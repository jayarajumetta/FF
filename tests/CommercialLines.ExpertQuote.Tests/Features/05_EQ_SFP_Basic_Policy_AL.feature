# v54 RAW TOSCA SOURCE: CL_EQ_TestCases_Staging_Area_Pre_Production.tsu
# Raw TestCase: EQ | SFP | Basic Policy [3a13ce49-1a8e-d822-14cf-7d9182268313]
# Raw TemplateInstance: TemplateInstance of EQ | SFP | Basic Policy [3a13ce49-1a8e-aa72-b25a-6fb70e4f44ed]
# Source truth: raw .tsu object graph only; manual CSV/XLSX/HTML are NOT generation or ordering inputs.

@CL_EQ @SFP @basic_new_business_policy

Feature: EQ SFP Basic Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ SFP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given I open a browser session
  Scenario Outline: EQ SFP Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete policy Details (Optimized)
    And I navigate to the required policy screen for screen
    And I verify None of the Above
    And I navigate to the required policy screen for navigate to screen
    And I enter Required Info
    And I navigate to the required policy screen for navigate to correct screen
    And I complete edit Client Roles
    And I navigate to the required policy screen for policy data entry
    And I add/Edit a Narrative and Verify Timestamp
    And I navigate to the required policy screen for subsequent screen 0118
    And I enter Required
    And I add a Location
    And I add a Residence
    And I add Residence Covg
    And I navigate to the required policy screen for subsequent screen 0174
    And I enter FPP
    And I navigate to the required policy screen for subsequent screen 0184
    And I complete equipment Breakdown and Implements Coverage
    And I navigate to the required policy screen for subsequent screen 0201
    And I add bicycle
    And I navigate to the required policy screen for subsequent screen 0215
    And I complete nOT CE
    And I navigate to the required policy screen for subsequent screen 0236
    And I complete insurance Score
    And I navigate to the required policy screen for subsequent screen 0250
    And I complete mortgagee/Loss Payee Information
    And I navigate to the required policy screen for subsequent screen 0273
    And I verify premium
    And I navigate to the required policy screen for subsequent screen 0282
    And I open a CLAS Browser and Search for EQ by Description 1
    And I complete restart Edge Popup
    Then I open a CLAS Browser and Search for EQ by Description 1 for username
    And I sign out of the application
    And I open a CLAS Browser and Search for EQ by Description 1 for open a clas browser and search for eq by description 1
    And I complete forms verification Retrieve QuoteID & SessionID by Browser Console
    And I complete save for Later/Return to Admin

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/05_eq_sfp_basic_policy_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ga.json | GA | GA | Georgia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_la.json | LA | LA | Louisiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_nv.json | NV | NV | Nevada | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_oh.json | OH | OH | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ok.json | OK | OK | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_sd.json | SD | SD | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_tn.json | TN | TN | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_ut.json | UT | UT | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/05_eq_sfp_basic_policy_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
