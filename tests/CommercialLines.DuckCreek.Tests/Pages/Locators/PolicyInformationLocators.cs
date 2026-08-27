using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    // v57 raw Tosca:  | Add Client | guid=3a13d49c-1679-21d3-307d-9ac2d420ffb8 | strategy=role-link
    public ILocator Client => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    // v57 raw Tosca:  | Detail | guid=3a13d49c-1700-371e-c808-c1dcd0cae17d | strategy=role-link
    public ILocator Detail => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    // Source modules: Policy Info|Required and Optional Fields | confidence=Medium score=113
    // Applies only to BOP/BAP Tiering states
    public ILocator EnterPriorLossInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Enter Prior Loss Information", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator ExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator IsThereAPriorCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=High score=97
    public ILocator LossExperienceHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loss Experience Heading");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v57 raw Tosca: Pricing | Modification Factor | guid=3a13d49c-1697-4099-cdcb-b51261d5962d | strategy=retained-semantic
    public ILocator ModificationFactor => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-4099-cdcb-b51261d5962d");

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator OtherInsuranceHistoryOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v57 raw Tosca: Commercial Auto | Policy Number | guid=3a13d49c-171e-17ac-180b-20fce969d8b7 | strategy=retained-semantic
    public ILocator PolicyNumber => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-17ac-180b-20fce969d8b7");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

}
