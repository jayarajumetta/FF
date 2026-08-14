# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 065_Endorse_Auto_with_Esign_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @Arizona @Edge @manual @archive @automated
Feature: Execute Endorse Auto with Esign for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse Auto with Esign workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse Auto with Esign using representative iteration Arizona (AZ) — selected from TestCase-Design; no concrete instantiated TestCase was exported
    # Source step 0010: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-03fd-f1c3-f87a1224b6ae
    # Runtime control: Enter Sign On Credentials > Condition
    Given if the source runtime condition "Enter Sign On Credentials > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-922b-9f49-1ca3c3359b67
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-a96a-c49f-0405a74ede84
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-062f-caa2-cb35b8c9fc35
    # Runtime control: Enter Sign On Credentials > Else
    Then if the source runtime condition "Enter Sign On Credentials > Else" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-d90e-4f04-6d2005256386
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-721c-62b5-e67f1f588866
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
    When I enter or select "NEW MEXICO" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" is visible
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0017: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0018: Proposal Start-Enter Proposal details to Start Quote | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-2588-3b8d-a90181a113b3
    Then I wait until "Lbl_Proposal Details" is visible
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I use source configuration "Drp List_Proposal Rating State > State List" = "X" for "Proposal Start-Enter Proposal details to Start Quote"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    Then I wait until "Lbl_Select Risk Address" is visible
    When I enter or select "{Invoke[Click]}{SENDKEYS[ARIZONA]}" in "Drp List_State"
    When I click "Lbl_NEW MEXICO"
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"
    When I click "Btn_PROCEED"

    # Source step 0019: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-af20-8f58-4dc73e025faa
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0020: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-f293-e3e0-ac1a20913037
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0021: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-e717-d137-1719de6be698
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"
    When I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0025: PreQualification-Select Client & Property Eligibility Restrictions | Module: EQ||PreQualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-e60a-8bd0-175233c084cc
    Then I wait until "Btn_Chk box_check_boxNone Of The Above" is visible
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0026: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-5ec5-292f-f3a2fabd054e
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0027: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0028: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-7158-6566-ec62a4fadc04
    # Runtime control: Driver Summary-Gender Conditional > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Condition" is satisfied, "Btn_Male" should have "ClassName" equal to "*toggle-checked*"
    Then "Btn_Male" should exist

    # Source step 0029: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-65f8-ddba-366b4b8c1610
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-9feb-0c81-29e24527eaf2
    # Runtime control: Driver Summary-Gender Conditional > Else > If > Condition
    Then if the source runtime condition "Driver Summary-Gender Conditional > Else > If > Condition" is satisfied, "Btn_Male" should exist

    # Source step 0031: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-a11d-012a-e0f3d8db1199
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-d9d5-8d43-ef3e21e2f45f
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-e0dd-dc91-1c6b92071108
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0034: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-1bb9-19d9-b9cb68693413
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0035: UW popup | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-ee42-4504-225c98d232bb
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0036: Driver Information Next-Select Next & Continue | Module: EQ||Driver Information Next
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-4806-02a0-7796838038d9
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0037: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-a2c5-ba23-76a58ab2462b
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Condition
    Then if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Condition" is satisfied, "Hdr_Vehicle Information" should exist

    # Source step 0038: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-7d49-b0bd-687126e411b9
    # Runtime control: EQ||Vehicle Information-Vehicle Selection > Then
    When if the source runtime condition "EQ||Vehicle Information-Vehicle Selection > Then" is satisfied, I click "btn_select vehicle1"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0039: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-816b-a916-db49abc17db0
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0040: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-9aab-76f8-e907e729dc1e
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

    # Source step 0041: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0042: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-4824-ad88-a0098cf06d8c
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

    # Source step 0043: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0044: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-dfa8-5a53-703f596286e3
    When I click "Btn_Vehicle_Select"
    Then I wait until "Lbl_Principal or Occasional driver of this vehicle?" is visible
    When I click "Btn_Principal_New"
    When I click "Btn_Next"

    # Source step 0045: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-d711-a7d1-3d58faff0155
    # Runtime control: Driver Assignment- UW Popup > Condition
    Then if the source runtime condition "Driver Assignment- UW Popup > Condition" is satisfied, I wait until "Lnk_CONTINUE" is visible
    Then "Lnk_CONTINUE" should exist

    # Source step 0046: Driver Assignment-Select Driver Assignment & Continue | Module: EQ||Driver Assignment
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-163c-f20b-891cc67c94d7
    # Runtime control: Driver Assignment- UW Popup > Then
    When if the source runtime condition "Driver Assignment- UW Popup > Then" is satisfied, I click "Lnk_CONTINUE"

    # Source step 0047: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-3092-7974-f380875afd67
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Condition
    Then if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Condition" is satisfied, "Hdr_Claims" should exist

    # Source step 0048: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-d934-ab91-517a723f10cb
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then" is satisfied, I click "Btn_Next"

    # Source step 0049: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0050: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-768d-ea4e-1ead1f82449b
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then > If > Condition
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then > If > Condition" is satisfied, I perform the source-defined operation "Claims\\Violations-Review Claims & Violations and Continue" in module "EQ||Claims\\Violations"

    # Source step 0051: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-52cd-3e03-d6e4a9c60a86
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Then > If > Then
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Then > If > Then" is satisfied, I perform the source-defined operation "Claims\\Violations-Review Claims & Violations and Continue" in module "EQ||Claims\\Violations"

    # Source step 0052: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-0728-7d7b-d6ae0d1fdcf8
    # Runtime control: Claims\Violations-Review Claims & Violations and Continue > Else
    When if the source runtime condition "Claims\\Violations-Review Claims & Violations and Continue > Else" is satisfied, I click "Btn_Next"

    # Source step 0053: Discounts-Review Discounts & Continue | Module: EQ||Discounts\Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3bd1-5804-77bd-d6b6e3dffad8
    Then I wait until "Hdr_Discounts / Adjustments" exists
    When I select "Btn_D1_No"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0054: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0060: Coverages-Select Coverages & Continue | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-f494-e716-3c74add623ca
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0061: Additional Coverages-Select Additional Coverages & Continue | Module: EQ||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-a70c-6128-7d590bbd450e
    When I select "Btn_No Coverage_Accidental Death & Dismemberment"
    When I click "Btn_check_box_outline_blankKcmgw Unzp"
    When I select "Btn_UMPD_No Coverage_V1"
    Then I wait until "Lbl_Uninsured Motorist PD" is enabled
    When I click "Btn_Next"

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0063: Pricing Details-Review & Continue | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-299a-fed9-cf9fb9ec4e29
    Then I wait until "Hdr_Pricing Details_Header" is visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0064: Underwriting-Review & Continue | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-f815-1861-2ad7ca641e1c
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0065: Additional Interest Summary-Review & Continue | Module: EQ||Additional Interest Summary
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-99bf-7fcf-bd2c73afde4d
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"

    # Source step 0066: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    When I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0067: Billing-Enter Billing Details & Continue | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-699b-1766-77708011bdee
    When I click "Btn_New Account"
    When I click "Btn_AccountHolder"
    Then I wait until "Btn_Direct Bill" is visible
    When I click "Btn_Direct Bill"
    When I click "Btn_1 Payment"
    When I enter or select "25" in "Txt_PaymentDueDate"
    When I click "Btn_Check"
    When I enter or select "{CLICK}{SendKeys[2468135709]}" in "Txt_InitialPaymentCheckNumber"
    When I click "Btn_Next"

    # Source step 0068: EQ||Submission | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-5cca-61bc-2938b9fa39de
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should exist

    # Source step 0069: EQ||Submission | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-6009-371f-5f59a0da0a11
    # Runtime control: Submission-Review & Continue > Then
    When if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0070: EQ||Submission | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-48d3-3fd5-69add7f15ff1
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0071: EQ||Submission | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-dc07-d866-c8a087f00139
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0072: Launch To eSignature | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-40ed-432d-f4f026b3c4d4
    Then "Btn_Launch To eSignature" should exist
    When I click "Btn_Launch To eSignature"

    # Source step 0073: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-0c2e-6a6f-d6427644fda6
    # Runtime control: Launch Esignature > Condition
    Then if the source runtime condition "Launch Esignature > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0074: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-033e-2449-d187232533b4
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

    # Source step 0075: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0076: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-ae79-7bc0-ba2fd5ea2385
    # Runtime control: Launch Esignature > Then
    Then if the source runtime condition "Launch Esignature > Then" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0077: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-70cb-50e5-45f10519c68c
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0078: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0079: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be1-4554-109a-eaabb34db67d
    # Runtime control: Launch Esignature > Then
    When if the source runtime condition "Launch Esignature > Then" is satisfied, I close the active browser

    # Source step 0080: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0081: EQ|| Confirm Esign_1 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-7e03-23d1-7f64287f9ed9
    # Runtime control: Launch Esignature > Else
    Then if the source runtime condition "Launch Esignature > Else" is satisfied, I wait until "Btn_Confirm Signers" exists
    When I click "Btn_Confirm Signers"

    # Source step 0082: EQ|| Confirm Esign_2 | Module: EQ|| Confirm Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-b3d0-7e8a-ab94253adac4
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture "Value" from "Txt_PIN" as runtime value "TC14_NB - esign (Cycle)_NM_PIN"
    When I enter the RUNTIME-CONFIGURED value "EsignEmail" in "Txt_Email Address"
    When I click "Btn_Create Signing Package"

    # Source step 0083: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0084: CloseBrowser-Close the Esign browser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-d97d-b6ea-b30e9d9dc77d
    # Runtime control: Launch Esignature > Else
    When if the source runtime condition "Launch Esignature > Else" is satisfied, I close the active browser

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0086: Open Url | Module: Open Url_ARA
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-2dd8-e196-df9617d53303
    When I enter the RUNTIME-CONFIGURED value "OutlookURL" in "Url"
    When I enter or select "False" in "UseActiveTab"

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-47a8-5d94-ae66eb983038
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I wait "3000" milliseconds

    # Source step 0088: Refresh | Module: TBox Send Keys
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-9e3e-d49d-dde8e1165a8b
    # Runtime control: Wait on Email [max=6] > Refresh
    When if the source runtime condition "Wait on Email [max=6] > Refresh" is satisfied, I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0089: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-d485-3da4-e56efed540a1
    # Runtime control: Wait on Email [max=6] > Check if email is here
    Then if the source runtime condition "Wait on Email [max=6] > Check if email is here" is satisfied, "e-SignLive" should not exist

    # Source step 0090: Refresh | Module: TBox Send Keys
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-36ce-9994-1362a8d3cb9b
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0091: TBox Wait | Module: TBox Wait
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-683d-587d-f74e3aa89083
    When I wait "6000" milliseconds

    # Source step 0092: Refresh | Module: TBox Send Keys
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-a078-259e-9589ccbef807
    When I enter or select "*Mail*" in "Caption"
    When I enter or select "{F5}" in "Keys"

    # Source step 0093: Click on e-SignLive Email | Module: Click on e-SignLive Email
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-17e2-0b22-af9c42bae76d
    When I click "e-SignLive"

    # Source step 0094: Mail - Alekya.Peddireddy@AmericanNational.com | Module: Click on Esign Link
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-6603-321d-035c05c49c1c
    Then "[EXTERNAL] Action Required: Your insurance document is ready for review and signature." should equal "[EXTERNAL] Action Required: Your insurance document is ready for review and signature."
    When I click "TABLE > e-SignLive Link"

    # Source step 0095: OneSpan Sign | Module: OneSpan Sign
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-7e96-1dca-1d79916a6411
    When I enter captured runtime value "TC14_NB - esign (Cycle)_NM_PIN" in "Secret PIN Maximum number of characters allowed for the field is 100"
    When I click "Login"

    # Source step 0096: CloseBrowser | Module: CloseBrowser
    # Section: Process > Open Onespan link via web mail(Outlook) | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-8948-6ca1-2b700e124801
    When I close the active browser

    # Source step 0097: Signing documents for Esign | Module: <unresolved module>
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-76c8-82a1-90ef4691e916
    # Runtime control: Signing & Reviewing documents for Esign > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Condition" is satisfied, I wait until "<unnamed value>" is visible

    # Source step 0098: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-8e84-9e9c-0f7b97a90c73
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I click "Review Documents"

    # Source step 0099: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait "5000" milliseconds

    # Source step 0100: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-9069-66c9-046df2c9a39a
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0101: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-5749-d32c-4ceeb025a742
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0102: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-3ef9-f645-e661f965089a
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0103:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-7bcc-b32a-0d646b535801
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0104: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-d16c-c086-f414147af6ff
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0105: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0106: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0107: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-599d-9b09-cb8a0ee3a7bc
    # Runtime control: Signing & Reviewing documents for Esign > Then
    When if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I close the active browser

    # Source step 0108: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-c165-627a-04069bfb471f
    # Runtime control: Signing & Reviewing documents for Esign > Then
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Then" is satisfied, I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0109: TBox Scroll Window Operation | Module: TBox Scroll Window Operation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-af35-b710-04b26f54e90e
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I enter or select "Signing*" in "Caption"
    When I enter or select "1" in "Window Index"
    When I enter or select "4000px" in "Vertical"
    When I enter or select "6000px" in "Horizontal"
    When I enter or select "Center" in "MousePolicy"
    When I enter or select "HorizontalFirst" in "DirectionPolicy"
    When I enter or select "100ms" in "Delay"

    # Source step 0110: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-9485-c3cf-46cf989b2265
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0111: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-a63d-3917-6b34aed6a939
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0112: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-277b-0566-bc2dbd43d109
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0113:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-040e-2c06-79a24e88c145
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0114: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-9433-268c-d502b7d6aa99
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0115: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0116: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Signing  documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Signing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0117: Click on Review Document | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-1b19-338d-fa2351d3a337
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I click "Review Documents"

    # Source step 0118: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I wait "5000" milliseconds

    # Source step 0119: Verify Page count Exists | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-3b63-2be4-e619f328f64e
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Condition" is satisfied, "Page Details" should have "ResultCount" equal to "0"

    # Source step 0120: Buffer Sign & Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-268f-37b0-47ffc8b1e086
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture "ResultCount" from "Initial_Count" as runtime value "InitialCount"
    When I capture "ResultCount" from "Sign_Count" as runtime value "SignCount"

    # Source step 0121: Click on Initial Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process > Click on Initial Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-613a-5cb9-5a43a2604f37
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Initial"

    # Source step 0122:  Click on Sign Count | Module: Signing  & Reviewing documents for Esign
    # Section: Process >  Click on Sign Count | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-6d53-1893-01f312d3fed8
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I click "Sign"

    # Source step 0123: Accept|Next|Confirm|Finished | Module: Signing  & Reviewing documents for Esign
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-448f-d974-19e9e6a73c91
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    Then if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait until "Accept|Next|Confirm|Finished" is visible
    When I click "Accept|Next|Confirm|Finished"

    # Source step 0124: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I wait "5000" milliseconds

    # Source step 0125: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else > Reviewing documents for Esign [max=30] > Loop" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0126: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-11dd-1b0a-57a12f73c396
    # Runtime control: Signing & Reviewing documents for Esign > Else
    When if the source runtime condition "Signing & Reviewing documents for Esign > Else" is satisfied, I close the active browser

    # Source step 0127: Launch To Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-76ab-f871-56a22d9c85d3
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0129: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-4583-f9ff-e8f103b2513f
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0131: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-868e-7a99-32861e2b0038
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

    # Source step 0132: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-83bb-da16-82c5c0bcd0ac
    When I select "Lnk_No Need-Prior Ins"

    # Source step 0133: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Upload Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-19f1-b162-161f3696956a
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0134: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Upload Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-b611-fecf-9c9cd4d8dfdd
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0135: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0136: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-aaaa-574b-7ed8ca8d0ef3
    When I close the active browser

    # Source step 0137: Back to Submission page and click ok | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-9bc9-738d-a4f87d7494d6
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"

    # Source step 0138: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0139: Click on Transmit Button | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-ab2b-b51a-886eea373b5f
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0140: Buffer Tranmit Premiums | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-f3fb-be52-888a3f3ca061
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"
    When I capture "InnerText" from "Lbl_Policy Number" as runtime value "Policy Number"

    # Source step 0141: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-d0c7-9370-b9a449f7dc28
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Auto - TC10_New Business - esign (Auto)_NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"

    # Source step 0142: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3be5-cf84-7ca5-eba2edb49bd8
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
# 20. Source step 0040 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 21. Source step 0040 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 22. Source step 0040 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 23. Source step 0040 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 24. Source step 0042 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 25. Source step 0042 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 26. Source step 0042 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 27. Source step 0042 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 28. Source step 0055 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 30.01.24 22:30:45 [ct2628]
#    - WAIT "Btn_Next" with "True"
#    - VERIFY "Btn_Next" with "True"
# 29. Source step 0056 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 30.01.24 22:30:45 [ct2628]
#    - WAIT "Btn_Next" with "True"
#    - WAIT "Btn_Next" with "True"
#    - INPUT "Btn_Next" with "{Invoke[Click]}"
# 30. Source step 0057 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 13.11.23 12:19:54 [ct2453]
#    - VERIFY "Hdr_Discounts / Adjustments" with "True"
#    - WAIT "Btn_Next" with "True"
#    - VERIFY "Btn_Next" with "True"
# 31. Source step 0058 "Discounts-Review Discounts & Continue" in module "EQ||Discounts\\Adjustments" was disabled. Reason: 13.11.23 12:19:54 [ct2453]
#    - INPUT "Btn_Next" with "{Invoke[Click]}"
# 32. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 33. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0060 field "<unnamed value>" in "Coverages-Select Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0061 field "Btn_UMPD Limits" in "Additional Coverages-Select Additional Coverages & Continue" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 37. Source step 0067 field "Lbl_Primary Payer" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0067 field "Lbl_Primary Payer Driver" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 39. Source step 0067 field "Lbl_Primary Payer Driver" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 40. Source step 0067 field "Btn_Primary Insured" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "Djfak Wopntz"
# 41. Source step 0067 field "Btn_Primary Insured1" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Down}"
# 42. Source step 0067 field "Txt_InitialPaymentAmount" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "110"
# 43. Source step 0067 field "DIV_Future PaymentPlan" in "Billing-Enter Billing Details & Continue" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 44. Source step 0076 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 45. Source step 0081 field "TABLE" in "EQ|| Confirm Esign_1" was disabled. Reason:  
#    - Preserved source value: a blank value
# 46. Source step 0128 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 47. Source step 0129 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 48. Source step 0129 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 49. Source step 0129 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 50. Source step 0130 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 51. Source step 0140 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0140 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 53. Source step 0140 field "Btn_Transmit" in "Buffer Tranmit Premiums" was disabled. Reason:  
#    - Preserved source value: "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
