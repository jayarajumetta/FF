using System.Text.RegularExpressions;
using Microsoft.Playwright;
namespace InsuranceAutomation.Core;
/// <summary>
/// Dropdown/autocomplete selection is deterministic and bounded:
/// exact option -> unique best partial option -> controlled Enter commit. Tab is never used to walk options.
/// </summary>
public static class ComponentAwareControlActions
{
    private const string RenderedOptionSelector = "[role=option],mat-option,.mat-mdc-option,.x-boundlist-item,li[role=option],.dropdown-item:not(.disabled)";
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
        try { await control.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs }); }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { }
        // Angular mat-select controls are frequently rendered aria-disabled="true" for a brief period
        // while the edit panel finishes initializing/binding (e.g. waiting on a parent field or async
        // lookup); Playwright's actionability check treats that as "not enabled" and can spin for the
        // full timeout. Waiting here for the disabled state to clear avoids that opaque 15s stall.
        await WaitForControlEnabledAsync(control, timeoutMs);
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
            // A prior mat-select/CDK overlay panel can still be closing (backdrop fade-out) when the next
            // control is clicked; that stray overlay intercepts the click so the intended panel never opens.
            // Waiting for any lingering overlay/backdrop to fully detach first makes each open deterministic.
            await WaitForStaleOverlaysToDetachAsync(page, timeoutMs);
            var opened = false;
            ControlMeta openedMeta = meta;
            for (var attempt = 0; attempt < 2 && !opened; attempt++)
            {
                // Editable autocomplete values should be entered before probing options; read-only/select triggers are clicked first.
                if ((meta.Tag is "input" or "textarea") && !meta.ReadOnly)
                    await control.FillAsync(value, new() { Timeout = timeoutMs });
                else
                    await control.ClickAsync(new() { Timeout = timeoutMs });
                // Angular Material only sets aria-controls/aria-owns on the trigger once its panel is open,
                // so the popup scope must be re-read after the click; otherwise the option search falls back
                // to an unscoped page-wide query and can collide with another still-open/overlapping panel.
                openedMeta = await ReadMetaAsync(control);
                if (string.IsNullOrWhiteSpace(openedMeta.PopupTargetId)) openedMeta = meta;
                opened = await HasVisibleOptionsAsync(page, openedMeta, optionTimeoutMs, optionPollIntervalMs);
                if (!opened && attempt == 0)
                {
                    // The click may have landed on a stale overlay/backdrop instead of opening this control's
                    // panel. Close any such overlay and retry once before giving up.
                    await CloseStrayOverlayAsync(page);
                }
            }
            if (await TryChooseRenderedOptionAsync(page, openedMeta, value, optionTimeoutMs, optionPollIntervalMs)) return;
            if (await CanCommitWithEnterAsync(page, control, openedMeta, value))
            {
                await control.PressAsync("Enter");
                return;
            }
            throw new PlaywrightException($"No exact or unambiguous partial rendered option matched '{value}', and Enter was not a safe selection/commit operation.");
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
        var started = Environment.TickCount64;
        while (Environment.TickCount64 - started <= timeoutMs)
        {
            var candidates = Options(page, meta);
            // Read visible option text in one browser round-trip to keep dropdown selection bounded.
            var visible = await candidates.EvaluateAllAsync<OptionSnapshot[]>(@"els => els.map((el,index) => {
                const style = getComputedStyle(el);
                const r = el.getBoundingClientRect();
                return { index, text: (el.innerText || el.textContent || '').replace(/\s+/g,' ').trim(),
                         visible: !!(r.width || r.height || el.getClientRects().length) && style.visibility !== 'hidden' && style.display !== 'none' };
            }).filter(x => x.visible)") ?? Array.Empty<OptionSnapshot>();
            if (visible.Length > 0)
            {
                var match = ChooseOptionIndex(visible.Select(x => x.Text).ToArray(), requested);
                if (match.Index >= 0)
                {
                    var option = candidates.Nth(visible[match.Index].Index);
                    // Bound every fallback attempt so an interception/overlay/detachment issue fails fast and
                    // lets the outer polling loop re-query fresh options instead of hanging on Playwright's
                    // default actionability timeout (which previously surfaced as a raw 15s TimeoutException).
                    var fallbackTimeoutMs = Math.Min(2000, Math.Max(500, timeoutMs));
                    try
                    {
                        await option.ClickAsync(new() { Timeout = fallbackTimeoutMs });
                        return true;
                    }
                    catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
                    {
                        // Some rendered options (e.g. Material tooltip-triggering mat-option rows) can report
                        // visible/enabled/stable yet still fail a real pointer click due to overlay interception.
                        // Fall back to a forced click, then a DOM click, both bounded to a short timeout.
                    }
                    try
                    {
                        await option.ClickAsync(new() { Timeout = fallbackTimeoutMs, Force = true });
                        return true;
                    }
                    catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
                    {
                    }
                    try
                    {
                        await option.EvaluateAsync("el => el.click()", null, new() { Timeout = fallbackTimeoutMs });
                        return true;
                    }
                    catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
                    {
                        // The option may have detached (e.g. the panel closed from a stray backdrop click).
                        // Fall through to the outer loop so it re-queries fresh rendered options instead of
                        // surfacing an opaque 15s timeout from this single stale element.
                    }
                }
            }
            if (Environment.TickCount64 - started >= timeoutMs) break;
            await Task.Delay(Math.Max(25, pollIntervalMs));
        }
        return false;
    }
    private const string OverlaySelector = ".cdk-overlay-pane,.cdk-overlay-backdrop,.mat-mdc-select-panel";
    private static async Task WaitForControlEnabledAsync(ILocator control, int timeoutMs)
    {
        var deadline = Environment.TickCount64 + Math.Max(250, timeoutMs);
        while (Environment.TickCount64 < deadline)
        {
            try
            {
                var disabled = await control.EvaluateAsync<bool>(@"el => {
                    const ariaDisabled = (el.getAttribute('aria-disabled') || '').toLowerCase() === 'true';
                    return ariaDisabled || !!el.disabled;
                }");
                if (!disabled) return;
            }
            catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { return; }
            await Task.Delay(100);
        }
    }
    private static async Task WaitForStaleOverlaysToDetachAsync(IPage page, int timeoutMs)
    {
        var deadline = Environment.TickCount64 + Math.Min(2000, Math.Max(250, timeoutMs));
        var overlays = CurrentScope(page).Locator(OverlaySelector);
        while (Environment.TickCount64 < deadline)
        {
            var count = await overlays.CountAsync();
            if (count == 0) return;
            await Task.Delay(50);
        }
    }
    private static async Task<bool> HasVisibleOptionsAsync(IPage page, ControlMeta meta, int timeoutMs, int pollIntervalMs)
    {
        var started = Environment.TickCount64;
        var candidates = Options(page, meta);
        while (Environment.TickCount64 - started <= timeoutMs)
        {
            var visible = await candidates.EvaluateAllAsync<int>(@"els => els.filter(el => {
                const style = getComputedStyle(el);
                const r = el.getBoundingClientRect();
                return (r.width || r.height || el.getClientRects().length) && style.visibility !== 'hidden' && style.display !== 'none';
            }).length");
            if (visible > 0) return true;
            await Task.Delay(Math.Max(25, pollIntervalMs));
        }
        return false;
    }
    private static async Task CloseStrayOverlayAsync(IPage page)
    {
        try { await page.Keyboard.PressAsync("Escape"); } catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { }
        await WaitForStaleOverlaysToDetachAsync(page, 1000);
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
        if (candidate.StartsWith(requested, StringComparison.OrdinalIgnoreCase)) return 9000 + requested.Length;
        if (requested.StartsWith(candidate, StringComparison.OrdinalIgnoreCase)) return 8500 + candidate.Length;
        if (candidate.Contains(requested, StringComparison.OrdinalIgnoreCase)) return 8000 + requested.Length;
        if (requested.Contains(candidate, StringComparison.OrdinalIgnoreCase)) return 7500 + candidate.Length;
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
    private static async Task<bool> CanCommitWithEnterAsync(IPage page, ILocator control, ControlMeta meta, string requested)
    {
        var isCombo = meta.Role is "combobox" or "listbox" || meta.Popup is "listbox" or "menu" ||
                      !string.IsNullOrWhiteSpace(meta.AriaAutocomplete) ||
                      meta.Cls.Contains("x-combo") || meta.Cls.Contains("autocomplete");
        if (!isCombo) return false;
        // Editable Duck Creek/ExtJS comboboxes accept a typed value by Enter when the popup does not expose
        // an exact or unique partial option. Only allow that fallback when the control really contains the
        // requested value; this prevents Enter from committing an unrelated highlighted option.
        if ((meta.Tag is "input" or "textarea") && !meta.ReadOnly)
        {
            var current = Normalize(await control.InputValueAsync());
            if (string.Equals(current, Normalize(requested), StringComparison.OrdinalIgnoreCase)) return true;
        }
        // Read-only/select-like controls may only commit an already-active option that is related to the request.
        var activeRoot = CurrentScope(page);
        var activeSelector = "[role=option][aria-selected=true],mat-option[aria-selected=true],.x-boundlist-selected,.mat-mdc-option-active,.active[role=option]";
        var active = string.IsNullOrWhiteSpace(meta.PopupTargetId)
            ? activeRoot.Locator(activeSelector)
            : activeRoot.Locator(PrefixSelectorsById(meta.PopupTargetId, activeSelector));
        var activeCount = await active.CountAsync();
        if (activeCount == 1 && await active.IsVisibleAsync())
        {
            var text = Normalize(await active.InnerTextAsync());
            return string.Equals(text, Normalize(requested), StringComparison.OrdinalIgnoreCase) ||
                   PartialScore(Normalize(requested), text) > 0;
        }
        return false;
    }
    private static ILocator Options(IPage page, ControlMeta meta) =>
        CurrentScope(page).Locator(string.IsNullOrWhiteSpace(meta.PopupTargetId) ? RenderedOptionSelector : PrefixSelectorsById(meta.PopupTargetId, RenderedOptionSelector));
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
