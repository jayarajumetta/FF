# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 04_EQ_SFP_Smoke_Test_MN.feature
# Application: Commercial Lines ExpertQuote
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_EQ @SFP @smoke @MN @Edge @manual @automated
Feature: Create, close, retrieve, and verify a Minnesota Special Farm Package quote in ExpertQuote
  As an ExpertQuote user
  I want to execute the exported EQ | SFP | Smoke Test flow using one Minnesota iteration
  So that the full Tosca sequence can be reviewed and performed as a traceable manual test


  Background: Establish the Commercial Lines ExpertQuote application context
    Given the Commercial Lines ExpertQuote application context and source-defined prerequisites are initialized

  Scenario: Complete SFP | Smoke Test for the Minnesota representative iteration

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0029: Set Buffer for Last Name
    # Reusable flow: EQ|Common|Enter Client Search Info
    When I generate and retain a RANDOM value matching "Smoke[a-z]{4}" as runtime value "LastName"
    And I generate and retain a RANDOM value matching "SFP [a-z]{3}" as runtime value "FirstName"
    # Source step 0030: Client Info
    # Reusable flow: EQ|Common|Enter Client Search Info
    Then I wait until "Client Info" is visible
    And I wait until "New/Existing Client Search" is visible
    And I use runtime value "FirstName" in "customer.name.first"
    And I use runtime value "LastName" in "customer.name.last"
    And I use "08/13/2004" (one-iteration value for 08/13/2026; source rule: execution date minus 22 years) in "customer.dateOfBirth"
    And I click "Search"
    # Source step 0031: Create New Client
    # Reusable flow: CL|EQ|Common|Create New Client
    Then I wait until "Existing Client Match" exists
    And I click "Create New Client_1"
    And I press TAB and click on "Next"
    # Source step 0032: Set StateName Buffer
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    When runtime value "StateName" is set to "Minnesota"
    # Source step 0033: Account Details - Account Info
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    Then I wait until "Account Information Header" is visible
    And I leave "Owner Middle Name" blank and press TAB
    And I enter a RANDOM value matching "3[0-9]{9}" in "Owner Phone"
    And I enter a RANDOM value matching "test@[a-z]{4}\\.com" in "Owner Email"
    # Source step 0034: Account Details - Select Married
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    When I select "Married"
    # Source step 0035: Navigate down the screen
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    When I press SHIFT+TAB on "Street Address"
    # Source step 0036: Account Details - Account Info
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    When I enter "115 S Main ST", then press TAB in "Street Address"
    And I enter "111", then press TAB in "Address 2"
    And I enter "Warren", then press TAB in "City"
    And I click on "State Dropdown"
    And I select the retained representative state from the state list
    And I enter "56762", then press TAB in "Zip"
    And I wait until "Map" exists
    And I wait until "Satellite" exists
    # Source step 0037: Navigate down the screen
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    When I press SHIFT+TAB on "Next"
    # Source step 0038: Account Details - Account Info
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    When I select "Have you received mail at this address for at least 90 days? Yes"
    And I select "Is the account address also where the client resides? Yes"
    And I click "Next"
    # Source step 0039: Proposal Start
    # Reusable flow: EQ|Common|Proposal Start
    Then I wait until "Proposal Details Header" is visible
    And I select "Special Farm Package"
    And I enter "12-01-2025", then press TAB in "Effective Date"
    And I set "newAccountAddress" to "True"
    And I press TAB on "PolicyTerm"
    And I enter "12 months" in "PolicyTerm"
    And I press TAB on "PolicyTerm"
    And I press TAB on "State Dropdown"
    And I select the retained representative state from the state list
    And I enter "D2102", then press TAB, then press TAB in "AgentPC"
    And I capture "Effective Date" as runtime value "EffDate"
    And I click on "State Dropdown"
    And I click "Start Quote"
    # Source step 0040: Set Buffer for LOB
    # Reusable flow: EQ|Common|Proposal Start
    When runtime value "LOB" is set to "SFP"
    # Source step 0041: Set Buffer for WaitOnTime
    When runtime value "WaitOnTime" is set to "5000"
    # Source step 0042: SSN
    # Reusable flow: EQ|Common|SSN
    Then I wait until "The SSN could not be found. Please enter an SSN." is visible
    And I enter a RANDOM value consisting of fixed prefix "025", followed by 6 random digits in "ssn"
    And I wait until "Submit - Angular" is visible
    And I press TAB on "Submit - Angular"
    And I click "Submit - Angular"
    # Source step 0043: Verify if Popup exists
    # Reusable flow: EQ|Common|SSN
    # Control flow: IF: If Prefill Match Not Found Popup Exists > Popup with Prefill Match Not Found
    And if the No Prefill Match Found popup exists, "No Prefill Match Found" should exist
    # Source step 0044: Click Continue
    # Reusable flow: EQ|Common|SSN
    # Control flow: IF: If Prefill Match Not Found Popup Exists > Then click Continue
    And if the No Prefill Match Found popup exists, I click "Continue"
    # Source step 0045: Set Buffer for WaitOnTime
    When runtime value "WaitOnTime" is set to "25000"
    # Source step 0046: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Pre Qualification"
    # Source step 0047: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0048: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0049: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0050: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Pre Qualification"
    # Source step 0051: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    When runtime value "Screen" is set to "Pre-Qualification"
    # Source step 0052: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0053: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0054: Quote Identifying
    # Reusable flow: CL|EQ|Common|Quote Identifying and Close Quote
    When I capture "Name and Quote" as runtime value "Quote_NameNum"
    # Source step 0055: Set Buffer for quote num & id
    # Reusable flow: CL|EQ|Common|Quote Identifying and Close Quote
    When I set runtime value "Quote_Num" from RUNTIME-DERIVED value from "{STRINGREPLACE[{B[Quote_NameNum]}][{B[LastName]}][]}"
    And I set runtime value "QuoteID" from runtime value "Quote_Num"
    # Source step 0056: Close Quote
    # Reusable flow: CL|EQ|Common|Quote Identifying and Close Quote
    When I click on "Close Quote"
    # Source step 0057: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0058: Search by QuoteNum
    # Reusable flow: CL|EQ|Common|Search by QuoteNum
    When I use RUNTIME-DERIVED value from "{SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}" in "quoteSearchInput"
    And I click "Search"
    # Source step 0059: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0060: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Pre Qualification"
    # Source step 0061: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0062: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0063: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0064: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Pre Qualification"
    # Source step 0065: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    When runtime value "Screen" is set to "Pre-Qualification"
    # Source step 0066: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0067: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0068: Quote Identifying
    # Reusable flow: CL|EQ|Common|Verifying Quote
    Then "Name and Quote" property "InnerText" should equal runtime value "Quote_NameNum"

    # ==============================================================================
    # Section: Post Condition
    # ==============================================================================
    # Source step 0069: Close Explorer Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0070: Close Chrome Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0071: Close Edge Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0072: Close Firefox Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0073: Close Edge Beta Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Step 0019: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0020: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Disabled granular value: Step 0031 / Create New Client / No results found. Please choose Create New Client to continue entering a new client.: True
# Disabled granular value: Step 0036 / Account Details - Account Info / County: {SENDKEYS[Marshall]}{TAB}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {SCROLL[2]}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {CLICK[0px][-10px]}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {CLICK}
# Disabled granular value: Step 0042 / SSN / SUBMIT: True
# Disabled granular value: Step 0042 / SSN / SUBMIT: {TAB}
# Disabled granular value: Step 0042 / SSN / SUBMIT: X

# --------------------------------------------------------------------------------------------------
# SOURCE-CONDITIONAL ACTIONS NOT EXECUTED FOR THIS REPRESENTATIVE ITERATION
# --------------------------------------------------------------------------------------------------
# Step 0039 / Proposal Start / Personal Auto: condition LOB == "PAP" is false; value X
# Step 0039 / Proposal Start / Motorcycle: condition LOB == "MOTO" is false; value X
# Step 0039 / Proposal Start / Recreational Vehicle: condition LOB == "RV" is false; value X
# Step 0039 / Proposal Start / Home: condition LOB == "HO" is false; value X
# Step 0039 / Proposal Start / ROP: condition LOB == "ROP" is false; value X
# Step 0039 / Proposal Start / Business Owners: condition LOB=="BOP" is false; value X
# Step 0039 / Proposal Start / Select -SFP CE: condition BusinessType == "CE" is false; value X
# Step 0039 / Proposal Start / Search Business Name: condition LOB != "SFP" is false; value {TAB}
# Step 0039 / Proposal Start / Individually Owned, DBA, or T/A: condition BusinessType == "Individual" is false; value {CLICK}
# Step 0039 / Proposal Start / Individual DBA: condition BusinessType == "Individual" is false; value Tester Automation
# Step 0039 / Proposal Start / Lessors Risk  - No: condition LOB != "SFP" is false; value X

# --------------------------------------------------------------------------------------------------
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# --------------------------------------------------------------------------------------------------
# Recovery R001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\SFP; Filename=SFP BASIC TestCase
# Recovery R002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\SFP; Filename=SFP BASIC TestStep
# Recovery R003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\SFP; Filename=SFP BASIC TSV
# Recovery R004: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R005: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R006: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R007: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R008: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5

# --------------------------------------------------------------------------------------------------
# STATIC CONVERSION COVERAGE
# --------------------------------------------------------------------------------------------------
# Normal source steps represented: 73/73
# Active/conditional source steps represented: 71/71
# Source-disabled steps preserved as comments: 2/2
# Recovery steps preserved as comments: 8/8
# Active non-structural granular values processed: 181/181
# Structural/container granular values represented through owning steps: 12
# Functional correctness still requires execution evidence and/or BA/SME validation.
