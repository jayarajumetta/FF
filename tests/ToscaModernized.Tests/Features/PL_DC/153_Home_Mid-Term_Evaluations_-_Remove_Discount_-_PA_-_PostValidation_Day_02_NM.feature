# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 153_Home_Mid-Term_Evaluations_-_Remove_Discount_-_PA_-_PostValidation_Day_02_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @post_validation @New_Mexico @Edge @manual @archive @automated
Feature: Execute Home Mid-Term Evaluations - Remove Discount - PA - PostValidation Day 02 for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Mid-Term Evaluations - Remove Discount - PA - PostValidation Day 02 workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Mid-Term Evaluations - Remove Discount - PA - PostValidation Day 02 using representative iteration New Mexico (NM)
    # Source step 0021: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Logging for ExpressUI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-6685-f9d7-1ec6fef4f4eb
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Given if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0022: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Logging for ExpressUI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-3c19-b292-159972ae8b60
    # Runtime control: If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0023: Search Policy in Express | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-ee47-a8ff-2608408f1854
    When I enter or select "\"^{a}\"" in "Txt_Search Text"
    When I enter the RUNTIME-DERIVED TDM value "Regression_Temp_Data.PolicyNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0024: Check LOB | Module: TBox Set Buffer
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-0363-2851-5d970305dacd
    # Runtime control: If LOB is Home > Condition
    When if the source runtime condition "If LOB is Home > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0025: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-2c63-6974-84252b430a1f
    # Runtime control: If LOB is Home > Then
    When if the source runtime condition "If LOB is Home > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Home"

    # Source step 0026: Check LOB | Module: TBox Set Buffer
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-e117-ccae-4e1b9110c55a
    # Runtime control: If LOB is ROP > Condition
    When if the source runtime condition "If LOB is ROP > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0027: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-e860-050f-78d1cfaa784f
    # Runtime control: If LOB is ROP > Then
    When if the source runtime condition "If LOB is ROP > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_ROP"

    # Source step 0028: Check LOB | Module: TBox Set Buffer
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-123a-fe5b-1741b10883d2
    # Runtime control: If LOB is RV > Condition
    When if the source runtime condition "If LOB is RV > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0029: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-6eb1-8963-b597fdd7bbb9
    # Runtime control: If LOB is RV > Then
    When if the source runtime condition "If LOB is RV > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_RV"

    # Source step 0030: Check LOB | Module: TBox Set Buffer
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-4491-a331-5e69a7936e6a
    # Runtime control: If LOB is PersonalAuto > Condition
    When if the source runtime condition "If LOB is PersonalAuto > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0031: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-890d-fbbe-e00ff2910cb7
    # Runtime control: If LOB is PersonalAuto > Then
    When if the source runtime condition "If LOB is PersonalAuto > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_PersonalAuto"

    # Source step 0032: Check LOB | Module: TBox Set Buffer
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-b0c3-adf2-2c1369b8f9a6
    # Runtime control: If LOB is Motorcycle > Condition
    When if the source runtime condition "If LOB is Motorcycle > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB"

    # Source step 0033: Navigate to Policy Insured & LOB | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Navigate to Policy Insured and LOB | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-fe32-f9fa-c76172e3b249
    # Runtime control: If LOB is Motorcycle > Then
    When if the source runtime condition "If LOB is Motorcycle > Then" is satisfied, I click "Lnk_Insured Name"
    When I click "Lnk_Motorcycle"

    # Source step 0034: Click on View policy | Module: EU||Transact
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-a152-acb9-74a4bfd5bb43
    Then I wait until "Btn_ViewPolicy" exists
    When I click "Btn_ViewPolicy"

    # Source step 0035: EU||Applicant-Navigate to Discounts page | Module: EU||Applicant
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-49ee-4573-f64c9c624e0d
    When I click "Lnk__Discounts"

    # Source step 0036: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0037: EU||Discounts(Home-Endorse)-Capture Auto-Home Discount on Day 02 | Module: EU||Discounts(Home-Endorse)
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-f7c0-0319-16f7f13d7eae
    Then I wait until "Lbl_Auto-Home Discount" is visible
    When I capture "Value" from "Txt_Auto-Home Discount" as runtime value "Auto-Home Discount Value Day02"
    Then "Lbl_Three-Line Discount" should exist

    # Source step 0038: Take Screenshot of the EU Discounts page | Module: TBox Take Screenshot
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-c0c0-cb1d-d68ef1b9c0cc
    When I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Home\\{B[TCName]}_EU Discounts Page_{DATE[][][MM/dd/yyyy]}_{TIME}"

    # Source step 0039: Verifying that Auto-Home Discount is dropped/removed on Day 02[value should be NO] | Module: TBox Partial Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-1079-d2a4-d36654915fea
    When I derive runtime buffer "Auto-Home Discount Value Day02" from "No"

    # Source step 0040: EU||Discounts-Log out of the Policy/EU | Module: EU||Discounts(Home-New Business)
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-b388-1d6f-fe7d2d9e8af7
    When I click "Btn_Log Out"

    # Source step 0041: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cbe-812e-8c0a-818b261ac914
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0015 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0016 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0017 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
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
