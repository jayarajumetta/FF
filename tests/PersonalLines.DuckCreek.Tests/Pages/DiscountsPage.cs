using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

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

    public Task VerifyCommercialAutoAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CommercialAuto, expected, property, new ControlIntent("Discounts", "CommercialAuto"));

    public Task WaitForDiscountNEWNextAsync(string expected) =>
        _ui.WaitAsync(_locators.DiscountNEWNext, expected, new ControlIntent("Discounts", "DiscountNEWNext"));

    public Task ClickDiscountNEWNextAsync() =>
        _ui.ClickAsync(_locators.DiscountNEWNext, new ControlIntent("Discounts", "DiscountNEWNext"));
public Task VerifyLoadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Loading, expected, property, new ControlIntent("Discounts", "Loading"));

    public Task<bool> IsLoadingPresentAsync() =>
        _ui.ExistsAsync(_locators.Loading);

    public Task VerifyMultiCarDiscountAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CommercialAuto, expected, property, new ControlIntent("Discounts", "MultiCarDiscount"));

    public Task ClickN1500030000Async() =>
        _ui.ClickAsync(_locators.N1500030000, new ControlIntent("Discounts", "N1500030000"));

    public Task SelectNoDefensiveDriverDiscountAsync(string value) =>
        _ui.SelectAsync(_locators.CommercialAuto, value, new ControlIntent("Discounts", "NoDefensiveDriverDiscount"));

    public Task SetOnAsync(string value) =>
        _ui.SmartSetAsync(_locators.On, value, new ControlIntent("Discounts", "On"));

    public Task PressResidentiaProperty1Async(string key) =>
        _ui.PressAsync(_locators.ResidentiaProperty1, key, new ControlIntent("Discounts", "ResidentiaProperty1"));

    public Task ClickResidentiaProperty1Async() =>
        _ui.ClickAsync(_locators.ResidentiaProperty1, new ControlIntent("Discounts", "ResidentiaProperty1"));

    public Task ClickRiderGroupDiscountAsync() =>
        _ui.ClickAsync(_locators.RiderGroupDiscount, new ControlIntent("Discounts", "RiderGroupDiscount"));

    public Task ClickSafeCycleDiscountAsync() =>
        _ui.ClickAsync(_locators.SafeCycleDiscount, new ControlIntent("Discounts", "SafeCycleDiscount"));

    public Task EnterSafeCycleDiscountDateAsync(string value) =>
        _ui.FillAsync(_locators.SafeCycleDiscountDate, value, new ControlIntent("Discounts", "SafeCycleDiscountDate"));

    public Task VerifySpecialFarmPackageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CommercialAuto, expected, property, new ControlIntent("Discounts", "SpecialFarmPackage"));

    public Task ClickStateMDAsync() =>
        _ui.ClickAsync(_locators.StateMD, new ControlIntent("Discounts", "StateMD"));

    public Task<bool> IsStateMDPresentAsync() =>
        _ui.ExistsAsync(_locators.StateMD);

}
