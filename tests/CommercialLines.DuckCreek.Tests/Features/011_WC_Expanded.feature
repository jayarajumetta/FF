@CL_DC @expanded_new_business

Feature: WC Expanded
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the WC Expanded workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: WC Expanded - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
    And I complete aJAX Error Check
    And I complete required billing information
    And I complete the Associated Client Info
    And I navigate to Underwriting Info Screen
    And I complete required policy information
    And I complete WC Specific Fields
    Then I complete Estimated premium
    And I complete coverage Information
    And I complete Address 1
    And I complete rating Information
    And I add Class Codes
    And I navigate to Entity Schedule
    And I complete endorsements
    And I add Designated Workplaces Exclusion
    And I add Partners, Officers And Others Exclusion
    And I add Sole Proprietors, Partners, Officers And Others Coverage
    And I complete WC UW Questions
    And I navigate to Pricing Screen
    Then I verify Class Codes on Policy are Valid
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | stateCode | dataFile                                   | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/011_wc_expanded_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/011_wc_expanded_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/011_wc_expanded_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/011_wc_expanded_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/011_wc_expanded_ct.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/011_wc_expanded_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/011_wc_expanded_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/011_wc_expanded_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/011_wc_expanded_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/011_wc_expanded_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/011_wc_expanded_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/011_wc_expanded_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/011_wc_expanded_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/011_wc_expanded_ma.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/011_wc_expanded_md.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/011_wc_expanded_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/011_wc_expanded_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/011_wc_expanded_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/011_wc_expanded_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/011_wc_expanded_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/011_wc_expanded_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/011_wc_expanded_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/011_wc_expanded_nj.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/011_wc_expanded_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/011_wc_expanded_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/011_wc_expanded_ny.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/011_wc_expanded_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/011_wc_expanded_pa.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/011_wc_expanded_ri.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/011_wc_expanded_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/011_wc_expanded_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/011_wc_expanded_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/011_wc_expanded_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/011_wc_expanded_va.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/011_wc_expanded_vt.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/011_wc_expanded_wv.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |

