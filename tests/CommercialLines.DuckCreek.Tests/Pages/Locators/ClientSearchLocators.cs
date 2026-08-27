using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;

    public ClientSearchLocators(IPage page) => _page = page;

    /// <summary>
    /// Helper to get iframe locator for popup dialogs
    /// Duck Creek uses popups with iframes for certain forms: #dctPopupWindow iframe
    /// </summary>
    public IFrameLocator PopupFrame => _page.FrameLocator("#dctPopupWindow iframe");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator AddNamedInsuredIndividual => _page.GetByRole(AriaRole.Button, new() { Name = "Add Named Insured - Individual", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator AdditionalInsuredFirstName => _page.Locator("[fieldref='AdditionalInsured.NameFirst']");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator AdditionalInsuredMiddleName => _page.Locator("[fieldref='AdditionalInsured.NameMiddle']");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator AdditionalNamedInsured => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Named Insured", Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=97
    public ILocator AdditionalNamedInsuredHeading => _page.GetByLabel("Additional Named Insured Heading", new() { Exact = true });

    // Source modules: Client|Named Insured|Common | Client|Add Associated Client
    // Updated: Using fieldref for unique identification
    // Consolidated from: Address1D319B
    public ILocator Address17A1FB => _page.Locator("[fieldref='AccountInput.Address1']");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator Address1CB379 => _page.Locator("[fieldref='AdditionalInsured.Address1']");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator Address2 => _page.Locator("[fieldref='AccountInput.Address2']");

    // Source modules: Client|Named Insured|Business | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator BusinessName => _page.Locator("[fieldref='AccountInput.NameBusiness']");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Updated: Using fieldref for unique identification (may be readonly display field)
    public ILocator City => _page.Locator("[fieldref='AccountInput.City']");

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    public ILocator Client070F4 => _page.GetByLabel("Client", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Client35F85 => _page.GetByRole(AriaRole.Link, new() { Name = "Client", Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    public ILocator ClientSearch2CB16 => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearch41F28 => ClientSearch2CB16; // semantic alias; locator defined once

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    public ILocator ClientSearchCA696 => ClientSearch2CB16; // semantic alias; locator defined once

    // Source modules: Client Search Results | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearchFDC36 => ClientSearch2CB16; // semantic alias; locator defined once

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Complete => _page.GetByRole(AriaRole.Button, new() { Name = "Complete", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // Updated: Using fieldref for unique identification
    public ILocator DOB => _page.Locator("[fieldref='AccountInput.DateOfBirth']");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Consolidated: Alias to DOB (same fieldref)
    public ILocator DateOfBirth338D7 => DOB;

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator DateOfBirthEA1C4 => _page.Locator("[fieldref='AdditionalInsured.DateOfBirth']");

    // Source modules: Client|Add Associated Client | confidence=Medium score=113
    public ILocator Detail6D228 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator Detail704E6 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Client|Named Insured|Individual | Client|Additional Insured|Individual | Client|Add Associated Client
    // Consolidated from: EnterSSNE3801, EnterSSNFA186
    // Updated: Using fieldref for unique identification
    public ILocator EnterSSN6B3FB => _page.Locator("input[fieldref='AccountSSNRetrievalInput.SSNInput']");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Updated: Using fieldref for unique identification (combobox, not textbox)
    public ILocator EntityType => _page.Locator("input[fieldref='AccountInput.EntityType']");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // Updated: Using fieldref for unique identification
    public ILocator FirstName55A0B => _page.Locator("[fieldref='AccountInput.NameFirst']");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Consolidated: Alias to FirstName55A0B (same fieldref)
    public ILocator FirstNameC5387 => FirstName55A0B;

    // Source modules: Client|Named Insured|Individual | Client|Add Associated Client
    // Consolidated from: Gender4973C
    // Updated: Using fieldref for unique identification
    public ILocator Gender1DC4A => _page.Locator("input[fieldref='AccountInput.Gender']");

    // Source modules: Client|Additional Insured|Individual
    public ILocator IndividualOK => _page.FrameLocator("iframe[name^='dctPopup_dctPopupWindow']").GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator IndividualType => _page.Locator("input[fieldref='AccountInput.IndividualType']");

    // Source modules: Client|Other Insured Info | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator InsuredEMailAddress => _page.Locator("[fieldref='AccountInput.Email']");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Updated: Using fieldref for unique identification (combobox, not textbox)
    public ILocator InsuredType => _page.Locator("input[fieldref='AccountInput.InsuredType']");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => _page.GetByLabel("JavaScript", new() { Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // Updated: Using fieldref for unique identification
    public ILocator LastName => _page.Locator("[fieldref='AccountInput.NameLast']");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // Updated: Using fieldref for unique identification
    public ILocator MiddleName => _page.Locator("[fieldref='AccountInput.NameMI']");

    // Source modules: Client|Other Insured Info | confidence=High score=95
    // Updated: Using fieldref for unique identification
    public ILocator NameOfAuditContact => _page.Locator("[fieldref='AccountInput.AuditContact']");

    // Source modules: Client|Other Insured Info | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator NameOfInspectionContact => _page.Locator("[fieldref='AccountInput.InspectionContact']");

    // Source modules: Client|Add Associated Client | Client|Named Insured|Individual | Client|Additional Insured|Individual
    // Consolidated from: OrderSSN68C87, OrderSSN710BF
    public ILocator OrderSSN5E031 => _page.GetByRole(AriaRole.Link, new() { Name = "Order SSN", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Consolidated from: PleaseVerifySSN8D55B, PleaseVerifySSNF738A
    public ILocator PleaseVerifySSN3EAB9 => _page.GetByText("Please verify SSN*", new() { Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=Medium score=113
    public ILocator QuickQuote => _page.Locator("[fieldref='PolicyOutputNonShredded.QuoteQuick']").First;

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => _page.GetByLabel("Result", new() { Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    public ILocator ReturnToClient => _page.GetByRole(AriaRole.Button, new() { Name = "Return to Client", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SSNWasNotReturned => _page.GetByText("SSN was not returned*", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchResultsDuckCreekPolicyFirstCheckbox => _page.GetByText("First Checkbox", new() { Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator SocialSecurity => _page.GetByText("Social Security #", new() { Exact = true });
    public ILocator VerifySocialSecurity => _page.Locator("[fieldref='AccountSSNRetrievalOuput.SSNDisplay']");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Updated: Using fieldref for unique identification (readonly display field in HTML)
    public ILocator State => _page.Locator("[fieldref='AccountInput.State']");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => _page.GetByLabel("Title", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Client|Additional Insured|Individual | Client|Add Associated Client | Client|Named Insured|Individual
    // Consolidated from: Verify7A388, Verify8CDBE
    public ILocator Verify34721 => _page.GetByRole(AriaRole.Link, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator WebsiteAddress => _page.Locator("[fieldref='AccountInput.WebsiteAddress']");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Not Displayed for BAP, BOP, CPP, CP, CR, IM, SUMB (JULY-20)
    // Updated: Using fieldref for unique identification
    public ILocator YearsInBusiness => _page.Locator("[fieldref='AccountInput.YearsInBusiness']");

    // Source modules: Client|Named Insured|Common | Client|Add Associated Client
    // Updated: Using fieldref for unique identification
    // Consolidated from: ZipCodeA088E
    public ILocator ZipCode26D22 => _page.Locator("[fieldref='AccountInput.ZipCode']");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // Updated: Using fieldref for unique identification
    public ILocator ZipCodeD2A54 => _page.Locator("[fieldref='AdditionalInsured.ZipCode']");


    /// <summary>Source: Client|Named Insured|Common | Field: Primary Phone | Description: </summary>
    /// Updated: Simplified to use fieldref selector (was: AccountInput.PrimaryPhone)
    public ILocator PrimaryPhone => _page.Locator("[fieldref='AccountInput.PrimaryPhone']");


    /// <summary>Source: Client|Named Insured|Business | Field: FEIN | Description: </summary>
    /// Updated: Simplified to use fieldref selector
    public ILocator FEIN => _page.Locator("[fieldref='AccountInput.FEIN']");


    /// <summary>Source: Client|Other Insured Info | Field: Audit Telephone # | Description: </summary>
    /// Updated: Simplified to use fieldref selector
    public ILocator AuditTelephone => _page.Locator("[fieldref='AccountInput.AuditContactPhone']");


    /// <summary>Source: Client|Other Insured Info | Field: Inspection Telephone # | Description: </summary>
    /// Updated: Simplified to use fieldref selector (fieldref='AccountInput.InspectionContactPhone' from HTML)
    public ILocator InspectionTelephone => _page.Locator("[fieldref='AccountInput.InspectionContactPhone']");

}
