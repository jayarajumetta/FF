using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator AddNamedInsuredIndividual => _page.GetByRole(AriaRole.Button, new() { Name = "Add Named Insured - Individual", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator AdditionalInsuredFirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Insured First Name", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator AdditionalInsuredMiddleName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Insured Middle Name", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator AdditionalNamedInsured => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Named Insured", Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=97
    public ILocator AdditionalNamedInsuredHeading => _page.GetByLabel("Additional Named Insured Heading", new() { Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    public ILocator Address17A1FB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator Address1CB379 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address 1*", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Address1D319B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address1", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    public ILocator Address2 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Address2", Exact = true });

    // Source modules: Client|Named Insured|Business | confidence=High score=125
    public ILocator BusinessName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Business Name", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator City => _page.GetByRole(AriaRole.Textbox, new() { Name = "City", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    public ILocator Client070F4 => _page.GetByLabel("Client", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator Client35F85 => _page.GetByRole(AriaRole.Link, new() { Name = "Client", Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    public ILocator ClientSearch2CB16 => _page.GetByRole(AriaRole.Button, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearch41F28 => _page.GetByRole(AriaRole.Button, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    public ILocator ClientSearchCA696 => _page.GetByRole(AriaRole.Button, new() { Name = "Client Search", Exact = true });

    // Source modules: Client Search Results | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearchFDC36 => _page.GetByRole(AriaRole.Button, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Complete => _page.GetByRole(AriaRole.Button, new() { Name = "Complete", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator DOB => _page.GetByRole(AriaRole.Textbox, new() { Name = "DOB", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator DateOfBirth338D7 => _page.GetByRole(AriaRole.Textbox, new() { Name = "DateOfBirth", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator DateOfBirthEA1C4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Date Of Birth*", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=Medium score=113
    public ILocator Detail6D228 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator Detail704E6 => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator EnterSSN6B3FB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator EnterSSNE3801 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN*", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator EnterSSNFA186 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN*", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    public ILocator EntityType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Entity Type", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator FirstName55A0B => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator FirstNameC5387 => _page.GetByRole(AriaRole.Textbox, new() { Name = "FirstName", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator Gender1DC4A => _page.GetByRole(AriaRole.Textbox, new() { Name = "Gender", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Gender4973C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Gender", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator IndividualOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator IndividualType => _page.GetByRole(AriaRole.Textbox, new() { Name = "IndividualType", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator InsuredEMailAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured E-mail Address*", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    public ILocator InsuredType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Type", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => _page.GetByLabel("JavaScript", new() { Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator MiddleName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Middle Name", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=95
    public ILocator NameOfAuditContact => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name of Audit contact", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator NameOfInspectionContact => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name of Inspection contact", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator OrderSSN5E031 => _page.GetByRole(AriaRole.Button, new() { Name = "Order SSN", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator OrderSSN68C87 => _page.GetByRole(AriaRole.Button, new() { Name = "Order SSN", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator OrderSSN710BF => _page.GetByRole(AriaRole.Button, new() { Name = "Order SSN", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PleaseVerifySSN3EAB9 => _page.GetByText("Please verify SSN*", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PleaseVerifySSN8D55B => _page.GetByText("Please verify SSN*", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PleaseVerifySSNF738A => _page.GetByText("Please verify SSN*", new() { Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=Medium score=113
    public ILocator QuickQuote => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Quick Quote", Exact = true });

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
    public ILocator SocialSecurity => _page.GetByLabel("Social Security #", new() { Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator State => _page.GetByRole(AriaRole.Textbox, new() { Name = "State", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => _page.GetByLabel("Title", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator Verify34721 => _page.GetByRole(AriaRole.Button, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Verify7A388 => _page.GetByRole(AriaRole.Button, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator Verify8CDBE => _page.GetByRole(AriaRole.Button, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator WebsiteAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Website Address", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Not Displayed for BAP, BOP, CPP, CP, CR, IM, SUMB (JULY-20)
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    public ILocator ZipCode26D22 => _page.GetByRole(AriaRole.Textbox, new() { Name = "ZipCode", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator ZipCodeA088E => _page.GetByRole(AriaRole.Textbox, new() { Name = "ZipCode", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator ZipCodeD2A54 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip code*", Exact = true });

}