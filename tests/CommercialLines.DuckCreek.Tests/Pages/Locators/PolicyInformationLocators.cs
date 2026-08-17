using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    // Source modules: Client|Named Insured|Common | confidence=High score=127
    public ILocator Client => _page.GetByLabel("Client", new() { Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator Detail => _page.GetByRole(AriaRole.Button, new() { Name = "Detail", Exact = true });

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
    public ILocator LossExperienceHeading => _page.GetByLabel("Loss Experience Heading", new() { Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator ModificationFactor => _page.GetByRole(AriaRole.Textbox, new() { Name = "ModificationFactor", Exact = true });

    // Source modules: Underwriting Info | Loss Experience | confidence=Medium score=113
    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=125
    public ILocator OtherInsuranceHistoryOK => _page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyNumber => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    // Source modules: Common Navigation Links | confidence=Medium score=113
    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });

}