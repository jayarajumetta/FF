using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class PolicyWorkflowPage
{
    private readonly BrowserSession _browser;
    private readonly PolicyWorkflowLocators _locators;
    private readonly UiActions _ui;

    public PolicyWorkflowPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new PolicyWorkflowLocators(browser.Page);
        _ui = ui;
    }

    public Task VerifyAJAXErrorCheckAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.AJAXErrorCheck, expected, property, new ControlIntent("PolicyWorkflow", "AJAXErrorCheck"));

    public Task WaitForAccountsReceivableHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "AccountsReceivableHeading"));

    public Task WaitForAddClientAsync(string expected) =>
        _ui.WaitAsync(_locators.AddClient, expected, new ControlIntent("PolicyWorkflow", "AddClient"));

    public Task PressAddClientAsync(string key) =>
        _ui.PressAsync(_locators.AddClient, key, new ControlIntent("PolicyWorkflow", "AddClient"));

    public Task ClickAddClientAsync() =>
        _ui.ClickAsync(_locators.AddClient, new ControlIntent("PolicyWorkflow", "AddClient"));

    public Task EnterAggregateLimitAsync(string value) =>
        _ui.FillAsync(_locators.AggregateLimit, value, new ControlIntent("PolicyWorkflow", "AggregateLimit"));

    public Task PressAggregateLimitAsync(string key) =>
        _ui.PressAsync(_locators.AggregateLimit, key, new ControlIntent("PolicyWorkflow", "AggregateLimit"));

    public Task WaitForBusinessownersAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "Businessowners"));

    public Task ClickCPDetailAsync() =>
        _ui.ClickAsync(_locators.Detail, new ControlIntent("PolicyWorkflow", "CPDetail"));

    public Task WaitForCPPLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "CPPLiability"));

    public Task VerifyCTStraightThroughLiabilityLimitTo1MAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CTStraightThroughLiabilityLimitTo1M, expected, property, new ControlIntent("PolicyWorkflow", "CTStraightThroughLiabilityLimitTo1M"));

    public Task WaitForCommercialAutoAsync(string expected) =>
        _ui.WaitAsync(_locators.CommercialAuto, expected, new ControlIntent("PolicyWorkflow", "CommercialAuto"));

    public Task EnterDedTypeAsync(string value) =>
        _ui.FillAsync(_locators.DedType, value, new ControlIntent("PolicyWorkflow", "DedType"));

    public Task PressDedTypeAsync(string key) =>
        _ui.PressAsync(_locators.DedType, key, new ControlIntent("PolicyWorkflow", "DedType"));

    public Task EnterDeductibleBasisAsync(string value) =>
        _ui.FillAsync(_locators.DeductibleBasis, value, new ControlIntent("PolicyWorkflow", "DeductibleBasis"));

    public Task PressDeductibleBasisAsync(string key) =>
        _ui.PressAsync(_locators.DeductibleBasis, key, new ControlIntent("PolicyWorkflow", "DeductibleBasis"));

    public Task WaitForDescriptionOfSpecifiedOperationAsync(string expected) =>
        _ui.WaitAsync(_locators.DescriptionOfSpecifiedOperation, expected, new ControlIntent("PolicyWorkflow", "DescriptionOfSpecifiedOperation"));

    public Task VerifyDescriptionOfSpecifiedOperationAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.DescriptionOfSpecifiedOperation, expected, property, new ControlIntent("PolicyWorkflow", "DescriptionOfSpecifiedOperation"));

    public Task EnterDescriptionOfSpecifiedOperationAsync(string value) =>
        _ui.FillAsync(_locators.DescriptionOfSpecifiedOperation, value, new ControlIntent("PolicyWorkflow", "DescriptionOfSpecifiedOperation"));

    public Task PressDescriptionOfSpecifiedOperationAsync(string key) =>
        _ui.PressAsync(_locators.DescriptionOfSpecifiedOperation, key, new ControlIntent("PolicyWorkflow", "DescriptionOfSpecifiedOperation"));

    public Task EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(string value) =>
        _ui.FillAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, value, new ControlIntent("PolicyWorkflow", "DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup"));

    public Task PressDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupAsync(string key) =>
        _ui.PressAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, key, new ControlIntent("PolicyWorkflow", "DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup"));

    public Task WaitForEmployersLiabAsync(string expected) =>
        _ui.WaitAsync(_locators.EmployersLiab, expected, new ControlIntent("PolicyWorkflow", "EmployersLiab"));

    public Task WaitForEndorsementHeadingAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "EndorsementHeading"));

    public Task EnterFireDamageAsync(string value) =>
        _ui.FillAsync(_locators.FireDamage, value, new ControlIntent("PolicyWorkflow", "FireDamage"));

    public Task WaitForGeneralLiabAsync(string expected) =>
        _ui.WaitAsync(_locators.GeneralLiab, expected, new ControlIntent("PolicyWorkflow", "GeneralLiab"));

    public Task EnterHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync(string value) =>
        _ui.FillAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, value, new ControlIntent("PolicyWorkflow", "HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage"));

    public Task PressHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageAsync(string key) =>
        _ui.PressAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, key, new ControlIntent("PolicyWorkflow", "HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage"));

    public Task WaitForHomeownerSLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "HomeownerSLiability"));

    public Task WaitForOKAsync(string expected) =>
        _ui.WaitAsync(_locators.OK, expected, new ControlIntent("PolicyWorkflow", "OK"));

    public Task ClickOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("PolicyWorkflow", "OK"));

    public Task EnterIFRAMEDuckCreekPolicyDescriptionOfOtherAsync(string value) =>
        _ui.FillAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfOther, value, new ControlIntent("PolicyWorkflow", "IFRAMEDuckCreekPolicyDescriptionOfOther"));

    public Task ClickIFRAMEDuckCreekPolicyOtherCheckBoxAsync() =>
        _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyOtherCheckBox, new ControlIntent("PolicyWorkflow", "IFRAMEDuckCreekPolicyOtherCheckBox"));

    public Task ClickIMDetailAsync() =>
        _ui.ClickAsync(_locators.Detail, new ControlIntent("PolicyWorkflow", "IMDetail"));

    public Task ClickIncludeBusinessownersAsync() =>
        _ui.ClickAsync(_locators.IncludeBusinessowners, new ControlIntent("PolicyWorkflow", "IncludeBusinessowners"));

    public Task ClickIncludeCommercialAutoAsync() =>
        _ui.ClickAsync(_locators.IncludeCommercialAuto, new ControlIntent("PolicyWorkflow", "IncludeCommercialAuto"));

    public Task ClickIncludeCommercialPackagePolicyLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeCommercialPackagePolicyLiability, new ControlIntent("PolicyWorkflow", "IncludeCommercialPackagePolicyLiability"));

    public Task ClickIncludeEmployersLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeEmployersLiability, new ControlIntent("PolicyWorkflow", "IncludeEmployersLiability"));

    public Task ClickIncludeGeneralLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeGeneralLiability, new ControlIntent("PolicyWorkflow", "IncludeGeneralLiability"));

    public Task ClickIncludeHomeownerSLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeHomeownerSLiability, new ControlIntent("PolicyWorkflow", "IncludeHomeownerSLiability"));

    public Task ClickIncludePersonalAutoLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludePersonalAutoLiability, new ControlIntent("PolicyWorkflow", "IncludePersonalAutoLiability"));

    public Task ClickIncludeRentalOwnerSLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeRentalOwnerSLiability, new ControlIntent("PolicyWorkflow", "IncludeRentalOwnerSLiability"));

    public Task ClickIncludeSFP10LiabilityFarmAsync() =>
        _ui.ClickAsync(_locators.IncludeSFP10LiabilityFarm, new ControlIntent("PolicyWorkflow", "IncludeSFP10LiabilityFarm"));

    public Task ClickIncludeWatercraftLiabilityAsync() =>
        _ui.ClickAsync(_locators.IncludeWatercraftLiability, new ControlIntent("PolicyWorkflow", "IncludeWatercraftLiability"));

    public Task VerifyIndividualTypeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IndividualType, expected, property, new ControlIntent("PolicyWorkflow", "IndividualType"));

    public Task EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string value) =>
        _ui.FillAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, value, new ControlIntent("PolicyWorkflow", "IsTheInsuredEngagedInAnySnowOrIceRemovalOperations"));

    public Task PressIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsAsync(string key) =>
        _ui.PressAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, key, new ControlIntent("PolicyWorkflow", "IsTheInsuredEngagedInAnySnowOrIceRemovalOperations"));

    public Task VerifyLoadingMessageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.LoadingMessage, expected, property, new ControlIntent("PolicyWorkflow", "LoadingMessage"));

    public Task ClickLoggedInUserAsync() =>
        _ui.ClickAsync(_locators.LoggedInUser, new ControlIntent("PolicyWorkflow", "LoggedInUser"));

    public Task ClickLogoutAsync() =>
        _ui.ClickAsync(_locators.Logout, new ControlIntent("PolicyWorkflow", "Logout"));

    public Task EnterMedicalAsync(string value) =>
        _ui.FillAsync(_locators.Medical, value, new ControlIntent("PolicyWorkflow", "Medical"));

    public Task PressOKAsync(string key) =>
        _ui.PressAsync(_locators.OK, key, new ControlIntent("PolicyWorkflow", "OK"));

    public Task EnterOccurenceLimitAsync(string value) =>
        _ui.FillAsync(_locators.OccurenceLimit, value, new ControlIntent("PolicyWorkflow", "OccurenceLimit"));

    public Task PressOccurenceLimitAsync(string key) =>
        _ui.PressAsync(_locators.OccurenceLimit, key, new ControlIntent("PolicyWorkflow", "OccurenceLimit"));

    public Task EnterOfFullTimeEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfFullTimeEmployees, value, new ControlIntent("PolicyWorkflow", "OfFullTimeEmployees"));

    public Task PressOfFullTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfFullTimeEmployees, key, new ControlIntent("PolicyWorkflow", "OfFullTimeEmployees"));

    public Task EnterOfPartTimeEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfPartTimeEmployees, value, new ControlIntent("PolicyWorkflow", "OfPartTimeEmployees"));

    public Task PressOfPartTimeEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfPartTimeEmployees, key, new ControlIntent("PolicyWorkflow", "OfPartTimeEmployees"));

    public Task EnterOfSeasonalTemporaryEmployeesAsync(string value) =>
        _ui.FillAsync(_locators.OfSeasonalTemporaryEmployees, value, new ControlIntent("PolicyWorkflow", "OfSeasonalTemporaryEmployees"));

    public Task PressOfSeasonalTemporaryEmployeesAsync(string key) =>
        _ui.PressAsync(_locators.OfSeasonalTemporaryEmployees, key, new ControlIntent("PolicyWorkflow", "OfSeasonalTemporaryEmployees"));

    public Task EnterPersAdvInjAsync(string value) =>
        _ui.FillAsync(_locators.PersAdvInj, value, new ControlIntent("PolicyWorkflow", "PersAdvInj"));

    public Task WaitForPersonalAutoAsync(string expected) =>
        _ui.WaitAsync(_locators.PersonalAuto, expected, new ControlIntent("PolicyWorkflow", "PersonalAuto"));

    public Task WaitForPolicyCovgGLPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "PolicyCovgGLPolicyCovg"));

    public Task WaitForPolicyCovgAsync(string expected) =>
        _ui.WaitAsync(_locators.PolicyCovg, expected, new ControlIntent("PolicyWorkflow", "PolicyCovg"));

    public Task WaitForPolicyInfoHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "PolicyInfoHeader"));

    public Task EnterPremOpDedAsync(string value) =>
        _ui.FillAsync(_locators.PremOpDed, value, new ControlIntent("PolicyWorkflow", "PremOpDed"));

    public Task PressPremOpDedAsync(string key) =>
        _ui.PressAsync(_locators.PremOpDed, key, new ControlIntent("PolicyWorkflow", "PremOpDed"));

    public Task EnterPremOpPDDedAsync(string value) =>
        _ui.FillAsync(_locators.PremOpPDDed, value, new ControlIntent("PolicyWorkflow", "PremOpPDDed"));

    public Task EnterProdBIDedAsync(string value) =>
        _ui.FillAsync(_locators.ProdBIDed, value, new ControlIntent("PolicyWorkflow", "ProdBIDed"));

    public Task PressProdBIDedAsync(string key) =>
        _ui.PressAsync(_locators.ProdBIDed, key, new ControlIntent("PolicyWorkflow", "ProdBIDed"));

    public Task EnterProdPDDedAsync(string value) =>
        _ui.FillAsync(_locators.ProdPDDed, value, new ControlIntent("PolicyWorkflow", "ProdPDDed"));

    public Task EnterProductsAggLimitAsync(string value) =>
        _ui.FillAsync(_locators.ProductsAggLimit, value, new ControlIntent("PolicyWorkflow", "ProductsAggLimit"));

    public Task VerifyPropertyOfOthersRatingGroupAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.PropertyOfOthersRatingGroup, expected, property, new ControlIntent("PolicyWorkflow", "PropertyOfOthersRatingGroup"));

    public Task EnterPropertyOfOthersRatingGroupAsync(string value) =>
        _ui.FillAsync(_locators.PropertyOfOthersRatingGroup, value, new ControlIntent("PolicyWorkflow", "PropertyOfOthersRatingGroup"));

    public Task PressPropertyOfOthersRatingGroupAsync(string key) =>
        _ui.PressAsync(_locators.PropertyOfOthersRatingGroup, key, new ControlIntent("PolicyWorkflow", "PropertyOfOthersRatingGroup"));

    public Task ClickQuickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.QuickSearchButton, new ControlIntent("PolicyWorkflow", "QuickSearchButton"));

    public Task WaitForRentalOwnersLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "RentalOwnersLiability"));

    public Task VerifyOKAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.OK, expected, property, new ControlIntent("PolicyWorkflow", "OK"));

    public Task WaitForReturnToAdminAsync(string expected) =>
        _ui.WaitAsync(_locators.ReturnToAdmin, expected, new ControlIntent("PolicyWorkflow", "ReturnToAdmin"));

    public Task VerifyReturnToAdminAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ReturnToAdmin, expected, property, new ControlIntent("PolicyWorkflow", "ReturnToAdmin"));

    public Task ClickReturnToAdminAsync() =>
        _ui.ClickAsync(_locators.ReturnToAdmin, new ControlIntent("PolicyWorkflow", "ReturnToAdmin"));

    public Task ClickReturnToCPPAsync() =>
        _ui.ClickAsync(_locators.ReturnToCPP, new ControlIntent("PolicyWorkflow", "ReturnToCPP"));

    public Task ClickRiskAccountsReceivableOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableOK"));

    public Task ClickRiskBaileesCustomersOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersOK"));

    public Task ClickRiskComputerSystemsOKAsync() =>
        _ui.ClickAsync(_locators.OK, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsOK"));

    public Task WaitForSFP10LiabilityFarmAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "SFP10LiabilityFarm"));

    public Task VerifySaveForLaterAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.SaveForLater, expected, property, new ControlIntent("PolicyWorkflow", "SaveForLater"));

    public Task ClickSaveForLaterAsync() =>
        _ui.ClickAsync(_locators.SaveForLater, new ControlIntent("PolicyWorkflow", "SaveForLater"));

    public Task WaitForSaveForLaterOKAsync(string expected) =>
        _ui.WaitAsync(_locators.SaveForLaterOK, expected, new ControlIntent("PolicyWorkflow", "SaveForLaterOK"));

    public Task ClickSaveForLaterOKAsync() =>
        _ui.ClickAsync(_locators.SaveForLaterOK, new ControlIntent("PolicyWorkflow", "SaveForLaterOK"));

    public Task ClickSearchButtonAsync() =>
        _ui.ClickAsync(_locators.SearchButton, new ControlIntent("PolicyWorkflow", "SearchButton"));

    public Task EnterSearchMethodEGDescriptionPolicyAsync(string value) =>
        _ui.FillAsync(_locators.SearchMethodEGDescriptionPolicy, value, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task PressSearchMethodEGDescriptionPolicyAsync(string key) =>
        _ui.PressAsync(_locators.SearchMethodEGDescriptionPolicy, key, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"));

    public Task VerifyRiskComputerSystemsSearchResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.RiskComputerSystemsSearchResult, expected, property, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchResult"));

    public Task EnterRiskComputerSystemsSearchResultAsync(string value) =>
        _ui.FillAsync(_locators.RiskComputerSystemsSearchResult, value, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchResult"));

    public Task PressRiskComputerSystemsSearchResultAsync(string key) =>
        _ui.PressAsync(_locators.RiskComputerSystemsSearchResult, key, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchResult"));

    public Task VerifyRiskBaileesCustomersSearchResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.RiskBaileesCustomersSearchResult, expected, property, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchResult"));

    public Task EnterRiskBaileesCustomersSearchResultAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersSearchResult, value, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchResult"));

    public Task PressRiskBaileesCustomersSearchResultAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersSearchResult, key, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchResult"));

    public Task VerifyRiskAccountsReceivableSearchResultAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.RiskAccountsReceivableSearchResult, expected, property, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchResult"));

    public Task EnterRiskAccountsReceivableSearchResultAsync(string value) =>
        _ui.FillAsync(_locators.RiskAccountsReceivableSearchResult, value, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchResult"));

    public Task PressRiskAccountsReceivableSearchResultAsync(string key) =>
        _ui.PressAsync(_locators.RiskAccountsReceivableSearchResult, key, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchResult"));

    public Task EnterSearchTextAsync(string value) =>
        _ui.FillAsync(_locators.SearchText, value, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task PressSearchTextAsync(string key) =>
        _ui.PressAsync(_locators.SearchText, key, new ControlIntent("PolicyWorkflow", "SearchText"));

    public Task EnterRiskAccountsReceivableSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.RiskAccountsReceivableSearchValue, value, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchValue"));

    public Task PressRiskAccountsReceivableSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.RiskAccountsReceivableSearchValue, key, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchValue"));

    public Task EnterRiskComputerSystemsSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.RiskComputerSystemsSearchValue, value, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchValue"));

    public Task PressRiskComputerSystemsSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.RiskComputerSystemsSearchValue, key, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchValue"));

    public Task EnterRiskBaileesCustomersSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.RiskBaileesCustomersSearchValue, value, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchValue"));

    public Task PressRiskBaileesCustomersSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.RiskBaileesCustomersSearchValue, key, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchValue"));

    public Task VerifyShowMeAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ShowMe, expected, property, new ControlIntent("PolicyWorkflow", "ShowMe"));

    public Task ClickShowMeAsync() =>
        _ui.ClickAsync(_locators.ShowMe, new ControlIntent("PolicyWorkflow", "ShowMe"));

    public Task SetSplitBIDedAsync(string value) =>
        _ui.SmartSetAsync(_locators.SplitBIDed, value, new ControlIntent("PolicyWorkflow", "SplitBIDed"));

    public Task PressSplitBIDedAsync(string key) =>
        _ui.PressAsync(_locators.SplitBIDed, key, new ControlIntent("PolicyWorkflow", "SplitBIDed"));

    public Task EnterSplitPDDedAsync(string value) =>
        _ui.FillAsync(_locators.SplitPDDed, value, new ControlIntent("PolicyWorkflow", "SplitPDDed"));

    public Task ClickStartAsync() =>
        _ui.ClickAsync(_locators.Start, new ControlIntent("PolicyWorkflow", "Start"));

    public Task VerifyBrowserCommunicationHTTPStatusZeroAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.BrowserCommunicationHTTPStatusZero, expected, property, new ControlIntent("PolicyWorkflow", "BrowserCommunicationHTTPStatusZero"));

    public Task VerifyValueAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Value, expected, property, new ControlIntent("PolicyWorkflow", "Value"));

    public Task ClickValueAsync() =>
        _ui.ClickAsync(_locators.Value, new ControlIntent("PolicyWorkflow", "Value"));

    public Task WaitForViewPolicyAsync(string expected) =>
        _ui.WaitAsync(_locators.ViewPolicy, expected, new ControlIntent("PolicyWorkflow", "ViewPolicy"));

    public Task PressViewPolicyAsync(string key) =>
        _ui.PressAsync(_locators.ViewPolicy, key, new ControlIntent("PolicyWorkflow", "ViewPolicy"));

    public Task ClickViewPolicyAsync() =>
        _ui.ClickAsync(_locators.ViewPolicy, new ControlIntent("PolicyWorkflow", "ViewPolicy"));

    public Task WaitForWatercraftLiabilityAsync(string expected) =>
        _ui.WaitAsync(_locators.PageTitle, expected, new ControlIntent("PolicyWorkflow", "WatercraftLiability"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

    public Task<string> CaptureDescriptionOfSpecifiedOperationAsync(string property = "") =>
        _ui.CaptureAsync(_locators.DescriptionOfSpecifiedOperation, property, new ControlIntent("PolicyWorkflow", "DescriptionOfSpecifiedOperation"));


    public Task EnterAggregateLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AggregateLimit, value, new ControlIntent("PolicyWorkflow", "AggregateLimit"), delayMs);

    public Task EnterDedTypeSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DedType, value, new ControlIntent("PolicyWorkflow", "DedType"), delayMs);

    public Task EnterDeductibleBasisSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DeductibleBasis, value, new ControlIntent("PolicyWorkflow", "DeductibleBasis"), delayMs);

    public Task EnterDescriptionOfSpecifiedOperationSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DescriptionOfSpecifiedOperation, value, new ControlIntent("PolicyWorkflow", "DescriptionOfSpecifiedOperation"), delayMs);

    public Task EnterDoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup, value, new ControlIntent("PolicyWorkflow", "DoesAnyRiskGeneratePowerOtherThanPrivateWindmillsOrEmergencyBackup"), delayMs);

    public Task EnterFireDamageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.FireDamage, value, new ControlIntent("PolicyWorkflow", "FireDamage"), delayMs);

    public Task EnterHasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverageSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage, value, new ControlIntent("PolicyWorkflow", "HasTheApplicantBeenInBusinessForAtLeast3YearsWithContinuousWorkersCompensationCoverage"), delayMs);

    public Task EnterIFRAMEDuckCreekPolicyDescriptionOfOtherSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IFRAMEDuckCreekPolicyDescriptionOfOther, value, new ControlIntent("PolicyWorkflow", "IFRAMEDuckCreekPolicyDescriptionOfOther"), delayMs);

    public Task EnterIsTheInsuredEngagedInAnySnowOrIceRemovalOperationsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.IsTheInsuredEngagedInAnySnowOrIceRemovalOperations, value, new ControlIntent("PolicyWorkflow", "IsTheInsuredEngagedInAnySnowOrIceRemovalOperations"), delayMs);

    public Task EnterMedicalSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.Medical, value, new ControlIntent("PolicyWorkflow", "Medical"), delayMs);

    public Task EnterOccurenceLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OccurenceLimit, value, new ControlIntent("PolicyWorkflow", "OccurenceLimit"), delayMs);

    public Task EnterOfFullTimeEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfFullTimeEmployees, value, new ControlIntent("PolicyWorkflow", "OfFullTimeEmployees"), delayMs);

    public Task EnterOfPartTimeEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfPartTimeEmployees, value, new ControlIntent("PolicyWorkflow", "OfPartTimeEmployees"), delayMs);

    public Task EnterOfSeasonalTemporaryEmployeesSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.OfSeasonalTemporaryEmployees, value, new ControlIntent("PolicyWorkflow", "OfSeasonalTemporaryEmployees"), delayMs);

    public Task EnterPersAdvInjSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PersAdvInj, value, new ControlIntent("PolicyWorkflow", "PersAdvInj"), delayMs);

    public Task EnterPremOpDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PremOpDed, value, new ControlIntent("PolicyWorkflow", "PremOpDed"), delayMs);

    public Task EnterPremOpPDDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PremOpPDDed, value, new ControlIntent("PolicyWorkflow", "PremOpPDDed"), delayMs);

    public Task EnterProdBIDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProdBIDed, value, new ControlIntent("PolicyWorkflow", "ProdBIDed"), delayMs);

    public Task EnterProdPDDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProdPDDed, value, new ControlIntent("PolicyWorkflow", "ProdPDDed"), delayMs);

    public Task EnterProductsAggLimitSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.ProductsAggLimit, value, new ControlIntent("PolicyWorkflow", "ProductsAggLimit"), delayMs);

    public Task EnterPropertyOfOthersRatingGroupSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.PropertyOfOthersRatingGroup, value, new ControlIntent("PolicyWorkflow", "PropertyOfOthersRatingGroup"), delayMs);

    public Task EnterSearchMethodEGDescriptionPolicySequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchMethodEGDescriptionPolicy, value, new ControlIntent("PolicyWorkflow", "SearchMethodEGDescriptionPolicy"), delayMs);

    public Task EnterRiskComputerSystemsSearchResultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskComputerSystemsSearchResult, value, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchResult"), delayMs);

    public Task EnterRiskBaileesCustomersSearchResultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersSearchResult, value, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchResult"), delayMs);

    public Task EnterRiskAccountsReceivableSearchResultSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskAccountsReceivableSearchResult, value, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchResult"), delayMs);

    public Task EnterSearchTextSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SearchText, value, new ControlIntent("PolicyWorkflow", "SearchText"), delayMs);

    public Task EnterRiskAccountsReceivableSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskAccountsReceivableSearchValue, value, new ControlIntent("PolicyWorkflow", "RiskAccountsReceivableSearchValue"), delayMs);

    public Task EnterRiskComputerSystemsSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskComputerSystemsSearchValue, value, new ControlIntent("PolicyWorkflow", "RiskComputerSystemsSearchValue"), delayMs);

    public Task EnterRiskBaileesCustomersSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.RiskBaileesCustomersSearchValue, value, new ControlIntent("PolicyWorkflow", "RiskBaileesCustomersSearchValue"), delayMs);

    public Task EnterSplitPDDedSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.SplitPDDed, value, new ControlIntent("PolicyWorkflow", "SplitPDDed"), delayMs);
}
