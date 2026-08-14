# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 011_WC_Expanded_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @WC @expanded @Alabama @Edge @manual @automated
Feature: Execute WC |Expanded for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the WC |Expanded workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: WC |Expanded using representative iteration Alabama (AL)

    # Source step 0037: Deselect Quick Quote | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-8c04-f871-977dce57ab16
    Then I wait until "Quick Quote" exists
    When I enter or select "False" in "Quick Quote"

    # Source step 0038: Wait for Non-Quick Quote Element to Appear | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-0dce-cfc6-59fb5cd44711
    Then I wait until "Underwriting Info" exists

    # Source step 0039: Select Business Insured | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-638e-caa1-a2682077282c
    When if field condition "'Insured Type' != NULL" is satisfied, I enter or select "{TAB}{CLICK}Business{TAB}{TAB}" in "Insured Type"
    When if field condition "'Insured Type' != NULL" is satisfied, I click or select "Entity Type"

    # Source step 0040: Enter Business Name | Module: Client|Named Insured|Business
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-13cf-1a29-3a6a432e24f0
    Then I wait until "Business Name" is visible
    When if field condition "'Business Name' != NULL" is satisfied, I enter or select "{TAB}{CLICK}AL WC Testing, Inc.{TAB}" in "Business Name"

    # Source step 0041: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-47da-657a-5d2d563ba8dd
    When if field condition "'Legal Nature' != NULL" is satisfied, I enter or select "{TAB}{CLICK}Joint Venture{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Primary Phone"
    When if field condition "'Address 1' != NULL" is satisfied, I enter or select "{TAB}{CLICK}1918 Avalon Ave{TAB}" in "Address1"
    When if field condition "ZipCode != NULL" is satisfied, I enter or select "{TAB}{CLICK}35661{TAB}" in "ZipCode"

    # Source step 0042: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-725b-1f27-557ce21e1a86
    # Runtime control: If Years in Business Exists > Check Years in Business
    Then "Years In Business" should exist

    # Source step 0043: Enter Business Info | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-92dc-c5e5-d2266e3fea67
    # Runtime control: If Years in Business Exists > Then Input Years
    When I enter or select "6{TAB}" in "Years In Business"

    # Source step 0044: Enter FEIN | Module: Client|Named Insured|Business
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-8bb4-fd21-9ae7ea77fd7d
    When I enter a RANDOM value matching "9 random digits/characters from source expression {RND[9]}{TAB}" in "FEIN"

    # Source step 0045: Enter Details in Other Information Section | Module: Client|Other Insured Info
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-6e03-f7a0-0c3c836544db
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}{CLICK}Auditor Doe{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "{TAB}{CLICK}https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0046: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-1679-36bd-8fec-88b6c41e8f7e
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "Carrier  WorkersCompensation  Pages   US   (9.8.0.0)" as runtime value "Product (LOB)"

    # Source step 0047: Add a new Associated Client - Business Owner Type - Click Add Client | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-cd56-2817-3869e35d6753
    # Source template XTestStep: 3a13d49c-165b-ce02-83cf-cd6904f97e54
    Then I wait until "Add Client" exists
    When I perform keyboard action "{TAB}" on "Add Client"
    When I click or select "Add Client"

    # Source step 0048: Check if IndividualType Exists | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-7fac-3f1f-4dc50ccb9ebe
    # Source template XTestStep: 3a13d49c-165b-d0b1-7d57-b7cecf62671b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Condition
    Then "IndividualType" should not exist

    # Source step 0049: AJAX Error Check | Module: AJAX Error
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-90d4-c7c4-34e4afe4471a
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Check for AJAX Error
    Then "AJAX Error Check" should exist

    # Source step 0050: Set buffer for Error | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-742f-be97-b5b259ccf349
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I derive and retain the RUNTIME-DERIVED buffer expression "The scripts experienced an AJAX error with the following information: {B[AJAX]}" as runtime value "AJAX Error"

    # Source step 0051: Force a fail | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-fc4f-89ec-af2ceb5f1e02
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    Then I evaluate the source-defined expression for "Force a fail" using "Expression='FALSE' == 'TRUE'"

    # Source step 0052: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I click or select "Billing"

    # Source step 0053: Fill Out Required Fields on Billing Screen | Module: Billing
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-315a-3b12-4a479c858c7a
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

    # Source step 0054: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I wait "3000" milliseconds

    # Source step 0055: Complete the Associated Client Info | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-1763-4592-11ef1ca8d3bf
    # Source template XTestStep: 3a13d49c-165b-71c5-b893-c4235f3b547a
    When I enter or select "{TAB}{CLICK}Business Owner{TAB}" in "IndividualType"
    Then I wait until "Please verify SSN*" exists

    # Source step 0056: Enter Client Details | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-6992-d52e-2ab358a08c81
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

    # Source step 0057: Verify no results returned and click OK | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-2311-8253-d992d206520c
    # Source template XTestStep: 3a13d49c-165b-32d5-f6ed-f265f9f9c6c8
    Then "Search Results > Duck Creek Policy > First Checkbox" should not exist
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0058: Order and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-df13-45de-73812a275180
    # Source template XTestStep: 3a13d49c-165b-2f1c-c197-ca3b93b64298
    When I click or select "Order SSN"
    When I perform keyboard action "{TAB}" on "Enter SSN*"
    When I enter or select "{TAB}736849971{TAB}" in "Enter SSN*"
    When I click or select "Enter SSN*"

    # Source step 0059: Does Verify Exist | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-0864-b94d-2fab98a54478
    # Source template XTestStep: 3a13d49c-165b-ba0f-6727-be7d60a0ce09
    # Runtime control: If Verify does not exist > Condition
    Then "Verify" should not exist

    # Source step 0060: Click Complete | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-b663-bfa3-9ead1c39bfb9
    # Source template XTestStep: 3a13d49c-165b-95b2-6c84-0c54eb4a6437
    # Runtime control: If Verify does not exist > Then
    When I click or select "Complete"

    # Source step 0061: Click Detail and Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-b0fd-6159-368929224b42
    # Source template XTestStep: 3a13d49c-165b-6230-e27e-9c3d0e9cbe27
    # Runtime control: If Verify does not exist > Then
    When I click or select "Detail"
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0062: Verify SSN | Module: Client|Add Associated Client
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-a0f2-3b77-317ba2cdabe2
    # Source template XTestStep: 3a13d49c-165b-de87-4c4c-3c66d28b8da1
    # Runtime control: If Verify does not exist > Else
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0063: Perform Final Client Search | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-822a-bbbe-15269f93b4c8
    # Source template XTestStep: 3a13d49c-165b-f6d6-53ae-4d4d2d531699
    Then I wait until "Client Search" exists
    When I click or select "Client Search"

    # Source step 0064: Click Ok | Module: Client Search Results
    # Section: New Application - Data Entry Process > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-889f-3125-c6b7f34f436d
    # Source template XTestStep: 3a13d49c-165b-647c-ba91-85bcca049803
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"
    Then I wait until "Client Search" no longer exists

    # Source step 0065: Navigate to Underwriting Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-cfea-31e9-422b19271c76
    # Source template XTestStep: 3a13d49c-165b-9ab4-0c96-7dae4d962d1c
    When I click or select "Underwriting Info"

    # Source step 0066: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-0431-520e-57ee7ed40b9e
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

    # Source step 0067: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-05ec-3374-3e1b691f498c
    # Source template XTestStep: 3a13d49c-165b-7e70-d439-607c40156454
    When I click or select "Loss Experience"
    Then I wait until "No known losses" exists
    When I enter or select "True{TAB}" in "No known losses"

    # Source step 0068: Click Return to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process > Common|Client|Complete Underwriting Info from Client Screen-SFP_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-8733-6bc9-e5e96ed2d3ea
    # Source template XTestStep: 3a13d49c-165b-b5c9-40b3-036c7fb8da80
    When I click or select "Return to Quote"

    # Source step 0069: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0070: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0071: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0072: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0073: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "07-01-2026{TAB}" in "EffectiveDate"

    # Source step 0074: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0075: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0076: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0078: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0080: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0081: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0082: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0083: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL WC ST {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0086: Policy Info | WC Specific Fields | Module: Policy Info|WC Specific Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Fill Out WC Specific Fields | Source XTestStep: 3a13d49c-165b-3baf-6162-78d1ff47073c
    When I enter or select "{CLICK}Yes{ENTER}{TAB}" in "Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?*"

    # Source step 0087: Policy Info | Estimated Premium | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|Fill Out Estimated Premium | Source XTestStep: 3a13d49c-165b-65a9-4b10-5278a85a5e32
    Then if field condition "'Estimated Premium' == NULL" is satisfied, "Estimated Premium*" should not exist

    # Source step 0090: Navigate to Policy Covg Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Policy Covg|Coverage Information | Source XTestStep: 3a13d49c-1679-40fa-c222-386d28ccf3e4
    When I click or select "Policy Covg"

    # Source step 0091: Policy Covg | Module: Policy Covg
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Policy Covg|Coverage Information | Source XTestStep: 3a13d49c-1679-e4a9-4a54-736beda6ae7a
    Then I wait until "Policy Covg Header" exists
    Then I wait until "Primary Location State*" exists
    Then if field condition "'Primary Rating State' != NULL" is satisfied, "Primary Location State*" property "value" should equals "{REGEX[\"(?i)\"Alabama]}"
    When if field condition "('Experience Rated' != NULL)&&(State!=\"OK\")" is satisfied, I enter or select "Yes{TAB}" in "Experience Rated"
    When if field condition "('Default Experience Mod Type' != NULL)&&(State!=\"OK\")&&(State!=\"NY\")" is satisfied, I capture "Default Experience Mod" as runtime value "ExpMod"
    When if field condition "('Default Experience Mod Type' != NULL)&&(State!=\"OK\")&&(State!=\"NY\")" is satisfied, I enter or select "Tentative{TAB}" in "Default Exp Mod Type"

    # Source step 0092: Navigate to Location Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Location|Fill Out Address 1 | Source XTestStep: 3a13d49c-1679-d376-1ab8-d9deb7f9ef0b
    When I click or select "Location"

    # Source step 0093: Location | Module: Location
    # Section: New Application - Data Entry Process | Reusable flow: WC|Location|Fill Out Address 1 | Source XTestStep: 3a13d49c-1679-ea8f-b5dd-712fa80abd05
    Then I wait until "Address1" exists
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"
    When I click or select "OK"

    # Source step 0094: Navigate to State Details Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-4e89-7ebf-6ab94f1307e6
    When I click or select "State Details"

    # Source step 0095: State Details - Main Questions | Module: State Details|Main
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-6fce-6852-05028213fefb
    Then I wait until "Intrastate Risk ID" exists
    When if field condition "'Waiver of Subrogation' != NULL" is satisfied, I enter or select "{TAB}Specific{TAB}" in "Waiver Of Subrogation"
    When if field condition "'Small Deductible' != NULL" is satisfied, I enter or select "{TAB}$500{TAB}" in "Small Deductible*"
    When if field condition "'Company Name' != NULL" is satisfied, I enter or select "{TAB}{CLICK}American National{TAB}{TAB}" in "Company Name*"
    When if field condition "('Merit Rating' != NULL)&&(State!=\"NY\")" is satisfied, I leave "Merit Rating" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Deductible != NULL" is satisfied, I leave "Deductible" blank because the reusable parameter is not supplied for this iteration
    When if field condition "Deductible != NULL" is satisfied, I leave "Deductible" blank because the reusable parameter is not supplied for this iteration

    # Source step 0096: State Details|Experience Rated | Module: State Details|Experience Rated
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-e358-51e2-70f91dd4a261
    When if field condition "'Experience Rating Options' != NULL" is satisfied, I enter or select "{TAB}Experience Rated{TAB}" in "Experience Rating Options"
    When if field condition "'Experience Mod Type' != NULL" is satisfied, I enter or select "{TAB}Contingent{TAB}" in "Experience Mod Type*"

    # Source step 0097: State Details|Check for Pending Rate Change | Module: State Details|Main
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-88de-73b5-d05af9b3b643
    Then if field condition "'Pending Rate Change' != NULL" is satisfied, "Pending Rate Change" property "value" should equals "No"

    # Source step 0099: Navigate to WC Schedule | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-5725-89db-5d93bcbd6185
    When I click or select "WC Schedule"

    # Source step 0100: Add First Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-3952-f9ea-269158d45b13
    Then I wait until "Add Class Code" exists
    When I click or select "Add Class Code"
    When I leave "Class Code Frame > Class Code Window" blank

    # Source step 0101: Loop while OK Button does not exist | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-9a45-0b8b-b94e187e670d
    # Runtime control: Do Loop for First Class Code [max=45] > Condition
    Then "Class Code Frame > Class Code Window > OK-Class Code" should not exist

    # Source step 0102: Loop for First Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-2a64-4c9d-6a3fb8227079
    # Runtime control: Do Loop for First Class Code [max=45] > Loop
    Then I wait until "Class Code Frame > Class Code Window > SearchValue" exists
    When if field condition "'Class Code 1' != NULL" is satisfied, I enter or select "LANDSCAPE GARDENING AND DRIVERS (0042){TAB}" in "Class Code Frame > Class Code Window > SearchValue"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > SearchValue"
    When if field condition "'Class Code 1' != NULL" is satisfied, I enter or select "{CLICK}LANDSCAPE GARDENING AND DRIVERS (0042){ENTER}{TAB}{CLICK}{TAB}{TAB}" in "Class Code Frame > Class Code Window > Select Class Code*"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > Select Class Code*"

    # Source step 0103: TBox Wait | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-65b8-d89c-521f0c93dc10
    # Runtime control: Do Loop for First Class Code [max=45] > Loop
    When I wait "3000" milliseconds

    # Source step 0104: Input First Class Code Details | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-1490-378d-bf8480460007
    Then if field condition "'Class Code 1' != NULL" is satisfied, "Class Code Frame > Class Code Window > Select Class Code*" property "value" should equals "LANDSCAPE GARDENING AND DRIVERS (0042)"
    Then I wait until "Class Code Frame > Class Code Window > OK-Class Code" exists
    When I click or select "Class Code Frame > Class Code Window > OK-Class Code"
    When if field condition "State != \"MD\"" is satisfied, I enter or select "{TAB}{CLICK}100000{TAB}" in "Class Code Frame > Class Code Window > Total Payroll (Estimated)"
    When if field condition "'Waiver of Subrogation Exposure' != NULL" is satisfied, I enter or select "{TAB}{CLICK}25000{TAB}" in "Class Code Frame > Class Code Window > Waiver Of Subrogation Exposure*"
    When I enter or select "{TAB}{CLICK}3{TAB}" in "Class Code Frame > Class Code Window > Number of Part-Time Employees*"
    When I enter or select "{TAB}{CLICK}2{TAB}" in "Class Code Frame > Class Code Window > Number of Full-Time Employees*"
    When I click or select "Class Code Frame > Class Code Window > OK-Details"
    Then I wait until "Class Code Frame" no longer exists

    # Source step 0105: Add Second Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-3204-ffb2-0933d8a53326
    Then I wait until "Add Class Code" exists
    When I click or select "Add Class Code"

    # Source step 0106: Loop while OK Button does not exist | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-97b3-00d5-866565c1aab1
    # Runtime control: Do Loop for Second Class Code [max=45] > Condition
    Then "Class Code Frame > Class Code Window > OK-Class Code" should not exist

    # Source step 0107: Loop for Second Class Code | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-7dc2-7640-fdde5e82fccc
    # Runtime control: Do Loop for Second Class Code [max=45] > Loop
    Then I wait until "Class Code Frame > Class Code Window > SearchValue" exists
    When if field condition "'Class Code 2' != NULL" is satisfied, I enter or select "MASONRY NOC (5022){TAB}" in "Class Code Frame > Class Code Window > SearchValue"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > SearchValue"
    When if field condition "'Class Code 2' != NULL" is satisfied, I enter or select "{CLICK}MASONRY NOC (5022){ENTER}{TAB}{CLICK}{TAB}{TAB}" in "Class Code Frame > Class Code Window > Select Class Code*"
    When I perform keyboard action "{TAB}" on "Class Code Frame > Class Code Window > Select Class Code*"

    # Source step 0108: TBox Wait | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-cdba-96ac-36343cfbcc87
    # Runtime control: Do Loop for Second Class Code [max=45] > Loop
    When I wait "3000" milliseconds

    # Source step 0109: Input Second Class Code Details | Module: WC Schedule|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|WC Schedule|Add Class Codes | Source XTestStep: 3a13d49c-1679-8305-b4e4-b1942d843ea7
    Then if field condition "'Class Code 2' != NULL" is satisfied, "Class Code Frame > Class Code Window > Select Class Code*" property "value" should equals "MASONRY NOC (5022)"
    Then I wait until "Class Code Frame > Class Code Window > OK-Class Code" exists
    When I click or select "Class Code Frame > Class Code Window > OK-Class Code"
    When I enter or select "{TAB}{CLICK}80000{TAB}" in "Class Code Frame > Class Code Window > Total Payroll (Estimated)"
    When if field condition "'Waiver of Subrogation Exposure' != NULL" is satisfied, I enter or select "25000{TAB}" in "Class Code Frame > Class Code Window > Waiver Of Subrogation Exposure*"
    When I enter or select "{TAB}{CLICK}4{TAB}" in "Class Code Frame > Class Code Window > Number of Part-Time Employees*"
    When I enter or select "{TAB}{CLICK}1{TAB}" in "Class Code Frame > Class Code Window > Number of Full-Time Employees*"
    When I click or select "Class Code Frame > Class Code Window > OK-Details"
    Then I wait until "Class Code Frame" no longer exists
    When I leave "Class Code Frame > Class Code Window" blank

    # Source step 0110: Navigate to Entity Schedule | Module: WC Navigation Links
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-7243-cae6-7ef89e5bbcc4
    # Source template XTestStep: 3a13d49c-1679-57cd-6a00-b07ca9c70ae1
    When I click or select "Entity Schedule"

    # Source step 0111: Wait for sync | Module: Entity Schedule|Main
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-e2f5-8164-8d2b6b57d0cc
    # Source template XTestStep: 3a13d49c-1679-a6d9-50d8-18b4879fb356
    Then I wait until "Entity Schedule" exists

    # Source step 0113: Enter First Entity Info | Module: Entity Schedule|First Entity Info
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-c9d8-426e-5b8050d0583f
    # Source template XTestStep: 3a13d49c-1679-012e-30b1-5c559463003a
    When I click or select "Detail"
    Then I wait until "Entity Info Frame > Entity Info Window > Insured Type" exists
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Entity Info Frame > Entity Info Window > Fax"
    When I enter or select "Test@test.com" in "Entity Info Frame > Entity Info Window > E-Mail"
    When I enter a RANDOM value matching "7 random digits/characters from source expression {RND[7]}{TAB}" in "Entity Info Frame > Entity Info Window > Bureau Number"
    When I enter a RANDOM value matching "6 random digits/characters from source expression {RND[6]}{TAB}" in "Entity Info Frame > Entity Info Window > State Unemployment Number Default"
    When I click or select "Entity Info Frame > Entity Info Window > OK"
    Then I wait until "Entity Info Frame" no longer exists

    # Source step 0114: Enter Location Assignment (up to NAICS) | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-ca24-2861-33ab1bb1324d
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

    # Source step 0115: NAICS is (select) | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-a7b4-bf40-8b89ab1218a5
    # Source template XTestStep: 3a13d49c-1679-e01e-7adf-1214ac72446f
    # Runtime control: If NAICS is (select) then reselect > check if NAICS is (select)
    Then "Location Assignment > Entity Location > Select Appropriate Code" property "value" should equals "(select)"
    Then I wait until "Location Assignment" no longer exists

    # Source step 0116: Enter Location Assignment | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-6351-5aa9-0546d1b818ca
    # Source template XTestStep: 3a13d49c-1679-1a32-14ab-7c5b432f2c79
    # Runtime control: If NAICS is (select) then reselect > Then
    When I enter or select "{CLICK}Testing Laboratories [541380]{TAB}{TAB}{Click}{TAB}{TAB}{TAB}" in "Location Assignment > Entity Location > Select Appropriate Code"
    Then "Location Assignment > Entity Location > Select Appropriate Code" property "value" should equals "{CLICK}Testing Laboratories [541380]"
    Then I wait until "Location Assignment" no longer exists

    # Source step 0117: Enter Location Assignment (after NAICS) | Module: Entity Schedule|Location Assignment
    # Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-44fa-ed3b-f1ec95a12811
    # Source template XTestStep: 3a13d49c-1679-c3e3-26cf-04fcb8073436
    Then "Location Assignment > Entity Location > Select Appropriate Code" property "value" should equals "Testing Laboratories [541380]"
    When I enter or select "X{TAB}{TAB}" in "Location Assignment > Entity Location > OK (First)"
    Then I wait until "Location Assignment > Entity Location > OK (Second)" no longer exists
    When I click or select "Location Assignment > Entity Location > OK"
    Then I wait until "Location Assignment" no longer exists

    # Source step 0118: Navigate to Endorsements Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Endorsements | Source XTestStep: 3a13d49c-1679-6b1b-2b0b-8ec18fd09f0b
    When I click or select "Endorsements"

    # Source step 0119: Endorsements - Waiton Add Endorsement Button | Module: Endorsements|Waiton Add Endorsement Button
    # Section: New Application - Data Entry Process | Reusable flow: WC|Endorsements | Source XTestStep: 3a13d49c-1679-59ff-a896-7b60f338659f
    When if field condition "State == \"NY\"" is satisfied, I enter or select "{TAB}{CLICK}No{TAB}" in "Are there any Officers that should be excluded?*"
    Then I wait until "Add Endorsement" exists

    # Source step 0120: Navigate to Endorsements Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Designated Workplaces Exclusion | Source XTestStep: 3a13d49c-1679-6cd9-3bda-23278680c303
    # Step condition: 'Endorsement Type' != NULL
    When I click or select "Endorsements"

    # Source step 0121: Endorsements|Designated Workplaces Exclusion | Module: Endorsements|Designated Workplaces Exclusion
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Designated Workplaces Exclusion | Source XTestStep: 3a13d49c-1679-28a9-9c04-5ff768f262f1
    # Step condition: 'Endorsement Type' != NULL
    Then I wait until "Add Endorsement" exists
    When I click or select "Add Endorsement"
    When if field condition "'Endorsement Type' != NULL" is satisfied, I enter or select "{TAB}Designated Workplaces Exclusion{TAB}" in "Endorsement Type"
    When if field condition "City != NULL" is satisfied, I enter or select "{TAB}Tempe{TAB}" in "City*"
    When if field condition "State != NULL" is satisfied, I enter or select "{TAB}AL{TAB}" in "State*"
    When I click or select "OK"

    # Source step 0122: Navigate to Endorsements Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Partners, Officers And Others Exclusion | Source XTestStep: 3a13d49c-1679-f7bc-b91b-f787c82d05c8
    # Step condition: 'Endorsement Type' != NULL
    When I click or select "Endorsements"

    # Source step 0123: Endorsements|Partners, Officers And Others Exclusion | Module: Endorsements|Partners, Officers And Others Exclusion
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Partners, Officers And Others Exclusion | Source XTestStep: 3a13d49c-1679-960a-7ec9-26b5d863bb14
    # Step condition: 'Endorsement Type' != NULL
    Then I wait until "Add Endorsement" exists
    When if field condition "'Endorsement Type' != NULL" is satisfied, I enter or select "{TAB}Partners, Officers And Others Exclusion{TAB}" in "Endorsement Type"
    When if field condition "(State!=\"MO\")&&(State!=\"ID\")" is satisfied, I click or select "Add Excluded Officer Information"
    When if field condition "(Officers != NULL)&&(State!=\"MO\")&&(State!=\"ID\")" is satisfied, I enter or select "{TAB}Bob, Ted and Phil{TAB}" in "Officers*"
    When if field condition "('Position Held' != NULL)&&(State!=\"MO\")&&(State!=\"ID\")" is satisfied, I enter or select "{TAB}President{TAB}" in "Officers Position Held*"
    When if field condition "(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")" is satisfied, I click or select "Add Excluded Others' Information"
    When if field condition "(State != \"IA\")&&(State != \"IN\")&&(State!=\"MA\")&&(State!=\"ID\")&&(State!=\"MS\")&&(State!=\"KY\")&&(State!=\"SC\")&&(State!=\"MT\")&&(State!=\"KS\")&&(State!=\"ME\")" is satisfied, I enter or select "{TAB}Nancy{TAB}" in "Others*"
    When I click or select "OK"
    When I click or select "Add Endorsement"

    # Source step 0124: Navigate to Endorsements Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Sole Proprietors, Partners, Officers And Others Coverage | Source XTestStep: 3a13d49c-1679-6c00-ce3f-a382014b459f
    # Step condition: 'Endorsement Type' != NULL
    When I click or select "Endorsements"

    # Source step 0125: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage | Module: Endorsements|Sole Proprietors, Partners, Officers And Others Coverage
    # Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Sole Proprietors, Partners, Officers And Others Coverage | Source XTestStep: 3a13d49c-1679-4e0d-5b92-f8313d4773e6
    # Step condition: 'Endorsement Type' != NULL
    Then I wait until "Add Endorsement" exists
    When I click or select "Add Endorsement"
    When if field condition "'Endorsement Type' != NULL" is satisfied, I enter or select "{TAB}Sole Proprietors, Partners, Officers And Others Coverage{TAB}" in "Endorsement Type"
    When I click or select "Add Sole Proprietor Information"
    When if field condition "'Sole Proprietors' != NULL" is satisfied, I enter or select "{TAB}Elon Musk{TAB}" in "Sole Proprietors*"
    When I click or select "Add Partner Information"
    When if field condition "Partners != NULL" is satisfied, I enter or select "{TAB}Martin, Harding & Mazzotti{TAB}" in "Partners*"
    When if field condition "(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")" is satisfied, I click or select "Add Others' Information"
    When if field condition "(State!=\"CO\")&&(State!=\"DE\")&&(State!=\"IA\")&&(State!=\"MN\")&&(State!=\"MO\")&&(State!=\"NH\")&&(State!=\"SD\")&&(State!=\"AL\")" is satisfied, I enter or select "{TAB}Dave{TAB}" in "Others*"
    When I click or select "OK"

    # Source step 0137: Navigate to UW Questions - Workers Comp Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|UW Questions|Fill Out WC UW Questions | Source XTestStep: 3a13d49c-1679-539e-f03a-b5fc6644e1ab
    When I click or select "UW Questions - Workers Comp"

    # Source step 0138: Fill Out Required Fields | Module: UW Questions - Workers Comp
    # Section: New Application - Data Entry Process | Reusable flow: WC|UW Questions|Fill Out WC UW Questions | Source XTestStep: 3a13d49c-1679-5d29-a810-d34320e76758
    Then I wait until "Update Answers" exists
    When I perform keyboard action "{TAB}" on "Update Answers"
    When I click or select "Update Answers"
    Then I wait until "Are physicals required after offers of employment are made?*" property "InnerText" does not equal "\"(select)\""
    When I perform keyboard action "{TAB}" on "List all policies with American National"
    When I enter or select "{TAB}{CLICK}{CLICK}9999W9999{TAB}{TAB}" in "List all policies with American National"

    # Source step 0139: Navigate to Pricing Screen | Module: WC Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-8672-69c9-1a7517673c1d
    When I click or select "Pricing"

    # Source step 0140: Wait for Pricing Screen to Load | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-9a9f-414a-1ab3569336d7
    Then I wait until "Pricing Detail" exists

    # Source step 0141: Go to Pricing Detail (necessary for refresh premium issue) | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-bedb-ad8b-19abc9edc4f6
    When I click or select "Pricing Detail"
    When I click or select "Pricing Detail - OK"

    # Source step 0142: Wait for Pricing Screen to Load | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Navigate to Pricing Screen | Source XTestStep: 3a13d49c-1679-e153-8e95-d4e1ecb6316e
    Then I wait until "Pricing Detail" exists

    # Source step 0143: Verify Invalid Class Codes Message Does not Exist | Module: Pricing
    # Section: New Application - Data Entry Process | Reusable flow: WC|Pricing|Verify Class Codes on Policy are Valid | Source XTestStep: 3a13d49c-1679-1e7d-effd-fbc9b4977a71
    Then "Invalid Class Code Message" should not exist

    # Source step 0144: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0145: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0146: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0147: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0148: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0149: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0150: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0151: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0152: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0153: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0154: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0155: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0156: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0157: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0158: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0159: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0160: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0161: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0162: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0163: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0164: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0165: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0209: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0210: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0211: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0212: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0213: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0214: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0218: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0219: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0220: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0221: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0222: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0223: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0224: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0225: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0269: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0270: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0271: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0272: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0273: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0274: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0275: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0276: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0290: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "8,673.00" as runtime value "NBPrem"

    # Source step 0291: Verify Premiums | Module: Submission|Premiums
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "*$8,673.00"
    Then "Premium Written" property "value" should equals "8,673.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "8,673.00"

    # Source step 0292: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0293: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0294: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0295: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0296: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0297: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0298: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\WC_StraightThrough_AL_{B[QuoteID]}.xml"

    # Source step 0304: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0305: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\\" -FileName \"WC_StraightThrough\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0306: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0307: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0308: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0309: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0310: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0311: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0312: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0313: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0314: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0316: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0317: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0318: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0319: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0320: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0084: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0085: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0088: "Navigate to Policy Covg Screen" in module "WC Navigation Links" was disabled. Reason: 12.11.21 15:54:39 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: WC|Policy Covg|Coverage Information | Source XTestStep: 3a13d49c-1679-8979-e3c1-b54df1772c6c
#    - INPUT "Policy Covg" with "x"
# Source step 0089: "Policy Covg" in module "Policy Covg" was disabled. Reason: 12.11.21 15:54:39 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: WC|Policy Covg|Coverage Information | Source XTestStep: 3a13d49c-1679-cf48-6712-a62ee1054e64
#    - WAIT (Exists) "Primary Location State*" with "True"
#    - VERIFY "Primary Location State*" with "{REGEX[\"(?i)\"Alabama]}"
#    - INPUT "Experience Rated" with "{TAB}{CLICK}Yes{TAB}"
#    - BUFFER "Default Experience Mod" with "ExpMod"
# Source step 0112: "Click Valen Score and Wait for sync" in module "Entity Schedule|Main" was disabled. Reason: Valen Contract ends 3/1/2021
# Section: New Application - Data Entry Process > WC|Entity Schedule_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-69e5-3e5f-b4c87b3031ba
#    - WAIT (Exists) "Get Valen Score" with "True"
#    - INPUT "Get Valen Score" with "X"
#    - WAIT (InnerText) "Score ID" with "a blank/null value"
#    - VERIFY (InnerText) "Bin #" with "a blank/null value"
#    - VERIFY (Exists) "Get Valen Score button must be selected to continue.*" with "False"
# Source step 0166: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0167: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0168: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0169: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0170: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0171: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0172: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0173: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0174: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0175: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0176: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0177: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0178: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0179: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0180: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0181: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0182: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0183: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0184: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0185: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0186: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0187: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0188: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0189: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0190: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0191: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0192: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0193: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0194: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0195: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0196: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0197: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0198: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0199: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0200: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0201: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0202: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0203: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0204: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0205: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0206: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0207: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0208: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0226: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0227: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0228: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0229: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0230: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0231: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0232: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0233: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0234: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0235: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0236: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0237: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0238: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0239: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0240: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0241: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0242: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0243: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0244: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0245: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0246: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0247: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0248: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0249: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0250: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0251: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0252: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0253: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0254: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0255: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0256: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0257: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\"
# Source step 0258: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0259: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0260: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0261: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0262: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0263: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0264: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0265: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0266: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0267: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0268: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0277: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0278: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0279: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0280: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0281: "Submission, select Policy Forms" in module "Submission, select Policy Forms" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-b954-0a7c-e98a92e77430
#    - INPUT "Policy Forms" with "x"
#    - WAIT (Exists) "Search" with "True"
#    - INPUT "Search for DEC Page" with "Declaration"
#    - INPUT "Search Button for DEC Page" with "x"
#    - INPUT "DEC LINK" with "x"
# Source step 0282: "Wait for Policy Forms to open" in module "TBox Wait" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8889-6242-e08fb28d4f40
#    - INPUT "Duration" with "9000"
# Source step 0283: "Close Policy Forms" in module "TBox Send Keys" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-582d-aae0-ba158c28662e
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0284: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-9a96-581e-d2b119b0020a
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0285: "Return to Submission Page" in module "Common Navigation Links" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8902-2720-581821968d05
#    - INPUT "Return to Policy" with "x"
# Source step 0286: "Submission, select Policy Admin Forms" in module "Submission, select Policy Forms" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-dcfb-265b-775fb7492386
#    - WAIT (Visible) "Policy Admin Forms" with "True"
#    - INPUT "Policy Admin Forms" with "x"
# Source step 0287: "Wait for Policy Admin Forms to open" in module "TBox Wait" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-5130-737f-d02663cba9f8
#    - INPUT "Duration" with "15000"
# Source step 0288: "Close Policy Admin Forms" in module "TBox Send Keys" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-c820-c654-7878ba2a4c1c
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0289: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 28.09.21 12:27:17 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-a6a9-8ecd-59b80f1bea38
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0299: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0300: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0301: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0302: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\WC_StraightThrough_AL_{B[QuoteID]}.xml"
# Source step 0303: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\WC_StraightThrough_AL_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0315: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0321: "Verify Premium" in module "Pricing" was disabled. Reason: 21.09.21 14:43:33 [ff01729]
# Section: WC|Pricing|Verify Premium_Reference | Reusable flow: <none> | Source XTestStep: 3a13d49c-1589-1ebd-3e72-3d746b3bf5d0
#    - VERIFY "Premium" with "*$8,673.00"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  WorkersCompensation  Pages   US   (9.8.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0073 "Enter Effective Date" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}" when 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL"
# Active source step 0075 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "{Click}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
# Source step 0077: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Source step 0079: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
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
# Active source step 0081 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "PrimaryRatingState" with "True" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0086 "Policy Info | WC Specific Fields" contains conditionally inapplicable field action(s):
#    - INPUT "Does applicant have a commitment to Workplace Safety and Risk Management?*" with "{CLICK}Yes{ENTER}{TAB}" when 'Workplace Saftey Question' == "Applies". Reason: Value condition evaluated false for the selected iteration: 'Workplace Saftey Question' == "Applies"
# Active source step 0087 "Policy Info | Estimated Premium" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "Estimated Premium*" with "True" when 'Estimated Premium' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Estimated Premium' != NULL
#    - INPUT "Estimated Premium*" with "Over{ENTER}{TAB}" when 'Estimated Premium' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Estimated Premium' != NULL
# Active source step 0095 "State Details - Main Questions" contains conditionally inapplicable field action(s):
#    - INPUT "AR Small Deductible Selection" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: AR Small Deductible Selection>{TAB})" when 'AR Small Deductible Selection' != NULL. Reason: Value condition evaluated false for the selected iteration: 'AR Small Deductible Selection' != NULL
#    - INPUT "Small Deductible Type|Selection" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Small Deductible Type>{TAB})" when 'Small Deductible Type' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Small Deductible Type' != NULL
#    - INPUT "Alcohol/Drug-Free Workplace" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Alcohol Drug Free Workplace>{TAB}{TAB})" when 'Alcohol Drug Free Workplace' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Alcohol Drug Free Workplace' != NULL
#    - INPUT "Deductible Selection" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Deductible Selection>{TAB})" when 'Deductible Selection' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Deductible Selection' != NULL
#    - INPUT "Certified Safety Committee Credit Program Indicator" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Certified Safety Committee Credit Program Indicator>{TAB})" when 'Certified Safety Committee Credit Program Indicator' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Certified Safety Committee Credit Program Indicator' != NULL
# Source step 0098: "State Details|Check for Pending Rate Change Effective Date" in module "State Details|Main" was not executed. Reason: Selected-iteration condition evaluated false: 'Pending Rate Change' != No
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|State Details|Rating Information | Source XTestStep: 3a13d49c-1679-7afc-dd3c-acfd86577c46
#    - Preserved source field action: VERIFY "Pending Rate Change Effective Date" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Pending Rate Change Effective Date>)" when 'Pending Rate Change Effective Date' != NULL
# Active source step 0104 "Input First Class Code Details" contains conditionally inapplicable field action(s):
#    - INPUT "Class Code Frame > Class Code Window > Total Payroll (Estimated)" with "{TAB}{CLICK}500000{TAB}" when State == "MD". Reason: Value condition evaluated false for the selected iteration: State == "MD"
# Active source step 0123 "Endorsements|Partners, Officers And Others Exclusion" contains conditionally inapplicable field action(s):
#    - INPUT "% Officers Ownership Interest*" with "{TAB}10{TAB}" when (State=="CO")&&(State=="PA")&&(State!="ID"). Reason: Value condition evaluated false for the selected iteration: (State=="CO")&&(State=="PA")&&(State!="ID")
#    - INPUT "Officers Date Of Birth" with "{TAB}01141975{TAB}" when State=="NH". Reason: Value condition evaluated false for the selected iteration: State=="NH"
#    - INPUT "Others Position Held" with "{TAB}President{TAB}" when State=="NH". Reason: Value condition evaluated false for the selected iteration: State=="NH"
#    - INPUT "% Others Ownership Interest*" with "{TAB}25{TAB}" when (State=="CO")&&(State=="PA")&&(State!="ID"). Reason: Value condition evaluated false for the selected iteration: (State=="CO")&&(State=="PA")&&(State!="ID")
#    - INPUT "Others Date Of Birth" with "{TAB}01141975{TAB}" when State=="NH". Reason: Value condition evaluated false for the selected iteration: State=="NH"
#    - INPUT "Add Excluded Sole Proprietor Information" with "x" when State=="ID". Reason: Value condition evaluated false for the selected iteration: State=="ID"
#    - INPUT "Sole Proprietors*" with "Tommy{TAB}" when State=="ID". Reason: Value condition evaluated false for the selected iteration: State=="ID"
# Active source step 0125 "Endorsements|Sole Proprietors, Partners, Officers And Others Coverage" contains conditionally inapplicable field action(s):
#    - INPUT "Sole Proprietors Date Of Birth*" with "{TAB}01141975{TAB}" when State=="NH". Reason: Value condition evaluated false for the selected iteration: State=="NH"
#    - INPUT "Partners Date Of Birth*" with "{TAB}01141975{TAB}" when State=="NH". Reason: Value condition evaluated false for the selected iteration: State=="NH"
# Source step 0126: "Navigate to Endorsements Screen" in module "WC Navigation Links" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Minnesota Third Degree of Kindred Family Member Exclusion Endorsement | Source XTestStep: 3a13d49c-1679-3183-89b8-2cb71c699a8a
#    - Preserved source field action: INPUT "Endorsements" with "x"
# Source step 0127: "Endorsements|Minnesota Third Degree of Kindred Family Member Exclusion Endorsement" in module "Endorsements|Minnesota Third Degree of Kindred Family Member Exclusion Endorsement" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Minnesota Third Degree of Kindred Family Member Exclusion Endorsement | Source XTestStep: 3a13d49c-1679-e3a2-f818-874e9f94e9f4
#    - Preserved source field action: WAIT (Exists) "Add Endorsement" with "True"
#    - Preserved source field action: INPUT "Add Endorsement" with "x"
#    - Preserved source field action: INPUT "Endorsement Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{TAB})" when 'Endorsement Type' != NULL
#    - Preserved source field action: INPUT "Add Family Member" with "x"
#    - Preserved source field action: INPUT "Family Member*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Family Member>{TAB})" when 'Family Member' != NULL
#    - Preserved source field action: INPUT "Relationship to Executive Officer or LLC Manager*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Relationship to Executive Officer or LLC Manager>{TAB})" when 'Relationship to Executive Officer or LLC Manager' != NULL
#    - Preserved source field action: INPUT "Executive Officer or LLC Manager*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Executive Officer or LLC Manager>{TAB})" when 'Executive Officer or LLC Manager' != NULL
#    - Preserved source field action: INPUT "OK" with "x"
# Source step 0128: "Navigate to Endorsements Screen" in module "WC Navigation Links" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Sole Proprietors Partners Officers And Others Coverage | Source XTestStep: 3a13d49c-1679-dbd7-8543-8fa249793dff
#    - Preserved source field action: INPUT "Endorsements" with "x"
# Source step 0129: "Endorsements|Sole Proprietors, Partners, Officers And Others Coverage" in module "Endorsements|Sole Proprietors, Partners, Officers And Others Coverage" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Sole Proprietors Partners Officers And Others Coverage | Source XTestStep: 3a13d49c-1679-9461-07d7-28aac9f16fb8
#    - Preserved source field action: WAIT (Exists) "Add Endorsement" with "True"
#    - Preserved source field action: INPUT "Add Endorsement" with "x"
#    - Preserved source field action: INPUT "Endorsement Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{TAB})" when 'Endorsement Type' != NULL
#    - Preserved source field action: INPUT "Add Sole Proprietor Information" with "x"
#    - Preserved source field action: INPUT "Sole Proprietors*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Sole Proprietors>{TAB})" when 'Sole Proprietors' != NULL
#    - Preserved source field action: INPUT "Sole Proprietors Date Of Birth*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Date of Birth>{TAB})" when State=="NH"
#    - Preserved source field action: INPUT "Add Partner Information" with "x"
#    - Preserved source field action: INPUT "Partners*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Partners>{TAB})" when Partners != NULL
#    - Preserved source field action: INPUT "Partners Date Of Birth*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Date of Birth>{TAB})" when State=="NH"
#    - Preserved source field action: INPUT "Add Others' Information" with "x" when (State!="CO")&&(State!="DE")&&(State!="IA")&&(State!="MN")&&(State!="MO")&&(State!="NH")&&(State!="AL")
#    - Preserved source field action: INPUT "Others*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Others>{TAB})" when (State!="CO")&&(State!="DE")&&(State!="IA")&&(State!="MN")&&(State!="MO")&&(State!="NH")&&(State!="AL")
#    - Preserved source field action: INPUT "OK" with "x"
# Source step 0130: "Navigate to Endorsements Screen" in module "WC Navigation Links" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Executive Officers Exclusion | Source XTestStep: 3a13d49c-1679-b0e9-2747-8d8280387322
#    - Preserved source field action: INPUT "Endorsements" with "x"
# Source step 0131: "Endorsements|Executive Officers Exclusion" in module "Endorsements|Executive Officers Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsements Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Executive Officers Exclusion | Source XTestStep: 3a13d49c-1679-ff84-234d-d57b132ec0e2
#    - Preserved source field action: WAIT (Exists) "Add Endorsement" with "True"
#    - Preserved source field action: INPUT "Endorsement Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Endorsements Type>{TAB})"
#    - Preserved source field action: INPUT "Add Excluded Officer Information" with "x"
#    - Preserved source field action: WAIT (Exists) "Type Of Corporation*" with "True"
#    - Preserved source field action: INPUT "Officers*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Officers>{TAB})"
#    - Preserved source field action: INPUT "Position Held*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Position Held>{TAB})"
#    - Preserved source field action: INPUT "Type Of Corporation*" with "a blank/not-supplied reusable parameter ({TAB}{CLICK}<BLANK — reusable-block parameter is not supplied: Type of Corporation>{DOWN}{TAB}{TAB})" when 'Type of Corporation' != NULL
#    - Preserved source field action: INPUT "% Ownership Interest*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: % of Officers Ownership Interest>{TAB})"
#    - Preserved source field action: INPUT "Add Endorsement" with "x"
# Source step 0132: "Endorsements|Executive Officers Exclusion" in module "Endorsements|Executive Officers Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsements Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Executive Officers Exclusion | Source XTestStep: 3a13d49c-1679-78ec-ea7c-67e1fb462a0f
#    - Preserved source field action: INPUT "Type Of Corporation*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Type of Corporation>{TAB}{TAB})" when 'Type of Corporation' != NULL
#    - Preserved source field action: INPUT "OK" with "x"
# Source step 0133: "Navigate to Endorsements Screen" in module "WC Navigation Links" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Statutory Employer Exclusion | Source XTestStep: 3a13d49c-1679-dd7e-a6ba-147f55c275d8
#    - Preserved source field action: INPUT "Endorsements" with "x"
# Source step 0134: "Endorsements|Statutory Employer Exclusion" in module "Endorsements|Statutory Employer Exclusion" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsements Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Statutory Employer Exclusion | Source XTestStep: 3a13d49c-1679-8c67-5432-dd76ba7a29bb
#    - Preserved source field action: WAIT (Exists) "Add Endorsement" with "True"
#    - Preserved source field action: INPUT "Statutory Employer*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Statutory Employer>{TAB})"
#    - Preserved source field action: INPUT "Endorsement Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Endorsements Type>{TAB})"
#    - Preserved source field action: INPUT "Description of Operations*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Description of Operations>{TAB})"
#    - Preserved source field action: INPUT "OK" with "x"
#    - Preserved source field action: INPUT "Add Endorsement" with "x"
# Source step 0135: "Navigate to Endorsements Screen" in module "WC Navigation Links" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Principal as Additional Insured | Source XTestStep: 3a13d49c-1679-e442-4288-b02e851d6291
#    - Preserved source field action: INPUT "Endorsements" with "x"
# Source step 0136: "Endorsements|Principal As Additional Insured" in module "Endorsements|Principal As Additional Insured" was not executed. Reason: Selected-iteration condition evaluated false: 'Endorsement Type' != NULL
# Section: New Application - Data Entry Process | Reusable flow: WC|StraightThrough|Endorsements|Add Principal as Additional Insured | Source XTestStep: 3a13d49c-1679-2c2e-d16c-35bceafaad85
#    - Preserved source field action: WAIT (Exists) "Add Endorsement" with "True"
#    - Preserved source field action: INPUT "Add Endorsement" with "x"
#    - Preserved source field action: INPUT "Endorsement Type" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Endorsement Type>{TAB})"
#    - Preserved source field action: INPUT "Principal*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Principal>{TAB})"
#    - Preserved source field action: INPUT "Operations*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Operations>{TAB})"
#    - Preserved source field action: INPUT "Name of Project/Construction of Building*" with "a blank/not-supplied reusable parameter ({TAB}<BLANK — reusable-block parameter is not supplied: Name of Project/Construction of Building>{TAB})"
#    - Preserved source field action: INPUT "OK" with "x"
# Source step 0215: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0216: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0217: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-1589-c4a8-e2b8-7438f2c47f0e
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\WC\\WCBASICTestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-1589-dbd9-b3d4-11acaf8c42b5
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\WC\\WC BASIC TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-1589-eab2-a80f-3ecc7c951f07
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\WC\\WC BASIC TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-1589-0710-fad8-e9181f8f2784
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-1589-dacc-eb87-375901f6a18d
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-1589-682b-e847-a76ee0dc104d
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-1589-93c3-380d-dc2a80c6241a
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-1589-5681-94f2-bd742e63c22d
#    - I run "taskkill /f /im msEdge.exe"
