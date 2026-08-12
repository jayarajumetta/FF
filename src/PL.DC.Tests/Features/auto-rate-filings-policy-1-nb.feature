@pl-dc
@generated @auto-rate-filings-policy-1-nb
Feature: Auto Rate Filings Policy 1 NB

  Scenario Outline: Auto Rate Filings Policy 1 NB - <example>
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
      | AL | TestData/al-7.json | AL | American National Property And Casualty Co. |
      | AR | TestData/ar-7.json | AR | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang-4.json | AZ | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp-4.json | AZ | American National Property And Casualty Co. |
      | CA | TestData/ca-5.json | CA | American National Property And Casualty Co. |
      | CO | TestData/co-7.json | CO | American National Property And Casualty Co. |
      | CT | TestData/ct-5.json | CT | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-7.json | DE | American National Property And Casualty Co. |
      | GA | TestData/ga-4.json | GA | American National Property And Casualty Co. |
      | IA | TestData/ia-7.json | IA | American National Property And Casualty Co. |
      | ID | TestData/id-7.json | ID | American National Property And Casualty Co. |
      | IL | TestData/il-7.json | IL | American National Property And Casualty Co. |
      | IN | TestData/in-7.json | IN | American National Property And Casualty Co. |
      | KS | TestData/ks-7.json | KS | American National Property And Casualty Co. |
      | KY | TestData/ky-7.json | KY | American National Property And Casualty Co. |
      | MD | TestData/md-5.json | MD | American National Property And Casualty Co. |
      | ME | TestData/me-7.json | ME | Farm Family Casualty Insurance Co. |
      | MN | TestData/mn-8.json | MN | American National Property And Casualty Co. |
      | MO | TestData/mo-9.json | MO | American National Property And Casualty Co. |
      | MS | TestData/ms-7.json | MS | American National Property And Casualty Co. |
      | MT | TestData/mt-7.json | MT | American National Property And Casualty Co. |
      | ND | TestData/nd-7.json | ND | American National Property And Casualty Co. |
      | NE | TestData/ne-8.json | NE | American National Property And Casualty Co. |
      | NH | TestData/nh-7.json | NH | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-5.json | NJ | United Farm Family Insurance Co. |
      | NM | TestData/nm-7.json | NM | American National Property And Casualty Co. |
      | NV | TestData/nv-4.json | NV | American National General Insurance Co. |
      | NY FFCIC | TestData/ny-ffcic-4.json | NY | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic-4.json | NY | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang-4.json | OH | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp-4.json | OH | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang-4.json | OK | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp-4.json | OK | American National Property And Casualty Co. |
      | OR | TestData/or-7.json | OR | American National Property And Casualty Co. |
      | PA | TestData/pa-5.json | PA | American National Property And Casualty Co. |
      | RI | TestData/ri-5.json | RI | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-7.json | SC | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang-4.json | SD | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp-4.json | SD | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang-4.json | TN | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp-4.json | TN | American National Property And Casualty Co. |
      | TX | TestData/tx-7.json | TX | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang-4.json | UT | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp-4.json | UT | American National Property And Casualty Co. |
      | VA | TestData/va-5.json | VA | American National Property And Casualty Co. |
      | VT | TestData/vt-5.json | VT | Farm Family Casualty Insurance Co. |
      | WA | TestData/wa-4.json | WA | American National Property And Casualty Co. |
      | WI | TestData/wi-8.json | WI | American National Property And Casualty Co. |
      | WV | TestData/wv-5.json | WV | American National Property And Casualty Co. |
      | WY | TestData/wy-7.json | WY | American National Property And Casualty Co. |
