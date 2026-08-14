using System.Diagnostics;
using Microsoft.Playwright;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Locators;

namespace ToscaArtifactAutomation.Core.Actions;

public sealed class UiAssertions
{
    private readonly LocatorResolver _resolver;
    private readonly RootSettings _settings;

    public UiAssertions(LocatorResolver resolver, RootSettings settings)
    {
        _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    public async Task WaitAsync(string target, string module, string expected, string property, string expectedValue, int timeoutMs)
    {
        var timeout = timeoutMs > 0 ? timeoutMs : _settings.Framework.DefaultTimeoutMs;
        if (expected.Equals("Absent", StringComparison.OrdinalIgnoreCase))
        {
            await PollAsync(async () => !await _resolver.ExistsAsync(target, module), timeout, $"'{target}' to be absent");
            return;
        }
        var locator = await _resolver.ResolveAsync(target, module, timeout);
        if (expected.Equals("Visible", StringComparison.OrdinalIgnoreCase))
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeout });
        else if (!string.IsNullOrWhiteSpace(property) && !string.IsNullOrWhiteSpace(expectedValue))
            await PollAsync(async () => string.Equals(await ReadPropertyAsync(locator, property), expectedValue, StringComparison.OrdinalIgnoreCase), timeout, $"'{target}' property '{property}' = '{expectedValue}'");
        else
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached, Timeout = timeout });
    }

    public async Task VerifyAsync(string target, string module, string expected, string property)
    {
        if (expected.Equals("Absent", StringComparison.OrdinalIgnoreCase))
        {
            if (await _resolver.ExistsAsync(target, module)) throw new InvalidOperationException($"Expected '{target}' to be absent, but it exists.");
            return;
        }
        var locator = await _resolver.ResolveAsync(target, module);
        if (expected.Equals("Exists", StringComparison.OrdinalIgnoreCase)) return;
        if (expected.Equals("Visible", StringComparison.OrdinalIgnoreCase))
        {
            if (!await locator.IsVisibleAsync()) throw new InvalidOperationException($"Expected '{target}' to be visible.");
            return;
        }
        var comparisonProperty = property ?? string.Empty;
        var notEqual = comparisonProperty.StartsWith("NotEqual:", StringComparison.OrdinalIgnoreCase);
        if (notEqual) comparisonProperty = comparisonProperty[9..];
        var regex = comparisonProperty.StartsWith("Regex:", StringComparison.OrdinalIgnoreCase) || comparisonProperty.Equals("Regex", StringComparison.OrdinalIgnoreCase);
        if (comparisonProperty.StartsWith("Regex:", StringComparison.OrdinalIgnoreCase)) comparisonProperty = comparisonProperty[6..];
        var normalizedExpected = expected.Equals("__BLANK__", StringComparison.Ordinal) ? string.Empty : expected;
        var actual = await ReadPropertyAsync(locator, string.IsNullOrWhiteSpace(comparisonProperty) ? "InnerText" : comparisonProperty);
        var matches = regex
            ? System.Text.RegularExpressions.Regex.IsMatch(actual, normalizedExpected)
            : string.Equals(actual, normalizedExpected, StringComparison.Ordinal);
        if (notEqual) matches = !matches;
        if (!matches)
            throw new InvalidOperationException($"Verification failed for '{target}' property '{property}'. Expected '{normalizedExpected}', actual '{actual}'.");
    }

    public async Task<string> ReadAsync(string target, string module, string property = "")
    {
        var locator = await _resolver.ResolveAsync(target, module);
        return await ReadPropertyAsync(locator, property);
    }

    private static async Task<string> ReadPropertyAsync(ILocator locator, string property)
    {
        property = property?.Trim() ?? string.Empty;
        if (property.Equals("Visible", StringComparison.OrdinalIgnoreCase)) return (await locator.IsVisibleAsync()).ToString();
        if (property.Equals("Enabled", StringComparison.OrdinalIgnoreCase)) return (await locator.IsEnabledAsync()).ToString();
        if (property.Equals("Disabled", StringComparison.OrdinalIgnoreCase)) return (!await locator.IsEnabledAsync()).ToString();
        if (property.Equals("Checked", StringComparison.OrdinalIgnoreCase)) return (await locator.IsCheckedAsync()).ToString();
        if (property.Equals("Selected", StringComparison.OrdinalIgnoreCase)) return (await locator.IsCheckedAsync()).ToString();
        if (property.Equals("ReadOnly", StringComparison.OrdinalIgnoreCase)) return ((await locator.GetAttributeAsync("readonly")) is not null).ToString();
        if (property.Equals("Count", StringComparison.OrdinalIgnoreCase) || property.Equals("Row count", StringComparison.OrdinalIgnoreCase)) return (await locator.CountAsync()).ToString();
        if (property.Equals("Value", StringComparison.OrdinalIgnoreCase))
        {
            try { return await locator.InputValueAsync(); } catch (PlaywrightException) { return await locator.GetAttributeAsync("value") ?? string.Empty; }
        }
        if (property.Equals("InnerText", StringComparison.OrdinalIgnoreCase) || string.IsNullOrWhiteSpace(property))
        {
            try { return (await locator.InnerTextAsync()).Trim(); } catch (PlaywrightException) { }
            try { return await locator.InputValueAsync(); } catch (PlaywrightException) { }
            return (await locator.TextContentAsync())?.Trim() ?? string.Empty;
        }
        return await locator.GetAttributeAsync(property) ?? string.Empty;
    }

    private static async Task PollAsync(Func<Task<bool>> condition, int timeoutMs, string description)
    {
        var timer = Stopwatch.StartNew();
        Exception? last = null;
        while (timer.ElapsedMilliseconds < timeoutMs)
        {
            try { if (await condition()) return; }
            catch (Exception ex) when (ex is PlaywrightException or InvalidOperationException) { last = ex; }
            await Task.Delay(200);
        }
        throw new TimeoutException($"Timed out after {timeoutMs} ms waiting for {description}.", last);
    }
}
