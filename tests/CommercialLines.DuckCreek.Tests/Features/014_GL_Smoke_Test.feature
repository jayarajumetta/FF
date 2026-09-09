@CLDC @CLDC_smoke_test @smoke_test @GL @GL_smoke

Feature: GL Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL Smoke Test workflow
  So that the business transaction is executed with maintainable test data and verification

Background: Prepare Commercial Lines Duck Creek for policy processing
	Given I open a browser session
Scenario Outline: GL Smoke Test - <stateCode>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Commercial Lines Duck Creek application
	And I sign in to Commercial Lines Duck Creek using configured credentials
	And I start a new quote
	And I enter individual client information
	And I complete required policy information
	And I navigate to Policy Info and Verify Desc

Examples:
	| stateCode | dataFile                                     | stateVariant | stateName     | externalDataFile                    |
	| AZ        | TestData/Smoke/AZ.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Smoke/CT.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Smoke/DE.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
	| MA        | TestData/Smoke/MA.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Smoke/MD.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Smoke/ME.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Smoke/NH.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Smoke/NJ.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Smoke/NY.json | NY           | New York      | TestData/ExternalDataOverrides.json |
	| OR        | TestData/Smoke/OR.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Smoke/PA.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Smoke/RI.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Smoke/VA.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Smoke/VT.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
	| WA        | TestData/Smoke/WA.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Smoke/WV.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |
