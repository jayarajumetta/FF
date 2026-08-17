using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    public ILocator CarrierName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier Name", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    public ILocator ExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeMotorcycleLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Motorcycle Liability", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    public ILocator IncludeRecreationalVehicleLiability => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Include Recreational Vehicle Liability", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    public ILocator LiabilityLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator MotorcycleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Motorcycle Liability", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=95
    // May be state specific?
    public ILocator PDLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "PD Limit*", Exact = true });

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovg => _page.GetByLabel("Policy Covg", new() { Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    public ILocator PolicyNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator RecreationalVehicleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Recreational Vehicle Liability", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=97
    public ILocator RecreationalVehicleLiabilityHeading => _page.GetByLabel("Recreational Vehicle Liability Heading", new() { Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    public ILocator TotalSubjectPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

}
