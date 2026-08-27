using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class FormsLocators
{
    private readonly IPage _page;
    public FormsLocators(IPage page) => _page = page;

    // Source modules: BAP Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: BAP Navigation Links | Additional Interests | guid=3a13d49c-1688-c094-cab0-01ca8db25c92 | strategy=role-link
    public ILocator AdditionalInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-c094-cab0-01ca8db25c92");

    // Source modules: Additional Interests Schedule | confidence=High score=127
    // v57 raw Tosca: Additional Interests Schedule | Addl Interests | guid=3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7 | strategy=id
    public ILocator AddlInterests => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Businessowners | guid=3a13d49c-1697-10a4-df69-6f4dc21706f3 | strategy=role-link
    public ILocator Businessowners => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-10a4-df69-6f4dc21706f3");

    // Source modules: Businessowners | confidence=High score=97
    // v57 raw Tosca: Businessowners | Businessowners Heading | guid=3a13d49c-1697-aa23-d1b3-f9e55696d8f8 | strategy=id
    public ILocator BusinessownersHeading => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Effective Date | guid=3a13d49c-1697-ac3b-2048-796e25a28c0b | strategy=retained-semantic
    public ILocator EffectiveDate => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ac3b-2048-796e25a28c0b");

    // Source modules: Businessowners | confidence=High score=94
    // Field opens if PRS is OH,WA,ND,WY
    // v57 raw Tosca: Businessowners | Employer's Liability CheckBox | guid=3a13d49c-1697-0525-b517-f29eae1fd064 | strategy=fieldref
    public ILocator EmployerSLiabilityCheckBox => _page.Locator("[fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"], [data-fieldref=\"UmbrellaBusinessOwnersInput.EmployersLiability\"]");

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Expiration Date | guid=3a13d49c-1697-62eb-1046-d8904ca7eb14 | strategy=retained-semantic
    public ILocator ExpirationDate => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-62eb-1046-d8904ca7eb14");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Homeowner's Liability | guid=3a13d49c-1697-b30f-c867-596198679155 | strategy=role-link
    public ILocator HomeownerSLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-b30f-c867-596198679155");

    // Source modules: Businessowners | confidence=High score=95
    // v57 raw Tosca: Businessowners | Import Policy Data Button | guid=3a13d49c-1697-5b7e-1059-24533633c948 | strategy=role-link
    public ILocator ImportPolicyDataButton => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-5b7e-1059-24533633c948");

    // Source modules: Commercial Auto | confidence=High score=125
    // v57 raw Tosca: Commercial Auto | Liability Limit* | guid=3a13d49c-171e-4b30-555c-4b79b411c0fd | strategy=retained-semantic
    public ILocator LiabilityLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-4b30-555c-4b79b411c0fd");

    // Source modules: Indicators and Errors | confidence=High score=127
    // This DIV appears during a refresh of the screen (working in the background) and can be used as a WaitOn for stability.
    public ILocator LoadingMessage => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Loading Message");

    // Source modules: Recreational Vehicle Liability | confidence=High score=95
    // May be state specific?
    // v57 raw Tosca: Recreational Vehicle Liability | PD Limit* | guid=3a13d49c-171e-1c33-a204-db3ffc91138e | strategy=retained-semantic
    public ILocator PDLimit => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-171e-1c33-a204-db3ffc91138e");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Personal Auto | guid=3a13d49c-1697-ae5b-45b5-df53d1fb9b8f | strategy=role-link
    public ILocator PersonalAuto => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-ae5b-45b5-df53d1fb9b8f");

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Policy Number | guid=3a13d49c-1697-2795-c091-4c635a79407e | strategy=retained-semantic
    public ILocator PolicyNumber => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-2795-c091-4c635a79407e");

    // Source modules:  | confidence=Review score=97
    public ILocator SessionID => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "sessionID");

    // Source modules:  | confidence=Review score=97
    public ILocator StatusCode => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "StatusCode");

    // Source modules: Businessowners | confidence=High score=125
    // v57 raw Tosca: Businessowners | Total Subject Premium* | guid=3a13d49c-1697-68c5-7803-bcdd157945fb | strategy=retained-semantic
    public ILocator TotalSubjectPremium => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-68c5-7803-bcdd157945fb");

    // Source modules:  | confidence=Review score=97
    // v57 raw Tosca:  | SearchValue | guid=3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc | strategy=associatedlabel-from-v55
    public ILocator Value => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc");

    // Source modules: UMB Navigation Links | confidence=Medium score=113
    // v57 raw Tosca: UMB Navigation Links | Watercraft Liability | guid=3a13d49c-1697-3ef2-a3f1-10c0a03b8675 | strategy=role-link
    public ILocator WatercraftLiability => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-1697-3ef2-a3f1-10c0a03b8675");

}
