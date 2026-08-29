# v54 RAW TOSCA SOURCE: CL-DC TestCases Staging Area.tsu
# Raw TestCase: CPP | Smoke Test [3a1632ff-e6d4-3a98-9b8b-bbb72ecbcd7e]
# Raw TemplateInstance: TemplateInstance of CPP | Smoke Test [3a163307-6c7b-6097-1b44-d576452e1f66]
# Source truth: raw .tsu object graph only; manual CSV/XLSX/HTML are NOT generation or ordering inputs.

@CL_DC @CPP @smoke_test

Feature: CPP Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CPP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: CPP Smoke Test - <stateCode>
    Given CLDC smoke data "CPP" for state "<stateCode>" named "<stateName>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    And I start a new quote
    And I enter individual client information
    And I complete required policy information
    And I select CPP Coverage - GL
    And I select CPP Coverage - CP
    And I navigate to Policy Info and Verify Desc
    And I sign out of the application for logged in user

    Examples:
      | stateCode | stateName |
      | AZ | Arizona |
      | CT | Connecticut |
      | DE | Delaware |
      | MA | Massachusetts |
      | MD | Maryland |
      | ME | Maine |
      | NH | New Hampshire |
      | NJ | New Jersey |
      | NY | New York |
      | OR | Oregon |
      | PA | Pennsylvania |
      | RI | Rhode Island |
      | VA | Virginia |
      | VT | Vermont |
      | WA | Washington |
      | WV | West Virginia |
