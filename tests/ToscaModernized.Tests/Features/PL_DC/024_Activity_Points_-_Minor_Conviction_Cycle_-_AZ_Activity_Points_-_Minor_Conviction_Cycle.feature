# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 024_Activity_Points_-_Minor_Conviction_Cycle_-_AZ_Activity_Points_-_Minor_Conviction_Cycle.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @Edge @manual @archive @automated
Feature: Execute Activity Points - Minor Conviction (Cycle) - AZ for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Minor Conviction (Cycle) - AZ workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Minor Conviction (Cycle) - AZ using representative iteration Activity Points - Minor Conviction (Cycle) - AZ
    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e8d-52b9-ec50-5f891748f985
    # Runtime control: EQ||Enter Sign On Credentials > Condition - if signon page is displayed
    Given if the source runtime condition "EQ||Enter Sign On Credentials > Condition - if signon page is displayed" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0012: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e8d-e249-8a49-83069a711702
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

    # Source step 0013: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e8d-4a2c-1dda-fe89a30bfd8e
    # Runtime control: EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Then - Enter Sign On Credentials" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e8d-079f-d4af-b6e0aa085258
    # Runtime control: EQ||Enter Sign On Credentials > Else - if signon page isn't displayed
    Then if the source runtime condition "EQ||Enter Sign On Credentials > Else - if signon page isn't displayed" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0015: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e8d-f5e3-5f2d-841fef051b60
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.LastName" in "Txt_Last"
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
    # Section: Process > Cycle Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e8d-a4d6-cf33-faa49fcc18c0
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.DOB" in "Txt_DOB"
    When I enter or select "9072093583" in "Txt_Best phone_Account Owner"
    When I enter or select "EVERETTDEMARCO1227@MSN.COM" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I select "Btn_Married"
    When I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.Street_Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.City" in "Txt_owner.address.city_New"
    When I enter or select "ARIZONA" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0017: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-5abe-193b-f42493be9188
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[ARIZONA]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_American National General Insurance Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0018: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-9c4d-9504-f378d7cec856
    # Runtime control: Proposal Start_Proceed  - If Popup appears > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start_Proceed - If Popup appears > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0019: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-de59-8f54-0b133c68c7a5
    # Runtime control: Proposal Start_Proceed  - If Popup appears > Then - Click Proceed
    When if the source runtime condition "Proposal Start_Proceed - If Popup appears > Then - Click Proceed" is satisfied, I click "Btn_PROCEED"

    # Source step 0020: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-9ddd-6fd3-19ed3d3316f6
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition - If Popup appears" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0021: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-2b12-9671-91a272716f73
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then - Click Confirm" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0022: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-5121-08a0-e32d4df8bdad
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else - Enter SSN and continue" is satisfied, I enter the RUNTIME-DERIVED TDM value "AZ_ClientData_Regression.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0023: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-23d3-ea43-05e3564d2d12
    # Runtime control: Proposal Start-UW Popup - If Popup appears > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start-UW Popup - If Popup appears > Condition - If Popup appears" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0024: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-4b7c-24e9-e40b40d99a5c
    # Runtime control: Proposal Start-UW Popup - If Popup appears > Then - Click on Use existing account
    When if the source runtime condition "Proposal Start-UW Popup - If Popup appears > Then - Click on Use existing account" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0026: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-42ff-7d57-a2cdebbd51b9
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0027: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-b145-5dbf-befd45e2bb5b
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0028: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-03cf-9220-74345333fd47
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0029: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-27ea-709c-315c863ba0b2
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0030: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-b871-00b1-1b3370f94ec0
    # Runtime control: If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Condition - If Prior Insurance button is selected" is satisfied, "Prior Insurance_Checked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base mat-button-toggle-checked btn-chip ng-star-inserted"

    # Source step 0031: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e95-89a0-b6f9-86d4626850ba
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

    # Source step 0032: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-cf1f-bcbd-3df6f4239f12
    # Runtime control: If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary  > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected
    Then if the source runtime condition "If - Checking Prior Insurance button selected or not > Else - Select Prior Insurance and continue with driver summary > If - Prior Insurance is not Selected > Condition - Prior Insurance is not selected" is satisfied, "Prior Insurance_Unchecked_Yes" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted"

    # Source step 0033: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy > 04 Driver Information > Driver Summary - Enter Driver Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-560c-884e-c80334e43490
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

    # Source step 0034: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-e752-8df2-3a855dd57c47
    When I click "Btn_Next"

    # Source step 0035: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-4084-9be8-4ec0fd057830
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0036: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-cf65-235e-ebf4f7db07d4
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0037: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-6ec3-88d2-a58f7f7a3437
    Then I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "1HD1KRM19EB602640" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    When I enter or select "Pleasure Use" in "Btn_Primary Vehicle Use_Options"
    When I select "Btn_Cycle_Customizatioin_No"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0038: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-fb8d-cad1-d4e8e957d9e7
    When I click "Btn_2014 Harley Davidson FLHXS_V1"
    Then I wait until "Btn_Principal_1" exists
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0039: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-4761-ca75-a2f87800bcf7
    # Runtime control: Driver Assignment- UW Popup > Condition - If UW Popup appears at Driver Assignment Page
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition - If UW Popup appears at Driver Assignment Page" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0040: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-8abe-23dc-1893fca41136
    # Runtime control: Driver Assignment- UW Popup > Then - Select Continue and proceed  
    When if the source runtime condition "Driver Assignment- UW Popup > Then - Select Continue and proceed" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0041: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-2c0c-d302-4fd97fbf6fd0
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Edit Violation" should be visible

    # Source step 0042: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-cd06-dc63-d8b5d0ec3194
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD VIOLATION"

    # Source step 0043: ExpertQuote|Violations | Module: EQ|Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-b1f5-fcb9-5757f7e68300
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I enter or select "10/10/2003" in "Violation/Susp Dat"
    Then "Driver Involved" should be visible
    When I click "Courtney Allison"
    When I enter or select "{invoke[Click]}{sendkeys[EL - Driving with Expired License]}" in "DIV_1"
    When I enter or select "10/10/2022" in "Conviction Date"
    When I click "Applies"
    When I click "Save and Continue"

    # Source step 0044: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-45ba-8538-8281bddca935
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0045: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-43d1-5a94-c92a1eea9820
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0046: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-b404-e8ce-64e24ff9cb6b
    When I click "Btn_Next"

    # Source step 0047: Enter Coverages | Module: <unresolved module>
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-23e0-432a-1c7bea820c3a
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0048: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-51e3-2e30-1a238f2045db
    When I click "Btn_Next"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 09 Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0050: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-c342-8300-d967df7435dd
    Then I wait until "Hdr_Pricing Details_Header" is visible
    When I click "Btn_Next"

    # Source step 0051: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-92a8-e79b-d164337d1bc5
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"

    # Source step 0052: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-2aa1-6e30-f5ac7ece3ae0
    When I click "btn_Next"

    # Source step 0053: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0058: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0059: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0060: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0064: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0065: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0066: Search Policy Number | Module: EU||Home
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0067: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"
    When I enter the unresolved source parameter "PersonalAuto" (not supplied by this reusable-block invocation) in "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0068: Click on Pricing | Module: EU||Applicant
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0070: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0072: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0074: Click on Home button | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0075: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0076: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0077: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0078: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0079: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0080: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0081: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0083: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0084: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0086: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-f1e9-55ac-0fe49608fa1a
    # Runtime control: Submission-Review & Continue > Condition - If Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Condition - If Agent Comments Appears" is satisfied, "Txt_AgentComments" should exist

    # Source step 0087: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-c92c-57d9-d2e46229c69f
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0088: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-3659-0005-6aa5e91bdcba
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Agent Comments Appears" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0089: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-f465-e79b-883fcb2438ec
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0090: EQ||Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-7a94-7b5a-d57cb0e4a7f2
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt3_Agent Comments" should exist

    # Source step 0091: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-6b30-4505-f961dc6de386
    # Runtime control: Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments
    When if the source runtime condition "Submission-Review & Continue > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt3_Agent Comments"

    # Source step 0092: Verify Refer to UW Appears | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-bf31-4a10-bd0ae1417ff8
    # Runtime control: Check UW comments for level 2 > Condition - Check if Refer to UW appears
    Then if the source runtime condition "Check UW comments for level 2 > Condition - Check if Refer to UW appears" is satisfied, "Btn_Refer to UW" should exist

    # Source step 0093: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-cda0-0537-5788fd53531d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Condition - if Agent Comments Appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0094: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-e92a-8cda-6ba69c03fb8d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0095: Agent Comments Appears | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-194c-a986-ee3ff36d0c68
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Condition - If Another Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0096: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-42fa-3750-2d3926af77b1
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"

    # Source step 0097: Another Agent Comment Appears | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-0333-ae38-db3e8c6ebc1d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Condition - If Another Agent Comments Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Condition - If Another Agent Comments Appears" is satisfied, "Txt_Agent_Cmnts_Refer to UW_2" should exist

    # Source step 0098: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-7e5f-b853-6335808f8263
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears  > Then - Enter Agent Comments
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > Submission > Then - Enter Agent Comments > If another Agent comments appear > Then - Enter Agent Comments > If - Another Agent Comments Appears > Then - Enter Agent Comments" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW_2"

    # Source step 0099: Click Refer to UW | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-a371-e1fc-18f2e1f3d91e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Refer to UW"

    # Source step 0100: OpenUrl | Module: OpenUrl
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0104: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-911b-002a-d7baa16cb124
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0105: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-433b-e91b-d41604601e50
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0106: EU||Home | Module: EU||Home
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-3de4-304c-5f61e3f98b88
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0107: EU||Click on Auto/Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-a14d-6674-8909b76da67e
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"

    # Source step 0108: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-2191-c919-3f1afe73b565
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Condition - If Transact Page Appears" is satisfied, I wait until "Btn_ViewPolicy" exists

    # Source step 0109: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-1185-7215-6a4cb6caa196
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If - Transcat Page Appears > Then - Click on View Policy" is satisfied, I click "Btn_ViewPolicy"

    # Source step 0110: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-d21d-ab7b-743c8fbcec05
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0111: EU||Transact | Module: EU||Transact
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-0d8e-2001-52daa500ac9d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI > If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0112: EU||Applicant | Module: EU||Applicant
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-7ec1-273c-28c2bc23d63b
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0113: EU||Pricing | Module: EU||Pricing
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-7f0c-e42a-6710e6e3d98f
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    Then if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Verified]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0114: Close the Express UI Page | Module: CloseBrowser
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e9c-c4c1-2a5c-cf0b6b343788
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I close the active browser

    # Source step 0115: EQ||Save and Exit - Save and Exit the Quote | Module: EQ||Submission
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-5c38-d257-b7c882d141ac
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "Btn_Save and Exit"

    # Source step 0116: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-a4c0-5389-e79927965c4d
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0117: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Cycle Policy > 13 Submission > Express UI - UW Approval in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-eca0-74f4-d95fa22fa494
    # Runtime control: Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI
    When if the source runtime condition "Check UW comments for level 2 > Then-Enter Agent Comments and Proceed with Express UI" is satisfied, I click "DIV_Submission"

    # Source step 0118: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-a85b-6186-679c25feb1d5
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0120: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-65b6-a951-cd18b1b8ff84
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0122: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-9008-c3a5-2f3af2402dc3
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

    # Source step 0123: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-891d-1db5-24f5b0e94326
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0124: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-3e7d-eea5-0d236507de3f
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0125: TBox Save As | Module: TBox Save As
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-be1e-fc6f-a96f0f74e977
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0126: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-6cb2-a1b1-cf165ff79967
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0127: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Cycle Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-aadd-3b69-c7f52143dc79
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0129: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0130: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-8da6-39f7-7e9df9f0755f
    When I close the active browser

    # Source step 0131: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-b4e9-47cf-6b513585f377
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0132: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0133: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-4d8e-6083-de3bdbeed519
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0134: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-4e01-f845-066dad7be7a3
    When I click "Btn_Save and Exit"

    # Source step 0135: OpenUrl | Module: OpenUrl
    # Section: Process > Activity Points Minor | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0139: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-6668-fcca-805c562a9a86
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0140: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-1bbf-a06c-1324880a232e
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2634" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0141: Search  Policy Number | Module: EU||Home
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-c213-5c40-3e6cc54bafb8
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0142: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-757c-c526-7cfb43524a5e
    When I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"

    # Source step 0143: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-0c34-abc9-f2c57f5193ac
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0144: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-ee88-9e91-21ef20788906
    # Runtime control: If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0145: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-e781-c024-b3605926c96e
    # Runtime control: If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0146: EU||Applicant | Module: EU||Applicant
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-4424-4b83-19d2d7f9e040
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0147: EU||Pricing | Module: EU||Pricing
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-ef3c-8025-343d9b3d0be1
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0148: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Activity Points Minor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-e11e-651b-c9542eb785d5
    When I close the active browser

    # Source step 0153: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-067a-0309-2d5226230e74
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "AZ"

    # Source step 0154: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-c7aa-215f-54dca5936e6f
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "AZ"

    # Source step 0157: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Cycle" as runtime value "LOB"
    When I retain hard-coded value "AZ" as runtime value "State"

    # Source step 0167: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0168: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0169:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0170: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ea3-f30c-e961-f95d043cfb08
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
# 5. Source step 0016 field "Btn_Single" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 6. Source step 0016 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0016 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 8. Source step 0016 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0022 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0025 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 11. Source step 0029 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 12. Source step 0031 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 13. Source step 0031 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 14. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 17. Source step 0031 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0031 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0031 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0031 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 21. Source step 0031 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 22. Source step 0031 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 23. Source step 0031 field "Btn_PriorInsurance_Yes" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0031 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0031 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 26. Source step 0031 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 27. Source step 0033 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 28. Source step 0033 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 29. Source step 0033 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0033 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 31. Source step 0033 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0033 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0033 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0033 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0033 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 36. Source step 0033 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 37. Source step 0033 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 38. Source step 0033 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0033 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 40. Source step 0033 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 41. Source step 0034 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 42. Source step 0035 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0035 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0036 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0037 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0037 field "Btn_Loan_1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0037 field "Btn_Loan_1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0037 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 49. Source step 0037 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0038 field "Btn_2014 Harley Davidson XL883L SUPERLO_V2" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 51. Source step 0038 field "Btn_Occasional_2" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0038 field "Btn_Occasional_2" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 53. Source step 0038 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 54. Source step 0039 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0041 field "Hdr_Claims" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0042 field "Btn_+ ADD CLAIM" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0047 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 58. Source step 0047 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 59. Source step 0047 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0047 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 61. Source step 0051 field "<unnamed value>" in "Enter Underwriting" was disabled. Reason:  
#    - Preserved source value: "X"
# 62. Source step 0052 field "Btn_Add Additional Interest" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 63. Source step 0052 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0052 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0052 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 66. Source step 0054 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 67. Source step 0055 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 68. Source step 0056 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 69. Source step 0057 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 70. Source step 0061 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 71. Source step 0062 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 72. Source step 0063 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 73. Source step 0101 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 74. Source step 0102 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 75. Source step 0103 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 76. Source step 0119 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 77. Source step 0120 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 78. Source step 0120 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 79. Source step 0120 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 80. Source step 0121 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 81. Source step 0123 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 82. Source step 0128 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 83. Source step 0133 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0133 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 85. Source step 0133 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
# 86. Source step 0136 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 87. Source step 0137 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 88. Source step 0138 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 89. Source step 0143 field "Btn_Yes" in "EU||Transact" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 90. Source step 0147 field "DIV_Risk Score" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "RiskScore"
# 91. Source step 0147 field "Hdr_DC-SECTION" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 92. Source step 0149 "TBox Evaluation Tool" in module "TBox Evaluation Tool" was disabled. Reason: 18.04.24 12:49:26 [ct2634]
#    - VERIFY "Expression" with the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='5'"
# 93. Source step 0150 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 18.04.24 12:49:26 [ct2634]
#    - INPUT "Activity Point_AZ" with "Activity points for At fault_AZ is as Expected"
# 94. Source step 0151 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 18.04.24 12:49:26 [ct2634]
#    - INPUT "Activity Point_AZ" with "Activity points for At fault_AZ is as Fail"
# 95. Source step 0152 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:42 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 96. Source step 0155 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:46 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 97. Source step 0156 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 98. Source step 0158 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 99. Source step 0159 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 100. Source step 0160 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 101. Source step 0161 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 102. Source step 0162 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 103. Source step 0163 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 104. Source step 0164 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 105. Source step 0165 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 106. Source step 0166 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
