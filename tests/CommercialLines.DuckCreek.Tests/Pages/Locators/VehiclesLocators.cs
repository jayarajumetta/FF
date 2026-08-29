using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    public ILocator CarrierName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier Name", Exact = true });

    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    public ILocator ExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    public ILocator IncludeMotorcycleLiability => _page.Locator("[fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"], [data-fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"]");

    public ILocator IncludeRecreationalVehicleLiability => _page.Locator("[fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"], [data-fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"]");

    public ILocator LiabilityLimit => _page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true });

    public ILocator MotorcycleLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-f277-7905-08e882cb4baa");

    public ILocator PDLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-1c33-a204-db3ffc91138e");

    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    public ILocator PolicyNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    public ILocator RecreationalVehicleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Recreational Vehicle Liability", Exact = true });

    public ILocator RecreationalVehicleLiabilityHeading => _page.Locator("[id=\"pageTitle\"]");

    public ILocator TotalSubjectPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true });
}
