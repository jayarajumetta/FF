using Microsoft.Playwright;
namespace InsuranceAutomation.Core.SelfHealing;

public static class DomContextCollector
{
    public static async Task<IReadOnlyList<DomElementSnapshot>> CollectAsync(IPage page)
    {
        // Intentionally excludes input values and textareas' values to avoid sending credentials/PII to Copilot.
        return await page.EvaluateAsync<IReadOnlyList<DomElementSnapshot>>(@"() => {
          const clean = v => (v || '').toString().replace(/\\s+/g,' ').trim().slice(0,180);
          const nodes = [...document.querySelectorAll('input,button,select,textarea,a,[role],[data-testid],[aria-label]')].slice(0,450);
          return nodes.map(e => ({
            Tag: clean(e.tagName).toLowerCase(),
            Role: clean(e.getAttribute('role')),
            Id: clean(e.id),
            Name: clean(e.getAttribute('name')),
            AriaLabel: clean(e.getAttribute('aria-label')),
            Placeholder: clean(e.getAttribute('placeholder')),
            Text: clean(e.innerText || e.textContent),
            TestId: clean(e.getAttribute('data-testid') || e.getAttribute('data-test-id')),
            DuckCreekId: clean(e.getAttribute('data-duckcreek-id') || e.getAttribute('duckcreekid')),
            Type: clean(e.getAttribute('type'))
          }));
        }") ?? Array.Empty<DomElementSnapshot>();
    }
}
