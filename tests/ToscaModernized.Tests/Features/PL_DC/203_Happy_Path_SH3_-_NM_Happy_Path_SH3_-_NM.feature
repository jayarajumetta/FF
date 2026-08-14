# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 203_Happy_Path_SH3_-_NM_Happy_Path_SH3_-_NM.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @happy_path @Edge @manual @obsolete @automated
Feature: Execute Happy Path SH3 - NM for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path SH3 - NM workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path SH3 - NM using representative iteration Happy Path SH3 - NM
    # Source step 0026: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c94-3698-eece-b15fcb9e2b55
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0027: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c94-709b-b3a7-2c4e91174d74
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0028: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c94-e4ac-a1c1-00c3190bd8b1
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

    # Source step 0029: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c94-9474-58f6-5e2293804627
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "2000000000" in "<unnamed value>"
    When I enter or select "out@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter captured runtime value "FullAddress" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0030: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c94-3c0b-de8a-fda0eec016d5
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
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][+5d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_NEW MEXICO_1"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0031: Proposal Start-Invalid Address,SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c94-087c-b6dd-60bd091a40fa
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0032: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0033: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-5461-fd46-3085c481dfe1
    Then I wait until "Lbl_Client Eligibility Restrictions" is visible
    Then "Btn_NO VALID SSN FOR ACCOUNT OWNER" should exist
    Then "Btn_None Of The Above_Client ER" should exist
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    Then "Lbl_Property Eligibility Restrictions" should exist
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_MORE THAN 2 UNITS"
    Then "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" should exist
    Then "Btn_None Of The Above_Property Eligibility Restrictions_SH4" should exist
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0034: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-f7ee-62bc-722b7a0a8904
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0035: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-358e-717d-54288732301e
    # Runtime control: Wait for Page to Load [max=30] > Condition
    Then if the source runtime condition "Wait for Page to Load [max=30] > Condition" is satisfied, "Lbl_Choose Insureds From Existing Account" should be visible

    # Source step 0036: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Wait for Page to Load [max=30] > Loop
    When if the source runtime condition "Wait for Page to Load [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0037: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-7a11-f930-73a708c5cff2
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0038: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-345c-36c3-69a5fa7fa522
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-537b-bab5-d89de278bd11
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0040: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0041: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-4153-2a3b-b1d9133159d3
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-a669-f64a-06b486113f79
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0044: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0045: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-9ca5-7252-ea544a388d5c
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0046: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-3177-5b26-c08d93f91b15
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0047: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0048: EQH||Location-provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-7226-2ec2-f38783c747ab
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0049: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-7982-e0ed-61e15cac3e21
    When I enter or select "PGUP" in "Home Characteristics Header"
    Then I wait until "Txt_Year Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Year Built"
    When I enter or select "\"{DEL}\"" in "Txt_Year Built"
    When I enter captured runtime value "YearOfBuild" in "Txt_Year Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter captured runtime value "LivingArea" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    When I click "Btn_Shingles, Architectural"
    Then "Btn_Shingles, Asphalt/Fiberglass" should exist
    Then "Btn_Tile, Clay" should exist
    Then I wait until "Btn_More Options_Roof Type" is visible
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-ab6d-68f1-d163d902c138
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0052: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-ac4b-1b3c-a6ea34e36349
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0053: RCT||Complete page | Module: RCT | Complete page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-c6ab-b0e3-3b05fbc96251
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0054: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-b99d-572c-5a5db65754b4
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0055: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-2c5e-5339-b4d73ee7b9e7
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0056: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0057: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-4667-baa4-b07f189e79e8
    When I enter or select "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}" in "Lbl_Is Principal Heating System Thermostatically Controlled ?"
    Then I wait until "Lbl_Construction Type" is visible
    When I click "Btn_Frame"
    Then "Btn_Siding" should exist
    Then "Btn_Veneer" should exist
    Then I wait until "Lbl_Building Occupancy" is visible
    When I click "Btn_Owner"
    Then I wait until "Btn_Tenant" is visible
    Then I wait until "Btn_Under Construction" is visible
    Then I wait until "Btn_More Options_Building Occupancy" is visible
    When I click "Txt_Market Value"
    When I enter or select "{Doubleclick}" in "Txt_Market Value"
    When I enter or select "\"^{a}\"" in "Txt_Market Value"
    When I enter or select "\"DEL\"" in "Txt_Market Value"
    When I enter captured runtime value "MarketValue" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I press "Tab" while focused on "Txt_Heating (Year)"
    When I press "Tab" while focused on "Txt_Cooling (Year)"
    When I press "Tab" while focused on "Txt_Plumbing (Year)"

    # Source step 0058: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0059: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-ce84-89d3-ccac7385a6f9
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-c960-1f20-46bc4f8d17ff
    When I enter or select "PGDN" in "Txt_Market Value"
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0062: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0063: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-83cc-821b-ccdf1b5663d9
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-8b77-952a-c43341aa5233
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0066: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-3830-ecc9-1976e32c4f4f
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0067: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-d4a9-dd5f-ebe486f133de
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "check_box_outline_blankNone of the Above - Special Exposures"
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0068: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-0aca-f2d3-a6293eb494dc
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0069: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-bb5b-bbfd-55e4d8ed4948
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0070: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-2153-11be-faf7ba2d79d5
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0071: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: 19 EQ | Home - On Premise Exposure Standard | Source XTestStep: 3a19e1e5-4091-b2a6-33df-bcbe74cfc99e
    When I click "Btn_NEXT"

    # Source step 0075: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-e017-bc56-9c5ad00d4201
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0076: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-ff9c-5259-05d773166ed1
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    When I click "Btn_NEXT"

    # Source step 0077: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0078: EQH||Coverages-Edit-Option 1 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-bf6e-ffd0-71385ab01eb5
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

    # Source step 0079: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0080: Additional Coverages-Add 'Blanket Jewelry, Watches, And Furs Coverage - $5,000' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c96-ec73-84de-f1722a2cde55
    Then I wait until "Txt_Search by Name-Coverage Catalog" is enabled
    When I enter or select "Blanket Jewelry" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "18000" milliseconds

    # Source step 0082: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-b01c-2de2-8b763af0d284
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-ca1e-2bed-8aa4c64897e7
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    Then "Btn_ADD MORTGAGE / ADD'L INTEREST" should exist
    When I click "Btn_NEXT"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0086: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-d0ff-ca65-76ada48f87aa
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

    # Source step 0121: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-bc99-8549-a6d4823fdb49
    When I enter or select "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 1. Review Messages"
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" is visible
    Then "Lbl_Step 3. Attach Supporting Documentation" should exist
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0122: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0123: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-a72e-6025-4c8abb3823b3
    # Runtime control: If_eChecklist Sign on page showed up or not > Condition
    Then if the source runtime condition "If_eChecklist Sign on page showed up or not > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0124: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-bb0e-c370-e42cd9bb11a4
    # Runtime control: If_eChecklist Sign on page showed up or not > Then
    When if the source runtime condition "If_eChecklist Sign on page showed up or not > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0125: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-ea1a-5fb1-9352a24ce473
    When I click "Link_Home/ROP Electronic Application"
    When I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0126: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-2f3d-8631-81179f79153c
    When I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0127: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0132: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-dd92-dcca-6d6096953c82
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0133: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0134: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-02a1-71e7-e3b381cab873
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0135: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-fc19-07d6-6000fe2ddd43
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0136: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0137: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-34a4-b495-7ed63d719835
    Then "Hdr_Submission Header" should exist
    Then I wait until "Lbl_Step 3. Attach Supporting Documentation" exists
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Step 4. Transmit"
    Then "Btn_Transmit_1" should exist
    When I click "Btn_Transmit_1"

    # Source step 0138: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0139: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-1e38-6345-1d04326bb0b9
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0140: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0141: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-dbdb-f6a1-150d4962884d
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

    # Source step 0156: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-8122-4917-3cc6799faa18
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0157: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1ca3-fae2-8cc0-d453ddf8ea66
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
#    - Preserved source value: "{Click[10px][10px]}"
# 5. Source step 0029 field "<unnamed value>" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}"
# 6. Source step 0030 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 7. Source step 0031 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0031 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0031 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 10. Source step 0033 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 11. Source step 0033 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "PGDN"
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
# 39. Source step 0048 field "Location Header" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0048 field "Lbl_How long have you owned or occupied location?" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 41. Source step 0048 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 42. Source step 0048 field "Btn_More than 5 years" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0048 field "Btn_Hide Google Maps" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 44. Source step 0048 field "Drp List_Miles to Fire Station-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0048 field "0-3.0" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 46. Source step 0048 field "Drp List_Feet to Hydrant-need to check" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 47. Source step 0048 field "< 601" in "EQH||Location-provide other details and complete" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0049 field "Btn_Manufactured Home" in "Home Characteristics-Cost Estimator info till Get Valuation" was disabled. Reason:  
#    - Preserved source value: "True"
# 49. Source step 0052 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 50. Source step 0057 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0057 field "Lbl_Principal Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0057 field "Btn_None" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0057 field "Btn_Central" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 54. Source step 0057 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0057 field "Btn_None_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0057 field "Btn_Central_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 57. Source step 0057 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0057 field "Lbl_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0057 field "Btn_None_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 60. Source step 0057 field "Btn_UL3" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0057 field "Btn_NEXT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 62. Source step 0059 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0059 field "Btn_Frame" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0059 field "Btn_Siding" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0059 field "Btn_Veneer" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0059 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 67. Source step 0059 field "Btn_Owner" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 68. Source step 0059 field "Btn_Tenant" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 70. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 71. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 72. Source step 0059 field "Txt_Market Value" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 73. Source step 0059 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 74. Source step 0059 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 75. Source step 0059 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 76. Source step 0059 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 77. Source step 0059 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 78. Source step 0059 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 79. Source step 0059 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 80. Source step 0059 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 81. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0059 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 83. Source step 0059 field "Btn_UL3" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0059 field "Btn_NEXT" in "Home Characteristics-Heating Details Principal Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 85. Source step 0061 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0061 field "Btn_Frame" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 87. Source step 0061 field "Btn_Siding" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 88. Source step 0061 field "Btn_Veneer" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 89. Source step 0061 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 90. Source step 0061 field "Btn_Owner" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 91. Source step 0061 field "Btn_Tenant" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0061 field "Btn_Under Construction" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 93. Source step 0061 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0061 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 95. Source step 0061 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 96. Source step 0061 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 97. Source step 0061 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 98. Source step 0061 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 99. Source step 0061 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 100. Source step 0061 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 101. Source step 0061 field "Btn_Central" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 102. Source step 0061 field "Btn_Floor Furnace" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 103. Source step 0061 field "Btn_More Options_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 104. Source step 0061 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 105. Source step 0061 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 106. Source step 0061 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 107. Source step 0061 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 108. Source step 0061 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 109. Source step 0061 field "Btn_UL3" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 110. Source step 0061 field "Btn_NEXT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 111. Source step 0063 field "Lbl_Construction Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0063 field "Btn_Frame" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 113. Source step 0063 field "Btn_Siding" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 114. Source step 0063 field "Btn_Veneer" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 115. Source step 0063 field "Lbl_Building Occupancy" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 116. Source step 0063 field "Btn_Owner" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 117. Source step 0063 field "Btn_Tenant" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 118. Source step 0063 field "Btn_Under Construction" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 119. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 120. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 121. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "\"DEL\""
# 122. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "350999"
# 123. Source step 0063 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 124. Source step 0063 field "Txt_Electric (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 125. Source step 0063 field "Txt_Heating (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 126. Source step 0063 field "Txt_Cooling (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 127. Source step 0063 field "Txt_Plumbing (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 128. Source step 0063 field "Lbl_Principal Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 129. Source step 0063 field "Btn_None" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 130. Source step 0063 field "Btn_Central" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 131. Source step 0063 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 132. Source step 0063 field "Btn_None_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 133. Source step 0063 field "Btn_Central_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 134. Source step 0063 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 135. Source step 0063 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 136. Source step 0065 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 137. Source step 0065 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 138. Source step 0065 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 139. Source step 0065 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 140. Source step 0065 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 141. Source step 0065 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 142. Source step 0065 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 143. Source step 0065 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 144. Source step 0065 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 145. Source step 0065 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 146. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 147. Source step 0066 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 148. Source step 0066 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{CLICK}"
# 149. Source step 0066 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 150. Source step 0072 "On Premise Exposures-Provide details regarding any exposures" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:32:12 [ct2452]
#    - WAIT "On Premise Exposures Header" with "True"
#    - WAIT "Lbl_Other Structures" with "True"
#    - VERIFY "Btn_ Add Other Structure" with "True"
#    - VERIFY "Lbl_Special Exposures" with "True"
#    - VERIFY "Btn_Chk box_Swimming pool" with "True"
#    - INPUT "check_box_outline_blankNone of the Above - Special Exposures" with "{Click}"
#    - INPUT "Btn_Chk box_None of the Above - Business Details" with "{Click}"
#    - INPUT "Lbl_Dog Exposures" with "PGDN"
#    - INPUT "Lbl_Business Details" with "PGDN"
#    - WAIT "Btn_Chk box_Animal Boarding" with "True"
#    - WAIT "Btn_Chk box_Adult 24 Hour Foster Care (Ages 15+)" with "True"
#    - VERIFY "Btn_Chk box_BUSINESS ON PREMISE" with "True"
#    - INPUT "Btn_Chk box_None Of The Above" with "{CLICK}"
#    - INPUT "Lbl_Farm & Livestock Exposures" with "PGDN"
#    - WAIT "Btn_Chk box_Incidental Farming on premise" with "True"
#    - WAIT "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "X"
#    - VERIFY "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "{CLICK}"
# 151. Source step 0073 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.05.24 12:32:12 [ct2452]
#    - INPUT "Duration" with "5000"
# 152. Source step 0074 "On Premise Exposures-Provide details and go to next page" in module "EQH||On Premise Exposures" was disabled. Reason: 29.05.24 12:32:12 [ct2452]
#    - INPUT "Lbl_Farm & Livestock Exposures" with "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" with "True"
#    - INPUT "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility" with "{CLICK}"
#    - WAIT "Btn_NEXT" with "True"
#    - INPUT "Btn_NEXT" with "X"
# 153. Source step 0078 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 154. Source step 0082 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 155. Source step 0082 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 156. Source step 0082 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 157. Source step 0082 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 158. Source step 0082 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 159. Source step 0082 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 160. Source step 0082 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 161. Source step 0086 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 162. Source step 0086 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 163. Source step 0086 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 164. Source step 0086 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 165. Source step 0088 "Submission- UW Referral and add agent comments" in module "EQ||Submission" was disabled. Reason: 06.05.24 17:39:26 [ct2452]
#    - WAIT "Hdr_Submission Header" with "True"
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}"
#    - INPUT "Txt_UW1_AgentComments" with "Test"
#    - INPUT "Btn_Refer to UW_1" with "{Click}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{CLICK}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - VERIFY "Lbl_Step 4. Transmit" with "True"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - VERIFY "Btn_Issue Home Binder" with "True"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 166. Source step 0089 "TBox Wait" in module "TBox Wait" was disabled. Reason: 06.05.24 17:39:26 [ct2452]
#    - INPUT "Duration" with "10000"
# 167. Source step 0090 "OpenUrl" in module "OpenUrl" was disabled. Reason: 09.04.24 23:23:54 [ct2452]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 168. Source step 0091 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 169. Source step 0092 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 170. Source step 0093 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 171. Source step 0094 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 09.04.24 23:23:54 [ct2452]
#    - VERIFY "Lbl_Login ID" with "True"
# 172. Source step 0095 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 09.04.24 23:23:54 [ct2452]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 173. Source step 0096 "EU||Home" in module "EU||Home" was disabled. Reason: 09.04.24 23:23:54 [ct2452]
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
# 174. Source step 0097 "OpenUrl" in module "OpenUrl" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 175. Source step 0098 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 176. Source step 0099 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 177. Source step 0100 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 178. Source step 0101 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - VERIFY "Lbl_Login ID" with "True"
# 179. Source step 0102 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 180. Source step 0103 "EU||Home" in module "EU||Home" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 181. Source step 0104 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 182. Source step 0105 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 183. Source step 0106 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 184. Source step 0107 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 185. Source step 0108 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 186. Source step 0109 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 187. Source step 0110 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 188. Source step 0111 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "Title" with "*Home*"
# 189. Source step 0112 "TBox Wait" in module "TBox Wait" was disabled. Reason: 06.05.24 17:39:33 [ct2452]
#    - INPUT "Duration" with "12000"
# 190. Source step 0113 "Close the Express UI page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 08.03.24 16:38:06 [ct2452]
#    - INPUT "Caption" with "Home*"
#    - INPUT "Keys" with "^(w)"
# 191. Source step 0114 "EQH||Quote Actions-Save and Exit the current Quote" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 06.05.24 17:39:42 [ct2452]
#    - INPUT "Btn_QUOTE ACTIONS" with "X"
#    - WAIT "Btn_Quote Actions_Save and Exit" with "True"
#    - INPUT "Btn_Quote Actions_Save and Exit" with "X"
# 192. Source step 0115 "Search for the Quote in EQ" in module "EQ||New Quote" was disabled. Reason: 06.05.24 17:39:42 [ct2452]
#    - WAIT "Btn_New Quote" with "True"
#    - INPUT "Btn_New Quote" with "X"
#    - INPUT "Txt_QuoteSearch_Input" with the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}"
#    - INPUT "Btn_Search_1" with "{Click}"
# 193. Source step 0116 "EQH||Side Menu and Quote Actions-Navigate to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 06.05.24 17:39:42 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 194. Source step 0117 "TBox Wait" in module "TBox Wait" was disabled. Reason: 06.05.24 17:39:42 [ct2452]
#    - INPUT "Duration" with "5000"
# 195. Source step 0118 "EQH||Side Menu and Quote ActionsNavigate to Location page to remove WildFire error on submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 29.01.24 13:32:45 [ct2452]
#    - INPUT "Location" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 196. Source step 0119 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.01.24 13:32:45 [ct2452]
#    - INPUT "Duration" with "5000"
# 197. Source step 0120 "EQH||Side Menu and Quote Actions-Navigate back to Submission page" in module "EQH||Side Menu and Quote Actions" was disabled. Reason: 29.01.24 13:32:57 [ct2452]
#    - INPUT "Submission" with "{Click}"
#    - INPUT "Transmit Confirmation" with "{Click}"
# 198. Source step 0121 field "Hdr_Submission Header" in "Submission- Launch to Checklist" was disabled. Reason:  
#    - Preserved source value: "True"
# 199. Source step 0128 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:13:21 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 200. Source step 0129 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:13:21 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 201. Source step 0130 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 202. Source step 0131 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:13:21 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 203. Source step 0137 field "Btn_Save and Exit_1" in "Submission-Transmit and issue Policy" was disabled. Reason:  
#    - Preserved source value: "True"
# 204. Source step 0139 field "Transmit Confirmation Header" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "True"
# 205. Source step 0139 field "Submission" in "Transmit Confirmation-Get Policy Number, Premium details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 206. Source step 0141 field "Data structure > State" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: "NM"
# 207. Source step 0142 "TestData-Save PolicyNumber, Date to TDM for Post XML validation" in module "TestData - Create & provide new item" was disabled. Reason: 06.05.24 16:36:31 [ct2452]
#    - INPUT "Existing or new TDS type" with "Regression_Temp_Data"
#    - INPUT "Data structure > TestCaseName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > EffectiveDate" with captured runtime value "Effective Date"
#    - INPUT "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
#    - INPUT "Data structure > State" with "NM"
# 208. Source step 0143 "Set LOB & State" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - INPUT "LOB" with "Home"
#    - INPUT "State" with "NM"
# 209. Source step 0144 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 210. Source step 0145 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 211. Source step 0146 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 212. Source step 0147 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 213. Source step 0148 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 214. Source step 0149 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 215. Source step 0150 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 216. Source step 0151 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 217. Source step 0152 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 218. Source step 0153 "TestData - Find & provide item from TDM" in module "Old_TestData - Find & provide item" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
#    - INPUT "Data search filter > State" with captured runtime value "State"
#    - INPUT "Data search filter > LOB" with captured runtime value "LOB"
# 219. Source step 0154 "Get Validated Premium from TDM" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
#    - INPUT "Expected_ValidatedPremium" with the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium"
# 220. Source step 0155 "Compare Actual Premium vs Expected Premium" in module "TBox Set Buffer" was disabled. Reason: 06.05.24 16:32:00 [ct2452]
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
