using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    public ILocator AccountOwner => _page.GetByTestId("fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper");

    public ILocator AccountOwnerReadOnly => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$gender.value-0\"]");

    public ILocator ActiveDisablingDevice => _page.GetByRole(AriaRole.Button, new() { Name = "ActiveDisablingDevice", Exact = true });

    public ILocator AddAdditionalVehicle => _page.GetByTestId("fields.policy.line.add_Vehicle-button-label");

    public ILocator AddCycleNextNext => _page.GetByTestId("auto-vehicle-prefill-selection-next-button-button-label").GetByText("Next").Or(this._page.GetByTestId("fields.policy.next").GetByText("Next")); 

    public ILocator AddVehicle => _page.GetByTestId("fields.policy.line.add_Vehicle");


    public ILocator AdditionalVehicle => _page.GetByTestId("_vehicleChips-chip-label").Filter(new() { HasText = "Additional Vehicle(s)" });



    public ILocator MoreOptionsDropdownLabel => _page.Locator("span.dropdown-label").Filter(new() { HasText = "MORE OPTIONS" });

    public ILocator SelectVehiclesToBeCoveredHeader => _page.Locator("h2.chip-group-title").Filter(new() { HasText = "Select vehicles to be covered:" });

    public ILocator AdditionalVehicleSMenuItem => _page.Locator("span.menu-item-label").Filter(new() { HasText = "Additional Vehicle(s)" });

    public ILocator AutoVehiclePrefillSelectionNext => _page.GetByTestId("auto-vehicle-prefill-selection-next-button");

    public ILocator AdditionalVehicleS62C9A => _page.GetByTestId("_vehicleChips-chip-wrapper").GetByText("Additional Vehicle(s)");


    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true })
       .Or(_page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true }))
       .Or(_page.GetByTestId("fields.policy.next"));


    public ILocator AgreedValue8E288 => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\"]");


    public ILocator AnnualMileage12A49 => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\"][name=\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\"]");

    public ILocator AnnualMileage51344 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value").First;

    public ILocator ActiveDisablingDeviceAndWindowGlassEtching => _page.GetByTestId("fields.data.policy.line.risk.rows[0].antiTheftRiskFactor$value.value-chip-label").Filter(new() { HasText = "Active Disabling Device and Window Glass Etching" });

    public ILocator AntiTheftYes => _page.GetByTestId("fields.data.policy.line.risk.rows[0].antiTheftRiskFactor$selected.value-chip-label").Filter(new() { HasText = "Yes" });

    public ILocator VehicleUsedForBusinessNo => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleUsedForBusiness.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator VehicleUsedForBusinessNoVeh4 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleUsedForBusiness.value-chip-label").Filter(new() { HasText = "No" });

    public ILocator HowManyDaysPerWeek1 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$howManyDaysPerWeek.value-chip-label").Filter(new() { HasText = "1" });

    public ILocator HowManyDaysPerWeek1Veh4 => _page.GetByTestId("fields.data.policy.line.risk.rows[3].vehicleInput$howManyDaysPerWeek.value-chip-label").Filter(new() { HasText = "1" });

    public ILocator HowManyMilesPerDayOneWay => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$howManyMilesPerDayOneWay.value");

    public ILocator HowManyMilesPerDayOneWayVeh4 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$howManyMilesPerDayOneWay.value");

    public ILocator HowManyAnnualMilesDrivenOutside => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$howManyAnnualMilesDrivenOutside.value");

    public ILocator HowManyAnnualMilesDrivenOutsideVeh4 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$howManyAnnualMilesDrivenOutside.value");

    public ILocator HistoricalPlatesVintage => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$historicalPlates.value-chip-label").Filter(new() { HasText = "Vintage" });

    public ILocator AppraisalDate8A115 => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\"]");


    public ILocator Assigned => _page.GetByTestId("fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper").Nth(0);


    public ILocator CONTINUED555D => _page.Locator("[data-testid='btnConfirmYes']").Filter(new() { HasText = "Continue" });

    public ILocator FinancialResponsibilitySR44No => _page.GetByTestId("fields.line.driver.rows[0].driverInputUnderwriting$sR22Indicator.value-chip-label").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex(@"^\s*No\s*$") });
    public ILocator CamperShellNo => _page.GetByRole(AriaRole.Button, new() { Name = "Camper_Shell_No", Exact = true });

    public ILocator CategoryI => _page.GetByRole(AriaRole.Button, new() { Name = "CategoryI", Exact = true });

    public ILocator Classic => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-item']").Filter(new() { HasText = "Classic" });

    public ILocator CollectorCar => _page.Locator("span.menu-item-label").Filter(new() { HasText = "Collector Car" }).First;

    public ILocator CollectorCarTypeMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-trigger");

    public ILocator CollegeDegreeGraduateWork => _page.GetByRole(AriaRole.Button, new() { Name = "College Degree/Graduate Work", Exact = true });


    public ILocator CurrentValue => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$currentValue.value\"][name=\"fields.line.risk.rows[0].vehicleInput$currentValue.value\"]");

    public ILocator CurrentlyInCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Currently in College", Exact = true });

    public ILocator Cycle1734D7 => _page.Locator("input[data-testid*=\"rows[0].vehicleInput$vIN.value\"]");
    
    public ILocator CycleAccessoriesV3 => _page.Locator("[id=\"fields.policy.line.risk.rows[1].end_IncreasedLimitsForAccessories$end_IncreasedLimitsForAccessories_Select.value-0\"]");


    public ILocator CycleNonDriverComboBox => _page.Locator("[name=\"CycleNonDriver_ComboBox\"], [id=\"CycleNonDriver_ComboBox\"]").First;



    public ILocator YrsLicensedAllStates => _page.Locator("input[id=\"fields.line.driver.rows[0].driverInput$totalYearAllStates.value\"][name=\"fields.line.driver.rows[0].driverInput$totalYearAllStates.value\"]");

    public ILocator AllStatesTimeLicensedMonths => _page.Locator("input[id=\"fields.line.driver.rows[0].driverInput$totalMonthsAllStates.value\"][name=\"fields.line.driver.rows[0].driverInput$totalMonthsAllStates.value\"]");

    public ILocator DaysOperatedUninsured => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$numberOfDaysOperatedUninsuredVehicle.value");

    public ILocator MonthsLicensedCurrentState => _page.GetByTestId("fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value");

    public ILocator DescriptionOfMods => _page.Locator("input[id=\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\"][name=\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\"]");

    public ILocator engineCC => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$engineDisplacement.value").Or(_page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$engineDisplacement.value"));

    public ILocator Divorced => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$maritalStatus.value-2\"]");

    public ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD => _page.GetByText(" Does this vehicle have any Non-Factory Additions, Alterations, or Modifications? ");

    public ILocator DriverLicenceNumber => _page.GetByTestId("fields.line.driver.rows[0].driverInput$driversLicenseNumber.value");

    public ILocator EQCAVerifiedMileage => _page.GetByText("EQ || CA Verified Mileage", new() { Exact = true });

    public ILocator GraduateDegreeJDMasters => _page.GetByRole(AriaRole.Button, new() { Name = "Graduate Degree (JD, Masters)", Exact = true });

    public ILocator HighSchoolDiplomaOrGED => _page.GetByTestId("fields.line.driver.rows[0].driverInput$educationLevel.value-chip-label").GetByText("High School Diploma or GED").First;

    public ILocator ILCategory1 => _page.GetByRole(AriaRole.Button, new() { Name = "IL_Category_1", Exact = true });



    public ILocator LblDescriptionOfMods => _page.GetByText("Lbl_Description of Mods", new() { Exact = true });

    public ILocator LblOwnedPopup => _page.GetByText("Owned or Financed?", new() { Exact = true });

    public ILocator Leased14EA4 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper").First;

    public ILocator Leased26B32 => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-1\"][data-testid=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"]");




    public ILocator Loan49242 => _page.Locator("div[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-0\"][data-testid=\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\"]");


    public ILocator MDNJEducationLevelUnknown => _page.GetByText("MD_NJ_EducationLevel == \"Unknown", new() { Exact = true });

    public ILocator MOREOPTIONS => _page.GetByTestId("_vehicleChips-menu-trigger");

    public ILocator MaritalStatusSingle => _page.Locator("[data-testid='fields.line.driver.rows[0].driverInput$maritalStatus.value-chip-wrapper']").Filter(new() { HasText = "Single" });

    public ILocator GenderLabel => _page.Locator("label.asterisk-after").Filter(new() { HasText = "Gender" });

    public ILocator GenderMale => _page.GetByTestId("fields.line.driver.rows[0].driverInput$gender.value-chip-label").GetByText("Male", new() { Exact = true });

    public ILocator OperatorStatusAssigned => _page.Locator("[data-testid='fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper']").Filter(new() { HasText = "Assigned" });

    public ILocator Married => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$maritalStatus.value-1\"]");




    public ILocator ModernClassic => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-label']").Filter(new() { HasText = "Modern Classic" });


    public ILocator MoreOptionsEdu => _page.GetByRole(AriaRole.Button, new() { Name = "More Options Edu", Exact = true });

    public ILocator MoreOptionsFarmUse => _page.GetByRole(AriaRole.Button, new() { Name = "More_Options_Farm_Use", Exact = true });


    public ILocator N1Day => _page.GetByRole(AriaRole.Button, new() { Name = "1_Day", Exact = true });

    public ILocator NYFFCICTotalAnnualMiles => _page.Locator("[name=\"NY_FFCIC_total_annual_miles\"], [id=\"NY_FFCIC_total_annual_miles\"]").First;

    public ILocator NamedInsured => _page.Locator("[data-testid='fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper']").Filter(new() { HasText = "Primary Named Insured" });

    public ILocator DriversLicenseNumber => _page.Locator("[data-testid='fields.line.driver.rows[0].driverInput$driversLicenseNumber.value']");

    public ILocator NativeAmericanRegisterNO => _page.GetByRole(AriaRole.Button, new() { Name = "Native_American_Register_NO", Exact = true });


    public ILocator No7C269 => _page.Locator("[data-testid$='.rows[0].vehicleInput$hasTheVehicleModified.value-chip-wrapper']").Nth(1);

    public ILocator NoCoverageV1Towing => _page.GetByTestId("fields.policy.line.risk.rows[0].covUninsuredMotoristsPDInput$limit.value-chip-wrapper").GetByText("No Coverage");

    public ILocator NoCoverageV2Towing => _page.GetByTestId("fields.policy.line.risk.rows[1].covUninsuredMotoristsPDInput$limit.value-chip-wrapper").GetByText("No Coverage");

    public ILocator NoD053A => _page.GetByTestId("//*[@id=\"undefined\"]/main/fieldset/div/div[18]/anico-form/ng-component/div/div/aa-regular-chips/div/div[1]/div/span");


    public ILocator NoNeedWasNotLicensed => _page.Locator("[data-testid='fields.line.driver.rows[0].insuranceHistoryManualInput$reasonForNoPriorInsurance.value-chip-wrapper']").Filter(new() { HasText = "No  Need -  Was  Not  Licensed" });


    public ILocator NB3NotLicensedLink => _page.Locator("//*[@id=\"undefined\"]/main/fieldset/div/div[27]/anico-form/ng-component/div/div/aa-regular-chips/div/div[3]/aa-hover-tooltip/span/div");

    public ILocator NoPreviouslyInsured => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-wrapper");

    public ILocator NoRegisteredFedTribe => _page.GetByRole(AriaRole.Button, new() { Name = "No_RegisteredFedTribe", Exact = true });



    public ILocator NonWorkAnnualMiles => _page.Locator("[name=\"Non_work_annual_miles\"], [id=\"Non_work_annual_miles\"]").First;


    public ILocator NotPleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Not Pleasure Use", Exact = true });

    public ILocator Odometer3843F => _page.Locator("[data-testid='fields.line.risk.rows[0].vehicleInput$odometer.value']");

    public ILocator VehicleTotalAnnualMileage => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value']");

    public ILocator OdometerD648F => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\"]");

    public ILocator OdometerRows0 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value");

    // Dynamically set by buffer CA Verified Mileage in RTB Auto | 05 EQ | Vehicle Summary Next
    public ILocator OptOut => _page.GetByTestId("fields.policy.lineVerifiedMileage.riskFactor_VerifiedMileageOptIn$value.value-chip-label").Filter(new() { HasText = "Opt Out" });





    public ILocator Own7C709 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper").Nth(2).Or(_page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper").Nth(2));

    public ILocator OwnB8575 => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-label']").Filter(new() { HasText = "Own" });

    public ILocator VehicleOwnedOrFinancedOwnAgreedValue => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-label']").Filter(new() { HasText = "Own" });





    public ILocator PleasureCANYFFCIC => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$usage.value-chip-label").Filter(new() { HasText = "Pleasure" });

    public ILocator PleasureCANYFFCICVeh4 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$usage.value-chip-label").Filter(new() { HasText = "Pleasure" });

    public ILocator PleasureUse => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper").First;


    public ILocator PleasureWorkUse => _page.Locator("[data-testid='fields.line.risk.rows[0].vehicleInput$usage.value-chip-label']").Filter(new() { HasText = "Pleasure/Work Use" });

    public ILocator PostGraduateDegreeMedicalDegreePhDEdDEtc => _page.GetByRole(AriaRole.Button, new() { Name = "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)", Exact = true });


    public ILocator Vechicle2 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper").First;



    public ILocator PricingDetailsNext =>
        _page.Locator("[id=\"Policy_Headless.Constant_ResidenceSummary-0-layout\"], [id=\"Policy.Constant_ResidenceSummary-0-layout\"]")
            .Or(_page.GetByTestId("fields.policy.next"))
            .Or(_page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true }));


    public ILocator PriorCarrierName => _page.Locator("[id=\"Driver_Headless.Constant_TimeWithPriorCarrier-0-layout\"]");

    public ILocator ClientInsuredAN => _page.GetByText(" Was this client insured with American National immediately prior to the carrier listed above? ");

    public ILocator ClientInsuredANNo => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-wrapper").GetByText("No");


    public ILocator UnderWriterRulesHeader => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Underwriting Rules" });

    public ILocator PurchaseDate736F4 => _page.Locator("input[id='fields.data.policy.line.risk.rows[0].vehicleInput$purchaseDate.value'][name='fields.data.policy.line.risk.rows[0].vehicleInput$purchaseDate.value']");

    public ILocator PurchaseDateVeh4 => _page.Locator("input[id='fields.data.policy.line.risk.rows[0].vehicleInput$purchaseDate.value'][name='fields.data.policy.line.risk.rows[0].vehicleInput$purchaseDate.value']");

    public ILocator OdometerVeh4 => _page.Locator("input[id='fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value'][name='fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value']");

    public ILocator PurchaseDateBB8AF => _page.Locator("[id='fields.line.risk.rows[0].vehicleInput$purchaseDate.value']");


    public ILocator RelationshipToAccountOwnerNULL => _page.GetByText("'Relationship to Account Owner' != NULL", new() { Exact = true });

    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covRentalReimbursementInput$limit.value-chip-wrapper").Nth(1);

    // Dynamically set by buffer Rental Reimbursement Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covRentalReimbursementInput$limit.value-chip-wrapper").Nth(1);

    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covRentalReimbursementInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Rental Reimbursement Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RentalReimbursementCoverageV4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covRentalReimbursementInput$limit.value-chip-wrapper");

    public ILocator RestrictedUse => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$usage.value-chip-label']").Filter(new() { HasText = "Restricted Use" });

    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covRoadsideAssistanceInput$limit.value-chip-wrapper").First;

    // Dynamically set by buffer Roadside Assistance Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covRoadsideAssistanceInput$limit.value-chip-wrapper").First;

    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covRoadsideAssistanceInput$limit.value-chip-wrapper");

    // Dynamically set by buffer Roadside Assistance Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator RoadsideAssistanceCoverageV4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covRoadsideAssistanceInput$limit.value-chip-wrapper");


    public ILocator SaveAndContinue8EF26 => _page.Locator("[data-testid='fields.line.save_and_Continue']").Filter(new() { HasText = "Save and Continue" });

    public ILocator SaveandContinue => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Save and Continue" });

    public ILocator FinancialResponsibilityNo => _page.Locator("[data-testid='fields.line.driver.rows[0].driverInputUnderwriting$sR22Indicator.value-chip-wrapper']").Filter(new() { HasText = "No" });

    public ILocator InsuredWithANPriorLabel => _page.Locator("label.asterisk-after").Filter(new() { HasText = "Was this client insured with American National immediately prior to the carrier listed above?" });

    public ILocator InsuredWithANPriorNoChip => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-label")
        .Filter(new() { HasText = "No" });





    public ILocator SaveContinue86B78 => _page.Locator("[data-testid='fields.data.policy.line.risk.vehicle_Detail_Done-button-label']").Filter(new() { HasText = "Save and Continue" });

    public ILocator SaveContinue2E7CD =>
        _page.Locator("[id=\"fields.data.policy.line.risk.vehicle_Detail_Done\"], [id=\"fields.policy.line.risk.vehicle_Detail_Done\"], [id=\"fields.line.risk.vehicle_Detail_Done\"]")
            .Or(_page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true }));


    public ILocator SelectVehicle => _page.GetByText("Select Vehicle", new() { Exact = true });

    public ILocator Single => _page.Locator("[id=\"fields.line.driver.rows[0].driverInput$maritalStatus.value-0\"]");

    public ILocator SomeCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Some College", Exact = true });



    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer Theft Deductible_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    public ILocator TotalAnnualMileage => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value\"]");

    public ILocator TotalAnnualMileageVeh4 => _page.Locator("input[id=\"fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value\"][name=\"fields.data.policy.line.risk.rows[0].vehicleInput$annualMileage.value\"]");

    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UIMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle1 => _page.GetByTestId("fields.policy.line.risk.rows[0].covUninsuredMotoristsPDInput$limit.value-chip-label").Nth(3);

    // Dynamically set by buffer UMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle2 => _page.GetByTestId("fields.policy.line.risk.rows[1].covUninsuredMotoristsPDInput$limit.value-chip-wrapper").Nth(3);

    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle3 => _page.GetByTestId("fields.policy.line.risk.rows[2].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    // Dynamically set by buffer UMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    public ILocator UMPDCoverageVehicle4 => _page.GetByTestId("fields.policy.line.risk.rows[3].covUninsuredMotoristsPDInput$limit.value-chip-wrapper");

    public ILocator UMPDMoreOptionsCoverages => _page.GetByRole(AriaRole.Button, new() { Name = "UMPD More Options Coverages", Exact = true });

    public ILocator UMPDVehicle1MoreOptions => _page.GetByTestId("fields.policy.line.risk.rows[0].covUninsuredMotoristsPDInput$limit.value-menu-trigger");

    public ILocator UMPDVehicle2MoreOptions => _page.GetByTestId("fields.policy.line.risk.rows[1].covUninsuredMotoristsPDInput$limit.value-menu-trigger");

    public ILocator UMPDOneHundredThousandOption => _page.Locator("[data-testid*='.covUninsuredMotoristsPDInput$limit.value-menu-item']:visible").GetByText("$100,000", new() { Exact = true });

    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages // fields.policy.line.risk.rows[1].covUninsuredMotoristsPDInput$limit.value-menu-item

    // Dynamically set by buffer UMPD/UIMPD_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages

    public ILocator UnderConstruction => _page.GetByRole(AriaRole.Button, new() { Name = "Under Construction", Exact = true });


    public ILocator UnknownNoHighSchoolDiplomaOrGED => _page.GetByTestId("fields.line.driver.rows[0].driverInput$educationLevel.value-chip-label").GetByText("Unknown/No High School Diploma or GED");

    public ILocator UseCAMoreOptions => _page.GetByRole(AriaRole.Button, new() { Name = "Use_CA_More_Options", Exact = true });


    public ILocator VIN06D01 => _page
        .Locator("input[data-testid*='vehicleInput$vIN.value'], input[id*='vehicleInput$vIN.value'], input[name*='vehicleInput$vIN.value']")
        .First
        .Or(_page.GetByTestId("fields.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper"))
        .Or(_page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper"));




    public ILocator Veh1 => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-label']").Filter(new() { HasText = "1979 Jeep PICKUP PICKUP 1727" });

    public ILocator Veh3 => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-label']").Filter(new() { HasText = "2014 Chevrolet CAMARO CAMARO CONV LT ETHAN RWD 6 SPD MANU 6 CYL 217354" });

    public ILocator Veh4 => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-label']").Filter(new() { HasText = "1980 Mercury GR MARQUIS GR MARQUIS 2514" });


   
    public ILocator VehicleNB1 => _page.Locator("[data-testid='fields.line.risk.rows[0].vehicleInput$vINSelect.value-chip-label']").Nth(0);

    public ILocator Vehicle1 => _page
        .Locator("[data-testid^='fields.line.risk.rows[0].vehicleInput$vINSelect.value-vin-select-'][data-testid$='-chip-chip']")
        .First
        .Or(_page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper").First);




    public ILocator VehicleOwnedOrFinancedOwn => _page.Locator("[data-testid='fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-label']").Filter(new() { HasText = "Own" });

    public ILocator VehicleTypeAutomobile => _page.Locator("[data-testid='fields.line.risk.rows[0].vehicleInput$vehicleType.value-chip-label']").Filter(new() { HasText = "Automobile" });

    public ILocator CustomizedEquipmentNo => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].nonFactoryAdditions$anyCustomizedEquipment.value-chip-label'], [data-testid='fields.line.risk.rows[0].nonFactoryAdditions$anyCustomizedEquipment.value-chip-label']").Filter(new() { HasText = "No" });

    public ILocator CustomizedEquipmentNoVeh4 => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].nonFactoryAdditions$anyCustomizedEquipment.value-chip-label']").Filter(new() { HasText = "No" });

    public ILocator AntiTheftCategory1 => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].antiTheftRiskFactor$value.value-chip-label']").Filter(new() { HasText = "Category I" });

    public ILocator AntiTheftCategory1WithoutLock => _page.GetByTestId("fields.data.policy.line.risk.rows[0].antiTheftRiskFactor$value.value-chip-label").Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex("^Category 1 Without Lock$") });

    public ILocator UsedInTravellingOrPermanentResidenceNo => _page.Locator("label[for='fields.line.risk.rows[0].underwritingQuestionsVehicle$usedInTravellingOrPermanentResidence.value-0-input']").Filter(new() { HasText = "No" });


    public ILocator VehicleMoreOptions => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-trigger']");

    public ILocator VehicleTypeMoreOptions => _page.Locator("[data-testid='fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-menu-trigger']").Filter(new() { HasText = "MORE OPTIONS" });



    public ILocator VocationalOrTradeSchoolDegree => _page.GetByRole(AriaRole.Button, new() { Name = "Vocational or Trade School Degree", Exact = true });


    public ILocator WorkMilesDay => _page.Locator("[name=\"Work_miles_day\"], [id=\"Work_miles_day\"]").First;

    public ILocator Yes => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-0\"]");


    public ILocator YrsLicensedCurrentState => _page.Locator("input[id=\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\"][name=\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\"]");

    public ILocator YrsLicensecAllStates => _page.GetByTestId("fields.line.driver.rows[0].driverInput$totalYearAllStates.value");
   


    public ILocator Male => _page
        .Locator("[data-testid$='.driverInput$gender.value-chip-label'], [data-testid$='.driverInput$gender.value-chip-wrapper']")
        .Filter(new() { HasTextRegex = new System.Text.RegularExpressions.Regex(@"^\s*Male\s*$") })
        .First;


    public ILocator PleaseSelectVehicleHeading => _page.GetByText("Please select the vehicle");
    public ILocator SelectFirstVehicle => _page.Locator("div[data-testid*='fields.line.risk.rows[0].vehicleInput$vINSelect.value-vin-select-']").Nth(1).Or(_page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper").Nth(0));

    public ILocator VehicleTypeHeading => _page.GetByText(" Vehicle Type ");
    public ILocator SelectMotorCycle => _page.Locator("div[data-testid*='.rows[0].vehicleInput$vehicleType.value-chip-wrapper']").First;
    public ILocator SelectVintage => _page.Locator("div[data-testid*='.rows[0].vehicleInput$vehicleType.value-chip-wrapper']").Nth(1);

    public ILocator DriverInformationHeader => _page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Driver Summary" });
}
