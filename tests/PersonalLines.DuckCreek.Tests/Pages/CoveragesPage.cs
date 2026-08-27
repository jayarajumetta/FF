using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class CoveragesPage
{
    private readonly BrowserSession _browser;
    private readonly CoveragesLocators _locators;
    private readonly UiActions _ui;

    public CoveragesPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new CoveragesLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForADDCoverageAsync(string expected) =>
        _ui.WaitAsync(_locators.ADDCoverage, expected, new ControlIntent("Coverages", "ADDCoverage"));

    public Task PressADDCoverageAsync(string key) =>
        _ui.PressAsync(_locators.ADDCoverage, key, new ControlIntent("Coverages", "ADDCoverage"));

    public Task ClickADDCoverageAsync() =>
        _ui.ClickAsync(_locators.ADDCoverage, new ControlIntent("Coverages", "ADDCoverage"));

    public Task ClickADDDriver1Async() =>
        _ui.ClickAsync(_locators.ADDDriver1, new ControlIntent("Coverages", "ADDDriver1"));

    public Task ClickADDDriver2Async() =>
        _ui.ClickAsync(_locators.ADDDriver2, new ControlIntent("Coverages", "ADDDriver2"));

    public Task ClickADDDriver3Async() =>
        _ui.ClickAsync(_locators.ADDDriver3, new ControlIntent("Coverages", "ADDDriver3"));

    public Task ClickADDDriver4Async() =>
        _ui.ClickAsync(_locators.ADDDriver4, new ControlIntent("Coverages", "ADDDriver4"));

    public Task ClickADDDriver5Async() =>
        _ui.ClickAsync(_locators.ADDDriver5, new ControlIntent("Coverages", "ADDDriver5"));

    public Task ClickAdditionalCoveragesNextNewNextAsync() =>
        _ui.ClickAsync(_locators.AdditionalCoveragesNextNewNext, new ControlIntent("Coverages", "AdditionalCoveragesNextNewNext"));

    public Task ClickExtraordinaryMedicalBenefitAsync() =>
        _ui.ClickAsync(_locators.ExtraordinaryMedicalBenefit, new ControlIntent("Coverages", "ExtraordinaryMedicalBenefit"));

    public Task WaitForH1AdditionalCoveragesAsync(string expected) =>
        _ui.WaitAsync(_locators.H1AdditionalCoverages, expected, new ControlIntent("Coverages", "H1AdditionalCoverages"));

    public Task ClickIncLiabilityClaimsOfFamilyMembersAsync() =>
        _ui.ClickAsync(_locators.IncLiabilityClaimsOfFamilyMembers, new ControlIntent("Coverages", "IncLiabilityClaimsOfFamilyMembers"));

    public Task PressIncomeLossCoverageAsync(string key) =>
        _ui.PressAsync(_locators.IncomeLossCoverage, key, new ControlIntent("Coverages", "IncomeLossCoverage"));

    public Task ClickIncomeLossCoverageAsync() =>
        _ui.ClickAsync(_locators.IncomeLossCoverage, new ControlIntent("Coverages", "IncomeLossCoverage"));

    public Task SetLossOfIncomeDriver1Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver1, value, new ControlIntent("Coverages", "LossOfIncomeDriver1"));

    public Task SetLossOfIncomeDriver2Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver2, value, new ControlIntent("Coverages", "LossOfIncomeDriver2"));

    public Task SetLossOfIncomeDriver3Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver3, value, new ControlIntent("Coverages", "LossOfIncomeDriver3"));

    public Task SetLossOfIncomeDriver4Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver4, value, new ControlIntent("Coverages", "LossOfIncomeDriver4"));

    public Task SetLossOfIncomeDriver5Async(string value) =>
        _ui.SmartSetAsync(_locators.LossOfIncomeDriver5, value, new ControlIntent("Coverages", "LossOfIncomeDriver5"));

    public Task PressTortOptionAsync(string key) =>
        _ui.PressAsync(_locators.TortOption, key, new ControlIntent("Coverages", "TortOption"));

    public Task ClickTortOptionAsync() =>
        _ui.ClickAsync(_locators.TortOption, new ControlIntent("Coverages", "TortOption"));

    public Task ClickTotalDisabilityCoverageDriver1Async() =>
        _ui.ClickAsync(_locators.TotalDisabilityCoverageDriver1, new ControlIntent("Coverages", "TotalDisabilityCoverageDriver1"));

    public Task ClickUIMPDAsync() =>
        _ui.ClickAsync(_locators.UIMPD, new ControlIntent("Coverages", "UIMPD"));

    public Task ClickUMPDAsync() =>
        _ui.ClickAsync(_locators.UMPD, new ControlIntent("Coverages", "UMPD"));

    public Task SelectWorkLossNoAsync(string value) =>
        _ui.SelectAsync(_locators.WorkLossNo, value, new ControlIntent("Coverages", "WorkLossNo"));

}
