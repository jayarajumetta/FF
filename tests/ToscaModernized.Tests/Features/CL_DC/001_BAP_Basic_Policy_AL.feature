# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 001_BAP_Basic_Policy_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @BAP @basic_policy @Alabama @Edge @manual @automated
Feature: Execute BAP | Basic Policy for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the BAP | Basic Policy workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: BAP | Basic Policy using representative iteration Alabama (AL)

    # Source step 0037: Uncheck Quick Quote | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-477c-510c-7ad43036cba4
    When I enter or select "False" in "Quick Quote"

    # Source step 0038: Wait on non-quick quote element | Module: Common Navigation Links
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3cbc-4aa7-a1c7b75ee619
    Then I wait until "Underwriting Info" exists

    # Source step 0039: Select Individual Insured | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-8c16-d826-567aed4c90ca
    When I enter or select "Individual/Person{ENTER}{TAB}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0040: Enter Name and DOB | Module: Client|Named Insured|Individual
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3ecf-8633-002f64245127
    Then I wait until "First Name" is visible
    When I enter or select "{TAB}{TAB}" in "First Name"
    When I enter or select "{CLICK}John{TAB}{TAB}" in "First Name"
    When I enter or select "AL{TAB}{TAB}" in "Middle Name"
    When I enter or select "{TAB}{TAB}" in "Last Name"
    When I enter RUNTIME-DERIVED value "{DATE[][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "DOB"
    When if field condition "State!=\"CA\"" is satisfied, I enter or select "Male{TAB}{TAB}" in "Gender"
    When I enter a RANDOM value matching "^[a-z]{4}$" in "Last Name"

    # Source step 0041: Select Individual Sole Proprietor | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-f281-684f-979ca5404005
    When I enter or select "Individual/Sole Proprietor{ENTER}{TAB}{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I enter or select "{TAB}103 Student Dr{TAB}" in "Address1"
    When I enter or select "{TAB}35662{TAB}" in "ZipCode"

    # Source step 0042: Click Client search | Module: Client|Named Insured|Individual
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-7952-2e48-6b516ae5679d
    When I click or select "Client Search"

    # Source step 0043: Client Search Results | Module: Client Search Results
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-62f0-721e-d093b870cfd8
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0044: Enter SSN | Module: Client|Named Insured|Individual
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3868-3c34-dfdde15584ab
    Then I wait until "Order SSN" exists
    When I click or select "Order SSN"
    Then I wait until "Enter SSN" exists
    When I perform keyboard action "{TAB}" on "Enter SSN"
    When I enter a RANDOM value matching "6 random digits/characters from source expression 125{RND[6]}{TAB}" in "Enter SSN"
    When I capture "Enter SSN" as runtime value "SSN"
    When I enter or select "{Doubleclick}{TAB}" in "Enter SSN"
    When I click or select "Verify"
    Then I wait until "Verify" no longer exists

    # Source step 0045: Partial Buffer the Last Four of SSN | Module: TBox Partial Buffer
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-cb58-ee90-632993a50481
    When I perform the source-defined partial-buffer operation "Partial Buffer the Last Four of SSN" using "Buffer=Last4SSN; Value={B[SSN]}; Start=6"

    # Source step 0046: Wait for SSN mask | Module: Client|Named Insured|Individual
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-eddc-3263-04e8ba1848e0
    Then I wait until "Social Security # " property "InnerText" equals "XXX-XX-*"

    # Source step 0047: Validate SSN | Module: Client|Named Insured|Individual
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-a17a-f6cd-1482be959af6
    Then "Social Security # " property "InnerText" should equals "XXX-XX-{B[Last4SSN]}"
    Then I wait until "Please verify SSN*" no longer exists

    # Source step 0048: Enter other insured info | Module: Client|Other Insured Info
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-1cd6-971b-633af7644e81
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}{CLICK}Auditor Doe{TAB}{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0049: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-6c12-f22a-3d3cfbcf2bb3
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0050: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: Policy Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-b042-25d6-3bc4136f8a02
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "BAP" as runtime value "Product (LOB)"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"
    When I retain hard-coded value "BAP_BASIC" as runtime value "FormOnPolicyDocName"

    # Source step 0051: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0052: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0053: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0054: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0055: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "09-05-2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0056: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0057: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0058: State is Kansas | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0059: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
    # Runtime control: If State is Kansas > Then
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "(select){ENTER}{TAB}{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0060: State is Virginia | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0061: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
    # Runtime control: If State is Virginia > Then
    When if field condition "'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0062: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0063: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0064: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0065: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL BAP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0068: Loop if OK button does not exist | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d421a-6706-8f18-ed07-8d5243080055
    # Runtime control: Do (Enter NAICS Code) [max=15] > Condition
    Then "OK" should not exist

    # Source step 0069: Enter NAICS Code | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d66-7338-0748-26cd8498b8ba
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I enter or select "{CLICK}CONSTRUCTION SAND AND GRAVEL MINING [212321]{TAB}{TAB}" in "NAICS Code Search Value*"

    # Source step 0070: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d68-fe85-e69f-3e66e032d667
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I wait "1000" milliseconds

    # Source step 0071: Enter NAICS Code | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d71-17dc-60e7-31193c7fbf26
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I enter or select "{CLICK}Construction Sand and Gravel Mining [212321]{TAB}{TAB}" in "NAICS Code Search Results*"

    # Source step 0072: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d74-51ec-c251-d5ca81666155
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I wait "1000" milliseconds

    # Source step 0073: Enter Account Credit | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-f3bb-6129-72b0-6a45a877373e
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    # Step condition: State != "NY"
    When if field condition "State != \"NY\"" is satisfied, I enter or select "No{TAB}{TAB}" in "Account Credit"

    # Source step 0074: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d421a-1bb8-8d9b-f9e4-968bde11e68f
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I wait "1000" milliseconds

    # Source step 0075: Click OK | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d421b-92a3-b6fe-f155-0ed531969933
    Then I wait until "OK" exists
    When I click or select "OK"
    Then I wait until "OK" no longer exists

    # Source step 0076: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-db96-2f0e-1e230bb9a656
    When I wait "1500" milliseconds

    # Source step 0077: Insurance Score | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-84af-bc6a-3f9f6e937252
    # Runtime control: Do [max=120] > Condition
    Then "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS" should exist

    # Source step 0078: Check if it is BAP VT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-faf3-28ce-cca724db461f
    # Runtime control: Do [max=120] > Loop > If BAP VT > Condition
    Then I evaluate the source-defined expression for "Check if it is BAP VT" using "Expression='{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"

    # Source step 0079: Click Insurance Score Consent if available | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-62c0-b9ad-e9b0b9d872db
    # Runtime control: Do [max=120] > Loop > If BAP VT > Then
    When I click or select "Insurance Score Consent"
    Then I wait until "IFRAME > Popup > Accept" exists
    When I click or select "IFRAME > Popup > Accept"
    Then I wait until "Insurance Score" exists

    # Source step 0080: Click Insurance Score and wait for Loading Window | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-6d8c-4d68-2f07c426a43c
    # Runtime control: Do [max=120] > Loop
    When I click or select "Insurance Score"

    # Source step 0081: Insurance Score | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-dba3-ee02-3503baa413fb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Condition
    Then "Reference Number" property "InnerText" should equals "\"\""

    # Source step 0082: Wait 1/2 Second for a max of 60 seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-4380-87c1-5285e9b2c0eb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Loop
    When I wait "500" milliseconds

    # Source step 0086: Wait 1/2 Second | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3c33-8cfc-5b97480b4dd3
    When I wait "500" milliseconds

    # Source step 0087: Click Prior Loss Information Button | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9ad8-eb02-17fecdf3ef98
    When I click or select "Enter Prior Loss Information"

    # Source step 0088: Wait for Loss Experience | Module: Underwriting Info | Loss Experience
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-a13e-1f79-5cb9a68adbeb
    Then I wait until "Loss Experience Heading" exists

    # Source step 0089: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-8448-7600-4584fe35482e
    When I enter or select "True{TAB}" in "No known losses"
    Then "No known losses" property "value" should equals "True"

    # Source step 0090: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-fc37-3d29-f7b92b1e33d8
    When I wait "1000" milliseconds

    # Source step 0091: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-0e76-49f9-17056c72e376
    When I click or select "Insurance History"
    Then I wait until "Is there a Prior Carrier?*" exists
    When I enter or select "Yes{Enter}" in "Is there a Prior Carrier?*"
    When I perform keyboard action "{Tab}" on "Is there a Prior Carrier?*"
    When I enter or select "{CLICK}{TAB}" in "Is there a Prior Carrier?*"
    When I enter or select "Insure Us, Inc{TAB}" in "Carrier"
    When I enter or select "P-0123456789{TAB}" in "Policy Number"
    When I enter or select "Commercial Package{TAB}" in "Policy Type"
    When I enter RUNTIME-DERIVED value "{DATE[][-2y][MM'/'dd'/'yyyy]}{TAB}" in "Effective Date"
    When I enter RUNTIME-DERIVED value "{DATE[][][MM'/'dd'/'yyyy]}{TAB}" in "Expiration Date"
    When I enter or select "1.1{TAB}" in "ModificationFactor"
    When I enter or select "1,250{TAB}" in "Total Premium"
    When I click or select "OK"
    Then I wait until "Detail" exists

    # Source step 0092: Click Return to Quote | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9013-a6d2-8708e97153e2
    When I click or select "Return to Quote"

    # Source step 0093: Wait for synchronization | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-cbb8-46f1-130af0ac7391
    Then I wait until "Client" exists

    # Source step 0094: Navigate to Policy Coverage | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > BAP|Policy Covg|Complete Required Info_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-c0fe-83a0-ea1a8d4877c8
    # Source template XTestStep: 3a13d49c-165b-d215-ddb4-2ff21465f162
    Then I wait until "Policy Covgerage" exists
    When I click or select "Policy Covgerage"

    # Source step 0095: Add coverages | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > BAP|Policy Covg|Complete Required Info_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-573a-ce90-7da9ee0a8a3c
    # Source template XTestStep: 3a13d49c-165b-9204-fbce-76b661d0e368
    Then I wait until "Policy Covg" exists
    When I enter or select "{Click}0{ENTER}{TAB}" in "Trailer Interchange Comp Deductible"
    When I enter or select "{Click}100{ENTER}{TAB}" in "Trailer Interchange Collision Deductible"

    # Source step 0096: Wait for Synchronization | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > BAP|Policy Covg|Complete Required Info_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-a2dd-f0ed-c37a35c8740b
    # Source template XTestStep: 3a13d49c-165b-d89a-b853-d5dd3de433a9
    Then I wait until "Policy Covg" exists

    # Source step 0097: Navigate to Location | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Location|Complete Required Info | Source XTestStep: 3a13d49c-165b-0cc7-b2c1-9e8122aa1d7c
    Then I wait until "Location" exists
    When I click or select "Location"

    # Source step 0098: Wait for Synchronization | Module: Location
    # Section: Policy Data Entry Process | Reusable flow: BAP|Location|Complete Required Info | Source XTestStep: 3a13d49c-165b-59cb-beea-fcf92a72e6cd
    Then I wait until "Location" exists
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0099: Navigate to State Details | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > BAP|State Details|Complete UM_UIM Section_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-8382-349b-783bdf8c2310
    # Source template XTestStep: 3a13d49c-165b-7f8e-32e7-e768afd7af6c
    Then I wait until "State Details" exists
    When I click or select "State Details"
    Then I wait until "State Details - Detail" exists
    When I click or select "State Details - Detail"

    # Source step 0100: Wait for Synchronization | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > BAP|State Details|Complete UM_UIM Section_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-45d5-887d-ceecd823946d
    # Source template XTestStep: 3a13d49c-165b-f7aa-daff-924ac0483545
    Then I wait until "State Details" exists

    # Source step 0101: Confirm Changes | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > BAP|State Details|Complete UM_UIM Section_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-7886-9710-6ead1b9e3188
    # Source template XTestStep: 3a13d49c-165b-9bd5-ef94-74a2fc9c5fe3
    When I click or select "OK"

    # Source step 0102: Wait for Synchronization | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > BAP|State Details|Complete UM_UIM Section_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13d6-ee01-3383-dba0ed90adf2
    # Source template XTestStep: 3a13d49c-165b-e3fe-878a-a312dd250f8b
    Then I wait until "State Details - Detail" exists

    # Source step 0103: Navigate to Risk Schedule | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-88bd-22de-4c2220b7685e
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0104: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-c44e-8fc0-def64e5567ed
    Then I wait until "Risk" exists

    # Source step 0105: Add a PPT | Module: Risk Aggregate
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-3078-5138-69269b3198af
    When I enter or select "Private Passenger" in "Vehicle Type"
    When I click or select "Add Risk at This Location"

    # Source step 0106: Fill out Vehicle Information (PPT) | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-e7e0-9fd3-e31e725756b8
    Then I wait until "VIN*" exists
    When I enter or select "{TAB}{TAB}" in "VIN*"
    When I enter or select "{TAB}\"1G1AB08C0CA598143\"{TAB}{TAB}" in "VIN*"

    # Source step 0109: Fill out Physical Damage | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-5f8f-6b73-ff9f0160a067
    When I click or select "OK"

    # Source step 0110: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-d2be-28b6-bef99edffecc
    Then I wait until "Risk" exists

    # Source step 0111: Add a truck | Module: Risk Aggregate
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-2210-cec9-216969cb3eac
    Then I wait until "Show All Locations" exists
    When I enter or select "{TAB}Truck{TAB}{TAB}" in "Vehicle Type"
    When I click or select "Add Risk at This Location"

    # Source step 0112: Fill out Vehicle Information (Truck) | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-d390-a052-84b5c9103ffd
    Then I wait until "VIN*" exists
    When I enter or select "{TAB}{TAB}" in "VIN*"
    When I enter or select "1FDBF2AT3BE598143{TAB}{TAB}" in "VIN*"

    # Source step 0113: Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-78d0-f5aa-5e3e656785e3
    When I enter or select "{TAB}No{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0116: Fill out Physical Damage | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-0d52-bddc-f94666187bd1
    When I click or select "OK"

    # Source step 0117: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-5c84-9fc9-efb225072276
    Then I wait until "Risk" exists

    # Source step 0118: Navigate to Driver Schedule | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-2624-7793-78f8d5626ae9
    When I click or select "Driver Schedule"

    # Source step 0119: Click Add a Driver | Module: Driver Schedule
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-3afb-f1b0-80ed96817db1
    Then I wait until "Driver Schedule" exists
    When I click or select "Add Driver"

    # Source step 0120: Enter Driver info | Module: Driver Detail
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-827c-e346-52e935c6128b
    Then I wait until "IFRAME > Duck Creek Policy > Driver Detail" exists
    When I enter or select "{TAB}John{TAB}{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When I enter or select "{TAB}Snow{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Last Name*"
    When I enter RUNTIME-DERIVED value "{TAB}{DATE[09-05-2026][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Date Of Birth*"
    When I enter or select "{TAB}Foreign License{TAB}{TAB}" in "IFRAME > Duck Creek Policy > State Licensed*"
    Then "IFRAME > Duck Creek Policy > Drivers License Number*" property "InnerText" should equals "International"
    When I enter or select "\"M\"{TAB}" in "IFRAME > Duck Creek Policy > Sex"
    When I enter or select "\"Single\"{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Marital Status"
    When I enter or select "1997{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Year Licensed"
    When I enter or select "01-01-2020{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Date Of Hire"
    When I enter or select "No{TAB}" in "IFRAME > Duck Creek Policy > Do you have a CDL license?*"
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0121: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-46bf-446c-71ddd3115bc9
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0122: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-e5f3-7f2d-23bd9fe88454
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0123: Wait for IFRAME to close | Module: Driver Detail
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-8ea4-5f40-4520f182f575
    Then I wait until "IFRAME" no longer exists

    # Source step 0124: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-1ccb-f20f-ede5f9f5d12e
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0125: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-384f-9c95-434dc426dfe7
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0126: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Endorsements|Fill out required fields | Source XTestStep: 3a13d49c-165b-1797-767a-b5f23b3d9d88
    Then I wait until "Endorsements" exists
    When I click or select "Endorsements"

    # Source step 0127: Wait for Synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process | Reusable flow: BAP|Endorsements|Fill out required fields | Source XTestStep: 3a13d49c-165b-f340-8e40-fbcba953b224
    Then I wait until "Endorsements Heading" exists

    # Source step 0129: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0130: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0131: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0132: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
    # Step condition: 'Endorsement Type' != "[CA2394] Silica or Silica-Related Dust Exclusion"||'Endorsement Type' != "[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"||'Endorsement Type' != "[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
    Then I wait until "Click Add Endorsement" is visible
    When I click or select "Click Add Endorsement"
    Then I wait until "IFRAME > Duck Creek Policy > Endorsement Detail" exists
    When if field condition "Year != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Year" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Make" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Model" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA 9940 - VIN" blank because the reusable parameter is not supplied for this iteration
    Then I wait until "IFRAME > Duck Creek Policy > OK" exists
    Then I wait until "Endorsement Type" exists
    When I click or select "Endorsement Type"
    When I enter or select "(select){TAB}" in "Endorsement Type"
    When I enter or select "{Click}Individual Named Insured{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0133: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0134: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0135: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0136: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0137: BAP Navigation Links | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Addl Interests|Complete Required Info | Source XTestStep: 3a13d49c-165b-3048-4ea8-48b0e4a034fa
    Then I wait until "Additional Interests" exists
    When I click or select "Additional Interests"

    # Source step 0138: Additional Interests | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process | Reusable flow: BAP|Addl Interests|Complete Required Info | Source XTestStep: 3a13d49c-165b-975b-585c-dc6f21e9f1c3
    Then I wait until "Addl Interests" exists

    # Source step 0139: Navigate to UW Questions | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-cfef-6060-dffbfba73711
    When I click or select "UW Questions"

    # Source step 0140: Wait for synchronization | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-4962-7a70-655b6ca4aebd
    Then I wait until "UW Questions" exists

    # Source step 0141: Fill out Underwriting Questions | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-bc4b-759d-fad8403f5fda
    When I enter or select "X{TAB}{TAB}" in "Update Answers Button"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "Are there any commercial vehicles owned by the applicant not insured on the policy?"
    Then I wait until "Are there any commercial vehicles owned by the applicant not insured on the policy?" property "value" equals "No"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "AnyPersonalAutoPolicyListingNameInsured"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "AnyVehicleCoveredRegisteredInNotPrimaryState"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}{TAB}{TAB}" in "BorrowingHiringOrLeasingWithinYear"
    Then I wait until "BorrowingHiringOrLeasingWithinYear" property "value" equals "No"
    Then I wait until "AnyVehicleCoveredRegisteredInNotPrimaryState" property "value" equals "No"

    # Source step 0142: Check for any Felonies question | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-d9e3-5ca9-3cd680f25672
    # Runtime control: If Any Felonies question exists > Condition
    Then "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring" should exist

    # Source step 0143: Fill out any Felonies question | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-42bd-4f1a-3af81ad13192
    # Runtime control: If Any Felonies question exists > Then
    When I enter or select "{TAB}No{TAB}{TAB}" in "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring"

    # Source step 0144: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0145: Fill Out Required Fields on Billing Screen | Module: Billing
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-315a-3b12-4a479c858c7a
    Then I wait until "Billing" exists
    When I enter or select "Direct{TAB}" in "Bill Type"
    When I perform keyboard action "{TAB}" on "Bill Type"
    Then I wait until "Bill Type" property "value" equals "Direct"
    When I enter or select "4{TAB}" in "Pay Plan"
    When I perform keyboard action "{TAB}" on "Pay Plan"
    Then I wait until "Pay Plan" property "value" equals "4"
    Then I wait until "Easy Pay" exists
    When I enter or select "{CLICK}No{ENTER}{TAB}{TAB}" in "Easy Pay"
    When I perform keyboard action "{TAB}" on "Easy Pay"

    # Source step 0146: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0147: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0148: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: Policy Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0149: Navigate to pricing | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Pricing|Verify Premium | Source XTestStep: 3a13d49c-165b-41fa-19a2-c1a98bab9d66
    Then I wait until "Pricing" exists
    When I click or select "Pricing"

    # Source step 0150: Wait for Synchronization | Module: Pricing
    # Section: Policy Data Entry Process | Reusable flow: BAP|Pricing|Verify Premium | Source XTestStep: 3a13d49c-165b-bfeb-6421-9b99827ea8fd
    Then I wait until "Pricing Heading" exists

    # Source step 0151: Verify Premium Amount | Module: Pricing
    # Section: Policy Data Entry Process | Reusable flow: BAP|Pricing|Verify Premium | Source XTestStep: 3a13d49c-165b-9fb0-1370-09b908b23536
    Then "Premium" property "value" should equals "*$1,560.00"

    # Source step 0152: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0153: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0154: Order Audit | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0155: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0156: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0157: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0158: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0159: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0160: 500ms wait for syncing | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0161: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0162: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0163: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0164: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0165: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0166: Wait 2 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0167: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0168: Set Error Flag | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0212: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0213: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0214: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0215: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0216: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0217: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0221: Wait 3.5 seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0222: Check for Loading Indicator | Module: Indicators and Errors
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0223: Wait 2 secs | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0224: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0225: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0226: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0227: Wait 2 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0228: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0272: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0273: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0274: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0275: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0276: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0277: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0278: Wait 3.5 seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0279: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0284: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "1,560.00" as runtime value "NBPrem"

    # Source step 0285: Verify Premiums | Module: Submission|Premiums
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "$1,560.00"
    Then "Premium Written" property "value" should equals "1,560.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "1,560.00"

    # Source step 0286: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0287: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0288: Buffer Server Address | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0289: Forms API Request | Module: Forms API Request
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0290: Forms API Response | Module: Forms API Response
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0291: Sync API | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0292: Save the Response as XML file | Module: Save XML file
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\BAP_BASIC_AL_{B[QuoteID]}.xml"

    # Source step 0298: Sync API | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0299: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\\" -FileName \"BAP_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0300: Execute Powershell Script | Module: TBox Start Program
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0301: Display the Results Summary | Module: TBox Clipboard
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0302: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0310: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0311: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0312: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0313: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0314: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0066: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0067: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0083: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:56 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-d800-16b1-204343afb7e1
#    - INPUT "Duration" with "1500"
# Source step 0084: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 14.04.20 08:18:24 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-06ca-978e-d5200f0622bb
#    - WAIT (Exists) "Insurance Score" with "False"
# Source step 0085: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:31 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3a41-fade-9ac567a11717
#    - INPUT "Duration" with "1500"
# Source step 0107: "Check if NY or NJ" in module "TBox Evaluation Tool" was disabled. Reason: 08.11.24 06:57:16 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-7aba-d288-b7d1b9e6e88e
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value '\"\"{B[State]}'\"\"=='NY'||'\"\"{B[State]}'\"\"=='NJ'"
# Source step 0108: "Fill out Physical Damage" in module "Risk Schedule|Physical Damage" was disabled. Reason: 08.11.24 06:57:16 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-cc8e-c6db-3771f7586c49
#    - INPUT "Inspection Required" with "{TAB}Yes{TAB}"
#    - INPUT "Inspection Method*" with "{TAB}Agent{TAB}"
# Source step 0114: "Check if NY or NJ" in module "TBox Evaluation Tool" was disabled. Reason: 08.11.24 06:57:39 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-de78-a1fd-40b0ba12e917
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value '\"\"{B[State]}'\"\"=='NY'||'\"\"{B[State]}'\"\"=='NJ'"
# Source step 0115: "Fill out Physical Damage" in module "Risk Schedule|Physical Damage" was disabled. Reason: 08.11.24 06:57:39 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: BAP|Risk Schedule|Fill out Vehicle Information | Source XTestStep: 3a13d49c-165b-361e-51f3-2d910131e393
#    - INPUT "Inspection Required" with "{TAB}Yes{TAB}"
#    - INPUT "Inspection Method*" with "{TAB}Agent{TAB}"
# Source step 0128: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0169: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0170: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0171: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0172: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0173: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0174: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0175: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0176: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0177: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0178: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0179: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0180: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0181: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0182: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0183: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0184: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0185: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0186: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0187: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0188: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0189: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0190: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0191: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0192: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0193: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0194: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0195: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0196: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0197: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0198: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0199: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0200: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0201: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0202: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0203: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0204: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0205: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0206: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0207: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0208: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0209: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0210: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0211: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0229: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0230: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0231: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0232: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0233: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0234: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0235: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0236: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0237: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0238: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0239: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0240: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0241: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0242: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0243: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0244: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0245: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0246: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0247: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0248: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0249: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0250: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0251: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0252: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0253: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0254: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0255: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0256: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0257: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0258: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0259: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0260: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\"
# Source step 0261: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0262: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0263: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0264: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0265: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0266: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0267: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0268: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0269: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0270: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0271: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0280: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0281: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0282: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0283: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0293: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0294: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0295: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0296: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\BAP_BASIC_AL_{B[QuoteID]}.xml"
# Source step 0297: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-878b-57be-a03b92d53f46
#    - GROUP "Request_2" with "a blank/null value"
#    - ACTION "Request_3" with "a blank/null value"
#    - GROUP "Request_3 > server" with "a blank/null value"
#    - GROUP "Request_3 > server > requests" with "a blank/null value"
#    - GROUP "Request_3 > server > requests > Session.resumeRq" with "a blank/null value"
#    - GROUP "Request_3 > server > requests > Session.resumeRq > sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
#    - GROUP "Request_3 > server > requests > FormsEngine.initPrintJobRq" with "a blank/null value"
#    - GROUP "Request_3 > server > requests > FormsEngine.initPrintJobRq > manuscript" with "Carrier_CommercialLines_Forms_US_4_0_0_0"
#    - GROUP "Request_3 > server > requests > FormsEngine.initPrintJobRq > printJob" with "_TransactionPrint"
#    - GROUP "Request_3 > server > requests > FormsEngine.initPrintJobRq > forceInit" with "1"
#    - ACTION "Communicate_3" with "a blank/null value"
#    - INPUT "Communicate_3 > Address" with "the RUNTIME-DERIVED source value {B[ServerAddress]}"
#    - GROUP "Communicate_3 > Send" with "a blank/null value"
#    - INPUT "Communicate_3 > Send > Method" with "POST"
#    - GROUP "Communicate_3 > Send > Headers" with "a blank/null value"
#    - GROUP "Communicate_3 > Receive" with "a blank/null value"
#    - VERIFY "Communicate_3 > Receive > Status code name" with "200 OK"
#    - GROUP "Transform response" with "a blank/null value"
#    - GROUP "Transform response > Response transformation_4" with "a blank/null value"
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\BAP_BASIC_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0303: "Logout" in module "Logout" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0304: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0305: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0306: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0307: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0308: "Logout" in module "Logout" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0309: "Waiton Username to exist" in module "Login" was disabled. Reason: 09.01.25 09:21:41 [ff01620@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  CommercialAuto  Pages   US   (9.23.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0041 "Select Individual Sole Proprietor" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
# Active source step 0059 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
# Active source step 0061 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
# Active source step 0063 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0132 "Enter required endorsement info" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "IFRAME > Duck Creek Policy > Click Add Excluded Driver" with "True" when 'Add Excluded Driver' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Add Excluded Driver' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Click Add Excluded Driver" with "X" when 'Add Excluded Driver' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Add Excluded Driver' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Add Driver Name" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Driver Name>{TAB})" when 'Driver Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Driver Name' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Excluded Driver Action Taken" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Driver Action Taken>{TAB})" when 'Driver Action Taken' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Driver Action Taken' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > State Licensed" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: State Licensed>{TAB})" when 'State Licensed' != NULL. Reason: Value condition evaluated false for the selected iteration: 'State Licensed' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Date Of Birth" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Date of Birth>{TAB})" when 'Date of Birth' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Date of Birth' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Exclusion Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Exclusion Type>{TAB})" when 'Exclusion Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Exclusion Type' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA0167 - Input Cost Of Hire" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Cost of Hire>{TAB})" when 'Cost of Hire' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Cost of Hire' != NULL
#    - WAIT (Exists) "IFRAME > Duck Creek Policy > [CA2325] Leased Workers Coverage" with "True" when 'Endorsement Type' == "[CA2325] Leased Workers Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' == "[CA2325] Leased Workers Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > CA9940 - Contract Provisions" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Contract Provisions>{ENTER}{TAB})" when 'Contract Provisions' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Contract Provisions' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA9948 - Classes Of Commodities Transported" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Commodities Transported>{ENTER}{TAB})" when 'Commodities Transported' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Commodities Transported' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA9990 - Amount Per Day Maximum" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Amount Per Day Max>{ENTER}{TAB})" when 'Amount Per Day Max' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Amount Per Day Max' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # Days Insured" with "{TAB}300{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # of Trailers" with "{TAB}50{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Death Benefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Death Benefits>{TAB})" when 'Death Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Death Benefits' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > DisabilityBenefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Disability Benefits>{TAB})" when 'Disability Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Disability Benefits' != NULL
# Source step 0218: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0219: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0220: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-13d6-ecaa-0883-5cfc2f12c5de
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BAP\\BAP BASIC TestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-13d6-75de-9643-8c2801b0a89a
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BAP\\BAP BASIC TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-13d6-cbe4-c1f7-288f7ffea19c
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BAP\\BAP BASIC TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13d6-95dc-45e7-ea82aa4c7d83
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13d6-af34-624f-5a39e6f4349c
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13d6-b977-dfeb-575d0efb6c4d
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13d6-d106-bb11-63fa47a0c20a
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13d6-7d19-f730-3b3ef344553f
#    - I run "taskkill /f /im msEdge.exe"
