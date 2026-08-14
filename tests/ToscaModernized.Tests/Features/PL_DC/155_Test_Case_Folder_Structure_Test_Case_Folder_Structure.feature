# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 155_Test_Case_Folder_Structure_Test_Case_Folder_Structure.feature
# Application: Personal Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@PL_DC @Policy @manual_conversion @Edge @manual @archive @automated
Feature: Execute Test Case Folder Structure for one representative PL|DC iteration
  As a PL|DC policy processing user
  I want to complete the Test Case Folder Structure workflow for the selected source iteration
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Personal Lines Duck Creek application context
    Given the Personal Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: Test Case Folder Structure using representative iteration Test Case Folder Structure
    Given the complete source-defined setup flow has been performed in the Background
    Then the structural or setup-only Tosca TestCase is represented without inventing an application action

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# No source-disabled TestSteps or TestStepValues were present in the selected iteration.
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario was exported for the selected iteration.
