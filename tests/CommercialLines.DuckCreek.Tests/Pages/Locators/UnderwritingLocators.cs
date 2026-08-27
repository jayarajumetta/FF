using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules:  | confidence=High score=95
    public ILocator Accept => _page.GetByRole(AriaRole.Button, new() { Name = "Accept", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial General Liability History | confidence=High score=127
    // v57 raw Tosca: CPP|Client|Underwriting Info|Commercial General Liability History | Commercial General Liability History | guid=3a13d49c-172d-86f0-a20c-1ad4f070b7d2 | strategy=id
    public ILocator CommercialGeneralLiabilityHistoryC65BF => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    // v57 raw Tosca: CPP|Client|Underwriting Info|Navigation | Commercial General Liability History | guid=3a13d49c-172d-ae38-1941-8d1e4082228d | strategy=role-link
    public ILocator CommercialGeneralLiabilityHistoryE02F8 => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial General Liability History", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial Property History | confidence=High score=127
    // v57 raw Tosca: CPP|Client|Underwriting Info|Commercial Property History | Commercial Property History | guid=3a13d49c-172d-335c-7708-0967cbda2e02 | strategy=id
    public ILocator CommercialPropertyHistory76D22 => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    // v57 raw Tosca: CPP|Client|Underwriting Info|Navigation | Commercial Property History | guid=3a13d49c-172d-5503-272e-b5782cc03f30 | strategy=role-link
    public ILocator CommercialPropertyHistoryE6A7F => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Property History", Exact = true });

    // Source modules: Underwriting Info | General UW Questions | confidence=High score=127
    public ILocator GeneralUWQuestions55852 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "General UW Questions");

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    // v57 raw Tosca: CPP|Client|Underwriting Info|Navigation | General UW Questions | guid=3a13d49c-172d-74d3-c828-418266202d01 | strategy=role-link
    public ILocator GeneralUWQuestionsBFB08 => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    // CPP (CR, GL, CP, IM), BOP, BAP
    public ILocator InsuranceScore => _page.GetByRole(AriaRole.Button, new() { Name = "Insurance Score", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    // BAP Only (VT)
    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Link, new() { Name = "Insurance Score Consent", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial Property History | confidence=High score=125
    // v57 raw Tosca: CPP|Client|Underwriting Info|Commercial Property History | Is there a Prior Carrier? | guid=3a13d49c-172d-db0e-d4df-810f9259f8cd | strategy=id
    public ILocator IsThereAPriorCarrier5D30E => _page.Locator("[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB7_1_1-inputEl\"]");

    // Source modules: CPP|Client|Underwriting Info|Commercial General Liability History | confidence=High score=125
    // v57 raw Tosca: CPP|Client|Underwriting Info|Commercial General Liability History | Is there a Prior Carrier? | guid=3a13d49c-172d-6e5a-b974-937aaebf04f1 | strategy=id
    public ILocator IsThereAPriorCarrierA9EB5 => _page.Locator("[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator IsThereAPriorCarrierEFB4F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=127
    public ILocator OtherInsuranceHistory416B1 => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Other Insurance History");

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    // v57 raw Tosca: CPP|Client|Underwriting Info|Navigation | Other Insurance History | guid=3a13d49c-172d-e104-e37b-841bea78737c | strategy=role-link
    public ILocator OtherInsuranceHistory5AFD8 => _page.GetByRole(AriaRole.Link, new() { Name = "Other Insurance History", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=Review score=97
    public ILocator ReferenceNumber => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "Reference Number");

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => InsuranceAutomation.Core.LocatorResolution.ByAssociatedLabel(_page, "The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS");

    // Source modules: Underwriting Info | General UW Questions | confidence=Medium score=113
    // v57 raw Tosca: Specific Underwriting Questions - Contractors Equipment | Update Answers | guid=3a13d49c-172d-a0a4-7d37-fbe634036887 | strategy=role-link
    public ILocator UpdateAnswers => CanonicalDuckCreekLocatorFactory.ByModuleAttributeGuid(_page, "3a13d49c-172d-a0a4-7d37-fbe634036887");

}
