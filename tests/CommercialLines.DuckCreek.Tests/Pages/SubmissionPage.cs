using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class SubmissionPage
{
    private readonly SubmissionLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public SubmissionPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new SubmissionLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_1075_f7819aAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_1076_f7819aAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_556}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_1077_f7819aAsync
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_557}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_1078_f7819aAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_1079_f7819aAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_1080_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_1081_f7819aAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_1082_f7819aAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_1126_f7819aAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_1127_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_1128_f7819aAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_1129_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_1130_f7819aAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_1131_f7819aAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_1135_f7819aAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_1136_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_1137_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_1138_f7819aAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_1139_f7819aAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_1140_f7819aAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_1141_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_1142_f7819aAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_1186_f7819aAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_1187_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_1188_f7819aAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_1189_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_1190_f7819aAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_1191_f7819aAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_1192_f7819aAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_1193_f7819aAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_1216_f7819aAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_589}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_590}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_1217_f7819aAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync2()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0124_515771Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0125_515771Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_223}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0126_515771Async
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_224}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0127_515771Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0128_515771Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0129_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0130_515771Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0131_515771Async
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0175_515771Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0176_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0177_515771Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0178_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0179_515771Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0180_515771Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0184_515771Async
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0185_515771Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0186_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0187_515771Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0188_515771Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0189_515771Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0190_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0191_515771Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0235_515771Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0236_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0237_515771Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0238_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0239_515771Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0240_515771Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0241_515771Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0242_515771Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0256_515771Async
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync3()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0124_d65717Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0125_d65717Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_223}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0126_d65717Async
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_224}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0127_d65717Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0128_d65717Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0129_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0130_d65717Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0131_d65717Async
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0175_d65717Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0176_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0177_d65717Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0178_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0179_d65717Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0180_d65717Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0184_d65717Async
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0185_d65717Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0186_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0187_d65717Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0188_d65717Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0189_d65717Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0190_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0191_d65717Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0235_d65717Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0236_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0237_d65717Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0238_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0239_d65717Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0240_d65717Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0241_d65717Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0242_d65717Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0256_d65717Async
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync4()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0161_f90f36Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0162_f90f36Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_247}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0163_f90f36Async
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_248}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0164_f90f36Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0165_f90f36Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0166_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0167_f90f36Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0168_f90f36Async
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0212_f90f36Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0213_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0214_f90f36Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0215_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0216_f90f36Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0217_f90f36Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0221_f90f36Async
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0222_f90f36Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0223_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0224_f90f36Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0225_f90f36Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0226_f90f36Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0227_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0228_f90f36Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0272_f90f36Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0273_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0274_f90f36Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0275_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0276_f90f36Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0277_f90f36Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0278_f90f36Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0279_f90f36Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0284_f90f36Async
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync5()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0291_aad19bAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0292_aad19bAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_663}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0293_aad19bAsync
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_664}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0294_aad19bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0295_aad19bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0296_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0297_aad19bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0298_aad19bAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0342_aad19bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0343_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0344_aad19bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0345_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0346_aad19bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0347_aad19bAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0351_aad19bAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0352_aad19bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0353_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0354_aad19bAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0355_aad19bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0356_aad19bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0357_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0358_aad19bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0402_aad19bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0403_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0404_aad19bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0405_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0406_aad19bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0407_aad19bAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0408_aad19bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0409_aad19bAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0423_aad19bAsync
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync6()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0191_677267Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0192_677267Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_351}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0193_677267Async
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_352}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0194_677267Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0195_677267Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0196_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0197_677267Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0198_677267Async
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0242_677267Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0243_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0244_677267Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0245_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0246_677267Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0247_677267Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0251_677267Async
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0252_677267Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0253_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0254_677267Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0255_677267Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0256_677267Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0257_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0258_677267Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0302_677267Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0303_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0304_677267Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0305_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0306_677267Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0307_677267Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0308_677267Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0309_677267Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0323_677267Async
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync7()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0524_a6f47eAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0525_a6f47eAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_876}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0526_a6f47eAsync
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_877}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0527_a6f47eAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0528_a6f47eAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0529_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0530_a6f47eAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0531_a6f47eAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0575_a6f47eAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0576_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0577_a6f47eAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0578_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0579_a6f47eAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0580_a6f47eAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0584_a6f47eAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0585_a6f47eAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0586_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0587_a6f47eAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0588_a6f47eAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0589_a6f47eAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0590_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0591_a6f47eAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0635_a6f47eAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0636_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0637_a6f47eAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0638_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0639_a6f47eAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0640_a6f47eAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0641_a6f47eAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0642_a6f47eAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // VerifyJavaScriptResult_c744f4Page.GetSessionIDBuffer_0648_a6f47eAsync
        await _ui.FillAsync(_locators.Title, _data.Resolve("{{data:title_909}}"));
        await _ui.FillAsync(_locators.JavaScript, _data.Resolve("{{data:javascript_910}}"));
        await _ui.VerifyAsync(_locators.Result, _data.Resolve("{XB[SessionId]}"), "value");
        // TBoxSetBuffer_e51da1Page.BufferServerAddress_0649_a6f47eAsync
        _data.Set("ServerAddress", _data.Resolve("{{data:serveraddress}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync8()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0202_767d1bAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0203_767d1bAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_259}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0204_767d1bAsync
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_260}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0205_767d1bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0206_767d1bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0207_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0208_767d1bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0209_767d1bAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0253_767d1bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0254_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0255_767d1bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0256_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0257_767d1bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0258_767d1bAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0262_767d1bAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0263_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0264_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0265_767d1bAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0266_767d1bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0267_767d1bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0268_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0269_767d1bAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0313_767d1bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0314_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0315_767d1bAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0316_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0317_767d1bAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0318_767d1bAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0319_767d1bAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0320_767d1bAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0325_767d1bAsync
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync9()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0138_bb930cAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0139_bb930cAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_255}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0140_bb930cAsync
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_256}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0141_bb930cAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0142_bb930cAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0143_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0144_bb930cAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0145_bb930cAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0189_bb930cAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0190_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0191_bb930cAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0192_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0193_bb930cAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0194_bb930cAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0198_bb930cAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0199_bb930cAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0200_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0201_bb930cAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0202_bb930cAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0203_bb930cAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0204_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0205_bb930cAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0249_bb930cAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0250_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0251_bb930cAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0252_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0253_bb930cAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0254_bb930cAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0255_bb930cAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0256_bb930cAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0270_bb930cAsync
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync10()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0196_a8e5f5Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0197_a8e5f5Async
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_398}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0198_a8e5f5Async
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_399}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0199_a8e5f5Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0200_a8e5f5Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0201_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0202_a8e5f5Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0203_a8e5f5Async
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0247_a8e5f5Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0248_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0249_a8e5f5Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0250_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0251_a8e5f5Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0252_a8e5f5Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0256_a8e5f5Async
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0257_a8e5f5Async
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0258_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0259_a8e5f5Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0260_a8e5f5Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0261_a8e5f5Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0262_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0263_a8e5f5Async
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0307_a8e5f5Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0308_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0309_a8e5f5Async
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0310_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0311_a8e5f5Async
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0312_a8e5f5Async
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0313_a8e5f5Async
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0314_a8e5f5Async
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0338_a8e5f5Async
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync11()
    {
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckToSeeCoverageIsBoundExists_0158_f2d6bdAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        // SubmissionRequiredAndOptionalFields_4090a9Page.CheckIsCoverageBoundSelect_0159_f2d6bdAsync
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_291}}"), "Value");
        // SubmissionRequiredAndOptionalFields_4090a9Page.AnswerIsCoverageBound_0160_f2d6bdAsync
        await _ui.FillAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:is_this_coverage_bound_292}}"));
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0161_f2d6bdAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0162_f2d6bdAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0163_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0164_f2d6bdAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // TBoxSetBuffer_e51da1Page.SetErrorFlag_0165_f2d6bdAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0209_f2d6bdAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0210_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0211_f2d6bdAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0212_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0213_f2d6bdAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0214_f2d6bdAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0218_f2d6bdAsync
        await Task.Delay(1000);
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0219_f2d6bdAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0220_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.StoplightMessageIsVisible_0221_f2d6bdAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0222_f2d6bdAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.RunStoplight_0223_f2d6bdAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowClose, _data.Resolve("Absent"), "");
        // TBoxWait_7ea9e1Page.Wait2Seconds_0224_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CheckForError_0225_f2d6bdAsync
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickFirstCloseButtonOnError_0269_f2d6bdAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0270_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.ClickCompleteApp_0271_f2d6bdAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // TBoxWait_7ea9e1Page.Wait3Seconds_0272_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.CloseStoplightWindow_0273_f2d6bdAsync
        await _ui.ClickAsync(_locators.StoplightWaitingWindowClose);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.WaitOnStoplightWindowToGoAway_0274_f2d6bdAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // TBoxWait_7ea9e1Page.Wait35Seconds_0275_f2d6bdAsync
        await Task.Delay(1000);
        // SubmissionCompleteApplicationStoplightFunctionality_c9d58cPage.VerifyStoplightSuccessfullyRan_0276_f2d6bdAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
        // TBoxSetBuffer_e51da1Page.SetNBPremBuffer_0290_f2d6bdAsync
        _data.Set("NBPrem", _data.Resolve("{{data:nbprem}}"));
    }

}