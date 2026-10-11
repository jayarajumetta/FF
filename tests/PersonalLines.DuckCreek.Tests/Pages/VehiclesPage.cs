using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class VehiclesPage
{
    private readonly BrowserSession _browser;
    private readonly VehiclesLocators _locators;
    private readonly UiActions _ui;

    public VehiclesPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new VehiclesLocators(browser.Page);
        _ui = ui;
    }

    public Task PressAccountOwnerAsync(string key) =>
        _ui.PressAsync(_locators.AccountOwner, key, new ControlIntent("Vehicles", "AccountOwner"));

    public Task ClickAccountOwnerAsync() =>
        _ui.ClickAsync(_locators.AccountOwner, new ControlIntent("Vehicles", "AccountOwner"));

    public Task VerifyAccountOwnerReadOnlyAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AccountOwnerReadOnly, expected, property, new ControlIntent("Vehicles", "AccountOwnerReadOnly"));

    public Task ClickActiveDisablingDeviceAsync() =>
        _ui.ClickAsync(_locators.ActiveDisablingDevice, new ControlIntent("Vehicles", "ActiveDisablingDevice"));

    public Task ClickAddAdditionalVehicleAsync() =>
        _ui.ClickAsync(_locators.AddAdditionalVehicle, new ControlIntent("Vehicles", "AddAdditionalVehicle"));

    public Task ClickAddCycleNextNextAsync() =>
        _ui.ClickAsync(_locators.AddCycleNextNext, new ControlIntent("Vehicles", "AddCycleNextNext"));

    public Task ClickAddVehicleAsync() =>
        _ui.ClickAsync(_locators.AddVehicle, new ControlIntent("Vehicles", "AddVehicle"));

    public Task WaitForAdditionalVehicleAsync(string expected) =>
        _ui.WaitAsync(_locators.AdditionalVehicle, expected, new ControlIntent("Vehicles", "AdditionalVehicle"));

    public Task ClickAdditionalVehicleAsync() =>
        _ui.ClickAsync(_locators.AdditionalVehicle, new ControlIntent("Vehicles", "AdditionalVehicle"));

    public Task<bool> IsAdditionalVehiclePresentAsync() =>
        _ui.ExistsAsync(_locators.AdditionalVehicle);

    public Task ClickAdditionalVehicleS62C9AAsync() =>
        _ui.ClickAsync(_locators.AdditionalVehicleS62C9A, new ControlIntent("Vehicles", "AdditionalVehicleS62C9A"));

    public Task ClickAdditionalVehicleSF5D93Async() =>
        _ui.ClickAsync(_locators.AdditionalVehicleS62C9A, new ControlIntent("Vehicles", "AdditionalVehicleSF5D93"));

    public Task<bool> IsAdditionalVehicleSF5D93PresentAsync() =>
        _ui.ExistsAsync(_locators.AdditionalVehicleS62C9A);

    public Task EnterAgreedValue8E288Async(string value) =>
        _ui.FillAsync(_locators.AgreedValue8E288, value, new ControlIntent("Vehicles", "AgreedValue8E288"));

    public Task EnterAgreedValueF302BAsync(string value) =>
        _ui.FillAsync(_locators.AgreedValue8E288, value, new ControlIntent("Vehicles", "AgreedValueF302B"));

    public Task EnterAnnualMileage12A49Async(string value) =>
        _ui.FillAsync(_locators.AnnualMileage12A49, value, new ControlIntent("Vehicles", "AnnualMileage12A49"));

    public Task EnterAnnualMileage51344Async(string value) =>
        _ui.FillAsync(_locators.AnnualMileage51344, value, new ControlIntent("Vehicles", "AnnualMileage51344"));

    public Task PressAnnualMileage51344Async(string key) =>
        _ui.PressAsync(_locators.AnnualMileage51344, key, new ControlIntent("Vehicles", "AnnualMileage51344"));

    public Task SelectAntiTheftYesAsync(string value) =>
        _ui.SelectAsync(_locators.AntiTheftYes, value, new ControlIntent("Vehicles", "AntiTheftYes"));

    public Task EnterAppraisalDate8A115Async(string value) =>
        _ui.FillAsync(_locators.AppraisalDate8A115, value, new ControlIntent("Vehicles", "AppraisalDate8A115"));

    public Task PressAppraisalDate8A115Async(string key) =>
        _ui.PressAsync(_locators.AppraisalDate8A115, key, new ControlIntent("Vehicles", "AppraisalDate8A115"));

    public Task EnterAppraisalDateD909CAsync(string value) =>
        _ui.FillAsync(_locators.AppraisalDate8A115, value, new ControlIntent("Vehicles", "AppraisalDateD909C"));

    public Task PressAssignedAsync(string key) =>
        _ui.PressAsync(_locators.Assigned, key, new ControlIntent("Vehicles", "Assigned"));

    public Task ClickAssignedAsync() =>
        _ui.ClickAsync(_locators.Assigned, new ControlIntent("Vehicles", "Assigned"));

    public Task WaitForCONTINUED555DAsync(string expected) =>
        _ui.WaitAsync(_locators.CONTINUED555D, expected, new ControlIntent("Vehicles", "CONTINUED555D"));

    public Task ClickCONTINUED555DAsync() =>
        _ui.ClickAsync(_locators.CONTINUED555D, new ControlIntent("Vehicles", "CONTINUED555D"));

    public Task<bool> IsCONTINUED555DPresentAsync() =>
        _ui.ExistsAsync(_locators.CONTINUED555D);

    public Task ClickCONTINUEF07C7Async() =>
        _ui.ClickAsync(_locators.CONTINUED555D, new ControlIntent("Vehicles", "CONTINUEF07C7"));

    public Task<bool> IsCONTINUEF07C7PresentAsync() =>
        _ui.ExistsAsync(_locators.CONTINUED555D);

    public Task SelectCamperShellNoAsync(string value) =>
        _ui.SelectAsync(_locators.CamperShellNo, value, new ControlIntent("Vehicles", "CamperShellNo"));

    public Task ClickCategoryIAsync() =>
        _ui.ClickAsync(_locators.CategoryI, new ControlIntent("Vehicles", "CategoryI"));

    public Task PressClassicAsync(string key) =>
        _ui.PressAsync(_locators.Classic, key, new ControlIntent("Vehicles", "Classic"));

    public Task ClickClassicAsync() =>
        _ui.ClickAsync(_locators.Classic, new ControlIntent("Vehicles", "Classic"));

    public Task PressCollectorCarAsync(string key) =>
        _ui.PressAsync(_locators.CollectorCar, key, new ControlIntent("Vehicles", "CollectorCar"));

    public Task ClickCollectorCarAsync() =>
        _ui.ClickAsync(_locators.CollectorCar, new ControlIntent("Vehicles", "CollectorCar"));

    public Task SelectCollectorCarTypeMoreOptionsAsync(string value) =>
        _ui.SelectAsync(_locators.CollectorCarTypeMoreOptions, value, new ControlIntent("Vehicles", "CollectorCarTypeMoreOptions"));

    public Task WaitForCollegeDegreeGraduateWorkAsync(string expected) =>
        _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, expected, new ControlIntent("Vehicles", "CollegeDegreeGraduateWork"));

    public Task ClickCollegeDegreeGraduateWorkAsync() =>
        _ui.ClickAsync(_locators.CollegeDegreeGraduateWork, new ControlIntent("Vehicles", "CollegeDegreeGraduateWork"));

    public Task ClickContinueAsync() =>
        _ui.ClickAsync(_locators.CONTINUED555D, new ControlIntent("Vehicles", "Continue"));

    public Task EnterCurrentValueAsync(string value) =>
        _ui.FillAsync(_locators.CurrentValue, value, new ControlIntent("Vehicles", "CurrentValue"));

    public Task WaitForCurrentlyInCollegeAsync(string expected) =>
        _ui.WaitAsync(_locators.CurrentlyInCollege, expected, new ControlIntent("Vehicles", "CurrentlyInCollege"));

    public Task ClickCurrentlyInCollegeAsync() =>
        _ui.ClickAsync(_locators.CurrentlyInCollege, new ControlIntent("Vehicles", "CurrentlyInCollege"));

    public Task ClickCycle1734D7Async() =>
        _ui.ClickAsync(_locators.Cycle1734D7, new ControlIntent("Vehicles", "Cycle1734D7"));

    public Task ClickCycle1C1864Async() =>
        _ui.ClickAsync(_locators.Cycle1734D7, new ControlIntent("Vehicles", "Cycle1C1864"));

    public Task ClickCycleAccessoriesV3Async() =>
        _ui.ClickAsync(_locators.CycleAccessoriesV3, new ControlIntent("Vehicles", "CycleAccessoriesV3"));

    public Task ClickCycleAccessoriesV4Async() =>
        _ui.ClickAsync(_locators.CycleAccessoriesV3, new ControlIntent("Vehicles", "CycleAccessoriesV4"));

    public Task EnterCycleNonDriverComboBoxAsync(string value) =>
        _ui.FillAsync(_locators.CycleNonDriverComboBox, value, new ControlIntent("Vehicles", "CycleNonDriverComboBox"));

    public Task ClickCyclePreFillSelectionNextAsync() =>
        _ui.ClickAsync(_locators.AddCycleNextNext, new ControlIntent("Vehicles", "CyclePreFillSelectionNext"));

    public Task WaitForCycleVINAsync(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "CycleVIN"));

    public Task EnterCycleVINAsync(string value) =>
        _ui.FillAsync(_locators.Cycle1734D7, value, new ControlIntent("Vehicles", "CycleVIN"));

    public Task PressCycleVINAsync(string key) =>
        _ui.PressAsync(_locators.Cycle1734D7, key, new ControlIntent("Vehicles", "CycleVIN"));

    public Task EnterDaysOperatedUninsuredAsync(string value) =>
        _ui.FillAsync(_locators.DaysOperatedUninsured, value, new ControlIntent("Vehicles", "DaysOperatedUninsured"));

    public Task EnterDescriptionOfModsAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfMods, value, new ControlIntent("Vehicles", "DescriptionOfMods"));

    public Task ClickDivorcedAsync() =>
        _ui.ClickAsync(_locators.Divorced, new ControlIntent("Vehicles", "Divorced"));

    public Task WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FDAsync(string expected) =>
        _ui.WaitAsync(_locators.DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD, expected, new ControlIntent("Vehicles", "DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD"));

    public Task WaitForDoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications21ABDAsync(string expected) =>
        _ui.WaitAsync(_locators.DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD, expected, new ControlIntent("Vehicles", "DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications21ABD"));

    public Task EnterDriverSLicenseNumberAsync(string value) =>
        _ui.FillAsync(_locators.DaysOperatedUninsured, value, new ControlIntent("Vehicles", "DriverSLicenseNumber"));

    public Task PressDriverSLicenseNumberAsync(string key) =>
        _ui.PressAsync(_locators.DaysOperatedUninsured, key, new ControlIntent("Vehicles", "DriverSLicenseNumber"));

    public Task VerifyEQCAVerifiedMileageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQCAVerifiedMileage, expected, property, new ControlIntent("Vehicles", "EQCAVerifiedMileage"));

    public Task WaitForGraduateDegreeJDMastersAsync(string expected) =>
        _ui.WaitAsync(_locators.GraduateDegreeJDMasters, expected, new ControlIntent("Vehicles", "GraduateDegreeJDMasters"));

    public Task ClickGraduateDegreeJDMastersAsync() =>
        _ui.ClickAsync(_locators.GraduateDegreeJDMasters, new ControlIntent("Vehicles", "GraduateDegreeJDMasters"));

    public Task VerifyHighSchoolDiplomaOrGEDAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, expected, property, new ControlIntent("Vehicles", "HighSchoolDiplomaOrGED"));

    public Task ClickHighSchoolDiplomaOrGEDAsync() =>
        _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED, new ControlIntent("Vehicles", "HighSchoolDiplomaOrGED"));

    public Task<bool> IsHighSchoolDiplomaOrGEDPresentAsync() =>
        _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED);

    public Task ClickILCategory1Async() =>
        _ui.ClickAsync(_locators.ILCategory1, new ControlIntent("Vehicles", "ILCategory1"));

    public Task WaitForIsThisDriverANamedInsuredAsync(string expected) =>
        _ui.WaitAsync(_locators.AccountOwnerReadOnly, expected, new ControlIntent("Vehicles", "IsThisDriverANamedInsured"));

    public Task WaitForIsThisVehicleOwnedOrFinancedAsync(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "IsThisVehicleOwnedOrFinanced"));

    public Task WaitForLblDescriptionOfModsAsync(string expected) =>
        _ui.WaitAsync(_locators.LblDescriptionOfMods, expected, new ControlIntent("Vehicles", "LblDescriptionOfMods"));

    public Task VerifyLblOwnedPopupAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LblOwnedPopup, expected, property, new ControlIntent("Vehicles", "LblOwnedPopup"));

    public Task<bool> IsLblOwnedPopupPresentAsync() =>
        _ui.ExistsAsync(_locators.LblOwnedPopup);

    public Task ClickLeased14EA4Async() =>
        _ui.ClickAsync(_locators.Leased14EA4, new ControlIntent("Vehicles", "Leased14EA4"));

    public Task ClickLeased26B32Async() =>
        _ui.ClickAsync(_locators.Leased26B32, new ControlIntent("Vehicles", "Leased26B32"));

    public Task ClickLeased87268Async() =>
        _ui.ClickAsync(_locators.Leased26B32, new ControlIntent("Vehicles", "Leased87268"));

    public Task EnterLicenseStateAsync(string value) =>
        _ui.FillAsync(_locators.DaysOperatedUninsured, value, new ControlIntent("Vehicles", "LicenseState"));

    public Task ClickLoan4369DAsync() =>
        _ui.ClickAsync(_locators.Leased14EA4, new ControlIntent("Vehicles", "Loan4369D"));

    public Task ClickLoan49242Async() =>
        _ui.ClickAsync(_locators.Loan49242, new ControlIntent("Vehicles", "Loan49242"));

    public Task ClickLoanED36CAsync() =>
        _ui.ClickAsync(_locators.Loan49242, new ControlIntent("Vehicles", "LoanED36C"));

    public Task ClickMDNJEducationLevelUnknownAsync() =>
        _ui.ClickAsync(_locators.MDNJEducationLevelUnknown, new ControlIntent("Vehicles", "MDNJEducationLevelUnknown"));

    public Task<bool> IsMDNJEducationLevelUnknownPresentAsync() =>
        _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown);

    public Task WaitForMOREOPTIONSAsync(string expected) =>
        _ui.WaitAsync(_locators.MOREOPTIONS, expected, new ControlIntent("Vehicles", "MOREOPTIONS"));

    public Task SelectMOREOPTIONSAsync(string value) =>
        _ui.SelectAsync(_locators.MOREOPTIONS, value, new ControlIntent("Vehicles", "MOREOPTIONS"));

    public Task<bool> IsMOREOPTIONSPresentAsync() =>
        _ui.ExistsAsync(_locators.MOREOPTIONS);

    public Task ClickMaritalStatusSingleAsync() =>
        _ui.ClickAsync(_locators.MaritalStatusSingle, new ControlIntent("Vehicles", "MaritalStatusSingle"));

    public Task<bool> IsMaritalStatusSinglePresentAsync() =>
        _ui.ExistsAsync(_locators.MaritalStatusSingle);

    public Task SelectMarriedAsync(string value) =>
        _ui.SelectAsync(_locators.Divorced, value, new ControlIntent("Vehicles", "Married"));

    public Task ClickMedicalConditionAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "MedicalCondition"));

    public Task ClickMilitaryAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "Military"));

    public Task ClickMissionaryAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "Missionary"));

    public Task PressModernClassicAsync(string key) =>
        _ui.PressAsync(_locators.ModernClassic, key, new ControlIntent("Vehicles", "ModernClassic"));

    public Task ClickModernClassicAsync() =>
        _ui.ClickAsync(_locators.ModernClassic, new ControlIntent("Vehicles", "ModernClassic"));

    public Task EnterMonthsLicensedCurrentStateAsync(string value) =>
        _ui.FillAsync(_locators.DaysOperatedUninsured, value, new ControlIntent("Vehicles", "MonthsLicensedCurrentState"));

    public Task PressMonthsLicensedCurrentStateAsync(string key) =>
        _ui.PressAsync(_locators.DaysOperatedUninsured, key, new ControlIntent("Vehicles", "MonthsLicensedCurrentState"));

    public Task SelectMoreOptionsEduAsync(string value) =>
        _ui.SelectAsync(_locators.MoreOptionsEdu, value, new ControlIntent("Vehicles", "MoreOptionsEdu"));

    public Task SelectMoreOptionsFarmUseAsync(string value) =>
        _ui.SelectAsync(_locators.MoreOptionsFarmUse, value, new ControlIntent("Vehicles", "MoreOptionsFarmUse"));

    public Task SelectMoreOptionsNonDriverAsync(string value) =>
        _ui.SelectAsync(_locators.AccountOwnerReadOnly, value, new ControlIntent("Vehicles", "MoreOptionsNonDriver"));

    public Task ClickN1DayAsync() =>
        _ui.ClickAsync(_locators.N1Day, new ControlIntent("Vehicles", "N1Day"));

    public Task EnterNYFFCICTotalAnnualMilesAsync(string value) =>
        _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, value, new ControlIntent("Vehicles", "NYFFCICTotalAnnualMiles"));

    public Task PressNYFFCICTotalAnnualMilesAsync(string key) =>
        _ui.PressAsync(_locators.NYFFCICTotalAnnualMiles, key, new ControlIntent("Vehicles", "NYFFCICTotalAnnualMiles"));

    public Task PressNamedInsuredAsync(string key) =>
        _ui.PressAsync(_locators.NamedInsured, key, new ControlIntent("Vehicles", "NamedInsured"));

    public Task ClickNamedInsuredAsync() =>
        _ui.ClickAsync(_locators.NamedInsured, new ControlIntent("Vehicles", "NamedInsured"));

    public Task SelectNativeAmericanRegisterNOAsync(string value) =>
        _ui.SelectAsync(_locators.NativeAmericanRegisterNO, value, new ControlIntent("Vehicles", "NativeAmericanRegisterNO"));

    public Task ClickNeverLicensedAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "NeverLicensed"));

    public Task SelectNo7C269Async(string value) =>
        _ui.SelectAsync(_locators.No7C269, value, new ControlIntent("Vehicles", "No7C269"));

    public Task SelectNoCoverageV1TowingAsync(string value) =>
        _ui.SelectAsync(_locators.NoCoverageV1Towing, value, new ControlIntent("Vehicles", "NoCoverageV1Towing"));

    public Task SelectNoCycleLicenseAsync(string value) =>
        _ui.SelectAsync(_locators.AccountOwnerReadOnly, value, new ControlIntent("Vehicles", "NoCycleLicense"));

    public Task PressNoD053AAsync(string key) =>
        _ui.PressAsync(_locators.NoD053A, key, new ControlIntent("Vehicles", "NoD053A"));

    public Task ClickNoD053AAsync() =>
        _ui.ClickAsync(_locators.NoD053A, new ControlIntent("Vehicles", "NoD053A"));

    public Task SelectNoD9E4DAsync(string value) =>
        _ui.SelectAsync(_locators.No7C269, value, new ControlIntent("Vehicles", "NoD9E4D"));

    public Task VerifyNoNeedWasNotLicensedAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, expected, property, new ControlIntent("Vehicles", "NoNeedWasNotLicensed"));

    public Task PressNoNeedWasNotLicensedAsync(string key) =>
        _ui.PressAsync(_locators.NoNeedWasNotLicensed, key, new ControlIntent("Vehicles", "NoNeedWasNotLicensed"));

    public Task ClickNoNeedWasNotLicensedAsync() =>
        _ui.ClickAsync(_locators.NoNeedWasNotLicensed, new ControlIntent("Vehicles", "NoNeedWasNotLicensed"));

    public Task<bool> IsNoNeedWasNotLicensedPresentAsync() =>
        _ui.ExistsAsync(_locators.NoNeedWasNotLicensed);

    public Task SelectNoPreviouslyInsuredAsync(string value) =>
        _ui.SelectAsync(_locators.NoPreviouslyInsured, value, new ControlIntent("Vehicles", "NoPreviouslyInsured"));

    public Task<bool> IsNoPreviouslyInsuredPresentAsync() =>
        _ui.ExistsAsync(_locators.NoPreviouslyInsured);

    public Task SelectNoRegisteredFedTribeAsync(string value) =>
        _ui.SelectAsync(_locators.NoRegisteredFedTribe, value, new ControlIntent("Vehicles", "NoRegisteredFedTribe"));

    public Task SelectNonDriverAsync(string value) =>
        _ui.SelectAsync(_locators.Assigned, value, new ControlIntent("Vehicles", "NonDriver"));

    public Task PressNonDriverAsync(string key) =>
        _ui.PressAsync(_locators.Assigned, key, new ControlIntent("Vehicles", "NonDriver"));

    public Task ClickNonDriverAsync() =>
        _ui.ClickAsync(_locators.Assigned, new ControlIntent("Vehicles", "NonDriver"));

    public Task WaitForNonDriverReasonAsync(string expected) =>
        _ui.WaitAsync(_locators.AccountOwnerReadOnly, expected, new ControlIntent("Vehicles", "NonDriverReason"));

    public Task EnterNonWorkAnnualMilesAsync(string value) =>
        _ui.FillAsync(_locators.NonWorkAnnualMiles, value, new ControlIntent("Vehicles", "NonWorkAnnualMiles"));

    public Task PressNonWorkAnnualMilesAsync(string key) =>
        _ui.PressAsync(_locators.NonWorkAnnualMiles, key, new ControlIntent("Vehicles", "NonWorkAnnualMiles"));

    public Task PressNotANamedInsuredAsync(string key) =>
        _ui.PressAsync(_locators.NamedInsured, key, new ControlIntent("Vehicles", "NotANamedInsured"));

    public Task ClickNotANamedInsuredAsync() =>
        _ui.ClickAsync(_locators.NamedInsured, new ControlIntent("Vehicles", "NotANamedInsured"));

    public Task SelectNotPleasureUseAsync(string value) =>
        _ui.SelectAsync(_locators.NotPleasureUse, value, new ControlIntent("Vehicles", "NotPleasureUse"));

    public Task EnterOdometer3843FAsync(string value) =>
        _ui.FillAsync(_locators.Odometer3843F, value, new ControlIntent("Vehicles", "Odometer3843F"));

    public Task PressOdometer3843FAsync(string key) =>
        _ui.PressAsync(_locators.Odometer3843F, key, new ControlIntent("Vehicles", "Odometer3843F"));

    public Task EnterOdometerD648FAsync(string value) =>
        _ui.FillAsync(_locators.OdometerD648F, value, new ControlIntent("Vehicles", "OdometerD648F"));

    public Task PressOdometerD648FAsync(string key) =>
        _ui.PressAsync(_locators.OdometerD648F, key, new ControlIntent("Vehicles", "OdometerD648F"));

    public Task ClickOptOutAsync() =>
        _ui.ClickAsync(_locators.OptOut, new ControlIntent("Vehicles", "OptOut"));

    public Task ClickOriginalPartsV3Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "OriginalPartsV3"));

    public Task ClickOriginalPartsV4Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "OriginalPartsV4"));

    public Task ClickOtherInsuranceAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "OtherInsurance"));

    public Task ClickOwn49EECAsync() =>
        _ui.ClickAsync(_locators.Leased14EA4, new ControlIntent("Vehicles", "Own49EEC"));

    public Task ClickOwn7C709Async() =>
        _ui.ClickAsync(_locators.Own7C709, new ControlIntent("Vehicles", "Own7C709"));

    public Task PressOwnB8575Async(string key) =>
        _ui.PressAsync(_locators.OwnB8575, key, new ControlIntent("Vehicles", "OwnB8575"));

    public Task ClickOwnB8575Async() =>
        _ui.ClickAsync(_locators.OwnB8575, new ControlIntent("Vehicles", "OwnB8575"));

    public Task ClickOwnD044EAsync() =>
        _ui.ClickAsync(_locators.Own7C709, new ControlIntent("Vehicles", "OwnD044E"));

    public Task ClickPermitDriverAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "PermitDriver"));

    public Task WaitForPleaseSelectTheVehicleBBB72Async(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "PleaseSelectTheVehicleBBB72"));

    public Task WaitForPleaseSelectTheVehicleCD741Async(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "PleaseSelectTheVehicleCD741"));

    public Task ClickPleasureCANYFFCICAsync() =>
        _ui.ClickAsync(_locators.PleasureCANYFFCIC, new ControlIntent("Vehicles", "PleasureCANYFFCIC"));

    public Task ClickPleasureUseAsync() =>
        _ui.ClickAsync(_locators.PleasureUse, new ControlIntent("Vehicles", "PleasureUse"));

    public Task WaitForPostGraduateDegreeMedicalDegreePhDEdDEtcAsync(string expected) =>
        _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, expected, new ControlIntent("Vehicles", "PostGraduateDegreeMedicalDegreePhDEdDEtc"));

    public Task ClickPostGraduateDegreeMedicalDegreePhDEdDEtcAsync() =>
        _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, new ControlIntent("Vehicles", "PostGraduateDegreeMedicalDegreePhDEdDEtc"));

    public Task WaitForPricingDetailsNextAsync(string expected) =>
        _ui.WaitAsync(_locators.PricingDetailsNext, expected, new ControlIntent("Vehicles", "PricingDetailsNext"));

    public Task ClickPricingDetailsNextAsync() =>
        _ui.ClickAsync(_locators.PricingDetailsNext, new ControlIntent("Vehicles", "PricingDetailsNext"));

    public Task PressPrimaryNamedInsuredAsync(string key) =>
        _ui.PressAsync(_locators.NamedInsured, key, new ControlIntent("Vehicles", "PrimaryNamedInsured"));

    public Task ClickPrimaryNamedInsuredAsync() =>
        _ui.ClickAsync(_locators.NamedInsured, new ControlIntent("Vehicles", "PrimaryNamedInsured"));

    public Task VerifyPriorCarrierNameAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PriorCarrierName, expected, property, new ControlIntent("Vehicles", "PriorCarrierName"));

    public Task<bool> IsPriorCarrierNamePresentAsync() =>
        _ui.ExistsAsync(_locators.PriorCarrierName);

    public Task EnterPurchaseDate736F4Async(string value) =>
        _ui.FillAsync(_locators.PurchaseDate736F4, value, new ControlIntent("Vehicles", "PurchaseDate736F4"));

    public Task EnterPurchaseDateBB8AFAsync(string value) =>
        _ui.FillAsync(_locators.PurchaseDateBB8AF, value, new ControlIntent("Vehicles", "PurchaseDateBB8AF"));

    public Task PressPurchaseDateBB8AFAsync(string key) =>
        _ui.PressAsync(_locators.PurchaseDateBB8AF, key, new ControlIntent("Vehicles", "PurchaseDateBB8AF"));

    public Task PressRelatedAsync(string key) =>
        _ui.PressAsync(_locators.Assigned, key, new ControlIntent("Vehicles", "Related"));

    public Task ClickRelatedAsync() =>
        _ui.ClickAsync(_locators.Assigned, new ControlIntent("Vehicles", "Related"));

    public Task SelectRelationshipToAccountOwnerNULLAsync(string value) =>
        _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, value, new ControlIntent("Vehicles", "RelationshipToAccountOwnerNULL"));

    public Task PressRentalReimbursementCoverageV1Async(string key) =>
        _ui.PressAsync(_locators.RentalReimbursementCoverageV1, key, new ControlIntent("Vehicles", "RentalReimbursementCoverageV1"));

    public Task ClickRentalReimbursementCoverageV1Async() =>
        _ui.ClickAsync(_locators.RentalReimbursementCoverageV1, new ControlIntent("Vehicles", "RentalReimbursementCoverageV1"));

    public Task PressRentalReimbursementCoverageV2Async(string key) =>
        _ui.PressAsync(_locators.RentalReimbursementCoverageV2, key, new ControlIntent("Vehicles", "RentalReimbursementCoverageV2"));

    public Task ClickRentalReimbursementCoverageV2Async() =>
        _ui.ClickAsync(_locators.RentalReimbursementCoverageV2, new ControlIntent("Vehicles", "RentalReimbursementCoverageV2"));

    public Task PressRentalReimbursementCoverageV3Async(string key) =>
        _ui.PressAsync(_locators.RentalReimbursementCoverageV3, key, new ControlIntent("Vehicles", "RentalReimbursementCoverageV3"));

    public Task ClickRentalReimbursementCoverageV3Async() =>
        _ui.ClickAsync(_locators.RentalReimbursementCoverageV3, new ControlIntent("Vehicles", "RentalReimbursementCoverageV3"));

    public Task PressRentalReimbursementCoverageV4Async(string key) =>
        _ui.PressAsync(_locators.RentalReimbursementCoverageV4, key, new ControlIntent("Vehicles", "RentalReimbursementCoverageV4"));

    public Task ClickRentalReimbursementCoverageV4Async() =>
        _ui.ClickAsync(_locators.RentalReimbursementCoverageV4, new ControlIntent("Vehicles", "RentalReimbursementCoverageV4"));

    public Task PressRestrictedUseAsync(string key) =>
        _ui.PressAsync(_locators.RestrictedUse, key, new ControlIntent("Vehicles", "RestrictedUse"));

    public Task ClickRestrictedUseAsync() =>
        _ui.ClickAsync(_locators.RestrictedUse, new ControlIntent("Vehicles", "RestrictedUse"));

    public Task PressRoadsideAssistanceCoverageV1Async(string key) =>
        _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, key, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV1"));

    public Task ClickRoadsideAssistanceCoverageV1Async() =>
        _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV1"));

    public Task PressRoadsideAssistanceCoverageV2Async(string key) =>
        _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, key, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV2"));

    public Task ClickRoadsideAssistanceCoverageV2Async() =>
        _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV2"));

    public Task PressRoadsideAssistanceCoverageV3Async(string key) =>
        _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, key, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV3"));

    public Task ClickRoadsideAssistanceCoverageV3Async() =>
        _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV3"));

    public Task ClickRoadsideAssistanceCoverageV4Async() =>
        _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4, new ControlIntent("Vehicles", "RoadsideAssistanceCoverageV4"));

    public Task ClickRoommateAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "Roommate"));

    public Task ClickSaveAndContinue8EF26Async() =>
        _ui.ClickAsync(_locators.SaveAndContinue8EF26, new ControlIntent("Vehicles", "SaveAndContinue8EF26"));

    public Task ClickSaveAndContinue9CB7AAsync() =>
        _ui.ClickAsync(_locators.SaveAndContinue8EF26, new ControlIntent("Vehicles", "SaveAndContinue9CB7A"));

    public Task<bool> IsSaveAndContinue9CB7APresentAsync() =>
        _ui.ExistsAsync(_locators.SaveAndContinue8EF26);

    public Task ClickSaveAndContinueBE6CDAsync() =>
        _ui.ClickAsync(_locators.SaveAndContinue8EF26, new ControlIntent("Vehicles", "SaveAndContinueBE6CD"));

    public Task ClickSaveContinue2E7CDAsync() =>
        _ui.ClickAsync(_locators.SaveContinue2E7CD, new ControlIntent("Vehicles", "SaveContinue2E7CD"));

    public Task ClickSaveContinue86B78Async() =>
        _ui.ClickAsync(_locators.SaveContinue2E7CD, new ControlIntent("Vehicles", "SaveContinue86B78"));

    public Task WaitForSelectVehicleAsync(string expected) =>
        _ui.WaitAsync(_locators.SelectVehicle, expected, new ControlIntent("Vehicles", "SelectVehicle"));

    public Task<bool> IsSelectVehiclePresentAsync() =>
        _ui.ExistsAsync(_locators.SelectVehicle);

    public Task VerifySingleAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Divorced, expected, property, new ControlIntent("Vehicles", "Single"));

    public Task ClickSingleAsync() =>
        _ui.ClickAsync(_locators.Divorced, new ControlIntent("Vehicles", "Single"));

    public Task<bool> IsSinglePresentAsync() =>
        _ui.ExistsAsync(_locators.Divorced);

    public Task WaitForSomeCollegeAsync(string expected) =>
        _ui.WaitAsync(_locators.SomeCollege, expected, new ControlIntent("Vehicles", "SomeCollege"));

    public Task ClickSomeCollegeAsync() =>
        _ui.ClickAsync(_locators.SomeCollege, new ControlIntent("Vehicles", "SomeCollege"));

    public Task VerifySpouseAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AccountOwner, expected, property, new ControlIntent("Vehicles", "Spouse"));

    public Task ClickSurrenderedAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "Surrendered"));

    public Task ClickTheftDeductibleV1Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "TheftDeductibleV1"));

    public Task ClickTheftDeductibleV2Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "TheftDeductibleV2"));

    public Task ClickTheftDeductibleV3Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "TheftDeductibleV3"));

    public Task ClickTheftDeductibleV4Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "TheftDeductibleV4"));

    public Task EnterTotalAnnualMileageAsync(string value) =>
        _ui.FillAsync(_locators.TotalAnnualMileage, value, new ControlIntent("Vehicles", "TotalAnnualMileage"));

    public Task PressTotalAnnualMileageAsync(string key) =>
        _ui.PressAsync(_locators.TotalAnnualMileage, key, new ControlIntent("Vehicles", "TotalAnnualMileage"));

    public Task ClickUIMPDCoverageV1Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UIMPDCoverageV1"));

    public Task ClickUIMPDCoverageV2Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UIMPDCoverageV2"));

    public Task ClickUIMPDCoverageV3Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UIMPDCoverageV3"));

    public Task ClickUIMPDCoverageV4Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UIMPDCoverageV4"));

    public Task PressUMPDCoverageVehicle1Async(string key) =>
        _ui.PressAsync(_locators.UMPDCoverageVehicle1, key, new ControlIntent("Vehicles", "UMPDCoverageVehicle1"));

    public Task ClickUMPDCoverageVehicle1Async() =>
        _ui.ClickAsync(_locators.UMPDCoverageVehicle1, new ControlIntent("Vehicles", "UMPDCoverageVehicle1"));

    public Task ClickUMPDCoverageVehicle2Async() =>
        _ui.ClickAsync(_locators.UMPDCoverageVehicle2, new ControlIntent("Vehicles", "UMPDCoverageVehicle2"));

    public Task ClickUMPDCoverageVehicle3Async() =>
        _ui.ClickAsync(_locators.UMPDCoverageVehicle3, new ControlIntent("Vehicles", "UMPDCoverageVehicle3"));

    public Task ClickUMPDCoverageVehicle4Async() =>
        _ui.ClickAsync(_locators.UMPDCoverageVehicle4, new ControlIntent("Vehicles", "UMPDCoverageVehicle4"));

    public Task SelectUMPDMoreOptionsCoveragesAsync(string value) =>
        _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, value, new ControlIntent("Vehicles", "UMPDMoreOptionsCoverages"));

    public Task ClickUMPDUIMPDV1Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UMPDUIMPDV1"));

    public Task ClickUMPDUIMPDV2Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UMPDUIMPDV2"));

    public Task ClickUMPDUIMPDV3Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UMPDUIMPDV3"));

    public Task ClickUMPDUIMPDV4Async() =>
        _ui.ClickAsync(_locators.NoCoverageV1Towing, new ControlIntent("Vehicles", "UMPDUIMPDV4"));

    public Task ClickUnderConstructionAsync() =>
        _ui.ClickAsync(_locators.UnderConstruction, new ControlIntent("Vehicles", "UnderConstruction"));

    public Task ClickUnderageAsync() =>
        _ui.ClickAsync(_locators.AccountOwnerReadOnly, new ControlIntent("Vehicles", "Underage"));

    public Task SelectUnknownNoHighSchoolDiplomaOrGEDAsync(string value) =>
        _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, value, new ControlIntent("Vehicles", "UnknownNoHighSchoolDiplomaOrGED"));

    public Task SelectUseCAMoreOptionsAsync(string value) =>
        _ui.SelectAsync(_locators.UseCAMoreOptions, value, new ControlIntent("Vehicles", "UseCAMoreOptions"));

    public Task WaitForVIN06D01Async(string expected) =>
        _ui.WaitAsync(_locators.VIN06D01, expected, new ControlIntent("Vehicles", "VIN06D01"));

    public Task EnterVIN06D01Async(string value) =>
        _ui.FillAsync(_locators.VIN06D01, value, new ControlIntent("Vehicles", "VIN06D01"));

    public Task PressVIN06D01Async(string key) =>
        _ui.PressAsync(_locators.VIN06D01, key, new ControlIntent("Vehicles", "VIN06D01"));

    public Task ClickVIN06D01Async() =>
        _ui.ClickAsync(_locators.VIN06D01, new ControlIntent("Vehicles", "VIN06D01"));

    public Task WaitForVIN0A17CAsync(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "VIN0A17C"));

    public Task EnterVIN0A17CAsync(string value) =>
        _ui.FillAsync(_locators.Cycle1734D7, value, new ControlIntent("Vehicles", "VIN0A17C"));

    public Task PressVIN0A17CAsync(string key) =>
        _ui.PressAsync(_locators.Cycle1734D7, key, new ControlIntent("Vehicles", "VIN0A17C"));

    public Task WaitForVIN8EE56Async(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "VIN8EE56"));

    public Task EnterVIN8EE56Async(string value) =>
        _ui.FillAsync(_locators.Cycle1734D7, value, new ControlIntent("Vehicles", "VIN8EE56"));

    public Task PressVIN8EE56Async(string key) =>
        _ui.PressAsync(_locators.Cycle1734D7, key, new ControlIntent("Vehicles", "VIN8EE56"));

    public Task ClickVeh1Async() =>
        _ui.ClickAsync(_locators.Veh1, new ControlIntent("Vehicles", "Veh1"));

    public Task ClickVeh3Async() =>
        _ui.ClickAsync(_locators.Veh1, new ControlIntent("Vehicles", "Veh3"));

    public Task ClickVehicle1Async() =>
        _ui.ClickAsync(_locators.Vehicle1, new ControlIntent("Vehicles", "Vehicle1"));

    public Task ClickVehicleInformationNextAsync() =>
        _ui.ClickAsync(_locators.PricingDetailsNext, new ControlIntent("Vehicles", "VehicleInformationNext"));

    public Task SelectVehicleMoreOptionsAsync(string value) =>
        _ui.SelectAsync(_locators.VehicleMoreOptions, value, new ControlIntent("Vehicles", "VehicleMoreOptions"));

    public Task PressVehicleMoreOptionsAsync(string key) =>
        _ui.PressAsync(_locators.VehicleMoreOptions, key, new ControlIntent("Vehicles", "VehicleMoreOptions"));

    public Task ClickVehicleMoreOptionsAsync() =>
        _ui.ClickAsync(_locators.VehicleMoreOptions, new ControlIntent("Vehicles", "VehicleMoreOptions"));

    public Task WaitForVehicleTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.Cycle1734D7, expected, new ControlIntent("Vehicles", "VehicleType"));

    public Task ClickVintageAsync() =>
        _ui.ClickAsync(_locators.Cycle1734D7, new ControlIntent("Vehicles", "Vintage"));

    public Task ClickVocationalOrTradeSchoolDegreeAsync() =>
        _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree, new ControlIntent("Vehicles", "VocationalOrTradeSchoolDegree"));

    public Task VerifyWasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAboveAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AccountOwnerReadOnly, expected, property, new ControlIntent("Vehicles", "WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove"));

    public Task<bool> IsWasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbovePresentAsync() =>
        _ui.ExistsAsync(_locators.AccountOwnerReadOnly);

    public Task EnterWorkMilesDayAsync(string value) =>
        _ui.FillAsync(_locators.WorkMilesDay, value, new ControlIntent("Vehicles", "WorkMilesDay"));

    public Task PressWorkMilesDayAsync(string key) =>
        _ui.PressAsync(_locators.WorkMilesDay, key, new ControlIntent("Vehicles", "WorkMilesDay"));

    public Task SelectYesAsync(string value) =>
        _ui.SelectAsync(_locators.Yes, value, new ControlIntent("Vehicles", "Yes"));

    public Task EnterYrsLicensedAllStatesAsync(string value) =>
        _ui.FillAsync(_locators.DaysOperatedUninsured, value, new ControlIntent("Vehicles", "YrsLicensedAllStates"));

    public Task PressYrsLicensedAllStatesAsync(string key) =>
        _ui.PressAsync(_locators.DaysOperatedUninsured, key, new ControlIntent("Vehicles", "YrsLicensedAllStates"));

    public Task EnterYrsLicensedCurrentStateAsync(string value) =>
        _ui.FillAsync(_locators.YrsLicensedCurrentState, value, new ControlIntent("Vehicles", "YrsLicensedCurrentState"));

    public Task PressYrsLicensedCurrentStateAsync(string key) =>
        _ui.PressAsync(_locators.YrsLicensedCurrentState, key, new ControlIntent("Vehicles", "YrsLicensedCurrentState"));

}
