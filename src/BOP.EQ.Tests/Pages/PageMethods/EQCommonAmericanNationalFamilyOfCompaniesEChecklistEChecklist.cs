using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklist
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklist(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator AcknowledgementLetterX5201 => EQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklistLocators.AcknowledgementLetterX5201(_page);

    public Task PressAcknowledgementLetterX5201Async(string key) => AcknowledgementLetterX5201.PressAsync(key);

    public Task DoubleClickAcknowledgementLetterX5201Async() => AcknowledgementLetterX5201.DblClickAsync();

    public Task WaitForAcknowledgementLetterX5201Async() =>
        AcknowledgementLetterX5201.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator Attach => EQCommonAmericanNationalFamilyOfCompaniesEChecklistEChecklistLocators.Attach(_page);

    public Task PressAttachAsync(string key) => Attach.PressAsync(key);

    public Task DoubleClickAttachAsync() => Attach.DblClickAsync();

    public Task ClickAttachAsync() => Attach.ClickAsync();

}
