# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 213_Smoke_Test_SH3_AZ.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Home @smoke @Arizona @Edge @manual @obsolete @automated
Feature: Execute Smoke Test SH3 for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Smoke Test SH3 workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Smoke Test SH3 using representative iteration Arizona (AZ)
    # Source step 0022: Enter Sign On Credentials | Module: EQ||Sign On
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-d422-cfa5-ed6f38c66060
    When I enter or select "\"^{a}\"" in "Txt_Username"
    When I enter or select "YD2102" in "Txt_Username"
    When I enter the RUNTIME-CONFIGURED value "EQPassword" in "Txt_Password"
    When I click "Btn_Sign On"

    # Source step 0023: Start New Quote in EQ | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-8608-dda8-731e4c08e713
    Then "Btn_New Quote" should be visible
    When I click "Btn_New Quote"

    # Source step 0024: Client Selection-Enter Client Info of New or Existing clients | Module: EQ || Client Selection
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-db4f-f8de-5c6ada11ea30
    Then I wait until "<unnamed value>" is visible
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

    # Source step 0025: Account Details-Enter new Account Information | Module: EQ||Account Details
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-1005-81bc-8d6166fd0f94
    Then I wait until "<unnamed value>" is visible
    Then "<unnamed value>" should exist
    Then "<unnamed value>" should exist
    When I enter captured runtime value "DOB" in "<unnamed value>"
    When I enter or select "2000000000" in "<unnamed value>"
    When I enter or select "out@aol.com" in "<unnamed value>"
    Then "Lbl_Marital Status:" should exist
    When I click "<unnamed value>"
    When I enter or select "8953 W Townley Ave, Peoria, AZ, USA" in "<unnamed value>"
    Then I wait until "<unnamed value>" exists
    When I enter or select "{click}{down}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "<unnamed value>"
    When I enter or select "{SCROLL[10][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Have you received mail at this address for at least 90 days?"
    Then I wait until "Lbl_Have you received mail at this address for at least 90 days?" is visible
    When I click "<unnamed value>"
    Then "Lbl_Is the account address also where the client resides?" should exist
    When I click "<unnamed value>"
    When I click "<unnamed value>"

    # Source step 0026: EQH||Proposal Start | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-e794-a78c-b095a099c223
    Then "Btn_PERSONAL AUTO" should exist
    Then "Btn_MOTORCYCLE" should exist
    Then "Btn_RECREATIONAL VEHICLE" should exist
    When I click "Btn_HOME"
    Then I wait until "Lbl_Select Product Type" is visible
    Then "Btn_SH3-HOMEOWNERS" should be visible
    When I click "Btn_SH3-HOMEOWNERS"
    Then "Btn_SH4-TENANTS" should be visible
    When I enter or select "{SCROLL[5][1000px][None][HorizontalFirst][300ms]}" in "Btn_SD1-RENTAL OWNERS"
    When I enter the RUNTIME-DERIVED date from Tosca expression "{DATE[][+5d][MM/dd/yyyy]}" in "Txt_Effective Date_1"
    When I enter or select "10" in "Txt_Effective Date_1"
    When I enter or select "{Invoke[Click]}{SENDKEYS[ARIZONA]}" in "Drp List_Rating State"
    Then "Txt_Agent 5-Digit PCCode" should exist
    When I enter or select "D2102" in "Txt_Agent 5-Digit PCCode"
    When I enter or select "{SCROLL[3][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Select Risk Address"

    # Source step 0027: Proposal Start - Writing Company | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-bdad-20e6-b42c097b548a
    When I select "Drp_Writing Company"
    When I click "Lbl_American National General Insurance Co."
    When I click "Rd Btn_Same as New Account Address"
    When I click "Btn_Start Quote_1"

    # Source step 0028: Proposal Start-Invalid Address,SSN,Client already exists | Module: (Old) EQ||Proposal Start
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-7425-dc60-3b28e2ad4ad2
    Then I wait until "Lbl_SSN" is visible
    When I enter captured runtime value "SSN" in "Txt_SSN"
    When I click "Btn_SSN_SUBMIT"

    # Source step 0029: TBox Wait | Module: TBox Wait
    # Section: Process | Reusable flow: zz Wait | Source XTestStep: 3a19dd55-d3cb-31ae-1220-d039e13dd35b
    When I wait "10000" milliseconds

    # Source step 0030: Pre-Qualification-Select Client and Property Eligibility Restrictions(Getting LN and Quote#) | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15e5-be13-be4f-bb50521eba52
    Then I wait until "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) WITH FELONY CONVICTION" exists
    Then "Btn_NO VALID SSN FOR ACCOUNT OWNER" should exist
    Then "Btn_DWELLING OWNED OR OCCUPIED BY PERSON(S) CONVICTED OF ARSON IN THE LAST 5 YEARS" should exist
    Then "Btn_None Of The Above_Client ER" should exist
    When I select "Btn_None Of The Above_Client ER"
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber1"
    Then "Lbl_Property Eligibility Restrictions" should exist
    When I enter or select "{SCROLL[4][1000px][None][HorizontalFirst][300ms]}" in "Btn_MORE THAN 2 UNITS"
    Then "Btn_SINGLE WIDE MANUFACTURED HOME" should exist
    Then "Btn_MANUFACTURED HOME CONSTRUCTED PRIOR TO 1994" should exist
    Then "Btn_ANY ANIMALS ON PREMISES WITH A BITE HISTORY" should exist
    Then "Btn_None Of The Above_Property Eligibility Restrictions_SH4" should exist
    When I select "Btn_None of the Above_SH3_SH6"
    Then I wait until "Btn_PreQualification_Next" exists
    When I click "Btn_PreQualification_Next"

    # Source step 0031: TBox Set Buffer-Extract the Quote Number | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-3e96-7ad4-f8a138887454
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber1]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber2"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber2]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber3"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber3]}][\"\\)\"][\"\"]}" as runtime value "QuoteNumber"

    # Source step 0032: Named Insureds Summary-Client Suggestions | Module: EQH||Named Insureds Summary-Client Suggestions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-47d7-383f-e8c819c59a53
    Then I wait until "Lbl_Choose Insureds From Existing Account" is visible
    When I click "Btn_(Existing Client)Dausenhauer, EricaDOB: 02/06/1966-Need to update"
    Then "Btn_Search" should exist
    When I click "Btn_Next"

    # Source step 0033: Add or Edit Named Insured-Existing Client | Module: EQH||Add or Edit Named Insured-Existing Client
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-c147-c30f-62c35a7eb1bd
    Then I wait until "Add/Edit Named Insured Header" is visible
    Then "Btn_Individual" should exist
    Then "Btn_C/O" should exist
    When I enter or select "{SCROLL[9][1000px][None][HorizontalFirst][300ms]}" in "Lbl_Phone Type"
    Then "Lbl_Email Type" should exist
    Then "Lbl_Gender" should exist
    When I click "Btn_Male"
    Then "Lbl_Marital Status" should be visible
    Then "Lbl_Relation To Account Owner" should be visible
    Then "Btn_Son" should be visible
    Then "Btn_Daughter" should exist
    When I click "Btn_SAVE AND CONTINUE"

    # Source step 0034: Named Insureds Summary-Review details or Add Named Insured | Module: EQH||Named Insureds Summary-Review details or Add Named Insured
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-9797-70d2-216a3616ea22
    Then I wait until "Named Insureds Summary Header" is visible
    Then "Btn_ADD NAMED INSURED" should exist
    Then "Btn_NEXT" should exist
    When I click "Btn_NEXT"

    # Source step 0037: EQH||Location - save and exit quote at this page | Module: EQH||Location
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-7f77-cd00-eaf62618ec51
    Then I wait until "Location Header" is visible
    When I click "Drop down_QUOTE ACTIONS"
    Then I wait until "Btn_Quote Actions_Save and Exit" is visible
    When I click "Btn_Quote Actions_Save and Exit"

    # Source step 0039: Search for the Quote in EQ  | Module: EQ||New Quote
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-0f95-2657-80b22816a30c
    Then "Btn_New Quote" should be visible
    When I enter captured runtime value "QuoteNumber" in "Txt_QuoteSearch_Input"
    When I click "Btn_Search_1"

    # Source step 0041: EQH||Side Menu-Navigate to Pre-Qualification page | Module: EQH||Side Menu and Quote Actions
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-2f89-9e6e-7f2be7011598
    When I click "Pre-Qualification"

    # Source step 0042: Pre-Qualification-Getting LN and Quote# after Recall | Module: EQH||Pre-Qualification
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-d186-fd86-e8df7f7f23a8
    Then I wait until "Lbl_Client Eligibility Restrictions" is visible
    When I capture "OuterText" from "Lbl_Side Menu_HOME_Quote Number" as runtime value "HomeQuoteNumber5"

    # Source step 0043: TBox Set Buffer-Extract the Quote Number after Recall | Module: TBox Set Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-67ac-de6d-b689d4a99097
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber5]}][\"HOME \"][\"\"]}" as runtime value "HomeQuoteNumber6"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber6]}][\"\\(\"][\"\"]}" as runtime value "HomeQuoteNumber7"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{STRINGREPLACE[{B[HomeQuoteNumber7]}][\"\\)\"][\"\"]}" as runtime value "RecallQuoteNumber"

    # Source step 0044: TBox Partial Buffer-Compare the Old and Recalled Quote Numbers | Module: TBox Partial Buffer
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-b7f7-bca0-73e3ca042095
    When I derive runtime buffer "RecallQuoteNumber" from captured runtime value "QuoteNumber"

    # Source step 0045: TestData-Save PolicyNumber, Premium and other details to TDM | Module: TestData - Create & provide new item
    # Section: Process | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-002d-0092-24c676a8c0ab
    When I retrieve test data through TDM operation "TestData-Save PolicyNumber, Premium and other details to TDM"
    And I use TDM parameter "Existing or new TDS type" with "Home_PolicyData_Smoke"
    And I use TDM parameter "Data structure > TestCaseName" with captured runtime value "TCName"
    And I use TDM parameter "Data structure > EffectiveDate" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][+5d][MM/dd/yyyy]}"
    And I use TDM parameter "Data structure > Date_Time" with the RUNTIME-DERIVED date from Tosca expression "{DATE[][][MM/dd/yyyy]} {TIME}"
    And I use TDM parameter "Data structure > FirstName" with captured runtime value "FirstName"
    And I use TDM parameter "Data structure > LastName" with captured runtime value "LastName"
    And I use TDM parameter "Data structure > DOB" with captured runtime value "DOB"
    And I use TDM parameter "Data structure > SSN" with captured runtime value "SSN"
    And I use TDM parameter "Data structure > QuoteNumber" with captured runtime value "QuoteNumber"

    # Source step 0046: Log Out- Exist from the Quote/Policy | Module: EQ||Log Out
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-0795-b17b-d949fed919ec
    When I click "Btn_Log Out icon"
    When I click "Btn_Log Out pop-up"

    # Source step 0047: CloseBrowser | Module: CloseBrowser
    # Section: Postcondition | Reusable flow: <none> | Source XTestStep: 3a19e1e5-15f5-d3f2-a9b9-ca7e4d2fff84
    When I close the active browser

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. Source step 0017 "Enter Sign On Credentials" in module "EQ||Sign On" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - VERIFY "Txt_Username" with "True"
# 2. Source step 0018 "TBox Wait" in module "TBox Wait" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Duration" with "1000"
# 3. Source step 0019 "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 05.06.25 14:50:33 [pa2096@dnanico1.aniconet.com]
#    - INPUT "Caption" with "*Sign On*"
#    - INPUT "Operation" with "Maximize"
# 4. Source step 0026 field "Hdr2" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 5. Source step 0026 field "Drp List_NEW MEXICO_1" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 6. Source step 0026 field "Rd Btn_Same as New Account Address" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 7. Source step 0026 field "Btn_Start Quote_1" in "EQH||Proposal Start" was disabled. Reason:  
#    - Preserved source value: "X"
# 8. Source step 0028 field "Btn_Confirm client's SSN_CONFIRM" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: a blank value
# 9. Source step 0028 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "True"
# 10. Source step 0028 field "Btn_Client Already Exists_CREATE NEW ACCOUNT" in "Proposal Start-Invalid Address,SSN,Client already exists" was disabled. Reason:  
#    - Preserved source value: "X"
# 11. Source step 0030 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Select Client and Property Eligibility Restrictions(Getting LN and Quote#)" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 12. Source step 0030 field "Btn_MORE THAN 2 UNITS" in "Pre-Qualification-Select Client and Property Eligibility Restrictions(Getting LN and Quote#)" was disabled. Reason:  
#    - Preserved source value: "PGDN"
# 13. Source step 0033 field "Lbl_Select the client type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: "True"
# 14. Source step 0033 field "Btn_Home" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 15. Source step 0033 field "Txt_Email Address" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 16. Source step 0033 field "Btn_Pager_Email Type" in "Add or Edit Named Insured-Existing Client" was disabled. Reason:  
#    - Preserved source value: a blank value
# 17. Source step 0035 "TBox Wait" in module "TBox Wait" was disabled. Reason: 07.02.24 11:32:12 [ct2453]
#    - INPUT "Duration" with "5000"
# 18. Source step 0036 "TBox Partial Buffer-Extract the Quote Number" in module "TBox Partial Buffer" was disabled. Reason: 25.01.24 17:26:33 [ct2452]
#    - INPUT "Buffer" with "QuoteNumber"
#    - INPUT "Value" with captured runtime value "LNQuoteNumber"
#    - INPUT "Last" with "12"
# 19. Source step 0038 "TBox Wait" in module "TBox Wait" was disabled. Reason: 07.02.24 11:32:12 [ct2453]
#    - INPUT "Duration" with "5000"
# 20. Source step 0039 field "Btn_New Quote" in "Search for the Quote in EQ" was disabled. Reason:  
#    - Preserved source value: "X"
# 21. Source step 0040 "TBox Wait" in module "TBox Wait" was disabled. Reason: 07.02.24 11:32:12 [ct2453]
#    - INPUT "Duration" with "3000"
# 22. Source step 0042 field "Lbl_QuoteTab_Name and Quote number" in "Pre-Qualification-Getting LN and Quote# after Recall" was disabled. Reason:  
#    - Preserved source value: "LNQuoteNumber"
# 23. Source step 0045 field "Data structure > PolicyNumber" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Policy Number"
# 24. Source step 0045 field "Data structure > Premium" in "TestData-Save PolicyNumber, Premium and other details to TDM" was disabled. Reason:  
#    - Preserved source value: captured runtime value "Premium"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario - Take screenshot, EQ sign out and Close browser
# 1. Source recovery step 0001 TBox Take Screenshot of failure(during initial run) at TC level: I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Smoke\\Smoke Test SH3 - AZ_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 2. Source recovery step 0002 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 3. Source recovery step 0003 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 4. Source recovery step 0004 CloseBrowser: I close the active browser
# Recovery scenario: CleanUp Scenario - Take screenshot, EQ sign out and Close browser
# 5. Source recovery step 0005 TBox Take Screenshot of failure(during recovery run): I capture a "Desktop" screenshot at "\\\\fs1\\public\\Tosca\\PL DC Automation\\Screenshots\\Smoke\\Smoke Test SH3 - AZ_{DATE[][][MM/dd/yyyy]}_{TIME}"
# 6. Source recovery step 0006 Log Out from the ExpertQuote EQ: I click "Btn_Log Out icon"
#    And I wait until "Btn_Log Out pop-up" is visible
#    And I click "Btn_Log Out pop-up"
# 7. Source recovery step 0007 Wait Until EQ-Log In page shows up: I wait until "Txt_Username_1" is visible
#    And I wait until "Btn_Sign On_1" is visible
# 8. Source recovery step 0008 CloseBrowser: I close the active browser
