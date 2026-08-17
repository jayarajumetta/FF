using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

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

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_d06ed6Async
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync()
    {
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0018_d06ed6Async
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_40}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_44}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_48}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        if (_data.Condition("State == \"NEW YORK\""))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Resolve("{{data:county_combobox_52}}"));
        }
        if (_data.Condition("State == \"KENTUCKY\""))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Resolve("{{data:county_combobox_53}}"));
        }
        if (_data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
            await _ui.WaitAsync(_locators.CountyYes, "Exists");
        }
        if (_data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
            await _ui.SelectAsync(_locators.CountyYes, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.StartQuote, "True");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0019_d06ed6Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0020_d06ed6Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0021_d06ed6Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.WaitAsync(_locators.SSN, "Exists");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0022_d06ed6Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0023_d06ed6Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0024_d06ed6Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0025_d06ed6Async
        if (await _ui.ExistsAsync(_locators.USEEXISTINGACCOUNT))
        {
            await _ui.WaitAsync(_locators.USEEXISTINGACCOUNT, "Exists");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0026_d06ed6Async
        if (await _ui.ExistsAsync(_locators.StateMONTANA))
        {
            await _ui.ClickAsync(_locators.StateMONTANA);
        }
        if (_data.Condition("State != \"MONTANA\""))
        {
            await _ui.ClickAsync(_locators.USEEXISTINGACCOUNT);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0027_d06ed6Async
        _data.Set("EffectiveDate", _data.Get("Effective Date"));
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync()
    {
        // EQTabs_8481b3Page.EQTabsCapturingQuoteNumber_0028_d06ed6Async
        _data.Set("QuoteNumber2", await _ui.CaptureAsync(_locators.QNum, "Text"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBufferTrimmingQuoteNumber_0029_d06ed6Async
        _data.Set("QuoteNumber3", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}"));
        _data.Set("QuoteNumber4", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync2()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_8f9ff6Async
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync2()
    {
        // EQProposalDetailsStart_c2c5a9Page.NavigateToTopOfScreen_0019_8f9ff6Async
        await _ui.PressAsync(_locators.EffectiveDate, "PRE:Scroll[-2]");
        await _ui.PressAsync(_locators.EffectiveDate, "Scroll[-2]");
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0020_8f9ff6Async
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{runtime:EffectiveDate}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_42}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_49}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        await _ui.PressAsync(_locators.SameAsMailingAddress, "Click");
        if (_data.Condition("'County Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Get("County Name"));
        }
        await _ui.WaitAsync(_locators.StartQuote, "Visible");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0024_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0025_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0026_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0027_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0028_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.VerifyAsync(_locators.SSN, _data.Resolve("Exists"), "");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0029_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0030_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.ClientAlreadyExists))
        {
            await _ui.VerifyAsync(_locators.ClientAlreadyExists, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0031_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CREATENEWACCOUNT))
        {
            await _ui.ClickAsync(_locators.CREATENEWACCOUNT);
        }
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync2()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0033_8f9ff6Async
        _data.Set("QuoteNum", await _ui.CaptureAsync(_locators.QuoteNumber, "InnerText"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0034_8f9ff6Async
        _data.Set("QNum", _data.Resolve("{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync3()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_b91c7dAsync
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync3()
    {
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0018_b91c7dAsync
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_40}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_44}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_48}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        if (_data.Condition("State == \"NEW YORK\""))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Resolve("{{data:county_combobox_52}}"));
        }
        if (_data.Condition("State == \"KENTUCKY\""))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Resolve("{{data:county_combobox_53}}"));
        }
        if (_data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
            await _ui.WaitAsync(_locators.CountyYes, "Exists");
        }
        if (_data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
            await _ui.SelectAsync(_locators.CountyYes, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.StartQuote, "True");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0019_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0020_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0021_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.WaitAsync(_locators.SSN, "Exists");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0022_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0023_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0024_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0025_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.USEEXISTINGACCOUNT))
        {
            await _ui.WaitAsync(_locators.USEEXISTINGACCOUNT, "Exists");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0026_b91c7dAsync
        if (await _ui.ExistsAsync(_locators.StateMONTANA))
        {
            await _ui.ClickAsync(_locators.StateMONTANA);
        }
        if (_data.Condition("State != \"MONTANA\""))
        {
            await _ui.ClickAsync(_locators.USEEXISTINGACCOUNT);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0027_b91c7dAsync
        _data.Set("EffectiveDate", _data.Get("Effective Date"));
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync3()
    {
        // EQTabs_8481b3Page.EQTabsCapturingQuoteNumber_0028_b91c7dAsync
        _data.Set("QuoteNumber2", await _ui.CaptureAsync(_locators.QNum, "Text"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBufferTrimmingQuoteNumber_0029_b91c7dAsync
        _data.Set("QuoteNumber3", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}"));
        _data.Set("QuoteNumber4", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync4()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_8f5301Async
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync4()
    {
        // EQProposalDetailsStart_c2c5a9Page.NavigateToTopOfScreen_0019_8f5301Async
        await _ui.PressAsync(_locators.EffectiveDate, "PRE:Scroll[-2]");
        await _ui.PressAsync(_locators.EffectiveDate, "Scroll[-2]");
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0020_8f5301Async
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{runtime:EffectiveDate}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_42}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_49}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        await _ui.PressAsync(_locators.SameAsMailingAddress, "Click");
        if (_data.Condition("'County Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Get("County Name"));
        }
        await _ui.WaitAsync(_locators.StartQuote, "Visible");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0024_8f5301Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0025_8f5301Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0026_8f5301Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0027_8f5301Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0028_8f5301Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.VerifyAsync(_locators.SSN, _data.Resolve("Exists"), "");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0029_8f5301Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0030_8f5301Async
        if (await _ui.ExistsAsync(_locators.ClientAlreadyExists))
        {
            await _ui.VerifyAsync(_locators.ClientAlreadyExists, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0031_8f5301Async
        if (await _ui.ExistsAsync(_locators.CREATENEWACCOUNT))
        {
            await _ui.ClickAsync(_locators.CREATENEWACCOUNT);
        }
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync4()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0033_8f5301Async
        _data.Set("QuoteNum", await _ui.CaptureAsync(_locators.QuoteNumber, "InnerText"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0034_8f5301Async
        _data.Set("QNum", _data.Resolve("{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync5()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_e2e0d7Async
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync5()
    {
        // EQProposalDetailsStart_c2c5a9Page.NavigateToTopOfScreen_0019_e2e0d7Async
        await _ui.PressAsync(_locators.EffectiveDate, "PRE:Scroll[-2]");
        await _ui.PressAsync(_locators.EffectiveDate, "Scroll[-2]");
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0020_e2e0d7Async
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{runtime:EffectiveDate}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_42}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_49}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        await _ui.PressAsync(_locators.SameAsMailingAddress, "Click");
        if (_data.Condition("'County Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Get("County Name"));
        }
        await _ui.WaitAsync(_locators.StartQuote, "Visible");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0024_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0025_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0026_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0027_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0028_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.VerifyAsync(_locators.SSN, _data.Resolve("Exists"), "");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0029_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0030_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.ClientAlreadyExists))
        {
            await _ui.VerifyAsync(_locators.ClientAlreadyExists, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0031_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CREATENEWACCOUNT))
        {
            await _ui.ClickAsync(_locators.CREATENEWACCOUNT);
        }
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync5()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0033_e2e0d7Async
        _data.Set("QuoteNum", await _ui.CaptureAsync(_locators.QuoteNumber, "InnerText"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0034_e2e0d7Async
        _data.Set("QNum", _data.Resolve("{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync6()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_bafd4aAsync
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync6()
    {
        // EQProposalDetailsStart_c2c5a9Page.NavigateToTopOfScreen_0019_bafd4aAsync
        await _ui.PressAsync(_locators.EffectiveDate, "PRE:Scroll[-2]");
        await _ui.PressAsync(_locators.EffectiveDate, "Scroll[-2]");
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0020_bafd4aAsync
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{runtime:EffectiveDate}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_42}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_49}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        await _ui.PressAsync(_locators.SameAsMailingAddress, "Click");
        if (_data.Condition("'County Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Get("County Name"));
        }
        await _ui.WaitAsync(_locators.StartQuote, "Visible");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0024_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0025_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0026_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0027_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0028_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.VerifyAsync(_locators.SSN, _data.Resolve("Exists"), "");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0029_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0030_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.ClientAlreadyExists))
        {
            await _ui.VerifyAsync(_locators.ClientAlreadyExists, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0031_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CREATENEWACCOUNT))
        {
            await _ui.ClickAsync(_locators.CREATENEWACCOUNT);
        }
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync6()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0033_bafd4aAsync
        _data.Set("QuoteNum", await _ui.CaptureAsync(_locators.QuoteNumber, "InnerText"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0034_bafd4aAsync
        _data.Set("QNum", _data.Resolve("{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync7()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_8f4c8fAsync
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync7()
    {
        // EQProposalDetailsStart_c2c5a9Page.NavigateToTopOfScreen_0019_8f4c8fAsync
        await _ui.PressAsync(_locators.EffectiveDate, "PRE:Scroll[-2]");
        await _ui.PressAsync(_locators.EffectiveDate, "Scroll[-2]");
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0020_8f4c8fAsync
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{runtime:EffectiveDate}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_42}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_49}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        await _ui.PressAsync(_locators.SameAsMailingAddress, "Click");
        if (_data.Condition("'County Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Get("County Name"));
        }
        await _ui.WaitAsync(_locators.StartQuote, "Visible");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0024_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0025_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0026_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0027_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0028_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.VerifyAsync(_locators.SSN, _data.Resolve("Exists"), "");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0029_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0030_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.ClientAlreadyExists))
        {
            await _ui.VerifyAsync(_locators.ClientAlreadyExists, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0031_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CREATENEWACCOUNT))
        {
            await _ui.ClickAsync(_locators.CREATENEWACCOUNT);
        }
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync7()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0033_8f4c8fAsync
        _data.Set("QuoteNum", await _ui.CaptureAsync(_locators.QuoteNumber, "InnerText"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0034_8f4c8fAsync
        _data.Set("QNum", _data.Resolve("{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync8()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_10f911Async
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync8()
    {
        // EQProposalDetailsStart_c2c5a9Page.NavigateToTopOfScreen_0019_10f911Async
        await _ui.PressAsync(_locators.EffectiveDate, "PRE:Scroll[-2]");
        await _ui.PressAsync(_locators.EffectiveDate, "Scroll[-2]");
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0020_10f911Async
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{{runtime:EffectiveDate}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_42}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        await _ui.SelectAsync(_locators.StateName, _data.Resolve(""));
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_49}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        await _ui.PressAsync(_locators.SameAsMailingAddress, "Click");
        if (_data.Condition("'County Name' != NULL"))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Get("County Name"));
        }
        await _ui.WaitAsync(_locators.StartQuote, "Visible");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0024_10f911Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0025_10f911Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0026_10f911Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0027_10f911Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0028_10f911Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.VerifyAsync(_locators.SSN, _data.Resolve("Exists"), "");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0029_10f911Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0030_10f911Async
        if (await _ui.ExistsAsync(_locators.ClientAlreadyExists))
        {
            await _ui.VerifyAsync(_locators.ClientAlreadyExists, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0031_10f911Async
        if (await _ui.ExistsAsync(_locators.CREATENEWACCOUNT))
        {
            await _ui.ClickAsync(_locators.CREATENEWACCOUNT);
        }
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync8()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0033_10f911Async
        _data.Set("QuoteNum", await _ui.CaptureAsync(_locators.QuoteNumber, "InnerText"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0034_10f911Async
        _data.Set("QNum", _data.Resolve("{STRINGREPLACE[{B[QuoteNum]}][\"PERSONAL AUTO \\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QNum]}][\"\\)\"][\"\"]}"));
    }

    // Business step: I start New Quote
    public async Task StartNewQuoteAsync9()
    {
        // EQNewQuote_785181Page.ClickOnNewQuoteButton_0012_0dc866Async
        await _ui.WaitAsync(_locators.NewQuote, "Exists");
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("{{data:expected_btn_new_quote_2}}"), "");
        await _ui.ClickAsync(_locators.NewQuote);
    }

    // Business step: I start the policy proposal
    public async Task StartThePolicyProposalAsync9()
    {
        // EQProposalDetailsStart_c2c5a9Page.ProposalDetailsStart_0018_0dc866Async
        if (_data.Condition("LOB == \"PersonalAuto\""))
        {
            await _ui.ClickAsync(_locators.PersonalAuto);
        }
        if (_data.Condition("LOB == \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.Motorcycle);
        }
        if (_data.Condition("LOB == \"RecreationalVehicle\""))
        {
            await _ui.ClickAsync(_locators.RecreationalVehicle);
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.AgentCode, _data.Resolve("{{data:agentcode_40}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.AgentCode, "POST:TAB");
            await _ui.PressAsync(_locators.AgentCode, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.State, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.State, _data.Resolve("{{data:state_44}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.State, "POST:TAB");
            await _ui.PressAsync(_locators.State, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.SelectAsync(_locators.WritingCompany, _data.Resolve(""));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.FillAsync(_locators.WritingCompany, _data.Resolve("{{data:writingcompany_48}}"));
        }
        if (_data.Condition("LOB != \"RecreationalVehicle\""))
        {
            await _ui.PressAsync(_locators.WritingCompany, "POST:TAB");
            await _ui.PressAsync(_locators.WritingCompany, "Tab");
        }
        await _ui.WaitAsync(_locators.SameAsMailingAddress, "True");
        await _ui.ClickAsync(_locators.SameAsMailingAddress);
        if (_data.Condition("State == \"NEW YORK\""))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Resolve("{{data:county_combobox_52}}"));
        }
        if (_data.Condition("State == \"KENTUCKY\""))
        {
            await _ui.FillAsync(_locators.CountyComboBox, _data.Resolve("{{data:county_combobox_53}}"));
        }
        if (_data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
            await _ui.WaitAsync(_locators.CountyYes, "Exists");
        }
        if (_data.Condition("State == \"NEW YORK\" OR State == \"KENTUCKY\""))
        {
            await _ui.SelectAsync(_locators.CountyYes, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.StartQuote, "True");
        await _ui.ClickAsync(_locators.StartQuote);
        // EQProposalStartProceedSSN_cb42c0Page.InvalidAddress_0019_0dc866Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.VerifyAsync(_locators.PROCEED, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.ProceedWithAddress_0020_0dc866Async
        if (await _ui.ExistsAsync(_locators.PROCEED))
        {
            await _ui.ClickAsync(_locators.PROCEED);
        }
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0021_0dc866Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.WaitAsync(_locators.SSN, "Exists");
        }
        await _ui.VerifyAsync(_locators.ProposalStartProceedSSNSUBMIT, _data.Resolve("Exists"), "");
        // EQProposalStartProceedSSN_cb42c0Page.EQProposalStartProceedSSN_0022_0dc866Async
        if (await _ui.ExistsAsync(_locators.SSN))
        {
            await _ui.FillAsync(_locators.SSN, _data.Get("AL_ClientData.SSN"));
        }
        await _ui.ClickAsync(_locators.ProposalStartProceedSSNSUBMIT);
        // EQProposalStartProceedSSN_cb42c0Page.ConfirmSSN_0023_0dc866Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.VerifyAsync(_locators.CONFIRM, _data.Resolve("Exists"), "");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectConfirm_0024_0dc866Async
        if (await _ui.ExistsAsync(_locators.CONFIRM))
        {
            await _ui.ClickAsync(_locators.CONFIRM);
        }
        // EQProposalStartProceedSSN_cb42c0Page.ExistingClient_0025_0dc866Async
        if (await _ui.ExistsAsync(_locators.USEEXISTINGACCOUNT))
        {
            await _ui.WaitAsync(_locators.USEEXISTINGACCOUNT, "Exists");
        }
        // EQProposalStartProceedSSN_cb42c0Page.SelectExistingClient_0026_0dc866Async
        if (await _ui.ExistsAsync(_locators.StateMONTANA))
        {
            await _ui.ClickAsync(_locators.StateMONTANA);
        }
        if (_data.Condition("State != \"MONTANA\""))
        {
            await _ui.ClickAsync(_locators.USEEXISTINGACCOUNT);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetEffectiveDateBuffer_0027_0dc866Async
        _data.Set("EffectiveDate", _data.Get("Effective Date"));
    }

    // Business step: I capture the proposal number
    public async Task CaptureTheProposalNumberAsync9()
    {
        // EQTabs_8481b3Page.EQTabsCapturingQuoteNumber_0028_0dc866Async
        _data.Set("QuoteNumber2", await _ui.CaptureAsync(_locators.QNum, "Text"));
        // TBoxSetBuffer_e51da1Page.TBoxSetBufferTrimmingQuoteNumber_0029_0dc866Async
        _data.Set("QuoteNumber3", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber2]}][\"PERSONAL AUTO \"][\"\"]}"));
        _data.Set("QuoteNumber4", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber3]}][\"\\(\"][\"\"]}"));
        _data.Set("QuoteNumber", _data.Resolve("{STRINGREPLACE[{B[QuoteNumber4]}][\"\\)\"][\"\"]}"));
    }

}
