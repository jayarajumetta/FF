@bop-eq
@generated @eq-bop-smart-straightthrough-policy
Feature: EQ BOP Smart StraightThrough Policy


  Scenario: EQ BOP Smart StraightThrough Policy
    Given test data file "TestData/eq-bop-smart-straightthrough-policy.json" is loaded
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
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I preQualification - Add Habitational Class - 63011
    And I confirm the general eligibility restrictions
    And I return to the prequalification screen
    And I enter the required primary-insured information
    And I primary Insured Details - Snowplow Questions
    And I enter the prior-claims information
    And I return to the prequalification screen
    And I assign the required client roles
    And I return to the prequalification screen
    And I add the underwriting narrative and verify its timestamp
    And I return to the prequalification screen
    And I enter the policy location
    And I return to the prequalification screen
    And I add a building
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 63011 to - the location - the building
    And I enter class-specific supplemental building data
    And I calculate the building valuation
    And I enter the building details
    And I enter the building heating sources
    And I select the additional property-risk options
    And I answer the building eligibility questions
    And I return to the prequalification screen
    And I add a building
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 74901 to Building - the location - the building
    And I building - Class Codes - Add Class Code 77161 to Building - the location - the building
    And I building - Class Codes - Add Class Code 91581 to Building - the location - the building
    And I building - Class - Enter supplemental data- for Landscape Gardening Shop - the location - the building
    And I building - Class - Enter supplemental data- for Snow and Ice Removal -Residential - the location - the building
    And I building - Answer Extra Questions after Class supplemental Data added- Snow and Ice Removal - the location - the building
    And I building - Answer Extra Questions after Class supplemental Data added - Subcontractors total Building Cost
    And I calculate the building valuation
    And I enter the building details
    And I enter the building heating sources
    And I select the additional property-risk options
    And I answer the building eligibility questions
    And I return to the prequalification screen
    And I add a building
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 64181 to Building - the location - the building
    And I building - Class - Enter supplemental data- for Veterinarians Office - Office - the location - the building
    And I calculate the building valuation
    And I enter the building details
    And I enter the building heating sources
    And I select the additional property-risk options
    And I answer the building eligibility questions
    And I return to the prequalification screen
    And I add a building
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 09661 to Building - the location - the building
    And I building - Class - Enter supplemental data- Casual Dining - Family Style Restaurants - With Sales of Alcoholic Beverages up to 50% of Total Sales - the current building
    And I calculate the building valuation
    And I enter the building details
    And I enter the building heating sources
    And I select the additional property-risk options
    And I answer the building eligibility questions
    And I review the required-information message
    And I locations/Buildings - Add 2nd Location
    And I buildings-Locations - Add a Building to 2nd Location
    And I add a building
    And I return to the prequalification screen
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 63631 to Building - the location - the building
    And I building - Class - Enter supplemental data- Accounting Services - CPAs - Office - the location - the building
    And I calculate the building valuation
    And I enter the building details
    And I enter the building heating sources
    And I select the additional property-risk options
    And I answer the building eligibility questions
    And I buildings-Locations - Add a Building to 2nd Location
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 16402 to Building - the location - the building
    And I building - Class - Enter supplemental data- Pet Grooming - the location - the building
    And I calculate the building valuation
    And I enter the building details
    And I select the additional property-risk options
    And I enter the building heating sources
    And I answer the building eligibility questions
    And I buildings-Locations - Add a Building to 2nd Location
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 59999 to Building - the location - the building
    And I building - Class - Enter supplemental data- for Ceramics - Retail Only - the location - the building
    And I calculate the building valuation
    And I enter the building details
    And I select the additional property-risk options
    And I enter the building heating sources
    And I answer the building eligibility questions
    And I buildings-Locations - Add a Building to 2nd Location
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location - the building
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 74231 to Building - the location - the building
    And I building - Class - Enter supplemental data- for Contractor - Carpentry - Interior - Shop - the location - the building
    And I calculate the building valuation
    And I enter the building details
    And I select the additional property-risk options
    And I enter the building heating sources
    And I answer the building eligibility questions
    And I locations/Buildings - Add 2nd Location
    And I return to the prequalification screen
    And I buildings-Locations - Add a Building to 3rd Location
    And I building - Select Own or rent and Building SQ Footage StraightThrough - the location
    And I select the required building coverages
    And I enter occupancy square footage
    And I building - Class Codes - Add Class Code 59965 to Building - the location - the building
    And I building - Class - Enter supplementaldata - for Winery - Wine MFG.- Retail
    And I calculate the building valuation
    And I enter the building details
    And I select the additional property-risk options
    And I enter the building heating sources
    And I answer the building eligibility questions
    And I return to the prequalification screen
    And I remove EPLI coverage when it is not applicable
    And I additional Coverages - Policy Coverages - Winery Extension
    And I answer the EPLI coverage questions
    And I return to the prequalification screen
    And I configure the billing account
    And I select the future payment plan
    And I enter the initial payment
    And I return to the prequalification screen
    And I return to the prequalification screen
    And I return to the prequalification screen
    And I calculate and verify the premium
    And I return to the prequalification screen
    And I complete the submission checklist and electronic signature
    And I review the first required building photo
    And I review the second required building photo
    And I provide the required loss-run history
    And I eChecklist - Signature Page
    And I esignature - confirm the dialog
    And I submission - Transmit to DC
    And I transmit the policy Confirmation and New Packet Verification in EQ
    And I general - Log In to DuckCreek
    And I dashboard - Perform Quick Search and Open Policy
    And I verify the premium in the policy administration system
    And I verify the new-business policy packet
    And I complete the regression verification

    # Post Condition
    Then I sign out of the underwriting application
    And I complete the business postcondition
