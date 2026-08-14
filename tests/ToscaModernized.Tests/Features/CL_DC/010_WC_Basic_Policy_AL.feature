# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 010_WC_Basic_Policy_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @WC @basic_policy @Alabama @Edge @manual @automated
Feature: Execute WC | Basic Policy for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the WC | Basic Policy workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: WC | Basic Policy using representative iteration Alabama (AL)

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
    When I enter or select "AL WC Testing, Inc.{TAB}" in "Business Name"

    # Source step 0041: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-e0be-7cfd-4133e268b3f9
    When I enter or select "Corporation{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I perform keyboard action "{TAB}" on "Address1"
    When I enter or select "{TAB}35661{TAB}" in "ZipCode"
    When I enter or select "1918 Avalon Ave{TAB}" in "Address1"

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
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "WC" as runtime value "Product (LOB)"
    When I retain hard-coded value "WC_BASIC" as runtime value "FormOnPolicyDocName"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"

    # Source step 0048: Add a new Associated Client - Business Owner Type - Click Add Client | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-7d35-2fd8-87d9efebb312
    # Source template XTestStep: 3a13d49c-165b-ce02-83cf-cd6904f97e54
    Then I wait until "Add Client" exists
    When I perform keyboard action "{TAB}" on "Add Client"
    When I click or select "Add Client"

    # Source step 0049: Check if IndividualType Exists | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-3876-52be-0b3ec844a96f
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
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-0327-70a2-1e06dc29e270
    # Source template XTestStep: 3a13d49c-165b-71c5-b893-c4235f3b547a
    When I enter or select "{TAB}{CLICK}Business Owner{TAB}" in "IndividualType"
    Then I wait until "Please verify SSN*" exists

    # Source step 0057: Enter Client Details | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-dec2-067f-22c23929720f
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
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-caaf-3a79-e7d457d6ef0f
    # Source template XTestStep: 3a13d49c-165b-32d5-f6ed-f265f9f9c6c8
    Then "Search Results > Duck Creek Policy > First Checkbox" should not exist
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0059: Order and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-e366-8ee3-15666da83e2e
    # Source template XTestStep: 3a13d49c-165b-2f1c-c197-ca3b93b64298
    When I click or select "Order SSN"
    When I perform keyboard action "{TAB}" on "Enter SSN*"
    When I enter or select "{TAB}736849971{TAB}" in "Enter SSN*"
    When I click or select "Enter SSN*"

    # Source step 0060: Does Verify Exist | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-f5c7-3a14-f8db14afa67a
    # Source template XTestStep: 3a13d49c-165b-ba0f-6727-be7d60a0ce09
    # Runtime control: If Verify does not exist > Condition
    Then "Verify" should not exist

    # Source step 0061: Click Complete | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-03ab-3e71-1c065ed573fb
    # Source template XTestStep: 3a13d49c-165b-95b2-6c84-0c54eb4a6437
    # Runtime control: If Verify does not exist > Then
    When I click or select "Complete"

    # Source step 0062: Click Detail and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-a42a-69ec-23026eec8f78
    # Source template XTestStep: 3a13d49c-165b-6230-e27e-9c3d0e9cbe27
    # Runtime control: If Verify does not exist > Then
    When I click or select "Detail"
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0063: Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-30d2-bbf2-a9bc2b2c968f
    # Source template XTestStep: 3a13d49c-165b-de87-4c4c-3c66d28b8da1
    # Runtime control: If Verify does not exist > Else
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0064: Perform Final Client Search | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-dfe2-7a8d-3ed40e5682fb
    # Source template XTestStep: 3a13d49c-165b-f6d6-53ae-4d4d2d531699
    Then I wait until "Client Search" exists
    When I click or select "Client Search"

    # Source step 0065: Click Ok | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-eb15-40f1-348d248d2dee
    # Source template XTestStep: 3a13d49c-165b-647c-ba91-85bcca049803
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"
    Then I wait until "Client Search" no longer exists

    # Source step 0066: Navigate to Underwriting Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-9b6f-39ea-ffe1fae93247
    # Source template XTestStep: 3a13d49c-165b-9ab4-0c96-7dae4d962d1c
    When I click or select "Underwriting Info"

    # Source step 0067: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-e705-012f-cddf938ff618
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

    # Source step 0068: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-7c42-5006-6b2cf4c81a69
    # Source template XTestStep: 3a13d49c-165b-7e70-d439-607c40156454
    When I click or select "Loss Experience"
    Then I wait until "No known losses" exists
    When I enter or select "True{TAB}" in "No known losses"

    # Source step 0069: Click Return to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-d127-d978-b74c0597a48a
    # Source template XTestStep: 3a13d49c-165b-b5c9-40b3-036c7fb8da80
    When I click or select "Return to Quote"

    # Source step 0070: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0071: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0072: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0073: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0074: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "07-01-2026{TAB}" in "EffectiveDate"

    # Source step 0075: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0076: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0077: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0079: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0081: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0082: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0083: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0084: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL WC Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0087: Policy Info | WC Specific Fields | Module: Policy Info|WC Specific Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Fill Out WC Specific Fields | Source XTestStep: 3a13d49c-165b-3baf-6162-78d1ff47073c
    When I enter or select "{CLICK}Yes{ENTER}{TAB}" in "Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?*"

    # Source step 0088: Policy Info | Estimated Premium | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Fill Out Estimated Premium | Source XTestStep: 3a13d49c-165b-65a9-4b10-5278a85a5e32
    Then if field condition "'Estimated Premium' == NULL" is satisfied, "Estimated Premium*" should not exist

    # Source step 0089: Navigate to Policy Covg Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Policy Covg|Coverage Information | Source XTestStep: 3a13d49c-1679-8979-e3c1-b54df1772c6c
    When I click or select "Policy Covg"

    # Source step 0090: Policy Covg | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: WC|Policy Covg|Coverage Information | Source XTestStep: 3a13d49c-1679-cf48-6712-a62ee1054e64
    Then I wait until "Primary Location State*" exists
    Then "Primary Location State*" property "value" should equals "{REGEX[\"(?i)\"Alabama]}"
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Experience Rated"
    When I capture "Default Experience Mod" as runtime value "ExpMod"

    # Source step 0091: Navigate to Location Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Location|Fill Out Address 1 | Source XTestStep: 3a13d49c-1679-d376-1ab8-d9deb7f9ef0b
    When I click or select "Location"

    # Source step 0092: Location | Module: Location
    # Section: New Application - Data Entry Process | Reusable flow: WC|Location|Fill Out Address 1 | Source XTestStep: 3a13d49c-1679-ea8f-b5dd-712fa80abd05
    Then I wait until "Address1" exists
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"
    When I click or select "OK"

    # Source step 0093: Navigate to State Details Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-70f6-c9b1-3f76a0911180
    When I click or select "State Details"

    # Source step 0094: State Details - Main Questions | Module: State Details|Main
    # Section: New Application - Data Entry Process | Reusable flow: WC|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-8140-5961-7421dd5fcdd4
    Then I wait until "Intrastate Risk ID" exists

    # Source step 0095: Navigate to WC Schedule | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-a7a5-a49c-3a3156eec709
    When I click or select "WC Schedule"

    # Source step 0096: Add First Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-6cb1-3520-6bb7bf258836
    Then I wait until "Add Class Code" exists
    When I click or select "Add Class Code"

    # Source step 0097: Loop while OK Button does not exist | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-cfa5-2a08-682647734593
    # Runtime control: Do Loop for First Class Code [max=45] > Condition
    Then "Class Code Frame > Class Code Window > OK-Class Code" should not exist

    # Source step 0098: Loop for First Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-cdfc-183c-b9a3eb38cfdb
    # Runtime control: Do Loop for First Class Code [max=45] > Loop
    Then I wait until "Class Code Frame > Class Code Window > SearchValue" exists
    When I enter or select "LANDSCAPE GARDENING AND DRIVERS (0042){TAB}" in "Class Code Frame > Class Code Window > SearchValue"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > SearchValue"
    When I enter or select "LANDSCAPE GARDENING AND DRIVERS (0042){ENTER}{TAB}{CLICK}{TAB}{TAB}" in "Class Code Frame > Class Code Window > Select Class Code*"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > Select Class Code*"

    # Source step 0099: TBox Wait | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-045c-550c-b3f6576009b8
    # Runtime control: Do Loop for First Class Code [max=45] > Loop
    When I wait "3000" milliseconds

    # Source step 0100: Input First Class Code Details | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-d7a0-045a-7fd3e91a595b
    Then "Class Code Frame > Class Code Window > Select Class Code*" property "value" should equals "LANDSCAPE GARDENING AND DRIVERS (0042)"
    Then I wait until "Class Code Frame > Class Code Window > OK-Class Code" exists
    When I click or select "Class Code Frame > Class Code Window > OK-Class Code"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > Total Payroll (Estimated)"
    When if field condition "State != \"MD\"" is satisfied, I enter or select "{TAB}{CLICK}100000{TAB}" in "Class Code Frame > Class Code Window > Total Payroll (Estimated)"
    When I enter or select "{TAB}{CLICK}3{TAB}" in "Class Code Frame > Class Code Window > Number of Part-Time Employees*"
    When I enter or select "{TAB}{CLICK}2{TAB}" in "Class Code Frame > Class Code Window > Number of Full-Time Employees*"
    When I click or select "Class Code Frame > Class Code Window > OK-Details"
    Then I wait until "Class Code Frame" no longer exists

    # Source step 0101: Add Second Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-ab1e-536f-65df0323656e
    Then I wait until "Add Class Code" exists
    When I click or select "Add Class Code"

    # Source step 0102: Loop while OK Button does not exist | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-3270-786f-6a1d91b118f4
    # Runtime control: Do Loop for Second Class Code [max=45] > Condition
    Then "Class Code Frame > Class Code Window > OK-Class Code" should not exist

    # Source step 0103: Loop for Second Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-bf25-c796-3e1a7adb6a0b
    # Runtime control: Do Loop for Second Class Code [max=45] > Loop
    Then I wait until "Class Code Frame > Class Code Window > SearchValue" exists
    When I leave "Class Code Frame > Class Code Window > SearchValue" blank
    When I enter or select "MASONRY NOC (5022){TAB}" in "Class Code Frame > Class Code Window > SearchValue"
    When I enter or select "MASONRY NOC (5022){ENTER}{TAB}{CLICK}{TAB}{TAB}" in "Class Code Frame > Class Code Window > Select Class Code*"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > Select Class Code*"

    # Source step 0104: TBox Wait | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-8a4c-056a-bbf5b72ac293
    # Runtime control: Do Loop for Second Class Code [max=45] > Loop
    When I wait "3000" milliseconds

    # Source step 0105: Input Second Class Code Details | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-004e-3d1e-668797414566
    Then "Class Code Frame > Class Code Window > Select Class Code*" property "value" should equals "MASONRY NOC (5022)"
    Then I wait until "Class Code Frame > Class Code Window > OK-Class Code" exists
    When I click or select "Class Code Frame > Class Code Window > OK-Class Code"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > Total Payroll (Estimated)"
    When I enter or select "{CLICK}80000{TAB}" in "Class Code Frame > Class Code Window > Total Payroll (Estimated)"
    When I enter or select "{TAB}{CLICK}4{TAB}" in "Class Code Frame > Class Code Window > Number of Part-Time Employees*"
    When I enter or select "{TAB}{CLICK}1{TAB}" in "Class Code Frame > Class Code Window > Number of Full-Time Employees*"
    When I click or select "Class Code Frame > Class Code Window > OK-Details"
    Then I wait until "Class Code Frame" no longer exists

    # Source step 0106: Navigate to Entity Schedule | Module: WC Navigation Links
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-8ead-fd12-97f51c86eeb6
    # Source template XTestStep: 3a13d49c-1679-57cd-6a00-b07ca9c70ae1
    When I click or select "Entity Schedule"

    # Source step 0107: Wait for sync | Module: Entity Schedule|Main
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-3d05-6daa-ba46e5ffda6e
    # Source template XTestStep: 3a13d49c-1679-a6d9-50d8-18b4879fb356
    Then I wait until "Entity Schedule" exists

    # Source step 0109: Enter First Entity Info | Module: Entity Schedule|First Entity Info
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-b424-d38c-607fa0afa9b0
    # Source template XTestStep: 3a13d49c-1679-012e-30b1-5c559463003a
    When I click or select "Detail"
    Then I wait until "Entity Info Frame > Entity Info Window > Insured Type" exists
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Entity Info Frame > Entity Info Window > Fax"
    When I enter or select "Test@test.com" in "Entity Info Frame > Entity Info Window > E-Mail"
    When I enter a RANDOM value matching "7 random digits/characters from source expression {RND[7]}{TAB}" in "Entity Info Frame > Entity Info Window > Bureau Number"
    When I enter a RANDOM value matching "6 random digits/characters from source expression {RND[6]}{TAB}" in "Entity Info Frame > Entity Info Window > State Unemployment Number Default"
    When I click or select "Entity Info Frame > Entity Info Window > OK"
    Then I wait until "Entity Info Frame" no longer exists

    # Source step 0110: Enter Location Assignment (up to NAICS) | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-994e-e8a5-7e4c585699d9
    # Source template XTestStep: 3a13d49c-1679-76c8-6e9c-36379c2139d8
    Then I wait until "Assign Locations" exists
    When I click or select "Assign Locations"
    Then I wait until "Location Assignment > Entity Location > Assign Location" exists
    When I click or select "Location Assignment > Entity Location > Assign Location"
    Then I wait until "Location Assignment > Entity Location > LocationID" exists
    When I enter or select "Primary Location{TAB}{ENTER}{TAB}{TAB}" in "Location Assignment > Entity Location > LocationID"
    When I click or select "Location Assignment > Entity Location > LocationID"
    When I enter or select "Primary Location{TAB}{ENTER}{TAB}{TAB}" in "Location Assignment > Entity Location > LocationID"
    Then "Location Assignment > Entity Location > LocationID" property "Value" should equals "Primary Location*"
    When I click or select "Location Assignment > Entity Location > Select NAICS Code"
    Then I wait until "Location Assignment > Entity Location > NAICSCodeSearchValue" exists
    When I perform keyboard action "{TAB}" on "Location Assignment > Entity Location > NAICSCodeSearchValue"
    When I enter or select "{CLICK}Testing Laboratories [541380]{TAB}{TAB}" in "Location Assignment > Entity Location > NAICSCodeSearchValue"
    When I click or select "Location Assignment > Entity Location > NAICSCodeSearchValue"
    When I perform keyboard action "{TAB}" on "Location Assignment > Entity Location > Select Appropriate Code"
    When I enter or select "{CLICK}Testing Laboratories [541380]{TAB}{TAB}{Click}{TAB}{TAB}{TAB}" in "Location Assignment > Entity Location > Select Appropriate Code"

    # Source step 0111: NAICS is (select) | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-550a-0e63-c20dc1874c26
    # Source template XTestStep: 3a13d49c-1679-e01e-7adf-1214ac72446f
    # Runtime control: If NAICS is (select) then reselect > check if NAICS is (select)
    Then "Location Assignment > Entity Location > Select Appropriate Code" property "value" should equals "(select)"
    Then I wait until "Location Assignment" no longer exists

    # Source step 0112: Enter Location Assignment | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-69a2-23bf-0f9a44a3fe48
    # Source template XTestStep: 3a13d49c-1679-1a32-14ab-7c5b432f2c79
    # Runtime control: If NAICS is (select) then reselect > Then
    When I enter or select "{CLICK}Testing Laboratories [541380]{TAB}{TAB}{Click}{TAB}{TAB}{TAB}" in "Location Assignment > Entity Location > Select Appropriate Code"
    Then "Location Assignment > Entity Location > Select Appropriate Code" property "value" should equals "{CLICK}Testing Laboratories [541380]"
    Then I wait until "Location Assignment" no longer exists

    # Source step 0113: Enter Location Assignment (after NAICS) | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-67c8-44e2-6801e494270b
    # Source template XTestStep: 3a13d49c-1679-c3e3-26cf-04fcb8073436
    Then "Location Assignment > Entity Location > Select Appropriate Code" property "value" should equals "Testing Laboratories [541380]"
    When I enter or select "X{TAB}{TAB}" in "Location Assignment > Entity Location > OK (First)"
    Then I wait until "Location Assignment > Entity Location > OK (Second)" no longer exists
    When I click or select "Location Assignment > Entity Location > OK"
    Then I wait until "Location Assignment" no longer exists

    # Source step 0114: Navigate to Endorsements Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Endorsements | Source XTestStep: 3a13d49c-1679-6b1b-2b0b-8ec18fd09f0b
    When I click or select "Endorsements"

    # Source step 0115: Endorsements - Waiton Add Endorsement Button | Module: Endorsements|Waiton Add Endorsement Button
    # Section: New Application - Data Entry Process | Reusable flow: WC|Endorsements | Source XTestStep: 3a13d49c-1679-59ff-a896-7b60f338659f
    Then I wait until "Add Endorsement" exists

    # Source step 0116: Navigate to UW Questions - Workers Comp Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|UW Questions|Fill Out WC UW Questions | Source XTestStep: 3a13d49c-1679-539e-f03a-b5fc6644e1ab
    When I click or select "UW Questions - Workers Comp"

    # Source step 0117: Fill Out Required Fields | Module: UW Questions - Workers Comp
    # Section: New Application - Data Entry Process | Reusable flow: WC|UW Questions|Fill Out WC UW Questions | Source XTestStep: 3a13d49c-1679-5d29-a810-d34320e76758
    Then I wait until "Update Answers" exists
    When I perform keyboard action "{TAB}" on "Update Answers"
    When I click or select "Update Answers"
    Then I wait until "Are physicals required after offers of employment are made?*" property "InnerText" does not equal "\"(select)\""
    When I perform keyboard action "{TAB}" on "List all policies with American National"
    When I enter or select "{TAB}{CLICK}{CLICK}9999W9999{TAB}{TAB}" in "List all policies with American National"

    # Source step 0118: Navigate to Pricing Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-8672-69c9-1a7517673c1d
    When I click or select "Pricing"

    # Source step 0119: Wait for Pricing Screen to Load | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-9a9f-414a-1ab3569336d7
    Then I wait until "Pricing Detail" exists

    # Source step 0120: Go to Pricing Detail (necessary for refresh premium issue) | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-bedb-ad8b-19abc9edc4f6
    When I click or select "Pricing Detail"
    When I click or select "Pricing Detail - OK"

    # Source step 0121: Wait for Pricing Screen to Load | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-e153-8e95-d4e1ecb6316e
    Then I wait until "Pricing Detail" exists

    # Source step 0122: Verify Invalid Class Codes Message Does not Exist | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Verify Class Codes on Policy are Valid | Source XTestStep: 3a13d49c-1679-1e7d-effd-fbc9b4977a71
    Then "Invalid Class Code Message" should not exist

    # Source step 0123: Verify Premium | Module: Pricing
    # Section: New Application - Data Entry Process > WC|Pricing|Verify Premium_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-865e-a5f1-077b739dc550
    # Source template XTestStep: 3a13d49c-1679-23ca-a783-3b43332f6399
    Then "Premium" property "value" should equals "*$8,497.00"

    # Source step 0124: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0125: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0126: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0127: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0128: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0129: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0130: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0131: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0132: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0133: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0134: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0135: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0136: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0137: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0138: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0139: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0140: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0141: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0142: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0143: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0144: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0145: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0189: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0190: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0191: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0192: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0193: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0194: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0198: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0199: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0200: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0201: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0202: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0203: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0204: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0205: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0249: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0250: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0251: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0252: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0253: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0254: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0255: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0256: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0270: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "8,497.00" as runtime value "NBPrem"

    # Source step 0271: Verify Premiums | Module: Submission|Premiums
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "*$8,497.00"
    Then "Premium Written" property "value" should equals "8,497.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "8,497.00"

    # Source step 0272: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0273: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0274: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0275: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0276: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0277: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0278: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\WC_BASIC_AL_{B[QuoteID]}.xml"

    # Source step 0284: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0285: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\\" -FileName \"WC_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0286: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0287: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0288: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0289: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0290: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0291: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0292: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0293: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0294: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0296: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0297: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0298: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0299: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0300: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0085: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0086: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0108: "Click Valen Score and Wait for sync" in module "Entity Schedule|Main" was disabled. Reason: Valen Contract ends 3/1/2021
# Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-155c-f878-467f-2ab6f14f8dd2
#    - WAIT (Exists) "Get Valen Score" with "True"
#    - INPUT "Get Valen Score" with "X"
#    - WAIT (InnerText) "Score ID" with "a blank/null value"
#    - VERIFY (InnerText) "Bin #" with "a blank/null value"
#    - VERIFY (Exists) "Get Valen Score button must be selected to continue.*" with "False"
# Source step 0146: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0147: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0148: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0149: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0150: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0151: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0152: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0153: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0154: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0155: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0156: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0157: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0158: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0159: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0160: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0161: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0162: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0163: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0164: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0165: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0166: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0167: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0168: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0169: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0170: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0171: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0172: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0173: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0174: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0175: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0176: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0177: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0178: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0179: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0180: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0181: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0182: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0183: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0184: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0185: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0186: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0187: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0188: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0206: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0207: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0208: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0209: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0210: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0211: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0212: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0213: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0214: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0215: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0216: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0217: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0218: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0219: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0220: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0221: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0222: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0223: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0224: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0225: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0226: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0227: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0228: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0229: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0230: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0231: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0232: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0233: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0234: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0235: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0236: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0237: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\"
# Source step 0238: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0239: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0240: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0241: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0242: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0243: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0244: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0245: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0246: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0247: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0248: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0257: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0258: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0259: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0260: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0261: "Submission, select Policy Forms" in module "Submission, select Policy Forms" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-b954-0a7c-e98a92e77430
#    - INPUT "Policy Forms" with "x"
#    - WAIT (Exists) "Search" with "True"
#    - INPUT "Search for DEC Page" with "Declaration"
#    - INPUT "Search Button for DEC Page" with "x"
#    - INPUT "DEC LINK" with "x"
# Source step 0262: "Wait for Policy Forms to open" in module "TBox Wait" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8889-6242-e08fb28d4f40
#    - INPUT "Duration" with "9000"
# Source step 0263: "Close Policy Forms" in module "TBox Send Keys" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-582d-aae0-ba158c28662e
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0264: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-9a96-581e-d2b119b0020a
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0265: "Return to Submission Page" in module "Common Navigation Links" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8902-2720-581821968d05
#    - INPUT "Return to Policy" with "x"
# Source step 0266: "Submission, select Policy Admin Forms" in module "Submission, select Policy Forms" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-dcfb-265b-775fb7492386
#    - WAIT (Visible) "Policy Admin Forms" with "True"
#    - INPUT "Policy Admin Forms" with "x"
# Source step 0267: "Wait for Policy Admin Forms to open" in module "TBox Wait" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-5130-737f-d02663cba9f8
#    - INPUT "Duration" with "15000"
# Source step 0268: "Close Policy Admin Forms" in module "TBox Send Keys" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-c820-c654-7878ba2a4c1c
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0269: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 10.09.19 14:43:29 [ff00958]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-a6a9-8ecd-59b80f1bea38
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0279: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0280: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0281: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0282: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\WC_BASIC_AL_{B[QuoteID]}.xml"
# Source step 0283: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\WC_BASIC_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0295: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  WorkersCompensation  Pages   US   (9.8.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0074 "Enter Effective Date" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}" when 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL"
# Active source step 0076 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "{Click}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
# Source step 0078: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Source step 0080: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP"
# Active source step 0082 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "PrimaryRatingState" with "True" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0087 "Policy Info | WC Specific Fields" contains conditionally inapplicable field action(s):
#    - INPUT "Does applicant have a commitment to Workplace Safety and Risk Management?*" with "{CLICK}Yes{ENTER}{TAB}" when 'Workplace Saftey Question' == "Applies". Reason: Value condition evaluated false for the selected iteration: 'Workplace Saftey Question' == "Applies"
# Active source step 0088 "Policy Info | Estimated Premium" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "Estimated Premium*" with "True" when 'Estimated Premium' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Estimated Premium' != NULL
#    - INPUT "Estimated Premium*" with "Over{ENTER}{TAB}" when 'Estimated Premium' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Estimated Premium' != NULL
# Active source step 0100 "Input First Class Code Details" contains conditionally inapplicable field action(s):
#    - INPUT "Class Code Frame > Class Code Window > Total Payroll (Estimated)" with "{TAB}{CLICK}500000{TAB}" when State == "MD". Reason: Value condition evaluated false for the selected iteration: State == "MD"
# Active source step 0115 "Endorsements - Waiton Add Endorsement Button" contains conditionally inapplicable field action(s):
#    - INPUT "Are there any Officers that should be excluded?*" with "{TAB}{CLICK}No{TAB}" when State == "NY". Reason: Value condition evaluated false for the selected iteration: State == "NY"
# Source step 0195: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0196: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0197: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-155c-8273-9010-1a2b0f519c73
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\WC\\WCBASICTestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-155c-ea61-5f16-991cbc7e2810
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\WC\\WC BASIC TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-155c-3b4f-7fdb-009daa728b90
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\WC\\WC BASIC TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-155c-24d5-292c-6d9ee0d313f4
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-155c-24e8-1769-31f7064d0902
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-155c-ec82-3bae-ffa7a983510e
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-155c-656e-cfc9-2c5a05eec486
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-155c-e177-ba8a-95dbfa716c5a
#    - I run "taskkill /f /im msEdge.exe"
