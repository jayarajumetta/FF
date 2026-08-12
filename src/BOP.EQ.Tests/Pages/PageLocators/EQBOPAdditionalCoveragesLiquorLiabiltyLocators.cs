using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPAdditionalCoveragesLiquorLiabiltyLocators
{
        public static ILocator GrossLiquorSales(IPage page) =>
        page.Locator("id=fields.line.endLiquorLiability.endLiquorLiabilityInput$grossLiquorSales.value");

        public static ILocator NumberOfEvents(IPage page) =>
        page.Locator("id=fields.line.endLiquorLiability.endLiquorLiabilityInput$numberOfEvents.value");

        public static ILocator LiquorLiabilityDescriptionOfActivities(IPage page) =>
        page.Locator("id=fields.line.endLiquorLiability.endLiquorLiabilityInput$activitiesDescription.value");

        public static ILocator NoneOfTheAbove(IPage page) =>
        page.GetByTestId("fields.line.endLiquorLiability.endLiquorLiabilityInput$noneOfTheAbove.value-label");

}
