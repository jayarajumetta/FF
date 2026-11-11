using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class SocialSecurityPage
{
    private readonly BrowserSession _browser;
    private readonly SocialSecurityLocators _locators;
    private readonly UiActions _ui;

    public SocialSecurityPage(BrowserSession browser, UiActions ui)
    {
        _browser = browser;
        _locators = new SocialSecurityLocators(browser.Page);
        _ui = ui;
    }

    public Task ClickDriverInformationAsync() =>
        _ui.ClickAsync(_locators.DriverInformation, new ControlIntent("SocialSecurity", "DriverInformation"));

    public Task ClickPrefillDriverSNavAsync() =>
        _ui.ClickAsync(_locators.PrefillDriverSNav, new ControlIntent("SocialSecurity", "PrefillDriverSNav"));

    public Task<bool> IsReasonForNotIncludingThisIndividualPresentAsync() =>
        _ui.ExistsAsync(_locators.ReasonForNotIncludingThisIndividualLabel);

    public Task<bool> IsReasonForNotIncludingThisIndividualPresentAsync(int row) =>
        _ui.ExistsAsync(_locators.GetReasonForNotIncludingThisIndividual(row));

    public Task SelectReasonForNotIncludingThisIndividualAsync(int row, string value) =>
        _ui.SelectAsync(_locators.GetReasonForNotIncludingThisIndividual(row), value, new ControlIntent("SocialSecurity", "ReasonForNotIncludingThisIndividual"));

    public Task EnterMATFORMFIELDAsync(string value) =>
        _ui.FillAsync(_locators.MATFORMFIELD, value, new ControlIntent("SocialSecurity", "MATFORMFIELD"));


    public Task<bool> IsRaymondNotIncludingIndividualPropertyAsync() =>
        _ui.ExistsAsync(_locators.ReasonForNOnLivingResidencyRaymond);

    public Task EnterRaymondNotIncludingIndividualPropertyAsync(string value) =>
        _ui.FillAsync(_locators.ReasonForNOnLivingResidencyRaymond, value, new ControlIntent("Driver", "Reason for not including this individual on the policy"));

    public Task<bool> IsReasonForIndividualProperyAsync() =>
    _ui.ExistsAsync(_locators.ReasonForIndividualPropery);

    public Task EnterReasonForIndividualProperyAsync(string value) =>
    _ui.FillAsync(_locators.ReasonForIndividualPropery, value, new ControlIntent("Driver", "Reason for not including this individual on the policy"));




    public Task<bool> IsReasonForNotIncludingPropertyAsync() =>
    _ui.ExistsAsync(_locators.ReasonForNotIncludingProperty);


    public Task EnterReasonForNotIncludingPropertyAsync(string value) =>
  _ui.FillAsync(_locators.ReasonForNotIncludingProperty, value, new ControlIntent("Driver", "Reason for not including this individual on the policy"));





    public Task<bool> IsMATFORMFIELDPresentAsync() =>
        _ui.ExistsAsync(_locators.MATFORMFIELD);

    public Task<int> GetPrefillReasonDropdownCountAsync() =>
        _locators.PrefillReasonDropdowns.CountAsync();

    public async Task<int> SelectFirstReasonForAllPrefillDriversAsync()
    {
        var dropdowns = _locators.PrefillReasonDropdowns;
        var count = await dropdowns.CountAsync();
        for (var index = 0; index < count; index++)
        {
            var dropdown = dropdowns.Nth(index);
            var intent = new ControlIntent("SocialSecurity", $"PrefillReason{index}");
            await _ui.ClickAsync(dropdown, intent);
            await _ui.ClickAsync(_locators.PrefillReasonFirstOption, new ControlIntent("SocialSecurity", $"PrefillReasonOption{index}"));
            await Assertions.Expect(dropdown).ToHaveAttributeAsync("aria-expanded", "false");
            await Assertions.Expect(dropdown).Not.ToHaveClassAsync(new System.Text.RegularExpressions.Regex(@"\bmat-mdc-select-empty\b"));
        }
        return count;
    }

    public Task PressNeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleSAsync(string key) =>
        _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, key, new ControlIntent("SocialSecurity", "NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS"));

    public Task WaitForPrefilledDriversAsync(string expected) =>
        _ui.WaitAsync(_locators.PrefilledDrivers, expected, new ControlIntent("SocialSecurity", "PrefilledDrivers"));

    public Task<string> CapturePrefilledDriversAsync(string property = "") =>
        _ui.CaptureAsync(_locators.PrefilledDrivers, property, new ControlIntent("SocialSecurity", "PrefilledDrivers"));

    public Task<bool> IsPrefilledDriversPresentAsync() =>
        _ui.ExistsAsync(_locators.PrefilledDrivers);

    public Task<bool> IsPrefilledDriversRequiredAsync() =>
        _ui.ExistsAsync(_locators.PreFilledDriversRequired);

    public Task ClickSaveAndContinueAsync() =>
        _ui.ClickAsync(_locators.SaveAndContinue, new ControlIntent("SocialSecurity", "SaveAndContinue"));

    public Task<bool> IsSaveAndContinuePresentAsync() =>
        _ui.ExistsAsync(_locators.SaveAndContinue);

    public Task EnterStateAsync(string value) =>
        _ui.FillAsync(_locators.State, value, new ControlIntent("SocialSecurity", "State"));

    public Task VerifyUnselectedClientSuggestionsAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.UnselectedClientSuggestions, expected, property, new ControlIntent("SocialSecurity", "UnselectedClientSuggestions"));

    public Task<bool> IsUnselectedClientSuggestionsPresentAsync() =>
        _ui.ExistsAsync(_locators.UnselectedClientSuggestions);

    public Task<bool> IsUnderWriterRulesAsync() =>
        _ui.ExistsAsync(_locators.UnderWriterRulesHeader);

    public Task ClickCONTINUEF07C7Async() =>
        _locators.CONTINUED555D.EvaluateAsync("el => el.click()");

}
