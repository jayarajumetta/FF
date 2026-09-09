@CL_EQ @BOP @basic_new_business_policy

Feature: EQ BOP Basic Policy
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ BOP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Commercial Lines ExpertQuote for policy processing
	Given I open a browser session
Scenario Outline: EQ BOP Basic Policy - <stateCode>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Commercial Lines ExpertQuote application
	And I sign in to Commercial Lines ExpertQuote using configured credentials
	When I create a new client and begin the quote
	And I enter client search information
	And I create a new client
	And I enter account details
	And I start the policy proposal
	And I enter and validate the insured social security number
	And I search and add a Class Code to the policy
	And I complete industry Class Code Restrictions
	And I confirm Primary Insured Details and select existing client
	And I enter Required Info
	And I complete general UW Questions
	And I complete industry Class Code Questions
	And I navigate to Claims/Prior Insurance screen
	And I complete Claims/Prior Insurance Screen
	And I complete Client Details and navigate to Narrative screen
	And I add/Edit a Narrative and Verify Timestamp
	And I navigate to Locations/Buildings screen
	And I complete edit a Location
    And I add a Building Button
    And I select Own or rent and Building SQ Footage Basic
    And I select Additional Coverages - Building, Functional Personal Property or Habitational
    And I enter supplimental data- for class
    And I select Cost Estimator & Calculate Valuations
    And I select Building Detail Fields
    And I answer Building Eligibility Questions
    And I navigate to Policy Coverages screen
    And I navigate to Additional Coverages screen
    And I answer EPLI Questions
    And I navigate to Billing screen
    And I complete billing Account Setup
    And I complete future Payment Plan 1
    And I complete initial Payment
    And I complete Agent Comments
    And I launch to Checklist
    And I click Refer to UW
    And I capture the quote identity and close the current quote
    Given I open the configured Commercial Lines Duck Creek application
    Given I sign in to Commercial Lines Duck Creek using configured credentials
    And I search for the policy by Description in Duck Creek
    And I click the insured name in the Duck Creek search results
    And I navigate to the Submission window in Duck Creek
    And I click Complete Application in Duck Creek
	And I open the configured Commercial Lines ExpertQuote application
	And I sign in to Commercial Lines ExpertQuote using configured credentials
	And I retrieve the quote and verify its identity
	Then I go to submission and transmit the policy

Examples:
	| dataFile                                          | stateCode | stateVariant | stateName      | externalDataFile                    |
	| TestData/Scenarios/02_eq_bop_basic_policy_al.json | AL        | AL           | Alabama        | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ar.json | AR        | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_az.json | AZ        | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ca.json | CA        | CA           | California     | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_co.json | CO        | CO           | Colorado       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ct.json | CT        | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_de.json | DE        | DE           | Delaware       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ga.json | GA        | GA           | Georgia        | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ia.json | IA        | IA           | Iowa           | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_id.json | ID        | ID           | Idaho          | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_il.json | IL        | IL           | Illinois       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_in.json | IN        | IN           | Indiana        | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ks.json | KS        | KS           | Kansas         | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ky.json | KY        | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_la.json | LA        | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ma.json | MA        | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_md.json | MD        | MD           | Maryland       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_me.json | ME        | ME           | Maine          | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_mn.json | MN        | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_mo.json | MO        | MO           | Missouri       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ms.json | MS        | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_mt.json | MT        | MT           | Montana        | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_nd.json | ND        | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ne.json | NE        | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_nh.json | NH        | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_nj.json | NJ        | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_nm.json | NM        | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_nv.json | NV        | NV           | Nevada         | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ny.json | NY        | NY           | New York       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_oh.json | OH        | OH           | Ohio           | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ok.json | OK        | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_or.json | OR        | OR           | Oregon         | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_pa.json | PA        | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ri.json | RI        | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_sc.json | SC        | SC           | South Carolina | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_sd.json | SD        | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_tn.json | TN        | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_tx.json | TX        | TX           | Texas          | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_ut.json | UT        | UT           | Utah           | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_va.json | VA        | VA           | Virginia       | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_vt.json | VT        | VT           | Vermont        | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_wa.json | WA        | WA           | Washington     | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_wi.json | WI        | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_wv.json | WV        | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
	| TestData/Scenarios/02_eq_bop_basic_policy_wy.json | WY        | WY           | Wyoming        | TestData/ExternalDataOverrides.json |
