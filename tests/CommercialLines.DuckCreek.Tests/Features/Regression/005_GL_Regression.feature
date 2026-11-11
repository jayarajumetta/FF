@CLDC @GL @regression @full_regression @gl_basic @cldc_basic @basic_new_business_policy

Feature: GL Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

Background: Prepare Commercial Lines Duck Creek for policy processing
	Given I open a browser session
Scenario Outline: GL traced regression lifecycle - <stateCode>
	Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
	And I open the configured Commercial Lines Duck Creek application
	And I sign in to Commercial Lines Duck Creek using configured credentials
	And I start a new quote
	When I enter individual client information
	And I complete Underwriting Info from Client Screen
	And I complete required policy information
	And I complete CGL Fields
	And I add Class
	And I add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations)
	And I add [CG0435] Employee Benefits Liability Endorsement
	And I add [CG 2149] Total Pollution Exclusion Endorsement

	And I add [CG2151] Amendment Of Liquor Liability Exclusion - Exception For Scheduled Activities
	And I verify and Fill out [FG0055] Employment Practices Liability Insurance Coverage Endorsement
	And I add Addl Interest [CG2007] - Engineers
	And I add Addl Interest [CG2020] Add'l Insured-Charitable Institution
	And I add Addl Interest [CG2023] Add'l Insured-Executors
	And I add Addl Interest [CG2025] Add'l Insured-Executive Officers
	And I add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic
	And I add notepad comment
	#And I switch to UW Director for OR and WA when required
	And I answer GL UW Questions OR & WA
	And I complete required billing information
	And I complete required submission information
    #And I switch back to Agent for OR and WA when required
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
	| stateCode | dataFile                                             | stateVariant | stateName     | externalDataFile                    |
	| MA        | TestData/Scenarios/Basic/005_gl_basic_policy_ma.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
	| NH        | TestData/Scenarios/Basic/005_gl_basic_policy_nh.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
	| NY        | TestData/Scenarios/Basic/005_gl_basic_policy_ny.json | NY           | New York      | TestData/ExternalDataOverrides.json |
	| VA        | TestData/Scenarios/Basic/005_gl_basic_policy_va.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
	| CT        | TestData/Scenarios/Basic/005_gl_basic_policy_ct.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
	| AZ        | TestData/Scenarios/Basic/005_gl_basic_policy_az.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
	| DE        | TestData/Scenarios/Basic/005_gl_basic_policy_de.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
	| MD        | TestData/Scenarios/Basic/005_gl_basic_policy_md.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
	| ME        | TestData/Scenarios/Basic/005_gl_basic_policy_me.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
	| NJ        | TestData/Scenarios/Basic/005_gl_basic_policy_nj.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
	| OR        | TestData/Scenarios/Basic/005_gl_basic_policy_or.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
	| PA        | TestData/Scenarios/Basic/005_gl_basic_policy_pa.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
	| RI        | TestData/Scenarios/Basic/005_gl_basic_policy_ri.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
	| VT        | TestData/Scenarios/Basic/005_gl_basic_policy_vt.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
	| WA        | TestData/Scenarios/Basic/005_gl_basic_policy_wa.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
	| WV        | TestData/Scenarios/Basic/005_gl_basic_policy_wv.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |
