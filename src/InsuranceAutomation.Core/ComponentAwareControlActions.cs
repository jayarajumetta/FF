using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

/// <summary>v55 component-aware action kernel derived from raw Tosca ModuleAttribute semantics.</summary>
public static class ComponentAwareControlActions
{
    public static async Task SelectOrFillAsync(IPage page, ILocator control, string value, int timeoutMs = 15000)
    {
        ArgumentNullException.ThrowIfNull(page);
        ArgumentNullException.ThrowIfNull(control);
        value ??= string.Empty;
        await control.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });
        var meta = await control.EvaluateAsync<ControlMeta>(@"el => ({
            tag: (el.tagName || '').toLowerCase(),
            type: (el.getAttribute('type') || '').toLowerCase(),
            role: (el.getAttribute('role') || '').toLowerCase(),
            popup: (el.getAttribute('aria-haspopup') || '').toLowerCase(),
            cls: typeof el.className === 'string' ? el.className.toLowerCase() : '',
            fieldref: el.getAttribute('fieldref') || el.getAttribute('data-fieldref') || '',
            readOnly: !!el.readOnly
        })");

        if (meta?.Tag == "select")
        {
            try { await control.SelectOptionAsync(new SelectOptionValue { Label = value }, new() { Timeout = timeoutMs }); }
            catch { await control.SelectOptionAsync(new SelectOptionValue { Value = value }, new() { Timeout = timeoutMs }); }
            return;
        }

        var componentLike = meta is not null && (
            meta.Role is "combobox" or "listbox" || meta.Popup is "listbox" or "menu" ||
            meta.Cls.Contains("mat-select") || meta.Cls.Contains("mdc-select") ||
            meta.Cls.Contains("x-form-trigger") || meta.Cls.Contains("x-combo") ||
            meta.Cls.Contains("autocomplete") || (meta.Tag == "input" && meta.ReadOnly && !string.IsNullOrWhiteSpace(meta.Fieldref)));

        if (componentLike)
        {
            await control.ClickAsync(new() { Timeout = timeoutMs });
            if (await TryClickExactOptionAsync(page, value, timeoutMs)) return;
            if (meta?.Tag == "input" && !meta.ReadOnly)
            {
                await control.FillAsync(value, new() { Timeout = timeoutMs });
                if (await TryClickExactOptionAsync(page, value, timeoutMs)) return;
            }
            throw new PlaywrightException($"No exact rendered option '{value}' was found for the dropdown/autocomplete control.");
        }

        if (meta?.Type is "checkbox" or "radio")
        {
            var desired = ParseBoolean(value);
            if (meta.Type == "checkbox") await control.SetCheckedAsync(desired, new() { Timeout = timeoutMs });
            else if (desired) await control.CheckAsync(new() { Timeout = timeoutMs });
            return;
        }

        await control.FillAsync(value, new() { Timeout = timeoutMs });
        await control.EvaluateAsync("el => el.blur()");
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
        await control.EvaluateAsync("el => ((HTMLElement)el).click()");
    }

    private static async Task<bool> TryClickExactOptionAsync(IPage page, string value, int timeoutMs)
    {
        var frame = FrameExecutionContext.Current;
        var candidates = frame is null
            ? page.Locator("[role=option],mat-option,.mat-mdc-option,.x-boundlist-item,li[role=option],.dropdown-item:not(.disabled)")
            : frame.Locator("[role=option],mat-option,.mat-mdc-option,.x-boundlist-item,li[role=option],.dropdown-item:not(.disabled)");
        var count = await candidates.CountAsync();
        var expected = Normalize(value);
        for (var i = 0; i < count; i++)
        {
            var candidate = candidates.Nth(i);
            if (!await candidate.IsVisibleAsync()) continue;
            var text = Normalize(await candidate.InnerTextAsync());
            if (!string.Equals(text, expected, StringComparison.OrdinalIgnoreCase)) continue;
            await candidate.ClickAsync(new() { Timeout = timeoutMs });
            return true;
        }
        return false;
    }

    private static string Normalize(string? value) => Regex.Replace(value ?? string.Empty, @"\s+", " ").Trim();
    private static bool ParseBoolean(string value) => value.Trim().Equals("true", StringComparison.OrdinalIgnoreCase) || value.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase) || value.Trim() == "1";
    private sealed class ControlMeta
    {
        public string Tag { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Popup { get; set; } = string.Empty;
        public string Cls { get; set; } = string.Empty;
        public string Fieldref { get; set; } = string.Empty;
        public bool ReadOnly { get; set; }
    }
}
