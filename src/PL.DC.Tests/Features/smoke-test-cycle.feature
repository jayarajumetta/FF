@pl-dc
@generated @smoke-test-cycle
Feature: Smoke Test Cycle

  Scenario Outline: Smoke Test Cycle - <example>
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
      | AL | TestData/al-5.json | ALABAMA | American National Property And Casualty Co. |
      | AR | TestData/ar-5.json | ARKANSAS | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang-2.json | ARIZONA | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp-2.json | ARIZONA | American National Property And Casualty Co. |
      | CA | TestData/ca-3.json | CALIFORNIA | American National Property And Casualty Co. |
      | CO | TestData/co-5.json | COLORADO | American National Property And Casualty Co. |
      | CT | TestData/ct-3.json | CONNECTICUT | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-5.json | DELAWARE | American National Property And Casualty Co. |
      | IA | TestData/ia-5.json | IOWA | American National Property And Casualty Co. |
      | ID | TestData/id-5.json | IDAHO | American National Property And Casualty Co. |
      | IL | TestData/il-5.json | ILLINOIS | American National Property And Casualty Co. |
      | IN | TestData/in-5.json | INDIANA | American National Property And Casualty Co. |
      | KS | TestData/ks-5.json | KANSAS | American National Property And Casualty Co. |
      | KY | TestData/ky-5.json | KENTUCKY | American National Property And Casualty Co. |
      | ME | TestData/me-5.json | MAINE | Farm Family Casualty Insurance Co. |
      | MD | TestData/md-3.json | MARYLAND | American National Property And Casualty Co. |
      | MN | TestData/mn-6.json | MINNESOTA | American National Property And Casualty Co. |
      | MO | TestData/mo-7.json | MISSOURI | American National Property And Casualty Co. |
      | MS | TestData/ms-5.json | MISSISSIPPI | American National Property And Casualty Co. |
      | MT | TestData/mt-5.json | MONTANA | American National Property And Casualty Co. |
      | ND | TestData/nd-5.json | NORTH DAKOTA | American National Property And Casualty Co. |
      | NE | TestData/ne-6.json | NEBRASKA | American National Property And Casualty Co. |
      | NH | TestData/nh-5.json | NEW HAMPSHIRE | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-3.json | NEW JERSEY | United Farm Family Insurance Co. |
      | NM | TestData/nm-5.json | NEW MEXICO | American National Property And Casualty Co. |
      | NY FFCIC | TestData/ny-ffcic-2.json | NEW YORK | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic-2.json | NEW YORK | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang-2.json | OHIO | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp-2.json | OHIO | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang-2.json | OKLAHOMA | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp-2.json | OKLAHOMA | American National Property And Casualty Co. |
      | OR | TestData/or-5.json | OREGON | American National Property And Casualty Co. |
      | PA | TestData/pa-3.json | PENNSYLVANIA | American National Property And Casualty Co. |
      | RI | TestData/ri-3.json | RHODE ISLAND | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-5.json | SOUTH CAROLINA | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang-2.json | SOUTH DAKOTA | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp-2.json | SOUTH DAKOTA | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang-2.json | TENNESSEE | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp-2.json | TENNESSEE | American National Property And Casualty Co. |
      | TX | TestData/tx-5.json | TEXAS | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang-2.json | UTAH | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp-2.json | UTAH | American National Property And Casualty Co. |
      | VA | TestData/va-3.json | VIRGINIA | American National Property And Casualty Co. |
      | VT | TestData/vt-3.json | VERMONT | Farm Family Casualty Insurance Co. |
      | WI | TestData/wi-6.json | WISCONSON | American National Property And Casualty Co. |
      | WV | TestData/wv-3.json | WEST VIRGINIA | American National Property And Casualty Co. |
      | WY | TestData/wy-5.json | WYOMING | American National Property And Casualty Co. |
