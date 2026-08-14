# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 010_Activity_Points_-_Experience_Period_Auto_-_NY_NY.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @New_York @Edge @manual @archive @automated
Feature: Execute Activity Points - Experience Period (Auto) - NY for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Experience Period (Auto) - NY workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Experience Period (Auto) - NY using representative iteration New York (NY)
    # Source step 0023: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Enter Client & Account Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-120c-ec8a-d9b2f34ab4b6
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
    # Section: Process > Generating Auto Policy > 01 Enter Client & Account Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-3943-2b3c-1a4c5c9526fc
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
    When I enter or select "NEW YORK" in "Drpdwn_State"
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
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-560b-57ce-2bbf58ef71fa
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW YORK]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_United Farm Family Insurance Co."
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I select "Lnk_YES"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0028: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-ed9d-7825-da499da68b16
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0029: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-d88f-29ba-b31af18d3fc6
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0030: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-3abc-4ba8-874cca8f6038
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"
    When I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0031: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-7781-e858-d7386d43d0a2
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0032: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-2f45-6337-9ff74b34bbbb
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0033: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-fd68-fa68-d8238a1b9509
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0034: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 02 Proposal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-6305-0f2f-854734fb5e7c
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "Quote number"

    # Source step 0035: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Prequalification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-1e74-d9e4-fb46341fc6b7
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0036: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-3ecf-53cc-81d6186e227b
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0037: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0038: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-89bf-4eeb-d18addae864f
    # Runtime control: Driver Summary-Gender Conditional > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Condition" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should exist

    # Source step 0039: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-f8fd-c142-cbe0c56796ec
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
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-012b-7259-fc8324c13110
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Condition" is satisfied, "Btn_Male" should exist

    # Source step 0041: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-d97c-0fae-700204632aaa
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
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-8e41-bfd5-958f74f02d28
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
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-87c0-87ca-ea628694416b
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0044: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-530b-4421-d6a3bc52f632
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0045: UW popup | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-c66d-e71e-62fae8a60a7d
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0046: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-4e96-daad-1317e9243609
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0047: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-76c0-7b27-3472007001a7
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Condition
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Condition" is satisfied, "Hdr_Vehicle Information" should exist

    # Source step 0048: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-3c6b-5d60-8a9a4949cbd0
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Then
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Then" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0049: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-e663-1101-9b20df1b4fdb
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0050: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-a244-590b-60b64dcf7d13
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
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-a8c6-8fa9-36bda5356a1a
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
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-9ad0-7210-5a25e82f8534
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0055: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-4535-7e1c-44cef4f0f371
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0056: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-1310-b192-ea6ad92e4a30
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0057: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-1ed4-e166-15e0418ff586
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Claims" should be visible

    # Source step 0058: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-4e5d-267b-9063b7e207f4
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD CLAIM"

    # Source step 0059: EQ | Claim Summary | Module: EQ | Claim Summary
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-ace3-8c79-34654349daa1
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Open"
    When I click "Insured At Fault"
    When I click "Collision"
    When I click "Courtney Allison"
    When I enter or select "{Click}{SENDKEYS[$1000]}" in "Claim Amount TextBox"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE[][-3y][MM/dd/yyyy]}]}" in "fields.losses.loss.rows[0].lossInput$dateOfLoss.value"
    When I click "Save and Continue"

    # Source step 0060: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-23ed-5978-0a93e3ae9911
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0061: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-6d0a-fffd-1dff6458326d
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0062: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-4c08-ef01-cfefe66025b2
    # Runtime control: Discounts-Review Discounts & Continue > Condition
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Condition" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    Then "Btn_D1_No" should be visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0063: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-556d-5e4a-a8fba552f2b1
    # Runtime control: Discounts-Review Discounts & Continue > Then
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Then" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0064: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-e02e-2dd3-2369958b328d
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
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-c884-74ae-3b705b19577e
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0068: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 10 Additional Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-fe62-ee66-79f650814d94
    When I click "Btn_BASIC"
    When I click "Btn_$100"
    When I select "Btn_No"
    When I select "Btn_No Coverage_Additional Death Benefit"
    When I click "Btn_Next"

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 10 Additional Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0070: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 11 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-75a2-bf86-a70b44b44c94
    Then I wait until "Hdr_Pricing Details_Header" is visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0071: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-b131-d084-760fc98d4d3b
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0072: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 12 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-5182-8600-b3cc27619838
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
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-0f6b-0946-df76761886cd
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0081: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d16-6f93-f538-979bc24f7b11
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0082: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-ea54-6cb9-186795b4b503
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0083: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-ed85-d594-7e5dac826240
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0084: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-b1ce-1750-ae9e0804f2e2
    # Runtime control: Submission-Check for Refer UW Condition > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Condition" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0085: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-20f7-3e56-f1af843b8c9c
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0086: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-2564-0dbd-f3dd29988896
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0087: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-bbc3-ca8e-3095d0f15ac1
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0088: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0092: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-2c1f-3a90-a20120f839af
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0093: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-e3ea-dccf-580068e5cb68
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0094: Search  Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-e1a0-a97b-4173657f150c
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Activity Points-At Fault (Auto)_PA" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0095: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-4d06-1dca-d27d92cd0bd1
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0096: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-0767-59c8-109c6cedcba6
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0097: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-e53f-e9fc-6969f38238c2
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0098: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-4aca-e4d6-62d6dddebe0d
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0099: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-59f1-c6f1-f09e196a490f
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0100: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-9a6d-dbaf-9c5d7c9cea48
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[Activity Points-At Fault (Auto)_PA]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0101: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 14 Submission > UW Approval | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-7d22-8000-ed3bdef0c606
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0102: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-f0cc-7409-e89838ec72b6
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0104: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-a6b8-f6b2-ace1552d600b
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
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-e22b-adae-60d860a6203b
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
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-48cd-e21c-095ed40e41fd
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0108: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-0e8f-32f6-ee0cce53e324
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0109: eChecklist-Click the 'drag/drop' link to upload the documents in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-7122-74cd-df52865dbef1
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0110: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-f5d5-dde1-f626094ee995
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0111: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-a409-8079-d9ec7c2e665b
    When I close the active browser

    # Source step 0112: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-6d7d-2bae-c8fba8917dce
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0113: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0114: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-2512-f5b3-1af2ca9c7095
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0115: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-2381-8e34-f54505ecdf3c
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NY"

    # Source step 0116: Push Quote Data & Policy Information to TDS_Regression_Temp_Data | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 17 TDS Validation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-fb22-73e9-f26c11cdb594
    When I click "Btn_Save and Exit"

    # Source step 0117: OpenUrl | Module: OpenUrl
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0121: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-95ac-5c07-c9e1734a2412
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0122: Provide Sign on credentials | Module: EU||Login
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-eb0b-db51-3ea37cc85da7
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0123: Search  Policy Number | Module: EU||Home
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-ba9b-6cde-0d0ac47fccff
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Quote number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0124: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-bddb-75e0-36cf2333b5ae
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0125: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-5765-b9c1-a2dd9488e75e
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0126: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-9d17-a79d-1f289b4d36c3
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0127: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-e629-6529-415edffb009a
    # Runtime control: Evaluating Activity Points is 0 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 0 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='0'"

    # Source step 0128: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-5ca5-8d15-0d571a4cf7f0
    # Runtime control: Evaluating Activity Points is 0 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 0 or not > Then" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Expected" as runtime value "Activity Point_PA"

    # Source step 0129: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > Before 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-67f7-0251-f5776e5f605d
    # Runtime control: Evaluating Activity Points is 0 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 0 or not > Else" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Fail" as runtime value "Activity Point_PA"

    # Source step 0130: Click on Driver History | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-1453-7aaf-f8377703910a
    When I click "Btn_Left arror Button"
    When I click "Lnk_Driver History"

    # Source step 0131: Click on Detail  | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-4e4f-0a13-093b22844511
    When I click "Lnk_Detail"

    # Source step 0132: Add over 36 months | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-3023-faf7-a1abeca31025
    When I enter a RANDOM value matching "1 random digits/characters" in "DIV_1 > Date Of Loss"
    When I click "Btn_Ok_1"

    # Source step 0133: EU||Applicant | Module: EU||Applicant
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-7f4e-741f-5ca17f63196f
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0134: EU||Pricing | Module: EU||Pricing
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-d34a-5ccd-4a8fad92b6d2
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0135: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-2658-2e0d-e13805af8246
    # Runtime control: Evaluating Activity Points is 4 or not > Condition
    Then if the source runtime condition "Evaluating Activity Points is 4 or not > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='4'"

    # Source step 0136: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-63a3-7101-3bc237fb5b13
    # Runtime control: Evaluating Activity Points is 4 or not > Then
    When if the source runtime condition "Evaluating Activity Points is 4 or not > Then" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Expected" as runtime value "Activity Point_PA"

    # Source step 0137: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-6c98-0c3a-a259b7784a65
    # Runtime control: Evaluating Activity Points is 4 or not > Else
    When if the source runtime condition "Evaluating Activity Points is 4 or not > Else" is satisfied, I retain hard-coded value "Activity points for At fault_PA is as Fail" as runtime value "Activity Point_PA"

    # Source step 0138: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-75eb-aedd-785de970a582
    When I close the active browser

    # Source step 0139: CloseBrowser | Module: CloseBrowser
    # Section: Process > UW Non Renewal > After 36 Months Capturing Experience period | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2d25-a01f-de85-0ee6ad28e543
    When I close the active browser

    # Source step 0140: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "NY" as runtime value "State"

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
