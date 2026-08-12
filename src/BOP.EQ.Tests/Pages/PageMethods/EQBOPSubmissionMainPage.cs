using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPSubmissionMainPage
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPSubmissionMainPage(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator NoReferralNeededVerification => EQBOPSubmissionMainPageLocators.NoReferralNeededVerification(_page);

    public Task PressNoReferralNeededVerificationAsync(string key) => NoReferralNeededVerification.PressAsync(key);

    public Task DoubleClickNoReferralNeededVerificationAsync() => NoReferralNeededVerification.DblClickAsync();

    public Task VerifyNoReferralNeededVerificationAsync(string expected) =>
        Expect(NoReferralNeededVerification).ToContainTextAsync(_data.Resolve(expected));

    private ILocator LaunchToChecklistButton => EQBOPSubmissionMainPageLocators.LaunchToChecklistButton(_page);

    public Task PressLaunchToChecklistButtonAsync(string key) => LaunchToChecklistButton.PressAsync(key);

    public Task DoubleClickLaunchToChecklistButtonAsync() => LaunchToChecklistButton.DblClickAsync();

    public Task ClickLaunchToChecklistButtonAsync() => LaunchToChecklistButton.ClickAsync();

    private ILocator ChecklistButtonSFP => EQBOPSubmissionMainPageLocators.ChecklistButtonSFP(_page);

    public Task PressChecklistButtonSFPAsync(string key) => ChecklistButtonSFP.PressAsync(key);

    public Task DoubleClickChecklistButtonSFPAsync() => ChecklistButtonSFP.DblClickAsync();

    public Task ClickChecklistButtonSFPAsync() => ChecklistButtonSFP.ClickAsync();

}
