using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

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

    // Business step: I complete required businessowners information
    public async Task CompleteRequiredBusinessownersInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.UMBNavigationLinks_0128_f7819aAsync
        await _ui.ClickAsync(_locators.Businessowners);
        // Businessowners_acf6e3Page.FillOutRequired_0129_f7819aAsync
        await _ui.WaitAsync(_locators.BusinessownersHeading, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_203}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        if (_data.Condition("'BOP Policy Number' != \"BOPPOL#\""))
        {
            await _ui.ClickAsync(_locators.ImportPolicyDataButton);
        }
        await _ui.WaitAsync(_locators.EffectiveDate, "NotEqual");
        // Businessowners_acf6e3Page.VerifyEmployerSLiabilityCheckBoxExistsNotExists_0130_f7819aAsync
        if (_data.Condition("'Employers Liability Checkbox' == NULL"))
        {
            await _ui.VerifyAsync(_locators.EmployerSLiabilityCheckBox, _data.Resolve("Absent"), "");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0134_f7819aAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0135_f7819aAsync
        await Task.Delay(1000);
    }

    // Business step: I complete required homeowners liability information
    public async Task CompleteRequiredHomeownersLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.HomeownersLiabilityNavigationLinks_0145_f7819aAsync
        await _ui.WaitAsync(_locators.HomeownerSLiability, "Visible");
        await _ui.PressAsync(_locators.HomeownerSLiability, "PRE:TAB");
        await _ui.PressAsync(_locators.HomeownerSLiability, "Tab");
        await _ui.PressAsync(_locators.HomeownerSLiability, "HOME");
        await _ui.ClickAsync(_locators.HomeownerSLiability);
        // HomeownerSLiability_967a01Page.HomeownerSLiability_0146_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_228}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit, _data.Resolve("{{data:liability_limit_232}}"));
        await _ui.PressAsync(_locators.LiabilityLimit, "Tab");
    }

    // Business step: I complete required personal auto liability information
    public async Task CompleteRequiredPersonalAutoLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.PersonalAutoLiabilityNavigationLinks_0149_f7819aAsync
        await _ui.WaitAsync(_locators.PersonalAuto, "Visible");
        await _ui.PressAsync(_locators.PersonalAuto, "PRE:TAB");
        await _ui.PressAsync(_locators.PersonalAuto, "Tab");
        await _ui.ClickAsync(_locators.PersonalAuto);
        // PersonalAutoLiability_1181bdPage.FillOutPersonalAutoLiabilityFields_0150_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_245}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit, _data.Resolve("{{data:liability_limit_249}}"));
        await _ui.PressAsync(_locators.LiabilityLimit, "Tab");
        if (_data.Condition("'PD Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.PDLimit, _data.Resolve("{{data:pd_limit_250}}"));
            await _ui.PressAsync(_locators.PDLimit, "CLICK");
            await _ui.PressAsync(_locators.PDLimit, "Enter");
            await _ui.PressAsync(_locators.PDLimit, "Tab");
        }
        await _ui.FillAsync(_locators.TotalSubjectPremium, _data.Resolve("{{data:total_subject_premium_251}}"));
        await _ui.PressAsync(_locators.TotalSubjectPremium, "Tab");
    }

    // Business step: I complete required watercraft liability information
    public async Task CompleteRequiredWatercraftLiabilityInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.WatercraftLiabNavigationLinks_0157_f7819aAsync
        await _ui.WaitAsync(_locators.WatercraftLiability, "Visible");
        await _ui.PressAsync(_locators.WatercraftLiability, "PRE:TAB");
        await _ui.PressAsync(_locators.WatercraftLiability, "Tab");
        await _ui.ClickAsync(_locators.WatercraftLiability);
        // WatercraftLiability_c88463Page.WatercraftLiability_0158_f7819aAsync
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_274}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit, _data.Resolve("{{data:liability_limit_278}}"));
        await _ui.PressAsync(_locators.LiabilityLimit, "Tab");
        await _ui.FillAsync(_locators.TotalSubjectPremium, _data.Resolve("{{data:total_subject_premium_279}}"));
        await _ui.PressAsync(_locators.TotalSubjectPremium, "Tab");
    }

    // Business step: I complete forms verification UMB
    public async Task CompleteFormsVerificationUMBAsync()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_1218_f7819aAsync
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_1219_f7819aAsync
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_594}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_1220_f7819aAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_1226_f7819aAsync
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_1228_f7819aAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA_UMB_variant.ps1  -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\\"  -FileName \"SUMB_StraightThrough\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_1230_f7819aAsync
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_1231_f7819aAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0261_515771Async
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0262_515771Async
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_266}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0263_515771Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0270_515771Async
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0271_515771Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL\\\" -FileName \"GL_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0273_515771Async
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0274_515771Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync2()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0261_d65717Async
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0262_d65717Async
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_266}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0263_d65717Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0270_d65717Async
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0271_d65717Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\GL_OCP\\\" -FileName \"GL_OCP_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0273_d65717Async
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0274_d65717Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete required additional\-interest information
    public async Task CompleteRequiredAdditionalInterestInformationAsync()
    {
        // BAPNavigationLinks_e0270bPage.BAPNavigationLinks_0137_f90f36Async
        await _ui.WaitAsync(_locators.AdditionalInterests, "Exists");
        await _ui.ClickAsync(_locators.AdditionalInterests);
        // AdditionalInterestsSchedule_145f1fPage.AdditionalInterests_0138_f90f36Async
        await _ui.WaitAsync(_locators.AddlInterests, "Exists");
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync3()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0289_f90f36Async
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0290_f90f36Async
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_290}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0291_f90f36Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0298_f90f36Async
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0299_f90f36Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\\" -FileName \"BAP_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0301_f90f36Async
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0302_f90f36Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync4()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0428_aad19bAsync
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0429_aad19bAsync
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_706}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0430_aad19bAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0437_aad19bAsync
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0438_aad19bAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\CPP\\\" -FileName \"CPP_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0440_aad19bAsync
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0441_aad19bAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync5()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0328_677267Async
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0329_677267Async
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_394}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0330_677267Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0337_677267Async
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0338_677267Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\CP\\\" -FileName \"CP_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0340_677267Async
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0341_677267Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync6()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0650_a6f47eAsync
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0651_a6f47eAsync
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_914}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0652_a6f47eAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0659_a6f47eAsync
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0660_a6f47eAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\BAP\\\" -FileName \"BAP_StraightThrough\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0662_a6f47eAsync
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0663_a6f47eAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete required businessowners information
    public async Task CompleteRequiredBusinessownersInformationAsync2()
    {
        // UMBNavigationLinks_77d89fPage.UMBNavigationLinks_0115_767d1bAsync
        await _ui.ClickAsync(_locators.Businessowners);
        // Businessowners_acf6e3Page.FillOutRequired_0116_767d1bAsync
        await _ui.WaitAsync(_locators.BusinessownersHeading, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_183}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        if (_data.Condition("'BOP Policy Number' != \"BOPPOL#\""))
        {
            await _ui.ClickAsync(_locators.ImportPolicyDataButton);
        }
        await _ui.WaitAsync(_locators.EffectiveDate, "NotEqual");
        // Businessowners_acf6e3Page.VerifyEmployerSLiabilityCheckBoxExistsNotExists_0117_767d1bAsync
        if (_data.Condition("'Employers Liability Checkbox' == NULL"))
        {
            await _ui.VerifyAsync(_locators.EmployerSLiabilityCheckBox, _data.Resolve("Absent"), "");
        }
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0121_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0122_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete forms verification UMB
    public async Task CompleteFormsVerificationUMBAsync2()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0347_767d1bAsync
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0348_767d1bAsync
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_302}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0349_767d1bAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0355_767d1bAsync
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0357_767d1bAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -File FormsCheckQA_UMB_variant.ps1  -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\SUMB\\\"  -FileName \"SUMB_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0359_767d1bAsync
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0360_767d1bAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        // IndicatorsAndErrors_ea9144Page.CheckForLoadingIndicator_0361_767d1bAsync
        await _ui.VerifyAsync(_locators.LoadingMessage, _data.Resolve("Visible"), "");
        // TBoxWait_7ea9e1Page.Wait2Secs_0362_767d1bAsync
        await Task.Delay(1000);
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync7()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0275_bb930cAsync
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0276_bb930cAsync
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_298}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0277_bb930cAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0284_bb930cAsync
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0285_bb930cAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\\" -FileName \"WC_BASIC\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0287_bb930cAsync
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0288_bb930cAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync8()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0343_a8e5f5Async
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0344_a8e5f5Async
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_441}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0345_a8e5f5Async
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0352_a8e5f5Async
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0353_a8e5f5Async
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\IM\\\" -FileName \"IM_BASIC\" -State  \"AZ\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0355_a8e5f5Async
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0356_a8e5f5Async
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

    // Business step: I complete forms verification
    public async Task CompleteFormsVerificationAsync9()
    {
        // FormsAPIRequest_dd3260Page.FormsAPIRequest_0295_f2d6bdAsync
        await _ui.FillAsync(_locators.SessionID, _data.Resolve("{B[SessionId]}"));
        // FormsAPIResponse_fb29c0Page.FormsAPIResponse_0296_f2d6bdAsync
        await _ui.VerifyAsync(_locators.StatusCode, _data.Resolve("{{data:expected_statuscode_value_334}}"), "value");
        // TBoxWait_7ea9e1Page.SyncAPI_0297_f2d6bdAsync
        await Task.Delay(1000);
        // TBoxWait_7ea9e1Page.SyncAPI_0304_f2d6bdAsync
        await Task.Delay(1000);
        // TBoxSetBuffer_e51da1Page.BufferPowershellArguments_0305_f2d6bdAsync
        _data.Set("PowershellArguments", _data.Resolve("powershell.exe -ExecutionPolicy Bypass -NoProfile -File FormsCheckQA.ps1 -Path \"\\\\mis\\sys\\QLTY\\Test_Automation\\Tricentis_Tosca\\Forms_Check\\WC\\\" -FileName \"WC_StraightThrough\" -State  \"AL\" -QuoteID \"{B[QuoteID]}\""));
        // TBoxClipboard_dc3815Page.DisplayTheResultsSummary_0307_f2d6bdAsync
        _data.Set("SummaryResults", await _ui.CaptureAsync(_locators.Value, "InnerText"));
        // TBoxSetBuffer_e51da1Page.CheckAndReportForFailsInTheFormsVerificationFromTheSummaryResults_0308_f2d6bdAsync
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_2}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_3}}"));
        _data.Set("SummaryResults", _data.Resolve("{{data:summaryresults_4}}"));
    }

}
