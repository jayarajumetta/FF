# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 174_Home_Regression_Testing_SH4_Scenario_1_-_PA_-_Unbound_Home_Regression_Testing_SH4_Scenario_1_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH4 Scenario #1 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH4 Scenario #1 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH4 Scenario #1 - PA - Unbound using representative iteration Home Regression Testing SH4 Scenario #1 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-3ee1-fd61-eba38d326c0d
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-ce8c-2d82-a7bfbf445642
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-b72d-0dd7-7e04ea93b04d
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-bfbe-d6d8-f91d0a56c1dd
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "6000000000" in "<unnamed value>"
    When I enter or select "wuyaus@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "1034 Foxwood Ln, Gouldsboro, PA 18424" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-2117-629c-73c3fbc46838
    Then I wait until "Btn_PERSONAL AUTO" is visible
    Then I wait until "Btn_MOTORCYCLE" is visible
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then "Btn_SH3-HOMEOWNERS" should be visible
    Then "Btn_SH4-TENANTS" should be visible
    When I click "Btn_SH4-TENANTS"
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-ab29-0567-17bdb720018d
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-8fe2-ef2f-85bd03cf94d5
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-9d89-8575-26d5fafd2f46
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-e84e-d20a-7d0a6cad8e43
    Then I wait until "Lbl_Client Eligibility Restrictions" is visible
    Then I wait until "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) WITH FELONY CONVICTION" exists
    Then "Btn_NO VALID SSN FOR ACCOUNT OWNER" should exist
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    Then "Lbl_Property Eligibility Restrictions" should exist
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_SINGLE WIDE MANUFACTURED HOME"
    Then "Btn_MANUFACTURED HOME CONSTRUCTED PRIOR TO 1994" should exist
    When I select "Btn_None Of The Above_Property Eligibility Restrictions_SH4"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0035: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-22f8-863c-e230cfbbfc47
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0036: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-858e-4531-3a84fcb7cf2b
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0037: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e3d-b880-7bf3-3033426a4c88
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-25f5-e5ee-449114f42534
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0040: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-bc2a-7cb0-7f9741e4fa79
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-e281-cc1a-b17c2a61487a
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0047: EQH||Location-Provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-d256-8bfd-bf80354744c6
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0048: EQH||Home Characteristics_SH4-Provide all details and move to next page | Module: EQH||Home Characteristics_SH4
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-e4a8-e982-38c4cd1ba6d7
    Then I wait until "Home Characteristics_Header" is visible
    Then "Txt_Years Built" should exist
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "1989" in "Txt_Years Built"
    Then I wait until "Txt_Years Built" is visible
    When I click "1 - 4 Units"
    Then I wait until "Lbl_Structure Type" is visible
    When I click "Triplex"
    When I enter or select "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Home Type"
    When I click "Conventional"
    When I click "Frame"
    When I click "Btn_PrincipalHeat_Central"
    When I click "Btn_SupplementalHeat_Floor Furnace"
    When I click "Btn_Home Characteristics_Next"

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0056: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-173b-e45e-06dceeecc949
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0057: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-3144-8d98-43b9cd9af094
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0058: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-4bd2-ab04-ef88c8029482
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I enter or select "PGDN" in "Lbl_Dog Exposures"
    When I enter or select "PGDN" in "Lbl_Business Details"
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"
    When I enter or select "PGDN" in "Lbl_Farm & Livestock Exposures"

    # Source step 0059: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0060: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-1d1d-2a0a-23c6fad8ee72
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0061: Claims History-Choose to Add Claim 01 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-80ae-94fc-8b9840719e1c
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0062: EQH||Add Non-Weather Claim 01 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-1dfc-bef1-b17a2b9ec595
    When I enter or select "01/25/2016" in "Txt_Claim Date"
    When I enter or select "2000" in "Txt_Claim Amount"
    When I enter or select "524365182" in "Txt_Policy Number"
    Then "Lbl_Claim Status" should exist
    When I click "Btn_Closed"
    When I click "Drp List_Claim Description"
    When I click "Accounts receivable"
    When I click "Btn_SH4 - Tenants"
    Then "Lbl_Weather Related?" should exist
    When I select "Btn_No"
    When I select "Btn_No_Catastrophe Related"
    When I click "Btn_SAVE"

    # Source step 0063: Claims History-Choose to Add Claim 02 | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-2c8c-1f1b-95c2b0b3a67a
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0064: EQH||Add Non-Weather Claim 02 | Module: EQH||Add Claim
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-eff5-3152-50b36154c5e1
    When I enter or select "01/25/2015" in "Txt_Claim Date"
    When I enter or select "1000" in "Txt_Claim Amount"
    When I enter or select "524365282" in "Txt_Policy Number"
    Then "Lbl_Claim Status" should exist
    When I click "Btn_Closed"
    When I click "Drp List_Claim Description"
    When I click "Accounts receivable"
    When I click "Btn_SH4 - Tenants"
    Then "Lbl_Weather Related?" should exist
    When I select "Btn_No"
    When I select "Btn_No_Catastrophe Related"
    When I click "Btn_SAVE"

    # Source step 0065: Claims History-Click Next to move to Discounts page | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-45dc-ce7e-e1ac8c1948f0
    Then I wait until "Claims History Header" is visible
    When I click "Btn_NEXT"

    # Source step 0066: Discounts/Adjustments-Choose Central Fire & Central Burglar Alarm dicounts | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-2c8c-2ae0-6f0325802935
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    When I click "Btn_Chk box_Central Fire Alarm"
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_Chk box_Central Burglar Alarm"
    When I click "Btn_NEXT"

    # Source step 0067: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0068: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $1000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-4cc9-ad20-77d6bd8f1073
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Btn_Reset Fields" is visible
    When I enter or select "{SCROLL[9][1000px][Center][HorizontalFirst][100ms]}" in "Btn_Reset Fields"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_$1,000"
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0069: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-793a-aeac-dcf4b3aab6e6
    When I click "Additional Coverages"

    # Source step 0070: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0071: Additional Coverages-Add 'Scheduled Personal Property' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-fea5-4815-64c42b36a9ab
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Scheduled Personal Property" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0072: EQH||Additional Coverages-Contents Coverages-Select 'Add Scheduled Personal Property' | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-1418-ad62-4ae79341d0a3
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I click "Btn_ADD SCHEDULED PERSONAL PROPERTY"

    # Source step 0073: EQH||Scheduled Coverage-Contents Covg-Scheduled Personal Property | Module: EQH||Scheduled Coverage-Contents Covg-Scheduled Personal Property
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-23ac-baef-ba6b4be98439
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

    # Source step 0074: Additional Coverages-Add 'Increased Coverage For Personal Property In Self Storage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-09dc-8e05-84d62d783bd7
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increased Coverage For Personal Property In Self Storage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0075: Additional Coverages-Add 'Business Merchandise Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-564c-b1cf-7f98ae9c7ea5
    When I enter or select "Business Merchandise Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0076: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0077: Additional Coverages-Add 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-0ae2-4ef0-e5489975549a
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Credit Card, Fund Transfer Card" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0078: EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-004f-e435-00b8d7d61740
    When I click "Btn_$2,000"
    When I click "Btn_Next"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0080: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-7b75-388b-faf98614f82b
    When I click "Additional Coverages"

    # Source step 0081: Additional Coverages-Add 'Contents Replacement Cost Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-3e40-b3ad-a317ee7ca77a
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Contents Replacement Cost Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0082: Additional Coverages-Add 'Increased Coverage For Electronic Equipment In Or On A Vehicle' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-10ac-fd91-4f9cb8da545c
    When I enter or select "Electronic Equipment" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0084: Additional Coverages-Add 'Personal Injury Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-b99e-3039-8949748a259f
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Personal Injury Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0085: EQH||Additional Coverages-Liability Coverages-Update 'Personal Injury Coverage' coverage/endorsement | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e49-1578-c35c-615132e7d369
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I select "Btn_No"
    When I click "Btn_Next"

    # Source step 0086: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0087: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-d8d4-4743-3c7e8a66007f
    When I click "Additional Coverages"

    # Source step 0088: Additional Coverages-Add 'Three Or Four Family Dwelling Premises Liability' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-ecd2-3e25-a947aa1dd019
    When I enter or select "Family Dwelling Premises Liability" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0090: Additional Coverages-Add 'Tenants Water Bed Liability' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-06bd-cdfb-ee33cdaec5f7
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Tenants Water Bed" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0091: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0092: Additional Coverages-Add 'Home Day Care Coverage ' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-9e66-fd82-34f6dd048b77
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Home Day Care Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0093: Additional Coverages-Add 'Additional Insured Residence Premises' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-73c5-4ff4-86af51f2463d
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Additional Insured Residence Premises" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    When I click "Btn_NEXT"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0095: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-356b-ac3a-b07ec88863e4
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0097: Mortgage/Additional Interest-Add Additional Interest | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-fd23-7782-745de14c4fad
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_ADD MORTGAGE / ADD'L INTEREST"

    # Source step 0098: EQH||Add/Edit Additional Interest - Adding Additional Interest | Module: EQH||Add/Edit Additional Interest-Additional Insured/Landlord
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-591a-041c-63f1bae6fdde
    Then I wait until "Lbl_Interest Type" is visible
    Then I wait until "Btn_First Mortgagee" is visible
    When I click "Btn_Additional Insured/Landlord"
    Then I wait until "Btn_Additional Insured" is visible
    When I enter captured runtime value "FirstName" in "Text box_Name"
    When I enter or select "1034 Foxwood Ln" in "Text box_Address"
    When I enter or select "Gouldsboro" in "Text box_City"
    When I select "Dropdown-State-GenericGUI"
    When I click "PA"
    When I enter or select "18424" in "Text box_Zip Code"
    When I click "Btn_SAVE"

    # Source step 0099: Mortgage/Additional Interest-Click NEXT to move to Billing | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-7fa4-b528-753ff5eed14f
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0100: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0101: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-93b0-b141-5aff7fa8bf7c
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

    # Source step 0102: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0123: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0125: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0126: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-b0a5-589f-89e50a709f4f
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

    # Source step 0127: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-db1d-4216-93cfb463d3d3
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0128: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-278b-cf33-cefe94fc91dd
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0130: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-f907-343e-3ad20a06033d
    # Runtime control: Close Chrome > Condition
    Then if the source runtime condition "Close Chrome > Condition" is satisfied, "Expression" should equal "Edge' = 'Chrome"

    # Source step 0131: TBox Start Program | Module: TBox Start Program
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-8434-e8b9-796ecb27e208
    # Runtime control: Close Chrome > Then
    And if the source runtime condition "Close Chrome > Then" is satisfied, I force-close browser/process "chrome.exe" using command "taskkill /im chrome.exe /f"

    # Source step 0132: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-e33b-af11-6296dee9c1a1
    # Runtime control: Close Edge > Condition
    Then if the source runtime condition "Close Edge > Condition" is satisfied, "Expression" should equal "Edge' = 'Edge"

    # Source step 0133: TBox Start Program | Module: TBox Start Program
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
# 5. Source step 0028 field "<unnamed value>" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "405"
# 6. Source step 0029 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 9. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 10. Source step 0034 field "Btn_None of the Above_SH3_SH6" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 11. Source step 0037 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0037 field "Btn_C/O" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 13. Source step 0037 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 14. Source step 0037 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 15. Source step 0037 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 16. Source step 0037 field "Btn_Married" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0037 field "Btn_Son" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 18. Source step 0040 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 19. Source step 0040 field "7.1-10.0" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 20. Source step 0042 field "Location Header" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 21. Source step 0042 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 22. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 23. Source step 0042 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 24. Source step 0042 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0042 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 26. Source step 0042 field "0-3.0" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 27. Source step 0044 "Verify Order Wildfire Risk Score is enabled" in module "EQH||Location" was disabled. Reason: 13.03.24 15:06:17 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "+ ORDER WILDFIRE RISK SCORE" with "True"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 28. Source step 0045 "Get the the Wildfore Risk Score for property" in module "EQH||Location" was disabled. Reason: 13.03.24 15:06:17 [ct2452]
#    - WAIT "Location Header" with a blank value
#    - VERIFY "Lbl_How long have you owned or occupied location?" with a blank value
#    - INPUT "Btn_More than 5 years" with a blank value
#    - VERIFY "Btn_More than 5 years" with a blank value
#    - INPUT "Btn_Hide Google Maps" with a blank value
#    - INPUT "+ ORDER WILDFIRE RISK SCORE" with "X"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with a blank value
#    - INPUT "0-3.0" with a blank value
# 29. Source step 0046 "TBox Wait" in module "TBox Wait" was disabled. Reason: 13.03.24 15:06:17 [ct2452]
#    - INPUT "Duration" with "2000"
# 30. Source step 0047 field "Location Header" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 31. Source step 0047 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 32. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 33. Source step 0047 field "Btn_More than 5 years" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 34. Source step 0047 field "Btn_Hide Google Maps" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 35. Source step 0047 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 36. Source step 0047 field "0-3.0" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 37. Source step 0047 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 38. Source step 0047 field "< 601" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0048 field "Lbl_# of Apts. Between Firewalls" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0048 field "Lbl_Building Occupancy" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}"
# 41. Source step 0049 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.24 15:52:56 [ct2452]
#    - INPUT "Duration" with "8000"
# 42. Source step 0050 "RCT||Home Page" in module "RCT | Home Page" was disabled. Reason: 26.02.24 15:52:56 [ct2452]
#    - WAIT "Btn_Edit_Building Information" with "True"
#    - INPUT "Btn_Finish_Valuation Totals" with "{Click}"
# 43. Source step 0051 "RCT||Pop up-Save,Discard,Close" in module "RCT | Pop up-Save,Discard,Close" was disabled. Reason: 26.02.24 15:52:56 [ct2452]
#    - WAIT "Btn_Save" with "True"
#    - INPUT "Btn_Save" with "X"
#    - INPUT "Btn_Close" with a blank value
# 44. Source step 0052 "RCT||Complete page" in module "RCT | Complete page" was disabled. Reason: 26.02.24 15:52:56 [ct2452]
#    - WAIT "DIV_Complete!" with "True"
#    - VERIFY "DIV_You may now close this window. This valuation is being processed." with "True"
# 45. Source step 0053 "Close the RCT Express page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 26.02.24 15:52:56 [ct2452]
#    - INPUT "Caption" with "test.anpac.info/*"
#    - INPUT "Keys" with "^(w)"
# 46. Source step 0054 "EQH||Home Characteristics-RCT Page Opened Pop up" in module "EQH||Home Characteristics-RCT Page Opened Pop up" was disabled. Reason: 26.02.24 15:52:56 [ct2452]
#    - WAIT "Please click 'OK' after the RCT page has been updated to refresh this page" with "True"
#    - INPUT "Btn_Ok" with "{Click}"
# 47. Source step 0056 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 48. Source step 0056 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 49. Source step 0056 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0056 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0056 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0056 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0056 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0056 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 55. Source step 0056 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 56. Source step 0056 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 57. Source step 0057 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0057 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 59. Source step 0057 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 60. Source step 0057 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0061 field "Btn_NEXT" in "Claims History-Choose to Add Claim 01" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 62. Source step 0063 field "Btn_NEXT" in "Claims History-Choose to Add Claim 02" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 63. Source step 0068 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $1000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 64. Source step 0075 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Business Merchandise Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 65. Source step 0078 field "Lbl_Coverage Catalog" in "EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 66. Source step 0078 field "Lbl_Contents Coverages" in "EQH||Additional Coverages-Contents Coverages-Update 'Credit Card, Fund Transfer Card, Forgery, And Counterfeit Money Coverage - Increased Limit' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 67. Source step 0082 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Coverage For Electronic Equipment In Or On A Vehicle' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 68. Source step 0085 field "Lbl_Personal Injury Coverage" in "EQH||Additional Coverages-Liability Coverages-Update 'Personal Injury Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 69. Source step 0088 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Three Or Four Family Dwelling Premises Liability' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 70. Source step 0095 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0095 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0095 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0095 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 74. Source step 0095 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0095 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 76. Source step 0095 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 77. Source step 0099 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Click NEXT to move to Billing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 78. Source step 0101 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0101 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 80. Source step 0101 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 81. Source step 0101 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0103 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
# 83. Source step 0104 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - INPUT "Duration" with "10000"
# 84. Source step 0105 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 85. Source step 0106 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 86. Source step 0107 "eChecklist-Click the 'Home/ROP Electronic Application' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 87. Source step 0108 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 88. Source step 0109 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - INPUT "Duration" with "10000"
# 89. Source step 0110 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 90. Source step 0111 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 91. Source step 0112 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 92. Source step 0113 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:50:27 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 93. Source step 0114 "eChecklist-Click the 'Copy of Alarm Certificate' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:21:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Copy of Alarm Certificate" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 94. Source step 0115 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:21:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 95. Source step 0116 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:33 [ct2452]
#    - INPUT "Duration" with "10000"
# 96. Source step 0117 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:50:33 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 97. Source step 0118 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:33 [ct2452]
#    - INPUT "Duration" with "10000"
# 98. Source step 0119 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:50:33 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 99. Source step 0120 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:50:33 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 100. Source step 0121 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:33 [ct2452]
#    - INPUT "Duration" with "8000"
# 101. Source step 0122 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 15.03.24 15:12:30 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
#    - INPUT "Btn_Issue Home Binder" with "{Invoke[Click]}"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 102. Source step 0124 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 15.03.24 15:12:36 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
# 103. Source step 0126 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 104. Source step 0126 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 105. Source step 0126 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 106. Source step 0127 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 107. Source step 0127 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 108. Source step 0129 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.03.24 15:43:14 [ct2452]
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
