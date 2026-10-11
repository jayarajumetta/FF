using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class DiscountsPage
{
    private readonly BrowserSession _browser;
    private readonly DiscountsLocators _locators;
    private readonly UiActions _ui;

    public DiscountsPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new DiscountsLocators(browser.Page);
        _ui = ui;
    }

    public Task EnterAccountCreditAsync(string value) =>
        _ui.FillAsync(_locators.AccountCredit, value, new ControlIntent("Discounts", "AccountCredit"));

    public Task PressAccountCreditAsync(string key) =>
        _ui.PressAsync(_locators.AccountCredit, key, new ControlIntent("Discounts", "AccountCredit"));

    public Task WaitForBAPSpecificFieldsOKAsync(string expected) =>
        _ui.WaitAsync(_locators.BAPSpecificFieldsOK, expected, new ControlIntent("Discounts", "BAPSpecificFieldsOK"));

    public Task VerifyBAPSpecificFieldsOKAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.BAPSpecificFieldsOK, expected, property, new ControlIntent("Discounts", "BAPSpecificFieldsOK"));

    public Task ClickBAPSpecificFieldsOKAsync() =>
        _ui.ClickAsync(_locators.BAPSpecificFieldsOK, new ControlIntent("Discounts", "BAPSpecificFieldsOK"));

    public Task EnterNAICSCodeSearchResultsAsync(string value) =>
        _ui.FillAsync(_locators.NAICSCodeSearchResults, value, new ControlIntent("Discounts", "NAICSCodeSearchResults"));

    public Task PressNAICSCodeSearchResultsAsync(string key) =>
        _ui.PressAsync(_locators.NAICSCodeSearchResults, key, new ControlIntent("Discounts", "NAICSCodeSearchResults"));

    public Task EnterNAICSCodeSearchValueAsync(string value) =>
        _ui.FillAsync(_locators.NAICSCodeSearchValue, value, new ControlIntent("Discounts", "NAICSCodeSearchValue"));

    public Task PressNAICSCodeSearchValueAsync(string key) =>
        _ui.PressAsync(_locators.NAICSCodeSearchValue, key, new ControlIntent("Discounts", "NAICSCodeSearchValue"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);


    public Task EnterAccountCreditSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.AccountCredit, value, new ControlIntent("Discounts", "AccountCredit"), delayMs);

    public Task EnterNAICSCodeSearchResultsSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NAICSCodeSearchResults, value, new ControlIntent("Discounts", "NAICSCodeSearchResults"), delayMs);

    public Task EnterNAICSCodeSearchValueSequentiallyAsync(string value, int delayMs = 20) =>
        _ui.PressSequentiallyAsync(_locators.NAICSCodeSearchValue, value, new ControlIntent("Discounts", "NAICSCodeSearchValue"), delayMs);
}
