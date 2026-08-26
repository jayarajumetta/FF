using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Main | Add Coverage Form | DuckCreekId
    public ILocator AddCoverageForm => _page.Locator("[duckcreekid=\"Add Coverage Form\"], [data-duckcreekid=\"Add Coverage Form\"]");

    // Source modules: Endorsements|Main | confidence=High score=125
    // v56 raw Tosca primary: Endorsements|Main | Add Endorsement | DuckCreekId
    public ILocator AddEndorsement => _page.Locator("[duckcreekid=\"Add Endorsement\"], [data-duckcreekid=\"Add Endorsement\"]");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg - Accounts Receivable | Away From Premises Desc | attributes_fieldref
    public ILocator AwayFromPremisesDesc => _page.Locator("[fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"], [data-fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"]");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Accounts Receivable | Away From Premises Lmt | Id+Name+DuckCreekId
    public ILocator AwayFromPremisesLmt => _page.Locator("input[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D6A_3_5-inputEl\"][name=\"int_D6A\"][duckcreekid=\"AccountsReceivableInput.OffPremisesLimit\"]");

    // Source modules: [CG3132] Limited Fungi or Bacteria Coverage | confidence=High score=125
    // v56 raw Tosca primary: [CG3132] Limited Fungi or Bacteria Coverage | OK | DuckCreekId | frame=iframe
    public ILocator CG3132LimitedFungiOrBacteriaCoverageOK => _page.FrameLocator("iframe").Locator("[duckcreekid=\"OK\"], [data-duckcreekid=\"OK\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Accounts Receivable | Coinsurance* | Id+Name+DuckCreekId
    public ILocator Coinsurance => _page.Locator("input[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D66_3_5-inputEl\"][name=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D66_3_5-inputEl\"][duckcreekid=\"AccountsReceivableInput.Coinsurance\"]");

    // Source modules: Policy Covg - Main | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Main | Coverage Form To Be Added | Id+Name+DuckCreekId
    public ILocator CoverageFormToBeAdded => _page.Locator("input[id=\"f_l1A9C547373A24FF38DA9C54C82FB349811CE_3_1-inputEl\"][name=\"f_l1A9C547373A24FF38DA9C54C82FB349811CE_3_1-inputEl\"][duckcreekid=\"LineInput.CoverageForm\"]");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg - Accounts Receivable | Description* | Id+Name+DuckCreekId
    public ILocator Description => _page.Locator("input[id=\"f_i3309D0502687408F8270F5B734F24EBAD62_3_5-inputEl\"][name=\"string_D62|\"][duckcreekid=\"CoverageFormsInput.Description\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules:  | confidence=High score=125
    // v56 raw Tosca primary: BOP Expanded Addl Insured | Detail | DuckCreekId | frame=iframe
    public ILocator Detail => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Detail\"], [data-duckcreekid=\"Detail\"]");

    // Source modules: [CG3132] Limited Fungi or Bacteria Coverage | confidence=High score=125
    // v56 raw Tosca primary: [CG3132] Limited Fungi or Bacteria Coverage | Endorsement Type | DuckCreekId
    public ILocator EndorsementType => _page.Locator("[duckcreekid=\"CovEndorsementsInput.Type\"], [data-duckcreekid=\"CovEndorsementsInput.Type\"]");

    // Source modules: GL Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Endorsements|Main | Endorsements | Id
    public ILocator Endorsements7572E => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Endorsements|Main | confidence=High score=127
    // v56 raw Tosca primary: Endorsements|Main | Endorsements | Id
    // v56 semantic alias: same physical raw-Tosca control as Endorsements7572E
    public ILocator Endorsements9626E => Endorsements7572E;

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    // v56 raw Tosca primary: Policy Info|CPP Specific Fields | Estimated Premium* | Id+Name+DuckCreekId
    public ILocator EstimatedPremium => _page.Locator("input[id=\"f_p07E26D4A848C4BFA8EEDAFE9836C87FA4AA_3_1-inputEl\"][name=\"f_p07E26D4A848C4BFA8EEDAFE9836C87FA4AA_3_1-inputEl\"][duckcreekid=\"PolicyInput.EstimatedPremium\"]");

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK => CG3132LimitedFungiOrBacteriaCoverageOK; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FG0055TableRowFG0055 => _page.GetByText("FG0055", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Fungus | DuckCreekId
    public ILocator Fungus => _page.Locator("[duckcreekid=\"CovFungusInput.Indicator\"], [data-duckcreekid=\"CovFungusInput.Indicator\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v56 raw Tosca primary: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | Has the insured ever had a claim for Employment Practices?* | Id+Name+DuckCreekId
    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.Locator("input[id=\"f_c413F524BDA03486A8D2A269F802883521ACF_3_26-inputEl\"][name=\"f_c413F524BDA03486A8D2A269F802883521ACF_3_26-inputEl\"][duckcreekid=\"CovEndorsementsInput.EPLIClaim\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v56 raw Tosca primary: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | Limit/Deductible* | Id+Name+DuckCreekId
    public ILocator LimitDeductible => _page.Locator("input[id=\"f_c413F524BDA03486A8D2A269F802883521ACC_3_26-inputEl\"][name=\"f_c413F524BDA03486A8D2A269F802883521ACC_3_26-inputEl\"][duckcreekid=\"CovEndorsementsInput.EPLILimitDeductible\"]");

    // Source modules: Policy Covg | confidence=High score=125
    // v56 raw Tosca primary: Policy Covg | Policy Coverage | DuckCreekId
    public ILocator PolicyCoverage => _page.Locator("[duckcreekid=\"PropertyPolicyInput.PolicyCoverage\"], [data-duckcreekid=\"PropertyPolicyInput.PolicyCoverage\"]");

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    public ILocator PolicyCovgAccountsReceivableOK => CG3132LimitedFungiOrBacteriaCoverageOK; // semantic alias; locator defined once

    // Source modules: IM Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: Policy Covg | Policy Covg | Id
    public ILocator PolicyCovgED95C => _page.Locator("[id=\"pageTop\"]");

    // Source modules: Policy Covg - Main | confidence=High score=127
    // v56 raw Tosca primary: Policy Covg - Main | Policy Covg | Id
    // v56 semantic alias: same physical raw-Tosca control as Endorsements7572E
    public ILocator PolicyCovgF9E58 => Endorsements7572E;

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => _page.GetByLabel("Policy Info Header", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Property Extension Endorsements | DuckCreekId
    public ILocator PropertyExtensionEndorsements => _page.Locator("[duckcreekid=\"CovExtensionEndorsementsInput.PropertyExtensionEndorsements\"], [data-duckcreekid=\"CovExtensionEndorsementsInput.PropertyExtensionEndorsements\"]");

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v56 raw Tosca primary: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | The insured and any executive, officer or owner has knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?* | Id+Name+DuckCreekId
    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("input[id=\"f_c413F524BDA03486A8D2A269F802883521AD0_3_26-inputEl\"][name=\"f_c413F524BDA03486A8D2A269F802883521AD0_3_26-inputEl\"][duckcreekid=\"CovEndorsementsInput.EPLIClaimInfo\"]");

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    // v56 raw Tosca primary: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | Third Party* | Id+Name+DuckCreekId
    public ILocator ThirdParty => _page.Locator("input[id=\"f_c413F524BDA03486A8D2A269F802883521AD1_3_26-inputEl\"][name=\"f_c413F524BDA03486A8D2A269F802883521AD1_3_26-inputEl\"][duckcreekid=\"CovEndorsementsInput.EPLIThirdParty\"]");

    // Source modules: Policy Covg | confidence=High score=95
    // v56 raw Tosca primary: Policy Covg | Utility Services | DuckCreekId
    public ILocator UtilityServices => _page.Locator("[duckcreekid=\"CovUtilityServicesInput.Indicator\"], [data-duckcreekid=\"CovUtilityServicesInput.Indicator\"]");

}
