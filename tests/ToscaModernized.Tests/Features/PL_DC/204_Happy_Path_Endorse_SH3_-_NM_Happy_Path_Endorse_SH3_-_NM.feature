# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 204_Happy_Path_Endorse_SH3_-_NM_Happy_Path_Endorse_SH3_-_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @happy_path @Edge @manual @obsolete @automated
Feature: Execute Happy Path Endorse SH3 - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path Endorse SH3 - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path Endorse SH3 - NM using representative iteration Happy Path Endorse SH3 - NM
    # Source step 0026: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-e4b3-3336-afc9085f8943
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0027: Search for "Happy Path SH3 - NM" Policy in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-3e1b-5ce2-8af1d408d3d8
    Then "Btn_New Quote" should be visible
    When I enter or select "\"^{a}\"" in "Txt_QuoteSearch_Input"
    When I enter or select "\"{DEL}\"" in "Txt_QuoteSearch_Input"
    When I enter captured runtime value "PolicyNo" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0028: Policy Change\Start Page - Choose to create a new policy change | Module: EQH||Policy Change\Start Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb2-24b3-7a90-f991ae4cbb79
    Then I wait until "Header_Policy History" is visible
    When I click "+ CREATE NEW POLICY CHANGE"

    # Source step 0029: Policy Change\Create a new policy change | Module: EQH||Policy Change\Create a new policy change
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb2-f315-75a2-5088b27c9d19
    Then I wait until "Header_PolicyChange" is visible
    When I enter or select "Add a new endorsement" in "Txt_TransactionReasonDescription"
    When I click "OK"

    # Source step 0030: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0031: EQH||Side Menu and Quote Actions-Navigate to additional coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb2-2129-4c58-0a2c580e1fd0
    When I click "Additional Coverages"

    # Source step 0032: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0033: Additional Coverages-Add 'Ordinance Or Law Coverage' | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb3-d47c-4f4c-521278d99d5b
    Then I wait until "Txt_Search by Name-Coverage Catalog" is enabled
    When I enter or select "Ordinance Or Law Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0034: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0035: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-199c-4c43-223146ba8dd9
    When I click "Submission"

    # Source step 0036: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0037: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-dc50-89c0-3ab623c49625
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0038: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0039: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-b860-f50a-732f772d896b
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0040: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-cfb6-fa95-cdb57fc98bf0
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0041: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-e0fc-c033-7dcc8fee9bd0
    When I click "Signed Homeowners/Rental Owners Change Request"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0042: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-c76a-98bf-a3cc00682f95
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0048: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-7a82-70cf-9ba793ee2be5
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0050: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-833e-14f8-6f34c724a53c
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0051: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-6b11-8c1c-184dae60e025
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0052: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0053: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-8306-c84f-c016bb6e3faa
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    Then "Btn_Transmit_1" should exist
    When I click "Btn_Transmit_1"

    # Source step 0054: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0055: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-4c7b-69a6-38614fa4c09b
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0056: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0057: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-9ab9-3e6b-57e4830ec72b
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "Home_PolicyData_Smoke"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > FirstName" with captured runtime value "FirstName"
    And I use TDM parameter "Data structure > LastName" with captured runtime value "LastName"
    And I use TDM parameter "Data structure > DOB" with captured runtime value "DOB"
    And I use TDM parameter "Data structure > SSN" with captured runtime value "SSN"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0072: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-1808-742e-5eaef88c4d7f
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0073: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-21cc-ad97-ddb37e7fed99
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0020 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0021 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0022 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0025 field "FirstName" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "^[A-Z][a-z]{5}$"
# 5. Source step 0025 field "LastName" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "^[A-Z][a-z]{5}$"
# 6. Source step 0025 field "DOB" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED date from Tosca expression "{DATE[][-37y][MM/dd/yyyy]}"
# 7. Source step 0025 field "SSN" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "254365120][754365120 random digits/characters"
# 8. Source step 0025 field "FullAddress" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED TDM value "Home_TestData_Regression.FullAddress"
# 9. Source step 0025 field "YearOfBuild" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED TDM value "Home_TestData_Regression.YearOfBuild"
# 10. Source step 0025 field "LivingArea" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED TDM value "Home_TestData_Regression.LivingArea"
# 11. Source step 0025 field "MarketValue" in "TBox Set Buffer-PolicyNumber,TCName" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED TDM value "Home_TestData_Regression.MarketValue"
# 12. Source step 0027 field "Btn_New Quote" in "Search for \"Happy Path SH3 - NM\" Policy in EQ" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0037 field "Hdr_Submission Header" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0044 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:13:21 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 15. Source step 0045 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:13:21 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 16. Source step 0046 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 17. Source step 0047 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:13:21 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 18. Source step 0053 field "Btn_Save and Exit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0055 field "Transmit Confirmation Header" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0055 field "Submission" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 21. Source step 0057 field "Data structure > State" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: "NM"
# 22. Source step 0058 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 06.05.24 16:36:31 [ct2452]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "NM"
# 23. Source step 0059 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - INPUT "LOB" with "Home"
#    - INPUT "State" with "NM"
# 24. Source step 0060 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 25. Source step 0061 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 26. Source step 0062 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 27. Source step 0063 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 28. Source step 0064 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 29. Source step 0065 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 30. Source step 0066 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 31. Source step 0067 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 32. Source step 0068 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 33. Source step 0069 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 34. Source step 0070 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 35. Source step 0071 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
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
