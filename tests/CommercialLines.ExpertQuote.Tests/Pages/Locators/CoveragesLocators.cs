using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    public ILocator AddCoverage => _page.GetByTestId("*ddBicycles*");

    public ILocator Approve => _page.GetByText("Approve", new() { Exact = true });

    public ILocator BlanketFPP => _page.Locator("input[id=\"fields.line.covCountryEstateBlanketFPP_D3.blanketFPP_2.value\"][name=\"fields.line.covCountryEstateBlanketFPP_D3.blanketFPP_2.value\"]");

    public ILocator CECoverage => _page.Locator("input[id=\"fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[0].policyWideCovCatEntryInput$selected.value-checkbox\"][name=\"fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[0].policyWideCovCatEntryInput$selected.value\"]");

    public ILocator CheckBox => _page.Locator("input[id=\"_temp.classCodeSelected.0-input\"][name=\"_temp.classCodeSelected.0\"]");



    public ILocator Deductible => _page.Locator("[id=\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$deductible.value\"]");

    public ILocator Description => _page.Locator("input[id=\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\"][name=\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\"]");

    public ILocator DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("[id=\"fields.line.endLineEmploymentRelatedPracticesLiability.endLineEmploymentRelatedPracticesLiabilityInput$ePLPriorKnowledge.value\"]");

    public ILocator HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner => _page.Locator("[id=\"fields.line.endLineEmploymentRelatedPracticesLiability.endLineEmploymentRelatedPracticesLiabilityInput$ePLPriorClaim.value\"]");

    public ILocator IFRAME => _page.GetByText("IFRAME", new() { Exact = true });

    public ILocator IFRAMEDuckCreekPolicyIFRAMEOK => _page.GetByText("IFRAME - OK", new() { Exact = true });

    public ILocator IsThisCoverageBound => _page.GetByText("Is this coverage bound?*", new() { Exact = true });

    public ILocator LiabilityLimit => _page.Locator("[id=\"fields.line.liability_D5.liabilityLimit_2.value\"]");

    public ILocator Limit => _page.Locator("input[id=\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\"][name=\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });



    public ILocator ReferRequestIssuance => _page.GetByText("Refer/Request Issuance", new() { Exact = true });

    public ILocator Save => _page.Locator("button[id=\"fields.data.save\"], button[data-testid=\"fields.line.save\"], button:has-text(\"Save\"), a:has-text(\"Save\")").First;

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator SearchByNameOrCode => _page.Locator("input[id=\"temp.filter\"][name=\"temp.filter\"]");

    public ILocator Select => _page.GetByRole(AriaRole.Radio, new() { Name = "Select", Exact = true }).First;


    public ILocator UnscheduledStructures => _page.Locator("[id=\"fields.line.covCountryEstate_D2.unschedStructures_3.value\"]");

    public ILocator WaterDamage => _page.Locator("[id=\"fields.line.covCountryEstate_D1.waterDamage_2.value\"]");

}
