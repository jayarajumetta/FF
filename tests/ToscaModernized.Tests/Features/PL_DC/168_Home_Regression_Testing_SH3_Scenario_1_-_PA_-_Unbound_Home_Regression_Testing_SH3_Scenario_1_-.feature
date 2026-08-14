# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 168_Home_Regression_Testing_SH3_Scenario_1_-_PA_-_Unbound_Home_Regression_Testing_SH3_Scenario_1_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH3 Scenario #1 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH3 Scenario #1 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH3 Scenario #1 - PA - Unbound using representative iteration Home Regression Testing SH3 Scenario #1 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-95af-16f0-08eba9b8de98
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-f04f-92b7-673e0976a33d
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-1490-47e1-35e1932b75a5
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-729a-1384-7d2854b60da2
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "5000000000" in "<unnamed value>"
    When I enter or select "gwsadios@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "813 Sandbank Rd, Mount Holly Springs, PA 17065" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-cf44-29fe-9bedda576d14
    Then I wait until "Btn_PERSONAL AUTO" is visible
    Then I wait until "Btn_MOTORCYCLE" is visible
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then "Btn_SH3-HOMEOWNERS" should be visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-3d63-60bf-1c5dd1c47bbb
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-be76-5b53-14375516098b
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-ed0b-3661-6784432d0f6a
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-046a-ce10-9acc78d4bab5
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-a588-1be8-587f9b0adb3c
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0036: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-bfdc-fca1-431780319e66
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0037: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-efd7-b03b-4b0c1fe4e056
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-e9e2-4923-abc7064449bb
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0040: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-8f5a-1059-c821afc09a97
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d75-5a15-1555-b7ec578d94fe
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0044: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-786f-cb16-3ef9bbd7797a
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0045: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-a117-8109-f2b2b8c3d064
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0047: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-5e6f-6650-28f56dfaf526
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0048: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-b8c4-702f-0f705140c8cd
    When I enter or select "PGUP" in "Home Characteristics Header"
    Then I wait until "Txt_Year Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Year Built"
    When I enter or select "\"{DEL}\"" in "Txt_Year Built"
    When I enter or select "1939" in "Txt_Year Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "1246" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    Then "Btn_Shingles, Asphalt/Fiberglass" should exist
    When I select "Btn_More Options_Roof Type"
    When I click "Shingles, Wood"
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

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0050: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-1256-8183-9982e94e2187
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0051: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-98c8-e8c4-9dcf3a939abc
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0052: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-c524-9668-c652b8a39ac8
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0053: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-8606-2232-c1469f08a3d3
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0054: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-9996-b761-c1fd932743a7
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0056: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-9349-8566-416f04b08b9d
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Is Principal Heating System Thermostatically Controlled ?"
    Then I wait until "Lbl_Construction Type" is visible
    When I click "Btn_Frame"
    Then I wait until "Lbl_Building Occupancy" is visible
    When I click "Btn_Owner"
    Then I wait until "Btn_Tenant" is visible
    When I click "Txt_Market Value"
    When I enter or select "{Doubleclick}" in "Txt_Market Value"
    When I enter or select "\"^{a}\"" in "Txt_Market Value"
    When I enter or select "\"DEL\"" in "Txt_Market Value"
    When I enter or select "360500" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I enter or select "2023" in "Txt_Heating (Year)"
    Then I wait until "Txt_Cooling (Year)" is visible
    When I enter or select "\"^{a}\"" in "Txt_Cooling (Year)"
    When I enter or select "\"^{a}\"" in "Txt_Cooling (Year)"
    When I enter or select "2023" in "Txt_Cooling (Year)"
    When I enter or select "\"^{a}\"" in "Txt_Roof (Year)"
    When I enter or select "\"^{a}\"" in "Txt_Roof (Year)"
    When I enter or select "2023" in "Txt_Roof (Year)"
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Btn_Breakers"

    # Source step 0057: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0058: EQH||Home Characteristics_SH3_Electrical Details | Module: EQH||Home Characteristics_SH3_Electrical Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-46b1-aadd-4c77451e70d8
    When I click "Breakers"
    Then "Lbl_Rating of Main Power?" should exist
    When I click "100 amp or more"
    When I click "GenericGUI-Type of Wiring"
    When I click "BX"
    Then I wait until "Lbl_Residence without Main Circuit Breakers or Subpanel Circuit Breakers?" is visible
    When I select "No"
    Then "Lbl_Make of Electrical Panels" should exist
    When I click "Other"

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0060: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-dd2f-4104-eba8c047567d
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    When I click "Btn_Central"
    Then I wait until "Btn_Floor Furnace" exists
    Then I wait until "Btn_More Options_Principal Heat Type" is visible
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible

    # Source step 0061: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0062: Home Characteristics-Heating Details Supplemental Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-3ebe-87d5-e3c3e3a4874a
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0063: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0064: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-f7d9-4a62-0d3f3f127e57
    Then I wait until "Lbl_Roof UL Rating" is visible
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Roof UL Rating"
    When I click "Btn_UL4"
    When I click "Btn_NEXT"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0066: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-d7f6-9cb2-58248fe9cc73
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0067: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-03d3-126b-fe2b36e66e93
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0068: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-7bd5-bb0c-e25be8597f4e
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I enter or select "PGDN" in "Lbl_Dog Exposures"
    When I click "Btn_Chk box_Dogs on Premise"
    When I enter or select "Lana" in "Txt_animal_Name"
    When I click "Gender"
    When I click "Female ( Spayed)"
    When I enter or select "\"^{a}\"" in "Txt_animal_YearBorn"
    When I enter or select "\"{DEL}\"" in "Txt_animal_YearBorn"
    When I enter or select "2022" in "Txt_animal_YearBorn"
    When I click "Primary Breed"
    When I click "Australian Shepherd"
    When I enter or select "PGDN" in "Lbl_Business Details"
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"
    When I enter or select "PGDN" in "Lbl_Farm & Livestock Exposures"

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0070: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-3b35-745e-3cbca197071d
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0071: Claims History-Add claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-d384-d434-6566b68ab134
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0072: EQH||Add Non-Weather Claim 01 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-e72c-1bcd-6dc2d9aaa97a
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

    # Source step 0073: Claims History-Choose to Add Claim 02 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-6a8a-8d0e-0131e4b65234
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0074: EQH||Add Non-Weather Claim 02 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-9160-91d3-d81e9bb4dded
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

    # Source step 0075: Claims History-Choose to Add Claim 03 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-959e-ab5f-d61a7b4edf0e
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0076: EQH||Add Non-Weather Claim 03 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-6bfe-4347-b5bf2bb111b4
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

    # Source step 0077: Claims History-Click Next to move to Discounts page | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-6b20-e9ef-7e19382509e8
    Then I wait until "Claims History Header" is visible
    When I click "Btn_NEXT"

    # Source step 0078: Discounts/Adjustments-Choose Central Fire, Central Burglar Alarm discount | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-8ca1-1cbc-d388352765db
    Then I wait until "Discounts/Adjustments Header" is visible
    When I click "Btn_Chk box_AUTO-HOME"
    Then "Lbl_Three Line Discount?" should exist
    When I click "Btn_All Other"
    When I click "Btn_Chk box_Central Fire Alarm"
    Then I wait until "Btn_Chk box_Local Burglar Alarm" is visible
    When I click "Btn_Chk box_Central Burglar Alarm"
    When I click "Btn_NEXT"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0080: EQH||Coverages-Edit-Option 1-Update All Other Peril Deductible 1%,Coverage B, Coverage C | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-d748-8f04-7649d16da783
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Btn_Reset Fields" is visible
    When I enter or select "{SCROLL[9][1000px][Center][HorizontalFirst][100ms]}" in "Btn_Reset Fields"
    When I enter or select "\"^{a}\"" in "Txt_B.Other Structures"
    When I enter or select "39000" in "Txt_B.Other Structures"
    When I enter or select "\"^{a}\"" in "Txt_C.Personal Property"
    When I enter or select "300000" in "Txt_C.Personal Property"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_1%"
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0083: Additional Coverages-Add 'Ordinance Or Law Coverage – 50% Loss Limit' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-e383-8960-b9f7522b19bb
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Ordinance Or Law Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[2][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $2 > $1"

    # Source step 0084: Additional Coverages-Add 'Enhanced Loss Settlement Factor' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-74f3-b76c-cab67e519311
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Enhanced Loss" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[2][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0086: Additional Coverages-Add 'Blanket Jewelry, Watches, And Furs Coverage - $5,000' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-3ebc-af07-121787f467ec
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Blanket Jewelry" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0087: Additional Coverages-Add 'Increase For Theft of Tools and toolboxes' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-ad2d-1015-a2cdb0f87d6c
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Theft of Tools and toolboxes" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0088: EQH||Additional Coverages-Contents Coverages-Update 'Increase For Theft Of Tools And Toolboxes' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-4ced-ff76-65bd1cf290d8
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I enter or select "8000" in "Txt_Increase For Theft Of Tools And Toolboxes"
    When I click "Btn_Personal Use"
    When I click "Btn_Next"

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0090: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-8d0b-ba0b-ef9e99a36e62
    When I click "Additional Coverages"

    # Source step 0091: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0092: Additional Coverages-Add 'Increased Limits For Home Computer' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-32ec-49ec-c2a5ff22f193
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increased Limits For Home Computer" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0093: EQH||Additional Coverages-Contents Coverages-Update 'Increased Limits For Home Computer' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-bb42-a05d-cdcd61fd6cac
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I enter or select "\"^{a}\"" in "Txt_Increased Limits For Home Computer Hardware And Software"
    When I enter or select "2000" in "Txt_Increased Limits For Home Computer Hardware And Software"
    When I click "Btn_Next"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0095: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-2243-e28d-b82e1940131f
    When I click "Additional Coverages"

    # Source step 0096: Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-4d74-833e-92f4c5c3856c
    When I enter or select "Increased Limit For Lawn Implements" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0097: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0098: EQH||Additional Coverages-Contents Coverages-Update 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d7b-320f-71a9-234681546bed
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I enter or select "15000" in "Txt_Increased Limits For Lawn Implements And Service Vehicles"
    When I click "Btn_Next"

    # Source step 0099: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0100: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-88eb-5bc5-96f48e07711a
    When I click "Additional Coverages"

    # Source step 0101: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0102: Additional Coverages-Add 'Increased Limits On Personal Property In Other Residences ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-af4f-aff6-016fc3924345
    When I enter or select "Increased Limits On Personal Property In Other Residences" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0103: EQH||Additional Coverages-Contents Coverages-Select 'Add Pers Prop Res Location' | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-3b8d-5a89-17d596e85118
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I click "Btn_+ ADD PERS PROP RES LOCATION"

    # Source step 0104: EQH||Scheduled Coverage-Contents Covg-Increased Limits On Personal Property In Other Residences | Module: EQH||Scheduled Coverage-Contents Covg-Increased Limits On Personal Property In Other Residences
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-cf05-051f-fb30f7455fb6
    When I enter or select "6244 Fiddle Lake Road, Union Dale, PA 18470" in "Txt_Inc Limits Pers Prop Other Res Details_Location"
    When I enter or select "{click}{down}" in "Txt_Inc Limits Pers Prop Other Res Details_Location"
    When I click "SAVE"

    # Source step 0105: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0106: Additional Coverages-Add 'Increased Coverage For Personal Property In Self Storage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-ddd0-bb4d-87e3c9941db5
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increased Coverage For Personal Property In Self Storage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0107: Additional Coverages-Add 'Business Merchandise Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-8d10-2c16-88169f40c812
    When I enter or select "Business Merchandise Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0109: Additional Coverages-Add 'Broadened Water Backup Of Sewers And Drains' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-ff57-5d73-7a3c8f75ee4c
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Broadened Water Backup" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0110: EQH||Additional Coverages-Dwelling Coverages-Update 'Broadened Water Backup Of Sewers And Drains' amount & LAC values | Module: EQH||Additional Coverages-Dwelling Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-8661-728e-fadb58e3e5be
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "Btn_$5,000"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0111: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0112: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-c5d7-9eb0-936d96f0d600
    When I click "Additional Coverages"

    # Source step 0113: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0114: Additional Coverages-Add 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-e3a3-fa8b-aa6954b550a7
    When I enter or select "Credit Card, Fund Transfer Card" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0115: EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-c555-745c-a66501ab84d9
    When I click "Btn_$2,000"
    When I click "Btn_Next"

    # Source step 0116: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0117: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-c60f-b168-29fb0af862e3
    When I click "Additional Coverages"

    # Source step 0118: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0119: Additional Coverages-Add 'Personal Injury Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-c373-2799-8bd09f7af091
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Personal Injury Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0120: EQH||Additional Coverages-Liability Coverages-Update 'Personal Injury Coverage' coverage/endorsement | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-8a3f-8e10-b20d40acb1c7
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I select "Btn_No"
    When I click "Btn_Next"

    # Source step 0121: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0122: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-748d-c802-893ad56dd369
    When I click "Additional Coverages"

    # Source step 0123: Additional Coverages-Add 'Office, Professional, Private School Or Studio Use - Residence Premises' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-6939-7bf0-b9828755d075
    When I enter or select "Office, Professional, Private School" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0124: EQH||Additional Coverages-Liability Coverages-Update 'Office, Professional, Private School Or Studio Use - Residence Premises' | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-9b2b-067f-3bbbcb93744e
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "Sole Proprietorship"
    When I click "One Chair Beauty or Barber Shop"
    When I click "Separate Structure on Premises"
    When I click "$7,500"
    When I enter or select "\"^{a}\"" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "\"^{DEL}\"" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "6000" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "18000" in "Txt_OfficeProfessionalPrivateSchool_ApproximateAnnualGrossRevenues"
    When I click "Btn_Next"

    # Source step 0125: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0126: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-89ca-0840-68418feddb3f
    When I click "Additional Coverages"

    # Source step 0127: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0128: Additional Coverages-Add 'Other Structure Restriction' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-6bd4-ea1d-b535ff63db90
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Other Structure Restriction" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[2][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0129: Additional Coverages-Premises Coverages-Choose to add other structure location | Module: EQH||Additional Coverages-Premises Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-fe55-e3d5-192ca4adbccb
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "H1_Header Additional Coverages"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "+ ADD OTHER STRUCTURE LOCATION"

    # Source step 0130: EQH||Additional Coverages-Premises Covg-Other Structure Location/Restriction | Module: EQH||Additional Coverages-Premises Covg-Other Structure Location/Restriction
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-3ed4-6b6c-68d9a88f90ba
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "H1_Header Scheduled Coverage"
    When I enter or select "813 Sandbank Rd, Mount Holly Springs, PA 17065" in "Txt_Address-Enter a location"
    When I enter or select "{click}{down}" in "Txt_Address-Enter a location"
    When I enter or select "Detached" in "Txt_OtherStructureRestriction-Building Description"
    When I enter or select "$25000" in "Txt_OtherStructureRestriction-Building Value"
    When I click "Btn_SAVE"

    # Source step 0131: Additional Coverages-Click Next to move to Pricing Details page | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-5447-8c80-6025dcf3b73e
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0132: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0133: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-af5e-705d-ab5d4a11845d
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0134: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0135: Mortgage/Additional Interest-Add Additional Interest | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-9bda-61ca-d5279d4f8aac
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0138: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0139: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d8b-11f0-3587-5aafc87829ca
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

    # Source step 0140: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0171: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0173: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0175: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0176: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d9a-eef8-f642-c456b2123af3
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

    # Source step 0177: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d9a-cdda-914a-4ef7891f4d98
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0178: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d9b-8058-b7f6-53bd7d0a3f38
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0179: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d9b-c568-6be9-0190ec3df7a4
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
# 5. Source step 0029 field "Lbl_Select Product Type" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 6. Source step 0029 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 9. Source step 0034 field "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) CONVICTED OF ARSON IN THE LAST 5 YEARS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0034 field "Btn_None Of The Above_Client ER" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 12. Source step 0034 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 13. Source step 0034 field "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0034 field "Btn_None Of The Above_Property Eligibility Restrictions_SH4" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0037 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0037 field "Btn_C/O" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0037 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 18. Source step 0037 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 19. Source step 0037 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 20. Source step 0037 field "Btn_Married" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0037 field "Btn_Son" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0040 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 23. Source step 0040 field "7.1-10.0" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 24. Source step 0042 field "Location Header" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0042 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 26. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 27. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 28. Source step 0042 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 29. Source step 0042 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 30. Source step 0042 field "0-3.0" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 31. Source step 0044 field "Location Header" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0044 field "Lbl_How long have you owned or occupied location?" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 33. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "X"
# 34. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0044 field "Btn_Hide Google Maps" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 36. Source step 0044 field "Drp List_Miles to Fire Station-need to check" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 37. Source step 0044 field "0-3.0" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 38. Source step 0045 field "Location Header" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 42. Source step 0045 field "Btn_Hide Google Maps" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 43. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 44. Source step 0045 field "0-3.0" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 45. Source step 0047 field "Location Header" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 46. Source step 0047 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 47. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 48. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 49. Source step 0047 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 50. Source step 0047 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 51. Source step 0047 field "0-3.0" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 52. Source step 0047 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 53. Source step 0047 field "< 601" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 54. Source step 0051 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 55. Source step 0056 field "Txt_Cooling (Year)" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "\"DEL\""
# 56. Source step 0056 field "Txt_Plumbing (Year)" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: ""
# 57. Source step 0058 field "Lbl_Electrical Box Type" in "EQH||Home Characteristics_SH3_Electrical Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0064 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0064 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 60. Source step 0064 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 62. Source step 0066 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 63. Source step 0066 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 64. Source step 0066 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0066 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0066 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 67. Source step 0066 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0066 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 69. Source step 0066 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 70. Source step 0066 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 71. Source step 0067 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0067 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 73. Source step 0067 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 74. Source step 0067 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0068 field "Btn_ Add Other Structure" in "On Premise Exposures-Provide details regarding any exposures" was disabled. Reason:  
#    - Preserved source value: a blank value
# 76. Source step 0082 "EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 17.03.24 22:59:58 [ct2452]
#    - INPUT "Additional Coverages" with "{Click}"
# 77. Source step 0083 field "Chk Box_Increase For Theft Of Service Sets_SH-91045" in "Additional Coverages-Add 'Ordinance Or Law Coverage – 50% Loss Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 78. Source step 0083 field "Btn_NEXT" in "Additional Coverages-Add 'Ordinance Or Law Coverage – 50% Loss Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 79. Source step 0083 field "Btn_NEXT" in "Additional Coverages-Add 'Ordinance Or Law Coverage – 50% Loss Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 80. Source step 0084 field "Additional Coverages Header" in "Additional Coverages-Add 'Enhanced Loss Settlement Factor' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0084 field "Chk Box_Increase For Theft Of Service Sets_SH-91045" in "Additional Coverages-Add 'Enhanced Loss Settlement Factor' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 82. Source step 0084 field "Btn_NEXT" in "Additional Coverages-Add 'Enhanced Loss Settlement Factor' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 83. Source step 0084 field "Btn_NEXT" in "Additional Coverages-Add 'Enhanced Loss Settlement Factor' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 84. Source step 0086 field "Additional Coverages Header" in "Additional Coverages-Add 'Blanket Jewelry, Watches, And Furs Coverage - $5,000' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0086 field "Chk Box_Increase For Theft Of Service Sets_SH-91045" in "Additional Coverages-Add 'Blanket Jewelry, Watches, And Furs Coverage - $5,000' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 86. Source step 0096 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 87. Source step 0102 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Limits On Personal Property In Other Residences ' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 88. Source step 0106 field "Chk Box_Increase For Theft Of Service Sets_SH-91045" in "Additional Coverages-Add 'Increased Coverage For Personal Property In Self Storage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 89. Source step 0107 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Business Merchandise Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 90. Source step 0109 field "Btn_Search-Coverage Catalog" in "Additional Coverages-Add 'Broadened Water Backup Of Sewers And Drains' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 91. Source step 0114 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit ' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 92. Source step 0115 field "Lbl_Coverage Catalog" in "EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 93. Source step 0115 field "Lbl_Contents Coverages" in "EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 94. Source step 0119 field "Btn_Search-Coverage Catalog" in "Additional Coverages-Add 'Personal Injury Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 95. Source step 0120 field "Lbl_Personal Injury Coverage" in "EQH||Additional Coverages-Liability Coverages-Update 'Personal Injury Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 96. Source step 0123 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Office, Professional, Private School Or Studio Use - Residence Premises' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 97. Source step 0124 field "$5,000" in "EQH||Additional Coverages-Liability Coverages-Update 'Office, Professional, Private School Or Studio Use - Residence Premises'" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 98. Source step 0128 field "Additional Coverages Header" in "Additional Coverages-Add 'Other Structure Restriction' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0128 field "Btn_NEXT" in "Additional Coverages-Add 'Other Structure Restriction' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 100. Source step 0128 field "Btn_NEXT" in "Additional Coverages-Add 'Other Structure Restriction' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: a blank value
# 101. Source step 0130 field "Txt_OtherStructureRestriction-ZipCode" in "EQH||Additional Coverages-Premises Covg-Other Structure Location/Restriction" was disabled. Reason:  
#    - Preserved source value: "17065"
# 102. Source step 0133 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 103. Source step 0133 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0133 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 105. Source step 0133 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 106. Source step 0133 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 107. Source step 0133 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 108. Source step 0133 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 109. Source step 0135 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Add Additional Interest" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 110. Source step 0136 "EQH||Add/Edit Additional Interest-First Mortgagee" in module "EQH||Add/Edit Additional Interest-First Mortgagee" was disabled. Reason: 18.03.24 17:29:42 [ct2452]
#    - WAIT "Lbl_Interest Type" with "True"
#    - INPUT "Btn_First Mortgagee" with "X"
#    - INPUT "Txt_MortgageSearch_Mortgage Name" with "NEW MEXICO BANK & TRUST"
#    - INPUT "Txt_MortgageSearch_Zip Code" with "87102"
#    - INPUT "Btn_Search" with "X"
#    - INPUT "TABLE > $1 > $1" with "{click[1px][1px]}"
#    - INPUT "Btn_Save" with "X"
# 111. Source step 0137 "Mortgage/Additional Interest-Click NEXT to move to Billing" in module "EQH||Mortgage/Additional Interest" was disabled. Reason: 18.03.24 17:30:22 [ct2452]
#    - WAIT "Mortgage/Additional Interest Header" with "True"
#    - WAIT "Lbl_Mortgage / Additional Interest Summary" with "True"
#    - INPUT "Btn_ADD MORTGAGE / ADD'L INTEREST" with a blank value
#    - INPUT "Btn_NEXT" with "{Invoke[Click]}"
# 112. Source step 0139 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 113. Source step 0139 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0139 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 115. Source step 0139 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 116. Source step 0141 "Submission-UW referraland add agent comments" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - WAIT "Hdr_Submission Header" with "True"
#    - VERIFY "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_UW1_AgentComments" with "Test"
#    - INPUT "Btn_Refer to UW_1" with "{Click}"
# 117. Source step 0142 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "10000"
# 118. Source step 0143 "OpenUrl" in module "OpenUrl" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 119. Source step 0144 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 120. Source step 0145 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 121. Source step 0146 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 122. Source step 0147 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - VERIFY "Lbl_Login ID" with "True"
# 123. Source step 0148 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 124. Source step 0149 "EU||Home" in module "EU||Home" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
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
# 125. Source step 0150 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "12000"
# 126. Source step 0151 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Title" with "Home"
# 127. Source step 0152 "EQH||Quote Actions-Save and Exit the current Quote" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Btn_QUOTE ACTIONS" with "X"
#    - WAIT "Btn_Quote Actions_Save and Exit" with "True"
#    - INPUT "Btn_Quote Actions_Save and Exit" with "X"
# 128. Source step 0153 "Search for the Quote in EQ" in module "EQ||New Quote" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - WAIT "Btn_New Quote" with "True"
#    - INPUT "Btn_New Quote" with "X"
#    - INPUT "Txt_QuoteSearch_Input" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search_1" with "{Click}"
# 129. Source step 0154 "EQH||Side Menu and Quote Actions-Navigate to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 130. Source step 0155 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "5000"
# 131. Source step 0156 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - VERIFY "Lbl_Step 4. Transmit" with "True"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - VERIFY "Btn_Issue Home Binder" with "True"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 132. Source step 0157 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "10000"
# 133. Source step 0158 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 134. Source step 0159 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 135. Source step 0160 "eChecklist-Click the 'Home/ROP Electronic Application' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 136. Source step 0161 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 137. Source step 0162 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "10000"
# 138. Source step 0163 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - WAIT "H4" with "True"
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 139. Source step 0164 "eChecklist-Click the 'drag/drop' link to upload the documents in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 140. Source step 0165 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 141. Source step 0166 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "10000"
# 142. Source step 0167 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 143. Source step 0168 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Duration" with "10000"
# 144. Source step 0169 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 145. Source step 0170 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:45:41 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 146. Source step 0172 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 18.03.24 19:59:12 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
# 147. Source step 0174 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 18.03.24 19:59:17 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
#    - INPUT "Submission" with "{Click}"
# 148. Source step 0176 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 149. Source step 0176 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 150. Source step 0176 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 151. Source step 0177 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 152. Source step 0177 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
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
