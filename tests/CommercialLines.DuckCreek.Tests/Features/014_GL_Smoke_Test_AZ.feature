# v54 RAW TOSCA SOURCE: CL-DC TestCases Staging Area.tsu
# Raw TestCase: GL | Smoke Test [3a161ed5-3580-cbf2-2c46-edfacbc4cd73]
# Raw TemplateInstance: TemplateInstance of GL | Smoke Test [3a161ee0-b94a-fc24-a176-4e86c4ebc53d]
# Source truth: raw .tsu object graph only; manual CSV/XLSX/HTML are NOT generation or ordering inputs.

@CL_DC @smoke_test

Feature: GL Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: GL Smoke Test - <stateCode>
    Given CLDC smoke data "GL" for state "<stateCode>" named "<stateName>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    And I start a new quote
    And I enter individual client information
    And I complete required policy information
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
