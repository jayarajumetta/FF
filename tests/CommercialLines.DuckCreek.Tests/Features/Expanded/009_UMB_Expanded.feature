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
    And I start a new quote
    When I enter business client information
    And I add a new Associated Client - Business Owner Type - Click Add Client
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
    #And I complete fill in CU2103 if it exists- condition disabled in Tosca
    And I complete required underwriting question information
    And I complete required billing information for billing
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    #And I complete forms verification UMB
    #And I sign out of the application

    Examples:
      | stateCode | dataFile                                    | stateVariant | stateName      | externalDataFile                    |
      | AL        | TestData/Scenarios/Expanded/009_umb_expanded_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Scenarios/Expanded/009_umb_expanded_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Scenarios/Expanded/009_umb_expanded_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Scenarios/Expanded/009_umb_expanded_ca.json | CA           | California     | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Scenarios/Expanded/009_umb_expanded_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/Expanded/009_umb_expanded_ct.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/Expanded/009_umb_expanded_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Scenarios/Expanded/009_umb_expanded_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Scenarios/Expanded/009_umb_expanded_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Scenarios/Expanded/009_umb_expanded_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Scenarios/Expanded/009_umb_expanded_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Scenarios/Expanded/009_umb_expanded_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Scenarios/Expanded/009_umb_expanded_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Scenarios/Expanded/009_umb_expanded_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Scenarios/Expanded/009_umb_expanded_la.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/Expanded/009_umb_expanded_ma.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/Expanded/009_umb_expanded_md.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/Expanded/009_umb_expanded_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Scenarios/Expanded/009_umb_expanded_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Scenarios/Expanded/009_umb_expanded_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Scenarios/Expanded/009_umb_expanded_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Scenarios/Expanded/009_umb_expanded_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Scenarios/Expanded/009_umb_expanded_nd.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Scenarios/Expanded/009_umb_expanded_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/Expanded/009_umb_expanded_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/Expanded/009_umb_expanded_nj.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Scenarios/Expanded/009_umb_expanded_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Scenarios/Expanded/009_umb_expanded_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/Expanded/009_umb_expanded_ny.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Scenarios/Expanded/009_umb_expanded_oh.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Scenarios/Expanded/009_umb_expanded_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/Expanded/009_umb_expanded_or.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/Expanded/009_umb_expanded_pa.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/Expanded/009_umb_expanded_ri.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Scenarios/Expanded/009_umb_expanded_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Scenarios/Expanded/009_umb_expanded_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Scenarios/Expanded/009_umb_expanded_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Scenarios/Expanded/009_umb_expanded_tx.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Scenarios/Expanded/009_umb_expanded_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/Expanded/009_umb_expanded_va.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/Expanded/009_umb_expanded_vt.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/Expanded/009_umb_expanded_wa.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Scenarios/Expanded/009_umb_expanded_wi.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/Expanded/009_umb_expanded_wv.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Scenarios/Expanded/009_umb_expanded_wy.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

