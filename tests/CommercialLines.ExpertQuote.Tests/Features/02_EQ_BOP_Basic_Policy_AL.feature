# Source scope: selected Tosca flow only; applicable TemplateInstance/TestSheet iterations = 45
# Framework: KISS business Feature -> StepDefinition -> Page method -> direct Playwright locator
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
    When I enter client search information
    And I create a new client
    And I enter account details
    And I start the policy proposal
    And I enter and validate the insured social security number
    And I navigate to the required policy screen
    And I complete industry Class Code Restrictions
    And I navigate to the required policy screen for screen
    And I enter Required Info
    And I complete general UW Questions
    And I complete industry Class Code Questions
    And I navigate to the required policy screen for navigate to screen
    And I complete edit Client Roles
    And I navigate to the required policy screen for navigate to correct screen
    And I add/Edit a Narrative and Verify Timestamp
    And I navigate to the required policy screen for policy data entry
    And I enter Required
    And I add/Verify/Delete Claims
    And I navigate to the required policy screen for subsequent screen 0143
    And I complete edit a Location
    And I add a Building Button
    And I select Own or rent and Building SQ Footage Basic
    And I select Additional Coverages - Building, Functional Personal Property or Habitational
    And I select Occupancy SQ Footage
    And I enter supplimental data- for class
    And I select Cost Estimator & Calculate Valuations
    And I select Building Detail Fields
    And I select Heating Sources
    And I complete extra Property Risk
    And I answer Building Eligibility Questions
    And I navigate to the required policy screen for subsequent screen 0266
    And I answer EPLI Questions
    And I navigate to the required policy screen for subsequent screen 0285
    And I complete billing Account Setup
    And I complete future Payment Plan 1
    And I complete initial Payment
    And I navigate to the required policy screen for subsequent screen 0310
    And I complete insurance Score and premium Verification
    And I navigate to the required policy screen for subsequent screen 0336
    And I open EQ in Browser
    And I complete restart Edge Popup
    And I open EQ in Browser for logout
    And I sign in to ExpertQuote
    And I search by QuoteNum
    And I search Results Table
    And I open a CLAS Browser and Search for EQ by Description
    And I sign out of the application
    And I open a CLAS Browser and Search for EQ by Description for cl dc
    And I search by Desc in DC
    And I open a CLAS Browser and Search for EQ by Description for view policy
    And I complete forms verification Retrieve QuoteID & SessionID by Browser Console
    And I complete save for Later/Return to Admin
    And I open EQ in Browser for body
    And I complete restart Edge Popup for ok
    And I open EQ in Browser for open eq in browser
    And I sign in to ExpertQuote for username
    And I search by QuoteNum for quotesearchinput
    And I search Results Table for results table
    And I navigate to the required policy screen for subsequent screen 0502
    And I complete checklist and Esign
    And I complete eChecklist - Building Photo1
    And I complete eChecklist - Building Photo2
    And I complete eChecklist - Building Photo3
    And I complete eChecklist - Building Photo4
    And I complete eChecklist - Loss Runs - 3 Years
    And I select OK
    And I navigate to the required policy screen for refer to uw in eq
    And I refer to UW
    And I open a CLAS Browser and Search for EQ by Description for body
    And I sign out of the application for logged in user
    And I open a CLAS Browser and Search for EQ by Description for open a clas browser and search for eq by description
    And I search by Desc in DC for search text
    And I open a CLAS Browser and Search for EQ by Description for verify view policy
    And I navigate to Submission Screen
    And I run Stoplight
    And I refer Application/Policy
    And I complete alert Error Check
    Then I refer Application/Policy for table row cell link
    And I complete save for Later/Return to Admin for save for later
    And I complete retreive Policy Number After Referral
    And I open EQ in Browser for open a browser
    And I complete restart Edge Popup for restart edge popup
    And I open EQ in Browser for check if logout exists
    And I sign in to ExpertQuote for login to eq sso
    And I search by QuoteNum for search by quotenum
    And I navigate to the required policy screen for subsequent screen 0827
    And I transmit to DC
    Then I verify premium on DC
    And I sign in to Duck Creek
    And I complete restart Edge Popup for restart microsoft edge message exists
    Then I sign in to Duck Creek for logged in user
    And I sign out of the application for logout
    And I sign in to Duck Creek for cl dc
    And I perform Quick Search and Open Policy
    And I verify for Policy Packet

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/02_eq_bop_basic_policy_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ca.json | CA | CA | California | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ga.json | GA | GA | Georgia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_la.json | LA | LA | Louisiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_nv.json | NV | NV | Nevada | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_oh.json | OH | OH | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ok.json | OK | OK | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_sd.json | SD | SD | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_tn.json | TN | TN | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_ut.json | UT | UT | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/02_eq_bop_basic_policy_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
