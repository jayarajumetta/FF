# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 148_Home_Mid-Term_Evaluations_-_Remove_Discount_-_PA_Home_Mid-Term_Evaluations_-_Remove_Disco.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @manual_conversion @Edge @manual @archive @automated
Feature: Execute Home Mid-Term Evaluations - Remove Discount - PA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Mid-Term Evaluations - Remove Discount - PA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Mid-Term Evaluations - Remove Discount - PA using representative iteration Home Mid-Term Evaluations - Remove Discount - PA
    # Source step 0026: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > 01 Start New Quote and Client Selection > Start New Quote | Reusable flow: Old Home & Auto | 01 EQ |  Start New Quote and Client Selection | Source XTestStep: 3a19dd55-d407-6193-d330-a4ed1f7ca7e6
    Given I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info & Create New Client | Module: EQ || Client Selection
    # Section: Process > 01 Start New Quote and Client Selection > Client Slection & Account Details for New Client | Reusable flow: Old Home & Auto | 01 EQ |  Start New Quote and Client Selection | Source XTestStep: 3a19dd55-d407-36e3-b8e6-8fed06bec548
    Then I wait until "<unnamed value>" exists
    When I enter captured runtime value "FirstName" in "<unnamed value>"
    When I enter captured runtime value "LastName" in "<unnamed value>"
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I click "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0028: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > 01 Start New Quote and Client Selection > Client Slection & Account Details for New Client | Reusable flow: Old Home & Auto | 01 EQ |  Start New Quote and Client Selection | Source XTestStep: 3a19dd55-d407-2b0f-f4ec-c86a9289e583
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "2000000000" in "<unnamed value>"
    When I enter or select "out@aol.com" in "<unnamed value>"
    When I click "<unnamed value>"
    When I enter captured runtime value "FullAddress" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: Proposal Start-With Effective Date prior to 90 days from current date | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-bb78-670f-fbbabd695b22
    Then "Btn_PERSONAL AUTO" should exist
    Then "Btn_MOTORCYCLE" should exist
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    Then "Btn_SH3-HOMEOWNERS" should be visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
    Then "Btn_SH6-CONDOMINIUM OWNERS" should exist
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][-90d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I select "Drp List_Rating State"
    When I click "Drp List_PENNSYLVANIA"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0030: Verify that Invalid address pop up is shown  | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-172c-5421-1b28671b6e36
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-8f32-88cf-979da690ea87
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: TBox Wait | Module: TBox Wait
    # Section: Process > 02 Proposal Start | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0033: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-7787-f283-e9a327be8075
    # Runtime control: Proposal Start-Provide SSN details,Client already exists > If confirm button is visible
    Then if the source runtime condition "Proposal Start-Provide SSN details,Client already exists > If confirm button is visible" is satisfied, "Btn_Confirm client's SSN_CONFIRM" should be visible

    # Source step 0034: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-8fbf-65ff-709689a0a1a0
    # Runtime control: Proposal Start-Provide SSN details,Client already exists > Click on confirm button
    When if the source runtime condition "Proposal Start-Provide SSN details,Client already exists > Click on confirm button" is satisfied, I click "Btn_Confirm client's SSN_CONFIRM"
    When I click "Btn_Client Already Exists_USE EXISTING ACCOUNT"

    # Source step 0035: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-be75-0101-1826f0f70db6
    # Runtime control: Proposal Start-Provide SSN details,Client already exists > Provide SSN Details
    When if the source runtime condition "Proposal Start-Provide SSN details,Client already exists > Provide SSN Details" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0036: Check LOB SubCategory | Module: TBox Set Buffer
    # Section: Process > 03 Pre-Qualification | Reusable flow: 03 EQ | Home - Pre-Qualification | Source XTestStep: 3a19e1e5-4081-6501-685d-6130ed741ba1
    # Runtime control: If SH3 OR SH6 OR SD1 OR SD3 > Condition
    When if the source runtime condition "If SH3 OR SH6 OR SD1 OR SD3 > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB SubCategory"

    # Source step 0037: Pre-Qualification-Select Client and Property Eligibility Restrictions and Get Quote Number | Module: EQH||Pre-Qualification
    # Section: Process > 03 Pre-Qualification | Reusable flow: 03 EQ | Home - Pre-Qualification | Source XTestStep: 3a19e1e5-4081-d1cc-d0e6-f66aebec28c9
    # Runtime control: If SH3 OR SH6 OR SD1 OR SD3 > Then
    Then if the source runtime condition "If SH3 OR SH6 OR SD1 OR SD3 > Then" is satisfied, I wait until "Lbl_Client Eligibility Restrictions" is visible
    When I select "Btn_None Of The Above_Client ER"
    Then "Lbl_Side Menu_HOME_Quote Number" should equal "HOME ({XB[QuoteNumber]})"
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0038: Check LOB SubCategory | Module: TBox Set Buffer
    # Section: Process > 03 Pre-Qualification | Reusable flow: 03 EQ | Home - Pre-Qualification | Source XTestStep: 3a19e1e5-4081-e7b9-3345-bbb52bd59504
    # Runtime control: If SH4 > Condition
    When if the source runtime condition "If SH4 > Condition" is satisfied, I perform the source-defined buffer operation "Check LOB SubCategory"

    # Source step 0039: Pre-Qualification-Select Client and Property Eligibility Restrictions and Get Quote Number | Module: EQH||Pre-Qualification
    # Section: Process > 03 Pre-Qualification | Reusable flow: 03 EQ | Home - Pre-Qualification | Source XTestStep: 3a19e1e5-4081-7994-a77b-9ff883e7c13e
    # Runtime control: If SH4 > Then
    Then if the source runtime condition "If SH4 > Then" is satisfied, I wait until "Lbl_Client Eligibility Restrictions" is visible
    When I select "Btn_None Of The Above_Client ER"
    Then "Lbl_Side Menu_HOME_Quote Number" should equal "HOME ({XB[QuoteNumber]})"
    When I select "Btn_None Of The Above_Property Eligibility Restrictions_SH4"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0040: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process > 04 Client Suggestion, Add/Edit Insured & Review | Reusable flow: Home & Auto | 04 EQ | - Client Suggestion, Add/Edit Insured & Review | Source XTestStep: 3a19dd55-d407-a7bb-026a-0a7399cb976e
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    When I click "Btn_Next"

    # Source step 0041: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process > 04 Client Suggestion, Add/Edit Insured & Review | Reusable flow: Home & Auto | 04 EQ | - Client Suggestion, Add/Edit Insured & Review | Source XTestStep: 3a19dd55-d407-6e3b-c1d1-33ef990b05ea
    Then I wait until "Add/Edit Named Insured Header" is visible
    When I click "Btn_Male"
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0042: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process > 04 Client Suggestion, Add/Edit Insured & Review | Reusable flow: Home & Auto | 04 EQ | - Client Suggestion, Add/Edit Insured & Review | Source XTestStep: 3a19dd55-d407-c9fe-f6c7-da4cf9cdbc8e
    Then I wait until "Named Insureds Summary Header" is visible
    When I click "Btn_NEXT"

    # Source step 0043: EQH||Location Details | Module: EQH||Location
    # Section: Process > 05 Location | Reusable flow: 05 EQ | Home - Location | Source XTestStep: 3a19e1e5-4081-b720-35e0-b6c8a09fcd21
    Then I wait until "Location Header" exists
    When I click "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0044: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process > 05 Location | Reusable flow: 05 EQ | Home - Location | Source XTestStep: 3a19e1e5-4081-b4f0-4148-77e40361fb75
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0045: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process > 05 Location | Reusable flow: 05 EQ | Home - Location | Source XTestStep: 3a19e1e5-4081-d3ac-9335-d1b69ff6b1f3
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0046: Home in City Limits? | Module: EQH||Location
    # Section: Process > 05 Location | Reusable flow: 05 EQ | Home - Location | Source XTestStep: 3a19e1e5-4081-37e0-cb26-7bb70a31e6f8
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"

    # Source step 0047: Click on Next | Module: EQH||Location
    # Section: Process > 05 Location | Reusable flow: 05 EQ | Home - Location | Source XTestStep: 3a19e1e5-4081-6233-c54a-d375076dba1a
    When I click "Btn_NEXT"

    # Source step 0048: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-a2b2-8046-dd5cb3c71271
    When I enter or select "PGUP" in "Home Characteristics Header"
    Then I wait until "Txt_Year Built" is visible
    When I enter or select "\"^{a}\"" in "Txt_Year Built"
    When I enter or select "\"{DEL}\"" in "Txt_Year Built"
    When I enter or select "1992" in "Txt_Year Built"
    Then I wait until "Txt_Total Living Area" is visible
    When I enter or select "\"^{a}\"" in "Txt_Total Living Area"
    When I enter or select "\"{DEL}\"" in "Txt_Total Living Area"
    When I enter or select "1455" in "Txt_Total Living Area"
    Then I wait until "Lbl_Roof Type" is visible
    Then "Btn_Shingles, Architectural" should exist
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
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0050: RCT||Home Page | Module: RCT | Home Page
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-f025-fdad-c85d4c9fd1ad
    # Runtime control: While [max=10] > Condition
    Then if the source runtime condition "While [max=10] > Condition" is satisfied, "Btn_Edit_Building Information" should be not visible

    # Source step 0051: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: While [max=10] > Loop
    When if the source runtime condition "While [max=10] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0052: Add Construction Type Framing - Rough Lumber 100% | Module: RCT | Home Page
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-2f3e-a632-b651155f4002
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

    # Source step 0053: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0054: Click Finish | Module: RCT | Home Page
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-ac50-e3d4-7010e2b4ea96
    Then I wait until "Btn_Finish_Valuation Totals" is enabled
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0055: RCT||Home Page | Module: RCT | Home Page
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-c91e-8a62-1f2382ba48f2
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0056: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-070a-6b21-77a56f2dcef5
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0057: RCT||Complete page | Module: RCT | Complete page
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-9907-8c87-e8ef9aec8e29
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0058: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0059: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-1f0c-d259-0ffe898ad2aa
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0060: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process > 06 Home Characteristics > RCT Operation | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-49af-baba-291d32a3f13e
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0061: Verify if RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-c4eb-9173-949167b4629e
    # Runtime control: RCT Page Opened Pop up > Verify if RCT Page Opened Pop up
    Then if the source runtime condition "RCT Page Opened Pop up > Verify if RCT Page Opened Pop up" is satisfied, "Please click 'OK' after the RCT page has been updated to refresh this page" should be visible

    # Source step 0062: Click on Ok | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-b39a-d60e-8436c089c769
    # Runtime control: RCT Page Opened Pop up > Click on Ok
    When if the source runtime condition "RCT Page Opened Pop up > Click on Ok" is satisfied, I click "Btn_Ok"

    # Source step 0063: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0064: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-0770-3491-bfdd1e619140
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
    When I enter or select "282000" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I press "Tab" while focused on "Txt_Heating (Year)"
    When I press "Tab" while focused on "Txt_Cooling (Year)"
    When I press "Tab" while focused on "Txt_Plumbing (Year)"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0066: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-d0bd-c8e3-f635a40a760d
    When I enter or select "{SCROLL[5][500px][Center][HorizontalFirst][300ms]}" in "Txt_Market Value"
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    When I click "Btn_Central"
    Then I wait until "Btn_Floor Furnace" exists
    Then I wait until "Btn_More Options_Principal Heat Type" is visible
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible

    # Source step 0067: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0068: Home Characteristics-Heating Details Supplemental Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-8e45-5964-ccdd20c0653c
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0069: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0070: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-b481-88cb-d0036b6cbed2
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

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0072: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-dc00-4bbe-8dbae9c18efb
    Then I wait until "On Premise Exposures Header" is visible
    When I select "check_box_outline_blankNone of the Above - Special Exposures"
    Then I wait until "Btn_Chk box_Dogs on Premise" is enabled
    When I click "Btn_Chk box_Dogs on Premise"
    Then I wait until "Txt_animal_Name" is enabled
    When I enter or select "Lana" in "Txt_animal_Name"
    When I click "Gender"
    When I click "Female ( Spayed)"
    When I enter or select "\"^{a}\"" in "Txt_animal_YearBorn"
    When I enter or select "\"{DEL}\"" in "Txt_animal_YearBorn"
    When I enter or select "2022" in "Txt_animal_YearBorn"

    # Source step 0073: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-9997-ec8b-979455563a1a
    # Runtime control: If Breed is Required > Condition
    Then if the source runtime condition "If Breed is Required > Condition" is satisfied, "Primary Breed" should be visible

    # Source step 0074: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-ea32-a4aa-61096ec41204
    # Runtime control: If Breed is Required > Then
    When if the source runtime condition "If Breed is Required > Then" is satisfied, I click "Primary Breed"
    When I click "Australian Shepherd"

    # Source step 0075: Select Other None of The Above | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-4bfe-6feb-e8ba8e641072
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0076: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-5dbe-d787-9d868efd4dab
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0077: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-21ec-d465-de38b191dc0f
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0078: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-8a3e-d4ac-c95ed8febc8a
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0079: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-c2e2-c6f2-f96d1284926d
    When I click "Btn_NEXT"

    # Source step 0080: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process > 08 Claim History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-770e-8124-c5f4e6bcb422
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0081: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process > 08 Claim History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-a4fa-9842-d24891203a2f
    Then I wait until "Discounts/Adjustments Header" is visible
    When I click "Btn_Chk box_AUTO-HOME"
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0082: TBox Wait | Module: TBox Wait
    # Section: Process > 08 Claim History | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "9000" milliseconds

    # Source step 0083: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process > 09 Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-8733-9aa4-339e9d1c12aa
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

    # Source step 0084: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > 09 Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-7a4b-9d23-cd8e7de757c3
    When I click "Additional Coverages"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process > 09 Coverage | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0086: Additional Coverages-Add addtional coverage/endorsement of  'Increase For Theft Of Service Sets' | Module: EQH||Additional Coverages
    # Section: Process > 10 Additional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-2223-dacc-d66fbc2587be
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increase For Theft Of Service Sets" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > 10 Additional Coverage | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0088: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > 11 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-ecfd-d00c-744ec2e8a4b6
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0089: TBox Wait | Module: TBox Wait
    # Section: Process > 11 Pricing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0090: Mortgage/Additional Interest-Add/Edit Additional Interest, if needed | Module: EQH||Mortgage/Additional Interest
    # Section: Process > 12 Mortgage/Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-f466-c81a-e79069df8012
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0091: TBox Wait | Module: TBox Wait
    # Section: Process > 12 Mortgage/Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0092: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > 13 Billing | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
    Then I wait until "Hdr_Billing" is visible
    When I click "Btn_Create New Billing Account"
    When I enter or select "{Click}{Scroll[3]}" in "Btn_Primary Account Holder name"
    When I enter or select "{Click}{scroll[3]}" in "Btn_Direct Bill"
    When I click "Btn_1 Payment"
    When I enter or select "25" in "Txt_PaymentDueDate"
    When I click "Rd Btn_Full Balance"
    When I click "Btn_CHECK"
    When I enter or select "1234" in "Txt_Check Number"
    When I click "Btn_Billing_NEXT"

    # Source step 0097: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-0986-a0f7-ad948f01b0d9
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0098: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Submission | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "10000" milliseconds

    # Source step 0099: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-64f3-c56b-c01d88dd0293
    # Runtime control: Check if 2 UW Comments are needed > Condition
    Then if the source runtime condition "Check if 2 UW Comments are needed > Condition" is satisfied, "Txt_UW2_AgentComments" should exist

    # Source step 0100: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-3d28-90de-5532b3cb6405
    # Runtime control: Check if 2 UW Comments are needed > Then
    Then if the source runtime condition "Check if 2 UW Comments are needed > Then" is satisfied, I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    When I enter or select "Test" in "Txt_UW1_AgentComments"
    When I enter or select "Test2" in "Txt_UW2_AgentComments"
    When I click "Btn_Refer to UW_1"

    # Source step 0101: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3ced-0623-cf43-4fc65bc8b5eb
    # Runtime control: Check if 2 UW Comments are needed > Else
    When if the source runtime condition "Check if 2 UW Comments are needed > Else" is satisfied, I enter or select "Test" in "Txt_UW1_AgentComments"
    When I click "Btn_Refer to UW_1"

    # Source step 0102: OpenUrl | Module: OpenUrl
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0106: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0107: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0108: EU||Home | Module: EU||Home
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    Then I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0109: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    When I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0110: EU||Applicant | Module: EU||Applicant
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    When I click "Lnk_Pricing"

    # Source step 0111: EU||Pricing | Module: EU||Pricing
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    When I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0112: EU||Pricing | Module: EU||Pricing
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Level 9 exists > Condition
    Then if the source runtime condition "If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0113: EU||Pricing | Module: EU||Pricing
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Level 9 exists > Then
    When if the source runtime condition "If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0116: CloseBrowser | Module: CloseBrowser
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    When I close the active browser

    # Source step 0117: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-fb48-ea10-506864e423e8
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0118: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-096e-39b3-9f442f51fb00
    # Runtime control: If_eChecklist Sign on Page is Visible > Condition
    Then if the source runtime condition "If_eChecklist Sign on Page is Visible > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0119: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-a825-5318-f15abe032dc6
    # Runtime control: If_eChecklist Sign on Page is Visible > Then
    When if the source runtime condition "If_eChecklist Sign on Page is Visible > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0120: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-6bbd-754e-7f1ca253de21
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"

    # Source step 0121: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-200c-e96c-ab94f8cdcaf5
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0122: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0123: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-0580-0bf7-94c7c19502c2
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0124: eChecklist-Click the drag/drop link to upload the file in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-bdb6-a7a5-42be8a603e35
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0125: Wait | Module: TBox Wait
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-e23b-d4cf-827d28d6bf2d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0126: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-ea11-00b4-b67ca0b11070
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0127: Wait | Module: TBox Wait
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-76dc-c64f-58c9e596d239
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0128: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-0a28-9329-8207032f19a9
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0129: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process > 14 Submission | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-f96f-3856-c26b47ad9894
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0130: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process > 14 Submission | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a6ac-5210-1c0cb8a88b72
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0131: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Submission | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I wait "2000" milliseconds

    # Source step 0132: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > 14 Submission > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-e597-5619-47dc276f4f40
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0133: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > 14 Submission > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-dbde-fcb0-d3f5d123559a
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0134: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > 14 Submission > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a25d-2718-6c70c2b9457b
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0135: TBox Wait | Module: TBox Wait
    # Section: Process > 15 Transmit > 17 Home - Transmit Policy and Get Policy Number, Premium details | Reusable flow: 22 EQ | Home - Transmit Policy and Get Policy Number, Premium details > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0136: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process > 15 Transmit > 17 Home - Transmit Policy and Get Policy Number, Premium details | Reusable flow: 22 EQ | Home - Transmit Policy and Get Policy Number, Premium details | Source XTestStep: 3a19e1e5-4091-1d8c-95e5-a796c7e4202f
    Then I wait until "Hdr_Submission Header" exists
    Then I wait until "Btn_Transmit_1" is enabled
    When I click "Btn_Transmit_1"

    # Source step 0137: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process > 15 Transmit > 17 Home - Transmit Policy and Get Policy Number, Premium details | Reusable flow: 22 EQ | Home - Transmit Policy and Get Policy Number, Premium details | Source XTestStep: 3a19e1e5-4091-205a-fa08-d4d7e13ebb88
    Then I wait until "Policy Transmitted" is enabled
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0138: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process > 16 TDS Operations for Further Validations > 16 TDS Operations for Further Validations | Reusable flow: TDS | Home & Auto - Push Quote Data & Policy Information to TDS | Source XTestStep: 3a19dd55-d416-f362-2870-cad1df2136ae
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "MegaHome_PolicyData_Regression"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATETIME[][][MM/dd/yyyyhhmm]}"
    And I use TDM parameter "Data structure > FirstName" with captured runtime value "FirstName"
    And I use TDM parameter "Data structure > LastName" with captured runtime value "LastName"
    And I use TDM parameter "Data structure > DOB" with captured runtime value "DOB"
    And I use TDM parameter "Data structure > SSN" with captured runtime value "SSN"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"
    And I use TDM parameter "Data structure > State" with "PA"

    # Source step 0139: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > 16 TDS Operations for Further Validations > 16 TDS Operations for Further Validations | Reusable flow: TDS | Home & Auto - Push Quote Data & Policy Information to TDS | Source XTestStep: 3a19dd55-d416-7ec3-3085-6c6774b8c897
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATETIME[][][MM/dd/yyyyhhmm]}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0140: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Home" as runtime value "LOB"
    When I retain hard-coded value "PA" as runtime value "State"

    # Source step 0150: TestData - Find & provide item from TDM | Module: Old_TestData - Find & provide item
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-1615-20d6-0f44272a1688
    When I retrieve test data through TDM operation "TestData - Find & provide item from TDM"
    And I use TDM parameter "Existing TDS type" with "PremiumValidation_Reference"
    And I use TDM parameter "Data search filter > TCName" with captured runtime value "TCName"
    And I use TDM parameter "Data search filter > State" with captured runtime value "State"
    And I use TDM parameter "Data search filter > LOB" with captured runtime value "LOB"

    # Source step 0151: Get Validated Premium from TDM | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-15e0-22f5-124c3e13f033
    When I retrieve and retain the RUNTIME-DERIVED TDM value "PremiumValidation_Reference.ValidatedPremium" as runtime value "Expected_ValidatedPremium"

    # Source step 0152:  Compare Actual Premium vs Expected Premium | Module: TBox Set Buffer
    # Section: Postcondition > 02 Premium Validation | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3e9-2c68-4316-e800a7c0cf60
    When I perform the source-defined buffer operation "Compare Actual Premium vs Expected Premium"

    # Source step 0153: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0154: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0029 field "Btn_SD1-RENTAL OWNERS" in "Proposal Start-With Effective Date prior to 90 days from current date" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 2. Source step 0029 field "Hdr2" in "Proposal Start-With Effective Date prior to 90 days from current date" was disabled. Reason:  
#    - Preserved source value: "X"
# 3. Source step 0035 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 4. Source step 0035 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 5. Source step 0035 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0064 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 7. Source step 0064 field "Lbl_Principal Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 8. Source step 0064 field "Btn_None" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 9. Source step 0064 field "Btn_Central" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 10. Source step 0064 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0064 field "Btn_None_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0064 field "Btn_Central_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 13. Source step 0064 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0064 field "Lbl_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0064 field "Btn_None_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 16. Source step 0064 field "Btn_UL3" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0064 field "Btn_NEXT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 18. Source step 0068 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0068 field "Btn_Frame" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0068 field "Btn_Siding" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0068 field "Btn_Veneer" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 22. Source step 0068 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 23. Source step 0068 field "Btn_Owner" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 24. Source step 0068 field "Btn_Tenant" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 25. Source step 0068 field "Btn_Under Construction" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0068 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 27. Source step 0068 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 28. Source step 0068 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 29. Source step 0068 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 30. Source step 0068 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 31. Source step 0068 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 32. Source step 0068 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 33. Source step 0068 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 34. Source step 0068 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 35. Source step 0068 field "Lbl_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 36. Source step 0068 field "Btn_None" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 37. Source step 0068 field "Btn_Central" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 38. Source step 0068 field "Btn_Floor Furnace" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 39. Source step 0068 field "Btn_More Options_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 40. Source step 0068 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 41. Source step 0068 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 42. Source step 0068 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 43. Source step 0068 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0068 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 45. Source step 0068 field "Btn_UL3" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 46. Source step 0068 field "Btn_NEXT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 47. Source step 0070 field "Lbl_Construction Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0070 field "Btn_Frame" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 49. Source step 0070 field "Btn_Siding" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 50. Source step 0070 field "Btn_Veneer" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0070 field "Lbl_Building Occupancy" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0070 field "Btn_Owner" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 53. Source step 0070 field "Btn_Tenant" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 54. Source step 0070 field "Btn_Under Construction" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0070 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 56. Source step 0070 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 57. Source step 0070 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "\"DEL\""
# 58. Source step 0070 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "350999"
# 59. Source step 0070 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 60. Source step 0070 field "Txt_Electric (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 61. Source step 0070 field "Txt_Heating (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 62. Source step 0070 field "Txt_Cooling (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 63. Source step 0070 field "Txt_Plumbing (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 64. Source step 0070 field "Lbl_Principal Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0070 field "Btn_None" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0070 field "Btn_Central" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 67. Source step 0070 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0070 field "Btn_None_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 69. Source step 0070 field "Btn_Central_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 70. Source step 0070 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 71. Source step 0070 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 72. Source step 0083 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 73. Source step 0083 field "All Other Peril Deductible_2%" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: a blank value
# 74. Source step 0093 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 75. Source step 0094 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 76. Source step 0095 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 77. Source step 0096 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 78. Source step 0103 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 79. Source step 0104 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 80. Source step 0105 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 81. Source step 0107 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 82. Source step 0107 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 83. Source step 0111 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 84. Source step 0111 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 85. Source step 0111 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 86. Source step 0111 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 87. Source step 0112 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 88. Source step 0112 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 89. Source step 0112 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 90. Source step 0112 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 91. Source step 0113 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 92. Source step 0113 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 93. Source step 0113 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 94. Source step 0113 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 95. Source step 0114 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 96. Source step 0115 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 97. Source step 0120 field "Drag and Drop files here to upload (or click here to open a file explorer)" in "eChecklist-Click the documents/links in the checklist" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 98. Source step 0141 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 99. Source step 0142 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 100. Source step 0143 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 101. Source step 0144 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 102. Source step 0145 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 103. Source step 0146 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 104. Source step 0147 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 105. Source step 0148 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 106. Source step 0149 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
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
