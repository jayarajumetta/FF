using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Serilog;
using ToscaArtifactAutomation.Core.Browser;
using ToscaArtifactAutomation.Core.Configuration;

namespace ToscaArtifactAutomation.Core.Locators;

public sealed class LocatorResolver
{
    private readonly BrowserSession _browser;
    private readonly RootSettings _settings;
    private readonly LocatorCatalog _catalog;

    public LocatorResolver(BrowserSession browser, RootSettings settings, LocatorCatalogProvider provider)
    {
        _browser = browser ?? throw new ArgumentNullException(nameof(browser));
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _catalog = provider?.Catalog ?? throw new ArgumentNullException(nameof(provider));
    }

    public async Task<ILocator> ResolveAsync(string target, string module = "", int timeoutMs = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(target);
        var definitions = FindDefinitions(target, module);
        var matches = new List<(LocatorDefinition Definition, ILocator Locator)>();
        foreach (var definition in definitions)
        {
            foreach (var candidate in definition.Candidates.OrderByDescending(x => x.Score))
            {
                var locator = Build(candidate).First;
                try
                {
                    if (await locator.CountAsync() > 0 && await locator.IsVisibleAsync())
                    {
                        matches.Add((definition, locator));
                        break;
                    }
                }
                catch (PlaywrightException) { }
            }
        }
        var uniqueDefinitions = matches.GroupBy(x => x.Definition.Id).Select(x => x.First()).ToArray();
        if (uniqueDefinitions.Length > 1 && _settings.Framework.StrictLocatorAmbiguity)
        {
            var details = string.Join(", ", uniqueDefinitions.Select(x => $"{x.Definition.Module}/{x.Definition.Name}"));
            throw new InvalidOperationException($"Locator '{target}' is ambiguous for module '{module}'. Visible source definitions: {details}.");
        }
        if (uniqueDefinitions.Length > 0) return uniqueDefinitions[0].Locator;

        var fallback = FallbackLocators(target).First();
        await fallback.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Attached,
            Timeout = timeoutMs > 0 ? timeoutMs : _settings.Framework.DefaultTimeoutMs
        });
        return fallback;
    }

    public async Task<ILocator?> TryResolveAsync(string target, string module = "")
    {
        if (string.IsNullOrWhiteSpace(target)) return null;
        foreach (var locator in CandidateLocators(target, module))
        {
            try
            {
                if (await locator.CountAsync() > 0 && await locator.IsVisibleAsync()) return locator.First;
            }
            catch (PlaywrightException) { }
        }
        return null;
    }

    public async Task<bool> ExistsAsync(string target, string module = "")
    {
        if (string.IsNullOrWhiteSpace(target)) return false;
        foreach (var locator in CandidateLocators(target, module))
        {
            try { if (await locator.CountAsync() > 0) return true; }
            catch (PlaywrightException) { }
        }
        return false;
    }

    public IEnumerable<ILocator> CandidateLocators(string target, string module = "")
    {
        foreach (var definition in FindDefinitions(target, module))
            foreach (var candidate in definition.Candidates.OrderByDescending(x => x.Score))
                yield return Build(candidate);
        foreach (var fallback in FallbackLocators(target)) yield return fallback;
    }

    private IReadOnlyList<LocatorDefinition> FindDefinitions(string target, string module)
    {
        var normalized = Normalize(LastSegment(target));
        var moduleNormalized = Normalize(module);
        var matches = _catalog.Definitions
            .Where(x => string.Equals(Normalize(x.Name), normalized, StringComparison.OrdinalIgnoreCase)
                     || string.Equals(x.NormalizedName, normalized, StringComparison.OrdinalIgnoreCase))
            .ToList();
        if (matches.Count == 0 && normalized.Length >= 4)
            matches = _catalog.Definitions.Where(x => Normalize(x.Name).EndsWith(normalized, StringComparison.OrdinalIgnoreCase)
                                                   || normalized.EndsWith(Normalize(x.Name), StringComparison.OrdinalIgnoreCase)).ToList();
        return matches
            .OrderByDescending(x => ModuleSimilarity(Normalize(x.Module), moduleNormalized))
            .ThenByDescending(x => x.QualityScore)
            .ThenBy(x => x.Id, StringComparer.Ordinal)
            .ToArray();
    }

    private ILocator Build(LocatorCandidate candidate)
    {
        var page = _browser.Page;
        var value = candidate.Value.Trim().Trim('"');
        return candidate.Strategy.ToLowerInvariant() switch
        {
            "testid" => page.GetByTestId(value),
            "id" or "duckcreekid" => page.Locator($"[id=\"{CssEscape(value)}\"]"),
            "name" => page.Locator($"[name=\"{CssEscape(value)}\"]"),
            "fieldref" => page.Locator($"[data-fieldref=\"{CssEscape(value)}\"]"),
            "role" => RoleLocator(page, candidate.Role, value),
            "label" or "arialabel" => page.GetByLabel(value, new PageGetByLabelOptions { Exact = true }),
            "text" => page.GetByText(value, new PageGetByTextOptions { Exact = true }),
            "csstagclass" => page.Locator(value),
            "xpath" => page.Locator(value.StartsWith("xpath=", StringComparison.OrdinalIgnoreCase) ? value : "xpath=" + value),
            _ => page.GetByText(value, new PageGetByTextOptions { Exact = true })
        };
    }

    private IEnumerable<ILocator> FallbackLocators(string target)
    {
        var page = _browser.Page;
        var value = LastSegment(target).Trim();
        yield return page.GetByLabel(value, new PageGetByLabelOptions { Exact = true });
        yield return page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = value, Exact = true });
        yield return page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = value, Exact = true });
        yield return page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { Name = value, Exact = true });
        yield return page.Locator($"[name=\"{CssEscape(value)}\"]");
        yield return page.Locator($"[id=\"{CssEscape(value)}\"]");
        yield return page.GetByText(value, new PageGetByTextOptions { Exact = true });
    }

    private static ILocator RoleLocator(IPage page, string role, string value)
    {
        if (!Enum.TryParse<AriaRole>(role, true, out var ariaRole)) ariaRole = AriaRole.Generic;
        return page.GetByRole(ariaRole, new PageGetByRoleOptions { Name = value, Exact = true });
    }

    private static int ModuleSimilarity(string left, string right)
    {
        if (string.IsNullOrWhiteSpace(right)) return 0;
        if (string.Equals(left, right, StringComparison.OrdinalIgnoreCase)) return 100;
        if (left.Contains(right, StringComparison.OrdinalIgnoreCase) || right.Contains(left, StringComparison.OrdinalIgnoreCase)) return 70;
        var l = left.Split('|', StringSplitOptions.RemoveEmptyEntries).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var r = right.Split('|', StringSplitOptions.RemoveEmptyEntries).ToHashSet(StringComparer.OrdinalIgnoreCase);
        return l.Intersect(r, StringComparer.OrdinalIgnoreCase).Count() * 10;
    }

    private static string Normalize(string value) => Regex.Replace(value ?? string.Empty, "[^a-z0-9]+", string.Empty, RegexOptions.IgnoreCase).ToLowerInvariant();
    private static string LastSegment(string value) => value.Split('>', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? value;
    private static string CssEscape(string value) => value.Replace("\\", "\\\\", StringComparison.Ordinal).Replace("\"", "\\\"", StringComparison.Ordinal);
}
