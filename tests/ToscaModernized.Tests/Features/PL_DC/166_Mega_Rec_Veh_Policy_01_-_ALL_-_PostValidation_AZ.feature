# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 166_Mega_Rec_Veh_Policy_01_-_ALL_-_PostValidation_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @RV @mega_policy @Arizona @Edge @manual @archive @automated
Feature: Execute Mega Rec Veh Policy 01 - ALL - PostValidation for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Mega Rec Veh Policy 01 - ALL - PostValidation workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Mega Rec Veh Policy 01 - ALL - PostValidation using representative iteration Arizona (AZ)
    # Source step 0009: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-1a5a-0d6c-db865ceba909
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0010: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-03f5-edab-f9b74055e37f
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"
    When I click "Btn_Download XML"

    # Source step 0011: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0013: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-b23e-832d-51fdc34cf0c3
    When I enter or select "^(j)" in "Keys"

    # Source step 0014: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0015: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-0d4f-d45b-82eb4e2e9f92
    When I enter or select "\"\"\"\"" in "Keys"

    # Source step 0016: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0017: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-9c88-d867-d09eb19330fe
    When I retain hard-coded value "Mega Rec Veh Policy 01-AZ" as runtime value "TCName"

    # Source step 0018: TBox Save As_1-To Upload the file | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-5d7e-2916-f8da168a0614
    When I enter or select "Save As" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "FilePath"
    When I enter or select "Save" in "Button"

    # Source step 0019: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0020: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-c4f0-4381-467b21a69652
    When I enter or select "\"\"" in "Keys"

    # Source step 0021: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0022: Open/Create XML file | Module: Open/Create XML file
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-197e-eca9-71ad6c367e27
    When I enter or select "XML" in "Resource"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "Filepath"

    # Source step 0023: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0024: Verify XML | Module: Verify XML
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-2c03-7818-82ff671d802f
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
    # Section: Process > Express|Verify Rate Effective Date > Open URL | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-f3f7-f3c3-1d4c6222f134
    When I open "https://dcpqa.dnanico1.aniconet.com/express/express.aspx#/me/express/defaultViewmodel"

    # Source step 0026: TBox Wait | Module: TBox Wait
    # Section: Process > Express|Verify Rate Effective Date > Wait | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-c7b1-b75a-deb5cda49087
    When I wait "3000" milliseconds

    # Source step 0027: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-451b-cb77-9fd6aeceec30
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Alias name (item)" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Data search filter > State" with "AZ"
    And I use TDM parameter "Data search filter > Veh Type" with "RV"
    And I use TDM parameter "Data search filter > NB/RB" with "NB"
    And I use TDM parameter "Data search filter > Company" with "ANPAC"

    # Source step 0028: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-1d34-cbad-216b89f85764
    When I retrieve and retain the RUNTIME-DERIVED TDM value "RateEffectiveDate_Reference.Rate Effective Date" as runtime value "Expected_RateEffectiveDate"

    # Source step 0029: EU||Login | Module: EU||Login
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-e75a-14e5-7d7692bf4a86
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0030: EU||Home | Module: EU||Home
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-c9d8-aed0-1cdbcd94149e
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"

    # Source step 0031: Client Information Page | Module: EU||Client Information Page
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-f1a5-7d9a-5cae1c2241a7
    When I click "lnk_RecVehicle"
    Then I wait until "btn_ViewDetailsandHistory" is visible

    # Source step 0032: EU||Transact | Module: EU||Transact
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-3283-3a21-c62bb9ac530a
    Then I wait until "Btn_ViewPolicy" is visible
    When I click "Btn_ViewPolicy"

    # Source step 0033: EU||Applicant | Module: EU||Applicant
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-e2d8-5148-2399256fe156
    When I click "LNK_PolicyTerm"

    # Source step 0034: EU||Policy Term | Module: EU||Policy Term
    # Section: Process > Express|Verify Rate Effective Date | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-2aba-48de-81c370f0015a
    When I capture "InnerText" from "lbl_RateDate_Value" as runtime value "ActualRateDate"
    Then "lbl_RateDate_Value" should equal captured runtime value "Expected_RateEffectiveDate"

    # Source step 0036: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-4042-8daa-1eb4-125e2342b8d3
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
