using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    public ILocator AddCoverageForm => _page.GetByRole(AriaRole.Link, new() { Name = "Add Coverage Form", Exact = true });

    public ILocator AddEndorsement => _page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true });

    public ILocator AwayFromPremisesDesc => _page.Locator("[fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"], [data-fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"]");

    public ILocator AwayFromPremisesLmt => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Away From Premises Lmt");

    public ILocator PolicyCovgAccountsReceivableOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    public ILocator Coinsurance => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Coinsurance");

    public ILocator CoverageFormToBeAdded => _page.Locator("input[fieldref=\"LineInput.CoverageForm\"]");

    public ILocator Description => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Description");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"]");

    public ILocator Detail => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator EndorsementType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Endorsement Type");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");


    public ILocator EstimatedPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Estimated Premium");

    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    public ILocator FGFormTableRow => _page.GetByText("FG0055", new() { Exact = true });

    public ILocator Fungus => _page.Locator("input[fieldref=\"CovFungusInput.Indicator\"]");

    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Has The Insured Ever Had AClaim For Employment Practices");

    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    public ILocator LimitDeductible => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Limit Deductible");


    public ILocator IMNavigationLinksPolicyCovg => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });



    public ILocator PropertyExtensionEndorsements => _page.Locator("input[fieldref=\"CovExtensionEndorsementsInput.PropertyExtensionEndorsements\"]");

    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "The Insured And Any Executive Officer Or Owner Has Knowledge Or Information Of Any Act Error Or Omission Which Might Give Rise To An EPLClaim Suit Or Complaint");

    public ILocator ThirdParty => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Third Party");

    public ILocator UtilityServices => _page.Locator("input[fieldref=\"CovUtilityServicesInput.Indicator\"]");
}
