# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 061_UW_Cancellation_-_Recreational_-_Post_-_ALL_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Cycle @cancellation @Arizona @Edge @manual @archive @automated
Feature: Execute UW Cancellation - Recreational - Post -  ALL for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the UW Cancellation - Recreational - Post -  ALL workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UW Cancellation - Recreational - Post -  ALL using representative iteration Arizona (AZ)
    # Source step 0009: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-807d-14a9-e9473baaa8ea
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0010: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-2873-6a32-b50edfaab185
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0012: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-c2f8-5f42-47fa78da245b
    When I click "Lnk_Insured Name"
    When I click "Btn_Download XML"

    # Source step 0013: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0015: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-66fc-39f6-8ad1957b2bd8
    When I enter or select "^(j)" in "Keys"

    # Source step 0016: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0017: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-d2f0-3a41-c4d3a2b0165e
    When I enter or select "\"\"\"\"" in "Keys"

    # Source step 0018: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0019: TBox Save As_1-To Upload the file | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-6015-5ffc-8469881122b3
    When I enter or select "Save As" in "Caption"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "FilePath"
    When I enter or select "Save" in "Button"

    # Source step 0020: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0021: TBox Send Keys | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-a358-3fd1-baf7686bb078
    When I enter or select "\"\"" in "Keys"

    # Source step 0022: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0023: Open/Create XML file | Module: Open/Create XML file
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-a59a-0bd0-d194cfead219
    When I enter or select "XML" in "Resource"
    When I enter the RUNTIME-DERIVED buffer expression "\\\\fs1\\public\\Tosca\\PL DC Automation\\XML\\{B[TCName]}_{B[Policy]}.xml" in "Filepath"

    # Source step 0024: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0025: Verify XML | Module: Verify XML
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-a143-a538-07590d121d11
    When I use source configuration "Resource" = "XML" for "Verify XML"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"CoverageOptionOverview\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "CoverageOptionOverview"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"IDCard0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "IDCard0180"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoProposal\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoProposal"
    When I use source configuration "XPath" = "//FormNumber[text()=\"\"AutoDeclarations0180\"\"]" for "Verify XML"
    Then "XPath > Value" should equal "AutoDeclarations0180"

    # Source step 0026: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-8cd1-13d1-a6c37feaa35a
    When I close the active browser

    # Source step 0041: OpenUrl | Module: OpenUrl
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0045: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0046: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-6ad5-8b6d-770577295bdb
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Alias name (item)" with "RateEffectiveDate_Reference"
    And I use TDM parameter "Data search filter > State" with "AZ"
    And I use TDM parameter "Data search filter > Veh Type" with "RV"
    And I use TDM parameter "Data search filter > NB/RB" with "NB"
    And I use TDM parameter "Data search filter > Company" with the unresolved source parameter "Company" (not supplied by this reusable-block invocation)
    And I use TDM parameter "Data search filter > LOB" with "Auto"

    # Source step 0047: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-a663-1c34-4f0d64ee2e2c
    When I retrieve and retain the RUNTIME-DERIVED TDM value "RateEffectiveDate_Reference.Rate Effective Date" as runtime value "Expected_RateEffectiveDate"

    # Source step 0048: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-6aaa-214b-e53739a81a23
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0049: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-bbd4-d30b-c4461cd1ba03
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0050: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-5431-0ed2-da3e75b7eb61
    When I click "Lnk_Insured Name"
    When I click "Lnk_RV"

    # Source step 0052: EU||Transact | Module: EU||Transact
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-5ba3-92a0-23dccd618f5c
    Then I wait until "Btn_ViewPolicy" is visible
    When I click "Btn_ViewPolicy"

    # Source step 0053: EU||Applicant | Module: EU||Applicant
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-a518-6768-a6a55541217e
    When I click "LNK_PolicyTerm"

    # Source step 0054: EU||Policy Term-Verify Rate Date/Rate Effective Date | Module: EU||Policy Term
    # Section: Process | Reusable flow: RV | Express|Verify Rate Effective Date  | Source XTestStep: 3a19dd55-d425-315c-5ac5-a38c22135c94
    When I capture "InnerText" from "lbl_RateDate_Value" as runtime value "ActualRateDate"
    Then "lbl_RateDate_Value" should equal captured runtime value "Expected_RateEffectiveDate"

    # Source step 0056: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3b71-b265-cd92-ec98ebc6566c
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
# 4. Source step 0011 "EU||Home" in module "EU||Home" was disabled. Reason: 29.05.24 19:12:21 [ct2634]
#    - INPUT "Txt_Search Text" with the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber"
#    - INPUT "Btn_Search" with "X"
#    - INPUT "Lbl_Insured Name" with "X"
#    - INPUT "Lnk_Policyholder_name" with "X"
#    - INPUT "Btn_Download XML" with "X"
# 5. Source step 0012 field "Lnk_PersonalAuto" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0014 "Evaluate XPath" in module "Evaluate XPath" was disabled. Reason: 06.12.23 01:10:12 [ct2453]
#    - INPUT "Resource" with a blank value
#    - INPUT "XPathExpression" with a blank value
#    - VERIFY "EvaluationResult" with a blank value
# 7. Source step 0027 "OpenUrl" in module "OpenUrl" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 8. Source step 0028 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 9. Source step 0029 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 10. Source step 0030 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 11. Source step 0031 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Duration" with "3000"
# 12. Source step 0032 "TestData - Find & provide item" in module "Old_TestData - Find & provide item" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TestCaseName" with "Mega Auto Policy 01 - NM"
#    - INPUT "Data search filter > State" with "NM"
#    - INPUT "Data search filter > LOB" with "Auto"
# 13. Source step 0033 "TBox Set Buffer" in module "TBox Set Buffer" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 14. Source step 0034 "EU||Login" in module "EU||Login" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "X"
# 15. Source step 0035 "EU||Home" in module "EU||Home" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Txt_Search Text" with the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber"
#    - INPUT "Btn_Search" with "X"
# 16. Source step 0036 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Lnk_Insured Name" with "X"
#    - INPUT "Lnk_PersonalAuto" with "X"
#    - INPUT "Btn_Download XML" with "X"
# 17. Source step 0037 "EU||Home" in module "EU||Home" was disabled. Reason: 04.04.24 09:51:35 [ct2452]
#    - INPUT "Txt_Search Text" with the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber"
#    - INPUT "Btn_Search" with "X"
#    - INPUT "Lbl_Insured Name" with "X"
#    - INPUT "Lnk_Policyholder_name" with "X"
# 18. Source step 0038 "Client Information Page" in module "EU||Client Information Page" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - WAIT "lnk_PersonalAuto" with "True"
#    - INPUT "lnk_PersonalAuto" with "X"
#    - WAIT "btn_ViewDetailsandHistory" with "True"
# 19. Source step 0039 "EU||Transact - Verify Premium Value" in module "EU||Transact" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - WAIT "Btn_ViewPolicy" with "True"
#    - INPUT "Btn_ViewPolicy" with "X"
#    - BUFFER "Txt_New Premium" with "Premium"
#    - VERIFY "Txt_New Premium" with captured runtime value "Expected_ValidatedPremium"
# 20. Source step 0040 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 29.05.24 19:19:11 [ct2634]
#    - INPUT "Title" with "*"
# 21. Source step 0042 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 22. Source step 0043 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 23. Source step 0044 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 24. Source step 0049 field "Lbl_Insured Name" in "EU||Home" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0050 field "Lbl_Insured Name" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0050 field "Lbl_Insured Name" in "EU|Home" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 27. Source step 0051 "Client Information Page" in module "EU||Client Information Page" was disabled. Reason: 03.04.24 21:30:42 [ct2451]
#    - WAIT "lnk_PersonalAuto" with "True"
#    - INPUT "lnk_PersonalAuto" with "X"
#    - WAIT "btn_ViewDetailsandHistory" with "True"
# 28. Source step 0055 "EU||Home" in module "EU||Home" was disabled. Reason: 06.12.23 10:36:47 [ct2453]
#    - INPUT "Lnk_Home_Left Navigation Pane" with "X"
#    - INPUT "Btn_Log Out" with "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
