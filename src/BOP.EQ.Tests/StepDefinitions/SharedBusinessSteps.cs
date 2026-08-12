using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding]
public sealed class SharedBusinessSteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public SharedBusinessSteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [StepDefinition("I add a building")]
    public async Task IAddABuildingAsync()
    {
        var eQBOPAddABuildingButton = new EQBOPAddABuildingButton(_browser.Page, _data);

        await eQBOPAddABuildingButton.ClickAddBuildingBPPAsync();
    
    
    }

    [StepDefinition("I add the underwriting narrative and verify its timestamp")]
    public async Task IAddTheUnderwritingNarrativeAndVerifyItsTimestampAsync()
    {
        var eQCommonNarrative = new EQCommonNarrative(_browser.Page, _data);

        await eQCommonNarrative.WaitForNarrativeScreenHeadingAsync();
        await eQCommonNarrative.ClickAddNarrativeAsync();
        await eQCommonNarrative.ClickEditAsync();
        await eQCommonNarrative.SetDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(_data.Get("EQ Common Narrative.Description of the business exposures, activities and experience", "{{data:Add New Description}}"));
        await eQCommonNarrative.SetDescriptionOfTheBusinessExposuresActivitiesAndExperienceAsync(_data.Get("EQ Common Narrative.Description of the business exposures, activities and experience", "{{data:Edited Description}}"));
        await eQCommonNarrative.ClickSaveAsync();
        await eQCommonNarrative.WaitForUserDateAndTimestampAsync();
        await eQCommonNarrative.VerifyUserDateAndTimestampAsync(_data.Get("EQ Common Narrative.User Date and Timestamp", "Null"));
    
    
    }

    [StepDefinition("I answer the EPLI coverage questions")]
    public async Task IAnswerTheEpliCoverageQuestionsAsync()
    {
        var eQBOPAdditionalCoveragesAnswerEPLIQuestions = new EQBOPAdditionalCoveragesAnswerEPLIQuestions(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.SetHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync(_data.Get("EQ BOP Additional Coverages Answer EPLI Questions.Have there been any EPL claims, suits or complaints or are there any now pending against the insured or any executive, officer or owner?", "No"));
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("Tab");
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("Enter");
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("Tab");
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.SetDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(_data.Get("EQ BOP Additional Coverages Answer EPLI Questions.Does the insured and any executive, officer or owner have any knowledge or information of any act, error or omission which might give rise to an EPL claim, suit or complaint?", "No"));
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.PressDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync("Enter");
        await eQBOPAdditionalCoveragesAnswerEPLIQuestions.PressDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync("Tab");
    
    
    }

    [StepDefinition("I answer the building eligibility questions")]
    public async Task IAnswerTheBuildingEligibilityQuestionsAsync()
    {
        var eQBOPBuildingBuildingEligibilityQuestions = new EQBOPBuildingBuildingEligibilityQuestions(_browser.Page, _data);

        await eQBOPBuildingBuildingEligibilityQuestions.ClickSaveAsync();
    
    
    }

    [StepDefinition("I assign the required client roles")]
    public async Task IAssignTheRequiredClientRolesAsync()
    {
        var eQBOPClientDetailsEditClientRoles = new EQBOPClientDetailsEditClientRoles(_browser.Page, _data);

        await eQBOPClientDetailsEditClientRoles.ClickBusinessOwnerAsync();
        await eQBOPClientDetailsEditClientRoles.ClickNamedInsuredAsync();
        await eQBOPClientDetailsEditClientRoles.ClickThirdPartyDesigneeAsync();
        await eQBOPClientDetailsEditClientRoles.ClickKeyIndividualAsync();
        await eQBOPClientDetailsEditClientRoles.PressAuditContactAsync("Tab");
        await eQBOPClientDetailsEditClientRoles.PressInspectionContactAsync("Tab");
        await eQBOPClientDetailsEditClientRoles.ClickAuditContactAsync();
        await eQBOPClientDetailsEditClientRoles.ClickInspectionContactAsync();
    
    
    }

    [StepDefinition("I calculate and verify the premium")]
    public async Task ICalculateAndVerifyThePremiumAsync()
    {
        var eQBOPPricingInsuranceScoreAndPremium = new EQBOPPricingInsuranceScoreAndPremium(_browser.Page, _data);

        await eQBOPPricingInsuranceScoreAndPremium.VerifyInsuranceScoreRefNumberAsync(_data.Get("EQ BOP Pricing Insurance Score and Premium.Insurance Score Ref Number", "{NULL}"));
        await eQBOPPricingInsuranceScoreAndPremium.StorePremiumAsync("Premium");
    
    
    }

    [StepDefinition("I calculate the building valuation")]
    public async Task ICalculateTheBuildingValuationAsync()
    {
        var eQBOPBuildingCostEstimator = new EQBOPBuildingCostEstimator(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingCostEstimator.PressCommercialButtonAsync("Tab");
        await eQBOPBuildingCostEstimator.PressCommercialButtonAsync("Tab");
        await eQBOPBuildingCostEstimator.SetCommercialButtonAsync(_data.Get("EQ BOP Building Cost Estimator.Commercial Button", "x"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingCostEstimator.PressBVSButtonAsync("Tab");
        await eQBOPBuildingCostEstimator.PressBVSButtonAsync("Tab");
        await eQBOPBuildingCostEstimator.ClickBVSButtonAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingCostEstimator.PressFrameAsync("Tab");
        await eQBOPBuildingCostEstimator.SetFrameAsync(_data.Get("EQ BOP Building Cost Estimator.Frame", "x"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingCostEstimator.PressBVSGroupComboboxAsync("Tab");
        await eQBOPBuildingCostEstimator.ClickBVSGroupComboboxAsync();
        await eQBOPBuildingCostEstimator.ClickBVSGroupAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingCostEstimator.PressBVSResultsComboboxAsync("Tab");
        await eQBOPBuildingCostEstimator.ClickBVSResultsComboboxAsync();
        await eQBOPBuildingCostEstimator.ClickBVSResultAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingCostEstimator.DoubleClickYearBuiltAsync();
        await eQBOPBuildingCostEstimator.PressYearBuiltAsync("Tab");
        await eQBOPBuildingCostEstimator.SetYearBuiltAsync(_data.Get("EQ BOP Building Cost Estimator.Year Built", "{{data:Year Built}}"));
        await eQBOPBuildingCostEstimator.PressYearBuiltAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingCostEstimator.PressRoofTypeMainAsync("Tab");
        await eQBOPBuildingCostEstimator.ClickGetValuationAsync();
        await eQBOPBuildingCostEstimator.ClickGetValuationAsync();
        await eQBOPBuildingCostEstimator.PressGetValuationAsync("Tab");
        await eQBOPBuildingCostEstimator.PressGetValuationAsync("Tab");
        await eQBOPBuildingCostEstimator.ClickRoofTypeMainAsync();
        await eQBOPBuildingCostEstimator.ClickRoofTypeSelectionAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I complete the business postcondition")]
    public async Task ICompleteTheBusinessPostconditionAsync()
    {
        await Task.CompletedTask;
    
    
    }

    [StepDefinition("I complete the proposal start")]
    public async Task ICompleteTheProposalStartAsync()
    {
        var page = new EQCommonProposalStart(_browser.Page, _data);

        await page.WaitForProposalDetailsHeaderAsync();
        await page.SelectProductAsync(_data.Get("LOB", "BOP"));

        // UI steering from the source block, kept in ModuleAttribute order.
        await page.PressSearchBusinessNameAsync("Tab");
        await page.ClickIndividuallyOwnedDBACheckBoxAsync();
        await page.ClickIndividuallyOwnedDBAOrTAAsync();
        await page.SetIndividualDBAAsync(_data.Get("EQ Common Proposal Start.Individual DBA", "Tester Automation"));

        await page.SetEffectiveDateAsync(_data.Get("EQ Common Proposal Start.Effective Date", "{{data:EffDate}}"));
        await page.PressEffectiveDateAsync("Tab");
        await page.StoreEffectiveDateAsync("EffDate");

        await page.SelectRatingStateAsync(_data.Get("StateName", "{{data:StateName}}"));
        await page.SetAgentPCAsync(_data.Get("EQ Common Proposal Start.AgentPC", "{{data:Agent}}"));
        await page.PressAgentPCAsync("Tab");
        await page.PressAgentPCAsync("Tab");

        await page.ClickNewAccountAddressAsync();
        await page.SetLessorsRiskNoAsync(_data.Get("EQ Common Proposal Start.Lessors Risk  - No", "X"));
        await page.SelectPolicyTermAsync(_data.Get("PolicyTerm", "12 months"));
        await page.ClickStartQuoteAsync();
    
    
    }

    [StepDefinition("I complete the regression verification")]
    public async Task ICompleteTheRegressionVerificationAsync()
    {
        var dashboardQuickSearch = new DashboardQuickSearch(_browser.Page, _data);
        var dashboardSearchForPoliciesQuotes = new DashboardSearchForPoliciesQuotes(_browser.Page, _data);
        var transACT = new TransACT(_browser.Page, _data);
        var clientNamedInsuredCommon = new ClientNamedInsuredCommon(_browser.Page, _data);
        var iNSPIREMain = new INSPIREMain(_browser.Page, _data);
        var submissionCompleteApplicationStoplightFunctionality = new SubmissionCompleteApplicationStoplightFunctionality(_browser.Page, _data);
        var queueInCLASQLTY = new QueueInCLASQLTY(_browser.Page, _data);
        var submissionReferApproveCompleteIssuanceBackToAgent = new SubmissionReferApproveCompleteIssuanceBackToAgent(_browser.Page, _data);
        var bOPNavigationLinks = new BOPNavigationLinks(_browser.Page, _data);
        var policyCoverage = new PolicyCoverage(_browser.Page, _data);
        var submissionRequiredAndOptionalFields = new SubmissionRequiredAndOptionalFields(_browser.Page, _data);
        var clientOtherInsuredInfo = new ClientOtherInsuredInfo(_browser.Page, _data);
        var transACTPolicyDetailsAttachments = new TransACTPolicyDetailsAttachments(_browser.Page, _data);
        var transACTTransACTDetailPopup = new TransACTTransACTDetailPopup(_browser.Page, _data);

        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await clientNamedInsuredCommon.WaitForLaunchInspireAsync();
        await clientNamedInsuredCommon.ClickLaunchInspireAsync();
        await iNSPIREMain.WaitForConfirmBusinessOwnersForPolicyAsync();
        await iNSPIREMain.VerifyConfirmBusinessOwnersForPolicyAsync(_data.Get("INSPIRE - Main.Confirm Business Owners for Policy #", "Confirm Business Owners for Policy {{buffer:Policy#}}"));
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await bOPNavigationLinks.ClickPolicyCoverageAsync();
        await policyCoverage.WaitForPolicyCoverageAsync();
        await policyCoverage.SetLiabilityPerOccurenceLimitAsync(_data.Get("Policy Coverage.LiabilityPerOccurenceLimit", "2,000,000"));
        await policyCoverage.PressLiabilityPerOccurenceLimitAsync("Tab");
        await policyCoverage.PressLiabilityPerOccurenceLimitAsync("Tab");
        await policyCoverage.WaitForProductsCompletedAggregateLimitAsync();
        await policyCoverage.WaitForGeneralAggregateLimitAsync();
        await submissionRequiredAndOptionalFields.WaitForSubmissionHeadingAsync();
        await submissionRequiredAndOptionalFields.SetDoesThisChangeRepresentAReductionInCoverageAsync(_data.Get("Submission Required and Optional Fields.Does this change represent a reduction in coverage?*", "No"));
        await submissionRequiredAndOptionalFields.PressDoesThisChangeRepresentAReductionInCoverageAsync("Tab");
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await bOPNavigationLinks.ClickPolicyCoverageAsync();
        await policyCoverage.WaitForPolicyCoverageAsync();
        await policyCoverage.SetLiabilityPerOccurenceLimitAsync(_data.Get("Policy Coverage.LiabilityPerOccurenceLimit", "1,000,000"));
        await policyCoverage.PressLiabilityPerOccurenceLimitAsync("Tab");
        await policyCoverage.PressLiabilityPerOccurenceLimitAsync("Tab");
        await policyCoverage.WaitForProductsCompletedAggregateLimitAsync();
        await policyCoverage.WaitForGeneralAggregateLimitAsync();
        await submissionRequiredAndOptionalFields.WaitForSubmissionHeadingAsync();
        await submissionRequiredAndOptionalFields.SetDoesThisChangeRepresentAReductionInCoverageAsync(_data.Get("Submission Required and Optional Fields.Does this change represent a reduction in coverage?*", "No"));
        await submissionRequiredAndOptionalFields.PressDoesThisChangeRepresentAReductionInCoverageAsync("Tab");
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await clientNamedInsuredCommon.WaitForClientAsync();
        await clientOtherInsuredInfo.SetWebsiteAddressAsync(_data.Get("Client Other Insured Info.Website Address", "HTTPS://WWW.INSUREDSITE.{{randomText:2}}.COM"));
        await clientOtherInsuredInfo.PressWebsiteAddressAsync("Tab");
        await clientOtherInsuredInfo.PressWebsiteAddressAsync("Tab");
        await submissionRequiredAndOptionalFields.WaitForSubmissionHeadingAsync();
        await submissionRequiredAndOptionalFields.SetDoesThisChangeRepresentAReductionInCoverageAsync(_data.Get("Submission Required and Optional Fields.Does this change represent a reduction in coverage?*", "No"));
        await submissionRequiredAndOptionalFields.PressDoesThisChangeRepresentAReductionInCoverageAsync("Tab");
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await clientNamedInsuredCommon.WaitForClientAsync();
        await clientOtherInsuredInfo.SetWebsiteAddressAsync(_data.Get("Client Other Insured Info.Website Address", "HTTPS://WWW.INSUREDSITE.{{randomText:2}}.COM"));
        await clientOtherInsuredInfo.PressWebsiteAddressAsync("Tab");
        await clientOtherInsuredInfo.PressWebsiteAddressAsync("Tab");
        await submissionRequiredAndOptionalFields.WaitForSubmissionHeadingAsync();
        await submissionRequiredAndOptionalFields.SetDoesThisChangeRepresentAReductionInCoverageAsync(_data.Get("Submission Required and Optional Fields.Does this change represent a reduction in coverage?*", "No"));
        await submissionRequiredAndOptionalFields.PressDoesThisChangeRepresentAReductionInCoverageAsync("Tab");
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACTPolicyDetailsAttachments.ClickViewPolicyDetailsAsync();
        await transACT.ClickViewPolicyAsync();
        await transACT.WaitForTransactionTypeAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACTPolicyDetailsAttachments.ClickViewPolicyDetailsAsync();
        await transACT.ClickViewPolicyAsync();
        await transACT.WaitForTransactionTypeAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await bOPNavigationLinks.ClickPolicyCoverageAsync();
        await policyCoverage.WaitForPolicyCoverageAsync();
        await policyCoverage.SetLiabilityPerOccurenceLimitAsync(_data.Get("Policy Coverage.LiabilityPerOccurenceLimit", "2,000,000"));
        await policyCoverage.PressLiabilityPerOccurenceLimitAsync("Tab");
        await policyCoverage.PressLiabilityPerOccurenceLimitAsync("Tab");
        await policyCoverage.WaitForProductsCompletedAggregateLimitAsync();
        await policyCoverage.WaitForGeneralAggregateLimitAsync();
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
        await submissionReferApproveCompleteIssuanceBackToAgent.ClickCompleteIssuanceAsync();
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.ClickQuickFilterListAsync();
        await transACT.SetQuickFilterListAsync(_data.Get("TransACT.QuickFilterList", "Offset Transactions"));
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.ClickQuickFilterListAsync();
        await transACT.SetQuickFilterListAsync(_data.Get("TransACT.QuickFilterList", "All"));
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.PressQuickFilterListAsync("Tab");
        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACTTransACTDetailPopup.WaitForIFRAMEAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACTTransACTDetailPopup.WaitForIFRAMEAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACTTransACTDetailPopup.WaitForIFRAMEAsync();
        await transACT.ClickQuickFilterListAsync();
        await transACT.SetQuickFilterListAsync(_data.Get("TransACT.QuickFilterList", "Offset Transactions"));
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.ClickQuickFilterListAsync();
        await transACT.SetQuickFilterListAsync(_data.Get("TransACT.QuickFilterList", "All"));
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.PressQuickFilterListAsync("Tab");
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
        await transACTTransACTDetailPopup.WaitForIFRAMEAsync();
        await transACT.WaitForTransACTAsync();
        await transACT.SetTransactionTypeAsync(_data.Get("TransACT.Transaction Type", "{{data:Transaction}}"));
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.PressTransactionTypeAsync("Tab");
        await transACT.StoreTransactionTypeAsync("TransactionType");
        await transACT.ClickGoAsync();
    
    
    }

    [StepDefinition("I complete the submission checklist and electronic signature")]
    public async Task ICompleteTheSubmissionChecklistAndElectronicSignatureAsync()
    {
        var eQBOPSubmissionMainPage = new EQBOPSubmissionMainPage(_browser.Page, _data);

        await eQBOPSubmissionMainPage.VerifyNoReferralNeededVerificationAsync(_data.Get("EQ BOP Submission Main Page.No Referral Needed Verification", "False"));
        await eQBOPSubmissionMainPage.ClickLaunchToChecklistButtonAsync();
        await eQBOPSubmissionMainPage.VerifyNoReferralNeededVerificationAsync(_data.Get("EQ BOP Submission Main Page.No Referral Needed Verification", "True"));
        await eQBOPSubmissionMainPage.ClickChecklistButtonSFPAsync();
    
    
    }

    [StepDefinition("I configure the billing account")]
    public async Task IConfigureTheBillingAccountAsync()
    {
        var eQBOPBilling = new EQBOPBilling(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBilling.WaitForBillingInformationHeadingAsync();
        await eQBOPBilling.ClickMortgageeButtonAsync();
        await eQBOPBilling.SetCreateNewBillingAccountAsync(_data.Get("EQ BOP Billing.Create New Billing Account", "x"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBilling.WaitForBillingInformationHeadingAsync();
        await eQBOPBilling.SetOTHERButtonAsync(_data.Get("EQ BOP Billing.OTHER Button", "x"));
        await eQBOPBilling.SetFirstNameAsync(_data.Get("EQ BOP Billing.First Name", "{{data:First Name}}"));
        await eQBOPBilling.PressFirstNameAsync("Tab");
        await eQBOPBilling.SetLastNameAsync(_data.Get("EQ BOP Billing.Last Name", "{{data:Last Name}}"));
        await eQBOPBilling.PressLastNameAsync("Tab");
        await eQBOPBilling.SetBusinessNameAsync(_data.Get("EQ BOP Billing.Business Name", "{{data:Business Name}}"));
        await eQBOPBilling.PressBusinessNameAsync("Tab");
        await eQBOPBilling.SetAddress1Async(_data.Get("EQ BOP Billing.Address1", "{{data:Address1}}"));
        await eQBOPBilling.PressAddress1Async("Tab");
        await eQBOPBilling.SetCityAsync(_data.Get("EQ BOP Billing.City", "{{data:City}}"));
        await eQBOPBilling.PressCityAsync("Tab");
        await eQBOPBilling.PressStateAsync("Tab");
        await eQBOPBilling.SetStateAsync(_data.Get("EQ BOP Billing.State", "{{data:State}}"));
        await eQBOPBilling.SetZipCodeAsync(_data.Get("EQ BOP Billing.Zip Code", "{{data:Zip Code}}"));
        await eQBOPBilling.PressZipCodeAsync("Tab");
        await eQBOPBilling.PressZipCodeAsync("Tab");
        await eQBOPBilling.PressZipCodeAsync("Tab");
    
    
    }

    [StepDefinition("I confirm the general eligibility restrictions")]
    public async Task IConfirmTheGeneralEligibilityRestrictionsAsync()
    {
        var eQCommonPreQualificationGeneralEligibilityRestrictions = new EQCommonPreQualificationGeneralEligibilityRestrictions(_browser.Page, _data);

        await eQCommonPreQualificationGeneralEligibilityRestrictions.VerifyRule92005FelonyRuleAsync(_data.Get("EQ Common PreQualification General Eligibility Restrictions.Rule 9 (2005)- Felony Rule", "False"));
        await eQCommonPreQualificationGeneralEligibilityRestrictions.WaitForUncheckedConvictedOfAnyOtherTypeOfCrimeAsync();
    
    
    }

    [StepDefinition("I create a new client")]
    public async Task ICreateANewClientAsync()
    {
        var eQCommonCreateNewClient = new EQCommonCreateNewClient(_browser.Page, _data);

        await eQCommonCreateNewClient.WaitForCreateNewClient1Async();
        await eQCommonCreateNewClient.ClickCreateNewClient1Async();
        await eQCommonCreateNewClient.ClickNextAsync();
        await eQCommonCreateNewClient.PressNextAsync("Tab");
    
    
    }

    [StepDefinition("I enter account information")]
    public async Task IEnterAccountInformationAsync()
    {
        var eQCommonAccountDetailsAccountInfo = new EQCommonAccountDetailsAccountInfo(_browser.Page, _data);

        await eQCommonAccountDetailsAccountInfo.WaitForOwnerPhoneAsync();
        await eQCommonAccountDetailsAccountInfo.SetOwnerMiddleNameAsync(_data.Get("EQ Common Account Details - Account Info.Owner Middle Name", ""));
        await eQCommonAccountDetailsAccountInfo.PressOwnerMiddleNameAsync("Tab");
        await eQCommonAccountDetailsAccountInfo.SetOwnerPhoneAsync(_data.Get("EQ Common Account Details - Account Info.Owner Phone", "{{randomPhone}}"));
        await eQCommonAccountDetailsAccountInfo.SetOwnerEmailAsync(_data.Get("EQ Common Account Details - Account Info.Owner Email", "{{randomEmail}}"));
        await eQCommonAccountDetailsAccountInfo.SetMarriedAsync(_data.Get("EQ Common Account Details - Account Info.Married", "x"));
        await eQCommonAccountDetailsAccountInfo.PressStreetAddressAsync("Shift+Tab");
        await eQCommonAccountDetailsAccountInfo.SetStreetAddressAsync(_data.Get("EQ Common Account Details - Account Info.Street Address", "{{data:Address 1}}"));
        await eQCommonAccountDetailsAccountInfo.PressStreetAddressAsync("Tab");
        await eQCommonAccountDetailsAccountInfo.SetCityAsync(_data.Get("EQ Common Account Details - Account Info.City", "{{data:City}}"));
        await eQCommonAccountDetailsAccountInfo.PressCityAsync("Tab");
        await eQCommonAccountDetailsAccountInfo.SelectStateAsync(_data.Get("StateName", "{{data:StateName}}"));
        await eQCommonAccountDetailsAccountInfo.SetZipAsync(_data.Get("EQ Common Account Details - Account Info.Zip", "{{data:Zip}}"));
        await eQCommonAccountDetailsAccountInfo.PressZipAsync("Tab");
        await eQCommonAccountDetailsAccountInfo.ClickNextAsync();
        await eQCommonAccountDetailsAccountInfo.SetHaveYouReceivedMailAtThisAddressForAtLeast90DaysYesAsync(_data.Get("EQ Common Account Details - Account Info.Have you received mail at this address for at least 90 days? Yes", "x"));
        await eQCommonAccountDetailsAccountInfo.ClickNextAsync();
        await eQCommonAccountDetailsAccountInfo.SetIsTheAccountAddressAlsoWhereTheClientResidesYesAsync(_data.Get("EQ Common Account Details - Account Info.Is the account address also where the client resides? Yes", "x"));
        await eQCommonAccountDetailsAccountInfo.PressNextAsync("Shift+Tab");
    
    
    }

    [StepDefinition("I enter class-specific supplemental building data")]
    public async Task IEnterClassSpecificSupplementalBuildingDataAsync()
    {
        var eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS = new EQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.WaitForClassCodesAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.WaitForOccupancySQFTHeadingAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.SetOccupancySqFtLimitAsync(_data.Get("EQ BOP Building Class Enter supplemental data for selected Class Code(s).Occupancy Sq Ft Limit", "2500"));
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.PressOccupancySqFtLimitAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.VerifyOccupancySqFootageTotalAsync(_data.Get("EQ BOP Building Class Enter supplemental data for selected Class Code(s).Occupancy Sq Footage Total", "2500"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.WaitForPersonalPropertyLimitCheckBoxAngularAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.SetPersonalPropertyLimitCheckBoxAngularAsync(_data.Get("EQ BOP Building Class Enter supplemental data for selected Class Code(s).Personal Property Limit CheckBox - Angular***", "True"));
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.PressPersonalPropertyLimitCheckBoxAngularAsync("Tab");
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.ClickPersonalPropertyLimitCheckBoxAngularAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.SetPersonalPropertyLimitAsync(_data.Get("EQ BOP Building Class Enter supplemental data for selected Class Code(s).Personal Property Limit", "5000"));
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.PressPersonalPropertyLimitAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.SetGrossSalesReceiptsAsync(_data.Get("EQ BOP Building Class Enter supplemental data for selected Class Code(s).Gross Sales Receipts", "25000"));
        await eQBOPBuildingClassEnterSupplementalDataForSelectedClassCodeS.PressGrossSalesReceiptsAsync("Tab");
    
    
    }

    [StepDefinition("I enter client search information")]
    public async Task IEnterClientSearchInformationAsync()
    {
        var eQCommonClientInfo = new EQCommonClientInfo(_browser.Page, _data);

        await eQCommonClientInfo.WaitForCustomerNameFirstAsync();
        await eQCommonClientInfo.SetCustomerNameFirstAsync(_data.Get("EQ Common Client Info.customer.name.first", "{{buffer:FirstName}}"));
        await eQCommonClientInfo.SetCustomerNameLastAsync(_data.Get("EQ Common Client Info.customer.name.last", "{{buffer:LastName}}"));
        await eQCommonClientInfo.SetCustomerDateOfBirthAsync(_data.Get("EQ Common Client Info.customer.dateOfBirth", "{{data:DOB}}"));
        await eQCommonClientInfo.ClickSearchAsync();
    
    
    }

    [StepDefinition("I enter occupancy square footage")]
    public async Task IEnterOccupancySquareFootageAsync()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPBuildingAddBuildingOwnRentSqFootage = new EQBOPBuildingAddBuildingOwnRentSqFootage(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.ClickInsuredOccupancySqFtAsync();
        await eQBOPBuildingAddBuildingOwnRentSqFootage.ClickInsuredOccupancySqFtAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I enter the building details")]
    public async Task IEnterTheBuildingDetailsAsync()
    {
        var eQBOPBuildingCostEstimator = new EQBOPBuildingCostEstimator(_browser.Page, _data);
        var eQBOPBuildingBuildingDetailsBuildingRatingBasis = new EQBOPBuildingBuildingDetailsBuildingRatingBasis(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm = new EQBOPBuildingBuildingDetailsRoofYearBurglarAlarm(_browser.Page, _data);

        await eQBOPBuildingCostEstimator.PressNumberOfStoriesAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.WaitForBuildingDetailsHeadingAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressActualCashValueAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetActualCashValueAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Actual Cash Value", "X"));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressReplacementCostAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetReplacementCostAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Replacement Cost", "X"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetYearBuiltRenovatedAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Year Built - Renovated", "\"^{a}\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetYearBuiltRenovatedAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Year Built - Renovated", "\"\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetYearBuiltRenovatedAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Year Built - Renovated", "{{data:Year Renovated}}"));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressYearBuiltRenovatedAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressYearBuiltRenovatedAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetWiringYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Wiring Year", "\"^{a}\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetWiringYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Wiring Year", "\"\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetWiringYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Wiring Year", "{{data:Wiring Year}}"));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressWiringYearAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetHeatingYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Heating Year", "\"^{a}\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetHeatingYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Heating Year", "\"\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetHeatingYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Heating Year", "{{data:Heating Year}}"));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressHeatingYearAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetPlumbingYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Plumbing Year", "\"^{a}\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetPlumbingYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Plumbing Year", "\"\""));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.SetPlumbingYearAsync(_data.Get("EQ BOP Building Building Details Building Rating Basis.Plumbing Year", "{{data:Plumbing Year}}"));
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressPlumbingYearAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressPlumbingYearAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressPlumbingYearAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.SetRoofYearAsync(_data.Get("EQ BOP Building Building Details Roof Year & Burglar Alarm.Roof Year", "{{data:Roof Year}}"));
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.PressRoofYearAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.SetSprinklerYesAsync(_data.Get("EQ BOP Building Building Details Roof Year & Burglar Alarm.Sprinkler - Yes", "x"));
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.WaitForSprinklerYesAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.ClickAutomaticCommercialCookingExhaustAndExtinguishingANSULSystemYesAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.ClickMainBreakerAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressMainBreakerAsync("Tab");
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.ClickMainBreakerAsync();
        await eQBOPBuildingBuildingDetailsBuildingRatingBasis.PressMainBreakerAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.ClickWiringTypeOtherAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.PressWiringTypeOtherAsync("Tab");
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.PressElectricalPanelTypeOtherAsync("Tab");
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.ClickElectricalPanelTypeOtherAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.ClickAmperageOfTheMainCircuitBreaker100AmpsOrGreaterAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingBuildingDetailsRoofYearBurglarAlarm.SetIsAnyHeatSourceThermostaticallyControlledYesAsync(_data.Get("EQ BOP Building Building Details Roof Year & Burglar Alarm.Is any heat source thermostatically controlled? - Yes", "x"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I enter the building heating sources")]
    public async Task IEnterTheBuildingHeatingSourcesAsync()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I enter the initial payment")]
    public async Task IEnterTheInitialPaymentAsync()
    {
        var eQBOPBilling = new EQBOPBilling(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQBOPBilling.SetCheckButtonAsync(_data.Get("EQ BOP Billing.Check Button", "X"));
        await eQBOPBilling.PressCheckButtonAsync("Tab");
        await eQBOPBilling.PressCheckButtonAsync("Tab");
        await eQBOPBilling.SetCreditCardButtonAsync(_data.Get("EQ BOP Billing.Credit Card Button", "X"));
        await eQBOPBilling.PressCreditCardButtonAsync("Tab");
        await eQBOPBilling.PressCreditCardButtonAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBilling.SetCheckNumberAsync(_data.Get("EQ BOP Billing.Check Number", "1205"));
        await eQBOPBilling.PressCheckNumberAsync("Enter");
        await eQBOPBilling.PressCheckNumberAsync("Tab");
        await eQBOPBilling.PressCheckNumberAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBilling.ClickInitialPaymentFullBalanceAsync();
    
    
    }

    [StepDefinition("I enter the insured social security number")]
    public async Task IEnterTheInsuredSocialSecurityNumberAsync()
    {
        var eQCommonSSN = new EQCommonSSN(_browser.Page, _data);

        await eQCommonSSN.WaitForTheSSNCouldNotBeFoundPleaseEnterAnSSNAsync();
        await eQCommonSSN.SetSsnAsync(_data.Get("EQ Common SSN.ssn", "025{{randomDigits:6}}"));
        await eQCommonSSN.PressSsnAsync("Tab");
        await eQCommonSSN.WaitForSUBMITAsync();
        await eQCommonSSN.ClickSUBMITAsync();
        await eQCommonSSN.PressSUBMITAsync("Tab");
        await eQCommonSSN.ClickSUBMITAsync();
        await eQCommonSSN.ClickSubmitAngularAsync();
        await eQCommonSSN.PressSubmitAngularAsync("Tab");
        await eQCommonSSN.ClickSubmitAngularAsync();
        await eQCommonSSN.WaitForSubmitAngularAsync();
    
    
    }

    [StepDefinition("I enter the policy location")]
    public async Task IEnterThePolicyLocationAsync()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPLocationsAddEditLocation = new EQBOPLocationsAddEditLocation(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.ClickLabelNicknameForTheLocationAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.SetMilesFromFireDepartmentAsync(_data.Get("EQ BOP Locations Add/Edit Location.Miles From Fire Department", "\"^{a}\"{{data:Miles From Fire Department}}"));
        await eQBOPLocationsAddEditLocation.PressMilesFromFireDepartmentAsync("Tab");
        await eQBOPLocationsAddEditLocation.WaitForSaveAsync();
        await eQBOPLocationsAddEditLocation.ClickOrderWildfireRiskScoreAsync();
        await eQBOPLocationsAddEditLocation.ClickSaveAsync();
        await eQBOPLocationsAddEditLocation.ClickFeetFromFireHydrantAsync();
        await eQBOPLocationsAddEditLocation.SetItem1100Async(_data.Get("EQ BOP Locations Add/Edit Location.1 - 100", "x"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPLocationsAddEditLocation.ClickSaveAsync();
    
    
    }

    [StepDefinition("I enter the prior-claims information")]
    public async Task IEnterThePriorClaimsInformationAsync()
    {
        var eQCommonPriorCarrierClaimsRequiredInfo = new EQCommonPriorCarrierClaimsRequiredInfo(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonPriorCarrierClaimsRequiredInfo.SetPriorPolicyNoAsync(_data.Get("EQ Common Prior Carrier-Claims Required Info.Prior Policy - No", "X"));
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPriorCarrierClaimsRequiredInfo.SetYearsInBusinessAsync(_data.Get("EQ Common Prior Carrier-Claims Required Info.Years In Business", "\"5\""));
        await eQCommonPriorCarrierClaimsRequiredInfo.PressYearsInBusinessAsync("Tab");
        await eQCommonPriorCarrierClaimsRequiredInfo.PressYearsInBusinessAsync("Tab");
        await eQCommonPriorCarrierClaimsRequiredInfo.PressYearsInBusinessAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPriorCarrierClaimsRequiredInfo.SetItem3YearsAsync(_data.Get("EQ Common Prior Carrier-Claims Required Info.3+ years", "X"));
        await eQCommonPriorCarrierClaimsRequiredInfo.PressItem3YearsAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPriorCarrierClaimsRequiredInfo.SetPriorInsuranceLatestExpirationDateAsync(_data.Get("EQ Common Prior Carrier-Claims Required Info.Prior Insurance Latest Expiration Date", "\"1/1/2025\""));
        await eQCommonPriorCarrierClaimsRequiredInfo.PressPriorInsuranceLatestExpirationDateAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPriorCarrierClaimsRequiredInfo.SetPriorInsuranceLatestCarrierAsync(_data.Get("EQ Common Prior Carrier-Claims Required Info.Prior Insurance Latest Carrier", "\"GEICO\""));
        await eQCommonPriorCarrierClaimsRequiredInfo.PressPriorInsuranceLatestCarrierAsync("Tab");
    
    
    }

    [StepDefinition("I enter the required primary-insured information")]
    public async Task IEnterTheRequiredPrimaryInsuredInformationAsync()
    {
        var eQCommonPrimaryInsuredRequired = new EQCommonPrimaryInsuredRequired(_browser.Page, _data);
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQCommonPrimaryInsuredGeneralInfo = new EQCommonPrimaryInsuredGeneralInfo(_browser.Page, _data);
        var eQBOPPrimaryInsuredDetailsGeneralUWQuestions2 = new EQBOPPrimaryInsuredDetailsGeneralUWQuestions2(_browser.Page, _data);

        await eQCommonPrimaryInsuredRequired.PressExistingClientAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressExistingClientAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressExistingClientAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressExistingClientAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressExistingClientAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressExistingClientAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressIndividualSoleProprietorOldAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressIndividualSoleProprietorOldAsync("Tab");
        await eQCommonPrimaryInsuredRequired.ClickIndividualSoleProprietorOldAsync();
        await eQCommonPrimaryInsuredRequired.ClickIndividualSoleProprietorOldAsync();
        await eQCommonPrimaryInsuredRequired.ClickNextSFPAsync();
        await eQCommonPrimaryInsuredRequired.ClickExistingClientAsync();
        await eQCommonPrimaryInsuredRequired.ClickExistingClientAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPrimaryInsuredRequired.ClickEditGeneralInfoAsync();
        await eQCommonPrimaryInsuredRequired.ClickSaveAsync();
        await eQCommonPrimaryInsuredRequired.ClickSaveAsync();
        await eQCommonPrimaryInsuredRequired.SetIndividualSoleProprietorAsync(_data.Get("EQ Common Primary Insured Required.Individual/Sole Proprietor", "x"));
        await eQCommonPrimaryInsuredRequired.SetMobilePhoneNumberAsync(_data.Get("EQ Common Primary Insured Required.Mobile Phone Number", "\"5554447777\""));
        await eQCommonPrimaryInsuredRequired.PressMobilePhoneNumberAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressMobilePhoneNumberAsync("Tab");
        await eQCommonPrimaryInsuredRequired.SetPrimaryPhoneAsync(_data.Get("EQ Common Primary Insured Required.Primary Phone", "\"4445557788\""));
        await eQCommonPrimaryInsuredRequired.PressPrimaryPhoneAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressPrimaryPhoneAsync("Tab");
        await eQCommonPrimaryInsuredRequired.PressSaveAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonPrimaryInsuredGeneralInfo.SetBusinessNameAsync(_data.Get("EQ Common Primary Insured General Info.Business Name", "\"BOP BASIC Test\""));
        await eQCommonPrimaryInsuredGeneralInfo.PressBusinessNameAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.PressBusinessNameAsync("Enter");
        await eQCommonPrimaryInsuredGeneralInfo.PressBusinessNameAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.SetDescriptionOfOperationsAsync(_data.Get("EQ Common Primary Insured General Info.Description Of Operations", "{{data:Description}}"));
        await eQCommonPrimaryInsuredGeneralInfo.PressDescriptionOfOperationsAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.PressDescriptionOfOperationsAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.SetNumberOfFulltimeEmployeesAsync(_data.Get("EQ Common Primary Insured General Info.Number Of Fulltime Employees", "\"3\""));
        await eQCommonPrimaryInsuredGeneralInfo.PressNumberOfFulltimeEmployeesAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.PressNumberOfFulltimeEmployeesAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.VerifyDescriptionOfOperationsAsync(_data.Get("EQ Common Primary Insured General Info.Description Of Operations", "{XB[QuoteDescription]}"));
        await eQCommonPrimaryInsuredGeneralInfo.SetNumberOfPartTimeEmployeesAsync(_data.Get("EQ Common Primary Insured General Info.Number Of PartTime Employees", "\"2\""));
        await eQCommonPrimaryInsuredGeneralInfo.PressNumberOfPartTimeEmployeesAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.PressNumberOfPartTimeEmployeesAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.SetNumberOfSeasonalEmployeesAsync(_data.Get("EQ Common Primary Insured General Info.Number Of Seasonal Employees", "\"1\""));
        await eQCommonPrimaryInsuredGeneralInfo.PressNumberOfSeasonalEmployeesAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.PressNumberOfSeasonalEmployeesAsync("Tab");
        await eQCommonPrimaryInsuredGeneralInfo.SetFarmBureauMemberNoAsync(_data.Get("EQ Common Primary Insured General Info.Farm Bureau Member - No", "X"));
        await eQCommonPrimaryInsuredGeneralInfo.SetDoYouWishToDiscloseRaceAndGenderInfoNoAsync(_data.Get("EQ Common Primary Insured General Info.Do you wish to disclose Race and Gender Info? - No", "X"));
        await eQCommonPrimaryInsuredGeneralInfo.SetIsTheClientAMemberOfAnyProfessionalTradeAssociationNoAsync(_data.Get("EQ Common Primary Insured General Info.Is the client a member of any Professional Trade Association?- No", "X"));
        await eQCommonPrimaryInsuredGeneralInfo.ClickSaveAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPPrimaryInsuredDetailsGeneralUWQuestions2.ClickNoneOfTheAboveCheckBoxAsync();
        await eQBOPPrimaryInsuredDetailsGeneralUWQuestions2.PressNoneOfTheAboveCheckBoxAsync("Tab");
    
    
    }

    [StepDefinition("I navigate to the prequalification screen")]
    public async Task INavigateToThePrequalificationScreenAsync()
    {
        await Task.CompletedTask;
    
    
    }

    [StepDefinition("I open EQ in the browser")]
    public async Task IOpenEqInTheBrowserAsync()
    {
        // Navigation is deliberately here, after scenario data has loaded.
        var url = _data.Get("Url", "{{env:BASE_URL}}");
        if (!Uri.TryCreate(url, UriKind.Absolute, out _))
            throw new InvalidOperationException($"A valid absolute EQ URL is required. Resolved value: '{url}'.");

        await _browser.Page.GotoAsync(url, new()
        {
            WaitUntil = WaitUntilState.DOMContentLoaded
        });
        await _browser.Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
    
    
    }

    [StepDefinition("I remove EPLI coverage when it is not applicable")]
    public async Task IRemoveEpliCoverageWhenItIsNotApplicableAsync()
    {
        var eQBOPAdditionalCoveragesDeleteEPLI = new EQBOPAdditionalCoveragesDeleteEPLI(_browser.Page, _data);

        await eQBOPAdditionalCoveragesDeleteEPLI.VerifyEmploymentRelatedPracticesExclusionAsync(_data.Get("EQ BOP Additional Coverages Delete EPLI.Employment Related Practices Exclusion", "True"));
    
    
    }

    [StepDefinition("I return to the prequalification screen")]
    public async Task IReturnToThePrequalificationScreenAsync()
    {
        await Task.CompletedTask;
    
    
    }

    [StepDefinition("I review the required-information message")]
    public async Task IReviewTheRequiredInformationMessageAsync()
    {
        var eQCommonReviewRequiredPopUp = new EQCommonReviewRequiredPopUp(_browser.Page, _data);

        await eQCommonReviewRequiredPopUp.ClickKeepGoingAsync();
    
    
    }

    [StepDefinition("I select the additional property-risk options")]
    public async Task ISelectTheAdditionalPropertyRiskOptionsAsync()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I select the future payment plan")]
    public async Task ISelectTheFuturePaymentPlanAsync()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPBilling = new EQBOPBilling(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBilling.SetDirectBillButtonAsync(_data.Get("EQ BOP Billing.Direct Bill Button", "x"));
        await eQBOPBilling.PressDirectBillButtonAsync("Tab");
        await eQBOPBilling.SetChoosePaymentDueDateAsync(_data.Get("EQ BOP Billing.Choose payment due date", "{{data:Choose payment due date}}"));
        await eQBOPBilling.PressChoosePaymentDueDateAsync("Tab");
        await eQBOPBilling.SetItem1PaymentButtonAsync(_data.Get("EQ BOP Billing.1 Payment Button", "x"));
        await eQBOPBilling.PressItem1PaymentButtonAsync("Tab");
        await eQBOPBilling.PressItem1PaymentButtonAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I select the required building coverages")]
    public async Task ISelectTheRequiredBuildingCoveragesAsync()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQBOPBuildingAddBuildingBuildingFunctionalHabitational = new EQBOPBuildingAddBuildingBuildingFunctionalHabitational(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.WaitForSelectIfClientOwnsOrRentsTheBuildingAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressFunctionalPersonalPropertyUncheckedAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.ClickFunctionalPersonalPropertyUncheckedAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressBuildingContainsHabitationalOccupanciesUncheckedAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.ClickBuildingContainsHabitationalOccupanciesUncheckedAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.WaitForFunctionalPersonalPropertyCheckedAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.WaitForBuildingContainsHabitationalOccupanciesCheckedAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.ClickWindstormLossMitigationUncheckedAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressWindstormLossMitigationUncheckedAsync("Enter");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.ClickCertificateTypeBronzeRoofAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressCertificateTypeBronzeRoofAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressCertificateTypeGoldFSLAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.ClickCertificateTypeGoldFSLAsync();
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetRoofShapeAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Roof Shape", "Gable"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofShapeAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofShapeAsync("Tab");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofDeckAttachmentAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofDeckAttachmentAsync("Tab");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetRoofDeckAttachmentAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Roof Deck Attachment", "Level A"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetRoofToWallConnectionAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Roof-to-Wall Connection", "Toe Nails"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofToWallConnectionAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofToWallConnectionAsync("Tab");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetDoorStrengthAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Door Strength", "Other"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressDoorStrengthAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressDoorStrengthAsync("Tab");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofCoveringAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressRoofCoveringAsync("Tab");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetRoofCoveringAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Roof Covering", "South Carolina Building Code Equivalent"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetOpeningProtectionAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Opening Protection", "Type 1"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressOpeningProtectionAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressOpeningProtectionAsync("Tab");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.SetSecondaryWaterResistanceAsync(_data.Get("EQ BOP Building Add Building Building, Functional, Habitational.Secondary Water Resistance", "No"));
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressSecondaryWaterResistanceAsync("Enter");
        await eQBOPBuildingAddBuildingBuildingFunctionalHabitational.PressSecondaryWaterResistanceAsync("Tab");
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    
    }

    [StepDefinition("I sign in to EQ")]
    public async Task ISignInToEqAsync()
    {
        var login = new Login(_browser.Page, _data);

        await login.WaitForUsernameAsync();
        await login.SetUsernameAsync(_data.Get("Login.Username", "{{data:Username}}"));
        await login.PressUsernameAsync("Tab");
        await login.SetPasswordAsync(_data.Get("Login.Password", "{{data:Password}}"));
        await login.PressPasswordAsync("Tab");
        await login.ClickSignOnAsync();
    
    
    }

    [StepDefinition("I sign out of the underwriting application")]
    public async Task ISignOutOfTheUnderwritingApplicationAsync()
    {
        var login2 = new Login2(_browser.Page, _data);

        await login2.WaitForUserNameAsync();
    
    
    }

    [StepDefinition("I start a new quote")]
    public async Task IStartANewQuoteAsync()
    {
        var eQCommonStartNewQuote = new EQCommonStartNewQuote(_browser.Page, _data);

        await eQCommonStartNewQuote.WaitForNewQuoteAsync();
        await eQCommonStartNewQuote.ClickNewQuoteAsync();
    
    
    }

    [StepDefinition("I verify the new-business policy packet")]
    public async Task IVerifyTheNewBusinessPolicyPacketAsync()
    {
        var dashboardQuickSearch = new DashboardQuickSearch(_browser.Page, _data);
        var dashboardSearchForPoliciesQuotes = new DashboardSearchForPoliciesQuotes(_browser.Page, _data);
        var transACT = new TransACT(_browser.Page, _data);
        var transACTPolicyDetailsAttachments = new TransACTPolicyDetailsAttachments(_browser.Page, _data);

        await dashboardQuickSearch.SetSearchTextAsync(_data.Get("Dashboard QuickSearch.Search Text", "{{data:Policy Number}}"));
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.PressSearchTextAsync("Tab");
        await dashboardQuickSearch.ClickQuickSearchButtonAsync();
        await dashboardSearchForPoliciesQuotes.WaitForViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.ClickViewPolicyAsync();
        await dashboardSearchForPoliciesQuotes.WaitForItem1ResultsFoundCurrentlyShowing11Async();
        await transACT.WaitForTransACTAsync();
        await transACTPolicyDetailsAttachments.ClickViewPolicyDetailsAsync();
        await transACT.WaitForTransactionTypeAsync();
        await transACT.ClickViewPolicyAsync();
    
    
    }

    [StepDefinition("I verify the premium in the policy administration system")]
    public async Task IVerifyThePremiumInThePolicyAdministrationSystemAsync()
    {
        await Task.CompletedTask;
    
    
    }
}
