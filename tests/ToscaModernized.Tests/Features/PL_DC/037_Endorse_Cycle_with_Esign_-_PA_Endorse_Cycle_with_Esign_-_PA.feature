# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 037_Endorse_Cycle_with_Esign_-_PA_Endorse_Cycle_with_Esign_-_PA.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @Edge @manual @archive @automated
Feature: Execute Endorse Cycle with Esign - PA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse Cycle with Esign - PA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse Cycle with Esign - PA using representative iteration Endorse Cycle with Esign - PA
    # Source step 0009: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27b7-2610-d2c1-50ae0493154c
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

    # Source step 0010: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27b7-9e48-c36d-25120a9ca729
    Then I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0011: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27b7-16f9-a278-5108227dbc0b
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.LastName" in "Txt_Last"
    When I leave "Txt_Date of birth" blank
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I click "Btn_Create New Client"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0012: Enter Account Details - New Account Information | Module: EQ||Account Details
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27b7-34a5-75e5-ef2ff4470557
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072232860" in "Txt_Best phone_Account Owner"
    When I enter or select "KARABEAUVIEW0813@VERIZON.NET" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I select "Btn_Married"
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.City" in "Txt_owner.address.city_New"
    When I enter or select "PENNSYLVANIA" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0013: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-63a2-b2c7-cf5821d6064a
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[PENNSYLVANIA]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"

    # Source step 0014: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0015: Verify If Popup appears | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-ea85-06e4-00ab67400ceb
    # Runtime control: If_Invalid Address appears > Condition - If Popup appears
    Then if the source runtime condition "If_Invalid Address appears > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0016: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-47a8-927f-fa216caee047
    # Runtime control: If_Invalid Address appears > Then
    When if the source runtime condition "If_Invalid Address appears > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0017: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-4f0d-a1fa-ec6fa8a80267
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0018: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-33db-83f5-d2d31d4bc968
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0019: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-8ada-ef77-8b446636d3d9
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter or select "666341778" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0020: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-b4f7-b2e9-d53811dfb153
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0021: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-a56b-f6dc-aaf69b04b81c
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_CREATE NEW ACCOUNT"

    # Source step 0023: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-8da6-c41c-9a963db163d4
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0024: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-2aff-9f02-1a30b9315c58
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0025: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-6ad7-a239-6ef71dc429b8
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0026: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-fd54-370c-1f2832392102
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0027: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-f5d4-60f3-bb449dcbd3e8
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0028: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-b305-c017-3788e78973c1
    # Runtime control: If_Driver Sumary_Prior Insurance > Then
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Then" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    Then I wait until "Btn_priorCarrierName" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorCarrierName"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Geico]}" in "Btn_priorCarrierName"
    Then I wait until "Btn_priorPolicyNumber" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorPolicyNumber"
    When I enter or select "{Invoke[Click]}{SENDKEYS[5127398001]}" in "Btn_priorPolicyNumber"
    Then I wait until "Btn_yearsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_yearsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[2]}" in "Btn_yearsWithPriorCarrier"
    Then I wait until "Btn_monthsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_monthsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[0]}" in "Btn_monthsWithPriorCarrier"
    When I click "Btn_Save and Continue"

    # Source step 0029: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-316a-1566-14b39759d6d3
    # Runtime control: If_Driver Sumary_Prior Insurance > Else
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Else" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_Yes"
    Then I wait until "Btn_priorCarrierName" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorCarrierName"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Geico]}" in "Btn_priorCarrierName"
    Then I wait until "Btn_priorPolicyNumber" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorPolicyNumber"
    When I enter or select "{Invoke[Click]}{SENDKEYS[5127398001]}" in "Btn_priorPolicyNumber"
    Then I wait until "Btn_yearsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_yearsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[2]}" in "Btn_yearsWithPriorCarrier"
    Then I wait until "Btn_monthsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_monthsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[0]}" in "Btn_monthsWithPriorCarrier"
    When I click "Btn_Save and Continue"

    # Source step 0030: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0031: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-997d-e882-6a40a0e09497
    When I click "Btn_Next"

    # Source step 0032: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-c7cb-fa4d-43795aaaea02
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0033: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-f92b-5b74-197af4a879f2
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0034: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27bc-21d8-799b-a2de26a9b2b4
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

    # Source step 0035: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c4-25a4-bb09-fb18ced249d3
    When I click "Btn_2014 Harley Davidson FLHXS_V1"
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0036: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c5-4aa8-7eaa-dac5fe03ee63
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0037: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-236b-1872-2dcfcc770d0f
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0038: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0039: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-4949-39fb-c94beecf93b3
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0040: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-82f0-be1c-bda2853afbf2
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0041: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-a95b-a3fe-85bfa2f0a7ff
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0042: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-1420-8bb2-8cbdacdf3eff
    When I click "Btn_Next"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0044: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-0d95-832c-a012939224f9
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0045: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-6b17-00c6-78609fc93a46
    When I click "Btn_Next"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-6b64-cae0-3c81b1d17539
    When I wait "15000" milliseconds

    # Source step 0047: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-b934-9aeb-01949458a797
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0048: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-771e-b19c-c0d1724c2b2d
    When I click "<unnamed value>"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0050: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-d058-a7cb-075307b877b9
    When I click "btn_Next"

    # Source step 0051: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0056: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0057: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0061: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0062: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0063: Search Policy Number | Module: EU||Home
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0064: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"
    When I enter the unresolved source parameter "PersonalAuto" (not supplied by this reusable-block invocation) in "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0065: Click on Pricing | Module: EU||Applicant
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0066: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0067: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0069: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0071: Click on Home button | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0072: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0073: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0074: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0075: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0076: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0077: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0078: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0080: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0081: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0083: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-c4b5-e56f-1251d3e3186d
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0084: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-0769-6ac1-02343bd8daa6
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0085: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-a8c7-6990-3b8242efab93
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0086: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-69d4-8dc3-803cdb969e80
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0087: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27c9-fae3-caec-7a0dd63243f0
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0088: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-5b7a-9199-6d610f19d1b1
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0089: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-5d82-7102-366a3eefabb9
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0090: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-a139-b19c-41fa9d010889
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0091: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0095: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0096: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0097: EU||Home | Module: EU||Home
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0098: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0099: EU||Applicant | Module: EU||Applicant
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0100: EU||Pricing | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0101: EU||Pricing | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0102: EU||Pricing | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0105: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0106: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Cycle Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-3805-b0a8-3be9908e3025
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0107: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-6144-af49-c617a221064d
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0108: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Cycle Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-ee50-7695-52bba0e48052
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0109: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-2945-0fc6-f7e99b15645a
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0110: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-54a0-682a-2934fba71e79
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0111: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-b7bc-313e-f5ccf89f5df5
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, "Img_American National Family of Companies" should exist
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

    # Source step 0112: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0113: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-ad39-6831-85b35c6601ee
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0114: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-ed99-97d9-5b02d01610de
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter or select "Eeshitha.Gaddam@AmericanNational.com" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0115: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0116: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-d430-2560-1dffbbc074b0
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0117: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0118: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-05fb-4ffb-e046971b493b
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0119: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-cc47-93d8-917b07c61d64
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter or select "Eeshitha.Gaddam@AmericanNational.com" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0120: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0121: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-23b7-4fe4-690dfe596956
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0122: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0123: Open Url | Module: Open Url_ARA
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-1811-52e9-f148f00758b7
    When I enter or select "https://outlook.office.com/mail/" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0124: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-cb1b-3951-d1f4a008ebc9
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0125: Refresh | Module: TBox Send Keys
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27cf-9742-c87f-852796c2e55c
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0126: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d4-dd5d-238f-9da8e4d0cd5b
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-Sign Live _Updated" should not exist

    # Source step 0127: Refresh | Module: TBox Send Keys
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d4-9665-31c1-c07ac19a9733
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0128: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d4-0d82-ccd9-44c6ac61ce23
    When I wait "6000" milliseconds

    # Source step 0129: Refresh | Module: TBox Send Keys
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d4-fa3a-c003-437463fbfaa3
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0130: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d5-dd5a-0eb5-5a884cc895d0
    When I click "e-Sign Live _Updated"

    # Source step 0131: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d5-dfd9-7718-2428c2af01de
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0132: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d5-9dc5-c7b6-149853fce221
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0133: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d5-d5ac-7076-62cdcb964fc4
    When I close the active browser

    # Source step 0134: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d5-fc7a-c2f6-c5cf8a1655d1
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0135: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d5-dc1a-92a5-f6eb904400e4
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0136: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0137: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-bbba-c135-537bcb743e56
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0138: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-4d6a-f6b7-392c96b1d5fc
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0139: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-dc7c-d297-3acec800f637
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0140:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-21e3-5699-e7a5692fd279
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Sign" is visible
    When I click "Sign"

    # Source step 0141: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-01c8-42a4-548f908c1b93
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0142: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0143: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0144: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-213e-2b5d-2bb30ac907cb
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0145: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-8b5d-2504-da15bdd383d3
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0146: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-3e74-38b8-20a350ae45b3
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0147: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-a8b8-e07c-dbbb706ef02b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0148: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-158c-6f24-a70373c4cd9a
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0149: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-4269-70b0-e68e3a67cb8c
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0150:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-e436-96db-56cfb8469801
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0151: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-afaf-4497-514297f96d3e
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0152: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0153: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0154: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-3f41-966f-b3ecfefda573
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0155: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0156: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-fb56-5dc5-99d6e3f2c2d3
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0157: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-19d0-1cba-a092f30d7cc6
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0158: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-b623-9305-abf726eb08e6
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0159:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-94cd-6540-cead2fa8fdf9
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0160: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-39a2-77f9-93b70da9ad5d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0161: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0162: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0163: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-ba81-58ea-2e59c8d57082
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0177: Click on Transmit | Module: EQ||Submission
    # Section: Process > Cycle Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-1988-5650-a730babcf962
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0178: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 16 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0179: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Cycle Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27d6-73c2-1a32-9004a989a9a0
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0197: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy > 17 TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-2898-a84b-6c6cd5642279
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Cycle with Esign - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0198: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy > 17 TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-3dd8-2360-be3492496eab
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Cycle with Esign - AZ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "AZ"

    # Source step 0199: Click Save and exit | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-6502-114b-ed4740e4e743
    When I click "Btn_Save and Exit"

    # Source step 0200: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0201: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-d9ae-21bc-d3953312b17f
    When I close the active browser

    # Source step 0202: OpenUrl | Module: OpenUrl_old
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-8942-2c8d-f3eb2360ce4e
    When I open "https://expertquote-qa.americannational.com/expertquote/#/quote"

    # Source step 0203: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-283a-9af9-8a884d268f96
    # Runtime control: Wait for Login Page [max=30] > Condition
    Then if the source runtime condition "Wait for Login Page [max=30] > Condition" is satisfied, "Txt_Username" should exist

    # Source step 0204: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Login Page [max=30] > Loop
    When if the source runtime condition "Wait for Login Page [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0205: Maximize Window | Module: TBox Window Operation
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-9a63-313c-d04b690d27b6
    When I enter or select "*Sign On*" in "Caption"
    When I enter or select "Maximize" in "Operation"

    # Source step 0206: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-6f7c-e4d8-6c2bb24c7913
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0207: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-bd6e-2141-b56eca804005
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0208: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-33b3-b6fb-86428aa31e23
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0209: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-674d-b197-fc82573b5fe6
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0210: If Recall quote/policy is visible | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-98fe-c374-c02cb755aa05
    # Runtime control: Recall quote/policy is visible > Verify if Recall quote/policy is visible
    Then if the source runtime condition "Recall quote/policy is visible > Verify if Recall quote/policy is visible" is satisfied, "Txt_Quote\\Policy Search" should be visible

    # Source step 0211: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-9c78-5ac2-05528ccf7720
    # Runtime control: Recall quote/policy is visible > Recall Quote\Policy
    When if the source runtime condition "Recall quote/policy is visible > Recall Quote\\Policy" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0212: Quick Actions | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-866c-e55e-ae6af717c1e9
    When I click "Btn_+ CREATE NEW POLICY CHANGE"
    When I enter or select "{CLICK}{SENDKEYS[Endorse Coverage Limit]}" in "Txt_Policy Change Field"
    When I click "Btn_OK"

    # Source step 0213: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-199e-6b3d-52cc029d248a
    When I select "Btn_SafeCycle_Yes_D1"
    When I enter or select "10/10/2022" in "Txt_safeCycleDiscountDate_D1"
    When I click "Btn_Next"

    # Source step 0214: Click on Coverages | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-dbbb-ad67-190b9b4cead3
    When I click "Coverages"

    # Source step 0215: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0216: Select Lower Cverage BI/PD | Module: <unresolved module>
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-acb2-dd15-1f4aa5d4a20d
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0217: Click on submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-7e46-8c11-9bde34b7e38b
    When I click "Submission"

    # Source step 0218: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-cc3b-6d88-ee1200e8c8c5
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0220: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-fe8f-7478-8a5805fc0d8f
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0222: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-1a36-58c1-3693fdd503c6
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

    # Source step 0223: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-bceb-2981-fcd4831d49ea
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0224: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-a021-88d0-0a725ed4523a
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0225: TBox Save As | Module: TBox Save As
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-a4dc-4073-c9e3e0e21837
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0226: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-57b6-63e8-2016eef4c111
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0227: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-03fa-c5d4-a414abc28b46
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0229: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0230: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-152b-a8e8-a4d31f8e5f9c
    When I close the active browser

    # Source step 0231: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0232: Click on Transmit | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-2ea5-afbb-66f2d485838e
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0233: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 16 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0234: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-e0f8-be79-bf713d39e0c2
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0235: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-1ef6-9b70-cf8305b820a8
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Cycle with Esign - AZ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "AZ"

    # Source step 0236: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27e4-443d-eb20-59f2120f9e16
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Cycle with Esign - AZ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "AZ"

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0003 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0004 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0005 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0007 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 5. Source step 0012 field "Btn_Single" in "Enter Account Details - New Account Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 6. Source step 0012 field "Txt_Enter a location" in "Enter Account Details - New Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0012 field "Txt_Enter a location" in "Enter Account Details - New Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 8. Source step 0012 field "Btn_Yes_client resides" in "Enter Account Details - New Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0013 field "Btn_Recreational Vehicle" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0013 field "Hdr_proposal.ratingState-panel" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: a blank value
# 11. Source step 0013 field "Drp List_State" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[PENNSYLVANIA]}"
# 12. Source step 0013 field "Lbl_NEW MEXICO" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0013 field "Btn_PROCEED" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0019 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 15. Source step 0021 field "Lnk_USE EXISTING ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 16. Source step 0022 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 17. Source step 0026 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0028 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0028 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 20. Source step 0028 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0028 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0028 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 23. Source step 0028 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0028 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 25. Source step 0028 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 26. Source step 0028 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 27. Source step 0028 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0028 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0029 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0029 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 31. Source step 0029 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0029 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 33. Source step 0029 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0029 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0029 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 36. Source step 0029 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 37. Source step 0029 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 38. Source step 0029 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0029 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 40. Source step 0031 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 41. Source step 0032 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0032 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0033 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 44. Source step 0034 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0034 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0034 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 47. Source step 0034 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0034 field "Btn_Pleasure" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0034 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 50. Source step 0034 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0034 field "Lbl_Does this vehicle have any customized equipment?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0034 field "Btn_Does this Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "No"
# 53. Source step 0034 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0034 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 55. Source step 0034 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0034 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "07/10/2003"
# 57. Source step 0034 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 58. Source step 0034 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0034 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 60. Source step 0034 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "120000"
# 61. Source step 0034 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 62. Source step 0034 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 63. Source step 0035 field "Btn_1988 Ford E350" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 64. Source step 0035 field "Btn_Principal_2" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 65. Source step 0035 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 66. Source step 0035 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 67. Source step 0035 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0035 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0035 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 70. Source step 0035 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0035 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 72. Source step 0035 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 73. Source step 0035 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 74. Source step 0036 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0042 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 76. Source step 0042 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 77. Source step 0045 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0045 field "Btn_UMPD_No Coverage_V1" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 79. Source step 0045 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0045 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 81. Source step 0045 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 82. Source step 0045 field "Btn_No Coverage_2" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0045 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0045 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 85. Source step 0050 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 86. Source step 0050 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 87. Source step 0050 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0052 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 89. Source step 0053 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 90. Source step 0054 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 91. Source step 0055 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 92. Source step 0058 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 93. Source step 0059 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 94. Source step 0060 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 95. Source step 0090 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 96. Source step 0092 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 97. Source step 0093 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 98. Source step 0094 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 99. Source step 0096 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0096 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 101. Source step 0100 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 102. Source step 0100 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 103. Source step 0100 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0100 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 105. Source step 0101 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 106. Source step 0101 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 107. Source step 0101 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 108. Source step 0101 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 109. Source step 0102 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 110. Source step 0102 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 111. Source step 0102 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0102 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 113. Source step 0103 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 114. Source step 0104 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 115. Source step 0113 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 116. Source step 0118 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 117. Source step 0164 "Launch To Checklist" in module "EQ||Submission" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - VERIFY "Btn_Launch To Checklist" with "True"
#    - INPUT "Btn_Launch To Checklist" with "X"
# 118. Source step 0165 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 119. Source step 0166 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
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
# 120. Source step 0167 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 121. Source step 0168 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
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
# 122. Source step 0169 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - BUFFER "DIV_Agent Documents Count" with "AgentList count"
#    - VERIFY "DIV_Agent Documents Count" with the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 123. Source step 0170 "EQ||ECheckList" in module "EQ||ECheckList" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 124. Source step 0171 "TBox Save As" in module "TBox Save As" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png"
#    - INPUT "Button" with "Open"
# 125. Source step 0172 "EQ||ECheckList_1" in module "EQ||ECheckList" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 126. Source step 0173 "TBox Save As_1" in module "TBox Save As" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg"
#    - INPUT "Button" with "Open"
# 127. Source step 0174 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 128. Source step 0175 "TBox Wait" in module "TBox Wait" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - INPUT "Duration" with "30000"
# 129. Source step 0176 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 11.06.24 10:56:17 [ct2634]
#    - INPUT "Title" with "American*"
# 130. Source step 0177 field "Btn_Ok" in "Click on Transmit" was disabled. Reason:  
#    - Preserved source value: "True"
# 131. Source step 0177 field "Btn_Ok" in "Click on Transmit" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 132. Source step 0179 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 133. Source step 0179 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 134. Source step 0179 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 135. Source step 0180 "Submission - Capturing Policy Number,Effective Date, Premium Value" in module "EQ||Submission" was disabled. Reason: 03.06.24 17:33:21 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 136. Source step 0181 "TestData - Save Policy Number, Effective Date to TDM" in module "TestData - Create & provide new item" was disabled. Reason: 03.06.24 17:33:21 [ct2634]
#    - INPUT "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with captured runtime value "TCName"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "NY"
# 137. Source step 0182 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "LOB" with "Auto"
#    - INPUT "State" with "NM"
# 138. Source step 0183 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 139. Source step 0184 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 140. Source step 0185 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 141. Source step 0186 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 142. Source step 0187 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 143. Source step 0188 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 144. Source step 0189 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 145. Source step 0190 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 146. Source step 0191 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 147. Source step 0192 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 148. Source step 0193 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 149. Source step 0194 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
# 150. Source step 0195 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 03.06.24 17:33:21 [ct2634]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "NY"
# 151. Source step 0196 "Submission - Save & Exit Policy" in module "EQ||Submission" was disabled. Reason: 03.06.24 17:33:21 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 152. Source step 0213 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 153. Source step 0213 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 154. Source step 0216 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 155. Source step 0216 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 156. Source step 0216 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 157. Source step 0216 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 158. Source step 0219 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 159. Source step 0220 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 160. Source step 0220 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 161. Source step 0220 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 162. Source step 0221 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 163. Source step 0223 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 164. Source step 0228 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 165. Source step 0234 field "Lbl_Value_Effective Date" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 166. Source step 0234 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 167. Source step 0234 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 168. Source step 0234 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 169. Source step 0237 "Click on Transmit Button" in module "EQ||Submission" was disabled. Reason: 30.04.24 11:25:37 [ct2634]
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 170. Source step 0238 "Buffer Tranmit Premiums" in module "EQ||Submission" was disabled. Reason: 30.04.24 11:25:37 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - BUFFER "Lbl_Policy Number" with "Policy Number"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 171. Source step 0239 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 07.06.24 10:56:14 [ct2634]
#    - INPUT "LOB" with "Cycle"
#    - INPUT "State" with "PA"
# 172. Source step 0240 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 173. Source step 0241 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 174. Source step 0242 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 175. Source step 0243 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 176. Source step 0244 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 177. Source step 0245 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 178. Source step 0246 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 179. Source step 0247 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 180. Source step 0248 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 181. Source step 0249 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 07.06.24 10:56:14 [ct2634]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 182. Source step 0250 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 07.06.24 10:56:14 [ct2634]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 183. Source step 0251 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 07.06.24 10:56:14 [ct2634]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
# 184. Source step 0252 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 07.06.24 10:56:14 [ct2634]
#    - INPUT "Title" with "ExpertQuote*"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0253 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse Cycle with Esign - PA_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0254 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0255 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0256 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0257 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\Endorse Cycle with Esign - PA_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0258 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0259 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0260 CloseBrowser: I close the active browser
