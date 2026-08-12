using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonAccountDetailsAccountInfoLocators
{
        public static ILocator AccountInformationHeader(IPage page) =>
        page.GetByText("Account Information", new() { Exact = true });

        public static ILocator OwnerMiddleName(IPage page) =>
        page.Locator("id=owner.name.middle");

        public static ILocator OwnerPhone(IPage page) =>
        page.Locator("id=owner.phone");

        public static ILocator OwnerEmail(IPage page) =>
        page.Locator("id=owner.email");

        public static ILocator Married(IPage page) =>
        page.GetByTestId("owner.maritalStatus-chip-wrapper");

        public static ILocator StreetAddress(IPage page) =>
        page.Locator("id=owner.address.line1");

        public static ILocator Address2(IPage page) =>
        page.Locator("id=owner.address.line2");

        public static ILocator City(IPage page) =>
        page.Locator("id=owner.address.city");

        public static ILocator StateDropdown(IPage page) =>
        page.Locator("id=owner.address.state");

        // REVIEW: no stronger source locator.
    public static ILocator StateName(IPage page) =>
        page.GetByText("{STRINGTOUPPER[{{buffer:StateName}}]}", new() { Exact = true });

        public static ILocator Zip(IPage page) =>
        page.Locator("id=owner.address.zip");

        public static ILocator County(IPage page) =>
        page.Locator("id=owner.address.county");

        public static ILocator Map(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Map", Exact = true });

        public static ILocator Satellite(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });

        public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

        public static ILocator HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes(IPage page) =>
        page.GetByTestId("owner.address.resided90days-chip-wrapper");

        public static ILocator IsTheAccountAddressAlsoWhereTheClientResidesYes(IPage page) =>
        page.GetByTestId("owner.address.useAsResidence-chip-wrapper");

}
