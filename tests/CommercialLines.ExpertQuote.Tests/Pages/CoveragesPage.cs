using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class CoveragesPage
{
    private readonly CoveragesLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public CoveragesPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new CoveragesLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete policy\-wide
    public async Task CompletePolicyWideAsync()
    {
        // CLEQSFPCEPolicyWide_c536c5Page.EQSFPPolicyWideCoverageCE_0180_503012Async
        await _ui.WaitAsync(_locators.CECoverage, "Exists");
        await _ui.PressAsync(_locators.AddCoverage, "POST:TAB");
        await _ui.PressAsync(_locators.AddCoverage, "Tab");
        await _ui.PressAsync(_locators.CECoverage, "POST:TAB");
        await _ui.PressAsync(_locators.CECoverage, "Tab");
        // CLEQSFPCEPolicyWide_c536c5Page.EQSFPCECoverages_0181_503012Async
        if (_data.Condition("CoverageType == \"Choice\""))
        {
            await _ui.PressAsync(_locators.Choice, "POST:SHIFTTAB");
            await _ui.PressAsync(_locators.Choice, "SHIFTTAB");
        }
        if (_data.Condition("CoverageType == \"Choice Horse\""))
        {
            await _ui.PressAsync(_locators.ChoiceWithHorse, "POST:TAB");
            await _ui.PressAsync(_locators.ChoiceWithHorse, "Tab");
        }
        if (_data.Condition("CoverageType == \"Select\""))
        {
            await _ui.PressAsync(_locators.Select, "POST:TAB");
            await _ui.PressAsync(_locators.Select, "Tab");
        }
        if (_data.Condition("CoverageType == \"Select Horse\""))
        {
            await _ui.PressAsync(_locators.SelectWithHorse, "POST:TAB");
            await _ui.PressAsync(_locators.SelectWithHorse, "Tab");
        }
        if (_data.Condition("CoverageType == \"Premier\""))
        {
            await _ui.PressAsync(_locators.Premier, "POST:TAB");
            await _ui.PressAsync(_locators.Premier, "Tab");
        }
        if (_data.Condition("CoverageType == \"Premier Horse\""))
        {
            await _ui.PressAsync(_locators.PremierWithHorse, "POST:TAB");
            await _ui.PressAsync(_locators.PremierWithHorse, "Tab");
        }
        await _ui.FillAsync(_locators.WaterDamage, _data.Resolve("{{data:water_damage_234}}"));
        await _ui.FillAsync(_locators.UnscheduledStructures, _data.Resolve("{{data:unscheduled_structures_235}}"));
        await _ui.FillAsync(_locators.BlanketFPP, _data.Resolve("{{data:blanket_fpp_236}}"));
        await _ui.PressAsync(_locators.BlanketFPP, "POST:ENTER");
        await _ui.PressAsync(_locators.BlanketFPP, "Enter");
        await _ui.PressAsync(_locators.BlanketFPP, "Tab");
        await _ui.PressAsync(_locators.BlanketFPP, "POST:TAB");
        await _ui.PressAsync(_locators.BlanketFPP, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit, _data.Resolve("{{data:liability_limit_239}}"));
        await _ui.ClickAsync(_locators.Save);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0182_503012Async
        _data.Set("Screen", _data.Resolve("{{data:screen_8}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0183_503012Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I answer EPLI Questions
    public async Task AnswerEPLIQuestionsAsync()
    {
        // EQBOPAdditionalCoveragesAnswerEPLIQuestions_8f39e4Page.EQBOPAdditionalCoveragesAnswerEPLIQuestions_0280_d18a3eAsync
        await _ui.PressAsync(_locators.HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner, "POST:ENTER");
        await _ui.PressAsync(_locators.HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner, "Enter");
        await _ui.PressAsync(_locators.HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner, "END");
        await _ui.PressAsync(_locators.HaveThereBeenAnyEPLClaimsSuitsOrComplaintsOrAreThereAnyNowPendingAgainstTheInsuredOrAnyExecutiveOfficerOrOwner, "Tab");
        // EQBOPAdditionalCoveragesAnswerEPLIQuestions_8f39e4Page.EQCommonLoadingIndicatorWait_0281_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPAdditionalCoveragesAnswerEPLIQuestions_8f39e4Page.EQBOPAdditionalCoveragesAnswerEPLIQuestions1_0282_d18a3eAsync
        await _ui.PressAsync(_locators.DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, "POST:ENTER");
        await _ui.PressAsync(_locators.DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, "Enter");
        await _ui.PressAsync(_locators.DoesTheInsuredAndAnyExecutiveOfficerOrOwnerHaveAnyKnowledgeOrInformationOfAnyActErrorOrOmissionWhichMightGiveRiseToAnEPLClaimSuitOrComplaint, "Tab");
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0283_d18a3eAsync
        _data.Set("Screen", _data.Resolve("{{data:screen_9}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0284_d18a3eAsync
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

    // Business step: I refer Application/Policy
    public async Task ReferApplicationPolicyAsync()
    {
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.CheckForREFER_0738_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.ReferRequestIssuance))
        {
            await _ui.VerifyAsync(_locators.ReferRequestIssuance, _data.Resolve("Absent"), "");
        }
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.CheckToSeeCoverageIsBoundExists_0739_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IsThisCoverageBound))
        {
            await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("Exists"), "");
        }
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.CheckIsCoverageBoundSelect_0740_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IsThisCoverageBound))
        {
            await _ui.VerifyAsync(_locators.IsThisCoverageBound, _data.Resolve("{{data:expected_is_this_coverage_bound_value_698}}"), "Value");
        }
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.AnswerIsCoverageBound_0741_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IsThisCoverageBound))
        {
            await _ui.PressAsync(_locators.IsThisCoverageBound, "POST:TAB");
            await _ui.PressAsync(_locators.IsThisCoverageBound, "Tab");
        }
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.REFER_0743_d18a3eAsync
        if (_data.Condition("'Refer Needed' == NULL"))
        {
            await _ui.ClickAsync(_locators.ReferRequestIssuance);
        }
        if (_data.Condition("'Refer Needed' != NULL"))
        {
            await _ui.ClickAsync(_locators.Approve);
        }
        await _ui.WaitAsync(_locators.IFRAMEDuckCreekPolicyIFRAMEOK, "Exists");
        await _ui.ClickAsync(_locators.IFRAMEDuckCreekPolicyIFRAMEOK);
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.CheckForIFRAME_0744_d18a3eAsync
        if (await _ui.ExistsAsync(_locators.IFRAME))
        {
            await _ui.VerifyAsync(_locators.IFRAME, _data.Resolve("Exists"), "");
        }
        // DCEQCommonSubmissionReferApplicationPolicy_13acc3Page.Wait1SecondForAMaxOf120Seconds_0745_d18a3eAsync
        if (_data.Condition("while check for IFRAME"))
        {
            await Task.Delay(1000);
        }
    }

    // Business step: I enter FPP
    public async Task EnterFPPAsync()
    {
        // CLEQSFPFarmPersonalPropertyEnterFPP_f093d3Page.EQSFPFarmPersonalProperty_0180_08f3f1Async
        await _ui.PressAsync(_locators.SearchByNameOrCode, "POST:ENTER");
        await _ui.PressAsync(_locators.SearchByNameOrCode, "Enter");
        await _ui.PressAsync(_locators.SearchByNameOrCode, "Tab");
        await _ui.PressAsync(_locators.CheckBox, "POST:TAB");
        await _ui.PressAsync(_locators.CheckBox, "Tab");
        await _ui.PressAsync(_locators.AddCoverage, "POST:TAB");
        await _ui.PressAsync(_locators.AddCoverage, "Tab");
        // CLEQSFPFarmPersonalPropertyEnterFPP_f093d3Page.EQSFPFPPAddCoverageAudioVisualData_0181_08f3f1Async
        await _ui.PressAsync(_locators.Description, "POST:ENTER");
        await _ui.PressAsync(_locators.Description, "Enter");
        await _ui.PressAsync(_locators.Description, "Tab");
        await _ui.PressAsync(_locators.Limit, "POST:ENTER");
        await _ui.PressAsync(_locators.Limit, "Enter");
        await _ui.PressAsync(_locators.Limit, "Tab");
        await _ui.FillAsync(_locators.Deductible, _data.Resolve("{{data:deductible_231}}"));
        await _ui.ClickAsync(_locators.Save);
        // EQCommonNavigateToScreen_b3fe17Page.BufferScreenName_0182_08f3f1Async
        _data.Set("Screen", _data.Resolve("{{data:screen_8}}"));
        // EQCommonNavigateToScreen_b3fe17Page.CheckIfOnCorrectScreen_0183_08f3f1Async
        if (!await _ui.ExistsAsync(_locators.ScreenHeading))
        {
            await _ui.VerifyAsync(_locators.ScreenHeading, _data.Resolve("Absent"), "");
        }
    }

}
