# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 157_Auto_-_Adding_Vehicle_State_Code_6.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Auto @manual_conversion @Edge @manual @archive @automated
Feature: Execute Auto - Adding Vehicle for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Auto - Adding Vehicle workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Auto - Adding Vehicle using representative iteration State Code_6
    # Source step 0016: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > A | Initial Poilcy Creation > 01 Start New Quote and Client Selection > Start New Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-56f2-c4ca-67c965ec8163
    Given I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0017: Client Selection-Enter Client Info & Create New Client | Module: EQ || Client Selection
    # Section: Process > A | Initial Poilcy Creation > 01 Start New Quote and Client Selection | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-e3e6-8bfb-b97a22bc05b9
    Then I wait until "<unnamed value>" exists
    When I enter captured runtime value "FirstName" in "<unnamed value>"
    When I enter captured runtime value "LastName" in "<unnamed value>"
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0018: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > A | Initial Poilcy Creation > 01 Start New Quote and Client Selection | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-9507-eeb4-8b93e53c8417
    Then I wait until "Lbl_Account Information" exists
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I enter or select "9072298577" in "Txt_Best phone_Account Owner"
    When I enter or select "out@aol.com" in "Txt_Email_Account Owner"
    When I click "Btn_Single"
    When I enter captured runtime value "StreetAddress" in "Txt_Enter a location"
    When I enter captured runtime value "City" in "Txt_owner.address.city_New"
    When I enter the RUNTIME-DERIVED buffer expression "{click}{SENDKEYS[{B[State]}]}{ENTER}" in "Drpdwn_State"
    When I enter captured runtime value "ZIP" in "Txt_owner.address.zip"
    When I select "Btn_Yes_at least 90 days"
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0019: Set LOB & Writing Company | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-1bad-699c-a44fe3238b3c
    When I retain hard-coded value "Personal Auto" as runtime value "LOB"
    When I retain hard-coded value "ANP" as runtime value "WritingCompany"

    # Source step 0020: Check LOB | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > Select Home/Motorcycle/Peronal Auto/RV | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-1a0c-cd0f-5adc660c2bf3
    # Runtime control: Select LOB Personal Auto > Condition
    When if the source runtime condition "Select LOB Personal Auto > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0021: Select Personal Auto | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > Select Home/Motorcycle/Peronal Auto/RV | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-184a-c28e-8695f89459d0
    # Runtime control: Select LOB Personal Auto > Then
    When if the source runtime condition "Select LOB Personal Auto > Then" is satisfied, I click "Btn_Personal Auto"

    # Source step 0022: Check LOB | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > Select Home/Motorcycle/Peronal Auto/RV | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-ae12-79d4-41629f667b95
    # Runtime control: Select LOB RV > Condition
    When if the source runtime condition "Select LOB RV > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0023: Select RV | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > Select Home/Motorcycle/Peronal Auto/RV | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-1d1a-cc98-0ed7489fab9f
    # Runtime control: Select LOB RV > Then
    When if the source runtime condition "Select LOB RV > Then" is satisfied, I click "Btn_Recreational Vehicle"

    # Source step 0024: Check LOB | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > Select Home/Motorcycle/Peronal Auto/RV | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-063f-2aed-c401ea0a2efa
    # Runtime control: Select LOB Motorcycle > Condition
    When if the source runtime condition "Select LOB Motorcycle > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0025: Select Motorcycle | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > Select Home/Motorcycle/Peronal Auto/RV | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-2080-39f1-e2fa4fce532d
    # Runtime control: Select LOB Motorcycle > Then
    When if the source runtime condition "Select LOB Motorcycle > Then" is satisfied, I click "Btn_Motorcycle"

    # Source step 0026: Select Effective Date Rating State | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-a2bf-7c2e-53cb68afc062
    Then I wait until "Btn_PERSONAL AUTO" is visible
    When I enter captured runtime value "EffectiveDate" in "Txt_Effective Date_1"
    When I enter or select "tas" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I select "Drp List_Rating State_1"
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"

    # Source step 0027: Select Same as New Account Address & Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-9443-6ef3-d8b08470d1fc
    Then I wait until "Rd Btn_Same as New Account Address" is enabled
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0028: Verify that Invalid address pop up is shown  | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-a26d-3455-f45174181635
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0029: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-a3e7-9154-6b049c1902f7
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0030: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-db2d-1c98-8b48c4f1ac83
    # Runtime control: SSN > Condition
    Then if the source runtime condition "SSN > Condition" is satisfied, I wait until "<unnamed value>" is visible

    # Source step 0031: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-2e08-3959-060f406c39d7
    # Runtime control: SSN > Then
    When if the source runtime condition "SSN > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"
    When I click "<unnamed value>"

    # Source step 0032: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-3048-935c-4450fbeca159
    # Runtime control: SSN > Else - Provide SSN
    When if the source runtime condition "SSN > Else - Provide SSN" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start > zz Wait | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-2e3c-dcbd-259e1b97cc17
    # Runtime control: SSN > Else - Provide SSN
    When if the source runtime condition "SSN > Else - Provide SSN" is satisfied, I wait "3000" milliseconds

    # Source step 0034: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-e60a-3742-f5dbf6c97df6
    # Runtime control: SSN > Else - Provide SSN > If > Condition
    Then if the source runtime condition "SSN > Else - Provide SSN > If > Condition" is satisfied, "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0035: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: Older  Auto | 02 EQ | Proposal Start  | Source XTestStep: 3a19dd55-d425-419f-cbc9-13ebbf50e86a
    # Runtime control: SSN > Else - Provide SSN > If > Then
    When if the source runtime condition "SSN > Else - Provide SSN > If > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0036: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-27a2-0aeb-e656a12d76e1
    # Runtime control: If > Condition
    Then if the source runtime condition "If > Condition" is satisfied, "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0037: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > A | Initial Poilcy Creation > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-ca6c-1d6d-916489105b38
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0038: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > A | Initial Poilcy Creation > 03 Pre-Qualification > 03 EQ | Auto - Pre-Qualification | Reusable flow: Auto | 03 EQ | Pre-Qualification (New) | Source XTestStep: 3a19dd55-d425-4b84-160d-b4880cf2b369
    When I enter or select "{CLICK}" in "Btn_Chk box_check_boxNone Of The Above"
    When I enter or select "{CLICK}" in "Btn_Next"

    # Source step 0039: Select Existing Client as Driver and Click Next | Module: EQ||Driver Information
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-c18a-9e1e-a18bf8f11437
    When I click "(Existing Client)_1"
    When I click "Btn_Next"

    # Source step 0040: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d213-f2ec-4048d91e2f1e
    # Runtime control: Gender > Condition - check if gender is not already populated
    Then if the source runtime condition "Gender > Condition - check if gender is not already populated" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0041: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-31f4-e99d-8174f0e8bc09
    # Runtime control: Gender > Then- select gender and continue
    When if the source runtime condition "Gender > Then- select gender and continue" is satisfied, I click "Btn_Male"

    # Source step 0042: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-a26c-1422-b93d19b73a28
    # Runtime control: Primary Named Insured > Condition
    Then if the source runtime condition "Primary Named Insured > Condition" is satisfied, "Btn_Primary Named Insured" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0043: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-6fed-aabc-ab91aa49dcfd
    # Runtime control: Primary Named Insured > Then
    When if the source runtime condition "Primary Named Insured > Then" is satisfied, I click "Btn_Primary Named Insured"

    # Source step 0044: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-7b8c-7764-0b610db7791c
    # Runtime control: Assigned Operator Status > Condition
    Then if the source runtime condition "Assigned Operator Status > Condition" is satisfied, "Btn_Assigned" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0045: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d8f7-df94-664f5d66b78c
    # Runtime control: Assigned Operator Status > Then
    When if the source runtime condition "Assigned Operator Status > Then" is satisfied, I click "Btn_Assigned"

    # Source step 0046: Enter  Driver's License Number  | Module: Driver Information
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-dfed-f5a4-41dc79c4a941
    When I click "Field Driver's License Number"
    When I enter or select "\"^{a}\"" in "Field Driver's License Number"
    When I enter captured runtime value "DLNumber" in "Field Driver's License Number"

    # Source step 0047: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-99d6-bd76-aca34017061c
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"

    # Source step 0048: Driver Summary | Module: Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-fa29-d0f9-e5b4c1b7ab46
    # Runtime control: Date License > Condition
    Then if the source runtime condition "Date License > Condition" is satisfied, "Date Licensed" should exist

    # Source step 0049: Driver Summary | Module: Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-19cf-69da-d54146d7792a
    # Runtime control: Date License > Then
    When if the source runtime condition "Date License > Then" is satisfied, I click "Date Licensed"
    When I enter the RUNTIME-DERIVED buffer expression "{Sendkeys[{DATE[{B[DOB]}][+20y][MM/dd/yyyy]}]}" in "Date Licensed"

    # Source step 0050: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-4ef5-3b03-14662bb5fe9a
    # Runtime control: Financia Responsibility > Condition
    Then if the source runtime condition "Financia Responsibility > Condition" is satisfied, "Btn_FinancialResponsibility_No" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0051: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-652d-651d-e8e045692110
    # Runtime control: Financia Responsibility > Then
    When if the source runtime condition "Financia Responsibility > Then" is satisfied, I select "Btn_FinancialResponsibility_No"

    # Source step 0052: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-8203-89f0-3a0a897643f1
    # Runtime control: Prior Insurance > Condition
    Then if the source runtime condition "Prior Insurance > Condition" is satisfied, "Btn_PriorInsurance_No" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0053: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-1020-1f37-8319d91c3449
    # Runtime control: Prior Insurance > Then
    When if the source runtime condition "Prior Insurance > Then" is satisfied, I select "Btn_PriorInsurance_No"

    # Source step 0054: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-3cf0-c280-25cb8b42b261
    # Runtime control: Prior Insurance > Then > If > Condition
    Then if the source runtime condition "Prior Insurance > Then > If > Condition" is satisfied, "Btn_No Need- Did Not Own a Vehicle" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0055: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-273b-9e54-b2d42b1dcab4
    # Runtime control: Prior Insurance > Then > If > Then
    When if the source runtime condition "Prior Insurance > Then > If > Then" is satisfied, I select "Btn_No Need- Did Not Own a Vehicle"

    # Source step 0056: Click on Save and Continue | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d86b-5e91-a92c6b673c78
    When I click "Btn_Save and Continue"

    # Source step 0057: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-c368-e151-682dea92c2bb
    # Runtime control: Driver Summary-UW Popup > Condition - check if popup appears
    Then if the source runtime condition "Driver Summary-UW Popup > Condition - check if popup appears" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0058: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-cd26-24e8-4573b3ca1260
    # Runtime control: Driver Summary-UW Popup > Then- click on continue
    When if the source runtime condition "Driver Summary-UW Popup > Then- click on continue" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0059: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-9b7c-39fe-8aa349b24652
    When I click "Btn_Next"

    # Source step 0060: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-2386-47a1-e5965f402ac7
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition-  check vehicle button is visible
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition- check vehicle button is visible" is satisfied, I wait until "btn_select vehicle1" exists

    # Source step 0061: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-5312-f6d6-5521ba32e954
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then- select vehicle and continue
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then- select vehicle and continue" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0062: Add VIN Number and Select Listed Vehicle | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-5ae5-0653-bb153ce7b6fb
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I enter or select "1FDKE30G9JHA64433" in "Txt_VIN number"

    # Source step 0063: Check ClassName | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information > Select Listed Vehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-652e-767e-523cd2f8564c
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Btn_SelectVehicle_1" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0064: Add VIN Number | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information > Select Listed Vehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-82fc-2cfe-4462ae881003
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I click "Btn_SelectVehicle_1"

    # Source step 0065: Add Vehicle Summary | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-4806-e066-8c176071b74b
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" is enabled
    When I enter or select "No" in "Btn_Does this Vehicle"
    Then I wait until "Txt_PurchaseDate" is enabled
    When I enter a RANDOM value matching "15][20 random digits/characters" in "Txt_PurchaseDate"
    When I click "Txt_Odometer"
    When I enter or select "\"^{a}\"" in "Txt_Odometer"
    When I enter a RANDOM value matching "10000][15000 random digits/characters" in "Txt_Odometer"
    When I enter or select "\"^{a}\"" in "Txt_AnnualMileage"
    When I enter a RANDOM value matching "1000][1500 random digits/characters" in "Txt_AnnualMileage"
    When I click "Btn_Save and Continue"

    # Source step 0066: Get VehicleName | Module: Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d98b-b7b4-57fee3bbabd9
    # Runtime control: Do [max=5] > Condition
    Then if the source runtime condition "Do [max=5] > Condition" is satisfied, "Existing Vehicle > Existing Vehicle VIN" should equal "1FDKE30G9JHA64433"

    # Source step 0067: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-e940-d62c-39eaa8cc91ca
    # Runtime control: Do [max=5] > Loop
    When if the source runtime condition "Do [max=5] > Loop" is satisfied, I retain hard-coded value "{Repetition}" as runtime value "VehicleIndex"

    # Source step 0068: Get VehicleName | Module: Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d4b1-b839-728df04399a8
    When I capture "InnerText" from "Existing Vehicle > Vehicle Name" as runtime value "VehicleName"

    # Source step 0069: Reset VehicleIndex | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-c771-801c-a86c319cbaab
    When I retain hard-coded value "1" as runtime value "VehicleIndex"

    # Source step 0070: Click on Next | Module: Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d6ae-1f1c-4b30567fc5de
    When I click "Next"

    # Source step 0071: Change Name to TitleCase | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-b215-d7dc-6fcf5db0b2bd
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[LastName]}\"\"\"\")]}" as runtime value "LName"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[FirstName]}\"\"\"\")]}" as runtime value "FName"

    # Source step 0072: Driver Assignment | Module: Driver Assignment
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-5afb-2052-b10b8ed5140e
    When I click "Current Driver Assignment > Vehicle"
    When I click "Current Driver Assignment > Principal"
    When I click "Next"

    # Source step 0073: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-4745-c8b9-652786f5c54c
    # Runtime control: Driver Assignment- UW Popup > Condition - check if popup appears
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - check if popup appears" is satisfied, "Lnk_CONTINUE" should be visible

    # Source step 0074: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-1341-3141-d07a4a2197fb
    # Runtime control: Driver Assignment- UW Popup > Then - click on continue
    When if the source runtime condition "Driver Assignment- UW Popup > Then - click on continue" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0075: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > A | Initial Poilcy Creation > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-37e1-d117-0a604f32e5a1
    Then I wait until "Hdr_Edit Violation" is visible
    When I click "Btn_Next"

    # Source step 0076: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > A | Initial Poilcy Creation > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-1e2f-6d78-79176dde1a70
    Then I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_Next" is enabled
    When I click "Btn_Next"

    # Source step 0077: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-9327-00de-aa8e346b3549
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"

    # Source step 0078: Coverage | Module: Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-0df9-e7a2-c4d35db18264
    Then "Vehicle Box > H2" should equal captured runtime value "VehicleName"
    When I click "Vehicle Box > 500"
    When I select "Vehicle Box > NoCoverage"
    When I click "Next"

    # Source step 0079: Wait for Page to Load | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-ca84-cc62-34153fdadbfb
    Then I wait until "Accidental Death & Dismemberment - No Coverage" is enabled

    # Source step 0080: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-bb95-05c1-f91fae3e3457
    # Runtime control: If Accidental Death & Dismemberment - No Coverage Is not Selected > Condition
    Then if the source runtime condition "If Accidental Death & Dismemberment - No Coverage Is not Selected > Condition" is satisfied, "Accidental Death & Dismemberment - No Coverage" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0081: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-147d-a435-e608781bbd1c
    # Runtime control: If Accidental Death & Dismemberment - No Coverage Is not Selected > Then
    When if the source runtime condition "If Accidental Death & Dismemberment - No Coverage Is not Selected > Then" is satisfied, I select "Accidental Death & Dismemberment - No Coverage"

    # Source step 0082: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-d28d-5609-2d56a2d0fee6
    # Runtime control: If Loss of Income Coverage Is Not Selected > Condition
    Then if the source runtime condition "If Loss of Income Coverage Is Not Selected > Condition" is satisfied, "Loss Of Income Coverage" should have "ClassName" equal to "mat-focus-indicator btn-toggle-checkbox mat-raised-button mat-button-base ng-star-inserted"

    # Source step 0083: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-8460-1540-1236abcee386
    # Runtime control: If Loss of Income Coverage Is Not Selected > Then
    When if the source runtime condition "If Loss of Income Coverage Is Not Selected > Then" is satisfied, I click "Loss Of Income Coverage"

    # Source step 0084: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage > Select - Uninsured Motorist PD | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-1c07-b920-11b9426119d8
    # Runtime control: If Uninsured Motorist PD - No Coverage Is not Selected > Condition
    Then if the source runtime condition "If Uninsured Motorist PD - No Coverage Is not Selected > Condition" is satisfied, "Uninsured Motorist PD - No Coverage" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0085: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage > Select - Uninsured Motorist PD | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-760e-cbeb-4b3b973011cc
    # Runtime control: If Uninsured Motorist PD - No Coverage Is not Selected > Then
    When if the source runtime condition "If Uninsured Motorist PD - No Coverage Is not Selected > Then" is satisfied, I select "Uninsured Motorist PD - No Coverage"

    # Source step 0086: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-2644-ab99-e5f183b48fb5
    When I click "Next"

    # Source step 0087: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > A | Initial Poilcy Creation > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-fbdb-d9ac-100434a3149c
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Btn_Next" exists

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 10 Pricing | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0089: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > A | Initial Poilcy Creation > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-9e66-a59e-9d0bdde32776
    Then I wait until "Btn_Next" exists
    When I click "Btn_Next"

    # Source step 0090: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > A | Initial Poilcy Creation > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-f97e-8ace-362a693198ba
    When I click "<unnamed value>"

    # Source step 0091: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process > A | Initial Poilcy Creation > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d50-241a-505a-13d82e758f18
    When I click "btn_Next"

    # Source step 0092: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > A | Initial Poilcy Creation > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
    Then I wait until "Hdr_Billing" is visible
    When I click "Btn_Create New Billing Account"
    When I enter or select "{Click}{Scroll[3]}" in "Btn_Primary Account Holder name"
    When I enter or select "{Click}{scroll[3]}" in "Btn_Direct Bill"
    When I click "Btn_1 Payment"
    When I enter or select "25" in "Txt_PaymentDueDate"
    When I click "Rd Btn_Full Balance"
    When I click "Btn_CHECK"
    When I enter or select "1234" in "Txt_Check Number"
    When I click "Btn_Billing_NEXT"

    # Source step 0097: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-3050-c747-442f1da071ac
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Hdr_Submission Header" should be visible

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0099: Submission-Review & Continue | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-83da-42df-c150b2c86fe2
    # Runtime control: If Comments are Required > Condition
    Then if the source runtime condition "If Comments are Required > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0100: Submission-Review & Continue | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-63f9-28d1-7be88090e669
    # Runtime control: If Comments are Required > Then
    When if the source runtime condition "If Comments are Required > Then" is satisfied, I enter or select "Review Required" in "Txt_AgentComments"

    # Source step 0101: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-fb48-ea10-506864e423e8
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0102: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-096e-39b3-9f442f51fb00
    # Runtime control: If_eChecklist Sign on Page is Visible > Condition
    Then if the source runtime condition "If_eChecklist Sign on Page is Visible > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0103: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-a825-5318-f15abe032dc6
    # Runtime control: If_eChecklist Sign on Page is Visible > Then
    When if the source runtime condition "If_eChecklist Sign on Page is Visible > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0104: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-6bbd-754e-7f1ca253de21
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"

    # Source step 0105: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-200c-e96c-ab94f8cdcaf5
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0106: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0107: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-0580-0bf7-94c7c19502c2
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0108: eChecklist-Click the drag/drop link to upload the file in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-bdb6-a7a5-42be8a603e35
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0109: Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-e23b-d4cf-827d28d6bf2d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0110: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-ea11-00b4-b67ca0b11070
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0111: Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-76dc-c64f-58c9e596d239
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0112: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-0a28-9329-8207032f19a9
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0113: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-f96f-3856-c26b47ad9894
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0114: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a6ac-5210-1c0cb8a88b72
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0115: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I wait "2000" milliseconds

    # Source step 0116: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-e597-5619-47dc276f4f40
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0117: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-dbde-fcb0-d3f5d123559a
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0118: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a25d-2718-6c70c2b9457b
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0119: Click on Transmit | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-a3e8-117c-c53160d478e3
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0120: Verify EffectiveDate and Policy Premium and Number | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-5863-06f9-afea5d04e1a5
    Then "Lbl_Value_Total Policy Premium" should equal the RUNTIME-DERIVED environment value from "${XB[Premium]}"
    Then "Lbl_Value_Effective Date" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"
    Then "Lbl_Value_Policy Number" should equal "{XB[Policy Number]}"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "ChecklistId"

    # Source step 0121: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process > A | Initial Poilcy Creation > 16 TDS Operations for Further Validations > 16 TDS Operations for Further Validations | Reusable flow: TDS | Home & Auto - Push Quote Data & Policy Information to TDS | Source XTestStep: 3a19dd55-d416-f362-2870-cad1df2136ae
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATETIME[][][MM/dd/yyyyhhmm]}"
    And I use TDM parameter "Data structure > FirstName" with captured runtime value "FirstName"
    And I use TDM parameter "Data structure > LastName" with captured runtime value "LastName"
    And I use TDM parameter "Data structure > DOB" with captured runtime value "DOB"
    And I use TDM parameter "Data structure > SSN" with captured runtime value "SSN"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"
    And I use TDM parameter "Data structure > State" with "IL"

    # Source step 0122: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > A | Initial Poilcy Creation > 16 TDS Operations for Further Validations > 16 TDS Operations for Further Validations | Reusable flow: TDS | Home & Auto - Push Quote Data & Policy Information to TDS | Source XTestStep: 3a19dd55-d416-7ec3-3085-6c6774b8c897
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATETIME[][][MM/dd/yyyyhhmm]}"
    And I use TDM parameter "Data structure > State" with "IL"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0123: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > A | Initial Poilcy Creation > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0124: CloseBrowser | Module: CloseBrowser
    # Section: Process > A | Initial Poilcy Creation > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0137: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > B | 1st Change Transaction on Policy > 01 Policy History > Search Policy with Policy Number | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-1a03-eb4a-8678f58a97b7
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "Policy Number" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0138: Policy History | Module: Policy History
    # Section: Process > B | 1st Change Transaction on Policy > 01 Policy History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-ed64-de8f-c0b335eaa165
    Then I wait until "List Of Changes Table" is visible
    Then "List Of Changes Table > $1 > #1" should equal "New Business"
    Then "List Of Changes Table > $1 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"
    When I click "+ CREATE NEW POLICY CHANGE"

    # Source step 0139: Policy Change Form | Module: Policy Change Form
    # Section: Process > B | 1st Change Transaction on Policy > 02 Policy Change Form | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-4591-8b37-9926c3b4afca
    When I click "New Effective Date"
    When I enter or select "\"^{a}\"" in "New Effective Date"
    When I enter captured runtime value "SecondEffectiveDate" in "New Effective Date"
    When I enter or select "Adding Another Occasional Driver" in "Transaction Reason"
    Then I wait until "OK" is enabled
    When I click "OK"

    # Source step 0140: Click on Add Additional Driver | Module: EQ||Driver Information Next
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-4f02-79f3-7ab4e7070cde
    When I click "Btn_Add Additional Driver"

    # Source step 0141: TestData - Find & provide item | Module: TestData - Find & provide item
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Get Client Data From TDS > TDS | Auto - Find Client From TDS with Sno | Reusable flow: TDS | Auto - Find Client From TDS with Sno | Source XTestStep: 3a19dd55-d425-eea1-cefb-4ed17a7516bf
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "IL_ClientData_Regression"
    And I use TDM parameter "Alias name (item)" with "IL_ClientData_Regression"
    And I use TDM parameter "Data search filter > Sno" with "7"

    # Source step 0142: Set Data-First Name, Last Name, DOB, SSN, State, & Sno | Module: TBox Set Buffer
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Get Client Data From TDS > TDS | Auto - Find Client From TDS with Sno | Reusable flow: TDS | Auto - Find Client From TDS with Sno | Source XTestStep: 3a19dd55-d425-2dc2-a2ce-9ce0eab71a9b
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.FirstName" as runtime value "FirstName"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.LastName" as runtime value "LastName"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.DOB" as runtime value "DOB"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.SSN" as runtime value "SSN"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.City" as runtime value "City"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.State" as runtime value "State"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.ZIP" as runtime value "ZIP"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.HouseNumber" as runtime value "HouseNumber"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.StreetAddress" as runtime value "StreetAddress"
    When I retrieve and retain the RUNTIME-DERIVED TDM value "IL_ClientData_Regression.DLNumber" as runtime value "DLNumber"

    # Source step 0143: Add Driver Details | Module: EQ||Additional Driver Information
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-78af-95a0-eae0f0bf7b3a
    When I enter captured runtime value "FirstName" in "Txt_FirstName"
    When I enter captured runtime value "LastName" in "Txt_LastName"
    When I enter captured runtime value "DOB" in "Txt_DOB"

    # Source step 0144: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-1b9b-98c6-a62cc9b21982
    # Runtime control: Gender > Condition - check if gender is not already populated
    Then if the source runtime condition "Gender > Condition - check if gender is not already populated" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0145: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-2dab-71df-4592203ca15b
    # Runtime control: Gender > Then- select gender and continue > Do [max=30] > Condition
    Then if the source runtime condition "Gender > Then- select gender and continue > Do [max=30] > Condition" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0146: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-0a2f-5bc0-b8944001e585
    # Runtime control: Gender > Then- select gender and continue > Do [max=30] > Loop
    When if the source runtime condition "Gender > Then- select gender and continue > Do [max=30] > Loop" is satisfied, I click "Btn_Male"

    # Source step 0147: TBox Wait | Module: TBox Wait
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Gender > Then- select gender and continue > Do [max=30] > Loop
    When if the source runtime condition "Gender > Then- select gender and continue > Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0148: Check Marital Status | Module: EQ||Additional Driver Information
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-ef9f-716a-124bfbd5dcda
    # Runtime control: Marital Status > Condition - check if gender is not already populated
    Then if the source runtime condition "Marital Status > Condition - check if gender is not already populated" is satisfied, "Btn_Single" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0149: Select Marital Status | Module: EQ||Additional Driver Information
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-bebd-e714-543706a25dde
    # Runtime control: Marital Status > Then- select gender and continue
    When if the source runtime condition "Marital Status > Then- select gender and continue" is satisfied, I click "Btn_Single"

    # Source step 0150: Select Relationship to Account Owner | Module: Driver Information
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-7dba-360b-b4590479fcb5
    When I select "Relationship to Account Owner - More Options"
    Then I wait until "Brother" is visible
    When I click "Brother"

    # Source step 0151: Add SSN and Not Primary Insured | Module: EQ||Additional Driver Information
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-8c32-a6a8-0411b39e9308
    When I click "Txt_SSN"
    When I enter or select "\"^{a}\"" in "Txt_SSN"
    When I enter captured runtime value "SSN" in "Txt_SSN"
    Then I wait until "Btn_Not a Named Insured" is visible
    When I select "Btn_Not a Named Insured"

    # Source step 0152: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-9bef-a25c-584340abffbf
    # Runtime control: Assigned Operator Status > Condition
    Then if the source runtime condition "Assigned Operator Status > Condition" is satisfied, "Btn_Assigned" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0153: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-ff43-2cb9-55c28bec5d2c
    # Runtime control: Assigned Operator Status > Then
    When if the source runtime condition "Assigned Operator Status > Then" is satisfied, I click "Btn_Assigned"

    # Source step 0154: Enter  Driver's License Number  | Module: Driver Information
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-349a-8b80-bd5f9b8d2e75
    When I click "Field Driver's License Number"
    When I enter or select "\"^{a}\"" in "Field Driver's License Number"
    When I enter captured runtime value "DLNumber" in "Field Driver's License Number"

    # Source step 0155: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-fd26-bee7-061de32edc49
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"

    # Source step 0156: Driver Summary | Module: Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-d183-716f-fae318ac335d
    # Runtime control: Date License > Condition
    Then if the source runtime condition "Date License > Condition" is satisfied, "Date Licensed" should exist

    # Source step 0157: Driver Summary | Module: Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-eb43-4fa1-246db15bc477
    # Runtime control: Date License > Then
    When if the source runtime condition "Date License > Then" is satisfied, I click "Date Licensed"
    When I enter the RUNTIME-DERIVED buffer expression "{Sendkeys[{DATE[{B[DOB]}][+20y][MM/dd/yyyy]}]}" in "Date Licensed"

    # Source step 0158: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-546b-9087-649072a21e0c
    # Runtime control: Financia Responsibility > Condition
    Then if the source runtime condition "Financia Responsibility > Condition" is satisfied, "Btn_FinancialResponsibility_No" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0159: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-a6a8-c4e1-515ef4a06089
    # Runtime control: Financia Responsibility > Then
    When if the source runtime condition "Financia Responsibility > Then" is satisfied, I select "Btn_FinancialResponsibility_No"

    # Source step 0160: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-134c-d5c6-20c3b5060936
    # Runtime control: Prior Insurance > Condition
    Then if the source runtime condition "Prior Insurance > Condition" is satisfied, "Btn_PriorInsurance_No" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0161: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-d5a7-42d5-5a5c63c836ff
    # Runtime control: Prior Insurance > Then
    When if the source runtime condition "Prior Insurance > Then" is satisfied, I select "Btn_PriorInsurance_No"

    # Source step 0162: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-4d0b-361f-9a9201506c84
    # Runtime control: Prior Insurance > Then > If > Condition
    Then if the source runtime condition "Prior Insurance > Then > If > Condition" is satisfied, "Btn_No Need- Did Not Own a Vehicle" should have "ClassName" equal to "*toggle-checked*"

    # Source step 0163: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-4db1-013a-e9db43cd00dc
    # Runtime control: Prior Insurance > Then > If > Then
    When if the source runtime condition "Prior Insurance > Then > If > Then" is satisfied, I select "Btn_No Need- Did Not Own a Vehicle"

    # Source step 0164: Click on Save and Continue | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-cd9e-033c-6d45a04cba0f
    When I click "Btn_Save and Continue"

    # Source step 0165: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-f63b-12f1-27089309c561
    # Runtime control: Driver Summary-UW Popup > Condition - check if popup appears
    Then if the source runtime condition "Driver Summary-UW Popup > Condition - check if popup appears" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0166: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-8bac-5057-5e3d8abd2422
    # Runtime control: Driver Summary-UW Popup > Then- click on continue
    When if the source runtime condition "Driver Summary-UW Popup > Then- click on continue" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0167: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-ddd2-87d5-dc30605b4f84
    When I click "Btn_Next"

    # Source step 0168: Click on Next | Module: EQ||Driver Information Next
    # Section: Process > B | 1st Change Transaction on Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-7748-925e-32b5684908da
    Then I wait until "Btn_Next" is enabled
    When I click "Btn_Next"

    # Source step 0169: Change Name to TitleCase | Module: TBox Set Buffer
    # Section: Process > B | 1st Change Transaction on Policy > 05 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-c121-c200-6c1809f2b7e8
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[LastName]}\"\"\"\")]}" as runtime value "LName"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[FirstName]}\"\"\"\")]}" as runtime value "FName"

    # Source step 0170: Driver Assignment | Module: Driver Assignment
    # Section: Process > B | 1st Change Transaction on Policy > 05 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-ab24-446f-adb26359b4f4
    When I click "Current Driver Assignment > Vehicle"
    When I click "Current Driver Assignment > Occasional"
    When I click "Next"

    # Source step 0171: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > B | 1st Change Transaction on Policy > 05 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-32e2-8d5a-810687006bff
    # Runtime control: Driver Assignment- UW Popup > Condition - check if popup appears
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - check if popup appears" is satisfied, "Lnk_CONTINUE" should be visible

    # Source step 0172: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > B | 1st Change Transaction on Policy > 05 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-021a-2454-cda5368fa1d3
    # Runtime control: Driver Assignment- UW Popup > Then - click on continue
    When if the source runtime condition "Driver Assignment- UW Popup > Then - click on continue" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0173: Navigate to Submission | Module: EQ | Side Menu
    # Section: Process > B | 1st Change Transaction on Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-20f8-ad82-e4dbaaf01c28
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0174: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > B | 1st Change Transaction on Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-86e2-cd7c-09bdf99ab2b8
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0175: TBox Wait | Module: TBox Wait
    # Section: Process > B | 1st Change Transaction on Policy > 06 Navigate to Submission and Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "10000" milliseconds

    # Source step 0176: Click on Transmit | Module: EQ||Submission
    # Section: Process > B | 1st Change Transaction on Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-e93a-8763-f91f759de5da
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0177: Verify EffectiveDate and Policy Premium and Number | Module: Transmit Policy
    # Section: Process > B | 1st Change Transaction on Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-61f7-c1fd-1b35fbf5ec26
    Then "Total Policy Premium" should equal the RUNTIME-DERIVED environment value from "${XB[RevisedPremium]}"
    Then "Endorsement Effective Date" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[SecondEffectiveDate]}][][MM/dd/yyyy]}"
    Then "Policy Number" should equal the RUNTIME-DERIVED buffer expression "*{B[Policy Number]}*"

    # Source step 0178: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > B | 1st Change Transaction on Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-a1a4-9c0c-b33191290c85
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0191: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > C | 2nd Change Transaction Policy > 01 Policy History > Search Policy with Policy Number | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-9633-c525-190f3313b56a
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "Policy Number" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0192: Policy History | Module: Policy History
    # Section: Process > C | 2nd Change Transaction Policy > 01 Policy History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-6912-a4c4-29b153e7846b
    Then "List Of Changes Table > $1 > #1" should equal "Endorse"
    Then "List Of Changes Table > $1 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[SecondEffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $2 > #1" should equal "New Business"
    Then "List Of Changes Table > $2 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"
    When I click "+ CREATE NEW POLICY CHANGE"

    # Source step 0193: Policy Change Form | Module: Policy Change Form
    # Section: Process > C | 2nd Change Transaction Policy > 02 Policy Change Form | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-dce3-78b1-2a33370f0b06
    When I click "New Effective Date"
    When I enter or select "\"^{a}\"" in "New Effective Date"
    When I enter captured runtime value "ThirdEffectiveDate" in "New Effective Date"
    When I enter or select "Adding Another Vehicle" in "Transaction Reason"
    Then I wait until "OK" is enabled
    When I click "OK"

    # Source step 0194: Navigate to Vehicle Summary | Module: EQ | Side Menu
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-a966-7cdb-c9daebe22fd2
    Then I wait until "Vehicle Summary" is enabled
    When I click "Vehicle Summary"

    # Source step 0195: Set VehicleIndex | Module: TBox Set Buffer
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Click on Add New Vehicle | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-0945-ecd4-cbf677517501
    When I retain hard-coded value "1" as runtime value "VehicleIndex"

    # Source step 0196: Click on Add Additional Vehicle | Module: Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Click on Add New Vehicle | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-9f03-d13a-a94f346ba420
    Then "Existing Vehicle > Existing Vehicle VIN" should equal "1FDKE30G9JHA64433"
    When I click "Add Additional Vehicle"

    # Source step 0197: Add VIN Number | Module: EQ||Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Add Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-2f7c-d925-da7cc9c10e2c
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I enter or select "JH4DA3440GS001028" in "Txt_VIN number"

    # Source step 0198: Check ClassName | Module: EQ||Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Add Vehicle Information > Select Listed Vehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-f780-bdad-394f5c65e32e
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Btn_SelectVehicle_1" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0199: Add VIN Number | Module: EQ||Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Add Vehicle Information > Select Listed Vehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-e086-f47c-29ab8b514b0c
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I capture "InnerText" from "Btn_SelectVehicle_1" as runtime value "VehicleName"
    When I click "Btn_SelectVehicle_1"

    # Source step 0200: Add Vehicle Summary | Module: EQ||Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Add Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-6c05-c4f1-a77745a7235f
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" is enabled
    When I enter or select "No" in "Btn_Does this Vehicle"
    Then I wait until "Txt_PurchaseDate" is enabled
    When I enter a RANDOM value matching "15][20 random digits/characters" in "Txt_PurchaseDate"
    When I click "Txt_Odometer"
    When I enter or select "\"^{a}\"" in "Txt_Odometer"
    When I enter a RANDOM value matching "10000][15000 random digits/characters" in "Txt_Odometer"
    When I enter or select "\"^{a}\"" in "Txt_AnnualMileage"
    When I enter a RANDOM value matching "1000][1500 random digits/characters" in "Txt_AnnualMileage"
    When I click "Btn_Save and Continue"

    # Source step 0201: Get VehicleName | Module: Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-f642-ffec-522bcaaf88b6
    # Runtime control: Do [max=5] > Condition
    Then if the source runtime condition "Do [max=5] > Condition" is satisfied, "Existing Vehicle > Existing Vehicle VIN" should equal "JH4DA3440GS001028"

    # Source step 0202: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-8253-bbd3-f6bd1db3deba
    # Runtime control: Do [max=5] > Loop
    When if the source runtime condition "Do [max=5] > Loop" is satisfied, I retain hard-coded value "{Repetition}" as runtime value "VehicleIndex"

    # Source step 0203: Get VehicleName | Module: Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-a61f-ad85-e4c2c41e93e2
    When I capture "InnerText" from "Existing Vehicle > Vehicle Name" as runtime value "VehicleName"

    # Source step 0204: Reset VehicleIndex | Module: TBox Set Buffer
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-5e70-f148-0eacd436ef34
    When I retain hard-coded value "1" as runtime value "VehicleIndex"

    # Source step 0205: Click on Next | Module: Vehicle Summary
    # Section: Process > C | 2nd Change Transaction Policy > 03 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-7967-f771-0fc661669f63
    When I click "Next"

    # Source step 0206: Navigate to Discounts / Adjustments | Module: EQ | Side Menu
    # Section: Process > C | 2nd Change Transaction Policy > 04 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-c5cb-3a92-acf7677f3848
    Then I wait until "Discounts / Adjustments" is enabled
    When I click "Discounts / Adjustments"

    # Source step 0207: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > C | 2nd Change Transaction Policy > 04 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-198d-e668-977d6ed6d379
    Then I wait until "Hdr_Discounts / Adjustments" exists

    # Source step 0208: Discounts | Module: Discounts
    # Section: Process > C | 2nd Change Transaction Policy > 04 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-c0e0-cb11-033545d5a639
    # Runtime control: If Multi-Car Discount Is selected > Condition
    Then if the source runtime condition "If Multi-Car Discount Is selected > Condition" is satisfied, "Multi-Car Discount" should have "ClassName" equal to "mat-focus-indicator btn-toggle-checkbox mat-raised-button mat-button-base ng-star-inserted btn-toggle-checkbox-checked cdk-focused cdk-mouse-focused"

    # Source step 0209: Discounts | Module: Discounts
    # Section: Process > C | 2nd Change Transaction Policy > 04 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-efd5-cac7-970f86167c99
    # Runtime control: If Multi-Car Discount Is selected > Then > Do [max=30] > Condition
    Then if the source runtime condition "If Multi-Car Discount Is selected > Then > Do [max=30] > Condition" is satisfied, "Multi-Car Discount" should have "ClassName" equal to "mat-focus-indicator btn-toggle-checkbox mat-raised-button mat-button-base ng-star-inserted"

    # Source step 0210: Discounts | Module: Discounts
    # Section: Process > C | 2nd Change Transaction Policy > 04 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-0ae4-27cd-f0454a1c59a6
    # Runtime control: If Multi-Car Discount Is selected > Then > Do [max=30] > Loop
    When if the source runtime condition "If Multi-Car Discount Is selected > Then > Do [max=30] > Loop" is satisfied, I click "Multi-Car Discount"

    # Source step 0211: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > C | 2nd Change Transaction Policy > 04 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-3751-bef1-9f24a237c087
    Then I wait until "Btn_Next" is enabled
    When I click "Btn_Next"

    # Source step 0212: Navigate to Coverage | Module: EQ | Side Menu
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-12a3-5bd1-710782a0fc83
    Then I wait until "Coverages" is enabled
    When I click "Coverages"

    # Source step 0213: Coverage | Module: Coverage
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-e1ec-9f6c-40709cdd8e85
    Then "Vehicle Box > H2" should equal captured runtime value "VehicleName"
    When I click "Vehicle Box > 500"
    When I select "Vehicle Box > NoCoverage"
    When I click "Next"

    # Source step 0214: Wait for Page to Load | Module: Additional Coverage
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-ed36-a43d-2b8029405701
    Then I wait until "Accidental Death & Dismemberment - No Coverage" is enabled

    # Source step 0215: Additional Coverage | Module: Additional Coverage
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-f434-53bb-f3188d57e699
    # Runtime control: If Accidental Death & Dismemberment - No Coverage Is not Selected > Condition
    Then if the source runtime condition "If Accidental Death & Dismemberment - No Coverage Is not Selected > Condition" is satisfied, "Accidental Death & Dismemberment - No Coverage" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0216: Additional Coverage | Module: Additional Coverage
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-b1da-d9e6-b098666386d7
    # Runtime control: If Accidental Death & Dismemberment - No Coverage Is not Selected > Then
    When if the source runtime condition "If Accidental Death & Dismemberment - No Coverage Is not Selected > Then" is satisfied, I select "Accidental Death & Dismemberment - No Coverage"

    # Source step 0217: ExpertQuote | Module: Additional Coverages
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Addtional Coverage > Select - Uninsured Motorist PD | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-42dc-c7ed-5a2be7ce36f3
    # Runtime control: If Uninsured Motorist PD - No Coverage Is not Selected > Condition
    Then if the source runtime condition "If Uninsured Motorist PD - No Coverage Is not Selected > Condition" is satisfied, "Vehicle Coverage - With VehicleName > No Coverage" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0218: ExpertQuote | Module: Additional Coverages
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Addtional Coverage > Select - Uninsured Motorist PD | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-aeeb-ca30-7cf84370bba7
    # Runtime control: If Uninsured Motorist PD - No Coverage Is not Selected > Then
    When if the source runtime condition "If Uninsured Motorist PD - No Coverage Is not Selected > Then" is satisfied, I select "Vehicle Coverage - With VehicleName > No Coverage"

    # Source step 0219: Additional Coverage | Module: Additional Coverage
    # Section: Process > C | 2nd Change Transaction Policy > 05 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-554f-b031-0b02fb63f2bf
    When I click "Next"

    # Source step 0220: Navigate to Submission | Module: EQ | Side Menu
    # Section: Process > C | 2nd Change Transaction Policy > 06 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-02e7-b0dd-588869a73da1
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0221: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > C | 2nd Change Transaction Policy > 06 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-c65f-e368-b097064e2cfc
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0222: TBox Wait | Module: TBox Wait
    # Section: Process > C | 2nd Change Transaction Policy > 06 Submission | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "10000" milliseconds

    # Source step 0223: Click on Transmit | Module: EQ||Submission
    # Section: Process > C | 2nd Change Transaction Policy > 06 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-adcb-2f5f-2fd47d1737b5
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0224: Verify EffectiveDate and Policy Premium and Number | Module: Transmit Policy
    # Section: Process > C | 2nd Change Transaction Policy > 06 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-b1ec-c2a5-fa203008d14b
    Then "Total Policy Premium" should equal the RUNTIME-DERIVED environment value from "${XB[LatestPremium]}"
    Then "Endorsement Effective Date" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[ThirdEffectiveDate]}][][MM/dd/yyyy]}"
    Then "Policy Number" should equal the RUNTIME-DERIVED buffer expression "*{B[Policy Number]}*"

    # Source step 0225: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > C | 2nd Change Transaction Policy > 06 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-696a-6c39-b6878379c37a
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0226: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Postcondition > Validate in ExpertQuote > Validate Transactions in ExpertQuote > Search Policy with Policy Number | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-0a75-efcb-6f94d22d6f1c
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "Policy Number" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0227: Policy History | Module: Policy History
    # Section: Postcondition > Validate in ExpertQuote > Validate Transactions in ExpertQuote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d5c-a299-d42f-dc9f447b5244
    Then "List Of Changes Table > $1 > #1" should equal "Endorse"
    Then "List Of Changes Table > $1 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[SecondEffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $2 > #1" should equal "Endorse"
    Then "List Of Changes Table > $2 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[ThirdEffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $3 > #1" should equal "New Business"
    Then "List Of Changes Table > $3 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"

    # Source step 0228: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition > Validate in ExpertQuote > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0229: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition > Validate in ExpertQuote > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0230: Force Close Edge | Module: TBox Start Program
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: Common | 00 Force Close Edge Browser | Source XTestStep: 3a19dd55-d3cb-4c12-291b-70baf4eb5889
    And I force-close browser/process "msedge.exe" using command "taskkill /im msedge.exe /f"

    # Source step 0231: Open Edge Preferences file | Module: Open/Create JSON file
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-54de-e510-208fe48a30ee
    And I open or create JSON resource "EdgePreferences" at "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0232: Change Exit Type | Module: Edge Preferences File
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-f7e3-bf94-cfe222ebeeac
    When I set Microsoft Edge preference "RootObject > profile > exit_type" to "none"

    # Source step 0233: Save changes | Module: Save JSON Resource
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-93a3-afa2-8a5a039508f8
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0234: Delete EdgePreferences Resource | Module: TBox Delete Resource
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-d78a-726d-297646009ab1
    When I remove runtime resource "EdgePreferences"

    # Source step 0235: Delete Cookies File | Module: TBox Delete File
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-b4d8-790f-d042719f63ea
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"

    # Source step 0236: TBox Wait | Module: TBox Wait
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: Common | 00 Reset Edge Preferences > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0237: OpenUrl | Module: OpenUrl
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0241: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-28ba-e459-095529cf8ad1
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0242: Provide Express UI Login credentials | Module: EU||Login
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-8887-a010-3dad60af4d76
    # Runtime control: If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0243: Search Policy in Express | Module: EU||Home
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-f24e-9a2a-63a22526e603
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0244: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-3911-d097-4ac379c83040
    When I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0245: Get TotalTransacations | Module: EU||Transact
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate TotalTransactions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-6d68-f096-d3ba8a8aa367
    When I capture "ResultCount" from "Transaction Table Row Un-Identified for Count" as runtime value "TotalTransaction"

    # Source step 0246: Validate TotalTransaction | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate TotalTransactions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-4d9b-fb93-a45fca191e92
    When I retain hard-coded value "3" as runtime value "TotalTransaction"

    # Source step 0247: Total Transacations | Module: EU||Transact
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Find Last Transaction with ThirdEffectiveDate | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-9532-d33d-2a327a7a53fc
    # Runtime control: Do [max={B[TotalTransaction]}] > Condition
    Then if the source runtime condition "Do [max={B[TotalTransaction]}] > Condition" is satisfied, "Transaction Table Row Identified for Validation > Effective Date" should equal the RUNTIME-DERIVED buffer expression "*{B[ThirdEffectiveDate]}*"

    # Source step 0248: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Find Last Transaction with ThirdEffectiveDate | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-31a3-311c-b1436ac3b8ff
    # Runtime control: Do [max={B[TotalTransaction]}] > Loop
    When if the source runtime condition "Do [max={B[TotalTransaction]}] > Loop" is satisfied, I retain hard-coded value "{Repetition}" as runtime value "TransactionRow"

    # Source step 0249: Total Transacations | Module: EU||Transact
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Find Last Transaction with ThirdEffectiveDate | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-54b3-f35e-a5b0332c2e11
    When I click "Transaction Table Row Identified for Validation > Btn_ViewPolicy"

    # Source step 0250: Navigate to Vehicle(s) | Module: Express  | Policy View
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate TotalVehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-3d10-94a7-fcc9b81d4644
    When I enter or select "Vehicle(s)" in "Policy View Tab"

    # Source step 0251: Get TotatlVehicles | Module: Express | Vehicles
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate TotalVehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-ef85-4677-30322da2f8a9
    When I capture "ResultCount" from "Driver Table Row Un-Identified for Count" as runtime value "TotalVehicles"

    # Source step 0252: Validate TotalVehicles | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate TotalVehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-0d53-fda2-a1655a22c8a4
    When I retain hard-coded value "2" as runtime value "TotalVehicles"

    # Source step 0253: Navigate to Drivers | Module: Express  | Policy View
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Drivers | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-1fd0-e1d7-4678f1a3d6ca
    When I enter or select "Driver(s)" in "Policy View Tab"

    # Source step 0254: Get TotatlDrivers | Module: Express | Drivers
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Drivers | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-0a96-4fc0-c23ce960912f
    When I capture "ResultCount" from "Driver Table Row Un-Identified for Count" as runtime value "TotalDrivers"

    # Source step 0255: Validate TotalDrivers | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Drivers | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-532f-46ac-f2913ccf5caf
    When I perform the source-defined buffer operation "Validate TotalDrivers"

    # Source step 0256: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition > Validate in ExpressUI > Express | Close Browser -TransACT Page | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d6d-4070-12d6-4242c4a3cd31
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0093 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 2. Source step 0094 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 3. Source step 0095 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 4. Source step 0096 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 5. Source step 0104 field "Drag and Drop files here to upload (or click here to open a file explorer)" in "eChecklist-Click the documents/links in the checklist" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 6. Source step 0238 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 7. Source step 0239 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 8. Source step 0240 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
