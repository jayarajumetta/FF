using System.Text.RegularExpressions;
using Microsoft.Playwright;
using ToscaModernized.Core.Data;
using ToscaModernized.Core.Locators;
using ToscaModernized.Core.Models;
using ToscaModernized.Core.Runtime;

namespace ToscaModernized.Core.Execution;

public sealed class PlaywrightUiActions
{
    private readonly BrowserSession _browser;
    private readonly LocatorResolver _locators;

    public PlaywrightUiActions(BrowserSession browser, LocatorResolver locators)
    {
        _browser = browser;
        _locators = locators;
    }

    public async Task NavigateAsync(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("Navigation URL is blank.", nameof(url));
        await _browser.Page.GotoAsync(url, new() { WaitUntil = WaitUntilState.DOMContentLoaded }).ConfigureAwait(false);
    }

    public async Task LoginAsync(PlanInstruction instruction, ExpressionResolver resolver)
    {
        var values = Regex.Matches(instruction.GherkinText, "\\\"((?:\\\\.|[^\\\"\\\\])*)\\\"")
            .Select(m => m.Groups[1].Value).ToArray();
        if (values.Length < 2) throw new InvalidOperationException($"Login instruction '{instruction.Id}' does not expose username/password values.");
        var username = resolver.Resolve(values[0]);
        var password = resolver.Resolve(values[1]);
        await FillAsync("Username", username, instruction.SourceModule).ConfigureAwait(false);
        await FillAsync("Password", password, instruction.SourceModule).ConfigureAwait(false);
        try { await ClickAsync("Sign On", instruction.SourceModule).ConfigureAwait(false); }
        catch (InvalidOperationException) { await ClickAsync("Login", instruction.SourceModule).ConfigureAwait(false); }
    }

    public async Task ClickAsync(string target, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        await locator.ClickAsync().ConfigureAwait(false);
    }

    public async Task FillAsync(string target, string value, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        await locator.FillAsync(value).ConfigureAwait(false);
    }

    public async Task SelectAsync(string target, string value, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(value))
        {
            try
            {
                await locator.SelectOptionAsync(new[] { new SelectOptionValue { Label = value } }).ConfigureAwait(false);
                return;
            }
            catch (PlaywrightException)
            {
                // Chip/radio controls are selected by clicking a value-specific child or the control itself.
            }
        }
        await locator.ClickAsync().ConfigureAwait(false);
    }

    public async Task PressAsync(string target, string text, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        var key = text.Contains("SHIFT+TAB", StringComparison.OrdinalIgnoreCase) ? "Shift+Tab"
            : text.Contains("TAB", StringComparison.OrdinalIgnoreCase) ? "Tab"
            : text.Contains("ESC", StringComparison.OrdinalIgnoreCase) ? "Escape"
            : "Enter";
        await locator.PressAsync(key).ConfigureAwait(false);
    }

    public async Task VerifyExistsAsync(string target, string sourceText, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        var count = await locator.CountAsync().ConfigureAwait(false);
        var expectsMissing = sourceText.Contains("does not exist", StringComparison.OrdinalIgnoreCase) ||
                             sourceText.Contains("should not exist", StringComparison.OrdinalIgnoreCase);
        if (expectsMissing ? count != 0 : count == 0)
        {
            throw new InvalidOperationException($"Existence verification failed for '{target}'. Count={count}, expectsMissing={expectsMissing}.");
        }
    }

    public async Task VerifyVisibleAsync(string target, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        if (!await locator.IsVisibleAsync().ConfigureAwait(false))
        {
            throw new InvalidOperationException($"Expected '{target}' to be visible.");
        }
    }

    public async Task VerifyTextAsync(string target, string expected, string? moduleHint = null)
    {
        var actual = await ReadAsync(target, moduleHint).ConfigureAwait(false);
        if (!string.IsNullOrWhiteSpace(expected) && !actual.Contains(expected, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Text verification failed for '{target}'. Expected '{expected}', actual '{actual}'.");
        }
    }

    public async Task<string> ReadAsync(string target, string? moduleHint = null)
    {
        var locator = await _locators.ResolveAsync(target, moduleHint).ConfigureAwait(false);
        return (await locator.InputValueAsync().ConfigureAwait(false)) is { Length: > 0 } input
            ? input
            : await locator.InnerTextAsync().ConfigureAwait(false);
    }

    public async Task WaitAsync(PlanInstruction instruction, string value)
    {
        if (int.TryParse(Regex.Match(value, "\\d+").Value, out var milliseconds) && milliseconds > 0)
        {
            await Task.Delay(Math.Min(milliseconds, 120_000)).ConfigureAwait(false);
            return;
        }
        if (!string.IsNullOrWhiteSpace(instruction.Target))
        {
            var locator = await _locators.ResolveAsync(instruction.Target, instruction.SourceModule).ConfigureAwait(false);
            var state = instruction.GherkinText.Contains("does not exist", StringComparison.OrdinalIgnoreCase)
                ? WaitForSelectorState.Detached
                : WaitForSelectorState.Visible;
            await locator.WaitForAsync(new() { State = state }).ConfigureAwait(false);
        }
    }

    public async Task EnterTableAsync(IReadOnlyList<IReadOnlyList<string>> table)
    {
        if (table.Count < 2) throw new InvalidDataException("The account-address table has no data rows.");
        for (var row = 1; row < table.Count; row++)
        {
            if (table[row].Count < 2) continue;
            var field = table[row][0];
            var value = table[row][1];
            if (string.IsNullOrWhiteSpace(value)) continue;
            await FillAsync(field, value).ConfigureAwait(false);
        }
    }

    public async Task ExecuteNaturalLanguageAsync(PlanInstruction instruction, string value)
    {
        var text = instruction.GherkinText;
        if (text.Contains("click", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(instruction.Target))
        {
            await ClickAsync(instruction.Target, instruction.SourceModule).ConfigureAwait(false);
        }
        else if (text.Contains("enter", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(instruction.Target))
        {
            await FillAsync(instruction.Target, value, instruction.SourceModule).ConfigureAwait(false);
        }
        else if (!string.IsNullOrWhiteSpace(instruction.Target))
        {
            await VerifyExistsAsync(instruction.Target, text, instruction.SourceModule).ConfigureAwait(false);
        }
        else
        {
            await _browser.Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded).ConfigureAwait(false);
        }
    }
}
