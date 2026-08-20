using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    // Source modules: EQ||Account Details | confidence=Medium score=113
    public ILocator AccountDetailsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Next", Exact = true });

    // Source modules: EQ||Account Details | confidence=Review score=97
    public ILocator AccountInformation => _page.GetByLabel("Lbl_Account Information", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator BestPhoneAccountOwner => _page.Locator("[name=\"Txt_Best phone_Account Owner\"], [id=\"Txt_Best phone_Account Owner\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=114
    public ILocator DOB => _page.Locator("[name=\"Txt_DOB\"], [id=\"Txt_DOB\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Divorced => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator DrpdwnState => _page.GetByLabel("Drpdwn_State", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator EmailAccountOwner => _page.Locator("[name=\"Txt_Email_Account Owner\"], [id=\"Txt_Email_Account Owner\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=114
    public ILocator EnterALocation => _page.Locator("[name=\"Txt_Enter a location\"], [id=\"Txt_Enter a location\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator FirstNameAccountOwner => _page.Locator("[name=\"Txt_First Name_Account Owner\"], [id=\"Txt_First Name_Account Owner\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=118
    public ILocator IsTheAccountAddressAlsoWhereTheClientResides => _page.GetByLabel("Is the account address also where the client resides?", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=Medium score=108
    public ILocator MaritalStatus => _page.GetByLabel("Lbl_Marital Status:", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Married => Divorced; // semantic alias; locator defined once

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressCityNew => _page.Locator("[name=\"Txt_owner.address.city_New\"], [id=\"Txt_owner.address.city_New\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressLine2 => _page.Locator("[name=\"Txt_owner.address.line2\"], [id=\"Txt_owner.address.line2\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressZip => _page.Locator("[name=\"Txt_owner.address.zip\"], [id=\"Txt_owner.address.zip\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=83
    public ILocator Satellite => _page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Single => Divorced; // semantic alias; locator defined once

    // Source modules: EQ||Account Details | confidence=Review score=97
    public ILocator StateName => _page.GetByLabel("State Name", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator YesAtLeast90Days => _page.GetByTestId("owner.address.resided90days-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator YesClientResides => _page.GetByTestId("owner.address.useAsResidence-chip-wrapper");

}
