# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 043_Endorse_RV_with_Esign_-_OH_OH.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @Ohio @Edge @manual @archive @automated
Feature: Execute Endorse RV with Esign - OH for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse RV with Esign - OH workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse RV with Esign - OH using representative iteration Ohio (OH)
    # Source step 0030: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-bfad-16f3-581457b1a263
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
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-1629-8eea-20e8ba6ebc0e
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
    When I enter or select "OHIO" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" is visible
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0032: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-e1d0-1dec-8aa94b0d5d57
    Then I wait until "Btn_Personal Auto" is visible
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{Sendkeys[OHIO]}{RETURN}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_American National General Insurance Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0033: Verify if popup is visible | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-8b50-d8d7-8444797c7c13
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0034: Click on Proceed button | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-037d-d241-5b152a18bc9c
    # Runtime control: Prposal Start_Proceed  > Click on Proceed button
    When if the source runtime condition "Prposal Start_Proceed > Click on Proceed button" is satisfied, I click "Btn_PROCEED"

    # Source step 0035: Verify if confirm the client SSN# is visible | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-376b-4084-0f3d00b41ecd
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Verify if confirm the client SSN# is visible
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Verify if confirm the client SSN# is visible" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0036: Click on Confirm button | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-a706-6518-59e3841ea2b1
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Click on Confirm button
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Click on Confirm button" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0037: Enter SSN details | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-ffec-41e0-c6655738e08c
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Enter SSN details
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Enter SSN details" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0038: Verify if popup is visible | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-bdd0-5e0d-b1de80ac75cd
    # Runtime control: Proposal Start-UW Popup > Verify if popup is visible
    Then if the source runtime condition "Proposal Start-UW Popup > Verify if popup is visible" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0039: Click Existing Account button | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-2bdc-d274-137e48525795
    # Runtime control: Proposal Start-UW Popup > Click Existing Account button
    When if the source runtime condition "Proposal Start-UW Popup > Click Existing Account button" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0040: Buffer QuoteNumber | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-8b52-1cf3-66289c818470
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0041: Trim QuoteNumber | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-a7a2-43e7-4324ff2e0542
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0042: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-bc4e-f5be-d920b9876ad9
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0043: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-439b-6824-3630cd733b7a
    Then I wait until "Hdr_Driver Information" is visible
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0044: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-458a-567b-bbee14d2ac93
    # Runtime control: Driver Summary-Gender Conditional > Verify - If prior insurance is visible
    Then if the source runtime condition "Driver Summary-Gender Conditional > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should be visible

    # Source step 0045: Enter details in prior insurance page | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-5351-8dbd-41b826b4c7d7
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page
    When if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0046: Verify - If prior insurance is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-a94e-43d0-2a2a649fead2
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page > Driver Summary-Gender Conditional > Verify - If prior insurance is visible
    Then if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page > Driver Summary-Gender Conditional > Verify - If prior insurance is visible" is satisfied, "Btn_Male" should exist

    # Source step 0047: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b65-f631-8f7a-042f6dcbece1
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page > Driver Summary-Gender Conditional > Enter details in prior insurance page
    When if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page > Driver Summary-Gender Conditional > Enter details in prior insurance page" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0048: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b69-9700-6553-9b705162fe50
    # Runtime control: Driver Summary-Gender Conditional > Enter details in prior insurance page > Driver Summary-Gender Conditional > Enter details in prior insurance page
    Then if the source runtime condition "Driver Summary-Gender Conditional > Enter details in prior insurance page > Driver Summary-Gender Conditional > Enter details in prior insurance page" is satisfied, "Btn_Male" should exist
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
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-c2fd-c2eb-1409b91da88d
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0050: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-6cf7-2709-f3917a4bfa2a
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0051: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-c9ad-b28b-4adcb0d575a0
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0052: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-fed7-eb57-54ad0034801b
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0053: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-1cd8-2915-901f9e1261cc
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible" is satisfied, "Hdr_Vehicle Information" should be visible

    # Source step 0054: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-0a94-51aa-c4c0523fc949
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle 
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0055: Verifiy VIN is visible | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-527d-a800-d7031d8605a0
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0056: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-7734-5de6-f553cfbf8fde
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
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-4866-d4d6-e7c992dcc671
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
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-99c5-a7c5-2a971c54dbea
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0059: Verify if pop up appears-Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-04f4-e34a-01f3fdd88a3e
    # Runtime control: Driver Assignment- UW Popup > Verify if pop up appears-Continue
    Then if the source runtime condition "Driver Assignment- UW Popup > Verify if pop up appears-Continue" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0060: CLick Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-dd27-c1fb-2a329b54e431
    # Runtime control: Driver Assignment- UW Popup > CLick Continue
    When if the source runtime condition "Driver Assignment- UW Popup > CLick Continue" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0061: Verify If claim page is visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-8ee4-4a56-cafeb532f187
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Verify If claim page is visible
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Verify If claim page is visible" is satisfied, "Hdr_Claims" should exist

    # Source step 0062: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-0b99-d526-e71a43cd8440
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Click on Next
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Click on Next" is satisfied, I click "Btn_Next"

    # Source step 0063: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-0cc5-54ac-ed4b1b42316e
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0064: Verify if Discount page is visible | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-6eed-c1a5-bf635a6bdfdd
    # Runtime control: Discounts-Review Discounts & Continue > Verify if Discount page is visible
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Verify if Discount page is visible" is satisfied, "Hdr_Discounts / Adjustments" should exist

    # Source step 0065: Select Auto-Home and proceed | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-c580-cb1d-7f4c83ccf517
    # Runtime control: Discounts-Review Discounts & Continue > Click Next 
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Click Next" is satisfied, I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0066: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-3980-b4a0-705ff44415d0
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0067: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-bc7f-9658-e6758caef00f
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0068: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-ca3b-12cd-64e5803e87a4
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0069: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-5318-8bda-7c958ff9d4fa
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-5eca-7209-8a11fb195e7f
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0071: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-d978-5815-9c9f2cb87abd
    When I select "Btn_No Coverage_Accidental Death & Dismemberment"
    When I click "Btn_check_box_outline_blankKcmgw Unzp"
    When I click "Btn_Next"

    # Source step 0072: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-5c62-11dc-a430a24c259f
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-998b-0f9a-08cc5b5cbd20
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0074: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-37d6-4227-39fd246975cf
    Then I wait until "Hdr_Pricing Details Header" is visible
    When I click "Btn_NEXT"

    # Source step 0075: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-f1a7-e7ed-789309a3719b
    When I use source configuration "<unnamed value>" = "True" for "Underwriting-Review & Continue"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0076: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-465c-4229-3ee2c4d1b8b1
    When I click "btn_Next"

    # Source step 0077: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0082: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0083: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0087: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0088: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0089: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0090: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0091: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0093: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0095: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0097: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0099: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0100: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0101: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0102: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0103: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0104: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0105: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0106: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0107: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0109: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-8a94-a55a-a1f8e07c9d98
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0110: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-a4a0-f56c-367e7e3df99b
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0111: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b6a-9085-7062-0be6145a9e7a
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0112: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-54ba-fce0-b09030b8ba11
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0113: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-8d73-baa1-54c7968f9cc5
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0114: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-fdfd-ec5c-9c97f2e4d1f8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0115: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-f92c-0f29-cd379fc88552
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0116: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-5756-a1c3-286eac8c7b9b
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0117: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0121: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0122: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0123: EU||Home | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0124: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0125: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0126: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0127: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0128: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0131: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0132: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-9b51-9e67-b2178f2208dd
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0133: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-148d-f276-6e551c66538f
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0134: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-604a-8804-120f2f8f0539
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0135: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-abad-f711-00ef2c896926
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0136: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-2d4d-5a1d-d4ccafd1d913
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0137: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-bd3d-6b6d-e6b98d05ceab
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

    # Source step 0138: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0139: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-41fe-9a28-20ebcd3dab22
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0140: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-b0a9-53e8-8756d9db2914
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0141: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-15d6-3a9f-a8f7c69c8779
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0142: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-05b0-0afa-9ae32eea2b8f
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0143: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-3c11-53d3-4d55cbd88328
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0144: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-9ffb-ed85-36935ef7f896
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0145: Open Url | Module: Open Url_ARA
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-4b07-5d88-d8cbd0b6e531
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0146: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-2057-a7bb-201465147deb
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0147: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-e352-c982-eaeda0086d61
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0148: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-5d73-a61c-49bb8d80bb6e
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0149: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-f382-eb8d-447aac853875
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0150: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-d9ce-4333-b07f7119d8cf
    When I wait "6000" milliseconds

    # Source step 0151: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-8457-79fc-dc98003dc79d
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0152: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-3673-f18c-4c4a5f475618
    When I click "e-SignLive"

    # Source step 0153: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-23de-b2cb-90473a452625
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0154: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-190f-2131-222a32f71121
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0155: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-4f37-8941-4da8128763de
    When I close the active browser

    # Source step 0156: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-e297-c9e3-80c12eb7fb14
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0157: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-5a67-d975-4c038e800cbb
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0158: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0159: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-1aca-aa52-b78dfc5bd360
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0160: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-6cfe-f738-c459aa308c93
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0161: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-b627-992c-b398d48c5561
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0162:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-9685-a649-9baf496025a8
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0163: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-0fa8-a54b-6629c27e52a0
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0164: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0165: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0166: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-968a-3ba5-670571748bc1
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0167: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-9b60-b49f-ed440973f161
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0168: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-ed7a-ed1b-93bfd0ce6dee
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0169: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-6728-6a74-eaa22e9ac58f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0170: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-2d70-3f52-6fb4b5665d28
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0171: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-edca-388a-00f7c4df11c4
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0172:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-e6b1-4440-59ac6575424e
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0173: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-fc30-ebfe-79738b3474ba
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0174: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0175: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0176: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-22d1-b248-f53ab530cc21
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0177: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0178: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-0898-5f6d-2e5e6e940c3f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0179: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-4bda-d032-6f26b721e98f
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0180: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-5892-cf4f-70e21c965ef9
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0181:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-4794-c6f5-e1c8d8f90964
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0182: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-e6f4-122a-31e1d9c798ed
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0183: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0184: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0185: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-308c-3933-1d4aa9306187
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0186: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-6ab2-038d-8b49e68f1c8c
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0188: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-20de-12e3-adfb058461ae
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0190: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-e35b-ce6a-d21e04b15e8c
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

    # Source step 0191: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-e875-108f-59a0979a6f3a
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0192: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-2971-c233-a3fff675f93d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0193: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-d533-b03e-5e3727f2da45
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0194: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b72-30e5-ee21-fd7f3edfe39b
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0195: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-2b44-9dc6-fb42ebe578bd
    When I close the active browser

    # Source step 0196: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-fab4-67cc-f12fed46c48d
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0197: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-a455-21eb-33d9247df363
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0198: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-60a6-6f0d-29e131f21f2a
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0199: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-c7d3-6352-a239033af3f1
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse RV with Esign - OH"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "OH"

    # Source step 0200: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-caa0-2414-2eb60e0397fd
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse RV with Esign - OH"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "OH"

    # Source step 0201: Click on policy History | Module: EQ | Side Menu
    # Section: Process > Generating Recreation Vehicle > 01 Recall Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-f82d-2e45-0a51adc18a77
    When I click "Policy History"

    # Source step 0202: EQ||Quick Actions | Module: EQ||Quick Actions
    # Section: Process > Generating Recreation Vehicle > 01 Recall Policy | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b78-9b82-507e-09b79d57c488
    When I click "Btn_QUOTE ACTIONS"
    When I click "Btn_New Quote Same Client"

    # Source step 0203: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Recreation Vehicle > 02 Changing Vehicle to RV  | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-56b4-fc01-a5bbbba87092
    When I click "Btn_Recreational Vehicle"
    When I enter or select "{Invoke[Click]}{SENDKEYS[OHIO]}" in "Drp List_Proposal Rating State"
    When I select "Drp_Writing Company"
    When I click "Lbl_American National General Insurance Co."
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0204: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Recreation Vehicle > 03 PreQualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-d464-1cca-bdb41238dffd
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" exists
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0205: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-eef2-8013-1a8e8cb617fd
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0206: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-e311-efe4-f9a56d896527
    When I click "Btn_Primary Named Insured"
    When I click "Btn_Save and Continue"

    # Source step 0207: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Recreation Vehicle > 04 Driver Information Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-c38e-88a4-560d2921dfc0
    When I click "Btn_Next"

    # Source step 0208: Verify vehicles are visible | Module: EQ||Vehicle Information
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-69b4-12e3-63c277490a22
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Verify vehicles are visible" is satisfied, "Hdr_Vehicle Information" should exist

    # Source step 0209: Select any one of Vehicle  | Module: EQ||Vehicle Information
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-069e-269c-de4d5fa4abd5
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle 
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Select any one of Vehicle" is satisfied, I wait until "Hdr_Vehicle Information" is visible
    When I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0210: Verifiy VIN is visible | Module: EQ||Vehicle Summary
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-1a2b-2f74-150c79ee95db
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Verifiy VIN is visible" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0211: Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-1a7d-5268-8f3f7019916b
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

    # Source step 0212: Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Recreation Vehicle > 05 Vehicle Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-a442-9ccc-2869894217df
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

    # Source step 0213: Verify Driver Information is visible | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-9858-2373-e23b48956745
    # Runtime control: Driver Summary-UW Popup > Verify Driver Information is visible
    Then if the source runtime condition "Driver Summary-UW Popup > Verify Driver Information is visible" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0214: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Recreation Vehicle > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-7a88-0fcd-06385357b3ba
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0215: Driver Summary-Enter Driver Summary Details | Module: TBox Set Buffer
    # Section: Process > Generating Recreation Vehicle > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-3fa6-4cb2-f4735353405b
    # Runtime control: Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details
    When if the source runtime condition "Driver Summary-UW Popup > Driver Summary-Enter Driver Summary Details" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0216: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Recreation Vehicle > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-5cb2-2627-8e3a9de95908
    Then I wait until "Hdr_Driver Assignment" is visible
    When I click "Btn_Next"

    # Source step 0217: Verify If claim page is visible | Module: EQ||Claims\Violations
    # Section: Process > Generating Recreation Vehicle > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-7789-a1d2-8817262e988d
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Verify If claim page is visible
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Verify If claim page is visible" is satisfied, "Hdr_Claims" should exist

    # Source step 0218: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Recreation Vehicle > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-f94f-0e98-40f0d83ffb9d
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Click on Next
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Click on Next" is satisfied, I click "Btn_Next"

    # Source step 0219: Click on Next | Module: EQ||Claims\Violations
    # Section: Process > Generating Recreation Vehicle > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-874c-ad01-3e8877a3dfa7
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0220: Verify if Discount page is visible | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Recreation Vehicle > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-2c9d-b42f-3b55f4a9262d
    # Runtime control: Discounts-Review Discounts & Continue > Verify if Discount page is visible
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Verify if Discount page is visible" is satisfied, "Hdr_Discounts / Adjustments" should exist

    # Source step 0221: Select Auto-Home and proceed | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Recreation Vehicle > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-5011-42f1-75c2d10da3fa
    # Runtime control: Discounts-Review Discounts & Continue > Click Next 
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Click Next" is satisfied, I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0222: Verify if coverage is visible | Module: <unresolved module>
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-910b-2b61-a7cc71a9175b
    # Runtime control: Load till coverage is visible [max=30] > Verify if coverage is visible
    Then if the source runtime condition "Load till coverage is visible [max=30] > Verify if coverage is visible" is satisfied, "<unnamed value>" should be visible

    # Source step 0223: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-c291-b0b9-ea09985c638e
    # Runtime control: Load till coverage is visible [max=30] > Wait 
    When if the source runtime condition "Load till coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0224: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-1292-2369-e9972c1d452e
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0225: Verify if Additional Coverage is visible | Module: EQ||Additional Coverages
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-8cc2-31bd-357772aab506
    # Runtime control: Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible
    Then if the source runtime condition "Load till Additional Coverage is visible [max=30] > Verify if Additional Coverage is visible" is satisfied, "Hdr_Additional Coverages" should be visible

    # Source step 0226: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-daa2-83dc-ecc11472684a
    # Runtime control: Load till Additional Coverage is visible [max=30] > Wait
    When if the source runtime condition "Load till Additional Coverage is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0227: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process > Generating Recreation Vehicle > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-f3ba-8f5b-b2dd29c7df7c
    When I click "Btn_Next"

    # Source step 0228: Verify if  pricing Details is visible | Module: EQ||Pricing Details
    # Section: Process > Generating Recreation Vehicle > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-dd39-ef2f-83e2e2670abf
    # Runtime control: Load till pricing Details is visible [max=30] > Verify if  pricing Details is visible
    Then if the source runtime condition "Load till pricing Details is visible [max=30] > Verify if pricing Details is visible" is satisfied, "Hdr_Pricing Details_Header" should be visible

    # Source step 0229: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-2af7-23de-20fe9dea3218
    # Runtime control: Load till pricing Details is visible [max=30] > Wait
    When if the source runtime condition "Load till pricing Details is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0230: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > Generating Recreation Vehicle > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-c4ed-d837-651606ca834e
    Then I wait until "Hdr_Pricing Details Header" is visible
    When I click "Btn_NEXT"

    # Source step 0231: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Recreation Vehicle > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-d3f7-66e4-7a0f1fa9a18f
    When I use source configuration "<unnamed value>" = "True" for "Underwriting-Review & Continue"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0232: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Recreation Vehicle > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-5c79-cb5c-a0d18f32aa9d
    When I click "btn_Next"

    # Source step 0233: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0238: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0239: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0243: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0244: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0245: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0246: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0247: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0248: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0249: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0250: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0251: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0252: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0253: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0254: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0255: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0256: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0257: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0258: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0259: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0260: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0261: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0262: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0263: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0264: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0265: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-4403-a820-bb6213a5212d
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0266: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-f404-919b-41d1c4c7f4ad
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0267: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-9b4a-3393-7210ac5f1b13
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0268: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-234f-c36c-efb11e470517
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0269: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-8cc0-9732-21f0d681efa3
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0270: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-766d-d3cf-1021d4d9ebd2
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0271: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-359f-2a7a-c70ac697f248
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0272: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-1e83-b73b-a7beccac2f88
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0273: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0277: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0278: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0279: EU||Home | Module: EU||Home
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0280: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0281: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0282: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0283: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0284: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0287: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0288: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-5750-4791-6f8492a6c2a9
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0289: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-7a6f-cf81-4f7eeeec94e6
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0290: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Generating Recreation Vehicle > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-6562-c789-2090dc9dca25
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0291: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-3fe3-a737-bbcd6fae0708
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0292: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-7871-66a2-a93c5d0bf80f
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0293: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-d3bb-9497-ce4052dff7c7
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

    # Source step 0294: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0295: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-3731-7266-d7b5145dae81
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0296: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-c3fe-85b7-2c43920501c1
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0297: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-fc04-c40b-6203414bb4ae
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0298: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-09c5-6095-3cb68a85243e
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0299: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-ac26-d937-bd0476a9c766
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0300: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-d363-a4df-87fe71035b97
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0301: Open Url | Module: Open Url_ARA
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-b7b6-e108-ff657a60b8ac
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0302: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-98f7-d208-84b43677add1
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0303: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-190e-801a-d80522a1c689
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0304: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-9592-b123-f199bfc83221
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0305: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-3cbf-dbc2-b9b2c3fb6fea
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0306: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-1acf-a0cc-bf55b9ef6a3f
    When I wait "6000" milliseconds

    # Source step 0307: Refresh | Module: TBox Send Keys
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-257e-6cad-af418937fc5a
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0308: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-2a4a-f984-22a9adf21c7e
    When I click "e-SignLive"

    # Source step 0309: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-818d-1e69-7dfda81b1abe
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0310: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-9201-d85e-62aeae25fe9a
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0311: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-9331-6188-6e873c1620c9
    When I close the active browser

    # Source step 0312: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-f63a-7a28-1606ccc0fbf4
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0313: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-6ca2-2fb2-f0c4f674fdae
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0314: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0315: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-bc39-ee60-db8b6f5af8dd
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0316: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-227c-1f4e-56f2822ef5a9
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0317: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-55a6-82da-fad518a7ea7d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0318:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-c839-624b-460bef860c90
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0319: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-cfac-e881-ee5de85782a4
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0320: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0321: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0322: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-4bce-fdf5-378437a4528d
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0323: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-4ea6-ac05-85651715a19c
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0324: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-8ba1-f4ea-06880f04df5a
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0325: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-17c9-2e92-95d26cd01af5
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0326: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-18bf-3ea6-df018551e456
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0327: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-5234-eaa2-7724156ccc47
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0328:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-b9d6-61ff-4ef1965b4dcc
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0329: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-2538-d216-3b91d55fcb93
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0330: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0331: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0332: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-2e59-6879-af702d7263c5
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0333: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0334: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-f4dd-e8e2-2e30774e84ce
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0335: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-9aa2-e07e-892e4aa8fdd7
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0336: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-1bf2-a47d-86c0aae416de
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0337:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-d899-6f53-25d101a35616
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0338: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-f712-47c2-7426e4bcfb20
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0339: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0340: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0341: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b79-77e8-ed8a-42b52c774a08
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0342: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-9056-80aa-6123a1c5247f
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0344: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-c20c-13a6-1288ad53b9a2
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0346: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-7a79-6c87-2bc923c5d0f0
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

    # Source step 0351: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-6ff7-1c7b-e00eeb025e75
    When I close the active browser

    # Source step 0352: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-639c-f8c7-7320f39e0a90
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0353: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-4d1a-f8ce-df8808180218
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0354: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Recreation Vehicle > 16 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-05d7-86cd-f47ea3f19e80
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0355: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Recreation Vehicle > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-8bf1-c22b-2bc6300366b8
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse RV with Esign - OH"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "OH"

    # Source step 0356: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Recreation Vehicle > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-89a1-5018-bd53f3ff5ef2
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse RV with Esign - OH"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "OH"

    # Source step 0357: Click save and exit | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-8ce5-2be2-989ad0496d6b
    When I click "Btn_Save and Exit"

    # Source step 0358: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0359: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-cdda-35cd-6ba98f47455b
    When I close the active browser

    # Source step 0360: OpenUrl | Module: OpenUrl_old
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-8942-2c8d-f3eb2360ce4e
    When I open "https://expertquote-qa.americannational.com/expertquote/#/quote"

    # Source step 0361: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-283a-9af9-8a884d268f96
    # Runtime control: Wait for Login Page [max=30] > Condition
    Then if the source runtime condition "Wait for Login Page [max=30] > Condition" is satisfied, "Txt_Username" should exist

    # Source step 0362: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Login Page [max=30] > Loop
    When if the source runtime condition "Wait for Login Page [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0363: Maximize Window | Module: TBox Window Operation
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-9a63-313c-d04b690d27b6
    When I enter or select "*Sign On*" in "Caption"
    When I enter or select "Maximize" in "Operation"

    # Source step 0364: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > Close and open browser to recall quote | Reusable flow: Common | 00 Navigate and Login to EQ | Source XTestStep: 3a19dd55-d407-6f7c-e4d8-6c2bb24c7913
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0365: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-7207-bbff-c28e5ba57d31
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0366: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-d95e-1bc5-ba21c4268661
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0367: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-369d-c908-08552689a04e
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0368: If Recall quote/policy is visible | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-0409-80d4-d8fb52d442aa
    # Runtime control: Recall quote/policy is visible > Verify if Recall quote/policy is visible
    Then if the source runtime condition "Recall quote/policy is visible > Verify if Recall quote/policy is visible" is satisfied, "Txt_Quote\\Policy Search" should be visible

    # Source step 0369: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-4710-6afe-5cf6bab15ff6
    # Runtime control: Recall quote/policy is visible > Recall Quote\Policy
    When if the source runtime condition "Recall quote/policy is visible > Recall Quote\\Policy" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0370: Verifiy if integration page appears | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-e3bc-ed1f-8c5997211333
    # Runtime control: Handling integration backend error  [max=30] > Verifiy if integration page appears
    Then if the source runtime condition "Handling integration backend error [max=30] > Verifiy if integration page appears" is satisfied, "Close Quote" should be visible

    # Source step 0371: Close Quote | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-31e1-3ebc-f993fb678d69
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I click "Close Quote"

    # Source step 0372: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-f435-ada3-1b9f0e46fc37
    # Runtime control: Handling integration backend error  [max=30] > Loop
    When if the source runtime condition "Handling integration backend error [max=30] > Loop" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Policy Number]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0373: Quick Actions | Module: EQ||New Quote
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-b484-6b56-6f4b25b07d1e
    When I click "Btn_+ CREATE NEW POLICY CHANGE"
    When I enter or select "{CLICK}{SENDKEYS[Endorse Coverage Limit]}" in "Txt_Policy Change Field"
    When I click "Btn_OK"

    # Source step 0374: Click on Coverage | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-6246-8703-f3d8be9ea191
    When I click "Coverages"

    # Source step 0375: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0376: Lower BI/PD Coverage | Module: <unresolved module>
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-48bb-de54-bcaa8770c806
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0377: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Endorse coverage to Lower | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-49a7-c92f-39330127bc1d
    When I click "Submission"

    # Source step 0378: Verify if Launch Esign is visible | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-4388-7e82-8297ef9f3181
    # Runtime control: Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible
    Then if the source runtime condition "Load till Launch Esign is visible [max=30] > Verify if Launch Esign is visible" is satisfied, "Btn_Launch To eSignature" should be visible

    # Source step 0379: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-aea5-cd52-9ff36184a3b8
    # Runtime control: Load till Launch Esign is visible [max=30] > Wait 
    When if the source runtime condition "Load till Launch Esign is visible [max=30] > Wait" is satisfied, I wait "10000" milliseconds

    # Source step 0380: Launch To eSignature | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-fc46-7fe9-bfb7bea3d18a
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0381: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-08de-c71b-372d89cf8bb7
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0382: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-fa9c-02a2-126224c8618d
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

    # Source step 0383: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0384: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-8448-d68b-0da24fc53f1e
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0385: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-9e89-86b0-c74c7e69b472
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0386: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-31ee-1946-93ff4a8b9934
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0387: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-8e90-c4ef-b1d469c5dcb4
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" is visible
    When I click "Btn_Confirm Signers"

    # Source step 0388: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-cd9d-3947-e3794bfeab05
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0389: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-1889-9e6c-b78414f5ca16
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0390: Open Url | Module: Open Url_ARA
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-87c4-bd55-52a580e6842f
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0391: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-426c-0044-c8fa3afc35bb
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0392: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-310b-e59c-319f51eaefc5
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0393: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-4fa9-0d70-89a8524aecca
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0394: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-d9c7-6491-7e8d5794c3da
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0395: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-c56b-2142-61cfeb7cf1fc
    When I wait "6000" milliseconds

    # Source step 0396: Refresh | Module: TBox Send Keys
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-dd17-d292-c13a4fa89c10
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0397: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-0fbe-4ec1-0b8df38f8127
    When I click "e-SignLive"

    # Source step 0398: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-c93f-602e-5020dd093170
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0399: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-e9af-5d11-f2a93e7490c7
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0400: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-8ee4-82a9-3111985361b4
    When I close the active browser

    # Source step 0401: Signing documents for Esign | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-10b1-ab1b-7a6731f4bef5
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "Review Documents" is visible

    # Source step 0402: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-239f-8132-f77ff5343078
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0403: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0404: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-774d-4e1d-52cd1490ceee
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0405: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-d942-d980-059e31d2d1a9
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0406: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-140e-3b4c-a331d63ff9c6
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0407:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-dc55-b14c-6aecdec98759
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0408: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-a6cd-c2c3-dcf6ed3b8a8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0409: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0410: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0411: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-def6-233e-afa6bb2dbd21
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0412: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-cc86-5cb4-ddc021eb3b93
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0413: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-a312-a785-8ea34008d327
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0414: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-6085-50ee-9dd05f4b9e4d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0415: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-ba5c-579f-c5273fb38b75
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0416:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-db32-a990-193e5506be22
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0417: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-2113-e2ae-afcd5f121df3
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0418: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0419: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0420: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-b3fc-4478-6940ca4222f0
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0421: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0422: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-e05a-a451-732b5e71b256
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0423: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-2cea-908b-d5d6910a2a09
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0424: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b8a-cc44-c4c3-3098368d9426
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0425:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b99-4f55-81d5-c8f2d0163404
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0426: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b99-0a0c-9c98-c44760695941
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0427: TBox Wait | Module: TBox Wait
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0428: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0429: CloseBrowser | Module: CloseBrowser
    # Section: Process > Endorse coverage to Lower > 14 Launch Esignature | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b99-a7c7-eb91-561d8004007e
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0430: Click on Transmit Button | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b99-0754-1e21-c4525a06fe75
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0431: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Endorse coverage to Lower > 15 Transmit | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b99-300b-03d1-ee294b721c64
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    Then "Lbl_Policy Number" should equal "Policy Number: {XB[Policy Number]}"

    # Source step 0432: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b9a-1061-845d-617f27f30c14
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Endorse Auto with Esign - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0433: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Endorse coverage to Lower > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2b9a-b8a4-32ba-c819962f7307
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Endorse Auto with Esign - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0434: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "OH" as runtime value "State"

    # Source step 0444: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0445: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0446:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0447: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0448: CloseBrowser | Module: CloseBrowser
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
# 20. Source step 0078 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 21. Source step 0079 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 22. Source step 0080 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 23. Source step 0081 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 24. Source step 0084 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 25. Source step 0085 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 26. Source step 0086 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 27. Source step 0116 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 28. Source step 0118 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 29. Source step 0119 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 30. Source step 0120 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 31. Source step 0122 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0122 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 33. Source step 0126 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0126 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 35. Source step 0126 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0126 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 37. Source step 0127 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0127 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 39. Source step 0127 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0127 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 41. Source step 0128 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0128 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 43. Source step 0128 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0128 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0129 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 46. Source step 0130 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 47. Source step 0139 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 48. Source step 0142 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 49. Source step 0187 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 50. Source step 0188 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 51. Source step 0188 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 52. Source step 0188 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 53. Source step 0189 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 54. Source step 0192 field "H4" in "eChecklist-Verify if 'Application' links in the checklist are completed" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0193 field "H4" in "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0198 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0198 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 58. Source step 0198 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 59. Source step 0203 field "Lbl_Proposal Details" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0203 field "Btn_Personal Auto" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "X"
# 61. Source step 0203 field "Txt_Effective Date" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "1 random digits/characters"
# 62. Source step 0203 field "Hdr_proposal.ratingState-panel" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "New Mexico"
# 63. Source step 0203 field "Txt_Agent PCCode" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 64. Source step 0203 field "Txt_Agent PCCode" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "D2102"
# 65. Source step 0203 field "Rd Btn_Same as NewAccountAddress" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0205 field "Btn_(Existing Client)*" in "Driver Information-Enter Driver Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 67. Source step 0211 field "Btn_SelectVehicle_Option1" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0211 field "Btn_Automobile" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0211 field "Btn_ATV" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 70. Source step 0211 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 71. Source step 0211 field "Lbl_Does this vehicle have any customized equipment?" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0211 field "Btn_Does this Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "No"
# 73. Source step 0211 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 74. Source step 0211 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 75. Source step 0211 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0211 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "04/21/2000"
# 77. Source step 0211 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 78. Source step 0211 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0211 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 80. Source step 0211 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "120000"
# 81. Source step 0211 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 82. Source step 0211 field "Btn_Add Additional Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0212 field "Btn_SelectVehicle_Option1" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0212 field "Btn_Automobile" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 85. Source step 0212 field "Btn_ATV" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 86. Source step 0212 field "Btn_Non-Factory Additions, Alterations, or Modifications_No" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 87. Source step 0212 field "Lbl_Does this vehicle have any customized equipment?" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 88. Source step 0212 field "Btn_Does this Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "No"
# 89. Source step 0212 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 90. Source step 0212 field "Btn_Pleasure/Work Use" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 91. Source step 0212 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0212 field "Txt_PurchaseDate" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "04/21/2000"
# 93. Source step 0212 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 94. Source step 0212 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 95. Source step 0212 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 96. Source step 0212 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "120000"
# 97. Source step 0212 field "Txt_Odometer" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 98. Source step 0212 field "Btn_Add Additional Vehicle" in "Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 99. Source step 0216 field "Btn_Vehicle_Select" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 100. Source step 0216 field "Lbl_Principal or Occasional driver of this vehicle?" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 101. Source step 0216 field "Btn_Principal_New" in "Driver Assignment-Select Driver Assignment & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 102. Source step 0234 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 103. Source step 0235 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 104. Source step 0236 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 105. Source step 0237 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 106. Source step 0240 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 107. Source step 0241 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 108. Source step 0242 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 109. Source step 0272 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 110. Source step 0274 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 111. Source step 0275 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 112. Source step 0276 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 113. Source step 0278 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0278 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 115. Source step 0282 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 116. Source step 0282 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 117. Source step 0282 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 118. Source step 0282 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 119. Source step 0283 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 120. Source step 0283 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 121. Source step 0283 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 122. Source step 0283 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 123. Source step 0284 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 124. Source step 0284 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 125. Source step 0284 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 126. Source step 0284 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 127. Source step 0285 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 128. Source step 0286 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 129. Source step 0295 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 130. Source step 0298 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 131. Source step 0343 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 132. Source step 0344 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 133. Source step 0344 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 134. Source step 0344 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 135. Source step 0345 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 136. Source step 0347 "EQ||ECheckList" in module "EQ||ECheckList" was disabled. Reason: 01.06.24 21:27:15 [ct2628]
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
# 137. Source step 0348 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 01.06.24 21:27:15 [ct2628]
#    - WAIT "H4" with "True"
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 138. Source step 0349 "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 01.06.24 21:27:15 [ct2628]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 139. Source step 0350 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 01.06.24 21:27:15 [ct2628]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 140. Source step 0354 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 141. Source step 0354 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 142. Source step 0354 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 143. Source step 0376 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 144. Source step 0376 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 145. Source step 0376 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 146. Source step 0376 field "<unnamed value>" in "Lower BI/PD Coverage" was disabled. Reason:  
#    - Preserved source value: "X"
# 147. Source step 0384 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 148. Source step 0387 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 149. Source step 0431 field "Lbl_Value_Effective Date" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 150. Source step 0431 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 151. Source step 0431 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 152. Source step 0431 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 153. Source step 0435 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 154. Source step 0436 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 155. Source step 0437 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 156. Source step 0438 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 157. Source step 0439 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 158. Source step 0440 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 159. Source step 0441 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 160. Source step 0442 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 161. Source step 0443 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Auto\\Endorse RV with Esign - OH_{DATE[][][MM/dd/yyyy]}_{TIME}"
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
