using Microsoft.Playwright;
using InsuranceAutomation.Pages.PageMethods;
using InsuranceAutomation.Utils;
using InsuranceAutomation.Hooks;
using Reqnroll;

namespace InsuranceAutomation.StepDefinitions;

[Binding, Scope(Feature = "EQ BOP Smoke Test")]
public sealed class EQBOPSmokeTestSteps
{
    private readonly BrowserSession _browser;
    private readonly ScenarioData _data;
    public EQBOPSmokeTestSteps(BrowserSession browser, ScenarioData data) { _browser = browser; _data = data; }

    [When("I capture the quote identity")]
    public async Task ICaptureTheQuoteIdentity_10()
    {
        var eQCommonQuoteIdentifying = new EQCommonQuoteIdentifying(_browser.Page, _data);

        await eQCommonQuoteIdentifying.StoreNameAndQuoteAsync("Quote_NameNum");
        await eQCommonQuoteIdentifying.ClickCloseQuoteAsync();
    
    }

    [When("I close the current quote")]
    public async Task ICloseTheCurrentQuote_11()
    {
        var page = new EQCommonQuoteIdentifying(_browser.Page, _data);
        await page.SetCloseQuoteAsync(_data.Get("Close Quote", ""));
    
    }

    [When("I search by quote number")]
    public async Task ISearchByQuoteNumber_12()
    {
        var eQCommonLoadingIndicatorWait = new EQCommonLoadingIndicatorWait(_browser.Page, _data);
        var eQCommonSearchByQuoteNum = new EQCommonSearchByQuoteNum(_browser.Page, _data);

        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
        await eQCommonSearchByQuoteNum.SetQuoteSearchInputAsync(_data.Get("EQ Common Search by QuoteNum.quoteSearchInput", "{{buffer:Quote_Num}}"));
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.PressQuoteSearchInputAsync("Tab");
        await eQCommonSearchByQuoteNum.ClickSearchAsync();
        await eQCommonLoadingIndicatorWait.WaitForLoadingAsync();
    
    }

    [When("I verify the retrieved quote")]
    public async Task IVerifyTheRetrievedQuote_14()
    {
        var eQCommonQuoteIdentifying = new EQCommonQuoteIdentifying(_browser.Page, _data);

        await eQCommonQuoteIdentifying.VerifyNameAndQuoteAsync(_data.Get("EQ Common Quote Identifying.Name and Quote", "{{buffer:Quote_NameNum}}"));
    
    }
}
