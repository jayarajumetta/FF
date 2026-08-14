# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 005_GL_Basic_Policy_AZ.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @GL @basic_policy @Arizona @Edge @manual @automated
Feature: Execute GL | Basic Policy for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the GL | Basic Policy workflow for Arizona (AZ)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: GL | Basic Policy using representative iteration Arizona (AZ)

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
    When I enter or select "AZ{TAB}{TAB}" in "Middle Name"
    When I enter or select "{TAB}{TAB}" in "Last Name"
    When I enter RUNTIME-DERIVED value "{DATE[][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "DOB"
    When if field condition "State!=\"CA\"" is satisfied, I enter or select "Male{TAB}{TAB}" in "Gender"
    When I enter a RANDOM value matching "^[a-z]{4}$" in "Last Name"

    # Source step 0041: Select Individual Sole Proprietor | Module: Client|Named Insured|Common
    # Section: New Application - Data Entry Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-f281-684f-979ca5404005
    When I enter or select "Individual/Sole Proprietor{ENTER}{TAB}{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I enter or select "{TAB}4201 N. 24th St{TAB}" in "Address1"
    When I enter or select "{TAB}85016{TAB}" in "ZipCode"

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
    When I retain hard-coded value "AZ" as runtime value "State"
    When I retain hard-coded value "GL" as runtime value "Product (LOB)"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"
    When I retain hard-coded value "GL_BASIC" as runtime value "FormOnPolicyDocName"

    # Source step 0051: Navigate to Underwriting Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Client|Complete Underwriting Info from Client Screen | Source XTestStep: 3a13d49c-165b-525c-4c6c-ebd6ba6f2236
    When I click or select "Underwriting Info"

    # Source step 0052: Underwriting Info | General UW Questions | Module: Underwriting Info | General UW Questions
    # Section: New Application - Data Entry Process | Reusable flow: Common|Client|Complete Underwriting Info from Client Screen | Source XTestStep: 3a13d49c-165b-2e2b-99e0-851a84f50fb1
    Then I wait until "General UW Questions" exists
    When I click or select "Update Answers"

    # Source step 0053: Add Prior Carrior details on Loss Information Screen | Module: Underwriting Info | Other Insurance History
    # Section: New Application - Data Entry Process | Reusable flow: Common|Client|Complete Underwriting Info from Client Screen | Source XTestStep: 3a13d49c-165b-9564-bb2c-902eb86be7d1
    When I click or select "Insurance History"
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

    # Source step 0054: Indicate No Known Losses on Loss Experience Screen | Module: Underwriting Info | Loss Experience
    # Section: New Application - Data Entry Process | Reusable flow: Common|Client|Complete Underwriting Info from Client Screen | Source XTestStep: 3a13d49c-165b-b36f-0124-9798fddff22f
    When I click or select "Loss Experience"
    Then I wait until "No known losses" exists
    When I enter or select "True{TAB}" in "No known losses"

    # Source step 0055: Click Return to Quote | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Client|Complete Underwriting Info from Client Screen | Source XTestStep: 3a13d49c-165b-df64-ef51-cb3542a4bb1b
    When I click or select "Return to Quote"

    # Source step 0056: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0057: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0058: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0059: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0060: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "10/17/2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0061: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0062: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Arizona{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0063: State is Kansas | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"

    # Source step 0065: State is Virginia | Module: TBox Evaluation Tool
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"

    # Source step 0066: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
    # Runtime control: If State is Virginia > Then
    When if field condition "'Product (LOB)' == \"GL\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"GL\"" is satisfied, I enter or select "Arizona{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0067: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0068: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0069: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0070: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AZ GL Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0073: Navigate to Policy Coverage Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Policy Covg|Fill out CGL Fields | Source XTestStep: 3a13d49c-166a-16fb-789d-1d5ec68b95b2
    # Step condition: 'Product' != "CPP"
    When I click or select "Policy Covg"

    # Source step 0074: Policy Covg|GL | Module: Policy Covg|GL
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Policy Covg|Fill out CGL Fields | Source XTestStep: 3a13d49c-166a-cfc7-5cbf-00ce7a96310a
    Then I wait until "Policy Covg" exists
    When if field condition "'Coverage Form' != NULL" is satisfied, I enter or select "{CLICK}CGL{ENTER}{TAB}" in "Coverage Form"
    When if field condition "'Occurence Limit' != NULL" is satisfied, I enter or select "{CLICK}$500,000{ENTER}{TAB}" in "Occurence Limit"
    When if field condition "'Aggregate Limit' != NULL" is satisfied, I enter or select "{CLICK}$200,000{ENTER}{TAB}" in "Aggregate Limit"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "$200,000{TAB}" in "Products Agg Limit"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "BI{TAB}" in "Ded Type"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "Per Claim{TAB}" in "Deductible Basis"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "$500{TAB}" in "PremOp Ded"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I leave "PremOp PD Ded" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "True{TAB}" in "Split BI Ded"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I leave "Split PD Ded" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "{CLICK}$500{TAB}" in "Prod BI Ded"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I leave "Prod PD Ded" blank because the reusable parameter is not supplied for this iteration
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "Include{TAB}" in "Fire Damage"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "Include{TAB}" in "Medical"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "Include{TAB}" in "Pers Adv Inj"
    When if field condition "'Coverage Form' != \"OCP\"" is satisfied, I enter or select "{CLICK}No{ENTER}{TAB}" in "Is the Insured engaged in any Snow or Ice Removal Operations?*"
    When if field condition "(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\"" is satisfied, I enter or select "1{TAB}" in "# of Full-Time Employees*"
    When if field condition "(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\") ||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\")||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\"" is satisfied, I enter or select "5{TAB}" in "# of Part-Time Employees*"
    When if field condition "(State==\"NY\")||(State == \"NJ\")||(State == \"WV\")||(State == \"MA\")||(State == \"CT\")||(State == \"ME\")||(State == \"NH\")||(State == \"OR\") ||(State == \"AZ\")||(State == \"PA\")||(State == \"MD\")||(State == \"DE\")||(State == \"RI\")||(State == \"VA\")||(State == \"VT\")&& 'Coverage Form' != \"OCP\"" is satisfied, I enter or select "15{TAB}" in "# of Seasonal/Temporary Employees*"
    Then if field condition "'Coverage Form' != NULL" is satisfied, I wait until "Coverage Form" property "value" equals "CGL"

    # Source step 0075: Navigate to CGL Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|CGL|Add Class | Source XTestStep: 3a13d49c-166a-c4b8-b5d5-6b2581f7e684
    When I click or select "CGL"

    # Source step 0076: CGL|Main Page | Module: CGL|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|CGL|Add Class | Source XTestStep: 3a13d49c-166a-2260-5645-30fc5b26ea7c
    Then I wait until "CGL" exists
    When I click or select "Add Class"

    # Source step 0077: CGL|Add Class | Module: CGL|Add Class
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|CGL|Add Class | Source XTestStep: 3a13d49c-166a-5aa1-abc0-57966d6fa46f
    When I enter or select "[13590] - Glass Dealers and Glaziers{TAB}" in "Search Results"
    When I click or select "OK"

    # Source step 0078: CGL|Add Class Exposure | Module: CGL|Main Page
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|CGL|Add Class | Source XTestStep: 3a13d49c-166a-f104-3061-dad5f0e9c721
    When I enter or select "50000{TAB}" in "Exposure"
    When I click or select "OK"

    # Source step 0079: Navigate to Endorsements Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG0435] Employee Benefits Liability Endorsement | Source XTestStep: 3a13d49c-166a-ec08-c4b6-a62779902829
    # Step condition: 'Endorsement Type' != NULL
    When if field condition "'Navigate to Endorsements Screen first time' != NULL" is satisfied, I click or select "Endorsements"

    # Source step 0080: Endorsements|Main | Module: Endorsements|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG0435] Employee Benefits Liability Endorsement | Source XTestStep: 3a13d49c-166a-006e-2ef7-e3cdb016bfa4
    Then I wait until "Endorsements" exists
    When I click or select "Add Endorsement"

    # Source step 0081: Add [CG0435] Employee Benefits Liability Endorsement | Module: [CG0435] Employee Benefits Liability
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG0435] Employee Benefits Liability Endorsement | Source XTestStep: 3a13d49c-166a-da01-ae0e-b907bdcdd2d9
    # Step condition: 'Endorsement Type' != NULL
    When I enter or select "[CG0435] Employee Benefits Liability{TAB}" in "Endorsement Type"
    When I enter or select "5{TAB}" in "Number Of Employees"
    When I click or select "OK"

    # Source step 0082: Navigate to Endorsements Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Source XTestStep: 3a13d49c-166a-cba1-1bc5-327a48499e73
    # Step condition: 'Endorsement Type' != NULL
    When if field condition "'Navigate to Endorsements Screen first time' != NULL" is satisfied, I click or select "Endorsements"

    # Source step 0083: Endorsements|Main | Module: Endorsements|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Source XTestStep: 3a13d49c-166a-fd61-655b-835afaef644f
    Then I wait until "Endorsements" exists
    When I click or select "Add Endorsement"

    # Source step 0084: Add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) Endorsement | Module: [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations)
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Source XTestStep: 3a13d49c-166a-0a00-dcb0-c3a365bf42d8
    # Step condition: 'Endorsement Type' != NULL
    When I enter or select "[CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations){TAB}" in "Endorsement Type"
    When I enter or select "True{TAB}" in "Exclude Explosion Hazard"
    When I enter or select "True{TAB}" in "Exclude Collapse Hazard"
    When I enter or select "True{TAB}" in "Exclude Underground Property Damage Hazard"
    When I enter or select "Test{TAB}" in "Description of Operation(s)"
    When if field condition "State != \"VA\"" is satisfied, I click or select "OK"

    # Source step 0085: Navigate to Endorsements Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG 2149] Total Pollution Exclusion Endorsement | Source XTestStep: 3a13d49c-166a-8618-6f3e-1460b84104f6
    # Step condition: 'Endorsement Type' != NULL
    When if field condition "'Navigate to Endorsements Screen first time' != NULL" is satisfied, I click or select "Endorsements"

    # Source step 0086: Endorsements|Main | Module: Endorsements|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG 2149] Total Pollution Exclusion Endorsement | Source XTestStep: 3a13d49c-166a-81cc-762b-9a0242f3d531
    Then I wait until "Endorsements" exists
    When I click or select "Add Endorsement"

    # Source step 0087: Add [CG 2149] Total Pollution Exclusion Endorsement | Module: [CG 2149] Total Pollution Exclusion Endorsement
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add [CG 2149] Total Pollution Exclusion Endorsement | Source XTestStep: 3a13d49c-166a-6133-049d-ed960f44a311
    # Step condition: 'Endorsement Type' != NULL
    When I enter or select "[CG 2149] Total Pollution Exclusion Endorsement{TAB}" in "Endorsement Type"
    When I click or select "OK"

    # Source step 0088: FG0055 EPLI Table | Module: FG0055 EPLI Table
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Verify and Fill out [FG0055] Employment Practices Liability Insurance Coverage Endorsement | Source XTestStep: 3a1786d2-1117-889c-d5bf-e007d959373d
    Then I wait until "FG0055 Table > <Row> > FG0055" exists
    Then "FG0055 Table > <Row> > Employment Practices Liability Insurance Coverage Endorsement" should exist
    When I click or select "FG0055 Table > <Row> > Detail"

    # Source step 0089: [FG0055] Employment Practices Liability Insurance Coverage Endorsement | Module: [FG0055, FG0062, FG0063, FG0069, FG0071, FG0072, FG0074, FG0077, FG0078] Employment Practices Liability Insurance Coverage Endorsement
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Verify and Fill out [FG0055] Employment Practices Liability Insurance Coverage Endorsement | Source XTestStep: 3a13d49c-166a-f069-ebb4-6f4038d6f145
    When I enter or select "$25,000/$2,500{TAB}" in "Limit/Deductible*"
    When I enter or select "No{TAB}" in "Has the insured ever had a claim for Employment Practices?*"
    When I enter or select "No{TAB}" in "The insured and any executive, officer or owner has knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?*"
    When I enter or select "No{TAB}" in "Third Party*"
    When I click or select "OK"

    # Source step 0090: Navigate to Addl Interests Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2007] - Engineers | Source XTestStep: 3a13d49c-166a-93ef-d805-3dc5baebd687
    When I click or select "Addl Interests"

    # Source step 0091: Select Addl Interests Button | Module: Addl Interests|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2007] - Engineers | Source XTestStep: 3a13d49c-166a-a15e-8eec-4cd4e4cd55a3
    Then I wait until "Addl Interests" exists
    When I click or select "Add Addl Interest"

    # Source step 0092: Add [CG 20 07] Add'l Insured-Engineers, Architects | Module: [CG 20 07] Add'l Insured-Engineers, Architects
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2007] - Engineers | Source XTestStep: 3a13d49c-166a-7f63-6e8c-ae4d04ebb868
    Then if field condition "Type != NULL" is satisfied, I wait until "Type" exists
    When I click or select "OK"
    When if field condition "Type != NULL" is satisfied, I click or select "Type"
    When if field condition "Type != NULL" is satisfied, I enter or select "[CG 20 07] Add'l Insured-Engineers, Architects{ENTER}{TAB}" in "Type"

    # Source step 0093: Navigate to Addl Interests Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2020] Add'l Insured-Charitable Institution | Source XTestStep: 3a13d49c-166a-6814-7383-f4888c2902f5
    When I click or select "Addl Interests"

    # Source step 0094: Select Addl Interests Button | Module: Addl Interests|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2020] Add'l Insured-Charitable Institution | Source XTestStep: 3a13d49c-166a-4755-3d7d-1d67408e1daf
    Then I wait until "Addl Interests" exists
    When I click or select "Add Addl Interest"

    # Source step 0095: Add [CG 20 20] Add'l Insured-Charitable Institution | Module: [CG 20 20] Add'l Insured-Charitable Institution
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2020] Add'l Insured-Charitable Institution | Source XTestStep: 3a13d49c-166a-ce5e-95c3-a0cc2af5658d
    When if field condition "Type != NULL" is satisfied, I enter or select "[CG 20 20] Add'l Insured-Charitable Institution{TAB}" in "Type"
    When if field condition "'Type of License' != NULL" is satisfied, I enter or select "{TAB}{CLICK}Hunting{TAB}" in "Type of License"
    When I click or select "OK"

    # Source step 0096: Navigate to Addl Interests Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2023] Add'l Insured-Executors | Source XTestStep: 3a13d49c-166a-3263-b693-9747d8c8f364
    When I click or select "Addl Interests"

    # Source step 0097: Select Addl Interests Button | Module: Addl Interests|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2023] Add'l Insured-Executors | Source XTestStep: 3a13d49c-166a-8f17-4645-6d99e32b6a5c
    Then I wait until "Addl Interests" exists
    When I click or select "Add Addl Interest"

    # Source step 0098: Add [CG 20 23] Add'l Insured-Executors | Module: [CG 20 23] Add'l Insured-Executors 
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2023] Add'l Insured-Executors | Source XTestStep: 3a13d49c-166a-a681-3b99-c5d3ec7025fd
    When if field condition "Type != NULL" is satisfied, I enter or select "[CG 20 23] Add'l Insured-Executors {TAB}" in "Type"
    When I click or select "OK"

    # Source step 0099: Navigate to Addl Interests Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2025] Add'l Insured-Executive Officers | Source XTestStep: 3a13d49c-166a-cddd-7417-fc2026d8bca0
    When I click or select "Addl Interests"

    # Source step 0100: Select Addl Interests Button | Module: Addl Interests|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2025] Add'l Insured-Executive Officers | Source XTestStep: 3a13d49c-166a-f2ea-27d5-289a5ebea5c9
    Then I wait until "Addl Interests" exists
    When I click or select "Add Addl Interest"

    # Source step 0101: Add [CG 20 25] Add'l Insured-Executive Officers | Module: [CG 20 25] Add'l Insured-Executive Officers 
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2025] Add'l Insured-Executive Officers | Source XTestStep: 3a13d49c-166a-3341-b148-09eba59eef62
    When if field condition "Type != NULL" is satisfied, I enter or select "[CG 20 25] Add'l Insured-Executive Officers {TAB}" in "Type"
    When I click or select "OK"

    # Source step 0102: Navigate to Addl Interests Screen | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic | Source XTestStep: 3a13d49c-166a-9cf8-2461-0dfeae00a1e7
    When I click or select "Addl Interests"

    # Source step 0103: Select Addl Interests Button | Module: Addl Interests|Main
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic | Source XTestStep: 3a13d49c-166a-061d-cdd4-a2bcdc87795a
    Then I wait until "Addl Interests" exists
    When I click or select "Add Addl Interest"

    # Source step 0104: Add [CG 20 34] Add'l Insured-Leased Equipment Automatic | Module: [CG 20 34] Add'l Insured-Leased Equipment Automatic 
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic | Source XTestStep: 3a13d49c-166a-1e41-e6dd-9df2cf4fbf50
    When if field condition "Type != NULL" is satisfied, I enter or select "[CG 20 34] Add'l Insured-Leased Equipment Automatic {TAB}" in "Type"
    When if field condition "'Type of Equipment' != NULL" is satisfied, I enter or select "{CLICK}Trailer{TAB}" in "Type of Equipment"
    When I click or select "OK"

    # Source step 0105: Navigate to NotePad Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-d381-f850-b8261baf619a
    When I click or select "Notepad"

    # Source step 0106: Add Notes/Remarks to NotePad | Module: NotePad
    # Section: New Application - Data Entry Process | Reusable flow: Common|NotePad|Add NotePad Comment | Source XTestStep: 3a13d49c-165b-7369-f1cb-a7ea298714bf
    Then I wait until "Notepad Heading" exists
    When I click or select "Add Notes/Remarks"
    When I enter captured RUNTIME-DERIVED value "Test {B[Product (LOB)]}" in "TextBox"
    When I click or select "OK"

    # Source step 0107: Navigate to GL UW Questions | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Answer GL UW Questions OR & WA | Source XTestStep: 3a13d49c-166a-10ab-66af-cd4ce911d42e
    When I click or select "GL UW Questions"

    # Source step 0108: Answer General Liability Information Questions | Module: General Liability Information
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Answer GL UW Questions OR & WA | Source XTestStep: 3a13d49c-166a-ecd5-d345-078f02d2a7ca
    Then I wait until "General Liability Information" exists
    When I click or select "Update Answers"
    When I enter or select "{TAB}Non Binding Contracts.{TAB}" in "Describe all hold harmless agreements and please provide a copy."
    When I click or select "OK"

    # Source step 0109: Navigate to GL UW Questions | Module: GL Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Answer GL UW Questions OR & WA | Source XTestStep: 3a13d49c-166a-31a1-c49d-322b7fbb9afc
    When I click or select "GL UW Questions"

    # Source step 0110: Wait for General Liability Screen to Load | Module: General Liability Information
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Answer GL UW Questions OR & WA | Source XTestStep: 3a13d49c-166a-e939-ae77-63e83f611bef
    Then I wait until "General Liability Information" exists

    # Source step 0111: Answer Products/Completed Ops Question | Module: Products/Completed Ops
    # Section: New Application - Data Entry Process | Reusable flow: GL|Basic|Answer GL UW Questions OR & WA | Source XTestStep: 3a13d49c-166a-813f-86ab-96add7169cc1
    When I click or select "Products/Completed Ops Button"
    Then I wait until "Products/Completed Ops" exists
    When I click or select "Update Answers"
    When I click or select "OK"

    # Source step 0112: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    When I click or select "Billing"

    # Source step 0113: Fill Out Required Fields on Billing Screen | Module: Billing
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

    # Source step 0114: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    When I wait "3000" milliseconds

    # Source step 0115: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-8f3a-657b-95ab25577f2d
    Then I wait until "Submission" is visible
    When I click or select "Submission"

    # Source step 0116: Fill out Required Fields | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-d04b-32cd-e097bd43b65f
    Then I wait until "Submission Heading" exists
    When I enter or select "{TAB}{CLICK}Yes{TAB}" in "Is this coverage bound?*"

    # Source step 0117: Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-fc17-9b79-db86f9cbd8b4
    # Runtime control: If Order Audit Exists > Check for Order Audit
    Then "Order Audit" should exist

    # Source step 0118: Fill out Order Audit | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission| Fill out Required Fields | Source XTestStep: 3a13d49c-165b-765c-94e8-6c488bddec5b
    # Runtime control: If Order Audit Exists > Then
    When I enter or select "No{TAB}" in "Order Audit"

    # Source step 0119: Check to see Submission Screen Header Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
    # Runtime control: Determine if on submission page > Condition
    Then "Submission Heading" should not exist

    # Source step 0120: Navigate to Submission Screen | Module: Common Navigation Links
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
    # Runtime control: Determine if on submission page > Then
    When I perform keyboard action "{TAB}" on "Submission"
    When I click or select "Submission"

    # Source step 0121: Wait for Synchronization | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
    # Runtime control: Determine if on submission page > Then
    When I wait "1250" milliseconds

    # Source step 0122: Wait on Submission Screen to Load | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
    # Runtime control: Determine if on submission page > Then
    Then I wait until "Submission Heading" exists

    # Source step 0123: 500ms wait for syncing | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
    # Runtime control: Determine if on submission page > Then
    When I wait "500" milliseconds

    # Source step 0124: Check to see Coverage is bound Exists | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-0f53-7da8-1e0d14e4c350
    # Runtime control: If Coverage is bound exists, make sure it is answered > Condition
    Then "Is this coverage bound?*" should exist

    # Source step 0125: Check Is Coverage bound (select) | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-32fe-804f-6cce2a927ae8
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Condition
    Then "Is this coverage bound?*" property "Value" should equals "(select)"

    # Source step 0126: Answer Is Coverage bound | Module: Submission|Required and Optional Fields
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-d5fb-88f1-9b2cda59e53c
    # Runtime control: If Coverage is bound exists, make sure it is answered > Then > If Coverage is (select) > Then
    When I enter or select "Yes{TAB}{TAB}" in "Is this coverage bound?*"

    # Source step 0127: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-f60f-0e8f-4a3c9ed8f325
    When I click or select "Complete Application"

    # Source step 0128: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-028d-66c0-0d92b0939256
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0129: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ad27-82d8-033eb6ea4ea4
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0130: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-2894-81cd-79ae70ebcb33
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0131: Set Error Flag | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-164c-34bd-09b4530fd604
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I retain hard-coded value "Yes" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "No" as runtime value "ErrorFlag"
    When I retain hard-coded value "1" as runtime value "REPETITION"

    # Source step 0175: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-336a-2f2d-f91cee96e0a5
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0176: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1eea-c630-fb44dabd2ff1
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0177: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-295a-0313-b85aabc45f74
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0178: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8a63-0209-3353b5d56e26
    # Runtime control: Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0179: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-1698-5dbb-76ee11a0f637
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0180: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-5da9-78c4-714d2d479244
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0184: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a1ca-79ec-ff11d9c09b05
    When I wait "3500" milliseconds

    # Source step 0185: Check for Loading Indicator | Module: Indicators and Errors
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
    # Runtime control: While Loading Indicator is Visible [max=60] > Condition
    Then "Loading Message" should be visible

    # Source step 0186: Wait 2 secs | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
    # Runtime control: While Loading Indicator is Visible [max=60] > Loop
    When I wait "2000" milliseconds

    # Source step 0187: Stoplight message is visible | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3c2f-486e-41b42b263aae
    # Runtime control: If Stoplight error > Condition
    Then "All required fields have not been completed. Please complete highlighted tabs." should exist

    # Source step 0188: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-b1f7-6edb-77900e071830
    # Runtime control: If Stoplight error > Then
    When I click or select "Complete Application"

    # Source step 0189: Run Stoplight | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-8d46-8d14-f2a1f45a3b80
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Condition
    Then "stoplightWaitingWindow > Close" should not exist

    # Source step 0190: Wait 2 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-4c18-bd33-a96bf0291874
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop
    When I wait "2000" milliseconds

    # Source step 0191: Check for error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-c078-450d-80410bc505db
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Condition
    Then "stoplightWaitingWindow > Error:" should exist

    # Source step 0235: Click First Close button on Error | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ef10-0f0e-98ea9f0c5273
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "stoplightWaitingWindow > First Close button on Error"

    # Source step 0236: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-3eec-acd0-1d9354ccea68
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0237: Click Complete App | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-04e5-635f-ea4e256741fd
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I click or select "Complete Application"

    # Source step 0238: Wait 3 Seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec60-a658-2aa4ff4dc1e6
    # Runtime control: If Stoplight error > Then > Do (Wait for Stoplight to Run) [max=90] > Loop > If Error message on processing exists > Then
    When I wait "3000" milliseconds

    # Source step 0239: Close Stoplight Window | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-ec6d-8aed-bfdf866ff549
    # Runtime control: If Stoplight error > Then
    When I click or select "stoplightWaitingWindow > Close"

    # Source step 0240: Wait on Stoplight window to go away | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-28c2-ddba-5e7461b8994b
    # Runtime control: If Stoplight error > Then
    Then I wait until "stoplightWaitingWindow" no longer exists

    # Source step 0241: Wait 3.5 seconds | Module: TBox Wait
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-cf8a-179f-7f95452f1e0e
    # Runtime control: If Stoplight error > Then
    When I wait "3500" milliseconds

    # Source step 0242: Verify Stoplight Successfully Ran | Module: Submission|Complete Application & Stoplight Functionality
    # Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-a597-71e9-28bf802ee44c
    Then "All required fields have not been completed. Please complete highlighted tabs." should not exist

    # Source step 0256: Set NBPrem Buffer | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a1d4770-bbba-b245-9364-2c0665da5266
    When I retain hard-coded value "1,387.00" as runtime value "NBPrem"

    # Source step 0257: Verify Premiums | Module: Submission|Premiums
    # Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Verify Values in Premium Fields | Source XTestStep: 3a13d49c-165b-c49a-dcbe-18bb68f15610
    Then "Full Term Premium" property "value" should equals "$1,387.00"
    Then "Premium Written" property "value" should equals "1,387.00"
    Then "Prior Premium" property "value" should equals "0.00"
    Then "Premium Change" property "value" should equals "1,387.00"

    # Source step 0258: Delete LastResponseResource | Module: TBox Delete Resource
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c69dd-b1c1-b293-8cbd-e5702d8da2cb
    When I remove runtime resource "LastResponseResource"

    # Source step 0259: Get Session ID & Buffer | Module: Verify JavaScript Result
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-b7b3-568f-d9274f4dafbf
    When I enter or select "*" in "Title"
    When I enter or select "return DCT.sessionID" in "JavaScript"
    Then "Result" property "value" should equals "{XB[SessionId]}"

    # Source step 0260: Buffer Server Address | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-8f9a-4122-1f9ff1c4c48e
    When I retain hard-coded value "http://svqw-clas21:8080/duckcreek/dctserver.aspx" as runtime value "ServerAddress"

    # Source step 0261: Forms API Request | Module: Forms API Request
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-dc4c-5c0d-05c99bfb41eb
    When I enter captured RUNTIME-DERIVED value "{B[SessionId]}" in "sessionID"

    # Source step 0262: Forms API Response | Module: Forms API Response
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-1531-ae62-19ae8fc934bd
    Then "StatusCode" property "value" should equals "200 OK"

    # Source step 0263: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-51f1-3b4e-a30a-4f8ab3ea504b
    When I wait "250" milliseconds

    # Source step 0264: Save the Response as XML file | Module: Save XML file
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f604-82d8-22d3fa60f189
    When I save the source-defined file/resource for "Save the Response as XML file" using "Resource=LastResponseResource; Filepath=\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\GL_BASIC_AZ_{B[QuoteID]}.xml"

    # Source step 0270: Sync API | Module: TBox Wait
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6a02-5706-521c-80aa-b7932ce6ae42
    When I wait "250" milliseconds

    # Source step 0271: Buffer Powershell Arguments | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-ff17-3a8f-ef94901d8f76
    When I derive and retain the RUNTIME-DERIVED buffer expression "powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\\" -FileName \"GL_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\"" as runtime value "PowershellArguments"

    # Source step 0272: Execute Powershell Script | Module: TBox Start Program
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-f037-0cbe-f1ebfe2869f4
    When I start the configured program or command "C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe {B[PowershellArguments]}" and wait for it to exit

    # Source step 0273: Display the Results Summary | Module: TBox Clipboard
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-0e48-b008-522e2ee454bb
    When I capture "Value" as runtime value "SummaryResults"

    # Source step 0274: Check and Report for Fails in the Forms Verification from the SummaryResults | Module: TBox Set Buffer
    # Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a13d49c-165b-5cb4-3850-01f15ef17f9a
    When I retain hard-coded value "*FAIL:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Forms Listed:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*INFO:0 *" as runtime value "SummaryResults"
    When I retain hard-coded value "*Other: 0*" as runtime value "SummaryResults"

    # Source step 0275: Logout | Module: Logout
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0276: Sync for Log out | Module: TBox Wait
    # Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0277: Check for Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0278: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0279: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0280: Logout | Module: Logout
    # Section: Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0282: Close Explorer Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0283: Close Chrome Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0284: Close Edge Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0285: Close Firefox Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0286: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0027: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0071: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0072: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0132: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0133: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0134: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0135: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0136: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0137: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0138: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0139: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0140: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0141: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0142: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0143: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0144: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0145: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0146: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0147: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0148: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0149: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0150: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0151: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0152: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0153: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0154: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0155: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0156: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0157: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0158: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0159: "Login" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0160: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0161: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0162: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0163: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "a blank/null value"
# Source step 0164: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0165: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0166: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0167: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0168: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0169: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0170: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0171: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0172: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0173: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0174: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:08:57 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0192: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
#    - INPUT "Url" with "https://connect.anico.com/Pages/default.aspx"
#    - INPUT "UseActiveTab" with "a blank/null value"
# Source step 0193: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0194: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
#    - INPUT "Loop Login" with "0"
#    - INPUT "URL" with "https://clasq.anico.com/Express/"
#    - INPUT "UserName" with "AG0U388"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
# Source step 0195: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0196: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0197: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0198: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0199: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0200: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0201: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
#    - ACTION "Resource" with "EdgePreferences"
#    - ACTION "RootObject" with "a blank/null value"
#    - ACTION "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0202: "Save changes" in module "Save JSON Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0203: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0204: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0205: "OpenUrl" in module "OpenUrl" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0206: "Wait on Edge Browser to open" in module "Edge Browser" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
#    - WAIT (Exists) "BODY" with "True"
# Source step 0207: "Policy Load Sync" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
#    - INPUT "Duration" with "3000"
# Source step 0208: "Restart Microsoft Edge Message Exists?" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
#    - VERIFY (Exists) "OK" with "True"
# Source step 0209: "Restart Microsoft Edge Message - Click OK" in module "Restart Microsoft Edge Message" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
#    - INPUT "OK" with "X"
# Source step 0210: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0211: "Check for Log In" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Check to see if Logged In | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0212: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0213: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
#    - INPUT "Duration" with "1000"
# Source step 0214: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0215: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
#    - INPUT "OK" with "X"
# Source step 0216: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
#    - WAIT (Visible) "OK" with "True"
# Source step 0217: "Logout" in module "Logout" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False > Http Error Msg | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0218: "Waiton Username to exist" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin] | 02.08.24 09:13:13 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0219: "Login" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
#    - INPUT "UserName" with "AG0U388{TAB}"
#    - INPUT "Password" with "${ENV:TOSCA_PROTECTED_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0220: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
#    - WAIT (Exists) "Login" with "True"
# Source step 0221: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
#    - INPUT "Loop Login" with "1"
# Source step 0222: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
#    - INPUT "Directory" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\Screenshots"
#    - INPUT "Filename" with "Login Error"
# Source step 0223: "Set DocPath Buffer" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
#    - INPUT "DocPath" with "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\"
# Source step 0224: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0225: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0226: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0227: "Check for Transact Header" in module "TransACT" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-7b52-b28b-e2cd589ebd26
#    - VERIFY (Exists) "TransACT" with "True"
# Source step 0228: "Check if Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-14f1-f247-161fc8221018
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - VERIFY "Table > <Row> > Status" with "Pending"
# Source step 0229: "Click on Edit Policy on Pending Transaction" in module "TransACT|Transaction List Table" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|TransACT|Find Pending Transaction | Source XTestStep: 3a13d49c-165b-3e78-de7d-e4287b8197cd
#    - ACTION "Table" with "a blank/null value"
#    - ACTION "Table > <Row>" with "a blank/null value"
#    - CONSTRAINT "Table > <Row> > Status" with "Pending"
#    - GROUP "Table > <Row> > $1" with "a blank/null value"
#    - ACTION "Table > <Row> > $1 > Link" with "{CLICK}"
# Source step 0230: "Check to see Submission Screen Header Exists" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-2c36-4c77-0509b15611cd
#    - VERIFY (Exists) "Submission Heading" with "False"
# Source step 0231: "Navigate to Submission Screen" in module "Common Navigation Links" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-6f12-3f1b-39180a24814b
#    - INPUT "Submission" with "{TAB}"
#    - INPUT "Submission" with "X"
# Source step 0232: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-4604-cd78-bb4eddf2bde6
#    - INPUT "Duration" with "1250"
# Source step 0233: "Wait on Submission Screen to Load" in module "Submission|Required and Optional Fields" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-c808-873d-7350bc0ce3dd
#    - WAIT (Exists) "Submission Heading" with "True"
# Source step 0234: "500ms wait for syncing" in module "TBox Wait" was disabled. Reason: 24.01.23 06:13:06 [Admin]
# Section: New Application - Data Entry Process > If Stoplight Parameter = False | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Determine if on Submission Page | Source XTestStep: 3a13d49c-165b-669e-7efc-61fd60f4b5e8
#    - INPUT "Duration" with "500"
# Source step 0243: "Click Queue to open popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-8ddd-5713-63585939f694
#    - INPUT "Queue" with "X"
# Source step 0244: "Wait on Clear All and Click it" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-0cf3-f436-c6f51c411f05
#    - WAIT (Visible) "Clear All" with "True"
#    - INPUT "Clear All" with "X"
# Source step 0245: "Wait 1/2 sec" in module "TBox Wait" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-9b11-3e6c-6ed198204d6d
#    - INPUT "Duration" with "500"
# Source step 0246: "Click Queue to close popup" in module "Queue in CLAS QLTY" was disabled. Reason: 08.03.23 14:59:48 [Admin]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Run Stoplight > Common|Submission|Click to Clear All in the Queue | Source XTestStep: 3a13d49c-165b-4535-acab-c503c22e2fdf
#    - INPUT "Queue" with "X"
#    - WAIT (Exists) "Clear All" with "False"
# Source step 0247: "Submission, select Policy Forms" in module "Submission, select Policy Forms" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-b954-0a7c-e98a92e77430
#    - INPUT "Policy Forms" with "x"
#    - WAIT (Exists) "Search" with "True"
#    - INPUT "Search for DEC Page" with "Declaration"
#    - INPUT "Search Button for DEC Page" with "x"
#    - INPUT "DEC LINK" with "x"
# Source step 0248: "Wait for Policy Forms to open" in module "TBox Wait" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8889-6242-e08fb28d4f40
#    - INPUT "Duration" with "9000"
# Source step 0249: "Close Policy Forms" in module "TBox Send Keys" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-582d-aae0-ba158c28662e
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0250: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-9a96-581e-d2b119b0020a
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0251: "Return to Submission Page" in module "Common Navigation Links" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-8902-2720-581821968d05
#    - INPUT "Return to Policy" with "x"
# Source step 0252: "Submission, select Policy Admin Forms" in module "Submission, select Policy Forms" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-dcfb-265b-775fb7492386
#    - WAIT (Visible) "Policy Admin Forms" with "True"
#    - INPUT "Policy Admin Forms" with "x"
# Source step 0253: "Wait for Policy Admin Forms to open" in module "TBox Wait" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-5130-737f-d02663cba9f8
#    - INPUT "Duration" with "15000"
# Source step 0254: "Close Policy Admin Forms" in module "TBox Send Keys" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-c820-c654-7878ba2a4c1c
#    - INPUT "Keys" with "%\"{F4}\""
# Source step 0255: "Close out of PDF" in module "TBox Send Keys" was disabled. Reason: 02.12.21 10:41:04 [ff01729]
# Section: New Application - Data Entry Process | Reusable flow: Common|Submission|Select Policy Forms and Policy Admin Forms | Source XTestStep: 3a13d49c-165b-a6a9-8ecd-59b80f1bea38
#    - INPUT "Keys" with "\"{TAB}~\""
# Source step 0265: "Forms API Request" in module "Forms API Request" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-02f0-f861-3f14ac657c0f
#    - INPUT "sessionID" with "the RUNTIME-DERIVED source value {B[SessionId]}"
# Source step 0266: "Forms API Response" in module "Forms API Response" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-f20b-5e0f-84cfa49f33fc
#    - VERIFY "StatusCode" with "200 OK"
# Source step 0267: "Sync API" in module "TBox Wait" was disabled. Reason: 16.01.26 11:58:19 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-205b-4d2d-f4ee1a471e93
#    - INPUT "Duration" with "25000"
# Source step 0268: "Save the Response as XML file" in module "Save XML file" was disabled. Reason: 18.09.25 11:22:06 [ff01620@dnanico1.aniconet.com]
# Section: New Application - Data Entry Process | Reusable flow: Common|General|Forms Verification | Source XTestStep: 3a1c6b03-05d9-0c6f-327f-4c278210c3f1
#    - INPUT "Resource" with "LastResponseResource"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\GL_BASIC_AZ_{B[QuoteID]}.xml"
# Source step 0269: "Run Forms Request Get Forms on Policy" in module "Communicate with Web service" was disabled. Reason: 20.11.23 07:56:55 [ff01620]
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
#    - INPUT "Transform response > Response transformation_4 > Filepath" with "the RUNTIME-DERIVED source value \\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\GL_BASIC_AZ_{B[QuoteID]}.xml"
#    - ACTION "Response_3" with "a blank/null value"
#    - ACTION "Response_3 > server" with "a blank/null value"
#    - ACTION "Response_3 > server > responses" with "a blank/null value"
#    - GROUP "Response_3 > server > responses > Session.resumeRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > Session.resumeRs > status" with "success"
#    - ACTION "Response_3 > server > responses > FormsEngine.initPrintJobRs" with "a blank/null value"
#    - VERIFY "Response_3 > server > responses > FormsEngine.initPrintJobRs > status" with "success"
# Source step 0281: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0035 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  GeneralLiability  Pages   US   (4.0.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0041 "Select Individual Sole Proprietor" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
# Source step 0064: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: New Application - Data Entry Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Active source step 0066 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
#    - INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
# Active source step 0068 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0074 "Policy Covg|GL" contains conditionally inapplicable field action(s):
#    - INPUT "Number of Buildings built prior to 1978" with "2{TAB}" when State == "NJ" && 'Coverage Form' != "OCP". Reason: Value condition evaluated false for the selected iteration: State == "NJ" && 'Coverage Form' != "OCP"
#    - INPUT "Number of Buildings built in 1978, 1979 and 1980" with "1{TAB}" when State == "NJ" && 'Coverage Form' != "OCP". Reason: Value condition evaluated false for the selected iteration: State == "NJ" && 'Coverage Form' != "OCP"
# Active source step 0078 "CGL|Add Class Exposure" contains conditionally inapplicable field action(s):
#    - INPUT "What are the total annual receipts from all operations (i.e., wine and non-wine receipts)?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: What are the total annual receipts from all operations (ie, wine and non-wine receipts)?>{TAB})" when 'What are the total annual receipts from all operations (ie, wine and non-wine receipts)?' != NULL. Reason: Value condition evaluated false for the selected iteration: 'What are the total annual receipts from all operations (ie, wine and non-wine receipts)?' != NULL
#    - INPUT "What percentage of the total annual receipts are Wholesale?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: What percentage of the total annual receipts are Wholesale?>{TAB})" when 'What percentage of the total annual receipts are Wholesale?' != NULL. Reason: Value condition evaluated false for the selected iteration: 'What percentage of the total annual receipts are Wholesale?' != NULL
#    - INPUT "What percentage of the total annual receipts are Retail?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: What percentage of the total annual receipts are Retail?>{TAB})" when 'What percentage of the total annual receipts are Retail?' != NULL. Reason: Value condition evaluated false for the selected iteration: 'What percentage of the total annual receipts are Retail?' != NULL
#    - INPUT "Any distilled spirits manufactured?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Any distilled spirits manufactured?>{TAB})" when 'Any distilled spirits manufactured?' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Any distilled spirits manufactured?' != NULL
#    - INPUT "Any sales in Foreign Countries?*" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: Any sales in Foreign Countries?>{TAB})" when 'Any sales in Foreign Countries?' != NULL. Reason: Value condition evaluated false for the selected iteration: 'Any sales in Foreign Countries?' != NULL
# Active source step 0084 "Add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) Endorsement" contains conditionally inapplicable field action(s):
#    - INPUT "OK" with "{Click}" when State == "VA". Reason: Value condition evaluated false for the selected iteration: State == "VA"
# Source step 0181: "Check for Loading Indicator" in module "Indicators and Errors" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-e5b6-99ea-0884937944de
#    - Preserved source field action: VERIFY (Visible) "Loading Message" with "True"
# Source step 0182: "Wait 2 secs" in module "TBox Wait" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight > Common|General|Wait on Loading Indicator | Source XTestStep: 3a13d49c-165b-d159-8ea2-a672b547d024
#    - Preserved source field action: INPUT "Duration" with "2000"
# Source step 0183: "Wait for Stoplight message to exist" in module "Submission|Complete Application & Stoplight Functionality" was not executed. Reason: Selected-iteration condition evaluated false: 'Stoplight Error' == "True"
# Section: New Application - Data Entry Process > If Stoplight Parameter = True | Reusable flow: Common|Submission|Run Stoplight | Source XTestStep: 3a13d49c-165b-dfa3-679c-238ff71faa05
#    - Preserved source field action: WAIT (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#    - Preserved source field action: VERIFY (Exists) "All required fields have not been completed. Please complete highlighted tabs." with "True"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# Recovery scenario: Recovery Scenario for TestCases
# Source recovery step 0001: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14b7-3720-cdad-ffa37b170fb4
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\GL\\GL BASIC TestCase"
# Recovery scenario: Recovery Scenario for TestSteps
# Source recovery step 0002: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14b7-a365-1fb4-e5c24541fc9b
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\GL\\GL BASIC TestStep"
# Recovery scenario: Recovery Scenario for TestStepValues
# Source recovery step 0003: Take Screenshot when Error Occurs | Module: TBox Take Screenshot | Source XTestStep: 3a13d49c-14b7-5298-9e7b-2d5f1991de89
#    - I capture a "Desktop" screenshot at "\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Screenshots\\GL\\GL BASIC TSV"
# Recovery scenario: CleanUp Scenario
# Source recovery step 0004: Close Explorer Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-a5e7-fcd7-dfc4e0a0d9ce
#    - I run "taskkill /f /im iexplore.exe"
# Source recovery step 0005: Close Chrome Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-f2de-8c56-57474e3df016
#    - I run "taskkill /f /im Chrome.exe"
# Source recovery step 0006: Close Firefox Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-362c-5268-a7e588f9794b
#    - I run "taskkill /f /im Firefox.exe"
# Source recovery step 0007: Close Edge Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-72b0-eb72-383c2e9d1e2c
#    - I run "taskkill /f /im MicrosoftEdge.exe"
# Source recovery step 0008: Close Edge Beta Browsers | Module: TBox Start Program | Source XTestStep: 3a13d49c-14b7-026b-8e4d-a618b30997a6
#    - I run "taskkill /f /im msEdge.exe"
