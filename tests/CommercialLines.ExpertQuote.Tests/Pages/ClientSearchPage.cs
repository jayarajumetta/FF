using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class ClientSearchPage
{
    private readonly ClientSearchLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public ClientSearchPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new ClientSearchLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I enter client search information
    public async Task EnterClientSearchInformationAsync()
    {
        // EQCommonEnterClientSearchInfo_116bf9Page.SetBufferForLastName_0029_503012Async
        _data.Set("LastName", _data.Random("LastName", "CE-[A-Z]{4}"));
        _data.Set("FirstName", _data.Random("FirstName", "SFP[A-Z]{3}"));
        // EQCommonEnterClientSearchInfo_116bf9Page.ClientInfo_0030_503012Async
        await _ui.WaitAsync(_locators.ClientInfo, "Visible");
        await _ui.WaitAsync(_locators.NewExistingClientSearch, "Visible");
        await _ui.FillAsync(_locators.CustomerNameFirst, _data.Resolve("{{runtime:FirstName}}"));
        await _ui.FillAsync(_locators.CustomerNameLast, _data.Resolve("{{runtime:LastName}}"));
        await _ui.FillAsync(_locators.CustomerDateOfBirth, _data.Resolve("{{data:customer_dateofbirth_7}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
    }

    // Business step: I create a new client
    public async Task CreateANewClientAsync()
    {
        // CLEQCommonCreateNewClient_d32265Page.CreateNewClient_0031_503012Async
        await _ui.WaitAsync(_locators.ExistingClientMatch, "Exists");
        await _ui.ClickAsync(_locators.CreateNewClient1);
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:TAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "Tab");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.SetStateNameBuffer_0032_503012Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
    }

    // Business step: I enter client search information
    public async Task EnterClientSearchInformationAsync2()
    {
        // EQCommonEnterClientSearchInfo_116bf9Page.SetBufferForLastName_0029_656be2Async
        _data.Set("LastName", _data.Random("LastName", "Smoke[a-z]{4}"));
        _data.Set("FirstName", _data.Random("FirstName", "SFP [a-z]{3}"));
        // EQCommonEnterClientSearchInfo_116bf9Page.ClientInfo_0030_656be2Async
        await _ui.WaitAsync(_locators.ClientInfo, "Visible");
        await _ui.WaitAsync(_locators.NewExistingClientSearch, "Visible");
        await _ui.FillAsync(_locators.CustomerNameFirst, _data.Resolve("{{runtime:FirstName}}"));
        await _ui.FillAsync(_locators.CustomerNameLast, _data.Resolve("{{runtime:LastName}}"));
        await _ui.FillAsync(_locators.CustomerDateOfBirth, _data.Resolve("{{data:customer_dateofbirth_7}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
    }

    // Business step: I create a new client
    public async Task CreateANewClientAsync2()
    {
        // CLEQCommonCreateNewClient_d32265Page.CreateNewClient_0031_656be2Async
        await _ui.WaitAsync(_locators.ExistingClientMatch, "Exists");
        await _ui.ClickAsync(_locators.CreateNewClient1);
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:TAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "Tab");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.SetStateNameBuffer_0032_656be2Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
    }

    // Business step: I enter client search information
    public async Task EnterClientSearchInformationAsync3()
    {
        // EQCommonEnterClientSearchInfo_116bf9Page.SetBufferForLastName_0029_d18a3eAsync
        _data.Set("LastName", _data.Random("LastName", "BASIC[A-Z]{4}"));
        _data.Set("FirstName", _data.Random("FirstName", "BOP[a-z]{3}"));
        // EQCommonEnterClientSearchInfo_116bf9Page.ClientInfo_0030_d18a3eAsync
        await _ui.WaitAsync(_locators.ClientInfo, "Visible");
        await _ui.WaitAsync(_locators.NewExistingClientSearch, "Visible");
        await _ui.FillAsync(_locators.CustomerNameFirst, _data.Resolve("{{runtime:FirstName}}"));
        await _ui.FillAsync(_locators.CustomerNameLast, _data.Resolve("{{runtime:LastName}}"));
        await _ui.FillAsync(_locators.CustomerDateOfBirth, _data.Resolve("{{data:customer_dateofbirth_7}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
    }

    // Business step: I create a new client
    public async Task CreateANewClientAsync3()
    {
        // CLEQCommonCreateNewClient_d32265Page.CreateNewClient_0031_d18a3eAsync
        await _ui.WaitAsync(_locators.ExistingClientMatch, "Exists");
        await _ui.ClickAsync(_locators.CreateNewClient1);
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:TAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "Tab");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.SetStateNameBuffer_0032_d18a3eAsync
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
    }

    // Business step: I create a new client and begin the quote
    public async Task CreateANewClientAndBeginTheQuoteAsync()
    {
        // Common_7de90aPage.BeginQuoteAndCreateANewClient_00280031_8fa692Async
        await _ui.VerifyAsync(_locators.NewQuote, _data.Resolve("Visible"), "");
        await _ui.ClickAsync(_locators.NewQuote);
        _data.Set("FirstName", _data.Random("FirstName", "BOP [a-z]{3}"));
        _data.Set("LastName", _data.Random("LastName", "Smoke[a-z]{4}"));
        await _ui.VerifyAsync(_locators.ClientInfo, _data.Resolve("Visible"), "");
        await _ui.FillAsync(_locators.CustomerNameFirst, _data.Resolve("{{runtime:FirstName}}"));
        await _ui.FillAsync(_locators.CustomerNameLast, _data.Resolve("{{runtime:LastName}}"));
        await _ui.FillAsync(_locators.CustomerDateOfBirth, _data.Resolve("{{data:customer_dateofbirth}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        await _ui.VerifyAsync(_locators.ExistingClientMatch, _data.Resolve("Exists"), "");
        await _ui.ClickAsync(_locators.CreateNewClient);
        await _ui.ClickAsync(_locators.AdditionalInterestsNext);
    }

    // Business step: I enter client search information
    public async Task EnterClientSearchInformationAsync4()
    {
        // EQCommonEnterClientSearchInfo_116bf9Page.SetBufferForLastName_0029_08f3f1Async
        _data.Set("LastName", _data.Random("LastName", "FETT[A-Z]{4}"));
        _data.Set("FirstName", _data.Random("FirstName", "SFP[A-Z]{3}"));
        // EQCommonEnterClientSearchInfo_116bf9Page.ClientInfo_0030_08f3f1Async
        await _ui.WaitAsync(_locators.ClientInfo, "Visible");
        await _ui.WaitAsync(_locators.NewExistingClientSearch, "Visible");
        await _ui.FillAsync(_locators.CustomerNameFirst, _data.Resolve("{{runtime:FirstName}}"));
        await _ui.FillAsync(_locators.CustomerNameLast, _data.Resolve("{{runtime:LastName}}"));
        await _ui.FillAsync(_locators.CustomerDateOfBirth, _data.Resolve("{{data:customer_dateofbirth_7}}"));
        await _ui.ClickAsync(_locators.ClientInfoSearch);
    }

    // Business step: I create a new client
    public async Task CreateANewClientAsync4()
    {
        // CLEQCommonCreateNewClient_d32265Page.CreateNewClient_0031_08f3f1Async
        await _ui.WaitAsync(_locators.ExistingClientMatch, "Exists");
        await _ui.ClickAsync(_locators.CreateNewClient1);
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:TAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "Tab");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.SetStateNameBuffer_0032_08f3f1Async
        _data.Set("StateName", _data.Resolve("{{data:statename}}"));
    }

}