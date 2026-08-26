using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    // v56 raw Tosca primary:  | Add Client | DuckCreekId | frame=iframe
    public ILocator Client => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Add Client\"], [data-duckcreekid=\"Add Client\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    // v56 raw Tosca primary:  | Detail | DuckCreekId | frame=iframe
    public ILocator Detail => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Detail\"], [data-duckcreekid=\"Detail\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: Employers Liability | Effective Date | DuckCreekId | frame=iframe
    public ILocator EffectiveDate => _page.FrameLocator("iframe").Locator("[duckcreekid=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"], [data-duckcreekid=\"UmbrellaEmployersLiabilityInput.EffectiveDate\"]");

    // Source modules: Policy Info|Required and Optional Fields | confidence=Medium score=113
    // Applies only to BOP/BAP Tiering states
    public ILocator EnterPriorLossInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Enter Prior Loss Information", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: Employers Liability | Expiration Date | DuckCreekId
    public ILocator ExpirationDate => _page.Locator("[duckcreekid=\"UmbrellaEmployersLiabilityInput.ExpirationDate\"], [data-duckcreekid=\"UmbrellaEmployersLiabilityInput.ExpirationDate\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial General Liability History | Is there a Prior Carrier? | Id+Name+DuckCreekId
    public ILocator IsThereAPriorCarrier => _page.Locator("input[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"][name=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"][duckcreekid=\"PolicyUnderwritingInput.CommercialGeneralLiabilityNoPriorCarrier\"]");

    // Source modules: Underwriting Info | Loss Experience | confidence=High score=97
    public ILocator LossExperienceHeading => _page.GetByLabel("Loss Experience Heading", new() { Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: Pricing | Modification Factor | DuckCreekId
    public ILocator ModificationFactor => _page.Locator("[duckcreekid=\"LineInput.ModificationFactor\"], [data-duckcreekid=\"LineInput.ModificationFactor\"]");

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    // v56 raw Tosca primary:  | OK | Id+DuckCreekId | frame=iframe
    public ILocator OtherInsuranceHistoryOK => _page.FrameLocator("iframe").Locator("a[id=\"ext-element-18\"][duckcreekid=\"OK\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: Commercial Auto | Policy Number | DuckCreekId
    public ILocator PolicyNumber => _page.Locator("[duckcreekid=\"UmbrellaCommercialAutoInput.PolicyNumber\"], [data-duckcreekid=\"UmbrellaCommercialAutoInput.PolicyNumber\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

}
