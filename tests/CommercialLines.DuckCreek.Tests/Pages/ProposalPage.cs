using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class ProposalPage
{
    private readonly ProposalLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public ProposalPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new ProposalLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0061_d344b2Async
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0062_d344b2Async
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0063_d344b2Async
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync2()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0061_a1ba9cAsync
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0062_a1ba9cAsync
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0063_a1ba9cAsync
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync3()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0061_85cb3fAsync
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0062_85cb3fAsync
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0063_85cb3fAsync
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync4()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0061_c839dfAsync
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0062_c839dfAsync
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0063_c839dfAsync
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync5()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0061_b3ff07Async
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0062_b3ff07Async
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0063_b3ff07Async
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync6()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0062_c7d608Async
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0063_c7d608Async
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0064_c7d608Async
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

    // Business step: I start a new quote
    public async Task StartANewQuoteAsync7()
    {
        // CommonNavigationLinks_dba56bPage.InitiateANewQuote_0061_2a8772Async
        await _ui.ClickAsync(_locators.NewQuote);
        // ProductSelection_4b609bPage.SelectAgencyAndProduct_0062_2a8772Async
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{data:effective_date_43}}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        _data.Set("NBEffDate", await _ui.CaptureAsync(_locators.EffectiveDate, "InnerText"));
        if (_data.Condition("'Product:*' != \"Carrier_SpecialFarmPackage  Pages   US   (4.0.0.0)\""))
        {
            await _ui.FillAsync(_locators.Product, _data.Resolve("{{data:product_45}}"));
            await _ui.PressAsync(_locators.Product, "CLICK");
            await _ui.PressAsync(_locators.Product, "Enter");
            await _ui.PressAsync(_locators.Product, "Tab");
        }
        await _ui.WaitAsync(_locators.Start, "Visible");
        await _ui.ClickAsync(_locators.Start);
        await _ui.ClickAsync(_locators.Start);
        // TBoxSetBuffer_e51da1Page.SetNBEffDateBuffer_0063_2a8772Async
        _data.Set("NBEffDate", _data.Resolve("{{data:nbeffdate}}"));
    }

}
