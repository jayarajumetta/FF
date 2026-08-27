using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>
/// v57 semantic control kernel. Dropdown/autocomplete selection is deterministic and bounded:
/// exact option -> unique best partial option -> controlled Enter commit. Tab is never used to walk options.
/// </summary>
public static class ComponentAwareControlActions
{
    private const string RenderedOptionSelector = "[role=option]:not(input):not([role=combobox]),mat-option:not(.mat-option-disabled),.mat-mdc-option:not(.mat-mdc-option-disabled),.mat-option,.mat-mdc-option,.x-boundlist-item,li[role=option],.dropdown-item:not(.disabled)";

    public static async Task SelectOrFillAsync(
        IPage page,
        ILocator control,
        string value,
        int timeoutMs = 15000,
        int optionTimeoutMs = 1200,
        int optionPollIntervalMs = 75)
    {
        ArgumentNullException.ThrowIfNull(page);
        ArgumentNullException.ThrowIfNull(control);
        value ??= string.Empty;
        await control.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });
        var meta = await ReadMetaAsync(control);

        if (meta.Tag == "select")
        {
            if (await TrySelectNativeAsync(control, value, timeoutMs)) return;
            throw new PlaywrightException($"No exact/controlled-partial native option matched '{value}'.");
        }

        if (meta.Type is "checkbox" or "radio")
        {
            var desired = ParseBoolean(value);
            if (meta.Type == "checkbox") await control.SetCheckedAsync(desired, new() { Timeout = timeoutMs });
            else if (desired) await control.CheckAsync(new() { Timeout = timeoutMs });
            return;
        }

        var componentLike = IsDropdownLike(meta);
        if (componentLike)
        {
            // For mat-select or similar components, click to open dropdown first, then type to filter
            var isMatSelect = meta.Cls.Contains("mat-select") || meta.Cls.Contains("mdc-select");

            if (isMatSelect && !meta.ReadOnly)
            {
                // Click to open mat-select dropdown
                await control.ClickAsync(new() { Timeout = timeoutMs });
                // Wait for dropdown to open and be ready
                await Task.Delay(250);

                // Try to wait for mat-options to appear before typing
                try
                {
                    var matOptions = page.Locator("mat-option, .mat-mdc-option");
                    await matOptions.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 1000 });
                }
                catch { /* Options may not be visible yet, continue */ }

                // Type to filter options (mat-select supports keyboard search)
                await page.Keyboard.TypeAsync(value, new() { Delay = 50 });
                // Give mat-options time to render/filter after typing - increased for Angular rendering
                await Task.Delay(400);
            }
            else if ((meta.Tag is "input" or "textarea") && !meta.ReadOnly)
            {
                // Editable autocomplete: fill value to trigger filtering
                await control.FillAsync(value, new() { Timeout = timeoutMs });
            }
            else
            {
                // Read-only/select triggers: click to open
                await control.ClickAsync(new() { Timeout = timeoutMs });
            }

            // Try to select from rendered options with improved partial matching
            if (await TryChooseRenderedOptionAsync(page, meta, value, optionTimeoutMs, optionPollIntervalMs)) return;

            // Fallback: Try Tab key to accept highlighted/focused option
            if (await TryCommitWithTabAsync(page, meta, value))
            {
                await page.Keyboard.PressAsync("Tab");
                return;
            }

            // Fallback: Try Enter to commit if applicable
            if (await CanCommitWithEnterAsync(page, control, meta, value))
            {
                await control.PressAsync("Enter");
                return;
            }

            throw new PlaywrightException($"No exact or unambiguous partial rendered option matched '{value}', and neither Tab nor Enter was a safe selection/commit operation.");
        }

        await control.FillAsync(value, new() { Timeout = timeoutMs });
        await control.EvaluateAsync("el => el.blur()");
    }

    public static async Task<bool> HasEnterCommitMeaningAsync(IPage page, ILocator control)
    {
        try
        {
            var meta = await ReadMetaAsync(control);
            if (meta.Tag == "select" || IsDropdownLike(meta)) return true;
            return false;
        }
        catch { return false; }
    }

    public static async Task SetBooleanAsync(ILocator control, bool desired, int timeoutMs = 15000)
    {
        await control.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });
        var input = control.Locator("input[type=checkbox],input[type=radio]");
        if (await input.CountAsync() == 1)
        {
            var type = await input.GetAttributeAsync("type");
            if (string.Equals(type, "checkbox", StringComparison.OrdinalIgnoreCase))
                await input.SetCheckedAsync(desired, new() { Timeout = timeoutMs });
            else if (desired) await input.CheckAsync(new() { Timeout = timeoutMs });
            return;
        }
        var state = await control.EvaluateAsync<bool?>(@"el => {
            const values=[el.getAttribute('aria-checked'),el.getAttribute('data-checked'),el.getAttribute('data-selected')];
            for (const v of values) if (v==='true') return true; else if (v==='false') return false;
            const c=(typeof el.className==='string'?el.className:'').toLowerCase();
            if (/\b(checked|selected|active|on)\b/.test(c)) return true;
            if (/\b(unchecked|off)\b/.test(c)) return false;
            return null;
        }");
        if (state is null)
        {
            if (!desired) throw new PlaywrightException("Refusing to blindly click a DIV toggle to false because its current state is unknown.");
            await control.ClickAsync(new() { Timeout = timeoutMs });
            return;
        }
        if (state.Value != desired) await control.ClickAsync(new() { Timeout = timeoutMs });
    }

    public static async Task DomClickAsync(ILocator control, int timeoutMs = 15000)
    {
        await control.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });
        await control.EvaluateAsync("el => el.click()");
    }

    private static async Task<bool> TrySelectNativeAsync(ILocator select, string requested, int timeoutMs)
    {
        var options = select.Locator("option");
        var texts = await options.AllInnerTextsAsync();
        var match = ChooseOptionIndex(texts, requested);
        if (match.Index < 0) return false;
        var actualLabel = texts[match.Index];
        await select.SelectOptionAsync(new SelectOptionValue { Label = actualLabel }, new() { Timeout = timeoutMs });
        return true;
    }

    private static async Task<bool> TryChooseRenderedOptionAsync(IPage page, ControlMeta meta, string requested, int timeoutMs, int pollIntervalMs)
    {
        // Ensure minimum timeout to allow at least one attempt
        timeoutMs = Math.Max(500, timeoutMs);
        pollIntervalMs = Math.Max(25, pollIntervalMs);

        var started = Environment.TickCount64;
        var attempts = 0;
        var lastCount = 0;

        // Use do-while to ensure at least one execution
        do
        {
            attempts++;
            try
            {
                var candidates = Options(page, meta);
                var count = await candidates.CountAsync();
                lastCount = count;

                // If no candidates found at all, wait and retry (unless timeout exceeded)
                if (count == 0)
                {
                    if (Environment.TickCount64 - started >= timeoutMs) break;
                    await Task.Delay(pollIntervalMs);
                    continue;
                }

                // One browser round-trip replaces N IsVisible/InnerText calls. This is the main v57 dropdown latency improvement.
                var visible = await candidates.EvaluateAllAsync<OptionSnapshot[]>(@"els => els.map((el,index) => {
                    const style = getComputedStyle(el);
                    const r = el.getBoundingClientRect();
                    // Filter out input and combobox elements from option list
                    const tag = (el.tagName || '').toLowerCase();
                    const role = el.getAttribute('role') || '';
                    if (tag === 'input' || role === 'combobox') return null;

                    return { index, text: (el.innerText || el.textContent || '').replace(/\s+/g,' ').trim(),
                             visible: !!(r.width || r.height || el.getClientRects().length) && style.visibility !== 'hidden' && style.display !== 'none' };
                }).filter(x => x !== null && x.visible)") ?? Array.Empty<OptionSnapshot>();

                if (visible.Length > 0)
                {
                    var match = ChooseOptionIndex(visible.Select(x => x.Text).ToArray(), requested);
                    if (match.Index >= 0)
                    {
                        var targetOption = candidates.Nth(visible[match.Index].Index);
                        // Ensure the option is still visible before clicking
                        await targetOption.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = Math.Min(500, timeoutMs) });
                        await targetOption.ClickAsync(new() { Timeout = Math.Max(500, timeoutMs) });
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                // If evaluation fails (e.g., options not yet rendered), continue polling
                // Only break if we've exceeded timeout
                if (Environment.TickCount64 - started >= timeoutMs) break;
            }

            // Check timeout before delaying
            if (Environment.TickCount64 - started >= timeoutMs) break;
            await Task.Delay(pollIntervalMs);

        } while (Environment.TickCount64 - started < timeoutMs || attempts == 1); // Ensure at least one attempt

        return false;
    }

    private static OptionMatch ChooseOptionIndex(IReadOnlyList<string> optionTexts, string requested)
    {
        var expected = Normalize(requested);
        if (string.IsNullOrWhiteSpace(expected)) return new(-1, false, 0);

        var exactMatches = Enumerable.Range(0, optionTexts.Count)
            .Where(i => string.Equals(Normalize(optionTexts[i]), expected, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        if (exactMatches.Length == 1) return new(exactMatches[0], true, 10000);
        if (exactMatches.Length > 1) return new(-1, true, 10000); // duplicate exact labels: refuse arbitrary selection.

        var ranked = new List<(int Index, int Score)>();
        for (var i = 0; i < optionTexts.Count; i++)
        {
            var candidate = Normalize(optionTexts[i]);
            if (string.IsNullOrWhiteSpace(candidate)) continue;
            var score = PartialScore(expected, candidate);
            if (score > 0) ranked.Add((i, score));
        }
        if (ranked.Count == 0) return new(-1, false, 0);
        var ordered = ranked.OrderByDescending(x => x.Score).ThenBy(x => x.Index).ToArray();
        // Controlled partial fallback: the best candidate must be unique. A tie is rejected rather than guessed.
        if (ordered.Length > 1 && ordered[0].Score == ordered[1].Score) return new(-1, false, ordered[0].Score);
        return new(ordered[0].Index, false, ordered[0].Score);
    }

    private static int PartialScore(string requested, string candidate)
    {
        // Exact match (handled earlier, but included for completeness)
        if (string.Equals(requested, candidate, StringComparison.OrdinalIgnoreCase)) return 10000 + requested.Length;

        // Best: Candidate starts with requested (e.g., "Cal" matches "California")
        if (candidate.StartsWith(requested, StringComparison.OrdinalIgnoreCase)) return 9000 + requested.Length;

        // Requested starts with candidate (e.g., "California" typed, "Cal" option)
        if (requested.StartsWith(candidate, StringComparison.OrdinalIgnoreCase)) return 8500 + candidate.Length;

        // IndexOf match: Candidate contains requested at any position (e.g., "New" matches "New York")
        var indexInCandidate = candidate.IndexOf(requested, StringComparison.OrdinalIgnoreCase);
        if (indexInCandidate >= 0)
        {
            // Prefer matches at the beginning, but accept any indexOf match
            var positionBonus = Math.Max(0, 100 - indexInCandidate);
            return 8000 + requested.Length + positionBonus;
        }

        // Requested contains candidate substring
        if (requested.Contains(candidate, StringComparison.OrdinalIgnoreCase)) return 7500 + candidate.Length;

        // Token-based fuzzy matching for multi-word scenarios
        var requestTokens = Tokens(requested);
        var candidateTokens = Tokens(candidate);
        if (requestTokens.Count == 0 || candidateTokens.Count == 0) return 0;
        var shared = requestTokens.Intersect(candidateTokens, StringComparer.OrdinalIgnoreCase).Count();
        if (shared == 0) return 0;
        var coverage = (double)shared / Math.Min(requestTokens.Count, candidateTokens.Count);
        return coverage >= 0.75 ? 5000 + (shared * 100) : 0;
    }

    private static HashSet<string> Tokens(string value) =>
        Regex.Split(Normalize(value), @"[^A-Za-z0-9]+")
            .Where(x => x.Length > 1)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

    private static async Task<bool> TryCommitWithTabAsync(IPage page, ControlMeta meta, string requested)
    {
        // Tab is useful for mat-select and similar components where an option is focused but not clicked
        if (!(meta.Role is "combobox" or "listbox" || meta.Popup is "listbox" or "menu" || meta.Cls.Contains("mat-select") || meta.Cls.Contains("mdc-select") || !string.IsNullOrWhiteSpace(meta.AriaAutocomplete)))
            return false;

        var options = Options(page, meta);
        var count = await options.CountAsync();
        if (count == 0) return false;

        // Check if there's a focused/highlighted mat-option (EXCLUDE input and combobox elements)
        var activeRoot = CurrentScope(page);
        // Only look for mat-option elements that are highlighted/active, not input or combobox
        var active = string.IsNullOrWhiteSpace(meta.PopupTargetId)
            ? activeRoot.Locator("mat-option[aria-selected=true]:not(input):not([role=combobox]),mat-option.mat-mdc-option-active:not(input),mat-option.mat-option-active:not(input),.mat-mdc-option[aria-selected=true]:not(input),.mat-mdc-option-active:not(input),[role=option][aria-selected=true]:not(input):not([role=combobox])")
            : activeRoot.Locator(PrefixSelectorsById(meta.PopupTargetId, "mat-option[aria-selected=true],mat-option.mat-mdc-option-active,mat-option.mat-option-active,.mat-mdc-option[aria-selected=true],.mat-mdc-option-active,[role=option][aria-selected=true]"));

        var activeCount = await active.CountAsync();
        if (activeCount >= 1)
        {
            try
            {
                // Filter to only get visible mat-option elements, not input/combobox
                for (var i = 0; i < activeCount; i++)
                {
                    var candidate = active.Nth(i);
                    var tagName = await candidate.EvaluateAsync<string>("el => el.tagName.toLowerCase()");

                    // Skip if it's an input or has combobox role
                    if (tagName == "input") continue;

                    var role = await candidate.GetAttributeAsync("role");
                    if (role == "combobox") continue;

                    if (await candidate.IsVisibleAsync())
                    {
                        var text = Normalize(await candidate.InnerTextAsync());
                        // Accept Tab if the focused mat-option is a partial match (indexOf check)
                        if (PartialScore(Normalize(requested), text) > 0)
                            return true;
                    }
                }
            }
            catch { return false; }
        }
        return false;
    }

    private static async Task<bool> CanCommitWithEnterAsync(IPage page, ILocator control, ControlMeta meta, string requested)
    {
        if (!(meta.Role is "combobox" or "listbox" || meta.Popup is "listbox" or "menu" || !string.IsNullOrWhiteSpace(meta.AriaAutocomplete)))
            return false;

        var options = Options(page, meta);
        var count = await options.CountAsync();
        if (count == 0)
        {
            // Editable autocomplete/combobox Enter is a known commit action; plain input Enter is not assumed.
            return (meta.Tag is "input" or "textarea") && !string.IsNullOrWhiteSpace(meta.AriaAutocomplete);
        }

        var activeRoot = CurrentScope(page);
        var active = string.IsNullOrWhiteSpace(meta.PopupTargetId)
            ? activeRoot.Locator("[role=option][aria-selected=true],mat-option[aria-selected=true],.x-boundlist-selected,.mat-mdc-option-active,.active[role=option]")
            : activeRoot.Locator(PrefixSelectorsById(meta.PopupTargetId, "[role=option][aria-selected=true],mat-option[aria-selected=true],.x-boundlist-selected,.mat-mdc-option-active,.active[role=option]"));
        var activeCount = await active.CountAsync();
        if (activeCount == 1 && await active.IsVisibleAsync())
        {
            var text = Normalize(await active.InnerTextAsync());
            return PartialScore(Normalize(requested), text) > 0 || string.Equals(text, Normalize(requested), StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }

    private static ILocator Options(IPage page, ControlMeta meta)
    {
        var scope = CurrentScope(page);

        // For mat-select, try to use panel-specific selector if available
        if (meta.Cls.Contains("mat-select") || meta.Cls.Contains("mdc-select"))
        {
            // Try to find mat-options in the overlay panel first (Angular Material specific)
            var matPanelOptions = scope.Locator(".mat-select-panel mat-option, .mat-mdc-select-panel mat-option, .mat-select-panel .mat-mdc-option, .mat-mdc-select-panel .mat-mdc-option, .cdk-overlay-pane mat-option, .cdk-overlay-pane .mat-mdc-option");
            return matPanelOptions;
        }

        // Default: use the standard selector with optional ID prefix
        return string.IsNullOrWhiteSpace(meta.PopupTargetId) 
            ? scope.Locator(RenderedOptionSelector) 
            : scope.Locator(PrefixSelectorsById(meta.PopupTargetId, RenderedOptionSelector));
    }

    private static string PrefixSelectorsById(string id, string selectors)
    {
        var escaped = id.Replace("\\", "\\\\").Replace("'", "\\'");
        var root = $"[id='{escaped}']";
        return string.Join(",", selectors.Split(',').Select(x => $"{root} {x.Trim()}"));
    }

    private static ILocatorScope CurrentScope(IPage page) =>
        FrameExecutionContext.Current is null ? new PageScope(page) : new FrameScope(FrameExecutionContext.Current);

    private static async Task<ControlMeta> ReadMetaAsync(ILocator control) =>
        await control.EvaluateAsync<ControlMeta>(@"el => ({
            tag: (el.tagName || '').toLowerCase(),
            type: (el.getAttribute('type') || '').toLowerCase(),
            role: (el.getAttribute('role') || '').toLowerCase(),
            popup: (el.getAttribute('aria-haspopup') || '').toLowerCase(),
            cls: typeof el.className === 'string' ? el.className.toLowerCase() : '',
            fieldref: el.getAttribute('fieldref') || el.getAttribute('data-fieldref') || '',
            ariaAutocomplete: el.getAttribute('aria-autocomplete') || '',
            popupTargetId: el.getAttribute('aria-controls') || el.getAttribute('aria-owns') || '',
            readOnly: !!el.readOnly
        })") ?? new ControlMeta();

    private static bool IsDropdownLike(ControlMeta meta) =>
        meta.Role is "combobox" or "listbox" || meta.Popup is "listbox" or "menu" ||
        meta.Cls.Contains("mat-select") || meta.Cls.Contains("mdc-select") ||
        meta.Cls.Contains("x-form-trigger") || meta.Cls.Contains("x-combo") || meta.Cls.Contains("autocomplete") ||
        !string.IsNullOrWhiteSpace(meta.AriaAutocomplete) ||
        (meta.Tag == "input" && meta.ReadOnly && !string.IsNullOrWhiteSpace(meta.Fieldref));

    private static string Normalize(string? value) => Regex.Replace(value ?? string.Empty, @"\s+", " ").Trim();
    private static bool ParseBoolean(string value) => value.Trim().Equals("true", StringComparison.OrdinalIgnoreCase) || value.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase) || value.Trim() == "1";

    private sealed record OptionMatch(int Index, bool Exact, int Score);
    private sealed class OptionSnapshot
    {
        public int Index { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool Visible { get; set; }
    }
    private sealed class ControlMeta
    {
        public string Tag { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Popup { get; set; } = string.Empty;
        public string Cls { get; set; } = string.Empty;
        public string Fieldref { get; set; } = string.Empty;
        public string AriaAutocomplete { get; set; } = string.Empty;
        public string PopupTargetId { get; set; } = string.Empty;
        public bool ReadOnly { get; set; }
    }

    private interface ILocatorScope { ILocator Locator(string selector); }
    private sealed class PageScope(IPage page) : ILocatorScope { public ILocator Locator(string selector) => page.Locator(selector); }
    private sealed class FrameScope(IFrameLocator frame) : ILocatorScope { public ILocator Locator(string selector) => frame.Locator(selector); }
}
