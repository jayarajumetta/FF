using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators
{
        public static ILocator DirectToConsumerSales(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$directToConsumerSales.value");

        public static ILocator BottledWine(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$bottledWine.value");

        public static ILocator ServedByTheGlass(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$servedByTheGlass.value");

        public static ILocator ConsumedOnPremise(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$consumedOnPremise.value");

        public static ILocator DirectToConsumerInternetSales(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$directToConsumerInternetSales.value");

        public static ILocator WholesaleWineSales(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$wholesaleWineSales.value");

        public static ILocator BulkWineSales(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$bulkWineSales.value");

        public static ILocator TotalWineSoldAnnually(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$totalWineSoldAnnually.value");

        public static ILocator TotalOtherThanWineSales(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$totalOtherThanWineSales.value");

        public static ILocator OtherAlcoholSalesExceed25(IPage page) =>
        page.GetByLabel("No", new() { Exact = true });

        public static ILocator PropertyDeductible(IPage page) =>
        page.GetByLabel("$1,000", new() { Exact = true });

        public static ILocator HarvestedGrapes(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankHarvested Grapes", Exact = true });

        public static ILocator HarvestedGrapesLimitOfInsurance(IPage page) =>
        page.Locator("id=fields.line.endWineryExtension.endWineryExtensionInput$harvestedGrapesLimitOfInsurance.value");

}
