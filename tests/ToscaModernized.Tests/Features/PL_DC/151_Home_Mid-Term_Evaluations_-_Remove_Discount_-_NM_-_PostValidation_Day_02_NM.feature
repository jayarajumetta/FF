# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 151_Home_Mid-Term_Evaluations_-_Remove_Discount_-_NM_-_PostValidation_Day_02_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @post_validation @New_Mexico @Edge @manual @archive @automated
Feature: Execute Home Mid-Term Evaluations - Remove Discount - NM - PostValidation Day 02 for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Mid-Term Evaluations - Remove Discount - NM - PostValidation Day 02 workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Mid-Term Evaluations - Remove Discount - NM - PostValidation Day 02 using representative iteration New Mexico (NM)
    # Source step 0015: EU||Login | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-68ab-d016-1ad8f3e957c9
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0016: EU||Home-Navigate to TransACT page | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-5c40-2004-4c9550b92977
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"
    When I click "Lnk_Home"

    # Source step 0017: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0018: EU||TransACT(Home-Endorse)-Navigate to ViewPolicy page | Module: EU||TransACT(Home-Endorse)
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-c33c-3247-805aef638311
    When I click "Btn_View Policy_Endorse"

    # Source step 0019: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0020: EU||Applicant-Navigate to Discounts page | Module: EU||Applicant
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-f9fb-cb18-bcb20718154b
    When I click "Lnk__Discounts"

    # Source step 0021: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0022: EU||Discounts(Home-Endorse)-Capture Auto-Home Discount on Day 02 | Module: EU||Discounts(Home-Endorse)
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-8fff-cc4d-f0d1fbe4d7ba
    Then I wait until "Lbl_Auto-Home Discount" is visible
    When I capture "Value" from "Txt_Auto-Home Discount" as runtime value "Auto-Home Discount Value Day02"
    Then "Lbl_Three-Line Discount" should exist

    # Source step 0023: Take Screenshot of the EU Discounts page | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-c396-b350-b8b4dd6514e2
    When I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\{B[TCName]}_EU Discounts Page_{DATE[][][MM/dd/yyyy]}_{TIME}"

    # Source step 0024: Verifying that Auto-Home Discount is dropped/removed on Day 02[value should be NO] | Module: TBox Partial Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-f39b-9ab8-e815e21f3ea7
    When I derive runtime buffer "Auto-Home Discount Value Day02" from "No"

    # Source step 0025: EU||Discounts-Log out of the Policy/EU | Module: EU||Discounts(Home-New Business)
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-8902-421a-3e1823120b15
    When I click "Btn_Log Out"

    # Source step 0026: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-daa0-6ed9-eea986f7b656
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0009 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0010 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0011 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EU log out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0002 EU||Discounts-Log out of the Policy/EU: I click "Btn_Log Out"
# 3. Source recovery step 0003 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EU log out and Close browser
# 4. Source recovery step 0004 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\{B[TCName]}_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 5. Source recovery step 0005 EU||Discounts-Log out of the Policy/EU: I click "Btn_Log Out"
# 6. Source recovery step 0006 CloseBrowser: I close the active browser
