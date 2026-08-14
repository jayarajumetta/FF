# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 175_Home_Regression_Testing_SH4_Scenario_2_-_PA_-_Unbound_Home_Regression_Testing_SH4_Scenario_2_-.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @regression @Edge @manual @archive @automated
Feature: Execute Home Regression Testing SH4 Scenario #2 - PA - Unbound for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Home Regression Testing SH4 Scenario #2 - PA - Unbound workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Home Regression Testing SH4 Scenario #2 - PA - Unbound using representative iteration Home Regression Testing SH4 Scenario #2 - PA - Unbound
    # Source step 0025: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-6650-453c-16a822c3e2eb
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YDF999" in "Txt_Username"
    When I enter or select "${ENV:PL_DC_PASSWORD}" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0026: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-460d-f791-6bf40bfdba0e
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0027: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-c951-1e6e-7e5617b365ad
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-cccb-4c89-78d79bd5fe56
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "8000000000" in "<unnamed value>"
    When I enter or select "mubses@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "4199 Morgantown Road, Smithfield, PA 15478" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    Then I wait until "<unnamed value>" is visible
    When I enter or select "4005" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0029: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-a643-ae67-22ff1f8cdf12
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-1bec-86a5-9671bd6f99c2
    # Runtime control: If_Invalid Address shows up > Condition
    Then if the source runtime condition "If_Invalid Address shows up > Condition" is satisfied, "Btn_PROCEED" should be visible

    # Source step 0031: Proceed with details | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-ccbc-f071-515bcf79c489
    # Runtime control: If_Invalid Address shows up > Then
    When if the source runtime condition "If_Invalid Address shows up > Then" is satisfied, I click "Btn_PROCEED"

    # Source step 0032: Proposal Start-Provide SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-97e4-3d55-c6bf169cc953
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0033: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0034: Pre-Qualification-Select Client and Property Eligibility Restrictions | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-024b-28fa-2a627229d233
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-37c7-1bda-b4524373efb0
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0036: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-2767-7a4b-ee79a1356970
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0037: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-bfb2-1c11-d1067f9f8887
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    When I enter or select "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Phone Type"
    Then "Lbl_Email Type" should exist
    Then "Lbl_Gender" should exist
    Then "Btn_Male" should exist
    When I click "Btn_Female"
    Then I wait until "Lbl_Marital Status" is visible
    Then I wait until "Btn_Single" is visible
    Then "Lbl_Relation To Account Owner" should be visible
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0038: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-b9e7-71f8-878a31a6e897
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0039: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0040: EQH||Location-till miles to fire station | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-4388-d012-14a12c119815
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
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-095c-ad10-d72626c7654d
    When I click "Drp List_Feet to Hydrant-need to check"
    When I click "< 601"

    # Source step 0043: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0044: Verify Order Wildfire Risk Score is enabled | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-1927-fd5a-7a745691259a
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Condition
    Then if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Condition" is satisfied, "+ ORDER WILDFIRE RISK SCORE" should be enabled

    # Source step 0045: Get the the Wildfore Risk Score for property | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-9dae-4f11-76201271cc64
    # Runtime control: If_Order Wildfire Risk Score is enabled or not > Then
    When if the source runtime condition "If_Order Wildfire Risk Score is enabled or not > Then" is satisfied, I click "+ ORDER WILDFIRE RISK SCORE"

    # Source step 0046: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0047: EQH||Location-Provide other details and complete | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-f20d-c6e3-d27d4052fe6e
    Then I wait until "Lbl_Home in City Limits?" is visible
    When I click "Btn_IN"
    When I click "Btn_NEXT"

    # Source step 0048: EQH||Home Characteristics_SH4-Provide all details and move to next page | Module: EQH||Home Characteristics_SH4
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e58-aa54-b04e-c6a66d25b2ee
    Then I wait until "Home Characteristics_Header" is visible
    Then "Txt_Years Built" should exist
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "\"{DEL}\"" in "Txt_Years Built"
    When I enter or select "\"^{a}\"" in "Txt_Years Built"
    When I enter or select "1920" in "Txt_Years Built"
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

    # Source step 0049: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0058: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-71ac-8730-5f761d2bb46c
    # Runtime control: If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up
    Then if the source runtime condition "If_not moved to On Premise Exposure page > Condition_Verify HomeCharactersitics-Roof UL details question is still showing up" is satisfied, "Lbl_Roof UL Rating" should be visible

    # Source step 0059: Home Characteristics-Roof Details | Module: EQH||Home Characteristics_SH3
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-7817-6dfe-53a63e730be4
    # Runtime control: If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures
    When if the source runtime condition "If_not moved to On Premise Exposure page > Then_Click 'NEXT' to move on to next page i.e On-Premise exposures" is satisfied, I click "Btn_NEXT"

    # Source step 0060: On Premise Exposures-Provide details regarding any exposures | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-026b-c37c-f20d61fa06bc
    Then I wait until "On Premise Exposures Header" is visible
    Then "Btn_Chk box_Swimming pool" should exist
    When I select "Btn_Chk box_None of the Above - Business Details"
    When I enter or select "PGDN" in "Lbl_Dog Exposures"
    When I enter or select "PGDN" in "Lbl_Business Details"
    Then "Btn_Chk box_BUSINESS ON PREMISE" should exist
    When I select "Btn_Chk box_None Of The Above"
    When I enter or select "PGDN" in "Lbl_Farm & Livestock Exposures"

    # Source step 0061: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0062: On Premise Exposures-Provide details and go to next page | Module: EQH||On Premise Exposures
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-775b-1bab-1754aa8bf623
    When I enter or select "{SCROLL[6][100px][Center][HorizontalFirst][300ms]}" in "Lbl_Farm & Livestock Exposures"
    Then "Btn_Chk box_DWELLING ONLY ACCESSIBLE BY BOAT OR PLANE" should exist
    When I select "Btn_Chk box_NONE OF THE ABOVE - Home and Household Eligibility"
    Then I wait until "Btn_NEXT" exists
    When I click "Btn_NEXT"

    # Source step 0063: Claims History-Click Next to move to Discounts page | Module: EQH||Claims History
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-9e2f-5a14-ac91aa63344b
    Then I wait until "Claims History Header" is visible
    When I click "Btn_NEXT"

    # Source step 0064: Discounts/Adjustments-click Next to move | Module: EQH||Discounts/Adjustments
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-e790-3bcd-de166f0f8411
    Then I wait until "Discounts/Adjustments Header" is visible
    Then I wait until "Btn_Chk box_AUTO-HOME" is visible
    Then "Lbl_Three Line Discount?" should exist
    Then "Btn_Chk box_Central Fire Alarm" should exist
    When I click "Btn_NEXT"

    # Source step 0065: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0066: EQH||Coverages-Edit-Option 1-All Other Peril Deductible $3000 | Module: EQH||Coverages-Edit-Option 1
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-2d7f-f48b-667e29c19c48
    Then I wait until "Lbl_Coverages" is visible
    When I click "Btn_EDIT"
    Then I wait until "Btn_Reset Fields" is visible
    When I enter or select "{SCROLL[9][1000px][Center][HorizontalFirst][100ms]}" in "Btn_Reset Fields"
    When I click "Btn_All Other Peril Deductible"
    When I click "All Other Peril Deductible_$3,000"
    Then I wait until "Btn_Save" is visible
    When I click "Btn_Save"
    Then I wait until "Btn_Next" is visible
    When I click "Btn_Next"

    # Source step 0067: EQH||Side Menu and Quote Actions-Click Additional Coverages to refresh the page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-8d87-ca93-454d4b59e382
    When I click "Additional Coverages"

    # Source step 0068: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0069: Additional Coverages-Add 'Blanket Jewelry, Watches, And Furs Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-91ef-17f3-88b05d105779
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Blanket Jewelry, Watches, And Furs Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0070: Additional Coverages-Add 'Increase For Theft Of Guns' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-4277-8435-c7ac212d5093
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increase For Theft Of Guns" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0071: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0072: Additional Coverages-Add 'Increase For Theft Of Service Sets' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-72a4-f244-743c8d937d38
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increase For Theft Of Service Sets" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0073: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0074: Additional Coverages-Add 'Increase For Theft Of Tools And Toolboxes' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-7758-c35f-396336ba6931
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Increase For Theft Of Tools And Toolboxes" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0075: EQH||Additional Coverages-Contents Coverages-Update 'Increase For Theft Of Tools And Toolboxes' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-10e6-b1ce-e5ad02f6fe09
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I enter or select "8000" in "Txt_Increase For Theft Of Tools And Toolboxes"
    When I click "Btn_Personal Use"
    When I click "Btn_Next"

    # Source step 0076: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0077: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-460f-ebb8-a7e463014c15
    When I click "Additional Coverages"

    # Source step 0078: Additional Coverages-Add 'Increased Limits For Home Computer' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-d7a0-2e41-ee05e67148cd
    When I enter or select "Increased Limits For Home Computer" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0079: EQH||Additional Coverages-Contents Coverages-Update 'Increased Limits For Home Computer' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-e153-352d-146b8103986d
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I click "Btn_Next"

    # Source step 0080: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0081: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-faed-747e-fa5c8e73bd5e
    When I click "Additional Coverages"

    # Source step 0082: Additional Coverages-Add 'Incidental Business Pursuits' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-ca3a-18f5-e433a354d753
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Incidental Business Pursuits" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0083: EQH||Additional Coverages-Liability Coverages-Add 'Incidental Business Pursuits' coverage/endorsement | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-36c9-2118-580e4d8db87b
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Liability Coverages"
    When I click "Btn_+ ADD BUSINESS PURSUIT"

    # Source step 0084: EQH||Scheduled Coverage-Add 'Incidental Business Pursuit' | Module: EQH||Scheduled Coverage-Liability Covg-Incidental Business Pursuit
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-2d3b-4e2b-6fb9d312301c
    When I enter or select "DUNKAN LLC" in "Txt_Name_IncidentalBusinessPursuits"
    When I click "Btn_Clerical Office Employees_Occupation"
    When I click "Btn_SAVE"

    # Source step 0085: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0086: Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-5670-079e-bbbd8f245971
    When I enter or select "Increased Limit For Lawn Implements" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0087: EQH||Additional Coverages-Contents Coverages-Update 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement | Module: EQH||Additional Coverages-Contents Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-4d46-fda1-28bf3bc0a2d2
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Contents Coverages"
    When I enter or select "15000" in "Txt_Increased Limits For Lawn Implements And Service Vehicles"
    When I click "Btn_Next"

    # Source step 0088: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0089: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-478f-95fc-de1cba2f8827
    When I click "Additional Coverages"

    # Source step 0090: Additional Coverages-Add 'Office, Professional, Private School Or Studio Use - Residence Premises' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-08cb-35a8-910429f31292
    When I enter or select "Office, Professional, Private School" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0091: EQH||Additional Coverages-Liability Coverages-Update 'Office, Professional, Private School Or Studio Use - Residence Premises' | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-7ec7-5157-288695746cfd
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I click "Sole Proprietorship"
    When I click "One Chair Beauty or Barber Shop"
    When I click "Separate Structure on Premises"
    When I click "$5,000"
    When I enter or select "\"^{a}\"" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "\"^{DEL}\"" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "6000" in "Txt_OfficeProfessionalPrivateSchool_CurrentValue"
    When I enter or select "18000" in "Txt_OfficeProfessionalPrivateSchool_ApproximateAnnualGrossRevenues"
    When I click "Btn_Next"

    # Source step 0092: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0093: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-9b6f-1080-33dbc8f8b3cc
    When I click "Additional Coverages"

    # Source step 0094: Additional Coverages-Add 'Additional Residence Premises - Rented To Others' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-454b-6e13-72765f3bfe8a
    When I enter or select "Additional Residence Premises - Rented To Others" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"

    # Source step 0095: EQH||Additional Coverages-Liability Coverages-Select 'Add Additional Location' | Module: EQH||Additional Coverages-Liability Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-fb61-6038-f4b30094e573
    When I click "Btn_+ ADD ADDL RESIDENCE LOCATION"

    # Source step 0096: EQH||Scheduled Coverage-Liability Covg-Update 'Additional Residence Premises - Rented To Others' | Module: EQH||Scheduled Coverage-Liability Covg-Additional Residence Premises - Rented To Others
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-4aa2-bd3b-5d648307583e
    When I enter or select "201 Arno St NE, Albuquerque, NM 87102" in "Enter a location"
    When I enter or select "{click}{down}" in "Enter a location"
    When I click "1"
    When I select "No"
    When I click "SAVE"

    # Source step 0097: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "15000" milliseconds

    # Source step 0098: EQH||Side Menu and Quote Actions-Navigate back to Additional Coverages | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-4cc8-3ed9-f3b0bc700945
    When I click "Additional Coverages"

    # Source step 0099: Additional Coverages-Add 'Child Care Coverage' coverage/endorsement | Module: EQH||Additional Coverages
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-f8f7-e00c-593eb3b36d0c
    Then I wait until "Additional Coverages Header" is visible
    When I enter or select "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverage Catalog"
    When I enter or select "Child Care Coverage" in "Txt_Search by Name-Coverage Catalog"
    When I click "Btn_Search-Coverage Catalog"
    When I click "TABLE > $1 > $1"
    When I click "Btn_NEXT"

    # Source step 0100: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0101: Pricing Details-Verify Pricing summary and View Documents | Module: EQ||Pricing Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-904c-023b-1fc8783a647c
    Then I wait until "Hdr_Pricing Details Header" is visible
    Then I wait until "Lbl_Residence Summary" is visible
    Then "Lbl_Premium Summary" should be visible
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Coverages-Premium Summary"
    When I capture "InnerText" from "Lbl_Value_Total Premium" as runtime value "Pricing Details_Total Premium"
    Then I wait until "Btn_NEXT" is visible
    When I click "Btn_NEXT"

    # Source step 0102: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "5000" milliseconds

    # Source step 0105: Mortgage/Additional Interest-Click NEXT to move to Billing | Module: EQH||Mortgage/Additional Interest
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-4268-7f0c-7d39489ec55f
    Then I wait until "Mortgage/Additional Interest Header" is visible
    Then I wait until "Lbl_Mortgage / Additional Interest Summary" is visible
    When I click "Btn_NEXT"

    # Source step 0106: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "2000" milliseconds

    # Source step 0107: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e68-6274-cd72-279e4a51555e
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

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "12000" milliseconds

    # Source step 0145: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0147: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "8000" milliseconds

    # Source step 0149: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "3000" milliseconds

    # Source step 0150: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-3d83-a946-24421527f5e9
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

    # Source step 0151: TestData-Save PolicyNumber, Date to TDM for Post XML validation | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-33a9-b072-2159f02eeb92
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Date to TDM for Post XML validation"
    And I use TDM parameter "Existing or new TDS type" with "Regression_Temp_Data"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > DateTime" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > State" with "PA"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0152: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-3e7c-7ff5-e203-86f1f529d640
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0154: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-f907-343e-3ad20a06033d
    # Runtime control: Close Chrome > Condition
    Then if the source runtime condition "Close Chrome > Condition" is satisfied, "Expression" should equal "Edge' = 'Chrome"

    # Source step 0155: TBox Start Program | Module: TBox Start Program
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-8434-e8b9-796ecb27e208
    # Runtime control: Close Chrome > Then
    And if the source runtime condition "Close Chrome > Then" is satisfied, I force-close browser/process "chrome.exe" using command "taskkill /im chrome.exe /f"

    # Source step 0156: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Postcondition | Reusable flow: Common | Close browser (force) | Source XTestStep: 3a19dd55-d434-e33b-af11-6296dee9c1a1
    # Runtime control: Close Edge > Condition
    Then if the source runtime condition "Close Edge > Condition" is satisfied, "Expression" should equal "Edge' = 'Edge"

    # Source step 0157: TBox Start Program | Module: TBox Start Program
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
# 5. Source step 0029 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: a blank value
# 6. Source step 0032 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 7. Source step 0032 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Provide SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 8. Source step 0034 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 9. Source step 0034 field "Btn_None of the Above_SH3_SH6" in "Pre-Qualification-Select Client and Property Eligibility Restrictions" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 10. Source step 0037 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 11. Source step 0037 field "Btn_C/O" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 12. Source step 0037 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 13. Source step 0037 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 14. Source step 0037 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 15. Source step 0040 field "Btn_Hide Google Maps" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 16. Source step 0040 field "7.1-10.0" in "EQH||Location-till miles to fire station" was disabled. Reason:  
#    - Preserved source value: a blank value
# 17. Source step 0044 field "Location Header" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 18. Source step 0044 field "Lbl_How long have you owned or occupied location?" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 19. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "X"
# 20. Source step 0044 field "Btn_More than 5 years" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "True"
# 21. Source step 0044 field "Btn_Hide Google Maps" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}"
# 22. Source step 0044 field "Drp List_Miles to Fire Station-need to check" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 23. Source step 0044 field "0-3.0" in "Verify Order Wildfire Risk Score is enabled" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 24. Source step 0045 field "Location Header" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 25. Source step 0045 field "Lbl_How long have you owned or occupied location?" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 26. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 27. Source step 0045 field "Btn_More than 5 years" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 28. Source step 0045 field "Btn_Hide Google Maps" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 29. Source step 0045 field "Drp List_Miles to Fire Station-need to check" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 30. Source step 0045 field "0-3.0" in "Get the the Wildfore Risk Score for property" was disabled. Reason:  
#    - Preserved source value: a blank value
# 31. Source step 0048 field "Lbl_# of Apts. Between Firewalls" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "True"
# 32. Source step 0048 field "Lbl_Building Occupancy" in "EQH||Home Characteristics_SH4-Provide all details and move to next page" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][Center][HorizontalFirst][300ms]}"
# 33. Source step 0050 "RCT||Home Page" in module "RCT | Home Page" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - WAIT "Btn_Edit_Building Information" with "True"
#    - INPUT "Btn_Finish_Valuation Totals" with "{Click}"
# 34. Source step 0051 "RCT||Pop up-Save,Discard,Close" in module "RCT | Pop up-Save,Discard,Close" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - WAIT "Btn_Save" with "True"
#    - INPUT "Btn_Save" with "X"
#    - INPUT "Btn_Close" with a blank value
# 35. Source step 0052 "RCT||Complete page" in module "RCT | Complete page" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - WAIT "DIV_Complete!" with "True"
#    - VERIFY "DIV_You may now close this window. This valuation is being processed." with "True"
# 36. Source step 0053 "Close the RCT Express page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - INPUT "Caption" with "test.anpac.info/*"
#    - INPUT "Keys" with "^(w)"
# 37. Source step 0054 "EQH||Home Characteristics-RCT Page Opened Pop up" in module "EQH||Home Characteristics-RCT Page Opened Pop up" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - WAIT "Please click 'OK' after the RCT page has been updated to refresh this page" with "True"
#    - INPUT "Btn_Ok" with "{Click}"
# 38. Source step 0055 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - INPUT "Duration" with "5000"
# 39. Source step 0056 "EQH||Home Characteristics_SH6-Property Information and Heating details" in module "EQH||Home Characteristics_SH6" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - INPUT "Lbl_Home Type" with "{SCROLL[5][1000px][Center][HorizontalFirst][300ms]}"
#    - VERIFY "Lbl_Construction Type" with "True"
#    - INPUT "Frame" with "X"
#    - INPUT "Tenant" with "X"
#    - INPUT "Btn_Condominium rented to others_Yes" with "X"
#    - INPUT "< 6 Months" with "X"
#    - INPUT "Btn_Principal Heat_Central" with "X"
#    - INPUT "Btn_Supplemental Heat_Floor Furnace" with "X"
#    - INPUT "Btn_Home Characteristics_Next" with "X"
# 40. Source step 0057 "TBox Wait" in module "TBox Wait" was disabled. Reason: 29.02.24 17:25:17 [ct2452]
#    - INPUT "Duration" with "5000"
# 41. Source step 0058 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 42. Source step 0058 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 43. Source step 0058 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 44. Source step 0058 field "Btn_Chk box_Roof Damaged or Needs repair including worn shingles or granule loss." in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0058 field "Btn_Chk box_Roof is T-Lock or simliar Interlocking Shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 46. Source step 0058 field "Btn_Chk box_Roof overlaid with more than two layers of shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0058 field "Btn_Chk box_Roof overlaid on wood shake or shingle" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 48. Source step 0058 field "Btn_Chk box_Wood roof overlaid on composition shingles" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 49. Source step 0058 field "Btn_Chk box_Include Loss Settlement for Roofs Damaged by Windstorm or Hail Endorsement" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 50. Source step 0058 field "Btn_NEXT" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 51. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 52. Source step 0059 field "Lbl_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 53. Source step 0059 field "Btn_None_Roof UL Rating" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "{Invoke[Click]}"
# 54. Source step 0059 field "Btn_UL3" in "Home Characteristics-Roof Details" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0066 field "Txt_C.Personal Property" in "EQH||Coverages-Edit-Option 1-All Other Peril Deductible $3000" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 56. Source step 0078 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Limits For Home Computer' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 57. Source step 0079 field "Txt_Increased Limits For Home Computer Hardware And Software" in "EQH||Additional Coverages-Contents Coverages-Update 'Increased Limits For Home Computer' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "1500"
# 58. Source step 0086 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 59. Source step 0086 field "Btn_Search-Coverage Catalog" in "Additional Coverages-Add 'Increased Limit For Lawn Implements And Service Vehicles' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}"
# 60. Source step 0090 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Office, Professional, Private School Or Studio Use - Residence Premises' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 61. Source step 0094 field "Lbl_Coverage Catalog" in "Additional Coverages-Add 'Additional Residence Premises - Rented To Others' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[11][1000px][None][HorizontalFirst][300ms]}"
# 62. Source step 0099 field "Btn_Search-Coverage Catalog" in "Additional Coverages-Add 'Child Care Coverage' coverage/endorsement" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
# 63. Source step 0101 field "Lbl_Proposal" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 64. Source step 0101 field "Lbl_Coverage Option Overview" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 65. Source step 0101 field "Lbl_Home Binder" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 66. Source step 0101 field "Btn_Print/Open Home Binder document" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 67. Source step 0101 field "Lbl_PDF Viewer-Proposal/CoverageOption/HomeBinder documents header" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "True"
# 68. Source step 0101 field "Btn_OK_PDF Viewer Close-Proposal/CoverageOption/HomeBinder documents" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "X"
# 69. Source step 0101 field "Btn_NEXT" in "Pricing Details-Verify Pricing summary and View Documents" was disabled. Reason:  
#    - Preserved source value: "{SCROLL[1][1000px][None][HorizontalFirst][300ms]}"
# 70. Source step 0103 "Mortgage/Additional Interest-Add Additional Interest" in module "EQH||Mortgage/Additional Interest" was disabled. Reason: 29.02.24 17:15:00 [ct2452]
#    - WAIT "Mortgage/Additional Interest Header" with "True"
#    - WAIT "Lbl_Mortgage / Additional Interest Summary" with "True"
#    - INPUT "Btn_ADD MORTGAGE / ADD'L INTEREST" with "{Invoke[Click]}"
#    - INPUT "Btn_NEXT" with a blank value
# 71. Source step 0104 "EQH||Add/Edit Additional Interest - Adding Additional Interest" in module "EQH||Add/Edit Additional Interest-Additional Insured/Landlord" was disabled. Reason: 29.02.24 17:15:00 [ct2452]
#    - WAIT "Lbl_Interest Type" with "True"
#    - WAIT "Btn_First Mortgagee" with "True"
#    - INPUT "Btn_Additional Insured/Landlord" with "X"
#    - WAIT "Btn_Additional Insured" with "True"
#    - INPUT "Text box_Name" with captured runtime value "FirstName"
#    - INPUT "Text box_Address" with "1310 Wilclark Rd Clovis"
#    - INPUT "Text box_City" with "Curry"
#    - INPUT "Dropdown-State-GenericGUI" with "{Click}"
#    - INPUT "NM" with "X"
#    - INPUT "Text box_Zip Code" with "88101"
#    - INPUT "Text box_Loan Number" with a blank value
#    - INPUT "Btn_SAVE" with "X"
# 72. Source step 0105 field "Btn_ADD MORTGAGE / ADD'L INTEREST" in "Mortgage/Additional Interest-Click NEXT to move to Billing" was disabled. Reason:  
#    - Preserved source value: a blank value
# 73. Source step 0107 field "Btn_Direct Bill - 2 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 74. Source step 0107 field "Btn_Direct Bill - 4 Payments" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 75. Source step 0107 field "Lbl_Select a payment amount." in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: a blank value
# 76. Source step 0107 field "Btn_QUICK PAY" in "Billing-Create and Update Billing details" was disabled. Reason:  
#    - Preserved source value: "True"
# 77. Source step 0109 "Submission- Launch to Checklist" in module "EQ||Submission" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - INPUT "Lbl_Step 1. Review Messages" with "{SCROLL[6][1000px][None][HorizontalFirst][300ms]}"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "True"
#    - INPUT "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
# 78. Source step 0110 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - INPUT "Duration" with "10000"
# 79. Source step 0111 "Verify eChecklist Sign on page showed up" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 80. Source step 0112 "Provide the Sign on credentials" in module "EQH||eChecklist-Sign On" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YDF999"
#    - INPUT "Txt_Password" with "${ENV:PL_DC_PASSWORD}"
#    - INPUT "Btn_Sign On" with "X"
# 81. Source step 0113 "eChecklist-Click the 'Home/ROP Electronic Application' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Link_Home/ROP Electronic Application" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 82. Source step 0114 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 83. Source step 0115 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - INPUT "Duration" with "10000"
# 84. Source step 0116 "eChecklist-Verify if 'Application' links in the checklist are completed" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - VERIFY "Drag and Drop files here to upload (or click here to open a file explorer)" with "True"
# 85. Source step 0117 "eChecklist-Click the drag/drop link to upload the file in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 86. Source step 0118 "TBox Wait" in module "TBox Wait" was disabled. Reason: 19.03.24 12:52:29 [ct2452]
#    - INPUT "Duration" with "2000"
# 87. Source step 0119 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 17:50:54 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 88. Source step 0120 "eChecklist-Click the 'Additional Residence Premises - Rented to Others (back diagonal)' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Additional Residence Premises - Rented to Others (back diagonal)" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 89. Source step 0121 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 90. Source step 0122 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Duration" with "10000"
# 91. Source step 0123 "eChecklist-Click the 'Additional Residence Premises - Rented to Others (front diagonal)' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Additional Residence Premises - Rented to Others (front diagonal)" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 92. Source step 0124 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 93. Source step 0125 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Duration" with "10000"
# 94. Source step 0126 "eChecklist-Click the 'Service Vehicle & Lawn Implements - Appraisal/Receipt' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Service Vehicle & Lawn Implements - Appraisal/Receipt" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 95. Source step 0127 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 96. Source step 0128 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Duration" with "10000"
# 97. Source step 0129 "eChecklist-Click the 'Service Vehicle & Lawn Implements - Photo' in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Service Vehicle & Lawn Implements - Photo" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 98. Source step 0130 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 99. Source step 0131 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Duration" with "10000"
# 100. Source step 0132 "eChecklist-Click the 'Theft of Tools & Tool Boxes-Appraisal/Receipt' link in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Link_Theft of Tools & Tool Boxes - Appraisal/Receipt" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 101. Source step 0133 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 102. Source step 0134 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Duration" with "8000"
# 103. Source step 0135 "eChecklist-Click the 'Theft of Tools & Tool Boxes-Photo' link in the checklist" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Link_Theft of Tools & Tool Boxes - Photo" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 104. Source step 0136 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 105. Source step 0137 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Duration" with "8000"
# 106. Source step 0138 "eChecklist-Click the 'Main Electic Panel'" in module "EQH||eChecklist-Home Page" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - WAIT "H4" with "True"
#    - INPUT "Btn_Named Insured/Account Holder name on top left" with "X"
#    - INPUT "Link_Theft of Tools & Tool Boxes - Photo" with "X"
#    - INPUT "Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 107. Source step 0139 "eChecklist-TBox Save As-Upload sample pdf document from shared path" in module "TBox Save As" was disabled. Reason: 20.03.24 12:22:59 [ct2452]
#    - INPUT "Caption" with "Open*"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist3.pdf"
#    - INPUT "Button" with "Open"
# 108. Source step 0140 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:06 [ct2452]
#    - INPUT "Duration" with "10000"
# 109. Source step 0141 "Close the eChecklist page/tab in browser" in module "TBox Send Keys" was disabled. Reason: 20.03.24 17:51:06 [ct2452]
#    - INPUT "Caption" with "American*"
#    - INPUT "Keys" with "^(w)"
# 110. Source step 0142 "TBox Wait" in module "TBox Wait" was disabled. Reason: 20.03.24 17:51:06 [ct2452]
#    - INPUT "Duration" with "10000"
# 111. Source step 0143 "Verify eChecklist opened Pop up is shown on submission page" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:51:06 [ct2452]
#    - VERIFY "Header_Checklist Opened" with "True"
# 112. Source step 0144 "Click OK to close the eChecklist opened Pop up" in module "EQH||eChecklist-Pop up" was disabled. Reason: 20.03.24 17:51:06 [ct2452]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
# 113. Source step 0146 "Submission-Transmit and issue Policy" in module "EQ||Submission" was disabled. Reason: 15.03.24 15:13:57 [ct2452]
#    - VERIFY "Hdr_Submission Header" with "True"
#    - WAIT "Lbl_Step 3. Attach Supporting Documentation" with "True"
#    - VERIFY "Btn_Launch To Checklist_1" with "{Invoke[Click]}"
#    - VERIFY "Btn_Launch To eSignature_1" with "True"
#    - INPUT "Lbl_Step 4. Transmit" with "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}"
#    - VERIFY "Btn_Transmit_1" with "True"
#    - INPUT "Btn_Transmit_1" with "{Invoke[Click]}"
#    - INPUT "Btn_Issue Home Binder" with "{Invoke[Click]}"
#    - VERIFY "Btn_Save and Exit_1" with "True"
# 114. Source step 0148 "Transmit Confirmation-Get Policy Number, Premium details" in module "EQH||Transmit Confirmation" was disabled. Reason: 15.03.24 15:14:03 [ct2452]
#    - VERIFY "Transmit Confirmation Header" with "True"
#    - BUFFER "Policy Transmitted > $1 > Stage" with "Stage"
#    - BUFFER "Policy Transmitted > $1 > Line" with "Line"
#    - BUFFER "Policy Transmitted > $1 > Name" with "Name"
#    - BUFFER "Policy Transmitted > $1 > Policy Number" with "Policy Number"
#    - BUFFER "Policy Transmitted > $1 > Premium" with "Premium"
#    - BUFFER "Policy Transmitted > $1 > Transmitted" with "Transmitted"
#    - BUFFER "Policy Transmitted > $1 > Effective" with "Effective Date"
# 115. Source step 0150 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 116. Source step 0150 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
# 117. Source step 0150 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 118. Source step 0151 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 119. Source step 0151 field "Data structure > EffectiveDate" in "TestData-Save PolicyNumber, Date to TDM for Post XML validation" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Effective Date"
# 120. Source step 0153 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.03.24 10:47:07 [ct2452]
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
