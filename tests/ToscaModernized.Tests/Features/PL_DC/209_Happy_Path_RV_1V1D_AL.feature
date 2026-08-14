# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 209_Happy_Path_RV_1V1D_AL.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @RV @happy_path @Alabama @Edge @manual @automated
Feature: Execute Happy Path RV 1V1D for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path RV 1V1D workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path RV 1V1D using representative iteration Alabama (AL)
    # Source step 0012: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > Auto > 01 Client Selection & Account Details for New Client > Start New Quote | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Common | 01 EQ - Start New Quote | Source XTestStep: 3a19dd55-d443-6b95-2414-e782dd27e3e3
    Given I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0013: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > Auto > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Client Selection (NEW) | Source XTestStep: 3a19dd55-d49d-6991-8246-f114ce750615
    Then I wait until "Lbl_Client Info" exists
    Then "Lbl_Client Info" should equal "Client Info"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.First Name" in "Txt_First"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.Last Name" in "Txt_Last"
    Then I wait until "Btn_Search" exists
    When I click "Btn_Search"
    Then I wait until "Btn_Create New Client" has "InnerText" equal to "Create New Client"
    When I click "Btn_Create New Client"
    When I click "Btn_Next"

    # Source step 0014: Set StateName | Module: TBox Set Buffer
    # Section: Process > Auto > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a1a96b2-e11f-e48e-9f6e-bb78c0d69fc1
    When I retain hard-coded value "ALABAMA" as runtime value "StateName"
    When I retain the unresolved source parameter "State Abbreviation" (not supplied by this reusable-block invocation) as runtime value "State"

    # Source step 0015: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Auto > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a19dd55-d4bb-5344-2b53-6fbb792cb2ce
    Then I wait until "Lbl_Account Information" exists
    Then "Txt_First Name_Account Owner" should exist
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.DOB" in "Txt_DOB"
    When I enter or select "5555551234" in "Txt_Best phone_Account Owner"
    When I enter or select "a@a.com" in "Txt_Email_Account Owner"
    Then I wait until "Lbl_Marital Status:" exists
    When I click "Btn_Single" when "'Marital Status' == \"Single\"" is satisfied
    When I select "Btn_Married" when "'Marital Status' == \"Married\"" is satisfied
    When I click "Btn_Divorced" when "'Marital Status' == \"Divorced\"" is satisfied
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.Street Address" in "Txt_Enter a location"
    When I enter the unresolved source parameter "Apartment" (not supplied by this reusable-block invocation) in "Txt_owner.address.line2"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.City" in "Txt_owner.address.city_New"
    When I select "Drpdwn_State"
    When I select "State Name"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.ZIP" in "Txt_owner.address.zip"
    Then I wait until "Satellite" is visible

    # Source step 0016: Account Details-Move down the screen | Module: EQ||Account Details
    # Section: Process > Auto > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a20ccea-6d87-3233-e1a5-8febbb16c0cb
    When I press "Shift+Tab" while focused on "Btn_Next"

    # Source step 0017: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > Auto > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client_1 > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a20cced-453c-5ea2-16e9-ff5272653480
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" exists
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0018: TBox Set Effective Date Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e7b-a6e5-7d00-f0c2-4760e71faa97
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{Date[{DATE}][][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0019: Navigate to top of screen | Module: EQ || Proposal Details/Start
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a20cd02-ca9e-8963-fbb2-ee430e14bbf7
    When I enter or select "{Scroll[-2]}" in "EffectiveDate"

    # Source step 0020: Proposal Details/Start | Module: EQ || Proposal Details/Start
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-b4d0-23a9-de44036bc990
    When I click "Personal Auto" when "LOB == \"PersonalAuto\"" is satisfied
    When I click "Motorcycle" when "LOB == \"Cycle\"" is satisfied
    When I click "Recreational Vehicle" when "LOB == \"RecreationalVehicle\"" is satisfied
    When I enter captured runtime value "EffectiveDate" in "EffectiveDate" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "D2102" in "AgentCode" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "AgentCode" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "State Name"
    When I press "Tab" while focused on "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "American National Property And Casualty Co." in "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "" in "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    Then I wait until "SameAsMailingAddress" is enabled
    When I enter or select "{Click}" in "SameAsMailingAddress"
    When I enter the unresolved source parameter "County Name" (not supplied by this reusable-block invocation) in "County_ComboBox" when "'County Name' != NULL" is satisfied
    Then I wait until "Start Quote" is visible
    When I click "Start Quote"

    # Source step 0024: Invalid Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-16d8-9e02-3881cfde7fcf
    # Runtime control: If Invalid Address Pops Up > Condition
    Then if the source runtime condition "If Invalid Address Pops Up > Condition" is satisfied, "Lnk_PROCEED" should exist

    # Source step 0025: Proceed with Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-a1cf-236e-50b5851b652b
    # Runtime control: If Invalid Address Pops Up > Then
    When if the source runtime condition "If Invalid Address Pops Up > Then" is satisfied, I click "Lnk_PROCEED"

    # Source step 0026: Confirm SSN? | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-b90f-dc8e-fc482b757001
    # Runtime control: If SSN Pop Up Confirm Exist  > Condition
    Then if the source runtime condition "If SSN Pop Up Confirm Exist > Condition" is satisfied, "Lnk_CONFIRM" should exist

    # Source step 0027: Select Confirm | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-db7a-eaec-fc221ebe2f9e
    # Runtime control: If SSN Pop Up Confirm Exist  > Then
    When if the source runtime condition "If SSN Pop Up Confirm Exist > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0028: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-1eba-4b97-bb6837e42931
    # Runtime control: If SSN Pop Up Confirm Exist  > Else > If SSN Pops Up > Condition
    Then if the source runtime condition "If SSN Pop Up Confirm Exist > Else > If SSN Pops Up > Condition" is satisfied, "Txt_SSN" should exist
    Then "Lnk_SUBMIT" should exist

    # Source step 0029: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-f7eb-36e8-124cfd68f528
    # Runtime control: If SSN Pop Up Confirm Exist  > Else > If SSN Pops Up > Then
    When if the source runtime condition "If SSN Pop Up Confirm Exist > Else > If SSN Pops Up > Then" is satisfied, I enter the RUNTIME-DERIVED TDM value "AL_ClientData.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0030: Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-e9ec-339f-d59f7f5b9ce8
    # Runtime control: If Existing Client Pops Up > Condition
    Then if the source runtime condition "If Existing Client Pops Up > Condition" is satisfied, "Client Already Exists" should exist

    # Source step 0031: Select Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Auto > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-96a1-6ec5-4c64d135a412
    # Runtime control: If Existing Client Pops Up > Then
    When if the source runtime condition "If Existing Client Pops Up > Then" is satisfied, I click "Lnk_CREATE NEW ACCOUNT"

    # Source step 0032: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Auto > 03 Pre-Qualification > 03 EQ | Auto - Pre-Qualification | Reusable flow: Auto | 03 EQ | Pre-Qualification (New) | Source XTestStep: 3a19dd55-d425-4b84-160d-b4880cf2b369
    When I enter or select "{CLICK}" in "Btn_Chk box_check_boxNone Of The Above"
    When I enter or select "{CLICK}" in "Btn_Next"

    # Source step 0033: EQ||Tabs - Capturing Quote number | Module: EQ||Tabs
    # Section: Process > Auto > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number | Source XTestStep: 3a19dd55-d443-9c9d-9370-343c6da34248
    When I capture "Text" from "Lbl_QNum" as runtime value "QuoteNumber2"

    # Source step 0034: TBox Set Buffer - Trimming Quote number | Module: TBox Set Buffer
    # Section: Process > Auto > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number | Source XTestStep: 3a19dd55-d443-fb9d-e604-b32de4887229
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}" as runtime value "QuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}" as runtime value "QuoteNumber4"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0035: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ -  Driver Information | Source XTestStep: 3a19dd55-d470-eb81-cece-a5f2c7b44eb9
    When I click "(Existing Client)_1"
    When I enter or select "{Click}" in "Btn_Next"

    # Source step 0036: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-67ca-4506-0400320d4e53
    When I retain the unresolved source parameter "MT National Guard" (not supplied by this reusable-block invocation) as runtime value "MT National Guard"

    # Source step 0040: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-acad-4c10-4f278508432b
    # Runtime control: If Marital Status Enabled > Condition
    Then if the source runtime condition "If Marital Status Enabled > Condition" is satisfied, "Single" should exist

    # Source step 0041: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-64a2-b464-f2c749d5e455
    # Runtime control: If Marital Status Enabled > Then
    When if the source runtime condition "If Marital Status Enabled > Then" is satisfied, I click "Single" when "'Marital Status' != \"Single\"" is satisfied
    When I select "Married" when "'Marital Status' != \"Married\"" is satisfied
    When I click "Divorced" when "'Marital Status' != \"Divorced\"" is satisfied
    When I click "Single" when "'Marital Status' == \"Single\"" is satisfied
    When I select "Married" when "'Marital Status' == \"Married\"" is satisfied
    When I click "Divorced" when "'Marital Status' == \"Divorced\"" is satisfied

    # Source step 0042: DriverEducationLevel | Module: EQ || DriverEducationLevel
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-22de-f57a-4b5d41897a85
    # Runtime control: If Education Enabled > Condition
    Then if the source runtime condition "If Education Enabled > Condition" is satisfied, "High School Diploma or GED" should be enabled

    # Source step 0043: DriverEducationLevel | Module: EQ || DriverEducationLevel
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-2e30-5e2a-6937be39ab36
    # Runtime control: If Education Enabled > Then
    When if the source runtime condition "If Education Enabled > Then" is satisfied, I click "High School Diploma or GED" when "MD_NJ_EducationLevel == \"Unknown\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "MD_NJ_EducationLevel == \"Unknown\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "MD_NJ_EducationLevel == \"HighSchool\"" is satisfied
    When I click "High School Diploma or GED" when "MD_NJ_EducationLevel == \"HighSchool\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "MD_NJ_EducationLevel == \"Trade\"" is satisfied
    When I click "Vocational or Trade School Degree" when "MD_NJ_EducationLevel == \"Trade\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\"" is satisfied
    When I select "More Options Edu" when "MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\"" is satisfied
    Then I wait until "Some College" is visible when "MD_NJ_EducationLevel == \"SomeCollege\"" is satisfied
    When I click "Some College" when "MD_NJ_EducationLevel == \"SomeCollege\"" is satisfied
    Then I wait until "Currently in College" is visible when "MD_NJ_EducationLevel == \"InCollege\"" is satisfied
    When I click "Currently in College" when "MD_NJ_EducationLevel == \"InCollege\"" is satisfied
    Then I wait until "College Degree/Graduate Work" is visible when "MD_NJ_EducationLevel == \"CollegeDegree\"" is satisfied
    When I click "College Degree/Graduate Work" when "MD_NJ_EducationLevel == \"CollegeDegree\"" is satisfied
    Then I wait until "Graduate Degree (JD, Masters)" is visible when "MD_NJ_EducationLevel == \"GradDegree\"" is satisfied
    When I click "Graduate Degree (JD, Masters)" when "MD_NJ_EducationLevel == \"GradDegree\"" is satisfied
    Then I wait until "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)" is visible when "MD_NJ_EducationLevel == \"GradDegree\"" is satisfied
    When I click "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)" when "MD_NJ_EducationLevel == \"GradDegree\"" is satisfied

    # Source step 0044: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14ce-b64f-dcbe-52f4-ddfd07b5d07d
    # Runtime control: If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != "Cycle"
    Then if the source runtime condition "If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\"" is satisfied, "Spouse" should exist
    When I click "Account Owner"

    # Source step 0045: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14d0-85e0-79e4-1078-fda24b1f8582
    # Runtime control: If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != "Cycle"
    When if the source runtime condition "If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\"" is satisfied, I select "More Options (Relation to Account Owner)" when "'Relationship to Account Owner' != NULL" is satisfied
    When I click "Account Owner" when "'Relationship to Account Owner' != NULL" is satisfied

    # Source step 0046: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14d0-ce74-b9cb-b3ed-cd4467168b3c
    # Runtime control: If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != "Cycle"
    Then if the source runtime condition "If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\"" is satisfied, "Account Owner_Read Only" should exist

    # Source step 0047: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14db-b70f-45c9-eddb-a5c6f7094423
    # Runtime control: If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != "Cycle"
    Then if the source runtime condition "If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\"" is satisfied, "Account Owner_Read Only" should exist

    # Source step 0048: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14da-5a6d-5fc3-9eb3-afdc9d03de74
    # Runtime control: If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != "Cycle"
    When if the source runtime condition "If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\"" is satisfied, I enter or select "{Click}{scroll[2]}" in "Account Owner"

    # Source step 0049: NamedIns_Operator Status_Cycle | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-2b15-8273-c404b5c0404d
    # Runtime control: 'Policy Type' == "Cycle"
    Then if the source runtime condition "'Policy Type' == \"Cycle\"" is satisfied, I wait until "Is this driver a named insured?" is visible
    When I enter or select "X{scroll[2]}" in "Primary Named Insured" when "'Named Insured?' == \"PrimaryNamedIns\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Named Insured" when "'Named Insured?' == \"NamedIns\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Not a Named Insured" when "'Named Insured?' == \"NotNamedIns\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Related" when "'Operator Status' == \"Assigned\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Assigned" when "'Operator Status' == \"Assigned\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Assigned" when "'Operator Status' == \"Related\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Related" when "'Operator Status' == \"Related\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Assigned" when "'Operator Status' == \"NoCycleLicense\"" is satisfied
    When I select "No Cycle License" when "'Operator Status' == \"NoCycleLicense\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Assigned" when "'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\"" is satisfied
    When I click "Military" when "'Operator Status' == \"Military\"" is satisfied
    When I click "Missionary" when "'Operator Status' == \"Missionary\"" is satisfied
    When I select "Non Driver" when "'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Other Insurance" when "'Operator Status' == \"OtherIns\"" is satisfied
    Then I wait until "Non-Driver Reason" is visible when "'Operator Status' == \"NonDriver\"" is satisfied
    When I enter or select "Never Licensed" in "CycleNonDriver_ComboBox" when "'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I enter or select "Underage" in "CycleNonDriver_ComboBox" when "'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I enter or select "Medical Condition" in "CycleNonDriver_ComboBox" when "'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I enter or select "Surrendered" in "CycleNonDriver_ComboBox" when "'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I enter or select "Permit Driver" in "CycleNonDriver_ComboBox" when "'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\"" is satisfied

    # Source step 0050: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-bed7-6dc5-6248987470f0
    # Runtime control: 'Policy Type' != "Cycle"
    Then if the source runtime condition "'Policy Type' != \"Cycle\"" is satisfied, I wait until "Is this driver a named insured?" is visible
    When I enter or select "X{scroll[2]}" in "Primary Named Insured" when "'Named Insured?' == \"PrimaryNamedIns\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Named Insured" when "'Named Insured?' == \"NamedIns\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Not a Named Insured" when "'Named Insured?' == \"NotNamedIns\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Assigned" when "'Operator Status' != \"Assigned\"" is satisfied
    When I enter or select "X{scroll[2]}" in "Non Driver" when "'Operator Status' != \"NonDriver\"" is satisfied
    When I click "Related" when "'Operator Status' != \"Related\"" is satisfied
    When I click "Assigned" when "'Operator Status' == \"Assigned\"" is satisfied
    When I click "Related" when "'Operator Status' == \"Related\"" is satisfied
    When I click "Military" when "'Operator Status' == \"Military\"" is satisfied
    When I click "Missionary" when "'Operator Status' == \"Missionary\"" is satisfied
    When I click "Other Insurance" when "'Operator Status' == \"OtherIns\"" is satisfied
    When I click "Roommate" when "'Operator Status' == \"Roomate\"" is satisfied
    Then I wait until "Non-Driver Reason" is visible when "'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Never Licensed" when "'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Underage" when "'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Medical Condition" when "'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I select "More Options_NonDriver" when "'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Surrendered" when "'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Permit Driver" when "'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\"" is satisfied

    # Source step 0051: License Info | Module: EQ || DriverLicense_Time
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-19bd-dde7-2fc97763504d
    When I enter the unresolved source parameter "State Licensed(XX)" (not supplied by this reusable-block invocation) in "License State" when "'State Licensed(XX)' != NULL" is satisfied
    When I enter or select "\"^{a}\"" in "Driver's License Number" when "'Drivers License #' != NULL" is satisfied
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.DL Number" in "Driver's License Number" when "'Drivers License #' != NULL" is satisfied
    When I enter or select "\"^{a}\"" in "Yrs Licensed Current State"
    When I enter or select "9" in "Yrs Licensed Current State"
    When I enter or select "\"^{a}\"" in "Months Licensed Current State"
    When I enter or select "9" in "Months Licensed Current State"
    When I enter or select "0" in "DaysOperatedUninsured" when "'State' == \"TX\"" is satisfied
    When I enter or select "\"^{a}\"" in "YrsLicensed All States" when "'State' == \"CA\"" is satisfied
    When I enter or select "9" in "YrsLicensed All States" when "'State' == \"CA\"" is satisfied
    When I enter or select "{Click}{Scroll[2]}" in "No" when "'Operator Status' == \"Assigned\"" is satisfied

    # Source step 0052: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1ca8e2-c037-4a88-944d-610a91933318
    # Runtime control: If client insured AN > Condition
    Then if the source runtime condition "If client insured AN > Condition" is satisfied, "Was this client insured with American National immediately prior to the carrier listed above?" should exist

    # Source step 0053: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1ca8e3-b95f-24c0-5890-eb7c717ccb05
    # Runtime control: If client insured AN > Then
    When if the source runtime condition "If client insured AN > Then" is satisfied, I select "No (Previously Insured?)"

    # Source step 0054: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-31f2-59ea-64b5d15df7ad
    # Runtime control: If Prior Ins Listed > Condition
    Then if the source runtime condition "If Prior Ins Listed > Condition" is satisfied, "Prior Carrier Name:" should exist

    # Source step 0055: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-78f2-ae36-2375667f9b21
    # Runtime control: If Prior Ins Listed > Then
    When if the source runtime condition "If Prior Ins Listed > Then" is satisfied, I click "Save and Continue"

    # Source step 0056: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-d344-1045-91f8a2224a19
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Condition
    Then if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Condition" is satisfied, "No Need - Was Not Licensed" should be visible

    # Source step 0057: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-06f9-6072-6e771286e5f3
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Then
    When if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Then" is satisfied, I enter or select "{End}{Click}" in "No Need - Was Not Licensed"
    When I click "Save and Continue"

    # Source step 0058: Save & Continue | Module: EQ || Prior Insurance Info
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-f3de-9f3c-35b9dd54efb9
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Else
    When if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Else" is satisfied, I click "Save and Continue"

    # Source step 0059: EQ || Expired License Pop Up | Module: EQ || Expired License Pop Up
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-4bc4-3bf5-62e9caafb20b
    # Runtime control: If License Expired Pop up > Condition
    Then if the source runtime condition "If License Expired Pop up > Condition" is satisfied, I wait until "CONTINUE" exists

    # Source step 0060: EQ || Expired License Pop Up | Module: EQ || Expired License Pop Up
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-6395-c07d-5485317b424a
    # Runtime control: If License Expired Pop up > Then
    When if the source runtime condition "If License Expired Pop up > Then" is satisfied, I click "CONTINUE"

    # Source step 0061: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-2bb8-d44c-bdda6126ad5c
    # Runtime control: 'Additional Drivers?' == "Yes"
    When if the source runtime condition "'Additional Drivers?' == \"Yes\"" is satisfied, I click "Driver Information"

    # Source step 0062: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-0828-ff66-1a82bd960ba2
    # Runtime control: If > Condition
    Then if the source runtime condition "If > Condition" is satisfied, I wait until "PrefilledDrivers" exists

    # Source step 0063: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-53ca-a517-f012a38d9d89
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I capture "ResultCount" from "PrefilledDrivers" as runtime value "NumberOfDrivers"

    # Source step 0064: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Auto > 04 Driver Information > Repetition | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-955b-09d6-d7a8d79d80e7
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I enter or select "" in "MAT-FORM-FIELD"
    When I enter or select "{return}" in "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)"

    # Source step 0065: Save & Continue | Module: EQ || Prefil Household Drivers
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-50c3-bf38-2ef127c8f25e
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I click "Save and Continue"

    # Source step 0066: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-391c-4683-2363a242b3c9
    # Runtime control: If > Else > If > Condition
    Then if the source runtime condition "If > Else > If > Condition" is satisfied, "Unselected Client Suggestions" should exist

    # Source step 0067: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Auto > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-c21c-d3f6-8683943ddec0
    # Runtime control: If > Else > If > Then
    When if the source runtime condition "If > Else > If > Then" is satisfied, I click "Save and Continue"

    # Source step 0068: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Auto > 04 Driver Information > Capture Driver Names | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-2a29-4e81-5b6a35363e97
    When I click "Driver Information"
    When I use source configuration "Vehicle Summary" = "AL" for "EQ | Side Menu"
    When I use source configuration "Coverages" = "Happy Path Auto 1V1D" for "EQ | Side Menu"

    # Source step 0069: EQ|| Add Additional Driver 1 | Module: EQ|| Add Additional Driver 1
    # Section: Process > Auto > 04 Driver Information > Capture Driver Names | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-7622-14c8-3e98d6c470a0
    When I capture "InnerText" from "Driver_1" as runtime value "Driver_1"

    # Source step 0070: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Auto > 04 Driver Information > Capture Driver Names | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-f213-a168-2efa359a27b3
    When I click "Vehicle Summary"
    When I use source configuration "Coverages" = "Happy Path Auto 1V1D" for "EQ | Side Menu"

    # Source step 0071: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-6e8e-dc95-4ade758ab6aa
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected" is satisfied, "btn_select vehicle1" should exist

    # Source step 0072: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-963b-5665-fed0872e34d2
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I wait until "Loading ..." exists

    # Source step 0073: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-a31a-cb1f-2f0f39344681
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I click "Btn_Additional Vehicle"
    When I click "Btn_Next"

    # Source step 0074: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-f7a2-75d0-c298cb3735ee
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I wait until "Loading ..." exists

    # Source step 0075: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-afa7-ce2a-49e2a1a52528
    When I retain the unresolved source parameter "Farm/Use" (not supplied by this reusable-block invocation) as runtime value "Farm/Use"
    When I retain the unresolved source parameter "PickUp" (not supplied by this reusable-block invocation) as runtime value "PickUp"
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "ANPAC" as runtime value "Company"
    When I retain the unresolved source parameter "Loan" (not supplied by this reusable-block invocation) as runtime value "Loan"
    When I retain the unresolved source parameter "Lease" (not supplied by this reusable-block invocation) as runtime value "Lease"
    When I retain the unresolved source parameter "AntiTheft" (not supplied by this reusable-block invocation) as runtime value "AntiTheft"
    When I retain the unresolved source parameter "Business/Use" (not supplied by this reusable-block invocation) as runtime value "Business/Use"

    # Source step 0076: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-1b5f-b5d6-bda93b7ee7bb
    # Runtime control: Vehicles prefilled > Condition
    Then if the source runtime condition "Vehicles prefilled > Condition" is satisfied, I wait until "Btn_Additional Vehicle" is visible

    # Source step 0077: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-06d7-3220-d1c09ab7d73d
    # Runtime control: Vehicles prefilled > Then
    When if the source runtime condition "Vehicles prefilled > Then" is satisfied, I click "Btn_Additional Vehicle"
    When I click "Btn_Next"

    # Source step 0078: EQ||Vehicle Vin | Module: EQ||Vehicle Auto Vin_1
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-ee03-30f7-e392bd393429
    Then I wait until "txt_VIN" is enabled
    When I click "txt_VIN"
    When I enter or select "2B3KA43R26H469054" in "txt_VIN"
    When I press "Tab" while focused on "txt_VIN"
    When I click "btn_vehicle1"
    When I click "btn_Vehicle3" when "'Farm/Use' != NULL" is satisfied

    # Source step 0079: EQ||Vehicle Summary Auto Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-95a2-8dfa-adebc59bdc38
    When I click "btn_Loan" when "Loan != NULL" is satisfied
    When I click "btn_Leased" when "Lease != NULL" is satisfied
    When I click "btn_Own" when "Loan == NULL AND Lease == NULL" is satisfied
    When I select "Native_American_Register_NO" when "State == \"OK\"" is satisfied
    When I select "Anti_theft_Yes" when "AntiTheft != NULL AND State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\"" is satisfied
    When I click "IL_Category_1" when "AntiTheft != NULL AND State == \"IL\"" is satisfied
    When I click "CategoryI" when "State == \"NJ\" AND AntiTheft != NULL" is satisfied
    When I click "ActiveDisablingDevice" when "AntiTheft != NULL AND (State == \"NY\" OR State == \"VT\")" is satisfied
    When I select "Camper_Shell_No" when "PickUp != NULL AND (State == \"NY\" OR State = \"VA\")" is satisfied
    When I select "Business_Use_No"
    When I select "Not_Work_School"
    When I enter or select "3500" in "NY_FFCIC_total_annual_miles"
    When I enter or select "\"^{a}\"" in "Work_miles_day" when "State == \"NY\"" is satisfied
    When I enter or select "10" in "Work_miles_day" when "State == \"NY\"" is satisfied
    When I enter or select "\"^{a}\"" in "Non_work_annual_miles" when "State == \"NY\"" is satisfied
    When I enter or select "3500" in "Non_work_annual_miles" when "State == \"NY\"" is satisfied
    When I click "Pleasure_CA_NY_FFCIC" when "State == \"CA\"" is satisfied

    # Source step 0082: EQ||Vehicle Summary Auto Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-6791-46c6-6310caf1c65a
    When I select "Not_Work_School"
    When I select "Farm_No"
    When I enter or select "\"^{a}\"" in "NY_FFCIC_total_annual_miles" when "State == \"NY\" AND Company == \"FFCIC\"" is satisfied
    When I enter or select "8500" in "NY_FFCIC_total_annual_miles" when "State == \"NY\" AND Company == \"FFCIC\"" is satisfied
    When I enter or select "\"^{a}\"" in "Non_work_annual_miles" when "State == \"NY\"" is satisfied
    When I enter or select "8500" in "Non_work_annual_miles" when "State == \"NY\"" is satisfied
    When I select "Use_CA_More_Options" when "'Farm/Use' != NULL AND State == \"CA\"" is satisfied
    When I select "More_Options_Farm_Use" when "'Farm/Use' != NULL AND (State != \"NY\" and Company !=\"FFCIC\")" is satisfied
    When I enter or select "\"^{a}\"" in "txt_purchase_date"
    When I enter or select "10/10/2000" in "txt_purchase_date"
    When I enter or select "\"^{a}\"" in "txt_odometer"
    When I enter or select "60000" in "txt_odometer"

    # Source step 0083: EQ||Vehicle Summary Auto/Motor Home Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-9f5a-ca3a-bc6f332fa6c1
    # Runtime control: If Total Mileage exists > Condition
    Then if the source runtime condition "If Total Mileage exists > Condition" is satisfied, I wait until "txt_annual_mileage" exists

    # Source step 0084: EQ||Vehicle Summary Auto/Motor Home Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-4244-eb9a-8e8dddf39348
    # Runtime control: If Total Mileage exists > Then
    When if the source runtime condition "If Total Mileage exists > Then" is satisfied, I enter or select "\"^{a}\"" in "txt_annual_mileage"
    When I enter or select "8500" in "txt_annual_mileage"
    When I click "btnSave_Continue"

    # Source step 0085: EQ||Vehicle Summary Auto/Motor Home Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-dffa-fa21-a9ab72d88e73
    # Runtime control: If Total Mileage exists > Else
    When if the source runtime condition "If Total Mileage exists > Else" is satisfied, I click "btnSave_Continue"

    # Source step 0086: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-6cc3-587f-71fd73c3c725
    When I retain the unresolved source parameter "CA Verified Mileage" (not supplied by this reusable-block invocation) as runtime value "CA Verified Mileage"

    # Source step 0087: EQ || CA Verified Mileage | Module: EQ || CA Verified Mileage
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-238f-a7b4-2a286e1f49c2
    When I click "Opt Out" when "'CA Verified Mileage' != NULL" is satisfied

    # Source step 0088: EQ||Vehicle Summary Next/Add  | Module: EQ||Vehicle Summary Next/Add 
    # Section: Process > Auto > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-f187-acde-56dc1d77b564
    Then I wait until "btn_Next" exists
    When I click "btn_Next"

    # Source step 0089: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 06 Driver Assignment | Reusable flow: Auto | 06 EQ | Driver Assignment | Source XTestStep: 3a19dd55-d461-7750-f7a7-0a4dfad39166
    When I retain hard-coded value "2006 Dodge CHARGER" as runtime value "Driver 1 Vehicle"
    When I retain hard-coded value "Principal" as runtime value "Driver 1 Principal Occasional"
    When I retain the unresolved source parameter "Driver 2 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 2 Vehicle"
    When I retain the unresolved source parameter "Driver 2 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 2 Principal Occasional"
    When I retain the unresolved source parameter "Driver 3 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 3 Vehicle"
    When I retain the unresolved source parameter "Driver 3 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 3 Principal Occasional"
    When I retain the unresolved source parameter "Driver 4 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 4 Vehicle"
    When I retain the unresolved source parameter "Driver 4 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 4 Principal Occasional"
    When I retain the unresolved source parameter "Driver 5 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 5 Vehicle"
    When I retain the unresolved source parameter "Driver 5 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 5 Principal Occasional"

    # Source step 0090: (New) EQ || Multiple Driver Assignment_1 | Module: (New) EQ || Multiple Driver Assignment
    # Section: Process > Auto > 06 Driver Assignment | Reusable flow: Auto | 06 EQ | Driver Assignment | Source XTestStep: 3a1a05eb-9533-f275-7cff-93b1b2320a32
    When I click "Driver 1 Vehicle" when "'Driver 1 Vehicle' != NULL" is satisfied
    When I click "Driver 1 Principal Occasional" when "'Driver 1 Principal Occasional' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 2 Vehicle" when "'Driver 2 Vehicle' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 2 Principal Occasional" when "'Driver 2 Principal Occasional' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 3 Vehicle" when "'Driver 3 Vehicle' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 3 Principal Occasional" when "'Driver 3 Principal Occasional' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 4 Vehicle" when "'Driver 4 Vehicle' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 4 Principal Occasional" when "'Driver 4 Principal Occasional' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 5 Vehicle" when "'Driver 5 Vehicle' != NULL" is satisfied
    When I enter or select "{Scroll[1]}{Click}" in "Driver 5 Principal Occasional" when "'Driver 5 Principal Occasional' != NULL" is satisfied
    When I click "Next"

    # Source step 0091: (New) EQ || Multiple Driver Assignment | Module: (New) EQ || Multiple Driver Assignment
    # Section: Process > Auto > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-13fe-0bae-f875adaccc82
    # Runtime control: EQ || Driver Assignment Continue > Condition
    Then if the source runtime condition "EQ || Driver Assignment Continue > Condition" is satisfied, I wait until "CONTINUE" exists
    Then "CONTINUE" should exist

    # Source step 0092: (New) EQ || Multiple Driver Assignment | Module: (New) EQ || Multiple Driver Assignment
    # Section: Process > Auto > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-74dc-05e4-1fdd58dbded4
    # Runtime control: EQ || Driver Assignment Continue > Then
    When if the source runtime condition "EQ || Driver Assignment Continue > Then" is satisfied, I click "CONTINUE"

    # Source step 0093: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-2a08-4e77-dc5f8e298664
    Then I wait until "Loading ..." exists

    # Source step 0094: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-dbdc-de07-9701885dcfb3
    # Runtime control: Underwriting Popup Continue > Condition
    Then if the source runtime condition "Underwriting Popup Continue > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" exists
    Then "Lnk_UW_CONTINUE" should exist

    # Source step 0095: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a1a521c-5c8a-fca8-0a5b-3d76b7758fb5
    # Runtime control: Underwriting Popup Continue > Then
    When if the source runtime condition "Underwriting Popup Continue > Then" is satisfied, I click "Lnk_UW_CONTINUE"

    # Source step 0096: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a210b32-90a1-416a-2a4e-cbc545f7aa3e
    When I retain hard-coded value "0" as runtime value "ClaimCount"

    # Source step 0097: Check for claims/violations needing edited | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d47f-d1d7-d3bf-5a1ad619f1df
    # Runtime control: While Edits Needed [max=30] > Condition
    Then if the source runtime condition "While Edits Needed [max=30] > Condition" is satisfied, I wait until "Edit Claim" exists

    # Source step 0098: Edit Item(s) | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-7158-5c0a-399d668795c5
    # Runtime control: While Edits Needed [max=30] > Loop
    When if the source runtime condition "While Edits Needed [max=30] > Loop" is satisfied, I click "Edit Claim"

    # Source step 0099: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a210b35-8dc4-e60e-2416-dcad7c60432f
    # Runtime control: While Edits Needed [max=30] > Loop
    When if the source runtime condition "While Edits Needed [max=30] > Loop" is satisfied, I derive and retain the RUNTIME-DERIVED buffer expression "{MATH[{B[ClaimCount]}+1]}" as runtime value "ClaimCount"

    # Source step 0100: If Claim | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-46b4-de3f-77dc236897bf
    # Runtime control: While Edits Needed [max=30] > Loop > If > Condition
    Then if the source runtime condition "While Edits Needed [max=30] > Loop > If > Condition" is satisfied, "claimDriver Not In Household" should exist

    # Source step 0101: Edit Claim | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-2ced-a12b-73ef153ad085
    # Runtime control: While Edits Needed [max=30] > Loop > If > Then
    When if the source runtime condition "While Edits Needed [max=30] > Loop > If > Then" is satisfied, I enter or select "{End}{Click}" in "claimDriver Not In Household"
    When I select "claimVehicle loaned to driver that does not/did not reside in household and has no access to vehicle(s) insured by American National"
    When I click "claim/violationSave and Continue"

    # Source step 0102: Edit Violation | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-6b21-cc41-2d4710d17d54
    # Runtime control: While Edits Needed [max=30] > Loop > If > Else 
    When if the source runtime condition "While Edits Needed [max=30] > Loop > If > Else" is satisfied, I enter or select "AA - Administrative Action" in "ComboBox"
    When I select "claim/violationDoes Not Apply"
    When I click "claim/violationSave and Continue"

    # Source step 0103: Check for PopUp | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-1edd-baa9-884315c266f1
    # Runtime control: While Edits Needed [max=30] > Loop > If > Else  > If PopUp > Condition
    Then if the source runtime condition "While Edits Needed [max=30] > Loop > If > Else > If PopUp > Condition" is satisfied, "CONTINUE_Doesn'tApply" should exist

    # Source step 0104: Select Continue | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-86b1-017c-63ac39019295
    # Runtime control: While Edits Needed [max=30] > Loop > If > Else  > If PopUp > Then
    When if the source runtime condition "While Edits Needed [max=30] > Loop > If > Else > If PopUp > Then" is satisfied, I click "CONTINUE_Doesn'tApply"

    # Source step 0105: Next | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > Auto > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-1281-e07e-979d81b828f8
    When I click "Next"

    # Source step 0106: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-309c-daef-7f1e6adc660e
    Then I wait until "Loading ..." exists

    # Source step 0107: EQ||Discount - Rate Tier Questions | Module: EQ||Discount - Rate Tier Questions(NEW)
    # Section: Process > Auto > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-13e6-1b80-2723562372aa
    # Runtime control: State == "MD" OR State == "NJ"
    When if the source runtime condition "State == \"MD\" OR State == \"NJ\"" is satisfied, I enter or select "{end}{scroll[-2]}{Click}" in "Residentia_ Property_1"

    # Source step 0108: EQ||Discount - Rate Tier Questions | Module: EQ||Discount - Rate Tier Questions(NEW)
    # Section: Process > Auto > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-47c7-69bb-e9d363040925
    # Runtime control: If MD/NJ New Client > Condition
    When if the source runtime condition "If MD/NJ New Client > Condition" is satisfied, I click "Less than $30,000/$60,000" when "State == \"MD\"" is satisfied
    When I click "$15,000/$30,000" when "State == \"NJ\"" is satisfied

    # Source step 0110: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-f901-02fb-45a629220db2
    Then I wait until "Loading ..." exists

    # Source step 0111: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a1c89c6-be47-757e-f9da-b65e363f46bf
    When I retain the unresolved source parameter "Commercial Auto" (not supplied by this reusable-block invocation) as runtime value "Commercial Auto"
    When I retain the unresolved source parameter "Special Farm Package" (not supplied by this reusable-block invocation) as runtime value "Special Farm Package"
    When I retain the unresolved source parameter "Safe Cycle Discount" (not supplied by this reusable-block invocation) as runtime value "Safe Cycle Discount"
    When I retain the unresolved source parameter "Rider Group Discount" (not supplied by this reusable-block invocation) as runtime value "Rider Group Discount"

    # Source step 0112: EQ||Discount | Module: EQ||Discount(NEW)
    # Section: Process > Auto > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-b5be-0602-d50df53effaa
    Then "Multi-Car Discount" should exist when "'Multi-Car Discount' !=NULL" is satisfied
    When I enter or select "True" in "Multi-Car Discount > on"
    When I click "Rider Group Discount" when "'Rider Group Discount' != NULL" is satisfied
    Then "Commercial Auto" should exist when "'Commercial Auto' != NULL" is satisfied
    When I enter or select "True" in "Commercial Auto > on"
    Then "Special Farm Package" should exist when "'Special Farm Package' != NULL" is satisfied
    When I enter or select "True" in "Special Farm Package > on"
    When I click "Safe Cycle Discount" when "'Safe Cycle Discount' != NULL" is satisfied
    When I enter the unresolved source parameter "Safe Cycle Discount Date" (not supplied by this reusable-block invocation) in "Safe Cycle Discount Date"
    When I select "NoDefensiveDriverDiscount" when "State == \"DE\"" is satisfied
    Then I wait until "Next" is visible
    When I click "Next"

    # Source step 0113: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-df5b-2917-9300f04e4d69
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Loading ..." should exist

    # Source step 0114: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-0b9f-8bec-ef3f01ae1339
    # Runtime control: Do [max=30] > Loop > If > Condition
    Then if the source runtime condition "Do [max=30] > Loop > If > Condition" is satisfied, I wait until "Loading ..." exists

    # Source step 0115: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-0405-f757-fd79e257041e
    When I retain hard-coded value "OPTION 2" as runtime value "PolicyCovOption"
    When I retain the unresolved source parameter "V1_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V1_CompCollOnly"
    When I retain hard-coded value "500" as runtime value "V1_CompDed"
    When I retain the unresolved source parameter "V1_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V1_CompDedMoreOpt"
    When I retain hard-coded value "500" as runtime value "V1_CollDed"
    When I retain the unresolved source parameter "V1_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V1_CollDedMoreOpt"
    When I retain the unresolved source parameter "V2_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V2_CompCollOnly"
    When I retain the unresolved source parameter "V2_CompDed" (not supplied by this reusable-block invocation) as runtime value "V2_CompDed"
    When I retain the unresolved source parameter "V2_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V2_CompDedMoreOpt"
    When I retain the unresolved source parameter "V2_CollDed" (not supplied by this reusable-block invocation) as runtime value "V2_CollDed"
    When I retain the unresolved source parameter "V2_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V2_CollDedMoreOpt"
    When I retain the unresolved source parameter "V3_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V3_CompCollOnly"
    When I retain the unresolved source parameter "V3_CompDed" (not supplied by this reusable-block invocation) as runtime value "V3_CompDed"
    When I retain the unresolved source parameter "V3_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V3_CompDedMoreOpt"
    When I retain the unresolved source parameter "V3_CollDed" (not supplied by this reusable-block invocation) as runtime value "V3_CollDed"
    When I retain the unresolved source parameter "V3_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V3_CollDedMoreOpt"
    When I retain the unresolved source parameter "V4_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V4_CompCollOnly"
    When I retain the unresolved source parameter "V4_CompDed" (not supplied by this reusable-block invocation) as runtime value "V4_CompDed"
    When I retain the unresolved source parameter "V4_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V4_CompDedMoreOpt"
    When I retain the unresolved source parameter "V4_CollDed" (not supplied by this reusable-block invocation) as runtime value "V4_CollDed"
    When I retain the unresolved source parameter "V4_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V4_CollDedMoreOpt"
    When I retain the unresolved source parameter "CovOptUninsured" (not supplied by this reusable-block invocation) as runtime value "CovOptUninsured"
    When I retain the unresolved source parameter "Supplemental UM/UIM Opt In" (not supplied by this reusable-block invocation) as runtime value "Supplemental UM/UIM Opt In"
    When I retain the unresolved source parameter "Supplemental UM/UIM Cov" (not supplied by this reusable-block invocation) as runtime value "Supplemental UM/UIM Cov"

    # Source step 0116: Select Policy Coverage Option | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-5e9f-ebb3-1a192f211891
    When I enter or select "True" in "Option 1" when "PolicyCovOption == \"OPTION 1\"" is satisfied
    When I enter or select "True" in "Option 2" when "PolicyCovOption == \"OPTION 2\"" is satisfied
    When I enter or select "True" in "Option 3" when "PolicyCovOption == \"OPTION 3\"" is satisfied
    When I click "EDIT COVERAGE Opt 1" when "PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied
    When I click "EDIT COVERAGE Opt 2" when "PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied
    When I click "EDIT COVERAGE Opt 3" when "PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied

    # Source step 0117: Edit Coverage Option | Module: Edit Coverage Option (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-747f-5f68-a24a43e77133
    Then I wait until "Supplemental UM/UIM Opt In" exists when "'Supplemental UM/UIM Opt In' != NULL" is satisfied
    When I click "Supplemental UM/UIM Opt In" when "'Supplemental UM/UIM Opt In' != NULL" is satisfied
    When I click "Supplemental UM/UIM Cov" when "'Supplemental UM/UIM Opt In' == \"Yes\"" is satisfied
    Then I wait until "UM Coverage" exists when "CovOptUninsured != NULL" is satisfied
    When I click "UM Coverage" when "CovOptUninsured != NULL" is satisfied
    When I click "Save and Continue" when "CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL" is satisfied

    # Source step 0118: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-32f7-1e44-9a9fe0dd9489
    Then I wait until "Loading ..." exists

    # Source step 0119: Navigate down screen to V1 | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-3e28-b8c2-daa0d90c90cf
    When I enter or select "{scroll[5]}" in "Option 3"

    # Source step 0120: Select V1 Coverages | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c3-e0f6-3efb-694f-24775fc5daab
    When I select "V1_Comp/Coll Only - YES" when "V1_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V1_Comprehensive Only" is visible when "'V1_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V1_Comprehensive Only" when "'V1_Comprehensive Only' != NULL" is satisfied
    When I click "V1_ Comprehensive And Collision Only" when "'V1_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V1_Comprehensive Deductible" should be visible when "V1_CompDed != NULL" is satisfied
    When I click "V1_CompDed" when "V1_CompDed != NULL" is satisfied
    When I click "V1_CompDedMoreOpt" when "V1_CompDedMoreOpt != NULL" is satisfied
    When I click "V1_CollDed" when "V1_CollDed != NULL AND V1_CompDed != NoCoverage" is satisfied
    When I click "V1_CollDedMoreOpt" when "V1_CollDedMoreOpt != NULL" is satisfied

    # Source step 0121: Navigate down screen to V2 | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-3cfb-5615-691d-4c4a67bb0dbb
    When I enter or select "{scroll[8]}" in "Option 3"

    # Source step 0122: Select V2 Coverages | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c3-f19a-4442-63dd-29bc94d7f23f
    When I select "V2_Comp/Coll Only - YES" when "V2_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V2_Comprehensive Only" is visible when "'V2_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V2_Comprehensive Only" when "'V2_Comprehensive Only' != NULL" is satisfied
    When I click "V2_Comprehensive And Collision Only" when "'V2_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V2_Comprehensive Deductible" should be visible when "V2_CompDed != NULL" is satisfied
    When I click "V2_CompDed" when "V2_CompDed != NULL" is satisfied
    When I click "V2_CompDedMoreOpt" when "V2_CompDedMoreOpt != NULL" is satisfied
    When I click "V2_CollDed" when "V2_CollDed != NULL" is satisfied
    When I click "V2_CollDedMoreOpt" when "V2_CollDedMoreOpt != NULL" is satisfied

    # Source step 0123: Navigate down screen to V3 | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-52a4-fe82-3bb0-369449699a34
    When I enter or select "{end}{scroll[-4]}" in "Next"

    # Source step 0124: Select V3 Coverages | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c4-0473-3bb0-3efe-79d19dce2cb1
    When I select "V3_Comp/Coll Only - YES" when "V3_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V3_Comprehensive Only" is visible when "'V3_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V3_Comprehensive Only" when "'V3_Comprehensive Only' != NULL" is satisfied
    When I click "V3_Comprehensive And Collision Only" when "'V3_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V3_Comprehensive Deductible" should be visible when "V3_CompDed != NULL" is satisfied
    When I click "V3_CompDed" when "V3_CompDed != NULL" is satisfied
    When I click "V3_CompDedMoreOpt" when "V3_CompDedMoreOpt != NULL" is satisfied
    When I click "V3_CollDed" when "V3_CollDed != NULL" is satisfied
    When I click "V3_CollDedMoreOpt" when "V3_CollDedMoreOpt != NULL" is satisfied

    # Source step 0125: Navigate down screen to V4 | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-5e76-1997-a9d2-51a01da87768
    When I enter or select "{end}" in "Next"

    # Source step 0126: Select V4 Coverages | Module: Coverages (New)
    # Section: Process > Auto > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c4-0dd3-f974-c0cc-517e7c067a4f
    When I select "V4_Comp/Coll Only - YES" when "V4_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V4_Comprehensive Only" is visible when "'V4_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V4_Comprehensive Only" when "'V4_Comprehensive Only' != NULL" is satisfied
    When I click "V4_Comprehensive And Collision Only" when "'V4_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V4_Comprehensive Deductible" should be visible when "V4_CompDed != NULL" is satisfied
    When I click "V4_CompDed" when "V4_CompDed != NULL" is satisfied
    When I click "V4_CompDedMoreOpt" when "V4_CompDedMoreOpt != NULL" is satisfied
    When I click "V4_CollDed" when "V4_CollDed != NULL" is satisfied
    When I click "V4_CollDedMoreOpt" when "V4_CollDedMoreOpt != NULL" is satisfied
    When I click "Next"

    # Source step 0135: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.1 EQ | Auto_AddlCov Policy Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-9926-83e8-e1b36f088d6a
    When I retain the unresolved source parameter "Tort Option" (not supplied by this reusable-block invocation) as runtime value "Tort Option"
    When I retain the unresolved source parameter "Income Loss Coverage" (not supplied by this reusable-block invocation) as runtime value "Income Loss Coverage"
    When I retain the unresolved source parameter "UMPD" (not supplied by this reusable-block invocation) as runtime value "UMPD"
    When I retain the unresolved source parameter "UIMPD" (not supplied by this reusable-block invocation) as runtime value "UIMPD"
    When I retain hard-coded value "No Coverage" as runtime value "AD&D Coverage"
    When I retain the unresolved source parameter "Inc Liab Claims Fam Mem" (not supplied by this reusable-block invocation) as runtime value "Inc Liab Claims Fam Mem"
    When I retain the unresolved source parameter "Extraordinary Medical Benefit" (not supplied by this reusable-block invocation) as runtime value "Extraordinary Medical Benefit"

    # Source step 0136: EQ || Other Policy Coverages Section | Module: EQ || Other Policy Coverages Section (New)
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.1 EQ | Auto_AddlCov Policy Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-dfa9-eb55-3377c15e84f9
    Then I wait until "H1_Additional Coverages" exists
    When I enter or select "{home}x" in "Tort Option" when "'Tort Option' != NULL" is satisfied
    When I enter or select "{Home}x" in "Income Loss Coverage" when "'Income Loss Coverage' != NULL" is satisfied
    When I click "UMPD" when "UMPD != NULL" is satisfied
    When I click "UIMPD" when "UIMPD != NULL" is satisfied
    Then I wait until "AD&D Coverage" is enabled when "'AD&D Coverage' != NULL" is satisfied
    When I enter or select "{Click}{scroll[3]}" in "AD&D Coverage" when "'AD&D Coverage' != NULL" is satisfied
    When I click "AD&D_Driver1" when "'AD&D_Driver1' != NULL" is satisfied
    When I click "AD&D_Driver2" when "'AD&D_Driver2' != NULL" is satisfied
    When I click "AD&D_Driver3" when "'AD&D_Driver3' != NULL" is satisfied
    When I click "AD&D_Driver4" when "'AD&D_Driver4' != NULL" is satisfied
    When I click "AD&D_Driver5" when "'AD&D_Driver5' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver1" when "'Loss of Income Coverage_Driver1' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver2" when "'Loss of Income Coverage_Driver2' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver3" when "'Loss of Income Coverage_Driver3' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver4" when "'Loss of Income Coverage_Driver4' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver5" when "'Loss of Income Coverage_Driver5' != NULL" is satisfied
    When I click "Total Disability Coverage_Driver1" when "'Total Disability Coverage_Driver1' != NULL" is satisfied
    When I click "Inc Liability Claims of Family Members" when "'Inc Liab Claims Fam Mem' != NULL" is satisfied
    When I click "Extraordinary Medical Benefit" when "'Extraordinary Medical Benefit' != NULL" is satisfied
    When I select "Work_Loss_No" when "'Work Loss Coordination Of Benefits' != NULL" is satisfied

    # Source step 0137: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.2 EQ | Auto_AddlCov PIP (NEW) | Source XTestStep: 3a19dd55-d49d-2319-e8b1-e935b78ef386
    When I retain the unresolved source parameter "All HH Members 65 or Pension" (not supplied by this reusable-block invocation) as runtime value "All HH Members 65 or Pension"
    When I retain the unresolved source parameter "PIP Limit" (not supplied by this reusable-block invocation) as runtime value "PIP Limit"
    When I retain the unresolved source parameter "PIP Deductible" (not supplied by this reusable-block invocation) as runtime value "PIP Deductible"
    When I retain the unresolved source parameter "Additional PIP" (not supplied by this reusable-block invocation) as runtime value "Additional PIP"
    When I retain the unresolved source parameter "PIP Stacking" (not supplied by this reusable-block invocation) as runtime value "PIP Stacking"
    When I retain the unresolved source parameter "Extra PIP Option" (not supplied by this reusable-block invocation) as runtime value "Extra PIP Option"
    When I retain the unresolved source parameter "Auto Health Insurer" (not supplied by this reusable-block invocation) as runtime value "Auto Health Insurer"
    When I retain the unresolved source parameter "Medical Expense Elimination" (not supplied by this reusable-block invocation) as runtime value "Medical Expense Elimination"
    When I retain the unresolved source parameter "Work Loss Benefits" (not supplied by this reusable-block invocation) as runtime value "Work Loss Benefits"
    When I retain the unresolved source parameter "Broadened PIP" (not supplied by this reusable-block invocation) as runtime value "Broadened PIP"
    When I retain the unresolved source parameter "Additional Death Benefit" (not supplied by this reusable-block invocation) as runtime value "Additional Death Benefit"
    When I retain the unresolved source parameter "Waiver of Income Loss" (not supplied by this reusable-block invocation) as runtime value "Waiver of Income Loss"

    # Source step 0138: EQ || Personal Injury Protection Section  | Module: EQ || Personal Injury Protection Section (New)
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.2 EQ | Auto_AddlCov PIP (NEW) | Source XTestStep: 3a19dd55-d49d-5cf9-bd48-8bc37f54be1b
    When I click "Household members age 65 or receiving pension" when "'All HH Members 65 or Pension' != NULL" is satisfied
    When I click "PIP Limit" when "'PIP Limit' != NULL" is satisfied
    When I click "PIP Deductible" when "'PIP Deductible' != NULL" is satisfied
    When I click "Additional PIP" when "'Additional PIP' != NULL" is satisfied
    When I click "PIP Stacking" when "'PIP Stacking' != NULL" is satisfied
    When I select "Extra PIP Option" when "'Extra PIP Option' != NULL" is satisfied
    When I click "Auto Health Insurer" when "'Auto Health Insurer' != NULL" is satisfied
    When I click "Medical Expense Elimination" when "'Medical Expense Elimination' != NULL" is satisfied
    When I select "Work_Loss_No" when "'Work Loss Coordination Of Benefits' != NULL" is satisfied
    When I click "Broadened PIP" when "'Broadened PIP' != NULL" is satisfied
    When I click "Additional Death Benefit" when "'Additional Death Benefit' != NULL" is satisfied
    When I click "Waiver of Income Loss" when "'Waiver of Income Loss' != NULL" is satisfied

    # Source step 0139: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-03d7-fc05-9d8e00af290c
    When I retain the unresolved source parameter "UMPD/UIMPD_V1" (not supplied by this reusable-block invocation) as runtime value "UMPD/UIMPD_V1"
    When I retain the unresolved source parameter "UMPD Coverage_V1" (not supplied by this reusable-block invocation) as runtime value "UMPD Coverage_V1"
    When I retain the unresolved source parameter "UMPD More Options Coverages_V1" (not supplied by this reusable-block invocation) as runtime value "UMPD More Options Coverages_V1"
    When I retain the unresolved source parameter "UIMPD Coverage_V1" (not supplied by this reusable-block invocation) as runtime value "UIMPD Coverage_V1"
    When I retain the unresolved source parameter "Rental Reimbursement Coverage_V1" (not supplied by this reusable-block invocation) as runtime value "Rental Reimbursement Coverage_V1"
    When I retain the unresolved source parameter "Theft Deductible_V1" (not supplied by this reusable-block invocation) as runtime value "Theft Deductible_V1"
    When I retain hard-coded value "No Coverage" as runtime value "Roadside Assistance Coverage_V1"
    When I retain the unresolved source parameter "UMPD/UIMPD_V2" (not supplied by this reusable-block invocation) as runtime value "UMPD/UIMPD_V2"
    When I retain the unresolved source parameter "UMPD Coverage_V2" (not supplied by this reusable-block invocation) as runtime value "UMPD Coverage_V2"
    When I retain the unresolved source parameter "UMPD More Options Coverages_V2" (not supplied by this reusable-block invocation) as runtime value "UMPD More Options Coverages_V2"
    When I retain the unresolved source parameter "UIMPD Coverage_V2" (not supplied by this reusable-block invocation) as runtime value "UIMPD Coverage_V2"
    When I retain the unresolved source parameter "Rental Reimbursement Coverage_V2" (not supplied by this reusable-block invocation) as runtime value "Rental Reimbursement Coverage_V2"
    When I retain the unresolved source parameter "Theft Deductible_V2" (not supplied by this reusable-block invocation) as runtime value "Theft Deductible_V2"
    When I retain the unresolved source parameter "Roadside Assistance Coverage_V2" (not supplied by this reusable-block invocation) as runtime value "Roadside Assistance Coverage_V2"
    When I retain the unresolved source parameter "UMPD/UIMPD_V3" (not supplied by this reusable-block invocation) as runtime value "UMPD/UIMPD_V3"
    When I retain the unresolved source parameter "UMPD Coverage_V3" (not supplied by this reusable-block invocation) as runtime value "UMPD Coverage_V3"
    When I retain the unresolved source parameter "UMPD More Options Coverages_V3" (not supplied by this reusable-block invocation) as runtime value "UMPD More Options Coverages_V3"
    When I retain the unresolved source parameter "UIMPD Coverage_V3" (not supplied by this reusable-block invocation) as runtime value "UIMPD Coverage_V3"
    When I retain the unresolved source parameter "Rental Reimbursement Coverage_V3" (not supplied by this reusable-block invocation) as runtime value "Rental Reimbursement Coverage_V3"
    When I retain the unresolved source parameter "Theft Deductible_V3" (not supplied by this reusable-block invocation) as runtime value "Theft Deductible_V3"
    When I retain the unresolved source parameter "Roadside Assistance Coverage_V3" (not supplied by this reusable-block invocation) as runtime value "Roadside Assistance Coverage_V3"
    When I retain the unresolved source parameter "UMPD/UIMPD_V4" (not supplied by this reusable-block invocation) as runtime value "UMPD/UIMPD_V4"
    When I retain the unresolved source parameter "UMPD Coverage_V4" (not supplied by this reusable-block invocation) as runtime value "UMPD Coverage_V4"
    When I retain the unresolved source parameter "UMPD More Options Coverages_V4" (not supplied by this reusable-block invocation) as runtime value "UMPD More Options Coverages_V4"
    When I retain the unresolved source parameter "UIMPD Coverage_V4" (not supplied by this reusable-block invocation) as runtime value "UIMPD Coverage_V4"
    When I retain the unresolved source parameter "Rental Reimbursement Coverage_V4" (not supplied by this reusable-block invocation) as runtime value "Rental Reimbursement Coverage_V4"
    When I retain the unresolved source parameter "Theft Deductible_V4" (not supplied by this reusable-block invocation) as runtime value "Theft Deductible_V4"
    When I retain the unresolved source parameter "Roadside Assistance Coverage_V4" (not supplied by this reusable-block invocation) as runtime value "Roadside Assistance Coverage_V4"
    When I retain the unresolved source parameter "Cycle Accessories_V1" (not supplied by this reusable-block invocation) as runtime value "Cycle Accessories_V1"
    When I retain the unresolved source parameter "Original Parts_V1" (not supplied by this reusable-block invocation) as runtime value "Original Parts_V1"
    When I retain the unresolved source parameter "Cycle Accessories_V2" (not supplied by this reusable-block invocation) as runtime value "Cycle Accessories_V2"
    When I retain the unresolved source parameter "Original Parts_V2" (not supplied by this reusable-block invocation) as runtime value "Original Parts_V2"
    When I retain the unresolved source parameter "Cycle Accessories_V3" (not supplied by this reusable-block invocation) as runtime value "Cycle Accessories_V3"
    When I retain the unresolved source parameter "Original Parts_V3" (not supplied by this reusable-block invocation) as runtime value "Original Parts_V3"
    When I retain the unresolved source parameter "Cycle Accessories_V4" (not supplied by this reusable-block invocation) as runtime value "Cycle Accessories_V4"
    When I retain the unresolved source parameter "Original Parts_V4" (not supplied by this reusable-block invocation) as runtime value "Original Parts_V4"

    # Source step 0140: EQ || Vehicle Coverages Section | Module:  EQ || Vehicle Coverages Section
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-761f-6f46-c2b18955c6fe
    When I click "UMPD/UIMPD_V1" when "'UMPD/UIMPD_V1' != NULL" is satisfied
    When I enter or select "{Click}{scroll[2]}" in "UMPD Coverage_Vehicle1" when "'UMPD Coverage_V1' != NULL" is satisfied
    When I select "More Options List_V1 > UMPD More Options Coverages" when "'UMPD Coverage_V1' == \"MORE OPTIONS\"" is satisfied
    When I click "UIMPD Coverage_V1" when "'UIMPD Coverage_V1' != NULL" is satisfied
    When I enter or select "{Click}{scroll[4]}" in "Rental Reimbursement Coverage_V1" when "'Rental Reimbursement Coverage_V1' != NULL" is satisfied
    When I click "Theft Deductible_V1" when "'Theft Deductible_V1' != NULL" is satisfied
    When I enter or select "{Click}{Scroll[2]}" in "Roadside Assistance Coverage_V1" when "'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")" is satisfied
    When I click "UMPD/UIMPD_V2" when "'UMPD/UIMPD_V2' != NULL" is satisfied
    When I click "UMPD Coverage_Vehicle2" when "'UMPD Coverage_V2' != NULL" is satisfied
    When I select "More Options List_V2 > UMPD More Options Coverages" when "'UMPD Coverage_V2' == \"MORE OPTIONS\"" is satisfied
    When I click "UIMPD Coverage_V2" when "'UIMPD Coverage_V2' != NULL" is satisfied
    When I enter or select "{Click}{scroll[4]}" in "Rental Reimbursement Coverage_V2" when "'Rental Reimbursement Coverage_V2' != NULL" is satisfied
    When I click "Theft Deductible_V2" when "'Theft Deductible_V2' != NULL" is satisfied
    When I enter or select "{Click}{scroll[2]}" in "Roadside Assistance Coverage_V2" when "'Roadside Assistance Coverage_V2' != NULL" is satisfied
    When I select "No Coverage_V1_Towing" when "'Towing and Labor' != NULL" is satisfied
    When I click "UMPD/UIMPD_V3" when "'UMPD/UIMPD_V3' != NULL" is satisfied
    When I click "UMPD Coverage_Vehicle3" when "'UMPD Coverage_V3' != NULL" is satisfied
    When I select "More Options List_V3 > UMPD More Options Coverages" when "'UMPD Coverage_V3' == \"MORE OPTIONS\"" is satisfied
    When I click "UIMPD Coverage_V3" when "'UIMPD Coverage_V3' != NULL" is satisfied
    When I enter or select "{Click}{scroll[4]}" in "Rental Reimbursement Coverage_V3" when "'Rental Reimbursement Coverage_V3' != NULL" is satisfied
    When I click "Theft Deductible_V3" when "'Theft Deductible_V3' != NULL" is satisfied
    When I enter or select "{Click}{scroll[2]}" in "Roadside Assistance Coverage_V3" when "'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")" is satisfied
    When I click "Cycle Accessories_V3" when "'Cycle Accessories_V3' != NULL" is satisfied
    When I click "Original Parts_V3" when "'Original Parts_V3' != NULL" is satisfied
    When I click "UMPD/UIMPD_V4" when "'UMPD/UIMPD_V4' != NULL" is satisfied
    When I click "UMPD Coverage_Vehicle4" when "'UMPD Coverage_V4' != NULL" is satisfied
    When I select "More Options List_V4 > UMPD More Options Coverages" when "'UMPD Coverage_V4' == \"MORE OPTIONS\"" is satisfied
    When I click "UIMPD Coverage_V4" when "'UIMPD Coverage_V4' != NULL" is satisfied
    When I enter or select "{Click}{end}" in "Rental Reimbursement Coverage_V4" when "'Rental Reimbursement Coverage_V4' != NULL" is satisfied
    When I click "Theft Deductible_V4" when "'Theft Deductible_V4' != NULL" is satisfied
    When I click "Roadside Assistance Coverage_V4" when "'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")" is satisfied
    When I click "Cycle Accessories_V4" when "'Cycle Accessories_V4' != NULL" is satisfied
    When I click "Original Parts_V4" when "'Original Parts_V4' != NULL" is satisfied

    # Source step 0141: Additional Coverages Next | Module: EQ || Additional Coverages Next (New)
    # Section: Process > Auto > 10 Additional Coverage | Reusable flow: Auto | 10.4 EQ | Auto_AddlCov Next (NEW) | Source XTestStep: 3a19dd55-d49d-96a9-0aec-e6aed537490d
    When I click "Next"

    # Source step 0142: EQ || Pricing Details (New) | Module: EQ || Pricing Details (New)
    # Section: Process > Auto > 11 Pricing | Reusable flow: Auto | 11 EQ | Happy Path_Pricing Page  | Source XTestStep: 3a19dd55-d48e-d305-1d73-388985eda2c9
    Then I wait until "Header Pricing Details" exists
    When I click "Next"

    # Source step 0143: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 11 Pricing | Reusable flow: Auto | 11 EQ | Happy Path_Pricing Page  | Source XTestStep: 3a19dd55-d48e-d8c5-f9f6-869ea583e4c6
    Then I wait until "Loading ..." exists

    # Source step 0144: EQ | Underwriting Eligibility Restrictions | Module: EQ | Underwriting Eligibility Restrictions
    # Section: Process > Auto > 12 Underwriting > EQ | Underwriting Eligibility Restrictions | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-d1ef-8e82-01e2c1104d3f
    Then I wait until "Header Underwriting" exists
    When I select "Yes"
    When I enter or select "{Click}{end}" in "No"

    # Source step 0145: EQ | Underwriting Collector And Vintage Information | Module: EQ | Underwriting Collector And Vintage Information
    # Section: Process > Auto > 12 Underwriting > EQ | Underwriting Collector And Vintage Information | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-a37d-0993-113ea0e74500
    # Runtime control: EQ | Underwriting Collector And Vintage Information > Condition
    Then if the source runtime condition "EQ | Underwriting Collector And Vintage Information > Condition" is satisfied, I wait until "Are all collector vehicles kept in a fully enclosed and locked structure?" is visible

    # Source step 0146: EQ | Underwriting Collector And Vintage Information | Module: EQ | Underwriting Collector And Vintage Information
    # Section: Process > Auto > 12 Underwriting > EQ | Underwriting Collector And Vintage Information | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-ef81-543f-210923711451
    # Runtime control: EQ | Underwriting Collector And Vintage Information > Then
    When if the source runtime condition "EQ | Underwriting Collector And Vintage Information > Then" is satisfied, I select "Yes"

    # Source step 0147: EQ | Underwriting Underwriting Next | Module: EQ | Underwriting Underwriting Next
    # Section: Process > Auto > 12 Underwriting | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-9e3c-e2f0-4fa80c4245ab
    When I click "Next"

    # Source step 0148: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 12 Underwriting | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a1b01b4-37fa-c628-2432-74737edb16f7
    When I perform the source-defined operation "EQ |Common|Loading Indicator Wait" in module "EQ |Common|Loading Indicator Wait"

    # Source step 0149: AdditionalInterest | Module: EQ || AdditionalInterest
    # Section: Process > Auto > 13 Additional Interest | Reusable flow: Auto | 13 EQ | Additional Interest Page | Source XTestStep: 3a19dd55-d4bb-a454-ca62-5a4cc15f71f7
    When I click "Next"

    # Source step 0150: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Auto > 13 Additional Interest | Reusable flow: Auto | 13 EQ | Additional Interest Page | Source XTestStep: 3a1b0169-7a5f-2a20-be85-cc3814410f19
    When I perform the source-defined operation "EQ |Common|Loading Indicator Wait" in module "EQ |Common|Loading Indicator Wait"

    # Source step 0151: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Auto > 14 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0156: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-678d-35f1-44cb42bd42a1
    # Runtime control: If Correction Needed > Condition Correction Needed Visible
    Then if the source runtime condition "If Correction Needed > Condition Correction Needed Visible" is satisfied, "Correction Needed Step 1" should exist

    # Source step 0157: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-78eb-7e86-0c69593dd72b
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "SaveExit_1"

    # Source step 0158: OpenUrl | Module: OpenUrl
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0162: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0163: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0164: EU||Home | Module: EU||Home
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0165: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0166: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "Lnk_Pricing"

    # Source step 0167: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0168: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Condition
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0169: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Then
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0172: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I close the active browser

    # Source step 0173: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-3597-854a-48cd2f94a920
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0174: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-4570-5e7e-f6661e969808
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "DIV_Submission"

    # Source step 0211: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-5fda-b2fb-7d9202bb7c40
    Then I wait until "Submission_1" exists

    # Source step 0212: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-0405-6aeb-e03a8a879562
    # Runtime control: While Comments  [max=10] > Condition
    Then if the source runtime condition "While Comments [max=10] > Condition" is satisfied, "Comments" should exist

    # Source step 0213: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission > Comments | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-24d4-58ea-b3b007866a02
    # Runtime control: While Comments  [max=10] > Loop > If > Condition
    Then if the source runtime condition "While Comments [max=10] > Loop > If > Condition" is satisfied, "Comments" should exist

    # Source step 0214: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission > Comments | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-fc27-ff5e-eddbf892e12e
    # Runtime control: While Comments  [max=10] > Loop > If > Then
    When if the source runtime condition "While Comments [max=10] > Loop > If > Then" is satisfied, I enter or select "\"Test\"" in "Comments"

    # Source step 0215: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-df70-4c5e-bc47d782b4cd
    # Runtime control: If Referral Button  > Condition
    Then if the source runtime condition "If Referral Button > Condition" is satisfied, "ReferUW" should be visible

    # Source step 0216: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-5e68-6b54-41c4c6120974
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "ReferUW"
    When I click "SaveExit_1"

    # Source step 0234: EQ || OpenUrl | Module: EQ || OpenUrl
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > Open URL | Source XTestStep: 3a1abacb-9c11-d635-aec9-d96efada9152
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0235: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1da9bf-638d-557b-2d67-5eca96520ce5
    # Runtime control: If Referral Button  > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If Referral Button > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0236: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1da9bf-639c-e3a7-4507-e7e068e6b07c
    # Runtime control: If Referral Button  > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If Referral Button > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0237: EU||Home | Module: EU||Home
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-17af-eac2-efc85049f006
    # Runtime control: If Referral Button  > Then
    Then if the source runtime condition "If Referral Button > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0238: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-776f-690b-c57137d617c8
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "Policy/Quote#"

    # Source step 0239: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-dd12-e647-1b7133cb86df
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0240: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-df28-5b9a-9aa2498a2226
    # Runtime control: If Referral Button  > Then
    Then if the source runtime condition "If Referral Button > Then" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Click}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    Then I wait until "Btn_Approve" is visible
    When I click "Btn_Approve"
    When I click "Lnk_Home"

    # Source step 0241: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-3187-745d-aac57504448a
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I close the active browser

    # Source step 0242: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > EQ | Recall Quote in EQ | Source XTestStep: 3a1d37b5-c754-fa99-186e-4cdf3e363d8c
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0243: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > EQ | Recall Quote in EQ | Source XTestStep: 3a1d37b5-c766-2435-d5f0-9d921f232fa6
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "DIV_Submission"

    # Source step 0247: OpenUrl | Module: OpenUrl
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0251: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0252: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0253: EU||Home | Module: EU||Home
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    Then I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0254: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    When I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0255: EU||Applicant | Module: EU||Applicant
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    When I click "Lnk_Pricing"

    # Source step 0256: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    When I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0257: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Level 9 exists > Condition
    Then if the source runtime condition "If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0258: EU||Pricing | Module: EU||Pricing
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Level 9 exists > Then
    When if the source runtime condition "If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0261: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    When I close the active browser

    # Source step 0262: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ| Express UW Review | Source XTestStep: 3a19e1e5-0cbf-1406-4bee-4dcaac1e1669
    When I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0263: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Auto > 15 Submission | Reusable flow: Auto | 15 EQ| Express UW Review | Source XTestStep: 3a19e1e5-0cbf-0464-b4c5-e67a9197d671
    When I click "DIV_Submission"

    # Source step 0264: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-3e09-b878-6e62408fbd61
    When I click "Checklist_1"

    # Source step 0265: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Auto > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-4353-149b-daba614be6e5
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0266: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Auto > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-c17f-736a-d3c52a1c9db4
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0267: TBox Save As | Module: TBox Save As
    # Section: Process > Auto > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-aacd-b5ac-657e4832e6f3
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0268: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Auto > 16 Launch Checklist > EU||Uploading_Docs | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-b8d9-b16b-057f5a30b083
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0270: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Auto > 16 Launch Checklist > EU||Uploading_Docs | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-fa06-d749-6feed4b2eadb
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0271: CloseBrowser | Module: CloseBrowser
    # Section: Process > Auto > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-7326-8d73-7c7fc0692bd4
    When I close the active browser

    # Source step 0272: EQ|| Checklist Close | Module: EQ|| Checklist Close
    # Section: Process > Auto > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-df50-487a-983ad17c1dff
    When I click "Btn_Ok"

    # Source step 0273: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Auto > TDS Validations | Reusable flow: Auto | 17 EQ | Transmit | Source XTestStep: 3a19dd55-d48e-82a4-34a0-f9472b13da42
    Then I wait until "Transmit" exists
    When I click "Transmit"

    # Source step 0274: Click on policy History | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 01 Recall Quote | Reusable flow: <none> | Source XTestStep: 3a1a521c-5ca9-3e8d-83e0-26bfd69f1c08
    When I click "Policy History"
    When I use source configuration "Vehicle Summary" = "AL" for "Click on policy History"
    When I use source configuration "Coverages" = "Happy Path Auto 1V1D" for "Click on policy History"

    # Source step 0275: EQ||Quick Actions | Module: EQ||Quick Actions
    # Section: Process > Recreational Policy > 01 Recall Quote | Reusable flow: <none> | Source XTestStep: 3a1a521c-5cb9-cf71-22cc-f2c7357c24d1
    When I click "Btn_QUOTE ACTIONS"
    When I click "Btn_New Quote Same Client"

    # Source step 0276: TBox Set Effective Date Buffer | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e7b-a6e5-7d00-f0c2-4760e71faa97
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{Date[{DATE}][][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0277: Navigate to top of screen | Module: EQ || Proposal Details/Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a20cd02-ca9e-8963-fbb2-ee430e14bbf7
    When I enter or select "{Scroll[-2]}" in "EffectiveDate"

    # Source step 0278: Proposal Details/Start | Module: EQ || Proposal Details/Start
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-b4d0-23a9-de44036bc990
    When I click "Personal Auto" when "LOB == \"PersonalAuto\"" is satisfied
    When I click "Motorcycle" when "LOB == \"Cycle\"" is satisfied
    When I click "Recreational Vehicle" when "LOB == \"RecreationalVehicle\"" is satisfied
    When I enter captured runtime value "EffectiveDate" in "EffectiveDate" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "D2102" in "AgentCode" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "AgentCode" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I press "Tab" while focused on "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "State" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "State Name"
    When I press "Tab" while focused on "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I select "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "American National Property And Casualty Co." in "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    When I enter or select "" in "WritingCompany" when "LOB != \"RecreationalVehicle\"" is satisfied
    Then I wait until "SameAsMailingAddress" is enabled
    When I enter or select "{Click}" in "SameAsMailingAddress"
    When I enter the unresolved source parameter "County Name" (not supplied by this reusable-block invocation) in "County_ComboBox" when "'County Name' != NULL" is satisfied
    Then I wait until "Start Quote" is visible
    When I click "Start Quote"

    # Source step 0282: Invalid Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-16d8-9e02-3881cfde7fcf
    # Runtime control: If Invalid Address Pops Up > Condition
    Then if the source runtime condition "If Invalid Address Pops Up > Condition" is satisfied, "Lnk_PROCEED" should exist

    # Source step 0283: Proceed with Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-a1cf-236e-50b5851b652b
    # Runtime control: If Invalid Address Pops Up > Then
    When if the source runtime condition "If Invalid Address Pops Up > Then" is satisfied, I click "Lnk_PROCEED"

    # Source step 0284: Confirm SSN? | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-b90f-dc8e-fc482b757001
    # Runtime control: If SSN Pop Up Confirm Exist  > Condition
    Then if the source runtime condition "If SSN Pop Up Confirm Exist > Condition" is satisfied, "Lnk_CONFIRM" should exist

    # Source step 0285: Select Confirm | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-db7a-eaec-fc221ebe2f9e
    # Runtime control: If SSN Pop Up Confirm Exist  > Then
    When if the source runtime condition "If SSN Pop Up Confirm Exist > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0286: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-1eba-4b97-bb6837e42931
    # Runtime control: If SSN Pop Up Confirm Exist  > Else > If SSN Pops Up > Condition
    Then if the source runtime condition "If SSN Pop Up Confirm Exist > Else > If SSN Pops Up > Condition" is satisfied, "Txt_SSN" should exist
    Then "Lnk_SUBMIT" should exist

    # Source step 0287: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-f7eb-36e8-124cfd68f528
    # Runtime control: If SSN Pop Up Confirm Exist  > Else > If SSN Pops Up > Then
    When if the source runtime condition "If SSN Pop Up Confirm Exist > Else > If SSN Pops Up > Then" is satisfied, I enter the RUNTIME-DERIVED TDM value "AL_ClientData.SSN" in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0288: Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-e9ec-339f-d59f7f5b9ce8
    # Runtime control: If Existing Client Pops Up > Condition
    Then if the source runtime condition "If Existing Client Pops Up > Condition" is satisfied, "Client Already Exists" should exist

    # Source step 0289: Select Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > Recreational Policy > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-96a1-6ec5-4c64d135a412
    # Runtime control: If Existing Client Pops Up > Then
    When if the source runtime condition "If Existing Client Pops Up > Then" is satisfied, I click "Lnk_CREATE NEW ACCOUNT"

    # Source step 0290: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > Recreational Policy > 03 Pre-Qualification > 03 EQ | Auto - Pre-Qualification | Reusable flow: Auto | 03 EQ | Pre-Qualification (New) | Source XTestStep: 3a19dd55-d425-4b84-160d-b4880cf2b369
    When I enter or select "{CLICK}" in "Btn_Chk box_check_boxNone Of The Above"
    When I enter or select "{CLICK}" in "Btn_Next"

    # Source step 0291: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number (NEW) | Source XTestStep: 3a19e1e5-0ccf-9e28-e149-a517d2513110
    When I capture "InnerText" from "Quote Number" as runtime value "QuoteNum"

    # Source step 0292: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number (NEW) | Source XTestStep: 3a19e1e5-0ccf-9957-49f2-159235c7eb66
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}" as runtime value "QNum"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0293: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ -  Driver Information | Source XTestStep: 3a19dd55-d470-eb81-cece-a5f2c7b44eb9
    When I click "(Existing Client)_1"
    When I enter or select "{Click}" in "Btn_Next"

    # Source step 0294: RVHappyDriver | Module: RVHappyDriver
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: RV || Driver Summary Happy | Source XTestStep: 3a19e1e5-0ccf-7e07-50cd-1fc56bce1dd9
    Then I wait until "H1_Driver Summary" exists
    When I click "Primary Named Insured" when "'Named insured? ' == \"Primary Named Insured\"" is satisfied
    When I click "Named Insured" when "'Named insured? ' == \"Named Insured\"" is satisfied
    When I select "Not a Named Insured" when "'Named insured? ' == \"Not Named Insured\"" is satisfied
    When I click "Excluded" when "'Operator Status' == \"Excluded\"" is satisfied
    When I enter the unresolved source parameter "License State" (not supplied by this reusable-block invocation) in "License State" when "'License State' != NULL" is satisfied
    When I enter the unresolved source parameter "License Number" (not supplied by this reusable-block invocation) in "License Number" when "'License Number' != NULL" is satisfied
    When I enter or select "\"^{a}\"" in "Years Licensed Current State" when "'Rating State' == \"NY\"" is satisfied
    When I enter or select "3" in "Years Licensed Current State" when "'Rating State' == \"NY\"" is satisfied
    When I enter or select "0" in "DaysOperatedUninsured" when "'Rating State' == \"TX\"" is satisfied
    When I click "Save and Continue"

    # Source step 0295: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-2bb8-d44c-bdda6126ad5c
    # Runtime control: 'Additional Drivers?' == "Yes"
    When if the source runtime condition "'Additional Drivers?' == \"Yes\"" is satisfied, I click "Driver Information"

    # Source step 0296: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-0828-ff66-1a82bd960ba2
    # Runtime control: If > Condition
    Then if the source runtime condition "If > Condition" is satisfied, I wait until "PrefilledDrivers" exists

    # Source step 0297: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-53ca-a517-f012a38d9d89
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I capture "ResultCount" from "PrefilledDrivers" as runtime value "NumberOfDrivers"

    # Source step 0298: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Recreational Policy > 04 Driver Information > Repetition | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-955b-09d6-d7a8d79d80e7
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I enter or select "" in "MAT-FORM-FIELD"
    When I enter or select "{return}" in "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)"

    # Source step 0299: Save & Continue | Module: EQ || Prefil Household Drivers
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-50c3-bf38-2ef127c8f25e
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I click "Save and Continue"

    # Source step 0300: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-391c-4683-2363a242b3c9
    # Runtime control: If > Else > If > Condition
    Then if the source runtime condition "If > Else > If > Condition" is satisfied, "Unselected Client Suggestions" should exist

    # Source step 0301: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > Recreational Policy > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-c21c-d3f6-8683943ddec0
    # Runtime control: If > Else > If > Then
    When if the source runtime condition "If > Else > If > Then" is satisfied, I click "Save and Continue"

    # Source step 0302: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-6e8e-dc95-4ade758ab6aa
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected" is satisfied, "btn_select vehicle1" should exist

    # Source step 0303: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-963b-5665-fed0872e34d2
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I wait until "Loading ..." exists

    # Source step 0304: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-a31a-cb1f-2f0f39344681
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I click "Btn_Additional Vehicle"
    When I click "Btn_Next"

    # Source step 0305: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-f7a2-75d0-c298cb3735ee
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I wait until "Loading ..." exists

    # Source step 0306: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ | Vehicle Summary Happy Path RV | Source XTestStep: 3a19dd55-d49d-f3c1-c852-ec0e418740cc
    # Runtime control: Vehicles prefilled > Condition
    Then if the source runtime condition "Vehicles prefilled > Condition" is satisfied, I wait until "Btn_Additional Vehicle" is visible

    # Source step 0307: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ | Vehicle Summary Happy Path RV | Source XTestStep: 3a19dd55-d49d-585c-278c-f24df4561a41
    # Runtime control: Vehicles prefilled > Then
    When if the source runtime condition "Vehicles prefilled > Then" is satisfied, I click "Btn_Additional Vehicle"
    When I click "Btn_Next"

    # Source step 0308: EQ||RV | Module: EQ||Vehicle RV/Travel Trailer
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ | Vehicle Summary Happy Path RV | Source XTestStep: 3a19dd55-d4ac-09a3-f0df-1df0f027e76e
    Then I wait until "VIN" is enabled
    When I click "VIN"
    When I enter or select "JY4AJ20Y36C015410" in "VIN"
    When I press "Tab" while focused on "VIN"
    Then I wait until "Vehicle1" is enabled
    When I click "Vehicle1"
    When I select "Road_No"
    When I select "racing_no"
    When I enter or select "50" in "Displacement"
    When I click "Own"
    When I select "Native_No" when "State == \"OK\"" is satisfied
    When I select "modifications_No"
    When I click "Save and Continue"

    # Source step 0309: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-6cc3-587f-71fd73c3c725
    When I retain the unresolved source parameter "CA Verified Mileage" (not supplied by this reusable-block invocation) as runtime value "CA Verified Mileage"

    # Source step 0310: EQ || CA Verified Mileage | Module: EQ || CA Verified Mileage
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-238f-a7b4-2a286e1f49c2
    When I click "Opt Out" when "'CA Verified Mileage' != NULL" is satisfied

    # Source step 0311: EQ||Vehicle Summary Next/Add  | Module: EQ||Vehicle Summary Next/Add 
    # Section: Process > Recreational Policy > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-f187-acde-56dc1d77b564
    Then I wait until "btn_Next" exists
    When I click "btn_Next"

    # Source step 0312: EQ||Claims\Violations_New | Module: EQ||Claims\Violations
    # Section: Process > Recreational Policy > 07 Claims & Violations | Reusable flow: <none> | Source XTestStep: 3a1a521c-5ce8-421d-a361-6d8df654ff09
    When I click "Btn_Next"

    # Source step 0313: EQ||Discounts_New | Module: EQ||Discounts\Adjustments
    # Section: Process > Recreational Policy > 08 Discounts | Reusable flow: <none> | Source XTestStep: 3a1a521c-5ce8-ff52-6d69-8fe7c632525f
    When I click "Btn_Next"

    # Source step 0314: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-df5b-2917-9300f04e4d69
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Loading ..." should exist

    # Source step 0315: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-0b9f-8bec-ef3f01ae1339
    # Runtime control: Do [max=30] > Loop > If > Condition
    Then if the source runtime condition "Do [max=30] > Loop > If > Condition" is satisfied, I wait until "Loading ..." exists

    # Source step 0316: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-0405-f757-fd79e257041e
    When I retain hard-coded value "OPTION 2" as runtime value "PolicyCovOption"
    When I retain the unresolved source parameter "V1_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V1_CompCollOnly"
    When I retain hard-coded value "500" as runtime value "V1_CompDed"
    When I retain the unresolved source parameter "V1_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V1_CompDedMoreOpt"
    When I retain hard-coded value "500" as runtime value "V1_CollDed"
    When I retain the unresolved source parameter "V1_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V1_CollDedMoreOpt"
    When I retain the unresolved source parameter "V2_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V2_CompCollOnly"
    When I retain the unresolved source parameter "V2_CompDed" (not supplied by this reusable-block invocation) as runtime value "V2_CompDed"
    When I retain the unresolved source parameter "V2_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V2_CompDedMoreOpt"
    When I retain the unresolved source parameter "V2_CollDed" (not supplied by this reusable-block invocation) as runtime value "V2_CollDed"
    When I retain the unresolved source parameter "V2_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V2_CollDedMoreOpt"
    When I retain the unresolved source parameter "V3_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V3_CompCollOnly"
    When I retain the unresolved source parameter "V3_CompDed" (not supplied by this reusable-block invocation) as runtime value "V3_CompDed"
    When I retain the unresolved source parameter "V3_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V3_CompDedMoreOpt"
    When I retain the unresolved source parameter "V3_CollDed" (not supplied by this reusable-block invocation) as runtime value "V3_CollDed"
    When I retain the unresolved source parameter "V3_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V3_CollDedMoreOpt"
    When I retain the unresolved source parameter "V4_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V4_CompCollOnly"
    When I retain the unresolved source parameter "V4_CompDed" (not supplied by this reusable-block invocation) as runtime value "V4_CompDed"
    When I retain the unresolved source parameter "V4_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V4_CompDedMoreOpt"
    When I retain the unresolved source parameter "V4_CollDed" (not supplied by this reusable-block invocation) as runtime value "V4_CollDed"
    When I retain the unresolved source parameter "V4_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V4_CollDedMoreOpt"
    When I retain the unresolved source parameter "CovOptUninsured" (not supplied by this reusable-block invocation) as runtime value "CovOptUninsured"
    When I retain the unresolved source parameter "Supplemental UM/UIM Opt In" (not supplied by this reusable-block invocation) as runtime value "Supplemental UM/UIM Opt In"
    When I retain the unresolved source parameter "Supplemental UM/UIM Cov" (not supplied by this reusable-block invocation) as runtime value "Supplemental UM/UIM Cov"

    # Source step 0317: Select Policy Coverage Option | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-5e9f-ebb3-1a192f211891
    When I enter or select "True" in "Option 1" when "PolicyCovOption == \"OPTION 1\"" is satisfied
    When I enter or select "True" in "Option 2" when "PolicyCovOption == \"OPTION 2\"" is satisfied
    When I enter or select "True" in "Option 3" when "PolicyCovOption == \"OPTION 3\"" is satisfied
    When I click "EDIT COVERAGE Opt 1" when "PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied
    When I click "EDIT COVERAGE Opt 2" when "PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied
    When I click "EDIT COVERAGE Opt 3" when "PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied

    # Source step 0318: Edit Coverage Option | Module: Edit Coverage Option (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-747f-5f68-a24a43e77133
    Then I wait until "Supplemental UM/UIM Opt In" exists when "'Supplemental UM/UIM Opt In' != NULL" is satisfied
    When I click "Supplemental UM/UIM Opt In" when "'Supplemental UM/UIM Opt In' != NULL" is satisfied
    When I click "Supplemental UM/UIM Cov" when "'Supplemental UM/UIM Opt In' == \"Yes\"" is satisfied
    Then I wait until "UM Coverage" exists when "CovOptUninsured != NULL" is satisfied
    When I click "UM Coverage" when "CovOptUninsured != NULL" is satisfied
    When I click "Save and Continue" when "CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL" is satisfied

    # Source step 0319: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-32f7-1e44-9a9fe0dd9489
    Then I wait until "Loading ..." exists

    # Source step 0320: Navigate down screen to V1 | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-3e28-b8c2-daa0d90c90cf
    When I enter or select "{scroll[5]}" in "Option 3"

    # Source step 0321: Select V1 Coverages | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c3-e0f6-3efb-694f-24775fc5daab
    When I select "V1_Comp/Coll Only - YES" when "V1_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V1_Comprehensive Only" is visible when "'V1_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V1_Comprehensive Only" when "'V1_Comprehensive Only' != NULL" is satisfied
    When I click "V1_ Comprehensive And Collision Only" when "'V1_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V1_Comprehensive Deductible" should be visible when "V1_CompDed != NULL" is satisfied
    When I click "V1_CompDed" when "V1_CompDed != NULL" is satisfied
    When I click "V1_CompDedMoreOpt" when "V1_CompDedMoreOpt != NULL" is satisfied
    When I click "V1_CollDed" when "V1_CollDed != NULL AND V1_CompDed != NoCoverage" is satisfied
    When I click "V1_CollDedMoreOpt" when "V1_CollDedMoreOpt != NULL" is satisfied

    # Source step 0322: Navigate down screen to V2 | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-3cfb-5615-691d-4c4a67bb0dbb
    When I enter or select "{scroll[8]}" in "Option 3"

    # Source step 0323: Select V2 Coverages | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c3-f19a-4442-63dd-29bc94d7f23f
    When I select "V2_Comp/Coll Only - YES" when "V2_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V2_Comprehensive Only" is visible when "'V2_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V2_Comprehensive Only" when "'V2_Comprehensive Only' != NULL" is satisfied
    When I click "V2_Comprehensive And Collision Only" when "'V2_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V2_Comprehensive Deductible" should be visible when "V2_CompDed != NULL" is satisfied
    When I click "V2_CompDed" when "V2_CompDed != NULL" is satisfied
    When I click "V2_CompDedMoreOpt" when "V2_CompDedMoreOpt != NULL" is satisfied
    When I click "V2_CollDed" when "V2_CollDed != NULL" is satisfied
    When I click "V2_CollDedMoreOpt" when "V2_CollDedMoreOpt != NULL" is satisfied

    # Source step 0324: Navigate down screen to V3 | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-52a4-fe82-3bb0-369449699a34
    When I enter or select "{end}{scroll[-4]}" in "Next"

    # Source step 0325: Select V3 Coverages | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c4-0473-3bb0-3efe-79d19dce2cb1
    When I select "V3_Comp/Coll Only - YES" when "V3_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V3_Comprehensive Only" is visible when "'V3_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V3_Comprehensive Only" when "'V3_Comprehensive Only' != NULL" is satisfied
    When I click "V3_Comprehensive And Collision Only" when "'V3_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V3_Comprehensive Deductible" should be visible when "V3_CompDed != NULL" is satisfied
    When I click "V3_CompDed" when "V3_CompDed != NULL" is satisfied
    When I click "V3_CompDedMoreOpt" when "V3_CompDedMoreOpt != NULL" is satisfied
    When I click "V3_CollDed" when "V3_CollDed != NULL" is satisfied
    When I click "V3_CollDedMoreOpt" when "V3_CollDedMoreOpt != NULL" is satisfied

    # Source step 0326: Navigate down screen to V4 | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-5e76-1997-a9d2-51a01da87768
    When I enter or select "{end}" in "Next"

    # Source step 0327: Select V4 Coverages | Module: Coverages (New)
    # Section: Process > Recreational Policy > 09 Coverage | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c4-0dd3-f974-c0cc-517e7c067a4f
    When I select "V4_Comp/Coll Only - YES" when "V4_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V4_Comprehensive Only" is visible when "'V4_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V4_Comprehensive Only" when "'V4_Comprehensive Only' != NULL" is satisfied
    When I click "V4_Comprehensive And Collision Only" when "'V4_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V4_Comprehensive Deductible" should be visible when "V4_CompDed != NULL" is satisfied
    When I click "V4_CompDed" when "V4_CompDed != NULL" is satisfied
    When I click "V4_CompDedMoreOpt" when "V4_CompDedMoreOpt != NULL" is satisfied
    When I click "V4_CollDed" when "V4_CollDed != NULL" is satisfied
    When I click "V4_CollDedMoreOpt" when "V4_CollDedMoreOpt != NULL" is satisfied
    When I click "Next"

    # Source step 0336: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > 10 Additional Coverages | Reusable flow: Auto | 10.1 EQ | Auto_AddlCov Policy Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-9926-83e8-e1b36f088d6a
    When I retain the unresolved source parameter "Tort Option" (not supplied by this reusable-block invocation) as runtime value "Tort Option"
    When I retain the unresolved source parameter "Income Loss Coverage" (not supplied by this reusable-block invocation) as runtime value "Income Loss Coverage"
    When I retain the unresolved source parameter "UMPD" (not supplied by this reusable-block invocation) as runtime value "UMPD"
    When I retain the unresolved source parameter "UIMPD" (not supplied by this reusable-block invocation) as runtime value "UIMPD"
    When I retain the unresolved source parameter "AD&D Coverage" (not supplied by this reusable-block invocation) as runtime value "AD&D Coverage"
    When I retain the unresolved source parameter "Inc Liab Claims Fam Mem" (not supplied by this reusable-block invocation) as runtime value "Inc Liab Claims Fam Mem"
    When I retain the unresolved source parameter "Extraordinary Medical Benefit" (not supplied by this reusable-block invocation) as runtime value "Extraordinary Medical Benefit"

    # Source step 0337: EQ || Other Policy Coverages Section | Module: EQ || Other Policy Coverages Section (New)
    # Section: Process > Recreational Policy > 10 Additional Coverages | Reusable flow: Auto | 10.1 EQ | Auto_AddlCov Policy Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-dfa9-eb55-3377c15e84f9
    Then I wait until "H1_Additional Coverages" exists
    When I enter or select "{home}x" in "Tort Option" when "'Tort Option' != NULL" is satisfied
    When I enter or select "{Home}x" in "Income Loss Coverage" when "'Income Loss Coverage' != NULL" is satisfied
    When I click "UMPD" when "UMPD != NULL" is satisfied
    When I click "UIMPD" when "UIMPD != NULL" is satisfied
    Then I wait until "AD&D Coverage" is enabled when "'AD&D Coverage' != NULL" is satisfied
    When I enter or select "{Click}{scroll[3]}" in "AD&D Coverage" when "'AD&D Coverage' != NULL" is satisfied
    When I click "AD&D_Driver1" when "'AD&D_Driver1' != NULL" is satisfied
    When I click "AD&D_Driver2" when "'AD&D_Driver2' != NULL" is satisfied
    When I click "AD&D_Driver3" when "'AD&D_Driver3' != NULL" is satisfied
    When I click "AD&D_Driver4" when "'AD&D_Driver4' != NULL" is satisfied
    When I click "AD&D_Driver5" when "'AD&D_Driver5' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver1" when "'Loss of Income Coverage_Driver1' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver2" when "'Loss of Income Coverage_Driver2' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver3" when "'Loss of Income Coverage_Driver3' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver4" when "'Loss of Income Coverage_Driver4' != NULL" is satisfied
    When I enter or select "True" in "Loss Of Income_Driver5" when "'Loss of Income Coverage_Driver5' != NULL" is satisfied
    When I click "Total Disability Coverage_Driver1" when "'Total Disability Coverage_Driver1' != NULL" is satisfied
    When I click "Inc Liability Claims of Family Members" when "'Inc Liab Claims Fam Mem' != NULL" is satisfied
    When I click "Extraordinary Medical Benefit" when "'Extraordinary Medical Benefit' != NULL" is satisfied
    When I select "Work_Loss_No" when "'Work Loss Coordination Of Benefits' != NULL" is satisfied

    # Source step 0338: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > Recreational Policy > 10 Additional Coverages | Reusable flow: Auto | 10.2 EQ | Auto_AddlCov PIP (NEW) | Source XTestStep: 3a19dd55-d49d-2319-e8b1-e935b78ef386
    When I retain the unresolved source parameter "All HH Members 65 or Pension" (not supplied by this reusable-block invocation) as runtime value "All HH Members 65 or Pension"
    When I retain the unresolved source parameter "PIP Limit" (not supplied by this reusable-block invocation) as runtime value "PIP Limit"
    When I retain the unresolved source parameter "PIP Deductible" (not supplied by this reusable-block invocation) as runtime value "PIP Deductible"
    When I retain the unresolved source parameter "Additional PIP" (not supplied by this reusable-block invocation) as runtime value "Additional PIP"
    When I retain the unresolved source parameter "PIP Stacking" (not supplied by this reusable-block invocation) as runtime value "PIP Stacking"
    When I retain the unresolved source parameter "Extra PIP Option" (not supplied by this reusable-block invocation) as runtime value "Extra PIP Option"
    When I retain the unresolved source parameter "Auto Health Insurer" (not supplied by this reusable-block invocation) as runtime value "Auto Health Insurer"
    When I retain the unresolved source parameter "Medical Expense Elimination" (not supplied by this reusable-block invocation) as runtime value "Medical Expense Elimination"
    When I retain the unresolved source parameter "Work Loss Benefits" (not supplied by this reusable-block invocation) as runtime value "Work Loss Benefits"
    When I retain the unresolved source parameter "Broadened PIP" (not supplied by this reusable-block invocation) as runtime value "Broadened PIP"
    When I retain the unresolved source parameter "Additional Death Benefit" (not supplied by this reusable-block invocation) as runtime value "Additional Death Benefit"
    When I retain the unresolved source parameter "Waiver of Income Loss" (not supplied by this reusable-block invocation) as runtime value "Waiver of Income Loss"

    # Source step 0339: EQ || Personal Injury Protection Section  | Module: EQ || Personal Injury Protection Section (New)
    # Section: Process > Recreational Policy > 10 Additional Coverages | Reusable flow: Auto | 10.2 EQ | Auto_AddlCov PIP (NEW) | Source XTestStep: 3a19dd55-d49d-5cf9-bd48-8bc37f54be1b
    When I click "Household members age 65 or receiving pension" when "'All HH Members 65 or Pension' != NULL" is satisfied
    When I click "PIP Limit" when "'PIP Limit' != NULL" is satisfied
    When I click "PIP Deductible" when "'PIP Deductible' != NULL" is satisfied
    When I click "Additional PIP" when "'Additional PIP' != NULL" is satisfied
    When I click "PIP Stacking" when "'PIP Stacking' != NULL" is satisfied
    When I select "Extra PIP Option" when "'Extra PIP Option' != NULL" is satisfied
    When I click "Auto Health Insurer" when "'Auto Health Insurer' != NULL" is satisfied
    When I click "Medical Expense Elimination" when "'Medical Expense Elimination' != NULL" is satisfied
    When I select "Work_Loss_No" when "'Work Loss Coordination Of Benefits' != NULL" is satisfied
    When I click "Broadened PIP" when "'Broadened PIP' != NULL" is satisfied
    When I click "Additional Death Benefit" when "'Additional Death Benefit' != NULL" is satisfied
    When I click "Waiver of Income Loss" when "'Waiver of Income Loss' != NULL" is satisfied

    # Source step 0340: Additional Coverages Next | Module: EQ || Additional Coverages Next (New)
    # Section: Process > Recreational Policy > 10 Additional Coverages | Reusable flow: Auto | 10.4 EQ | Auto_AddlCov Next (NEW) | Source XTestStep: 3a19dd55-d49d-96a9-0aec-e6aed537490d
    When I click "Next"

    # Source step 0341: EQ || Pricing Details (New) | Module: EQ || Pricing Details (New)
    # Section: Process > Recreational Policy > 11 Pricing | Reusable flow: Auto | 11 EQ | Happy Path_Pricing Page  | Source XTestStep: 3a19dd55-d48e-d305-1d73-388985eda2c9
    Then I wait until "Header Pricing Details" exists
    When I click "Next"

    # Source step 0342: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 11 Pricing | Reusable flow: Auto | 11 EQ | Happy Path_Pricing Page  | Source XTestStep: 3a19dd55-d48e-d8c5-f9f6-869ea583e4c6
    Then I wait until "Loading ..." exists

    # Source step 0343: EQ | Underwriting Eligibility Restrictions | Module: EQ | Underwriting Eligibility Restrictions
    # Section: Process > Recreational Policy > 12 Underwriting > EQ | Underwriting Eligibility Restrictions | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-d1ef-8e82-01e2c1104d3f
    Then I wait until "Header Underwriting" exists
    When I select "Yes"
    When I enter or select "{Click}{end}" in "No"

    # Source step 0344: EQ | Underwriting Collector And Vintage Information | Module: EQ | Underwriting Collector And Vintage Information
    # Section: Process > Recreational Policy > 12 Underwriting > EQ | Underwriting Collector And Vintage Information | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-a37d-0993-113ea0e74500
    # Runtime control: EQ | Underwriting Collector And Vintage Information > Condition
    Then if the source runtime condition "EQ | Underwriting Collector And Vintage Information > Condition" is satisfied, I wait until "Are all collector vehicles kept in a fully enclosed and locked structure?" is visible

    # Source step 0345: EQ | Underwriting Collector And Vintage Information | Module: EQ | Underwriting Collector And Vintage Information
    # Section: Process > Recreational Policy > 12 Underwriting > EQ | Underwriting Collector And Vintage Information | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-ef81-543f-210923711451
    # Runtime control: EQ | Underwriting Collector And Vintage Information > Then
    When if the source runtime condition "EQ | Underwriting Collector And Vintage Information > Then" is satisfied, I select "Yes"

    # Source step 0346: EQ | Underwriting Underwriting Next | Module: EQ | Underwriting Underwriting Next
    # Section: Process > Recreational Policy > 12 Underwriting | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-9e3c-e2f0-4fa80c4245ab
    When I click "Next"

    # Source step 0347: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 12 Underwriting | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a1b01b4-37fa-c628-2432-74737edb16f7
    When I perform the source-defined operation "EQ |Common|Loading Indicator Wait" in module "EQ |Common|Loading Indicator Wait"

    # Source step 0348: AdditionalInterest | Module: EQ || AdditionalInterest
    # Section: Process > Recreational Policy > 13 Additional Interest | Reusable flow: Auto | 13 EQ | Additional Interest Page | Source XTestStep: 3a19dd55-d4bb-a454-ca62-5a4cc15f71f7
    When I click "Next"

    # Source step 0349: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > Recreational Policy > 13 Additional Interest | Reusable flow: Auto | 13 EQ | Additional Interest Page | Source XTestStep: 3a1b0169-7a5f-2a20-be85-cc3814410f19
    When I perform the source-defined operation "EQ |Common|Loading Indicator Wait" in module "EQ |Common|Loading Indicator Wait"

    # Source step 0350: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > Recreational Policy > 14 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0414: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-678d-35f1-44cb42bd42a1
    # Runtime control: If Correction Needed > Condition Correction Needed Visible
    Then if the source runtime condition "If Correction Needed > Condition Correction Needed Visible" is satisfied, "Correction Needed Step 1" should exist

    # Source step 0415: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-78eb-7e86-0c69593dd72b
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "SaveExit_1"

    # Source step 0416: OpenUrl | Module: OpenUrl
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0420: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0421: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0422: EU||Home | Module: EU||Home
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0423: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0424: EU||Applicant | Module: EU||Applicant
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "Lnk_Pricing"

    # Source step 0425: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0426: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Condition
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0427: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Then
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0430: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I close the active browser

    # Source step 0431: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-3597-854a-48cd2f94a920
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0432: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-4570-5e7e-f6661e969808
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "DIV_Submission"

    # Source step 0469: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-5fda-b2fb-7d9202bb7c40
    Then I wait until "Submission_1" exists

    # Source step 0470: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-0405-6aeb-e03a8a879562
    # Runtime control: While Comments  [max=10] > Condition
    Then if the source runtime condition "While Comments [max=10] > Condition" is satisfied, "Comments" should exist

    # Source step 0471: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission > Comments | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-24d4-58ea-b3b007866a02
    # Runtime control: While Comments  [max=10] > Loop > If > Condition
    Then if the source runtime condition "While Comments [max=10] > Loop > If > Condition" is satisfied, "Comments" should exist

    # Source step 0472: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission > Comments | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-fc27-ff5e-eddbf892e12e
    # Runtime control: While Comments  [max=10] > Loop > If > Then
    When if the source runtime condition "While Comments [max=10] > Loop > If > Then" is satisfied, I enter or select "\"Test\"" in "Comments"

    # Source step 0473: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-df70-4c5e-bc47d782b4cd
    # Runtime control: If Referral Button  > Condition
    Then if the source runtime condition "If Referral Button > Condition" is satisfied, "ReferUW" should be visible

    # Source step 0474: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-5e68-6b54-41c4c6120974
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "ReferUW"
    When I click "SaveExit_1"

    # Source step 0492: EQ || OpenUrl | Module: EQ || OpenUrl
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > Open URL | Source XTestStep: 3a1abacb-9c11-d635-aec9-d96efada9152
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0493: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1da9bf-638d-557b-2d67-5eca96520ce5
    # Runtime control: If Referral Button  > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If Referral Button > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0494: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1da9bf-639c-e3a7-4507-e7e068e6b07c
    # Runtime control: If Referral Button  > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If Referral Button > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0495: EU||Home | Module: EU||Home
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-17af-eac2-efc85049f006
    # Runtime control: If Referral Button  > Then
    Then if the source runtime condition "If Referral Button > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0496: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-776f-690b-c57137d617c8
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "Policy/Quote#"

    # Source step 0497: EU||Applicant | Module: EU||Applicant
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-dd12-e647-1b7133cb86df
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0498: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-df28-5b9a-9aa2498a2226
    # Runtime control: If Referral Button  > Then
    Then if the source runtime condition "If Referral Button > Then" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Click}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    Then I wait until "Btn_Approve" is visible
    When I click "Btn_Approve"
    When I click "Lnk_Home"

    # Source step 0499: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-3187-745d-aac57504448a
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I close the active browser

    # Source step 0500: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > EQ | Recall Quote in EQ | Source XTestStep: 3a1d37b5-c754-fa99-186e-4cdf3e363d8c
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0501: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > EQ | Recall Quote in EQ | Source XTestStep: 3a1d37b5-c766-2435-d5f0-9d921f232fa6
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "DIV_Submission"

    # Source step 0505: OpenUrl | Module: OpenUrl
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0509: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0510: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0511: EU||Home | Module: EU||Home
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    Then I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0512: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    When I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0513: EU||Applicant | Module: EU||Applicant
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    When I click "Lnk_Pricing"

    # Source step 0514: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    When I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0515: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Level 9 exists > Condition
    Then if the source runtime condition "If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0516: EU||Pricing | Module: EU||Pricing
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Level 9 exists > Then
    When if the source runtime condition "If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0519: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    When I close the active browser

    # Source step 0520: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ| Express UW Review | Source XTestStep: 3a19e1e5-0cbf-1406-4bee-4dcaac1e1669
    When I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0521: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > Recreational Policy > 15 Submission | Reusable flow: Auto | 15 EQ| Express UW Review | Source XTestStep: 3a19e1e5-0cbf-0464-b4c5-e67a9197d671
    When I click "DIV_Submission"

    # Source step 0534: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 16 Launch checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-3e09-b878-6e62408fbd61
    When I click "Checklist_1"

    # Source step 0535: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > Recreational Policy > 16 Launch checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-4353-149b-daba614be6e5
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0536: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > Recreational Policy > 16 Launch checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-c17f-736a-d3c52a1c9db4
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0537: TBox Save As | Module: TBox Save As
    # Section: Process > Recreational Policy > 16 Launch checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-aacd-b5ac-657e4832e6f3
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0538: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > Recreational Policy > 16 Launch checklist > EU||Uploading_Docs | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-b8d9-b16b-057f5a30b083
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0540: TBox Save As_1 | Module: TBox Save As
    # Section: Process > Recreational Policy > 16 Launch checklist > EU||Uploading_Docs | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-fa06-d749-6feed4b2eadb
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0541: CloseBrowser | Module: CloseBrowser
    # Section: Process > Recreational Policy > 16 Launch checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-7326-8d73-7c7fc0692bd4
    When I close the active browser

    # Source step 0542: EQ|| Checklist Close | Module: EQ|| Checklist Close
    # Section: Process > Recreational Policy > 16 Launch checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-df50-487a-983ad17c1dff
    When I click "Btn_Ok"

    # Source step 0544: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > Recreational Policy > 17 Transmit | Reusable flow: Auto | 17 EQ | Transmit | Source XTestStep: 3a19dd55-d48e-82a4-34a0-f9472b13da42
    Then I wait until "Transmit" exists
    When I click "Transmit"

    # Source step 0545: Get Policy Number, Premium details_Reference | Module: EQ||Submission
    # Section: Process > Recreational Policy > 17 Transmit | Reusable flow: <none> | Source XTestStep: 3a1a521c-5d27-dc3d-f0f6-8e52b3e62c82
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0546: Push Quote Data & Policy Information to TDS | Module: TestData - Create & provide new item
    # Section: Process > Recreational Policy > TDS Validations | Reusable flow: <none> | Source XTestStep: 3a1a521c-5d27-5140-b751-162b20124729
    When I retrieve test data through TDM operation "Push Quote Data & Policy Information to TDS"
    And I use TDM parameter "Existing or new TDS type" with "Auto_PolicyData_Smoke"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "AZ"

    # Source step 0547: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a1a521c-5d27-73ba-dd16-3c49e50c3af2
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0548: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a1a521c-5d27-28dd-93ed-29234be2e94d
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "Auto_PolicyData_Smoke"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "AZ"

    # Source step 0549: Submission_2-Save & Exit | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a1a521c-5d27-b9e1-d1d1-c7057b124330
    When I click "Btn_Save and Exit"

    # Source step 0550: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a1a521c-5d27-602f-2479-fbabb4754ae5
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0010 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0015 field "Drpdwn_State" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: ""
# 3. Source step 0020 field "PROCEED" in "Proposal Details/Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 4. Source step 0020 field "PROCEED" in "Proposal Details/Start" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 5. Source step 0021 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - VERIFY "County_ComboBox" with "True"
# 6. Source step 0022 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - INPUT "County_ComboBox" with the unresolved source parameter "County Name" (not supplied by this reusable-block invocation)
#    - INPUT "Start Quote" with "X"
#    - WAIT "PROCEED" with "True"
#    - INPUT "PROCEED" with "X"
# 7. Source step 0023 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - INPUT "Start Quote" with "X"
# 8. Source step 0033 field "Lbl_Quote" in "EQ||Tabs - Capturing Quote number" was disabled. Reason:  
#    - Preserved source value: a blank value
# 9. Source step 0037 "NamedIns_Operator Status_MT" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 03.06.26 09:09:31 [pa2096@dnanico1.aniconet.com]
#    - INPUT "First Name_Driver1" with the RUNTIME-DERIVED TDM value "AL_ClientData.First Name"
#    - INPUT "Last Name_Driver1" with the RUNTIME-DERIVED TDM value "AL_ClientData.Last Name"
#    - INPUT "DOB_Driver1" with the unresolved source parameter "DOB" (not supplied by this reusable-block invocation)
#    - INPUT "More Options (Relation to Account Owner)" with ""
#    - WAIT "More Options (Relation to Account Owner)" with "True"
#    - INPUT "More Options (Relation to Account Owner)" with "X"
#    - WAIT "Account Owner" with "True"
#    - INPUT "Account Owner" with "{Click}"
#    - INPUT "SSN" with the RUNTIME-DERIVED TDM value "AL_ClientData.SSN"
#    - INPUT "MT National Guard" with "X"
# 10. Source step 0038 "Gender Enabled?" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 01.06.26 16:18:37 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Gender" with "True"
# 11. Source step 0039 "NamedIns_Operator Status" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 01.06.26 16:18:37 [pa2096@dnanico1.aniconet.com]
#    - CONTAINER "Gender" with "True"
#    - INPUT "Male" with "X"
#    - INPUT "Female" with "X"
# 12. Source step 0049 field "More Options (Operator Status)" in "NamedIns_Operator Status_Cycle" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0050 field "More Options (Operator Status)" in "NamedIns_Operator Status" was disabled. Reason:  
#    - Preserved source value: "X"
# 14. Source step 0051 field "Driver Name" in "License Info" was disabled. Reason:  
#    - Preserved source value: "Driver_1"
# 15. Source step 0079 field "btn_Customized_No" in "EQ||Vehicle Summary Auto Use" was disabled. Reason:  
#    - Preserved source value: "X"
# 16. Source step 0080 "EQ||Vehicle Summary Auto/Motor Home Use" in module "EQ||Vehicle Summary Auto/Motor Home Use" was disabled. Reason: 05.05.25 16:19:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Title_transfer_No" with "True"
# 17. Source step 0081 "EQ||Vehicle Summary Auto/Motor Home Use" in module "EQ||Vehicle Summary Auto/Motor Home Use" was disabled. Reason: 05.05.25 16:19:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title_transfer_Yes" with "X"
# 18. Source step 0101 field "claim/violationDoes Not Apply" in "Edit Claim" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0109 "EQ||Discount - Rate Tier Questions" in module "EQ||Discount - Rate Tier Questions(NEW)" was disabled. Reason: 15.04.25 14:50:31 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Less than $15,000/$30,000" with "{Click}"
# 20. Source step 0127 "V1 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V1_Comp/Coll Only - YES" with "X"
#    - WAIT "V1_Comprehensive Only" with "True"
#    - INPUT "V1_Comprehensive Only" with "X"
#    - INPUT "V1_ Comprehensive And Collision Only" with "X"
#    - VERIFY "V1_Comprehensive Deductible" with "True"
#    - INPUT "V1_CompDed" with "X"
#    - INPUT "V1_CompDedMoreOpt" with "X"
# 21. Source step 0128 "V1 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V1_CollDed" with "X"
#    - INPUT "V1_CollDedMoreOpt" with "X"
# 22. Source step 0129 "V2 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_Comp/Coll Only - YES" with "X"
#    - WAIT "V2_Comprehensive Only" with "True"
#    - INPUT "V2_Comprehensive Only" with "X"
#    - INPUT "V2_Comprehensive And Collision Only" with "X"
#    - VERIFY "V2_Comprehensive Deductible" with "True"
#    - INPUT "V2_CompDed" with "X"
#    - INPUT "V2_CompDedMoreOpt" with "X"
#    - VERIFY "V3_Comprehensive Deductible" with "True"
#    - INPUT "V3_CompDed" with "X"
#    - INPUT "V3_CompDedMoreOpt" with "X"
# 23. Source step 0130 "V2 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CollDed" with "X"
#    - INPUT "V2_CollDedMoreOpt" with "X"
#    - INPUT "V4_CompDedMoreOpt" with "X"
# 24. Source step 0131 "V3 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CompDed" with "X"
#    - INPUT "V3_Comp/Coll Only - YES" with "X"
#    - WAIT "V3_Comprehensive Only" with "True"
#    - INPUT "V3_Comprehensive Only" with "X"
#    - INPUT "V3_Comprehensive And Collision Only" with "X"
#    - VERIFY "V3_Comprehensive Deductible" with "True"
#    - INPUT "V3_CompDed" with "X"
#    - INPUT "V3_CompDedMoreOpt" with "X"
# 25. Source step 0132 "V3 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V3_CollDed" with "X"
#    - INPUT "V3_CollDedMoreOpt" with "X"
# 26. Source step 0133 "V4 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CompDedMoreOpt" with "X"
#    - INPUT "V4_Comp/Coll Only - YES" with "X"
#    - WAIT "V4_Comprehensive Only" with "True"
#    - INPUT "V4_Comprehensive Only" with "X"
#    - INPUT "V4_Comprehensive And Collision Only" with "X"
#    - VERIFY "V4_Comprehensive Deductible" with "True"
#    - INPUT "V4_CompDed" with "X"
#    - INPUT "V4_CompDedMoreOpt" with "X"
# 27. Source step 0134 "V4 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V4_CollDed" with "X"
#    - INPUT "V4_CollDedMoreOpt" with "X"
#    - INPUT "Next" with "X"
# 28. Source step 0140 field "Cycle Accessories_V1" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 29. Source step 0140 field "Original Parts_V1" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 30. Source step 0140 field "Endorsement Limit V1" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "SA-1398 $5,000"
# 31. Source step 0140 field "Cycle Accessories_V2" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 32. Source step 0140 field "Original Parts_V2" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 33. Source step 0140 field "Endorsement Limit V2" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "SA-1399 $7,000"
# 34. Source step 0149 field "H1_Additional Interest Summary" in "AdditionalInterest" was disabled. Reason:  
#    - Preserved source value: "True"
# 35. Source step 0152 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 36. Source step 0153 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 37. Source step 0154 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 38. Source step 0155 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 39. Source step 0159 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 40. Source step 0160 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 41. Source step 0161 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 42. Source step 0163 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0163 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 44. Source step 0167 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 45. Source step 0167 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 46. Source step 0167 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 47. Source step 0167 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 48. Source step 0168 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 49. Source step 0168 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 50. Source step 0168 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0168 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 52. Source step 0169 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0169 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 54. Source step 0169 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0169 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0170 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 57. Source step 0171 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 58. Source step 0175 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Submission_1" with "True"
# 59. Source step 0176 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Comments" with "True"
# 60. Source step 0177 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Comments" with "True"
# 61. Source step 0178 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Comments" with "\"Test\""
# 62. Source step 0179 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ReferUW" with "True"
# 63. Source step 0180 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ReferUW" with "X"
#    - INPUT "SaveExit_1" with "X"
# 64. Source step 0181 "OpenUrl" in module "OpenUrl" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with "https://dcpqa.dnanico1.aniconet.com/express/express.aspx"
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 65. Source step 0182 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 66. Source step 0183 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 67. Source step 0184 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 68. Source step 0185 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 69. Source step 0186 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 70. Source step 0187 "EU||Home" in module "EU||Home" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 71. Source step 0188 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 72. Source step 0189 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 73. Source step 0190 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 74. Source step 0191 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 75. Source step 0192 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 76. Source step 0193 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 77. Source step 0194 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 78. Source step 0195 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 79. Source step 0196 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 80. Source step 0197 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 81. Source step 0198 "EQ || OpenUrl" in module "EQ || OpenUrl" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with "https://dcpqa.dnanico1.aniconet.com/express/express.aspx"
#    - INPUT "WebDriverBrowserArguments" with "--silent-debugger-extension-api"
# 82. Source step 0199 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 83. Source step 0200 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 84. Source step 0201 "EU||Home" in module "EU||Home" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 85. Source step 0202 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
# 86. Source step 0203 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 87. Source step 0204 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 88. Source step 0205 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 89. Source step 0206 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 90. Source step 0207 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 91. Source step 0208 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 92. Source step 0209 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 93. Source step 0210 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 94. Source step 0217 "OpenUrl" in module "OpenUrl" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 95. Source step 0218 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 96. Source step 0219 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 97. Source step 0220 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 98. Source step 0221 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 99. Source step 0222 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 100. Source step 0223 "EU||Home" in module "EU||Home" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 101. Source step 0224 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 102. Source step 0225 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 103. Source step 0226 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 104. Source step 0227 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 105. Source step 0228 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 106. Source step 0229 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 107. Source step 0230 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 108. Source step 0231 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 109. Source step 0232 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 110. Source step 0233 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 111. Source step 0236 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 112. Source step 0236 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 113. Source step 0244 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 114. Source step 0245 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 115. Source step 0246 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 116. Source step 0248 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 117. Source step 0249 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 118. Source step 0250 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 119. Source step 0252 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 120. Source step 0252 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 121. Source step 0256 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 122. Source step 0256 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 123. Source step 0256 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 124. Source step 0256 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 125. Source step 0257 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 126. Source step 0257 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 127. Source step 0257 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 128. Source step 0257 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 129. Source step 0258 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 130. Source step 0258 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 131. Source step 0258 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 132. Source step 0258 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 133. Source step 0259 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 134. Source step 0260 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 135. Source step 0265 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 136. Source step 0269 "TBox Wait" in module "TBox Wait" was disabled. Reason: 25.02.25 14:11:17 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "30000"
# 137. Source step 0278 field "PROCEED" in "Proposal Details/Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 138. Source step 0278 field "PROCEED" in "Proposal Details/Start" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 139. Source step 0279 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - VERIFY "County_ComboBox" with "True"
# 140. Source step 0280 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - INPUT "County_ComboBox" with the unresolved source parameter "County Name" (not supplied by this reusable-block invocation)
#    - INPUT "Start Quote" with "X"
#    - WAIT "PROCEED" with "True"
#    - INPUT "PROCEED" with "X"
# 141. Source step 0281 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - INPUT "Start Quote" with "X"
# 142. Source step 0307 field "Btn_Additional Vehicle" in "EQ||Vehicle Information" was disabled. Reason:  
#    - Preserved source value: "True"
# 143. Source step 0328 "V1 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V1_Comp/Coll Only - YES" with "X"
#    - WAIT "V1_Comprehensive Only" with "True"
#    - INPUT "V1_Comprehensive Only" with "X"
#    - INPUT "V1_ Comprehensive And Collision Only" with "X"
#    - VERIFY "V1_Comprehensive Deductible" with "True"
#    - INPUT "V1_CompDed" with "X"
#    - INPUT "V1_CompDedMoreOpt" with "X"
# 144. Source step 0329 "V1 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V1_CollDed" with "X"
#    - INPUT "V1_CollDedMoreOpt" with "X"
# 145. Source step 0330 "V2 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_Comp/Coll Only - YES" with "X"
#    - WAIT "V2_Comprehensive Only" with "True"
#    - INPUT "V2_Comprehensive Only" with "X"
#    - INPUT "V2_Comprehensive And Collision Only" with "X"
#    - VERIFY "V2_Comprehensive Deductible" with "True"
#    - INPUT "V2_CompDed" with "X"
#    - INPUT "V2_CompDedMoreOpt" with "X"
#    - VERIFY "V3_Comprehensive Deductible" with "True"
#    - INPUT "V3_CompDed" with "X"
#    - INPUT "V3_CompDedMoreOpt" with "X"
# 146. Source step 0331 "V2 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CollDed" with "X"
#    - INPUT "V2_CollDedMoreOpt" with "X"
#    - INPUT "V4_CompDedMoreOpt" with "X"
# 147. Source step 0332 "V3 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CompDed" with "X"
#    - INPUT "V3_Comp/Coll Only - YES" with "X"
#    - WAIT "V3_Comprehensive Only" with "True"
#    - INPUT "V3_Comprehensive Only" with "X"
#    - INPUT "V3_Comprehensive And Collision Only" with "X"
#    - VERIFY "V3_Comprehensive Deductible" with "True"
#    - INPUT "V3_CompDed" with "X"
#    - INPUT "V3_CompDedMoreOpt" with "X"
# 148. Source step 0333 "V3 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V3_CollDed" with "X"
#    - INPUT "V3_CollDedMoreOpt" with "X"
# 149. Source step 0334 "V4 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CompDedMoreOpt" with "X"
#    - INPUT "V4_Comp/Coll Only - YES" with "X"
#    - WAIT "V4_Comprehensive Only" with "True"
#    - INPUT "V4_Comprehensive Only" with "X"
#    - INPUT "V4_Comprehensive And Collision Only" with "X"
#    - VERIFY "V4_Comprehensive Deductible" with "True"
#    - INPUT "V4_CompDed" with "X"
#    - INPUT "V4_CompDedMoreOpt" with "X"
# 150. Source step 0335 "V4 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V4_CollDed" with "X"
#    - INPUT "V4_CollDedMoreOpt" with "X"
#    - INPUT "Next" with "X"
# 151. Source step 0348 field "H1_Additional Interest Summary" in "AdditionalInterest" was disabled. Reason:  
#    - Preserved source value: "True"
# 152. Source step 0351 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 153. Source step 0352 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 154. Source step 0353 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 155. Source step 0354 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 156. Source step 0355 "Verify if Principal/occasional operator assigned_ErrorMsg is visible" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Principal/occasional operator assigned_ErrorMsg" with "True"
# 157. Source step 0356 "OpenUrl" in module "OpenUrl" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 158. Source step 0357 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 159. Source step 0358 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 160. Source step 0359 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 161. Source step 0360 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 162. Source step 0361 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 163. Source step 0362 "Search Policy Number" in module "EU||Home" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 164. Source step 0363 "Click on Insured and Product type" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Lnk_Insured Name" with "X"
#    - INPUT "Lnk_Motorcycle" with the unresolved source parameter "MotorCycle" (not supplied by this reusable-block invocation)
#    - INPUT "Lnk_PersonalAuto" with "X"
#    - INPUT "Lnk_Home" with the unresolved source parameter "Home" (not supplied by this reusable-block invocation)
#    - INPUT "Lnk_ROP" with the unresolved source parameter "ROP" (not supplied by this reusable-block invocation)
# 165. Source step 0364 "Click on Pricing" in module "EU||Applicant" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 166. Source step 0365 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "20000"
# 167. Source step 0366 "ChkBox_Bypass Level 9 Rules" in module "EU||Pricing" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Bypass Level 9 Comments" with "True"
# 168. Source step 0367 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "20000"
# 169. Source step 0368 "ChkBox_Bypass Level 9 Rules" in module "EU||Pricing" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}{Sendkeys[Bypassed]}"
# 170. Source step 0369 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 171. Source step 0370 "Click on Home button" in module "EU||Pricing" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - WAIT "Lnk_Home" with "True"
#    - INPUT "Lnk_Home" with "X"
# 172. Source step 0371 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 173. Source step 0372 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Title" with "Home*"
# 174. Source step 0373 "Submission_2-Back to Submission page" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_Save and Exit" with "X"
# 175. Source step 0374 "Another user is currently accessing this quote. Please try again in a moment." in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Another user is currently accessing this quote. Please try again in a moment." with "True"
# 176. Source step 0375 "Click ok & Recall Quote" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Ok" with "X"
# 177. Source step 0376 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}"
#    - INPUT "Btn_Search" with "X"
# 178. Source step 0377 "Click on Submission" in module "EQ | Side Menu" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Submission" with "X"
# 179. Source step 0378 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "8000"
# 180. Source step 0379 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with the RUNTIME-DERIVED buffer expression "{CLICK}{Sendkeys[{B[QuoteNumber]}]}"
#    - INPUT "Btn_Search" with "X"
# 181. Source step 0380 "Click on Submission" in module "EQ | Side Menu" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Submission" with "X"
# 182. Source step 0381 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "8000"
# 183. Source step 0382 "EQ||Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Txt_AgentComments" with "True"
# 184. Source step 0383 "EQ||Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_AgentComments" with "{CLICK}{SENDKEYS[Review Completed]}"
# 185. Source step 0384 "EQ||Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Txt2_Agent Comments" with "True"
# 186. Source step 0385 "EQ||Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt2_Agent Comments" with "{CLICK}{SENDKEYS[Review Completed]}"
# 187. Source step 0386 "EQ||Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Txt3_Agent Comments" with "True"
# 188. Source step 0387 "Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt3_Agent Comments" with "{CLICK}{SENDKEYS[Review Completed]}"
# 189. Source step 0388 "Verify Refer to UW Appears" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Btn_Refer to UW" with "True"
# 190. Source step 0389 "EQ||Submission" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Txt_Agent Comments" with "True"
# 191. Source step 0390 "Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Agent Comments" with "{CLICK}{SENDKEYS[Review Completed]}"
# 192. Source step 0391 "Agent Comments Appears" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Txt_Agent_Cmnts_Refer to UW" with "True"
# 193. Source step 0392 "Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Agent_Cmnts_Refer to UW" with "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 194. Source step 0393 "Another Agent Comment Appears" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Txt_Agent_Cmnts_Refer to UW_2" with "True"
# 195. Source step 0394 "Enter Agent Comments" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Agent_Cmnts_Refer to UW_2" with "{Invoke[Click]}{SENDKEYS[Review Completed]}"
# 196. Source step 0395 "Click Refer to UW" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_Refer to UW" with "X"
# 197. Source step 0396 "OpenUrl" in module "OpenUrl" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Url" with the unresolved source parameter "URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 198. Source step 0397 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 199. Source step 0398 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 200. Source step 0399 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 201. Source step 0400 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 202. Source step 0401 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED value "ExpressPassword"
#    - INPUT "Lnk_LOGIN" with "X"
# 203. Source step 0402 "EU||Home" in module "EU||Home" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Search Text" with "\"^{a}\""
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "x"
# 204. Source step 0403 "EU||Click on Auto/Motorcycle" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Lnk_Insured Name" with "X"
#    - WAIT "Lnk_PersonalAuto" with "True"
#    - INPUT "Lnk_PersonalAuto" with "X"
# 205. Source step 0404 "EU||Transact" in module "EU||Transact" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - WAIT "Btn_ViewPolicy" with "True"
# 206. Source step 0405 "EU||Transact" in module "EU||Transact" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_ViewPolicy" with "{Invoke[Click]}"
# 207. Source step 0406 "EU||Transact" in module "EU||Transact" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Btn_Yes" with "True"
# 208. Source step 0407 "EU||Transact" in module "EU||Transact" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_Yes" with "{Invoke[Click]}"
# 209. Source step 0408 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 210. Source step 0409 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Invoke[Click]}{SENDKEYS[Verified]}"
#    - INPUT "Btn_Approve" with "{Invoke[Click]}"
# 211. Source step 0410 "Close the Express UI Page" in module "CloseBrowser" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Title" with "TransACT*"
# 212. Source step 0411 "EQ||Save and Exit - Save and Exit the Quote" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_Save and Exit" with "{Invoke[Click]}"
# 213. Source step 0412 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 214. Source step 0413 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 26.03.25 14:27:16 [pa1639@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 215. Source step 0417 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 216. Source step 0418 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 217. Source step 0419 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 218. Source step 0421 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 219. Source step 0421 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 220. Source step 0425 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 221. Source step 0425 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 222. Source step 0425 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 223. Source step 0425 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 224. Source step 0426 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 225. Source step 0426 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 226. Source step 0426 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 227. Source step 0426 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 228. Source step 0427 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 229. Source step 0427 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 230. Source step 0427 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 231. Source step 0427 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 232. Source step 0428 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 233. Source step 0429 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 234. Source step 0433 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Submission_1" with "True"
# 235. Source step 0434 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Comments" with "True"
# 236. Source step 0435 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Comments" with "True"
# 237. Source step 0436 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Comments" with "\"Test\""
# 238. Source step 0437 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ReferUW" with "True"
# 239. Source step 0438 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ReferUW" with "X"
#    - INPUT "SaveExit_1" with "X"
# 240. Source step 0439 "OpenUrl" in module "OpenUrl" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with "https://dcpqa.dnanico1.aniconet.com/express/express.aspx"
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 241. Source step 0440 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 242. Source step 0441 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 243. Source step 0442 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 244. Source step 0443 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 245. Source step 0444 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 246. Source step 0445 "EU||Home" in module "EU||Home" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 247. Source step 0446 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 248. Source step 0447 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 249. Source step 0448 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 250. Source step 0449 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 251. Source step 0450 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 252. Source step 0451 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 253. Source step 0452 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 254. Source step 0453 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 255. Source step 0454 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 256. Source step 0455 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 257. Source step 0456 "EQ || OpenUrl" in module "EQ || OpenUrl" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with "https://dcpqa.dnanico1.aniconet.com/express/express.aspx"
#    - INPUT "WebDriverBrowserArguments" with "--silent-debugger-extension-api"
# 258. Source step 0457 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 259. Source step 0458 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 260. Source step 0459 "EU||Home" in module "EU||Home" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 261. Source step 0460 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
# 262. Source step 0461 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 263. Source step 0462 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 264. Source step 0463 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 265. Source step 0464 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 266. Source step 0465 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 267. Source step 0466 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 268. Source step 0467 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 269. Source step 0468 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 270. Source step 0475 "OpenUrl" in module "OpenUrl" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 271. Source step 0476 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 272. Source step 0477 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 273. Source step 0478 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 274. Source step 0479 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 275. Source step 0480 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 276. Source step 0481 "EU||Home" in module "EU||Home" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 277. Source step 0482 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 278. Source step 0483 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 279. Source step 0484 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 280. Source step 0485 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 281. Source step 0486 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 282. Source step 0487 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 283. Source step 0488 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 284. Source step 0489 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 285. Source step 0490 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 286. Source step 0491 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 287. Source step 0494 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 288. Source step 0494 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 289. Source step 0502 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 290. Source step 0503 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 291. Source step 0504 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 292. Source step 0506 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 293. Source step 0507 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 294. Source step 0508 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 295. Source step 0510 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 296. Source step 0510 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 297. Source step 0514 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 298. Source step 0514 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 299. Source step 0514 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 300. Source step 0514 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 301. Source step 0515 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 302. Source step 0515 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 303. Source step 0515 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 304. Source step 0515 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 305. Source step 0516 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 306. Source step 0516 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 307. Source step 0516 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 308. Source step 0516 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 309. Source step 0517 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 310. Source step 0518 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 311. Source step 0522 "Launch To Checklist" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Btn_Launch To Checklist" with "{Invoke[Click]}"
# 312. Source step 0523 "Verify ExpressUI Sign on page showed up" in module "EU||Login" was disabled. Reason: 14.12.23 20:50:20 [ct2518]
#    - VERIFY "Lbl_Login ID" with "True"
#    - VERIFY "Lbl_Password" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_LOGIN" with "True"
# 313. Source step 0524 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YD2102"
#    - VERIFY "Lbl_Password" with "Password"
#    - INPUT "Txt_Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_FORGOT LOGIN ID?" with "True"
#    - VERIFY "Lnk_FORGOT PASSWORD?" with "True"
#    - VERIFY "Btn_Sign On" with "True"
# 314. Source step 0525 "Provide Sign on credentials" in module "EU||Login" was disabled. Reason: 14.12.23 20:51:55 [ct2518]
#    - INPUT "Txt_Login ID_1" with "\"^{a}\""
#    - INPUT "Txt_Login ID_1" with "CT2451"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "X"
# 315. Source step 0526 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - VERIFY "Img_American National Family of Companies" with "True"
#    - VERIFY "Lbl_Sign On" with "True"
#    - VERIFY "Lbl_Please sign on and we'll send you right along." with "True"
#    - VERIFY "Lbl_Username" with "Username"
#    - INPUT "Txt_Username" with "\"^{a}\""
#    - INPUT "Txt_Username" with "YD2102"
#    - VERIFY "Lbl_Password" with "Password"
#    - INPUT "Txt_Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - VERIFY "Lnk_FORGOT LOGIN ID?" with "True"
#    - VERIFY "Lnk_FORGOT PASSWORD?" with "True"
#    - INPUT "Btn_Sign On" with "X"
# 316. Source step 0527 "EQ||Agent List count capture - Capture Count of Documents to be Uploaded" in module "EQ||Agent List count capture" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - BUFFER "DIV_Agent Documents Count" with "AgentList count"
#    - VERIFY "DIV_Agent Documents Count" with the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 317. Source step 0528 "EQ||ECheckList - Click Auto/Cycle/RV Application" in module "EQ||ECheckList" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Recreational Vehicle Photo (Opposite Diagonal)" with "X"
#    - INPUT "Lnk_Auto/Cycle/RV Application" with "X"
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 318. Source step 0529 "TBox Save As - Enter File location" in module "TBox Save As" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png"
#    - INPUT "Button" with "Open"
# 319. Source step 0530 "EQ||ECheckList_1" in module "EQ||ECheckList" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - INPUT "DIV_Drag and Drop files here to upload (or click here to open a file explorer)" with "{Click}"
# 320. Source step 0531 "TBox Save As_1" in module "TBox Save As" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Caption" with "Open"
#    - INPUT "FilePath" with "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg"
#    - INPUT "Button" with "Open"
# 321. Source step 0532 "EQ||Agent List count capture" in module "EQ||Agent List count capture" was disabled. Reason: 04.01.24 15:56:23 [ct2518]
#    - BUFFER "DIV_Agent Documents Count" with "count"
# 322. Source step 0533 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 26.03.25 14:26:06 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Title" with "American*"
# 323. Source step 0535 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 324. Source step 0539 "TBox Wait" in module "TBox Wait" was disabled. Reason: 25.02.25 14:11:17 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "30000"
# 325. Source step 0543 "EQ||Click on Transmit" in module "EQ||Submission" was disabled. Reason: 26.03.25 14:27:46 [pa1639@dnanico1.aniconet.com]
#    - WAIT "Btn_Ok" with "True"
#    - INPUT "Btn_Ok" with "{Invoke[Click]}"
#    - WAIT "Btn_Transmit" with "True"
#    - VERIFY "Btn_Transmit" with "Transmit"
#    - INPUT "Btn_Transmit" with "X"
# 326. Source step 0545 field "Btn_Transmit" in "Get Policy Number, Premium details_Reference" was disabled. Reason:  
#    - Preserved source value: "True"
# 327. Source step 0545 field "Btn_Transmit" in "Get Policy Number, Premium details_Reference" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 328. Source step 0545 field "Btn_Transmit" in "Get Policy Number, Premium details_Reference" was disabled. Reason:  
#    - Preserved source value: "X"
# 329. Source step 0547 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 330. Source step 0547 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 331. Source step 0547 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
