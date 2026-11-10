using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    public ILocator CarrierName => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.CarrierName\"]");

    public ILocator EffectiveDate => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.EffectiveDate\"]");

    public ILocator ExpirationDate => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.ExpirationDate\"]");

    public ILocator IncludeMotorcycleLiability => _page.Locator("input[fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"]");

    public ILocator IncludeRecreationalVehicleLiability => _page.Locator("input[fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"]");

    public ILocator LiabilityLimit => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.LiabilityLimit\"]");

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator RecreationalVehicleLiability => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Recreational Vehicle Liability" });

    public ILocator PDLimit => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.PDLimit\"]");

    public ILocator PolicyCovg => _page.Locator("[id=\"pageTitle\"]").GetByText("Policy Covg", new() { Exact = true });

    public ILocator PolicyNumber => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.PolicyNumber\"]");

    public ILocator TotalSubjectPremium => _page.Locator("input[fieldref=\"UmbrellaRecreationalVehicleLiabilityInput.TotalSubjectPremium\"]");
    public ILocator CommercialUMLimit => _page.Locator("input[fieldref*='UMLimit']");

}
