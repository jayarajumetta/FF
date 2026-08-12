@pl-dc
@generated @auto-rate-filings-common-policy-nb
Feature: Auto Rate Filings Common Policy NB

  Scenario Outline: Auto Rate Filings Common Policy NB - <example>
    Given test data file "<dataFile>" is loaded
    And the policy jurisdiction is "<stateCode>"
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
      | example | dataFile | stateCode | writingCompany |
      | AL | TestData/al-9.json | AL | ANPAC |
      | AR | TestData/ar-9.json | AR | ANPAC |
      | AZ ANG | TestData/az-ang-6.json | AZ | ANG |
      | AZ ANP | TestData/az-anp-6.json | AZ | ANPAC |
      | CA | TestData/ca-7.json | CA | ANPAC |
      | CO | TestData/co-9.json | CO | ANPAC |
      | CT | TestData/ct-7.json | CT | FFCIC |
      | DE | TestData/de-9.json | DE | ANPAC |
      | GA | TestData/ga-6.json | GA | ANPAC |
      | IA | TestData/ia-9.json | IA | ANPAC |
      | ID | TestData/id-9.json | ID | ANPAC |
      | IL | TestData/il-9.json | IL | ANPAC |
      | IN | TestData/in-9.json | IN | ANPAC |
      | KS | TestData/ks-9.json | KS | ANPAC |
      | KY | TestData/ky-9.json | KY | ANPAC |
      | MD | TestData/md-7.json | MD | ANPAC |
      | ME | TestData/me-9.json | ME | FFCIC |
      | MN | TestData/mn-10.json | MN | ANPAC |
      | MO | TestData/mo-11.json | MO | ANPAC |
      | MS | TestData/ms-9.json | MS | ANPAC |
      | MT | TestData/mt-9.json | MT | ANPAC |
      | ND | TestData/nd-9.json | ND | ANPAC |
      | NE | TestData/ne-10.json | NE | ANPAC |
      | NH | TestData/nh-9.json | NH | FFCIC |
      | NJ | TestData/nj-7.json | NJ | UFFIC |
      | NM | TestData/nm-9.json | NM | ANPAC |
      | NV | TestData/nv-6.json | NV | ANG |
      | NY FFCIC | TestData/ny-ffcic-6.json | NY | FFCIC |
      | NY UFFIC | TestData/ny-uffic-6.json | NY | UFFIC |
      | OH ANG | TestData/oh-ang-6.json | OH | ANG |
      | OH ANP | TestData/oh-anp-6.json | OH | ANPAC |
      | OK ANG | TestData/ok-ang-6.json | OK | ANG |
      | OK ANP | TestData/ok-anp-6.json | OK | ANPAC |
      | OR | TestData/or-9.json | OR | ANPAC |
      | PA | TestData/pa-7.json | PA | ANPAC |
      | RI | TestData/ri-7.json | RI | FFCIC |
      | SC | TestData/sc-9.json | SC | ANPAC |
      | SD ANG | TestData/sd-ang-6.json | SD | ANG |
      | SD ANP | TestData/sd-anp-6.json | SD | ANPAC |
      | TN ANG | TestData/tn-ang-6.json | TN | ANG |
      | TN ANP | TestData/tn-anp-6.json | TN | ANPAC |
      | TX | TestData/tx-9.json | TX | ANCMIC |
      | UT ANG | TestData/ut-ang-6.json | UT | ANG |
      | UT ANP | TestData/ut-anp-6.json | UT | ANPAC |
      | VA | TestData/va-7.json | VA | ANPAC |
      | VT | TestData/vt-7.json | VT | FFCIC |
      | WA | TestData/wa-6.json | WA | ANPAC |
      | WI | TestData/wi-10.json | WI | ANPAC |
      | WV | TestData/wv-7.json | WV | ANPAC |
      | WY | TestData/wy-9.json | WY | ANPAC |
