using InsuranceAutomation.Core;
using InsuranceAutomation.CLDC.Pages.Locators;

namespace InsuranceAutomation.CLDC.Pages;

public sealed class VehiclesPage
{
    private readonly VehiclesLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public VehiclesPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new VehiclesLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I add Motorcycle Liability Underlying LOB
    public async Task AddMotorcycleLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectMotorcycleLiabilityUnderlyingLOB_0105_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovg, "Visible");
        await _ui.ClickAsync(_locators.IncludeMotorcycleLiability);
        // UMBNavigationLinks_77d89fPage.WaitForMotorcycleLiabilityTabToAppear_0106_f7819aAsync
        await _ui.WaitAsync(_locators.MotorcycleLiability, "Visible");
    }

    // Business step: I add Recreational Vehicle Liability Underlying LOB
    public async Task AddRecreationalVehicleLiabilityUnderlyingLOBAsync()
    {
        // PolicyCovg_0dff37Page.SelectRecreationalVehicleLiabilityUnderlyingLOB_0109_f7819aAsync
        await _ui.WaitAsync(_locators.PolicyCovg, "Visible");
        await _ui.ClickAsync(_locators.IncludeRecreationalVehicleLiability);
        // UMBNavigationLinks_77d89fPage.WaitForRecreationalVehicleLiabilityTabToAppear_0110_f7819aAsync
        await _ui.WaitAsync(_locators.RecreationalVehicleLiability, "Visible");
    }

    // Business step: I complete required recreational vehicle information
    public async Task CompleteRequiredRecreationalVehicleInformationAsync()
    {
        // UMBNavigationLinks_77d89fPage.ClickRVLink_0159_f7819aAsync
        await _ui.ClickAsync(_locators.RecreationalVehicleLiability);
        // RecreationalVehicleLiability_9339cePage.RecreationalVehicleLiability_0160_f7819aAsync
        await _ui.WaitAsync(_locators.RecreationalVehicleLiabilityHeading, "Visible");
        await _ui.FillAsync(_locators.PolicyNumber, _data.Resolve("{{data:policy_number_282}}"));
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.PressAsync(_locators.PolicyNumber, "Tab");
        await _ui.FillAsync(_locators.CarrierName, _data.Resolve("{{data:carrier_name_283}}"));
        await _ui.PressAsync(_locators.CarrierName, "Tab");
        await _ui.FillAsync(_locators.EffectiveDate, _data.Resolve("{DATE[][][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.EffectiveDate, "Tab");
        await _ui.WaitAsync(_locators.EffectiveDate, "NotEqual");
        await _ui.FillAsync(_locators.ExpirationDate, _data.Resolve("{DATE[][+1y][MM'/'dd'/'yyyy]}"));
        await _ui.PressAsync(_locators.ExpirationDate, "Tab");
        await _ui.FillAsync(_locators.LiabilityLimit, _data.Resolve("{{data:liability_limit_287}}"));
        await _ui.PressAsync(_locators.LiabilityLimit, "Tab");
        if (_data.Condition("'PD Limit' != NULL"))
        {
            await _ui.FillAsync(_locators.PDLimit, _data.Resolve("{{data:pd_limit_288}}"));
            await _ui.PressAsync(_locators.PDLimit, "Tab");
        }
        await _ui.FillAsync(_locators.TotalSubjectPremium, _data.Resolve("{{data:total_subject_premium_289}}"));
        await _ui.PressAsync(_locators.TotalSubjectPremium, "Tab");
    }

}
