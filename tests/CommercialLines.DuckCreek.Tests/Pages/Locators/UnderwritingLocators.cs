using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules:  | confidence=High score=95
    public ILocator Accept => _page.GetByRole(AriaRole.Button, new() { Name = "Accept", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial General Liability History | confidence=High score=127
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial General Liability History | Commercial General Liability History | Id
    public ILocator CommercialGeneralLiabilityHistoryC65BF => _page.Locator("[id=\"pageTitle\"]");

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial General Liability History | Commercial General Liability History | Id
    // v56 semantic alias: same physical raw-Tosca control as CommercialGeneralLiabilityHistoryC65BF
    public ILocator CommercialGeneralLiabilityHistoryE02F8 => CommercialGeneralLiabilityHistoryC65BF;

    // Source modules: CPP|Client|Underwriting Info|Commercial Property History | confidence=High score=127
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial Property History | Commercial Property History | Id
    // v56 semantic alias: same physical raw-Tosca control as CommercialGeneralLiabilityHistoryC65BF
    public ILocator CommercialPropertyHistory76D22 => CommercialGeneralLiabilityHistoryC65BF;

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial Property History | Commercial Property History | Id
    // v56 semantic alias: same physical raw-Tosca control as CommercialGeneralLiabilityHistoryC65BF
    public ILocator CommercialPropertyHistoryE6A7F => CommercialGeneralLiabilityHistoryC65BF;

    // Source modules: Underwriting Info | General UW Questions | confidence=High score=127
    public ILocator GeneralUWQuestions55852 => _page.GetByLabel("General UW Questions", new() { Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    public ILocator GeneralUWQuestionsBFB08 => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    // CPP (CR, GL, CP, IM), BOP, BAP
    public ILocator InsuranceScore => _page.GetByRole(AriaRole.Button, new() { Name = "Insurance Score", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    // BAP Only (VT)
    // v56 raw Tosca primary: Insurance Designee | Insurance Score Consent  | DuckCreekId
    public ILocator InsuranceScoreConsent => _page.Locator("[duckcreekid=\"Insurance Score Consent\"], [data-duckcreekid=\"Insurance Score Consent\"]");

    // Source modules: CPP|Client|Underwriting Info|Commercial Property History | confidence=High score=125
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial Property History | Is there a Prior Carrier? | Id+Name+DuckCreekId
    public ILocator IsThereAPriorCarrier5D30E => _page.Locator("input[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB7_1_1-inputEl\"][name=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB7_1_1-inputEl\"][duckcreekid=\"PolicyUnderwritingInput.CommercialPropertyNoPriorCarrier\"]");

    // Source modules: CPP|Client|Underwriting Info|Commercial General Liability History | confidence=High score=125
    public ILocator IsThereAPriorCarrierA9EB5 => IsThereAPriorCarrier5D30E; // semantic alias; locator defined once

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    // v56 raw Tosca primary: CPP|Client|Underwriting Info|Commercial General Liability History | Is there a Prior Carrier? | Id+Name+DuckCreekId
    public ILocator IsThereAPriorCarrierEFB4F => _page.Locator("input[id=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"][name=\"f_p5C3FE0A9E9C647DDBBABE0147EF317DB6_1_1-inputEl\"][duckcreekid=\"PolicyUnderwritingInput.CommercialGeneralLiabilityNoPriorCarrier\"]");

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=127
    public ILocator OtherInsuranceHistory416B1 => _page.GetByLabel("Other Insurance History", new() { Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    public ILocator OtherInsuranceHistory5AFD8 => _page.GetByRole(AriaRole.Link, new() { Name = "Other Insurance History", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=Review score=97
    public ILocator ReferenceNumber => _page.GetByLabel("Reference Number", new() { Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => _page.GetByLabel("The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS", new() { Exact = true });

    // Source modules: Underwriting Info | General UW Questions | confidence=Medium score=113
    // v56 raw Tosca primary: Specific Underwriting Questions - Contractors Equipment | Update Answers | DuckCreekId
    public ILocator UpdateAnswers => _page.Locator("[duckcreekid=\"Update Answers\"], [data-duckcreekid=\"Update Answers\"]");

}
