# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 14
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
@CL_DC @owners_and_contractors_protective_new_business

Feature: GL OCP Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL OCP Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: GL OCP Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I complete Underwriting Info from Client Screen
    And I complete required policy information
    And I complete OCP Fields
    And I complete OCP Risk Fields
    And I complete [CG0424] Coverage for Injury to Leased Workers
    And I complete [CG2401] Non-Binding Arbitration
    And I complete [CG2812] Pesticide or Herbicide Applicator Coverage
    And I complete [CG3132] Limited Fungi or Bacteria Coverage
    And I complete [CG 20 31] Add'l Insured-Engineers, Architects OCP
    And I complete [CG 29 35] Add'l Insured-State or Political (Permits)
    And I complete [FG0013] - Automatic Additional Insured - Specific
    And I answer GL UW Questions OR & WA
    And I complete required billing information
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/006_gl_ocp_policy_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/006_gl_ocp_policy_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
