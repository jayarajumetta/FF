# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 026_Activity_Points_-_No_Fault_Cycle_-_NY_NY.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @New_York @Edge @manual @archive @automated
Feature: Execute Activity Points - No Fault (Cycle) - NY for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - No Fault (Cycle) - NY workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - No Fault (Cycle) - NY using representative iteration New York (NY)
    # Source step 0030: Enter Client Information | Module: EQ || Client Selection
    # Section: Process > Generating Cycle Policy > 01 Start New Quote and Client Selection | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-a782-efe9-06e792ae6154
    Given "Lbl_Client Info" should exist
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

    # Source step 0031: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Generating Cycle Policy > 01 Start New Quote and Client Selection | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-bded-4ba7-9a01f8a74432
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
    When I enter or select "NEW YORK" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0032: Enter Proposal Details | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-5e26-16f2-ccad627c8e63
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Motorcycle"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW YORK]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Writing Company" exists
    When I select "Drp_Writing Company"
    When I click "Lbl_United Farm Family Insurance Co."
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I enter or select "{Invoke[Click]}{SENDKEYS[Bronx]}" in "Hdr1"
    When I click "Btn_Start Quote"

    # Source step 0033: Verify if popup is visible | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-ec94-debc-6d407b07fb33
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0034: Click on Proceed button | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-c670-ad42-89f5450ca685
    # Runtime control: Prposal Start_Proceed  > Click on Proceed button
    When if the source runtime condition "Prposal Start_Proceed > Click on Proceed button" is satisfied, I click "Btn_PROCEED"

    # Source step 0035: Verify if confirm the client SSN# is visible | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-3e41-fc31-69393267cfab
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Verify if confirm the client SSN# is visible
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Verify if confirm the client SSN# is visible" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0036: Click on Confirm button | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-64a1-9254-77dd737d7290
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Click on Confirm button
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Click on Confirm button" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0037: Enter SSN details | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-6167-648d-0a708b6891e6
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Enter SSN details
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Enter SSN details" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0038: Verify if popup is visible | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-25aa-6f12-94d3ea23bf22
    # Runtime control: Proposal Start-UW Popup > Verify if popup is visible
    Then if the source runtime condition "Proposal Start-UW Popup > Verify if popup is visible" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0039: Click Existing Account button | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Cycle Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-cff6-240b-55921c535490
    # Runtime control: Proposal Start-UW Popup > Click Existing Account button
    When if the source runtime condition "Proposal Start-UW Popup > Click Existing Account button" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0040: Buffer the QuoteNumber | Module: EQ||Tabs
    # Section: Process > Generating Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-bb26-8169-f91a89b6d5b1
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0041: Trim the QuoteNumber | Module: TBox Set Buffer
    # Section: Process > Generating Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-6d94-8ad8-69fd327a690c
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0042: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Generating Cycle Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-d6a5-5121-1e93c87af016
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0043: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Generating Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-aa26-fae8-123e6c89fecd
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0044: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-20de-eb3b-7fe92e341c9a
    # Runtime control: If_Driver Sumary_Prior Insurance > Verify - If prior insurance is visible
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Verify - If prior insurance is visible" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0045: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-b252-7be6-ca3ea000726a
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
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

    # Source step 0046: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-76ca-ea0a-43250781d886
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
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

    # Source step 0047: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 04 Driver Information | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0048: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Generating Cycle Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-b4fd-8b67-53563f255947
    When I click "Btn_Next"

    # Source step 0049: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-ce4b-1dc7-e80b3dcaed62
    # Runtime control: Select Vehicle information > Verify vehicles are visible
    Then if the source runtime condition "Select Vehicle information > Verify vehicles are visible" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0050: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-11f7-5872-abe142c84931
    # Runtime control: Select Vehicle information > Select any one of Vehicle 
    When if the source runtime condition "Select Vehicle information > Select any one of Vehicle" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0051: Enter Vehicle information | Module: EQ||Vehicle Summary
    # Section: Process > Generating Cycle Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-4ec7-60a2-ec588371e60b
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
    When I enter or select "{Invoke[Click]}{SENDKEYS[450]}" in "Txt_Engine CC"
    When I enter or select "{CLICK}{SENDKEYS[40]}" in "Txt_AnnualMileage"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0052: Select Driver in Driver Assignment page | Module: EQ||Driver Assignment
    # Section: Process > Generating Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-31db-b903-031ad2cafebd
    Then I wait until "Hdr_Driver Assignment" is visible
    When I click "Btn_2002 Lexus GS430"
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0053: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-22a3-8931-c908db30b9a9
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0054: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-24db-ddaf-55696426d357
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0055: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Cycle Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-7bcb-e5c7-ffcc1408e53f
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0056: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 06 Driver Assignment | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0057: Verifiy Claim/violations are visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-c058-e18e-89bf11484889
    # Runtime control: Claims/Violations Popup > Verifiy Claims are visible
    Then if the source runtime condition "Claims/Violations Popup > Verifiy Claims are visible" is satisfied, "Hdr_Claims" should be visible

    # Source step 0058: Click on Add claim | Module: EQ||Claims\Violations
    # Section: Process > Generating Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-f6a2-3628-f9a7f1dfbac9
    # Runtime control: Claims/Violations Popup > Add Claim 
    When if the source runtime condition "Claims/Violations Popup > Add Claim" is satisfied, I click "Btn_+ ADD CLAIM"

    # Source step 0059: Add claim related details | Module: EQ | Claim Summary
    # Section: Process > Generating Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-3cb8-5ed9-2656a959e814
    # Runtime control: Claims/Violations Popup > Add Claim 
    When if the source runtime condition "Claims/Violations Popup > Add Claim" is satisfied, I click "Btn_Open"
    When I select "Not At Fault"
    When I click "Collision"
    When I click "Gayland Kearney"
    When I enter or select "{Click}{SENDKEYS[100]}" in "Claim Amount TextBox"
    When I enter a RANDOM value matching "1 random digits/characters" in "fields.losses.loss.rows[0].lossInput$dateOfLoss.value"
    When I click "Save and Continue"

    # Source step 0060: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-a33c-f3d2-d52ebc1f2e35
    # Runtime control: Claims/Violations Popup > Add Claim 
    When if the source runtime condition "Claims/Violations Popup > Add Claim" is satisfied, I click "Btn_Next"

    # Source step 0061: Click on Next button | Module: EQ||Claims\Violations
    # Section: Process > Generating Cycle Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-0c85-888f-33bba386c25c
    # Runtime control: Claims/Violations Popup > Click on Next button
    When if the source runtime condition "Claims/Violations Popup > Click on Next button" is satisfied, I click "Btn_Next"

    # Source step 0062: Enter Details in Discount page | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Cycle Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-b760-4dae-b087a7205e89
    Then I wait until "Hdr_Discounts / Adjustments" is visible
    When I click "Btn_Next"

    # Source step 0063: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-f826-a9bc-fc7696afc115
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0064: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2ca6-2e4c-c20e-3ef102df16b6
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0065: Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-fb56-b400-48b4702ca6d2
    Then I wait until "<unnamed value>" is visible
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0066: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-6b20-2cf0-78cbf3659619
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0067: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-c0e1-9cbd-f902ce308e6e
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0068: Enter Additional Coverage details | Module: EQ||Additional Coverages
    # Section: Process > Generating Cycle Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-eaf7-f2c0-1448c85ab3e1
    Then I wait until "Hdr_Additional Coverages" is visible
    When I click "Btn_BASIC"
    When I click "Btn_Next"

    # Source step 0069: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Cycle Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-4b05-d601-df4107f72649
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-20c2-3ca5-08a7fa9c6a03
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0071: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Generating Cycle Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-9299-5737-908e6f2d5feb
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0072: Enter Underwriting details | Module: <unresolved module>
    # Section: Process > Generating Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-cd37-3d7f-cc5166022e97
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0073: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Cycle Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-00da-e160-50ab073708c3
    When I click "btn_Next"

    # Source step 0074: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Generating Cycle Policy > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0080: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0081: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0085: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0086: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0087: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0088: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"
    When I enter the unresolved source parameter "PersonalAuto" (not supplied by this reusable-block invocation) in "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0089: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0090: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0091: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0093: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0095: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0097: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0098: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0099: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0100: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0101: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0102: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0103: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0104: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0105: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0106: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0107: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-4067-2516-3a6c59f89be9
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0108: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-a4e8-d040-e885712ec658
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0109: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-1e14-5017-e39bfefa4d49
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0110: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb6-51ba-65c1-d6682c417065
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0111: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-7c60-66c8-7466042bd2d8
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0112: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-1cc0-b153-8029f8338e28
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0113: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-6121-2e60-f4b073bc169d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0114: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-264f-6e48-76e2dbe7a577
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0115: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0119: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0120: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0121: EU||Home | Module: EU||Home
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0122: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0123: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0124: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0125: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0126: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0129: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Cycle Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0130: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Cycle Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-24ca-a899-ef54d2e9d78c
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0131: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Cycle Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-7075-fe63-46af6e2fd9de
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0132: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Cycle Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-b01b-9230-c1e2174ac23f
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0133: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-674c-ffea-49c2d2aa99a1
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0135: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-1afb-1254-a72bedc0d4f0
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0137: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-0ab3-064d-2f09ca4e95d7
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

    # Source step 0138: Clicn on Agent in checklist | Module: EQ||ECheckList
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-658f-d590-25cd6bbbb542
    When I click "Lnk_Auto/Cycle/RV Application"

    # Source step 0139: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-580d-da14-f26151d19f8d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0140: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-268c-4bd7-a0c6f49ba52e
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0141: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-749a-0b10-bbae357fa445
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0142: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-8257-f1c3-2e5ba95a61b4
    When I close the active browser

    # Source step 0143: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 14 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-9c86-d7ea-996f283e102a
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0144: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 15 Transmit  | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-6a32-4936-0e6314ae3886
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0145: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Cycle Policy > 15 Transmit  | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0146: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 15 Transmit  | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-6333-0068-75c2b827cf6b
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0147: Click on Save and Exit | Module: EQ||Submission
    # Section: Process > Generating Cycle Policy > 15 Transmit  | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-2cb4-3be9-005705a6813d
    When I click "Btn_Save and Exit"

    # Source step 0148: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Cycle Policy > TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-d817-a4bb-fa843056c050
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Activity Points - No Fault (Cycle) - NY"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0149: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Cycle Policy > TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-3edd-4823-a989ba63f5c6
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Activity Points - No Fault (Cycle) - NY"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0150: OpenUrl | Module: OpenUrl
    # Section: Process > Validate Activity Points | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0154: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-acbf-af80-7315d86efcde
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0155: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-bddd-e034-463cd0aeb780
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0156: Search  Policy Number | Module: EU||Home
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-22c2-86f6-5b5d11126eb2
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0157: Click on Motorcycle | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-15eb-0f43-48f276b068e8
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_Motorcycle" is visible
    When I click "Lnk_Motorcycle"

    # Source step 0158: Click on View policy | Module: EU||Transact
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-ce71-54d5-8bb242132d88
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0159: EU||Transact | Module: EU||Transact
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-ee3c-78c9-a932c99b1254
    # Runtime control: If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0160: EU||Transact | Module: EU||Transact
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-2297-5158-1f968eb50fd0
    # Runtime control: If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0161: Click on Pricing | Module: EU||Applicant
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-b35b-84a5-08fc2420a090
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0162: Buffer Activity points | Module: EU||Pricing
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-fd51-c07d-e5e49dac5022
    When I capture "InnerText" from "DIV_Risk Score" as runtime value "RiskScore"
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0163: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-c80d-3d7b-fa90917b40d6
    When I close the active browser

    # Source step 0164: Verifiy if Activitypoints is equal to 3 | Module: TBox Evaluation Tool
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-e0d0-1d05-a17c8983be90
    # Runtime control: Evaluating Activity Points is 3 or not > Verifiy if Activitypoints is equal to 3
    Then if the source runtime condition "Evaluating Activity Points is 3 or not > Verifiy if Activitypoints is equal to 3" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='3'"

    # Source step 0165: Activity points for Not at fault_NY is as Expected | Module: TBox Set Buffer
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-9c40-6254-ecb05cf2f45a
    # Runtime control: Evaluating Activity Points is 3 or not > Activity points for Not at fault_NY is as Expected
    When if the source runtime condition "Evaluating Activity Points is 3 or not > Activity points for Not at fault_NY is as Expected" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Expected" as runtime value "Activity Point_NY"

    # Source step 0166: Activity points for Not at fault_NY is as Fail | Module: TBox Set Buffer
    # Section: Process > Validate Activity Points | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2cb8-ce4d-5ae4-501c1cf9b4b9
    # Runtime control: Evaluating Activity Points is 3 or not > Activity points for Not at fault_NY is as Fail
    When if the source runtime condition "Evaluating Activity Points is 3 or not > Activity points for Not at fault_NY is as Fail" is satisfied, I retain hard-coded value "Activity points for Not at fault_NY is as Fail" as runtime value "Activity Point_NY"

    # Source step 0167: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Cycle" as runtime value "LOB"
    When I retain hard-coded value "NY" as runtime value "State"

    # Source step 0177: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0178: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0179:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0180: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0181: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0024 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0051 field "Txt_Engine CC's" in "Enter Vehicle information" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[450]}"
# 3. Source step 0075 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 4. Source step 0076 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 5. Source step 0077 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 6. Source step 0078 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 7. Source step 0082 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 8. Source step 0083 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 9. Source step 0084 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 10. Source step 0114 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 11. Source step 0116 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 12. Source step 0117 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 13. Source step 0118 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 14. Source step 0120 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0120 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 16. Source step 0124 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0124 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 18. Source step 0124 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0124 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0125 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0125 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 22. Source step 0125 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 23. Source step 0125 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0126 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 25. Source step 0126 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 26. Source step 0126 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0126 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0127 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 29. Source step 0128 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 30. Source step 0134 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 31. Source step 0135 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 32. Source step 0135 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 33. Source step 0135 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 34. Source step 0136 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 35. Source step 0139 field "H4" in "eChecklist-Verify if 'Application' links in the checklist are completed" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0140 field "H4" in "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0151 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 38. Source step 0152 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 39. Source step 0153 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 40. Source step 0168 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 41. Source step 0169 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 42. Source step 0170 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 43. Source step 0171 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 44. Source step 0172 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 45. Source step 0173 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 46. Source step 0174 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 47. Source step 0175 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 48. Source step 0176 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Activity Points - No Fault (Cycle) - NY_{DATE[][][MM/dd/yyyy]}_{TIME}"
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
