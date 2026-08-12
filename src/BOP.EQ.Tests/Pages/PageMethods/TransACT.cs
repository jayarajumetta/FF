using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class TransACT
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public TransACT(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator RootElement => TransACTLocators.TransACT(_page);

    public Task PressTransACTAsync(string key) => RootElement.PressAsync(key);

    public Task DoubleClickTransACTAsync() => RootElement.DblClickAsync();

    public Task VerifyTransACTAsync(string expected) =>
        Expect(RootElement).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForTransACTAsync() =>
        RootElement.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PolicyStatus => TransACTLocators.PolicyStatus(_page);

    public Task PressPolicyStatusAsync(string key) => PolicyStatus.PressAsync(key);

    public Task DoubleClickPolicyStatusAsync() => PolicyStatus.DblClickAsync();

    public Task VerifyPolicyStatusAsync(string expected) =>
        Expect(PolicyStatus).ToContainTextAsync(_data.Resolve(expected));

    private ILocator TransactionType => TransACTLocators.TransactionType(_page);

    public Task PressTransactionTypeAsync(string key) => TransactionType.PressAsync(key);

    public Task DoubleClickTransactionTypeAsync() => TransactionType.DblClickAsync();

    public Task SetTransactionTypeAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TransactionType, _data.Resolve(value));

    public Task TypeTransactionTypeAsync(string value, float delayMs = 40) =>
        TransactionType.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task WaitForTransactionTypeAsync() =>
        TransactionType.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    public async Task StoreTransactionTypeAsync(string key)
    {
        var value = await TransactionType.TextContentAsync() ?? await TransactionType.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator ViewPolicy => TransACTLocators.ViewPolicy(_page);

    public Task PressViewPolicyAsync(string key) => ViewPolicy.PressAsync(key);

    public Task DoubleClickViewPolicyAsync() => ViewPolicy.DblClickAsync();

    public Task ClickViewPolicyAsync() => ViewPolicy.ClickAsync();

    private ILocator Go => TransACTLocators.Go(_page);

    public Task PressGoAsync(string key) => Go.PressAsync(key);

    public Task DoubleClickGoAsync() => Go.DblClickAsync();

    public Task ClickGoAsync() => Go.ClickAsync();

    private ILocator QuickFilterList => TransACTLocators.QuickFilterList(_page);

    public Task PressQuickFilterListAsync(string key) => QuickFilterList.PressAsync(key);

    public Task DoubleClickQuickFilterListAsync() => QuickFilterList.DblClickAsync();

    public Task SetQuickFilterListAsync(string value) =>
        UiActions.ApplyInputAsync(_page, QuickFilterList, _data.Resolve(value));

    public Task TypeQuickFilterListAsync(string value, float delayMs = 40) =>
        QuickFilterList.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Policy => TransACTLocators.Policy(_page);

    public Task PressPolicyAsync(string key) => Policy.PressAsync(key);

    public Task DoubleClickPolicyAsync() => Policy.DblClickAsync();

    public async Task StorePolicyAsync(string key)
    {
        var value = await Policy.TextContentAsync() ?? await Policy.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    public Task ClickQuickFilterListAsync() => QuickFilterList.ClickAsync();
}
