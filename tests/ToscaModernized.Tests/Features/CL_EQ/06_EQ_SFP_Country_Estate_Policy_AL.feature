# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 06_EQ_SFP_Country_Estate_Policy_AL.feature
# Application: Commercial Lines ExpertQuote
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_EQ @SFP @country_estate @AL @Edge @manual @automated
Feature: Execute the complete Alabama Special Farm Package Country Estate policy flow in ExpertQuote
  As an ExpertQuote user
  I want to execute the exported EQ | SFP | Country Estate Policy flow using one Alabama iteration
  So that the full Tosca sequence can be reviewed and performed as a traceable manual test


  Background: Establish the Commercial Lines ExpertQuote application context
    Given the Commercial Lines ExpertQuote application context and source-defined prerequisites are initialized

  Scenario: Complete SFP | Country Estate Policy for the Alabama representative iteration

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0029: Set Buffer for Last Name
    # Reusable flow: EQ|Common|Enter Client Search Info
    When I generate and retain a RANDOM value matching "CE-[A-Z]{4}" as runtime value "LastName"
    And I generate and retain a RANDOM value matching "SFP[A-Z]{3}" as runtime value "FirstName"
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
    And I enter "111", then press TAB in "Address 2"
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
    And I select "Special Farm Package"
    And I click "Select -SFP CE"
    And I enter "08-30-2026", then press TAB in "Effective Date"
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
    When runtime value "Screen" is set to "Policy Details"
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
    When runtime value "Screen" is set to "Policy Details"
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
    # Source step 0052: TBox Set Buffer
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When runtime value "PrimaryFarmCategory" is set to "CROPS"
    And runtime value "PrimaryFarmType" is set to "Berry"
    And I leave runtime value "SecondaryFarmCategory" blank because the source did not supply it
    And I leave runtime value "SecondaryFarmType" blank because the source did not supply it
    # Source step 0053: Choose Primary Farm Category
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When I click "Primary Farm Category"
    # Source step 0054: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized) > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0055: Wait on Primary Farm Type to appear
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    Then I wait until "Primary Farm Type" exists
    # Source step 0056: Select Primary Farm Type
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When I click "Primary Farm Type"
    # Source step 0057: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized) > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist

    # ==============================================================================
    # Section: Policy Data Entry > Add a Secondary Farm Type
    # ==============================================================================
    # Source step 0058: Toggle Secondary Farm Section On
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When I click "Add Secondary Farm Type - Toggle"
    And I wait until "Secondary Farm Category" is visible
    # Source step 0059: Choose Secondary Farm Category
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When I click "Secondary Farm Category"
    # Source step 0060: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized) > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0061: Wait on Secondary Farm Type to appear
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    Then I wait until "Secondary Farm Type" exists
    # Source step 0062: Select Secondary Farm Type
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When I click "Secondary Farm Type"
    # Source step 0063: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized) > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist

    # ==============================================================================
    # Section: Policy Data Entry
    # ==============================================================================
    # Source step 0064: Enter Gross Farm Income
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    When I enter "500" in "Gross Farm Income"
    # Source step 0065: Answer Industrial Hemp Question - No
    # Reusable flow: CL|EQ|SFP|Policy Details (Optimized)
    And if source condition "'Industrial Hemp Answer' == \"No\"" is satisfied, I select "Industrial Hemp - No"
    And if source condition "'Industrial Hemp Answer' == \"Yes\"" is satisfied, I select "Industrial Hemp - Yes"
    # Source step 0066: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Pre Qualification"
    # Source step 0067: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0068: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0069: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0070: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Pre Qualification"
    # Source step 0071: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0072: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0073: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0074: General Eligibility Restrictions - Synching
    # Reusable flow: EQ|Common|PreQualification|General Eligibility Restrictions|Verify None of the Above
    When I execute Tosca step “General Eligibility Restrictions - Synching” using module “EQ|Common|PreQualification|General Eligibility Restrictions”
    # Source step 0075: Verify None of the Above Status
    # Reusable flow: EQ|Common|PreQualification|General Eligibility Restrictions|Verify None of the Above
    # Control flow: IF: If None of the Above is unchecked > Condition Verify None of the Above Status
    And if none of the Above is unchecked, "Unchecked - None Of The Above" should exist
    # Source step 0076: Check None Of the Above
    # Reusable flow: EQ|Common|PreQualification|General Eligibility Restrictions|Verify None of the Above
    # Control flow: IF: If None of the Above is unchecked > Then Check None Of the Above
    And if none of the Above is unchecked, I press TAB, then click on "Unchecked - None Of The Above"
    And if none of the Above is unchecked, I wait until "Response required to continue" exists
    # Source step 0078: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Primary Insured Details"
    # Source step 0079: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0080: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0081: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0082: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Primary Insured Details"
    # Source step 0083: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0084: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0085: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0086: EQ|Primary Insured|Enter Required Info|Type|BOP
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: LOB == "BOP"
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0087: EQ|Primary Insured|Enter Required Info|Type|SFP
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: LOB == "SFP"
    When I click, then press TAB, then press TAB, then press TAB on "(Existing Client)"
    And I click "Next (SFP)"
    # Source step 0088: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    Then I wait until "Loading ..." does not exist
    # Source step 0089: EQ|Primary Insured|Enter Required Info|Other
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    When I press TAB on "Save"
    And I click "Save"
    # Source step 0090: EQ|Primary Insured|Click Edit General Info
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: ReadOnly == NULL
    And if source condition "ReadOnly == NULL" is satisfied, I perform “EQ|Primary Insured|Click Edit General Info” in module “EQ|Common|Primary Insured|Required” using the field actions and data below
    # Source step 0091: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    Then I wait until "Loading ..." does not exist
    # Source step 0092: EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: ReadOnly == NULL
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then leave the field blank and press TAB on "Description Of Operations"
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "3", then press TAB on "Number Of Fulltime Employees"
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "2", then press TAB on "Number Of PartTime Employees"
    And if source condition "ReadOnly == NULL" is satisfied, I press TAB, then enter "1", then press TAB on "Number Of Seasonal Employees"
    And if source condition "ReadOnly == NULL" is satisfied, I click "Save"
    And if source condition "ReadOnly == NULL" is satisfied, "Description Of Operations" should match runtime value "QuoteDescription"
    # Source step 0093: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    Then I wait until "Loading ..." does not exist
    # Source step 0094: EQ|BOP|Primary Insured Details|Answer None of the Above
    # Reusable flow: CL|EQ|Common|Primary Insured|Enter Required Info
    # Source condition: LOB != "BOP"
    When I press TAB, then click on "None of the Above CheckBox"
    # Source step 0095: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Client Details"
    # Source step 0096: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0097: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0098: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0099: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Client Details"
    # Source step 0100: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0101: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0102: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0103: Set Buffer for Indexes
    # Reusable flow: EQ|BOP|Client Details|Edit Client Roles
    When runtime value "InspectionContactIndex" is set to "1"
    # Source step 0104: EQ|BOP|Client Details|Click Client Role on Rolodex
    # Reusable flow: EQ|BOP|Client Details|Edit Client Roles
    When I press TAB, then click on "Inspection Contact"
    # Source step 0105: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Narrative"
    # Source step 0106: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0107: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0108: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0109: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Narrative"
    # Source step 0110: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0111: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0112: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0113: ------------------>EQ|Common|Verify that Edit is not displayed and Text is Locked
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
    # Source step 0114: Set Quote_Num
    # Reusable flow: EQ|Common|Narrative|Add/Edit a Narrative and Verify Timestamp
    When I derive a partial runtime-buffer value for "Set Quote_Num" using source values "{\"Buffer\": \"Quote_Num\", \"Value\": \"{B[NameQuoteNum]}\", \"Last\": \"8\"}"
    # Source step 0115: Set QuoteID buffer
    # Reusable flow: EQ|Common|Narrative|Add/Edit a Narrative and Verify Timestamp
    When I set runtime value "QuoteID" from runtime value "Quote_Num"
    And runtime value "Policy#" is set to "Test1111"
    # Source step 0116: Buffer Screen Name
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Claims Prior Insurance"
    # Source step 0117: Check if on Correct Screen
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0118: Navigate to Correct Screen
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0119: EQ|Common|Review Required Pop-up
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0120: Buffer Screen Name
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Claims Prior Insurance"
    # Source step 0121: Buffer Screen Name if different
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0122: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0123: Wait on for correct Screen
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required > EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0124: EQ|Prior Carrier-Claims|Enter Required Info
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    When I click on "Prior Policy - No"
    # Source step 0125: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0126: EQ|Prior Carrier-Claims|Click 3+
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    When I enter "5", then press TAB in "Years In Business"
    And I click on "3+ years"
    And I press TAB on "3+ years"
    # Source step 0127: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0128: EQ|Prior Carrier-Claims|Enter Latest Expiration
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    When I enter "1/1/2025", then press TAB in "Prior Insurance Latest Expiration Date"
    # Source step 0129: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    Then I wait until "Loading ..." does not exist
    # Source step 0130: EQ|Prior Carrier-Claims|Enter Latest Carrier
    # Reusable flow: CL|EQ|SFP|Prior Claims|Enter Required
    When I enter "GEICO", then press TAB in "Prior Insurance Latest Carrier"
    # Source step 0131: CL|EQ|SFP|Location|Add a Location|Loc Desc and Miles FD
    # Reusable flow: CL|EQ|SFP|Location|Add a Location
    When I click "Location Link"
    And I wait until "Location Description" exists
    And I enter "Primary Location", then press TAB, then press TAB in "Location Description"
    And I enter "3", then press TAB, then press TAB in "Miles from FD"
    # Source step 0132: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Location > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0133: CL|EQ|SFP|Location|Add a Location|Fire Hydrant and Wind Hail
    # Reusable flow: CL|EQ|SFP|Location|Add a Location
    When I enter or select "101-250" in "Feet from Hydrant"
    # Source step 0134: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Location > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0135: CL|EQ|SFP|Location|Add a Location|Fire Hydrant and Wind Hail
    # Reusable flow: CL|EQ|SFP|Location|Add a Location
    When I enter or select "\"\"" in "Total Farming Acreage"
    And I enter "6", then press TAB in "Total Farming Acreage"
    And I scroll "1" on "Total Farming Acreage"
    # Source step 0136: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Location > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0137: CL|EQ|SFP|Location|Add a Location|Fire Hydrant and Wind Hail
    # Reusable flow: CL|EQ|SFP|Location|Add a Location
    And if source condition "WindHail == \"1%\" && '1% Mandatory' != \"Yes\"" is satisfied, I click on "WindHail 1%"
    And if source condition "WindHail == \"2%\"" is satisfied, I click on "WindHail 2%"
    And if source condition "WindHail == \"5%\"" is satisfied, I click on "WindHail 5%"
    # Source step 0141: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Location > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0142: Check if Save Exists
    # Reusable flow: CL|EQ|SFP|Location|Add a Location
    # Control flow: WHILE: While Save still exists [max=30] > Condition
    And while save still exists [max=30], "Save" should exist
    # Source step 0143: CL|EQ|SFP|Location|Add a Location|Click Save
    # Reusable flow: CL|EQ|SFP|Location|Add a Location
    # Control flow: WHILE: While Save still exists [max=30] > Loop
    And while save still exists [max=30], I click "Save"
    # Source step 0144: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Location > CL|EQ|Common|WaitOn Loading Indicator
    # Control flow: WHILE: While Save still exists [max=30] > Loop
    And while save still exists [max=30], I wait until "Loading ..." does not exist
    # Source step 0145: EQ|SFP|Div I - Click Add Residence
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    When I click "+ Add Residence to Location"
    # Source step 0146: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0147: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait until "Add Residence - Header" exists
    And I press CTRL+A, then enter "Primary Residence", then press TAB, then press TAB on "Additional Description"
    And I press TAB on "Frame"
    And I click, then press TAB on "Single Family"
    And I press CTRL+A, then enter "2022", then press TAB on "Year Built"
    # Source step 0148: TBox Wait_1
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait "500" milliseconds for "TBox Wait_1"
    # Source step 0149: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    When I press TAB on "Plumbing Year"
    # Source step 0150: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0151: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait until "Add Residence - Header" exists
    And I click, then press TAB on "Rate Type 1"
    And I press CTRL+A, then enter "2022", then press TAB, then press TAB on "Roof Year"
    # Source step 0152: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0153: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait until "Add Residence - Header" exists
    And I enter or select "Asphalt" in "Roof Type_1"
    And I enter or select "UL 2" in "Roof Impact_1"
    # Source step 0154: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait until "Add Residence - Header" exists
    And I press TAB, then scroll "2" on "Roof Year"
    # Source step 0155: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0156: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait until "Add Residence - Header" exists
    And I press TAB, then scroll "-3" on "Residence Coverage"
    # Source step 0157: TBox Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait "1000" milliseconds for "TBox Wait"
    # Source step 0158: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    When I click on "Does the client have a solid fuel heating type? No"
    # Source step 0159: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0160: EQ|SFP|Div I - Add Residence|Add Residence - Detail
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence
    Then I wait until "Add Residence - Header" exists
    And I press TAB on "Residence Coverage"
    And I click on "Residence Coverage"
    # Source step 0161: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add a Residence > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0162: EQ|SFP|Div I - Add Residence|Add Residence Covg
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg
    Then "Residence Coverage" should match True
    And I enter "375000", then press TAB in "Insurance Amount"
    # Source step 0163: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0164: EQ|SFP|Div I - Add Residence|Add Residence Covg
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg
    When I enter "1800", then press TAB in "Square Feet"
    And I press SHIFT+TAB on "Actual Cash Value"
    # Source step 0165: EQ|SFP|Div I - Add Residence|Add Residence Covg
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg
    When I click, then press TAB on "Does the residence have a thermostatically controlled device? - Yes"
    And I enter or select "Expanded Replacement Cost" in "Actual Cash Value"
    # Source step 0166: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0167: EQ|SFP|Div I - Add Residence|Add Residence Covg
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg
    When I press SHIFT+TAB, then scroll "-1" on "Save"
    # Source step 0168: EQ|SFP|Div I - Add Residence|Add Residence Covg
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg
    When I click on "RCT"
    And I click on "Standard RCT - Use Defaults"
    And I click "Get Valuation"
    # Source step 0169: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0170: EQ|SFP|Div I - Add Residence|Add Residence Covg
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg
    When I click "Save"
    # Source step 0171: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Location|Add Residence Covg > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0172: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Policy-Wide and Division-Specific Coverages"
    # Source step 0173: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0174: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0175: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0176: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Policy-Wide and Division-Specific Coverages"
    # Source step 0177: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0178: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0179: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0180: EQ|SFP|PolicyWide Coverage|CE
    # Reusable flow: CL|EQ|SFP|CE|Policy-wide
    Then I wait until "CE Coverage" exists
    And I press TAB, then click on "Add Coverage"
    And I press TAB, then click on "CE Coverage"
    # Source step 0181: EQ|SFP|CE|Coverages
    # Reusable flow: CL|EQ|SFP|CE|Policy-wide
    And if source condition "CoverageType == \"Choice\"" is satisfied, I press SHIFT+TAB, then click on "Choice"
    And if source condition "CoverageType == \"Choice Horse\"" is satisfied, I press TAB, then click on "ChoiceWithHorse"
    And if source condition "CoverageType == \"Select\"" is satisfied, I press TAB, then click on "Select"
    And if source condition "CoverageType == \"Select Horse\"" is satisfied, I press TAB, then click on "SelectWithHorse"
    And if source condition "CoverageType == \"Premier\"" is satisfied, I press TAB, then click on "Premier"
    And if source condition "CoverageType == \"Premier Horse\"" is satisfied, I press TAB, then click on "PremierWithHorse"
    And I enter or select "$5,000" in "Water Damage"
    And I enter or select "$5,000" in "Unscheduled Structures"
    And I enter or select "\"\"" in "Blanket FPP"
    And I enter "31,000", then press TAB in "Blanket FPP"
    And I press TAB on "Blanket FPP"
    And I enter or select "$500,000/$1,000,000" in "Liability Limit"
    And I click "Save"
    # Source step 0182: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Insurance Score"
    # Source step 0183: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0184: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0185: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0186: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Insurance Score"
    # Source step 0187: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0188: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0189: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0190: EQ|SFP|Input Insurance Score Information
    # Reusable flow: CL|EQ|SFP|Insurance Score
    When I enter or select "Primary  Insured" in "Entity Type"
    And I press SHIFT+TAB, then scroll "-3" on "Insurance Score Consent"
    # Source step 0191: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Insurance Score > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0192: EQ|SFP|Input Insurance Score Information
    # Reusable flow: CL|EQ|SFP|Insurance Score
    When I click on "Primary Insured"
    # Source step 0193: TBox Wait
    # Reusable flow: CL|EQ|SFP|Insurance Score
    Then I wait "1000" milliseconds for "TBox Wait"
    # Source step 0194: EQ|SFP|Input Insurance Score Information
    # Reusable flow: CL|EQ|SFP|Insurance Score
    When I click "Insurance Score Consent"
    And I wait until "Accept" exists
    And I click "Accept"
    # Source step 0195: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Insurance Score > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0196: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Mortgagee/Loss Payee"
    # Source step 0197: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0198: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0199: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0200: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Mortgagee/Loss Payee"
    # Source step 0201: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0202: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0203: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0204: EQ|SFP|Add Mortgagee
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I click "+ ADD ADDITIONAL INTEREST"
    And I click on "Mortgagee/Secured Party"
    # Source step 0205: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0206: EQ|SFP|Search for Financial Institution
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I press TAB, then enter "Connect One Bank", then press TAB, then press TAB on "Search Name"
    And I press TAB on "Search ZipCode"
    And I click "Search"
    # Source step 0207: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0208: EQ|SFP|Select Financial Institution
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I set "Mortgage CheckBox" to "True"
    And I wait until "Location (Primary Location)" is visible
    # Source step 0209: EQ|SFP|Add location/residence info
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I use RUNTIME-DERIVED value from "{STRINGTOUPPER[1918 Avalon Ave]}*" in "Location (Primary Location)"
    And I enter or select "Residence #1" in "Residence"
    And I press TAB on "Location (Primary Location)"
    # Source step 0210: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0211: EQ|SFP|Navigate down screen
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I press TAB on "Account Number"
    # Source step 0212: EQ|SFP|Choose no Copy of Dec
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I click on "Copy of Dec - No"
    # Source step 0213: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0214: EQ|SFP|Add Account # and Description
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I press TAB, then enter "165156651", then press TAB on "Account Number"
    And I enter "Mortgagee Test Description", then press TAB in "Description Of Interest"
    And I enter "Mortgagee 2nd Description", then press TAB in "Description Of Interest"
    # Source step 0215: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0216: EQ|SFP|Mark Escrow Billed
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I click on "Escrow Billed - Yes"
    # Source step 0217: EQ Loading Indicator Wait
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information > CL|EQ|Common|WaitOn Loading Indicator
    Then I wait until "Loading ..." does not exist
    # Source step 0218: EQ|SFP|Click Save
    # Reusable flow: CL|EQ|SFP|Mortgagee/Loss Payee Information
    When I click "Save"
    # Source step 0219: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Pricing"
    # Source step 0220: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0221: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0222: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0223: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Pricing"
    # Source step 0224: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0225: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0226: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists
    # Source step 0227: EQ|SFP|Pricing
    # Reusable flow: CL|EQ|SFP|Pricing|Verify Premium
    When I capture "Total Premium" as runtime value "Total Premium"
    # Source step 0228: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    When runtime value "Screen" is set to "Submission"
    # Source step 0229: Check if on Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Condition
    And if the current screen is not the required screen, "Screen Heading" should not exist
    # Source step 0230: Navigate to Correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I click the navigation link for runtime value "Screen"
    # Source step 0231: EQ|Common|Review Required Pop-up
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    And if source condition "'Review Required - Keep Going' == \"Yes\"" is satisfied, I click "Keep Going"
    # Source step 0232: Buffer Screen Name
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: 'Review Required - Keep Going' == "Yes"
    When runtime value "Screen" is set to "Submission"
    # Source step 0233: Buffer Screen Name if different
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    # Source condition: Screen2 != NULL
    # No executable action for this representative iteration; see conditional appendix.
    # Source step 0234: EQ Loading Indicator Wait
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Loading ..." does not exist
    # Source step 0235: Wait on for correct Screen
    # Reusable flow: EQ|Common|Navigate to Screen
    # Control flow: IF: If Not on Correct screen > Then
    And if the current screen is not the required screen, I wait until "Screen Heading" exists

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek
    # ==============================================================================
    # Source step 0236: Open a Browser
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I open "https://connect.anico.com/Pages/default.aspx"
    # Source step 0237: Close Explorer Browsers
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0238: Close Chrome Browsers
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0239: Close Firefox Browsers
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0240: Close Edge Browsers
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0241: Close Edge Beta Browsers
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek > Reset Exit_Type (Restore last session popup)
    # ==============================================================================
    # Source step 0242: Open Edge Preferences file
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|DC|Common|Reset Edge Preferences
    When I open or create JSON resource "EdgePreferences" from "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0243: Change Exit Type
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|DC|Common|Reset Edge Preferences
    When I set Edge preference "profile.exit_type" to "none" in resource "EdgePreferences"
    # Source step 0244: Save changes
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|DC|Common|Reset Edge Preferences
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
    # Source step 0245: Delete EdgePreferences Resource
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|DC|Common|Reset Edge Preferences
    When I delete runtime resource "EdgePreferences"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek
    # ==============================================================================
    # Source step 0246: Delete Cookies File
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|DC|Common|Reset Edge Preferences
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
    # Source step 0247: OpenUrl
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I open "http://svqw-clas21:8080/express/" in the active browser tab
    # Source step 0248: Wait on Edge Browser to open
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    Then I wait until "BODY" exists
    # Source step 0249: Policy Load Sync
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0250: Restart Microsoft Edge Message Exists?
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Check if Edge Popup is showing
    And if the Restart Microsoft Edge popup is displayed, "OK" should exist
    # Source step 0251: Restart Microsoft Edge Message - Click OK
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > CL|EQ|Common|General|Restart Edge Popup
    # Control flow: IF: If Edge Popup is showing > Then
    And if the Restart Microsoft Edge popup is displayed, I click "OK"
    # Source step 0252: Verify Username exists
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    # Control flow: IF: If still Logged into CLAS > Verify if Username is available
    And if an existing CLAS session is still logged in, "UserName" should not exist
    # Source step 0253: Logout
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, the source configuration "Logged In User" is click
    And if an existing CLAS session is still logged in, I click "Logged In User > Logout"
    # Source step 0254: Sync for Log out
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, I wait "1000" milliseconds for "Sync for Log out"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek > Http Error Msg
    # ==============================================================================
    # Source step 0255: Check for Http Error Msg
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Check if Error Msg Exists
    And if an existing CLAS session is still logged in, "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist
    # Source step 0256: Click OK on Http Error Msg
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, I click "OK"
    # Source step 0257: Check Http Error Msg does not exist
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, I wait until "OK" is not visible
    # Source step 0258: Logout
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > Common|General|Logout
    # Control flow: IF: If still Logged into CLAS > Then > IF: If Error Msg Exists > Then
    And if an existing CLAS session is still logged in, the source configuration "Logged In User" is click
    And if an existing CLAS session is still logged in, I click "Logged In User > Logout"

    # ==============================================================================
    # Section: Policy Data Entry > Check Forms via DuckCreek
    # ==============================================================================
    # Source step 0260: OpenUrl
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    # Control flow: IF: If still Logged into CLAS > Then
    And if an existing CLAS session is still logged in, I open "http://svqw-clas21:8080/express/" in the active browser tab
    # Source step 0261: Login
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    Then I wait until the username field exists
    When I log in with username "FFQA008" and password "${ENV:TOSCA_PROTECTED_PASSWORD}"
    # Source step 0262: Wait for Login Screen to Go Away
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    Then I wait until "Login" does not exist
    # Source step 0263: Enter Quote in QuickSearch
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I enter or select "Client Name" in "Search Mode"
    And I use RUNTIME-DERIVED value from "{B[LastName]}, {B[FirstName]}{TAB}" in "Search Text"
    And I click on "QuickSearch Button"
    # Source step 0264: Verify View Policy Exists
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    Then I wait until "View Policy" exists
    # Source step 0265: Check for Loading Indicator
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0266: Wait 2 secs
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0267: Click View Policy
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1
    When I click "View Policy"
    # Source step 0268: Check for Loading Indicator
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Condition
    And while the loading indicator is visible, for no more than 60 attempts, "Loading Message" should be visible
    # Source step 0269: Wait 2 secs
    # Reusable flow: CL|EQ|SFP|Open a CLAS Browser and Search for EQ by Description_1 > DC|EQ|Common|General|Wait on Loading Indicator
    # Control flow: WHILE: While Loading Indicator is Visible [max=60] > Loop
    And while the loading indicator is visible, for no more than 60 attempts, I wait "2000" milliseconds for "Wait 2 secs"
    # Source step 0270: Policy Load Sync
    Then I wait "3000" milliseconds for "Policy Load Sync"
    # Source step 0271: Delete LastResponseResource
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When I delete runtime resource "LastResponseResource"
    # Source step 0272: Get Session ID & Buffer
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When I use *Duck* for "Title" in "Get Session ID & Buffer"
    And I use return  DCT.sessionID; for "JavaScript" in "Get Session ID & Buffer"
    And I use runtime value "SessionId" for "Result" in "Get Session ID & Buffer"
    # Source step 0273: Buffer Server Address
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When runtime value "ServerAddress" is set to "http://svqw-clas21:8080/duckcreek/dctserver.aspx"
    # Source step 0274: Check to see if Content Length is less than 40
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    # Control flow: LOOP: Run the API and repeat if Content Length is less than 40 [max=4] > Condition - Check Content Length
    And during run the API and repeat if Content Length is less than 40 [max=4], I evaluate the configured expression using "{\"Expression\": \"{B[Content]} <40\"}"
    # Source step 0275: Forms API Request
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    # Control flow: LOOP: Run the API and repeat if Content Length is less than 40 [max=4] > Loop - Run the API to check forms
    And during run the API and repeat if Content Length is less than 40 [max=4], I use runtime value "SessionId" for "sessionID" in "Forms API Request"
    # Source step 0276: Forms API Response
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    # Control flow: LOOP: Run the API and repeat if Content Length is less than 40 [max=4] > Loop - Run the API to check forms
    And during run the API and repeat if Content Length is less than 40 [max=4], I use 200 OK for "StatusCode" in "Forms API Response"
    And during run the API and repeat if Content Length is less than 40 [max=4], I use Content for "Content-Length" in "Forms API Response"
    # Source step 0277: Sync API
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    # Control flow: LOOP: Run the API and repeat if Content Length is less than 40 [max=4] > Loop - Run the API to check forms
    And during run the API and repeat if Content Length is less than 40 [max=4], I wait "250" milliseconds for "Sync API"
    # Source step 0278: Save the Response as XML file
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When I save the XML resource using "{\"Resource\": \"LastResponseResource\", \"Filepath\": \"\\\\\\\\mis\\\\sys\\\\QLTY\\\\Test_Automation\\\\Tricentis_Tosca\\\\Forms_Check\\\\SFP\\\\SFP_CE_AL_{B[QuoteID]}.xml\"}"
    # Source step 0279: Sync API
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    Then I wait "500" milliseconds for "Sync API"
    # Source step 0287: Sync API
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    Then I wait "1250" milliseconds for "Sync API"
    # Source step 0288: Buffer Powershell Arguments
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When I set runtime value "PowershellArguments" from RUNTIME-DERIVED value from "powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA.ps1  -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\\"  -FileName \"SFP_CE\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""
    # Source step 0289: Execute Powershell Script
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When I run system command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" with WaitForExit="True"
    # Source step 0290: Display the Results Summary
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When I perform the clipboard operation using "{\"Value\": \"SummaryResults\"}"
    # Source step 0291: Check and Report for Fails in the Forms Verification from the SummaryResults
    # Reusable flow: CL|EQ|Common|General|Forms Verification for EQ in CLAS
    When runtime value "SummaryResults" is set to "*Forms Listed:0 *"
    And runtime value "SummaryResults" is set to "*FAIL:0 *"
    And runtime value "SummaryResults" is set to "*INFO:0 *"
    And runtime value "SummaryResults" is set to "*Other: 0*"
    # Source step 0292: Check for Save for Later Button
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Save for Later Button to avoid Locking the Policy > Condition
    And if check for Save for Later Button to avoid Locking the Policy, "Save for Later" should exist
    # Source step 0293: Save for Later
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Save for Later Button to avoid Locking the Policy > Then
    And if check for Save for Later Button to avoid Locking the Policy, I click "Save for Later"
    And if check for Save for Later Button to avoid Locking the Policy, I wait until "Save for Later - OK" exists
    And if check for Save for Later Button to avoid Locking the Policy, I click "Save for Later - OK"
    # Source step 0294: Check for Return to Admin Button
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Return to Admin Button to avoid Locking the Policy > Condition
    And if check for Return to Admin Button to avoid Locking the Policy, "Return To Admin" should exist
    # Source step 0295: Return To Admin
    # Reusable flow: Common|General|Save for Later/Return to Admin
    # Control flow: IF: Check for Return to Admin Button to avoid Locking the Policy > Then
    And if check for Return to Admin Button to avoid Locking the Policy, I click "Return To Admin"
    And if check for Return to Admin Button to avoid Locking the Policy, I wait until "Return To Admin" does not exist

    # ==============================================================================
    # Section: PostCondition
    # ==============================================================================
    # Source step 0377: Close Explorer Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im iexplore.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0378: Close Chrome Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im Chrome.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0379: Close Edge Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im MicrosoftEdge.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0380: Close Firefox Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im Firefox.exe" with WaitForExit="True" and timeout "5" seconds
    # Source step 0381: Close Edge Beta Browsers
    # Reusable flow: Common|General|Post Condition
    When I run system command "taskkill /f /im msEdge.exe" with WaitForExit="True" and timeout "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Step 0018: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0019: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0077: Verify Level 9 Rules are not fired. | Module: EQ|Common|PreQualification|General Eligibility Restrictions | Values: Unchecked- Indicted for or convicted of any degree of the crime of fraud, bribery, arson or any other arson-related crime in connection with this or any other business or property in the last five years (ten in RI)?=True; Rule 9 (2004)-Indictment or Conviction Rule=False; Unchecked - Convicted of any other type of crime=True; Rule 9 (2005)- Felony Rule=False | Reason: 06.05.24 12:26:19 [ff01729]
# Step 0138: CL|EQ|SFP|Location|Add a Location|Fire Hydrant and Wind Hail | Module: EQ|SFP|Location | Values: Wind Hail 1% Selected=True | Reason: 25.04.25 11:34:31 [ff01620@dnanico1.aniconet.com]
# Step 0139: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 25.04.25 11:34:31 [ff01620@dnanico1.aniconet.com]
# Step 0140: CL|EQ|SFP|Location|Add a Location|Fire Hydrant and Wind Hail | Module: EQ|SFP|Location | Values: WindHail 1%=X; WindHail 2%=X; WindHail 5%=X | Reason: 25.04.25 11:34:31 [ff01620@dnanico1.aniconet.com]
# Step 0259: Waiton Username to exist | Module: Login | Values: UserName=True | Reason: 02.08.24 09:13:13 [Admin]
# Step 0280: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0281: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK; Content-Length=Content | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0282: Sync API | Module: TBox Wait | Values: Duration=250 | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0283: Forms API Request | Module: Forms API Request | Values: sessionID={B[SessionId]} | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0284: Forms API Response | Module: Forms API Response | Values: StatusCode=200 OK | Reason: 23.10.25 09:47:03 [ff01620@dnanico1.aniconet.com]
# Step 0285: Save the Response as XML file | Module: Save XML file | Values: Resource=LastResponseResource; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\SFP\SFP_CE_AL_{B[QuoteID]}.xml | Reason: 23.10.25 09:47:18 [ff01620@dnanico1.aniconet.com]
# Step 0286: Run Forms Request Get Forms on Policy | Module: Communicate with Web service | Values: server > requests > Session.resumeRq > sessionID={B[SessionId]}; server > requests > FormsEngine.initPrintJobRq > manuscript=Carrier_CommercialLines_Forms_US_4_0_0_0; server > requests > FormsEngine.initPrintJobRq > printJob=_TransactionPrint; server > requests > FormsEngine.initPrintJobRq > forceInit=1; Address={B[ServerAddress]}; Send > Method=POST; Receive > Status code name=200 OK; Filepath=\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Forms_Check\SFP\SFP_CE_AL_{B[QuoteID]}.xml; server > responses > Session.resumeRs > status=success; server > responses > FormsEngine.initPrintJobRs > status=success | Reason: 20.11.23 07:56:55 [ff01620]
# Step 0296: Open a Browser | Module: OpenUrl | Values: Url=https://connect.anico.com/Pages/default.aspx | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0297: Close Explorer Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=iexplore.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0298: Close Chrome Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Chrome.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0299: Close Firefox Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=Firefox.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0300: Close Edge Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=MicrosoftEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0301: Close Edge Beta Browsers | Module: TBox Start Program | Values: Path=taskkill; Arguments > Argument=/f; Arguments > Argument=/im; Arguments > Argument=msEdge.exe; WaitForExit=True; WaitForExit > TimeoutForExit=5 | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0302: Open Edge Preferences file | Module: Open/Create JSON file | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0303: Change Exit Type | Module: Edge Preferences File | Values: Resource=EdgePreferences; RootObject > profile > exit_type=none | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0304: Save changes | Module: Save JSON Resource | Values: Resource=EdgePreferences; Filepath=%userprofile%\AppData\Local\Microsoft\Edge\User Data\Default\Preferences | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0305: Delete EdgePreferences Resource | Module: TBox Delete Resource | Values: Resource=EdgePreferences | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0306: Delete Cookies File | Module: TBox Delete File | Values: Directory=%USERPROFILE%\AppData\Local\Microsoft\Edge\User Data\Default; File=Cookies | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0307: Open broswer and navigate to EQ | Module: OpenUrl | Values: Url=https://expertquote-qa.americannational.com/expertquote/; UseActiveTab=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0308: Wait on Edge Browser to open | Module: Edge Browser | Values: BODY=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0309: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0310: Policy Load Sync | Module: TBox Wait | Values: Duration=3000 | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0311: Restart Microsoft Edge Message Exists? | Module: Restart Microsoft Edge Message | Values: OK=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0312: Restart Microsoft Edge Message - Click OK | Module: Restart Microsoft Edge Message | Values: OK=X | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0313: Username does not exist | Module: Login | Values: Username=True | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0314: Sync to EQ | Module: TBox Wait | Values: Duration=1000 | Reason: 14.11.24 12:04:11 [ff01620@dnanico1.aniconet.com]
# Step 0315: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0316: EQ|Common|Check if Logout Exists | Module: EQ|Common|Logout of EQ | Values: logout=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0317: EQ|Common|Click Logout of EQ | Module: EQ|Common|Logout of EQ | Values: logout=X; logout Log Out=X | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0318: Login | Module: Login | Values: Username=True; Password=${ENV:CL_EQ_PASSWORD}{TAB}; Sign On=X; Username=YDH040{TAB} | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0319: Retrieve Dex Agent Name | Module: TBox Set Buffer | Values: Buffer name: GetHostname="""${COMPUTERNAME}"""; Buffer name: AgentName={B[GetHostname]} | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0320: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0321: Search by QuoteNum | Module: EQ|Common|Search by QuoteNum | Values: quoteSearchInput={SENDKEYS[{B[Quote_Num]}]}{TAB}{TAB}; Search=X | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0322: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0323: CL|EQ|Common|Search Policy Results Table | Module: EQ|Common|Search Policy Results Table | Values: Results TABLE=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0324: CL|EQ|Common|Search Policy Results Table | Module: EQ|Common|Search Policy Results Table | Values: Results TABLE > <Row> > <Cell> (ExplicitName=Name)={STRINGTOUPPER[{B[LastName]}, {B[FirstName]}]}; Results TABLE > edit=X | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0325: Waiton Name and QuoteNum | Module: EQ|Common|Narrative | Values: Name and Quote Num="New Quote" | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0326: Verify QuoteNum | Module: EQ|Common|Narrative | Values: Name and Quote Num={REGEX[{B[NameQuoteNum]}|{B[Quote_Num]}|{B[Policy#]}]} | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0327: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Billing | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0328: Check if on Correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0329: Navigate to Correct Screen | Module: EQ|Common|Navigation | Values: Nav Link=X | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0330: EQ|Common|Review Required Pop-up | Module: EQ|Common|Review Required Pop-up | Values: Keep Going=x | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0331: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Billing | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0332: Buffer Screen Name if different | Module: TBox Set Buffer | Values: Buffer name: Screen=<BLANK — reusable-block parameter is not supplied> | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0333: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0334: Wait on for correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 30.03.26 16:09:09 [ff00958@dnanico1.aniconet.com]
# Step 0335: EQ|Common|Billing | Module: EQ|BOP|Billing | Values: Billing Information Heading=True; Mortgagee Button=X; Create New Billing Account=x | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0336: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0337: EQ|Common|Billing - Enter Other Info | Module: EQ|BOP|Billing | Values: Billing Information Heading=True; OTHER Button=x; First Name={SENDKEYS[Tommy]}{TAB}; Last Name={SENDKEYS[Automation]}{TAB}; Business Name={SENDKEYS[Auto Corp]}{TAB}; Address1={SENDKEYS[9 Center Road]}{TAB}; City={SENDKEYS[Mahopac]}{TAB}; State={SENDKEYS[NY]}{TAB}; Zip Code={SENDKEYS[10541]}{TAB}{TAB}{TAB} | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0338: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0339: EQ|CommonP|Billing|Select Direct Bill and Payment Plan | Module: EQ|BOP|Billing | Values: Direct Bill Button=x{TAB}; 1 Payment Button=x{TAB}{TAB} | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0340: Wait on screen to update | Module: TBox Wait | Values: Duration=5000 | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0341: EQ|Common|Billing|Select Payment Due Date | Module: EQ|BOP|Billing | Values: Choose payment due date={SENDKEYS[01]}{TAB} | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0342: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0343: EQ|Common|Billing|Select Initial Payment Method | Module: EQ|BOP|Billing | Values: Check Button=X{TAB}{TAB}; Credit Card Button=X{TAB}{TAB} | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0344: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0345: EQ|Common|Billing|Fill in Check Number | Module: EQ|BOP|Billing | Values: Check Number=False | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0346: EQ|Common|Billing|Select Initial Payment Method | Module: EQ|BOP|Billing | Values: Check Button=X{TAB}{TAB}; Credit Card Button=X{TAB}{TAB} | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0347: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0348: EQ|Common|Billing|Fill in Check Number | Module: EQ|BOP|Billing | Values: Check Number=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0349: EQ|Common|Billing|Fill in Check Number | Module: EQ|BOP|Billing | Values: Check Number={SENDKEYS[1205]}{ENTER}{TAB}{TAB} | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0350: EQ |Common|Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0351: EQ|Common|Billing|Select Initial Payment Amount | Module: EQ|BOP|Billing | Values: Initial Payment - Full Balance=x | Reason: 06.08.25 06:48:12 [ff01620@dnanico1.aniconet.com]
# Step 0352: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Submission | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0353: Check if on Correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0354: Navigate to Correct Screen | Module: EQ|Common|Navigation | Values: Nav Link=X | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0355: EQ|Common|Review Required Pop-up | Module: EQ|Common|Review Required Pop-up | Values: Keep Going=x | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0356: Buffer Screen Name | Module: TBox Set Buffer | Values: Buffer name: Screen=Submission | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0357: Buffer Screen Name if different | Module: TBox Set Buffer | Values: Buffer name: Screen=<BLANK — reusable-block parameter is not supplied> | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0358: EQ Loading Indicator Wait | Module: EQ |Common|Loading Indicator Wait | Values: Loading ...=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0359: Wait on for correct Screen | Module: EQ|Common|Navigation | Values: Screen Heading=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0360: EQ|BOP|Submission | Module: EQ|BOP|Submission|Main Page | Values: Submission Screen Heading=True; No Referral Needed Verification=False; Launch to Checklist Button=x; Checklist Button_SFP=X; No Referral Needed Verification=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0361: Sync for the Screen | Module: TBox Wait | Values: Duration=2200 | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0362: CL|EQ|eChecklist - Residence Photo #1 | Module: EQ|Common|eChecklist - eChecklist | Values: Policy Header={CLICK}; Residence Photo #1=X; Accept=True; Exception=X; Add a Note...=True; Add a Note...=Test{TAB}; Accept=X; OK - Accept=X; OK=X; OK=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0363: CL|EQ|eChecklist -Sync | Module: EQ|Common|eChecklist - eChecklist | Values: Residence Photo #1==True; Review Complete=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0364: CL|EQ|eChecklist - Wait until UL Roof | Module: EQ|Common|eChecklist - eChecklist | Values: UL Roof Type Credit=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0365: CL|EQ|eChecklist - Click Policy Header | Module: EQ|Common|eChecklist - eChecklist | Values: Policy Header={CLICK}; UL Roof Type Credit=X | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0366: CL|EQ|eChecklist - UL Roof | Module: EQ|Common|eChecklist - eChecklist | Values: UL Roof Type Credit Header=True; Accept=X; Exception=X; Add a Note...=Test; OK - Accept=X; OK - Accept=True; OK=X; OK=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0367: CL|EQ|eChecklist -Sync | Module: EQ|Common|eChecklist - eChecklist | Values: UL Roof Type Credit Header=True; Review Complete=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0368: CL|EQ|eChecklist -Loss Runs - 3 Yrs | Module: EQ|Common|eChecklist - eChecklist | Values: Policy Header={CLICK}; All Link=<BLANK>; Loss Runs (Tiered - 5 Years; Not tiered - 3 years)=X; Loss Runs Header=True; Accept=True; Exception=X; Add a Note...=True; Add a Note...=Test{TAB}; Accept=X; OK - Accept=X; OK=X; OK=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0369: CL|EQ|eChecklist -Sync | Module: EQ|Common|eChecklist - eChecklist | Values: Loss Runs - 3 years Header=True; Review Complete=True | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0370: CL|EQ|eChecklist - Review Complete to Update | Module: EQ|Common|eChecklist - eChecklist | Values: Policy Header={CLICK}; Signature Page link=X; Signature Page (bound coverage only) - SFP=X; Review Complete=True; Review Complete=X | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0371: Check for Attach | Module: EQ|Common|eChecklist - eChecklist | Values: Attach=True; Drag and Drop files here to upload (or click here to open a file explorer)={CLICK} | Reason: 12.03.26 15:34:42 [ff01729@dnanico1.aniconet.com]
# Step 0372: Click on Attach | Module: EQ|Common|eChecklist - eChecklist | Values: Attach=X; Drag and Drop files here to upload (or click here to open a file explorer)=True | Reason: 12.03.26 15:34:42 [ff01729@dnanico1.aniconet.com]
# Step 0373: Click on Drag and Drop | Module: EQ|Common|eChecklist - eChecklist | Values: Attach=x; Drag and Drop files here to upload (or click here to open a file explorer)={CLICK} | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0374: eChecklist - Signature Page - Upload | Module: EQ|Common|eChecklist - Signature Page - Upload | Values: Enter File Path and Name={TAB}{CLICK}{TAB}; &Open=X; Enter File Path and Name={SENDKEYS["\\mis\sys\QLTY\Test_Automation\Tricentis_Tosca\Screenshots\Signature Test Page BOPSMART.gif"]}{TAB} | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Step 0375: CL|EQ|Common|eChecklist Submit | Module: EQ|Common|eChecklist - eChecklist | Values: Submit=X; Ok-Submit=True; Ok-Submit=X | Reason: 16.10.25 15:27:37 [ff01620@dnanico1.aniconet.com]
# Step 0376: CL|EQ|Esignature|Click OK | Module: EQ|Common|Esignature|Click OK | Values: Ok To Update from Checklist=X | Reason: 30.03.26 16:09:04 [ff00958@dnanico1.aniconet.com]
# Disabled granular value: Step 0031 / Create New Client / No results found. Please choose Create New Client to continue entering a new client.: True
# Disabled granular value: Step 0036 / Account Details - Account Info / County: {SENDKEYS[Colbert]}{TAB}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {SCROLL[2]}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {CLICK[0px][-10px]}
# Disabled granular value: Step 0039 / Proposal Start / Individually Owned / DBA CheckBox: {CLICK}
# Disabled granular value: Step 0041 / SSN / SUBMIT: True
# Disabled granular value: Step 0041 / SSN / SUBMIT: {TAB}
# Disabled granular value: Step 0041 / SSN / SUBMIT: X
# Disabled granular value: Step 0089 / EQ|Primary Insured|Enter Required Info|Other / Mobile Phone Number: {TAB}{SENDKEYS["5554447777"]}{TAB}
# Disabled granular value: Step 0089 / EQ|Primary Insured|Enter Required Info|Other / Primary Phone: {TAB}{SENDKEYS["4445557788"]}{TAB}
# Disabled granular value: Step 0090 / EQ|Primary Insured|Click Edit General Info / Edit General Info: X
# Disabled granular value: Step 0092 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Business Name: {TAB}{SENDKEYS["BOP BASIC Test"]}{ENTER}{TAB}

# --------------------------------------------------------------------------------------------------
# SOURCE-CONDITIONAL ACTIONS NOT EXECUTED FOR THIS REPRESENTATIVE ITERATION
# --------------------------------------------------------------------------------------------------
# Step 0039 / Proposal Start / Personal Auto: condition LOB == "PAP" is false; value X
# Step 0039 / Proposal Start / Motorcycle: condition LOB == "MOTO" is false; value X
# Step 0039 / Proposal Start / Recreational Vehicle: condition LOB == "RV" is false; value X
# Step 0039 / Proposal Start / Home: condition LOB == "HO" is false; value X
# Step 0039 / Proposal Start / ROP: condition LOB == "ROP" is false; value X
# Step 0039 / Proposal Start / Business Owners: condition LOB=="BOP" is false; value X
# Step 0039 / Proposal Start / Search Business Name: condition LOB != "SFP" is false; value {TAB}
# Step 0039 / Proposal Start / Individually Owned, DBA, or T/A: condition BusinessType == "Individual" is false; value {CLICK}
# Step 0039 / Proposal Start / Individual DBA: condition BusinessType == "Individual" is false; value Tester Automation
# Step 0039 / Proposal Start / Lessors Risk  - No: condition LOB != "SFP" is false; value X
# Step 0049 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0071 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0083 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0086 EQ|Primary Insured|Enter Required Info|Type|BOP: source condition LOB == "BOP" is false for this iteration
# Step 0089 / EQ|Primary Insured|Enter Required Info|Other / Individual/Sole Proprietor: condition LOB !="SFP" is false; value x
# Step 0092 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Farm Bureau Member - No: condition State == "MA"||State=="ME"||State=="NH"||State=="NJ"||State=="RI" is false; value X
# Step 0092 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Do you wish to disclose Race and Gender Info? - No: condition State == "CA" is false; value X
# Step 0092 / EQ|Primary Insured|General Info ----------->>>>>>>>Quote Description / Is the client a member of any Professional Trade Association?- No: condition State == "MA"||State=="ME"||State=="NH"||State=="NJ"||State=="RI" is false; value X
# Step 0100 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0103 / Buffer name: BusinessOwnerIndex: condition 'Index for Business Owner' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0103 / Buffer name: NamedInsuredIndex: condition 'Index for Named Insured' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0103 / Buffer name: ThirdPartyIndex: condition 'Index for Third Party' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0103 / Buffer name: KeyIndividualIndex: condition 'Index for Key Individual' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0103 / Buffer name: AuditContactIndex: condition 'Index for Audit Contact' != NULL is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0104 / EQ|BOP|Client Details|Click Client Role on Rolodex / BusinessOwner: condition 'Index for Business Owner' != NULL is false; value x
# Step 0104 / EQ|BOP|Client Details|Click Client Role on Rolodex / NamedInsured: condition 'Index for Named Insured' != NULL is false; value x
# Step 0104 / EQ|BOP|Client Details|Click Client Role on Rolodex / ThirdPartyDesignee: condition 'Index for Third Party' != NULL is false; value x
# Step 0104 / EQ|BOP|Client Details|Click Client Role on Rolodex / KeyIndividual: condition 'Index for Key Individual' != NULL is false; value x
# Step 0104 / EQ|BOP|Client Details|Click Client Role on Rolodex / Audit Contact: condition 'Index for Audit Contact' != NULL is false; value {TAB}{CLICK}
# Step 0110 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0113 / ------------------>EQ|Common|Verify that Edit is not displayed and Text is Locked / Edit: condition Edit == "x" is false; value <BLANK — reusable-block parameter is not supplied>
# Step 0121 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0154 / EQ|SFP|Div I - Add Residence|Add Residence - Detail / Seasonal or Vacant - No: condition CE == NULL is false; value {Click}
# Step 0164 / EQ|SFP|Div I - Add Residence|Add Residence Covg / Perils: condition CE == NULL is false; value 3
# Step 0165 / EQ|SFP|Div I - Add Residence|Add Residence Covg / Actual Cash Value: condition CE == NULL is false; value Replacement Cost
# Step 0177 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0187 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0201 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0224 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration
# Step 0233 Buffer Screen Name if different: source condition Screen2 != NULL is false for this iteration

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
# Normal source steps represented: 381/381
# Active/conditional source steps represented: 286/286
# Source-disabled steps preserved as comments: 95/95
# Recovery steps preserved as comments: 8/8
# Active non-structural granular values processed: 542/542
# Structural/container granular values represented through owning steps: 20
# Functional correctness still requires execution evidence and/or BA/SME validation.
