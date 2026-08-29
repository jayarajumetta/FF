# v54 RAW TOSCA SOURCE: CL-DC TestCases Staging Area.tsu
# Raw TestCase: CP | Smoke Test [3a161e9f-fdf6-48a7-45ae-e075e2ea975f]
# Raw TemplateInstance: TemplateInstance of CP | Smoke Test [3a161ea8-8705-c5b0-f2d5-c58a42449cef]
# Source truth: raw .tsu object graph only; manual CSV/XLSX/HTML are NOT generation or ordering inputs.

@CL_DC @smoke_test

Feature: CP Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: CP Smoke Test - <stateCode>
    Given CLDC smoke data "CP" for state "<stateCode>" named "<stateName>" are loaded
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
