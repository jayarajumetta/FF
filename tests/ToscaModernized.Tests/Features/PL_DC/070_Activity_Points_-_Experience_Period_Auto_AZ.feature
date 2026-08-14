# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 070_Activity_Points_-_Experience_Period_Auto_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @Arizona @Edge @manual @archive @automated
Feature: Execute Activity Points - Experience Period (Auto) for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Experience Period (Auto) workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Experience Period (Auto) using representative iteration Arizona (AZ) — selected from TestCase-Design; no concrete instantiated TestCase was exported
    # Source step 0010: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-cf4e-ed0d-a6b1a1329c82
    # Runtime control: Enter Sign On Credentials > Condition
    Given if the source runtime condition "Enter Sign On Credentials > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-6fe4-4573-14bbd087ca62
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, "Img_American National Family of Companies" should exist
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

    # Source step 0012: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-9966-c1b2-20f5214d43c2
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-d90e-4e1e-fe8464a45720
    # Runtime control: Enter Sign On Credentials > Else
    Then if the source runtime condition "Enter Sign On Credentials > Else" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Enter Client Selection | Module: EQ || Client Selection
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-398c-39a4-e28d4e7e18c5
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

    # Source step 0015: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-cdfe-55c6-728615a3d1f2
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I enter or select "9072094713" in "Txt_Best phone_Account Owner"
    When I enter or select "GAYLANDKEARNEY0607@OUTLOOK.COM" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I click "Btn_Single"
    When I enter captured runtime value "StreetAddress" in "Txt_Enter a location"
    When I enter captured runtime value "StreetAddress" in "Txt_owner.address.city_New"
    When I enter or select "ARIZONA" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0016: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-0f4e-45bb-89557afdfcc0
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Writing Company" exists
    When I enter or select "{Invoke[Click]}{SENDKEYS[United Farm Family Insurance Co.]}" in "Drp List_List Auto Writing Company"
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I enter or select "{Invoke[Click]}{Sendkeys[ARIZONA]}{RETURN}" in "Drp List_State"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Bronx]}" in "Hdr1"
    When I click "Btn_Start Quote"

    # Source step 0017: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0018: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-954d-3a79-5588b3afa725
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0019: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-0380-52f2-50743e91257d
    # Runtime control: Prposal Start_Proceed  > Then
    When if the source runtime condition "Prposal Start_Proceed > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0020: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-e9ca-852e-4758edad49ec
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0021: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-933b-6a3e-10aa7c61b5a6
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0022: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-0b12-4c5d-b19da0291056
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0023: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-6379-645d-ea1363e0b8f1
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0024: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-934c-6bd6-a0b828fa03e8
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0026: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-4e05-04c3-57673ae91cfb
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0027: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-82ce-c447-34f90c7facc7
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "ActivityPoints-NoFault(Cycle)_NY"

    # Source step 0028: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-640d-4ebe-d73ccba00826
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0029: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-1876-1c58-e4c78dfe5049
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0030: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-ef78-0bdc-432f3e7a948c
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0031: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-994f-5726-3f76bb6e3560
    # Runtime control: If_Driver Sumary_Prior Insurance > Then
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Then" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
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

    # Source step 0032: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-acb6-1733-5a6457ce17cc
    # Runtime control: If_Driver Sumary_Prior Insurance > Else
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Else" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I click "Btn_Save and Continue"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0034: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-72f2-480e-4385eec11871
    When I click "Btn_Next"

    # Source step 0035: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-8acb-16ec-66f66ce4dbcf
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0036: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-c739-913a-f9c46d14e123
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0037: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-4fc6-c7b8-c0d45d1048d2
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    When I click "Btn_Motorcycle"
    When I click "Btn_Harley-Davidson Tour FL"
    When I click "Btn_Pleasure Use"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    When I select "Btn_Cycle_Customizatioin_No"
    When I enter or select "{Invoke[Click]}{SENDKEYS[450]}" in "Txt_Engine CC's"
    When I enter or select "{CLICK}{SENDKEYS[40]}" in "Txt_AnnualMileage"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0038: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-bcca-97d7-f29e6060b9a2
    When I click "Btn_2002 Lexus GS430"
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0039: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-f9aa-51bb-5e8f975f2656
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0040: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-6076-95ba-b44ec7ca0649
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0041: UW popup | Module: TBox Set Buffer
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-e683-c17e-4aaba39a0673
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0042: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0043: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-ebe0-5c83-a0480f8bea69
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Claims" should be visible

    # Source step 0044: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-1c8a-2ad3-9c679851da46
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD CLAIM"

    # Source step 0045: EQ | Claim Summary | Module: EQ | Claim Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-c5b5-cde7-2c1e4f3be314
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Open"
    When I select "Not At Fault"
    When I click "Collision"
    When I click "Gayland Kearney"
    When I enter or select "{Click}{SENDKEYS[100]}" in "Claim Amount TextBox"
    When I enter a RANDOM value matching "1 random digits/characters" in "fields.losses.loss.rows[0].lossInput$dateOfLoss.value"
    When I click "Save and Continue"

    # Source step 0046: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-8a4e-8d1a-8e1da1f5b55f
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0047: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-786d-2f94-c0ea1cec9cb4
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0048: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-28c0-cf7e-ed4d2b8e84de
    When I click "Btn_Next"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0050: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-f067-2d65-5fc401ea03dc
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0051: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-9656-8c61-b6c09f2dc9e1
    When I click "Btn_BASIC"
    When I click "Btn_Next"

    # Source step 0052: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-054e-39c0-6f2c8c11e04b
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0053: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-d1a5-5112-9307be8b82bd
    When I click "<unnamed value>"

    # Source step 0054: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0055: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-54e4-f5e9-bf22da3dfbbe
    When I click "btn_Next"

    # Source step 0056: Billing-Enter Billing Details & Continue | Module: EQ||Billing
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c4f-3996-d90c-9497874d974a
    When I click "Btn_New Account"
    When I click "Btn_AccountHolder"
    Then I wait until "Btn_Direct Bill" is visible
    When I click "Btn_Direct Bill"
    When I click "Btn_1 Payment"
    When I enter or select "25" in "Txt_PaymentDueDate"
    When I click "Btn_Check"
    When I enter or select "{CLICK}{SendKeys[2468135709]}" in "Txt_InitialPaymentCheckNumber"
    When I click "Btn_Next"

    # Source step 0057: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0058: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-8403-eaf6-6d66702c191c
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0059: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-f4b0-e2c8-c49d6cd10a3f
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0060: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-2210-598d-ec10120ce366
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0061: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-7908-c91e-0382100d8904
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0062: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-76d7-0102-a96cf5f81f61
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0064: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-b9fc-6c15-4f56638594ce
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0066: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-3f17-a16d-0f5caebfab86
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

    # Source step 0067: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-a227-b734-27f7ee19dd30
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0068: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-4957-e05e-bc4a8f2aae32
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0069: TBox Save As | Module: TBox Save As
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-b44b-e497-d8eaf102ad9e
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0070: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-f92f-c87e-6451d07161ba
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0071: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Cycle Policy > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-8e42-c21f-5ca6f62d68f2
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0074: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-7e72-d51e-75f75859ec03
    When I close the active browser

    # Source step 0075: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-3d45-1b00-e563316bac71
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0076: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0077: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-e0fb-2aae-c0d1f74211ec
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number_Activitypoints_NotAtFault_NY"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0078: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-9d64-3a85-d27f0187c77f
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number_Activitypoints_NotAtFault_NY"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Activity Points - No Fault (Cycle)_NY"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0079: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-9e8b-5e25-24f911a3486b
    When I click "Btn_Save and Exit"

    # Source step 0080: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-c1ea-b881-7282527964d1
    When I close the active browser

    # Source step 0081: OpenUrl | Module: OpenUrl
    # Section: Process > UW Non Renewal | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0085: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-6a75-3207-098cd3e5eec9
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0086: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-ad2d-7723-37f90d3004a8
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0087: Search  Policy Number | Module: EU||Home
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-9df2-95b8-c93296e51286
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number_Activitypoints_NotAtFault_NY" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0088: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-362a-9c64-cf0088ac13d9
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_Motorcycle" is visible
    When I click "Lnk_Motorcycle"

    # Source step 0089: EU||Transact | Module: EU||Transact
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-ef2d-9c87-3b5563a04114
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0090: EU||Transact | Module: EU||Transact
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-39a7-4231-d6532e8e3db8
    # Runtime control: If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0091: EU||Transact | Module: EU||Transact
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-250e-b43a-998d606068c6
    # Runtime control: If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0092: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-7e56-c7ad-d6c5d5304c34
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0093: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-5386-f3c6-14905e0763d4
    When I capture "InnerText" from "DIV_Risk Score" as runtime value "RiskScore"
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0094: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-2dc3-8058-6239bd348666
    When I close the active browser

    # Source step 0095: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-79cd-f7c4-8b1598a72d74
    # Runtime control: Evaluating Activity Points is 3 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 3 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='3'"

    # Source step 0096: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-6d0a-d02d-f56d57428981
    # Runtime control: Evaluating Activity Points is 3 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 3 or not > Then" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Expected" as runtime value "Activity Point_NY"

    # Source step 0097: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c5e-d836-b166-694c410dc02b
    # Runtime control: Evaluating Activity Points is 3 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 3 or not > Else" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Fail" as runtime value "Activity Point_NY"

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
# 5. Source step 0015 field "Btn_Married" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0015 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0015 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 8. Source step 0015 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0016 field "Btn_Recreational Vehicle" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0016 field "Btn_PROCEED" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 11. Source step 0022 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 12. Source step 0025 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 13. Source step 0029 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0031 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0031 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 16. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 18. Source step 0031 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0031 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0031 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 21. Source step 0031 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 22. Source step 0031 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 23. Source step 0031 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0031 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0032 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0032 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 27. Source step 0032 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 28. Source step 0032 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 29. Source step 0032 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0032 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0032 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 32. Source step 0032 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 33. Source step 0032 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 34. Source step 0032 field "Btn_PriorInsurance_Yes" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0032 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0032 field "Btn_priorCarrierName" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0032 field "Btn_priorCarrierName" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 38. Source step 0032 field "Btn_priorCarrierName" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Geico]}"
# 39. Source step 0032 field "Btn_priorPolicyNumber" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0032 field "Btn_priorPolicyNumber" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 41. Source step 0032 field "Btn_priorPolicyNumber" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[5127398001]}"
# 42. Source step 0032 field "Btn_yearsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0032 field "Btn_yearsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 44. Source step 0032 field "Btn_yearsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[2]}"
# 45. Source step 0032 field "Btn_monthsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 46. Source step 0032 field "Btn_monthsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 47. Source step 0032 field "Btn_monthsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[0]}"
# 48. Source step 0032 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0032 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0034 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0035 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0035 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0036 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 54. Source step 0037 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0037 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 56. Source step 0037 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0037 field "Btn_Pleasure" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 58. Source step 0037 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 59. Source step 0037 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0037 field "Lbl_Does this vehicle have any customized equipment?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0037 field "Btn_Does this Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "No"
# 62. Source step 0037 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0037 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 64. Source step 0037 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0037 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "07/10/2003"
# 66. Source step 0037 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 67. Source step 0037 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0037 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 69. Source step 0037 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "120000"
# 70. Source step 0037 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 71. Source step 0037 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 72. Source step 0048 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 73. Source step 0048 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 74. Source step 0055 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 75. Source step 0055 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0055 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 77. Source step 0056 field "Lbl_Primary Payer" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0056 field "Lbl_Primary Payer Driver" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 79. Source step 0056 field "Lbl_Primary Payer Driver" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 80. Source step 0056 field "Btn_Primary Insured" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "Djfak Wopntz"
# 81. Source step 0056 field "Btn_Primary Insured1" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Down}"
# 82. Source step 0056 field "Txt_InitialPaymentAmount" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "110"
# 83. Source step 0056 field "DIV_Future PaymentPlan" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 84. Source step 0063 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 85. Source step 0064 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 86. Source step 0064 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 87. Source step 0064 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 88. Source step 0065 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 89. Source step 0067 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 90. Source step 0072 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 91. Source step 0077 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0077 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 93. Source step 0077 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
# 94. Source step 0082 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 95. Source step 0083 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 96. Source step 0084 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 97. Source step 0089 field "Btn_Yes" in "EU||Transact" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
