# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 207_Happy_Path_SD3_-_NM_Happy_Path_SD3_-_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @happy_path @Edge @manual @obsolete @automated
Feature: Execute Happy Path SD3 - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path SD3 - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path SD3 - NM using representative iteration Happy Path SD3 - NM
    # Source step 0026: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-abfb-fb9e-eb64be27ae60
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0027: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0028: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-1bde-ee07-5c2e804ef870
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0029: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-20bd-b9d7-0fab8b1b5863
    When I enter captured runtime value "FirstName" in "<unnamed value>"
    When I enter captured runtime value "LastName" in "<unnamed value>"
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0030: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-f09a-8cf2-21c3595e0d07
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "5000000000" in "<unnamed value>"
    When I enter or select "gwsadios@aol.com" in "<unnamed value>"
    When I click "<unnamed value>"
    When I enter captured runtime value "Street" in "<unnamed value>"
    When I enter a RANDOM value matching "3 random digits/characters" in "<unnamed value>"
    When I enter captured runtime value "City" in "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I enter captured runtime value "ZIP" in "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0031: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-3b19-bb77-2e96669a61a3
    Then I wait until "Btn_RECREATIONAL VEHICLE" exists
    When I click "Btn_HOME"
    When I click "Btn_SD3-RENTAL OWNERS"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][+5w][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "tas" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_NEW MEXICO_1"
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0032: Verify that Invalid address pop up is shown  | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-2097-1448-ce61fdf8bb2b
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0033: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-41af-8468-72fa5ce352a8
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0034: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-8b06-6602-8f2d8f419ef0
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0035: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0036: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-05d9-4118-532d7cd8ed58
    Then I wait until "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) WITH FELONY CONVICTION" exists
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0037: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-ba12-22b7-4367b6d0f3ae
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0038: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-3314-4eb7-abfe6a63ccc8
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0039: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-9b44-dc0a-96d166138ff7
    Then I wait until "Add/Edit Named Insured Header" is visible
    When I click "Btn_Male"
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0040: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-35c7-7f75-65c681b93241
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0041: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0042: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-abff-1a1a-be6573fa13e2
    Then I wait until "Location Header" exists
    Then "Lbl_How long have you owned or occupied location?" should exist
    When I click "Btn_More than 5 years"
    Then "Btn_More than 5 years" should exist
    When I enter or select "{SCROLL[12][1000px][None][HorizontalFirst][300ms]}" in "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0044: EQH||Location-till feet to hydrant | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-e258-7ccf-002756588548
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0045: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0046: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-ed6a-a6b1-d5bcf4352f59
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0047: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-2d1c-d5cf-7290d931f852
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0048: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0049: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-33d1-7428-3e2d94e380b8
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0050: Home Characteristics_SD3-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SD3/SD1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-026d-e015-02b6045405d6
    Then I wait until "Home Characteristics_Header" is visible
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "1930" in "Txt_Years Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "3150" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    When I click "Tile, Clay"
    Then I wait until "Lbl_Home Type" is visible
    When I click "Conventional"
    Then I wait until "Structure Type" is visible
    When I click "Single Family"
    Then I wait until "Lbl_Is Principal Heating System Thermostatically Controlled ?" is visible
    When I select "Yes"
    When I click "Btn_Get Valuation"

    # Source step 0051: RCT||Home Page | Module: RCT | Home Page
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-b3d6-dab0-54709a41f853
    # Runtime control: While [max=10] > Condition
    Then if the source runtime condition "While [max=10] > Condition" is satisfied, "Btn_Edit_Building Information" should be not visible

    # Source step 0052: TBox Wait | Module: TBox Wait
    # Section: Process > RCT Operation | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: While [max=10] > Loop
    When if the source runtime condition "While [max=10] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0053: Add Construction Type Framing - Rough Lumber 100% | Module: RCT | Home Page
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-7b7a-1334-53cd7c2223f4
    When I click "Hdr_Construction Details"
    Then I wait until "Lnk_Exterior Wall Framing" is visible
    When I click "Lnk_Exterior Wall Framing"
    Then I wait until "DIV_---- Select ----" is visible
    When I click "DIV_---- Select ----"
    Then I wait until "Lnk_Framing, Rough Lumber" is visible
    When I click "Lnk_Framing, Rough Lumber"
    When I enter or select "\"^{a}\"" in "Txt_amount"
    When I enter or select "100" in "Txt_amount"
    Then I wait until "Btn_Calculate" is visible
    When I click "Btn_Calculate"

    # Source step 0054: TBox Wait | Module: TBox Wait
    # Section: Process > RCT Operation | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0055: Click Finish | Module: RCT | Home Page
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-48d1-fed5-ea50b5d09b10
    Then I wait until "Btn_Finish_Valuation Totals" is enabled
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0056: RCT||Home Page | Module: RCT | Home Page
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-b9fb-29c2-b70fb301ee03
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0057: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-02e6-5c73-154131ea5e2e
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0058: RCT||Complete page | Module: RCT | Complete page
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-0af1-32df-1d010cd43dac
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process > RCT Operation | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0060: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-a6f2-58cb-dc78f34d53fb
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0061: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-91f4-bea0-c2bd65cede9c
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0063: Home Characteristics_SD3-Property Information | Module: EQH||Home Characteristics_SD3/SD1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-243f-9294-ee78dc4e3ba4
    When I click "Frame"
    Then I wait until "Lbl_Building Occupancy" is visible
    When I click "Under Construction"
    When I select "Btn_Home sold for profit_Yes"
    When I enter or select "\"^{a}\"" in "Txt_Market Value"
    When I enter or select "\"{DEL}\"" in "Txt_Market Value"
    When I enter or select "575000" in "Txt_Market Value"
    Then I wait until "Lbl_Length of rental agreement period" is visible
    When I click ">= 6 Months"

    # Source step 0064: EQH||Home Characteristics_SH3_Electrical Details | Module: EQH||Home Characteristics_SH3_Electrical Details
    # Section: Process > Electrical Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-95b5-b350-02a3295cb189
    Then I wait until "Lbl_Electrical Box Type" is visible
    When I click "Breakers"

    # Source step 0065: EQH||Home Characteristics_SH3_Electrical Details | Module: EQH||Home Characteristics_SH3_Electrical Details
    # Section: Process > Electrical Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-0f50-89ca-308596f54a13
    # Runtime control: Validate Breakes are selected [max=30] > Condition
    Then if the source runtime condition "Validate Breakes are selected [max=30] > Condition" is satisfied, "Breakers" should have "ClassName" equal to "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted cdk-focused cdk-mouse-focused mat-button-toggle-checked"

    # Source step 0066: EQH||Home Characteristics_SH3_Electrical Details | Module: EQH||Home Characteristics_SH3_Electrical Details
    # Section: Process > Electrical Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-82ca-6f29-4d8c6183d7fb
    # Runtime control: Validate Breakes are selected [max=30] > Loop
    When if the source runtime condition "Validate Breakes are selected [max=30] > Loop" is satisfied, I click "Breakers"

    # Source step 0067: EQH||Home Characteristics_SH3_Electrical Details | Module: EQH||Home Characteristics_SH3_Electrical Details
    # Section: Process > Electrical Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-e054-f6cf-edf08e6239cb
    When I click "100 amp or more"
    When I click "GenericGUI-Type of Wiring"
    When I click "BX"
    When I select "No"
    When I click "Other"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0069: Home Characteristics_SD3-Heating and Roof Details | Module: EQH||Home Characteristics_SD3/SD1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-e877-c1cc-2eae2428085a
    Then I wait until "Lbl_Principal Heat Type" is visible
    When I click "Btn_Principal Heat_Central"
    Then I wait until "Lbl_Supplemental Heat Type" is visible
    When I click "Btn_Supplemental Heat_Floor Furnace"
    Then I wait until "Lbl_Roof UL Rating" is visible
    When I click "UL4"
    When I click "Btn_Home Characteristics_Next"

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0071: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-9bc8-37d7-6f68729d7dac
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0072: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-1d49-ed65-b8103fb5747c
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0073: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-d4a9-dd5f-ebe486f133de
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "check_box_outline_blankNone of the Above - Special Exposures"
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0074: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-0aca-f2d3-a6293eb494dc
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0075: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-bb5b-bbfd-55e4d8ed4948
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0076: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-2153-11be-faf7ba2d79d5
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0077: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-b2a6-33df-bcbe74cfc99e
    When I click "Btn_NEXT"

    # Source step 0081: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-8c90-b0fc-efc12b9aa271
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0082: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-c382-1d8f-0e3c18adefdf
    Then I wait until "Discounts/Adjustments Header" is visible
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0084: EQH||Coverages-Edit-Option 1-All Other Peril Deductible 1% | Module: EQH||Coverages-Edit-Option 1
    # Section: Process > Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-8623-6327-a5a476e840cf
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Use Estimated Replacement Cost > CheckBox" is enabled
    When I select "Use Estimated Replacement Cost > CheckBox"
    When I enter or select "\"^{a}\"" in "Txt_A.Dwelling"
    When I enter or select "575000" in "Txt_A.Dwelling"
    When I click "Btn_All Other Peril Deductible"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_1%"
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0085: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-1d35-6297-3198ffb02628
    When I click "Additional Coverages"

    # Source step 0086: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0087: Additional Coverages-Add 'Modified Replacement Cost' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process > Additonal Coverage Modified Replacement Cost | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-5396-9048-5ffcb5428f3f
    Then I wait until "Txt_Search by Name-Coverage Catalog" is enabled
    When I enter or select "Modified Replacement Cost" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0089: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-2d79-e0a6-14ae5c753c86
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0090: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0091: Mortgage/Additional Interest-Add/Edit Additional Interest, if needed | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-d81e-43ba-81f356292709
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0093: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-fd0a-fcb9-1d1eb3f08344
    Then I wait until "Hdr_Billing" is visible
    Then I wait until "Lbl_Select from existing Billing Accounts or Create New" is visible
    When I click "Btn_Create New Billing Account"
    Then "Lbl_Select the Primary Payer for the new account" should be visible
    When I click "Btn_Primary Account Holder name"
    Then "Lbl_Select Payment Type" should exist
    When I click "Btn_Direct Bill_1"
    Then "Lbl_Select Payment Plan" should exist
    When I click "Btn_Direct Bill - 1 Payment"
    When I enter or select "\"^{a}\"" in "Txt_Due Date"
    When I enter or select "DEL" in "Txt_Due Date"
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

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0095: Submission- Land on Submission page and UW referral  | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-77f2-ae1f-f8477b3ff8ad
    # Runtime control: Submission- Land on Submission page and UW referral  > Condition
    Then if the source runtime condition "Submission- Land on Submission page and UW referral > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    Then "Txt_UW2_AgentComments" should exist

    # Source step 0096: Submission- Land on Submission page and UW referral  | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-1fda-ea05-1f430892e569
    # Runtime control: Submission- Land on Submission page and UW referral  > Then
    When if the source runtime condition "Submission- Land on Submission page and UW referral > Then" is satisfied, I enter or select "Test" in "Txt_UW1_AgentComments"
    When I enter or select "Test02" in "Txt_UW2_AgentComments"
    When I click "Btn_Refer to UW_1"

    # Source step 0097: Submission- Land on Submission page and UW referral  | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-b19d-7110-0a043deb89aa
    # Runtime control: Submission- Land on Submission page and UW referral  > Else
    When if the source runtime condition "Submission- Land on Submission page and UW referral > Else" is satisfied, I enter or select "Test" in "Txt_UW1_AgentComments"
    When I click "Btn_Refer to UW_1"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0099: OpenUrl | Module: OpenUrl
    # Section: Process > Approve in Express UI | Reusable flow: zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0103: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-e993-0975-7b51b9d30da0
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0104: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-527e-505f-dbe1defc9f3c
    # Runtime control: If_ExpressUI Login Page showed up > Then
    When if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED value "ExpressPassword" in "Txt_Password_1"
    When I click "Lnk_LOGIN"

    # Source step 0105: EU||Home | Module: EU||Home
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-5afd-0119-075b386974f5
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0106: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-29a5-b260-5c1768a67ccd
    When I click "Lnk_Insured Name"
    When I click "Lnk_ROP"

    # Source step 0107: EU||Applicant | Module: EU||Applicant
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-cf18-86f7-4ff6b8599bc0
    When I click "Lnk_Pricing"

    # Source step 0108: EU||Pricing | Module: EU||Pricing
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ce2-b8cd-7ed5-30644335db03
    Then I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Invoke[Click]}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    When I click "Btn_Approve"

    # Source step 0109: TBox Wait | Module: TBox Wait
    # Section: Process > Approve in Express UI | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0110: CloseBrowser | Module: CloseBrowser
    # Section: Process > Approve in Express UI | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-dad5-079d-4e62235759a6
    When I close the active browser

    # Source step 0111: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-fd97-3cf5-74ed13d30eb2
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0112: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-504f-48a6-f476906b7a78
    Then I wait until "Btn_New Quote" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0113: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-8f0a-c0ca-be5b9d7a4596
    When I click "Submission"

    # Source step 0114: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0115: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-cff6-3ce5-9e3fc529a253
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0116: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0117: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-5a22-09bb-c46ac0011ea8
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0118: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-4dd3-680f-02f95afd21a7
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0119: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-6b65-3145-ba54ae222688
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0120: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-c426-5ed9-4fbc1cb7968e
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0121: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-c552-a489-13fc44bc1690
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0122: eChecklist-Click the drag/drop link to upload the file in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-b0fe-1ac7-849c02c3e438
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0123: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-83de-3b1d-508039c26d3a
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0124: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0125: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-a61a-0851-da0a63166a1f
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0126: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0127: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-3433-a6d9-d15e30d83324
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0128: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-833a-602d-2e64eb4fe7f3
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0129: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "30000" milliseconds

    # Source step 0130: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-416c-498e-ccadebf5d82e
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    When I click "Btn_Transmit_1"

    # Source step 0131: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0132: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-0bd4-e567-6d56fa56cd08
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0133: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0134: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-851d-eb35-9ae3b8f9d79b
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaHome_PolicyData_Regression"
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

    # Source step 0135: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-e297-1dc8-538e9210a685
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NM"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0136: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "ROP" as runtime value "LOB"
    When I retain hard-coded value "NM" as runtime value "State"

    # Source step 0146: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0147: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0148:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0149: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-8a20-cc39-a4a15f664035
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
# 4. Source step 0078 "On Premise Exposures-Provide details regarding any exposures" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:45:34 [ct2452]
#    - WAIT "On Premise Exposures Header" with "True"
#    - VERIFY "Btn_Chk box_Swimming pool" with "True"
#    - INPUT "Btn_Chk box_None of the Above - Business Details" with "{Click}"
#    - INPUT "Lbl_Dog Exposures" with "PGDN"
#    - INPUT "Lbl_Business Details" with "PGDN"
#    - VERIFY "Btn_Chk box_BUSINESS ON PREMISE" with "True"
#    - INPUT "Btn_Chk box_None Of The Above" with "{CLICK}"
#    - INPUT "Lbl_Farm & Livestock Exposures" with "PGDN"
# 5. Source step 0079 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.05.24 12:45:34 [ct2452]
#    - INPUT "Duration" with "5000"
# 6. Source step 0080 "On Premise Exposures-Provide details and go to next page" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:45:34 [ct2452]
#    - INPUT "Lbl_Farm & Livestock Exposures" with "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "{CLICK}"
#    - INPUT "Txt_NumberOfRentalPropertiesOwnedByApplicant" with "1"
#    - WAIT "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "X"
# 7. Source step 0100 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 8. Source step 0101 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 9. Source step 0102 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 10. Source step 0137 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 11. Source step 0138 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 12. Source step 0139 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 13. Source step 0140 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 14. Source step 0141 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 15. Source step 0142 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 16. Source step 0143 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 17. Source step 0144 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 18. Source step 0145 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 19. Source step 0150 "Log Out- Exist from the Quote/Policy" in module "EQ||Log Out" was disabled. Reason: 07.05.24 12:59:49 [ct2451]
#    - INPUT "Btn_Log Out icon" with "X"
#    - INPUT "Btn_Log Out pop-up" with "X"
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
