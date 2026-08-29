using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Mortgage CheckBox | Id+Name
    public ILocator ADDADDITIONALINTEREST => _page.Locator("input[id=\"additionalInsuredSelected.0-checkbox\"][name=\"additionalInsuredSelected.0\"]");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Account Number | Id+Name
    public ILocator AccountNumber => _page.Locator("input[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$accountNumber.value\"][name=\"fields.additionalOtherInterest.additionalOtherInterestInput$accountNumber.value\"]");

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | Add | Id
    public ILocator Add => _page.Locator("[id=\"fields.data.addClass\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator AttachmentsListGridRowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator AttachmentsListGridRowCellExplicitName3 => _page.GetByText("(ExplicitName=$3)", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator BODY => _page.GetByText("BODY", new() { Exact = true });

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | Class Filter | Id+Name
    public ILocator ClassFilter => _page.Locator("input[id=\"temp.filter\"][name=\"temp.filter\"]");

    // Source modules: EQ|Common|Client Info | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|Client Info | customer.name.first | Id+Name
    public ILocator ClientInfoSearch => _page.Locator("input[id=\"customer.name.first\"][name=\"customer.name.first\"]");

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator CombinedDeductible => _page.GetByTestId("fields.line.covEquipmentBreakdown.covEquipmentBreakdownInput$combinedDed.value");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=130
    public ILocator CopyOfDecNo => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-wrapper");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Description Of Interest | Id+Name
    public ILocator DescriptionOfInterest => _page.Locator("input[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$descriptionOfInterest.value\"][name=\"fields.additionalOtherInterest.additionalOtherInterestInput$descriptionOfInterest.value\"]");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=130
    public ILocator EscrowBilledYes => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-wrapper");

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator FarmImplementsNo => _page.GetByTestId("fields.line.covEquipmentBreakdownContent.covEquipmentBreakdownInput$farmImplement.value-chip-wrapper");

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | Class Filter | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as ClassFilter
    public ILocator FindAClassCode => ClassFilter;

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator GeneralEligibilityRestrictionsSynching => _page.GetByText("General Eligibility Restrictions - Synching", new() { Exact = true });

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator GreaterThan25000No => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$lossGreaterThan24KEver.value-chip-wrapper");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | Insured Occupancy Sq Ft | Id+Name
    public ILocator InsuredOccupancySqFtAngular => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\\\"\"]");

    // Source modules: EQ|Common|Review Required Pop-up | confidence=High score=100
    public ILocator KeepGoing => _page.GetByTestId("btnConfirmYes");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Location (Primary Location) | Id
    public ILocator LocationPrimaryLocation => _page.Locator("[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$locationID.value\"]");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=130
    public ILocator MortgageeSecuredParty => _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$type.value-chip-wrapper");

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | on | Id
    public ILocator On => _page.Locator("[id=\"\"fields._OccupancyClassSearch.occupancyClassCode.rows[12].occupancyClassCodeInput$addToPolicy.value-checkbox\"\"]");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=High score=100
    public ILocator OwnButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$buildingOccupiedEQ.value-chip-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT|Policy Details (Attachments) | Policy Details | Id
    public ILocator PolicyDetailsABBA9 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator PolicyDetailsE7F69 => PolicyDetailsABBA9; // semantic alias; locator defined once

    // Source modules: EQ|Common|Transact|Verify DC Premium | confidence=High score=97
    // v56 raw Tosca primary: EQ|Common|Transact|Verify DC Premium | Policy Number | Id
    public ILocator PolicyNumber => _page.Locator("[id=\"activeAccountReferenceId\"]");

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator PowerGreaterThan250kwNo => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$powerGeneration.value-chip-wrapper");

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator PowerGreaterThan250kwYes => PowerGreaterThan250kwNo; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator PreQualification => _page.GetByRole(AriaRole.Heading, new() { NameRegex = new System.Text.RegularExpressions.Regex("^PreQualification", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Residence | Id
    public ILocator Residence => _page.Locator("[id=\"fields.additionalOtherInterest.additionalOtherInterestInput$buildingID.value\"]");

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Screen25E91 => _page.GetByText("Screen", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Screen4475C => Screen25E91; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenDA408 => Screen25E91; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeading69631 => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeading9696C => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ScreenHeadingDCABF => ScreenHeading69631; // semantic alias; locator defined once

    // Source modules: EQ|BOP|PreQualification|Add a Class | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|Common|PreQualification|Add Class Codes | Search/Add Class Code | Id
    public ILocator SearchAddClassCode => _page.Locator("[id=\"fields.data.classCodeSearchButton\"]");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Search Name | Id+Name
    public ILocator SearchName => _page.Locator("input[id=\"temp.searchName\"][name=\"temp.searchName\"]");

    // Source modules: EQ|SFP|Mortgagee/Loss Payee | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Mortgagee/Loss Payee | Search ZipCode | Id+Name
    public ILocator SearchZipCode => _page.Locator("input[id=\"temp.searchZipCode\"][name=\"temp.searchZipCode\"]");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | Total Building Sq. Footage | Id+Name
    public ILocator SelectIfClientOwnsOrRentsTheBuilding => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\\\"\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Submission48772 => _page.GetByText("Submission", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator Submission7E601 => Submission48772; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: Submission|Required and Optional Fields | Submission Heading | Id
    public ILocator SubmissionHeading => _page.Locator("[id=\"pageTop\"]");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | Total Building Sq. Footage | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as SelectIfClientOwnsOrRentsTheBuilding
    public ILocator TotalBuildingSqFootage => SelectIfClientOwnsOrRentsTheBuilding;

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | TransACT | Id
    // v56 semantic alias: same physical raw-Tosca control as PolicyDetailsABBA9
    public ILocator TransACT => PolicyDetailsABBA9;

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | Transaction Type | Id+Name+DuckCreekId
    public ILocator TransactionType => _page.Locator("input[id=\"f_tB2C8F4EC9E3041B7B52430914E990D15D2_2_1-inputEl\"][name=\"f_tB2C8F4EC9E3041B7B52430914E990D15D2_2_1-inputEl\"][duckcreekid=\"TransACTInput.TransactionTypeList\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator True => _page.GetByText("True", new() { Exact = true });

    // Source modules: EQ|SFP|Equipment Breakdown | confidence=High score=130
    public ILocator TwoOrMoreLossesNo => _page.GetByTestId("fields.line.covEquipmentBreakdownPowerGeneration.covEquipmentBreakdownInput$twoOrMoreLossIn24Month.value-chip-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary: TransACT | View Policy  (*) | Id
    public ILocator ViewPolicy => _page.Locator("[id=\"returnToActiveSessionA\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    public ILocator ViewPolicyDetails848D5 => _page.FrameLocator("iframe").Locator("[duckcreekid=\"NewTransactionReason.NewTransactionReasonDescription\"], [data-duckcreekid=\"NewTransactionReason.NewTransactionReasonDescription\"]");

    // Source modules: Synthetic | confidence=Review score=40
    public ILocator ViewPolicyDetailsC87C2 => ViewPolicyDetails848D5; // semantic alias; locator defined once

    // Source modules: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | confidence=Medium score=108
    // v56 raw Tosca primary: EQ|Common|PreQualification|Add Class Codes|Search/Add Class Codes | Class Filter | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as ClassFilter
    public ILocator YouHaveSelected1ClassCodes => ClassFilter;

    // Source EQ|Common|Navigation: Nav Link = DIV InnerText {B[Screen]}, Screen Heading = H1 {B[Screen]}*.
    public ILocator GetNavigationLink(string screen) =>
        _page.GetByText(screen, new() { Exact = true });

    public ILocator GetScreenHeading(string screen) =>
        _page.GetByRole(AriaRole.Heading, new()
        {
            NameRegex = new System.Text.RegularExpressions.Regex("^" + System.Text.RegularExpressions.Regex.Escape(screen), System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        });

}
