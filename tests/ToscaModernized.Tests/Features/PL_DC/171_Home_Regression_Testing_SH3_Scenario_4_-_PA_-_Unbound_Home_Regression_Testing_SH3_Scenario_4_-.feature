# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 171_Home_Regression_Testing_SH3_Scenario_4_-_PA_-_Unbound_Home_Regression_Testing_SH3_Scenario_4_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH3 Scenario #4 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH3 Scenario #4 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH3 Scenario #4 - PA - Unbound using representative iteration Home Regression Testing SH3 Scenario #4 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-4c7c-98a4-80bdfa472a63
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-ae85-02f7-dad669b3b0dd
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-e83b-e9af-6cc3df1e3594
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-6bab-711d-bbf042d7607f
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "7000000000" in "<unnamed value>"
    When I enter or select "ointyut@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "116 Howard St, Howard, PA 16841" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-b081-da62-d925ac31039c
    Then "Btn_PERSONAL AUTO" should exist
    Then "Btn_MOTORCYCLE" should exist
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    Then "Btn_SH3-HOMEOWNERS" should be visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
    Then "Btn_SH6-CONDOMINIUM OWNERS" should exist
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-dffb-6032-b68fe28a8243
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-db83-e904-2cb3d96d4b41
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-6e0a-c42f-b2ef0d37e0cc
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-ddb9-35bf-5611b8d000d2
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

    # Source step 0036: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-0583-74e0-02453c505bd8
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0037: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-28c1-8bc2-07ec2380e3ac
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0038: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-e912-48f7-4572078ae146
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    Then "Btn_C/O" should exist
    Then "Lbl_Email Type" should exist
    Then "Lbl_Gender" should exist
    Then "Btn_Male" should exist
    When I click "Btn_Female"
    Then I wait until "Lbl_Marital Status" is visible
    Then I wait until "Btn_Single" is visible
    Then I wait until "Btn_Married" is visible
    Then "Lbl_Relation To Account Owner" should be visible
    Then "Btn_Son" should be visible
    Then "Btn_Daughter" should exist
    When I enter or select "{MOUSE[CLICK][Jump][5%][5%]}" in "Btn_SAVE AND CONTINUE"

    # Source step 0039: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-ad87-99ae-4f4a4fb8a1c8
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0040: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0041: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-ad4f-7098-022f488091ff
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-b5a2-aac1-2fc68b33dea7
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0048: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dda-9782-8bad-32dfb260fd8f
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0049: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dea-3eb3-874b-58bb5c5d627d
    When I enter or select "PGUP" in "Home Characteristics Header"
    Then I wait until "Txt_Year Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Year Built"
    When I enter or select "\"{DEL}\"" in "Txt_Year Built"
    When I enter or select "1969" in "Txt_Year Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "960" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    Then "Btn_Shingles, Architectural" should exist
    When I click "Btn_Shingles, Asphalt/Fiberglass"
    Then "Lbl_Structure Type" should be visible
    When I click "Btn_Single Family"
    Then I wait until "Lbl_Home Type" is visible
    When I click "Btn_Conventional"
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Btn_Modular Home"
    Then "Lbl_Is Principal Heating System Thermostatically Controlled ?" should exist
    When I select "Btn_YES"
    Then I wait until "Btn_GET VALUATION" is visible
    When I click "Btn_GET VALUATION"

    # Source step 0050: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0051: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3deb-ddf1-c42d-e8ca05d2411a
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0052: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3deb-8b26-abe4-a2660535ecba
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0053: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3deb-3ef9-7535-d5d12bb15385
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0054: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3deb-3a3d-8a4d-252cd8431a5a
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0055: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3deb-9430-82c7-486cb94fc02d
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0056: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0057: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3deb-5da6-b122-8c88e212357c
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Is Principal Heating System Thermostatically Controlled ?"
    Then I wait until "Lbl_Construction Type" is visible
    When I click "Btn_Frame"
    Then "Btn_Siding" should exist
    Then "Btn_Veneer" should exist
    When I select "Btn_More Options_Construction Type"
    When I click "Btn_Fire Resistive"
    Then I wait until "Lbl_Building Occupancy" is visible
    When I click "Btn_Owner"
    Then I wait until "Btn_Tenant" is visible
    Then I wait until "Btn_Under Construction" is visible
    Then I wait until "Btn_More Options_Building Occupancy" is visible
    When I click "Txt_Market Value"
    When I enter or select "{Doubleclick}" in "Txt_Market Value"
    When I enter or select "\"^{a}\"" in "Txt_Market Value"
    When I enter or select "\"DEL\"" in "Txt_Market Value"
    When I enter or select "237000" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I press "Tab" while focused on "Txt_Heating (Year)"
    When I press "Tab" while focused on "Txt_Cooling (Year)"
    When I press "Tab" while focused on "Txt_Plumbing (Year)"

    # Source step 0058: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0059: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-30f1-22dd-65745cfb4015
    Then I wait until "Btn_Under Construction" exists
    When I enter or select "{SCROLL[5][500px][Center][HorizontalFirst][300ms]}" in "Txt_Market Value"
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-89c2-2342-52454eb8a8fd
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0063: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-49b0-6317-4e56a06f6aca
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

    # Source step 0064: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0065: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-5086-a2ed-6b1db762e970
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0066: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-c5e2-49f9-a27033fc7aa4
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0067: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-cc81-77ca-e34b9bcd30bf
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

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0069: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-d1ca-cec8-30c1bb692e8f
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0070: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-591a-514c-37c61fb81ce5
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0071: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-394e-3a82-9861acb0fb62
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0072: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0073: EQH||Coverages-Edit-Option 1 and choose Peril Ded. of 2% | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-10fe-937b-acd677765e34
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Btn_Reset Fields" is visible
    When I enter or select "{SCROLL[9][1000px][Center][HorizontalFirst][100ms]}" in "Btn_Reset Fields"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_2%"
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0075: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-5a02-7893-7dff9c42727f
    When I click "Additional Coverages"

    # Source step 0076: Additional Coverages-Add 'Scheduled Personal Property' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-ac0c-d494-37b3c19274d0
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Scheduled Personal Property" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0077: EQH||Additional Coverages-Contents Coverages-Select 'Add Scheduled Personal Property' | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-452f-a1b7-72950c5dcb46
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I click "Btn_ADD SCHEDULED PERSONAL PROPERTY"

    # Source step 0078: EQH||Scheduled Coverage-Contents Covg-Scheduled Personal Property | Module: EQH||Scheduled Coverage-Contents Covg-Scheduled Personal Property
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-d563-8c7f-81fe7fee65fd
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

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0080: Additional Coverages-Add addtional coverage(Child Care Coverage) | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-3ff1-7c42-ea9958729b26
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Child Care Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "Chk Box_Child Care Coverage_SH-9695"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0082: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-bbfc-9daa-d43db660723a
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0084: Mortgage/Additional Interest-Add or Update  | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-c75d-e32c-56cbb5f85bcc
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    Then "Btn_ADD MORTGAGE / ADD'L INTEREST" should exist
    When I click "Btn_NEXT"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0086: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ded-acac-1bef-9c2980922515
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

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0129: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0131: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0133: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0134: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-4ebf-fefa-29f131fd1c58
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

    # Source step 0135: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-14ce-ab42-a7cb90f6d7a0
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0137: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-4159-d33b-ee441dcf08fa
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0138: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3dfd-0939-b60a-41e0d8c01c1e
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
# 6. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 8. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 10. Source step 0034 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 11. Source step 0035 "TBox Partial Buffer-Extract the Quote Number" in module "TBox Partial Buffer" was disabled. Reason: 25.01.24 17:19:02 [ct2452]
#    - INPUT "Buffer" with "QuoteNumber"
#    - INPUT "Value" with captured runtime value "LNQuoteNumber"
#    - INPUT "Last" with "12"
# 12. Source step 0038 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 13. Source step 0038 field "Lbl_Phone Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 14. Source step 0038 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 15. Source step 0038 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 16. Source step 0038 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 17. Source step 0041 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 18. Source step 0043 field "Location Header" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0043 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0043 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0043 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0043 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 23. Source step 0043 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0043 field "0-3.0" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 25. Source step 0045 "Verify Order Wildfire Risk Score is enabled" in module "EQH||Location" was disabled. Reason: 11.03.24 17:22:04 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "+ ORDER WILDFIRE RISK SCORE" with "True"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 26. Source step 0046 "Get the the Wildfore Risk Score for property" in module "EQH||Location" was disabled. Reason: 11.03.24 17:22:04 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "+ ORDER WILDFIRE RISK SCORE" with "X"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 27. Source step 0047 "TBox Wait" in module "TBox Wait" was disabled. Reason: 11.03.24 17:22:04 [ct2452]
#    - INPUT "Duration" with "2000"
# 28. Source step 0048 field "Location Header" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 29. Source step 0048 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0048 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0048 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0048 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 33. Source step 0048 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0048 field "0-3.0" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0048 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 36. Source step 0048 field "< 601" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 37. Source step 0049 field "Btn_Manufactured Home" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0052 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0057 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0057 field "Lbl_Principal Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 41. Source step 0057 field "Btn_None" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0057 field "Btn_Central" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 43. Source step 0057 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0057 field "Btn_None_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0057 field "Btn_Central_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 46. Source step 0057 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0057 field "Lbl_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0057 field "Btn_None_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 49. Source step 0057 field "Btn_UL3" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0057 field "Btn_NEXT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 51. Source step 0059 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0059 field "Btn_Frame" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0059 field "Btn_Siding" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0059 field "Btn_Veneer" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0059 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0059 field "Btn_Owner" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 57. Source step 0059 field "Btn_Tenant" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 60. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 61. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 62. Source step 0059 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 63. Source step 0059 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 64. Source step 0059 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 65. Source step 0059 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 66. Source step 0059 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 67. Source step 0059 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 68. Source step 0059 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0059 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 70. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0059 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 72. Source step 0059 field "Btn_UL3" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0059 field "Btn_NEXT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 74. Source step 0065 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 75. Source step 0065 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 76. Source step 0065 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0065 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0065 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0065 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0065 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0065 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 82. Source step 0065 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 83. Source step 0065 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 84. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 86. Source step 0066 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 87. Source step 0066 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 88. Source step 0067 field "Lbl_Other Structures" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 89. Source step 0067 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 90. Source step 0067 field "Btn_Chk box_Incidental Farming on premise" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 91. Source step 0067 field "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0067 field "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "X"
# 93. Source step 0067 field "Btn_NEXT" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0067 field "Btn_NEXT" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 95. Source step 0069 field "On Premise Exposures Header" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0069 field "Lbl_Other Structures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 97. Source step 0069 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 98. Source step 0069 field "Lbl_Special Exposures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0069 field "Btn_Chk box_Swimming pool" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0069 field "Btn_Chk box_None of the Above - Business Details" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 101. Source step 0069 field "Lbl_Dog Exposures" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 102. Source step 0069 field "Lbl_Business Details" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 103. Source step 0069 field "Btn_Chk box_Animal Boarding" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0069 field "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 105. Source step 0069 field "Btn_Chk box_BUSINESS ON PREMISE" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 106. Source step 0069 field "Btn_Chk box_None Of The Above" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 107. Source step 0069 field "Btn_Chk box_Incidental Farming on premise" in "On Premise Exposures-Provide details and go to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 108. Source step 0073 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1 and choose Peril Ded. of 2%" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 109. Source step 0080 field "Chk Box_First Coverage that shows after search by coverage name in the Coverage Catalog" in "Additional Coverages-Add addtional coverage(Child Care Coverage)" was disabled. Reason:  
#    - Preserved source value: "X"
# 110. Source step 0082 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 111. Source step 0082 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0082 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 113. Source step 0082 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 114. Source step 0082 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 115. Source step 0082 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 116. Source step 0082 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 117. Source step 0086 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 118. Source step 0086 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 119. Source step 0086 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 120. Source step 0086 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 121. Source step 0088 "Submission- Land on Submission page" in module "EQ||Submission" was disabled. Reason: 01.02.24 12:14:10 [ct2452]
#    - WAIT "Hdr_Submission Header" with "True"
#    - VERIFY "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_UW1_AgentComments" with "Test"
#    - INPUT "Btn_Refer to UW_1" with "{Click}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - VERIFY "Lbl_Step 4. Transmit" with "True"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - VERIFY "Btn_Issue Home Binder" with "True"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 122. Source step 0089 "EQH||Side Menu and Quote Actions-Navigate back to NamedInsured page to select Gender again, remove GenderX 0076 error on submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: Not needed as GenderX error is fixed
#    - INPUT "Named Insureds Summary" with "{Click}"
#    - INPUT "Location" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 123. Source step 0090 "EQH||Named Insureds Summary-Review details or Add Named Insured" in module "EQH||Named Insureds Summary-Review details or Add Named Insured" was disabled. Reason: Not needed as GenderX error is fixed
#    - WAIT "Named Insureds Summary Header" with "True"
#    - INPUT "Btn_edit pen icon" with "{Click}"
# 124. Source step 0091 "EQH||Add or Edit Named Insured-Existing Client" in module "EQH||Add or Edit Named Insured-Existing Client" was disabled. Reason: Not needed as GenderX error is fixed
#    - WAIT "Add/Edit Named Insured Header" with "True"
#    - INPUT "Txt_Phone Number" with "{SCROLL[3][100px][Center][HorizontalFirst][300ms]}"
#    - INPUT "Btn_Female" with "X"
#    - INPUT "Btn_SAVE AND CONTINUE" with "X"
# 125. Source step 0092 "TBox Wait" in module "TBox Wait" was disabled. Reason: Not needed as GenderX error is fixed
#    - INPUT "Duration" with "10000"
# 126. Source step 0093 "EQH||Side Menu and Quote Actions-Navigate back to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: Not needed as GenderX error is fixed
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 127. Source step 0094 "Submission- UW Referral and add agent comments" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - WAIT "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_UW1_AgentComments" with "Test"
#    - INPUT "Btn_Refer to UW_1" with "{Click}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - VERIFY "Lbl_Step 4. Transmit" with "True"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - VERIFY "Btn_Issue Home Binder" with "True"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 128. Source step 0095 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - INPUT "Duration" with "10000"
# 129. Source step 0096 "OpenUrl" in module "OpenUrl" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 130. Source step 0097 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 131. Source step 0098 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 132. Source step 0099 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 133. Source step 0100 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - VERIFY "Lbl_Login ID" with "True"
# 134. Source step 0101 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 135. Source step 0102 "EU||Home" in module "EU||Home" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
#    - INPUT "Lbl_Insured Name" with "X"
#    - INPUT "Lnk_Policyholder_name" with "X"
#    - INPUT "Lnk_Home" with "X"
#    - INPUT "Lnk_Pricing" with "X"
#    - INPUT "Txt_Underwriting Notes *" with "Approved"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - WAIT "Btn_Log Out" with "True"
#    - INPUT "Btn_Log Out" with "X"
# 136. Source step 0103 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:30 [ct2452]
#    - INPUT "Duration" with "12000"
# 137. Source step 0104 "Close the Express UI page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 08.03.24 16:38:06 [ct2452]
#    - INPUT "Caption" with "Home*"
#    - INPUT "Keys" with "^(w)"
# 138. Source step 0105 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 20.03.24 17:48:43 [ct2452]
#    - INPUT "Title" with "Home"
# 139. Source step 0106 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:43 [ct2452]
#    - INPUT "Duration" with "5000"
# 140. Source step 0107 "EQH||Quote Actions-Save and Exit the current Quote" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 20.03.24 17:48:43 [ct2452]
#    - INPUT "Btn_QUOTE ACTIONS" with "X"
#    - WAIT "Btn_Quote Actions_Save and Exit" with "True"
#    - INPUT "Btn_Quote Actions_Save and Exit" with "X"
# 141. Source step 0108 "Search for the Quote in EQ" in module "EQ||New Quote" was disabled. Reason: 20.03.24 17:48:43 [ct2452]
#    - WAIT "Btn_New Quote" with "True"
#    - INPUT "Btn_New Quote" with "X"
#    - INPUT "Txt_QuoteSearch_Input" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search_1" with "{Click}"
# 142. Source step 0109 "EQH||Side Menu and Quote Actions-Navigate to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 20.03.24 17:48:43 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 143. Source step 0110 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:43 [ct2452]
#    - INPUT "Duration" with "5000"
# 144. Source step 0111 "EQH||Side Menu and Quote ActionsNavigate to Location page to remove WildFire error on submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 29.01.24 13:32:45 [ct2452]
#    - INPUT "Location" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 145. Source step 0112 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.01.24 13:32:45 [ct2452]
#    - INPUT "Duration" with "5000"
# 146. Source step 0113 "EQH||Side Menu and Quote Actions-Navigate back to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 29.01.24 13:32:57 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 147. Source step 0114 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
# 148. Source step 0115 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - INPUT "Duration" with "10000"
# 149. Source step 0116 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 150. Source step 0117 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 151. Source step 0118 "eChecklist-Click the documents/links in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 152. Source step 0119 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 153. Source step 0120 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:51 [ct2452]
#    - INPUT "Duration" with "10000"
# 154. Source step 0121 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:20:06 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 155. Source step 0122 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:20:06 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 156. Source step 0123 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 157. Source step 0124 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:20:06 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 158. Source step 0125 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:48:59 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 159. Source step 0126 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:48:59 [ct2452]
#    - INPUT "Duration" with "10000"
# 160. Source step 0127 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:48:59 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 161. Source step 0128 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:48:59 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 162. Source step 0130 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 15.03.24 15:06:30 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 163. Source step 0132 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 15.03.24 15:06:35 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
#    - INPUT "Submission" with "{Click}"
# 164. Source step 0134 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 165. Source step 0134 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 166. Source step 0134 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 167. Source step 0135 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 168. Source step 0135 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 169. Source step 0136 "TBox Partial Buffer-Compare the Total Premium from PricingDetails and TransmitConfirmation" in module "TBox Partial Buffer" was disabled. Reason: 15.03.24 15:06:56 [ct2452]
#    - INPUT "Buffer" with "Pricing Details_Total Premium"
#    - VERIFY "Value" with captured runtime value "Premium"
#    - INPUT "Last" with "12"
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
