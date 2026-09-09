@PL_DC @CYCLE @smoke_test @PL_DC_smoke_test @CYCLE_smoke_test 

Feature: Smoke Test Cycle
  As a Personal Lines Duck Creek policy processing user
  I want to complete the Smoke Test Cycle workflow
  So that the business transaction is executed with maintainable test data and verification

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
	| AL        | TestData/Smoke/AL.json       | AL           | Alabama        | TestData/ExternalDataOverrides.json |
	| AR        | TestData/Smoke/AR.json       | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Smoke/AZ_ANG.json   | AZ ANG       | Arizona        | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Smoke/AZ_ANP.json   | AZ ANP       | Arizona        | TestData/ExternalDataOverrides.json |
	| CA        | TestData/Smoke/CA.json       | CA           | California     | TestData/ExternalDataOverrides.json |
	| CO        | TestData/Smoke/CO.json       | CO           | Colorado       | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Smoke/CT.json       | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Smoke/DE.json       | DE           | Delaware       | TestData/ExternalDataOverrides.json |
	| IA        | TestData/Smoke/IA.json       | IA           | Iowa           | TestData/ExternalDataOverrides.json |
	| ID        | TestData/Smoke/ID.json       | ID           | Idaho          | TestData/ExternalDataOverrides.json |
	| IL        | TestData/Smoke/IL.json       | IL           | Illinois       | TestData/ExternalDataOverrides.json |
	| IN        | TestData/Smoke/IN.json       | IN           | Indiana        | TestData/ExternalDataOverrides.json |
	| KS        | TestData/Smoke/KS.json       | KS           | Kansas         | TestData/ExternalDataOverrides.json |
	| KY        | TestData/Smoke/KY.json       | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Smoke/ME.json       | ME           | Maine          | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Smoke/MD.json       | MD           | Maryland       | TestData/ExternalDataOverrides.json |
	| MN        | TestData/Smoke/MN.json       | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
	| MO        | TestData/Smoke/MO.json       | MO           | Missouri       | TestData/ExternalDataOverrides.json |
	| MS        | TestData/Smoke/MS.json       | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
	| MT        | TestData/Smoke/MT.json       | MT           | Montana        | TestData/ExternalDataOverrides.json |
	| ND        | TestData/Smoke/ND.json       | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
	| NE        | TestData/Smoke/NE.json       | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Smoke/NH.json       | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Smoke/NJ.json       | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
	| NM        | TestData/Smoke/NM.json       | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Smoke/NY_FFCIC.json | NY FFCIC     | New York       | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Smoke/NY_UFFIC.json | NY UFFIC     | New York       | TestData/ExternalDataOverrides.json |
	| OH        | TestData/Smoke/OH_ANG.json   | OH ANG       | Ohio           | TestData/ExternalDataOverrides.json |
	| OH        | TestData/Smoke/OH_ANP.json   | OH ANP       | Ohio           | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Smoke/OK_ANG.json   | OK ANG       | Oklahoma       | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Smoke/OK_ANP.json   | OK ANP       | Oklahoma       | TestData/ExternalDataOverrides.json |
	| OR        | TestData/Smoke/OR.json       | OR           | Oregon         | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Smoke/PA.json       | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Smoke/RI.json       | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
	| SC        | TestData/Smoke/SC.json       | SC           | South Carolina | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Smoke/SD_ANG.json   | SD ANG       | South Dakota   | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Smoke/SD_ANP.json   | SD ANP       | South Dakota   | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Smoke/TN_ANG.json   | TN ANG       | Tennessee      | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Smoke/TN_ANP.json   | TN ANP       | Tennessee      | TestData/ExternalDataOverrides.json |
	| TX        | TestData/Smoke/TX.json       | TX           | Texas          | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Smoke/UT_ANG.json   | UT ANG       | Utah           | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Smoke/UT_ANP.json   | UT ANP       | Utah           | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Smoke/VA.json       | VA           | Virginia       | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Smoke/VT.json       | VT           | Vermont        | TestData/ExternalDataOverrides.json |
	| WI        | TestData/Smoke/WI.json       | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Smoke/WV.json       | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
	| WY        | TestData/Smoke/WY.json       | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

