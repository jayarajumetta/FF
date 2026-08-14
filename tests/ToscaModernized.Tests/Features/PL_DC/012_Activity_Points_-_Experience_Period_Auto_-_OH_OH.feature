# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 012_Activity_Points_-_Experience_Period_Auto_-_OH_OH.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @Ohio @Edge @manual @archive @automated
Feature: Execute Activity Points - Experience Period (Auto) - OH for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Experience Period (Auto) - OH workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Experience Period (Auto) - OH using representative iteration Ohio (OH)
    # Source step 0023: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Enter Client & Account Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-3efe-6445-20ab22f00570
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

    # Source step 0024: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 01 Enter Client & Account Information | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0025: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Generating Auto Policy > 01 Enter Client & Account Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-ed53-d1a6-313b7e753d7d
    Then I wait until "Lbl_Account Information" is visible
    Then I wait until "Txt_First Name_Account Owner" is visible
    Then I wait until "Txt_Middle Name_Account Owner" is visible
    Then I wait until "Txt_Last Name_Account Owner" is visible
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I enter or select "9072000876" in "Txt_Best phone_Account Owner"
    When I enter or select "Smoke@test.com" in "Txt_Email_Account Owner"
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

    # Source step 0026: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 01 Enter Client & Account Information | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0027: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-b244-780c-1d900c153760
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[OHIO]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_American National General Insurance Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0028: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-3fae-50d0-3fa16713d47c
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0029: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-75bf-f98a-beeb5ed9d08c
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0030: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-a4a9-6ddb-bd1b417dd228
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"
    When I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0031: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-7cec-4449-6b3a687cede9
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0032: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-7464-8839-6777e26f35e3
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0033: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-f43c-ee5c-4e855170943a
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0034: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-ff59-016e-c76f862ceae1
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "Quote number"

    # Source step 0035: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Prequalification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-a61a-d444-fee9fecca31a
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0036: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-6ae6-2a65-3ea1820a5dfe
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0037: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0038: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-308e-918c-6b4b9060ce91
    # Runtime control: Driver Summary-Gender Conditional > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Condition" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should exist

    # Source step 0039: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-1411-521e-0a16bff0531b
    # Runtime control: Driver Summary-Gender Conditional > Then
    When if the source runtime condition "Driver Summary-Gender Conditional > Then" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0040: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-8daf-e0e7-cb8b727cb505
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Condition" is satisfied, "Btn_Male" should exist

    # Source step 0041: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-b0eb-f9d9-a2447eb52755
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Then
    When if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Then" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "22" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0042: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-bc60-5300-bf22234a656c
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Else
    Then if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Else" is satisfied, "Btn_Male" should exist
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

    # Source step 0043: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-9e10-6936-e2aacb528b8d
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0044: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-303f-b474-3450e81b9eb0
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0045: UW popup | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-c2f3-81b9-93c916efcd41
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0046: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-2978-98a9-3f5164277e6f
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0047: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-70a2-eccc-b56198918df2
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Condition
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Condition" is satisfied, "Hdr_Vehicle Information" should exist

    # Source step 0048: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-f53a-29bb-9ef302a4a8b6
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Then
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Then" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0049: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-ea5b-1876-14de6d6a70df
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0050: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-54c0-5bb1-68511d1e7fc1
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, "Lbl_VIN LABEL" should exist
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then "Btn_Own" should exist
    When I click "Btn_Own"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" exists
    When I enter or select "No" in "Btn_Does this Vehicle"
    When I enter or select "10/10/2000" in "Txt_PurchaseDate"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0051: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0052: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-8998-12d1-43f64dfe53e9
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, "Lbl_VIN LABEL" should exist
    When I enter or select "{CLICK}{Sendkeys[JT8BL69S020010343 ]}" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then "Btn_Own" should exist
    When I click "Btn_Own"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" exists
    When I enter or select "No" in "Btn_Does this Vehicle"
    When I enter or select "10/10/2000" in "Txt_PurchaseDate"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0053: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0054: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-8de1-7f49-363fa608b096
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0055: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-7a53-3871-4b3c7906b933
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0056: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-c62c-86b1-1a2ea44a35e7
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0057: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-6479-4adf-96425986f39c
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Claims" should be visible

    # Source step 0058: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-ff26-8250-7bd03392e956
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD CLAIM"

    # Source step 0059: EQ | Claim Summary | Module: EQ | Claim Summary
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-655b-51ad-3725428f3e07
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Open"
    When I click "Insured At Fault"
    When I click "Collision"
    When I click "Courtney Allison"
    When I enter or select "{Click}{SENDKEYS[$1000]}" in "Claim Amount TextBox"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE[][-3y][MM/dd/yyyy]}]}" in "fields.losses.loss.rows[0].lossInput$dateOfLoss.value"
    When I click "Save and Continue"

    # Source step 0060: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-2868-d4af-04c0239d461a
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0061: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-3a2b-e58a-7ef02dea221c
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0062: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-d64b-af02-81691ce95fe3
    # Runtime control: Discounts-Review Discounts & Continue > Condition
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Condition" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    Then "Btn_D1_No" should be visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0063: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-e7b2-3c90-42a55681457d
    # Runtime control: Discounts-Review Discounts & Continue > Then
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Then" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0064: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-d348-6c15-f37d6973cefe
    # Runtime control: Discounts-Review Discounts & Continue > Else
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Else" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0065: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0066: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0067: Enter Coverages | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-65be-c37f-4e2f05958012
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0068: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 10 Additional Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d46-7a75-91ad-c261390b3d98
    When I click "Btn_ADD_$5,000"
    When I click "Btn_check_box_outline_blankDick Fernandez"
    When I click "Btn_check_box_outline_blankKcmgw Unzp"
    When I click "Btn_Next"

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 10 Additional Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0070: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 11 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-56ad-5f54-f3d3856a938f
    Then I wait until "Hdr_Pricing Details_Header" is visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0071: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-2df1-0d22-84464a5a0683
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0072: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-21c6-c1f7-7100c1689733
    When I click "btn_Next"

    # Source step 0073: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0074: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Generating Auto Policy > 13 Billing | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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
    # Section: Process > Generating Auto Policy > 13 Billing | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0080: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-82c9-dcdd-26a231e1c96e
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0081: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-e3ae-e806-8745cd9b4688
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0082: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-dbb1-85be-2613c3f6a851
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0083: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-aa25-1ded-1359bd884b39
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0084: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-13ad-2c80-56d50b66f6e1
    # Runtime control: Submission-Check for Refer UW Condition > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Condition" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0085: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-96d3-1ec7-a758ffe231f3
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0086: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-66fa-6331-ecb96a420b4a
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0087: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-cc0b-f972-3722fc268b4d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0088: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0092: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-6721-f07f-72a5432965ef
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0093: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-5b32-0ba1-b59814056733
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0094: Search  Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-b9fb-92fa-0fa908953512
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Activity Points-At Fault (Auto)_PA" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0095: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-4823-5642-2f237519a1a9
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0096: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-9453-b539-6feb99bb5a58
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0097: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-7bd2-b59b-56c021ef58a9
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0098: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-e1b3-92e2-87fe8c515ede
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0099: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-a0a3-45f5-a7851f709ff0
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0100: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-cc8d-22cb-1fe8b2975f18
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Activity Points-At Fault (Auto)_PA]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0101: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-88d3-1186-1888f4a02acd
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0102: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-dd3b-129c-ba64318a603b
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0104: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-7961-ac60-d633cd33f3d1
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0106: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-9e6e-0e3b-ed719d521b32
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

    # Source step 0107: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-fa32-0050-f08844dbf6f0
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0108: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-9a99-fb64-3553cc0e6f11
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0109: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-026a-e61e-f8e32450adfb
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0110: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-ca21-2883-4e75088d28d1
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0111: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-61a2-b1dd-fbe2e3d1cc7e
    When I close the active browser

    # Source step 0112: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-01e5-4f0a-8ee5c527c75f
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0113: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0114: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-582b-8b39-4b48b2cefc97
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0115: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-ad66-4456-1630356c5084
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "OH"

    # Source step 0116: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-c250-535b-bd0033bad524
    When I click "Btn_Save and Exit"

    # Source step 0117: OpenUrl | Module: OpenUrl
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0121: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-1e2a-8e82-d84dd734f1bb
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0122: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-ce65-2df4-9175b7393fd3
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0123: Search  Policy Number | Module: EU||Home
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-7ed4-7ab8-de6aeae67d3b
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Quote number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0124: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-ac21-eef8-4a7141c1c510
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0125: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-8bfb-cd54-0bd1769577b8
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0126: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-04a8-647f-a7918a2ce751
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0127: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-9227-0534-5dd0fa1a1e88
    # Runtime control: Evaluating Activity Points is 0 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 0 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='0'"

    # Source step 0128: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-b179-572c-63c8ba7208bc
    # Runtime control: Evaluating Activity Points is 0 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 0 or not > Then" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Expected" as runtime value "Activity Point_PA"

    # Source step 0129: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-1b83-a89b-0f3465b5869c
    # Runtime control: Evaluating Activity Points is 0 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 0 or not > Else" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Fail" as runtime value "Activity Point_PA"

    # Source step 0130: Click on Driver History | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-b734-737c-39ebaf720ca7
    When I click "Btn_Left arror Button"
    When I click "Lnk_Driver History"

    # Source step 0131: Click on Detail  | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-e473-b382-680d71290081
    When I click "Lnk_Detail"

    # Source step 0132: Add over 36 months | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-0961-1659-5e84dc4c4d49
    When I enter a RANDOM value matching "1 random digits/characters" in "DIV_1 > Date Of Loss"
    When I click "Btn_Ok_1"

    # Source step 0133: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-2531-dbb6-c09fb0bf4dc8
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0134: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-af46-8d05-4347b3ff2737
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0135: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-a037-4d2b-298f0173cfdc
    # Runtime control: Evaluating Activity Points is 5 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 5 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='5'"

    # Source step 0136: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d55-470b-9329-5e854bd47363
    # Runtime control: Evaluating Activity Points is 5 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 5 or not > Then" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Expected" as runtime value "Activity Point_PA"

    # Source step 0137: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d65-498b-4edf-d1cb23b8fc80
    # Runtime control: Evaluating Activity Points is 5 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 5 or not > Else" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Fail" as runtime value "Activity Point_PA"

    # Source step 0138: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d65-aafa-6209-7fda10763a14
    When I close the active browser

    # Source step 0139: CloseBrowser | Module: CloseBrowser
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d65-89e9-5cd4-e1f33b43ffa5
    When I close the active browser

    # Source step 0140: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "OH" as runtime value "State"

    # Source step 0150: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0151: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0152:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0153: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0154: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0013 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0014 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0015 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0017 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 5. Source step 0025 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 6. Source step 0025 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 7. Source step 0025 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 8. Source step 0039 field "Txt_Years Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: ""
# 9. Source step 0042 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0042 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 11. Source step 0042 field "Btn_Male" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0042 field "Btn_Single" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0042 field "Txt_Months Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 14. Source step 0042 field "Txt_Date License" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 15. Source step 0050 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 16. Source step 0050 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 17. Source step 0050 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 18. Source step 0050 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 19. Source step 0052 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 20. Source step 0052 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0052 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 22. Source step 0052 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 23. Source step 0075 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 24. Source step 0076 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 25. Source step 0077 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 26. Source step 0078 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 27. Source step 0087 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 28. Source step 0089 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 29. Source step 0090 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 30. Source step 0091 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 31. Source step 0103 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 32. Source step 0104 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 33. Source step 0104 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 34. Source step 0104 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 35. Source step 0105 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 36. Source step 0108 field "H4" in "eChecklist-Verify if 'Application' links in the checklist are completed" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0109 field "H4" in "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0114 field "Lbl_Value_Effective Date" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Effective Date"
# 39. Source step 0114 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0114 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 41. Source step 0114 field "Btn_Transmit" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "X"
# 42. Source step 0118 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 43. Source step 0119 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 44. Source step 0120 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 45. Source step 0126 field "DIV_Risk Score" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "RiskScore"
# 46. Source step 0134 field "DIV_Risk Score" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "RiskScore"
# 47. Source step 0141 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 48. Source step 0142 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 49. Source step 0143 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 50. Source step 0144 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 51. Source step 0145 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 52. Source step 0146 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 53. Source step 0147 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 54. Source step 0148 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 55. Source step 0149 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
