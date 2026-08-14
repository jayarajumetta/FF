# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 016_Activity_Points_-_Major_Conviction_Auto_-_NJ_NJ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @activity_points @New_Jersey @Edge @manual @archive @automated
Feature: Execute Activity Points - Major Conviction (Auto) - NJ for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Activity Points - Major Conviction (Auto) - NJ workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Activity Points - Major Conviction (Auto) - NJ using representative iteration New Jersey (NJ)
    # Source step 0011: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-3754-88a5-41239bdd7c9c
    # Runtime control: Enter Sign On Credentials > Condition
    Given if the source runtime condition "Enter Sign On Credentials > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"

    # Source step 0012: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-b067-1bc9-c0f5dfa724fd
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
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-b76d-cd2d-4189214a47dd
    # Runtime control: Enter Sign On Credentials > Then
    Then if the source runtime condition "Enter Sign On Credentials > Then" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0014: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-6e69-2369-ac1cbc7d4f18
    # Runtime control: Enter Sign On Credentials > Else
    Then if the source runtime condition "Enter Sign On Credentials > Else" is satisfied, I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0015: Enter Client Selection | Module: EQ || Client Selection
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-e19f-afb3-d811fbae7b7b
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

    # Source step 0016: Enter Account Details | Module: EQ||Account Details
    # Section: Process > Auto Policy > 01 Client Slection & Account Details for New Client | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-8158-2374-0f7b9f5059b3
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
    When I enter or select "NEW JERSEY" in "Drpdwn_State"
    When I enter or select "{RETURN}" in "Drpdwn_State"
    When I enter captured runtime value "Zip" in "Txt_owner.address.zip"
    Then "Lbl_Have you received mail at this address for at least 90 days?" should exist
    When I select "Btn_Yes_at least 90 days"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0017: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0018: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-8b32-e581-69d8e84b0d18
    Then "Lbl_Proposal Details" should exist
    When I click "Btn_Personal Auto"
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Effective Date"
    When I enter or select "{Invoke[Click]}{SENDKEYS[NEW JERSEY]}" in "Drp List_Proposal Rating State"
    When I enter or select "D2102" in "Txt_Agent PCCode"
    When I select "Drp_Writing Company"
    When I click "Lbl_United Farm Family Insurance Co."
    Then I wait until "Lbl_Select Risk Address" exists
    When I click "Rd Btn_Same as NewAccountAddress"
    When I click "Btn_Start Quote"

    # Source step 0019: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-7613-0681-c01bf3bd9eb9
    # Runtime control: Prposal Start_Proceed  > Condition - If Popup appears
    Then if the source runtime condition "Prposal Start_Proceed > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0020: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-4d6e-5c51-0ee59a86b22b
    # Runtime control: Prposal Start_Proceed  > Then
    When if the source runtime condition "Prposal Start_Proceed > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0021: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-8044-969e-611a1339c845
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Condition
    Then if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Condition" is satisfied, "DIV_Confirm the Client's SSN#" should be visible

    # Source step 0022: ExpertQuote | Module: Confirm the Client's SSN# Popup-Edit/Confirm
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-7362-ad15-9959a5917e8a
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Then
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0023: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-d6b6-0517-e2a197464308
    # Runtime control: Proposal Start-Invalid Address,SSN,Client already exists > Else
    When if the source runtime condition "Proposal Start-Invalid Address,SSN,Client already exists > Else" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0024: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-b2e2-7091-b4a21d9f4eea
    # Runtime control: Proposal Start-UW Popup > Condition
    Then if the source runtime condition "Proposal Start-UW Popup > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists
    Then "Lnk_USE EXISTING ACCOUNT" should exist

    # Source step 0025: Proposal Start-Invalid Address,SSN,Client already exists | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto Policy > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-b289-427d-7e7381acdc96
    # Runtime control: Proposal Start-UW Popup > Then
    When if the source runtime condition "Proposal Start-UW Popup > Then" is satisfied, I click "Lnk_USE EXISTING ACCOUNT"

    # Source step 0027: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-c4ab-f4c5-961653af7902
    When I capture "InnerText" from "Lbl_Quote" as runtime value "QuoteNumber"
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0028: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-9e3a-8fc2-94bba6b59325
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0029: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Auto Policy > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-9619-2193-51b848ba6a76
    When I select "Btn_Chk box_check_boxNone Of The Above"
    When I click "Btn_Next"

    # Source step 0030: Enter Driver Information | Module: EQ||Driver Information
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-5096-5c23-88bfd046e2ac
    When I click "Btn_(Existing Client)"
    When I click "Btn_Next"

    # Source step 0031: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-a5c8-abb4-8d1af68a3764
    # Runtime control: If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected
    Then if the source runtime condition "If_Driver Sumary_Prior Insurance > Condition - If prior insurance is selected" is satisfied, "Btn_PriorInsurance_Yes" should be enabled

    # Source step 0032: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-f793-3e67-1dda0af9fd5e
    # Runtime control: If_Driver Sumary_Prior Insurance > Then
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Then" is satisfied, I click "Btn_Primary Named Insured"
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

    # Source step 0033: EQ||Driver Summary | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2da6-00b9-7f65-bc7057c4c1d8
    # Runtime control: If_Driver Sumary_Prior Insurance > Else
    When if the source runtime condition "If_Driver Sumary_Prior Insurance > Else" is satisfied, I click "Btn_Primary Named Insured"
    Then I wait until "Txt_Years Licensed in Current State" is enabled
    When I select "Txt_Years Licensed in Current State"
    When I enter or select "{Click}{Sendkeys[19]}" in "Txt_Years Licensed in Current State"
    When I press "Enter" while focused on "Txt_Years Licensed in Current State"
    When I select "Btn_FinancialResponsibility_No"
    When I click "Btn_Save and Continue"

    # Source step 0034: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "40000" milliseconds

    # Source step 0035: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > Auto Policy > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db5-1fdd-923d-c3fbea2991c8
    When I click "Btn_Next"

    # Source step 0036: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db5-4360-e5a5-13b286025f47
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition" is satisfied, I wait until "btn_select vehicle1" exists
    Then "btn_select vehicle1" should exist

    # Source step 0037: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db5-4b28-a679-b955b9300ca6
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then" is satisfied, I click "btn_select vehicle1"
    When I click "Btn_Next"

    # Source step 0038: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db5-b3f9-f310-2ad113e758c4
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition
    Then if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Condition" is satisfied, "Txt_VIN number" should equal ""

    # Source step 0039: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db5-1854-8f81-a879b1d04023
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

    # Source step 0040: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Then" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0041: Vehicle Summary-Enter Vehicle Summary Details | Module: EQ||Vehicle Summary
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db5-c8a2-5cd4-a4bf3844ec97
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

    # Source step 0042: TBox Take Screenshot | Module: TBox Take Screenshot
    # Section: Process > Auto Policy > 05 Vehicle Summary | Reusable flow: zz TBox Take Screenshot | Source XTestStep: 3a19dd55-d3cb-2b7f-2694-cbb062579d8d
    # Runtime control: Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else
    When if the source runtime condition "Vehicle Summary-Enter Vehicle Summary Details - Conditional > Else" is satisfied, I capture a "Desktop" screenshot at "C:\\Tosca_Projects\\Screenshots"

    # Source step 0043: Enter Driver Assignment | Module: EQ||Driver Assignment
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-b274-6a9b-017f3dc10a14
    When I click "Btn_2002 Lexus GS430"
    When I click "Btn_Principal_1"
    When I click "Btn_Next"

    # Source step 0044: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-118d-5811-a2c9ef55953f
    # Runtime control: Driver Summary-UW Popup > Condition
    Then if the source runtime condition "Driver Summary-UW Popup > Condition" is satisfied, I wait until "Lnk_UWR_BACK TO DETAILS" exists
    Then "Lnk_UWR_BACK TO DETAILS" should exist

    # Source step 0045: Driver Summary-Enter Driver Summary Details | Module: EQ||Driver Summary
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-1013-e1a9-919eccf45549
    # Runtime control: Driver Summary-UW Popup > Then
    When if the source runtime condition "Driver Summary-UW Popup > Then" is satisfied, I click "Lnk_UWR_CONTINUE"

    # Source step 0046: UW popup | Module: TBox Set Buffer
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-8604-1c2e-0b019a9a8209
    # Runtime control: Driver Summary-UW Popup > Else
    When if the source runtime condition "Driver Summary-UW Popup > Else" is satisfied, I retain hard-coded value "Popup not appeared" as runtime value "UW Popup"

    # Source step 0047: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 06 Driver Assignment | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0048: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-00c9-ca63-b6330074f8af
    # Runtime control: Claims/Violations Popup > Condition
    Then if the source runtime condition "Claims/Violations Popup > Condition" is satisfied, "Hdr_Edit Violation" should be visible

    # Source step 0049: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-b99b-1ab9-96a68e665806
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_+ ADD VIOLATION"

    # Source step 0050: ExpertQuote|Violations | Module: EQ|Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-5572-5791-9337cf8fa938
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I enter or select "10/10/2022" in "Violation/Susp Dat"
    Then "Driver Involved" should be visible
    When I click "Courtney Allison"
    When I enter or select "{invoke[Click]}{sendkeys[CR - Contest Racing]}" in "DIV_1"
    When I enter or select "10/10/2022" in "Conviction Date"
    When I click "Applies"
    When I click "Save and Continue"

    # Source step 0051: Claims\Violations-Review Claims & Violations and Continue | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-b4fe-729b-f689fdde40b4
    # Runtime control: Claims/Violations Popup > Then
    When if the source runtime condition "Claims/Violations Popup > Then" is satisfied, I click "Btn_Next"

    # Source step 0052: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto Policy > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-2e2e-9b6f-119a9c014351
    # Runtime control: Claims/Violations Popup > Else
    When if the source runtime condition "Claims/Violations Popup > Else" is satisfied, I click "Btn_Next"

    # Source step 0053: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-49e6-7370-85f2c3a721ad
    When I select "Btn_Not Residential Property Owner"
    When I click "Btn_Next"

    # Source step 0054: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 08 Discounts | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0055: Enter Coverages | Module: <unresolved module>
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-3e36-d86e-7a4295439d6e
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0056: Additional Coverages_New | Module: EQ||Additional Coverages
    # Section: Process > Auto Policy > 09 Coverages | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-8ef7-0b11-cdde3296080b
    When I select "Btn_UMPD No Coverage"
    When I click "Btn_Full"
    When I click "Btn_$15,000_PIP Limit"
    When I select "Btn_No Coverage_2"
    When I select "Btn_No_EXtra PIP Option"
    When I select "Btn_No_Auto Health Insurer"
    When I click "Btn_Next"

    # Source step 0057: Enter Pricing Details | Module: EQ||Pricing Details
    # Section: Process > Auto Policy > 10 Pricing | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-e319-da44-5ad17c971ea0
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0058: Enter Underwriting | Module: <unresolved module>
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-275b-0f97-32bcbf95d234
    When I click "<unnamed value>"

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0060: Enter Additional Interest Summary | Module: EQ||Additional Interest Summary
    # Section: Process > Auto Policy > 11 Underwriting & Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-66f5-b45c-c8300d49621c
    When I click "btn_Next"

    # Source step 0061: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Auto Policy > 12 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0066: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 12 Billing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0067: Verify if Principal/occasional operator assigned_ErrorMsg is visible | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1628-6ddc-52b74ce16088
    # Runtime control: Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Verify if Principal/occasional operator assigned_ErrorMsg is visible" is satisfied, "Lbl_Principal/occasional operator assigned_ErrorMsg" should be visible

    # Source step 0068: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0072: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-43c1-31f7-aad2e9bbde07
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0073: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-6a01-ae7a-ee22ddb3ba5f
    # Runtime control: Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0074: Search Policy Number | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-099f-df0f-274df411ba78
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0075: Click on Insured and Product type | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-e8ab-ad9c-636fe39d7102
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Insured Name"
    When I enter the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation) in "Lnk_Motorcycle"
    When I click "Lnk_PersonalAuto"
    When I enter the unresolved source parameter "Home" (not supplied by this reusable-block invocation) in "Lnk_Home"
    When I enter the unresolved source parameter "ROP" (not supplied by this reusable-block invocation) in "Lnk_ROP"

    # Source step 0076: Click on Pricing | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-cb29-0340-1e157ac35cb4
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0078: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-5cee-04bd-4413505afcfa
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    Then I wait until "Bypass Level 9 Comments" is visible

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "20000" milliseconds

    # Source step 0080: ChkBox_Bypass Level 9 Rules | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-bfcf-3e39-51c6223fdca5
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I enter or select "{Click}{Sendkeys[Bypassed]}" in "Bypass Level 9 Comments_1"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0082: Click on Home button | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-3c7e-61e8-9ab899082709
    # Runtime control: Submission - Principal/occasional operator > Then
    Then if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait until "Lnk_Home" is visible
    When I click "Lnk_Home"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I wait "12000" milliseconds

    # Source step 0084: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-39f2-c1d1-e921351aafb0
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I close the active browser

    # Source step 0085: Submission_2-Back to Submission page | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-fc51-260f-d5e012702200
    # Runtime control: Submission - Principal/occasional operator > Then
    When if the source runtime condition "Submission - Principal/occasional operator > Then" is satisfied, I click "Btn_Save and Exit"

    # Source step 0086: Another user is currently accessing this quote. Please try again in a moment. | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-c40e-f8ae-530189973621
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible
    Then if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Verify if Another user is currently accessing this quote. Please try again in a moment is visible" is satisfied, "Another user is currently accessing this quote. Please try again in a moment." should be visible

    # Source step 0087: Click ok & Recall Quote | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-51d3-56c9-c1ae146b3559
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Ok"

    # Source step 0088: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-7513-ff40-3bfe421e0174
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0089: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-f56b-6ac0-9f37a9f47e01
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I click "Submission"

    # Source step 0090: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > Click ok Button & Recall Quote" is satisfied, I wait "8000" milliseconds

    # Source step 0091: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-1340-698c-d88615fce821
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0092: Click on Submission | Module: EQ | Side Menu
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule | Source XTestStep: 3a19dd55-d407-4090-cfbc-1fe8c3e568a1
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I click "Submission"

    # Source step 0093: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 13 Submission > Submission - Principal/occasional operator > Approve in Express UI | Reusable flow: Auto | Express| Approve in Express UI for Level 9 rule > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible
    When if the source runtime condition "Submission - Principal/occasional operator > Then > Handling Error Accessing Quote > If Popup not Visible" is satisfied, I wait "8000" milliseconds

    # Source step 0094: Verify if submission page is visible | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-2635-4481-6dc27dd2af07
    # Runtime control: Submission-Review & Continue > Condition
    Then if the source runtime condition "Submission-Review & Continue > Condition" is satisfied, "Txt_AgentComments" should be visible

    # Source step 0095: Enter Agent Comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-5907-1df8-87941f50d5f1
    # Runtime control: Submission-Review & Continue > Then
    Then if the source runtime condition "Submission-Review & Continue > Then" is satisfied, I wait until "Txt_AgentComments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_AgentComments"

    # Source step 0096: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-9cf7-0c40-0037fc7bc355
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Condition" is satisfied, "Txt2_Agent Comments" should exist

    # Source step 0097: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-a5d4-f4a1-aac7303063c8
    # Runtime control: Submission-Review & Continue > Then > If another Agent comments appear > Then
    Then if the source runtime condition "Submission-Review & Continue > Then > If another Agent comments appear > Then" is satisfied, I wait until "Txt2_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt2_Agent Comments"

    # Source step 0098: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-2979-ce6b-a4b57b5f35ab
    # Runtime control: Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Verify if Refer UW Agent appears" is satisfied, "Txt_Agent Comments" should exist

    # Source step 0099: Enter Agent comments | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-b91e-009b-f52c5f714ecb
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I wait until "Txt_Agent Comments" is visible
    When I enter or select "{CLICK}{SENDKEYS[Review Completed]}" in "Txt_Agent Comments"
    When I click "Btn_Refer to UW"

    # Source step 0100: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-c931-99ce-56fed816519f
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments > If another Agent comments appear > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments > If another Agent comments appear > Condition" is satisfied, "Txt_Agent_Cmnts_Refer to UW" should exist

    # Source step 0101: EQ||Submission | Module: EQ||Submission
    # Section: Process > Auto Policy > 13 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-4471-416f-155aca080658
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments > If another Agent comments appear > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments > If another Agent comments appear > Then" is satisfied, I enter or select "{Invoke[Click]}{SENDKEYS[Review Completed]}" in "Txt_Agent_Cmnts_Refer to UW"
    When I click "Btn_Refer to UW"

    # Source step 0102: OpenUrl | Module: OpenUrl
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0106: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0107: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0108: EU||Home | Module: EU||Home
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0109: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0110: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I click "Lnk_Pricing"

    # Source step 0111: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0112: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments > If Level 9 exists > Condition
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0113: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments > If Level 9 exists > Then
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0116: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 13 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I close the active browser

    # Source step 0117: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-26dd-68c1-887e0d1f82e8
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0118: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-4b59-52ad-568a78293947
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    Then if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I wait until "Btn_New Quote" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0119: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Auto Policy > 13 Submission > Save and Exit Current Quote | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-c146-9397-9fd2ce3e96a8
    # Runtime control: Submission-Check for Refer UW Condition > Enter Agent comments
    When if the source runtime condition "Submission-Check for Refer UW Condition > Enter Agent comments" is satisfied, I click "Submission"

    # Source step 0120: Launch To Checklist | Module: EQ||Submission
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-1f84-548e-82d2aca9e36d
    Then "Btn_Launch To Checklist" should exist
    When I click "Btn_Launch To Checklist"

    # Source step 0122: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-b97d-f3d8-81ad46aad8b3
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition" is satisfied, "Img_American National Family of Companies" should exist
    Then "Lbl_Sign On" should exist
    Then "Lbl_Please sign on and we'll send you right along." should exist
    Then "Lbl_Username" should equal "Username"
    Then "Lbl_Password" should equal "Password"
    Then "Lnk_FORGOT LOGIN ID?" should exist
    Then "Lnk_FORGOT PASSWORD?" should exist
    Then "Btn_Sign On" should exist

    # Source step 0124: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-83db-7002-856080a99786
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

    # Source step 0125: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-4aca-e00e-b0f0161d8232
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0126: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-899e-6136-1bc59166b65a
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0127: TBox Save As | Module: TBox Save As
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-ac5f-f5e1-94a691ad21c0
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0128: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Auto Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-af86-8d2f-707f793df96c
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0129: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Auto Policy > 15 Launch Checklist > EU||Uploading_Docs | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-1d1f-a637-31c550bcadcc
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0131: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0132: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > 15 Launch Checklist | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-dfb4-9031-b8603b91970d
    When I close the active browser

    # Source step 0133: EQ||Submission_1 | Module: EQ||Submission
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-8b7c-e824-71ee985953ed
    Then I wait until "Btn_Ok" exists
    When I click "Btn_Ok"
    Then I wait until "Btn_Transmit" exists
    Then "Btn_Transmit" should equal "Transmit"
    When I click "Btn_Transmit"

    # Source step 0134: TBox Wait | Module: TBox Wait
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0135: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-648e-4cb1-d4f3bbf5568f
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0136: Save & Exit | Module: EQ||Submission
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-ee0a-7d3e-a9d008883f04
    When I click "Btn_Save and Exit"

    # Source step 0137: Push Quote Data & Policy Information to TDS_Reference | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-57f3-cb75-04f47881cbd6
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS_Reference"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Activity Points - Major Conviction (Auto) - NJ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0138: Push Quote Data & Policy Information to TDS Regression_Temp_Data | Module: TestData - Create & provide new item
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-647b-9270-cd1b8d78aeb8
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS Regression_Temp_Data"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCaseName" with "Activity Points - Major Conviction (Auto) - NJ"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NJ"

    # Source step 0139: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-6ee1-b744-98941cd1d554
    When I close the active browser

    # Source step 0140: OpenUrl | Module: OpenUrl
    # Section: Process > Activity Points Major | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0144: Verify ExpressUI Sign on page showed up | Module: EU||Login
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-dd76-8ae2-e71f95f11aab
    # Runtime control: If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed
    Then if the source runtime condition "If_ExpressUI Sign on page showed up or not > Condition - if signon page is displayed" is satisfied, "Lbl_Login ID" should exist
    Then "Lbl_Password" should exist
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    Then "Lnk_LOGIN" should exist

    # Source step 0145: Provide Sign on credentials | Module: EU||Login
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-c711-64f2-871f1acd3390
    # Runtime control: If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials
    When if the source runtime condition "If_ExpressUI Sign on page showed up or not > Then - Enter Sign On Credentials" is satisfied, I enter or select "\"^{a}\"" in "Txt_Login ID_1"
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0146: Search  Policy Number | Module: EU||Home
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-62a1-203b-850c729798ed
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter captured runtime value "Policy Number" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0147: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-03a9-f6ec-f8a7683a45a7
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" is visible
    When I click "Lnk_PersonalAuto"

    # Source step 0148: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-f614-25bf-3ef8b2c0fcf1
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0149: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-50b0-4df4-9072b3b6d88b
    # Runtime control: If_Transact page shows yes > Condition - If yes button exists
    Then if the source runtime condition "If_Transact page shows yes > Condition - If yes button exists" is satisfied, "Btn_Yes" should exist

    # Source step 0150: EU||Transact | Module: EU||Transact
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-e985-153b-994d2fbd2149
    # Runtime control: If_Transact page shows yes > Then - Select 'Yes' button and proceed
    When if the source runtime condition "If_Transact page shows yes > Then - Select 'Yes' button and proceed" is satisfied, I select "Btn_Yes"

    # Source step 0151: EU||Applicant | Module: EU||Applicant
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-7850-8661-de033c4cdb63
    When I click "Btn_Ok"
    When I click "Lnk_Pricing"

    # Source step 0152: EU||Pricing | Module: EU||Pricing
    # Section: Process > Activity Points Major | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2db8-0f21-78f0-4a0c62b45c96
    When I click "Btn_Activity Point Total"
    When I capture "InnerText" from "Hdr_DC-SECTION > Activitypoints Score" as runtime value "ActivityPoints"

    # Source step 0162: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Auto" as runtime value "LOB"
    When I retain hard-coded value "NJ" as runtime value "State"

    # Source step 0172: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0173: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0174:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0175: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-2dc4-7957-53d5-7c64d0dcba7b
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
# 5. Source step 0016 field "Btn_Married" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0016 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0016 field "Txt_Enter a location" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "{click}{down}"
# 8. Source step 0016 field "Btn_Yes_client resides" in "Enter Account Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0018 field "Btn_Recreational Vehicle" in "EQ||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0023 field "Lnk_USE EXISTING ACCOUNT" in "EQ||Proposal Start Proceed & SSN" was disabled. Reason:  
#    - Preserved source value: "X"
# 11. Source step 0026 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 12. Source step 0030 field "Btn_(Existing Client)*" in "Enter Driver Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0032 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0032 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 15. Source step 0032 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0032 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0032 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 18. Source step 0032 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0032 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 20. Source step 0032 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 21. Source step 0032 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 22. Source step 0032 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 23. Source step 0032 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0033 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 25. Source step 0033 field "Lbl_Gender" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "Gender"
# 26. Source step 0033 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0033 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 28. Source step 0033 field "Btn_Male" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0033 field "Btn_Single" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0033 field "Btn_Assigned" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 31. Source step 0033 field "Txt_Months Licensed in Current State" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1"
# 32. Source step 0033 field "Txt_Date License" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "1/1/2015"
# 33. Source step 0033 field "Btn_PriorInsurance_Yes" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0033 field "Btn_PriorInsurance_No" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0033 field "Btn_priorCarrierName" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0033 field "Btn_priorCarrierName" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 37. Source step 0033 field "Btn_priorCarrierName" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Geico]}"
# 38. Source step 0033 field "Btn_priorPolicyNumber" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 39. Source step 0033 field "Btn_priorPolicyNumber" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 40. Source step 0033 field "Btn_priorPolicyNumber" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[5127398001]}"
# 41. Source step 0033 field "Btn_yearsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0033 field "Btn_yearsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 43. Source step 0033 field "Btn_yearsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[2]}"
# 44. Source step 0033 field "Btn_monthsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0033 field "Btn_monthsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 46. Source step 0033 field "Btn_monthsWithPriorCarrier" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[0]}"
# 47. Source step 0033 field "Btn_Did Not Have Insurance" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0033 field "Lnk_UWR_CONTINUE" in "EQ||Driver Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0035 field "Btn_Add Additional Driver" in "EQ||Driver Information Next" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0036 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0036 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0037 field "Btn_Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0039 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 54. Source step 0039 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 55. Source step 0039 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 56. Source step 0039 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 57. Source step 0041 field "Btn_Automobile" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 58. Source step 0041 field "Btn_Leased" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 59. Source step 0041 field "Txt_Odometer" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "60000"
# 60. Source step 0041 field "Txt_AnnualMileage" in "Vehicle Summary-Enter Vehicle Summary Details" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 61. Source step 0048 field "Hdr_Claims" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0049 field "Btn_+ ADD CLAIM" in "EQ||Claims\\Violations" was disabled. Reason:  
#    - Preserved source value: "X"
# 63. Source step 0053 field "Btn_D1_No" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0053 field "Hdr_Discounts page" in "EQ||Discounts_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 65. Source step 0055 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 66. Source step 0055 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 67. Source step 0055 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0055 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0055 field "<unnamed value>" in "Enter Coverages" was disabled. Reason:  
#    - Preserved source value: "X"
# 70. Source step 0056 field "Btn_No Coverage_UMPD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 71. Source step 0056 field "Btn_check_box_outline_blankDjfak Wopntz" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 72. Source step 0056 field "Btn_check_box_outline_blankKcmgw Unzp" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 73. Source step 0056 field "Btn_No Coverage_Accidental Death & Dismemberment" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 74. Source step 0056 field "Lbl_Uninsured Motorist PD" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0056 field "Btn_UMPD Limits" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "No Coverage_1"
# 76. Source step 0056 field "Btn_No Coverage_Vehicle3" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 77. Source step 0056 field "Btn_UMPD_No Coverage_V3" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0056 field "Btn_UMPD_No Coverage_V4" in "Additional Coverages_New" was disabled. Reason:  
#    - Preserved source value: "X"
# 79. Source step 0060 field "Btn_Next" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0060 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0060 field "<unnamed value>" in "Enter Additional Interest Summary" was disabled. Reason:  
#    - Preserved source value: "X"
# 82. Source step 0062 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 83. Source step 0063 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 84. Source step 0064 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 85. Source step 0065 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 86. Source step 0069 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 87. Source step 0070 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 88. Source step 0071 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 89. Source step 0101 field "Txt_Agent_Cmnts_Refer to UW_3" in "EQ||Submission" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 90. Source step 0103 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 91. Source step 0104 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 92. Source step 0105 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 93. Source step 0107 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0107 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 95. Source step 0111 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0111 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 97. Source step 0111 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 98. Source step 0111 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 99. Source step 0112 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0112 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 101. Source step 0112 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 102. Source step 0112 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 103. Source step 0113 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0113 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 105. Source step 0113 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 106. Source step 0113 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 107. Source step 0114 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 108. Source step 0115 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 109. Source step 0121 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 110. Source step 0122 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "\"^{a}\""
# 111. Source step 0122 field "Txt_Username" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: "YD2102"
# 112. Source step 0122 field "Txt_Password" in "Enter Sign On Credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 113. Source step 0123 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 114. Source step 0125 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 115. Source step 0130 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 116. Source step 0135 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 117. Source step 0135 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 118. Source step 0135 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
# 119. Source step 0141 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 120. Source step 0142 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 121. Source step 0143 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 122. Source step 0148 field "Btn_Yes" in "EU||Transact" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 123. Source step 0152 field "DIV_Risk Score" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "RiskScore"
# 124. Source step 0152 field "Hdr_DC-SECTION" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 125. Source step 0152 field "Btn_Close" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 126. Source step 0153 "Close the RCT Express Page" in module "CloseBrowser" was disabled. Reason: 15.04.24 15:38:33 [ct2634]
#    - INPUT "Title" with "Pricing*"
# 127. Source step 0154 "TBox Evaluation Tool" in module "TBox Evaluation Tool" was disabled. Reason: 15.04.24 15:38:33 [ct2634]
#    - VERIFY "Expression" with the RUNTIME-DERIVED buffer expression "'{B[ActivityPoints]}'=='5'"
# 128. Source step 0155 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 15.04.24 15:38:33 [ct2634]
#    - INPUT "Activity Point_NJ" with "Activity points for At fault_NJ is as Expected"
# 129. Source step 0156 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 15.04.24 15:38:33 [ct2634]
#    - INPUT "Activity Point_NJ" with "Activity points for At fault_NJ is as Fail"
# 130. Source step 0157 "Submission_1-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:42 [ct2634]
#    - BUFFER "Lbl_Value_Total Policy Premium" with "Premium"
#    - BUFFER "Lbl_Value_Effective Date" with "Effective Date"
#    - BUFFER "Lbl_Value_Policy Number" with "Policy Number"
#    - BUFFER "Lbl_Value_Checklist Id" with "CheckList ID"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 131. Source step 0158 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 26.06.24 16:56:12 [ct2634]
#    - INPUT "Existing or new TDS type" with "BaseRegression_Auto_PolicyData"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with captured runtime value "TCName"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "NJ"
# 132. Source step 0159 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 26.06.24 16:56:12 [ct2634]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "NJ"
# 133. Source step 0160 "Submission_2-Save & Exit" in module "EQ||Submission" was disabled. Reason: 06.03.24 13:07:46 [ct2634]
#    - INPUT "Btn_Save and Exit" with "X"
# 134. Source step 0161 "LogOut" in module "EQ||Log Out" was disabled. Reason: 02.11.23 15:20:44 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
# 135. Source step 0163 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 136. Source step 0164 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 137. Source step 0165 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 138. Source step 0166 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 139. Source step 0167 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 140. Source step 0168 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 141. Source step 0169 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 142. Source step 0170 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 143. Source step 0171 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: CloseBrowser
# 1. Source recovery step 0001 CloseBrowser: I close the active browser
