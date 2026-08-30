using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    public ILocator Carrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Carrier");

    public ILocator Client => _page.GetByRole(AriaRole.Link, new() { Name = "Add Client", Exact = true });

    public ILocator Detail => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator EffectiveDate => _page.Locator("input[fieldref=\\"PolicyInput.EffectiveDate\\"]");

    public ILocator EnterPriorLossInformation => _page.GetByRole(AriaRole.Link, new() { Name = "Enter Prior Loss Information", Exact = true });

    public ILocator ExpirationDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Expiration Date");

    public ILocator InsuranceHistory => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance History", Exact = true });

    public ILocator IsThereAPriorCarrier => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Is there a Prior Carrier?*");

    public ILocator LossExperienceHeading => _page.Locator("[id=\"pageTitle\"]");

    public ILocator ModificationFactor => _page.Locator("input[fieldref=\"LineInput.ModificationFactor\"]");

    public ILocator NoKnownLosses => _page.GetByRole(AriaRole.Checkbox, new() { Name = "No known losses", Exact = true });

    public ILocator OtherInsuranceHistoryOK => _page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true });

    public ILocator PolicyNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Number");

    public ILocator PolicyType => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Type");

    public ILocator ReturnToQuote => _page.GetByRole(AriaRole.Link, new() { Name = "Return to Quote", Exact = true });

    public ILocator TotalPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Total Premium");
}
