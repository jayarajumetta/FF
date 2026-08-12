using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "EQ BOP Smart StraightThrough Policy")]
public sealed class EQBOPSmartStraightThroughPolicySteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public EQBOPSmartStraightThroughPolicySteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [When("I preQualification - Add Habitational Class - 63011")]
    public async Task IPreQualificationAddHabitationalClass63011_10()
    {
        var eQBOPPreQualificationAddAClass = new EQBOPPreQualificationAddAClass(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPPreQualificationAddAClass.WaitForPreQualificationHeadingAsync();
        await eQBOPPreQualificationAddAClass.ClickSearchAddClassCodeAsync();
        await eQBOPPreQualificationAddAClass.WaitForAddClassTablePopupAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPreQualificationAddAClass.WaitForTABLEAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I primary Insured Details - Snowplow Questions")]
    public async Task IPrimaryInsuredDetailsSnowplowQuestions_14()
    {
        var eQBOPPrimaryInsuredDetailsSnowplowQuestions = new EQBOPPrimaryInsuredDetailsSnowplowQuestions(_browser.Page, _data);

        await eQBOPPrimaryInsuredDetailsSnowplowQuestions.WaitForSnowplowQuestionsAsync();
        await eQBOPPrimaryInsuredDetailsSnowplowQuestions.ClickNoneOfTheAboveAsync();
        await eQBOPPrimaryInsuredDetailsSnowplowQuestions.ClickNextClaimsPriorInsuranceAsync();
    
    }

    [When("I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building")]
    public async Task IBuildingSelectOwnOrRentAndBuildingSQFootageStraightThroughTheLocationTheBuilding_20()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPBuildingAddBuildingOwnRentSqFootage = new EQBOPBuildingAddBuildingOwnRentSqFootage(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForSelectIfClientOwnsOrRentsTheBuildingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.ClickOwnButtonOldAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.ClickRentButtonAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForTotalBuildingSqFootageAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.SetTotalBuildingSqFootageAsync(_data.Get("EQ BOP Building Add Building Own Rent & Sq Footage.Total Building Sq. Footage", "\"^{a}\"{{data:Total Building Sq Footage}}"));
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForTotalBuildingSqFootageAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.SetTotalBuildingSqFootageAsync(_data.Get("EQ BOP Building Add Building Own Rent & Sq Footage.Total Building Sq. Footage", "\"^{a}\"{{data:Total Building Sq Footage}}"));
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 63011 to - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode63011ToTheLocationTheBuilding_23()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 74901 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode74901ToBuildingTheLocationTheBuilding_30()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 77161 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode77161ToBuildingTheLocationTheBuilding_31()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 91581 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode91581ToBuildingTheLocationTheBuilding_32()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- for Landscape Gardening Shop - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataForLandscapeGardeningShopTheLocationTheBuilding_33()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- for Snow and Ice Removal -Residential - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataForSnowAndIceRemovalResidentialTheLocationTheBuilding_34()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Answer Extra Questions after Class supplemental Data added- Snow and Ice Removal - the location - the building")]
    public async Task IBuildingAnswerExtraQuestionsAfterClassSupplementalDataAddedSnowAndIceRemovalTheLocationTheBuilding_35()
    {
        var eQBOPBuildingSnowAndIceRemovalQuestion = new EQBOPBuildingSnowAndIceRemovalQuestion(_browser.Page, _data);

        await eQBOPBuildingSnowAndIceRemovalQuestion.ClickNoAsync();
        await eQBOPBuildingSnowAndIceRemovalQuestion.PressNoAsync("Tab");
        await eQBOPBuildingSnowAndIceRemovalQuestion.PressNoAsync("Tab");
    
    }

    [When("I building - Answer Extra Questions after Class supplemental Data added - Subcontractors total Building Cost")]
    public async Task IBuildingAnswerExtraQuestionsAfterClassSupplementalDataAddedSubcontractorsTotalBuildingCost_36()
    {
        var eQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost = new EQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost(_browser.Page, _data);

        await eQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost.SetSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync(_data.Get("EQ BOP Building Subcontractors - in connection with building construction, reconstruction repair or erection - not buildings total cost.Subcontractors - in connection with building construction, reconstruction repair or erection - not buildings total cost", "4000"));
        await eQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost.PressSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync("Enter");
        await eQBOPBuildingSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCost.PressSubcontractorsInConnectionWithBuildingConstructionReconstructionRepairOrErectionNotBuildingsTotalCostAsync("Tab");
    
    }

    [When("I building - Class Codes - Add Class Code 64181 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode64181ToBuildingTheLocationTheBuilding_37()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- for Veterinarians Office - Office - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataForVeterinariansOfficeOfficeTheLocationTheBuilding_38()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 09661 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode09661ToBuildingTheLocationTheBuilding_39()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- Casual Dining - Family Style Restaurants - With Sales of Alcoholic Beverages up to 50% of Total Sales - the current building")]
    public async Task IBuildingClassEnterSupplementalDataCasualDiningFamilyStyleRestaurantsWithSalesOfAlcoholicBeveragesUpTo50OfTotalSalesTheCurrentBuilding_40()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I locations/Buildings - Add 2nd Location")]
    public async Task ILocationsBuildingsAdd2ndLocation_42()
    {
        var eQBOPLocationsAddEditCopyLocationSelection = new EQBOPLocationsAddEditCopyLocationSelection(_browser.Page, _data);
        var eQBOPLocationsAddEditLocation = new EQBOPLocationsAddEditLocation(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPLocationsAddEditCopyLocationSelection.ClickAddLocationButtonAsync();
        await eQBOPLocationsAddEditLocation.SetLabelNicknameForTheLocationAsync(_data.Get("EQ BOP Locations Add/Edit Location.Label/Nickname for the Location", "\"^{a}\"{{data: Loc #2 Label/Nickname}}"));
        await eQBOPLocationsAddEditLocation.PressLabelNicknameForTheLocationAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressLabelNicknameForTheLocationAsync("Tab");
        await eQBOPLocationsAddEditLocation.SetAddress1Async(_data.Get("EQ BOP Locations Add/Edit Location.Address 1", "\"^{a}\"{{data:Loc #2 Address 1}}"));
        await eQBOPLocationsAddEditLocation.PressAddress1Async("Tab");
        await eQBOPLocationsAddEditLocation.SetCityAsync(_data.Get("EQ BOP Locations Add/Edit Location.City", "\"^{a}\"{{data:Loc #2 City}}"));
        await eQBOPLocationsAddEditLocation.PressCityAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressCityAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressCityAsync("Tab");
        await eQBOPLocationsAddEditLocation.SetStateAsync(_data.Get("EQ BOP Locations Add/Edit Location.State", "x"));
        await eQBOPLocationsAddEditLocation.ClickStateDropdownAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetZipCodeAsync(_data.Get("EQ BOP Locations Add/Edit Location.Zip Code", "\"^{a}\"{{data:Loc #2 Zip Code}}"));
        await eQBOPLocationsAddEditLocation.PressZipCodeAsync("Tab");
        await eQBOPLocationsAddEditLocation.WaitForZipCodeAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.ClickValidateAddressAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetMilesFromFireDepartmentAsync(_data.Get("EQ BOP Locations Add/Edit Location.Miles From Fire Department", "{{data:Loc #2 Miles From Fire Department}}"));
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Enter");
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetFeetFromFireHydrantAsync(_data.Get("EQ BOP Locations Add/Edit Location.Feet from Fire Hydrant", "1 - 100"));
        await eQBOPLocationsAddEditLocation.PressFeetFromFireHydrantAsync("Enter");
        await eQBOPLocationsAddEditLocation.PressFeetFromFireHydrantAsync("Tab");
        await eQBOPLocationsAddEditLocation.ClickSaveAsync();
        await eQBOPLocationsAddEditCopyLocationSelection.ClickAddLocationButtonAsync();
        await eQBOPLocationsAddEditLocation.SetLabelNicknameForTheLocationAsync(_data.Get("EQ BOP Locations Add/Edit Location.Label/Nickname for the Location", "\"^{a}\"{{data:Loc #3 Label/Nickname}}"));
        await eQBOPLocationsAddEditLocation.PressLabelNicknameForTheLocationAsync("Tab");
        await eQBOPLocationsAddEditLocation.SetAddress1Async(_data.Get("EQ BOP Locations Add/Edit Location.Address 1", "\"^{a}\"{{data:Loc #3 Address 1}}"));
        await eQBOPLocationsAddEditLocation.PressAddress1Async("Tab");
        await eQBOPLocationsAddEditLocation.PressAddress1Async("Tab");
        await eQBOPLocationsAddEditLocation.SetCityAsync(_data.Get("EQ BOP Locations Add/Edit Location.City", "\"^{a}\"{{data:Loc #3 City}}"));
        await eQBOPLocationsAddEditLocation.PressCityAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressCityAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressCityAsync("Tab");
        await eQBOPLocationsAddEditLocation.SetStateAsync(_data.Get("EQ BOP Locations Add/Edit Location.State", "x"));
        await eQBOPLocationsAddEditLocation.SetZipCodeAsync(_data.Get("EQ BOP Locations Add/Edit Location.Zip Code", "\"^{a}\"{{data:Loc #3 Zip Code}}"));
        await eQBOPLocationsAddEditLocation.PressZipCodeAsync("Tab");
        await eQBOPLocationsAddEditLocation.WaitForZipCodeAsync();
        await eQBOPLocationsAddEditLocation.ClickStateDropdownAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetZipCodeAsync(_data.Get("EQ BOP Locations Add/Edit Location.Zip Code", "{{data:Loc #2 Zip Code}}"));
        await eQBOPLocationsAddEditLocation.PressZipCodeAsync("Tab");
        await eQBOPLocationsAddEditLocation.WaitForZipCodeAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.ClickValidateAddressAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetMilesFromFireDepartmentAsync(_data.Get("EQ BOP Locations Add/Edit Location.Miles From Fire Department", "{{data:Loc #3 Miles From Fire Department}}"));
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Tab");
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetFeetFromFireHydrantAsync(_data.Get("EQ BOP Locations Add/Edit Location.Feet from Fire Hydrant", "1 - 100"));
        await eQBOPLocationsAddEditLocation.PressFeetFromFireHydrantAsync("Enter");
        await eQBOPLocationsAddEditLocation.PressFeetFromFireHydrantAsync("Tab");
        await eQBOPLocationsAddEditLocation.ClickSaveAsync();
        await eQBOPLocationsAddEditCopyLocationSelection.ClickAddLocationButtonAsync();
        await eQBOPLocationsAddEditLocation.SetLabelNicknameForTheLocationAsync(_data.Get("EQ BOP Locations Add/Edit Location.Label/Nickname for the Location", "{{data:Loc #4 Label/Nickname}}"));
        await eQBOPLocationsAddEditLocation.PressLabelNicknameForTheLocationAsync("Tab");
        await eQBOPLocationsAddEditLocation.SetAddress1Async(_data.Get("EQ BOP Locations Add/Edit Location.Address 1", "{{data:Loc #4 Address 1}}"));
        await eQBOPLocationsAddEditLocation.PressAddress1Async("Tab");
        await eQBOPLocationsAddEditLocation.PressAddress1Async("Tab");
        await eQBOPLocationsAddEditLocation.SetStateAsync(_data.Get("EQ BOP Locations Add/Edit Location.State", "x"));
        await eQBOPLocationsAddEditLocation.SetZipCodeAsync(_data.Get("EQ BOP Locations Add/Edit Location.Zip Code", "{{data:Loc #4 Zip Code}}"));
        await eQBOPLocationsAddEditLocation.PressZipCodeAsync("Tab");
        await eQBOPLocationsAddEditLocation.WaitForZipCodeAsync();
        await eQBOPLocationsAddEditLocation.SetMilesFromFireDepartmentAsync(_data.Get("EQ BOP Locations Add/Edit Location.Miles From Fire Department", "{{data:Loc #4 Miles From Fire Department}}"));
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Tab");
        await eQBOPLocationsAddEditLocation.WaitForMilesFromFireDepartmentAsync();
        await eQBOPLocationsAddEditLocation.ClickSaveAsync();
        await eQBOPLocationsAddEditLocation.ClickStateDropdownAsync();
        await eQBOPLocationsAddEditLocation.ClickFeetFromFireHydrantAsync();
        await eQBOPLocationsAddEditLocation.SetItem501750Async(_data.Get("EQ BOP Locations Add/Edit Location.501 - 750", "x"));
    
    }

    [When("I buildings-Locations - Add a Building to 2nd Location")]
    public async Task IBuildingsLocationsAddABuildingTo2ndLocation_43()
    {
        var eQBOPLocationsBuildingsAddABuildingTo2ndLocation = new EQBOPLocationsBuildingsAddABuildingTo2ndLocation(_browser.Page, _data);

        await eQBOPLocationsBuildingsAddABuildingTo2ndLocation.VerifyLocation2Location2SecondaryAsync(_data.Get("EQ BOP Locations-Buildings Add a Building to 2nd Location.Location 2 - Location #2 (Secondary)", "{{data:Location and Building}}"));
        await eQBOPLocationsBuildingsAddABuildingTo2ndLocation.ClickAddBuildingBPP1Async();
    
    }

    [When("I building - Class Codes - Add Class Code 63631 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode63631ToBuildingTheLocationTheBuilding_44()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- Accounting Services - CPAs - Office - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataAccountingServicesCPAsOfficeTheLocationTheBuilding_45()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 16402 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode16402ToBuildingTheLocationTheBuilding_46()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- Pet Grooming - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataPetGroomingTheLocationTheBuilding_47()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 59999 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode59999ToBuildingTheLocationTheBuilding_48()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- for Ceramics - Retail Only - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataForCeramicsRetailOnlyTheLocationTheBuilding_49()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 74231 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode74231ToBuildingTheLocationTheBuilding_50()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplemental data- for Contractor - Carpentry - Interior - Shop - the location - the building")]
    public async Task IBuildingClassEnterSupplementalDataForContractorCarpentryInteriorShopTheLocationTheBuilding_51()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I buildings-Locations - Add a Building to 3rd Location")]
    public async Task IBuildingsLocationsAddABuildingTo3rdLocation_52()
    {
        var eQBOPLocationsBuildingsAddABuildingTo3rdLocation = new EQBOPLocationsBuildingsAddABuildingTo3rdLocation(_browser.Page, _data);

        await eQBOPLocationsBuildingsAddABuildingTo3rdLocation.SetLocation3Async(_data.Get("EQ BOP Locations-Buildings Add a Building to 3rd Location.Location #3", "Lost Forty Brewing"));
        await eQBOPLocationsBuildingsAddABuildingTo3rdLocation.PressLocation3Async("Tab");
    
    }

    [When("I building - Select Own or rent and Building SQ Footage StraightThrough - the location")]
    public async Task IBuildingSelectOwnOrRentAndBuildingSQFootageStraightThroughTheLocation_53()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPBuildingAddBuildingOwnRentSqFootage = new EQBOPBuildingAddBuildingOwnRentSqFootage(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForSelectIfClientOwnsOrRentsTheBuildingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.ClickOwnButtonOldAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.ClickRentButtonAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForTotalBuildingSqFootageAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.SetTotalBuildingSqFootageAsync(_data.Get("EQ BOP Building Add Building Own Rent & Sq Footage.Total Building Sq. Footage", "\"^{a}\"{{data:Total Building Sq Footage}}"));
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class Codes - Add Class Code 59965 to Building - the location - the building")]
    public async Task IBuildingClassCodesAddClassCode59965ToBuildingTheLocationTheBuilding_54()
    {
        var eQBOPBuildingEditAndVerifyClassInfo = new EQBOPBuildingEditAndVerifyClassInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.PressAddInventoryAsync("Tab");
        await eQBOPBuildingEditAndVerifyClassInfo.ClickAddInventoryAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I building - Class - Enter supplementaldata - for Winery - Wine MFG.- Retail")]
    public async Task IBuildingClassEnterSupplementaldataForWineryWineMFGRetail_55()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I additional Coverages - Policy Coverages - Winery Extension")]
    public async Task IAdditionalCoveragesPolicyCoveragesWineryExtension_57()
    {
        var eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension = new EQBOPAdditionalCoveragesPolicyCoveragesWineryExtension(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetDirectToConsumerSalesAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Direct To Consumer Sales", "50000"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressDirectToConsumerSalesAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetBottledWineAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Bottled Wine", "25000"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressBottledWineAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetServedByTheGlassAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Served By The Glass", "3000"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressServedByTheGlassAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetConsumedOnPremiseAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Consumed On Premise", "0"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressConsumedOnPremiseAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetDirectToConsumerInternetSalesAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Direct To Consumer Internet Sales", "6000"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressDirectToConsumerInternetSalesAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetWholesaleWineSalesAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Wholesale Wine Sales", "900"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressWholesaleWineSalesAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetBulkWineSalesAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Bulk Wine Sales", "0"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressBulkWineSalesAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetTotalWineSoldAnnuallyAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Total Wine Sold Annually", "150000"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressTotalWineSoldAnnuallyAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetTotalOtherThanWineSalesAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Total Other Than Wine Sales", "500"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressTotalOtherThanWineSalesAsync("Tab");
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressOtherAlcoholSalesExceed25Async("Tab");
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetOtherAlcoholSalesExceed25Async(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Other alcohol sales exceed 25%", "NO"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetPropertyDeductibleAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Property Deductible", "$2,500"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressPropertyDeductibleAsync("Tab");
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.ClickHarvestedGrapesAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.SetHarvestedGrapesLimitOfInsuranceAsync(_data.Get("EQ BOP Additional Coverages Policy Coverages Winery Extension.Harvested Grapes Limit Of Insurance", "25000"));
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.PressHarvestedGrapesLimitOfInsuranceAsync("Tab");
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.ClickTotalOtherThanWineSalesAsync();
        await eQBOPAdditionalCoveragesPolicyCoveragesWineryExtension.ClickTotalOtherThanWineSalesAsync();
    
    }

    [When("I review the first required building photo")]
    public async Task IReviewTheFirstRequiredBuildingPhoto_64()
    {
        var eQCommonEChecklistEChecklist = new EQCommonEChecklistEChecklist(_browser.Page, _data);

        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto1HeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto1HeaderAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickBuildingPhoto1Async();
    
    }

    [When("I review the second required building photo")]
    public async Task IReviewTheSecondRequiredBuildingPhoto_65()
    {
        var eQCommonEChecklistEChecklist = new EQCommonEChecklistEChecklist(_browser.Page, _data);

        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto2HeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto2Async();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickBuildingPhoto2Async();
    
    }

    [When("I provide the required loss-run history")]
    public async Task IProvideTheRequiredLossRunHistory_66()
    {
        var eQCommonEChecklistEChecklist = new EQCommonEChecklistEChecklist(_browser.Page, _data);

        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForLossRuns3YearsHeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForLossRunsHeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
    
    }

    [When("I eChecklist - Signature Page")]
    public async Task IEChecklistSignaturePage_67()
    {
        var eQCommonEChecklistEChecklist = new EQCommonEChecklistEChecklist(_browser.Page, _data);

        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.ClickSignaturePageLinkAsync();
        await eQCommonEChecklistEChecklist.ClickReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.ClickSignaturePageBoundCoverageOnlySFPAsync();
        await eQCommonEChecklistEChecklist.ClickAttachAsync();
        await eQCommonEChecklistEChecklist.WaitForOkSubmitAsync();
        await eQCommonEChecklistEChecklist.ClickSubmitAsync();
        await eQCommonEChecklistEChecklist.ClickOkSubmitAsync();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
    
    }

    [When("I esignature - confirm the dialog")]
    public async Task IEsignatureConfirmTheDialog_68()
    {
        var eQCommonEsignatureClickOK = new EQCommonEsignatureClickOK(_browser.Page, _data);

        await eQCommonEsignatureClickOK.ClickOkToUpdateFromChecklistAsync();
    
    }

    [When("I submission - Transmit to DC")]
    public async Task ISubmissionTransmitToDC_69()
    {
        var eQBOPSubmissionTransmitToDC = new EQBOPSubmissionTransmitToDC(_browser.Page, _data);

        await eQBOPSubmissionTransmitToDC.ClickTransmitAsync();
    
    }

    [When("I transmit the policy Confirmation and New Packet Verification in EQ")]
    public async Task ITransmitThePolicyConfirmationAndNewPacketVerificationInEQ_70()
    {
        var eQCommonTransmitConfirmation = new EQCommonTransmitConfirmation(_browser.Page, _data);

        await eQCommonTransmitConfirmation.VerifyNEWBUSINESSPACKETAsync(_data.Get("EQ Common Transmit Confirmation.NEW BUSINESS PACKET", "True"));
    
    }

    [When("I general - Log In to DuckCreek")]
    public async Task IGeneralLogInToDuckCreek_71()
    {
        await Task.CompletedTask;
    
    }

    [When("I dashboard - Perform Quick Search and Open Policy")]
    public async Task IDashboardPerformQuickSearchAndOpenPolicy_72()
    {
        var dashboardQuickSearch = new DashboardQuickSearch(_browser.Page, _data);
        var dashboardSearchForPoliciesQuotes = new DashboardSearchForPoliciesQuotes(_browser.Page, _data);

        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
    
    }
}
