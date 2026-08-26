using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class VehiclesLocators
{
    private readonly IPage _page;
    public VehiclesLocators(IPage page) => _page = page;

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v56 raw Tosca primary: Recreational Vehicle Liability | Carrier Name | DuckCreekId
    public ILocator CarrierName => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.CarrierName\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.CarrierName\"]");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v56 raw Tosca primary: Recreational Vehicle Liability | Effective Date | DuckCreekId | frame=iframe
    public ILocator EffectiveDate => _page.FrameLocator("iframe").Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.EffectiveDate\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.EffectiveDate\"]");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v56 raw Tosca primary: Recreational Vehicle Liability | Expiration Date | DuckCreekId
    public ILocator ExpirationDate => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.ExpirationDate\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.ExpirationDate\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Motorcycle Liability | attributes_fieldref
    public ILocator IncludeMotorcycleLiability => _page.Locator("[fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"], [data-fieldref=\"LineUmbrellaMotorcycleLiability.IncludeMotorcycleLiability\"]");

    // Source modules: Policy Covg | confidence=High score=124
    // v56 raw Tosca primary: Policy Covg | Include Recreational Vehicle Liability | attributes_fieldref
    public ILocator IncludeRecreationalVehicleLiability => _page.Locator("[fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"], [data-fieldref=\"LineUmbrellaRecreationalVehicleLiability.IncludeRecreationalVehicleLiability\"]");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v56 raw Tosca primary: Recreational Vehicle Liability | Liability Limit* | DuckCreekId
    public ILocator LiabilityLimit => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.LiabilityLimit\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.LiabilityLimit\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator MotorcycleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Motorcycle Liability", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=95
    // May be state specific?
    // v56 raw Tosca primary: Recreational Vehicle Liability | PD Limit* | DuckCreekId
    public ILocator PDLimit => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.PDLimit\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.PDLimit\"]");

    // Source modules: Policy Covg | confidence=High score=127
    // v56 raw Tosca primary: Policy Covg | Policy Covg | Id
    public ILocator PolicyCovg => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v56 raw Tosca primary: Recreational Vehicle Liability | Policy Number | DuckCreekId
    public ILocator PolicyNumber => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.PolicyNumber\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.PolicyNumber\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator RecreationalVehicleLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Recreational Vehicle Liability", Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=97
    // v56 raw Tosca primary: Recreational Vehicle Liability | Recreational Vehicle Liability Heading | Id
    // v56 semantic alias: same physical raw-Tosca control as PolicyCovg
    public ILocator RecreationalVehicleLiabilityHeading => PolicyCovg;

    // Source modules: Recreational Vehicle Liability | confidence=High score=125
    // v56 raw Tosca primary: Recreational Vehicle Liability | Total Subject Premium* | DuckCreekId
    public ILocator TotalSubjectPremium => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.TotalSubjectPremium\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.TotalSubjectPremium\"]");

}
