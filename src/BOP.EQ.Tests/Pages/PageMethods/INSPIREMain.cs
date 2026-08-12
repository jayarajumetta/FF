using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class INSPIREMain
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public INSPIREMain(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ConfirmBusinessOwnersForPolicy => INSPIREMainLocators.ConfirmBusinessOwnersForPolicy(_page);

    public Task PressConfirmBusinessOwnersForPolicyAsync(string key) => ConfirmBusinessOwnersForPolicy.PressAsync(key);

    public Task DoubleClickConfirmBusinessOwnersForPolicyAsync() => ConfirmBusinessOwnersForPolicy.DblClickAsync();

    public Task VerifyConfirmBusinessOwnersForPolicyAsync(string expected) =>
        Expect(ConfirmBusinessOwnersForPolicy).ToContainTextAsync(_data.Resolve(expected));

    public Task WaitForConfirmBusinessOwnersForPolicyAsync() =>
        ConfirmBusinessOwnersForPolicy.WaitForAsync(new() { State = WaitForSelectorState.Visible });

}
