using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQCommonProposalStart
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQCommonProposalStart(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BusinessOwners => EQCommonProposalStartLocators.BusinessOwners(_page);

    public async Task SelectProductAsync(string lob)
    {
        switch ((lob ?? string.Empty).Trim().ToUpperInvariant())
        {
            case "BOP":
            case "BUSINESS OWNERS":
            case "BUSINESS OWNERS POLICY":
                await BusinessOwners.ClickAsync();
                break;
            case "PA":
            case "PERSONAL AUTO":
                await PersonalAuto.ClickAsync();
                break;
            case "MOTORCYCLE":
                await Motorcycle.ClickAsync();
                break;
            case "RV":
            case "RECREATIONAL VEHICLE":
                await RecreationalVehicle.ClickAsync();
                break;
            case "HOME":
                await Home.ClickAsync();
                break;
            case "ROP":
                await ROP.ClickAsync();
                break;
            case "SFP":
            case "SPECIAL FARM PACKAGE":
                await UiActions.ApplyInputAsync(_page, SpecialFarmPackage, "X");
                break;
            default:
                throw new InvalidOperationException($"Unsupported Proposal Start LOB '{lob}'. Product selection is intentionally not guessed.");
        }
    }

    public Task SelectRatingStateAsync(string value) =>
        UiActions.SelectFromOverlayAsync(_page, StateDropdown, _data.Resolve(value));

    private ILocator NewAccountAddress => EQCommonProposalStartLocators.NewAccountAddress(_page);
    public Task ClickNewAccountAddressAsync() => NewAccountAddress.ClickAsync();

    private ILocator PolicyTerm => EQCommonProposalStartLocators.PolicyTerm(_page);
    public Task SelectPolicyTermAsync(string value) =>
        UiActions.SelectFromOverlayAsync(_page, PolicyTerm, _data.Resolve(value));

    private ILocator ProposalDetailsHeader => EQCommonProposalStartLocators.ProposalDetailsHeader(_page);

    public Task PressProposalDetailsHeaderAsync(string key) => ProposalDetailsHeader.PressAsync(key);

    public Task DoubleClickProposalDetailsHeaderAsync() => ProposalDetailsHeader.DblClickAsync();

    public Task WaitForProposalDetailsHeaderAsync() =>
        ProposalDetailsHeader.WaitForAsync(new() { State = WaitForSelectorState.Visible });

    private ILocator PersonalAuto => EQCommonProposalStartLocators.PersonalAuto(_page);

    public Task PressPersonalAutoAsync(string key) => PersonalAuto.PressAsync(key);

    public Task DoubleClickPersonalAutoAsync() => PersonalAuto.DblClickAsync();

    public Task ClickPersonalAutoAsync() => PersonalAuto.ClickAsync();

    private ILocator Motorcycle => EQCommonProposalStartLocators.Motorcycle(_page);

    public Task PressMotorcycleAsync(string key) => Motorcycle.PressAsync(key);

    public Task DoubleClickMotorcycleAsync() => Motorcycle.DblClickAsync();

    public Task ClickMotorcycleAsync() => Motorcycle.ClickAsync();

    private ILocator RecreationalVehicle => EQCommonProposalStartLocators.RecreationalVehicle(_page);

    public Task PressRecreationalVehicleAsync(string key) => RecreationalVehicle.PressAsync(key);

    public Task DoubleClickRecreationalVehicleAsync() => RecreationalVehicle.DblClickAsync();

    public Task ClickRecreationalVehicleAsync() => RecreationalVehicle.ClickAsync();

    private ILocator Home => EQCommonProposalStartLocators.Home(_page);

    public Task PressHomeAsync(string key) => Home.PressAsync(key);

    public Task DoubleClickHomeAsync() => Home.DblClickAsync();

    public Task ClickHomeAsync() => Home.ClickAsync();

    private ILocator ROP => EQCommonProposalStartLocators.ROP(_page);

    public Task PressROPAsync(string key) => ROP.PressAsync(key);

    public Task DoubleClickROPAsync() => ROP.DblClickAsync();

    public Task ClickROPAsync() => ROP.ClickAsync();

    private ILocator SpecialFarmPackage => EQCommonProposalStartLocators.SpecialFarmPackage(_page);

    public Task PressSpecialFarmPackageAsync(string key) => SpecialFarmPackage.PressAsync(key);

    public Task DoubleClickSpecialFarmPackageAsync() => SpecialFarmPackage.DblClickAsync();

    public Task SetSpecialFarmPackageAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SpecialFarmPackage, _data.Resolve(value));

    public Task TypeSpecialFarmPackageAsync(string value, float delayMs = 40) =>
        SpecialFarmPackage.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator SelectSFPCE => EQCommonProposalStartLocators.SelectSFPCE(_page);

    public Task PressSelectSFPCEAsync(string key) => SelectSFPCE.PressAsync(key);

    public Task DoubleClickSelectSFPCEAsync() => SelectSFPCE.DblClickAsync();

    public Task ClickSelectSFPCEAsync() => SelectSFPCE.ClickAsync();

    private ILocator SearchBusinessName => EQCommonProposalStartLocators.SearchBusinessName(_page);

    public Task PressSearchBusinessNameAsync(string key) => SearchBusinessName.PressAsync(key);

    public Task DoubleClickSearchBusinessNameAsync() => SearchBusinessName.DblClickAsync();

    public Task SetSearchBusinessNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, SearchBusinessName, _data.Resolve(value));

    public Task TypeSearchBusinessNameAsync(string value, float delayMs = 40) =>
        SearchBusinessName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IndividuallyOwnedDBACheckBox => EQCommonProposalStartLocators.IndividuallyOwnedDBACheckBox(_page);

    public Task PressIndividuallyOwnedDBACheckBoxAsync(string key) => IndividuallyOwnedDBACheckBox.PressAsync(key);

    public Task DoubleClickIndividuallyOwnedDBACheckBoxAsync() => IndividuallyOwnedDBACheckBox.DblClickAsync();

    public Task SetIndividuallyOwnedDBACheckBoxAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IndividuallyOwnedDBACheckBox, _data.Resolve(value));

    public Task TypeIndividuallyOwnedDBACheckBoxAsync(string value, float delayMs = 40) =>
        IndividuallyOwnedDBACheckBox.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IndividuallyOwnedDBAOrTA => EQCommonProposalStartLocators.IndividuallyOwnedDBAOrTA(_page);

    public Task PressIndividuallyOwnedDBAOrTAAsync(string key) => IndividuallyOwnedDBAOrTA.PressAsync(key);

    public Task DoubleClickIndividuallyOwnedDBAOrTAAsync() => IndividuallyOwnedDBAOrTA.DblClickAsync();

    public Task SetIndividuallyOwnedDBAOrTAAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IndividuallyOwnedDBAOrTA, _data.Resolve(value));

    public Task TypeIndividuallyOwnedDBAOrTAAsync(string value, float delayMs = 40) =>
        IndividuallyOwnedDBAOrTA.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator IndividualDBA => EQCommonProposalStartLocators.IndividualDBA(_page);

    public Task PressIndividualDBAAsync(string key) => IndividualDBA.PressAsync(key);

    public Task DoubleClickIndividualDBAAsync() => IndividualDBA.DblClickAsync();

    public Task SetIndividualDBAAsync(string value) =>
        UiActions.ApplyInputAsync(_page, IndividualDBA, _data.Resolve(value));

    public Task TypeIndividualDBAAsync(string value, float delayMs = 40) =>
        IndividualDBA.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator EffectiveDate => EQCommonProposalStartLocators.EffectiveDate(_page);

    public Task PressEffectiveDateAsync(string key) => EffectiveDate.PressAsync(key);

    public Task DoubleClickEffectiveDateAsync() => EffectiveDate.DblClickAsync();

    public Task SetEffectiveDateAsync(string value) =>
        UiActions.ApplyInputAsync(_page, EffectiveDate, _data.Resolve(value));

    public Task TypeEffectiveDateAsync(string value, float delayMs = 40) =>
        EffectiveDate.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public async Task StoreEffectiveDateAsync(string key)
    {
        var value = await EffectiveDate.TextContentAsync() ?? await EffectiveDate.InputValueAsync();
        _data.SetBuffer(key, value ?? string.Empty);
    }

    private ILocator LessorsRiskNo => EQCommonProposalStartLocators.LessorsRiskNo(_page);

    public Task PressLessorsRiskNoAsync(string key) => LessorsRiskNo.PressAsync(key);

    public Task DoubleClickLessorsRiskNoAsync() => LessorsRiskNo.DblClickAsync();

    public Task SetLessorsRiskNoAsync(string value) =>
        UiActions.ApplyInputAsync(_page, LessorsRiskNo, _data.Resolve(value));

    public Task TypeLessorsRiskNoAsync(string value, float delayMs = 40) =>
        LessorsRiskNo.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StateDropdown => EQCommonProposalStartLocators.StateDropdown(_page);

    public Task PressStateDropdownAsync(string key) => StateDropdown.PressAsync(key);

    public Task DoubleClickStateDropdownAsync() => StateDropdown.DblClickAsync();

    public Task SetStateDropdownAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateDropdown, _data.Resolve(value));

    public Task TypeStateDropdownAsync(string value, float delayMs = 40) =>
        StateDropdown.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StateName => EQCommonProposalStartLocators.StateName(_page);

    public Task PressStateNameAsync(string key) => StateName.PressAsync(key);

    public Task DoubleClickStateNameAsync() => StateName.DblClickAsync();

    public Task SetStateNameAsync(string value) =>
        UiActions.ApplyInputAsync(_page, StateName, _data.Resolve(value));

    public Task TypeStateNameAsync(string value, float delayMs = 40) =>
        StateName.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator AgentPC => EQCommonProposalStartLocators.AgentPC(_page);

    public Task PressAgentPCAsync(string key) => AgentPC.PressAsync(key);

    public Task DoubleClickAgentPCAsync() => AgentPC.DblClickAsync();

    public Task SetAgentPCAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AgentPC, _data.Resolve(value));

    public Task TypeAgentPCAsync(string value, float delayMs = 40) =>
        AgentPC.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator StartQuote => EQCommonProposalStartLocators.StartQuote(_page);

    public Task PressStartQuoteAsync(string key) => StartQuote.PressAsync(key);

    public Task DoubleClickStartQuoteAsync() => StartQuote.DblClickAsync();

    public Task ClickStartQuoteAsync() => StartQuote.ClickAsync();

    public Task ClickIndividuallyOwnedDBACheckBoxAsync() => IndividuallyOwnedDBACheckBox.ClickAsync();

    public Task ClickIndividuallyOwnedDBAOrTAAsync() => IndividuallyOwnedDBAOrTA.ClickAsync();
}
