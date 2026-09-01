using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    public ILocator AccountOwner => _page.GetByTestId("fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper");

    public ILocator AccountOwnerReadOnly => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$gender.value-0\"]");

    public ILocator ActiveDisablingDevice => _page.GetByRole(AriaRole.Button, new() { Name = "ActiveDisablingDevice", Exact = true });

    public ILocator AddAdditionalVehicle => _page.GetByRole(AriaRole.Button, new() { Name = "Add Additional Vehicle", Exact = true });

    public ILocator AddCycleNextNext => _page.Locator("[id=\"fields.data.next\"]");

    public ILocator AddVehicle => _page.GetByTestId("fields.policy.line.add_Vehicle");

    public ILocator AdditionalVehicle => _page.GetByTestId("_vehicleChips-chip-wrapper");

    public ILocator AdditionalVehicleS62C9A => _page.Locator("[id=\"unlistedVehicle\"]");


    public ILocator AgreedValue8E288 => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\"]");


    public ILocator AnnualMileage12A49 => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\"][name=\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\"]");

    public ILocator AnnualMileage51344 => _page.Locator("[name=\"txt_annual_mileage\"], [id=\"txt_annual_mileage\"]").First;

    public ILocator AntiTheftYes => _page.GetByRole(AriaRole.Button, new() { Name = "Anti_theft_Yes", Exact = true });

    public ILocator AppraisalDate8A115 => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\"]");


    public ILocator Assigned => _page.GetByTestId("fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper");

    public ILocator CONTINUED555D => _page.Locator("[id=\"btnConfirmYes\"]");


    public ILocator CamperShellNo => _page.GetByRole(AriaRole.Button, new() { Name = "Camper_Shell_No", Exact = true });

    public ILocator CategoryI => _page.GetByRole(AriaRole.Button, new() { Name = "CategoryI", Exact = true });

    public ILocator Classic => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-0\"][data-testid=\"fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-wrapper\"]");

    public ILocator CollectorCar => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-0\"][data-testid=\"fields.line.risk.rows[0].vehicleInput$vehicleType.value-chip-wrapper\"]");

    public ILocator CollectorCarTypeMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-trigger");

    public ILocator CollegeDegreeGraduateWork => _page.GetByRole(AriaRole.Button, new() { Name = "College Degree/Graduate Work", Exact = true });


    public ILocator CurrentValue => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$currentValue.value\"][name=\"fields.line.risk.rows[0].vehicleInput$currentValue.value\"]");

    public ILocator CurrentlyInCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Currently in College", Exact = true });

    public ILocator Cycle1734D7 => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$vIN.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$vIN.value\"]");


    public ILocator CycleAccessoriesV3 => _page.Locator("[id=\"fields.policy.line.risk.rows[1].end_IncreasedLimitsForAccessories$end_IncreasedLimitsForAccessories_Select.value-0\"]");


    public ILocator CycleNonDriverComboBox => _page.Locator("[name=\"CycleNonDriver_ComboBox\"], [id=\"CycleNonDriver_ComboBox\"]").First;



    public ILocator DaysOperatedUninsured => _page.Locator("input[id=\"fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value\"][name=\"fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value\"]");

    public ILocator DescriptionOfMods => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\"][name=\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\"]");

    public ILocator Divorced => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$maritalStatus.value-2\"]");

    public ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$agreedValue.value\"][name=\"fields.line.risk.rows[0].vehicleInput$agreedValue.value\"]");



    public ILocator EQCAVerifiedMileage => _page.GetByText("EQ || CA Verified Mileage", new() { Exact = true });

    public ILocator GraduateDegreeJDMasters => _page.GetByRole(AriaRole.Button, new() { Name = "Graduate Degree (JD, Masters)", Exact = true });

    public ILocator HighSchoolDiplomaOrGED => _page.GetByRole(AriaRole.Button, new() { Name = "High School Diploma or GED", Exact = true });

    public ILocator ILCategory1 => _page.GetByRole(AriaRole.Button, new() { Name = "IL_Category_1", Exact = true });



    public ILocator LblDescriptionOfMods => _page.GetByText("Lbl_Description of Mods", new() { Exact = true });

    public ILocator LblOwnedPopup => _page.GetByText("Lbl_Owned Popup", new() { Exact = true });

    public ILocator Leased14EA4 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    public ILocator Leased26B32 => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-1\"][data-testid=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"]");




    public ILocator Loan49242 => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-0\"][data-testid=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"]");


    public ILocator MDNJEducationLevelUnknown => _page.GetByText("MD_NJ_EducationLevel == \"Unknown", new() { Exact = true });

    public ILocator MOREOPTIONS => _page.GetByTestId("_vehicleChips-menu-trigger");

    public ILocator MaritalStatusSingle => _page.GetByText("'Marital Status' != \"Single", new() { Exact = true });

    public ILocator Married => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$maritalStatus.value-1\"]");




    public ILocator ModernClassic => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-wrapper");


    public ILocator MoreOptionsEdu => _page.GetByRole(AriaRole.Button, new() { Name = "More Options Edu", Exact = true });

    public ILocator MoreOptionsFarmUse => _page.GetByRole(AriaRole.Button, new() { Name = "More_Options_Farm_Use", Exact = true });


    public ILocator N1Day => _page.GetByRole(AriaRole.Button, new() { Name = "1_Day", Exact = true });

    public ILocator NYFFCICTotalAnnualMiles => _page.Locator("[name=\"NY_FFCIC_total_annual_miles\"], [id=\"NY_FFCIC_total_annual_miles\"]").First;

    public ILocator NamedInsured => _page.GetByTestId("fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper");

    public ILocator NativeAmericanRegisterNO => _page.GetByRole(AriaRole.Button, new() { Name = "Native_American_Register_NO", Exact = true });


    public ILocator No7C269 => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-1\"]");

    public ILocator NoCoverageV1Towing => _page.Locator("[id=\"fields.policy.line.risk.rows[0].end_OriginalParts$end_OriginalParts_Select.value-0\"]");


    public ILocator NoD053A => _page.GetByTestId("fields.line.driver.rows[0].driverInputUnderwriting$sR22Indicator.value-chip-wrapper");


    public ILocator NoNeedWasNotLicensed => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$reasonForNoPriorInsurance.value-chip-wrapper");

    public ILocator NoPreviouslyInsured => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-wrapper");

    public ILocator NoRegisteredFedTribe => _page.GetByRole(AriaRole.Button, new() { Name = "No_RegisteredFedTribe", Exact = true });



    public ILocator NonWorkAnnualMiles => _page.Locator("[name=\"Non_work_annual_miles\"], [id=\"Non_work_annual_miles\"]").First;


    public ILocator NotPleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Not Pleasure Use", Exact = true });

    public ILocator Odometer3843F => _page.Locator("[name=\"txt_odometer\"], [id=\"txt_odometer\"]").First;

    public ILocator OdometerD648F => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\"]");

    // Dynamically set by buffer CA Verified Mileage in RTB Auto | 05 EQ | Vehicle Summary Next
    public ILocator OptOut => _page.Locator("[id=\"fields.policy.lineVerifiedMileage.riskFactor_VerifiedMileageOptIn$value.value-1\"]");





    public ILocator Own7C709 => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-2\"][data-testid=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"]");

    public ILocator OwnB8575 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");





    public ILocator PleasureCANYFFCIC => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper");

    public ILocator PleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Pleasure Use", Exact = true });

    public ILocator PostGraduateDegreeMedicalDegreePhDEdDEtc => _page.GetByRole(AriaRole.Button, new() { Name = "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)", Exact = true });

    public ILocator PricingDetailsNext => _page.Locator("[id=\"Policy_Headless.Constant_ResidenceSummary-0-layout\"]");


    public ILocator PriorCarrierName => _page.Locator("[id=\"Driver_Headless.Constant_TimeWithPriorCarrier-0-layout\"]");

    public ILocator PurchaseDate736F4 => _page.Locator("[name=\"Purchase_date\"], [id=\"Purchase_date\"]").First;

    public ILocator PurchaseDateBB8AF => _page.Locator("[name=\"txt_purchase_date\"], [id=\"txt_purchase_date\"]").First;


    public ILocator RelationshipToAccountOwnerNULL => _page.GetByText("'Relationship to Account Owner' != NULL", new() { Exact = true });

    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Rental Reimbursement Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covRentalReimbursementInput$limit.value-chip-wrapper");

    public ILocator RestrictedUse => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper");

    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Roadside Assistance Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covRoadsideAssistanceInput$limit.value-chip-wrapper");


    public ILocator SaveAndContinue8EF26 => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });



    public ILocator SaveContinue2E7CD => _page.Locator("[id=\"fields.data.policy.line.risk.vehicle_Detail_Done\"]");


    public ILocator SelectVehicle => _page.GetByText("Select Vehicle", new() { Exact = true });

    public ILocator Single => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$maritalStatus.value-0\"]");

    public ILocator SomeCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Some College", Exact = true });



    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer Theft Deductible_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    public ILocator TotalAnnualMileage => _page.Locator("[name=\"Total_annual_mileage\"], [id=\"Total_annual_mileage\"]").First;

    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UIMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Dynamically set by buffer UMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    public ILocator UMPDMoreOptionsCoverages => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD More Options Coverages", Exact = true });

    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD/UIMPD_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    public ILocator UnderConstruction => _page.GetByRole(AriaRole.Button, new() { Name = "Under Construction", Exact = true });


    public ILocator UnknownNoHighSchoolDiplomaOrGED => _page.GetByRole(AriaRole.Button, new() { Name = "Unknown/No High School Diploma or GED", Exact = true });

    public ILocator UseCAMoreOptions => _page.GetByRole(AriaRole.Button, new() { Name = "Use_CA_More_Options", Exact = true });

    public ILocator VIN06D01 => _page.Locator("[name=\"txt_VIN\"], [id=\"txt_VIN\"]").First;



    public ILocator Veh1 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper");


    public ILocator Vehicle1 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$vINSelect.value-vin-select-\"*\"-chip-chip");


    public ILocator VehicleMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-menu-trigger");



    public ILocator VocationalOrTradeSchoolDegree => _page.GetByRole(AriaRole.Button, new() { Name = "Vocational or Trade School Degree", Exact = true });


    public ILocator WorkMilesDay => _page.Locator("[name=\"Work_miles_day\"], [id=\"Work_miles_day\"]").First;

    public ILocator Yes => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-0\"]");


    public ILocator YrsLicensedCurrentState => _page.Locator("input[id=\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\"][name=\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\"]");

}
