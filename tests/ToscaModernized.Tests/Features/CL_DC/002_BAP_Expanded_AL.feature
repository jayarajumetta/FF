# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 002_BAP_Expanded_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @BAP @expanded @Alabama @Edge @manual @automated
Feature: Execute BAP | Expanded for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the BAP | Expanded workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: BAP | Expanded using representative iteration Alabama (AL)

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
    When I retain hard-coded value "BAP_StraightThrough" as runtime value "FormOnPolicyDocName"

    # Source step 0051: Check if on Client | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-2cd4-70ba-6eba4e39d0f5
    # Runtime control: If not on Client screen > Condition
    Then "Client" should not exist

    # Source step 0052: Navigate to Client | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-0d5c-9292-cf12ab39ab82
    # Runtime control: If not on Client screen > Then
    When I click or select "Client"

    # Source step 0053: Small wait for refresh | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-c4c7-c417-1bc9e793539e
    When I wait "3000" milliseconds

    # Source step 0054: Click Third Party Designee | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-d1dc-bbd9-34d3efaca3ab
    When I click or select "Third Party Designee"

    # Source step 0055: Add Third Party info | Module: Client|Third Party Designee|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-182a-e50c-41abb9e60015
    Then I wait until "Heading Third Party Designee" exists
    When I click or select "Add Third Party"
    Then I wait until "AdditionalOtherInterestInput.FirstName" exists
    When I enter or select "{TAB}Mary Beth{CLICK}" in "AdditionalOtherInterestInput.FirstName"
    Then I wait until "AdditionalOtherInterestInput.LastName" exists
    When I enter a RANDOM value matching "^[a-z]{15}$" in "AdditionalOtherInterestInput.LastName"
    When I enter or select "100 Bridge St{TAB}" in "AdditionalOtherInterestInput.Address1"
    When I enter or select "12158{TAB}" in "Zip Code*"

    # Source step 0056: Confirm Addition | Module: Client|Third Party Designee|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-ae9c-15c7-378d82ad5592
    When I click or select "OK"

    # Source step 0057: Wait for synchronization | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Third Party Designee | Source XTestStep: 3a13d49c-165b-c562-cd87-0fd16e068eba
    Then I wait until "Client" exists

    # Source step 0058: Check if on Client | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-54ac-4718-6655430ddf8d
    # Runtime control: If not on Client screen > Condition
    Then "Client" should not exist

    # Source step 0059: Navigate to Client | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-97b9-c6b1-ffe65682850c
    # Runtime control: If not on Client screen > Then
    When I click or select "Client"

    # Source step 0060: Click Additional Named Insured | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-75f0-8e55-f7ed7b213d85
    When I click or select "Additional Named Insured"

    # Source step 0061: Wait for synchronization | Module: Client|Additional Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-d6f5-05ee-e6ce04e326a2
    Then I wait until "Additional Named Insured Heading" exists

    # Source step 0062: Enter Individual info | Module: Client|Additional Insured|Individual
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-356b-45ff-f8cba5ab2192
    # Step condition: Individual != NULL
    When I click or select "Add Named Insured - Individual"
    Then I wait until "Additional Insured First Name" exists
    When I enter or select "{TAB}John{TAB}" in "Additional Insured First Name"
    When I enter or select "Michael{TAB}" in "Additional Insured Middle Name"
    When I enter a RANDOM value matching "^[a-z]{15}$" in "Additional Insured Last Name"
    When I click or select "Detail"

    # Source step 0064: Enter Individual Address info | Module: Client|Additional Insured|Individual
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-bd17-f37b-91a04fab916e
    # Step condition: Individual != NULL
    Then I wait until "Address 1*" exists
    When I enter or select "{TAB}100 Bridge St{TAB}{TAB}" in "Address 1*"
    When I enter or select "12158{TAB}{TAB}" in "Zip code*"

    # Source step 0066: Enter DOB | Module: Client|Additional Insured|Individual
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-a1cc-1f36-6a795bd9ffed
    # Step condition: Individual != NULL
    When I enter or select "{CLICK}01/01/1980{TAB}" in "Date Of Birth*"

    # Source step 0067: Perform Client Search | Module: Client|Additional Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-6d6d-20ae-f3d36d13856d
    When I click or select "Client Search"
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0068: Order SSN | Module: Client|Additional Insured|Individual
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-92c0-3a03-b9afdf4a3ef3
    # Step condition: Individual != NULL
    When I click or select "Order SSN"
    Then I wait until "SSN was not returned*" exists

    # Source step 0069: Enter SSN | Module: Client|Additional Insured|Individual
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-ec8b-6542-d7790d50d81e
    # Step condition: Individual != NULL
    When I enter a RANDOM value matching "6 random digits/characters from source expression {TAB}025{RND[6]}{TAB}{TAB}{TAB}" in "Enter SSN*"
    Then I wait until "Enter SSN*" exists
    When I enter or select "{Doubleclick}{TAB}{TAB}" in "Enter SSN*"
    When I click or select "Verify"
    Then I wait until "Verify" no longer exists

    # Source step 0070: Confirm entries | Module: Client|Additional Insured|Individual
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-beba-cf35-98e60c11ab1c
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "OK"

    # Source step 0071: Return to Client | Module: Client|Additional Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-0c5b-f48c-7db87bf9064c
    Then I wait until "Return to Client" exists
    When I click or select "Return to Client"

    # Source step 0072: Wait for synchronization | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-e323-0200-c0c7ad7e2856
    Then I wait until "Client" exists

    # Source step 0074: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0075: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0076: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0077: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0078: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "09-05-2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0079: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0080: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0081: State is Kansas | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0082: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
    # Runtime control: If State is Kansas > Then
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "(select){ENTER}{TAB}{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0083: State is Virginia | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0084: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
    # Runtime control: If State is Virginia > Then
    When if field condition "'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0085: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0086: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0087: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0088: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL BAP StraightThrough {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0091: Loop if OK button does not exist | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d421a-6706-8f18-ed07-8d5243080055
    # Runtime control: Do (Enter NAICS Code) [max=15] > Condition
    Then "OK" should not exist

    # Source step 0092: Enter NAICS Code | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d66-7338-0748-26cd8498b8ba
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I enter or select "{CLICK}CONSTRUCTION SAND AND GRAVEL MINING [212321]{TAB}{TAB}" in "NAICS Code Search Value*"

    # Source step 0093: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d68-fe85-e69f-3e66e032d667
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I wait "1000" milliseconds

    # Source step 0094: Enter NAICS Code | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d71-17dc-60e7-31193c7fbf26
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I enter or select "{CLICK}Construction Sand and Gravel Mining [212321]{TAB}{TAB}" in "NAICS Code Search Results*"

    # Source step 0095: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-3d74-51ec-c251-d5ca81666155
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I wait "1000" milliseconds

    # Source step 0096: Enter Account Credit | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d4217-f3bb-6129-72b0-6a45a877373e
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    # Step condition: State != "NY"
    When if field condition "State != \"NY\"" is satisfied, I enter or select "No{TAB}{TAB}" in "Account Credit"

    # Source step 0097: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d421a-1bb8-8d9b-f9e4-968bde11e68f
    # Runtime control: Do (Enter NAICS Code) [max=15] > Loop
    When I wait "1000" milliseconds

    # Source step 0098: Click OK | Module: Policy Info|BAP Specific Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Fill Out BAP Specific Fields | Source XTestStep: 3a1d421b-92a3-b6fe-f155-0ed531969933
    Then I wait until "OK" exists
    When I click or select "OK"
    Then I wait until "OK" no longer exists

    # Source step 0099: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-db96-2f0e-1e230bb9a656
    When I wait "1500" milliseconds

    # Source step 0100: Insurance Score | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-84af-bc6a-3f9f6e937252
    # Runtime control: Do [max=120] > Condition
    Then "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS" should exist

    # Source step 0101: Check if it is BAP VT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-faf3-28ce-cca724db461f
    # Runtime control: Do [max=120] > Loop > If BAP VT > Condition
    Then I evaluate the source-defined expression for "Check if it is BAP VT" using "Expression='{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"

    # Source step 0102: Click Insurance Score Consent if available | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-62c0-b9ad-e9b0b9d872db
    # Runtime control: Do [max=120] > Loop > If BAP VT > Then
    When I click or select "Insurance Score Consent"
    Then I wait until "IFRAME > Popup > Accept" exists
    When I click or select "IFRAME > Popup > Accept"
    Then I wait until "Insurance Score" exists

    # Source step 0103: Click Insurance Score and wait for Loading Window | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-6d8c-4d68-2f07c426a43c
    # Runtime control: Do [max=120] > Loop
    When I click or select "Insurance Score"

    # Source step 0104: Insurance Score | Module: Policy Info|Insurance Score
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-dba3-ee02-3503baa413fb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Condition
    Then "Reference Number" property "InnerText" should equals "\"\""

    # Source step 0105: Wait 1/2 Second for a max of 60 seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-4380-87c1-5285e9b2c0eb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Loop
    When I wait "500" milliseconds

    # Source step 0109: Wait 1/2 Second | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3c33-8cfc-5b97480b4dd3
    When I wait "500" milliseconds

    # Source step 0110: Click Prior Loss Information Button | Module: Policy Info|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9ad8-eb02-17fecdf3ef98
    When I click or select "Enter Prior Loss Information"

    # Source step 0111: Wait for Loss Experience | Module: Underwriting Info | Loss Experience
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-a13e-1f79-5cb9a68adbeb
    Then I wait until "Loss Experience Heading" exists

    # Source step 0112: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-8448-7600-4584fe35482e
    When I enter or select "True{TAB}" in "No known losses"
    Then "No known losses" property "value" should equals "True"

    # Source step 0113: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-fc37-3d29-f7b92b1e33d8
    When I wait "1000" milliseconds

    # Source step 0114: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
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

    # Source step 0115: Click Return to Quote | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-9013-a6d2-8708e97153e2
    When I click or select "Return to Quote"

    # Source step 0116: Wait for synchronization | Module: Client|Named Insured|Common
    # Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Underwriting Info - Complete from Policy Info Screen | Source XTestStep: 3a13d49c-165b-cbb8-46f1-130af0ac7391
    Then I wait until "Client" exists

    # Source step 0117: Navigate to Policy Coverage | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Policy Covg > BAP|Policy Covg|Complete Required Info_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13e5-7bf6-dd06-c29366c9cafc
    # Source template XTestStep: 3a13d49c-165b-d215-ddb4-2ff21465f162
    Then I wait until "Policy Covgerage" exists
    When I click or select "Policy Covgerage"

    # Source step 0118: Add coverages | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > Policy Covg > BAP|Policy Covg|Complete Required Info_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13e5-a420-2441-ac935f1d0837
    # Source template XTestStep: 3a13d49c-165b-9204-fbce-76b661d0e368
    Then I wait until "Policy Covg" exists
    When I enter or select "{Click}0{ENTER}{TAB}" in "Trailer Interchange Comp Deductible"
    When I enter or select "{Click}100{ENTER}{TAB}" in "Trailer Interchange Collision Deductible"

    # Source step 0119: Wait for Synchronization | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > Policy Covg > BAP|Policy Covg|Complete Required Info_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-13e5-51a8-2e27-9c04a9c70308
    # Source template XTestStep: 3a13d49c-165b-d89a-b853-d5dd3de433a9
    Then I wait until "Policy Covg" exists

    # Source step 0120: CT StraightThrough Liability Limit to 1M | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: <none> | Source XTestStep: 3a13d49c-13e5-bd2d-7df5-ac17f95d7132
    # Source template XTestStep: 3a13d49c-13a9-46ae-589e-18b66c317bbc
    When I perform source-defined action "CT StraightThrough Liability Limit to 1M" in module "Policy Coverage|Limits"

    # Source step 0121: Check if on Policy Covg | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add NonOwnership Liability | Source XTestStep: 3a13d49c-165b-3408-1e1e-30405fd73248
    # Runtime control: If not on Policy Coverage > Condition
    Then "Policy Covg" should not exist

    # Source step 0122: Navigate to Policy Covg | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add NonOwnership Liability | Source XTestStep: 3a13d49c-165b-0c1c-0191-78022b2ebc85
    # Runtime control: If not on Policy Coverage > Then
    When I click or select "Policy Covgerage"

    # Source step 0123: Enter Nonownership selections | Module: Policy Coverage|NonOwned
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add NonOwnership Liability | Source XTestStep: 3a13d49c-165b-ffd3-fac9-2b6c66bbe855
    When I enter or select "{Click}Yes{TAB}" in "Non Owned Auto"
    Then I wait until "# of Employees" exists
    When I enter or select "{TAB}2{TAB}" in "# of Employees"
    When I enter or select "{TAB}2{TAB}" in "# of Partners"
    When I enter or select "{Click}Yes{TAB}" in "Extended Employee Coverage"

    # Source step 0124: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add NonOwnership Liability | Source XTestStep: 3a13d49c-165b-efd6-6f3a-47c1ee10c70d
    When I wait "1000" milliseconds

    # Source step 0125: Check if on Policy Covg | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-d4fc-15bd-b4f7a08a5ef0
    # Runtime control: If not on Policy Coverage > Condition
    Then "Policy Covg" should not exist

    # Source step 0126: Navigate to Policy Covg | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-8170-d55d-ef80fb6a9f62
    # Runtime control: If not on Policy Coverage > Then
    When I click or select "Policy Covgerage"

    # Source step 0127: Select Business Interruption | Module: Policy Coverage|Business Interruption
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-da6c-99e7-126b6a1b89f9
    When I enter or select "{Click}Yes{TAB}" in "Business Interruption Endorsement"
    Then I wait until "Detail" exists

    # Source step 0128: Select form and options | Module: Policy Coverage|Business Interruption
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-1b0b-daa5-8b95e8ed4a83
    When I click or select "Detail"
    Then I wait until "Business Interruption Detail" exists
    When I enter or select "{TAB}{TAB}" in "Description Of Business Activites*"
    When I click or select "Option A CheckBox "
    Then I wait until "Option A Schedule Button" exists
    When I enter or select "Business Activities{TAB}{TAB}" in "Description Of Business Activites*"

    # Source step 0129: Choose Option A | Module: Policy Coverage|Business Interruption
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-5e32-72d1-906c12af2df0
    When I click or select "Option A Schedule Button"

    # Source step 0130: List Schedule Property | Module: Policy Coverage|Business Interruption|Option A Schedule
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-fa9d-2f31-c4b20ac99128
    Then I wait until "IFRAME > Duck Creek Policy > Option A" exists
    When I click or select "IFRAME > Duck Creek Policy > Add Option A"
    Then I wait until "IFRAME > Duck Creek Policy > Business Interruption Limit Of Insurance" exists
    When I enter or select "100,000{TAB}" in "IFRAME > Duck Creek Policy > Business Interruption Limit Of Insurance"
    When I perform keyboard action "{TAB}" on "IFRAME > Duck Creek Policy > Business Interruption Description Of ScheduledProperty"
    When I enter or select "Scheduled Property{TAB}" in "IFRAME > Duck Creek Policy > Business Interruption Description Of ScheduledProperty"

    # Source step 0131: Confirm addition | Module: Policy Coverage|Business Interruption|Option A Schedule
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-39bb-82c4-3558637ce69b
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0132: Short static wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-9d11-9206-79b3e9d7f3f6
    When I wait "1000" milliseconds

    # Source step 0133: Check for IFRAME | Module: Policy Coverage|Business Interruption|Option A Schedule
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-44f9-76a4-08872ee13d86
    # Runtime control: If IFRAME exists, wait for it to close > If IFRAME Exists
    Then "IFRAME" should exist

    # Source step 0134: Wait for IFRAME to close | Module: Policy Coverage|Business Interruption|Option A Schedule
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-9647-1da6-59f7823c99e5
    # Runtime control: If IFRAME exists, wait for it to close > Then wait for it to close
    Then I wait until "IFRAME" no longer exists

    # Source step 0135: Return to Policy Covg | Module: Policy Coverage|Business Interruption
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-7ff0-b516-f7bf4561689c
    When I click or select "OK"

    # Source step 0136: Wait for synchronization | Module: Policy Coverage|Limits
    # Section: Policy Data Entry Process > Policy Covg | Reusable flow: BAP|Add Business Interruption | Source XTestStep: 3a13d49c-165b-8095-57b2-72a7c9adfac7
    Then I wait until "Policy Covg" exists

    # Source step 0137: Navigate to Location | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Location|Complete Required Info | Source XTestStep: 3a13d49c-165b-0cc7-b2c1-9e8122aa1d7c
    Then I wait until "Location" exists
    When I click or select "Location"

    # Source step 0138: Wait for Synchronization | Module: Location
    # Section: Policy Data Entry Process | Reusable flow: BAP|Location|Complete Required Info | Source XTestStep: 3a13d49c-165b-59cb-beea-fcf92a72e6cd
    Then I wait until "Location" exists
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0139: Navigate to State Details | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage | Source XTestStep: 3a13d49c-165b-109c-0647-4008aa6f18b1
    When I click or select "State Details"
    Then I wait until "State Details - Detail" exists
    When I click or select "State Details - Detail"
    Then I wait until "State Details - Detail" no longer exists

    # Source step 0140: Wait for synchronization | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage | Source XTestStep: 3a13d49c-165b-24f6-919a-9fb14adfffb7
    Then I wait until "OK" is visible

    # Source step 0141: Enter Basic UM info | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage | Source XTestStep: 3a13d49c-165b-2f53-0b2c-49c2d57dab59
    Then I wait until "State Details" exists
    When if field condition "'UM Type Default' != NULL" is satisfied, I enter or select "{CLICK}UMBI CSL{RETURN}{TAB}{TAB}{TAB}" in "UM Type Default Selections"
    When if field condition "'UMBI Limit' != NULL AND 'UM Type Default' != \"UMBIPD CSL\"" is satisfied, I enter or select "{CLICK}50,000{TAB}{TAB}{TAB}" in "UMBI Limit*"

    # Source step 0142: Enter Basic UIM info | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage | Source XTestStep: 3a13d49c-165b-8dcf-0d62-39e7dc1e99a7
    Then I wait until "State Details" exists
    Then "OK" should exist

    # Source step 0143: Check for Loading Indicator | Module: Indicators and Errors
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0144: Wait 2 secs | Module: TBox Wait
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0145: Confirm Changes | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage | Source XTestStep: 3a13d49c-165b-a597-cd74-f5709b17c6c6
    When I click or select "OK"

    # Source step 0146: Wait for return to State Details | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add UM/UIM Coverage | Source XTestStep: 3a13d49c-165b-9b83-66b8-46f7671be3eb
    Then I wait until "State Details - Detail" exists

    # Source step 0147: Navigate to State Details | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-b38c-3a55-0de7eb20e944
    When I click or select "State Details"
    Then I wait until "State Details - Detail" exists
    When I click or select "State Details - Detail"
    Then I wait until "State Details - Detail" no longer exists

    # Source step 0148: Wait for synchronization | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-e414-4f0a-75542902aa2f
    Then I wait until "OK" is visible

    # Source step 0149: Add Hired Auto Liability | Module: State Details|Hired Auto Liability
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-007b-1275-68f1da4546a0
    # Step condition: State != "CA"
    When I click or select "Hired Auto Liability"
    When I click or select "Primary Liability If Any"
    When I click or select "Excess Liability If Any"
    When I click or select "Employee Hired Autos CheckBox"
    When I click or select "Volunteer Hired Autos CheckBox"

    # Source step 0151: TBox Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-2a98-0589-e10886f725e2
    When I wait "1000" milliseconds

    # Source step 0152: Add Drive Other Car | Module: State Details|Drive Other Car
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-31d4-6a13-f419388a3215
    # Step condition: 'Add Drive Other Car' != NULL
    When I click or select "Drive Other Car"
    When I click or select "Comprehensive"
    Then I wait until "OTC Deductible" exists
    When I click or select "Collision"
    Then I wait until "Collision Deductible" exists
    When I perform keyboard action "{TAB}" on "First Name"
    When I enter or select "Jones{TAB}" in "Last Name"
    When I enter or select "John{TAB}" in "First Name"

    # Source step 0153: TBox Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-034c-4705-27b10644dc81
    When I wait "1000" milliseconds

    # Source step 0154: Add Hired Auto PD Without Driver | Module: State Details|Hired Auto PD Without Driver
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-1380-1eb5-0df809380f82
    # Step condition: State != "CA"
    When I click or select "Hired Auto Physical Damage Without Driver"
    When I enter or select "{Click}$50{TAB}" in "OTC Deductible*"
    When I click or select "OTC If Any"
    When I enter or select "{TAB}$100{TAB}{TAB}" in "Collision Deductible*"
    When I click or select "Collision If Any"

    # Source step 0156: TBox Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-d46b-efe8-f194191bdf68
    When I wait "1000" milliseconds

    # Source step 0157: Add Hired Auto PD With Driver | Module: State Details|Hired Auto Physical Damage With Driver
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-d9f9-fe1d-71380f0d7acf
    # Step condition: State != "CA"
    When I click or select "Hired Auto Physical Damage With Driver"
    When I enter or select "{Click}$50{TAB}{TAB}" in "OTC Deductible*"
    When I click or select "OTC If Any"
    When I enter or select "{CLICK}$100{ENTER}{TAB}{TAB}" in "Collision Deductible*"
    When I click or select "Collision If Any"
    When I enter or select "2018 Subaru Forester{TAB}{TAB}" in "Vehicle Information"

    # Source step 0160: TBox Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-1af5-4473-628a24c82943
    When I wait "1000" milliseconds

    # Source step 0162: Confirm Addition | Module: State Details|UM/UIM
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-cfac-bb4b-746a6bf668c5
    When I click or select "OK"

    # Source step 0163: Check for loading mask | Module: Indicators and Errors
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-341f-0fc3-8d469a8c2f52
    # Runtime control: If loading mask is present, wait > If loading mask is present
    Then "Loading Message" should exist

    # Source step 0164: Wait for mask to go away | Module: Indicators and Errors
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-5204-807b-cbf9570838e9
    # Runtime control: If loading mask is present, wait > Then wait for loading mask to disappear
    Then I wait until "Loading Message" no longer is visible

    # Source step 0165: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-fffa-e039-f29d464c23ef
    # Runtime control: If loading mask is present, wait > Then wait for loading mask to disappear
    When I wait "5000" milliseconds

    # Source step 0166: Wait for synchronization | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-faed-bd33-489ac839283c
    Then I wait until "State Details - Detail" is visible

    # Source step 0167: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0168: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0169: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0170: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0171: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0172: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Private Passenger{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Private Passenger"
    When I click or select "Add Risk at This Location"

    # Source step 0173: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0174: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I leave "Year*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "Make*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "Model*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "1G1AB08C0CA598143{TAB}{TAB}" in "VIN*"

    # Source step 0175: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0176: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0177: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0178: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0181: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I leave "GCW*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Snowplow != NULL" is satisfied, I leave "Is This Vehicle Used In Snow Plow Operations?*" blank because the reusable parameter is not supplied for this iteration

    # Source step 0185: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0186: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Private Passenger\"\"' == 'Registration Plates'"

    # Source step 0188: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"1G1AB08C0CA598143\"\"' == 'ContentsVIN1234'"

    # Source step 0190: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0191: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0192: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0193: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0194: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0195: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0196: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0197: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0198: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0199: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0200: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0201: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Truck{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Truck"
    When I click or select "Add Risk at This Location"

    # Source step 0202: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0203: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I leave "Year*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "Make*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "Model*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "1FDBR10S8EU598143{TAB}{TAB}" in "VIN*"

    # Source step 0204: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0205: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0206: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0207: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0210: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I leave "GCW*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0213: Add/Remove Physical Damage | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
    When if field condition "'OTC Causes of Loss' != NULL" is satisfied, I enter or select "{CLICK}Fire, Theft, Wind{TAB}" in "OTC Causes of Loss*"

    # Source step 0214: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0215: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Truck\"\"' == 'Registration Plates'"

    # Source step 0217: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"1FDBR10S8EU598143\"\"' == 'ContentsVIN1234'"

    # Source step 0219: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0220: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0221: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0222: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0223: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0224: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0225: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0226: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0227: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0228: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0229: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0230: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Truck Tractor{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Truck Tractor"
    When I click or select "Add Risk at This Location"

    # Source step 0231: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0232: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I leave "Year*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "Make*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "Model*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "JHBSG1HD7P2598143{TAB}{TAB}" in "VIN*"

    # Source step 0233: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0234: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0235: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0236: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0239: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I enter or select "{Click}Heavy (0 - 45,000){ENTER}{TAB}{TAB}" in "GCW*"
    When if field condition "Snowplow != NULL" is satisfied, I leave "Is This Vehicle Used In Snow Plow Operations?*" blank because the reusable parameter is not supplied for this iteration

    # Source step 0243: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0244: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Truck Tractor\"\"' == 'Registration Plates'"

    # Source step 0246: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"JHBSG1HD7P2598143\"\"' == 'ContentsVIN1234'"

    # Source step 0248: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0249: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0250: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0251: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0252: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0253: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0254: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0255: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0256: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0257: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0258: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0259: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Semitrailer{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Semitrailer"
    When I click or select "Add Risk at This Location"

    # Source step 0260: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0261: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I leave "Year*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "Make*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "Model*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'Value Basis' != NULL" is satisfied, I enter or select "{Click}ACV{TAB}{TAB}" in "Value Basis"
    When if field condition "'Original Cost New' != NULL" is satisfied, I enter or select "{CLICK}100000{TAB}{TAB}" in "Original Cost New*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "1C9402026X0112143{TAB}{TAB}" in "VIN*"

    # Source step 0262: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0263: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0264: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0265: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0266: Enter General Coverage | Module: Risk Schedule|General Coverage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
    # Runtime control: Enter General Coverage > Then Enter Coverage w/ Accept Liability Coverage
    When if field condition "'Used as Showroom' != NULL" is satisfied, I enter or select "{CLICK}Yes{TAB}" in "Used As Showroom"

    # Source step 0267: Enter General Coverage | Module: Risk Schedule|General Coverage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
    # Runtime control: Enter General Coverage > Else Accept Liability Coverage ignored
    When if field condition "'Used as Showroom' != NULL" is satisfied, I enter or select "{CLICK}Yes{TAB}" in "Used As Showroom"

    # Source step 0268: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I leave "GCW*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Snowplow != NULL" is satisfied, I leave "Is This Vehicle Used In Snow Plow Operations?*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'2nd Class Category' != NULL" is satisfied, I enter or select "{Click}Farmers{TAB}" in "2nd Class Category"
    When if field condition "'2nd Class Code' != NULL" is satisfied, I enter or select "{Click}Individually/Family Owned{TAB}{TAB}" in "2nd Class Code*"

    # Source step 0272: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0273: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Semitrailer\"\"' == 'Registration Plates'"

    # Source step 0275: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"1C9402026X0112143\"\"' == 'ContentsVIN1234'"

    # Source step 0277: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0278: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0279: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0280: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0281: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0282: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0283: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0284: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0285: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0286: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0287: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0288: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Golf Carts/Low Speed Vehicles{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Golf Carts/Low Speed Vehicles"
    When I click or select "Add Risk at This Location"

    # Source step 0289: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0290: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I enter or select "{TAB}1979{TAB}{TAB}" in "Year*"
    When if field condition "Make != NULL" is satisfied, I enter or select "{TAB}Make{TAB}{TAB}" in "Make*"
    When if field condition "Model != NULL" is satisfied, I enter or select "{TAB}Model{TAB}{TAB}" in "Model*"
    When if field condition "'Body Style' != NULL" is satisfied, I enter or select "{TAB}Body Style{TAB}{TAB}" in "Body Style"
    When if field condition "'Stated Amount' != NULL" is satisfied, I enter or select "{TAB}100000{TAB}{TAB}" in "Stated Amount*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "5TSTE24338G020309{TAB}{TAB}" in "VIN*"

    # Source step 0291: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0292: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0293: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0294: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0295: Enter General Coverage | Module: Risk Schedule|General Coverage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
    # Runtime control: Enter General Coverage > Then Enter Coverage w/ Accept Liability Coverage
    When if field condition "'Engine Size' != NULL" is satisfied, I enter or select "{Click}101-200{TAB}{TAB}" in "Engine Size (cc)*"

    # Source step 0296: Enter General Coverage | Module: Risk Schedule|General Coverage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
    # Runtime control: Enter General Coverage > Else Accept Liability Coverage ignored
    When if field condition "'Engine Size' != NULL" is satisfied, I enter or select "{Click}101-200{TAB}{TAB}" in "Engine Size (cc)*"

    # Source step 0297: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I leave "GCW*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Snowplow != NULL" is satisfied, I leave "Is This Vehicle Used In Snow Plow Operations?*" blank because the reusable parameter is not supplied for this iteration

    # Source step 0301: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0302: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Golf Carts/Low Speed Vehicles\"\"' == 'Registration Plates'"

    # Source step 0304: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"5TSTE24338G020309\"\"' == 'ContentsVIN1234'"

    # Source step 0306: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0307: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0308: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0309: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0310: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0311: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0312: Check if on Risk | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-66e8-4be7-eb75f480e8af
    # Runtime control: If not on Risk Schedule, navigate to risk > Condition
    Then "Risk" should not exist

    # Source step 0313: Navigate to Risk | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-5a32-8abc-225d293edf27
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk Schedule" exists
    When I click or select "Risk Schedule"

    # Source step 0314: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-2821-b0ab-7dd7bf8b813d
    # Runtime control: If not on Risk Schedule, navigate to risk > Then
    Then I wait until "Risk" exists

    # Source step 0315: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-9740-c287-4c6bab128f8d
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0316: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0218-e214-a7524d802364
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0317: Select vehicle type | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-fc74-cc0e-167be5797f93
    Then I wait until "Show All Locations" exists
    When I enter or select "(select){TAB}" in "Vehicle Type"
    Then I wait until "Vehicle Type" exists
    When I enter or select "{CLICK}Mobile Home{TAB}{TAB}{TAB}" in "Vehicle Type"
    Then "Vehicle Type" property "value" should equals "Mobile Home"
    When I click or select "Add Risk at This Location"

    # Source step 0318: Wait for synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-7f21-2ad7-c808e6cd2a59
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0319: Enter VIN | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1085-8f92-3a38ebf27624
    Then if field condition "VIN != NULL" is satisfied, I wait until "VIN*" is visible
    When if field condition "Year != NULL" is satisfied, I enter or select "{TAB}1979{TAB}{TAB}" in "Year*"
    When if field condition "Make != NULL" is satisfied, I enter or select "{TAB}Make{TAB}{TAB}" in "Make*"
    When if field condition "Model != NULL" is satisfied, I enter or select "{TAB}Model{TAB}{TAB}" in "Model*"
    When if field condition "'Body Style' != NULL" is satisfied, I enter or select "{TAB}Body Style{TAB}{TAB}" in "Body Style"
    When if field condition "'Stated Amount' != NULL" is satisfied, I enter or select "{TAB}100000{TAB}{TAB}" in "Stated Amount*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "VIN*"
    When if field condition "VIN != NULL" is satisfied, I enter or select "MobileHomeVIN1234{TAB}{TAB}" in "VIN*"

    # Source step 0320: State is KY | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d61e-0032-afcd2beda0c1
    # Runtime control: If State is KY, answer SnowPlow if Suspended > State is KY
    Then I evaluate the source-defined expression for "State is KY" using "Expression='\"\"{B[State]}\"\"' == 'KY'"

    # Source step 0321: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-eaf5-2cb7-abbaf2156b83
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Check if Snowplow Exists
    Then if field condition "Snowplow != NULL" is satisfied, "Is This Vehicle Used In Snow Plow Operations?*" should exist

    # Source step 0322: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-0a9f-edd4-36f6e232c749
    # Runtime control: If State is KY, answer SnowPlow if Suspended > Then > If Vehicle Type is Snowplow Not Null [Snowplow != NULL] > Then do nothing if null
    When if field condition "Snowplow != NULL" is satisfied, I enter or select "{Click}No{ENTER}{TAB}{TAB}" in "Is This Vehicle Used In Snow Plow Operations?*"

    # Source step 0323: State is not UT | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad07-135b-53e9-867b-bd5d54b9373b
    # Runtime control: Enter General Coverage > Condition
    Then I evaluate the source-defined expression for "State is not UT" using "Expression='\"\"{B[State]}\"\"' != 'UT'"

    # Source step 0326: Enter Risk Specific | Module: Risk Schedule|Risk Specific
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-28d8-f80a-c2eb43ff3705
    When if field condition "GCW != NULL" is satisfied, I leave "GCW*" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Snowplow != NULL" is satisfied, I leave "Is This Vehicle Used In Snow Plow Operations?*" blank because the reusable parameter is not supplied for this iteration

    # Source step 0330: State is NJ | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-1067-2c50-e7086e1dc8b6
    # Runtime control: If State is NJ, answer Collision > State is NJ
    Then I evaluate the source-defined expression for "State is NJ" using "Expression='\"\"{B[State]}\"\"' == 'NJ'"

    # Source step 0331: Vehicle Type is Registration Plates | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-45e1-9cee-d4c6f08a103f
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Check if Registration Plates
    Then I evaluate the source-defined expression for "Vehicle Type is Registration Plates" using "Expression='\"\"Mobile Home\"\"' == 'Registration Plates'"

    # Source step 0333: VIN is Mobile Home Contents | Module: TBox Evaluation Tool
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a72f-e101-25afe483c94a
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Check if ContentsVIN
    Then I evaluate the source-defined expression for "VIN is Mobile Home Contents" using "Expression='\"\"MobileHomeVIN1234\"\"' == 'ContentsVIN1234'"

    # Source step 0335: Check if Collision Cov exists | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-f927-866b-99b6099e8ab1
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Collision exists?
    Then "Collision Coverage" should exist

    # Source step 0336: Answer Collision as No if Null | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-15b3-a550-40ee61023c05
    # Runtime control: If State is NJ, answer Collision > Then > If Vehicle Type is Registration Plates > Else > If VIN is ContentsVIN1234 > Else > If Collision exists > Then
    When if field condition "'Collision Coverage' == NULL" is satisfied, I enter or select "{TAB}No{TAB}{TAB}" in "Collision Coverage"

    # Source step 0337: Confirm vehicle addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-60ce-5b1e-d1f2b6b94fd0
    When I click or select "OK"

    # Source step 0338: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a737-b36c-bda1f019db45
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0339: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-e0ed-ff5a-f945e14d4611
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0340: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-62ac-1a0d-b6ebcc00a163
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0341: Navigate to Risk Aggregate | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-17fc-c43f-9e6440b6b1f3
    When I click or select "Risk Schedule"

    # Source step 0342: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-0a6d-3181-98bf5aa59414
    Then I wait until "Risk" exists

    # Source step 0343: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-833d-29d8-e1cad22e6f93
    And I use "Private Passenger" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0344: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-4a15-e943-a9a42d88462f
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0345: Add Coverage | Module: Risk Schedule|Hired Auto
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-3d50-03a3-3e23019e53fa
    When I enter or select "{TAB}Yes{ENTER}{TAB}" in "Hired Auto Ext Addl Insured"
    Then "Hired Auto Ext Addl Insured" property "value" should equals "Yes"
    Then I wait until "Hired Auto Form*" exists
    When I enter or select "{CLICK}CA 9916{ENTER}{TAB}{CLICK}{TAB}" in "Hired Auto Form*"
    Then I wait until "Hired Auto Form*" property "Text" does not equal "\"\""

    # Source step 0346: Wait for synchronization (same page) | Module: Risk Schedule|Hired Auto
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-9cc0-554e-2083cad6e408
    Then I wait until "OK" no longer exists

    # Source step 0347: Confirm Changes | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-8428-bc9f-8e7001dd2b34
    When I click or select "OK"

    # Source step 0348: Wait for Synchronization (back to Risk Schedule) | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-db23-b25f-a551f3a79970
    Then I wait until "Risk" exists

    # Source step 0349: Navigate to Risk Aggregate | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-17fc-c43f-9e6440b6b1f3
    When I click or select "Risk Schedule"

    # Source step 0350: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-0a6d-3181-98bf5aa59414
    Then I wait until "Risk" exists

    # Source step 0351: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-833d-29d8-e1cad22e6f93
    And I use "Truck" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0352: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-4a15-e943-a9a42d88462f
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0353: Add Coverage | Module: Risk Schedule|Hired Auto
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-3d50-03a3-3e23019e53fa
    When I enter or select "{TAB}Yes{ENTER}{TAB}" in "Hired Auto Ext Addl Insured"
    Then "Hired Auto Ext Addl Insured" property "value" should equals "Yes"
    Then I wait until "Hired Auto Form*" exists
    When I enter or select "{CLICK}CA 9947{ENTER}{TAB}{CLICK}{TAB}" in "Hired Auto Form*"
    Then I wait until "Hired Auto Form*" property "Text" does not equal "\"\""

    # Source step 0354: Wait for synchronization (same page) | Module: Risk Schedule|Hired Auto
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-9cc0-554e-2083cad6e408
    Then I wait until "OK" no longer exists

    # Source step 0355: Confirm Changes | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-8428-bc9f-8e7001dd2b34
    When I click or select "OK"

    # Source step 0356: Wait for Synchronization (back to Risk Schedule) | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-db23-b25f-a551f3a79970
    Then I wait until "Risk" exists

    # Source step 0357: Navigate to Risk Aggregate | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-17fc-c43f-9e6440b6b1f3
    When I click or select "Risk Schedule"

    # Source step 0358: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-0a6d-3181-98bf5aa59414
    Then I wait until "Risk" exists

    # Source step 0359: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-833d-29d8-e1cad22e6f93
    And I use "Truck Tractor" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0360: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-4a15-e943-a9a42d88462f
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0361: Add Coverage | Module: Risk Schedule|Hired Auto
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-3d50-03a3-3e23019e53fa
    When I enter or select "{TAB}Yes{ENTER}{TAB}" in "Hired Auto Ext Addl Insured"
    Then "Hired Auto Ext Addl Insured" property "value" should equals "Yes"
    Then I wait until "Hired Auto Form*" exists
    When I enter or select "{CLICK}CA 2001{ENTER}{TAB}{CLICK}{TAB}" in "Hired Auto Form*"
    Then I wait until "Hired Auto Form*" property "Text" does not equal "\"\""
    When if field condition "'First Name' != NULL" is satisfied, I perform keyboard action "{TAB}" on "HiredAuto CA2001 First Name"
    When if field condition "'Last Name' != NULL" is satisfied, I enter or select "{TAB}Snow{TAB}" in "HiredAuto CA2001 Last Name"
    When if field condition "'Address 1' != NULL" is satisfied, I perform keyboard action "{TAB}" on "HiredAuto CA2001 Address1"
    When if field condition "'Zip Code' != NULL" is satisfied, I enter or select "{TAB}12158{TAB}" in "HiredAuto CA2001 ZipCode"
    When if field condition "'First Name' != NULL" is satisfied, I click or select "OK"
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "John{TAB}" in "HiredAuto CA2001 First Name"
    When if field condition "'Address 1' != NULL" is satisfied, I enter or select "100 Bridge St{TAB}" in "HiredAuto CA2001 Address1"

    # Source step 0362: Wait for synchronization (same page) | Module: Risk Schedule|Hired Auto
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-9cc0-554e-2083cad6e408
    Then I wait until "OK" no longer exists

    # Source step 0363: Confirm Changes | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-8428-bc9f-8e7001dd2b34
    When I click or select "OK"

    # Source step 0364: Wait for Synchronization (back to Risk Schedule) | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Interests | Reusable flow: BAP|ST|Add Risk Level Interest | Source XTestStep: 3a13d49c-165b-db23-b25f-a551f3a79970
    Then I wait until "Risk" exists

    # Source step 0365: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-0c65-db70-beb5d117569b
    And I use "Private Passenger" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0366: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-8ccb-da74-e378dce4227f
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0367: Verify UM/UIM, PIP | Module: Risk Schedule|Liability, UM, Medical & PIP
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-7669-db05-eadc989d1931
    Then if field condition "'Accept UM' != NULL" is satisfied, "Accept UM" property "InnerText" should equals "Yes"

    # Source step 0368: Return to Risk Schedule | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-90d0-c7b0-131a8a466029
    When I click or select "OK"

    # Source step 0369: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-4b02-934a-c92eca8e5201
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0370: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-a5f2-8275-137f834856ec
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0371: Wait for synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Verify Risk Level Coverages | Source XTestStep: 3a13d49c-165b-cf51-85ca-0db45cd1509b
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0372: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-8740-a7a7-3d616c74f47c
    And I use "Private Passenger" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0373: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-d2a6-f97a-21537e3709ba
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0375: Add Coverages | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-3f1c-aa37-94f5b7fa4a84
    When if field condition "'Loan/Lease Gap' != NULL" is satisfied, I enter or select "{Click}Yes{ENTER}{TAB}{TAB}" in "Loan/Lease Gap"
    When if field condition "'Tapes Coverage' != NULL" is satisfied, I enter or select "{TAB}Yes" in "Tapes Coverage"
    When if field condition "'Audio Visual' != NULL" is satisfied, I enter or select "{TAB}Yes{TAB}" in "Audio Visual"
    When if field condition "'Audio Visual' != NULL" is satisfied, I enter or select "{TAB}500{TAB}{TAB}" in "AV Cost New*"
    When if field condition "Towing != NULL && 'Vehicle Type' == \"Private Passenger\"" is satisfied, I leave "Towing" blank because the reusable parameter is not supplied for this iteration
    Then I wait until "OK" exists

    # Source step 0376: Confirm Addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-0eeb-9792-d6c430269939
    When I click or select "OK"

    # Source step 0377: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-bc90-bf61-38eab01fd6e7
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0378: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-221e-2efc-888ab4197c14
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0379: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-4b67-b4be-f0ede169b109
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0380: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-7ac3-667e-12afeb76a7da
    Then I wait until "Risk" exists

    # Source step 0381: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-8740-a7a7-3d616c74f47c
    And I use "Truck" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0382: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-d2a6-f97a-21537e3709ba
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0384: Add Coverages | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-3f1c-aa37-94f5b7fa4a84
    When if field condition "'Loan/Lease Gap' != NULL" is satisfied, I enter or select "{Click}Yes{ENTER}{TAB}{TAB}" in "Loan/Lease Gap"
    When if field condition "'Tapes Coverage' != NULL" is satisfied, I enter or select "{TAB}Yes" in "Tapes Coverage"
    When if field condition "'Audio Visual' != NULL" is satisfied, I enter or select "{TAB}Yes{TAB}" in "Audio Visual"
    When if field condition "'Audio Visual' != NULL" is satisfied, I enter or select "{TAB}500{TAB}{TAB}" in "AV Cost New*"
    Then I wait until "OK" exists

    # Source step 0385: Confirm Addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-0eeb-9792-d6c430269939
    When I click or select "OK"

    # Source step 0386: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-bc90-bf61-38eab01fd6e7
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0387: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-221e-2efc-888ab4197c14
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0388: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-4b67-b4be-f0ede169b109
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0389: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-7ac3-667e-12afeb76a7da
    Then I wait until "Risk" exists

    # Source step 0390: Navigate to Risk Detail | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-8740-a7a7-3d616c74f47c
    And I use "Semitrailer" as the identifying constraint for "Vehicle Schedule > #1 > Type"
    Then "Vehicle Schedule > #1 > Veh #" property "value" should equals "{XB[VehicleNumber]}"
    When I click or select "Detail"

    # Source step 0391: Wait for Synchronization | Module: Risk Schedule|Vehicle Information
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-d2a6-f97a-21537e3709ba
    Then I wait until "Commercial Auto Risk Detail" exists

    # Source step 0392: Enter General Coverage | Module: Risk Schedule|General Coverage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-34d5-ede4-2553d1eb08cd
    # Step condition: 'Seasonal Produce Trailers' != NULL
    When I enter or select "{CLICK}Yes{TAB}" in "Seasonal Produce Trailers"
    Then I wait until "Coverage begin date:" exists
    When I enter RUNTIME-DERIVED value "{CLICK}{DATE[09-05-2026][+6M][MM-dd-yyyy]}{TAB}" in "Coverage end date:"
    When I enter or select "{CLICK}Fruits & Vegetables{TAB}" in "Produce Carried"

    # Source step 0393: Add Coverages | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-3f1c-aa37-94f5b7fa4a84
    Then I wait until "OK" exists

    # Source step 0394: Confirm Addition | Module: Risk Schedule|Physical Damage
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-0eeb-9792-d6c430269939
    When I click or select "OK"

    # Source step 0395: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-bc90-bf61-38eab01fd6e7
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0396: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-221e-2efc-888ab4197c14
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0397: TBox Wait | Module: TBox Wait
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-4b67-b4be-f0ede169b109
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    When I wait "5000" milliseconds

    # Source step 0398: Wait for Synchronization | Module: Risk Aggregate
    # Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-7ac3-667e-12afeb76a7da
    Then I wait until "Risk" exists

    # Source step 0399: Navigate to Driver Schedule | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-2624-7793-78f8d5626ae9
    When I click or select "Driver Schedule"

    # Source step 0400: Click Add a Driver | Module: Driver Schedule
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-3afb-f1b0-80ed96817db1
    Then I wait until "Driver Schedule" exists
    When I click or select "Add Driver"

    # Source step 0401: Enter Driver info | Module: Driver Detail
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

    # Source step 0402: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-46bf-446c-71ddd3115bc9
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0403: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-e5f3-7f2d-23bd9fe88454
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0404: Wait for IFRAME to close | Module: Driver Detail
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-8ea4-5f40-4520f182f575
    Then I wait until "IFRAME" no longer exists

    # Source step 0405: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-1ccb-f20f-ede5f9f5d12e
    # Runtime control: If loading indicator is present, wait > if loading indicator is present
    Then "Loading Message" should be visible

    # Source step 0406: Indicators and Errors | Module: Indicators and Errors
    # Section: Policy Data Entry Process | Reusable flow: BAP|Driver Schedule|Fill out driver info | Source XTestStep: 3a13d49c-165b-384f-9c95-434dc426dfe7
    # Runtime control: If loading indicator is present, wait > Then wait for it to go away
    Then I wait until "Loading Message" no longer is visible

    # Source step 0407: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|Verify Mandatory Endorsements | Source XTestStep: 3a13d49c-165b-987b-1e78-6c5252c00c62
    When I click or select "Endorsements"

    # Source step 0408: Verify Mandatory Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|Verify Mandatory Endorsements | Source XTestStep: 3a13d49c-165b-5373-da02-4b77ad2d8c62
    Then I wait until "Endorsements Heading" exists
    And I use "{NULL}" as the identifying constraint for "Endorsement Schedule > <Row> > $1"
    Then if field condition "'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\"" is satisfied, "Endorsement Schedule > <Row> > $1" property "InnerText" should equals "Silica or Silica-Related Dust Exclusion"
    And I use "{NULL}" as the identifying constraint for "Endorsement Table > <Row> > #1"
    Then if field condition "'Endorsement Type' ==\"[CA2394] Silica or Silica-Related Dust Exclusion\"" is satisfied, "Endorsement Table > <Row> > $2" property "InnerText" should equals "Silica or Silica-Related Dust Exclusion"

    # Source step 0410: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0411: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0412: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0413: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
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
    When I enter or select "{Click}[CA2397] Amphibious Vehicles{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0414: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0415: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0416: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0417: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0419: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0420: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0421: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0422: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
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
    When I enter or select "{Click}[CA2305] Wrong Delivery of Liquid Products{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0423: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0424: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0425: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0426: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0428: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0429: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0430: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0431: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
    # Step condition: 'Endorsement Type' != "[CA2394] Silica or Silica-Related Dust Exclusion"||'Endorsement Type' != "[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"||'Endorsement Type' != "[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
    Then I wait until "Click Add Endorsement" is visible
    When I click or select "Click Add Endorsement"
    Then I wait until "IFRAME > Duck Creek Policy > Endorsement Detail" exists
    Then if field condition "'Endorsement Type' == \"[CA2325] Leased Workers Coverage\"" is satisfied, I wait until "IFRAME > Duck Creek Policy > [CA2325] Leased Workers Coverage" exists
    When if field condition "Year != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Year" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Make" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Model" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA 9940 - VIN" blank because the reusable parameter is not supplied for this iteration
    Then I wait until "IFRAME > Duck Creek Policy > OK" exists
    Then I wait until "Endorsement Type" exists
    When I click or select "Endorsement Type"
    When I enter or select "(select){TAB}" in "Endorsement Type"
    When I enter or select "{Click}[CA2325] Leased Workers Coverage{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0432: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0433: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0434: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0435: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0437: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0438: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0439: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0440: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
    # Step condition: 'Endorsement Type' != "[CA2394] Silica or Silica-Related Dust Exclusion"||'Endorsement Type' != "[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"||'Endorsement Type' != "[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
    Then I wait until "Click Add Endorsement" is visible
    When I click or select "Click Add Endorsement"
    Then I wait until "IFRAME > Duck Creek Policy > Endorsement Detail" exists
    Then if field condition "'Add Excluded Driver' != NULL" is satisfied, I wait until "IFRAME > Duck Creek Policy > Click Add Excluded Driver" exists
    When if field condition "'Add Excluded Driver' != NULL" is satisfied, I click or select "IFRAME > Duck Creek Policy > Click Add Excluded Driver"
    When if field condition "'Driver Name' != NULL" is satisfied, I enter or select "{TAB}Steve Wozniak{TAB}" in "IFRAME > Duck Creek Policy > Add Driver Name"
    When if field condition "Year != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Year" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Make" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Model" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA 9940 - VIN" blank because the reusable parameter is not supplied for this iteration
    Then I wait until "IFRAME > Duck Creek Policy > OK" exists
    Then I wait until "Endorsement Type" exists
    When I click or select "Endorsement Type"
    When I enter or select "(select){TAB}" in "Endorsement Type"
    When I enter or select "{Click}[CC9902]- Driver Exclusion{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0441: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0442: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0443: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0444: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0446: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0447: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0448: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0449: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
    # Step condition: 'Endorsement Type' != "[CA2394] Silica or Silica-Related Dust Exclusion"||'Endorsement Type' != "[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"||'Endorsement Type' != "[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
    Then I wait until "Click Add Endorsement" is visible
    When I click or select "Click Add Endorsement"
    Then I wait until "IFRAME > Duck Creek Policy > Endorsement Detail" exists
    When if field condition "Year != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Year" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Make" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Model" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA 9940 - VIN" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'Commodities Transported' != NULL" is satisfied, I enter or select "{Click}Commodity Type I{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > CA9948 - Classes Of Commodities Transported"
    Then I wait until "IFRAME > Duck Creek Policy > OK" exists
    Then I wait until "Endorsement Type" exists
    When I click or select "Endorsement Type"
    When I enter or select "(select){TAB}" in "Endorsement Type"
    When I enter or select "{Click}[CA9948] - Pollution Liability - Broadened Coverage For Covered Autos{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0450: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0451: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0452: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0453: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0455: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0456: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0457: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0458: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
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
    When I enter or select "{Click}[CA9990] Loss Of Use Expenses - Rental Vehicles - Optional Limits{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0459: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0460: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0461: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0462: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0464: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0465: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0466: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0467: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
    # Step condition: 'Endorsement Type' != "[CA2394] Silica or Silica-Related Dust Exclusion"||'Endorsement Type' != "[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"||'Endorsement Type' != "[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
    Then I wait until "Click Add Endorsement" is visible
    When I click or select "Click Add Endorsement"
    Then I wait until "IFRAME > Duck Creek Policy > Endorsement Detail" exists
    When if field condition "Year != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Year" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Make != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Make" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Model != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA9940 - Model" blank because the reusable parameter is not supplied for this iteration
    When if field condition "VIN != NULL" is satisfied, I leave "IFRAME > Duck Creek Policy > CA 9940 - VIN" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'Endorsement Type' ==\"Trailer Interchange Coverage\"" is satisfied, I enter or select "{TAB}300{TAB}" in "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # Days Insured"
    When if field condition "'Endorsement Type' ==\"Trailer Interchange Coverage\"" is satisfied, I enter or select "{TAB}50{TAB}" in "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # of Trailers"
    Then I wait until "IFRAME > Duck Creek Policy > OK" exists
    Then I wait until "Endorsement Type" exists
    When I click or select "Endorsement Type"
    When I enter or select "(select){TAB}" in "Endorsement Type"
    When I enter or select "{Click}Trailer Interchange Coverage{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0468: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0469: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0470: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0471: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0473: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0474: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0475: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0476: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
    # Step condition: 'Endorsement Type' != "[CA2394] Silica or Silica-Related Dust Exclusion"||'Endorsement Type' != "[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"||'Endorsement Type' != "[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
    Then I wait until "Click Add Endorsement" is visible
    When I click or select "Click Add Endorsement"
    Then I wait until "IFRAME > Duck Creek Policy > Endorsement Detail" exists
    When if field condition "Year != NULL" is satisfied, I enter or select "{TAB}2018{TAB}" in "IFRAME > Duck Creek Policy > CA9940 - Year"
    When if field condition "Make != NULL" is satisfied, I enter or select "{TAB}Sub{TAB}" in "IFRAME > Duck Creek Policy > CA9940 - Make"
    When if field condition "Model != NULL" is satisfied, I enter or select "{TAB}Forester{TAB}" in "IFRAME > Duck Creek Policy > CA9940 - Model"
    When if field condition "VIN != NULL" is satisfied, I enter or select "{TAB}JF2SJABC4JH524145{TAB}" in "IFRAME > Duck Creek Policy > CA 9940 - VIN"
    When if field condition "'Contract Provisions' != NULL" is satisfied, I enter or select "{CLICK}Option 1{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > CA9940 - Contract Provisions"
    Then I wait until "IFRAME > Duck Creek Policy > OK" exists
    Then I wait until "Endorsement Type" exists
    When I click or select "Endorsement Type"
    When I enter or select "(select){TAB}" in "Endorsement Type"
    When I enter or select "{Click}[CA9940] - Exclusion or Excess Coverage Hazards Otherwise Insured{ENTER}{TAB}{TAB}" in "Endorsement Type"

    # Source step 0477: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0478: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0479: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0480: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0482: Check if on Endorsements | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-972a-d47a-13639cb9905f
    # Runtime control: If not on Endorsements > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0483: Navigate to Endorsements | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d013-d192-d0c3d78fb224
    # Runtime control: If not on Endorsements > Then
    When I click or select "Endorsements"

    # Source step 0484: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-90be-7b27-21e527e6be70
    Then I wait until "Endorsements Heading" exists

    # Source step 0485: Enter required endorsement info | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d80f-1eab-a3b1d745ea48
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

    # Source step 0486: Confirm Addition | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-3ef6-7ef0-5129a2245a01
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0487: Check if IFRAME is open | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-d164-2090-faef2cf9089d
    # Runtime control: If IFRAME is present, wait for it to close > If IFRAME is present
    Then "IFRAME" should exist

    # Source step 0488: Wait for IFRAME to close | Module: BAP Endorsements
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f90f-6f96-cfdfca480f4b
    # Runtime control: If IFRAME is present, wait for it to close > Then wait for it to go away
    Then I wait until "IFRAME" no longer exists

    # Source step 0489: Wait for synchronization | Module: BAP Endorsement Schedule
    # Section: Policy Data Entry Process > Add Endorsements > Add Endorsement if not Null | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-516d-b9b2-a505538a3995
    Then I wait until "Endorsements Heading" exists

    # Source step 0490: Check if on Addl Interests | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-9aeb-7ff8-ca5bd0e745ac
    # Runtime control: If not on Addl Interests > Condition
    Then "Addl Interests" should not exist

    # Source step 0491: Navigate to Addl Interests | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-6568-99bd-61454c5c7dda
    # Runtime control: If not on Addl Interests > Then
    When I click or select "Additional Interests"

    # Source step 0492: Wait for Synchronization | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-8720-4091-15261fb6b70b
    Then I wait until "Addl Interests" exists
    When I click or select "Add Other Interest"
    Then I wait until "IFRAME > Duck Creek Policy > Type of Interest" exists
    When I enter or select "{CLICK}[CA 20 48] Designated Insured{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > Type of Interest"

    # Source step 0493: Enter required info | Module: Additional Interests
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-b7fd-c464-ab81868a9941
    Then I wait until "IFRAME > Duck Creek Policy > First Name*" exists
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "{TAB}Mark{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When if field condition "'Last Name' != NULL" is satisfied, I enter or select "{TAB}{TAB}Grayson{TAB}" in "IFRAME > Duck Creek Policy > Last Name*"
    When if field condition "Address != NULL" is satisfied, I enter or select "{TAB}100 Bridge St{TAB}" in "IFRAME > Duck Creek Policy > Address 1*"
    When if field condition "ZIP != NULL" is satisfied, I enter or select "{TAB}12158{TAB}" in "IFRAME > Duck Creek Policy > Zip Code"
    Then I wait until "IFRAME > Duck Creek Policy > State" is visible
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0494: Wait for Synchronization | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-126e-f80d-fbdea2360e15
    Then I wait until "Addl Interests" exists
    Then I wait until "IFRAME" no longer exists

    # Source step 0495: Check if on Addl Interests | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-9aeb-7ff8-ca5bd0e745ac
    # Runtime control: If not on Addl Interests > Condition
    Then "Addl Interests" should not exist

    # Source step 0496: Navigate to Addl Interests | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-6568-99bd-61454c5c7dda
    # Runtime control: If not on Addl Interests > Then
    When I click or select "Additional Interests"

    # Source step 0497: Wait for Synchronization | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-8720-4091-15261fb6b70b
    Then I wait until "Addl Interests" exists
    When I click or select "Add Other Interest"
    Then I wait until "IFRAME > Duck Creek Policy > Type of Interest" exists
    When I enter or select "{CLICK}[CA 99 44] Loss Payable Clause{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > Type of Interest"

    # Source step 0498: Enter required info | Module: Additional Interests
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-b7fd-c464-ab81868a9941
    Then I wait until "IFRAME > Duck Creek Policy > First Name*" exists
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "{TAB}Bryson{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When if field condition "'Last Name' != NULL" is satisfied, I enter or select "{TAB}{TAB}Jones{TAB}" in "IFRAME > Duck Creek Policy > Last Name*"
    When if field condition "Address != NULL" is satisfied, I enter or select "{TAB}100 Bridge St{TAB}" in "IFRAME > Duck Creek Policy > Address 1*"
    When if field condition "ZIP != NULL" is satisfied, I enter or select "{TAB}12158{TAB}" in "IFRAME > Duck Creek Policy > Zip Code"
    Then I wait until "IFRAME > Duck Creek Policy > State" is visible
    When if field condition "'Vehicle Association' != NULL" is satisfied, I click or select "IFRAME > Duck Creek Policy > Vehicle Association*"
    When if field condition "'Vehicle Association' != NULL" is satisfied, I enter or select "{DOUBLECLICK}{DOWN}{DOWN}{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > Vehicle Association*"
    Then if field condition "'Vehicle Association' != NULL" is satisfied, I wait until "IFRAME > Duck Creek Policy > Vehicle Association*" property "InnerText" does not equal "\"\""
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0499: Wait for Synchronization | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-126e-f80d-fbdea2360e15
    Then I wait until "Addl Interests" exists
    Then I wait until "IFRAME" no longer exists

    # Source step 0500: Check if on Addl Interests | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-9aeb-7ff8-ca5bd0e745ac
    # Runtime control: If not on Addl Interests > Condition
    Then "Addl Interests" should not exist

    # Source step 0501: Navigate to Addl Interests | Module: BAP Navigation Links
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-6568-99bd-61454c5c7dda
    # Runtime control: If not on Addl Interests > Then
    When I click or select "Additional Interests"

    # Source step 0502: Wait for Synchronization | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-8720-4091-15261fb6b70b
    Then I wait until "Addl Interests" exists
    When I click or select "Add Other Interest"
    Then I wait until "IFRAME > Duck Creek Policy > Type of Interest" exists
    When I enter or select "{CLICK}[CA 99 61] Loss Payable Clause - Audio, Visual And Data Electronic Equipment{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > Type of Interest"

    # Source step 0503: Enter required info | Module: Additional Interests
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-b7fd-c464-ab81868a9941
    Then I wait until "IFRAME > Duck Creek Policy > First Name*" exists
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "{TAB}{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When if field condition "'First Name' != NULL" is satisfied, I enter or select "{TAB}James{TAB}" in "IFRAME > Duck Creek Policy > First Name*"
    When if field condition "'Last Name' != NULL" is satisfied, I enter or select "{TAB}{TAB}Sendack{TAB}" in "IFRAME > Duck Creek Policy > Last Name*"
    When if field condition "Address != NULL" is satisfied, I enter or select "{TAB}100 Bridge St{TAB}" in "IFRAME > Duck Creek Policy > Address 1*"
    When if field condition "ZIP != NULL" is satisfied, I enter or select "{TAB}12158{TAB}" in "IFRAME > Duck Creek Policy > Zip Code"
    Then I wait until "IFRAME > Duck Creek Policy > State" is visible
    When if field condition "'Vehicle Association' != NULL" is satisfied, I click or select "IFRAME > Duck Creek Policy > Vehicle Association*"
    When if field condition "'Vehicle Association' != NULL" is satisfied, I enter or select "{DOUBLECLICK}{DOWN}{DOWN}{ENTER}{TAB}" in "IFRAME > Duck Creek Policy > Vehicle Association*"
    Then if field condition "'Vehicle Association' != NULL" is satisfied, I wait until "IFRAME > Duck Creek Policy > Vehicle Association*" property "InnerText" does not equal "\"\""
    When I click or select "IFRAME > Duck Creek Policy > OK"

    # Source step 0504: Wait for Synchronization | Module: Additional Interests Schedule
    # Section: Policy Data Entry Process > Add Addl Interests | Reusable flow: BAP|Add Addl Interest | Source XTestStep: 3a13d49c-165b-126e-f80d-fbdea2360e15
    Then I wait until "Addl Interests" exists
    Then I wait until "IFRAME" no longer exists

    # Source step 0505: Navigate to UW Questions | Module: BAP Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-cfef-6060-dffbfba73711
    When I click or select "UW Questions"

    # Source step 0506: Wait for synchronization | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-4962-7a70-655b6ca4aebd
    Then I wait until "UW Questions" exists

    # Source step 0507: Fill out Underwriting Questions | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-bc4b-759d-fad8403f5fda
    When I enter or select "X{TAB}{TAB}" in "Update Answers Button"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "Are there any commercial vehicles owned by the applicant not insured on the policy?"
    Then I wait until "Are there any commercial vehicles owned by the applicant not insured on the policy?" property "value" equals "No"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "AnyPersonalAutoPolicyListingNameInsured"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}" in "AnyVehicleCoveredRegisteredInNotPrimaryState"
    When I enter or select "{TAB}\"No\"{TAB}{TAB}{TAB}{TAB}" in "BorrowingHiringOrLeasingWithinYear"
    Then I wait until "BorrowingHiringOrLeasingWithinYear" property "value" equals "No"
    Then I wait until "AnyVehicleCoveredRegisteredInNotPrimaryState" property "value" equals "No"

    # Source step 0508: Check for any Felonies question | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-d9e3-5ca9-3cd680f25672
    # Runtime control: If Any Felonies question exists > Condition
    Then "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring" should exist

    # Source step 0509: Fill out any Felonies question | Module: Underwriting Questions
    # Section: Policy Data Entry Process | Reusable flow: BAP|UW Questions|Fill out required fields | Source XTestStep: 3a13d49c-165b-42bd-4f1a-3af81ad13192
    # Runtime control: If Any Felonies question exists > Then
    When I enter or select "{TAB}No{TAB}{TAB}" in "Has any applicant been convicted of a felony or been involved in any incidents or claims relating to sexual abuse or molestation allegations, discrimination, arson, fraud, bribery or negligent hiring"

    # Source step 0510: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0511: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0512: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0513: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0514: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: Policy Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0515: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0516: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0517: Order Audit | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0518: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0519: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0520: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0521: Wait for Synchronization | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0522: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0523: 500ms wait for syncing | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0524: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0525: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0526: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0527: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0528: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0529: Wait 2 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0530: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0531: Set Error Flag | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0575: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0576: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0577: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0578: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0579: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0580: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0584: Wait 3.5 seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0585: Check for Loading Indicator | Module: Indicators and Errors
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0586: Wait 2 secs | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0587: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0588: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0589: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0590: Wait 2 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0591: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0635: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0636: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0637: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0638: Wait 3 Seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0639: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0640: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0641: Wait 3.5 seconds | Module: TBox Wait
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0642: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0647: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0648: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0649: Buffer Server Address | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0650: Forms API Request | Module: Forms API Request
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0651: Forms API Response | Module: Forms API Response
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0652: Sync API | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0653: Save the Response as XML file | Module: Save XML file
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\BAP_StraightThrough_AL_{B[QuoteID]}.xml"

    # Source step 0659: Sync API | Module: TBox Wait
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0660: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\\" -FileName \"BAP_StraightThrough\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0661: Execute Powershell Script | Module: TBox Start Program
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0662: Display the Results Summary | Module: TBox Clipboard
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0663: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0664: Check for Save for Later Button | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-7f66-3db6-9842c21b8f30
    # Runtime control: Check for Save for Later Button to avoid Locking the Policy > Condition
    Then "Save for Later" should exist

    # Source step 0665: Save for Later | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-76d9-8f8d-5996da943954
    # Runtime control: Check for Save for Later Button to avoid Locking the Policy > Then
    When I click or select "Save for Later"
    Then I wait until "Save for Later - OK" exists
    When I click or select "Save for Later - OK"

    # Source step 0666: Check for Return to Admin Button | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-f9d4-d6c6-7d52f321bbe0
    # Runtime control: Check for Return to Admin Button to avoid Locking the Policy > Condition
    Then "Return To Admin" should exist

    # Source step 0667: Return To Admin | Module: Common Navigation Links
    # Section: <root> | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-5f9c-b6f4-47437bc9202b
    # Runtime control: Check for Return to Admin Button to avoid Locking the Policy > Then
    When I click or select "Return To Admin"
    Then I wait until "Return To Admin" no longer exists

    # Source step 0675: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0676: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0677: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0678: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0679: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0073: "Enter SSN" in module "Client|Named Insured|Individual" was disabled. Reason: 11.07.23 12:48:56 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-49b4-6804-8a7e93c5d2c0
#    - WAIT (Exists) "Order SSN" with "True"
#    - INPUT "Order SSN" with "X"
#    - WAIT (Exists) "Enter SSN" with "True"
#    - INPUT "Enter SSN" with "a RANDOM value matching 6 random digits/characters from source expression 025{RND[6]}{TAB}{TAB}"
#    - BUFFER "Enter SSN" with "SSN"
#    - WAIT (Exists) "Enter SSN" with "True"
#    - INPUT "Verify" with "X"
#    - WAIT (Exists) "Verify" with "False"
# Source step 0089: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0090: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0106: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:56 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-d800-16b1-204343afb7e1
#    - INPUT "Duration" with "1500"
# Source step 0107: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 14.04.20 08:18:24 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-06ca-978e-d5200f0622bb
#    - WAIT (Exists) "Insurance Score" with "False"
# Source step 0108: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:31 [ff01620]
# Section: Policy Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3a41-fade-9ac567a11717
#    - INPUT "Duration" with "1500"
# Source step 0409: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0418: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0427: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0436: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0445: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0454: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0463: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0472: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0481: "Check if Endorsement Type is not Null" in module "TBox Evaluation Tool" was disabled. Reason: 29.12.23 09:52:18 [ff01620]
# Section: Policy Data Entry Process > Add Endorsements | Reusable flow: BAP|ST|Add Endorsement | Source XTestStep: 3a13d49c-165b-f89a-a374-2c6d912565a0
#    - VERIFY "Expression" with "'NULL' == 'NULL'"
# Source step 0532: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0533: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0534: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0535: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0536: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0537: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0538: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0539: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0540: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0541: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0542: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0543: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0544: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0545: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0546: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0547: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0548: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0549: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0550: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0551: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0552: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0553: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0554: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0555: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0556: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0557: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0558: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0559: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0560: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0561: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0562: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0563: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0564: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0565: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0566: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0567: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0568: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0569: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0570: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0571: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0572: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0573: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0574: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0592: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0593: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0594: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0595: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0596: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0597: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0598: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0599: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0600: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0601: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0602: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0603: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0604: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0605: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0606: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0607: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0608: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0609: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0610: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0611: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0612: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0613: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0614: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0615: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0616: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0617: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0618: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0619: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0620: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0621: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0622: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0623: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\"
# Source step 0624: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0625: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0626: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0627: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0628: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0629: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0630: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0631: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0632: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0633: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0634: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: Policy Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0643: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0644: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0645: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0646: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: Policy Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0654: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0655: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0656: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0657: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: Policy Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\BAP_StraightThrough_AL_{B[QuoteID]}.xml"
# Source step 0658: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\BAP_StraightThrough_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0668: "Logout" in module "Logout" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0669: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0670: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0671: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0672: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0673: "Logout" in module "Logout" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com]
# Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0674: "Waiton Username to exist" in module "Login" was disabled. Reason: 09.01.25 09:21:28 [ff01620@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  CommercialAuto  Pages   US   (9.23.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0041 "Select Individual Sole Proprietor" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
# Source step 0063: "Enter Business info" in module "Client|Additional Named Insured|Business" was not executed. Reason: Selected-iteration condition evaluated false: Individual == NULL
# Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-6988-aa54-0091d5683080
#    - Preserved source field action: INPUT "Add Named Insured - Business" with "X"
#    - Preserved source field action: WAIT (Exists) "BusinessName" with "True"
#    - Preserved source field action: INPUT "BusinessName" with "{TAB}Joe's Plumbing Inc.{TAB}{TAB}"
#    - Preserved source field action: INPUT "Detail" with "X"
# Source step 0065: "Enter Business Address info" in module "Client|Additional Named Insured|Business" was not executed. Reason: Selected-iteration condition evaluated false: Individual == NULL
# Section: Policy Data Entry Process | Reusable flow: Common|Add Additional Named Insured | Source XTestStep: 3a13d49c-165b-131a-1b20-e05bcc0d794e
#    - Preserved source field action: WAIT (Exists) "Address 1" with "True"
#    - Preserved source field action: INPUT "Address 1" with "{TAB}100 Bridge St.{TAB}"
#    - Preserved source field action: INPUT "Zip code" with "12158{TAB}"
#    - Preserved source field action: INPUT "FEIN*" with "11-7464646{TAB}{TAB}"
# Active source step 0082 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
# Active source step 0084 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
# Active source step 0086 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0141 "Enter Basic UM info" contains conditionally inapplicable field action(s):
#    - INPUT "UM Coverage" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: UM Coverage>{TAB}{TAB}{TAB})" when 'UM Coverage' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UM Coverage' != NULL
#    - INPUT "UM Coverage Options" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: UM Coverage Options>{TAB})" when 'UM Coverage Options' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UM Coverage Options' != NULL
#    - VERIFY "UM Type Default read only" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UM Type - Read Only>)" when 'UM Type - Read Only' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UM Type - Read Only' != NULL
#    - INPUT "Stacked UM" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Stacked UM>{TAB}{TAB}{TAB})" when 'Stacked UM' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stacked UM' != NULL
#    - INPUT "UMBIPD Limit*" with "{CLICK}50,000{RETURN}{TAB}{TAB}{TAB}{TAB}" when 'UM Type Default' == "UMBIPD CSL". Reason: Value condition evaluated false for the selected iteration: 'UM Type Default' == "UMBIPD CSL"
#    - INPUT "UIM Type Default Selections" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: UIM Type Default>{TAB}{TAB}{TAB})" when 'UIM Type Default' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM Type Default' != NULL
#    - VERIFY "UIM Type Default Read Only" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UIM Type Default_ReadOnly>)" when 'UIM Type Default_ReadOnly' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM Type Default_ReadOnly' != NULL
#    - VERIFY "UIM CSL Limit Read Only" with "a blank/not-supplied reusable parameter ({Regex[<BLANK — reusable-block parameter is not supplied: UIM Limit Read Only>| \"$\"<BLANK — reusable-block parameter is not supplied: UIM Limit Read Only>]})" when 'UIM Limit Read Only' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM Limit Read Only' != NULL
#    - INPUT "Accept UM for PPT" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Accept UM for PPT>)" when 'Accept UM for PPT' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept UM for PPT' != NULL
#    - VERIFY "Accept UM for PPT" with "True" when 'Accept UM for PPT' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept UM for PPT' != NULL
#    - WAIT (Exists) "UMPD Limit" with "True" when 'UMPD Limit - editable' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UMPD Limit - editable' != NULL
#    - INPUT "UMPD Limit" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: UMPD Limit - editable>{TAB})" when 'UMPD Limit - editable' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UMPD Limit - editable' != NULL
#    - VERIFY "UMPD Limit - read only" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UMPD Limit - read only>)" when 'UMPD Limit - read only' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UMPD Limit - read only' != NULL
#    - INPUT "Economic Loss Coverage Only" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Economic Loss Only>{TAB})" when 'Economic Loss Only' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Economic Loss Only' != NULL
#    - WAIT (Enabled) "UMBIPD Limit*" with "True" when 'UM Type Default' == "UMBIPD CSL". Reason: Value condition evaluated false for the selected iteration: 'UM Type Default' == "UMBIPD CSL"
#    - INPUT "UMBIPD Limit*" with "{CLICK}50,000{ENTER}{TAB}{TAB}{TAB}" when 'UM Type Default' == "UMBIPD CSL". Reason: Value condition evaluated false for the selected iteration: 'UM Type Default' == "UMBIPD CSL"
# Active source step 0142 "Enter Basic UIM info" contains conditionally inapplicable field action(s):
#    - INPUT "Include UIM" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Include UIM>{TAB}{TAB}{TAB})" when 'Include UIM' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Include UIM' != NULL
#    - INPUT "Stacked UM" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Stacked UM>)" when 'Stacked UM' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stacked UM' != NULL
#    - INPUT "Stacked UIM" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Stacked UIM>{TAB})" when 'Stacked UIM' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stacked UIM' != NULL
#    - INPUT "UIM Type Default Selections" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: UIM Type Default>{TAB}{TAB}{TAB})" when 'UIM Type Default' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM Type Default' != NULL
#    - INPUT "UIM CSL Limit*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: UIM Limit>{TAB}{TAB})" when 'UIM Limit' != NULL. Reason: Value condition evaluated false for the selected iteration: 'UIM Limit' != NULL
#    - INPUT "Accept UM for PPT" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Accept UM for PPT>{TAB})" when 'Accept UM for PPT' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept UM for PPT' != NULL
# Source step 0150: "Add Hired Auto Liability - CA" in module "State Details|Hired Auto Liability" was not executed. Reason: Selected-iteration condition evaluated false: State == "CA"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-44f9-0003-9606267e86fb
#    - Preserved source field action: INPUT "Hired Auto Liability" with "True"
#    - Preserved source field action: INPUT "Employee Hired Autos CheckBox" with "True"
#    - Preserved source field action: INPUT "Volunteer Hired Autos CheckBox" with "True"
#    - Preserved source field action: INPUT "Cost of Hire Primary" with "{TAB}250{TAB}"
#    - Preserved source field action: INPUT "Cost of Hire Excess" with "{TAB}500{TAB}"
# Source step 0155: "State Details|Hired Auto PD Without Driver - CA" in module "State Details|Hired Auto PD Without Driver" was not executed. Reason: Selected-iteration condition evaluated false: State == "CA"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-3354-f2c0-30dacee00a42
#    - Preserved source field action: INPUT "Hired Auto Physical Damage Without Driver" with "True"
#    - Preserved source field action: INPUT "OTC Coverage Form" with "{TAB}Comprehensive{TAB}"
#    - Preserved source field action: INPUT "OTC Deductible*" with "{Click}$50{TAB}"
#    - Preserved source field action: INPUT "Collision Deductible*" with "$500{TAB}{TAB}"
#    - Preserved source field action: INPUT "PD Without Driver Cost of Hire" with "$500{TAB}"
# Source step 0158: "State Details|Hired Auto Physical Damage With Driver - CA" in module "State Details|Hired Auto Physical Damage With Driver" was not executed. Reason: Selected-iteration condition evaluated false: State == "CA"
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-268e-eed6-8fdf06a67b0e
#    - Preserved source field action: INPUT "Hired Auto Physical Damage With Driver" with "True"
#    - Preserved source field action: INPUT "OTC Coverage Form" with "Comprehensive{TAB}"
#    - Preserved source field action: INPUT "OTC Deductible*" with "$50{TAB}"
#    - Preserved source field action: INPUT "Collision Deductible*" with "{Click}$100{TAB}"
#    - Preserved source field action: INPUT "Cost of Hire" with "$1000{TAB}"
#    - Preserved source field action: INPUT "Vehicle Information" with "2018 Subaru Forester{TAB}{TAB}"
# Source step 0159: "Add Supplemental Spousal" in module "State Details|Misc" was not executed. Reason: Selected-iteration condition evaluated false: 'Add Supplemental Spousal' != NULL
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-60cf-fc74-dcf1797202a2
#    - Preserved source field action: INPUT "Supplemental Spousal Coverage" with "{Click}Yes{TAB}"
# Source step 0161: "Add (ND) Rental Vehicle Coverage" in module "State Details|Misc" was not executed. Reason: Selected-iteration condition evaluated false: 'Add (ND) Rental Vehicle Coverage' != NULL
# Section: Policy Data Entry Process > State Details | Reusable flow: BAP|ST|Add Policy Level Coverages | Source XTestStep: 3a13d49c-165b-98aa-8b44-765ade540cdd
#    - Preserved source field action: INPUT "Rental Vehicle Liability Checkbox" with "True"
#    - Preserved source field action: WAIT (Exists) "Cost Of Hire*" with "True"
#    - Preserved source field action: INPUT "Cost Of Hire*" with "100,000"
# Active source step 0174 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Body Style" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Body Style>{TAB}{TAB})" when 'Body Style' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Body Style' != NULL
#    - INPUT "Value Basis" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Value Basis>{TAB}{TAB})" when 'Value Basis' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Value Basis' != NULL
#    - INPUT "Original Cost New*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Original Cost New>{TAB}{TAB})" when 'Original Cost New' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Original Cost New' != NULL
#    - INPUT "Stated Amount*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Stated Amount>{TAB}{TAB})" when 'Stated Amount' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stated Amount' != NULL
# Source step 0179: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Source step 0180: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Active source step 0181 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "2nd Class Category" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Category>{TAB})" when '2nd Class Category' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Category' != NULL
#    - INPUT "2nd Class Code*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Code>{TAB}{TAB})" when '2nd Class Code' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Code' != NULL
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0182: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0183: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Source step 0184: "Add/Remove Physical Damage" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
#    - Preserved source field action: INPUT "OTC Causes of Loss*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: OTC Causes of Loss>{TAB})" when 'OTC Causes of Loss' != NULL
#    - Preserved source field action: INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL
#    - Preserved source field action: INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL
#    - Preserved source field action: INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL
#    - Preserved source field action: INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL
# Source step 0187: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0189: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Active source step 0203 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Body Style" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Body Style>{TAB}{TAB})" when 'Body Style' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Body Style' != NULL
#    - INPUT "Value Basis" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Value Basis>{TAB}{TAB})" when 'Value Basis' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Value Basis' != NULL
#    - INPUT "Original Cost New*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Original Cost New>{TAB}{TAB})" when 'Original Cost New' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Original Cost New' != NULL
#    - INPUT "Stated Amount*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Stated Amount>{TAB}{TAB})" when 'Stated Amount' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stated Amount' != NULL
# Source step 0208: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Source step 0209: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Active source step 0210 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "2nd Class Category" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Category>{TAB})" when '2nd Class Category' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Category' != NULL
#    - INPUT "2nd Class Code*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Code>{TAB}{TAB})" when '2nd Class Code' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Code' != NULL
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0211: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0212: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Active source step 0213 "Add/Remove Physical Damage" contains conditionally inapplicable field action(s):
#    - INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Full Safety Glass Coverage' != NULL
#    - INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Collision Coverage' != NULL
#    - INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Inspection Method' != NULL
#    - INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Lease Gap' != NULL
#    - INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Auto Loan Cov' != NULL
# Source step 0216: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0218: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Active source step 0232 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Body Style" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Body Style>{TAB}{TAB})" when 'Body Style' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Body Style' != NULL
#    - INPUT "Value Basis" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Value Basis>{TAB}{TAB})" when 'Value Basis' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Value Basis' != NULL
#    - INPUT "Original Cost New*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Original Cost New>{TAB}{TAB})" when 'Original Cost New' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Original Cost New' != NULL
#    - INPUT "Stated Amount*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Stated Amount>{TAB}{TAB})" when 'Stated Amount' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stated Amount' != NULL
# Source step 0237: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Source step 0238: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Active source step 0239 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "2nd Class Category" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Category>{TAB})" when '2nd Class Category' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Category' != NULL
#    - INPUT "2nd Class Code*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Code>{TAB}{TAB})" when '2nd Class Code' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Code' != NULL
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0240: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0241: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Source step 0242: "Add/Remove Physical Damage" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
#    - Preserved source field action: INPUT "OTC Causes of Loss*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: OTC Causes of Loss>{TAB})" when 'OTC Causes of Loss' != NULL
#    - Preserved source field action: INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL
#    - Preserved source field action: INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL
#    - Preserved source field action: INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL
#    - Preserved source field action: INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL
# Source step 0245: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0247: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Active source step 0261 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Body Style" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Body Style>{TAB}{TAB})" when 'Body Style' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Body Style' != NULL
#    - INPUT "Stated Amount*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Stated Amount>{TAB}{TAB})" when 'Stated Amount' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Stated Amount' != NULL
# Active source step 0266 "Enter General Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Engine Size' != NULL
#    - INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept Liability' != NULL
# Active source step 0267 "Enter General Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Engine Size' != NULL
#    - INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept Liability' != NULL
# Active source step 0268 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0269: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0270: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Source step 0271: "Add/Remove Physical Damage" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
#    - Preserved source field action: INPUT "OTC Causes of Loss*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: OTC Causes of Loss>{TAB})" when 'OTC Causes of Loss' != NULL
#    - Preserved source field action: INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL
#    - Preserved source field action: INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL
#    - Preserved source field action: INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL
#    - Preserved source field action: INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL
# Source step 0274: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0276: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Active source step 0290 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Value Basis" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Value Basis>{TAB}{TAB})" when 'Value Basis' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Value Basis' != NULL
#    - INPUT "Original Cost New*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Original Cost New>{TAB}{TAB})" when 'Original Cost New' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Original Cost New' != NULL
# Active source step 0295 "Enter General Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Used as Showroom' != NULL
#    - INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept Liability' != NULL
# Active source step 0296 "Enter General Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Used as Showroom' != NULL
#    - INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept Liability' != NULL
# Active source step 0297 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "2nd Class Category" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Category>{TAB})" when '2nd Class Category' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Category' != NULL
#    - INPUT "2nd Class Code*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Code>{TAB}{TAB})" when '2nd Class Code' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Code' != NULL
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0298: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0299: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Source step 0300: "Add/Remove Physical Damage" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
#    - Preserved source field action: INPUT "OTC Causes of Loss*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: OTC Causes of Loss>{TAB})" when 'OTC Causes of Loss' != NULL
#    - Preserved source field action: INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL
#    - Preserved source field action: INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL
#    - Preserved source field action: INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL
#    - Preserved source field action: INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL
# Source step 0303: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0305: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Active source step 0319 "Enter VIN" contains conditionally inapplicable field action(s):
#    - INPUT "Value Basis" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Value Basis>{TAB}{TAB})" when 'Value Basis' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Value Basis' != NULL
#    - INPUT "Original Cost New*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Original Cost New>{TAB}{TAB})" when 'Original Cost New' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Original Cost New' != NULL
# Source step 0324: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a1fad08-55d6-2adf-5ade-534189759957
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Source step 0325: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d964-df5b-2a491eba39bd
#    - Preserved source field action: INPUT "Used As Showroom" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Used as Showroom>{TAB})" when 'Used as Showroom' != NULL
#    - Preserved source field action: INPUT "Engine Size (cc)*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Engine Size>{TAB}{TAB})" when 'Engine Size' != NULL
#    - Preserved source field action: INPUT "Accept Liability Coverage" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Accept Liability>{ENTER}{TAB}{TAB})" when 'Accept Liability' != NULL
# Active source step 0326 "Enter Risk Specific" contains conditionally inapplicable field action(s):
#    - INPUT "2nd Class Category" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Category>{TAB})" when '2nd Class Category' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Category' != NULL
#    - INPUT "2nd Class Code*" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: 2nd Class Code>{TAB}{TAB})" when '2nd Class Code' != NULL. Reason: Value condition evaluated false for the selected iteration: '2nd Class Code' != NULL
#    - INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
#    - INPUT "Public Group" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Public Group>{ENTER}{TAB}{TAB})" when 'Public Group' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Group' != NULL
#    - INPUT "Public Vehicle Type*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Public Vehicle Type>{TAB}{TAB})" when 'Public Vehicle Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Public Vehicle Type' != NULL
#    - INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Group Type' != NULL
# Source step 0327: "Verify Group Type does not match Business Parameters" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-b316-6269-9946-068c875e5e66
#    - Preserved source field action: VERIFY (InnerText) "Group Type" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Group Type>)" when 'Group Type' != NULL
# Source step 0328: "Enter Group Type" in module "Risk Schedule|Risk Specific" was not executed. Reason: Selected-iteration condition evaluated false: 'Group Type' != NULL
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a19c261-bf07-93b2-4839-f62a6540103e
#    - Preserved source field action: INPUT "Group Type" with "{TAB}{TAB}" when 'Group Type' != NULL
#    - Preserved source field action: INPUT "Group Type" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Group Type>{ENTER}{TAB})" when 'Group Type' != NULL
# Source step 0329: "Add/Remove Physical Damage" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-a113-18b8-482487df16a6
#    - Preserved source field action: INPUT "OTC Causes of Loss*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: OTC Causes of Loss>{TAB})" when 'OTC Causes of Loss' != NULL
#    - Preserved source field action: INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Collision Coverage>)" when 'Collision Coverage' != NULL
#    - Preserved source field action: INPUT "Inspection Method*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Inspection Method>{TAB})" when 'Inspection Method' != NULL
#    - Preserved source field action: INPUT "Lease Gap" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL
#    - Preserved source field action: INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL
# Source step 0332: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-3c89-874c-6a18237a30c3
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Source step 0334: "Answer Collision if Not Null" in module "Risk Schedule|Physical Damage" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Policy Data Entry Process > Add Risks | Reusable flow: BAP|Add a Risk | Source XTestStep: 3a13d49c-165b-d58e-1cbc-bb38baa35007
#    - Preserved source field action: INPUT "Collision Coverage" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Collision Coverage>{TAB}{TAB})" when 'Collision Coverage' != NULL
# Active source step 0345 "Add Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "HiredAuto CA2001 First Name" with "{TAB}" when 'First Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'First Name' != NULL
#    - INPUT "HiredAuto CA2001 Last Name" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Last Name>{TAB})" when 'Last Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Last Name' != NULL
#    - INPUT "HiredAuto CA2001 Address1" with "{TAB}" when 'Address 1' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Address 1' != NULL
#    - INPUT "HiredAuto CA2001 ZipCode" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Zip Code>{TAB})" when 'Zip Code' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Zip Code' != NULL
#    - INPUT "OK" with "X" when 'First Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'First Name' != NULL
#    - INPUT "HiredAuto CA2001 First Name" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: First Name>{TAB})" when 'First Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'First Name' != NULL
#    - INPUT "HiredAuto CA2001 Address1" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Address 1>{TAB})" when 'Address 1' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Address 1' != NULL
# Active source step 0353 "Add Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "HiredAuto CA2001 First Name" with "{TAB}" when 'First Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'First Name' != NULL
#    - INPUT "HiredAuto CA2001 Last Name" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Last Name>{TAB})" when 'Last Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Last Name' != NULL
#    - INPUT "HiredAuto CA2001 Address1" with "{TAB}" when 'Address 1' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Address 1' != NULL
#    - INPUT "HiredAuto CA2001 ZipCode" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Zip Code>{TAB})" when 'Zip Code' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Zip Code' != NULL
#    - INPUT "OK" with "X" when 'First Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'First Name' != NULL
#    - INPUT "HiredAuto CA2001 First Name" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: First Name>{TAB})" when 'First Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'First Name' != NULL
#    - INPUT "HiredAuto CA2001 Address1" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Address 1>{TAB})" when 'Address 1' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Address 1' != NULL
# Active source step 0367 "Verify UM/UIM, PIP" contains conditionally inapplicable field action(s):
#    - VERIFY (Value) "Accept UM Editable" with "Yes" when 'Accept UM Editable' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept UM Editable' != NULL
#    - VERIFY (InnerText) "Accept UIM" with "Yes" when 'Accept UIM' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Accept UIM' != NULL
#    - VERIFY (InnerText) "Additional Limit" with "Yes" when 'Additional Limit' != NULL || 'Added FPB' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Additional Limit' != NULL || 'Added FPB' != NULL
#    - VERIFY (InnerText) "Subject to No Fault" with "Yes" when 'Subject to No-Fault (read only)' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Subject to No-Fault (read only)' != NULL
# Source step 0374: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: Selected-iteration condition evaluated false: 'Seasonal Produce Trailers' != NULL
# Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-34d5-ede4-2553d1eb08cd
#    - Preserved source field action: INPUT "Seasonal Produce Trailers" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Seasonal Produce Trailers>{TAB})"
#    - Preserved source field action: WAIT (Exists) "Coverage begin date:" with "True"
#    - Preserved source field action: INPUT "Coverage end date:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Coverage End Date>{TAB})"
#    - Preserved source field action: INPUT "Produce Carried" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Produce Carried>{TAB})"
# Active source step 0375 "Add Coverages" contains conditionally inapplicable field action(s):
#    - INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Full Safety Glass Coverage' != NULL && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Lease Gap" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Lease Gap' != NULL
#    - INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL  && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Auto Loan Cov' != NULL  && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Rental Reimbursement" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Rental Reimbursement>{TAB})" when 'Rental Reimbursement' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Rental Reimbursement' != NULL
#    - INPUT "Full Cov Glass" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Full Glass>{TAB})" when 'Full Glass' != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Full Glass' != NULL && 'Vehicle Type' == "Private Passenger"
# Source step 0383: "Enter General Coverage" in module "Risk Schedule|General Coverage" was not executed. Reason: Selected-iteration condition evaluated false: 'Seasonal Produce Trailers' != NULL
# Section: Policy Data Entry Process > Add Risk Level Coverages | Reusable flow: BAP|ST|Add Risk Level Coverages | Source XTestStep: 3a13d49c-165b-34d5-ede4-2553d1eb08cd
#    - Preserved source field action: INPUT "Seasonal Produce Trailers" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Seasonal Produce Trailers>{TAB})"
#    - Preserved source field action: WAIT (Exists) "Coverage begin date:" with "True"
#    - Preserved source field action: INPUT "Coverage end date:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Coverage End Date>{TAB})"
#    - Preserved source field action: INPUT "Produce Carried" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Produce Carried>{TAB})"
# Active source step 0384 "Add Coverages" contains conditionally inapplicable field action(s):
#    - INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Full Safety Glass Coverage' != NULL && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Lease Gap" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Lease Gap' != NULL
#    - INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL  && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Auto Loan Cov' != NULL  && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Rental Reimbursement" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Rental Reimbursement>{TAB})" when 'Rental Reimbursement' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Rental Reimbursement' != NULL
#    - INPUT "Towing" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Towing>{ENTER}{TAB})" when Towing != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: Towing != NULL && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Full Cov Glass" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Full Glass>{TAB})" when 'Full Glass' != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Full Glass' != NULL && 'Vehicle Type' == "Private Passenger"
# Active source step 0393 "Add Coverages" contains conditionally inapplicable field action(s):
#    - INPUT "Full Safety Glass Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Full Safety Glass Coverage>{TAB})" when 'Full Safety Glass Coverage' != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Full Safety Glass Coverage' != NULL && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Lease Gap" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Lease Gap>{TAB})" when 'Lease Gap' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Lease Gap' != NULL
#    - INPUT "Auto Loan Cov" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Auto Loan Cov>{TAB})" when 'Auto Loan Cov' != NULL  && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Auto Loan Cov' != NULL  && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Loan/Lease Gap" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Loan/Lease Gap>{ENTER}{TAB}{TAB})" when 'Loan/Lease Gap' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Loan/Lease Gap' != NULL
#    - INPUT "Tapes Coverage" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Tapes Coverage>)" when 'Tapes Coverage' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Tapes Coverage' != NULL
#    - INPUT "Audio Visual" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Audio Visual>{TAB})" when 'Audio Visual' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Audio Visual' != NULL
#    - INPUT "AV Cost New*" with "{TAB}500{TAB}{TAB}" when 'Audio Visual' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Audio Visual' != NULL
#    - INPUT "Rental Reimbursement" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Rental Reimbursement>{TAB})" when 'Rental Reimbursement' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Rental Reimbursement' != NULL
#    - INPUT "Towing" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Towing>{ENTER}{TAB})" when Towing != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: Towing != NULL && 'Vehicle Type' == "Private Passenger"
#    - INPUT "Full Cov Glass" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Full Glass>{TAB})" when 'Full Glass' != NULL && 'Vehicle Type' == "Private Passenger". Reason: Value condition evaluated false for the selected iteration: 'Full Glass' != NULL && 'Vehicle Type' == "Private Passenger"
# Active source step 0408 "Verify Mandatory Endorsements" contains conditionally inapplicable field action(s):
#    - VERIFY (InnerText) "Endorsement Schedule > <Row> > $1" with "Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure" when 'Endorsement Type' =="[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
#    - VERIFY (InnerText) "Endorsement Schedule > <Row> > $1" with "Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure" when 'Endorsement Type' =="[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
#    - VERIFY (InnerText) "Endorsement Table > <Row> > $2" with "Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure" when 'Endorsement Type' =="[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="[CA2395] Kentucky Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
#    - VERIFY (InnerText) "Endorsement Table > <Row> > $2" with "Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure" when 'Endorsement Type' =="[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="[CA2396] Connecticut Silica Or Silica-Related Dust Exclusion For Covered Autos Exposure"
# Active source step 0413 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
# Active source step 0422 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
# Active source step 0431 "Enter required endorsement info" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "IFRAME > Duck Creek Policy > Click Add Excluded Driver" with "True" when 'Add Excluded Driver' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Add Excluded Driver' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Click Add Excluded Driver" with "X" when 'Add Excluded Driver' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Add Excluded Driver' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Add Driver Name" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Driver Name>{TAB})" when 'Driver Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Driver Name' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Excluded Driver Action Taken" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Driver Action Taken>{TAB})" when 'Driver Action Taken' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Driver Action Taken' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > State Licensed" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: State Licensed>{TAB})" when 'State Licensed' != NULL. Reason: Value condition evaluated false for the selected iteration: 'State Licensed' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Date Of Birth" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Date of Birth>{TAB})" when 'Date of Birth' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Date of Birth' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Exclusion Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Exclusion Type>{TAB})" when 'Exclusion Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Exclusion Type' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA0167 - Input Cost Of Hire" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Cost of Hire>{TAB})" when 'Cost of Hire' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Cost of Hire' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA9940 - Contract Provisions" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Contract Provisions>{ENTER}{TAB})" when 'Contract Provisions' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Contract Provisions' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA9948 - Classes Of Commodities Transported" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Commodities Transported>{ENTER}{TAB})" when 'Commodities Transported' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Commodities Transported' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA9990 - Amount Per Day Maximum" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Amount Per Day Max>{ENTER}{TAB})" when 'Amount Per Day Max' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Amount Per Day Max' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # Days Insured" with "{TAB}300{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # of Trailers" with "{TAB}50{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Death Benefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Death Benefits>{TAB})" when 'Death Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Death Benefits' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > DisabilityBenefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Disability Benefits>{TAB})" when 'Disability Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Disability Benefits' != NULL
# Active source step 0440 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
# Active source step 0449 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
#    - INPUT "IFRAME > Duck Creek Policy > CA9990 - Amount Per Day Maximum" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Amount Per Day Max>{ENTER}{TAB})" when 'Amount Per Day Max' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Amount Per Day Max' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # Days Insured" with "{TAB}300{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # of Trailers" with "{TAB}50{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Death Benefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Death Benefits>{TAB})" when 'Death Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Death Benefits' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > DisabilityBenefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Disability Benefits>{TAB})" when 'Disability Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Disability Benefits' != NULL
# Active source step 0458 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
# Active source step 0467 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
#    - INPUT "IFRAME > Duck Creek Policy > Death Benefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Death Benefits>{TAB})" when 'Death Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Death Benefits' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > DisabilityBenefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Disability Benefits>{TAB})" when 'Disability Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Disability Benefits' != NULL
# Active source step 0476 "Enter required endorsement info" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "IFRAME > Duck Creek Policy > Click Add Excluded Driver" with "True" when 'Add Excluded Driver' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Add Excluded Driver' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Click Add Excluded Driver" with "X" when 'Add Excluded Driver' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Add Excluded Driver' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Add Driver Name" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Driver Name>{TAB})" when 'Driver Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Driver Name' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Excluded Driver Action Taken" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Driver Action Taken>{TAB})" when 'Driver Action Taken' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Driver Action Taken' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > State Licensed" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: State Licensed>{TAB})" when 'State Licensed' != NULL. Reason: Value condition evaluated false for the selected iteration: 'State Licensed' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Date Of Birth" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Date of Birth>{TAB})" when 'Date of Birth' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Date of Birth' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Exclusion Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Exclusion Type>{TAB})" when 'Exclusion Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Exclusion Type' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA0167 - Input Cost Of Hire" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Cost of Hire>{TAB})" when 'Cost of Hire' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Cost of Hire' != NULL
#    - WAIT (Exists) "IFRAME > Duck Creek Policy > [CA2325] Leased Workers Coverage" with "True" when 'Endorsement Type' == "[CA2325] Leased Workers Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' == "[CA2325] Leased Workers Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > CA9948 - Classes Of Commodities Transported" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Commodities Transported>{ENTER}{TAB})" when 'Commodities Transported' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Commodities Transported' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > CA9990 - Amount Per Day Maximum" with "a blank/not-supplied reusable parameter ({Click}<BLANK — reusable-block parameter is not supplied: Amount Per Day Max>{ENTER}{TAB})" when 'Amount Per Day Max' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Amount Per Day Max' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # Days Insured" with "{TAB}300{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Trailer Interchange - Enter # of Trailers" with "{TAB}50{TAB}" when 'Endorsement Type' =="Trailer Interchange Coverage". Reason: Value condition evaluated false for the selected iteration: 'Endorsement Type' =="Trailer Interchange Coverage"
#    - INPUT "IFRAME > Duck Creek Policy > Death Benefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Death Benefits>{TAB})" when 'Death Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Death Benefits' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > DisabilityBenefits" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Disability Benefits>{TAB})" when 'Disability Benefits' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Disability Benefits' != NULL
# Active source step 0485 "Enter required endorsement info" contains conditionally inapplicable field action(s):
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
# Active source step 0493 "Enter required info" contains conditionally inapplicable field action(s):
#    - INPUT "IFRAME > Duck Creek Policy > Or Business Name*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Business Name>{TAB})" when 'Business Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Business Name' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Vehicle Association*" with "{Click}" when 'Vehicle Association' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Vehicle Association' != NULL
#    - INPUT "IFRAME > Duck Creek Policy > Vehicle Association*" with "{DOUBLECLICK}{DOWN}{DOWN}{ENTER}{TAB}" when 'Vehicle Association' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Vehicle Association' != NULL
#    - WAIT (InnerText) "IFRAME > Duck Creek Policy > Vehicle Association*" with "\"\"" when 'Vehicle Association' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Vehicle Association' != NULL
# Active source step 0498 "Enter required info" contains conditionally inapplicable field action(s):
#    - INPUT "IFRAME > Duck Creek Policy > Or Business Name*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Business Name>{TAB})" when 'Business Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Business Name' != NULL
# Active source step 0503 "Enter required info" contains conditionally inapplicable field action(s):
#    - INPUT "IFRAME > Duck Creek Policy > Or Business Name*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Business Name>{TAB})" when 'Business Name' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Business Name' != NULL
# Source step 0581: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0582: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0583: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: Policy Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-13e5-feef-a2b5-cae3a5d191a3
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BAP\\BAP StraightThrough TestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-13e5-5ab1-b29d-bd727c430ffc
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BAP\\BAP StraightThrough TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-13e5-ca53-fc3a-a8811d917fb5
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\BAP\\BAP StraightThrough TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13e5-4ec1-53c0-c9147345c2f1
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13e5-243a-246f-92d97715484c
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13e5-7048-2c61-feb01131b653
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13e5-1ef3-e97b-f6a3ee85a6d5
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-13e5-98b0-0926-9a6ea74e6772
#    - I run "taskkill /f /im msEdge.exe"
