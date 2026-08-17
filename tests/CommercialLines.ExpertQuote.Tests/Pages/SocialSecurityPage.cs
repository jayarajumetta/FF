using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class SocialSecurityPage
{
    private readonly SocialSecurityLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public SocialSecurityPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new SocialSecurityLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I enter and validate the insured social security number
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync()
    {
        // EQCommonSSN_a9ff7ePage.SSN_0041_503012Async
        await _ui.WaitAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, "Visible");
        _data.Set("InsuredSSN", _data.Random("InsuredSSN", "025[0-9]{6}"));
        await _ui.WaitAsync(_locators.SubmitAngular, "Visible");
        await _ui.PressAsync(_locators.SubmitAngular, "POST:TAB");
        await _ui.PressAsync(_locators.SubmitAngular, "Tab");
        await _ui.ClickAsync(_locators.SubmitAngular);
        // EQCommonSSN_a9ff7ePage.VerifyIfPopupExists_0042_503012Async
        if (await _ui.ExistsAsync(_locators.NoPrefillMatchFound))
        {
        await _ui.VerifyAsync(_locators.NoPrefillMatchFound, _data.Resolve("Exists"), "");
        }
        // EQCommonSSN_a9ff7ePage.ClickContinue_0043_503012Async
        if (await _ui.ExistsAsync(_locators.Continue))
        {
        await _ui.ClickAsync(_locators.Continue);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0044_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0045_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I enter and validate the insured social security number
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync2()
    {
        // EQCommonSSN_a9ff7ePage.SSN_0042_656be2Async
        await _ui.WaitAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, "Visible");
        _data.Set("InsuredSSN", _data.Random("InsuredSSN", "025[0-9]{6}"));
        await _ui.WaitAsync(_locators.SubmitAngular, "Visible");
        await _ui.PressAsync(_locators.SubmitAngular, "POST:TAB");
        await _ui.PressAsync(_locators.SubmitAngular, "Tab");
        await _ui.ClickAsync(_locators.SubmitAngular);
        // EQCommonSSN_a9ff7ePage.VerifyIfPopupExists_0043_656be2Async
        if (await _ui.ExistsAsync(_locators.NoPrefillMatchFound))
        {
        await _ui.VerifyAsync(_locators.NoPrefillMatchFound, _data.Resolve("Exists"), "");
        }
        // EQCommonSSN_a9ff7ePage.ClickContinue_0044_656be2Async
        if (await _ui.ExistsAsync(_locators.Continue))
        {
        await _ui.ClickAsync(_locators.Continue);
        }
        // EQCommonSSN_a9ff7ePage.SetBufferForWaitOnTime_0045_656be2Async
        _data.Set("WaitOnTime", _data.Resolve("{{data:waitontime_2}}"));
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0046_656be2Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0047_656be2Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I enter and validate the insured social security number
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync3()
    {
        // EQCommonSSN_a9ff7ePage.SSN_0041_d18a3eAsync
        await _ui.WaitAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, "Visible");
        _data.Set("InsuredSSN", _data.Random("InsuredSSN", "025[0-9]{6}"));
        await _ui.WaitAsync(_locators.SubmitAngular, "Visible");
        await _ui.PressAsync(_locators.SubmitAngular, "POST:TAB");
        await _ui.PressAsync(_locators.SubmitAngular, "Tab");
        await _ui.ClickAsync(_locators.SubmitAngular);
        // EQCommonSSN_a9ff7ePage.VerifyIfPopupExists_0042_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.NoPrefillMatchFound))
        {
        await _ui.VerifyAsync(_locators.NoPrefillMatchFound, _data.Resolve("Exists"), "");
        }
        // EQCommonSSN_a9ff7ePage.ClickContinue_0043_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.Continue))
        {
        await _ui.ClickAsync(_locators.Continue);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0044_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0045_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I enter the insured social security number and handle any prefill result
    public async Task EnterTheInsuredSocialSecurityNumberAndHandleAnyPrefillResultAsync()
    {
        // Common_7de90aPage.SSNEntryAndOptionalNoPrefillMatchHandling_00410044_8fa692Async
        _data.Set("WaitOnTime", _data.Resolve("{{data:wait_on_time}}"));
        await _ui.VerifyAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, _data.Resolve("Visible"), "");
        _data.Set("InsuredSSN", _data.Random("InsuredSSN", "025[0-9]{6}"));
        await _ui.FillAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, _data.Resolve("{{runtime:InsuredSSN}}"));
        await _ui.VerifyAsync(_locators.EChecklistEChecklistSubmit, _data.Resolve("Visible"), "");
        await _ui.ClickAsync(_locators.EChecklistEChecklistSubmit);
        if (await _ui.ExistsAsync(_locators.Continue))
        {
        await _ui.ClickAsync(_locators.Continue);
        }
    }

    // Business step: I enter and validate the insured social security number
    public async Task EnterAndValidateTheInsuredSocialSecurityNumberAsync4()
    {
        // EQCommonSSN_a9ff7ePage.SSN_0041_08f3f1Async
        await _ui.WaitAsync(_locators.TheSSNCouldNotBeFoundPleaseEnterAnSSN, "Visible");
        _data.Set("InsuredSSN", _data.Random("InsuredSSN", "025[0-9]{6}"));
        await _ui.WaitAsync(_locators.SubmitAngular, "Visible");
        await _ui.PressAsync(_locators.SubmitAngular, "POST:TAB");
        await _ui.PressAsync(_locators.SubmitAngular, "Tab");
        await _ui.ClickAsync(_locators.SubmitAngular);
        // EQCommonSSN_a9ff7ePage.VerifyIfPopupExists_0042_08f3f1Async
        if (await _ui.ExistsAsync(_locators.NoPrefillMatchFound))
        {
        await _ui.VerifyAsync(_locators.NoPrefillMatchFound, _data.Resolve("Exists"), "");
        }
        // EQCommonSSN_a9ff7ePage.ClickContinue_0043_08f3f1Async
        if (await _ui.ExistsAsync(_locators.Continue))
        {
        await _ui.ClickAsync(_locators.Continue);
        }
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0044_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0045_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}