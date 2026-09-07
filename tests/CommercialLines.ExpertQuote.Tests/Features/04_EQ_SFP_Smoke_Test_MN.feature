@CL_EQ @SFP @smoke_test

Feature: EQ SFP Smoke Test
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ SFP Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines ExpertQuote for policy processing
    Given I open a browser session
  Scenario Outline: EQ SFP Smoke Test - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines ExpertQuote application
    And I sign in to Commercial Lines ExpertQuote using configured credentials
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete quote Identifying and Close Quote
    And I search by QuoteNum
    And I navigate to the required policy screen for screen
    Then I complete verifying Quote
    Examples:
      | stateCode | dataFile                                        | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/04_eq_sfp_smoke_test_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/04_eq_sfp_smoke_test_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/04_eq_sfp_smoke_test_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/04_eq_sfp_smoke_test_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/04_eq_sfp_smoke_test_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/04_eq_sfp_smoke_test_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/04_eq_sfp_smoke_test_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/04_eq_sfp_smoke_test_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/04_eq_sfp_smoke_test_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/04_eq_sfp_smoke_test_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/04_eq_sfp_smoke_test_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/04_eq_sfp_smoke_test_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Scenarios/04_eq_sfp_smoke_test_la.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/04_eq_sfp_smoke_test_ma.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/04_eq_sfp_smoke_test_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/04_eq_sfp_smoke_test_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/04_eq_sfp_smoke_test_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/04_eq_sfp_smoke_test_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/04_eq_sfp_smoke_test_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Scenarios/04_eq_sfp_smoke_test_nd.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/04_eq_sfp_smoke_test_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/04_eq_sfp_smoke_test_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/04_eq_sfp_smoke_test_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/04_eq_sfp_smoke_test_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/04_eq_sfp_smoke_test_oh.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/04_eq_sfp_smoke_test_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/04_eq_sfp_smoke_test_or.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/04_eq_sfp_smoke_test_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/04_eq_sfp_smoke_test_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/04_eq_sfp_smoke_test_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Scenarios/04_eq_sfp_smoke_test_tx.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/04_eq_sfp_smoke_test_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/04_eq_sfp_smoke_test_wa.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Scenarios/04_eq_sfp_smoke_test_wi.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Scenarios/04_eq_sfp_smoke_test_wy.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

