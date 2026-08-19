using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class UnderwritingPage
{
    private readonly BrowserSession _browser;
    private readonly UnderwritingLocators _locators;
    private readonly UiActions _ui;

    public UnderwritingPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new UnderwritingLocators(browser.Page);
        _ui = ui;
    }

    public Task WaitForAreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructureAsync(string expected) =>
        _ui.WaitAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure, expected, new ControlIntent("Underwriting", "AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure"));

    public Task PressChkBoxCheckBoxNoneOfTheAboveAsync(string key) =>
        _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, key, new ControlIntent("Underwriting", "ChkBoxCheckBoxNoneOfTheAbove"));

    public Task ClickChkBoxCheckBoxNoneOfTheAboveAsync() =>
        _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, new ControlIntent("Underwriting", "ChkBoxCheckBoxNoneOfTheAbove"));

    public Task ClickCycleUnderwritingNextAsync() =>
        _ui.ClickAsync(_locators.CycleUnderwritingNext, new ControlIntent("Underwriting", "CycleUnderwritingNext"));

    public Task VerifyEQCommonLoadingIndicatorWaitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, expected, property, new ControlIntent("Underwriting", "EQCommonLoadingIndicatorWait"));

    public Task WaitForHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync(string expected) =>
        _ui.WaitAsync(_locators.HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony, expected, new ControlIntent("Underwriting", "HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony"));

    public Task WaitForHeaderUnderwritingAsync(string expected) =>
        _ui.WaitAsync(_locators.HeaderUnderwriting, expected, new ControlIntent("Underwriting", "HeaderUnderwriting"));

    public Task WaitForIsAnyVintageCycleGaragedInADifferentLocationAsync(string expected) =>
        _ui.WaitAsync(_locators.IsAnyVintageCycleGaragedInADifferentLocation, expected, new ControlIntent("Underwriting", "IsAnyVintageCycleGaragedInADifferentLocation"));

    public Task ClickNewQuoteSearchAsync() =>
        _ui.ClickAsync(_locators.NewQuoteSearch, new ControlIntent("Underwriting", "NewQuoteSearch"));

    public Task SelectNo1Async(string value) =>
        _ui.SelectAsync(_locators.No1, value, new ControlIntent("Underwriting", "No1"));

    public Task SelectNo43938Async(string value) =>
        _ui.SelectAsync(_locators.No43938, value, new ControlIntent("Underwriting", "No43938"));

    public Task PressNo77DAEAsync(string key) =>
        _ui.PressAsync(_locators.No77DAE, key, new ControlIntent("Underwriting", "No77DAE"));

    public Task ClickNo77DAEAsync() =>
        _ui.ClickAsync(_locators.No77DAE, new ControlIntent("Underwriting", "No77DAE"));

    public Task PressPreQualificationNextAsync(string key) =>
        _ui.PressAsync(_locators.PreQualificationNext, key, new ControlIntent("Underwriting", "PreQualificationNext"));

    public Task ClickPreQualificationNextAsync() =>
        _ui.ClickAsync(_locators.PreQualificationNext, new ControlIntent("Underwriting", "PreQualificationNext"));

    public Task<bool> IsPreQualificationNextPresentAsync() =>
        _ui.ExistsAsync(_locators.PreQualificationNext);

    public Task EnterQuotePolicySearchAsync(string value) =>
        _ui.FillAsync(_locators.QuotePolicySearch, value, new ControlIntent("Underwriting", "QuotePolicySearch"));

    public Task PressQuotePolicySearchAsync(string key) =>
        _ui.PressAsync(_locators.QuotePolicySearch, key, new ControlIntent("Underwriting", "QuotePolicySearch"));

    public Task<bool> IsQuotePolicySearchPresentAsync() =>
        _ui.ExistsAsync(_locators.QuotePolicySearch);

    public Task ClickUnderwritingUnderwritingNextNextAsync() =>
        _ui.ClickAsync(_locators.UnderwritingUnderwritingNextNext, new ControlIntent("Underwriting", "UnderwritingUnderwritingNextNext"));

    public Task SelectYes707BBAsync(string value) =>
        _ui.SelectAsync(_locators.Yes707BB, value, new ControlIntent("Underwriting", "Yes707BB"));

    public Task SelectYes71588Async(string value) =>
        _ui.SelectAsync(_locators.Yes71588, value, new ControlIntent("Underwriting", "Yes71588"));


    public Task<bool> IsAreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructurePresentAsync() => _ui.ExistsAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure);

    public Task<bool> IsYes71588PresentAsync() => _ui.ExistsAsync(_locators.Yes71588);

}
