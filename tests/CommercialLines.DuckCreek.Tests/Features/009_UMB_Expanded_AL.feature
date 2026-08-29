@CL_DC @UMB @expanded_new_business

Feature: UMB Expanded
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the UMB Expanded workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: UMB Expanded - <stateCode>
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
    And I add Homeowner's Liability Underlying LOB
    And I add Motorcycle Liability Underlying LOB
    And I add Personal Auto Liability Underlying LOB
    And I add Recreational Vehicle Liability Underlying LOB
    And I add Rental Owner's Liability Underlying LOB
    And I add Watercraft Liability Underlying LOB
    And I complete required location information
    And I complete required commercial auto information
    And I complete required general liability information
    And I complete required businessowners information
    And I complete required sfp 10 information
    And I complete required employers liability information
    And I complete required homeowners liability information
    And I complete required motorcycle liability information
    And I complete required personal auto liability information
    And I complete required rental owners liability information
    And I complete required cpp information
    And I complete required watercraft liability information
    And I complete required recreational vehicle information
    And I complete required endorsement information
    And I complete fill in CU2103 if it exists
    And I complete required underwriting question information
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I complete forms verification UMB
    And I sign out of the application

    Examples:
      | dataFile | stateCode | stateVariant | stateName | externalDataFile |
      | TestData/Scenarios/009_umb_expanded_al.json | AL | AL | Alabama | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ar.json | AR | AR | Arkansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_az.json | AZ | AZ | Arizona | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ca.json | CA | CA | California | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_co.json | CO | CO | Colorado | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ct.json | CT | CT | Connecticut | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_de.json | DE | DE | Delaware | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ga.json | GA | GA | Georgia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ia.json | IA | IA | Iowa | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_id.json | ID | ID | Idaho | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_il.json | IL | IL | Illinois | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_in.json | IN | IN | Indiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ks.json | KS | KS | Kansas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ky.json | KY | KY | Kentucky | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_la.json | LA | LA | Louisiana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ma.json | MA | MA | Massachusetts | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_md.json | MD | MD | Maryland | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_me.json | ME | ME | Maine | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_mn.json | MN | MN | Minnesota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_mo.json | MO | MO | Missouri | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ms.json | MS | MS | Mississippi | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_mt.json | MT | MT | Montana | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_nd.json | ND | ND | North Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ne.json | NE | NE | Nebraska | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_nh.json | NH | NH | New Hampshire | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_nj.json | NJ | NJ | New Jersey | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_nm.json | NM | NM | New Mexico | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_nv.json | NV | NV | Nevada | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ny.json | NY | NY | New York | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_oh.json | OH | OH | Ohio | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ok.json | OK | OK | Oklahoma | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_or.json | OR | OR | Oregon | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_pa.json | PA | PA | Pennsylvania | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ri.json | RI | RI | Rhode Island | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_sc.json | SC | SC | South Carolina | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_sd.json | SD | SD | South Dakota | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_tn.json | TN | TN | Tennessee | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_tx.json | TX | TX | Texas | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_ut.json | UT | UT | Utah | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_va.json | VA | VA | Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_vt.json | VT | VT | Vermont | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_wa.json | WA | WA | Washington | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_wi.json | WI | WI | Wisconsin | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_wv.json | WV | WV | West Virginia | TestData/ExternalDataOverrides.json |
      | TestData/Scenarios/009_umb_expanded_wy.json | WY | WY | Wyoming | TestData/ExternalDataOverrides.json |
