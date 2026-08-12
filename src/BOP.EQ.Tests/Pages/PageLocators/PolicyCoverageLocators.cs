using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class PolicyCoverageLocators
{
        public static ILocator PolicyCoverage(IPage page) =>
        page.Locator("id=pageTitle");

        public static ILocator LiabilityPerOccurenceLimit(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInput.LiabilityPerOccurenceLimit\"]");

        public static ILocator ProductsCompletedAggregateLimit(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInput.ProductsCompletedAggregateLimit\"]");

        public static ILocator GeneralAggregateLimit(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInput.GeneralAggregateLimit\"]");

        public static ILocator NumberOfEmployees(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInputNonShredded.NumberOfEmployees\"]");

        public static ILocator NumberOfPartTimeEmployees(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInputNonShredded.NumberOfPartTimeEmployees\"]");

        public static ILocator NumberOfSeasonalEmployees(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInputNonShredded.NumberOfSeasonalEmployees\"]");

        public static ILocator IsTheInsuredEngagedInAnySnowOrIceRemovalOperations(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInput.SnowplowOperation\"]");

        public static ILocator DoesBuildingSInMarylandContain1OrMoreResidentialRentalUnits(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInput.MarylandResidentialRentalUnits\"]");

        public static ILocator LPGTransportQuestion(IPage page) =>
        page.Locator("[data-duckcreek-id=\"LineInput.LiquefiedPetroleumTransport\"]");

}
