using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQProposalDetailsStart
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQProposalDetailsStart(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator PersonalAuto => EQProposalDetailsStartLocators.PersonalAuto(_page);

    public Task PressPersonalAutoAsync(string key) => PersonalAuto.PressAsync(key);

    public Task DoubleClickPersonalAutoAsync() => PersonalAuto.DblClickAsync();

    public Task SetPersonalAutoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, PersonalAuto, _data.Resolve(value));

    public Task TypePersonalAutoAsync(string value, float delayMs = 40) =>
        PersonalAuto.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator Motorcycle => EQProposalDetailsStartLocators.Motorcycle(_page);

    public Task PressMotorcycleAsync(string key) => Motorcycle.PressAsync(key);

    public Task DoubleClickMotorcycleAsync() => Motorcycle.DblClickAsync();

    public Task SetMotorcycleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, Motorcycle, _data.Resolve(value));

    public Task TypeMotorcycleAsync(string value, float delayMs = 40) =>
        Motorcycle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator RecreationalVehicle => EQProposalDetailsStartLocators.RecreationalVehicle(_page);

    public Task PressRecreationalVehicleAsync(string key) => RecreationalVehicle.PressAsync(key);

    public Task DoubleClickRecreationalVehicleAsync() => RecreationalVehicle.DblClickAsync();

    public Task SetRecreationalVehicleAsync(string value) =>
        UiActions.ApplyInputAsync(_page, RecreationalVehicle, _data.Resolve(value));

    public Task TypeRecreationalVehicleAsync(string value, float delayMs = 40) =>
        RecreationalVehicle.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator EffectiveDate => EQProposalDetailsStartLocators.EffectiveDate(_page);

    public Task PressEffectiveDateAsync(string key) => EffectiveDate.PressAsync(key);

    public Task DoubleClickEffectiveDateAsync() => EffectiveDate.DblClickAsync();

    public Task SetEffectiveDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, EffectiveDate, _data.Resolve(value));

    public Task TypeEffectiveDateAsync(string value, float delayMs = 40) =>
        EffectiveDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AgentCode => EQProposalDetailsStartLocators.AgentCode(_page);

    public Task PressAgentCodeAsync(string key) => AgentCode.PressAsync(key);

    public Task DoubleClickAgentCodeAsync() => AgentCode.DblClickAsync();

    public Task SetAgentCodeAsync(string value) =>
        AgentCode.SelectOptionAsync(_data.Resolve(value));

    private ILocator State => EQProposalDetailsStartLocators.State(_page);

    public Task PressStateAsync(string key) => State.PressAsync(key);

    public Task DoubleClickStateAsync() => State.DblClickAsync();

    public Task SetStateAsync(string value) =>
        State.SelectOptionAsync(_data.Resolve(value));

    private ILocator WritingCompany => EQProposalDetailsStartLocators.WritingCompany(_page);

    public Task PressWritingCompanyAsync(string key) => WritingCompany.PressAsync(key);

    public Task DoubleClickWritingCompanyAsync() => WritingCompany.DblClickAsync();

    public Task SetWritingCompanyAsync(string value) =>
        WritingCompany.SelectOptionAsync(_data.Resolve(value));

    private ILocator CountyComboBox => EQProposalDetailsStartLocators.CountyComboBox(_page);

    public Task PressCountyComboBoxAsync(string key) => CountyComboBox.PressAsync(key);

    public Task DoubleClickCountyComboBoxAsync() => CountyComboBox.DblClickAsync();

    public Task SetCountyComboBoxAsync(string value) =>
        CountyComboBox.SelectOptionAsync(_data.Resolve(value));

    public Task VerifyCountyComboBoxAsync(string expected) =>
        Expect(CountyComboBox).ToContainTextAsync(_data.Resolve(expected));

    private ILocator CountyYes => EQProposalDetailsStartLocators.CountyYes(_page);

    public Task PressCountyYesAsync(string key) => CountyYes.PressAsync(key);

    public Task DoubleClickCountyYesAsync() => CountyYes.DblClickAsync();

    public Task ClickCountyYesAsync() => CountyYes.ClickAsync();

    public Task WaitForCountyYesAsync() =>
        CountyYes.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator StartQuote => EQProposalDetailsStartLocators.StartQuote(_page);

    public Task PressStartQuoteAsync(string key) => StartQuote.PressAsync(key);

    public Task DoubleClickStartQuoteAsync() => StartQuote.DblClickAsync();

    public Task ClickStartQuoteAsync() => StartQuote.ClickAsync();

    public Task WaitForStartQuoteAsync() =>
        StartQuote.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator StateName => EQProposalDetailsStartLocators.StateName(_page);

    public Task PressStateNameAsync(string key) => StateName.PressAsync(key);

    public Task DoubleClickStateNameAsync() => StateName.DblClickAsync();

    public Task SetStateNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateName, _data.Resolve(value));

    public Task TypeStateNameAsync(string value, float delayMs = 40) =>
        StateName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator PROCEED => EQProposalDetailsStartLocators.PROCEED(_page);

    public Task PressPROCEEDAsync(string key) => PROCEED.PressAsync(key);

    public Task DoubleClickPROCEEDAsync() => PROCEED.DblClickAsync();

    public Task ClickPROCEEDAsync() => PROCEED.ClickAsync();

    public Task WaitForPROCEEDAsync() =>
        PROCEED.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    public Task ClickMotorcycleAsync() => Motorcycle.ClickAsync();

    public Task ClickPersonalAutoAsync() => PersonalAuto.ClickAsync();

    public Task ClickRecreationalVehicleAsync() => RecreationalVehicle.ClickAsync();

    public Task ClickStateAsync() => State.ClickAsync();

    public Task ClickWritingCompanyAsync() => WritingCompany.ClickAsync();
}
