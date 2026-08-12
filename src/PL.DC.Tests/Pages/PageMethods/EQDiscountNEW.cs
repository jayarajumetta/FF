using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQDiscountNEW
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQDiscountNEW(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator MultiCarDiscount => EQDiscountNEWLocators.MultiCarDiscount(_page);

    public Task PressMultiCarDiscountAsync(string key) => MultiCarDiscount.PressAsync(key);

    public Task DoubleClickMultiCarDiscountAsync() => MultiCarDiscount.DblClickAsync();

    public Task VerifyMultiCarDiscountAsync(string expected) =>
        Expect(MultiCarDiscount).ToContainTextAsync(_data.Resolve(expected));

    private ILocator RiderGroupDiscount => EQDiscountNEWLocators.RiderGroupDiscount(_page);

    public Task PressRiderGroupDiscountAsync(string key) => RiderGroupDiscount.PressAsync(key);

    public Task DoubleClickRiderGroupDiscountAsync() => RiderGroupDiscount.DblClickAsync();

    public Task ClickRiderGroupDiscountAsync() => RiderGroupDiscount.ClickAsync();

    private ILocator CommercialAuto => EQDiscountNEWLocators.CommercialAuto(_page);

    public Task PressCommercialAutoAsync(string key) => CommercialAuto.PressAsync(key);

    public Task DoubleClickCommercialAutoAsync() => CommercialAuto.DblClickAsync();

    public Task VerifyCommercialAutoAsync(string expected) =>
        Expect(CommercialAuto).ToContainTextAsync(_data.Resolve(expected));

    private ILocator SpecialFarmPackage => EQDiscountNEWLocators.SpecialFarmPackage(_page);

    public Task PressSpecialFarmPackageAsync(string key) => SpecialFarmPackage.PressAsync(key);

    public Task DoubleClickSpecialFarmPackageAsync() => SpecialFarmPackage.DblClickAsync();

    public Task VerifySpecialFarmPackageAsync(string expected) =>
        Expect(SpecialFarmPackage).ToContainTextAsync(_data.Resolve(expected));

    private ILocator SafeCycleDiscount => EQDiscountNEWLocators.SafeCycleDiscount(_page);

    public Task PressSafeCycleDiscountAsync(string key) => SafeCycleDiscount.PressAsync(key);

    public Task DoubleClickSafeCycleDiscountAsync() => SafeCycleDiscount.DblClickAsync();

    public Task ClickSafeCycleDiscountAsync() => SafeCycleDiscount.ClickAsync();

    private ILocator SafeCycleDiscountDate => EQDiscountNEWLocators.SafeCycleDiscountDate(_page);

    public Task PressSafeCycleDiscountDateAsync(string key) => SafeCycleDiscountDate.PressAsync(key);

    public Task DoubleClickSafeCycleDiscountDateAsync() => SafeCycleDiscountDate.DblClickAsync();

    public Task SetSafeCycleDiscountDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SafeCycleDiscountDate, _data.Resolve(value));

    public Task TypeSafeCycleDiscountDateAsync(string value, float delayMs = 40) =>
        SafeCycleDiscountDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator NoDefensiveDriverDiscount => EQDiscountNEWLocators.NoDefensiveDriverDiscount(_page);

    public Task PressNoDefensiveDriverDiscountAsync(string key) => NoDefensiveDriverDiscount.PressAsync(key);

    public Task DoubleClickNoDefensiveDriverDiscountAsync() => NoDefensiveDriverDiscount.DblClickAsync();

    public Task ClickNoDefensiveDriverDiscountAsync() => NoDefensiveDriverDiscount.ClickAsync();

    private ILocator Next => EQDiscountNEWLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

    public Task WaitForNextAsync() =>
        Next.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
