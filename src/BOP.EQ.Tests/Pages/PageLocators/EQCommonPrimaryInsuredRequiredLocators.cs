using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPrimaryInsuredRequiredLocators
{
        public static ILocator ExistingClient(IPage page) =>
        page.GetByTestId("temp.clientSuggestions-cif-client-*-wrapper");

        public static ILocator IndividualSoleProprietorOld(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Individual/Sole Proprietor", Exact = true });

        public static ILocator NextSFP(IPage page) =>
        page.GetByTestId("next-button");

        public static ILocator IndividualSoleProprietor(IPage page) =>
        page.GetByTestId("fields.data.account.accountInput$entityType.value-chip-wrapper");

        public static ILocator MobilePhoneNumber(IPage page) =>
        page.Locator("id=fields.data.account.accountInput$mobilePhoneNumber.value");

        public static ILocator PrimaryPhone(IPage page) =>
        page.Locator("[name=\"fields.data.account.accountInput$primaryPhone.value\"]");

        public static ILocator Save(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true });

        public static ILocator EditGeneralInfo(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Edit", Exact = true });

}
