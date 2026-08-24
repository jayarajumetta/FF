using Microsoft.Playwright;

namespace InsuranceAutomation.Core;

public enum LocatorPick { Unique, First, Last, Nth }

public sealed record LocatorSpec(
    string Strategy,
    string Value,
    string? Role = null,
    string? AnchorStrategy = null,
    string? AnchorValue = null,
    LocatorPick Pick = LocatorPick.Unique,
    int Index = 0,
    bool Exact = true,
    string? SourceModule = null,
    string? SourceField = null,
    string? HasText = null);

public static class LocatorResolution
{
    public static ILocator Build(IPage page, LocatorSpec spec)
    {
        var locator = string.IsNullOrWhiteSpace(spec.AnchorStrategy)
            ? Raw(page, spec.Strategy, spec.Value, spec.Role, spec.Exact)
            : Raw(Raw(page, spec.AnchorStrategy!, spec.AnchorValue ?? string.Empty, null, true), spec.Strategy, spec.Value, spec.Role, spec.Exact);

        if (!string.IsNullOrWhiteSpace(spec.HasText))
            locator = locator.Filter(new LocatorFilterOptions { HasText = spec.HasText });

        return spec.Pick switch
        {
            LocatorPick.First => locator.First,
            LocatorPick.Last => locator.Last,
            LocatorPick.Nth => locator.Nth(spec.Index),
            _ => locator
        };
    }

    private static ILocator Raw(IPage p, string strategy, string value, string? role, bool exact) => strategy.ToLowerInvariant() switch
    {
        "testid" => p.GetByTestId(value),
        "id" => p.Locator($"[id=\"{Esc(value)}\"]"),
        "name" => p.Locator($"[name=\"{Esc(value)}\"]"),
        "duckcreekid" => p.Locator($"[duckcreekid=\"{Esc(value)}\"], [data-duckcreekid=\"{Esc(value)}\"]"),
        "label" => p.GetByLabel(value, new() { Exact = exact }),
        "placeholder" => p.GetByPlaceholder(value, new() { Exact = exact }),
        "text" => p.GetByText(value, new() { Exact = exact }),
        "title" => p.GetByTitle(value, new() { Exact = exact }),
        "role" => p.GetByRole(Role(role), new() { Name = value, Exact = exact }),
        "xpath" => p.Locator("xpath=" + NormalizeXPath(value)),
        "css" => p.Locator(value),
        _ => p.Locator(value)
    };

    private static ILocator Raw(ILocator p, string strategy, string value, string? role, bool exact) => strategy.ToLowerInvariant() switch
    {
        "testid" => p.GetByTestId(value),
        "id" => p.Locator($"[id=\"{Esc(value)}\"]"),
        "name" => p.Locator($"[name=\"{Esc(value)}\"]"),
        "duckcreekid" => p.Locator($"[duckcreekid=\"{Esc(value)}\"], [data-duckcreekid=\"{Esc(value)}\"]"),
        "label" => p.GetByLabel(value, new() { Exact = exact }),
        "placeholder" => p.GetByPlaceholder(value, new() { Exact = exact }),
        "text" => p.GetByText(value, new() { Exact = exact }),
        "title" => p.GetByTitle(value, new() { Exact = exact }),
        "role" => p.GetByRole(Role(role), new() { Name = value, Exact = exact }),
        "xpath" => p.Locator("xpath=" + NormalizeXPath(value)),
        "css" => p.Locator(value),
        _ => p.Locator(value)
    };

    private static AriaRole Role(string? role) => (role ?? "").ToLowerInvariant() switch
    {
        "button" => AriaRole.Button,
        "textbox" => AriaRole.Textbox,
        "checkbox" => AriaRole.Checkbox,
        "radio" => AriaRole.Radio,
        "combobox" => AriaRole.Combobox,
        "link" => AriaRole.Link,
        "heading" => AriaRole.Heading,
        "option" => AriaRole.Option,
        "tab" => AriaRole.Tab,
        "menuitem" => AriaRole.Menuitem,
        "switch" => AriaRole.Switch,
        _ => AriaRole.Generic
    };

    private static string NormalizeXPath(string value)
    {
        var v = (value ?? "").Trim();
        if (v.Length >= 2 && v[0] == '"' && v[^1] == '"') v = v[1..^1];
        return v;
    }

    private static string Esc(string value) => value.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
