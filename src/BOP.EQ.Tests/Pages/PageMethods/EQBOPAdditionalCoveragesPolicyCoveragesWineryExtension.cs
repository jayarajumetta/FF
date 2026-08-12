using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPAdditionalCoveragesPolicyCoveragesWineryExtension
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPAdditionalCoveragesPolicyCoveragesWineryExtension(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator DirectToConsumerSales => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.DirectToConsumerSales(_page);

    public Task PressDirectToConsumerSalesAsync(string key) => DirectToConsumerSales.PressAsync(key);

    public Task DoubleClickDirectToConsumerSalesAsync() => DirectToConsumerSales.DblClickAsync();

    public Task SetDirectToConsumerSalesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DirectToConsumerSales, _data.Resolve(value));

    public Task TypeDirectToConsumerSalesAsync(string value, float delayMs = 40) =>
        DirectToConsumerSales.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BottledWine => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.BottledWine(_page);

    public Task PressBottledWineAsync(string key) => BottledWine.PressAsync(key);

    public Task DoubleClickBottledWineAsync() => BottledWine.DblClickAsync();

    public Task SetBottledWineAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BottledWine, _data.Resolve(value));

    public Task TypeBottledWineAsync(string value, float delayMs = 40) =>
        BottledWine.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ServedByTheGlass => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.ServedByTheGlass(_page);

    public Task PressServedByTheGlassAsync(string key) => ServedByTheGlass.PressAsync(key);

    public Task DoubleClickServedByTheGlassAsync() => ServedByTheGlass.DblClickAsync();

    public Task SetServedByTheGlassAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ServedByTheGlass, _data.Resolve(value));

    public Task TypeServedByTheGlassAsync(string value, float delayMs = 40) =>
        ServedByTheGlass.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator ConsumedOnPremise => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.ConsumedOnPremise(_page);

    public Task PressConsumedOnPremiseAsync(string key) => ConsumedOnPremise.PressAsync(key);

    public Task DoubleClickConsumedOnPremiseAsync() => ConsumedOnPremise.DblClickAsync();

    public Task SetConsumedOnPremiseAsync(string value) =>
        UiActions.ApplyInputAsync(_page, ConsumedOnPremise, _data.Resolve(value));

    public Task TypeConsumedOnPremiseAsync(string value, float delayMs = 40) =>
        ConsumedOnPremise.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator DirectToConsumerInternetSales => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.DirectToConsumerInternetSales(_page);

    public Task PressDirectToConsumerInternetSalesAsync(string key) => DirectToConsumerInternetSales.PressAsync(key);

    public Task DoubleClickDirectToConsumerInternetSalesAsync() => DirectToConsumerInternetSales.DblClickAsync();

    public Task SetDirectToConsumerInternetSalesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, DirectToConsumerInternetSales, _data.Resolve(value));

    public Task TypeDirectToConsumerInternetSalesAsync(string value, float delayMs = 40) =>
        DirectToConsumerInternetSales.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator WholesaleWineSales => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.WholesaleWineSales(_page);

    public Task PressWholesaleWineSalesAsync(string key) => WholesaleWineSales.PressAsync(key);

    public Task DoubleClickWholesaleWineSalesAsync() => WholesaleWineSales.DblClickAsync();

    public Task SetWholesaleWineSalesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, WholesaleWineSales, _data.Resolve(value));

    public Task TypeWholesaleWineSalesAsync(string value, float delayMs = 40) =>
        WholesaleWineSales.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator BulkWineSales => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.BulkWineSales(_page);

    public Task PressBulkWineSalesAsync(string key) => BulkWineSales.PressAsync(key);

    public Task DoubleClickBulkWineSalesAsync() => BulkWineSales.DblClickAsync();

    public Task SetBulkWineSalesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, BulkWineSales, _data.Resolve(value));

    public Task TypeBulkWineSalesAsync(string value, float delayMs = 40) =>
        BulkWineSales.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TotalWineSoldAnnually => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.TotalWineSoldAnnually(_page);

    public Task PressTotalWineSoldAnnuallyAsync(string key) => TotalWineSoldAnnually.PressAsync(key);

    public Task DoubleClickTotalWineSoldAnnuallyAsync() => TotalWineSoldAnnually.DblClickAsync();

    public Task SetTotalWineSoldAnnuallyAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TotalWineSoldAnnually, _data.Resolve(value));

    public Task TypeTotalWineSoldAnnuallyAsync(string value, float delayMs = 40) =>
        TotalWineSoldAnnually.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator TotalOtherThanWineSales => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.TotalOtherThanWineSales(_page);

    public Task PressTotalOtherThanWineSalesAsync(string key) => TotalOtherThanWineSales.PressAsync(key);

    public Task DoubleClickTotalOtherThanWineSalesAsync() => TotalOtherThanWineSales.DblClickAsync();

    public Task SetTotalOtherThanWineSalesAsync(string value) =>
        UiActions.ApplyInputAsync(_page, TotalOtherThanWineSales, _data.Resolve(value));

    public Task TypeTotalOtherThanWineSalesAsync(string value, float delayMs = 40) =>
        TotalOtherThanWineSales.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator OtherAlcoholSalesExceed25 => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.OtherAlcoholSalesExceed25(_page);

    public Task PressOtherAlcoholSalesExceed25Async(string key) => OtherAlcoholSalesExceed25.PressAsync(key);

    public Task DoubleClickOtherAlcoholSalesExceed25Async() => OtherAlcoholSalesExceed25.DblClickAsync();

    public Task SetOtherAlcoholSalesExceed25Async(string value) =>
        OtherAlcoholSalesExceed25.SelectOptionAsync(_data.Resolve(value));

    private ILocator PropertyDeductible => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.PropertyDeductible(_page);

    public Task PressPropertyDeductibleAsync(string key) => PropertyDeductible.PressAsync(key);

    public Task DoubleClickPropertyDeductibleAsync() => PropertyDeductible.DblClickAsync();

    public Task SetPropertyDeductibleAsync(string value) =>
        PropertyDeductible.SelectOptionAsync(_data.Resolve(value));

    private ILocator HarvestedGrapes => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.HarvestedGrapes(_page);

    public Task PressHarvestedGrapesAsync(string key) => HarvestedGrapes.PressAsync(key);

    public Task DoubleClickHarvestedGrapesAsync() => HarvestedGrapes.DblClickAsync();

    public Task ClickHarvestedGrapesAsync() => HarvestedGrapes.ClickAsync();

    private ILocator HarvestedGrapesLimitOfInsurance => EQBOPAdditionalCoveragesPolicyCoveragesWineryExtensionLocators.HarvestedGrapesLimitOfInsurance(_page);

    public Task PressHarvestedGrapesLimitOfInsuranceAsync(string key) => HarvestedGrapesLimitOfInsurance.PressAsync(key);

    public Task DoubleClickHarvestedGrapesLimitOfInsuranceAsync() => HarvestedGrapesLimitOfInsurance.DblClickAsync();

    public Task SetHarvestedGrapesLimitOfInsuranceAsync(string value) =>
        UiActions.ApplyInputAsync(_page, HarvestedGrapesLimitOfInsurance, _data.Resolve(value));

    public Task TypeHarvestedGrapesLimitOfInsuranceAsync(string value, float delayMs = 40) =>
        HarvestedGrapesLimitOfInsurance.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickTotalOtherThanWineSalesAsync() => TotalOtherThanWineSales.ClickAsync();
}
