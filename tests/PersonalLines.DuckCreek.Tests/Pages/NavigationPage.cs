using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class NavigationPage
{
    private readonly BrowserSession _browser;
    private readonly NavigationLocators _locators;
    private readonly UiActions _ui;

    public NavigationPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new NavigationLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickCloseTabAsync() =>
        _ui.ClickAsync(_locators.CloseTab, new ControlIntent("Navigation", "CloseTab"));

    public Task PressCoveragesNewNextAsync(string key) =>
        _ui.PressAsync(_locators.CoveragesNewNext, key, new ControlIntent("Navigation", "CoveragesNewNext"));

    public Task ClickCoveragesNewNextAsync() =>
        _ui.ClickAsync(_locators.CoveragesNewNext, new ControlIntent("Navigation", "CoveragesNewNext"));

    public Task<string> CaptureDriver1Async(string property = "") =>
        _ui.CaptureAsync(_locators.Driver1, property, new ControlIntent("Navigation", "Driver1"));

    public Task ClickDriverInformationAsync() =>
        _ui.ClickAsync(_locators.DriverInformation, new ControlIntent("Navigation", "DriverInformation"));

    public Task ClickEDITCOVERAGEOpt1Async() =>
        _ui.ClickAsync(_locators.EDITCOVERAGEOpt1, new ControlIntent("Navigation", "EDITCOVERAGEOpt1"));

    public Task ClickEDITCOVERAGEOpt2Async() =>
        _ui.ClickAsync(_locators.EDITCOVERAGEOpt2, new ControlIntent("Navigation", "EDITCOVERAGEOpt2"));

    public Task ClickEDITCOVERAGEOpt3Async() =>
        _ui.ClickAsync(_locators.EDITCOVERAGEOpt3, new ControlIntent("Navigation", "EDITCOVERAGEOpt3"));
public Task SetOption1Async(string value) =>
        _ui.SmartSetAsync(_locators.Option1, value, new ControlIntent("Navigation", "Option1"));

    public Task SetOption2Async(string value) =>
        _ui.SmartSetAsync(_locators.Option2, value, new ControlIntent("Navigation", "Option2"));

    public Task SetOption3Async(string value) =>
        _ui.SmartSetAsync(_locators.Option3, value, new ControlIntent("Navigation", "Option3"));

    public Task PressOption3Async(string key) =>
        _ui.PressAsync(_locators.Option3, key, new ControlIntent("Navigation", "Option3"));

    public Task VerifyQNumAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.QNum, expected, property, new ControlIntent("Navigation", "QNum"));

    public Task<string> CaptureQNumAsync(string property = "") =>
        _ui.CaptureAsync(_locators.QNum, property, new ControlIntent("Navigation", "QNum"));

    public Task EnterQuoteSearchInputAsync(string value) =>
        _ui.FillAsync(_locators.QuoteSearchInput, value, new ControlIntent("Navigation", "QuoteSearchInput"));

    public Task ClickSaveAndContinueAsync() =>
        _ui.ClickAsync(_locators.SaveAndContinue, new ControlIntent("Navigation", "SaveAndContinue"));

    public Task EnterStateAsync(string value) =>
        _ui.FillAsync(_locators.State, value, new ControlIntent("Navigation", "State"));

    public Task ClickSupplementalUMUIMCovAsync() =>
        _ui.ClickAsync(_locators.SupplementalUMUIMCov, new ControlIntent("Navigation", "SupplementalUMUIMCov"));

    public Task WaitForSupplementalUMUIMOptInAsync(string expected) =>
        _ui.WaitAsync(_locators.SupplementalUMUIMOptIn, expected, new ControlIntent("Navigation", "SupplementalUMUIMOptIn"));

    public Task ClickSupplementalUMUIMOptInAsync() =>
        _ui.ClickAsync(_locators.SupplementalUMUIMOptIn, new ControlIntent("Navigation", "SupplementalUMUIMOptIn"));

    public Task ClickTabsSearchAsync() =>
        _ui.ClickAsync(_locators.TabsSearch, new ControlIntent("Navigation", "TabsSearch"));

    public Task WaitForUMCoverageAsync(string expected) =>
        _ui.WaitAsync(_locators.UMCoverage, expected, new ControlIntent("Navigation", "UMCoverage"));

    public Task ClickUMCoverageAsync() =>
        _ui.ClickAsync(_locators.UMCoverage, new ControlIntent("Navigation", "UMCoverage"));

    public Task ClickV1CollDedAsync() =>
        _ui.ClickAsync(_locators.V1CollDed, new ControlIntent("Navigation", "V1CollDed"));

    public Task ClickV1CollDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V1CollDedMoreOpt, new ControlIntent("Navigation", "V1CollDedMoreOpt"));

    public Task SelectV1CompCollOnlyYESAsync(string value) =>
        _ui.SelectAsync(_locators.V1CompCollOnlyYES, value, new ControlIntent("Navigation", "V1CompCollOnlyYES"));

    public Task ClickV1CompDedAsync() =>
        _ui.ClickAsync(_locators.V1CompDed, new ControlIntent("Navigation", "V1CompDed"));

    public Task ClickV1CompDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V1CompDedMoreOpt, new ControlIntent("Navigation", "V1CompDedMoreOpt"));

    public Task ClickV1ComprehensiveAndCollisionOnlyAsync() =>
        _ui.ClickAsync(_locators.V1ComprehensiveAndCollisionOnly, new ControlIntent("Navigation", "V1ComprehensiveAndCollisionOnly"));

    public Task VerifyV1ComprehensiveDeductibleAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.V1ComprehensiveDeductible, expected, property, new ControlIntent("Navigation", "V1ComprehensiveDeductible"));

    public Task WaitForV1ComprehensiveOnlyAsync(string expected) =>
        _ui.WaitAsync(_locators.V1ComprehensiveOnly, expected, new ControlIntent("Navigation", "V1ComprehensiveOnly"));

    public Task SetV1ComprehensiveOnlyAsync(string value) =>
        _ui.SmartSetAsync(_locators.V1ComprehensiveOnly, value, new ControlIntent("Navigation", "V1ComprehensiveOnly"));

    public Task ClickV2CollDedAsync() =>
        _ui.ClickAsync(_locators.V2CollDed, new ControlIntent("Navigation", "V2CollDed"));

    public Task ClickV2CollDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V2CollDedMoreOpt, new ControlIntent("Navigation", "V2CollDedMoreOpt"));

    public Task SelectV2CompCollOnlyYESAsync(string value) =>
        _ui.SelectAsync(_locators.V2CompCollOnlyYES, value, new ControlIntent("Navigation", "V2CompCollOnlyYES"));

    public Task ClickV2CompDedAsync() =>
        _ui.ClickAsync(_locators.V2CompDed, new ControlIntent("Navigation", "V2CompDed"));

    public Task ClickV2CompDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V2CompDedMoreOpt, new ControlIntent("Navigation", "V2CompDedMoreOpt"));

    public Task ClickV2ComprehensiveAndCollisionOnlyAsync() =>
        _ui.ClickAsync(_locators.V2ComprehensiveAndCollisionOnly, new ControlIntent("Navigation", "V2ComprehensiveAndCollisionOnly"));

    public Task VerifyV2ComprehensiveDeductibleAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.V2ComprehensiveDeductible, expected, property, new ControlIntent("Navigation", "V2ComprehensiveDeductible"));

    public Task WaitForV2ComprehensiveOnlyAsync(string expected) =>
        _ui.WaitAsync(_locators.V2ComprehensiveOnly, expected, new ControlIntent("Navigation", "V2ComprehensiveOnly"));

    public Task SetV2ComprehensiveOnlyAsync(string value) =>
        _ui.SmartSetAsync(_locators.V2ComprehensiveOnly, value, new ControlIntent("Navigation", "V2ComprehensiveOnly"));

    public Task ClickV3CollDedAsync() =>
        _ui.ClickAsync(_locators.V3CollDed, new ControlIntent("Navigation", "V3CollDed"));

    public Task ClickV3CollDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V3CollDedMoreOpt, new ControlIntent("Navigation", "V3CollDedMoreOpt"));

    public Task SelectV3CompCollOnlyYESAsync(string value) =>
        _ui.SelectAsync(_locators.V3CompCollOnlyYES, value, new ControlIntent("Navigation", "V3CompCollOnlyYES"));

    public Task ClickV3CompDedAsync() =>
        _ui.ClickAsync(_locators.V3CompDed, new ControlIntent("Navigation", "V3CompDed"));

    public Task ClickV3CompDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V3CompDedMoreOpt, new ControlIntent("Navigation", "V3CompDedMoreOpt"));

    public Task ClickV3ComprehensiveAndCollisionOnlyAsync() =>
        _ui.ClickAsync(_locators.V3ComprehensiveAndCollisionOnly, new ControlIntent("Navigation", "V3ComprehensiveAndCollisionOnly"));

    public Task VerifyV3ComprehensiveDeductibleAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.V3ComprehensiveDeductible, expected, property, new ControlIntent("Navigation", "V3ComprehensiveDeductible"));

    public Task WaitForV3ComprehensiveOnlyAsync(string expected) =>
        _ui.WaitAsync(_locators.V3ComprehensiveOnly, expected, new ControlIntent("Navigation", "V3ComprehensiveOnly"));

    public Task SetV3ComprehensiveOnlyAsync(string value) =>
        _ui.SmartSetAsync(_locators.V3ComprehensiveOnly, value, new ControlIntent("Navigation", "V3ComprehensiveOnly"));

    public Task ClickV4CollDedAsync() =>
        _ui.ClickAsync(_locators.V4CollDed, new ControlIntent("Navigation", "V4CollDed"));

    public Task ClickV4CollDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V4CollDedMoreOpt, new ControlIntent("Navigation", "V4CollDedMoreOpt"));

    public Task SelectV4CompCollOnlyYESAsync(string value) =>
        _ui.SelectAsync(_locators.V4CompCollOnlyYES, value, new ControlIntent("Navigation", "V4CompCollOnlyYES"));

    public Task ClickV4CompDedAsync() =>
        _ui.ClickAsync(_locators.V4CompDed, new ControlIntent("Navigation", "V4CompDed"));

    public Task ClickV4CompDedMoreOptAsync() =>
        _ui.ClickAsync(_locators.V4CompDedMoreOpt, new ControlIntent("Navigation", "V4CompDedMoreOpt"));

    public Task ClickV4ComprehensiveAndCollisionOnlyAsync() =>
        _ui.ClickAsync(_locators.V4ComprehensiveAndCollisionOnly, new ControlIntent("Navigation", "V4ComprehensiveAndCollisionOnly"));

    public Task VerifyV4ComprehensiveDeductibleAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.V4ComprehensiveDeductible, expected, property, new ControlIntent("Navigation", "V4ComprehensiveDeductible"));

    public Task WaitForV4ComprehensiveOnlyAsync(string expected) =>
        _ui.WaitAsync(_locators.V4ComprehensiveOnly, expected, new ControlIntent("Navigation", "V4ComprehensiveOnly"));

    public Task SetV4ComprehensiveOnlyAsync(string value) =>
        _ui.SmartSetAsync(_locators.V4ComprehensiveOnly, value, new ControlIntent("Navigation", "V4ComprehensiveOnly"));

    public Task ClickVehicleSummaryAsync() =>
        _ui.ClickAsync(_locators.VehicleSummary, new ControlIntent("Navigation", "VehicleSummary"));
}
