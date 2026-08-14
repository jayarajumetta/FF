# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 177_Home_Regression_Testing_SH6_Scenario_2_-_PA_-_Unbound_Home_Regression_Testing_SH6_Scenario_2_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH6 Scenario #2 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH6 Scenario #2 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH6 Scenario #2 - PA - Unbound using representative iteration Home Regression Testing SH6 Scenario #2 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-e31d-9de5-0e70f44eae40
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-b5ff-3188-9c6dff39d270
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-5c8e-b7af-c5893d2cdca5
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-fea9-3b3d-f72460951ede
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "5000000000" in "<unnamed value>"
    When I enter or select "inout@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "6244 Fiddle Lake Road, Union Dale, PA 18470" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I enter or select "101" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-a22a-9709-cac86950c401
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-1ac3-555c-240072bff101
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-c630-5400-2eb13c6d048e
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-40ff-ff61-dd26e10fa73c
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-1b3b-20f0-dd7aea023da6
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-704e-da1d-257cfd8002c3
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0036: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-b217-e375-ed117a79966f
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0037: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-8ba7-f0f4-0ecf3fd7a4ed
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-8a73-0820-49bf7ee80662
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0040: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-0fe1-4720-e9f9c35d6494
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e9d-7b20-b14a-f2fde0f89c43
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0044: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea1-5794-31b3-2139e9546b48
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0045: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea1-0834-0a36-9f617e99e4d4
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0047: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea1-7d6a-2ab1-f082fba44fcb
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0048: EQH||Home Characteristics_SH6-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH6
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea1-ebfd-135b-871425852882
    Then I wait until "Home Characteristics_Header" is visible
    Then I wait until "Txt_Years Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "1990" in "Txt_Years Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "1404" in "Txt_Total Living Area"
    Then "Lbl_Roof Type" should exist
    When I click "Shingles, Asphalt/Fiberglass"
    Then "Lbl_# of Apts. Between Firewalls" should exist
    When I click "5 - 99 Units"
    When I enter or select "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Home Type"
    When I click "Conventional"
    Then "Lbl_Is Principal Heating System Thermostatically Controlled ?" should exist
    When I select "Yes"
    When I click "Btn_Get Valuation"

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0050: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea1-154c-b0cf-43ee23691343
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0051: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-c2a4-d739-3a452cac049f
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0052: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-a7bf-2f71-013730e4716f
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0053: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-5192-d41f-28a30796addd
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0054: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-1c49-9916-dd1b225d91db
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0056: EQH||Home Characteristics_SH6-Property Information and Heating details | Module: EQH||Home Characteristics_SH6
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-c3d7-8136-a1dd8c5ab184
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-c6fe-3440-de63de385897
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0059: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-3863-5a89-6cb7d0f55387
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0060: On Premise Exposures-Provide details regarding Dog exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-1834-a551-558d3902bc6b
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I click "Btn_Chk box_Dogs on Premise"
    When I enter or select "Lana" in "Txt_animal_Name"
    When I click "Gender"
    When I click "Female ( Spayed)"
    When I enter or select "\"^{a}\"" in "Txt_animal_YearBorn"
    When I enter or select "\"{DEL}\"" in "Txt_animal_YearBorn"
    When I enter or select "2023" in "Txt_animal_YearBorn"
    When I click "Primary Breed"
    When I click "Australian Shepherd"
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Business Details"
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"

    # Source step 0061: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0062: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-fdd0-f88f-a6e0311d0a3f
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0063: Claims History-Choose to Add Claim 01 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-6478-e709-b6e632f14949
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0064: EQH||Add Non-Weather Claim 01 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-8293-acb3-8373cc1b861f
    When I enter or select "01/25/2016" in "Txt_Claim Date"
    When I enter or select "2000" in "Txt_Claim Amount"
    When I enter or select "524365182" in "Txt_Policy Number"
    Then "Lbl_Claim Status" should exist
    When I click "Btn_Closed"
    When I click "Drp List_Claim Description"
    When I click "Accounts receivable"
    When I click "Btn_SH6 - Condominium Owners"
    Then "Lbl_Weather Related?" should exist
    When I select "Btn_No"
    When I select "Btn_No_Catastrophe Related"
    When I click "Btn_SAVE"

    # Source step 0065: Claims History-Choose to Add Claim 02 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-a88b-d2c1-fc7d7bd41614
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0066: EQH||Add Non-Weather Claim 02 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ea3-9f2e-e272-99e2d75ab50f
    When I enter or select "01/25/2015" in "Txt_Claim Date"
    When I enter or select "1000" in "Txt_Claim Amount"
    When I enter or select "524365282" in "Txt_Policy Number"
    Then "Lbl_Claim Status" should exist
    When I click "Btn_Closed"
    When I click "Drp List_Claim Description"
    When I click "Accounts receivable"
    When I click "Btn_SH6 - Condominium Owners"
    Then "Lbl_Weather Related?" should exist
    When I select "Btn_No"
    When I select "Btn_No_Catastrophe Related"
    When I click "Btn_SAVE"

    # Source step 0067: Claims History-Choose to Add Claim 03 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3eaa-3940-446c-183c8c2f682f
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0068: EQH||Add Non-Weather Claim 03 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3eaa-884f-d737-8fb0857ea7e1
    When I enter or select "12/25/2015" in "Txt_Claim Date"
    When I enter or select "500" in "Txt_Claim Amount"
    When I enter or select "524365195" in "Txt_Policy Number"
    Then "Lbl_Claim Status" should exist
    When I click "Btn_Closed"
    When I click "Drp List_Claim Description"
    When I click "Accounts receivable"
    When I click "Btn_SH6 - Condominium Owners"
    Then "Lbl_Weather Related?" should exist
    When I select "Btn_No"
    When I select "Btn_No_Catastrophe Related"
    When I click "Btn_SAVE"

    # Source step 0069: Claims History-Click Next to move to Discounts page | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-889c-97e3-b39ee3a630e7
    Then I wait until "Claims History Header" is visible
    When I click "Btn_NEXT"

    # Source step 0070: Discounts/Adjustments-Choose Central Fire, Local Burglar alarm discounts | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-b7ac-414e-75971dea8646
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    When I click "Btn_Chk box_Central Fire Alarm"
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_Chk box_Local Burglar Alarm"
    When I click "Btn_NEXT"

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0072: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $5000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-3cdd-2c5f-22de2f30284c
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Btn_Reset Fields" is visible
    When I enter or select "{SCROLL[9][1000px][Center][HorizontalFirst][100ms]}" in "Btn_Reset Fields"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_$5,000"
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0073: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-f8db-e85d-18a4c6a62fd8
    When I click "Additional Coverages"

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0075: Additional Coverages-Add 'Scheduled Personal Property' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-bba6-ccb2-71d30b100986
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Scheduled Personal Property" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0076: EQH||Additional Coverages-Contents Coverages-Select 'Add Scheduled Personal Property' | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-7e3b-36a2-b898ccd286e3
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I click "Btn_ADD SCHEDULED PERSONAL PROPERTY"

    # Source step 0077: EQH||Scheduled Coverage-Contents Covg-Scheduled Personal Property | Module: EQH||Scheduled Coverage-Contents Covg-Scheduled Personal Property
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-50fe-2f26-12a0c921218b
    Then I wait until "Scheduled Coverage Summary" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Contents Coverages: Scheduled Personal Property"
    When I click "DropList_Add New Category_Type_GenericGUI"
    When I click "Furs"
    When I click "Btn_ADD CATEGORY"
    When I enter or select "CanadaGoose" in "Txt_Item_Furs_Description"
    When I enter or select "2500" in "Txt_Item_Furs_Current Value"
    When I click "Drop List_Item_Furs_Deductible Value"
    When I click "10%"
    When I click "Btn_SAVE"

    # Source step 0078: Additional Coverages-Add 'Increased Coverage For Personal Property In Self Storage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-1f97-14d1-3bbd05ed62eb
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increased Coverage For Personal Property In Self Storage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0080: Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-9180-7c8e-41bd7d52ffbd
    When I enter or select "Increased Limit For Lawn Implements" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0081: EQH||Additional Coverages-Contents Coverages-Update 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-7e44-88b5-31da50237c0c
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I enter or select "15000" in "Txt_Increased Limits For Lawn Implements And Service Vehicles"
    When I click "Btn_Next"

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0083: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-a5e3-e4a1-1ccb6b144900
    When I click "Additional Coverages"

    # Source step 0084: Additional Coverages-Add 'Business Merchandise Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-0fad-5da5-678676208f50
    When I enter or select "Business Merchandise Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0085: Additional Coverages-Add 'Water Backup Of Sewers And Drains' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-2b85-6166-53617f531857
    When I enter or select "Water Backup Of Sewers And Drains" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $2 > $1"

    # Source step 0086: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0087: Additional Coverages-Add 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-8508-3f5a-d6e96614f278
    When I enter or select "Credit Card, Fund Transfer Card" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0088: EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-d1f6-c1fe-4bba06d328e5
    When I click "Btn_$2,000"
    When I click "Btn_Next"

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0090: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-55d7-c88e-9333be84089a
    When I click "Additional Coverages"

    # Source step 0091: Additional Coverages-Add 'Office, Professional, Private School Or Studio Use - Residence Premises' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-77dc-44b0-d6375d80d576
    When I enter or select "Office, Professional, Private School" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0092: EQH||Additional Coverages-Liability Coverages-Update 'Office, Professional, Private School Or Studio Use - Residence Premises' | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-fd23-c9ab-626a1620b633
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "Sole Proprietorship"
    When I click "One Chair Beauty or Barber Shop"
    When I click "Separate Structure on Premises"
    When I click "$5,000"
    When I enter or select "\"^{a}\"" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "\"^{DEL}\"" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "6000" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "18000" in "Txt_OfficeProfessionalPrivateSchool_ApproximateAnnualGrossRevenues"
    When I click "Btn_Next"

    # Source step 0093: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0094: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-85aa-28c4-23c76a45e40a
    When I click "Additional Coverages"

    # Source step 0095: Additional Coverages-Add 'Additional Residence Premises - Rented To Others' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-1b40-3886-0e00c29610eb
    When I enter or select "Additional Residence Premises - Rented To Others" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0096: EQH||Additional Coverages-Liability Coverages-Select 'Add Additional Location' | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-cddc-9fa5-c9427d4fd8c6
    When I click "Btn_+ ADD ADDL RESIDENCE LOCATION"

    # Source step 0097: EQH||Scheduled Coverage-Liability Covg-Update 'Additional Residence Premises - Rented To Others' | Module: EQH||Scheduled Coverage-Liability Covg-Additional Residence Premises - Rented To Others
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-83bb-940b-5b5db7347b8e
    When I enter or select "6244 Fiddle Lake Road, Union Dale, PA 18470" in "Enter a location"
    When I enter or select "{click}{down}" in "Enter a location"
    When I click "1"
    When I select "No"
    When I click "SAVE"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0099: Additional Coverages-Add 'Increased Limits On Personal Property In Other Residences ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-ebc7-e952-8798e62489a1
    When I enter or select "Increased Limits On Personal Property In Other Residences" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0100: EQH||Additional Coverages-Contents Coverages-Select 'Add Pers Prop Res Location' | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-8962-e472-8df9ccacc5d9
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I click "Btn_+ ADD PERS PROP RES LOCATION"

    # Source step 0101: EQH||Scheduled Coverage-Contents Covg-Increased Limits On Personal Property In Other Residences | Module: EQH||Scheduled Coverage-Contents Covg-Increased Limits On Personal Property In Other Residences
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-130f-af1f-f9b01276df1c
    When I enter or select "6244 Fiddle Lake Road, Union Dale, PA 18470" in "Txt_Inc Limits Pers Prop Other Res Details_Location"
    When I enter or select "{click}{down}" in "Txt_Inc Limits Pers Prop Other Res Details_Location"
    When I click "SAVE"

    # Source step 0102: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0103: Additional Coverages-Add 'Home Day Care Coverage ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-c3b7-eca7-56bb354c35a8
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Home Day Care Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0105: Additional Coverages-Add 'Additional Insured Residence Premises' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-4a26-6329-62e34176163c
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Additional Insured Residence Premises" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    When I click "Btn_NEXT"

    # Source step 0106: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0107: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-f7a6-4fb9-d90aaf7a43aa
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0109: Mortgage/Additional Interest-Add Additional Interest | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-63bb-2c3b-f70608a8a5b0
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_ADD MORTGAGE / ADD'L INTEREST"

    # Source step 0110: EQH||Add/Edit Additional Interest - Adding Additional Interest | Module: EQH||Add/Edit Additional Interest-Additional Insured/Landlord
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-809d-513d-018795d666e1
    Then I wait until "Lbl_Interest Type" is visible
    Then I wait until "Btn_First Mortgagee" is visible
    When I click "Btn_Additional Insured/Landlord"
    Then I wait until "Btn_Additional Insured" is visible
    When I enter captured runtime value "FirstName" in "Text box_Name"
    When I enter or select "201 Arno St NE" in "Text box_Address"
    When I enter or select "Albuquerque" in "Text box_City"
    When I select "Dropdown-State-GenericGUI"
    When I click "NM"
    When I enter or select "87102" in "Text box_Zip Code"
    When I click "Btn_SAVE"

    # Source step 0112: Add/Edit Additional Interest-UW Rules Address Validation pop up is shown | Module: EQH||Add/Edit Additional Interest-UW Rules Address Validation pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-651e-9b76-1974905608a5
    # Runtime control: If_Verify Additional Insured Address verification pop up shown > Condition
    Then if the source runtime condition "If_Verify Additional Insured Address verification pop up shown > Condition" is satisfied, "BACK TO DETAILS" should be visible

    # Source step 0113: click continue | Module: EQH||Add/Edit Additional Interest-UW Rules Address Validation pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-daaa-3596-ba2cd37abfca
    # Runtime control: If_Verify Additional Insured Address verification pop up shown > Then
    When if the source runtime condition "If_Verify Additional Insured Address verification pop up shown > Then" is satisfied, I click "CONTINUE"

    # Source step 0114: Mortgage/Additional Interest-Click NEXT to move to Billing | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-9a38-97ab-d08db8409d3f
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0115: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0116: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ead-f361-c39a-beed33af16b4
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

    # Source step 0117: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0148: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0150: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0152: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0153: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3eb7-4b3a-4e5d-464740762e49
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

    # Source step 0154: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3eb7-f011-102d-6b2ba0ce3af1
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0155: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3eb7-4d1a-792e-1e67d33465c3
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0156: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3eb7-e1a6-7990-ad2ee36bfff8
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
# 4. Source step 0026 field "Hdr_SECTION-ExpertQuote static word below AN symbol on top left" in "Start New Quote in EQ" was disabled. Reason:  
#    - Preserved source value: a blank value
# 5. Source step 0029 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: a blank value
# 6. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 9. Source step 0037 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0037 field "Btn_C/O" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0037 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 12. Source step 0037 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 13. Source step 0037 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 14. Source step 0037 field "Btn_Married" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0037 field "Btn_Son" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0040 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 17. Source step 0040 field "7.1-10.0" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 18. Source step 0042 field "Location Header" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 19. Source step 0042 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 20. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 21. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 22. Source step 0042 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 23. Source step 0042 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 24. Source step 0042 field "0-3.0" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0044 field "Location Header" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0044 field "Lbl_How long have you owned or occupied location?" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 29. Source step 0044 field "Btn_Hide Google Maps" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 30. Source step 0044 field "Drp List_Miles to Fire Station-need to check" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 31. Source step 0044 field "0-3.0" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 32. Source step 0045 field "Location Header" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 33. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 34. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 35. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 36. Source step 0045 field "Btn_Hide Google Maps" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 37. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 38. Source step 0045 field "0-3.0" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0047 field "Location Header" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0047 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 42. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 43. Source step 0047 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 44. Source step 0047 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 45. Source step 0047 field "0-3.0" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 46. Source step 0047 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 47. Source step 0047 field "< 601" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 48. Source step 0051 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 49. Source step 0058 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 50. Source step 0058 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 51. Source step 0058 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0058 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0058 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0058 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0058 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0058 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 57. Source step 0058 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 58. Source step 0058 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 59. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 61. Source step 0059 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 62. Source step 0059 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0060 field "Lbl_Dog Exposures" in "On Premise Exposures-Provide details regarding Dog exposures" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 64. Source step 0060 field "Btn_+ ADD DOG" in "On Premise Exposures-Provide details regarding Dog exposures" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 65. Source step 0063 field "Btn_NEXT" in "Claims History-Choose to Add Claim 01" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 66. Source step 0065 field "Btn_NEXT" in "Claims History-Choose to Add Claim 02" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 67. Source step 0067 field "Btn_NEXT" in "Claims History-Choose to Add Claim 03" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 68. Source step 0072 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $5000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 69. Source step 0080 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 70. Source step 0084 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Business Merchandise Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 71. Source step 0085 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Water Backup Of Sewers And Drains' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 72. Source step 0087 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit ' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 73. Source step 0088 field "Lbl_Coverage Catalog" in "EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 74. Source step 0088 field "Lbl_Contents Coverages" in "EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 75. Source step 0091 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Office, Professional, Private School Or Studio Use - Residence Premises' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 76. Source step 0095 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Additional Residence Premises - Rented To Others' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 77. Source step 0099 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Limits On Personal Property In Other Residences ' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 78. Source step 0104 "Additional Coverages-Add 'Inc limit dogs/equine' coverage/endorsement, if available" in module "EQH||Additional Coverages" was disabled. Reason: 14.03.24 20:13:11 [ct2452]
#    - INPUT "Lbl_Coverage Catalog" with "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_Search by Name-Coverage Catalog" with "Inc limit dogs/equine"
#    - INPUT "Btn_Search-Coverage Catalog" with "X"
#    - INPUT "TABLE > $1 > $1" with "{click[1px][1px]}"
# 79. Source step 0107 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0107 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0107 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0107 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 83. Source step 0107 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0107 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 85. Source step 0107 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 86. Source step 0109 field "Btn_NEXT" in "Mortgage/Additional Interest-Add Additional Interest" was disabled. Reason:  
#    - Preserved source value: a blank value
# 87. Source step 0110 field "Text box_Loan Number" in "EQH||Add/Edit Additional Interest - Adding Additional Interest" was disabled. Reason:  
#    - Preserved source value: a blank value
# 88. Source step 0111 "EQH||Add/Edit Additional Interest-UW Rules Address Validation pop up" in module "EQH||Add/Edit Additional Interest-UW Rules Address Validation pop up" was disabled. Reason: 14.03.24 21:23:23 [ct2452]
#    - INPUT "CONTINUE" with "X"
# 89. Source step 0114 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Click NEXT to move to Billing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 90. Source step 0116 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 91. Source step 0116 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0116 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 93. Source step 0116 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0118 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
# 95. Source step 0119 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - INPUT "Duration" with "10000"
# 96. Source step 0120 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 97. Source step 0121 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 98. Source step 0122 "eChecklist-Click the 'Home/ROP Electronic Application' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 99. Source step 0123 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 100. Source step 0124 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - INPUT "Duration" with "10000"
# 101. Source step 0125 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 102. Source step 0126 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 103. Source step 0127 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 104. Source step 0128 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:52:24 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 105. Source step 0129 "eChecklist-Click the 'Additional Residence Premises - Rented to Others (back diagonal)' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Additional Residence Premises - Rented to Others (back diagonal)" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 106. Source step 0130 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 107. Source step 0131 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Duration" with "10000"
# 108. Source step 0132 "eChecklist-Click the 'Additional Residence Premises - Rented to Others (front diagonal)' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Additional Residence Premises - Rented to Others (front diagonal)" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 109. Source step 0133 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 110. Source step 0134 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Duration" with "10000"
# 111. Source step 0135 "eChecklist-Click the 'Copy of Alarm Certificate' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Copy of Alarm Certificate" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 112. Source step 0136 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 113. Source step 0137 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Duration" with "10000"
# 114. Source step 0138 "eChecklist-Click the 'Service Vehicle & Lawn Implements - Appraisal/Receipt' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Service Vehicle & Lawn Implements - Appraisal/Receipt" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 115. Source step 0139 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 116. Source step 0140 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Duration" with "10000"
# 117. Source step 0141 "eChecklist-Click the 'Service Vehicle & Lawn Implements - Photo' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Service Vehicle & Lawn Implements - Photo" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 118. Source step 0142 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:23:57 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 119. Source step 0143 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:52:32 [ct2452]
#    - INPUT "Duration" with "10000"
# 120. Source step 0144 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:52:32 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 121. Source step 0145 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:52:32 [ct2452]
#    - INPUT "Duration" with "10000"
# 122. Source step 0146 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:52:32 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 123. Source step 0147 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:52:32 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 124. Source step 0149 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 15.03.24 15:17:24 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
#    - INPUT "Btn_Issue Home Binder" with "{Invoke[Click]}"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 125. Source step 0151 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 15.03.24 15:17:30 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
# 126. Source step 0153 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 127. Source step 0153 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 128. Source step 0153 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 129. Source step 0154 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 130. Source step 0154 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
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
