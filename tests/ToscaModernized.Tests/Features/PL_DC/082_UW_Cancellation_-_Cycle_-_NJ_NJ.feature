# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 082_UW_Cancellation_-_Cycle_-_NJ_NJ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @cancellation @New_Jersey @Edge @manual @archive @automated
Feature: Execute UW Cancellation - Cycle - NJ for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Cancellation - Cycle - NJ workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Cancellation - Cycle - NJ using representative iteration New Jersey (NJ)
    # Source step 0029: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Cycle Policy > 01 Enter Client & Account Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-b688-89d9-2db9aaf46afb
    Given "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.LastName" in "Txt_Last"
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
    # Section: Process > Cycle Policy > 01 Enter Client & Account Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-69d4-7323-36563f302be3
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072231575" in "Txt_Best phone_Account Owner"
    When I enter or select "TEST@AOL.COM" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I select "Btn_Married"
    When I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.City" in "Txt_owner.address.city_New"
    When I enter or select "NEW JERSEY" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0031: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-b693-9dd2-fe10ba4fdeff
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW JERSEY]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0032: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-c05d-5895-f03a98e8e42f
    # Runtime control: Proposal Start_Proceed  - If Popup appears > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start_Proceed - If Popup appears > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0033: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-0167-7df9-305fe44d8aae
    # Runtime control: Proposal Start_Proceed  - If Popup appears > Then - Click Proceed
    When if the source runtime condition "Proposal Start_Proceed - If Popup appears > Then - Click Proceed" is satisfied, I click "Btn_PROCEED"

    # Source step 0034: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-b86b-2345-10b968202c58
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0035: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-bae7-27ae-3824ca4bc362
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0036: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-f2a8-8402-70dbf3f52333
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue" is satisfied, I enter the RUNTIME-DERIVED TDM value "NJ_ClientData_Regression.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0037: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-b21a-ac9d-324720c0c287
    # Runtime control: Proposal Start-UW Popup - If Popup appears > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-UW Popup - If Popup appears > Condition - If Popup appears" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0038: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-4c1f-ba64-f03bab9f110b
    # Runtime control: Proposal Start-UW Popup - If Popup appears > Then - Click on Use existing account
    When if the source runtime condition "Proposal Start-UW Popup - If Popup appears > Then - Click on Use existing account" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0040: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Cycle Policy > 03 Prequalification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-da3a-a637-4bc0c93556f5
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0041: EQ||Tabs - Capturing Quote Number | Module: EQ||Tabs
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-9f02-acec-1d25ebfa14de
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0042: TBox Set Buffer - Trimming Quote Number | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-fe78-79e3-189950017322
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0043: Enter Driver Information - Select Existing Client | Module: EQ||Driver Information
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-eaed-a1cd-209763ad2802
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0044: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-eaac-0050-8f0d54bbfcb7
    # Runtime control: If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected" is satisfied, "Prior Insurance_Checked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0045: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-0a14-9d75-7752c1601b87
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
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-d19e-540a-ef5caa5b26aa
    # Runtime control: If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary  > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected" is satisfied, "Prior Insurance_Unchecked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0047: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-a4d7-28f1-78ae24996d89
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

    # Source step 0048: Driver Information - Click Next | Module: EQ||Driver Information Next
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-9678-5da2-14615289aa62
    When I click "Btn_Next"

    # Source step 0049: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-09fb-ae31-40ccb47e1892
    # Runtime control: Vehicle Information_VehicleSelection > Condition - If vehicle is selected
    Then if the source runtime condition "Vehicle Information_VehicleSelection > Condition - If vehicle is selected" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0050: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-1d6f-21bd-e5ae630883b0
    # Runtime control: Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    When if the source runtime condition "Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0051: Vehicle Summary - Enter Vehicle Details | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-4873-b297-c39ba0152902
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

    # Source step 0052: Enter Driver Assignment - Select Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-613e-7319-eb1863d99854
    When I click "Btn_2014 Harley Davidson FLHXS_V1"
    Then I wait until "Btn_Principal_1" exists
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0053: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-c274-8f90-f9cd658ea4a7
    # Runtime control: Driver Assignment- UW Popup > Condition - If UW Popup appears at Driver Assignment Page
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - If UW Popup appears at Driver Assignment Page" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0054: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-f65c-5394-c11106867cc1
    # Runtime control: Driver Assignment- UW Popup > Then - Select Continue and proceed  
    When if the source runtime condition "Driver Assignment- UW Popup > Then - Select Continue and proceed" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0055: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-a861-dd59-2d154e356e71
    # Runtime control: Claims/Violations Popup > If Pop up Appears
    Then if the source runtime condition "Claims/Violations Popup > If Pop up Appears" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0056: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-5e56-a32f-e7bafbae04ae
    # Runtime control: Claims/Violations Popup > Then - Click Continue & Next
    When if the source runtime condition "Claims/Violations Popup > Then - Click Continue & Next" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0057: Claims/Violations Popup - Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-f877-7f43-a5a8f4caedd0
    # Runtime control: Claims/Violations Popup > Else - Click Next
    When if the source runtime condition "Claims/Violations Popup > Else - Click Next" is satisfied, I click "Btn_Next"

    # Source step 0058: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-c17e-7748-302312a4114c
    # Runtime control: If - Residential Property Appears > Condition - Residentail Property Appears
    Then if the source runtime condition "If - Residential Property Appears > Condition - Residentail Property Appears" is satisfied, "Btn_Residential Property Owner" should be visible

    # Source step 0059: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-9cb0-6932-40324550a320
    # Runtime control: If - Residential Property Appears > Then - Select Reseidential Property Owner
    When if the source runtime condition "If - Residential Property Appears > Then - Select Reseidential Property Owner" is satisfied, I click "Btn_Residential Property Owner"

    # Source step 0060: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-d0d9-4f98-3a972b37c007
    # Runtime control: If - Proof Of Insurance Appears > Condition - Proof Of Insurance Appears
    Then if the source runtime condition "If - Proof Of Insurance Appears > Condition - Proof Of Insurance Appears" is satisfied, "Btn_No Proof of Prior Insurance" should be visible

    # Source step 0061: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-9e7b-9f71-54d165a2f458
    # Runtime control: If - Proof Of Insurance Appears > Then - Select No-Proof of Insurance
    When if the source runtime condition "If - Proof Of Insurance Appears > Then - Select No-Proof of Insurance" is satisfied, I select "Btn_No Proof of Prior Insurance"

    # Source step 0062: Discounts - Enter Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-181b-f211-f2c5f06202fc
    When I click "Btn_Next"

    # Source step 0063: Coverages - Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-dbe8-77d2-ed63ab8d7f8e
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0064: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy > 10 Additional Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-04dd-e14e-540e2ff67633
    When I click "Btn_$25,005"
    When I click "Btn_Next"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 10 Additional Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0066: Enter Pricing Details - Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy > 11 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-8b40-d594-66a4cf3ed718
    Then I wait until "Hdr_Pricing Details_Header" is visible
    When I click "Btn_Next"

    # Source step 0067: Underwriting - Underwriting Review & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-a9d7-03d3-50846d822af4
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"

    # Source step 0068: Additional Interest - Click Next | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-fb94-80ee-c5630a1b0e0d
    When I click "btn_Next"

    # Source step 0069: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Cycle Policy > 13 Billing | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Billing | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0075: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0076: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0080: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0081: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0082: Search Policy Number | Module: EU||Home
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0083: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"
    When I enter the unresolved source parameter "PersonalAuto" (not supplied by this reusable-block invocation) in "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0084: Click on Pricing | Module: EU||Applicant
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0086: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0088: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0090: Click on Home button | Module: EU||Pricing
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0091: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0092: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0093: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0094: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0095: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0096: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0097: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0099: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0100: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0101: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 14 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0102: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-86f6-29e1-6f151ec3233f
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0103: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-6aa2-c2c7-a20969e40282
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0104: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-8d33-abae-84bc5b9ecaa3
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0105: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-01a9-54a1-85d81162ff26
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0106: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-f6d3-3ebe-6fd1da024d90
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If > Condition" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0107: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-2cb0-7e3e-e583d51adf9c
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If > Then
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0108: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-0cc0-2697-71021e3fa3d7
    # Runtime control: Check UW comments for level 2 > Condition-check for Refer to UW
    Then if the source runtime condition "Check UW comments for level 2 > Condition-check for Refer to UW" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0109: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-adac-e13c-cc4a8e1dbf38
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Condition
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Condition" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0110: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3309-74c3-36ab-d962d01c5858
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0111: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-fcf1-f148-7befb2c5aa10
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0112: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-abd1-5999-ae3b3930e794
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0113: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-cc5e-ec92-30e87c341f58
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then > If > Condition
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then > If > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0114: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-faac-1adc-7c379ef268b9
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then > If > Then
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then > If > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0115: Refer to UW | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-03bd-29c8-b1a21ae299d5
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0116: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0120: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-b097-10df-482a6f676428
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0121: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-9015-0a02-7b1c7a77cd03
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0122: EU||Home | Module: EU||Home
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-256f-2382-456ebc0101ad
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0123: EU||Click on motorcycle/Auto | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-f0aa-850b-793aceeed6c3
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    Then I wait until "Lnk_Motorcycle" is visible
    When I click "Lnk_Motorcycle"

    # Source step 0124: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3318-43e2-d171-2042b27389ef
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0125: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-f183-00a1-8be5e50e3f3f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0126: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-4cf0-149e-e066beeb1f6c
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0127: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-6da3-94bc-3928d2aad0a0
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and continue
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and continue" is satisfied, I select "Btn_Yes"

    # Source step 0128: EU||Applicant | Module: EU||Applicant
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-eba9-14d8-d1df65bf8353
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0129: EU||Pricing | Module: EU||Pricing
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-4b78-019c-e1b859bbeb59
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" exists
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0130: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-7052-ad95-9fb7d8007bf5
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0131: EQ||Save and Exit | Module: EQ||Submission
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-3f4b-f6eb-d58cd556a3a7
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0132: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3319-6cd1-9ecf-4449fade55de
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0133: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Cycle Policy > 14 Submission > Express UI_UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-f791-01c4-1109e6ef1ac0
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0134: Launch to Checklist | Module: EQ||Submission
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-5371-1b34-80ea8098c28c
    When I click "Btn_Launch To Checklist"

    # Source step 0136: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-c195-5adb-3ca9f38e3e5b
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0138: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-ab85-7fde-94b9421d2e86
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

    # Source step 0139: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-b7ba-e2d9-0175e43cefab
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0140: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-789a-e072-6991d4f2a8a6
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0141: TBox Save As | Module: TBox Save As
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-c265-5bfa-1173fe974a9b
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0142: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-5bda-4dab-2ccca7560804
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0143: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Cycle Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-067c-5a74-6eba6dae6799
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0145: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-4c2c-34af-8417e3323191
    When I close the active browser

    # Source step 0146: EQ||Click on Transmit | Module: EQ||Submission
    # Section: Process > Cycle Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-d50e-482e-4612c33feac5
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0147: Back to Submission page - Capture Policy Number, Effective Date, Policy Premium | Module: EQ||Submission
    # Section: Process > Cycle Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-b5ca-099a-c2a11052f821
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0148: TestData - Save the Policy Number,Effective Date, Premium to TDM  | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-55c8-68b4-d72d66b63a8e
    When I retrieve test data through TDM operation "TestData - Save the Policy Number,Effective Date, Premium to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0149: Set LOB & State | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 17 TDS Validation > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Cycle" as runtime value "LOB"
    When I retain hard-coded value "NJ" as runtime value "State"

    # Source step 0159: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Process > Cycle Policy > 17 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0160: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 17 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0161:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 17 TDS Validation > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0162: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-3f3e-a756-cd12b2600004
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0163: Submission - Save & Exit Policy | Module: EQ||Submission
    # Section: Process > Cycle Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-1a8a-9fa1-0c8bccf8e2fb
    When I click "Btn_Save and Exit"

    # Source step 0164: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Process > Cycle Policy > 17 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0165: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 17 TDS Validation | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

    # Source step 0166: OpenUrl | Module: OpenUrl
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0170: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-e6b9-7f73-c63d2f4de73c
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0171: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-669d-5b55-5b132ddacd0a
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0172: Search Policy | Module: EU||Home
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-f63e-078b-ecbf8feccfee
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0173: Click Policy holder name | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Cancellation > Launch Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-413d-6c50-d973fd814d40
    When I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"

    # Source step 0174: Click Transaction Type | Module: EU|Transaction Type
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-669e-a020-13d616227795
    When I click "expand"
    When I click "Cancel"
    When I click "Go"

    # Source step 0175: Click Transaction Reason & Detailed Reason | Module: Check if Value too High appears
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-fabb-7fc4-b16d937ff8d5
    When I click "Transaction Reason expand"
    When I click "Underwriting Reasons - Cancellation"
    When I click "Detailed Reason_expand"
    When I click "Claims Review"

    # Source step 0176: Set the Scheduled Date to Current Date | Module: Schedule Dates for Cancellation_Rejection
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-8c32-5b13-be0a71aa68af
    When I enter the RUNTIME-DERIVED date from Tosca expression "{CLICK}{SENDKEYS[\"^{a}\"]}{SENDKEYS[{DATE[][][MM/dd/yyyy]}]}{TAB}" in "Schedule Date (optional):"

    # Source step 0177: TBox Wait | Module: TBox Wait
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-dc11-fa6a-ec4242c6aee1
    When I wait "10000" milliseconds

    # Source step 0178: Capture Effective and Scheduled Dates | Module: Schedule Dates for Cancellation_Rejection
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-767f-48e9-075692f1267c
    When I capture "Value" from "Effective Date_1" as runtime value "Cancellation_EffectiveDate"
    When I capture "Value" from "Schedule Date (optional):_1" as runtime value "Cancellation_ScheduledDate"

    # Source step 0179: Set Dates | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-66e4-c117-5b258d3ea048
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]}" as runtime value "ScheduledDate"
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{DATE[][-25d][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0180: Start PowerShell | Module: TBox Start Program
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-704c-34c7-7dede225a7cf
    And I run program or command "powershell.exe"

    # Source step 0181: Execute PowerShellCommand 1 | Module: TBox Send Keys
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-e7fb-7ea1-3b2ed002ef62
    When I enter or select "*PowerShell*" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\"\"\"\"$TimeSpan=([DateTime]'{B[ScheduledDate]}' - [DateTime]'{B[EffectiveDate]}')\"\"\"\";~" in "Keys"

    # Source step 0182: Execute PowerShellCommand 2  | Module: TBox Send Keys
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-71af-2645-8865f1928b4f
    When I enter or select "*PowerShell*" in "Caption"
    When I enter or select "$TimeSpan | Clip~" in "Keys"

    # Source step 0183: TBox Wait | Module: TBox Wait
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0184: Get Days Difference | Module: TBox Clipboard
    # Section: Process > UW Cancellation > UW Cancellation Transaction > Difference Between Two Dates > Find Difference Between Scheduled Date and Effective Date | Reusable flow: Auto |24 EQ | Find Difference Between Scheduled Date and Effective Date | Source XTestStep: 3a19dd55-d416-ce3b-30f4-20c3744a9291
    Then "Value" should equal "Days : {XB[DayDifference]} *"

    # Source step 0185: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-b2d9-9be4-78b56008ad50
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "ScheduledDates"
    And I use TDM parameter "Alias name (item)" with "ScheduledDates"
    And I use TDM parameter "Data search filter > TCName" with "UW Cancellation - Cycle - NJ"
    And I use TDM parameter "Data search filter > State" with "NJ"
    And I use TDM parameter "Data search filter > LOB" with "Cycle"

    # Source step 0186: Retriving Expected No.of days from TDM | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-7ac2-ab9b-1e4dae1486f2
    When I retrieve and retain the RUNTIME-DERIVED TDM value "ScheduledDates.No of Days Workaround" as runtime value "Expected Days"

    # Source step 0187: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-f198-4945-5579b4c9275e
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Condition
    Then if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[DayDifference]} == {B[Expected Days]}"

    # Source step 0188: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-3097-62bf-597853ff995d
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Then
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Then" is satisfied, I retain hard-coded value "The Actual No.of Days is equal to Expected No.of Days" as runtime value "No.of Days Equal"

    # Source step 0189: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: Auto |26 EQ | Retriving No.Of Days from TDM and Comparing Actual No.of Days to Expected No.of Days | Source XTestStep: 3a19dd55-d425-20bd-4b04-c766bb604b48
    # Runtime control: Check If Actaul No.of Days is equal to Expected No.of Days > Else
    When if the source runtime condition "Check If Actaul No.of Days is equal to Expected No.of Days > Else" is satisfied, I retain hard-coded value "The Actaul No.of Days are not equal to Expected No.of Days" as runtime value "No.of Days not Equal"

    # Source step 0190: Select  & Click Schedule | Module: EU|Schedule
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-8c6c-43f7-a78b6aba8898
    When I enter or select "True" in "MVR_1"
    When I click "Schedule"

    # Source step 0191: TBox Wait | Module: TBox Wait
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-f787-1b7e-4745575713f0
    When I wait "5000" milliseconds

    # Source step 0192: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > UW Cancellation > UW Cancellation Transaction | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-7beb-b2f0-b76657b73b04
    When I close the active browser

    # Source step 0193: Close the Express UI Page | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-331a-085e-6346-d80c452bc6e0
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
# 5. Source step 0018 "Unlock TDS Type" in module "Old_TestData - Expert module" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 6. Source step 0019 "Find Client Data with Sno" in module "Old_TestData - Find & provide item" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - INPUT "Existing TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
#    - INPUT "Data search filter > Sno" with the unresolved source parameter "Sno" (not supplied by this reusable-block invocation)
# 7. Source step 0020 "Set CaseName" in module "TBox Set Buffer" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - INPUT "CaseName" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 8. Source step 0021 "Check If CaseName is NULL" in module "TBox Set Buffer" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - VERIFY "CaseName" with ""
# 9. Source step 0022 "Unlock TDS Type" in module "Old_TestData - Expert module" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
# 10. Source step 0023 "Find Client Data with Sno" in module "Old_TestData - Find & provide item" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - INPUT "Existing TDS type" with the unresolved source parameter "TDSTableName" (not supplied by this reusable-block invocation)
#    - INPUT "Alias name (item)" with captured runtime value "TCName"
#    - INPUT "Data search filter > Sno" with the unresolved source parameter "Sno" (not supplied by this reusable-block invocation)
# 11. Source step 0024 "TestData - Update TCName" in module "TestData - Update item" was disabled. Reason: 22.05.24 11:37:28 [ct2518]
#    - INPUT "Existing alias name (item)" with captured runtime value "TCName"
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > Processed" with "Y"
# 12. Source step 0030 field "Btn_Single" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: a blank value
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
# 18. Source step 0043 field "Btn_(Existing Client)*" in "Enter Driver Information - Select Existing Client" was disabled. Reason:  
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
# 51. Source step 0051 field "Btn_SelectVehicle_Option1" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 52. Source step 0051 field "Btn_Automobile" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0051 field "Btn_Trailbike" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 54. Source step 0051 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0051 field "Btn_Pleasure" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0051 field "Btn_No_non-factory additions, alterations, or modifications" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0051 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 58. Source step 0051 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 59. Source step 0051 field "Lbl_Does this vehicle have any customized equipment?" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0051 field "Btn_Does this Vehicle" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "No"
# 61. Source step 0051 field "Btn_Pleasure/Work Use" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0051 field "Btn_Pleasure/Work Use" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 63. Source step 0051 field "Txt_PurchaseDate" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 64. Source step 0051 field "Txt_PurchaseDate" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "07/10/2003"
# 65. Source step 0051 field "Txt_Odometer" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 66. Source step 0051 field "Txt_Odometer" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 67. Source step 0051 field "Txt_Odometer" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 68. Source step 0051 field "Txt_Odometer" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "120000"
# 69. Source step 0051 field "Txt_Odometer" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 70. Source step 0051 field "Btn_Add Additional Vehicle" in "Vehicle Summary - Enter Vehicle Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 71. Source step 0052 field "Btn_VehSelect" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 72. Source step 0052 field "Btn_1997 Harley Davidson FLSTF FAT" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 73. Source step 0052 field "Btn_1988 Ford E350" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 74. Source step 0052 field "Btn_Principal_2" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 75. Source step 0052 field "Btn_1988 Ford E351" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 76. Source step 0052 field "Btn_Principal_4" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0052 field "Btn_Principal_4" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0052 field "Btn_Occasional_3" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0052 field "Btn_Occasional_3" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0052 field "Btn_Vehicle_Select" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 81. Source step 0052 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0052 field "Btn_Principal" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 83. Source step 0052 field "Btn_Principal_New" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0052 field "Btn_Occasional" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 85. Source step 0052 field "Lnk_CONTINUE_1" in "Enter Driver Assignment - Select Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 86. Source step 0053 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 87. Source step 0063 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 88. Source step 0063 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 89. Source step 0063 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 90. Source step 0063 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 91. Source step 0063 field "<unnamed value>" in "Coverages - Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0068 field "Btn_Add Additional Interest" in "Additional Interest - Click Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 93. Source step 0068 field "Btn_Next" in "Additional Interest - Click Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 94. Source step 0068 field "<unnamed value>" in "Additional Interest - Click Next" was disabled. Reason:  
#    - Preserved source value: "True"
# 95. Source step 0068 field "<unnamed value>" in "Additional Interest - Click Next" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 96. Source step 0070 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 97. Source step 0071 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 98. Source step 0072 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 99. Source step 0073 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 100. Source step 0077 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 101. Source step 0078 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 102. Source step 0079 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 103. Source step 0117 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 104. Source step 0118 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 105. Source step 0119 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 106. Source step 0122 field "Lnk_Policyholder_name" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "x"
# 107. Source step 0122 field "Lnk_PersonalAuto" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 108. Source step 0122 field "Lnk_Motorcycle" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 109. Source step 0122 field "Lnk_ROP" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "x"
# 110. Source step 0122 field "Lnk_New Business" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "x"
# 111. Source step 0122 field "Btn_BUTTON_Forward" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 112. Source step 0122 field "Lnk_Pricing" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 113. Source step 0122 field "Txt_Underwriting Notes *" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "{Click}{Sendkeys[Verified]}"
# 114. Source step 0122 field "Btn_Approve" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 115. Source step 0122 field "Btn_Approve" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 116. Source step 0122 field "Lnk_Home_Left Navigation Pane" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 117. Source step 0122 field "Btn_Log Out" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 118. Source step 0135 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 119. Source step 0136 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 120. Source step 0136 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 121. Source step 0136 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 122. Source step 0137 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 123. Source step 0139 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 124. Source step 0144 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 125. Source step 0147 field "Btn_Transmit" in "Back to Submission page - Capture Policy Number, Effective Date, Policy Premium" was disabled. Reason:  
#    - Preserved source value: "True"
# 126. Source step 0147 field "Btn_Transmit" in "Back to Submission page - Capture Policy Number, Effective Date, Policy Premium" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 127. Source step 0147 field "Btn_Transmit" in "Back to Submission page - Capture Policy Number, Effective Date, Policy Premium" was disabled. Reason:  
#    - Preserved source value: "X"
# 128. Source step 0150 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 129. Source step 0151 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 130. Source step 0152 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 131. Source step 0153 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 132. Source step 0154 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 133. Source step 0155 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 134. Source step 0156 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 135. Source step 0157 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 136. Source step 0158 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 137. Source step 0167 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 138. Source step 0168 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 139. Source step 0169 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0194 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\UW Rejection Cycle_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0195 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0196 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0197 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0198 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\UW Rejection Cycle_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0199 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0200 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0201 CloseBrowser: I close the active browser
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 9. Source recovery step 0202 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 10. Source recovery step 0203 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 11. Source recovery step 0204 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 12. Source recovery step 0205 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EQ sign out and Close browser
# 13. Source recovery step 0206 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 14. Source recovery step 0207 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 15. Source recovery step 0208 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 16. Source recovery step 0209 CloseBrowser: I close the active browser
