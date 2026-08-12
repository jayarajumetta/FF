@pl-dc
@generated @auto-rate-filings-policy-3-nb-prior-eff-
Feature: Auto Rate Filings Policy 3 NB_Prior Eff Date

  Scenario Outline: Auto Rate Filings Policy 3 NB_Prior Eff Date - <example>
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
      | AL | TestData/al-8.json | AL | 08.08.2025 | American National Property And Casualty Co. |
      | AR | TestData/ar-8.json | AR | 07.23.2025 | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang-5.json | AZ | 06.23.2025 | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp-5.json | AZ | 06.23.2025 | American National Property And Casualty Co. |
      | CA | TestData/ca-6.json | CA | 08.08.2025 | American National Property And Casualty Co. |
      | CO | TestData/co-8.json | CO | 08.08.2025 | American National Property And Casualty Co. |
      | CT | TestData/ct-6.json | CT | 08.08.2025 | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-8.json | DE | 08.08.2025 | American National Property And Casualty Co. |
      | GA | TestData/ga-5.json | GA | 08.08.2025 | American National Property And Casualty Co. |
      | IA | TestData/ia-8.json | IA | 08.08.2025 | American National Property And Casualty Co. |
      | ID | TestData/id-8.json | ID | 08.09.2025 | American National Property And Casualty Co. |
      | IL | TestData/il-8.json | IL | 08.08.2025 | American National Property And Casualty Co. |
      | IN | TestData/in-8.json | IN | 08.08.2025 | American National Property And Casualty Co. |
      | KS | TestData/ks-8.json | KS | 08.08.2025 | American National Property And Casualty Co. |
      | KY | TestData/ky-8.json | KY | 08.08.2025 | American National Property And Casualty Co. |
      | MD | TestData/md-6.json | MD | 08.08.2025 | American National Property And Casualty Co. |
      | ME | TestData/me-8.json | ME | 08.08.2025 | Farm Family Casualty Insurance Co. |
      | MN | TestData/mn-9.json | MN | 08.08.2025 | American National Property And Casualty Co. |
      | MO | TestData/mo-10.json | MO | 08.08.2025 | American National Property And Casualty Co. |
      | MS | TestData/ms-8.json | MS | 08.08.2025 | American National Property And Casualty Co. |
      | MT | TestData/mt-8.json | MT | 10.13.2025 | American National Property And Casualty Co. |
      | ND | TestData/nd-8.json | ND | 08.08.2025 | American National Property And Casualty Co. |
      | NE | TestData/ne-9.json | NE | 08.08.2025 | American National Property And Casualty Co. |
      | NH | TestData/nh-8.json | NH | 08.08.2025 | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-6.json | NJ | 08.08.2025 | United Farm Family Insurance Co. |
      | NM | TestData/nm-8.json | NM | 08.08.2025 | American National Property And Casualty Co. |
      | NV | TestData/nv-5.json | NV | 08.08.2025 | American National General Insurance Co. |
      | NY FFCIC | TestData/ny-ffcic-5.json | NY | 08.08.2025 | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic-5.json | NY | 08.08.2025 | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang-5.json | OH | 08.08.2025 | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp-5.json | OH | 08.08.2025 | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang-5.json | OK | 08.08.2025 | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp-5.json | OK | 08.08.2025 | American National Property And Casualty Co. |
      | OR | TestData/or-8.json | OR | 08.08.2025 | American National Property And Casualty Co. |
      | PA | TestData/pa-6.json | PA | 08.23.2025 | American National Property And Casualty Co. |
      | RI | TestData/ri-6.json | RI | 08.08.2025 | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-8.json | SC | 08.08.2025 | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang-5.json | SD | 08.08.2025 | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp-5.json | SD | 08.08.2025 | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang-5.json | TN | 08.08.2025 | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp-5.json | TN | 08.08.2025 | American National Property And Casualty Co. |
      | TX | TestData/tx-8.json | TX | 08.08.2025 | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang-5.json | UT | 06.23.2025 | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp-5.json | UT | 06.23.2025 | American National Property And Casualty Co. |
      | VA | TestData/va-6.json | VA | 08.08.2025 | American National Property And Casualty Co. |
      | VT | TestData/vt-6.json | VT | 11.24.2025 | Farm Family Casualty Insurance Co. |
      | WA | TestData/wa-5.json | WA | 08.08.2025 | American National Property And Casualty Co. |
      | WI | TestData/wi-9.json | WI | 08.08.2025 | American National Property And Casualty Co. |
      | WV | TestData/wv-6.json | WV | 08.08.2025 | American National Property And Casualty Co. |
      | WY | TestData/wy-8.json | WY | 10.11.2025 | American National Property And Casualty Co. |
