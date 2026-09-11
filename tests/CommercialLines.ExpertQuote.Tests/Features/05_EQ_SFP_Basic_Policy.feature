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
      | stateCode | dataFile                                          | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/05_eq_sfp_basic_policy_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/05_eq_sfp_basic_policy_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/05_eq_sfp_basic_policy_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/05_eq_sfp_basic_policy_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/05_eq_sfp_basic_policy_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/05_eq_sfp_basic_policy_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/05_eq_sfp_basic_policy_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/05_eq_sfp_basic_policy_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/05_eq_sfp_basic_policy_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/05_eq_sfp_basic_policy_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/05_eq_sfp_basic_policy_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/05_eq_sfp_basic_policy_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Scenarios/05_eq_sfp_basic_policy_la.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/05_eq_sfp_basic_policy_ma.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/05_eq_sfp_basic_policy_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/05_eq_sfp_basic_policy_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/05_eq_sfp_basic_policy_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/05_eq_sfp_basic_policy_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/05_eq_sfp_basic_policy_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Scenarios/05_eq_sfp_basic_policy_nd.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/05_eq_sfp_basic_policy_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/05_eq_sfp_basic_policy_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/05_eq_sfp_basic_policy_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/05_eq_sfp_basic_policy_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/05_eq_sfp_basic_policy_oh.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/05_eq_sfp_basic_policy_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/05_eq_sfp_basic_policy_or.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/05_eq_sfp_basic_policy_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/05_eq_sfp_basic_policy_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/05_eq_sfp_basic_policy_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Scenarios/05_eq_sfp_basic_policy_tx.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/05_eq_sfp_basic_policy_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/05_eq_sfp_basic_policy_wa.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Scenarios/05_eq_sfp_basic_policy_wi.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Scenarios/05_eq_sfp_basic_policy_wy.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

