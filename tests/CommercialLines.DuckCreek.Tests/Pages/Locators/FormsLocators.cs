using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v56 raw Tosca primary: BAP Navigation Links | State Details - Detail | Id
    public ILocator AdditionalInterests => _page.Locator("[id=\"dctGridLink\"]");

    // Source modules: Additional Interests Schedule | confidence=High score=127
    // v56 raw Tosca primary: Additional Interests Schedule | Addl Interests | Id
    public ILocator AddlInterests => _page.Locator("[id=\"pageTop\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator Businessowners => _page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true });

    // Source modules: Businessowners | confidence=High score=97
    // v56 raw Tosca primary: Businessowners | Businessowners Heading | Id
    public ILocator BusinessownersHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Businessowners | confidence=High score=125
    // v56 raw Tosca primary: Businessowners | Effective Date | DuckCreekId | frame=iframe
    public ILocator EffectiveDate => _page.FrameLocator("iframe").Locator("[duckcreekid=\"UmbrellaBusinessOwnersInput.EffectiveDate\"], [data-duckcreekid=\"UmbrellaBusinessOwnersInput.EffectiveDate\"]");

    // Source modules: Businessowners | confidence=High score=94
    // Field opens if PRS is OH,WA,ND,WY
    // v56 raw Tosca primary: Businessowners | Employer's Liability CheckBox | attributes_fieldref
    public ILocator EmployerSLiabilityCheckBox => _page.Locator("[fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"], [data-fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"]");

    // Source modules: Businessowners | confidence=High score=125
    // v56 raw Tosca primary: Businessowners | Expiration Date | DuckCreekId
    public ILocator ExpirationDate => _page.Locator("[duckcreekid=\"UmbrellaBusinessOwnersInput.ExpirationDate\"], [data-duckcreekid=\"UmbrellaBusinessOwnersInput.ExpirationDate\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator HomeownerSLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Homeowner's Liability", Exact = true });

    // Source modules: Businessowners | confidence=High score=95
    // v56 raw Tosca primary: Businessowners | Import Policy Data Button | DuckCreekId
    public ILocator ImportPolicyDataButton => _page.Locator("[duckcreekid=\"Import Policy Data\"], [data-duckcreekid=\"Import Policy Data\"]");

    // Source modules: Commercial Auto | confidence=High score=125
    // v56 raw Tosca primary: Commercial Auto | Liability Limit* | DuckCreekId
    public ILocator LiabilityLimit => _page.Locator("[duckcreekid=\"UmbrellaCommercialAutoInput.LiabilityLimit\"], [data-duckcreekid=\"UmbrellaCommercialAutoInput.LiabilityLimit\"]");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => _page.GetByLabel("Loading Message", new() { Exact = true });

    // Source modules: Recreational Vehicle Liability | confidence=High score=95
    // May be state specific?
    // v56 raw Tosca primary: Recreational Vehicle Liability | PD Limit* | DuckCreekId
    public ILocator PDLimit => _page.Locator("[duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.PDLimit\"], [data-duckcreekid=\"UmbrellaRecreationalVehicleLiabilityInput.PDLimit\"]");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    // v56 raw Tosca primary: Businessowners | Policy Number | DuckCreekId
    public ILocator PolicyNumber => _page.Locator("[duckcreekid=\"UmbrellaBusinessOwnersInput.PolicyNumber\"], [data-duckcreekid=\"UmbrellaBusinessOwnersInput.PolicyNumber\"]");

    // Source modules:  | confidence=Review score=97
    public ILocator SessionID => _page.GetByLabel("sessionID", new() { Exact = true });

    // Source modules:  | confidence=Review score=97
    public ILocator StatusCode => _page.GetByLabel("StatusCode", new() { Exact = true });

    // Source modules: Businessowners | confidence=High score=125
    // v56 raw Tosca primary: Businessowners | Total Subject Premium* | DuckCreekId
    public ILocator TotalSubjectPremium => _page.Locator("[duckcreekid=\"UmbrellaBusinessOwnersInputPremiums.TotalSubjectPremium\"], [data-duckcreekid=\"UmbrellaBusinessOwnersInputPremiums.TotalSubjectPremium\"]");

    // Source modules:  | confidence=Review score=97
    public ILocator Value => _page.GetByLabel("value", new() { Exact = true });

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    public ILocator WatercraftLiability => _page.GetByRole(AriaRole.Link, new() { Name = "Watercraft Liability", Exact = true });

}
