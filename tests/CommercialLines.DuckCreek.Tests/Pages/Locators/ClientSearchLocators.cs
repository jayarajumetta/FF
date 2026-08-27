using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class ClientSearchLocators
{
    private readonly IPage _page;
    public ClientSearchLocators(IPage page) => _page = page;

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Add Named Insured - Individual | guid=3a13d49c-16f1-4f69-cb99-81b0970b6380 | strategy=role-link
    public ILocator AddNamedInsuredIndividual => _page.GetByRole(AriaRole.Link, new() { Name = "Add Named Insured - Individual", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Additional Insured First Name | guid=3a13d49c-16f1-9b9f-08a6-3089ffb4a297 | strategy=retained-semantic
    public ILocator AdditionalInsuredFirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Insured First Name", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Additional Insured Middle Name | guid=3a13d49c-16f1-6e18-939b-0e26fb2999a9 | strategy=retained-semantic
    public ILocator AdditionalInsuredMiddleName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Insured Middle Name", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator AdditionalNamedInsured => _page.GetByRole(AriaRole.Link, new() { Name = "Additional Named Insured", Exact = true });

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=97
    // v57 raw Tosca: Client|Additional Named Insured|Common | Additional Named Insured Heading | guid=3a13d49c-16f1-3663-5cde-e8757652fde6 | strategy=id
    public ILocator AdditionalNamedInsuredHeading => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v57 raw Tosca: Endorsement - CM 66 01 Exclude Named Customer | Address | guid=3a13d49c-172d-b5bb-ae1c-348164b75bbb | strategy=id
    public ILocator Address17A1FB => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-b5bb-ae1c-348164b75bbb");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Address 1* | guid=3a13d49c-16f1-460b-bb79-8b413bd0e32f | strategy=retained-semantic
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
    // v57 raw Tosca:  | Add Client | guid=3a13d49c-1679-21d3-307d-9ac2d420ffb8 | strategy=role-link
    public ILocator Client070F4 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    // v57 raw Tosca:  | Add Client | guid=3a13d49c-1679-21d3-307d-9ac2d420ffb8 | strategy=canonical-alias
    public ILocator Client35F85 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    // v57 raw Tosca: Client|Additional Named Insured|Common | Client Search | guid=3a13d49c-16f1-838c-840a-cc5117302527 | strategy=role-link
    public ILocator ClientSearch2CB16 => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearch41F28 => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    public ILocator ClientSearchCA696 => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    // Source modules: Client Search Results | confidence=High score=125
    // Cardinality has been set on this field to allow the addition of a "WaitOn" action.
    public ILocator ClientSearchFDC36 => _page.GetByRole(AriaRole.Link, new() { Name = "Client Search", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | Complete | guid=3a13d49c-1679-c9b8-aded-f0011c3cd6eb | strategy=role-link
    public ILocator Complete => _page.GetByRole(AriaRole.Link, new() { Name = "Complete", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator DOB => _page.GetByRole(AriaRole.Textbox, new() { Name = "DOB", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | Date Of Birth* | guid=3a13d49c-16f1-5235-6ac4-b01a5f07f090 | strategy=id
    public ILocator DateOfBirth338D7 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-5235-6ac4-b01a5f07f090");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Date Of Birth* | guid=3a13d49c-16f1-4506-c834-18430c0075f4 | strategy=retained-semantic
    public ILocator DateOfBirthEA1C4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Date Of Birth*", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=Medium score=113
    // v57 raw Tosca:  | Detail | guid=3a13d49c-1700-371e-c808-c1dcd0cae17d | strategy=role-link
    public ILocator Detail6D228 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Detail | guid=3a13d49c-16f1-71c9-b23c-6b7edaee8edb | strategy=role-link
    public ILocator Detail704E6 => _page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v57 raw Tosca:  | Enter SSN* | guid=3a13d49c-1679-7765-9913-2cfd88461bb0 | strategy=retained-semantic
    public ILocator EnterSSN6B3FB => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Enter SSN* | guid=3a13d49c-16f1-f10e-7389-ca80e61b6e9f | strategy=retained-semantic
    public ILocator EnterSSNE3801 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN*", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator EnterSSNFA186 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter SSN*", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v57 raw Tosca: Insurance Designee | Entity Type | guid=3a13d49c-171e-9383-29ce-b44544c7109d | strategy=retained-semantic
    public ILocator EntityType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Entity Type", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v57 raw Tosca:  | First Name* | guid=3a13d49c-16f1-7104-229a-892e18f1a07f | strategy=id
    public ILocator FirstName55A0B => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7104-229a-892e18f1a07f");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | First Name* | guid=3a13d49c-16f1-7104-229a-892e18f1a07f | strategy=canonical-alias
    public ILocator FirstNameC5387 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-7104-229a-892e18f1a07f");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v57 raw Tosca:  | Gender | guid=3a13d49c-1679-e18a-bc86-17a6e28c5c14 | strategy=retained-semantic
    public ILocator Gender1DC4A => _page.GetByRole(AriaRole.Textbox, new() { Name = "Gender", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Gender4973C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Gender", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | OK | guid=3a13d49c-16f1-f85f-64d6-0c78648a1d2d | strategy=role-link
    public ILocator IndividualOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | IndividualType | guid=3a13d49c-1679-a316-96ce-ca532c48906e | strategy=retained-semantic
    public ILocator IndividualType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-a316-96ce-ca532c48906e");

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator InsuredEMailAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured E-mail Address*", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v57 raw Tosca:  | Insured Type* | guid=3a13d49c-1679-fa35-fde2-a6f6475ff53f | strategy=retained-semantic
    public ILocator InsuredType => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-fa35-fde2-a6f6475ff53f");

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // The JavaScript code to execute. Use a return statement in the code to specify the return value.
    public ILocator JavaScript => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "JavaScript");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v57 raw Tosca:  | Last Name* | guid=3a13d49c-16f1-fd52-8a69-a72f6ca273e5 | strategy=id
    public ILocator LastName => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-fd52-8a69-a72f6ca273e5");

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    // v57 raw Tosca:  | MiddleName | guid=3a13d49c-1679-aaf7-cfe8-7a995fe9d098 | strategy=retained-semantic
    public ILocator MiddleName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Middle Name", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=95
    public ILocator NameOfAuditContact => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name of Audit contact", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator NameOfInspectionContact => _page.GetByRole(AriaRole.Textbox, new() { Name = "Name of Inspection contact", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator OK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    // v57 raw Tosca:  | Order SSN | guid=3a13d49c-1679-3fed-4745-ae3e295be008 | strategy=role-link
    public ILocator OrderSSN5E031 => _page.GetByRole(AriaRole.Link, new() { Name = "Order SSN", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator OrderSSN68C87 => _page.GetByRole(AriaRole.Link, new() { Name = "Order SSN", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Order SSN | guid=3a13d49c-16f1-477a-1ad3-70d959c7f14a | strategy=role-link
    public ILocator OrderSSN710BF => _page.GetByRole(AriaRole.Link, new() { Name = "Order SSN", Exact = true });

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
    public ILocator Result => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Result");

    // Source modules: Client|Additional Named Insured|Common | confidence=High score=125
    // v57 raw Tosca: Client|Additional Named Insured|Common | Return to Client | guid=3a13d49c-16f1-ed64-263f-9cc7526def3c | strategy=role-link
    public ILocator ReturnToClient => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Client", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SSNWasNotReturned => _page.GetByText("SSN was not returned*", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SearchResultsDuckCreekPolicyFirstCheckbox => _page.GetByText("First Checkbox", new() { Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator SocialSecurity => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Social Security #");

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator State => _page.GetByRole(AriaRole.Textbox, new() { Name = "State", Exact = true });

    // Source modules: Verify JavaScript Result | confidence=Review score=97
    // Defines the caption of the browser window that is searched for.
    public ILocator Title => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Title");

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator UnderwritingInfo => _page.GetByRole(AriaRole.Link, new() { Name = "Underwriting Info", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Verify | guid=3a13d49c-16f1-4f72-3c04-be78d47d96de | strategy=role-link
    public ILocator Verify34721 => _page.GetByRole(AriaRole.Link, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator Verify7A388 => _page.GetByRole(AriaRole.Link, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Named Insured|Individual | confidence=High score=125
    // Only applicable to individual
    public ILocator Verify8CDBE => _page.GetByRole(AriaRole.Link, new() { Name = "Verify", Exact = true });

    // Source modules: Client|Other Insured Info | confidence=High score=125
    public ILocator WebsiteAddress => _page.GetByRole(AriaRole.Textbox, new() { Name = "Website Address", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // Not Displayed for BAP, BOP, CPP, CP, CR, IM, SUMB (JULY-20)
    public ILocator YearsInBusiness => _page.GetByRole(AriaRole.Textbox, new() { Name = "Years In Business", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=125
    // v57 raw Tosca:  | Zip Code | guid=3a13d49c-16f1-b514-9d70-426524d6f8fc | strategy=retained-semantic
    public ILocator ZipCode26D22 => _page.GetByRole(AriaRole.Textbox, new() { Name = "ZipCode", Exact = true });

    // Source modules: Client|Add Associated Client | confidence=High score=125
    public ILocator ZipCodeA088E => _page.GetByRole(AriaRole.Textbox, new() { Name = "ZipCode", Exact = true });

    // Source modules: Client|Additional Insured|Individual | confidence=High score=125
    // v57 raw Tosca: Client|Additional Insured|Individual | Zip code* | guid=3a13d49c-16f1-d3ae-ccd1-adab2b580302 | strategy=retained-semantic
    public ILocator ZipCodeD2A54 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Zip code*", Exact = true });


    /// <summary>Source: Client|Named Insured|Common | Field: Primary Phone | Description: </summary>
    public ILocator PrimaryPhone => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Primary Phone");


    /// <summary>Source: Client|Named Insured|Business | Field: FEIN | Description: </summary>
    // v57 raw Tosca:  | FEIN* | guid=3a13d49c-1679-bce5-0470-cd95818f25b1 | strategy=associatedlabel-no-duckcreek
    public ILocator FEIN => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "FEIN*");


    /// <summary>Source: Client|Other Insured Info | Field: Audit Telephone # | Description: </summary>
    public ILocator AuditTelephone => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Audit Telephone #");


    /// <summary>Source: Client|Other Insured Info | Field: Inspection Telephone # | Description: </summary>
    public ILocator InspectionTelephone => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Inspection Telephone #");

}
