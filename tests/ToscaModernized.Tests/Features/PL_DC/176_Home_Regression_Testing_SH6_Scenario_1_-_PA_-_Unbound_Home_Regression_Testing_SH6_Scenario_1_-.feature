# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 176_Home_Regression_Testing_SH6_Scenario_1_-_PA_-_Unbound_Home_Regression_Testing_SH6_Scenario_1_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH6 Scenario #1 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH6 Scenario #1 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH6 Scenario #1 - PA - Unbound using representative iteration Home Regression Testing SH6 Scenario #1 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-eb02-1079-411d277af4b1
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-3a2b-933e-5f4b1a6baf5d
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-7cc2-1668-f54c13543d6c
    Then I wait until "<unnamed value>" exists
    When I enter captured runtime value "FirstName" in "<unnamed value>"
    When I enter captured runtime value "LastName" in "<unnamed value>"
    When I enter captured runtime value "DOB" in "<unnamed value>"
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    Then "<unnamed value>" should be visible
    Then "<unnamed value>" should be visible
    When I click "<unnamed value>"

    # Source step 0028: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-8814-1290-e5a85c1b071a
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "5000000000" in "<unnamed value>"
    When I enter or select "injskas@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "220 Savannah Dr STE 202, Gettysburg, PA 17325" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I enter or select "2002" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-4f59-0560-3665f3df6fa8
    Then I wait until "Btn_PERSONAL AUTO" is visible
    Then I wait until "Btn_MOTORCYCLE" is visible
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then "Btn_SH3-HOMEOWNERS" should be visible
    Then "Btn_SH4-TENANTS" should be visible
    When I click "Btn_SH6-CONDOMINIUM OWNERS"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_SD1-RENTAL OWNERS"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][+3M][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_PENNSYLVANIA"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0030: Verify that Invalid address pop up is shown  | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-f3de-728c-c3f81d838275
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-2ebc-b378-69b691fea8c9
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-5763-7cd0-b9bf2ca58e1b
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-d0ed-d4d4-382b3a61f18a
    Then I wait until "Lbl_Client Eligibility Restrictions" is visible
    Then I wait until "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) WITH FELONY CONVICTION" exists
    Then "Btn_NO VALID SSN FOR ACCOUNT OWNER" should exist
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    Then "Lbl_Property Eligibility Restrictions" should exist
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_MORE THAN 2 UNITS"
    Then "Btn_SINGLE WIDE MANUFACTURED HOME" should exist
    Then "Btn_MANUFACTURED HOME CONSTRUCTED PRIOR TO 1994" should exist
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0035: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-ebde-81e7-7605af2dc8fb
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0036: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-91ad-b9ac-905805a424ed
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0037: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-3f89-53fb-9e78f124a59b
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    When I enter or select "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Phone Type"
    Then "Lbl_Email Type" should exist
    Then "Lbl_Gender" should exist
    When I click "Btn_Male"
    Then "Btn_Female" should exist
    Then I wait until "Lbl_Marital Status" is visible
    Then I wait until "Btn_Single" is visible
    Then "Lbl_Relation To Account Owner" should be visible
    Then "Btn_Daughter" should exist
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0038: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-5ed1-5d44-48b3d915f9ae
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0040: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-1428-3228-e27aeb554c1f
    Then I wait until "Location Header" exists
    Then "Lbl_How long have you owned or occupied location?" should exist
    When I click "Btn_More than 5 years"
    Then "Btn_More than 5 years" should exist
    When I enter or select "{SCROLL[12][1000px][None][HorizontalFirst][300ms]}" in "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"

    # Source step 0041: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0042: EQH||Location-till feet to hydrant | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-534d-0050-181afba96f72
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0044: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-65de-7c8d-21fbfc4c3dcb
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0045: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-3a36-cab5-6c26b7040341
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0047: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-8dd2-eb3d-419ad4e2cb5a
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0048: EQH||Home Characteristics_SH6-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH6
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-3317-d2fa-a6965fcc1bd4
    Then I wait until "Home Characteristics_Header" is visible
    Then I wait until "Txt_Years Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "2011" in "Txt_Years Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "2258" in "Txt_Total Living Area"
    Then "Lbl_Roof Type" should exist
    When I click "Shingles, Architectural"
    Then "Lbl_# of Apts. Between Firewalls" should exist
    When I click "5 - 99 Units"
    When I enter or select "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Home Type"
    When I click "Conventional"
    Then "Lbl_Is Principal Heating System Thermostatically Controlled ?" should exist
    When I select "Yes"
    When I click "Btn_Get Valuation"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0050: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-1541-f0cf-2bb092d1c903
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0051: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-1f93-adf6-1b1990745d3c
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0052: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-5301-7c78-956004be8ad2
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0053: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-36c9-6e2e-22fe3972873f
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0054: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-1fb9-3d7e-08df651a3d6b
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0056: EQH||Home Characteristics_SH6-Property Information and Heating details | Module: EQH||Home Characteristics_SH6
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-437d-056b-713ddbef8f69
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Home Type"
    Then "Lbl_Construction Type" should be visible
    When I click "Frame"
    When I click "Tenant"
    When I select "Btn_Condominium rented to others_Yes"
    When I click "< 6 Months"
    When I click "Btn_Principal Heat_Central"
    When I click "Btn_Supplemental Heat_Floor Furnace"
    When I click "Btn_Home Characteristics_Next"

    # Source step 0057: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "4000" milliseconds

    # Source step 0058: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-15a0-b77e-2e58c0c29836
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0059: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-adcc-a7ed-71f5830272ab
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0060: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-b384-00c5-e72a2f2ff822
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I enter or select "PGDN" in "Lbl_Dog Exposures"
    When I enter or select "PGDN" in "Lbl_Business Details"
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"
    When I enter or select "PGDN" in "Lbl_Farm & Livestock Exposures"

    # Source step 0061: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0062: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-ffc0-1bc1-c0f5976566c0
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0063: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-3110-4c8b-2b3deeb5022d
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0064: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-d521-8296-76e4c979a133
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0066: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-455d-7f6c-0325eee9be03
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Btn_Reset Fields" is visible
    When I enter or select "{SCROLL[9][1000px][Center][HorizontalFirst][100ms]}" in "Btn_Reset Fields"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_$2,000"
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0067: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-96c3-3086-b8c43e840d1e
    When I click "Additional Coverages"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0069: Additional Coverages-Add 'Home Systems Breakdown Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-0bb3-d0d3-cc9d6fad6471
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Home Systems Breakdown Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0070: Additional Coverages-Add 'Loss Assessment Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-88c2-7c35-bb7e9fde808e
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Loss Assessment Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0072: Additional Coverages-Add 'Vacancy' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-e9a6-9b9d-20d16b3cc4f7
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Vacancy" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0073: Additional Coverages-Add 'Broadened Water Backup Of Sewers And Drains' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-dcde-0495-a1e79daa5a2c
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Broadened Water Backup Of Sewers And Drains" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0074: EQH||Additional Coverages-Dwelling Coverages-Update 'Broadened Water Backup Of Sewers And Drains' amount & LAC values | Module: EQH||Additional Coverages-Dwelling Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-4a4f-7564-979b5422fc88
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "Btn_$5,000"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0075: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0076: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-0eee-ea87-9caebe478dd7
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0080: Mortgage/Additional Interest-Click NEXT to move to Billing | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-01d8-afe3-74fcdf77c1ca
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0082: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e88-3cb3-1a81-d3baaa4b7f5e
    Then I wait until "Hdr_Billing" is visible
    Then I wait until "Lbl_Select from existing Billing Accounts or Create New" is visible
    When I click "Btn_Create New Billing Account"
    Then "Lbl_Select the Primary Payer for the new account" should be visible
    When I click "Btn_Primary Account Holder name"
    Then "Lbl_Select Payment Type" should exist
    When I click "Btn_Direct Bill_1"
    Then "Lbl_Select Payment Plan" should exist
    When I click "Btn_Direct Bill - 1 Payment"
    Then I wait until "Txt_Due Date" is visible
    When I enter or select "\"^{a}\"" in "Txt_Due Date"
    When I enter or select "\"{DEL}\"" in "Txt_Due Date"
    When I enter or select "25" in "Txt_Due Date"
    When I enter or select "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}" in "Txt_Due Date"
    When I click "Rd Btn_Custom Amount"
    When I click "Btn_CHECK"
    Then I wait until "Txt_Check Number" is visible
    When I enter or select "512453294" in "Txt_Check Number"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_CREDIT CARD"
    Then "Lbl_Want to enroll for Paperless Communication?" should exist
    Then "Btn_Yes" should exist
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_No"
    When I click "Btn_Billing_NEXT"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0117: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0119: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0120: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e97-59be-6470-15fb2349b840
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaHome_PolicyData_Regression"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > FirstName" with captured runtime value "FirstName"
    And I use TDM parameter "Data structure > LastName" with captured runtime value "LastName"
    And I use TDM parameter "Data structure > DOB" with captured runtime value "DOB"
    And I use TDM parameter "Data structure > SSN" with captured runtime value "SSN"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0121: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e98-bdc5-fe10-a6e6ce9f5d49
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0122: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e98-9c42-0976-93fbb7a9ada3
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0124: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-f907-343e-3ad20a06033d
    # Runtime control: Close Chrome > Condition
    Then if the source runtime condition "Close Chrome > Condition" is satisfied, "Expression" should equal "Edge' = 'Chrome"

    # Source step 0125: TBox Start Program | Module: TBox Start Program
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-8434-e8b9-796ecb27e208
    # Runtime control: Close Chrome > Then
    And if the source runtime condition "Close Chrome > Then" is satisfied, I force-close browser/process "chrome.exe" using command "taskkill /im chrome.exe /f"

    # Source step 0126: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-e33b-af11-6296dee9c1a1
    # Runtime control: Close Edge > Condition
    Then if the source runtime condition "Close Edge > Condition" is satisfied, "Expression" should equal "Edge' = 'Edge"

    # Source step 0127: TBox Start Program | Module: TBox Start Program
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-e7e2-4f76-4a9fc5cda171
    # Runtime control: Close Edge > Then
    And if the source runtime condition "Close Edge > Then" is satisfied, I force-close browser/process "msedge.exe" using command "taskkill /im msedge.exe /f"

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
# 4. Source step 0026 field "Hdr_SECTION-ExpertQuote static word below AN symbol on top left" in "Start New Quote in EQ" was disabled. Reason:  
#    - Preserved source value: a blank value
# 5. Source step 0029 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: a blank value
# 6. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0034 field "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) CONVICTED OF ARSON IN THE LAST 5 YEARS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0034 field "Btn_None Of The Above_Client ER" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 11. Source step 0034 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 12. Source step 0034 field "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 13. Source step 0034 field "Btn_None Of The Above_Property Eligibility Restrictions_SH4" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0037 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0037 field "Btn_C/O" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0037 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 17. Source step 0037 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 18. Source step 0037 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 19. Source step 0037 field "Btn_Married" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0037 field "Btn_Son" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0040 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 22. Source step 0040 field "7.1-10.0" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 23. Source step 0042 field "Location Header" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 24. Source step 0042 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 26. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 27. Source step 0042 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 28. Source step 0042 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 29. Source step 0042 field "0-3.0" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 30. Source step 0044 field "Location Header" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 31. Source step 0044 field "Lbl_How long have you owned or occupied location?" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0044 field "Btn_Hide Google Maps" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 35. Source step 0044 field "Drp List_Miles to Fire Station-need to check" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 36. Source step 0044 field "0-3.0" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 37. Source step 0045 field "Location Header" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 38. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0045 field "Btn_Hide Google Maps" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 42. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 43. Source step 0045 field "0-3.0" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 44. Source step 0047 field "Location Header" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 45. Source step 0047 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 46. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 47. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 48. Source step 0047 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 49. Source step 0047 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 50. Source step 0047 field "0-3.0" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 51. Source step 0047 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 52. Source step 0047 field "< 601" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 53. Source step 0051 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 54. Source step 0058 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 55. Source step 0058 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 56. Source step 0058 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0058 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0058 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0058 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0058 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0058 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 62. Source step 0058 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 63. Source step 0058 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 64. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 66. Source step 0059 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 67. Source step 0059 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0060 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: a blank value
# 69. Source step 0066 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 70. Source step 0076 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0076 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0076 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0076 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 74. Source step 0076 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0076 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 76. Source step 0076 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 77. Source step 0078 "Mortgage/Additional Interest-Add Additional Interest" in module "EQH||Mortgage/Additional Interest" was disabled. Reason: 13.03.24 17:36:50 [ct2452]
#    - WAIT "Mortgage/Additional Interest Header" with "True"
#    - WAIT "Lbl_Mortgage / Additional Interest Summary" with "True"
#    - INPUT "Btn_ADD MORTGAGE / ADD'L INTEREST" with "{Invoke[Click]}"
#    - INPUT "Btn_NEXT" with a blank value
# 78. Source step 0079 "EQH||Add/Edit Additional Interest - Adding Additional Interest" in module "EQH||Add/Edit Additional Interest-Additional Insured/Landlord" was disabled. Reason: 13.03.24 17:36:50 [ct2452]
#    - WAIT "Lbl_Interest Type" with "True"
#    - WAIT "Btn_First Mortgagee" with "True"
#    - INPUT "Btn_Additional Insured/Landlord" with "X"
#    - WAIT "Btn_Additional Insured" with "True"
#    - INPUT "Text box_Name" with captured runtime value "FirstName"
#    - INPUT "Text box_Address" with "1310 Wilclark Rd Clovis"
#    - INPUT "Text box_City" with "Curry"
#    - INPUT "Dropdown-State-GenericGUI" with "{Click}"
#    - INPUT "NM" with "X"
#    - INPUT "Text box_Zip Code" with "88101"
#    - INPUT "Text box_Loan Number" with a blank value
#    - INPUT "Btn_SAVE" with "X"
# 79. Source step 0080 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Click NEXT to move to Billing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 80. Source step 0082 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0082 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0082 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 83. Source step 0082 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0084 "Submission- Land on Submission page and Refer to UW" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - WAIT "Hdr_Submission Header" with "True"
#    - VERIFY "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_UW1_AgentComments" with "Test"
#    - INPUT "Btn_Refer to UW_1" with "{Click}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
# 85. Source step 0085 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - INPUT "Duration" with "8000"
# 86. Source step 0086 "OpenUrl" in module "OpenUrl" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 87. Source step 0087 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 88. Source step 0088 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 89. Source step 0089 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 90. Source step 0090 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - VERIFY "Lbl_Login ID" with "True"
# 91. Source step 0091 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 92. Source step 0092 "EU||Home" in module "EU||Home" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
#    - INPUT "Lbl_Insured Name" with "X"
#    - INPUT "Lnk_Policyholder_name" with "X"
#    - INPUT "Lnk_Home" with "X"
#    - INPUT "Lnk_Pricing" with "X"
#    - INPUT "Txt_Underwriting Notes *" with "Approved"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - WAIT "Btn_Log Out" with "True"
#    - INPUT "Btn_Log Out" with "X"
# 93. Source step 0093 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:30 [ct2452]
#    - INPUT "Duration" with "12000"
# 94. Source step 0094 "Close the Express UI page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 08.03.24 16:39:53 [ct2452]
#    - INPUT "Caption" with "Home*"
#    - INPUT "Keys" with "^(w)"
# 95. Source step 0095 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Title" with "Home"
# 96. Source step 0096 "EQH||Quote Actions-Save and Exit the current Quote" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Btn_QUOTE ACTIONS" with "X"
#    - WAIT "Btn_Quote Actions_Save and Exit" with "True"
#    - INPUT "Btn_Quote Actions_Save and Exit" with "X"
# 97. Source step 0097 "Search for the Quote in EQ" in module "EQ||New Quote" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - WAIT "Btn_New Quote" with "True"
#    - INPUT "Btn_New Quote" with "X"
#    - INPUT "Txt_QuoteSearch_Input" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search_1" with "{Click}"
# 98. Source step 0098 "EQH||Side Menu and Quote Actions-Navigate to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Submission" with "{Click}"
# 99. Source step 0099 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Duration" with "5000"
# 100. Source step 0100 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
# 101. Source step 0101 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Duration" with "10000"
# 102. Source step 0102 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 103. Source step 0103 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 104. Source step 0104 "eChecklist-Click the documents/links in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 105. Source step 0105 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 106. Source step 0106 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:38 [ct2452]
#    - INPUT "Duration" with "10000"
# 107. Source step 0107 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:31 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 108. Source step 0108 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:31 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 109. Source step 0109 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 110. Source step 0110 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:23:31 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 111. Source step 0111 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:51:43 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 112. Source step 0112 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:43 [ct2452]
#    - INPUT "Duration" with "10000"
# 113. Source step 0113 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:51:43 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 114. Source step 0114 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:51:43 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 115. Source step 0115 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:43 [ct2452]
#    - INPUT "Duration" with "8000"
# 116. Source step 0116 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 15.03.24 15:15:14 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
#    - INPUT "Btn_Issue Home Binder" with "{Invoke[Click]}"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 117. Source step 0118 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 15.03.24 15:15:20 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
# 118. Source step 0120 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 119. Source step 0120 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 120. Source step 0120 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 121. Source step 0121 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 122. Source step 0121 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 123. Source step 0123 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.03.24 17:12:31 [ct2452]
#    - INPUT "Title" with "Sign On*"
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
