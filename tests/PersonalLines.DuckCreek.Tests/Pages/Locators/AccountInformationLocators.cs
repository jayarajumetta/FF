using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    // Source modules: EQ||Account Details | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Account Details | Txt_First Name_Account Owner | Id+Name
    public ILocator AccountDetailsNext => _page.Locator("input[id=\"owner.name.first\"][name=\"owner.name.first\"]");

    // Source modules: EQ||Account Details | confidence=Review score=97
    // v56 raw Tosca primary: EQ||Account Details | Txt_owner.address.line2 | Id+Name
    public ILocator AccountInformation => _page.Locator("input[id=\"owner.address.line2\"][name=\"owner.address.line2\"]");

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator BestPhoneAccountOwner => _page.Locator("[name=\"Txt_Best phone_Account Owner\"], [id=\"Txt_Best phone_Account Owner\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=114
    public ILocator DOB => _page.Locator("[name=\"Txt_DOB\"], [id=\"Txt_DOB\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Divorced => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=127
    // v56 raw Tosca primary: EQ||Account Details | Drpdwn_State | Id
    public ILocator DrpdwnState => _page.Locator("[id=\"owner.address.state\"]");

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator EmailAccountOwner => _page.Locator("[name=\"Txt_Email_Account Owner\"], [id=\"Txt_Email_Account Owner\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=114
    public ILocator EnterALocation => _page.Locator("[name=\"Txt_Enter a location\"], [id=\"Txt_Enter a location\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator FirstNameAccountOwner => _page.Locator("[name=\"Txt_First Name_Account Owner\"], [id=\"Txt_First Name_Account Owner\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=118
    // v56 raw Tosca primary: EQ||Account Details | Txt_owner.address.line2 | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AccountInformation
    public ILocator IsTheAccountAddressAlsoWhereTheClientResides => AccountInformation;

    // Source modules: EQ||Account Details | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Account Details | Txt_owner.address.line2 | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AccountInformation
    public ILocator MaritalStatus => AccountInformation;

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Married => Divorced; // semantic alias; locator defined once

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressCityNew => _page.Locator("[name=\"Txt_owner.address.city_New\"], [id=\"Txt_owner.address.city_New\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressLine2 => _page.Locator("[name=\"Txt_owner.address.line2\"], [id=\"Txt_owner.address.line2\"]").First;

    // Source modules: EQ||Account Details | confidence=High score=127
    public ILocator OwnerAddressZip => _page.Locator("[name=\"Txt_owner.address.zip\"], [id=\"Txt_owner.address.zip\"]").First;

    // Source modules: EQ||Account Details | confidence=Medium score=83
    // v56 raw Tosca primary: EQ||Account Details | Txt_owner.address.line2 | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AccountInformation
    public ILocator Satellite => AccountInformation;

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator Single => Divorced; // semantic alias; locator defined once

    // Source modules: EQ||Account Details | confidence=Review score=97
    // v56 raw Tosca primary: EQ||Account Details | Txt_First Name_Account Owner | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AccountDetailsNext
    public ILocator StateName => AccountDetailsNext;

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator YesAtLeast90Days => _page.GetByTestId("owner.address.resided90days-chip-wrapper");

    // Source modules: EQ||Account Details | confidence=High score=130
    public ILocator YesClientResides => _page.GetByTestId("owner.address.useAsResidence-chip-wrapper");

}
