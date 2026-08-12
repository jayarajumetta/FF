@pl-dc
@generated @smoke-test-rv
Feature: Smoke Test RV

  Scenario Outline: Smoke Test RV - <example>
    Given test data file "<dataFile>" is loaded
    And the policy jurisdiction is "<stateCode>"
    And the writing company is "<writingCompany>"

    # Precondition
    Given I prepare the Home and Auto application
    And I load the required business test data
    And I set TCName

    # Process
    When I select or create the client and enter account details
    And I complete the proposal
    And I complete prequalification

    # Postcondition
    Then I save the generated business test results


    Examples:
      | example | dataFile | stateCode | writingCompany |
      | AL | TestData/al-6.json | ALABAMA | American National Property And Casualty Co. |
      | AR | TestData/ar-6.json | ARKANSAS | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang-3.json | ARIZONA | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp-3.json | ARIZONA | American National Property And Casualty Co. |
      | CA | TestData/ca-4.json | CALIFORNIA | American National Property And Casualty Co. |
      | CO | TestData/co-6.json | COLORADO | American National Property And Casualty Co. |
      | CT | TestData/ct-4.json | CONNECTICUT | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-6.json | DELAWARE | American National Property And Casualty Co. |
      | IA | TestData/ia-6.json | IOWA | American National Property And Casualty Co. |
      | ID | TestData/id-6.json | IDAHO | American National Property And Casualty Co. |
      | IL | TestData/il-6.json | ILLINOIS | American National Property And Casualty Co. |
      | IN | TestData/in-6.json | INDIANA | American National Property And Casualty Co. |
      | KS | TestData/ks-6.json | KANSAS | American National Property And Casualty Co. |
      | KY | TestData/ky-6.json | KENTUCKY | American National Property And Casualty Co. |
      | ME | TestData/me-6.json | MAINE | Farm Family Casualty Insurance Co. |
      | MD | TestData/md-4.json | MARYLAND | American National Property And Casualty Co. |
      | MN | TestData/mn-7.json | MINNESOTA | American National Property And Casualty Co. |
      | MO | TestData/mo-8.json | MISSOURI | American National Property And Casualty Co. |
      | MS | TestData/ms-6.json | MISSISSIPPI | American National Property And Casualty Co. |
      | MT | TestData/mt-6.json | MONTANA | American National Property And Casualty Co. |
      | ND | TestData/nd-6.json | NORTH DAKOTA | American National Property And Casualty Co. |
      | NE | TestData/ne-7.json | NEBRASKA | American National Property And Casualty Co. |
      | NH | TestData/nh-6.json | NEW HAMPSHIRE | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-4.json | NEW JERSEY | United Farm Family Insurance Co. |
      | NM | TestData/nm-6.json | NEW MEXICO | American National Property And Casualty Co. |
      | NY FFCIC | TestData/ny-ffcic-3.json | NEW YORK | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic-3.json | NEW YORK | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang-3.json | OHIO | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp-3.json | OHIO | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang-3.json | OKLAHOMA | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp-3.json | OKLAHOMA | American National Property And Casualty Co. |
      | OR | TestData/or-6.json | OREGON | American National Property And Casualty Co. |
      | PA | TestData/pa-4.json | PENNSYLVANIA | American National Property And Casualty Co. |
      | RI | TestData/ri-4.json | RHODE ISLAND | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-6.json | SOUTH CAROLINA | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang-3.json | SOUTH DAKOTA | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp-3.json | SOUTH DAKOTA | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang-3.json | TENNESSEE | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp-3.json | TENNESSEE | American National Property And Casualty Co. |
      | TX | TestData/tx-6.json | TEXAS | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang-3.json | UTAH | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp-3.json | UTAH | American National Property And Casualty Co. |
      | VA | TestData/va-4.json | VIRGINIA | American National Property And Casualty Co. |
      | VT | TestData/vt-4.json | VERMONT | Farm Family Casualty Insurance Co. |
      | WI | TestData/wi-7.json | WISCONSON | American National Property And Casualty Co. |
      | WV | TestData/wv-4.json | WEST VIRGINIA | American National Property And Casualty Co. |
      | WY | TestData/wy-6.json | WYOMING | American National Property And Casualty Co. |
