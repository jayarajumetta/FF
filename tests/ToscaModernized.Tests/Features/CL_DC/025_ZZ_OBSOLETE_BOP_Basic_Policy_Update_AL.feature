# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 025_ZZ_OBSOLETE_BOP_Basic_Policy_Update_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @BOP @basic_policy @Alabama @Edge @manual @obsolete @archive @automated
Feature: Execute BOP | Basic Policy_Update for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the BOP | Basic Policy_Update workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: BOP | Basic Policy_Update using representative iteration Alabama (AL)

    # Source step 0037: Uncheck Quick Quote | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-477c-510c-7ad43036cba4
    When I enter or select "False" in "Quick Quote"

    # Source step 0038: Wait on non-quick quote element | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3cbc-4aa7-a1c7b75ee619
    Then I wait until "Underwriting Info" exists

    # Source step 0039: Select Individual Insured | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-8c16-d826-567aed4c90ca
    When I enter or select "Individual/Person{ENTER}{TAB}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0040: Enter Name and DOB | Module: Client|Named Insured|Individual
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3ecf-8633-002f64245127
    Then I wait until "First Name" is visible
    When I enter or select "{TAB}{TAB}" in "First Name"
    When I enter or select "{CLICK}John{TAB}{TAB}" in "First Name"
    When I enter or select "AL{TAB}{TAB}" in "Middle Name"
    When I enter or select "{TAB}{TAB}" in "Last Name"
    When I enter RUNTIME-DERIVED value "{DATE[][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "DOB"
    When if field condition "State!=\"CA\"" is satisfied, I enter or select "Male{TAB}{TAB}" in "Gender"
    When I enter a RANDOM value matching "^[a-z]{4}$" in "Last Name"

    # Source step 0041: Select Individual Sole Proprietor | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-f281-684f-979ca5404005
    When I enter or select "Individual/Sole Proprietor{ENTER}{TAB}{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I enter or select "{TAB}1918 Avalon Ave{TAB}" in "Address1"
    When I enter or select "{TAB}35661{TAB}" in "ZipCode"

    # Source step 0042: Click Client search | Module: Client|Named Insured|Individual
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-7952-2e48-6b516ae5679d
    When I click or select "Client Search"

    # Source step 0043: Client Search Results | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-62f0-721e-d093b870cfd8
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0044: Enter SSN | Module: Client|Named Insured|Individual
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3868-3c34-dfdde15584ab
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
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-cb58-ee90-632993a50481
    When I perform the source-defined partial-buffer operation "Partial Buffer the Last Four of SSN" using "Buffer=Last4SSN; Value={B[SSN]}; Start=6"

    # Source step 0046: Wait for SSN mask | Module: Client|Named Insured|Individual
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-eddc-3263-04e8ba1848e0
    Then I wait until "Social Security # " property "InnerText" equals "XXX-XX-*"

    # Source step 0047: Validate SSN | Module: Client|Named Insured|Individual
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-a17a-f6cd-1482be959af6
    Then "Social Security # " property "InnerText" should equals "XXX-XX-{B[Last4SSN]}"
    Then I wait until "Please verify SSN*" no longer exists

    # Source step 0048: Enter other insured info | Module: Client|Other Insured Info
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-1cd6-971b-633af7644e81
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}{CLICK}Auditor Doe{TAB}{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0049: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-6c12-f22a-3d3cfbcf2bb3
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0050: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-b042-25d6-3bc4136f8a02
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "BOP" as runtime value "Product (LOB)"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"
    When I retain hard-coded value "BOP_BASIC" as runtime value "FormOnPolicyDocName"

    # Source step 0051: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0052: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0053: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0054: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0055: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "02-07-2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0056: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0057: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0058: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0059: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
    # Runtime control: If State is Kansas > Then
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "(select){ENTER}{TAB}{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0060: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0061: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
    # Runtime control: If State is Virginia > Then
    When if field condition "'Product (LOB)' == \"BOP\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0062: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0063: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0064: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0065: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL BOP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0068: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-db96-2f0e-1e230bb9a656
    When I wait "1500" milliseconds

    # Source step 0069: Insurance Score | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-84af-bc6a-3f9f6e937252
    # Runtime control: Do [max=120] > Condition
    Then "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS" should exist

    # Source step 0070: Check if it is BAP VT | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-faf3-28ce-cca724db461f
    # Runtime control: Do [max=120] > Loop > If BAP VT > Condition
    Then I evaluate the source-defined expression for "Check if it is BAP VT" using "Expression='{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"

    # Source step 0071: Click Insurance Score Consent if available | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-62c0-b9ad-e9b0b9d872db
    # Runtime control: Do [max=120] > Loop > If BAP VT > Then
    When I click or select "Insurance Score Consent"
    Then I wait until "IFRAME > Popup > Accept" exists
    When I click or select "IFRAME > Popup > Accept"
    Then I wait until "Insurance Score" exists

    # Source step 0072: Click Insurance Score and wait for Loading Window | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-6d8c-4d68-2f07c426a43c
    # Runtime control: Do [max=120] > Loop
    When I click or select "Insurance Score"

    # Source step 0073: Insurance Score | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-dba3-ee02-3503baa413fb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Condition
    Then "Reference Number" property "InnerText" should equals "\"\""

    # Source step 0074: Wait 1/2 Second for a max of 60 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-4380-87c1-5285e9b2c0eb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Loop
    When I wait "500" milliseconds

    # Source step 0078: Wait 1/2 Second | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3c33-8cfc-5b97480b4dd3
    When I wait "500" milliseconds

    # Source step 0079: Enter BOP Specific Items on Policy Info | Module: Policy Info|BOP Specific Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BOP Specific Fields | Source XTestStep: 3a13d49c-165b-3f42-d820-f4d0e35f3219
    Then if field condition "'# of Claims in the last 3 years*' == NULL" is satisfied, "# of Claims in the last 3 years*" should not exist
    Then if field condition "'Farm Bureau' == NULL" is satisfied, "Farm Bureau Question" should not exist

    # Source step 0080: Policy Info | Race and Gender Fields | Module: Policy Info|Race and Gender Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Race and Gender - Verify Fields do not exist | Source XTestStep: 3a13d49c-165b-bc77-e60b-cd1e66a81e7c
    Then "Do you wish to disclose Race and Gender Info?" should not exist

    # Source step 0081: Click Prior Loss Information Button | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9ad8-eb02-17fecdf3ef98
    When I click or select "Enter Prior Loss Information"

    # Source step 0082: Wait for Loss Experience | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-a13e-1f79-5cb9a68adbeb
    Then I wait until "Loss Experience Heading" exists

    # Source step 0083: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-8448-7600-4584fe35482e
    When I enter or select "True{TAB}" in "No known losses"
    Then "No known losses" property "value" should equals "True"

    # Source step 0084: Wait for synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-fc37-3d29-f7b92b1e33d8
    When I wait "1000" milliseconds

    # Source step 0085: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-0e76-49f9-17056c72e376
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

    # Source step 0086: Click Return to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9013-a6d2-8708e97153e2
    When I click or select "Return to Quote"

    # Source step 0087: Wait for synchronization | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-cbb8-46f1-130af0ac7391
    Then I wait until "Client" exists

    # Source step 0088: Navigate to Policy Coverage Screen | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Policy Coverage| Fill Out Commonly Required Fields | Source XTestStep: 3a13d49c-166a-8654-5e26-1dca9373baec
    When I click or select "Policy Coverage"

    # Source step 0089: Enter Number of Employees and Snow Removal Question | Module: Policy Coverage 
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Policy Coverage| Fill Out Commonly Required Fields | Source XTestStep: 3a13d49c-166a-d62b-b4d2-b5a151cf6814
    Then I wait until "Policy Coverage" exists
    When I enter or select "10{TAB}" in "NumberOfEmployees"
    When I enter or select "2{TAB}" in "NumberOfPartTimeEmployees"
    When I enter or select "1{TAB}" in "NumberOfSeasonalEmployees"
    When I enter or select "No{TAB}" in "Is the Insured engaged in any Snow or Ice Removal Operations?*"

    # Source step 0090: Verify Fields to Synch correctly | Module: Policy Coverage 
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Policy Coverage| Fill Out Commonly Required Fields | Source XTestStep: 3a13d49c-166a-7dab-a079-615df485327a
    Then "NumberOfEmployees" should be visible
    Then "NumberOfPartTimeEmployees" should be visible
    Then "NumberOfSeasonalEmployees" should be visible

    # Source step 0091: Answer Maryland Lead Question | Module: Policy Coverage 
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Policy Coverage|Answer Question related to Maryland Lead | Source XTestStep: 3a13d49c-166a-6ede-48f1-7f92e0cbccdf
    Then if field condition "'Maryland Lead' == NULL" is satisfied, "Does building(s) in Maryland contain 1 or more residential rental units?*" should not exist

    # Source step 0092: Check for LPG Transport Question | Module: Policy Coverage 
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Policy Coverage|Answer Question related to LPG Transport | Source XTestStep: 3a13d49c-166a-696c-811d-b31fa7de52fb
    Then if field condition "'LPG Transport Question' == NULL" is satisfied, "LPG Transport Question" should not exist

    # Source step 0093: Navigate to Location Screen | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-1e54-7c5a-aefe4983ab04
    Then I wait until "Location" is visible
    When I click or select "Location"

    # Source step 0094: Input Location Details | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-2ee5-ba6a-a4ed4c02ce0b
    Then I wait until "Location Heading" exists
    When I enter or select "1918 Avalon Ave{TAB}" in "Address1"
    When I enter or select "35661{TAB}" in "ZipCode"
    Then if field condition "Territory == \"Not Defaulted\"" is satisfied, I wait until "Territory" exists
    When I enter or select "101 - 250{TAB}{TAB}" in "FeetFromHydrant"
    Then if field condition "DeductibleWindstormHailPercentage != NULL" is satisfied, "DeductibleWindstormHailPercentage" property "value" should equals "1%"
    Then if field condition "'Hurricane Deductible' == NULL" is satisfied, "Hurricane Percentage Deductible" should not exist
    Then if field condition "'Named Storm Deductible' == NULL" is satisfied, "Named Storm Precentage Deductible" should not exist
    When if field condition "Territory == \"Not Defaulted\"" is satisfied, I enter or select "{CLICK}{DOWN}{TAB}" in "Territory"
    When I enter or select "5{TAB}" in "MilesFromFireDepartment"
    Then "FeetFromHydrant" property "value" should equals "101 - 250"
    When if field condition "DeductibleFixedDollar != NULL" is satisfied, I enter or select "1,000{TAB}" in "DeductibleFixedDollar"

    # Source step 0095: Verify Territory | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-d120-7a01-6028be8c226c
    # Runtime control: If Territory is not defaulted and displaying (select) [Territory == "Not Defaulted"] > Check Territory
    # Step condition: Territory == "Not Defaulted"
    Then if field condition "Territory == \"Not Defaulted\"" is satisfied, "Territory" property "Value" should equals "\"(select)\""

    # Source step 0096: Input Territory | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-4ab7-0003-075073e187ee
    # Runtime control: If Territory is not defaulted and displaying (select) [Territory == "Not Defaulted"] > Then
    # Step condition: Territory == "Not Defaulted"
    When if field condition "Territory == \"Not Defaulted\"" is satisfied, I enter or select "0{ENTER}{TAB}" in "Territory"

    # Source step 0098: Verify Brush Fire Score does not exist | Module: Location|Brush Fire Score
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-2b81-f3f9-108e33b39837
    # Step condition: 'Brush Fire Score' == NULL
    Then "Brush Fire Score*" should not exist

    # Source step 0099: Call ISO | Module: Location|Call ISO
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-c8d9-a9e3-a2365c79f167
    When I click or select "Call ISO"

    # Source step 0100: Select PPC | Module: Location|Select PPC
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-c457-1100-cdafacae0511
    When I leave "Select" blank
    When I click or select "Select PPC"

    # Source step 0101: If BCEG applies, enter BCEG details. | Module: Location|BCEG Detail
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-5084-be30-2415b7a915f3
    # Step condition: BCEG == "Applies"
    Then I wait until "BCEG Detail Heading" exists
    When I enter RUNTIME-DERIVED value "0101{DATE[][][yyyy]}{TAB}" in "DateOfLatestCertificateOfOccupancy"
    When I click or select "Select"
    Then I wait until "BCEG Value" property "InnerText" does not equal "\"\""
    When I click or select "OK"
    When I click or select "BCEG Detail"

    # Source step 0104: Click OK | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-5ae9-1349-36913e555ed6
    Then I wait until "Theft Limitations" exists
    When I click or select "OK"

    # Source step 0105: Wait for detail button | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-0e64-5cf5-9996da4ea869
    Then I wait until "Detail" exists

    # Source step 0106: Navigate to Building Screen | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building| Enter Building Info - Building Details | Source XTestStep: 3a13d49c-166a-9640-2fc7-44b60e61cc7a
    When I click or select "Building"

    # Source step 0107: Enter Building Information | Module: Building|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building| Enter Building Info - Building Details | Source XTestStep: 3a13d49c-166a-1729-a0e6-f3d9e42dc405
    When I enter or select "2001{TAB}{TAB}" in "Year Built"
    When I enter or select "2{TAB}{TAB}" in "Stories"
    When I enter or select "Asphalt/ Fiberglass Shingle{TAB}{TAB}" in "RoofType"
    When I enter or select "2009{TAB}{TAB}" in "Roof Year"
    When I enter or select "Frame{TAB}{TAB}" in "Construction"
    When I leave "Sprinkler" blank
    When I leave "Fire Burglar Alarm" blank
    When I leave "Protective Safeguards" blank
    When I enter or select "No{TAB}{TAB}" in "Prima Facie - Does this building contain any habitational occupancies?*"
    When I enter or select "{CLICK}No{TAB}{TAB}{TAB}" in "Is the building cooled?"
    When I enter or select "{CLICK}No{TAB}{TAB}{TAB}" in "Is the building heated with a Solid Fuel Heating Device?"
    When I enter or select "Test{TAB}{TAB}" in "Provide a List of Surrounding Exposure/Other Occupancies within 100 ft"

    # Source step 0108: Add First Class | Module: Building|Add Class
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building|Add Class | Add First Class | Source XTestStep: 3a13d49c-166a-17ec-222f-b614e29479eb
    When I click or select "Add Class"
    Then I wait until "Building - Add Class - Search Header" exists
    Then I wait until "Search Result*" exists
    When I enter or select "[59999] Air Conditioning Equipment - Retail Only{TAB}" in "Search Result*"
    When I enter or select "2000{TAB}" in "Occupancy Square Footage*"
    When I click or select "Continue"

    # Source step 0109: Add Additional Class | Module: Building|Add Class
    # Section: New Application - Data Entry Process | Reusable flow: BOP|StraightThrough|Building|Add Class |Add Additional Class | Source XTestStep: 3a13d49c-166a-26fc-e420-47b1e09f9bea
    When I click or select "Class Schedule"
    When I click or select "Add Occupancy"
    When I enter or select "[77070] Drilling - Water Only - Shop{TAB}" in "Search Result*"
    When I enter or select "3000{TAB}" in "Occupancy Square Footage*"
    When if field condition "Condo != NULL" is satisfied, I leave "Association Unit Owners" blank because the reusable parameter is not supplied for this iteration
    When I click or select "OK (1)"

    # Source step 0110: Wait on Add Occupancy and click OK | Module: Building|Add Class
    # Section: New Application - Data Entry Process | Reusable flow: BOP|StraightThrough|Building|Add Class |Add Additional Class | Source XTestStep: 3a13d49c-166a-9e2b-5b83-76d2589bb54c
    Then I wait until "Add Occupancy" exists
    When I click or select "OK (2)"

    # Source step 0111: Enter Other Building Details (except Functional BPP) | Module: Building|Other Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building|Other Building Details | Source XTestStep: 3a13d49c-166a-e959-3939-5f1767f19255
    When I enter or select "2500{TAB}" in "Total Building Sq. Footage"
    When I enter or select "RCT{TAB}" in "Estimator Type"
    When I enter or select "Standard RCT - Use Defaults{TAB}" in "Valuation Type"
    When if field condition "'Estimator Type' == RCT" is satisfied, I enter or select "112244{TAB}" in "ValuationID"
    When if field condition "'Estimator Type' == RCT" is satisfied, I enter or select "\"01/01/2025\"" in "Building Estimator Date"
    When I click or select "Create Valuation"

    # Source step 0112: Enter Other Building Details (except Functional BPP) | Module: Building|Other Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building|Other Building Details | Source XTestStep: 3a13d49c-166a-1fde-c6d5-22f91edf8029
    # Runtime control: Wait for Valuation ID to Populate [max=150] > Condition
    Then "Create Valuation" should exist

    # Source step 0113: Wait 1/2 Second for a max of 45 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building|Other Building Details | Source XTestStep: 3a13d49c-166a-4ee6-ec63-0ba510c0376f
    # Runtime control: Wait for Valuation ID to Populate [max=150] > Loop
    When I wait "500" milliseconds

    # Source step 0114: Enter Other Building Details (except Functional BPP) | Module: Building|Other Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building|Other Building Details | Source XTestStep: 3a13d49c-166a-76fc-00a0-bcc82081bd75
    Then I wait until "Get Calculated Value" exists
    When I click or select "Get Calculated Value"
    Then I wait until "Calculated Value Exists" property "InnerText" does not equal "0"
    When I capture "Calculated Value Returned" as runtime value "CalcValue"
    When I enter or select "185,000" in "Building Limit"
    When I click or select "Add Personal Property"
    When I enter or select "{CLICK}[59999] Air Conditioning Equipment - Retail Only{ENTER}{TAB}" in "Personal Property OccupancyID"
    When I enter or select "{CLICK}20000{ENTER}{TAB}{TAB}" in "Personal Property Limit"
    When if field condition "FunctionalBPP != NULL" is satisfied, I click or select "Add Functional Personal Property"
    When if field condition "FunctionalBPP != NULL" is satisfied, I enter or select "{CLICK}[59999] Air Conditioning Equipment - Retail Only{ENTER}{TAB}" in "Functional BPP OccupancyID"
    Then if field condition "FunctionalBPP != NULL" is satisfied, I wait until "Functional BPP OccupancyID" property "Value" equals "[59999] Air Conditioning Equipment - Retail Only"
    When if field condition "FunctionalBPP != NULL" is satisfied, I enter or select "{CLICK}20000{ENTER}{TAB}{TAB}" in "Functional BPP Limit"
    Then if field condition "FunctionalBPP != NULL" is satisfied, I wait until "Functional BPP Limit" property "Value" equals "20,000"
    When if field condition "FunctionalBPP != NULL" is satisfied, I enter or select "{Click}Test{TAB}" in "Functional BPP Description"
    Then if field condition "FunctionalBPP != NULL" is satisfied, I wait until "Functional BPP Description" property "Value" equals "TEST"
    Then "Payroll is less than the State Minimum" should exist
    When I enter or select "37,000{TAB}" in "Liability Payroll"
    Then I wait until "Payroll is less than the State Minimum" no longer exists
    Then "Payroll is less than the State Minimum" should not exist
    When I enter or select "1,000{TAB}" in "Liability Gross Sales Receipts"

    # Source step 0115: Navigate to Building Specific Coverages Screen and complete required fields | Module: Building Specific Cov'gs|Fields without sub-fields
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building Specific Coverages|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-ded0-aeb2-c9c40bb81a73
    When I click or select "Building Specific Coverages"
    Then I wait until "Building Specific Coverages Heading" exists
    When I enter or select "15,000{TAB}{TAB}" in "Accounts Receivable-On Premises Limit"

    # Source step 0116: Return to Building Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building Specific Coverages|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-db00-1067-3d1ad75442b6
    When I click or select "Return to Quote"

    # Source step 0117: Wait for building screen to load | Module: Building|Other Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Building Specific Coverages|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-6ac4-c983-a867680dc58f
    Then I wait until "Total Building Sq. Footage" exists

    # Source step 0118: Navigate to Location Screen | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible | Source XTestStep: 3a13d49c-166a-3200-7d9b-7e180d91581c
    When I click or select "Location"

    # Source step 0119: Wait for screen to appear | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible | Source XTestStep: 3a13d49c-166a-d3c5-63a3-cbf01caa2873
    Then I wait until "Location Heading" exists

    # Source step 0120: Check for Detail Button | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible | Source XTestStep: 3a13d49c-166a-63fb-69e5-44f5c190e251
    # Runtime control: If Detail button exists > Location Detail button exists
    Then "Detail" should exist

    # Source step 0121: Go to Location One Detail Screen | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible | Source XTestStep: 3a13d49c-166a-f836-24ee-9f24164d5e0b
    # Runtime control: If Detail button exists > Then
    When I click or select "Detail"

    # Source step 0122: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0123: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0124: Verify Minimum Windstorm Hail Deductible Percentage | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Wind/Hail & Deductible | Source XTestStep: 3a13d49c-166a-2d90-591e-1b8a0b22ff9f
    Then "DeductibleWindstormHailPercentage" property "value" should equals "1%"

    # Source step 0125: Wait for screen to appear | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible | Source XTestStep: 3a13d49c-166a-d070-d43e-befc97434eb5
    # Runtime control: If not on Location screen > Check if on Location screen
    Then "Location Heading" should exist

    # Source step 0126: Navigate to Location Screen | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible | Source XTestStep: 3a13d49c-166a-8934-8673-72a8c0107243
    # Runtime control: If not on Location screen > Else Click Location Tab
    When I click or select "Location"

    # Source step 0127: Wait for screen to appear | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible | Source XTestStep: 3a13d49c-166a-2197-752b-151963fc5d6c
    # Runtime control: If not on Location screen > Else Click Location Tab
    Then I wait until "Location Heading" exists

    # Source step 0128: Check for Detail Button | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible | Source XTestStep: 3a13d49c-166a-c345-b305-14c828c3e0e9
    # Runtime control: If Detail button exists > Location Detail button exists
    Then "Detail" should exist

    # Source step 0129: Go to Location One Detail Screen | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible | Source XTestStep: 3a13d49c-166a-54e6-4544-cc69a0fe7564
    # Runtime control: If Detail button exists > Then
    When I click or select "Detail"

    # Source step 0130: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0131: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0132: Verify the Fixed Deductible | Module: Location|Details
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Location|Return to verify Fixed Deductible | Source XTestStep: 3a13d49c-166a-5cde-61fb-0338d1e4a639
    Then I wait until "Location Heading" exists
    Then I wait until "DeductibleFixedDollar" exists
    Then I wait until "DeductibleFixedDollar" property "Value" does not equal "\"\""
    Then I wait until "DeductibleFixedDollar" property "Enabled" equals "True"
    Then I wait until "DeductibleFixedDollar" property "Value" does not equal "\"\""
    Then "DeductibleFixedDollar" property "value" should equals "1,000"

    # Source step 0133: Navigate to Company Endorsements | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Company Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-e1cb-bafb-90150a971c98
    When I click or select "Company Endorsements"

    # Source step 0134: Wait for Screen to appear | Module: Company Endorsements - Main
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Company Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-1d7b-cf91-f33c54bdd174
    Then I wait until "Company Endorsements" exists

    # Source step 0135: Enter Designated Work Exclusion as Yes | Module: Company Endorsements|Coverages without sub-fields
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Company Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-1430-85c2-25447f3c6451
    # Step condition: State != "CA"
    Then I wait until "Designated Work Exclusion" exists
    When I enter or select "Yes{TAB}{TAB}" in "Designated Work Exclusion"

    # Source step 0136: Employment Related Practices Liability is Yes | Module: Employment Related Practices Liability
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Company Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-d06e-7c38-ca66980d6bae
    # Step condition: (State!="RI") && (State!="VT")
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "Employment Related Practices Liability" property "value" should equals "Yes"
    When if field condition "EPLI_Default==\"Yes\"" is satisfied, I enter or select "No{TAB}" in "-- Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?*"
    When if field condition "EPLI_Default==\"Yes\"" is satisfied, I enter or select "No{ENTER}{TAB}{TAB}" in "-- Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?*"
    When if field condition "(State==\"LA\")||(State==\"AR\")||(State==\"WY\")" is satisfied, I enter or select "$50,000/$50,000/$2,500{ENTER}{TAB}{TAB}{TAB}" in "-- Limit/Deductible"
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "-- Original Inception Date" should be visible
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "-- Third Party EPL Coverage" should be visible
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "-- Limit/Deductible" should be visible

    # Source step 0137: Employment Related Practices Liability is Yes (for RI and VT) | Module: Employment Related Practices Liability
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Company Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-08f1-55a2-b73653216985
    # Step condition: (State=="RI")||(State=="VT")
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "Employment Related Practices Liability" property "value" should equals "Yes"
    When I enter or select "No{TAB}{TAB}{TAB}{TAB}" in "Employment Related Practices Liability"
    When I enter or select "Yes{TAB}{TAB}{TAB}{TAB}" in "Employment Related Practices Liability"
    When if field condition "EPLI_Default==\"Yes\"" is satisfied, I enter or select "No{TAB}" in "-- Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?*"
    When if field condition "EPLI_Default==\"Yes\"" is satisfied, I enter or select "No{TAB}" in "-- Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?*"
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "-- Limit/Deductible" should be visible
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "-- Original Inception Date" should be visible
    Then if field condition "EPLI_Default==\"Yes\"" is satisfied, "-- Third Party EPL Coverage" should be visible

    # Source step 0139: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0140: Fill Out Required Fields on Billing Screen | Module: Billing
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-315a-3b12-4a479c858c7a
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

    # Source step 0141: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0142: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0143: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0144: Navigate to Pricing Screen | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Pricing| Fill out Required Fields (New Tiering) | Source XTestStep: 3a13d49c-166a-d844-cda0-f3fa51864eb7
    When I click or select "Pricing"

    # Source step 0145: Verify Info on BOP Pricing | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Pricing| Fill out Required Fields (New Tiering) | Source XTestStep: 3a13d49c-166a-5644-458f-4ceb3b262022
    Then I wait until "Pricing Heading" exists
    Then "Tier Premium" should not exist
    Then "LossRatioComment" should not exist
    Then "RiskManagementProgramReason" should not exist
    Then "Property Tier" should exist
    Then "Liability Tier" should exist
    Then "Policy Tier Report" should exist

    # Source step 0146: Pricing Screen Sync for Premium | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: <none> | Source XTestStep: 3a199394-86c3-9a21-8b01-f31614906db3
    # Source template XTestStep: 3a199394-0e5e-1085-1f5d-f0efa9ae55bb
    When I wait "750" milliseconds

    # Source step 0147: Verify Premium Amount | Module: Pricing
    # Section: New Application - Data Entry Process > BOP|Pricing|Verify Premium_Reference | Reusable flow: <none> | Source XTestStep: 3a199394-86c3-e3f9-7725-f63e1b444bd8
    # Source template XTestStep: 3a13d49c-166a-18e3-cd3e-5078a1aa42b4
    Then I wait until "Pricing Heading" exists
    Then "Premium - Pricing Screen" property "value" should equals "*$3,322.00"

    # Source step 0148: Navigate to BOP UW Questions | Module: BOP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Underwriting Questions| Fill out BOP General UW Questions | Source XTestStep: 3a13d49c-166a-e558-c7e2-34202e3ef3a7
    When I click or select "BOP UW Questions"

    # Source step 0149: Fill out General UW Questions | Module: UW Questions - General 
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Underwriting Questions| Fill out BOP General UW Questions | Source XTestStep: 3a13d49c-166a-d100-0c13-98b04e42435d
    Then I wait until "Update UW Answers" exists
    Then I wait until "GeneralInformationNewInput.OilOrGasWellsOnYourProperty" property "value" equals "No"
    When I click or select "Update UW Answers"

    # Source step 0150: Navigate to, and fill out General Liability Questions | Module: UW Questions - Liability
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Underwriting Questions|Fill out Gen Liab Questions | Source XTestStep: 3a13d49c-166a-6a70-e3d0-2c4c5e0da9fb
    When I click or select "UW Questions - Liability"
    When I enter or select "{TAB}200,000{TAB}" in "Gross Earnings:*"
    When I enter or select "400,000{TAB}" in "Total Annual Sales:*"
    When I click or select "Update Answers"
    Then I wait until "Has any applicant ever been held liable for any injury resulting from an incident involving an animal associated with their business or on the business premises?" property "value" equals "No"
    When if field condition "'Manufacture Alcohol' != NULL" is satisfied, I enter or select "No{TAB}" in "Does the applicant/insured manufacture alcohol?*"
    When if field condition "'Dairy Products' != NULL" is satisfied, I enter or select "No{TAB}" in "Does the applicant manufacture, distribute or sell unpasteurized dairy products directly to the consumer?"

    # Source step 0151: Navigate to, and fill out UW Questions Property | Module: UW Questions - Property
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Underwriting Questions|Fill out Property Questions | Source XTestStep: 3a13d49c-166a-2ee0-5d04-a6d96fb8335c
    When I click or select "UW Questions - Property"
    Then I wait until "Is the applicant the sole occupant on the premises?" exists
    When I click or select "Update Answers"
    Then I wait until "Is the applicant the sole occupant on the premises?" property "value" equals "Yes"

    # Source step 0152: Navigate to, and fill out UW Questions Contractors | Module: UW Questions - Contractors
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Underwriting Questions|Fill out Contractors Questions | Source XTestStep: 3a13d49c-166a-e0ee-d813-d53b23dee3a2
    When I click or select "UW Questions - Contractors"
    When I enter or select "100000{TAB}" in "What limit of liability do you require from your subcontractors?"
    When I enter or select "{Click}{TAB}" in "Update Answers"
    When I enter or select "{Click}10{TAB}" in "If any new construction, advise percentage of:"

    # Source step 0153: Navigate to, and fill out UW Questions Contractors | Module: UW Questions - Contractors
    # Section: New Application - Data Entry Process | Reusable flow: BOP|Underwriting Questions|Click OK to Navigate Back to Main Menu | Source XTestStep: 3a13d49c-166a-fe02-bfef-dcd7754c913b
    When I click or select "OK"
    Then I wait until "OK" no longer exists

    # Source step 0154: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0155: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0156: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0157: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0158: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0159: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0160: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0161: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0162: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0163: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0164: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0165: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0166: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0167: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0168: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0169: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0170: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0214: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0215: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0216: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0217: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0218: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0219: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0223: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0224: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0225: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0226: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0227: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0228: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0229: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0230: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0274: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0275: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0276: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0277: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0278: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0279: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0280: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0281: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0295: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "3,322.00" as runtime value "NBPrem"

    # Source step 0296: Verify Premiums | Module: Submission|Premiums
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "3,322.00"
    Then "Premium Written" property "value" should equals "3,322.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "3,322.00"

    # Source step 0297: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0298: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0299: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0300: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0301: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0302: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0303: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOP\\BOP_BASIC_AL_{B[QuoteID]}.xml"

    # Source step 0309: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0310: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOP\\\" -FileName \"BOP_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0311: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0312: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0313: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0314: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0315: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0316: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0317: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0318: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0319: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0321: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0322: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0323: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0324: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0325: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0066: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0067: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0075: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:56 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-d800-16b1-204343afb7e1
#    - INPUT "Duration" with "1500"
# Source step 0076: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 14.04.20 08:18:24 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-06ca-978e-d5200f0622bb
#    - WAIT (Exists) "Insurance Score" with "False"
# Source step 0077: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:31 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3a41-fade-9ac567a11717
#    - INPUT "Duration" with "1500"
# Source step 0171: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0172: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0173: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0174: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0175: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0176: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0177: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0178: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0179: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0180: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0181: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0182: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0183: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0184: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0185: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0186: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0187: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0188: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0189: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0190: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0191: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0192: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0193: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0194: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0195: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0196: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0197: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0198: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0199: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0200: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0201: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0202: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0203: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0204: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0205: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0206: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0207: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0208: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0209: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0210: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0211: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0212: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0213: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0231: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0232: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0233: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0234: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0235: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0236: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0237: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0238: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0239: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0240: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0241: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0242: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0243: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0244: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0245: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0246: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0247: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0248: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0249: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0250: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0251: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0252: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0253: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0254: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0255: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0256: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0257: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0258: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0259: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0260: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0261: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOP\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0262: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOP\\"
# Source step 0263: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0264: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0265: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0266: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0267: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0268: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0269: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0270: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0271: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0272: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0273: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0282: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0283: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0284: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0285: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0286: "Submission, select Policy Forms" in module "Submission, select Policy Forms" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-b954-0a7c-e98a92e77430
#    - INPUT "Policy Forms" with "x"
#    - WAIT (Exists) "Search" with "True"
#    - INPUT "Search for DEC Page" with "Declaration"
#    - INPUT "Search Button for DEC Page" with "x"
#    - INPUT "DEC LINK" with "x"
# Source step 0287: "Wait for Policy Forms to open" in module "TBox Wait" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8889-6242-e08fb28d4f40
#    - INPUT "Duration" with "9000"
# Source step 0288: "Close Policy Forms" in module "TBox Send Keys" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-582d-aae0-ba158c28662e
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0289: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-9a96-581e-d2b119b0020a
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0290: "Return to Submission Page" in module "Common Navigation Links" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8902-2720-581821968d05
#    - INPUT "Return to Policy" with "x"
# Source step 0291: "Submission, select Policy Admin Forms" in module "Submission, select Policy Forms" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-dcfb-265b-775fb7492386
#    - WAIT (Visible) "Policy Admin Forms" with "True"
#    - INPUT "Policy Admin Forms" with "x"
# Source step 0292: "Wait for Policy Admin Forms to open" in module "TBox Wait" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-5130-737f-d02663cba9f8
#    - INPUT "Duration" with "15000"
# Source step 0293: "Close Policy Admin Forms" in module "TBox Send Keys" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-c820-c654-7878ba2a4c1c
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0294: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 26.06.19 11:35:41 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-a6a9-8ecd-59b80f1bea38
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0304: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0305: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0306: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0307: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOP\\BOP_BASIC_AL_{B[QuoteID]}.xml"
# Source step 0308: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-878b-57be-a03b92d53f46
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOP\\BOP_BASIC_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0320: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  BusinessOwners  Pages   US   4.3.0.0{ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0041 "Select Individual Sole Proprietor" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
# Active source step 0059 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
# Active source step 0061 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
# Active source step 0063 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0079 "Enter BOP Specific Items on Policy Info" contains conditionally inapplicable field action(s):
#    - INPUT "# of Claims in the last 3 years*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: # of Claims in the last 3 years*>{ENTER}{TAB})" when '# of Claims in the last 3 years*' != NULL. Reason: Value condition evaluated false for the selected iteration: '# of Claims in the last 3 years*' != NULL
#    - INPUT "Farm Bureau Question" with "{CLICK}Yes{ENTER}{TAB}" when 'Farm Bureau' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Farm Bureau' != NULL
# Active source step 0091 "Answer Maryland Lead Question" contains conditionally inapplicable field action(s):
#    - INPUT "Does building(s) in Maryland contain 1 or more residential rental units?*" with "No{TAB}" when 'Maryland Lead' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Maryland Lead' != NULL
# Active source step 0092 "Check for LPG Transport Question" contains conditionally inapplicable field action(s):
#    - INPUT "LPG Transport Question" with "Yes{TAB}" when 'LPG Transport Question' != NULL. Reason: Value condition evaluated false for the selected iteration: 'LPG Transport Question' != NULL
# Active source step 0094 "Input Location Details" contains conditionally inapplicable field action(s):
#    - VERIFY (Exists) "DeductibleWindstormHailPercentage" with "False" when DeductibleWindstormHailPercentage == NULL. Reason: Value condition evaluated false for the selected iteration: DeductibleWindstormHailPercentage == NULL
#    - VERIFY "Hurricane Percentage Deductible" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Hurricane Deductible>)" when 'Hurricane Deductible' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Hurricane Deductible' != NULL
#    - VERIFY "Named Storm Precentage Deductible" with "a blank/null value" when 'Named Storm Deductible' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Named Storm Deductible' != NULL
# Source step 0097: "Brush Fire Score" in module "Location|Brush Fire Score" was not executed. Reason: Selected-iteration condition evaluated false: 'Brush Fire Score' != NULL
# Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-1357-f929-b08b77aa37a3
#    - Preserved source field action: INPUT "Brush Fire Score*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Brush Fire Score>)"
# Source step 0102: "If BCEG applies, but no result returned, enter date and verify no select button." in module "Location|BCEG Detail" was not executed. Reason: Selected-iteration condition evaluated false: BCEG == "No Return"
# Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-eafd-10a2-add01645ee6c
#    - Preserved source field action: INPUT "BCEG Detail" with "X"
#    - Preserved source field action: INPUT "DateOfLatestCertificateOfOccupancy" with "the RUNTIME-DERIVED source value 0101{DATE[][][yy]}"
#    - Preserved source field action: VERIFY (Exists) "Select" with "False"
#    - Preserved source field action: WAIT (InnerText) "BCEG Value" with "NULL"
#    - Preserved source field action: INPUT "OK" with "X"
# Source step 0103: "If BCEG does not apply, verify BCEG button does not exist." in module "Location|BCEG Detail" was not executed. Reason: Selected-iteration condition evaluated false: BCEG == NULL
# Section: New Application - Data Entry Process | Reusable flow: BOP|Location| Add a single location | Source XTestStep: 3a13d49c-166a-eef0-98de-fb3591053320
#    - Preserved source field action: VERIFY (Exists) "BCEG Detail" with "False"
# Active source step 0109 "Add Additional Class" contains conditionally inapplicable field action(s):
#    - INPUT "# of Units*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: # of Units>{TAB}{TAB})" when '# of Units' != NULL. Reason: Value condition evaluated false for the selected iteration: '# of Units' != NULL
#    - INPUT "Number of Rented Living Quarters*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Number of Rented Living Quarters>)" when 'Number of Rented Living Quarters' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Number of Rented Living Quarters' != NULL
#    - INPUT "Alert Box > OK" with "x" when 'Class Code 1'=="[64181] Veterinarians Office - Office". Reason: Value condition evaluated false for the selected iteration: 'Class Code 1'=="[64181] Veterinarians Office - Office"
# Active source step 0111 "Enter Other Building Details (except Functional BPP)" contains conditionally inapplicable field action(s):
#    - INPUT "BVS Search Result" with "2121 - Office, Low-Rise, Shell{TAB}" when 'Estimator Type' == BVS. Reason: Value condition evaluated false for the selected iteration: 'Estimator Type' == BVS
# Active source step 0114 "Enter Other Building Details (except Functional BPP)" contains conditionally inapplicable field action(s):
#    - VERIFY (Exists) "Add Functional Personal Property" with "False" when FunctionalBPP == NULL. Reason: Value condition evaluated false for the selected iteration: FunctionalBPP == NULL
# Active source step 0132 "Verify the Fixed Deductible" contains conditionally inapplicable field action(s):
#    - VERIFY "Named Storm Precentage Deductible" with "a blank/null value" when 'Named Storm Deductible' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Named Storm Deductible' != NULL
# Source step 0138: "Employment Related Practices Liability is No" in module "Employment Related Practices Liability" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: BOP|Company Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-ffb1-7d5e-475295bd9ef7
#    - Preserved source field action: VERIFY "Employment Related Practices Liability" with "No" when EPLI_Default=="No"
#    - Preserved source field action: VERIFY (Exists) "-- Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?*" with "False" when EPLI_Default=="No"
#    - Preserved source field action: VERIFY (Exists) "-- Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?*" with "False" when EPLI_Default=="No"
# Active source step 0149 "Fill out General UW Questions" contains conditionally inapplicable field action(s):
#    - INPUT "Gen UW ApplicantOwn - Smart UW Special" with "{TAB}Yes - Insured with American National{TAB}" when 'BOP Smart' != NULL. Reason: Value condition evaluated false for the selected iteration: 'BOP Smart' != NULL
#    - VERIFY (Value) "Gen UW ApplicantOwn - Smart UW Special" with "Yes - Insured with American National" when 'BOP Smart' != NULL. Reason: Value condition evaluated false for the selected iteration: 'BOP Smart' != NULL
# Active source step 0150 "Navigate to, and fill out General Liability Questions" contains conditionally inapplicable field action(s):
#    - INPUT "Engaged in Tobacco Store Operations - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Tobacco Store Operations Class>{TAB})" when 'Tobacco Store Operations Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Tobacco Store Operations Class' != NULL
#    - INPUT "Engaged in Medical Equipment Sales - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Medical Equipment Sales Class>{TAB})" when 'Medical Equipment Sales Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Medical Equipment Sales Class' != NULL
#    - INPUT "Does the applicant/insured sell-second hand baby/toddler clothing? - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Secondhand Clothes Sales Class>{TAB})" when 'Secondhand Clothes Sales Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Secondhand Clothes Sales Class' != NULL
#    - INPUT "Does the applicant/insured raise, distribute, or sell shellfish with the intent to be consumed raw, outside of an incidental exposure? - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Shellfish Class>{TAB})" when 'Shellfish Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Shellfish Class' != NULL
#    - INPUT "Does the applicant/insured sell used or reconditioned equipment? - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Used or Reconditioned Equipment Sales Class>{TAB})" when 'Used or Reconditioned Equipment Sales Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Used or Reconditioned Equipment Sales Class' != NULL
#    - INPUT "Is rental of hardware, equipment, and/or tools to others greater than 10%? - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Equipment Tools Rental to Others Class>{TAB})" when 'Equipment Tools Rental to Others Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Equipment Tools Rental to Others Class' != NULL
#    - INPUT "Does the applicant/insured operate out of their residence with the public coming on the premises? - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Operate out of residence Class>{TAB})" when 'Operate out of residence Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Operate out of residence Class' != NULL
#    - INPUT "Is the applicant/insured involved in the distribution, sale, service, or repair of firearms? - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Firearms Class>{TAB})" when 'Firearms Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Firearms Class' != NULL
#    - INPUT "Does the applicant/insured manufacture or sell re- treaded tires or recapped tires?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Retread Tires Class>{TAB})" when 'Retread Tires Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Retread Tires Class' != NULL
#    - INPUT "Does the applicant/insured perform automobile/heavy equipment service or repair? (Not including incidental auto parts store services--windshield wiper install, headlight bulb replacement, etc.)* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Auto Heavy Equip Class>{TAB})" when 'Auto Heavy Equip Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Auto Heavy Equip Class' != NULL
#    - INPUT "Does the applicant/insured manufacture, refurbish, rebuild, or alter parts?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Refurbish Rebuild Class>{TAB})" when 'Refurbish Rebuild Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Refurbish Rebuild Class' != NULL
#    - INPUT "Does the risk have fireworks sales in excess of 10% and/or the type sold is not limited to “consumer fireworks”?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Fireworks Class>{TAB})" when 'Fireworks Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Fireworks Class' != NULL
#    - INPUT "Does the applicant/insured offer emergency towing/roadside services?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Towing Class>{TAB})" when 'Towing Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Towing Class' != NULL
#    - INPUT "Does the applicant/insured publish any newspapers, periodicals or books?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Newspaper Class>{TAB})" when 'Newspaper Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Newspaper Class' != NULL
#    - INPUT "Does the applicant/insured sell ammunition or gun powder with sales exceeding 20% of their gross sales?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Ammunition Class>{TAB})" when 'Ammunition Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Ammunition Class' != NULL
#    - INPUT "Are the annual gross sales derived from retail operations greater than 25%?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Wholesale Class>{TAB})" when 'Wholesale Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Wholesale Class' != NULL
#    - INPUT "Is the percentage of total floor area open to the public greater than 25%?* - Smart UW Special" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Wholesale Class>{TAB})" when 'Wholesale Class' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Wholesale Class' != NULL
#    - INPUT "Do total annual sales at any one location exceed $10,000,000?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Annual Sales 10M>{TAB})" when 'Annual Sales 10M' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Annual Sales 10M' != NULL
# Active source step 0152 "Navigate to, and fill out UW Questions Contractors" contains conditionally inapplicable field action(s):
#    - INPUT "Do you work in the state of New York?*" with "No{TAB}" when 'NY State work' != NULL. Reason: Value condition evaluated false for the selected iteration: 'NY State work' != NULL
# Source step 0220: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0221: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0222: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a199394-861d-a147-99a2-2cb4ddb78ea6
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BOP\\BOP BASIC TestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a199394-863c-7910-6658-4620703e85cd
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BOP\\BOP BASIC TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a199394-863c-6311-e813-d94571cea670
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BOP\\BOP BASIC TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a199394-863c-a9f3-73e9-8c6f5b428f75
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a199394-863c-d7ff-cff2-f578d7a62a26
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a199394-863c-9df4-ba4f-a3ef518ffd0a
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a199394-863c-b7ca-5e9f-e2e9eceec251
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a199394-863c-7c97-01c5-a524825d5cd0
#    - I run "taskkill /f /im msEdge.exe"
