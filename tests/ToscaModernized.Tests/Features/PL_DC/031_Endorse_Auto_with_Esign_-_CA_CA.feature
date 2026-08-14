# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 031_Endorse_Auto_with_Esign_-_CA_CA.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @California @Edge @manual @archive @automated
Feature: Execute Endorse Auto with Esign - CA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse Auto with Esign - CA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse Auto with Esign - CA using representative iteration California (CA)
    # Source step 0030: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-87c9-cbaf-8f9f6f51a019
    Given "Lbl_Client Info" should exist
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
    When I click "Btn_Next"

    # Source step 0031: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-6fc8-76b6-dda4dbe47a67
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072295245" in "Txt_Best phone_Account Owner"
    When I enter or select "TONYARALPHJENKINS0804@ATT.NET" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I click "Btn_Single"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    Then I wait until "Txt_Enter a location" exists
    When I enter or select "{click}{down}" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.City" in "Txt_owner.address.city_New"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0032: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-4748-ae1e-17f29af1e58f
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{Sendkeys[CALIFORNIA]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Writing Company" is visible
    When I select "Drp_Writing Company"
    When I click "Lbl_American National Property And Casualty Co."
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0033: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-cbf5-9e22-1787b85760f5
    When I click "Lnk_USE EXISTING ACCOUNT"
    When I click "<unnamed value>"

    # Source step 0034: Verify if popup is visible | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-96b2-7293-ac74b6d5937f
    # Runtime control: Proposal Start-UW Popup > Verify if popup is visible
    Then if the source runtime condition "Proposal Start-UW Popup > Verify if popup is visible" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0035: Click Existing Account button | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-6fb3-cea9-3417bb812563
    # Runtime control: Proposal Start-UW Popup > Click Existing Account button
    When if the source runtime condition "Proposal Start-UW Popup > Click Existing Account button" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0036: EQ||Tabs - Capturing Quote number | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-fcd0-12f5-d83d2c0ddd66
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0037: TBox Set Buffer  -Trimming Quote Number | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-6f82-9b4e-93af4276dd7c
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0038: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-559a-6cca-2fa09b7bd403
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0039: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-3159-7627-cb85b30de98e
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0040: Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-08d6-fa64-5a233292d99d
    When I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    Then I wait until "Txt_totalYearAllStates.value" is visible
    When I enter or select "10" in "Txt_totalYearAllStates.value"
    When I select "Btn_FinancialResponsibility_No"
    When I click "Btn_Save and Continue"

    # Source step 0041: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-4cb4-9170-92f3cc5a2c5b
    When I click "Btn_Next"

    # Source step 0042: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-606b-2bfb-114d717ff079
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0043: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-b709-9bcd-c732d9f96021
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle 
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0044: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-5cff-9ca5-87bda4d75b19
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "1FDKE30G9JHA64433" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    When I select "Btn_More Options_Vehicle Type_new"
    When I click "Btn_Pleasure Use"
    When I leave "Btn_More Options_Vehicle Type" blank
    When I select "Btn_Named Non-Owned_Vehicle Type_New"
    When I click "Btn_Save and Continue"
    When I click "Lnk_UW_CONTINUE"
    When I click "Btn_Opt Out"
    When I click "Btn_Next"

    # Source step 0045: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-4eb1-5c40-c7d2707c8984
    When I click "Btn_Vehicle_Select"
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0046: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-a57a-7ab0-e20339de5bbc
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0047: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-d4b7-1dc3-38a35f3f5e55
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0048: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-977e-4097-8bf102d23d0d
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0049: Verify If claim page is visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-606e-5ea2-929a70621378
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Verify If claim page is visible
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Verify If claim page is visible" is satisfied, "Hdr_Claims" should exist

    # Source step 0050: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-7ea4-9087-c0db4f1dd73c
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Click on Next
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Click on Next" is satisfied, I click "Btn_Next"

    # Source step 0051: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-3c7d-88db-d43dca8c4ff6
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0052: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-d41e-0e94-7016291f71d2
    # Runtime control: Discounts-Review Discounts & Continue > Condition
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Condition" is satisfied, "Hdr_Discounts / Adjustments" should exist
    Then "Btn_D1_No" should be visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0053: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-4016-e676-7e58cbd0e518
    # Runtime control: Discounts-Review Discounts & Continue > Then
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Then" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    When I select "Btn_No Proof of Prior Insurance"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0054: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-8acd-42aa-89292ee660cb
    # Runtime control: Discounts-Review Discounts & Continue > Else
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Else" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0055: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-37de-49b6-ddf6bc8709f3
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0056: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-fc6f-f0b4-e585832fd940
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0057: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2669-d49f-bc7f-aaf32877bd8c
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"

    # Source step 0058: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2678-9132-e8d8-d9530fb782d2
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-e4c7-8b1b-a6cb73ba9bb7
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0060: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-89a0-f207-c3ccc67f0595
    When I click "Btn_Next"

    # Source step 0061: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-2f85-cd33-8fce39f8b324
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-e81c-60c2-47989d58aca7
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0063: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-7f96-43e5-c295b3033612
    Then I wait until "Hdr_Pricing Details_Header" is visible
    When I click "Btn_Next"

    # Source step 0064: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-2a82-e62d-e65e032a64c6
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0065: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-4ae4-3e64-55b6ebfaaf35
    Then I wait until "Hdr_Additional Interest Summary" is visible
    When I click "btn_Next"

    # Source step 0066: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Generating Auto Policy > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0071: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0072: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0076: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0077: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0078: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0079: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0080: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0082: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0084: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0086: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0088: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0089: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0090: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0091: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0092: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0093: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0095: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0096: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0097: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0098: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-d4fc-b1c5-ab7a6402ebf8
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0099: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-1b58-2118-c5ebda296502
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0100: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-5c98-eefa-8f64ffe22a0c
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0101: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9967-2cac-f7795b43fd3c
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0102: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-471c-6d5e-9e7da1fc734e
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0103: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-2e24-fcce-2669e3470727
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0104: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-03ae-0110-2c41a0eb66b6
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0105: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-37ce-02fd-727ffbabca06
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0106: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0110: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0111: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0112: EU||Home | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0113: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0114: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0115: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0116: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0117: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0120: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0121: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-e0c8-6c81-964bd6d13911
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0122: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-92b7-bbc0-8fa01905c230
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0123: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-77b5-ff3b-949c875ea625
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0124: Verify if Launch Esign is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-959b-bf28-762e12f6e960
    # Runtime control: Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible
    Then if the source runtime condition "Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible" is satisfied, "Btn_Launch To eSignature" should be visible

    # Source step 0125: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-bd3d-6954-e5861e9fa3e3
    # Runtime control: Load till Launch Esign is visible [max=30] > Wait 
    When if the source runtime condition "Load till Launch Esign is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0126: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-70c7-207d-1c96f5226be0
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0127: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-6e29-86ed-713e8dad52a9
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0128: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-226f-598f-171e44437396
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

    # Source step 0129: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0130: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-30cc-366a-5857df6c9fae
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0131: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-ce6f-79dc-c651db84b757
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0132: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-6dbe-d14e-b8072339d77f
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0133: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-579c-fbcc-fff78377e708
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0134: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9095-f1c3-cd61188f9e27
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0135: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9317-d5e6-7191a6014dc9
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0136: Open Url | Module: Open Url_ARA
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-b787-c45c-b8413a83d535
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0137: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-ebfc-23ed-7aa146f07dd2
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0138: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-8ec7-367f-8cac10aa38eb
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0139: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9b91-b892-8634905d83ad
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0140: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-68b6-dfdb-72c9532f923b
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0141: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-dfa0-ba9b-1828bcdc20bd
    When I wait "6000" milliseconds

    # Source step 0142: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9fd5-f887-901d43c1d924
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0143: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-a50f-9392-f601e7330bfa
    When I click "e-SignLive"

    # Source step 0144: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-ec98-ae37-8f9592d906bb
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0145: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-0d6e-2d4f-ab7f430fe8bf
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0146: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-b2b4-af6f-2bc623f77c80
    When I close the active browser

    # Source step 0147: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-ad24-0ab6-392b5832afb5
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0148: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-d493-386f-e0d0666f06dc
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0149: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0150: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-0057-06e5-e8d2e3d2ffb4
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0151: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-5bbf-a0f5-a9e1f7c539d4
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0152: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-b872-ed9c-76fbbefb41f1
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0153:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-6c93-99e1-993757952487
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0154: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-47e7-3435-7236056f6ba5
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0155: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0156: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0157: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-c075-f20b-e33c6a6179fd
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0158: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-eee5-8588-edbe530a5c8e
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0159: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-b09c-78fb-d4df1ea41306
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0160: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-6fe8-5406-3ef24067dba0
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0161: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-8798-a1d8-0432778b384b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0162: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-1c9a-531b-82307eadee73
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0163:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-3938-183c-c16cb32e6494
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0164: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-320e-e83e-717bfe7a564f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0165: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0166: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0167: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-871d-c160-fea637403ebd
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0168: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0169: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-e215-788f-ec8dc07b1437
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0170: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9794-cfa7-3eb7e9fad87d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0171: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-d194-2500-8428faab82c4
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0172:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-51d3-3170-c831935d33d8
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0173: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-794e-5b77-1a573c70b853
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0174: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0175: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0176: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-d02f-035d-d0253803e497
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0177: Launch Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-d253-1a18-572019c28f5a
    Then I wait until "Btn_Launch To Checklist" is visible
    When I click "Btn_Launch To Checklist"

    # Source step 0180: CloseBrowser-Close the Echecklist browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-b65a-aa01-8bd32052cebc
    When I close the active browser

    # Source step 0181: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-63de-3783-9846ef1dcc8a
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0182: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-02e4-8644-8430fadc5a39
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0183: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-993b-e9d6-506cfcf91fdb
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0184: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-e03e-c763-ce770412dc3c
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Auto with Esign - CA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0185: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-9e2f-9970-906ea964826f
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Auto with Esign - CA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0186: Click save and exit | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2679-618d-97b8-fb5e972071b4
    When I click "Btn_Save and Exit"

    # Source step 0187: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0188: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-c8cf-226f-3461527f3620
    When I close the active browser

    # Source step 0189: OpenUrl | Module: OpenUrl_old
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-8942-2c8d-f3eb2360ce4e
    When I open "https://expertquote-qa.americannational.com/expertquote/#/quote"

    # Source step 0190: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-283a-9af9-8a884d268f96
    # Runtime control: Wait for Login Page [max=30] > Condition
    Then if the source runtime condition "Wait for Login Page [max=30] > Condition" is satisfied, "Txt_Username" should exist

    # Source step 0191: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Login Page [max=30] > Loop
    When if the source runtime condition "Wait for Login Page [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0192: Maximize Window | Module: TBox Window Operation
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-9a63-313c-d04b690d27b6
    When I enter or select "*Sign On*" in "Caption"
    When I enter or select "Maximize" in "Operation"

    # Source step 0193: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-6f7c-e4d8-6c2bb24c7913
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0194: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-e9b3-a01d-ef711409a356
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0195: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-6070-68e7-cd8484b0564f
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0196: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-7f91-cc5f-a3f440b5de7b
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0197: If Recall quote/policy is visible | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-e635-c849-25f2e91297f5
    # Runtime control: Recall quote/policy is visible > Verify if Recall quote/policy is visible
    Then if the source runtime condition "Recall quote/policy is visible > Verify if Recall quote/policy is visible" is satisfied, "Txt_Quote\\Policy Search" should be visible

    # Source step 0198: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-1509-6b07-a35c0688b54d
    # Runtime control: Recall quote/policy is visible > Recall Quote\Policy
    When if the source runtime condition "Recall quote/policy is visible > Recall Quote\\Policy" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0199: Quick Actions | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-e167-07c1-b119fe7ffcd1
    When I click "Btn_+ CREATE NEW POLICY CHANGE"
    When I enter or select "{CLICK}{SENDKEYS[Endorse Coverage Limit]}" in "Txt_Policy Change Field"
    When I click "Btn_OK"

    # Source step 0200: Click on Coverages | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2688-7525-a803-f2c369e7b70d
    When I click "Coverages"

    # Source step 0201: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0202: Select Lower Cverage BI/PD | Module: <unresolved module>
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-6edc-05f7-ba0a7d47bf96
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0203: Click on Discount page | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-0bf4-5ae6-bbd030be2a36
    When I click "Discounts / Adjustments"

    # Source step 0204: Select Auto-Home Discount | Module: EQ||Discounts\Adjustments
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-7cd8-2d1d-cbdde6258afd
    Then I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_check_box_Auto-Home" is visible
    When I click "Btn_check_box_Auto-Home"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0205: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-ed53-1942-fb20b2cdf81a
    When I click "Submission"

    # Source step 0206: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0207: Verify XX0600 rulefire | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-7cd0-991d-15dd3432cc1e
    Then "XX0600" should equal "XX0600"
    Then "You have manually added the Auto Home, discount. Please remove in order to proceed with binding." should equal "You have manually added the Auto Home, discount. Please remove in order to proceed with binding."

    # Source step 0208: Click on Discount page | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-eb50-4af3-fd1696d6f5ac
    When I click "Discounts / Adjustments"

    # Source step 0209: Remove Auto-Home Discount | Module: EQ||Discounts\Adjustments
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-fff8-41be-3dd745cfe60b
    Then I wait until "Hdr_Discounts / Adjustments" exists
    When I click "Btn_Uncheck_box_Auto-Home"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0210: Click on submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-268a-8da3-c42b-835c66092a8b
    When I click "Submission"

    # Source step 0263: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-241a-c54b-78503b361155
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0265: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-b9f1-807c-d083119bf340
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0267: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-d885-1433-e5a21b39efad
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

    # Source step 0268: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-2221-2585-fe6d86798106
    When I click "CA Mileage Opt Out Form"

    # Source step 0269: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-6af6-7fce-53617200d80d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0270: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-70d8-3349-1c33a9b4d656
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0271: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-6bd5-8687-da8c47d9a1d2
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0272: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-6d33-1ff5-f78bcf839979
    When I close the active browser

    # Source step 0273: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-c332-cf05-a385ab38136c
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0274: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-96df-6f2c-375d1b2e9b88
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0275: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-6f00-2f02-22628005de87
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0276: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-0c91-36c1-5ed4b59d89f6
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Auto with Esign - CA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0277: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2698-a888-6872-ab9f9a6cebd7
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Auto with Esign - CA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "CA"

    # Source step 0278: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "CA" as runtime value "State"

    # Source step 0288: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0289: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0290:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0291: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0292: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0024 field "Alias name (item)" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "CA_ClientData_Regression"
# 2. Source step 0030 field "Btn_Next" in "Client Selection-Enter Client Info of New or Exisiting Clients" was disabled. Reason:  
#    - Preserved source value: "True"
# 3. Source step 0031 field "Txt_owner.address.zip" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED TDM value "CA_ClientData_Regression.Zip"
# 4. Source step 0031 field "Txt_owner.address.county" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "Aztec"
# 5. Source step 0031 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0032 field "Rd Btn_Same as NewAccountAddress" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "X"
# 7. Source step 0032 field "Rd Btn_Same as NewAccountAddress" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "X"
# 8. Source step 0033 field "Txt_SSN" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "666356409"
# 9. Source step 0033 field "Lnk_SUBMIT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0038 field "Hdr_Message_Additional Documentation Required" in "PreQualification-Select Client & Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0038 field "Hdr_Message_Provide the documentation below" in "PreQualification-Select Client & Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0038 field "Lnk_CLOSE QUOTE" in "PreQualification-Select Client & Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0039 field "Btn_(Existing Client)*" in "Driver Information-Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0044 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 15. Source step 0044 field "Btn_Named Non-Owned_Vehicle Type" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0044 field "Btn_Named Non-Owned_Vehicle Type" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 17. Source step 0044 field "Btn_Motor Home_Vehicle Type" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 18. Source step 0044 field "Btn_Collector Car_Vehicle Type" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 19. Source step 0044 field "Btn_Modern Classic_Collector Car Type" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 20. Source step 0044 field "Btn_Own" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0044 field "Btn_Own" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "x"
# 22. Source step 0044 field "Txt_Agreed Value" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 23. Source step 0044 field "Txt_Agreed Value" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "$16000"
# 24. Source step 0044 field "Btn_Yes_Is this motor home or travel trailer?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0044 field "Btn_No_Is this motor home or travel trailer?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 26. Source step 0044 field "Btn_Restricted Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 27. Source step 0044 field "Drpdwn_Passive Restraint" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{Sendkeys[None]}"
# 28. Source step 0044 field "Lbl_Does this vehicle have any customized equipment?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 29. Source step 0044 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0044 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 31. Source step 0044 field "Txt_Appraisal Date" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0044 field "Txt_Appraisal Date" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "10/10/2001"
# 33. Source step 0044 field "Txt_What is the length in feet?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0044 field "Txt_What is the length in feet?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}{Sendkeys[2]}"
# 35. Source step 0044 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0044 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "10/10/2000"
# 37. Source step 0044 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 38. Source step 0044 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 39. Source step 0044 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "60"
# 40. Source step 0044 field "Txt_AnnualMileage" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 41. Source step 0044 field "Txt_AnnualMileage" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "50"
# 42. Source step 0044 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 43. Source step 0045 field "Lbl_Principal or Occasional driver of this vehicle?" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0045 field "Btn_Principal" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 45. Source step 0057 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "x"
# 46. Source step 0057 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 47. Source step 0057 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 48. Source step 0057 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0057 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0057 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0060 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "x"
# 52. Source step 0060 field "Btn_No Coverage_2" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0060 field "Lbl_Uninsured Motorist PD" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0060 field "Btn_UMPD Limits" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 55. Source step 0063 field "Btn_Next" in "Pricing Details-Review & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0067 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 57. Source step 0068 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 58. Source step 0069 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 59. Source step 0070 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 60. Source step 0073 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 61. Source step 0074 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 62. Source step 0075 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 63. Source step 0105 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 64. Source step 0107 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 65. Source step 0108 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 66. Source step 0109 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 67. Source step 0111 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0111 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 69. Source step 0115 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 70. Source step 0115 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 71. Source step 0115 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0115 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 73. Source step 0116 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 74. Source step 0116 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 75. Source step 0116 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0116 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 77. Source step 0117 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0117 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 79. Source step 0117 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0117 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 81. Source step 0118 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 82. Source step 0119 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 83. Source step 0130 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 84. Source step 0133 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 85. Source step 0178 "ECheckList-Attach required enlcosures" in module "EQ||ECheckList" was disabled. Reason: 31.05.24 02:24:29 [ct2628]
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 86. Source step 0179 "TBox Save As-To Upload the file" in module "TBox Save As" was disabled. Reason: 31.05.24 02:24:29 [ct2628]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png"
#    - INPUT "Button" with "Open"
# 87. Source step 0183 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 88. Source step 0183 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 89. Source step 0183 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 90. Source step 0202 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 91. Source step 0202 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0202 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 93. Source step 0202 field "<unnamed value>" in "Select Lower Cverage BI/PD" was disabled. Reason:  
#    - Preserved source value: "X"
# 94. Source step 0211 "Verify if Launch Esign is visible" in module "EQ||Submission" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "Btn_Launch To eSignature" with "True"
# 95. Source step 0212 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "10000"
# 96. Source step 0213 "Launch To eSignature" in module "EQ||Submission" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Btn_Launch To eSignature" with "X"
# 97. Source step 0214 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - VERIFY "Lbl_Password" with "Password"
# 98. Source step 0215 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
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
# 99. Source step 0216 "TBox Take Screenshot" in module "TBox Take Screenshot" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Environment" with "Desktop"
#    - INPUT "Directory" with "C:\\Tosca_Projects\\Screenshots"
#    - INPUT "Filename" with a blank value
# 100. Source step 0217 "EQ|| Confirm Esign_1" in module "EQ|| Confirm Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - WAIT "Btn_Confirm Signers" with "True"
#    - INPUT "Btn_Confirm Signers" with "X"
# 101. Source step 0218 "EQ|| Confirm Esign_2" in module "EQ|| Confirm Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - BUFFER "Txt_PIN" with "TC14_NB - esign (Cycle)_NM_PIN"
#    - INPUT "Txt_Email Address" with the RUNTIME-CONFIGURED value "EsignEmail"
#    - INPUT "Btn_Create Signing Package" with "x"
# 102. Source step 0219 "CloseBrowser-Close the Esign browser" in module "CloseBrowser" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Title" with "Esign*"
# 103. Source step 0220 "EQ|| Confirm Esign_1" in module "EQ|| Confirm Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - WAIT "Btn_Confirm Signers" with "True"
#    - INPUT "Btn_Confirm Signers" with "X"
# 104. Source step 0221 "EQ|| Confirm Esign_2" in module "EQ|| Confirm Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - BUFFER "Txt_PIN" with "TC14_NB - esign (Cycle)_NM_PIN"
#    - INPUT "Txt_Email Address" with the RUNTIME-CONFIGURED value "EsignEmail"
#    - INPUT "Btn_Create Signing Package" with "x"
# 105. Source step 0222 "CloseBrowser-Close the Esign browser" in module "CloseBrowser" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Title" with "Esign*"
# 106. Source step 0223 "Open Url" in module "Open Url_ARA" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Url" with the RUNTIME-CONFIGURED value "OutlookURL"
#    - INPUT "UseActiveTab" with "False"
# 107. Source step 0224 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "3000"
# 108. Source step 0225 "Refresh" in module "TBox Send Keys" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Caption" with "*Mail*"
#    - INPUT "Keys" with "{F5}"
# 109. Source step 0226 "Click on e-SignLive Email" in module "Click on e-SignLive Email" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "e-SignLive" with "False"
# 110. Source step 0227 "Refresh" in module "TBox Send Keys" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Caption" with "*Mail*"
#    - INPUT "Keys" with "{F5}"
# 111. Source step 0228 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "6000"
# 112. Source step 0229 "Refresh" in module "TBox Send Keys" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Caption" with "*Mail*"
#    - INPUT "Keys" with "{F5}"
# 113. Source step 0230 "Click on e-SignLive Email" in module "Click on e-SignLive Email" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "e-SignLive" with "{Click[39%][91%]}"
# 114. Source step 0231 "Mail - Alekya.Peddireddy@AmericanNational.com" in module "Click on Esign Link" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." with "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
#    - INPUT "TABLE > e-SignLive Link" with "{Click}"
# 115. Source step 0232 "OneSpan Sign" in module "OneSpan Sign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Secret PIN Maximum number of characters allowed for the field is 100" with captured runtime value "TC14_NB - esign (Cycle)_NM_PIN"
#    - INPUT "Login" with "x"
# 116. Source step 0233 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Title" with "*Mail*"
# 117. Source step 0234 "Signing documents for Esign" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - WAIT "Review Documents" with "True"
# 118. Source step 0235 "Click on Review Document" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Review Documents" with "X"
# 119. Source step 0236 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "5000"
# 120. Source step 0237 "Verify Page count Exists" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "Page Details" with "0"
# 121. Source step 0238 "Buffer Sign & Initial Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - BUFFER "Initial_Count" with "InitialCount"
#    - BUFFER "Sign_Count" with "SignCount"
# 122. Source step 0239 "Click on Initial Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Initial" with "X"
# 123. Source step 0240 "Click on Sign Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Sign" with "X"
# 124. Source step 0241 "Accept|Next|Confirm|Finished" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - WAIT "Accept|Next|Confirm|Finished" with "True"
#    - INPUT "Accept|Next|Confirm|Finished" with "X"
# 125. Source step 0242 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "5000"
# 126. Source step 0243 "TBox Take Screenshot" in module "TBox Take Screenshot" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Environment" with "Desktop"
#    - INPUT "Directory" with "C:\\Tosca_Projects\\Screenshots"
#    - INPUT "Filename" with a blank value
# 127. Source step 0244 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Title" with "Signing*"
# 128. Source step 0245 "TBox Scroll Window Operation" in module "TBox Scroll Window Operation" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Caption" with "Signing*"
#    - INPUT "Window Index" with "1"
#    - INPUT "Vertical" with "4000px"
#    - INPUT "Horizontal" with "6000px"
#    - INPUT "MousePolicy" with "Center"
#    - INPUT "DirectionPolicy" with "HorizontalFirst"
#    - INPUT "Delay" with "100ms"
# 129. Source step 0246 "Verify Page count Exists" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "Page Details" with "0"
# 130. Source step 0247 "Buffer Sign & Initial Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - BUFFER "Initial_Count" with "InitialCount"
#    - BUFFER "Sign_Count" with "SignCount"
# 131. Source step 0248 "Click on Initial Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Initial" with "X"
# 132. Source step 0249 "Click on Sign Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Sign" with "X"
# 133. Source step 0250 "Accept|Next|Confirm|Finished" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - WAIT "Accept|Next|Confirm|Finished" with "True"
#    - INPUT "Accept|Next|Confirm|Finished" with "X"
# 134. Source step 0251 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "5000"
# 135. Source step 0252 "TBox Take Screenshot" in module "TBox Take Screenshot" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Environment" with "Desktop"
#    - INPUT "Directory" with "C:\\Tosca_Projects\\Screenshots"
#    - INPUT "Filename" with a blank value
# 136. Source step 0253 "Click on Review Document" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Review Documents" with "X"
# 137. Source step 0254 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "5000"
# 138. Source step 0255 "Verify Page count Exists" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - VERIFY "Page Details" with "0"
# 139. Source step 0256 "Buffer Sign & Initial Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - BUFFER "Initial_Count" with "InitialCount"
#    - BUFFER "Sign_Count" with "SignCount"
# 140. Source step 0257 "Click on Initial Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Initial" with "X"
# 141. Source step 0258 "Click on Sign Count" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Sign" with "X"
# 142. Source step 0259 "Accept|Next|Confirm|Finished" in module "Signing & Reviewing documents for Esign" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - WAIT "Accept|Next|Confirm|Finished" with "True"
#    - INPUT "Accept|Next|Confirm|Finished" with "X"
# 143. Source step 0260 "TBox Wait" in module "TBox Wait" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Duration" with "5000"
# 144. Source step 0261 "TBox Take Screenshot" in module "TBox Take Screenshot" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Environment" with "Desktop"
#    - INPUT "Directory" with "C:\\Tosca_Projects\\Screenshots"
#    - INPUT "Filename" with a blank value
# 145. Source step 0262 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 17.06.24 10:42:10 [ct2628]
#    - INPUT "Title" with "Signing*"
# 146. Source step 0264 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 147. Source step 0265 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 148. Source step 0265 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 149. Source step 0265 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 150. Source step 0266 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 151. Source step 0269 field "H4" in "eChecklist-Verify if 'Application' links in the checklist are completed" was disabled. Reason:  
#    - Preserved source value: "True"
# 152. Source step 0270 field "H4" in "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 153. Source step 0275 field "Lbl_Value_Effective Date" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 154. Source step 0275 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 155. Source step 0275 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 156. Source step 0275 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 157. Source step 0279 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 158. Source step 0280 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 159. Source step 0281 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 160. Source step 0282 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 161. Source step 0283 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 162. Source step 0284 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 163. Source step 0285 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 164. Source step 0286 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 165. Source step 0287 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse Auto with Esign - CA_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0002 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0003 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0004 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EQ sign out and Close browser
# 5. Source recovery step 0005 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0006 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0007 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0008 CloseBrowser: I close the active browser
