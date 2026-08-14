# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 038_Endorse_with_Esign_RV_-_NM_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @New_Mexico @Edge @manual @archive @automated
Feature: Execute Endorse with Esign (RV) - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse with Esign (RV) - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse with Esign (RV) - NM using representative iteration New Mexico (NM)
    # Source step 0030: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27ed-d0e2-24c8-e4ed39c3cedf
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

    # Source step 0031: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27ed-6369-a768-93dd2b7b602a
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
    When I enter or select "NEW MEXICO" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" is visible
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0032: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-9954-f0ac-3f122253675b
    Then I wait until "Btn_Personal Auto" is visible
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW MEXICO]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0033: Verify if popup is visible | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-a0fe-5d05-7b5542e42d30
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0034: Click on Proceed button | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-8376-8894-fd9a77db2121
    # Runtime control: Prposal Start_Proceed  > Click on Proceed button
    When if the source runtime condition "Prposal Start_Proceed > Click on Proceed button" is satisfied, I click "Btn_PROCEED"

    # Source step 0035: Verify if confirm the client SSN# is visible | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-f47f-b34b-6096ba1f336a
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Verify if confirm the client SSN# is visible
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Verify if confirm the client SSN# is visible" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0036: Click on Confirm button | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-f48d-df94-992f5cae13f9
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Click on Confirm button
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Click on Confirm button" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0037: Enter SSN details | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-8b76-ec85-dc2f822b7210
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Enter SSN details
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Enter SSN details" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0038: Verify if popup is visible | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-337d-d4a8-c408e40b1328
    # Runtime control: Proposal Start-UW Popup > Verify if popup is visible
    Then if the source runtime condition "Proposal Start-UW Popup > Verify if popup is visible" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0039: Click Existing Account button | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-7b20-e9b0-6d198ba85ed9
    # Runtime control: Proposal Start-UW Popup > Click Existing Account button
    When if the source runtime condition "Proposal Start-UW Popup > Click Existing Account button" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0040: Trim the Buffered Value | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-7ca5-060b-fc915a7ba34c
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0041: Buffer the QuoteNumber | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-d557-6f08-338eb192253a
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0042: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-6d70-f947-4231e7a2a84a
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0043: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-bcde-56f7-cc8e466693d6
    Then I wait until "Hdr_Driver Information" is visible
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0044: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-3fd3-e60b-f631d7df6a84
    # Runtime control: If_Driver Sumary_Prior Insurance > Verify - If prior insurance is visible
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should be visible

    # Source step 0045: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-c015-2193-1de882164b6d
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0046: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-6401-1ba5-22ee776c2477
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Verify - If prior insurance is visible
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should exist

    # Source step 0047: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-2397-f5b0-767f1af4a294
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0048: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-8eb2-11ae-04f3004f0884
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details" is satisfied, "Btn_Male" should exist
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

    # Source step 0049: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-eb15-c67b-50ebfb484cfd
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0050: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-984b-4f26-b143aefdf231
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0051: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-6da8-4b9d-2403126b2f36
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0052: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-f636-d5e6-370085873bb4
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0053: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-7473-68ee-f2b63c5a04d7
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible" is satisfied, "Hdr_Vehicle Information" should be visible

    # Source step 0054: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27f4-8c70-b04d-b1092241881a
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle 
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0055: Verifiy VIN is visible | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-9a2c-2c92-7f951a683b1f
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0056: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-67cd-595a-5459501f5fd9
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

    # Source step 0057: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-7fe9-186b-d34bc435d9e3
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

    # Source step 0058: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-be38-46b8-dbf9f9025842
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0059: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-31bd-bbdb-d2d12fc5a85f
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0060: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-8c71-7138-85de60d6fb2c
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0061: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-fbb4-a1a6-670587efd8f2
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0062: Verify If claim page is visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-5da1-5a5a-006b870ba22e
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Verify If claim page is visible
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Verify If claim page is visible" is satisfied, "Hdr_Claims" should exist

    # Source step 0063: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-35fc-9070-38ec763fc40c
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Click on Next
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Click on Next" is satisfied, I click "Btn_Next"

    # Source step 0064: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-2aa8-5a4b-32e80ed2c7bc
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0065: Verify if Discount page is visible | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-e09e-beab-a16a3b1c913d
    # Runtime control: Discounts-Review Discounts & Continue > Verify if Discount page is visible
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Verify if Discount page is visible" is satisfied, "Hdr_Discounts / Adjustments" should exist

    # Source step 0066: Select Auto-Home and proceed | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-3d5e-434e-713042df3df9
    # Runtime control: Discounts-Review Discounts & Continue > Click Next 
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Click Next" is satisfied, I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0067: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-f2f6-aeda-0e04126c37b8
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-a822-da8e-84c7b5790495
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0069: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-e1aa-a377-d04caefae99d
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0070: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-ab42-301a-df3173cc4a66
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-07ce-21f1-0b4f8ffca6b3
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0072: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-9a13-b7e3-ab17ddc75201
    When I select "Btn_No Coverage_Accidental Death & Dismemberment"
    When I select "Btn_UMPD_No Coverage_V1"
    When I click "Btn_check_box_outline_blankKcmgw Unzp"
    When I click "Btn_Next"

    # Source step 0073: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-10eb-f5ac-a92f840afdf4
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 10 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-db84-f89a-d35e7e034f5a
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0075: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-b288-1ddd-9cd6d498b59f
    Then I wait until "Hdr_Pricing Details Header" is visible
    When I click "Btn_NEXT"

    # Source step 0076: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-e589-4eb0-c775007c4b72
    When I use source configuration "<unnamed value>" = "True" for "Underwriting-Review & Continue"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0077: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-96fa-35e7-ae70422f731a
    When I click "btn_Next"

    # Source step 0078: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0084: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0085: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0089: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0090: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0091: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0092: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0093: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0095: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0097: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0099: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0100: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0101: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0102: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0103: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0104: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0105: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0106: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0107: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0108: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0109: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0110: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0111: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-8eb0-9347-5f8a2871b0f4
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0112: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-ccf1-6edf-6c1fb680c799
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0113: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-f2d5-9bbf-b19cadce6ce7
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0114: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-aea2-f632-bcb07b969967
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0115: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-4698-a512-c4bd4bd88cc3
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0116: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-eccb-cae0-b121a1bfd487
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0117: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-764f-5823-4b2f9d30bda9
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0118: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-fb26-b501-8d38961cf08e
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0119: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0123: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0124: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0125: EU||Home | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0126: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0127: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0128: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0129: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0130: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0133: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0134: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-652a-bbc3-a3bf6816120d
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0135: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-d678-74bf-cdd2c3ea8e16
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0136: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-a491-29f5-05cc279b6586
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0137: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-fd8a-6bef-bb8c8715c76d
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0138: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-f9d6-9d73-971d2e855d53
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0139: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-8840-8c07-39288f0650fc
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

    # Source step 0140: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0141: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-209e-3b77-b6385fee29e4
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0142: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-1010-8990-3f2eb6abe5a4
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0143: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-e560-8139-ad95da151aa5
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0144: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-0c87-2f4f-3fc175d6ed76
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0145: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-2aa3-010e-bfddc3e2823d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0146: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-8eec-7b5a-6bc7e5bc156e
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0147: Open Url | Module: Open Url_ARA
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-9fd8-4728-a2c1fbe31edd
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0148: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-8a66-cdbd-a179d9e51852
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0149: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-3414-f36d-2788063ad706
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0150: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-27fc-9e73-0d11-8bef6429e577
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0151: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-fc52-941b-e06ab57e5536
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0152: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-a3e6-a148-c6760af13020
    When I wait "6000" milliseconds

    # Source step 0153: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-7552-80ff-d946d865a5b3
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0154: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-ac88-0383-d47123a26e7f
    When I click "e-SignLive"

    # Source step 0155: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-9791-6075-5c6ace2c794b
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0156: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-f6a3-2823-703ccb0451d6
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0157: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-7903-8ff0-3b17bd7a7358
    When I close the active browser

    # Source step 0158: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-7fec-0a87-a937cca7f580
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0159: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-ea82-5270-3477c425e062
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0160: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0161: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-78e0-0208-2e3d3d11fc59
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0162: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-0da1-505a-4563e3e5b75d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0163: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-375e-847d-fa95c65db689
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0164:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-10a4-51b2-99d16d40606d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0165: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-ed31-113d-4c5449c8ba4d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0166: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0167: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0168: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-35ad-b9e1-809c888096fe
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0169: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-d45e-487f-d7c05a8f1018
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0170: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-db79-0c39-0185427b5af4
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0171: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-09ac-d2d6-ee49bbd27ed7
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0172: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2804-de84-9f19-f445370b96c5
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0173: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-3fdc-b775-23584b5b8903
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0174:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-ed7a-a82c-3dde97e3d911
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0175: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-9e52-263d-a7464b8f51ab
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0176: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0177: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0178: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-3206-d9c5-7e950f9a59f3
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0179: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0180: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-7ffb-97ad-2bce107ea07f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0181: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-a8b2-db03-73c1bcc344d5
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0182: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-656d-6f66-619ad58f4cfd
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0183:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-febd-0cd1-dc8cd7ce350f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0184: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-44f0-2918-55b00dbd76a3
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0185: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0186: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0187: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-7443-b835-7b7a4d7b92ad
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0188: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-ac99-e069-1f9303222553
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0190: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2814-058b-20a0-8fdcda5146c9
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0192: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2823-2011-f149-8743bf96b105
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

    # Source step 0193: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2824-71df-1349-ed453b46795e
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0194: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2824-be8b-3418-75fdcdfd6df5
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0195: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2824-8c8f-6129-5a636f1fd2c1
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0196: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2824-6640-3609-002f0afe9781
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0197: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2825-9814-abb2-2519755cb445
    When I close the active browser

    # Source step 0198: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2825-936f-785c-a7eb6de7ee52
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0199: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2825-8eab-6e61-a62a5b398ba2
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0200: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2825-f3db-1737-acb685a32ff8
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0201: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2825-e1f8-0170-254d01643e56
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse with Esign (RV) - NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0202: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2825-88ae-9da4-0950152bb29c
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse with Esign (RV) - NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0203: Click on policy History | Module: EQ | Side Menu
    # Section: Process > Generating Recreation Vehicle > 01 Recall Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-2cc2-cfc1-8f1f8dadd7af
    When I click "Policy History"

    # Source step 0204: EQ||Quick Actions | Module: EQ||Quick Actions
    # Section: Process > Generating Recreation Vehicle > 01 Recall Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-fd4b-8111-2091317e9d5a
    When I click "Btn_QUOTE ACTIONS"
    When I click "Btn_New Quote Same Client"

    # Source step 0205: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Recreation Vehicle > 02 Changing Vehicle to RV  | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-0fee-0f7c-4656beb8ca44
    When I click "Btn_Recreational Vehicle"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW MEXICO]}" in "Drp List_Proposal Rating State"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0206: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Recreation Vehicle > 03 PreQualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-bb2d-1990-9ca9fbb5cd65
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" exists
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0207: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-a82b-7d85-4e8e867dbada
    Then I wait until "Hdr_Driver Information" is visible
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0208: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-ae28-1073-67978c10ab7b
    # Runtime control: If_Driver Sumary_Prior Insurance > Verify - If prior insurance is visible
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should be visible

    # Source step 0209: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-d094-e746-f16b7c5e1bd0
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0210: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-233a-db1b-f28ff471861f
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Verify - If prior insurance is visible
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should exist

    # Source step 0211: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-a113-8b8f-956f8fa3a41b
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Btn_Primary Named Insured"
    When I click "Btn_Save and Continue"

    # Source step 0212: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2834-5643-5004-89214394f05c
    # Runtime control: If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Enter details in prior insurance page > If prior insurance is visible > Driver Summary-Enter Driver Summary Details" is satisfied, "Btn_Male" should exist
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

    # Source step 0213: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2843-6aac-9558-dc03d4c17fee
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0214: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2843-b14b-e635-9852f5af3d8c
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0215: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2843-c787-e07e-38ca2137b5c1
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0216: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2844-3b34-f33b-049cdaf3df40
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0217: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2844-62d7-136a-adb63ce961b9
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible" is satisfied, "Hdr_Vehicle Information" should be visible

    # Source step 0218: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2844-65a3-ed48-c48d1aeec65f
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle 
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0219: Verifiy VIN is visible | Module: EQ||Vehicle Summary
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2844-8a49-e959-91d2ef558a04
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0220: Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2844-d915-c248-7cb095fe7d4c
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Enter Vehicle Summary Details
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Enter Vehicle Summary Details" is satisfied, I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "4XAHH68A992870818" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    When I select "Btn_Is this vehicle used for racing?_No"
    When I select "Btn_Cycle_Customizatioin_No"
    When I select "Btn_Is this vehicle licensed for road use?_No"
    When I click "Btn_Save and Continue"

    # Source step 0221: Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2845-f7f0-caa9-28ed92ec0173
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, I wait until "Txt_VIN number" is enabled
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I click "Txt_VIN number"
    When I enter or select "4XAHH68A992870818" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then I wait until "Btn_Own" exists
    When I click "Btn_Own"
    When I select "Btn_Is this vehicle used for racing?_No"
    When I select "Btn_Cycle_Customizatioin_No"
    When I select "Btn_Is this vehicle licensed for road use?_No"
    When I click "Btn_Save and Continue"

    # Source step 0222: Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-1035-8cf0-02ba96fdeffe
    When I click "Btn_Next"

    # Source step 0227: Verify If claim page is visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Recreation Vehicle > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-6f78-7a23-1bba8d58b34e
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Verify If claim page is visible
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Verify If claim page is visible" is satisfied, "Hdr_Claims" should exist

    # Source step 0228: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Recreation Vehicle > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-a4e1-5b27-37ac1484578a
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Click on Next
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Click on Next" is satisfied, I click "Btn_Next"

    # Source step 0229: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Recreation Vehicle > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-a821-ba6b-6d94a25d937f
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0230: Verify if Discount page is visible | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Recreation Vehicle > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-0f78-06c7-2efabfc8efbb
    # Runtime control: Discounts-Review Discounts & Continue > Verify if Discount page is visible
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Verify if Discount page is visible" is satisfied, "Hdr_Discounts / Adjustments" should exist

    # Source step 0231: Select Auto-Home and proceed | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Recreation Vehicle > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-6546-b5f6-a874d66d426e
    # Runtime control: Discounts-Review Discounts & Continue > Click Next 
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Click Next" is satisfied, I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0232: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-83bf-85ab-bcc323878efa
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0233: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2853-da04-0955-c9d1346535cd
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0234: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-a02b-6b4e-18615d2cc4e6
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0235: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-1620-b96e-6fad9f81128d
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0236: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-878e-bd08-ecb4ae44779e
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0237: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-44fd-63a5-77b2c611c8e4
    When I select "Btn_UMPD_No Coverage_V0"
    When I click "Btn_Next"

    # Source step 0238: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Recreation Vehicle > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-18ad-86f8-93d1b63404b6
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0239: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-2447-9895-8cd5168300fd
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0240: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > Generating Recreation Vehicle > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-5356-6b16-a4850a2828df
    Then I wait until "Hdr_Pricing Details Header" is visible
    When I click "Btn_NEXT"

    # Source step 0241: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Recreation Vehicle > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-eecb-5a20-8cf30a707cbc
    When I use source configuration "<unnamed value>" = "True" for "Underwriting-Review & Continue"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0242: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Recreation Vehicle > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2862-df5c-a63e-690cb03f9901
    When I click "btn_Next"

    # Source step 0243: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Generating Recreation Vehicle > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0248: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0249: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0253: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0254: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0255: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0256: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0257: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0258: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0259: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0260: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0261: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0262: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0263: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0264: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0265: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0266: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0267: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0268: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0269: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0270: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0271: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0272: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0273: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0274: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0275: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-51ee-fe28-d5296f723766
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0276: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-bacd-7ede-d857bedb7924
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0277: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-7836-390f-1aff60b72f5d
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0278: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-3076-a917-9a60f4e01c98
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0279: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-0ffa-e935-a2aa94de3040
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0280: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-d23e-72d8-63d5fb7daa3c
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0281: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-b8c4-179a-432f1a96cad7
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0282: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2864-655f-4981-19cdea2f0a5e
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0283: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0287: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0288: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0289: EU||Home | Module: EU||Home
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0290: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0291: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0292: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0293: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0294: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0297: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0298: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-626d-960c-4a23926bb216
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0299: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-5d0d-5546-8b6635deb804
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0300: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-7a4d-7532-c724232c70c9
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0301: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-e3e3-cd25-7950ef024bd6
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0302: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-fdc1-2673-cb0b134bbb93
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0303: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-ae5f-4851-d09947a00bd3
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

    # Source step 0304: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0305: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-1679-e5ea-ef81f5548710
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0306: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-6bdf-eaac-3055beab4c99
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0307: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-760c-8afe-ca8acb8d6afd
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0308: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-dd84-9f39-17e993bf21b1
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0309: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-ee2d-ddbe-cfe101cf615b
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0310: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-675f-b91b-e9cc4dbea0fb
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0311: Open Url | Module: Open Url_ARA
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2872-ee55-8e6a-5549bd2b7e2b
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0312: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-dcb1-b853-a7a19b2000ac
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0313: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-a73e-35e7-333bbdb88973
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0314: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-e2e3-968d-110cf998fb72
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0315: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-2c49-ff76-d4f626637d5f
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0316: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-35d8-5e98-21b6e320b81b
    When I wait "6000" milliseconds

    # Source step 0317: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-48ff-c00a-d6f096b86da1
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0318: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-3991-0be0-9f907553c231
    When I click "e-SignLive"

    # Source step 0319: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-6f81-90c2-a94b172989ba
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0320: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-4b78-ca08-7f820e360718
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0321: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-993a-24e9-7ecf76675cc9
    When I close the active browser

    # Source step 0322: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-97ca-57ae-d07fee0e9131
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0323: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-eeed-284f-648a9d22308b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0324: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0325: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-8711-d60b-f010c1e11db6
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0326: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-dc22-da02-13177a9e1c29
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0327: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-ae13-413c-932cc51d9178
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0328:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-0e8f-73f0-0899a5f6fd35
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0329: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-a722-c03b-fc3f243ff140
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0330: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0331: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0332: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-9d0a-a2ba-8f31ae8cc09c
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0333: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-f78b-2351-483f73c93611
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0334: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2882-5c53-113b-7ebb62ac6e30
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0335: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2891-4e37-0d99-093b85c5d153
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0336: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2891-a237-b272-522c79e15627
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0337: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2891-1f42-73cc-264de2dd8450
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0338:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2891-5f7e-cd8d-781463caf43a
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0339: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2891-5866-5b60-4e2b166e9f6e
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0340: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0341: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0342: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2891-acaf-208f-1306161d18cd
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0343: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0344: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-ce33-f69b-18d8c6482094
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0345: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-0d1e-0d8f-d1c5abfe4563
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0346: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-0f07-e269-f525721f6f2d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0347:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-7bff-f146-bea69b88e219
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0348: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-a070-62c0-2ed1a918b771
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0349: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0350: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0351: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-3cdc-2ec0-b781c1e1e7ff
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0352: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2893-569c-4a6c-3aa8093a4550
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0354: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2895-1213-be02-07c43b8e84eb
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0356: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-c5cb-9b92-b4fc1d6af9e4
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

    # Source step 0361: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-dc68-9639-29631b5c5ccc
    When I close the active browser

    # Source step 0362: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-6917-1c17-ae63ff8e31f9
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0363: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-8d64-2b63-84c30ecd4354
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0364: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-6f46-da04-7747052ca8ce
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0365: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Recreation Vehicle > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-4683-2f38-8e279d7c9db5
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse with Esign (RV) - NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0366: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Recreation Vehicle > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28a1-9a85-3b7a-00fa2fcadd6c
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse with Esign (RV) - NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0367: Click save and exit | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-894a-cdea-8ae9721d916e
    When I click "Btn_Save and Exit"

    # Source step 0368: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0369: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-b69c-25f8-59869c4759a5
    When I close the active browser

    # Source step 0370: OpenUrl | Module: OpenUrl_old
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-8942-2c8d-f3eb2360ce4e
    When I open "https://expertquote-qa.americannational.com/expertquote/#/quote"

    # Source step 0371: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-283a-9af9-8a884d268f96
    # Runtime control: Wait for Login Page [max=30] > Condition
    Then if the source runtime condition "Wait for Login Page [max=30] > Condition" is satisfied, "Txt_Username" should exist

    # Source step 0372: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Login Page [max=30] > Loop
    When if the source runtime condition "Wait for Login Page [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0373: Maximize Window | Module: TBox Window Operation
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-9a63-313c-d04b690d27b6
    When I enter or select "*Sign On*" in "Caption"
    When I enter or select "Maximize" in "Operation"

    # Source step 0374: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-6f7c-e4d8-6c2bb24c7913
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0375: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-b504-4b0e-24ec70e08810
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0376: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-5015-3f1a-fa6b19cfc0ed
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0377: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-8106-944e-4a97d0793f3f
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0378: If Recall quote/policy is visible | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-16c8-bd63-44fccb1f0167
    # Runtime control: Recall quote/policy is visible > Verify if Recall quote/policy is visible
    Then if the source runtime condition "Recall quote/policy is visible > Verify if Recall quote/policy is visible" is satisfied, "Txt_Quote\\Policy Search" should be visible

    # Source step 0379: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-d404-4d96-9a83e22c3d70
    # Runtime control: Recall quote/policy is visible > Recall Quote\Policy
    When if the source runtime condition "Recall quote/policy is visible > Recall Quote\\Policy" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0380: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-80f8-b8d0-6f8ac3666342
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0381: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-95f9-7d9d-036b5f625ea2
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0382: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-50fb-413c-0633115a0de0
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0383: Quick Actions | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-055a-557e-98c41f7a6983
    When I click "Btn_+ CREATE NEW POLICY CHANGE"
    When I enter or select "{CLICK}{SENDKEYS[Endorse Coverage Limit]}" in "Txt_Policy Change Field"
    When I click "Btn_OK"

    # Source step 0384: Click on Coverage | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-e9ef-54d8-6384001fbb0e
    When I click "Coverages"

    # Source step 0385: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0386: Lower BI/PD Coverage | Module: <unresolved module>
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-0169-1a3c-7e53d38a7eed
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0387: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28b4-e7a3-3730-e90fbf62e9ef
    When I click "Submission"

    # Source step 0388: Verify if Launch Esign is visible | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c1-7fab-fa49-dc535f3fa263
    # Runtime control: Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible
    Then if the source runtime condition "Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible" is satisfied, "Btn_Launch To eSignature" should be visible

    # Source step 0389: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c1-2c82-2fac-fccef496d706
    # Runtime control: Load till Launch Esign is visible [max=30] > Wait 
    When if the source runtime condition "Load till Launch Esign is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0390: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c1-9c42-d50c-ef1dc972a2f8
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0391: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c1-cae2-1c02-564a0b5ca670
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0392: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-ce2d-963a-201116f4cb7a
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

    # Source step 0393: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0394: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-13ab-15e2-4c539fb6cf79
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0395: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-502e-f54b-0fb6b5482b70
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0396: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-bf08-a359-e7e43394f6f9
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0397: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-fd1b-7305-858b2d92e8f1
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0398: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-d130-3c84-879e11ab2cc9
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0399: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-160f-2587-0378a479606a
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0400: Open Url | Module: Open Url_ARA
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-a407-cb3d-55b3b5ba0f3e
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0401: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-88bd-acd8-b3c508c2dccf
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0402: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-e4a0-0dd6-387f280ddd1d
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0403: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-fb9d-e5be-ab22ee4068df
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0404: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28c2-6c1c-c813-03922d1dc11c
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0405: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-8bc8-54b4-183032d1bb18
    When I wait "6000" milliseconds

    # Source step 0406: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-fced-7d50-8bfb18635e22
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0407: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-a5f5-6dcb-b0cb0d03291c
    When I click "e-SignLive"

    # Source step 0408: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-507a-683c-ecd8a22413fc
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0409: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-e829-f02c-c308e12a6b60
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0410: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-154d-ec9b-5f6f2e4475ad
    When I close the active browser

    # Source step 0411: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d1-9b2d-b9d9-cdbe8ca813c2
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0412: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d2-0e63-91f5-122a52d024e2
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0413: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0414: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d2-42de-bb8a-e5deb13a9cd1
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0415: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d2-bad9-9a80-1a6827c541c6
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0416: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d2-03bb-4689-586c374536d5
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0417:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d2-942f-3c3d-7cd30cf988f3
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0418: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d2-885b-85b2-6f2f805aa2a2
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0419: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0420: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0421: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d3-d9b1-7afb-bbc8e74b63a5
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0422: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d3-1054-9ec7-8d042a36342c
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0423: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d3-c578-02a2-7f3edab78f34
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0424: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d3-4b89-aa5f-f375414257c2
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0425: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d3-d878-529e-75927b78b976
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0426:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28d3-5d89-0a52-9203e494552b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0427: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-463a-3763-924b1387f90a
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0428: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0429: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0430: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-aa39-d4c4-f912ea3f39f2
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0431: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0432: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-2fdb-dd68-2608db39d0a2
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0433: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-7b25-a6f1-51be6e301d1c
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0434: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-0f67-eb2d-669837512127
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0435:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-8f3e-775c-91c511be9085
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0436: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-7edd-1e70-9a3fb3900a7d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0437: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0438: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0439: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-c6e2-8290-3c961d0c335d
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0440: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-c9db-1c9a-aa21a9e549a6
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0441: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-78a5-aaa0-2f0e01d7c8cf
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0442: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-42b2-e95c-012dbcb1460e
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Auto with Esign - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0443: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-28e0-b615-a6da-0e5e9e8d5a72
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Auto with Esign - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0444: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "NM" as runtime value "State"

    # Source step 0454: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0455: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0456:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0457: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0458: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0024 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0031 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 3. Source step 0031 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 4. Source step 0031 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 5. Source step 0045 field "Txt_Years Licensed in Current State" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: ""
# 6. Source step 0048 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0048 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 8. Source step 0048 field "Btn_Male" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0048 field "Btn_Single" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0048 field "Txt_Months Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 11. Source step 0048 field "Txt_Date License" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 12. Source step 0056 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 13. Source step 0056 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0056 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 15. Source step 0056 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 16. Source step 0057 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 17. Source step 0057 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0057 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 19. Source step 0057 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 20. Source step 0072 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0072 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 22. Source step 0072 field "Btn_No Coverage_2" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 23. Source step 0072 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 24. Source step 0072 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 25. Source step 0079 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 26. Source step 0080 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 27. Source step 0081 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 28. Source step 0082 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 29. Source step 0086 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 30. Source step 0087 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 31. Source step 0088 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 32. Source step 0118 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 33. Source step 0120 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 34. Source step 0121 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 35. Source step 0122 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 36. Source step 0124 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0124 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 38. Source step 0128 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 39. Source step 0128 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 40. Source step 0128 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 41. Source step 0128 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
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
# 50. Source step 0131 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 51. Source step 0132 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 52. Source step 0141 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 53. Source step 0144 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 54. Source step 0189 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 55. Source step 0190 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 56. Source step 0190 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 57. Source step 0190 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 58. Source step 0191 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 59. Source step 0194 field "H4" in "eChecklist-Verify if 'Application' links in the checklist are completed" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0195 field "H4" in "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0200 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0200 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 63. Source step 0200 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0209 field "Txt_Years Licensed in Current State" in "Enter details in prior insurance page" was disabled. Reason:  
#    - Preserved source value: ""
# 65. Source step 0212 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0212 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 67. Source step 0212 field "Btn_Male" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0212 field "Btn_Single" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0212 field "Txt_Months Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 70. Source step 0212 field "Txt_Date License" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 71. Source step 0220 field "Btn_SelectVehicle_Option1" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 72. Source step 0220 field "Btn_Automobile" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 73. Source step 0220 field "Btn_ATV" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 74. Source step 0220 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 75. Source step 0220 field "Lbl_Does this vehicle have any customized equipment?" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0220 field "Btn_Does this Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "No"
# 77. Source step 0220 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0220 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 79. Source step 0220 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0220 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "04/21/2000"
# 81. Source step 0220 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 82. Source step 0220 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 83. Source step 0220 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 84. Source step 0220 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "120000"
# 85. Source step 0220 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 86. Source step 0220 field "Btn_Add Additional Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 87. Source step 0221 field "Btn_SelectVehicle_Option1" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0221 field "Btn_Automobile" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 89. Source step 0221 field "Btn_ATV" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 90. Source step 0221 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 91. Source step 0221 field "Lbl_Does this vehicle have any customized equipment?" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0221 field "Btn_Does this Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "No"
# 93. Source step 0221 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0221 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 95. Source step 0221 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0221 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "04/21/2000"
# 97. Source step 0221 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 98. Source step 0221 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0221 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 100. Source step 0221 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "120000"
# 101. Source step 0221 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 102. Source step 0221 field "Btn_Add Additional Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 103. Source step 0223 "Verify Driver Information is visible" in module "EQ||Driver Summary" was disabled. Reason: 31.05.24 10:34:48 [ct2628]
#    - WAIT "Lnk_UWR_BACK TO DETAILS" with "True"
#    - VERIFY "Lnk_UWR_BACK TO DETAILS" with "True"
# 104. Source step 0224 "Driver Summary-Enter Driver Summary Details" in module "EQ||Driver Summary" was disabled. Reason: 31.05.24 10:34:48 [ct2628]
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 105. Source step 0225 "Driver Summary-Enter Driver Summary Details" in module "TBox Set Buffer" was disabled. Reason: 31.05.24 10:34:48 [ct2628]
#    - INPUT "UW Popup" with "Popup not appeared"
# 106. Source step 0226 "Driver Assignment-Select Driver Assignment & Continue" in module "EQ||Driver Assignment" was disabled. Reason: 31.05.24 10:34:48 [ct2628]
#    - WAIT "Hdr_Driver Assignment" with "True"
#    - INPUT "Btn_Vehicle_Select" with "X"
#    - WAIT "Lbl_Principal or Occasional driver of this vehicle?" with "True"
#    - INPUT "Btn_Principal_New" with "X"
#    - INPUT "Btn_Next" with "X"
# 107. Source step 0244 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 108. Source step 0245 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 109. Source step 0246 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 110. Source step 0247 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 111. Source step 0250 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 112. Source step 0251 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 113. Source step 0252 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 114. Source step 0282 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 115. Source step 0284 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 116. Source step 0285 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 117. Source step 0286 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 118. Source step 0288 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 119. Source step 0288 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 120. Source step 0292 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 121. Source step 0292 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 122. Source step 0292 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 123. Source step 0292 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 124. Source step 0293 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 125. Source step 0293 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 126. Source step 0293 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 127. Source step 0293 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 128. Source step 0294 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 129. Source step 0294 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 130. Source step 0294 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 131. Source step 0294 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 132. Source step 0295 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 133. Source step 0296 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 134. Source step 0305 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 135. Source step 0308 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 136. Source step 0353 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 137. Source step 0354 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 138. Source step 0354 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 139. Source step 0354 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 140. Source step 0355 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 141. Source step 0357 "EQ||ECheckList" in module "EQ||ECheckList" was disabled. Reason: 02.04.24 18:39:25 [ct2628]
#    - INPUT "Lnk_No Need-Prior Ins" with "X"
# 142. Source step 0358 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 02.04.24 18:39:25 [ct2628]
#    - WAIT "H4" with "True"
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 143. Source step 0359 "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 02.04.24 18:39:25 [ct2628]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 144. Source step 0360 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 02.04.24 18:39:25 [ct2628]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 145. Source step 0364 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 146. Source step 0364 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 147. Source step 0364 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 148. Source step 0386 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 149. Source step 0386 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 150. Source step 0386 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 151. Source step 0386 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 152. Source step 0394 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 153. Source step 0397 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 154. Source step 0441 field "Lbl_Value_Effective Date" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 155. Source step 0441 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 156. Source step 0441 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 157. Source step 0441 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 158. Source step 0445 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 159. Source step 0446 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 160. Source step 0447 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 161. Source step 0448 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 162. Source step 0449 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 163. Source step 0450 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 164. Source step 0451 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 165. Source step 0452 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 166. Source step 0453 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse RV with Esign - NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
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
