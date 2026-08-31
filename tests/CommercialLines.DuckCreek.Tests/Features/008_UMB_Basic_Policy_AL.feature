@CL_DC @UMB @basic_new_business_policy

Feature: UMB Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the UMB Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: UMB Basic Policy - <stateCode> <stateVariant>
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
    And I complete required policy covg information
    And I add Commercial Auto Underlying LOB
    And I add General Liability Underlying LOB
    And I add Businessowners Underlying LOB
    And I add SFP - 10 Liability Farm Underlying LOB
    And I add Commercial Package Policy Liability Underlying LOB
    And I add Employers Liability Underlying LOB
    And I complete required location information
    And I complete required commercial auto information
    And I complete required general liability information
    And I complete required businessowners information
    And I complete required employers liability information
    And I complete required cpp information
    And I complete required sfp 10 information
    And I complete required endorsement information
    And I complete required underwriting question information
    And I navigate to Pricing Screen
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification UMB
    And I sign out of the application

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/008_umb_basic_policy_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ca.json | CA | CA | California | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ga.json | GA | GA | Georgia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_la.json | LA | LA | Louisiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ma_auto.json | MA | MA Auto | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_nv.json | NV | NV | Nevada | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_oh.json | OH | OH | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ok.json | OK | OK | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_sd.json | SD | SD | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_tn.json | TN | TN | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_ut.json | UT | UT | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/008_umb_basic_policy_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
