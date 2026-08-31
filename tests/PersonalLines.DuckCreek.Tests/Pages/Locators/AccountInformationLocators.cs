using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    public ILocator AccountDetailsNext => _page.Locator("input[id=\"owner.name.first\"][name=\"owner.name.first\"]");

    public ILocator AccountInformation => _page.Locator("input[id=\"owner.address.line2\"][name=\"owner.address.line2\"]");

    public ILocator BestPhoneAccountOwner => _page.Locator("[name=\"Txt_Best phone_Account Owner\"], [id=\"Txt_Best phone_Account Owner\"]").First;

    public ILocator DOB => _page.Locator("[name=\"Txt_DOB\"], [id=\"Txt_DOB\"]").First;

    public ILocator Divorced => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    public ILocator DrpdwnState => _page.Locator("[id=\"owner.address.state\"]");

    public ILocator EmailAccountOwner => _page.Locator("[name=\"Txt_Email_Account Owner\"], [id=\"Txt_Email_Account Owner\"]").First;

    public ILocator EnterALocation => _page.Locator("[name=\"Txt_Enter a location\"], [id=\"Txt_Enter a location\"]").First;

    public ILocator FirstNameAccountOwner => _page.Locator("[name=\"Txt_First Name_Account Owner\"], [id=\"Txt_First Name_Account Owner\"]").First;




    public ILocator OwnerAddressCityNew => _page.Locator("[name=\"Txt_owner.address.city_New\"], [id=\"Txt_owner.address.city_New\"]").First;

    public ILocator OwnerAddressLine2 => _page.Locator("[name=\"Txt_owner.address.line2\"], [id=\"Txt_owner.address.line2\"]").First;

    public ILocator OwnerAddressZip => _page.Locator("[name=\"Txt_owner.address.zip\"], [id=\"Txt_owner.address.zip\"]").First;




    public ILocator YesAtLeast90Days => _page.GetByTestId("owner.address.resided90days-chip-wrapper");

    public ILocator YesClientResides => _page.GetByTestId("owner.address.useAsResidence-chip-wrapper");

}
