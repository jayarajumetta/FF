using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BuildingsLocators
{
    private readonly IPage _page;
    public BuildingsLocators(IPage page) => _page = page;

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=130
    public ILocator ActualCashValue => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].riskInput$ratingBasisBuilding.value-chip-wrapper");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=114
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add a Note...Signature | Id
    public ILocator AddANote => _page.Locator("[id=\"note\"]");

    // Source modules: EQ|BOP|Add a Building Button | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Add a Building Button | + Add Building / BPP | Id
    public ILocator AddBuildingBPP => _page.Locator("[id=\"\"fields.data.accountDetail.locationDetail.rows[0].addBuildingButton\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence - Detail | Wiring Year | Id+Name+attributes_data-testid
    public ILocator AddResidenceHeader => _page.Locator("input[id=\"\\\"fields.building.rows[0].buildingInput$wiringYear.value\\\"\"][name=\"\\\"fields.building.rows[0].buildingInput$wiringYear.value\\\"\"][data-testid=\"\\\"fields.building.rows[0].buildingInput$wiringYear.value\\\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence | confidence=Medium score=113
    public ILocator AddResidenceToLocation => _page.GetByRole(AriaRole.Button, new() { Name = "+ Add Residence to Location", Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence - Detail | Additional Description | Id+Name
    public ILocator AdditionalDescription => _page.Locator("input[id=\"\\\"fields.building.rows[0].buildingInput$additionalDescription.value\\\"\"][name=\"\\\"fields.building.rows[0].buildingInput$additionalDescription.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | Roof Year | Id+Name
    public ILocator AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$roofYear.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$roofYear.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=130
    public ILocator BVSButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingValuatioinInput$estimatorType.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | BVS Group Combobox | Id
    public ILocator BVSGroup => _page.Locator("[id=\"\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value\"\"]");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | BVS Group Combobox | Id
    // v56 semantic alias: same physical raw-Tosca control as BVSGroup
    public ILocator BVSGroupCombobox => BVSGroup;

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | BVS Results Combobox | Id
    public ILocator BVSResult => _page.Locator("[id=\"\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSSearchResult.value\"\"]");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | BVS Results Combobox | Id
    // v56 semantic alias: same physical raw-Tosca control as BVSResult
    public ILocator BVSResultsCombobox => BVSResult;

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=130
    public ILocator Building => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].covBuilding.covBuildingInput$limit.value");

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|BOP|Building|Add Building|Building, Functional, Habitational | Windstorm Loss Mitigation checked | Id
    public ILocator BuildingContainsHabitationalOccupanciesChecked => _page.Locator("[id=\"\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$windstormLossMitigationSelect.value\"\"]");

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|BOP|Building|Add Building|Building, Functional, Habitational | Windstorm Loss Mitigation checked | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingContainsHabitationalOccupanciesChecked
    public ILocator BuildingContainsHabitationalOccupanciesUnchecked => BuildingContainsHabitationalOccupanciesChecked;

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=High score=100
    public ILocator BuildingCoverageAngular => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$includeBuildingCoverage.value");

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=97
    // v56 raw Tosca primary: EQ|BOP|Building|Building Details|Building Rating Basis | Building Details Heading | Id
    public ILocator BuildingDetailsHeading => _page.Locator("[id=\"BuildingPrivate.BuildingDetailsHeader-0-layout\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=108
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    public ILocator BuildingPhoto1 => _page.Locator("[id=\"add-note\"]");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto1Header => BuildingPhoto1;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto2 => BuildingPhoto1;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto2Header => BuildingPhoto1;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto3 => BuildingPhoto1;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto3Header => BuildingPhoto1;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto4 => BuildingPhoto1;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Add Note | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingPhoto1
    public ILocator BuildingPhoto4Header => BuildingPhoto1;

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=130
    public ILocator CheckBoxAngular => _page.GetByTestId("_temp.classCodeSelected.0");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=97
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | Class Codes | Id
    public ILocator ClassCodes => _page.Locator("[id=\"NAICSSearchPrivate.ClassCodesHeader-0-layout\"]");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=130
    public ILocator CommercialButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingValuatioinInput$structureType.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator DoesTheClientHaveASolidFuelHeatingTypeNo => _page.GetByTestId("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=130
    public ILocator DoesTheResidenceHaveAThermostaticallyControlledDeviceYes => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-chip-wrapper");

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | OK | Id
    public ILocator EChecklistEChecklistOK => _page.Locator("[id=\"exception-note-confirm\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    public ILocator EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions => _page.FrameLocator("iframe").Locator("[duckcreekid=\"NewTransactionReason.NewTransactionReasonDescription\"], [data-duckcreekid=\"NewTransactionReason.NewTransactionReasonDescription\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions
    public ILocator EQBOPBuildingBuildingDetailsSelectBurglarAlarm => EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions
    public ILocator EQBOPBuildingBuildingDetailsSelectPelletStove => EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions
    public ILocator EQBOPBuildingBuildingDetailsSelectWoodFurnace => EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    // v56 semantic alias: same physical raw-Tosca control as EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions
    public ILocator EQBOPBuildingBuildingDetailsSelectWoodStove => EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Exception | Id
    public ILocator Exception => _page.Locator("[id=\"exception\"]");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=High score=130
    public ILocator Frame => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$constructionCodeValuation.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|BOP|Building|Add Building|Building, Functional, Habitational | Windstorm Loss Mitigation checked | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingContainsHabitationalOccupanciesChecked
    public ILocator FunctionalPersonalPropertyChecked => BuildingContainsHabitationalOccupanciesChecked;

    // Source modules: EQ|BOP|Building|Add Building|Building, Functional, Habitational  | confidence=Medium score=83
    // v56 raw Tosca primary: EQ|BOP|Building|Add Building|Building, Functional, Habitational | Windstorm Loss Mitigation checked | Id
    // v56 semantic alias: same physical raw-Tosca control as BuildingContainsHabitationalOccupanciesChecked
    public ILocator FunctionalPersonalPropertyUnchecked => BuildingContainsHabitationalOccupanciesChecked;

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | Year Built | Id+Name
    public ILocator GetValuation => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$yearBuiltValuation.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$yearBuiltValuation.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | Gross Sales Receipts | Id+Name
    public ILocator GrossSalesReceipts => _page.Locator("input[id=\"\\\"fields.data.policy.line.risk.rows[0].covRiskLiability.rows[0].covRiskLiabilityInput$grossSalesReceipts.value\\\"\"][name=\"\\\"fields.data.policy.line.risk.rows[0].covRiskLiability.rows[0].covRiskLiabilityInput$grossSalesReceipts.value\\\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator HeatingYear => _page.GetByTestId("fields.building.rows[0].buildingInput$heatingYear.value");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence Covg | Insurance Amount | Id+Name
    public ILocator InsuranceAmount => _page.Locator("input[id=\"\\\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value\\\"\"][name=\"\\\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value\\\"\"]");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | Insured Occupancy Sq Ft | Id+Name
    public ILocator InsuredOccupancySqFt => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\\\"\"]");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=113
    // v56 raw Tosca primary: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | Insured Occupancy Sq Ft | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as InsuredOccupancySqFt
    public ILocator InsuredOccupancySqFtAngular => InsuredOccupancySqFt;

    // Source modules: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | confidence=High score=130
    public ILocator IsAnyHeatSourceThermostaticallyControlledYes => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$thermostaticallyControlled.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Heating Sources | confidence=High score=130
    public ILocator IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$noneOfTheAbove.value");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|BOP|Add Building|Building Details | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Add Building|Building Details | Number of Stories | Id+Name
    public ILocator NumberOfStories => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$numberOfStories.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$numberOfStories.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=97
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | Occupancy SQ FT Heading | Id
    public ILocator OccupancySQFTHeading => _page.Locator("[id=\"undefined\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | Occupancy Sq Footage Total | Id+Name
    public ILocator OccupancySqFootageTotal => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingPrivate$occupancySqFtTotal.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingPrivate$occupancySqFtTotal.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | Occupancy Sq Ft Limit | Id+Name
    public ILocator OccupancySqFtLimit => _page.Locator("input[id=\"\\\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\\\"\"][name=\"\\\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\\\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence Covg | Perils | Id
    public ILocator Perils => _page.Locator("[id=\"\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$perilGroup.value\"\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | Personal Property Limit | Id+Name
    public ILocator PersonalPropertyLimit => _page.Locator("input[id=\"\\\"fields.data.policy.line.risk.rows[0].covPersonalProperty.rows[0].covPersonalPropertyInput$limit.value\\\"\"][name=\"\\\"fields.data.policy.line.risk.rows[0].covPersonalProperty.rows[0].covPersonalPropertyInput$limit.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code(s) | confidence=High score=130
    public ILocator PersonalPropertyLimitCheckBoxAngular => _page.GetByTestId("fields.data.account.occupancy.rows[0].occupancyInput$includeBPP.value");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator PlumbingYear => _page.GetByTestId("fields.building.rows[0].buildingInput$plumbingYear.value");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=130
    public ILocator RCT => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$estimatorType.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator RateType1 => _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=100
    public ILocator ReplacementCost => ActualCashValue; // semantic alias; locator defined once

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence - Detail | Residence Coverage | Id+Name
    public ILocator ResidenceCoverage => _page.Locator("input[id=\"\\\"fields.risk.rows[0].riskInput$eQResidenceCoverage.value-checkbox\\\"\"][name=\"\\\"fields.risk.rows[0].riskInput$eQResidenceCoverage.value\\\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence - Detail | Roof Impact_1 | Id
    public ILocator RoofImpact1 => _page.Locator("[id=\"\"fields.building.rows[0].buildingInput$roofImpactResistance.value\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence - Detail | Roof Type_1 | Id
    public ILocator RoofType1 => _page.Locator("[id=\"\"fields.building.rows[0].buildingInput$roofType.value\"\"]");

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Review score=97
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | Year Built | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as GetValuation
    public ILocator RoofTypeMain => GetValuation;

    // Source modules: EQ|BOP|Building|Cost Estimator | confidence=Review score=97
    // v56 raw Tosca primary: EQ|BOP|Building|Cost Estimator | Year Built | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as GetValuation
    public ILocator RoofTypeSelection => GetValuation;

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Building Details|Building Rating Basis | Roof Year | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes
    public ILocator RoofYear => AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes;

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator SeasonalOrVacantNo => _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Additional Property Selections | confidence=High score=130
    public ILocator SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.building.rows[0].riskCoverages.rows[0].riskInput$amusementPlaygroundsPoolsNoneOfTheAbove.value");

    // Source modules: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | confidence=Medium score=78
    // v56 raw Tosca primary: EQ|BOP|Building |Add Building|Own Rent & Sq Footage | Total Building Sq. Footage | Id+Name
    public ILocator SelectIfClientOwnsOrRentsTheBuilding => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\\\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator SingleFamily => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-chip-wrapper");

    // Source modules: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | confidence=High score=130
    public ILocator SprinklerYes => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$sprinkler.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Div I - Add Residence|Add Residence Covg | Square Feet | Id+Name
    public ILocator SquareFeet => _page.Locator("input[id=\"\\\"fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$squareFt.value\\\"\"][name=\"\\\"fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$squareFt.value\\\"\"]");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence Covg | confidence=High score=130
    public ILocator StandardRCTUseDefaults => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-chip-wrapper");

    // Source modules: EQ|SFP|Div I - Add Residence|Add Residence - Detail | confidence=High score=130
    public ILocator WiringYear => _page.GetByTestId("fields.building.rows[0].buildingInput$wiringYear.value");

    // Source modules: EQ|BOP|Add Building|Building Details | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Add Building|Building Details | Year Built | Id+Name
    public ILocator YearBuilt => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$yearBuilt.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$yearBuilt.value\\\"\"]");

    // Source modules: EQ|BOP|Building|Building Details|Building Rating Basis | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Building|Building Details|Building Rating Basis | Year Built - Renovated | Id+Name
    public ILocator YearBuiltRenovated => _page.Locator("input[id=\"\\\"fields.data.account.building.rows[0].buildingInput$yearRenovated.value\\\"\"][name=\"\\\"fields.data.account.building.rows[0].buildingInput$yearRenovated.value\\\"\"]");

}
