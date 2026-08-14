# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 094_UW_Cancellation_Auto_-_CA_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @cancellation @Arizona @Edge @manual @archive @automated
Feature: Execute UW Cancellation Auto - CA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Cancellation Auto - CA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Cancellation Auto - CA using representative iteration Arizona (AZ)
    # Source step 0009: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3020-ab02-49a3-b9a2b75915b6
    # Runtime control: EQ||Enter Sign On Credentials > Condition - if signon page is displayed
    Given if the source runtime condition "EQ||Enter Sign On Credentials > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0010: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3020-c5e7-be2c-b398fefaa29e
    # Runtime control: EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials" is satisfied, "Img_American National Family of Companies" should exist
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

    # Source step 0011: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-c6f7-9502-916a3bfbd775
    # Runtime control: EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0012: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-9b5e-7ed9-73ebea486f55
    # Runtime control: EQ||Enter Sign On Credentials > Else - if signon page isn't displayed
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Else - if signon page isn't displayed" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0015: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-c1a7-000a-4516a124ab31
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.LastName" in "Txt_Last"
    When I leave "Txt_Date of birth" blank
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I click "Btn_Create New Client"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0016: Enter Account Details | Module: EQ||Account Details
    # Section: Process > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-27bd-f185-b814c8f11db7
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072003463" in "Txt_Best phone_Account Owner"
    When I enter or select "TEST@AOL.COM" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I select "Btn_Married"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.City" in "Txt_owner.address.city_New"
    When I enter or select "CALIFORNIA" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0017: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-8435-461a-922528429375
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{Sendkeys[CALIFORNIA]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_American National Property And Casualty Co."
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0018: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-a4e3-541f-2faf0d0299e1
    When I click "Lnk_USE EXISTING ACCOUNT"
    When I click "<unnamed value>"

    # Source step 0019: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-b53b-e682-9df9ce22040e
    # Runtime control: Proposal Start-UW Popup > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-UW Popup > Condition - If Popup appears" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0020: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-dde8-84c2-a29ad0ca7e31
    # Runtime control: Proposal Start-UW Popup > Then- Click Use existing account
    When if the source runtime condition "Proposal Start-UW Popup > Then- Click Use existing account" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0022: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-e058-0110-f71481c3c4da
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0023: EQ||Tabs - Capturing Quote Number | Module: EQ||Tabs
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-5197-8e55-78dbede99db4
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0024: TBox Set Buffer - Trimming Quote Number | Module: TBox Set Buffer
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-45a9-7ac9-c345d9506b25
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0025: Enter Driver Information - Select Existing Client | Module: EQ||Driver Information
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-d5ed-0d0f-aceba424d49d
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0026: Driver Summary - Enter Driver Details | Module: EQ||Driver Summary
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-98e1-b458-e5782c7a1f82
    When I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    Then I wait until "Txt_totalYearAllStates.value" is visible
    When I enter or select "10" in "Txt_totalYearAllStates.value"
    When I select "Btn_FinancialResponsibility_No"
    When I click "Btn_Save and Continue"

    # Source step 0027: Driver Information - Click Next | Module: EQ||Driver Information Next
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-2a76-7ce6-303e8e2e9f0f
    When I click "Btn_Next"

    # Source step 0028: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-cc84-0e62-f7e9567a778c
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0029: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-8a01-d523-285cf27b8b0f
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0030: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-7d09-c54e-40cfc51cc6cf
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

    # Source step 0031: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-5715-720e-03ca394c4482
    When I click "Btn_1988 Ford E350"
    When I click "Btn_Principal_2"
    When I click "Btn_Next"

    # Source step 0032: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-b47f-68d0-6b2c8c6d6fd7
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0033: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-1e7d-0242-149c4b3e84bd
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0034: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-c781-e603-3a205e943f94
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0035: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-1f87-f16a-ea4ee2fbbdc1
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0036: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-b689-1255-8e97eb2bb1e2
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0037: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-8452-991f-44b77d279332
    When I click "Btn_Next"

    # Source step 0038: Coverages - Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-7d46-bb1c-88d612de2906
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0039: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-700d-b53b-77c15b24bb7c
    When I click "Btn_Next"

    # Source step 0040: TBox Wait | Module: TBox Wait
    # Section: Process > 09 Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0041: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-2682-b55f-4e46978187f8
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0042: Enter Underwriting | Module: <unresolved module>
    # Section: Process > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-393a-de44-ec263c388b19
    When I click "<unnamed value>"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0044: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-0772-b764-77bc55a196a2
    When I click "btn_Next"

    # Source step 0045: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0050: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0051: OpenUrl | Module: OpenUrl
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0055: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0056: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0057: Search Policy Number | Module: EU||Home
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0058: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0059: Click on Pricing | Module: EU||Applicant
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0060: TBox Wait | Module: TBox Wait
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0061: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0063: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0064: TBox Wait | Module: TBox Wait
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0065: Click on Home button | Module: EU||Pricing
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0066: TBox Wait | Module: TBox Wait
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0067: CloseBrowser | Module: CloseBrowser
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0068: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0069: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0070: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0071: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0072: Click on Submission | Module: EQ | Side Menu
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0074: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0075: Click on Submission | Module: EQ | Side Menu
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0076: TBox Wait | Module: TBox Wait
    # Section: Process > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0077: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-71f3-1bcb-f90468d83f56
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0078: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-b785-a025-0c20984d7ea8
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0079: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-e409-a01e-f02abb49f3e9
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0080: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-6b44-ce95-377d1012b7bf
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0081: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-75c3-417b-be69f5840805
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0082: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-14be-c3ec-3a680a833bbd
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0083: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-e8ee-9ab0-b520f9f1407a
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0084: EQ||Submission | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-c3a4-52a6-c110c16a9807
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0085: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-1990-13cd-79a9e3d4eaac
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0086: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-dbea-66b5-77860c444952
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0087: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-7d04-2170-4fef6480a67e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0088: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-6261-4f4a-c5178c395a97
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0089: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-07f0-b247-500d12c8498d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0090: Click Refer to UW | Module: EQ||Submission
    # Section: Process > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-f22e-3527-f1cb09b8a742
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0091: OpenUrl | Module: OpenUrl
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0095: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-644c-dc8d-4a4f1bad8be9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0096: Provide Sign on credentials | Module: EU||Login
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-0dd0-89a3-da6e2ee21899
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0097: EU||Home | Module: EU||Home
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-bcb1-2b91-62b4b70668ad
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0098: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-f8fa-a3cd-21c6d604e2af
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0099: EU||Transact | Module: EU||Transact
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-92b1-dc48-bae85190822b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0100: EU||Transact | Module: EU||Transact
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-36f9-13bc-3419ee0bd63f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0101: EU||Transact | Module: EU||Transact
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-1f2c-5e2d-7db0b9fefd9f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0102: EU||Transact | Module: EU||Transact
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-cb4d-4914-7c2e9f753af1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0103: EU||Applicant | Module: EU||Applicant
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-bdb9-61a2-894856cd262a
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0104: EU||Pricing | Module: EU||Pricing
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-beea-34a4-ce8f69a78b33
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0105: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-aafa-3c36-df8bcf110fa1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0106: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3023-30f3-dc0c-c2a97d92cf00
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0107: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-8acb-292a-d731598b9bf7
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0108: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-f150-f6d8-f6ea317cc1ef
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0109: Launch To Checklist | Module: EQ||Submission
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-1cc1-fae2-e51c46691768
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0111: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-63ad-6b69-f47a43d59e05
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0113: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-7bdb-bb6f-53c92fc8911a
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

    # Source step 0114: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-7b11-358f-15d8474379e0
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0115: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-199a-506a-ebba680a1391
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0116: TBox Save As | Module: TBox Save As
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-bb36-e112-46a9714af55f
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0117: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-4076-ce0f-7b75606f35f8
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0118: TBox Save As_1 | Module: TBox Save As
    # Section: Process > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-f5d7-8eb8-bafdd4892b3e
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0120: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0121: CloseBrowser | Module: CloseBrowser
    # Section: Process > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-c934-7df2-78610e27766f
    When I close the active browser

    # Source step 0122: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-ce90-73d1-729010b562e5
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0123: TBox Wait | Module: TBox Wait
    # Section: Process > 15 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0124: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-f2e8-23fd-d36f2903a8e6
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0125: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-e565-eb4a-69b3c2644991
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0126: Set LOB & State | Module: TBox Set Buffer
    # Section: Process > 16 TDS Validation > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "CA" as runtime value "State"

    # Source step 0136: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Process > 16 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0137: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Process > 16 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0138:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Process > 16 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0139: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-b74b-38e2-3d3f855a4e3e
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0140: Submission - Save & Exit Policy | Module: EQ||Submission
    # Section: Process > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-ecd6-0df7-e1d9ed4b84ba
    When I click "Btn_Save and Exit"

    # Source step 0141: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > 16 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0142: CloseBrowser | Module: CloseBrowser
    # Section: Process > 16 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0143: OpenUrl | Module: OpenUrl
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0147: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-ea5f-b02e-bb417a8d3990
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0148: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-87fa-8390-d3d869ef83b4
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0149: Search Policy | Module: EU||Home
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-1b3f-9aaa-a6afadc15373
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0150: Click Policy holder name | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-0aae-9e02-1f4537aaa733
    When I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0151: Click Transaction Type | Module: EU|Transaction Type
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-25f5-cf4d-6c2ba85d0911
    When I click "expand"
    When I click "Cancel"
    When I click "Go"

    # Source step 0152: Click Transaction Reason & Detailed Reason | Module: Check if Value too High appears
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-b913-a74a-50ac1e67ec03
    When I click "Transaction Reason expand"
    When I click "Underwriting Reasons - Cancellation"
    When I click "Detailed Reason_expand"
    When I click "Claims Review"

    # Source step 0153: Capture Effective and Scheduled Dates | Module: Schedule Dates for Cancellation_Rejection
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-27f1-b6c5-ef8a970f6359
    When I capture "Value" from "Effective Date_1" as runtime value "Cancellation_EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):_1" as runtime value "Cancellation_ScheduledDate"

    # Source step 0154: Set Dates | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-66e4-c117-5b258d3ea048
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]}" as runtime value "ScheduledDate"
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][-25d][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0155: Start PowerShell | Module: TBox Start Program
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-704c-34c7-7dede225a7cf
    And I run program or command "powershell.exe"

    # Source step 0156: Execute PowerShellCommand 1 | Module: TBox Send Keys
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-e7fb-7ea1-3b2ed002ef62
    When I enter or select "*PowerShell*" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\"\"\"\"$TimeSpan=([DateTime]'{B[ScheduledDate]}' - [DateTime]'{B[EffectiveDate]}')\"\"\"\";~" in "Keys"

    # Source step 0157: Execute PowerShellCommand 2  | Module: TBox Send Keys
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-71af-2645-8865f1928b4f
    When I enter or select "*PowerShell*" in "Caption"
    When I enter or select "$TimeSpan | Clip~" in "Keys"

    # Source step 0158: TBox Wait | Module: TBox Wait
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0159: Get Days Difference | Module: TBox Clipboard
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-ce3b-30f4-20c3744a9291
    Then "Value" should equal "Days : {XB[DayDifference]} *"

    # Source step 0160: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-b2d9-9be4-78b56008ad50
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "ScheduledDates"
    And I use TDM parameter "Alias name (item)" with "ScheduledDates"
    And I use TDM parameter "Data search filter > TCName" with "UW Cancellation Auto - CA"
    And I use TDM parameter "Data search filter > State" with "CA"
    And I use TDM parameter "Data search filter > LOB" with "Auto"

    # Source step 0161: Retriving Expected No.of days from TDM | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-7ac2-ab9b-1e4dae1486f2
    When I retrieve and retain the RUNTIME-DERIVED TDM value "ScheduledDates.No of Days Workaround" as runtime value "Expected Days"

    # Source step 0162: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-f198-4945-5579b4c9275e
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Condition
    Then if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[DayDifference]} == {B[Expected Days]}"

    # Source step 0163: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-3097-62bf-597853ff995d
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Then
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Then" is satisfied, I retain hard-coded value "The Actual No.of Days is equal to Expected No.of Days" as runtime value "No.of Days Equal"

    # Source step 0164: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-20bd-4b04-c766bb604b48
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Else
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Else" is satisfied, I retain hard-coded value "The Actaul No.of Days are not equal to Expected No.of Days" as runtime value "No.of Days not Equal"

    # Source step 0166: Select  & Cick Schedule | Module: EU|Schedule
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-219d-f3ff-58cd97777490
    When I enter or select "True" in "MVR_1"
    When I click "Schedule"

    # Source step 0167: TBox Wait | Module: TBox Wait
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-8f40-a824-7424d2658a4a
    When I wait "5000" milliseconds

    # Source step 0168: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3031-db64-75a5-72a0568339d3
    When I close the active browser

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
# 5. Source step 0013 "Client Selection-Enter Client Info of New or Exisiting Clients" in module "EQ || Client Selection" was disabled. Reason: 01.06.24 14:50:24 [ct2634]
#    - VERIFY "Lbl_Client Info" with "True"
#    - VERIFY "Lbl_Client Info" with "Client Info"
#    - VERIFY "Lbl_New/Existing Client Search" with "True"
#    - VERIFY "Lbl_New/Existing Client Search" with "New/Existing Client Search"
#    - INPUT "Txt_First" with "{Invoke[Click]}{SENDKEYS[Allen]}"
#    - INPUT "Txt_Last" with "Pagliaro"
#    - INPUT "Txt_Date of birth" with a blank value
#    - INPUT "Txt_Best phone" with a blank value
#    - INPUT "Txt_Email address" with a blank value
#    - VERIFY "Btn_Search" with "True"
#    - INPUT "Btn_Search" with "X"
#    - VERIFY "Btn_Create New Client" with "Create New Client"
#    - INPUT "Btn_Create New Client" with "X"
#    - VERIFY "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 6. Source step 0014 "Account Details-Enter new Account Information" in module "EQ||Account Details" was disabled. Reason: 01.06.24 14:50:24 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with "3/12/1972"
#    - INPUT "Txt_Best phone_Account Owner" with "9072000754"
#    - INPUT "Txt_Email_Account Owner" with "ALLENPAGLIARO0221@COMCAST.NET"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Txt_Enter a location" with "CRESCENT DR"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with "BEVERLY HILLS"
#    - INPUT "Drpdwn_State" with "CALIFORNIA"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with "902120000"
#    - INPUT "Txt_owner.address.county" with "Aztec"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 7. Source step 0016 field "Btn_Single" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0016 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0016 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 10. Source step 0016 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 11. Source step 0017 field "Drp List_List Auto Writing Company" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0017 field "Drp List_List Auto Writing Company" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{Sendkeys[American National Property And Casualty Co.]}"
# 13. Source step 0017 field "Drp List_State" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{Sendkeys[CALIFORNIA]}"
# 14. Source step 0017 field "Rd Btn_Same as NewAccountAddress" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "X"
# 15. Source step 0017 field "Rd Btn_Same as NewAccountAddress" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "X"
# 16. Source step 0018 field "Txt_SSN" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "666356409"
# 17. Source step 0018 field "Lnk_SUBMIT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0021 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 19. Source step 0022 field "Lnk_CLOSE QUOTE" in "PreQualification-Select Client & Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0025 field "Btn_(Existing Client)*" in "Enter Driver Information - Select Existing Client" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0028 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0028 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 23. Source step 0029 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0030 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0030 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 26. Source step 0030 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 27. Source step 0030 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0030 field "Btn_Cycle_Customizatioin_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0030 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 30. Source step 0030 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0030 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0030 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 33. Source step 0030 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 34. Source step 0030 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0031 field "Btn_VehSelect" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0031 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 37. Source step 0031 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0031 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0031 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0031 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 41. Source step 0031 field "Btn_Vehicle_Select" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 42. Source step 0031 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0031 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 44. Source step 0031 field "Btn_Principal_New" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0031 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0031 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 47. Source step 0032 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0037 field "Btn_SafeCycle_Yes_D1" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0037 field "Txt_safeCycleDiscountDate_D1" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "10/10/2000"
# 50. Source step 0037 field "Btn_D1_No" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0037 field "Hdr_Discounts page" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 52. Source step 0038 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 53. Source step 0038 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 54. Source step 0038 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0038 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0038 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0044 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 58. Source step 0044 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0044 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0046 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 61. Source step 0047 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 62. Source step 0048 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 63. Source step 0049 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 64. Source step 0052 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 65. Source step 0053 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 66. Source step 0054 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 67. Source step 0092 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 68. Source step 0093 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 69. Source step 0094 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 70. Source step 0110 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 71. Source step 0111 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 72. Source step 0111 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 73. Source step 0111 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 74. Source step 0112 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 75. Source step 0114 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 76. Source step 0119 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 77. Source step 0124 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0124 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 79. Source step 0124 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0127 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 81. Source step 0128 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 82. Source step 0129 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 83. Source step 0130 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 84. Source step 0131 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 85. Source step 0132 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 86. Source step 0133 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 87. Source step 0134 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 88. Source step 0135 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 89. Source step 0144 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 90. Source step 0145 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 91. Source step 0146 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 92. Source step 0165 "Close Cancel Page" in module "Check if Value too High appears" was disabled. Reason: 13.06.24 19:09:07 [ct2634]
#    - INPUT "Exit Without Saving" with "X"
# 93. Source step 0169 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 19.02.24 14:13:32 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 94. Source step 0170 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 19.02.24 14:13:32 [ct2634]
#    - INPUT "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with "Auto - TC03_Mega Rec Veh Policy 02_NM"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "NM"
# 95. Source step 0171 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 19.02.24 14:13:32 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 96. Source step 0172 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 97. Source step 0173 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 19.02.24 14:13:32 [ct2634]
#    - INPUT "Title" with "ExpertQuote*"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0174 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 2. Source recovery step 0175 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 3. Source recovery step 0176 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 4. Source recovery step 0177 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 5. Source recovery step 0178 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 6. Source recovery step 0179 CloseBrowser: I close the active browser
