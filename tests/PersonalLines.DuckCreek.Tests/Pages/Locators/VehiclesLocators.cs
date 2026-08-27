using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator AccountOwner => _page.GetByTestId("fields.line.driver.rows[0].driverInput$relationToAccountOwner.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    public ILocator AccountOwnerReadOnly => _page.Locator("[id=\"\"fields.line.driver.rows[0].driverInput$gender.value-0\"\"]");

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator ActiveDisablingDevice => _page.GetByRole(AriaRole.Button, new() { Name = "ActiveDisablingDevice", Exact = true });

    // Source modules: EQ || Add Cycle/Next | confidence=Medium score=113
    public ILocator AddAdditionalVehicle => _page.GetByRole(AriaRole.Button, new() { Name = "Add Additional Vehicle", Exact = true });

    // Source modules: EQ || Add Cycle/Next | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Discount(NEW) | Next | Id
    public ILocator AddCycleNextNext => _page.Locator("[id=\"fields.data.next\"]");

    // Source modules: EQ||Vehicle Summary Next/Add  | confidence=High score=130
    public ILocator AddVehicle => _page.GetByTestId("fields.policy.line.add_Vehicle");

    // Source modules: EQ||Vehicle Information | confidence=High score=100
    public ILocator AdditionalVehicle => _page.GetByTestId("_vehicleChips-chip-wrapper");

    // Source modules: EQ||Vehicle Information | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Vehicle Information | Additional Vehicle(s) | Id
    public ILocator AdditionalVehicleS62C9A => _page.Locator("[id=\"unlistedVehicle\"]");

    // Source modules: EQ || CyclePreFillSelection | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Information | Additional Vehicle(s) | Id
    // v56 semantic alias: same physical raw-Tosca control as AdditionalVehicleS62C9A
    public ILocator AdditionalVehicleSF5D93 => AdditionalVehicleS62C9A;

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Agreed Value | Id+Name
    public ILocator AgreedValue8E288 => _page.Locator("input[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\\\"\"][name=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$agreedValue.value\\\"\"]");

    // Source modules: EQ || Vintage Cycle | confidence=High score=127
    public ILocator AgreedValueF302B => AgreedValue8E288; // semantic alias; locator defined once

    // Source modules: EQ || 1st Cycle | confidence=High score=97
    // v56 raw Tosca primary: EQ || 1st Cycle | Annual Mileage | Id+Name
    public ILocator AnnualMileage12A49 => _page.Locator("input[id=\"\\\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\\\"\"][name=\"\\\"fields.line.risk.rows[0].vehicleInput$annualMileage.value\\\"\"]");

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator AnnualMileage51344 => _page.Locator("[name=\"txt_annual_mileage\"], [id=\"txt_annual_mileage\"]").First;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator AntiTheftYes => _page.GetByRole(AriaRole.Button, new() { Name = "Anti_theft_Yes", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Appraisal Date | Id+Name
    public ILocator AppraisalDate8A115 => _page.Locator("input[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\\\"\"][name=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$appraisalDate.value\\\"\"]");

    // Source modules: EQ || Vintage Cycle | confidence=High score=127
    public ILocator AppraisalDateD909C => AppraisalDate8A115; // semantic alias; locator defined once

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator Assigned => _page.GetByTestId("fields.line.driver.rows[0].driverInput$operatorStatus.value-chip-wrapper");

    // Source modules: EQ || Expired License Pop Up | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Continue | Id
    public ILocator CONTINUED555D => _page.Locator("[id=\"btnConfirmYes\"]");

    // Source modules: EQ || Owned Popup | confidence=Medium score=113
    public ILocator CONTINUEF07C7 => CONTINUED555D; // semantic alias; locator defined once

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator CamperShellNo => _page.GetByRole(AriaRole.Button, new() { Name = "Camper_Shell_No", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator CategoryI => _page.GetByRole(AriaRole.Button, new() { Name = "CategoryI", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Modern Classic | Id+attributes_data-testid
    public ILocator Classic => _page.Locator("div[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-0\\\"\"][data-testid=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-wrapper\\\"\"]");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=Medium score=108
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Automobile | Id+attributes_data-testid
    public ILocator CollectorCar => _page.Locator("div[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-0\\\"\"][data-testid=\"\\\"fields.line.risk.rows[0].vehicleInput$vehicleType.value-chip-wrapper\\\"\"]");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator CollectorCarTypeMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-menu-trigger");

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator CollegeDegreeGraduateWork => _page.GetByRole(AriaRole.Button, new() { Name = "College Degree/Graduate Work", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Continue | Id
    // v56 semantic alias: same physical raw-Tosca control as CONTINUED555D
    public ILocator Continue => CONTINUED555D;

    // Source modules: EQ || 1st Cycle | confidence=High score=97
    // v56 raw Tosca primary: EQ || 1st Cycle | Current Value | Id+Name
    public ILocator CurrentValue => _page.Locator("input[id=\"\\\"fields.line.risk.rows[0].vehicleInput$currentValue.value\\\"\"][name=\"\\\"fields.line.risk.rows[0].vehicleInput$currentValue.value\\\"\"]");

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=83
    public ILocator CurrentlyInCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Currently in College", Exact = true });

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || Vintage Cycle | Cycle VIN | Id+Name
    public ILocator Cycle1734D7 => _page.Locator("input[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$vIN.value\\\"\"][name=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$vIN.value\\\"\"]");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator Cycle1C1864 => Cycle1734D7; // semantic alias; locator defined once

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Cycle Accessories_V3 | Id
    public ILocator CycleAccessoriesV3 => _page.Locator("[id=\"\"fields.policy.line.risk.rows[1].end_IncreasedLimitsForAccessories$end_IncreasedLimitsForAccessories_Select.value-0\"\"]");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Cycle Accessories_V4 | Id
    // v56 semantic alias: same physical raw-Tosca control as CycleAccessoriesV3
    public ILocator CycleAccessoriesV4 => CycleAccessoriesV3;

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=97
    public ILocator CycleNonDriverComboBox => _page.Locator("[name=\"CycleNonDriver_ComboBox\"], [id=\"CycleNonDriver_ComboBox\"]").First;

    // Source modules: EQ || CyclePreFillSelection | confidence=Medium score=113
    public ILocator CyclePreFillSelectionNext => AddCycleNextNext; // semantic alias; locator defined once

    // Source modules: EQ || Vintage Cycle | confidence=High score=127
    // v56 raw Tosca primary: EQ || Vintage Cycle | Cycle VIN | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as Cycle1734D7
    public ILocator CycleVIN => Cycle1734D7;

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || DriverLicense_Time | Months Licensed Current State | Id+Name
    public ILocator DaysOperatedUninsured => _page.Locator("input[id=\"\\\"fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value\\\"\"][name=\"\\\"fields.line.driver.rows[0].driverInput$monthsLicensedCurrentState.value\\\"\"]");

    // Source modules: EQ || 1st Cycle | confidence=High score=97
    // v56 raw Tosca primary: EQ || 1st Cycle | Description of Mods | Id+Name
    public ILocator DescriptionOfMods => _page.Locator("input[id=\"\\\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\\\"\"][name=\"\\\"fields.line.risk.rows[0].vehicleInput$describeAdditionAlterationOrModification.value\\\"\"]");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Divorced | Id
    public ILocator Divorced => _page.Locator("[id=\"\"fields.line.driver.rows[0].driverInput$maritalStatus.value-2\"\"]");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || 1st Cycle | Agreed Value | Id+Name
    public ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD => _page.Locator("input[id=\"\\\"fields.line.risk.rows[0].vehicleInput$agreedValue.value\\\"\"][name=\"\\\"fields.line.risk.rows[0].vehicleInput$agreedValue.value\\\"\"]");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    public ILocator DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications21ABD => DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD; // semantic alias; locator defined once

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || DriverLicense_Time | Months Licensed Current State | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as DaysOperatedUninsured
    public ILocator DriverSLicenseNumber => DaysOperatedUninsured;

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
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator IsThisDriverANamedInsured => AccountOwnerReadOnly;

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || Vintage Cycle | Cycle VIN | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as Cycle1734D7
    public ILocator IsThisVehicleOwnedOrFinanced => Cycle1734D7;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LblDescriptionOfMods => _page.GetByText("Lbl_Description of Mods", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator LblOwnedPopup => _page.GetByText("Lbl_Owned Popup", new() { Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator Leased14EA4 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Leased | Id+attributes_data-testid
    public ILocator Leased26B32 => _page.Locator("div[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-1\\\"\"][data-testid=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\\\"\"]");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator Leased87268 => Leased26B32; // semantic alias; locator defined once

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || DriverLicense_Time | Months Licensed Current State | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as DaysOperatedUninsured
    public ILocator LicenseState => DaysOperatedUninsured;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator Loan4369D => Leased14EA4; // semantic alias; locator defined once

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Loan | Id+attributes_data-testid
    public ILocator Loan49242 => _page.Locator("div[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-0\\\"\"][data-testid=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\\\"\"]");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator LoanED36C => Loan49242; // semantic alias; locator defined once

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MDNJEducationLevelUnknown => _page.GetByText("MD_NJ_EducationLevel == \"Unknown", new() { Exact = true });

    // Source modules: EQ||Vehicle Information | confidence=High score=100
    public ILocator MOREOPTIONS => _page.GetByTestId("_vehicleChips-menu-trigger");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator MaritalStatusSingle => _page.GetByText("'Marital Status' != \"Single", new() { Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Married | Id
    public ILocator Married => _page.Locator("[id=\"\"fields.line.driver.rows[0].driverInput$maritalStatus.value-1\"\"]");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator MedicalCondition => AccountOwnerReadOnly;

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator Military => AccountOwnerReadOnly;

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator Missionary => AccountOwnerReadOnly;

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator ModernClassic => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$collectorCarType.value-chip-wrapper");

    // Source modules: EQ || DriverLicense_Time | confidence=High score=127
    // v56 raw Tosca primary: EQ || DriverLicense_Time | Months Licensed Current State | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as DaysOperatedUninsured
    public ILocator MonthsLicensedCurrentState => DaysOperatedUninsured;

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=83
    public ILocator MoreOptionsEdu => _page.GetByRole(AriaRole.Button, new() { Name = "More Options Edu", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator MoreOptionsFarmUse => _page.GetByRole(AriaRole.Button, new() { Name = "More_Options_Farm_Use", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator MoreOptionsNonDriver => AccountOwnerReadOnly;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    public ILocator N1Day => _page.GetByRole(AriaRole.Button, new() { Name = "1_Day", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator NYFFCICTotalAnnualMiles => _page.Locator("[name=\"NY_FFCIC_total_annual_miles\"], [id=\"NY_FFCIC_total_annual_miles\"]").First;

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator NamedInsured => _page.GetByTestId("fields.line.driver.rows[0].driverInput$namedInsuredType.value-chip-wrapper");

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator NativeAmericanRegisterNO => _page.GetByRole(AriaRole.Button, new() { Name = "Native_American_Register_NO", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator NeverLicensed => AccountOwnerReadOnly;

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || Cycle Underwriting | No | Id
    public ILocator No7C269 => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-1\"]");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    public ILocator NoCoverageV1Towing => _page.Locator("[id=\"\"fields.policy.line.risk.rows[0].end_OriginalParts$end_OriginalParts_Select.value-0\"\"]");

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator NoCycleLicense => AccountOwnerReadOnly;

    // Source modules: EQ || DriverLicense_Time | confidence=High score=130
    public ILocator NoD053A => _page.GetByTestId("fields.line.driver.rows[0].driverInputUnderwriting$sR22Indicator.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator NoD9E4D => No7C269; // semantic alias; locator defined once

    // Source modules: EQ || Prior Insurance Info | confidence=High score=130
    public ILocator NoNeedWasNotLicensed => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$reasonForNoPriorInsurance.value-chip-wrapper");

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=100
    public ILocator NoPreviouslyInsured => _page.GetByTestId("fields.line.driver.rows[0].insuranceHistoryManualInput$wasThisClientIssuedWithAN.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=83
    public ILocator NoRegisteredFedTribe => _page.GetByRole(AriaRole.Button, new() { Name = "No_RegisteredFedTribe", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=100
    public ILocator NonDriver => Assigned; // semantic alias; locator defined once

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator NonDriverReason => AccountOwnerReadOnly;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=97
    public ILocator NonWorkAnnualMiles => _page.Locator("[name=\"Non_work_annual_miles\"], [id=\"Non_work_annual_miles\"]").First;

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=100
    public ILocator NotANamedInsured => NamedInsured; // semantic alias; locator defined once

    // Source modules: EQ || 1st Cycle | confidence=Medium score=83
    public ILocator NotPleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Not Pleasure Use", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator Odometer3843F => _page.Locator("[name=\"txt_odometer\"], [id=\"txt_odometer\"]").First;

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Odometer | Id+Name
    public ILocator OdometerD648F => _page.Locator("input[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\\\"\"][name=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$odometer.value\\\"\"]");

    // Source modules: EQ || CA Verified Mileage | confidence=Medium score=113
    // Dynamically set by buffer CA Verified Mileage in RTB Auto | 05 EQ | Vehicle Summary Next
    // v56 raw Tosca primary: EQ || CA Verified Mileage | Opt Out | Id
    public ILocator OptOut => _page.Locator("[id=\"fields.policy.lineVerifiedMileage.riskFactor_VerifiedMileageOptIn$value.value-1\"]");

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V3 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator OriginalPartsV3 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=High score=127
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V4 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator OriginalPartsV4 => NoCoverageV1Towing;

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=108
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator OtherInsurance => AccountOwnerReadOnly;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator Own49EEC => Leased14EA4; // semantic alias; locator defined once

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Own | Id+attributes_data-testid
    public ILocator Own7C709 => _page.Locator("div[id=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-2\\\"\"][data-testid=\"\\\"fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper\\\"\"]");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator OwnB8575 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$isVehicleOwnedOrFinanced.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator OwnD044E => Own7C709; // semantic alias; locator defined once

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator PermitDriver => AccountOwnerReadOnly;

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || Vintage Cycle | Cycle VIN | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as Cycle1734D7
    public ILocator PleaseSelectTheVehicleBBB72 => Cycle1734D7;

    // Source modules: EQ || 1st Cycle | confidence=Medium score=78
    public ILocator PleaseSelectTheVehicleCD741 => PleaseSelectTheVehicleBBB72; // semantic alias; locator defined once

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=130
    public ILocator PleasureCANYFFCIC => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$usage.value-chip-wrapper");

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator PleasureUse => _page.GetByRole(AriaRole.Button, new() { Name = "Pleasure Use", Exact = true });

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator PostGraduateDegreeMedicalDegreePhDEdDEtc => _page.GetByRole(AriaRole.Button, new() { Name = "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)", Exact = true });

    // Source modules: EQ||Pricing Details | confidence=Medium score=114
    // v56 raw Tosca primary: EQ||Pricing Details | Lbl_Residence Summary | Id
    public ILocator PricingDetailsNext => _page.Locator("[id=\"Policy_Headless.Constant_ResidenceSummary-0-layout\"]");

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator PrimaryNamedInsured => NamedInsured; // semantic alias; locator defined once

    // Source modules: EQ || Prior Insurance Info | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || Prior Insurance Info | Time with prior carrier | Id
    public ILocator PriorCarrierName => _page.Locator("[id=\"Driver_Headless.Constant_TimeWithPriorCarrier-0-layout\"]");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator PurchaseDate736F4 => _page.Locator("[name=\"Purchase_date\"], [id=\"Purchase_date\"]").First;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=127
    public ILocator PurchaseDateBB8AF => _page.Locator("[name=\"txt_purchase_date\"], [id=\"txt_purchase_date\"]").First;

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator Related => Assigned; // semantic alias; locator defined once

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
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator Roommate => AccountOwnerReadOnly;

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator SaveAndContinue8EF26 => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // Source modules: EQ || Prior Insurance Info | confidence=Medium score=113
    public ILocator SaveAndContinue9CB7A => SaveAndContinue8EF26; // semantic alias; locator defined once

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    public ILocator SaveAndContinueBE6CD => SaveAndContinue8EF26; // semantic alias; locator defined once

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Save_Continue | Id
    public ILocator SaveContinue2E7CD => _page.Locator("[id=\"fields.data.policy.line.risk.vehicle_Detail_Done\"]");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=Medium score=113
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | Save_Continue | Id
    // v56 semantic alias: same physical raw-Tosca control as SaveContinue2E7CD
    public ILocator SaveContinue86B78 => SaveContinue2E7CD;

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator SelectVehicle => _page.GetByText("Select Vehicle", new() { Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Single | Id
    public ILocator Single => _page.Locator("[id=\"\"fields.line.driver.rows[0].driverInput$maritalStatus.value-0\"\"]");

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator SomeCollege => _page.GetByRole(AriaRole.Button, new() { Name = "Some College", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=High score=130
    public ILocator Spouse => AccountOwner; // semantic alias; locator defined once

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator Surrendered => AccountOwnerReadOnly;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator TheftDeductibleV1 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator TheftDeductibleV2 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator TheftDeductibleV3 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer Theft Deductible_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator TheftDeductibleV4 => NoCoverageV1Towing;

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    public ILocator TotalAnnualMileage => _page.Locator("[name=\"Total_annual_mileage\"], [id=\"Total_annual_mileage\"]").First;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UIMPDCoverageV1 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UIMPDCoverageV2 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UIMPDCoverageV3 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UIMPD Coverage_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UIMPDCoverageV4 => NoCoverageV1Towing;

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
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UMPDUIMPDV1 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V2 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UMPDUIMPDV2 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UMPDUIMPDV3 => NoCoverageV1Towing;

    // Source modules:  EQ || Vehicle Coverages Section | confidence=Medium score=113
    // Dynamically set by buffer UMPD/UIMPD_V1 in RTB Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages
    // v56 raw Tosca primary: EQ || Vehicle Coverages Section | Original Parts_V1 | Id
    // v56 semantic alias: same physical raw-Tosca control as NoCoverageV1Towing
    public ILocator UMPDUIMPDV4 => NoCoverageV1Towing;

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    public ILocator UnderConstruction => _page.GetByRole(AriaRole.Button, new() { Name = "Under Construction", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator Underage => AccountOwnerReadOnly;

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=83
    public ILocator UnknownNoHighSchoolDiplomaOrGED => _page.GetByRole(AriaRole.Button, new() { Name = "Unknown/No High School Diploma or GED", Exact = true });

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=Medium score=83
    public ILocator UseCAMoreOptions => _page.GetByRole(AriaRole.Button, new() { Name = "Use_CA_More_Options", Exact = true });

    // Source modules: EQ||Vehicle Auto Vin_1 | confidence=High score=127
    public ILocator VIN06D01 => _page.Locator("[name=\"txt_VIN\"], [id=\"txt_VIN\"]").First;

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=127
    // v56 raw Tosca primary: EQ||Vehicle Summary Auto Additional | VIN | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as Cycle1734D7
    public ILocator VIN0A17C => Cycle1734D7;

    // Source modules: EQ || 1st Cycle | confidence=High score=127
    public ILocator VIN8EE56 => VIN0A17C; // semantic alias; locator defined once

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator Veh1 => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vINSelect.value-chip-wrapper");

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator Veh3 => Veh1; // semantic alias; locator defined once

    // Source modules: EQ||Vehicle Auto Vin_1 | confidence=High score=130
    public ILocator Vehicle1 => _page.GetByTestId("fields.line.risk.rows[0].vehicleInput$vINSelect.value-vin-select-\"*\"-chip-chip");

    // Source modules: EQ||Vehicle Information | confidence=Medium score=113
    public ILocator VehicleInformationNext => PricingDetailsNext; // semantic alias; locator defined once

    // Source modules: EQ||Vehicle Summary Auto Additional | confidence=High score=130
    public ILocator VehicleMoreOptions => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$vehicleType.value-menu-trigger");

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || Vintage Cycle | Cycle VIN | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as Cycle1734D7
    public ILocator VehicleType => Cycle1734D7;

    // Source modules: EQ || Vintage Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || Vintage Cycle | Cycle VIN | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as Cycle1734D7
    public ILocator Vintage => Cycle1734D7;

    // Source modules: EQ || DriverEducationLevel | confidence=Medium score=113
    public ILocator VocationalOrTradeSchoolDegree => _page.GetByRole(AriaRole.Button, new() { Name = "Vocational or Trade School Degree", Exact = true });

    // Source modules: EQ || NamedIns_Operator Status | confidence=Medium score=78
    // v56 raw Tosca primary: EQ || NamedIns_Operator Status | Male | Id
    // v56 semantic alias: same physical raw-Tosca control as AccountOwnerReadOnly
    public ILocator WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove => AccountOwnerReadOnly;

    // Source modules: EQ||Vehicle Summary Auto/Motor Home Use | confidence=High score=97
    public ILocator WorkMilesDay => _page.Locator("[name=\"Work_miles_day\"], [id=\"Work_miles_day\"]").First;

    // Source modules: EQ || 1st Cycle | confidence=Medium score=113
    // v56 raw Tosca primary: EQ || Cycle Underwriting | Yes | Id
    public ILocator Yes => _page.Locator("[id=\"fields.data.policy.underwritingQuestionsPolicy$felonyConviction.value-0\"]");

    // Source modules: EQ || DriverLicense_Time | confidence=Medium score=83
    // v56 raw Tosca primary: EQ || DriverLicense_Time | Months Licensed Current State | Id+Name
    // v56 semantic alias: same physical raw-Tosca control as DaysOperatedUninsured
    public ILocator YrsLicensedAllStates => DaysOperatedUninsured;

    // Source modules: EQ || DriverLicense_Time | confidence=High score=127
    // v56 raw Tosca primary: EQ || DriverLicense_Time | Yrs Licensed Current State | Id+Name
    public ILocator YrsLicensedCurrentState => _page.Locator("input[id=\"\\\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\\\"\"][name=\"\\\"fields.line.driver.rows[0].driverInput$yearsLicensedCurrentState.value\\\"\"]");

}
