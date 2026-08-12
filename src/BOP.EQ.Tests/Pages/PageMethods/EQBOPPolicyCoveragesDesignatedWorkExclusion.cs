using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPPolicyCoveragesDesignatedWorkExclusion
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPPolicyCoveragesDesignatedWorkExclusion(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator IsOperationCoveredUnderAnotherPolicy => EQBOPPolicyCoveragesDesignatedWorkExclusionLocators.IsOperationCoveredUnderAnotherPolicy(_page);

    public Task PressIsOperationCoveredUnderAnotherPolicyAsync(string key) => IsOperationCoveredUnderAnotherPolicy.PressAsync(key);

    public Task DoubleClickIsOperationCoveredUnderAnotherPolicyAsync() => IsOperationCoveredUnderAnotherPolicy.DblClickAsync();

    public Task SetIsOperationCoveredUnderAnotherPolicyAsync(string value) =>
        IsOperationCoveredUnderAnotherPolicy.SelectOptionAsync(_data.Resolve(value));

}
