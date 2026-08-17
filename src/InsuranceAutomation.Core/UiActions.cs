using System.Runtime.CompilerServices;
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

    public Task ClickAsync(
        ILocator locator,
        [CallerArgumentExpression(nameof(locator))] string expression = "") =>
        ExecuteAsync(locator, "click", item => item.ClickAsync(), expression);

    public Task FillAsync(
        ILocator locator,
        string value,
        [CallerArgumentExpression(nameof(locator))] string expression = "") =>
        ExecuteAsync(locator, "fill", async item =>
        {
            await item.ClickAsync();
            await item.FillAsync(string.Empty);
            await item.PressSequentiallyAsync(value ?? string.Empty);
        }, expression);

    public Task SmartSetAsync(
        ILocator locator,
        string value,
        [CallerArgumentExpression(nameof(locator))] string expression = "") =>
        ExecuteAsync(locator, "smart-set", async item =>
        {
            var type = await item.GetAttributeAsync("type");
            if (type is "checkbox" or "radio")
            {
                if (value.Equals("false", StringComparison.OrdinalIgnoreCase) ||
                    value.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    await item.UncheckAsync();
                }
                else
                {
                    await item.CheckAsync();
                }
                return;
            }

            var tag = await item.EvaluateAsync<string>("element => element.tagName.toLowerCase()");
            if (tag == "select")
            {
                await item.SelectOptionAsync(new SelectOptionValue { Label = value });
                return;
            }

            await item.ClickAsync();
            await item.FillAsync(string.Empty);
            await item.PressSequentiallyAsync(value ?? string.Empty);
        }, expression);

    public Task SelectAsync(
        ILocator locator,
        string value,
        [CallerArgumentExpression(nameof(locator))] string expression = "") =>
        ExecuteAsync(locator, "select", async item =>
        {
            try
            {
                await item.SelectOptionAsync(new SelectOptionValue { Label = value });
            }
            catch (PlaywrightException)
            {
                await item.ClickAsync();
                await _browser.Page.GetByRole(AriaRole.Option, new PageGetByRoleOptions { Name = value, Exact = true }).ClickAsync();
            }
        }, expression);

    public Task PressAsync(
        ILocator locator,
        string key,
        [CallerArgumentExpression(nameof(locator))] string expression = "") =>
        ExecuteAsync(locator, "press", item => item.PressAsync(NormalizeKey(key)), expression);

    public async Task<bool> ExistsAsync(ILocator locator)
    {
        try
        {
            return await locator.CountAsync() > 0;
        }
        catch
        {
            return false;
        }
    }

    public Task WaitAsync(
        ILocator locator,
        string expected,
        [CallerArgumentExpression(nameof(locator))] string expression = "")
    {
        if (expected.Contains("Absent", StringComparison.OrdinalIgnoreCase) ||
            expected.Contains("not", StringComparison.OrdinalIgnoreCase))
        {
            return locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Detached });
        }

        return ExecuteAsync(locator, "wait-visible", item => item.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible }), expression);
    }

    public async Task VerifyAsync(
        ILocator locator,
        string expected,
        string property,
        [CallerArgumentExpression(nameof(locator))] string expression = "")
    {
        if (expected.Equals("Visible", StringComparison.OrdinalIgnoreCase) ||
            expected.Equals("Exists", StringComparison.OrdinalIgnoreCase) ||
            expected.Equals("True", StringComparison.OrdinalIgnoreCase))
        {
            await ExecuteAsync(locator, "verify-visible", async item =>
            {
                if (await item.CountAsync() == 0)
                {
                    throw new TimeoutException("Expected control to exist.");
                }
                await item.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }, expression);
            return;
        }

        var actual = await CaptureAsync(locator, property, expression);
        if (!string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Expected '{expected}' but found '{actual}'.");
        }
    }

    public Task<string> CaptureAsync(
        ILocator locator,
        string property = "",
        [CallerArgumentExpression(nameof(locator))] string expression = "") =>
        ExecuteAsync(locator, "capture", async item =>
        {
            if (property.Contains("Value", StringComparison.OrdinalIgnoreCase))
            {
                try { return await item.InputValueAsync(); } catch { }
            }

            try { return (await item.InnerTextAsync()).Trim(); }
            catch { return (await item.TextContentAsync() ?? string.Empty).Trim(); }
        }, expression);

    public Task ReviewRequiredAsync(string reason)
    {
        _logger.Warn($"SOURCE TRACE NOTE: {reason}");
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync(ILocator locator, string action, Func<ILocator, Task> operation, string expression)
    {
        try
        {
            await operation(locator);
        }
        catch (Exception exception) when (IsLocatorFailure(exception))
        {
            _logger.Warn($"Locator action failed. Action={action}; Control={expression}; Error={exception.Message}");
            var healed = await _healer.TryHealAsync(expression, action, exception);
            if (healed is null) throw;
            await operation(healed);
        }
    }

    private async Task<T> ExecuteAsync<T>(ILocator locator, string action, Func<ILocator, Task<T>> operation, string expression)
    {
        try
        {
            return await operation(locator);
        }
        catch (Exception exception) when (IsLocatorFailure(exception))
        {
            _logger.Warn($"Locator action failed. Action={action}; Control={expression}; Error={exception.Message}");
            var healed = await _healer.TryHealAsync(expression, action, exception);
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
