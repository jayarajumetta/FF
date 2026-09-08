@CLDC @CLDC_smoke_test @smoke_test @GL @GL_smoke

Feature: GL Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

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
	| AZ        | TestData/Scenarios/014_gl_smoke_test_az.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Scenarios/014_gl_smoke_test_ct.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Scenarios/014_gl_smoke_test_de.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
	| MA        | TestData/Scenarios/014_gl_smoke_test_ma.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Scenarios/014_gl_smoke_test_md.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Scenarios/014_gl_smoke_test_me.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Scenarios/014_gl_smoke_test_nh.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Scenarios/014_gl_smoke_test_nj.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/014_gl_smoke_test_ny.json | NY           | New York      | TestData/ExternalDataOverrides.json |
	| OR        | TestData/Scenarios/014_gl_smoke_test_or.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Scenarios/014_gl_smoke_test_pa.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Scenarios/014_gl_smoke_test_ri.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Scenarios/014_gl_smoke_test_va.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Scenarios/014_gl_smoke_test_vt.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
	| WA        | TestData/Scenarios/014_gl_smoke_test_wa.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Scenarios/014_gl_smoke_test_wv.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |
