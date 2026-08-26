using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Add Named Insured - Individual | DuckCreekId
    public ILocator AddNamedInsuredIndividual => _page.Locator("[duckcreekid=\"Add Named Insured - Individual\"], [data-duckcreekid=\"Add Named Insured - Individual\"]");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Additional Insured First Name | DuckCreekId
    public ILocator AdditionalInsuredFirstName => _page.Locator("[duckcreekid=\"AdditionalNamedInsuredInput.FirstName\"], [data-duckcreekid=\"AdditionalNamedInsuredInput.FirstName\"]");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Additional Insured Middle Name | DuckCreekId
    public ILocator AdditionalInsuredMiddleName => _page.Locator("[duckcreekid=\"AdditionalNamedInsuredInput.MiddleName\"], [data-duckcreekid=\"AdditionalNamedInsuredInput.MiddleName\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Client|Additional Named Insured|Common | Additional Named Insured | DuckCreekId
    public ILocator AdditionalNamedInsured => _page.Locator("[duckcreekid=\"Additional Named Insured\"], [data-duckcreekid=\"Additional Named Insured\"]");

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=97
    // v56 raw Tosca primary: Client|Additional Named Insured|Common | Additional Named Insured Heading | Id
    public ILocator AdditionalNamedInsuredHeading => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary: Endorsement - CM 66 01 Exclude Named Customer | Address | Id+Name+DuckCreekId
    public ILocator Address17A1FB => _page.Locator("input[id=\"f_CCE14981F38894A679A407BA735B5959BD3_3_1-inputEl\"][name=\"string_D3|\"][duckcreekid=\"CovEndorsmentIteratorNonShreddedInput.Address\"]");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Address 1* | DuckCreekId | frame=iframe
    public ILocator Address1CB379 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"IndividualNamedInsuredInput.Address1\"], [data-duckcreekid=\"IndividualNamedInsuredInput.Address1\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Address1D319B => Address17A1FB; // semantic alias; locator defined once

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary:  | Address 2 | DuckCreekId | frame=iframe
    public ILocator Address2 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Address2\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Address2\"]");

    // Source modules: Client|Named Insured|Business | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Named Insured|Business | BusinessName | DuckCreekId
    public ILocator BusinessName => _page.Locator("[duckcreekid=\"AdditionalNamedInsuredInput.BusinessName\"], [data-duckcreekid=\"AdditionalNamedInsuredInput.BusinessName\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | City | DuckCreekId | frame=iframe
    public ILocator City => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.City\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.City\"]");

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    // v56 raw Tosca primary:  | Add Client | DuckCreekId | frame=iframe
    public ILocator Client070F4 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Add Client\"], [data-duckcreekid=\"Add Client\"]");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary:  | Add Client | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as Client070F4
    public ILocator Client35F85 => Client070F4;

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Named Insured|Common | Client Search | DuckCreekId | frame=iframe
    public ILocator ClientSearch2CB16 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Client Search\"], [data-duckcreekid=\"Client Search\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearch41F28 => ClientSearch2CB16; // semantic alias; locator defined once

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    public ILocator ClientSearchCA696 => ClientSearch2CB16; // semantic alias; locator defined once

    // Source modules: Client Search Results | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearchFDC36 => ClientSearch2CB16; // semantic alias; locator defined once

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | Complete | DuckCreekId | frame=iframe
    public ILocator Complete => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Complete\"], [data-duckcreekid=\"Complete\"]");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator DOB => _page.GetByRole(AriaRole.Textbox, new() { Name = "DOB", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | Date Of Birth* | Id+Name+DuckCreekId | frame=iframe
    public ILocator DateOfBirth338D7 => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CF_1_1-inputEl\"][name=\"date_10CF|mm-dd-yyyy\"][duckcreekid=\"DriverUnderwritingInformationInput.DateOfBirth\"]");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Date Of Birth* | DuckCreekId | frame=iframe
    public ILocator DateOfBirthEA1C4 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"IndividualNamedInsuredInput.DateOfBirth\"], [data-duckcreekid=\"IndividualNamedInsuredInput.DateOfBirth\"]");

    // Source modules: Client|Add Associated Client | confidence=Medium score=113
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    public ILocator Detail6D228 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Detail\"], [data-duckcreekid=\"Detail\"]");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Detail | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as Detail6D228
    public ILocator Detail704E6 => Detail6D228;

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v56 raw Tosca primary:  | Enter SSN* | DuckCreekId | frame=iframe
    public ILocator EnterSSN6B3FB => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientSSNRetrievalInput.SSNInput\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientSSNRetrievalInput.SSNInput\"]");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Enter SSN* | DuckCreekId | frame=iframe
    public ILocator EnterSSNE3801 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"IndividualNamedInsuredSSNRetrievalInput.SSNInput\"], [data-duckcreekid=\"IndividualNamedInsuredSSNRetrievalInput.SSNInput\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator EnterSSNFA186 => EnterSSNE3801; // semantic alias; locator defined once

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary: Insurance Designee | Entity Type | DuckCreekId
    public ILocator EntityType => _page.Locator("[duckcreekid=\"SFPInsuranceScoreDesigneeInput.EntityType\"], [data-duckcreekid=\"SFPInsuranceScoreDesigneeInput.EntityType\"]");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v56 raw Tosca primary:  | First Name* | Id+Name+DuckCreekId | frame=iframe
    public ILocator FirstName55A0B => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010C8_1_1-inputEl\"][name=\"string_10C8|\"][duckcreekid=\"DriverUnderwritingInformationInput.Name\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | First Name* | Id+Name+DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as FirstName55A0B
    public ILocator FirstNameC5387 => FirstName55A0B;

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v56 raw Tosca primary:  | Gender | DuckCreekId | frame=iframe
    public ILocator Gender1DC4A => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.Gender\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.Gender\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Gender4973C => Gender1DC4A; // semantic alias; locator defined once

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | OK | DuckCreekId | frame=iframe
    public ILocator IndividualOK => _page.FrameLocator("iframe").Locator("[duckcreekid=\"OK\"], [data-duckcreekid=\"OK\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | IndividualType | DuckCreekId | frame=iframe
    public ILocator IndividualType => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.IndividualType\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.IndividualType\"]");

    // Source modules: Client|Other Insured Info | confidence=High score=125
    // v56 raw Tosca primary:  | E-Mail | DuckCreekId | frame=iframe
    public ILocator InsuredEMailAddress => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.Email\"], [data-duckcreekid=\"AdditionalOtherInterestInput.Email\"]");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary:  | Insured Type* | DuckCreekId | frame=iframe
    public ILocator InsuredType => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.InsuredType\"], [data-duckcreekid=\"AdditionalOtherInterestInput.InsuredType\"]");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => _page.GetByLabel("JavaScript", new() { Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v56 raw Tosca primary:  | Last Name* | Id+Name+DuckCreekId | frame=iframe
    public ILocator LastName => _page.FrameLocator("iframe").Locator("input[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CA_1_1-inputEl\"][name=\"string_10CA|\"][duckcreekid=\"DriverUnderwritingInformationInput.LastName\"]");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v56 raw Tosca primary:  | MiddleName | DuckCreekId | frame=iframe
    public ILocator MiddleName => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.MiddleName\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.MiddleName\"]");

    // Source modules: Client|Other Insured Info | confidence=High score=95
    public ILocator NameOfAuditContact => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name of Audit contact", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator NameOfInspectionContact => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name of Inspection contact", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => IndividualOK; // semantic alias; locator defined once

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v56 raw Tosca primary:  | Order SSN | DuckCreekId | frame=iframe
    public ILocator OrderSSN5E031 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Order SSN\"], [data-duckcreekid=\"Order SSN\"]");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator OrderSSN68C87 => OrderSSN5E031; // semantic alias; locator defined once

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    public ILocator OrderSSN710BF => OrderSSN5E031; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Verify | DuckCreekId | frame=iframe
    public ILocator PleaseVerifySSN3EAB9 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Verify\"], [data-duckcreekid=\"Verify\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PleaseVerifySSN8D55B => PleaseVerifySSN3EAB9; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PleaseVerifySSNF738A => PleaseVerifySSN3EAB9; // semantic alias; locator defined once

    // Source modules: Client|Named Insured|Common | confidence=Medium score=113
    public ILocator QuickQuote => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Quick Quote", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The string result to verify
    public ILocator Result => _page.GetByLabel("Result", new() { Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Named Insured|Common | Return to Client | DuckCreekId
    public ILocator ReturnToClient => _page.Locator("[duckcreekid=\"Return to Client\"], [data-duckcreekid=\"Return to Client\"]");

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
    // v56 raw Tosca primary:  | State | DuckCreekId | frame=iframe
    public ILocator State => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.State\"], [data-duckcreekid=\"AdditionalOtherInterestAssociatedClientInput.State\"]");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => _page.GetByLabel("Title", new() { Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Verify | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as PleaseVerifySSN3EAB9
    public ILocator Verify34721 => PleaseVerifySSN3EAB9;

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Verify7A388 => Verify34721; // semantic alias; locator defined once

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator Verify8CDBE => Verify34721; // semantic alias; locator defined once

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator WebsiteAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Website Address", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Not Displayed for BAP, BOP, CPP, CP, CR, IM, SUMB (JULY-20)
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v56 raw Tosca primary:  | Zip Code | DuckCreekId | frame=iframe
    public ILocator ZipCode26D22 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.ZipCode\"], [data-duckcreekid=\"AdditionalOtherInterestInput.ZipCode\"]");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator ZipCodeA088E => ZipCode26D22; // semantic alias; locator defined once

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v56 raw Tosca primary: Client|Additional Insured|Individual | Zip code* | DuckCreekId | frame=iframe
    public ILocator ZipCodeD2A54 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"IndividualNamedInsuredInput.ZipCode\"], [data-duckcreekid=\"IndividualNamedInsuredInput.ZipCode\"]");


    /// <summary>Source: Client|Named Insured|Common | Field: Primary Phone | Description: </summary>
    public ILocator PrimaryPhone => _page.Locator("[id=\"AccountInput.PrimaryPhone\"], [name=\"AccountInput.PrimaryPhone\"], [data-testid=\"AccountInput.PrimaryPhone\"], [data-duckcreekid=\"AccountInput.PrimaryPhone\"], [data-duck-creek-id=\"AccountInput.PrimaryPhone\"]").First;


    /// <summary>Source: Client|Named Insured|Business | Field: FEIN | Description: </summary>
    // v56 raw Tosca primary:  | FEIN* | DuckCreekId | frame=iframe
    public ILocator FEIN => _page.FrameLocator("iframe").Locator("[duckcreekid=\"AdditionalOtherInterestInput.FEIN\"], [data-duckcreekid=\"AdditionalOtherInterestInput.FEIN\"]");


    /// <summary>Source: Client|Other Insured Info | Field: Audit Telephone # | Description: </summary>
    public ILocator AuditTelephone => _page.Locator("[id=\"AccountInput.AuditContactPhone\"], [name=\"AccountInput.AuditContactPhone\"], [data-testid=\"AccountInput.AuditContactPhone\"], [data-duckcreekid=\"AccountInput.AuditContactPhone\"], [data-duck-creek-id=\"AccountInput.AuditContactPhone\"]").First;


    /// <summary>Source: Client|Other Insured Info | Field: Inspection Telephone # | Description: </summary>
    public ILocator InspectionTelephone => _page.Locator("[id=\"AccountInput.InspectionContactPhone\"], [name=\"AccountInput.InspectionContactPhone\"], [data-testid=\"AccountInput.InspectionContactPhone\"], [data-duckcreekid=\"AccountInput.InspectionContactPhone\"], [data-duck-creek-id=\"AccountInput.InspectionContactPhone\"]").First;

}
