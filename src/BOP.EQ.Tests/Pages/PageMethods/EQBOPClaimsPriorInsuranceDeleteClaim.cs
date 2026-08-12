using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPClaimsPriorInsuranceDeleteClaim
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPClaimsPriorInsuranceDeleteClaim(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator DeleteTrashCan => EQBOPClaimsPriorInsuranceDeleteClaimLocators.DeleteTrashCan(_page);

    public Task PressDeleteTrashCanAsync(string key) => DeleteTrashCan.PressAsync(key);

    public Task DoubleClickDeleteTrashCanAsync() => DeleteTrashCan.DblClickAsync();

    public Task ClickDeleteTrashCanAsync() => DeleteTrashCan.ClickAsync();

    private ILocator Confirm => EQBOPClaimsPriorInsuranceDeleteClaimLocators.Confirm(_page);

    public Task PressConfirmAsync(string key) => Confirm.PressAsync(key);

    public Task DoubleClickConfirmAsync() => Confirm.DblClickAsync();

    public Task WaitForConfirmAsync() =>
        Confirm.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator DELETE => EQBOPClaimsPriorInsuranceDeleteClaimLocators.DELETE(_page);

    public Task PressDELETEAsync(string key) => DELETE.PressAsync(key);

    public Task DoubleClickDELETEAsync() => DELETE.DblClickAsync();

    public Task ClickDELETEAsync() => DELETE.ClickAsync();

}
