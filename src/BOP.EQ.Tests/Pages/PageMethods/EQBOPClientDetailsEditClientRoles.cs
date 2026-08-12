using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using InsuranceAutomation.Pages.PageLocators;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.Pages.PageMethods;

public sealed class EQBOPClientDetailsEditClientRoles
{
    private readonly IPage _page;
    private readonly ScenarioData _data;

    public EQBOPClientDetailsEditClientRoles(IPage page, ScenarioData data)
    {
        _page = page;
        _data = data;
    }

    private ILocator BusinessOwner => EQBOPClientDetailsEditClientRolesLocators.BusinessOwner(_page);

    public Task PressBusinessOwnerAsync(string key) => BusinessOwner.PressAsync(key);

    public Task DoubleClickBusinessOwnerAsync() => BusinessOwner.DblClickAsync();

    public Task ClickBusinessOwnerAsync() => BusinessOwner.ClickAsync();

    private ILocator NamedInsured => EQBOPClientDetailsEditClientRolesLocators.NamedInsured(_page);

    public Task PressNamedInsuredAsync(string key) => NamedInsured.PressAsync(key);

    public Task DoubleClickNamedInsuredAsync() => NamedInsured.DblClickAsync();

    public Task ClickNamedInsuredAsync() => NamedInsured.ClickAsync();

    private ILocator ThirdPartyDesignee => EQBOPClientDetailsEditClientRolesLocators.ThirdPartyDesignee(_page);

    public Task PressThirdPartyDesigneeAsync(string key) => ThirdPartyDesignee.PressAsync(key);

    public Task DoubleClickThirdPartyDesigneeAsync() => ThirdPartyDesignee.DblClickAsync();

    public Task ClickThirdPartyDesigneeAsync() => ThirdPartyDesignee.ClickAsync();

    private ILocator KeyIndividual => EQBOPClientDetailsEditClientRolesLocators.KeyIndividual(_page);

    public Task PressKeyIndividualAsync(string key) => KeyIndividual.PressAsync(key);

    public Task DoubleClickKeyIndividualAsync() => KeyIndividual.DblClickAsync();

    public Task ClickKeyIndividualAsync() => KeyIndividual.ClickAsync();

    private ILocator AuditContact => EQBOPClientDetailsEditClientRolesLocators.AuditContact(_page);

    public Task PressAuditContactAsync(string key) => AuditContact.PressAsync(key);

    public Task DoubleClickAuditContactAsync() => AuditContact.DblClickAsync();

    public Task SetAuditContactAsync(string value) =>
        UiActions.ApplyInputAsync(_page, AuditContact, _data.Resolve(value));

    public Task TypeAuditContactAsync(string value, float delayMs = 40) =>
        AuditContact.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    private ILocator InspectionContact => EQBOPClientDetailsEditClientRolesLocators.InspectionContact(_page);

    public Task PressInspectionContactAsync(string key) => InspectionContact.PressAsync(key);

    public Task DoubleClickInspectionContactAsync() => InspectionContact.DblClickAsync();

    public Task SetInspectionContactAsync(string value) =>
        UiActions.ApplyInputAsync(_page, InspectionContact, _data.Resolve(value));

    public Task TypeInspectionContactAsync(string value, float delayMs = 40) =>
        InspectionContact.PressSequentiallyAsync(_data.Resolve(value), new() { Delay = delayMs });

    public Task ClickAuditContactAsync() => AuditContact.ClickAsync();

    public Task ClickInspectionContactAsync() => InspectionContact.ClickAsync();
}
