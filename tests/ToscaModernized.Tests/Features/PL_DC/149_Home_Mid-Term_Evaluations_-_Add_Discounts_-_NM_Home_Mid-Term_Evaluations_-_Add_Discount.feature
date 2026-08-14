# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 149_Home_Mid-Term_Evaluations_-_Add_Discounts_-_NM_Home_Mid-Term_Evaluations_-_Add_Discount.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @manual_conversion @Edge @manual @archive @automated
Feature: Execute Home Mid-Term Evaluations - Add Discounts - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Mid-Term Evaluations - Add Discounts - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Mid-Term Evaluations - Add Discounts - NM using representative iteration Home Mid-Term Evaluations - Add Discounts - NM
    # Source step 0020: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-d99d-81fd-73ee1a0c90c7
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0021: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-a2b3-a984-11041e99656a
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0022: Client Selection-Enter Client Info of New or Existing Clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-e06c-d182-6ad89858e486
    Then "Lbl_Client Info" should exist
    Then "Lbl_Client Info" should equal "Client Info"
    Then "Lbl_New/Existing Client Search" should exist
    Then "Lbl_New/Existing Client Search" should equal "New/Existing Client Search"
    When I enter the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.FirstName" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.LastName" in "Txt_Last"
    When I enter the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.DOB" in "Txt_Date of birth"
    When I leave "Txt_Best phone" blank
    When I leave "Txt_Email address" blank
    Then "Btn_Search" should exist
    When I click "Btn_Search"
    Then "Btn_Create New Client" should equal "Create New Client"
    When I select "Btn_Existing Client Match_SecondOption"
    Then "Btn_Next" should be visible
    When I click "Btn_Next"

    # Source step 0024: Account Details-Choose existing account | Module: EQH||Account Details(with existing Auto accounts)
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-98d9-f07a-decef2bedb17
    Then I wait until "Header_Account Information" is visible
    Then "Lbl_Please select to add this policy to an existing account or to a new account." should exist
    When I click "Btn_Next"

    # Source step 0026: Proposal Start(with existing accounts)-With Effective Date prior to 90 days from current date | Module: EQ||Proposal Start(with existing Auto accounts)
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-7c86-ba6d-c39cb0493c7f
    Then I wait until "Btn_PERSONAL AUTO" is visible
    Then I wait until "Btn_MOTORCYCLE" is visible
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
    Then "Btn_SH6-CONDOMINIUM OWNERS" should exist
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_SD1-RENTAL OWNERS"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][-90d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "DrpList_Rating State"
    When I click "NEW MEXICO_1"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I click "Rd Btn_Same as Existing Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0027: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-f9d3-694f-d5a30ca79b86
    # Runtime control: Proposal Start_Proceed  - If Popup appears > Condition - If Popup appears
    Then if the source runtime condition "Proposal Start_Proceed - If Popup appears > Condition - If Popup appears" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0028: EQ||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-eb35-7cd8-1416931cebf8
    # Runtime control: Proposal Start_Proceed  - If Popup appears > Then - Click Proceed
    When if the source runtime condition "Proposal Start_Proceed - If Popup appears > Then - Click Proceed" is satisfied, I click "Btn_PROCEED"

    # Source step 0038: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0039: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-0a89-c8e1-d8ee2c7f6b58
    Then I wait until "Lbl_Client Eligibility Restrictions" is visible
    Then I wait until "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) WITH FELONY CONVICTION" exists
    Then "Btn_NO VALID SSN FOR ACCOUNT OWNER" should exist
    Then "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) CONVICTED OF ARSON IN THE LAST 5 YEARS" should exist
    Then "Btn_None Of The Above_Client ER" should exist
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    Then "Lbl_Property Eligibility Restrictions" should exist
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_MORE THAN 2 UNITS"
    Then "Btn_SINGLE WIDE MANUFACTURED HOME" should exist
    Then "Btn_MANUFACTURED HOME CONSTRUCTED PRIOR TO 1994" should exist
    Then "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" should exist
    Then "Btn_None Of The Above_Property Eligibility Restrictions_SH4" should exist
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0040: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-0879-c571-8c29c5cc1edd
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0041: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-ff87-46d7-197e2c1597da
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0042: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-faf5-1a86-385baede42a6
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    Then "Btn_C/O" should exist
    When I enter or select "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Phone Type"
    Then "Lbl_Email Type" should exist
    Then "Lbl_Gender" should exist
    Then "Btn_Female" should exist
    Then I wait until "Lbl_Marital Status" is visible
    Then I wait until "Btn_Single" is visible
    Then I wait until "Btn_Married" is visible
    Then "Lbl_Relation To Account Owner" should be visible
    Then "Btn_Son" should be visible
    Then "Btn_Daughter" should exist
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0043: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-7674-1f21-049fe9ead7e4
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0045: Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-b575-725a-19f9d9db53f6
    Then I wait until "Location Header" exists
    Then "Lbl_How long have you owned or occupied location?" should exist
    When I click "Btn_More than 5 years"
    Then "Btn_More than 5 years" should exist
    When I enter or select "{SCROLL[12][1000px][None][HorizontalFirst][300ms]}" in "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0047: Location-till feet to hydrant | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cfc-4d20-5bf1-41ee3f250b93
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0048: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0049: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-f442-ec9f-70e0709760de
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0050: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-68ec-1a16-7fdfa2ed37e8
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0051: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0052: Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-2816-504c-fd2d63390bbc
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Drp List_Select County"
    When I click "SAN JUAN"
    When I click "BLOOMFIELD1003602"
    When I click "Btn_NEXT"

    # Source step 0053: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-0cc9-98f1-8c4c310870b9
    When I enter or select "PGUP" in "Home Characteristics Header"
    Then I wait until "Txt_Year Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Year Built"
    When I enter or select "\"{DEL}\"" in "Txt_Year Built"
    When I enter or select "2003" in "Txt_Year Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "1827" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    When I click "Btn_Shingles, Architectural"
    Then "Btn_Shingles, Asphalt/Fiberglass" should exist
    Then "Btn_Tile, Clay" should exist
    Then I wait until "Btn_More Options_Roof Type" is visible
    Then "Lbl_Structure Type" should be visible
    When I click "Btn_Single Family"
    Then I wait until "Lbl_Home Type" is visible
    When I click "Btn_Conventional"
    Then "Btn_Manufactured Home" should exist
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Btn_Modular Home"
    Then "Lbl_Is Principal Heating System Thermostatically Controlled ?" should exist
    When I select "Btn_YES"
    Then I wait until "Btn_GET VALUATION" is visible
    When I click "Btn_GET VALUATION"

    # Source step 0054: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0055: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-122d-8c81-a17b398d0d84
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0056: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-7e70-e707-eb2ddb978d00
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0057: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-7e6d-b72a-7e153133bcd2
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0058: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-9ba7-2483-a79a0f8e6841
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0059: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-aaf4-9e4f-2bec38ad978d
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0060: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0061: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-c981-c2a7-0a4ed5bd2200
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Is Principal Heating System Thermostatically Controlled ?"
    Then I wait until "Lbl_Construction Type" is visible
    Then "Btn_Frame" should exist
    When I click "Btn_Siding"
    Then I wait until "Lbl_Building Occupancy" is visible
    When I click "Btn_Owner"
    Then I wait until "Btn_Tenant" is visible
    When I click "Txt_Market Value"
    When I enter or select "{Doubleclick}" in "Txt_Market Value"
    When I enter or select "\"^{a}\"" in "Txt_Market Value"
    When I enter or select "\"DEL\"" in "Txt_Market Value"
    When I enter or select "430000" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I press "Tab" while focused on "Txt_Heating (Year)"
    When I press "Tab" while focused on "Txt_Cooling (Year)"
    When I press "Tab" while focused on "Txt_Plumbing (Year)"

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0063: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-12ee-5e3a-54da6b77eaf0
    When I enter or select "{SCROLL[5][500px][Center][HorizontalFirst][300ms]}" in "Txt_Market Value"
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    When I click "Btn_Central"
    Then I wait until "Btn_Floor Furnace" exists
    Then I wait until "Btn_More Options_Principal Heat Type" is visible
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible

    # Source step 0064: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0065: Home Characteristics-Heating Details Supplemental Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d0b-a01e-a94b-cfdb0615689f
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0066: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0067: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-9943-24b1-d0a12fceedea
    Then I wait until "Lbl_Roof UL Rating" is visible
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Roof UL Rating"
    When I select "Btn_None_Roof UL Rating"
    Then "Btn_UL3" should be visible
    Then "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." should exist
    Then "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" should exist
    Then "Btn_Chk box_Roof overlaid with more than two layers of shingles" should exist
    Then "Btn_Chk box_Roof overlaid on wood shake or shingle" should exist
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Chk box_Wood roof overlaid on composition shingles"
    When I click "Btn_NEXT"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0069: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-9b29-12ed-82d886d4bae7
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0070: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-41e7-ad24-60a52db5a863
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0071: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-7d62-646a-39ed33f48ea9
    Then I wait until "On Premise Exposures Header" is visible
    Then "Lbl_Special Exposures" should exist
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I enter or select "PGDN" in "Lbl_Dog Exposures"
    When I enter or select "PGDN" in "Lbl_Business Details"
    Then I wait until "Btn_Chk box_Animal Boarding" is visible
    Then I wait until "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" is visible
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"
    When I enter or select "PGDN" in "Lbl_Farm & Livestock Exposures"

    # Source step 0072: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0073: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-720e-70fc-a36c1940e421
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0074: Claims History-Choose to update existing claim | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-2004-4079-a78b35089352
    Then I wait until "Claims History Header" is visible
    When I click "Btn_edit claim pen icon"

    # Source step 0075: Edit Claim-Weather related or not | Module: EQH||Edit Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-7b98-3329-b68aa9577f88
    Then I wait until "Weather Related?" is visible
    When I select "No"
    When I click "Save"

    # Source step 0076: Claims History-Navigate to Discounts | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-af47-cff2-ab9158dacc52
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0077: Discounts/Adjustments-Add auto-home discount | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-9fec-ec47-378785090af4
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    When I click "Btn_Chk box_AUTO-HOME"
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0078: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "9000" milliseconds

    # Source step 0079: Coverages-Edit-Option 1 if needed | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-dc3f-e85d-b2d899100340
    Then I wait until "Lbl_Coverages" is visible
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0080: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-2dc1-6db5-a566079fd305
    When I click "Additional Coverages"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0082: Additional Coverages-Add addtional coverage if needed | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-7882-f123-3a274b782200
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0084: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-09fd-cff9-20bccbecfe50
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0086: Mortgage/Additional Interest-Add or Update  | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-0425-3d4b-cc31fe5b1ac7
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    Then "Btn_ADD MORTGAGE / ADD'L INTEREST" should exist
    When I click "Btn_NEXT"

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0088: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d11-6a6b-906f-1dc1ff0123d3
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

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0090: Submission- Land on Submission page | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-45b7-87c1-4a6d3a11a8d6
    Then I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0097: Submission- UW Referral and add agent comments | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-ae4b-cf1c-eb20c9e8e16d
    Then I wait until "Hdr_Submission Header" is visible
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    When I enter or select "Test" in "Txt_UW1_AgentComments"
    When I click "Btn_Refer to UW_1"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist

    # Source step 0098: OpenUrl | Module: OpenUrl
    # Section: Process | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0102: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-4122-36ea-251f95f20733
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0103: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-4ada-ab58-c5d42a022a28
    # Runtime control: If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0104: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-ec53-6fab-1883ffba5dc4
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"
    When I click "Lbl_Insured Name"
    When I click "Lnk_Policyholder_name"
    When I click "Lnk_Home"
    When I click "Lnk_Pricing"
    When I enter or select "Approved" in "Txt_Underwriting Notes *"
    Then I wait until "Btn_Approve" is visible
    When I click "Btn_Approve"
    Then I wait until "Btn_Log Out" is visible
    When I click "Btn_Log Out"

    # Source step 0105: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0107: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-20be-c0cc-a47af9198eea
    When I close the active browser

    # Source step 0108: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-070a-619a-4f9532f83047
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0109: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-0048-e947-b3c63efcfe38
    Then I wait until "Btn_New Quote" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0110: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-d6c2-006f-8904955c4554
    When I click "Submission"

    # Source step 0111: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0112: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-7fb0-9df1-3fb51f773b2f
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0113: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0114: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-e410-e7d9-090693a8dbc0
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0115: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-03f9-fdbb-035ff808a0fe
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0116: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-297a-d0ad-0d1336acc2a1
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0117: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-2d95-debf-e66911dd201a
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0118: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0119: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-a789-5162-503e79ecc1ad
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0120: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0121: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-8a69-706b-98d2d7d597c2
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0122: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-0a7e-b7b0-975bb5892f6e
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0123: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0124: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-c9c4-a046-52f4e01c47d7
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    When I click "Btn_Transmit_1"

    # Source step 0125: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0126: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-645e-ccb7-832047340649
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0127: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0128: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-4d5c-c0b3-d20669166d34
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Home_PolicyData"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0129: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-c4e2-bad7-cdc5460f9548
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0130: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-58a5-8e29-117fac87a6c1
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0131: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-cfdf-341e-fbacacfc2ae5
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0014 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0015 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0016 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0018 field "Data search filter > Auto" in "TestData - Getting Client Data from TDS" was disabled. Reason:  
#    - Preserved source value: "N"
# 5. Source step 0019 field "FirstName" in "TBox Set Buffer-Setting up TC Name" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "^[A-Z][a-z]{5}$"
# 6. Source step 0019 field "LastName" in "TBox Set Buffer-Setting up TC Name" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "^[A-Z][a-z]{5}$"
# 7. Source step 0019 field "DOB" in "TBox Set Buffer-Setting up TC Name" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED date from Tosca expression "{DATE[][-37y][MM/dd/yyyy]}"
# 8. Source step 0019 field "SSN" in "TBox Set Buffer-Setting up TC Name" was disabled. Reason:  
#    - Preserved source value: a RANDOM value matching "254365120][754365120 random digits/characters"
# 9. Source step 0023 "Enter Account Details" in module "EQ||Account Details" was disabled. Reason: 08.03.24 18:27:37 [ct2452]
#    - VERIFY "Lbl_Account Information" with "True"
#    - VERIFY "Txt_First Name_Account Owner" with "True"
#    - VERIFY "Txt_Middle Name_Account Owner" with "True"
#    - VERIFY "Txt_Last Name_Account Owner" with "True"
#    - INPUT "Txt_DOB" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.DOB"
#    - INPUT "Txt_Best phone_Account Owner" with "9072090736"
#    - INPUT "Txt_Email_Account Owner" with "DICKFERNANDEZ1125@YAHOO.COM"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "Btn_Single" with a blank value
#    - INPUT "Btn_Married" with "X"
#    - INPUT "Txt_Enter a location" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.Street_Address"
#    - WAIT "Txt_Enter a location" with "True"
#    - INPUT "Txt_Enter a location" with "{click}{down}"
#    - INPUT "Txt_owner.address.city_New" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.City"
#    - INPUT "Drpdwn_State" with "NEW MEXICO"
#    - INPUT "Drpdwn_State" with "{RETURN}"
#    - INPUT "Txt_owner.address.zip" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.Zip"
#    - VERIFY "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "Btn_Yes_at least 90 days" with "X"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "Btn_Yes_ClientResides" with "X"
#    - INPUT "Btn_Yes_client resides" with "X"
#    - INPUT "Btn_Next" with "X"
# 10. Source step 0025 "Proposal Start-With Effective Date prior to 90 days from current date" in module "(Old) EQ||Proposal Start" was disabled. Reason: 08.03.24 18:50:49 [ct2452]
#    - WAIT "Btn_PERSONAL AUTO" with "True"
#    - WAIT "Btn_MOTORCYCLE" with "True"
#    - VERIFY "Btn_RECREATIONAL VEHICLE" with "True"
#    - INPUT "Btn_HOME" with "X"
#    - WAIT "Lbl_Select Product Type" with "True"
#    - VERIFY "Btn_SH3-HOMEOWNERS" with "True"
#    - INPUT "Btn_SH3-HOMEOWNERS" with "X"
#    - VERIFY "Btn_SH4-TENANTS" with "True"
#    - VERIFY "Btn_SH6-CONDOMINIUM OWNERS" with "True"
#    - INPUT "Btn_SD1-RENTAL OWNERS" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_Effective Date_1" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][-90d][MM/dd/yyyy]}"
#    - INPUT "Txt_Effective Date_1" with "10"
#    - INPUT "Hdr2" with "X"
#    - INPUT "Drp List_Rating State" with "{Click}"
#    - INPUT "Drp List_NEW MEXICO_1" with "X"
#    - VERIFY "Txt_Agent 5-Digit PCCode" with "True"
#    - INPUT "Txt_Agent 5-Digit PCCode" with "D2102"
#    - INPUT "Lbl_Select Risk Address" with "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Rd Btn_Same as New Account Address" with "X"
#    - INPUT "Btn_Start Quote_1" with "X"
# 11. Source step 0029 "ExpertQuote" in module "Confirm the Client's SSN# Popup-Edit/Confirm" was disabled. Reason: 07.03.24 20:03:23 [ct2452]
#    - VERIFY "DIV_Confirm the Client's SSN#" with "True"
# 12. Source step 0030 "ExpertQuote" in module "Confirm the Client's SSN# Popup-Edit/Confirm" was disabled. Reason: 07.03.24 20:03:23 [ct2452]
#    - INPUT "Lnk_CONFIRM" with "X"
# 13. Source step 0031 "EQ||Proposal Start Proceed & SSN" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 07.03.24 20:03:23 [ct2452]
#    - INPUT "Txt_SSN" with the RUNTIME-DERIVED TDM value "NM_ClientData_Regression.SSN"
#    - INPUT "Lnk_SUBMIT" with "X"
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 14. Source step 0032 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 07.03.24 20:03:23 [ct2452]
#    - WAIT "Lnk_USE EXISTING ACCOUNT" with "True"
#    - VERIFY "Lnk_USE EXISTING ACCOUNT" with "True"
# 15. Source step 0033 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 07.03.24 20:03:23 [ct2452]
#    - INPUT "Lnk_USE EXISTING ACCOUNT" with "X"
# 16. Source step 0034 "Proposal Start-Invalid Address,SSN,Client already exists" in module "EQ||Proposal Start Proceed & SSN" was disabled. Reason: 05.11.23 11:06:58 [ct2453]
#    - INPUT "Lnk_CREATE NEW ACCOUNT" with "X"
# 17. Source step 0035 "Client Selection-Enter Client Info of New or Existing clients" in module "EQ || Client Selection" was disabled. Reason: 07.03.24 19:35:19 [ct2452]
#    - VERIFY "<unnamed value>" with "Client Info"
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with captured runtime value "FirstName"
#    - INPUT "<unnamed value>" with captured runtime value "LastName"
#    - INPUT "<unnamed value>" with captured runtime value "DOB"
#    - VERIFY "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - VERIFY "<unnamed value>" with "True"
#    - VERIFY "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
# 18. Source step 0036 "Account Details-Enter new Account Information" in module "EQ||Account Details" was disabled. Reason: 07.03.24 19:35:19 [ct2452]
#    - VERIFY "<unnamed value>" with "True"
#    - VERIFY "<unnamed value>" with "True"
#    - VERIFY "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with captured runtime value "DOB"
#    - INPUT "<unnamed value>" with "3000000000"
#    - INPUT "<unnamed value>" with "outin@aol.com"
#    - VERIFY "Lbl_Marital Status:" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "3809 Fox Sparrow Trl NW,Albuquerque, New Mexico, USA"
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "{click}{down}"
#    - INPUT "<unnamed value>" with "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Lbl_Have you received mail at this address for at least 90 days?" with "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Have you received mail at this address for at least 90 days?" with "True"
#    - INPUT "<unnamed value>" with "{Invoke[Click]}"
#    - VERIFY "Lbl_Is the account address also where the client resides?" with "True"
#    - INPUT "<unnamed value>" with "{Invoke[Click]}"
#    - INPUT "<unnamed value>" with "X"
# 19. Source step 0037 "Proposal Start-Invalid Address,SSN,Client already exists" in module "(Old) EQ||Proposal Start" was disabled. Reason: 07.03.24 19:49:33 [ct2452]
#    - INPUT "Txt_SSN" with captured runtime value "SSN"
#    - INPUT "Btn_SSN_SUBMIT" with "X"
#    - INPUT "Btn_Confirm client's SSN_CONFIRM" with a blank value
#    - WAIT "Btn_Client Already Exists_CREATE NEW ACCOUNT" with "True"
#    - INPUT "Btn_Client Already Exists_CREATE NEW ACCOUNT" with "X"
# 20. Source step 0039 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 21. Source step 0039 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 22. Source step 0042 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 23. Source step 0042 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 24. Source step 0042 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0042 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 26. Source step 0042 field "Btn_Male" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 27. Source step 0045 field "Btn_Hide Google Maps" in "Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 28. Source step 0045 field "7.1-10.0" in "Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0047 field "Location Header" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0047 field "Lbl_How long have you owned or occupied location?" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 31. Source step 0047 field "Btn_More than 5 years" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0047 field "Btn_More than 5 years" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 33. Source step 0047 field "Btn_Hide Google Maps" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 34. Source step 0047 field "Drp List_Miles to Fire Station-need to check" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0047 field "0-3.0" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0049 field "Location Header" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0049 field "Lbl_How long have you owned or occupied location?" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0049 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "X"
# 39. Source step 0049 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0049 field "Btn_Hide Google Maps" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 41. Source step 0049 field "Drp List_Miles to Fire Station-need to check" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 42. Source step 0049 field "0-3.0" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 43. Source step 0050 field "Location Header" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0050 field "Lbl_How long have you owned or occupied location?" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0050 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0050 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0050 field "Btn_Hide Google Maps" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 48. Source step 0050 field "Drp List_Miles to Fire Station-need to check" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 49. Source step 0050 field "0-3.0" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 50. Source step 0052 field "Btn_Hide Google Maps" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 51. Source step 0053 field "Lbl_Manufactured Home Type" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0053 field "Btn_Singlewide" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0053 field "Btn_Multiwide" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: a blank value
# 54. Source step 0056 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 55. Source step 0061 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0061 field "Btn_Veneer" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 57. Source step 0061 field "Btn_More Options_Construction Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 58. Source step 0061 field "Btn_Fire Resistive" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 59. Source step 0061 field "Btn_Under Construction" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0061 field "Btn_More Options_Building Occupancy" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0061 field "Lbl_Principal Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0061 field "Btn_None" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0061 field "Btn_Central" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 64. Source step 0061 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0061 field "Btn_None_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0061 field "Btn_Central_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 67. Source step 0061 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0061 field "Lbl_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0061 field "Btn_None_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 70. Source step 0061 field "Btn_UL3" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0061 field "Btn_NEXT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 72. Source step 0063 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0063 field "Btn_Frame" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 74. Source step 0063 field "Btn_Siding" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0063 field "Btn_Veneer" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0063 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0063 field "Btn_Owner" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 78. Source step 0063 field "Btn_Tenant" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0063 field "Btn_Under Construction" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 82. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 83. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 84. Source step 0063 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 85. Source step 0063 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 86. Source step 0063 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 87. Source step 0063 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 88. Source step 0063 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 89. Source step 0063 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 90. Source step 0063 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 91. Source step 0063 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 92. Source step 0063 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 93. Source step 0063 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 94. Source step 0063 field "Btn_UL3" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 95. Source step 0063 field "Btn_NEXT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 96. Source step 0065 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 97. Source step 0065 field "Btn_Frame" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 98. Source step 0065 field "Btn_Siding" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0065 field "Btn_Veneer" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0065 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 101. Source step 0065 field "Btn_Owner" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 102. Source step 0065 field "Btn_Tenant" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 103. Source step 0065 field "Btn_Under Construction" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0065 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 105. Source step 0065 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 106. Source step 0065 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 107. Source step 0065 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 108. Source step 0065 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 109. Source step 0065 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 110. Source step 0065 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 111. Source step 0065 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 112. Source step 0065 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 113. Source step 0065 field "Lbl_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0065 field "Btn_None" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 115. Source step 0065 field "Btn_Central" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 116. Source step 0065 field "Btn_Floor Furnace" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 117. Source step 0065 field "Btn_More Options_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 118. Source step 0065 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 119. Source step 0065 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 120. Source step 0065 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 121. Source step 0065 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 122. Source step 0065 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 123. Source step 0065 field "Btn_UL3" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 124. Source step 0065 field "Btn_NEXT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 125. Source step 0067 field "Lbl_Construction Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 126. Source step 0067 field "Btn_Frame" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 127. Source step 0067 field "Btn_Siding" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 128. Source step 0067 field "Btn_Veneer" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 129. Source step 0067 field "Lbl_Building Occupancy" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 130. Source step 0067 field "Btn_Owner" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 131. Source step 0067 field "Btn_Tenant" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 132. Source step 0067 field "Btn_Under Construction" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 133. Source step 0067 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 134. Source step 0067 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 135. Source step 0067 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "\"DEL\""
# 136. Source step 0067 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "350999"
# 137. Source step 0067 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 138. Source step 0067 field "Txt_Electric (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 139. Source step 0067 field "Txt_Heating (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 140. Source step 0067 field "Txt_Cooling (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 141. Source step 0067 field "Txt_Plumbing (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 142. Source step 0067 field "Lbl_Principal Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 143. Source step 0067 field "Btn_None" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 144. Source step 0067 field "Btn_Central" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 145. Source step 0067 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 146. Source step 0067 field "Btn_None_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 147. Source step 0067 field "Btn_Central_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 148. Source step 0067 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 149. Source step 0067 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 150. Source step 0069 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 151. Source step 0069 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 152. Source step 0069 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 153. Source step 0069 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 154. Source step 0069 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 155. Source step 0069 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 156. Source step 0069 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 157. Source step 0069 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 158. Source step 0069 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 159. Source step 0069 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 160. Source step 0070 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 161. Source step 0070 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 162. Source step 0070 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 163. Source step 0070 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 164. Source step 0071 field "Btn_Chk box_Incidental Farming on premise" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 165. Source step 0071 field "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 166. Source step 0071 field "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "X"
# 167. Source step 0071 field "Btn_NEXT" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 168. Source step 0071 field "Btn_NEXT" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 169. Source step 0073 field "On Premise Exposures Header" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 170. Source step 0073 field "Lbl_Other Structures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 171. Source step 0073 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 172. Source step 0073 field "Lbl_Special Exposures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 173. Source step 0073 field "Btn_Chk box_Swimming pool" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 174. Source step 0073 field "Btn_Chk box_None of the Above - Business Details" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 175. Source step 0073 field "Lbl_Dog Exposures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 176. Source step 0073 field "Lbl_Business Details" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 177. Source step 0073 field "Btn_Chk box_Animal Boarding" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 178. Source step 0073 field "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 179. Source step 0073 field "Btn_Chk box_BUSINESS ON PREMISE" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 180. Source step 0073 field "Btn_Chk box_None Of The Above" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 181. Source step 0073 field "Btn_Chk box_Incidental Farming on premise" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 182. Source step 0074 field "Btn_ADD CLAIM" in "Claims History-Choose to update existing claim" was disabled. Reason:  
#    - Preserved source value: "True"
# 183. Source step 0074 field "Btn_NEXT" in "Claims History-Choose to update existing claim" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 184. Source step 0079 field "All Other Peril Deductible_2%" in "Coverages-Edit-Option 1 if needed" was disabled. Reason:  
#    - Preserved source value: a blank value
# 185. Source step 0084 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 186. Source step 0084 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 187. Source step 0084 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 188. Source step 0084 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 189. Source step 0084 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 190. Source step 0084 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 191. Source step 0084 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 192. Source step 0088 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 193. Source step 0088 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 194. Source step 0088 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 195. Source step 0088 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 196. Source step 0090 field "Lbl_Step 1. Review Messages" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
# 197. Source step 0090 field "Txt_UW1_AgentComments" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "Test"
# 198. Source step 0090 field "Btn_Refer to UW_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 199. Source step 0090 field "Btn_Launch To Checklist_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 200. Source step 0090 field "Btn_Launch To Checklist_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 201. Source step 0090 field "Btn_Launch To eSignature_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 202. Source step 0090 field "Lbl_Step 4. Transmit" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 203. Source step 0090 field "Btn_Transmit_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 204. Source step 0090 field "Btn_Issue Home Binder" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 205. Source step 0090 field "Btn_Save and Exit_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 206. Source step 0091 "EQH||Side Menu and Quote Actions-Navigate back to NamedInsured page to select Gender again, remove GenderX 0076 error on submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - INPUT "Named Insureds Summary" with "{Click}"
#    - INPUT "Location" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 207. Source step 0092 "EQH||Named Insureds Summary-Review details or Add Named Insured" in module "EQH||Named Insureds Summary-Review details or Add Named Insured" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - WAIT "Named Insureds Summary Header" with "True"
#    - INPUT "Btn_edit pen icon" with "{Click}"
# 208. Source step 0093 "EQH||Add or Edit Named Insured-Existing Client" in module "EQH||Add or Edit Named Insured-Existing Client" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - WAIT "Add/Edit Named Insured Header" with "True"
#    - INPUT "Txt_Phone Number" with "{SCROLL[3][100px][Center][HorizontalFirst][300ms]}"
#    - INPUT "Btn_Female" with "X"
#    - INPUT "Btn_SAVE AND CONTINUE" with "X"
# 209. Source step 0094 "TBox Wait" in module "TBox Wait" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - INPUT "Duration" with "10000"
# 210. Source step 0095 "EQH||Side Menu and Quote Actions-Navigate back to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 211. Source step 0097 field "Btn_Launch To Checklist_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 212. Source step 0097 field "Btn_Launch To Checklist_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 213. Source step 0097 field "Btn_Launch To eSignature_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 214. Source step 0097 field "Lbl_Step 4. Transmit" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 215. Source step 0097 field "Btn_Transmit_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 216. Source step 0097 field "Btn_Issue Home Binder" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 217. Source step 0097 field "Btn_Save and Exit_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 218. Source step 0099 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 219. Source step 0100 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 220. Source step 0101 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 221. Source step 0106 "Close the Express UI page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 08.03.24 16:14:54 [ct2452]
#    - INPUT "Caption" with "Home"
#    - INPUT "Keys" with "^(w)"
# 222. Source step 0109 field "Btn_New Quote" in "Search for the Quote in EQ" was disabled. Reason:  
#    - Preserved source value: "X"
# 223. Source step 0110 field "Transmit Confirmation" in "EQH||Side Menu and Quote Actions-Navigate to Submission page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 224. Source step 0112 field "Hdr_Submission Header" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 225. Source step 0112 field "Btn_Launch To eSignature_1" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 226. Source step 0112 field "Lbl_Step 4. Transmit" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 227. Source step 0112 field "Btn_Transmit_1" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 228. Source step 0112 field "Btn_Issue Home Binder" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 229. Source step 0112 field "Btn_Save and Exit_1" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 230. Source step 0124 field "Btn_Launch To Checklist_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 231. Source step 0124 field "Btn_Launch To eSignature_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 232. Source step 0124 field "Btn_Transmit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 233. Source step 0124 field "Btn_Issue Home Binder" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 234. Source step 0124 field "Btn_Save and Exit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 235. Source step 0126 field "Transmit Confirmation Header" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 236. Source step 0126 field "Submission" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 237. Source step 0128 field "Data structure > FirstName" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "FirstName"
# 238. Source step 0128 field "Data structure > LastName" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "LastName"
# 239. Source step 0128 field "Data structure > DOB" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "DOB"
# 240. Source step 0128 field "Data structure > SSN" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "SSN"
# 241. Source step 0129 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
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
