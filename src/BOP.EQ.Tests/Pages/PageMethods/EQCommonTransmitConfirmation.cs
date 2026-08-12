using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonTransmitConfirmation
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonTransmitConfirmation(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator NEWBUSINESSPACKET => EQCommonTransmitConfirmationLocators.NEWBUSINESSPACKET(_page);

    public Task PressNEWBUSINESSPACKETAsync(string key) => NEWBUSINESSPACKET.PressAsync(key);

    public Task DoubleClickNEWBUSINESSPACKETAsync() => NEWBUSINESSPACKET.DblClickAsync();

    public Task VerifyNEWBUSINESSPACKETAsync(string expected) =>
        Expect(NEWBUSINESSPACKET).ToContainTextAsync(_data.Resolve(expected));

}
