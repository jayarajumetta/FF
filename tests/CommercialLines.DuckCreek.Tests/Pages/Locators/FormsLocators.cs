using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    public ILocator AdditionalInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-c094-cab0-01ca8db25c92");

    public ILocator AddlInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7");

    public ILocator Businessowners => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-10a4-df69-6f4dc21706f3");

    public ILocator BusinessownersHeading => _page.Locator("[id=\"pageTitle\"]");

    public ILocator EffectiveDate => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ac3b-2048-796e25a28c0b");

    public ILocator EmployerSLiabilityCheckBox => _page.Locator("[fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"], [data-fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"]");

    public ILocator ExpirationDate => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-62eb-1046-d8904ca7eb14");

    public ILocator HomeownerSLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b30f-c867-596198679155");

    public ILocator ImportPolicyDataButton => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-5b7e-1059-24533633c948");

    public ILocator LiabilityLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-4b30-555c-4b79b411c0fd");

    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    public ILocator PDLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-1c33-a204-db3ffc91138e");

    public ILocator PersonalAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ae5b-45b5-df53d1fb9b8f");

    public ILocator PolicyNumber => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-2795-c091-4c635a79407e");

    public ILocator SessionID => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "sessionID");

    public ILocator StatusCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "StatusCode");

    public ILocator TotalSubjectPremium => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-68c5-7803-bcdd157945fb");

    public ILocator Value => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc");

    public ILocator WatercraftLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-3ef2-a3f1-10c0a03b8675");
}
