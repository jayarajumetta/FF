using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPPricingCAMARiskCategoriesLocators
{
        public static ILocator CatastrophePotential(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$catastrophePotentialReason.value");

        public static ILocator LossRatio(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$lossRatioReason.value");

        public static ILocator LengthOfEmployment(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$lengthOfEmploymentReason.value");

        public static ILocator MemberOfATradeAssociation(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$memberOfTradeAssociationReason.value");

        public static ILocator RiskManagementProgram(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$riskManagementProgramReason.value");

        public static ILocator YearsInBusiness(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$yearsInBusinessReason.value");

        public static ILocator UseOfSubcontractors(IPage page) =>
        page.Locator("id=fields.tierPricing.tierPricingInput$useOfSubcontractorsReason.value");

}
