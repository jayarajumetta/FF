using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator AccountOwner => _page.GetByTestId("fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    public ILocator AccountOwnerReadOnly => _page.GetByLabel("Account Owner_Read Only", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator ActiveDisablingDevice => _page.GetByRole(AriaRole.Button, new() { Name = "ActiveDisablingDevice", Exact = true });

    // Source modules: EQ || Add Cycle/Next | confidence=Medium score=113
    public ILocator AddAdditionalVehicle => _page.GetByRole(AriaRole.Button, new() { Name = "Add Additional Vehicle", Exact = true });

    // Source modules: EQ || Add Cycle/Next | confidence=Medium score=113
    public ILocator AddCycleNextNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ||Vehicle Summary Next/Add  | confidence=High score=130
    public ILocator AddVehicle => _page.GetByTestId("fields.policy.line.add_Vehicle");

    // Source modules: EQ||Vehicle Information | confidence=High score=100
    public ILocator AdditionalVehicle => _page.GetByTestId("_vehicleChips-chip-wrapper");

    // Source modules: EQ||Vehicle Information | confidence=Medium score=108
    public ILocator AdditionalVehicleS62C9A => _page.GetByLabel("Additional Vehicle(s)", new() { Exact = true });

    // Source modules: EQ || CyclePreFillSelection | confidence=Medium score=113
    public ILocator AdditionalVehicleSF5D93 => _page.GetByRole(AriaRole.Button, new() { Name = "AdditionalVehicle(s)", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator AgreedValue8E288 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Agreed Value", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=High score=127
    public ILocator AgreedValueF302B => _page.GetByRole(AriaRole.Textbox, new() { Name = "Agreed Value", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=High score=97
    public ILocator AnnualMileage12A49 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Annual Mileage", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator AnnualMileage51344 => _page.GetByRole(AriaRole.Textbox, new() { Name = "txt_annual_mileage", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator AntiTheftYes => _page.GetByRole(AriaRole.Button, new() { Name = "Anti_theft_Yes", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator AppraisalDate8A115 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Appraisal Date", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=High score=127
    public ILocator AppraisalDateD909C => _page.GetByRole(AriaRole.Textbox, new() { Name = "Appraisal Date", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator Assigned => _page.GetByTestId("fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper");

    // Source modules: EQ || Expired License Pop Up | confidence=Medium score=113
    public ILocator CONTINUED555D => _page.GetByRole(AriaRole.Link, new() { Name = "CONTINUE", Exact = true });

    // Source modules: EQ || Owned Popup | confidence=Medium score=113
    public ILocator CONTINUEF07C7 => _page.GetByRole(AriaRole.Link, new() { Name = "CONTINUE", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator CamperShellNo => _page.GetByRole(AriaRole.Button, new() { Name = "Camper_Shell_No", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator CategoryI => _page.GetByRole(AriaRole.Button, new() { Name = "CategoryI", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=Medium score=108
    public ILocator Classic => _page.GetByLabel("Classic", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=Medium score=108
    public ILocator CollectorCar => _page.GetByLabel("CollectorCar", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator CollectorCarTypeMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-trigger");

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator CollegeDegreeGraduateWork => _page.GetByRole(AriaRole.Button, new() { Name = "College Degree/Graduate Work", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator Continue => _page.GetByRole(AriaRole.Button, new() { Name = "Continue", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=High score=97
    public ILocator CurrentValue => _page.GetByRole(AriaRole.Textbox, new() { Name = "Current Value", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=83
    public ILocator CurrentlyInCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Currently in College", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator Cycle1734D7 => _page.GetByRole(AriaRole.Button, new() { Name = "Cycle_1", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator Cycle1C1864 => _page.GetByRole(AriaRole.Button, new() { Name = "Cycle_1", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    public ILocator CycleAccessoriesV3 => _page.GetByRole(AriaRole.Button, new() { Name = "Cycle Accessories_V3", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    public ILocator CycleAccessoriesV4 => _page.GetByRole(AriaRole.Button, new() { Name = "Cycle Accessories_V4", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=97
    public ILocator CycleNonDriverComboBox => _page.GetByRole(AriaRole.Combobox, new() { Name = "CycleNonDriver_ComboBox", Exact = true });

    // Source modules: EQ || CyclePreFillSelection | confidence=Medium score=113
    public ILocator CyclePreFillSelectionNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=High score=127
    public ILocator CycleVIN => _page.GetByRole(AriaRole.Textbox, new() { Name = "Cycle VIN", Exact = true });

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    public ILocator DaysOperatedUninsured => _page.GetByRole(AriaRole.Textbox, new() { Name = "DaysOperatedUninsured", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=High score=97
    public ILocator DescriptionOfMods => _page.GetByRole(AriaRole.Textbox, new() { Name = "Description of Mods", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator Divorced => _page.GetByRole(AriaRole.Button, new() { Name = "Divorced", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=78
    public ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD => _page.GetByLabel("Does this vehicle have any Non-Factory Additions, Alterations, or Modifications?", new() { Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    public ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications21ABD => _page.GetByLabel("Does this vehicle have any Non-Factory Additions, Alterations, or Modifications?", new() { Exact = true });

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    public ILocator DriverSLicenseNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Driver's License Number", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator EQCAVerifiedMileage => _page.GetByText("EQ || CA Verified Mileage", new() { Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator GraduateDegreeJDMasters => _page.GetByRole(AriaRole.Button, new() { Name = "Graduate Degree (JD, Masters)", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator HighSchoolDiplomaOrGED => _page.GetByRole(AriaRole.Button, new() { Name = "High School Diploma or GED", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator ILCategory1 => _page.GetByRole(AriaRole.Button, new() { Name = "IL_Category_1", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    public ILocator IsThisDriverANamedInsured => _page.GetByLabel("Is this driver a named insured?", new() { Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    public ILocator IsThisVehicleOwnedOrFinanced => _page.GetByLabel("Is this vehicle owned or financed?", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LblDescriptionOfMods => _page.GetByText("Lbl_Description of Mods", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LblOwnedPopup => _page.GetByText("Lbl_Owned Popup", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator Leased14EA4 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator Leased26B32 => _page.GetByRole(AriaRole.Button, new() { Name = "Leased", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator Leased87268 => _page.GetByRole(AriaRole.Button, new() { Name = "Leased", Exact = true });

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    public ILocator LicenseState => _page.GetByRole(AriaRole.Combobox, new() { Name = "License State", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator Loan4369D => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator Loan49242 => _page.GetByRole(AriaRole.Button, new() { Name = "Loan", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator LoanED36C => _page.GetByRole(AriaRole.Button, new() { Name = "Loan", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MDNJEducationLevelUnknown => _page.GetByText("MD_NJ_EducationLevel == \"Unknown", new() { Exact = true });

    // Source modules: EQ||Vehicle Information | confidence=High score=100
    public ILocator MOREOPTIONS => _page.GetByTestId("_vehicleChips-menu-trigger");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MaritalStatusSingle => _page.GetByText("'Marital Status' != \"Single", new() { Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=83
    public ILocator Married => _page.GetByRole(AriaRole.Button, new() { Name = "Married", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator MedicalCondition => _page.GetByRole(AriaRole.Button, new() { Name = "Medical Condition", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    public ILocator Military => _page.GetByLabel("Military", new() { Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    public ILocator Missionary => _page.GetByLabel("Missionary", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator ModernClassic => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-wrapper");

    // Source modules: EQ || DriverLicense_Time | confidence=High score=127
    public ILocator MonthsLicensedCurrentState => _page.GetByRole(AriaRole.Textbox, new() { Name = "Months Licensed Current State", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=83
    public ILocator MoreOptionsEdu => _page.GetByRole(AriaRole.Button, new() { Name = "More Options Edu", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator MoreOptionsFarmUse => _page.GetByRole(AriaRole.Button, new() { Name = "More_Options_Farm_Use", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=83
    public ILocator MoreOptionsNonDriver => _page.GetByRole(AriaRole.Button, new() { Name = "More Options_NonDriver", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator N1Day => _page.GetByRole(AriaRole.Button, new() { Name = "1_Day", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator NYFFCICTotalAnnualMiles => _page.GetByRole(AriaRole.Textbox, new() { Name = "NY_FFCIC_total_annual_miles", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator NamedInsured => _page.GetByTestId("fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper");

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator NativeAmericanRegisterNO => _page.GetByRole(AriaRole.Button, new() { Name = "Native_American_Register_NO", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator NeverLicensed => _page.GetByRole(AriaRole.Button, new() { Name = "Never Licensed", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator No7C269 => _page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=83
    public ILocator NoCoverageV1Towing => _page.GetByRole(AriaRole.Button, new() { Name = "No Coverage_V1_Towing", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=83
    public ILocator NoCycleLicense => _page.GetByRole(AriaRole.Button, new() { Name = "No Cycle License", Exact = true });

    // Source modules: EQ || DriverLicense_Time | confidence=High score=130
    public ILocator NoD053A => _page.GetByTestId("fields.line.driver.rows[0].driverInputUnderwriting$sR22Indicator.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator NoD9E4D => _page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

    // Source modules: EQ || Prior Insurance Info | confidence=High score=130
    public ILocator NoNeedWasNotLicensed => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$reasonForNoPriorInsurance.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=100
    public ILocator NoPreviouslyInsured => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=83
    public ILocator NoRegisteredFedTribe => _page.GetByRole(AriaRole.Button, new() { Name = "No_RegisteredFedTribe", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=100
    public ILocator NonDriver => _page.GetByTestId("fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    public ILocator NonDriverReason => _page.GetByLabel("Non-Driver Reason", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=97
    public ILocator NonWorkAnnualMiles => _page.GetByRole(AriaRole.Textbox, new() { Name = "Non_work_annual_miles", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=100
    public ILocator NotANamedInsured => _page.GetByTestId("fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=83
    public ILocator NotPleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Not Pleasure Use", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator Odometer3843F => _page.GetByRole(AriaRole.Textbox, new() { Name = "txt_odometer", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator OdometerD648F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Odometer", Exact = true });

    // Source modules: EQ || CA Verified Mileage | confidence=Medium score=113
    // Dynamically set by buffer CA Verified Mileage in RTB Auto | 05 EQ | Vehicle Summary Next
    public ILocator OptOut => _page.GetByRole(AriaRole.Button, new() { Name = "Opt Out", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    public ILocator OriginalPartsV3 => _page.GetByRole(AriaRole.Button, new() { Name = "Original Parts_V3", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    public ILocator OriginalPartsV4 => _page.GetByRole(AriaRole.Button, new() { Name = "Original Parts_V4", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    public ILocator OtherInsurance => _page.GetByLabel("Other Insurance", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator Own49EEC => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator Own7C709 => _page.GetByRole(AriaRole.Button, new() { Name = "Own", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator OwnB8575 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator OwnD044E => _page.GetByRole(AriaRole.Button, new() { Name = "Own", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator PermitDriver => _page.GetByRole(AriaRole.Button, new() { Name = "Permit Driver", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    public ILocator PleaseSelectTheVehicleBBB72 => _page.GetByLabel("Please select the vehicle", new() { Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=78
    public ILocator PleaseSelectTheVehicleCD741 => _page.GetByLabel("Please select the vehicle", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator PleasureCANYFFCIC => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator PleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Pleasure Use", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator PostGraduateDegreeMedicalDegreePhDEdDEtc => _page.GetByRole(AriaRole.Button, new() { Name = "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)", Exact = true });

    // Source modules: EQ||Pricing Details | confidence=Medium score=114
    public ILocator PricingDetailsNext => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Next", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator PrimaryNamedInsured => _page.GetByTestId("fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper");

    // Source modules: EQ || Prior Insurance Info | confidence=Medium score=83
    public ILocator PriorCarrierName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Prior Carrier Name", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator PurchaseDate736F4 => _page.GetByRole(AriaRole.Textbox, new() { Name = "Purchase_date", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator PurchaseDateBB8AF => _page.GetByRole(AriaRole.Textbox, new() { Name = "txt_purchase_date", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator Related => _page.GetByTestId("fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator RelationshipToAccountOwnerNULL => _page.GetByText("'Relationship to Account Owner' != NULL", new() { Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Rental Reimbursement Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator RestrictedUse => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Roadside Assistance Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=130
    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    public ILocator Roommate => _page.GetByLabel("Roommate", new() { Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator SaveAndContinue8EF26 => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // Source modules: EQ || Prior Insurance Info | confidence=Medium score=113
    public ILocator SaveAndContinue9CB7A => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator SaveAndContinueBE6CD => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator SaveContinue2E7CD => _page.GetByRole(AriaRole.Button, new() { Name = "btnSave_Continue", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=Medium score=113
    public ILocator SaveContinue86B78 => _page.GetByRole(AriaRole.Button, new() { Name = "Save_Continue", Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SelectVehicle => _page.GetByText("Select Vehicle", new() { Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator Single => _page.GetByRole(AriaRole.Button, new() { Name = "Single", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator SomeCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Some College", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator Spouse => _page.GetByTestId("fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator Surrendered => _page.GetByRole(AriaRole.Button, new() { Name = "Surrendered", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator TheftDeductibleV1 => _page.GetByRole(AriaRole.Button, new() { Name = "Theft Deductible_V1", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator TheftDeductibleV2 => _page.GetByRole(AriaRole.Button, new() { Name = "Theft Deductible_V2", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator TheftDeductibleV3 => _page.GetByRole(AriaRole.Button, new() { Name = "Theft Deductible_V3", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator TheftDeductibleV4 => _page.GetByRole(AriaRole.Button, new() { Name = "Theft Deductible_V4", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator TotalAnnualMileage => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total_annual_mileage", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UIMPDCoverageV1 => _page.GetByRole(AriaRole.Button, new() { Name = "UIMPD Coverage_V1", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UIMPDCoverageV2 => _page.GetByRole(AriaRole.Button, new() { Name = "UIMPD Coverage_V2", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UIMPDCoverageV3 => _page.GetByRole(AriaRole.Button, new() { Name = "UIMPD Coverage_V3", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UIMPDCoverageV4 => _page.GetByRole(AriaRole.Button, new() { Name = "UIMPD Coverage_V4", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=100
    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=130
    // Dynamically set by buffer UMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=130
    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=130
    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Source modules:  | confidence=Medium score=83
    public ILocator UMPDMoreOptionsCoverages => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD More Options Coverages", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDUIMPDV1 => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD/UIMPD_V1", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDUIMPDV2 => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD/UIMPD_V2", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDUIMPDV3 => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD/UIMPD_V3", Exact = true });

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDUIMPDV4 => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD/UIMPD_V4", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator UnderConstruction => _page.GetByRole(AriaRole.Button, new() { Name = "Under Construction", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    public ILocator Underage => _page.GetByRole(AriaRole.Button, new() { Name = "Underage", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=83
    public ILocator UnknownNoHighSchoolDiplomaOrGED => _page.GetByRole(AriaRole.Button, new() { Name = "Unknown/No High School Diploma or GED", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator UseCAMoreOptions => _page.GetByRole(AriaRole.Button, new() { Name = "Use_CA_More_Options", Exact = true });

    // Source modules: EQ||Vehicle Auto Vin_1 | confidence=High score=127
    public ILocator VIN06D01 => _page.GetByRole(AriaRole.Textbox, new() { Name = "txt_VIN", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator VIN0A17C => _page.GetByRole(AriaRole.Textbox, new() { Name = "VIN", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=High score=127
    public ILocator VIN8EE56 => _page.GetByRole(AriaRole.Textbox, new() { Name = "VIN", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator Veh1 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator Veh3 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper");

    // Source modules: EQ||Vehicle Auto Vin_1 | confidence=High score=130
    public ILocator Vehicle1 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$vINSelect.value-vin-select-\"*\"-chip-chip");

    // Source modules: EQ||Vehicle Information | confidence=Medium score=113
    public ILocator VehicleInformationNext => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Next", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator VehicleMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-menu-trigger");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    public ILocator VehicleType => _page.GetByLabel("Vehicle Type", new() { Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator Vintage => _page.GetByRole(AriaRole.Button, new() { Name = "Vintage", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator VocationalOrTradeSchoolDegree => _page.GetByRole(AriaRole.Button, new() { Name = "Vocational or Trade School Degree", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    public ILocator WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove => _page.GetByLabel("Was this client insured with American National immediately prior to the carrier listed above?", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=97
    public ILocator WorkMilesDay => _page.GetByRole(AriaRole.Textbox, new() { Name = "Work_miles_day", Exact = true });

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator Yes => _page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    public ILocator YrsLicensedAllStates => _page.GetByRole(AriaRole.Textbox, new() { Name = "YrsLicensed All States", Exact = true });

    // Source modules: EQ || DriverLicense_Time | confidence=High score=127
    public ILocator YrsLicensedCurrentState => _page.GetByRole(AriaRole.Textbox, new() { Name = "Yrs Licensed Current State", Exact = true });

}
