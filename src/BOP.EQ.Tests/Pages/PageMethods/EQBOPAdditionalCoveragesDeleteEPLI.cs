using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPAdditionalCoveragesDeleteEPLI
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPAdditionalCoveragesDeleteEPLI(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator DeleteEPLICoverage => EQBOPAdditionalCoveragesDeleteEPLILocators.DeleteEPLICoverage(_page);

    public Task PressDeleteEPLICoverageAsync(string key) => DeleteEPLICoverage.PressAsync(key);

    public Task DoubleClickDeleteEPLICoverageAsync() => DeleteEPLICoverage.DblClickAsync();

    public Task ClickDeleteEPLICoverageAsync() => DeleteEPLICoverage.ClickAsync();

    public Task VerifyDeleteEPLICoverageAsync(string expected) =>
        Expect(DeleteEPLICoverage).ToContainTextAsync(_data.Resolve(expected));

    private ILocator EmploymentRelatedPracticesExclusion => EQBOPAdditionalCoveragesDeleteEPLILocators.EmploymentRelatedPracticesExclusion(_page);

    public Task PressEmploymentRelatedPracticesExclusionAsync(string key) => EmploymentRelatedPracticesExclusion.PressAsync(key);

    public Task DoubleClickEmploymentRelatedPracticesExclusionAsync() => EmploymentRelatedPracticesExclusion.DblClickAsync();

    public Task VerifyEmploymentRelatedPracticesExclusionAsync(string expected) =>
        Expect(EmploymentRelatedPracticesExclusion).ToContainTextAsync(_data.Resolve(expected));

}
