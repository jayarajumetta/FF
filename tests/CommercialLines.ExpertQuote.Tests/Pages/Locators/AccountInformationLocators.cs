using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class AccountInformationLocators
{
    private readonly IPage _page;
    public AccountInformationLocators(IPage page) => _page = page;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AccountInformation => _page.GetByRole(AriaRole.Heading, new() { Name = "Account Information", Exact = true }); 

    // Source modules: EQ|Common|Account Details - Account Info | confidence=Medium score=78
    public ILocator AccountInformationHeader => _page.GetByRole(AriaRole.Heading, new() { Name = "Account Owner", Exact = true });

    // Source modules: EQ|BOP|Additional Interests | confidence=Medium score=113
    public ILocator AdditionalInterestsNext => _page.GetByTestId("next");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator Address2 => _page.Locator("#owner\\.address\\.line2");

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator City => _page.Locator("#owner\\.address\\.city");

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=130
    public ILocator HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes => _page.GetByTestId("owner.address.resided90days").GetByText("Yes", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=130
    public ILocator IsTheAccountAddressAlsoWhereTheClientResidesYes => _page.GetByTestId("owner.address.useAsResidence").GetByText("Yes", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=Medium score=113
    public ILocator Map => _page.GetByRole(AriaRole.Button, new() { Name = "Map", Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=130
    public ILocator Married => _page.GetByTestId("owner.maritalStatus").GetByText("Married", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=127
    public ILocator OwnerMiddleName => _page.Locator("#owner\\.name\\.middle");

    // Source modules: EQ|Common|Account Details - Account Info | confidence=Medium score=113
    public ILocator Satellite => _page.GetByRole(AriaRole.Button, new() { Name = "Satellite", Exact = true });

    // Source modules: EQ|BOP|Billing | confidence=High score=127
    public ILocator State0110E => _page.Locator("#owner\\.address\\.state");

    // Source modules:  | confidence=Review score=97
    public ILocator StateAE19A => _page.Locator("#owner\\.address\\.state");

    // Source modules: EQ|BOP|Additional Interest Field Entry | confidence=High score=127
    // (BP 04 06);(BP 04 11);(BP 04 48);(BP 04 49);(BP 04 16);(BP 04 02);(BP 04 09);(BP 04 10);(BP 04 50);(BP 04 52);(BP 04 07);(BP 04 47);(BP 12 03);(Mortgagee)
    public ILocator StateDropdown => _page.Locator("#owner\\.address\\.state");

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=127
    public ILocator StreetAddress => _page.Locator("#owner\\.address\\.line1");

    // Source modules:  | confidence=Medium score=78
    public ILocator Yes => _page.GetByTestId("owner.address.resided90days").GetByText("Yes", new() { Exact = true });

    // Source modules: EQ|Common|Account Details - Account Info | confidence=High score=127
    public ILocator Zip => _page.Locator("#owner\\.address\\.zip");


    /// <summary>Source: EQ|Common|Account Details - Account Info | Field: Owner Phone | Description: </summary>
    public ILocator OwnerPhone => _page.Locator("#owner\\.phone");


    /// <summary>Source: EQ|Common|Account Details - Account Info | Field: Owner Email | Description: </summary>
    public ILocator OwnerEmail => _page.Locator("#owner\\.email");

    /// <summary>
    /// Gets a state option from the dropdown by state name
    /// </summary>
    /// <param name="stateText">The state text (e.g., "ALABAMA", "TEXAS")</param>
    public ILocator GetStateOption(string stateText) 
        => _page.GetByRole(AriaRole.Option, new() { Name = stateText, Exact = true });



}
