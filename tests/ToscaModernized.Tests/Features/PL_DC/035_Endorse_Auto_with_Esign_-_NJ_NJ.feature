# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 035_Endorse_Auto_with_Esign_-_NJ_NJ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @New_Jersey @Edge @manual @archive @automated
Feature: Execute Endorse Auto with Esign - NJ for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse Auto with Esign - NJ workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse Auto with Esign - NJ using representative iteration New Jersey (NJ)
    # Source step 0031: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2736-64d2-ed5b-bffd6c2a181f
    Given I wait until "<unnamed value>" exists
    When I enter captured runtime value "FirstName" in "<unnamed value>"
    When I enter captured runtime value "LastName" in "<unnamed value>"
    When I enter captured runtime value "DOB" in "<unnamed value>"
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"

    # Source step 0032: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2736-90f1-d14b-9d35af94efbb
    Then I wait until "Lbl_Account Information" is visible
    Then I wait until "Txt_First Name_Account Owner" is visible
    Then I wait until "Txt_Middle Name_Account Owner" is visible
    Then I wait until "Txt_Last Name_Account Owner" is visible
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I enter or select "9072090736" in "Txt_Best phone_Account Owner"
    When I enter or select "DICKFERNANDEZ1125@YAHOO.COM" in "Txt_Email_Account Owner"
    Then I wait until "Lbl_Marital Status:" is visible
    When I click "Btn_Single"
    When I enter captured runtime value "StreetAddress" in "Txt_Enter a location"
    When I enter captured runtime value "StreetAddress" in "Txt_owner.address.city_New"
    When I enter or select "NEW JERSEY" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" is visible
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0033: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-2d8a-ae12-060152c6d156
    Then I wait until "Btn_Personal Auto" is visible
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW JERSEY]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0034: Verify that Invalid address pop up is shown  | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-0e64-5745-4ef3370c97ab
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0035: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-0217-333a-fcaca301f200
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0036: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-29ef-cf5c-f4760a31e764
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0037: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-e00a-e773-6bb244fd36ba
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0038: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-82c1-9008-59791599cf8f
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"
    When I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0039: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-75bf-67eb-913b30175585
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0040: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-59d0-8170-0baee7cc3119
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0041: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-8deb-90a7-5fff603a74c0
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0042: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-a45d-ab32-2dabfa994639
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0043: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-8b15-89ca-f8430749d31e
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0044: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-cea6-404f-ac8efa57fafe
    Then I wait until "Hdr_Driver Information" is visible
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0045: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-53a5-fb88-d0937621fd85
    # Runtime control: Driver Summary-Gender Conditional > Verify - If prior insurance is visible
    Then if the source runtime condition "Driver Summary-Gender Conditional > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should be visible

    # Source step 0046: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-2bb4-0cfa-6b6cbe6f605f
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page
    When if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0047: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-a5ab-1782-86b4db2c8310
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page > Verify - If prior insurance is visible > Verify - If prior insurance is visible
    Then if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page > Verify - If prior insurance is visible > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should exist

    # Source step 0048: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-8b6f-a8be-c272fafc9b70
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page > Verify - If prior insurance is visible > Enter details in prior insurance page
    When if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page > Verify - If prior insurance is visible > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0049: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-7220-83a3-ea8b88088f63
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page > Verify - If prior insurance is visible > Enter details in prior insurance page
    Then if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page > Verify - If prior insurance is visible > Enter details in prior insurance page" is satisfied, "Btn_Male" should exist
    When I click "Btn_Male"
    When I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0050: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-28ba-18cb-71a0392a6657
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0051: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-de22-bc3a-2f038e6723a7
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0052: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-8c77-7852-74b0b06051f0
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0053: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-b8cd-a707-d83d94d3c269
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0054: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-8289-1d24-135ff5d46b70
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible" is satisfied, "Hdr_Vehicle Information" should be visible

    # Source step 0055: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-254d-d491-ae99bf79d4a0
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle 
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0056: Verifiy VIN is visible | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-e91f-a2e9-23ccfd4e76df
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0057: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-ac69-4a63-ba1674a1227e
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Enter Vehicle Summary Details
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Enter Vehicle Summary Details" is satisfied, "Lbl_VIN LABEL" should be visible
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" is visible
    When I click "Btn_SelectVehicle_1"
    Then "Btn_Own" should be visible
    When I click "Btn_Own"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" exists
    When I enter or select "No" in "Btn_Does this Vehicle"
    When I enter or select "10/10/2000" in "Txt_PurchaseDate"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0058: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-e9c1-f7e8-38086eca8399
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Enter Vehicle Summary Details
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Enter Vehicle Summary Details" is satisfied, "Lbl_VIN LABEL" should be visible
    When I enter or select "{CLICK}{Sendkeys[JT8BL69S020010343 ]}" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then "Lbl_Please select the vehicle" should be visible
    When I click "Btn_SelectVehicle_1"
    Then "Btn_Own" should be visible
    When I click "Btn_Own"
    Then "Lbl_Does this vehicle have any customized equipment?" should be visible
    When I enter or select "No" in "Btn_Does this Vehicle"
    When I enter or select "10/10/2000" in "Txt_PurchaseDate"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0059: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-684f-b171-9cbd68f3c8e1
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0060: Verify if pop up appears-Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-24a5-f7d3-0cf4a9d7d2b3
    # Runtime control: Driver Assignment- UW Popup > Verify if pop up appears-Continue
    Then if the source runtime condition "Driver Assignment- UW Popup > Verify if pop up appears-Continue" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0061: CLick Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-5ce0-0b7b-0f07fabc6659
    # Runtime control: Driver Assignment- UW Popup > CLick Continue
    When if the source runtime condition "Driver Assignment- UW Popup > CLick Continue" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0062: Verify If claim page is visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-7b53-a9a1-cad3a6cdcd96
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Verify If claim page is visible
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Verify If claim page is visible" is satisfied, "Hdr_Claims" should exist

    # Source step 0063: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-84ef-d147-ba97ffb2e7f4
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Click on Next
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Click on Next" is satisfied, I click "Btn_Next"

    # Source step 0064: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-bafc-4197-a7544aca9cb0
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0065: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-feed-12a1-fc034f2da131
    # Runtime control: Discounts-Review Discounts & Continue > Condition
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Condition" is satisfied, "Hdr_Discounts / Adjustments" should exist
    Then "Btn_D1_No" should be visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0066: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-b44b-5666-0ca1616b31fc
    # Runtime control: Discounts-Review Discounts & Continue > Then
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Then" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    When I select "Btn_No Proof of Prior Insurance"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0067: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-a2cb-280a-18c446a429d2
    # Runtime control: Discounts-Review Discounts & Continue > Else
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Else" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_Not Residential Property Owner"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0068: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-7af2-b675-2a49d2e7b845
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-051d-2082-96d2bdec3f4a
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0070: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-3f20-7de9-65f0783c67eb
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0071: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-ae33-bbc9-0e257b251b22
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0072: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-3b67-228f-17237212d380
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0073: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-f7c4-aaeb-12598c752c76
    When I select "Btn_UMPD No Coverage"
    When I click "Btn_Full"
    When I click "Btn_$15,000_PIP Limit"
    When I select "Btn_No Coverage_2"
    When I select "Btn_No_EXtra PIP Option"
    When I select "Btn_No_Auto Health Insurer"
    When I click "Btn_Next"

    # Source step 0074: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-ff05-a533-ba420adb5c6e
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0075: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-166d-a4fa-6b614c112ee4
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0076: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-ef0f-d99d-232e8fe19a17
    Then I wait until "Hdr_Pricing Details Header" is visible
    When I click "Btn_NEXT"

    # Source step 0077: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-6bd1-7617-11ed2a502cc8
    When I use source configuration "<unnamed value>" = "True" for "Underwriting-Review & Continue"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0078: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-2cde-17a7-fefda3e543d6
    When I click "btn_Next"

    # Source step 0079: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0084: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0085: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0086: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0090: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0091: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0092: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0093: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0094: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0095: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0096: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0097: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0098: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0099: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0100: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0101: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0102: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0103: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0104: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0105: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0106: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0107: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0109: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0110: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0111: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0112: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-74b7-446c-057aeb3eedee
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0113: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-8a6c-037d-6a2ebfdc021b
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0114: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-1c62-e311-116a694ea4ac
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0115: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-49b4-271f-56387ad7c317
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0116: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-2890-06f1-00c415eccd75
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0117: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-ee23-63ee-1fd032bc7e33
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0118: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-c6fc-8aee-0907d85d2a3d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0119: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-fd8a-b245-50da98daa5ba
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0120: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0124: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0125: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0126: EU||Home | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0127: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0128: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0129: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0130: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0131: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0134: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0135: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-b7ad-eef3-6dbcf497dc37
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0136: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-557e-4b84-dc35c43d354d
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0137: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2745-ae02-9168-504bc29deb21
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0138: Verify if Launch Esign is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2755-f29e-e199-65d367794441
    # Runtime control: Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible
    Then if the source runtime condition "Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible" is satisfied, "Btn_Launch To eSignature" should be visible

    # Source step 0139: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2755-ea38-da83-0ab330b415cf
    # Runtime control: Load till Launch Esign is visible [max=30] > Wait 
    When if the source runtime condition "Load till Launch Esign is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0140: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2755-0d83-ee02-97a416bd2487
    Then "Btn_Launch To eSignature" should be visible
    When I click "Btn_Launch To eSignature"

    # Source step 0141: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2755-c7f4-2e91-888c58043504
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0142: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-563d-a6fb-0bda08744d96
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

    # Source step 0143: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0144: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-3d49-4197-0e1040d4200f
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0145: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-6471-7f55-aa1b888e43b3
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0146: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-fa50-bcaa-8b7079f59c9a
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0147: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-ce4f-5fe2-e48d84cb5f50
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0148: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-22ab-3444-741ee1440332
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0149: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-9909-da98-9af24dc10ca3
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0150: Open Url | Module: Open Url_ARA
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-2232-41aa-f016cc67b740
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0151: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-5de3-bdf1-61a27fda9288
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0152: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-68c2-8ffc-182064d2b18c
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0153: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-ad3d-2905-8e1b8aecb7bc
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0154: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-fd83-d1e1-6aecc517d892
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0155: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-4add-5024-bd3fdc479ba2
    When I wait "6000" milliseconds

    # Source step 0156: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-d9c0-05fe-ddd24d8ce024
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0157: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-571c-8d67-6a04455146ea
    When I click "e-SignLive"

    # Source step 0158: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-9971-51c8-e09cb129e278
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0159: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-1b52-6ece-b42e8f106f55
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0160: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-cc75-2475-5d98457ad330
    When I close the active browser

    # Source step 0161: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-d676-f739-9934bd68c220
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0162: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-61c5-f756-e35a432079b9
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0163: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0164: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-9fe0-ed9c-ac15e458e48e
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0165: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-db05-0325-91e9ff2684e5
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0166: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-7b6e-de7f-ad72ffa1f187
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0167:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-99ff-e5de-8212bf69206f
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0168: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-99a9-1222-4da09b7aec32
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0169: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0170: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0171: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-a77d-401a-2a610c27ddff
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0172: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-47e1-e136-d1feae20fe0a
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0173: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-cfb8-c2f2-5284e6009ad2
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0174: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-db8a-ac4a-2ab275e22170
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0175: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-3738-ba2e-a31a48b1784d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0176: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-aa13-79ac-781e6ab3071b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0177:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-417d-cc08-f9f1c2cc8bf1
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0178: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-c5fc-4c27-0ea42dd50b01
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0179: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0180: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0181: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-0d72-6e56-324c31a1ae44
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0182: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0183: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-be5b-64f0-3124647a6b0c
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0184: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-947a-4412-a94de795a4a3
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0185: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-4136-7f2b-7ca866843322
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0186:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-0431-ae8d-86b524543315
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0187: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-0e6d-23c4-c45ca53cc8b8
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0188: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0189: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0190: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-bf6e-39aa-a5c734e60fd2
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0191: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-31d7-ec15-4e80a9883f43
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0193: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-5c2d-125b-580302d03acb
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0195: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-6b19-e168-e5e8f145dbcf
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

    # Source step 0196: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-1b87-f5b5-5cc987b70a8f
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0197: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-f4b9-4252-987a76502e08
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0198: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-6f32-598d-9b41d827da02
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0199: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-063b-2321-809aa694fd94
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0200: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-3e13-ace8-584201ca5c36
    When I close the active browser

    # Source step 0201: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-5eb6-2b9e-32b06073f953
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0202: Verify if Transmit is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-205e-4f12-145f67512f50
    # Runtime control: Load till Transmit is visible [max=30] > Verify if Transmit is visible
    Then if the source runtime condition "Load till Transmit is visible [max=30] > Verify if Transmit is visible" is satisfied, "Btn_Transmit" should be visible

    # Source step 0203: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-173f-3853-48c23ebef4b9
    # Runtime control: Load till Transmit is visible [max=30] > Wait 
    When if the source runtime condition "Load till Transmit is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0204: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-9255-e2c9-a56e44d15dfc
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0205: Buffer Tranmit Premiums | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-6c7e-60f8-bc7de68402c4
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0206: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2756-0339-bfce-49f93527facc
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse RV with Esign - NJ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0207: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-de43-3446-a66f40f49a44
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse RV with Esign - NJ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0208: Click save and exit | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-98ca-c3e7-78f535aaa40b
    When I click "Btn_Save and Exit"

    # Source step 0209: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0210: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-ef97-c6ac-d47558fc6520
    When I close the active browser

    # Source step 0211: OpenUrl | Module: OpenUrl_old
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-8942-2c8d-f3eb2360ce4e
    When I open "https://expertquote-qa.americannational.com/expertquote/#/quote"

    # Source step 0212: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-283a-9af9-8a884d268f96
    # Runtime control: Wait for Login Page [max=30] > Condition
    Then if the source runtime condition "Wait for Login Page [max=30] > Condition" is satisfied, "Txt_Username" should exist

    # Source step 0213: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Login Page [max=30] > Loop
    When if the source runtime condition "Wait for Login Page [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0214: Maximize Window | Module: TBox Window Operation
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-9a63-313c-d04b690d27b6
    When I enter or select "*Sign On*" in "Caption"
    When I enter or select "Maximize" in "Operation"

    # Source step 0215: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-6f7c-e4d8-6c2bb24c7913
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0216: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-842f-621a-5ed4982b19ce
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0217: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-ba9d-f999-2ada61f90ca9
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0218: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-089d-01c6-bc677bbe2a17
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0219: If Recall quote/policy is visible | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-0950-7156-7fe69aae809d
    # Runtime control: Recall quote/policy is visible > Verify if Recall quote/policy is visible
    Then if the source runtime condition "Recall quote/policy is visible > Verify if Recall quote/policy is visible" is satisfied, "Txt_Quote\\Policy Search" should be visible

    # Source step 0220: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2763-e7de-0d5f-72553178757a
    # Runtime control: Recall quote/policy is visible > Recall Quote\Policy
    When if the source runtime condition "Recall quote/policy is visible > Recall Quote\\Policy" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0221: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-df59-4e72-ac94e9f0073a
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0222: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-24a2-91a5-d81eca75a7b2
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0223: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-3518-565f-d1a5ebe686ce
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0224: Quick Actions | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-e333-efd9-b852fd708b7b
    When I click "Btn_+ CREATE NEW POLICY CHANGE"
    When I enter or select "{CLICK}{SENDKEYS[Endorse Coverage Limit]}" in "Txt_Policy Change Field"
    When I click "Btn_OK"

    # Source step 0225: Click on Coverages | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-05f4-445f-5bd4ac717000
    When I click "Coverages"

    # Source step 0226: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0227: Lower BI/PD Coverages | Module: <unresolved module>
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-bc0f-b535-3a1344e42820
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0228: Click on Discount page | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-2359-4ebf-1be68064e2dd
    When I click "Discounts / Adjustments"

    # Source step 0229: Select Auto-Home Discount | Module: EQ||Discounts\Adjustments
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-bd19-3532-c0adc8d1931f
    Then I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_check_box_Auto-Home" is visible
    When I click "Btn_check_box_Auto-Home"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0230: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-e0c4-9454-5068d3200b0b
    When I click "Submission"

    # Source step 0231: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0232: Verify XX0600 rulefire | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-fdc4-d726-38159391e54c
    Then "XX0600" should equal "XX0600"
    Then "You have manually added the Auto Home, discount. Please remove in order to proceed with binding." should equal "You have manually added the Auto Home, discount. Please remove in order to proceed with binding."

    # Source step 0233: Click on Discount page | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-abef-40db-ad22dfb17594
    When I click "Discounts / Adjustments"

    # Source step 0234: Remove Auto-Home Discount | Module: EQ||Discounts\Adjustments
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-0e17-7a3b-63fff0a90356
    Then I wait until "Hdr_Discounts / Adjustments" exists
    When I click "Btn_Uncheck_box_Auto-Home"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0235: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-2c95-a8d9-1cd87c89e07d
    When I click "Submission"

    # Source step 0236: Verify if Launch Esign is visible | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-d61b-ea4c-83860e694119
    # Runtime control: Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible
    Then if the source runtime condition "Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible" is satisfied, "Btn_Launch To eSignature" should be visible

    # Source step 0237: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-6ebf-8b9d-6a8129d1cf5e
    # Runtime control: Load till Launch Esign is visible [max=30] > Wait 
    When if the source runtime condition "Load till Launch Esign is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0238: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-a43b-7da1-eba34532334b
    When I click "Btn_Launch To eSignature"

    # Source step 0239: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-f73c-9d83-c2f9d22fb35a
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0240: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-8aa5-b1d8-9fe4f0818f11
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

    # Source step 0241: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0242: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-108c-1c97-71afb7a94807
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0243: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-08cf-14a1-91eaa0c17a0b
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0244: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-3570-7807-3a7401a5e096
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0245: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-b35d-6da7-ef834b8e796a
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0246: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-e3bf-e758-2f1f84fcfb87
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0247: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-264a-fdaa-52cbe886d308
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0248: Open Url | Module: Open Url_ARA
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-d6ea-3d26-d53a55b2d0af
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0249: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-ed3d-30a0-da6973d487e5
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0250: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-e69c-ce5e-df8b8d348215
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0251: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-3edb-5171-fa72f55d9456
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0252: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2765-2d72-9149-25a22fbc60a8
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0253: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-57d9-1967-dcaead084c58
    When I wait "6000" milliseconds

    # Source step 0254: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-859c-bb85-cab661456e80
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0255: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-b8e5-663d-6c539c939c25
    When I click "e-SignLive"

    # Source step 0256: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-9a78-fdfd-4c4eda079573
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0257: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-9478-fe29-2dca2d29325e
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0258: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-cfe5-8ecb-038dd45e3f14
    When I close the active browser

    # Source step 0259: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-b3d1-510a-5f0e4ffb64b4
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0260: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-6e76-8458-0d85d8405276
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0261: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0262: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-c954-373b-dcd103d8bf81
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0263: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-95da-4c69-47a2dfc14363
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0264: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-c6cb-b982-7360fe082f51
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0265:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-65f2-bcd6-3d5a73cdd60c
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0266: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-ac0c-d87e-bc804ce7eb5d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0267: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0268: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0269: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-303b-8018-26ad95b313ac
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0270: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-5d03-5d7f-3d0342bc2511
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0271: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-dc0b-a330-3ef0853c2136
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0272: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-61d4-8ecc-4ee9022b9e8c
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0273: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-64de-4938-05a68fddc511
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0274:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-40bb-e557-76d1fc693a26
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0275: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-eda5-2015-9c64615e654b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0276: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0277: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0278: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-17ca-d564-c3f3512499a9
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0279: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0280: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-ec88-31a8-fb3f298ca27e
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0281: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-597e-45ab-e72ab5f79555
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0282: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-b1d1-3b4e-17fe85ae0919
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0283:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-abbc-fece-e1285bfff844
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0284: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-f248-d153-5c29656fae59
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0285: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0286: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0287: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-3ec6-44c3-dfa0bc9ca842
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0288: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-1f19-fc9f-14a489ddb0ec
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0289: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-98e1-f9f0-c1f728bdfb92
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0290: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-276f-ae7b-dd68-f749746b4ead
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Auto with Esign - NJ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0291: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2774-8a48-54b8-47f7f29a25ec
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Auto with Esign - NJ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0292: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "NJ" as runtime value "State"

    # Source step 0302: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0303: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0304:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0305: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0306: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0024 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0032 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 3. Source step 0032 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 4. Source step 0032 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 5. Source step 0046 field "Txt_Years Licensed in Current State" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: ""
# 6. Source step 0049 field "Lbl_Gender" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0049 field "Lbl_Gender" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 8. Source step 0049 field "Btn_Male" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0049 field "Btn_Single" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0049 field "Txt_Months Licensed in Current State" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: "1"
# 11. Source step 0049 field "Txt_Date License" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 12. Source step 0057 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 13. Source step 0057 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0057 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 15. Source step 0057 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 16. Source step 0058 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 17. Source step 0058 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0058 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 19. Source step 0058 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 20. Source step 0073 field "Btn_No Coverage_UMPD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0073 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 22. Source step 0073 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 23. Source step 0073 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0073 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 25. Source step 0073 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 26. Source step 0073 field "Btn_No Coverage_Vehicle3" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 27. Source step 0073 field "Btn_UMPD_No Coverage_V3" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0073 field "Btn_UMPD_No Coverage_V4" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0080 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 30. Source step 0081 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 31. Source step 0082 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 32. Source step 0083 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 33. Source step 0087 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 34. Source step 0088 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 35. Source step 0089 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 36. Source step 0119 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 37. Source step 0121 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 38. Source step 0122 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 39. Source step 0123 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 40. Source step 0125 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 41. Source step 0125 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 42. Source step 0129 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0129 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 44. Source step 0129 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0129 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0130 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0130 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 48. Source step 0130 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 49. Source step 0130 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0131 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0131 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 52. Source step 0131 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0131 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 54. Source step 0132 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 55. Source step 0133 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 56. Source step 0144 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 57. Source step 0147 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 58. Source step 0192 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 59. Source step 0193 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 60. Source step 0193 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 61. Source step 0193 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 62. Source step 0194 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 63. Source step 0197 field "H4" in "eChecklist-Verify if 'Application' links in the checklist are completed" was disabled. Reason:  
#    - Preserved source value: "True"
# 64. Source step 0198 field "H4" in "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0205 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0205 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 67. Source step 0205 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0227 field "<unnamed value>" in "Lower BI/PD Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0227 field "<unnamed value>" in "Lower BI/PD Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 70. Source step 0227 field "<unnamed value>" in "Lower BI/PD Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 71. Source step 0227 field "<unnamed value>" in "Lower BI/PD Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 72. Source step 0242 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 73. Source step 0245 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 74. Source step 0289 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0289 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 76. Source step 0289 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 77. Source step 0293 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 78. Source step 0294 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 79. Source step 0295 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 80. Source step 0296 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 81. Source step 0297 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 82. Source step 0298 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 83. Source step 0299 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 84. Source step 0300 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 85. Source step 0301 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse Auto with Esign - NJ_{DATE[][][MM/dd/yyyy]}_{TIME}"
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
