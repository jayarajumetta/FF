using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPriorCarrierClaimsRequiredInfoLocators
{
        public static ILocator PriorPolicyNo(IPage page) =>
        page.GetByTestId("fields.data.policy.policyInput$exposuresInsuredAN90Days.value-chip-wrapper");

        public static ILocator YearsInBusiness(IPage page) =>
        page.Locator("id=fields.data.policy.policyUnderwriting.accountInput$yearsInBusiness.value");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Item3Years(IPage page) =>
        page.GetByText("3+ years", new() { Exact = true });

        public static ILocator PriorInsuranceLatestExpirationDate(IPage page) =>
        page.Locator("id=fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestExpirationDate.value");

        public static ILocator PriorInsuranceLatestCarrier(IPage page) =>
        page.Locator("id=fields.data.policy.policyUnderwriting.policyUnderwritingInput$priorInsuranceLatestCarrier.value");

}
