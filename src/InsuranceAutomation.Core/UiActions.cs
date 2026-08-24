using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class UiActions
{
    private readonly LlmLocatorHealer _healer;
    private readonly DeterministicLocatorFallbackResolver _fallback;
    private readonly RunLogger _logger;
    private readonly BrowserSession _browser;

    public UiActions(BrowserSession browser, FrameworkConfig config, RunLogger logger)
        : this(browser, config, logger, null, "Unknown") { }

    public UiActions(BrowserSession browser, FrameworkConfig config, RunLogger logger, ScenarioReport? report, string applicationName)
    {
        _browser = browser;
        _logger = logger;
        _fallback = new DeterministicLocatorFallbackResolver(browser, config, logger, report, applicationName);
        _healer = new LlmLocatorHealer(browser, config, logger, applicationName);
    }

    public Task ClickAsync(ILocator locator) => ClickAsync(locator, new ControlIntent("Application", "Control"));
    public Task FillAsync(ILocator locator, string value) => FillAsync(locator, value, new ControlIntent("Application", "Control"));
    public Task ClickAsync(ILocator locator, ControlIntent intent) => ExecuteAsync(locator, intent, "click", x => ClickSemanticAsync(x));
    public Task FillAsync(ILocator locator, string value, ControlIntent intent) => ExecuteAsync(locator, intent, "fill", x => x.FillAsync(value ?? string.Empty));
    public Task PressAsync(ILocator locator, string key, ControlIntent intent) => ExecuteAsync(locator, intent, "press", x => x.PressAsync(NormalizeKey(key)));

    /// <summary>
    /// Component-aware Tosca Set semantics. Native select, Angular Material/MDC,
    /// autocomplete, radio/chip groups, checkbox and date controls are handled
    /// before the generic editable-control fallback.
    /// </summary>
    public Task SmartSetAsync(ILocator locator, string value, ControlIntent intent) => ExecuteAsync(locator, intent, "set", async x =>
    {
        var component = await DetectComponentAsync(x);
        switch (component)
        {
            case ComponentKind.NativeSelect:
                await x.SelectOptionAsync(new SelectOptionValue { Label = value });
                return;
            case ComponentKind.MaterialSelect:
                await SelectMaterialOptionAsync(x, value, intent);
                return;
            case ComponentKind.Autocomplete:
                await SetAutocompleteAsync(x, value, intent);
                return;
            case ComponentKind.RadioGroup:
            case ComponentKind.ChipGroup:
                await SelectRadioOrChipAsync(x, value, intent);
                return;
            case ComponentKind.Checkbox:
                await SetCheckboxAsync(x, ParseBoolean(value));
                return;
            case ComponentKind.DatePicker:
                await SetDateAsync(x, value);
                return;
        }

        var tag = (await x.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        var type = (await x.GetAttributeAsync("type") ?? "").ToLowerInvariant();
        var role = (await x.GetAttributeAsync("role") ?? "").ToLowerInvariant();
        if (type == "radio")
        {
            await x.SetCheckedAsync(ParseBoolean(value, defaultValue: true));
            return;
        }

        var editable = tag is "input" or "textarea" || role == "textbox" ||
                       string.Equals(await x.GetAttributeAsync("contenteditable"), "true", StringComparison.OrdinalIgnoreCase);
        if (editable)
        {
            await x.FillAsync(value ?? string.Empty);
            return;
        }

        if (tag is "button" or "a" or "div" or "span" || role is "button" or "radio" or "option")
        {
            await SelectResolvedClickableAsync(x, value, intent);
            return;
        }

        throw new PlaywrightException($"Semantic set mismatch for {intent.Page}.{intent.Control}: tag={tag}, type={type}, role={role}. A non-editable control will not be filled.");
    });

    /// <summary>
    /// Source/component-aware Select semantics.
    /// SelectOptionAsync is intentionally reserved for a real HTML &lt;select&gt;.
    /// Angular Material uses trigger-click + role=option/mat-option. Already-resolved
    /// chips, Yes/No containers, buttons and links are clicked directly rather than
    /// being misclassified as dropdowns.
    /// </summary>
    public Task SelectAsync(ILocator locator, string value, ControlIntent intent) => ExecuteAsync(locator, intent, "select", async x =>
    {
        var component = await DetectComponentAsync(x);
        switch (component)
        {
            case ComponentKind.NativeSelect:
                await x.SelectOptionAsync(new SelectOptionValue { Label = value });
                return;
            case ComponentKind.MaterialSelect:
                await SelectMaterialOptionAsync(x, value, intent);
                return;
            case ComponentKind.Autocomplete:
                await SetAutocompleteAsync(x, value, intent);
                return;
            case ComponentKind.RadioGroup:
            case ComponentKind.ChipGroup:
                await SelectRadioOrChipAsync(x, value, intent);
                return;
            case ComponentKind.Checkbox:
                await SetCheckboxAsync(x, ParseBoolean(value, defaultValue: true));
                return;
            case ComponentKind.DatePicker:
                await SetDateAsync(x, value);
                return;
            default:
                await SelectResolvedClickableAsync(x, value, intent);
                return;
        }
    });

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

    private async Task SelectMaterialOptionAsync(ILocator trigger, string value, ControlIntent intent)
    {
        await trigger.ClickAsync();
        var page = _browser.Page;
        var option = page.GetByRole(AriaRole.Option, new() { Name = value, Exact = true });
        if (await option.CountAsync() == 0) option = page.Locator("mat-option").Filter(new() { HasText = value });
        if (await option.CountAsync() == 0) option = page.Locator("[role=option]").Filter(new() { HasText = value });
        await ClickSingleVisibleAsync(option, $"dropdown option '{value}'", intent);
    }

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

    private async Task SetAutocompleteAsync(ILocator control, string value, ControlIntent intent)
    {
        var tag = (await control.EvaluateAsync<string>("e=>e.tagName.toLowerCase()")).ToLowerInvariant();
        var input = tag == "input" || tag == "textarea" ? control : control.Locator("input,textarea").First;
        await input.FillAsync(value ?? string.Empty);
        var page = _browser.Page;
        var option = page.GetByRole(AriaRole.Option, new() { Name = value, Exact = true });
        if (await option.CountAsync() == 0) option = page.Locator("mat-option,[role=option]").Filter(new() { HasText = value });
        await ClickSingleVisibleAsync(option, $"autocomplete option '{value}'", intent);
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
        if (await option.CountAsync() == 0) option = control.Locator("mat-radio-button,mat-chip-option,mat-chip,[role=radio],[role=option]").Filter(new() { HasText = value });
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

    public Task WaitAsync(ILocator locator, string expected, ControlIntent intent) =>
        expected.Contains("Absent", StringComparison.OrdinalIgnoreCase)
            ? locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Detached })
            : ExecuteAsync(locator, intent, "wait-visible", x => x.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible }));

    public async Task VerifyAsync(ILocator locator, string expected, string property, ControlIntent intent)
    {
        if (expected.Equals("Visible", StringComparison.OrdinalIgnoreCase) || expected.Equals("Exists", StringComparison.OrdinalIgnoreCase) || expected.Equals("True", StringComparison.OrdinalIgnoreCase))
        {
            await ExecuteAsync(locator, intent, "verify-visible", async x =>
            {
                if (await x.CountAsync() == 0) throw new TimeoutException("Expected control to exist.");
                await x.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            });
            return;
        }
        var actual = await CaptureAsync(locator, property, intent);
        if (!string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException($"Expected '{expected}' but found '{actual}'.");
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
        try { await operation(locator); }
        catch (Exception ex) when (IsLocatorFailure(ex))
        {
            // Deterministic Tosca candidates are the first recovery layer. They execute ONLY the
            // failed Page action; a successful fallback never replays the business step/scenario.
            if (await _fallback.TryExecuteAsync(intent, action, operation, ex)) return;

            // LLM/Copilot healing is deliberately last, after every mature source-derived fallback
            // candidate has been live-validated and exhausted.
            var healed = await _healer.TryHealAsync(locator, intent, action, ex);
            if (healed is null) throw;
            await operation(healed);
        }
        // Intentionally no post-action DOM extraction/consolidation.
        // Failure-time DOM + screenshot evidence remains available to the final healing layer.
    }

    private async Task<T> ExecuteAsync<T>(ILocator locator, ControlIntent intent, string action, Func<ILocator, Task<T>> operation)
    {
        try { return await operation(locator); }
        catch (Exception ex) when (IsLocatorFailure(ex))
        {
            var fallback = await _fallback.TryExecuteAsync(intent, action, operation, ex);
            if (fallback.Success) return fallback.Value!;

            var healed = await _healer.TryHealAsync(locator, intent, action, ex);
            if (healed is null) throw;
            return await operation(healed);
        }
        // Intentionally no post-action DOM extraction/consolidation.
        // Failure-time DOM + screenshot evidence remains available to the final healing layer.
    }

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
