# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 02_EQ_BOP_Basic_Policy_AL.feature
# Application: Commercial Lines ExpertQuote
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_EQ @BOP @basic_policy @AL @Edge @manual @automated
Feature: Execute the complete Alabama Business Owners policy flow in ExpertQuote
  As an ExpertQuote user
  I want to execute the exported EQ | BOP | Basic Policy flow using one Alabama iteration
  So that the full Tosca sequence can be reviewed and performed as a traceable manual test


  Background: Establish the Commercial Lines ExpertQuote application context
    Given the Commercial Lines ExpertQuote application context and source-defined prerequisites are initialized

  Scenario: Complete BOP | Basic Policy for the Alabama representative iteration
    # MANUAL-ITERATION CHOICE: the source exposes actions conditional on BusinessType == Individual
    # but does not export a resolved BusinessType value. This representative manual iteration uses
    # BusinessType "Individual" so the source DBA actions are executable; the choice is explicit.

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0029: Set Buffer for Last Name
    # Reusable flow: EQ|Common|Enter Client Search Info
    When I generate and retain a RANDOM value matching "BASIC[A-Z]{4}" as runtime value "LastName"
    And I generate and retain a RANDOM value matching "BOP[a-z]{3}" as runtime value "FirstName"
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
    When runtime value "StateName" is set to "Alabama"
    # Source step 0033: Account Details - Account Info
    # Reusable flow: EQ|Common|Enter Account Details - Account Info
    Then I wait until "Account Information Header" is visible
    And I enter "AL", then press TAB in "Owner Middle Name"
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
    When I enter "1918 Avalon Ave", then press TAB in "Street Address"
    And I leave "Address 2" blank and press TAB
    And I enter "Muscle Shoals", then press TAB in "City"
    And I click on "State Dropdown"
    And I select the retained representative state from the state list
    And I enter "35661", then press TAB in "Zip"
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
    And I select "Business Owners"
    And I press TAB on "Search Business Name"
    And I click on "Individually Owned, DBA, or T/A"
    And I enter or select "Tester Automation" in "Individual DBA"
    And I enter "11-28-2026", then press TAB in "Effective Date"
    And I set "newAccountAddress" to "True"
    And I select "Lessors Risk  - No"
    And I press TAB on "State Dropdown"
    And I select the retained representative state from the state list
    And I enter "D2102", then press TAB, then press TAB in "AgentPC"
    And I capture "Effective Date" as runtime value "EffDate"
    And I click on "State Dropdown"
    And I click "Start Quote"
    # Source step 0040: Set Buffer for LOB
    # Reusable flow: EQ|Common|Proposal Start
    When runtime value "LOB" is set to "BOP"
    # Source step 0041: SSN
    # Reusable flow: EQ|Common|SSN
    Then I wait until "The SSN could not be found. Please enter an SSN." is visible
    And I enter a RANDOM value consisting of fixed prefix "025", followed by 6 random digits in "ssn"
    And I wait until "Submit - Angular" is visible
    And I press TAB on "Submit - Angular"
    And I click "Submit - Angular"
    # Source step 0042: Verify if Popup exists
    # Reusable flow: EQ|Common|SSN
    # Control flow: IF: If Prefill Match Not Found Popup Exists > Popup with Prefill Match Not Found
    And if the No Prefill Match Found popup exists, "No Prefill Match Found" should exist
    # Source step 0043: Click Continue
    # Reusable flow: EQ|Common|SSN
    # Control flow: IF: If Prefill Match Not Found Popup Exists > Then click Continue
    And if the No Prefill Match Found popup exists, I click "Continue"
    # Source step 0044: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "PreQualification"
    # Source step 0045: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0046: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0047: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0048: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "PreQualification"
    # Source step 0049: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0050: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0051: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists

    # ==============================================================================
    # Section: Policy Data Entry > Search and Add Class
    # ==============================================================================
    # Source step 0052: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|PreQualification|Search and Add a Class
    Then I wait until "Loading ..." does not exist
    # Source step 0053: Wait for Add Class Codes to Exist and Click Search/Add Class Code
    # Reusable flow: EQ|BOP|PreQualification|Search and Add a Class
    When I press TAB, then click on "Search/Add Class Code"
    # Source step 0054: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|PreQualification|Search and Add a Class
    Then I wait until "Loading ..." does not exist
    # Source step 0055: Wait for Find a Class Code window to exist and add the class code.
    # Reusable flow: EQ|BOP|PreQualification|Search and Add a Class
    Then I wait until "Find a Class Code" exists
    And I enter "59325" in "Class Filter"
    And I click on "search"
    And I wait until "on" exists
    And I press TAB, then use value "True" on "on"
    And I wait until "You have selected 1 Class Codes" exists
    And I click, then press TAB on "You have selected 1 Class Codes"
    And I click on "Add"
    # Source step 0056: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|PreQualification|Search and Add a Class
    Then I wait until "Loading ..." does not exist
    # Source step 0057: Set Industry/Class Code Restrictions to None of the Above, and go to next screen
    # Reusable flow: EQ|BOP|PreQualification|Search and Add a Class
    # Source condition: LOB == "SFP"
    # No executable action for this representative iteration; see conditional appendix.

    # ==============================================================================
    # Section: Policy Data Entry > BOP Industry / Class Code Restrictions
    # ==============================================================================
    # Source step 0062: BOP Industry  - Answer Non of the Above
    # Reusable flow: EQ|BOP|PreQualification|Industry Class Code Restrictions
    Then I wait until "Industry / Class Code Restrictions Heading" exists
    And I use value "True", then press TAB on "None of the Above"

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0063: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Primary Insured Details"
    # Source step 0064: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0065: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0066: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0067: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Primary Insured Details"
    # Source step 0068: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0069: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0070: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0071: EQ|Primary Insured|Enter Required Info|Type|BOP
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: LOB == "BOP"
    When I click, then press TAB, then press TAB, then press TAB on "(Existing Client)"
    And I click "Next (BOP)"
    # Source step 0072: EQ|Primary Insured|Enter Required Info|Type|SFP
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: LOB == "SFP"
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0073: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    Then I wait until "Loading ..." does not exist
    # Source step 0074: EQ|Primary Insured|Enter Required Info|Other
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    When I click "Individual/Sole Proprietor"
    And I press TAB on "Save"
    And I click "Save"
    # Source step 0075: EQ|Primary Insured|Click Edit General Info
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: ReadOnly == NULL
    And if source condition "ReadOnly == NULL" is satisfied, I perform “EQ|Primary Insured|Click Edit General Info” in module “EQ|Common|Primary Insured|Required” using the field actions and data below
    # Source step 0076: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    Then I wait until "Loading ..." does not exist
    # Source step 0077: EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: ReadOnly == NULL
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "AL BOP EQ Basic {NMONTH}.{NDAY}.{NYEAR} {Time}", then press TAB on "Description Of Operations"
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "3", then press TAB on "Number Of Fulltime Employees"
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "2", then press TAB on "Number Of PartTime Employees"
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "1", then press TAB on "Number Of Seasonal Employees"
    And if source condition "ReadOnly == NULL" is satisfied, I click "Save"
    And if source condition "ReadOnly == NULL" is satisfied, "Description Of Operations" should match runtime value "QuoteDescription"
    # Source step 0078: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    Then I wait until "Loading ..." does not exist
    # Source step 0079: EQ|BOP|Primary Insured Details|Answer None of the Above
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: LOB != "BOP"
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0080: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Primary Insured Details|General UW Questions
    Then I wait until "Loading ..." does not exist
    # Source step 0081: EQ|BOP|Primary Insured Details| General UW Questions
    # Reusable flow: EQ|BOP|Primary Insured Details|General UW Questions
    # Source condition: LOB == "BOP"
    When I use value "True", then press TAB on "None of the Above - Checkbox"
    # Source step 0082: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Primary Insured Details|Industry Class Code Questions
    Then I wait until "Loading ..." does not exist
    # Source step 0083: EQ|BOP|Primary Insured Details|Industry/Class Code Questions
    # Reusable flow: EQ|BOP|Primary Insured Details|Industry Class Code Questions
    # Source condition: LOB == "BOP"
    When I use value "True", then press TAB on "None of the Above - Checkbox"
    # Source step 0084: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Client Details"
    # Source step 0085: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0086: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0087: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0088: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Client Details"
    # Source step 0089: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0090: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0091: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0092: Set Buffer for Indexes
    # Reusable flow: EQ|BOP|Client Details|Edit Client Roles
    When runtime value "InspectionContactIndex" is set to "1"
    # Source step 0093: EQ|BOP|Client Details|Click Client Role on Rolodex
    # Reusable flow: EQ|BOP|Client Details|Edit Client Roles
    When I press TAB, then click on "Inspection Contact"
    # Source step 0094: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Narrative"
    # Source step 0095: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0096: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0097: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0098: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Narrative"
    # Source step 0099: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0100: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0101: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0102: ------------------>EQ|Common|Verify that Edit is not displayed and Text is Locked
    # Reusable flow: EQ|Common|Narrative|Add/Edit a Narrative and Verify Timestamp
    Then I wait until "Narrative Screen Heading" exists
    And I click "Add Narrative"
    And I enter "Test Narrative 1" in "Description of the business exposures, activities and experience"
    And if source condition "'Referred and Locked' != \"Yes\"" is satisfied, I click "Save"
    And I wait until "User Date and Timestamp" is visible
    And "User Date and Timestamp" property "InnerText" should not equal Null
    And if source condition "'Referred and Locked' == \"Yes\"" is satisfied, "Locked This quote has been submitted and you can no longer make changes to this text." should exist
    And I leave "Description of the business exposures, activities and experience" blank
    And I capture "Name and Quote Num" as runtime value "NameQuoteNum"
    # Source step 0103: Set Quote_Num
    # Reusable flow: EQ|Common|Narrative|Add/Edit a Narrative and Verify Timestamp
    When I derive a partial runtime-buffer value for "Set Quote_Num" using source values "{\"Buffer\": \"Quote_Num\", \"Value\": \"{B[NameQuoteNum]}\", \"Last\": \"8\"}"
    # Source step 0104: Set QuoteID buffer
    # Reusable flow: EQ|Common|Narrative|Add/Edit a Narrative and Verify Timestamp
    When I set runtime value "QuoteID" from runtime value "Quote_Num"
    And runtime value "Policy#" is set to "Test1111"
    # Source step 0105: Buffer Screen Name
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Claims/Prior Insurance"
    # Source step 0106: Check if on Correct Screen
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0107: Navigate to Correct Screen
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0108: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0109: Buffer Screen Name
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Claims/Prior Insurance"
    # Source step 0110: Buffer Screen Name if different
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0111: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0112: Wait on for correct Screen
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0113: EQ|Prior Carrier-Claims|Enter Required Info
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    When I select "Prior Policy - No"
    # Source step 0114: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0115: EQ|Prior Carrier-Claims|Enter Required Info
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    When I press TAB, then enter "5", then press TAB, then press TAB on "Years In Business"
    # Source step 0116: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0117: EQ|Prior Carrier-Claims|Click 3+
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    When I click "3+ years"
    And I press TAB on "3+ years"
    # Source step 0118: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0119: EQ|Prior Carrier-Claims|Enter Latest Expiration
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    When I enter "1/1/2025", then press TAB in "Prior Insurance Latest Expiration Date"
    # Source step 0120: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0121: EQ|Prior Carrier-Claims|Enter Latest Carrier
    # Reusable flow: EQ|BOP|Prior Claims|Enter Required
    When I enter "GEICO", then press TAB in "Prior Insurance Latest Carrier"
    # Source step 0122: TBox Set Buffer
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When runtime value "Type of Loss" is set to "PROP"
    # Source step 0123: EQ|BOP|Claims/Prior Insurance|Add Claims - Date of Occurence
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I click "+ ADD CLAIM"
    And I press CTRL+A, then enter "01/02/2026", then press TAB on "Date Of Occurrence"
    # Source step 0124: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0125: EQ|BOP|Claims/Prior Insurance|Add Claims - Policy Start
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press CTRL+A, then enter "01-01-2026", then press TAB on "Policy Start"
    # Source step 0126: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0127: EQ|BOP|Claims/Prior Insurance|Add Claims - Policy Expire
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press CTRL+A, then enter "01-01-2027", then press TAB, then press TAB on "Policy Expire"
    # Source step 0128: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0129: EQ|BOP|Claims/Prior Insurance|Add Claims - Amount Paid
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press CTRL+A, then enter "15000", then press ENTER, then press TAB on "Amount Paid"
    # Source step 0130: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0131: EQ|BOP|Claims/Prior Insurance|Add Claims - Amount Reserved
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press CTRL+A, then enter "10000", then press ENTER, then press TAB on "Amount Reserved"
    # Source step 0132: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0133: EQ|BOP|Claims/Prior Insurance|Add Claims - Expense Amount
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press CTRL+A, then enter "500", then press ENTER, then press TAB on "Expense Amount"
    # Source step 0134: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0135: EQ|BOP|Claims/Prior Insurance|Add Claims - Type of Loss
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press TAB, then click on "Type of Loss Dropdown"
    And I click "Type of Loss Selection"
    # Source step 0136: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then I wait until "Loading ..." does not exist
    # Source step 0137: EQ|BOP|Claims/Prior Insurance|Add Claims -Description of Claim
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    When I press TAB, then press TAB, then enter "Accident", then press TAB on "Description Of Occurrence Or Claim"
    And I click "Open Button"
    And I click "Save"
    # Source step 0138: EQ|BOP|Claims/Prior Insurance|Add Claim|Claims Summary Table|Verify Headings
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then "Claim Summary Table > <Row> > <Cell> (ExplicitName=Claim Date)" should match Claim Date
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=Amount)" should match Amount
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=Line of Coverage)" should match Line of Coverage
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=Type of Loss)" should match Type of Loss
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=CAT Claim)" should match CAT Claim
    # Source step 0139: EQ|BOP|Claims/Prior Insurance|Add Claim|Claims Summary Table|Verify Correct Values
    # Reusable flow: EQ|BOP|Claims/Prior Insurance|Add/Verify/Delete Claims
    Then "Claim Summary Table > <Row> > <Cell> (ExplicitName=Claim Date)" should match 01/02/2026
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=Amount)" should match blank
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=Line of Coverage)" should match BOP
    And "Claim Summary Table > <Row> > <Cell> (ExplicitName=Type of Loss)" should match PROP
    # Source step 0141: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Locations/Buildings"
    # Source step 0142: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0143: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0144: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0145: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Locations/Buildings"
    # Source step 0146: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0147: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0148: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0149: Set Buffer for Edit Locations
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    When runtime value "Edit Location" is set to "1"
    And runtime value "Territory" is set to "001"
    # Source step 0150: EQ |Common|Loading Indicator Wait
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    Then I wait until "Loading ..." does not exist
    # Source step 0151: EQ|BOP|Locations/Buildings|Edit Location Selection
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    When I click "Edit Location Button - Latest Angular"
    # Source step 0152: EQ |Common|Loading Indicator Wait
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    Then I wait until "Loading ..." does not exist
    # Source step 0153: EQ|BOP|Edit Location|Select Territory Dropdown
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    Then I wait until "Edit Location Heading" exists
    # Source step 0155: EQ |Common|Loading Indicator Wait
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    Then I wait until "Loading ..." does not exist

    # ==============================================================================
    # Section: Policy Data Entry > Territory_MilesFromFireHydrant_FeetFrontHydrant
    # ==============================================================================
    # Source step 0160: Territory and FD
    # Reusable flow: EQ|BOP|Locations/Buildings|Edit a Location
    When I enter or select "001" in "Territory"
    And I press CTRL+A, then enter "1", then press TAB on "Miles From Fire Dept"
    And I enter or select "101 - 250" in "FeetfromHydrant"
    And I click "Save"
    And I wait until "Save" does not exist
    And if source condition "'Order Wildfire Risk Score' == \"Yes\"" is satisfied, I click "Order Wildfire Risk Score"

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0169: EQ|BOP|Select Add a Building Button
    # Reusable flow: EQ|BOP|Building|Add a Building Button
    When I click "+ Add Building / BPP"
    # Source step 0170: Set Ownership and Wait
    # Reusable flow: EQ|BOP|Building-1|Select Own or rent and Building SQ Footage Basic
    Then I wait until "Select if client owns or rents the building" is visible
    And if source condition "'Client Own or Rent' == \"OWN\"" is satisfied, I click/select "Own Button", then press TAB on "Own Button"
    And I wait until "Total Building Sq. Footage" is visible
    And I wait until "Insured Occupancy Sq Ft - Angular" is visible
    # Source step 0171: Navigate downscreen
    # Reusable flow: EQ|BOP|Building-1|Select Own or rent and Building SQ Footage Basic
    When I press SHIFT+TAB on "Insured Occupancy Sq Ft - Angular"
    # Source step 0172: Fill out Total Building Sq Footage
    # Reusable flow: EQ|BOP|Building-1|Select Own or rent and Building SQ Footage Basic
    When I enter "2500", then press TAB in "Total Building Sq. Footage"
    # Source step 0173: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-1|Select Own or rent and Building SQ Footage Basic
    Then I wait until "Loading ..." does not exist
    # Source step 0174: Fill out Insured Occupancy Sq Ft
    # Reusable flow: EQ|BOP|Building-1|Select Own or rent and Building SQ Footage Basic
    When I enter "2500", then press TAB in "Insured Occupancy Sq Ft - Angular"
    And I press TAB on "Insured Occupancy Sq Ft - Angular"
    # Source step 0175: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-1|Select Own or rent and Building SQ Footage Basic
    Then I wait until "Loading ..." does not exist
    # Source step 0176: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-2|Select Additional Coverages - Building, Functional Personal Property or Habitational
    Then I wait until "Loading ..." does not exist
    # Source step 0177: EQ|BOP Building|Select Building contains habitational occupancies
    # Reusable flow: EQ|BOP|Building-2|Select Additional Coverages - Building, Functional Personal Property or Habitational
    Then I wait until "Select if client owns or rents the building" is visible
    And if source condition "'Select Building Coverage' == \"Building Coverage\"" is satisfied, I use value "True", then press TAB on "Building Coverage - Angular"
    And if source condition "'Select Functional Personal Property' == \"Include Functional Personal Property\"" is satisfied, I click/select "Functional Personal Property unchecked", then press ENTER on "Functional Personal Property unchecked"
    And if source condition "'Select Building contains habitational occupancy' == \"Building contains habitational occupancies\"" is satisfied, I click/select "Building contains habitational occupancies unchecked", then press ENTER on "Building contains habitational occupancies unchecked"
    And if source condition "'Select Functional Personal Property' == \"Include Functional Personal Property\"" is satisfied, I wait until "Functional Personal Property checked" is visible
    And if source condition "'Select Building contains habitational occupancy' == \"Building contains habitational occupancies\"" is satisfied, I wait until "Building contains habitational occupancies checked" is visible
    # Source step 0178: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-2|Select Additional Coverages - Building, Functional Personal Property or Habitational
    Then I wait until "Loading ..." does not exist
    # Source step 0183: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-3|Select Occupancy SQ Footage
    Then I wait until "Loading ..." does not exist
    # Source step 0184: EQ|BOP Building Add Building|Fill out Insured Occupancy
    # Reusable flow: EQ|BOP|Building-3|Select Occupancy SQ Footage
    When I leave "Insured Occupancy Sq Ft" blank
    And I leave "Insured Occupancy Sq Ft" blank
    And I press TAB on "Insured Occupancy Sq Ft - Angular"
    And I click, then press CTRL+A, then enter "2500", then press TAB, then press TAB on "Insured Occupancy Sq Ft - Angular"
    # Source step 0185: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-3|Select Occupancy SQ Footage
    Then I wait until "Loading ..." does not exist
    # Source step 0186: EQ|BOP|Building|Class|Enter supplemental data for Class - Select Checkbox
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Class Codes" exists
    And I wait until "CheckBox - Angular" exists
    And I press TAB, then use value "True" on "CheckBox - Angular"
    And I click on "CheckBox - Angular"
    # Source step 0187: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Loading ..." does not exist
    # Source step 0188: EQ|BOP|Building|Class|Enter supplemental data for Class - Enter Occ Sq Ft Limit
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Occupancy SQ FT Heading" exists
    And I enter "2500", then press TAB in "Occupancy Sq Ft Limit"
    # Source step 0189: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Loading ..." does not exist
    # Source step 0190: EQ|BOP|Building|Class|Enter supplemental data for class - Verify Occ Sq Ft Total
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then "Occupancy Sq Footage Total" property "Value" should equal 2500
    # Source step 0191: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Loading ..." does not exist
    # Source step 0192: EQ|BOP|Building|Class|Enter supplemental data for selected Class - Select Personal Property Limiyt Checkbox
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Personal Property Limit CheckBox - Angular" exists
    And I press TAB, then use value "True" on "Personal Property Limit CheckBox - Angular"
    And I click on "Personal Property Limit CheckBox - Angular"
    # Source step 0193: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Loading ..." does not exist
    # Source step 0194: EQ|BOP|Building|Class|Enter supplemental data for selected Class - Select Personal Property Limit
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    When I enter "5000", then press TAB in "Personal Property Limit"
    # Source step 0195: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    Then I wait until "Loading ..." does not exist
    # Source step 0196: EQ|BOP|Building|Class|Enter supplemental data for selected Class Code - Select Gross Sales Limit
    # Reusable flow: EQ|BOP|Building-11|Class|Enter supplimental data- for class
    When I enter "25000", then press TAB in "Gross Sales Receipts"
    # Source step 0197: Set Buffers for BVS
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When runtime value "BVS Group" is set to "Offices"
    And runtime value "BVS Result" is set to "2100 - Office, Low-Rise"
    And runtime value "Roof Type" is set to "Aluminum- Shingle"
    # Source step 0198: EQ|BOP|Building|Select Commercial Type
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB, then press TAB on "Commercial Button"
    And I click "Commercial Button"
    # Source step 0199: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0200: EQ|BOP|Building|Select Estimator Type
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB, then press TAB on "BVS Button"
    And I click on "BVS Button"
    # Source step 0201: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0202: EQ|BOP|Building|Select Structure Type
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB on "Frame"
    And I click "Frame"
    # Source step 0203: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0204: EQ|BOP|Building|Select BVS Occupancy Group
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB, then click on "BVS Group Combobox"
    And I click on "BVS Group"
    # Source step 0206: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0207: EQ|BOP|Building|Select BVS Search Result
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB, then click on "BVS Results Combobox"
    And I click on "BVS Result"
    # Source step 0209: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0210: EQ|BOP|Building|Select Year
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB, then double-click on "Year Built"
    And I enter "2020", then press TAB in "Year Built"
    # Source step 0211: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0212: EQ|BOP|Building|Select Roof Type Get Evaluation
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    When I press TAB, then click on "Roof Type Main"
    And I click on "Roof Type Selection"
    And I press TAB, then press TAB on "Get Valuation"
    And I click "Get Valuation"
    # Source step 0213: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-18|Select Cost Estimator & Calculate Valuations
    Then I wait until "Loading ..." does not exist
    # Source step 0214: EQ|BOP|Building|Reposition Mouse for Scroll Down
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I press TAB on "Number Of Stories"
    # Source step 0216: EQ|BOP|Building|Select Rating Basis
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Building Details Heading" exists
    And if source condition "'Actual Cash Value' != NULL" is satisfied, I press TAB on "Actual Cash Value"
    And if source condition "'Actual Cash Value' != NULL" is satisfied, I click "Actual Cash Value"
    And if source condition "'Replacement Cost' != NULL" is satisfied, I press TAB on "Replacement Cost"
    And if source condition "'Replacement Cost' != NULL" is satisfied, I click "Replacement Cost"
    # Source step 0217: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0218: Wait for Building limit to become available
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait "10000" milliseconds for "Wait for Building limit to become available"
    # Source step 0219: EQ|BOP|Building|Select Building or Functional Limit and Year Renovated
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I press TAB, then click, then enter "443000", then press ENTER, then press TAB on "Building"
    # Source step 0220: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0221: EQ|BOP|Building|Select Year Renovated Built
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I press CTRL+A on "Year Built - Renovated"
    And I press DELETE on "Year Built - Renovated"
    And I press TAB, then click, then enter "2020", then press TAB on "Year Built - Renovated"
    # Source step 0222: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0224: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0225: EQ|BOP|Building|Select Wiring Year
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    # Source condition: 'Wiring Year' != NULL
    When I press CTRL+A on "Wiring Year"
    And I press DELETE on "Wiring Year"
    And I enter "2021", then press TAB in "Wiring Year"
    # Source step 0226: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0227: EQ|BOP|Building|Select Heating Year
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    # Source condition: 'Heating Year' != NULL
    When I press CTRL+A on "Heating Year"
    And I press DELETE on "Heating Year"
    And I click, then enter "2022", then press TAB on "Heating Year"
    # Source step 0228: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0229: EQ|BOP|Building|Select Plumbing Year
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    # Source condition: 'Plumbing Year' != NULL
    When I press CTRL+A on "Plumbing Year"
    And I press DELETE on "Plumbing Year"
    And I click, then enter "2023", then press TAB, then press TAB, then press TAB on "Plumbing Year"
    # Source step 0230: EQ|BOP|Building|Building Details|Select Burglar Alarm
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I execute Tosca step “EQ|BOP|Building|Building Details|Select Burglar Alarm” using module “EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm”
    # Source step 0231: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0232: EQ|BOP|Building|Building Details|Select Roof Year
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I enter "2024", then press TAB in "Roof Year"
    # Source step 0233: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0234: EQ|BOP|Building|Building Details|Select Sprinkler
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I select "Sprinkler - Yes"
    And I wait until "Sprinkler - Yes" is visible
    # Source step 0235: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0237: EQ|BOP|Building|Building Details|Select Ansul System for Restaurant Class
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    # Source condition: ANSUL != NULL
    And if source condition "ANSUL != NULL" is satisfied, I select "Automatic Commercial Cooking Exhaust and Extinguishing (ANSUL) System - Yes"
    # Source step 0238: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0245: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0248: EQ|BOP|Building|Building Details|Select if thermostatically controlled
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    When I select "Is any heat source thermostatically controlled? - Yes"
    # Source step 0249: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-19|Select Building Detail Fields
    Then I wait until "Loading ..." does not exist
    # Source step 0250: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    Then I wait until "Loading ..." does not exist
    # Source step 0251: EQ|BOP|Building|Building Details|Select Coal Furnace
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    When I use value "True", then press TAB on "Is the building heated with one of the following? - None of the Above Checkbox - Angular"
    # Source step 0252: EQ|BOP|Building|Building Details|Select Pellet Stove
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    When I execute Tosca step “EQ|BOP|Building|Building Details|Select Pellet Stove” using module “EQ|BOP|Building|Building Details|Heating Sources”
    # Source step 0253: EQ|BOP|Building|Building Details|Select Wood Furnace
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    When I execute Tosca step “EQ|BOP|Building|Building Details|Select Wood Furnace” using module “EQ|BOP|Building|Building Details|Heating Sources”
    # Source step 0254: EQ|BOP|Building|Building Details|Select Wood Stove
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    When I execute Tosca step “EQ|BOP|Building|Building Details|Select Wood Stove” using module “EQ|BOP|Building|Building Details|Heating Sources”
    # Source step 0255: EQ|BOP|Building|Building Details|Select None of the Above
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    When I use value "True", then press TAB on "Is the building heated with one of the following? - None of the Above Checkbox - Angular"
    # Source step 0256: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-20|Building Details|Select Heating Sources
    Then I wait until "Loading ..." does not exist
    # Source step 0257: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-21|Building Details|Select Additional Property checkboxes|Extra Property Risk
    Then I wait until "Loading ..." does not exist
    # Source step 0258: EQ|BOP|Building|Building Details|Select Extra Property Risk
    # Reusable flow: EQ|BOP|Building-21|Building Details|Select Additional Property checkboxes|Extra Property Risk
    When I use value "True", then press TAB on "Select any of the following which apply to this building - None of the Above Checkbox - Angular"
    # Source step 0259: EQ Loading Indicator Wait
    # Reusable flow: EQ|BOP|Building-21|Building Details|Select Additional Property checkboxes|Extra Property Risk
    Then I wait until "Loading ..." does not exist
    # Source step 0260: EQ|BOP|Building|Building Details|Answer any Extra Property Additional Questions
    # Reusable flow: EQ|BOP|Building-21|Building Details|Select Additional Property checkboxes|Extra Property Risk
    When I execute Tosca step “EQ|BOP|Building|Building Details|Answer any Extra Property Additional Questions” using module “EQ|BOP|Building|Building Details|Addl Property Questions”
    # Source step 0261: EQ |Common|Loading Indicator Wait
    Then I wait until "Loading ..." does not exist
    # Source step 0262: EQ|BOP|Building|Building Eligibility Questions
    # Reusable flow: EQ|BOP|Building-26|Answer Building Eligibility Questions
    When I use value "True", then press TAB on "Building Eligibility Questions - None of the Above Checkbox - Angular"
    And I click "Save"
    # Source step 0263: Set Buffer for WaitOnTime
    When runtime value "WaitOnTime" is set to "60000"
    # Source step 0264: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Policy Coverages"
    # Source step 0265: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0266: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0267: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0268: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Policy Coverages"
    # Source step 0269: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0270: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0271: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0272: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Additional Coverages"
    # Source step 0273: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0274: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0275: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0276: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Additional Coverages"
    # Source step 0277: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0278: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0279: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0280: EQ|BOP|Additional Coverages|Answer EPLI Questions
    # Reusable flow: EQ|BOP|Additional Coverages|Answer EPLI Questions
    When I press TAB, then click, then enter "No", then press ENTER, then press TAB, then press TAB on "Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?"
    # Source step 0281: EQ |Common|Loading Indicator Wait
    # Reusable flow: EQ|BOP|Additional Coverages|Answer EPLI Questions
    Then I wait until "Loading ..." does not exist
    # Source step 0282: EQ|BOP|Additional Coverages|Answer EPLI Questions_1
    # Reusable flow: EQ|BOP|Additional Coverages|Answer EPLI Questions
    When I long-click, then enter "No", then press ENTER, then press TAB on "Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?"
    # Source step 0283: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Billing"
    # Source step 0284: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0285: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0286: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0287: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Billing"
    # Source step 0288: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0289: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0290: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0291: EQ|Common|Billing
    # Reusable flow: CL|EQ|Common|Billing|Billing Account Setup
    Then I wait until "Billing Information Heading" exists
    And I click "Create New Billing Account"
    # Source step 0292: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Billing|Billing Account Setup > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0293: EQ|Common|Billing - Enter Other Info
    # Reusable flow: CL|EQ|Common|Billing|Billing Account Setup
    # Source condition: LOB != "SFP"
    Then I wait until "Billing Information Heading" exists
    And I click "OTHER Button"
    And I enter "Tommy", then press TAB in "First Name"
    And I enter "Automation", then press TAB in "Last Name"
    And I enter "Auto Corp", then press TAB in "Business Name"
    And I enter "9 Center Road", then press TAB in "Address1"
    And I enter "Mahopac", then press TAB in "City"
    And I enter "NY", then press TAB in "State"
    And I enter "10541", then press TAB, then press TAB, then press TAB in "Zip Code"
    # Source step 0294: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Billing|Future Payment Plan_1
    Then I wait until "Loading ..." does not exist
    # Source step 0295: EQ|CommonP|Billing|Select Direct Bill and Payment Plan
    # Reusable flow: CL|EQ|Common|Billing|Future Payment Plan_1
    When I click/select "Direct Bill Button", then press TAB on "Direct Bill Button"
    And I click/select "1 Payment Button", then press TAB, then press TAB on "1 Payment Button"
    # Source step 0296: Wait on screen to update
    # Reusable flow: CL|EQ|Common|Billing|Future Payment Plan_1
    Then I wait "5000" milliseconds for "Wait on screen to update"
    # Source step 0297: EQ|Common|Billing|Select Payment Due Date
    # Reusable flow: CL|EQ|Common|Billing|Future Payment Plan_1
    When I enter "01", then press TAB in "Choose payment due date"
    # Source step 0298: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Billing|Future Payment Plan_1
    Then I wait until "Loading ..." does not exist
    # Source step 0299: EQ|Common|Billing|Select Initial Payment Method
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    And if source condition "'Payment Type' ==\"Check\"" is satisfied, I click/select "Check Button", then press TAB, then press TAB on "Check Button"
    And if source condition "'Payment Type' ==\"Credit Card\"" is satisfied, I click/select "Credit Card Button", then press TAB, then press TAB on "Credit Card Button"
    # Source step 0300: EQ |Common|Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    Then I wait until "Loading ..." does not exist
    # Source step 0301: EQ|Common|Billing|Fill in Check Number
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    # Control flow: IF: If Check Number field exists [condition='Payment Type' == "Check"] > Verify Check Number
    # Source condition: 'Payment Type' == "Check"
    And if source condition "'Payment Type' == \"Check\"" is satisfied, "Check Number" should not exist
    # Source step 0302: EQ|Common|Billing|Select Initial Payment Method
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    # Control flow: IF: If Check Number field exists [condition='Payment Type' == "Check"] > Then
    # Source condition: 'Payment Type' == "Check"
    And if source condition "'Payment Type' == \"Check\"" is satisfied, I click/select "Check Button", then press TAB, then press TAB on "Check Button"
    And if source condition "'Payment Type' == \"Check\"" is satisfied, I click/select "Credit Card Button", then press TAB, then press TAB on "Credit Card Button"
    # Source step 0303: EQ |Common|Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    # Control flow: IF: If Check Number field exists [condition='Payment Type' == "Check"] > Then
    # Source condition: 'Payment Type' == "Check"
    And if source condition "'Payment Type' == \"Check\"" is satisfied, I wait until "Loading ..." does not exist
    # Source step 0304: EQ|Common|Billing|Fill in Check Number
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    # Control flow: IF: If Check Number field exists [condition='Payment Type' == "Check"] > Then
    # Source condition: 'Payment Type' == "Check"
    And if source condition "'Payment Type' == \"Check\"" is satisfied, I wait until "Check Number" exists
    # Source step 0305: EQ|Common|Billing|Fill in Check Number
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    # Source condition: 'Payment Type' == "Check"
    And if source condition "'Payment Type' == \"Check\"" is satisfied, I enter "1205", then press ENTER, then press TAB, then press TAB in "Check Number"
    # Source step 0306: EQ |Common|Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    Then I wait until "Loading ..." does not exist
    # Source step 0307: EQ|Common|Billing|Select Initial Payment Amount
    # Reusable flow: CL|EQ|Common|Billing|Initial Payment
    When I click "Initial Payment - Full Balance"
    # Source step 0308: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Pricing"
    # Source step 0309: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0310: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0311: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0312: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Pricing"
    # Source step 0313: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0314: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0315: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0316: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Billing"
    # Source step 0317: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0318: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0319: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0320: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Billing"
    # Source step 0321: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0322: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0323: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0324: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Pricing"
    # Source step 0325: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0326: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0327: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0328: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Pricing"
    # Source step 0329: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0330: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0331: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0332: EQ|BOP|Pricing|Insurance Score and Premium
    # Reusable flow: EQ|BOP|Pricing|Insurance Score and Premium Verification
    When I capture "Premium" as runtime value "Premium"
    # Source step 0333: EQ|BOP|Pricing|Verify Premiums
    # Reusable flow: EQ|BOP|Pricing|Insurance Score and Premium Verification
    Then "TABLE > <Row> > <Cell> (ExplicitName=$1)" should match $2,084.00
    # Source step 0334: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Submission"
    # Source step 0335: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0336: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0337: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0338: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Submission"
    # Source step 0339: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0340: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0341: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote
    # ==============================================================================
    # Source step 0351: Open a Browser
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0352: Close Explorer Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0353: Close Chrome Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0354: Close Firefox Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0355: Close Edge Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0356: Close Edge Beta Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0357: Open Edge Preferences file
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0358: Change Exit Type
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0359: Save changes
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0360: Delete EdgePreferences Resource
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote
    # ==============================================================================
    # Source step 0361: Delete Cookies File
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0362: Open broswer and navigate to EQ
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I open "https://expertquote-qa.americannational.com/expertquote/" in the active browser tab
    # Source step 0363: Wait on Edge Browser to open
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "BODY" exists
    # Source step 0364: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "Loading ..." does not exist
    # Source step 0365: Policy Load Sync
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0366: Restart Microsoft Edge Message Exists?
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Check if Edge Popup is showing
    And if the Restart Microsoft Edge popup is displayed, "OK" should exist
    # Source step 0367: Restart Microsoft Edge Message - Click OK
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Then
    And if the Restart Microsoft Edge popup is displayed, I click "OK"
    # Source step 0370: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "Loading ..." does not exist
    # Source step 0371: EQ|Common|Check if Logout Exists
    # Reusable flow: EQ|Common|Open EQ in Browser
    # Control flow: IF: If Still Logged in to EQ > Check for Logout button
    And if an existing ExpertQuote session is still logged in, "logout" should exist
    # Source step 0372: EQ|Common|Click Logout of EQ
    # Reusable flow: EQ|Common|Open EQ in Browser
    # Control flow: IF: If Still Logged in to EQ > Then
    And if an existing ExpertQuote session is still logged in, I click "logout"
    And if an existing ExpertQuote session is still logged in, I click "logout Log Out"
    # Source step 0373: Login
    # Reusable flow: EQ|Common|Login to EQ (SSO)
    Then I wait until the username field exists
    When I log in with username "YDH040" and password "${ENV:CL_EQ_PASSWORD}"
    # Source step 0374: Retrieve Dex Agent Name
    # Reusable flow: EQ|Common|Login to EQ (SSO)
    When I set runtime value "GetHostname" from runtime environment value "COMPUTERNAME"
    And I set runtime value "AgentName" from runtime value "GetHostname"
    # Source step 0375: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0376: Search by QuoteNum
    # Reusable flow: CL|EQ|Common|Search by QuoteNum
    When I use RUNTIME-DERIVED value from "{SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}" in "quoteSearchInput"
    And I click "Search"
    # Source step 0377: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0378: CL|EQ|Common|Search Policy Results Table
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Check if Results Table Exists
    And if results Table Exists, "Results TABLE" should exist
    # Source step 0379: CL|EQ|Common|Search Policy Results Table
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Then Click on Edit Policy/Quote
    And if results Table Exists, "Results TABLE > <Row> > <Cell> (ExplicitName=Name)" should match RUNTIME-DERIVED value from "{STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}"
    And if results Table Exists, I click "Results TABLE > edit"
    # Source step 0380: Waiton Name and QuoteNum
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Else Quote is already opened
    And if results Table Exists, I wait until "Name and Quote Num" property "InnerText" does not equal New Quote
    # Source step 0381: Verify QuoteNum
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Else Quote is already opened
    And if results Table Exists, "Name and Quote Num" property "InnerText" should equal RUNTIME-DERIVED value from "{REGEX[{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}]}"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek
    # ==============================================================================
    # Source step 0382: Open a Browser
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0383: Close Explorer Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0384: Close Chrome Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0385: Close Firefox Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0386: Close Edge Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0387: Close Edge Beta Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0388: Open Edge Preferences file
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0389: Change Exit Type
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0390: Save changes
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0391: Delete EdgePreferences Resource
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek
    # ==============================================================================
    # Source step 0392: Delete Cookies File
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0393: OpenUrl
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I open "http://svqw-clas21:8080/express/"
    # Source step 0394: Wait on Edge Browser to open
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "BODY" exists
    # Source step 0395: Policy Load Sync
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0396: Edge Popup message- ImageBased
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If EQ Popup is showing > Check if EQ Popup is showing
    And if eQ Popup is showing, "Button" should exist
    # Source step 0397: Edge Popup message- ImageBased
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If EQ Popup is showing > Then
    And if eQ Popup is showing, I click "Button"
    # Source step 0398: Verify Username exists
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If still Logged into CLAS > Verify if Username is available
    And if an existing CLAS session is still logged in, "UserName" should not exist
    # Source step 0399: Logout
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, the source configuration "Logged In User" is click
    And if an existing CLAS session is still logged in, I click "Logged In User > Logout"
    # Source step 0400: Sync for Log out
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, I wait "1000" milliseconds for "Sync for Log out"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek > Http Error Msg
    # ==============================================================================
    # Source step 0401: Check for Http Error Msg
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Check if Error Msg Exists
    And if an existing CLAS session is still logged in, "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist
    # Source step 0402: Click OK on Http Error Msg
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, I click "OK"
    # Source step 0403: Check Http Error Msg does not exist
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, I wait until "OK" is not visible
    # Source step 0404: Logout
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, the source configuration "Logged In User" is click
    And if an existing CLAS session is still logged in, I click "Logged In User > Logout"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek
    # ==============================================================================
    # Source step 0406: OpenUrl
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, I open "http://svqw-clas21:8080/express/" in the active browser tab
    # Source step 0407: Login
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I log in with username "FFQA008" and password "${ENV:TOSCA_PROTECTED_PASSWORD}"
    # Source step 0408: Wait for Login Screen to Go Away
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "Login" does not exist
    # Source step 0409: Enter Desc in QuickSearch
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC
    When I use RUNTIME-DERIVED value from "{B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}" in "Search Text"
    And I click "QuickSearch Button"
    # Source step 0410: Enter Info to Search by Desc
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC
    When I use value "Description", then press TAB, then press TAB on "Search Method (e.g. Description/Policy#)"
    And I wait until "Search Button" property "Enabled" equals True
    And I press TAB on "Search Button"
    And I click "Search Button"
    # Source step 0411: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0412: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0413: Click Search by Desc
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC
    Then I wait until "View Policy" exists
    And I press TAB on "View Policy"
    And I press TAB on "Search Button"
    And I click "Search Button"
    # Source step 0414: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0415: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0416: Verify View Policy
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "View Policy" exists
    # Source step 0417: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0418: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0419: Click View Policy
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I click "View Policy"
    # Source step 0420: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0421: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0422: Wait until View Policy does not exist
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "View Policy" does not exist
    # Source step 0423: Policy Load Sync
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0445: Delete LastResponseResource
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I delete runtime resource "LastResponseResource"
    # Source step 0446: Open DevTools Console
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I send the configured keys using "{\"Keys\": \"\\\"^+j\\\"\"}"
    # Source step 0447: Wait
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    Then I wait "1500" milliseconds for "Wait"
    # Source step 0448: Enable Pasting in Console
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I send the configured keys using "{\"Keys\": \"\\\"allow pasting\\\" ~\"}"
    # Source step 0449: Get QuoteID by Console
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I send the configured keys using "{\"Keys\": \"\\\"copy{(}document.getElementById{(}'_QuoteID'{)}.value{)}\\\" ~\"}"
    # Source step 0450: Save QuoteID Buffer
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I perform the clipboard operation using "{\"Value\": \"{XB[QuoteID]}\"}"
    # Source step 0451: Verify QuoteID Buffer
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I perform the clipboard operation using "{\"Value\": \"{XB[QuoteID]}\"}"
    # Source step 0452: Get SessionID by Console
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I send the configured keys using "{\"Keys\": \"\\\"copy{(}DCT.sessionID{)}\\\" ~\"}"
    # Source step 0453: Save SessionID Buffer
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I perform the clipboard operation using "{\"Value\": \"{XB[SessionId]}\"}"
    # Source step 0454: Verify SessionID Buffer
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I perform the clipboard operation using "{\"Value\": \"{XB[SessionId]}\"}"
    # Source step 0455: Buffer Server Address
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When runtime value "ServerAddress" is set to "http://svqw-clas21:8080/duckcreek/dctserver.aspx"
    # Source step 0456: Forms API Request
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I use runtime value "SessionId" for "sessionID" in "Forms API Request"
    # Source step 0457: Forms API Response
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    Then I use 200 OK for "StatusCode" in "Forms API Response"
    # Source step 0458: Sync API
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    Then I wait "250" milliseconds for "Sync API"
    # Source step 0459: Save the Response as XML file
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I save the XML resource using "{\"Resource\": \"LastResponseResource\", \"Filepath\": \"\\\\\\\\mis\\\\sys\\\\QLTY\\\\Test_Automation\\\\Tricentis_Tosca\\\\Forms_Check\\\\BOPSmart\\\\BOPSmart_BASIC_AL_{B[QuoteID]}.xml\"}"
    # Source step 0460: Sync API
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    Then I wait "250" milliseconds for "Sync API"
    # Source step 0461: Buffer Powershell Arguments
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I set runtime value "PowershellArguments" from RUNTIME-DERIVED value from "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOPSmart\\\" -FileName \"BOPSmart_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""
    # Source step 0462: Execute Powershell Script
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I run system command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" with WaitForExit="True"
    # Source step 0463: Display the Results Summary
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When I perform the clipboard operation using "{\"Value\": \"SummaryResults\"}"
    # Source step 0464: Check and Report for Fails in the Forms Verification from the SummaryResults
    # Reusable flow: Common|General|Forms Verification_Retrieve QuoteID & SessionID by Browser Console
    When runtime value "SummaryResults" is set to "*FAIL:0 *"
    And runtime value "SummaryResults" is set to "*Forms Listed:0 *"
    And runtime value "SummaryResults" is set to "*INFO:0 *"
    And runtime value "SummaryResults" is set to "*Other: 0*"
    # Source step 0465: Check for Save for Later Button
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Save for Later Button to avoid Locking the Policy > Condition
    And if check for Save for Later Button to avoid Locking the Policy, "Save for Later" should exist
    # Source step 0466: Save for Later
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Save for Later Button to avoid Locking the Policy > Then
    And if check for Save for Later Button to avoid Locking the Policy, I click "Save for Later"
    And if check for Save for Later Button to avoid Locking the Policy, I wait until "Save for Later - OK" exists
    And if check for Save for Later Button to avoid Locking the Policy, I click "Save for Later - OK"
    # Source step 0467: Check for Return to Admin Button
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Return to Admin Button to avoid Locking the Policy > Condition
    And if check for Return to Admin Button to avoid Locking the Policy, "Return To Admin" should exist
    # Source step 0468: Return To Admin
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Return to Admin Button to avoid Locking the Policy > Then
    And if check for Return to Admin Button to avoid Locking the Policy, I click "Return To Admin"
    And if check for Return to Admin Button to avoid Locking the Policy, I wait until "Return To Admin" does not exist

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote
    # ==============================================================================
    # Source step 0469: Open a Browser
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0470: Close Explorer Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0471: Close Chrome Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0472: Close Firefox Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0473: Close Edge Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0474: Close Edge Beta Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0475: Open Edge Preferences file
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0476: Change Exit Type
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0477: Save changes
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0478: Delete EdgePreferences Resource
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote
    # ==============================================================================
    # Source step 0479: Delete Cookies File
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0480: Open broswer and navigate to EQ
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I open "https://expertquote-qa.americannational.com/expertquote/" in the active browser tab
    # Source step 0481: Wait on Edge Browser to open
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "BODY" exists
    # Source step 0482: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "Loading ..." does not exist
    # Source step 0483: Policy Load Sync
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0484: Restart Microsoft Edge Message Exists?
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Check if Edge Popup is showing
    And if the Restart Microsoft Edge popup is displayed, "OK" should exist
    # Source step 0485: Restart Microsoft Edge Message - Click OK
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Then
    And if the Restart Microsoft Edge popup is displayed, I click "OK"
    # Source step 0488: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "Loading ..." does not exist
    # Source step 0489: EQ|Common|Check if Logout Exists
    # Reusable flow: EQ|Common|Open EQ in Browser
    # Control flow: IF: If Still Logged in to EQ > Check for Logout button
    And if an existing ExpertQuote session is still logged in, "logout" should exist
    # Source step 0490: EQ|Common|Click Logout of EQ
    # Reusable flow: EQ|Common|Open EQ in Browser
    # Control flow: IF: If Still Logged in to EQ > Then
    And if an existing ExpertQuote session is still logged in, I click "logout"
    And if an existing ExpertQuote session is still logged in, I click "logout Log Out"
    # Source step 0491: Login
    # Reusable flow: EQ|Common|Login to EQ (SSO)
    Then I wait until the username field exists
    When I log in with username "YDH040" and password "${ENV:CL_EQ_PASSWORD}"
    # Source step 0492: Retrieve Dex Agent Name
    # Reusable flow: EQ|Common|Login to EQ (SSO)
    When I set runtime value "GetHostname" from runtime environment value "COMPUTERNAME"
    And I set runtime value "AgentName" from runtime value "GetHostname"
    # Source step 0493: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0494: Search by QuoteNum
    # Reusable flow: CL|EQ|Common|Search by QuoteNum
    When I use RUNTIME-DERIVED value from "{SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}" in "quoteSearchInput"
    And I click "Search"
    # Source step 0495: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0496: CL|EQ|Common|Search Policy Results Table
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Check if Results Table Exists
    And if results Table Exists, "Results TABLE" should exist
    # Source step 0497: CL|EQ|Common|Search Policy Results Table
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Then Click on Edit Policy/Quote
    And if results Table Exists, "Results TABLE > <Row> > <Cell> (ExplicitName=Name)" should match RUNTIME-DERIVED value from "{STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}"
    And if results Table Exists, I click "Results TABLE > edit"
    # Source step 0498: Waiton Name and QuoteNum
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Else Quote is already opened
    And if results Table Exists, I wait until "Name and Quote Num" property "InnerText" does not equal New Quote
    # Source step 0499: Verify QuoteNum
    # Reusable flow: CL|EQ|Common|Search Results Table
    # Control flow: IF: If Results Table Exists > Else Quote is already opened
    And if results Table Exists, "Name and Quote Num" property "InnerText" should equal RUNTIME-DERIVED value from "{REGEX[{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}]}"

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0500: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Submission"
    # Source step 0501: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0502: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0503: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0504: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Submission"
    # Source step 0505: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0506: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0507: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0508: EQ|BOP|Submission
    # Reusable flow: EQ|Common|Submission|Checklist and Esign
    Then I wait until "Submission Screen Heading" exists
    And if source condition "'Referral Needed' != NULL" is satisfied, "No Referral Needed Verification" should not exist
    And I click "Launch to Checklist Button"
    And if source condition "'Referral Needed' == NULL" is satisfied, "No Referral Needed Verification" should exist
    # Source step 0509: Set Buffer for WaitOnTime
    When runtime value "WaitOnTime" is set to "30000"

    # ==============================================================================
    # Section: Policy Data Entry > Checklist
    # ==============================================================================
    # Source step 0510: CL|EQ|eChecklist -Building Photo1
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo1
    When I click on "Building Photo 1"
    And I wait until "Building Photo 1 Header" exists
    And I click "Exception"
    And I enter or select "Test" in "Add a Note..."
    And I click "OK"
    And I wait until "OK" is not visible
    # Source step 0511: CL|EQ|eChecklist -Sync
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo1
    Then I wait until "Building Photo 1 Header" does not exist
    # Source step 0512: CL|EQ|eChecklist -Building Photo2
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo2
    Then I wait until "Building Photo 2 Header" exists
    And I click "Exception"
    And I enter or select "Test" in "Add a Note..."
    And I click "OK"
    And I wait until "OK" is not visible
    # Source step 0513: CL|EQ|eChecklist -Sync
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo2
    Then I wait until "Building Photo 2" does not exist
    # Source step 0514: CL|EQ|eChecklist -Building Photo3
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo3
    Then I wait until "Building Photo 3 Header" exists
    And I click "Exception"
    And I enter or select "Test" in "Add a Note..."
    And I click "OK"
    And I wait until "OK" is not visible
    # Source step 0515: CL|EQ|eChecklist -Sync
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo3
    Then I wait until "Building Photo 3" does not exist
    # Source step 0516: CL|EQ|eChecklist -Building Photo4
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo4
    Then I wait until "Building Photo 4 Header" exists
    And I click "Exception"
    And I enter or select "Test" in "Add a Note..."
    And I click "OK"
    And I wait until "OK" is not visible
    # Source step 0517: CL|EQ|eChecklist -Sync
    # Reusable flow: CL|EQ|Common|eChecklist - Building Photo4
    Then I wait until "Building Photo 4" does not exist
    # Source step 0518: CL|EQ|eChecklist -Loss Runs - 3 Yrs
    # Reusable flow: CL|EQ|Common|eChecklist - Loss Runs - 3 Years
    When I leave "All Link" blank
    And I wait until "Loss Runs Header" exists
    And I click "Exception"
    And I wait until "Add a Note..." is visible
    And I use value "Test", then press TAB on "Add a Note..."
    And I click "OK"
    And I wait until "OK" is not visible
    # Source step 0519: CL|EQ|eChecklist -Sync
    # Reusable flow: CL|EQ|Common|eChecklist - Loss Runs - 3 Years
    Then I wait until "Loss Runs - 3 years Header" does not exist
    # Source step 0520: CL|EQ|Esignature|Click OK
    # Reusable flow: CL|EQ|Common|Esignature|Click OK
    When I click "Ok To Update from Checklist"

    # ==============================================================================
    # Section: Policy Data Entry > Refer to UW in EQ
    # ==============================================================================
    # Source step 0552: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Submission"
    # Source step 0553: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0554: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0555: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0556: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Submission"
    # Source step 0557: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0558: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0559: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0560: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Regression|Refer to UW > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0561: Wait for Sync
    # Reusable flow: CL|EQ|Common|Regression|Refer to UW
    Then I wait "4000" milliseconds for "Wait for Sync"
    # Source step 0562: EQ|Submission|Refer to UW
    # Reusable flow: CL|EQ|Common|Regression|Refer to UW
    When I enter "Testing for Refer to UW", then press ENTER, then press TAB, then press TAB in "Underwriting Rules - Agent Comments"
    And I click "Refer to UW"

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS
    # ==============================================================================
    # Source step 0563: Open a Browser
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0564: Close Explorer Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0565: Close Chrome Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0566: Close Firefox Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0567: Close Edge Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0568: Close Edge Beta Browsers
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0569: Open Edge Preferences file
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0570: Change Exit Type
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0571: Save changes
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0572: Delete EdgePreferences Resource
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS
    # ==============================================================================
    # Source step 0573: Delete Cookies File
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|DC|Common|Reset Edge Preferences
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0574: OpenUrl
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I open "http://svqw-clas21:8080/express/"
    # Source step 0575: Wait on Edge Browser to open
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "BODY" exists
    # Source step 0576: Policy Load Sync
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0577: Edge Popup message- ImageBased
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If EQ Popup is showing > Check if EQ Popup is showing
    And if eQ Popup is showing, "Button" should exist
    # Source step 0578: Edge Popup message- ImageBased
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If EQ Popup is showing > Then
    And if eQ Popup is showing, I click "Button"
    # Source step 0579: Verify Username exists
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If still Logged into CLAS > Verify if Username is available
    And if an existing CLAS session is still logged in, "UserName" should not exist
    # Source step 0580: Logout
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, the source configuration "Logged In User" is click
    And if an existing CLAS session is still logged in, I click "Logged In User > Logout"
    # Source step 0581: Sync for Log out
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, I wait "1000" milliseconds for "Sync for Log out"

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS > Http Error Msg
    # ==============================================================================
    # Source step 0582: Check for Http Error Msg
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Check if Error Msg Exists
    And if an existing CLAS session is still logged in, "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist
    # Source step 0583: Click OK on Http Error Msg
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, I click "OK"
    # Source step 0584: Check Http Error Msg does not exist
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, I wait until "OK" is not visible
    # Source step 0585: Logout
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, the source configuration "Logged In User" is click
    And if an existing CLAS session is still logged in, I click "Logged In User > Logout"

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS
    # ==============================================================================
    # Source step 0587: OpenUrl
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, I open "http://svqw-clas21:8080/express/" in the active browser tab
    # Source step 0588: Login
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I log in with username "FFQA008" and password "${ENV:TOSCA_PROTECTED_PASSWORD}"
    # Source step 0589: Wait for Login Screen to Go Away
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "Login" does not exist
    # Source step 0590: Enter Desc in QuickSearch
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC
    When I use RUNTIME-DERIVED value from "{B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}" in "Search Text"
    And I click "QuickSearch Button"
    # Source step 0591: Enter Info to Search by Desc
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC
    When I use value "Description", then press TAB, then press TAB on "Search Method (e.g. Description/Policy#)"
    And I wait until "Search Button" property "Enabled" equals True
    And I press TAB on "Search Button"
    And I click "Search Button"
    # Source step 0592: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0593: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0594: Click Search by Desc
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC
    Then I wait until "View Policy" exists
    And I press TAB on "View Policy"
    And I press TAB on "Search Button"
    And I click "Search Button"
    # Source step 0595: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0596: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > CL|EQ|Common|Search by Desc in DC > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0597: Verify View Policy
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "View Policy" exists
    # Source step 0598: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0599: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0600: Click View Policy
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    When I click "View Policy"
    # Source step 0601: Check for Loading Indicator
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0602: Wait 2 secs
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0603: Wait until View Policy does not exist
    # Reusable flow: CL|EQ|Common|Open a CLAS Browser and Search for EQ by Description
    Then I wait until "View Policy" does not exist
    # Source step 0609: Navigate to Submission Screen
    Then I wait until "Submission" is visible
    And I click "Submission"
    # Source step 0610: Check to see Submission Screen Header Exists
    # Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page
    # Control flow: IF: Determine if on submission page > Condition
    And if determine if on submission page, "Submission Heading" should not exist
    # Source step 0611: Navigate to Submission Screen
    # Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page
    # Control flow: IF: Determine if on submission page > Then
    And if determine if on submission page, I press TAB on "Submission"
    And if determine if on submission page, I click "Submission"
    # Source step 0612: Wait for Synchronization
    # Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page
    # Control flow: IF: Determine if on submission page > Then
    And if determine if on submission page, I wait "1250" milliseconds for "Wait for Synchronization"
    # Source step 0613: Wait on Submission Screen to Load
    # Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page
    # Control flow: IF: Determine if on submission page > Then
    And if determine if on submission page, I wait until "Submission Heading" exists
    # Source step 0614: 500ms wait for syncing
    # Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page
    # Control flow: IF: Determine if on submission page > Then
    And if determine if on submission page, I wait "500" milliseconds for "500ms wait for syncing"
    # Source step 0615: Check to see Coverage is bound Exists
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Coverage is bound exists, make sure it is answered > Condition
    And if coverage is bound exists, make sure it is answered, "Is this coverage bound?*" should exist
    # Source step 0616: Check Is Coverage bound (select)
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Coverage is bound exists, make sure it is answered > Then > IF: If Coverage is (select) > Condition
    And if coverage is bound exists, make sure it is answered, "Is this coverage bound?*" property "Value" should equal (select)
    # Source step 0617: Answer Is Coverage bound
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Coverage is bound exists, make sure it is answered > Then > IF: If Coverage is (select) > Then
    And if coverage is bound exists, make sure it is answered, I use value "Yes", then press TAB, then press TAB on "Is this coverage bound?*"
    # Source step 0618: Run Stoplight
    # Reusable flow: Common|Submission|Run Stoplight
    When I click "Complete Application"
    # Source step 0619: Run Stoplight
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Condition
    And during do (Wait for Stoplight to Run) [max=90], "stoplightWaitingWindow > Close" should not exist
    # Source step 0620: Wait 2 Seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop
    And during do (Wait for Stoplight to Run) [max=90], I wait "2000" milliseconds for "Wait 2 Seconds"
    # Source step 0621: Check for error
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Condition
    And during do (Wait for Stoplight to Run) [max=90], "stoplightWaitingWindow > Error:" should exist
    # Source step 0622: Set Error Flag
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    When runtime value "ErrorFlag" is set to "Yes"
    And runtime value "ErrorFlag" is set to "No"
    And runtime value "REPETITION" is set to "1"
    # Source step 0666: Click First Close button on Error
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And during do (Wait for Stoplight to Run) [max=90], I click "stoplightWaitingWindow > First Close button on Error"
    # Source step 0667: Wait 3 Seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And during do (Wait for Stoplight to Run) [max=90], I wait "3000" milliseconds for "Wait 3 Seconds"
    # Source step 0668: Click Complete App
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And during do (Wait for Stoplight to Run) [max=90], I click "Complete Application"
    # Source step 0669: Wait 3 Seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And during do (Wait for Stoplight to Run) [max=90], I wait "3000" milliseconds for "Wait 3 Seconds"
    # Source step 0670: Close Stoplight Window
    # Reusable flow: Common|Submission|Run Stoplight
    When I click "stoplightWaitingWindow > Close"
    # Source step 0671: Wait on Stoplight window to go away
    # Reusable flow: Common|Submission|Run Stoplight
    Then I wait until "stoplightWaitingWindow" does not exist

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS > If Stoplight Parameter = True
    # ==============================================================================
    # Source step 0672: Check for Loading Indicator
    # Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0673: Wait 2 secs
    # Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0674: Wait for Stoplight message to exist
    # Reusable flow: Common|Submission|Run Stoplight
    Then I wait until "All required fields have not been completed. Please complete highlighted tabs." exists
    And "All required fields have not been completed. Please complete highlighted tabs." should exist

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS > If Stoplight Parameter = False
    # ==============================================================================
    # Source step 0675: Wait 3.5 seconds
    # Reusable flow: Common|Submission|Run Stoplight
    Then I wait "3500" milliseconds for "Wait 3.5 seconds"
    # Source step 0676: Check for Loading Indicator
    # Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0677: Wait 2 secs
    # Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0678: Stoplight message is visible
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Condition
    And if stoplight error, "All required fields have not been completed. Please complete highlighted tabs." should exist
    # Source step 0679: Run Stoplight
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then
    And if stoplight error, I click "Complete Application"
    # Source step 0680: Run Stoplight
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Condition
    And if stoplight error, "stoplightWaitingWindow > Close" should not exist
    # Source step 0681: Wait 2 Seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop
    And if stoplight error, I wait "2000" milliseconds for "Wait 2 Seconds"
    # Source step 0682: Check for error
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Condition
    And if stoplight error, "stoplightWaitingWindow > Error:" should exist
    # Source step 0726: Click First Close button on Error
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And if stoplight error, I click "stoplightWaitingWindow > First Close button on Error"
    # Source step 0727: Wait 3 Seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And if stoplight error, I wait "3000" milliseconds for "Wait 3 Seconds"
    # Source step 0728: Click Complete App
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And if stoplight error, I click "Complete Application"
    # Source step 0729: Wait 3 Seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then > LOOP: Do (Wait for Stoplight to Run) [max=90] > Loop > IF: If Error message on processing exists > Then
    And if stoplight error, I wait "3000" milliseconds for "Wait 3 Seconds"
    # Source step 0730: Close Stoplight Window
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then
    And if stoplight error, I click "stoplightWaitingWindow > Close"
    # Source step 0731: Wait on Stoplight window to go away
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then
    And if stoplight error, I wait until "stoplightWaitingWindow" does not exist
    # Source step 0732: Wait 3.5 seconds
    # Reusable flow: Common|Submission|Run Stoplight
    # Control flow: IF: If Stoplight error > Then
    And if stoplight error, I wait "3500" milliseconds for "Wait 3.5 seconds"
    # Source step 0733: Verify Stoplight Successfully Ran
    # Reusable flow: Common|Submission|Run Stoplight
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # ==============================================================================
    # Section: Policy Data Entry > Refer as UW in CLAS
    # ==============================================================================
    # Source step 0738: check for REFER
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    # Control flow: IF: If REFER does not exist > check for Refer
    And if rEFER does not exist, "Refer/Request Issuance" should not exist
    # Source step 0739: Check to see Coverage is bound Exists
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    # Control flow: IF: If REFER does not exist > Then set BOUND to NO to cause a referral > IF: If Coverage is bound exists, make sure it is answered > Condition
    And if rEFER does not exist, "Is this coverage bound?*" should exist
    # Source step 0740: Check Is Coverage bound (select)
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    # Control flow: IF: If REFER does not exist > Then set BOUND to NO to cause a referral > IF: If Coverage is bound exists, make sure it is answered > Then > IF: If Coverage is (select) > Condition
    And if rEFER does not exist, "Is this coverage bound?*" property "Value" should equal (select)
    # Source step 0741: Answer Is Coverage bound
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    # Control flow: IF: If REFER does not exist > Then set BOUND to NO to cause a referral > IF: If Coverage is bound exists, make sure it is answered > Then > IF: If Coverage is (select) > Then
    And if rEFER does not exist, I use value "No", then press TAB, then press TAB on "Is this coverage bound?*"
    # Source step 0743: ------->>> REFER
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    And if source condition "'Refer Needed' == NULL" is satisfied, I click "Refer/Request Issuance"
    And if source condition "'Refer Needed' != NULL" is satisfied, I click "Approve"
    And I wait until "IFRAME > Duck Creek Policy > IFRAME - OK" exists
    And I click "IFRAME > Duck Creek Policy > IFRAME - OK"
    # Source step 0744: Check for IFRAME
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Condition
    And while check for IFRAME, and Wait for Syncronization [max=150], "IFRAME" should exist
    # Source step 0745: Wait 1 Second for a max of 120 seconds
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop
    And while check for IFRAME, and Wait for Syncronization [max=150], I wait "1000" milliseconds for "Wait 1 Second for a max of 120 seconds"
    # Source step 0746: Alert: Error
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If Alert Error occurs for policy number/quote number > Check for Alert Error
    And while check for IFRAME, and Wait for Syncronization [max=150], "Alert Error Message Box: policy number exists for this quote numbe" should exist
    # Source step 0747: Set buffer for Error
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If Alert Error occurs for policy number/quote number > Then
    When runtime value "Alert Error" is set to "The scripts experienced an Alert error with the following information: assignPolicyNumberRq : A policy number exists for this quote number"
    # Source step 0748: Force a fail
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If Alert Error occurs for policy number/quote number > Then
    And while check for IFRAME, and Wait for Syncronization [max=150], I evaluate the configured expression using "{\"Expression\": \"{B[Alert Error]} == 'TRUE'\"}"
    # Source step 0749: IFrame
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If IFrame exists then check for error > Check For IFrame
    And while check for IFRAME, and Wait for Syncronization [max=150], "IFRAME" should exist
    # Source step 0750: Alert: Error
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If IFrame exists then check for error > Then > IF: If Alert Error occurs for policy number/quote number > Check for Alert Error
    And while check for IFRAME, and Wait for Syncronization [max=150], "IFRAME > Duck Creek Policy > Alert Error Message" should exist
    # Source step 0751: Set buffer for Error
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If IFrame exists then check for error > Then > IF: If Alert Error occurs for policy number/quote number > Then
    When runtime value "Alert Error" is set to "The scripts experienced an Alert error with the following information: assignPolicyNumberRq : A policy number exists for this quote number"
    # Source step 0752: Force a fail
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy  > Common|General|Alert Error Check
    # Control flow: WHILE: Check for IFRAME, and Wait for Syncronization [max=150] > Loop > IF: If IFrame exists then check for error > Then > IF: If Alert Error occurs for policy number/quote number > Then
    And while check for IFRAME, and Wait for Syncronization [max=150], I evaluate the configured expression using "{\"Expression\": \"{B[Alert Error]} == 'TRUE'\"}"
    # Source step 0753: Wait for Syncronization
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    Then I wait "250" milliseconds for "Wait for Syncronization"
    # Source step 0754: Wait on TransACT screen to appear
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    Then I wait until "Transaction Type" exists
    # Source step 0755: Open the referred policy
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    Given the technical value "Table > <Row> > <Cell> > Link" is X
    # Source step 0756: Wait for Billing Link to Appear
    # Reusable flow: DC|EQ|Common|Submission|Refer Application/Policy
    Then I wait until "Billing" exists
    # Source step 0757: Check for Save for Later Button
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Save for Later Button to avoid Locking the Policy > Condition
    And if check for Save for Later Button to avoid Locking the Policy, "Save for Later" should exist
    # Source step 0758: Save for Later
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Save for Later Button to avoid Locking the Policy > Then
    And if check for Save for Later Button to avoid Locking the Policy, I click "Save for Later"
    And if check for Save for Later Button to avoid Locking the Policy, I wait until "Save for Later - OK" exists
    And if check for Save for Later Button to avoid Locking the Policy, I click "Save for Later - OK"
    # Source step 0759: Check for Return to Admin Button
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Return to Admin Button to avoid Locking the Policy > Condition
    And if check for Return to Admin Button to avoid Locking the Policy, "Return To Admin" should exist
    # Source step 0760: Return To Admin
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Return to Admin Button to avoid Locking the Policy > Then
    And if check for Return to Admin Button to avoid Locking the Policy, I click "Return To Admin"
    And if check for Return to Admin Button to avoid Locking the Policy, I wait until "Return To Admin" does not exist
    # Source step 0761: Navigate to Policy Details Screen
    # Reusable flow: DC|EQ|Common|TransACT|Retreive Policy Number After Referral
    When I click "View Policy Details"
    # Source step 0762: Navigate to Policy Details Screen
    # Reusable flow: DC|EQ|Common|TransACT|Retreive Policy Number After Referral
    # Control flow: LOOP: Loop to Check if Policy Details Exists [max=120] > Condition
    And during loop to Check if Policy Details Exists [max=120], "Policy Details" should not exist
    # Source step 0763: Wait 1/2 Second for a max of 60 seconds
    # Reusable flow: DC|EQ|Common|TransACT|Retreive Policy Number After Referral
    # Control flow: LOOP: Loop to Check if Policy Details Exists [max=120] > Loop
    And during loop to Check if Policy Details Exists [max=120], I wait "500" milliseconds for "Wait 1/2 Second for a max of 60 seconds"
    # Source step 0764: ------->>> POLICY # BUFFER
    # Reusable flow: DC|EQ|Common|TransACT|Retreive Policy Number After Referral
    When I capture "Policy Number" as runtime value "Policy#"

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote
    # ==============================================================================
    # Source step 0786: Open a Browser
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0787: Close Explorer Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0788: Close Chrome Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0789: Close Firefox Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0790: Close Edge Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0791: Close Edge Beta Browsers
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0792: Open Edge Preferences file
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0793: Change Exit Type
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0794: Save changes
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0795: Delete EdgePreferences Resource
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Log back in to EQ and search for Quote
    # ==============================================================================
    # Source step 0796: Delete Cookies File
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|DC|Common|Reset Edge Preferences
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0797: Open broswer and navigate to EQ
    # Reusable flow: EQ|Common|Open EQ in Browser
    When I open "https://expertquote-qa.americannational.com/expertquote/" in the active browser tab
    # Source step 0798: Wait on Edge Browser to open
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "BODY" exists
    # Source step 0799: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "Loading ..." does not exist
    # Source step 0800: Policy Load Sync
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0801: Restart Microsoft Edge Message Exists?
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Check if Edge Popup is showing
    And if the Restart Microsoft Edge popup is displayed, "OK" should exist
    # Source step 0802: Restart Microsoft Edge Message - Click OK
    # Reusable flow: EQ|Common|Open EQ in Browser > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Then
    And if the Restart Microsoft Edge popup is displayed, I click "OK"
    # Source step 0805: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Open EQ in Browser
    Then I wait until "Loading ..." does not exist
    # Source step 0806: EQ|Common|Check if Logout Exists
    # Reusable flow: EQ|Common|Open EQ in Browser
    # Control flow: IF: If Still Logged in to EQ > Check for Logout button
    And if an existing ExpertQuote session is still logged in, "logout" should exist
    # Source step 0807: EQ|Common|Click Logout of EQ
    # Reusable flow: EQ|Common|Open EQ in Browser
    # Control flow: IF: If Still Logged in to EQ > Then
    And if an existing ExpertQuote session is still logged in, I click "logout"
    And if an existing ExpertQuote session is still logged in, I click "logout Log Out"
    # Source step 0808: Login
    # Reusable flow: EQ|Common|Login to EQ (SSO)
    Then I wait until the username field exists
    When I log in with username "YDH040" and password "${ENV:CL_EQ_PASSWORD}"
    # Source step 0809: Retrieve Dex Agent Name
    # Reusable flow: EQ|Common|Login to EQ (SSO)
    When I set runtime value "GetHostname" from runtime environment value "COMPUTERNAME"
    And I set runtime value "AgentName" from runtime value "GetHostname"
    # Source step 0818: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0819: Search by QuoteNum
    # Reusable flow: CL|EQ|Common|Search by QuoteNum
    When I use RUNTIME-DERIVED value from "{SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}" in "quoteSearchInput"
    And I click "Search"
    # Source step 0820: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Search by QuoteNum > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0825: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Submission"
    # Source step 0826: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0827: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0828: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0829: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Submission"
    # Source step 0830: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0831: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0832: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists

    # ==============================================================================
    # Section: Policy Data Entry > Transmit
    # ==============================================================================
    # Source step 0833: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0834: EQ|Common|Submission|Transmit to DC
    # Reusable flow: EQ|Common|Submission|Transmit to DC
    When I click "Transmit"
    # Source step 0835: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0836: EQ|Common|Transmit Confirmation - Buffer Policy Number & Verify Premium
    # Reusable flow: EQ|Common|Transmit Confirmation and New Packet Verification in EQ
    Then "TABLE > <Row> > <Cell> (ExplicitName=$1)" should match Transmitted
    And "TABLE > <Row> > <Cell> (ExplicitName=$2)" should match BusinessOwners
    And "TABLE > <Row> > <Cell> (ExplicitName=$4)" should match runtime value "Policy#"
    And "TABLE > <Row> > <Cell> (ExplicitName=$5)" should match runtime value "Premium"
    And "TABLE > <Row> > <Cell> (ExplicitName=$5)" should match $2,084.00

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0837: Verify New Premium on Duck Creek
    # Reusable flow: EQ|Common|Transact|Verify Premium on DC
    Then "DC Transaction Table > <Row> > <Cell> (ExplicitName=New Premium)" should match $2,084.00
    And "DC Transaction Table > <Row> > <Cell> (ExplicitName=Status)" should match Committed

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists
    # ==============================================================================
    # Source step 0838: OpenUrl
    # Reusable flow: Common|General|Log In to DuckCreek
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0839: Check the Loop Login
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Condition
    And during loop for the Login [max=30], I evaluate the configured expression using "{\"Expression\": \"{B[Loop Login]} = 0\"}"
    # Source step 0840: Set Loop Buffer
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    When runtime value "Loop Login" is set to "0"
    And runtime value "URL" is set to "http://svqw-clas22:8080/express/default.aspx"
    And runtime value "UserName" is set to "FFQA009"
    And runtime value "Password" is set to "${ENV:CL_EQ_PASSWORD}"
    # Source step 0841: Close Explorer Browsers
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0842: Close Chrome Browsers
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0843: Close Firefox Browsers
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0844: Close Edge Browsers
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0845: Close Edge Beta Browsers
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0846: Open Edge Preferences file
    # Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0847: Change Exit Type
    # Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0848: Save changes
    # Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0849: Delete EdgePreferences Resource
    # Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists
    # ==============================================================================
    # Source step 0850: Delete Cookies File
    # Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0851: OpenUrl
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I open "http://svqw-clas22:8080/express/default.aspx"
    # Source step 0852: Wait on Edge Browser to open
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I wait until "BODY" exists
    # Source step 0853: Policy Load Sync
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0854: Restart Microsoft Edge Message Exists?
    # Reusable flow: Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Edge Popup is showing > Check if Edge Popup is showing
    And during loop for the Login [max=30], "OK" should exist
    # Source step 0855: Restart Microsoft Edge Message - Click OK
    # Reusable flow: Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Edge Popup is showing > Then
    And during loop for the Login [max=30], I click "OK"
    # Source step 0856: Maximize Window
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    And during loop for the Login [max=30], I perform the window operation using "{\"Caption\": \"Duck Creek*\", \"Operation\": \"Maximize\"}"

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists > Check to see if Logged In
    # ==============================================================================
    # Source step 0857: Check for Log In
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Condition
    And during loop for the Login [max=30], "Logged In User" should exist

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists
    # ==============================================================================
    # Source step 0858: Logout
    # Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Then
    And during loop for the Login [max=30], the source configuration "Logged In User" is click
    And during loop for the Login [max=30], I click "Logged In User > Logout"
    # Source step 0859: Sync for Log out
    # Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Then
    And during loop for the Login [max=30], I wait "1000" milliseconds for "Sync for Log out"

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists > Http Error Msg
    # ==============================================================================
    # Source step 0860: Check for Http Error Msg
    # Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Then > IF: If Error Msg Exists > Check if Error Msg Exists
    And during loop for the Login [max=30], "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist
    # Source step 0861: Click OK on Http Error Msg
    # Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Then > IF: If Error Msg Exists > Then
    And during loop for the Login [max=30], I click "OK"
    # Source step 0862: Check Http Error Msg does not exist
    # Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Then > IF: If Error Msg Exists > Then
    And during loop for the Login [max=30], I wait until "OK" is not visible
    # Source step 0863: Logout
    # Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Still Logged In > Then > IF: If Error Msg Exists > Then
    And during loop for the Login [max=30], the source configuration "Logged In User" is click
    And during loop for the Login [max=30], I click "Logged In User > Logout"

    # ==============================================================================
    # Section: Policy Data Entry > Verify NB Policy Packet Exists
    # ==============================================================================
    # Source step 0865: Login
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop
    When I log in with username "FFQA009" and password "${ENV:TOSCA_PROTECTED_PASSWORD}"
    # Source step 0866: Wait for Login Screen to Go Away
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Login Screen goes away > Condition
    And during loop for the Login [max=30], I wait until "Login" does not exist
    # Source step 0867: Set Loop Buffer to Exit Loop
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Login Screen goes away > Then
    When runtime value "Loop Login" is set to "1"
    # Source step 0868: Take Screenshot of Login
    # Reusable flow: Common|General|Log In to DuckCreek
    # Control flow: LOOP: Loop for the Login [max=30] > Loop > IF: If Login Screen goes away > Else Take Screenshot and Loop
    And during loop for the Login [max=30], I capture a screenshot using "{\"Directory\": \"Screenshots\", \"Filename\": \"Login Error\"}"
    # Source step 0869: Set DocPath Buffer
    # Reusable flow: Common|General|Log In to DuckCreek
    # Source condition: DocPath != NULL
    When I leave runtime value "DocPath" blank because the source did not supply it
    # Source step 0870: Retrieve Dex Agent Name
    # Reusable flow: Common|General|Log In to DuckCreek
    When I set runtime value "GetHostname" from runtime environment value "COMPUTERNAME"
    And I set runtime value "AgentName" from runtime value "GetHostname"
    # Source step 0871: Small static wait for syncronization
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    Then I wait "1000" milliseconds for "Small static wait for syncronization"
    # Source step 0872: Dashboard|QuickSearch
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    When I use RUNTIME-DERIVED value from "{B[Policy#]}{TAB}{TAB}" in "Search Text"
    And I click "QuickSearch Button"
    # Source step 0873: Check for Loading Indicator
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0874: Wait 2 secs
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0875: 500ms Wait for Syncronization
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    Then I wait "500" milliseconds for "500ms Wait for Syncronization"
    # Source step 0876: Wait for results
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    Then I wait until "1 results found. Currently showing 1 - 1." is visible
    # Source step 0877: Click View Policy, and wait for navigation away from screen
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    Then I wait until "View Policy" is visible
    And I click "View Policy"
    # Source step 0878: Check for Loading Indicator
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0879: Wait 2 secs
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0880: 500ms Wait for Syncronization
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    Then I wait "500" milliseconds for "500ms Wait for Syncronization"
    # Source step 0881: View Policy Exists
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    # Control flow: WHILE: While View Policy Exists [max=90] > Condition
    And while view Policy Exists [max=90], "View Policy" should be visible
    # Source step 0882: 5s Wait for Syncronization
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    # Control flow: WHILE: While View Policy Exists [max=90] > Loop
    And while view Policy Exists [max=90], I wait "5000" milliseconds for "5s Wait for Syncronization"
    # Source step 0883: View Policy Exists
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    # Control flow: WHILE: While View Policy Exists [max=90] > Loop > IF: If View Policy still exists > Condition
    And while view Policy Exists [max=90], "View Policy" should be visible
    # Source step 0884: Click View Policy
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    # Control flow: WHILE: While View Policy Exists [max=90] > Loop > IF: If View Policy still exists > Then
    And while view Policy Exists [max=90], I click "View Policy"
    # Source step 0885: 500ms Wait for Syncronization
    # Reusable flow: Common|Dashboard|Perform Quick Search and Open Policy
    # Control flow: WHILE: While View Policy Exists [max=90] > Loop > IF: If View Policy still exists > Then
    And while view Policy Exists [max=90], I wait "500" milliseconds for "500ms Wait for Syncronization"
    # Source step 0886: TransACT
    # Reusable flow: Common|TransACT|Check for Policy Packet
    Then I wait until "TransACT" is visible
    # Source step 0887: Navigate to Policy Details Screen
    # Reusable flow: Common|TransACT|Check for Policy Packet
    When I click "View Policy Details"
    # Source step 0888: Navigate to Policy Details Screen
    # Reusable flow: Common|TransACT|Check for Policy Packet
    # Control flow: LOOP: Loop to Check if Policy Details Exists [max=120] > Condition
    And during loop to Check if Policy Details Exists [max=120], "Policy Details" should not exist
    # Source step 0889: Wait 1/2 Second for a max of 60 seconds
    # Reusable flow: Common|TransACT|Check for Policy Packet
    # Control flow: LOOP: Loop to Check if Policy Details Exists [max=120] > Loop
    And during loop to Check if Policy Details Exists [max=120], I wait "500" milliseconds for "Wait 1/2 Second for a max of 60 seconds"
    # Source step 0890: Navigate to Policy Details Details
    # Reusable flow: Common|TransACT|Check for Policy Packet
    Then I wait until "Attachments List Grid > <Row> > <Cell> (ExplicitName=$1)" is visible
    # Source step 0891: Check for Policy Packet
    # Reusable flow: Common|TransACT|Check for Policy Packet
    Given I target the row or control where "Attachments List Grid > <Row> > <Cell> (ExplicitName=$1)" matches NewPolicy*
    And I capture "Attachments List Grid > <Row> > <Cell> (ExplicitName=$3)" as runtime value "NBPolicyFormPacket"
    And "Attachments List Grid > <Row> > <Cell> (ExplicitName=$1)" should match NewPolicy*
    # Source step 0892: Navigate Back to Policy Details Screen
    # Reusable flow: Common|TransACT|Check for Policy Packet
    When I click "View Policy  (*)"
    And I wait until "Transaction Type" is visible

    # ==============================================================================
    # Section: Post Condition
    # ==============================================================================
    # Source step 0900: Close Explorer Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0901: Close Chrome Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0902: Close Edge Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0903: Close Firefox Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0904: Close Edge Beta Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Step 0018: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0019: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0058: General Eligibility Restrictions - Synching | Module: EQ|Common|PreQualification|General Eligibility Restrictions | Values: <no steering value> | Reason: 02.04.26 16:50:18 [ff01729@dnanico1.aniconet.com]
# Step 0059: Verify None of the Above Status | Module: EQ|Common|PreQualification|General Eligibility Restrictions | Values: Unchecked - None Of The Above=True | Reason: 02.04.26 16:50:18 [ff01729@dnanico1.aniconet.com]
# Step 0060: Check None Of the Above | Module: EQ|Common|PreQualification|General Eligibility Restrictions | Values: Unchecked - None Of The Above={TAB}{CLICK}; Response required to continue=True | Reason: 02.04.26 16:50:18 [ff01729@dnanico1.aniconet.com]
# Step 0061: Verify Level 9 Rules are not fired. | Module: EQ|Common|PreQualification|General Eligibility Restrictions | Values: Unchecked- Indicted for or convicted of any degree of the crime of fraud, bribery, arson or any other arson-related crime in connection with this or any other business or property in the last five years (ten in RI)?=True; Rule 9 (2004)-Indictment or Conviction Rule=False; Unchecked - Convicted of any other type of crime=True; Rule 9 (2005)- Felony Rule=False | Reason: 06.05.24 12:26:19 [ff01729]
# Step 0140: EQ|BOP|Claims/Prior Insurance|Delete Claim | Module: EQ|BOP|Claims/Prior Insurance|Delete Claim | Values: Delete Trash Can=x; Confirm=True; DELETE=x | Reason: 15.03.24 11:34:17 [ff01729]
# Step 0154: Territory Test | Module: Territory Test | Values: Territory=001 | Reason: 28.07.26 12:19:56 [ff02492@dnanico1.aniconet.com]
# Step 0156: EQ|BOP|Edit Location|Select Miles from Fire Dept & Feet from Hydrant | Module: EQ|BOP|Locations|Add/Edit Location | Values: Edit Location Heading=True; Feet from Fire Hydrant={CLICK}; Order Wildfire Risk Score=x; 1 - 100=x; Save=x; Miles From Fire Department={SENDKEYS["^{a}"]}{SENDKEYS[1]}{TAB}; Save=False | Reason: 28.07.26 12:20:17 [ff02492@dnanico1.aniconet.com]
# Step 0157: EQ|BOP|Locations/Buildings|Edit Location Selection | Module: EQ|BOP|Locations|Edit Location | Values: Edit Location Button - Latest Angular=x | Reason: 01.06.26 09:48:43 [ff01729@dnanico1.aniconet.com]
# Step 0158: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 01.06.26 09:48:49 [ff01729@dnanico1.aniconet.com]
# Step 0159: EQ|BOP|Edit Location | Module: EQ|BOP|Locations|Add/Edit Location | Values: Edit Location Heading=True; New Territory Dropdown=<BLANK>; Save=x | Reason: 01.06.26 08:59:39 [ff01729@dnanico1.aniconet.com]
# Step 0161: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Add Building | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0162: Check if on Correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0163: Navigate to Correct Screen | Module: EQ|Common|Navigation | Values: Nav Link=X | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0164: EQ|Common|Review Required Pop-up | Module: EQ|Common|Review Required Pop-up | Values: Keep Going=x | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0165: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Add Building | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0166: Buffer Screen Name if different | Module: TBox Set Buffer | Values: Buffer name: Screen=<BLANK — reusable-block parameter is not supplied> | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0167: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0168: Wait on for correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 01.12.25 15:32:42 [FF01729@dnanico1.aniconet.com]
# Step 0179: EQ|BOP Building|Select Building contains Windstorm | Module: EQ|BOP|Building|Add Building|Building, Functional, Habitational | Values: Windstorm Loss Mitigation unchecked=x{ENTER} | Reason: 21.11.25 15:48:32 [FF01729@dnanico1.aniconet.com]
# Step 0180: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 21.11.25 15:48:44 [FF01729@dnanico1.aniconet.com]
# Step 0181: EQ|BOP Building|Select Windstorm Certificate Type | Module: EQ|BOP|Building|Add Building|Building, Functional, Habitational | Values: Certificate Type - Bronze/Roof=x{ENTER}; Certificate Type - Gold/FSL=x{ENTER}; Roof Shape=Gable{ENTER}{TAB}; Roof Deck Attachment=Level A{ENTER}{TAB}; Roof-to-Wall Connection=Toe Nails{ENTER}{TAB}; Door Strength=Other{ENTER}{TAB}; Roof Covering=South Carolina Building Code Equivalent{ENTER}{TAB}; Opening Protection=Type 1{ENTER}{TAB}; Secondary Water Resistance=No{ENTER}{TAB} | Reason: 21.11.25 15:48:50 [FF01729@dnanico1.aniconet.com]
# Step 0182: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 21.11.25 15:48:58 [FF01729@dnanico1.aniconet.com]
# Step 0205: EQ|BOP|Building|Select Roof Type | Module: EQ|BOP|Building|Cost Estimator | Values: <no steering value> | Reason: 05.08.24 06:38:58 [ff01620@dnanico1.aniconet.com]
# Step 0208: Scroll down Page | Module: TBox Scroll Window Operation | Values: Caption=ExpertQuote*; Vertical=250px; MousePolicy=Center; DirectionPolicy=VerticalFirst | Reason: 01.08.24 11:56:30 [ff01620@dnanico1.aniconet.com]
# Step 0215: Scroll down Page | Module: TBox Scroll Window Operation | Values: Caption=ExpertQuote*; Vertical=10; MousePolicy=Center; DirectionPolicy=VerticalFirst | Reason: 01.08.24 11:57:09 [ff01620@dnanico1.aniconet.com]
# Step 0223: EQ|BOP|Building|Select Construction Type | Module: EQ|BOP|Building|Building Details|Building Rating Basis | Values: <no steering value> | Reason: 05.08.24 07:04:00 [ff01620@dnanico1.aniconet.com]
# Step 0236: Scroll down Page | Module: TBox Scroll Window Operation | Values: Caption=ExpertQuote*; Vertical=5; MousePolicy=Center; DirectionPolicy=VerticalFirst | Reason: 15.04.26 11:29:32 [ff01729@dnanico1.aniconet.com]
# Step 0239: EQ|BOP|Building|Select Service Panel Main Breaker | Module: EQ|BOP|Building|Building Details|Building Rating Basis | Values: Main Breaker={TAB}; Main Breaker={Click}{TAB} | Reason: 06.08.24 12:55:42 [ff01620@dnanico1.aniconet.com]
# Step 0240: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.24 12:55:42 [ff01620@dnanico1.aniconet.com]
# Step 0241: EQ|BOP|Building|Building Details|Select Wiring Type | Module: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | Values: Wiring Type - Other={Click}{TAB} | Reason: 06.08.24 12:55:42 [ff01620@dnanico1.aniconet.com]
# Step 0242: EQ|BOP|Building|Building Details|Select Electrical Panel Type | Module: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | Values: Electrical Panel Type - Other={Click}{TAB} | Reason: 06.08.24 12:55:42 [ff01620@dnanico1.aniconet.com]
# Step 0243: Scroll down Page | Module: TBox Scroll Window Operation | Values: Caption=ExpertQuote*; Vertical=5; MousePolicy=Center; DirectionPolicy=VerticalFirst | Reason: 15.04.26 12:27:52 [ff01729@dnanico1.aniconet.com]
# Step 0244: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 15.04.26 12:28:03 [ff01729@dnanico1.aniconet.com]
# Step 0246: EQ|BOP|Building|Building Details|Select Amperage of Main Circuit Breaker | Module: EQ|BOP|Building|Building Details|Roof Year & Burglar Alarm | Values: Amperage of the Main Circuit Breaker - 100 Amps or greater=x | Reason: 06.08.24 12:57:05 [ff01620@dnanico1.aniconet.com]
# Step 0247: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.24 12:57:13 [ff01620@dnanico1.aniconet.com]
# Step 0342: EQ|Common|Submission|Policy Forms|Click Policy Forms and Verify Navigation | Module: EQ|Common|Submission|Policy Forms|Main | Values: Policy Forms=X; Policy Forms Header=True; Forms Search=True | Reason: 07.08.26 10:24:24 [pa4126@dnanico1.aniconet.com]
# Step 0343: Set Form Number | Module: TBox Set Buffer | Values: Buffer name: Form Number=X48451217 | Reason: 07.08.26 10:24:24 [pa4126@dnanico1.aniconet.com]
# Step 0344: Forms List - BOP - Check if Form exists Smart | Module: EQ|Common|Form Check|UI - Forms List - BOP Smart | Values: <no steering value> | Reason: 07.08.26 10:24:24 [pa4126@dnanico1.aniconet.com]
# Step 0345: Forms List - BOP Smart - Verify Form | Module: EQ|Common|Form Check|UI - Forms List - BOP Smart | Values: FORM #={XB[Form Number]}; Form Number={B[Form Number]} | Reason: 07.08.26 10:24:24 [pa4126@dnanico1.aniconet.com]
# Step 0346: Report Form is not listed | Module: TBox Evaluation Tool | Values: Expression='{B[Form Number]}'+ ' is not listed for this policy' == '' | Reason: 07.08.26 10:24:24 [pa4126@dnanico1.aniconet.com]
# Step 0347: Forms List - BOP - Check if Form exists Smart | Module: EQ|Common|Form Check|UI - Forms List - BOP Smart | Values: FORM #=True; Form Number=True | Reason: 09.04.26 12:50:26 [ff01729@dnanico1.aniconet.com]
# Step 0348: Forms List - BOP Smart - Verify Form | Module: EQ|Common|Form Check|UI - Forms List - BOP Smart | Values: FORM #={B[Form Number]}; Form Number={B[Form Number]} | Reason: 09.04.26 12:50:26 [ff01729@dnanico1.aniconet.com]
# Step 0349: Report Form is not listed | Module: TBox Evaluation Tool | Values: Expression='{B[Form Number]}'+ ' is not listed for this policy' == '' | Reason: 09.04.26 12:50:26 [ff01729@dnanico1.aniconet.com]
# Step 0350: Forms List - Click Close | Module: EQ|Common|Form Check|UI - Forms List - BOP Smart | Values: Close=X | Reason: 07.08.26 10:24:24 [pa4126@dnanico1.aniconet.com]
# Step 0368: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0369: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0405: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0424: Delete LastResponseResource | Module: TBox Delete Resource | Values: Resource=LastResponseResource | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0425: Get Session ID & Buffer | Module: Verify JavaScript Result | Values: Title=*Duck*; JavaScript=return  DCT.sessionID;; Result={XB[SessionId]} | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0426: Buffer Server Address | Module: TBox Set Buffer | Values: Buffer name: ServerAddress=http://svqw-clas21:8080/duckcreek/dctserver.aspx | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0427: Check to see if Content Length is less than 40 | Module: TBox Evaluation Tool | Values: Expression={B[Content]} <40 | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0428: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0429: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK; Content-Length=Content | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0430: Sync API | Module: TBox Wait | Values: Duration=250 | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0431: Save the Response as XML file | Module: Save XML file | Values: Resource=LastResponseResource; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\BOPSmart_BASIC_AL_{B[QuoteID]}.xml | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0432: Sync API | Module: TBox Wait | Values: Duration=500 | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0433: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0434: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK; Content-Length=Content | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0435: Sync API | Module: TBox Wait | Values: Duration=250 | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0436: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0437: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0438: Save the Response as XML file | Module: Save XML file | Values: Resource=LastResponseResource; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\BOPSmart_BASIC_AL_{B[QuoteID]}.xml | Reason: 23.10.25 09:47:18 [ff01620@dnanico1.aniconet.com]
# Step 0439: Run Forms Request Get Forms on Policy | Module: Communicate with Web service | Values: server > requests > Session.resumeRq > sessionID={B[SessionId]}; server > requests > FormsEngine.initPrintJobRq > manuscript=Carrier_CommercialLines_Forms_US_4_0_0_0; server > requests > FormsEngine.initPrintJobRq > printJob=_TransactionPrint; server > requests > FormsEngine.initPrintJobRq > forceInit=1; Address={B[ServerAddress]}; Send > Method=POST; Receive > Status code name=200 OK; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\BOPSmart_BASIC_AL_{B[QuoteID]}.xml; server > responses > Session.resumeRs > status=success; server > responses > FormsEngine.initPrintJobRs > status=success | Reason: 20.11.23 07:56:55 [ff01620]
# Step 0440: Sync API | Module: TBox Wait | Values: Duration=1250 | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0441: Buffer Powershell Arguments | Module: TBox Set Buffer | Values: Buffer name: PowershellArguments=powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA.ps1  -Path "\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\"  -FileName "BOPSmart_BASIC" -State  "AL" -QuoteID "{B[QuoteID]}" | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0442: Execute Powershell Script | Module: TBox Start Program | Values: Path=C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe; Directory=\\mis\SYS\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check; Arguments > Argument={B[PowershellArguments]}; WaitForExit=True; WaitForExit > StandardOutputFile=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\FormsCheckResults.txt | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0443: Display the Results Summary | Module: TBox Clipboard | Values: Value=SummaryResults | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0444: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer | Values: Buffer name: SummaryResults=*Forms Listed:0 *; Buffer name: SummaryResults=*FAIL:0 *; Buffer name: SummaryResults=*INFO:0 *; Buffer name: SummaryResults=*Other: 0* | Reason: javascript calls for session & quote ID failing. using workaround step
# Step 0486: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0487: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0521: Open a Browser | Module: OpenUrl | Values: Url=https://connect.anico.com/Pages/default.aspx | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0522: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0523: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0524: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0525: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0526: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0527: Open Edge Preferences file | Module: Open/Create JSON file | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0528: Change Exit Type | Module: Edge Preferences File | Values: Resource=EdgePreferences; RootObject > profile > exit_type=none | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0529: Save changes | Module: Save JSON Resource | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0530: Delete EdgePreferences Resource | Module: TBox Delete Resource | Values: Resource=EdgePreferences | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0531: Delete Cookies File | Module: TBox Delete File | Values: Directory=%USERPROFILE%\AppData\Local\Microsoft\Edge\User Data\Default; File=Cookies | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0532: Open broswer and navigate to EQ | Module: OpenUrl | Values: Url=https://expertquote-qa.americannational.com/expertquote/; UseActiveTab=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0533: Wait on Edge Browser to open | Module: Edge Browser | Values: BODY=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0534: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0535: Policy Load Sync | Module: TBox Wait | Values: Duration=3000 | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0536: Restart Microsoft Edge Message Exists? | Module: Restart Microsoft Edge Message | Values: OK=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0537: Restart Microsoft Edge Message - Click OK | Module: Restart Microsoft Edge Message | Values: OK=X | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0538: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0539: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0540: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0541: EQ|Common|Check if Logout Exists | Module: EQ|Common|Logout of EQ | Values: logout=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0542: EQ|Common|Click Logout of EQ | Module: EQ|Common|Logout of EQ | Values: logout=X; logout Log Out=X | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0543: Login | Module: Login | Values: Username=True; Password=${ENV:CL_EQ_PASSWORD}{TAB}; Sign On=X; Username=YDH040{TAB} | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0544: Retrieve Dex Agent Name | Module: TBox Set Buffer | Values: Buffer name: GetHostname="""${COMPUTERNAME}"""; Buffer name: AgentName={B[GetHostname]} | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0545: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0546: Search by QuoteNum | Module: EQ|Common|Search by QuoteNum | Values: quoteSearchInput={SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}; Search=X | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0547: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0548: CL|EQ|Common|Search Policy Results Table | Module: EQ|Common|Search Policy Results Table | Values: Results TABLE=True | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0549: CL|EQ|Common|Search Policy Results Table | Module: EQ|Common|Search Policy Results Table | Values: Results TABLE > <Row> > <Cell> (ExplicitName=Name)={STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}; Results TABLE > edit=X | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0550: Waiton Name and QuoteNum | Module: EQ|Common|Narrative | Values: Name and Quote Num="New Quote" | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0551: Verify QuoteNum | Module: EQ|Common|Narrative | Values: Name and Quote Num={REGEX[{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}]} | Reason: 17.12.25 15:17:06 [ff01620@dnanico1.aniconet.com]
# Step 0586: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0604: Navigate to Submission Screen | Module: Common Navigation Links | Values: Submission=True; Submission=X | Reason: 17.12.25 15:19:49 [ff01620@dnanico1.aniconet.com]
# Step 0605: Sends the application Back to Agent | Module: Submission|Refer, Approve, Complete Issuance, Back to Agent | Values: Back to Agent=True; Back to Agent=X; IFRAME > Duck Creek Policy > IFRAME - OK=True; IFRAME > Duck Creek Policy > IFRAME - OK=X | Reason: 17.12.25 15:19:49 [ff01620@dnanico1.aniconet.com]
# Step 0606: Wait for the IFRAME to close | Module: Submission|Refer, Approve, Complete Issuance, Back to Agent | Values: IFRAME=False | Reason: 17.12.25 15:19:49 [ff01620@dnanico1.aniconet.com]
# Step 0607: Wait for Syncronization | Module: TBox Wait | Values: Duration=250 | Reason: 17.12.25 15:19:49 [ff01620@dnanico1.aniconet.com]
# Step 0608: Wait on TransACT screen to appear | Module: TransACT | Values: Transaction Type=True | Reason: 17.12.25 15:19:49 [ff01620@dnanico1.aniconet.com]
# Step 0623: OpenUrl | Module: OpenUrl | Values: Url=https://connect.anico.com/Pages/default.aspx; UseActiveTab=<BLANK> | Reason: 24.01.23 06:08:57 [Admin]
# Step 0624: Check the Loop Login | Module: TBox Evaluation Tool | Values: Expression={B[Loop Login]} = 0 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0625: Set Loop Buffer | Module: TBox Set Buffer | Values: Buffer name: Loop Login=0; Buffer name: URL=http://svqw-clas21:8080/express/; Buffer name: UserName=FFQA008; Buffer name: Password=<BLANK — reusable-block parameter is not supplied> | Reason: 24.01.23 06:08:57 [Admin]
# Step 0626: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0627: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0628: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0629: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0630: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0631: Open Edge Preferences file | Module: Open/Create JSON file | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 24.01.23 06:08:57 [Admin]
# Step 0632: Change Exit Type | Module: Edge Preferences File | Values: Resource=EdgePreferences; RootObject > profile > exit_type=none | Reason: 24.01.23 06:08:57 [Admin]
# Step 0633: Save changes | Module: Save JSON Resource | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 24.01.23 06:08:57 [Admin]
# Step 0634: Delete EdgePreferences Resource | Module: TBox Delete Resource | Values: Resource=EdgePreferences | Reason: 24.01.23 06:08:57 [Admin]
# Step 0635: Delete Cookies File | Module: TBox Delete File | Values: Directory=%USERPROFILE%\AppData\Local\Microsoft\Edge\User Data\Default; File=Cookies | Reason: 24.01.23 06:08:57 [Admin]
# Step 0636: OpenUrl | Module: OpenUrl | Values: Url=http://svqw-clas21:8080/express/; UseActiveTab=<BLANK>; WebDriverBrowserArguments=<BLANK>; WebDriverBrowserArguments > Argument=--silent-debugger-extension-api | Reason: 24.01.23 06:08:57 [Admin]
# Step 0637: Wait on Edge Browser to open | Module: Edge Browser | Values: BODY=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0638: Policy Load Sync | Module: TBox Wait | Values: Duration=3000 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0639: Restart Microsoft Edge Message Exists? | Module: Restart Microsoft Edge Message | Values: OK=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0640: Restart Microsoft Edge Message - Click OK | Module: Restart Microsoft Edge Message | Values: OK=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0641: Maximize Window | Module: TBox Window Operation | Values: Caption=Duck Creek*; Operation=Maximize | Reason: 24.01.23 06:08:57 [Admin]
# Step 0642: Check for Log In | Module: Logout | Values: Logged In User=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0643: Logout | Module: Logout | Values: Logged In User={Click}; Logged In User > Logout=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0644: Sync for Log out | Module: TBox Wait | Values: Duration=1000 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0645: Check for Http Error Msg | Module: Http Error Msg | Values: The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0646: Click OK on Http Error Msg | Module: Http Error Msg | Values: OK=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0647: Check Http Error Msg does not exist | Module: Http Error Msg | Values: OK=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0648: Logout | Module: Logout | Values: Logged In User={Click}; Logged In User > Logout=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0649: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0650: Login | Module: Login | Values: UserName=FFQA008{TAB}; Password=${ENV:TOSCA_PROTECTED_PASSWORD}; Login=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0651: Wait for Login Screen to Go Away | Module: Login | Values: Login=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0652: Set Loop Buffer to Exit Loop | Module: TBox Set Buffer | Values: Buffer name: Loop Login=1 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0653: Take Screenshot of Login | Module: TBox Take Screenshot | Values: Directory=Screenshots; Filename=Login Error | Reason: 24.01.23 06:08:57 [Admin]
# Step 0654: Set DocPath Buffer | Module: TBox Set Buffer | Values: Buffer name: DocPath=<BLANK — reusable-block parameter is not supplied> | Reason: 24.01.23 06:08:57 [Admin]
# Step 0655: Retrieve Dex Agent Name | Module: TBox Set Buffer | Values: Buffer name: GetHostname="""${COMPUTERNAME}"""; Buffer name: AgentName={B[GetHostname]} | Reason: 24.01.23 06:08:57 [Admin]
# Step 0656: Enter Desc in QuickSearch | Module: Dashboard|QuickSearch | Values: Search Text={B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}; QuickSearch Button=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0657: Enter Info to Search by Desc | Module: Dashboard|Search for Policies / Quotes | Values: Search Method (e.g. Description/Policy#)=Description{TAB}; Search Button={Click}; View Policy=True; View Policy={TAB}; View Policy=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0658: Check for Transact Header | Module: TransACT | Values: TransACT=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0659: Check if Pending Transaction | Module: TransACT|Transaction List Table | Values: Table > <Row> > <Cell> (ExplicitName=Status)=Pending | Reason: 24.01.23 06:08:57 [Admin]
# Step 0660: Click on Edit Policy on Pending Transaction | Module: TransACT|Transaction List Table | Values: Table > <Row> > <Cell> (ExplicitName=Status)=Pending; Table > <Row> > <Cell> > Link={CLICK} | Reason: 24.01.23 06:08:57 [Admin]
# Step 0661: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields | Values: Submission Heading=False | Reason: 24.01.23 06:08:57 [Admin]
# Step 0662: Navigate to Submission Screen | Module: Common Navigation Links | Values: Submission={TAB}; Submission=X | Reason: 24.01.23 06:08:57 [Admin]
# Step 0663: Wait for Synchronization | Module: TBox Wait | Values: Duration=1250 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0664: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields | Values: Submission Heading=True | Reason: 24.01.23 06:08:57 [Admin]
# Step 0665: 500ms wait for syncing | Module: TBox Wait | Values: Duration=500 | Reason: 24.01.23 06:08:57 [Admin]
# Step 0683: OpenUrl | Module: OpenUrl | Values: Url=https://connect.anico.com/Pages/default.aspx; UseActiveTab=<BLANK> | Reason: 24.01.23 06:13:06 [Admin]
# Step 0684: Check the Loop Login | Module: TBox Evaluation Tool | Values: Expression={B[Loop Login]} = 0 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0685: Set Loop Buffer | Module: TBox Set Buffer | Values: Buffer name: Loop Login=0; Buffer name: URL=http://svqw-clas21:8080/express/; Buffer name: UserName=FFQA008; Buffer name: Password=<BLANK — reusable-block parameter is not supplied> | Reason: 24.01.23 06:13:06 [Admin]
# Step 0686: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0687: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0688: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0689: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0690: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0691: Open Edge Preferences file | Module: Open/Create JSON file | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 24.01.23 06:13:06 [Admin]
# Step 0692: Change Exit Type | Module: Edge Preferences File | Values: Resource=EdgePreferences; RootObject > profile > exit_type=none | Reason: 24.01.23 06:13:06 [Admin]
# Step 0693: Save changes | Module: Save JSON Resource | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 24.01.23 06:13:06 [Admin]
# Step 0694: Delete EdgePreferences Resource | Module: TBox Delete Resource | Values: Resource=EdgePreferences | Reason: 24.01.23 06:13:06 [Admin]
# Step 0695: Delete Cookies File | Module: TBox Delete File | Values: Directory=%USERPROFILE%\AppData\Local\Microsoft\Edge\User Data\Default; File=Cookies | Reason: 24.01.23 06:13:06 [Admin]
# Step 0696: OpenUrl | Module: OpenUrl | Values: Url=http://svqw-clas21:8080/express/; UseActiveTab=<BLANK>; WebDriverBrowserArguments=<BLANK>; WebDriverBrowserArguments > Argument=--silent-debugger-extension-api | Reason: 24.01.23 06:13:06 [Admin]
# Step 0697: Wait on Edge Browser to open | Module: Edge Browser | Values: BODY=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0698: Policy Load Sync | Module: TBox Wait | Values: Duration=3000 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0699: Restart Microsoft Edge Message Exists? | Module: Restart Microsoft Edge Message | Values: OK=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0700: Restart Microsoft Edge Message - Click OK | Module: Restart Microsoft Edge Message | Values: OK=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0701: Maximize Window | Module: TBox Window Operation | Values: Caption=Duck Creek*; Operation=Maximize | Reason: 24.01.23 06:13:06 [Admin]
# Step 0702: Check for Log In | Module: Logout | Values: Logged In User=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0703: Logout | Module: Logout | Values: Logged In User={Click}; Logged In User > Logout=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0704: Sync for Log out | Module: TBox Wait | Values: Duration=1000 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0705: Check for Http Error Msg | Module: Http Error Msg | Values: The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0706: Click OK on Http Error Msg | Module: Http Error Msg | Values: OK=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0707: Check Http Error Msg does not exist | Module: Http Error Msg | Values: OK=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0708: Logout | Module: Logout | Values: Logged In User={Click}; Logged In User > Logout=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0709: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0710: Login | Module: Login | Values: UserName=FFQA008{TAB}; Password=${ENV:TOSCA_PROTECTED_PASSWORD}; Login=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0711: Wait for Login Screen to Go Away | Module: Login | Values: Login=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0712: Set Loop Buffer to Exit Loop | Module: TBox Set Buffer | Values: Buffer name: Loop Login=1 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0713: Take Screenshot of Login | Module: TBox Take Screenshot | Values: Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\Screenshots; Filename=Login Error | Reason: 24.01.23 06:13:06 [Admin]
# Step 0714: Set DocPath Buffer | Module: TBox Set Buffer | Values: Buffer name: DocPath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\ | Reason: 24.01.23 06:13:06 [Admin]
# Step 0715: Retrieve Dex Agent Name | Module: TBox Set Buffer | Values: Buffer name: GetHostname="""${COMPUTERNAME}"""; Buffer name: AgentName={B[GetHostname]} | Reason: 24.01.23 06:13:06 [Admin]
# Step 0716: Enter Desc in QuickSearch | Module: Dashboard|QuickSearch | Values: Search Text={B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}; QuickSearch Button=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0717: Enter Info to Search by Desc | Module: Dashboard|Search for Policies / Quotes | Values: Search Method (e.g. Description/Policy#)=Description{TAB}; Search Button={Click}; View Policy=True; View Policy={TAB}; View Policy=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0718: Check for Transact Header | Module: TransACT | Values: TransACT=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0719: Check if Pending Transaction | Module: TransACT|Transaction List Table | Values: Table > <Row> > <Cell> (ExplicitName=Status)=Pending | Reason: 24.01.23 06:13:06 [Admin]
# Step 0720: Click on Edit Policy on Pending Transaction | Module: TransACT|Transaction List Table | Values: Table > <Row> > <Cell> (ExplicitName=Status)=Pending; Table > <Row> > <Cell> > Link={CLICK} | Reason: 24.01.23 06:13:06 [Admin]
# Step 0721: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields | Values: Submission Heading=False | Reason: 24.01.23 06:13:06 [Admin]
# Step 0722: Navigate to Submission Screen | Module: Common Navigation Links | Values: Submission={TAB}; Submission=X | Reason: 24.01.23 06:13:06 [Admin]
# Step 0723: Wait for Synchronization | Module: TBox Wait | Values: Duration=1250 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0724: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields | Values: Submission Heading=True | Reason: 24.01.23 06:13:06 [Admin]
# Step 0725: 500ms wait for syncing | Module: TBox Wait | Values: Duration=500 | Reason: 24.01.23 06:13:06 [Admin]
# Step 0734: Click Queue to open popup | Module: Queue in CLAS QLTY | Values: Queue=X | Reason: 08.03.23 14:59:48 [Admin]
# Step 0735: Wait on Clear All and Click it | Module: Queue in CLAS QLTY | Values: Clear All=True; Clear All=X | Reason: 08.03.23 14:59:48 [Admin]
# Step 0736: Wait 1/2 sec | Module: TBox Wait | Values: Duration=500 | Reason: 08.03.23 14:59:48 [Admin]
# Step 0737: Click Queue to close popup | Module: Queue in CLAS QLTY | Values: Queue=X; Clear All=False | Reason: 08.03.23 14:59:48 [Admin]
# Step 0742: Set Bound to No | Module: Submission|Required and Optional Fields | Values: Submission Heading=True; Is this coverage bound?*=No{TAB} | Reason: 05.01.26 10:23:54 [ff01620@dnanico1.aniconet.com]
# Step 0765: Delete LastResponseResource | Module: TBox Delete Resource | Values: Resource=LastResponseResource | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0766: Get Session ID & Buffer | Module: Verify JavaScript Result | Values: Title=*Duck*; JavaScript=return  DCT.sessionID;; Result={XB[SessionId]} | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0767: Buffer Server Address | Module: TBox Set Buffer | Values: Buffer name: ServerAddress=http://svqw-clas21:8080/duckcreek/dctserver.aspx | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0768: Check to see if Content Length is less than 40 | Module: TBox Evaluation Tool | Values: Expression={B[Content]} <40 | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0769: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0770: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK; Content-Length=Content | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0771: Sync API | Module: TBox Wait | Values: Duration=250 | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0772: Save the Response as XML file | Module: Save XML file | Values: Resource=LastResponseResource; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\BOPSmart_BASIC_AL_{B[QuoteID]}.xml | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0773: Sync API | Module: TBox Wait | Values: Duration=500 | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0774: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0775: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK; Content-Length=Content | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0776: Sync API | Module: TBox Wait | Values: Duration=250 | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0777: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0778: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0779: Save the Response as XML file | Module: Save XML file | Values: Resource=LastResponseResource; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\BOPSmart_BASIC_AL_{B[QuoteID]}.xml | Reason: 23.10.25 09:47:18 [ff01620@dnanico1.aniconet.com]
# Step 0780: Run Forms Request Get Forms on Policy | Module: Communicate with Web service | Values: server > requests > Session.resumeRq > sessionID={B[SessionId]}; server > requests > FormsEngine.initPrintJobRq > manuscript=Carrier_CommercialLines_Forms_US_4_0_0_0; server > requests > FormsEngine.initPrintJobRq > printJob=_TransactionPrint; server > requests > FormsEngine.initPrintJobRq > forceInit=1; Address={B[ServerAddress]}; Send > Method=POST; Receive > Status code name=200 OK; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\BOPSmart_BASIC_AL_{B[QuoteID]}.xml; server > responses > Session.resumeRs > status=success; server > responses > FormsEngine.initPrintJobRs > status=success | Reason: 20.11.23 07:56:55 [ff01620]
# Step 0781: Sync API | Module: TBox Wait | Values: Duration=1250 | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0782: Buffer Powershell Arguments | Module: TBox Set Buffer | Values: Buffer name: PowershellArguments=powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA.ps1  -Path "\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\"  -FileName "BOPSmart_BASIC" -State  "AL" -QuoteID "{B[QuoteID]}" | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0783: Execute Powershell Script | Module: TBox Start Program | Values: Path=C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe; Directory=\\mis\SYS\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check; Arguments > Argument={B[PowershellArguments]}; WaitForExit=True; WaitForExit > StandardOutputFile=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\BOPSmart\FormsCheckResults.txt | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0784: Display the Results Summary | Module: TBox Clipboard | Values: Value=SummaryResults | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0785: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer | Values: Buffer name: SummaryResults=*Forms Listed:0 *; Buffer name: SummaryResults=*FAIL:0 *; Buffer name: SummaryResults=*INFO:0 *; Buffer name: SummaryResults=*Other: 0* | Reason: 05.08.26 13:28:57 [ff02492@dnanico1.aniconet.com]
# Step 0803: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0804: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0810: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Primary Insured Details | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0811: Check if on Correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0812: Navigate to Correct Screen | Module: EQ|Common|Navigation | Values: Nav Link=X | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0813: EQ|Common|Review Required Pop-up | Module: EQ|Common|Review Required Pop-up | Values: Keep Going=x | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0814: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Primary Insured Details | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0815: Buffer Screen Name if different | Module: TBox Set Buffer | Values: Buffer name: Screen=<BLANK — reusable-block parameter is not supplied> | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0816: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0817: Wait on for correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 08.05.26 11:45:41 [ff02492@dnanico1.aniconet.com]
# Step 0821: CL|EQ|Common|Search Policy Results Table | Module: EQ|Common|Search Policy Results Table | Values: Results TABLE=True | Reason: 08.05.26 13:11:04 [ff02492@dnanico1.aniconet.com]
# Step 0822: CL|EQ|Common|Search Policy Results Table | Module: EQ|Common|Search Policy Results Table | Values: Results TABLE > <Row> > <Cell> (ExplicitName=Name)={STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}; Results TABLE > edit=X | Reason: 08.05.26 13:11:04 [ff02492@dnanico1.aniconet.com]
# Step 0823: Waiton Name and QuoteNum | Module: EQ|Common|Narrative | Values: Name and Quote Num="New Quote" | Reason: 08.05.26 13:11:04 [ff02492@dnanico1.aniconet.com]
# Step 0824: Verify QuoteNum | Module: EQ|Common|Narrative | Values: Name and Quote Num={REGEX[{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}]} | Reason: 08.05.26 13:11:04 [ff02492@dnanico1.aniconet.com]
# Step 0864: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0893: Logout | Module: Logout | Values: Logged In User={Click}; Logged In User > Logout=X | Reason: 13.02.25 12:08:45 [ff01620@dnanico1.aniconet.com]
# Step 0894: Sync for Log out | Module: TBox Wait | Values: Duration=1000 | Reason: 13.02.25 12:08:45 [ff01620@dnanico1.aniconet.com]
# Step 0895: Check for Http Error Msg | Module: Http Error Msg | Values: The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0=True | Reason: 13.02.25 12:08:45 [ff01620@dnanico1.aniconet.com]
# Step 0896: Click OK on Http Error Msg | Module: Http Error Msg | Values: OK=X | Reason: 13.02.25 12:08:45 [ff01620@dnanico1.aniconet.com]
# Step 0897: Check Http Error Msg does not exist | Module: Http Error Msg | Values: OK=True | Reason: 13.02.25 12:08:45 [ff01620@dnanico1.aniconet.com]
# Step 0898: Logout | Module: Logout | Values: Logged In User={Click}; Logged In User > Logout=X | Reason: 13.02.25 12:08:45 [ff01620@dnanico1.aniconet.com]
# Step 0899: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0905: Set Buffer for WaitOnTime | Module: TBox Set Buffer | Values: Buffer name: WaitOnTime=15000 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0906: Open a Browser | Module: OpenUrl | Values: Url=https://connect.anico.com/Pages/default.aspx | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0907: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0908: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0909: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0910: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0911: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0912: Open Edge Preferences file | Module: Open/Create JSON file | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0913: Change Exit Type | Module: Edge Preferences File | Values: Resource=EdgePreferences; RootObject > profile > exit_type=none | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0914: Save changes | Module: Save JSON Resource | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0915: Delete EdgePreferences Resource | Module: TBox Delete Resource | Values: Resource=EdgePreferences | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0916: Delete Cookies File | Module: TBox Delete File | Values: Directory=%USERPROFILE%\AppData\Local\Microsoft\Edge\User Data\Default; File=Cookies | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0917: Open broswer and navigate to EQ | Module: OpenUrl | Values: Url=https://expertquote-qa.americannational.com/expertquote/; UseActiveTab=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0918: Wait on Edge Browser to open | Module: Edge Browser | Values: BODY=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0919: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0920: Policy Load Sync | Module: TBox Wait | Values: Duration=3000 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0921: Restart Microsoft Edge Message Exists? | Module: Restart Microsoft Edge Message | Values: OK=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0922: Restart Microsoft Edge Message - Click OK | Module: Restart Microsoft Edge Message | Values: OK=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0923: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0924: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0925: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0926: EQ|Common|Check if Logout Exists | Module: EQ|Common|Logout of EQ | Values: logout=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0927: EQ|Common|Click Logout of EQ | Module: EQ|Common|Logout of EQ | Values: logout=X; logout Log Out=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0928: Login | Module: Login | Values: Username=True; Password=${ENV:CL_EQ_PASSWORD}{TAB}; Sign On=X; Username=YDH040{TAB} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0929: Retrieve Dex Agent Name | Module: TBox Set Buffer | Values: Buffer name: GetHostname="""${COMPUTERNAME}"""; Buffer name: AgentName={B[GetHostname]} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0930: Start New Quote | Module: EQ|Common|Start New Quote | Values: New Quote=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0931: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0932: Start New Quote | Module: EQ|Common|Start New Quote | Values: New Quote=True; New Quote=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0933: Set Buffer for Last Name | Module: TBox Set Buffer | Values: Buffer name: LastName={RANDOMREGEX["Smoke[a-z]{4}"]}; Buffer name: FirstName={RANDOMREGEX["BOP [a-z]{3}"]} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0934: Client Info | Module: EQ|Common|Client Info | Values: Client Info=True; New/Existing Client Search=True; customer.name.first={SENDKEYS[{B[FirstName]}]}; customer.name.last={SENDKEYS[{B[LastName]}]}; customer.dateOfBirth={SENDKEYS[{DATE[][-22y][MM/dd/yyyy]}]}; Search=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0935: Create New Client | Module: EQ|Common|Create New Client | Values: Existing Client Match=True; No results found. Please choose Create New Client to continue entering a new client.=True; Create New Client_1=X; Next={Tab}X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0936: Set StateName Buffer | Module: TBox Set Buffer | Values: Buffer name: StateName=Alabama | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0937: Account Details - Account Info | Module: EQ|Common|Account Details - Account Info | Values: Account Information Header=True; Owner Middle Name={SENDKEYS[]}{TAB}; Owner Phone={SENDKEYS[{RANDOMREGEX["3[0-9]{9}"]}]}; Owner Email={SENDKEYS[{RANDOMREGEX["test@[a-z]{4}\.com"]}]} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0938: Account Details - Select Married | Module: EQ|Common|Account Details - Account Info | Values: Married=x | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0939: Navigate down the screen | Module: EQ|Common|Account Details - Account Info | Values: Street Address={Shifttab} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0940: Account Details - Account Info | Module: EQ|Common|Account Details - Account Info | Values: Street Address={SENDKEYS[1918 Avalon Ave]}{TAB}; Address 2={SENDKEYS[]}{TAB}; City={SENDKEYS[Muscle Shoals]}{TAB}; State Dropdown={CLICK}; State Name=X; Zip={SENDKEYS[35661]}{TAB}; County={SENDKEYS[Colbert]}{TAB}; Map=True; Satellite=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0941: Navigate down the screen | Module: EQ|Common|Account Details - Account Info | Values: Next={Shifttab} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0942: Account Details - Account Info | Module: EQ|Common|Account Details - Account Info | Values: Have you received mail at this address for at least 90 days? Yes=x; Is the account address also where the client resides? Yes=x; Next=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0943: Proposal Start | Module: EQ|Common|Proposal Start | Values: Proposal Details Header=True; Personal Auto=X; Motorcycle=X; Recreational Vehicle=X; Home=X; ROP=X; Business Owners=X; Special Farm Package=X; Select -SFP CE=X; Search Business Name={TAB}; Individually Owned / DBA CheckBox={SCROLL[2]}; Individually Owned, DBA, or T/A={CLICK}; Individual DBA=Tester Automation; Effective Date={SENDKEYS[11-28-2026]}{TAB}; newAccountAddress=True; Lessors Risk  - No=X; PolicyTerm={TAB}; PolicyTerm={Sendkeys[12 months]}; PolicyTerm={Tab}; State Dropdown={TAB}; State Name=X; AgentPC={SENDKEYS[D2102]}{TAB}{TAB}; Effective Date=EffDate; State Dropdown={CLICK}; Individually Owned / DBA CheckBox={CLICK[0px][-10px]}; Individually Owned / DBA CheckBox={CLICK}; Start Quote=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0944: Set Buffer for LOB | Module: TBox Set Buffer | Values: Buffer name: LOB=BOP | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0945: Set Buffer for WaitOnTime | Module: TBox Set Buffer | Values: Buffer name: WaitOnTime=5000 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0946: SSN | Module: EQ|Common|SSN | Values: The SSN could not be found. Please enter an SSN.=True; ssn={SENDKEYS[025{RND[6]}]}{TAB}; SUBMIT=True; SUBMIT={TAB}; SUBMIT=X; Submit - Angular=True; Submit - Angular={TAB}; Submit - Angular=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0947: Verify if Popup exists | Module: EQ|Common|SSN | Values: No Prefill Match Found=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0948: Click Continue | Module: EQ|Common|SSN | Values: Continue=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0949: Set Buffer for WaitOnTime | Module: TBox Set Buffer | Values: Buffer name: WaitOnTime=25000 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0950: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=PreQualification | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0951: Check if on Correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0952: Navigate to Correct Screen | Module: EQ|Common|Navigation | Values: Nav Link=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0953: EQ|Common|Review Required Pop-up | Module: EQ|Common|Review Required Pop-up | Values: Keep Going=x | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0954: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=PreQualification | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0955: Buffer Screen Name if different | Module: TBox Set Buffer | Values: Buffer name: Screen=<BLANK — reusable-block parameter is not supplied> | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0956: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0957: Wait on for correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0958: Quote Identifying | Module: EQ|Common|Quote Identifying | Values: Name and Quote=Quote_NameNum | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0959: Set Buffer for quote num & id | Module: TBox Set Buffer | Values: Buffer name: Quote_Num={STRINGREPLACE[{B[Quote_NameNum]}][{B[LastName]}][]}; Buffer name: QuoteID={B[Quote_Num]} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0960: Close Quote | Module: EQ|Common|Quote Identifying | Values: Close Quote={CLICK} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0961: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0962: Search by QuoteNum | Module: EQ|Common|Search by QuoteNum | Values: quoteSearchInput={SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}; Search=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0963: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0964: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=PreQualification | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0965: Check if on Correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0966: Navigate to Correct Screen | Module: EQ|Common|Navigation | Values: Nav Link=X | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0967: EQ|Common|Review Required Pop-up | Module: EQ|Common|Review Required Pop-up | Values: Keep Going=x | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0968: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=PreQualification | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0969: Buffer Screen Name if different | Module: TBox Set Buffer | Values: Buffer name: Screen=<BLANK — reusable-block parameter is not supplied> | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0970: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0971: Wait on for correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0972: Quote Identifying | Module: EQ|Common|Quote Identifying | Values: Name and Quote={B[Quote_NameNum]} | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0973: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0974: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0975: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0976: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Step 0977: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 28.07.26 15:32:37 [FF01729@dnanico1.aniconet.com]
# Disabled granular value: Step 0031 / Create New Client / No results found. Please choose Create New Client to continue entering a new client.: True
# Disabled granular value: Step 0036 / Account Details - Account Info / County: {SENDKEYS[Colbert]}{TAB}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {SCROLL[2]}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {CLICK[0px][-10px]}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {CLICK}
# Disabled granular value: Step 0041 / SSN / SUBMIT: True
# Disabled granular value: Step 0041 / SSN / SUBMIT: {TAB}
# Disabled granular value: Step 0041 / SSN / SUBMIT: X
# Disabled granular value: Step 0053 / Wait for Add Class Codes to Exist and Click Search/Add Class Code / Add Class Codes - Header: True
# Disabled granular value: Step 0055 / Wait for Find a Class Code window to exist and add the class code. / CheckBox: True
# Disabled granular value: Step 0055 / Wait for Find a Class Code window to exist and add the class code. / CheckBox: {TAB}True
# Disabled granular value: Step 0055 / Wait for Find a Class Code window to exist and add the class code. / CheckBox: {CLICK}
# Disabled granular value: Step 0071 / EQ|Primary Insured|Enter Required Info|Type|BOP / Individual/Sole Proprietor - old: {TAB}{TAB}
# Disabled granular value: Step 0071 / EQ|Primary Insured|Enter Required Info|Type|BOP / Individual/Sole Proprietor - old: X
# Disabled granular value: Step 0074 / EQ|Primary Insured|Enter Required Info|Other / Mobile Phone Number: {TAB}{SENDKEYS["5554447777"]}{TAB}
# Disabled granular value: Step 0074 / EQ|Primary Insured|Enter Required Info|Other / Primary Phone: {TAB}{SENDKEYS["4445557788"]}{TAB}
# Disabled granular value: Step 0075 / EQ|Primary Insured|Click Edit General Info / Edit General Info: X
# Disabled granular value: Step 0077 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Business Name: {TAB}{SENDKEYS["BOP BASIC Test"]}{ENTER}{TAB}
# Disabled granular value: Step 0081 / EQ|BOP|Primary Insured Details| General UW Questions / General UW Questions Heading: True
# Disabled granular value: Step 0083 / EQ|BOP|Primary Insured Details|Industry/Class Code Questions / Industry/Class Code Questions Heading: True
# Disabled granular value: Step 0123 / EQ|BOP|Claims/Prior Insurance|Add Claims - Date of Occurence / ClaimsAdd and Update Claims as Needed: True
# Disabled granular value: Step 0153 / EQ|BOP|Edit Location|Select Territory Dropdown / New Territory Dropdown: {SENDKEYS["^{a}"]}{SENDKEYS[{B[Territory]}]}{ENTER}{TAB}{TAB}
# Disabled granular value: Step 0449 / Get QuoteID by Console / Caption: <BLANK>
# Disabled granular value: Step 0510 / CL|EQ|eChecklist -Building Photo1 / All Link: X
# Disabled granular value: Step 0510 / CL|EQ|eChecklist -Building Photo1 / Accept: X
# Disabled granular value: Step 0510 / CL|EQ|eChecklist -Building Photo1 / OK - Accept: X
# Disabled granular value: Step 0510 / CL|EQ|eChecklist -Building Photo1 / OK - Accept: True
# Disabled granular value: Step 0511 / CL|EQ|eChecklist -Sync / Review Complete: True
# Disabled granular value: Step 0512 / CL|EQ|eChecklist -Building Photo2 / Policy Header: {CLICK}
# Disabled granular value: Step 0512 / CL|EQ|eChecklist -Building Photo2 / Building Photo 2: {CLICK}
# Disabled granular value: Step 0512 / CL|EQ|eChecklist -Building Photo2 / Accept: X
# Disabled granular value: Step 0512 / CL|EQ|eChecklist -Building Photo2 / OK - Accept: X
# Disabled granular value: Step 0512 / CL|EQ|eChecklist -Building Photo2 / OK - Accept: True
# Disabled granular value: Step 0513 / CL|EQ|eChecklist -Sync / Review Complete: True
# Disabled granular value: Step 0514 / CL|EQ|eChecklist -Building Photo3 / Policy Header: {CLICK}
# Disabled granular value: Step 0514 / CL|EQ|eChecklist -Building Photo3 / Building Photo 2: {CLICK}
# Disabled granular value: Step 0514 / CL|EQ|eChecklist -Building Photo3 / Accept: X
# Disabled granular value: Step 0514 / CL|EQ|eChecklist -Building Photo3 / OK - Accept: X
# Disabled granular value: Step 0514 / CL|EQ|eChecklist -Building Photo3 / OK - Accept: True
# Disabled granular value: Step 0515 / CL|EQ|eChecklist -Sync / Review Complete: True
# Disabled granular value: Step 0516 / CL|EQ|eChecklist -Building Photo4 / Policy Header: {CLICK}
# Disabled granular value: Step 0516 / CL|EQ|eChecklist -Building Photo4 / Building Photo 2: {CLICK}
# Disabled granular value: Step 0516 / CL|EQ|eChecklist -Building Photo4 / Accept: X
# Disabled granular value: Step 0516 / CL|EQ|eChecklist -Building Photo4 / OK - Accept: X
# Disabled granular value: Step 0516 / CL|EQ|eChecklist -Building Photo4 / OK - Accept: True
# Disabled granular value: Step 0517 / CL|EQ|eChecklist -Sync / Review Complete: True
# Disabled granular value: Step 0518 / CL|EQ|eChecklist -Loss Runs - 3 Yrs / Policy Header: {CLICK}
# Disabled granular value: Step 0518 / CL|EQ|eChecklist -Loss Runs - 3 Yrs / Loss Runs (Tiered - 5 Years; Not tiered - 3 years): X
# Disabled granular value: Step 0518 / CL|EQ|eChecklist -Loss Runs - 3 Yrs / Accept: True
# Disabled granular value: Step 0518 / CL|EQ|eChecklist -Loss Runs - 3 Yrs / Accept: X
# Disabled granular value: Step 0518 / CL|EQ|eChecklist -Loss Runs - 3 Yrs / OK - Accept: X
# Disabled granular value: Step 0519 / CL|EQ|eChecklist -Sync / Review Complete: True
# Disabled granular value: Step 0622 / Set Error Flag / Buffer name: ErrorFlag: No
# Disabled granular value: Step 0836 / EQ|Common|Transmit Confirmation - Buffer Policy Number & Verify Premium / TABLE > <Row> (ExplicitName=$1): <NULL / NO STEERING VALUE>
# Disabled granular value: Step 0836 / EQ|Common|Transmit Confirmation - Buffer Policy Number & Verify Premium / NEW BUSINESS PACKET: True

# --------------------------------------------------------------------------------------------------
# SOURCE-CONDITIONAL ACTIONS NOT EXECUTED FOR THIS REPRESENTATIVE ITERATION
# --------------------------------------------------------------------------------------------------
# Step 0039 / Proposal Start / Personal Auto: condition LOB == "PAP" is false; value X
# Step 0039 / Proposal Start / Motorcycle: condition LOB == "MOTO" is false; value X
# Step 0039 / Proposal Start / Recreational Vehicle: condition LOB == "RV" is false; value X
# Step 0039 / Proposal Start / Home: condition LOB == "HO" is false; value X
# Step 0039 / Proposal Start / ROP: condition LOB == "ROP" is false; value X
# Step 0039 / Proposal Start / Special Farm Package: condition LOB == "SFP" is false; value X
# Step 0039 / Proposal Start / Select -SFP CE: condition BusinessType == "CE" is false; value X
# Step 0039 / Proposal Start / PolicyTerm: condition LOB == "SFP" is false; value {TAB}
# Step 0039 / Proposal Start / PolicyTerm: condition LOB == "SFP" is false; value {Sendkeys[12 months]}
# Step 0039 / Proposal Start / PolicyTerm: condition LOB == "SFP" is false; value {Tab}
# Step 0049 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0057 Set Industry/Class Code Restrictions to None of the Above, and go to next screen: source condition LOB == "SFP" is false for this iteration
# Step 0068 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0072 EQ|Primary Insured|Enter Required Info|Type|SFP: source condition LOB == "SFP" is false for this iteration
# Step 0077 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Farm Bureau Member - No: condition State == "MA"||State=="ME"||State=="NH"||State=="NJ"||State=="RI" is false; value X
# Step 0077 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Do you wish to disclose Race and Gender Info? - No: condition State == "CA" is false; value X
# Step 0077 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Is the client a member of any Professional Trade Association?- No: condition State == "MA"||State=="ME"||State=="NH"||State=="NJ"||State=="RI" is false; value X
# Step 0079 EQ|BOP|Primary Insured Details|Answer None of the Above: source condition LOB != "BOP" is false for this iteration
# Step 0089 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0092 / Buffer name: BusinessOwnerIndex: condition 'Index for Business Owner' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0092 / Buffer name: NamedInsuredIndex: condition 'Index for Named Insured' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0092 / Buffer name: ThirdPartyIndex: condition 'Index for Third Party' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0092 / Buffer name: KeyIndividualIndex: condition 'Index for Key Individual' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0092 / Buffer name: AuditContactIndex: condition 'Index for Audit Contact' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0093 / EQ|BOP|Client Details|Click Client Role on Rolodex / BusinessOwner: condition 'Index for Business Owner' != NULL is false; value x
# Step 0093 / EQ|BOP|Client Details|Click Client Role on Rolodex / NamedInsured: condition 'Index for Named Insured' != NULL is false; value x
# Step 0093 / EQ|BOP|Client Details|Click Client Role on Rolodex / ThirdPartyDesignee: condition 'Index for Third Party' != NULL is false; value x
# Step 0093 / EQ|BOP|Client Details|Click Client Role on Rolodex / KeyIndividual: condition 'Index for Key Individual' != NULL is false; value x
# Step 0093 / EQ|BOP|Client Details|Click Client Role on Rolodex / Audit Contact: condition 'Index for Audit Contact' != NULL is false; value {TAB}{CLICK}
# Step 0099 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0102 / ------------------>EQ|Common|Verify that Edit is not displayed and Text is Locked / Edit: condition Edit == "x" is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0110 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0146 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0269 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0277 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0288 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0291 / EQ|Common|Billing / Mortgagee Button: condition LOB == "SFP" is false; value X
# Step 0313 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0321 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0329 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0339 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0505 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0508 / EQ|BOP|Submission / Checklist Button_SFP: condition LOB =="SFP" is false; value X
# Step 0557 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0830 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration

# --------------------------------------------------------------------------------------------------
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# --------------------------------------------------------------------------------------------------
# Recovery R001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\BOP; Filename=BOP BASIC TestCase
# Recovery R002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\BOP; Filename=BOP BASIC TestStep
# Recovery R003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\BOP; Filename=BOP BASIC TSV
# Recovery R004: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R005: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R006: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R007: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R008: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R009: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\SFP; Filename=SFP BASIC TestCase
# Recovery R010: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\SFP; Filename=SFP BASIC TestStep
# Recovery R011: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Values: Environment=Desktop; Directory=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\SFP; Filename=SFP BASIC TSV
# Recovery R012: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R013: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R014: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R015: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5
# Recovery R016: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5

# --------------------------------------------------------------------------------------------------
# STATIC CONVERSION COVERAGE
# --------------------------------------------------------------------------------------------------
# Normal source steps represented: 977/977
# Active/conditional source steps represented: 661/661
# Source-disabled steps preserved as comments: 316/316
# Recovery steps preserved as comments: 16/16
# Active non-structural granular values processed: 1187/1187
# Structural/container granular values represented through owning steps: 93
# Functional correctness still requires execution evidence and/or BA/SME validation.
