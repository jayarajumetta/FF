# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 150_Home_Mid-Term_Evaluations_-_Add_Discounts_-_PA_Home_Mid-Term_Evaluations_-_Add_Discount.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @manual_conversion @Edge @manual @archive @automated
Feature: Execute Home Mid-Term Evaluations - Add Discounts - PA for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Mid-Term Evaluations - Add Discounts - PA workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Mid-Term Evaluations - Add Discounts - PA using representative iteration Home Mid-Term Evaluations - Add Discounts - PA
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
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d1b-4ef3-b0c3-a2aea87ecf1d
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
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-cd4c-8950-7d62d7cbd002
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-ebb8-95a5-0f01d67a59db
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-f28f-c8cd-eae3943a0aa2
    # Runtime control: Proposal Start-Provide SSN details,Client already exists > If confirm button is visible
    Then if the source runtime condition "Proposal Start-Provide SSN details,Client already exists > If confirm button is visible" is satisfied, "Btn_Confirm client's SSN_CONFIRM" should be visible

    # Source step 0033: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-f6fb-fbe9-19a5bcca7192
    # Runtime control: Proposal Start-Provide SSN details,Client already exists > Click on confirm button
    When if the source runtime condition "Proposal Start-Provide SSN details,Client already exists > Click on confirm button" is satisfied, I click "Btn_Confirm client's SSN_CONFIRM"
    When I click "Btn_Client Already Exists_USE EXISTING ACCOUNT"

    # Source step 0034: Proposal Start-Provide SSN details,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process > 02 Proposal Start | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-8775-c69c-133e68919060
    # Runtime control: Proposal Start-Provide SSN details,Client already exists > Provide SSN Details
    When if the source runtime condition "Proposal Start-Provide SSN details,Client already exists > Provide SSN Details" is satisfied, I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0035: TBox Wait | Module: TBox Wait
    # Section: Process > 02 Proposal Start | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

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
    # Section: Process > 04 Client Suggestion, Add/Edit Insured & Review | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-104f-9c47-4093a5f797bd
    When I click "(Existing Client)Bass, BlaineDOB: 10/12/1958"
    When I click "Btn_Next"

    # Source step 0041: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process > 04 Client Suggestion, Add/Edit Insured & Review | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2a-c1a1-42ef-ed360624fe65
    Then I wait until "Add/Edit Named Insured Header" is visible
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0042: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process > 04 Client Suggestion, Add/Edit Insured & Review | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-021a-c2ad-d7a5c94f91c5
    Then I wait until "Named Insureds Summary Header" is visible
    When I click "Btn_NEXT"

    # Source step 0043: EQH||Location Details | Module: EQH||Location
    # Section: Process > 05 Location & PPC > 05 Location | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-36b5-e92b-2bfce7e10826
    Then I wait until "Location Header" exists
    When I click "Btn_More than 5 years"
    When I click "Drp List_Miles to Fire Station-need to check"
    When I click "0-3.0"
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0044: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process > 05 Location & PPC > 05 Location | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-4c8b-29f8-e2b0bb9935fa
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0045: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process > 05 Location & PPC > 05 Location | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-f783-6cca-efdc2363c7e3
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0046: Home in City Limits & Select PPC | Module: EQH||Location
    # Section: Process > 05 Location & PPC > 05 Location | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-df4b-cf9f-07df2fb5709e
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "BIG RUN"

    # Source step 0047: Click on Next | Module: EQH||Location
    # Section: Process > 05 Location & PPC > 05 Location | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-6dac-f329-6eed13e30e7b
    When I click "Btn_NEXT"

    # Source step 0048: Home Characteristics-Cost Estimator info till Get Valuation | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2c-185a-7007-a8e3117d31da
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
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-8ec1-74fa-b741409f0fc8
    Then I wait until "Btn_Edit_Building Information" is visible
    When I click "Btn_Finish_Valuation Totals"

    # Source step 0051: RCT||Pop up-Save,Discard,Close | Module: RCT | Pop up-Save,Discard,Close
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-1a95-441b-281c6e4fdc87
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"

    # Source step 0052: RCT||Complete page | Module: RCT | Complete page
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-5df8-9914-9cb1e9f62267
    Then I wait until "DIV_Complete!" is visible
    Then "DIV_You may now close this window. This valuation is being processed." should be visible

    # Source step 0053: Close the RCT Express page/tab in browser | Module: TBox Send Keys
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-439f-b5a6-cb437118cccc
    When I enter or select "test.anpac.info/*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0054: EQH||Home Characteristics-RCT Page Opened Pop up | Module: EQH||Home Characteristics-RCT Page Opened Pop up
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-cbe1-195c-c8898718f284
    Then I wait until "Please click 'OK' after the RCT page has been updated to refresh this page" is visible
    When I click "Btn_Ok"

    # Source step 0055: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0056: Home Characteristics-Property Information | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-03a9-2e8b-470954b8e78a
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
    When I enter or select "274400" in "Txt_Market Value"
    When I press "Tab" while focused on "Txt_Electric (Year)"
    When I press "Tab" while focused on "Txt_Heating (Year)"
    When I press "Tab" while focused on "Txt_Cooling (Year)"
    When I press "Tab" while focused on "Txt_Plumbing (Year)"

    # Source step 0057: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0062: Home Characteristics-Heating Details Principal Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-06e6-7e77-b8edadd9571b
    When I enter or select "{SCROLL[5][500px][Center][HorizontalFirst][300ms]}" in "Txt_Market Value"
    Then "Lbl_Principal Heat Type" should exist
    Then "Btn_None" should exist
    When I click "Btn_Central"
    Then I wait until "Btn_Floor Furnace" exists
    Then I wait until "Btn_More Options_Principal Heat Type" is visible
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible

    # Source step 0063: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0064: Home Characteristics-Heating Details Supplemental Heat Type | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-3504-e485-442d241e951b
    Then "Lbl_Supplemental Heat Type" should exist
    Then I wait until "Btn_None_SHT" is visible
    When I click "Btn_Floor Furnace_SHT"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0066: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process > 06 Home Characteristics | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-d5a2-84d7-e12437fa207a
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

    # Source step 0067: TBox Wait | Module: TBox Wait
    # Section: Process > 06 Home Characteristics | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0068: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
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

    # Source step 0069: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-9997-ec8b-979455563a1a
    # Runtime control: If Breed is Required > Condition
    Then if the source runtime condition "If Breed is Required > Condition" is satisfied, "Primary Breed" should be visible

    # Source step 0070: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-ea32-a4aa-61096ec41204
    # Runtime control: If Breed is Required > Then
    When if the source runtime condition "If Breed is Required > Then" is satisfied, I click "Primary Breed"
    When I click "Australian Shepherd"

    # Source step 0071: Select Other None of The Above | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-4bfe-6feb-e8ba8e641072
    Then I wait until "Btn_Chk box_None of the Above - Business Details" is enabled
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"

    # Source step 0072: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-5dbe-d787-9d868efd4dab
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition
    Then if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Condition" is satisfied, "Txt_NumberOfRentalPropertiesOwnedByApplicant" should exist

    # Source step 0073: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-21ec-d465-de38b191dc0f
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I click "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0074: NumberOfRentalPropertiesOwnedByApplicant | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-8a3e-d4ac-c95ed8febc8a
    # Runtime control: If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then
    When if the source runtime condition "If NumberOfRentalPropertiesOwnedByApplicant Is Requried > Then" is satisfied, I enter or select "2" in "Txt_NumberOfRentalPropertiesOwnedByApplicant"

    # Source step 0075: Click on Next | Module: EQH||On Premise Exposures
    # Section: Process > 07 On Premise Exposure | Reusable flow: 20 EQ | Home - On Premise Exposure with Dog | Source XTestStep: 3a19e1e5-4081-c2e2-c6f2-f96d1284926d
    When I click "Btn_NEXT"

    # Source step 0076: Claims History-Add or Update existing claims | Module: EQH||Claims History
    # Section: Process > 08 Claim History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-f205-89e3-0c34f8aebd5b
    Then I wait until "Claims History Header" is visible
    Then I wait until "Btn_ADD CLAIM" exists
    When I click "Btn_NEXT"

    # Source step 0077: Discounts/Adjustments-Choose any dicounts applied | Module: EQH||Discounts/Adjustments
    # Section: Process > 08 Claim History | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-315d-a6da-446e2dd6bbb3
    Then I wait until "Discounts/Adjustments Header" is visible
    When I click "Btn_Chk box_AUTO-HOME"
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    Then "Btn_Chk box_Local Burglar Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0078: TBox Wait | Module: TBox Wait
    # Section: Process > 08 Claim History | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "9000" milliseconds

    # Source step 0079: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process > 09 Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-f45f-0484-d053cf60ba76
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

    # Source step 0080: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > 09 Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-e756-71c7-4b2af696359e
    When I click "Additional Coverages"

    # Source step 0081: TBox Wait | Module: TBox Wait
    # Section: Process > 09 Coverage | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0082: Additional Coverages-Add addtional coverage/endorsement of  'Increase For Theft Of Service Sets' | Module: EQH||Additional Coverages
    # Section: Process > 10 Additional Coverage | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-f13f-a2bc-7cbfc6fd9b48
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increase For Theft Of Service Sets" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0083: TBox Wait | Module: TBox Wait
    # Section: Process > 10 Additional Coverage | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "20000" milliseconds

    # Source step 0084: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process > 11 Pricing Details | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-760b-3f84-413984eb7402
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process > 11 Pricing Details | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0086: Mortgage/Additional Interest-Add/Edit Additional Interest, if needed | Module: EQH||Mortgage/Additional Interest
    # Section: Process > 12 Mortgage/Additional Interest | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-ca5f-35fb-bef4b447ba94
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0087: TBox Wait | Module: TBox Wait
    # Section: Process > 12 Mortgage/Additional Interest | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0088: Billing-Create and Update Billing details | Module: EQ||Billing
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

    # Source step 0093: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-4b42-f705-27c5d674c9c6
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, I wait until "Hdr_Submission Header" is visible

    # Source step 0094: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Submission | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "10000" milliseconds

    # Source step 0095: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-f83d-9d8e-1e2dad66a9d5
    # Runtime control: Check if 2 UW Comments are needed > Condition
    Then if the source runtime condition "Check if 2 UW Comments are needed > Condition" is satisfied, "Txt_UW2_AgentComments" should exist

    # Source step 0096: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-3506-f48a-8f1f76bbafca
    # Runtime control: Check if 2 UW Comments are needed > Then
    Then if the source runtime condition "Check if 2 UW Comments are needed > Then" is satisfied, I wait until "Hdr_Submission Header" is visible
    Then "Hdr_Submission Header" should exist
    When I enter or select "Test" in "Txt_UW1_AgentComments"
    When I enter or select "Test2" in "Txt_UW2_AgentComments"
    When I click "Btn_Refer to UW_1"

    # Source step 0097: Submission-UW referraland add agent comments | Module: EQ||Submission
    # Section: Process > 14 Submission | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3d2d-c238-5486-de164593989a
    # Runtime control: Check if 2 UW Comments are needed > Else
    When if the source runtime condition "Check if 2 UW Comments are needed > Else" is satisfied, I enter or select "Test" in "Txt_UW1_AgentComments"
    When I click "Btn_Refer to UW_1"

    # Source step 0098: OpenUrl | Module: OpenUrl
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "URL" (not supplied by this reusable-block invocation)

    # Source step 0102: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0103: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0104: EU||Home | Module: EU||Home
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    Then I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0105: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    When I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0106: EU||Applicant | Module: EU||Applicant
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    When I click "Lnk_Pricing"

    # Source step 0107: EU||Pricing | Module: EU||Pricing
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    When I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0108: EU||Pricing | Module: EU||Pricing
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Level 9 exists > Condition
    Then if the source runtime condition "If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0109: EU||Pricing | Module: EU||Pricing
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Level 9 exists > Then
    When if the source runtime condition "If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0112: CloseBrowser | Module: CloseBrowser
    # Section: Process > 14 Submission > Approve in Express UI | Reusable flow: Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    When I close the active browser

    # Source step 0113: Submission- Launch to Checklist | Module: EQ||Submission
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-fb48-ea10-506864e423e8
    Then "Btn_Launch To Checklist_1" should be enabled
    When I click "Btn_Launch To Checklist_1"

    # Source step 0114: Verify eChecklist Sign on page showed up | Module: EQH||eChecklist-Sign On
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-096e-39b3-9f442f51fb00
    # Runtime control: If_eChecklist Sign on Page is Visible > Condition
    Then if the source runtime condition "If_eChecklist Sign on Page is Visible > Condition" is satisfied, "Lbl_Sign On" should exist
    Then "Btn_Sign On" should exist

    # Source step 0115: Provide the Sign on credentials | Module: EQH||eChecklist-Sign On
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-a825-5318-f15abe032dc6
    # Runtime control: If_eChecklist Sign on Page is Visible > Then
    When if the source runtime condition "If_eChecklist Sign on Page is Visible > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0116: eChecklist-Click the documents/links in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-6bbd-754e-7f1ca253de21
    Then I wait until "H4" is visible
    When I click "Link_Home/ROP Electronic Application"

    # Source step 0117: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-200c-e96c-ab94f8cdcaf5
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0118: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: Do [max=30] > Loop
    When if the source runtime condition "Do [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0119: eChecklist-Verify if 'Application' links in the checklist are completed | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-0580-0bf7-94c7c19502c2
    # Runtime control: Upload the remaining Checklist documents [max=30] > Condition
    Then if the source runtime condition "Upload the remaining Checklist documents [max=30] > Condition" is satisfied, "Drag and Drop files here to upload (or click here to open a file explorer)" should be visible

    # Source step 0120: eChecklist-Click the drag/drop link to upload the file in the checklist  | Module: EQH||eChecklist-Home Page
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-bdb6-a7a5-42be8a603e35
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I click "Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0121: Wait | Module: TBox Wait
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d407-e23b-d4cf-827d28d6bf2d
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0122: eChecklist-TBox Save As-Upload sample pdf document from shared path | Module: TBox Save As
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-ea11-00b4-b67ca0b11070
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I enter or select "Open*" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0123: Wait | Module: TBox Wait
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-76dc-c64f-58c9e596d239
    # Runtime control: Upload the remaining Checklist documents [max=30] > Loop
    When if the source runtime condition "Upload the remaining Checklist documents [max=30] > Loop" is satisfied, I wait "3000" milliseconds

    # Source step 0124: Close the eChecklist page/tab in browser | Module: TBox Send Keys
    # Section: Process > 14 Submission > Upload Documents | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-0a28-9329-8207032f19a9
    When I enter or select "American*" in "Caption"
    When I enter or select "^(w)" in "Keys"

    # Source step 0125: Verify eChecklist opened Pop up is shown on submission page | Module: EQH||eChecklist-Pop up
    # Section: Process > 14 Submission | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-f96f-3856-c26b47ad9894
    # Runtime control: If_eChecklist opened pop up is shown > Condition
    Then if the source runtime condition "If_eChecklist opened pop up is shown > Condition" is satisfied, "Header_Checklist Opened" should exist

    # Source step 0126: Click OK to close the eChecklist opened Pop up | Module: EQH||eChecklist-Pop up
    # Section: Process > 14 Submission | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a6ac-5210-1c0cb8a88b72
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I click "Btn_Ok"

    # Source step 0127: TBox Wait | Module: TBox Wait
    # Section: Process > 14 Submission | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    # Runtime control: If_eChecklist opened pop up is shown > Then
    When if the source runtime condition "If_eChecklist opened pop up is shown > Then" is satisfied, I wait "2000" milliseconds

    # Source step 0128: EQH||Quote Actions-Save and Exit the current Quote | Module: EQH||Side Menu and Quote Actions
    # Section: Process > 14 Submission > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-e597-5619-47dc276f4f40
    When I click "Btn_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0129: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process > 14 Submission > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-dbde-fcb0-d3f5d123559a
    Then I wait until "Btn_New Quote" is enabled
    Then I wait until "Txt_QuoteSearch_Input" is enabled
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0130: EQH||Side Menu and Quote Actions-Navigate to Submission page | Module: EQH||Side Menu and Quote Actions
    # Section: Process > 14 Submission > Save and Exit Current Quote | Reusable flow: Home & Auto | 07 EQ | CheckList - Save and Exit Current Quote, Updaload FIles | Source XTestStep: 3a19dd55-d416-a25d-2718-6c70c2b9457b
    Then I wait until "Submission" is enabled
    When I click "Submission"

    # Source step 0131: TBox Wait | Module: TBox Wait
    # Section: Process > 15 Transmit > 17 Home - Transmit Policy and Get Policy Number, Premium details | Reusable flow: 22 EQ | Home - Transmit Policy and Get Policy Number, Premium details > zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0132: Submission-Transmit and issue Policy | Module: EQ||Submission
    # Section: Process > 15 Transmit > 17 Home - Transmit Policy and Get Policy Number, Premium details | Reusable flow: 22 EQ | Home - Transmit Policy and Get Policy Number, Premium details | Source XTestStep: 3a19e1e5-4091-1d8c-95e5-a796c7e4202f
    Then I wait until "Hdr_Submission Header" exists
    Then I wait until "Btn_Transmit_1" is enabled
    When I click "Btn_Transmit_1"

    # Source step 0133: Transmit Confirmation-Get Policy Number, Premium details | Module: EQH||Transmit Confirmation
    # Section: Process > 15 Transmit > 17 Home - Transmit Policy and Get Policy Number, Premium details | Reusable flow: 22 EQ | Home - Transmit Policy and Get Policy Number, Premium details | Source XTestStep: 3a19e1e5-4091-205a-fa08-d4d7e13ebb88
    Then I wait until "Policy Transmitted" is enabled
    When I capture "Text" from "Policy Transmitted > $1 > Stage" as runtime value "Stage"
    When I capture "Text" from "Policy Transmitted > $1 > Line" as runtime value "Line"
    When I capture "Text" from "Policy Transmitted > $1 > Name" as runtime value "Name"
    When I capture "Text" from "Policy Transmitted > $1 > Policy Number" as runtime value "Policy Number"
    When I capture "Text" from "Policy Transmitted > $1 > Premium" as runtime value "Premium"
    When I capture "Text" from "Policy Transmitted > $1 > Transmitted" as runtime value "Transmitted"
    When I capture "Text" from "Policy Transmitted > $1 > Effective" as runtime value "Effective Date"

    # Source step 0134: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
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

    # Source step 0135: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process > 16 TDS Operations for Further Validations > 16 TDS Operations for Further Validations | Reusable flow: TDS | Home & Auto - Push Quote Data & Policy Information to TDS | Source XTestStep: 3a19dd55-d416-7ec3-3085-6c6774b8c897
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATETIME[][][MM/dd/yyyyhhmm]}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0136: Set LOB & State | Module: TBox Set Buffer
    # Section: Postcondition > Set LOB & State | Reusable flow: Home & Auto |13 EQ |  Premium Validation(Actual vs Expected) in Pre-Policy | Source XTestStep: 3a19dd55-d3da-f721-3841-73fc357c3af1
    When I retain hard-coded value "Home" as runtime value "LOB"
    When I retain hard-coded value "PA" as runtime value "State"

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

    # Source step 0149: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-c841-82de-e91e55997524
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0150: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: Home & Auto |23 EQ | Logout from EQ and Close Browser | Source XTestStep: 3a19dd55-d407-6359-30e8-55feca12a438
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0024 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0029 field "Btn_SD1-RENTAL OWNERS" in "Proposal Start-With Effective Date prior to 90 days from current date" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 3. Source step 0029 field "Hdr2" in "Proposal Start-With Effective Date prior to 90 days from current date" was disabled. Reason:  
#    - Preserved source value: "X"
# 4. Source step 0034 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 5. Source step 0034 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 6. Source step 0034 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN details,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 7. Source step 0040 field "Lbl_Choose Insureds From Existing Account" in "Named Insureds Summary-Client Suggestions" was disabled. Reason:  
#    - Preserved source value: "True"
# 8. Source step 0051 field "Btn_Close" in "RCT||Pop up-Save,Discard,Close" was disabled. Reason:  
#    - Preserved source value: a blank value
# 9. Source step 0056 field "Home Characteristics Header" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0056 field "Lbl_Principal Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0056 field "Btn_None" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0056 field "Btn_Central" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 13. Source step 0056 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0056 field "Btn_None_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 15. Source step 0056 field "Btn_Central_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 16. Source step 0056 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 17. Source step 0056 field "Lbl_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 18. Source step 0056 field "Btn_None_Roof UL Rating" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 19. Source step 0056 field "Btn_UL3" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 20. Source step 0056 field "Btn_NEXT" in "Home Characteristics-Property Information" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 21. Source step 0058 "EQH||Home Characteristics_SH3_Electrical Details" in module "EQH||Home Characteristics_SH3_Electrical Details" was disabled. Reason: 18.05.24 23:13:17 [ct2628]
#    - WAIT "Lbl_Electrical Box Type" with "True"
#    - INPUT "Breakers" with "{Click}"
# 22. Source step 0059 "EQH||Home Characteristics_SH3_Electrical Details" in module "EQH||Home Characteristics_SH3_Electrical Details" was disabled. Reason: 18.05.24 23:13:17 [ct2628]
#    - VERIFY "Breakers" with "mat-focus-indicator mat-raised-button mat-button-base btn-chip ng-star-inserted cdk-focused cdk-mouse-focused mat-button-toggle-checked"
# 23. Source step 0060 "EQH||Home Characteristics_SH3_Electrical Details" in module "EQH||Home Characteristics_SH3_Electrical Details" was disabled. Reason: 18.05.24 23:13:17 [ct2628]
#    - INPUT "Breakers" with "{Click}"
# 24. Source step 0061 "EQH||Home Characteristics_SH3_Electrical Details" in module "EQH||Home Characteristics_SH3_Electrical Details" was disabled. Reason: 18.05.24 23:13:17 [ct2628]
#    - INPUT "100 amp or more" with "{Click}"
#    - INPUT "GenericGUI-Type of Wiring" with "{Click}"
#    - INPUT "BX" with "X"
#    - INPUT "No" with "{Click}"
#    - INPUT "Other" with "{Click}"
# 25. Source step 0064 field "Lbl_Construction Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 26. Source step 0064 field "Btn_Frame" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 27. Source step 0064 field "Btn_Siding" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 28. Source step 0064 field "Btn_Veneer" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 29. Source step 0064 field "Lbl_Building Occupancy" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 30. Source step 0064 field "Btn_Owner" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 31. Source step 0064 field "Btn_Tenant" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0064 field "Btn_Under Construction" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 33. Source step 0064 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 34. Source step 0064 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 35. Source step 0064 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 36. Source step 0064 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "350999"
# 37. Source step 0064 field "Txt_Market Value" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 38. Source step 0064 field "Txt_Electric (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 39. Source step 0064 field "Txt_Heating (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 40. Source step 0064 field "Txt_Cooling (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 41. Source step 0064 field "Txt_Plumbing (Year)" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: ""
# 42. Source step 0064 field "Lbl_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0064 field "Btn_None" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0064 field "Btn_Central" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 45. Source step 0064 field "Btn_Floor Furnace" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 46. Source step 0064 field "Btn_More Options_Principal Heat Type" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0064 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Longclick}"
# 48. Source step 0064 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 49. Source step 0064 field "Btn_Central_SHT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "X"
# 50. Source step 0064 field "Lbl_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0064 field "Btn_None_Roof UL Rating" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 52. Source step 0064 field "Btn_UL3" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0064 field "Btn_NEXT" in "Home Characteristics-Heating Details Supplemental Heat Type" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 54. Source step 0066 field "Lbl_Construction Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0066 field "Btn_Frame" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0066 field "Btn_Siding" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0066 field "Btn_Veneer" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 58. Source step 0066 field "Lbl_Building Occupancy" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0066 field "Btn_Owner" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0066 field "Btn_Tenant" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0066 field "Btn_Under Construction" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 62. Source step 0066 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0066 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Doubleclick}"
# 64. Source step 0066 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "\"DEL\""
# 65. Source step 0066 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "350999"
# 66. Source step 0066 field "Txt_Market Value" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 67. Source step 0066 field "Txt_Electric (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 68. Source step 0066 field "Txt_Heating (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 69. Source step 0066 field "Txt_Cooling (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 70. Source step 0066 field "Txt_Plumbing (Year)" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: ""
# 71. Source step 0066 field "Lbl_Principal Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 72. Source step 0066 field "Btn_None" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 73. Source step 0066 field "Btn_Central" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 74. Source step 0066 field "Lbl_Supplemental Heat Type" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0066 field "Btn_None_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 76. Source step 0066 field "Btn_Central_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 77. Source step 0066 field "Btn_Floor Furnace_SHT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 78. Source step 0066 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 79. Source step 0079 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 80. Source step 0079 field "All Other Peril Deductible_2%" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $2000" was disabled. Reason:  
#    - Preserved source value: a blank value
# 81. Source step 0089 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 82. Source step 0090 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 83. Source step 0091 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 84. Source step 0092 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 85. Source step 0099 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 86. Source step 0100 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 87. Source step 0101 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 88. Source step 0103 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 89. Source step 0103 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 90. Source step 0107 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 91. Source step 0107 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 92. Source step 0107 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 93. Source step 0107 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 94. Source step 0108 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 95. Source step 0108 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 96. Source step 0108 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 97. Source step 0108 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 98. Source step 0109 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 99. Source step 0109 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 100. Source step 0109 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 101. Source step 0109 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 102. Source step 0110 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 103. Source step 0111 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 104. Source step 0116 field "Drag and Drop files here to upload (or click here to open a file explorer)" in "eChecklist-Click the documents/links in the checklist" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 105. Source step 0137 "Set AliasName" in module "TBox Set Buffer" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "AliasName" with the RUNTIME-DERIVED buffer expression "{B[TCName]}_{TIME[][][HHmmss]}"
# 106. Source step 0138 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 107. Source step 0139 "TestData - Find & provide item with Alias" in module "TestData - Find & provide item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data search filter > TCName" with captured runtime value "TCName"
# 108. Source step 0140 "Temp Prmium Update into TDS Premium Validation Table if Empty" in module "TestData - Update item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing alias name (item)" with captured runtime value "AliasName"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > State" with captured runtime value "State"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
# 109. Source step 0141 "Unlock TDS Item" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockItem"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Alias name (item)" with captured runtime value "AliasName"
# 110. Source step 0142 "Wait" in module "TBox Wait" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Duration" with "5000"
# 111. Source step 0143 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Test data task" with "UnlockType"
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
# 112. Source step 0144 "TestData - Create New Entry" in module "TestData - Create & provide new item" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
#    - INPUT "Existing or new TDS type" with "PremiumValidation_Reference"
#    - INPUT "Data structure > Sno" with a blank value
#    - INPUT "Data structure > TCName" with captured runtime value "TCName"
#    - INPUT "Data structure > PolicyNumber" with captured runtime value "Policy Number"
#    - INPUT "Data structure > ValidatedPremium" with captured runtime value "Premium"
#    - INPUT "Data structure > LOB" with captured runtime value "LOB"
#    - INPUT "Data structure > State" with captured runtime value "State"
# 113. Source step 0145 "Unlock TDS Table" in module "TestData - Expert module" was disabled. Reason: 28.06.24 19:43:54 [ct2721]
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
