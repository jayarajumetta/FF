# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 208_Happy_Path_SH6_-_NM_Happy_Path_SH6_-_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @happy_path @Edge @manual @obsolete @automated
Feature: Execute Happy Path SH6 - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path SH6 - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path SH6 - NM using representative iteration Happy Path SH6 - NM
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-b5fe-14d2-71b352e66098
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-ce56-129c-2222ea1e6975
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-1652-8956-b4ecbfc7396a
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-172a-25c9-eb6fc8902f22
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "3000000000" in "<unnamed value>"
    When I enter or select "inout@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "1010 Lead Ave SW, Albuquerque, NM 87102" in "<unnamed value>"
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-e59e-3a0e-e578c1a870b5
    Then I wait until "Btn_PERSONAL AUTO" is visible
    Then I wait until "Btn_MOTORCYCLE" is visible
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then "Btn_SH3-HOMEOWNERS" should be visible
    Then "Btn_SH4-TENANTS" should be visible
    When I click "Btn_SH6-CONDOMINIUM OWNERS"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_SD1-RENTAL OWNERS"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][+5d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_NEW MEXICO_1"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0030: Proposal Start-Invalid Address,SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-a370-58ad-cb93fc9046db
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0031: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0032: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cf2-1a2c-8376-7c19d84765aa
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

    # Source step 0033: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-c11a-df50-93b496d2f81e
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0034: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-90af-be8c-35c22c283130
    # Runtime control: Wait for Page to Load [max=30] > Condition
    Then if the source runtime condition "Wait for Page to Load [max=30] > Condition" is satisfied, "Lbl_Choose Insureds From Existing Account" should be visible

    # Source step 0035: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Page to Load [max=30] > Loop
    When if the source runtime condition "Wait for Page to Load [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0036: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-6f03-86cb-9c0682d4e57f
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0037: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-f7f7-0ece-2c423416b7ec
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-f0a0-bbb0-170f3f95b4f6
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0040: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-cd76-6614-90db67eb8d1b
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-7fca-fd72-b215eeb19baa
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0047: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-d8e4-ff70-c99cea914b7c
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0048: EQH||Home Characteristics_SH6-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH6
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-b246-4e1a-46dc5fea01e6
    Then I wait until "Home Characteristics_Header" is visible
    Then I wait until "Txt_Years Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "2000" in "Txt_Years Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "1802" in "Txt_Total Living Area"
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
    When I wait "8000" milliseconds

    # Source step 0050: RCT||Home Page | Module: RCT | Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cfa-132c-c2a8-8d24bb3fa41b
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0051: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-327e-7286-f8ffe7c9a170
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0052: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-7272-b827-b9b790259db9
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0053: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-66f1-a777-107eec0050f5
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0054: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-d1ab-fb6d-c8c609dd4185
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0056: EQH||Home Characteristics_SH6-Property Information and Heating details | Module: EQH||Home Characteristics_SH6
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-1d70-2bf1-5927066e9962
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-360a-7ec1-c46e9a78db13
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0059: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-92a9-9621-f666ed85e465
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0060: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-d4a9-dd5f-ebe486f133de
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "check_box_outline_blankNone of the Above - Special Exposures"
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0061: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-0aca-f2d3-a6293eb494dc
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0062: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-bb5b-bbfd-55e4d8ed4948
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0063: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-2153-11be-faf7ba2d79d5
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0064: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-b2a6-33df-bcbe74cfc99e
    When I click "Btn_NEXT"

    # Source step 0068: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-2008-da34-83888f97c8b4
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0069: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-250a-c878-9a6964921971
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0071: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-c5f0-5b4a-ac33673bb135
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

    # Source step 0072: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-554a-d9ac-4d681a16f559
    When I click "Additional Coverages"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0074: Additional Coverages-Add 'Home Systems Breakdown Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-3485-9807-abae056cf130
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Home Systems Breakdown Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0075: Additional Coverages-Add 'Loss Assessment Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-34b2-ec6c-572aea14a4e9
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Loss Assessment Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0076: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0077: Additional Coverages-Add 'Vacancy' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-25ca-4084-3ab1e9a8466b
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Vacancy" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0078: Additional Coverages-Add 'Broadened Water Backup Of Sewers And Drains' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-2eb7-11d9-f5b0fe5b357f
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Broadened Water Backup Of Sewers And Drains" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0079: EQH||Additional Coverages-Dwelling Coverages-Update 'Broadened Water Backup Of Sewers And Drains' amount & LAC values | Module: EQH||Additional Coverages-Dwelling Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-5289-ff59-93a758ef41c8
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "Btn_$5,000"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0080: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0081: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-1bdc-6709-6f7b330d6848
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0083: Mortgage/Additional Interest-Add Additional Interest | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-cc4b-37e3-8ee266c04f7e
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_ADD MORTGAGE / ADD'L INTEREST"

    # Source step 0084: EQH||Add/Edit Additional Interest - Adding Additional Interest | Module: EQH||Add/Edit Additional Interest-Additional Insured/Landlord
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-c6ea-21f2-5ffb5ed8540e
    Then I wait until "Lbl_Interest Type" is visible
    Then I wait until "Btn_First Mortgagee" is visible
    When I click "Btn_Additional Insured/Landlord"
    Then I wait until "Btn_Additional Insured" is visible
    When I enter captured runtime value "FirstName" in "Text box_Name"
    When I enter or select "1310 Wilclark Rd Clovis" in "Text box_Address"
    When I enter or select "Curry" in "Text box_City"
    When I select "Dropdown-State-GenericGUI"
    When I click "NM"
    When I enter or select "88101" in "Text box_Zip Code"
    When I click "Btn_SAVE"

    # Source step 0085: Mortgage/Additional Interest-Click NEXT to move to Billing | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-96f3-d5ee-cf1cb48b6a83
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0086: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0087: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-1597-62f1-9cf594879458
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

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0089: Submission- Land on Submission page and Refer to UW | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-ea90-e0f2-dd6a4b3c3f96
    Then I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    When I enter or select "Test" in "Txt_UW1_AgentComments"
    When I click "Btn_Refer to UW_1"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist

    # Source step 0090: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0091: OpenUrl | Module: OpenUrl
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0095: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0096: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0097: EU||Home | Module: EU||Home
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    Then I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0098: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    When I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0099: EU||Applicant | Module: EU||Applicant
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    When I click "Lnk_Pricing"

    # Source step 0100: EU||Pricing | Module: EU||Pricing
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    When I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0101: EU||Pricing | Module: EU||Pricing
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Level 9 exists > Condition
    Then if the source runtime condition "If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0102: EU||Pricing | Module: EU||Pricing
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Level 9 exists > Then
    When if the source runtime condition "If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0105: CloseBrowser | Module: CloseBrowser
    # Section: Process > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    When I close the active browser

    # Source step 0116: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-74a3-7c57-6caa6fda3e69
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0117: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-8cdd-4fde-b0625a0db208
    Then I wait until "Btn_New Quote" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0118: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-fcfd-492a-1ebe8d1d7f63
    When I click "Submission"

    # Source step 0119: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0120: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-55e0-b51b-8634c69eb134
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0121: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0122: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-dff8-37db-be8fc931fa09
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0123: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-264b-20fc-69c33685c021
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0124: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-e3a1-774f-25924837351a
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0125: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-9fab-0abb-56fa61a7450c
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0126: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0131: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-e805-a837-dd6dad59f4bb
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0132: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0133: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-cb84-df23-2fbaec7ff5c8
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0134: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-69fc-2c85-b96b63443f09
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0135: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0136: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-7265-73cb-f5f10b32942e
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    When I click "Btn_Transmit_1"

    # Source step 0137: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0138: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d01-5d9b-a635-b4faf2142b75
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0139: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0140: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d13-e356-2abb-b70edfe1eeff
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

    # Source step 0141: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d13-468f-7d55-148a53abb672
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0155: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d13-fd11-24bf-c03c525767a6
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0156: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1d13-ec25-f87a-54e78e3f10d4
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
# 6. Source step 0030 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0030 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0032 field "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) CONVICTED OF ARSON IN THE LAST 5 YEARS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0032 field "Btn_None Of The Above_Client ER" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0032 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 11. Source step 0032 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 12. Source step 0032 field "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "True"
# 13. Source step 0032 field "Btn_None Of The Above_Property Eligibility Restrictions_SH4" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
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
# 30. Source step 0044 "Verify Order Wildfire Risk Score is enabled" in module "EQH||Location" was disabled. Reason: 05.02.24 18:05:50 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "+ ORDER WILDFIRE RISK SCORE" with "True"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 31. Source step 0045 "Get the the Wildfore Risk Score for property" in module "EQH||Location" was disabled. Reason: 05.02.24 18:05:50 [ct2452]
#    - WAIT "Location Header" with a blank value
#    - VERIFY "Lbl_How long have you owned or occupied location?" with a blank value
#    - INPUT "Btn_More than 5 years" with a blank value
#    - VERIFY "Btn_More than 5 years" with a blank value
#    - INPUT "Btn_Hide Google Maps" with a blank value
#    - INPUT "+ ORDER WILDFIRE RISK SCORE" with "X"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with a blank value
#    - INPUT "0-3.0" with a blank value
# 32. Source step 0046 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.02.24 18:05:50 [ct2452]
#    - INPUT "Duration" with "2000"
# 33. Source step 0047 field "Location Header" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 34. Source step 0047 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 35. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 36. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 37. Source step 0047 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 38. Source step 0047 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0047 field "0-3.0" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0047 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0047 field "< 601" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 42. Source step 0051 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 43. Source step 0058 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 44. Source step 0058 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 45. Source step 0058 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 46. Source step 0058 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0058 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0058 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 49. Source step 0058 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0058 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 51. Source step 0058 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 52. Source step 0058 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 53. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 55. Source step 0059 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 56. Source step 0059 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0065 "On Premise Exposures-Provide details regarding any exposures" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:45:49 [ct2452]
#    - WAIT "On Premise Exposures Header" with "True"
#    - VERIFY "Btn_ Add Other Structure" with a blank value
#    - VERIFY "Btn_Chk box_Swimming pool" with "True"
#    - INPUT "Btn_Chk box_None of the Above - Business Details" with "{Click}"
#    - INPUT "Lbl_Dog Exposures" with "PGDN"
#    - INPUT "Lbl_Business Details" with "PGDN"
#    - VERIFY "Btn_Chk box_BUSINESS ON PREMISE" with "True"
#    - INPUT "Btn_Chk box_None Of The Above" with "{CLICK}"
#    - INPUT "Lbl_Farm & Livestock Exposures" with "PGDN"
# 58. Source step 0066 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.05.24 12:45:49 [ct2452]
#    - INPUT "Duration" with "5000"
# 59. Source step 0067 "On Premise Exposures-Provide details and go to next page" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:45:49 [ct2452]
#    - INPUT "Lbl_Farm & Livestock Exposures" with "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "{CLICK}"
#    - WAIT "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "X"
# 60. Source step 0071 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 61. Source step 0081 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0081 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0081 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 64. Source step 0081 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 65. Source step 0081 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0081 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 67. Source step 0081 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 68. Source step 0083 field "Btn_NEXT" in "Mortgage/Additional Interest-Add Additional Interest" was disabled. Reason:  
#    - Preserved source value: a blank value
# 69. Source step 0084 field "Text box_Loan Number" in "EQH||Add/Edit Additional Interest - Adding Additional Interest" was disabled. Reason:  
#    - Preserved source value: a blank value
# 70. Source step 0085 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Click NEXT to move to Billing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 71. Source step 0087 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0087 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0087 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 74. Source step 0087 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0092 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 76. Source step 0093 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 77. Source step 0094 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 78. Source step 0096 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0096 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 80. Source step 0100 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 81. Source step 0100 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 82. Source step 0100 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 83. Source step 0100 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 84. Source step 0101 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0101 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 86. Source step 0101 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 87. Source step 0101 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 88. Source step 0102 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 89. Source step 0102 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 90. Source step 0102 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 91. Source step 0102 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 92. Source step 0103 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 93. Source step 0104 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 94. Source step 0106 "OpenUrl" in module "OpenUrl" was disabled. Reason: 16.04.24 14:30:18 [ct2721]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 95. Source step 0107 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 96. Source step 0108 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 97. Source step 0109 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 98. Source step 0110 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 16.04.24 14:30:01 [ct2721]
#    - VERIFY "Lbl_Login ID" with "True"
# 99. Source step 0111 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 16.04.24 14:30:01 [ct2721]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 100. Source step 0112 "EU||Home" in module "EU||Home" was disabled. Reason: 16.04.24 14:30:01 [ct2721]
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
# 101. Source step 0113 "TBox Wait" in module "TBox Wait" was disabled. Reason: 16.04.24 14:30:01 [ct2721]
#    - INPUT "Duration" with "12000"
# 102. Source step 0114 "Close the Express UI page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 08.03.24 16:39:53 [ct2452]
#    - INPUT "Caption" with "Home*"
#    - INPUT "Keys" with "^(w)"
# 103. Source step 0115 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 16.04.24 14:30:01 [ct2721]
#    - INPUT "Title" with "Home"
# 104. Source step 0117 field "Btn_New Quote" in "Search for the Quote in EQ" was disabled. Reason:  
#    - Preserved source value: "X"
# 105. Source step 0127 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:15:22 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 106. Source step 0128 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:15:22 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 107. Source step 0129 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 108. Source step 0130 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:15:22 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 109. Source step 0136 field "Btn_Launch To Checklist_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 110. Source step 0136 field "Btn_Launch To eSignature_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 111. Source step 0136 field "Btn_Transmit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0136 field "Btn_Issue Home Binder" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 113. Source step 0136 field "Btn_Save and Exit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0138 field "Transmit Confirmation Header" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 115. Source step 0141 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 116. Source step 0142 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 07.05.24 18:38:26 [ct2451]
#    - INPUT "LOB" with "Home"
#    - INPUT "State" with "NM"
# 117. Source step 0143 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 118. Source step 0144 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 119. Source step 0145 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 120. Source step 0146 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 121. Source step 0147 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 122. Source step 0148 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 123. Source step 0149 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 124. Source step 0150 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 125. Source step 0151 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 126. Source step 0152 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 07.05.24 18:38:26 [ct2451]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 127. Source step 0153 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 07.05.24 18:38:26 [ct2451]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 128. Source step 0154 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 07.05.24 18:38:26 [ct2451]
#    - VERIFY "Expected_ValidatedPremium" with captured runtime value "Premium"
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
