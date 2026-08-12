using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQAgentListCountCapture
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQAgentListCountCapture(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator DIVAgentDocumentsCount => EQAgentListCountCaptureLocators.DIVAgentDocumentsCount(_page);

    public Task PressDIVAgentDocumentsCountAsync(string key) => DIVAgentDocumentsCount.PressAsync(key);

    public Task DoubleClickDIVAgentDocumentsCountAsync() => DIVAgentDocumentsCount.DblClickAsync();

    public Task VerifyDIVAgentDocumentsCountAsync(string expected) =>
        Expect(DIVAgentDocumentsCount).ToContainTextAsync(_data.Resolve(expected));

    public async Task StoreDIVAgentDocumentsCountAsync(string key)
    {
        var value = await DIVAgentDocumentsCount.TextContentAsync() ?? await DIVAgentDocumentsCount.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

}
