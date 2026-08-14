# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 008_UMB_Basic_Policy_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @UMB @basic_policy @Alabama @Edge @manual @automated
Feature: Execute UMB | Basic Policy for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the UMB | Basic Policy workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: UMB | Basic Policy using representative iteration Alabama (AL)

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
    When I enter or select "AL UMB Testing, Inc.{TAB}" in "Business Name"

    # Source step 0041: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-e0be-7cfd-4133e268b3f9
    When I enter or select "Corporation{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I perform keyboard action "{TAB}" on "Address1"
    When I enter or select "{TAB}35662{TAB}" in "ZipCode"
    When I enter or select "103 Student Dr{TAB}" in "Address1"

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
    When I retain hard-coded value "UMB" as runtime value "Product (LOB)"
    When I retain hard-coded value "SUMB_BASIC" as runtime value "FormOnPolicyDocName"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"

    # Source step 0048: Add a new Associated Client - Business Owner Type - Click Add Client | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-e04c-0b4a-8ef78c072a95
    # Source template XTestStep: 3a13d49c-165b-ce02-83cf-cd6904f97e54
    Then I wait until "Add Client" exists
    When I perform keyboard action "{TAB}" on "Add Client"
    When I click or select "Add Client"

    # Source step 0049: Check if IndividualType Exists | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-0d5f-c01e-a4c1b2039c77
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
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-19c8-010c-6cfc7a7113a7
    # Source template XTestStep: 3a13d49c-165b-71c5-b893-c4235f3b547a
    When I enter or select "{TAB}{CLICK}Business Owner{TAB}" in "IndividualType"
    Then I wait until "Please verify SSN*" exists

    # Source step 0057: Enter Client Details | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-ecbe-8c9c-2bfc2d0fd212
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
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-66fc-dcfd-b41418674ffd
    # Source template XTestStep: 3a13d49c-165b-32d5-f6ed-f265f9f9c6c8
    Then "Search Results > Duck Creek Policy > First Checkbox" should not exist
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0059: Order and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-02d8-664b-ec660b2ca554
    # Source template XTestStep: 3a13d49c-165b-2f1c-c197-ca3b93b64298
    When I click or select "Order SSN"
    When I perform keyboard action "{TAB}" on "Enter SSN*"
    When I enter or select "{TAB}736849971{TAB}" in "Enter SSN*"
    When I click or select "Enter SSN*"

    # Source step 0060: Does Verify Exist | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-f1b8-7c53-b5a633050ea9
    # Source template XTestStep: 3a13d49c-165b-ba0f-6727-be7d60a0ce09
    # Runtime control: If Verify does not exist > Condition
    Then "Verify" should not exist

    # Source step 0061: Click Complete | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-96ca-085b-c91ec45ad420
    # Source template XTestStep: 3a13d49c-165b-95b2-6c84-0c54eb4a6437
    # Runtime control: If Verify does not exist > Then
    When I click or select "Complete"

    # Source step 0062: Click Detail and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-0cec-50f9-d8d4fefc2a68
    # Source template XTestStep: 3a13d49c-165b-6230-e27e-9c3d0e9cbe27
    # Runtime control: If Verify does not exist > Then
    When I click or select "Detail"
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0063: Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-ee97-82fd-f231fe6cec6b
    # Source template XTestStep: 3a13d49c-165b-de87-4c4c-3c66d28b8da1
    # Runtime control: If Verify does not exist > Else
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0064: Perform Final Client Search | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-b193-4bf8-9856913a3d53
    # Source template XTestStep: 3a13d49c-165b-f6d6-53ae-4d4d2d531699
    Then I wait until "Client Search" exists
    When I click or select "Client Search"

    # Source step 0065: Click Ok | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-6706-426e-c1c80ff0dbe5
    # Source template XTestStep: 3a13d49c-165b-647c-ba91-85bcca049803
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"
    Then I wait until "Client Search" no longer exists

    # Source step 0066: Navigate to Underwriting Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-f25b-a92a-fc698f975e8e
    # Source template XTestStep: 3a13d49c-165b-9ab4-0c96-7dae4d962d1c
    When I click or select "Underwriting Info"

    # Source step 0067: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-2d39-5773-904ae5942175
    # Source template XTestStep: 3a13d49c-165b-9c6a-a918-259d7e8d9ba3
    Then I wait until "Is there a Prior Carrier?*" exists
    When I enter or select "Yes{TAB}" in "Is there a Prior Carrier?*"
    When I click or select "Add Prior Carrier"
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
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-cb0e-cd3d-9ffa34d44ac3
    # Source template XTestStep: 3a13d49c-165b-7e70-d439-607c40156454
    When I click or select "Loss Experience"
    Then I wait until "No known losses" exists
    When I enter or select "True{TAB}" in "No known losses"

    # Source step 0069: Click Return to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-fa44-9666-8faa078648de
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
    When I enter or select "09-05-2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0075: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0076: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0077: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0078: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
    # Runtime control: If State is Kansas > Then
    When if field condition "'Product (LOB)' == \"UMB\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0079: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0080: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
    # Runtime control: If State is Virginia > Then
    When if field condition "'Product (LOB)' == \"UMB\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"UMB\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0081: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0082: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
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
    When I enter RUNTIME-DERIVED value "AL UMB Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0087: Navigate to Policy Covg Screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-c748-cb48-6b8d4333a553
    When I click or select "Policy Covg"

    # Source step 0088: Complete Required Fields / Verification Steps | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-6f54-3e53-4527df337f5e
    Then I wait until "Policy Covg" is visible
    Then if field condition "'Umb Limit' == \"$1,000,000\"" is satisfied, "Umbrella Limit" property "Value" should equals "$1,000,000"
    Then if field condition "'Excluded Liability' == \"CU2186\"" is satisfied, "Excluded Liability - Confidential Information*" property "value" should equals "CU2186"
    Then if field condition "'Products - Aggregate Limit' == \"Umbrella Policy Limit\"" is satisfied, "Products - Completed Operations Aggregate Limit" property "value" should equals "Umbrella Policy Limit"

    # Source step 0089: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0090: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0091: Select Commercial Auto underlying LOB | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Commercial Auto Underlying LOB | Source XTestStep: 3a13d49c-166a-0a7c-1bb9-2c36983d6d3b
    When I click or select "Include Commercial Auto"

    # Source step 0092: Wait for Commercial Auto Tab to Appear | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Commercial Auto Underlying LOB | Source XTestStep: 3a13d49c-166a-5884-3303-ddb82e00346f
    Then I wait until "Commercial Auto" is visible

    # Source step 0093: Select General Liability underlying LOB | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add General Liability Underlying LOB | Source XTestStep: 3a13d49c-1679-6690-e902-d4eb4742da28
    Then I wait until "Policy Covg" is visible
    When I click or select "Include General Liability"

    # Source step 0094: Wait for General Liability Tab to Appear | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add General Liability Underlying LOB | Source XTestStep: 3a13d49c-1679-9749-f6b9-fb143c0fe846
    Then I wait until "General Liab" is visible

    # Source step 0095: Select General Liability underlying LOB | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Businessowners Underlying LOB | Source XTestStep: 3a13d49c-1679-8ed4-300d-56608b1f93f0
    Then I wait until "Policy Covg" is visible
    When I click or select "Include Businessowners"

    # Source step 0096: Wait for Businessowners Tab to Appear | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Businessowners Underlying LOB | Source XTestStep: 3a13d49c-1679-7d69-1486-c89e2c5640b3
    Then I wait until "Businessowners" is visible

    # Source step 0097: Select SFP - 10 underlying LOB | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add SFP - 10 Liability Farm Underlying  LOB | Source XTestStep: 3a13d49c-1679-aaec-fd26-9a748f624741
    Then I wait until "Policy Covg" is visible
    When I click or select "Include SFP - 10 Liability/Farm"

    # Source step 0098: Wait for SFP-10 Liability/Farm Tab to Appear | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add SFP - 10 Liability Farm Underlying  LOB | Source XTestStep: 3a13d49c-1679-a9ea-49de-d89b5ec3b69c
    Then I wait until "SFP - 10 Liability/Farm" is visible

    # Source step 0099: Select Commercial Package Policy Liability underlying LOB | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Commercial Package Policy Liability Underlying LOB | Source XTestStep: 3a13d49c-1679-4628-7845-7fd51a37917a
    Then I wait until "Policy Covg" is visible
    When I click or select "Include Commercial Package Policy Liability"

    # Source step 0100: Wait for Commercial Package Policy Liability Tab to Appear | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Commercial Package Policy Liability Underlying LOB | Source XTestStep: 3a13d49c-1679-f815-da48-a6cf6502cd36
    Then I wait until "CPP Liability" is visible

    # Source step 0101: Select Employers Liability underlying LOB | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Employers Liability Underlying LOB | Source XTestStep: 3a13d49c-1679-0d92-466d-3d251d4c41c1
    Then I wait until "Policy Covg" is visible
    When I click or select "Include Employers Liability"

    # Source step 0102: Wait for Employers Liability Tab to Appear | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Policy Covg|Add Employers Liability Underlying LOB | Source XTestStep: 3a13d49c-1679-4d41-3657-9e755771b4cf
    Then I wait until "Employers Liab" is visible

    # Source step 0103: Navigate to Location Screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Location|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-9f1f-ee7d-59db5ca0ed80
    When I click or select "Location"

    # Source step 0104: Click OK and wait for Detail Button | Module: Location
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Location|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-e0ce-094d-103a243c2367
    Then I wait until "Location" is visible
    Then "Zip Code" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"
    When I click or select "OK"
    Then I wait until "Detail" is visible

    # Source step 0105: Navigate to Commercial Auto screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Commercial Auto| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-82c5-8927-20319b334f0d
    When I click or select "Commercial Auto"

    # Source step 0106: Fill out Commercial Auto fields | Module: Commercial Auto
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Commercial Auto| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-cbc4-082d-232c109f337c
    Then I wait until "Commercial Auto Detail" is visible
    When I enter or select "{TAB}0101C2099{TAB}" in "Policy Number"
    When if field condition "'BAP Policy Number' != \"BAPPOL#\"" is satisfied, I click or select "Import Policy Data Button"
    Then I wait until "Effective Date" property "value" does not equal " \"\""
    Then I wait until "Stoplight Message: Total Subject Premium" no longer exists

    # Source step 0108: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0109: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0110: Navigate to General Liab Screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|General Liability| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-7532-a0f1-604ba0c57563
    Then I wait until "General Liab" is visible
    When I perform keyboard action "{TAB}" on "General Liab"
    When I click or select "General Liab"

    # Source step 0111: Fill out General Liability fields | Module: General Liability
    # Section: New Application - Data Entry Process | Reusable flow: UMB|General Liability| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-24de-8e47-0d53ca6d9eac
    Then I wait until "General Liability" is visible
    When I enter or select "{TAB}GLPOL#{TAB}" in "Policy Number"
    When if field condition "'GL Policy Number' == \"GLPOL#\"" is satisfied, I enter RUNTIME-DERIVED value "{DATE[][][MM'/'dd'/'yyyy]}{TAB}" in "Effective Date"
    Then I wait until "Effective Date" property "value" does not equal " \"\""
    When if field condition "'GL Policy Number' == \"GLPOL#\"" is satisfied, I enter RUNTIME-DERIVED value "{DATE[][+1y][MM'/'dd'/'yyyy]}{TAB}" in "Expiration Date"
    When if field condition "'GL Policy Number' == \"GLPOL#\"" is satisfied, I enter or select "{CLICK}$1,000,000/$2,000,000{ENTER}{TAB}" in "CGL Limits*"
    When if field condition "'GL Policy Number' == \"GLPOL#\"" is satisfied, I enter or select "800{TAB}" in "Total Subject Premium*"

    # Source step 0113: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0114: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0115: UMB Navigation Links | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Businessowners| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-03b4-9f45-47691be9de2e
    When I click or select "Businessowners"

    # Source step 0116: Fill Out Required | Module: Businessowners
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Businessowners| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-5514-5358-00265bea4f55
    Then I wait until "Businessowners Heading" is visible
    When I enter or select "{TAB}0102X1262{TAB}" in "Policy Number"
    When if field condition "'BOP Policy Number' != \"BOPPOL#\"" is satisfied, I click or select "Import Policy Data Button"
    Then I wait until "Effective Date" property "value" does not equal " \"\""

    # Source step 0117: Verify Employer's Liability CheckBox Exists/Not Exists | Module: Businessowners
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Businessowners| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-300d-9a88-c723cf9398be
    Then if field condition "'Employers Liability Checkbox' == NULL" is satisfied, "Employer's Liability CheckBox" should not exist

    # Source step 0121: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0122: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0123: Navigate to Employers Liability screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Employers Liability|Fill out Required Fields | Source XTestStep: 3a13d49c-1679-5356-000c-76ac3c1edbf0
    Then I wait until "Employers Liab" is visible
    When I perform keyboard action "{TAB}" on "Employers Liab"
    When I click or select "Employers Liab"

    # Source step 0124: Employers Liability | Module: Employers Liability
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Employers Liability|Fill out Required Fields | Source XTestStep: 3a13d49c-1679-a00b-9ce2-5c3673bbb5b7
    When I enter or select "{TAB}0101W0086{TAB}" in "Policy Number"
    When if field condition "'WC Policy Number' != \"WCPOL#\"" is satisfied, I click or select "Import Policy Data Button"
    Then I wait until "Effective Date" property "value" does not equal " \"\""

    # Source step 0125: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0126: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0127: Navigate to CPP Liability screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|CPP|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-6516-db0f-ffb773ac7313
    Then I wait until "CPP Liability" is visible
    When I perform keyboard action "{TAB}" on "CPP Liability"
    When I click or select "CPP Liability"

    # Source step 0128: Fill out CPP Liability fields | Module: Commercial Package Policy
    # Section: New Application - Data Entry Process | Reusable flow: UMB|CPP|Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-91fe-34b1-a6ad06f27568
    When I enter or select "{TAB}CPPPOL#{TAB}" in "Policy Number"
    When if field condition "'CPP Policy Number' ==\"CPPPOL#\"" is satisfied, I enter RUNTIME-DERIVED value "{DATE[][][MM'/'dd'/'yyyy]}{TAB}" in "Effective Date"
    Then I wait until "Effective Date" property "value" does not equal " \"\""
    When if field condition "'CPP Policy Number' ==\"CPPPOL#\"" is satisfied, I enter RUNTIME-DERIVED value "{DATE[][+1y][MM'/'dd'/'yyyy]}{TAB}" in "Expiration Date"
    When if field condition "'CPP Policy Number' ==\"CPPPOL#\"" is satisfied, I enter or select "{CLICK}$2,000,000/$2,000,000{ENTER}{TAB}" in "Liability Limit*"
    When if field condition "'CPP Policy Number' ==\"CPPPOL#\"" is satisfied, I enter or select "900{TAB}" in "Total Subject Premium*"

    # Source step 0129: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0130: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0131: Navigate to SFP-10  Liability/Farm Screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|SFP-10| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-c99b-bc04-3d804dcdedea
    When I click or select "SFP - 10 Liability/Farm"

    # Source step 0132: Fill out SFP - 10 Liability/Farm fields | Module: SFP - 10 Liability/Farm
    # Section: New Application - Data Entry Process | Reusable flow: UMB|SFP-10| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-c128-4437-1d1ab5d2f192
    Then I wait until "SFP - 10 Liability/Farm Heading" is visible
    When I enter or select "{TAB}SPFPOL#{TAB}" in "Policy Number"
    When I enter RUNTIME-DERIVED value "{DATE[][][MM'/'dd'/'yyyy]}{TAB}" in "Effective Date"
    Then I wait until "Effective Date" property "value" does not equal " \"\""
    When I enter RUNTIME-DERIVED value "{DATE[][+1y][MM'/'dd'/'yyyy]}{TAB}" in "Expiration Date"
    When I enter or select "{CLICK}$300,000/$300,000{ENTER}{TAB}" in "Liability Limit*"
    When I enter or select "1500{TAB}" in "Total Subject Premium*"

    # Source step 0136: Check Endorsements Heading and Fill Out Required Fields | Module: Endorsements - Main Screen
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-7e4d-f135-b40adbe8c375
    # Runtime control: If not on Endorsements page > Condition
    Then "Endorsements Heading" should not exist

    # Source step 0137: Navigate to Endorsements Screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-b281-fb98-014c19e0ceab
    # Runtime control: If not on Endorsements page > Then
    Then I wait until "Endorsements" is visible
    When I perform keyboard action "{TAB}" on "Endorsements"
    When I click or select "Endorsements"

    # Source step 0138: Wait on Endorsements Heading and Fill Out Required Fields | Module: Endorsements - Main Screen
    # Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-0f1f-3e84-2e1f9e389ec5
    # Runtime control: If not on Endorsements page > Then
    Then I wait until "Endorsements Heading" exists

    # Source step 0183: Navigate to UW Questions - Umbrella | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: UMB|UW Questions| Fill Out required Fields | Source XTestStep: 3a13d49c-166a-29df-ee4a-d8c76bb6b2aa
    When I enter or select "{LongClick}" in "UW Questions - Umbrella"

    # Source step 0184: Wait on UW Questions Heading and Fill Out required Fields | Module: UW Questions - Umbrella
    # Section: New Application - Data Entry Process | Reusable flow: UMB|UW Questions| Fill Out required Fields | Source XTestStep: 3a13d49c-166a-066a-26c0-cba5f774b35a
    Then I wait until "UW Questions - Umbrella" exists
    When I click or select "Update Answers"
    Then I wait until "Have you had any liability losses in the last 5 years on any primary or excess policy?*" property "value" equals "No"
    When I enter or select "UW.Test.Com" in "Please provide website address(es).*"

    # Source step 0185: Navigate to Pricing Screen | Module: UMB Navigation Links
    # Section: New Application - Data Entry Process > UMB|Pricing|Fill Out Required Fields_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-0343-edc0-f8de52eafe5e
    # Source template XTestStep: 3a13d49c-166a-33e8-4def-096f702eca50
    When I click or select "Pricing"

    # Source step 0186: Waiton Pricing Heading and Fill Out Required Fields | Module: Pricing
    # Section: New Application - Data Entry Process > UMB|Pricing|Fill Out Required Fields_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-c860-5613-d6f9439b23f9
    # Source template XTestStep: 3a13d49c-166a-d4b2-5168-1b9a5a89d675
    When I perform source-defined action "Waiton Pricing Heading and Fill Out Required Fields" in module "Pricing"

    # Source step 0187: Verify Premium Amount | Module: Pricing
    # Section: New Application - Data Entry Process > UMB|Pricing|Fill Out Required Fields_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-14f3-1ef7-98d5-073f3c060943
    # Source template XTestStep: 3a13d49c-166a-7127-1f21-b1bf1fac7dce
    Then "Premium" property "value" should equals "*$1,010.00"

    # Source step 0188: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0189: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0190: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0191: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0192: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0193: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0194: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0195: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0196: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0197: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0198: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0199: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0200: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0201: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0202: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0203: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0204: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0205: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0206: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0207: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0208: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0209: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0253: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0254: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0255: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0256: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0257: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0258: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0262: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0263: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0264: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0265: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0266: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0267: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0268: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0269: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0313: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0314: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0315: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0316: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0317: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0318: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0319: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0320: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0325: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "1,010.00" as runtime value "NBPrem"

    # Source step 0326: Verify Premiums | Module: Submission|Premiums
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "$1,010.00"
    Then "Premium Written" property "value" should equals "1,010.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "1,010.00"

    # Source step 0344: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c69fe-dde4-9043-7190-6aef66188a63
    When I remove runtime resource "LastResponseResource"

    # Source step 0345: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5cb4-3526-488c-7008e71543a5
    When I enter or select "*" in "Title"
    When I enter or select "return  DCT.sessionID;" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0346: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5cc3-33f0-9d78-aebdde42ec82
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0347: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5cc3-02d8-dc48-23c4e4bce784
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0348: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5cc3-ee18-f8b6-967284462495
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0349: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c69ff-7341-4d89-5dac-2f13a12b757f
    When I wait "250" milliseconds

    # Source step 0350: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5cc3-21d9-5a67-b92afa2e4a96
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\SUMB_BASIC_AL_{B[QuoteID]}.xml"

    # Source step 0355: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c6a02-06b7-140a-023f-4c7af74eaaca
    When I wait "250" milliseconds

    # Source step 0357: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5d68-5a10-f779-4beaa246c197
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA_UMB_variant.ps1  -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\\"  -FileName \"SUMB_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0358: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5d77-c25c-6ed0-ee5adf06bdb4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0359: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5d77-d6e4-ea8c-7f7cfd3226df
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0360: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5d77-2bcb-0e0f-443513f08432
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0361: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0362: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0363: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0364: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0365: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0366: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0367: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0368: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0370: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0371: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0372: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0373: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0374: Close Edge Beta Browsers | Module: TBox Start Program
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
# Source step 0143: "CU2118 is visible" in module "Endorsements - Main Screen" was disabled. Reason: 15.10.25 08:58:02 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-3b86-fbc5-67910812ddf5
#    - VERIFY (Exists) "Delete" with "True"
# Source step 0144: "Delete CU2118" in module "Endorsements - Main Screen" was disabled. Reason: 15.10.25 08:58:02 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-9cba-2ea3-559d828f3884
#    - INPUT "Delete" with "{Click}"
# Source step 0145: "CU2118 is no longer visible" in module "Endorsements - Main Screen" was disabled. Reason: 15.10.25 08:58:02 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-a45c-5917-2e33e190c778
#    - WAIT (Exists) "Delete" with "False"
# Source step 0151: "[CU2118] Exclusion - Year 2000 Computer-Related and Other Electronic Problems" in module "[CU2118] Exclusion - Year 2000 Computer-Related and Other Electronic Problems" was disabled. Reason: 28.10.21 14:19:49 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-cec4-3ead-33faa2250fa8
#    - INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - INPUT "Add Endorsement" with "X"
#    - ACTION "IFRAME" with "a blank/null value"
#    - ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0210: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0211: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0212: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0213: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0214: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0215: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0216: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0217: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0218: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0219: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0220: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0221: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0222: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0223: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0224: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0225: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0226: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0227: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0228: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0229: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0230: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0231: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0232: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0233: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0234: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0235: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0236: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0237: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0238: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0239: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0240: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0241: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0242: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0243: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0244: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0245: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0246: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0247: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0248: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0249: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0250: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0251: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0252: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0270: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0271: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0272: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0273: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0274: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0275: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0276: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0277: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0278: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0279: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0280: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0281: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0282: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0283: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0284: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0285: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0286: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0287: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0288: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0289: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0290: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0291: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0292: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0293: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0294: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0295: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0296: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0297: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0298: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0299: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0300: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0301: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\"
# Source step 0302: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0303: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0304: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0305: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0306: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0307: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0308: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0309: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0310: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0311: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0312: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0321: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0322: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0323: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0324: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0327: "Delete LastResponseResource" in module "TBox Delete Resource" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
#    - INPUT "Resource" with "LastResponseResource"
# Source step 0328: "Get Session ID & Buffer" in module "Verify JavaScript Result" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
#    - INPUT "Title" with "*"
#    - INPUT "JavaScript" with "return DCT.sessionID"
#    - VERIFY "Result" with "{XB[SessionId]}"
# Source step 0329: "Buffer Server Address" in module "TBox Set Buffer" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
#    - INPUT "ServerAddress" with "http://svqw-clas21:8080/duckcreek/dctserver.aspx"
# Source step 0330: "Forms API Request" in module "Forms API Request" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0331: "Forms API Response" in module "Forms API Response" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0332: "Sync API" in module "TBox Wait" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
#    - INPUT "Duration" with "250"
# Source step 0333: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\SUMB_BASIC_AL_{B[QuoteID]}.xml"
# Source step 0334: "Forms API Request" in module "Forms API Request" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com] | 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0335: "Forms API Response" in module "Forms API Response" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com] | 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0336: "Sync API" in module "TBox Wait" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com] | 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0337: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com] | 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\SUMB_BASIC_AL_{B[QuoteID]}.xml"
# Source step 0338: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com] | 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\SUMB_BASIC_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0339: "Sync API" in module "TBox Wait" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
#    - INPUT "Duration" with "250"
# Source step 0340: "Buffer Powershell Arguments" in module "TBox Set Buffer" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
#    - INPUT "PowershellArguments" with "the RUNTIME-DERIVED source value powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\\" -FileName \"SUMB_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""
# Source step 0341: "Execute Powershell Script" in module "TBox Start Program" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
#    - INPUT "Path" with "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe"
#    - INPUT "Directory" with "\\\\mis\\SYS\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "the RUNTIME-DERIVED source value {B[PowershellArguments]}"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > StandardOutputFile" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\FormsCheckResults.txt"
# Source step 0342: "Display the Results Summary" in module "TBox Clipboard" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
#    - BUFFER "Value" with "SummaryResults"
# Source step 0343: "Check and Report for Fails in the Forms Verification from the SummaryResults" in module "TBox Set Buffer" was disabled. Reason: 24.10.24 07:53:09 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
#    - VERIFY "SummaryResults" with "*FAIL:0 *"
#    - VERIFY "SummaryResults" with "*Forms Listed:0 *"
#    - VERIFY "SummaryResults" with "*INFO:0 *"
#    - VERIFY "SummaryResults" with "*Other: 0*"
# Source step 0351: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 13:37:48 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c6b04-daa8-92fc-3053-284eeecde0cc
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0352: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 13:37:48 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c6b04-daa8-7259-ce46-bc128b921300
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0353: "Sync API" in module "TBox Wait" was disabled. Reason: 18.09.25 13:37:48 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c6b04-daa8-d7fc-504e-29a9d954eae5
#    - INPUT "Duration" with "250"
# Source step 0354: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 13:37:48 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a1c6b04-daa8-5bc3-badf-5f4dba60376b
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\SUMB_BASIC_AL_{B[QuoteID]}.xml"
# Source step 0356: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification_UMB | Source XTestStep: 3a15c6c4-5cc3-4fdd-f9fb-3cf69490fc6c
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\SUMB_BASIC_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0369: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  CommercialUmbrella  Pages   US   (9.2.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0045 "Enter Details in Other Information Section" contains conditionally inapplicable field action(s):
#    - INPUT "Name of Audit contact" with "{TAB}Auditor Doe{TAB}" when 'Product (LOB)' != "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "UMB"
#    - INPUT "Audit Telephone #" with "a RANDOM value matching 10 random digits/characters from source expression {RND[10]}{TAB}" when 'Product (LOB)' != "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "UMB"
# Active source step 0078 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
# Active source step 0080 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
# Active source step 0082 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0088 "Complete Required Fields / Verification Steps" contains conditionally inapplicable field action(s):
#    - INPUT "Umbrella Limit" with "{CLICK}$1,000,000{ENTER}{TAB}" when 'Umb Limit' != "$1,000,000". Reason: Value condition evaluated false for the selected iteration: 'Umb Limit' != "$1,000,000"
#    - INPUT "Requested Umbrella Limit" with "$17,000,000{ENTER}{TAB}" when 'Umb Limit' == "Over $15M". Reason: Value condition evaluated false for the selected iteration: 'Umb Limit' == "Over $15M"
#    - INPUT "Industry Code" with "{CLICK}Agricultural{ENTER}{TAB}" when 'State' == "TX". Reason: Value condition evaluated false for the selected iteration: 'State' == "TX"
#    - INPUT "Excluded Liability - Confidential Information*" with "{CLICK}CU2186{ENTER}{TAB}{TAB}{TAB}" when 'Excluded Liability' != "CU2186". Reason: Value condition evaluated false for the selected iteration: 'Excluded Liability' != "CU2186"
#    - WAIT (Value) "Excluded Liability - Confidential Information*" with "CU2186" when 'Excluded Liability' != "CU2186". Reason: Value condition evaluated false for the selected iteration: 'Excluded Liability' != "CU2186"
#    - INPUT "Products - Completed Operations Aggregate Limit" with "Umbrella Policy Limit{TAB}{TAB}" when 'Products - Aggregate Limit' != "Umbrella Policy Limit". Reason: Value condition evaluated false for the selected iteration: 'Products - Aggregate Limit' != "Umbrella Policy Limit"
# Active source step 0095 "Select General Liability underlying LOB" contains conditionally inapplicable field action(s):
#    - INPUT "Does this policy cover a contractor's exposure?" with "{CLICK}No{ENTER}{TAB}" when 'Construction Defect State?' == "Yes". Reason: Value condition evaluated false for the selected iteration: 'Construction Defect State?' == "Yes"
# Active source step 0106 "Fill out Commercial Auto fields" contains conditionally inapplicable field action(s):
#    - INPUT "Effective Date" with "the RUNTIME-DERIVED source value {DATE[][][MM'/'dd'/'yyyy]}{TAB}" when 'BAP Policy Number' ==  "BAPPOL#". Reason: Value condition evaluated false for the selected iteration: 'BAP Policy Number' ==  "BAPPOL#"
#    - INPUT "Expiration Date" with "the RUNTIME-DERIVED source value {DATE[][+1y][MM'/'dd'/'yyyy]}{TAB}" when 'BAP Policy Number' ==  "BAPPOL#". Reason: Value condition evaluated false for the selected iteration: 'BAP Policy Number' ==  "BAPPOL#"
#    - INPUT "Liability Limit*" with "{CLICK}$500,000 CSL{ENTER}{TAB}" when 'BAP Policy Number' ==  "BAPPOL#". Reason: Value condition evaluated false for the selected iteration: 'BAP Policy Number' ==  "BAPPOL#"
#    - INPUT "Total Subject Premium*" with "950{TAB}{TAB}{TAB}" when 'BAP Policy Number' == "BAPPOL#". Reason: Value condition evaluated false for the selected iteration: 'BAP Policy Number' == "BAPPOL#"
# Source step 0107: "Fill out UM Limit" in module "Commercial Auto" was not executed. Reason: Selected-iteration condition evaluated false: 'BAP Policy Number' ==  "BAPPOL#"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Commercial Auto| Fill Out Required Fields | Source XTestStep: 3a13d49c-166a-46d9-5848-4f1cc420da13
#    - Preserved source field action: INPUT "UM Limit*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: UM Limit>{TAB}{TAB})"
# Active source step 0111 "Fill out General Liability fields" contains conditionally inapplicable field action(s):
#    - INPUT "Import Policy Data Button" with "X" when 'GL Policy Number' != "GLPOL#". Reason: Value condition evaluated false for the selected iteration: 'GL Policy Number' != "GLPOL#"
#    - INPUT "Are there any buildings on the underlying policy that have a year built prior to 1980?*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: NY Bldg Prior to 1980>{ENTER}{TAB})" when 'NY Bldg Prior to 1980' == "Yes". Reason: Value condition evaluated false for the selected iteration: 'NY Bldg Prior to 1980' == "Yes"
# Source step 0112: "Fill Out NY Building Prior to 1980 Field" in module "General Liability" was not executed. Reason: Selected-iteration condition evaluated false: 'NY Bldg Prior to 1980' == "Yes"
# Section: New Application - Data Entry Process | Reusable flow: UMB|General Liability| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-82fd-8f62-30122d927e2a
#    - Preserved source field action: INPUT "Are there any buildings on the underlying policy that have a year built prior to 1980?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Bldg Prior to 1980>{TAB}{TAB})"
#    - Preserved source field action: INPUT "Has the building been certified as free of existing lead hazards?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Lead Hazards>{TAB}{TAB})"
# Active source step 0116 "Fill Out Required" contains conditionally inapplicable field action(s):
#    - INPUT "Effective Date" with "the RUNTIME-DERIVED source value {DATE[][][MM'/'dd'/'yyyy]}{TAB}" when 'BOP Policy Number' == "BOPPOL#". Reason: Value condition evaluated false for the selected iteration: 'BOP Policy Number' == "BOPPOL#"
#    - INPUT "Expiration Date" with "the RUNTIME-DERIVED source value {DATE[][+1y][MM'/'dd'/'yyyy]}{TAB}" when 'BOP Policy Number' == "BOPPOL#". Reason: Value condition evaluated false for the selected iteration: 'BOP Policy Number' == "BOPPOL#"
# Active source step 0117 "Verify Employer's Liability CheckBox Exists/Not Exists" contains conditionally inapplicable field action(s):
#    - VERIFY (Exists) "Employer's Liability CheckBox" with "True" when 'Employers Liability Checkbox' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Employers Liability Checkbox' != NULL
# Source step 0118: "Fill Out IA Is the Insured Engaged in A/C Field" in module "Businessowners" was not executed. Reason: Selected-iteration condition evaluated false: 'IA Is the Insured involved In A/C & Appliances' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|Businessowners| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-6cca-65e6-8f3d01f117a6
#    - Preserved source field action: INPUT "Is the insured engaged in Air Conditioning (74011,74021), Appliances (74071,74081,74101,74111,71212), HVAC (74771,74781), Plumbing (75781,75791,75811,75821), Refrigeration Systems (75871,75881), Sheet Metal (77140,77150) and/or Water Softening (77210,77220)?" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: IA Is the Insured involved In A/C & Appliances>{TAB})"
# Source step 0119: "Fill Out MO Liquefied Petroleum Gas" in module "Businessowners" was not executed. Reason: Selected-iteration condition evaluated false: 'MO Does the underlying BOP have Exposure to Liquefied Petroleum Gas ' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|Businessowners| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-3c83-b9ab-cdd84260e2f8
#    - Preserved source field action: INPUT "Does the underlying BOP have any exposure to Liquefied Petroleum Gas?" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: MO Does the underlying BOP have Exposure to Liquefied Petroleum Gas>{ENTER}{TAB})"
# Source step 0120: "Fill Out NY Building Prior to 1980 Field" in module "Businessowners" was not executed. Reason: Selected-iteration condition evaluated false: 'NY Bldg Prior to 1980' == "Yes"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Businessowners| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-e977-5be6-0213a7af9a71
#    - Preserved source field action: INPUT "Are there any buildings on the underlying policy that have a year built prior to 1980?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Bldg Prior to 1980>{TAB})"
#    - Preserved source field action: INPUT "Has the building been certified as free of existing lead hazards?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Lead Hazards>{TAB})"
# Active source step 0124 "Employers Liability" contains conditionally inapplicable field action(s):
#    - INPUT "Effective Date" with "the RUNTIME-DERIVED source value {DATE[][][MM'/'dd'/'yyyy]}{TAB}" when 'WC Policy Number' == "WCPOL#". Reason: Value condition evaluated false for the selected iteration: 'WC Policy Number' == "WCPOL#"
#    - INPUT "Expiration Date" with "the RUNTIME-DERIVED source value {DATE[][+1y][MM'/'dd'/'yyyy]}{TAB}" when 'WC Policy Number' == "WCPOL#". Reason: Value condition evaluated false for the selected iteration: 'WC Policy Number' == "WCPOL#"
#    - INPUT "Liability Limit*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Employers Liability Limit>{ENTER}{TAB})" when 'WC Policy Number' == "WCPOL#". Reason: Value condition evaluated false for the selected iteration: 'WC Policy Number' == "WCPOL#"
#    - INPUT "Total Subject Premium*" with "750{TAB}" when 'WC Policy Number' == "WCPOL#". Reason: Value condition evaluated false for the selected iteration: 'WC Policy Number' == "WCPOL#"
# Active source step 0128 "Fill out CPP Liability fields" contains conditionally inapplicable field action(s):
#    - INPUT "Import Policy Data Button" with "x" when 'CPP Policy Number' !="CPPPOL#". Reason: Value condition evaluated false for the selected iteration: 'CPP Policy Number' !="CPPPOL#"
#    - INPUT "Are there any buildings on the underlying policy that have a year built prior to 1980?*" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: NY Building Prior to 1980>{ENTER}{TAB})" when 'NY Building Prior to 1980' == "CPPPOL#". Reason: Value condition evaluated false for the selected iteration: 'NY Building Prior to 1980' == "CPPPOL#"
#    - INPUT "Has the building been certified as free of existing lead hazards?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Lead Hazards>{TAB})" when 'Lead Hazards' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Lead Hazards' != NULL
#    - INPUT "Description Of Premises" with "Test{TAB}" when 'Lead Hazards' == "No". Reason: Value condition evaluated false for the selected iteration: 'Lead Hazards' == "No"
# Source step 0133: "Fill Out ME Farm Employee Field" in module "SFP - 10 Liability/Farm" was not executed. Reason: Selected-iteration condition evaluated false: 'ME Farm Employee Liabilty $100,000' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|SFP-10| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-9ad4-3e55-f942945c2765
#    - Preserved source field action: INPUT "Does the SFP 10 include farm employee liability coverage of $100,000?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: ME Farm Employee Liabilty $100,000>{TAB})"
# Source step 0134: "Fill Out NY Building Prior to 1980 Field" in module "SFP - 10 Liability/Farm" was not executed. Reason: Selected-iteration condition evaluated false: 'NY Bldg Prior to 1980' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|SFP-10| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-c2d0-5a48-df34fc3871d7
#    - Preserved source field action: INPUT "Are there any buildings on the underlying policy that have a year built prior to 1980?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Bldg Prior to 1980>{TAB})"
#    - Preserved source field action: INPUT "Has the building been certified as free of existing lead hazards?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Lead Hazards>{TAB})"
# Source step 0135: "Fill Out NY Sale of Livestock Field" in module "SFP - 10 Liability/Farm" was not executed. Reason: Selected-iteration condition evaluated false: 'NY Sale of Livestock or Meat' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|SFP-10| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-e03c-b4d8-5c123ff575c4
#    - Preserved source field action: INPUT "Is the insured involved in the sale of any livestock or meat?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: NY Sale of Livestock or Meat>{TAB})"
# Source step 0139: "CU2118 Exists" in module "Endorsements - Main Screen" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' == "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations"||'Endorsement Type' =="[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises" ||'Endorsement Type' =="[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a1cfa50-d9d3-d0e0-d5f5-5aee4bc515be
#    - Preserved source field action: VERIFY (Exists) "Delete" with "True"
# Source step 0140: "Delete CU2118" in module "Endorsements - Main Screen" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' == "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations"||'Endorsement Type' =="[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises" ||'Endorsement Type' =="[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a1cfa51-27f2-8cf6-c6ee-8cbe976d4e6f
#    - Preserved source field action: INPUT "Delete" with "{Click}"
# Source step 0141: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' == "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations"||'Endorsement Type' =="[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises" ||'Endorsement Type' =="[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0142: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' == "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations"||'Endorsement Type' =="[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises" ||'Endorsement Type' =="[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0146: "Verify if value equals select" in module "[CU0400] Coverage For Injury To Leased Workers" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-f1bb-c8c0-444b43d9ad90
#    - Preserved source field action: VERIFY (Value) "Select Endorsement:" with "(select)"
# Source step 0147: "[CU0400] Coverage For Injury To Leased Workers" in module "[CU0400] Coverage For Injury To Leased Workers" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU0400] Coverage For Injury To Leased Workers"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-da40-3d6a-332c62a7a6fe
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0148: "[CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies" in module "[CU0206] Utah Changes - Notice of Cancellation for Private Investigator Agencies" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-610e-00a6-e9430c7a188f
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0149: "[CU2103] Exclusion - Designated Work" in module "[CU2103] Exclusion - Designated Work " was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2103] Exclusion - Designated Work "
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-44a9-3937-853593395859
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "\"[CU 2103] Exclusion - Designated Work\""
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Other CheckBox" with "True{TAB}"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Description of Other" with "This is a test."
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0150: "[CU2114] Amendment of Liquor Liability Exclusion - Exception for Scheduled Premises or Activities" in module "[CU2114] Amendment of Liquor Liability Exclusion - Exception for Scheduled Premises or Activities" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2114] Amendment of Liquor Liability Exclusion - Exception for Scheduled Premises or Activities"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-0b40-f480-e2a78dc4498a
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Description Of Premises Or Activities" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0152: "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations" in module "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2119] Exclusion - Year 2000 Computer Related and other Electronic Problems - Products/Completed Operations"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-3458-93fe-5de6e1d90c6d
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0153: "[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises" in module "[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2120] Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-e17f-52e3-85790f1800be
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "\"[CU2120]  - Exclusion - Year 2000 Computer-Related and other Electronic Problems - With Exception for Bodily Injury on your Premises\""
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0154: "[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages" in module "[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2121] Year 2000 Computer-Related and Other Electronic Problems - Exclusion of Specified Coverages"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-2e3e-9e39-dd7f74e72068
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "{Click}"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( \"<BLANK — reusable-block parameter is not supplied: Endorsement Type>\")"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Bodily Injury CheckBox" with "True"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Property Damage CheckBox" with "True"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Personal and Advertising Injury CheckBox" with "True"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Decription of locations,operations" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0155: "[CU2150] Silica or Silica-Related Dust Exclusion" in module "[CU2150] Silica or Silica-Related Dust Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type'  =="[CU2150] Silica or Silica-Related Dust Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-44fb-960d-e8c5c6db3e48
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "{Click}"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( \"<BLANK — reusable-block parameter is not supplied: Endorsement Type>\")"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0156: "[CU2151] Total Pollution Exclusion with a Hostile Fire Exception" in module "[CU2151] Total Pollution Exclusion with a Hostile Fire Exception" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2151] Total Pollution Exclusion with a Hostile Fire Exception"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-2135-c116-df08caedff1c
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0157: "[CU2152] Total Pollution Exclusion with a Building Heating, Cooling and Dehumidifying Equipment Exception and a Hostile Fire Exception" in module "[CU2152] Total Pollution Exclusion with a Building Heating, Cooling and Dehumidifying Equipment Exception and a Hostile Fire Exception" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2152] Total Pollution Exclusion with a Building Heating, Cooling and Dehumidifying Equipment Exception and a Hostile Fire Exception"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-2e21-7173-c23cb0f7a21e
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0158: "[CU2173] Exclusion – Unmanned Aircraft (Coverage B Only)" in module "[CU2173] Exclusion – Unmanned Aircraft (Coverage B Only)" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2173] Exclusion – Unmanned Aircraft (Coverage B Only)"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-e30d-9c67-4b451b276ae8
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0159: "[CU2216] Underground Resources and Equipment Coverage" in module "[CU2216] Underground Resources and Equipment Coverage" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2216] Underground Resources and Equipment Coverage"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-1c7a-4f6b-bcf498dfc6dc
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Aggregate Limit" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Aggregate Limit>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0160: "[CU2448] Washington -  Limited Coverage for Bodily Injury, Property Damage or Personal and Advertising Injury Involving Efficient Proximate Cause" in module "[CU2448] Washington -  Limited Coverage for Bodily Injury, Property Damage or Personal and Advertising Injury Involving Efficient Proximate Cause" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2448] Washington -  Limited Coverage for Bodily Injury, Property Damage or Personal and Advertising Injury Involving Efficient Proximate Cause"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-98e5-58e3-9a7a893aa5fb
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0161: "[CU2604] Connecticut Changes - Condominiums" in module "[CU2604] Connecticut Changes - Condominiums" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2604] Connecticut Changes - Condominiums"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-2d47-f4ca-3747963a27c8
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0162: "[CU2605] Connecticut Changes - Townhouses" in module "[CU2605] Connecticut Changes - Townhouses" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2605] Connecticut Changes - Townhouses"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-959b-c707-ac0deaa6774a
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0163: "[CU2618] WA Changes – Amendment of Liquor Liability Exclusion Exception for Scheduled Premises or Activities" in module "[CU2618] WA Changes – Amendment of Liquor Liability Exclusion Exception for Scheduled Premises or Activities" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[CU2618] WA Changes – Amendment of Liquor Liability Exclusion Exception for Scheduled Premises or Activities"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-fec7-3d5d-787a4c315367
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Description Of Premises Or Activities" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0164: "[UC0201] Auto Owner And/Or Operator Exclusion" in module "[UC0201] Auto Owner And/Or Operator Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0201] Auto Owner And/Or Operator Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-e48e-ed11-c2c36b4acb04
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Excluded Driver" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Excluded Driver>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0165: "[UC0229] Automobile Owner And/Or Operator Exclusion - South Dakota" in module "[UC0229] Automobile Owner And/Or Operator Exclusion - South Dakota" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0229] Automobile Owner And/Or Operator Exclusion - South Dakota"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-a8d6-c5ac-50baeacba4e0
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Excluded Driver" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Excluded Driver>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0166: "[UC0230] Asbestos Exclusion" in module "[UC0230] Asbestos Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0230] Asbestos Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-df31-06a1-fcc567392b44
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0167: "[UC0232] Lead Liability Exclusion" in module "[UC0232] Lead Liability Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0232] Lead Liability Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-8cca-1595-2c7d3232bc04
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0168: "[UC0234] Continuous Or Progressive Injury & Damage Exclusion" in module "[UC0234] Continuous Or Progressive Injury & Damage Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0234] Continuous Or Progressive Injury & Damage Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-3820-d63f-c45e928eebe7
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0169: "[UC0237] Absolute Movement of Land, Earth, or Soil Exclusion" in module "[UC0237] Absolute Movement of Land, Earth, or Soil Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0237] Absolute Movement of Land, Earth, or Soil Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-1b7b-1b9f-5f77b2fc56e2
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0170: "[UC0272] Waiver of Subrogation" in module "[UC0272] Waiver of Subrogation" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0272] Waiver of Subrogation"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-e4cb-3447-ac5d58e5ace4
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0171: "[UC0274] Amendment of Other Insurance Condition – Primary and Non-contributory" in module "[UC0274] Amendment of Other Insurance Condition – Primary and Non-contributory" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0274] Amendment of Other Insurance Condition – Primary and Non-contributory"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-acd6-ad75-46d2492e5fd1
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0172: "[UC0287] NY Multi Unit Residential Buildings and Tract Housing Exclusion" in module "[UC0287] NY Multi Unit Residential Buildings and Tract Housing Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0287] NY Multi Unit Residential Buildings and Tract Housing Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-fe20-c6c4-7df02aeb0fe9
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0173: "[UC0292] New York Amendment of Other Insurance Condition OR Primary and Noncontributory" in module "[UC0292] New York Amendment of Other Insurance Condition OR Primary and Noncontributory" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0292] New York Amendment of Other Insurance Condition OR Primary and Noncontributory"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-b5bc-0272-89a55346d664
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( \"<BLANK — reusable-block parameter is not supplied: Endorsement Type>\")"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0174: "[UC0295] Louisiana - Continuous Or Progressive Injury & Damage Exclusion" in module "[UC0295] Louisiana - Continuous Or Progressive Injury & Damage Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0295] Louisiana - Continuous Or Progressive Injury & Damage Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-7778-dea6-3278f006d696
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( \"<BLANK — reusable-block parameter is not supplied: Endorsement Type>\")"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0175: "[UC0296] Georgia - Absolute Movement of Land, Earth, or Soil Exclusion" in module "[UC0296] Georgia - Absolute Movement of Land, Earth, or Soil Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' ==  "[UC0296] Georgia - Absolute Movement of Land, Earth, or Soil Exclusion"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-d0e7-f14d-971ab69ea348
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( \"<BLANK — reusable-block parameter is not supplied: Endorsement Type>\")"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0176: "[UC0299] Amendment of Other Insurance Condition – Primary and Non-contributory" in module "[UC0299] Amendment of Other Insurance Condition – Primary and Non-contributory" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC0299] Amendment of Other Insurance Condition – Primary and Non-contributory"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-0028-312f-90ee1583179f
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0177: "[UC1100] Exclusion - All Hazards in Connection with Designated Farm Location" in module "[UC1100] Exclusion - All Hazards in Connection with Designated Farm Location" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' ==  "[UC1100] Exclusion - All Hazards in Connection with Designated Farm Location"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-79fc-24cc-be0407a0b914
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Address(es) or Description(s) of Designated Farm Location(s):" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0178: "[UC1101] Exclusion for Designated Activities or Services" in module "[UC1101] Exclusion for Designated Activities or Services" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC1101] Exclusion for Designated Activities or Services"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-9d3f-ba93-2bc001f0ccf1
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Name(s) or Description(s) and Date(s) of Designated Activities or Services" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0179: "[UC1102] Exclusion for Designated Animals" in module "[UC1102] Exclusion for Designated Animals" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC1102] Exclusion for Designated Animals"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-6ccb-251b-15180fc7e988
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter ( <BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Name(s) or Description(s) of Designated Animal(s):" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0180: "[UC1103] Exclusion for Designated Premises" in module "[UC1103] Exclusion for Designated Premises" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL AND 'Endorsement Type' == "[UC1103] Exclusion for Designated Premises"
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-93eb-4e5a-bd66d25b33f2
#    - Preserved source field action: INPUT "Select Endorsement:" with "a blank/not-supplied reusable parameter ({CLICK}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{ENTER}{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "X"
#    - Preserved source field action: ACTION "IFRAME" with "a blank/null value"
#    - Preserved source field action: ACTION "IFRAME > Duck Creek Policy" with "a blank/null value"
#    - Preserved source field action: WAIT (InnerText) "IFRAME > Duck Creek Policy > Endorsement Heading" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Endorsement Type>)"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > Address(es) or Description(s) of Designated Premises:" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Description>{TAB})"
#    - Preserved source field action: INPUT "IFRAME > Duck Creek Policy > OK" with "X"
# Source step 0181: "Wait on Endorsement Type" in module "[UC0272] Waiver of Subrogation" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-f42e-675e-bd545a96c503
#    - Preserved source field action: WAIT (Exists) "Select Endorsement:" with "True"
# Source step 0182: "Wait for Endorsement to be completed" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: UMB|Endorsements| Fill Out Required Fields | Source XTestStep: 3a13d49c-1679-6b7e-a5a6-263177d59b36
#    - Preserved source field action: INPUT "Duration" with "950"
# Source step 0259: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0260: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0261: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14f3-7a41-9525-f3bd22c21887
#    - I capture a "Desktop" screenshot at ""
#   - Source-disabled recovery value: INPUT "Environment" with "Desktop"
#   - Source-disabled recovery value: INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\UMB"
#   - Source-disabled recovery value: INPUT "Filename" with "UMBBASICTestCase"
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-1679-f3bb-e65c-a50d525b51d8
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\UMB\\UMBBASICTestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14f3-3339-4a91-37fae279423e
#    - I capture a "Desktop" screenshot at ""
#   - Source-disabled recovery value: INPUT "Environment" with "Desktop"
#   - Source-disabled recovery value: INPUT "Directory" with "P:\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\UMB"
#   - Source-disabled recovery value: INPUT "Filename" with "UMBBASICTestStep"
# Source recovery step 0004: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-1679-f3bb-e65c-a50d525b51d8
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\UMB\\UMBBASICTestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0005: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14f3-8637-0a09-55baa5168d54
#    - I capture a "Desktop" screenshot at ""
#   - Source-disabled recovery value: INPUT "Environment" with "Desktop"
#   - Source-disabled recovery value: INPUT "Directory" with "P:\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\UMB"
#   - Source-disabled recovery value: INPUT "Filename" with "UMBBASICTestStepValue"
# Source recovery step 0006: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-1679-f3bb-e65c-a50d525b51d8
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\UMB\\UMBBASICTestStepValue"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0007: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14f3-b7cd-3ebe-98bdcf1defcd
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0008: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14f3-17fe-48e9-ce5487fb7586
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0009: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14f3-8252-6559-265c5c073518
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0010: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14f3-a6a0-d4e0-e976301a2a18
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0011: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14f3-a586-4abc-e1c654f05107
#    - I run "taskkill /f /im msEdge.exe"
