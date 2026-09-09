@CL_EQ @BOP @smoke_test @BOP_Smoke_Test @CLEQ_smoke_test

Feature: EQ BOP Smoke Test
  As a Commercial Lines ExpertQuote policy processing user
  I want to complete the EQ BOP Smoke Test workflow
  So that the business transaction is executed with maintainable test data and verification

Background: Prepare Commercial Lines ExpertQuote for policy processing
	Given I open a browser session
Scenario Outline: EQ BOP Smoke Test - <stateCode>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Commercial Lines ExpertQuote application
	And I sign in to Commercial Lines ExpertQuote using configured credentials
	When I create a new client and begin the quote
	And I enter the client account and address information
	And I start the configured policy proposal
	And I enter the insured social security number and handle any prefill result
	And I navigate to the required policy screen
	And I capture the quote identity and close the current quote
	And I retrieve the quote and verify its identity
Examples:
	| stateCode | dataFile                                        | stateVariant | stateName      | externalDataFile                    |
	| AL        | TestData/Smoke/AL.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
      | AR        | TestData/Smoke/AR.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
      | AZ        | TestData/Smoke/AZ.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
      | CA        | TestData/Smoke/CA.json | CA           | California     | TestData/ExternalDataOverrides.json |
      | CO        | TestData/Smoke/CO.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Smoke/CT.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Smoke/DE.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
      | GA        | TestData/Smoke/GA.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
      | IA        | TestData/Smoke/IA.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
      | ID        | TestData/Smoke/ID.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
      | IL        | TestData/Smoke/IL.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
      | IN        | TestData/Smoke/IN.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
      | KS        | TestData/Smoke/KS.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
      | KY        | TestData/Smoke/KY.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
      | LA        | TestData/Smoke/LA.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Smoke/MA.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Smoke/MD.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Smoke/ME.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
      | MN        | TestData/Smoke/MN.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
      | MO        | TestData/Smoke/MO.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
      | MS        | TestData/Smoke/MS.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
      | MT        | TestData/Smoke/MT.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
      | ND        | TestData/Smoke/ND.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json |
      | NE        | TestData/Smoke/NE.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Smoke/NH.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Smoke/NJ.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
      | NM        | TestData/Smoke/NM.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
      | NV        | TestData/Smoke/NV.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Smoke/NY.json | NY           | New York       | TestData/ExternalDataOverrides.json |
      | OH        | TestData/Smoke/OH.json | OH           | Ohio           | TestData/ExternalDataOverrides.json |
      | OK        | TestData/Smoke/OK.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Smoke/OR.json | OR           | Oregon         | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Smoke/PA.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Smoke/RI.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
      | SC        | TestData/Smoke/SC.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
      | SD        | TestData/Smoke/SD.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
      | TN        | TestData/Smoke/TN.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
      | TX        | TestData/Smoke/TX.json | TX           | Texas          | TestData/ExternalDataOverrides.json |
      | UT        | TestData/Smoke/UT.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Smoke/VA.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Smoke/VT.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Smoke/WA.json | WA           | Washington     | TestData/ExternalDataOverrides.json |
      | WI        | TestData/Smoke/WI.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Smoke/WV.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |
      | WY        | TestData/Smoke/WY.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json |

