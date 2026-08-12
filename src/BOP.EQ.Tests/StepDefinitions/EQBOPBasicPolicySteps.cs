using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "EQ BOP Basic Policy")]
public sealed class EQBOPBasicPolicySteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public EQBOPBasicPolicySteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [When("I search for and add the required business class")]
    public async Task ISearchForAndAddTheRequiredBusinessClass_10()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQCommonPreQualificationAddClassCodes = new EQCommonPreQualificationAddClassCodes(_browser.Page, _data);
        var eQCommonPreQualificationAddClassCodesSearchAddClassCodes = new EQCommonPreQualificationAddClassCodesSearchAddClassCodes(_browser.Page, _data);
        var eQCommonPreQualificationIndustryClassCodeRestrictions = new EQCommonPreQualificationIndustryClassCodeRestrictions(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPreQualificationAddClassCodes.WaitForAddClassCodesHeaderAsync();
        await eQCommonPreQualificationAddClassCodes.ClickSearchAddClassCodeAsync();
        await eQCommonPreQualificationAddClassCodes.PressSearchAddClassCodeAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.WaitForFindAClassCodeAsync();
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.SetClassFilterAsync(_data.Get("EQ Common PreQualification Add Class Codes Search/Add Class Codes.Class Filter", "59325"));
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.ClickSearchAsync();
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.SetOnAsync(_data.Get("EQ Common PreQualification Add Class Codes Search/Add Class Codes.on", "True"));
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.PressOnAsync("Tab");
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.WaitForOnAsync();
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.PressYouHaveSelected1ClassCodesAsync("Tab");
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.WaitForYouHaveSelected1ClassCodesAsync();
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.ClickAddAsync();
        await eQCommonPreQualificationAddClassCodesSearchAddClassCodes.ClickYouHaveSelected1ClassCodesAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPreQualificationIndustryClassCodeRestrictions.WaitForIndustryClassCodeRestrictionsAsync();
        await eQCommonPreQualificationIndustryClassCodeRestrictions.ClickCheckBoxOutlineBlankNoneOfTheAboveAsync();
        await eQCommonPreQualificationIndustryClassCodeRestrictions.PressCheckBoxOutlineBlankNoneOfTheAboveAsync("Tab");
        await eQCommonPreQualificationIndustryClassCodeRestrictions.SelectResponseRequiredToContinueAsync(_data.Get("EQ Common PreQualification Industry Class Code Restrictions.Response required to continue", "False"));
        await eQCommonPreQualificationIndustryClassCodeRestrictions.ClickNextPrimaryInsuredDetailsAsync();
        await eQCommonPreQualificationIndustryClassCodeRestrictions.PressNextPrimaryInsuredDetailsAsync("Tab");
    
    }

    [When("I complete the industry class-code restrictions")]
    public async Task ICompleteTheIndustryClassCodeRestrictions_12()
    {
        var eQBOPPrequalificationIndustryClassCodeRestrictions = new EQBOPPrequalificationIndustryClassCodeRestrictions(_browser.Page, _data);

        await eQBOPPrequalificationIndustryClassCodeRestrictions.WaitForIndustryClassCodeRestrictionsHeadingAsync();
        await eQBOPPrequalificationIndustryClassCodeRestrictions.SetNoneOfTheAboveAsync(_data.Get("EQ BOP Prequalification Industry Class Code Restrictions.None of the Above", "True"));
        await eQBOPPrequalificationIndustryClassCodeRestrictions.PressNoneOfTheAboveAsync("Tab");
    
    }

    [When("I navigate to the primary insured details screen")]
    public async Task INavigateToThePrimaryInsuredDetailsScreen_13()
    {
        await Task.CompletedTask;
    
    }

    [When("I answer the primary-insured underwriting questions")]
    public async Task IAnswerThePrimaryInsuredUnderwritingQuestions_15()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPPrimaryInsuredDetailsGeneralUWQuestions = new EQBOPPrimaryInsuredDetailsGeneralUWQuestions(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPrimaryInsuredDetailsGeneralUWQuestions.WaitForGeneralUWQuestionsHeadingAsync();
    
    }

    [When("I answer the industry class-code questions")]
    public async Task IAnswerTheIndustryClassCodeQuestions_16()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions = new EQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions.WaitForIndustryClassCodeQuestionsHeadingAsync();
        await eQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions.SetNoneOfTheAboveCheckboxAsync(_data.Get("EQ BOP Primary Insured Details Industry/Class Code Questions.None of the Above - Checkbox", "True"));
        await eQBOPPrimaryInsuredDetailsIndustryClassCodeQuestions.PressNoneOfTheAboveCheckboxAsync("Tab");
    
    }

    [When("I navigate to the client details screen")]
    public async Task INavigateToTheClientDetailsScreen_17()
    {
        await Task.CompletedTask;
    
    }

    [When("I navigate to the narrative screen")]
    public async Task INavigateToTheNarrativeScreen_19()
    {
        await Task.CompletedTask;
    
    }

    [When("I maintain and verify prior claims")]
    public async Task IMaintainAndVerifyPriorClaims_22()
    {
        var eQBOPClaimsPriorInsuranceAddClaim = new EQBOPClaimsPriorInsuranceAddClaim(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPClaimsPriorInsuranceDeleteClaim = new EQBOPClaimsPriorInsuranceDeleteClaim(_browser.Page, _data);

        await eQBOPClaimsPriorInsuranceAddClaim.WaitForClaimsAddAndUpdateClaimsAsNeededAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.ClickADDCLAIMAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetDateOfOccurrenceAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Date Of Occurrence", "\"^{a}\"{{data:Date of Occurance}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressDateOfOccurrenceAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetPolicyStartAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Policy Start", "\"^{a}\"{{data:Policy Start}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressPolicyStartAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetPolicyExpireAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Policy Expire", "\"^{a}\"{{data:Policy Expire}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressPolicyExpireAsync("Tab");
        await eQBOPClaimsPriorInsuranceAddClaim.PressPolicyExpireAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetAmountPaidAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Amount Paid", "\"^{a}\"{{data:Amount Paid}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressAmountPaidAsync("Enter");
        await eQBOPClaimsPriorInsuranceAddClaim.PressAmountPaidAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetAmountReservedAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Amount Reserved", "\"^{a}\"{{data:Amount Reserved}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressAmountReservedAsync("Enter");
        await eQBOPClaimsPriorInsuranceAddClaim.PressAmountReservedAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetExpenseAmountAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Expense Amount", "\"^{a}\"{{data:Expense Amount}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressExpenseAmountAsync("Enter");
        await eQBOPClaimsPriorInsuranceAddClaim.PressExpenseAmountAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.PressTypeOfLossDropdownAsync("Tab");
        await eQBOPClaimsPriorInsuranceAddClaim.SetTypeOfLossSelectionAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Type of Loss Selection", "X"));
        await eQBOPClaimsPriorInsuranceAddClaim.ClickTypeOfLossDropdownAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPClaimsPriorInsuranceAddClaim.SetDescriptionOfOccurrenceOrClaimAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Description Of Occurrence Or Claim", "{{data:Description Of Occurrence Or Claim}}"));
        await eQBOPClaimsPriorInsuranceAddClaim.PressDescriptionOfOccurrenceOrClaimAsync("Tab");
        await eQBOPClaimsPriorInsuranceAddClaim.PressDescriptionOfOccurrenceOrClaimAsync("Tab");
        await eQBOPClaimsPriorInsuranceAddClaim.PressDescriptionOfOccurrenceOrClaimAsync("Tab");
        await eQBOPClaimsPriorInsuranceAddClaim.SetOpenButtonAsync(_data.Get("EQ BOP Claims/Prior Insurance Add Claim.Open Button", "x"));
        await eQBOPClaimsPriorInsuranceAddClaim.ClickSaveAsync();
        await eQBOPClaimsPriorInsuranceDeleteClaim.ClickDeleteTrashCanAsync();
        await eQBOPClaimsPriorInsuranceDeleteClaim.WaitForConfirmAsync();
        await eQBOPClaimsPriorInsuranceDeleteClaim.ClickDELETEAsync();
    
    }

    [When("I navigate to locations and buildings")]
    public async Task INavigateToLocationsAndBuildings_23()
    {
        await Task.CompletedTask;
    
    }

    [When("I navigate to the add building screen")]
    public async Task INavigateToTheAddBuildingScreen_25()
    {
        await Task.CompletedTask;
    
    }

    [When("I enter building ownership and square footage")]
    public async Task IEnterBuildingOwnershipAndSquareFootage_27()
    {
        var eQBOPBuildingAddBuildingOwnRentSqFootage = new EQBOPBuildingAddBuildingOwnRentSqFootage(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForSelectIfClientOwnsOrRentsTheBuildingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.SetOwnButtonAsync(_data.Get("EQ BOP Building Add Building Own Rent & Sq Footage.Own Button", "x"));
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressOwnButtonAsync("Tab");
        await eQBOPBuildingAddBuildingOwnRentSqFootage.WaitForTotalBuildingSqFootageAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.SetTotalBuildingSqFootageAsync(_data.Get("EQ BOP Building Add Building Own Rent & Sq Footage.Total Building Sq. Footage", "{{data:Total Building Sq Footage}}"));
        await eQBOPBuildingAddBuildingOwnRentSqFootage.PressTotalBuildingSqFootageAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I navigate to policy coverages")]
    public async Task INavigateToPolicyCoverages_37()
    {
        await Task.CompletedTask;
    
    }

    [When("I navigate to additional coverages")]
    public async Task INavigateToAdditionalCoverages_38()
    {
        await Task.CompletedTask;
    
    }

    [When("I answer the designated-work exclusion question")]
    public async Task IAnswerTheDesignatedWorkExclusionQuestion_41()
    {
        var eQBOPPolicyCoveragesDesignatedWorkExclusion = new EQBOPPolicyCoveragesDesignatedWorkExclusion(_browser.Page, _data);

        await eQBOPPolicyCoveragesDesignatedWorkExclusion.SetIsOperationCoveredUnderAnotherPolicyAsync(_data.Get("EQ BOP Policy Coverages Designated Work Exclusion.Is operation covered under another policy?", "{{data:Is operation covered under another policy?}}"));
        await eQBOPPolicyCoveragesDesignatedWorkExclusion.PressIsOperationCoveredUnderAnotherPolicyAsync("Enter");
        await eQBOPPolicyCoveragesDesignatedWorkExclusion.PressIsOperationCoveredUnderAnotherPolicyAsync("Tab");
    
    }

    [When("I enter liquor-liability gross sales and event details")]
    public async Task IEnterLiquorLiabilityGrossSalesAndEventDetails_42()
    {
        var page = new EQBOPAdditionalCoveragesLiquorLiabilty(_browser.Page, _data);
        await page.SetGrossLiquorSalesAsync(_data.Get("Gross Liquor Sales", "45000"));
        await page.PressGrossLiquorSalesAsync("Tab");
        await page.SetNumberOfEventsAsync(_data.Get("Number Of Events", "20"));
        await page.PressNumberOfEventsAsync("Tab");
    
    }

    [When("I select the liquor-liability activity description")]
    public async Task ISelectTheLiquorLiabilityActivityDescription_43()
    {
        var page = new EQBOPAdditionalCoveragesLiquorLiabilty(_browser.Page, _data);
        await page.SetLiquorLiabilityDescriptionOfActivitiesAsync(_data.Get("Liquor Liability Description of Activities", "Wine Tasting"));
        await page.PressLiquorLiabilityDescriptionOfActivitiesAsync("Tab");
    
    }

    [When("I confirm no additional liquor-liability conditions apply")]
    public async Task IConfirmNoAdditionalLiquorLiabilityConditionsApply_44()
    {
        var page = new EQBOPAdditionalCoveragesLiquorLiabilty(_browser.Page, _data);
        await page.SetNoneOfTheAboveAsync(_data.Get("None of the Above", "x"));
    
    }

    [When("I navigate to billing")]
    public async Task INavigateToBilling_45()
    {
        await Task.CompletedTask;
    
    }

    [When("I navigate to pricing")]
    public async Task INavigateToPricing_49()
    {
        await Task.CompletedTask;
    
    }

    [When("I return to billing")]
    public async Task IReturnToBilling_50()
    {
        await Task.CompletedTask;
    
    }

    [When("I return to pricing")]
    public async Task IReturnToPricing_51()
    {
        await Task.CompletedTask;
    
    }

    [When("I verify the applicable risk category")]
    public async Task IVerifyTheApplicableRiskCategory_53()
    {
        var eQBOPPricingCAMARiskCategories = new EQBOPPricingCAMARiskCategories(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPPricingCAMARiskCategories.SetCatastrophePotentialAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Catastrophe Potential", "{{data:Catastrophe Potential}}"));
        await eQBOPPricingCAMARiskCategories.PressCatastrophePotentialAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressCatastrophePotentialAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPricingCAMARiskCategories.SetLossRatioAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Loss Ratio", "{{data:Loss Ratio}}"));
        await eQBOPPricingCAMARiskCategories.PressLossRatioAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressLossRatioAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPricingCAMARiskCategories.SetLengthOfEmploymentAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Length of Employment", "{{data:Length of Employment}}"));
        await eQBOPPricingCAMARiskCategories.PressLengthOfEmploymentAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressLengthOfEmploymentAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPricingCAMARiskCategories.PressMemberOfATradeAssociationAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressMemberOfATradeAssociationAsync("Tab");
        await eQBOPPricingCAMARiskCategories.SetMemberOfATradeAssociationAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Member of a Trade Association", "{{data:Member of a Trade Association}}"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPricingCAMARiskCategories.SetRiskManagementProgramAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Risk Management Program", "{{data:Risk Management Program}}"));
        await eQBOPPricingCAMARiskCategories.PressRiskManagementProgramAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressRiskManagementProgramAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPricingCAMARiskCategories.SetYearsInBusinessAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Years in Business", "{{data:Years in Business}}"));
        await eQBOPPricingCAMARiskCategories.PressYearsInBusinessAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressYearsInBusinessAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPricingCAMARiskCategories.SetUseOfSubcontractorsAsync(_data.Get("EQ BOP Pricing CA & MA Risk Categories.Use of Subcontractors", "{{data:Use of Subcontractors}}"));
        await eQBOPPricingCAMARiskCategories.PressUseOfSubcontractorsAsync("Enter");
        await eQBOPPricingCAMARiskCategories.PressUseOfSubcontractorsAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I navigate to the submission screen")]
    public async Task INavigateToTheSubmissionScreen_54()
    {
        await Task.CompletedTask;
    
    }

    [When("I verify the policy jacket")]
    public async Task IVerifyThePolicyJacket_55()
    {
        var eQCommonSubmissionPolicyFormsMain = new EQCommonSubmissionPolicyFormsMain(_browser.Page, _data);
        var eQCommonFormCheckUIFormsListBOPSmart = new EQCommonFormCheckUIFormsListBOPSmart(_browser.Page, _data);

        await eQCommonSubmissionPolicyFormsMain.ClickPolicyFormsAsync();
        await eQCommonSubmissionPolicyFormsMain.WaitForPolicyFormsHeaderAsync();
        await eQCommonSubmissionPolicyFormsMain.VerifyFormsSearchAsync(_data.Get("EQ Common Submission Policy Forms Main.Forms Search", "True"));
        await eQCommonFormCheckUIFormsListBOPSmart.ClickCloseAsync();
    
    }

    [When("I return to the quote in EQ")]
    public async Task IReturnToTheQuoteInEQ_56()
    {
        var edgePreferencesFile = new EdgePreferencesFile(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var login = new Login(_browser.Page, _data);
        var eQCommonSearchByQuoteNum = new EQCommonSearchByQuoteNum(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await login.WaitForUsernameAsync();
        await login.SetUsernameAsync(_data.Get("Login.Username", "{{data:Username}}"));
        await login.PressUsernameAsync("Tab");
        await login.SetPasswordAsync(_data.Get("Login.Password", "{{data:Password}}"));
        await login.PressPasswordAsync("Tab");
        await login.ClickSignOnAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonSearchByQuoteNum.SetQuoteSearchInputAsync(_data.Get("EQ Common Search by QuoteNum.quoteSearchInput", "{{buffer:Quote_Num}}"));
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.ClickSearchAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I verify the generated forms")]
    public async Task IVerifyTheGeneratedForms_57()
    {
        var edgePreferencesFile = new EdgePreferencesFile(_browser.Page, _data);
        var login2 = new Login2(_browser.Page, _data);
        var dashboardQuickSearch = new DashboardQuickSearch(_browser.Page, _data);
        var dashboardSearchForPoliciesQuotes = new DashboardSearchForPoliciesQuotes(_browser.Page, _data);

        await login2.SetUserNameAsync(_data.Get("Login.UserName", "{{data:UserName}}"));
        await login2.PressUserNameAsync("Tab");
        await login2.SetPasswordAsync(_data.Get("Login.Password", "21489a0b-c163-4a62-b61e-501090c9506aMgAxADQAOAA5AGEAMABiAC0AYwAxADYAMwAtADQAYQA2ADIALQBiADYAMQBlAC0ANQAwADEAMAA5ADAAYwA5ADUAMAA2AGEADwGvwrhTxCVA7Ae9zcvnVw=="));
        await login2.ClickLoginAsync();
        await login2.WaitForLoginAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{buffer:QuoteDescription}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.SetSearchMethodEGDescriptionPolicyAsync(_data.Get("Dashboard Search for Policies / Quotes.Search Method (e.g. Description/Policy#)", "Description"));
        await dashboardSearchForPoliciesQuotes.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        await dashboardSearchForPoliciesQuotes.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.PressSearchButtonAsync("Tab");
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.PressSearchButtonAsync("Tab");
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.PressViewPolicyAsync("Tab");
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
    
    }

    [When("I return to the submission screen")]
    public async Task IReturnToTheSubmissionScreen_58()
    {
        await Task.CompletedTask;
    
    }

    [When("I complete the policy checklist")]
    public async Task ICompleteThePolicyChecklist_60()
    {
        var eQCommonEChecklistEChecklist = new EQCommonEChecklistEChecklist(_browser.Page, _data);
        var eQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklist = new EQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklist(_browser.Page, _data);
        var bOP051 = new BOP051(_browser.Page, _data);
        var bOP061 = new BOP061(_browser.Page, _data);
        var eQCommonEsignatureClickOK = new EQCommonEsignatureClickOK(_browser.Page, _data);

        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.ClickWindstormOrHailPercentageDeductiblesSelectionFormAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto2HeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto2Async();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto4Async();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto3HeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto3Async();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto4HeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto1HeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto1HeaderAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickAttachAsync();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        await eQCommonEChecklistEChecklist.ClickBuildingPhoto1Async();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickBuildingPhoto2Async();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickBuildingPhoto2Async();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickBuildingPhoto2Async();
        await eQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklist.WaitForAcknowledgementLetterX5201Async();
        await eQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklist.ClickAttachAsync();
        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForBuildingPhoto3Async();
        await eQCommonEChecklistEChecklist.WaitForLeadAbatementRemovalStatementHeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        await bOP051.ClickAttachAsync();
        await bOP051.WaitForAcknowledgementLetterX5201Async();
        await bOP061.WaitForBOPRestaurantQuestionnaireHeaderAsync();
        await bOP061.ClickExceptionAsync();
        await bOP061.ClickOKAsync();
        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.WaitForLossRuns3YearsHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickSignaturePageLinkAsync();
        await eQCommonEChecklistEChecklist.WaitForLossRunsHeaderAsync();
        await eQCommonEChecklistEChecklist.WaitForOKAsync();
        await eQCommonEChecklistEChecklist.ClickReviewCompleteAsync();
        await eQCommonEChecklistEChecklist.ClickAcceptAsync();
        await eQCommonEChecklistEChecklist.WaitForAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickExceptionAsync();
        await eQCommonEChecklistEChecklist.ClickOKAcceptAsync();
        await eQCommonEChecklistEChecklist.ClickOKAsync();
        await eQCommonEChecklistEChecklist.ClickSignaturePageBoundCoverageOnlySFPAsync();
        await eQCommonEChecklistEChecklist.ClickAttachAsync();
        await eQCommonEChecklistEChecklist.WaitForOkSubmitAsync();
        await eQCommonEChecklistEChecklist.ClickSubmitAsync();
        await eQCommonEChecklistEChecklist.ClickOkSubmitAsync();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickPolicyHeaderAsync();
        await eQCommonEChecklistEChecklist.ClickDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorerAsync();
        await eQCommonEsignatureClickOK.ClickOkToUpdateFromChecklistAsync();
    
    }

    [When("I refer the quote to underwriting")]
    public async Task IReferTheQuoteToUnderwriting_61()
    {
        var edgePreferencesFile = new EdgePreferencesFile(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var login = new Login(_browser.Page, _data);
        var eQCommonSearchByQuoteNum = new EQCommonSearchByQuoteNum(_browser.Page, _data);
        var eQCommonSubmissionReferToUW = new EQCommonSubmissionReferToUW(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await login.WaitForUsernameAsync();
        await login.SetUsernameAsync(_data.Get("Login.Username", "{{data:Username}}"));
        await login.PressUsernameAsync("Tab");
        await login.SetPasswordAsync(_data.Get("Login.Password", "{{data:Password}}"));
        await login.PressPasswordAsync("Tab");
        await login.ClickSignOnAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonSearchByQuoteNum.SetQuoteSearchInputAsync(_data.Get("EQ Common Search by QuoteNum.quoteSearchInput", "{{buffer:Quote_Num}}"));
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.ClickSearchAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonSubmissionReferToUW.SetUnderwritingRulesAgentCommentsAsync(_data.Get("EQ Common Submission Refer to UW.Underwriting Rules - Agent Comments", "\"Testing for Refer to UW\""));
        await eQCommonSubmissionReferToUW.PressUnderwritingRulesAgentCommentsAsync("Enter");
        await eQCommonSubmissionReferToUW.PressUnderwritingRulesAgentCommentsAsync("Tab");
        await eQCommonSubmissionReferToUW.PressUnderwritingRulesAgentCommentsAsync("Tab");
        await eQCommonSubmissionReferToUW.ClickReferToUWAsync();
    
    }

    [When("I approve the referral as an underwriter")]
    public async Task IApproveTheReferralAsAnUnderwriter_62()
    {
        var edgePreferencesFile = new EdgePreferencesFile(_browser.Page, _data);
        var login2 = new Login2(_browser.Page, _data);
        var dashboardQuickSearch = new DashboardQuickSearch(_browser.Page, _data);
        var dashboardSearchForPoliciesQuotes = new DashboardSearchForPoliciesQuotes(_browser.Page, _data);
        var commonNavigationLinks = new CommonNavigationLinks(_browser.Page, _data);
        var submissionReferApproveCompleteIssuanceBackToAgent = new SubmissionReferApproveCompleteIssuanceBackToAgent(_browser.Page, _data);
        var transACT = new TransACT(_browser.Page, _data);
        var submissionCompleteApplicationStoplightFunctionality = new SubmissionCompleteApplicationStoplightFunctionality(_browser.Page, _data);
        var queueInCLASQLTY = new QueueInCLASQLTY(_browser.Page, _data);
        var transACTPolicyDetailsAttachments = new TransACTPolicyDetailsAttachments(_browser.Page, _data);
        var eQCommonTransactVerifyDCPremium = new EQCommonTransactVerifyDCPremium(_browser.Page, _data);

        await login2.SetUserNameAsync(_data.Get("Login.UserName", "{{data:UserName}}"));
        await login2.PressUserNameAsync("Tab");
        await login2.SetPasswordAsync(_data.Get("Login.Password", "21489a0b-c163-4a62-b61e-501090c9506aMgAxADQAOAA5AGEAMABiAC0AYwAxADYAMwAtADQAYQA2ADIALQBiADYAMQBlAC0ANQAwADEAMAA5ADAAYwA5ADUAMAA2AGEADwGvwrhTxCVA7Ae9zcvnVw=="));
        await login2.ClickLoginAsync();
        await login2.WaitForLoginAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{buffer:QuoteDescription}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.SetSearchMethodEGDescriptionPolicyAsync(_data.Get("Dashboard Search for Policies / Quotes.Search Method (e.g. Description/Policy#)", "Description"));
        await dashboardSearchForPoliciesQuotes.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        await dashboardSearchForPoliciesQuotes.PressSearchMethodEGDescriptionPolicyAsync("Tab");
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.PressSearchButtonAsync("Tab");
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.PressSearchButtonAsync("Tab");
        await dashboardSearchForPoliciesQuotes.ClickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.PressViewPolicyAsync("Tab");
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await commonNavigationLinks.ClickSubmissionAsync();
        await commonNavigationLinks.WaitForSubmissionAsync();
        await submissionReferApproveCompleteIssuanceBackToAgent.WaitForBackToAgentAsync();
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickBackToAgentAsync();
        await transACT.WaitForTransactionTypeAsync();
        await commonNavigationLinks.ClickSubmissionAsync();
        await commonNavigationLinks.WaitForSubmissionAsync();
        await submissionCompleteApplicationStoplightFunctionality.ClickCompleteApplicationAsync();
        await submissionCompleteApplicationStoplightFunctionality.WaitForStoplightWaitingWindowAsync();
        await submissionCompleteApplicationStoplightFunctionality.WaitForAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync();
        await submissionCompleteApplicationStoplightFunctionality.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(_data.Get("Submission Complete Application & Stoplight Functionality.All required fields have not been completed. Please complete highlighted tabs.", "True"));
        await submissionCompleteApplicationStoplightFunctionality.VerifyAllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabsAsync(_data.Get("Submission Complete Application & Stoplight Functionality.All required fields have not been completed. Please complete highlighted tabs.", "False"));
        await queueInCLASQLTY.ClickQueueAsync();
        await queueInCLASQLTY.ClickQueueAsync();
        await queueInCLASQLTY.WaitForClearAllAsync();
        await queueInCLASQLTY.ClickClearAllAsync();
        await queueInCLASQLTY.WaitForClearAllAsync();
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickReferRequestIssuanceAsync();
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickApproveAsync();
        await transACT.WaitForTransactionTypeAsync();
        await commonNavigationLinks.WaitForBillingAsync();
        await transACTPolicyDetailsAttachments.ClickViewPolicyDetailsAsync();
        await eQCommonTransactVerifyDCPremium.StorePolicyNumberAsync("Policy");
    
    }

    [When("I return to the active quote in EQ")]
    public async Task IReturnToTheActiveQuoteInEQ_63()
    {
        var edgePreferencesFile = new EdgePreferencesFile(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var login = new Login(_browser.Page, _data);
        var eQCommonSearchByQuoteNum = new EQCommonSearchByQuoteNum(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await login.WaitForUsernameAsync();
        await login.SetUsernameAsync(_data.Get("Login.Username", "{{data:Username}}"));
        await login.PressUsernameAsync("Tab");
        await login.SetPasswordAsync(_data.Get("Login.Password", "{{data:Password}}"));
        await login.PressPasswordAsync("Tab");
        await login.ClickSignOnAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonSearchByQuoteNum.SetQuoteSearchInputAsync(_data.Get("EQ Common Search by QuoteNum.quoteSearchInput", "{{buffer:Quote_Num}}"));
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.ClickSearchAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I return to the primary insured details screen")]
    public async Task IReturnToThePrimaryInsuredDetailsScreen_64()
    {
        await Task.CompletedTask;
    
    }

    [When("I transmit the policy")]
    public async Task ITransmitThePolicy_65()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPSubmissionTransmitToDC = new EQBOPSubmissionTransmitToDC(_browser.Page, _data);
        var eQCommonTransmitConfirmation = new EQCommonTransmitConfirmation(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPSubmissionTransmitToDC.ClickTransmitAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonTransmitConfirmation.VerifyNEWBUSINESSPACKETAsync(_data.Get("EQ Common Transmit Confirmation.NEW BUSINESS PACKET", "True"));
    
    }
}
