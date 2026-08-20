# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 16
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
@CL_DC @CPP @smoke_test

Feature: CPP Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CPP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: CPP Smoke Test - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I sign in to Duck Creek
    And I complete restart Edge Popup
    Then I sign in to Duck Creek for logged in user
    And I sign out of the application
    And I sign in to Duck Creek for username
    And I start a new quote
    And I enter individual client information
    And I complete required policy information
    And I select CPP Coverage - GL
    And I select CPP Coverage - CP
    And I navigate to Policy Info and Verify Desc
    And I sign out of the application for logged in user

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/017_cpp_smoke_test_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/017_cpp_smoke_test_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
