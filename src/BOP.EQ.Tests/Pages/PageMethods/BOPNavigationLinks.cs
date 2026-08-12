using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class BOPNavigationLinks
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public BOPNavigationLinks(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PolicyCoverage => BOPNavigationLinksLocators.PolicyCoverage(_page);

    public Task PressPolicyCoverageAsync(string key) => PolicyCoverage.PressAsync(key);

    public Task DoubleClickPolicyCoverageAsync() => PolicyCoverage.DblClickAsync();

    public Task ClickPolicyCoverageAsync() => PolicyCoverage.ClickAsync();

    private ILocator Location => BOPNavigationLinksLocators.Location(_page);

    public Task PressLocationAsync(string key) => Location.PressAsync(key);

    public Task DoubleClickLocationAsync() => Location.DblClickAsync();

    public Task ClickLocationAsync() => Location.ClickAsync();

    public Task WaitForLocationAsync() =>
        Location.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Building => BOPNavigationLinksLocators.Building(_page);

    public Task PressBuildingAsync(string key) => Building.PressAsync(key);

    public Task DoubleClickBuildingAsync() => Building.DblClickAsync();

    public Task ClickBuildingAsync() => Building.ClickAsync();

    private ILocator CompanyEndorsements => BOPNavigationLinksLocators.CompanyEndorsements(_page);

    public Task PressCompanyEndorsementsAsync(string key) => CompanyEndorsements.PressAsync(key);

    public Task DoubleClickCompanyEndorsementsAsync() => CompanyEndorsements.DblClickAsync();

    public Task ClickCompanyEndorsementsAsync() => CompanyEndorsements.ClickAsync();

    private ILocator Pricing => BOPNavigationLinksLocators.Pricing(_page);

    public Task PressPricingAsync(string key) => Pricing.PressAsync(key);

    public Task DoubleClickPricingAsync() => Pricing.DblClickAsync();

    public Task ClickPricingAsync() => Pricing.ClickAsync();

    private ILocator BOPUWQuestions => BOPNavigationLinksLocators.BOPUWQuestions(_page);

    public Task PressBOPUWQuestionsAsync(string key) => BOPUWQuestions.PressAsync(key);

    public Task DoubleClickBOPUWQuestionsAsync() => BOPUWQuestions.DblClickAsync();

    public Task ClickBOPUWQuestionsAsync() => BOPUWQuestions.ClickAsync();

}
