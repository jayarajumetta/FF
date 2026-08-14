# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 066_Endorse_Cycle_with_Esign_template_source.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @Edge @manual @archive @automated
Feature: Execute Endorse Cycle with Esign for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse Cycle with Esign workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse Cycle with Esign using representative iteration Template source — no concrete instantiated TestCase or TestCase-Design iteration was exported
    # Source step 0008: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-742f-fc0d-2c86099ab2a1
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

    # Source step 0009: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-940a-37c3-c2ee3d8a3871
    Then I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0010: Enter Client Selection | Module: EQ || Client Selection
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-6804-7514-e3d87d7f3ba9
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Shavon]}" in "Txt_First"
    When I enter or select "Ceballos" in "Txt_Last"
    When I leave "Txt_Date of birth" blank
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I click "Btn_Create New Client"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0011: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-b114-2866-1b8d9bc675dc
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter or select "8/18/1958" in "Txt_DOB"
    When I enter or select "9072279057" in "Txt_Best phone_Account Owner"
    When I enter or select "SHAVONCEBALLOS0622@COMCAST.NET" in "Txt_Email_Account Owner"
    Then "Lbl_Marital Status:" should exist
    When I click "Btn_Single"
    When I enter or select "TRES YUCCAS RD" in "Txt_Enter a location"
    When I enter or select "LAS CRUCES" in "Txt_owner.address.city_New"
    When I enter or select "NEW MEXICO" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter or select "880120000" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0012: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-bf20-d1c4-9f9da61e0be5
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I use source configuration "Drp List_Proposal Rating State > State List" = "X" for "EQ||Proposal Start"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I select "Drp List_State"
    When I click "Lbl_NEW MEXICO"
    When I click "Btn_Start Quote"

    # Source step 0013: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0014: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-0090-bfa7-73255d20562d
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0015: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-a805-d641-8958484b5065
    # Runtime control: Prposal Start_Proceed  > Then
    When if the source runtime condition "Prposal Start_Proceed > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0016: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-af6f-1220-4aec2fda310c
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0017: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-e810-398f-2fda7a35f495
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0018: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-6116-c138-fb97a46c01eb
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter or select "666341778" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0019: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-e843-5045-affa38c7aaa2
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0020: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-509f-bf3c-ef90064a3915
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0022: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-ed21-c079-ae0e8b32c0c2
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"

    # Source step 0023: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-afdf-fd6e-b3a3fa174f7d
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "TC10_Mega Auto Policy 07_CA"

    # Source step 0024: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-f416-5500-103587c72415
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0025: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-5eb7-5787-29865326a49c
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0026: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-01e1-b543-68bdb5c5547b
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0027: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-20ab-6703-10e2ad60980b
    # Runtime control: If_Driver Sumary_Prior Insurance > Then - Continue with Driver Summary
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Then - Continue with Driver Summary" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[26]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    Then I wait until "Btn_priorCarrierName" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorCarrierName"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Geico]}" in "Btn_priorCarrierName"
    Then I wait until "Btn_priorPolicyNumber" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorPolicyNumber"
    When I enter or select "{Invoke[Click]}{SENDKEYS[564723878]}" in "Btn_priorPolicyNumber"
    Then I wait until "Btn_yearsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_yearsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[5]}" in "Btn_yearsWithPriorCarrier"
    Then I wait until "Btn_monthsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_monthsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[0]}" in "Btn_monthsWithPriorCarrier"
    When I click "Btn_Save and Continue"

    # Source step 0028: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-c4a9-1b85-c77953a8c507
    # Runtime control: If_Driver Sumary_Prior Insurance > Else - Select Prior Insurance and continue with Driver Summary
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Else - Select Prior Insurance and continue with Driver Summary" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[26]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_Yes"
    Then I wait until "Btn_priorCarrierName" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorCarrierName"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Geico]}" in "Btn_priorCarrierName"
    Then I wait until "Btn_priorPolicyNumber" is enabled
    When I enter or select "\"^{a}\"" in "Btn_priorPolicyNumber"
    When I enter or select "{Invoke[Click]}{SENDKEYS[564723878]}" in "Btn_priorPolicyNumber"
    Then I wait until "Btn_yearsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_yearsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[5]}" in "Btn_yearsWithPriorCarrier"
    Then I wait until "Btn_monthsWithPriorCarrier" is enabled
    When I enter or select "\"^{a}\"" in "Btn_monthsWithPriorCarrier"
    When I enter or select "{Invoke[Click]}{SENDKEYS[0]}" in "Btn_monthsWithPriorCarrier"
    When I click "Btn_Save and Continue"

    # Source step 0029: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0030: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-6203-c6e5-b8984c7cad9a
    When I click "Btn_Next"

    # Source step 0031: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-8e61-2507-86cf7f568d09
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0032: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-199f-87b3-8a29797518d9
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0033: Vehicle Summary_New_Rescan | Module: EQ||Vehicle Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-8d94-b8b0-4922f3bcdf5f
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

    # Source step 0034: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-8e6e-fbdd-d4ef9e08034b
    When I click "Btn_2014 Harley Davidson FLHXS_V1"
    Then I wait until "Btn_Principal_1" exists
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0035: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-3b9f-2468-7c4943fa71a0
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, "Lnk_CONTINUE" should exist

    # Source step 0036: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-0fdd-c748-49db8d96503e
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0037: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0038: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-402e-99e3-cace20642e62
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" is visible
    Then "Lnk_UW_CONTINUE" should be visible

    # Source step 0039: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-9ab3-a1a5-9cb4d2b85b66
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Lnk_UW_CONTINUE"
    When I click "Btn_Next"

    # Source step 0040: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-bfab-4140-8478e1caa182
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0041: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-fa02-223b-c71df4d52cdb
    When I select "Btn_SafeCycle_Yes_D1"
    When I enter or select "10/10/2000" in "Txt_safeCycleDiscountDate_D1"
    When I click "Btn_Next"

    # Source step 0042: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0043: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-8fee-059d-fb2ef17579db
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0044: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-d31c-f77c-b45167254d6b
    When I select "Btn_UMPD_No Coverage_V1"
    When I click "Btn_Next"

    # Source step 0045: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-ee5f-56d3-22f3a8e80494
    When I wait "10000" milliseconds

    # Source step 0046: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-cbca-5c8c-8c80d85b0d7b
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0047: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-e2ee-8994-899391c947a1
    When I click "<unnamed value>"

    # Source step 0048: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0049: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-9f4e-dac0-35049d14aff7
    When I click "btn_Next"

    # Source step 0050: EQ||Billing_New | Module: EQ||Billing
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-1861-3561-16333872884b
    When I click "Btn_New Account"
    When I click "Btn_AccountHolder"
    When I click "Btn_Direct Bill"
    When I click "Btn_1 Payment"
    When I enter or select "{Invoke[Click]}{SENDKEYS[18]}" in "Txt_PaymentDueDate"
    When I click "Btn_Check"
    When I enter or select "{Invoke[Click]}{SendKeys[4088761300]}" in "Txt_InitialPaymentCheckNumber"
    When I click "Btn_Next"

    # Source step 0051: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0052: EQ||Check Principal/Occasional Box | Module: EQ||Check Principal/Occasional Box
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-fc49-6bea-db23c3dd6e97
    # Runtime control: Submission > Condition
    Then if the source runtime condition "Submission > Condition" is satisfied, "DIV_Principal/Occasional" should exist

    # Source step 0053: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-ecaa-8ef3-913978460a13
    # Runtime control: Submission > Then
    Then if the source runtime condition "Submission > Then" is satisfied, I wait until "Txt_AgentComments" exists
    When I enter or select "Need UW Approval" in "Txt_AgentComments"
    When I enter or select "Need UW Approval" in "Txt_AgentComments"

    # Source step 0054: EQ||Submission | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-c231-98da-3a8b917f5f79
    # Runtime control: Submission > Else
    When if the source runtime condition "Submission > Else" is satisfied, I enter or select "Need UW Approval" in "Txt_AgentComments"
    When I click "Btn_Launch To Checklist"

    # Source step 0055: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-f034-35a4-99cfbdbe865e
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0056: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-316b-3740-357f704d2edd
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0057: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-9fee-600b-716f0b0a93ed
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

    # Source step 0058: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0059: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-8361-c63b-ac1752ddac85
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0060: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-7cec-ee8a-7baa3615283d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter or select "Eeshitha.Gaddam@AmericanNational.com" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0061: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0062: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-25bb-7591-b1723a4c16a3
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0063: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0064: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-b51d-d8d4-392757c6097f
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0065: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-0362-d9e3-7731876e51e4
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter or select "Eeshitha.Gaddam@AmericanNational.com" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0066: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0067: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-92ec-e840-8902a2608c21
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0069: Open Url | Module: Open Url_ARA
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-c048-7c47-82cce462a7bf
    When I enter or select "https://outlook.office.com/mail/" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-1bd4-acbd-422ed576bdc4
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0071: Refresh | Module: TBox Send Keys
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-1f8b-6972-16da21b388a3
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0072: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-220c-ed1a-1e72b50d0566
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0073: Refresh | Module: TBox Send Keys
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-950f-0060-0bcecd12deb2
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-8e08-07bc-5976218d0e50
    When I wait "6000" milliseconds

    # Source step 0075: Refresh | Module: TBox Send Keys
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-5426-fc64-73520eb52dfb
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0076: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-c4aa-916a-26b391a24907
    When I click "e-SignLive"

    # Source step 0077: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-01b4-96ed-97780b263c9f
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0078: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-6ba8-66a9-438f0894c136
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0079: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-80fc-aabe-4ee113713aa1
    When I close the active browser

    # Source step 0080: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-7526-de1c-2a70607297a8
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0081: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bef-4e4a-7578-4d4c36c9cc12
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0083: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-bfcd-7095-a1dff70fe0e8
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0084: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-9404-b5d0-c50905960f8f
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0085: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-42b2-ac79-7fa6c6d83ba6
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0086:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-9e2e-7e72-795470d1aa46
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0087: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-15b0-f7f8-9597ccae0497
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0089: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0090: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-ddd2-2bbb-28b6abcdc1a4
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0091: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-4be4-66e9-b6b8160451f2
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0092: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-11ee-2d94-d97db1ea4634
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0093: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-4b15-cb44-7ae32eff5f02
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0094: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-4f80-9b3f-6697fe32fd4b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0095: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-3bca-a632-d3bcb8c69feb
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0096:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-e7dc-4194-d64727a0ce5d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0097: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-a1e7-6838-6ef7ea88f02f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0099: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0100: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-cbbe-976d-37ec2d8b0ffd
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0101: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0102: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-cd46-320a-ccd84b67963d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0103: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-b56b-0fa1-55ab9d3ed636
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0104: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-4423-bfcc-459980213cad
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0105:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-9d07-4d7b-88362f930cf8
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0106: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-71ab-e111-ecc92cfa7567
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0107: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0108: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Cycle Policy | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0109: CloseBrowser | Module: CloseBrowser
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-79d1-22f2-a919a40c8fc7
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0123: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-ab4a-51ef-cb735dfe156c
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0124: TBox Wait | Module: TBox Wait
    # Section: Process > Cycle Policy | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0125: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-68fd-d97d-306b4841a6d0
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0126: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-f332-fa81-fd0fd4b9814b
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Auto - TC08_Mega Rec Veh Policy 01_NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0127: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Cycle Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-93f0-a7e1-2cb1385d1ee8
    When I click "Btn_Save and Exit"

    # Source step 0128: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-568b-c7ff-8d7185703c7b
    When I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"
    When I click "Btn_+ CREATE NEW POLICY CHANGE"
    When I enter or select "{CLICK}{SENDKEYS[Endorse Coverage Limit]}" in "Txt_Policy Change Field"
    When I click "Btn_OK"

    # Source step 0129: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-6a70-17ab-4809d20e9a31
    When I click "Coverages"

    # Source step 0130: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0131: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-3aa9-5b6d-49797edec27f
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0132: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-97dc-bc33-1d13c861409f
    When I click "Submission"

    # Source step 0133: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0134: EQ||Submission | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-1fdf-fbd6-943ef4146b55
    When I click "Btn_Launch To Checklist"

    # Source step 0136: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-caec-a297-3c35d5f05428
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0138: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-587e-31c7-3b513ba19d50
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

    # Source step 0139: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-6ff1-4e53-806b17f8a4cb
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0140:  eChecklist|Signchange | Module:  eChecklist|Signchange
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-41c8-c2a3-a9a70b37f8c8
    When I click "Signed Change Form"

    # Source step 0141: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-ea6b-654f-16d003a3e7dc
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0142: TBox Save As | Module: TBox Save As
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-8372-f146-05dedc728cd8
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0143: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Endorse coverage to Lower > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-a1c3-9b5d-26324cd89f0e
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0144: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Endorse coverage to Lower > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-d704-77c2-76f8d8a7052f
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0146: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0147: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-d35d-eece-2ced3fbe9db7
    When I close the active browser

    # Source step 0148: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-b7c0-710c-5307298a5e9f
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0149: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0150: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-1d29-836c-a9965c8772e2
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"

    # Source step 0151: Click on Transmit Button | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-5b6d-4f9f-f10aebb45564
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0152: Buffer Tranmit Premiums | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-c32b-8bb3-88b96d372a1d
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    When I capture "InnerText" from "Lbl_Policy Number" as runtime value "Policy Number"

    # Source step 0153: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-edf4-d004-2bc53a3bf0ab
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "TC04_Endorse Cycle_NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"

    # Source step 0154: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-4a7c-6523-6aa7f62d9675
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
# 5. Source step 0011 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 6. Source step 0011 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 7. Source step 0011 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 8. Source step 0012 field "Btn_Recreational Vehicle" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0012 field "Drp List_Proposal Rating State" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0012 field "Hdr_proposal.ratingState-panel" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "New Mexico"
# 11. Source step 0012 field "Btn_PROCEED" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 12. Source step 0018 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0021 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 14. Source step 0022 field "Lbl_QNum" in "EQ||Tabs" was disabled. Reason:  
#    - Preserved source value: "QuoteNumber2"
# 15. Source step 0025 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 16. Source step 0027 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0027 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 18. Source step 0027 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0027 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0027 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0027 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 22. Source step 0027 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 23. Source step 0027 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 24. Source step 0027 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 25. Source step 0027 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 26. Source step 0027 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 27. Source step 0027 field "Btn_PriorInsurance_Yes" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0027 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0027 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0027 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0028 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0028 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 33. Source step 0028 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0028 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0028 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0028 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 37. Source step 0028 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 38. Source step 0028 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 39. Source step 0028 field "Txt_DL Number" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[885502570]}"
# 40. Source step 0028 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 41. Source step 0028 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 42. Source step 0028 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 43. Source step 0028 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 44. Source step 0028 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0030 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0031 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0031 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0032 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0033 field "Btn_SelectVehicle_Option1" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0033 field "Btn_Automobile" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 51. Source step 0033 field "Btn_Trailbike" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 52. Source step 0033 field "Btn_Is this vehicle used for racing?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0033 field "Btn_Pleasure" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 54. Source step 0033 field "Btn_No_non-factory additions, alterations, or modifications" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0033 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 56. Source step 0033 field "Btn_Is this vehicle licensed for road use?_No" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0033 field "Lbl_Does this vehicle have any customized equipment?" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0033 field "Btn_Does this Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "No"
# 59. Source step 0033 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0033 field "Btn_Pleasure/Work Use" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 61. Source step 0033 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0033 field "Txt_PurchaseDate" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "07/10/2003"
# 63. Source step 0033 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 64. Source step 0033 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0033 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 66. Source step 0033 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "120000"
# 67. Source step 0033 field "Txt_Odometer" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: a blank value
# 68. Source step 0033 field "Btn_Add Additional Vehicle" in "Vehicle Summary_New_Rescan" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0034 field "Btn_VehSelect" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 70. Source step 0034 field "Btn_1997 Harley Davidson FLSTF FAT" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 71. Source step 0034 field "Btn_1988 Ford E350" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 72. Source step 0034 field "Btn_Principal_2" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 73. Source step 0034 field "Btn_1988 Ford E351" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 74. Source step 0034 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0034 field "Btn_Principal_4" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 76. Source step 0034 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0034 field "Btn_Occasional_3" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0034 field "Btn_Vehicle_Select" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 79. Source step 0034 field "Lbl_Principal or Occasional driver of this vehicle?" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0034 field "Btn_Principal" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 81. Source step 0034 field "Btn_Principal_New" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 82. Source step 0034 field "Btn_Occasional" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0034 field "Lnk_CONTINUE_1" in "Enter Driver Assignment" was disabled. Reason:  
#    - Preserved source value: "x"
# 84. Source step 0035 field "Lnk_CONTINUE" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0041 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 86. Source step 0041 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 87. Source step 0044 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0044 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 89. Source step 0044 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 90. Source step 0044 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 91. Source step 0044 field "Btn_No Coverage_2" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0044 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 93. Source step 0044 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 94. Source step 0049 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 95. Source step 0049 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0049 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 97. Source step 0050 field "Img_Primary Payer_MAT LABEL" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 98. Source step 0050 field "Img_Primary Payer_MAT LABEL" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 99. Source step 0050 field "Lbl_Primary Payer" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0050 field "Lbl_Primary Payer Driver" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 101. Source step 0050 field "Lbl_Primary Payer Driver" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 102. Source step 0050 field "Btn_Primary Insured" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "Djfak Wopntz"
# 103. Source step 0050 field "Btn_Primary Insured1" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "{Down}"
# 104. Source step 0050 field "Txt_InitialPaymentAmount" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "110"
# 105. Source step 0050 field "DIV_Future PaymentPlan" in "EQ||Billing_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 106. Source step 0053 field "Lbl_QuoteTab_Name and Quote number" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
# 107. Source step 0053 field "Txt_Agent Comments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "True"
# 108. Source step 0053 field "Txt_Agent Comments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "Nedd UW Approval"
# 109. Source step 0053 field "Btn_Refer to UW" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 110. Source step 0053 field "Btn_Launch To Checklist" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 111. Source step 0053 field "Btn_Transmit" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "X"
# 112. Source step 0054 field "Lbl_QuoteTab_Name and Quote number" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
# 113. Source step 0054 field "Txt_AgentComments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0054 field "Txt_AgentComments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "Need UW Approval"
# 115. Source step 0054 field "Txt_Agent Comments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "True"
# 116. Source step 0054 field "Txt_Agent Comments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "Nedd UW Approval"
# 117. Source step 0054 field "Btn_Refer to UW" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 118. Source step 0054 field "Btn_Transmit" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "X"
# 119. Source step 0059 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 120. Source step 0064 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 121. Source step 0110 "Launch To Checklist" in module "EQ||Submission" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - VERIFY "Btn_Launch To Checklist" with "True"
#    - INPUT "Btn_Launch To Checklist" with "X"
# 122. Source step 0111 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 123. Source step 0112 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
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
#    - VERIFY "Btn_Sign On" with "True"
# 124. Source step 0113 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 125. Source step 0114 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
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
# 126. Source step 0115 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - BUFFER "DIV_Agent Documents Count" with "AgentList count"
#    - VERIFY "DIV_Agent Documents Count" with the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 127. Source step 0116 "EQ||ECheckList" in module "EQ||ECheckList" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 128. Source step 0117 "TBox Save As" in module "TBox Save As" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png"
#    - INPUT "Button" with "Open"
# 129. Source step 0118 "EQ||ECheckList_1" in module "EQ||ECheckList" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 130. Source step 0119 "TBox Save As_1" in module "TBox Save As" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg"
#    - INPUT "Button" with "Open"
# 131. Source step 0120 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 132. Source step 0121 "TBox Wait" in module "TBox Wait" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - INPUT "Duration" with "30000"
# 133. Source step 0122 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 28.03.24 12:02:54 [ct2634]
#    - INPUT "Title" with "American*"
# 134. Source step 0123 field "Btn_Ok" in "EQ||Submission_1" was disabled. Reason:  
#    - Preserved source value: "True"
# 135. Source step 0123 field "Btn_Ok" in "EQ||Submission_1" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 136. Source step 0125 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 137. Source step 0125 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 138. Source step 0125 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
# 139. Source step 0131 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 140. Source step 0131 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 141. Source step 0131 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 142. Source step 0131 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 143. Source step 0131 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 144. Source step 0134 field "Lbl_QuoteTab_Name and Quote number" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
# 145. Source step 0134 field "Txt_Agent Comments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "True"
# 146. Source step 0134 field "Txt_Agent Comments" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "Nedd UW Approval"
# 147. Source step 0134 field "Btn_Refer to UW" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 148. Source step 0134 field "Btn_Transmit" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "X"
# 149. Source step 0135 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 150. Source step 0136 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 151. Source step 0136 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 152. Source step 0136 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 153. Source step 0137 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 154. Source step 0139 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 155. Source step 0141 field "Lnk_Auto/Cycle/RV Application" in "EQ||ECheckList" was disabled. Reason:  
#    - Preserved source value: "X"
# 156. Source step 0145 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 157. Source step 0148 field "Btn_Transmit" in "EQ||Submission_1" was disabled. Reason:  
#    - Preserved source value: "True"
# 158. Source step 0148 field "Btn_Transmit" in "EQ||Submission_1" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 159. Source step 0148 field "Btn_Transmit" in "EQ||Submission_1" was disabled. Reason:  
#    - Preserved source value: "X"
# 160. Source step 0150 field "Lbl_Value_Total Policy Premium" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Premium"
# 161. Source step 0150 field "Lbl_Value_Effective Date" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 162. Source step 0150 field "Lbl_Value_Checklist Id" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "CheckList ID"
# 163. Source step 0150 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 164. Source step 0150 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 165. Source step 0150 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
# 166. Source step 0152 field "Lbl_Value_Effective Date" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 167. Source step 0152 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "True"
# 168. Source step 0152 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 169. Source step 0152 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0155 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse Cycle with Esign - NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0156 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0157 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0158 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 5. Source recovery step 0159 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse Cycle with Esign - NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0160 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0161 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0162 CloseBrowser: I close the active browser
