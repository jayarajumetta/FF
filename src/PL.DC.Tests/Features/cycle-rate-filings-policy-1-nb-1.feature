@pl-dc
@generated @cycle-rate-filings-policy-1-nb-1
Feature: Cycle Rate Filings Policy 1 NB_1

  Scenario Outline: Cycle Rate Filings Policy 1 NB_1 - <example>
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
    And I cycle Summary
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
      | AL | TestData/al-11.json | AL | American National Property And Casualty Co. |
      | AR | TestData/ar-11.json | AR | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang-8.json | AZ | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp-8.json | AZ | American National Property And Casualty Co. |
      | CA | TestData/ca-9.json | CA | American National Property And Casualty Co. |
      | CO | TestData/co-11.json | CO | American National Property And Casualty Co. |
      | CT | TestData/ct-9.json | CT | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-11.json | DE | American National Property And Casualty Co. |
      | GA | TestData/ga-8.json | GA | American National Property And Casualty Co. |
      | IA | TestData/ia-11.json | IA | American National Property And Casualty Co. |
      | ID | TestData/id-11.json | ID | American National Property And Casualty Co. |
      | IL | TestData/il-11.json | IL | American National Property And Casualty Co. |
      | IN | TestData/in-11.json | IN | American National Property And Casualty Co. |
      | KS | TestData/ks-11.json | KS | American National Property And Casualty Co. |
      | KY | TestData/ky-11.json | KY | American National Property And Casualty Co. |
      | MD | TestData/md-9.json | MD | American National Property And Casualty Co. |
      | ME | TestData/me-11.json | ME | Farm Family Casualty Insurance Co. |
      | MN | TestData/mn-12.json | MN | American National Property And Casualty Co. |
      | MO | TestData/mo-13.json | MO | American National Property And Casualty Co. |
      | MS | TestData/ms-11.json | MS | American National Property And Casualty Co. |
      | MT | TestData/mt-11.json | MT | American National Property And Casualty Co. |
      | ND | TestData/nd-11.json | ND | American National Property And Casualty Co. |
      | NE | TestData/ne-12.json | NE | American National Property And Casualty Co. |
      | NH | TestData/nh-11.json | NH | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-9.json | NJ | United Farm Family Insurance Co. |
      | NM | TestData/nm-11.json | NM | American National Property And Casualty Co. |
      | NV | TestData/nv-8.json | NV | American National General Insurance Co. |
      | NY FFCIC | TestData/ny-ffcic-8.json | NY | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic-8.json | NY | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang-8.json | OH | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp-8.json | OH | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang-8.json | OK | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp-8.json | OK | American National Property And Casualty Co. |
      | OR | TestData/or-11.json | OR | American National Property And Casualty Co. |
      | PA | TestData/pa-9.json | PA | American National Property And Casualty Co. |
      | RI | TestData/ri-9.json | RI | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-11.json | SC | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang-8.json | SD | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp-8.json | SD | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang-8.json | TN | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp-8.json | TN | American National Property And Casualty Co. |
      | TX | TestData/tx-11.json | TX | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang-8.json | UT | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp-8.json | UT | American National Property And Casualty Co. |
      | VA | TestData/va-9.json | VA | American National Property And Casualty Co. |
      | VT | TestData/vt-9.json | VT | Farm Family Casualty Insurance Co. |
      | WI | TestData/wi-12.json | WI | American National Property And Casualty Co. |
      | WV | TestData/wv-9.json | WV | American National Property And Casualty Co. |
      | WY | TestData/wy-11.json | WY | American National Property And Casualty Co. |
