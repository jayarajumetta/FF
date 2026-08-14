# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 160_Mega_Auto_Policy_03_-_ALL_-_PostValidation_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Auto @mega_policy @Arizona @Edge @manual @archive @automated
Feature: Execute Mega Auto Policy 03 - ALL - PostValidation for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Mega Auto Policy 03 - ALL - PostValidation workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Mega Auto Policy 03 - ALL - PostValidation using representative iteration Arizona (AZ)
    # Source step 0009: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-e27c-7b04-df335aba9e5b
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0010: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-82a7-46e2-3b66258c8d45
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"
    When I click "Btn_Download XML"

    # Source step 0011: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0013: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-56bc-a387-18855ef1fb1c
    When I enter or select "^(j)" in "Keys"

    # Source step 0014: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0015: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-04f5-dde8-47f6461ac448
    When I enter or select "\"\"\"\"" in "Keys"

    # Source step 0016: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0017: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-c0fb-7740-efbe5c5bb19e
    When I retain hard-coded value "Mega Auto Policy 03-AZ" as runtime value "TCName"

    # Source step 0018: TBox Save As_1-To Upload the file | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-e220-b6e3-84507fd4b52c
    When I enter or select "Save As" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "FilePath"
    When I enter or select "Save" in "Button"

    # Source step 0019: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0020: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-cb07-79a3-5b22343358e5
    When I enter or select "\"\"" in "Keys"

    # Source step 0021: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0022: Open/Create XML file | Module: Open/Create XML file
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-c5a5-d77a-78ca62821a2e
    When I enter or select "XML" in "Resource"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "Filepath"

    # Source step 0023: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0024: Verify XML | Module: Verify XML
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-3f03-918f-6b7f90077aca
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

    # Source step 0025: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-9a5b-68bb-dbe143d501e3
    When I close the active browser

    # Source step 0026: OpenUrl | Module: OpenUrl
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0030: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0031: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3cb-cabb-d113-c74e9efe7ff4
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Alias name (item)" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Data search filter > State" with "NM"
    And I use TDM parameter "Data search filter > Veh Type" with "Auto"
    And I use TDM parameter "Data search filter > NB/RB" with "NB"
    And I use TDM parameter "Data search filter > Company" with the unresolved source parameter "Company" (not supplied by this reusable-block invocation)
    And I use TDM parameter "Data search filter > LOB" with the unresolved source parameter "Lob" (not supplied by this reusable-block invocation)

    # Source step 0032: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3cb-7230-4228-424cacf0ed3b
    When I retrieve and retain the RUNTIME-DERIVED TDM value "RateEffectiveDate_Reference.Rate Effective Date" as runtime value "Expected_RateEffectiveDate"

    # Source step 0033: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3cb-a97b-65e5-5ec09a8db8e1
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0034: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3cb-1eb1-370c-cb1d39765e45
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0035: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3cb-995d-177c-d93ed3fb4069
    When I click "Lnk_Insured Name"
    Then I wait until "Lnk_PersonalAuto" exists
    When I click "Lnk_PersonalAuto"

    # Source step 0037: EU||Transact | Module: EU||Transact
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3cb-d13c-00cc-cf04cb019e9f
    Then I wait until "Btn_ViewPolicy" is visible
    When I click "Btn_ViewPolicy"

    # Source step 0038: EU||Applicant | Module: EU||Applicant
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3da-4ba5-76ab-806793de999f
    When I click "LNK_PolicyTerm"

    # Source step 0039: EU||Policy Term-Verify Rate Date/Rate Effective Date | Module: EU||Policy Term
    # Section: Process | Reusable flow: Common | Express|Verify Rate Effective Date | Source XTestStep: 3a19dd55-d3da-24a6-e08a-32a5d3fe4c48
    When I capture "InnerText" from "lbl_RateDate_Value" as runtime value "ActualRateDate"
    Then "lbl_RateDate_Value" should equal captured runtime value "Expected_RateEffectiveDate"

    # Source step 0041: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3f75-28aa-930c-8b270aecd9f8
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
# 5. Source step 0027 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 6. Source step 0028 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 7. Source step 0029 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 8. Source step 0034 field "Lbl_Insured Name" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0035 field "Lbl_Insured Name" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0035 field "Lbl_Insured Name" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 11. Source step 0036 "Client Information Page" in module "EU||Client Information Page" was disabled. Reason: 03.04.24 21:30:42 [ct2451]
#    - WAIT "lnk_PersonalAuto" with "True"
#    - INPUT "lnk_PersonalAuto" with "X"
#    - WAIT "btn_ViewDetailsandHistory" with "True"
# 12. Source step 0040 "EU||Home" in module "EU||Home" was disabled. Reason: 06.12.23 10:36:47 [ct2453]
#    - INPUT "Lnk_Home_Left Navigation Pane" with "X"
#    - INPUT "Btn_Log Out" with "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, Close browser
# 1. Source recovery step 0042 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\PostValidations\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0043 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, Close browser
# 3. Source recovery step 0044 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\PostValidations\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 4. Source recovery step 0045 CloseBrowser: I close the active browser
