@CL_DC @BAP @basic_new_business_policy

Feature: BAP Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the BAP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: BAP Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I complete required policy information
    And I complete Business Auto policy-specific fields
    And I run insurance score
    And I complete underwriting information from the policy information screen
    And I navigate to policy coverages
    And I complete required location information
    And I navigate to state details
    And I complete vehicle information
    And I complete driver information
    And I complete required endorsement information
    And I add endorsement
    And I complete required additional-interest information
    And I complete required underwriting question information
    And I complete required billing information
    And I add notepad comment
    And I verify premium
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification

    Examples:
      | stateCode | dataFile                                        | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/001_bap_basic_policy_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/001_bap_basic_policy_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/001_bap_basic_policy_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/001_bap_basic_policy_ct.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/001_bap_basic_policy_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/001_bap_basic_policy_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/001_bap_basic_policy_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/001_bap_basic_policy_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/001_bap_basic_policy_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/001_bap_basic_policy_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/001_bap_basic_policy_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/001_bap_basic_policy_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/001_bap_basic_policy_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Scenarios/001_bap_basic_policy_la.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/001_bap_basic_policy_md.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/001_bap_basic_policy_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/001_bap_basic_policy_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/001_bap_basic_policy_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/001_bap_basic_policy_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/001_bap_basic_policy_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Scenarios/001_bap_basic_policy_nd.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/001_bap_basic_policy_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/001_bap_basic_policy_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/001_bap_basic_policy_nj.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/001_bap_basic_policy_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/001_bap_basic_policy_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/001_bap_basic_policy_ny.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/001_bap_basic_policy_oh.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/001_bap_basic_policy_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/001_bap_basic_policy_or.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/001_bap_basic_policy_pa.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/001_bap_basic_policy_ri.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/001_bap_basic_policy_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/001_bap_basic_policy_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/001_bap_basic_policy_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Scenarios/001_bap_basic_policy_tx.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/001_bap_basic_policy_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/001_bap_basic_policy_va.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/001_bap_basic_policy_vt.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/001_bap_basic_policy_wa.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Scenarios/001_bap_basic_policy_wi.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/001_bap_basic_policy_wv.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Scenarios/001_bap_basic_policy_wy.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Scenarios/001_bap_basic_policy_ca.json | CA           | California     | TestData/ExternalDataOverrides.json |

