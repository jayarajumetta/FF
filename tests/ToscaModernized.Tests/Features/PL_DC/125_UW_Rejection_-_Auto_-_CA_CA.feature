# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 125_UW_Rejection_-_Auto_-_CA_CA.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @rejection @California @Edge @manual @archive @automated
Feature: Execute UW Rejection - Auto - CA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Rejection - Auto - CA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Rejection - Auto - CA using representative iteration California (CA)
    # Source step 0009: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-0088-ebbf-781b563948bf
    # Runtime control: EQ||Enter Sign On Credentials > Condition - if signon page is displayed
    Given if the source runtime condition "EQ||Enter Sign On Credentials > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0010: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-9dd6-f4f8-cef792093347
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
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-45ea-9a7b-ad377dcc463f
    # Runtime control: EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0012: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-4d92-e026-dd062428fa90
    # Runtime control: EQ||Enter Sign On Credentials > Else - if signon page isn't displayed
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Else - if signon page isn't displayed" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0015: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-0cc8-2a4f-0ed8fd2036b3
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
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-3204-96cf-7e48b3b9df25
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
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-310d-4ae4-4c83-b4c605e3ee9a
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
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-deb9-bc21-86f01728b2f5
    When I click "Lnk_USE EXISTING ACCOUNT"
    When I click "<unnamed value>"

    # Source step 0019: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-9984-52f1-e6da5b27bfa8
    # Runtime control: Proposal Start-UW Popup > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-UW Popup > Condition - If Popup appears" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0020: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-5f7c-4b24-4651b87d6909
    # Runtime control: Proposal Start-UW Popup > Then- Click Use existing account
    When if the source runtime condition "Proposal Start-UW Popup > Then- Click Use existing account" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0022: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-38bb-c525-81d725d39e6c
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0023: EQ||Tabs - Capturing Quote Number | Module: EQ||Tabs
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-59c0-b275-7e7c5b5fba4d
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0024: TBox Set Buffer - Trimming Quote Number | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-7686-5fd4-26ac4a29f381
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0025: Enter Driver Information - Select Existing Client | Module: EQ||Driver Information
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-d501-42aa-fe3bc3d1d294
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0026: Driver Summary - Enter Driver Details | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-1d0c-c7ea-ef6fde5f92b7
    When I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    Then I wait until "Txt_totalYearAllStates.value" is visible
    When I enter or select "10" in "Txt_totalYearAllStates.value"
    When I select "Btn_FinancialResponsibility_No"
    When I click "Btn_Save and Continue"

    # Source step 0031: Driver Information - Click Next | Module: EQ||Driver Information Next
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-93b7-bf02-cd6ab68dbd3f
    When I click "Btn_Next"

    # Source step 0032: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-ec8f-e484-c0d373111a8c
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0033: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-b586-19ed-04c438e9f384
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0034: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-a689-1272-3b5079afb607
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

    # Source step 0035: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3117-f148-494f-d0f9f1dd310c
    When I click "Btn_1988 Ford E350"
    When I click "Btn_Principal_2"
    When I click "Btn_Next"

    # Source step 0036: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311d-725e-f32f-1cdd4cfa5357
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0037: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311d-a0f3-28fb-166a7acdcad6
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0038: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311d-9ddd-e2b0-3231bfa20302
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0039: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311d-0781-47f8-ee607843b0ee
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0040: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311d-bebe-ed69-c081b0f93373
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0041: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311d-c763-faf5-3d7033e20383
    When I click "Btn_Next"

    # Source step 0042: Coverages - Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-37b3-12f0-f542958ab4c1
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0043: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-4e20-3219-7210fd35bf57
    When I click "Btn_Next"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0045: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-84b9-4710-3e912b3e1b44
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0046: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-f37a-9cd2-93f98beefe64
    When I click "<unnamed value>"

    # Source step 0047: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0048: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-55fc-a08b-44900ccd3ae3
    When I click "btn_Next"

    # Source step 0049: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0054: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0055: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0059: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0060: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0061: Search Policy Number | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0062: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0063: Click on Pricing | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0064: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0065: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0066: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0067: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0069: Click on Home button | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0071: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0072: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0073: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0074: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0075: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0076: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0078: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0079: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0080: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0081: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-636a-b83d-e39be9afb62c
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0082: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-0d97-8481-eeca1cfd44e8
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0083: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-aad7-4f82-4b1862000651
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0084: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-3aef-ce61-33e35415f665
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0085: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-609e-4b9e-9eb05d8d6f1d
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0086: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-db80-3d7c-01430ee981fc
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0087: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-c988-2db8-54560d688e19
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0088: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-3ce6-16c4-39eb25539f66
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0089: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-a267-02bf-6d728c39b857
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0090: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-78b4-9f48-0b3e888d79c9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0091: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-0d5d-dac9-cf098e15631f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0092: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-2faa-2f41-2200f8009b03
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0093: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-0aeb-ebfd-1a9fd9db2705
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0094: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-a5c0-28a2-91f03e95cf90
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0095: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0099: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-647c-c7e1-d21e08991411
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0100: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-9210-17ac-6fa032e9d4ac
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0101: EU||Home | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-42db-210d-229b8bd4b0f3
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0102: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-909c-11ee-487b1a8976b9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0103: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-b813-0c4a-74705d28dceb
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0104: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-1ebf-b99d-b5001b8424c5
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0105: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-f2a7-c4ee-1073144c4883
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0106: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-01db-6d0e-4aed5f84eed4
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0107: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-ac76-e7d9-6a56efea337d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0108: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-41d0-2fd6-632f1a94a3f4
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0109: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-aace-c818-3ac6d45a5946
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0110: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-b44e-ffd9-6e10057cc4bc
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0111: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-867a-0c4e-cfc740699532
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0112: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-9cd0-e792-19ab060db38b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0113: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-f973-e603-5824710383a0
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0115: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-8e67-7a97-578bf50d24a1
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0117: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-6666-5bd2-2c328396df21
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

    # Source step 0118: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-a5ad-eb96-00ce238ced6a
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0119: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-2620-67a6-275f6c067772
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0120: TBox Save As | Module: TBox Save As
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-1dd1-e8f5-49a2fbcc7220
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0121: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-56e1-fe70-fbdf4fd7c4df
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0122: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Auto Policy > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-5c63-9ce9-d23f57b6787c
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0124: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0125: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-816e-e0bd-5f3803335de5
    When I close the active browser

    # Source step 0126: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Auto Policy > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-c08b-2926-0997be229100
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0127: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 15 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0128: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-360e-bef6-88653d2c3265
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0129: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-fa27-6a18-ae6b059abf5d
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0143: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-7420-0552-c586e732c931
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0144: Submission - Save & Exit Policy | Module: EQ||Submission
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-20d7-133a-40b158a2b07c
    When I click "Btn_Save and Exit"

    # Source step 0145: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0146: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0147: OpenUrl | Module: OpenUrl
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0151: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-7123-3190-3933772d8975
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0152: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-9dcc-45d0-e09cd4af4106
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0153: Search Policy | Module: EU||Home
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-7682-49f9-840041548d03
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0154: Click Policy holder name | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-3393-78cd-444db380cd47
    When I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0155: Click Transaction Type | Module: EU|Transaction Type
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-f2a7-167f-958fc1082944
    When I click "expand"
    When I click "Cancel"
    When I click "Go"

    # Source step 0156: Click Transaction Reason & Detailed Reason | Module: Check if Value too High appears
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-13b4-6dac-03bd265370c6
    When I click "Transaction Reason expand"
    When I click "Underwriting Reasons - Rejection"
    When I click "Detailed Reason_expand"
    When I click "Claims Review"

    # Source step 0157: Capture Effective and Scheduled Dates | Module: Schedule Dates for Cancellation_Rejection
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-3937-96ba-5748164ca2e2
    When I enter the RUNTIME-DERIVED date from Tosca expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{DATE[][][MM/dd/yyyy]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0158: TBox Wait | Module: TBox Wait
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-82db-092f-7b6086b81306
    When I wait "10000" milliseconds

    # Source step 0159: Capture Effective and Scheduled Dates | Module: Schedule Dates for Cancellation_Rejection
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-b852-20b3-1cb52f673ef6
    When I capture "Value" from "Effective Date_1" as runtime value "Cancellation_EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):_1" as runtime value "Cancellation_ScheduledDate"

    # Source step 0160: Set Dates | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-66e4-c117-5b258d3ea048
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]}" as runtime value "ScheduledDate"
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][-25d][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0161: Start PowerShell | Module: TBox Start Program
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-704c-34c7-7dede225a7cf
    And I run program or command "powershell.exe"

    # Source step 0162: Execute PowerShellCommand 1 | Module: TBox Send Keys
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-e7fb-7ea1-3b2ed002ef62
    When I enter or select "*PowerShell*" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\"\"\"\"$TimeSpan=([DateTime]'{B[ScheduledDate]}' - [DateTime]'{B[EffectiveDate]}')\"\"\"\";~" in "Keys"

    # Source step 0163: Execute PowerShellCommand 2  | Module: TBox Send Keys
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-71af-2645-8865f1928b4f
    When I enter or select "*PowerShell*" in "Caption"
    When I enter or select "$TimeSpan | Clip~" in "Keys"

    # Source step 0164: TBox Wait | Module: TBox Wait
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0165: Get Days Difference | Module: TBox Clipboard
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-ce3b-30f4-20c3744a9291
    Then "Value" should equal "Days : {XB[DayDifference]} *"

    # Source step 0166: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-b2d9-9be4-78b56008ad50
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "ScheduledDates"
    And I use TDM parameter "Alias name (item)" with "ScheduledDates"
    And I use TDM parameter "Data search filter > TCName" with "UW Rejection - Auto - CA"
    And I use TDM parameter "Data search filter > State" with "CA"
    And I use TDM parameter "Data search filter > LOB" with "Auto"

    # Source step 0167: Retriving Expected No.of days from TDM | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-7ac2-ab9b-1e4dae1486f2
    When I retrieve and retain the RUNTIME-DERIVED TDM value "ScheduledDates.No of Days Workaround" as runtime value "Expected Days"

    # Source step 0168: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-f198-4945-5579b4c9275e
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Condition
    Then if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[DayDifference]} == {B[Expected Days]}"

    # Source step 0169: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-3097-62bf-597853ff995d
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Then
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Then" is satisfied, I retain hard-coded value "The Actual No.of Days is equal to Expected No.of Days" as runtime value "No.of Days Equal"

    # Source step 0170: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-20bd-4b04-c766bb604b48
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Else
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Else" is satisfied, I retain hard-coded value "The Actaul No.of Days are not equal to Expected No.of Days" as runtime value "No.of Days not Equal"

    # Source step 0172: Select  & Cick Schedule | Module: EU|Schedule
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-707f-5ab5-3dc1408b1942
    When I enter or select "True" in "MVR_1"
    When I click "Schedule"

    # Source step 0173: TBox Wait | Module: TBox Wait
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-46f0-dd71-7e48b0f0609e
    When I wait "5000" milliseconds

    # Source step 0174: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-311f-c63f-372f-66a290108917
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
# 5. Source step 0013 "Client Selection-Enter Client Info of New or Exisiting Clients" in module "EQ || Client Selection" was disabled. Reason: 01.06.24 15:20:21 [ct2634]
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
# 6. Source step 0014 "Account Details-Enter new Account Information" in module "EQ||Account Details" was disabled. Reason: 01.06.24 15:20:21 [ct2634]
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
# 21. Source step 0027 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.06.24 11:41:48 [ct2634]
#    - VERIFY "Prior Insurance_Checked_Yes" with "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"
# 22. Source step 0028 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.06.24 11:41:48 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - INPUT "Btn_Assigned" with "X"
#    - WAIT "Txt_DL Number" with "True"
#    - INPUT "Txt_DL Number" with "{Invoke[Click]}{SENDKEYS[885502570]}"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "{Click}{Sendkeys[14]}"
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
#    - INPUT "Btn_priorPolicyNumber" with "{Invoke[Click]}{SENDKEYS[730927358002]}"
#    - WAIT "Btn_yearsWithPriorCarrier" with "True"
#    - INPUT "Btn_yearsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_yearsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[1]}"
#    - WAIT "Btn_monthsWithPriorCarrier" with "True"
#    - INPUT "Btn_monthsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_monthsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[0]}"
#    - INPUT "Btn_Did Not Have Insurance" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 23. Source step 0029 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.06.24 11:41:48 [ct2634]
#    - VERIFY "Prior Insurance_Unchecked_Yes" with "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"
# 24. Source step 0030 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 18.06.24 11:41:48 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - INPUT "Btn_Assigned" with "X"
#    - WAIT "Txt_DL Number" with "True"
#    - INPUT "Txt_DL Number" with "{Invoke[Click]}{SENDKEYS[885502570]}"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "{Click}{Sendkeys[14]}"
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
#    - INPUT "Btn_priorPolicyNumber" with "{Invoke[Click]}{SENDKEYS[730927358002]}"
#    - WAIT "Btn_yearsWithPriorCarrier" with "True"
#    - INPUT "Btn_yearsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_yearsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[1]}"
#    - WAIT "Btn_monthsWithPriorCarrier" with "True"
#    - INPUT "Btn_monthsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_monthsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[0]}"
#    - INPUT "Btn_Did Not Have Insurance" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 25. Source step 0032 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0032 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0033 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0034 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0034 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0034 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 31. Source step 0034 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0034 field "Btn_Cycle_Customizatioin_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0034 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 34. Source step 0034 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0034 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0034 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 37. Source step 0034 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 38. Source step 0034 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0035 field "Btn_VehSelect" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 40. Source step 0035 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 41. Source step 0035 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0035 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 43. Source step 0035 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0035 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0035 field "Btn_Vehicle_Select" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0035 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0035 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 48. Source step 0035 field "Btn_Principal_New" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0035 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0035 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 51. Source step 0036 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0041 field "Btn_SafeCycle_Yes_D1" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0041 field "Txt_safeCycleDiscountDate_D1" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "10/10/2000"
# 54. Source step 0041 field "Btn_D1_No" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0041 field "Hdr_Discounts page" in "Discounts - Enter Discounts & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 56. Source step 0042 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 57. Source step 0042 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 58. Source step 0042 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 59. Source step 0042 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0042 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 61. Source step 0048 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 62. Source step 0048 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0048 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0050 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 65. Source step 0051 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 66. Source step 0052 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 67. Source step 0053 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 68. Source step 0056 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 69. Source step 0057 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 70. Source step 0058 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 71. Source step 0096 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 72. Source step 0097 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 73. Source step 0098 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 74. Source step 0114 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 75. Source step 0115 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 76. Source step 0115 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 77. Source step 0115 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 78. Source step 0116 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 79. Source step 0118 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 80. Source step 0123 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 81. Source step 0128 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0128 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 83. Source step 0128 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0130 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "LOB" with "Auto"
#    - INPUT "State" with "NM"
# 85. Source step 0131 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 86. Source step 0132 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 87. Source step 0133 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 88. Source step 0134 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 89. Source step 0135 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 90. Source step 0136 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 91. Source step 0137 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 92. Source step 0138 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 93. Source step 0139 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 94. Source step 0140 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 95. Source step 0141 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 96. Source step 0142 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
# 97. Source step 0148 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 98. Source step 0149 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 99. Source step 0150 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 100. Source step 0171 "Close Cancel Page" in module "Check if Value too High appears" was disabled. Reason: 13.06.24 19:13:40 [ct2634]
#    - INPUT "Exit Without Saving" with "X"
# 101. Source step 0175 "Click on Transmit Button" in module "EQ||Submission" was disabled. Reason: 31.05.24 09:51:01 [ct2634]
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 102. Source step 0176 "Buffer Tranmit Premiums" in module "EQ||Submission" was disabled. Reason: 31.05.24 09:51:01 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - BUFFER "Lbl_Policy Number" with "Policy Number"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 103. Source step 0177 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 31.05.24 09:51:01 [ct2634]
#    - INPUT "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with "TC10 UW Rejection Cycle_NM"
#    - INPUT "Data structure > Endorsement" with "N"
# 104. Source step 0178 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 31.05.24 09:51:01 [ct2634]
#    - INPUT "Title" with "ExpertQuote*"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0179 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\UW Rejection Cycle_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0180 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0181 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0182 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0183 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\UW Rejection Cycle_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0184 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0185 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0186 CloseBrowser: I close the active browser
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 9. Source recovery step 0187 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 10. Source recovery step 0188 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 11. Source recovery step 0189 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 12. Source recovery step 0190 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EQ sign out and Close browser
# 13. Source recovery step 0191 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 14. Source recovery step 0192 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 15. Source recovery step 0193 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 16. Source recovery step 0194 CloseBrowser: I close the active browser
