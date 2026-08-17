using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class PolicyInformationPage
{
    private readonly PolicyInformationLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public PolicyInformationPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new PolicyInformationLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I complete underwriting information from the policy information screen
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync()
    {
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.ClickPriorLossInformationButton_0087_f90f36Async
        await _ui.ClickAsync(_locators.EnterPriorLossInformation);
        // UnderwritingInfoLossExperience_54b758Page.WaitForLossExperience_0088_f90f36Async
        await _ui.WaitAsync(_locators.LossExperienceHeading, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0089_f90f36Async
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_101}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        await _ui.VerifyAsync(_locators.NoKnownLosses, _data.Resolve("{{data:expected_no_known_losses_value_102}}"), "value");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0090_f90f36Async
        await Task.Delay(1000);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0091_f90f36Async
        await _ui.ClickAsync(_locators.InsuranceHistory);
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_106}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Enter");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "PRE:Tab");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.ClickAsync(_locators.IsThereAPriorCarrier);
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "CLICK");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_109}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_110}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_111}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_114}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_115}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail, "Exists");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0092_f90f36Async
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // ClientNamedInsuredCommon_9ad77bPage.WaitForSynchronization_0093_f90f36Async
        await _ui.WaitAsync(_locators.Client, "Exists");
    }

    // Business step: I complete underwriting information from the policy information screen
    public async Task CompleteUnderwritingInformationFromThePolicyInformationScreenAsync2()
    {
        // PolicyInfoRequiredAndOptionalFields_f7216aPage.ClickPriorLossInformationButton_0110_a6f47eAsync
        await _ui.ClickAsync(_locators.EnterPriorLossInformation);
        // UnderwritingInfoLossExperience_54b758Page.WaitForLossExperience_0111_a6f47eAsync
        await _ui.WaitAsync(_locators.LossExperienceHeading, "Exists");
        // UnderwritingInfoLossExperience_54b758Page.IndicateNoKnownLossesOnLossExperienceScreen_0112_a6f47eAsync
        await _ui.SmartSetAsync(_locators.NoKnownLosses, _data.Resolve("{{data:no_known_losses_144}}"));
        await _ui.PressAsync(_locators.NoKnownLosses, "Tab");
        await _ui.VerifyAsync(_locators.NoKnownLosses, _data.Resolve("{{data:expected_no_known_losses_value_145}}"), "value");
        // TBoxWait_7ea9e1Page.WaitForSynchronization_0113_a6f47eAsync
        await Task.Delay(1000);
        // UnderwritingInfoOtherInsuranceHistory_b78753Page.AddPriorCarriorDetailsOnLossInformationScreen_0114_a6f47eAsync
        await _ui.ClickAsync(_locators.InsuranceHistory);
        await _ui.WaitAsync(_locators.IsThereAPriorCarrier, "Exists");
        await _ui.FillAsync(_locators.IsThereAPriorCarrier, _data.Resolve("{{data:is_there_a_prior_carrier_149}}"));
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Enter");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "PRE:Tab");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.ClickAsync(_locators.IsThereAPriorCarrier);
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "CLICK");
        await _ui.PressAsync(_locators.IsThereAPriorCarrier, "Tab");
        await _ui.FillAsync(_locators.Carrier, _data.Resolve("{{data:carrier_152}}"));
        await _ui.PressAsync(_locators.Carrier, "Tab");
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_153}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.FillAsync(_locators.PolicyType, _data.Resolve("{{data:policy_type_154}}"));
        await _ui.PressAsync(_locators.PolicyType, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE[][-2y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        await _ui.FillAsync(_locators.ExpirationDate, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate, "Tab");
        await _ui.FillAsync(_locators.ModificationFactor, _data.Resolve("{{data:modificationfactor_157}}"));
        await _ui.PressAsync(_locators.ModificationFactor, "Tab");
        await _ui.FillAsync(_locators.TotalPremium, _data.Resolve("{{data:total_premium_158}}"));
        await _ui.PressAsync(_locators.TotalPremium, "Tab");
        await _ui.ClickAsync(_locators.OtherInsuranceHistoryOK);
        await _ui.WaitAsync(_locators.Detail, "Exists");
        // CommonNavigationLinks_dba56bPage.ClickReturnToQuote_0115_a6f47eAsync
        await _ui.ClickAsync(_locators.ReturnToQuote);
        // ClientNamedInsuredCommon_9ad77bPage.WaitForSynchronization_0116_a6f47eAsync
        await _ui.WaitAsync(_locators.Client, "Exists");
    }

}