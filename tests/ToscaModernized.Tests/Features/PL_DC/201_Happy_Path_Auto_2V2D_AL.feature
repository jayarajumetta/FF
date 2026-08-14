# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 201_Happy_Path_Auto_2V2D_AL.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Auto @happy_path @Alabama @Edge @manual @automated
Feature: Execute Happy Path Auto 2V2D for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Happy Path Auto 2V2D workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Happy Path Auto 2V2D using representative iteration Alabama (AL) — selected from TestCase-Design; no concrete instantiated TestCase was exported
    # Source step 0020: Click on New Quote button | Module: EQ||New Quote
    # Section: Process > 01 Client Selection & Account Details for New Client > Start New Quote | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client > Common | 01 EQ - Start New Quote | Source XTestStep: 3a19dd55-d443-6b95-2414-e782dd27e3e3
    Given I wait until "Btn_New Quote" exists
    Then "Btn_New Quote" should equal "New Quote"
    When I click "Btn_New Quote"

    # Source step 0021: Client Selection-Enter Client Info of New or Exisiting Clients | Module: EQ || Client Selection
    # Section: Process > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client > Auto | 01 EQ | Client Selection (NEW) | Source XTestStep: 3a19dd55-d49d-6991-8246-f114ce750615
    Then I wait until "Lbl_Client Info" exists
    Then "Lbl_Client Info" should equal "Client Info"
    When I enter the source TestCase-Design value "Drivers.First Name" (not resolved in this concrete export) in "Txt_First"
    When I enter the source TestCase-Design value "Drivers.Last Name" (not resolved in this concrete export) in "Txt_Last"
    Then I wait until "Btn_Search" exists
    When I click "Btn_Search"
    Then I wait until "Btn_Create New Client" has "InnerText" equal to "Create New Client"
    When I click "Btn_Create New Client"
    When I click "Btn_Next"

    # Source step 0022: Set StateName | Module: TBox Set Buffer
    # Section: Process > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a1a96b2-e11f-e48e-9f6e-bb78c0d69fc1
    When I retain hard-coded value "ALABAMA" as runtime value "StateName"
    When I retain the unresolved source parameter "State Abbreviation" (not supplied by this reusable-block invocation) as runtime value "State"

    # Source step 0023: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a19dd55-d4bb-5344-2b53-6fbb792cb2ce
    Then I wait until "Lbl_Account Information" exists
    Then "Txt_First Name_Account Owner" should exist
    When I enter the source TestCase-Design value "Drivers.Date of Birth" (not resolved in this concrete export) in "Txt_DOB"
    When I enter or select "5555551234" in "Txt_Best phone_Account Owner"
    When I enter or select "a@a.com" in "Txt_Email_Account Owner"
    Then I wait until "Lbl_Marital Status:" exists
    When I click "Btn_Single" when "'Marital Status' == \"Single\"" is satisfied
    When I select "Btn_Married" when "'Marital Status' == \"Married\"" is satisfied
    When I click "Btn_Divorced" when "'Marital Status' == \"Divorced\"" is satisfied
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.Street Address" in "Txt_Enter a location"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.Apartment" in "Txt_owner.address.line2"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.City" in "Txt_owner.address.city_New"
    When I select "Drpdwn_State"
    When I select "State Name"
    When I enter the RUNTIME-DERIVED TDM value "AL_ClientData.ZIP" in "Txt_owner.address.zip"
    Then I wait until "Satellite" is visible

    # Source step 0024: Account Details-Move down the screen | Module: EQ||Account Details
    # Section: Process > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a20ccea-6d87-3233-e1a5-8febbb16c0cb
    When I press "Shift+Tab" while focused on "Btn_Next"

    # Source step 0025: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process > 01 Client Selection & Account Details for New Client | Reusable flow: Auto | 01 EQ | Client Selection & Account Details for New Client > Auto | 01 EQ | Account Details (NEW) | Source XTestStep: 3a20cced-453c-5ea2-16e9-ff5272653480
    When I select "Btn_Yes_at least 90 days"
    Then I wait until "Lbl_Is the account address also where the client resides?" exists
    When I select "Btn_Yes_ClientResides"
    When I click "Btn_Next"

    # Source step 0026: TBox Set Effective Date Buffer | Module: TBox Set Buffer
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e7b-a6e5-7d00-f0c2-4760e71faa97
    When I derive and retain the RUNTIME-DERIVED date from Tosca expression "{Date[{DATE}][][MM/dd/yyyy]}" as runtime value "EffectiveDate"

    # Source step 0027: Navigate to top of screen | Module: EQ || Proposal Details/Start
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a20cd02-ca9e-8963-fbb2-ee430e14bbf7
    When I enter or select "{Scroll[-2]}" in "EffectiveDate"

    # Source step 0028: Proposal Details/Start | Module: EQ || Proposal Details/Start
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-b4d0-23a9-de44036bc990
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

    # Source step 0032: Invalid Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-16d8-9e02-3881cfde7fcf
    # Runtime control: If Invalid Address Pops Up > Condition
    Then if the source runtime condition "If Invalid Address Pops Up > Condition" is satisfied, "Lnk_PROCEED" should exist

    # Source step 0033: Proceed with Address | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-a1cf-236e-50b5851b652b
    # Runtime control: If Invalid Address Pops Up > Then
    When if the source runtime condition "If Invalid Address Pops Up > Then" is satisfied, I click "Lnk_PROCEED"

    # Source step 0034: Confirm SSN? | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-b90f-dc8e-fc482b757001
    # Runtime control: If SSN Pop Up Confirm Exist  > Condition
    Then if the source runtime condition "If SSN Pop Up Confirm Exist > Condition" is satisfied, "Lnk_CONFIRM" should exist

    # Source step 0035: Select Confirm | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-db7a-eaec-fc221ebe2f9e
    # Runtime control: If SSN Pop Up Confirm Exist  > Then
    When if the source runtime condition "If SSN Pop Up Confirm Exist > Then" is satisfied, I click "Lnk_CONFIRM"

    # Source step 0036: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-1eba-4b97-bb6837e42931
    # Runtime control: If SSN Pop Up Confirm Exist  > Else > If SSN Pops Up > Condition
    Then if the source runtime condition "If SSN Pop Up Confirm Exist > Else > If SSN Pops Up > Condition" is satisfied, "Txt_SSN" should exist
    Then "Lnk_SUBMIT" should exist

    # Source step 0037: EQ||Proposal Start Proceed & SSN | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-f7eb-36e8-124cfd68f528
    # Runtime control: If SSN Pop Up Confirm Exist  > Else > If SSN Pops Up > Then
    When if the source runtime condition "If SSN Pop Up Confirm Exist > Else > If SSN Pops Up > Then" is satisfied, I enter the source TestCase-Design value "Drivers.SSN" (not resolved in this concrete export) in "Txt_SSN"
    When I click "Lnk_SUBMIT"

    # Source step 0038: Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-e9ec-339f-d59f7f5b9ce8
    # Runtime control: If Existing Client Pops Up > Condition
    Then if the source runtime condition "If Existing Client Pops Up > Condition" is satisfied, "Client Already Exists" should exist

    # Source step 0039: Select Existing Client | Module: EQ||Proposal Start Proceed & SSN
    # Section: Process > 02 Proposal Start | Reusable flow: Auto | 02 EQ | Proposal Start (NEW) | Source XTestStep: 3a1a4e6b-ba2d-96a1-6ec5-4c64d135a412
    # Runtime control: If Existing Client Pops Up > Then
    When if the source runtime condition "If Existing Client Pops Up > Then" is satisfied, I click "Lnk_CREATE NEW ACCOUNT"

    # Source step 0040: Enter PreQualification | Module: EQ||PreQualification
    # Section: Process > 03 Pre-Qualification > 03 EQ | Auto - Pre-Qualification | Reusable flow: Auto | 03 EQ | Pre-Qualification (New) | Source XTestStep: 3a19dd55-d425-4b84-160d-b4880cf2b369
    When I enter or select "{CLICK}" in "Btn_Chk box_check_boxNone Of The Above"
    When I enter or select "{CLICK}" in "Btn_Next"

    # Source step 0041: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number (NEW) | Source XTestStep: 3a19e1e5-0ccf-9e28-e149-a517d2513110
    When I capture "InnerText" from "Quote Number" as runtime value "QuoteNum"

    # Source step 0042: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 03 Pre-Qualification | Reusable flow: Auto | 03 EQ | Capturing Proposal Number (NEW) | Source XTestStep: 3a19e1e5-0ccf-9957-49f2-159235c7eb66
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}" as runtime value "QNum"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0043: Driver Information-Enter Driver Details | Module: EQ||Driver Information
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ -  Driver Information | Source XTestStep: 3a19dd55-d470-eb81-cece-a5f2c7b44eb9
    When I click "(Existing Client)_1"
    When I enter or select "{Click}" in "Btn_Next"

    # Source step 0044: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-67ca-4506-0400320d4e53
    When I retain the source TestCase-Design value "Drivers.MT National Guard" (not resolved in this concrete export) as runtime value "MT National Guard"

    # Source step 0048: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-acad-4c10-4f278508432b
    # Runtime control: If Marital Status Enabled > Condition
    Then if the source runtime condition "If Marital Status Enabled > Condition" is satisfied, "Single" should exist

    # Source step 0049: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-64a2-b464-f2c749d5e455
    # Runtime control: If Marital Status Enabled > Then
    When if the source runtime condition "If Marital Status Enabled > Then" is satisfied, I click "Single" when "'Marital Status' != \"Single\"" is satisfied
    When I select "Married" when "'Marital Status' != \"Married\"" is satisfied
    When I click "Divorced" when "'Marital Status' != \"Divorced\"" is satisfied
    When I click "Single" when "'Marital Status' == \"Single\"" is satisfied
    When I select "Married" when "'Marital Status' == \"Married\"" is satisfied
    When I click "Divorced" when "'Marital Status' == \"Divorced\"" is satisfied

    # Source step 0050: DriverEducationLevel | Module: EQ || DriverEducationLevel
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-22de-f57a-4b5d41897a85
    # Runtime control: If Education Enabled > Condition
    Then if the source runtime condition "If Education Enabled > Condition" is satisfied, "High School Diploma or GED" should be enabled

    # Source step 0051: DriverEducationLevel | Module: EQ || DriverEducationLevel
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-2e30-5e2a-6937be39ab36
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

    # Source step 0052: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14ce-b64f-dcbe-52f4-ddfd07b5d07d
    # Runtime control: If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != "Cycle"
    Then if the source runtime condition "If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\"" is satisfied, "Spouse" should exist
    When I click "Account Owner"

    # Source step 0053: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14d0-85e0-79e4-1078-fda24b1f8582
    # Runtime control: If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != "Cycle"
    When if the source runtime condition "If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\"" is satisfied, I select "More Options (Relation to Account Owner)" when "'Relationship to Account Owner' != NULL" is satisfied
    When I click "Account Owner" when "'Relationship to Account Owner' != NULL" is satisfied

    # Source step 0054: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14d0-ce74-b9cb-b3ed-cd4467168b3c
    # Runtime control: If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != "Cycle"
    Then if the source runtime condition "If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\"" is satisfied, "Account Owner_Read Only" should exist

    # Source step 0055: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14db-b70f-45c9-eddb-a5c6f7094423
    # Runtime control: If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != "Cycle"
    Then if the source runtime condition "If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\"" is satisfied, "Account Owner_Read Only" should exist

    # Source step 0056: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1d14da-5a6d-5fc3-9eb3-afdc9d03de74
    # Runtime control: If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != "Cycle"
    When if the source runtime condition "If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\"" is satisfied, I enter or select "{Click}{scroll[2]}" in "Account Owner"

    # Source step 0057: NamedIns_Operator Status_Cycle | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-2b15-8273-c404b5c0404d
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

    # Source step 0058: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-bed7-6dc5-6248987470f0
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

    # Source step 0059: License Info | Module: EQ || DriverLicense_Time
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-19bd-dde7-2fc97763504d
    When I enter the unresolved source parameter "State Licensed(XX)" (not supplied by this reusable-block invocation) in "License State" when "'State Licensed(XX)' != NULL" is satisfied
    When I enter or select "\"^{a}\"" in "Driver's License Number" when "'Drivers License #' != NULL" is satisfied
    When I enter the RUNTIME-DERIVED TDM value "NM_ClientData.DL Number" in "Driver's License Number" when "'Drivers License #' != NULL" is satisfied
    When I enter or select "\"^{a}\"" in "Yrs Licensed Current State"
    When I enter or select "9" in "Yrs Licensed Current State"
    When I enter or select "\"^{a}\"" in "Months Licensed Current State"
    When I enter or select "9" in "Months Licensed Current State"
    When I enter or select "0" in "DaysOperatedUninsured" when "'State' == \"TX\"" is satisfied
    When I enter or select "\"^{a}\"" in "YrsLicensed All States" when "'State' == \"CA\"" is satisfied
    When I enter or select "9" in "YrsLicensed All States" when "'State' == \"CA\"" is satisfied
    When I enter or select "{Click}{Scroll[2]}" in "No" when "'Operator Status' == \"Assigned\"" is satisfied

    # Source step 0060: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1ca8e2-c037-4a88-944d-610a91933318
    # Runtime control: If client insured AN > Condition
    Then if the source runtime condition "If client insured AN > Condition" is satisfied, "Was this client insured with American National immediately prior to the carrier listed above?" should exist

    # Source step 0061: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a1ca8e3-b95f-24c0-5890-eb7c717ccb05
    # Runtime control: If client insured AN > Then
    When if the source runtime condition "If client insured AN > Then" is satisfied, I select "No (Previously Insured?)"

    # Source step 0062: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-31f2-59ea-64b5d15df7ad
    # Runtime control: If Prior Ins Listed > Condition
    Then if the source runtime condition "If Prior Ins Listed > Condition" is satisfied, "Prior Carrier Name:" should exist

    # Source step 0063: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-78f2-ae36-2375667f9b21
    # Runtime control: If Prior Ins Listed > Then
    When if the source runtime condition "If Prior Ins Listed > Then" is satisfied, I click "Save and Continue"

    # Source step 0064: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-d344-1045-91f8a2224a19
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Condition
    Then if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Condition" is satisfied, "No Need - Was Not Licensed" should be visible

    # Source step 0065: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-06f9-6072-6e771286e5f3
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Then
    When if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Then" is satisfied, I enter or select "{End}{Click}" in "No Need - Was Not Licensed"
    When I click "Save and Continue"

    # Source step 0066: Save & Continue | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-f3de-9f3c-35b9dd54efb9
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Else
    When if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Else" is satisfied, I click "Save and Continue"

    # Source step 0067: EQ || Expired License Pop Up | Module: EQ || Expired License Pop Up
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-4bc4-3bf5-62e9caafb20b
    # Runtime control: If License Expired Pop up > Condition
    Then if the source runtime condition "If License Expired Pop up > Condition" is satisfied, I wait until "CONTINUE" exists

    # Source step 0068: EQ || Expired License Pop Up | Module: EQ || Expired License Pop Up
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Driver Information Summary (NEW) | Source XTestStep: 3a19dd55-d4bb-6395-c07d-5485317b424a
    # Runtime control: If License Expired Pop up > Then
    When if the source runtime condition "If License Expired Pop up > Then" is satisfied, I click "CONTINUE"

    # Source step 0069: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-2bb8-d44c-bdda6126ad5c
    # Runtime control: 'Additional Drivers?' == "Yes"
    When if the source runtime condition "'Additional Drivers?' == \"Yes\"" is satisfied, I click "Driver Information"

    # Source step 0070: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-0828-ff66-1a82bd960ba2
    # Runtime control: If > Condition
    Then if the source runtime condition "If > Condition" is satisfied, I wait until "PrefilledDrivers" exists

    # Source step 0071: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-53ca-a517-f012a38d9d89
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I capture "ResultCount" from "PrefilledDrivers" as runtime value "NumberOfDrivers"

    # Source step 0072: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information > Repetition | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-955b-09d6-d7a8d79d80e7
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I enter or select "" in "MAT-FORM-FIELD"
    When I enter or select "{return}" in "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)"

    # Source step 0073: Save & Continue | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-50c3-bf38-2ef127c8f25e
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I click "Save and Continue"

    # Source step 0074: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-391c-4683-2363a242b3c9
    # Runtime control: If > Else > If > Condition
    Then if the source runtime condition "If > Else > If > Condition" is satisfied, "Unselected Client Suggestions" should exist

    # Source step 0075: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-c21c-d3f6-8683943ddec0
    # Runtime control: If > Else > If > Then
    When if the source runtime condition "If > Else > If > Then" is satisfied, I click "Save and Continue"

    # Source step 0076: EQ||Add Additional Driver | Module: EQ||Driver Information Next
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-6d36-18da-989be1c35398
    When I click "Btn_Add Additional Driver"

    # Source step 0077: TestData - Find & provide item | Module: Old_TestData - Find & provide item
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-c450-3951-9f37c6868fdf
    When I retrieve test data through TDM operation "TestData - Find & provide item"
    And I use TDM parameter "Existing TDS type" with "AL_ClientData"
    And I use TDM parameter "Alias name (item)" with "AL_ClientData"
    And I use TDM parameter "Data search filter > SNO" with "5"

    # Source step 0078: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0ccf-0948-b4d2-1dc786986a48
    When I retain the source TestCase-Design value "Drivers.Date of Birth" (not resolved in this concrete export) as runtime value "Silly"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[Silly]}][/][.]}" as runtime value "Convert"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[Convert]}][][MM.dd.yyyy]}" as runtime value "AddZeros"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{B[AddZeros]}][][yyyy]}" as runtime value "DOB"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{MATH[{DATE[{DATE}][-{B[DOB]}y][yy]}-15]}" as runtime value "Years Licensed"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{DATE[{DATE}][-{B[Years Licensed]}y][]}" as runtime value "Date Licensed"
    When I retain the source TestCase-Design value "Drivers.Gender" (not resolved in this concrete export) as runtime value "Gender"

    # Source step 0082: NamedIns_Operator Status | Module: EQ || NamedIns_Operator Status
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cde-2f5f-1735-2bf263842aab
    When I enter the source TestCase-Design value "Drivers.First Name" (not resolved in this concrete export) in "First Name_additionalDriver" when "'First Name' != NULL" is satisfied
    When I enter the source TestCase-Design value "Drivers.Last Name" (not resolved in this concrete export) in "Last Name_additionalDriver" when "'Last Name' != NULL" is satisfied
    When I enter the source TestCase-Design value "Drivers.Date of Birth" (not resolved in this concrete export) in "DOB_additionalDriver" when "'DOB ' != NULL" is satisfied
    When I press "Tab" while focused on "DOB_additionalDriver" when "'DOB ' != NULL" is satisfied
    When I click "Male" when "'Gender' == M" is satisfied
    When I click "Female" when "'Gender' == F" is satisfied
    When I click "Single" when "'Marital Status' == \"Single\"" is satisfied
    When I select "Married" when "'Marital Status' == \"Married\"" is satisfied
    When I click "Divorced" when "'Marital Status' == \"Divorced\"" is satisfied
    When I click "Spouse" when "'Relation to account owner' == \"Spouse\"" is satisfied
    When I click "Son" when "'Relation to account owner' == \"Son\"" is satisfied
    When I click "Daughter" when "'Relation to account owner' == \"Daughter\"" is satisfied
    When I select "More Options (Relation to Account Owner)" when "'Relation to account owner' == \"Extended Family\"" is satisfied
    Then I wait until "Extended Family" is visible when "'Relation to account owner' == \"Extended Family\"" is satisfied
    When I click "Extended Family" when "'Relation to account owner' == \"Extended Family\"" is satisfied
    Then I wait until "Is this driver a named insured?" is visible
    When I click "Primary Named Insured" when "'Named Insured?' == \"PrimaryNamedIns\"" is satisfied
    When I click "Named Insured" when "'Named Insured?' == \"NamedIns\"" is satisfied
    When I select "Not a Named Insured" when "'Named Insured?' == \"NotNamedIns\"" is satisfied
    When I click "Assigned" when "'Operator Status' == \"Assigned\"" is satisfied
    When I select "Non Driver" when "'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Related" when "'Operator Status' == \"Related\"" is satisfied
    When I select "More Options (Operator Status)" when "'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NonDriver\" AND 'Operator Status' != \"Related\"" is satisfied
    When I click "Military" when "'Operator Status' == \"Military\"" is satisfied
    When I click "Missionary" when "'Operator Status' == \"Missionary\"" is satisfied
    When I click "Other Insurance" when "'Operator Status' == \"OtherIns\"" is satisfied
    When I click "School > 100mi from home" when "'Student AWS' == \"Yes\"" is satisfied
    Then I wait until "CarAtSchool_Yes" is enabled when "'Student AWS' == \"Yes\"" is satisfied
    When I select "CarAtSchool_Yes" when "'Student AWS' == \"Yes\"" is satisfied
    When I select "CarAtSchool_No" when "'Student AWS' == \"Yes\"" is satisfied
    Then I wait until "Non-Driver Reason" is visible when "'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Never Licensed" when "'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Underage" when "'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Medical Condition" when "'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I select "More Options_NonDriver" when "'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Surrendered" when "'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\"" is satisfied
    When I click "Permit Driver" when "'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\"" is satisfied

    # Source step 0083: Order SSN Enabled | Module: EQ || Spouse SSN
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-f01f-c9e7-738bd8ce2af7
    # Runtime control: If Spouse listed > If
    Then if the source runtime condition "If Spouse listed > If" is satisfied, "Order SSN#" should be enabled

    # Source step 0084: Spouse SSN | Module: EQ || Spouse SSN
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-e2e6-259c-5faf3c7f152c
    # Runtime control: If Spouse listed > Then
    When if the source runtime condition "If Spouse listed > Then" is satisfied, I click "Order SSN#"

    # Source step 0085: Spouse SSN | Module: EQ || Spouse SSN
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-797d-9810-182899eb830c
    # Runtime control: If Spouse listed > Then > If  > SSN is Prefilled
    Then if the source runtime condition "If Spouse listed > Then > If > SSN is Prefilled" is satisfied, "Confirm Clients SSN" should exist

    # Source step 0086: Spouse SSN | Module: EQ || Spouse SSN
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-cb0d-c70a-06a5eac708d3
    # Runtime control: If Spouse listed > Then > If  > Then
    When if the source runtime condition "If Spouse listed > Then > If > Then" is satisfied, I click "CONFIRM"

    # Source step 0087: Spouse SSN | Module: EQ || Spouse SSN
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-4379-facd-69193d148716
    # Runtime control: If Spouse listed > Then > If  > Then > If > SSN Not Prefilled
    Then if the source runtime condition "If Spouse listed > Then > If > Then > If > SSN Not Prefilled" is satisfied, "Enter the Client's full SSN#." should exist

    # Source step 0088: Spouse SSN | Module: EQ || Spouse SSN
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-8387-dd83-340913cc6ccc
    # Runtime control: If Spouse listed > Then > If  > Then > If > Then
    When if the source runtime condition "If Spouse listed > Then > If > Then > If > Then" is satisfied, I enter the source TestCase-Design value "Drivers.SSN" (not resolved in this concrete export) in "Enter SSN"
    When I click "SUBMIT"

    # Source step 0089: DriverEducationLevel | Module: EQ || DriverEducationLevel
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-55fc-649b-8f626351d156
    # Runtime control: 'Relation to account owner' == "Spouse" AND  (State == "MD" OR State == "NJ")


    When if the source runtime condition "'Relation to account owner' == \"Spouse\" AND (State == \"MD\" OR State == \"NJ\")" is satisfied, I click "High School Diploma or GED" when "'If Spouse_MD_NJ_Edu_Level' == \"Unknown\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "'If Spouse_MD_NJ_Edu_Level' == \"Unknown\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "'If Spouse_MD_NJ_Edu_Level' == \"HighSchool\"" is satisfied
    When I click "High School Diploma or GED" when "'If Spouse_MD_NJ_Edu_Level' == \"HighSchool\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "'If Spouse_MD_NJ_Edu_Level' == \"Trade\"" is satisfied
    When I click "Vocational or Trade School Degree" when "'If Spouse_MD_NJ_Edu_Level' == \"Trade\"" is satisfied
    When I select "Unknown/No High School Diploma or GED" when "'If Spouse_MD_NJ_Edu_Level' != \"Unknown\" AND 'If Spouse_MD_NJ_Edu_Level' != \"HighSchool\" AND 'If Spouse_MD_NJ_Edu_Level' != \"Trade\"" is satisfied
    When I select "More Options Edu" when "'If Spouse_MD_NJ_Edu_Level' != \"Unknown\" AND 'If Spouse_MD_NJ_Edu_Level' != \"HighSchool\" AND 'If Spouse_MD_NJ_Edu_Level' != \"Trade\"" is satisfied
    Then I wait until "Some College" is visible when "'If Spouse_MD_NJ_Edu_Level' == \"SomeCollege\"" is satisfied
    When I click "Some College" when "'If Spouse_MD_NJ_Edu_Level' == \"SomeCollege\"" is satisfied
    Then I wait until "Currently in College" is visible when "'If Spouse_MD_NJ_Edu_Level' == \"InCollege\"" is satisfied
    When I click "Currently in College" when "'If Spouse_MD_NJ_Edu_Level' == \"InCollege\"" is satisfied
    Then I wait until "College Degree/Graduate Work" is visible when "'If Spouse_MD_NJ_Edu_Level' == \"CollegeDegree\"" is satisfied
    When I click "College Degree/Graduate Work" when "'If Spouse_MD_NJ_Edu_Level' == \"CollegeDegree\"" is satisfied
    Then I wait until "Graduate Degree (JD, Masters)" is visible when "'If Spouse_MD_NJ_Edu_Level' == \"GradDegree\"" is satisfied
    When I click "Graduate Degree (JD, Masters)" when "'If Spouse_MD_NJ_Edu_Level' == \"GradDegree\"" is satisfied
    Then I wait until "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)" is visible when "'If Spouse_MD_NJ_Edu_Level' == \"GradDegree\"" is satisfied
    When I click "Post Graduate Degree (Medical Degree, Ph.D., Ed.D, etc.)" when "'If Spouse_MD_NJ_Edu_Level' == \"GradDegree\"" is satisfied

    # Source step 0090: License Info | Module: EQ || DriverLicense_Time
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-1a26-0ed1-29d44fcc8936
    When I enter the unresolved source parameter "Licensed State(XX)" (not supplied by this reusable-block invocation) in "License State" when "'Licensed State(XX)' != NULL" is satisfied
    When I enter the source TestCase-Design value "Drivers.Drivers License Number" (not resolved in this concrete export) in "Driver's License Number" when "'Drivers License #' != NULL" is satisfied
    When I enter or select "\"^{a}\"" in "Yrs Licensed Current State"
    When I enter captured runtime value "Years Licensed" in "Yrs Licensed Current State" when "'State' != \"CA\"" is satisfied
    When I enter or select "0" in "Yrs Licensed Current State" when "'State' == \"CA\"" is satisfied
    When I enter or select "\"^{a}\"" in "YrsLicensed All States" when "'State' == \"CA\"" is satisfied
    When I enter or select "1" in "YrsLicensed All States" when "'State' == \"CA\"" is satisfied
    When I enter the RUNTIME-DERIVED date from Tosca expression "{SENDKEYS[{DATE[{DATE}][-1y][]}]}" in "Date Licensed" when "'State' == \"CA\" AND 'Operator Status' != \"NonDriver\"" is satisfied
    When I select "No" when "'Operator Status' == \"Assigned\"" is satisfied

    # Source step 0091: TBox Evaluation Tool | Module: TBox Evaluation Tool
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-2321-90b7-5cd6e4bfd3fd
    # Runtime control: If Yrs Licensed <= 3 > Condition
    Then if the source runtime condition "If Yrs Licensed <= 3 > Condition" is satisfied, "Expression" should equal the RUNTIME-DERIVED buffer expression "{B[Years Licensed]} <= \"3\""

    # Source step 0092: YrsLicensedAllStates_DateLicensed | Module: EQ || DriverLicense_Time
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-5889-ae29-39b8c9b6aa7a
    # Runtime control: If Yrs Licensed <= 3 > Then
    When if the source runtime condition "If Yrs Licensed <= 3 > Then" is satisfied, I enter captured runtime value "Years Licensed" in "YrsLicensed All States"
    When I enter captured runtime value "Date Licensed" in "Date Licensed" when "'Operator Status' != \"NonDriver\"" is satisfied
    When I select "Yes" when "'Operator Status' == \"Assigned\"" is satisfied
    When I select "No" when "'Operator Status' == \"Assigned\"" is satisfied

    # Source step 0093: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-3f2a-677b-a5aeebce3198
    # Runtime control: If Prior Ins Listed > Condition
    Then if the source runtime condition "If Prior Ins Listed > Condition" is satisfied, I wait until "Prior Carrier Name" is visible

    # Source step 0094: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-d416-61a7-7fe40775900b
    # Runtime control: If Prior Ins Listed > Then
    When if the source runtime condition "If Prior Ins Listed > Then" is satisfied, I enter or select "\"^{a}\"" in "Yrs Prior Carrier"
    When I enter or select "9" in "Yrs Prior Carrier"
    When I enter or select "\"^{a}\"" in "Months Prior Carrier"
    When I enter or select "9" in "Months Prior Carrier"
    When I click "Save and Continue"

    # Source step 0095: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-8e64-6429-3a375f05ba2c
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Condition
    Then if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Condition" is satisfied, I wait until "No" is visible

    # Source step 0096: Prior Insurance Info | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-476c-ab93-a11eedd97ffd
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Then
    When if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Then" is satisfied, I select "Yes"
    When I select "No"
    When I select "No Need - Was Not Licensed"
    When I click "Save and Continue"

    # Source step 0097: Save & Continue | Module: EQ || Prior Insurance Info
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-6f6e-66d7-0e6f7a2aaaf1
    # Runtime control: If Prior Ins Listed > Else > If No Prio Ins > Else
    When if the source runtime condition "If Prior Ins Listed > Else > If No Prio Ins > Else" is satisfied, I click "Save and Continue"

    # Source step 0098: EQ || Expired License Pop Up | Module: EQ || Expired License Pop Up
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-6e60-c8b5-b548104e2653
    # Runtime control: If License Expired Pop up > Condition
    Then if the source runtime condition "If License Expired Pop up > Condition" is satisfied, I wait until "CONTINUE" exists

    # Source step 0099: EQ || Expired License Pop Up | Module: EQ || Expired License Pop Up
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Additional Driver Information Summary (NEW) | Source XTestStep: 3a19e1e5-0cdf-88e6-af4d-c689742084c3
    # Runtime control: If License Expired Pop up > Then
    When if the source runtime condition "If License Expired Pop up > Then" is satisfied, I click "CONTINUE"

    # Source step 0100: EQ||Driver Information Next | Module: EQ||Driver Information Next
    # Section: Process > 04 Driver Information | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-3a3f-5f95-e7081f2cd971
    When I click "Btn_Next"

    # Source step 0101: EQ | Side Menu | Module: EQ | Side Menu
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-2bb8-d44c-bdda6126ad5c
    # Runtime control: 'Additional Drivers?' == "Yes"
    When if the source runtime condition "'Additional Drivers?' == \"Yes\"" is satisfied, I click "Driver Information"

    # Source step 0102: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-0828-ff66-1a82bd960ba2
    # Runtime control: If > Condition
    Then if the source runtime condition "If > Condition" is satisfied, I wait until "PrefilledDrivers" exists

    # Source step 0103: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-53ca-a517-f012a38d9d89
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I capture "ResultCount" from "PrefilledDrivers" as runtime value "NumberOfDrivers"

    # Source step 0104: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information > Repetition | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-955b-09d6-d7a8d79d80e7
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I enter or select "" in "MAT-FORM-FIELD"
    When I enter or select "{return}" in "Never resided in the household and doesn't regularly use or have access to policy vehicle(s)"

    # Source step 0105: Save & Continue | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-50c3-bf38-2ef127c8f25e
    # Runtime control: If > Then
    When if the source runtime condition "If > Then" is satisfied, I click "Save and Continue"

    # Source step 0106: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-391c-4683-2363a242b3c9
    # Runtime control: If > Else > If > Condition
    Then if the source runtime condition "If > Else > If > Condition" is satisfied, "Unselected Client Suggestions" should exist

    # Source step 0107: Prefil Household Drivers | Module: EQ || Prefil Household Drivers
    # Section: Process > 04 Driver Information | Reusable flow: Auto | 04 EQ | Household Driver Prefill (NEW) | Source XTestStep: 3a19dd55-d47f-c21c-d3f6-8683943ddec0
    # Runtime control: If > Else > If > Then
    When if the source runtime condition "If > Else > If > Then" is satisfied, I click "Save and Continue"

    # Source step 0108: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-6e8e-dc95-4ade758ab6aa
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Condition - If vehicle is selected" is satisfied, "btn_select vehicle1" should exist

    # Source step 0109: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-963b-5665-fed0872e34d2
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I wait until "Loading ..." exists

    # Source step 0110: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-a31a-cb1f-2f0f39344681
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    When if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I click "Btn_Additional Vehicle"
    When I click "Btn_Next"

    # Source step 0111: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Prefill Information | Source XTestStep: 3a19dd55-d461-f7a2-75d0-c298cb3735ee
    # Runtime control: EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary
    Then if the source runtime condition "EQ||Vehicle Information_VehicleSelection > Then - Select vehicle and continue with vehicle summary" is satisfied, I wait until "Loading ..." exists

    # Source step 0112: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-afa7-ce2a-49e2a1a52528
    When I retain the unresolved source parameter "Farm/Use" (not supplied by this reusable-block invocation) as runtime value "Farm/Use"
    When I retain the unresolved source parameter "PickUp" (not supplied by this reusable-block invocation) as runtime value "PickUp"
    When I retain the source TestCase-Design value "Drivers.State" (not resolved in this concrete export) as runtime value "State"
    When I retain the source TestCase-Design value "Company" (not resolved in this concrete export) as runtime value "Company"
    When I retain the unresolved source parameter "Loan" (not supplied by this reusable-block invocation) as runtime value "Loan"
    When I retain the unresolved source parameter "Lease" (not supplied by this reusable-block invocation) as runtime value "Lease"
    When I retain the unresolved source parameter "AntiTheft" (not supplied by this reusable-block invocation) as runtime value "AntiTheft"
    When I retain the unresolved source parameter "Business/Use" (not supplied by this reusable-block invocation) as runtime value "Business/Use"

    # Source step 0113: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-1b5f-b5d6-bda93b7ee7bb
    # Runtime control: Vehicles prefilled > Condition
    Then if the source runtime condition "Vehicles prefilled > Condition" is satisfied, I wait until "Btn_Additional Vehicle" is visible

    # Source step 0114: EQ||Vehicle Information | Module: EQ||Vehicle Information
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-06d7-3220-d1c09ab7d73d
    # Runtime control: Vehicles prefilled > Then
    When if the source runtime condition "Vehicles prefilled > Then" is satisfied, I click "Btn_Additional Vehicle"
    When I click "Btn_Next"

    # Source step 0115: EQ||Vehicle Vin | Module: EQ||Vehicle Auto Vin_1
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-ee03-30f7-e392bd393429
    Then I wait until "txt_VIN" is enabled
    When I click "txt_VIN"
    When I enter or select "2B3KA43R26H469054" in "txt_VIN"
    When I press "Tab" while focused on "txt_VIN"
    When I click "btn_vehicle1"
    When I click "btn_Vehicle3" when "'Farm/Use' != NULL" is satisfied

    # Source step 0116: EQ||Vehicle Summary Auto Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-95a2-8dfa-adebc59bdc38
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

    # Source step 0119: EQ||Vehicle Summary Auto Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-6791-46c6-6310caf1c65a
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

    # Source step 0120: EQ||Vehicle Summary Auto/Motor Home Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-9f5a-ca3a-bc6f332fa6c1
    # Runtime control: If Total Mileage exists > Condition
    Then if the source runtime condition "If Total Mileage exists > Condition" is satisfied, I wait until "txt_annual_mileage" exists

    # Source step 0121: EQ||Vehicle Summary Auto/Motor Home Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-4244-eb9a-8e8dddf39348
    # Runtime control: If Total Mileage exists > Then
    When if the source runtime condition "If Total Mileage exists > Then" is satisfied, I enter or select "\"^{a}\"" in "txt_annual_mileage"
    When I enter or select "8500" in "txt_annual_mileage"
    When I click "btnSave_Continue"

    # Source step 0122: EQ||Vehicle Summary Auto/Motor Home Use | Module: EQ||Vehicle Summary Auto/Motor Home Use
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Automobile/RV (NEW) | Source XTestStep: 3a19dd55-d47f-dffa-fa21-a9ab72d88e73
    # Runtime control: If Total Mileage exists > Else
    When if the source runtime condition "If Total Mileage exists > Else" is satisfied, I click "btnSave_Continue"

    # Source step 0123: EQ||Vehicle Summary Next/Add  | Module: EQ||Vehicle Summary Next/Add 
    # Section: Process > 05 Vehicle Summary | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-c60b-7bb6-1bd465571824
    When I click "btn_Add_Vehicle"

    # Source step 0124: EQ||Vehicle Summar Auto Additional | Module: EQ||Vehicle Summary Auto Additional
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-48da-571b-08a35d085e84
    Then I wait until "VIN" is enabled
    When I enter or select "1J4GL58K15W695449" in "VIN"
    When I press "Tab" while focused on "VIN"
    Then I wait until "Veh1" is enabled
    When I click "Veh1"
    Then I wait until "Own" is enabled
    When I click "Own"

    # Source step 0125: EQ||Vehicle Owned/Finance Popup | Module: EQ||Vehicle Owned/Finance Popup
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-fa74-b119-ee24bd588d9e
    # Runtime control: If Owned Pop up > Condition
    Then if the source runtime condition "If Owned Pop up > Condition" is satisfied, I wait until "Owned_CONTINUE" exists

    # Source step 0126: EQ||Vehicle Owned/Finance Popup | Module: EQ||Vehicle Owned/Finance Popup
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-5f6a-a5df-db8c87395e8b
    # Runtime control: If Owned Pop up > Then
    When if the source runtime condition "If Owned Pop up > Then" is satisfied, I click "Owned_CONTINUE"

    # Source step 0127: EQ||Vehicle Summar Auto Additional | Module: EQ||Vehicle Summary Auto Additional
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-5253-4990-575ea90c0b8e
    When I click "2_day" when "Company == \"FFCIC\" AND State == \"NY\"" is satisfied
    When I enter or select "6" in "Work_miles_day" when "State == \"NY\" AND Company == \"FFCIC\"" is satisfied
    When I enter or select "\"^{a}\"" in "Non_work_annual_Miles" when "State == \"NY\" AND Company == \"FFCIC\"" is satisfied
    When I enter or select "6000" in "Non_work_annual_Miles" when "State == \"NY\" AND Company == \"FFCIC\"" is satisfied
    When I select "Customized_No" when "NOT(State == \"VA\" OR (Company == \"FFCIC\" AND State == \"NY\"))" is satisfied
    When I click "CA_Use_Pleasure" when "State == \"CA\"" is satisfied
    When I enter or select "\"^{a}\"" in "Purchase_date"
    When I click "Purchase_date"
    When I enter or select "\"^{a}\"" in "Odometer"
    When I enter or select "60000" in "Odometer"

    # Source step 0128: EQ||Vehicle Summar Auto Additional | Module: EQ||Vehicle Summary Auto Additional
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-8570-38e6-c4467957836a
    # Runtime control: If Total Mileage exists > Condition
    Then if the source runtime condition "If Total Mileage exists > Condition" is satisfied, I wait until "Total_annual_mileage" exists

    # Source step 0129: EQ||Vehicle Summar Auto Additional | Module: EQ||Vehicle Summary Auto Additional
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-f3be-af84-cc30b0c88381
    # Runtime control: If Total Mileage exists > Then
    When if the source runtime condition "If Total Mileage exists > Then" is satisfied, I enter or select "\"^{a}\"" in "Total_annual_mileage"
    When I enter or select "900" in "Total_annual_mileage"
    When I click "Save_Continue"

    # Source step 0130: EQ||Vehicle Summar Auto Additional | Module: EQ||Vehicle Summary Auto Additional
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05  EQ |Vehicle Summary Automobile additional | Source XTestStep: 3a19dd55-d4ac-61e4-7f37-7dbf78572b6d
    # Runtime control: If Total Mileage exists > Else
    When if the source runtime condition "If Total Mileage exists > Else" is satisfied, I click "Save_Continue"

    # Source step 0131: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-6cc3-587f-71fd73c3c725
    When I retain the unresolved source parameter "CA Verified Mileage" (not supplied by this reusable-block invocation) as runtime value "CA Verified Mileage"

    # Source step 0132: EQ || CA Verified Mileage | Module: EQ || CA Verified Mileage
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-238f-a7b4-2a286e1f49c2
    When I click "Opt Out" when "'CA Verified Mileage' != NULL" is satisfied

    # Source step 0133: EQ||Vehicle Summary Next/Add  | Module: EQ||Vehicle Summary Next/Add 
    # Section: Process > 05 Vehicle Summary | Reusable flow: Auto | 05 EQ | Vehicle Summary Next | Source XTestStep: 3a19dd55-d461-f187-acde-56dc1d77b564
    Then I wait until "btn_Next" exists
    When I click "btn_Next"

    # Source step 0134: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 06 Driver Assignment | Reusable flow: Auto | 06 EQ | Driver Assignment | Source XTestStep: 3a19dd55-d461-7750-f7a7-0a4dfad39166
    When I retain hard-coded value "2006 Dodge CHARGER" as runtime value "Driver 1 Vehicle"
    When I retain hard-coded value "Principal" as runtime value "Driver 1 Principal Occasional"
    When I retain hard-coded value "2005 Jeep LIBERTY" as runtime value "Driver 2 Vehicle"
    When I retain hard-coded value "Principal" as runtime value "Driver 2 Principal Occasional"
    When I retain the unresolved source parameter "Driver 3 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 3 Vehicle"
    When I retain the unresolved source parameter "Driver 3 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 3 Principal Occasional"
    When I retain the unresolved source parameter "Driver 4 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 4 Vehicle"
    When I retain the unresolved source parameter "Driver 4 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 4 Principal Occasional"
    When I retain the unresolved source parameter "Driver 5 Vehicle" (not supplied by this reusable-block invocation) as runtime value "Driver 5 Vehicle"
    When I retain the unresolved source parameter "Driver 5 Principal Occasional" (not supplied by this reusable-block invocation) as runtime value "Driver 5 Principal Occasional"

    # Source step 0135: (New) EQ || Multiple Driver Assignment_1 | Module: (New) EQ || Multiple Driver Assignment
    # Section: Process > 06 Driver Assignment | Reusable flow: Auto | 06 EQ | Driver Assignment | Source XTestStep: 3a1a05eb-9533-f275-7cff-93b1b2320a32
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

    # Source step 0136: (New) EQ || Multiple Driver Assignment | Module: (New) EQ || Multiple Driver Assignment
    # Section: Process > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a1a060e-d6bf-4650-d2a9-eb8a36749c41
    # Runtime control: EQ || Driver Assignment Continue > Condition
    Then if the source runtime condition "EQ || Driver Assignment Continue > Condition" is satisfied, I wait until "CONTINUE" exists
    Then "CONTINUE" should exist

    # Source step 0137: (New) EQ || Multiple Driver Assignment | Module: (New) EQ || Multiple Driver Assignment
    # Section: Process > 06 Driver Assignment | Reusable flow: <none> | Source XTestStep: 3a1a060e-d6c0-23f6-947e-06db96980889
    # Runtime control: EQ || Driver Assignment Continue > Then
    When if the source runtime condition "EQ || Driver Assignment Continue > Then" is satisfied, I click "CONTINUE"

    # Source step 0138: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-31a1-ca62-9e77b036c44f
    Then I wait until "Loading ..." exists

    # Source step 0139: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-2773-f7f2-9ce4cfa0f433
    # Runtime control: Underwriting Popup Continue > Condition
    Then if the source runtime condition "Underwriting Popup Continue > Condition" is satisfied, I wait until "Lnk_UW_CONTINUE" exists
    Then "Lnk_UW_CONTINUE" should exist

    # Source step 0140: EQ||Claims\Violations | Module: EQ||Claims\Violations
    # Section: Process > 07 Claims\Violations | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-c66f-efbf-f1f38907022e
    # Runtime control: Underwriting Popup Continue > Then
    When if the source runtime condition "Underwriting Popup Continue > Then" is satisfied, I click "Lnk_UW_CONTINUE"

    # Source step 0141: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a210b32-90a1-416a-2a4e-cbc545f7aa3e
    When I retain hard-coded value "0" as runtime value "ClaimCount"

    # Source step 0142: Check for claims/violations needing edited | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d47f-d1d7-d3bf-5a1ad619f1df
    # Runtime control: While Edits Needed [max=30] > Condition
    Then if the source runtime condition "While Edits Needed [max=30] > Condition" is satisfied, I wait until "Edit Claim" exists

    # Source step 0143: Edit Item(s) | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-7158-5c0a-399d668795c5
    # Runtime control: While Edits Needed [max=30] > Loop
    When if the source runtime condition "While Edits Needed [max=30] > Loop" is satisfied, I click "Edit Claim"

    # Source step 0144: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a210b35-8dc4-e60e-2416-dcad7c60432f
    # Runtime control: While Edits Needed [max=30] > Loop
    When if the source runtime condition "While Edits Needed [max=30] > Loop" is satisfied, I derive and retain the RUNTIME-DERIVED buffer expression "{MATH[{B[ClaimCount]}+1]}" as runtime value "ClaimCount"

    # Source step 0145: If Claim | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-46b4-de3f-77dc236897bf
    # Runtime control: While Edits Needed [max=30] > Loop > If > Condition
    Then if the source runtime condition "While Edits Needed [max=30] > Loop > If > Condition" is satisfied, "claimDriver Not In Household" should exist

    # Source step 0146: Edit Claim | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-2ced-a12b-73ef153ad085
    # Runtime control: While Edits Needed [max=30] > Loop > If > Then
    When if the source runtime condition "While Edits Needed [max=30] > Loop > If > Then" is satisfied, I enter or select "{End}{Click}" in "claimDriver Not In Household"
    When I select "claimVehicle loaned to driver that does not/did not reside in household and has no access to vehicle(s) insured by American National"
    When I click "claim/violationSave and Continue"

    # Source step 0147: Edit Violation | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-6b21-cc41-2d4710d17d54
    # Runtime control: While Edits Needed [max=30] > Loop > If > Else 
    When if the source runtime condition "While Edits Needed [max=30] > Loop > If > Else" is satisfied, I enter or select "AA - Administrative Action" in "ComboBox"
    When I select "claim/violationDoes Not Apply"
    When I click "claim/violationSave and Continue"

    # Source step 0148: Check for PopUp | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-1edd-baa9-884315c266f1
    # Runtime control: While Edits Needed [max=30] > Loop > If > Else  > If PopUp > Condition
    Then if the source runtime condition "While Edits Needed [max=30] > Loop > If > Else > If PopUp > Condition" is satisfied, "CONTINUE_Doesn'tApply" should exist

    # Source step 0149: Select Continue | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-86b1-017c-63ac39019295
    # Runtime control: While Edits Needed [max=30] > Loop > If > Else  > If PopUp > Then
    When if the source runtime condition "While Edits Needed [max=30] > Loop > If > Else > If PopUp > Then" is satisfied, I click "CONTINUE_Doesn'tApply"

    # Source step 0150: Next | Module: EQ || ClaimsViolation (NEW)
    # Section: Process > 07 Claims\Violations | Reusable flow: Auto | 07 EQ | EditClaimsViolations (NEW) | Source XTestStep: 3a19dd55-d48e-1281-e07e-979d81b828f8
    When I click "Next"

    # Source step 0151: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-309c-daef-7f1e6adc660e
    Then I wait until "Loading ..." exists

    # Source step 0152: EQ||Discount - Rate Tier Questions | Module: EQ||Discount - Rate Tier Questions(NEW)
    # Section: Process > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-13e6-1b80-2723562372aa
    # Runtime control: State == "MD" OR State == "NJ"
    When if the source runtime condition "State == \"MD\" OR State == \"NJ\"" is satisfied, I enter or select "{end}{scroll[-2]}{Click}" in "Residentia_ Property_1"

    # Source step 0153: EQ||Discount - Rate Tier Questions | Module: EQ||Discount - Rate Tier Questions(NEW)
    # Section: Process > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-47c7-69bb-e9d363040925
    # Runtime control: If MD/NJ New Client > Condition
    When if the source runtime condition "If MD/NJ New Client > Condition" is satisfied, I click "Less than $30,000/$60,000" when "State == \"MD\"" is satisfied
    When I click "$15,000/$30,000" when "State == \"NJ\"" is satisfied

    # Source step 0155: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-f901-02fb-45a629220db2
    Then I wait until "Loading ..." exists

    # Source step 0156: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a1c89c6-be47-757e-f9da-b65e363f46bf
    When I retain the unresolved source parameter "Commercial Auto" (not supplied by this reusable-block invocation) as runtime value "Commercial Auto"
    When I retain the unresolved source parameter "Special Farm Package" (not supplied by this reusable-block invocation) as runtime value "Special Farm Package"
    When I retain the unresolved source parameter "Safe Cycle Discount" (not supplied by this reusable-block invocation) as runtime value "Safe Cycle Discount"
    When I retain the unresolved source parameter "Rider Group Discount" (not supplied by this reusable-block invocation) as runtime value "Rider Group Discount"

    # Source step 0157: EQ||Discount | Module: EQ||Discount(NEW)
    # Section: Process > 08 Discounts | Reusable flow: Auto | 08 EQ | Discount(NEW)_1 | Source XTestStep: 3a19dd55-d49d-b5be-0602-d50df53effaa
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

    # Source step 0158: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-df5b-2917-9300f04e4d69
    # Runtime control: Do [max=30] > Condition
    Then if the source runtime condition "Do [max=30] > Condition" is satisfied, "Loading ..." should exist

    # Source step 0159: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-0b9f-8bec-ef3f01ae1339
    # Runtime control: Do [max=30] > Loop > If > Condition
    Then if the source runtime condition "Do [max=30] > Loop > If > Condition" is satisfied, I wait until "Loading ..." exists

    # Source step 0160: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-0405-f757-fd79e257041e
    When I retain the unresolved source parameter "PolicyCovOption" (not supplied by this reusable-block invocation) as runtime value "PolicyCovOption"
    When I retain the unresolved source parameter "V1_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V1_CompCollOnly"
    When I retain hard-coded value "500" as runtime value "V1_CompDed"
    When I retain the unresolved source parameter "V1_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V1_CompDedMoreOpt"
    When I retain hard-coded value "500" as runtime value "V1_CollDed"
    When I retain the unresolved source parameter "V1_CollDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V1_CollDedMoreOpt"
    When I retain the unresolved source parameter "V2_CompCollOnly" (not supplied by this reusable-block invocation) as runtime value "V2_CompCollOnly"
    When I retain hard-coded value "500" as runtime value "V2_CompDed"
    When I retain the unresolved source parameter "V2_CompDedMoreOpt" (not supplied by this reusable-block invocation) as runtime value "V2_CompDedMoreOpt"
    When I retain hard-coded value "500" as runtime value "V2_CollDed"
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
    When I retain the source TestCase-Design value "Policy Coverage Option.Supplemental UM/UIM Opt In" (not resolved in this concrete export) as runtime value "Supplemental UM/UIM Opt In"
    When I retain the source TestCase-Design value "Policy Coverage Option.Supplemental UM/UIM Cov" (not resolved in this concrete export) as runtime value "Supplemental UM/UIM Cov"

    # Source step 0161: Select Policy Coverage Option | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-5e9f-ebb3-1a192f211891
    When I enter or select "True" in "Option 1" when "PolicyCovOption == \"OPTION 1\"" is satisfied
    When I enter or select "True" in "Option 2" when "PolicyCovOption == \"OPTION 2\"" is satisfied
    When I enter or select "True" in "Option 3" when "PolicyCovOption == \"OPTION 3\"" is satisfied
    When I click "EDIT COVERAGE Opt 1" when "PolicyCovOption == \"OPTION 1\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied
    When I click "EDIT COVERAGE Opt 2" when "PolicyCovOption == \"OPTION 2\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied
    When I click "EDIT COVERAGE Opt 3" when "PolicyCovOption == \"OPTION 3\" And (CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL)" is satisfied

    # Source step 0162: Edit Coverage Option | Module: Edit Coverage Option (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-747f-5f68-a24a43e77133
    Then I wait until "Supplemental UM/UIM Opt In" exists when "'Supplemental UM/UIM Opt In' != NULL" is satisfied
    When I click "Supplemental UM/UIM Opt In" when "'Supplemental UM/UIM Opt In' != NULL" is satisfied
    When I click "Supplemental UM/UIM Cov" when "'Supplemental UM/UIM Opt In' == \"Yes\"" is satisfied
    Then I wait until "UM Coverage" exists when "CovOptUninsured != NULL" is satisfied
    When I click "UM Coverage" when "CovOptUninsured != NULL" is satisfied
    When I click "Save and Continue" when "CovOptUninsured != NULL OR 'Supplemental UM/UIM Opt In' != NULL" is satisfied

    # Source step 0163: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-32f7-1e44-9a9fe0dd9489
    Then I wait until "Loading ..." exists

    # Source step 0164: Navigate down screen to V1 | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a19dd55-d452-3e28-b8c2-daa0d90c90cf
    When I enter or select "{scroll[5]}" in "Option 3"

    # Source step 0165: Select V1 Coverages | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c3-e0f6-3efb-694f-24775fc5daab
    When I select "V1_Comp/Coll Only - YES" when "V1_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V1_Comprehensive Only" is visible when "'V1_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V1_Comprehensive Only" when "'V1_Comprehensive Only' != NULL" is satisfied
    When I click "V1_ Comprehensive And Collision Only" when "'V1_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V1_Comprehensive Deductible" should be visible when "V1_CompDed != NULL" is satisfied
    When I click "V1_CompDed" when "V1_CompDed != NULL" is satisfied
    When I click "V1_CompDedMoreOpt" when "V1_CompDedMoreOpt != NULL" is satisfied
    When I click "V1_CollDed" when "V1_CollDed != NULL AND V1_CompDed != NoCoverage" is satisfied
    When I click "V1_CollDedMoreOpt" when "V1_CollDedMoreOpt != NULL" is satisfied

    # Source step 0166: Navigate down screen to V2 | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-3cfb-5615-691d-4c4a67bb0dbb
    When I enter or select "{scroll[8]}" in "Option 3"

    # Source step 0167: Select V2 Coverages | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c3-f19a-4442-63dd-29bc94d7f23f
    When I select "V2_Comp/Coll Only - YES" when "V2_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V2_Comprehensive Only" is visible when "'V2_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V2_Comprehensive Only" when "'V2_Comprehensive Only' != NULL" is satisfied
    When I click "V2_Comprehensive And Collision Only" when "'V2_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V2_Comprehensive Deductible" should be visible when "V2_CompDed != NULL" is satisfied
    When I click "V2_CompDed" when "V2_CompDed != NULL" is satisfied
    When I click "V2_CompDedMoreOpt" when "V2_CompDedMoreOpt != NULL" is satisfied
    When I click "V2_CollDed" when "V2_CollDed != NULL" is satisfied
    When I click "V2_CollDedMoreOpt" when "V2_CollDedMoreOpt != NULL" is satisfied

    # Source step 0168: Navigate down screen to V3 | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-52a4-fe82-3bb0-369449699a34
    When I enter or select "{end}{scroll[-4]}" in "Next"

    # Source step 0169: Select V3 Coverages | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c4-0473-3bb0-3efe-79d19dce2cb1
    When I select "V3_Comp/Coll Only - YES" when "V3_CompCollOnly == \"Yes\"" is satisfied
    Then I wait until "V3_Comprehensive Only" is visible when "'V3_Comprehensive Only' != NULL" is satisfied
    When I enter or select "True" in "V3_Comprehensive Only" when "'V3_Comprehensive Only' != NULL" is satisfied
    When I click "V3_Comprehensive And Collision Only" when "'V3_ Comprehensive And Collision Only' != NULL" is satisfied
    Then "V3_Comprehensive Deductible" should be visible when "V3_CompDed != NULL" is satisfied
    When I click "V3_CompDed" when "V3_CompDed != NULL" is satisfied
    When I click "V3_CompDedMoreOpt" when "V3_CompDedMoreOpt != NULL" is satisfied
    When I click "V3_CollDed" when "V3_CollDed != NULL" is satisfied
    When I click "V3_CollDedMoreOpt" when "V3_CollDedMoreOpt != NULL" is satisfied

    # Source step 0170: Navigate down screen to V4 | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1ca-5e76-1997-a9d2-51a01da87768
    When I enter or select "{end}" in "Next"

    # Source step 0171: Select V4 Coverages | Module: Coverages (New)
    # Section: Process > 09 Coverages | Reusable flow: Auto | 09 EQ | Coverages | Source XTestStep: 3a20e1c4-0dd3-f974-c0cc-517e7c067a4f
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

    # Source step 0185: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.1 EQ | Auto_AddlCov Policy Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-9926-83e8-e1b36f088d6a
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Auto Group 1.Tort Option" (not resolved in this concrete export) as runtime value "Tort Option"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Auto Group 1.Income Loss" (not resolved in this concrete export) as runtime value "Income Loss Coverage"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Auto Group 1.Uninsured Motorists PD" (not resolved in this concrete export) as runtime value "UMPD"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Auto Group 1.UnderInsured Motorists PD" (not resolved in this concrete export) as runtime value "UIMPD"
    When I retain hard-coded value "No Coverage" as runtime value "AD&D Coverage"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Auto Group 1.Inc Liability for Claims of Family Members" (not resolved in this concrete export) as runtime value "Inc Liab Claims Fam Mem"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Auto Group 1.Extraordinary Medical Benefit" (not resolved in this concrete export) as runtime value "Extraordinary Medical Benefit"

    # Source step 0186: EQ || Other Policy Coverages Section | Module: EQ || Other Policy Coverages Section (New)
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.1 EQ | Auto_AddlCov Policy Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-dfa9-eb55-3377c15e84f9
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

    # Source step 0187: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.2 EQ | Auto_AddlCov PIP (NEW) | Source XTestStep: 3a19dd55-d49d-2319-e8b1-e935b78ef386
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.All HH Members 65 or Pension" (not resolved in this concrete export) as runtime value "All HH Members 65 or Pension"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.PIP Limit" (not resolved in this concrete export) as runtime value "PIP Limit"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.PIP Deductible" (not resolved in this concrete export) as runtime value "PIP Deductible"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Additional PIP" (not resolved in this concrete export) as runtime value "Additional PIP"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.PIP Stacking" (not resolved in this concrete export) as runtime value "PIP Stacking"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Extra PIP Option" (not resolved in this concrete export) as runtime value "Extra PIP Option"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Auto Health Insurer" (not resolved in this concrete export) as runtime value "Auto Health Insurer"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Medical Expense Elimination" (not resolved in this concrete export) as runtime value "Medical Expense Elimination"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Work Loss Benefits" (not resolved in this concrete export) as runtime value "Work Loss Benefits"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Broadened PIP" (not resolved in this concrete export) as runtime value "Broadened PIP"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Additional Death Benefit" (not resolved in this concrete export) as runtime value "Additional Death Benefit"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.PIP_Happy Path.Waiver of Income Loss" (not resolved in this concrete export) as runtime value "Waiver of Income Loss"

    # Source step 0188: EQ || Personal Injury Protection Section  | Module: EQ || Personal Injury Protection Section (New)
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.2 EQ | Auto_AddlCov PIP (NEW) | Source XTestStep: 3a19dd55-d49d-5cf9-bd48-8bc37f54be1b
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

    # Source step 0189: TBox Set Buffer | Module: TBox Set Buffer
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-03d7-fc05-9d8e00af290c
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Vehicle Coverages_Happy Path.Vehicle 1.Uninsured/Underinsured Motorist PD (UMPD/UIMPD" (not resolved in this concrete export) as runtime value "UMPD/UIMPD_V1"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Vehicle Coverages_Happy Path.Vehicle 1.Uninsured Motorist PD (UMPD)" (not resolved in this concrete export) as runtime value "UMPD Coverage_V1"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Vehicle Coverages_Happy Path.Vehicle 1.UMPD More Options Coverages_V1" (not resolved in this concrete export) as runtime value "UMPD More Options Coverages_V1"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Vehicle Coverages_Happy Path.Vehicle 1.Underinsured Motorist PD (UIMPD)" (not resolved in this concrete export) as runtime value "UIMPD Coverage_V1"
    When I retain hard-coded value "$40" as runtime value "Rental Reimbursement Coverage_V1"
    When I retain the source TestCase-Design value "Additional Coverages_Happy Path.Vehicle Coverages_Happy Path.Vehicle 1.Theft Deductible" (not resolved in this concrete export) as runtime value "Theft Deductible_V1"
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

    # Source step 0190: EQ || Vehicle Coverages Section | Module:  EQ || Vehicle Coverages Section
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.3 EQ | Auto_AddlCov Vehicle Coverages (NEW) | Source XTestStep: 3a19dd55-d49d-761f-6f46-c2b18955c6fe
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

    # Source step 0191: Additional Coverages Next | Module: EQ || Additional Coverages Next (New)
    # Section: Process > 10 Additional Coverage | Reusable flow: Auto | 10.4 EQ | Auto_AddlCov Next (NEW) | Source XTestStep: 3a19dd55-d49d-96a9-0aec-e6aed537490d
    When I click "Next"

    # Source step 0192: EQ || Pricing Details (New) | Module: EQ || Pricing Details (New)
    # Section: Process > 11 Pricing | Reusable flow: Auto | 11 EQ | Happy Path_Pricing Page  | Source XTestStep: 3a19dd55-d48e-d305-1d73-388985eda2c9
    Then I wait until "Header Pricing Details" exists
    When I click "Next"

    # Source step 0193: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 11 Pricing | Reusable flow: Auto | 11 EQ | Happy Path_Pricing Page  | Source XTestStep: 3a19dd55-d48e-d8c5-f9f6-869ea583e4c6
    Then I wait until "Loading ..." exists

    # Source step 0194: EQ | Underwriting Eligibility Restrictions | Module: EQ | Underwriting Eligibility Restrictions
    # Section: Process > 12 Underwriting > EQ | Underwriting Eligibility Restrictions | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-d1ef-8e82-01e2c1104d3f
    Then I wait until "Header Underwriting" exists
    When I select "Yes"
    When I enter or select "{Click}{end}" in "No"

    # Source step 0195: EQ | Underwriting Collector And Vintage Information | Module: EQ | Underwriting Collector And Vintage Information
    # Section: Process > 12 Underwriting > EQ | Underwriting Collector And Vintage Information | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-a37d-0993-113ea0e74500
    # Runtime control: EQ | Underwriting Collector And Vintage Information > Condition
    Then if the source runtime condition "EQ | Underwriting Collector And Vintage Information > Condition" is satisfied, I wait until "Are all collector vehicles kept in a fully enclosed and locked structure?" is visible

    # Source step 0196: EQ | Underwriting Collector And Vintage Information | Module: EQ | Underwriting Collector And Vintage Information
    # Section: Process > 12 Underwriting > EQ | Underwriting Collector And Vintage Information | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-ef81-543f-210923711451
    # Runtime control: EQ | Underwriting Collector And Vintage Information > Then
    When if the source runtime condition "EQ | Underwriting Collector And Vintage Information > Then" is satisfied, I select "Yes"

    # Source step 0197: EQ | Underwriting Underwriting Next | Module: EQ | Underwriting Underwriting Next
    # Section: Process > 12 Underwriting | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a19dd55-d48e-9e3c-e2f0-4fa80c4245ab
    When I click "Next"

    # Source step 0198: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 12 Underwriting | Reusable flow: Auto | 12 EQ | Underwriting Page Auto | Source XTestStep: 3a1b01b4-37fa-c628-2432-74737edb16f7
    When I perform the source-defined operation "EQ |Common|Loading Indicator Wait" in module "EQ |Common|Loading Indicator Wait"

    # Source step 0199: AdditionalInterest | Module: EQ || AdditionalInterest
    # Section: Process > 13 Additional Interest | Reusable flow: Auto | 13 EQ | Additional Interest Page | Source XTestStep: 3a19dd55-d4bb-a454-ca62-5a4cc15f71f7
    When I click "Next"

    # Source step 0200: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait
    # Section: Process > 13 Additional Interest | Reusable flow: Auto | 13 EQ | Additional Interest Page | Source XTestStep: 3a1b0169-7a5f-2a20-be85-cc3814410f19
    When I perform the source-defined operation "EQ |Common|Loading Indicator Wait" in module "EQ |Common|Loading Indicator Wait"

    # Source step 0201: Billing-Create and Update Billing details | Module: EQ||Billing
    # Section: Process > 14 Billing Details | Reusable flow: Home & Auto |12 EQ | Billing Direct Pay | Source XTestStep: 3a19dd55-d416-819e-dff4-9b838366dca2
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

    # Source step 0206: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-678d-35f1-44cb42bd42a1
    # Runtime control: If Correction Needed > Condition Correction Needed Visible
    Then if the source runtime condition "If Correction Needed > Condition Correction Needed Visible" is satisfied, "Correction Needed Step 1" should exist

    # Source step 0207: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-78eb-7e86-0c69593dd72b
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "SaveExit_1"

    # Source step 0208: OpenUrl | Module: OpenUrl
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0212: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0213: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0214: EU||Home | Module: EU||Home
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0215: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0216: EU||Applicant | Module: EU||Applicant
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "Lnk_Pricing"

    # Source step 0217: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0218: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Condition
    Then if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0219: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Then
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9 > If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0222: CloseBrowser | Module: CloseBrowser
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 Express Level 9 bypass > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I close the active browser

    # Source step 0223: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-3597-854a-48cd2f94a920
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0224: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 Express Level 9 bypass | Source XTestStep: 3a19e1e5-0ccd-4570-5e7e-f6661e969808
    # Runtime control: If Correction Needed > Then go to Express to bypass L9
    When if the source runtime condition "If Correction Needed > Then go to Express to bypass L9" is satisfied, I click "DIV_Submission"

    # Source step 0261: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-5fda-b2fb-7d9202bb7c40
    Then I wait until "Submission_1" exists

    # Source step 0262: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-0405-6aeb-e03a8a879562
    # Runtime control: While Comments  [max=10] > Condition
    Then if the source runtime condition "While Comments [max=10] > Condition" is satisfied, "Comments" should exist

    # Source step 0263: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission > Comments | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-24d4-58ea-b3b007866a02
    # Runtime control: While Comments  [max=10] > Loop > If > Condition
    Then if the source runtime condition "While Comments [max=10] > Loop > If > Condition" is satisfied, "Comments" should exist

    # Source step 0264: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission > Comments | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-fc27-ff5e-eddbf892e12e
    # Runtime control: While Comments  [max=10] > Loop > If > Then
    When if the source runtime condition "While Comments [max=10] > Loop > If > Then" is satisfied, I enter or select "\"Test\"" in "Comments"

    # Source step 0265: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-df70-4c5e-bc47d782b4cd
    # Runtime control: If Referral Button  > Condition
    Then if the source runtime condition "If Referral Button > Condition" is satisfied, "ReferUW" should be visible

    # Source step 0266: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) | Source XTestStep: 3a19dd55-d49d-5e68-6b54-41c4c6120974
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "ReferUW"
    When I click "SaveExit_1"

    # Source step 0284: EQ || OpenUrl | Module: EQ || OpenUrl
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > Open URL | Source XTestStep: 3a1abacb-9c11-d635-aec9-d96efada9152
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0285: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1da9bf-638d-557b-2d67-5eca96520ce5
    # Runtime control: If Referral Button  > Then > If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If Referral Button > Then > If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0286: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1da9bf-639c-e3a7-4507-e7e068e6b07c
    # Runtime control: If Referral Button  > Then > If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If Referral Button > Then > If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0287: EU||Home | Module: EU||Home
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-17af-eac2-efc85049f006
    # Runtime control: If Referral Button  > Then
    Then if the source runtime condition "If Referral Button > Then" is satisfied, I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0288: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-776f-690b-c57137d617c8
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "Policy/Quote#"

    # Source step 0289: EU||Applicant | Module: EU||Applicant
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-dd12-e647-1b7133cb86df
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "Lnk_Pricing"

    # Source step 0290: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-df28-5b9a-9aa2498a2226
    # Runtime control: If Referral Button  > Then
    Then if the source runtime condition "If Referral Button > Then" is satisfied, I wait until "Txt_Underwriting Notes *" is enabled
    When I enter or select "{Click}{SENDKEYS[Approved]}" in "Txt_Underwriting Notes *"
    Then I wait until "Btn_Approve" is visible
    When I click "Btn_Approve"
    When I click "Lnk_Home"

    # Source step 0291: CloseBrowser | Module: CloseBrowser
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 | Source XTestStep: 3a1d2a06-6143-3187-745d-aac57504448a
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I close the active browser

    # Source step 0292: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > EQ | Recall Quote in EQ | Source XTestStep: 3a1d37b5-c754-fa99-186e-4cdf3e363d8c
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0293: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ | Submission UW Comments/Review (NEW) > Auto | 15 EQ| Express UW Review without L9 > EQ | Recall Quote in EQ | Source XTestStep: 3a1d37b5-c766-2435-d5f0-9d921f232fa6
    # Runtime control: If Referral Button  > Then
    When if the source runtime condition "If Referral Button > Then" is satisfied, I click "DIV_Submission"

    # Source step 0297: OpenUrl | Module: OpenUrl
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI > zz Open URL | Source XTestStep: 3a19dd55-d3bc-f112-92ef-4713bf05610b
    When I open the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)

    # Source step 0301: Verify if ExpressUI login page is shown | Module: EU||Login
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-8c15-36db-08c856886941
    # Runtime control: If_ExpressUI Login Page showed up > Condition
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Condition" is satisfied, "Lbl_Login ID" should be visible

    # Source step 0302: Provide Express UI Login credentials | Module: EU||Login
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-627e-ba49-d8b2-c1e2bab53d2d
    # Runtime control: If_ExpressUI Login Page showed up > Then
    Then if the source runtime condition "If_ExpressUI Login Page showed up > Then" is satisfied, I wait until "Txt_Login ID_1" exists
    When I enter or select "AQ7314" in "Txt_Login ID_1"
    When I enter the RUNTIME-CONFIGURED protected Tosca-encrypted source value in "Password"
    When I click "Lnk_LOGIN"

    # Source step 0303: EU||Home | Module: EU||Home
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-b81f-072e-24f85ce7a961
    Then I wait until "Txt_Search Type" is visible
    When I enter captured runtime value "QuoteNumber" in "Txt_Search Text"
    When I click "Btn_Search"

    # Source step 0304: EU|Home | Module: EU|Home/Motorcycle/PersonalAuto
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-8a84-0a79-0d37ab5438c7
    When I click "Policy/Quote#"
    When I click "Lnk_Motorcycle" when "MotorCycle != NULL" is satisfied
    When I click "Lnk_PersonalAuto" when "PersonalAuto != NULL" is satisfied
    When I click "Lnk_RV" when "RV != NULL" is satisfied

    # Source step 0305: EU||Applicant | Module: EU||Applicant
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-ec2f-dbdd-68c9e7781526
    When I click "Lnk_Pricing"

    # Source step 0306: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d3d3c-12ad-c4e4-409e-18e3bbd2a5e8
    When I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0307: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-1c80-710d-3201657a5736
    # Runtime control: If Level 9 exists > Condition
    Then if the source runtime condition "If Level 9 exists > Condition" is satisfied, "ChkBox_Bypass Level 9 Rules" should be enabled

    # Source step 0308: EU||Pricing | Module: EU||Pricing
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-d23e-8b35-10a1f408ef8f
    # Runtime control: If Level 9 exists > Then
    When if the source runtime condition "If Level 9 exists > Then" is satisfied, I enter or select "True" in "ChkBox_Bypass Level 9 Rules"
    When I click "Bypass Level 9 Comments_1"
    When I enter or select "Approved" in "Bypass Level 9 Comments_1"
    When I press "Tab" while focused on "Bypass Level 9 Comments_1"
    When I click "Lnk_Home"

    # Source step 0311: CloseBrowser | Module: CloseBrowser
    # Section: Process > 15 Submission > Approve in Express UI | Reusable flow: Auto | 15 EQ| Express UW Review > Express|Approve UW referal in Express UI | Source XTestStep: 3a1d37e5-628f-7e6a-565b-2e3c24e46cb3
    When I close the active browser

    # Source step 0312: Recall Quote\Policy | Module: EQ||New Quote
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ| Express UW Review | Source XTestStep: 3a19e1e5-0cbf-1406-4bee-4dcaac1e1669
    When I enter or select "\"^{a}\"" in "Txt_Quote\\Policy Search"
    When I enter captured runtime value "QuoteNumber" in "Txt_Quote\\Policy Search"
    When I click "Btn_Search"

    # Source step 0313: EQ||Click on Submission Page | Module: EQ||Auto Tabs
    # Section: Process > 15 Submission | Reusable flow: Auto | 15 EQ| Express UW Review | Source XTestStep: 3a19e1e5-0cbf-0464-b4c5-e67a9197d671
    When I click "DIV_Submission"

    # Source step 0314: EQ||Submission - UW Comments(NEW) | Module: EQ||Submission (NEW)
    # Section: Process > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-3e09-b878-6e62408fbd61
    When I click "Checklist_1"

    # Source step 0315: EQ||Agent List count capture | Module: EQ||Agent List count capture
    # Section: Process > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-4353-149b-daba614be6e5
    When I capture "InnerText" from "DIV_Agent Documents Count" as runtime value "AgentList count"

    # Source step 0316: EQ||ECheckList | Module: EQ||ECheckList
    # Section: Process > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-c17f-736a-d3c52a1c9db4
    When I click "Lnk_Auto/Cycle/RV Application"
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0317: TBox Save As | Module: TBox Save As
    # Section: Process > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-aacd-b5ac-657e4832e6f3
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist1.png" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0318: EQ||ECheckList_1 | Module: EQ||ECheckList
    # Section: Process > 16 Launch Checklist > EU||Uploading_Docs | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-b8d9-b16b-057f5a30b083
    When I click "DIV_Drag and Drop files here to upload (or click here to open a file explorer)"

    # Source step 0320: TBox Save As_1 | Module: TBox Save As
    # Section: Process > 16 Launch Checklist > EU||Uploading_Docs | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-fa06-d749-6feed4b2eadb
    When I enter or select "Open" in "Caption"
    When I enter or select "\\\\fs1\\public\\Tosca\\PL DC Automation\\Samplechecklist2.jpg" in "FilePath"
    When I enter or select "Open" in "Button"

    # Source step 0321: CloseBrowser | Module: CloseBrowser
    # Section: Process > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-7326-8d73-7c7fc0692bd4
    When I close the active browser

    # Source step 0322: EQ|| Checklist Close | Module: EQ|| Checklist Close
    # Section: Process > 16 Launch Checklist | Reusable flow: Auto | 16 EQ| Checklist | Source XTestStep: 3a19dd55-d48e-df50-487a-983ad17c1dff
    When I click "Btn_Ok"

    # Source step 0323: EQ||Submission (NEW) | Module: EQ||Submission (NEW)
    # Section: Process > TDS Validations | Reusable flow: Auto | 17 EQ | Transmit | Source XTestStep: 3a19dd55-d48e-82a4-34a0-f9472b13da42
    Then I wait until "Transmit" exists
    When I click "Transmit"

    # Source step 0324: Submission_1-Back to Submission page | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-531b-8626-eff911da355f
    When I capture "InnerText" from "Lbl_Value_Total Policy Premium" as runtime value "Premium"
    When I capture "InnerText" from "Lbl_Value_Effective Date" as runtime value "Effective Date"
    When I capture "InnerText" from "Lbl_Value_Policy Number" as runtime value "Policy Number"
    When I capture "InnerText" from "Lbl_Value_Checklist Id" as runtime value "CheckList ID"

    # Source step 0325: TestData - Create & provide new item | Module: TestData - Create & provide new item
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-2d42-833f-9f15a7a197fd
    When I retrieve test data through TDM operation "TestData - Create & provide new item"
    And I use TDM parameter "Existing or new TDS type" with "MegaAuto_PolicyData_Regression"
    And I use TDM parameter "Data structure > PolicyNumber" with captured runtime value "Policy Number"
    And I use TDM parameter "Data structure > Premium" with captured runtime value "Premium"
    And I use TDM parameter "Data structure > EffectiveDate" with captured runtime value "Effective Date"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE} {TIME}"
    And I use TDM parameter "Data structure > TestCase" with "Auto - TC10_Mega Auto Policy 07_NM"
    And I use TDM parameter "Data structure > Endorsement" with "N"
    And I use TDM parameter "Data structure > State" with "NM"

    # Source step 0326: Submission_2-Save & Exit | Module: EQ||Submission
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-19e7-da7c-6556824ddc7d
    When I click "Btn_Save and Exit"

    # Source step 0327: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-1c74-8f83-45e3-1f66c1448547
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0018 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 2. Source step 0023 field "Drpdwn_State" in "Account Details-Enter new Account Information" was disabled. Reason:  
#    - Preserved source value: ""
# 3. Source step 0028 field "PROCEED" in "Proposal Details/Start" was disabled. Reason:  
#    - Preserved source value: "True"
# 4. Source step 0028 field "PROCEED" in "Proposal Details/Start" was disabled. Reason:  
#    - Preserved source value: "{Click}"
# 5. Source step 0029 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - VERIFY "County_ComboBox" with "True"
# 6. Source step 0030 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - INPUT "County_ComboBox" with the unresolved source parameter "County Name" (not supplied by this reusable-block invocation)
#    - INPUT "Start Quote" with "X"
#    - WAIT "PROCEED" with "True"
#    - INPUT "PROCEED" with "X"
# 7. Source step 0031 "Proposal Details/Start" in module "EQ || Proposal Details/Start" was disabled. Reason: 07.11.25 15:16:11 [ff01620@dnanico1.aniconet.com]
#    - INPUT "Start Quote" with "X"
# 8. Source step 0045 "NamedIns_Operator Status_MT" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 03.06.26 09:09:31 [pa2096@dnanico1.aniconet.com]
#    - INPUT "First Name_Driver1" with the source TestCase-Design value "Drivers.First Name" (not resolved in this concrete export)
#    - INPUT "Last Name_Driver1" with the source TestCase-Design value "Drivers.Last Name" (not resolved in this concrete export)
#    - INPUT "DOB_Driver1" with the unresolved source parameter "DOB" (not supplied by this reusable-block invocation)
#    - INPUT "More Options (Relation to Account Owner)" with ""
#    - WAIT "More Options (Relation to Account Owner)" with "True"
#    - INPUT "More Options (Relation to Account Owner)" with "X"
#    - WAIT "Account Owner" with "True"
#    - INPUT "Account Owner" with "{Click}"
#    - INPUT "SSN" with the source TestCase-Design value "Drivers.SSN" (not resolved in this concrete export)
#    - INPUT "MT National Guard" with "X"
# 9. Source step 0046 "Gender Enabled?" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 01.06.26 16:18:37 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Gender" with "True"
# 10. Source step 0047 "NamedIns_Operator Status" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 01.06.26 16:18:37 [pa2096@dnanico1.aniconet.com]
#    - CONTAINER "Gender" with "True"
#    - INPUT "Male" with "X"
#    - INPUT "Female" with "X"
# 11. Source step 0057 field "More Options (Operator Status)" in "NamedIns_Operator Status_Cycle" was disabled. Reason:  
#    - Preserved source value: "X"
# 12. Source step 0058 field "More Options (Operator Status)" in "NamedIns_Operator Status" was disabled. Reason:  
#    - Preserved source value: "X"
# 13. Source step 0059 field "Driver Name" in "License Info" was disabled. Reason:  
#    - Preserved source value: "Driver_1"
# 14. Source step 0077 field "Data search filter > Auto" in "TestData - Find & provide item" was disabled. Reason:  
#    - Preserved source value: "N"
# 15. Source step 0079 "TBox Evaluation Tool" in module "TBox Evaluation Tool" was disabled. Reason: 31.03.25 13:08:25 [pa3462@dnanico1.aniconet.com]
#    - VERIFY "Expression" with the RUNTIME-DERIVED buffer expression "{B[Gender]}==M"
# 16. Source step 0080 "NamedIns_Operator Status" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 31.03.25 13:08:25 [pa3462@dnanico1.aniconet.com]
#    - INPUT "First Name_additionalDriver" with the source TestCase-Design value "Drivers.First Name" (not resolved in this concrete export)
#    - INPUT "Last Name_additionalDriver" with the source TestCase-Design value "Drivers.Last Name" (not resolved in this concrete export)
#    - INPUT "DOB_additionalDriver" with the source TestCase-Design value "Drivers.Date of Birth" (not resolved in this concrete export)
#    - INPUT "DOB_additionalDriver" with ""
#    - INPUT "Male" with "X"
#    - INPUT "Single" with "X"
#    - INPUT "Married" with "X"
#    - INPUT "Divorced" with "X"
#    - INPUT "Spouse" with "X"
#    - INPUT "Son" with "X"
#    - INPUT "Daughter" with "X"
#    - INPUT "More Options (Relation to Account Owner)" with "X"
#    - WAIT "Extended Family" with "True"
#    - INPUT "Extended Family" with "X"
#    - WAIT "Is this driver a named insured?" with "True"
#    - INPUT "Primary Named Insured" with "X"
#    - INPUT "Named Insured" with "X"
#    - INPUT "Not a Named Insured" with "X"
#    - INPUT "Assigned" with "X"
#    - INPUT "Non Driver" with "X"
#    - INPUT "Related" with "X"
#    - INPUT "More Options (Operator Status)" with "X"
#    - INPUT "Military" with "X"
#    - INPUT "Missionary" with "X"
#    - INPUT "Other Insurance" with "X"
#    - INPUT "School > 100mi from home" with "X"
#    - WAIT "CarAtSchool_Yes" with "True"
#    - INPUT "CarAtSchool_Yes" with "X"
#    - INPUT "CarAtSchool_No" with "X"
#    - WAIT "Non-Driver Reason" with "True"
#    - INPUT "Never Licensed" with "X"
#    - INPUT "Underage" with "X"
#    - INPUT "Medical Condition" with "X"
#    - INPUT "More Options_NonDriver" with "X"
#    - INPUT "Surrendered" with "X"
#    - INPUT "Permit Driver" with "X"
# 17. Source step 0081 "NamedIns_Operator Status" in module "EQ || NamedIns_Operator Status" was disabled. Reason: 31.03.25 13:08:25 [pa3462@dnanico1.aniconet.com]
#    - INPUT "First Name_additionalDriver" with the source TestCase-Design value "Drivers.First Name" (not resolved in this concrete export)
#    - INPUT "Last Name_additionalDriver" with the source TestCase-Design value "Drivers.Last Name" (not resolved in this concrete export)
#    - INPUT "DOB_additionalDriver" with the source TestCase-Design value "Drivers.Date of Birth" (not resolved in this concrete export)
#    - INPUT "DOB_additionalDriver" with ""
#    - INPUT "Female" with "X"
#    - INPUT "Single" with "X"
#    - INPUT "Married" with "X"
#    - INPUT "Divorced" with "X"
#    - INPUT "Spouse" with "X"
#    - INPUT "Son" with "X"
#    - INPUT "Daughter" with "X"
#    - INPUT "More Options (Relation to Account Owner)" with "X"
#    - WAIT "Extended Family" with "True"
#    - INPUT "Extended Family" with "X"
#    - WAIT "Is this driver a named insured?" with "True"
#    - INPUT "Primary Named Insured" with "X"
#    - INPUT "Named Insured" with "X"
#    - INPUT "Not a Named Insured" with "X"
#    - INPUT "Assigned" with "X"
#    - INPUT "Non Driver" with "X"
#    - INPUT "Related" with "X"
#    - INPUT "More Options (Operator Status)" with "X"
#    - INPUT "Military" with "X"
#    - INPUT "Missionary" with "X"
#    - INPUT "Other Insurance" with "X"
#    - INPUT "School > 100mi from home" with "X"
#    - WAIT "CarAtSchool_Yes" with "True"
#    - INPUT "CarAtSchool_Yes" with "X"
#    - INPUT "CarAtSchool_No" with "X"
#    - WAIT "Non-Driver Reason" with "True"
#    - INPUT "Never Licensed" with "X"
#    - INPUT "Underage" with "X"
#    - INPUT "Medical Condition" with "X"
#    - INPUT "More Options_NonDriver" with "X"
#    - INPUT "Surrendered" with "X"
#    - INPUT "Permit Driver" with "X"
# 18. Source step 0116 field "btn_Customized_No" in "EQ||Vehicle Summary Auto Use" was disabled. Reason:  
#    - Preserved source value: "X"
# 19. Source step 0117 "EQ||Vehicle Summary Auto/Motor Home Use" in module "EQ||Vehicle Summary Auto/Motor Home Use" was disabled. Reason: 05.05.25 16:19:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Title_transfer_No" with "True"
# 20. Source step 0118 "EQ||Vehicle Summary Auto/Motor Home Use" in module "EQ||Vehicle Summary Auto/Motor Home Use" was disabled. Reason: 05.05.25 16:19:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title_transfer_Yes" with "X"
# 21. Source step 0146 field "claim/violationDoes Not Apply" in "Edit Claim" was disabled. Reason:  
#    - Preserved source value: "X"
# 22. Source step 0154 "EQ||Discount - Rate Tier Questions" in module "EQ||Discount - Rate Tier Questions(NEW)" was disabled. Reason: 15.04.25 14:50:31 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Less than $15,000/$30,000" with "{Click}"
# 23. Source step 0172 "V1 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V1_Comp/Coll Only - YES" with "X"
#    - WAIT "V1_Comprehensive Only" with "True"
#    - INPUT "V1_Comprehensive Only" with "X"
#    - INPUT "V1_ Comprehensive And Collision Only" with "X"
#    - VERIFY "V1_Comprehensive Deductible" with "True"
#    - INPUT "V1_CompDed" with "X"
#    - INPUT "V1_CompDedMoreOpt" with "X"
# 24. Source step 0173 "V1 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V1_CollDed" with "X"
#    - INPUT "V1_CollDedMoreOpt" with "X"
# 25. Source step 0174 "V2 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
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
# 26. Source step 0175 "V2 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CollDed" with "X"
#    - INPUT "V2_CollDedMoreOpt" with "X"
#    - INPUT "V4_CompDedMoreOpt" with "X"
# 27. Source step 0176 "V3 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CompDed" with "X"
#    - INPUT "V3_Comp/Coll Only - YES" with "X"
#    - WAIT "V3_Comprehensive Only" with "True"
#    - INPUT "V3_Comprehensive Only" with "X"
#    - INPUT "V3_Comprehensive And Collision Only" with "X"
#    - VERIFY "V3_Comprehensive Deductible" with "True"
#    - INPUT "V3_CompDed" with "X"
#    - INPUT "V3_CompDedMoreOpt" with "X"
# 28. Source step 0177 "V3 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V3_CollDed" with "X"
#    - INPUT "V3_CollDedMoreOpt" with "X"
# 29. Source step 0178 "V4 Comp Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V2_CompDedMoreOpt" with "X"
#    - INPUT "V4_Comp/Coll Only - YES" with "X"
#    - WAIT "V4_Comprehensive Only" with "True"
#    - INPUT "V4_Comprehensive Only" with "X"
#    - INPUT "V4_Comprehensive And Collision Only" with "X"
#    - VERIFY "V4_Comprehensive Deductible" with "True"
#    - INPUT "V4_CompDed" with "X"
#    - INPUT "V4_CompDedMoreOpt" with "X"
# 30. Source step 0179 "V4 Coll Cov" in module "Coverages (New)" was disabled. Reason: 28.08.25 14:01:14 [pa2096@dnanico1.aniconet.com]
#    - INPUT "V4_CollDed" with "X"
#    - INPUT "V4_CollDedMoreOpt" with "X"
#    - INPUT "Next" with "X"
# 31. Source step 0180 "Set Buffer for Index" in module "TBox Set Buffer" was disabled. Reason: 05.06.25 07:58:35 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ADD Index" with "1"
#    - INPUT "LOI Index" with "3"
# 32. Source step 0181 "EQ || Other Policy Coverages" in module "EQ || Other Policy Coverages Section (New)" was disabled. Reason: 05.06.25 07:58:35 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Tort Option" with the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Happy Path.Tort Option" (not resolved in this concrete export)
#    - VERIFY "Income Loss" with the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Happy Path.Income Loss" (not resolved in this concrete export)
#    - INPUT "Extraordinary Medical Benefit" with the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Happy Path.Extraordinary Medical Benefit" (not resolved in this concrete export)
#    - INPUT "$5,000_Obsolete" with "X"
#    - INPUT "check_box_outline_ADD Driver_Obsolete" with "X"
#    - INPUT "check_box_outline_LOI Driver_Obsolete" with "X"
# 33. Source step 0182 "Set Buffer for Index" in module "TBox Set Buffer" was disabled. Reason: 05.06.25 07:58:35 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ADD Index" with "1"
#    - INPUT "LOI Index" with "1"
# 34. Source step 0183 "EQ || Other Policy Coverages" in module "EQ || Other Policy Coverages Section (New)" was disabled. Reason: 05.06.25 07:58:35 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Tort Option" with the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Happy Path.Tort Option" (not resolved in this concrete export)
#    - VERIFY "Income Loss" with the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Happy Path.Income Loss" (not resolved in this concrete export)
#    - INPUT "Extraordinary Medical Benefit" with the source TestCase-Design value "Additional Coverages_Happy Path.Policy Coverages_Happy Path.Extraordinary Medical Benefit" (not resolved in this concrete export)
#    - INPUT "check_box_outline_ADD Driver_Obsolete" with "X"
#    - INPUT "check_box_outline_LOI Driver_Obsolete" with "X"
# 35. Source step 0184 "EQ || Vehicle Coverage" in module "EQ || Vehicle Coverages Section" was disabled. Reason: 05.06.25 07:58:35 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Yes_V1_Obsolete_1" with "X"
#    - INPUT "Cycle Accessories_V1" with "X"
#    - INPUT "$10,000_V3 UMPD_Obsolete" with "X"
#    - INPUT "$10,000" with "X"
#    - INPUT "Next_1" with "X"
# 36. Source step 0190 field "Cycle Accessories_V1" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 37. Source step 0190 field "Original Parts_V1" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 38. Source step 0190 field "Endorsement Limit V1" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "SA-1398 $5,000"
# 39. Source step 0190 field "Cycle Accessories_V2" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 40. Source step 0190 field "Original Parts_V2" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "X"
# 41. Source step 0190 field "Endorsement Limit V2" in "EQ || Vehicle Coverages Section" was disabled. Reason:  
#    - Preserved source value: "SA-1399 $7,000"
# 42. Source step 0199 field "H1_Additional Interest Summary" in "AdditionalInterest" was disabled. Reason:  
#    - Preserved source value: "True"
# 43. Source step 0202 "Verify if Due date is Enabled or not" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Due Date" with "True"
# 44. Source step 0203 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Due Date" with "True"
#    - INPUT "Txt_Due Date" with "{CLICK}{sendkeys[\"^{a}\"]}"
#    - INPUT "Txt_Due Date" with "\"{DEL}\""
#    - INPUT "Txt_Due Date" with "25"
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[1234]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 45. Source step 0204 "Billing-Create and Update Billing details" in module "EQ||Billing" was disabled. Reason: 24.07.25 14:44:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Rd Btn_Custom Amount" with "X"
#    - INPUT "Btn_CHECK" with "X"
#    - WAIT "Txt_Check Number" with "True"
#    - INPUT "Txt_Check Number" with "{CLICK}{sendkeys[42]}"
#    - INPUT "Btn_Billing_NEXT" with "X"
# 46. Source step 0205 "EQ || Billing" in module "<unresolved module>" was disabled. Reason: 23.07.25 11:29:56 [pa2096@dnanico1.aniconet.com]
#    - WAIT "<unnamed value>" with "True"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Payment Due Date" with "9"
#    - INPUT "<unnamed value>" with "X"
#    - INPUT "Check # Field" with "1234"
#    - INPUT "<unnamed value>" with "X"
# 47. Source step 0209 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 48. Source step 0210 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 49. Source step 0211 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 50. Source step 0213 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 51. Source step 0213 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 52. Source step 0217 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 53. Source step 0217 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 54. Source step 0217 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 55. Source step 0217 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 56. Source step 0218 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 57. Source step 0218 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 58. Source step 0218 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 59. Source step 0218 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 60. Source step 0219 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 61. Source step 0219 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 62. Source step 0219 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 63. Source step 0219 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 64. Source step 0220 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 65. Source step 0221 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 66. Source step 0225 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Submission_1" with "True"
# 67. Source step 0226 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Comments" with "True"
# 68. Source step 0227 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Comments" with "True"
# 69. Source step 0228 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Comments" with "\"Test\""
# 70. Source step 0229 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ReferUW" with "True"
# 71. Source step 0230 "EQ||Submission - UW Comments(NEW)" in module "EQ||Submission (NEW)" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ReferUW" with "X"
#    - INPUT "SaveExit_1" with "X"
# 72. Source step 0231 "OpenUrl" in module "OpenUrl" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with "https://dcpqa.dnanico1.aniconet.com/express/express.aspx"
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 73. Source step 0232 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 74. Source step 0233 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 75. Source step 0234 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 76. Source step 0235 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 77. Source step 0236 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 78. Source step 0237 "EU||Home" in module "EU||Home" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 79. Source step 0238 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 80. Source step 0239 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 81. Source step 0240 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 82. Source step 0241 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 83. Source step 0242 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 84. Source step 0243 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 85. Source step 0244 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 86. Source step 0245 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 87. Source step 0246 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 88. Source step 0247 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 89. Source step 0248 "EQ || OpenUrl" in module "EQ || OpenUrl" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with "https://dcpqa.dnanico1.aniconet.com/express/express.aspx"
#    - INPUT "WebDriverBrowserArguments" with "--silent-debugger-extension-api"
# 90. Source step 0249 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 91. Source step 0250 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 92. Source step 0251 "EU||Home" in module "EU||Home" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 93. Source step 0252 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
# 94. Source step 0253 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 95. Source step 0254 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 96. Source step 0255 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 97. Source step 0256 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 98. Source step 0257 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 23.10.25 15:32:02 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 99. Source step 0258 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 100. Source step 0259 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 101. Source step 0260 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 102. Source step 0267 "OpenUrl" in module "OpenUrl" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Url" with the unresolved source parameter "Express URL" (not supplied by this reusable-block invocation)
#    - INPUT "UseActiveTab" with a blank value
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# 103. Source step 0268 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 104. Source step 0269 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 105. Source step 0270 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 106. Source step 0271 "Verify if ExpressUI login page is shown" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Lbl_Login ID" with "True"
# 107. Source step 0272 "Provide Express UI Login credentials" in module "EU||Login" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Login ID_1" with "True"
#    - INPUT "Txt_Login ID_1" with "AQ7314"
#    - INPUT "Password" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - WAIT "Txt_Password_1" with "True"
#    - INPUT "Txt_Password_1" with the RUNTIME-CONFIGURED protected Tosca-encrypted source value
#    - INPUT "Lnk_LOGIN" with "{Click}"
# 108. Source step 0273 "EU||Home" in module "EU||Home" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Search Type" with "True"
#    - INPUT "Txt_Search Text" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 109. Source step 0274 "EU|Home" in module "EU|Home/Motorcycle/PersonalAuto" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Policy/Quote#" with "X"
#    - INPUT "Lnk_Motorcycle" with "x"
#    - INPUT "Lnk_PersonalAuto" with "x"
#    - INPUT "Lnk_RV" with "x"
# 110. Source step 0275 "EU||Applicant" in module "EU||Applicant" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Lnk_Pricing" with "{Invoke[Click]}"
# 111. Source step 0276 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 112. Source step 0277 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "ChkBox_Bypass Level 9 Rules" with "True"
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
# 113. Source step 0278 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "True"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "Approved"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 114. Source step 0279 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 115. Source step 0280 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 116. Source step 0281 "CloseBrowser" in module "CloseBrowser" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Title" with "*Home*"
# 117. Source step 0282 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "X"
# 118. Source step 0283 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 13.11.25 16:06:24 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 119. Source step 0286 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 120. Source step 0286 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 121. Source step 0294 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 122. Source step 0295 "Recall Quote\\Policy" in module "EQ||New Quote" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Txt_Quote\\Policy Search" with "\"^{a}\""
#    - INPUT "Txt_Quote\\Policy Search" with captured runtime value "QuoteNumber"
#    - INPUT "Btn_Search" with "{Click}"
# 123. Source step 0296 "EQ||Click on Submission Page" in module "EQ||Auto Tabs" was disabled. Reason: 28.10.25 09:43:04 [pa2096@dnanico1.aniconet.com]
#    - INPUT "DIV_Submission" with "{Invoke[Click]}"
# 124. Source step 0298 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 125. Source step 0299 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 126. Source step 0300 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 127. Source step 0302 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: "True"
# 128. Source step 0302 field "Txt_Password_1" in "Provide Express UI Login credentials" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-CONFIGURED protected Tosca-encrypted source value
# 129. Source step 0306 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 130. Source step 0306 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 131. Source step 0306 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 132. Source step 0306 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 133. Source step 0307 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 134. Source step 0307 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 135. Source step 0307 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 136. Source step 0307 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 137. Source step 0308 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 138. Source step 0308 field "Txt_Underwriting Notes *" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "{Click}{SENDKEYS[Approved]}"
# 139. Source step 0308 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "True"
# 140. Source step 0308 field "Btn_Approve" in "EU||Pricing" was disabled. Reason:  
#    - Preserved source value: "X"
# 141. Source step 0309 "EU||Pricing" in module "EU||Pricing" was disabled. Reason: 28.10.25 10:52:23 [pa2096@dnanico1.aniconet.com]
#    - INPUT "ChkBox_Bypass Level 9 Rules" with "x"
#    - INPUT "Bypass Level 9 Comments_1" with "{Click}"
#    - INPUT "Bypass Level 9 Comments_1" with "{SENDKEYS[Approved]"
#    - INPUT "Bypass Level 9 Comments_1" with ""
#    - WAIT "Txt_Underwriting Notes *" with "True"
#    - INPUT "Txt_Underwriting Notes *" with "{Click}{SENDKEYS[Approved]}"
#    - WAIT "Btn_Approve" with "True"
#    - INPUT "Btn_Approve" with "X"
#    - INPUT "Lnk_Home" with "X"
# 142. Source step 0310 "TBox Wait" in module "TBox Wait" was disabled. Reason: 26.02.25 13:58:29 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "12000"
# 143. Source step 0315 field "DIV_Agent Documents Count" in "EQ||Agent List count capture" was disabled. Reason:  
#    - Preserved source value: the RUNTIME-DERIVED buffer expression "{MATH[{B[AgentList count]}-1]}"
# 144. Source step 0319 "TBox Wait" in module "TBox Wait" was disabled. Reason: 25.02.25 14:11:17 [pa1639@dnanico1.aniconet.com]
#    - INPUT "Duration" with "30000"
# 145. Source step 0324 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "True"
# 146. Source step 0324 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "Transmit"
# 147. Source step 0324 field "Btn_Transmit" in "Submission_1-Back to Submission page" was disabled. Reason:  
#    - Preserved source value: "X"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Smoke\\TC01_Smoke_Auto_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0002 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0003 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0004 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EQ sign out and Close browser
# 5. Source recovery step 0005 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Smoke\\TC01_Smoke_Auto_NM_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0006 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0007 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0008 CloseBrowser: I close the active browser
