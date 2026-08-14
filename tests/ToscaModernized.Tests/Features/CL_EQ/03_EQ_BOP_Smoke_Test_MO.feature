# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 03_EQ_BOP_Smoke_Test_MO.feature
# Application: Commercial Lines ExpertQuote
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_EQ @BOP @smoke @Missouri @Edge @manual @automated
Feature: Create, close, retrieve, and verify a Missouri Business Owners quote in ExpertQuote
  As an ExpertQuote user
  I want to create a Missouri Business Owners quote for a new individual/DBA client
  So that I can confirm the quote is created, can be found again, and retains its identity


  Background: Establish the Commercial Lines ExpertQuote application context
    Given the Commercial Lines ExpertQuote application context and source-defined prerequisites are initialized

  Scenario: Create and retrieve a Missouri BOP quote for a new individual DBA client
    # Source steps 0028-0031: begin quote and create a new client.
    Given the "New Quote" control is visible
    When I click "New Quote"
    And I generate and retain a RANDOM first name matching "BOP [a-z]{3}" as "FirstName"
    And I generate and retain a RANDOM last name matching "Smoke[a-z]{4}" as "LastName"
    Then the "Client Info" and "New/Existing Client Search" sections should be visible
    When I enter the retained RANDOM value "FirstName" in the client first-name field
    And I enter the retained RANDOM value "LastName" in the client last-name field
    And I enter date of birth "08/13/2004"
    # The DOB above is the one-iteration hard-coded value for execution on 08/13/2026.
    # The Tosca source rule is execution date minus 22 years, formatted MM/dd/yyyy.
    And I click "Search"
    Then the "Existing Client Match" section should be displayed
    When I click "Create New Client"
    And I click "Next"

    # Source steps 0032-0038: account information and address.
    Then the "Account Information" header should be visible
    When I leave "Owner Middle Name" blank
    And I enter a RANDOM 10-digit owner phone number matching "3[0-9]{9}"
    And I enter a RANDOM owner email address matching "test@[a-z]{4}.com"
    And I select marital status "Married"
    And I enter the following account address:
      | Field          | Hard-coded value       |
      | Street Address | 317 Park Central East  |
      | Address 2      |                        |
      | City           | Springfield            |
      | State          | Missouri               |
      | ZIP            | 65805                  |
    Then the "Map" control should exist
    And the "Satellite" control should exist
    When I answer "Yes" to "Have you received mail at this address for at least 90 days?"
    And I answer "Yes" to "Is the account address also where the client resides?"
    And I click "Next"

    # Source steps 0039-0040: proposal creation data.
    Then the "Proposal Details" header should be visible
    When I select line of business "Business Owners"
    And I move past the "Search Business Name" field without entering a business name
    And for this one manual iteration I use business type "Individual"
    # MANUAL-ITERATION CHOICE: the export contains actions conditional on BusinessType == Individual,
    # but it does not expose a resolved BusinessType value. This choice is explicit rather than inferred silently.
    And I select business ownership "Individually Owned, DBA, or T/A"
    And I enter individual DBA name "Tester Automation"
    And I enter effective date "03-01-2025"
    And I keep the new-account-address indicator set to "True"
    And I answer "No" to "Lessors Risk"
    And I select state "Missouri"
    And I enter agent producer code "D2102"
    And I retain the displayed effective date as runtime value "EffDate"
    And I click "Start Quote"
    Then the runtime line-of-business value should be retained as "BOP"

    # Source steps 0041-0044: SSN entry and optional no-prefill-match handling.
    And the technical wait buffer is set to "5000" milliseconds
    Then the message "The SSN could not be found. Please enter an SSN." should be visible
    When I enter a RANDOM 9-digit SSN consisting of fixed prefix "025" followed by "6" random digits
    And I move focus away from the SSN field
    Then the active Angular "Submit" control should be visible
    When I activate the active Angular "Submit" control
    And if the "No Prefill Match Found" popup is displayed, I click "Continue"

    # Source steps 0045-0053: navigate to the target screen.
    And the technical wait buffer is set to "25000" milliseconds
    And the required target screen is "PreQualification"
    When the current screen is not "PreQualification", I use the navigation link for "PreQualification"
    And if the "Review Required" popup is displayed and the configured action is "Keep Going", I click "Keep Going"
    And I wait until the configured ExpertQuote loading-indicator condition is satisfied
    Then the "PreQualification" screen heading should exist

    # Source steps 0054-0056: capture the quote identity and close the quote.
    When I capture the full displayed "Name and Quote" text as runtime value "Quote_NameNum"
    And I derive runtime value "Quote_Num" by removing the retained RANDOM "LastName" from "Quote_NameNum"
    And I retain "Quote_Num" as runtime value "QuoteID"
    And I click "Close Quote"

    # Source steps 0057-0068: search for the same quote and verify identity.
    And I wait until the configured ExpertQuote loading-indicator condition is satisfied
    And I enter the captured runtime value "Quote_Num" in the quote-search field
    And I click "Search"
    And I wait until the configured ExpertQuote loading-indicator condition is satisfied
    And the required target screen is "PreQualification"
    When the retrieved quote is not on "PreQualification", I use the navigation link for "PreQualification"
    And if the "Review Required" popup is displayed and the configured action is "Keep Going", I click "Keep Going"
    And I wait until the configured ExpertQuote loading-indicator condition is satisfied
    Then the "PreQualification" screen heading should exist
    And the displayed "Name and Quote" text should exactly equal captured runtime value "Quote_NameNum"

    # Source steps 0069-0073: post-condition cleanup.
    And after verification, any running browser processes named "iexplore.exe", "Chrome.exe", "MicrosoftEdge.exe", "Firefox.exe", and "msEdge.exe" are force-closed with a maximum exit wait of "5" seconds per process

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# 1. The redirect-detection Username verification and 1000 ms synchronization loop were disabled.
# 2. The assertion "No results found. Please choose Create New Client..." was disabled.
# 3. County "Greene" was present in source data but its field action was disabled; it is not entered.
# 4. Legacy "SUBMIT" visibility, tab, and click actions were disabled; the active Angular Submit is used.
# 5. DBA checkbox scroll and coordinate/direct-click actions were disabled.
# 6. Screen2 was not supplied; navigation uses only "PreQualification".
# 7. BusinessType was not resolved in the export. "Individual" is an explicit one-iteration manual choice
#    so that the conditional DBA actions can be executed; it is not claimed as resolved Tosca data.
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# On TestCase, TestStep, or TestStepValue failure, Tosca captures a Desktop screenshot under:
#   \\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\SFP
# using filenames "SFP BASIC TestCase", "SFP BASIC TestStep", or "SFP BASIC TSV", then performs
# browser-process cleanup. The SFP naming is preserved from the source and should be reviewed because
# this test case is a BOP smoke test.
