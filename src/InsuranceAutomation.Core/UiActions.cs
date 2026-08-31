using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class UiActions
{
    private readonly RunLogger _logger;
    private readonly BrowserSession _browser;
    private readonly FrameworkConfig _config;
    private readonly ScenarioReport? _report;
    private readonly DeferredVerificationCollector? _verificationFailures;
    private readonly HashSet<string> _semanticallyCommittedControls = new(StringComparer.OrdinalIgnoreCase);
    private readonly IRuntimeLocatorResolver? _runtimeLocatorResolver;

    public UiActions(BrowserSession browser, FrameworkConfig config, RunLogger logger)
        : this(browser, config, logger, null, "Unknown", null, null) { }

    public UiActions(BrowserSession browser, FrameworkConfig config, RunLogger logger, ScenarioReport? report, string applicationName)
        : this(browser, config, logger, report, applicationName, null, null) { }

    public UiActions(BrowserSession browser, FrameworkConfig config, RunLogger logger, ScenarioReport? report, string applicationName, DeferredVerificationCollector? verificationFailures, IRuntimeLocatorResolver? runtimeLocatorResolver = null)
    {
        _browser = browser;
        _logger = logger;
        _config = config;
        _report = report;
        _verificationFailures = verificationFailures;
        _runtimeLocatorResolver = runtimeLocatorResolver;
    }

    public async Task WaitReadyBestEffortAsync(ILocator locator, ControlIntent intent, int timeoutMs)
    {
        try { await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs }); }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { _logger.Warn($"DEPENDENT CONTROL WAIT CONTINUING: {intent}; {ex.Message}"); }
    }

    public Task ClickAsync(ILocator locator) => ClickAsync(locator, new ControlIntent("Application", "Control"));
    public Task FillAsync(ILocator locator, string value) => FillAsync(locator, value, new ControlIntent("Application", "Control"));
    public Task ClickAsync(ILocator locator, ControlIntent intent) => ExecuteAsync(locator, intent, "click", x => ClickSemanticAsync(x));
    public async Task FillAsync(ILocator locator, string value, ControlIntent intent)
    {
        await ExecuteAsync(locator, intent, "fill", x => ComponentAwareControlActions.SelectOrFillAsync(
            _browser.Page, x, value ?? string.Empty, _config.Browser.ActionTimeoutMs,
            _config.Waits.DropdownOptionTimeoutMs, _config.Waits.DropdownPollIntervalMs));
        _semanticallyCommittedControls.Add(IntentKey(intent));
    }

    public async Task PressSequentiallyAsync(ILocator locator, string value, ControlIntent intent, int delayMs = 20)
    {
        await ExecuteAsync(locator, intent, "press-sequentially", async x =>
        {
            await x.ClickAsync();
            try { await x.FillAsync(string.Empty); } catch { }
            await x.PressSequentiallyAsync(value ?? string.Empty, new LocatorPressSequentiallyOptions { Delay = Math.Max(0, delayMs) });
        });
    }

    public async Task PressAsync(ILocator locator, string key, ControlIntent intent)
    {
        var normalized = NormalizeKey(key).Trim();
        // Tosca CLICK is an interaction intent, never a keyboard key.
        if (normalized.Equals("CLICK", StringComparison.OrdinalIgnoreCase)) { await ClickAsync(locator, intent); return; }
        if (normalized.Equals("DOUBLECLICK", StringComparison.OrdinalIgnoreCase))
        { await ExecuteAsync(locator, intent, "double-click", x => x.DblClickAsync()); return; }

        if (normalized.Equals("Tab", StringComparison.OrdinalIgnoreCase) && _semanticallyCommittedControls.Contains(IntentKey(intent)))
        {
            _logger.Info($"KEYBOARD STEERING SUPPRESSED: {intent} key=Tab; semantic set/select/fill already committed the control.");
            return;
        }

        if (normalized.Equals("Enter", StringComparison.OrdinalIgnoreCase))
        {
            if (_semanticallyCommittedControls.Contains(IntentKey(intent)))
            {
                _logger.Info($"KEYBOARD STEERING SUPPRESSED: {intent} key=Enter; semantic set/select/fill already performed any required selection commit.");
                return;
            }
            if (!await ComponentAwareControlActions.HasEnterCommitMeaningAsync(_browser.Page, locator))
            {
                _logger.Info($"KEYBOARD STEERING SUPPRESSED: {intent} key=Enter; resolved control does not expose dropdown/autocomplete commit semantics.");
                return;
            }
        }
        await ExecuteAsync(locator, intent, "press", x => x.PressAsync(normalized));
    }

    /// <summary>
    /// Component-aware set semantics for dropdowns, autocomplete, toggles and editable controls.
    /// </summary>
    public async Task SmartSetAsync(ILocator locator, string value, ControlIntent intent)
    {
        await ExecuteAsync(locator, intent, "set", async x =>
        {
            var component = await DetectComponentAsync(x);
            switch (component)
            {
                case ComponentKind.NativeSelect:
                case ComponentKind.MaterialSelect:
                case ComponentKind.Autocomplete:
                    await ComponentAwareControlActions.SelectOrFillAsync(_browser.Page, x, value ?? string.Empty,
                        _config.Browser.ActionTimeoutMs, _config.Waits.DropdownOptionTimeoutMs, _config.Waits.DropdownPollIntervalMs);
                    return;
                case ComponentKind.RadioGroup:
                case ComponentKind.ChipGroup:
                    await SelectRadioOrChipAsync(x, value, intent); return;
                case ComponentKind.Checkbox:
                    await SetCheckboxAsync(x, ParseBoolean(value)); return;
                case ComponentKind.DatePicker:
                    await SetDateAsync(x, value); return;
            }

            var tag = (await x.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
            var type = (await x.GetAttributeAsync("type") ?? "").ToLowerInvariant();
            var role = (await x.GetAttributeAsync("role") ?? "").ToLowerInvariant();
            if (type == "radio") { await x.SetCheckedAsync(ParseBoolean(value, defaultValue: true)); return; }
            var editable = tag is "input" or "textarea" || role == "textbox" ||
                           string.Equals(await x.GetAttributeAsync("contenteditable"), "true", StringComparison.OrdinalIgnoreCase);
            if (editable) { await x.FillAsync(value ?? string.Empty); return; }
            if (tag is "button" or "a" or "div" or "span" || role is "button" or "radio" or "option" or "link")
            { await SelectResolvedClickableAsync(x, value, intent); return; }
            throw new PlaywrightException($"Semantic set mismatch for {intent.Page}.{intent.Control}: tag={tag}, type={type}, role={role}.");
        });
        _semanticallyCommittedControls.Add(IntentKey(intent));
    }

    /// <summary>
    /// Source/component-aware Select semantics. Native and rendered dropdowns use one bounded deterministic algorithm.
    /// </summary>
    public async Task SelectAsync(ILocator locator, string value, ControlIntent intent)
    {
        await ExecuteAsync(locator, intent, "select", async x =>
        {
            var component = await DetectComponentAsync(x);
            switch (component)
            {
                case ComponentKind.NativeSelect:
                case ComponentKind.MaterialSelect:
                case ComponentKind.Autocomplete:
                    await ComponentAwareControlActions.SelectOrFillAsync(_browser.Page, x, value ?? string.Empty,
                        _config.Browser.ActionTimeoutMs, _config.Waits.DropdownOptionTimeoutMs, _config.Waits.DropdownPollIntervalMs);
                    return;
                case ComponentKind.RadioGroup:
                case ComponentKind.ChipGroup:
                    await SelectRadioOrChipAsync(x, value, intent); return;
                case ComponentKind.Checkbox:
                    await SetCheckboxAsync(x, ParseBoolean(value, defaultValue: true)); return;
                case ComponentKind.DatePicker:
                    await SetDateAsync(x, value); return;
                default:
                    await SelectResolvedClickableAsync(x, value, intent); return;
            }
        });
        _semanticallyCommittedControls.Add(IntentKey(intent));
    }

    public Task ActivateTabAsync(ILocator container, string tabName, ControlIntent intent) => ExecuteAsync(container, intent, "activate-tab", async x =>
    {
        var tab = x.GetByRole(AriaRole.Tab, new() { Name = tabName, Exact = true });
        await ClickSingleVisibleAsync(tab, $"tab '{tabName}'", intent);
    });

    public Task ClickDialogActionAsync(ILocator dialog, string actionName, ControlIntent intent) => ExecuteAsync(dialog, intent, "dialog-action", async x =>
    {
        var button = x.GetByRole(AriaRole.Button, new() { Name = actionName, Exact = true });
        await ClickSingleVisibleAsync(button, $"dialog action '{actionName}'", intent);
    });

    public Task ToggleExpansionPanelAsync(ILocator panel, bool expanded, ControlIntent intent) => ExecuteAsync(panel, intent, "expansion-panel", async x =>
    {
        var header = (await x.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")) == "mat-expansion-panel-header"
            ? x
            : x.Locator("mat-expansion-panel-header, [role=button]").First;
        var actual = string.Equals(await header.GetAttributeAsync("aria-expanded"), "true", StringComparison.OrdinalIgnoreCase);
        if (actual != expanded) await header.ClickAsync();
    });

    public Task ClickGridCellAsync(ILocator grid, string cellText, ControlIntent intent) => ExecuteAsync(grid, intent, "grid-cell", async x =>
    {
        var cell = x.GetByRole(AriaRole.Gridcell, new() { Name = cellText, Exact = true });
        if (await cell.CountAsync() == 0) cell = x.Locator("td,[role=gridcell]").Filter(new() { HasText = cellText });
        await ClickSingleVisibleAsync(cell, $"grid cell '{cellText}'", intent);
    });


    private static async Task SelectResolvedClickableAsync(ILocator control, string value, ControlIntent intent)
    {
        var tag = (await control.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        var type = (await control.GetAttributeAsync("type") ?? "").ToLowerInvariant();
        var role = (await control.GetAttributeAsync("role") ?? "").ToLowerInvariant();

        if (tag == "input" && type == "radio")
        {
            await control.SetCheckedAsync(ParseBoolean(value, defaultValue: true));
            return;
        }

        if (tag == "input" && type == "checkbox")
        {
            await control.SetCheckedAsync(ParseBoolean(value, defaultValue: true));
            return;
        }

        var clickable = tag is "button" or "a" or "div" or "span" or "mat-option" or "mat-chip" or "mat-chip-option" or "mat-radio-button"
                        || role is "button" or "radio" or "option" or "tab";
        if (!clickable)
            throw new PlaywrightException($"Semantic select mismatch for {intent.Page}.{intent.Control}: resolved control is tag={tag}, type={type}, role={role}; it is not a native select, Material select, autocomplete, radio/chip/checkbox, or clickable option.");

        if (!string.IsNullOrWhiteSpace(value))
        {
            var text = string.Empty;
            try { text = (await control.InnerTextAsync()).Trim(); } catch { }
            var boolLike = value.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                           value.Equals("no", StringComparison.OrdinalIgnoreCase) ||
                           value.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                           value.Equals("false", StringComparison.OrdinalIgnoreCase);
            if (!boolLike && !string.IsNullOrWhiteSpace(text) &&
                !text.Contains(value, StringComparison.OrdinalIgnoreCase) &&
                !value.Contains(text, StringComparison.OrdinalIgnoreCase))
            {
                throw new PlaywrightException($"Resolved clickable text '{text}' does not match requested selection '{value}' for {intent.Page}.{intent.Control}. Refusing to guess a dropdown.");
            }
        }

        await control.ClickAsync();
    }


    private static async Task SetDateAsync(ILocator control, string value)
    {
        var tag = (await control.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        var input = tag == "input" ? control : control.Locator("input").First;
        await input.FillAsync(value ?? string.Empty);
    }

    private static async Task SetCheckboxAsync(ILocator control, bool value)
    {
        var tag = (await control.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        var type = (await control.GetAttributeAsync("type") ?? "").ToLowerInvariant();
        if (tag == "input" && type == "checkbox")
        {
            await control.SetCheckedAsync(value);
            return;
        }

        var input = control.Locator("input[type=checkbox]");
        if (await input.CountAsync() == 1)
        {
            await input.SetCheckedAsync(value);
            return;
        }

        var current = string.Equals(await control.GetAttributeAsync("aria-checked"), "true", StringComparison.OrdinalIgnoreCase);
        if (current != value) await control.ClickAsync();
    }

    private async Task SelectRadioOrChipAsync(ILocator control, string value, ControlIntent intent)
    {
        var option = control.GetByRole(AriaRole.Radio, new() { Name = value, Exact = true });
        if (await option.CountAsync() == 0) option = control.GetByRole(AriaRole.Option, new() { Name = value, Exact = true });
        if (await option.CountAsync() == 0) option = control.Locator("mat-radio-button,mat-chip-option,mat-chip,[role=radio],[role=option]").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex($@"^\s*{System.Text.RegularExpressions.Regex.Escape(value)}\s*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });
        await ClickSingleVisibleAsync(option, $"radio/chip option '{value}'", intent);
    }

    private static async Task ClickSingleVisibleAsync(ILocator candidates, string description, ControlIntent intent)
    {
        var count = await candidates.CountAsync();
        if (count == 0) throw new PlaywrightException($"No {description} matched for {intent.Page}.{intent.Control}.");
        if (count == 1)
        {
            await candidates.ClickAsync();
            return;
        }

        ILocator? visible = null;
        var visibleCount = 0;
        for (var i = 0; i < count; i++)
        {
            var candidate = candidates.Nth(i);
            if (!await candidate.IsVisibleAsync()) continue;
            visible = candidate;
            visibleCount++;
            if (visibleCount > 1) break;
        }
        if (visibleCount == 1 && visible is not null)
        {
            await visible.ClickAsync();
            return;
        }
        throw new PlaywrightException($"Strict component collision: {count} matches ({visibleCount} visible) for {description} at {intent.Page}.{intent.Control}. Add page/section or Tosca occurrence evidence; no arbitrary First/Nth selection is allowed.");
    }

    private static async Task<ComponentKind> DetectComponentAsync(ILocator control)
    {
        var tag = (await control.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        var type = (await control.GetAttributeAsync("type") ?? "").ToLowerInvariant();
        var role = (await control.GetAttributeAsync("role") ?? "").ToLowerInvariant();
        var cls = (await control.GetAttributeAsync("class") ?? "").ToLowerInvariant();
        var ariaAutocomplete = await control.GetAttributeAsync("aria-autocomplete");
        var ariaHasPopup = (await control.GetAttributeAsync("aria-haspopup") ?? "").ToLowerInvariant();

        if (tag == "select") return ComponentKind.NativeSelect;
        if (tag == "mat-select" || (role == "combobox" && tag != "input" && string.IsNullOrWhiteSpace(ariaAutocomplete)) || (ariaHasPopup == "listbox" && tag != "input")) return ComponentKind.MaterialSelect;
        if (tag == "mat-autocomplete" || !string.IsNullOrWhiteSpace(ariaAutocomplete) || (role == "combobox" && tag == "input")) return ComponentKind.Autocomplete;
        if (tag == "mat-radio-group" || role == "radiogroup") return ComponentKind.RadioGroup;
        if (tag.Contains("chip", StringComparison.Ordinal) || cls.Contains("chip-set", StringComparison.Ordinal)) return ComponentKind.ChipGroup;
        if (tag == "mat-checkbox" || type == "checkbox" || role == "checkbox") return ComponentKind.Checkbox;
        if (tag.Contains("datepicker", StringComparison.Ordinal) || type == "date" || (await control.GetAttributeAsync("matdatepicker")) is not null) return ComponentKind.DatePicker;
        if (tag == "table" || role is "grid" or "gridcell") return ComponentKind.TableGrid;
        if (tag == "mat-dialog-container" || role == "dialog") return ComponentKind.Dialog;
        if (tag == "mat-tab-group" || role == "tab") return ComponentKind.Tabs;
        if (tag.StartsWith("mat-expansion-panel", StringComparison.Ordinal)) return ComponentKind.ExpansionPanel;
        return ComponentKind.Generic;
    }

    private static async Task ClickSemanticAsync(ILocator control)
    {
        var tag = (await control.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        if (tag == "mat-expansion-panel")
        {
            var header = control.Locator("mat-expansion-panel-header");
            if (await header.CountAsync() == 1) { await header.ClickAsync(); return; }
        }
        await control.ClickAsync();
    }

    public async Task<bool> ExistsAsync(ILocator locator)
    {
        try { return await locator.CountAsync() > 0 && await locator.First.IsVisibleAsync(); }
        catch { return false; }
    }

    public async Task WaitAsync(ILocator locator, string expected, ControlIntent intent)
    {
        await WaitForPageReadyBestEffortAsync();
        if (expected.Contains("Absent", StringComparison.OrdinalIgnoreCase) ||
            expected.Contains("Hidden", StringComparison.OrdinalIgnoreCase))
        {
            await locator.WaitForAsync(new LocatorWaitForOptions
            {
                State = expected.Contains("Absent", StringComparison.OrdinalIgnoreCase)
                    ? WaitForSelectorState.Detached
                    : WaitForSelectorState.Hidden,
                Timeout = _config.Waits.VerifyTimeoutMs
            });
            return;
        }

        await ExecuteAsync(locator, intent, "wait-visible", x => x.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible,
            Timeout = _config.Waits.ElementReadyTimeoutMs
        }));
    }

    public async Task VerifyAsync(ILocator locator, string expected, string property, ControlIntent intent)
    {
        try
        {
            await WaitForPageReadyBestEffortAsync();
            var normalized = (expected ?? string.Empty).Trim();
            if (normalized.Equals("Visible", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("Exists", StringComparison.OrdinalIgnoreCase) ||
                normalized.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                await ExecuteAsync(locator, intent, "verify-visible", x => x.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = _config.Waits.VerifyTimeoutMs
                }));
                return;
            }

            if (normalized.Equals("Absent", StringComparison.OrdinalIgnoreCase) || normalized.Equals("Hidden", StringComparison.OrdinalIgnoreCase))
            {
                await locator.WaitForAsync(new LocatorWaitForOptions
                {
                    State = normalized.Equals("Absent", StringComparison.OrdinalIgnoreCase) ? WaitForSelectorState.Detached : WaitForSelectorState.Hidden,
                    Timeout = _config.Waits.VerifyTimeoutMs
                });
                return;
            }

            if (normalized.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
            {
                await ExecuteAsync(locator, intent, "verify-enabled", async x =>
                {
                    await x.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = _config.Waits.VerifyTimeoutMs });
                    if (!await x.IsEnabledAsync()) throw new InvalidOperationException("Expected control to be enabled.");
                });
                return;
            }

            var propertySpec = (property ?? string.Empty).Trim();
            var regexMode = propertySpec.StartsWith("Regex:", StringComparison.OrdinalIgnoreCase) ||
                            normalized.StartsWith("Regex:", StringComparison.OrdinalIgnoreCase);
            var notEqualMode = propertySpec.StartsWith("NotEqual:", StringComparison.OrdinalIgnoreCase) ||
                               normalized.StartsWith("NotEqual:", StringComparison.OrdinalIgnoreCase);

            var captureProperty = propertySpec;
            if (captureProperty.StartsWith("Regex:", StringComparison.OrdinalIgnoreCase)) captureProperty = captureProperty[6..].Trim();
            if (captureProperty.StartsWith("NotEqual:", StringComparison.OrdinalIgnoreCase)) captureProperty = captureProperty[9..].Trim();

            var actual = await CaptureAsync(locator, captureProperty, intent);
            if (regexMode)
            {
                var pattern = normalized.StartsWith("Regex:", StringComparison.OrdinalIgnoreCase) ? normalized[6..] : normalized;
                if (!System.Text.RegularExpressions.Regex.IsMatch(actual, pattern))
                    throw new InvalidOperationException($"Expected value to match regex '{pattern}' but found '{actual}'.");
                return;
            }
            if (notEqualMode)
            {
                var notExpected = normalized.StartsWith("NotEqual:", StringComparison.OrdinalIgnoreCase) ? normalized[9..] : normalized;
                if (string.Equals(actual, notExpected, StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException($"Expected value to differ from '{notExpected}', but it was equal.");
                return;
            }
            if (!string.Equals(actual, normalized, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"Expected '{normalized}' but found '{actual}'.");
        }
        catch (Exception ex) when (ShouldDeferVerification(ex))
        {
            string? screenshot = null;
            try
            {
                if (_browser.IsStarted && _config.Browser.ScreenshotOnFailure)
                    screenshot = await _browser.CaptureScreenshotAsync($"verify_{Safe(intent.Page)}_{Safe(intent.Control)}_{DateTime.Now:HHmmssfff}.png");
            }
            catch { }

            var failure = new DeferredVerificationFailure(
                DateTimeOffset.Now, ExecutionIntent.Current.Step, intent.Page, intent.Control, property, expected, ex.Message, screenshot);
            _verificationFailures!.Add(failure);
            _report?.RecordDeferredVerification(failure);
            _logger.Error($"DEFERRED VERIFY FAILURE: Step={failure.BusinessStep}; Control={intent}; Expected={expected}; Property={property}; {ex.Message}. Scenario continues; final outcome will fail after evidence publication.");
        }
    }

    public Task<string> CaptureAsync(ILocator locator, string property, ControlIntent intent) => ExecuteAsync(locator, intent, "capture", async x =>
    {
        if (property.Contains("Value", StringComparison.OrdinalIgnoreCase))
        {
            try { return await x.InputValueAsync(); } catch { }
        }
        try { return (await x.InnerTextAsync()).Trim(); }
        catch { return (await x.TextContentAsync() ?? "").Trim(); }
    });

    public Task ReviewRequiredAsync(string reason)
    {
        _logger.Warn($"SOURCE TRACE NOTE: {reason}");
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync(ILocator locator, ControlIntent intent, string action, Func<ILocator, Task> operation)
    {
        await WaitForPageReadyBestEffortAsync();
        try
        {
            await PrepareForActionAsync(locator, intent, action);
            var resolved = _runtimeLocatorResolver is null ? locator : await _runtimeLocatorResolver.ResolveAsync(_browser.Page, locator, intent, action) ?? locator;
            if (!ReferenceEquals(resolved, locator)) await PrepareForActionAsync(resolved, intent, action);
            using var frameScope = FrameExecutionContext.Push(null);
            await ExecuteWithHighlightAsync(resolved, action, operation);
        }
        catch (Exception) { throw; }
    }

    private async Task<T> ExecuteAsync<T>(ILocator locator, ControlIntent intent, string action, Func<ILocator, Task<T>> operation)
    {
        await WaitForPageReadyBestEffortAsync();
        try
        {
            await PrepareForActionAsync(locator, intent, action);
            var resolved = _runtimeLocatorResolver is null ? locator : await _runtimeLocatorResolver.ResolveAsync(_browser.Page, locator, intent, action) ?? locator;
            if (!ReferenceEquals(resolved, locator)) await PrepareForActionAsync(resolved, intent, action);
            using var frameScope = FrameExecutionContext.Push(null);
            return await ExecuteWithHighlightAsync(resolved, action, operation);
        }
        catch (Exception) { throw; }
    }

    private async Task ExecuteWithHighlightAsync(ILocator locator, string action, Func<ILocator, Task> operation)
    {
        if (ShouldHighlight(action))
            await InteractionHighlighter.PulseAsync(locator, _config.Browser.HighlightDurationMs);
        await operation(locator);
    }

    private async Task<T> ExecuteWithHighlightAsync<T>(ILocator locator, string action, Func<ILocator, Task<T>> operation)
    {
        if (ShouldHighlight(action))
            await InteractionHighlighter.PulseAsync(locator, _config.Browser.HighlightDurationMs);
        return await operation(locator);
    }

    private bool ShouldHighlight(string action) =>
        _config.Browser.HighlightInteractions && action is "click" or "double-click" or "fill" or "set" or "select" or "press" or "press-sequentially" or "activate-tab" or "dialog-action" or "expansion-panel" or "grid-cell";

    private async Task PrepareForActionAsync(ILocator locator, ControlIntent intent, string action)
    {
        if (action is "wait-absent") return;
        // Best-effort readiness only. A timeout is diagnostic; the actual Playwright action decides the result.
        var timeout = action.StartsWith("verify", StringComparison.OrdinalIgnoreCase)
            ? _config.Waits.VerifyTimeoutMs
            : _config.Waits.ElementReadyTimeoutMs;
        try
        {
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeout });
        }
        catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
        {
            _logger.Warn($"CONTROL READY WAIT CONTINUING: {intent}; Action={action}; visible wait did not settle within {timeout}ms: {ex.Message}");
        }
    }

    private async Task WaitForPageReadyBestEffortAsync()
    {
        if (!_config.Waits.WaitForDomContentLoadedBeforeActions || !_browser.IsStarted) return;
        try
        {
            await _browser.Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded, new PageWaitForLoadStateOptions
            {
                Timeout = _config.Waits.PageReadyTimeoutMs
            });
        }
        catch (Exception ex) when (ex is TimeoutException or PlaywrightException)
        {
            // SPA applications can keep navigation/network activity alive. DOMContentLoaded is a readiness
            // hint, not a business assertion; the element-level wait below remains authoritative.
            _logger.Warn($"PAGE READY WAIT CONTINUING: DOMContentLoaded did not settle within {_config.Waits.PageReadyTimeoutMs}ms: {ex.Message}");
        }
    }

    private bool ShouldDeferVerification(Exception ex)
    {
        if (!_config.Execution.DeferVerificationFailures || _verificationFailures is null) return false;
        if (ex.Message.Contains("target closed", StringComparison.OrdinalIgnoreCase) ||
            ex.Message.Contains("browser has been closed", StringComparison.OrdinalIgnoreCase) ||
            ex.Message.Contains("context closed", StringComparison.OrdinalIgnoreCase) ||
            ex.Message.Contains("page closed", StringComparison.OrdinalIgnoreCase)) return false;
        return ex is PlaywrightException or TimeoutException or InvalidOperationException;
    }

    private static string Safe(string value) => string.Concat((value ?? string.Empty).Select(c => char.IsLetterOrDigit(c) ? c : '_')).Trim('_');

    private static bool IsLocatorFailure(Exception ex)
    {
        if (ex is not PlaywrightException and not TimeoutException) return false;
        var message = ex.Message.ToLowerInvariant();
        if (message.Contains("target closed") || message.Contains("browser has been closed") || message.Contains("page closed") || message.Contains("context closed")) return false;
        return ex is TimeoutException || message.Contains("timeout") || message.Contains("locator") || message.Contains("strict mode") || message.Contains("not visible") || message.Contains("not enabled") || message.Contains("not editable") || message.Contains("not attached") || message.Contains("component collision");
    }

    private static bool ParseBoolean(string value, bool defaultValue = false)
    {
        if (string.IsNullOrWhiteSpace(value)) return defaultValue;
        if (value.Equals("true", StringComparison.OrdinalIgnoreCase) || value.Equals("yes", StringComparison.OrdinalIgnoreCase) || value.Equals("checked", StringComparison.OrdinalIgnoreCase) || value == "1") return true;
        if (value.Equals("false", StringComparison.OrdinalIgnoreCase) || value.Equals("no", StringComparison.OrdinalIgnoreCase) || value.Equals("unchecked", StringComparison.OrdinalIgnoreCase) || value == "0") return false;
        return defaultValue;
    }

    private static string IntentKey(ControlIntent intent) => $"{intent.Page}|{intent.Control}";

    private static string NormalizeKey(string key) => key
        .Replace("POST:", "", StringComparison.OrdinalIgnoreCase)
        .Replace("PRE:", "", StringComparison.OrdinalIgnoreCase)
        .Replace("{TAB}", "Tab", StringComparison.OrdinalIgnoreCase)
        .Replace("{ENTER}", "Enter", StringComparison.OrdinalIgnoreCase)
        .Replace("{ESC}", "Escape", StringComparison.OrdinalIgnoreCase);

    private enum ComponentKind
    {
        Generic,
        NativeSelect,
        MaterialSelect,
        Autocomplete,
        RadioGroup,
        ChipGroup,
        Checkbox,
        DatePicker,
        TableGrid,
        Dialog,
        Tabs,
        ExpansionPanel
    }
}
