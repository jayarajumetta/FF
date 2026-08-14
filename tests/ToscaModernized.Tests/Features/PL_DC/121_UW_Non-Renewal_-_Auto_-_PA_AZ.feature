# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 121_UW_Non-Renewal_-_Auto_-_PA_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @non_renewal @Arizona @Edge @manual @archive @automated
Feature: Execute UW Non-Renewal - Auto - PA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Non-Renewal - Auto - PA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Non-Renewal - Auto - PA using representative iteration Arizona (AZ)
    # Source step 0031: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-8dfa-5a64-838e009907d2
    Given "Lbl_Client Info" should exist
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

    # Source step 0032: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-dde2-8c46-b998dad42395
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072279303" in "Txt_Best phone_Account Owner"
    When I enter or select "SHERRIEAUSTIN0825@YAHOO.COM" in "Txt_Email_Account Owner"
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

    # Source step 0033: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-0228-a13d-b86a2995348b
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Personal Auto"
    When I enter or select "12/14/2023" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[PENNSYLVANIA]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"

    # Source step 0034: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0035: Verify if popup appears | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-ac8b-fdd2-fee9f1436bbe
    # Runtime control: If_Invalid Address appears > Condition 
    Then if the source runtime condition "If_Invalid Address appears > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0036: Proceed with Details | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-0828-49bf-cadc1ebcd13c
    # Runtime control: If_Invalid Address appears > Then
    When if the source runtime condition "If_Invalid Address appears > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0037: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-bd97-88dd-5d977b7519e4
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0038: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-6b50-92c7-200c0912323e
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0039: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-6d4d-f955-947565bb8119
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0040: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-9c0d-b4e3-0000e3b7b99f
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0041: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-af15-9eef-62cffaa3b7b2
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0043: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-024b-5069-90b8fedf11ef
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0044: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-e892-14a7-27e13fa57cdc
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "Quote Number"

    # Source step 0045: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-69fd-6fa1-667910cc1082
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0046: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-4bf8-528a-54a094678196
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0047: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-24b0-0227-e8c4417bdff0
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0048: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-d7ec-dcd4-a2466f086660
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
    When I select "Btn_Was this client insured with AN_No"
    When I click "Btn_Save and Continue"

    # Source step 0049: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-ab5f-1460-215a04164cba
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

    # Source step 0050: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0051: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-2450-c4cd-b8ec636600b4
    When I click "Btn_Next"

    # Source step 0052: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-3bd3-21a0-3e31b5dd3ff0
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0053: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-466d-252d-158f19d3f68f
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0054: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-26a7-c758-db5ca1604635
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "WBSNB93527CX07002" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" exists
    When I enter or select "No" in "Btn_Does this Vehicle"
    Then I wait until "Txt_PurchaseDate" exists
    When I enter or select "07/10/2003" in "Txt_PurchaseDate"
    When I enter or select "\"^{a}\"" in "Txt_Odometer"
    Then I wait until "Txt_Odometer" exists
    When I click "Txt_Odometer"
    When I enter or select "120000" in "Txt_Odometer"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0055: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-de1c-70fd-cb803da011b0
    When I click "Btn_1988 Ford E350"
    When I click "Btn_Principal_2"
    When I click "Btn_Next"

    # Source step 0056: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-13d5-3f40-e68bd098092e
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0057: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-b918-04df-a3929a52d8b5
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0058: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0059: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-4123-ea7b-8fb07c2c1d68
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0060: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-aebb-178f-763b17db31b9
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0061: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-c2d5-3bb4-dcadeae09c03
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0062: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-034d-4166-cc4fd409970c
    When I click "Btn_Next"

    # Source step 0063: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0064: Enter Coverages | Module: <unresolved module>
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-da9b-1034-04c876fd72bc
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0065: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fb3-ea91-c34c-3d0a94664197
    When I select "Btn_No Coverage_Income Loss"
    When I select "Btn_No Coverage_Accidental Death & Dismemberment"
    When I click "Btn_Full"
    When I select "Btn_No Coverage_UMPD"
    When I select "Btn_No Coverage_Extraordinary Medical Benefit"
    When I click "Btn_Next"

    # Source step 0066: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-fd91-7d2c-f3dd23632a2a
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0067: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-ee0c-03e7-e02320cb510c
    When I click "<unnamed value>"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0069: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-28f3-7ced-31228129524b
    When I click "btn_Next"

    # Source step 0070: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Auto Policy > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0075: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0076: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0077: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0081: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0082: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0083: Search Policy Number | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0084: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0085: Click on Pricing | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0086: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0087: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0089: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0090: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0091: Click on Home button | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0093: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0094: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0095: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0096: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0097: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0098: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0099: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0100: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0101: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0102: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0103: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-05a5-33fb-64b502954bdb
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0104: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-922f-e246-14183120eda3
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0105: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-9137-ff7b-762cefaa0917
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0106: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-ccd4-005a-acf533d7d85e
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0107: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-66c9-bb5d-2347f2b059d9
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0108: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-2be5-2c60-e6177c988777
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0109: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fbf-3c20-ce23-493c6c362ee4
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0110: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-9ca9-bb9b-6836aa399929
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0111: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-b3ed-2f38-c56e48805b50
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0112: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-45aa-4669-4dc02ec3275f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0113: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-bfc0-aae0-5e004b63af96
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0114: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-820f-834b-185d97b2ddd0
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0115: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-d198-daab-d1e42fe00887
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0116: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-ad94-4a22-9161e87e7316
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0117: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0121: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-696d-e184-5f899856562b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0122: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-ea08-a0d2-8c1d0a6a5bf1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0123: EU||Home | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc1-ba2a-8cad-3cccd148632b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0124: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-3f1a-8449-17b278c7aab9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0125: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-88c4-b3f1-cd89c9406ca7
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0126: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-d56c-53c3-b8cdd6dabf12
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0127: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-b519-b453-cb5a61f98b29
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0128: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-7d3c-45e5-5e7a13c677e9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0129: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-da66-84e3-63a379221f45
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0130: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-e5bb-9dd3-4061f96282bb
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0131: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-73a6-7f66-879f4c665b11
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0132: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-0a1f-f517-b94d50fba873
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0133: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-db24-935b-d151758e2595
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0134: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-c1d7-d613-ea73b679912e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0135: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-e424-2144-628d7aaafd28
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0137: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-426d-21ff-0cf92177d450
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0139: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-1cc2-7b04-cf8bc50c299a
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

    # Source step 0140: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-86fd-d142-b827dd9e393a
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0141: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-978f-bd9c-867b6d392534
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0142: TBox Save As | Module: TBox Save As
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-76cf-5f27-ab372e7823d0
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0143: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-04a6-e023-30a2bea120fb
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0144: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Auto Policy > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-ee41-8379-c5b125db3add
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0146: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0147: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-486e-7ec8-3266c1da86f1
    When I close the active browser

    # Source step 0148: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Auto Policy > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-4d91-0b41-5ddf62902adf
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0149: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 15 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0150: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-ca74-5de0-d6b3dd6dd6ae
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0151: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-0478-1cec-e7dcceb7f92a
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0152: Set LOB & State | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 16 TDS Validation > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "PA" as runtime value "State"

    # Source step 0162: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Process > Auto Policy > 16 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0163: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 16 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0164:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 16 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0165: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-763d-1aba-53bf9a942ee1
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0166: Submission - Save & Exit Policy | Module: EQ||Submission
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-8ab1-15d9-861b7fb0e344
    When I click "Btn_Save and Exit"

    # Source step 0167: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0168: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0169: OpenUrl | Module: OpenUrl
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0173: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-5909-df97-a7ddd15c213f
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0174: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-30e0-d4e5-122013d3b6e2
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0175: Search Policy | Module: EU||Home
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-22db-36fd-054248af210c
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0176: Click Policy holder name | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-c290-dc44-453d0cefccf3
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0177: Click Non-Renew Transaction | Module: EU|Transaction Type
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-59a9-a2a7-f358cbbbbcf7
    When I click "expand"
    When I select "Non-Renew"
    When I click "Go"

    # Source step 0178: Capturing Eff Date & Schedule date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-95fb-ace4-82736eabbda9
    When I capture "Value" from "Effective Date" as runtime value "EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):" as runtime value "Schedule Date"

    # Source step 0179: Set Dates | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-66e4-c117-5b258d3ea048
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]}" as runtime value "ScheduledDate"
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][-25d][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0180: Start PowerShell | Module: TBox Start Program
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-704c-34c7-7dede225a7cf
    And I run program or command "powershell.exe"

    # Source step 0181: Execute PowerShellCommand 1 | Module: TBox Send Keys
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-e7fb-7ea1-3b2ed002ef62
    When I enter or select "*PowerShell*" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\"\"\"\"$TimeSpan=([DateTime]'{B[ScheduledDate]}' - [DateTime]'{B[EffectiveDate]}')\"\"\"\";~" in "Keys"

    # Source step 0182: Execute PowerShellCommand 2  | Module: TBox Send Keys
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-71af-2645-8865f1928b4f
    When I enter or select "*PowerShell*" in "Caption"
    When I enter or select "$TimeSpan | Clip~" in "Keys"

    # Source step 0183: TBox Wait | Module: TBox Wait
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0184: Get Days Difference | Module: TBox Clipboard
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-ce3b-30f4-20c3744a9291
    Then "Value" should equal "Days : {XB[DayDifference]} *"

    # Source step 0185: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-b2d9-9be4-78b56008ad50
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "ScheduledDates"
    And I use TDM parameter "Alias name (item)" with "ScheduledDates"
    And I use TDM parameter "Data search filter > TCName" with "UW Non-Renewal - Auto - PA"
    And I use TDM parameter "Data search filter > State" with "PA"
    And I use TDM parameter "Data search filter > LOB" with "Auto"

    # Source step 0186: Retriving Expected No.of days from TDM | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-7ac2-ab9b-1e4dae1486f2
    When I retrieve and retain the RUNTIME-DERIVED TDM value "ScheduledDates.No of Days Workaround" as runtime value "Expected Days"

    # Source step 0187: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-f198-4945-5579b4c9275e
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Condition
    Then if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[DayDifference]} == {B[Expected Days]}"

    # Source step 0188: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-3097-62bf-597853ff995d
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Then
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Then" is satisfied, I retain hard-coded value "The Actual No.of Days is equal to Expected No.of Days" as runtime value "No.of Days Equal"

    # Source step 0189: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-20bd-4b04-c766bb604b48
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Else
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Else" is satisfied, I retain hard-coded value "The Actaul No.of Days are not equal to Expected No.of Days" as runtime value "No.of Days not Equal"

    # Source step 0190: Add 60 days | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-b1d2-c9da-146f1fcffce5
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Schedule Date]}][-60d][MM/dd/yyyy]}" as runtime value "Future Date"

    # Source step 0191: Set the Scheduled Date after the Effective date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-5738-da9a-8b5ee2ba0635
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{B[Future Date]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0192: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-658d-c8c7-bdf1c6797b8b
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0193: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-b1f2-835c-d10b0a588d87
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0194: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-3e20-e818-998045af06d8
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0195: Set the Scheduled Date to Current Date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-65ef-1b8d-20aba4392175
    When I enter the RUNTIME-DERIVED date from Tosca expression "{CLICK}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[{DATE[][][MM/dd/yyyy]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0196: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-0bdc-8e90-0a1729ab32c7
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0197: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-265e-2680-76f659d48891
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0198: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-366c-9c85-6967b82f64e6
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0199: Exit the TransACT Page | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Go Back to TransACT Page & Click Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-c122-592b-2503fbbbd135
    When I click "Exit Without Saving"

    # Source step 0200: Select Non Renew TransACT | Module: EU|Transaction Type
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Go Back to TransACT Page & Click Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-d7bb-3fe7-1f8029ce92a5
    When I click "expand"
    When I select "Non-Renew"
    When I click "Go"

    # Source step 0201: Capturing Eff Date & Schedule date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Go Back to TransACT Page & Click Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-2dd9-282c-7cfd09c03ca4
    When I capture "Value" from "Effective Date" as runtime value "EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):" as runtime value "Schedule Date"

    # Source step 0202: Set the date to Less than Expected No of days | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-d1f4-cf98-a76290025d89
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Schedule Date]}][+8d][MM/dd/yyyy]}" as runtime value "Add 8 Days"

    # Source step 0203: Set the Scheduled Date less than Expected No.of Days | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-1568-37c2-395cfd718c3e
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{B[Add 8 Days]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0204: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-1f64-761e-0ff1f206bc9b
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0205: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-4081-983b-b5801c78f0e9
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0206: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-d892-1b6d-1a2d0c37e02c
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0207: Set the date to More than Expected No of days | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-a6c5-6c5b-ee1d1b6e416f
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Schedule Date]}][-6d][MM/dd/yyyy]}" as runtime value "Minus 6 Days"

    # Source step 0208: Set the Scheduled Date more than Expected No.of Days | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-6956-d780-d4591d2706ac
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{B[Minus 6 Days]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0209: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-f400-6895-24f29478636b
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0210: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-801c-38ea-fb1d355f4c37
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0211: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-b436-dcdc-4e4df04c2121
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0212: click Non Renew Detailed reason | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-85f6-4cd9-9fb3eb113719
    When I click "Detailed Reason_expand"
    When I click "Claims Review"

    # Source step 0213: Select  & Cick Schedule | Module: EU|Schedule
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-2f5f-4a44-29b168033c9b
    When I enter or select "True" in "MVR_1"
    When I click "Schedule"

    # Source step 0214: TBox Wait | Module: TBox Wait
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-7563-6d68-b9799ecc044e
    When I wait "5000" milliseconds

    # Source step 0215: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2fc2-64cf-564c-0d9bd71786f5
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0012 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0013 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0014 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0016 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 5. Source step 0018 "Unlock TDS Type" in module "Old_TestData - Expert module" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 6. Source step 0019 "Find Client Data with Sno" in module "Old_TestData - Find & provide item" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - INPUT "Existing TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
#    - INPUT "Data search filter > Sno" with the unresolved source parameter "Sno" (not supplied by this reusable-block invocation)
# 7. Source step 0020 "Set CaseName" in module "TBox Set Buffer" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - INPUT "CaseName" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 8. Source step 0021 "Check If CaseName is NULL" in module "TBox Set Buffer" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - VERIFY "CaseName" with ""
# 9. Source step 0022 "Unlock TDS Type" in module "Old_TestData - Expert module" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 10. Source step 0023 "Find Client Data with Sno" in module "Old_TestData - Find & provide item" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - INPUT "Existing TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
#    - INPUT "Alias name (item)" with captured runtime value "TCName"
#    - INPUT "Data search filter > Sno" with the unresolved source parameter "Sno" (not supplied by this reusable-block invocation)
# 11. Source step 0024 "TestData - Update TCName" in module "TestData - Update item" was disabled. Reason: 15.05.24 12:38:46 [ct2518]
#    - INPUT "Existing alias name (item)" with captured runtime value "TCName"
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > Processed" with "Y"
# 12. Source step 0029 "Enter Client Selection" in module "EQ || Client Selection" was disabled. Reason: 01.06.24 14:12:48 [ct2634]
#    - VERIFY "Lbl_Client Info" with "True"
#    - VERIFY "Lbl_Client Info" with "Client Info"
#    - VERIFY "Lbl_New/Existing Client Search" with "True"
#    - VERIFY "Lbl_New/Existing Client Search" with "New/Existing Client Search"
#    - INPUT "Txt_First" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.FirstName"
#    - INPUT "Txt_Last" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.LastName"
#    - INPUT "Txt_Date of birth" with a blank value
#    - INPUT "Txt_Best phone" with a blank value
#    - INPUT "Txt_Email address" with a blank value
#    - VERIFY "Btn_Search" with "True"
#    - INPUT "Btn_Search" with "X"
#    - VERIFY "Btn_Create New Client" with "Create New Client"
#    - INPUT "Btn_Create New Client" with "X"
#    - VERIFY "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 13. Source step 0030 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 01.06.24 14:12:48 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.DOB"
#    - INPUT "Txt_Best phone_Account Owner" with "9072007096"
#    - INPUT "Txt_Email_Account Owner" with "CHRSTINECULLEN0702@OUTLOOK.COM"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Married" with "X"
#    - INPUT "Txt_Enter a location" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.Street_Address"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.City"
#    - INPUT "Drpdwn_State" with "PENNSYLVANIA"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.Zip"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 14. Source step 0032 field "Btn_Single" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 15. Source step 0032 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0032 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 17. Source step 0032 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0033 field "Btn_Recreational Vehicle" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0033 field "Hdr_proposal.ratingState-panel" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "New Mexico"
# 20. Source step 0033 field "Drp List_List Auto Writing Company" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0033 field "Hdr_Writing Company" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[American National Property And Casualty Co.]}"
# 22. Source step 0033 field "Lbl_Select Risk Address" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 23. Source step 0033 field "Drp List_State" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[PENNSYLVANIA]}"
# 24. Source step 0033 field "Btn_PROCEED" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0039 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 26. Source step 0042 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 27. Source step 0048 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 28. Source step 0048 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 29. Source step 0048 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0048 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 31. Source step 0048 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0048 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0048 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 34. Source step 0048 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 35. Source step 0048 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0048 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 37. Source step 0048 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 38. Source step 0049 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 39. Source step 0049 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 40. Source step 0049 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 41. Source step 0049 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0049 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 43. Source step 0049 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 44. Source step 0049 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 45. Source step 0049 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 46. Source step 0049 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 47. Source step 0049 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0049 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0051 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0052 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0052 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0053 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0054 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 54. Source step 0054 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0054 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 56. Source step 0054 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0054 field "Btn_Cycle_Customizatioin_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 58. Source step 0054 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 59. Source step 0054 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0054 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0054 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 62. Source step 0054 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 63. Source step 0054 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0055 field "Btn_VehSelect" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 65. Source step 0055 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 66. Source step 0055 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 67. Source step 0055 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0055 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0055 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 70. Source step 0055 field "Btn_Vehicle_Select" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 71. Source step 0055 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0055 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 73. Source step 0055 field "Btn_Principal_New" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 74. Source step 0055 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 75. Source step 0055 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 76. Source step 0056 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0062 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0062 field "Btn_Not Residential Property Owner" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 79. Source step 0062 field "Btn_No Proof of Prior Insurance" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0062 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 81. Source step 0064 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 82. Source step 0064 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0064 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0064 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 85. Source step 0064 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 86. Source step 0065 field "Btn_UMPD_No Coverage_V1" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 87. Source step 0065 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0065 field "Btn_$40 per day/$800 per occurrence" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 89. Source step 0065 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 90. Source step 0065 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 91. Source step 0065 field "Btn_No Coverage_2" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0065 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 93. Source step 0065 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 94. Source step 0067 field "<unnamed value>" in "Enter Underwriting" was disabled. Reason:  
#    - Preserved source value: "True"
# 95. Source step 0067 field "<unnamed value>" in "Enter Underwriting" was disabled. Reason:  
#    - Preserved source value: "X"
# 96. Source step 0069 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 97. Source step 0069 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 98. Source step 0069 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 99. Source step 0071 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 100. Source step 0072 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 101. Source step 0073 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 102. Source step 0074 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 103. Source step 0078 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 104. Source step 0079 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 105. Source step 0080 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 106. Source step 0118 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 107. Source step 0119 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 108. Source step 0120 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 109. Source step 0136 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 110. Source step 0137 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 111. Source step 0137 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 112. Source step 0137 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 113. Source step 0138 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 114. Source step 0140 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 115. Source step 0145 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 116. Source step 0150 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "True"
# 117. Source step 0150 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 118. Source step 0150 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "X"
# 119. Source step 0153 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 120. Source step 0154 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 121. Source step 0155 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 122. Source step 0156 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 123. Source step 0157 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 124. Source step 0158 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 125. Source step 0159 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 126. Source step 0160 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 127. Source step 0161 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 128. Source step 0170 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 129. Source step 0171 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 130. Source step 0172 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 131. Source step 0216 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:42 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 132. Source step 0217 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:46 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 133. Source step 0218 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 134. Source step 0219 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 29.05.24 14:06:17 [ct2634]
#    - INPUT "Title" with "ExpertQuote*"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0220 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\UW Non-Renewal-Auto_PA_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0221 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0222 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0223 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0224 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\UW Non-Renewal-Auto_PA_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0225 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0226 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0227 CloseBrowser: I close the active browser
