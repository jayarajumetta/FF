@pl-dc
@generated @cycle-rate-filings-policy-3-nb-prior-eff
Feature: Cycle Rate Filings Policy 3 NB_Prior Eff Date

  Scenario Outline: Cycle Rate Filings Policy 3 NB_Prior Eff Date - <example>
    Given test data file "<dataFile>" is loaded
    And the policy jurisdiction is "<stateCode>"
    And the policy effective date is "<effectiveDate>"
    And the writing company is "<writingCompany>"

    # Precondition
    Given I prepare the Home and Auto application
    And I load the required business test data

    # Process
    When I select or create the client and enter account details
    And I complete the proposal
    And I complete prequalification
    And I enter driver information
    And I enter vehicle information
    And I assign drivers to vehicles
    And I enter claims and violation history
    And I apply eligible discounts
    And I select policy coverages
    And I select additional coverages
    And I calculate and review pricing
    And I complete underwriting information
    And I enter additional interests
    And I enter billing details
    And I complete the submission
    And I complete the launch checklist
    And I validate downstream policy data

    # Postcondition
    Then I return to the submission
    And I verify the policy transmission confirmation
    And I save the generated business test results
    And I save and exit the submission


    Examples:
      | example | dataFile | stateCode | effectiveDate | writingCompany |
      | AL | TestData/al-12.json | AL | 08.08.2024 | American National Property And Casualty Co. |
      | AR | TestData/ar-12.json | AR | 08.08.2024 | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang-9.json | AZ | 08.08.2024 | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp-9.json | AZ | 08.08.2024 | American National Property And Casualty Co. |
      | CA | TestData/ca-10.json | CA | 08.08.2024 | American National Property And Casualty Co. |
      | CO | TestData/co-12.json | CO | 08.08.2024 | American National Property And Casualty Co. |
      | CT | TestData/ct-10.json | CT | 08.08.2024 | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-12.json | DE | 08.08.2024 | American National Property And Casualty Co. |
      | GA | TestData/ga-9.json | GA | 07.12.2025 | American National Property And Casualty Co. |
      | IA | TestData/ia-12.json | IA | 06.28.2025 | American National Property And Casualty Co. |
      | ID | TestData/id-12.json | ID | 08.08.2024 | American National Property And Casualty Co. |
      | IL | TestData/il-12.json | IL | 07.10.2025 | American National Property And Casualty Co. |
      | IN | TestData/in-12.json | IN | 08.08.2024 | American National Property And Casualty Co. |
      | KS | TestData/ks-12.json | KS | 08.08.2024 | American National Property And Casualty Co. |
      | KY | TestData/ky-12.json | KY | 08.18.2025 | American National Property And Casualty Co. |
      | MD | TestData/md-10.json | MD | 08.08.2024 | American National Property And Casualty Co. |
      | ME | TestData/me-12.json | ME | 08.08.2024 | Farm Family Casualty Insurance Co. |
      | MN | TestData/mn-13.json | MN | 08.08.2024 | American National Property And Casualty Co. |
      | MO | TestData/mo-14.json | MO | 08.08.2024 | American National Property And Casualty Co. |
      | MS | TestData/ms-12.json | MS | 08.08.2024 | American National Property And Casualty Co. |
      | MT | TestData/mt-12.json | MT | 08.08.2024 | American National Property And Casualty Co. |
      | ND | TestData/nd-12.json | ND | 06.15.2025 | American National Property And Casualty Co. |
      | NE | TestData/ne-13.json | NE | 08.08.2024 | American National Property And Casualty Co. |
      | NH | TestData/nh-12.json | NH | 08.08.2024 | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-10.json | NJ | 08.08.2024 | United Farm Family Insurance Co. |
      | NM | TestData/nm-12.json | NM | 08.08.2024 | American National Property And Casualty Co. |
      | NV | TestData/nv-9.json | NV | 07.03.2025 | American National General Insurance Co. |
      | NY FFCIC | TestData/ny-ffcic-9.json | NY | 08.08.2024 | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic-9.json | NY | 08.08.2024 | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang-9.json | OH | 08.08.2024 | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp-9.json | OH | 08.08.2024 | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang-9.json | OK | 08.08.2024 | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp-9.json | OK | 08.08.2024 | American National Property And Casualty Co. |
      | OR | TestData/or-12.json | OR | 08.08.2024 | American National Property And Casualty Co. |
      | PA | TestData/pa-10.json | PA | 08.08.2024 | American National Property And Casualty Co. |
      | RI | TestData/ri-10.json | RI | 08.08.2024 | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-12.json | SC | 08.08.2024 | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang-9.json | SD | 08.08.2024 | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp-9.json | SD | 08.08.2024 | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang-9.json | TN | 08.08.2024 | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp-9.json | TN | 08.08.2024 | American National Property And Casualty Co. |
      | TX | TestData/tx-12.json | TX | 06.30.2025 | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang-9.json | UT | 08.08.2024 | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp-9.json | UT | 08.08.2024 | American National Property And Casualty Co. |
      | VA | TestData/va-10.json | VA | 07.01.2025 | American National Property And Casualty Co. |
      | VT | TestData/vt-10.json | VT | 08.08.2024 | Farm Family Casualty Insurance Co. |
      | WI | TestData/wi-13.json | WI | 08.08.2024 | American National Property And Casualty Co. |
      | WV | TestData/wv-10.json | WV | 07.12.2025 | American National Property And Casualty Co. |
      | WY | TestData/wy-12.json | WY | 08.08.2024 | American National Property And Casualty Co. |
