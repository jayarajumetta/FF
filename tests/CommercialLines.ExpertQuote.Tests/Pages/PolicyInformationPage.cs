using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class PolicyInformationPage
{
    private readonly BrowserSession _browser;
    private readonly PolicyInformationLocators _locators;
    private readonly UiActions _ui;

    public PolicyInformationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new PolicyInformationLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickAddSecondaryFarmTypeToggleAsync() =>
        _ui.ClickAsync(_locators.AddSecondaryFarmTypeToggle, new ControlIntent("PolicyInformation", "AddSecondaryFarmTypeToggle"));

    public Task EnterGrossFarmIncomeAsync(string value) =>
        _ui.FillAsync(_locators.GrossFarmIncome, value, new ControlIntent("PolicyInformation", "GrossFarmIncome"));

    public Task SelectIndustrialHempNoAsync(string value) =>
        _ui.SelectAsync(_locators.IndustrialHempNo, value, new ControlIntent("PolicyInformation", "IndustrialHempNo"));

    public Task SelectIndustrialHempYesAsync(string value) =>
        _ui.SelectAsync(_locators.IndustrialHempNo, value, new ControlIntent("PolicyInformation", "IndustrialHempYes"));
public Task ClickPrimaryFarmCategoryAsync() =>
        _ui.ClickAsync(_locators.PrimaryFarmCategory, new ControlIntent("PolicyInformation", "PrimaryFarmCategory"));

    public Task WaitForPrimaryFarmTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.PrimaryFarmType, expected, new ControlIntent("PolicyInformation", "PrimaryFarmType"));

    public Task ClickPrimaryFarmTypeAsync() =>
        _ui.ClickAsync(_locators.PrimaryFarmType, new ControlIntent("PolicyInformation", "PrimaryFarmType"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoPrefillMatchFound, expected, property, new ControlIntent("PolicyInformation", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.NoPrefillMatchFound);

    public Task WaitForSecondaryFarmCategoryAsync(string expected) =>
        _ui.WaitAsync(_locators.SecondaryFarmCategory, expected, new ControlIntent("PolicyInformation", "SecondaryFarmCategory"));

    public Task ClickSecondaryFarmCategoryAsync() =>
        _ui.ClickAsync(_locators.SecondaryFarmCategory, new ControlIntent("PolicyInformation", "SecondaryFarmCategory"));

    public Task WaitForSecondaryFarmTypeAsync(string expected) =>
        _ui.WaitAsync(_locators.SecondaryFarmType, expected, new ControlIntent("PolicyInformation", "SecondaryFarmType"));

    public Task ClickSecondaryFarmTypeAsync() =>
        _ui.ClickAsync(_locators.SecondaryFarmType, new ControlIntent("PolicyInformation", "SecondaryFarmType"));

}
