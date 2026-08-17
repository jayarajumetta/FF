using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    // Business step: I complete checklist and Esign
    public async Task CompleteChecklistAndEsignAsync()
    {
        // EQCommonSubmissionChecklistAndEsign_2e6388Page.EQBOPSubmission_0508_d18a3eAsync
        await _ui.WaitAsync(_locators.SubmissionScreenHeading, "Exists");
        if (_data.Condition("'Referral Needed' != NULL"))
        {
        await _ui.VerifyAsync(_locators.NoReferralNeededVerification, _data.Resolve("Absent"), "");
        }
        await _ui.ClickAsync(_locators.LaunchToChecklistButton);
        if (_data.Condition("'Referral Needed' == NULL"))
        {
        await _ui.VerifyAsync(_locators.NoReferralNeededVerification, _data.Resolve("Exists"), "");
        }
        // EQCommonSubmissionChecklistAndEsign_2e6388Page.SetBufferForWaitOnTime_0509_d18a3eAsync
        _data.Set("WaitOnTime", _data.Resolve("{{data:waitontime_2}}"));
    }

    // Business step: I refer to UW
    public async Task ReferToUWAsync()
    {
        // CLEQCommonRegressionReferToUW_8aa9b2Page.EQSubmissionReferToUW_0562_d18a3eAsync
        await _ui.PressAsync(_locators.UnderwritingRulesAgentComments, "POST:ENTER");
        await _ui.PressAsync(_locators.UnderwritingRulesAgentComments, "Enter");
        await _ui.PressAsync(_locators.UnderwritingRulesAgentComments, "Tab");
        await _ui.ClickAsync(_locators.ReferToUW);
    }

    // Business step: I run Stoplight
    public async Task RunStoplightAsync()
    {
        // CommonSubmissionRunStoplight_076e05Page.CheckToSeeCoverageIsBoundExists_0615_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IsThisCoverageBound))
        {
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.CheckIsCoverageBoundSelect_0616_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IsThisCoverageBound))
        {
        await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_661}}"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.AnswerIsCoverageBound_0617_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IsThisCoverageBound))
        {
        await _ui.PressAsync(_locators.IsThisCoverageBound, "POST:TAB");
        await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        }
        // CommonSubmissionRunStoplight_076e05Page.RunStoplight_0618_d18a3eAsync
        await _ui.ClickAsync(_locators.CompleteApplication);
        // CommonSubmissionRunStoplight_076e05Page.RunStoplight_0619_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Close))
        {
        await _ui.VerifyAsync(_locators.Close, _data.Resolve("Absent"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait2Seconds_0620_d18a3eAsync
        if (_data.Condition("during do (Wait for Stoplight to Run) [max=90]"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.CheckForError_0621_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.StoplightWaitingWindowError))
        {
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.SetErrorFlag_0622_d18a3eAsync
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag}}"));
        _data.Set("ErrorFlag", _data.Resolve("{{data:errorflag_2}}"));
        _data.Set("REPETITION", _data.Resolve("{{data:repetition}}"));
        // CommonSubmissionRunStoplight_076e05Page.ClickFirstCloseButtonOnError_0666_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError))
        {
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait3Seconds_0667_d18a3eAsync
        if (_data.Condition("during do (Wait for Stoplight to Run) [max=90]"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.ClickCompleteApp_0668_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.CompleteApplication))
        {
        await _ui.ClickAsync(_locators.CompleteApplication);
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait3Seconds_0669_d18a3eAsync
        if (_data.Condition("during do (Wait for Stoplight to Run) [max=90]"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.CloseStoplightWindow_0670_d18a3eAsync
        await _ui.ClickAsync(_locators.Close);
        // CommonSubmissionRunStoplight_076e05Page.WaitOnStoplightWindowToGoAway_0671_d18a3eAsync
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        // CommonSubmissionRunStoplightCommonGeneralWaitOnLoadingIndicator_d0bd99Page.CheckForLoadingIndicator_0672_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CommonSubmissionRunStoplightCommonGeneralWaitOnLoadingIndicator_d0bd99Page.Wait2Secs_0673_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CommonSubmissionRunStoplight_076e05Page.WaitForStoplightMessageToExist_0674_d18a3eAsync
        await _ui.WaitAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, "Exists");
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        // CommonSubmissionRunStoplight_076e05Page.Wait35Seconds_0675_d18a3eAsync
        await Task.Delay(1000);
        // CommonSubmissionRunStoplightCommonGeneralWaitOnLoadingIndicator_d0bd99Page.CheckForLoadingIndicator_0676_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.LoadingMessage))
        {
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        }
        // CommonSubmissionRunStoplightCommonGeneralWaitOnLoadingIndicator_d0bd99Page.Wait2Secs_0677_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CommonSubmissionRunStoplight_076e05Page.StoplightMessageIsVisible_0678_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs))
        {
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Exists"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.RunStoplight_0679_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.CompleteApplication))
        {
        await _ui.ClickAsync(_locators.CompleteApplication);
        }
        // CommonSubmissionRunStoplight_076e05Page.RunStoplight_0680_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Close))
        {
        await _ui.VerifyAsync(_locators.Close, _data.Resolve("Absent"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait2Seconds_0681_d18a3eAsync
        if (_data.Condition("if stoplight error"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.CheckForError_0682_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.StoplightWaitingWindowError))
        {
        await _ui.VerifyAsync(_locators.StoplightWaitingWindowError, _data.Resolve("Exists"), "");
        }
        // CommonSubmissionRunStoplight_076e05Page.ClickFirstCloseButtonOnError_0726_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError))
        {
        await _ui.ClickAsync(_locators.StoplightWaitingWindowFirstCloseButtonOnError);
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait3Seconds_0727_d18a3eAsync
        if (_data.Condition("if stoplight error"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.ClickCompleteApp_0728_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.CompleteApplication))
        {
        await _ui.ClickAsync(_locators.CompleteApplication);
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait3Seconds_0729_d18a3eAsync
        if (_data.Condition("if stoplight error"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.CloseStoplightWindow_0730_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Close))
        {
        await _ui.ClickAsync(_locators.Close);
        }
        // CommonSubmissionRunStoplight_076e05Page.WaitOnStoplightWindowToGoAway_0731_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.StoplightWaitingWindow))
        {
        await _ui.WaitAsync(_locators.StoplightWaitingWindow, "Absent");
        }
        // CommonSubmissionRunStoplight_076e05Page.Wait35Seconds_0732_d18a3eAsync
        if (_data.Condition("if stoplight error"))
        {
        await Task.Delay(1000);
        }
        // CommonSubmissionRunStoplight_076e05Page.VerifyStoplightSuccessfullyRan_0733_d18a3eAsync
        await _ui.VerifyAsync(_locators.AllRequiredFieldsHaveNotBeenCompletedPleaseCompleteHighlightedTabs, _data.Resolve("Absent"), "");
    }

    // Business step: I transmit to DC
    public async Task TransmitToDCAsync()
    {
        // EQCommonSubmissionTransmitToDC_454dd1Page.EQCommonSubmissionTransmitToDC_0834_d18a3eAsync
        await _ui.ClickAsync(_locators.Transmit);
        // CLEQCommonWaitOnLoadingIndicator_59e7d3Page.EQLoadingIndicatorWait_0835_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQCommonTransmitConfirmationAndNewPacketVerificationInEQ_e053c1Page.EQCommonTransmitConfirmationBufferPolicyNumberVerifyPremium_0836_d18a3eAsync
        await _ui.VerifyAsync(_locators.TABLERowCellExplicitName1, _data.Resolve("{{data:expected_table_row_cell_explicitname_1_767}}"), "");
        await _ui.VerifyAsync(_locators.TABLERowCellExplicitName2, _data.Resolve("{{data:expected_table_row_cell_explicitname_2_768}}"), "");
        await _ui.VerifyAsync(_locators.TABLERowCellExplicitName4, _data.Resolve("{{runtime:Policy#}}"), "");
        await _ui.VerifyAsync(_locators.TABLERowCellExplicitName5, _data.Resolve("{{runtime:Premium}}"), "");
        await _ui.VerifyAsync(_locators.TABLERowCellExplicitName5, _data.Resolve("{{data:expected_table_row_cell_explicitname_5_771}}"), "");
    }

}