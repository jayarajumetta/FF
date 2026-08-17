using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class DiscountsPage
{
    private readonly DiscountsLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public DiscountsPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new DiscountsLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete Business Auto policy\-specific fields
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync()
    {
        // PolicyInfoBAPSpecificFields_c8933aPage.LoopIfOKButtonDoesNotExist_0106_a1ba9cAsync
        await _ui.VerifyAsync(_locators.BAPSpecificFieldsOK, _data.Resolve("Absent"), "");
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterNAICSCode_0107_a1ba9cAsync
        await _ui.FillAsync(_locators.NAICSCodeSearchValue, _data.Resolve("{{data:naics_code_search_value_139}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0108_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterNAICSCode_0109_a1ba9cAsync
        await _ui.FillAsync(_locators.NAICSCodeSearchResults, _data.Resolve("{{data:naics_code_search_results_141}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0110_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterAccountCredit_0111_a1ba9cAsync
        if (_data.Condition("State != \"NY\""))
        {
        await _ui.FillAsync(_locators.AccountCredit, _data.Resolve("{{data:account_credit_143}}"));
        await _ui.PressAsync(_locators.AccountCredit, "Tab");
        await _ui.PressAsync(_locators.AccountCredit, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0112_a1ba9cAsync
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.ClickOK_0113_a1ba9cAsync
        await _ui.WaitAsync(_locators.BAPSpecificFieldsOK, "Exists");
        await _ui.ClickAsync(_locators.BAPSpecificFieldsOK);
        await _ui.WaitAsync(_locators.BAPSpecificFieldsOK, "Absent");
    }

    // Business step: I complete Business Auto policy\-specific fields
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync2()
    {
        // PolicyInfoBAPSpecificFields_c8933aPage.LoopIfOKButtonDoesNotExist_0068_f90f36Async
        await _ui.VerifyAsync(_locators.BAPSpecificFieldsOK, _data.Resolve("Absent"), "");
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterNAICSCode_0069_f90f36Async
        await _ui.FillAsync(_locators.NAICSCodeSearchValue, _data.Resolve("{{data:naics_code_search_value_79}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0070_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterNAICSCode_0071_f90f36Async
        await _ui.FillAsync(_locators.NAICSCodeSearchResults, _data.Resolve("{{data:naics_code_search_results_81}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0072_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterAccountCredit_0073_f90f36Async
        if (_data.Condition("State != \"NY\""))
        {
        await _ui.FillAsync(_locators.AccountCredit, _data.Resolve("{{data:account_credit_83}}"));
        await _ui.PressAsync(_locators.AccountCredit, "Tab");
        await _ui.PressAsync(_locators.AccountCredit, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0074_f90f36Async
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.ClickOK_0075_f90f36Async
        await _ui.WaitAsync(_locators.BAPSpecificFieldsOK, "Exists");
        await _ui.ClickAsync(_locators.BAPSpecificFieldsOK);
        await _ui.WaitAsync(_locators.BAPSpecificFieldsOK, "Absent");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0076_f90f36Async
        await Task.Delay(1000);
    }

    // Business step: I complete Business Auto policy\-specific fields
    public async Task CompleteBusinessAutoPolicySpecificFieldsAsync3()
    {
        // PolicyInfoBAPSpecificFields_c8933aPage.LoopIfOKButtonDoesNotExist_0091_a6f47eAsync
        await _ui.VerifyAsync(_locators.BAPSpecificFieldsOK, _data.Resolve("Absent"), "");
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterNAICSCode_0092_a6f47eAsync
        await _ui.FillAsync(_locators.NAICSCodeSearchValue, _data.Resolve("{{data:naics_code_search_value_122}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchValue, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0093_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterNAICSCode_0094_a6f47eAsync
        await _ui.FillAsync(_locators.NAICSCodeSearchResults, _data.Resolve("{{data:naics_code_search_results_124}}"));
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "CLICK");
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "Tab");
        await _ui.PressAsync(_locators.NAICSCodeSearchResults, "Tab");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0095_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.EnterAccountCredit_0096_a6f47eAsync
        if (_data.Condition("State != \"NY\""))
        {
        await _ui.FillAsync(_locators.AccountCredit, _data.Resolve("{{data:account_credit_126}}"));
        await _ui.PressAsync(_locators.AccountCredit, "Tab");
        await _ui.PressAsync(_locators.AccountCredit, "Tab");
        }
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0097_a6f47eAsync
        await Task.Delay(1000);
        // PolicyInfoBAPSpecificFields_c8933aPage.ClickOK_0098_a6f47eAsync
        await _ui.WaitAsync(_locators.BAPSpecificFieldsOK, "Exists");
        await _ui.ClickAsync(_locators.BAPSpecificFieldsOK);
        await _ui.WaitAsync(_locators.BAPSpecificFieldsOK, "Absent");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0099_a6f47eAsync
        await Task.Delay(1000);
    }

}