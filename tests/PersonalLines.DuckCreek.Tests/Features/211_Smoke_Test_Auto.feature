@PL_DC @AUTO @smoke_test @PL_DC_smoke_test @AUTO_smoke_test 

Feature: Smoke Test Auto
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Smoke Test Auto workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Personal Lines Duck Creek for policy processing
	Given I open a browser session
Scenario Outline: Smoke Test Auto - <stateCode> <stateVariant>
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
	| stateCode | dataFile                                             | stateVariant | stateName      | externalDataFile                    |
	| AL        | TestData/Scenarios/211_smoke_test_auto_al.json       | AL           | Alabama        | TestData/ExternalDataOverrides.json |
	| AR        | TestData/Scenarios/211_smoke_test_auto_ar.json       | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Scenarios/211_smoke_test_auto_az_ang.json   | AZ ANG       | Arizona        | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Scenarios/211_smoke_test_auto_az_anp.json   | AZ ANP       | Arizona        | TestData/ExternalDataOverrides.json |
	| CA        | TestData/Scenarios/211_smoke_test_auto_ca.json       | CA           | California     | TestData/ExternalDataOverrides.json |
	| CO        | TestData/Scenarios/211_smoke_test_auto_co.json       | CO           | Colorado       | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Scenarios/211_smoke_test_auto_ct.json       | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Scenarios/211_smoke_test_auto_de.json       | DE           | Delaware       | TestData/ExternalDataOverrides.json |
	| IA        | TestData/Scenarios/211_smoke_test_auto_ia.json       | IA           | Iowa           | TestData/ExternalDataOverrides.json |
	| ID        | TestData/Scenarios/211_smoke_test_auto_id.json       | ID           | Idaho          | TestData/ExternalDataOverrides.json |
	| IL        | TestData/Scenarios/211_smoke_test_auto_il.json       | IL           | Illinois       | TestData/ExternalDataOverrides.json |
	| IN        | TestData/Scenarios/211_smoke_test_auto_in.json       | IN           | Indiana        | TestData/ExternalDataOverrides.json |
	| KS        | TestData/Scenarios/211_smoke_test_auto_ks.json       | KS           | Kansas         | TestData/ExternalDataOverrides.json |
	| KY        | TestData/Scenarios/211_smoke_test_auto_ky.json       | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Scenarios/211_smoke_test_auto_me.json       | ME           | Maine          | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Scenarios/211_smoke_test_auto_md.json       | MD           | Maryland       | TestData/ExternalDataOverrides.json |
	| MN        | TestData/Scenarios/211_smoke_test_auto_mn.json       | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
	| MO        | TestData/Scenarios/211_smoke_test_auto_mo.json       | MO           | Missouri       | TestData/ExternalDataOverrides.json |
	| MS        | TestData/Scenarios/211_smoke_test_auto_ms.json       | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
	| MT        | TestData/Scenarios/211_smoke_test_auto_mt.json       | MT           | Montana        | TestData/ExternalDataOverrides.json |
	| ND        | TestData/Scenarios/211_smoke_test_auto_nd.json       | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
	| NE        | TestData/Scenarios/211_smoke_test_auto_ne.json       | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Scenarios/211_smoke_test_auto_nh.json       | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Scenarios/211_smoke_test_auto_nj.json       | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
	| NM        | TestData/Scenarios/211_smoke_test_auto_nm.json       | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/211_smoke_test_auto_ny_ffcic.json | NY FFCIC     | New York       | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/211_smoke_test_auto_ny_uffic.json | NY UFFIC     | New York       | TestData/ExternalDataOverrides.json |
	| OH        | TestData/Scenarios/211_smoke_test_auto_oh_ang.json   | OH ANG       | Ohio           | TestData/ExternalDataOverrides.json |
	| OH        | TestData/Scenarios/211_smoke_test_auto_oh_anp.json   | OH ANP       | Ohio           | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Scenarios/211_smoke_test_auto_ok_ang.json   | OK ANG       | Oklahoma       | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Scenarios/211_smoke_test_auto_ok_anp.json   | OK ANP       | Oklahoma       | TestData/ExternalDataOverrides.json |
	| OR        | TestData/Scenarios/211_smoke_test_auto_or.json       | OR           | Oregon         | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Scenarios/211_smoke_test_auto_pa.json       | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Scenarios/211_smoke_test_auto_ri.json       | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
	| SC        | TestData/Scenarios/211_smoke_test_auto_sc.json       | SC           | South Carolina | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Scenarios/211_smoke_test_auto_sd_ang.json   | SD ANG       | South Dakota   | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Scenarios/211_smoke_test_auto_sd_anp.json   | SD ANP       | South Dakota   | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Scenarios/211_smoke_test_auto_tn_ang.json   | TN ANG       | Tennessee      | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Scenarios/211_smoke_test_auto_tn_anp.json   | TN ANP       | Tennessee      | TestData/ExternalDataOverrides.json |
	| TX        | TestData/Scenarios/211_smoke_test_auto_tx.json       | TX           | Texas          | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Scenarios/211_smoke_test_auto_ut_ang.json   | UT ANG       | Utah           | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Scenarios/211_smoke_test_auto_ut_anp.json   | UT ANP       | Utah           | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Scenarios/211_smoke_test_auto_va.json       | VA           | Virginia       | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Scenarios/211_smoke_test_auto_vt.json       | VT           | Vermont        | TestData/ExternalDataOverrides.json |
	| WI        | TestData/Scenarios/211_smoke_test_auto_wi.json       | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Scenarios/211_smoke_test_auto_wv.json       | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
	| WY        | TestData/Scenarios/211_smoke_test_auto_wy.json       | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

