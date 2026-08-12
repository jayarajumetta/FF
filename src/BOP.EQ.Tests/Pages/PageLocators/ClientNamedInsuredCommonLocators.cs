using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class ClientNamedInsuredCommonLocators
{
        public static ILocator LaunchInspire(IPage page) =>
        page.Locator("[data-duckcreek-id=\"Launch Inspire\"]");

        public static ILocator Client(IPage page) =>
        page.Locator("id=pageTitle");

        public static ILocator InsuredType(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.InsuredType\"]");

        public static ILocator EntityType(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.EntityType\"]");

        public static ILocator YearsInBusiness(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.YearsInBusiness\"]");

        public static ILocator PrimaryPhone(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.PrimaryPhone\"]");

        public static ILocator Address1(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.Address1\"]");

        public static ILocator ZipCode(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.ZipCode\"]");

        public static ILocator Address2(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.Address2\"]");

}
