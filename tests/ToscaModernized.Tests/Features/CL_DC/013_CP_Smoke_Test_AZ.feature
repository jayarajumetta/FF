# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 013_CP_Smoke_Test_AZ.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @CP @smoke @Arizona @Edge @manual @automated
Feature: Execute CP | Smoke Test for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the CP | Smoke Test workflow for Arizona (AZ)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: CP | Smoke Test using representative iteration Arizona (AZ)

    # Source step 0028: OpenUrl | Module: OpenUrl
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a178739-6c2a-7f96-bdeb-c75256d37be8
    When I open "https://connect.anico.com/Pages/default.aspx" in the active browser tab

    # Source step 0029: Check the Loop Login | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e5fd-3e81-f0c163b45bec
    # Runtime control: Loop for the Login [max=30] > Condition
    Then I evaluate the source-defined expression for "Check the Loop Login" using "Expression={B[Loop Login]} = 0"

    # Source step 0030: Set Loop Buffer | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-3cce-e902-ad26cde48dad
    # Runtime control: Loop for the Login [max=30] > Loop
    When I retain hard-coded value "0" as runtime value "Loop Login"
    When I retain hard-coded value "https://clasq.anico.com/Express/" as runtime value "URL"
    When I retain hard-coded value "AG0U388" as runtime value "UserName"
    When I retain RUNTIME-CONFIGURED value "CL_DC_PASSWORD" as runtime value "Password"

    # Source step 0031: Close Explorer Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-e3da-d6b5-08c35a43f04d
    # Runtime control: Loop for the Login [max=30] > Loop
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0032: Close Chrome Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-9cc6-4a8f-338b7b667ec2
    # Runtime control: Loop for the Login [max=30] > Loop
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0033: Close Firefox Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-a67c-6795-e63970f56d0b
    # Runtime control: Loop for the Login [max=30] > Loop
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0034: Close Edge Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-cf23-15a2-7a8ef9e564eb
    # Runtime control: Loop for the Login [max=30] > Loop
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0035: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-acaf-d111-26d7d113b4a9
    # Runtime control: Loop for the Login [max=30] > Loop
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0036: Open Edge Preferences file | Module: Open/Create JSON file
    # Section: Run New Smoke > Precondition > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-51a2-e30a-875085d7293d
    # Runtime control: Loop for the Login [max=30] > Loop
    Given I open or create JSON resource "EdgePreferences" at "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0037: Change Exit Type | Module: Edge Preferences File
    # Section: Run New Smoke > Precondition > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-3bfc-0f17-941d4e508586
    # Runtime control: Loop for the Login [max=30] > Loop
    When I enter or select "EdgePreferences" in "Resource"
    When I enter or select "none" in "RootObject > profile > exit_type"

    # Source step 0038: Save changes | Module: Save JSON Resource
    # Section: Run New Smoke > Precondition > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-ddc0-eab3-528e14fa8530
    # Runtime control: Loop for the Login [max=30] > Loop
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0039: Delete EdgePreferences Resource | Module: TBox Delete Resource
    # Section: Run New Smoke > Precondition > Reset Exit_Type (Restore last session popup) | Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-2343-7a4a-f38e82d101b1
    # Runtime control: Loop for the Login [max=30] > Loop
    When I remove runtime resource "EdgePreferences"

    # Source step 0040: Delete Cookies File | Module: TBox Delete File
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > CL|DC|Common|Reset Edge Preferences | Source XTestStep: 3a13d49c-139a-5462-86d0-b2918ffe99fb
    # Runtime control: Loop for the Login [max=30] > Loop
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"

    # Source step 0041: OpenUrl | Module: OpenUrl
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a14f870-cc24-f954-1ce4-f66a4de25344
    # Runtime control: Loop for the Login [max=30] > Loop
    When I open "https://clasq.anico.com/Express/" in the active browser tab
    # Granular source value retained: INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"

    # Source step 0042: Wait on Edge Browser to open | Module: Edge Browser
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a1ec4ae-079b-3cc6-1506-4d54e5cd3412
    # Runtime control: Loop for the Login [max=30] > Loop
    Then I wait until "BODY" exists

    # Source step 0043: Policy Load Sync | Module: TBox Wait
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a1eab8e-7f31-b52e-d7c3-e0d6284edd4a
    # Runtime control: Loop for the Login [max=30] > Loop
    When I wait "3000" milliseconds

    # Source step 0044: Restart Microsoft Edge Message Exists? | Module: Restart Microsoft Edge Message
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-606d-8342-675b674aceca
    # Runtime control: Loop for the Login [max=30] > Loop > If Edge Popup is showing > Check if Edge Popup is showing
    Then "OK" should exist

    # Source step 0045: Restart Microsoft Edge Message - Click OK | Module: Restart Microsoft Edge Message
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > CL|EQ|Common|General|Restart Edge Popup | Source XTestStep: 3a20f668-6621-f75e-9950-268125ca8a2f
    # Runtime control: Loop for the Login [max=30] > Loop > If Edge Popup is showing > Then
    When I click or select "OK"

    # Source step 0046: Maximize Window | Module: TBox Window Operation
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-2b97-0140-17239ab3f79d
    # Runtime control: Loop for the Login [max=30] > Loop
    When I perform window operation "Maximize" on window "Duck Creek*"

    # Source step 0047: Check for Log In | Module: Logout
    # Section: Run New Smoke > Precondition > Check to see if Logged In | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-1049-ff4e-2462353be58e
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Condition
    Then "Logged In User" should exist

    # Source step 0048: Logout | Module: Logout
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0049: Sync for Log out | Module: TBox Wait
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Then
    When I wait "1000" milliseconds

    # Source step 0050: Check for Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Precondition > Http Error Msg | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Then > If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0051: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Precondition > Http Error Msg | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Then > If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0052: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Run New Smoke > Precondition > Http Error Msg | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Then > If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0053: Logout | Module: Logout
    # Section: Run New Smoke > Precondition > Http Error Msg | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: Loop for the Login [max=30] > Loop > If Still Logged In > Then > If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0055: Login | Module: Login
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-bf72-8b9d-330f6a10d897
    # Runtime control: Loop for the Login [max=30] > Loop
    When I enter or select "AG0U388{TAB}" in "UserName"
    When I enter or select "${ENV:TOSCA_PROTECTED_PASSWORD}" in "Password"
    When I click or select "Login"

    # Source step 0056: Wait for Login Screen to Go Away | Module: Login
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-95d4-9641-ecd18d77dd9b
    # Runtime control: Loop for the Login [max=30] > Loop > If Login Screen goes away > Condition
    Then I wait until "Login" no longer exists

    # Source step 0057: Set Loop Buffer to Exit Loop | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-ef41-eb0d-3bbe94d20cf1
    # Runtime control: Loop for the Login [max=30] > Loop > If Login Screen goes away > Then
    When I retain hard-coded value "1" as runtime value "Loop Login"

    # Source step 0058: Take Screenshot of Login | Module: TBox Take Screenshot
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-31b6-f0c0-5913076be452
    # Runtime control: Loop for the Login [max=30] > Loop > If Login Screen goes away > Else Take Screenshot and Loop
    When I capture a "Desktop" screenshot at "<BLANK — reusable-block parameter is not supplied: DocPath>Screenshots\\Login Error"

    # Source step 0059: Set DocPath Buffer | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a13d49c-165b-4b72-914c-3b3f207c9615
    # Step condition: DocPath != NULL
    When I retain a blank/not-supplied value as runtime value "DocPath"

    # Source step 0060: Retrieve Dex Agent Name | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek | Source XTestStep: 3a14206f-dfa2-d0fa-2115-a328697615e9
    When I derive and retain the RUNTIME-DERIVED expression "\"\"\"${COMPUTERNAME}\"\"\"" as runtime value "GetHostname"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{B[GetHostname]}" as runtime value "AgentName"

    # Source step 0061: Initiate a New Quote | Module: Common Navigation Links
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-e0bf-927f-5ec1a6b5218a
    When I click or select "New Quote"

    # Source step 0062: Select Agency and Product | Module: Product Selection
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-78aa-5295-3da4b7d394dd
    When I enter or select "07/25/2026{TAB}" in "Effective Date:*"
    When I capture "Effective Date:*" as runtime value "NBEffDate"
    When if field condition "'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\"" is satisfied, I enter or select "{CLICK}Carrier PropertyPages US (4.0.0.0){ENTER}{TAB}" in "Product:*"
    Then I wait until "Start" is visible
    When I click or select "Start"
    When I click or select "Start"

    # Source step 0063: Set NBEffDate Buffer | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-8a6f-caa1-29190033e33f
    When I retain hard-coded value "07/25/2026" as runtime value "NBEffDate"

    # Source step 0064: Uncheck Quick Quote | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-477c-510c-7ad43036cba4
    When I enter or select "False" in "Quick Quote"

    # Source step 0065: Wait on non-quick quote element | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3cbc-4aa7-a1c7b75ee619
    Then I wait until "Underwriting Info" exists

    # Source step 0066: Select Individual Insured | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-8c16-d826-567aed4c90ca
    When I enter or select "Individual/Person{ENTER}{TAB}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0067: Enter Name and DOB | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3ecf-8633-002f64245127
    Then I wait until "First Name" is visible
    When I enter or select "{TAB}{TAB}" in "First Name"
    When I enter or select "{CLICK}John{TAB}{TAB}" in "First Name"
    When I enter or select "AZ{TAB}{TAB}" in "Middle Name"
    When I enter or select "{TAB}{TAB}" in "Last Name"
    When I enter RUNTIME-DERIVED value "{DATE[][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "DOB"
    When if field condition "State!=\"CA\"" is satisfied, I enter or select "Male{TAB}{TAB}" in "Gender"
    When I enter a RANDOM value matching "^[a-z]{4}$" in "Last Name"

    # Source step 0068: Select Individual Sole Proprietor | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-f281-684f-979ca5404005
    When I enter or select "Individual/Sole Proprietor{ENTER}{TAB}{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I enter or select "{TAB}4201 N. 24th St{TAB}" in "Address1"
    When I enter or select "{TAB}85016{TAB}" in "ZipCode"

    # Source step 0069: Click Client search | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-7952-2e48-6b516ae5679d
    When I click or select "Client Search"

    # Source step 0070: Client Search Results | Module: Client Search Results
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-62f0-721e-d093b870cfd8
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0071: Enter SSN | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3868-3c34-dfdde15584ab
    Then I wait until "Order SSN" exists
    When I click or select "Order SSN"
    Then I wait until "Enter SSN" exists
    When I perform keyboard action "{TAB}" on "Enter SSN"
    When I enter a RANDOM value matching "6 random digits/characters from source expression 125{RND[6]}{TAB}" in "Enter SSN"
    When I capture "Enter SSN" as runtime value "SSN"
    When I enter or select "{Doubleclick}{TAB}" in "Enter SSN"
    When I click or select "Verify"
    Then I wait until "Verify" no longer exists

    # Source step 0072: Partial Buffer the Last Four of SSN | Module: TBox Partial Buffer
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-cb58-ee90-632993a50481
    When I perform the source-defined partial-buffer operation "Partial Buffer the Last Four of SSN" using "Buffer=Last4SSN; Value={B[SSN]}; Start=6"

    # Source step 0073: Wait for SSN mask | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-eddc-3263-04e8ba1848e0
    Then I wait until "Social Security # " property "InnerText" equals "XXX-XX-*"

    # Source step 0074: Validate SSN | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-a17a-f6cd-1482be959af6
    Then "Social Security # " property "InnerText" should equals "XXX-XX-{B[Last4SSN]}"
    Then I wait until "Please verify SSN*" no longer exists

    # Source step 0075: Enter other insured info | Module: Client|Other Insured Info
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-1cd6-971b-633af7644e81
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}{CLICK}Auditor Doe{TAB}{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0076: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-6c12-f22a-3d3cfbcf2bb3
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0077: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-b042-25d6-3bc4136f8a02
    When I retain hard-coded value "AZ" as runtime value "State"
    When I retain hard-coded value "CP" as runtime value "Product (LOB)"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"
    When I retain a blank/not-supplied value as runtime value "FormOnPolicyDocName"

    # Source step 0078: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0079: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0080: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0081: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0082: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "07/25/2026{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0083: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0084: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Arizona{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0085: State is Kansas | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Arizona==\"Kansas\"; Expression= 'Arizona'=='Kansas'"

    # Source step 0087: State is Virginia | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Arizona==\"Virginia\"; Expression= 'Arizona'=='Virginia'"

    # Source step 0089: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0090: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0091: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0092: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AZ CP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0128: Navigate to Policy Info | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Small Smoke|Navigate to Policy Info and Verify Desc | Source XTestStep: 3a1619ee-cb71-3900-9d9f-d047b008fe38
    When I click or select "Policy Info"

    # Source step 0129: Policy Info|Verify Description of Specified Operation | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Small Smoke|Navigate to Policy Info and Verify Desc | Source XTestStep: 3a1619ea-9f25-47ea-9a5a-f370a0fbda64
    Then "Description of Specified Operation" property "value" should equals "{B[QuoteDescription]}"

    # Source step 0130: Logout | Module: Logout
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0131: Sync for Log out | Module: TBox Wait
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0132: Check for Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0133: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0134: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0135: Logout | Module: Logout
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0137: Close Explorer Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0138: Close Chrome Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0139: Close Edge Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0140: Close Firefox Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0141: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0001: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-6452-ea2c-c73724cb5607
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0002: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-6c5b-83dd-058b40bcb707
#    - INPUT "Loop Login" with "0"
#    - INPUT "UserName" with "AG09999"
# Source step 0003: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-bd78-afac-ac62c5463170
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0004: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-e965-d5c9-5c09e00a148c
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0005: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-ffb2-43bc-610e3e97b832
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0006: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-5141-0463-17400507cafe
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0007: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-23e1-7092-bca1e2c0f79a
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0008: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-d647-6724-d734c1e137de
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0009: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-f8e5-f81d-fd9393399c81
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "RootObject" with "a blank/null value"
#    - GROUP "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0010: "Save changes" in module "Save JSON Resource" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-380a-e655-956ad0187149
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0011: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-ef6a-372d-fbe5de1fae8d
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0012: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-4467-c097-5b8307528448
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0013: "OpenUrl" in module "OpenUrl" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-3206-2031-69262fa0d277
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - GROUP "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0014: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-8b95-46df-445df5cd3554
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0015: "Check for Log In" in module "Logout" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Check to see if Logged In | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-dc7e-1bf5-f83d42f1876d
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0016: "Logout" in module "Logout" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-57ae-6009-5248f28deaf7
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0017: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-dfb6-2a0c-b47d969860f0
#    - INPUT "Duration" with "1000"
# Source step 0018: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-12e3-c4fc-534a558bdae8
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0019: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-f65f-c1b0-3be297b724f5
#    - INPUT "OK" with "X"
# Source step 0020: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-6e80-a64d-c0b347c811d3
#    - WAIT (Visible) "OK" with "True"
# Source step 0021: "Logout" in module "Logout" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-35c7-daa5-1c0cea3e6a8d
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0022: "Waiton Username to exist" in module "Login" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-af8b-c3b8-6a4b940030b3
#    - WAIT (Exists) "UserName" with "True"
# Source step 0023: "Login" in module "Login" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b56-5efe-b07c-7ef88e8997de
#    - INPUT "UserName" with "AG0u388{TAB}"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0024: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b65-6c88-ded7-4e145acee3d5
#    - WAIT (Exists) "Login" with "True"
# Source step 0025: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b65-8a11-894c-e94f2b9103df
#    - INPUT "Loop Login" with "1"
# Source step 0026: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b65-d197-9d50-c3f705ab15ed
#    - INPUT "Filename" with "Login Error"
# Source step 0027: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 08.12.25 08:26:11 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4b65-4c93-f047-c8e85e7d209a
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0054: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0093: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0094: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0095: "Check for Save for Later Button" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-7f66-3db6-9842c21b8f30
#    - VERIFY (Exists) "Save for Later" with "True"
# Source step 0096: "Save for Later" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-76d9-8f8d-5996da943954
#    - INPUT "Save for Later" with "X"
#    - WAIT (Exists) "Save for Later - OK" with "True"
#    - INPUT "Save for Later - OK" with "X"
# Source step 0097: "Check for Return to Admin Button" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-f9d4-d6c6-7d52f321bbe0
#    - VERIFY (Exists) "Return To Admin" with "True"
# Source step 0098: "Return To Admin" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-5f9c-b6f4-47437bc9202b
#    - INPUT "Return To Admin" with "X"
#    - WAIT (Exists) "Return To Admin" with "False"
# Source step 0099: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-8a89-650c-fbba7233847c
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0100: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-0a84-39fa-13e8c1332bc9
#    - INPUT "Loop Login" with "0"
#    - INPUT "UserName" with "AG09999"
# Source step 0101: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-85c3-a280-f7deb4360f42
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0102: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-9fdb-5b19-574e16ad5d53
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0103: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-ebfe-433b-e57a0f68714e
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0104: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-7f13-521f-1257afa2c609
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0105: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-87b3-308e-51e811af7de6
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0106: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-8339-29a3-3845fef72af9
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0107: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-0700-a5d8-ab00748274aa
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "RootObject" with "a blank/null value"
#    - GROUP "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0108: "Save changes" in module "Save JSON Resource" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-aeab-35cb-d10b76b244c9
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0109: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-bc7d-c60b-7736ec638aec
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0110: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-cc0b-b7ed-6d276354e345
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0111: "OpenUrl" in module "OpenUrl" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-7475-4b0c-9ab104d99d4f
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - GROUP "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0112: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-dd05-59e4-ecaf371c040d
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0113: "Check for Log In" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Check to see if Logged In | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-859a-a9af-7ffbc2912da0
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0114: "Logout" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-3b68-a1e2-e1fa4cfdd680
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0115: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-9cdc-9563-667da44df074
#    - INPUT "Duration" with "1000"
# Source step 0116: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-10d7-209d-465a4ef70e66
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0117: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-6f1a-2578-06f9a5915149
#    - INPUT "OK" with "X"
# Source step 0118: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-fa37-5e93-d3d9e6ec1b56
#    - WAIT (Visible) "OK" with "True"
# Source step 0119: "Logout" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-e6ee-9984-5040e0dce2e7
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0120: "Waiton Username to exist" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-83ab-c9f1-f95061da4293
#    - WAIT (Exists) "UserName" with "True"
# Source step 0121: "Login" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-5c60-62de-5d35709dfa96
#    - INPUT "UserName" with "AG09999{TAB}"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0122: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-2e85-9269-89066e0583ed
#    - WAIT (Exists) "Login" with "True"
# Source step 0123: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-ce42-3f3f-3eb1317622b8
#    - INPUT "Loop Login" with "1"
# Source step 0124: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-8f98-9f2c-aaf2d15a3c8b
#    - INPUT "Filename" with "Login Error"
# Source step 0125: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161ea9-4dbd-89aa-3ef2-83d9cefbc661
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0126: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 07.11.24 15:32:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0127: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 07.11.24 15:32:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0136: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0062 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier PropertyPages US (4.0.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0068 "Select Individual Sole Proprietor" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
# Source step 0086: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Arizona{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Source step 0088: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
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
# Active source step 0090 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario steps were exported for this representative iteration.
