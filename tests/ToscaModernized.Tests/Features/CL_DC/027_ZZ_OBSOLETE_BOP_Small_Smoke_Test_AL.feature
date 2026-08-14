# ==================================================================================================
# Standalone ReqnRoll + Playwright feature generated from: 027_ZZ_OBSOLETE_BOP_Small_Smoke_Test_AL.feature
# Application: Commercial Lines Duck Creek
# The original application-specific business scenario remains in source order.
# Technical/source Background operations are executed by ReqnRoll Hooks from the matching ScenarioPlan.
# Fixed values are mirrored in the matching JSON data file; RANDOM values are generated at runtime.
# Credentials and Tosca-protected payloads are externalized to environment variables.
# ==================================================================================================

@CL_DC @BOP @smoke @Alabama @Edge @manual @obsolete @archive @automated
Feature: Execute BOP | Small Smoke Test for one representative CL|DC iteration
  As a CL|DC policy processing user
  I want to complete the BOP | Small Smoke Test workflow for Alabama (AL)
  So that every source-defined action, test datum, runtime dependency, and expected result is preserved in sequence


  Background: Establish the Commercial Lines Duck Creek application context
    Given the Commercial Lines Duck Creek application context and source-defined prerequisites are initialized

  Scenario: BOP | Small Smoke Test using representative iteration Alabama (AL)

    # Source step 0001: Check the Loop Login | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e1-b192-15b3-b0341f08c6f1
    # Source template XTestStep: 3a161a84-6304-f45b-e227-d3748525dfde
    # Runtime control: Loop for the Login [max=3] > Condition
    Then I evaluate the source-defined expression for "Check the Loop Login" using "Expression={B[Loop Login]} = 0"

    # Source step 0002: Set Loop Buffer | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e1-f207-60fc-70213d2d4559
    # Source template XTestStep: 3a161a84-6304-d3bd-dc84-265641aa2838
    # Runtime control: Loop for the Login [max=3] > Loop
    When I retain hard-coded value "0" as runtime value "Loop Login"
    When I retain hard-coded value "AG09999" as runtime value "UserName"

    # Source step 0003: Close Explorer Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e1-31c1-482e-eadac72fb832
    # Source template XTestStep: 3a161a84-6304-fd96-35ce-21a97a2fb98f
    # Runtime control: Loop for the Login [max=3] > Loop
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0004: Close Chrome Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e2-c776-f40f-b2f9d87b9075
    # Source template XTestStep: 3a161a84-6304-f386-20af-ec4853cd7661
    # Runtime control: Loop for the Login [max=3] > Loop
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0005: Close Firefox Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e3-d23b-1fde-1606a59925ff
    # Source template XTestStep: 3a161a84-6304-e0a8-baa1-29b493da8534
    # Runtime control: Loop for the Login [max=3] > Loop
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0006: Close Edge Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e3-bdf3-ea7e-27327a9daec7
    # Source template XTestStep: 3a161a84-6304-1b62-cec0-7310a00333a0
    # Runtime control: Loop for the Login [max=3] > Loop
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0007: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e4-e7e3-cd62-8748ed3e8f33
    # Source template XTestStep: 3a161a84-6304-f70f-2ca8-a80f21d50168
    # Runtime control: Loop for the Login [max=3] > Loop
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0008: Open Edge Preferences file | Module: Open/Create JSON file
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e5-0ab3-3f4b-607a4348150a
    # Source template XTestStep: 3a161a84-6304-5f1a-4cdc-fef79aa78c1a
    # Runtime control: Loop for the Login [max=3] > Loop
    Given I open or create JSON resource "EdgePreferences" at "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0009: Change Exit Type | Module: Edge Preferences File
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e5-b40e-ac62-50c7a76053ba
    # Source template XTestStep: 3a161a84-6304-59f5-b9e6-0a9820f74ec7
    # Runtime control: Loop for the Login [max=3] > Loop
    When I enter or select "none" in "RootObject > profile > exit_type"

    # Source step 0010: Save changes | Module: Save JSON Resource
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e5-bb71-9986-420d3d55684a
    # Source template XTestStep: 3a161a84-6304-45da-0c59-c936c60383ea
    # Runtime control: Loop for the Login [max=3] > Loop
    When I save JSON resource "EdgePreferences" to "%userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"

    # Source step 0011: Delete EdgePreferences Resource | Module: TBox Delete Resource
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e6-8f5d-69dd-26230c911dee
    # Source template XTestStep: 3a161a84-6313-9004-288c-7dce7c7ae5ed
    # Runtime control: Loop for the Login [max=3] > Loop
    When I remove runtime resource "EdgePreferences"

    # Source step 0012: Delete Cookies File | Module: TBox Delete File
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Reset Edge Preferences | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e6-0050-c655-bdb066e96181
    # Source template XTestStep: 3a161a84-6313-e96d-0a4e-7c127bc3cb79
    # Runtime control: Loop for the Login [max=3] > Loop
    When I delete file "Cookies" from "%USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"

    # Source step 0013: OpenUrl | Module: OpenUrl
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e6-aea5-26d8-005dc8141f76
    # Source template XTestStep: 3a161a84-6313-8c15-7c9f-fe1a85d90f6b
    # Runtime control: Loop for the Login [max=3] > Loop
    When I open "https://clasq.anico.com/Express/" in the active browser tab
    # Granular source value retained: INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"

    # Source step 0014: Maximize Window | Module: TBox Window Operation
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e6-7a51-bfdb-2a46f824c277
    # Source template XTestStep: 3a161a84-6313-e23d-dd9f-d8da66b0759f
    # Runtime control: Loop for the Login [max=3] > Loop
    When I perform window operation "Maximize" on window "Duck Creek*"

    # Source step 0015: Check for Log In | Module: Logout
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Check to see if Logged In | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e7-6082-1ca0-8660854a26b3
    # Source template XTestStep: 3a161a84-6313-4d8e-76ab-9fbc5a3cd1bb
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Condition
    Then "Logged In User" should exist

    # Source step 0016: Logout | Module: Logout
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e7-e58a-fa12-b816d608b0ef
    # Source template XTestStep: 3a161a84-6313-d2f3-4aaf-e2995a5810b6
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0017: Sync for Log out | Module: TBox Wait
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e7-8516-4ad4-3ddca7bebf25
    # Source template XTestStep: 3a161a84-6313-0bfc-fb56-c0e7e4ff7ac6
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Then
    When I wait "1000" milliseconds

    # Source step 0018: Check for Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e7-9f87-d8e0-7fc6d51a966a
    # Source template XTestStep: 3a161a84-6313-b086-68e9-4b21f38098c5
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Then > If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0019: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e8-0438-3416-f1dc0d133212
    # Source template XTestStep: 3a161a84-6313-1055-1674-7a9eb5e94a97
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Then > If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0020: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e8-2f62-5fec-2bdba257e7d1
    # Source template XTestStep: 3a161a84-6313-e988-f4fa-01934000c9bc
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Then > If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0021: Logout | Module: Logout
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e8-45d3-3706-f59736684a42
    # Source template XTestStep: 3a161a84-6313-d312-711d-558d240a27cf
    # Runtime control: Loop for the Login [max=3] > Loop > If Still Logged In > Then > If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0023: Login | Module: Login
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e9-05b7-313f-921d19d64e4d
    # Source template XTestStep: 3a161a84-6313-f9ff-d018-7b5db3e46b65
    # Runtime control: Loop for the Login [max=3] > Loop
    When I enter or select "AG0U388{TAB}" in "UserName"
    When I enter or select "${ENV:CL_DC_PASSWORD}" in "Password"
    When I click or select "Login"

    # Source step 0024: Wait for Login Screen to Go Away | Module: Login
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e9-9274-3224-32966fd04c75
    # Source template XTestStep: 3a161a84-6313-8e82-6c86-5032f822dc52
    # Runtime control: Loop for the Login [max=3] > Loop > If Login Screen goes away > Condition
    Then I wait until "Login" no longer exists

    # Source step 0025: Set Loop Buffer to Exit Loop | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e9-71ad-39a5-dd70efe67709
    # Source template XTestStep: 3a161a84-6313-02bf-6c64-be7227e4ef78
    # Runtime control: Loop for the Login [max=3] > Loop > If Login Screen goes away > Then
    When I retain hard-coded value "1" as runtime value "Loop Login"

    # Source step 0026: Take Screenshot of Login | Module: TBox Take Screenshot
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e9-fd23-b494-c8d84230298d
    # Source template XTestStep: 3a161a84-6313-7017-4071-932b7936b1c6
    # Runtime control: Loop for the Login [max=3] > Loop > If Login Screen goes away > Else Take Screenshot and Loop
    When I capture a "Desktop" screenshot at "the configured source path"

    # Source step 0027: Retrieve Dex Agent Name | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4ea-8ff5-7bef-8d9e4e0cdf73
    # Source template XTestStep: 3a161a84-6313-0e9a-cb30-8b72854d1840
    When I derive and retain the RUNTIME-DERIVED expression "\"\"\"${COMPUTERNAME}\"\"\"" as runtime value "GetHostname"
    When I derive and retain the RUNTIME-DERIVED buffer expression "{B[GetHostname]}" as runtime value "AgentName"

    # Source step 0028: Initiate a New Quote | Module: Common Navigation Links
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-e0bf-927f-5ec1a6b5218a
    When I click or select "New Quote"

    # Source step 0029: Select Agency and Product | Module: Product Selection
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-78aa-5295-3da4b7d394dd
    When I enter or select "03-01-2025{TAB}" in "Effective Date:*"
    When I capture "Effective Date:*" as runtime value "NBEffDate"
    When if field condition "'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\"" is satisfied, I enter or select "{CLICK}Carrier  BusinessOwners  Pages   US   4.3.0.0{ENTER}{TAB}" in "Product:*"
    Then I wait until "Start" is visible
    When I click or select "Start"
    When I click or select "Start"

    # Source step 0030: Set NBEffDate Buffer | Module: TBox Set Buffer
    # Section: Run New Smoke > Precondition | Reusable flow: Common|General|Start New Quote | Source XTestStep: 3a13d49c-165b-8a6f-caa1-29190033e33f
    When I retain hard-coded value "03-01-2025" as runtime value "NBEffDate"

    # Source step 0031: Uncheck Quick Quote | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-477c-510c-7ad43036cba4
    When I enter or select "False" in "Quick Quote"

    # Source step 0032: Wait on non-quick quote element | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3cbc-4aa7-a1c7b75ee619
    Then I wait until "Underwriting Info" exists

    # Source step 0033: Select Individual Insured | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-8c16-d826-567aed4c90ca
    When I enter or select "Individual/Person{ENTER}{TAB}{TAB}{TAB}" in "Insured Type"
    When I click or select "Entity Type"

    # Source step 0034: Enter Name and DOB | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-3ecf-8633-002f64245127
    Then I wait until "First Name" is visible
    When I enter or select "{TAB}{TAB}" in "First Name"
    When I enter or select "{CLICK}John{TAB}{TAB}" in "First Name"
    When I enter or select "AL{TAB}{TAB}" in "Middle Name"
    When I enter or select "{TAB}{TAB}" in "Last Name"
    When I enter RUNTIME-DERIVED value "{DATE[][-40y][MM-dd-yyyy]}{TAB}{TAB}" in "DOB"
    When if field condition "State!=\"CA\"" is satisfied, I enter or select "Male{TAB}{TAB}" in "Gender"
    When I enter a RANDOM value matching "^[a-z]{4}$" in "Last Name"

    # Source step 0035: Select Individual Sole Proprietor | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-f281-684f-979ca5404005
    When I enter or select "Individual/Sole Proprietor{ENTER}{TAB}{TAB}" in "Entity Type"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}{TAB}{TAB}{TAB}" in "Primary Phone"
    When I enter or select "{TAB}1918 Avalon Ave{TAB}" in "Address1"
    When I enter or select "{TAB}35661{TAB}" in "ZipCode"

    # Source step 0036: Click Client search | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-7952-2e48-6b516ae5679d
    When I click or select "Client Search"

    # Source step 0037: Client Search Results | Module: Client Search Results
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-62f0-721e-d093b870cfd8
    Then I wait until "Search Results > Duck Creek Policy > OK" exists
    When I click or select "Search Results > Duck Creek Policy > OK"

    # Source step 0038: Enter SSN | Module: Client|Named Insured|Individual
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

    # Source step 0039: Partial Buffer the Last Four of SSN | Module: TBox Partial Buffer
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-cb58-ee90-632993a50481
    When I perform the source-defined partial-buffer operation "Partial Buffer the Last Four of SSN" using "Buffer=Last4SSN; Value={B[SSN]}; Start=6"

    # Source step 0040: Wait for SSN mask | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-eddc-3263-04e8ba1848e0
    Then I wait until "Social Security # " property "InnerText" equals "XXX-XX-*"

    # Source step 0041: Validate SSN | Module: Client|Named Insured|Individual
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-a17a-f6cd-1482be959af6
    Then "Social Security # " property "InnerText" should equals "XXX-XX-{B[Last4SSN]}"
    Then I wait until "Please verify SSN*" no longer exists

    # Source step 0042: Enter other insured info | Module: Client|Other Insured Info
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-1cd6-971b-633af7644e81
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter or select "{TAB}{CLICK}Auditor Doe{TAB}{TAB}" in "Name of Audit contact"
    When if field condition "'Product (LOB)' != \"UMB\"" is satisfied, I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Audit Telephone #"
    When I enter or select "{TAB}{CLICK}Inspector Smith{TAB}" in "Name of Inspection contact"
    When I enter a RANDOM value matching "10 random digits/characters from source expression {RND[10]}{TAB}" in "Inspection Telephone #"
    When I enter or select "{TAB}{CLICK}insured@emailaddress.com{TAB}" in "Insured E-mail Address*"
    When I enter or select "https://www.InsuredSite.com{TAB}" in "Website Address"

    # Source step 0043: Verify ZipCode+4 | Module: Client|Named Insured|Common
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-6c12-f22a-3d3cfbcf2bb3
    When I enter or select "{TAB}{TAB}" in "Address2"
    Then "ZipCode" property "value" should equals "{REGEX[\"[0-9]{5}-[0-9]{4}\"]}"

    # Source step 0044: Set Buffer for State and Product | Module: TBox Set Buffer
    # Section: Run New Smoke > Smoke Process > Common|Enter Individual Client | Reusable flow: Common|Client|Enter Individual Client Info | Source XTestStep: 3a13d49c-165b-b042-25d6-3bc4136f8a02
    When I retain hard-coded value "AL" as runtime value "State"
    When I retain hard-coded value "BOP" as runtime value "Product (LOB)"
    When I retain hard-coded value "svqw-clas21:8080" as runtime value "Server"
    When I retain a blank/not-supplied value as runtime value "FormOnPolicyDocName"

    # Source step 0045: Get Quote ID and Buffer | Module: Verify JavaScript Result
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Get Quote ID and Buffer | Source XTestStep: 3a13d49c-165b-6bdf-2cdc-5846c562c6d2
    When I enter or select "*" in "Title"
    When I enter or select "return 1+2" in "JavaScript"
    Then "Result" property "value" should equals "3"

    # Source step 0046: Navigate to Policy Info Screen | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-897b-6196-e4e1e7e6c5cc
    When I click or select "Policy Info"

    # Source step 0047: Wait for screen to appear | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d639-8c4c-a1d7be293047
    Then I wait until "Policy Info Header" exists

    # Source step 0048: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d59a-b199-bfa0e20eb400
    When I wait "250" milliseconds

    # Source step 0049: Enter Effective Date | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-be22-b57e-1a49f8047592
    When I enter or select "03-01-2025{TAB}" in "EffectiveDate"
    When if field condition "'Product (LOB)' == \"BOP\"||'Product (LOB)' == \"UMB\"||'Product (LOB)' == \"BAP\"||'Product (LOB)' == \"CPP\"||'Product (LOB)' == \"CP\"||'Product (LOB)' == \"CR\"||'Product (LOB)' == \"IM\"||'Product (LOB)'==\"GL\"" is satisfied, I enter or select "6{TAB}" in "Years In Business"

    # Source step 0050: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-a1b6-477b-f9dc20337f75
    When I wait "250" milliseconds

    # Source step 0051: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0b7f-87f4-19724986fbea
    When if field condition "NOT(('Product (LOB)' == \"WC\")||('Product (LOB)' == \"BOP\" && 'PrimaryRatingState'==\"Kansas\"))" is satisfied, I enter or select "Alabama{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I click or select "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{TAB}No{Tab}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"

    # Source step 0052: State is Kansas | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-0ce9-0ee2-9fa7a64332d9
    # Runtime control: If State is Kansas > Check if State is Kansas
    Then I evaluate the source-defined expression for "State is Kansas" using "Expression=Alabama==\"Kansas\"; Expression= 'Alabama'=='Kansas'"

    # Source step 0053: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-e0d3-dc4d-1e08a8be164d
    # Runtime control: If State is Kansas > Then
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "(select){ENTER}{TAB}{TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\" || 'Product (LOB)' == \"UMB\" || 'Product (LOB)' == \"BAP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0054: State is Virginia | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-d875-773a-994172cf9b91
    # Runtime control: If State is Virginia > Check if state is Virginia
    Then I evaluate the source-defined expression for "State is Virginia" using "Expression=Alabama==\"Virginia\"; Expression= 'Alabama'=='Virginia'"

    # Source step 0055: Enter Primary Rating State | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-5d9e-6c23-c593e552e638
    # Runtime control: If State is Virginia > Then
    When if field condition "'Product (LOB)' == \"BOP\"" is satisfied, I enter or select "(select){TAB}" in "PrimaryRatingState"
    When if field condition "'Product (LOB)' == \"BOP\"" is satisfied, I enter or select "Alabama{Down}{Enter}{TAB}{TAB}" in "PrimaryRatingState"

    # Source step 0056: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-3893-b9cb-4e02d75c2589
    When I wait "750" milliseconds

    # Source step 0057: Tab out of Primary Rating State Field (For syncronization) | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-c853-d6bb-b6934e60d372
    Then if field condition "'Product (LOB)' != \"WC\"" is satisfied, I wait until "PrimaryRatingState" exists
    When if field condition "'Product (LOB)' != \"WC\"" is satisfied, I perform keyboard action "{TAB}" on "PrimaryRatingState"
    When I enter or select "{CLICK}No{ENTER}{TAB}" in "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days?"
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Prior American National Policy #*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > What is the primary reason this new policy is being rewritten with Farm Family/American National?*" should not exist
    Then "Were the exposures insured on this policy previously insured for this client on another Farm Family/American National Policy within the last 90 days? > Is this policy being fully cancelled?*" should not exist

    # Source step 0058: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info| Fill Out Required Fields | Source XTestStep: 3a13d49c-165b-6642-f458-b4fb86163d83
    When I wait "250" milliseconds

    # Source step 0059: ------->>> DESCRIPTION BUFFER | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation | Source XTestStep: 3a13d49c-165b-293d-aa04-0d5c0420386a
    Then I wait until "Policy Info Header" is visible
    Then I wait until "Description of Specified Operation" is visible
    When I perform keyboard action "{TAB}" on "Description of Specified Operation"
    When I enter RUNTIME-DERIVED value "AL BOP Basic {NMONTH}.{NDAY}.{NYEAR} {Time}{TAB}" in "Description of Specified Operation"
    Then "Description of Specified Operation" property "value" should equals "{XB[QuoteDescription]}"

    # Source step 0062: Wait for Synchronization | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-db96-2f0e-1e230bb9a656
    When I wait "1500" milliseconds

    # Source step 0063: Insurance Score | Module: Policy Info|Insurance Score
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-84af-bc6a-3f9f6e937252
    # Runtime control: Do [max=120] > Condition
    Then "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS" should exist

    # Source step 0064: Check if it is BAP VT | Module: TBox Evaluation Tool
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-faf3-28ce-cca724db461f
    # Runtime control: Do [max=120] > Loop > If BAP VT > Condition
    Then I evaluate the source-defined expression for "Check if it is BAP VT" using "Expression='{B[Product (LOB)]}' = 'BAP' && '{B[State]}'= 'VT'"

    # Source step 0065: Click Insurance Score Consent if available | Module: Policy Info|Insurance Score
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-62c0-b9ad-e9b0b9d872db
    # Runtime control: Do [max=120] > Loop > If BAP VT > Then
    When I click or select "Insurance Score Consent"
    Then I wait until "IFRAME > Popup > Accept" exists
    When I click or select "IFRAME > Popup > Accept"
    Then I wait until "Insurance Score" exists

    # Source step 0066: Click Insurance Score and wait for Loading Window | Module: Policy Info|Insurance Score
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-6d8c-4d68-2f07c426a43c
    # Runtime control: Do [max=120] > Loop
    When I click or select "Insurance Score"

    # Source step 0067: Insurance Score | Module: Policy Info|Insurance Score
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-dba3-ee02-3503baa413fb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Condition
    Then "Reference Number" property "InnerText" should equals "\"\""

    # Source step 0068: Wait 1/2 Second for a max of 60 seconds | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-4380-87c1-5285e9b2c0eb
    # Runtime control: Do [max=120] > Loop > Wait for Insurance Score to Populate [max=40] > Loop
    When I wait "500" milliseconds

    # Source step 0072: Wait 1/2 Second | Module: TBox Wait
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3c33-8cfc-5b97480b4dd3
    When I wait "500" milliseconds

    # Source step 0106: Navigate to Policy Info | Module: Common Navigation Links
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Small Smoke|Navigate to Policy Info and Verify Desc | Source XTestStep: 3a1619ee-cb71-3900-9d9f-d047b008fe38
    When I click or select "Policy Info"

    # Source step 0107: Policy Info|Verify Description of Specified Operation | Module: Policy Info|Required and Optional Fields
    # Section: Run New Smoke > Smoke Process | Reusable flow: Common|Small Smoke|Navigate to Policy Info and Verify Desc | Source XTestStep: 3a1619ea-9f25-47ea-9a5a-f370a0fbda64
    Then "Description of Specified Operation" property "value" should equals "{B[QuoteDescription]}"

    # Source step 0108: Logout | Module: Logout
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-f91a-b5de-ec24851f1092
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0109: Sync for Log out | Module: TBox Wait
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd82-ee13-a8e3-e990-700201b7767f
    When I wait "1000" milliseconds

    # Source step 0110: Check for Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-62aa-95ff-f6d8b76c90b1
    # Runtime control: If Error Msg Exists > Check if Error Msg Exists
    Then "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" should exist

    # Source step 0111: Click OK on Http Error Msg | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-53c6-4142-f9728cfaee2b
    # Runtime control: If Error Msg Exists > Then
    When I click or select "OK"

    # Source step 0112: Check Http Error Msg does not exist | Module: Http Error Msg
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-0d6f-117a-0c2b-317a4b5a0333
    # Runtime control: If Error Msg Exists > Then
    Then I wait until "OK" no longer is visible

    # Source step 0113: Logout | Module: Logout
    # Section: Run New Smoke > Post Condition > Http Error Msg | Reusable flow: Common|General|Logout | Source XTestStep: 3a13fd63-bec2-69ea-d0bf-57cc476fc9b2
    # Runtime control: If Error Msg Exists > Then
    When I click or select "Logged In User"
    When I click or select "Logged In User > Logout"

    # Source step 0115: Close Explorer Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-c58c-edf0-0234c7c08a4e
    When I force-close browser/process "iexplore.exe" using command "taskkill /f /im iexplore.exe" with a maximum exit wait of "5" seconds

    # Source step 0116: Close Chrome Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-e417-4680-2ffcb4d88537
    When I force-close browser/process "Chrome.exe" using command "taskkill /f /im Chrome.exe" with a maximum exit wait of "5" seconds

    # Source step 0117: Close Edge Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-a5b9-af89-e11b7d3d2a63
    When I force-close browser/process "MicrosoftEdge.exe" using command "taskkill /f /im MicrosoftEdge.exe" with a maximum exit wait of "5" seconds

    # Source step 0118: Close Firefox Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-3cf4-0c26-f914c79b6240
    When I force-close browser/process "Firefox.exe" using command "taskkill /f /im Firefox.exe" with a maximum exit wait of "5" seconds

    # Source step 0119: Close Edge Beta Browsers | Module: TBox Start Program
    # Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Post Condition | Source XTestStep: 3a13d49c-165b-df19-a24b-c746ff8c164a
    When I force-close browser/process "msEdge.exe" using command "taskkill /f /im msEdge.exe" with a maximum exit wait of "5" seconds

# --------------------------------------------------------------------------------------------------
# SOURCE-DISABLED TOSCA ACTIONS — intentionally excluded from the executable scenario
# --------------------------------------------------------------------------------------------------
# Source step 0022: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Precondition > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161e5b-a4e8-7d69-48ca-6f1cf859f794
#    - WAIT (Exists) "UserName" with "True"
# Source step 0060: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141601-c534-8b80-388b-028f54c064da
#    - INPUT "Start" with "x"
# Source step 0061: "Taskbar|Start Button Click Once" in module "Taskbar|Start Button" was disabled. Reason: 27.10.25 11:14:56 [ff01620@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|BUFFER: Description of Specified Operation > Common|General|Mask Error Recovery | Source XTestStep: 3a141602-8798-4778-640a-dab2517fd518
#    - INPUT "Start" with "x"
# Source step 0069: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:56 [ff01620]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-d800-16b1-204343afb7e1
#    - INPUT "Duration" with "1500"
# Source step 0070: "Click Insurance Score and wait for Loading Window" in module "Policy Info|Insurance Score" was disabled. Reason: 14.04.20 08:18:24 [ff01620]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-06ca-978e-d5200f0622bb
#    - WAIT (Exists) "Insurance Score" with "False"
# Source step 0071: "Wait for Synchronization" in module "TBox Wait" was disabled. Reason: 14.04.20 08:18:31 [ff01620]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|Policy Info|Run Insurance Score | Source XTestStep: 3a13d49c-165b-3a41-fade-9ac567a11717
#    - INPUT "Duration" with "1500"
# Source step 0073: "Check for Save for Later Button" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-7f66-3db6-9842c21b8f30
#    - VERIFY (Exists) "Save for Later" with "True"
# Source step 0074: "Save for Later" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-76d9-8f8d-5996da943954
#    - INPUT "Save for Later" with "X"
#    - WAIT (Exists) "Save for Later - OK" with "True"
#    - INPUT "Save for Later - OK" with "X"
# Source step 0075: "Check for Return to Admin Button" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-f9d4-d6c6-7d52f321bbe0
#    - VERIFY (Exists) "Return To Admin" with "True"
# Source step 0076: "Return To Admin" in module "Common Navigation Links" was disabled. Reason: 07.11.24 15:24:07 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Save for Later/Return to Admin | Source XTestStep: 3a13d49c-165b-5f9c-b6f4-47437bc9202b
#    - INPUT "Return To Admin" with "X"
#    - WAIT (Exists) "Return To Admin" with "False"
# Source step 0077: "Check the Loop Login" in module "TBox Evaluation Tool" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a715-16b9-7b41-ac90e1768252
#    - VERIFY "Expression" with "the RUNTIME-DERIVED source value {B[Loop Login]} = 0"
# Source step 0078: "Set Loop Buffer" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a716-3944-490a-61a033535dd6
#    - INPUT "Loop Login" with "0"
#    - INPUT "UserName" with "AG09999"
# Source step 0079: "Close Explorer Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a716-8ce6-8288-0dc3d34af15f
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "iexplore.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0080: "Close Chrome Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a717-393b-09d1-4177f3935b42
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Chrome.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0081: "Close Firefox Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a718-b1b2-665d-73ee0c4507ee
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "Firefox.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0082: "Close Edge Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a719-2dc4-33d3-8a98338a53ce
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "MicrosoftEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0083: "Close Edge Beta Browsers" in module "TBox Start Program" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a71a-c9f4-ec30-15526ed3e89a
#    - INPUT "Path" with "taskkill"
#    - GROUP "Arguments" with "a blank/null value"
#    - INPUT "Arguments > Argument" with "/f"
#    - INPUT "Arguments > Argument" with "/im"
#    - INPUT "Arguments > Argument" with "msEdge.exe"
#    - GROUP "WaitForExit" with "True"
#    - INPUT "WaitForExit > TimeoutForExit" with "5"
# Source step 0084: "Open Edge Preferences file" in module "Open/Create JSON file" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a729-2229-5354-7d54a255919a
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0085: "Change Exit Type" in module "Edge Preferences File" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a729-6cfe-fe3d-9a87ff229e67
#    - GROUP "Resource" with "EdgePreferences"
#    - GROUP "RootObject" with "a blank/null value"
#    - GROUP "RootObject > profile" with "a blank/null value"
#    - INPUT "RootObject > profile > exit_type" with "none"
# Source step 0086: "Save changes" in module "Save JSON Resource" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72a-97d9-6df4-fc837b5b227d
#    - INPUT "Resource" with "EdgePreferences"
#    - INPUT "Filepath" with "the RUNTIME-DERIVED source value %userprofile%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Preferences"
# Source step 0087: "Delete EdgePreferences Resource" in module "TBox Delete Resource" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences > Reset Exit_Type (Restore last session popup) | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72a-a8d7-555b-e3d67c603017
#    - INPUT "Resource" with "EdgePreferences"
# Source step 0088: "Delete Cookies File" in module "TBox Delete File" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Reset Edge Preferences | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72b-aa59-4e48-19e5c8d82d56
#    - INPUT "Directory" with "the RUNTIME-DERIVED source value %USERPROFILE%\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
#    - INPUT "File" with "Cookies"
# Source step 0089: "OpenUrl" in module "OpenUrl" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72b-130c-2489-ca2d590c42fe
#    - INPUT "Url" with "https://clasq.anico.com/Express/"
#    - INPUT "UseActiveTab" with "a blank/null value"
#    - GROUP "WebDriverBrowserArguments" with "a blank/null value"
#    - INPUT "WebDriverBrowserArguments > Argument" with "--silent-debugger-extension-api"
# Source step 0090: "Maximize Window" in module "TBox Window Operation" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72c-4e8d-70ee-963e4ddfd8ae
#    - INPUT "Caption" with "Duck Creek*"
#    - INPUT "Operation" with "Maximize"
# Source step 0091: "Check for Log In" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Check to see if Logged In | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72c-86f8-b0ec-9b3e4feef8c5
#    - VERIFY (Exists) "Logged In User" with "True"
# Source step 0092: "Logout" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72c-7c1d-baff-7c0f627a4378
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0093: "Sync for Log out" in module "TBox Wait" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72d-34a4-300e-6665d702af3c
#    - INPUT "Duration" with "1000"
# Source step 0094: "Check for Http Error Msg" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72d-dcbb-30c6-7af06d1852a3
#    - VERIFY (Exists) "The browser was unable to communicate with the server. HTTP Status Error - , HTTP Status - 0" with "True"
# Source step 0095: "Click OK on Http Error Msg" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72d-a919-932f-3836db410ce2
#    - INPUT "OK" with "X"
# Source step 0096: "Check Http Error Msg does not exist" in module "Http Error Msg" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72e-7f2f-2ff7-0313cf10a9bd
#    - WAIT (Visible) "OK" with "True"
# Source step 0097: "Logout" in module "Logout" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout > Http Error Msg | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72e-ea7f-1cfd-1c80d59fc862
#    - INPUT "Logged In User" with "{Click}"
#    - INPUT "Logged In User > Logout" with "X"
# Source step 0098: "Waiton Username to exist" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com] | 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek > Common|General|Logout | Reusable flow: <none> | Source XTestStep: 3a161e5b-a72f-ac7c-964a-90456231da83
#    - WAIT (Exists) "UserName" with "True"
# Source step 0099: "Login" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a730-a287-a65e-8ab451cd2dca
#    - INPUT "UserName" with "AG09999{TAB}"
#    - INPUT "Password" with "${ENV:CL_DC_PASSWORD}"
#    - INPUT "Login" with "X"
# Source step 0100: "Wait for Login Screen to Go Away" in module "Login" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a730-0031-fda9-5b8bd5c8a20b
#    - WAIT (Exists) "Login" with "True"
# Source step 0101: "Set Loop Buffer to Exit Loop" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a731-08f9-be6b-aaf2975ab558
#    - INPUT "Loop Login" with "1"
# Source step 0102: "Take Screenshot of Login" in module "TBox Take Screenshot" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a731-8a38-8e13-118238b18605
#    - INPUT "Filename" with "Login Error"
# Source step 0103: "Retrieve Dex Agent Name" in module "TBox Set Buffer" was disabled. Reason: 07.11.24 15:23:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process > Common|General|Log In to DuckCreek | Reusable flow: <none> | Source XTestStep: 3a161e5b-a732-c47c-6f23-94cacfe4d926
#    - INPUT "GetHostname" with "the RUNTIME-DERIVED source value \"\"\"${COMPUTERNAME}\"\"\""
#    - INPUT "AgentName" with "the RUNTIME-DERIVED source value {B[GetHostname]}"
# Source step 0104: "Enter Desc in QuickSearch" in module "Dashboard|QuickSearch" was disabled. Reason: 07.11.24 15:32:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-8f31-b52b-f361f8bff3e4
#    - INPUT "Search Text" with "the RUNTIME-DERIVED source value {B[QuoteDescription]}{TAB}{TAB}{TAB}{TAB}"
#    - INPUT "QuickSearch Button" with "X"
# Source step 0105: "Enter Info to Search by Desc" in module "Dashboard|Search for Policies / Quotes" was disabled. Reason: 07.11.24 15:32:39 [FF01729@dnanico1.aniconet.com]
# Section: Run New Smoke > Smoke Process | Reusable flow: Common|General|Search by Desc | Source XTestStep: 3a13d49c-165b-4d07-6103-6bfdee99288b
#    - INPUT "Search Method (e.g. Description/Policy#)" with "Description{TAB}"
#    - INPUT "Search Button" with "{Click}"
#    - WAIT (Exists) "View Policy" with "True"
#    - INPUT "View Policy" with "{TAB}"
#    - INPUT "View Policy" with "X"
# Source step 0114: "Waiton Username to exist" in module "Login" was disabled. Reason: 02.08.24 09:13:13 [Admin]
# Section: Run New Smoke > Post Condition | Reusable flow: Common|General|Logout | Source XTestStep: 3a13d49c-165b-5d28-b7d5-c93c8b451278
#    - WAIT (Exists) "UserName" with "True"
#
# CONDITIONAL TOSCA ACTIONS NOT APPLICABLE TO THIS REPRESENTATIVE ITERATION
# Active source step 0029 "Select Agency and Product" contains conditionally inapplicable field action(s):
#    - INPUT "Choose SFP" with "{CLICK}Carrier  BusinessOwners  Pages   US   4.3.0.0{ENTER}{TAB}" when 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)". Reason: Value condition evaluated false for the selected iteration: 'Product:*' == "Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)"
#    - INPUT "Producer:*" with "{Click}HERALD BENNETT2{ENTER}{TAB}" when 'Producer' == "AG09999"|'MA Auto'=="Yes". Reason: Value condition evaluated false for the selected iteration: 'Producer' == "AG09999"|'MA Auto'=="Yes"
# Active source step 0035 "Select Individual Sole Proprietor" contains conditionally inapplicable field action(s):
#    - INPUT "Years In Business" with "6{TAB}{TAB}" when 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "WC"||'Product (LOB)' == "SFP"
# Active source step 0053 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
# Active source step 0055 "Enter Primary Rating State" contains conditionally inapplicable field action(s):
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "UMB". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "UMB"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "BAP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "BAP"
#    - INPUT "PrimaryRatingState" with "(select){TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
#    - INPUT "PrimaryRatingState" with "Alabama{Down}{Enter}{TAB}{TAB}" when 'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "GL OCP"
# Active source step 0057 "Tab out of Primary Rating State Field (For syncronization)" contains conditionally inapplicable field action(s):
#    - INPUT "Farm Type*" with "Rabbits{TAB}" when 'Product (LOB)' == "SFP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"
#    - INPUT "Years In Business" with "6" when 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP". Reason: Value condition evaluated false for the selected iteration: 'Product (LOB)' == "SFP"||'Product (LOB)' == "GL OCP"
#
# RECOVERY BEHAVIOR FROM TOSCA — automation support, not normal manual business flow
# No RecoveryScenario steps were exported for this representative iteration.
