using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class VehiclesPage
{
    private readonly VehiclesLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public VehiclesPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new VehiclesLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I add bicycle
    public async Task AddBicycleAsync()
    {
        // CLEQSFPDIV4ScheduledPersonalPropertyAddBicycle_1ac6f8Page.AddDIV4BicycleCoverage_0207_08f3f1Async
        await _ui.WaitAsync(_locators.ScheduledPersonalPropertyHeader, "Exists");
        await _ui.PressAsync(_locators.SearchByNameOrCode, "POST:ENTER");
        await _ui.PressAsync(_locators.SearchByNameOrCode, "Enter");
        await _ui.PressAsync(_locators.SearchByNameOrCode, "Tab");
        await _ui.ClickAsync(_locators.ClientInfoSearch);
        await _ui.FillAsync(_locators.True, _data.Resolve("{{data:true_260}}"));
        // CLEQSFPDIV4ScheduledPersonalPropertyAddBicycleCLEQCommonWaitOnLoadingIndicator_5ece51Page.EQLoadingIndicatorWait_0208_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPDIV4ScheduledPersonalPropertyAddBicycle_1ac6f8Page.WaitForAddCocerageButton_0209_08f3f1Async
        await _ui.WaitAsync(_locators.AddCoverage, "Exists");
        // CLEQSFPDIV4ScheduledPersonalPropertyAddBicycle_1ac6f8Page.AddCoverageAndDetail_0210_08f3f1Async
        await _ui.SelectAsync(_locators.AddCoverage, _data.Resolve(""));
        await _ui.PressAsync(_locators.Description, "POST:ENTER");
        await _ui.PressAsync(_locators.Description, "Enter");
        await _ui.PressAsync(_locators.Description, "Tab");
        await _ui.PressAsync(_locators.Limit, "POST:ENTER");
        await _ui.PressAsync(_locators.Limit, "Enter");
        await _ui.PressAsync(_locators.Limit, "Tab");
        // CLEQSFPDIV4ScheduledPersonalPropertyAddBicycleCLEQCommonWaitOnLoadingIndicator_5ece51Page.EQLoadingIndicatorWait_0211_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPDIV4ScheduledPersonalPropertyAddBicycle_1ac6f8Page.AddYearOfLastAppraisalAndSave_0212_08f3f1Async
        await _ui.PressAsync(_locators.YearOfLastAppraisal, "POST:ENTER");
        await _ui.PressAsync(_locators.YearOfLastAppraisal, "Enter");
        await _ui.PressAsync(_locators.YearOfLastAppraisal, "Tab");
        await _ui.ClickAsync(_locators.Save);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0213_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_10}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0214_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
        await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}