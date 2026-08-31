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

    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    public ILocator Coinsurance => _page.Locator("input[fieldref=\"AccountsReceivableInput.Coinsurance\"]");

    public ILocator CoverageFormToBeAdded => _page.Locator("input[fieldref=\"LineInput.CoverageForm\"]");

    public ILocator Description => _page.Locator("input[fieldref=\"CoverageFormsInput.Description\"]");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"]");

    public ILocator Detail => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator EndorsementType => _page.Locator("input[fieldref=\"CovEndorsementsInput.Type\"]");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator PolicyCoverage => _page.Locator("input[fieldref=\"PropertyPolicyInput.PolicyCoverage\"]");


    public ILocator EstimatedPremium => _page.Locator("input[fieldref=\"PolicyInput.EstimatedPremium\"]");

    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    public ILocator FGFormTableRow => _page.GetByText("FG0055", new() { Exact = true });

    public ILocator Fungus => _page.Locator("input[fieldref=\"CovFungusInput.Indicator\"]");

    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLIClaim\"]");

    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    public ILocator LimitDeductible => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLILimitDeductible\"]");


    public ILocator IMNavigationLinksPolicyCovg => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });



    public ILocator PropertyExtensionEndorsements => _page.Locator("input[fieldref=\"CovExtensionEndorsementsInput.PropertyExtensionEndorsements\"]");

    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLIClaimInfo\"]");

    public ILocator ThirdParty => _page.Locator("input[fieldref=\"CovEndorsementsInput.EPLIThirdParty\"]");

    public ILocator UtilityServices => _page.Locator("input[fieldref=\"CovUtilityServicesInput.Indicator\"]");
}
