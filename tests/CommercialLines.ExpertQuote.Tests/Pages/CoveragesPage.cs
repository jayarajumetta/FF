using InsuranceAutomation.Core;
using Microsoft.Playwright;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

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

    public Task PressAddCoverageAsync(string key) =>
        _ui.PressAsync(_locators.AddCoverage, key, new ControlIntent("Coverages", "AddCoverage"));

    public Task ClickApproveAsync() =>
        _ui.ClickAsync(_locators.Approve, new ControlIntent("Coverages", "Approve"));

    public Task EnterBlanketFPPAsync(string value) =>
        _ui.FillAsync(_locators.BlanketFPP, value, new ControlIntent("Coverages", "BlanketFPP"));

    public Task PressBlanketFPPAsync(string key) =>
        _ui.PressAsync(_locators.BlanketFPP, key, new ControlIntent("Coverages", "BlanketFPP"));

    public Task WaitForCECoverageAsync(string expected) =>
        _ui.WaitAsync(_locators.CECoverage, expected, new ControlIntent("Coverages", "CECoverage"));

    public Task PressCECoverageAsync(string key) =>
        _ui.PressAsync(_locators.CECoverage, key, new ControlIntent("Coverages", "CECoverage"));

    public Task PressCheckBoxAsync(string key) =>
        _ui.PressAsync(_locators.CheckBox, key, new ControlIntent("Coverages", "CheckBox"));

    public Task PressChoiceAsync(string key) =>
        _ui.PressAsync(_locators.BlanketFPP, key, new ControlIntent("Coverages", "Choice"));

    public Task PressChoiceWithHorseAsync(string key) =>
        _ui.PressAsync(_locators.BlanketFPP, key, new ControlIntent("Coverages", "ChoiceWithHorse"));

    public Task EnterDeductibleAsync(string value) =>
        _ui.FillAsync(_locators.Deductible, value, new ControlIntent("Coverages", "Deductible"));

    public Task PressDescriptionAsync(string key) =>
        _ui.PressAsync(_locators.Description, key, new ControlIntent("Coverages", "Description"));

    public Task PressDoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaintAsync(string key) =>
        _ui.PressAsync(_locators.DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, key, new ControlIntent("Coverages", "DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint"));

    public Task PressHaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwnerAsync(string key) =>
        _ui.PressAsync(_locators.HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner, key, new ControlIntent("Coverages", "HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner"));

    public Task VerifyIFRAMEAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IFRAME, expected, property, new ControlIntent("Coverages", "IFRAME"));

    public Task<bool> IsIFRAMEPresentAsync() =>
        _ui.ExistsAsync(_locators.IFRAME);

    public Task WaitForIFRAMEDuckCreekPolicyIFRAMEOKAsync(string expected) =>
        _ui.WaitAsync(_locators.IFRAMEDuckCreekPolicyIFRAMEOK, expected, new ControlIntent("Coverages", "IFRAMEDuckCreekPolicyIFRAMEOK"));

    public Task ClickIFRAMEDuckCreekPolicyIFRAMEOKAsync() =>
        _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyIFRAMEOK, new ControlIntent("Coverages", "IFRAMEDuckCreekPolicyIFRAMEOK"));

    public Task VerifyIsThisCoverageBoundAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.IsThisCoverageBound, expected, property, new ControlIntent("Coverages", "IsThisCoverageBound"));

    public Task PressIsThisCoverageBoundAsync(string key) =>
        _ui.PressAsync(_locators.IsThisCoverageBound, key, new ControlIntent("Coverages", "IsThisCoverageBound"));

    public Task<bool> IsIsThisCoverageBoundPresentAsync() =>
        _ui.ExistsAsync(_locators.IsThisCoverageBound);

    public Task EnterLiabilityLimitAsync(string value) =>
        _ui.FillAsync(_locators.LiabilityLimit, value, new ControlIntent("Coverages", "LiabilityLimit"));

    public Task PressLimitAsync(string key) =>
        _ui.PressAsync(_locators.Limit, key, new ControlIntent("Coverages", "Limit"));
public Task PressPremierAsync(string key) =>
        _ui.PressAsync(_locators.BlanketFPP, key, new ControlIntent("Coverages", "Premier"));

    public Task PressPremierWithHorseAsync(string key) =>
        _ui.PressAsync(_locators.BlanketFPP, key, new ControlIntent("Coverages", "PremierWithHorse"));

    public Task VerifyReferRequestIssuanceAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.ReferRequestIssuance, expected, property, new ControlIntent("Coverages", "ReferRequestIssuance"));

    public Task ClickReferRequestIssuanceAsync() =>
        _ui.ClickAsync(_locators.ReferRequestIssuance, new ControlIntent("Coverages", "ReferRequestIssuance"));

    public Task<bool> IsReferRequestIssuancePresentAsync() =>
        _ui.ExistsAsync(_locators.ReferRequestIssuance);

    public Task ClickSaveAsync() =>
        _ui.ClickAsync(_locators.Save, new ControlIntent("Coverages", "Save"));

    public Task VerifyScreenHeadingAsync(string expected, string property) =>
        _ui.VerifyAsync(_locators.NoPrefillMatchFound, expected, property, new ControlIntent("Coverages", "ScreenHeading"));

    public Task<bool> IsScreenHeadingPresentAsync() =>
        _ui.ExistsAsync(_locators.NoPrefillMatchFound);

    public Task PressSearchByNameOrCodeAsync(string key) =>
        _ui.PressAsync(_locators.SearchByNameOrCode, key, new ControlIntent("Coverages", "SearchByNameOrCode"));

    public Task PressSelectAsync(string key) =>
        _ui.PressAsync(_locators.Select, key, new ControlIntent("Coverages", "Select"));

    public Task PressSelectWithHorseAsync(string key) =>
        _ui.PressAsync(_locators.BlanketFPP, key, new ControlIntent("Coverages", "SelectWithHorse"));

    public Task EnterUnscheduledStructuresAsync(string value) =>
        _ui.FillAsync(_locators.UnscheduledStructures, value, new ControlIntent("Coverages", "UnscheduledStructures"));

    public Task EnterWaterDamageAsync(string value) =>
        _ui.FillAsync(_locators.WaterDamage, value, new ControlIntent("Coverages", "WaterDamage"));

    public Task PauseAsync(int milliseconds) =>
        Task.Delay(milliseconds);

}
