using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class CoveragesNew
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public CoveragesNew(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator V1CompCollOnlyYES => CoveragesNewLocators.V1CompCollOnlyYES(_page);

    public Task PressV1CompCollOnlyYESAsync(string key) => V1CompCollOnlyYES.PressAsync(key);

    public Task DoubleClickV1CompCollOnlyYESAsync() => V1CompCollOnlyYES.DblClickAsync();

    public Task SetV1CompCollOnlyYESAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V1CompCollOnlyYES, _data.Resolve(value));

    public Task TypeV1CompCollOnlyYESAsync(string value, float delayMs = 40) =>
        V1CompCollOnlyYES.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V1ComprehensiveAndCollisionOnly => CoveragesNewLocators.V1ComprehensiveAndCollisionOnly(_page);

    public Task PressV1ComprehensiveAndCollisionOnlyAsync(string key) => V1ComprehensiveAndCollisionOnly.PressAsync(key);

    public Task DoubleClickV1ComprehensiveAndCollisionOnlyAsync() => V1ComprehensiveAndCollisionOnly.DblClickAsync();

    public Task ClickV1ComprehensiveAndCollisionOnlyAsync() => V1ComprehensiveAndCollisionOnly.ClickAsync();

    private ILocator V1CompDed => CoveragesNewLocators.V1CompDed(_page);

    public Task PressV1CompDedAsync(string key) => V1CompDed.PressAsync(key);

    public Task DoubleClickV1CompDedAsync() => V1CompDed.DblClickAsync();

    public Task SetV1CompDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V1CompDed, _data.Resolve(value));

    public Task TypeV1CompDedAsync(string value, float delayMs = 40) =>
        V1CompDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V1CompDedMoreOpt => CoveragesNewLocators.V1CompDedMoreOpt(_page);

    public Task PressV1CompDedMoreOptAsync(string key) => V1CompDedMoreOpt.PressAsync(key);

    public Task DoubleClickV1CompDedMoreOptAsync() => V1CompDedMoreOpt.DblClickAsync();

    public Task ClickV1CompDedMoreOptAsync() => V1CompDedMoreOpt.ClickAsync();

    private ILocator V1CollDed => CoveragesNewLocators.V1CollDed(_page);

    public Task PressV1CollDedAsync(string key) => V1CollDed.PressAsync(key);

    public Task DoubleClickV1CollDedAsync() => V1CollDed.DblClickAsync();

    public Task SetV1CollDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V1CollDed, _data.Resolve(value));

    public Task TypeV1CollDedAsync(string value, float delayMs = 40) =>
        V1CollDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V1CollDedMoreOpt => CoveragesNewLocators.V1CollDedMoreOpt(_page);

    public Task PressV1CollDedMoreOptAsync(string key) => V1CollDedMoreOpt.PressAsync(key);

    public Task DoubleClickV1CollDedMoreOptAsync() => V1CollDedMoreOpt.DblClickAsync();

    public Task ClickV1CollDedMoreOptAsync() => V1CollDedMoreOpt.ClickAsync();

    private ILocator V2CompCollOnlyYES => CoveragesNewLocators.V2CompCollOnlyYES(_page);

    public Task PressV2CompCollOnlyYESAsync(string key) => V2CompCollOnlyYES.PressAsync(key);

    public Task DoubleClickV2CompCollOnlyYESAsync() => V2CompCollOnlyYES.DblClickAsync();

    public Task SetV2CompCollOnlyYESAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V2CompCollOnlyYES, _data.Resolve(value));

    public Task TypeV2CompCollOnlyYESAsync(string value, float delayMs = 40) =>
        V2CompCollOnlyYES.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V2ComprehensiveAndCollisionOnly => CoveragesNewLocators.V2ComprehensiveAndCollisionOnly(_page);

    public Task PressV2ComprehensiveAndCollisionOnlyAsync(string key) => V2ComprehensiveAndCollisionOnly.PressAsync(key);

    public Task DoubleClickV2ComprehensiveAndCollisionOnlyAsync() => V2ComprehensiveAndCollisionOnly.DblClickAsync();

    public Task ClickV2ComprehensiveAndCollisionOnlyAsync() => V2ComprehensiveAndCollisionOnly.ClickAsync();

    private ILocator V2ComprehensiveDeductible => CoveragesNewLocators.V2ComprehensiveDeductible(_page);

    public Task PressV2ComprehensiveDeductibleAsync(string key) => V2ComprehensiveDeductible.PressAsync(key);

    public Task DoubleClickV2ComprehensiveDeductibleAsync() => V2ComprehensiveDeductible.DblClickAsync();

    public Task VerifyV2ComprehensiveDeductibleAsync(string expected) =>
        Expect(V2ComprehensiveDeductible).ToContainTextAsync(_data.Resolve(expected));

    private ILocator V2CompDed => CoveragesNewLocators.V2CompDed(_page);

    public Task PressV2CompDedAsync(string key) => V2CompDed.PressAsync(key);

    public Task DoubleClickV2CompDedAsync() => V2CompDed.DblClickAsync();

    public Task SetV2CompDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V2CompDed, _data.Resolve(value));

    public Task TypeV2CompDedAsync(string value, float delayMs = 40) =>
        V2CompDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V2CompDedMoreOpt => CoveragesNewLocators.V2CompDedMoreOpt(_page);

    public Task PressV2CompDedMoreOptAsync(string key) => V2CompDedMoreOpt.PressAsync(key);

    public Task DoubleClickV2CompDedMoreOptAsync() => V2CompDedMoreOpt.DblClickAsync();

    public Task ClickV2CompDedMoreOptAsync() => V2CompDedMoreOpt.ClickAsync();

    private ILocator V2CollDed => CoveragesNewLocators.V2CollDed(_page);

    public Task PressV2CollDedAsync(string key) => V2CollDed.PressAsync(key);

    public Task DoubleClickV2CollDedAsync() => V2CollDed.DblClickAsync();

    public Task SetV2CollDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V2CollDed, _data.Resolve(value));

    public Task TypeV2CollDedAsync(string value, float delayMs = 40) =>
        V2CollDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V2CollDedMoreOpt => CoveragesNewLocators.V2CollDedMoreOpt(_page);

    public Task PressV2CollDedMoreOptAsync(string key) => V2CollDedMoreOpt.PressAsync(key);

    public Task DoubleClickV2CollDedMoreOptAsync() => V2CollDedMoreOpt.DblClickAsync();

    public Task ClickV2CollDedMoreOptAsync() => V2CollDedMoreOpt.ClickAsync();

    private ILocator Next => CoveragesNewLocators.Next(_page);

    public Task PressNextAsync(string key) => Next.PressAsync(key);

    public Task DoubleClickNextAsync() => Next.DblClickAsync();

    public Task ClickNextAsync() => Next.ClickAsync();

    private ILocator V3CompCollOnlyYES => CoveragesNewLocators.V3CompCollOnlyYES(_page);

    public Task PressV3CompCollOnlyYESAsync(string key) => V3CompCollOnlyYES.PressAsync(key);

    public Task DoubleClickV3CompCollOnlyYESAsync() => V3CompCollOnlyYES.DblClickAsync();

    public Task SetV3CompCollOnlyYESAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V3CompCollOnlyYES, _data.Resolve(value));

    public Task TypeV3CompCollOnlyYESAsync(string value, float delayMs = 40) =>
        V3CompCollOnlyYES.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V3ComprehensiveAndCollisionOnly => CoveragesNewLocators.V3ComprehensiveAndCollisionOnly(_page);

    public Task PressV3ComprehensiveAndCollisionOnlyAsync(string key) => V3ComprehensiveAndCollisionOnly.PressAsync(key);

    public Task DoubleClickV3ComprehensiveAndCollisionOnlyAsync() => V3ComprehensiveAndCollisionOnly.DblClickAsync();

    public Task ClickV3ComprehensiveAndCollisionOnlyAsync() => V3ComprehensiveAndCollisionOnly.ClickAsync();

    private ILocator V3ComprehensiveDeductible => CoveragesNewLocators.V3ComprehensiveDeductible(_page);

    public Task PressV3ComprehensiveDeductibleAsync(string key) => V3ComprehensiveDeductible.PressAsync(key);

    public Task DoubleClickV3ComprehensiveDeductibleAsync() => V3ComprehensiveDeductible.DblClickAsync();

    public Task VerifyV3ComprehensiveDeductibleAsync(string expected) =>
        Expect(V3ComprehensiveDeductible).ToContainTextAsync(_data.Resolve(expected));

    private ILocator V3CompDed => CoveragesNewLocators.V3CompDed(_page);

    public Task PressV3CompDedAsync(string key) => V3CompDed.PressAsync(key);

    public Task DoubleClickV3CompDedAsync() => V3CompDed.DblClickAsync();

    public Task SetV3CompDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V3CompDed, _data.Resolve(value));

    public Task TypeV3CompDedAsync(string value, float delayMs = 40) =>
        V3CompDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V3CompDedMoreOpt => CoveragesNewLocators.V3CompDedMoreOpt(_page);

    public Task PressV3CompDedMoreOptAsync(string key) => V3CompDedMoreOpt.PressAsync(key);

    public Task DoubleClickV3CompDedMoreOptAsync() => V3CompDedMoreOpt.DblClickAsync();

    public Task ClickV3CompDedMoreOptAsync() => V3CompDedMoreOpt.ClickAsync();

    private ILocator V3CollDed => CoveragesNewLocators.V3CollDed(_page);

    public Task PressV3CollDedAsync(string key) => V3CollDed.PressAsync(key);

    public Task DoubleClickV3CollDedAsync() => V3CollDed.DblClickAsync();

    public Task SetV3CollDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V3CollDed, _data.Resolve(value));

    public Task TypeV3CollDedAsync(string value, float delayMs = 40) =>
        V3CollDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V3CollDedMoreOpt => CoveragesNewLocators.V3CollDedMoreOpt(_page);

    public Task PressV3CollDedMoreOptAsync(string key) => V3CollDedMoreOpt.PressAsync(key);

    public Task DoubleClickV3CollDedMoreOptAsync() => V3CollDedMoreOpt.DblClickAsync();

    public Task ClickV3CollDedMoreOptAsync() => V3CollDedMoreOpt.ClickAsync();

    private ILocator V4CompCollOnlyYES => CoveragesNewLocators.V4CompCollOnlyYES(_page);

    public Task PressV4CompCollOnlyYESAsync(string key) => V4CompCollOnlyYES.PressAsync(key);

    public Task DoubleClickV4CompCollOnlyYESAsync() => V4CompCollOnlyYES.DblClickAsync();

    public Task SetV4CompCollOnlyYESAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V4CompCollOnlyYES, _data.Resolve(value));

    public Task TypeV4CompCollOnlyYESAsync(string value, float delayMs = 40) =>
        V4CompCollOnlyYES.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V4ComprehensiveAndCollisionOnly => CoveragesNewLocators.V4ComprehensiveAndCollisionOnly(_page);

    public Task PressV4ComprehensiveAndCollisionOnlyAsync(string key) => V4ComprehensiveAndCollisionOnly.PressAsync(key);

    public Task DoubleClickV4ComprehensiveAndCollisionOnlyAsync() => V4ComprehensiveAndCollisionOnly.DblClickAsync();

    public Task ClickV4ComprehensiveAndCollisionOnlyAsync() => V4ComprehensiveAndCollisionOnly.ClickAsync();

    private ILocator V4ComprehensiveDeductible => CoveragesNewLocators.V4ComprehensiveDeductible(_page);

    public Task PressV4ComprehensiveDeductibleAsync(string key) => V4ComprehensiveDeductible.PressAsync(key);

    public Task DoubleClickV4ComprehensiveDeductibleAsync() => V4ComprehensiveDeductible.DblClickAsync();

    public Task VerifyV4ComprehensiveDeductibleAsync(string expected) =>
        Expect(V4ComprehensiveDeductible).ToContainTextAsync(_data.Resolve(expected));

    private ILocator V4CompDed => CoveragesNewLocators.V4CompDed(_page);

    public Task PressV4CompDedAsync(string key) => V4CompDed.PressAsync(key);

    public Task DoubleClickV4CompDedAsync() => V4CompDed.DblClickAsync();

    public Task SetV4CompDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V4CompDed, _data.Resolve(value));

    public Task TypeV4CompDedAsync(string value, float delayMs = 40) =>
        V4CompDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V4CompDedMoreOpt => CoveragesNewLocators.V4CompDedMoreOpt(_page);

    public Task PressV4CompDedMoreOptAsync(string key) => V4CompDedMoreOpt.PressAsync(key);

    public Task DoubleClickV4CompDedMoreOptAsync() => V4CompDedMoreOpt.DblClickAsync();

    public Task ClickV4CompDedMoreOptAsync() => V4CompDedMoreOpt.ClickAsync();

    private ILocator V4CollDed => CoveragesNewLocators.V4CollDed(_page);

    public Task PressV4CollDedAsync(string key) => V4CollDed.PressAsync(key);

    public Task DoubleClickV4CollDedAsync() => V4CollDed.DblClickAsync();

    public Task SetV4CollDedAsync(string value) =>
        UiActions.ApplyInputAsync(_page, V4CollDed, _data.Resolve(value));

    public Task TypeV4CollDedAsync(string value, float delayMs = 40) =>
        V4CollDed.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator V4CollDedMoreOpt => CoveragesNewLocators.V4CollDedMoreOpt(_page);

    public Task PressV4CollDedMoreOptAsync(string key) => V4CollDedMoreOpt.PressAsync(key);

    public Task DoubleClickV4CollDedMoreOptAsync() => V4CollDedMoreOpt.DblClickAsync();

    public Task ClickV4CollDedMoreOptAsync() => V4CollDedMoreOpt.ClickAsync();

    public Task ClickV1CollDedAsync() => V1CollDed.ClickAsync();

    public Task ClickV1CompCollOnlyYESAsync() => V1CompCollOnlyYES.ClickAsync();

    public Task ClickV1CompDedAsync() => V1CompDed.ClickAsync();

    public Task ClickV3CollDedAsync() => V3CollDed.ClickAsync();

    public Task ClickV3CompDedAsync() => V3CompDed.ClickAsync();

    public Task ClickV4CollDedAsync() => V4CollDed.ClickAsync();

    public Task ClickV4CompDedAsync() => V4CompDed.ClickAsync();
}
