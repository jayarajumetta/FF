# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 212_Smoke_Test_Cycle_AL.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @smoke @Alabama @Edge @manual @automated
Feature: Execute Smoke Test Cycle for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Smoke Test Cycle workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Smoke Test Cycle using representative iteration Alabama (AL)
    # Source step 0012: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > Start New Quote | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Common | 01 EQ - Start New Quote | Source XTestStep: 3a19dd55-d443-6b95-2414-e782dd27e3e3
    Given I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Client Selection (NEW) | Source XTestStep: 3a19dd55-d49d-6991-8246-f114ce750615
    Then I wait until "Lbl_Client Info" exists
    Then "Lbl_Client Info" should equal "Client Info"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.First Name" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.Last Name" in "Txt_Last"
    Then I wait until "Btn_Search" exists
    When I click "Btn_Search"
    Then I wait until "Btn_Create New Client" has "InnerText" equal to "Create New Client"
    When I click "Btn_Create New Client"
    When I click "Btn_Next"

    # Source step 0014: Set StateName | Module: TBox Set Buffer
    # Section: Process | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a1a96b2-e11f-e48e-9f6e-bb78c0d69fc1
    When I retain hard-coded value "ALABAMA" as runtime value "StateName"
    When I retain the unresolved source parameter "State Abbreviation" (not supplied by this reusable-block invocation) as runtime value "State"

    # Source step 0015: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a19dd55-d4bb-5344-2b53-6fbb792cb2ce
    Then I wait until "Lbl_Account Information" exists
    Then "Txt_First Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.DOB" in "Txt_DOB"
    When I enter or select "5555551234" in "Txt_Best phone_Account Owner"
    When I enter or select "a@a.com" in "Txt_Email_Account Owner"
    Then I wait until "Lbl_Marital Status:" exists
    When I click "Btn_Single" when "'Marital Status' == \"Single\"" is satisfied
    When I select "Btn_Married" when "'Marital Status' == \"Married\"" is satisfied
    When I click "Btn_Divorced" when "'Marital Status' == \"Divorced\"" is satisfied
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.Street Address" in "Txt_Enter a location"
    When I enter the unresolved source parameter "Apartment" (not supplied by this reusable-block invocation) in "Txt_owner.address.line2"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.City" in "Txt_owner.address.city_New"
    When I select "Drpdwn_State"
    When I select "State Name"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.ZIP" in "Txt_owner.address.zip"
    Then I wait until "Satellite" is visible

    # Source step 0016: Account Details-Move down the screen | Module: EQ||Account Details
    # Section: Process | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a20ccea-6d87-3233-e1a5-8febbb16c0cb
    When I press "Shift+Tab" while focused on "Btn_Next"

    # Source step 0017: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a20cced-453c-5ea2-16e9-ff5272653480
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" exists
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0018: Proposal Details/Start | Module: EQ || Proposal Details/Start
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-4e49-24eb-78fee0c5fb2f
    When I click "Personal Auto" when "LOB == \"PersonalAuto\"" is satisfied
    When I click "Motorcycle" when "LOB == \"Cycle\"" is satisfied
    When I click "Recreational Vehicle" when "LOB == \"RecreationalVehicle\"" is satisfied
    When I enter the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE}]}" in "EffectiveDate" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "D2102" in "AgentCode" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "AgentCode" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "ALABAMA" in "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "American National Property And Casualty Co." in "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    Then I wait until "SameAsMailingAddress" is enabled
    When I click "SameAsMailingAddress"
    When I enter or select "Albany" in "County_ComboBox" when "State == \"NEW YORK\"" is satisfied
    When I enter or select "Adair" in "County_ComboBox" when "State == \"KENTUCKY\"" is satisfied
    Then I wait until "County_Yes" exists when "State == \"NEW YORK\" OR State == \"KENTUCKY\"" is satisfied
    When I select "County_Yes" when "State == \"NEW YORK\" OR State == \"KENTUCKY\"" is satisfied
    Then I wait until "Start Quote" is enabled
    When I click "Start Quote"

    # Source step 0019: Invalid Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-623e-b686-7ddf56301640
    # Runtime control: If Invalid Address Pops Up > Condition
    Then if the source runtime condition "If Invalid Address Pops Up > Condition" is satisfied, "Lnk_PROCEED" should exist

    # Source step 0020: Proceed with Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-d933-1f45-01d7c5884c97
    # Runtime control: If Invalid Address Pops Up > Then
    When if the source runtime condition "If Invalid Address Pops Up > Then" is satisfied, I click "Lnk_PROCEED"

    # Source step 0021: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-2346-4ac1-4484f91279c2
    # Runtime control: If SSN Pops Up > Condition
    Then if the source runtime condition "If SSN Pops Up > Condition" is satisfied, I wait until "Txt_SSN" exists
    Then "Lnk_SUBMIT" should exist

    # Source step 0022: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-e07a-c912-67b225b906d7
    # Runtime control: If SSN Pops Up > Then
    When if the source runtime condition "If SSN Pops Up > Then" is satisfied, I enter the RUNTIME-DERIVED TDM value "AL_ClientData.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0023: Confirm SSN? | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-ade4-c507-54a1e1752cd1
    # Runtime control: If SSN Pops Up > Else > If > Condition
    Then if the source runtime condition "If SSN Pops Up > Else > If > Condition" is satisfied, "Lnk_CONFIRM" should exist

    # Source step 0024: Select Confirm | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-3de6-f2d5-e7180cc12529
    # Runtime control: If SSN Pops Up > Else > If > Then
    When if the source runtime condition "If SSN Pops Up > Else > If > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0025: Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-9d1a-2059-569b4cf4abc0
    # Runtime control: If Existing Client Pops Up > Condition
    Then if the source runtime condition "If Existing Client Pops Up > Condition" is satisfied, I wait until "Lnk_USE EXISTING ACCOUNT" exists

    # Source step 0026: Select Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a19dd55-d4bb-62d6-6343-5954b89fe8eb
    # Runtime control: If Existing Client Pops Up > Then
    When if the source runtime condition "If Existing Client Pops Up > Then" is satisfied, I click "Lnk_CREATE NEW ACCOUNT" when "State == \"MONTANA\"" is satisfied
    When I click "Lnk_USE EXISTING ACCOUNT" when "State != \"MONTANA\"" is satisfied

    # Source step 0027: TBox Set Effective Date Buffer | Module: TBox Set Buffer
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (OLD) | Source XTestStep: 3a1a4eb2-e67c-37e2-de7d-16fe80bc5ef8
    When I retain the unresolved source parameter "Effective Date" (not supplied by this reusable-block invocation) as runtime value "EffectiveDate"

    # Source step 0028: EQ||Tabs - Capturing Quote number | Module: EQ||Tabs
    # Section: Process > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number | Source XTestStep: 3a19dd55-d443-9c9d-9370-343c6da34248
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0029: TBox Set Buffer - Trimming Quote number | Module: TBox Set Buffer
    # Section: Process > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number | Source XTestStep: 3a19dd55-d443-fb9d-e604-b32de4887229
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0030: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1999-ba64-a75f-dfe505d2a44b
    When I click "Btn_Close_tab"
    When I enter captured runtime value "QuoteNumber" in "Txt_quoteSearchInput"
    When I click "Btn_Search"

    # Source step 0031: EQ||Tabs | Module: EQ||Tabs
    # Section: Process > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1999-fc31-bb49-41b86cc1680f
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber6"
    Then "Lbl_QNum" should equal captured runtime value "QuoteNumber2"

    # Source step 0032: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 03 Pre-Qualification | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1999-d96e-5955-863289ca8abf
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber6]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber7"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber7]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber8"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber8]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber9"

    # Source step 0035: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1999-8070-458d-bff1dd88a536
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0010 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0015 field "Drpdwn_State" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: ""
# 3. Source step 0028 field "Lbl_Quote" in "EQ||Tabs - Capturing Quote number" was disabled. Reason:  
#    - Preserved source value: a blank value
# 4. Source step 0030 field "Btn_New_tab" in "EQ||Tabs" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 5. Source step 0030 field "Btn_Edit" in "EQ||Tabs" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 6. Source step 0032 field "Smoke_Auto_RecallQuote_AZ" in "TBox Set Buffer" was disabled. Reason:  
#    - Preserved source value: captured runtime value "QuoteNumber"
# 7. Source step 0033 "TestData - Create & provide new item" in module "TestData - Create & provide new item" was disabled. Reason: 07.02.25 10:53:26 [PA9962@dnanico1.aniconet.com]
#    - INPUT "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > Premium" with captured runtime value "Premium"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
#    - INPUT "Data structure > TestCase" with captured runtime value "TCName"
#    - INPUT "Data structure > Endorsement" with "N"
#    - INPUT "Data structure > State" with "MD"
# 8. Source step 0034 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 07.02.25 10:53:26 [PA9962@dnanico1.aniconet.com]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "MD"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - EQ sign out and close browser
# 1. Source recovery step 0036 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 2. Source recovery step 0037 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 3. Source recovery step 0038 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - EQ sign out and close browser
# 4. Source recovery step 0039 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 5. Source recovery step 0040 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 6. Source recovery step 0041 CloseBrowser: I close the active browser
