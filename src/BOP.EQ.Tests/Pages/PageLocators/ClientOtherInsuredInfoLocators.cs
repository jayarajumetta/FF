using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class ClientOtherInsuredInfoLocators
{
        public static ILocator WebsiteAddress(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.WebsiteAddress\"]");

        public static ILocator NameOfAuditContact(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.AuditContact\"]");

        public static ILocator AuditTelephone(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.AuditContactPhone\"]");

        public static ILocator NameOfInspectionContact(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.InspectionContact\"]");

        public static ILocator InspectionTelephone(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.InspectionContactPhone\"]");

        public static ILocator InsuredEMailAddress(IPage page) =>
        page.Locator("[data-duckcreek-id=\"AccountInput.Email\"]");

}
