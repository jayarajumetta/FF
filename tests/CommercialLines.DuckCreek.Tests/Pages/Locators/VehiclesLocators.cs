using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    public ILocator CarrierName => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Carrier Name");

    public ILocator EffectiveDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Effective Date");

    public ILocator ExpirationDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Expiration Date");

    public ILocator IncludeMotorcycleLiability => _page.Locator("[fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"], [data-fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"]");

    public ILocator IncludeRecreationalVehicleLiability => _page.Locator("[fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"], [data-fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"]");

    public ILocator LiabilityLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Liability Limit*");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator PDLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "PD Limit*");

    public ILocator PolicyCovg => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Covg");

    public ILocator PolicyNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Number");



    public ILocator TotalSubjectPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Total Subject Premium*");
}
