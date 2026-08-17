using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BuildingsLocators
{
    private readonly IPage _page;
    public BuildingsLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=130
    public ILocator ActualCashValue => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].riskInput$ratingBasisBuilding.value-chip-wrapper");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=114
    public ILocator AddANote => _page.GetByRole(AriaRole.Textbox, new() { Name = "Add a Note...", Exact = true });

    // Source modules: EQ|BOP|Add a Building Button | confidence=High score=127
    public ILocator AddBuildingBPP => _page.GetByRole(AriaRole.Button, new() { Name = "+ Add Building / BPP", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=Medium score=78
    public ILocator AddResidenceHeader => _page.GetByLabel("Add Residence - Header", new() { Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence | confidence=Medium score=113
    public ILocator AddResidenceToLocation => _page.GetByRole(AriaRole.Button, new() { Name = "+ Add Residence to Location", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    public ILocator AdditionalDescription => _page.GetByRole(AriaRole.Textbox, new() { Name = "Additional Description", Exact = true });

    // Source modules: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | confidence=Medium score=83
    public ILocator AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes => _page.GetByRole(AriaRole.Button, new() { Name = "Automatic Commercial Cooking Exhaust and Extinguishing (ANSUL) System - Yes", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=130
    public ILocator BVSButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingValuatioinInput$estimatorType.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Medium score=113
    public ILocator BVSGroup => _page.GetByRole(AriaRole.Listitem, new() { Name = "BVS Group", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=127
    public ILocator BVSGroupCombobox => _page.GetByRole(AriaRole.Combobox, new() { Name = "BVS Group Combobox", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Medium score=113
    public ILocator BVSResult => _page.GetByRole(AriaRole.Listitem, new() { Name = "BVS Result", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=127
    public ILocator BVSResultsCombobox => _page.GetByRole(AriaRole.Combobox, new() { Name = "BVS Results Combobox", Exact = true });

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=130
    public ILocator Building => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].covBuilding.covBuildingInput$limit.value");

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    public ILocator BuildingContainsHabitationalOccupanciesChecked => _page.GetByRole(AriaRole.Button, new() { Name = "Building contains habitational occupancies checked", Exact = true });

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    public ILocator BuildingContainsHabitationalOccupanciesUnchecked => _page.GetByRole(AriaRole.Button, new() { Name = "Building contains habitational occupancies unchecked", Exact = true });

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=High score=100
    public ILocator BuildingCoverageAngular => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$includeBuildingCoverage.value");

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=97
    public ILocator BuildingDetailsHeading => _page.GetByLabel("Building Details Heading", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=108
    public ILocator BuildingPhoto1 => _page.GetByLabel("Building Photo 1", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto1Header => _page.GetByLabel("Building Photo 1 Header", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto2 => _page.GetByLabel("Building Photo 2", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto2Header => _page.GetByLabel("Building Photo 2 Header", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto3 => _page.GetByLabel("Building Photo 3", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto3Header => _page.GetByLabel("Building Photo 3 Header", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto4 => _page.GetByLabel("Building Photo 4", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    public ILocator BuildingPhoto4Header => _page.GetByLabel("Building Photo 4 Header", new() { Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=130
    public ILocator CheckBoxAngular => _page.GetByTestId("_temp.classCodeSelected.0");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=97
    public ILocator ClassCodes => _page.GetByLabel("Class Codes", new() { Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=130
    public ILocator CommercialButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingValuatioinInput$structureType.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator DoesTheClientHaveASolidFuelHeatingTypeNo => _page.GetByTestId("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=130
    public ILocator DoesTheResidenceHaveAThermostaticallyControlledDeviceYes => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-chip-wrapper");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator EChecklistEChecklistOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions => _page.GetByText("EQ|BOP|Building|Building Details|Answer any Extra Property Additional Questions", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQBOPBuildingBuildingDetailsSelectBurglarAlarm => _page.GetByText("EQ|BOP|Building|Building Details|Select Burglar Alarm", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQBOPBuildingBuildingDetailsSelectPelletStove => _page.GetByText("EQ|BOP|Building|Building Details|Select Pellet Stove", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQBOPBuildingBuildingDetailsSelectWoodFurnace => _page.GetByText("EQ|BOP|Building|Building Details|Select Wood Furnace", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQBOPBuildingBuildingDetailsSelectWoodStove => _page.GetByText("EQ|BOP|Building|Building Details|Select Wood Stove", new() { Exact = true });

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator Exception => _page.GetByRole(AriaRole.Button, new() { Name = "Exception", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=130
    public ILocator Frame => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$constructionCodeValuation.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    public ILocator FunctionalPersonalPropertyChecked => _page.GetByRole(AriaRole.Button, new() { Name = "Functional Personal Property checked", Exact = true });

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    public ILocator FunctionalPersonalPropertyUnchecked => _page.GetByRole(AriaRole.Button, new() { Name = "Functional Personal Property unchecked", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Medium score=113
    public ILocator GetValuation => _page.GetByRole(AriaRole.Button, new() { Name = "Get Valuation", Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    public ILocator GrossSalesReceipts => _page.GetByRole(AriaRole.Textbox, new() { Name = "Gross Sales Receipts", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator HeatingYear => _page.GetByTestId("fields.building.rows[0].buildingInput$heatingYear.value");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    public ILocator InsuranceAmount => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insurance Amount", Exact = true });

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=High score=127
    public ILocator InsuredOccupancySqFt => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Occupancy Sq Ft", Exact = true });

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=113
    public ILocator InsuredOccupancySqFtAngular => _page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Occupancy Sq Ft - Angular***", Exact = true });

    // Source modules: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | confidence=High score=130
    public ILocator IsAnyHeatSourceThermostaticallyControlledYes => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$thermostaticallyControlled.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Heating Sources | confidence=High score=130
    public ILocator IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$noneOfTheAbove.value");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|BOP|Add Building|Building Details | confidence=High score=127
    public ILocator NumberOfStories => _page.GetByRole(AriaRole.Textbox, new() { Name = "Number of Stories", Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=97
    public ILocator OccupancySQFTHeading => _page.GetByLabel("Occupancy SQ FT Heading", new() { Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    public ILocator OccupancySqFootageTotal => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occupancy Sq Footage Total", Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    public ILocator OccupancySqFtLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Occupancy Sq Ft Limit", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    public ILocator Perils => _page.GetByRole(AriaRole.Combobox, new() { Name = "Perils", Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    public ILocator PersonalPropertyLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Personal Property Limit", Exact = true });

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=130
    public ILocator PersonalPropertyLimitCheckBoxAngular => _page.GetByTestId("fields.data.account.occupancy.rows[0].occupancyInput$includeBPP.value");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator PlumbingYear => _page.GetByTestId("fields.building.rows[0].buildingInput$plumbingYear.value");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=130
    public ILocator RCT => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$estimatorType.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator RateType1 => _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=100
    public ILocator ReplacementCost => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].riskInput$ratingBasisBuilding.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    public ILocator ResidenceCoverage => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Residence Coverage", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    public ILocator RoofImpact1 => _page.GetByRole(AriaRole.Combobox, new() { Name = "Roof Impact_1", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    public ILocator RoofType1 => _page.GetByRole(AriaRole.Combobox, new() { Name = "Roof Type_1", Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Review score=97
    public ILocator RoofTypeMain => _page.GetByLabel("Roof Type Main", new() { Exact = true });

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Review score=97
    public ILocator RoofTypeSelection => _page.GetByLabel("Roof Type Selection", new() { Exact = true });

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=127
    public ILocator RoofYear => _page.GetByRole(AriaRole.Textbox, new() { Name = "Roof Year", Exact = true });

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator SeasonalOrVacantNo => _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Additional Property Selections | confidence=High score=130
    public ILocator SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.building.rows[0].riskCoverages.rows[0].riskInput$amusementPlaygroundsPoolsNoneOfTheAbove.value");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=78
    public ILocator SelectIfClientOwnsOrRentsTheBuilding => _page.GetByLabel("Select if client owns or rents the building", new() { Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator SingleFamily => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | confidence=High score=130
    public ILocator SprinklerYes => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$sprinkler.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    public ILocator SquareFeet => _page.GetByRole(AriaRole.Textbox, new() { Name = "Square Feet", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=130
    public ILocator StandardRCTUseDefaults => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator WiringYear => _page.GetByTestId("fields.building.rows[0].buildingInput$wiringYear.value");

    // Source modules: EQ|BOP|Add Building|Building Details | confidence=High score=127
    public ILocator YearBuilt => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year Built", Exact = true });

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=127
    public ILocator YearBuiltRenovated => _page.GetByRole(AriaRole.Textbox, new() { Name = "Year Built - Renovated", Exact = true });

}
