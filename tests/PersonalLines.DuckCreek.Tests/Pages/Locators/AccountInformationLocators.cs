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
    public ILocator BestPhoneAccountOwner => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_Best phone_Account Owner", Exact = true });

    // Source modules: EQ||Account Details | confidence=Medium score=114
    public ILocator DOB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_DOB", Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Divorced => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator DrpdwnState => _page.GetByLabel("Drpdwn_State", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator EmailAccountOwner => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_Email_Account Owner", Exact = true });

    // Source modules: EQ||Account Details | confidence=Medium score=114
    public ILocator EnterALocation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_Enter a location", Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator FirstNameAccountOwner => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_First Name_Account Owner", Exact = true });

    // Source modules: EQ||Account Details | confidence=Medium score=118
    public ILocator IsTheAccountAddressAlsoWhereTheClientResides => _page.GetByLabel("Is the account address also where the client resides?", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=Medium score=108
    public ILocator MaritalStatus => _page.GetByLabel("Lbl_Marital Status:", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Married => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressCityNew => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_owner.address.city_New", Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressLine2 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_owner.address.line2", Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressZip => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_owner.address.zip", Exact = true });

    // Source modules: EQ||Account Details | confidence=Medium score=83
    public ILocator Satellite => _page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Single => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=Review score=97
    public ILocator StateName => _page.GetByLabel("State Name", new() { Exact = true });

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator YesAtLeast90Days => _page.GetByTestId("owner.address.resided90days-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator YesClientResides => _page.GetByTestId("owner.address.useAsResidence-chip-wrapper");

}
