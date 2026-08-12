@bop-eq
@generated @eq-bop-basic-policy
Feature: EQ BOP Basic Policy


  Scenario Outline: EQ BOP Basic Policy - <stateCode>
    Given test data file "<dataFile>" is loaded
    And the policy jurisdiction is "<stateCode>"
    And the policy state is "<stateName>"
    And I open EQ in the browser
    And I sign in to EQ
    And I start a new quote


    # PreCondition

    # Policy Data Entry
    When I enter client search information
    And I create a new client
    And I enter account information
    And I complete the proposal start
    And I enter the insured social security number
    And I navigate to the prequalification screen
    And I search for and add the required business class
    And I confirm the general eligibility restrictions
    And I complete the industry class-code restrictions
    And I navigate to the primary insured details screen
    And I enter the required primary-insured information
    And I answer the primary-insured underwriting questions
    And I answer the industry class-code questions
    And I navigate to the client details screen
    And I assign the required client roles
    And I navigate to the narrative screen
    And I add the underwriting narrative and verify its timestamp
    And I enter the prior-claims information
    And I maintain and verify prior claims
    And I navigate to locations and buildings
    And I enter the policy location
    And I navigate to the add building screen
    And I add a building
    And I enter building ownership and square footage
    And I select the required building coverages
    And I enter occupancy square footage
    And I enter class-specific supplemental building data
    And I calculate the building valuation
    And I enter the building details
    And I enter the building heating sources
    And I select the additional property-risk options
    And I answer the building eligibility questions
    And I review the required-information message
    And I navigate to policy coverages
    And I navigate to additional coverages
    And I remove EPLI coverage when it is not applicable
    And I answer the EPLI coverage questions
    And I answer the designated-work exclusion question
    And I enter liquor-liability gross sales and event details
    And I select the liquor-liability activity description
    And I confirm no additional liquor-liability conditions apply
    And I navigate to billing
    And I configure the billing account
    And I select the future payment plan
    And I enter the initial payment
    And I navigate to pricing
    And I return to billing
    And I return to pricing
    And I calculate and verify the premium
    And I verify the applicable risk category
    And I navigate to the submission screen
    And I verify the policy jacket
    And I return to the quote in EQ
    And I verify the generated forms
    And I return to the quote in EQ
    And I return to the submission screen
    And I complete the submission checklist and electronic signature
    And I complete the policy checklist
    And I refer the quote to underwriting
    And I approve the referral as an underwriter
    And I return to the active quote in EQ
    And I return to the primary insured details screen
    And I transmit the policy
    And I verify the new-business policy packet
    And I verify the premium in the policy administration system
    And I complete the regression verification

    # Post Condition
    Then I sign out of the underwriting application
    And I complete the business postcondition


    Examples:
      | dataFile | stateCode | stateName |
      | TestData/al.json | AL | Alabama |
      | TestData/ar.json | AR | Arkansas |
      | TestData/az.json | AZ | Arizona |
      | TestData/ca.json | CA | California |
      | TestData/co.json | CO | Colorado |
      | TestData/ct.json | CT | Connecticut |
      | TestData/de.json | DE | Delaware |
      | TestData/ga.json | GA | Georgia |
      | TestData/ia.json | IA | Iowa |
      | TestData/id.json | ID | Idaho |
      | TestData/il.json | IL | Illinois |
      | TestData/in.json | IN | Indiana |
      | TestData/ks.json | KS | Kansas |
      | TestData/ky.json | KY | Kentucky |
      | TestData/la.json | LA | Louisiana |
      | TestData/ma.json | MA | Massachusetts |
      | TestData/md.json | MD | Maryland |
      | TestData/me.json | ME | Maine |
      | TestData/mn.json | MN | Minnesota |
      | TestData/mo.json | MO | Missouri |
      | TestData/ms.json | MS | Mississippi |
      | TestData/mt.json | MT | Montana |
      | TestData/nd.json | ND | North Dakota |
      | TestData/ne.json | NE | Nebraska |
      | TestData/nh.json | NH | New Hampshire |
      | TestData/nj.json | NJ | New Jersey |
      | TestData/nm.json | NM | New Mexico |
      | TestData/nv.json | NV | Nevada |
      | TestData/ny.json | NY | New York |
      | TestData/oh.json | OH | Ohio |
      | TestData/ok.json | OK | Oklahoma |
      | TestData/or.json | OR | Oregon |
      | TestData/pa.json | PA | Pennsylvania |
      | TestData/ri.json | RI | Rhode Island |
      | TestData/sc.json | SC | South Carolina |
      | TestData/sd.json | SD | South Dakota |
      | TestData/tn.json | TN | Tennessee |
      | TestData/tx.json | TX | Texas |
      | TestData/ut.json | UT | Utah |
      | TestData/va.json | VA | Virginia |
      | TestData/vt.json | VT | Vermont |
      | TestData/wa.json | WA | Washington |
      | TestData/wi.json | WI | Wisconsin |
      | TestData/wv.json | WV | West Virginia |
      | TestData/wy.json | WY | Wyoming |
