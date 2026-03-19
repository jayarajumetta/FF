@FormsSmoke
Feature: Forms Validation Smoke Test

  Standalone test that grabs the DuckCreek_SessionId cookie from CLAS Express
  and validates forms without running the full SFP policy flow.

  Scenario: Validate forms for existing quote via CLAS session cookie
    Given I have an existing quote "01918753" in state "AR" for LOB "SFP"
    When I extract the DuckCreek session via CLAS cookie
    Then the forms should match the baseline
