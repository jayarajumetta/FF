using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonSubmissionPolicyFormsMain
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonSubmissionPolicyFormsMain(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PolicyForms => EQCommonSubmissionPolicyFormsMainLocators.PolicyForms(_page);

    public Task PressPolicyFormsAsync(string key) => PolicyForms.PressAsync(key);

    public Task DoubleClickPolicyFormsAsync() => PolicyForms.DblClickAsync();

    public Task ClickPolicyFormsAsync() => PolicyForms.ClickAsync();

    private ILocator PolicyFormsHeader => EQCommonSubmissionPolicyFormsMainLocators.PolicyFormsHeader(_page);

    public Task PressPolicyFormsHeaderAsync(string key) => PolicyFormsHeader.PressAsync(key);

    public Task DoubleClickPolicyFormsHeaderAsync() => PolicyFormsHeader.DblClickAsync();

    public Task WaitForPolicyFormsHeaderAsync() =>
        PolicyFormsHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator FormsSearch => EQCommonSubmissionPolicyFormsMainLocators.FormsSearch(_page);

    public Task PressFormsSearchAsync(string key) => FormsSearch.PressAsync(key);

    public Task DoubleClickFormsSearchAsync() => FormsSearch.DblClickAsync();

    public Task VerifyFormsSearchAsync(string expected) =>
        Expect(FormsSearch).ToContainTextAsync(_data.Resolve(expected));

}
