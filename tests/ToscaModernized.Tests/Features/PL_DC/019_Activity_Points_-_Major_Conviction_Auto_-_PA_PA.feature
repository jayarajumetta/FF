# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 019_Activity_Points_-_Major_Conviction_Auto_-_PA_PA.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @Pennsylvania @Edge @manual @archive @automated
Feature: Execute Activity Points - Major Conviction (Auto) - PA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Major Conviction (Auto) - PA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Major Conviction (Auto) - PA using representative iteration Pennsylvania (PA)
    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-5b26-b8b7-48cc13a5761e
    # Runtime control: Enter Sign On Credentials > Condition
    Given if the source runtime condition "Enter Sign On Credentials > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0012: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-f716-a86f-47b6f11d57a2
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

    # Source step 0013: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-5333-ae00-6eba15fab53f
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-2c8c-219e-b56b16879a00
    # Runtime control: Enter Sign On Credentials > Else
    Then if the source runtime condition "Enter Sign On Credentials > Else" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0015: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-cd1c-72ee-9edcf7371a14
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

    # Source step 0016: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0017: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-556d-1ca6-7f55bd34fc14
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
    When I enter or select "PENNSYLVANIA" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" is visible
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0018: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0019: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0020: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-b2d1-631a-2df4f6fb12d8
    Then I wait until "Lbl_Proposal Details" is visible
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[PENNSYLVANIA]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0021: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-324a-42f0-3c854a46057e
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0022: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-835a-cfd6-1a48f085de6e
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0023: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-69ad-2640-24730e24ee71
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"
    When I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0024: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-b71d-5a68-629185eb58c5
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0025: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Generating Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-0a91-bb00-0a375ed22b70
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0026: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-40e4-e471-342485910a56
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0027: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-56f0-d60b-8cac937769ad
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0028: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process > Generating Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-5897-726f-12a42641f7ef
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0029: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-2b99-4651-2ca4318e6fe6
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0030: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0031: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-6b58-ee4f-e6b48deb0199
    # Runtime control: Driver Summary-Gender Conditional > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Condition" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should exist

    # Source step 0032: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-29f1-f599-74e9f97e3037
    # Runtime control: Driver Summary-Gender Conditional > Then
    When if the source runtime condition "Driver Summary-Gender Conditional > Then" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0033: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-1b72-4413-29e383ae4da8
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Condition" is satisfied, "Btn_Male" should exist

    # Source step 0034: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-de5e-9fad-c620812c997c
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

    # Source step 0035: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-aca9-6b05-7fbd12351dc2
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

    # Source step 0036: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-0a76-8f04-1f124c187736
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0037: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-d078-661d-3a574bd66327
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0038: UW popup | Module: TBox Set Buffer
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-c4b0-1796-7a4a893623ee
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0039: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process > Generating Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-01d1-1ad6-a12b9d013c24
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0040: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-287b-6513-dec5f0142fc8
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Condition
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Condition" is satisfied, "Hdr_Vehicle Information" should exist

    # Source step 0041: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-5eba-7a50-d38422e52026
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Then
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Then" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0042: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-1689-cc14-76f2a5be71e9
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0043: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-0c86-f683-a03bd5da4607
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

    # Source step 0044: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0045: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-1f9a-4cb9-f63aeeccd0b0
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

    # Source step 0046: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 05 Vehicle Summary | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0047: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-af8f-856a-3963b5af57c4
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0048: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-71b3-9f92-b9669b726b7f
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0049: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process > Generating Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-55dc-d0fd-919de9268f4f
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0050: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-3d17-ac76-44c08ee270df
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Edit Violation" should be visible

    # Source step 0051: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-f8a4-9e89-7abd024fa242
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD VIOLATION"

    # Source step 0052: ExpertQuote|Violations | Module: EQ|Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-f080-f856-5e35b9b329ec
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I enter or select "10/10/2022" in "Violation/Susp Dat"
    Then "Driver Involved" should be visible
    When I click "Courtney Allison"
    When I enter or select "{invoke[Click]}{sendkeys[BC - Blood Alcohol Content]}" in "DIV_1"
    When I enter or select "10/10/2022" in "Conviction Date"
    When I click "Applies"
    When I click "Save and Continue"

    # Source step 0053: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-e320-ebe2-bba868d33812
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0054: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Generating Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-cdbd-6fda-beeb01ce9fb1
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0055: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-a455-35aa-8d51b1f7db76
    # Runtime control: Discounts-Review Discounts & Continue > Condition
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Condition" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    Then "Btn_D1_No" should be visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0056: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-69c9-73bc-b98b517e8f6a
    # Runtime control: Discounts-Review Discounts & Continue > Then
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Then" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0057: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-45ee-244f-1db50ba0a92c
    # Runtime control: Discounts-Review Discounts & Continue > Else
    Then if the source runtime condition "Discounts-Review Discounts & Continue > Else" is satisfied, I wait until "Hdr_Discounts / Adjustments" exists
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0058: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 08 Discounts | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0063: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-a87b-6449-72cc59835599
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0064: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-0601-f6c0-de4d81aae192
    Then I wait until "Btn_Full" exists
    When I click "Btn_Full"
    When I select "Btn_No Coverage_2"
    When I select "Btn_No Coverage_Accidental Death & Dismemberment"
    When I select "Btn_No Coverage_Extraordinary Medical Benefit"
    When I click "Btn_Next"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 09 Coverages | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0066: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process > Generating Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2df4-e4f8-97d1-9789a366b3f8
    Then I wait until "Hdr_Pricing Details_Header" is visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0067: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-5f81-976d-93173ac9abd7
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0068: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-dcc4-0fe9-e0d014988694
    When I click "btn_Next"

    # Source step 0069: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Generating Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0070: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0075: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0076: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0077: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0081: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0082: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0083: Search Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0084: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0085: Click on Pricing | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0086: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0087: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0089: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0090: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0091: Click on Home button | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0093: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0094: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0095: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0096: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0097: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0098: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0099: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0100: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0101: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0102: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0103: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-d684-e04b-0555f3c76ac3
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0104: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-16dc-84b6-dddf90068a69
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0105: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-9a91-13bd-f8cb3ed6dbcd
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0106: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-8ab4-d454-2716bd85d26d
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0107: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-4e4d-e610-20d96905b43e
    # Runtime control: Submission-Check for Refer UW Condition > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Condition" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0108: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-7e25-59bc-8d2b4398a8df
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"

    # Source step 0109: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-4945-64bb-8e26436fe5a1
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0110: EQ||Submission | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-3cd4-1757-49923ec4ed82
    # Runtime control: Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0111: OpenUrl | Module: OpenUrl
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0115: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-60cc-a25b-bbd177de6b5d
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0116: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-7384-1291-e267d3300562
    # Runtime control: Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then > If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0117: Search  Policy Number | Module: EU||Home
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-47ae-ecdd-591c714889d6
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0118: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-1278-d82d-d36210ec5a55
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0119: EU||Applicant | Module: EU||Applicant
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-3fa0-88ae-3bb05a685ca0
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0120: EU||Pricing | Module: EU||Pricing
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-0d5f-5fed-b5a484083c89
    # Runtime control: Submission-Check for Refer UW Condition > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"
    When I click "Btn_Approve"

    # Source step 0121: Close the RCT Express Page | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-2762-f9db-39b969b9a42c
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I close the active browser

    # Source step 0122: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-ebb8-adde-0e3187cede6d
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0123: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-838e-76c6-192f3bb433a7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[ActivityPoints-NoFault(Cycle)_OH]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0124: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Generating Auto Policy > 13 Submission > UW Non Renewal | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-d2f6-9b37-4398b214e7f7
    # Runtime control: Submission-Check for Refer UW Condition > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Then" is satisfied, I click "Submission"

    # Source step 0125: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-9302-55ee-105fffa3f3c3
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0127: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-f9af-a7d7-db2e8a0cf97f
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0129: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-ce48-0719-ad6e53f729bc
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

    # Source step 0130: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-e49a-2ae0-7825d71c7230
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0131: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-92bd-88fa-43a6e017c2e2
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0132: TBox Save As | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-b0fa-cf00-72195aac5fdc
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0133: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-b7a0-21f4-18b45db64f9f
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0134: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Generating Auto Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e04-65b8-95f6-b004c05d2350
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0136: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0137: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-c7eb-0be6-3932399a0fc3
    When I close the active browser

    # Source step 0138: TBox Wait | Module: TBox Wait
    # Section: Process > Generating Auto Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0139: Click Transmit | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-7522-50f2-b545f49d3f10
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0140: Transmit Confirmation-Get Policy Number, Premium details | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-a9cf-cdde-3ad902e1767a
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0141: Save & Exit | Module: EQ||Submission
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-14e2-8ddc-a31aa4f9fc87
    When I click "Btn_Save and Exit"

    # Source step 0142: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-4dd3-e790-1df969393282
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Activity Points - Major Conviction (Auto) - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0143: Push Quote Data & Policy Information to TDS Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-6e3e-6a62-1e162058263f
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Activity Points - Major Conviction (Auto) - PA"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0144: CloseBrowser | Module: CloseBrowser
    # Section: Process > Generating Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e0c-fcd9-7bfe-94bb9d7b3cf1
    When I close the active browser

    # Source step 0213: OpenUrl | Module: OpenUrl
    # Section: Process > Activity Points MAjor | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0217: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-788a-f35d-6078bfbf4d06
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0218: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-660c-22ff-a1e87a57e10d
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0219: Search  Policy Number | Module: EU||Home
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-93f9-1f65-19f6c0dac639
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0220: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-46b9-78ed-6a769d33f782
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0221: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-6eff-0753-e8f4d3048a19
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0222: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-4c61-6a58-7dec04940a74
    # Runtime control: If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0223: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-c910-c912-42d3f2d20255
    # Runtime control: If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0224: EU||Applicant | Module: EU||Applicant
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-ba5b-1d3d-4861ee791091
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0225: EU||Pricing | Module: EU||Pricing
    # Section: Process > Activity Points MAjor | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-1932-3141-0855ab8ccae1
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"
    When I click "Btn_Close"

    # Source step 0235: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "PA" as runtime value "State"

    # Source step 0245: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0246: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0247:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0248: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2e1c-2648-013f-ba7422638a6b
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
# 5. Source step 0017 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 6. Source step 0017 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 7. Source step 0017 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 8. Source step 0032 field "Txt_Years Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: ""
# 9. Source step 0035 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0035 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 11. Source step 0035 field "Btn_Male" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0035 field "Btn_Single" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0035 field "Txt_Months Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 14. Source step 0035 field "Txt_Date License" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 15. Source step 0043 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 16. Source step 0043 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 17. Source step 0043 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 18. Source step 0043 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 19. Source step 0045 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 20. Source step 0045 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0045 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 22. Source step 0045 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 23. Source step 0050 field "Hdr_Claims" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "True"
# 24. Source step 0051 field "Btn_+ ADD CLAIM" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0059 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 30.01.24 22:30:45 [ct2628]
#    - WAIT "Btn_Next" with "True"
#    - VERIFY "Btn_Next" with "True"
# 26. Source step 0060 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 30.01.24 22:30:45 [ct2628]
#    - WAIT "Btn_Next" with "True"
#    - WAIT "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "{Invoke[Click]}"
# 27. Source step 0061 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 13.11.23 12:19:54 [ct2453]
#    - VERIFY "Hdr_Discounts / Adjustments" with "True"
#    - WAIT "Btn_Next" with "True"
#    - VERIFY "Btn_Next" with "True"
# 28. Source step 0062 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 13.11.23 12:19:54 [ct2453]
#    - INPUT "Btn_Next" with "{Invoke[Click]}"
# 29. Source step 0064 field "Btn_UMPD No Coverage" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0064 field "Btn_No Coverage_UMPD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0064 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 32. Source step 0064 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 33. Source step 0064 field "Btn_No Coverage_1" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0064 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0064 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 36. Source step 0064 field "Btn_No Coverage_Vehicle3" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 37. Source step 0064 field "Btn_UMPD_No Coverage_V3" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 38. Source step 0064 field "Btn_UMPD_No Coverage_V4" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0071 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 40. Source step 0072 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 41. Source step 0073 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 42. Source step 0074 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 43. Source step 0078 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 44. Source step 0079 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 45. Source step 0080 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 46. Source step 0110 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 47. Source step 0112 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 48. Source step 0113 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 49. Source step 0114 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 50. Source step 0126 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 51. Source step 0127 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 52. Source step 0127 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 53. Source step 0127 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 54. Source step 0128 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 55. Source step 0130 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 56. Source step 0135 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 57. Source step 0145 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - VERIFY "Lbl_Password" with "Password"
# 58. Source step 0146 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
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
# 59. Source step 0147 "Start New Quote in EQ" in module "EQ||New Quote" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Btn_New Quote" with "True"
#    - VERIFY "Btn_New Quote" with "New Quote"
#    - INPUT "Btn_New Quote" with "X"
# 60. Source step 0148 "Start New Quote in EQ" in module "EQ||New Quote" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Btn_New Quote" with "True"
#    - VERIFY "Btn_New Quote" with "New Quote"
#    - INPUT "Btn_New Quote" with "X"
# 61. Source step 0149 "Enter Client Selection" in module "EQ || Client Selection" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "Lbl_Client Info" with "True"
#    - VERIFY "Lbl_Client Info" with "Client Info"
#    - VERIFY "Lbl_New/Existing Client Search" with "True"
#    - VERIFY "Lbl_New/Existing Client Search" with "New/Existing Client Search"
#    - INPUT "Txt_First" with "{Invoke[Click]}{SENDKEYS[David]}"
#    - INPUT "Txt_Last" with "Dee"
#    - INPUT "Txt_Date of birth" with a blank value
#    - INPUT "Txt_Best phone" with a blank value
#    - INPUT "Txt_Email address" with a blank value
#    - VERIFY "Btn_Search" with "True"
#    - INPUT "Btn_Search" with "X"
#    - VERIFY "Btn_Create New Client" with "Create New Client"
#    - INPUT "Btn_Create New Client" with "X"
#    - VERIFY "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 62. Source step 0150 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with "6/19/1948"
#    - INPUT "Txt_Best phone_Account Owner" with "9072009167"
#    - INPUT "Txt_Email_Account Owner" with "DAVIDDEE1125@MAIL.COM"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Married" with "X"
#    - INPUT "Txt_Enter a location" with "SLOAN ST"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with "SCRANTON"
#    - INPUT "Drpdwn_State" with "PENNSYLVANIA"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with "185040000"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 63. Source step 0151 "EQ||Proposal Start" in module "(Old) EQ||Proposal Start" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "Lbl_Proposal Details" with "True"
#    - INPUT "Btn_Personal Auto" with "X"
#    - INPUT "Btn_Recreational Vehicle" with "X"
#    - INPUT "Txt_Effective Date" with the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE[][][MM/dd/yyyy]}]}"
#    - CONTAINER "Drp List_Proposal Rating State" with "X"
#    - CONTAINER "Drp List_Proposal Rating State > State List" with "X"
#    - CONTAINER "Hdr_proposal.ratingState-panel" with "New Mexico"
#    - INPUT "Txt_Agent PCCode" with "D2102"
#    - WAIT "Drp List_List Auto Writing Company" with "True"
#    - INPUT "Hdr_Writing Company" with "{Invoke[Click]}{SENDKEYS[American National General Insurance Co.]}"
#    - WAIT "Lbl_Select Risk Address" with "True"
#    - INPUT "Rd Btn_Same as NewAccountAddress" with "{Invoke[Click]}"
#    - INPUT "Drp List_State" with "{Invoke[Click]}{SENDKEYS[PENNSYLVANIA]}"
#    - INPUT "Btn_Start Quote" with "X"
#    - INPUT "Btn_PROCEED" with "X"
# 64. Source step 0152 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "15000"
# 65. Source step 0153 "EQ||Proposal Start" in module "(Old) EQ||Proposal Start" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "Btn_PROCEED" with "True"
# 66. Source step 0154 "EQ||Proposal Start" in module "(Old) EQ||Proposal Start" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_PROCEED" with "X"
# 67. Source step 0155 "ExpertQuote" in module "Confirm the Client's SSN# Popup-Edit/Confirm" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "DIV_Confirm the Client's SSN#" with "True"
# 68. Source step 0156 "ExpertQuote" in module "Confirm the Client's SSN# Popup-Edit/Confirm" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Lnk_CONFIRM" with "X"
# 69. Source step 0157 "EQ||Proposal Start Proceed & SSN" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Txt_SSN" with the RUNTIME-DERIVED TDM value "PA_ClientData_Regression.SSN"
#    - INPUT "Lnk_SUBMIT" with "X"
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 70. Source step 0158 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Lnk_USE EXISTING ACCOUNT" with "True"
#    - VERIFY "Lnk_USE EXISTING ACCOUNT" with "True"
# 71. Source step 0159 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 72. Source step 0160 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 73. Source step 0161 "EQ||Tabs" in module "EQ||Tabs" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - BUFFER "Lbl_Quote" with "QuoteNumber"
#    - BUFFER "Lbl_QNum" with "QuoteNumber2"
# 74. Source step 0162 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "QuoteNumber3" with the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}"
#    - INPUT "QuoteNumber4" with the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}"
#    - INPUT "UW Non-Renewal - Auto_PA" with the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}"
# 75. Source step 0163 "Enter PreQualification" in module "EQ||PreQualification" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_Chk box_check_boxNone Of The Above" with "X"
#    - INPUT "Btn_Next" with "X"
# 76. Source step 0164 "Enter Driver Information" in module "EQ||Driver Information" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_(Existing Client)" with "X"
#    - INPUT "Btn_Next" with "X"
# 77. Source step 0165 "Driver Summary-Enter Driver Summary Details" in module "EQ||Driver Summary" was disabled. Reason: 04.03.24 11:58:05 [ct2634]
#    - VERIFY "Btn_Male" with "*toggle-checked*"
#    - VERIFY "Btn_Male" with "True"
# 78. Source step 0166 "Driver Summary-Enter Driver Summary Details" in module "EQ||Driver Summary" was disabled. Reason: 04.03.24 11:58:05 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - INPUT "Btn_Assigned" with "x"
#    - INPUT "Txt_DL Number" with "887299001"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "6"
#    - INPUT "Txt_Years Licensed in Current State" with ""
#    - INPUT "Txt_Months Licensed in Current State" with "1"
#    - INPUT "Txt_Date License" with "1/1/2015"
#    - INPUT "Btn_PriorInsurance_No" with "X"
#    - INPUT "Btn_No Need- Did Not Own a Vehicle" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
# 79. Source step 0167 "Driver Summary-Enter Driver Summary Details" in module "EQ||Driver Summary" was disabled. Reason: 04.03.24 11:58:05 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - INPUT "Btn_Assigned" with "x"
#    - INPUT "Txt_DL Number" with "57344361"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "8"
#    - INPUT "Txt_Years Licensed in Current State" with ""
#    - INPUT "Txt_Months Licensed in Current State" with "1"
#    - INPUT "Txt_Date License" with "1/1/2015"
#    - INPUT "Btn_FinancialResponsibility_No" with "X"
#    - INPUT "Btn_PriorInsurance_No" with "X"
#    - INPUT "Btn_No Need- Did Not Own a Vehicle" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
# 80. Source step 0168 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "Btn_PriorInsurance_Yes" with "True"
# 81. Source step 0169 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "{Click}{Sendkeys[19]}"
#    - INPUT "Txt_Years Licensed in Current State" with ""
#    - INPUT "Txt_Months Licensed in Current State" with "1"
#    - INPUT "Txt_Date License" with "1/1/2015"
#    - INPUT "Btn_FinancialResponsibility_No" with "X"
#    - INPUT "Btn_PriorInsurance_No" with "X"
#    - WAIT "Btn_priorCarrierName" with "True"
#    - INPUT "Btn_priorCarrierName" with "\"^{a}\""
#    - INPUT "Btn_priorCarrierName" with "{Invoke[Click]}{SENDKEYS[Geico]}"
#    - WAIT "Btn_priorPolicyNumber" with "True"
#    - INPUT "Btn_priorPolicyNumber" with "\"^{a}\""
#    - INPUT "Btn_priorPolicyNumber" with "{Invoke[Click]}{SENDKEYS[5127398001]}"
#    - WAIT "Btn_yearsWithPriorCarrier" with "True"
#    - INPUT "Btn_yearsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_yearsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[2]}"
#    - WAIT "Btn_monthsWithPriorCarrier" with "True"
#    - INPUT "Btn_monthsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_monthsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[0]}"
#    - INPUT "Btn_Was this client insured with AN_No" with "X"
#    - INPUT "Btn_Did Not Have Insurance" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 82. Source step 0170 "EQ||Driver Summary" in module "EQ||Driver Summary" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Lbl_Gender" with "True"
#    - VERIFY "Lbl_Gender" with "Gender"
#    - WAIT "Btn_Male" with "True"
#    - VERIFY "Btn_Male" with "True"
#    - INPUT "Btn_Male" with "X"
#    - INPUT "Btn_Single" with "X"
#    - INPUT "Btn_Primary Named Insured" with "X"
#    - WAIT "Txt_Years Licensed in Current State" with "True"
#    - INPUT "Txt_Years Licensed in Current State" with "{Invoke[Click]}"
#    - INPUT "Txt_Years Licensed in Current State" with "{Click}{Sendkeys[19]}"
#    - INPUT "Txt_Years Licensed in Current State" with ""
#    - INPUT "Txt_Months Licensed in Current State" with "1"
#    - INPUT "Txt_Date License" with "1/1/2015"
#    - INPUT "Btn_FinancialResponsibility_No" with "X"
#    - INPUT "Btn_PriorInsurance_Yes" with "X"
#    - INPUT "Btn_PriorInsurance_No" with "X"
#    - WAIT "Btn_priorCarrierName" with "True"
#    - INPUT "Btn_priorCarrierName" with "\"^{a}\""
#    - INPUT "Btn_priorCarrierName" with "{Invoke[Click]}{SENDKEYS[Geico]}"
#    - WAIT "Btn_priorPolicyNumber" with "True"
#    - INPUT "Btn_priorPolicyNumber" with "\"^{a}\""
#    - INPUT "Btn_priorPolicyNumber" with "{Invoke[Click]}{SENDKEYS[5127398001]}"
#    - WAIT "Btn_yearsWithPriorCarrier" with "True"
#    - INPUT "Btn_yearsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_yearsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[2]}"
#    - WAIT "Btn_monthsWithPriorCarrier" with "True"
#    - INPUT "Btn_monthsWithPriorCarrier" with "\"^{a}\""
#    - INPUT "Btn_monthsWithPriorCarrier" with "{Invoke[Click]}{SENDKEYS[0]}"
#    - INPUT "Btn_Did Not Have Insurance" with "X"
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Lnk_UWR_CONTINUE" with "X"
# 83. Source step 0171 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "40000"
# 84. Source step 0172 "EQ||Driver Information Next" in module "EQ||Driver Information Next" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_Add Additional Driver" with "X"
#    - INPUT "Btn_Next" with "X"
# 85. Source step 0173 "EQ||Vehicle Information" in module "EQ||Vehicle Information" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "btn_select vehicle1" with "True"
#    - VERIFY "btn_select vehicle1" with "True"
#    - WAIT "Btn_Vehicle" with "True"
#    - VERIFY "Btn_Vehicle" with "True"
# 86. Source step 0174 "EQ||Vehicle Information" in module "EQ||Vehicle Information" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "btn_select vehicle1" with "X"
#    - INPUT "Btn_Vehicle" with "X"
#    - INPUT "Btn_Next" with "X"
# 87. Source step 0175 "Vehicle Summary_New_Rescan" in module "EQ||Vehicle Summary" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Txt_VIN number" with "True"
#    - INPUT "Txt_VIN number" with "\"^{a}\""
#    - INPUT "Txt_VIN number" with "{Invoke[Click]}"
#    - INPUT "Txt_VIN number" with "WBSNB93527CX07002"
#    - INPUT "Txt_VIN number" with ""
#    - WAIT "Lbl_Please select the vehicle" with "True"
#    - INPUT "Btn_SelectVehicle_1" with "X"
#    - INPUT "Btn_SelectVehicle_Option1" with "X"
#    - INPUT "Btn_Automobile" with "X"
#    - INPUT "Btn_Trailbike" with "{Invoke[Click]}"
#    - WAIT "Btn_Own" with "True"
#    - INPUT "Btn_Own" with "X"
#    - INPUT "Btn_Is this vehicle used for racing?_No" with "X"
#    - INPUT "Btn_Cycle_Customizatioin_No" with "X"
#    - INPUT "Btn_Non-Factory Additions, Alterations, or Modifications_No" with a blank value
#    - INPUT "Btn_Is this vehicle licensed for road use?_No" with "X"
#    - WAIT "Lbl_Does this vehicle have any customized equipment?" with "True"
#    - INPUT "Btn_Does this Vehicle" with "No"
#    - WAIT "Btn_Pleasure/Work Use" with "True"
#    - INPUT "Btn_Pleasure/Work Use" with "{Click}"
#    - WAIT "Txt_PurchaseDate" with "True"
#    - INPUT "Txt_PurchaseDate" with "07/10/2003"
#    - INPUT "Txt_Odometer" with "\"^{a}\""
#    - WAIT "Txt_Odometer" with "True"
#    - INPUT "Txt_Odometer" with "{Click}"
#    - INPUT "Txt_Odometer" with "120000"
#    - INPUT "Txt_Odometer" with a blank value
#    - INPUT "Btn_Save and Continue" with "X"
#    - INPUT "Btn_Next" with "X"
#    - INPUT "Btn_Add Additional Vehicle" with "X"
# 88. Source step 0176 "Enter Driver Assignment" in module "EQ||Driver Assignment" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_VehSelect" with "X"
#    - INPUT "Btn_1988 Ford E350" with "{Invoke[Click]}"
#    - INPUT "Btn_Principal_2" with "{Invoke[Click]}"
#    - INPUT "Btn_1988 Ford E351" with "{Invoke[Click]}"
#    - WAIT "Btn_Principal_4" with "True"
#    - INPUT "Btn_Principal_4" with "X"
#    - WAIT "Btn_Occasional_3" with "True"
#    - INPUT "Btn_Occasional_3" with "X"
#    - INPUT "Btn_Vehicle_Select" with "X"
#    - WAIT "Lbl_Principal or Occasional driver of this vehicle?" with "True"
#    - INPUT "Btn_Principal" with "{Click}"
#    - INPUT "Btn_Principal_New" with "X"
#    - INPUT "Btn_Occasional" with "X"
#    - INPUT "Btn_Next" with "X"
#    - INPUT "Lnk_CONTINUE_1" with "x"
# 89. Source step 0177 "Driver Assignment-Select Driver Assignment & Continue" in module "EQ||Driver Assignment" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Lnk_CONTINUE" with "True"
#    - VERIFY "Lnk_CONTINUE" with "True"
# 90. Source step 0178 "Driver Assignment-Select Driver Assignment & Continue" in module "EQ||Driver Assignment" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Lnk_CONTINUE" with "X"
# 91. Source step 0179 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "10000"
# 92. Source step 0180 "EQ||Claims\\Violations" in module "EQ||Claims\\Violations" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Lnk_UW_CONTINUE" with "True"
#    - VERIFY "Lnk_UW_CONTINUE" with "True"
# 93. Source step 0181 "EQ||Claims\\Violations" in module "EQ||Claims\\Violations" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Lnk_UW_CONTINUE" with "X"
#    - INPUT "Btn_Next" with "X"
# 94. Source step 0182 "EQ||Claims\\Violations" in module "EQ||Claims\\Violations" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_Next" with "X"
# 95. Source step 0183 "EQ||Discounts_New" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_D1_No" with "X"
#    - INPUT "Btn_Not Residential Property Owner" with "X"
#    - INPUT "Btn_No Proof of Prior Insurance" with "X"
#    - INPUT "Hdr_Discounts page" with "{Click}"
#    - INPUT "Btn_Next" with "X"
# 96. Source step 0184 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "15000"
# 97. Source step 0185 "Enter Coverages" in module "<unresolved module>" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "<unnamed value>" with "{Click}"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
# 98. Source step 0186 "Additional Coverages_New" in module "EQ||Additional Coverages" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_No Coverage_Income Loss" with "X"
#    - INPUT "Btn_No Coverage_Accidental Death & Dismemberment" with "X"
#    - INPUT "Btn_UMPD_No Coverage_V1" with "X"
#    - INPUT "Btn_UMPD No Coverage" with "X"
#    - INPUT "Btn_Full" with "X"
#    - INPUT "Btn_No Coverage_UMPD" with "X"
#    - INPUT "Btn_$40 per day/$800 per occurrence" with "X"
#    - INPUT "Btn_No Coverage_Extraordinary Medical Benefit" with "X"
#    - INPUT "Btn_check_box_outline_blankDjfak Wopntz" with "{Click}"
#    - INPUT "Btn_check_box_outline_blankKcmgw Unzp" with "{Invoke[Click]}"
#    - INPUT "Btn_No Coverage_2" with "X"
#    - WAIT "Lbl_Uninsured Motorist PD" with "True"
#    - INPUT "Btn_UMPD Limits" with "No Coverage_1"
#    - INPUT "Btn_Next" with "X"
# 99. Source step 0187 "Enter Pricing Details" in module "EQ||Pricing Details" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "X"
# 100. Source step 0188 "Enter Underwriting" in module "<unresolved module>" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
# 101. Source step 0189 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "3000"
# 102. Source step 0190 "Enter Additional Interest Summary" in module "EQ||Additional Interest Summary" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "btn_Next" with "X"
#    - INPUT "Btn_Next" with "X"
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
# 103. Source step 0191 "EQ||Billing_New" in module "EQ||Billing" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_New Account" with "X"
#    - INPUT "Img_Primary Payer_MAT LABEL" with "{CLICK}"
#    - INPUT "Img_Primary Payer_MAT LABEL" with "{CLICK}"
#    - WAIT "Lbl_Primary Payer" with "True"
#    - INPUT "Lbl_Primary Payer Driver" with "{Invoke[Click]}"
#    - INPUT "Lbl_Primary Payer Driver" with "{Click}"
#    - INPUT "Btn_AccountHolder" with "X"
#    - INPUT "Btn_Primary Insured" with "Djfak Wopntz"
#    - INPUT "Btn_Primary Insured1" with "{Down}"
#    - INPUT "Btn_Direct Bill" with "{Invoke[Click]}"
#    - INPUT "Btn_1 Payment" with "{Invoke[Click]}"
#    - INPUT "Txt_PaymentDueDate" with "{Invoke[Click]}{SENDKEYS[18]}"
#    - INPUT "Txt_InitialPaymentAmount" with "110"
#    - INPUT "DIV_Future PaymentPlan" with "{Click}"
#    - INPUT "Btn_Check" with "X"
#    - INPUT "Txt_InitialPaymentCheckNumber" with "{Invoke[Click]}{SendKeys[4088761300]}"
#    - INPUT "Btn_Next" with "X"
# 104. Source step 0192 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "10000"
# 105. Source step 0193 "EQ||Check Principal/Occasional Box" in module "EQ||Check Principal/Occasional Box" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - VERIFY "DIV_Principal/Occasional" with "True"
# 106. Source step 0194 "EQ||Submission" in module "EQ||Submission" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - BUFFER "Lbl_QuoteTab_Name and Quote number" with "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
#    - WAIT "Txt_AgentComments" with "True"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - WAIT "Txt_Agent Comments" with "True"
#    - INPUT "Txt_Agent Comments" with "Nedd UW Approval"
#    - INPUT "Btn_Refer to UW" with "{Invoke[Click]}"
#    - INPUT "Btn_Launch To Checklist" with "{Invoke[Click]}"
#    - INPUT "Btn_Transmit" with "X"
# 107. Source step 0195 "EQ||Submission" in module "EQ||Submission" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - BUFFER "Lbl_QuoteTab_Name and Quote number" with "TC02_Mega Auto Policy 02_QuoteTab_Name and Quote number"
#    - WAIT "Txt_AgentComments" with "True"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - INPUT "Txt_AgentComments" with "Need UW Approval"
#    - WAIT "Txt_Agent Comments" with "True"
#    - INPUT "Txt_Agent Comments" with "Nedd UW Approval"
#    - INPUT "Btn_Refer to UW" with "{Invoke[Click]}"
#    - INPUT "Btn_Launch To Checklist" with "{Invoke[Click]}"
#    - INPUT "Btn_Transmit" with "X"
# 108. Source step 0196 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 109. Source step 0197 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
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
# 110. Source step 0198 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 111. Source step 0199 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
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
# 112. Source step 0200 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - BUFFER "DIV_Agent Documents Count" with "AgentList count"
#    - VERIFY "DIV_Agent Documents Count" with the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 113. Source step 0201 "EQ||ECheckList" in module "EQ||ECheckList" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 114. Source step 0202 "TBox Save As" in module "TBox Save As" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png"
#    - INPUT "Button" with "Open"
# 115. Source step 0203 "EQ||ECheckList_1" in module "EQ||ECheckList" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 116. Source step 0204 "TBox Save As_1" in module "TBox Save As" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg"
#    - INPUT "Button" with "Open"
# 117. Source step 0205 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 118. Source step 0206 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "30000"
# 119. Source step 0207 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Title" with "American*"
# 120. Source step 0208 "EQ||Submission_1" in module "EQ||Submission" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - WAIT "Btn_Ok" with "True"
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 121. Source step 0209 "TBox Wait" in module "TBox Wait" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Duration" with "30000"
# 122. Source step 0210 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 123. Source step 0211 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with "Auto - TC08_Mega Rec Veh Policy 01_NM"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "NM"
# 124. Source step 0212 "Submission_2-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 30.04.24 12:28:29 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 125. Source step 0214 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 126. Source step 0215 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 127. Source step 0216 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 128. Source step 0221 field "Btn_Yes" in "EU||Transact" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 129. Source step 0225 field "DIV_Risk Score" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "RiskScore"
# 130. Source step 0225 field "Hdr_DC-SECTION" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 131. Source step 0226 "Close the RCT Express Page" in module "CloseBrowser" was disabled. Reason: 15.04.24 17:55:20 [ct2634]
#    - INPUT "Title" with "Pricing*"
# 132. Source step 0227 "TBox Evaluation Tool" in module "TBox Evaluation Tool" was disabled. Reason: 15.04.24 17:55:20 [ct2634]
#    - VERIFY "Expression" with the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='5'"
# 133. Source step 0228 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 15.04.24 17:55:20 [ct2634]
#    - INPUT "Activity Point_PA" with "Activity points for At fault_PA is as Expected"
# 134. Source step 0229 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 15.04.24 17:55:20 [ct2634]
#    - INPUT "Activity Point_PA" with "Activity points for At fault_PA is as Fail"
# 135. Source step 0230 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:42 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 136. Source step 0231 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 26.06.24 16:56:57 [ct2634]
#    - INPUT "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with captured runtime value "TCName"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "PA"
# 137. Source step 0232 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 26.06.24 16:56:57 [ct2634]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "PA"
# 138. Source step 0233 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:46 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 139. Source step 0234 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 140. Source step 0236 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 141. Source step 0237 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 142. Source step 0238 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 143. Source step 0239 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 144. Source step 0240 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 145. Source step 0241 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 146. Source step 0242 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 147. Source step 0243 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 148. Source step 0244 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
