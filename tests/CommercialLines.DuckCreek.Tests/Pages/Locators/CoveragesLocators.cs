using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Source modules: Policy Covg - Main | confidence=High score=125
    public ILocator AddCoverageForm => _page.GetByRole(AriaRole.Button, new() { Name = "Add Coverage Form", Exact = true });

    // Source modules: Endorsements|Main | confidence=High score=125
    public ILocator AddEndorsement => _page.GetByRole(AriaRole.Button, new() { Name = "Add Endorsement", Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=124
    public ILocator AwayFromPremisesDesc => _page.GetByRole(AriaRole.Textbox, new() { Name = "Away From Premises Desc", Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    public ILocator AwayFromPremisesLmt => _page.GetByRole(AriaRole.Textbox, new() { Name = "Away From Premises Lmt", Exact = true });

    // Source modules: [CG3132] Limited Fungi or Bacteria Coverage | confidence=High score=125
    public ILocator CG3132LimitedFungiOrBacteriaCoverageOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    public ILocator Coinsurance => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coinsurance*", Exact = true });

    // Source modules: Policy Covg - Main | confidence=High score=125
    public ILocator CoverageFormToBeAdded => _page.GetByRole(AriaRole.Textbox, new() { Name = "Coverage Form To Be Added", Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    public ILocator Description => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description*", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=125
    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    // Source modules:  | confidence=High score=125
    public ILocator Detail => _page.GetByRole(AriaRole.Textbox, new() { Name = "Detail", Exact = true });

    // Source modules: [CG3132] Limited Fungi or Bacteria Coverage | confidence=High score=125
    public ILocator EndorsementType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    // Source modules: GL Navigation Links | confidence=Medium score=113
    public ILocator Endorsements7572E => _page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true });

    // Source modules: Endorsements|Main | confidence=High score=127
    public ILocator Endorsements9626E => _page.GetByLabel("Endorsements", new() { Exact = true });

    // Source modules: Policy Info|CPP Specific Fields | confidence=High score=95
    public ILocator EstimatedPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Estimated Premium*", Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator FG0055FG0062FG0063FG0069FG0071FG0072FG0074FG0077FG0078EmploymentPracticesLiabilityInsuranceCoverageEndorsementOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator FG0055TableRowFG0055 => _page.GetByText("FG0055", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator Fungus => _page.GetByRole(AriaRole.Textbox, new() { Name = "Fungus", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Has the insured ever had a claim for Employment Practices?*", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator LimitDeductible => _page.GetByRole(AriaRole.Textbox, new() { Name = "Limit/Deductible*", Exact = true });

    // Source modules: Policy Covg | confidence=High score=125
    public ILocator PolicyCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Coverage", Exact = true });

    // Source modules: Policy Covg - Accounts Receivable | confidence=High score=125
    public ILocator PolicyCovgAccountsReceivableOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: IM Navigation Links | confidence=Medium score=113
    public ILocator PolicyCovgED95C => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });

    // Source modules: Policy Covg - Main | confidence=High score=127
    public ILocator PolicyCovgF9E58 => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=High score=97
    public ILocator PolicyInfoHeader => _page.GetByLabel("Policy Info Header", new() { Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator PropertyExtensionEndorsements => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property Extension Endorsements", Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.GetByRole(AriaRole.Textbox, new() { Name = "The insured and any executive, officer or owner has knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?*", Exact = true });

    // Source modules: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement | confidence=High score=125
    public ILocator ThirdParty => _page.GetByRole(AriaRole.Textbox, new() { Name = "Third Party*", Exact = true });

    // Source modules: Policy Covg | confidence=High score=95
    public ILocator UtilityServices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Utility Services", Exact = true });

}