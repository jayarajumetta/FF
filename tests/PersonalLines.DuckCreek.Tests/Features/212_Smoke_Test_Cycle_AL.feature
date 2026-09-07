@PL_DC @CYCLE @smoke_test @PL_DC_smoke_test @CYCLE_smoke_test 

Feature: Smoke Test Cycle
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Smoke Test Cycle workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Personal Lines Duck Creek for policy processing
	Given I open a browser session
Scenario Outline: Smoke Test Cycle - <stateCode> <stateVariant>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Personal Lines Duck Creek application
	And I sign in to Personal Lines Duck Creek using configured credentials
	When I start New Quote
	And I select or create the policy client
	And I enter account details
	And I start the policy proposal
	And I capture the proposal number
	And I complete tabs

Examples:
	| stateCode | dataFile                                              | stateVariant | stateName      | externalDataFile                    |
	| AL        | TestData/Scenarios/212_smoke_test_cycle_al.json       | AL           | Alabama        | TestData/ExternalDataOverrides.json |
	| AR        | TestData/Scenarios/212_smoke_test_cycle_ar.json       | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Scenarios/212_smoke_test_cycle_az_ang.json   | AZ ANG       | Arizona        | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Scenarios/212_smoke_test_cycle_az_anp.json   | AZ ANP       | Arizona        | TestData/ExternalDataOverrides.json |
	| CA        | TestData/Scenarios/212_smoke_test_cycle_ca.json       | CA           | California     | TestData/ExternalDataOverrides.json |
	| CO        | TestData/Scenarios/212_smoke_test_cycle_co.json       | CO           | Colorado       | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Scenarios/212_smoke_test_cycle_ct.json       | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Scenarios/212_smoke_test_cycle_de.json       | DE           | Delaware       | TestData/ExternalDataOverrides.json |
	| IA        | TestData/Scenarios/212_smoke_test_cycle_ia.json       | IA           | Iowa           | TestData/ExternalDataOverrides.json |
	| ID        | TestData/Scenarios/212_smoke_test_cycle_id.json       | ID           | Idaho          | TestData/ExternalDataOverrides.json |
	| IL        | TestData/Scenarios/212_smoke_test_cycle_il.json       | IL           | Illinois       | TestData/ExternalDataOverrides.json |
	| IN        | TestData/Scenarios/212_smoke_test_cycle_in.json       | IN           | Indiana        | TestData/ExternalDataOverrides.json |
	| KS        | TestData/Scenarios/212_smoke_test_cycle_ks.json       | KS           | Kansas         | TestData/ExternalDataOverrides.json |
	| KY        | TestData/Scenarios/212_smoke_test_cycle_ky.json       | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Scenarios/212_smoke_test_cycle_me.json       | ME           | Maine          | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Scenarios/212_smoke_test_cycle_md.json       | MD           | Maryland       | TestData/ExternalDataOverrides.json |
	| MN        | TestData/Scenarios/212_smoke_test_cycle_mn.json       | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
	| MO        | TestData/Scenarios/212_smoke_test_cycle_mo.json       | MO           | Missouri       | TestData/ExternalDataOverrides.json |
	| MS        | TestData/Scenarios/212_smoke_test_cycle_ms.json       | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
	| MT        | TestData/Scenarios/212_smoke_test_cycle_mt.json       | MT           | Montana        | TestData/ExternalDataOverrides.json |
	| ND        | TestData/Scenarios/212_smoke_test_cycle_nd.json       | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
	| NE        | TestData/Scenarios/212_smoke_test_cycle_ne.json       | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Scenarios/212_smoke_test_cycle_nh.json       | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Scenarios/212_smoke_test_cycle_nj.json       | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
	| NM        | TestData/Scenarios/212_smoke_test_cycle_nm.json       | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/212_smoke_test_cycle_ny_ffcic.json | NY FFCIC     | New York       | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/212_smoke_test_cycle_ny_uffic.json | NY UFFIC     | New York       | TestData/ExternalDataOverrides.json |
	| OH        | TestData/Scenarios/212_smoke_test_cycle_oh_ang.json   | OH ANG       | Ohio           | TestData/ExternalDataOverrides.json |
	| OH        | TestData/Scenarios/212_smoke_test_cycle_oh_anp.json   | OH ANP       | Ohio           | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Scenarios/212_smoke_test_cycle_ok_ang.json   | OK ANG       | Oklahoma       | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Scenarios/212_smoke_test_cycle_ok_anp.json   | OK ANP       | Oklahoma       | TestData/ExternalDataOverrides.json |
	| OR        | TestData/Scenarios/212_smoke_test_cycle_or.json       | OR           | Oregon         | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Scenarios/212_smoke_test_cycle_pa.json       | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Scenarios/212_smoke_test_cycle_ri.json       | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
	| SC        | TestData/Scenarios/212_smoke_test_cycle_sc.json       | SC           | South Carolina | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Scenarios/212_smoke_test_cycle_sd_ang.json   | SD ANG       | South Dakota   | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Scenarios/212_smoke_test_cycle_sd_anp.json   | SD ANP       | South Dakota   | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Scenarios/212_smoke_test_cycle_tn_ang.json   | TN ANG       | Tennessee      | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Scenarios/212_smoke_test_cycle_tn_anp.json   | TN ANP       | Tennessee      | TestData/ExternalDataOverrides.json |
	| TX        | TestData/Scenarios/212_smoke_test_cycle_tx.json       | TX           | Texas          | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Scenarios/212_smoke_test_cycle_ut_ang.json   | UT ANG       | Utah           | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Scenarios/212_smoke_test_cycle_ut_anp.json   | UT ANP       | Utah           | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Scenarios/212_smoke_test_cycle_va.json       | VA           | Virginia       | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Scenarios/212_smoke_test_cycle_vt.json       | VT           | Vermont        | TestData/ExternalDataOverrides.json |
	| WI        | TestData/Scenarios/212_smoke_test_cycle_wi.json       | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Scenarios/212_smoke_test_cycle_wv.json       | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
	| WY        | TestData/Scenarios/212_smoke_test_cycle_wy.json       | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

