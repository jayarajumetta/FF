using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPBuildingEditAndVerifyClassInfo
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPBuildingEditAndVerifyClassInfo(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AddInventory => EQBOPBuildingEditAndVerifyClassInfoLocators.AddInventory(_page);

    public Task PressAddInventoryAsync(string key) => AddInventory.PressAsync(key);

    public Task DoubleClickAddInventoryAsync() => AddInventory.DblClickAsync();

    public Task ClickAddInventoryAsync() => AddInventory.ClickAsync();

    private ILocator ClassCodeTABLE => EQBOPBuildingEditAndVerifyClassInfoLocators.ClassCodeTABLE(_page);

    public Task PressClassCodeTABLEAsync(string key) => ClassCodeTABLE.PressAsync(key);

    public Task DoubleClickClassCodeTABLEAsync() => ClassCodeTABLE.DblClickAsync();

}
