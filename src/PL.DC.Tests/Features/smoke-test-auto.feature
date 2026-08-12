@pl-dc
@generated @smoke-test-auto
Feature: Smoke Test Auto

  Scenario Outline: Smoke Test Auto - <example>
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
      | AL | TestData/al-4.json | ALABAMA | American National Property And Casualty Co. |
      | AR | TestData/ar-4.json | ARKANSAS | American National Property And Casualty Co. |
      | AZ ANG | TestData/az-ang.json | ARIZONA | American National General Insurance Co. |
      | AZ ANP | TestData/az-anp.json | ARIZONA | American National Property And Casualty Co. |
      | CA | TestData/ca-2.json | CALIFORNIA | American National Property And Casualty Co. |
      | CO | TestData/co-4.json | COLORADO | American National Property And Casualty Co. |
      | CT | TestData/ct-2.json | CONNECTICUT | Farm Family Casualty Insurance Co. |
      | DE | TestData/de-4.json | DELAWARE | American National Property And Casualty Co. |
      | IA | TestData/ia-4.json | IOWA | American National Property And Casualty Co. |
      | ID | TestData/id-4.json | IDAHO | American National Property And Casualty Co. |
      | IL | TestData/il-4.json | ILLINOIS | American National Property And Casualty Co. |
      | IN | TestData/in-4.json | INDIANA | American National Property And Casualty Co. |
      | KS | TestData/ks-4.json | KANSAS | American National Property And Casualty Co. |
      | KY | TestData/ky-4.json | KENTUCKY | American National Property And Casualty Co. |
      | ME | TestData/me-4.json | MAINE | Farm Family Casualty Insurance Co. |
      | MD | TestData/md-2.json | MARYLAND | American National Property And Casualty Co. |
      | MN | TestData/mn-5.json | MINNESOTA | American National Property And Casualty Co. |
      | MO | TestData/mo-6.json | MISSOURI | American National Property And Casualty Co. |
      | MS | TestData/ms-4.json | MISSISSIPPI | American National Property And Casualty Co. |
      | MT | TestData/mt-4.json | MONTANA | American National Property And Casualty Co. |
      | ND | TestData/nd-4.json | NORTH DAKOTA | American National Property And Casualty Co. |
      | NE | TestData/ne-5.json | NEBRASKA | American National Property And Casualty Co. |
      | NH | TestData/nh-4.json | NEW HAMPSHIRE | Farm Family Casualty Insurance Co. |
      | NJ | TestData/nj-2.json | NEW JERSEY | United Farm Family Insurance Co. |
      | NM | TestData/nm-4.json | NEW MEXICO | American National Property And Casualty Co. |
      | NY FFCIC | TestData/ny-ffcic.json | NEW YORK | Farm Family Casualty Insurance Co. |
      | NY UFFIC | TestData/ny-uffic.json | NEW YORK | United Farm Family Insurance Co. |
      | OH ANG | TestData/oh-ang.json | OHIO | American National General Insurance Co. |
      | OH ANP | TestData/oh-anp.json | OHIO | American National Property And Casualty Co. |
      | OK ANG | TestData/ok-ang.json | OKLAHOMA | American National General Insurance Co. |
      | OK ANP | TestData/ok-anp.json | OKLAHOMA | American National Property And Casualty Co. |
      | OR | TestData/or-4.json | OREGON | American National Property And Casualty Co. |
      | PA | TestData/pa-2.json | PENNSYLVANIA | American National Property And Casualty Co. |
      | RI | TestData/ri-2.json | RHODE ISLAND | Farm Family Casualty Insurance Co. |
      | SC | TestData/sc-4.json | SOUTH CAROLINA | American National Property And Casualty Co. |
      | SD ANG | TestData/sd-ang.json | SOUTH DAKOTA | American National General Insurance Co. |
      | SD ANP | TestData/sd-anp.json | SOUTH DAKOTA | American National Property And Casualty Co. |
      | TN ANG | TestData/tn-ang.json | TENNESSEE | American National General Insurance Co. |
      | TN ANP | TestData/tn-anp.json | TENNESSEE | American National Property And Casualty Co. |
      | TX | TestData/tx-4.json | TEXAS | American National County Mutual Insurance Co. |
      | UT ANG | TestData/ut-ang.json | UTAH | American National General Insurance Co. |
      | UT ANP | TestData/ut-anp.json | UTAH | American National Property And Casualty Co. |
      | VA | TestData/va-2.json | VIRGINIA | American National Property And Casualty Co. |
      | VT | TestData/vt-2.json | VERMONT | Farm Family Casualty Insurance Co. |
      | WI | TestData/wi-5.json | WISCONSIN | American National Property And Casualty Co. |
      | WV | TestData/wv-2.json | WEST VIRGINIA | American National Property And Casualty Co. |
      | WY | TestData/wy-4.json | WYOMING | American National Property And Casualty Co. |
