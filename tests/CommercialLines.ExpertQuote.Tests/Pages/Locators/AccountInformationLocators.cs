using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    // Source: EQ|Common|Account Details - Account Info
    public ILocator AccountInformation => _page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true });

    public ILocator OwnerMiddleName => _page.Locator("[id='owner.name.middle']");
    public ILocator OwnerPhone => _page.Locator("[id='owner.phone']");
    public ILocator OwnerEmail => _page.Locator("[id='owner.email']");

    // Tosca ModuleAttributes are clickable DIV chip wrappers, not native selects.
    public ILocator Married => _page.Locator("[data-testid='owner.maritalStatus-chip-wrapper']").Filter(new() { HasText = "Married" });
    public ILocator HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes =>
        _page.Locator("[data-testid='owner.address.resided90days-chip-wrapper']").Filter(new() { HasText = "Yes" });
    public ILocator IsTheAccountAddressAlsoWhereTheClientResidesYes =>
        _page.Locator("[data-testid='owner.address.useAsResidence-chip-wrapper']").Filter(new() { HasText = "Yes" });

    public ILocator Map => _page.GetByRole(AriaRole.Button, new() { Name = "Map", Exact = true });
    public ILocator Satellite => _page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });
    public ILocator AdditionalInterestsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator StreetAddress => _page.Locator("[id='owner.address.line1']");
    public ILocator Address2 => _page.Locator("[id='owner.address.line2']");
    public ILocator City => _page.Locator("[id='owner.address.city']");

    // Tosca source: Tag=MAT-SELECT, Id=owner.address.state.
    public ILocator StateDropdown => _page.Locator("[id='owner.address.state']");


    public ILocator Zip => _page.Locator("[id='owner.address.zip']");
    // Raw Tosca: EQ|Common|Account Details - Account Info > County (TextBox)
    public ILocator County => _page.Locator("[id='owner.address.county']");

    public ILocator GetStateOption(string stateText) =>
        _page.GetByRole(AriaRole.Option, new() { Name = stateText, Exact = true });
}
