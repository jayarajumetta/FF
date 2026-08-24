using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=Medium score=113
    public ILocator ADDADDITIONALINTEREST => _page.GetByRole(AriaRole.Button, new() { Name = "+ ADD ADDITIONAL INTEREST", Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    public ILocator AccountNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Account Number", Exact = true });

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=High score=127
    public ILocator Add => _page.GetByRole(AriaRole.Button, new() { Name = "Add", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AttachmentsListGridRowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator AttachmentsListGridRowCellExplicitName3 => _page.GetByText("(ExplicitName=$3)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=High score=127
    public ILocator ClassFilter => _page.GetByRole(AriaRole.Textbox, new() { Name = "Class Filter", Exact = true });

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    public ILocator ClientInfoSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search", Exact = true });

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator CombinedDeductible => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$combinedDed.value");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=130
    public ILocator CopyOfDecNo => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-wrapper");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    public ILocator DescriptionOfInterest => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description Of Interest", Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=130
    public ILocator EscrowBilledYes => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-wrapper");

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator FarmImplementsNo => _page.GetByTestId("fields.line.covEquipmentBreakdownContent.covEquipmentBreakdownInput$farmImplement.value-chip-wrapper");

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=Medium score=78
    public ILocator FindAClassCode => _page.GetByLabel("Find a Class Code", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator GeneralEligibilityRestrictionsSynching => _page.GetByText("General Eligibility Restrictions - Synching", new() { Exact = true });

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator GreaterThan25000No => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$lossGreaterThan24KEver.value-chip-wrapper");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=113
    public ILocator InsuredOccupancySqFtAngular => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Occupancy Sq Ft - Angular***", Exact = true });

    // Source modules: EQ|Common|Review Required Pop-up | confidence=High score=100
    public ILocator KeepGoing => _page.GetByTestId("btnConfirmYes");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    public ILocator LocationPrimaryLocation => _page.GetByRole(AriaRole.Combobox, new() { Name = "Location (Primary Location)", Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=130
    public ILocator MortgageeSecuredParty => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$type.value-chip-wrapper");

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=High score=127
    public ILocator On => _page.GetByRole(AriaRole.Checkbox, new() { Name = "on", Exact = true });

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=High score=100
    public ILocator OwnButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$buildingOccupiedEQ.value-chip-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PolicyDetailsABBA9 => _page.GetByText("Policy Details", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PolicyDetailsE7F69 => PolicyDetailsABBA9; // semantic alias; locator defined once

    // Source modules: EQ|Common|Transact|Verify DC Premium | confidence=High score=97
    public ILocator PolicyNumber => _page.GetByLabel("Policy Number", new() { Exact = true });

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator PowerGreaterThan250kwNo => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-wrapper");

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator PowerGreaterThan250kwYes => PowerGreaterThan250kwNo; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator PreQualification => _page.GetByRole(AriaRole.Heading, new() { NameRegex = new System.Text.RegularExpressions.Regex("^PreQualification", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    public ILocator Residence => _page.GetByRole(AriaRole.Combobox, new() { Name = "Residence", Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Screen25E91 => _page.GetByText("Screen", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Screen4475C => Screen25E91; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenDA408 => Screen25E91; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading69631 => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading9696C => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeadingDCABF => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: EQ|BOP|PreQualification|Add a Class | confidence=Medium score=113
    public ILocator SearchAddClassCode => _page.GetByRole(AriaRole.Button, new() { Name = "Search/Add Class Code", Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    public ILocator SearchName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Name", Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    public ILocator SearchZipCode => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search ZipCode", Exact = true });

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=78
    public ILocator SelectIfClientOwnsOrRentsTheBuilding => _page.GetByLabel("Select if client owns or rents the building", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Submission48772 => _page.GetByText("Submission", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator Submission7E601 => Submission48772; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SubmissionHeading => _page.GetByText("Submission Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=High score=127
    public ILocator TotalBuildingSqFootage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Building Sq. Footage", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TransACT => _page.GetByText("TransACT", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TransactionType => _page.GetByText("Transaction Type", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator True => _page.GetByText("True", new() { Exact = true });

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator TwoOrMoreLossesNo => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$twoOrMoreLossIn24Month.value-chip-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicy => _page.GetByText("View Policy (*)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicyDetails848D5 => _page.GetByText("View Policy Details", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ViewPolicyDetailsC87C2 => ViewPolicyDetails848D5; // semantic alias; locator defined once

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=Medium score=108
    public ILocator YouHaveSelected1ClassCodes => _page.GetByLabel("You have selected 1 Class Codes", new() { Exact = true });

    // Source EQ|Common|Navigation: Nav Link = DIV InnerText {B[Screen]}, Screen Heading = H1 {B[Screen]}*.
    public ILocator GetNavigationLink(string screen) =>
        _page.GetByText(screen, new() { Exact = true });

    public ILocator GetScreenHeading(string screen) =>
        _page.GetByRole(AriaRole.Heading, new()
        {
            NameRegex = new System.Text.RegularExpressions.Regex("^" + System.Text.RegularExpressions.Regex.Escape(screen), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        });

}
