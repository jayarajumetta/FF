# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 167_Mega_Rec_Veh_Policy_02_-_ALL_-_PostValidation_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @RV @mega_policy @Arizona @Edge @manual @archive @automated
Feature: Execute Mega Rec Veh Policy 02 - ALL - PostValidation for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Mega Rec Veh Policy 02 - ALL - PostValidation workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Mega Rec Veh Policy 02 - ALL - PostValidation using representative iteration Arizona (AZ)
    # Source step 0009: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-c1cf-242f-19cd7c75bcfc
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0010: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-8eef-1bd0-d10e18afb403
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"
    When I click "Btn_Download XML"

    # Source step 0011: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0013: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-c6d6-c119-001174a9b269
    When I enter or select "^(j)" in "Keys"

    # Source step 0014: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0015: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-dd26-f7db-01c801800f70
    When I enter or select "\"\"\"\"" in "Keys"

    # Source step 0016: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0017: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-e65d-60d0-9ee9cbee2433
    When I retain hard-coded value "Mega Rec Veh Policy 02-AZ" as runtime value "TCName"

    # Source step 0018: TBox Save As_1-To Upload the file | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-6fbb-44ef-150767982a84
    When I enter or select "Save As" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "FilePath"
    When I enter or select "Save" in "Button"

    # Source step 0019: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0020: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-45ee-1471-abe5baaa7977
    When I enter or select "\"\"" in "Keys"

    # Source step 0021: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0022: Open/Create XML file | Module: Open/Create XML file
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-d1ed-44f6-b9d62aa3f4fd
    When I enter or select "XML" in "Resource"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "Filepath"

    # Source step 0023: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0024: Verify XML | Module: Verify XML
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-eece-4557-5fbc971de2e1
    When I use source configuration "Resource" = "XML" for "Verify XML"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"CoverageOptionOverview\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "CoverageOptionOverview"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"IDCard0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "IDCard0180"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoProposal\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoProposal"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoTempIDNewMexico0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoTempIDNewMexico0180"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoDeclarations0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoDeclarations0180"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"NM1580618\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "NM1580618"

    # Source step 0025: OpenUrl | Module: OpenUrl_old
    # Section: Process > Express|Verify Rate Effective Date > Open URL | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-2eaa-96ee-b54f85202dd0
    When I open "https://dcpqa.dnanico1.aniconet.com/express/express.aspx#/me/express/defaultViewmodel"

    # Source step 0026: TBox Wait | Module: TBox Wait
    # Section: Process > Express|Verify Rate Effective Date > Wait | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-39a3-05c1-1407f45d9c7e
    When I wait "3000" milliseconds

    # Source step 0027: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-8878-6ebb-f0b7510610a4
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Alias name (item)" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Data search filter > State" with "AZ"
    And I use TDM parameter "Data search filter > Veh Type" with "RV"
    And I use TDM parameter "Data search filter > NB/RB" with "NB"
    And I use TDM parameter "Data search filter > Company" with "ANPAC"

    # Source step 0028: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-8d72-37b9-fa663a9e8b0f
    When I retrieve and retain the RUNTIME-DERIVED TDM value "RateEffectiveDate_Reference.Rate Effective Date" as runtime value "Expected_RateEffectiveDate"

    # Source step 0029: EU||Login | Module: EU||Login
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-50de-30a9-b4a70a07f807
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0030: EU||Home | Module: EU||Home
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-335c-a583-847e8f0fe8b4
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"

    # Source step 0031: Client Information Page | Module: EU||Client Information Page
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-fa44-ea92-55efae1f33d2
    When I click "lnk_RecVehicle"
    Then I wait until "btn_ViewDetailsandHistory" is visible

    # Source step 0032: EU||Transact | Module: EU||Transact
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-1475-d61c-5536af11b23e
    Then I wait until "Btn_ViewPolicy" is visible
    When I click "Btn_ViewPolicy"

    # Source step 0033: EU||Applicant | Module: EU||Applicant
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-f738-dbb8-5c57f72ff94e
    When I click "LNK_PolicyTerm"

    # Source step 0034: EU||Policy Term | Module: EU||Policy Term
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-5016-6d95-e3ce64bc2afd
    When I capture "InnerText" from "lbl_RateDate_Value" as runtime value "ActualRateDate"
    Then "lbl_RateDate_Value" should equal captured runtime value "Expected_RateEffectiveDate"

    # Source step 0036: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4063-01b4-308d-d1b1177202c3
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0003 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0004 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0005 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0012 "Evaluate XPath" in module "Evaluate XPath" was disabled. Reason: 06.12.23 01:10:12 [ct2453]
#    - INPUT "Resource" with a blank value
#    - INPUT "XPathExpression" with a blank value
#    - VERIFY "EvaluationResult" with a blank value
# 5. Source step 0035 "EU||Home" in module "EU||Home" was disabled. Reason: 06.12.23 10:36:47 [ct2453]
#    - INPUT "Lnk_Home_Left Navigation Pane" with "X"
#    - INPUT "Btn_Log Out" with "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, Close browser
# 1. Source recovery step 0037 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\PostValidations\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0038 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, Close browser
# 3. Source recovery step 0039 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\PostValidations\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 4. Source recovery step 0040 CloseBrowser: I close the active browser
