# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 156_Auto_-_Driver_being_added_State_Code_6.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Auto @manual_conversion @Edge @manual @archive @automated
Feature: Execute Auto - Driver being added for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Auto - Driver being added workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Auto - Driver being added using representative iteration State Code_6
    # Source step 0016: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > A | Initial Poilcy Creation > 01 Start New Quote and Client Selection > Start New Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-8cf9-aa59-087ee5228d8b
    Given I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0017: Client Selection-Enter Client Info & Create New Client | Module: EQ || Client Selection
    # Section: Process > A | Initial Poilcy Creation > 01 Start New Quote and Client Selection | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-f479-6662-e1b29e1c294f
    Then I wait until "<unnamed value>" exists
    When I enter captured runtime value "FirstName" in "<unnamed value>"
    When I enter captured runtime value "LastName" in "<unnamed value>"
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0018: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > A | Initial Poilcy Creation > 01 Start New Quote and Client Selection | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-39c3-a058-85cb36057f07
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

    # Source step 0036: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > A | Initial Poilcy Creation > 03 Pre-Qualification > 03 EQ | Auto - Pre-Qualification | Reusable flow: Auto | 03 EQ | Pre-Qualification (New) | Source XTestStep: 3a19dd55-d425-4b84-160d-b4880cf2b369
    When I enter or select "{CLICK}" in "Btn_Chk box_check_boxNone Of The Above"
    When I enter or select "{CLICK}" in "Btn_Next"

    # Source step 0037: Select Existing Client as Driver and Click Next | Module: EQ||Driver Information
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-6c35-6d0b-a5b1729056c3
    When I click "(Existing Client)_1"
    When I click "Btn_Next"

    # Source step 0038: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-3cd6-41fe-d8aff6960467
    When I click "Btn_Primary Named Insured"
    Then "Txt_DL Number" should equal captured runtime value "DLNumber"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0039: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > A | Initial Poilcy Creation > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-1dcb-d3a0-2af62c6eb066
    When I click "Btn_Next"

    # Source step 0040: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-e438-7ecb-72fabd87e45d
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition-  check vehicle button is visible
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition- check vehicle button is visible" is satisfied, I wait until "btn_select vehicle1" exists

    # Source step 0041: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-e940-7f93-8b96b60c99ff
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then- select vehicle and continue
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then- select vehicle and continue" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0042: Add VIN Number and Select Listed Vehicle | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-0aeb-bac8-6a76af090850
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I enter or select "1FDKE30G9JHA64433" in "Txt_VIN number"

    # Source step 0043: Check ClassName | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information > Select Listed Vehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-d44d-c95d-29f1c93921c4
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Btn_SelectVehicle_1" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0044: Add VIN Number | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information > Select Listed Vehicles | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-aa08-ce87-7a589d394395
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I click "Btn_SelectVehicle_1"

    # Source step 0045: Add Vehicle Summary | Module: EQ||Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Add Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-a25e-2b19-0c41b114d6b2
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

    # Source step 0046: Set VehicleIndex | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-dcdd-1f7b-d4f8b382b363
    When I retain hard-coded value "1" as runtime value "VehicleIndex"

    # Source step 0047: Get VehicleName | Module: Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-66ce-f229-3f388fad7489
    # Runtime control: Do [max=5] > Condition
    Then if the source runtime condition "Do [max=5] > Condition" is satisfied, "Existing Vehicle > Existing Vehicle VIN" should equal "1FDKE30G9JHA64433"

    # Source step 0048: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-4512-ad6b-818dda4f5dbb
    # Runtime control: Do [max=5] > Loop
    When if the source runtime condition "Do [max=5] > Loop" is satisfied, I retain hard-coded value "{Repetition}" as runtime value "VehicleIndex"

    # Source step 0049: Get VehicleName | Module: Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-8f98-cf4a-d1c7c9a1779b
    When I capture "InnerText" from "Existing Vehicle > Vehicle Name" as runtime value "VehicleName"

    # Source step 0050: Reset VehicleIndex | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary > Get VehicleName | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-15dd-7274-1d8376639aba
    When I retain hard-coded value "1" as runtime value "VehicleIndex"

    # Source step 0051: Click on Next | Module: Vehicle Summary
    # Section: Process > A | Initial Poilcy Creation > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-b758-d639-e048ecaceaf2
    When I click "Next"

    # Source step 0052: Change Name to TitleCase | Module: TBox Set Buffer
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-ca96-78a7-1e08bcae04df
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[LastName]}\"\"\"\")]}" as runtime value "LName"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[FirstName]}\"\"\"\")]}" as runtime value "FName"

    # Source step 0053: Driver Assignment | Module: Driver Assignment
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-4e24-aae3-077e09df74e5
    When I click "Current Driver Assignment > Vehicle"
    When I click "Current Driver Assignment > Principal"
    When I click "Next"

    # Source step 0054: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-b28e-701e-50a72c8731fe
    # Runtime control: Driver Assignment- UW Popup > Condition - check if popup appears
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - check if popup appears" is satisfied, "Lnk_CONTINUE" should be visible

    # Source step 0055: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > A | Initial Poilcy Creation > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-c4b9-86d5-dea772dfc3f7
    # Runtime control: Driver Assignment- UW Popup > Then - click on continue
    When if the source runtime condition "Driver Assignment- UW Popup > Then - click on continue" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0056: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > A | Initial Poilcy Creation > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-beca-4c3f-4592ab292112
    Then I wait until "Hdr_Edit Violation" is visible
    When I click "Btn_Next"

    # Source step 0057: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > A | Initial Poilcy Creation > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-c6a4-5195-f00e43c721e6
    Then I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_Next" is enabled
    When I click "Btn_Next"

    # Source step 0058: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-f263-1dcc-b18faed72459
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"

    # Source step 0059: Coverage | Module: Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-475e-9ae9-9c9c40e2946a
    Then "Vehicle Box > H2" should equal captured runtime value "VehicleName"
    When I click "Vehicle Box > 500"
    When I select "Vehicle Box > NoCoverage"
    When I click "Next"

    # Source step 0060: Wait for Page to Load | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-2d53-82fd-4b57f2332d15
    Then I wait until "Accidental Death & Dismemberment - No Coverage" is enabled

    # Source step 0061: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3c-c558-13c9-bbc118f0a89a
    # Runtime control: If Accidental Death & Dismemberment - No Coverage Is not Selected > Condition
    Then if the source runtime condition "If Accidental Death & Dismemberment - No Coverage Is not Selected > Condition" is satisfied, "Accidental Death & Dismemberment - No Coverage" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0062: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-bbdb-78b5-5840d8de865a
    # Runtime control: If Accidental Death & Dismemberment - No Coverage Is not Selected > Then
    When if the source runtime condition "If Accidental Death & Dismemberment - No Coverage Is not Selected > Then" is satisfied, I select "Accidental Death & Dismemberment - No Coverage"

    # Source step 0063: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-a78e-bb87-c9ff3cea81f5
    # Runtime control: If Loss of Income Coverage Is Not Selected > Condition
    Then if the source runtime condition "If Loss of Income Coverage Is Not Selected > Condition" is satisfied, "Loss Of Income Coverage" should have "ClassName" equal to "mat-focus-indicator btn-toggle-checkbox mat-raised-button mat-button-base ng-star-inserted"

    # Source step 0064: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-6056-5016-44fe35d2f283
    # Runtime control: If Loss of Income Coverage Is Not Selected > Then
    When if the source runtime condition "If Loss of Income Coverage Is Not Selected > Then" is satisfied, I click "Loss Of Income Coverage"

    # Source step 0065: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage > Select - Uninsured Motorist PD | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-6a6e-e844-6769c0a1155f
    # Runtime control: If Uninsured Motorist PD - No Coverage Is not Selected > Condition
    Then if the source runtime condition "If Uninsured Motorist PD - No Coverage Is not Selected > Condition" is satisfied, "Uninsured Motorist PD - No Coverage" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0066: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage > Select - Uninsured Motorist PD | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-70eb-a171-aa58588ee735
    # Runtime control: If Uninsured Motorist PD - No Coverage Is not Selected > Then
    When if the source runtime condition "If Uninsured Motorist PD - No Coverage Is not Selected > Then" is satisfied, I select "Uninsured Motorist PD - No Coverage"

    # Source step 0067: Additional Coverage | Module: Additional Coverage
    # Section: Process > A | Initial Poilcy Creation > 09 Coverages > Addtional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-9ade-ed85-9ad4784f2429
    When I click "Next"

    # Source step 0068: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > A | Initial Poilcy Creation > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-8312-c086-912522e321b6
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Btn_Next" exists

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 10 Pricing | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0070: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > A | Initial Poilcy Creation > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-67d7-c876-9c24a7771ed3
    Then I wait until "Btn_Next" exists
    When I click "Btn_Next"

    # Source step 0071: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > A | Initial Poilcy Creation > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-c12f-b22c-3c9b5dbdf9ea
    When I click "<unnamed value>"

    # Source step 0072: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process > A | Initial Poilcy Creation > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-319a-d851-f893d27b602b
    When I click "btn_Next"

    # Source step 0073: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0078: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-69d4-5758-597a6faec325
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0080: Submission-Review & Continue | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-d4f7-039f-596799c908ba
    # Runtime control: If Comments are Required > Condition
    Then if the source runtime condition "If Comments are Required > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0081: Submission-Review & Continue | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-e2aa-2d8b-3811c8542674
    # Runtime control: If Comments are Required > Then
    When if the source runtime condition "If Comments are Required > Then" is satisfied, I enter or select "Review Required" in "Txt_AgentComments"

    # Source step 0082: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-fb48-ea10-506864e423e8
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0083: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-096e-39b3-9f442f51fb00
    # Runtime control: If_eChecklist Sign on Page is Visible > Condition
    Then if the source runtime condition "If_eChecklist Sign on Page is Visible > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0084: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-a825-5318-f15abe032dc6
    # Runtime control: If_eChecklist Sign on Page is Visible > Then
    When if the source runtime condition "If_eChecklist Sign on Page is Visible > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0085: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-6bbd-754e-7f1ca253de21
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"

    # Source step 0086: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-200c-e96c-ab94f8cdcaf5
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0088: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-0580-0bf7-94c7c19502c2
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0089: eChecklist-Click the drag/drop link to upload the file in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-bdb6-a7a5-42be8a603e35
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0090: Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-e23b-d4cf-827d28d6bf2d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0091: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-ea11-00b4-b67ca0b11070
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0092: Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-76dc-c64f-58c9e596d239
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0093: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-0a28-9329-8207032f19a9
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0094: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-f96f-3856-c26b47ad9894
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0095: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a6ac-5210-1c0cb8a88b72
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I wait "2000" milliseconds

    # Source step 0097: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-e597-5619-47dc276f4f40
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0098: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-dbde-fcb0-d3f5d123559a
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0099: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > A | Initial Poilcy Creation > 14 Launch Checklist > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a25d-2718-6c70c2b9457b
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0100: Click on Transmit | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-f9ab-2d0e-c525ba6e3d4b
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0101: Verify EffectiveDate and Policy Premium and Number | Module: EQ||Submission
    # Section: Process > A | Initial Poilcy Creation > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-37b4-1b88-e05a19925fb4
    Then "Lbl_Value_Total Policy Premium" should equal the RUNTIME-DERIVED environment value from "${XB[Premium]}"
    Then "Lbl_Value_Effective Date" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"
    Then "Lbl_Value_Policy Number" should equal "{XB[Policy Number]}"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "ChecklistId"

    # Source step 0102: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
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

    # Source step 0103: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > A | Initial Poilcy Creation > 16 TDS Operations for Further Validations > 16 TDS Operations for Further Validations | Reusable flow: TDS | Home & Auto - Push Quote Data & Policy Information to TDS | Source XTestStep: 3a19dd55-d416-7ec3-3085-6c6774b8c897
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATETIME[][][MM/dd/yyyyhhmm]}"
    And I use TDM parameter "Data structure > State" with "IL"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0104: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > A | Initial Poilcy Creation > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0105: CloseBrowser | Module: CloseBrowser
    # Section: Process > A | Initial Poilcy Creation > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0118: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > B | 1st Change Transaction on Policy > 01 Policy History > Search Policy with Policy Number | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-0be1-7fe1-7206ba43b0fa
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "Policy Number" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0119: Policy History | Module: Policy History
    # Section: Process > B | 1st Change Transaction on Policy > 01 Policy History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-56c5-5368-0eeaa72ee338
    Then "List Of Changes Table > $1 > #1" should equal "New Business"
    Then "List Of Changes Table > $1 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $1 > #3" should equal captured runtime value "Premium"
    When I click "+ CREATE NEW POLICY CHANGE"

    # Source step 0120: Policy Change Form | Module: Policy Change Form
    # Section: Process > B | 1st Change Transaction on Policy > 02 Policy Change Form | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-4fbd-74cb-a5fd13bfb792
    When I click "New Effective Date"
    When I enter or select "\"^{a}\"" in "New Effective Date"
    When I enter captured runtime value "SecondEffectiveDate" in "New Effective Date"
    When I enter or select "Update Comp Covergar to $1000" in "Transaction Reason"
    Then I wait until "OK" is enabled
    When I click "OK"

    # Source step 0121: Navigate to Coverage | Module: EQ | Side Menu
    # Section: Process > B | 1st Change Transaction on Policy > 03 Increase Comp Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-300c-7127-e23ff625333d
    Then I wait until "Coverages" is enabled
    When I click "Coverages"

    # Source step 0122: Increase Coverage to $1000 | Module: Coverage
    # Section: Process > B | 1st Change Transaction on Policy > 03 Increase Comp Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-91ac-896b-85aaef4fd67d
    Then I wait until "Comp Cov - 1,000" is enabled
    When I click "Comp Cov - 1,000"
    When I click "Next"

    # Source step 0123: Navigate to Submission | Module: EQ | Side Menu
    # Section: Process > B | 1st Change Transaction on Policy > 04 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-2f80-df8c-58ba41e1e98d
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0124: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > B | 1st Change Transaction on Policy > 04 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-646f-7967-635f6f5bf0fa
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0125: TBox Wait | Module: TBox Wait
    # Section: Process > B | 1st Change Transaction on Policy > 04 Navigate to Submission and Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "10000" milliseconds

    # Source step 0126: Click on Transmit | Module: EQ||Submission
    # Section: Process > B | 1st Change Transaction on Policy > 04 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-ecf9-0dc1-9a9191d6cfad
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0127: Verify EffectiveDate and Policy Premium and Number | Module: Transmit Policy
    # Section: Process > B | 1st Change Transaction on Policy > 04 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-fe91-c7a4-4dbb9a9c44df
    Then "Total Policy Premium" should equal the RUNTIME-DERIVED environment value from "${XB[RevisedPremium]}"
    Then "Endorsement Effective Date" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[SecondEffectiveDate]}][][MM/dd/yyyy]}"
    Then "Policy Number" should equal the RUNTIME-DERIVED buffer expression "*{B[Policy Number]}*"

    # Source step 0128: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > B | 1st Change Transaction on Policy > 04 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-f059-ba4c-ab77ff251999
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0129: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > B | 1st Change Transaction on Policy > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0130: CloseBrowser | Module: CloseBrowser
    # Section: Process > B | 1st Change Transaction on Policy > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0143: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > C | 2nd Change Transaction Policy > 01 Policy History > Search Policy with Policy Number | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-0a86-9674-631a2f2c21ff
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "Policy Number" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0144: Policy History | Module: Policy History
    # Section: Process > C | 2nd Change Transaction Policy > 01 Policy History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-76b8-8310-e7c2232e5e6e
    Then "List Of Changes Table > $1 > #1" should equal "Endorse"
    Then "List Of Changes Table > $1 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[SecondEffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $2 > #1" should equal "New Business"
    Then "List Of Changes Table > $2 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"
    When I click "+ CREATE NEW POLICY CHANGE"

    # Source step 0145: Policy Change Form | Module: Policy Change Form
    # Section: Process > C | 2nd Change Transaction Policy > 02 Policy Change Form | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-790b-6714-475e548bdf8a
    When I click "New Effective Date"
    When I enter or select "\"^{a}\"" in "New Effective Date"
    When I enter captured runtime value "ThirdEffectiveDate" in "New Effective Date"
    When I enter or select "Adding Another Occasional Driver" in "Transaction Reason"
    Then I wait until "OK" is enabled
    When I click "OK"

    # Source step 0146: Click on Add Additional Driver | Module: EQ||Driver Information Next
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-3251-3afc-5aaf9951fa73
    When I click "Btn_Add Additional Driver"

    # Source step 0147: TestData - Find & provide item | Module: TestData - Find & provide item
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information > Get Client Data From TDS > TDS | Auto - Find Client From TDS with Sno | Reusable flow: TDS | Auto - Find Client From TDS with Sno | Source XTestStep: 3a19dd55-d425-eea1-cefb-4ed17a7516bf
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "IL_ClientData_Regression"
    And I use TDM parameter "Alias name (item)" with "IL_ClientData_Regression"
    And I use TDM parameter "Data search filter > Sno" with "1"

    # Source step 0148: Set Data-First Name, Last Name, DOB, SSN, State, & Sno | Module: TBox Set Buffer
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information > Get Client Data From TDS > TDS | Auto - Find Client From TDS with Sno | Reusable flow: TDS | Auto - Find Client From TDS with Sno | Source XTestStep: 3a19dd55-d425-2dc2-a2ce-9ce0eab71a9b
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

    # Source step 0149: Add Driver Details | Module: EQ||Additional Driver Information
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-e85f-a87a-b28c216d30d3
    When I enter captured runtime value "FirstName" in "Txt_FirstName"
    When I enter captured runtime value "LastName" in "Txt_LastName"
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I click "Btn_Male"
    When I click "Btn_Single"

    # Source step 0150: Select Relationship to Account Owner | Module: Driver Information
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-194e-829c-0ee8c17d7523
    When I select "Relationship to Account Owner - More Options"
    Then I wait until "Brother" is visible
    When I click "Brother"

    # Source step 0151: Add Driver Details | Module: EQ||Additional Driver Information
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information > Add Additional Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-d781-5b69-2f26539081eb
    When I click "Txt_SSN"
    When I enter or select "\"^{a}\"" in "Txt_SSN"
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I press "Enter" while focused on "Txt_SSN"
    Then I wait until "Btn_Not a Named Insured" is visible
    When I select "Btn_Not a Named Insured"
    When I click "Btn_Assigned"
    When I enter captured runtime value "DLNumber" in "Txt_License Numberrr"
    Then I wait until "Txt_Years Licensed in Current State" is visible
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "8" in "Txt_Years Licensed in Current State"
    When I enter the RUNTIME-DERIVED buffer expression "{Sendkeys[{DATE[{B[DOB]}][+20y][MM/dd/yyyy]}]}" in "Txt_Date Licensed"
    When I select "Btn_No_Prior Insurance"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0152: Click on Next | Module: EQ||Driver Information Next
    # Section: Process > C | 2nd Change Transaction Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-5dc9-df6f-b8963f549649
    Then I wait until "Btn_Next" is enabled
    When I click "Btn_Next"

    # Source step 0153: Navigate to Driver Assignment | Module: EQ | Side Menu
    # Section: Process > C | 2nd Change Transaction Policy > 05 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-1d55-ba13-c5e0bfaac7f3
    Then I wait until "Driver Assignment" is enabled
    When I click "Driver Assignment"

    # Source step 0154: Change Name to TitleCase | Module: TBox Set Buffer
    # Section: Process > C | 2nd Change Transaction Policy > 05 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-810b-03f9-9ed827a51757
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[LastName]}\"\"\"\")]}" as runtime value "LName"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{CALC[proper(\"\"\"\"{B[FirstName]}\"\"\"\")]}" as runtime value "FName"

    # Source step 0155: Driver Assignment | Module: Driver Assignment
    # Section: Process > C | 2nd Change Transaction Policy > 05 Driver Assignment > Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d3d-d96d-1562-e0e96f6eadb0
    When I click "Current Driver Assignment > Vehicle"
    When I click "Current Driver Assignment > Occasional"
    When I click "Next"

    # Source step 0156: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > C | 2nd Change Transaction Policy > 05 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4b-ed85-3414-016f21d4a50e
    # Runtime control: Driver Assignment- UW Popup > Condition - check if popup appears
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - check if popup appears" is satisfied, "Lnk_CONTINUE" should be visible

    # Source step 0157: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > C | 2nd Change Transaction Policy > 05 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4b-5481-dad8-ead503caf982
    # Runtime control: Driver Assignment- UW Popup > Then - click on continue
    When if the source runtime condition "Driver Assignment- UW Popup > Then - click on continue" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0158: Navigate to Navigate to Submission | Module: EQ | Side Menu
    # Section: Process > C | 2nd Change Transaction Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4b-ad08-0b71-8c2963e733c8
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0159: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > C | 2nd Change Transaction Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4b-eb27-d124-8e63e8e97e93
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0160: TBox Wait | Module: TBox Wait
    # Section: Process > C | 2nd Change Transaction Policy > 06 Navigate to Submission and Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "10000" milliseconds

    # Source step 0161: Click on Transmit | Module: EQ||Submission
    # Section: Process > C | 2nd Change Transaction Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4c-094f-0d00-e1843a8970e3
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0162: Verify EffectiveDate and Policy Premium and Number | Module: Transmit Policy
    # Section: Process > C | 2nd Change Transaction Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4c-cbb3-60a2-cb4b3f709117
    Then "Total Policy Premium" should equal the RUNTIME-DERIVED environment value from "${XB[LatestPremium]}"
    Then "Endorsement Effective Date" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[ThirdEffectiveDate]}][][MM/dd/yyyy]}"
    Then "Policy Number" should equal the RUNTIME-DERIVED buffer expression "*{B[Policy Number]}*"

    # Source step 0163: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > C | 2nd Change Transaction Policy > 06 Navigate to Submission and Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4d-5a6b-ed9f-26f33c47f7ba
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0164: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Postcondition > Validate in ExpertQuote > Validate Transactions in ExpertQuote > Search Policy with Policy Number | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4d-0db7-0f0b-855ca5212164
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "Policy Number" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0165: Policy History | Module: Policy History
    # Section: Postcondition > Validate in ExpertQuote > Validate Transactions in ExpertQuote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4d-615b-8eff-e93e9d1cfec3
    Then "List Of Changes Table > $1 > #1" should equal "Endorse"
    Then "List Of Changes Table > $1 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[SecondEffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $2 > #1" should equal "Endorse"
    Then "List Of Changes Table > $2 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[ThirdEffectiveDate]}][][MM/dd/yyyy]}"
    Then "List Of Changes Table > $3 > #1" should equal "New Business"
    Then "List Of Changes Table > $3 > #2" should equal the RUNTIME-DERIVED buffer expression "{DATE[{B[EffectiveDate]}][][MM/dd/yyyy]}"

    # Source step 0166: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition > Validate in ExpertQuote > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0167: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition > Validate in ExpertQuote > Logout from EQ and Close Browser | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0168: Force Close Edge | Module: TBox Start Program
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: Common | 00 Force Close Edge Browser | Source XTestStep: 3a19dd55-d3cb-4c12-291b-70baf4eb5889
    And I force-close browser/process "msedge.exe" using command "taskkill /im msedge.exe /f"

    # Source step 0169: Open Edge Preferences file | Module: Open/Create JSON file
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-54de-e510-208fe48a30ee
    And I open or create JSON resource "EdgePreferences" at "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0170: Change Exit Type | Module: Edge Preferences File
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-f7e3-bf94-cfe222ebeeac
    When I set Microsoft Edge preference "RootObject > profile > exit_type" to "none"

    # Source step 0171: Save changes | Module: Save JSON Resource
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-93a3-afa2-8a5a039508f8
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0172: Delete EdgePreferences Resource | Module: TBox Delete Resource
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI > Reset Exit_Type (Restore last session popup) | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-d78a-726d-297646009ab1
    When I remove runtime resource "EdgePreferences"

    # Source step 0173: Delete Cookies File | Module: TBox Delete File
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: Common | 00 Reset Edge Preferences | Source XTestStep: 3a19dd55-d3da-b4d8-790f-d042719f63ea
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"

    # Source step 0174: TBox Wait | Module: TBox Wait
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: Common | 00 Reset Edge Preferences > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0175: OpenUrl | Module: OpenUrl
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0179: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4d-b37a-00ca-405d99138e33
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0180: Provide Express UI Login credentials | Module: EU||Login
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate and Login to ExpressUI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-e8b4-899a-a9f25e1dd74d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0181: Search Policy in Express | Module: EU||Home
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-1929-835b-aa04b425ae75
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0182: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-60ed-134c-8b7052a2a074
    When I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0183: Get TotalTransacations | Module: EU||Transact
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate TotalTransactions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-321b-83d8-3954ba559002
    When I capture "ResultCount" from "Transaction Table Row Un-Identified for Count" as runtime value "TotalTransaction"

    # Source step 0184: Validate TotalTransaction | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate TotalTransactions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-1b3d-dff4-62c11af667ad
    When I retain hard-coded value "3" as runtime value "TotalTransaction"

    # Source step 0185: Total Transacations | Module: EU||Transact
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Find Last Transaction with ThirdEffectiveDate | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-3635-0e6e-9d64221e9520
    # Runtime control: Do [max={B[TotalTransaction]}] > Condition
    Then if the source runtime condition "Do [max={B[TotalTransaction]}] > Condition" is satisfied, "Transaction Table Row Identified for Validation > Effective Date" should equal the RUNTIME-DERIVED buffer expression "*{B[ThirdEffectiveDate]}*"

    # Source step 0186: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Find Last Transaction with ThirdEffectiveDate | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-8d0d-d6ef-9fd0fd6759b8
    # Runtime control: Do [max={B[TotalTransaction]}] > Loop
    When if the source runtime condition "Do [max={B[TotalTransaction]}] > Loop" is satisfied, I retain hard-coded value "{Repetition}" as runtime value "TransactionRow"

    # Source step 0187: Total Transacations | Module: EU||Transact
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Find Last Transaction with ThirdEffectiveDate | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-e28b-34ac-947a85ade85f
    When I click "Transaction Table Row Identified for Validation > Btn_ViewPolicy"

    # Source step 0188: Navigate to Drivers | Module: Express  | Policy View
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Drivers | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-4f4a-7ffa-950131d347e7
    When I enter or select "Driver(s)" in "Policy View Tab"

    # Source step 0189: Get TotatlDrivers | Module: Express | Drivers
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Drivers | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-f5da-48ba-bddeb34f7df6
    When I capture "ResultCount" from "Driver Table Row Un-Identified for Count" as runtime value "TotalDrivers"

    # Source step 0190: Validate TotalDrivers | Module: TBox Set Buffer
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Drivers | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-cba9-497d-6324cfd2a426
    When I perform the source-defined buffer operation "Validate TotalDrivers"

    # Source step 0191: Navigate to Coverages | Module: Express  | Policy View
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-1129-66bd-0f0fabcb5798
    When I enter or select "Coverages" in "Policy View Tab"

    # Source step 0192: Express | Coverages | Module: Express | Coverages
    # Section: Postcondition > Validate in ExpressUI > Validate Transaction in ExpressUI > Validate Last Transaction > Validate Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-2c33-aee5-27c775f8ccb8
    Then I wait until "Vehicle Name Header > expand" is enabled
    When I click "Vehicle Name Header > expand"
    Then I wait until "Comprehensive Deduction" is enabled
    Then "Comprehensive Deduction" should equal "$500"

    # Source step 0193: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition > Validate in ExpressUI > Express | Close Browser -TransACT Page | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d4e-6eb8-a34a-a1f63dcf3bca
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0074 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 2. Source step 0075 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 3. Source step 0076 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 4. Source step 0077 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 5. Source step 0085 field "Drag and Drop files here to upload (or click here to open a file explorer)" in "eChecklist-Click the documents/links in the checklist" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 6. Source step 0176 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 7. Source step 0177 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 8. Source step 0178 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
