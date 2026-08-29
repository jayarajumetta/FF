using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    public ILocator AddCoverageForm => _page.Locator("a[fieldref=\"Add Coverage Form\"]");

    public ILocator AddEndorsement => _page.Locator("a[fieldref=\"Add Endorsement\"]");

    public ILocator AwayFromPremisesDesc => _page.Locator("[fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"], [data-fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"]");

    public ILocator AwayFromPremisesLmt => _page.Locator("[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D6A_3_5-inputEl\"]");

    public ILocator PolicyCovgAccountsReceivableOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    public ILocator Coinsurance => _page.Locator("[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D66_3_5-inputEl\"]");

    public ILocator CoverageFormToBeAdded => _page.Locator("input[fieldref=\"LineInput.CoverageForm\"]");

    public ILocator Description => _page.Locator("[id=\"f_i3309D0502687408F8270F5B734F24EBAD62_3_5-inputEl\"]");

    public ILocator DescriptionOfSpecifiedOperation => _page.Locator("input[fieldref=\"PolicyOutput.DescriptionOfOperations\"]");

    public ILocator Detail => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator EndorsementType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Endorsement Type");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");


    public ILocator EstimatedPremium => _page.Locator("[id=\"f_p07E26D4A848C4BFA8EEDAFE9836C87FA4AA_3_1-inputEl\"]");

    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    public ILocator FGFormTableRow => _page.GetByText("FG0055", new() { Exact = true });

    public ILocator Fungus => _page.Locator("input[fieldref=\"CovFungusInput.Indicator\"]");

    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521ACF_3_26-inputEl\"]");

    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    public ILocator LimitDeductible => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521ACC_3_26-inputEl\"]");


    public ILocator IMNavigationLinksPolicyCovg => _page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true });



    public ILocator PropertyExtensionEndorsements => _page.Locator("input[fieldref=\"CovExtensionEndorsementsInput.PropertyExtensionEndorsements\"]");

    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521AD0_3_26-inputEl\"]");

    public ILocator ThirdParty => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521AD1_3_26-inputEl\"]");

    public ILocator UtilityServices => _page.Locator("input[fieldref=\"CovUtilityServicesInput.Indicator\"]");
}
