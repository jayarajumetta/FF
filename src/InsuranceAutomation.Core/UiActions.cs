using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public sealed class UiActions
{
    private readonly BrowserSession _browser;
    private readonly RunLogger _logger;
    private readonly CopilotLocatorHealer _healer;

    public UiActions(BrowserSession browser, RunLogger logger)
    {
        _browser = browser;
        _logger = logger;
        _healer = new CopilotLocatorHealer(browser, logger);
    }

    public Task ClickAsync(ILocator locator, ControlIntent intent) =>
        ExecuteAsync(locator, intent, "click", item => item.ClickAsync());

    public Task FillAsync(ILocator locator, string value, ControlIntent intent) =>
        ExecuteAsync(locator, intent, "fill", async item =>
        {
            await item.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await item.FillAsync(value ?? string.Empty);
        });

    public Task SmartSetAsync(ILocator locator, string value, ControlIntent intent) =>
        ExecuteAsync(locator, intent, "set", async item =>
        {
            var type = (await item.GetAttributeAsync("type") ?? string.Empty).ToLowerInvariant();
            if (type is "checkbox" or "radio")
            {
                var expected = !value.Equals("false", StringComparison.OrdinalIgnoreCase) &&
                               !value.Equals("no", StringComparison.OrdinalIgnoreCase);
                await item.SetCheckedAsync(expected);
                return;
            }

            var tag = await item.EvaluateAsync<string>("element => element.tagName.toLowerCase()");
            if (tag == "select")
            {
                await item.SelectOptionAsync(new SelectOptionValue { Label = value });
                return;
            }

            await item.FillAsync(value ?? string.Empty);
        });

    public Task SelectAsync(ILocator locator, string value, ControlIntent intent) =>
        ExecuteAsync(locator, intent, "select", async item =>
        {
            try
            {
                await item.SelectOptionAsync(new SelectOptionValue { Label = value });
            }
            catch (PlaywrightException)
            {
                await item.ClickAsync();
                await _browser.Page.GetByRole(AriaRole.Option, new PageGetByRoleOptions
                {
                    Name = value,
                    Exact = true
                }).ClickAsync();
            }
        });

    public Task PressAsync(ILocator locator, string key, ControlIntent intent) =>
        ExecuteAsync(locator, intent, "press", item => item.PressAsync(NormalizeKey(key)));

    public async Task<bool> ExistsAsync(ILocator locator)
    {
        try { return await locator.CountAsync() > 0; }
        catch { return false; }
    }

    public Task WaitAsync(ILocator locator, string expected, ControlIntent intent)
    {
        if (expected.Contains("Absent", StringComparison.OrdinalIgnoreCase) ||
            expected.Contains("not", StringComparison.OrdinalIgnoreCase))
        {
            return locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Detached });
        }

        return ExecuteAsync(locator, intent, "wait-visible",
            item => item.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible }));
    }

    public async Task VerifyAsync(ILocator locator, string expected, string property, ControlIntent intent)
    {
        if (expected.Equals("Visible", StringComparison.OrdinalIgnoreCase) ||
            expected.Equals("Exists", StringComparison.OrdinalIgnoreCase) ||
            expected.Equals("True", StringComparison.OrdinalIgnoreCase))
        {
            await ExecuteAsync(locator, intent, "verify-visible", async item =>
            {
                if (await item.CountAsync() == 0) throw new TimeoutException("Expected control to exist.");
                await item.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            });
            return;
        }

        var actual = await CaptureAsync(locator, property, intent);
        if (!string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Expected '{expected}' but found '{actual}'.");
        }
    }

    public Task<string> CaptureAsync(ILocator locator, string property, ControlIntent intent) =>
        ExecuteAsync(locator, intent, "capture", async item =>
        {
            if (property.Contains("Value", StringComparison.OrdinalIgnoreCase))
            {
                try { return await item.InputValueAsync(); } catch { }
            }

            try { return (await item.InnerTextAsync()).Trim(); }
            catch { return (await item.TextContentAsync() ?? string.Empty).Trim(); }
        });

    public Task ReviewRequiredAsync(string reason)
    {
        _logger.Warn($"SOURCE TRACE NOTE: {reason}");
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync(ILocator locator, ControlIntent intent, string action, Func<ILocator, Task> operation)
    {
        try
        {
            await operation(locator);
        }
        catch (Exception exception) when (IsLocatorFailure(exception))
        {
            _logger.Warn($"Locator action failed. Action={action}; Control={intent}; Locator={locator}; Error={exception.Message}");
            var healed = await _healer.TryHealAsync(locator, intent, action, exception);
            if (healed is null) throw;
            await operation(healed);
        }
    }

    private async Task<T> ExecuteAsync<T>(ILocator locator, ControlIntent intent, string action, Func<ILocator, Task<T>> operation)
    {
        try
        {
            return await operation(locator);
        }
        catch (Exception exception) when (IsLocatorFailure(exception))
        {
            _logger.Warn($"Locator action failed. Action={action}; Control={intent}; Locator={locator}; Error={exception.Message}");
            var healed = await _healer.TryHealAsync(locator, intent, action, exception);
            if (healed is null) throw;
            return await operation(healed);
        }
    }

    private static bool IsLocatorFailure(Exception exception)
    {
        if (exception is not PlaywrightException and not TimeoutException) return false;
        var message = exception.Message.ToLowerInvariant();
        if (message.Contains("target closed") || message.Contains("browser has been closed") ||
            message.Contains("page closed") || message.Contains("context closed")) return false;

        return exception is TimeoutException || message.Contains("timeout") || message.Contains("locator") ||
               message.Contains("strict mode") || message.Contains("not visible") ||
               message.Contains("not enabled") || message.Contains("not editable") ||
               message.Contains("not attached");
    }

    private static string NormalizeKey(string key) => key
        .Replace("POST:", string.Empty, StringComparison.OrdinalIgnoreCase)
        .Replace("PRE:", string.Empty, StringComparison.OrdinalIgnoreCase)
        .Replace("{TAB}", "Tab", StringComparison.OrdinalIgnoreCase)
        .Replace("{ENTER}", "Enter", StringComparison.OrdinalIgnoreCase)
        .Replace("{ESC}", "Escape", StringComparison.OrdinalIgnoreCase);
}
