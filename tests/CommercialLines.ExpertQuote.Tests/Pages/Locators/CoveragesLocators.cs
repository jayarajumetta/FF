using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class CoveragesLocators
{
    private readonly IPage _page;
    public CoveragesLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=130
    public ILocator AddCoverage => _page.GetByTestId("*ddBicycles*");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Approve => _page.GetByText("Approve", new() { Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Blanket FPP | Id+Name
    public ILocator BlanketFPP => _page.Locator("input[id=\"fields.line.covCountryEstateBlanketFPP_D3.blanketFPP_2.value\"][name=\"fields.line.covCountryEstateBlanketFPP_D3.blanketFPP_2.value\"]");

    // Source modules: EQ|SFP|PolicyWide Coverage|CE | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|PolicyWide Coverage|CE | CE Coverage | Id+Name
    public ILocator CECoverage => _page.Locator("input[id=\"\\\"fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[0].policyWideCovCatEntryInput$selected.value-checkbox\\\"\"][name=\"\\\"fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[0].policyWideCovCatEntryInput$selected.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | CheckBox | Id+Name
    public ILocator CheckBox => _page.Locator("input[id=\"_temp.classCodeSelected.0-input\"][name=\"_temp.classCodeSelected.0\"]");

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Blanket FPP | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as BlanketFPP
    public ILocator Choice => BlanketFPP;

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Blanket FPP | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as BlanketFPP
    public ILocator ChoiceWithHorse => BlanketFPP;

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence Covg | Deductible | Id
    public ILocator Deductible => _page.Locator("[id=\"\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$deductible.value\"\"]");

    // Source modules: EQ|BOP|Building|Personal Property|Add Inventory | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Personal Property|Add Inventory | Description | Id+Name
    public ILocator Description => _page.Locator("input[id=\"\\\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\\\"\"][name=\"\\\"fields.risk.rows[0].businessPersonalPropertyInventorySheet.businessPersonalPropertyInventorySheetScheduled.rows[0].businessPersonalPropertyInventorySheetScheduledInput$description.value\\\"\"]");

    // Source modules: EQ|BOP|Additional Coverages|Answer EPLI Questions | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Additional Coverages|Answer EPLI Questions | Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint? | Id
    public ILocator DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint => _page.Locator("[id=\"fields.line.endLineEmploymentRelatedPracticesLiability.endLineEmploymentRelatedPracticesLiabilityInput$ePLPriorKnowledge.value\"]");

    // Source modules: EQ|BOP|Additional Coverages|Answer EPLI Questions | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Additional Coverages|Answer EPLI Questions | Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?  | Id
    public ILocator HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner => _page.Locator("[id=\"fields.line.endLineEmploymentRelatedPracticesLiability.endLineEmploymentRelatedPracticesLiabilityInput$ePLPriorClaim.value\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAME => _page.GetByText("IFRAME", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IFRAMEDuckCreekPolicyIFRAMEOK => _page.GetByText("IFRAME - OK", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator IsThisCoverageBound => _page.GetByText("Is this coverage bound?*", new() { Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Liability Limit | Id
    public ILocator LiabilityLimit => _page.Locator("[id=\"fields.line.liability_D5.liabilityLimit_2.value\"]");

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | Limit | Id+Name
    public ILocator Limit => _page.Locator("input[id=\"\\\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\\\"\"][name=\"\\\"fields.covEndorsements.rows[0].covEndorsementsInput$limit.value\\\"\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Blanket FPP | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as BlanketFPP
    public ILocator Premier => BlanketFPP;

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Blanket FPP | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as BlanketFPP
    public ILocator PremierWithHorse => BlanketFPP;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ReferRequestIssuance => _page.GetByText("Refer/Request Issuance", new() { Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|DIV 4|Scheduled Personal Property|Bicycles | Search by Name or Code | Id+Name
    public ILocator SearchByNameOrCode => _page.Locator("input[id=\"temp.filter\"][name=\"temp.filter\"]");

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    // v56 raw Tosca primary: Location|BCEG Detail | Select | DuckCreekId
    public ILocator Select => _page.Locator("[duckcreekid=\"Select\"], [data-duckcreekid=\"Select\"]");

    // Source modules: EQ|SFP|CE|Coverages | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Blanket FPP | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as BlanketFPP
    public ILocator SelectWithHorse => BlanketFPP;

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Unscheduled Structures | Id
    public ILocator UnscheduledStructures => _page.Locator("[id=\"fields.line.covCountryEstate_D2.unschedStructures_3.value\"]");

    // Source modules: EQ|SFP|CE|Coverages | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|CE|Coverages | Water Damage | Id
    public ILocator WaterDamage => _page.Locator("[id=\"fields.line.covCountryEstate_D1.waterDamage_2.value\"]");

}
