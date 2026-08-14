# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 145_UW_Rejection_-_RV-_MD_UW_Rejection_-_RV-_MD.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @rejection @Edge @manual @archive @automated
Feature: Execute UW Rejection - RV- MD for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Rejection - RV- MD workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Rejection - RV- MD using representative iteration UW Rejection - RV- MD
    # Source step 0009: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-e859-c650-aec7596498b6
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
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-b270-2b16-3137e3be1513
    Then I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-1260-779e-b4123ed54763
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "MD_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "MD_ClientData_Regression.LastName" in "Txt_Last"
    When I leave "Txt_Date of birth" blank
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I click "Btn_Create New Client"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0014: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-5129-3a41-00c5621b0185
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "MD_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072234762" in "Txt_Best phone_Account Owner"
    When I enter or select "TEST@MAIL.COM" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I select "Btn_Married"
    When I enter the RUNTIME-DERIVED TDM value "MD_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "MD_ClientData_Regression.City" in "Txt_owner.address.city_New"
    When I enter or select "MARYLAND" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter the RUNTIME-DERIVED TDM value "MD_ClientData_Regression.Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0015: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-9a51-d54e-79bb20dcfae0
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Personal Auto"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE[][+1d][MM/dd/yyyy]}]}" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[MARYLAND]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"

    # Source step 0016: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0017: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-d4c7-abea-1f6aaa7f8295
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0018: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-1c9d-ab0f-f785023f855f
    # Runtime control: Prposal Start_Proceed  > Then
    When if the source runtime condition "Prposal Start_Proceed > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0019: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-aaba-3b94-3200bd250867
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0020: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-95ef-515b-f5a59f1f18e7
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0021: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-44ef-389f-785ea55a8db6
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter or select "666341778" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0022: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-2168-eabd-660777e7488c
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0023: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-1aa0-16fd-2f90b84c7a25
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0025: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-2658-0129-c60a39515aa3
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0026: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-6275-1ef8-efef2207f6ab
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0027: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-9451-5095-9c0485231311
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0028: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-7b22-e7fa-1a14611da087
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0029: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-4c62-b705-5d288c23416c
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0030: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-6746-14d5-224aaaa45274
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

    # Source step 0031: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-21bf-d92b-c6b52f71ca30
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

    # Source step 0032: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0033: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-3a3b-5c97-f75bde0f1546
    When I click "Btn_Next"

    # Source step 0034: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-ba86-ac7c-b753b259654f
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0035: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-d0be-e395-8b6a9b9df789
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0036: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-69a6-dca5-d4d744c80cd4
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "WBSNB93527CX07002" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    When I click "Btn_Pleasure Use"
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

    # Source step 0037: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-ad0e-d716-addc8b1ab13f
    When I click "Btn_1988 Ford E350"
    When I click "Btn_Principal_2"
    When I click "Btn_Next"

    # Source step 0038: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3998-675c-7f1a-3395f97f3fe1
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0039: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a7-9776-d7b4-320e4a970095
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0040: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0041: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-7123-c90a-8a8bcada4167
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0042: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-4f54-e60b-3eb2178d6f9d
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0043: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-b9e4-37a5-0f2ee27ae1a0
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0044: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-43ea-1bfe-a98aecf152eb
    When I click "Btn_Next"

    # Source step 0045: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0046: Enter Coverages | Module: <unresolved module>
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-fd37-904e-687039ee34f8
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0047: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-b589-4276-d2b4ca02be51
    When I click "Btn_BASIC"
    When I click "Btn_$15,000_UMPD"
    When I select "Btn_V1_More Options"
    When I click "Btn_$50,000"
    When I click "Btn_Next"

    # Source step 0048: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-0d54-9521-6be3a028fae4
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0049: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-4290-b876-c45325b65cd0
    When I click "<unnamed value>"

    # Source step 0050: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0051: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-1480-3978-4b90b2737904
    When I click "btn_Next"

    # Source step 0052: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0057: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0058: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0059: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0063: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0064: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "CT2634" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0065: Search Policy Number | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0066: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0067: Click on Pricing | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0069: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0071: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0072: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0073: Click on Home button | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0075: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0076: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0077: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0078: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0079: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0080: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0082: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0083: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0084: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0085: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-1c6f-06ef-d8e20fa3f0a4
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0086: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-bde5-cdd7-e06eb42f7078
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0087: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-2a63-cd36-37cf05697e7f
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0088: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-3988-2726-2ac7807e81fc
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0089: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-8a17-920e-df78135ce9eb
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0090: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-9e21-18e4-111797236d56
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0091: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-e3c8-6d00-bfd9c0d9143f
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0092: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-22d5-36e4-d170c9de0347
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0093: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-939f-8de4-1889181c9f5e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0094: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-f7e3-496f-75493b792db1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0095: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-50f7-f62e-b438a64fec61
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0096: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-8409-3fd8-5de67afba100
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0097: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-79e7-d26e-edcee7d01226
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0098: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-ab1b-c7a9-dc9688c66a82
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0099: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0103: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-3f61-6df8-31e382589451
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0104: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-b850-445d-7eb1c201942e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2634" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0105: EU||Home | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-b6ef-8915-326f8061edd2
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0106: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-f299-09b6-7e799859b2b1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0107: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-3805-75c9-fd68cb9513a8
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0108: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-723f-36c8-5d61f359f495
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0109: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-2f50-d7d9-b27dcf1f9a56
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0110: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-e702-c962-12348f54ad74
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0111: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-f00f-aa09-eff77edeacfa
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0112: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-731f-47d3-db113cc0731a
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0113: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-3077-9038-34974a768e4c
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0114: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-f34a-0a6b-7b976c78d8a4
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0115: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-50d3-ba68-9295bb556c51
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0116: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-17db-0c86-d3292d64c0af
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0117: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-8349-4cd7-c012c51716eb
    When I click "Btn_Launch To Checklist"

    # Source step 0119: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-79ac-4ffd-de4d3b2708d6
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0121: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-0da1-4663-98c46b03ca0e
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, "Img_American National Family of Companies" should exist
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

    # Source step 0122: EQ||Agent List count capture - Capture Count of Documents to be Uploaded | Module: EQ||Agent List count capture
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-7f6e-c831-298aab97f7b6
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0123: EQ||ECheckList - Click Auto/Cycle/RV Application | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-8e0e-8606-0f83053392f9
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0124: TBox Save As - Enter File location | Module: TBox Save As
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-5a49-06b0-a75172a02903
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0125: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-9e14-0220-ee7799e1026d
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0126: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Auto Policy > 14 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-c0cd-8b07-72748d33b722
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0128: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-9a8e-0717-950ffb5f526e
    When I close the active browser

    # Source step 0129: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Auto Policy > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-cff4-ff3f-ea4f5e134ad2
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0130: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 15 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0131: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-a73b-9e1a-50d5b8dcfe15
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0132: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-de25-8531-044357513afc
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "MD"

    # Source step 0146: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 16 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-11c5-bf5b-016621246d13
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "MD"

    # Source step 0157: Click on policy History | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 01 Recall Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-86ff-8a95-73756f279254
    When I click "Policy History"

    # Source step 0158: EQ||Quick Actions | Module: EQ||Quick Actions
    # Section: Process > Recreational Policy > 01 Recall Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-aa0d-137d-1a3275172e78
    When I click "Btn_QUOTE ACTIONS"
    When I click "Btn_New Quote Same Client"

    # Source step 0159: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-5800-f81a-6e2e3591575a
    When I click "Btn_Recreational Vehicle"
    When I enter or select "{Invoke[Click]}{SENDKEYS[MARYLAND]}" in "Drp List_Proposal Rating State"
    When I select "Drp_Writing Company"
    When I click "Lbl_American National Property And Casualty Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"

    # Source step 0160: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-6da0-a597-09eeb050290e
    # Runtime control: Proposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0161: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-1e25-052d-805101e22ed4
    # Runtime control: Proposal Start_Proceed  > Then - Click Proceed
    When if the source runtime condition "Proposal Start_Proceed > Then - Click Proceed" is satisfied, I click "Btn_PROCEED"

    # Source step 0162: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Recreational Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-c175-533e-e936f59000c1
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0163: Enter Driver Information - Add Existing Client & Continue | Module: EQ||Driver Information
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-7c5b-1a88-eb86932b1361
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0164: Driver Summary - Enter Driver Details | Module: EQ||Driver Summary
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39a8-cdd2-bac3-d53ce270de45
    When I click "Btn_Primary Named Insured"
    When I click "Btn_Save and Continue"

    # Source step 0165: Driver Information- Click Next | Module: EQ||Driver Information Next
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-0223-5643-f40f5ff20851
    When I click "Btn_Next"

    # Source step 0166: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-fae2-84c8-a2eb1d4f9ef9
    # Runtime control: Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0167: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-bcd1-2cbd-83d04ad98769
    # Runtime control: Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0168: Vehicle Summary - Enter Vehcile Details | Module: EQ||Vehicle Summary
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-ec6a-c13b-f6d20a5b45ae
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "4XARC08G4BB410976" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    When I select "Btn_Is this vehicle used for racing?_No"
    Then I wait until "Txt_Engine CC" exists
    When I enter or select "\"^{a}\"" in "Txt_Engine CC"
    When I enter or select "700" in "Txt_Engine CC"
    Then I wait until "Btn_No" exists
    When I select "Btn_No"
    When I select "Btn_Is this vehicle licensed for road use?_No"
    Then I wait until "Txt_ActualCashValue" exists
    When I enter or select "\"^{a}\"" in "Txt_ActualCashValue"
    When I enter or select "1000" in "Txt_ActualCashValue"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0169: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 06 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-c1f6-a408-3c87ffe48b1e
    # Runtime control: Claims/Violations Popup > If Pop up Appears
    Then if the source runtime condition "Claims/Violations Popup > If Pop up Appears" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0170: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 06 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-16a5-d923-d0a8e28c98aa
    # Runtime control: Claims/Violations Popup > Then - Click Continue & Next
    When if the source runtime condition "Claims/Violations Popup > Then - Click Continue & Next" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0171: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 06 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-bab2-8242-87d4e977145a
    # Runtime control: Claims/Violations Popup > Else - Click Next
    When if the source runtime condition "Claims/Violations Popup > Else - Click Next" is satisfied, I click "Btn_Next"

    # Source step 0172: Discounts - Select Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Recreational Policy > 07 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-4cb5-b959-f68562b64459
    When I click "Btn_Next"

    # Source step 0173: Coverages - Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Recreational Policy > 08 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-2808-7ae9-a59e9cee016b
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0174: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Recreational Policy > 08 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-93d3-c2b2-cd96003af096
    When I click "Btn_Next"

    # Source step 0175: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 08 Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0176: Pricing Details - Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Recreational Policy > 09 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-e39a-c55b-95360d7a1098
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0177: Underwriting - Underwriting Review & Continue | Module: <unresolved module>
    # Section: Process > Recreational Policy > 10 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-4bf9-e684-8a5caef2aa02
    When I click "<unnamed value>"

    # Source step 0178: Additional Interest Summary - Click Next | Module: EQ||Additional Interest Summary
    # Section: Process > Recreational Policy > 10 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-5738-d0f0-05a205ae60e5
    When I click "btn_Next"

    # Source step 0179: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Recreational Policy > 11 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0184: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 11 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0185: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0186: OpenUrl | Module: OpenUrl
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0190: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0191: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "CT2634" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0192: Search Policy Number | Module: EU||Home
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0193: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0194: Click on Pricing | Module: EU||Applicant
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0195: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0196: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0197: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0198: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0199: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0200: Click on Home button | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0201: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0202: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0203: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0204: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0205: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0206: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0207: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0208: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0209: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0210: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0211: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0212: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-3724-3fc6-c944694aa02b
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0213: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-ea0f-6a19-de5fc4e707e7
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0214: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-fe95-52b3-d5e73da75f99
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0215: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-536c-ea8e-392c560a63df
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0216: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-2110-cd73-c4dab13d403a
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0217: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-65cb-9c69-a50e9ff196ca
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0218: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-fd5f-f81f-d7f753b1f98a
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0219: EQ||Submission | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-567d-a737-df66ad1d0aeb
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0220: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-66cc-d228-06c8186b8c66
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0221: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-7151-d4fb-155affd75e0e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0222: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-b7af-cb07-d8e7e9550503
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0223: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-c024-b0c6-2bb11d8b2846
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0224: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-5ebe-6f0b-eba01c58a8a0
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0225: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-500e-d0d4-b2631a3a32d9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0226: OpenUrl | Module: OpenUrl
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0230: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-0c06-5ddd-ddc269cf55fe
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0231: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-9feb-1c82-4ae78c37e74f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2634" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0232: EU||Home | Module: EU||Home
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-27aa-80d2-75cf53de6269
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0233: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-9f0d-b9cd-4ccb6b989b07
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0234: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-9f35-5f9d-2c8dd12e7a01
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0235: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-e868-ee19-bd0f4ee5bf58
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0236: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-cc8b-3e59-8cf8a67ee12b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0237: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-f2d9-8056-fb597815cc5b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0238: EU||Applicant | Module: EU||Applicant
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-7b7b-4ffa-087e6e043d49
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0239: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-ecf6-e225-cc5da3854e7d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0240: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-6608-a3bc-82c48b45dc08
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0241: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-beab-46de-ad7bc1e830ad
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0242: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-6c8c-0836-61e7799c86b7
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0243: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-2502-6179-b5076ae0cee9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0244: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-1093-4748-04dd419c7a66
    When I click "Btn_Launch To Checklist"

    # Source step 0246: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-4e83-7633-972cc4411bed
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0248: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-c3b3-2e5a-785b176954a9
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, "Img_American National Family of Companies" should exist
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

    # Source step 0249: EQ||Agent List count capture - Capture Count of Documents to be Uploaded | Module: EQ||Agent List count capture
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-4de8-aadb-9ba13ed25759
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0250: EQ||ECheckList - Click Auto/Cycle/RV Application | Module: EQ||ECheckList
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-e4c1-29af-aaa5791eb860
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0251: TBox Save As - Enter File location | Module: TBox Save As
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-0abc-88a0-98ef39f0cbdd
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0252: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Recreational Policy > 14 Launch checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-f69d-b234-c9a3bd9396c3
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0253: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Recreational Policy > 14 Launch checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-e442-848f-131118431bd0
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0255: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-afcb-d47f-f6778f45aadc
    When I close the active browser

    # Source step 0256: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Recreational Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-1035-b6e4-ecdba4f9cf05
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0257: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 16 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0258: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-88e8-c302-0cb0741c44f9
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0259: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-d1d9-663e-874b2aa2cbae
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "MD"

    # Source step 0273: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-65f8-c28c-7692723c50c7
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "MD"

    # Source step 0274: Submission - Save & Exit Policy | Module: EQ||Submission
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-aa6d-e1e9-a7c96cdc17c3
    When I click "Btn_Save and Exit"

    # Source step 0275: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0276: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0277: OpenUrl | Module: OpenUrl
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0281: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-0827-7b4b-155ab6d76339
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0282: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-d32c-dac2-75c3520289ed
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2634" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0283: Search Policy | Module: EU||Home
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-3fa4-0093-33c2aa5eeca8
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0284: Click Policy holder name | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Rejection > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-0654-89ec-2ed6cee3e528
    When I click "Lnk_Insured Name"
    When I click "Lnk_RV"

    # Source step 0285: Click Transaction Type | Module: EU|Transaction Type
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-4a47-7886-d42caa881697
    When I click "expand"
    When I click "Cancel"
    When I click "Go"

    # Source step 0286: Click Transaction Reason & Detailed Reason | Module: Check if Value too High appears
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-24cd-3833-cc9a27a1229e
    When I click "Transaction Reason expand"
    When I click "Underwriting Reasons - Rejection"
    When I click "Detailed Reason_expand"
    When I click "Claims Review"

    # Source step 0287: Capture Effective and Scheduled Dates | Module: Schedule Dates for Cancellation_Rejection
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-b1f9-eac3-6ae643241b4f
    When I capture "Value" from "Effective Date_1" as runtime value "Cancellation_EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):_1" as runtime value "Cancellation_ScheduledDate"

    # Source step 0288: Set Dates | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-66e4-c117-5b258d3ea048
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]}" as runtime value "ScheduledDate"
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][-25d][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0289: Start PowerShell | Module: TBox Start Program
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-704c-34c7-7dede225a7cf
    And I run program or command "powershell.exe"

    # Source step 0290: Execute PowerShellCommand 1 | Module: TBox Send Keys
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-e7fb-7ea1-3b2ed002ef62
    When I enter or select "*PowerShell*" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\"\"\"\"$TimeSpan=([DateTime]'{B[ScheduledDate]}' - [DateTime]'{B[EffectiveDate]}')\"\"\"\";~" in "Keys"

    # Source step 0291: Execute PowerShellCommand 2  | Module: TBox Send Keys
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-71af-2645-8865f1928b4f
    When I enter or select "*PowerShell*" in "Caption"
    When I enter or select "$TimeSpan | Clip~" in "Keys"

    # Source step 0292: TBox Wait | Module: TBox Wait
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0293: Get Days Difference | Module: TBox Clipboard
    # Section: Process > UW Rejection > UW Rejection Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-ce3b-30f4-20c3744a9291
    Then "Value" should equal "Days : {XB[DayDifference]} *"

    # Source step 0294: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-b2d9-9be4-78b56008ad50
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "ScheduledDates"
    And I use TDM parameter "Alias name (item)" with "ScheduledDates"
    And I use TDM parameter "Data search filter > TCName" with "UW Rejection - Auto - MD"
    And I use TDM parameter "Data search filter > State" with "MD"
    And I use TDM parameter "Data search filter > LOB" with "Auto"

    # Source step 0295: Retriving Expected No.of days from TDM | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-7ac2-ab9b-1e4dae1486f2
    When I retrieve and retain the RUNTIME-DERIVED TDM value "ScheduledDates.No of Days Workaround" as runtime value "Expected Days"

    # Source step 0296: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-f198-4945-5579b4c9275e
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Condition
    Then if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[DayDifference]} == {B[Expected Days]}"

    # Source step 0297: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-3097-62bf-597853ff995d
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Then
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Then" is satisfied, I retain hard-coded value "The Actual No.of Days is equal to Expected No.of Days" as runtime value "No.of Days Equal"

    # Source step 0298: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-20bd-4b04-c766bb604b48
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Else
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Else" is satisfied, I retain hard-coded value "The Actaul No.of Days are not equal to Expected No.of Days" as runtime value "No.of Days not Equal"

    # Source step 0300: Select  & Cick Schedule | Module: EU|Schedule
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-cc82-74cb-b47f38c826ca
    When I enter or select "True" in "MVR_1"
    When I click "Schedule"

    # Source step 0301: TBox Wait | Module: TBox Wait
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-36d0-37bf-8529bd0ef2f9
    When I wait "5000" milliseconds

    # Source step 0302: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > UW Rejection > UW Rejection Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39b7-cc59-a027-b1a27af72271
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
# 5. Source step 0011 "Enter Client Selection" in module "EQ || Client Selection" was disabled. Reason: 01.06.24 15:49:24 [ct2634]
#    - VERIFY "Lbl_Client Info" with "True"
#    - VERIFY "Lbl_Client Info" with "Client Info"
#    - VERIFY "Lbl_New/Existing Client Search" with "True"
#    - VERIFY "Lbl_New/Existing Client Search" with "New/Existing Client Search"
#    - INPUT "Txt_First" with "{Invoke[Click]}{SENDKEYS[Dusty]}"
#    - INPUT "Txt_Last" with "COHEE"
#    - INPUT "Txt_Date of birth" with a blank value
#    - INPUT "Txt_Best phone" with a blank value
#    - INPUT "Txt_Email address" with a blank value
#    - VERIFY "Btn_Search" with "True"
#    - INPUT "Btn_Search" with "X"
#    - VERIFY "Btn_Create New Client" with "Create New Client"
#    - INPUT "Btn_Create New Client" with "X"
#    - VERIFY "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 6. Source step 0012 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 01.06.24 15:49:24 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with "2/28/1935"
#    - INPUT "Txt_Best phone_Account Owner" with "9072091932"
#    - INPUT "Txt_Email_Account Owner" with "DUSTYCOHEE0228@COMCAST.NET"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Married" with "X"
#    - INPUT "Txt_Enter a location" with "MONTROSE RD"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with "ROCKVILLE"
#    - INPUT "Drpdwn_State" with "MARYLAND"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with "852090000"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 7. Source step 0014 field "Btn_Single" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0014 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0014 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 10. Source step 0014 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 11. Source step 0015 field "Btn_Recreational Vehicle" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 12. Source step 0015 field "Hdr_proposal.ratingState-panel" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "New Mexico"
# 13. Source step 0015 field "Lbl_Writing Company" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0015 field "Drp List_List Auto Writing Company" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[American National General Insurance Co.]}"
# 15. Source step 0015 field "Drp List_State" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[MARYLAND]}"
# 16. Source step 0015 field "Lbl_NEW MEXICO" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 17. Source step 0015 field "Lnk_YES" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0015 field "Hdr1" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[ARIZONA]}"
# 19. Source step 0015 field "Btn_PROCEED" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0021 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0024 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 22. Source step 0028 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 23. Source step 0030 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 24. Source step 0030 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 25. Source step 0030 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0030 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0030 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0030 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0030 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 30. Source step 0030 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 31. Source step 0030 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0030 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0030 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0031 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0031 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 36. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0031 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 40. Source step 0031 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 41. Source step 0031 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 42. Source step 0031 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 43. Source step 0031 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 44. Source step 0031 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0033 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0034 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0034 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0035 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0036 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0036 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0036 field "Lbl_Primary Vehicle Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 52. Source step 0036 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 53. Source step 0036 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 54. Source step 0036 field "Btn_Cycle_Customizatioin_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0036 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 56. Source step 0036 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0036 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0036 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 59. Source step 0036 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 60. Source step 0036 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 61. Source step 0037 field "Btn_VehSelect" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 62. Source step 0037 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 63. Source step 0037 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 64. Source step 0037 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 65. Source step 0037 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0037 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 67. Source step 0037 field "Btn_Vehicle_Select" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0037 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0037 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 70. Source step 0037 field "Btn_Principal_New" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 71. Source step 0037 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 72. Source step 0037 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 73. Source step 0038 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 74. Source step 0044 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 75. Source step 0044 field "Btn_Not Residential Property Owner" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 76. Source step 0044 field "Btn_No Proof of Prior Insurance" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 77. Source step 0044 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 78. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 79. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 81. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 82. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0046 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 85. Source step 0047 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 86. Source step 0047 field "Btn_UMPD_No Coverage_V1" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 87. Source step 0047 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0047 field "Btn_$15,000_PIP Limit" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 89. Source step 0047 field "Btn_No Deductible" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 90. Source step 0047 field "Btn_No" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "x"
# 91. Source step 0047 field "Btn_No Coverage_UMPD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0047 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 93. Source step 0047 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 94. Source step 0047 field "Btn_No Coverage_2" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 95. Source step 0047 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0047 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 97. Source step 0049 field "<unnamed value>" in "Enter Underwriting" was disabled. Reason:  
#    - Preserved source value: "True"
# 98. Source step 0049 field "<unnamed value>" in "Enter Underwriting" was disabled. Reason:  
#    - Preserved source value: "X"
# 99. Source step 0051 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 100. Source step 0051 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 101. Source step 0051 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 102. Source step 0053 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 103. Source step 0054 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 104. Source step 0055 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 105. Source step 0056 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 106. Source step 0060 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 107. Source step 0061 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 108. Source step 0062 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 109. Source step 0100 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 110. Source step 0101 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 111. Source step 0102 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 112. Source step 0118 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 113. Source step 0119 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 114. Source step 0119 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 115. Source step 0119 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 116. Source step 0120 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 117. Source step 0122 field "DIV_Agent Documents Count" in "EQ||Agent List count capture - Capture Count of Documents to be Uploaded" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 118. Source step 0127 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 119. Source step 0131 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "True"
# 120. Source step 0131 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 121. Source step 0131 field "Btn_Transmit" in "Submission - Capturing Policy Number,Effective Date, Premium Value" was disabled. Reason:  
#    - Preserved source value: "X"
# 122. Source step 0133 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "LOB" with "Auto"
#    - INPUT "State" with "NM"
# 123. Source step 0134 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 124. Source step 0135 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 125. Source step 0136 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 126. Source step 0137 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 127. Source step 0138 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 128. Source step 0139 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 129. Source step 0140 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 130. Source step 0141 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 131. Source step 0142 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 132. Source step 0143 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 133. Source step 0144 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 134. Source step 0145 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 28.05.24 22:28:38 [ct2518]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
# 135. Source step 0147 "Submission - Save & Exit Policy" in module "EQ||Submission" was disabled. Reason: 31.05.24 12:46:26 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 136. Source step 0148 "Log Out- Exist from the Quote/Policy" in module "EQ||Log Out" was disabled. Reason: 31.05.24 12:46:26 [ct2634]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 137. Source step 0149 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 31.05.24 12:46:26 [ct2634]
#    - INPUT "Title" with "Sign On*"
# 138. Source step 0150 "Click Save and Exit" in module "EQ||Submission" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - INPUT "Btn_Save and Exit" with "X"
# 139. Source step 0151 "TBox Partial Buffer_Trim Policy Number" in module "TBox Partial Buffer" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - INPUT "Buffer" with "Policy_Number"
#    - INPUT "Value" with the RUNTIME-DERIVED buffer expression "{TRIM[{B[Policy Number]}]}"
# 140. Source step 0152 "Verifiy if integration page appears" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - VERIFY "Close Quote" with "True"
# 141. Source step 0153 "Close Quote" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - INPUT "Close Quote" with "X"
# 142. Source step 0154 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with the RUNTIME-DERIVED buffer expression "{Click}{Sendkeys[{B[Policy_Number]}]}"
#    - INPUT "Btn_Search" with "X"
# 143. Source step 0155 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "Policy_Number"
#    - INPUT "Btn_Search" with "X"
# 144. Source step 0156 "EQ||Quick Actions" in module "EQ||Quick Actions" was disabled. Reason: 30.05.24 23:25:54 [ct2518]
#    - INPUT "Btn_QUOTE ACTIONS" with "{Invoke[Click]}"
#    - INPUT "Btn_New Quote Same Client" with "{Invoke[Click]}"
# 145. Source step 0163 field "Btn_(Existing Client)*" in "Enter Driver Information - Add Existing Client & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 146. Source step 0164 field "Lbl_Gender" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 147. Source step 0164 field "Lbl_Gender" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 148. Source step 0164 field "Btn_Male" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 149. Source step 0164 field "Btn_Male" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 150. Source step 0164 field "Btn_Male" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 151. Source step 0164 field "Btn_Single" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 152. Source step 0164 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 153. Source step 0164 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 154. Source step 0164 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "{Click}{Sendkeys[22]}"
# 155. Source step 0164 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: ""
# 156. Source step 0164 field "Txt_Months Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 157. Source step 0164 field "Txt_Date License" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 158. Source step 0164 field "Btn_FinancialResponsibility_No" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 159. Source step 0164 field "Btn_PriorInsurance_No" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 160. Source step 0164 field "Btn_Did Not Have Insurance" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 161. Source step 0164 field "Lnk_UWR_CONTINUE" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 162. Source step 0166 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 163. Source step 0166 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 164. Source step 0167 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 165. Source step 0168 field "Lbl_VIN LABEL" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 166. Source step 0168 field "Btn_Automobile" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 167. Source step 0168 field "Btn_Trailbike" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 168. Source step 0168 field "Btn_Cycle_Customizatioin_No" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 169. Source step 0168 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 170. Source step 0168 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 171. Source step 0168 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 172. Source step 0168 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "60"
# 173. Source step 0168 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 174. Source step 0174 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "x"
# 175. Source step 0174 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 176. Source step 0174 field "Btn_UMPD_No Coverage_V1" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "x"
# 177. Source step 0174 field "Lbl_Uninsured Motorist PD" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 178. Source step 0174 field "Btn_UMPD Limits" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 179. Source step 0177 field "<unnamed value>" in "Underwriting - Underwriting Review & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 180. Source step 0177 field "<unnamed value>" in "Underwriting - Underwriting Review & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 181. Source step 0180 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 182. Source step 0181 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 183. Source step 0182 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 184. Source step 0183 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 185. Source step 0187 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 186. Source step 0188 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 187. Source step 0189 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 188. Source step 0227 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 189. Source step 0228 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 190. Source step 0229 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 191. Source step 0245 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 192. Source step 0246 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 193. Source step 0246 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 194. Source step 0246 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 195. Source step 0247 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 196. Source step 0249 field "DIV_Agent Documents Count" in "EQ||Agent List count capture - Capture Count of Documents to be Uploaded" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 197. Source step 0254 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 198. Source step 0260 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 23.05.24 20:59:16 [ct2518]
#    - INPUT "LOB" with "RV"
#    - INPUT "State" with "PA"
# 199. Source step 0261 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 200. Source step 0262 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 201. Source step 0263 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 202. Source step 0264 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 203. Source step 0265 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 204. Source step 0266 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 205. Source step 0267 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 206. Source step 0268 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 207. Source step 0269 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 208. Source step 0270 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 23.05.24 20:59:16 [ct2518]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 209. Source step 0271 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 23.05.24 20:59:16 [ct2518]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 210. Source step 0272 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 23.05.24 20:59:16 [ct2518]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
# 211. Source step 0278 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 212. Source step 0279 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 213. Source step 0280 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 214. Source step 0299 "Close Cancel Page" in module "Check if Value too High appears" was disabled. Reason: 13.06.24 19:33:57 [ct2634]
#    - INPUT "Exit Without Saving" with "X"
# 215. Source step 0303 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:21:18 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 216. Source step 0304 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 31.05.24 14:19:56 [ct2634]
#    - INPUT "Existing or new TDS type" with "BaseRegression_PolicyData_Regression"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with "UW Rejection - RV- MD"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "MD"
# 217. Source step 0305 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:21:22 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 218. Source step 0306 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 219. Source step 0307 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 31.05.24 14:19:56 [ct2634]
#    - INPUT "Title" with "ExpertQuote*"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0308 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\UW Rejection-Recreational_MD_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0309 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0310 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0311 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0312 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\UW Rejection-Recreational_MD_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0313 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0314 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0315 CloseBrowser: I close the active browser
