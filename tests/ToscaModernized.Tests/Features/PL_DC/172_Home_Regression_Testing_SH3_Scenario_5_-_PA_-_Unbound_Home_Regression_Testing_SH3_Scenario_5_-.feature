# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 172_Home_Regression_Testing_SH3_Scenario_5_-_PA_-_Unbound_Home_Regression_Testing_SH3_Scenario_5_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH3 Scenario #5 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH3 Scenario #5 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH3 Scenario #5 - PA - Unbound using representative iteration Home Regression Testing SH3 Scenario #5 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-1765-06d5-31a962ad6a1d
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-c3ef-23b9-aaf7d0c9b87b
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-07c7-331b-d206b6fb639d
    Then "<unnamed value>" should equal "Client Info"
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-5566-e2e4-3a1a967eb332
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "8000000000" in "<unnamed value>"
    When I enter or select "outwell@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "2855 Alexandra Dr, Erie, PA 16506" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-b0a2-c914-b25f253b6b4c
    Then "Btn_PERSONAL AUTO" should exist
    Then "Btn_MOTORCYCLE" should exist
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    Then "Btn_SH3-HOMEOWNERS" should be visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
    Then "Btn_SH6-CONDOMINIUM OWNERS" should exist
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0a-74cb-72ef-a389cf668159
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0a-a517-5046-968ed4330bb5
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0a-b69d-4588-e6d59abd548b
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-defc-70fb-95734e5bace2
    Then I wait until "Lbl_Client Eligibility Restrictions" is visible
    Then I wait until "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) WITH FELONY CONVICTION" exists
    Then "Btn_NO VALID SSN FOR ACCOUNT OWNER" should exist
    Then "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) CONVICTED OF ARSON IN THE LAST 5 YEARS" should exist
    Then "Btn_None Of The Above_Client ER" should exist
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    Then "Lbl_Property Eligibility Restrictions" should exist
    Then "Btn_SINGLE WIDE MANUFACTURED HOME" should exist
    Then "Btn_MANUFACTURED HOME CONSTRUCTED PRIOR TO 1994" should exist
    Then "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" should exist
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0036: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-3ff2-7a5e-aa8932b6fa45
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0037: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-b9ca-56b6-0b2749be499e
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0038: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-37a7-b619-01c3301d3d3a
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    Then "Btn_C/O" should exist
    Then "Lbl_Email Type" should exist
    Then "Lbl_Gender" should exist
    When I click "Btn_Male"
    Then "Btn_Female" should exist
    Then I wait until "Lbl_Marital Status" is visible
    Then I wait until "Btn_Single" is visible
    Then I wait until "Btn_Married" is visible
    Then "Lbl_Relation To Account Owner" should be visible
    Then "Btn_Son" should be visible
    Then "Btn_Daughter" should exist
    When I enter or select "{MOUSE[CLICK][Jump][5%][5%]}" in "Btn_SAVE AND CONTINUE"

    # Source step 0039: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-c99d-4ffc-73bf82d58a62
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0040: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0041: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-19e4-3367-2707bde3e40a
    Then I wait until "Location Header" exists
    Then "Lbl_How long have you owned or occupied location?" should exist
    When I click "Btn_More than 5 years"
    Then "Btn_More than 5 years" should exist
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"

    # Source step 0042: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0043: EQH||Location-till feet to hydrant | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-8368-c02f-a6d92c654d41
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0045: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-feb8-18df-3d6e847c63f1
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0046: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-8e52-4082-34e1346a962a
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0047: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0048: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-01a0-9bc5-dbf384a6444c
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0049: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-4f85-f2db-f24fe2f60772
    Then I wait until "Txt_Year Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Year Built"
    When I enter or select "\"{DEL}\"" in "Txt_Year Built"
    When I enter or select "2003" in "Txt_Year Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "1845" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    Then "Btn_Shingles, Asphalt/Fiberglass" should exist
    Then "Btn_Tile, Clay" should exist
    When I select "Btn_More Options_Roof Type"
    When I click "Shingles, Wood"
    Then "Lbl_Structure Type" should be visible
    When I click "Btn_Single Family"
    Then I wait until "Lbl_Home Type" is visible
    Then "Btn_Conventional" should exist
    When I click "Btn_Manufactured Home"
    Then "Btn_Modular Home" should exist
    Then I wait until "Lbl_Manufactured Home Type" is visible
    When I click "Btn_Singlewide"
    Then "Lbl_Is Principal Heating System Thermostatically Controlled ?" should exist
    When I select "Btn_YES"
    Then I wait until "Btn_GET VALUATION" is visible
    When I click "Btn_GET VALUATION"

    # Source step 0050: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0051: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-9ed9-bc4a-85e872ce6380
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0052: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-fb27-1db2-51a77b0196cc
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0053: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-d359-fbe8-7eba4c20c141
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0054: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-7279-c976-5bc2ebf906a3
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0055: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e0b-90af-353f-c78817119234
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0056: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0057: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-11db-aec8-71cb661abb88
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Is Principal Heating System Thermostatically Controlled ?"
    Then I wait until "Lbl_Construction Type" is visible
    Then "Btn_Frame" should exist
    Then "Btn_Siding" should exist
    When I click "Btn_Veneer"
    Then I wait until "Lbl_Building Occupancy" is visible
    When I click "Btn_Owner"
    Then I wait until "Btn_Tenant" is visible
    When I click "Txt_Market Value"
    When I enter or select "{Doubleclick}" in "Txt_Market Value"
    When I enter or select "\"^{a}\"" in "Txt_Market Value"
    When I enter or select "\"DEL\"" in "Txt_Market Value"
    When I enter or select "377000" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I press "Tab" while focused on "Txt_Heating (Year)"
    When I press "Tab" while focused on "Txt_Cooling (Year)"
    When I press "Tab" while focused on "Txt_Plumbing (Year)"

    # Source step 0058: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0059: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-5642-f084-2ea33b5f275c
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    When I click "Btn_Central"
    Then I wait until "Btn_Floor Furnace" exists
    Then I wait until "Btn_More Options_Principal Heat Type" is visible
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible

    # Source step 0060: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0061: Home Characteristics-Heating Details Supplemental Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-b324-708b-4d3d638041c1
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0063: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-0d47-a61d-bd53d312509a
    Then I wait until "Lbl_Roof UL Rating" is visible
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Roof UL Rating"
    When I select "Btn_None_Roof UL Rating"
    Then "Btn_UL3" should be visible
    Then "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." should exist
    Then "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" should exist
    Then "Btn_Chk box_Roof overlaid with more than two layers of shingles" should exist
    Then "Btn_Chk box_Roof overlaid on wood shake or shingle" should exist
    When I click "Btn_NEXT"

    # Source step 0064: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0065: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-8036-f23b-eb4a00746f97
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0066: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-e241-fe61-e38773a82c0f
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0067: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-64eb-69f0-45994985ecda
    Then I wait until "On Premise Exposures Header" is visible
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I enter or select "PGDN" in "Lbl_Dog Exposures"
    When I enter or select "PGDN" in "Lbl_Business Details"
    Then I wait until "Btn_Chk box_Animal Boarding" is visible
    Then I wait until "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" is visible
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0069: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-4c62-9d6b-5a06b69ed312
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0070: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-be5d-15c3-2e2f2e1560c2
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0071: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-a790-b307-24ee82a7b9f6
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0072: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "9000" milliseconds

    # Source step 0073: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-934f-9010-9477bc187e85
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

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0075: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-ec0c-28af-2db8caa535b8
    When I click "Additional Coverages"

    # Source step 0076: Additional Coverages-Add any additional coverages and Click Next | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-4fe5-68cc-a717fdbed49f
    Then I wait until "Additional Coverages Header" is visible
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0078: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-23f9-710f-e34999a434fb
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0080: Mortgage/Additional Interest-Add or Update, if needed  | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-e0a1-aa58-c43c400829b8
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    Then "Btn_ADD MORTGAGE / ADD'L INTEREST" should exist
    When I click "Btn_NEXT"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0082: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-99ce-02bc-2ad8a266e75b
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

    # Source step 0084: Submission- Land on Submission page | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-5b8d-7865-e3c317411c3a
    Then I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist

    # Source step 0105: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0107: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0109: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0110: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-9749-6f83-85a5e9f0a0f2
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

    # Source step 0111: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-4e2e-c42f-737c2bd902a1
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0113: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-8d4d-923a-2a3f79e673e8
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0114: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e19-fbc4-03af-6be29c7ef6c1
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
#    - Preserved source value: "{Click[10px][10px]}"
# 5. Source step 0028 field "<unnamed value>" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}"
# 6. Source step 0028 field "Lbl_Have you received mail at this address for at least 90 days?" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}"
# 7. Source step 0029 field "Btn_SD1-RENTAL OWNERS" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 8. Source step 0029 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 10. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 12. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 13. Source step 0034 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 14. Source step 0034 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
# 15. Source step 0034 field "Btn_None Of The Above_Property Eligibility Restrictions_SH4" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0035 "TBox Partial Buffer-Extract the Quote Number" in module "TBox Partial Buffer" was disabled. Reason: 25.01.24 17:19:58 [ct2452]
#    - INPUT "Buffer" with "QuoteNumber"
#    - INPUT "Value" with captured runtime value "LNQuoteNumber"
#    - INPUT "Last" with "12"
# 17. Source step 0038 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 18. Source step 0038 field "Lbl_Phone Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 19. Source step 0038 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 20. Source step 0038 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 21. Source step 0038 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 22. Source step 0041 field "Btn_More than 5 years" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[12][1000px][None][HorizontalFirst][300ms]}"
# 23. Source step 0041 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 24. Source step 0043 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 25. Source step 0045 field "Location Header" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0045 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "X"
# 28. Source step 0045 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 29. Source step 0045 field "Btn_Hide Google Maps" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 30. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 31. Source step 0045 field "0-3.0" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 32. Source step 0046 field "Location Header" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "True"
# 33. Source step 0046 field "Lbl_How long have you owned or occupied location?" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0046 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0046 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0046 field "Btn_Hide Google Maps" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 37. Source step 0046 field "Drp List_Miles to Fire Station-need to check" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 38. Source step 0046 field "0-3.0" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 39. Source step 0048 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 40. Source step 0049 field "Home Characteristics Header" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "PGUP"
# 41. Source step 0049 field "Btn_Multiwide" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}"
# 42. Source step 0052 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 43. Source step 0057 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][500px][Center][HorizontalFirst][300ms]}"
# 45. Source step 0065 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 46. Source step 0065 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 47. Source step 0065 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0065 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 49. Source step 0065 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0065 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0065 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0065 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 53. Source step 0065 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 54. Source step 0065 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 55. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 57. Source step 0066 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 58. Source step 0066 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0067 field "Lbl_Other Structures" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0067 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0067 field "Lbl_Special Exposures" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0067 field "Btn_Chk box_Swimming pool" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0067 field "Lbl_Farm & Livestock Exposures" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 64. Source step 0067 field "Btn_Chk box_Incidental Farming on premise" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0067 field "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0067 field "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "X"
# 67. Source step 0067 field "Btn_NEXT" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0067 field "Btn_NEXT" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 69. Source step 0069 field "On Premise Exposures Header" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 70. Source step 0069 field "Lbl_Other Structures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0069 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0069 field "Lbl_Special Exposures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0069 field "Btn_Chk box_Swimming pool" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 74. Source step 0069 field "Btn_Chk box_None of the Above - Business Details" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 75. Source step 0069 field "Lbl_Dog Exposures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 76. Source step 0069 field "Lbl_Business Details" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 77. Source step 0069 field "Btn_Chk box_Animal Boarding" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0069 field "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0069 field "Btn_Chk box_BUSINESS ON PREMISE" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0069 field "Btn_Chk box_None Of The Above" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 81. Source step 0069 field "Btn_Chk box_Incidental Farming on premise" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0073 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 83. Source step 0073 field "All Other Peril Deductible_2%" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: a blank value
# 84. Source step 0082 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0082 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0082 field "Txt_Due Date" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 87. Source step 0082 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 88. Source step 0082 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 89. Source step 0084 field "Lbl_Step 1. Review Messages" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
# 90. Source step 0084 field "Txt_UW1_AgentComments" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "Test"
# 91. Source step 0084 field "Btn_Refer to UW_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 92. Source step 0084 field "Btn_Launch To Checklist_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 93. Source step 0084 field "Btn_Launch To Checklist_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 94. Source step 0084 field "Btn_Launch To eSignature_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 95. Source step 0084 field "Lbl_Step 4. Transmit" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0084 field "Btn_Transmit_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 97. Source step 0084 field "Btn_Issue Home Binder" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 98. Source step 0084 field "Btn_Save and Exit_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0085 "EQH||Side Menu and Quote Actions-Navigate back to NamedInsured page to select Gender again, remove GenderX 0076 error on submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 01.02.24 12:16:31 [ct2452]
#    - INPUT "Named Insureds Summary" with "{Click}"
#    - INPUT "Location" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 100. Source step 0086 "EQH||Named Insureds Summary-Review details or Add Named Insured" in module "EQH||Named Insureds Summary-Review details or Add Named Insured" was disabled. Reason: 01.02.24 12:16:31 [ct2452]
#    - WAIT "Named Insureds Summary Header" with "True"
#    - INPUT "Btn_edit pen icon" with "{Click}"
# 101. Source step 0087 "EQH||Add or Edit Named Insured-Existing Client" in module "EQH||Add or Edit Named Insured-Existing Client" was disabled. Reason: 01.02.24 12:16:31 [ct2452]
#    - WAIT "Add/Edit Named Insured Header" with "True"
#    - INPUT "Txt_Phone Number" with "{SCROLL[3][100px][Center][HorizontalFirst][300ms]}"
#    - INPUT "Btn_Female" with "X"
#    - INPUT "Btn_SAVE AND CONTINUE" with "X"
# 102. Source step 0088 "TBox Wait" in module "TBox Wait" was disabled. Reason: 01.02.24 12:16:31 [ct2452]
#    - INPUT "Duration" with "10000"
# 103. Source step 0089 "EQH||Side Menu and Quote Actions-Navigate back to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 01.02.24 12:16:31 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 104. Source step 0090 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
# 105. Source step 0091 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - INPUT "Duration" with "10000"
# 106. Source step 0092 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 107. Source step 0093 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 108. Source step 0094 "eChecklist-Click to upload 'Home/ROP Electronic Application' documents/links in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 109. Source step 0095 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 110. Source step 0096 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:49:28 [ct2452]
#    - INPUT "Duration" with "10000"
# 111. Source step 0097 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:20:30 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 112. Source step 0098 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:20:30 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 113. Source step 0099 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 114. Source step 0100 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:20:30 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 115. Source step 0101 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:49:37 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 116. Source step 0102 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:49:37 [ct2452]
#    - INPUT "Duration" with "10000"
# 117. Source step 0103 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:49:37 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 118. Source step 0104 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:49:37 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 119. Source step 0106 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 15.03.24 15:08:50 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
# 120. Source step 0108 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 15.03.24 15:08:56 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
#    - INPUT "Submission" with "{Click}"
# 121. Source step 0110 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 122. Source step 0110 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 123. Source step 0110 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 124. Source step 0111 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 125. Source step 0111 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 126. Source step 0112 "TBox Partial Buffer-Compare the Total Premium from PricingDetails and TransmitConfirmation" in module "TBox Partial Buffer" was disabled. Reason: 15.03.24 15:09:01 [ct2452]
#    - INPUT "Buffer" with "Pricing Details_Total Premium"
#    - VERIFY "Value" with captured runtime value "Premium"
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
