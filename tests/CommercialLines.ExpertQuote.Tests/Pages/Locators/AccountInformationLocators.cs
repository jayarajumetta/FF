using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AccountInformation => _page.GetByText("Account Information", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=Medium score=78
    public ILocator AccountInformationHeader => _page.GetByLabel("Account Information Header", new() { Exact = true });

    // Source modules: EQ|BOP|Additional Interests | confidence=Medium score=113
    public ILocator AdditionalInterestsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator Address2 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address2", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City", Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=130
    public ILocator HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes => _page.GetByTestId("owner.address.resided90days-chip-wrapper");

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=130
    public ILocator IsTheAccountAddressAlsoWhereTheClientResidesYes => _page.GetByTestId("owner.address.useAsResidence-chip-wrapper");

    // Source modules: EQ|Common|Account Details - Account Info | confidence=Medium score=113
    public ILocator Map => _page.GetByRole(AriaRole.Button, new() { Name = "Map", Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=130
    public ILocator Married => _page.GetByTestId("owner.maritalStatus-chip-wrapper");

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=127
    public ILocator OwnerMiddleName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Owner Middle Name", Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=Medium score=113
    public ILocator Satellite => _page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator State0110E => _page.GetByRole(AriaRole.Combobox, new() { Name = "State", Exact = true });

    // Source modules:  | confidence=Review score=97
    public ILocator StateAE19A => _page.GetByLabel("State", new() { Exact = true });

    // Source modules: EQ|BOP|Additional Interest Field Entry | confidence=High score=127
    // (BP 04 06);(BP 04 11);(BP 04 48);(BP 04 49);(BP 04 16);(BP 04 02);(BP 04 09);(BP 04 10);(BP 04 50);(BP 04 52);(BP 04 07);(BP 04 47);(BP 12 03);(Mortgagee)
    public ILocator StateDropdown => _page.GetByLabel("State Dropdown", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=127
    public ILocator StreetAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Street Address", Exact = true });

    // Source modules:  | confidence=Medium score=78
    public ILocator Yes => _page.GetByLabel("Yes", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=127
    public ILocator Zip => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip", Exact = true });

}