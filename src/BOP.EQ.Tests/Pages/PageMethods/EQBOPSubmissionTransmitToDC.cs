using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPSubmissionTransmitToDC
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPSubmissionTransmitToDC(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator Transmit => EQBOPSubmissionTransmitToDCLocators.Transmit(_page);

    public Task PressTransmitAsync(string key) => Transmit.PressAsync(key);

    public Task DoubleClickTransmitAsync() => Transmit.DblClickAsync();

    public Task ClickTransmitAsync() => Transmit.ClickAsync();

}
