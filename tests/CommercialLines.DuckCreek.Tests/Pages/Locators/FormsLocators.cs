using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    public ILocator PageTitle => _page.Locator("[id=\"pageTitle\"]");

    public ILocator AddlInterests => _page.Locator("[id=\"pageTop\"]");



    public ILocator EffectiveDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Effective Date");

    public ILocator EmployerSLiabilityCheckBox => _page.Locator("[fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"], [data-fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"]");

    public ILocator ExpirationDate => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Expiration Date");


    public ILocator ImportPolicyDataButton => _page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true });

    public ILocator LiabilityLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Liability Limit*");

    public ILocator LoadingMessage => _page.Locator("[id=\"loadingMessage\"]");

    public ILocator PDLimit => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "PD Limit*");

    public ILocator PersonalAuto => _page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true });

    public ILocator PolicyNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Policy Number");

    public ILocator SessionID => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "sessionID");

    public ILocator StatusCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "StatusCode");

    public ILocator TotalSubjectPremium => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Total Subject Premium*");

    public ILocator Value => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "SearchValue");

}
