using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Main | Add Coverage Form | guid=3a13d49c-172d-e6d1-13bd-997e7f292085 | strategy=role-link
    public ILocator AddCoverageForm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-e6d1-13bd-997e7f292085");

    // Source modules: Endorsements|Main | confidence=High score=125
    // v57 raw Tosca: Endorsements|Main | Add Endorsement | guid=3a13d49c-1700-5aa5-ccad-be01b1072c20 | strategy=role-link
    public ILocator AddEndorsement => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-5aa5-ccad-be01b1072c20");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=124
    // v57 raw Tosca: Policy Covg - Accounts Receivable | Away From Premises Desc | guid=3a13d49c-172d-5425-b44e-9fa1acefecdb | strategy=fieldref
    public ILocator AwayFromPremisesDesc => _page.Locator("[fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"], [data-fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"]");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Accounts Receivable | Away From Premises Lmt | guid=3a13d49c-172d-e0c2-ae18-0f0c964c7b53 | strategy=id
    public ILocator AwayFromPremisesLmt => _page.Locator("[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D6A_3_5-inputEl\"]");

    // Source modules: [CG3132] Limited Fungi or Bacteria Coverage | confidence=High score=125
    // v57 raw Tosca: [CG3132] Limited Fungi or Bacteria Coverage | OK | guid=3a13d49c-172d-039b-e597-c622fc32f90a | strategy=role-link
    public ILocator CG3132LimitedFungiOrBacteriaCoverageOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Accounts Receivable | Coinsurance* | guid=3a13d49c-172d-8f48-ed0a-247f056520af | strategy=id
    public ILocator Coinsurance => _page.Locator("[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D66_3_5-inputEl\"]");

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Main | Coverage Form To Be Added | guid=3a13d49c-172d-eb63-48b6-c4fba029f2b7 | strategy=id
    public ILocator CoverageFormToBeAdded => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-eb63-48b6-c4fba029f2b7");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    // v57 raw Tosca: Policy Covg - Accounts Receivable | Description* | guid=3a13d49c-172d-ff77-691d-f3091a1ed800 | strategy=id
    public ILocator Description => _page.Locator("[id=\"f_i3309D0502687408F8270F5B734F24EBAD62_3_5-inputEl\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules:  | confidence=High score=125
    // v57 raw Tosca:  | Detail | guid=3a13d49c-1700-371e-c808-c1dcd0cae17d | strategy=role-link
    public ILocator Detail => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    // Source modules: [CG3132] Limited Fungi or Bacteria Coverage | confidence=High score=125
    // v57 raw Tosca: [CG3132] Limited Fungi or Bacteria Coverage | Endorsement Type | guid=3a13d49c-172d-fa80-baa7-a86f588d67c5 | strategy=retained-semantic
    public ILocator EndorsementType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: GL Navigation Links | Endorsements | guid=3a13d49c-16f1-6ee5-b6f2-1ec6da80521a | strategy=role-link
    public ILocator Endorsements7572E => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-6ee5-b6f2-1ec6da80521a");

    // Source modules: Endorsements|Main | confidence=High score=127
    // v57 raw Tosca: Endorsements|Main | Endorsements | guid=3a13d49c-1700-454b-5278-9f3e549fbf37 | strategy=id
    public ILocator Endorsements9626E => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-454b-5278-9f3e549fbf37");

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // v57 raw Tosca: Policy Info|CPP Specific Fields | Estimated Premium* | guid=3a13d49c-1697-6858-06c4-d9056b6e4a92 | strategy=id
    public ILocator EstimatedPremium => _page.Locator("[id=\"f_p07E26D4A848C4BFA8EEDAFE9836C87FA4AA_3_1-inputEl\"]");

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FG0055TableRowFG0055 => _page.GetByText("FG0055", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Fungus | guid=3a13d49c-1700-29af-3cfc-9ee090aef41a | strategy=retained-semantic
    public ILocator Fungus => _page.GetByRole(AriaRole.Textbox, new() { Name = "Fungus", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v57 raw Tosca: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | Has the insured ever had a claim for Employment Practices?* | guid=3a13d49c-1700-e8fc-b83f-ed362d327c49 | strategy=id
    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521ACF_3_26-inputEl\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v57 raw Tosca: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | Limit/Deductible* | guid=3a13d49c-1700-ab34-3fd7-9dceee960046 | strategy=id
    public ILocator LimitDeductible => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521ACC_3_26-inputEl\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v57 raw Tosca: Policy Covg | Policy Coverage | guid=3a13d49c-1700-a40c-c2ed-23568e3d05ec | strategy=retained-semantic
    public ILocator PolicyCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Coverage", Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    public ILocator PolicyCovgAccountsReceivableOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: IM Navigation Links | Policy Covg | guid=3a13d49c-172d-a4c5-1221-65f506afd5b8 | strategy=role-link
    public ILocator PolicyCovgED95C => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a4c5-1221-65f506afd5b8");

    // Source modules: Policy Covg - Main | confidence=High score=127
    // v57 raw Tosca: Policy Covg - Main | Policy Covg | guid=3a13d49c-172d-9338-df10-a309c3e3c058 | strategy=id
    public ILocator PolicyCovgF9E58 => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9338-df10-a309c3e3c058");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Info Header");

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Property Extension Endorsements | guid=3a13d49c-1700-2954-fda0-9fe1a17052d3 | strategy=retained-semantic
    public ILocator PropertyExtensionEndorsements => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property Extension Endorsements", Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v57 raw Tosca: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | The insured and any executive, officer or owner has knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?* | guid=3a13d49c-1700-feb9-a727-6393166a6156 | strategy=id
    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521AD0_3_26-inputEl\"]");

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v57 raw Tosca: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | Third Party* | guid=3a13d49c-1700-66f2-0aed-0010ce272ee9 | strategy=id
    public ILocator ThirdParty => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521AD1_3_26-inputEl\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // v57 raw Tosca: Policy Covg | Utility Services | guid=3a13d49c-1700-f773-4476-5f31dc6a0761 | strategy=retained-semantic
    public ILocator UtilityServices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Utility Services", Exact = true });

}
