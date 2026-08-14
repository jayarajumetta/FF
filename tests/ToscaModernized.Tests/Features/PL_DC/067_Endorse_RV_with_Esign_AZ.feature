# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 067_Endorse_RV_with_Esign_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @Arizona @Edge @manual @archive @automated
Feature: Execute Endorse RV with Esign for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse RV with Esign workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse RV with Esign using representative iteration Arizona (AZ) — selected from TestCase-Design; no concrete instantiated TestCase was exported
    # Source step 0010: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-6b62-d320-8b9018b73754
    # Runtime control: Enter Sign On Credentials > Condition
    Given if the source runtime condition "Enter Sign On Credentials > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-13d6-0304-01b311845ed1
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-67f1-982a-cfe3ca5715aa
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-60b5-bbae-1e8ae5d6bed0
    # Runtime control: Enter Sign On Credentials > Else
    Then if the source runtime condition "Enter Sign On Credentials > Else" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-3f9f-6886-5288051f6ed5
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

    # Source step 0015: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0016: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-f88a-ca96-eae6154e36c1
    Then "Lbl_Account Information" should exist
    Then "Txt_First Name_Account Owner" should exist
    Then "Txt_Middle Name_Account Owner" should exist
    Then "Txt_Last Name_Account Owner" should exist
    When I enter captured runtime value "DOB" in "Txt_DOB"
    When I enter or select "9072000876" in "Txt_Best phone_Account Owner"
    When I enter or select "Smoke@test.com" in "Txt_Email_Account Owner"
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

    # Source step 0017: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0018: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-b9e4-41c0-4df9e9641cae
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I use source configuration "Drp List_Proposal Rating State > State List" = "X" for "Proposal Start-Enter Proposal details to Start Quote"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" exists
    When I enter or select "{Invoke[Click]}{SENDKEYS[ARIZONA]}" in "Drp List_State"
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0019: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-2417-18fa-4f790ab7a29f
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0020: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-689a-b1e3-5b781924212c
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0021: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-ea6d-b905-04bfe8dba198
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"
    When I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0025: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-9039-7e45-2bfa4fe99b01
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" exists
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0026: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bff-5c6d-d4a0-8bd760991250
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0027: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0028: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-617e-1709-f17fef9653f3
    # Runtime control: Driver Summary-Gender Conditional > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Condition" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should exist

    # Source step 0029: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-9c39-07b0-82f68fc8ea9d
    # Runtime control: Driver Summary-Gender Conditional > Then
    When if the source runtime condition "Driver Summary-Gender Conditional > Then" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "\"^{a}\"" in "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I select "Btn_PriorInsurance_No"
    When I select "Btn_No Need- Did Not Own a Vehicle"
    When I click "Btn_Save and Continue"

    # Source step 0030: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-2407-e806-234ba4c324d2
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Condition" is satisfied, "Btn_Male" should exist

    # Source step 0031: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-727a-fd4d-0a2ea33843b7
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

    # Source step 0032: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-0fd5-fbfd-0d428f102cbc
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

    # Source step 0033: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-5242-d105-868420e7a150
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0034: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-34f2-3871-0708247bc5c5
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0035: UW popup | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-c2ac-4d74-feb71f36d0ce
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0036: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-9bc1-0866-107bb8edeb56
    When I click "Btn_Next"

    # Source step 0037: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-31ff-4a79-dd4606f58ccb
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Condition
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Condition" is satisfied, "Hdr_Vehicle Information" should exist

    # Source step 0038: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-7daa-f0de-069928af8306
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Then
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0039: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c0e-62f2-7f0e-6896af3644e9
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0040: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-da85-0723-e1344c0f1b89
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, "Lbl_VIN LABEL" should exist
    Then I wait until "Txt_VIN number" is enabled
    When I click "Txt_VIN number"
    When I enter or select "\"^{a}\"" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    When I click "Btn_Automobile"
    Then "Btn_Own" should exist
    When I click "Btn_Own"
    When I click "Btn_Leased"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" exists
    When I enter or select "No" in "Btn_Does this Vehicle"
    When I enter or select "10/10/2000" in "Txt_PurchaseDate"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0041: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0042: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-781b-61e1-b59ff7bd2aba
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, "Lbl_VIN LABEL" should exist
    When I enter or select "{CLICK}{Sendkeys[JT8BL69S020010343 ]}" in "Txt_VIN number"
    When I press "Enter" while focused on "Txt_VIN number"
    Then I wait until "Lbl_Please select the vehicle" exists
    When I click "Btn_SelectVehicle_1"
    Then "Btn_Own" should exist
    When I click "Btn_Own"
    When I click "Btn_Leased"
    Then I wait until "Lbl_Does this vehicle have any customized equipment?" exists
    When I enter or select "No" in "Btn_Does this Vehicle"
    When I enter or select "10/10/2000" in "Txt_PurchaseDate"
    When I click "Btn_Save and Continue"
    When I click "Btn_Next"

    # Source step 0043: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0044: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-0c4d-040f-cb254dae1fb1
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0045: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-ee18-eb73-aaa142449d14
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0046: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-fc2f-5d85-8dd1d1069709
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0047: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-57b3-5974-57ee3c3df02b
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Condition
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Condition" is satisfied, "Hdr_Claims" should exist

    # Source step 0048: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-e5f5-06c8-72ecf852210e
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then" is satisfied, I click "Btn_Next"

    # Source step 0049: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0050: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-4f82-abba-c8f6ac62a28c
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then > If > Condition
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then > If > Condition" is satisfied, I perform the source-defined operation "Claims\\Violations-Review Claims & Violations and Continue" in module "EQ||Claims\\Violations"

    # Source step 0051: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-4f30-52d4-3a9c3cbee72f
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then > If > Then
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then > If > Then" is satisfied, I perform the source-defined operation "Claims\\Violations-Review Claims & Violations and Continue" in module "EQ||Claims\\Violations"

    # Source step 0052: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-a23a-feb4-c94d3b84768c
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0053: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-edb9-7b72-5f725b8fdc48
    Then I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    Then I wait until "Btn_Next" exists
    When I click "Btn_Next"

    # Source step 0054: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0055: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-f215-76e1-4d5fc993eb84
    # Runtime control: Discounts_Page_Submit > Condition
    Then if the source runtime condition "Discounts_Page_Submit > Condition" is satisfied, I wait until "Btn_Next" exists
    Then "Btn_Next" should exist

    # Source step 0056: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-0861-e716-bb600778b262
    # Runtime control: Discounts_Page_Submit > Then
    Then if the source runtime condition "Discounts_Page_Submit > Then" is satisfied, I wait until "Btn_Next" exists
    Then I wait until "Btn_Next" exists
    When I click "Btn_Next"

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0060: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-9e13-d1c7-0a6f10fa7dbd
    Then I wait until "<unnamed value>" exists
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0061: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-cf14-fbef-63ee8a1ed316
    When I select "Btn_No Coverage_Accidental Death & Dismemberment"
    When I click "Btn_check_box_outline_blankKcmgw Unzp"
    When I select "Btn_UMPD_No Coverage_V1"
    Then I wait until "Lbl_Uninsured Motorist PD" is enabled
    When I click "Btn_Next"

    # Source step 0062: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c10-937b-6799-29f68b434633
    Then I wait until "Hdr_Pricing Details_Header" is visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0063: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-2653-2276-e17af9506a8c
    When I click "<unnamed value>"

    # Source step 0064: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-6fc1-dc2f-1002228e5899
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0065: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0066: Billing-Enter Billing Details & Continue | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-6a58-f7d1-227d3e9f868c
    When I click "Btn_New Account"
    When I click "Btn_AccountHolder"
    Then I wait until "Btn_Direct Bill" is visible
    When I click "Btn_Direct Bill"
    When I click "Btn_1 Payment"
    When I enter or select "25" in "Txt_PaymentDueDate"
    When I click "Btn_Check"
    When I enter or select "2468135709" in "Txt_InitialPaymentCheckNumber"
    When I click "Btn_Next"

    # Source step 0067: EQ||Submission | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-f84d-dc46-b35b7a0bc1bf
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0068: EQ||Submission | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-d37f-ea80-db117ea1b7cd
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "Review Completed" in "Txt_AgentComments"

    # Source step 0069: Launch To eSignature | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-07fb-98ed-4cc10d0f2d6a
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0070: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-8fdd-eabc-684cd1dc70db
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0071: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-1677-8d4f-21f0d7d32e79
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

    # Source step 0072: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0073: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-d476-7a16-95fa696528ad
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0074: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-7412-b907-b32544a21e24
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0075: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0076: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-e73a-c106-cefb62a5f755
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0077: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0078: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-1d18-2ce0-920b08e2b5ba
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0079: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-02d6-2d22-e6b10fa06dde
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0080: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0081: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-e1c5-31bc-862fdd2d44a3
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0083: Open Url | Module: Open Url_ARA
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-987b-ab32-017056ee9d0a
    When I enter or select "https://mail.anico.com/owa/#path=/mail" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0084: TBox Wait | Module: TBox Wait
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-b8c9-cfd9-9198ad85cb47
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0085: Refresh | Module: TBox Send Keys
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-1da9-550d-5894af990da7
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0086: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-14e8-7724-fac9594a8a3e
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0087: Refresh | Module: TBox Send Keys
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-ab46-0f26-1be8ae4f18f8
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-f0f2-dd63-b63c04510812
    When I wait "6000" milliseconds

    # Source step 0089: Refresh | Module: TBox Send Keys
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-7a3c-8b84-3c4232c42de5
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0090: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-063d-3cc6-fa7864592674
    When I click "e-SignLive"

    # Source step 0091: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-ffc9-09e2-891243b53f66
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0092: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-af34-1ac0-03c0af837aca
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0093: CloseBrowser | Module: CloseBrowser
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-48a3-23fe-59222f11bae6
    When I close the active browser

    # Source step 0094: Signing documents for Esign | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-1b50-9155-098a97abccfe
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "<unnamed value>" is visible

    # Source step 0095: Click on Review Document | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-a916-bb54-f2f51fc74151
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "<unnamed value>"

    # Source step 0096: Reviewing Documents for Esign | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c19-8426-4a4f-2f0358ea4393
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "<unnamed value> > <unnamed value>" is visible
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0097: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0098: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1e-c472-0e8f-b3ec5f85940e
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0099: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1e-c0e7-ed1a-4e9b9c28532e
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0100: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1e-1f63-9be8-9520a86e3841
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0101: Signing documents for Esign | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-f9fd-b71a-1e4e6849c68a
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0102: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0103: Click on Review Document | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-1808-5388-0ba4e3fdea2e
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "<unnamed value>"

    # Source step 0104: Reviewing Documents for Esign | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-0e80-1518-64c65dc885c4
    # Runtime control: Signing & Reviewing documents for Esign > Else
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait until "<unnamed value> > <unnamed value>" is visible
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0105: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-8033-8de0-83c5aaaef40b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0106: Launch To Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-0163-bf95-d2614db3def6
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0108: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-12b6-578d-1bfebbeef384
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0110: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-7e85-d777-bae6dd9401cf
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

    # Source step 0111: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-72e9-8446-b04c0c79357b
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0112: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Upload Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-7ab8-460b-24bdab27f0d3
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0113: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Upload Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-a452-d568-96187acc196d
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0114: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0115: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-9b8b-198d-c468eeda82f5
    When I close the active browser

    # Source step 0116: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-14cd-6451-192c247c7d1e
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0117: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0118: Click on Transmit Button | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-6c59-32b7-cef40fa9e80f
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0119: Buffer Tranmit Premiums | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-5e51-f650-348f9ddc8bd2
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    When I capture "InnerText" from "Lbl_Policy Number" as runtime value "Policy Number"

    # Source step 0120: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-7dbb-e986-19de66cff522
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "Auto_PolicyData_Smoke"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Auto - TC02_Verify Policy in Expert Quote with 1 V 1 D for Auto LOB"
    And I use TDM parameter "Data structure > Endorsement" with "N"

    # Source step 0121: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3c1f-ef85-a952-c47b1aa453f8
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
# 5. Source step 0016 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 6. Source step 0016 field "Txt_Enter a location" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 7. Source step 0016 field "Btn_Yes_client resides" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 8. Source step 0018 field "Drp List_Proposal Rating State" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0018 field "Hdr_proposal.ratingState-panel" in "Proposal Start-Enter Proposal details to Start Quote" was disabled. Reason:  
#    - Preserved source value: "New Mexico"
# 10. Source step 0022 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 25.01.24 15:11:05 [ct2628]
#    - WAIT "Lnk_USE EXISTING ACCOUNT" with "True"
#    - VERIFY "Lnk_USE EXISTING ACCOUNT" with "True"
# 11. Source step 0023 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 25.01.24 15:11:05 [ct2628]
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 12. Source step 0024 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 25.01.24 15:11:05 [ct2628]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 13. Source step 0029 field "Txt_Years Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: ""
# 14. Source step 0032 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0032 field "Lbl_Gender" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 16. Source step 0032 field "Btn_Male" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0032 field "Btn_Single" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0032 field "Txt_Months Licensed in Current State" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1"
# 19. Source step 0032 field "Txt_Date License" in "Driver Summary-Enter Driver Summary Details" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 20. Source step 0040 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 21. Source step 0040 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 22. Source step 0042 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 23. Source step 0042 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 24. Source step 0042 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 25. Source step 0057 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 13.11.23 12:19:54 [ct2453]
#    - VERIFY "Hdr_Discounts / Adjustments" with "True"
#    - WAIT "Btn_Next" with "True"
#    - VERIFY "Btn_Next" with "True"
# 26. Source step 0058 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 13.11.23 12:19:54 [ct2453]
#    - INPUT "Btn_Next" with "{Invoke[Click]}"
# 27. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 28. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0061 field "Btn_UMPD Limits" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 32. Source step 0066 field "Lbl_Primary Payer" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 33. Source step 0066 field "Lbl_Primary Payer Driver" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 34. Source step 0066 field "Lbl_Primary Payer Driver" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 35. Source step 0066 field "Btn_Primary Insured" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "Djfak Wopntz"
# 36. Source step 0066 field "Btn_Primary Insured1" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Down}"
# 37. Source step 0066 field "Txt_InitialPaymentAmount" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "110"
# 38. Source step 0066 field "DIV_Future PaymentPlan" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 39. Source step 0073 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0078 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0107 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 42. Source step 0108 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 43. Source step 0108 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 44. Source step 0108 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 45. Source step 0109 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 46. Source step 0119 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0119 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 48. Source step 0119 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
