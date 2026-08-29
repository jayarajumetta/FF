using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    public ILocator AddCoverageForm => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-e6d1-13bd-997e7f292085");

    public ILocator AddEndorsement => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-5aa5-ccad-be01b1072c20");

    public ILocator AwayFromPremisesDesc => _page.Locator("[fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"], [data-fieldref=\"AccountsReceivableInput.OffPremisesLimitDescription\"]");

    public ILocator AwayFromPremisesLmt => _page.Locator("[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D6A_3_5-inputEl\"]");

    public ILocator PolicyCovgAccountsReceivableOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator CP => _page.GetByText("CP", new() { Exact = true });

    public ILocator Coinsurance => _page.Locator("[id=\"f_cFB6D8CBADE6A4CB5A622905338BA6BA5D66_3_5-inputEl\"]");

    public ILocator CoverageFormToBeAdded => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-eb63-48b6-c4fba029f2b7");

    public ILocator Description => _page.Locator("[id=\"f_i3309D0502687408F8270F5B734F24EBAD62_3_5-inputEl\"]");

    public ILocator DescriptionOfSpecifiedOperation => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Specified Operation", Exact = true });

    public ILocator Detail => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    public ILocator EndorsementType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Endorsement Type", Exact = true });

    public ILocator GLNavigationLinksEndorsements => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-6ee5-b6f2-1ec6da80521a");

    public ILocator Endorsements => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-454b-5278-9f3e549fbf37");

    public ILocator EstimatedPremium => _page.Locator("[id=\"f_p07E26D4A848C4BFA8EEDAFE9836C87FA4AA_3_1-inputEl\"]");

    public ILocator FG0055TableRowEmploymentPracticesLiabilityInsuranceCoverageEndorsement => _page.GetByText("Employment Practices Liability Insurance Coverage Endorsement", new() { Exact = true });

    public ILocator FGFormTableRow => _page.GetByText("FG0055", new() { Exact = true });

    public ILocator Fungus => _page.GetByRole(AriaRole.Textbox, new() { Name = "Fungus", Exact = true });

    public ILocator GL => _page.GetByText("GL", new() { Exact = true });

    public ILocator HasTheInsuredEverHadAClaimForEmploymentPractices => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521ACF_3_26-inputEl\"]");

    public ILocator IM => _page.GetByText("IM", new() { Exact = true });

    public ILocator LimitDeductible => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521ACC_3_26-inputEl\"]");

    public ILocator PolicyCoverage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Coverage", Exact = true });

    public ILocator IMNavigationLinksPolicyCovg => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a4c5-1221-65f506afd5b8");

    public ILocator PolicyCovgMainPolicyCovg => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-9338-df10-a309c3e3c058");

    public ILocator PolicyInfoHeader => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Info Header");

    public ILocator PropertyExtensionEndorsements => _page.GetByRole(AriaRole.Textbox, new() { Name = "Property Extension Endorsements", Exact = true });

    public ILocator TheInsuredAndAnyExecutiveOfficerOrOwnerHasKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521AD0_3_26-inputEl\"]");

    public ILocator ThirdParty => _page.Locator("[id=\"f_c413F524BDA03486A8D2A269F802883521AD1_3_26-inputEl\"]");

    public ILocator UtilityServices => _page.GetByRole(AriaRole.Textbox, new() { Name = "Utility Services", Exact = true });
}
