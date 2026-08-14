# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 205_Happy_Path_SH4_-_NM_Happy_Path_SH4_-_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @happy_path @Edge @manual @obsolete @automated
Feature: Execute Happy Path SH4 - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path SH4 - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path SH4 - NM using representative iteration Happy Path SH4 - NM
    # Source step 0026: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-0a0c-e511-ecbd0b07b413
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0027: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-9a8a-8db6-98747f1f9720
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0028: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-bb4b-1fd6-98ac57b2064a
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

    # Source step 0029: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-b60f-be44-0513654bfec8
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "8000000000" in "<unnamed value>"
    When I enter or select "wuyaus@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter captured runtime value "FullAddress" in "<unnamed value>"
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

    # Source step 0030: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-4a89-985a-582812700031
    Then "Btn_PERSONAL AUTO" should exist
    Then "Btn_MOTORCYCLE" should exist
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    Then "Btn_SH3-HOMEOWNERS" should be visible
    Then "Btn_SH4-TENANTS" should be visible
    When I click "Btn_SH4-TENANTS"
    Then "Btn_SH6-CONDOMINIUM OWNERS" should exist
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][+2d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_NEW MEXICO_1"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0031: Verify that Invalid address pop up is shown  | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-6a66-1b59-f624805176be
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0032: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-56fc-9707-ef3fa8d24e0c
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0033: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-2fa1-728e-4cc129d6a8da
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0034: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0035: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-4cf5-c276-c8ea4c9e9551
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

    # Source step 0036: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-5471-9e6f-9ffc3757fb65
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0037: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-27bb-7042-3726cbcf839b
    # Runtime control: Wait for Page to Load [max=30] > Condition
    Then if the source runtime condition "Wait for Page to Load [max=30] > Condition" is satisfied, "Lbl_Choose Insureds From Existing Account" should be visible

    # Source step 0038: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Page to Load [max=30] > Loop
    When if the source runtime condition "Wait for Page to Load [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0039: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-d8a2-2c1f-c531650d10db
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0040: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-047d-6b76-6bac3337a710
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

    # Source step 0041: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-e1d0-c8fa-0bb2ddfc9033
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0042: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0043: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-03cc-43fb-d68091e3d3f4
    Then I wait until "Location Header" exists
    Then "Lbl_How long have you owned or occupied location?" should exist
    When I click "Btn_More than 5 years"
    Then "Btn_More than 5 years" should exist
    When I enter or select "{SCROLL[12][1000px][None][HorizontalFirst][300ms]}" in "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0045: EQH||Location-till feet to hydrant | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-4952-5ef0-52078020df04
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0050: EQH||Location-Provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-af7e-5195-a96a8d87f8b9
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0051: EQH||Home Characteristics_SH4-Provide all details and move to next page | Module: EQH||Home Characteristics_SH4
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cb4-d9bf-32d0-3835dcc38638
    Then I wait until "Home Characteristics_Header" is visible
    Then "Txt_Years Built" should exist
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter captured runtime value "YearOfBuild" in "Txt_Years Built"
    Then I wait until "Txt_Years Built" is visible
    When I click "1 - 4 Units"
    When I enter or select "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Home Type"
    When I click "Conventional"
    When I click "Frame"
    When I click "Btn_PrincipalHeat_Central"
    When I click "Btn_SupplementalHeat_Floor Furnace"
    When I click "Btn_Home Characteristics_Next"

    # Source step 0052: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0053: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc2-9614-5edb-73a954327f20
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0054: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc2-5b59-0399-c9e49fcf020b
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0055: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-d4a9-dd5f-ebe486f133de
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "check_box_outline_blankNone of the Above - Special Exposures"
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0056: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-0aca-f2d3-a6293eb494dc
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0057: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-bb5b-bbfd-55e4d8ed4948
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0058: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-2153-11be-faf7ba2d79d5
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0059: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-b2a6-33df-bcbe74cfc99e
    When I click "Btn_NEXT"

    # Source step 0063: Claims History-Add claims | Module: EQH||Claims History
    # Section: Process > Add 1 Non-Weather Related Claim | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-c19f-fc99-f85b52355d55
    Then I wait until "Claims History Header" is visible
    When I click "Btn_ADD CLAIM"

    # Source step 0064: EQH||Add Non-Weather Claim 01 | Module: EQH||Add Claim
    # Section: Process > Add 1 Non-Weather Related Claim | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-1cbe-8821-dde2a631791e
    When I enter a RANDOM value matching "1 random digits/characters" in "Txt_Claim Date"
    When I enter a RANDOM value matching "1000][5000 random digits/characters" in "Txt_Claim Amount"
    When I enter a RANDOM value matching "520000000][620000000 random digits/characters" in "Txt_Policy Number"
    When I click "Btn_Closed"
    When I click "Drp List_Claim Description"
    When I click "Accounts receivable"
    When I click "Btn_SH6 - Condominium Owners"
    When I select "Btn_No"
    When I select "Btn_No_Catastrophe Related"
    When I click "Btn_SAVE"

    # Source step 0065: Claims History-Click Next to move to Discounts page | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-52e2-79c3-01b667b61824
    Then I wait until "Claims History Header" is visible
    When I click "Btn_NEXT"

    # Source step 0066: Discounts/Adjustments-Choose Central Fire & Central Burglar Alarm dicounts | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-5dfc-8620-a13159244500
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-4bfb-3b6f-73917165b739
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

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0070: Additional Coverages-Add 'Increased Coverage For Personal Property In Self Storage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-aa4e-9b8f-b686524a9fe1
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increased Coverage For Personal Property In Self Storage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    When I click "Btn_NEXT"

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0072: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-317f-670e-a90d2c3cbb96
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0074: Mortgage/Additional Interest-Click NEXT to move to Billing | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-8898-58e0-df16c6c98cc2
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0075: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0076: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-4560-ccd0-5469fdf7a086
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

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0078: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-16be-27b8-2132ce73da8c
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0080: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-9f2e-a01d-8df620d32aea
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0081: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-9b08-581a-45be4f0dd92d
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0082: eChecklist-Click the 'Home/ROP Electronic Application' in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-47d2-2051-f0f678aa6db4
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0083: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-c166-2936-6cbc4f43f595
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0084: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0085: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-d796-5958-19df33e93ca5
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0086: eChecklist-Click the drag/drop link to upload the file in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-0675-646a-717417d78d76
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0088: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-0e6f-58b1-353b80cdb0c2
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0090: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-8671-861c-a8b4d28dda50
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0091: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0092: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-7a8f-27a6-1b31d5b158fe
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0093: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-a5a1-12e0-eab702032983
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0095: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-bcbb-9900-ef9152927710
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    When I click "Btn_Transmit_1"

    # Source step 0096: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0097: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-92cb-3ba5-39bb49d44831
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0099: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-4cd8-32ad-c67ed3e8f622
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "Home_PolicyData_Smoke"
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

    # Source step 0114: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-809d-678a-e54a52b56689
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0115: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1cc4-6b1a-6db7-30f634f7e306
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
# 4. Source step 0027 field "Hdr_SECTION-ExpertQuote static word below AN symbol on top left" in "Start New Quote in EQ" was disabled. Reason:  
#    - Preserved source value: a blank value
# 5. Source step 0029 field "<unnamed value>" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "405"
# 6. Source step 0030 field "Btn_SH3-HOMEOWNERS" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 7. Source step 0030 field "Btn_SD1-RENTAL OWNERS" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 8. Source step 0030 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 9. Source step 0030 field "Drp List_PENNSYLVANIA" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0033 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 11. Source step 0033 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0033 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0035 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 14. Source step 0035 field "Btn_None of the Above_SH3_SH6" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 15. Source step 0040 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 16. Source step 0040 field "Btn_C/O" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0040 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 18. Source step 0040 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 19. Source step 0040 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 20. Source step 0040 field "Btn_Married" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0040 field "Btn_Son" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0043 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 23. Source step 0043 field "7.1-10.0" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 24. Source step 0045 field "Location Header" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 26. Source step 0045 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 27. Source step 0045 field "Btn_More than 5 years" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 28. Source step 0045 field "Btn_Hide Google Maps" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 29. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 30. Source step 0045 field "0-3.0" in "EQH||Location-till feet to hydrant" was disabled. Reason:  
#    - Preserved source value: a blank value
# 31. Source step 0047 "Verify Order Wildfire Risk Score is enabled" in module "EQH||Location" was disabled. Reason: 27.02.24 13:27:57 [ct2452]
#    - WAIT "Location Header" with "True"
#    - VERIFY "Lbl_How long have you owned or occupied location?" with "True"
#    - INPUT "Btn_More than 5 years" with "X"
#    - VERIFY "Btn_More than 5 years" with "True"
#    - INPUT "Btn_Hide Google Maps" with "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "+ ORDER WILDFIRE RISK SCORE" with "True"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with "{Click}"
#    - INPUT "0-3.0" with "{Click}"
# 32. Source step 0048 "Get the the Wildfore Risk Score for property" in module "EQH||Location" was disabled. Reason: 27.02.24 13:27:57 [ct2452]
#    - WAIT "Location Header" with a blank value
#    - VERIFY "Lbl_How long have you owned or occupied location?" with a blank value
#    - INPUT "Btn_More than 5 years" with a blank value
#    - VERIFY "Btn_More than 5 years" with a blank value
#    - INPUT "Btn_Hide Google Maps" with a blank value
#    - INPUT "+ ORDER WILDFIRE RISK SCORE" with "X"
#    - INPUT "Drp List_Miles to Fire Station-need to check" with a blank value
#    - INPUT "0-3.0" with a blank value
# 33. Source step 0049 "TBox Wait" in module "TBox Wait" was disabled. Reason: 27.02.24 13:27:57 [ct2452]
#    - INPUT "Duration" with "2000"
# 34. Source step 0050 field "Location Header" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 35. Source step 0050 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 36. Source step 0050 field "Btn_More than 5 years" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 37. Source step 0050 field "Btn_More than 5 years" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 38. Source step 0050 field "Btn_Hide Google Maps" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 39. Source step 0050 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 40. Source step 0050 field "0-3.0" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 41. Source step 0050 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 42. Source step 0050 field "< 601" in "EQH||Location-Provide other details and complete" was disabled. Reason:  
#    - Preserved source value: a blank value
# 43. Source step 0051 field "Lbl_# of Apts. Between Firewalls" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0051 field "Lbl_Structure Type" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0051 field "Single Family" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0051 field "Triplex" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "X"
# 47. Source step 0051 field "Lbl_Building Occupancy" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}"
# 48. Source step 0053 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 49. Source step 0053 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 50. Source step 0053 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0053 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0053 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0053 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0053 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0053 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 56. Source step 0053 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 57. Source step 0053 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 58. Source step 0054 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0054 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 60. Source step 0054 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 61. Source step 0054 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0060 "On Premise Exposures-Provide details regarding any exposures" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:45:01 [ct2452]
#    - WAIT "On Premise Exposures Header" with "True"
#    - VERIFY "Btn_Chk box_Swimming pool" with "True"
#    - INPUT "Btn_Chk box_None of the Above - Business Details" with "{Click}"
#    - INPUT "Lbl_Dog Exposures" with "PGDN"
#    - INPUT "Lbl_Business Details" with "PGDN"
#    - VERIFY "Btn_Chk box_BUSINESS ON PREMISE" with "True"
#    - INPUT "Btn_Chk box_None Of The Above" with "{CLICK}"
#    - INPUT "Lbl_Farm & Livestock Exposures" with "PGDN"
# 63. Source step 0061 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.05.24 12:45:01 [ct2452]
#    - INPUT "Duration" with "5000"
# 64. Source step 0062 "On Premise Exposures-Provide details and go to next page" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:45:01 [ct2452]
#    - INPUT "Lbl_Farm & Livestock Exposures" with "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "{CLICK}"
#    - WAIT "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "X"
# 65. Source step 0068 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $1000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 66. Source step 0072 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 67. Source step 0072 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0072 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0072 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 70. Source step 0072 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0072 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 72. Source step 0072 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 73. Source step 0074 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Click NEXT to move to Billing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 74. Source step 0076 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0076 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0076 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 77. Source step 0076 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0086 field "H4" in "eChecklist-Click the drag/drop link to upload the file in the checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 79. Source step 0087 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 80. Source step 0095 field "Btn_Launch To Checklist_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 81. Source step 0095 field "Btn_Launch To eSignature_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0095 field "Btn_Transmit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 83. Source step 0095 field "Btn_Issue Home Binder" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 84. Source step 0095 field "Btn_Save and Exit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 85. Source step 0097 field "Transmit Confirmation Header" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0099 field "Data structure > State" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: "NM"
# 87. Source step 0100 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 06.05.24 20:01:21 [ct2452]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "NM"
# 88. Source step 0101 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 20:00:57 [ct2452]
#    - INPUT "LOB" with "Home"
#    - INPUT "State" with "NM"
# 89. Source step 0102 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 90. Source step 0103 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 91. Source step 0104 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 92. Source step 0105 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 93. Source step 0106 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 94. Source step 0107 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 95. Source step 0108 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 96. Source step 0109 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 97. Source step 0110 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 98. Source step 0111 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 06.05.24 20:00:57 [ct2452]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 99. Source step 0112 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 20:00:57 [ct2452]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 100. Source step 0113 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 20:00:57 [ct2452]
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
