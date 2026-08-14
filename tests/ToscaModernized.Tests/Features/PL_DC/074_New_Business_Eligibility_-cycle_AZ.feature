# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 074_New_Business_Eligibility_-cycle_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @new_business @Arizona @Edge @manual @archive @automated
Feature: Execute New Business Eligibility -cycle for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the New Business Eligibility -cycle workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: New Business Eligibility -cycle using representative iteration Arizona (AZ) — selected from TestCase-Design; no concrete instantiated TestCase was exported
    # Source step 0010: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-7cf1-28d8-0e646a77abb0
    # Runtime control: Enter Sign On Credentials > Condition
    Given if the source runtime condition "Enter Sign On Credentials > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-aa97-2ed2-6cb8e4f0e0f3
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-c420-324e-8727dd77e242
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-aad1-308d-c7d873873d60
    # Runtime control: Enter Sign On Credentials > Else
    Then if the source runtime condition "Enter Sign On Credentials > Else" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Enter Client Selection | Module: EQ || Client Selection
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-0495-7080-5e9969b8039c
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-43bc-ee43-ba1cb5e8a138
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-1645-4ae4-386243e7312e
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I use source configuration "Drp List_Proposal Rating State" = "{Invoke[Click]}{Sendkeys[ARIZONA]}{RETURN}" for "EQ||Proposal Start"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Writing Company" exists
    When I enter or select "{Invoke[Click]}{SENDKEYS[United Farm Family Insurance Co.]}" in "Drp List_List Auto Writing Company"
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Bronx]}" in "Hdr1"
    When I click "Btn_Start Quote"

    # Source step 0017: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0018: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-5fa0-8b86-ad5898922d6f
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0019: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-8971-9d2a-1d8a663a47d6
    # Runtime control: Prposal Start_Proceed  > Then
    When if the source runtime condition "Prposal Start_Proceed > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0020: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-f86d-1728-ae42e1612485
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0021: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-87a4-17a8-a3574b974060
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0022: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-6863-9b01-e19a48fada5f
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0023: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-b7b8-f7a4-4b1e479328eb
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0024: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-269d-56da-ed2ef54a66fa
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0026: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-a40e-e801-a70e99246525
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0027: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-b96f-c833-c072c731f37b
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "ActivityPoints-NoFault(Cycle)_NY"

    # Source step 0028: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-02db-8fc8-0863716d5eb8
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0029: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-892a-e3b8-25d8466e025c
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0030: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-fa37-4fe1-4abaa68f890d
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0031: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-e5e7-567d-7b59c3dacb52
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-96e6-bbeb-1dc2ca284d97
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-a5f6-207b-161ebfeb1b6a
    When I click "Btn_Next"

    # Source step 0035: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-bf59-f381-730a12b3f1d9
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0036: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-0b6d-8fd0-be8573e47dbd
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0037: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c9d-14e8-3299-3d7d4c0a4f43
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-5743-4064-2dff79d77bf3
    When I click "Btn_2002 Lexus GS430"
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0039: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-9910-cffd-1ba6ade593e8
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0040: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-02f0-9661-17b1eaebb471
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0041: UW popup | Module: TBox Set Buffer
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-9388-76a3-98012e349275
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0042: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0043: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-c74b-fe2a-ffdf3b8a4ad1
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Claims" should be visible

    # Source step 0044: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-684c-9d21-7f52bd291602
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD CLAIM"

    # Source step 0045: EQ | Claim Summary | Module: EQ | Claim Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-5a9a-d2d1-13e5fa477742
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Open"
    When I select "Not At Fault"
    When I click "Collision"
    When I click "Gayland Kearney"
    When I enter or select "{Click}{SENDKEYS[100]}" in "Claim Amount TextBox"
    When I enter a RANDOM value matching "1 random digits/characters" in "fields.losses.loss.rows[0].lossInput$dateOfLoss.value"
    When I click "Save and Continue"

    # Source step 0046: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-4424-e7a4-92dbee8936eb
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0047: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-12e6-a893-6f39fb9ae207
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0048: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-c3b5-cacf-c23f2c4af791
    When I click "Btn_Next"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0050: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-84cc-47da-d4c7f70a089e
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0051: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-5d21-d968-75274e3d55c7
    When I click "Btn_BASIC"
    When I click "Btn_Next"

    # Source step 0052: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-a929-930f-3a5d8c688e70
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0053: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-a055-ee80-9e08ef02feca
    When I click "<unnamed value>"

    # Source step 0054: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0055: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-6fd5-5a37-eceaffc5c896
    When I click "btn_Next"

    # Source step 0056: Billing-Enter Billing Details & Continue | Module: EQ||Billing
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-14f5-9f02-00ab262933a6
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-e112-c2df-7bf89039c718
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0059: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-cab2-e142-79caa12f9bfa
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0060: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-88d4-870f-0e1f608729cd
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0061: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-c046-6806-fe0bb3db20f1
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0062: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-6b3f-a6f6-6a1e06c0bd49
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0064: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-ba7f-dfad-4533c3baa957
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-852c-72d6-bdf91183239b
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-273c-834f-f5d402ac6f3b
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0068: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-30ac-7121-4122b3710c91
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0069: TBox Save As | Module: TBox Save As
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-f780-af8f-8fd07bae5aaa
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0070: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Cycle Policy > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-983f-260c-5e65027d5a62
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0071: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Cycle Policy > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-4f16-054c-ced53e8b0063
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0074: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-d28c-3a2c-17d988b115b7
    When I close the active browser

    # Source step 0075: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-6fb5-cc51-05e11bd72133
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0076: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0077: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-758a-e585-e2561a28c3df
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number_Activitypoints_NotAtFault_NY"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0078: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-d23b-1525-9af714791215
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
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-df2e-5824-3accf0b76220
    When I click "Btn_Save and Exit"

    # Source step 0080: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-d5c7-0ffe-0b4ea0aa054b
    When I close the active browser

    # Source step 0081: OpenUrl | Module: OpenUrl
    # Section: Process > UW Non Renewal | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0085: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cad-87d0-9440-0ec842b3760b
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0086: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-0a66-e398-a15a64de82b3
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0087: Search  Policy Number | Module: EU||Home
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-bab1-12f4-4fee5da294b5
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "New Business Eligibiliyu (Auto)_NY" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0088: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-d2b2-d3a1-ece98607d6f9
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0092: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-e129-1117-0652ca552805
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0093: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-8d4b-9988-f4024224861a
    When I capture "InnerText" from "DIV_Risk Score" as runtime value "RiskScore"
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0094: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-d354-96e7-baa1c2df3324
    # Runtime control: Evaluating Activity Points is 4 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 4 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='4'"

    # Source step 0095: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-36fc-c95d-eeff26c7a11e
    # Runtime control: Evaluating Activity Points is 4 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 4 or not > Then" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Expected" as runtime value "Activity Point_NY"

    # Source step 0096: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-3311-c793-2742737ae2cb
    # Runtime control: Evaluating Activity Points is 4 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 4 or not > Else" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Fail" as runtime value "Activity Point_NY"

    # Source step 0097: EU|CLICK Driver History to check ignore box | Module: EU||Applicant
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-37d3-94b1-9828a1cc96f1
    When I click "Btn_Left arror Button"
    When I click "Lnk_Driver History"
    When I select "ChkBox_Ignore"

    # Source step 0098: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-a7a1-e3f1-e0e29a05f766
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0099: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-43d1-4350-d63c04854e55
    When I capture "InnerText" from "DIV_Risk Score" as runtime value "RiskScore"
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0100: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-1b15-1d30-7e4f14f5a8fd
    # Runtime control: Evaluating Activity Points is 0 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 0 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='0'"

    # Source step 0101: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-2e74-6206-3120e5dc0b95
    # Runtime control: Evaluating Activity Points is 0 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 0 or not > Then" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Expected" as runtime value "Activity Point_NY"

    # Source step 0102: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-2acf-3169-899e54d93923
    # Runtime control: Evaluating Activity Points is 0 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 0 or not > Else" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Fail" as runtime value "Activity Point_NY"

    # Source step 0103: EU|Driver History | Module: EU||Applicant
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-4ac5-1dc8-91def69bfcc2
    When I click "Btn_Left arror Button"
    When I click "Lnk_Driver History"
    When I select "ChkBox_Ignore"

    # Source step 0104: Click on Add Accident | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Add Accident | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-b8ae-ea86-7d4e4d74cb35
    When I click "Btn_Add Accident"

    # Source step 0105: Add Details | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Add Accident | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-819d-eaf9-736a99864422
    When I capture "InnerText" from "DIV_Buffer Driver Name" as runtime value "DriverName"
    When I enter or select "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[Collision]}" in "Txt_Loss Cause"
    When I enter the RUNTIME-DERIVED buffer expression "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[{B[DriverName]}]}" in "Txt_Driver Involved"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{CLICK}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[{DATE[][-1d][MM-dd-yyyy]}]}" in "DIV_1 > Date Of Loss"
    When I enter or select "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[Open]}" in "Hdr_DC-COMBOBOX > Status_New"
    When I enter or select "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[$1500]}" in "Hdr_DC-TEXT-FIELD > Surcharge Amount"
    When I enter or select "{CLICK}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[Insured At Fault]}" in "Hdr_DC-COMBOBOX_1 > At Fault Indicator"
    When I click "Btn_Ok_1"

    # Source step 0106: TBox Wait | Module: TBox Wait
    # Section: Process > UW Non Renewal > Add Accident | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0107: EU|Driver History | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Add Convictions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-74c6-d2fa-7426f57267f0
    When I click "Btn_Left arror Button"
    When I click "Lnk_Driver History"
    When I click "Btn_Add Conviction"

    # Source step 0108: Add Details | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Add Convictions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-d425-4cfa-c6dbced047b5
    When I enter or select "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[Conviction]}" in "Hdr_DC-COMBOBOX_2 > Violation Type"
    When I enter or select "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[SE - 1 to 9 mph Over Limit]}" in "Hdr_DC-COMBOBOX_3 > MVR Violation Code"

    # Source step 0109: Add Details | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Add Convictions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-3923-85b7-a18747b01217
    When I enter the RUNTIME-DERIVED buffer expression "{Click}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[{B[DriverName]}]}{TAB}" in "Txt_Driver Involved"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{CLICK}{SENDKEYS[\"^{a}\"]}{BACKSPACE}{SENDKEYS[{DATE[][-8d][MM-dd-yyyy]}]}" in "DIV_1 > Date Of Loss"
    When I click "Btn_Ok_1"

    # Source step 0110: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Add Convictions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-b7fc-973d-487c1697da10
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0111: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal > Add Convictions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-6d72-d2d8-04c0a0058eb8
    When I capture "InnerText" from "DIV_Risk Score" as runtime value "RiskScore"
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I capture "InnerText" from "Hdr_DC-SECTION > 4" as runtime value "ActivityPoints1"
    When I capture "InnerText" from "Hdr_DC-HYPERGRID-CELL > 3" as runtime value "ActivityPoint2"
    When I click "Btn_Close"

    # Source step 0112: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > Add Convictions | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-ff86-f19a-c48b4d407422
    When I derive and retain the RUNTIME-DERIVED buffer expression "{MATH[{B[ActivityPoints]}+{B[ActivityPoints1]}+{B[ActivityPoint2]}]}" as runtime value "Activity Point_NY"

    # Source step 0113: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-92c1-f184-4ae7fcf6d7b4
    # Runtime control: Evaluating Activity Points is 11 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 11 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[Activity Point_NY]}'=='11'"

    # Source step 0114: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cb8-3a45-1599-e1dbafef39c0
    # Runtime control: Evaluating Activity Points is 11 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 11 or not > Then" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Expected" as runtime value "Activity Point_NY"

    # Source step 0115: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbb-6ad7-99de-6f1001548c13
    # Runtime control: Evaluating Activity Points is 11 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 11 or not > Else" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Fail" as runtime value "Activity Point_NY"

    # Source step 0116: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbb-abfd-1f06-1e4991192c99
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
# 97. Source step 0089 "EU||Transact" in module "EU||Transact" was disabled. Reason: 15.04.24 18:35:08 [ct2628]
#    - WAIT "Btn_ViewPolicy" with "True"
#    - INPUT "Btn_ViewPolicy" with "{Invoke[Click]}"
#    - INPUT "Btn_Yes" with "{Invoke[Click]}"
# 98. Source step 0090 "EU||Transact" in module "EU||Transact" was disabled. Reason: 15.04.24 18:35:08 [ct2628]
#    - VERIFY "Btn_Yes" with "True"
# 99. Source step 0091 "EU||Transact" in module "EU||Transact" was disabled. Reason: 15.04.24 18:35:08 [ct2628]
#    - INPUT "Btn_Yes" with "{Invoke[Click]}"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
