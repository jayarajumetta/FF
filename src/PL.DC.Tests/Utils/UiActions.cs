using Microsoft.Playwright;

namespace InsuranceAutomation.Utils;

public static class UiActions
{
    public static async Task ApplyInputAsync(IPage page, ILocator locator, string value, float delayMs = 35)
    {
        value ??= string.Empty;
        await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible });

        var info = await locator.EvaluateAsync<ElementInfo>(@"el => ({
            tag: (el.tagName || '').toLowerCase(),
            role: (el.getAttribute('role') || '').toLowerCase(),
            cls: (el.getAttribute('class') || '').toLowerCase(),
            type: (el.getAttribute('type') || '').toLowerCase(),
            editable: !!el.isContentEditable
        })");

        var tag = info?.tag ?? string.Empty;
        var role = info?.role ?? string.Empty;
        var cls = info?.cls ?? string.Empty;
        var type = info?.type ?? string.Empty;
        var token = value.Trim();

        var clickLike = tag == "button"
            || role is "button" or "checkbox" or "radio"
            || type is "button" or "checkbox" or "radio"
            || cls.Contains("chip-wrapper")
            || cls.Contains("mat-chip");

        if (clickLike && token.Equals("X", StringComparison.OrdinalIgnoreCase))
        {
            await locator.ClickAsync();
            return;
        }

        var selectLike = tag == "select"
            || role == "combobox"
            || cls.Contains("mat-select")
            || cls.Contains("mat-mdc-select");

        if (selectLike)
        {
            await SelectFromOverlayAsync(page, locator, value);
            return;
        }

        if (tag is "input" or "textarea" || info?.editable == true)
        {
            await locator.ClickAsync();
            if (tag is "input" or "textarea")
            {
                await locator.PressAsync("ControlOrMeta+A");
                await locator.PressAsync("Backspace");
            }
            if (!string.IsNullOrEmpty(value))
                await locator.PressSequentiallyAsync(value, new() { Delay = delayMs });
            return;
        }

        if (token.Equals("X", StringComparison.OrdinalIgnoreCase) || token.Equals("CLICK", StringComparison.OrdinalIgnoreCase))
        {
            await locator.ClickAsync();
            return;
        }

        // Last resort for editable-looking custom controls.
        await locator.ClickAsync();
        if (!string.IsNullOrEmpty(value))
            await locator.PressSequentiallyAsync(value, new() { Delay = delayMs });
    }

    public static async Task SelectFromOverlayAsync(IPage page, ILocator trigger, string value)
    {
        value = value?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("A select/combobox value is required.", nameof(value));

        var tag = await trigger.EvaluateAsync<string>("el => (el.tagName || '').toLowerCase()");
        if (tag == "select")
        {
            await trigger.SelectOptionAsync(new SelectOptionValue { Label = value });
            return;
        }

        await trigger.ClickAsync();
        var option = page.GetByRole(AriaRole.Option, new() { Name = value, Exact = true });
        if (await option.CountAsync() == 0)
            option = page.Locator("mat-option").Filter(new() { HasText = value });
        await option.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });
        await option.First.ClickAsync();
    }

    private sealed class ElementInfo
    {
        public string tag { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public string cls { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public bool editable { get; set; }
    }
}
