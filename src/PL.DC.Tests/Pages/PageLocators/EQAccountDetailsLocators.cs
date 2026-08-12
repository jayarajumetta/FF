using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQAccountDetailsLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator LblMaritalStatus(IPage page) =>
        page.GetByText("Marital Status:", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LblIsTheAccountAddressAlsoWhereTheClientResides(IPage page) =>
        page.GetByText("Is the account address also where the client resides?", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtFirstNameAccountOwner(IPage page) =>
        page.Locator("id=owner.name.first");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtBestPhoneAccountOwner(IPage page) =>
        page.Locator("id=owner.phone");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtEmailAccountOwner(IPage page) =>
        page.Locator("id=owner.email");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnSingle(IPage page) =>
        page.GetByTestId("owner.maritalStatus-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnMarried(IPage page) =>
        page.GetByTestId("owner.maritalStatus-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnDivorced(IPage page) =>
        page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtOwnerAddressLine2(IPage page) =>
        page.Locator("id=owner.address.line2");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtOwnerAddressCityNew(IPage page) =>
        page.Locator("id=owner.address.city");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator DrpdwnState(IPage page) =>
        page.Locator("id=owner.address.state");

        // REVIEW: source field not uniquely resolved.
    public static ILocator StateName(IPage page) =>
        page.GetByText("{STRINGTOUPPER[{{buffer:StateName}}]}", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator TxtOwnerAddressZip(IPage page) =>
        page.Locator("id=owner.address.zip");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Satellite(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnNext(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnYesAtLeast90Days(IPage page) =>
        page.GetByTestId("owner.address.resided90days-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator BtnYesClientResides(IPage page) =>
        page.GetByText("Yes", new() { Exact = true });

}
