@CLDC @BAP @regression @full_regression @bap_basic @cldc_basic @basic_new_business_policy

Feature: BAP Basic Regression Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the BAP Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Commercial Lines Duck Creek for policy processing
	Given I open a browser session

Scenario Outline: BAP traced regression lifecycle - <stateCode>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Commercial Lines Duck Creek application
	And I sign in to Commercial Lines Duck Creek using configured credentials
	#And I search for the policy quote  using quick search
	#And I search for the quote description using quick search
	And I start a new quote
	When I enter individual client information
	And I complete required policy information
	And I complete Business Auto policy-specific fields
	And I run insurance score
	And I complete underwriting information from the policy information screen
	And I navigate to policy coverages
	And I complete required location information
	And I navigate to state details
	And I complete vehicle information
	And I complete driver information
	And I complete required endorsement information
	And I add endorsement
	And I complete required additional-interest information
	And I complete required underwriting question information
	And I complete required billing information
	And I add notepad comment
	And I verify premium
	And I complete required submission information
	And I verify values in premium fields


	And I capture the policy effective date
	And I launch to Checklist
	And I click the Refer button
	#And I click the View Policy link and store policy number
	And I click on QA button to logout
   
 
	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I complete required submission information
	And I click the Approve button
	And I click Complete Issuance
	And I click on QA button to logout
	And I sign in to Commercial Lines Duck Creek using configured credentials
	And I search for the quote description using quick search
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Endorse
	And I execute the Duplicate ID regression endorsement updating Risk Schedule for all vehicle with effective date rule <duplicateIdEffDateRule>
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Adjust New Business
	And I select reason as Other and enter details as Test
	And I click Launch Inspire
	And I sign in to Inspire using configured credentials
	And I verify the Confirm Business Owners header is visible
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Endorse
	And I execute the All Other regression endorsement for premium increase with effective date rule <premiumIncreaseEffDateRule>
	And I increase the policy premium by updating liability and medical limits
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Endorse
	And I execute the All Other regression endorsement for premium decrease with effective date rule <premiumDecreaseEffDateRule>
	And I decrease the policy premium by updating liability and medical limits
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Endorse
	And I execute the All Other regression endorsement for premium decrease with reason as Information and effective date rule <premiumDecreaseInfoEffDateRule>
	And I endorse the policy for a mailing-address-only change
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Endorse
	And I execute the All Other regression endorsement for Mailing Address Change Only with effective date rule <mailingAddressEffDateRule>
	And I enter the mailing address as 119 Broadway
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I login with admin and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Renew
	And I click OK if visible
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Adjust Renewal
	And I enter reason as Forms Correction for Adjust Renewal
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout
	

	And I switch to production underwriting and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Endorse
	And I select endorsement reason as All Other with effective date rule <allOtherEffDateRule>
	And I navigate to Policy Coverage and set liability limit as 500,000 and medical limit as 10,000
	And I complete required submission information
	And I click Complete Issuance
	And I click on QA button to logout


	And I login with admin and reopen the policy
	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Cancel
	And I select Cancel reason as Insured's request with effective date rule <cancelEffDateRule>


	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Reinstate
	And I enter reason for reinstatement as SmokeTest Reinstate


	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Cancel
	And I select Cancel reason as Insured's request All Other with effective date rule <cancelAllOtherEffDateRule>


	And I search for the quote description using quick search
	And I select Transaction Type as Reinstate
	And I enter reason for reinstatement as SmokeTest Reinstate


	And I search for the quote description using quick search
	And I select Transaction Type as Cancel
	And I select Cancel reason as Insured's request OOO with effective date rule <cancelOOOEffDateRule>


	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Reinstate
	And I enter reason for reinstatement as SmokeTest Reinstate


	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Cancel
	And I select Cancel reason as Insured's request for policy expiration with effective date <cancelExpirationEffDate>

	And I search for the quote description using quick search
	#And I search for the policy quote  using quick search with policy number <policyNumberRule>
	And I select Transaction Type as Reinstate
	And I enter reason for reinstatement as SmokeTest Reinstate
	And I click on QA button to logout

#	
#	And I sign out when required by the traced regression flow
#
#	Then the traced regression lifecycle is complete

Examples:
	| stateCode | dataFile                                        | stateVariant | stateName      | externalDataFile                    | duplicateIdEffDateRule | premiumIncreaseEffDateRule | premiumDecreaseEffDateRule | premiumDecreaseInfoEffDateRule | mailingAddressEffDateRule | allOtherEffDateRule | cancelEffDateRule | cancelAllOtherEffDateRule | cancelOOOEffDateRule | cancelExpirationEffDate | policyNumberRule |
	| AL        | TestData/Scenarios/001_bap_basic_policy_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json | 01/23/2026             | 02/11/2026                 | 03/11/2026                 | 04/11/2026                     | 05/11/2026                | 05/10/2026          | 05/30/2026        | 05/31/2026                | 05/29/2026           | 06/01/2026              | 4201C2422        |
	| AR        | TestData/Scenarios/001_bap_basic_policy_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| AZ        | TestData/Scenarios/001_bap_basic_policy_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| CT        | TestData/Scenarios/001_bap_basic_policy_ct.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| CO        | TestData/Scenarios/001_bap_basic_policy_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| DE        | TestData/Scenarios/001_bap_basic_policy_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| GA        | TestData/Scenarios/001_bap_basic_policy_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| IA        | TestData/Scenarios/001_bap_basic_policy_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| ID        | TestData/Scenarios/001_bap_basic_policy_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| IL        | TestData/Scenarios/001_bap_basic_policy_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| IN        | TestData/Scenarios/001_bap_basic_policy_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| KS        | TestData/Scenarios/001_bap_basic_policy_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| KY        | TestData/Scenarios/001_bap_basic_policy_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| LA        | TestData/Scenarios/001_bap_basic_policy_la.json | LA           | Louisiana      | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| MD        | TestData/Scenarios/001_bap_basic_policy_md.json | MD           | Maryland       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| ME        | TestData/Scenarios/001_bap_basic_policy_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| MN        | TestData/Scenarios/001_bap_basic_policy_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| MO        | TestData/Scenarios/001_bap_basic_policy_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| MS        | TestData/Scenarios/001_bap_basic_policy_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| MT        | TestData/Scenarios/001_bap_basic_policy_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| ND        | TestData/Scenarios/001_bap_basic_policy_nd.json | ND           | North Dakota   | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| NE        | TestData/Scenarios/001_bap_basic_policy_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| NH        | TestData/Scenarios/001_bap_basic_policy_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| NJ        | TestData/Scenarios/001_bap_basic_policy_nj.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| NM        | TestData/Scenarios/001_bap_basic_policy_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| NV        | TestData/Scenarios/001_bap_basic_policy_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| NY        | TestData/Scenarios/001_bap_basic_policy_ny.json | NY           | New York       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| OH        | TestData/Scenarios/001_bap_basic_policy_oh.json | OH           | Ohio           | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| OK        | TestData/Scenarios/001_bap_basic_policy_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| OR        | TestData/Scenarios/001_bap_basic_policy_or.json | OR           | Oregon         | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| PA        | TestData/Scenarios/001_bap_basic_policy_pa.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| RI        | TestData/Scenarios/001_bap_basic_policy_ri.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| SC        | TestData/Scenarios/001_bap_basic_policy_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| SD        | TestData/Scenarios/001_bap_basic_policy_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| TN        | TestData/Scenarios/001_bap_basic_policy_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| TX        | TestData/Scenarios/001_bap_basic_policy_tx.json | TX           | Texas          | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| UT        | TestData/Scenarios/001_bap_basic_policy_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| VA        | TestData/Scenarios/001_bap_basic_policy_va.json | VA           | Virginia       | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| VT        | TestData/Scenarios/001_bap_basic_policy_vt.json | VT           | Vermont        | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| WA        | TestData/Scenarios/001_bap_basic_policy_wa.json | WA           | Washington     | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| WI        | TestData/Scenarios/001_bap_basic_policy_wi.json | WI           | Wisconsin      | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| WV        | TestData/Scenarios/001_bap_basic_policy_wv.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| WY        | TestData/Scenarios/001_bap_basic_policy_wy.json | WY           | Wyoming        | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |
	| CA        | TestData/Scenarios/001_bap_basic_policy_ca.json | CA           | California     | TestData/ExternalDataOverrides.json | 01/01/2026             | 01/01/2026                 | 01/01/2026                 | 01/01/2026                     | 01/01/2026                | 01/01/2026          | 01/01/2026        | 01/01/2026                | 01/01/2026           | 01/01/2026              | DUMMY1234        |

