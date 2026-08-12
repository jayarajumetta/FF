using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class TransACTPolicyDetailsAttachments
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public TransACTPolicyDetailsAttachments(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator ViewPolicyDetails => TransACTPolicyDetailsAttachmentsLocators.ViewPolicyDetails(_page);

    public Task PressViewPolicyDetailsAsync(string key) => ViewPolicyDetails.PressAsync(key);

    public Task DoubleClickViewPolicyDetailsAsync() => ViewPolicyDetails.DblClickAsync();

    public Task ClickViewPolicyDetailsAsync() => ViewPolicyDetails.ClickAsync();

    private ILocator PolicyDetails => TransACTPolicyDetailsAttachmentsLocators.PolicyDetails(_page);

    public Task PressPolicyDetailsAsync(string key) => PolicyDetails.PressAsync(key);

    public Task DoubleClickPolicyDetailsAsync() => PolicyDetails.DblClickAsync();

    public Task VerifyPolicyDetailsAsync(string expected) =>
        Expect(PolicyDetails).ToContainTextAsync(_data.Resolve(expected));

    private ILocator AttachmentsListGrid => TransACTPolicyDetailsAttachmentsLocators.AttachmentsListGrid(_page);

    public Task PressAttachmentsListGridAsync(string key) => AttachmentsListGrid.PressAsync(key);

    public Task DoubleClickAttachmentsListGridAsync() => AttachmentsListGrid.DblClickAsync();

}
