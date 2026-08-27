using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v57 raw Tosca: Recreational Vehicle Liability | Carrier Name | guid=3a13d49c-171e-4441-8095-85585b7f05f1 | strategy=retained-semantic
    public ILocator CarrierName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier Name", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v57 raw Tosca: Recreational Vehicle Liability | Effective Date | guid=3a13d49c-171e-a4bf-59be-c9a301713091 | strategy=retained-semantic
    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v57 raw Tosca: Recreational Vehicle Liability | Expiration Date | guid=3a13d49c-171e-596b-ff6a-5d8ba3fba97a | strategy=retained-semantic
    public ILocator ExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Motorcycle Liability | guid=3a13d49c-16f1-e105-649e-bebdc5da66b8 | strategy=fieldref
    public ILocator IncludeMotorcycleLiability => _page.Locator("[fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"], [data-fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v57 raw Tosca: Policy Covg | Include Recreational Vehicle Liability | guid=3a13d49c-16f1-9e92-82a0-afe63256c55f | strategy=fieldref
    public ILocator IncludeRecreationalVehicleLiability => _page.Locator("[fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"], [data-fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"]");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v57 raw Tosca: Recreational Vehicle Liability | Liability Limit* | guid=3a13d49c-171e-02ea-6668-dea1d2cb3d74 | strategy=retained-semantic
    public ILocator LiabilityLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Motorcycle Liability | guid=3a13d49c-1697-f277-7905-08e882cb4baa | strategy=role-link
    public ILocator MotorcycleLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f277-7905-08e882cb4baa");

    // Source modules: Recreational Vehicle Liability | confidence=High score=95
    // May be state specific?
    // v57 raw Tosca: Recreational Vehicle Liability | PD Limit* | guid=3a13d49c-171e-1c33-a204-db3ffc91138e | strategy=retained-semantic
    public ILocator PDLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-1c33-a204-db3ffc91138e");

    // Source modules: Policy Covg | confidence=High score=127
    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v57 raw Tosca: Recreational Vehicle Liability | Policy Number | guid=3a13d49c-171e-7a85-58a7-292f81b08dcf | strategy=retained-semantic
    public ILocator PolicyNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Recreational Vehicle Liability | guid=3a13d49c-1697-167e-5a2a-b8df8bc2f4a5 | strategy=role-link
    public ILocator RecreationalVehicleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Recreational Vehicle Liability", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=97
    // v57 raw Tosca: Recreational Vehicle Liability | Recreational Vehicle Liability Heading | guid=3a13d49c-171e-edc7-8891-acd88e600b9f | strategy=id
    public ILocator RecreationalVehicleLiabilityHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v57 raw Tosca: Recreational Vehicle Liability | Total Subject Premium* | guid=3a13d49c-171e-4879-b5ef-e0c08e25c689 | strategy=retained-semantic
    public ILocator TotalSubjectPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });

}
