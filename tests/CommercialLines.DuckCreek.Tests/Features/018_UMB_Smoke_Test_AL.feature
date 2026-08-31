@CL_DC @UMB @smoke_test

Feature: UMB Smoke Test
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the UMB Smoke Test workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Commercial Lines Duck Creek for policy processing
	Given I open a browser session
Scenario Outline: UMB Smoke Test - <stateCode>
	Given CLDC smoke data "UMB" for state "<stateCode>" named "<stateName>" are loaded
	And I open the configured Commercial Lines Duck Creek application
	And I sign in to Commercial Lines Duck Creek using configured credentials
	And I start a new quote
	And I enter individual client information
	And I complete required policy information
	And I navigate to Policy Info and Verify Desc

Examples:
	| stateCode | stateName      |
	| AL        | Alabama        |
	#| AR        | Arkansas       |
	#| AZ        | Arizona        |
	#| CA        | California     |
	#| CT        | Connecticut    |
	#| CO        | Colorado       |
	#| DE        | Delaware       |
	#| GA        | Georgia        |
	#| IA        | Iowa           |
	#| ID        | Idaho          |
	#| IL        | Illinois       |
	#| IN        | Indiana        |
	#| KS        | Kansas         |
	#| KY        | Kentucky       |
	#| LA        | Louisiana      |
	#| MD        | Maryland       |
	#| ME        | Maine          |
	#| MN        | Minnesota      |
	#| MO        | Missouri       |
	#| MS        | Mississippi    |
	#| MT        | Montana        |
	#| ND        | North Dakota   |
	#| NE        | Nebraska       |
	#| NH        | New Hampshire  |
	#| NJ        | New Jersey     |
	#| NM        | New Mexico     |
	#| NV        | Nevada         |
	#| NY        | New York       |
	#| OH        | Ohio           |
	#| OK        | Oklahoma       |
	#| OR        | Oregon         |
	#| PA        | Pennsylvania   |
	#| RI        | Rhode Island   |
	#| SC        | South Carolina |
	#| SD        | South Dakota   |
	#| TN        | Tennessee      |
	#| TX        | Texas          |
	#| UT        | Utah           |
	#| VA        | Virginia       |
	#| VT        | Vermont        |
	#| WA        | Washington     |
	#| WI        | Wisconsin      |
	#| WV        | West Virginia  |
	#| WY        | Wyoming        |
