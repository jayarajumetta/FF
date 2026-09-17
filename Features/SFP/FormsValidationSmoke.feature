@SFP @Forms @BusinessOutcomes @SfpBasicOutcome @AutomationId-SFP-FORMS-VALIDATION
Feature: Forms Validation Smoke Test

  Standalone test that grabs the DuckCreek_SessionId cookie from CLAS Express
  and validates forms without running the full SFP policy flow.
  Requires stable QA quotes that exist in the target environment.
  Add one Example row per state — use a permanent QA quote for each.

  @Smoke
  Scenario Outline: SFP Forms Validation - <State>
    Given I have an existing quote "<QuoteNumber>" in state "<State>" for LOB "SFP" and company "<Company>"
    When I extract the DuckCreek session via CLAS cookie
    Then the forms should match the baseline

    Examples:
      | State | QuoteNumber | Company                                      |
      | AR    | 01918753    | American National Property And Casualty Co. |
