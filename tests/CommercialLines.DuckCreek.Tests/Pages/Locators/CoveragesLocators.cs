using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    public ILocator AddCoverageForm => _page.GetByRole(AriaRole.Link, new() { Name = "Add Coverage Form", Exact = true });

    public ILocator AddEndorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    public ILocator AwayFromPremisesDesc => _page.Locator("textarea[fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"]");

    public ILocator AwayFromPremisesLmt => _page.Locator("input[fieldref=\"AccountsReceivableInput.OffPremisesLimit\"]");

    public ILocator PolicyCovgAccountsReceivableOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator CP => _page.Locator("input[type='checkbox'][fieldref='LineInput.Selected'][name='boolean_2F6_1']");
    public ILocator Coinsurance => _page.Locator("input[fieldref=\"AccountsReceivableInput.Coinsurance\"]");

    public ILocator CoverageFormToBeAdded => _page.Locator("input[fieldref=\"LineInput.CoverageForm\"]");

    public ILocator Description => _page.Locator("input[fieldref=\"CoverageFormsInput.Description\"]");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"]");

    public ILocator Detail => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator FG0055Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0059TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementNY => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (NY)", new() { Exact = true });

    public ILocator FG0059Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (NY)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0063TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementMD => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (MD)", new() { Exact = true });

    public ILocator FG0063Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (MD)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0062TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementPA => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (PA)", new() { Exact = true });

    public ILocator FG0062Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (PA)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0069TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementOR => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (OR)", new() { Exact = true });

    public ILocator FG0069Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (OR)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0071TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementNH => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (NH)", new() { Exact = true });

    public ILocator FG0071Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (NH)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0072TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementME => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (ME)", new() { Exact = true });

    public ILocator FG0072Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (ME)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0074TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementCT => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (CT)", new() { Exact = true });

    public ILocator FG0074Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (CT)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0077TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementVA => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (VA)", new() { Exact = true });

    public ILocator FG0077Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (VA)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator FG0078TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsementVT => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement (VT)", new() { Exact = true });

    public ILocator FG0078Detail => _page.Locator("tr:has-text(\"Employment Practices Liability Insurance Coverage Endorsement (VT)\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator EndorsementType => _page.Locator("input[fieldref=\"CovEndorsementsInput.Type\"]");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator PolicyCoverage => _page.Locator("input[fieldref=\"PropertyPolicyInput.PolicyCoverage\"]");


    public ILocator EstimatedPremium => _page.Locator("input[fieldref=\"PolicyInput.EstimatedPremium\"]");
    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    public ILocator CG2151TableRowAmendmentOfLiquorLiabilityExclusion => _page.GetByText("Amendment Of Liquor Liability Exclusion - Exception For Scheduled Activities", new() { Exact = true });

    public ILocator CG2151Detail => _page.Locator("tr:has-text(\"Amendment Of Liquor Liability Exclusion - Exception For Scheduled Activities\")").Locator("a:has(span.g-btn-text:has-text(\"Detail\"))").First;

    public ILocator CovEndorsementsDescription => _page.Locator("textarea[fieldref=\"CovEndorsementsInput.Description\"]");

    public ILocator FGFormTableRow => _page.GetByText("FG0055", new() { Exact = true });

    public ILocator Fungus => _page.Locator("input[fieldref=\"CovFungusInput.Indicator\"]");
    public ILocator GL => _page.Locator("input[type='checkbox'][fieldref='LineInput.Selected'][name='boolean_2F6']");


    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLIClaim\"]");

    public ILocator IM => _page.Locator("input[type='checkbox'][fieldref='LineInput.Selected'][name='boolean_2F6_2']");

    public ILocator LimitDeductible => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLILimitDeductible\"]");


    public ILocator IMNavigationLinksPolicyCovg => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });



    public ILocator PropertyExtensionEndorsements => _page.Locator("input[fieldref=\"CovExtensionEndorsementsInput.PropertyExtensionEndorsements\"]");

    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLIClaimInfo\"]");

    public ILocator ThirdParty => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLIThirdParty\"]");

    public ILocator UtilityServices => _page.Locator("input[fieldref=\"CovUtilityServicesInput.Indicator\"]");
}
