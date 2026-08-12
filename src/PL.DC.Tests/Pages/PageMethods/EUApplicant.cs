using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EUApplicant
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EUApplicant(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BypassLevel9BRules => EUApplicantLocators.BypassLevel9BRules(_page);

    public Task PressBypassLevel9BRulesAsync(string key) => BypassLevel9BRules.PressAsync(key);

    public Task DoubleClickBypassLevel9BRulesAsync() => BypassLevel9BRules.DblClickAsync();

    public Task SetBypassLevel9BRulesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BypassLevel9BRules, _data.Resolve(value));

    public Task TypeBypassLevel9BRulesAsync(string value, float delayMs = 40) =>
        BypassLevel9BRules.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BypassLevel9BRulesComments => EUApplicantLocators.BypassLevel9BRulesComments(_page);

    public Task PressBypassLevel9BRulesCommentsAsync(string key) => BypassLevel9BRulesComments.PressAsync(key);

    public Task DoubleClickBypassLevel9BRulesCommentsAsync() => BypassLevel9BRulesComments.DblClickAsync();

    public Task SetBypassLevel9BRulesCommentsAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BypassLevel9BRulesComments, _data.Resolve(value));

    public Task TypeBypassLevel9BRulesCommentsAsync(string value, float delayMs = 40) =>
        BypassLevel9BRulesComments.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Home => EUApplicantLocators.Home(_page);

    public Task PressHomeAsync(string key) => Home.PressAsync(key);

    public Task DoubleClickHomeAsync() => Home.DblClickAsync();

    public Task ClickHomeAsync() => Home.ClickAsync();

    private ILocator LnkPricing => EUApplicantLocators.LnkPricing(_page);

    public Task PressLnkPricingAsync(string key) => LnkPricing.PressAsync(key);

    public Task DoubleClickLnkPricingAsync() => LnkPricing.DblClickAsync();

    public Task ClickLnkPricingAsync() => LnkPricing.ClickAsync();

}
