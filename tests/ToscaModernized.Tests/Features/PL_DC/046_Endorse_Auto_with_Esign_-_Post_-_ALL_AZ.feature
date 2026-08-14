# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 046_Endorse_Auto_with_Esign_-_Post_-_ALL_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @endorsement @Arizona @Edge @manual @archive @automated
Feature: Execute Endorse Auto with Esign - Post - ALL for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Endorse Auto with Esign - Post - ALL workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Endorse Auto with Esign - Post - ALL using representative iteration Arizona (AZ)
    # Source step 0009: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39f7-42b1-c773-41ea651b1ccd
    When I enter or select "CT2628" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0011: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39f7-e6be-f5ce-f101298bc3a9
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0012: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39f7-16a0-c8df-738c8a8e2ff5
    When I click "Lnk_Insured Name"
    When I click "Btn_Download XML"

    # Source step 0013: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0015: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39f7-5562-4629-d164bc0a1d92
    When I enter or select "^(j)" in "Keys"

    # Source step 0016: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0017: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39f7-475e-ab1a-90abd4ca64f1
    When I enter or select "\"\"\"\"" in "Keys"

    # Source step 0018: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0019: TBox Save As_1-To Upload the file | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-39f7-63f4-12ac-b63e06f29211
    When I enter or select "Save As" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "FilePath"
    When I enter or select "Save" in "Button"

    # Source step 0020: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0021: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3a07-d924-1538-ef7ce5338d95
    When I enter or select "\"\"" in "Keys"

    # Source step 0022: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0023: Open/Create XML file | Module: Open/Create XML file
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3a07-06ae-a188-2d5c508dbf0a
    When I enter or select "XML" in "Resource"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "Filepath"

    # Source step 0024: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0025: Verify XML | Module: Verify XML
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3a07-fc06-5d97-4977bab08f90
    When I use source configuration "Resource" = "XML" for "Verify XML"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"CoverageOptionOverview\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "CoverageOptionOverview"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"IDCard0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "IDCard0180"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoProposal\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoProposal"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoDeclarations0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoDeclarations0180"

    # Source step 0027: CloseBrowser | Module: CloseBrowser
    # Section:  Post condition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3a07-5a0c-a0fb-3e1c0211079c
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
# 4. Source step 0010 "EU||Home" in module "EU||Home" was disabled. Reason: 21.05.24 17:49:56 [ct2634]
#    - INPUT "Txt_Search Text" with the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber"
#    - INPUT "Btn_Search" with "X"
#    - INPUT "Lbl_Insured Name" with "X"
#    - INPUT "Lnk_Policyholder_name" with "X"
#    - INPUT "Lnk_PolicyHolderName_Cycle" with "X"
#    - INPUT "Btn_Download XML" with "X"
# 5. Source step 0012 field "Lnk_PersonalAuto" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0014 "Evaluate XPath" in module "Evaluate XPath" was disabled. Reason: 06.12.23 01:10:12 [ct2453]
#    - INPUT "Resource" with a blank value
#    - INPUT "XPathExpression" with a blank value
#    - VERIFY "EvaluationResult" with a blank value
# 7. Source step 0026 "EU||Home" in module "EU||Home" was disabled. Reason: 06.12.23 10:36:47 [ct2453]
#    - INPUT "Lnk_Home_Left Navigation Pane" with "X"
#    - INPUT "Btn_Log Out" with "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
