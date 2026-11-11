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

    public Task ClickDiscountsAdjustmentsNavAsync() =>
        _ui.ClickAsync(_locators.DiscountsAdjustmentsNav, new ControlIntent("Discounts", "DiscountsAdjustmentsNav"));

    public Task WaitForDiscountsAdjustmentsHeaderAsync(string expected) =>
        _ui.WaitAsync(_locators.DiscountsAdjustmentsHeader, expected, new ControlIntent("Discounts", "DiscountsAdjustmentsHeader"));

public Task VerifyLoadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.Loading, expected, property, new ControlIntent("Discounts", "Loading"));

    public Task<bool> IsLoadingPresentAsync() =>
        _ui.ExistsAsync(_locators.Loading);

    public Task VerifyMultiCarDiscountAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CommercialAuto, expected, property, new ControlIntent("Discounts", "MultiCarDiscount"));

    public Task ClickN1500030000Async() =>
        _ui.ClickAsync(_locators.N1500030000, new ControlIntent("Discounts", "N1500030000"));

    public Task<bool> IsGreaterThan25000050000AndLessThan100000300000PresentAsync() =>
        _ui.ExistsAsync(_locators.GreaterThan25000050000AndLessThan100000300000);

    public Task ClickGreaterThan25000050000AndLessThan100000300000Async() =>
        _ui.ClickAsync(_locators.GreaterThan25000050000AndLessThan100000300000, new ControlIntent("Discounts", "GreaterThan25000050000AndLessThan100000300000"));

    public Task<bool> IsNotResidentialPropertyOwnerPresentAsync() =>
        _ui.ExistsAsync(_locators.NotResidentialPropertyOwner);

    public Task ClickNotResidentialPropertyOwnerAsync() =>
        _ui.ClickAsync(_locators.NotResidentialPropertyOwner, new ControlIntent("Discounts", "NotResidentialPropertyOwner"));

    public Task SelectNoDefensiveDriverDiscountAsync(string value) =>
        _ui.SelectAsync(_locators.NoDefensiveDriver, value, new ControlIntent("Discounts", "NoDefensiveDriverDiscount"));

    public Task<bool> IsDefensiveDriverCourseBasicPresentAsync() =>
        _ui.ExistsAsync(_locators.DefensiveDriverCourseBasic);

    public Task ClickDefensiveDriverCourseBasicAsync() =>
        _ui.ClickAsync(_locators.DefensiveDriverCourseBasic, new ControlIntent("Discounts", "DefensiveDriverCourseBasic"));

    public Task SetOnAsync(string value) =>
        _ui.SmartSetAsync(_locators.On, value, new ControlIntent("Discounts", "On"));

    public Task ClickSetOnAsync() =>
        _locators.On.EvaluateAsync("el => el.click()");

    public Task<bool> IsAutoHomeDiscountOnPresentAsync() =>
        _ui.ExistsAsync(_locators.AutoHomeDiscountOn);

    public Task ClickAutoHomeDiscountOnAsync() =>
        _ui.ClickAsync(_locators.AutoHomeDiscountOn, new ControlIntent("Discounts", "AutoHomeDiscountOn"));

    public Task PressResidentiaProperty1Async(string key) =>
        _ui.PressAsync(_locators.ResidentiaProperty1, key, new ControlIntent("Discounts", "ResidentiaProperty1"));

    public Task ClickResidentiaProperty1Async() =>
        _ui.ClickAsync(_locators.ResidentiaProperty1, new ControlIntent("Discounts", "ResidentiaProperty1"));

    public Task ClickRBodyInjurelessthanor30k60kAsync() =>
        _ui.ClickAsync(_locators.LessThanOrEqualTo30k60k, new ControlIntent("Discounts", "LessThan30k60k"));

    public Task ClickRiderGroupDiscountAsync() =>
        _ui.ClickAsync(_locators.RiderGroupDiscount, new ControlIntent("Discounts", "RiderGroupDiscount"));

    public Task<bool> IsRiderGroupDiscountPresentAsync() =>
        _ui.ExistsAsync(_locators.RiderGroupDiscount);

    public Task ClickSafeCycleDiscountAsync() =>
        _ui.ClickAsync(_locators.SafeCycleDiscountYes, new ControlIntent("Discounts", "SafeCycleDiscount"));

    public Task EnterSafeCycleDiscountDateAsync(string value) =>
        _ui.FillAsync(_locators.SafeCycleDiscountDate, value, new ControlIntent("Discounts", "SafeCycleDiscountDate"));

    public Task<bool> IsSafeCycleDiscountDatePresentAsync() =>
        _ui.ExistsAsync(_locators.SafeCycleDiscountDate);

    public Task VerifySpecialFarmPackageAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.CommercialAuto, expected, property, new ControlIntent("Discounts", "SpecialFarmPackage"));

    public Task ClickStateMDAsync() =>
        _ui.ClickAsync(_locators.StateMD, new ControlIntent("Discounts", "StateMD"));

    public Task<bool> IsStateMDPresentAsync() =>
        _ui.ExistsAsync(_locators.StateMD);

    public Task<bool> IsOnPresentAsync() =>
        _ui.ExistsAsync(_locators.On);

    public Task SetCommercialAutoOverrideOnAsync(string value) =>
        _ui.SmartSetAsync(_locators.CommercialAutoOverride, value, new ControlIntent("Discounts", "CommercialAutoOverride"));

    public Task ClickCommercialAutoOverrideOnAsync() =>
        _ui.ClickAsync(_locators.CommercialAutoOverride, new ControlIntent("Discounts", "CommercialAutoOverride"));

    public Task<bool> IsCommercialAutoOverridePresentAsync() =>
        _ui.ExistsAsync(_locators.CommercialAutoOverride);

    public Task SetSpecialFarmPackageOverrideOnAsync(string value) =>
        _ui.SmartSetAsync(_locators.SpecialFarmPackageOverride, value, new ControlIntent("Discounts", "SpecialFarmPackageOverride"));
    public Task ClickSpecialFarmPackageOverrideOnAsync() =>
        _ui.ClickAsync(_locators.SpecialFarmPackageOverride, new ControlIntent("Discounts", "SpecialFarmPackageOverride"));

    public Task<bool> IsSpecialFarmPackageOverridePresentAsync() =>
        _ui.ExistsAsync(_locators.SpecialFarmPackageOverride);

}
