using InsuranceAutomation.Core;
using InsuranceAutomation.CLEQ.Pages.Locators;

namespace InsuranceAutomation.CLEQ.Pages;

public sealed class LocationsPage
{
    private readonly LocationsLocators _locators;
    private readonly ScenarioData _data;
    private readonly PageUiActions _ui;

    public LocationsPage(BrowserSession browser, ScenarioData data, PageUiActions ui)
    {
        _locators = new LocationsLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I add a Location
    public async Task AddALocationAsync()
    {
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationLocDescAndMilesFD_0131_503012Async
        await _ui.ClickAsync(_locators.LocationLink);
        await _ui.WaitAsync(_locators.LocationDescription, "Exists");
        await _ui.PressAsync(_locators.LocationDescription, "POST:ENTER");
        await _ui.PressAsync(_locators.LocationDescription, "Enter");
        await _ui.PressAsync(_locators.LocationDescription, "Tab");
        await _ui.PressAsync(_locators.MilesFromFD, "POST:ENTER");
        await _ui.PressAsync(_locators.MilesFromFD, "Enter");
        await _ui.PressAsync(_locators.MilesFromFD, "Tab");
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0132_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationFireHydrantAndWindHail_0133_503012Async
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_161}}"));
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0134_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationFireHydrantAndWindHail_0135_503012Async
        await _ui.FillAsync(_locators.TotalFarmingAcreage, _data.Resolve("{{data:total_farming_acreage_163}}"));
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "POST:ENTER");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "Enter");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "Tab");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "POST:SCROLL[1]");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "SCROLL[1]");
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0136_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationFireHydrantAndWindHail_0137_503012Async
        if (_data.Condition("WindHail == \"1%\" && '1% Mandatory' != \"Yes\""))
        {
        await _ui.ClickAsync(_locators.WindHail1);
        }
        if (_data.Condition("WindHail == \"2%\""))
        {
        await _ui.ClickAsync(_locators.WindHail2);
        }
        if (_data.Condition("WindHail == \"5%\""))
        {
        await _ui.ClickAsync(_locators.WindHail5);
        }
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0141_503012Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CheckIfSaveExists_0142_503012Async
        if (await _ui.ExistsAsync(_locators.Save))
        {
        await _ui.VerifyAsync(_locators.Save, _data.Resolve("Exists"), "");
        }
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationClickSave_0143_503012Async
        if (await _ui.ExistsAsync(_locators.Save))
        {
        await _ui.ClickAsync(_locators.Save);
        }
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0144_503012Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Absent");
        }
    }

    // Business step: I complete edit a Location
    public async Task CompleteEditALocationAsync()
    {
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.EQBOPLocationsBuildingsEditLocationSelection_0151_d18a3eAsync
        await _ui.ClickAsync(_locators.EditLocationButtonLatestAngular);
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.EQCommonLoadingIndicatorWait_0152_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.EQBOPEditLocationSelectTerritoryDropdown_0153_d18a3eAsync
        await _ui.WaitAsync(_locators.EditLocationHeading, "Exists");
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.EQCommonLoadingIndicatorWait_0155_d18a3eAsync
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // EQBOPLocationsBuildingsEditALocation_13fc60Page.TerritoryAndFD_0160_d18a3eAsync
        await _ui.FillAsync(_locators.Territory, _data.Resolve("{{data:territory_188}}"));
        await _ui.PressAsync(_locators.MilesFromFireDept, "POST:CTRL+A");
        await _ui.PressAsync(_locators.MilesFromFireDept, "CTRL+A");
        await _ui.PressAsync(_locators.MilesFromFireDept, "Enter");
        await _ui.PressAsync(_locators.MilesFromFireDept, "Tab");
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feetfromhydrant_190}}"));
        await _ui.ClickAsync(_locators.Save);
        await _ui.WaitAsync(_locators.Save, "Absent");
        if (_data.Condition("'Order Wildfire Risk Score' == \"Yes\""))
        {
        await _ui.ClickAsync(_locators.OrderWildfireRiskScore);
        }
    }

    // Business step: I add a Location
    public async Task AddALocationAsync2()
    {
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationLocDescAndMilesFD_0131_08f3f1Async
        await _ui.ClickAsync(_locators.LocationLink);
        await _ui.WaitAsync(_locators.LocationDescription, "Exists");
        await _ui.PressAsync(_locators.LocationDescription, "POST:ENTER");
        await _ui.PressAsync(_locators.LocationDescription, "Enter");
        await _ui.PressAsync(_locators.LocationDescription, "Tab");
        await _ui.PressAsync(_locators.MilesFromFD, "POST:ENTER");
        await _ui.PressAsync(_locators.MilesFromFD, "Enter");
        await _ui.PressAsync(_locators.MilesFromFD, "Tab");
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0132_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationFireHydrantAndWindHail_0133_08f3f1Async
        await _ui.FillAsync(_locators.FeetFromHydrant, _data.Resolve("{{data:feet_from_hydrant_160}}"));
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0134_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationFireHydrantAndWindHail_0135_08f3f1Async
        await _ui.FillAsync(_locators.TotalFarmingAcreage, _data.Resolve("{{data:total_farming_acreage_162}}"));
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "POST:ENTER");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "Enter");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "Tab");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "POST:SCROLL[1]");
        await _ui.PressAsync(_locators.TotalFarmingAcreage, "SCROLL[1]");
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0136_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationFireHydrantAndWindHail_0137_08f3f1Async
        if (_data.Condition("WindHail == \"1%\" && '1% Mandatory' != \"Yes\""))
        {
        await _ui.ClickAsync(_locators.WindHail1);
        }
        if (_data.Condition("WindHail == \"2%\""))
        {
        await _ui.ClickAsync(_locators.WindHail2);
        }
        if (_data.Condition("WindHail == \"5%\""))
        {
        await _ui.ClickAsync(_locators.WindHail5);
        }
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0141_08f3f1Async
        await _ui.WaitAsync(_locators.Loading, "Absent");
        // CLEQSFPLocationAddALocation_99017dPage.CheckIfSaveExists_0142_08f3f1Async
        if (await _ui.ExistsAsync(_locators.Save))
        {
        await _ui.VerifyAsync(_locators.Save, _data.Resolve("Exists"), "");
        }
        // CLEQSFPLocationAddALocation_99017dPage.CLEQSFPLocationAddALocationClickSave_0143_08f3f1Async
        if (await _ui.ExistsAsync(_locators.Save))
        {
        await _ui.ClickAsync(_locators.Save);
        }
        // CLEQSFPLocationAddALocationCLEQCommonWaitOnLoadingIndicator_fb07bcPage.EQLoadingIndicatorWait_0144_08f3f1Async
        if (await _ui.ExistsAsync(_locators.Loading))
        {
        await _ui.WaitAsync(_locators.Loading, "Absent");
        }
    }

}