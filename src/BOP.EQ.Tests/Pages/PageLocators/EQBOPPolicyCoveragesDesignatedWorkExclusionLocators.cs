using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPolicyCoveragesDesignatedWorkExclusionLocators
{
        public static ILocator IsOperationCoveredUnderAnotherPolicy(IPage page) =>
        page.Locator("id=fields.line.endDesignatedWorkExclusion.endDesignatedWorkExclusionInput$coveredUnderOtherPolicy.value");

}
