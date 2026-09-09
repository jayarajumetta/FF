@CL_DC @owners_and_contractors_protective_new_business

Feature: GL OCP Policy
  As a Commercial Lines Duck Creek policy processing user
  I want to complete the GL OCP Policy workflow
  So that the business transaction is executed with maintainable test data and verification

  Background: Prepare Commercial Lines Duck Creek for policy processing
    Given I open a browser session
  Scenario Outline: GL OCP Policy - <stateCode>
    Given test data "<dataFile>" and external data "<externalDataFile>" are loaded
    And I open the configured Commercial Lines Duck Creek application
    And I sign in to Commercial Lines Duck Creek using configured credentials
    When I enter individual client information
    And I complete Underwriting Info from Client Screen
    And I complete required policy information
    And I complete OCP Fields
    And I complete OCP Risk Fields
    And I complete [CG0424] Coverage for Injury to Leased Workers
    And I complete [CG2401] Non-Binding Arbitration
    And I complete [CG2812] Pesticide or Herbicide Applicator Coverage
    And I complete [CG3132] Limited Fungi or Bacteria Coverage
    And I complete [CG 20 31] Add'l Insured-Engineers, Architects OCP
    And I complete [CG 29 35] Add'l Insured-State or Political (Permits)
    And I complete [FG0013] - Automatic Additional Insured - Specific
    And I answer GL UW Questions OR & WA
    And I complete required billing information
    And I add notepad comment
    And I complete required submission information
    And I run Stoplight
    And I verify values in premium fields
    And I complete forms verification
    And I sign out of the application

    Examples:
      | stateCode | dataFile                                     | stateVariant | stateName     | externalDataFile                    |
      | AZ        | TestData/Basic/AZ.json | AZ           | Arizona       | TestData/ExternalDataOverrides.json |
      | CT        | TestData/Basic/CT.json | CT           | Connecticut   | TestData/ExternalDataOverrides.json |
      | DE        | TestData/Basic/DE.json | DE           | Delaware      | TestData/ExternalDataOverrides.json |
      | MA        | TestData/Basic/MA.json | MA           | Massachusetts | TestData/ExternalDataOverrides.json |
      | MD        | TestData/Basic/MD.json | MD           | Maryland      | TestData/ExternalDataOverrides.json |
      | ME        | TestData/Basic/ME.json | ME           | Maine         | TestData/ExternalDataOverrides.json |
      | NH        | TestData/Basic/NH.json | NH           | New Hampshire | TestData/ExternalDataOverrides.json |
      | NJ        | TestData/Basic/NJ.json | NJ           | New Jersey    | TestData/ExternalDataOverrides.json |
      | NY        | TestData/Basic/NY.json | NY           | New York      | TestData/ExternalDataOverrides.json |
      | PA        | TestData/Basic/PA.json | PA           | Pennsylvania  | TestData/ExternalDataOverrides.json |
      | RI        | TestData/Basic/RI.json | RI           | Rhode Island  | TestData/ExternalDataOverrides.json |
      | VA        | TestData/Basic/VA.json | VA           | Virginia      | TestData/ExternalDataOverrides.json |
      | VT        | TestData/Basic/VT.json | VT           | Vermont       | TestData/ExternalDataOverrides.json |
      | WV        | TestData/Basic/WV.json | WV           | West Virginia | TestData/ExternalDataOverrides.json |

