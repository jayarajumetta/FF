# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 147_Home_Mid-Term_Evaluations_-_Remove_Discount_-_NM_Home_Mid-Term_Evaluations_-_Remove_Disco.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @manual_conversion @Edge @manual @archive @automated
Feature: Execute Home Mid-Term Evaluations - Remove Discount - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Mid-Term Evaluations - Remove Discount - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Mid-Term Evaluations - Remove Discount - NM using representative iteration Home Mid-Term Evaluations - Remove Discount - NM
    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-5ef0-b7a0-2fdf4632b81a
    Given "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-960a-1de5-61ee8e5ec46c
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-72f0-0eeb-832dcf0bdfb0
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "3000000000" in "<unnamed value>"
    When I enter or select "outin@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "3809 Fox Sparrow Trl NW,Albuquerque, New Mexico, USA" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: Proposal Start-With Effective Date prior to 90 days from current date | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-173e-0f3d-4d6efc0173d9
    Then I wait until "Btn_PERSONAL AUTO" is visible
    Then I wait until "Btn_MOTORCYCLE" is visible
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    Then "Btn_SH3-HOMEOWNERS" should be visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
    Then "Btn_SH6-CONDOMINIUM OWNERS" should exist
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_SD1-RENTAL OWNERS"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][-90d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_NEW MEXICO_1"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0030: Proposal Start-Invalid Address,SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-d5b8-1b5d-e6889d5cd308
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0031: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0032: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-73d6-8144-ccd2b7419399
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

    # Source step 0033: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-d5ff-b953-e6fe1efda4fc
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0034: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-36e0-4a84-6ad52d2be0ce
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0035: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-9816-6109-3b3d9a38f23a
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    Then "Btn_C/O" should exist
    When I enter or select "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Phone Type"
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
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0036: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-42e0-ffce-d19a89668d13
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0037: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0038: Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-1f4d-0bb0-91565a108174
    Then I wait until "Location Header" exists
    Then "Lbl_How long have you owned or occupied location?" should exist
    When I click "Btn_More than 5 years"
    Then "Btn_More than 5 years" should exist
    When I enter or select "{SCROLL[12][1000px][None][HorizontalFirst][300ms]}" in "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0040: Location-till feet to hydrant | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-8d59-895a-2fbac43de65e
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0045: Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-cc43-b776-e0feb1abeabd
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0046: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-4e20-3c64-7b7fb9ef68f4
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

    # Source step 0047: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0048: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-a931-0b29-8676c1229c58
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0049: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-6125-cc9c-de0f17f58f57
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0050: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-668d-ba60-59e0930ec808
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0051: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-ef6e-5ffb-7dc9f31a0aec
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0052: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-1067-995a-9a0646d66489
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0053: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0054: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cd1-1f20-3ff8-ac8412a75d14
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

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0056: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdc-9b40-27e2-b643fc1a6f6a
    When I enter or select "{SCROLL[5][500px][Center][HorizontalFirst][300ms]}" in "Txt_Market Value"
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    When I click "Btn_Central"
    Then I wait until "Btn_Floor Furnace" exists
    Then I wait until "Btn_More Options_Principal Heat Type" is visible
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible

    # Source step 0057: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0058: Home Characteristics-Heating Details Supplemental Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-b0ca-1f04-2010c1bbe9d9
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0060: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-c8ea-9147-009e2930beae
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

    # Source step 0061: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0062: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-adbf-632f-3ddc3b37b7d8
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0063: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-9ba8-6986-57078849937b
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0064: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-d4a9-dd5f-ebe486f133de
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "check_box_outline_blankNone of the Above - Special Exposures"
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0065: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-0aca-f2d3-a6293eb494dc
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0066: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-bb5b-bbfd-55e4d8ed4948
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0067: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-2153-11be-faf7ba2d79d5
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0068: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-b2a6-33df-bcbe74cfc99e
    When I click "Btn_NEXT"

    # Source step 0072: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-9af1-5a13-ed6f700c6de6
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0073: Discounts/Adjustments-Add auto-home/Three-Line discount | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-7d5c-26d0-706552cb9160
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    When I click "Btn_Chk box_AUTO-HOME"
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0074: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "9000" milliseconds

    # Source step 0075: Coverages-Edit-Option 1-All Other Peril Deductible $2000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-e2e2-4f8a-cd433e6e6986
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

    # Source step 0076: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-a827-6eef-26e21237c1a6
    When I click "Additional Coverages"

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0078: Additional Coverages-Add addtional coverage(Increase For Theft Of Service Sets) | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-0388-38a3-4ddb402fc92c
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increase For Theft Of Service Sets" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "Chk Box_Increase For Theft Of Service Sets_SH-91045"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0080: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-579c-fe0f-114ffdd2d660
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0082: Mortgage/Additional Interest-Add or Update  | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-9cac-aa28-bf72e17e509b
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    Then "Btn_ADD MORTGAGE / ADD'L INTEREST" should exist
    When I click "Btn_NEXT"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0084: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-457e-2942-991b383ab459
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

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0086: Submission- Land on Submission page | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-3d01-5ea7-4b68f0153ce9
    Then I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0093: Submission- UW Referral and add agent comments | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-3939-b6e9-5b6b7c223133
    Then I wait until "Hdr_Submission Header" is visible
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    When I enter or select "Test" in "Txt_UW1_AgentComments"
    When I click "Btn_Refer to UW_1"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist

    # Source step 0094: OpenUrl | Module: OpenUrl
    # Section: Process | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0098: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-7c34-8527-27316b351da0
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0099: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-3ffc-3dbf-87e20795e3e7
    # Runtime control: If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0100: EU||Home | Module: EU||Home
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-347c-6412-d8278a1d0ae9
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

    # Source step 0101: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0103: CloseBrowser | Module: CloseBrowser
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-72ae-fea3-3db0c52b6d4c
    When I close the active browser

    # Source step 0104: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-3f43-6ba3-afe3292f8923
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0105: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-9687-a149-282693dd7b93
    Then I wait until "Btn_New Quote" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0106: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-a0b3-025e-b4c861089986
    When I click "Submission"

    # Source step 0107: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0108: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-93f7-7e36-7051bff15b5d
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0109: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0110: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-10af-234e-9ca65538bc6b
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0111: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-0019-37bd-ceaeaeba2e1f
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0112: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-98ba-71c0-7c6d0da438c0
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0113: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-b433-4aef-6a1183b6a833
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0114: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0115: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-a06c-0aa7-88c21bfc0877
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0116: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0117: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-059e-c6b8-4527589cc1f0
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0118: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-57d2-47ff-2ae665e8bba9
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0119: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0120: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-7060-fd97-e62fc94c1a43
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    When I click "Btn_Transmit_1"

    # Source step 0121: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0122: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-ce9c-0197-76d020284189
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0123: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0124: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-6097-5206-d65d7fafcbae
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "BaseRegression_Home_PolicyData"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > FirstName" with captured runtime value "FirstName"
    And I use TDM parameter "Data structure > LastName" with captured runtime value "LastName"
    And I use TDM parameter "Data structure > DOB" with captured runtime value "DOB"
    And I use TDM parameter "Data structure > SSN" with captured runtime value "SSN"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0125: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-b072-c3fb-551e6fa6d95f
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0126: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-4ce8-a51c-9ff809dc2799
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0127: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3cdd-4017-e948-b4b75175a201
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0025 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 06.06.24 14:22:40 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 2. Source step 0029 field "Hdr2" in "Proposal Start-With Effective Date prior to 90 days from current date" was disabled. Reason:  
#    - Preserved source value: "X"
# 3. Source step 0030 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 4. Source step 0030 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 5. Source step 0030 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0032 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 7. Source step 0032 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 8. Source step 0035 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0035 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 10. Source step 0035 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 11. Source step 0035 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 12. Source step 0038 field "Btn_Hide Google Maps" in "Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 13. Source step 0038 field "7.1-10.0" in "Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0040 field "Location Header" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0040 field "Lbl_How long have you owned or occupied location?" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0040 field "Btn_More than 5 years" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 17. Source step 0040 field "Btn_More than 5 years" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "True"
# 18. Source step 0040 field "Btn_Hide Google Maps" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 19. Source step 0040 field "Drp List_Miles to Fire Station-need to check" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0040 field "0-3.0" in "Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0041 "TBox Wait" in module "TBox Wait" was disabled. Reason: 06.03.24 18:46:19 [ct2452]
#    - INPUT "Duration" with "3000"
# 22. Source step 0042 "Verify Order Wildfire Risk Score is enabled" in module "EQH||Location" was disabled. Reason: 06.03.24 18:46:19 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "+ ORDER WILDFIRE RISK SCORE" with "True"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 23. Source step 0043 "Get the the Wildfore Risk Score for property" in module "EQH||Location" was disabled. Reason: 06.03.24 18:46:19 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "+ ORDER WILDFIRE RISK SCORE" with "X"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 24. Source step 0045 field "Location Header" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 25. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0045 field "Btn_More than 5 years" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 27. Source step 0045 field "Btn_More than 5 years" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 28. Source step 0045 field "Btn_Hide Google Maps" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 29. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0045 field "0-3.0" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0045 field "Drp List_Feet to Hydrant-need to check" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0045 field "< 601" in "Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0046 field "Lbl_Manufactured Home Type" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0046 field "Btn_Singlewide" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "X"
# 35. Source step 0046 field "Btn_Multiwide" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: a blank value
# 36. Source step 0049 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 37. Source step 0054 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 38. Source step 0054 field "Btn_Veneer" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0054 field "Btn_More Options_Construction Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0054 field "Btn_Fire Resistive" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0054 field "Btn_Under Construction" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 42. Source step 0054 field "Btn_More Options_Building Occupancy" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0054 field "Lbl_Principal Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0054 field "Btn_None" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0054 field "Btn_Central" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 46. Source step 0054 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0054 field "Btn_None_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0054 field "Btn_Central_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 49. Source step 0054 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0054 field "Lbl_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0054 field "Btn_None_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 52. Source step 0054 field "Btn_UL3" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0054 field "Btn_NEXT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 54. Source step 0056 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0056 field "Btn_Frame" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0056 field "Btn_Siding" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0056 field "Btn_Veneer" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0056 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0056 field "Btn_Owner" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0056 field "Btn_Tenant" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0056 field "Btn_Under Construction" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0056 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0056 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 64. Source step 0056 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 65. Source step 0056 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 66. Source step 0056 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 67. Source step 0056 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 68. Source step 0056 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 69. Source step 0056 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 70. Source step 0056 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 71. Source step 0056 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 72. Source step 0056 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 73. Source step 0056 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 74. Source step 0056 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0056 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 76. Source step 0056 field "Btn_UL3" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0056 field "Btn_NEXT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 78. Source step 0058 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0058 field "Btn_Frame" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0058 field "Btn_Siding" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0058 field "Btn_Veneer" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0058 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 83. Source step 0058 field "Btn_Owner" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0058 field "Btn_Tenant" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0058 field "Btn_Under Construction" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0058 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 87. Source step 0058 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 88. Source step 0058 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 89. Source step 0058 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 90. Source step 0058 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 91. Source step 0058 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 92. Source step 0058 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 93. Source step 0058 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 94. Source step 0058 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 95. Source step 0058 field "Lbl_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 96. Source step 0058 field "Btn_None" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 97. Source step 0058 field "Btn_Central" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 98. Source step 0058 field "Btn_Floor Furnace" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0058 field "Btn_More Options_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 100. Source step 0058 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 101. Source step 0058 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 102. Source step 0058 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 103. Source step 0058 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0058 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 105. Source step 0058 field "Btn_UL3" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 106. Source step 0058 field "Btn_NEXT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 107. Source step 0060 field "Lbl_Construction Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 108. Source step 0060 field "Btn_Frame" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 109. Source step 0060 field "Btn_Siding" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 110. Source step 0060 field "Btn_Veneer" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 111. Source step 0060 field "Lbl_Building Occupancy" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0060 field "Btn_Owner" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 113. Source step 0060 field "Btn_Tenant" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0060 field "Btn_Under Construction" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 115. Source step 0060 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 116. Source step 0060 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 117. Source step 0060 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "\"DEL\""
# 118. Source step 0060 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "350999"
# 119. Source step 0060 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 120. Source step 0060 field "Txt_Electric (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 121. Source step 0060 field "Txt_Heating (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 122. Source step 0060 field "Txt_Cooling (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 123. Source step 0060 field "Txt_Plumbing (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 124. Source step 0060 field "Lbl_Principal Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 125. Source step 0060 field "Btn_None" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 126. Source step 0060 field "Btn_Central" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 127. Source step 0060 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 128. Source step 0060 field "Btn_None_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 129. Source step 0060 field "Btn_Central_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 130. Source step 0060 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 131. Source step 0060 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 132. Source step 0062 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 133. Source step 0062 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 134. Source step 0062 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 135. Source step 0062 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 136. Source step 0062 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 137. Source step 0062 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 138. Source step 0062 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 139. Source step 0062 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 140. Source step 0062 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 141. Source step 0062 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 142. Source step 0063 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 143. Source step 0063 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 144. Source step 0063 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 145. Source step 0063 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 146. Source step 0069 "On Premise Exposures-Provide details regarding any exposures" in module "EQH||On Premise Exposures" was disabled. Reason: 31.05.24 12:12:09 [ct2451]
#    - WAIT "On Premise Exposures Header" with "True"
#    - VERIFY "Lbl_Special Exposures" with "True"
#    - VERIFY "Btn_Chk box_Swimming pool" with "True"
#    - INPUT "Btn_Chk box_None of the Above - Business Details" with "{Click}"
#    - INPUT "Lbl_Dog Exposures" with "PGDN"
#    - INPUT "Lbl_Business Details" with "PGDN"
#    - WAIT "Btn_Chk box_Animal Boarding" with "True"
#    - WAIT "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" with "True"
#    - VERIFY "Btn_Chk box_BUSINESS ON PREMISE" with "True"
#    - INPUT "Btn_Chk box_None Of The Above" with "{Invoke[Click]}"
#    - INPUT "Lbl_Farm & Livestock Exposures" with "PGDN"
#    - WAIT "Btn_Chk box_Incidental Farming on premise" with "True"
#    - WAIT "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "X"
#    - VERIFY "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "{Invoke[Click]}"
# 147. Source step 0070 "TBox Wait" in module "TBox Wait" was disabled. Reason: 31.05.24 12:12:29 [ct2451]
#    - INPUT "Duration" with "5000"
# 148. Source step 0071 "On Premise Exposures-Provide details and go to next page" in module "EQH||On Premise Exposures" was disabled. Reason: 31.05.24 12:12:25 [ct2451]
#    - WAIT "On Premise Exposures Header" with "True"
#    - WAIT "Lbl_Other Structures" with "True"
#    - VERIFY "Btn_ Add Other Structure" with "True"
#    - VERIFY "Lbl_Special Exposures" with "True"
#    - VERIFY "Btn_Chk box_Swimming pool" with "True"
#    - INPUT "Btn_Chk box_None of the Above - Business Details" with "{Click}"
#    - INPUT "Lbl_Dog Exposures" with "PGDN"
#    - INPUT "Lbl_Business Details" with "PGDN"
#    - WAIT "Btn_Chk box_Animal Boarding" with "True"
#    - WAIT "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" with "True"
#    - VERIFY "Btn_Chk box_BUSINESS ON PREMISE" with "True"
#    - INPUT "Btn_Chk box_None Of The Above" with "{Invoke[Click]}"
#    - INPUT "Lbl_Farm & Livestock Exposures" with "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}"
#    - WAIT "Btn_Chk box_Incidental Farming on premise" with "True"
#    - VERIFY "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "{Invoke[Click]}"
#    - WAIT "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "X"
# 149. Source step 0075 field "Txt_C.Personal Property" in "Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 150. Source step 0075 field "All Other Peril Deductible_2%" in "Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: a blank value
# 151. Source step 0078 field "Chk Box_Child Care Coverage_SH-9695" in "Additional Coverages-Add addtional coverage(Increase For Theft Of Service Sets)" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 152. Source step 0078 field "Chk Box_First Coverage that shows after search by coverage name in the Coverage Catalog" in "Additional Coverages-Add addtional coverage(Increase For Theft Of Service Sets)" was disabled. Reason:  
#    - Preserved source value: "X"
# 153. Source step 0080 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 154. Source step 0080 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 155. Source step 0080 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 156. Source step 0080 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 157. Source step 0080 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 158. Source step 0080 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 159. Source step 0080 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 160. Source step 0084 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 161. Source step 0084 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 162. Source step 0084 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 163. Source step 0084 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 164. Source step 0086 field "Lbl_Step 1. Review Messages" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
# 165. Source step 0086 field "Txt_UW1_AgentComments" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "Test"
# 166. Source step 0086 field "Btn_Refer to UW_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 167. Source step 0086 field "Btn_Launch To Checklist_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 168. Source step 0086 field "Btn_Launch To Checklist_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 169. Source step 0086 field "Btn_Launch To eSignature_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 170. Source step 0086 field "Lbl_Step 4. Transmit" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 171. Source step 0086 field "Btn_Transmit_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 172. Source step 0086 field "Btn_Issue Home Binder" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 173. Source step 0086 field "Btn_Save and Exit_1" in "Submission- Land on Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 174. Source step 0087 "EQH||Side Menu and Quote Actions-Navigate back to NamedInsured page to select Gender again, remove GenderX 0076 error on submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - INPUT "Named Insureds Summary" with "{Click}"
#    - INPUT "Location" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 175. Source step 0088 "EQH||Named Insureds Summary-Review details or Add Named Insured" in module "EQH||Named Insureds Summary-Review details or Add Named Insured" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - WAIT "Named Insureds Summary Header" with "True"
#    - INPUT "Btn_edit pen icon" with "{Click}"
# 176. Source step 0089 "EQH||Add or Edit Named Insured-Existing Client" in module "EQH||Add or Edit Named Insured-Existing Client" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - WAIT "Add/Edit Named Insured Header" with "True"
#    - INPUT "Txt_Phone Number" with "{SCROLL[3][100px][Center][HorizontalFirst][300ms]}"
#    - INPUT "Btn_Female" with "X"
#    - INPUT "Btn_SAVE AND CONTINUE" with "X"
# 177. Source step 0090 "TBox Wait" in module "TBox Wait" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - INPUT "Duration" with "10000"
# 178. Source step 0091 "EQH||Side Menu and Quote Actions-Navigate back to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 01.02.24 12:17:05 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 179. Source step 0093 field "Btn_Launch To Checklist_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 180. Source step 0093 field "Btn_Launch To Checklist_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 181. Source step 0093 field "Btn_Launch To eSignature_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 182. Source step 0093 field "Lbl_Step 4. Transmit" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 183. Source step 0093 field "Btn_Transmit_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 184. Source step 0093 field "Btn_Issue Home Binder" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 185. Source step 0093 field "Btn_Save and Exit_1" in "Submission- UW Referral and add agent comments" was disabled. Reason:  
#    - Preserved source value: "True"
# 186. Source step 0095 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 187. Source step 0096 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 188. Source step 0097 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 189. Source step 0102 "Close the Express UI page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 08.03.24 16:10:33 [ct2452]
#    - INPUT "Caption" with "Home"
#    - INPUT "Keys" with "^(w)"
# 190. Source step 0105 field "Btn_New Quote" in "Search for the Quote in EQ" was disabled. Reason:  
#    - Preserved source value: "X"
# 191. Source step 0106 field "Transmit Confirmation" in "EQH||Side Menu and Quote Actions-Navigate to Submission page" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 192. Source step 0108 field "Hdr_Submission Header" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 193. Source step 0108 field "Btn_Launch To eSignature_1" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 194. Source step 0108 field "Lbl_Step 4. Transmit" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 195. Source step 0108 field "Btn_Transmit_1" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 196. Source step 0108 field "Btn_Issue Home Binder" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 197. Source step 0108 field "Btn_Save and Exit_1" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 198. Source step 0120 field "Btn_Launch To Checklist_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 199. Source step 0120 field "Btn_Launch To eSignature_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 200. Source step 0120 field "Btn_Transmit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 201. Source step 0120 field "Btn_Issue Home Binder" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 202. Source step 0120 field "Btn_Save and Exit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 203. Source step 0122 field "Transmit Confirmation Header" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 204. Source step 0122 field "Submission" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 205. Source step 0125 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
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
