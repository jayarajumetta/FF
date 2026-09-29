using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class PolicyInformationLocators
{
    private readonly IPage _page;
    public PolicyInformationLocators(IPage page) => _page = page;

    public ILocator Carrier => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.CarrierName\"]");

    public ILocator Client => _page.GetByRole(AriaRole.Link, new() { Name = "Add Client", Exact = true });

    public ILocator Detail => _page.Locator("[id=\"dctGridLink\"]");

    public ILocator EffectiveDate => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.EffectiveDate\"]");

    public ILocator EnterPriorLossInformation => _page.Locator("span.g-btn-text").Filter(new LocatorFilterOptions { HasText = "Enter Prior Loss Information" }).First;

    public ILocator ExpirationDate => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.ExpirationDate\"]");

    public ILocator InsuranceHistory => _page.Locator("span.g-btn-text").Filter(new LocatorFilterOptions { HasText = "Previous" }).First;

    public ILocator IsThereAPriorCarrier => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.CommercialAutoNoPriorCarrier\"]");

    public ILocator LossExperienceHeading => _page.Locator("[id=\"pageTitle\"]");

    public ILocator ModificationFactor => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.ModificationFactor\"]");

    public ILocator NoKnownLosses => _page.Locator("input[fieldref=\"PolicyUnderwritingInput.NoKnownLosses\"]");

    public ILocator OtherInsuranceHistoryOK => _page.Locator("span.g-btn-text").Filter(new LocatorFilterOptions { HasText = "OK" }).First;

    public ILocator PolicyNumber => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.PolicyNumber\"]");

    public ILocator PolicyType => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.PolicyType\"]");

    public ILocator ReturnToQuote => _page.Locator("span.g-btn-text").Filter(new LocatorFilterOptions { HasText = "Return to Quote" }).First;

    public ILocator TotalPremium => _page.Locator("input[fieldref=\"CommercialAutoHistoryInput.TotalPremium\"]");
}
