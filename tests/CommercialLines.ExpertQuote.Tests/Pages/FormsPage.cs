using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class FormsPage
{
    private readonly FormsLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public FormsPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new FormsLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete forms verification for EQ in CLAS
    public async Task CompleteFormsVerificationForEQInCLASAsync()
    {
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.CheckToSeeIfContentLengthIsLessThan40_0274_503012Async
        if (_data.Condition("during run the API and repeat if Content Length is less than 40 [max=4]"))
        {
            _data.Set("CheckToSeeIfContentLengthIsLessThan40", _data.Resolve("{\"Expression\": \"{B[Content]} <40\"}"));
        }
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.FormsAPIRequest_0275_503012Async
        if (_data.Condition("during run the API and repeat if Content Length is less than 40 [max=4]"))
        {
            await _ui.FillAsync(_locators.FormsAPIRequest01660, _data.Resolve("{{runtime:SessionId}}"));
        }
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.FormsAPIResponse_0276_503012Async
        if (_data.Condition("during run the API and repeat if Content Length is less than 40 [max=4]"))
        {
            await _ui.FillAsync(_locators.FormsAPIResponse53891, _data.Resolve("{{data:forms_api_response_348}}"));
        }
        if (_data.Condition("during run the API and repeat if Content Length is less than 40 [max=4]"))
        {
            await _ui.FillAsync(_locators.FormsAPIResponse53891, _data.Resolve("{{data:forms_api_response_349}}"));
        }
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.SyncAPI_0277_503012Async
        if (_data.Condition("during run the API and repeat if Content Length is less than 40 [max=4]"))
        {
            await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        }
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.SyncAPI_0279_503012Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.SyncAPI_0287_503012Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.BufferPowershellArguments_0288_503012Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA.ps1  -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\\"  -FileName \"SFP_CE\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.DisplayTheResultsSummary_0290_503012Async
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"SummaryResults\"}"));
        // CLEQCommonGeneralFormsVerificationForEQInCLAS_4a1c59Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0291_503012Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification Retrieve QuoteID \& SessionID by Browser Console
    public async Task CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync()
    {
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.OpenDevToolsConsole_0446_d18a3eAsync
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.Wait_0447_d18a3eAsync
        await Task.Delay(1000);
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.EnablePastingInConsole_0448_d18a3eAsync
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.GetQuoteIDByConsole_0449_d18a3eAsync
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SaveQuoteIDBuffer_0450_d18a3eAsync
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[QuoteID]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.VerifyQuoteIDBuffer_0451_d18a3eAsync
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[QuoteID]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.GetSessionIDByConsole_0452_d18a3eAsync
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SaveSessionIDBuffer_0453_d18a3eAsync
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[SessionId]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.VerifySessionIDBuffer_0454_d18a3eAsync
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[SessionId]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.BufferServerAddress_0455_d18a3eAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.FormsAPIRequest_0456_d18a3eAsync
        await _ui.FillAsync(_locators.FormsAPIRequestB50D4, _data.Resolve("{{runtime:SessionId}}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.FormsAPIResponse_0457_d18a3eAsync
        await _ui.FillAsync(_locators.FormsAPIResponse3FBAF, _data.Resolve("{{data:forms_api_response_494}}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SyncAPI_0458_d18a3eAsync
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SyncAPI_0460_d18a3eAsync
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.BufferPowershellArguments_0461_d18a3eAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BOPSmart\\\" -FileName \"BOPSmart_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.DisplayTheResultsSummary_0463_d18a3eAsync
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"SummaryResults\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0464_d18a3eAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I perform Quick Search and Open Policy
    public async Task PerformQuickSearchAndOpenPolicyAsync()
    {
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.DashboardQuickSearch_0872_d18a3eAsync
        await _ui.FillAsync(_locators.SearchText, _data.Resolve("{B[Policy#]}"));
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.PressAsync(_locators.SearchText, "Tab");
        await _ui.ClickAsync(_locators.QuickSearchButton);
        // CommonDashboardPerformQuickSearchAndOpenPolicyCommonGeneralWaitOnLoadingIndicator_def0c7Page.CheckForLoadingIndicator_0873_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CommonDashboardPerformQuickSearchAndOpenPolicyCommonGeneralWaitOnLoadingIndicator_def0c7Page.Wait2Secs_0874_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.N500msWaitForSyncronization_0875_d18a3eAsync
        await Task.Delay(1000);
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.WaitForResults_0876_d18a3eAsync
        await _ui.WaitAsync(_locators.N1ResultsFoundCurrentlyShowing11, "Visible");
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.ClickViewPolicyAndWaitForNavigationAwayFromScreen_0877_d18a3eAsync
        await _ui.WaitAsync(_locators.ViewPolicy, "Visible");
        await _ui.ClickAsync(_locators.ViewPolicy);
        // CommonDashboardPerformQuickSearchAndOpenPolicyCommonGeneralWaitOnLoadingIndicator_def0c7Page.CheckForLoadingIndicator_0878_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
            await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CommonDashboardPerformQuickSearchAndOpenPolicyCommonGeneralWaitOnLoadingIndicator_def0c7Page.Wait2Secs_0879_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.N500msWaitForSyncronization_0880_d18a3eAsync
        await Task.Delay(1000);
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.ViewPolicyExists_0881_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ViewPolicy))
        {
            await _ui.VerifyAsync(_locators.ViewPolicy, _data.Resolve("Visible"), "");
        }
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.N5sWaitForSyncronization_0882_d18a3eAsync
        if (_data.Condition("while view Policy Exists [max=90]"))
        {
            await Task.Delay(1000);
        }
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.ViewPolicyExists_0883_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ViewPolicy))
        {
            await _ui.VerifyAsync(_locators.ViewPolicy, _data.Resolve("Visible"), "");
        }
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.ClickViewPolicy_0884_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ViewPolicy))
        {
            await _ui.ClickAsync(_locators.ViewPolicy);
        }
        // CommonDashboardPerformQuickSearchAndOpenPolicy_3431c5Page.N500msWaitForSyncronization_0885_d18a3eAsync
        if (_data.Condition("while view Policy Exists [max=90]"))
        {
            await Task.Delay(1000);
        }
    }

    // Business step: I complete forms verification Retrieve QuoteID \& SessionID by Browser Console
    public async Task CompleteFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsoleAsync2()
    {
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.OpenDevToolsConsole_0345_08f3f1Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.Wait_0346_08f3f1Async
        await Task.Delay(1000);
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.EnablePastingInConsole_0347_08f3f1Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.GetQuoteIDByConsole_0348_08f3f1Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SaveQuoteIDBuffer_0349_08f3f1Async
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[QuoteID]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.VerifyQuoteIDBuffer_0350_08f3f1Async
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[QuoteID]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.GetSessionIDByConsole_0351_08f3f1Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SaveSessionIDBuffer_0352_08f3f1Async
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[SessionId]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.VerifySessionIDBuffer_0353_08f3f1Async
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"{XB[SessionId]}\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.BufferServerAddress_0354_08f3f1Async
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.FormsAPIRequest_0355_08f3f1Async
        await _ui.FillAsync(_locators.FormsAPIRequestB50D4, _data.Resolve("{{runtime:SessionId}}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.FormsAPIResponse_0356_08f3f1Async
        await _ui.FillAsync(_locators.FormsAPIResponse3FBAF, _data.Resolve("{{data:forms_api_response_401}}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SyncAPI_0357_08f3f1Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.SyncAPI_0359_08f3f1Async
        await _ui.ReviewRequiredAsync("Browser-console/forms verification requires environment-specific implementation.");
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.BufferPowershellArguments_0360_08f3f1Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SFP\\\" -FileName \"SFP_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.DisplayTheResultsSummary_0362_08f3f1Async
        _data.Set("ClipboardValue", _data.Resolve("{\"Value\": \"SummaryResults\"}"));
        // CommonGeneralFormsVerificationRetrieveQuoteIDSessionIDByBrowserConsole_376283Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0363_08f3f1Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

}
