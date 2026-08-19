# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 16
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 16
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
@CL_DC @CPP @basic_new_business_policy

Feature: CPP Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the CPP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: CPP Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
    And I complete aJAX Error Check
    And I complete required billing information
    And I complete the Associated Client Info
    And I complete required policy information
    And I run insurance score
    And I select CPP Coverage - GL
    And I select CPP Coverage - CP
    And I select CPP Coverage - IM
    And I select CP Detail
    And I complete CP Fields
    And I complete mask Error Recovery
    And I complete CP Fields for policy coverage
    And I complete CP Fields for location
    And I complete CP Fields for building
    And I add a Rating Group
    And I complete Structure Questions
    And I complete ensure Property of Others Rating Group has been entered
    And I add Addl Interests
    And I complete Property UW Questions
    And I return to CPP Navigation
    And I select GL Detail
    And I complete CGL Fields
    And I add Class
    And I add [CG0435] Employee Benefits Liability Endorsement
    And I add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations)
    And I add [CG 2149] Total Pollution Exclusion Endorsement
    And I verify and Fill out [FG0055] Employment Practices Liability Insurance Coverage Endorsement
    And I add Addl Interest [CG2007] - Engineers
    And I add Addl Interest [CG2020] Add'l Insured-Charitable Institution
    And I add Addl Interest [CG2023] Add'l Insured-Executors
    And I add Addl Interest [CG2025] Add'l Insured-Executive Officers
    And I add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic
    And I answer GL UW Questions OR & WA
    And I return to CPP Navigation for return to cpp
    And I select IM Detail
    And I add Accounts Receivable Coverage
    And I add Bailees Customers Coverage
    And I add Computer Systems
    And I add Contractors Equipment
    And I add Motor Truck Cargo
    And I add Signs
    And I add Accounts Receivable
    And I complete if search result Alert exists
    And I complete ensure Class has been entered for Accounts Receivable
    And I add Bailees Customers
    And I complete if search result Alert exists for show me
    And I complete ensure Class has been entered for Bailees Customers
    And I add Computer Systems for risk
    And I complete if search result Alert exists for duck creek policy
    And I complete ensure Class has been entered for Computer Systems
    And I add Signs for risk
    And I add CM 66 01 Exclude Named Customer
    And I add IF 00 02 Waterborne Equipment
    And I complete Accounts Receivable Questions
    And I complete Bailees Customers Questions
    And I complete Computer Systems Questions
    And I complete Contractors Equipment Questions
    And I complete Motor Truck Cargo Questions (Owner)
    And I complete Signs Questions
    And I return to CPP policy navigation
    And I select GL Available Classiifcation
    And I navigate to Underwriting Info Screens
    And I answer General UW Questions
    And I answer General Liability History Questions
    And I answer Commercial Property History Questions
    And I answer Other Insurance History Questions
    And I navigate back to CPP Main
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/003_cpp_basic_policy_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/003_cpp_basic_policy_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
