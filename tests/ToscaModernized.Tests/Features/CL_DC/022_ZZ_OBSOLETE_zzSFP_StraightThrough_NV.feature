# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 022_ZZ_OBSOLETE_zzSFP_StraightThrough_NV.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @SFP @straight_through @Nevada @Edge @manual @obsolete @archive @automated
Feature: Execute zzSFP | StraightThrough for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the zzSFP | StraightThrough workflow for Nevada (NV)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: zzSFP | StraightThrough using representative iteration Nevada (NV)

    # Source step 0038: Deselect Quick Quote | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-baea-fc85-843e0b462e26
    Then I wait until "Quick Quote" exists
    When I enter or select "False" in "Quick Quote"

    # Source step 0039: Wait for Non-Quick Quote Element to Appear | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-ac73-2258-77271da65807
    Then I wait until "Underwriting Info" exists

    # Source step 0040: Select Business Insured | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-ba4e-70ab-2fddc1e53a30
    When I enter or select "Business{ENTER}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0041: Enter Business Name | Module: Client|Named Insured|Business
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-afee-adb2-16b93c762899
    Then I wait until "Business Name" is visible
    When I enter or select "NV SFP StraightThrough, Inc.{TAB}" in "Business Name"

    # Source step 0042: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-e0be-7cfd-4133e268b3f9
    When I enter or select "Corporation{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I perform keyboard action "{TAB}" on "Address1"
    When I enter or select "{TAB}89101{TAB}" in "ZipCode"
    When I enter or select "340 North 11th St{TAB}" in "Address1"

    # Source step 0043: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-83a0-cae3-d02d409f7316
    # Runtime control: If Years in Business Exists > Check Years in Business
    Then "Years In Business" should exist

    # Source step 0044: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-5638-4d11-366b2d2dda1c
    # Runtime control: If Years in Business Exists > Then Input Years
    When I enter or select "6{TAB}" in "Years In Business"

    # Source step 0045: Enter FEIN | Module: Client|Named Insured|Business
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-c5e9-eccd-b3778fc99bfd
    When I enter a RANDOM value matching "6 random digits/characters from source expression 486{RND[6]}{TAB}" in "FEIN"

    # Source step 0046: Enter Details in Other Information Section | Module: Client|Other Insured Info
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-0b67-ea05-a131fa3c03bf
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}Auditor Doe{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0047: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-8298-54db-43889fb5edce
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0048: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Common|Client|Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-996b-f29f-d2de8058d631
    When I retain hard-coded value "NV" as runtime value "State"
    When I retain hard-coded value "SFP" as runtime value "Product (LOB)"
    When I retain hard-coded value "SFP_StraightThrough" as runtime value "FormOnPolicyDocName"
    When I retain hard-coded value "svdw-clas03:8080" as runtime value "Server"

    # Source step 0049: Add a new Associated Client - Business Owner Type - Click Add Client | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-1939-7fc0-ca593065c271
    # Source template XTestStep: 3a13d49c-165b-ce02-83cf-cd6904f97e54
    Then I wait until "Add Client" exists
    When I click or select "Add Client"

    # Source step 0050: Check if IndividualType Exists | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-8df2-93c6-53e75d4fc26a
    # Source template XTestStep: 3a13d49c-165b-d0b1-7d57-b7cecf62671b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Condition
    Then "IndividualType" should not exist

    # Source step 0051: AJAX Error Check | Module: AJAX Error
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-90d4-c7c4-34e4afe4471a
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Check for AJAX Error
    Then "AJAX Error Check" should exist

    # Source step 0052: Set buffer for Error | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-742f-be97-b5b259ccf349
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I derive and retain the RUNTIME-DERIVED buffer expression "The scripts experienced an AJAX error with the following information: {B[AJAX]}" as runtime value "AJAX Error"

    # Source step 0053: Force a fail | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-fc4f-89ec-af2ceb5f1e02
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    Then I evaluate the source-defined expression for "Force a fail" using "Expression='FALSE' == 'TRUE'"

    # Source step 0054: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I click or select "Billing"

    # Source step 0055: Fill Out Required Fields on Billing Screen | Module: Billing
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-315a-3b12-4a479c858c7a
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

    # Source step 0056: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I wait "3000" milliseconds

    # Source step 0057: Complete the Associated Client Info | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-620d-1349-79ff612812e4
    # Source template XTestStep: 3a13d49c-165b-71c5-b893-c4235f3b547a
    When I enter or select "{TAB}{CLICK}Business Owner{TAB}" in "IndividualType"

    # Source step 0058: Enter Client Details | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-625d-a499-6b04e28b7079
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

    # Source step 0059: Verify no results returned and click OK | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-dd90-a690-1dab649c4943
    # Source template XTestStep: 3a13d49c-165b-32d5-f6ed-f265f9f9c6c8
    Then "Search Results > Duck Creek Policy > First Checkbox" should not exist
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0060: Order and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-b7b3-69cd-da2af8738cc2
    # Source template XTestStep: 3a13d49c-165b-2f1c-c197-ca3b93b64298
    When I click or select "Order SSN"
    When I perform keyboard action "{TAB}" on "Enter SSN*"
    When I enter or select "{TAB}736849971{TAB}" in "Enter SSN*"
    When I click or select "Enter SSN*"

    # Source step 0061: Does Verify Exist | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-ff6a-05f8-9878a3fc49bb
    # Source template XTestStep: 3a13d49c-165b-ba0f-6727-be7d60a0ce09
    # Runtime control: If Verify does not exist > Condition
    Then "Verify" should not exist

    # Source step 0062: Click Complete | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-0a7b-1759-db79b945d0e4
    # Source template XTestStep: 3a13d49c-165b-95b2-6c84-0c54eb4a6437
    # Runtime control: If Verify does not exist > Then
    When I click or select "Complete"

    # Source step 0063: Click Detail and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-c001-48a0-2538623260d1
    # Source template XTestStep: 3a13d49c-165b-6230-e27e-9c3d0e9cbe27
    # Runtime control: If Verify does not exist > Then
    When I click or select "Detail"
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0064: Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-2acd-ad18-2667544acadc
    # Source template XTestStep: 3a13d49c-165b-de87-4c4c-3c66d28b8da1
    # Runtime control: If Verify does not exist > Else
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0065: Perform Final Client Search | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-d156-3898-3ea50a82a5d6
    # Source template XTestStep: 3a13d49c-165b-f6d6-53ae-4d4d2d531699
    Then I wait until "Client Search" exists
    When I click or select "Client Search"

    # Source step 0066: Click Ok | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Client|Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-2566-f8a3-04557379fdbf
    # Source template XTestStep: 3a13d49c-165b-647c-ba91-85bcca049803
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"
    Then I wait until "Client Search" no longer exists

    # Source step 0067: Navigate to Underwriting Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-2cb0-f665-b1d5a70d21b9
    # Source template XTestStep: 3a13d49c-165b-9ab4-0c96-7dae4d962d1c
    When I click or select "Underwriting Info"

    # Source step 0068: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-d67d-9bb5-a534a2c8485f
    # Source template XTestStep: 3a13d49c-165b-9c6a-a918-259d7e8d9ba3
    Then I wait until "Is there a Prior Carrier?*" exists
    When I enter or select "Yes{TAB}" in "Is there a Prior Carrier?*"
    Then I wait until "Carrier" exists
    When I enter or select "{TAB}Insure Us, Inc{TAB}" in "Carrier"
    When I enter or select "P-0123456789{TAB}" in "Policy Number"
    When I enter or select "Commercial Package{TAB}" in "Policy Type"
    When I enter RUNTIME-DERIVED value "{DATE[][-2y][MM'/'dd'/'yyyy]}{TAB}" in "Effective Date"
    When I enter RUNTIME-DERIVED value "{DATE[][][MM'/'dd'/'yyyy]}{TAB}" in "Expiration Date"
    When I enter or select "1.1{TAB}" in "ModificationFactor"
    When I enter or select "1,250{TAB}" in "Total Premium"
    When I click or select "OK"
    Then I wait until "Detail" exists

    # Source step 0069: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-f308-e77c-b3246bf3e731
    # Source template XTestStep: 3a13d49c-165b-7e70-d439-607c40156454
    When I click or select "Loss Experience"
    Then I wait until "No known losses" exists
    When I enter or select "True{TAB}" in "No known losses"

    # Source step 0070: Click Return to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14d5-6389-ba35-acda3ce4372f
    # Source template XTestStep: 3a13d49c-165b-b5c9-40b3-036c7fb8da80
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
    When I enter or select "09-01-2022{TAB}" in "EffectiveDate"

    # Source step 0076: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0077: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Nevada{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0078: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Nevada==\"Kansas\"; Expression= 'Nevada'=='Kansas'"

    # Source step 0080: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Nevada==\"Virginia\"; Expression= 'Nevada'=='Virginia'"

    # Source step 0082: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0083: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"SFP\"" is satisfied, I enter or select "Rabbits{TAB}" in "Farm Type*"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist
    When if field condition "'Product (LOB)' == \"SFP\"||'Product (LOB)' == \"GL OCP\"" is satisfied, I enter or select "6" in "Years In Business"

    # Source step 0084: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0085: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "NV SFP StraightThrough {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0099: Navigate to Location | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Location|Enter Location Details | Source XTestStep: 3a13d49c-166a-4f6e-450c-00c4b4015aa0
    When if field condition "Primary == \"Yes\"" is satisfied, I click or select "Location"

    # Source step 0100: Enter Location Details | Module: Location
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Location|Enter Location Details | Source XTestStep: 3a13d49c-166a-93c0-68f3-07c125299afa
    Then I wait until "Location" exists
    When if field condition "Primary == \"Yes\"" is satisfied, I click or select "Detail"
    Then I wait until "Location Detail" exists
    When I enter or select "340 North 11th St{TAB}" in "Address1"
    When I enter or select "89101{TAB}" in "ZipCode"
    When I enter or select "5{TAB}" in "MilesFromFireDepartment"
    When I enter or select "101-250{TAB}" in "FeetFromHydrant"
    When I enter or select "X{TAB}{TAB}" in "Call ISO"
    Then I wait until "Select PPC Table" exists
    When I click or select "Select PPC Table > $1 > $1"
    Then I wait until "Protection Class" property "InnerText" does not equal "Null"
    When I click or select "OK"
    Then I wait until "Cancel" no longer exists

    # Source step 0101: Navigate to Insurance Designee | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Insurance Designee| Navigate to Insurance Designee | Source XTestStep: 3a13d49c-166a-40ef-d553-43bb4b46e992
    When I click or select "Insurance Designee"

    # Source step 0102: Verify on Insurance Designee screen | Module: Insurance Designee
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Insurance Designee| Navigate to Insurance Designee | Source XTestStep: 3a13d49c-166a-aabb-82b9-73ced2ae8fbe
    Then I wait until "Insurance Designee" exists

    # Source step 0103: Input an Insurance Designee | Module: Insurance Designee
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Insurance Designee|Fill out required info | Source XTestStep: 3a13d49c-166a-5c96-ba57-f1c27dc86cbe
    Then I wait until "Insurance Designee" exists
    When I enter or select "Prescott{TAB}" in "Last Name"
    When I enter or select "Dak{TAB}" in "First Name"
    When I enter or select "{CLICK}4 Jersey Number{TAB}" in "Address"
    When I enter or select "07/29/1993{TAB}" in "Date Of Birth"
    When I enter or select "Dallas{TAB}" in "City"
    When I enter or select "Texas{TAB}" in "State"
    When I enter or select "55555{TAB}" in "Zip Code"
    When I enter or select "404040404{TAB}" in "SSN*"

    # Source step 0104: Run Insurance Score | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Insurance Designee|Fill out required info | Source XTestStep: 3a13d49c-166a-fba1-6f88-970becf7f312
    When I click or select "Insurance Score Consent"
    Then I wait until "IFRAME > Popup > Accept" exists
    When I click or select "IFRAME > Popup > Accept"
    Then I wait until "Insurance Score" exists
    When I click or select "Insurance Score"

    # Source step 0105: Insurance Score | Module: Policy Info|Insurance Score
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Insurance Designee|Fill out required info | Source XTestStep: 3a13d49c-166a-630d-6131-d5458e6bb1af
    # Runtime control: Wait for Insurance Score to Populate [max=40] > Condition
    Then "Reference Number" property "InnerText" should equals "\"\""

    # Source step 0106: Wait 1/2 Second for a max of 20 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: SFP|Insurance Designee|Fill out required info | Source XTestStep: 3a13d49c-166a-81a3-9740-8a4128547c69
    # Runtime control: Wait for Insurance Score to Populate [max=40] > Loop
    When I wait "500" milliseconds

    # Source step 0107: Navigate to 1 - Residence | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1| Navigate to 1 - Residence screen | Source XTestStep: 3a13d49c-166a-47e5-f5ff-09e72540ab2f
    When I click or select "1 - Residence"

    # Source step 0108: Wait for 1 - Residence screen to load | Module: Residence - Main Page
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1| Navigate to 1 - Residence screen | Source XTestStep: 3a13d49c-166a-370b-0c4e-82be0d18069e
    Then I wait until "1 - Residence" exists

    # Source step 0109: Residence - Main Page | Module: Residence - Main Page
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Add Residence Coverage | Source XTestStep: 3a13d49c-166a-b69d-1ce8-64a4553d52a0
    When I enter or select "Location #1{TAB}" in "Location:"
    Then "Location:" property "value" should equals "Location #1"
    When I click or select "Add Residence"

    # Source step 0110: Residence Detail | Module: Residence Detail
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Add Residence Coverage | Source XTestStep: 3a13d49c-166a-d92c-8949-8038c297b3e9
    When I enter or select "Frame{TAB}" in "Construction"
    When I enter or select "2{TAB}" in "RateType"
    When I enter or select "Owner{TAB}" in "Occupancy"
    When I enter or select "1{TAB}" in "Number of Families"
    When if field condition "Year == NULL" is satisfied, I enter RUNTIME-DERIVED value "{CALC[{LYEAR[{DATE[][-20y][MM-dd-yyyy]}]}]}{TAB}" in "Year New "
    When if field condition "Year != NULL" is satisfied, I leave "Year New " blank because the reusable parameter is not supplied for this iteration
    When I enter RUNTIME-DERIVED value "{CALC[{LYEAR[{DATE[][-15y][MM-dd-yyyy]}]}]}{TAB}" in "Year Renovated"
    When I enter RUNTIME-DERIVED value "{CALC[{LYEAR[{DATE[][-10y][MM-dd-yyyy]}]}]}{TAB}" in "RoofYear"
    When I enter or select "Asphalt{TAB}" in "Roof Type"
    When I enter or select "UL 2{TAB}" in "Roof Impact Resistance"
    When I enter or select "No{TAB}" in "Cosmetic Roof Exclusion"
    When I enter or select "1{TAB}" in "Protective Device Credit"
    When I enter or select "No{TAB}" in "Lightning Rod/Tie Down Credit"
    When I enter or select "No{TAB}" in "Non Smokers Credit"
    When I leave "Vacant/Seasonal" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "No{TAB}" in "Vacant/Unoccupied Buyback"
    When I enter or select "No{TAB}{TAB}" in "Solid Fuel Heat Device*"
    When I click or select "Solid Fuel Heat Device*"
    When I perform keyboard action "{TAB}" on "Solid Fuel Heat Device*"
    When I enter or select "No{TAB}" in "Ordinance or Law"
    When I enter or select "No{TAB}" in "Windstorm Protection"
    When I leave "MA Relocation # of Units" blank because the reusable parameter is not supplied for this iteration

    # Source step 0111: Select Add Coverage Information | Module: Residence Coverage Detail - Main
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Residence Coverage Detail-Main | Source XTestStep: 3a13d49c-166a-ac8d-d3b5-7fa02e03e127
    When I click or select "Add Coverage Information"
    Then I wait until "Residence Coverage Detail" exists

    # Source step 0112: Residence Coverage Detail - Add Residence Covg | Module: Residence Coverage Detail - Add Residence Covg
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Residence Coverage Detail - Add Residence Covg | Source XTestStep: 3a13d49c-166a-d3b4-fce1-586dbe0606e5
    # Step condition: 'Residence Coverage Type*' != NULL
    When I click or select "Add Residence Coverage"
    Then I wait until "Residence Coverage Type*" exists
    When I enter or select "Residence{TAB}" in "Residence Coverage Type*"
    When I enter or select "100000{TAB}" in "Residence Additional Limit*"
    When I enter or select "500{TAB}" in "Residence Deductible"
    When I enter or select "4{TAB}" in "Residence Peril Group*"
    When I enter or select "Replacement Cost{TAB}" in "Residence Replacement Cost"
    When I enter or select "0{TAB}" in "Residence Inflation Guard"

    # Source step 0113: SFP Residence Coverage Detail - RCT | Module: SFP Building Estimator
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP Estimator | Source XTestStep: 3a13d49c-166a-dc39-2823-e5b145db881c
    When I enter or select "3000{TAB}" in "Square Feet"
    When I enter or select "RCT{TAB}{TAB}" in "Estimator Type*"
    When if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I enter or select "Standard RCT - Use Defaults{TAB}" in "Valuation Type"
    When if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I click or select "Create Valuation"
    Then if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I wait until "ValuationID Exists" property "Value" does not equal "\"\""
    Then if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I wait until "Valuation ID Exists" property "InnerText" does not equal "\"\""
    When if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I click or select "Get Calculated Value"
    Then if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I wait until "Calculated Value Exists" property "InnerText" does not equal "\"\""

    # Source step 0114: Add Contents Coverage | Module: Residence Coverage Detail - Add Contents Coverage
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Residence Coverage Detail - Add Contents Coverage | Source XTestStep: 3a13d49c-166a-0d78-b3c1-f7bde93c051f
    # Step condition: Coverage != NULL
    When I click or select "Add Contents Coverage"
    When I click or select "Contents Coverage Type*"
    When I enter or select "Residence Contents{CLICK}{TAB}{TAB}" in "Contents Coverage Type*"
    When I enter or select "Residence Contents{TAB}{TAB}" in "Contents Coverage Type*"
    When I enter or select "100000{TAB}{TAB}" in "Contents Additional Limit*"
    Then I wait until "Contents Deductible" is visible
    When I enter or select "500{TAB}" in "Contents Deductible"
    When I enter or select "4{TAB}" in "Contents Peril Group*"
    When I enter or select "No{TAB}{TAB}" in "Contents Replacement Cost"
    When I enter or select "0{TAB}" in "Contents Inflation Guard"

    # Source step 0115: Add Contents Coverage | Module: Residence Coverage Detail - Add Contents Coverage
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Residence Coverage Detail - Add Contents Coverage | Source XTestStep: 3a13d49c-166a-70fd-8422-813e4335d8ed
    # Runtime control: If Ded does not match then re input > Condition
    # Step condition: Coverage != NULL
    Then "Contents Deductible" property "Text" should does not equal "500"

    # Source step 0116: Add Contents Coverage | Module: Residence Coverage Detail - Add Contents Coverage
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Residence Coverage Detail - Add Contents Coverage | Source XTestStep: 3a13d49c-166a-d76e-6167-ef61d7ffe2f9
    # Runtime control: If Ded does not match then re input > Then
    # Step condition: Coverage != NULL
    When I enter or select "500{TAB}" in "Contents Deductible"

    # Source step 0117: Add Residence Optional Coverages | Module: Residence Optional Coverages
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Residence Optional Coverages | Source XTestStep: 3a13d49c-166a-89ad-7ccf-f7bd12312c6a
    # Step condition: 'Coverage Type' != NULL
    When I click or select "Residence Optional Coverages"
    Then I wait until "Residence Optional Coverages - Header" exists
    When if field condition "'Coverage Type' != NULL" is satisfied, I enter or select "Excess Loss of Use{TAB}" in "CoverageType"
    When if field condition "'Coverage Type' != NULL" is satisfied, I click or select "Add Optional Coverage"
    When if field condition "'Coverage Type' == \"Excess Loss of Use\"" is satisfied, I enter or select "10000{TAB}" in "Excess Loss of Use - Additional Limit*"

    # Source step 0118: Click to Return | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Return to Residence screen from Coverage | Source XTestStep: 3a13d49c-166a-6f1a-a339-27c40bc79db5
    When I click or select "Return"

    # Source step 0119: Wait for 1 - Residence screen to load | Module: Residence - Main Page
    # Section: New Application - Data Entry Process > Division 1 | Reusable flow: SFP|Div 1|Return to Residence screen from Coverage | Source XTestStep: 3a13d49c-166a-156a-1793-75f0a506eff1
    Then I wait until "1 - Residence" exists

    # Source step 0120: Navigate to 2 - Building | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2| Navigate to 2 - Building Main | Source XTestStep: 3a13d49c-166a-7fb5-5266-f1e6452394d5
    When I click or select "2 - Building"

    # Source step 0121: Wait for 2 - Building Header | Module: Building - Main Page
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2| Navigate to 2 - Building Main | Source XTestStep: 3a13d49c-166a-aefa-b6fd-a37bcd03a572
    Then I wait until "2 - Building" exists

    # Source step 0122: Add a Building | Module: Building - Main Page
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Add a Building - Building Detail | Source XTestStep: 3a13d49c-166a-0092-1421-a532cbdd739f
    When I enter or select "Location #1{TAB}" in "Location:"
    Then "Location:" property "value" should equals "Location #1"
    When I click or select "Add Building"

    # Source step 0123: Add Building Detail | Module: Building Detail
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Add a Building - Building Detail | Source XTestStep: 3a13d49c-166a-bbc9-755b-8f129066a5c1
    Then I wait until "Building Detail" exists
    When I enter or select "Frame{TAB}" in "ConstructionCode"
    When I enter or select "2{TAB}" in "RateType"
    When I enter RUNTIME-DERIVED value "{CALC[{LYEAR[{DATE[][-5y][MM-dd-yyyy]}]}]}{TAB}" in "YearBuilt(Year New)"
    When I enter RUNTIME-DERIVED value "{CALC[{LYEAR[{DATE[][-3y][MM-dd-yyyy]}]}]}{TAB}" in "YearRenovated"
    When I enter or select "Asphalt{TAB}" in "RoofType"
    When I enter RUNTIME-DERIVED value "{CALC[{LYEAR[{DATE[][-1y][MM-dd-yyyy]}]}]}{TAB}" in "Roof Year"
    When I enter or select "(n/a){TAB}" in "Protective Device Credit"
    When I enter or select "No{TAB}" in "Lightning Rod/Tie Down Credit"
    When I enter or select "(n/a){TAB}" in "Vacant/Unoccupied"
    When I enter or select "No{TAB}" in "Vacant/Unoccupied Buyback"
    When I enter or select "No{TAB}" in "Windstorm Protection"
    When I enter or select "No{TAB}" in "Utility Value"
    When I enter or select "No{TAB}" in "Solid Fuel Heat Device*"
    When I enter or select "No{TAB}" in "Ordinance or Law"
    When I leave "Wind/Hail Exclusion" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "No{TAB}" in "Cosmetic Roof Exclusion"
    When I click or select "Add Coverage Information"

    # Source step 0124: Building/Contents Main | Module: Building/Contents Main
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents Main | Source XTestStep: 3a13d49c-166a-3b31-8d59-122c8608feb3
    When I click or select "Building/Contents"
    Then I wait until "Building/Contents Header" exists

    # Source step 0125: Building/Contents - Add Building Covg | Module: Building/Contents - Add Building Covg
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Building Coverage | Source XTestStep: 3a13d49c-166a-9783-e9a4-cbdf3d23ff7e
    # Step condition: 'Coverage Code' != NULL
    When I click or select "Add Building Coverage"
    Then I wait until "Coverage Code*" exists
    When I enter or select "Farm Buildings{TAB}" in "Coverage Code*"
    When I enter or select "100000{TAB}" in "Amount of Insurance*"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "4{TAB}" in "Peril Group*"
    When I enter or select "No{TAB}" in "Replacement Cost"
    When I enter or select "Farm Stand{TAB}" in "Description Code*"
    When I enter or select "SFP Building Test{TAB}" in "Description"

    # Source step 0128: SFP Residence Coverage Detail - RCT | Module: SFP Building Estimator
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP Estimator | Source XTestStep: 3a13d49c-166a-dc39-2823-e5b145db881c
    When I enter or select "3000{TAB}" in "Square Feet"
    When I enter or select "BVS{TAB}{TAB}" in "Estimator Type*"
    When if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I enter or select "Commercial Valuation{TAB}" in "Valuation Type"
    When if field condition "'SFP Estimator Type RCT/BVS' == \"BVS\"" is satisfied, I enter or select "2121 - Office, Low-Rise, Shell{TAB}" in "BVSSearchResult"
    When if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I click or select "Create Valuation"
    Then if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I wait until "ValuationID Exists" property "Value" does not equal "\"\""
    Then if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I wait until "Valuation ID Exists" property "InnerText" does not equal "\"\""
    When if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I click or select "Get Calculated Value"
    Then if field condition "'SFP Estimator Type RCT/BVS' != \"Other - Dealer Quote\"" is satisfied, I wait until "Calculated Value Exists" property "InnerText" does not equal "\"\""

    # Source step 0129: Building/Contents - Add Contents | Module: Building/Contents - Add Contents
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-2c57-2aab-11074cd49e39
    # Step condition: 'Coverage Code' != NULL
    When I click or select "Add Contents Coverage"
    Then I wait until "Building Contents Coverage Header" exists
    When I enter or select "Farm Contents{TAB}" in "Coverage Code*"
    When I enter or select "100000{TAB}" in "Amount of Insurance*"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "4{TAB}" in "Peril Group*"
    When I enter or select "No{TAB}" in "Replacement Cost"
    When I enter or select "Farm Stand{TAB}" in "Description Code*"
    When I enter or select "SFP Contents{TAB}" in "Description"

    # Source step 0131: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0132: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0135: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0136: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0139: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0140: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0142: Set DetailIndex | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building Optional Coverages | Source XTestStep: 3a13d49c-166a-a92d-d5d7-1cc497b2377e
    # Step condition: DetailIndex != NULL
    When I retain a blank/not-supplied value as runtime value "DetailIndex"

    # Source step 0143: Building Optional Coverages | Module: Building Optional Coverages
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building Optional Coverages | Source XTestStep: 3a13d49c-166a-eced-05a6-ce626534aff1
    # Step condition: 'Coverage Type' != NULL
    When I click or select "Optional Coverages"
    Then I wait until "Optional Coverages Header" exists
    When if field condition "'Coverage Type' != NULL" is satisfied, I enter or select "Consequential Loss{TAB}" in "CoverageType"
    When if field condition "'Coverage Type' != NULL" is satisfied, I click or select "Add Optional Coverage"
    When if field condition "'Coverage Type' == \"Consequential Loss\"" is satisfied, I enter or select "500{TAB}" in "Consequential Loss - Deductible"
    When if field condition "'Coverage Type' == \"Consequential Loss\"" is satisfied, I enter or select "10000{TAB}" in "Consequential Loss - Additional Limit*"

    # Source step 0144: Building Optional Coverages | Module: Building Optional Coverages
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building Optional Coverages | Source XTestStep: 3a13d49c-166a-72de-a337-6867c6762af1
    # Step condition: DetailIndex != NULL
    When I click or select "Detail"
    Then I wait until "Detail" no longer exists
    When I click or select "Optional Coverages"
    Then I wait until "Optional Coverages Header" exists
    When if field condition "DetailIndex != NULL" is satisfied, I leave "Livestock Loss of Value - Limit Per Livestock*" blank because the reusable parameter is not supplied for this iteration
    Then if field condition "DetailIndex != NULL" is satisfied, "Livestock Loss of Value - Livestock Limit (ReadOnly)" should exist

    # Source step 0145: Click to Return | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building Optional Coverages > SFP|Div 2|Return to Building screen from Coverage | Source XTestStep: 3a13d49c-166a-a4a6-ea70-47cacba8fda4
    When I click or select "Return"

    # Source step 0146: Wait for 2 - Building Header | Module: Building - Main Page
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building Optional Coverages > SFP|Div 2|Return to Building screen from Coverage | Source XTestStep: 3a13d49c-166a-6774-cf3b-d619327397fe
    Then I wait until "2 - Building" exists

    # Source step 0147: Click to Return | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Return to Building screen from Coverage | Source XTestStep: 3a13d49c-166a-a4a6-ea70-47cacba8fda4
    When I click or select "Return"

    # Source step 0148: Wait for 2 - Building Header | Module: Building - Main Page
    # Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Return to Building screen from Coverage | Source XTestStep: 3a13d49c-166a-6774-cf3b-d619327397fe
    Then I wait until "2 - Building" exists

    # Source step 0149: Navigate to 3 - Farm Personal Property | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3| Navigate to 3 - Farm Personal Property screen | Source XTestStep: 3a13d49c-166a-d470-f979-f1da3a5e050b
    When I click or select "3 - Farm Personal Property"

    # Source step 0150: Wait for 3 - Farm Personal Property to load | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3| Navigate to 3 - Farm Personal Property screen | Source XTestStep: 3a13d49c-166a-6626-8cbf-c1a5b906fb39
    Then I wait until "3 - Farm Personal Property" exists

    # Source step 0151: Select 461|Rental Reimbursement Coverage | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|461|Add Rental Reimbursement Coverage | Source XTestStep: 3a13d49c-166a-ec4d-873e-4e4e1c7ad552
    When I enter or select "Rental Reimbursement{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0152: Add Rental Reimbursement Coverage Details | Module: 461|Rental Reimbursement
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|461|Add Rental Reimbursement Coverage | Source XTestStep: 3a13d49c-166a-5b26-710a-e1d1e281d9a4
    Then I wait until "Rental Reimbursement" exists
    When I enter or select "10,000{TAB}" in "Amount of Insurance"
    When I click or select "Return"

    # Source step 0153: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|461|Add Rental Reimbursement Coverage | Source XTestStep: 3a13d49c-166a-7faa-daf1-0dcc2c28eb62
    And I use "10,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 461 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 461 > Deductible" property "value" should equals "100"
    Then "Farm Personal Property Summary Table -old > 461 > IRPM" property "value" should equals "N/A"
    Then "Farm Personal Property Summary Table -old > 461 > Peril Group" property "value" should equals "8"
    And I use "10,000" as the identifying constraint for "Farm Personal Property Summary Table > 461 > Limit"
    Then "Farm Personal Property Summary Table > 461 > Ded*" property "value" should equals "100"
    Then "Farm Personal Property Summary Table > 461 > PG" property "value" should equals "8"

    # Source step 0154: Select 464|Audio, Visual and Data Electronic Equipment | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|464|Add Audio, Visual and Data Electronic Equipment | Source XTestStep: 3a13d49c-166a-dc0d-690a-90cca9730ddb
    When I enter or select "Audio, Visual and Data Electronic Equipment{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0155: Add Audio, Visual and Data Electronic Equipment Coverage Details | Module: 464|Audio, Visual and Data Electronic Equipment
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|464|Add Audio, Visual and Data Electronic Equipment | Source XTestStep: 3a13d49c-166a-5e97-71b2-b781973f9fa4
    Then I wait until "Audio, Visual and Data Electronic Equipment" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "464 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0156: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|464|Add Audio, Visual and Data Electronic Equipment | Source XTestStep: 3a13d49c-166a-8be2-b467-71bfd17ac0bd
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > $1 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > $1 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > $1 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > $1 > Peril Group" property "value" should equals "4"
    Then "Farm Personal Property Summary Table -old > $1 > Code" property "value" should equals "464"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 464 > Limit"
    Then "Farm Personal Property Summary Table > 464 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 464 > PG" property "value" should equals "4"

    # Source step 0157: Set DetailIndex | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage | Source XTestStep: 3a13d49c-166a-0eb0-a16f-9c84cc5d66f3
    # Step condition: DetailIndex != NULL
    When I retain hard-coded value "3" as runtime value "DetailIndex"

    # Source step 0158: Select 470|Livestock - Specific coverage | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage | Source XTestStep: 3a13d49c-166a-a4cd-88b4-f3a02112d958
    When I enter or select "Livestock - Specific{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0159: Add Livestock - Specific coverage details | Module: 470|Livestock - Specific
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage | Source XTestStep: 3a13d49c-166a-5058-9679-470b86ec7cfc
    Then I wait until "Livestock - Specific" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    Then "Peril Group" property "value" should equals "9"
    When I enter or select "(select){TAB}" in "Animals Other Than Defined Livestock"
    When I leave "Description of Animals Other Than Defined Livestock" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "Yes{TAB}" in "Suffocation Of Livestock"
    When I leave "Livestock Freezing Peril" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "470 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0160: Click Detail to re-enter Desc | Module: 470|Livestock - Specific
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage | Source XTestStep: 3a13d49c-166a-d54f-9e8b-85d4b1fcc4d5
    # Step condition: DetailIndex != NULL
    When I click or select "Detail"
    Then I wait until "Livestock - Specific" exists
    When I enter or select "470 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0161: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage | Source XTestStep: 3a13d49c-166a-5b0f-1456-127f9ab306dd
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 470 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 470 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 470 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 470 > Peril Group" property "value" should equals "9"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 470 > Limit"
    Then "Farm Personal Property Summary Table > 470 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 470 > PG" property "value" should equals "9"
    Then "Farm Personal Property Summary Table > 470 > IRPM" property "value" should equals "0%"

    # Source step 0162: Increase ReferralCounter Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage > Common|General|UW Referral|Send Referral Message to TDS | Source XTestStep: 3a13d49c-165b-8367-098b-19069cf4339f
    When I derive and retain the RUNTIME-DERIVED buffer expression "{MATH[{B[ReferralCounter]}+1]}" as runtime value "ReferralCounter"

    # Source step 0164: Select 471|Livestock - Blanket Coverage | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|471|Add Livestock - Blanket Coverage | Source XTestStep: 3a13d49c-166a-aaee-e542-7ff0b52fb804
    When I enter or select "Livestock - Blanket{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0165: Add Livestock - Blanket coverage details | Module: 471|Livestock - Blanket
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|471|Add Livestock - Blanket Coverage | Source XTestStep: 3a13d49c-166a-ac2a-918a-8b3244ccc6c9
    Then I wait until "Livestock - Blanket" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    Then "Peril Group" property "value" should equals "9"
    When I enter or select "Dairy Cows Only{TAB}" in "Optional Property Coverage"
    When I leave "Description of Animals Other Than Defined Livestock" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "Yes{TAB}" in "Suffocation Of Livestock"
    When I leave "Livestock Freezing Peril" blank because the reusable parameter is not supplied for this iteration
    When I click or select "Return"

    # Source step 0166: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|471|Add Livestock - Blanket Coverage | Source XTestStep: 3a13d49c-166a-d3bf-f4e4-e471bb351e62
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 471 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 471 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 471 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 471 > Peril Group" property "value" should equals "9"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 471 > Limit"
    Then "Farm Personal Property Summary Table > 471 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 471 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table > 471 > PG" property "value" should equals "9"

    # Source step 0167: Increase ReferralCounter Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|471|Add Livestock - Blanket Coverage > Common|General|UW Referral|Send Referral Message to TDS | Source XTestStep: 3a13d49c-165b-8367-098b-19069cf4339f
    When I derive and retain the RUNTIME-DERIVED buffer expression "{MATH[{B[ReferralCounter]}+1]}" as runtime value "ReferralCounter"

    # Source step 0169: Select 472|Farm Machinery - Specific | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|472|Add Farm Machinery - Specific | Source XTestStep: 3a13d49c-166a-463c-96a5-d39f82097b8f
    When I enter or select "Farm Machinery - Specific{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0170: Add Farm Machinery - Specific | Module: 472|Farm Machinery - Specific
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|472|Add Farm Machinery - Specific | Source XTestStep: 3a13d49c-166a-9af8-ab88-73ef53d9fac1
    Then I wait until "Farm Machinery - Specific" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I leave "Peril Group" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "None{TAB}" in "Special Use"
    When I enter or select "No{TAB}" in "Tractor Glass"
    When I enter or select "472 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0171: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|472|Add Farm Machinery - Specific | Source XTestStep: 3a13d49c-166a-4490-df0b-235a124cee90
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 472 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 472 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 472 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 472 > Peril Group" property "value" should equals "<BLANK — reusable-block parameter is not supplied: Peril Group>"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 472 > Limit"
    Then "Farm Personal Property Summary Table > 472 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 472 > PG" property "value" should equals "<BLANK — reusable-block parameter is not supplied: Peril Group>"

    # Source step 0172: Select 473|Farm Machinery - Blanket Coverage | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|473|Add Farm Machinery - Blanket Coverage | Source XTestStep: 3a13d49c-166a-11a0-8566-a3573b9cc706
    When I enter or select "Farm Machinery - Blanket{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0173: 473|Add Farm Machinery - Blanket Coverage | Module: 473|Farm Machinery - Blanket
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|473|Add Farm Machinery - Blanket Coverage | Source XTestStep: 3a13d49c-166a-a075-bd33-bbab88bdf7c8
    Then I wait until "Farm Machinery - Blanket" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I leave "Peril Group" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "None{TAB}" in "Special Use"
    When I click or select "Return"

    # Source step 0174: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|473|Add Farm Machinery - Blanket Coverage | Source XTestStep: 3a13d49c-166a-3b86-7dc5-ad0422a75b3b
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 473 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 473 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 473 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 473 > Peril Group" property "value" should equals "<BLANK — reusable-block parameter is not supplied: Peril Group>"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 473 > Limit"
    Then "Farm Personal Property Summary Table > 473 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 473 > PG" property "value" should equals "<BLANK — reusable-block parameter is not supplied: Peril Group>"

    # Source step 0175: Select 474|Farm Products, Supplies, Tools - Specific | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|474|Add Farm Products, Supplies, Tools - Specific | Source XTestStep: 3a13d49c-166a-6bb5-3093-367881820cc8
    When I enter or select "Farm Products, Supplies, Tools - Specific{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0176: Add Farm Products, Supplies, Tools - Specific | Module: 474|Farm Products, Supplies, Tools - Specific
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|474|Add Farm Products, Supplies, Tools - Specific | Source XTestStep: 3a13d49c-166a-628e-c391-0dfbc9f4a648
    Then I wait until "Farm Products, Supplies, Tools - Specific" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "4{TAB}" in "Peril Group"
    When I enter or select "None{TAB}{TAB}{TAB}" in "Excess Property Away"
    When I leave "Where is the property stored off-premises?*" blank because the reusable parameter is not supplied for this iteration
    When I leave "Why is it stored in this location?*" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "474 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0177: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|474|Add Farm Products, Supplies, Tools - Specific | Source XTestStep: 3a13d49c-166a-d61b-fbd1-f29df1890977
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 474 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 474 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 474 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 474 > Peril Group" property "value" should equals "4"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 474 > Limit"
    Then "Farm Personal Property Summary Table > 474 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 474 > PG" property "value" should equals "4"

    # Source step 0178: Select 475|Farm Products, Supplies, Tools - Blanket | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|475|Farm Products, Supplies, Tools - Blanket | Source XTestStep: 3a13d49c-166a-9741-6fa3-aca6645e5ab6
    When I enter or select "Farm Products, Supplies, Tools - Blanket{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0179: Add Farm Products, Supplies, Tools - Blanket | Module: 475|Farm Products, Supplies, Tools - Blanket
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|475|Farm Products, Supplies, Tools - Blanket | Source XTestStep: 3a13d49c-166a-53d7-a601-9f34b1efb92f
    Then I wait until "Farm Products, Supplies, Tools - Blanket" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "4{TAB}" in "Peril Group"
    When I enter or select "None{TAB}" in "Excess Property Away"
    When I enter or select "None{TAB}" in "Periodic Increase in Limits Annual Percentage"
    When I enter or select "No{TAB}" in "Boats, Skiffs, Rafts and Their Equipment Confined to Lobster Pounds"
    When I leave "Where is the property stored off-premises?*" blank because the reusable parameter is not supplied for this iteration
    When I leave "Why is it stored in this location?*" blank because the reusable parameter is not supplied for this iteration
    When I click or select "Return"

    # Source step 0180: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|475|Farm Products, Supplies, Tools - Blanket | Source XTestStep: 3a13d49c-166a-7803-fa65-b0d1ac1fa54d
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 475 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 475 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 475 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 475 > Peril Group" property "value" should equals "4"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 475 > Limit"
    Then "Farm Personal Property Summary Table > 475 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 475 > PG" property "value" should equals "4"

    # Source step 0181: Select 476|Special Silo Unloader Coverage | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|476|Special Silo Unloader Coverage | Source XTestStep: 3a13d49c-166a-1ef1-a354-ef2a211c96e0
    When I enter or select "Special Silo Unloader Coverage{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0182: Add Special Silo Unloader Coverage details | Module: 476|Special Silo Unloader Coverage
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|476|Special Silo Unloader Coverage | Source XTestStep: 3a13d49c-166a-a104-bfc2-5f721ad4a1eb
    Then I wait until "Special Silo Unloader Coverage" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "476 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0183: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|476|Special Silo Unloader Coverage | Source XTestStep: 3a13d49c-166a-1933-2088-eed614a9a8e9
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 476 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 476 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 476 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 476 > Peril Group" property "value" should equals "8"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 476 > Limit"
    Then "Farm Personal Property Summary Table > 476 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 476 > PG" property "value" should equals "8"

    # Source step 0184: Select 477|Borrowed/Rented Farm Machinery - Blanket | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|477|Borrowed/Rented Farm Machinery - Blanket | Source XTestStep: 3a13d49c-166a-14dd-ee9c-34ca630a4637
    When I enter or select "Borrowed/Rented Farm Machinery - Blanket{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0185: Add Borrowed/Rented Farm Machinery - Blanket coverage details | Module: 477|Borrowed/Rented Farm Machinery - Blanket
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|477|Borrowed/Rented Farm Machinery - Blanket | Source XTestStep: 3a13d49c-166a-5c09-5a6d-80f8a788a29c
    Then I wait until "Borrowed/Rented Farm Machinery - Blanket" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I leave "Peril Group" blank because the reusable parameter is not supplied for this iteration
    When I click or select "Return"

    # Source step 0186: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|477|Borrowed/Rented Farm Machinery - Blanket | Source XTestStep: 3a13d49c-166a-bed5-d8a6-d590721975c9
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 477 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 477 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 477 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 477 > Peril Group" property "value" should equals "<BLANK — reusable-block parameter is not supplied: Peril Group>"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 477 > Limit"
    Then "Farm Personal Property Summary Table > 477 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 477 > PG" property "value" should equals "<BLANK — reusable-block parameter is not supplied: Peril Group>"

    # Source step 0187: Select 478|Nursery and Greenhouse Plants | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|478|Add Nursery and Greenhouse Plants Coverage | Source XTestStep: 3a13d49c-166a-12f2-29d5-bcc92f856028
    When I enter or select "Nursery and Greenhouse Plants{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0188: Add Nursery and Greenhouse Plants | Module: 478|Nursery and Greenhouse Plants
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|478|Add Nursery and Greenhouse Plants Coverage | Source XTestStep: 3a13d49c-166a-dfd5-f5be-13a1e32be725
    Then I wait until "Nursery and Greenhouse Plants" exists
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "1{TAB}" in "Peril Group"
    When I enter or select "500{TAB}" in "Outside Plants"
    When if field condition "January != 0" is satisfied, I enter or select "5000{TAB}" in "January $"
    When if field condition "February != 0" is satisfied, I enter or select "5000{TAB}" in "February $"
    When if field condition "March != 0" is satisfied, I enter or select "5000{TAB}" in "March $"
    When if field condition "April != 0" is satisfied, I enter or select "5000{TAB}" in "April $"
    When if field condition "October != 0" is satisfied, I enter or select "5000{TAB}" in "October $"
    When if field condition "November != 0" is satisfied, I enter or select "5000{TAB}" in "November $"
    When if field condition "December != 0" is satisfied, I enter or select "5000{TAB}" in "December $"
    When I enter or select "478 Test Description StraightThrough{TAB}" in "Description"

    # Source step 0189: Verify Monthly Totals and Averages | Module: 478|Nursery and Greenhouse Plants
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|478|Add Nursery and Greenhouse Plants Coverage | Source XTestStep: 3a13d49c-166a-5ebd-89a4-9fd3e52f7e9b
    Then "Total Est.Value $" property "value" should equals "{CALC[FIXED(5000+5000+5000+5000+0+0+0+0+0+5000+5000+5000,0,FALSE)]}"
    Then "Monthly Average $" property "value" should equals "{CALC[FIXED((5000+5000+5000+5000+0+0+0+0+0+5000+5000+5000)/12,0,FALSE)]}"
    When I click or select "Return"
    When I capture "Monthly Average $" as runtime value "Monthly Average $"

    # Source step 0190: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|478|Add Nursery and Greenhouse Plants Coverage | Source XTestStep: 3a13d49c-166a-affe-75a7-4f08e2a45a2f
    Then "Farm Personal Property Summary Table -old > 478 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 478 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 478 > Peril Group" property "value" should equals "1"
    And I use captured runtime value "{B[Monthly Average $]}" as the identifying constraint for "Farm Personal Property Summary Table -old > 478 > Amount of Insurance"
    Then "Farm Personal Property Summary Table > 478 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 478 > PG" property "value" should equals "1"
    And I use captured runtime value "{B[Monthly Average $]}" as the identifying constraint for "Farm Personal Property Summary Table > 478 > Limit"

    # Source step 0191: Select 490|Multi Fuctional Equipment | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|490|Multi Functional Equipment | Source XTestStep: 3a13d49c-166a-2822-b6ff-2ccfb1ca1618
    When I enter or select "Multi Functional Equipment{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0192: Add Multi Functional Equipment | Module: 490|Multi Functional Equipment
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|490|Multi Functional Equipment | Source XTestStep: 3a13d49c-166a-b19a-e764-9ccd6a561548
    Then I wait until "Multi Functional Equipment" exists
    When I enter or select "5,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    Then "Peril Group" property "value" should equals "10"
    When I enter or select "ATV{TAB}" in "Snowmobile/ATV"
    When I enter or select "{LYEAR}{TAB}" in "Year"
    When I enter or select "NameBrand A{TAB}" in "Make Model"
    When I enter or select "123456789{TAB}" in "Serial #"
    When I enter or select "420{TAB}" in "CC"
    When I enter or select "25{TAB}" in "HP"
    When I click or select "Return"

    # Source step 0193: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|490|Multi Functional Equipment | Source XTestStep: 3a13d49c-166a-c519-ce7b-79271a81f6bb
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table -old > 490 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 490 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 490 > IRPM" property "value" should equals "N/A"
    Then "Farm Personal Property Summary Table -old > 490 > Peril Group" property "value" should equals "10"
    And I use "5,000" as the identifying constraint for "Farm Personal Property Summary Table > 490 > Limit"
    Then "Farm Personal Property Summary Table > 490 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 490 > PG" property "value" should equals "10"

    # Source step 0194: Select 650|PAC - Crops, Feed, Supplies, etc. | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|650|Add PAC - Crops, Feed, Supplies, etc. | Source XTestStep: 3a13d49c-166a-412d-87ac-2688e73b80e7
    When I enter or select "PAC - Crops, Feed, Supplies, etc.{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0195: Add PAC - Crops, Feed, Supplies, etc. | Module: 650|PAC - Crops, Feed, Supplies, etc.
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|650|Add PAC - Crops, Feed, Supplies, etc. | Source XTestStep: 3a13d49c-166a-3405-fd19-5a878a23d4d7
    Then I wait until "PAC - Crops, Feed, Supplies, etc." exists
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "1{TAB}" in "Peril Group"
    When if field condition "January != 0" is satisfied, I enter or select "5000{TAB}" in "January"
    When if field condition "February != 0" is satisfied, I enter or select "5000{TAB}" in "February"
    When if field condition "March != 0" is satisfied, I enter or select "5000{TAB}" in "March"
    When if field condition "April != 0" is satisfied, I enter or select "5000{TAB}" in "April"
    When if field condition "October != 0" is satisfied, I enter or select "5000{TAB}" in "October"
    When if field condition "November != 0" is satisfied, I enter or select "5000{TAB}" in "November"
    When if field condition "December != 0" is satisfied, I enter or select "5000{TAB}" in "December"
    When I enter or select "650 Test Description StraightThrough{TAB}" in "Description"

    # Source step 0196: Verify Monthly Totals and Averages | Module: 650|PAC - Crops, Feed, Supplies, etc.
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|650|Add PAC - Crops, Feed, Supplies, etc. | Source XTestStep: 3a13d49c-166a-8f15-e38b-bd2e948011f4
    Then "Total Est.Value $" property "value" should equals "{CALC[FIXED(5000+5000+5000+5000+0+0+0+0+0+5000+5000+5000,0,FALSE)]}"
    Then "Monthly Average $" property "value" should equals "{CALC[FIXED((5000+5000+5000+5000+0+0+0+0+0+5000+5000+5000)/12,0,FALSE)]}"
    When I click or select "Return"
    When I capture "Monthly Average $" as runtime value "Monthly Average $"

    # Source step 0197: Verify Coverage Details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|650|Add PAC - Crops, Feed, Supplies, etc. | Source XTestStep: 3a13d49c-166a-7487-5be5-83c510982a49
    Then "Farm Personal Property Summary Table -old > 650 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 650 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 650 > Peril Group" property "value" should equals "1"
    And I use captured runtime value "{B[Monthly Average $]}" as the identifying constraint for "Farm Personal Property Summary Table -old > 650 > Amount of Insurance"
    Then "Farm Personal Property Summary Table > 650 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 650 > PG" property "value" should equals "1"
    And I use captured runtime value "{B[Monthly Average $]}" as the identifying constraint for "Farm Personal Property Summary Table > 650 > Limit"

    # Source step 0198: Set DetailIndex | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|651|Add PAC - Hay, Grain, Straw, and Fodder | Source XTestStep: 3a13d49c-166a-8c42-ef7e-b1df2fed2b16
    # Step condition: DetailIndex != NULL
    When I retain a blank/not-supplied value as runtime value "DetailIndex"

    # Source step 0199: Select 651|PAC - Hay, Grain, Straw, and Fodder | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|651|Add PAC - Hay, Grain, Straw, and Fodder | Source XTestStep: 3a13d49c-166a-81f1-1d7a-1999b4938405
    When I enter or select "PAC - Hay, Grain, Straw, and Fodder{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0200: Add PAC - Hay, Grain, Straw, and Fodder | Module: 651|PAC - Hay, Grain, Straw, and Fodder
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|651|Add PAC - Hay, Grain, Straw, and Fodder | Source XTestStep: 3a13d49c-166a-f883-9bf8-61c06e746417
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "1{TAB}" in "Peril Group"
    When I enter or select "(select){TAB}" in "Apply Per Stack Limit"
    When I leave "Per Stack Limit" blank because the reusable parameter is not supplied for this iteration
    When I leave "Per Stack Limit (>100K)" blank because the reusable parameter is not supplied for this iteration
    When if field condition "January != 0" is satisfied, I enter or select "5000{TAB}" in "January"
    When if field condition "February != 0" is satisfied, I enter or select "5000{TAB}" in "February"
    When if field condition "March != 0" is satisfied, I enter or select "5000{TAB}" in "March"
    When if field condition "April != 0" is satisfied, I enter or select "5000{TAB}" in "April"
    When if field condition "October != 0" is satisfied, I enter or select "5000{TAB}" in "October"
    When if field condition "November != 0" is satisfied, I enter or select "5000{TAB}" in "November"
    When if field condition "December != 0" is satisfied, I enter or select "5000{TAB}" in "December"
    When I enter or select "651 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"

    # Source step 0201: Verify Monthly Totals and Averages | Module: 651|PAC - Hay, Grain, Straw, and Fodder
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|651|Add PAC - Hay, Grain, Straw, and Fodder | Source XTestStep: 3a13d49c-166a-be32-4234-f282a8c01687
    Then I wait until "Deductible" exists
    When I enter or select "651 Test Description StraightThrough{ENTER}{TAB}{TAB}{TAB}" in "Description"
    Then "Total Est.Value $" property "value" should equals "{CALC[FIXED(5000+5000+5000+5000+0+0+0+0+0+5000+5000+5000,0,FALSE)]}"
    Then "Monthly Average $" property "value" should equals "{CALC[FIXED((5000+5000+5000+5000+0+0+0+0+0+5000+5000+5000)/12,0,FALSE)]}"
    When I click or select "Return"
    When I capture "Monthly Average $" as runtime value "Monthly Average $"

    # Source step 0202: Click Detail to enter Desc | Module: 651|PAC - Hay, Grain, Straw, and Fodder
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|651|Add PAC - Hay, Grain, Straw, and Fodder | Source XTestStep: 3a13d49c-166a-8b1a-7d29-57b3ff119b7c
    # Step condition: DetailIndex != NULL
    When I click or select "Detail"
    Then I wait until "PAC - Hay, Grain, Straw, and Fodder" exists
    When I enter or select "651 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0203: Verify coverage details | Module: Farm Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|651|Add PAC - Hay, Grain, Straw, and Fodder | Source XTestStep: 3a13d49c-166a-df36-a0bc-bcba868db65d
    And I use captured runtime value "{B[Monthly Average $]}" as the identifying constraint for "Farm Personal Property Summary Table -old > 651 > Amount of Insurance"
    Then "Farm Personal Property Summary Table -old > 651 > Deductible" property "value" should equals "500"
    Then "Farm Personal Property Summary Table -old > 651 > IRPM" property "value" should equals "0%"
    Then "Farm Personal Property Summary Table -old > 651 > Peril Group" property "value" should equals "1"
    And I use captured runtime value "{B[Monthly Average $]}" as the identifying constraint for "Farm Personal Property Summary Table > 651 > Limit"
    Then "Farm Personal Property Summary Table > 651 > Ded*" property "value" should equals "500"
    Then "Farm Personal Property Summary Table > 651 > PG" property "value" should equals "1"

    # Source step 0204: Navigate to 4 - Scheduled Personal Property | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4| Navigate to 4 - Scheduled Personal Property screen | Source XTestStep: 3a13d49c-166a-812e-f18c-e8094739b84c
    When I click or select "4 - Scheduled Personal Property"

    # Source step 0205: Wait for 4 - Scheduled Personal Property screen to load | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4| Navigate to 4 - Scheduled Personal Property screen | Source XTestStep: 3a13d49c-166a-12b3-935f-3b29bc25ab3a
    Then I wait until "4 - Scheduled Personal Property" exists

    # Source step 0206: Select 401|Bicycles coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|401|Add Bicycles Coverage | Source XTestStep: 3a13d49c-166a-9ab9-1d54-940f0847be2e
    When I enter or select "Bicycles{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0207: Add Bicycles coverage Details | Module: 401|Bicycles
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|401|Add Bicycles Coverage | Source XTestStep: 3a13d49c-166a-c743-43f7-6bf4c19e08c8
    Then I wait until "Bicycles" exists
    When I enter or select "1,000{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "401 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0208: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|401|Add Bicycles Coverage | Source XTestStep: 3a13d49c-166a-74d7-c2f3-8a9dff3767da
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 401 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 401 > Deductible" property "value" should equals "N/A"
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 401 > Limit"
    Then "Scheduled Personal Property Summary Table > 401 > Ded*" property "value" should equals "N/A"

    # Source step 0209: Select 402|Photography Equipment | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|402|Add Photography Equipment Coverage | Source XTestStep: 3a13d49c-166a-2a7b-832c-ed6e714a4695
    When I enter or select "Photography Equipment{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0210: Add Photography Coverage Details | Module: 402|Photography Equipment
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|402|Add Photography Equipment Coverage | Source XTestStep: 3a13d49c-166a-b459-7fdf-4689a47f38ff
    Then I wait until "Photography Equipment" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "No{TAB}" in "Professional Use"
    When I enter or select "402 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0211: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|402|Add Photography Equipment Coverage | Source XTestStep: 3a13d49c-166a-f11b-09bb-2d498ca95ebc
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 402 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 402 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 402 > Limit"
    Then "Scheduled Personal Property Summary Table > 402 > Ded*" property "value" should equals "N/A"

    # Source step 0212: Select 403|Coin Collections coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|403|Add Coin Collections Coverage | Source XTestStep: 3a13d49c-166a-205e-b499-5760ae34ab1a
    When I enter or select "Coin Collections{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0213: Add Coin Collections Details | Module: 403|Coin Collections
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|403|Add Coin Collections Coverage | Source XTestStep: 3a13d49c-166a-c2ed-a959-4adafe2ede24
    Then I wait until "Coin Collections" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "No{TAB}" in "Is this collection kept in a vault?"
    When I enter or select "No{TAB}" in "Unattended Vehicle"
    When I enter or select "403 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0214: Verify Coverage Details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|403|Add Coin Collections Coverage | Source XTestStep: 3a13d49c-166a-d88e-5182-c90acdabd683
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 403 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 403 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 403 > Limit"
    Then "Scheduled Personal Property Summary Table > 403 > Ded*" property "value" should equals "N/A"

    # Source step 0215: Select 404|Furs Coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|404|Add Furs Coverage | Source XTestStep: 3a13d49c-166a-2362-63e3-76d41bb54e50
    When I enter or select "Furs{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0216: Add Furs coverage | Module: 404|Furs
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|404|Add Furs Coverage | Source XTestStep: 3a13d49c-166a-c8c5-72c9-5b3c845fc358
    Then I wait until "Furs" exists
    When I enter or select "2,000{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "404 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0217: Verify Coverage Details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|404|Add Furs Coverage | Source XTestStep: 3a13d49c-166a-1777-5bd5-1194259c9a6a
    And I use "2,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 404 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 404 > Deductible" property "value" should equals "N/A"
    And I use "2,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 404 > Limit"
    Then "Scheduled Personal Property Summary Table > 404 > Ded*" property "value" should equals "N/A"

    # Source step 0218: Select 405|Golf Equipment | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|405|Add Golf Equipment Coverage | Source XTestStep: 3a13d49c-166a-a5af-1c9b-a5f181a84fd8
    When I enter or select "Golf Equipment{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0219: Add Golf Equipment Coverage Details | Module: 405|Golf Equipment
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|405|Add Golf Equipment Coverage | Source XTestStep: 3a13d49c-166a-0c0a-ad31-6be3a9f13beb
    Then I wait until "Golf Equipment" exists
    When I enter or select "1,000 {TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "405 Test Description StraightThrough {TAB}" in "Description"
    When I click or select "Return"

    # Source step 0220: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|405|Add Golf Equipment Coverage | Source XTestStep: 3a13d49c-166a-0a55-4850-ee4401d728b2
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 405 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 405 > Deductible" property "value" should equals "N/A"
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 405 > Limit"
    Then "Scheduled Personal Property Summary Table > 405 > Ded*" property "value" should equals "N/A"

    # Source step 0221: Select 406|Guns coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|406|Guns | Source XTestStep: 3a13d49c-166a-3ae5-5aa7-adbbb9546105
    When I enter or select "Guns{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0222: Add Guns coverage | Module: 406|Guns
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|406|Guns | Source XTestStep: 3a13d49c-166a-3b12-871f-d2dd52233ff9
    Then I wait until "Guns" exists
    When I enter or select "2,000{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "406 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0223: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|406|Guns | Source XTestStep: 3a13d49c-166a-1555-c0e7-5070fb4f0311
    And I use "2,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 406 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 406 > Deductible" property "value" should equals "N/A"
    And I use "2,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 406 > Limit"
    Then "Scheduled Personal Property Summary Table > 406 > Ded*" property "value" should equals "N/A"

    # Source step 0224: Select 407|Jewelry coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|407|Jewelry | Source XTestStep: 3a13d49c-166a-7d9e-9028-830efc4cc8c2
    When I enter or select "Jewelry{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0225: Add Jewelry coverage | Module: 407|Jewelry
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|407|Jewelry | Source XTestStep: 3a13d49c-166a-80bf-39f4-9aa3a1fb37bb
    Then I wait until "Jewelry" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "No{TAB}" in "Vault Credit"
    When I enter or select "No{TAB}" in "Gem Print"
    When I enter or select "407 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0226: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|407|Jewelry | Source XTestStep: 3a13d49c-166a-2519-7eb8-291a3bd2e97a
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 407 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 407 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 407 > Limit"
    Then "Scheduled Personal Property Summary Table > 407 > Ded*" property "value" should equals "N/A"

    # Source step 0227: Select 408|Silverware coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|408|Silverware | Source XTestStep: 3a13d49c-166a-23e3-294d-4e20a64fbf9a
    When I enter or select "Silverware{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0228: Add Silverware coverage | Module: 408|Silverware
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|408|Silverware | Source XTestStep: 3a13d49c-166a-942b-ed5e-6370de411441
    Then I wait until "Silverware" exists
    When I enter or select "1,000{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "408 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0229: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|408|Silverware | Source XTestStep: 3a13d49c-166a-5043-32dc-4852de3efc17
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 408 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 408 > Deductible" property "value" should equals "N/A"
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 408 > Limit"
    Then "Scheduled Personal Property Summary Table > 408 > Ded*" property "value" should equals "N/A"

    # Source step 0230: Select 409|Stamp Collections coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|409|Stamp Collections | Source XTestStep: 3a13d49c-166a-56b0-410f-2d2a0a5a24ab
    When I enter or select "Stamp Collections{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0231: Add Stamp Collections coverage | Module: 409|Stamp Collections
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|409|Stamp Collections | Source XTestStep: 3a13d49c-166a-2616-1074-7f6750d34193
    Then I wait until "Stamp Collections" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "No{TAB}" in "Is this collection kept in a vault?"
    When I enter or select "No{TAB}" in "Unattended Vehicle"
    When I enter or select "409 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0232: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|409|Stamp Collections | Source XTestStep: 3a13d49c-166a-8f2f-93d8-72bd2cec15a0
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 409 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 409 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 409 > Limit"
    Then "Scheduled Personal Property Summary Table > 409 > Ded*" property "value" should equals "N/A"

    # Source step 0233: Set DetailIndex | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|410|Add Tourists, & Travelers Personal Effects | Source XTestStep: 3a13d49c-166a-f643-b06f-e77623a6e5ba
    # Step condition: DetailIndex != NULL
    When I retain a blank/not-supplied value as runtime value "DetailIndex"

    # Source step 0234: Select 410|Tourists, & Travelers Personal Effects | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|410|Add Tourists, & Travelers Personal Effects | Source XTestStep: 3a13d49c-166a-1748-6c2d-0774fc9ab768
    When I enter or select "Tourists, & Travelers Personal Effects{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0235: Add Tourists, & Travelers Personal Effects | Module: 410|Tourists, & Travelers Personal Effects
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|410|Add Tourists, & Travelers Personal Effects | Source XTestStep: 3a13d49c-166a-0336-c4aa-ac2b89836773
    When I enter or select "1,000{TAB}" in "Amount of Insurance"
    When I enter or select "None{TAB}" in "Student Extension #"
    When I enter or select "No{TAB}" in "Limit Peril"
    When I enter or select "No{TAB}" in "Unattended Vehicles"
    When I enter or select "No{TAB}" in "Professional Entertainer"
    When I enter or select "None{TAB}" in "Named Person"
    When I leave "Name" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "410 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0236: Add Tourists, & Travelers Personal Effects | Module: 410|Tourists, & Travelers Personal Effects
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|410|Add Tourists, & Travelers Personal Effects | Source XTestStep: 3a13d49c-166a-ccc3-6f44-15ac5b7c19e1
    # Step condition: DetailIndex != NULL
    When I click or select "Detail"
    When I enter or select "410 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0237: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|410|Add Tourists, & Travelers Personal Effects | Source XTestStep: 3a13d49c-166a-d62a-a987-de60368fbbcc
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 410 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 410 > Deductible" property "value" should equals "N/A"
    And I use "1,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 410 > Limit"
    Then "Scheduled Personal Property Summary Table > 410 > Ded*" property "value" should equals "N/A"

    # Source step 0238: Set DetailIndex | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|411|Add Auto Trailer Home Personal Effects | Source XTestStep: 3a13d49c-166a-8765-77aa-8f064eb35745
    # Step condition: DetailIndex != NULL
    When I retain a blank/not-supplied value as runtime value "DetailIndex"

    # Source step 0239: Select 411|Auto Trailer Home Personal Effects | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|411|Add Auto Trailer Home Personal Effects | Source XTestStep: 3a13d49c-166a-157e-d740-a19fdcbdd185
    When I enter or select "Auto Trailer Home Personal Effects{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0240: Add Auto Trailer Home Personal Effects | Module: 411|Auto Trailer Home Personal Effects
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|411|Add Auto Trailer Home Personal Effects | Source XTestStep: 3a13d49c-166a-57d0-20c2-844faf3608ef
    When I enter or select "2,000{TAB}" in "Amount of Insurance"
    When I enter or select "None{TAB}" in "Student Extension"
    When I enter or select "No{TAB}" in "Limit Peril"
    When I enter or select "No{TAB}" in "Unattended Vehicles"
    When I enter or select "No{TAB}" in "Professional Entertainer"
    When I enter or select "None{TAB}" in "Named Person"
    When I leave "Name" blank because the reusable parameter is not supplied for this iteration
    When I enter or select "411 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0241: Add Auto Trailer Home Personal Effects | Module: 411|Auto Trailer Home Personal Effects
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|411|Add Auto Trailer Home Personal Effects | Source XTestStep: 3a13d49c-166a-a082-8c48-c55b060d6323
    # Step condition: DetailIndex != NULL
    When I click or select "Detail"
    When I enter or select "411 Test Description StraightThrough{ENTER}{TAB}{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0242: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|411|Add Auto Trailer Home Personal Effects | Source XTestStep: 3a13d49c-166a-9b78-8577-3ada3528fe8a
    And I use "2,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 411 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 411 > Deductible" property "value" should equals "N/A"
    And I use "2,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 411 > Limit"
    Then "Scheduled Personal Property Summary Table > 411 > Ded*" property "value" should equals "N/A"

    # Source step 0243: Select 412|Musical Instruments - Non-Professional coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|412|Add Musical Instruments - Non-Professional | Source XTestStep: 3a13d49c-166a-5fd3-2945-bad4c40171e4
    When I enter or select "Musical Instruments - Non-Professional{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0244: Add Musical Instruments - Non-Professional coverage | Module: 412|Musical Instruments - Non-Professional
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|412|Add Musical Instruments - Non-Professional | Source XTestStep: 3a13d49c-166a-0d57-5acc-c0fe57fa9f20
    Then I wait until "Musical Instruments - Non-Professional" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "412 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0245: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|412|Add Musical Instruments - Non-Professional | Source XTestStep: 3a13d49c-166a-cb6e-32c6-d99ae3f78bc3
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 412 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 412 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 412 > Limit"
    Then "Scheduled Personal Property Summary Table > 412 > Ded*" property "value" should equals "N/A"

    # Source step 0246: Select 413|Signs coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|413|Add Signs | Source XTestStep: 3a13d49c-166a-520d-2796-4cc8fc278092
    When I enter or select "Signs{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0247: Add Signs coverage | Module: 413|Signs
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|413|Add Signs | Source XTestStep: 3a13d49c-166a-3e65-650c-2165b4f5b0d4
    Then I wait until "Signs" exists
    When I enter or select "1,500{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "Location #1{TAB}" in "Location #"
    When I enter or select "413 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0248: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|413|Add Signs | Source XTestStep: 3a13d49c-166a-fe88-125f-924afd8846ec
    And I use "1,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 413 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 413 > Deductible" property "value" should equals "500"
    And I use "1,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 413 > Limit"
    Then "Scheduled Personal Property Summary Table > 413 > Ded*" property "value" should equals "500"

    # Source step 0249: Select 415|Watercraft Coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|415|Add Watercraft Coverage | Source XTestStep: 3a13d49c-166a-f844-0a23-4a7107f84a93
    When I enter or select "Watercraft{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0250: Add Watercraft coverage details | Module: 415|Watercraft
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|415|Add Watercraft Coverage | Source XTestStep: 3a13d49c-166a-3bab-710c-7f7ad9dd00e6
    Then I wait until "Watercraft" exists
    When I enter or select "8,000{TAB}" in "Amount of Insurance"
    When I enter or select "500{TAB}" in "Deductible"
    When I enter or select "{LYear}{TAB}{TAB}{TAB}" in "Year of Last Appraisal"
    When I enter or select "Inboard/Outboard (less than 26 ft.){TAB}" in "Watercraft Type"
    When I enter or select "{LYear}{TAB}{TAB}{TAB}" in "Year"
    When I enter or select "Four Winns{TAB}" in "Make Model"
    When I enter or select "160{TAB}" in "HP"
    When I enter or select "30{TAB}" in "Max MPH"
    When I enter or select "20{TAB}{TAB}" in "Length"
    When I click or select "Return"

    # Source step 0251: Verify Coverage Details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|415|Add Watercraft Coverage | Source XTestStep: 3a13d49c-166a-c81f-8d6e-74cbc116fc3a
    And I use "8,000" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 415 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 415 > Deductible" property "value" should equals "500"
    And I use "8,000" as the identifying constraint for "Scheduled Personal Property Summary Table > 415 > Limit"
    Then "Scheduled Personal Property Summary Table > 415 > Ded*" property "value" should equals "500"

    # Source step 0252: Select 440|Musical Instruments - Professional coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|440|Add Musical Instruments - Professional | Source XTestStep: 3a13d49c-166a-8a3e-41f0-ecb2948eebda
    When I enter or select "Musical Instruments - Professional{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0253: Add Musical Instruments - Professional | Module: 440|Musical Instruments - Professional
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|440|Add Musical Instruments - Professional | Source XTestStep: 3a13d49c-166a-98cf-bfa9-1ff8e6d81e64
    Then I wait until "Musical Instruments - Professional" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "440 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0254: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|440|Add Musical Instruments - Professional | Source XTestStep: 3a13d49c-166a-bd2b-2a2e-41238ed51e5f
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 440 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 440 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 440 > Limit"
    Then "Scheduled Personal Property Summary Table > 440 > Ded*" property "value" should equals "N/A"

    # Source step 0255: Select Fine Arts coverage | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|442|Add Fine Arts | Source XTestStep: 3a13d49c-166a-edba-6a86-e92a03542dda
    When I enter or select "Fine Arts{TAB}" in "Coverage Selection"
    When I click or select "Add Coverage"

    # Source step 0256: Add Fine Arts | Module: 442|Fine Arts
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|442|Add Fine Arts | Source XTestStep: 3a13d49c-166a-35d9-d8ff-906af5cbffb4
    Then I wait until "Fine Arts" exists
    When I enter or select "2,500{TAB}" in "Amount of Insurance"
    When I enter or select "{LYear}{TAB}" in "Year of Last Appraisal"
    When I enter or select "No{TAB}" in "Include Breakage"
    When I enter or select "442 Test Description StraightThrough{TAB}" in "Description"
    When I click or select "Return"

    # Source step 0257: Verify coverage details | Module: Scheduled Personal Property - Main Page
    # Section: New Application - Data Entry Process > Division 4 | Reusable flow: SFP|Div 4|442|Add Fine Arts | Source XTestStep: 3a13d49c-166a-db54-91f2-f6550a82be2f
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table-old > 442 > Amount of Insurance"
    Then "Scheduled Personal Property Summary Table-old > 442 > Deductible" property "value" should equals "N/A"
    And I use "2,500" as the identifying constraint for "Scheduled Personal Property Summary Table > 442 > Limit"
    Then "Scheduled Personal Property Summary Table > 442 > Ded*" property "value" should equals "N/A"

    # Source step 0258: SFP Navigation Links | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5| Navigate to Div 5 | Source XTestStep: 3a13d49c-166a-162c-2535-9b9323b70cc9
    When I click or select "5 - Liability"

    # Source step 0259: Liability Main | Module: Liability Main
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5| Navigate to Div 5 | Source XTestStep: 3a13d49c-166a-2204-f2bc-c2ed68b5b4a8
    Then I wait until "5 - Liability" exists

    # Source step 0260: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type | Source XTestStep: 3a13d49c-166a-1561-a509-3723fbe18e30
    When I click or select "Policy Info"

    # Source step 0261: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type | Source XTestStep: 3a13d49c-166a-bd59-19dc-02cd4f707b9f
    Then I wait until "Policy Info Header" exists

    # Source step 0262: Input Gross Sales | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type | Source XTestStep: 3a13d49c-166a-5227-efea-a6d6b7b37251
    When I enter or select "7500{TAB}" in "Gross Farm Income"

    # Source step 0263: SFP Navigation Links | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type > SFP|Div 5| Navigate to Div 5 | Source XTestStep: 3a13d49c-166a-162c-2535-9b9323b70cc9
    When I click or select "5 - Liability"

    # Source step 0264: Liability Main | Module: Liability Main
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type > SFP|Div 5| Navigate to Div 5 | Source XTestStep: 3a13d49c-166a-2204-f2bc-c2ed68b5b4a8
    Then I wait until "5 - Liability" exists

    # Source step 0265: Check for Add Liability Main | Module: Liability Main
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type | Source XTestStep: 3a13d49c-166a-fefd-bad0-539ceb011c87
    # Runtime control: If Add Liability Exists > Condition
    Then "Add Liability" should exist

    # Source step 0266: Click Add Liability Main | Module: Liability Main
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type | Source XTestStep: 3a13d49c-166a-6a14-ba63-306e4114ba23
    # Runtime control: If Add Liability Exists > Then
    When I click or select "Add Liability"

    # Source step 0267: Input Liability Farm Type | Module: Liability Farm Type
    # Section: New Application - Data Entry Process > Division 5 | Reusable flow: SFP|Div 5|Input Liability Farm Type | Source XTestStep: 3a13d49c-166a-e265-2a64-1c316bdf7c1b
    # Runtime control: If Add Liability Exists > Then
    Then I wait until "Liability Limit" exists
    Then "Medical Limit" property "value" should equals "$5,000"
    Then "Farm Chemical Limit" property "value" should equals "$25,000"
    Then "Fire Legal Limit" property "value" should equals "$100,000"
    Then "Farm Pollution Limit" property "value" should equals "$50,000"
    Then "Agritainment Limit" property "value" should equals "$25,000/$100,000"
    When I enter or select "7500{TAB}{TAB}" in "Gross Farm Sales"
    When I enter or select "1{TAB}{TAB}" in "Livestock Horses"
    When I enter or select "1{TAB}{TAB}" in "Livestock Small"
    When I enter or select "1{TAB}{TAB}" in "Livestock Large"
    Then "Rate Type" property "value" should equals "2"
    When I enter or select "No{TAB}{TAB}" in "Does the insured own/operate an unmanned aircraft system for their own agricultural precision farming operations only?"
    When I enter or select "$200,000/$200,000{TAB}{TAB}" in "Liability Limit"

    # Source step 0268: EB link is present | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Equipment Breakdown | Reusable flow: SFP|EB| Navigate to Equipment Breakdown screen | Source XTestStep: 3a13d49c-166a-291a-c11a-c7c42ee2dcdb
    # Runtime control: If EB is present then Click > Condition
    Then "Equipment Breakdown" should exist

    # Source step 0269: Navigate to EB | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process > Equipment Breakdown | Reusable flow: SFP|EB| Navigate to Equipment Breakdown screen | Source XTestStep: 3a13d49c-166a-ff78-a9e3-239bb96d705c
    # Runtime control: If EB is present then Click > Then
    When I click or select "Equipment Breakdown"

    # Source step 0270: Wait for Equipment Breakdown to load | Module: Equipment Breakdown
    # Section: New Application - Data Entry Process > Equipment Breakdown | Reusable flow: SFP|EB| Navigate to Equipment Breakdown screen | Source XTestStep: 3a13d49c-166a-be9e-658a-28376ea2473a
    # Runtime control: If EB is present then Click > Then
    Then I wait until "Equipment Breakdown" exists
    When I enter or select "No{TAB}" in "Power Generation"

    # Source step 0271: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0272: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0273: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0274: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0275: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0276: Navigate to SFP UW Questions | Module: SFP Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions| Navigate to SFP UW Screen | Source XTestStep: 3a13d49c-166a-0579-790b-9944be1be074
    When I click or select "SFP UW Questions"

    # Source step 0277: Verify on General Underwriting Questions Screen | Module: General Underwriting Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions| Navigate to SFP UW Screen | Source XTestStep: 3a13d49c-166a-b63c-87b0-9fdb40346376
    Then I wait until "General Underwriting Questions" exists

    # Source step 0278: Input General Underwriting Questions | Module: General Underwriting Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions|Fill out required info | Source XTestStep: 3a13d49c-166a-2178-a94f-0c8b325614ac
    Then I wait until "General Underwriting Questions" exists
    When I enter or select "No{TAB}" in "Are there any operations not listed on this policy conducted on any owned/ leased premise?"
    When I enter or select "No{TAB}" in "Has any applicant had their coverage declined, canceled or non-renewed during the last 3 years?"
    When I enter or select "No{TAB}" in "Has any insured been convicted of a felony?"
    When I enter or select "No{TAB}" in "Are there any solid fuel heating devices in any residences or outbuildings whether or not insured?"
    When I enter or select "No{TAB}" in "Has the applicant had two or more equipment breakdown losses of any size in the last 24 months?"
    When I enter or select "No{TAB}" in "Has the applicant ever had an equipment breakdown loss greater than $25,000?"
    When I enter or select "No{TAB}" in "Does the applicant have a location engaged in the generation of power that’s over 250kw? (This does not include electricity generated solely for emergency, on-premise use)."

    # Source step 0279: Condo UW Questions | Module: Condo UW Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions|Fill out required info | Source XTestStep: 3a13d49c-166a-c95f-172c-0869ffa65c79
    # Runtime control: If Condo UW Exists > Condo UW Exists
    Then "Condo Underwriting Questions Link" should exist

    # Source step 0280: Navigate and answer Condo UW Questions | Module: Condo UW Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions|Fill out required info | Source XTestStep: 3a13d49c-166a-c83e-f0df-b590dc1e47b0
    # Runtime control: If Condo UW Exists > Then
    When I click or select "Condo Underwriting Questions Link"
    Then I wait until "Condo Underwriting Questions" exists
    When I enter or select "No{TAB}" in "Is the building equipped with sufficient and strategically located smoke and heat detectors and/ or automatic sprinkler system which is suitable for the occupancy and type of construction?*"
    When I enter or select "No{TAB}" in "Is the condominium occupied by the owner for 12 months of the year?*"

    # Source step 0281: Snowmobile ATV UW Questions | Module: Snowmobile ATV UW Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions|Fill out required info | Source XTestStep: 3a13d49c-166a-90ac-adb2-a0cc4aa9cc05
    # Runtime control: If Snowmobile ATV UW Exists > Snowmobile ATV UW Exists
    Then "Snowmobile ATV Questions" should exist

    # Source step 0282: Navigate and Input Snowmobile ATV UW Questions | Module: Snowmobile ATV UW Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions|Fill out required info | Source XTestStep: 3a13d49c-166a-3620-ec03-e98b555f8153
    # Runtime control: If Snowmobile ATV UW Exists > Then
    When I click or select "Snowmobile ATV Questions"
    Then I wait until "Snowmobile ATV Questions Header" exists
    When I enter or select "No{TAB}" in "Any off premises exposure?*"
    When I enter or select "No{TAB}" in "Has any operator had a major motor vehicle violation or three (3) or more minor violations over the last three (3) years? *"
    When I enter or select "No{TAB}" in "Are any units modified, customized or high performance?*"
    When I enter or select "No{TAB}" in "Are any units used for public livery or used to give rides to the public at any organized gathering/celebration?*"
    When I enter or select "No{TAB}" in "Are any units rented or used as rentals?*"
    When I enter or select "No{TAB}" in "Any units used in competitive races or demonstrations?*"
    Then I wait until "Refresh" exists
    When I click or select "OK"

    # Source step 0283: Click OK | Module: General Underwriting Questions
    # Section: New Application - Data Entry Process | Reusable flow: SFP|SFP UW Questions|Fill out required info | Source XTestStep: 3a13d49c-166a-f113-4259-3d4acde52eab
    # Runtime control: If Snowmobile ATV UW Exists > Else
    When I click or select "OK"

    # Source step 0284: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0285: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0286: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0287: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0292: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0293: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0294: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0295: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0296: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0297: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0298: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0299: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0300: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0301: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0302: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0303: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0304: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0348: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0349: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0350: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0351: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0352: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0353: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0357: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0358: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0359: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0360: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0361: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0362: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0363: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0364: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0408: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0409: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0410: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0411: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0412: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0413: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0414: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0415: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0420: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0421: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0422: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svdw-clas03:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0423: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0424: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0425: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0426: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\SFP_StraightThrough_NV_{B[QuoteID]}.xml"

    # Source step 0432: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0433: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\\" -FileName \"SFP_StraightThrough\" -State  \"NV\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0434: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0435: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0436: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0437: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0438: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0439: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0440: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0441: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0442: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0444: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0445: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0446: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0447: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0448: Close Edge Beta Browsers | Module: TBox Start Program
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
# Source step 0088: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-db96-2f0e-1e230bb9a656
#    - INPUT "Duration" with "1500"
# Source step 0089: "Insurance Score" in module "Policy Info|Insurance Score" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-84af-bc6a-3f9f6e937252
#    - VERIFY (Exists) "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS" with "True"
# Source step 0090: "Check if it is BAP VT" in module "TBox Evaluation Tool" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-faf3-28ce-cca724db461f
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value '{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"
# Source step 0091: "Click Insurance Score Consent if available" in module "Policy Info|Insurance Score" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-62c0-b9ad-e9b0b9d872db
#    - INPUT "Insurance Score Consent" with "X"
#    - ACTION "IFRAME" with "a blank/null value"
#    - ACTION "IFRAME > Popup" with "a blank/null value"
#    - WAIT (Exists) "IFRAME > Popup > Accept" with "True"
#    - INPUT "IFRAME > Popup > Accept" with "X"
#    - WAIT (Exists) "Insurance Score" with "True"
# Source step 0092: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-6d8c-4d68-2f07c426a43c
#    - INPUT "Insurance Score" with "X"
# Source step 0093: "Insurance Score" in module "Policy Info|Insurance Score" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-dba3-ee02-3503baa413fb
#    - VERIFY (InnerText) "Reference Number" with "\"\""
# Source step 0094: "Wait 1/2 Second for a max of 60 seconds" in module "TBox Wait" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-4380-87c1-5285e9b2c0eb
#    - INPUT "Duration" with "500"
# Source step 0095: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available | 14.04.20 08:18:56 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-d800-16b1-204343afb7e1
#    - INPUT "Duration" with "1500"
# Source step 0096: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available | 14.04.20 08:18:24 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-06ca-978e-d5200f0622bb
#    - WAIT (Exists) "Insurance Score" with "False"
# Source step 0097: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available | 14.04.20 08:18:31 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3a41-fade-9ac567a11717
#    - INPUT "Duration" with "1500"
# Source step 0098: "Wait 1/2 Second" in module "TBox Wait" was disabled. Reason: 07.02.20 09:11:50 [ff00958]Insurance score button not yet available
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3c33-8cfc-5b97480b4dd3
#    - INPUT "Duration" with "500"
# Source step 0127: "Add ReferralMessage to TestData Repository" in module "Old_TestData - Expert module" was disabled. Reason: 04.03.21 06:06:41 [ff01620]
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Building Coverage > Common|General|UW Referral|Send Referral Message to TDS | Source XTestStep: 3a13d49c-165b-1398-b9d0-00c0d5947ae7
#    - INPUT "Test data task" with "Create"
#    - INPUT "Existing or new TDS type" with "Referral_Messages"
#    - ACTION "Data structure" with "a blank/null value"
#    - INPUT "Data structure > QuoteID" with "the RUNTIME-DERIVED source value {B[QuoteID]}"
#    - INPUT "Data structure > QuoteDescription" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}"
#    - INPUT "Data structure > Referral Text" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UW Referral>)"
# Source step 0163: "Add ReferralMessage to TestData Repository" in module "Old_TestData - Expert module" was disabled. Reason: 04.03.21 06:06:41 [ff01620]
# Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|470|Add Livestock - Specific Coverage > Common|General|UW Referral|Send Referral Message to TDS | Source XTestStep: 3a13d49c-165b-1398-b9d0-00c0d5947ae7
#    - INPUT "Test data task" with "Create"
#    - INPUT "Existing or new TDS type" with "Referral_Messages"
#    - ACTION "Data structure" with "a blank/null value"
#    - INPUT "Data structure > QuoteID" with "the RUNTIME-DERIVED source value {B[QuoteID]}"
#    - INPUT "Data structure > QuoteDescription" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}"
#    - INPUT "Data structure > Referral Text" with "If Suffocation of Livestock is selected for Specific Livestock and Farm Type is not Hog, Poultry, Turkey, or Duck, Underwriter Approval is required."
# Source step 0168: "Add ReferralMessage to TestData Repository" in module "Old_TestData - Expert module" was disabled. Reason: 04.03.21 06:06:41 [ff01620]
# Section: New Application - Data Entry Process > Division 3 | Reusable flow: SFP|Div 3|471|Add Livestock - Blanket Coverage > Common|General|UW Referral|Send Referral Message to TDS | Source XTestStep: 3a13d49c-165b-1398-b9d0-00c0d5947ae7
#    - INPUT "Test data task" with "Create"
#    - INPUT "Existing or new TDS type" with "Referral_Messages"
#    - ACTION "Data structure" with "a blank/null value"
#    - INPUT "Data structure > QuoteID" with "the RUNTIME-DERIVED source value {B[QuoteID]}"
#    - INPUT "Data structure > QuoteDescription" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}"
#    - INPUT "Data structure > Referral Text" with "If Suffocation of Livestock is selected for Blanket Livestock and Farm Type is not Hog, Poultry, Turkey, or Duck, Underwriter Approval is required."
# Source step 0288: "Find a Referral Message record" in module "Old_TestData - Find & provide item" was disabled. Reason: 17.03.21 08:02:20 [ff01620]
# Section: New Application - Data Entry Process > Find Record, Buffer the Message, Validate Message, Delete the Record > Find a record | Reusable flow: Common|General|UW Referral|Verify UW Referral Message on Submission Screen | Source XTestStep: 3a13d49c-165b-41b4-4bd6-0af77a9a054e
#    - INPUT "Existing TDS type" with "Referral_Messages"
#    - ACTION "Data search filter" with "a blank/null value"
#    - CONSTRAINT "Data search filter > QuoteID" with "the RUNTIME-DERIVED source value {B[QuoteID]}"
#    - CONSTRAINT "Data search filter > QuoteDescription" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}"
# Source step 0289: "Buffer the Referral Message" in module "TBox Set Buffer" was disabled. Reason: 17.03.21 08:02:20 [ff01620]
# Section: New Application - Data Entry Process > Find Record, Buffer the Message, Validate Message, Delete the Record > Buffer the Referral Message | Reusable flow: Common|General|UW Referral|Verify UW Referral Message on Submission Screen | Source XTestStep: 3a13d49c-165b-663d-f7ca-5b8c084d3591
#    - INPUT "Message" with "the RUNTIME-DERIVED source value {{tdm:Referral_Messages.Referral Text}}"
# Source step 0290: "Verify the Referral Message on the Screen" in module "Rating Message / Referral" was disabled. Reason: 17.03.21 08:02:20 [ff01620]
# Section: New Application - Data Entry Process > Find Record, Buffer the Message, Validate Message, Delete the Record > Verify the Referral Message on Submission Screen | Reusable flow: Common|General|UW Referral|Verify UW Referral Message on Submission Screen | Source XTestStep: 3a13d49c-165b-bcdd-fa0f-b5919748be28
#    - VERIFY (Exists) "LI" with "True"
# Source step 0291: "Delete the Referral Message record" in module "Old_TestData - Expert module" was disabled. Reason: 17.03.21 08:02:20 [ff01620]
# Section: New Application - Data Entry Process > Find Record, Buffer the Message, Validate Message, Delete the Record > Delete Record | Reusable flow: Common|General|UW Referral|Verify UW Referral Message on Submission Screen | Source XTestStep: 3a13d49c-165b-8962-37e0-b3beb2dd98b9
#    - INPUT "Test data task" with "DeleteItem"
#    - INPUT "Existing or new TDS type" with "Referral_Messages"
#    - INPUT "Alias name (item)" with "Referral_Messages"
#    - ACTION "Data structure" with "a blank/null value"
#    - CONSTRAINT "Data structure > QuoteID" with "the RUNTIME-DERIVED source value {B[QuoteID]}"
#    - CONSTRAINT "Data structure > QuoteDescription" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}"
#    - CONSTRAINT "Data structure > Referral Text" with "the RUNTIME-DERIVED source value {B[Message]}"
# Source step 0305: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0306: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0307: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "http://svdw-clas03:8080/express/"
#    - INPUT "UserName" with "AG09999"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0308: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0309: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0310: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0311: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0312: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0313: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0314: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0315: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0316: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0317: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0318: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "http://svdw-clas03:8080/express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0319: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0320: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0321: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0322: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0323: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0324: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0325: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0326: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0327: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0328: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0329: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0330: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0331: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0332: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG09999{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0333: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0334: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0335: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0336: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0337: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0338: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0339: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0340: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0341: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0342: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0343: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0344: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0345: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0346: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0347: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0365: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0366: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0367: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "http://svdw-clas03:8080/express/"
#    - INPUT "UserName" with "AG09999"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0368: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0369: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0370: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0371: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0372: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0373: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0374: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0375: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0376: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0377: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0378: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "http://svdw-clas03:8080/express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0379: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0380: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0381: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0382: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0383: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0384: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0385: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0386: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0387: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0388: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0389: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0390: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0391: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0392: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG09999{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0393: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0394: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0395: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "the source value not supplied by the exported iteration (<SOURCE VALUE NOT SUPPLIED BY EXPORTED ITERATION: Forms Set Up.FormDocPath>Screenshots)"
#    - INPUT "Filename" with "Login Error"
# Source step 0396: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "the source value not supplied by the exported iteration (<SOURCE VALUE NOT SUPPLIED BY EXPORTED ITERATION: Forms Set Up.FormDocPath>)"
# Source step 0397: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0398: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0399: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0400: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0401: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0402: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0403: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0404: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0405: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0406: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0407: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0416: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0417: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0418: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0419: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0427: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0428: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0429: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0430: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\SFP_StraightThrough_NV_{B[QuoteID]}.xml"
# Source step 0431: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\SFP_StraightThrough_NV_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0443: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Product:*" with "{CLICK}Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0){ENTER}{TAB}" when 'Product:*' != "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' != "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0075 "Enter Effective Date" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}" when 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL"
# Source step 0079: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Nevada{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Source step 0081: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Nevada{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Nevada{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Nevada{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Nevada{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Nevada{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP"
# Active source step 0100 "Enter Location Details" contains conditionally inapplicable field action(s):
#    - INPUT "Add Location" with "X" when Primary == "No". Reason: Value condition evaluated false for the selected iteration: Primary == "No"
# Active source step 0110 "Residence Detail" contains conditionally inapplicable field action(s):
#    - INPUT "Is the Solid Fuel Heating Device designed specifically for use in a Mobile Home?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Solid Fuel Heat Device for Mobile Home>{TAB})" when 'Solid Fuel Heat Device' == "Yes". Reason: Value condition evaluated false for the selected iteration: 'Solid Fuel Heat Device' == "Yes"
# Active source step 0112 "Residence Coverage Detail - Add Residence Covg" contains conditionally inapplicable field action(s):
#    - INPUT "Functional Replacement Limit*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Functional Replacement Cost>{TAB})" when 'Functional Replacement Cost' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Functional Replacement Cost' != NULL
# Active source step 0113 "SFP Residence Coverage Detail - RCT" contains conditionally inapplicable field action(s):
#    - INPUT "BVSSearchResult" with "2121 - Office, Low-Rise, Shell{TAB}" when 'SFP Estimator Type RCT/BVS' == "BVS". Reason: Value condition evaluated false for the selected iteration: 'SFP Estimator Type RCT/BVS' == "BVS"
# Active source step 0117 "Add Residence Optional Coverages" contains conditionally inapplicable field action(s):
#    - INPUT "Excess Computer Hardware Software - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Excess Computer Hardware Software". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Computer Hardware Software"
#    - VERIFY "Earthquake - Additional Limit*" with "10000" when 'Coverage Type' == "Earthquake". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Earthquake"
#    - WAIT (Exists) "Condominium Earthquake Loss Assessment" with "True" when 'Coverage Type' == "Condominium Earthquake Loss Assessment". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Condominium Earthquake Loss Assessment"
#    - VERIFY "Condominium Earthquake Loss Assessment - Additional Limit*" with "10000" when 'Coverage Type' == "Condominium Earthquake Loss Assessment". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Condominium Earthquake Loss Assessment"
#    - VERIFY "Sinkhole Collapse - Additional Limit*" with "10000" when 'Coverage Type' == "Sinkhole Collapse". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Sinkhole Collapse"
#    - INPUT "Excess Condominium Unit-owner Additions - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Excess Condominium Unit-owner Additions". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Condominium Unit-owner Additions"
#    - INPUT "Excess Outdoor Radio Satellite and Television Equipment- Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Excess Outdoor Radio Satellite and Television Equipment". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Outdoor Radio Satellite and Television Equipment"
#    - INPUT "Excess Motorized Vehicles - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Excess Motorized Vehicles". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Motorized Vehicles"
#    - INPUT "Condominium Loss Assessment - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Condominium Loss Assessment". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Condominium Loss Assessment"
#    - INPUT "Excess Business Property - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Excess Business Property". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Business Property"
#    - INPUT "Operations Records - Deductible" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Deductible>{TAB})" when 'Coverage Type' == "Operations Records". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Operations Records"
#    - INPUT "Operations Records - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Operations Records". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Operations Records"
#    - VERIFY "Water Damage - Backup of Sewers Drains and Sumps - Additional Limit*" with "10000" when 'Coverage Type' == "Water Damage - Backup of Sewers Drains and Sumps". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Water Damage - Backup of Sewers Drains and Sumps"
#    - VERIFY "Excess Money - Additional Limit*" with "10000" when 'Coverage Type' == "Excess Money". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Money"
#    - VERIFY "Excess Securities - Additional Limit*" with "10000" when 'Coverage Type' == "Excess Securities". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Securities"
#    - VERIFY "Excess Jewelry and Furs - Additional Limit*" with "10000" when 'Coverage Type' == "Excess Jewelry and Furs". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Jewelry and Furs"
# Active source step 0125 "Building/Contents - Add Building Covg" contains conditionally inapplicable field action(s):
#    - INPUT "Plastic Covered Greenhouse Thickness (mils)" with "3{TAB}" when 'Coverage Code' == "Greenhouse". Reason: Value condition evaluated false for the selected iteration: 'Coverage Code' == "Greenhouse"
#    - INPUT "Date Installed*" with "the RUNTIME-DERIVED source value {DATE[][-1y][MM/dd/yyyy]}{TAB}" when 'Coverage Code' == "Greenhouse". Reason: Value condition evaluated false for the selected iteration: 'Coverage Code' == "Greenhouse"
# Source step 0126: "Increase ReferralCounter Buffer" in module "TBox Set Buffer" was not executed. Reason: Selected-iteration condition evaluated false: 'UW Referral' != Null
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Building Coverage > Common|General|UW Referral|Send Referral Message to TDS | Source XTestStep: 3a13d49c-165b-8367-098b-19069cf4339f
#    - Preserved source field action: INPUT "ReferralCounter" with "the RUNTIME-DERIVED source value {MATH[{B[ReferralCounter]}+1]}"
# Active source step 0129 "Building/Contents - Add Contents" contains conditionally inapplicable field action(s):
#    - INPUT "Suffocation" with "Yes{TAB}{TAB}{TAB}" when 'Coverage Code' == "Poultry Contents". Reason: Value condition evaluated false for the selected iteration: 'Coverage Code' == "Poultry Contents"
#    - INPUT "NumberOfBirds" with "{Click}{TAB}" when 'Coverage Code' == "Poultry Contents". Reason: Value condition evaluated false for the selected iteration: 'Coverage Code' == "Poultry Contents"
#    - INPUT "PoultrySchedule" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Poultry Schedule>{TAB}{CLICK}{TAB})" when 'Coverage Code' == "Poultry Contents". Reason: Value condition evaluated false for the selected iteration: 'Coverage Code' == "Poultry Contents"
# Source step 0130: "Wait for Poultry Synching" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Coverage Code' == "Poultry Contents"
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-aac8-8e6b-3f2561353a38
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0133: "Building/Contents - Add Contents - Synching Poultry Limit" in module "Building/Contents - Add Contents" was not executed. Reason: Selected-iteration condition evaluated false: 'Coverage Code' == "Poultry Contents"
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-09d8-7815-cf9e0e77029a
#    - Preserved source field action: INPUT "NumberOfBirds" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Number of Birds>{TAB}{CLICK}{TAB}{TAB})" when 'Coverage Code' == "Poultry Contents"
# Source step 0134: "Wait for Poultry Synching" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Coverage Code' == "Poultry Contents"
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-91ea-d28c-bda41f3f8acc
#    - Preserved source field action: INPUT "Duration" with "5000"
# Source step 0137: "Building/Contents - Add Contents - Synching Poultry Limit" in module "Building/Contents - Add Contents" was not executed. Reason: Selected-iteration condition evaluated false: 'Coverage Code' == "Poultry Contents"
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-5310-1231-d14737ec572a
#    - Preserved source field action: INPUT "Description" with "{CLICK}{TAB}"
# Source step 0138: "Wait for Poultry Synching" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Coverage Code' == "Poultry Contents"
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-1ce7-e3d7-84e4793f026e
#    - Preserved source field action: INPUT "Duration" with "4000"
# Source step 0141: "Building/Contents - Add Contents - Synching Poultry Limit" in module "Building/Contents - Add Contents" was not executed. Reason: Selected-iteration condition evaluated false: 'Coverage Code' == "Poultry Contents"
# Section: New Application - Data Entry Process > Division 2 | Reusable flow: SFP|Div 2|Building/Contents - Add Contents | Source XTestStep: 3a13d49c-166a-c6d0-2d2e-c9f36f3aacec
#    - Preserved source field action: INPUT "Amount of Insurance*" with "{Click}"
#    - Preserved source field action: INPUT "Amount of Insurance*" with "{TAB}"
#    - Preserved source field action: WAIT (InnerText) "Amount of Insurance*" with "Null"
#    - Preserved source field action: INPUT "Suffocation" with "{TAB}"
# Active source step 0143 "Building Optional Coverages" contains conditionally inapplicable field action(s):
#    - INPUT "On and Off Premises Power Interruption - Deductible" with "500{TAB}" when 'Coverage Type' == "On and Off Premises Power Interruption". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "On and Off Premises Power Interruption"
#    - INPUT "On and Off Premises Power Interruption - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "On and Off Premises Power Interruption". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "On and Off Premises Power Interruption"
#    - INPUT "Operations Records - Deductible" with "500{TAB}" when 'Coverage Type' == "Operations Records". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Operations Records"
#    - INPUT "Operations Records - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Operations Records". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Operations Records"
#    - INPUT "Poultry Income Loss - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Poultry Income Loss". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Poultry Income Loss"
#    - INPUT "Livestock Loss of Value - # of Livestock*" with "10{TAB}" when 'Coverage Type'=="Livestock - Loss of Value". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type'=="Livestock - Loss of Value"
#    - INPUT "Livestock Loss of Value - Limit Per Livestock*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Limit Per Livestock>{ENTER}{TAB}{TAB})" when 'Coverage Type' == "Livestock - Loss of Value". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Livestock - Loss of Value"
#    - VERIFY (Exists) "Livestock Loss of Value - Livestock Limit (ReadOnly)" with "True" when 'Coverage Type'=="Livestock - Loss of Value". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type'=="Livestock - Loss of Value"
#    - INPUT "Earthquake - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Earthquake". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Earthquake"
#    - INPUT "Loss by Fire/Theft of Money Checks - On Premises (A) - Deductible" with "500{TAB}" when 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On Premises (A)". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On Premises (A)"
#    - INPUT "Loss by Fire/Theft of Money Checks - On Premises (A) - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On Premises (A)". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On Premises (A)"
#    - INPUT "Loss by Fire/Theft of Money Checks - On and Off Premises (B) - Deductible" with "500{TAB}" when 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On and Off Premises (B)". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On and Off Premises (B)"
#    - INPUT "Loss by Fire/Theft of Money Checks - On and Off Premises (B) - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On and Off Premises (B)". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Loss by Fire/Theft of Money Checks - On and Off Premises (B)"
#    - INPUT "Business Property Temporarily Removed From A Building - Deductible" with "500{TAB}" when 'Coverage Type' == "Business Property Temporarily Removed From A Building". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Business Property Temporarily Removed From A Building"
#    - INPUT "Business Property Temporarily Removed From A Building - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Business Property Temporarily Removed From A Building". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Business Property Temporarily Removed From A Building"
#    - INPUT "Excess Property Temporarily Removed From a Building - Deductible" with "500{TAB}" when 'Coverage Type' == "Excess Property Temporarily Removed From a Building". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Property Temporarily Removed From a Building"
#    - INPUT "Excess Property Temporarily Removed From a Building - Additional Limit*" with "10000{TAB}" when 'Coverage Type' == "Excess Property Temporarily Removed From a Building". Reason: Value condition evaluated false for the selected iteration: 'Coverage Type' == "Excess Property Temporarily Removed From a Building"
# Active source step 0188 "Add Nursery and Greenhouse Plants" contains conditionally inapplicable field action(s):
#    - INPUT "May $" with "0{TAB}" when May != 0. Reason: Value condition evaluated false for the selected iteration: May != 0
#    - INPUT "June $" with "0{TAB}" when June != 0. Reason: Value condition evaluated false for the selected iteration: June != 0
#    - INPUT "July $" with "0{TAB}" when July != 0. Reason: Value condition evaluated false for the selected iteration: July != 0
#    - INPUT "August $" with "0{TAB}" when August != 0. Reason: Value condition evaluated false for the selected iteration: August != 0
#    - INPUT "September $" with "0{TAB}" when September != 0. Reason: Value condition evaluated false for the selected iteration: September != 0
# Active source step 0195 "Add PAC - Crops, Feed, Supplies, etc." contains conditionally inapplicable field action(s):
#    - INPUT "May" with "0{TAB}" when May != 0. Reason: Value condition evaluated false for the selected iteration: May != 0
#    - INPUT "June" with "0{TAB}" when June != 0. Reason: Value condition evaluated false for the selected iteration: June != 0
#    - INPUT "July" with "0{TAB}" when July != 0. Reason: Value condition evaluated false for the selected iteration: July != 0
#    - INPUT "August" with "0{TAB}" when August != 0. Reason: Value condition evaluated false for the selected iteration: August != 0
#    - INPUT "September" with "0{TAB}" when September != 0. Reason: Value condition evaluated false for the selected iteration: September != 0
# Active source step 0200 "Add PAC - Hay, Grain, Straw, and Fodder" contains conditionally inapplicable field action(s):
#    - INPUT "May" with "0{TAB}" when May != 0. Reason: Value condition evaluated false for the selected iteration: May != 0
#    - INPUT "June" with "0{TAB}" when June != 0. Reason: Value condition evaluated false for the selected iteration: June != 0
#    - INPUT "July" with "0{TAB}" when July != 0. Reason: Value condition evaluated false for the selected iteration: July != 0
#    - INPUT "August" with "0{TAB}" when August != 0. Reason: Value condition evaluated false for the selected iteration: August != 0
#    - INPUT "September" with "0{TAB}" when September != 0. Reason: Value condition evaluated false for the selected iteration: September != 0
# Source step 0354: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0355: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0356: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14d5-03e2-5213-724ae53b348e
#    - I capture a "Desktop" screenshot at "P:\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\SFP\\SFP StraightThrough Test Case"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14d5-13f5-f723-13f60bde821a
#    - I capture a "Desktop" screenshot at "P:\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\SFP\\SFP StraightThrough TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14d5-5681-f21b-c9a125dd4f83
#    - I capture a "Desktop" screenshot at "P:\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\SFP\\SFP StraightThrough TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14d5-8cc4-3982-2cd356406a2a
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14d5-86ae-771d-9fa235ed1b75
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14d5-860b-d288-e71eb5c24f1d
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14d5-a17b-59c4-f6d7a8d82532
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14d5-6487-7d9e-9d7bda3605b5
#    - I run "taskkill /f /im msEdge.exe"
