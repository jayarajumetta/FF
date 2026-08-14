# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 108_UW_Non-Renewal_-_RV_-_NY_NY.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @non_renewal @New_York @Edge @manual @archive @automated
Feature: Execute UW Non-Renewal - RV - NY for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Non-Renewal - RV - NY workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Non-Renewal - RV - NY using representative iteration New York (NY)
    # Source step 0029: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3422-df06-668b-166357012130
    Given "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.LastName" in "Txt_Last"
    When I leave "Txt_Date of birth" blank
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I click "Btn_Create New Client"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0030: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3422-81ec-9ce7-cbd2f4208d9c
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072234777" in "Txt_Best phone_Account Owner"
    When I enter or select "TEST@VERIZON.NET" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I click "Btn_Single"
    When I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.City" in "Txt_owner.address.city_New"
    When I enter or select "NEW YORK" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0031: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3425-7873-293d-caf2360514ab
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW YORK]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_United Farm Family Insurance Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I select "Lnk_YES"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0032: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-2449-b188-88f218012985
    # Runtime control: Proposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0033: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-acea-c52b-8b5f0338bd52
    # Runtime control: Proposal Start_Proceed  > Then - Click Proceed
    When if the source runtime condition "Proposal Start_Proceed > Then - Click Proceed" is satisfied, I click "Btn_PROCEED"

    # Source step 0034: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-dee6-1a2d-309a841078a4
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0035: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-e3f8-0c03-bbff0dcb7900
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0036: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-fc5e-c1c0-ab1f333f3e48
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue" is satisfied, I enter the RUNTIME-DERIVED TDM value "NY_ClientData_Regression.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0037: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-12fc-3a31-50545f20ece1
    # Runtime control: Proposal Start-UW Popup > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-UW Popup > Condition - If Popup appears" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0038: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-acbb-446e-2074e69db65c
    # Runtime control: Proposal Start-UW Popup > Then- Click Use existing account
    When if the source runtime condition "Proposal Start-UW Popup > Then- Click Use existing account" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0040: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Auto Policy > 03 Prequalification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-cfa6-dccd-7d40a5769053
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0041: Driver Information - Add Existing Client & Next | Module: EQ||Driver Information
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-9c08-8639-c7c0b1efb8fc
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0042: EQ||Tabs - Capturing Quote Number | Module: EQ||Tabs
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-ab64-a03c-27e77ee6d038
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0043: TBox Set  - Trimming Quote Number | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-f7be-6efb-03faab01ea4b
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0044: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-8738-ec34-d64c318b21d5
    # Runtime control: If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected" is satisfied, "Prior Insurance_Checked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0045: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-e0fc-f87a-ebbd164e05c9
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

    # Source step 0046: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-b5bf-75c7-33575dc13866
    # Runtime control: If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary  > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected" is satisfied, "Prior Insurance_Unchecked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0047: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-9e93-a1cf-8b12c5362b92
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

    # Source step 0048: Driver Information Next - Click Next | Module: EQ||Driver Information Next
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-f2de-2687-247482367cf2
    When I click "Btn_Next"

    # Source step 0049: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-54a4-39f0-009a63f9fe48
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0050: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-f9ae-ee53-e316403c1d26
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0051: Vehicle Summary - Enter Vehicle Details | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-68bd-bf1c-5bef4ff53521
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "19UUA66296A043458" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    Then I wait until "Txt_PurchaseDate" is visible
    When I click "Txt_PurchaseDate"
    When I enter or select "10/23/2016" in "Txt_PurchaseDate"
    When I enter or select "\"^{a}\"" in "Txt_Odometer"
    Then I wait until "Txt_Odometer" exists
    When I click "Txt_Odometer"
    When I enter or select "120000" in "Txt_Odometer"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0052: Enter Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-a742-49e9-57863cff5fd9
    When I click "Btn_1988 Ford E350"
    When I click "Btn_Principal_2"
    When I click "Btn_Next"

    # Source step 0053: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-8d00-f0af-9883e41a6aef
    # Runtime control: Driver Assignment- UW Popup > Condition - If UW Popup appears at Driver Assignment Page
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - If UW Popup appears at Driver Assignment Page" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0054: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-dedf-a497-0b33d05fbdd5
    # Runtime control: Driver Assignment- UW Popup > Then - Select Continue and proceed  
    When if the source runtime condition "Driver Assignment- UW Popup > Then - Select Continue and proceed" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0055: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-e333-6c32-6a105dc83c30
    # Runtime control: Claims/Violations Popup > If Pop up Appears
    Then if the source runtime condition "Claims/Violations Popup > If Pop up Appears" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0056: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0aea-5471-226a12692c54
    # Runtime control: Claims/Violations Popup > Then - Click Continue & Next
    When if the source runtime condition "Claims/Violations Popup > Then - Click Continue & Next" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0057: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0e1b-91fd-926d0220713f
    # Runtime control: Claims/Violations Popup > Else - Click Next
    When if the source runtime condition "Claims/Violations Popup > Else - Click Next" is satisfied, I click "Btn_Next"

    # Source step 0058: Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-14db-551a-208a0d783803
    When I click "Btn_Next"

    # Source step 0059: Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-47b8-7d35-63043f60ce77
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0060: Additional Coverages - Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Auto Policy > 10 Additional Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-018d-5bb0-4e5b29a8b126
    When I click "Btn_BASIC"
    When I click "Btn_$100"
    When I select "Btn_No"
    When I select "Btn_No Coverage_Additional Death Benefit"
    When I click "Btn_Next"

    # Source step 0061: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 10 Additional Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0062: Pricing Details - Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Auto Policy > 11 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-b433-ddbd-1dbd5ae504e3
    Then I wait until "Hdr_Pricing Details_Header" is visible
    When I click "Btn_Next"

    # Source step 0063: Underwriting - Review & Continue | Module: <unresolved module>
    # Section: Process > Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-993d-63af-7ebd1c58b7ca
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"

    # Source step 0064: Additional Interest Summary - Click Next | Module: EQ||Additional Interest Summary
    # Section: Process > Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-6d7b-ef3f-70e86aea08ee
    When I click "btn_Next"

    # Source step 0065: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Auto Policy > 13 Billing | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Billing | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0071: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0072: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0076: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0077: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0078: Search Policy Number | Module: EU||Home
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0079: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0080: Click on Pricing | Module: EU||Applicant
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0082: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0084: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0086: Click on Home button | Module: EU||Pricing
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0088: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0089: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0090: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0091: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0092: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0093: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0095: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0096: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0097: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0098: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-5d13-6258-2333fade956a
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0099: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-cfcf-ed10-d0ce01781d21
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0100: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-9c85-efc7-2e34c1c0b68d
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0101: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-2fa9-6f83-27b984657645
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0102: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-3dd7-d24f-be2af07afa52
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0103: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-c6b4-907f-67ecc08a1632
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0104: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-c957-83f3-495e6cda3d5b
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0105: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-8d4b-589f-bf5bfd1c6acf
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0106: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-ab85-b5da-b0bbfa14c419
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0107: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-5a0a-4078-02ae5c62f2b3
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0108: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-8a8f-b4f8-48bcae94242d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0109: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0ae8-6bd0-eef625bae47b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0110: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-5b3c-de4c-cbbfdbb401ba
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0111: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-b59b-d89d-403cbbdb471e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0112: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0116: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-9ad5-f8e0-8cb4741966d3
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0117: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0624-ae66-6c869b581aca
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0118: EU||Home | Module: EU||Home
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0507-6fc8-08907883c126
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0119: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-2e44-a9a4-f03a1250ab3b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0120: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-52ac-3e9e-71fd482f14d4
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0121: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-b662-f40c-f890212fced2
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0122: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-ff5e-fad3-d1c1a6ca847e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0123: EU||Transact | Module: EU||Transact
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0963-e31d-0d1763ba0429
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0124: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-d1ab-fef1-86759b2af3cf
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0125: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-f351-ff31-00920af29697
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0126: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0435-380a-f168a6e53422
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0127: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-03da-657d-55f72a9ab750
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0128: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-d296-d26a-2deaa267870e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0129: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto Policy > 14 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-c354-13a9-0c51f3f0fd0d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0130: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-a300-6b4b-a57af883d743
    When I click "Btn_Launch To Checklist"

    # Source step 0132: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-9e5d-3f35-f2aefe7a4d4a
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0134: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-2047-fe63-4a004cd16795
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

    # Source step 0135: EQ||Agent List count capture - Capture Count of Documents to be Uploaded | Module: EQ||Agent List count capture
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-1525-bbd9-b3ac17abdb31
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0136: EQ||ECheckList - Click Auto/Cycle/RV Application | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-a1da-2635-dd33a848827f
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0137: TBox Save As - Enter File location | Module: TBox Save As
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-202a-af09-568ad189cd1d
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0138: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-a541-840c-0e4902181334
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0139: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Auto Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-9933-538a-094b0e63119a
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0141: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-3f85-06ae-84cf64e2dfdf
    When I close the active browser

    # Source step 0142: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-4634-9391-3dfb9957f348
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0143: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 16 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0144: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-0b27-c99e-cdc3308958c0
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0145: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-cefd-4b56-b042b217b806
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0153: Click on policy History | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 01 Recall Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-3dd7-20a9-f2876668ca5e
    When I click "Policy History"

    # Source step 0154: EQ||Quick Actions | Module: EQ||Quick Actions
    # Section: Process > Recreational Policy > 01 Recall Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-ea8e-528d-55160aed6812
    When I click "Btn_QUOTE ACTIONS"
    When I click "Btn_New Quote Same Client"

    # Source step 0155: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-787c-ffb8-7ac823adaa96
    When I click "Btn_Recreational Vehicle"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW YORK]}" in "Drp List_Proposal Rating State"
    When I select "Drp_Writing Company"
    When I click "Lbl_United Farm Family Insurance Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I select "Lnk_YES"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0156: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-db9d-aac9-607af7bcc1cb
    # Runtime control: Proposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0157: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-7535-9633-87384ed37d7b
    # Runtime control: Proposal Start_Proceed  > Then - Click Proceed
    When if the source runtime condition "Proposal Start_Proceed > Then - Click Proceed" is satisfied, I click "Btn_PROCEED"

    # Source step 0158: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Recreational Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-d075-86cd-958a096ed170
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0159: Enter Driver Information - Add Existing Client & Continue | Module: EQ||Driver Information
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-29d0-6fc3-2a7a90fd195e
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0160: Driver Summary - Enter Driver Details | Module: EQ||Driver Summary
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-29ad-cd7f-0ed99ccf0d54
    When I click "Btn_Primary Named Insured"
    When I click "Btn_Save and Continue"

    # Source step 0161: Driver Information- Click Next | Module: EQ||Driver Information Next
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-b5dc-35f1-de5cef0471a0
    When I click "Btn_Next"

    # Source step 0162: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-246b-9ee0-62e395939d43
    # Runtime control: Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0163: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-b469-3e18-070a1ccd26f9
    # Runtime control: Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0164: Vehicle Summary - Enter Vehcile Details | Module: EQ||Vehicle Summary
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3426-2d42-c389-420336ba4f70
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

    # Source step 0165: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 06 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-82f1-5e36-ec6c3baa3d82
    # Runtime control: Claims/Violations Popup > If Pop up Appears
    Then if the source runtime condition "Claims/Violations Popup > If Pop up Appears" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0166: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 06 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-e290-90c3-8cc2f0b82716
    # Runtime control: Claims/Violations Popup > Then - Click Continue & Next
    When if the source runtime condition "Claims/Violations Popup > Then - Click Continue & Next" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0167: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 06 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-ebc9-d232-3a276f913aad
    # Runtime control: Claims/Violations Popup > Else - Click Next
    When if the source runtime condition "Claims/Violations Popup > Else - Click Next" is satisfied, I click "Btn_Next"

    # Source step 0168: Discounts - Select Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Recreational Policy > 07 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-9bf6-18a2-69dc6f306424
    When I click "Btn_Next"

    # Source step 0169: Coverages - Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Recreational Policy > 08 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-e83f-a448-b7369e6fe0ff
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0170: Additional Coverages - Select Additional coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Recreational Policy > 08 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-4048-1b9b-8a349c2fe304
    When I select "Btn_Yes"
    When I click "Btn_Next"

    # Source step 0171: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 08 Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0172: Pricing Details - Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Recreational Policy > 09 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-4a0d-6cbd-c0fef045071d
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0173: Underwriting - Underwriting Review & Continue | Module: <unresolved module>
    # Section: Process > Recreational Policy > 10 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-a444-7da8-bb3ce12ace0c
    When I click "<unnamed value>"

    # Source step 0174: Additional Interest Summary - Click Next | Module: EQ||Additional Interest Summary
    # Section: Process > Recreational Policy > 10 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-9800-98fc-7b36ed7e9eee
    When I click "btn_Next"

    # Source step 0175: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0180: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 11 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0181: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0182: OpenUrl | Module: OpenUrl
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0186: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0187: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0188: Search Policy Number | Module: EU||Home
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0189: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0190: Click on Pricing | Module: EU||Applicant
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0191: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0192: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0193: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0194: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0195: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0196: Click on Home button | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0197: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0198: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0199: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0200: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0201: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0202: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0203: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0204: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0205: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0206: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0207: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 12 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0208: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-c3d8-888a-d1173962f5c3
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0209: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-f687-5041-17505dcaa19d
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0210: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-0e6a-ce7d-0ce61e1fd454
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0211: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-1abc-19ff-73b205ac5ed6
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0212: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-1fad-87ae-d4b52959d1d7
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0213: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-24cf-62ae-da702969330c
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0214: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-99e1-df30-79bee0360982
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0215: EQ||Submission | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-4683-2671-f9c09ed0ae8c
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0216: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-715f-c673-aefe38f6f5ea
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0217: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-3a0f-08d3-918b084dff6a
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0218: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-f798-fd6f-2587866647d0
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0219: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d04a-a646-c9b01968ecab
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0220: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-3ca4-ab09-11dbdc1da85c
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0221: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-7275-8ef8-ff5bf007547f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0222: OpenUrl | Module: OpenUrl
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0226: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-0a43-2f48-e9386a787905
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0227: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-2ab4-ad54-b2cec621318e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0228: EU||Home | Module: EU||Home
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d86c-63c0-17b329a80db7
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0229: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-fd3b-cdfd-1538bbabf1ca
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_RV"

    # Source step 0230: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-2ecf-e226-1d65d99fb1ce
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0231: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-63b4-0b5d-f65f9d64c44e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0232: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-022c-cd01-ad3c7420ccad
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0233: EU||Transact | Module: EU||Transact
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-1b34-02a2-9f0e33d154a6
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0234: EU||Applicant | Module: EU||Applicant
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-8dbf-4a96-04874b25a3bf
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0235: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-cc69-0805-0da7d06b9e17
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0236: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-cf35-a917-f0728f216425
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0237: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-59cf-8e09-063095363d04
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0238: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-b572-12b8-d6c560bfc429
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0239: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Recreational Policy > 12 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d6cf-7214-5da36f52b3e3
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0240: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-6b94-6dcf-f007e6cf0236
    When I click "Btn_Launch To Checklist"

    # Source step 0242: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-2f89-cebf-9786b933980b
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0244: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-90ef-68e7-28dae3aedb15
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

    # Source step 0245: EQ||Agent List count capture - Capture Count of Documents to be Uploaded | Module: EQ||Agent List count capture
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-f561-f282-78d2e5f50f5c
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0246: EQ||ECheckList - Click Auto/Cycle/RV Application | Module: EQ||ECheckList
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-650e-da0e-d43b3400d20a
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0247: TBox Save As - Enter File location | Module: TBox Save As
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-2e21-1eb5-4dbf6a4ec188
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0248: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Recreational Policy > 14 Launch checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-dfc1-0a78-d131e6f94400
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0249: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Recreational Policy > 14 Launch checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-82c1-1ddb-0e6eef619cee
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0251: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 14 Launch checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-c3c5-9e15-301f436782ee
    When I close the active browser

    # Source step 0252: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Recreational Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-7d19-8b95-9d7ee6472587
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0253: TBox Wait | Module: TBox Wait
    # Section: Process > Recreational Policy > 16 Transmit | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0254: Submission - Capturing Policy Number,Effective Date, Premium Value | Module: EQ||Submission
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-27ea-ebb3-209fcebc8778
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0255: TestData - Save Policy Number, Effective Date to TDM | Module: TestData - Create & provide new item
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-6c3b-6f8d-09358ae2f605
    When I retrieve test data through TDM operation "TestData - Save Policy Number, Effective Date to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0256: Set LOB & State | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > TDS Validations > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "RV" as runtime value "LOB"
    When I retain hard-coded value "NY" as runtime value "State"

    # Source step 0266: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Process > Recreational Policy > TDS Validations > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0267: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > TDS Validations > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0268:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > TDS Validations > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0269: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-f37d-dd6c-4bd0b4e8fd8c
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0270: Submission - Save & Exit Policy | Module: EQ||Submission
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-5d3f-1d87-68076fbaae8e
    When I click "Btn_Save and Exit"

    # Source step 0271: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0272: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0273: OpenUrl | Module: OpenUrl
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0277: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-6932-ae5e-a6e63381b7d8
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0278: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d12b-bb02-65ba5bd69ba9
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0279: Search Policy | Module: EU||Home
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-b16a-fc84-dfd77159f50b
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0280: Click Policy holder name | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Non Renewal > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d122-d94b-5c96bfc91076
    When I click "Lnk_Insured Name"
    When I click "Lnk_RV"

    # Source step 0281: Click Non-Renew Transaction | Module: EU|Transaction Type
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-be63-f79c-9ae511c0dc6f
    When I click "expand"
    When I select "Non-Renew"
    When I click "Go"

    # Source step 0282: Capturing Eff Date & Schedule date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-242c-81fe-2b45c67ebeb7
    When I capture "Value" from "Effective Date" as runtime value "EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):" as runtime value "Schedule Date"

    # Source step 0283: Set Dates | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-66e4-c117-5b258d3ea048
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]}" as runtime value "ScheduledDate"
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][-25d][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0284: Start PowerShell | Module: TBox Start Program
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-704c-34c7-7dede225a7cf
    And I run program or command "powershell.exe"

    # Source step 0285: Execute PowerShellCommand 1 | Module: TBox Send Keys
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-e7fb-7ea1-3b2ed002ef62
    When I enter or select "*PowerShell*" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\"\"\"\"$TimeSpan=([DateTime]'{B[ScheduledDate]}' - [DateTime]'{B[EffectiveDate]}')\"\"\"\";~" in "Keys"

    # Source step 0286: Execute PowerShellCommand 2  | Module: TBox Send Keys
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-71af-2645-8865f1928b4f
    When I enter or select "*PowerShell*" in "Caption"
    When I enter or select "$TimeSpan | Clip~" in "Keys"

    # Source step 0287: TBox Wait | Module: TBox Wait
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0288: Get Days Difference | Module: TBox Clipboard
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-ce3b-30f4-20c3744a9291
    Then "Value" should equal "Days : {XB[DayDifference]} *"

    # Source step 0289: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-b2d9-9be4-78b56008ad50
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "ScheduledDates"
    And I use TDM parameter "Alias name (item)" with "ScheduledDates"
    And I use TDM parameter "Data search filter > TCName" with "UW Non-Renewal - RV - NY"
    And I use TDM parameter "Data search filter > State" with "NY"
    And I use TDM parameter "Data search filter > LOB" with "RV"

    # Source step 0290: Retriving Expected No.of days from TDM | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-7ac2-ab9b-1e4dae1486f2
    When I retrieve and retain the RUNTIME-DERIVED TDM value "ScheduledDates.No of Days Workaround" as runtime value "Expected Days"

    # Source step 0291: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-f198-4945-5579b4c9275e
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Condition
    Then if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[DayDifference]} == {B[Expected Days]}"

    # Source step 0292: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-3097-62bf-597853ff995d
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Then
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Then" is satisfied, I retain hard-coded value "The Actual No.of Days is equal to Expected No.of Days" as runtime value "No.of Days Equal"

    # Source step 0293: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-20bd-4b04-c766bb604b48
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Else
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Else" is satisfied, I retain hard-coded value "The Actaul No.of Days are not equal to Expected No.of Days" as runtime value "No.of Days not Equal"

    # Source step 0294: Add 60 days | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-7d56-d1b1-ace0d98a4af6
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Schedule Date]}][-60d][MM/dd/yyyy]}" as runtime value "Future Date"

    # Source step 0295: Set the Scheduled Date after the Effective date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-8a1b-f21e-79e76eef3070
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{B[Future Date]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0296: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-e971-5ada-0472aace9c45
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0297: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-494d-b898-faa8974b8a89
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0298: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-bb67-471e-f8abaa5eb880
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0299: Set the Scheduled Date to Current Date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-ea83-b72c-1724b787bdca
    When I enter the RUNTIME-DERIVED date from Tosca expression "{CLICK}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[{DATE[][][MM/dd/yyyy]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0300: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-23f3-a1ed-6c2cae127532
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0301: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-cf08-6c88-7545bb7b499a
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0302: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to Current Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-3de4-8ed0-2affd11a3638
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0303: Exit the TransACT Page | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Go Back to TransACT Page & Click Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-b4b7-da5c-b662aeb49555
    When I click "Exit Without Saving"

    # Source step 0304: Select Non Renew TransACT | Module: EU|Transaction Type
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Go Back to TransACT Page & Click Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-b8fb-c295-5d0c4a242624
    When I click "expand"
    When I select "Non-Renew"
    When I click "Go"

    # Source step 0305: Capturing Eff Date & Schedule date | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Go Back to TransACT Page & Click Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-8917-8d71-70cb4443c4f9
    When I capture "Value" from "Effective Date" as runtime value "EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):" as runtime value "Schedule Date"

    # Source step 0306: Set the date to Less than Expected No of days | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-5a74-e9c0-eac858cda1cf
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Schedule Date]}][+8d][MM/dd/yyyy]}" as runtime value "Add 8 Days"

    # Source step 0307: Set the Scheduled Date less than Expected No.of Days | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d442-9142-34e3946d9c21
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{B[Add 8 Days]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0308: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-ea33-3080-51dec9242b27
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0309: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-0b4b-1f82-6d738a4e901c
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0310: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-38fe-899c-dcbc5310f6ea
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0311: Set the date to More than Expected No of days | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-7b56-2994-f430ab21c5cd
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Schedule Date]}][-6d][MM/dd/yyyy]}" as runtime value "Minus 6 Days"

    # Source step 0312: Set the Scheduled Date more than Expected No.of Days | Module: Schedule Dates for Non-Renewal
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-3978-6d7c-08e2fc344fe8
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{B[Minus 6 Days]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0313: Value too High | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-7733-d2dd-ea58f326859a
    # Runtime control: Check if System Prevents > Condition
    Then if the source runtime condition "Check if System Prevents > Condition" is satisfied, "Value too high" should equal "ValueTooHigh"

    # Source step 0314: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-6175-6a96-7899606d3fc8
    # Runtime control: Check if System Prevents > Then
    When if the source runtime condition "Check if System Prevents > Then" is satisfied, I retain hard-coded value "Pop up displayed" as runtime value "Pass"

    # Source step 0315: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction > Set the Scheduled Date to less than or more than Expected Days | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-6ff7-3a48-25368bfa0606
    # Runtime control: Check if System Prevents > Else
    When if the source runtime condition "Check if System Prevents > Else" is satisfied, I retain hard-coded value "No pop up displayed" as runtime value "Fail"

    # Source step 0316: click Non Renew Detailed reason | Module: Check if Value too High appears
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3435-d06c-d995-0eab0fac6003
    When I click "Detailed Reason_expand"
    When I click "Claims Review"

    # Source step 0317: Select  & Cick Schedule | Module: EU|Schedule
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3446-9c6e-b7cc-1d2696a43979
    When I enter or select "True" in "MVR_1"
    When I click "Schedule"

    # Source step 0318: TBox Wait | Module: TBox Wait
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3446-51e7-7224-95ab1cc497aa
    When I wait "5000" milliseconds

    # Source step 0319: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > UW Non Renewal > UW Non Renewal Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3446-74bc-fc8d-e9d7371e21a8
    When I close the active browser

    # Source step 0320: Close the Express UI Page | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3447-bf16-50c3-a57255e53abd
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
# 5. Source step 0018 "Unlock TDS Type" in module "Old_TestData - Expert module" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 6. Source step 0019 "Find Client Data with Sno" in module "Old_TestData - Find & provide item" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - INPUT "Existing TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
#    - INPUT "Data search filter > Sno" with the unresolved source parameter "Sno" (not supplied by this reusable-block invocation)
# 7. Source step 0020 "Set CaseName" in module "TBox Set Buffer" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - INPUT "CaseName" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 8. Source step 0021 "Check If CaseName is NULL" in module "TBox Set Buffer" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - VERIFY "CaseName" with ""
# 9. Source step 0022 "Unlock TDS Type" in module "Old_TestData - Expert module" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 10. Source step 0023 "Find Client Data with Sno" in module "Old_TestData - Find & provide item" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - INPUT "Existing TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
#    - INPUT "Alias name (item)" with captured runtime value "TCName"
#    - INPUT "Data search filter > Sno" with the unresolved source parameter "Sno" (not supplied by this reusable-block invocation)
# 11. Source step 0024 "TestData - Update TCName" in module "TestData - Update item" was disabled. Reason: 24.05.24 10:57:55 [ct2518]
#    - INPUT "Existing alias name (item)" with captured runtime value "TCName"
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > Processed" with "Y"
# 12. Source step 0030 field "Btn_Married" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0030 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0030 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 15. Source step 0030 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 16. Source step 0036 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 17. Source step 0039 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 18. Source step 0041 field "Btn_(Existing Client)*" in "Driver Information - Add Existing Client & Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0045 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0045 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 21. Source step 0045 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0045 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 23. Source step 0045 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0045 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0045 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 26. Source step 0045 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0045 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 28. Source step 0045 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 29. Source step 0045 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 30. Source step 0045 field "Btn_PriorInsurance_Yes" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0045 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0045 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0045 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0047 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0047 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 36. Source step 0047 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0047 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0047 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0047 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 40. Source step 0047 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 41. Source step 0047 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0047 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 43. Source step 0047 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 44. Source step 0047 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 45. Source step 0047 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0047 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 47. Source step 0047 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0049 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 49. Source step 0049 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0050 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0051 field "Txt_Odometer" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 52. Source step 0051 field "Btn_Add Additional Vehicle" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0053 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0064 field "Btn_Add Additional Interest" in "Additional Interest Summary - Click Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0064 field "Btn_Next" in "Additional Interest Summary - Click Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0064 field "<unnamed value>" in "Additional Interest Summary - Click Next" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0064 field "<unnamed value>" in "Additional Interest Summary - Click Next" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 58. Source step 0066 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 59. Source step 0067 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 60. Source step 0068 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 61. Source step 0069 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 62. Source step 0073 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 63. Source step 0074 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 64. Source step 0075 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 65. Source step 0113 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 66. Source step 0114 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 67. Source step 0115 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 68. Source step 0131 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 69. Source step 0132 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 70. Source step 0132 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 71. Source step 0132 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 72. Source step 0133 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 73. Source step 0135 field "DIV_Agent Documents Count" in "EQ||Agent List count capture - Capture Count of Documents to be Uploaded" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 74. Source step 0140 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 75. Source step 0146 "Click Save and Exit" in module "EQ||Submission" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - INPUT "Btn_Save and Exit" with "X"
# 76. Source step 0147 "TBox Partial Buffer_Trim Policy Number" in module "TBox Partial Buffer" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - INPUT "Buffer" with "Policy_Number"
#    - INPUT "Value" with the RUNTIME-DERIVED buffer expression "{TRIM[{B[Policy Number]}]}"
# 77. Source step 0148 "Verifiy if integration page appears" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - VERIFY "Close Quote" with "True"
# 78. Source step 0149 "Close Quote" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - INPUT "Close Quote" with "X"
# 79. Source step 0150 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with the RUNTIME-DERIVED buffer expression "{Click}{Sendkeys[{B[Policy_Number]}]}"
#    - INPUT "Btn_Search" with "X"
# 80. Source step 0151 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "Policy_Number"
#    - INPUT "Btn_Search" with "X"
# 81. Source step 0152 "EQ||Quick Actions" in module "EQ||Quick Actions" was disabled. Reason: 30.05.24 23:25:10 [ct2518]
#    - INPUT "Btn_QUOTE ACTIONS" with "{Invoke[Click]}"
#    - INPUT "Btn_New Quote Same Client" with "{Invoke[Click]}"
# 82. Source step 0159 field "Btn_(Existing Client)*" in "Enter Driver Information - Add Existing Client & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0160 field "Lbl_Gender" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0160 field "Lbl_Gender" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 85. Source step 0160 field "Btn_Male" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0160 field "Btn_Male" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 87. Source step 0160 field "Btn_Male" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0160 field "Btn_Single" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 89. Source step 0160 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 90. Source step 0160 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 91. Source step 0160 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "{Click}{Sendkeys[22]}"
# 92. Source step 0160 field "Txt_Years Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: ""
# 93. Source step 0160 field "Txt_Months Licensed in Current State" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 94. Source step 0160 field "Txt_Date License" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 95. Source step 0160 field "Btn_FinancialResponsibility_No" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 96. Source step 0160 field "Btn_PriorInsurance_No" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 97. Source step 0160 field "Btn_Did Not Have Insurance" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 98. Source step 0160 field "Lnk_UWR_CONTINUE" in "Driver Summary - Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 99. Source step 0162 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0162 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 101. Source step 0163 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 102. Source step 0164 field "Lbl_VIN LABEL" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 103. Source step 0164 field "Btn_Automobile" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 104. Source step 0164 field "Btn_Trailbike" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 105. Source step 0164 field "Btn_Cycle_Customizatioin_No" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 106. Source step 0164 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 107. Source step 0164 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 108. Source step 0164 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 109. Source step 0164 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: "60"
# 110. Source step 0164 field "Txt_Odometer" in "Vehicle Summary - Enter Vehcile Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 111. Source step 0173 field "<unnamed value>" in "Underwriting - Underwriting Review & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0173 field "<unnamed value>" in "Underwriting - Underwriting Review & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 113. Source step 0176 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 114. Source step 0177 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 115. Source step 0178 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 116. Source step 0179 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 117. Source step 0183 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 118. Source step 0184 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 119. Source step 0185 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 120. Source step 0223 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 121. Source step 0224 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 122. Source step 0225 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 123. Source step 0241 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 124. Source step 0242 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 125. Source step 0242 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 126. Source step 0242 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 127. Source step 0243 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 128. Source step 0245 field "DIV_Agent Documents Count" in "EQ||Agent List count capture - Capture Count of Documents to be Uploaded" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 129. Source step 0250 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 130. Source step 0257 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 131. Source step 0258 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 132. Source step 0259 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 133. Source step 0260 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 134. Source step 0261 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 135. Source step 0262 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 136. Source step 0263 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 137. Source step 0264 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 138. Source step 0265 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 139. Source step 0274 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 140. Source step 0275 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 141. Source step 0276 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0321 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\UW Rejection Cycle_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0322 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0323 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0324 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0325 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\UW Rejection Cycle_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0326 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0327 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0328 CloseBrowser: I close the active browser
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 9. Source recovery step 0329 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 10. Source recovery step 0330 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 11. Source recovery step 0331 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 12. Source recovery step 0332 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EQ sign out and Close browser
# 13. Source recovery step 0333 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 14. Source recovery step 0334 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 15. Source recovery step 0335 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 16. Source recovery step 0336 CloseBrowser: I close the active browser
