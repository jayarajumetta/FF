# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 007_IM_Basic_Policy_AZ.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @IM @basic_policy @Arizona @Edge @manual @automated
Feature: Execute IM | Basic Policy for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the IM | Basic Policy workflow for Arizona (AZ)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: IM | Basic Policy using representative iteration Arizona (AZ)

    # Source step 0037: Deselect Quick Quote | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-baea-fc85-843e0b462e26
    Then I wait until "Quick Quote" exists
    When I enter or select "False" in "Quick Quote"

    # Source step 0038: Wait for Non-Quick Quote Element to Appear | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-ac73-2258-77271da65807
    Then I wait until "Underwriting Info" exists

    # Source step 0039: Select Business Insured | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-ba4e-70ab-2fddc1e53a30
    When I enter or select "Business{ENTER}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0040: Enter Business Name | Module: Client|Named Insured|Business
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-afee-adb2-16b93c762899
    Then I wait until "Business Name" is visible
    When I enter or select "AZ IM Testing, Inc.{TAB}" in "Business Name"

    # Source step 0041: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-e0be-7cfd-4133e268b3f9
    When I enter or select "Corporation{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I perform keyboard action "{TAB}" on "Address1"
    When I enter or select "{TAB}85016{TAB}" in "ZipCode"
    When I enter or select "4201 N. 24th St{TAB}" in "Address1"

    # Source step 0042: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-83a0-cae3-d02d409f7316
    # Runtime control: If Years in Business Exists > Check Years in Business
    Then "Years In Business" should exist

    # Source step 0043: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-5638-4d11-366b2d2dda1c
    # Runtime control: If Years in Business Exists > Then Input Years
    When I enter or select "6{TAB}" in "Years In Business"

    # Source step 0044: Enter FEIN | Module: Client|Named Insured|Business
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-c5e9-eccd-b3778fc99bfd
    When I enter a RANDOM value matching "6 random digits/characters from source expression 486{RND[6]}{TAB}" in "FEIN"

    # Source step 0045: Enter Details in Other Information Section | Module: Client|Other Insured Info
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-0b67-ea05-a131fa3c03bf
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}Auditor Doe{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0046: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-8298-54db-43889fb5edce
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0047: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-996b-f29f-d2de8058d631
    When I retain hard-coded value "Arizona" as runtime value "State"
    When I retain hard-coded value "IM" as runtime value "Product (LOB)"
    When I retain hard-coded value "IM_BASIC" as runtime value "FormOnPolicyDocName"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"

    # Source step 0048: Add a new Associated Client - Business Owner Type - Click Add Client | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-0237-8718-e7857b6552f0
    # Source template XTestStep: 3a13d49c-165b-ce02-83cf-cd6904f97e54
    Then I wait until "Add Client" exists
    When I perform keyboard action "{TAB}" on "Add Client"
    When I click or select "Add Client"

    # Source step 0049: Check if IndividualType Exists | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-0fce-633d-f148a179033b
    # Source template XTestStep: 3a13d49c-165b-d0b1-7d57-b7cecf62671b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Condition
    Then "IndividualType" should not exist

    # Source step 0050: AJAX Error Check | Module: AJAX Error
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-90d4-c7c4-34e4afe4471a
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Check for AJAX Error
    Then "AJAX Error Check" should exist

    # Source step 0051: Set buffer for Error | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-742f-be97-b5b259ccf349
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I derive and retain the RUNTIME-DERIVED buffer expression "The scripts experienced an AJAX error with the following information: {B[AJAX]}" as runtime value "AJAX Error"

    # Source step 0052: Force a fail | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-fc4f-89ec-af2ceb5f1e02
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    Then I evaluate the source-defined expression for "Force a fail" using "Expression='FALSE' == 'TRUE'"

    # Source step 0053: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I click or select "Billing"

    # Source step 0054: Fill Out Required Fields on Billing Screen | Module: Billing
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-315a-3b12-4a479c858c7a
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
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

    # Source step 0055: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I wait "3000" milliseconds

    # Source step 0056: Complete the Associated Client Info | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-2c71-69a2-0cd77dfa29ff
    # Source template XTestStep: 3a13d49c-165b-71c5-b893-c4235f3b547a
    When I enter or select "{TAB}{CLICK}Business Owner{TAB}" in "IndividualType"
    Then I wait until "Please verify SSN*" exists

    # Source step 0057: Enter Client Details | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-bf8a-7858-37a80501f8fe
    # Source template XTestStep: 3a13d49c-165b-200d-d11b-a6ba7f5f21d0
    When I enter or select "{TAB}{TAB}" in "FirstName"
    When I enter a RANDOM value matching "^[a-z]{1}$" in "MiddleName"
    When I enter a RANDOM value matching "^[a-z]{7}$" in "LastName"
    When I enter or select "01-01-1985{TAB}" in "DateOfBirth"
    When I enter or select "{TAB}344 Rt 9w{TAB}" in "Address1"
    When I enter or select "{TAB}Glenmont{TAB}{TAB}" in "City"
    When I enter or select "New York{TAB}{TAB}{TAB}" in "State"
    When I enter or select "{TAB}12077{TAB}{TAB}" in "ZipCode"
    When I enter or select "Male{TAB}" in "Gender"
    Then I wait until "Client Search" exists
    When I click or select "Client Search"
    When I enter a RANDOM value matching "^[a-z]{4}$" in "FirstName"

    # Source step 0058: Verify no results returned and click OK | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-6295-d02f-639f9519136f
    # Source template XTestStep: 3a13d49c-165b-32d5-f6ed-f265f9f9c6c8
    Then "Search Results > Duck Creek Policy > First Checkbox" should not exist
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0059: Order and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-36ef-053b-c24a1b41bfca
    # Source template XTestStep: 3a13d49c-165b-2f1c-c197-ca3b93b64298
    When I click or select "Order SSN"
    When I perform keyboard action "{TAB}" on "Enter SSN*"
    When I enter or select "{TAB}736849971{TAB}" in "Enter SSN*"
    When I click or select "Enter SSN*"

    # Source step 0060: Does Verify Exist | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-6afc-5893-aa63cc2804e6
    # Source template XTestStep: 3a13d49c-165b-ba0f-6727-be7d60a0ce09
    # Runtime control: If Verify does not exist > Condition
    Then "Verify" should not exist

    # Source step 0061: Click Complete | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-b016-2abb-0e1599c8ba29
    # Source template XTestStep: 3a13d49c-165b-95b2-6c84-0c54eb4a6437
    # Runtime control: If Verify does not exist > Then
    When I click or select "Complete"

    # Source step 0062: Click Detail and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-fe4f-fe31-841a842cbedb
    # Source template XTestStep: 3a13d49c-165b-6230-e27e-9c3d0e9cbe27
    # Runtime control: If Verify does not exist > Then
    When I click or select "Detail"
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0063: Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-6250-7c13-b61fe8e57a0a
    # Source template XTestStep: 3a13d49c-165b-de87-4c4c-3c66d28b8da1
    # Runtime control: If Verify does not exist > Else
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0064: Perform Final Client Search | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-deb2-d3a7-d871e980d89e
    # Source template XTestStep: 3a13d49c-165b-f6d6-53ae-4d4d2d531699
    Then I wait until "Client Search" exists
    When I click or select "Client Search"

    # Source step 0065: Click Ok | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-38a2-df42-6c4574d87994
    # Source template XTestStep: 3a13d49c-165b-647c-ba91-85bcca049803
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"
    Then I wait until "Client Search" no longer exists

    # Source step 0066: Navigate to UW Info | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Client|Fill out Underwring Questions from Client Screen | Source XTestStep: 3a13d49c-1679-0e22-3c09-d01e3249c1b4
    When I click or select "Underwriting Info"

    # Source step 0067: Underwriting Info | Update General UW Questions | Module: Underwriting Info | General UW Questions
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Client|Fill out Underwring Questions from Client Screen | Source XTestStep: 3a13d49c-1679-5a01-a28f-af0067b34897
    Then I wait until "General UW Questions" exists
    When I click or select "Update Answers"

    # Source step 0068: Underwriting Info | Update General Liability History | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Client|Fill out Underwring Questions from Client Screen | Source XTestStep: 3a13d49c-1679-340c-3603-d4c76bad59d0
    When I click or select "Insurance History"
    When I enter or select "No{TAB}" in "Is there a Prior Carrier?*"

    # Source step 0069: Underwriting Info | Select Loss Experience | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Client|Fill out Underwring Questions from Client Screen | Source XTestStep: 3a13d49c-1679-9286-533c-8bdf6914b409
    When I click or select "Loss Experience"
    Then I wait until "Loss Experience Heading" exists
    When I click or select "No known losses"

    # Source step 0070: Navigate back to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Client|Fill out Underwring Questions from Client Screen | Source XTestStep: 3a13d49c-1679-12fe-fe6f-50bf68211bb7
    When I click or select "Return to Quote"

    # Source step 0071: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0072: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0073: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0074: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0075: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "10/17/2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0076: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0077: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Arizona{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0078: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"

    # Source step 0080: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"

    # Source step 0082: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0083: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0084: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0085: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AZ IM Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0088: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-db96-2f0e-1e230bb9a656
    When I wait "1500" milliseconds

    # Source step 0089: Insurance Score | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-84af-bc6a-3f9f6e937252
    # Runtime control: Do [max=120] > Condition
    Then "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS" should exist

    # Source step 0090: Check if it is BAP VT | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-faf3-28ce-cca724db461f
    # Runtime control: Do [max=120] > Loop > If BAP VT > Condition
    Then I evaluate the source-defined expression for "Check if it is BAP VT" using "Expression='{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"

    # Source step 0091: Click Insurance Score Consent if available | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-62c0-b9ad-e9b0b9d872db
    # Runtime control: Do [max=120] > Loop > If BAP VT > Then
    When I click or select "Insurance Score Consent"
    Then I wait until "IFRAME > Popup > Accept" exists
    When I click or select "IFRAME > Popup > Accept"
    Then I wait until "Insurance Score" exists

    # Source step 0092: Click Insurance Score and wait for Loading Window | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-6d8c-4d68-2f07c426a43c
    # Runtime control: Do [max=120] > Loop
    When I click or select "Insurance Score"

    # Source step 0093: Insurance Score | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-dba3-ee02-3503baa413fb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Condition
    Then "Reference Number" property "InnerText" should equals "\"\""

    # Source step 0094: Wait 1/2 Second for a max of 60 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-4380-87c1-5285e9b2c0eb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Loop
    When I wait "500" milliseconds

    # Source step 0098: Wait 1/2 Second | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3c33-8cfc-5b97480b4dd3
    When I wait "500" milliseconds

    # Source step 0099: IM Navigation Links | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Accounts Receivable Coverage | Source XTestStep: 3a13d49c-1679-1e06-eb46-4eee8eb64ba2
    # Step condition: 'Product' != "CPP"
    When I click or select "Policy Covg"

    # Source step 0100: Policy Covg - Main | Module: Policy Covg - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Accounts Receivable Coverage | Source XTestStep: 3a13d49c-1679-a33d-5609-9f7e703d1f25
    Then I wait until "Policy Covg" exists
    When I enter or select "{TAB}{CLICK}Accounts Receivable{ENTER}{TAB}" in "Coverage Form To Be Added"
    When I click or select "Add Coverage Form"

    # Source step 0101: Policy Covg - Accounts Receivable | Module: Policy Covg - Accounts Receivable
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Accounts Receivable Coverage | Source XTestStep: 3a13d49c-1679-517e-9726-19f28a7b8159
    When I enter or select "{TAB}{CLICK}Accounts Receivable{ENTER}" in "Description*"
    When I enter or select "{TAB}{CLICK}100" in "Coinsurance*"
    When I enter or select "{TAB}{CLICK}10,000" in "Away From Premises Lmt"
    When I enter or select "{TAB}{CLICK}Remote Site" in "Away From Premises Desc"
    When I click or select "OK"

    # Source step 0102: Navigate to Policy Covg Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Bailees Customers Coverage | Source XTestStep: 3a13d49c-1679-026b-9314-181c3a4f2951
    When I click or select "Policy Covg"

    # Source step 0103: Policy Covg - Main | Module: Policy Covg - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Bailees Customers Coverage | Source XTestStep: 3a13d49c-1679-6c3c-8664-10a7d70199fd
    Then I wait until "Policy Covg" exists
    When I enter or select "{TAB}{CLICK}Bailees Customers{ENTER}{TAB}" in "Coverage Form To Be Added"
    When I click or select "Add Coverage Form"

    # Source step 0104: Add Policy Covg - Bailees Customers | Module: Policy Covg - Bailees Cutomers
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Bailees Customers Coverage | Source XTestStep: 3a13d49c-1679-3845-b52b-0ff39688dc04
    Then I wait until "Coverage Form Display" exists
    When I perform keyboard action "{TAB}" on "Description*"
    When I enter or select "{CLICK}Bailees Customers{ENTER}{TAB}" in "Description*"
    When I enter or select "{TAB}5,000{TAB}" in "Property In Transit"
    When I click or select "Property Away From Your Premises Schedule"

    # Source step 0105: Policy Covg - Bailees - Property Away from Your Premises | Module: Policy Covg - Bailees - Property Away from Your Premises
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Bailees Customers Coverage | Source XTestStep: 3a13d49c-1679-be93-2079-acf8fd32c4dd
    When I click or select "Add Premises"
    When I enter or select "{CLICK}8 Center Road, Mahopac, NY, 10541{TAB}" in "Address (Street, City, State, Zip)"
    When I enter or select "{TAB}5000{TAB}" in "Limit"
    When I click or select "OK"

    # Source step 0106: Policy Covg - Bailees Cutomers Select OK to complete coverage | Module: Policy Covg - Bailees Cutomers
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Bailees Customers Coverage | Source XTestStep: 3a13d49c-1679-7d83-e4ff-3b5ab23feffd
    Then I wait until "Coverage Form Display" exists
    When I click or select "OK"

    # Source step 0107: Navigate to Policy Covg Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Contractors Equipment | Source XTestStep: 3a13d49c-1679-8583-bfa2-cdb957c93c79
    When I click or select "Policy Covg"

    # Source step 0108: Policy Covg - Main | Module: Policy Covg - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Contractors Equipment | Source XTestStep: 3a13d49c-1679-555b-b3fc-8c81dc0ba610
    Then I wait until "Policy Covg" exists
    When I enter or select "{TAB}{CLICK}Contractors Equipment{ENTER}{TAB}" in "Coverage Form To Be Added"
    When I click or select "Add Coverage Form"

    # Source step 0109: Add Policy Covg - Contractors Equipment | Module: Policy Covg - Contractors Equipment
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Contractors Equipment | Source XTestStep: 3a13d49c-1679-4cdd-232c-a3dbf445a3df
    Then I wait until "Coverage Form Display" exists
    When I perform keyboard action "{TAB}" on "Description*"
    When I enter or select "{TAB}{CLICK}Contractors Equipment{TAB}" in "Description*"
    When I enter or select "{TAB}{CLICK}90{TAB}" in "Coinsurance"
    When I enter or select "{TAB}{CLICK}$1,000{TAB}" in "Deductible"
    When I enter or select "{TAB}{CLICK}$5,000{TAB}" in "Boom Deductible"
    When I enter or select "{TAB}{CLICK}Roadbuilding  Contractors{TAB}" in "Type Of Contractor"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "Scheduled Coverage"
    When I enter or select "{TAB}{CLICK}250{TAB}" in "Rented Equipment Expense"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "Tools And Clothing Belonging To Your Employees"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "Misc Items Blanket Coverage"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "Rental Reimbursement"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "Hired Equipment"
    When I click or select "OK"

    # Source step 0110: Navigate to Policy Covg Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Computer Systems | Source XTestStep: 3a13d49c-1679-de34-67bc-63da08010651
    When I click or select "Policy Covg"

    # Source step 0111: Policy Covg - Main | Module: Policy Covg - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Computer Systems | Source XTestStep: 3a13d49c-1679-4d14-771f-a459562d0e24
    Then I wait until "Policy Covg" exists
    When I enter or select "{TAB}{CLICK}Computer Systems{ENTER}{TAB}" in "Coverage Form To Be Added"
    When I click or select "Add Coverage Form"

    # Source step 0112: Policy Covg - Computer Systems | Module: Policy Covg - Computer Systems
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Computer Systems | Source XTestStep: 3a13d49c-1679-da83-f2e1-b997243cd562
    Then I wait until "Coverage Form Display" exists
    When I perform keyboard action "{TAB}" on "Description*"
    When I enter or select "{CLICK}Computer Systems{ENTER}{TAB}" in "Description*"
    When I enter or select "{TAB}$500{TAB}" in "Deductible"
    When I enter or select "{TAB}100{TAB}" in "Coinsurance"
    When I enter or select "{TAB}5,000{TAB}" in "Property In Transit"
    When I enter or select "{TAB}No{TAB}" in "Unnamed Premises"
    When I enter or select "{TAB}No{TAB}" in "Personal Portable Computers"
    When I enter or select "{TAB}No{TAB}" in "Extra Expense"
    When I enter or select "{TAB}No{TAB}" in "Virus, Harmful Code Or Similar Instruction"
    When I click or select "OK"

    # Source step 0113: Navigate to Policy Covg Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Motor Truck Cargo | Source XTestStep: 3a13d49c-1679-2725-42a7-858d4d9ea9a7
    When I click or select "Policy Covg"

    # Source step 0114: Policy Covg - Main | Module: Policy Covg - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Motor Truck Cargo | Source XTestStep: 3a13d49c-1679-5dc1-67f1-b99318bba9cb
    Then I wait until "Policy Covg" exists
    When I enter or select "{TAB}{CLICK}Motor Truck Cargo{ENTER}{TAB}" in "Coverage Form To Be Added"
    When I click or select "Add Coverage Form"

    # Source step 0115: Policy Covg - Motor Truck Cargo | Module: Policy Covg - Motor Truck Cargo
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Motor Truck Cargo | Source XTestStep: 3a13d49c-1679-9275-f4dd-c2eb178f5303
    Then I wait until "Coverage Form Display" exists
    When I perform keyboard action "{TAB}" on "Description*"
    When I enter or select "{TAB}{CLICK}Motor truck Cargo{ENTER}{TAB}" in "Description*"
    When I enter or select "{TAB}Motor Truck Cargo Carriers{TAB}{TAB}" in "Coverage Type"
    When I enter or select "{TAB}Motor Trucks{TAB}" in "Covered Property Consisting Principally of:"
    When I enter or select "{TAB}$500{TAB}" in "Deductible"
    When I enter or select "{TAB}5,000{TAB}" in "Per Vehicle Limit"
    When I enter or select "{TAB}Class 1{TAB}" in "Group Class"
    When I enter or select "{TAB}25{TAB}" in "Number Of Vehicles"
    When I enter or select "{TAB}7500{TAB}" in "Unnamed Terminals Limit"
    When I click or select "OK"

    # Source step 0116: Navigate to Policy Covg Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Signs | Source XTestStep: 3a13d49c-1679-9fb1-9acd-2c9f67c7c847
    When I click or select "Policy Covg"

    # Source step 0117: Policy Covg - Main | Module: Policy Covg - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Signs | Source XTestStep: 3a13d49c-1679-28c9-003d-5db28552608b
    Then I wait until "Policy Covg" exists
    When I enter or select "{TAB}{CLICK}Signs{ENTER}{TAB}" in "Coverage Form To Be Added"
    When I click or select "Add Coverage Form"

    # Source step 0118: Policy Covg - Signs | Module: Policy Covg - Signs
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Policy Covg|Add Signs | Source XTestStep: 3a13d49c-1679-1419-663c-3d1e6d0dd757
    Then I wait until "Coverage Form Display" exists
    When I perform keyboard action "{TAB}" on "Description*"
    When I enter or select "{TAB}{CLICK}Signs{ENTER}{TAB}" in "Description*"
    Then "Coverage Form" should exist
    When I enter or select "{TAB}No{TAB}" in "5% Deductible"
    When I click or select "OK"

    # Source step 0119: Wait for prior screen to update | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Accounts Receivable | Source XTestStep: 3a13d49c-1679-1f70-94a5-957f173fcca0
    When I wait "750" milliseconds

    # Source step 0120: Navigate to Risk Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Accounts Receivable | Source XTestStep: 3a13d49c-1679-8af2-468d-d4a386b18b63
    When I click or select "Risk"

    # Source step 0121: Risk - Main | Module: Risk - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Accounts Receivable | Source XTestStep: 3a13d49c-1679-d52d-dfbe-7f2b9f7f2e03
    Then I wait until "Risk" exists
    When I enter or select "{TAB}{CLICK}Accounts Receivable - ACCOUNTS RECEIVABLE{TAB}" in "Coverage Form"
    When I click or select "Add"

    # Source step 0122: Risk - Accounts Receivable | Module: Risk - Accounts Receivable
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Accounts Receivable | Source XTestStep: 3a13d49c-1679-0704-8387-914dd994f8d4
    Then I wait until "Accounts Receivable Heading" exists
    When I perform keyboard action "{TAB}" on "Search Value"
    When I enter or select "{TAB}{CLICK}A{TAB}" in "Search Value"
    When I enter or select "{TAB}{CLICK}[6009] ABRASIVE WHEEL MFG.{ENTER}{TAB}" in "Search Result"
    When I enter or select "{TAB}{CLICK}Frame{TAB}" in "Construction"
    When I enter or select "{TAB}{CLICK}Main{TAB}" in "Premises Type"
    When I enter or select "{TAB}{CLICK}50{TAB}" in "% Duplicated Records"
    When I enter or select "{TAB}{CLICK}50{TAB}" in "Classification of Risk %"
    When I click or select "OK"

    # Source step 0123: Navigate to Risk Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Bailees Customers | Source XTestStep: 3a13d49c-1679-f3c0-ebc2-30a93be12514
    When I click or select "Risk"

    # Source step 0124: Risk - Main | Module: Risk - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Bailees Customers | Source XTestStep: 3a13d49c-1679-e276-1d55-1d4fdf9305e2
    Then I wait until "Risk" exists
    When I enter or select "{TAB}{CLICK}Bailees Customers - BAILEES CUSTOMERS{TAB}" in "Coverage Form"
    When I click or select "Add"

    # Source step 0125: Risk - Bailees Customers | Module: Risk - Bailees Customers
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Bailees Customers | Source XTestStep: 3a13d49c-1679-a8ca-db42-95fe00a5e8b2
    Then I wait until "Bailees Customers Heading" exists
    When I enter or select "{TAB}{CLICK}$500{TAB}" in "Deductible"
    When I perform keyboard action "{TAB}" on "Search Value"
    When I enter or select "{CLICK}B{TAB}{TAB}" in "Search Value"
    When I enter or select "{TAB}{CLICK}[6009] Brick Mfg.{ENTER}{TAB}" in "Search Result"
    When I enter or select "{TAB}{CLICK}Frame{TAB}" in "Construction"
    When I enter or select "{TAB}{CLICK}100000{TAB}" in "Annual Gross Receipts"
    When I enter or select "{TAB}{CLICK}15{TAB}" in "Average Number Of Days Service"
    When I enter or select "{TAB}{CLICK}300{TAB}" in "Average Number Of Working Days"
    When I enter or select "{TAB}{CLICK}30{TAB}" in "Average Service Charge"
    When I enter or select "{TAB}{CLICK}75{TAB}" in "Average Value Per Order"
    When I enter or select "{TAB}{CLICK}800{TAB}" in "Limit"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "Earthquake"
    When I enter or select "{TAB}{CLICK}100{TAB}" in "Storage Limit"
    When I click or select "OK"

    # Source step 0126: Navigate to Risk Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Computer Systems | Source XTestStep: 3a13d49c-1679-7e36-a674-d13bb81ba1eb
    When I click or select "Risk"

    # Source step 0127: Risk - Main | Module: Risk - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Computer Systems | Source XTestStep: 3a13d49c-1679-13c4-60b9-964b9a044403
    Then I wait until "Risk" exists
    When I enter or select "{TAB}{CLICK}Computer Systems - COMPUTER SYSTEMS{TAB}" in "Coverage Form"
    When I click or select "Add"

    # Source step 0128: Risk - Computer Equipment | Module: Risk - Computer Systems
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Computer Systems | Source XTestStep: 3a13d49c-1679-b4a0-d69e-ed1dc507c899
    When I enter or select "{TAB}{CLICK}25000{TAB}" in "Computer Equipment"
    When I enter or select "{TAB}{CLICK}5000{TAB}" in "Data And Media"
    When I perform keyboard action "{TAB}" on "Search Value"
    When I enter or select "{CLICK}H{TAB}{TAB}" in "Search Value"
    When I enter or select "{TAB}{Click}[2300] Honey Extracting{ENTER}{TAB}{TAB}{TAB}" in "Search Result"
    When I enter or select "{TAB}{CLICK}Frame{TAB}" in "Construction Code"
    When I click or select "OK"

    # Source step 0129: Navigate to Risk Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Signs | Source XTestStep: 3a13d49c-1679-598e-6924-0befbbdce7b3
    When I click or select "Risk"

    # Source step 0130: Risk - Main | Module: Risk - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Signs | Source XTestStep: 3a13d49c-1679-d1fc-d034-e848a88dab92
    Then I wait until "Risk" exists
    When I enter or select "{TAB}{CLICK}Signs - SIGNS{TAB}" in "Coverage Form"
    When I click or select "Add"

    # Source step 0131: Risk - Signs | Module: Risk - Signs
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Add Signs | Source XTestStep: 3a13d49c-1679-2d47-3155-f09890b82c53
    Then I wait until "Signs Heading" exists
    When I enter or select "{TAB}{CLICK}50000{TAB}" in "Limit of Insurance"
    When I enter or select "{TAB}{CLICK}Outside{TAB}" in "Sign Location"
    When I enter or select "{TAB}{CLICK}Signs{TAB}" in "Type"
    When I enter or select "{TAB}{CLICK}ABC{TAB}" in "Lettering"
    When I click or select "OK"

    # Source step 0132: Navigate to Endorsement Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Endorsement|Add CM 66 01 Exclude Named Customer | Source XTestStep: 3a13d49c-1679-0ec0-43d7-a989721ff4c1
    When I click or select "Endorsement"

    # Source step 0133: Endorsement - Main | Module: Endorsement - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Endorsement|Add CM 66 01 Exclude Named Customer | Source XTestStep: 3a13d49c-1679-3596-d908-6882f8dfe9ca
    Then I wait until " Endorsement Heading" exists
    When I click or select "Add Endorsement"
    When I enter or select "{CLICK}CM 66 01 Exclude Named Customer{TAB}" in "Type"

    # Source step 0134: Endorsement - CM 66 01 Exclude Named Customer | Module: Endorsement - CM 66 01 Exclude Named Customer
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Endorsement|Add CM 66 01 Exclude Named Customer | Source XTestStep: 3a13d49c-1679-9391-352a-ea8f53a4e092
    When I perform keyboard action "{TAB}" on "Names"
    When I enter or select "{CLICK}Jim Bob{TAB}" in "Names"
    When I perform keyboard action "{TAB}" on "Address"
    When I enter or select "{CLICK}9 Center Road, Mahopac, NY 10541{TAB}" in "Address"
    When I click or select "OK"

    # Source step 0135: Navigate to Endorsement Screen | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Endorsement|Add IF 00 02 Waterborne Equipment | Source XTestStep: 3a13d49c-1679-f074-e135-f108cd524991
    When I click or select "Endorsement"

    # Source step 0136: Endorsement - Main | Module: Endorsement - Main
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Endorsement|Add IF 00 02 Waterborne Equipment | Source XTestStep: 3a13d49c-1679-b3a0-4f90-dc2bbb45bad4
    Then I wait until " Endorsement Heading" exists
    When I click or select "Add Endorsement"
    When I enter or select "{TAB}IF 00 02 Waterborne Equipment{TAB}" in "Type"

    # Source step 0137: Endorsement - IF 00 02 Waterborne Equipment | Module: Endorsement - IF 00 02 Waterborne Equipment
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Endorsement|Add IF 00 02 Waterborne Equipment | Source XTestStep: 3a13d49c-1679-884c-9774-06ad969fadc6
    When I enter or select "50,000{TAB}" in "Limit"
    When I enter or select "250{TAB}" in "Deductible"
    When I click or select "OK"

    # Source step 0138: Navigate to Specific Underwriting Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Accounts Receivable Questions | Source XTestStep: 3a13d49c-1679-4632-b3a3-7c275da264d8
    When I click or select "Specific Underwriting Questions"

    # Source step 0139: Navigate to Accounts Receivable UW Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Accounts Receivable Questions | Source XTestStep: 3a13d49c-1679-7880-21d5-50c32b7a11df
    When I click or select "Accounts Receivable UW Questions"

    # Source step 0140: Specific Underwriting Questions - Accounts Receivable | Module: Specific Underwriting Questions - Accounts Receivable
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Accounts Receivable Questions | Source XTestStep: 3a13d49c-1679-55b9-8e82-70bb840e0d16
    Then I wait until "Accounts Receivable Heading" exists
    When I click or select "Update Answers"
    When I enter or select "{TAB}{CLICK}Test{TAB}" in "What is the construction of the premises where the receivables are stored?"
    When I perform keyboard action "{TAB}" on "What safeguards are in place for receivables to protect against damage or theft?"
    When I enter or select "{TAB}{CLICK}Test{TAB}" in "What safeguards are in place for receivables to protect against damage or theft?"
    When I click or select "OK"

    # Source step 0141: Navigate to Specific Underwriting Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Bailees Customers Questions | Source XTestStep: 3a13d49c-1679-679b-71cc-e31018d745e8
    When I click or select "Specific Underwriting Questions"

    # Source step 0142: Navigate to Bailees Customers UW Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Bailees Customers Questions | Source XTestStep: 3a13d49c-1679-510a-35c2-55f1074c8a96
    When I click or select "Bailees Customer UW Questions"

    # Source step 0143: Specific Underwriting Questions - Bailees Customer | Module: Specific Underwriting Questions - Bailees Customer
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Bailees Customers Questions | Source XTestStep: 3a13d49c-1679-92ac-3853-ef39ef4d52af
    Then I wait until "Bailees Customer Heading" exists
    When I enter or select "{TAB}{CLICK}50{TAB}" in "Dry Cleaning %"
    When I enter or select "{TAB}{CLICK}50{TAB}" in "Laundry %"
    When I enter or select "{TAB}{CLICK}2{TAB}" in "2. Indicate the age, type of construction and protection class of the premises."
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}25%{TAB}" in "3. What is the percentage of annual gross receipts derived from service or repair?"
    When I enter or select "{TAB}{CLICK}Every Month{TAB}" in "4. What method do you use for keeping records of property in your care and how often are the records updated?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "5. Are recognized approved central station burglar alarms installed and maintained?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "6. Are all storage areas locked at all times when unoccupied?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "7. Are there any hazardous or flammable materials used or stored on the premises?"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}20{TAB}" in "a. What is the public Protection class rating?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "b. Are there any private protection improvements?"
    When I enter or select "{TAB}{CLICK}65{TAB}" in "c. What is the distance in feet to the nearest hydrant?"
    When I enter or select "{TAB}{CLICK}5{TAB}" in "d. What is the distance in miles to the nearest responding fire department?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "e. Are no smoking rules posted and enforced?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "9. Are the premises or any portion of the premises equipped with a sprinkler system?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "10. Are the premises equipped with a recognized approved central station fire alarm, fire extinguishers or smoke alarms?"
    When I enter or select "{TAB}{CLICK}Trucks{TAB}" in "11. What is the procedure for transporting property? Include the transit methods used and the protection class provided while in transit."
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "12. Are drivers’ MVRs reviewed on a regular basis and maintained?"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}Fords{TAB}" in "13. What types of vehicles do you operate and what protective devices are on each vehicle?"
    When I enter or select "{TAB}{CLICK}Foam Peanuts{TAB}" in "14. What is your procedure for protecting small items from breakage or disappearance while in storage?"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}We are very Careful{TAB}" in "15. What measures does the insured take to protect customer’s property against theft?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "16. Does the risk use release forms?"
    When I click or select "OK"

    # Source step 0144: Navigate to Specific Underwriting Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Computer Systems Questions | Source XTestStep: 3a13d49c-1679-eeb0-fba0-771c028784cb
    When I click or select "Specific Underwriting Questions"

    # Source step 0145: Navigate to Computer Systems UW Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Computer Systems Questions | Source XTestStep: 3a13d49c-1679-4f31-0712-e8f5fd14cf8d
    When I click or select "Computer Systems UW Questions"

    # Source step 0146: Specific Underwriting Questions - Computer Systems | Module: Specific Underwriting Questions - Computer Systems
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Computer Systems Questions | Source XTestStep: 3a13d49c-1679-6511-0577-f08f4ee62439
    When I enter or select "{TAB}{Click}" in "Update Answers"
    When I enter or select "{TAB}{CLICK}Bubble Wrap{TAB}" in "What is the procedure for transporting the computer equipment?"
    When I enter or select "{TAB}{CLICK}56{TAB}" in "Indicate the building(s) age, type of construction, and protection class, and other tenants in the building(s) where the computer equipment is located"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}Locks{TAB}" in "What are the procedures and methods for keeping the EDP areas secured?"
    When I enter or select "{TAB}{CLICK}Thumb Drives{TAB}" in "What are the procedures and schedule for backing up the media and data and their storage?"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}Backups{TAB}" in "Provide information regarding antivirus methods and copyright protection of data and media"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}{CLICK}10{TAB}" in "What is the public protection class rating?*"
    When I enter or select "{TAB}{CLICK}{CLICK}55{TAB}" in "What is the distance in feet to the nearest fire hydrant?"
    When I enter or select "{TAB}{CLICK}{CLICK}3{TAB}" in "What is the distance in miles to the nearest responding fire department?*"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Uninterruptible power source?*"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Line conditioner?*"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Power suppressor voltage regulator?*"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Dedicated line?*"
    When I enter or select "{TAB}{CLICK}once a day{TAB}" in "How often is data backed up?"
    When I click or select "OK"

    # Source step 0147: Navigate to Specific Underwriting Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Contractors Equipment Questions | Source XTestStep: 3a13d49c-1679-d619-e3b6-f4ad99c29607
    When I click or select "Specific Underwriting Questions"

    # Source step 0148: Navigate to Computer Systems UW Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Contractors Equipment Questions | Source XTestStep: 3a13d49c-1679-24f9-0dad-1c2f65d67fca
    When I click or select "Contractors Equipment UW Questions"

    # Source step 0149: Specific Underwriting Questions - Contractors Equipment | Module: Specific Underwriting Questions - Contractors Equipment
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Contractors Equipment Questions | Source XTestStep: 3a13d49c-1679-d8e9-0d7c-93a4ef878ecb
    Then I wait until "Contractors Equipment Heading" exists
    When I click or select "Update Answers"
    When I enter or select "{TAB}{CLICK}50000{TAB}" in "Estimated Highest Value"
    When I enter or select "{TAB}{CLICK}Heating system Flush{TAB}" in "If Yes, describe"
    When I click or select "OK"

    # Source step 0150: Navigate to Specific Underwriting Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Motor Truck Cargo Questions (Owner) | Source XTestStep: 3a13d49c-1679-d48b-6908-9cb5d08ee84f
    When I click or select "Specific Underwriting Questions"

    # Source step 0151: Navigate to Computer Systems UW Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Motor Truck Cargo Questions (Owner) | Source XTestStep: 3a13d49c-1679-05ac-c356-e6fc698ed6b2
    When I click or select "Motor Truck Cargo UW Questions"

    # Source step 0152: Specific Underwriting Questions - Motor Truck Cargo(Owners) | Module: Specific Underwriting Questions - Motor Truck Cargo(Owners)
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Motor Truck Cargo Questions (Owner) | Source XTestStep: 3a13d49c-1679-eb99-a72f-25abb2c0602a
    Then I wait until "Motor Truck Cargo Heading" exists
    When I enter or select "Owners (complete section II only){TAB}" in "Which form are you completing?"
    When I perform keyboard action "{TAB}" on "1. What are the distances the shipments will travel and the time required to complete the shipment?	"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}3 Days{TAB}" in "1. What are the distances the shipments will travel and the time required to complete the shipment?	"
    When I enter or select "{TAB}{CLICK}Ford 5 Years{TAB}" in "2. What are the types and ages of the vehicles/trailers used to transport your commodities?	"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "3. Does the applicant haul for others?"
    When I enter or select "{TAB}{CLICK}None{TAB}" in "4. What protective devices are installed on each vehicle or trailer?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "5. Do any vehicles have special equipment mounted or attached?"
    When I enter or select "{TAB}{CLICK}No{Tab}" in "6. Does the applicant pull double or triple trailers?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "7. Does the applicant leave the truck windows, doors and compartments closed and locked when unattended?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "8. Do you provide scheduled maintenance for the vehicles and trailers you operate?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "9. Are the employees that pack, load and unload trained in proper handling of the commodities?"
    When I enter or select "{TAB}{CLICK}Truck{TAB}" in "10. How are the goods being transported protected from damage and theft?"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "11. Are drivers’ MVRs and trip logs maintained?"
    When I enter or select "{TAB}{CLICK}Daily{TAB}" in "12. How often are these logs reviewed or updated?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "13. Live animal in transit coverage?"
    When I enter or select "{TAB}{CLICK}No{TAB}" in "14. Legal Liability coverage?"
    When I click or select "OK"

    # Source step 0153: Navigate to Specific Underwriting Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Signs Questions | Source XTestStep: 3a13d49c-1679-3ba0-b0e7-6f4979d485dc
    When I click or select "Specific Underwriting Questions"

    # Source step 0154: Navigate to Computer Systems UW Questions | Module: IM Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Signs Questions | Source XTestStep: 3a13d49c-1679-40c7-b4fb-59543817a2ba
    When I click or select "Signs UW Questions"

    # Source step 0155: Specific Underwriting Questions - Signs | Module: Specific Underwriting Questions - Signs
    # Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Specific Underwriting Questions|Complete Signs Questions | Source XTestStep: 3a13d49c-1679-a72b-aeb9-ae48fa9f452e
    Then I wait until "Signs Heading" exists
    When I enter or select "{TAB}No{TAB}" in "Are Any signs off premises or not attached to building?"
    When I enter or select "{TAB}No{TAB}" in "Does the applicant wish to cover any signs inside their premises?"
    When I enter or select "{TAB}Metal{TAB}" in "What is the construction of each sign?"
    When I click or select "OK"

    # Source step 0182: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0183: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0184: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0185: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0186: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0187: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0188: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0189: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0190: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0191: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0192: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0193: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0194: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0195: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0196: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0197: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0198: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0199: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0200: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0201: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0202: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0203: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0247: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0248: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0249: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0250: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0251: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0252: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0256: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0257: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0258: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0259: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0260: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0261: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0262: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0263: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0307: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0308: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0309: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0310: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0311: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0312: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0313: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0314: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0338: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "2,423.00" as runtime value "NBPrem"

    # Source step 0339: Verify Premiums | Module: Submission|Premiums
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "$2,423.00"
    Then "Premium Written" property "value" should equals "2,423.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "2,423.00"

    # Source step 0340: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0341: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0342: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0343: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0344: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0345: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0346: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\IM_BASIC_AZ_{B[QuoteID]}.xml"

    # Source step 0352: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0353: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\\" -FileName \"IM_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0354: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0355: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0356: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0358: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0359: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0360: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0361: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0362: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0086: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0087: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0095: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:56 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-d800-16b1-204343afb7e1
#    - INPUT "Duration" with "1500"
# Source step 0096: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 14.04.20 08:18:24 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-06ca-978e-d5200f0622bb
#    - WAIT (Exists) "Insurance Score" with "False"
# Source step 0097: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:31 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3a41-fade-9ac567a11717
#    - INPUT "Duration" with "1500"
# Source step 0156: "Verify JavaScript Result" in module "Verify JavaScript Result" was disabled. Reason: 31.05.23 14:03:22 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-1679-8883-8082-fa16a03fdd50
#    - INPUT "Title" with "*"
#    - INPUT "JavaScript" with "return document.getElementById('_QuoteID').value"
#    - VERIFY "Result" with "{XB[QuoteID]}"
# Source step 0157: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-1add-e1db-90745bf0356c
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0158: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-8317-776e-ef2c241c7331
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "FFQA008"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0159: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-0945-2a6b-1ddb25b247f9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0160: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-521e-d1ce-f90ce5572a32
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0161: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-343f-2e25-5b26dcf95f0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0162: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-cbef-a087-f74870fbea22
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0163: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-a89a-695b-21bbda77c753
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0164: "Open broswer and navigate to DuckCreek" in module "OpenUrl_old" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-4c28-58d3-da2629623258
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
# Source step 0165: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-7825-6667-d3f2b79bb4bc
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0166: "Login" in module "Login" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-5bbe-067e-8bb0e6f0ffe8
#    - INPUT "UserName" with "FFQA008"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0167: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-9133-1f3b-a1c405cf786b
#    - WAIT (Exists) "Login" with "True"
# Source step 0168: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-51f6-5314-46dad22fc891
#    - INPUT "Loop Login" with "1"
# Source step 0169: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-ded3-221b-7443ee21926c
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0170: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 31.05.23 14:03:27 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-1679-d7c1-cc25-bd1214f1fdd3
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\"
# Source step 0171: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 31.05.23 14:03:32 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0172: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 31.05.23 14:03:32 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0173: "500ms Wait for Syncronization" in module "TBox Wait" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy | Source XTestStep: 3a13d49c-1679-8acd-687c-c1778fbe049b
#    - INPUT "Duration" with "500"
# Source step 0174: "Small static wait for syncronization" in module "TBox Wait" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy | Source XTestStep: 3a13d49c-1679-aeab-61a5-1987ee849ffb
#    - INPUT "Duration" with "1000"
# Source step 0175: "Dashboard|QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy | Source XTestStep: 3a13d49c-1679-b63a-dffe-5a257c3075b7
#    - INPUT "Search Mode" with "{TAB}Description{TAB}"
#    - INPUT "Search Text" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Policy Number>{TAB})"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0176: "Check for Loading Indicator" in module "Indicators and Errors" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - VERIFY (Visible) "Loading Message" with "True"
# Source step 0177: "Wait 2 secs" in module "TBox Wait" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - INPUT "Duration" with "2000"
# Source step 0178: "Wait for results" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy | Source XTestStep: 3a13d49c-1679-126a-b9cc-382f97d6bbe4
#    - INPUT "Specific Policies and Quotes" with "a blank/null value"
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{ENTER}{TAB}"
#    - INPUT "Search Button" with "x"
#    - WAIT (Visible) "1 results found. Currently showing 1 - 1." with "True"
# Source step 0179: "Click View Policy, and wait for navigation away from screen" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy | Source XTestStep: 3a13d49c-1679-97c6-f315-3ca39a489d6c
#    - WAIT (Visible) "View Policy" with "True"
#    - INPUT "View Policy" with "X"
#    - WAIT (Exists) "View Policy" with "False"
# Source step 0180: "Check for Loading Indicator" in module "Indicators and Errors" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - VERIFY (Visible) "Loading Message" with "True"
# Source step 0181: "Wait 2 secs" in module "TBox Wait" was disabled. Reason: 05.04.22 12:09:15 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Dashboard|Perform Quick Search and Open Policy > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - INPUT "Duration" with "2000"
# Source step 0204: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0205: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0206: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0207: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0208: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0209: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0210: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0211: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0212: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0213: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0214: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0215: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0216: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0217: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0218: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0219: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0220: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0221: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0222: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0223: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0224: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0225: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0226: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0227: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0228: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0229: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0230: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0231: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0232: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0233: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0234: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0235: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0236: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0237: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0238: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0239: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0240: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0241: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0242: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0243: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0244: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0245: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0246: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0264: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0265: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0266: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0267: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0268: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0269: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0270: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0271: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0272: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0273: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0274: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0275: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0276: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0277: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0278: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0279: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0280: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0281: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0282: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0283: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0284: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0285: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0286: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0287: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0288: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0289: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0290: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0291: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0292: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0293: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0294: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0295: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\"
# Source step 0296: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0297: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0298: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0299: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0300: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0301: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0302: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0303: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0304: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0305: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0306: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0315: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0316: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0317: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0318: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0319: "Submission|Complete Application & Stoplight Functionality" in module "Submission|Complete Application & Stoplight Functionality" was disabled. Reason: 04.10.23 08:34:18 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-c0e3-6fe2-60d35b35503c
#    - INPUT "Complete Application" with "x"
# Source step 0320: "Navigate to Risk Screen" in module "IM Navigation Links" was disabled. Reason: 31.05.23 15:26:53 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Rate for Accounts Receivable | Source XTestStep: 3a13d49c-1679-bae3-30ea-baafeb966efb
#    - INPUT "Risk" with "x"
# Source step 0321: "Risk - Complete StopLight Fields" in module "Risk - Complete StopLight Fields" was disabled. Reason: 31.05.23 15:26:53 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Rate for Accounts Receivable | Source XTestStep: 3a13d49c-1679-2eb9-e298-5b5608b1c4bb
#    - INPUT "Accounts Receivable Detail" with "{Click}"
# Source step 0322: "Risk - Accounts Receivable" in module "Risk - Accounts Receivable" was disabled. Reason: 31.05.23 15:26:53 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Rate for Accounts Receivable | Source XTestStep: 3a13d49c-1679-1f1c-c261-b3feb93db2e4
#    - INPUT "BGI Rate" with "{TAB}1.000{TAB}"
#    - INPUT "OK" with "X"
# Source step 0323: "Navigate to Risk Screen" in module "IM Navigation Links" was disabled. Reason: 31.05.23 15:26:58 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Loss Cost for Bailees Customers | Source XTestStep: 3a13d49c-1679-2e41-bfba-576504517ea8
#    - INPUT "Risk" with "x"
# Source step 0324: "Risk - Complete StopLight Fields" in module "Risk - Complete StopLight Fields" was disabled. Reason: 31.05.23 15:26:58 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Loss Cost for Bailees Customers | Source XTestStep: 3a13d49c-1679-52b4-19e5-3e26208fb498
#    - INPUT "Bailees Customers Detail" with "{Click}"
# Source step 0325: "Risk - Bailees Customers" in module "Risk - Bailees Customers" was disabled. Reason: 31.05.23 15:26:58 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Loss Cost for Bailees Customers | Source XTestStep: 3a13d49c-1679-c8fc-ecc9-4f62b20fa379
#    - INPUT "BGI I Loss Cost" with "{TAB}1.000{TAB}"
#    - INPUT "OK" with "X"
# Source step 0326: "Navigate to Risk Screen" in module "IM Navigation Links" was disabled. Reason: 31.05.23 15:27:06 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Loss Cost for Computer Systems | Source XTestStep: 3a13d49c-1679-fc28-f74c-a9adf51d6b44
#    - INPUT "Risk" with "x"
# Source step 0327: "Risk - Complete StopLight Fields" in module "Risk - Complete StopLight Fields" was disabled. Reason: 31.05.23 15:27:06 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Loss Cost for Computer Systems | Source XTestStep: 3a13d49c-1679-87dd-e8ea-fc9d310ee876
#    - INPUT "Computer Systems Detail" with "{Click}"
# Source step 0328: "Risk - Computer Systems" in module "Risk - Computer Systems" was disabled. Reason: 31.05.23 15:27:06 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: IM|Basic|Risk|Go back and Fill in BGI Loss Cost for Computer Systems | Source XTestStep: 3a13d49c-1679-f0fa-4688-a295ec279b16
#    - INPUT "BG 1 Loss Cost" with "{TAB}1.000{TAB}"
#    - INPUT "OK" with "X"
# Source step 0329: "Submission, select Policy Forms" in module "Submission, select Policy Forms" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-b954-0a7c-e98a92e77430
#    - INPUT "Policy Forms" with "x"
#    - WAIT (Exists) "Search" with "True"
#    - INPUT "Search for DEC Page" with "Declaration"
#    - INPUT "Search Button for DEC Page" with "x"
#    - INPUT "DEC LINK" with "x"
# Source step 0330: "Wait for Policy Forms to open" in module "TBox Wait" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8889-6242-e08fb28d4f40
#    - INPUT "Duration" with "9000"
# Source step 0331: "Close Policy Forms" in module "TBox Send Keys" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-582d-aae0-ba158c28662e
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0332: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-9a96-581e-d2b119b0020a
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0333: "Return to Submission Page" in module "Common Navigation Links" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8902-2720-581821968d05
#    - INPUT "Return to Policy" with "x"
# Source step 0334: "Submission, select Policy Admin Forms" in module "Submission, select Policy Forms" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-dcfb-265b-775fb7492386
#    - WAIT (Visible) "Policy Admin Forms" with "True"
#    - INPUT "Policy Admin Forms" with "x"
# Source step 0335: "Wait for Policy Admin Forms to open" in module "TBox Wait" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-5130-737f-d02663cba9f8
#    - INPUT "Duration" with "15000"
# Source step 0336: "Close Policy Admin Forms" in module "TBox Send Keys" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-c820-c654-7878ba2a4c1c
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0337: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 31.05.23 14:14:03 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-a6a9-8ecd-59b80f1bea38
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0347: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0348: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0349: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0350: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\IM_BASIC_AZ_{B[QuoteID]}.xml"
# Source step 0351: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\IM_BASIC_AZ_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0357: "Submission|Complete Application & Stoplight Functionality" in module "Submission|Complete Application & Stoplight Functionality" was disabled. Reason: 06.04.23 09:21:47 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: <none> | Source XTestStep: 3a13d49c-14c6-cc92-995a-e32301170bb0
#    - No granular TestStepValues were exported for this disabled step.
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  InlandMarine  Pages   US   (4.0.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Source step 0079: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Source step 0081: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP"
# Active source step 0083 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0122 "Risk - Accounts Receivable" contains conditionally inapplicable field action(s):
#    - INPUT "BGI Rate" with "{TAB}{CLICK}.001{TAB}" when 'Product' == "CPP" && 'State' == "WA". Reason: Value condition evaluated false for the selected iteration: 'Product' == "CPP" && 'State' == "WA"
# Active source step 0125 "Risk - Bailees Customers" contains conditionally inapplicable field action(s):
#    - INPUT "BGI I Loss Cost" with "{TAB}{CLICK}.001{TAB}" when 'Product' == "CPP" && 'State' == "WA". Reason: Value condition evaluated false for the selected iteration: 'Product' == "CPP" && 'State' == "WA"
# Active source step 0128 "Risk - Computer Equipment" contains conditionally inapplicable field action(s):
#    - INPUT "BG 1 Loss Cost" with "{TAB}{CLICK}.001{TAB}" when 'Product' == "CPP" && 'State' == "WA". Reason: Value condition evaluated false for the selected iteration: 'Product' == "CPP" && 'State' == "WA"
# Source step 0253: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0254: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0255: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14b7-cb05-f487-2befea3c8a03
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\IM\\IM BASIC TestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14b7-c392-9dfa-ff6db73ec358
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\IM\\IM BASIC TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14b7-7313-7ac7-5cbc33cefe12
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\IM\\IM BASIC TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-867b-0f3a-cc340a086145
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-9244-b8c2-9dcbfa60ed1b
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-2f7a-00ba-d7fe09a5f4aa
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-4e15-d707-6eb729ea585b
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-5319-5088-5643e5b60a1e
#    - I run "taskkill /f /im msEdge.exe"
