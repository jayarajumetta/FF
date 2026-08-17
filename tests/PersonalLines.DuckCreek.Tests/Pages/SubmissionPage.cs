using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class SubmissionPage
{
    private readonly BrowserSession _browser;

    private readonly SubmissionLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public SubmissionPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _browser = browser;

        _locators = new SubmissionLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete submission underwriting comments and review
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0152_8f9ff6Async
        await _ui.WaitAsync(_locators.Submission1, "Exists");
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0153_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0154_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0155_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.FillAsync(_locators.Comments, _data.Resolve("{{data:comments_530}}"));
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0156_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.VerifyAsync(_locators.ReferUW, _data.Resolve("Visible"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0157_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.ClickAsync(_locators.ReferUW);
        }
        await _ui.ClickAsync(_locators.SaveExit1);
    }

    // Business step: I recall the quote in ExpertQuote
    public async Task RecallTheQuoteInExpertQuoteAsync()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0183_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_551}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0184_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the Level 9 underwriting bypass
    public async Task CompleteTheLevel9UnderwritingBypassAsync()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0188_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CorrectionNeededStep1))
        {
            await _ui.VerifyAsync(_locators.CorrectionNeededStep1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0189_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SaveExit1))
        {
            await _ui.ClickAsync(_locators.SaveExit1);
        }
    }

    // Business step: I complete the Level 9 underwriting bypass for txt quote policy search
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0205_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_583}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0206_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the submission checklist
    public async Task CompleteTheSubmissionChecklistAsync()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0243_8f9ff6Async
        await _ui.ClickAsync(_locators.Checklist1);
        // EQAgentListCountCapture_336cf8Page.EQAgentListCountCapture_0244_8f9ff6Async
        _data.Set("AgentList count", await _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, "InnerText"));
        // EQECheckList_45a110Page.EQECheckList_0245_8f9ff6Async
        await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0246_8f9ff6Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_591}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_592}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_593}}"));
        // EQECheckList_45a110Page.EQECheckList1_0247_8f9ff6Async
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0249_8f9ff6Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_595}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_596}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_597}}"));
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0250_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0251_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQECheckList_45a110Page.EQECheckList_0252_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.AutoCycleRVApplication))
        {
            await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        }
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0253_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_602}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_603}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_604}}"));
        // EQECheckList_45a110Page.EQECheckList1_0254_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer))
        {
            await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        }
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0256_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_606}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_607}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_608}}"));
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0257_8f9ff6Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
        // EQChecklistClose_a85085Page.EQChecklistClose_0259_8f9ff6Async
        await _ui.ClickAsync(_locators.ChecklistCloseOk);
    }

    // Business step: I transmit the policy
    public async Task TransmitThePolicyAsync()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0260_8f9ff6Async
        await _ui.WaitAsync(_locators.Transmit, "Exists");
        await _ui.ClickAsync(_locators.Transmit);
    }

    // Business step: I verify policy transmission confirmation
    public async Task VerifyPolicyTransmissionConfirmationAsync()
    {
        // EQTransmitConfirmation_b0e274Page.TransmitConfirmation_0262_8f9ff6Async
        _data.Set("Policy Number", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
        await _ui.FillAsync(_locators.TransmitConfirmation, _data.Resolve("{DATE}"));
        // TestDataCreateProvideNewItem_2a56e9Page.TestDataCreateProvideNewItem_0263_8f9ff6Async
        _data.Set("TestDataCreateProvideNewItem", _data.Get("TestData - Create & provide new item"));
        _data.Set("TDM_ExistingOrNewTDSType", _data.Resolve("{{data:tdm_existingornewtdstype}}"));
        _data.Set("TDM_DataStructurePolicyNumber", _data.Resolve("{{runtime:Policy Number}}"));
        _data.Set("TDM_DataStructureEffectiveDate", _data.Resolve("{{runtime:EffectiveDate}}"));
        _data.Set("TDM_DataStructureDateTime", _data.Resolve("{DATE} {TIME}"));
        _data.Set("TDM_DataStructureTestCase", _data.Resolve("{{runtime:TCName}}"));
        _data.Set("TDM_DataStructureState", _data.Resolve("{{runtime:State}}"));
    }

    // Business step: I complete submission underwriting comments and review
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync2()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0164_8f5301Async
        await _ui.WaitAsync(_locators.Submission1, "Exists");
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0165_8f5301Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0166_8f5301Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0167_8f5301Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.FillAsync(_locators.Comments, _data.Resolve("{{data:comments_581}}"));
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0168_8f5301Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.VerifyAsync(_locators.ReferUW, _data.Resolve("Visible"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0169_8f5301Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.ClickAsync(_locators.ReferUW);
        }
        await _ui.ClickAsync(_locators.SaveExit1);
    }

    // Business step: I recall the quote in ExpertQuote
    public async Task RecallTheQuoteInExpertQuoteAsync2()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0195_8f5301Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_602}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0196_8f5301Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the submission checklist
    public async Task CompleteTheSubmissionChecklistAsync2()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0200_8f5301Async
        await _ui.ClickAsync(_locators.Checklist1);
        // EQAgentListCountCapture_336cf8Page.EQAgentListCountCapture_0201_8f5301Async
        _data.Set("AgentList count", await _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, "InnerText"));
        // EQECheckList_45a110Page.EQECheckList_0202_8f5301Async
        await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0203_8f5301Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_610}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_611}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_612}}"));
        // EQECheckList_45a110Page.EQECheckList1_0204_8f5301Async
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0206_8f5301Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_614}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_615}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_616}}"));
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0207_8f5301Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0208_8f5301Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQECheckList_45a110Page.EQECheckList_0209_8f5301Async
        if (await _ui.ExistsAsync(_locators.AutoCycleRVApplication))
        {
            await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        }
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0210_8f5301Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_621}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_622}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_623}}"));
        // EQECheckList_45a110Page.EQECheckList1_0211_8f5301Async
        if (await _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer))
        {
            await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        }
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0213_8f5301Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_625}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_626}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_627}}"));
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0214_8f5301Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
        // EQChecklistClose_a85085Page.EQChecklistClose_0216_8f5301Async
        await _ui.ClickAsync(_locators.ChecklistCloseOk);
    }

    // Business step: I transmit the policy
    public async Task TransmitThePolicyAsync2()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0217_8f5301Async
        await _ui.WaitAsync(_locators.Transmit, "Exists");
        await _ui.ClickAsync(_locators.Transmit);
    }

    // Business step: I verify policy transmission confirmation
    public async Task VerifyPolicyTransmissionConfirmationAsync2()
    {
        // EQTransmitConfirmation_b0e274Page.TransmitConfirmation_0219_8f5301Async
        _data.Set("Policy Number", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
        // TestDataCreateProvideNewItem_2a56e9Page.TestDataCreateProvideNewItem_0220_8f5301Async
        _data.Set("TestDataCreateProvideNewItem", _data.Get("TestData - Create & provide new item"));
        _data.Set("TDM_ExistingOrNewTDSType", _data.Resolve("{{data:tdm_existingornewtdstype}}"));
        _data.Set("TDM_DataStructurePolicyNumber", _data.Resolve("{{runtime:Policy Number}}"));
        _data.Set("TDM_DataStructureEffectiveDate", _data.Resolve("{{runtime:EffectiveDate}}"));
        _data.Set("TDM_DataStructureDateTime", _data.Resolve("{DATE} {TIME}"));
        _data.Set("TDM_DataStructureTestCase", _data.Resolve("{{runtime:TCName}}"));
        _data.Set("TDM_DataStructureState", _data.Resolve("{{runtime:State}}"));
    }

    // Business step: I complete the Level 9 underwriting bypass
    public async Task CompleteTheLevel9UnderwritingBypassAsync2()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0165_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CorrectionNeededStep1))
        {
            await _ui.VerifyAsync(_locators.CorrectionNeededStep1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0166_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SaveExit1))
        {
            await _ui.ClickAsync(_locators.SaveExit1);
        }
    }

    // Business step: I complete the Level 9 underwriting bypass for txt quote policy search
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync2()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0182_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_591}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0183_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete submission underwriting comments and review
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync3()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0220_e2e0d7Async
        await _ui.WaitAsync(_locators.Submission1, "Exists");
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0221_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0222_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0223_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.FillAsync(_locators.Comments, _data.Resolve("{{data:comments_598}}"));
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0224_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.VerifyAsync(_locators.ReferUW, _data.Resolve("Visible"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0225_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.ClickAsync(_locators.ReferUW);
        }
        await _ui.ClickAsync(_locators.SaveExit1);
    }

    // Business step: I open the configured policy application for 15 submission
    public async Task OpenTheConfiguredPolicyApplicationFor15SubmissionAsync()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0243_e2e0d7Async
        if (_data.Condition("If Referral Button > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I recall the quote in ExpertQuote
    public async Task RecallTheQuoteInExpertQuoteAsync3()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0251_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_619}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0252_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the submission checklist
    public async Task CompleteTheSubmissionChecklistAsync3()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0256_e2e0d7Async
        await _ui.ClickAsync(_locators.Checklist1);
        // EQAgentListCountCapture_336cf8Page.EQAgentListCountCapture_0257_e2e0d7Async
        _data.Set("AgentList count", await _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, "InnerText"));
        // EQECheckList_45a110Page.EQECheckList_0258_e2e0d7Async
        await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0259_e2e0d7Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_627}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_628}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_629}}"));
        // EQECheckList_45a110Page.EQECheckList1_0260_e2e0d7Async
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0262_e2e0d7Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_631}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_632}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_633}}"));
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0263_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0264_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQECheckList_45a110Page.EQECheckList_0265_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.AutoCycleRVApplication))
        {
            await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        }
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0266_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_638}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_639}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_640}}"));
        // EQECheckList_45a110Page.EQECheckList1_0267_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer))
        {
            await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        }
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0269_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_642}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_643}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_644}}"));
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0270_e2e0d7Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
        // EQChecklistClose_a85085Page.EQChecklistClose_0272_e2e0d7Async
        await _ui.ClickAsync(_locators.ChecklistCloseOk);
    }

    // Business step: I transmit the policy
    public async Task TransmitThePolicyAsync3()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0273_e2e0d7Async
        await _ui.WaitAsync(_locators.Transmit, "Exists");
        await _ui.ClickAsync(_locators.Transmit);
    }

    // Business step: I verify policy transmission confirmation
    public async Task VerifyPolicyTransmissionConfirmationAsync3()
    {
        // EQTransmitConfirmation_b0e274Page.TransmitConfirmation_0275_e2e0d7Async
        await _ui.WaitAsync(_locators.PolicyNumber, "Exists");
        _data.Set("Policy Number", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
        // TestDataCreateProvideNewItem_2a56e9Page.TestDataCreateProvideNewItem_0276_e2e0d7Async
        _data.Set("TestDataCreateProvideNewItem", _data.Get("TestData - Create & provide new item"));
        _data.Set("TDM_ExistingOrNewTDSType", _data.Resolve("{{data:tdm_existingornewtdstype}}"));
        _data.Set("TDM_DataStructurePolicyNumber", _data.Resolve("{{runtime:Policy Number}}"));
        _data.Set("TDM_DataStructureEffectiveDate", _data.Resolve("{{runtime:EffectiveDate}}"));
        _data.Set("TDM_DataStructureDateTime", _data.Resolve("{DATE} {TIME}"));
        _data.Set("TDM_DataStructureTestCase", _data.Resolve("{{runtime:TCName}}"));
        _data.Set("TDM_DataStructureState", _data.Resolve("{{runtime:State}}"));
    }

    // Business step: I complete the Level 9 underwriting bypass
    public async Task CompleteTheLevel9UnderwritingBypassAsync3()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0165_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CorrectionNeededStep1))
        {
            await _ui.VerifyAsync(_locators.CorrectionNeededStep1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0166_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SaveExit1))
        {
            await _ui.ClickAsync(_locators.SaveExit1);
        }
    }

    // Business step: I complete the Level 9 underwriting bypass for txt quote policy search
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync3()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0182_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_591}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0183_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete submission underwriting comments and review
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync4()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0220_bafd4aAsync
        await _ui.WaitAsync(_locators.Submission1, "Exists");
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0221_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0222_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0223_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.FillAsync(_locators.Comments, _data.Resolve("{{data:comments_598}}"));
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0224_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.VerifyAsync(_locators.ReferUW, _data.Resolve("Visible"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0225_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.ClickAsync(_locators.ReferUW);
        }
        await _ui.ClickAsync(_locators.SaveExit1);
    }

    // Business step: I open the configured policy application for 15 submission
    public async Task OpenTheConfiguredPolicyApplicationFor15SubmissionAsync2()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0243_bafd4aAsync
        if (_data.Condition("If Referral Button > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I recall the quote in ExpertQuote
    public async Task RecallTheQuoteInExpertQuoteAsync4()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0251_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_619}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0252_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the submission checklist
    public async Task CompleteTheSubmissionChecklistAsync4()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0256_bafd4aAsync
        await _ui.ClickAsync(_locators.Checklist1);
        // EQAgentListCountCapture_336cf8Page.EQAgentListCountCapture_0257_bafd4aAsync
        _data.Set("AgentList count", await _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, "InnerText"));
        // EQECheckList_45a110Page.EQECheckList_0258_bafd4aAsync
        await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0259_bafd4aAsync
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_627}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_628}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_629}}"));
        // EQECheckList_45a110Page.EQECheckList1_0260_bafd4aAsync
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0262_bafd4aAsync
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_631}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_632}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_633}}"));
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0263_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0264_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQECheckList_45a110Page.EQECheckList_0265_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.AutoCycleRVApplication))
        {
            await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        }
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0266_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_638}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_639}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_640}}"));
        // EQECheckList_45a110Page.EQECheckList1_0267_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer))
        {
            await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        }
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0269_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_642}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_643}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_644}}"));
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0270_bafd4aAsync
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
        // EQChecklistClose_a85085Page.EQChecklistClose_0272_bafd4aAsync
        await _ui.ClickAsync(_locators.ChecklistCloseOk);
    }

    // Business step: I transmit the policy
    public async Task TransmitThePolicyAsync4()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0273_bafd4aAsync
        await _ui.WaitAsync(_locators.Transmit, "Exists");
        await _ui.ClickAsync(_locators.Transmit);
    }

    // Business step: I verify policy transmission confirmation
    public async Task VerifyPolicyTransmissionConfirmationAsync4()
    {
        // EQTransmitConfirmation_b0e274Page.TransmitConfirmation_0275_bafd4aAsync
        await _ui.WaitAsync(_locators.PolicyNumber, "Exists");
        _data.Set("Policy Number", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
        // TestDataCreateProvideNewItem_2a56e9Page.TestDataCreateProvideNewItem_0276_bafd4aAsync
        _data.Set("TestDataCreateProvideNewItem", _data.Get("TestData - Create & provide new item"));
        _data.Set("TDM_ExistingOrNewTDSType", _data.Resolve("{{data:tdm_existingornewtdstype}}"));
        _data.Set("TDM_DataStructurePolicyNumber", _data.Resolve("{{runtime:Policy Number}}"));
        _data.Set("TDM_DataStructureEffectiveDate", _data.Resolve("{{runtime:EffectiveDate}}"));
        _data.Set("TDM_DataStructureDateTime", _data.Resolve("{DATE} {TIME}"));
        _data.Set("TDM_DataStructureTestCase", _data.Resolve("{{runtime:TCName}}"));
        _data.Set("TDM_DataStructureState", _data.Resolve("{{runtime:State}}"));
    }

    // Business step: I complete the Level 9 underwriting bypass
    public async Task CompleteTheLevel9UnderwritingBypassAsync4()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0168_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CorrectionNeededStep1))
        {
            await _ui.VerifyAsync(_locators.CorrectionNeededStep1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0169_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SaveExit1))
        {
            await _ui.ClickAsync(_locators.SaveExit1);
        }
    }

    // Business step: I complete the Level 9 underwriting bypass for txt quote policy search
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync4()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0185_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_608}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0186_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete submission underwriting comments and review
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync5()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0223_8f4c8fAsync
        await _ui.WaitAsync(_locators.Submission1, "Exists");
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0224_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0225_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0226_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.FillAsync(_locators.Comments, _data.Resolve("{{data:comments_615}}"));
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0227_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.VerifyAsync(_locators.ReferUW, _data.Resolve("Visible"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0228_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.ClickAsync(_locators.ReferUW);
        }
        await _ui.ClickAsync(_locators.SaveExit1);
    }

    // Business step: I open the configured policy application for 15 submission
    public async Task OpenTheConfiguredPolicyApplicationFor15SubmissionAsync3()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0246_8f4c8fAsync
        if (_data.Condition("If Referral Button > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I recall the quote in ExpertQuote
    public async Task RecallTheQuoteInExpertQuoteAsync5()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0254_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_636}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0255_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the submission checklist
    public async Task CompleteTheSubmissionChecklistAsync5()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0259_8f4c8fAsync
        await _ui.ClickAsync(_locators.Checklist1);
        // EQAgentListCountCapture_336cf8Page.EQAgentListCountCapture_0260_8f4c8fAsync
        _data.Set("AgentList count", await _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, "InnerText"));
        // EQECheckList_45a110Page.EQECheckList_0261_8f4c8fAsync
        await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0262_8f4c8fAsync
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_644}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_645}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_646}}"));
        // EQECheckList_45a110Page.EQECheckList1_0263_8f4c8fAsync
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0265_8f4c8fAsync
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_648}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_649}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_650}}"));
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0266_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0267_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQECheckList_45a110Page.EQECheckList_0268_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.AutoCycleRVApplication))
        {
            await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        }
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0269_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_655}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_656}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_657}}"));
        // EQECheckList_45a110Page.EQECheckList1_0270_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer))
        {
            await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        }
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0272_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_659}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_660}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_661}}"));
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0273_8f4c8fAsync
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
        // EQChecklistClose_a85085Page.EQChecklistClose_0275_8f4c8fAsync
        await _ui.ClickAsync(_locators.ChecklistCloseOk);
    }

    // Business step: I transmit the policy
    public async Task TransmitThePolicyAsync5()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0276_8f4c8fAsync
        await _ui.WaitAsync(_locators.Transmit, "Exists");
        await _ui.ClickAsync(_locators.Transmit);
    }

    // Business step: I verify policy transmission confirmation
    public async Task VerifyPolicyTransmissionConfirmationAsync5()
    {
        // EQTransmitConfirmation_b0e274Page.TransmitConfirmation_0278_8f4c8fAsync
        await _ui.WaitAsync(_locators.PolicyNumber, "Exists");
        _data.Set("Policy Number", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
        await _ui.FillAsync(_locators.TransmitConfirmation, _data.Resolve("{{data:transmit_confirmation_669}}"));
        // TestDataCreateProvideNewItem_2a56e9Page.TestDataCreateProvideNewItem_0279_8f4c8fAsync
        _data.Set("TestDataCreateProvideNewItem", _data.Get("TestData - Create & provide new item"));
        _data.Set("TDM_ExistingOrNewTDSType", _data.Resolve("{{data:tdm_existingornewtdstype}}"));
        _data.Set("TDM_DataStructurePolicyNumber", _data.Resolve("{{runtime:Policy Number}}"));
        _data.Set("TDM_DataStructureEffectiveDate", _data.Resolve("{{runtime:EffectiveDate}}"));
        _data.Set("TDM_DataStructureDateTime", _data.Resolve("{DATE} {TIME}"));
        _data.Set("TDM_DataStructureTestCase", _data.Resolve("{{runtime:TCName}}"));
        _data.Set("TDM_DataStructureState", _data.Resolve("{{runtime:State}}"));
    }

    // Business step: I complete the Level 9 underwriting bypass
    public async Task CompleteTheLevel9UnderwritingBypassAsync5()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0168_10f911Async
        if (await _ui.ExistsAsync(_locators.CorrectionNeededStep1))
        {
            await _ui.VerifyAsync(_locators.CorrectionNeededStep1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0169_10f911Async
        if (await _ui.ExistsAsync(_locators.SaveExit1))
        {
            await _ui.ClickAsync(_locators.SaveExit1);
        }
    }

    // Business step: I complete the Level 9 underwriting bypass for txt quote policy search
    public async Task CompleteTheLevel9UnderwritingBypassForTxtQuotePolicySearchAsync5()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0185_10f911Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_611}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0186_10f911Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete submission underwriting comments and review
    public async Task CompleteSubmissionUnderwritingCommentsAndReviewAsync6()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0223_10f911Async
        await _ui.WaitAsync(_locators.Submission1, "Exists");
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0224_10f911Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0225_10f911Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.VerifyAsync(_locators.Comments, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0226_10f911Async
        if (await _ui.ExistsAsync(_locators.Comments))
        {
            await _ui.FillAsync(_locators.Comments, _data.Resolve("{{data:comments_618}}"));
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0227_10f911Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.VerifyAsync(_locators.ReferUW, _data.Resolve("Visible"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0228_10f911Async
        if (await _ui.ExistsAsync(_locators.ReferUW))
        {
            await _ui.ClickAsync(_locators.ReferUW);
        }
        await _ui.ClickAsync(_locators.SaveExit1);
    }

    // Business step: I open the configured policy application for 15 submission
    public async Task OpenTheConfiguredPolicyApplicationFor15SubmissionAsync4()
    {
        // EQOpenUrl_bc49e2Page.EQOpenUrl_0246_10f911Async
        if (_data.Condition("If Referral Button > Then"))
        {
            await _browser.Page.GotoAsync(_data.Resolve("{{data:application_url}}"));
        }
    }

    // Business step: I recall the quote in ExpertQuote
    public async Task RecallTheQuoteInExpertQuoteAsync6()
    {
        // EQNewQuote_785181Page.RecallQuotePolicy_0254_10f911Async
        if (await _ui.ExistsAsync(_locators.QuotePolicySearch))
        {
            await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{data:txt_quote_policy_search_639}}"));
            await _ui.PressAsync(_locators.QuotePolicySearch, "CTRL+A");
        }
        await _ui.FillAsync(_locators.QuotePolicySearch, _data.Resolve("{{runtime:QuoteNumber}}"));
        await _ui.ClickAsync(_locators.NewQuoteSearch);
        // EQAutoTabs_bf9a1ePage.EQClickOnSubmissionPage_0255_10f911Async
        if (await _ui.ExistsAsync(_locators.DIVSubmission))
        {
            await _ui.ClickAsync(_locators.DIVSubmission);
        }
    }

    // Business step: I complete the submission checklist
    public async Task CompleteTheSubmissionChecklistAsync6()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0259_10f911Async
        await _ui.ClickAsync(_locators.Checklist1);
        // EQAgentListCountCapture_336cf8Page.EQAgentListCountCapture_0260_10f911Async
        _data.Set("AgentList count", await _ui.CaptureAsync(_locators.DIVAgentDocumentsCount, "InnerText"));
        // EQECheckList_45a110Page.EQECheckList_0261_10f911Async
        await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0262_10f911Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_647}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_648}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_649}}"));
        // EQECheckList_45a110Page.EQECheckList1_0263_10f911Async
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0265_10f911Async
        await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_651}}"));
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_652}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_653}}"));
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0266_10f911Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQSubmissionNEW_5224d2Page.EQSubmissionUWCommentsNEW_0267_10f911Async
        if (await _ui.ExistsAsync(_locators.Checklist1))
        {
            await _ui.VerifyAsync(_locators.Checklist1, _data.Resolve("Exists"), "");
        }
        // EQECheckList_45a110Page.EQECheckList_0268_10f911Async
        if (await _ui.ExistsAsync(_locators.AutoCycleRVApplication))
        {
            await _ui.ClickAsync(_locators.AutoCycleRVApplication);
        }
        await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        // TBoxSaveAs_c1c647Page.TBoxSaveAs_0269_10f911Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_658}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_659}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_660}}"));
        // EQECheckList_45a110Page.EQECheckList1_0270_10f911Async
        if (await _ui.ExistsAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer))
        {
            await _ui.ClickAsync(_locators.DIVDragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer);
        }
        // TBoxSaveAs_c1c647Page.TBoxSaveAs1_0272_10f911Async
        if (await _ui.ExistsAsync(_locators.Caption))
        {
            await _ui.FillAsync(_locators.Caption, _data.Resolve("{{data:caption_662}}"));
        }
        await _ui.FillAsync(_locators.FilePath, _data.Resolve("{{data:filepath_663}}"));
        await _ui.FillAsync(_locators.Button, _data.Resolve("{{data:button_664}}"));
        // EQCommonLoadingIndicatorWait_36281fPage.EQCommonLoadingIndicatorWait_0273_10f911Async
        await _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, _data.Resolve("Exists"), "");
        // EQChecklistClose_a85085Page.EQChecklistClose_0275_10f911Async
        await _ui.ClickAsync(_locators.ChecklistCloseOk);
    }

    // Business step: I transmit the policy
    public async Task TransmitThePolicyAsync6()
    {
        // EQSubmissionNEW_5224d2Page.EQSubmissionNEW_0276_10f911Async
        await _ui.WaitAsync(_locators.Transmit, "Exists");
        await _ui.ClickAsync(_locators.Transmit);
    }

    // Business step: I verify policy transmission confirmation
    public async Task VerifyPolicyTransmissionConfirmationAsync6()
    {
        // EQTransmitConfirmation_b0e274Page.TransmitConfirmation_0278_10f911Async
        await _ui.WaitAsync(_locators.PolicyNumber, "Exists");
        _data.Set("Policy Number", await _ui.CaptureAsync(_locators.PolicyNumber, "InnerText"));
        // TestDataCreateProvideNewItem_2a56e9Page.TestDataCreateProvideNewItem_0279_10f911Async
        _data.Set("TestDataCreateProvideNewItem", _data.Get("TestData - Create & provide new item"));
        _data.Set("TDM_ExistingOrNewTDSType", _data.Resolve("{{data:tdm_existingornewtdstype}}"));
        _data.Set("TDM_DataStructurePolicyNumber", _data.Resolve("{{runtime:Policy Number}}"));
        _data.Set("TDM_DataStructureEffectiveDate", _data.Resolve("{{runtime:EffectiveDate}}"));
        _data.Set("TDM_DataStructureDateTime", _data.Resolve("{DATE} {TIME}"));
        _data.Set("TDM_DataStructureTestCase", _data.Resolve("{{runtime:TCName}}"));
        _data.Set("TDM_DataStructureState", _data.Resolve("{{runtime:State}}"));
    }

}
