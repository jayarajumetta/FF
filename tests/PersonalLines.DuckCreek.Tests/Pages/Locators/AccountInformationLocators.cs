using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    public ILocator AccountDetailsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator AccountInformation => _page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true });

    public ILocator BestPhoneAccountOwner => _page.Locator("[id='owner.phone']");

    public ILocator DOB => _page.Locator("[id='owner.dateOfBirth']");

    public ILocator Divorced => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    public ILocator Single => _page.Locator("[data-testid='owner.maritalStatus-chip-wrapper']").Filter(new() { HasText = "Single" });

    public ILocator DrpdwnState => _page.Locator("[id=\"owner.address.state\"]");

    public ILocator EmailAccountOwner => _page.Locator("[id='owner.email']");

    public ILocator EnterALocation => _page.Locator("[id='owner.address.line1']");
    public ILocator StateDropdown => _page.Locator("[id='owner.address.state']");

    public ILocator FirstNameAccountOwner => _page.Locator("[name=\"Txt_First Name_Account Owner\"], [id=\"Txt_First Name_Account Owner\"]").First;


    public ILocator Satellite => _page.Locator("button:has-text('Satellite'), [aria-label='Satellite'], [data-testid='satellite'], [title='Satellite']").First;




    public ILocator OwnerAddressCityNew => _page.Locator("[id='owner.address.city']");

    public ILocator OwnerAddressLine2 => _page.Locator("[id = 'owner.address.line2']");

    public ILocator OwnerAddressZip => _page.Locator("[id='owner.address.zip']");



    public ILocator YesAtLeast90Days => _page.Locator("[data-testid='owner.address.resided90days-chip-wrapper']").Filter(new() { HasText = "Yes" });

    public ILocator YesClientResides => _page.Locator("[data-testid='owner.address.useAsResidence-chip-wrapper']").Filter(new() { HasText = "Yes" });
}
