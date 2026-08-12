@bop-eq
@obsolete @legacy
@generated @obsolete @legacy
Feature: BOP Basic Policy - OBSOLETE


  Scenario: BOP Basic Policy - OBSOLETE
    Given test data file "TestData/zz-old-bop-basic-policy.json" is loaded
    And I general - Log In to DuckCreek
    And I general - start a new quote


    # Precondition

    # New Application - Data Entry Process
    When I enter Individual Client
    And I enter Business Client
    And I client - Complete Underwriting Info from Client Screen-SFP
    And I general - Get Quote ID and Buffer
    And I navigate to the policy information screen
    And I wait for the policy information screen to become ready
    And I enter the policy effective date
    And I select the primary rating state
    And I complete the remaining policy information fields
    And I capture the operation description
    And I start the required desktop process
    And I policy Info - Run Insurance Score
    And I policy Info - Fill Out BOP Specific Fields
    And I policy Info - Race and Gender - Fill Out Fields
    And I policy Info - Race and Gender - Verify Fields do not exist
    And I policy Info - Underwriting Info - Complete from Policy Info Screen
    And I policy Info - Underwriting Info - Verify Button does not exist
    And I policy Coverage - Fill Out Commonly Required Fields
    And I policy Coverage - Answer Question related to Maryland Lead
    And I policy Coverage - Answer Question related to LPG Transport
    And I location - Add a single location
    And I building - Enter Building Info - Building Details
    And I building - Add Class - Add First Class
    And I straightThrough - Building - Add Class - Add Additional Class
    And I building - Other Building Details
    And I complete the building-specific coverages
    And I return to the building screen
    And I wait for the building screen to become ready
    And I location - Return to verify Wind/Hail and Deductible
    And I location - Verify Named Storm Deductible
    And I location - Return to verify Fixed Deductible
    And I company Endorsements - Fill Out Required Fields
    And I company Endorsements - Elevator and Escalator
    And I navigate to billing
    And I complete the required billing information
    And I notePad - Add NotePad Comment
    And I pricing - Fill out Required Fields (Old Tiering)
    And I pricing - Fill out Required Fields (New Tiering)
    And I pricing - Fill out Required Fields (No Tiering)
    And I pricing Screen Sync for Premium
    And I pricing - Verify Premium
    And I underwriting Questions - Fill out BOP General UW Questions
    And I underwriting Questions - Fill out Gen Liab Questions
    And I underwriting Questions - Fill out Property Questions
    And I underwriting Questions - Fill out Contractors Questions
    And I underwriting Questions - Fill out Labor Law Questions
    And I underwriting Questions - Fill out Labor Law - NY
    And I underwriting Questions - confirm the dialog to Navigate Back to Main Menu
    And I submission - Fill out Required Fields
    And I smoke Test - Check Stoplight Functionality
    And I submission - Run Stoplight
    And I submission - Select Policy Forms and Policy Admin Forms
    And I submission - Verify Values in Premium Fields
    And I general - Forms Verification

    # Post Condition
    Then I sign out of the underwriting application
    And I complete the business postcondition
