using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "Smoke Test Auto")]
public sealed class SmokeTestAutoSteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public SmokeTestAutoSteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [When("I complete prequalification")]
    public async Task ICompletePrequalification_6()
    {
        var eQTabs = new EQTabs(_browser.Page, _data);

        await eQTabs.StoreLblQuoteAsync("LblQuote");
        await eQTabs.StoreLblQNumAsync("QuoteNumber2");
        await eQTabs.ClickBtnCloseTabAsync();
        await eQTabs.ClickBtnNewTabAsync();
        await eQTabs.SetTxtQuoteSearchInputAsync(_data.Get("EQ Tabs.Txt_quoteSearchInput", "{{buffer:QuoteNumber}}"));
        await eQTabs.ClickBtnSearchAsync();
        await eQTabs.ClickBtnEditAsync();
        await eQTabs.StoreLblQNumAsync("QuoteNumber6");
        await eQTabs.VerifyLblQNumAsync(_data.Get("EQ Tabs.Lbl_QNum", "{{buffer:QuoteNumber2}}"));
    
    }
}
