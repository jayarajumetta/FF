using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class PolicyInformationPage
{
    private readonly PolicyInformationLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public PolicyInformationPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new PolicyInformationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete policy Details \(Optimized\)
    public async Task CompletePolicyDetailsOptimizedAsync()
    {
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.ChoosePrimaryFarmCategory_0053_503012Async
        await _ui.ClickAsync(_locators.PrimaryFarmCategory);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0054_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.WaitOnPrimaryFarmTypeToAppear_0055_503012Async
        await _ui.WaitAsync(_locators.PrimaryFarmType, "Exists");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.SelectPrimaryFarmType_0056_503012Async
        await _ui.ClickAsync(_locators.PrimaryFarmType);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0057_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.ToggleSecondaryFarmSectionOn_0058_503012Async
        await _ui.ClickAsync(_locators.AddSecondaryFarmTypeToggle);
        await _ui.WaitAsync(_locators.SecondaryFarmCategory, "Visible");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.ChooseSecondaryFarmCategory_0059_503012Async
        await _ui.ClickAsync(_locators.SecondaryFarmCategory);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0060_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.WaitOnSecondaryFarmTypeToAppear_0061_503012Async
        await _ui.WaitAsync(_locators.SecondaryFarmType, "Exists");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.SelectSecondaryFarmType_0062_503012Async
        await _ui.ClickAsync(_locators.SecondaryFarmType);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0063_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.EnterGrossFarmIncome_0064_503012Async
        await _ui.FillAsync(_locators.GrossFarmIncome, _data.Resolve("{{data:gross_farm_income_76}}"));
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.AnswerIndustrialHempQuestionNo_0065_503012Async
        if (_data.Condition("'Industrial Hemp Answer' == \"No\""))
        {
        await _ui.SelectAsync(_locators.IndustrialHempNo, _data.Resolve(""));
        }
        if (_data.Condition("'Industrial Hemp Answer' == \"Yes\""))
        {
        await _ui.SelectAsync(_locators.IndustrialHempYes, _data.Resolve(""));
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0066_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0067_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I complete policy Details \(Optimized\)
    public async Task CompletePolicyDetailsOptimizedAsync2()
    {
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.ChoosePrimaryFarmCategory_0053_08f3f1Async
        await _ui.ClickAsync(_locators.PrimaryFarmCategory);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0054_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.WaitOnPrimaryFarmTypeToAppear_0055_08f3f1Async
        await _ui.WaitAsync(_locators.PrimaryFarmType, "Exists");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.SelectPrimaryFarmType_0056_08f3f1Async
        await _ui.ClickAsync(_locators.PrimaryFarmType);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0057_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.ToggleSecondaryFarmSectionOn_0058_08f3f1Async
        await _ui.ClickAsync(_locators.AddSecondaryFarmTypeToggle);
        await _ui.WaitAsync(_locators.SecondaryFarmCategory, "Visible");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.ChooseSecondaryFarmCategory_0059_08f3f1Async
        await _ui.ClickAsync(_locators.SecondaryFarmCategory);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0060_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.WaitOnSecondaryFarmTypeToAppear_0061_08f3f1Async
        await _ui.WaitAsync(_locators.SecondaryFarmType, "Exists");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.SelectSecondaryFarmType_0062_08f3f1Async
        await _ui.ClickAsync(_locators.SecondaryFarmType);
        // CLEQSFPPolicyDetailsOptimizedCLEQCommonWaitOnLoadingIndicator_e16e8ePage.EQLoadingIndicatorWait_0063_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.EnterGrossFarmIncome_0064_08f3f1Async
        await _ui.FillAsync(_locators.GrossFarmIncome, _data.Resolve("{{data:gross_farm_income_75}}"));
        // CLEQSFPPolicyDetailsOptimized_d0a0daPage.AnswerIndustrialHempQuestionNo_0065_08f3f1Async
        if (_data.Condition("'Industrial Hemp Answer' == \"No\""))
        {
        await _ui.SelectAsync(_locators.IndustrialHempNo, _data.Resolve(""));
        }
        if (_data.Condition("'Industrial Hemp Answer' == \"Yes\""))
        {
        await _ui.SelectAsync(_locators.IndustrialHempYes, _data.Resolve(""));
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0066_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0067_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}