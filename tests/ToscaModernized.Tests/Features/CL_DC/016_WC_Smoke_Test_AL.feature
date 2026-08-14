# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 016_WC_Smoke_Test_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @WC @smoke @Alabama @Edge @manual @automated
Feature: Execute WC | Smoke Test for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the WC | Smoke Test workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: WC | Smoke Test using representative iteration Alabama (AL)

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
    When I enter or select "12-01-2025{TAB}" in "Effective Date:*"
    When I capture "Effective Date:*" as runtime value "NBEffDate"
    When if field condition "'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\"" is satisfied, I enter or select "{CLICK}Carrier  WorkersCompensation  Pages   US   (9.8.0.0){ENTER}{TAB}" in "Product:*"
    Then I wait until "Start" is visible
    When I click or select "Start"
    When I click or select "Start"

    # Source step 0063: Set NBEffDate Buffer | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-8a6f-caa1-29190033e33f
    When I retain hard-coded value "12-01-2025" as runtime value "NBEffDate"

    # Source step 0078: Deselect Quick Quote | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-baea-fc85-843e0b462e26
    Then I wait until "Quick Quote" exists
    When I enter or select "False" in "Quick Quote"

    # Source step 0079: Wait for Non-Quick Quote Element to Appear | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-ac73-2258-77271da65807
    Then I wait until "Underwriting Info" exists

    # Source step 0080: Select Business Insured | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-ba4e-70ab-2fddc1e53a30
    When I enter or select "Business{ENTER}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0081: Enter Business Name | Module: Client|Named Insured|Business
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-afee-adb2-16b93c762899
    Then I wait until "Business Name" is visible
    When I enter or select "AL WC Testing, Inc.{TAB}" in "Business Name"

    # Source step 0082: Enter Business Info | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-e0be-7cfd-4133e268b3f9
    When I enter or select "Corporation{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I perform keyboard action "{TAB}" on "Address1"
    When I enter or select "{TAB}35661{TAB}" in "ZipCode"
    When I enter or select "1918 Avalon Ave{TAB}" in "Address1"

    # Source step 0083: Enter Business Info | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-83a0-cae3-d02d409f7316
    # Runtime control: If Years in Business Exists > Check Years in Business
    Then "Years In Business" should exist

    # Source step 0084: Enter Business Info | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-5638-4d11-366b2d2dda1c
    # Runtime control: If Years in Business Exists > Then Input Years
    When I enter or select "6{TAB}" in "Years In Business"

    # Source step 0085: Enter FEIN | Module: Client|Named Insured|Business
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-c5e9-eccd-b3778fc99bfd
    When I enter a RANDOM value matching "6 random digits/characters from source expression 486{RND[6]}{TAB}" in "FEIN"

    # Source step 0086: Enter Details in Other Information Section | Module: Client|Other Insured Info
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-0b67-ea05-a131fa3c03bf
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}Auditor Doe{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{TAB}{CLICK}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0087: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-8298-54db-43889fb5edce
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0088: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client | Reusable flow: Common|Client|Enter Business Client Info | Source XTestStep: 3a13d49c-165b-996b-f29f-d2de8058d631
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "WC" as runtime value "Product (LOB)"
    When I retain a blank/not-supplied value as runtime value "FormOnPolicyDocName"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"

    # Source step 0089: Add a new Associated Client - Business Owner Type - Click Add Client | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9d69-58fe-7329-8d9d0fc9cde1
    # Source template XTestStep: 3a13d49c-165b-ce02-83cf-cd6904f97e54
    Then I wait until "Add Client" exists
    When I perform keyboard action "{TAB}" on "Add Client"
    When I click or select "Add Client"

    # Source step 0090: Check if IndividualType Exists | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9d69-7252-c3bd-3a9474ba4a9f
    # Source template XTestStep: 3a13d49c-165b-d0b1-7d57-b7cecf62671b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Condition
    Then "IndividualType" should not exist

    # Source step 0091: AJAX Error Check | Module: AJAX Error
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-90d4-c7c4-34e4afe4471a
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Check for AJAX Error
    Then "AJAX Error Check" should exist

    # Source step 0092: Set buffer for Error | Module: TBox Set Buffer
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-742f-be97-b5b259ccf349
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I derive and retain the RUNTIME-DERIVED buffer expression "The scripts experienced an AJAX error with the following information: {B[AJAX]}" as runtime value "AJAX Error"

    # Source step 0093: Force a fail | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check | Source XTestStep: 3a13d49c-165b-fc4f-89ec-af2ceb5f1e02
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    Then I evaluate the source-defined expression for "Force a fail" using "Expression='FALSE' == 'TRUE'"

    # Source step 0094: Navigate to Billing Screen | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-25bf-bd57-f35caadb6623
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I click or select "Billing"

    # Source step 0095: Fill Out Required Fields on Billing Screen | Module: Billing
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-315a-3b12-4a479c858c7a
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

    # Source step 0096: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: Common|General|AJAX Error Check > Common|Billing| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-7ff2-ffee-46e34f27451b
    # Runtime control: Loop until Associated Client Screen opens [max=30] > Loop > If AJAX Error occurs > Then
    When I wait "3000" milliseconds

    # Source step 0097: Complete the Associated Client Info | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-d4ce-2648-601db16815ad
    # Source template XTestStep: 3a13d49c-165b-71c5-b893-c4235f3b547a
    When I enter or select "{TAB}{CLICK}Business Owner{TAB}" in "IndividualType"
    Then I wait until "Please verify SSN*" exists

    # Source step 0098: Enter Client Details | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-4618-125c-4b0409e1bad7
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

    # Source step 0099: Verify no results returned and click OK | Module: Client Search Results
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-ec53-ac94-a34875c1f965
    # Source template XTestStep: 3a13d49c-165b-32d5-f6ed-f265f9f9c6c8
    Then "Search Results > Duck Creek Policy > First Checkbox" should not exist
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0100: Order and Verify SSN | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-2e1a-e32f-3d2daf662a8e
    # Source template XTestStep: 3a13d49c-165b-2f1c-c197-ca3b93b64298
    When I click or select "Order SSN"
    When I perform keyboard action "{TAB}" on "Enter SSN*"
    When I enter or select "{TAB}736849971{TAB}" in "Enter SSN*"
    When I click or select "Enter SSN*"

    # Source step 0101: Does Verify Exist | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-cf52-ff39-53d801c32bf3
    # Source template XTestStep: 3a13d49c-165b-ba0f-6727-be7d60a0ce09
    # Runtime control: If Verify does not exist > Condition
    Then "Verify" should not exist

    # Source step 0102: Click Complete | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-39a4-bb0a-c39b2aedd83a
    # Source template XTestStep: 3a13d49c-165b-95b2-6c84-0c54eb4a6437
    # Runtime control: If Verify does not exist > Then
    When I click or select "Complete"

    # Source step 0103: Click Detail and Verify SSN | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-ad34-7e58-5c885b5b5e05
    # Source template XTestStep: 3a13d49c-165b-6230-e27e-9c3d0e9cbe27
    # Runtime control: If Verify does not exist > Then
    When I click or select "Detail"
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0104: Verify SSN | Module: Client|Add Associated Client
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-3e72-a46b-12162edf6a7c
    # Source template XTestStep: 3a13d49c-165b-de87-4c4c-3c66d28b8da1
    # Runtime control: If Verify does not exist > Else
    Then I wait until "Enter SSN*" exists
    When I click or select "Verify"
    Then I wait until "Please verify SSN*" no longer exists
    When I click or select "Complete"

    # Source step 0105: Perform Final Client Search | Module: Client Search Results
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-d47b-833c-5c5a71b45625
    # Source template XTestStep: 3a13d49c-165b-f6d6-53ae-4d4d2d531699
    Then I wait until "Client Search" exists
    When I click or select "Client Search"

    # Source step 0106: Click Ok | Module: Client Search Results
    # Section: Run New Smoke > Smoke Process > Common|Enter Business Client > Common|Client|Add Associated Client Information_Reference | Reusable flow: <none> | Source XTestStep: 3a162e41-9db4-ac85-5a6e-ba3a1c6d67a7
    # Source template XTestStep: 3a13d49c-165b-647c-ba91-85bcca049803
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"
    Then I wait until "Client Search" no longer exists

    # Source step 0107: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0108: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0109: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0110: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0111: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "12-01-2025{TAB}" in "EffectiveDate"

    # Source step 0112: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0113: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0114: State is Kansas | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0116: State is Virginia | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0118: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0119: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0120: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0121: Policy Info | WC Specific Fields | Module: Policy Info|WC Specific Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Fill Out WC Specific Fields | Source XTestStep: 3a13d49c-165b-3baf-6162-78d1ff47073c
    When I enter or select "{CLICK}Yes{ENTER}{TAB}" in "Has the applicant been in business for at least 3 years with continuous Workers Compensation Coverage?*"

    # Source step 0122: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL WC Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0158: Navigate to Policy Info | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Small Smoke|Navigate to Policy Info and Verify Desc | Source XTestStep: 3a1619ee-cb71-3900-9d9f-d047b008fe38
    When I click or select "Policy Info"

    # Source step 0159: Policy Info|Verify Description of Specified Operation | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Small Smoke|Navigate to Policy Info and Verify Desc | Source XTestStep: 3a1619ea-9f25-47ea-9a5a-f370a0fbda64
    Then "Description of Specified Operation" property "value" should equals "{B[QuoteDescription]}"

    # Source step 0160: Logout | Module: Logout
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0161: Sync for Log out | Module: TBox Wait
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0162: Check for Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0163: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0164: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0165: Logout | Module: Logout
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0167: Close Explorer Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0168: Close Chrome Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0169: Close Edge Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0170: Close Firefox Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0171: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0001: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-8398-c8ae-6cf8205eb229
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0002: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-e99b-98f1-a586cfee3d9b
#    - INPUT "Loop Login" with "0"
#    - INPUT "UserName" with "AG09999"
# Source step 0003: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-cd6c-2792-8eb4786b6669
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0004: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-5657-e6a4-e8a93e92c0ca
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0005: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-9f40-535f-39f3efe6c175
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0006: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-b27e-e529-b2692cd5408c
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0007: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-e75d-aac2-313ee984b58b
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0008: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-d4e4-b127-a78d912f2130
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0009: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-3d9a-b4f4-0bd24e03ae9f
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "RootObject" with "a blank/null value"
#    - GROUP "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0010: "Save changes" in module "Save JSON Resource" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-8caa-af3d-764bd1fcd07c
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0011: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-de59-9d46-c5686aad5549
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0012: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-de2b-9b8e-99a8d80073ff
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0013: "OpenUrl" in module "OpenUrl" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-09f9-c9df-a47a420ead1c
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - GROUP "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0014: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-91b9-1f7b-3f1e7f8d94f3
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0015: "Check for Log In" in module "Logout" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Check to see if Logged In | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-5239-0326-83684b229ef1
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0016: "Logout" in module "Logout" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-8f73-0dac-74f6b7f0c46f
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0017: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-ce99-0c61-07b42be2f4e0
#    - INPUT "Duration" with "1000"
# Source step 0018: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-9b12-5410-1a032e504ca5
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0019: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-35c8-f046-851f8b22eed2
#    - INPUT "OK" with "X"
# Source step 0020: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-2cef-7d04-f3f3bb1f3a5b
#    - WAIT (Visible) "OK" with "True"
# Source step 0021: "Logout" in module "Logout" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-9336-7e04-0f2ec2c60ff8
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0022: "Waiton Username to exist" in module "Login" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-06d6-7643-8d5cae78f5c4
#    - WAIT (Exists) "UserName" with "True"
# Source step 0023: "Login" in module "Login" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-1b3b-f642-a1caabea47e1
#    - INPUT "UserName" with "AG0u388{TAB}"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0024: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-066e-42fc-ca3c1f8de766
#    - WAIT (Exists) "Login" with "True"
# Source step 0025: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-a796-526f-54aa81354928
#    - INPUT "Loop Login" with "1"
# Source step 0026: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e5c-32de-e4ed-d0b2a492ccc9
#    - INPUT "Filename" with "Login Error"
# Source step 0027: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 08.12.25 08:27:35 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-1e6b-b72e-287e-0c5469e63f0e
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0054: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Precondition | Reusable flow: Common|General|Log In to DuckCreek > Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
# Source step 0064: "Uncheck Quick Quote" in module "Client|Named Insured|Common" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-477c-510c-7ad43036cba4
#    - INPUT "Quick Quote" with "False"
# Source step 0065: "Wait on non-quick quote element" in module "Common Navigation Links" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3cbc-4aa7-a1c7b75ee619
#    - WAIT (Exists) "Underwriting Info" with "True"
# Source step 0066: "Select Individual Insured" in module "Client|Named Insured|Common" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-8c16-d826-567aed4c90ca
#    - INPUT "Insured Type" with "Individual/Person{ENTER}{TAB}{TAB}{TAB}"
#    - INPUT "Entity Type" with "{CLICK}"
# Source step 0067: "Enter Name and DOB" in module "Client|Named Insured|Individual" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3ecf-8633-002f64245127
#    - WAIT (Visible) "First Name" with "True"
#    - INPUT "First Name" with "{TAB}{TAB}"
#    - INPUT "First Name" with "{CLICK}John{TAB}{TAB}"
#    - INPUT "Middle Name" with "AL{TAB}{TAB}"
#    - INPUT "Last Name" with "{TAB}{TAB}"
#    - INPUT "DOB" with "the RUNTIME-DERIVED source value {DATE[][-40y][MM-dd-yyyy]}{TAB}{TAB}"
#    - INPUT "Gender" with "Male{TAB}{TAB}" when State!="CA"
#    - INPUT "Last Name" with "a RANDOM value matching ^[a-z]{4}$"
# Source step 0068: "Select Individual Sole Proprietor" in module "Client|Named Insured|Common" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-f281-684f-979ca5404005
#    - INPUT "Entity Type" with "Individual/Sole Proprietor{ENTER}{TAB}{TAB}"
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
#    - INPUT "Primary Phone" with "a RANDOM value matching 10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "Address1" with "{TAB}1918 Avalon Ave{TAB}"
#    - INPUT "ZipCode" with "{TAB}35661{TAB}"
# Source step 0069: "Click Client search" in module "Client|Named Insured|Individual" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-7952-2e48-6b516ae5679d
#    - INPUT "Client Search" with "X"
# Source step 0070: "Client Search Results" in module "Client Search Results" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-62f0-721e-d093b870cfd8
#    - ACTION "Search Results" with "a blank/null value"
#    - ACTION "Search Results > Duck Creek Policy" with "a blank/null value"
#    - WAIT (Exists) "Search Results > Duck Creek Policy > OK" with "True"
#    - INPUT "Search Results > Duck Creek Policy > OK" with "X"
# Source step 0071: "Enter SSN" in module "Client|Named Insured|Individual" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3868-3c34-dfdde15584ab
#    - WAIT (Exists) "Order SSN" with "True"
#    - INPUT "Order SSN" with "X"
#    - WAIT (Exists) "Enter SSN" with "True"
#    - INPUT "Enter SSN" with "{TAB}"
#    - INPUT "Enter SSN" with "a RANDOM value matching 6 random digits/characters from source expression 125{RND[6]}{TAB}"
#    - BUFFER "Enter SSN" with "SSN"
#    - INPUT "Enter SSN" with "{Doubleclick}{TAB}"
#    - INPUT "Verify" with "{Click}"
#    - WAIT (Exists) "Verify" with "False"
# Source step 0072: "Partial Buffer the Last Four of SSN" in module "TBox Partial Buffer" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-cb58-ee90-632993a50481
#    - INPUT "Buffer" with "Last4SSN"
#    - INPUT "Value" with "the RUNTIME-DERIVED source value {B[SSN]}"
#    - INPUT "Start" with "6"
# Source step 0073: "Wait for SSN mask" in module "Client|Named Insured|Individual" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-eddc-3263-04e8ba1848e0
#    - WAIT (InnerText) "Social Security # " with "XXX-XX-*"
# Source step 0074: "Validate SSN" in module "Client|Named Insured|Individual" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-a17a-f6cd-1482be959af6
#    - VERIFY (InnerText) "Social Security # " with "the RUNTIME-DERIVED source value XXX-XX-{B[Last4SSN]}"
#    - WAIT (Exists) "Please verify SSN*" with "False"
# Source step 0075: "Enter other insured info" in module "Client|Other Insured Info" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-1cd6-971b-633af7644e81
#    - INPUT "Name of Audit contact" with "{TAB}{CLICK}Auditor Doe{TAB}{TAB}" when 'Product (LOB)' != "UMB"
#    - INPUT "Audit Telephone #" with "a RANDOM value matching 10 random digits/characters from source expression {RND[10]}{TAB}" when 'Product (LOB)' != "UMB"
#    - INPUT "Name of Inspection contact" with "{TAB}{CLICK}Inspector Smith{TAB}"
#    - INPUT "Inspection Telephone #" with "a RANDOM value matching 10 random digits/characters from source expression {RND[10]}{TAB}"
#    - INPUT "Insured E-mail Address*" with "{TAB}{CLICK}insured@emailaddress.com{TAB}"
#    - INPUT "Website Address" with "https://www.InsuredSite.com{TAB}"
# Source step 0076: "Verify ZipCode+4" in module "Client|Named Insured|Common" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-6c12-f22a-3d3cfbcf2bb3
#    - INPUT "Address2" with "{TAB}{TAB}"
#    - VERIFY "ZipCode" with "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"
# Source step 0077: "Set Buffer for State and Product" in module "TBox Set Buffer" was disabled. Reason: 11.11.24 10:20:45 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-b042-25d6-3bc4136f8a02
#    - INPUT "State" with "AL"
#    - INPUT "Product (LOB)" with "WC"
#    - INPUT "Server" with "svqw-clas21:8080"
#    - INPUT "FormOnPolicyDocName" with "a blank/not-supplied reusable parameter (<BLANK — reusable-block parameter is not supplied: FormOnPolicyDocName>)"
# Source step 0123: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0124: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0125: "Check for Save for Later Button" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-7f66-3db6-9842c21b8f30
#    - VERIFY (Exists) "Save for Later" with "True"
# Source step 0126: "Save for Later" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-76d9-8f8d-5996da943954
#    - INPUT "Save for Later" with "X"
#    - WAIT (Exists) "Save for Later - OK" with "True"
#    - INPUT "Save for Later - OK" with "X"
# Source step 0127: "Check for Return to Admin Button" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-f9d4-d6c6-7d52f321bbe0
#    - VERIFY (Exists) "Return To Admin" with "True"
# Source step 0128: "Return To Admin" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-5f9c-b6f4-47437bc9202b
#    - INPUT "Return To Admin" with "X"
#    - WAIT (Exists) "Return To Admin" with "False"
# Source step 0129: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-f978-0cbd-f19adc096c80
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0130: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-8abc-9867-f990929c012d
#    - INPUT "Loop Login" with "0"
#    - INPUT "UserName" with "AG09999"
# Source step 0131: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-a389-32ec-c4d4d4b13565
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0132: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-2f8f-b126-823ffe8020d9
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0133: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-34e9-79e5-b23e4d618d34
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0134: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-95d4-9bb4-f5118c23f6b4
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0135: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-9332-c689-7a909465f482
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0136: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-9094-99aa-a2610d3e5c0f
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0137: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-d25c-0b8b-e3de85471476
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "RootObject" with "a blank/null value"
#    - GROUP "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0138: "Save changes" in module "Save JSON Resource" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-c7a3-c7e1-1895e6c948dd
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0139: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-c8d5-f0db-4f32fc40451c
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0140: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-303d-6a17-f864045325f1
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0141: "OpenUrl" in module "OpenUrl" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-916a-17b5-b2a55ed8e3ea
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - GROUP "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0142: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-8eb8-cd51-70d559357a48
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0143: "Check for Log In" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Check to see if Logged In | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-0985-6ea0-982052180323
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0144: "Logout" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-102e-a983-adc4307e7196
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0145: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-3956-5f50-8a59f926ee05
#    - INPUT "Duration" with "1000"
# Source step 0146: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-c8e2-cba3-fe4211d4e730
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0147: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-5392-1494-86a1a7ebcdfe
#    - INPUT "OK" with "X"
# Source step 0148: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-874b-7ba4-300407f44191
#    - WAIT (Visible) "OK" with "True"
# Source step 0149: "Logout" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-7b12-7284-43003f1fc51b
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0150: "Waiton Username to exist" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-66ba-603a-41cf15f66030
#    - WAIT (Exists) "UserName" with "True"
# Source step 0151: "Login" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-1cdd-bb7d-615fd13599a1
#    - INPUT "UserName" with "AG09999{TAB}"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0152: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-4ddb-a1f4-958032abeac2
#    - WAIT (Exists) "Login" with "True"
# Source step 0153: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-228f-2128-05b03e682906
#    - INPUT "Loop Login" with "1"
# Source step 0154: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2087-be9f-d668-33b56ae600ea
#    - INPUT "Filename" with "Login Error"
# Source step 0155: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161f74-2096-9fc0-e04e-09d1462d5ee8
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0156: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 07.11.24 15:32:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0157: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 07.11.24 15:32:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0166: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0062 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  WorkersCompensation  Pages   US   (9.8.0.0){ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0111 "Enter Effective Date" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}" when 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BOP"||'Product (LOB)' == "UMB"||'Product (LOB)' == "BAP"||'Product (LOB)' == "CPP"||'Product (LOB)' == "CP"||'Product (LOB)' == "CR"||'Product (LOB)' == "IM"||'Product (LOB)'=="GL"
# Active source step 0113 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "{Click}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
# Source step 0115: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){ENTER}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "BAP"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB"
#    - Preserved source field action: INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BOP" || 'Product (LOB)' == "UMB" || 'Product (LOB)' == "BAP"
# Source step 0117: "Enter Primary Rating State" in module "Policy Info|Required and Optional Fields" was not executed. Reason: All source field actions are not applicable to the selected iteration.
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
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
# Active source step 0119 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - WAIT (Exists) "PrimaryRatingState" with "True" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "PrimaryRatingState" with "{TAB}" when 'Product (LOB)' != "WC". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' != "WC"
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
# Active source step 0121 "Policy Info | WC Specific Fields" contains conditionally inapplicable field action(s):
#    - INPUT "Does applicant have a commitment to Workplace Safety and Risk Management?*" with "{CLICK}Yes{ENTER}{TAB}" when 'Workplace Saftey Question' == "Applies". Reason: Value condition evaluated false for the selected iteration: 'Workplace Saftey Question' == "Applies"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario steps were exported for this representative iteration.
