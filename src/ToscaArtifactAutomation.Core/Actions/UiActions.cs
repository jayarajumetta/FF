using Microsoft.Playwright;
using Serilog;
using ToscaArtifactAutomation.Core.Browser;
using ToscaArtifactAutomation.Core.Locators;

namespace ToscaArtifactAutomation.Core.Actions;

public sealed class UiActions
{
    private readonly BrowserSession _browser;
    private readonly LocatorResolver _resolver;

    public UiActions(BrowserSession browser, LocatorResolver resolver)
    {
        _browser = browser ?? throw new ArgumentNullException(nameof(browser));
        _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
    }

    public async Task SmartSetAsync(string target, string value, string module, IReadOnlyList<string> commands)
    {
        var locator = await _resolver.ResolveAsync(target, module);
        await ApplyCommandsAsync(locator, commands.Where(x => x.StartsWith("PRE:", StringComparison.OrdinalIgnoreCase)).ToArray());
        var tag = (await locator.EvaluateAsync<string>("element => element.tagName.toLowerCase()")) ?? string.Empty;
        var type = (await locator.GetAttributeAsync("type"))?.ToLowerInvariant() ?? string.Empty;
        var role = (await locator.GetAttributeAsync("role"))?.ToLowerInvariant() ?? string.Empty;
        if (tag == "select")
        {
            await SelectOptionAsync(locator, value);
        }
        else if (type is "checkbox" or "radio")
        {
            if (string.Equals(value, "false", StringComparison.OrdinalIgnoreCase)) await locator.UncheckAsync();
            else await locator.CheckAsync();
        }
        else if (tag is "button" or "a" || role is "button" or "link" || string.Equals(value, "X", StringComparison.OrdinalIgnoreCase))
        {
            await locator.ClickAsync();
        }
        else
        {
            await locator.FillAsync(value ?? string.Empty);
        }
        await ApplyCommandsAsync(locator, commands.Where(x => !x.StartsWith("PRE:", StringComparison.OrdinalIgnoreCase)).ToArray());
    }

    public async Task ClickAsync(string target, string module, IReadOnlyList<string> commands)
    {
        var locator = await _resolver.ResolveAsync(target, module);
        if (commands.Any(x => x.Equals("DBLCLICK", StringComparison.OrdinalIgnoreCase) || x.Equals("DOUBLECLICK", StringComparison.OrdinalIgnoreCase)))
            await locator.DblClickAsync();
        else if (commands.Any(x => x.Equals("RIGHTCLICK", StringComparison.OrdinalIgnoreCase)))
            await locator.ClickAsync(new LocatorClickOptions { Button = MouseButton.Right });
        else if (commands.Any(x => x.Equals("LONGCLICK", StringComparison.OrdinalIgnoreCase)))
            await locator.ClickAsync(new LocatorClickOptions { Delay = 1000 });
        else
            await locator.ClickAsync();
        await ApplyCommandsAsync(locator, commands.Where(x => !x.Contains("CLICK", StringComparison.OrdinalIgnoreCase)).ToArray());
    }

    public async Task SelectAsync(string target, string value, string module, IReadOnlyList<string> commands)
    {
        var locator = await _resolver.ResolveAsync(target, module);
        var tag = (await locator.EvaluateAsync<string>("element => element.tagName.toLowerCase()")) ?? string.Empty;
        if (tag == "select")
        {
            await SelectOptionAsync(locator, value);
        }
        else
        {
            await locator.ClickAsync();
            if (!string.IsNullOrWhiteSpace(value))
            {
                var option = _browser.Page.GetByRole(AriaRole.Option, new PageGetByRoleOptions { Name = value, Exact = true }).First;
                if (await option.CountAsync() == 0)
                    option = _browser.Page.GetByText(value, new PageGetByTextOptions { Exact = true }).First;
                await option.ClickAsync();
            }
        }
        await ApplyCommandsAsync(locator, commands);
    }

    public async Task PressAsync(string target, string module, IReadOnlyList<string> commands)
    {
        var locator = string.IsNullOrWhiteSpace(target) ? null : await _resolver.TryResolveAsync(target, module);
        foreach (var command in commands)
            await ApplyCommandAsync(locator, command);
    }

    private static async Task SelectOptionAsync(ILocator locator, string value)
    {
        try { await locator.SelectOptionAsync(new SelectOptionValue { Label = value }); }
        catch (PlaywrightException) { await locator.SelectOptionAsync(new SelectOptionValue { Value = value }); }
    }

    private async Task ApplyCommandsAsync(ILocator locator, IReadOnlyList<string> commands)
    {
        foreach (var command in commands)
            await ApplyCommandAsync(locator, command);
    }

    private async Task ApplyCommandAsync(ILocator? locator, string command)
    {
        command = System.Text.RegularExpressions.Regex.Replace(command.Trim(), "^(?:PRE|POST):", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase).Trim('{', '}');
        if (string.IsNullOrWhiteSpace(command)) return;
        if (command.StartsWith("SCROLL[", StringComparison.OrdinalIgnoreCase))
        {
            var match = System.Text.RegularExpressions.Regex.Match(command, @"-?\d+");
            var amount = match.Success ? int.Parse(match.Value) : 1;
            await _browser.Page.Mouse.WheelAsync(0, amount * 500);
            return;
        }
        if (command.StartsWith("CLICK[", StringComparison.OrdinalIgnoreCase))
        {
            if (locator is not null) await locator.ClickAsync();
            return;
        }
        var key = command.ToUpperInvariant() switch
        {
            "SHIFTTAB" or "SHIFT+TAB" => "Shift+Tab",
            "CTRL+A" => "Control+A",
            "CTRL+DELETE" => "Control+Delete",
            "ESC" or "ESCAPE" => "Escape",
            _ => command
        };
        if (locator is not null) await locator.PressAsync(key);
        else await _browser.Page.Keyboard.PressAsync(key);
    }
}
