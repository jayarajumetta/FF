using Microsoft.Playwright;
using ToscaModernized.Core.Configuration;

namespace ToscaModernized.Core.Locators;

public sealed class LocatorResolver
{
    private readonly IPage _page;
    private readonly LocatorRepository _repository;
    private readonly FrameworkSettings _settings;

    public LocatorResolver(IPage page, LocatorRepository repository, FrameworkSettings settings)
    {
        _page = page;
        _repository = repository;
        _settings = settings;
    }

    public async Task<ILocator> ResolveAsync(string target, string? moduleHint = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(target);
        var attempted = new List<string>();
        foreach (var definition in _repository.Find(target, moduleHint))
        {
            foreach (var candidate in definition.Candidates.OrderByDescending(c => c.Score))
            {
                try
                {
                    var locator = Build(candidate);
                    attempted.Add($"{candidate.Strategy}={candidate.Value}");
                    var count = await locator.CountAsync().ConfigureAwait(false);
                    if (count == 1) return locator;
                    if (count > 1 && !_settings.Execution.StrictLocatorAmbiguity) return locator.First;
                }
                catch (PlaywrightException)
                {
                    // Try the next source-derived candidate.
                }
            }
        }

        foreach (var locator in DynamicFallbacks(target))
        {
            try
            {
                var count = await locator.CountAsync().ConfigureAwait(false);
                if (count == 1) return locator;
                if (count > 1 && !_settings.Execution.StrictLocatorAmbiguity) return locator.First;
            }
            catch (PlaywrightException)
            {
                // Continue through deterministic fallbacks.
            }
        }

        throw new InvalidOperationException($"Unable to resolve a unique locator for '{target}'. Attempted source candidates: {string.Join(", ", attempted)}");
    }

    private ILocator Build(LocatorCandidate candidate) => candidate.Strategy switch
    {
        "TestId" => _page.GetByTestId(candidate.Value),
        "Id" => _page.Locator(CssAttribute("id", candidate.Value)),
        "DuckCreekId" => _page.Locator($"{CssAttribute("id", candidate.Value)}, {CssAttribute("name", candidate.Value)}, {CssAttribute("data-duckcreek-id", candidate.Value)}, {CssAttribute("data-fieldref", candidate.Value)}"),
        "FieldRef" => _page.Locator(CssAttribute("data-fieldref", candidate.Value)),
        "AutomationId" => _page.Locator(CssAttribute("data-automation-id", candidate.Value)),
        "AriaLabel" => _page.GetByLabel(candidate.Value, new() { Exact = true }),
        "Label" => _page.GetByLabel(candidate.Value, new() { Exact = true }),
        "Name" => _page.Locator(CssAttribute("name", candidate.Value)),
        "Role" => ByRole(candidate.Role, candidate.Value),
        "Text" => _page.GetByText(candidate.Value, new() { Exact = true }),
        "XPath" => _page.Locator("xpath=" + candidate.Value),
        "CssTagClass" => _page.Locator(candidate.Value),
        _ => _page.GetByText(candidate.Value, new() { Exact = true })
    };

    private ILocator ByRole(string role, string name)
    {
        var ariaRole = role.ToLowerInvariant() switch
        {
            "button" => AriaRole.Button,
            "link" => AriaRole.Link,
            "checkbox" => AriaRole.Checkbox,
            "radio" => AriaRole.Radio,
            "textbox" => AriaRole.Textbox,
            "combobox" => AriaRole.Combobox,
            "img" => AriaRole.Img,
            "listitem" => AriaRole.Listitem,
            _ => AriaRole.Generic
        };
        return _page.GetByRole(ariaRole, new() { Name = name, Exact = true });
    }

    private IEnumerable<ILocator> DynamicFallbacks(string target)
    {
        yield return _page.GetByTestId(target);
        yield return _page.GetByLabel(target, new() { Exact = true });
        yield return _page.Locator(CssAttribute("id", target));
        yield return _page.Locator(CssAttribute("name", target));
        yield return _page.Locator(CssAttribute("data-fieldref", target));
        yield return _page.GetByRole(AriaRole.Button, new() { Name = target, Exact = true });
        yield return _page.GetByRole(AriaRole.Link, new() { Name = target, Exact = true });
        yield return _page.GetByText(target, new() { Exact = true });
    }

    private static string CssAttribute(string name, string value) => $"[{name}=\"{CssEscape(value)}\"]";

    private static string CssEscape(string value) => value
        .Replace("\\", "\\\\", StringComparison.Ordinal)
        .Replace("\"", "\\\"", StringComparison.Ordinal)
        .Replace("\r", "\\D ", StringComparison.Ordinal)
        .Replace("\n", "\\A ", StringComparison.Ordinal);
}
