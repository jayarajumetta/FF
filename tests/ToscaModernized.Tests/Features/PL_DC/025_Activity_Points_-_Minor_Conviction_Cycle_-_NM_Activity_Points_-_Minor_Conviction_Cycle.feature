# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 025_Activity_Points_-_Minor_Conviction_Cycle_-_NM_Activity_Points_-_Minor_Conviction_Cycle.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @Edge @manual @archive @automated
Feature: Execute Activity Points - Minor Conviction (Cycle) - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Minor Conviction (Cycle) - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Minor Conviction (Cycle) - NM using representative iteration Activity Points - Minor Conviction (Cycle) - NM
    # Source step 0076: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eb9-d7d7-2dff-8617e8493fea
    Given "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YD2102" in "Txt_Username"
    Then "Lbl_Password" should equal "Password"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    When I click "Btn_Sign On"

    # Source step 0077: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eb9-0491-24a5-8fe95dc8fd26
    Then I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0080: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eb9-d61b-782c-bbbf415b6850
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter captured runtime value "FirstName" in "Txt_First"
    When I enter captured runtime value "LastName" in "Txt_Last"
    When I leave "Txt_Date of birth" blank
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I click "Btn_Create New Client"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0081: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0082: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-6727-3dee-6b150531a4d7
    Then I wait until "Lbl_Account Information" is visible
    Then I wait until "Txt_First Name_Account Owner" is visible
    Then I wait until "Txt_Middle Name_Account Owner" is visible
    Then I wait until "Txt_Last Name_Account Owner" is visible
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I enter or select "9072290061" in "Txt_Best phone_Account Owner"
    When I enter or select "STEPHENOSTENDORF1120@GMAIL.COM" in "Txt_Email_Account Owner"
    Then I wait until "Lbl_Marital Status:" is visible
    When I click "Btn_Single"
    When I enter captured runtime value "StreetAddress" in "Txt_Enter a location"
    When I enter captured runtime value "StreetAddress" in "Txt_owner.address.city_New"
    When I enter or select "NEW MEXICO" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" is visible
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0083: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0084: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-9691-3428-959768722640
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW MEXICO]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"

    # Source step 0085: Verify that Invalid Address Pop up is shown | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-73fe-1b25-23a10fd1f9dd
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0086: Click Proceed | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-22ae-3436-14972e412527
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0087: If SSN Pop up Appears | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-d593-c259-8937f68fb85a
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0088: Click Confirm | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-0de7-abb0-56c4ecf61399
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0089: Enter SSN  | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2eca-01df-a1b4-7361c41d6cd2
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue" is satisfied, I enter the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0090: Verify Existing Account / New Account pop up shows | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-d6f4-686e-856517f5121e
    # Runtime control: Proposal Start-UW Popup -Use Existing Account / New Account > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-UW Popup -Use Existing Account / New Account > Condition - If Popup appears" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0091: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-eea4-c12d-5ee0df6ac941
    # Runtime control: Proposal Start-UW Popup -Use Existing Account / New Account > Then - Click Use existing account 
    When if the source runtime condition "Proposal Start-UW Popup -Use Existing Account / New Account > Then - Click Use existing account" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0093: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-3ea6-c4ed-7c634b4f8fae
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0094: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-5698-50e4-1d8e92755b89
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0095: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-be9f-733e-152f713fe67c
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0096: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-a08d-70b0-dc91255d208b
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0097: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-7840-f085-9aaaf64b9e81
    # Runtime control: If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected" is satisfied, "Prior Insurance_Checked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0098: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ecd-0518-9d62-073b18fe39d6
    # Runtime control: If - Checking Prior Insurance button selected or not > Then - Continue with Driver Summary Information 
    When if the source runtime condition "If - Checking Prior Insurance button selected or not > Then - Continue with Driver Summary Information" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[14]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    Then I wait until "Btn_priorCarrierName" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorCarrierName"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Geico]}" in "Btn_priorCarrierName"
    Then I wait until "Btn_priorPolicyNumber" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorPolicyNumber"
    When I enter or select "{Invoke[Click]}{SENDKEYS[730927358002]}" in "Btn_priorPolicyNumber"
    Then I wait until "Btn_yearsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_yearsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[1]}" in "Btn_yearsWithPriorCarrier"
    Then I wait until "Btn_monthsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_monthsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[0]}" in "Btn_monthsWithPriorCarrier"
    When I click "Btn_Save and Continue"

    # Source step 0099: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed0-313e-a414-84d1a210688f
    # Runtime control: If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary  > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected" is satisfied, "Prior Insurance_Unchecked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0100: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed0-da72-703b-acf36b826988
    # Runtime control: If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary  > If - Prior Insurance is not Selected > Then - select yes and continue with Driver summary Information
    When if the source runtime condition "If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary > If - Prior Insurance is not Selected > Then - select yes and continue with Driver summary Information" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[14]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_Yes"
    Then I wait until "Btn_priorCarrierName" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorCarrierName"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Geico]}" in "Btn_priorCarrierName"
    Then I wait until "Btn_priorPolicyNumber" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorPolicyNumber"
    When I enter or select "{Invoke[Click]}{SENDKEYS[730927358002]}" in "Btn_priorPolicyNumber"
    Then I wait until "Btn_yearsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_yearsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[1]}" in "Btn_yearsWithPriorCarrier"
    Then I wait until "Btn_monthsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_monthsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[0]}" in "Btn_monthsWithPriorCarrier"
    When I click "Btn_Save and Continue"

    # Source step 0101: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed0-282e-7e63-b357f64767ea
    When I click "Btn_Next"

    # Source step 0102: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed0-d008-6e24-aada852e8d9c
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0103: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed0-535e-83d9-6fef17d9e36e
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0104: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed0-be13-8e5c-a61071ec6eb0
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "1HD1KRM19EB602640" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    When I click "Btn_Pleasure Use"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    When I select "Btn_Cycle_Customizatioin_No"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0105: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-b965-9cbd-d8f1a3b6be4b
    When I click "Btn_2014 Harley Davidson FLHXS_V1"
    Then I wait until "Btn_Principal_1" exists
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0106: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-b1eb-9be7-551288da5961
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0107: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-b3fb-9485-f0d7bd6303a1
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0109: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-e935-0376-e6d2a996593a
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Edit Violation" should be visible

    # Source step 0110: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-6115-ffbd-a0d9f4d23a31
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD VIOLATION"

    # Source step 0111: ExpertQuote|Violations | Module: EQ|Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-1e9c-e300-b4390d4d9964
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I enter or select "10/10/2003" in "Violation/Susp Dat"
    Then "Driver Involved" should be visible
    When I click "Courtney Allison"
    When I enter or select "{invoke[Click]}{sendkeys[EL - Driving with Expired License]}" in "DIV_1"
    When I enter or select "10/10/2022" in "Conviction Date"
    When I click "Applies"
    When I click "Save and Continue"

    # Source step 0112: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-a133-98da-8dc4158fb416
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0113: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-078f-e488-dbed3793b619
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0114: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed3-4dfd-c315-862d5c34adc6
    When I select "Btn_SafeCycle_Yes_D1"
    When I enter or select "10/10/2000" in "Txt_safeCycleDiscountDate_D1"
    When I click "Btn_Next"

    # Source step 0115: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0116: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-24d6-8843-a73c544b051f
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0117: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-ec21-4000-60f74ecd4851
    When I select "Btn_UMPD_No Coverage_V1"
    When I click "Btn_Next"

    # Source step 0118: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-1efe-0f14-dae781592b5b
    When I wait "10000" milliseconds

    # Source step 0119: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-c7c0-a5fc-0383dd93e2b9
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0120: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-2738-0a4e-5e76d49d8078
    When I click "<unnamed value>"

    # Source step 0121: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0122: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-e95c-e2ca-32ab4c277d57
    When I click "btn_Next"

    # Source step 0123: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Cycle Policy > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0128: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0129: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0130: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0134: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0135: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0136: Search Policy Number | Module: EU||Home
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0137: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"
    When I enter the unresolved source parameter "PersonalAuto" (not supplied by this reusable-block invocation) in "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0138: Click on Pricing | Module: EU||Applicant
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0139: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0140: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0141: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0142: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0143: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0144: Click on Home button | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0145: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0146: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0147: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0148: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0149: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0150: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0151: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0152: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0153: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0154: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0155: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0156: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-0bd4-05a3-eb00c2bab090
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0157: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-6190-adb9-35ae62535163
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0158: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-2678-a974-539f75243952
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0159: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-c378-eb20-cc081f16bd7d
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0160: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-c0a8-dd1e-b8006d930b33
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0161: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-1734-85b4-8ecf5601b858
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0162: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-a2ee-c16f-e0e1586edbf0
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0163: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-a5dd-b79c-b4208c317a1d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0164: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-2608-2d4e-c31a000a0e85
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0165: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-8e1b-ef1c-177d1e698dcf
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0166: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-9376-f8b1-1dfcccadd0c1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0167: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed6-ad7f-754d-c862aaa45633
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0168: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed9-779a-1115-471efe877a2b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0169: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed9-0042-7fd2-6d3b97e7cef0
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0170: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0174: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed9-261d-e5c1-b60ed295c7c1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0175: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ed9-d01d-1d5f-33c0c505b2e1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0176: EU||Home | Module: EU||Home
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edc-f70e-75a3-e4f865a1adb5
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0177: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ede-c4b6-42ce-0d7e586521a7
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"

    # Source step 0178: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ede-3697-2013-74073fa85ef6
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0179: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-f6c2-64f2-a40de83e5d99
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0180: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-85ef-c075-7d6d49db84fc
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0181: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-5475-6fba-6be475f182f1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0182: EU||Applicant | Module: EU||Applicant
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-178b-1ddd-70236e91c915
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0183: EU||Pricing | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-8c35-a759-d85d36914a47
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0184: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-69b6-f858-7b3375735bca
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0185: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-ba27-1c76-58f596888c26
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0186: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-c278-20a9-a8343707fe9b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0187: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-8fbd-89f0-ff8a38d5774b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0188: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-d961-b3dd-c80c62f63455
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0190: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2edf-8f2e-8915-5dc721a4476a
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0192: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-ea17-460a-bc67f3eafe97
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YD2102" in "Txt_Username"
    Then "Lbl_Password" should equal "Password"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    When I click "Btn_Sign On"

    # Source step 0193: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-9a91-c9ad-6ec83870cb7a
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0194: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-bd16-9bd4-057599dbc8b0
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0195: TBox Save As | Module: TBox Save As
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-fbe8-d0ac-636a108c71f7
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0196: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-8e13-4747-24ea10511723
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0197: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Cycle Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-4a56-4075-8d518c8fc585
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0199: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0200: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-f67a-cde7-f664ed39e811
    When I close the active browser

    # Source step 0201: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-b249-62b4-3cc73c605b1a
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0202: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0203: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-0f9e-f8c5-6bf62b09e06c
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number_Activity Points - Minor Conviction (Cycle)_NM"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0204: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-b536-77f3-bd42e955f3c1
    When I click "Btn_Save and Exit"

    # Source step 0205: OpenUrl | Module: OpenUrl
    # Section: Process > Activity Points Minor | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0209: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-85ef-9018-2cedd8a5d75b
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0210: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-7e5c-f575-0ebf504abe25
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0211: Search  Policy Number | Module: EU||Home
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-0dfd-df80-968501965edf
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number_Activity Points - Minor Conviction (Cycle)_NM" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0212: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-6812-159e-91dd706c59ef
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_Motorcycle" is visible
    When I click "Lnk_Motorcycle"

    # Source step 0213: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-7073-6eea-4dded33492c5
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0214: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-34cf-f4e7-d46b7bf832e6
    # Runtime control: If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0215: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-16d8-9511-3f7c69b6c30d
    # Runtime control: If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0216: EU||Applicant | Module: EU||Applicant
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-e892-7486-5652b13d32b7
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0217: EU||Pricing | Module: EU||Pricing
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-0acf-bda6-79f0a10fbbed
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0218: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-5fbd-c08e-b8672aea2465
    When I close the active browser

    # Source step 0223: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-69ba-7efb-3e7de6a3011e
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0224: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-b950-4289-d6e5eb886d28
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0227: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Cycle" as runtime value "LOB"
    When I retain hard-coded value "NM" as runtime value "State"

    # Source step 0237: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0238: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0239:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0240: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ee3-64b9-53f7-1f1ec7e1f2a4
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0004 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0005 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0006 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0008 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 5. Source step 0011 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YD2102"
#    - VERIFY "Lbl_Password" with "Password"
#    - INPUT "Txt_Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_FORGOT LOGIN ID?" with "True"
#    - VERIFY "Lnk_FORGOT PASSWORD?" with "True"
#    - INPUT "Btn_Sign On" with "X"
# 6. Source step 0012 "Click on New Quote button" in module "EQ||New Quote" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Btn_New Quote" with "True"
#    - VERIFY "Btn_New Quote" with "New Quote"
#    - INPUT "Btn_New Quote" with "X"
# 7. Source step 0013 "Client Selection-Enter Client Info of New or Existing Clients" in module "EQ || Client Selection" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Lbl_Client Info" with "True"
#    - VERIFY "Lbl_Client Info" with "Client Info"
#    - VERIFY "Lbl_New/Existing Client Search" with "True"
#    - VERIFY "Lbl_New/Existing Client Search" with "New/Existing Client Search"
#    - INPUT "Txt_First" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.FirstName"
#    - INPUT "Txt_Last" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.LastName"
#    - INPUT "Txt_Date of birth" with a blank value
#    - INPUT "Txt_Best phone" with a blank value
#    - INPUT "Txt_Email address" with a blank value
#    - VERIFY "Btn_Search" with "True"
#    - INPUT "Btn_Search" with "X"
#    - VERIFY "Btn_Create New Client" with "Create New Client"
#    - INPUT "Btn_Create New Client" with "X"
#    - VERIFY "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 8. Source step 0014 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 18.04.24 11:17:58 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with "10/2/1946"
#    - INPUT "Txt_Best phone_Account Owner" with "9072095371"
#    - INPUT "Txt_Email_Account Owner" with "GLADYSROBERTSON0616@GMAIL.COM"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Married" with "X"
#    - INPUT "Txt_Enter a location" with "S 5TH ST"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with "RATON"
#    - INPUT "Drpdwn_State" with "NEW MEXICO"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with "884150000"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 9. Source step 0015 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.DOB"
#    - INPUT "Txt_Best phone_Account Owner" with "9072003463"
#    - INPUT "Txt_Email_Account Owner" with "BEVERLYCRAGUN0104@AOL.COM"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with a blank value
#    - INPUT "Btn_Married" with "X"
#    - INPUT "Txt_Enter a location" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.Street_Address"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.City"
#    - INPUT "Drpdwn_State" with "NEW MEXICO"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.Zip"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 10. Source step 0016 "EQ||Proposal Start" in module "(Old) EQ||Proposal Start" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Lbl_Proposal Details" with "True"
#    - INPUT "Btn_Motorcycle" with "X"
#    - INPUT "Btn_Recreational Vehicle" with "X"
#    - INPUT "Txt_Effective Date" with the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE[][-1d][MM/dd/yyyy]}]}"
#    - INPUT "Drp List_Proposal Rating State" with "{Invoke[Click]}{SENDKEYS[NEW MEXICO]}"
#    - CONTAINER "Hdr_proposal.ratingState-panel" with "New Mexico"
#    - INPUT "Txt_Agent PCCode" with "D2102"
#    - WAIT "Lbl_Select Risk Address" with "True"
#    - INPUT "Rd Btn_Same as NewAccountAddress" with "{Invoke[Click]}"
#    - INPUT "Drp List_State" with "X"
#    - INPUT "Lbl_NEW MEXICO" with "X"
#    - INPUT "Btn_Start Quote" with "X"
#    - INPUT "Btn_PROCEED" with "X"
# 11. Source step 0017 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "15000"
# 12. Source step 0018 "EQ||Proposal Start" in module "(Old) EQ||Proposal Start" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Btn_PROCEED" with "True"
# 13. Source step 0019 "EQ||Proposal Start" in module "(Old) EQ||Proposal Start" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_PROCEED" with "X"
# 14. Source step 0020 "ExpertQuote" in module "Confirm the Client's SSN# Popup-Edit/Confirm" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "DIV_Confirm the Client's SSN#" with "True"
# 15. Source step 0021 "ExpertQuote" in module "Confirm the Client's SSN# Popup-Edit/Confirm" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Lnk_CONFIRM" with "X"
# 16. Source step 0022 "EQ||Proposal Start Proceed & SSN" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Txt_SSN" with "666341778"
#    - INPUT "Lnk_SUBMIT" with "X"
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 17. Source step 0023 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Lnk_USE EXISTING ACCOUNT" with "True"
#    - VERIFY "Lnk_USE EXISTING ACCOUNT" with "True"
# 18. Source step 0024 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 19. Source step 0025 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 20. Source step 0026 "Enter PreQualification" in module "EQ||PreQualification" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_Chk box_check_boxNone Of The Above" with "X"
#    - INPUT "Btn_Next" with "X"
# 21. Source step 0027 "Enter Driver Information" in module "EQ||Driver Information" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_(Existing Client)" with "X"
#    - INPUT "Btn_(Existing Client)*" with "X"
#    - INPUT "Btn_Next" with "X"
# 22. Source step 0028 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Btn_PriorInsurance_Yes" with "True"
# 23. Source step 0029 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "{Click}{Sendkeys[19]}"
#    - INPUT "Txt_Years Licensed in Current State" with ""
#    - INPUT "Txt_Months Licensed in Current State" with "1"
#    - INPUT "Txt_Date License" with "1/1/2015"
#    - INPUT "Btn_FinancialResponsibility_No" with "X"
#    - INPUT "Btn_PriorInsurance_No" with "X"
#    - WAIT "Btn_priorCarrierName" with "True"
#    - INPUT "Btn_priorCarrierName" with "\"^{a}\""
#    - INPUT "Btn_priorCarrierName" with "{Invoke[Click]}{SENDKEYS[Geico]}"
#    - WAIT "Btn_priorPolicyNumber" with "True"
#    - INPUT "Btn_priorPolicyNumber" with "\"^{a}\""
#    - INPUT "Btn_priorPolicyNumber" with "{Invoke[Click]}{SENDKEYS[5127398001]}"
#    - WAIT "Btn_yearsWithPriorCarrier" with "True"
#    - INPUT "Btn_yearsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_yearsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[2]}"
#    - WAIT "Btn_monthsWithPriorCarrier" with "True"
#    - INPUT "Btn_monthsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_monthsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[0]}"
#    - INPUT "Btn_Did Not Have Insurance" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 24. Source step 0030 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "{Click}{Sendkeys[19]}"
#    - INPUT "Txt_Years Licensed in Current State" with ""
#    - INPUT "Txt_Months Licensed in Current State" with "1"
#    - INPUT "Txt_Date License" with "1/1/2015"
#    - INPUT "Btn_FinancialResponsibility_No" with "X"
#    - INPUT "Btn_PriorInsurance_Yes" with "X"
#    - INPUT "Btn_PriorInsurance_No" with "X"
#    - WAIT "Btn_priorCarrierName" with "True"
#    - INPUT "Btn_priorCarrierName" with "\"^{a}\""
#    - INPUT "Btn_priorCarrierName" with "{Invoke[Click]}{SENDKEYS[Geico]}"
#    - WAIT "Btn_priorPolicyNumber" with "True"
#    - INPUT "Btn_priorPolicyNumber" with "\"^{a}\""
#    - INPUT "Btn_priorPolicyNumber" with "{Invoke[Click]}{SENDKEYS[5127398001]}"
#    - WAIT "Btn_yearsWithPriorCarrier" with "True"
#    - INPUT "Btn_yearsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_yearsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[2]}"
#    - WAIT "Btn_monthsWithPriorCarrier" with "True"
#    - INPUT "Btn_monthsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_monthsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[0]}"
#    - INPUT "Btn_Did Not Have Insurance" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 25. Source step 0031 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "40000"
# 26. Source step 0032 "EQ||Driver Information Next" in module "EQ||Driver Information Next" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_Add Additional Driver" with "X"
#    - INPUT "Btn_Next" with "X"
# 27. Source step 0033 "EQ||Vehicle Information" in module "EQ||Vehicle Information" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "btn_select vehicle1" with "True"
#    - VERIFY "btn_select vehicle1" with "True"
#    - WAIT "Btn_Vehicle" with "True"
#    - VERIFY "Btn_Vehicle" with "True"
# 28. Source step 0034 "EQ||Vehicle Information" in module "EQ||Vehicle Information" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "btn_select vehicle1" with "X"
#    - INPUT "Btn_Vehicle" with "X"
#    - INPUT "Btn_Next" with "X"
# 29. Source step 0035 "Vehicle Summary_New_Rescan" in module "EQ||Vehicle Summary" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Txt_VIN number" with "True"
#    - INPUT "Txt_VIN number" with "\"^{a}\""
#    - INPUT "Txt_VIN number" with "{Invoke[Click]}"
#    - INPUT "Txt_VIN number" with "1HD1KRM19EB602640"
#    - INPUT "Txt_VIN number" with ""
#    - WAIT "Lbl_Please select the vehicle" with "True"
#    - INPUT "Btn_SelectVehicle_1" with "X"
#    - INPUT "Btn_SelectVehicle_Option1" with "X"
#    - INPUT "Btn_Automobile" with "X"
#    - INPUT "Btn_Pleasure Use" with "X"
#    - INPUT "Btn_Trailbike" with "{Invoke[Click]}"
#    - WAIT "Btn_Own" with "True"
#    - INPUT "Btn_Own" with "X"
#    - INPUT "Btn_Is this vehicle used for racing?_No" with "X"
#    - INPUT "Btn_Pleasure" with "X"
#    - INPUT "Btn_Cycle_Customizatioin_No" with "X"
#    - INPUT "Btn_No_non-factory additions, alterations, or modifications" with "{Invoke[Click]}"
#    - INPUT "Btn_Is this vehicle licensed for road use?_No" with "X"
#    - WAIT "Lbl_Does this vehicle have any customized equipment?" with "True"
#    - INPUT "Btn_Does this Vehicle" with "No"
#    - WAIT "Btn_Pleasure/Work Use" with "True"
#    - INPUT "Btn_Pleasure/Work Use" with "{Click}"
#    - WAIT "Txt_PurchaseDate" with "True"
#    - INPUT "Txt_PurchaseDate" with "07/10/2003"
#    - INPUT "Txt_Odometer" with "\"^{a}\""
#    - WAIT "Txt_Odometer" with "True"
#    - INPUT "Txt_Odometer" with "{Click}"
#    - INPUT "Txt_Odometer" with "120000"
#    - INPUT "Txt_Odometer" with a blank value
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Btn_Next" with "X"
#    - INPUT "Btn_Add Additional Vehicle" with "X"
# 30. Source step 0036 "Enter Driver Assignment" in module "EQ||Driver Assignment" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_VehSelect" with "X"
#    - INPUT "Btn_2014 Harley Davidson FLHXS_V1" with "{Invoke[Click]}"
#    - INPUT "Btn_1988 Ford E350" with "{Invoke[Click]}"
#    - INPUT "Btn_Principal_2" with "{Invoke[Click]}"
#    - INPUT "Btn_Principal_1" with "{Invoke[Click]}"
#    - INPUT "Btn_1988 Ford E351" with "{Invoke[Click]}"
#    - WAIT "Btn_Principal_4" with "True"
#    - INPUT "Btn_Principal_4" with "X"
#    - WAIT "Btn_Occasional_3" with "True"
#    - INPUT "Btn_Occasional_3" with "X"
#    - INPUT "Btn_Vehicle_Select" with "X"
#    - WAIT "Lbl_Principal or Occasional driver of this vehicle?" with "True"
#    - INPUT "Btn_Principal" with "{Click}"
#    - INPUT "Btn_Principal_New" with "X"
#    - INPUT "Btn_Occasional" with "X"
#    - INPUT "Btn_Next" with "X"
#    - INPUT "Lnk_CONTINUE_1" with "x"
# 31. Source step 0037 "Driver Assignment-Select Driver Assignment & Continue" in module "EQ||Driver Assignment" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Lnk_CONTINUE" with "True"
#    - VERIFY "Lnk_CONTINUE" with "True"
# 32. Source step 0038 "Driver Assignment-Select Driver Assignment & Continue" in module "EQ||Driver Assignment" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Lnk_CONTINUE" with "X"
# 33. Source step 0039 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "10000"
# 34. Source step 0040 "EQ||Claims\\Violations" in module "EQ||Claims\\Violations" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Hdr_Edit Violation" with "True"
#    - VERIFY "Hdr_Claims" with "True"
# 35. Source step 0041 "EQ||Claims\\Violations" in module "EQ||Claims\\Violations" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_+ ADD CLAIM" with "X"
#    - INPUT "Btn_+ ADD VIOLATION" with "X"
# 36. Source step 0042 "ExpertQuote|Violations" in module "EQ|Violations" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Violation/Susp Dat" with "10/10/2003"
#    - VERIFY "Driver Involved" with "True"
#    - INPUT "Courtney Allison" with "X"
#    - INPUT "DIV_1" with "{invoke[Click]}{sendkeys[IV - Improper Backing or Start From Parked Position]}"
#    - INPUT "Applies" with "X"
#    - INPUT "Save and Continue" with "X"
# 37. Source step 0043 "Claims\\Violations-Review Claims & Violations and Continue" in module "EQ||Claims\\Violations" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_Next" with "X"
# 38. Source step 0044 "EQ||Claims\\Violations" in module "EQ||Claims\\Violations" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_Next" with "X"
# 39. Source step 0045 "EQ||Discounts_New" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_D1_No" with "X"
#    - INPUT "Hdr_Discounts page" with "{Click}"
#    - INPUT "Btn_Next" with "X"
# 40. Source step 0046 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "15000"
# 41. Source step 0047 "Enter Coverages" in module "<unresolved module>" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "<unnamed value>" with "{Click}"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
# 42. Source step 0048 "Additional Coverages_New" in module "EQ||Additional Coverages" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_No Coverage_Accidental Death & Dismemberment" with "X"
#    - INPUT "Btn_UMPD_No Coverage_V1" with "X"
#    - INPUT "Btn_UMPD No Coverage" with "X"
#    - INPUT "Btn_check_box_outline_blankDjfak Wopntz" with "{Click}"
#    - INPUT "Btn_check_box_outline_blankKcmgw Unzp" with "{Invoke[Click]}"
#    - INPUT "Btn_No Coverage_2" with "X"
#    - WAIT "Lbl_Uninsured Motorist PD" with "True"
#    - INPUT "Btn_UMPD Limits" with "No Coverage_1"
#    - INPUT "Btn_Next" with "X"
# 43. Source step 0049 "Enter Pricing Details" in module "EQ||Pricing Details" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 44. Source step 0050 "Enter Underwriting" in module "<unresolved module>" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
# 45. Source step 0051 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "3000"
# 46. Source step 0052 "Enter Additional Interest Summary" in module "EQ||Additional Interest Summary" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "btn_Next" with "X"
#    - INPUT "Btn_Next" with "X"
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
# 47. Source step 0053 "EQ||Billing_New" in module "EQ||Billing" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_New Account" with "X"
#    - INPUT "Img_Primary Payer_MAT LABEL" with "{CLICK}"
#    - INPUT "Img_Primary Payer_MAT LABEL" with "{CLICK}"
#    - WAIT "Lbl_Primary Payer" with "True"
#    - INPUT "Lbl_Primary Payer Driver" with "{Invoke[Click]}"
#    - INPUT "Lbl_Primary Payer Driver" with "{Click}"
#    - INPUT "Btn_AccountHolder" with "X"
#    - INPUT "Btn_Primary Insured" with "Djfak Wopntz"
#    - INPUT "Btn_Primary Insured1" with "{Down}"
#    - INPUT "Btn_Direct Bill" with "{Invoke[Click]}"
#    - INPUT "Btn_1 Payment" with "{Invoke[Click]}"
#    - INPUT "Txt_PaymentDueDate" with "{Invoke[Click]}{SENDKEYS[18]}"
#    - INPUT "Txt_InitialPaymentAmount" with "110"
#    - INPUT "DIV_Future PaymentPlan" with "{Click}"
#    - INPUT "Btn_Check" with "X"
#    - INPUT "Txt_InitialPaymentCheckNumber" with "{Invoke[Click]}{SendKeys[4088761300]}"
#    - INPUT "Btn_Next" with "X"
# 48. Source step 0054 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "10000"
# 49. Source step 0055 "EQ||Check Principal/Occasional Box" in module "EQ||Check Principal/Occasional Box" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "DIV_Principal/Occasional" with "True"
# 50. Source step 0056 "EQ||Submission" in module "EQ||Submission" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - BUFFER "Lbl_QuoteTab_Name and Quote number" with "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
#    - WAIT "Txt_AgentComments" with "True"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - WAIT "Txt_Agent Comments" with "True"
#    - INPUT "Txt_Agent Comments" with "Nedd UW Approval"
#    - INPUT "Btn_Refer to UW" with "{Invoke[Click]}"
#    - INPUT "Btn_Launch To Checklist" with "{Invoke[Click]}"
#    - INPUT "Btn_Transmit" with "X"
# 51. Source step 0057 "EQ||Submission" in module "EQ||Submission" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - BUFFER "Lbl_QuoteTab_Name and Quote number" with "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
#    - WAIT "Txt_AgentComments" with "True"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - WAIT "Txt_Agent Comments" with "True"
#    - INPUT "Txt_Agent Comments" with "Nedd UW Approval"
#    - INPUT "Btn_Refer to UW" with "{Invoke[Click]}"
#    - INPUT "Btn_Launch To Checklist" with "{Invoke[Click]}"
#    - INPUT "Btn_Transmit" with "X"
# 52. Source step 0058 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 53. Source step 0059 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YD2102"
#    - VERIFY "Lbl_Password" with "Password"
#    - INPUT "Txt_Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_FORGOT LOGIN ID?" with "True"
#    - VERIFY "Lnk_FORGOT PASSWORD?" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 54. Source step 0060 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 55. Source step 0061 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YD2102"
#    - VERIFY "Lbl_Password" with "Password"
#    - INPUT "Txt_Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_FORGOT LOGIN ID?" with "True"
#    - VERIFY "Lnk_FORGOT PASSWORD?" with "True"
#    - INPUT "Btn_Sign On" with "X"
# 56. Source step 0062 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - BUFFER "DIV_Agent Documents Count" with "AgentList count"
#    - VERIFY "DIV_Agent Documents Count" with the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 57. Source step 0063 "EQ||ECheckList" in module "EQ||ECheckList" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 58. Source step 0064 "TBox Save As" in module "TBox Save As" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png"
#    - INPUT "Button" with "Open"
# 59. Source step 0065 "EQ||ECheckList_1" in module "EQ||ECheckList" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 60. Source step 0066 "TBox Save As_1" in module "TBox Save As" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg"
#    - INPUT "Button" with "Open"
# 61. Source step 0067 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 62. Source step 0068 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "30000"
# 63. Source step 0069 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Title" with "American*"
# 64. Source step 0070 "EQ||Submission_1" in module "EQ||Submission" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - WAIT "Btn_Ok" with "True"
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 65. Source step 0071 "TBox Wait" in module "TBox Wait" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Duration" with "30000"
# 66. Source step 0072 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 67. Source step 0073 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Existing or new TDS type" with "Base_PolicyData_Regression"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with "TC10_UW Rejection Cycle_NM"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "NM"
# 68. Source step 0074 "Submission_2-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 69. Source step 0075 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 18.04.24 14:05:25 [ct2634]
#    - INPUT "Title" with "ExpertQuote*"
# 70. Source step 0078 "Enter Client Selection" in module "EQ || Client Selection" was disabled. Reason: 21.06.24 15:46:34 [ct2634]
#    - VERIFY "Lbl_Client Info" with "True"
#    - VERIFY "Lbl_Client Info" with "Client Info"
#    - VERIFY "Lbl_New/Existing Client Search" with "True"
#    - VERIFY "Lbl_New/Existing Client Search" with "New/Existing Client Search"
#    - INPUT "Txt_First" with "{Invoke[Click]}{SENDKEYS[Shavon]}"
#    - INPUT "Txt_Last" with "Ceballos"
#    - INPUT "Txt_Date of birth" with a blank value
#    - INPUT "Txt_Best phone" with a blank value
#    - INPUT "Txt_Email address" with a blank value
#    - VERIFY "Btn_Search" with "True"
#    - INPUT "Btn_Search" with "X"
#    - VERIFY "Btn_Create New Client" with "Create New Client"
#    - INPUT "Btn_Create New Client" with "X"
#    - VERIFY "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 71. Source step 0079 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 21.06.24 15:46:34 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with "8/18/1958"
#    - INPUT "Txt_Best phone_Account Owner" with "9072279057"
#    - INPUT "Txt_Email_Account Owner" with "SHAVONCEBALLOS0622@COMCAST.NET"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Txt_Enter a location" with "TRES YUCCAS RD"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with "LAS CRUCES"
#    - INPUT "Drpdwn_State" with "NEW MEXICO"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with "880120000"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 72. Source step 0082 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0082 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 74. Source step 0082 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 75. Source step 0089 field "Lnk_USE EXISTING ACCOUNT" in "Enter SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 76. Source step 0092 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 77. Source step 0096 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0098 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0098 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 80. Source step 0098 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0098 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0098 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0098 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0098 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 85. Source step 0098 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0098 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 87. Source step 0098 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 88. Source step 0098 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 89. Source step 0098 field "Btn_PriorInsurance_Yes" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 90. Source step 0098 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 91. Source step 0098 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0098 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 93. Source step 0100 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0100 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 95. Source step 0100 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0100 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 97. Source step 0100 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 98. Source step 0100 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 99. Source step 0100 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 100. Source step 0100 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 101. Source step 0100 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 102. Source step 0100 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 103. Source step 0100 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 104. Source step 0100 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 105. Source step 0100 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 106. Source step 0100 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 107. Source step 0101 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 108. Source step 0102 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 109. Source step 0102 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 110. Source step 0103 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 111. Source step 0104 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 112. Source step 0104 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 113. Source step 0104 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 114. Source step 0104 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 115. Source step 0104 field "Btn_Pleasure" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 116. Source step 0104 field "Btn_No_non-factory additions, alterations, or modifications" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 117. Source step 0104 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 118. Source step 0104 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 119. Source step 0104 field "Lbl_Does this vehicle have any customized equipment?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 120. Source step 0104 field "Btn_Does this Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "No"
# 121. Source step 0104 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 122. Source step 0104 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 123. Source step 0104 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 124. Source step 0104 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "07/10/2003"
# 125. Source step 0104 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 126. Source step 0104 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 127. Source step 0104 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 128. Source step 0104 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "120000"
# 129. Source step 0104 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 130. Source step 0104 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 131. Source step 0105 field "Btn_VehSelect" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 132. Source step 0105 field "Btn_1997 Harley Davidson FLSTF FAT" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 133. Source step 0105 field "Btn_1988 Ford E350" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 134. Source step 0105 field "Btn_Principal_2" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 135. Source step 0105 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 136. Source step 0105 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 137. Source step 0105 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 138. Source step 0105 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 139. Source step 0105 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 140. Source step 0105 field "Btn_Vehicle_Select" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 141. Source step 0105 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 142. Source step 0105 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 143. Source step 0105 field "Btn_Principal_New" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 144. Source step 0105 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 145. Source step 0105 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 146. Source step 0106 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 147. Source step 0109 field "Hdr_Claims" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "True"
# 148. Source step 0110 field "Btn_+ ADD CLAIM" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "X"
# 149. Source step 0114 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 150. Source step 0114 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 151. Source step 0117 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 152. Source step 0117 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 153. Source step 0117 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 154. Source step 0117 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 155. Source step 0117 field "Btn_No Coverage_2" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 156. Source step 0117 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 157. Source step 0117 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 158. Source step 0122 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 159. Source step 0122 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 160. Source step 0122 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 161. Source step 0124 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 162. Source step 0125 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 163. Source step 0126 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 164. Source step 0127 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 165. Source step 0131 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 166. Source step 0132 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 167. Source step 0133 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 168. Source step 0171 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 169. Source step 0172 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 170. Source step 0173 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 171. Source step 0189 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 172. Source step 0190 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 173. Source step 0190 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 174. Source step 0190 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 175. Source step 0191 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 176. Source step 0193 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 177. Source step 0198 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 178. Source step 0203 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 179. Source step 0203 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 180. Source step 0203 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
# 181. Source step 0206 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 182. Source step 0207 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 183. Source step 0208 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 184. Source step 0213 field "Btn_Yes" in "EU||Transact" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 185. Source step 0217 field "DIV_Risk Score" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "RiskScore"
# 186. Source step 0217 field "Hdr_DC-SECTION" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 187. Source step 0219 "TBox Evaluation Tool" in module "TBox Evaluation Tool" was disabled. Reason: 18.04.24 10:59:45 [ct2634]
#    - VERIFY "Expression" with the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='5'"
# 188. Source step 0220 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 18.04.24 10:59:45 [ct2634]
#    - INPUT "Activity Point_NM" with "Activity points for At fault_NM is as Expected"
# 189. Source step 0221 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 18.04.24 10:59:45 [ct2634]
#    - INPUT "Activity Point_NM" with "Activity points for At fault_NM is as Fail"
# 190. Source step 0222 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:42 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 191. Source step 0225 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:46 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 192. Source step 0226 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 193. Source step 0228 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 194. Source step 0229 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 195. Source step 0230 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 196. Source step 0231 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 197. Source step 0232 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 198. Source step 0233 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 199. Source step 0234 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 200. Source step 0235 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 201. Source step 0236 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
