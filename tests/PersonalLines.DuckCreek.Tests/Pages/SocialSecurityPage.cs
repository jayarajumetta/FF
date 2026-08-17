using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class SocialSecurityPage
{
    private readonly SocialSecurityLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public SocialSecurityPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new SocialSecurityLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I review household\-driver prefill results
    public async Task ReviewHouseholdDriverPrefillResultsAsync()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0074_8f9ff6Async
        if (_data.Condition("'Additional Drivers?' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.DriverInformation);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0075_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        await _ui.WaitAsync(_locators.PrefilledDrivers, "Exists");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0076_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        _data.Set("NumberOfDrivers", await _ui.CaptureAsync(_locators.PrefilledDrivers, "ResultCount"));
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0077_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.MATFORMFIELD))
        {
        await _ui.FillAsync(_locators.MATFORMFIELD, _data.Resolve(""));
        }
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "PRE:return");
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "return");
        // EQPrefilHouseholdDrivers_d424d2Page.SaveContinue_0078_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0079_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.UnselectedClientSuggestions))
        {
        await _ui.VerifyAsync(_locators.UnselectedClientSuggestions, _data.Resolve("Exists"), "");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0080_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
    }

    // Business step: I review household\-driver prefill results
    public async Task ReviewHouseholdDriverPrefillResultsAsync2()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0074_8f5301Async
        if (_data.Condition("'Additional Drivers?' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.DriverInformation);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0075_8f5301Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        await _ui.WaitAsync(_locators.PrefilledDrivers, "Exists");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0076_8f5301Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        _data.Set("NumberOfDrivers", await _ui.CaptureAsync(_locators.PrefilledDrivers, "ResultCount"));
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0077_8f5301Async
        if (await _ui.ExistsAsync(_locators.MATFORMFIELD))
        {
        await _ui.FillAsync(_locators.MATFORMFIELD, _data.Resolve(""));
        }
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "PRE:return");
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "return");
        // EQPrefilHouseholdDrivers_d424d2Page.SaveContinue_0078_8f5301Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0079_8f5301Async
        if (await _ui.ExistsAsync(_locators.UnselectedClientSuggestions))
        {
        await _ui.VerifyAsync(_locators.UnselectedClientSuggestions, _data.Resolve("Exists"), "");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0080_8f5301Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0084_8f5301Async
        _data.Set("Farm/Use", _data.Get("Farm/Use"));
        _data.Set("PickUp", _data.Get("PickUp"));
        _data.Set("State", _data.Get("State"));
        _data.Set("Company", _data.Resolve("{{data:company}}"));
        _data.Set("Loan", _data.Get("Loan"));
        _data.Set("Lease", _data.Get("Lease"));
        _data.Set("AntiTheft", _data.Get("AntiTheft"));
        _data.Set("Business/Use", _data.Get("Business/Use"));
    }

    // Business step: I review household\-driver prefill results
    public async Task ReviewHouseholdDriverPrefillResultsAsync3()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0074_e2e0d7Async
        if (_data.Condition("'Additional Drivers?' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.DriverInformation);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0075_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        await _ui.WaitAsync(_locators.PrefilledDrivers, "Exists");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0076_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        _data.Set("NumberOfDrivers", await _ui.CaptureAsync(_locators.PrefilledDrivers, "ResultCount"));
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0077_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.MATFORMFIELD))
        {
        await _ui.FillAsync(_locators.MATFORMFIELD, _data.Resolve(""));
        }
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "PRE:return");
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "return");
        // EQPrefilHouseholdDrivers_d424d2Page.SaveContinue_0078_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0079_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.UnselectedClientSuggestions))
        {
        await _ui.VerifyAsync(_locators.UnselectedClientSuggestions, _data.Resolve("Exists"), "");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0080_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0084_e2e0d7Async
        _data.Set("Farm/Use", _data.Get("Farm/Use"));
        _data.Set("PickUp", _data.Get("PickUp"));
        _data.Set("State", _data.Resolve("{{data:state}}"));
        _data.Set("Company", _data.Resolve("{{data:company}}"));
        _data.Set("Loan", _data.Get("Loan"));
        _data.Set("Lease", _data.Get("Lease"));
        _data.Set("AntiTheft", _data.Get("AntiTheft"));
        _data.Set("Business/Use", _data.Get("Business/Use"));
    }

    // Business step: I review household\-driver prefill results
    public async Task ReviewHouseholdDriverPrefillResultsAsync4()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0074_bafd4aAsync
        if (_data.Condition("'Additional Drivers?' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.DriverInformation);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0075_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        await _ui.WaitAsync(_locators.PrefilledDrivers, "Exists");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0076_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        _data.Set("NumberOfDrivers", await _ui.CaptureAsync(_locators.PrefilledDrivers, "ResultCount"));
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0077_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.MATFORMFIELD))
        {
        await _ui.FillAsync(_locators.MATFORMFIELD, _data.Resolve(""));
        }
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "PRE:return");
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "return");
        // EQPrefilHouseholdDrivers_d424d2Page.SaveContinue_0078_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0079_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.UnselectedClientSuggestions))
        {
        await _ui.VerifyAsync(_locators.UnselectedClientSuggestions, _data.Resolve("Exists"), "");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0080_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0084_bafd4aAsync
        _data.Set("Farm/Use", _data.Get("Farm/Use"));
        _data.Set("PickUp", _data.Get("PickUp"));
        _data.Set("State", _data.Get("State"));
        _data.Set("Company", _data.Get("Company"));
        _data.Set("Loan", _data.Get("Loan"));
        _data.Set("Lease", _data.Get("Lease"));
        _data.Set("AntiTheft", _data.Get("AntiTheft"));
        _data.Set("Business/Use", _data.Get("Business/Use"));
    }

    // Business step: I review household\-driver prefill results
    public async Task ReviewHouseholdDriverPrefillResultsAsync5()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0074_8f4c8fAsync
        if (_data.Condition("'Additional Drivers?' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.DriverInformation);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0075_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        await _ui.WaitAsync(_locators.PrefilledDrivers, "Exists");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0076_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        _data.Set("NumberOfDrivers", await _ui.CaptureAsync(_locators.PrefilledDrivers, "ResultCount"));
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0077_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.MATFORMFIELD))
        {
        await _ui.FillAsync(_locators.MATFORMFIELD, _data.Resolve(""));
        }
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "PRE:return");
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "return");
        // EQPrefilHouseholdDrivers_d424d2Page.SaveContinue_0078_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0079_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.UnselectedClientSuggestions))
        {
        await _ui.VerifyAsync(_locators.UnselectedClientSuggestions, _data.Resolve("Exists"), "");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0080_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0084_8f4c8fAsync
        _data.Set("Farm/Use", _data.Get("Farm/Use"));
        _data.Set("PickUp", _data.Get("PickUp"));
        await _ui.FillAsync(_locators.State, _data.Get("AL_ClientData.State"));
        _data.Set("Company", _data.Resolve("{{data:company}}"));
        _data.Set("Loan", _data.Get("Loan"));
        _data.Set("Lease", _data.Get("Lease"));
        _data.Set("AntiTheft", _data.Get("AntiTheft"));
        _data.Set("Business/Use", _data.Get("Business/Use"));
    }

    // Business step: I review household\-driver prefill results
    public async Task ReviewHouseholdDriverPrefillResultsAsync6()
    {
        // EQSideMenu_e12e67Page.EQSideMenu_0074_10f911Async
        if (_data.Condition("'Additional Drivers?' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.DriverInformation);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0075_10f911Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        await _ui.WaitAsync(_locators.PrefilledDrivers, "Exists");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0076_10f911Async
        if (await _ui.ExistsAsync(_locators.PrefilledDrivers))
        {
        _data.Set("NumberOfDrivers", await _ui.CaptureAsync(_locators.PrefilledDrivers, "ResultCount"));
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0077_10f911Async
        if (await _ui.ExistsAsync(_locators.MATFORMFIELD))
        {
        await _ui.FillAsync(_locators.MATFORMFIELD, _data.Resolve(""));
        }
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "PRE:return");
        await _ui.PressAsync(_locators.NeverResidedInTheHouseholdAndDoesnTRegularlyUseOrHaveAccessToPolicyVehicleS, "return");
        // EQPrefilHouseholdDrivers_d424d2Page.SaveContinue_0078_10f911Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0079_10f911Async
        if (await _ui.ExistsAsync(_locators.UnselectedClientSuggestions))
        {
        await _ui.VerifyAsync(_locators.UnselectedClientSuggestions, _data.Resolve("Exists"), "");
        }
        // EQPrefilHouseholdDrivers_d424d2Page.PrefilHouseholdDrivers_0080_10f911Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue))
        {
        await _ui.ClickAsync(_locators.SaveAndContinue);
        }
    }

}