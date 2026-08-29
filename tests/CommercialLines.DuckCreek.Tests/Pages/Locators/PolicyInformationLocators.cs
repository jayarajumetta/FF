using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    public ILocator Carrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Carrier", Exact = true });

    public ILocator Client => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1679-21d3-307d-9ac2d420ffb8");

    public ILocator Detail => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1700-371e-c808-c1dcd0cae17d");

    public ILocator EffectiveDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true });

    public ILocator EnterPriorLossInformation => _page.GetByRole(AriaRole.Button, new() { Name = "Enter Prior Loss Information", Exact = true });

    public ILocator ExpirationDate => _page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true });

    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    public ILocator IsThereAPriorCarrier => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    public ILocator LossExperienceHeading => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loss Experience Heading");

    public ILocator ModificationFactor => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-4099-cdcb-b51261d5962d");

    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    public ILocator OtherInsuranceHistoryOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator PolicyNumber => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-17ac-180b-20fce969d8b7");

    public ILocator PolicyType => _page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Type", Exact = true });

    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    public ILocator TotalPremium => _page.GetByRole(AriaRole.Textbox, new() { Name = "Total Premium", Exact = true });
}
