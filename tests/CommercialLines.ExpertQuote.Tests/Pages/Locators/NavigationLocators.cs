using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    public ILocator ADDADDITIONALINTEREST => _page.Locator("input[id=\"additionalInsuredSelected.0-checkbox\"][name=\"additionalInsuredSelected.0\"]");

    public ILocator AccountNumber => _page.Locator("input[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$accountNumber.value\"][name=\"fields.additionalOtherInterest.additionalOtherInterestInput$accountNumber.value\"]");

    public ILocator Add => _page.Locator("mat-dialog-content:has-text('Find a Class Code') button[data-testid='fields.data.addClass']:visible").First;
   
    public ILocator FindClassCodeDialog => _page.Locator("mat-dialog-content:has-text('Find a Class Code')").First;

    public ILocator AttachmentsListGridRowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

    public ILocator AttachmentsListGridRowCellExplicitName3 => _page.GetByText("(ExplicitName=$3)", new() { Exact = true });

    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    public ILocator ChecklistOpenedOK => _page.Locator("button#btnOk[data-testid=\"btnOk\"]");

    public ILocator ClassFilter => _page.Locator("input[id=\"temp.filter\"][name=\"temp.filter\"]");

    public ILocator ClassFilterSearchButton => _page.Locator("button[data-testid='temp.filter--search']");

    public ILocator ClientInfoSearch => _page.Locator("input[id=\"customer.name.first\"][name=\"customer.name.first\"]");

    public ILocator CombinedDeductible => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$combinedDed.value");

    public ILocator CopyOfDecNo => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-wrapper");

    public ILocator DescriptionOfInterest => _page.Locator("input[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$descriptionOfInterest.value\"][name=\"fields.additionalOtherInterest.additionalOtherInterestInput$descriptionOfInterest.value\"]");

    public ILocator EscrowBilledYes => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-wrapper");

    public ILocator FarmImplementsNo => _page.GetByTestId("fields.line.covEquipmentBreakdownContent.covEquipmentBreakdownInput$farmImplement.value-chip-wrapper");


    public ILocator GeneralEligibilityRestrictionsSynching => _page.GetByText("General Eligibility Restrictions - Synching", new() { Exact = true });

    public ILocator GreaterThan25000No => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$lossGreaterThan24KEver.value-chip-wrapper");

    public ILocator InsuredOccupancySqFtAngular => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\"][name=\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\"]");

    public ILocator KeepGoing => _page.GetByTestId("btnConfirmYes");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator LocationPrimaryLocation => _page.Locator("[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$locationID.value\"]");

    public ILocator MortgageeSecuredParty => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$type.value-chip-wrapper");

    // Class row checkbox (Search/Add Class Code results)
    public ILocator AddToPolicyCheckbox => _page.Locator("input[type='checkbox'][data-testid*='occupancyClassCodeInput$addToPolicy.value']:visible").First;

    // Backward-compatible alias
    public ILocator On => AddToPolicyCheckbox;

    public ILocator OwnButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$buildingOccupiedEQ.value-chip-wrapper").Filter(new() { HasText = "Own" });

    public ILocator PolicyDetailsABBA9 => _page.Locator("[id=\"pageTitle\"]");


    public ILocator PolicyNumber => _page.Locator("[id=\"activeAccountReferenceId\"]");

    public ILocator PowerGreaterThan250kwNo => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-wrapper");


    public ILocator PreQualification => _page.GetByRole(AriaRole.Heading, new() { NameRegex = new System.Text.RegularExpressions.Regex("^PreQualification", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

    public ILocator Residence => _page.Locator("[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$buildingID.value\"]");

    public ILocator NextClaimsPriorInsurance => _page.Locator("button[data-testid='fields.data-Next.next']");

    public ILocator Save => _page.Locator("button[id=\"fields.data.save\"], button[id=\"fields.data.saveLocation\"], button[data-testid=\"fields.line.save\"], button:has-text(\"Save\"), a:has-text(\"Save\")").First;

    public ILocator Screen25E91 => _page.GetByText("Screen", new() { Exact = true });



    public ILocator ScreenHeading69631 => _page.GetByText("Screen Heading", new() { Exact = true });



    public ILocator SearchAddClassCode => _page.Locator("button[id='fields.data.classCodeSearchButton'], button[data-testid='fields.data.classCodeSearchButton']");

    public ILocator NextPrimaryInsuredDetails => _page.GetByRole(AriaRole.Button, new() { Name = "Next: Primary Insured Details", Exact = true });

    public ILocator NextClientDetails => _page.GetByTestId("fields.data-Next.next");

    public ILocator NextNarrativeFromClaims => _page.Locator("button[data-testid='fields.data.next']").Filter(new() { HasText = "Next: Narrative" });

    public ILocator InspectionContactCheckBox => _page.Locator("label.checkbox-label", new() { HasText = "Inspection Contact" });

    public ILocator NextLocationsBuildings => _page.GetByTestId("LocationsBuildings-nav");

    public ILocator NextPricing => _page.Locator("[data-testid=\"fields.data-Next.next-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Next: Pricing" }).First;

    public ILocator NextBilling => _page.Locator("[data-testid=\"fields.data.next-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Next: Billing" }).First;

    public ILocator CatastrophePotential => _page.Locator("[data-testid=\"fields.tierPricing.tierPricingInput$catastrophePotentialReason.value\"]");

    public ILocator LossRatio => _page.Locator("[data-testid=\"fields.tierPricing.tierPricingInput$lossRatioReason.value\"]");

    public ILocator LengthOfEmployment => _page.Locator("[data-testid=\"fields.tierPricing.tierPricingInput$lengthOfEmploymentReason.value\"]");

    public ILocator MemberOfTradeAssociation => _page.Locator("[data-testid=\"fields.tierPricing.tierPricingInput$memberOfTradeAssociationReason.value\"]");

    public ILocator RiskManagementProgram => _page.Locator("[data-testid=\"fields.tierPricing.tierPricingInput$riskManagementProgramReason.value\"]");

    public ILocator YearsInBusiness => _page.Locator("[data-testid=\"fields.tierPricing.tierPricingInput$yearsInBusinessReason.value\"]");

    public ILocator SearchName => _page.Locator("input[id=\"temp.searchName\"][name=\"temp.searchName\"]");

    public ILocator SearchZipCode => _page.Locator("input[id=\"temp.searchZipCode\"][name=\"temp.searchZipCode\"]");

    public ILocator SelectIfClientOwnsOrRentsTheBuilding => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\"][name=\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\"]");

    public ILocator Submission48772 => _page.GetByText("Submission", new() { Exact = true });


    public ILocator SubmissionHeading => _page.Locator("[id=\"pageTop\"]");



    public ILocator TransactionType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Transaction Type", Exact = true }).First;

    public ILocator True => _page.GetByText("True", new() { Exact = true });

    public ILocator TwoOrMoreLossesNo => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$twoOrMoreLossIn24Month.value-chip-wrapper");

    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

    public ILocator ViewPolicyDetails848D5 => _page.GetByRole(AriaRole.Link, new() { Name = "View Policy Details", Exact = true }).First;



    public ILocator SaveBuilding => _page.Locator("button[id=\"fields.data.saveBuilding\"], [data-testid=\"fields.data.saveBuilding-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Save" }).First;

    public ILocator LaunchToChecklist => _page.Locator("[data-testid=\"fields.data.checklist-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Launch to Checklist" }).First;

    // Source EQ|Common|Navigation: Nav Link = DIV InnerText {B[Screen]}, Screen Heading = H1 {B[Screen]}*.
    public ILocator GetNavigationLink(string screen) =>
        _page.GetByTestId($"{screen}-nav");

    public ILocator GetScreenHeading(string screen) =>
        _page.GetByRole(AriaRole.Heading, new()
        {
            NameRegex = new System.Text.RegularExpressions.Regex(
                "^" + System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Escape(screen), @"(?<=[a-z])(?=[A-Z])", @"\s*"),
                System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        });

}
