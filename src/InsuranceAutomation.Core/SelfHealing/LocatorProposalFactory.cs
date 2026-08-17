using Microsoft.Playwright;
namespace InsuranceAutomation.Core.SelfHealing;

public static class LocatorProposalFactory
{
    public static ILocator Create(IPage page, LocatorProposal p)
    {
        var strategy = (p.Strategy ?? "").Trim().ToLowerInvariant();
        return strategy switch
        {
            "testid" => page.GetByTestId(p.Value),
            "label" => page.GetByLabel(p.Value, new() { Exact = p.Exact }),
            "placeholder" => page.GetByPlaceholder(p.Value, new() { Exact = p.Exact }),
            "text" => page.GetByText(p.Value, new() { Exact = p.Exact }),
            "role" => CreateRole(page, p),
            "id" => page.Locator("#" + CssEscape(p.Value)),
            "name" => page.Locator($"[name=\"{CssAttributeEscape(p.Value)}\"]"),
            "duckcreekid" => page.Locator($"[data-duckcreek-id=\"{CssAttributeEscape(p.Value)}\"]"),
            "css" => page.Locator(p.Value),
            _ => throw new InvalidOperationException($"Copilot locator strategy '{p.Strategy}' is not allowed.")
        };
    }

    static ILocator CreateRole(IPage page, LocatorProposal p)
    {
        if (!Enum.TryParse<AriaRole>(NormalizeRole(p.Value), true, out var role))
            throw new InvalidOperationException($"Unsupported ARIA role '{p.Value}'.");
        return page.GetByRole(role, new() { Name = p.Name ?? "", Exact = p.Exact });
    }

    static string NormalizeRole(string v) => v.Replace("-", "", StringComparison.Ordinal).Replace("_", "", StringComparison.Ordinal);
    static string CssEscape(string v) => v.Replace("\\", "\\\\").Replace(":", "\\:").Replace(".", "\\.").Replace("[", "\\[").Replace("]", "\\]");
    static string CssAttributeEscape(string v) => v.Replace("\\", "\\\\").Replace("\"", "\\\"");
}
