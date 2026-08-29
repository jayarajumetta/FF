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
    string? HasText = null,
    string? FrameStrategy = null,
    string? FrameValue = null);
/// <summary>
/// Locator construction keeps frame metadata as a scope hint; Build(IPage, ...) always targets the
/// top document. The deterministic resolver decides whether to use BuildInFrame after it has briefly proved
/// that the hinted frame is present. This avoids hard-wiring a stale Tosca HtmlFrame classification.
/// </summary>
public static class LocatorResolution
{
    public static ILocator Build(IPage page, LocatorSpec spec)
    {
        var locator = string.IsNullOrWhiteSpace(spec.AnchorStrategy)
            ? Raw(page, spec.Strategy, spec.Value, spec.Role, spec.Exact)
            : Raw(Raw(page, spec.AnchorStrategy!, spec.AnchorValue ?? string.Empty, null, true), spec.Strategy, spec.Value, spec.Role, spec.Exact);
        return Finish(locator, spec);
    }
    public static ILocator BuildInFrame(IPage page, LocatorSpec spec)
    {
        if (string.IsNullOrWhiteSpace(spec.FrameValue))
            throw new InvalidOperationException("Frame-scoped locator requested without raw Tosca frame evidence.");
        var frame = BuildFrame(page, spec.FrameStrategy ?? "css", spec.FrameValue!);
        var locator = string.IsNullOrWhiteSpace(spec.AnchorStrategy)
            ? Raw(frame, spec.Strategy, spec.Value, spec.Role, spec.Exact)
            : Raw(Raw(frame, spec.AnchorStrategy!, spec.AnchorValue ?? string.Empty, null, true), spec.Strategy, spec.Value, spec.Role, spec.Exact);
        return Finish(locator, spec);
    }
    public static IFrameLocator? FrameFor(IPage page, LocatorSpec spec) =>
        string.IsNullOrWhiteSpace(spec.FrameValue) ? null : BuildFrame(page, spec.FrameStrategy ?? "css", spec.FrameValue!);
    public static IFrameLocator BuildFrame(IPage page, string strategy, string value) =>
        page.FrameLocator(FrameSelector(strategy, value));
    public static string FrameSelector(string strategy, string value) => strategy.ToLowerInvariant() switch
    {
        "id" => $"iframe[id=\"{Esc(value)}\"],frame[id=\"{Esc(value)}\"]",
        "name" => $"iframe[name=\"{Esc(value)}\"],frame[name=\"{Esc(value)}\"]",
        "css" => value,
        _ => value
    };
    private static ILocator Finish(ILocator locator, LocatorSpec spec)
    {
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
        "fieldref" => p.Locator($"[fieldref=\"{Esc(value)}\"], [data-fieldref=\"{Esc(value)}\"]"),
        "testid" => p.GetByTestId(value),
        "automationid" => p.Locator($"[automationid=\"{Esc(value)}\"], [data-automation-id=\"{Esc(value)}\"]"),
        "id" => p.Locator($"[id=\"{Esc(value)}\"]"),
        "name" => p.Locator($"[name=\"{Esc(value)}\"]"),
        "duckcreekid" => p.Locator($"[duckcreekid=\"{Esc(value)}\"], [data-duckcreekid=\"{Esc(value)}\"]"),
        "associatedlabel" => p.Locator(AssociatedLabelXPath(value)),
        "label" => p.Locator(AssociatedLabelXPath(value)),
        "placeholder" => p.GetByPlaceholder(value, new() { Exact = exact }),
        "text" => p.GetByText(value, new() { Exact = exact }),
        "title" => p.GetByTitle(value, new() { Exact = exact }),
        "role" => p.GetByRole(Role(role), new() { Name = value, Exact = exact }),
        "xpath" => p.Locator("xpath=" + NormalizeXPath(value)),
        "css" => p.Locator(value),
        _ => p.Locator(value)
    };
    private static ILocator Raw(IFrameLocator p, string strategy, string value, string? role, bool exact) => strategy.ToLowerInvariant() switch
    {
        "fieldref" => p.Locator($"[fieldref=\"{Esc(value)}\"], [data-fieldref=\"{Esc(value)}\"]"),
        "testid" => p.GetByTestId(value),
        "automationid" => p.Locator($"[automationid=\"{Esc(value)}\"], [data-automation-id=\"{Esc(value)}\"]"),
        "id" => p.Locator($"[id=\"{Esc(value)}\"]"),
        "name" => p.Locator($"[name=\"{Esc(value)}\"]"),
        "duckcreekid" => p.Locator($"[duckcreekid=\"{Esc(value)}\"], [data-duckcreekid=\"{Esc(value)}\"]"),
        "associatedlabel" => p.Locator(AssociatedLabelXPath(value)),
        "label" => p.Locator(AssociatedLabelXPath(value)),
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
        "fieldref" => p.Locator($"[fieldref=\"{Esc(value)}\"], [data-fieldref=\"{Esc(value)}\"]"),
        "testid" => p.GetByTestId(value),
        "automationid" => p.Locator($"[automationid=\"{Esc(value)}\"], [data-automation-id=\"{Esc(value)}\"]"),
        "id" => p.Locator($"[id=\"{Esc(value)}\"]"),
        "name" => p.Locator($"[name=\"{Esc(value)}\"]"),
        "duckcreekid" => p.Locator($"[duckcreekid=\"{Esc(value)}\"], [data-duckcreekid=\"{Esc(value)}\"]"),
        "associatedlabel" => p.Locator(AssociatedLabelXPath(value)),
        "label" => p.Locator(AssociatedLabelXPath(value)),
        "placeholder" => p.GetByPlaceholder(value, new() { Exact = exact }),
        "text" => p.GetByText(value, new() { Exact = exact }),
        "title" => p.GetByTitle(value, new() { Exact = exact }),
        "role" => p.GetByRole(Role(role), new() { Name = value, Exact = exact }),
        "xpath" => p.Locator("xpath=" + NormalizeXPath(value)),
        "css" => p.Locator(value),
        _ => p.Locator(value)
    };
    public static ILocator ByAssociatedLabel(IPage page, string label) => page.Locator(AssociatedLabelXPath(label));
    public static ILocator ByAssociatedLabel(IFrameLocator frame, string label) => frame.Locator(AssociatedLabelXPath(label));
    private static string AssociatedLabelXPath(string label)
    {
        var q = XPathLiteral(label.Trim());
        // Resolve the label to the actual technical control. Supports for=id, nested controls, and common sibling layouts.
        return "xpath=(//*[@id = //label[normalize-space(string(.))=" + q + "]/@for]" +
               " | //label[normalize-space(string(.))=" + q + "]//*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1]" +
               " | //label[normalize-space(string(.))=" + q + "]/following-sibling::*[self::input or self::select or self::textarea or @role='checkbox' or @role='radio' or @role='combobox'][1])";
    }
    private static string XPathLiteral(string value)
    {
        if (!value.Contains('\'')) return $"'{value}'";
        if (!value.Contains('"')) return $"\"{value}\"";
        var parts = value.Split('\'');
        return "concat(" + string.Join(", \"'\", ", parts.Select(x => $"'{x}'")) + ")";
    }
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
