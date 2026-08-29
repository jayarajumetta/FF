# v54 RAW TOSCA SOURCE: CL-DC TestCases Staging Area.tsu
# Raw TestCase: WC | Smoke Test [3a161f5c-3d24-fe0a-93aa-e4ede5fe1b61]
# Raw TemplateInstance: TemplateInstance of WC | Smoke Test [3a161f74-113c-29a9-50fe-0526adda9495]
# Source truth: raw .tsu object graph only; manual CSV/XLSX/HTML are NOT generation or ordering inputs.

@CL_DC @smoke_test

Feature: WC Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the WC Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: WC Smoke Test - <stateCode>
    Given CLDC smoke data "WC" for state "<stateCode>" named "<stateName>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    And I start a new quote
    And I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
    And I complete aJAX Error Check
    And I complete required billing information
    And I complete the Associated Client Info
    And I complete required policy information
    And I complete WC Specific Fields
    And I navigate to Policy Info and Verify Desc
    And I sign out of the application for logged in user

    Examples:
      | stateCode | stateName |
      | AL | Alabama |
      | AR | Arkansas |
      | AZ | Arizona |
      | CT | Connecticut |
      | CO | Colorado |
      | DE | Delaware |
      | IA | Iowa |
      | ID | Idaho |
      | IL | Illinois |
      | IN | Indiana |
      | KS | Kansas |
      | KY | Kentucky |
      | MA | Massachusetts |
      | MD | Maryland |
      | MN | Minnesota |
      | MO | Missouri |
      | MS | Mississippi |
      | MT | Montana |
      | NE | Nebraska |
      | NH | New Hampshire |
      | NJ | New Jersey |
      | NM | New Mexico |
      | NV | Nevada |
      | NY | New York |
      | OK | Oklahoma |
      | PA | Pennsylvania |
      | RI | Rhode Island |
      | SC | South Carolina |
      | SD | South Dakota |
      | TN | Tennessee |
      | UT | Utah |
      | VA | Virginia |
      | VT | Vermont |
      | WV | West Virginia |
