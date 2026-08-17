using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class AccountInformationPage
{
    private readonly AccountInformationLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public AccountInformationPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new AccountInformationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync()
    {
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0033_503012Async
        await _ui.WaitAsync(_locators.AccountInformationHeader, "Visible");
        await _ui.PressAsync(_locators.OwnerMiddleName, "POST:ENTER");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Enter");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Tab");
        _data.Set("OwnerPhone", _data.Random("OwnerPhone", "3[0-9]{9}"));
        _data.Set("OwnerEmail", _data.Random("OwnerEmail", "test@[a-z]{4}\\.com"));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsSelectMarried_0034_503012Async
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0035_503012Async
        await _ui.PressAsync(_locators.StreetAddress, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.StreetAddress, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0036_503012Async
        await _ui.PressAsync(_locators.StreetAddress, "POST:ENTER");
        await _ui.PressAsync(_locators.StreetAddress, "Enter");
        await _ui.PressAsync(_locators.StreetAddress, "Tab");
        await _ui.PressAsync(_locators.Address2, "POST:ENTER");
        await _ui.PressAsync(_locators.Address2, "Enter");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.City, "POST:ENTER");
        await _ui.PressAsync(_locators.City, "Enter");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.SelectAsync(_locators.State0110E, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.Zip, "POST:ENTER");
        await _ui.PressAsync(_locators.Zip, "Enter");
        await _ui.PressAsync(_locators.Zip, "Tab");
        await _ui.WaitAsync(_locators.Map, "Exists");
        await _ui.WaitAsync(_locators.Satellite, "Exists");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0037_503012Async
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0038_503012Async
        await _ui.SelectAsync(_locators.HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes, _data.Resolve(""));
        await _ui.SelectAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResidesYes, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AdditionalInterestsNext);
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync2()
    {
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0033_656be2Async
        await _ui.WaitAsync(_locators.AccountInformationHeader, "Visible");
        await _ui.PressAsync(_locators.OwnerMiddleName, "POST:TAB");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Tab");
        _data.Set("OwnerPhone", _data.Random("OwnerPhone", "3[0-9]{9}"));
        _data.Set("OwnerEmail", _data.Random("OwnerEmail", "test@[a-z]{4}\\.com"));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsSelectMarried_0034_656be2Async
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0035_656be2Async
        await _ui.PressAsync(_locators.StreetAddress, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.StreetAddress, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0036_656be2Async
        await _ui.PressAsync(_locators.StreetAddress, "POST:ENTER");
        await _ui.PressAsync(_locators.StreetAddress, "Enter");
        await _ui.PressAsync(_locators.StreetAddress, "Tab");
        await _ui.PressAsync(_locators.Address2, "POST:ENTER");
        await _ui.PressAsync(_locators.Address2, "Enter");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.City, "POST:ENTER");
        await _ui.PressAsync(_locators.City, "Enter");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.SelectAsync(_locators.State0110E, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.Zip, "POST:ENTER");
        await _ui.PressAsync(_locators.Zip, "Enter");
        await _ui.PressAsync(_locators.Zip, "Tab");
        await _ui.WaitAsync(_locators.Map, "Exists");
        await _ui.WaitAsync(_locators.Satellite, "Exists");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0037_656be2Async
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0038_656be2Async
        await _ui.SelectAsync(_locators.HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes, _data.Resolve(""));
        await _ui.SelectAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResidesYes, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AdditionalInterestsNext);
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync3()
    {
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0033_d18a3eAsync
        await _ui.WaitAsync(_locators.AccountInformationHeader, "Visible");
        await _ui.PressAsync(_locators.OwnerMiddleName, "POST:ENTER");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Enter");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Tab");
        _data.Set("OwnerPhone", _data.Random("OwnerPhone", "3[0-9]{9}"));
        _data.Set("OwnerEmail", _data.Random("OwnerEmail", "test@[a-z]{4}\\.com"));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsSelectMarried_0034_d18a3eAsync
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0035_d18a3eAsync
        await _ui.PressAsync(_locators.StreetAddress, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.StreetAddress, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0036_d18a3eAsync
        await _ui.PressAsync(_locators.StreetAddress, "POST:ENTER");
        await _ui.PressAsync(_locators.StreetAddress, "Enter");
        await _ui.PressAsync(_locators.StreetAddress, "Tab");
        await _ui.PressAsync(_locators.Address2, "POST:TAB");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.City, "POST:ENTER");
        await _ui.PressAsync(_locators.City, "Enter");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.SelectAsync(_locators.State0110E, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.Zip, "POST:ENTER");
        await _ui.PressAsync(_locators.Zip, "Enter");
        await _ui.PressAsync(_locators.Zip, "Tab");
        await _ui.WaitAsync(_locators.Map, "Exists");
        await _ui.WaitAsync(_locators.Satellite, "Exists");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0037_d18a3eAsync
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0038_d18a3eAsync
        await _ui.SelectAsync(_locators.HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes, _data.Resolve(""));
        await _ui.SelectAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResidesYes, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AdditionalInterestsNext);
    }

    // Business step: I enter the client account and address information
    public async Task EnterTheClientAccountAndAddressInformationAsync()
    {
        // Common_7de90aPage.AccountInformationAndAddress_00320038_8fa692Async
        await _ui.VerifyAsync(_locators.AccountInformation, _data.Resolve("Visible"), "");
        await _ui.FillAsync(_locators.OwnerMiddleName, _data.Resolve(""));
        _data.Set("OwnerPhone", _data.Random("OwnerPhone", "3[0-9]{9}"));
        _data.Set("OwnerEmail", _data.Random("OwnerEmail", "test@[a-z]{4}.com"));
        await _ui.ClickAsync(_locators.Married);
        await _ui.VerifyAsync(_locators.Map, _data.Resolve("Exists"), "");
        await _ui.VerifyAsync(_locators.Satellite, _data.Resolve("Exists"), "");
        await _ui.ClickAsync(_locators.Yes);
        await _ui.ClickAsync(_locators.Yes);
        await _ui.ClickAsync(_locators.AdditionalInterestsNext);
        // Common_7de90aPage.AccountInformationAndAddress_0032003801_8fa692Async
        await _ui.FillAsync(_locators.StreetAddress, _data.Resolve("{{data:street_address_18}}"));
        // Common_7de90aPage.AccountInformationAndAddress_0032003802_8fa692Async
        await _ui.FillAsync(_locators.Address2, _data.Resolve(""));
        // Common_7de90aPage.AccountInformationAndAddress_0032003803_8fa692Async
        await _ui.FillAsync(_locators.City, _data.Resolve("{{data:city_20}}"));
        // Common_7de90aPage.AccountInformationAndAddress_0032003804_8fa692Async
        await _ui.FillAsync(_locators.StateAE19A, _data.Resolve("{{data:state_21}}"));
        // Common_7de90aPage.AccountInformationAndAddress_0032003805_8fa692Async
        await _ui.FillAsync(_locators.Zip, _data.Resolve("{{data:zip_22}}"));
    }

    // Business step: I enter account details
    public async Task EnterAccountDetailsAsync4()
    {
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0033_08f3f1Async
        await _ui.WaitAsync(_locators.AccountInformationHeader, "Visible");
        await _ui.PressAsync(_locators.OwnerMiddleName, "POST:ENTER");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Enter");
        await _ui.PressAsync(_locators.OwnerMiddleName, "Tab");
        _data.Set("OwnerPhone", _data.Random("OwnerPhone", "3[0-9]{9}"));
        _data.Set("OwnerEmail", _data.Random("OwnerEmail", "test@[a-z]{4}\\.com"));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsSelectMarried_0034_08f3f1Async
        await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0035_08f3f1Async
        await _ui.PressAsync(_locators.StreetAddress, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.StreetAddress, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0036_08f3f1Async
        await _ui.PressAsync(_locators.StreetAddress, "POST:ENTER");
        await _ui.PressAsync(_locators.StreetAddress, "Enter");
        await _ui.PressAsync(_locators.StreetAddress, "Tab");
        await _ui.PressAsync(_locators.Address2, "POST:ENTER");
        await _ui.PressAsync(_locators.Address2, "Enter");
        await _ui.PressAsync(_locators.Address2, "Tab");
        await _ui.PressAsync(_locators.City, "POST:ENTER");
        await _ui.PressAsync(_locators.City, "Enter");
        await _ui.PressAsync(_locators.City, "Tab");
        await _ui.ClickAsync(_locators.StateDropdown);
        await _ui.SelectAsync(_locators.State0110E, _data.Resolve("{{runtime:StateName}}"));
        await _ui.PressAsync(_locators.Zip, "POST:ENTER");
        await _ui.PressAsync(_locators.Zip, "Enter");
        await _ui.PressAsync(_locators.Zip, "Tab");
        await _ui.WaitAsync(_locators.Map, "Exists");
        await _ui.WaitAsync(_locators.Satellite, "Exists");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.NavigateDownTheScreen_0037_08f3f1Async
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "POST:SHIFTTAB");
        await _ui.PressAsync(_locators.AdditionalInterestsNext, "SHIFTTAB");
        // EQCommonEnterAccountDetailsAccountInfo_a911afPage.AccountDetailsAccountInfo_0038_08f3f1Async
        await _ui.SelectAsync(_locators.HaveYouReceivedMailAtThisAddressForAtLeast90DaysYes, _data.Resolve(""));
        await _ui.SelectAsync(_locators.IsTheAccountAddressAlsoWhereTheClientResidesYes, _data.Resolve(""));
        await _ui.ClickAsync(_locators.AdditionalInterestsNext);
    }

}