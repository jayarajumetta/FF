# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 024_ZZ_OBSOLETE_zzBAP_GAP_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @BAP @gap @Alabama @Edge @manual @obsolete @archive @automated
Feature: Execute zzBAP | GAP for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the zzBAP | GAP workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: zzBAP | GAP using representative iteration Alabama (AL)

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
    When I retain hard-coded value "Blank" as runtime value "FormOnPolicyDocName"

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
    When I enter or select "04-01-2023{TAB}" in "EffectiveDate"
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
    When I enter RUNTIME-DERIVED value "AL BAP GAP {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
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

    # Source step 0087: Navigate to Policy Covg screen | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Regression|Change Liability Limit (BAP) | Source XTestStep: 3a13d49c-165b-cfa2-191e-56c729b5beb1
    When I click or select "Policy Covgerage"

    # Source step 0088: Wait on Policy Covg screen to exist | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process | Reusable flow: Common|Regression|Change Liability Limit (BAP) | Source XTestStep: 3a13d49c-165b-3009-c997-9298e468a898
    Then I wait until "Liability Limit" exists
    When I perform keyboard action "{TAB}" on "Liability Limit"

    # Source step 0089: Change Liability Limit | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process | Reusable flow: Common|Regression|Change Liability Limit (BAP) | Source XTestStep: 3a13d49c-165b-834b-4cba-0f7205828cbd
    When if field condition "'State' != \"ID\"" is satisfied, I enter or select "{Click}$300,000{ENTER}{TAB}{TAB}" in "Liability Limit"

    # Source step 0090: Verify Liability Limit | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process | Reusable flow: Common|Regression|Change Liability Limit (BAP) | Source XTestStep: 3a13d49c-165b-b974-a044-4d5b0fa62c27
    Then if field condition "'State' != \"ID\"" is satisfied, "Liability Limit" property "value" should equals "*$300,000"

    # Source step 0091: Buffer CSL limit for UM/UIM verification | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process | Reusable flow: BAP|Buffer CSL limit | Source XTestStep: 3a13d49c-165b-02ac-0ba7-4b99e67cb54c
    When I capture "Liability Limit" as runtime value "CSL Limit"

    # Source step 0092: Trim characters | Module: TBox Partial Buffer
    # Section: Policy Data Entry Process | Reusable flow: BAP|Buffer CSL limit | Source XTestStep: 3a13d49c-165b-5651-9836-f48d6e9b9dac
    When I perform the source-defined partial-buffer operation "Trim characters" using "Buffer=CSL Limit; Value={B[CSL Limit]}; Start=2"

    # Source step 0093: Navigate to State Details | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-46dc-6c97-639dbdb208dc
    When I click or select "State Details"
    Then I wait until "State Details - Detail" exists
    When I click or select "State Details - Detail"
    Then I wait until "State Details - Detail" no longer is visible

    # Source step 0094: Wait for Synchronization | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-f101-aa3e-b997e02d9116
    Then I wait until "OK" is visible

    # Source step 0095: Verify UM defaults | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-f187-d81f-b825220c032a
    Then if field condition "'UM Type Default (editable)' != NULL" is satisfied, "UM Type Default Selections" property "value" should equals "UMBI CSL"
    Then if field condition "'UMBI Limit (editable)' == \"CSL Limit\"" is satisfied, "UMBI Limit*" property "value" should equals "{Regex[{B[CSL Limit]}|\"$\"{B[CSL Limit]}]}"

    # Source step 0100: Confirm | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-6b5a-268a-f525041b87a8
    When I click or select "OK"

    # Source step 0101: Wait for Synchronization | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-c3e3-2bbf-2eafed89d0b5
    Then I wait until "Risk Schedule" is visible

    # Source step 0102: Navigate to State Details | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-b167-9ae2-988ecd7a39bc
    When I click or select "State Details"
    Then I wait until "State Details - Detail" exists
    When I click or select "State Details - Detail"
    Then I wait until "State Details - Detail" no longer is visible

    # Source step 0103: Wait for Synchronization | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-055e-2d41-e7227a9456d6
    Then I wait until "State Details" is visible
    Then I wait until "OK" is visible

    # Source step 0104: Increase UM/UIM Limit | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-5d4f-5470-f89a5ba34b90
    When if field condition "'UM > CSL stoplight' != NULL" is satisfied, I enter or select "1,000,000{TAB}{TAB}{TAB}{TAB}{TAB}" in "UMBI Limit*"
    When if field condition "'UM > CSL stoplight' != NULL" is satisfied, I enter or select "1,000,000{TAB}{TAB}" in "UMBI Limit*"
    Then if field condition "'UM > CSL stoplight' != NULL" is satisfied, "UMBI Limit*" property "value" should equals "{Regex[1,000,000|$1,000,000]}"

    # Source step 0105: Verify message | Module: State Details|Stoplight messages
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-bb46-f431-47cd85e9204a
    # Step condition: State != "CT"
    Then "UM limit selected should not be greater than the policy CSL limit" should exist
    Then if field condition "'UIM > CSL stoplight' != NULL OR 'UIM Limit - read only' != NULL" is satisfied, "UIM limit selected should not be greater than the policy CSL limit" should exist

    # Source step 0109: Confirm Changes | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-61a3-a145-d99bfb230006
    When I click or select "OK"

    # Source step 0110: Wait for Synchronization | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-1d36-8a71-3665dedde2f3
    Then I wait until "Risk Schedule" is visible

    # Source step 0111: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0112: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0113: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0114: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0115: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0116: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Private Passenger{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Private Passenger"
    When I click or select "Add Risk at This Location"

    # Source step 0117: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0118: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I leave "Year*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "Make*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "Model*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "1G1AB08C0CA598143{TAB}{TAB}" in "VIN*"

    # Source step 0119: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0120: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0121: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0122: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0125: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I leave "GCW*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Snowplow != NULL" is satisfied, I leave "Is This Vehicle Used In Snow Plow Operations?*" blank because the reusable parameter is not supplied for this iteration

    # Source step 0129: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0130: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Private Passenger\"\"' == 'Registration Plates'"

    # Source step 0132: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"1G1AB08C0CA598143\"\"' == 'ContentsVIN1234'"

    # Source step 0134: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0135: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0136: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0137: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0138: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0139: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0140: Navigate to Driver Schedule | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-2624-7793-78f8d5626ae9
    When I click or select "Driver Schedule"

    # Source step 0141: Click Add a Driver | Module: Driver Schedule
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-3afb-f1b0-80ed96817db1
    Then I wait until "Driver Schedule" exists
    When I click or select "Add Driver"

    # Source step 0142: Enter Driver info | Module: Driver Detail
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-827c-e346-52e935c6128b
    Then I wait until "IFRAME > Duck Creek Policy > Driver Detail" exists
    When I enter or select "{TAB}John{TAB}{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When I enter or select "{TAB}Snow{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Last Name*"
    When I enter RUNTIME-DERIVED value "{TAB}{DATE[04-01-2023][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Date Of Birth*"
    When I enter or select "{TAB}Foreign License{TAB}{TAB}" in "IFRAME > Duck Creek Policy > State Licensed*"
    Then "IFRAME > Duck Creek Policy > Drivers License Number*" property "InnerText" should equals "International"
    When I enter or select "\"M\"{TAB}" in "IFRAME > Duck Creek Policy > Sex"
    When I enter or select "\"Single\"{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Marital Status"
    When I enter or select "1997{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Year Licensed"
    When I enter or select "01-01-2020{TAB}{TAB}" in "IFRAME > Duck Creek Policy > Date Of Hire"
    When I enter or select "No{TAB}" in "IFRAME > Duck Creek Policy > Do you have a CDL license?*"
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0143: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-46bf-446c-71ddd3115bc9
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0144: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-e5f3-7f2d-23bd9fe88454
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0145: Wait for IFRAME to close | Module: Driver Detail
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-8ea4-5f40-4520f182f575
    Then I wait until "IFRAME" no longer exists

    # Source step 0146: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-1ccb-f20f-ede5f9f5d12e
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0147: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-384f-9c95-434dc426dfe7
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0148: Navigate to UW Questions | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-cfef-6060-dffbfba73711
    When I click or select "UW Questions"

    # Source step 0149: Wait for synchronization | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-4962-7a70-655b6ca4aebd
    Then I wait until "UW Questions" exists

    # Source step 0150: Fill out Underwriting Questions | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-bc4b-759d-fad8403f5fda
    When I enter or select "X{TAB}{TAB}" in "Update Answers Button"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "Are there any commercial vehicles owned by the applicant not insured on the policy?"
    Then I wait until "Are there any commercial vehicles owned by the applicant not insured on the policy?" property "value" equals "No"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "AnyPersonalAutoPolicyListingNameInsured"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "AnyVehicleCoveredRegisteredInNotPrimaryState"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}{TAB}{TAB}" in "BorrowingHiringOrLeasingWithinYear"
    Then I wait until "BorrowingHiringOrLeasingWithinYear" property "value" equals "No"
    Then I wait until "AnyVehicleCoveredRegisteredInNotPrimaryState" property "value" equals "No"

    # Source step 0151: Check for any Felonies question | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-d9e3-5ca9-3cd680f25672
    # Runtime control: If Any Felonies question exists > Condition
    Then "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring" should exist

    # Source step 0152: Fill out any Felonies question | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-42bd-4f1a-3af81ad13192
    # Runtime control: If Any Felonies question exists > Then
    When I enter or select "{TAB}No{TAB}{TAB}" in "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring"

    # Source step 0153: Navigate to Policy Info | Module: Common Navigation Links
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: <none> | Source XTestStep: 3a13d49c-1430-a80d-6531-ec76501af3ee
    # Source template XTestStep: 3a13d49c-13a9-aa3a-1354-a2f3866f082c
    When I click or select "Policy Info"

    # Source step 0154: Click Prior Loss Information Button | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9ad8-eb02-17fecdf3ef98
    When I click or select "Enter Prior Loss Information"

    # Source step 0155: Wait for Loss Experience | Module: Underwriting Info | Loss Experience
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-a13e-1f79-5cb9a68adbeb
    Then I wait until "Loss Experience Heading" exists

    # Source step 0156: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-8448-7600-4584fe35482e
    When I enter or select "True{TAB}" in "No known losses"
    Then "No known losses" property "value" should equals "True"

    # Source step 0157: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-fc37-3d29-f7b92b1e33d8
    When I wait "1000" milliseconds

    # Source step 0158: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-0e76-49f9-17056c72e376
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

    # Source step 0159: Click Return to Quote | Module: Common Navigation Links
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9013-a6d2-8708e97153e2
    When I click or select "Return to Quote"

    # Source step 0160: Wait for synchronization | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process > Fill out UW information | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-cbb8-46f1-130af0ac7391
    Then I wait until "Client" exists

    # Source step 0161: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0162: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0163: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0164: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0165: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: Policy Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0166: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0167: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0168: Order Audit | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0169: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0170: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0171: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0172: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0173: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0174: 500ms wait for syncing | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0175: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0176: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0177: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0178: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0179: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0180: Wait 2 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0181: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0182: Set Error Flag | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0226: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0227: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0228: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0229: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0230: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0231: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0232: Check for Loading Indicator | Module: Indicators and Errors
    # Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0233: Wait 2 secs | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0234: Wait for Stoplight message to exist | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
    Then I wait until "All required fields have not been completed. Please complete highlighted tabs." exists
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0298: Check for Save for Later Button | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-7f66-3db6-9842c21b8f30
    # Runtime control: Check for Save for Later Button to avoid Locking the Policy > Condition
    Then "Save for Later" should exist

    # Source step 0299: Save for Later | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-76d9-8f8d-5996da943954
    # Runtime control: Check for Save for Later Button to avoid Locking the Policy > Then
    When I click or select "Save for Later"
    Then I wait until "Save for Later - OK" exists
    When I click or select "Save for Later - OK"

    # Source step 0300: Check for Return to Admin Button | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-f9d4-d6c6-7d52f321bbe0
    # Runtime control: Check for Return to Admin Button to avoid Locking the Policy > Condition
    Then "Return To Admin" should exist

    # Source step 0301: Return To Admin | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-5f9c-b6f4-47437bc9202b
    # Runtime control: Check for Return to Admin Button to avoid Locking the Policy > Then
    When I click or select "Return To Admin"
    Then I wait until "Return To Admin" no longer exists

    # Source step 0302: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0303: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0304: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0305: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0306: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0307: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0309: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0310: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0311: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0312: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0313: Close Edge Beta Browsers | Module: TBox Start Program
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
# Source step 0183: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0184: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0185: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0186: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0187: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0188: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0189: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0190: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0191: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0192: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0193: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0194: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0195: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0196: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0197: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0198: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0199: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0200: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0201: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0202: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0203: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0204: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0205: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0206: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0207: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0208: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0209: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0210: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0211: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0212: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0213: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0214: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0215: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0216: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0217: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0218: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0219: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0220: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0221: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0222: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0223: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0224: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0225: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0243: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0244: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0245: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0246: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0247: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0248: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0249: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0250: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0251: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0252: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0253: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0254: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0255: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0256: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0257: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0258: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0259: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0260: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0261: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0262: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0263: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0264: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0265: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0266: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0267: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0268: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0269: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0270: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0271: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0272: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0273: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "the source value not supplied by the exported iteration (<SOURCE VALUE NOT SUPPLIED BY EXPORTED ITERATION: Forms Set Up.FormDocPath>Screenshots)"
#    - INPUT "Filename" with "Login Error"
# Source step 0274: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "the source value not supplied by the exported iteration (<SOURCE VALUE NOT SUPPLIED BY EXPORTED ITERATION: Forms Set Up.FormDocPath>)"
# Source step 0275: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0276: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0277: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0278: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0279: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0280: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0281: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0282: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0283: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0284: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0285: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0294: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0295: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0296: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0297: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0308: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
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
# Active source step 0089 "Change Liability Limit" contains conditionally inapplicable field action(s):
#    - INPUT "Medical Limit" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Medical Limit>{ENTER}{TAB}{TAB})" when 'State' == "ID". Reason: Value condition evaluated false for the selected iteration: 'State' == "ID"
# Active source step 0090 "Verify Liability Limit" contains conditionally inapplicable field action(s):
#    - VERIFY "Medical Limit" with "a blank/not-supplied reusable parameter (*<BLANK — reusable-block parameter is not supplied: Medical Limit>)" when 'State' == "ID". Reason: Value condition evaluated false for the selected iteration: 'State' == "ID"
# Active source step 0095 "Verify UM defaults" contains conditionally inapplicable field action(s):
#    - VERIFY "UM Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UM Coverage>)" when 'UM Coverage' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UM Coverage' != NULL
#    - VERIFY "UM Type Default read only" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UM Type Default (read only)>)" when 'UM Type Default (read only)' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UM Type Default (read only)' != NULL
#    - VERIFY "Stacked UM" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UM Stacked>)" when 'UM Stacked' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UM Stacked' != NULL
#    - VERIFY "UMBI Limit*" with "{Regex[CSL Limit|\"$\"CSL Limit]}" when 'UMBI Limit (editable)' != NULL && 'UMBI Limit (editable)' != "CSL Limit". Reason: Value condition evaluated false for the selected iteration: 'UMBI Limit (editable)' != NULL && 'UMBI Limit (editable)' != "CSL Limit"
#    - VERIFY "UMBI Limit* read only" with "a blank/not-supplied reusable parameter ({Regex[<BLANK — reusable-block parameter is not supplied: UMBI Limit (read only)>|\"$\"<BLANK — reusable-block parameter is not supplied: UMBI Limit (read only)>]})" when 'UMBI Limit (read only)' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UMBI Limit (read only)' != NULL
#    - VERIFY "UMPD Limit - read only" with "a blank/not-supplied reusable parameter ({Regex[<BLANK — reusable-block parameter is not supplied: UMPD Limit - read only>|\"$\"<BLANK — reusable-block parameter is not supplied: UMPD Limit - read only>]})" when 'UMPD Limit - read only' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UMPD Limit - read only' != NULL
#    - VERIFY "Economic Loss Coverage Only" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Economic Loss Only>)" when 'Economic Loss Only' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Economic Loss Only' != NULL
# Source step 0096: "Verify UIM defaults" in module "State Details|UM/UIM" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-aac6-f362-2d7c9f91a0b1
#    - Preserved source field action: VERIFY "Include UIM" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Include UIM>)" when 'Include UIM' != NULL
#    - Preserved source field action: VERIFY "Stacked UIM" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UIM Stacked>)" when 'UIM Stacked' != NULL
#    - Preserved source field action: VERIFY "UIM Type Default Selections" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UIM Type Default (editable)>)" when 'UIM Type Default (editable)' != NULL
#    - Preserved source field action: VERIFY "UIM Type Default Read Only" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UIM Type Default (read only)>)" when 'UIM Type Default (read only)' != NULL
#    - Preserved source field action: VERIFY "UIM CSL Limit*" with "the RUNTIME-DERIVED source value {Regex[{B[CSL Limit]}|\"$\"{B[CSL Limit]}]}" when 'UIMBI Limit (editable)' == "CSL Limit"
#    - Preserved source field action: VERIFY "UIM CSL Limit*" with "a blank/not-supplied reusable parameter ({Regex[<BLANK — reusable-block parameter is not supplied: UIMBI Limit (editable)>|\"$\"<BLANK — reusable-block parameter is not supplied: UIMBI Limit (editable)>]})" when 'UIMBI Limit (read only)' != NULL && 'UIMBI Limit (editable)' != "CSL Limit"
#    - Preserved source field action: VERIFY "UIM CSL Limit Read Only" with "a blank/not-supplied reusable parameter ({Regex[<BLANK — reusable-block parameter is not supplied: UIMBI Limit (read only)>|\"$\"<BLANK — reusable-block parameter is not supplied: UIMBI Limit (read only)>]})" when 'UIMBI Limit (read only)' != NULL
# Source step 0097: "WI Add Required Coverage" in module "State Details|UM/UIM" was not executed. Reason: Selected-iteration condition evaluated false: State == "WI"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-ac13-8a22-99f8d9a0ab6b
#    - Preserved source field action: INPUT "UIM Type Default Selections" with "UIMBI CSL{TAB}{TAB}"
#    - Preserved source field action: VERIFY "UIM CSL Limit*" with "{Regex[\"100,000\"|\"$100,000\"]}"
# Source step 0098: "NY Verify Supplementary Limit" in module "State Details|UM/UIM" was not executed. Reason: Selected-iteration condition evaluated false: State == "NY"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-4c42-4322-533a4bed1c41
#    - Preserved source field action: INPUT "UM Coverage" with "{Click}Supplementary{ENTER}{TAB}"
#    - Preserved source field action: VERIFY "UM Type Default read only" with "UMBI CSL"
#    - Preserved source field action: VERIFY "UMBI Limit*" with "the RUNTIME-DERIVED source value {REGEX[{B[CSL Limit]}|\"$\"{B[CSL Limit]}]}"
# Source step 0099: "NY Restore Default" in module "State Details|UM/UIM" was not executed. Reason: Selected-iteration condition evaluated false: State == "NY"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|GAP|Verify UM/UIM Defaults | Source XTestStep: 3a13d49c-165b-3a10-9d61-f9cac71cb407
#    - Preserved source field action: INPUT "UM Coverage" with "{Click}Statutory{ENTER}{TAB}"
# Active source step 0104 "Increase UM/UIM Limit" contains conditionally inapplicable field action(s):
#    - INPUT "UIM CSL Limit*" with "1,000,000{ENTER}{TAB}{TAB}" when 'UIM > CSL stoplight' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM > CSL stoplight' != NULL
#    - VERIFY "UIM CSL Limit*" with "{Regex[1,000,000|$1,000,000]}" when 'UIM > CSL stoplight' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM > CSL stoplight' != NULL
# Source step 0106: "Verify message - CT" in module "State Details|Stoplight messages" was not executed. Reason: Selected-iteration condition evaluated false: State == "CT"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-ff61-8054-3ab3084c3b6a
#    - Preserved source field action: VERIFY (Exists) "UM limit selected cannot exceed 2x the policy CSL limit" with "True"
# Source step 0107: "Decrease UM Limit (SD)" in module "State Details|UM/UIM" was not executed. Reason: Selected-iteration condition evaluated false: State == "SD"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-c87a-2f94-92fa292e4c4b
#    - Preserved source field action: INPUT "UMBI Limit*" with "100,000{TAB}{TAB}"
#    - Preserved source field action: VERIFY "UMBI Limit*" with "100,000"
# Source step 0108: "Verify message - SD" in module "State Details|Stoplight messages" was not executed. Reason: Selected-iteration condition evaluated false: State == "SD"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|Verify UM/UIM Limit Exceeds CSL Stoplight | Source XTestStep: 3a13d49c-165b-374d-bc38-6798d0ebc140
#    - Preserved source field action: VERIFY (Exists) "UIM limit selected should not be greater than the policy UMBI limit." with "True"
# Active source step 0118 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Body Style" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Body Style>{TAB}{TAB})" when 'Body Style' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Body Style' != NULL
#    - INPUT "Value Basis" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Value Basis>{TAB}{TAB})" when 'Value Basis' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Value Basis' != NULL
#    - INPUT "Original Cost New*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Original Cost New>{TAB}{TAB})" when 'Original Cost New' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Original Cost New' != NULL
#    - INPUT "Stated Amount*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Stated Amount>{TAB}{TAB})" when 'Stated Amount' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stated Amount' != NULL
# Source step 0123: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Source step 0124: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Active source step 0125 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "2nd Class Category" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Category>{TAB})" when '2nd Class Category' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Category' != NULL
#    - INPUT "2nd Class Code*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Code>{TAB}{TAB})" when '2nd Class Code' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Code' != NULL
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0126: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0127: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Source step 0128: "Add/Remove Physical Damage" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
#    - Preserved source field action: INPUT "OTC Causes of Loss*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: OTC Causes of Loss>{TAB})" when 'OTC Causes of Loss' != NULL
#    - Preserved source field action: INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL
#    - Preserved source field action: INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL
#    - Preserved source field action: INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL
#    - Preserved source field action: INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL
# Source step 0131: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0133: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0235: "Wait 3.5 seconds" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
#    - Preserved source field action: INPUT "Duration" with "3500"
# Source step 0236: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0237: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0238: "Stoplight message is visible" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
# Source step 0239: "Run Stoplight" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
#    - Preserved source field action: INPUT "Complete Application" with "X"
# Source step 0240: "Run Stoplight" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
#    - Preserved source field action: ACTION "stoplightWaitingWindow" with "a blank/null value"
#    - Preserved source field action: VERIFY (Exists) "stoplightWaitingWindow > Close" with "False"
# Source step 0241: "Wait 2 Seconds" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0242: "Check for error" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
#    - Preserved source field action: ACTION "stoplightWaitingWindow" with "a blank/null value"
#    - Preserved source field action: VERIFY (Exists) "stoplightWaitingWindow > Error:" with "True"
# Source step 0286: "Click First Close button on Error" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
#    - Preserved source field action: ACTION "stoplightWaitingWindow" with "a blank/null value"
#    - Preserved source field action: INPUT "stoplightWaitingWindow > First Close button on Error" with "X"
# Source step 0287: "Wait 3 Seconds" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
#    - Preserved source field action: INPUT "Duration" with "3000"
# Source step 0288: "Click Complete App" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
#    - Preserved source field action: INPUT "Complete Application" with "X"
# Source step 0289: "Wait 3 Seconds" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
#    - Preserved source field action: INPUT "Duration" with "3000"
# Source step 0290: "Close Stoplight Window" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
#    - Preserved source field action: ACTION "stoplightWaitingWindow" with "a blank/null value"
#    - Preserved source field action: INPUT "stoplightWaitingWindow > Close" with "X"
# Source step 0291: "Wait on Stoplight window to go away" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
#    - Preserved source field action: WAIT (Exists) "stoplightWaitingWindow" with "False"
# Source step 0292: "Wait 3.5 seconds" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
#    - Preserved source field action: INPUT "Duration" with "3500"
# Source step 0293: "Verify Stoplight Successfully Ran" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "False"
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "False"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario steps were exported for this representative iteration.
