# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 056_UW_Rejection_-_Auto_-_Post_-_ALL_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @rejection @Arizona @Edge @manual @archive @automated
Feature: Execute UW Rejection - Auto - Post - ALL for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Rejection - Auto - Post - ALL workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Rejection - Auto - Post - ALL using representative iteration Arizona (AZ)
    # Source step 0009: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-2a16-3dad-256cb680c210
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0010: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-7ede-76a4-0168a51761eb
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0011: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-5146-559e-1c56f985c78b
    When I click "Lnk_Insured Name"
    When I click "Btn_Download XML"

    # Source step 0012: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0014: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-9ff2-79e6-8a19c2f44989
    When I enter or select "^(j)" in "Keys"

    # Source step 0015: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0016: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-951f-ff7b-431beb0af62b
    When I enter or select "\"\"\"\"" in "Keys"

    # Source step 0017: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0018: TBox Save As_1-To Upload the file | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-b2ec-32c3-b2f68ad3729a
    When I enter or select "Save As" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "FilePath"
    When I enter or select "Save" in "Button"

    # Source step 0019: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0020: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-f683-977d-87f42d11e404
    When I enter or select "\"\"" in "Keys"

    # Source step 0021: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0022: Open/Create XML file | Module: Open/Create XML file
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-bb35-9461-3bd350a9dc9f
    When I enter or select "XML" in "Resource"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "Filepath"

    # Source step 0023: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0024: Verify XML | Module: Verify XML
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-78b4-31f4-1b20ee0294c9
    When I use source configuration "Resource" = "XML" for "Verify XML"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"CoverageOptionOverview\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "CoverageOptionOverview"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"IDCard0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "IDCard0180"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoProposal\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoProposal"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoDeclarations0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoDeclarations0180"

    # Source step 0025: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-e425-a618-d1a96e42dff6
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
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ae3-4047-ed38-0dd417d87b32
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
# 4. Source step 0011 field "Lnk_PersonalAuto" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 5. Source step 0013 "Evaluate XPath" in module "Evaluate XPath" was disabled. Reason: 06.12.23 01:10:12 [ct2453]
#    - INPUT "Resource" with a blank value
#    - INPUT "XPathExpression" with a blank value
#    - VERIFY "EvaluationResult" with a blank value
# 6. Source step 0027 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 7. Source step 0028 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 8. Source step 0029 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 9. Source step 0034 field "Lbl_Insured Name" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0035 field "Lbl_Insured Name" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0035 field "Lbl_Insured Name" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 12. Source step 0036 "Client Information Page" in module "EU||Client Information Page" was disabled. Reason: 03.04.24 21:30:42 [ct2451]
#    - WAIT "lnk_PersonalAuto" with "True"
#    - INPUT "lnk_PersonalAuto" with "X"
#    - WAIT "btn_ViewDetailsandHistory" with "True"
# 13. Source step 0040 "EU||Home" in module "EU||Home" was disabled. Reason: 06.12.23 10:36:47 [ct2453]
#    - INPUT "Lnk_Home_Left Navigation Pane" with "X"
#    - INPUT "Btn_Log Out" with "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
