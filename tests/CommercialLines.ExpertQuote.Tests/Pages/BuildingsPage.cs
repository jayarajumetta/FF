using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class BuildingsPage
{
    private readonly BuildingsLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public BuildingsPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new BuildingsLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I add a Residence
    public async Task AddAResidenceAsync()
    {
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIClickAddResidence_0145_503012Async
        await _ui.ClickAsync(_locators.AddResidenceToLocation);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0146_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0147_503012Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.AdditionalDescription, "POST:CTRL+A");
        await _ui.PressAsync(_locators.AdditionalDescription, "CTRL+A");
        await _ui.PressAsync(_locators.AdditionalDescription, "Enter");
        await _ui.PressAsync(_locators.AdditionalDescription, "Tab");
        await _ui.PressAsync(_locators.Frame, "POST:TAB");
        await _ui.PressAsync(_locators.Frame, "Tab");
        await _ui.PressAsync(_locators.SingleFamily, "POST:TAB");
        await _ui.PressAsync(_locators.SingleFamily, "Tab");
        await _ui.PressAsync(_locators.YearBuilt, "POST:CTRL+A");
        await _ui.PressAsync(_locators.YearBuilt, "CTRL+A");
        await _ui.PressAsync(_locators.YearBuilt, "Enter");
        await _ui.PressAsync(_locators.YearBuilt, "Tab");
        // CLEQSFPLocationAddAResidence_51048bPage.TBoxWait1_0148_503012Async
        await Task.Delay(1000);
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0149_503012Async
        await _ui.PressAsync(_locators.PlumbingYear, "POST:TAB");
        await _ui.PressAsync(_locators.PlumbingYear, "Tab");
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0150_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0151_503012Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.RateType1, "POST:TAB");
        await _ui.PressAsync(_locators.RateType1, "Tab");
        await _ui.PressAsync(_locators.RoofYear, "POST:CTRL+A");
        await _ui.PressAsync(_locators.RoofYear, "CTRL+A");
        await _ui.PressAsync(_locators.RoofYear, "Enter");
        await _ui.PressAsync(_locators.RoofYear, "Tab");
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0152_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0153_503012Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.FillAsync(_locators.RoofType1, _data.Resolve("{{data:roof_type_1_189}}"));
        await _ui.FillAsync(_locators.RoofImpact1, _data.Resolve("{{data:roof_impact_1_190}}"));
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0154_503012Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.RoofYear, "POST:TAB");
        await _ui.PressAsync(_locators.RoofYear, "Tab");
        await _ui.PressAsync(_locators.RoofYear, "SCROLL[2]");
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0155_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0156_503012Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.ResidenceCoverage, "POST:TAB");
        await _ui.PressAsync(_locators.ResidenceCoverage, "Tab");
        await _ui.PressAsync(_locators.ResidenceCoverage, "SCROLL[-3]");
        // CLEQSFPLocationAddAResidence_51048bPage.TBoxWait_0157_503012Async
        await Task.Delay(1000);
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0158_503012Async
        await _ui.ClickAsync(_locators.DoesTheClientHaveASolidFuelHeatingTypeNo);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0159_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0160_503012Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.ResidenceCoverage, "POST:TAB");
        await _ui.PressAsync(_locators.ResidenceCoverage, "Tab");
        await _ui.ClickAsync(_locators.ResidenceCoverage);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0161_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I add Residence Covg
    public async Task AddResidenceCovgAsync()
    {
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0162_503012Async
        await _ui.VerifyAsync(_locators.ResidenceCoverage, _data.Resolve("{{data:expected_residence_coverage_203}}"), "");
        await _ui.PressAsync(_locators.InsuranceAmount, "POST:ENTER");
        await _ui.PressAsync(_locators.InsuranceAmount, "Enter");
        await _ui.PressAsync(_locators.InsuranceAmount, "Tab");
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0163_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0164_503012Async
        await _ui.PressAsync(_locators.SquareFeet, "POST:ENTER");
        await _ui.PressAsync(_locators.SquareFeet, "Enter");
        await _ui.PressAsync(_locators.SquareFeet, "Tab");
        await _ui.PressAsync(_locators.ActualCashValue, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.ActualCashValue, "SHIFTTAB");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0165_503012Async
        await _ui.PressAsync(_locators.DoesTheResidenceHaveAThermostaticallyControlledDeviceYes, "POST:TAB");
        await _ui.PressAsync(_locators.DoesTheResidenceHaveAThermostaticallyControlledDeviceYes, "Tab");
        await _ui.FillAsync(_locators.ActualCashValue, _data.Resolve("{{data:actual_cash_value_209}}"));
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0166_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0167_503012Async
        await _ui.PressAsync(_locators.Save, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.Save, "SHIFTTAB");
        await _ui.PressAsync(_locators.Save, "SCROLL[-1]");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0168_503012Async
        await _ui.ClickAsync(_locators.RCT);
        await _ui.ClickAsync(_locators.StandardRCTUseDefaults);
        await _ui.ClickAsync(_locators.GetValuation);
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0169_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0170_503012Async
        await _ui.ClickAsync(_locators.Save);
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0171_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0172_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_7}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0173_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I add a Building Button
    public async Task AddABuildingButtonAsync()
    {
        // EQBOPBuildingAddABuildingButton_049872Page.EQBOPSelectAddABuildingButton_0169_d18a3eAsync
        await _ui.ClickAsync(_locators.AddBuildingBPP);
    }

    // Business step: I select Additional Coverages \- Building, Functional Personal Property or Habitational
    public async Task SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitationalAsync()
    {
        // EQBOPBuilding2SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitational_eb7ffcPage.EQBOPBuildingSelectBuildingContainsHabitationalOccupancies_0177_d18a3eAsync
        await _ui.WaitAsync(_locators.SelectIfClientOwnsOrRentsTheBuilding, "Visible");
        if (_data.Condition("'Select Building Coverage' == \"Building Coverage\""))
        {
        await _ui.PressAsync(_locators.BuildingCoverageAngular, "POST:TAB");
        await _ui.PressAsync(_locators.BuildingCoverageAngular, "Tab");
        }
        if (_data.Condition("'Select Functional Personal Property' == \"Include Functional Personal Property\""))
        {
        await _ui.PressAsync(_locators.FunctionalPersonalPropertyUnchecked, "POST:ENTER");
        await _ui.PressAsync(_locators.FunctionalPersonalPropertyUnchecked, "Enter");
        }
        if (_data.Condition("'Select Building contains habitational occupancy' == \"Building contains habitational occupancies\""))
        {
        await _ui.PressAsync(_locators.BuildingContainsHabitationalOccupanciesUnchecked, "POST:ENTER");
        await _ui.PressAsync(_locators.BuildingContainsHabitationalOccupanciesUnchecked, "Enter");
        }
        if (_data.Condition("'Select Functional Personal Property' == \"Include Functional Personal Property\""))
        {
        await _ui.WaitAsync(_locators.FunctionalPersonalPropertyChecked, "Visible");
        }
        if (_data.Condition("'Select Building contains habitational occupancy' == \"Building contains habitational occupancies\""))
        {
        await _ui.WaitAsync(_locators.BuildingContainsHabitationalOccupanciesChecked, "Visible");
        }
        // EQBOPBuilding2SelectAdditionalCoveragesBuildingFunctionalPersonalPropertyOrHabitational_eb7ffcPage.EQLoadingIndicatorWait_0178_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding3SelectOccupancySQFootage_3d47fdPage.EQLoadingIndicatorWait_0183_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I select Occupancy SQ Footage
    public async Task SelectOccupancySQFootageAsync()
    {
        // EQBOPBuilding3SelectOccupancySQFootage_3d47fdPage.EQBOPBuildingAddBuildingFillOutInsuredOccupancy_0184_d18a3eAsync
        await _ui.FillAsync(_locators.InsuredOccupancySqFt, _data.Resolve(""));
        await _ui.FillAsync(_locators.InsuredOccupancySqFt, _data.Resolve(""));
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "POST:TAB");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "Tab");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "POST:CTRL+A");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "CTRL+A");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "Enter");
        await _ui.PressAsync(_locators.InsuredOccupancySqFtAngular, "Tab");
        // EQBOPBuilding3SelectOccupancySQFootage_3d47fdPage.EQLoadingIndicatorWait_0185_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I enter supplimental data\- for class
    public async Task EnterSupplimentalDataForClassAsync()
    {
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQBOPBuildingClassEnterSupplementalDataForClassSelectCheckbox_0186_d18a3eAsync
        await _ui.WaitAsync(_locators.ClassCodes, "Exists");
        await _ui.WaitAsync(_locators.CheckBoxAngular, "Exists");
        await _ui.PressAsync(_locators.CheckBoxAngular, "POST:TAB");
        await _ui.PressAsync(_locators.CheckBoxAngular, "Tab");
        await _ui.ClickAsync(_locators.CheckBoxAngular);
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQLoadingIndicatorWait_0187_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQBOPBuildingClassEnterSupplementalDataForClassEnterOccSqFtLimit_0188_d18a3eAsync
        await _ui.WaitAsync(_locators.OccupancySQFTHeading, "Exists");
        await _ui.PressAsync(_locators.OccupancySqFtLimit, "POST:ENTER");
        await _ui.PressAsync(_locators.OccupancySqFtLimit, "Enter");
        await _ui.PressAsync(_locators.OccupancySqFtLimit, "Tab");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQLoadingIndicatorWait_0189_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQBOPBuildingClassEnterSupplementalDataForClassVerifyOccSqFtTotal_0190_d18a3eAsync
        await _ui.VerifyAsync(_locators.OccupancySqFootageTotal, _data.Resolve("{{data:expected_occupancy_sq_footage_total_value_227}}"), "Value");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQLoadingIndicatorWait_0191_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQBOPBuildingClassEnterSupplementalDataForSelectedClassSelectPersonalPropertyLimiytCheckbox_0192_d18a3eAsync
        await _ui.WaitAsync(_locators.PersonalPropertyLimitCheckBoxAngular, "Exists");
        await _ui.PressAsync(_locators.PersonalPropertyLimitCheckBoxAngular, "POST:TAB");
        await _ui.PressAsync(_locators.PersonalPropertyLimitCheckBoxAngular, "Tab");
        await _ui.ClickAsync(_locators.PersonalPropertyLimitCheckBoxAngular);
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQLoadingIndicatorWait_0193_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQBOPBuildingClassEnterSupplementalDataForSelectedClassSelectPersonalPropertyLimit_0194_d18a3eAsync
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "POST:ENTER");
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "Enter");
        await _ui.PressAsync(_locators.PersonalPropertyLimit, "Tab");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQLoadingIndicatorWait_0195_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding11ClassEnterSupplimentalDataForClass_f3dd4cPage.EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeSelectGrossSalesLimit_0196_d18a3eAsync
        await _ui.PressAsync(_locators.GrossSalesReceipts, "POST:ENTER");
        await _ui.PressAsync(_locators.GrossSalesReceipts, "Enter");
        await _ui.PressAsync(_locators.GrossSalesReceipts, "Tab");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.SetBuffersForBVS_0197_d18a3eAsync
        _data.Set("BVS Group", _data.Resolve("{{data:bvs_group}}"));
        _data.Set("BVS Result", _data.Resolve("{{data:bvs_result}}"));
        _data.Set("Roof Type", _data.Resolve("{{data:roof_type}}"));
    }

    // Business step: I select Cost Estimator \& Calculate Valuations
    public async Task SelectCostEstimatorCalculateValuationsAsync()
    {
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectCommercialType_0198_d18a3eAsync
        await _ui.PressAsync(_locators.CommercialButton, "POST:TAB");
        await _ui.PressAsync(_locators.CommercialButton, "Tab");
        await _ui.ClickAsync(_locators.CommercialButton);
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0199_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectEstimatorType_0200_d18a3eAsync
        await _ui.PressAsync(_locators.BVSButton, "POST:TAB");
        await _ui.PressAsync(_locators.BVSButton, "Tab");
        await _ui.ClickAsync(_locators.BVSButton);
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0201_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectStructureType_0202_d18a3eAsync
        await _ui.PressAsync(_locators.Frame, "POST:TAB");
        await _ui.PressAsync(_locators.Frame, "Tab");
        await _ui.ClickAsync(_locators.Frame);
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0203_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectBVSOccupancyGroup_0204_d18a3eAsync
        await _ui.PressAsync(_locators.BVSGroupCombobox, "POST:TAB");
        await _ui.PressAsync(_locators.BVSGroupCombobox, "Tab");
        await _ui.ClickAsync(_locators.BVSGroup);
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0206_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectBVSSearchResult_0207_d18a3eAsync
        await _ui.PressAsync(_locators.BVSResultsCombobox, "POST:TAB");
        await _ui.PressAsync(_locators.BVSResultsCombobox, "Tab");
        await _ui.ClickAsync(_locators.BVSResult);
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0209_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectYear_0210_d18a3eAsync
        await _ui.PressAsync(_locators.YearBuilt, "POST:TAB");
        await _ui.PressAsync(_locators.YearBuilt, "Tab");
        await _ui.PressAsync(_locators.YearBuilt, "POST:ENTER");
        await _ui.PressAsync(_locators.YearBuilt, "Enter");
        await _ui.PressAsync(_locators.YearBuilt, "Tab");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0211_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQBOPBuildingSelectRoofTypeGetEvaluation_0212_d18a3eAsync
        await _ui.PressAsync(_locators.RoofTypeMain, "POST:TAB");
        await _ui.PressAsync(_locators.RoofTypeMain, "Tab");
        await _ui.ClickAsync(_locators.RoofTypeSelection);
        await _ui.PressAsync(_locators.GetValuation, "POST:TAB");
        await _ui.PressAsync(_locators.GetValuation, "Tab");
        await _ui.ClickAsync(_locators.GetValuation);
        // EQBOPBuilding18SelectCostEstimatorCalculateValuations_d32accPage.EQLoadingIndicatorWait_0213_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I select Building Detail Fields
    public async Task SelectBuildingDetailFieldsAsync()
    {
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingRepositionMouseForScrollDown_0214_d18a3eAsync
        await _ui.PressAsync(_locators.NumberOfStories, "POST:TAB");
        await _ui.PressAsync(_locators.NumberOfStories, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingSelectRatingBasis_0216_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingDetailsHeading, "Exists");
        if (_data.Condition("'Actual Cash Value' != NULL"))
        {
        await _ui.PressAsync(_locators.ActualCashValue, "POST:TAB");
        await _ui.PressAsync(_locators.ActualCashValue, "Tab");
        }
        if (_data.Condition("'Actual Cash Value' != NULL"))
        {
        await _ui.ClickAsync(_locators.ActualCashValue);
        }
        if (_data.Condition("'Replacement Cost' != NULL"))
        {
        await _ui.PressAsync(_locators.ReplacementCost, "POST:TAB");
        await _ui.PressAsync(_locators.ReplacementCost, "Tab");
        }
        if (_data.Condition("'Replacement Cost' != NULL"))
        {
        await _ui.ClickAsync(_locators.ReplacementCost);
        }
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0217_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.WaitForBuildingLimitToBecomeAvailable_0218_d18a3eAsync
        await Task.Delay(1000);
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingSelectBuildingOrFunctionalLimitAndYearRenovated_0219_d18a3eAsync
        await _ui.PressAsync(_locators.Building, "POST:ENTER");
        await _ui.PressAsync(_locators.Building, "Enter");
        await _ui.PressAsync(_locators.Building, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0220_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingSelectYearRenovatedBuilt_0221_d18a3eAsync
        await _ui.PressAsync(_locators.YearBuiltRenovated, "POST:CTRL+A");
        await _ui.PressAsync(_locators.YearBuiltRenovated, "CTRL+A");
        await _ui.PressAsync(_locators.YearBuiltRenovated, "POST:DELETE");
        await _ui.PressAsync(_locators.YearBuiltRenovated, "Delete");
        await _ui.PressAsync(_locators.YearBuiltRenovated, "POST:ENTER");
        await _ui.PressAsync(_locators.YearBuiltRenovated, "Enter");
        await _ui.PressAsync(_locators.YearBuiltRenovated, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0222_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0224_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingSelectWiringYear_0225_d18a3eAsync
        await _ui.PressAsync(_locators.WiringYear, "POST:CTRL+A");
        await _ui.PressAsync(_locators.WiringYear, "CTRL+A");
        await _ui.PressAsync(_locators.WiringYear, "POST:DELETE");
        await _ui.PressAsync(_locators.WiringYear, "Delete");
        await _ui.PressAsync(_locators.WiringYear, "POST:ENTER");
        await _ui.PressAsync(_locators.WiringYear, "Enter");
        await _ui.PressAsync(_locators.WiringYear, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0226_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingSelectHeatingYear_0227_d18a3eAsync
        await _ui.PressAsync(_locators.HeatingYear, "POST:CTRL+A");
        await _ui.PressAsync(_locators.HeatingYear, "CTRL+A");
        await _ui.PressAsync(_locators.HeatingYear, "POST:DELETE");
        await _ui.PressAsync(_locators.HeatingYear, "Delete");
        await _ui.PressAsync(_locators.HeatingYear, "POST:ENTER");
        await _ui.PressAsync(_locators.HeatingYear, "Enter");
        await _ui.PressAsync(_locators.HeatingYear, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0228_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingSelectPlumbingYear_0229_d18a3eAsync
        await _ui.PressAsync(_locators.PlumbingYear, "POST:CTRL+A");
        await _ui.PressAsync(_locators.PlumbingYear, "CTRL+A");
        await _ui.PressAsync(_locators.PlumbingYear, "POST:DELETE");
        await _ui.PressAsync(_locators.PlumbingYear, "Delete");
        await _ui.PressAsync(_locators.PlumbingYear, "POST:ENTER");
        await _ui.PressAsync(_locators.PlumbingYear, "Enter");
        await _ui.PressAsync(_locators.PlumbingYear, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingBuildingDetailsSelectBurglarAlarm_0230_d18a3eAsync
        await _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsSelectBurglarAlarm, _data.Resolve("Exists"), "");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0231_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingBuildingDetailsSelectRoofYear_0232_d18a3eAsync
        await _ui.PressAsync(_locators.RoofYear, "POST:ENTER");
        await _ui.PressAsync(_locators.RoofYear, "Enter");
        await _ui.PressAsync(_locators.RoofYear, "Tab");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0233_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingBuildingDetailsSelectSprinkler_0234_d18a3eAsync
        await _ui.SelectAsync(_locators.SprinklerYes, _data.Resolve(""));
        await _ui.WaitAsync(_locators.SprinklerYes, "Visible");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0235_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingBuildingDetailsSelectAnsulSystemForRestaurantClass_0237_d18a3eAsync
        if (_data.Condition("ANSUL != NULL"))
        {
        await _ui.SelectAsync(_locators.AutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYes, _data.Resolve(""));
        }
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0238_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0245_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQBOPBuildingBuildingDetailsSelectIfThermostaticallyControlled_0248_d18a3eAsync
        await _ui.SelectAsync(_locators.IsAnyHeatSourceThermostaticallyControlledYes, _data.Resolve(""));
        // EQBOPBuilding19SelectBuildingDetailFields_fd996aPage.EQLoadingIndicatorWait_0249_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQLoadingIndicatorWait_0250_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I select Heating Sources
    public async Task SelectHeatingSourcesAsync()
    {
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQBOPBuildingBuildingDetailsSelectCoalFurnace_0251_d18a3eAsync
        await _ui.PressAsync(_locators.IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular, "POST:TAB");
        await _ui.PressAsync(_locators.IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular, "Tab");
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQBOPBuildingBuildingDetailsSelectPelletStove_0252_d18a3eAsync
        await _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsSelectPelletStove, _data.Resolve("Exists"), "");
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQBOPBuildingBuildingDetailsSelectWoodFurnace_0253_d18a3eAsync
        await _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsSelectWoodFurnace, _data.Resolve("Exists"), "");
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQBOPBuildingBuildingDetailsSelectWoodStove_0254_d18a3eAsync
        await _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsSelectWoodStove, _data.Resolve("Exists"), "");
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQBOPBuildingBuildingDetailsSelectNoneOfTheAbove_0255_d18a3eAsync
        await _ui.PressAsync(_locators.IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular, "POST:TAB");
        await _ui.PressAsync(_locators.IsTheBuildingHeatedWithOneOfTheFollowingNoneOfTheAboveCheckboxAngular, "Tab");
        // EQBOPBuilding20BuildingDetailsSelectHeatingSources_b2b9ecPage.EQLoadingIndicatorWait_0256_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding21BuildingDetailsSelectAdditionalPropertyCheckboxesExtraPropertyRisk_94a52aPage.EQLoadingIndicatorWait_0257_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I complete extra Property Risk
    public async Task CompleteExtraPropertyRiskAsync()
    {
        // EQBOPBuilding21BuildingDetailsSelectAdditionalPropertyCheckboxesExtraPropertyRisk_94a52aPage.EQBOPBuildingBuildingDetailsSelectExtraPropertyRisk_0258_d18a3eAsync
        await _ui.PressAsync(_locators.SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular, "POST:TAB");
        await _ui.PressAsync(_locators.SelectAnyOfTheFollowingWhichApplyToThisBuildingNoneOfTheAboveCheckboxAngular, "Tab");
        // EQBOPBuilding21BuildingDetailsSelectAdditionalPropertyCheckboxesExtraPropertyRisk_94a52aPage.EQLoadingIndicatorWait_0259_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPBuilding21BuildingDetailsSelectAdditionalPropertyCheckboxesExtraPropertyRisk_94a52aPage.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions_0260_d18a3eAsync
        await _ui.VerifyAsync(_locators.EQBOPBuildingBuildingDetailsAnswerAnyExtraPropertyAdditionalQuestions, _data.Resolve("Exists"), "");
        // EQBOPBuilding21BuildingDetailsSelectAdditionalPropertyCheckboxesExtraPropertyRisk_94a52aPage.EQCommonLoadingIndicatorWait_0261_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I complete eChecklist \- Building Photo1
    public async Task CompleteEChecklistBuildingPhoto1Async()
    {
        // CLEQCommonEChecklistBuildingPhoto1_cbc313Page.CLEQEChecklistBuildingPhoto1_0510_d18a3eAsync
        await _ui.ClickAsync(_locators.BuildingPhoto1);
        await _ui.WaitAsync(_locators.BuildingPhoto1Header, "Exists");
        await _ui.ClickAsync(_locators.Exception);
        await _ui.FillAsync(_locators.AddANote, _data.Resolve("{{data:add_a_note_561}}"));
        await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        // CLEQCommonEChecklistBuildingPhoto1_cbc313Page.CLEQEChecklistSync_0511_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto1Header, "Absent");
    }

    // Business step: I complete eChecklist \- Building Photo2
    public async Task CompleteEChecklistBuildingPhoto2Async()
    {
        // CLEQCommonEChecklistBuildingPhoto2_dde98aPage.CLEQEChecklistBuildingPhoto2_0512_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto2Header, "Exists");
        await _ui.ClickAsync(_locators.Exception);
        await _ui.FillAsync(_locators.AddANote, _data.Resolve("{{data:add_a_note_567}}"));
        await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        // CLEQCommonEChecklistBuildingPhoto2_dde98aPage.CLEQEChecklistSync_0513_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto2, "Absent");
    }

    // Business step: I complete eChecklist \- Building Photo3
    public async Task CompleteEChecklistBuildingPhoto3Async()
    {
        // CLEQCommonEChecklistBuildingPhoto3_b66810Page.CLEQEChecklistBuildingPhoto3_0514_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto3Header, "Exists");
        await _ui.ClickAsync(_locators.Exception);
        await _ui.FillAsync(_locators.AddANote, _data.Resolve("{{data:add_a_note_573}}"));
        await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        // CLEQCommonEChecklistBuildingPhoto3_b66810Page.CLEQEChecklistSync_0515_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto3, "Absent");
    }

    // Business step: I complete eChecklist \- Building Photo4
    public async Task CompleteEChecklistBuildingPhoto4Async()
    {
        // CLEQCommonEChecklistBuildingPhoto4_effc70Page.CLEQEChecklistBuildingPhoto4_0516_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto4Header, "Exists");
        await _ui.ClickAsync(_locators.Exception);
        await _ui.FillAsync(_locators.AddANote, _data.Resolve("{{data:add_a_note_579}}"));
        await _ui.ClickAsync(_locators.EChecklistEChecklistOK);
        await _ui.WaitAsync(_locators.EChecklistEChecklistOK, "Absent");
        // CLEQCommonEChecklistBuildingPhoto4_effc70Page.CLEQEChecklistSync_0517_d18a3eAsync
        await _ui.WaitAsync(_locators.BuildingPhoto4, "Absent");
    }

    // Business step: I add a Residence
    public async Task AddAResidenceAsync2()
    {
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIClickAddResidence_0145_08f3f1Async
        await _ui.ClickAsync(_locators.AddResidenceToLocation);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0146_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0147_08f3f1Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.AdditionalDescription, "POST:CTRL+A");
        await _ui.PressAsync(_locators.AdditionalDescription, "CTRL+A");
        await _ui.PressAsync(_locators.AdditionalDescription, "Enter");
        await _ui.PressAsync(_locators.AdditionalDescription, "Tab");
        await _ui.PressAsync(_locators.Frame, "POST:TAB");
        await _ui.PressAsync(_locators.Frame, "Tab");
        await _ui.PressAsync(_locators.SingleFamily, "POST:TAB");
        await _ui.PressAsync(_locators.SingleFamily, "Tab");
        await _ui.PressAsync(_locators.YearBuilt, "POST:CTRL+A");
        await _ui.PressAsync(_locators.YearBuilt, "CTRL+A");
        await _ui.PressAsync(_locators.YearBuilt, "Enter");
        await _ui.PressAsync(_locators.YearBuilt, "Tab");
        // CLEQSFPLocationAddAResidence_51048bPage.TBoxWait1_0148_08f3f1Async
        await Task.Delay(1000);
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0149_08f3f1Async
        await _ui.PressAsync(_locators.PlumbingYear, "POST:TAB");
        await _ui.PressAsync(_locators.PlumbingYear, "Tab");
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0150_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0151_08f3f1Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.RateType1, "POST:TAB");
        await _ui.PressAsync(_locators.RateType1, "Tab");
        await _ui.PressAsync(_locators.RoofYear, "POST:CTRL+A");
        await _ui.PressAsync(_locators.RoofYear, "CTRL+A");
        await _ui.PressAsync(_locators.RoofYear, "Enter");
        await _ui.PressAsync(_locators.RoofYear, "Tab");
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0152_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0153_08f3f1Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.FillAsync(_locators.RoofType1, _data.Resolve("{{data:roof_type_1_188}}"));
        await _ui.FillAsync(_locators.RoofImpact1, _data.Resolve("{{data:roof_impact_1_189}}"));
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0154_08f3f1Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.RoofYear, "POST:TAB");
        await _ui.PressAsync(_locators.RoofYear, "Tab");
        await _ui.PressAsync(_locators.RoofYear, "SCROLL[2]");
        await _ui.ClickAsync(_locators.SeasonalOrVacantNo);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0155_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0156_08f3f1Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.ResidenceCoverage, "POST:TAB");
        await _ui.PressAsync(_locators.ResidenceCoverage, "Tab");
        await _ui.PressAsync(_locators.ResidenceCoverage, "SCROLL[-3]");
        // CLEQSFPLocationAddAResidence_51048bPage.TBoxWait_0157_08f3f1Async
        await Task.Delay(1000);
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0158_08f3f1Async
        await _ui.ClickAsync(_locators.DoesTheClientHaveASolidFuelHeatingTypeNo);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0159_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddAResidence_51048bPage.EQSFPDivIAddResidenceAddResidenceDetail_0160_08f3f1Async
        await _ui.WaitAsync(_locators.AddResidenceHeader, "Exists");
        await _ui.PressAsync(_locators.ResidenceCoverage, "POST:TAB");
        await _ui.PressAsync(_locators.ResidenceCoverage, "Tab");
        await _ui.ClickAsync(_locators.ResidenceCoverage);
        // CLEQSFPLocationAddAResidenceCLEQCommonWaitOnLoadingIndicator_7613adPage.EQLoadingIndicatorWait_0161_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
    }

    // Business step: I add Residence Covg
    public async Task AddResidenceCovgAsync2()
    {
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0162_08f3f1Async
        await _ui.VerifyAsync(_locators.ResidenceCoverage, _data.Resolve("{{data:expected_residence_coverage_203}}"), "");
        await _ui.PressAsync(_locators.InsuranceAmount, "POST:ENTER");
        await _ui.PressAsync(_locators.InsuranceAmount, "Enter");
        await _ui.PressAsync(_locators.InsuranceAmount, "Tab");
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0163_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0164_08f3f1Async
        await _ui.PressAsync(_locators.SquareFeet, "POST:ENTER");
        await _ui.PressAsync(_locators.SquareFeet, "Enter");
        await _ui.PressAsync(_locators.SquareFeet, "Tab");
        await _ui.FillAsync(_locators.Perils, _data.Resolve("{{data:perils_207}}"));
        await _ui.PressAsync(_locators.ActualCashValue, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.ActualCashValue, "SHIFTTAB");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0165_08f3f1Async
        await _ui.PressAsync(_locators.DoesTheResidenceHaveAThermostaticallyControlledDeviceYes, "POST:TAB");
        await _ui.PressAsync(_locators.DoesTheResidenceHaveAThermostaticallyControlledDeviceYes, "Tab");
        await _ui.FillAsync(_locators.ActualCashValue, _data.Resolve("{{data:actual_cash_value_210}}"));
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0166_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0167_08f3f1Async
        await _ui.PressAsync(_locators.Save, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.Save, "SHIFTTAB");
        await _ui.PressAsync(_locators.Save, "SCROLL[-1]");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0168_08f3f1Async
        await _ui.ClickAsync(_locators.RCT);
        await _ui.ClickAsync(_locators.StandardRCTUseDefaults);
        await _ui.ClickAsync(_locators.GetValuation);
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0169_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddResidenceCovg_56e82dPage.EQSFPDivIAddResidenceAddResidenceCovg_0170_08f3f1Async
        await _ui.ClickAsync(_locators.Save);
        // CLEQSFPLocationAddResidenceCovgCLEQCommonWaitOnLoadingIndicator_2ab3c4Page.EQLoadingIndicatorWait_0171_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0172_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_7}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0173_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}