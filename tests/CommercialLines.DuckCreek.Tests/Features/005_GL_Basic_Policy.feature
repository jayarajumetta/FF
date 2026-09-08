@CL_DC @basic_new_business_policy

Feature: GL Basic Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL Basic Policy workflow
  So that the business transaction is executed with source-traceable data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: GL Basic Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I complete Underwriting Info from Client Screen
    And I complete required policy information
    And I complete CGL Fields
    And I add Class
    And I add [CG0435] Employee Benefits Liability Endorsement
    And I add [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations)
    And I add [CG 2149] Total Pollution Exclusion Endorsement
    And I verify and Fill out [FG0055] Employment Practices Liability Insurance Coverage Endorsement
    And I add Addl Interest [CG2007] - Engineers
    And I add Addl Interest [CG2020] Add'l Insured-Charitable Institution
    And I add Addl Interest [CG2023] Add'l Insured-Executors
    And I add Addl Interest [CG2025] Add'l Insured-Executive Officers
    And I add Addl Interest [CG2034] Add'l Insured-Leased Equipment Automatic
    And I add notepad comment
    And I switch to UW Director for OR and WA when required
    And I answer GL UW Questions OR & WA
    And I complete required billing information
    And I complete required submission information
    And I switch back to Agent for OR and WA when required
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | stateCode | dataFile                                       | stateVariant | stateName     | externalDataFile                    |
      | AZ        | TestData/Scenarios/005_gl_basic_policy_az.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Scenarios/005_gl_basic_policy_ct.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Scenarios/005_gl_basic_policy_de.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Scenarios/005_gl_basic_policy_ma.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Scenarios/005_gl_basic_policy_md.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Scenarios/005_gl_basic_policy_me.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Scenarios/005_gl_basic_policy_nh.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Scenarios/005_gl_basic_policy_nj.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Scenarios/005_gl_basic_policy_ny.json | NY           | New York      | TestData/ExternalDataOverrides.json |
      | OR        | TestData/Scenarios/005_gl_basic_policy_or.json | OR           | Oregon        | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Scenarios/005_gl_basic_policy_pa.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Scenarios/005_gl_basic_policy_ri.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Scenarios/005_gl_basic_policy_va.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Scenarios/005_gl_basic_policy_vt.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
      | WA        | TestData/Scenarios/005_gl_basic_policy_wa.json | WA           | Washington    | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Scenarios/005_gl_basic_policy_wv.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |

