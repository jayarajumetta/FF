using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class BuildingsLocators
{
    private readonly IPage _page;
    public BuildingsLocators(IPage page) => _page = page;

    public ILocator ActualCashValue => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].riskInput$ratingBasisBuilding.value-chip-wrapper");

    public ILocator AddANote => _page.Locator("[id=\"note\"]");

    public ILocator AddBuildingBPP => _page.Locator("[id=\"fields.data.accountDetail.locationDetail.rows[0].addBuildingButton\"], button:has([data-testid=\"fields.data.accountDetail.locationDetail.rows[0].addBuildingButton-button-label\"])").First;

    public ILocator AddResidenceHeader => _page.Locator("input[id=\"fields.building.rows[0].buildingInput$wiringYear.value\"][name=\"fields.building.rows[0].buildingInput$wiringYear.value\"][data-testid=\"fields.building.rows[0].buildingInput$wiringYear.value\"]");

    public ILocator AddResidenceToLocation => _page.GetByRole(AriaRole.Button, new() { Name = "+ Add Residence to Location", Exact = true });

    public ILocator AdditionalDescription => _page.Locator("input[id=\"fields.building.rows[0].buildingInput$additionalDescription.value\"][name=\"fields.building.rows[0].buildingInput$additionalDescription.value\"]");

    public ILocator AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$roofYear.value\"][name=\"fields.data.account.building.rows[0].buildingInput$roofYear.value\"]");

    public ILocator BVSButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingValuatioinInput$estimatorType.value-chip-label").Filter(new LocatorFilterOptions { HasText = "BVS" });

    public ILocator BVSGroup => _page.Locator("input[id=\"_temp.fields.data.account.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value\"], input[data-testid=\"_temp.fields.data.account.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value\"], input[id=\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value\"], input[data-testid=\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSOccupancyGroup.value\"]").First;


    public ILocator BVSResult => _page.Locator("input[id=\"_temp.fields.data.account.building.rows[0].buildingValuatioinInput$bVSSearchResult.value\"], input[data-testid=\"_temp.fields.data.account.building.rows[0].buildingValuatioinInput$bVSSearchResult.value\"], input[id=\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSSearchResult.value\"], input[data-testid=\"fields.data.account.building.rows[0].buildingValuatioinInput$bVSSearchResult.value\"]").First;

    public ILocator RoofTypeValuation => _page.Locator("input[id=\"_temp.fields.data.account.building.rows[0].buildingInput$roofTypeValuation.value\"], input[data-testid=\"_temp.fields.data.account.building.rows[0].buildingInput$roofTypeValuation.value\"], input[id=\"fields.data.account.building.rows[0].buildingInput$roofTypeValuation.value\"], input[data-testid=\"fields.data.account.building.rows[0].buildingInput$roofTypeValuation.value\"], mat-select[id=\"fields.data.account.building.rows[0].buildingInput$roofTypeValuation.value\"], mat-select[data-testid=\"fields.data.account.building.rows[0].buildingInput$roofTypeValuation.value\"]").First;


    public ILocator Building => _page.GetByTestId("fields.data.account.building.rows[0].risk.rows[0].covBuilding.covBuildingInput$limit.value");

    public ILocator BuildingContainsHabitationalOccupanciesChecked => _page.Locator("[id=\"fields.data.account.building.rows[0].buildingWindstormLossMitigationInput$windstormLossMitigationSelect.value\"]");


    public ILocator BuildingCoverageAngular => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$includeBuildingCoverage.value-checkbox\"]");

    public ILocator BuildingDetailsHeading => _page.Locator("[id=\"BuildingPrivate.BuildingDetailsHeader-0-layout\"]");

    public ILocator BuildingPhoto1 => _page.Locator("[id=\"add-note\"]");








    public ILocator ClassCodeCheckbox => _page.Locator("input[id=\"_temp.classCodeSelected.0-checkbox\"]");

    public ILocator ClassCodes => _page.Locator("[id=\"NAICSSearchPrivate.ClassCodesHeader-0-layout\"]");

    public ILocator CommercialButton => _page.GetByTestId("fields.data.account.building.rows[0].buildingValuatioinInput$structureType.value-chip-label").Filter(new LocatorFilterOptions { HasText = "Commercial" });

    public ILocator DoesTheClientHaveASolidFuelHeatingTypeNo => _page.GetByTestId("fields.building_SolidFuel.rows[0].buildingInput$solidFuelHeatingDevices.value-chip-wrapper");

    public ILocator DoesTheResidenceHaveAThermostaticallyControlledDeviceYes => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-chip-wrapper");

    public ILocator EChecklistEChecklistOK => _page.Locator("[id=\"exception-note-confirm\"]");

    public ILocator EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions => _page.GetByRole(AriaRole.Textbox, new() { Name = "Detail", Exact = true }).First;





    public ILocator Exception => _page.Locator("[id=\"exception\"]");

    public ILocator Frame => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$constructionCodeValuation.value-chip-label").Filter(new LocatorFilterOptions { HasText = "Frame" });



    public ILocator GetValuation => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$yearBuiltValuation.value\"][name=\"fields.data.account.building.rows[0].buildingInput$yearBuiltValuation.value\"]");

    public ILocator GetValuationButton => _page.GetByTestId("fields.data.account.building.rows[0].get Valuation-button-label");

    public ILocator GrossSalesReceipts => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].covRiskLiability.rows[0].covRiskLiabilityInput$grossSalesReceipts.value\"][name=\"fields.data.policy.line.risk.rows[0].covRiskLiability.rows[0].covRiskLiabilityInput$grossSalesReceipts.value\"]");

    public ILocator HeatingYear => _page.Locator("input[id=\"fields.data.account.building.rows[0].propertyInformation$heatingYear.value\"][name=\"fields.data.account.building.rows[0].propertyInformation$heatingYear.value\"]");

    public ILocator InsuranceAmount => _page.Locator("input[id=\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value\"][name=\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value\"]");

    public ILocator InsuredOccupancySqFt => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\"][name=\"fields.data.account.building.rows[0].buildingInput$insuredOccupancySqFt.value\"]");


    public ILocator IsAnyHeatSourceThermostaticallyControlledYes => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$thermostaticallyControlled.value-chip-label").Filter(new LocatorFilterOptions { HasText = "Yes" });

    public ILocator IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$noneOfTheAbove.value-checkbox\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator NumberOfStories => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$numberOfStories.value\"][name=\"fields.data.account.building.rows[0].buildingInput$numberOfStories.value\"]");

    public ILocator OccupancySQFTHeading => _page.GetByText("Occupancy SQ FT", new() { Exact = true });

    public ILocator OccupancySqFootageTotal => _page.Locator("input[id=\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\"][data-testid=\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\"]");

    public ILocator OccupancySqFtLimit => _page.Locator("input[id=\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\"][name=\"fields.data.account.occupancy.rows[0].occupancyOutput$bOP_SquareFootage.value\"]");

    public ILocator Perils => _page.Locator("[id=\"fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$perilGroup.value\"]");

    public ILocator PersonalPropertyLimit => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].covPersonalProperty.rows[0].covPersonalPropertyInput$limit.value\"][name=\"fields.data.policy.line.risk.rows[0].covPersonalProperty.rows[0].covPersonalPropertyInput$limit.value\"]");

    public ILocator PersonalPropertyLimitCheckBoxAngular => _page.Locator("input[id=\"fields.data.account.occupancy.rows[0].occupancyInput$includeBPP.value-checkbox\"]");

    public ILocator PlumbingYear => _page.Locator("input[id=\"fields.data.account.building.rows[0].propertyInformation$plumbingYear.value\"][name=\"fields.data.account.building.rows[0].propertyInformation$plumbingYear.value\"]");

    public ILocator RCT => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$estimatorType.value-chip-wrapper");

    public ILocator RateType1 => _page.GetByTestId("fields.building.rows[0].buildingInput$rateType.value-chip-wrapper");


    public ILocator ResidenceCoverage => _page.Locator("input[id=\"fields.risk.rows[0].riskInput$eQResidenceCoverage.value-checkbox\"][name=\"fields.risk.rows[0].riskInput$eQResidenceCoverage.value\"]");

    public ILocator RoofImpact1 => _page.Locator("[id=\"fields.building.rows[0].buildingInput$roofImpactResistance.value\"]");

    public ILocator RoofType1 => _page.Locator("input[id=\"_temp.fields.data.account.building.rows[0].buildingInput$roofType.value\"], input[data-testid=\"_temp.fields.data.account.building.rows[0].buildingInput$roofType.value\"], input[id=\"fields.data.account.building.rows[0].buildingInput$roofType.value\"], input[data-testid=\"fields.data.account.building.rows[0].buildingInput$roofType.value\"], mat-select[id=\"fields.data.account.building.rows[0].buildingInput$roofType.value\"], mat-select[data-testid=\"fields.data.account.building.rows[0].buildingInput$roofType.value\"]").First;




    public ILocator Save => _page.Locator("button[id=\"fields.data.saveBuilding\"], [data-testid=\"fields.data.saveBuilding-button-label\"], button[id=\"fields.data.save\"], button[data-testid=\"fields.line.save\"], button:has-text(\"Save\"), a:has-text(\"Save\")").Filter(new LocatorFilterOptions { HasText = "Save" }).First;

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator SeasonalOrVacantNo => _page.GetByTestId("fields.building.rows[0].buildingInput$eQVacantSeasonal.value-chip-wrapper");

    public ILocator SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular => _page.Locator("input[id=\"fields.data.account.building.rows[0].riskCoverages.rows[0].riskInput$amusementPlaygroundsPoolsNoneOfTheAbove.value-checkbox\"]");

    public ILocator SelectIfClientOwnsOrRentsTheBuilding => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\"][name=\"fields.data.account.building.rows[0].buildingInput$squareFtEq.value\"]");

    public ILocator SingleFamily => _page.GetByTestId("fields.building.rows[0].buildingInput$eQNumberOfFamilies.value-chip-wrapper");

    public ILocator SprinklerYes => _page.GetByTestId("fields.data.account.building.rows[0].buildingInput$sprinkler.value-chip-label").Filter(new LocatorFilterOptions { HasText = "Yes" });

    public ILocator SquareFeet => _page.Locator("input[id=\"fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$squareFt.value\"][name=\"fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$squareFt.value\"]");

    public ILocator StandardRCTUseDefaults => _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-chip-wrapper");

    public ILocator WiringYear => _page.Locator("input[id=\"fields.data.account.building.rows[0].propertyInformation$wiringYear.value\"][name=\"fields.data.account.building.rows[0].propertyInformation$wiringYear.value\"]");

    public ILocator YearBuilt => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$yearBuilt.value\"][name=\"fields.data.account.building.rows[0].buildingInput$yearBuilt.value\"]");

    public ILocator YearBuiltRenovated => _page.Locator("input[id=\"fields.data.account.building.rows[0].buildingInput$yearRenovated.value\"][name=\"fields.data.account.building.rows[0].buildingInput$yearRenovated.value\"]");

}
