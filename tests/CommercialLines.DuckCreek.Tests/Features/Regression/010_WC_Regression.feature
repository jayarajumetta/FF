@CLDC @WC @regression @full_regression @wc_basic @cldc_basic @basic_new_business_policy

Feature: WC Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the WC Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Commercial Lines Duck Creek for policy processing
	Given I open a browser session

Scenario Outline: WC traced regression lifecycle - <stateCode>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Commercial Lines Duck Creek application
	And I sign in to Commercial Lines Duck Creek using configured credentials
	And I start a new quote
	And I enter business client information
	And I add a new Associated Client - Business Owner Type - Click Add Client
    ##And I complete aJAX Error Check
    ##And I complete required billing information
	And I complete the Associated Client Info
	And I navigate to Underwriting Info Screen
	And I complete required policy information
	And I complete WC Specific Fields
	Then I complete Estimated premium
	And I complete coverage Information
	And I complete Address 1
	And I complete rating Information
	And I add Class Codes
	And I navigate to Entity Schedule
	And I complete endorsements
	And I complete WC UW Questions
	And I navigate to Pricing Screen
	And I verify Class Codes on Policy are Valid
	And I verify premium
	And I complete required billing information for billing
	And I add notepad comment
	And I complete required submission information
	And I run Stoplight
	And I verify values in premium fields
    #And I complete forms verification
    #And I sign out of the application

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


	When I switch to production underwriting and reopen the policy
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
	| stateCode | dataFile                                             | stateVariant | stateName      | externalDataFile                    |
	| AL        | TestData/Scenarios/Basic/010_wc_basic_policy_al.json | AL           | Alabama        | TestData/ExternalDataOverrides.json |
	| AR        | TestData/Scenarios/Basic/010_wc_basic_policy_ar.json | AR           | Arkansas       | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Scenarios/Basic/010_wc_basic_policy_az.json | AZ           | Arizona        | TestData/ExternalDataOverrides.json |
	| CO        | TestData/Scenarios/Basic/010_wc_basic_policy_co.json | CO           | Colorado       | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Scenarios/Basic/010_wc_basic_policy_ct.json | CT           | Connecticut    | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Scenarios/Basic/010_wc_basic_policy_de.json | DE           | Delaware       | TestData/ExternalDataOverrides.json |
	| GA        | TestData/Scenarios/Basic/010_wc_basic_policy_ga.json | GA           | Georgia        | TestData/ExternalDataOverrides.json |
	| IA        | TestData/Scenarios/Basic/010_wc_basic_policy_ia.json | IA           | Iowa           | TestData/ExternalDataOverrides.json |
	| ID        | TestData/Scenarios/Basic/010_wc_basic_policy_id.json | ID           | Idaho          | TestData/ExternalDataOverrides.json |
	| IL        | TestData/Scenarios/Basic/010_wc_basic_policy_il.json | IL           | Illinois       | TestData/ExternalDataOverrides.json |
	| IN        | TestData/Scenarios/Basic/010_wc_basic_policy_in.json | IN           | Indiana        | TestData/ExternalDataOverrides.json |
	| KS        | TestData/Scenarios/Basic/010_wc_basic_policy_ks.json | KS           | Kansas         | TestData/ExternalDataOverrides.json |
	| KY        | TestData/Scenarios/Basic/010_wc_basic_policy_ky.json | KY           | Kentucky       | TestData/ExternalDataOverrides.json |
	| MA        | TestData/Scenarios/Basic/010_wc_basic_policy_ma.json | MA           | Massachusetts  | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Scenarios/Basic/010_wc_basic_policy_md.json | MD           | Maryland       | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Scenarios/Basic/010_wc_basic_policy_me.json | ME           | Maine          | TestData/ExternalDataOverrides.json |
	| MN        | TestData/Scenarios/Basic/010_wc_basic_policy_mn.json | MN           | Minnesota      | TestData/ExternalDataOverrides.json |
	| MO        | TestData/Scenarios/Basic/010_wc_basic_policy_mo.json | MO           | Missouri       | TestData/ExternalDataOverrides.json |
	| MS        | TestData/Scenarios/Basic/010_wc_basic_policy_ms.json | MS           | Mississippi    | TestData/ExternalDataOverrides.json |
	| MT        | TestData/Scenarios/Basic/010_wc_basic_policy_mt.json | MT           | Montana        | TestData/ExternalDataOverrides.json |
	| NE        | TestData/Scenarios/Basic/010_wc_basic_policy_ne.json | NE           | Nebraska       | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Scenarios/Basic/010_wc_basic_policy_nh.json | NH           | New Hampshire  | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Scenarios/Basic/010_wc_basic_policy_nj.json | NJ           | New Jersey     | TestData/ExternalDataOverrides.json |
	| NM        | TestData/Scenarios/Basic/010_wc_basic_policy_nm.json | NM           | New Mexico     | TestData/ExternalDataOverrides.json |
	| NV        | TestData/Scenarios/Basic/010_wc_basic_policy_nv.json | NV           | Nevada         | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/Basic/010_wc_basic_policy_ny.json | NY           | New York       | TestData/ExternalDataOverrides.json |
	| OK        | TestData/Scenarios/Basic/010_wc_basic_policy_ok.json | OK           | Oklahoma       | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Scenarios/Basic/010_wc_basic_policy_pa.json | PA           | Pennsylvania   | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Scenarios/Basic/010_wc_basic_policy_ri.json | RI           | Rhode Island   | TestData/ExternalDataOverrides.json |
	| SC        | TestData/Scenarios/Basic/010_wc_basic_policy_sc.json | SC           | South Carolina | TestData/ExternalDataOverrides.json |
	| SD        | TestData/Scenarios/Basic/010_wc_basic_policy_sd.json | SD           | South Dakota   | TestData/ExternalDataOverrides.json |
	| TN        | TestData/Scenarios/Basic/010_wc_basic_policy_tn.json | TN           | Tennessee      | TestData/ExternalDataOverrides.json |
	| UT        | TestData/Scenarios/Basic/010_wc_basic_policy_ut.json | UT           | Utah           | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Scenarios/Basic/010_wc_basic_policy_va.json | VA           | Virginia       | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Scenarios/Basic/010_wc_basic_policy_vt.json | VT           | Vermont        | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Scenarios/Basic/010_wc_basic_policy_wv.json | WV           | West Virginia  | TestData/ExternalDataOverrides.json |

