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

    public Task WaitForChkBoxCheckBoxNoneOfTheAboveAsync(string expected) =>
        _ui.WaitAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, expected, new ControlIntent("Underwriting", "ChkBoxCheckBoxNoneOfTheAbove"));
    public Task ClickVehiclesKeptEnclosedNoAsync() =>
        _ui.ClickAsync(_locators.VehiclesKeptEnclosedNo, new ControlIntent("Underwriting", "VehiclesKeptEnclosedNo"));

    public Task ClickVehiclesKeptEnclosedYesAsync() =>
        _ui.ClickAsync(_locators.VehiclesKeptEnclosedYes, new ControlIntent("Underwriting", "VehiclesKeptEnclosedYes"));

    public Task<bool> IsWhoWillCompleteInspectionHeaderPresentAsync() =>
        _ui.ExistsAsync(_locators.WhoWillCompleteInspectionHeader);

    public Task ClickCompleteInspectionAgentAsync() =>
        _ui.ClickAsync(_locators.CompleteInspectionAgent, new ControlIntent("Underwriting", "CompleteInspectionAgent"));

    public Task PressChkBoxCheckBoxNoneOfTheAboveAsync(string key) =>
        _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, key, new ControlIntent("Underwriting", "ChkBoxCheckBoxNoneOfTheAbove"));

    public Task ClickChkBoxCheckBoxNoneOfTheAboveAsync() =>
        _ui.ClickAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, new ControlIntent("Underwriting", "ChkBoxCheckBoxNoneOfTheAbove"));

    public Task ClickCycleUnderwritingNextAsync() =>
        _ui.ClickAsync(_locators.BtnNext, new ControlIntent("Underwriting", "CycleUnderwritingNext"));

    public Task VerifyEQCommonLoadingIndicatorWaitAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.EQCommonLoadingIndicatorWait, expected, property, new ControlIntent("Underwriting", "EQCommonLoadingIndicatorWait"));

    public Task WaitForHaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelonyAsync(string expected) =>
        _ui.WaitAsync(_locators.HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony, expected, new ControlIntent("Underwriting", "HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony"));

    public Task WaitForHeaderUnderwritingAsync(string expected) =>
        _ui.WaitAsync(_locators.HeaderUnderwriting, expected, new ControlIntent("Underwriting", "HeaderUnderwriting"));

    public Task WaitForIsAnyVintageCycleGaragedInADifferentLocationAsync(string expected) =>
        _ui.WaitAsync(_locators.HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony, expected, new ControlIntent("Underwriting", "IsAnyVintageCycleGaragedInADifferentLocation"));

    public Task ClickNewQuoteSearchAsync() =>
        _ui.ClickAsync(_locators.NewQuoteSearch, new ControlIntent("Underwriting", "NewQuoteSearch"));

    public Task SelectNo1Async(string value) =>
        _ui.SelectAsync(_locators.CollectorNVintageNo, value, new ControlIntent("Underwriting", "No1"));

    public Task SelectNo43938Async(string value) =>
        _ui.SelectAsync(_locators.No43938, value, new ControlIntent("Underwriting", "No43938"));

    public Task PressNo77DAEAsync(string key) =>
        _ui.PressAsync(_locators.No77DAE, key, new ControlIntent("Underwriting", "No77DAE"));

    public Task ClickNo77DAEAsync() =>
        _ui.ClickAsync(_locators.No77DAE, new ControlIntent("Underwriting", "No77DAE"));

    public Task<bool> IsNo77DAEPresentAsync() =>
        _ui.ExistsAsync(_locators.No77DAE);

    public Task<bool> IsTrafficRelatedFelonyNoPresentAsync() =>
        _ui.ExistsAsync(_locators.TrafficRelatedFelonyNo);

    public Task ClickTrafficRelatedFelonyNoAsync() =>
        _ui.ClickAsync(_locators.TrafficRelatedFelonyNo, new ControlIntent("Underwriting", "TrafficRelatedFelonyNo"));

    public Task PressPreQualificationNextAsync(string key) =>
        _ui.PressAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove, key, new ControlIntent("Underwriting", "PreQualificationNext"));

    public Task ClickPreQualificationNextAsync() =>
        _ui.ClickAsync(_locators.BtnNext, new ControlIntent("Underwriting", "PreQualificationNext"));

    public Task<bool> IsPreQualificationNextPresentAsync() =>
        _ui.ExistsAsync(_locators.ChkBoxCheckBoxNoneOfTheAbove);

    public Task EnterQuotePolicySearchAsync(string value) =>
        _ui.FillAsync(_locators.QuotePolicySearch, value, new ControlIntent("Underwriting", "QuotePolicySearch"));

    public Task PressQuotePolicySearchAsync(string key) =>
        _ui.PressAsync(_locators.QuotePolicySearch, key, new ControlIntent("Underwriting", "QuotePolicySearch"));

    public Task<bool> IsQuotePolicySearchPresentAsync() =>
        _ui.ExistsAsync(_locators.QuotePolicySearch);

    public Task ClickUnderwritingUnderwritingNextNextAsync() =>
        _ui.ClickAsync(_locators.CycleUnderwritingNext, new ControlIntent("Underwriting", "UnderwritingUnderwritingNextNext"));

    public Task SelectYes707BBAsync(string value) =>
        _ui.SelectAsync(_locators.No77DAE, value, new ControlIntent("Underwriting", "Yes707BB"));

    public Task SelectYes71588Async(string value) =>
        _ui.SelectAsync(_locators.Yes71588, value, new ControlIntent("Underwriting", "Yes71588"));


    public Task<bool> IsAreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructurePresentAsync() => _ui.ExistsAsync(_locators.AreAllCollectorVehiclesKeptInAFullyEnclosedAndLockedStructure);

    public Task<bool> IsYes71588PresentAsync() => _ui.ExistsAsync(_locators.Yes71588);

    public Task EnterAgentCommentsAsync(string value) =>
        EnterAgentCommentsWithRetryAsync(_locators.AgentComments, value, "AgentComments");

    public Task EnterAgentComments2Async(string value) =>
        EnterAgentCommentsWithRetryAsync(_locators.AgentComments2, value, "AgentComments2");

    // The Agent Comments input is occasionally re-rendered/reset by Angular change detection right after
    // keystrokes are entered, so the typed value can silently disappear. Verifying the value stuck and
    // retrying makes the interaction deterministic instead of intermittently failing.
    private async Task EnterAgentCommentsWithRetryAsync(ILocator locator, string value, string controlName)
    {
        var intent = new ControlIntent("Underwriting", controlName);
        await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        const int maxAttempts = 3;
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            await _ui.PressSequentiallyAsync(locator, value, intent);

            // Commit the value so Angular's change detection binds it to the model instead of
            // leaving it as a transient DOM-only value that can be wiped by a later re-render.
            try { await locator.BlurAsync(); } catch (Exception ex) when (ex is PlaywrightException or TimeoutException) { }

            // Angular can re-render the control asynchronously after the input/blur events fire,
            // silently resetting the value a few hundred ms later. Re-check after a short settle
            // delay so we don't declare success on a value that is about to be wiped out.

            string actual;
            try
            {
                actual = await locator.InputValueAsync();
            }
            catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
            {
                actual = string.Empty;
            }
            if (string.Equals(actual, value, StringComparison.Ordinal)) return;
            if (attempt < maxAttempts) await Task.Delay(500);
        }
    }

    public async Task<bool> IsAgentCommentsVisibleAndEditableAsync()
    {
        try
        {
            await _locators.AgentComments.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.AgentComments.IsVisibleAsync() && await _locators.AgentComments.IsEditableAsync();
    }

    public async Task<bool> IsAgentComments2VisibleAndEditableAsync()
    {
        try
        {
            await _locators.AgentComments2.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 3000 });
        }
        catch (Exception ex) when (ex is PlaywrightException or TimeoutException)
        {
            return false;
        }
        return await _locators.AgentComments2.IsVisibleAsync() && await _locators.AgentComments2.IsEditableAsync();
    }

    public Task ClickReferToUWAsync() =>
        _ui.ClickAsync(_locators.ReferToUW, new ControlIntent("Underwriting", "ReferToUW"));

    public Task<bool> IsReferToUWVisibleAsync() =>
        _locators.ReferToUW.IsVisibleAsync();

    // Agent Note boxes can appear for any number of underwriting rule rows (rows[0], rows[1], ...),
    // and the row index is not guaranteed to be stable, so fill all boxes currently on screen.
    public async Task<bool> IsAnyAgentNoteVisibleAsync()
    {
        var inputs = _locators.AgentNoteInputs;
        var count = await inputs.CountAsync();
        for (var i = 0; i < count; i++)
        {
            if (await inputs.Nth(i).IsVisibleAsync())
                return true;
        }
        return false;
    }

    public async Task EnterAllAgentNotesAsync(string value)
    {
        var inputs = _locators.AgentNoteInputs;
        var count = await inputs.CountAsync();
        for (var i = 0; i < count; i++)
        {
            await EnterAgentCommentsWithRetryAsync(inputs.Nth(i), value, $"AgentNote{i}");
        }
    }

}
