using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules:  | confidence=High score=95
    public ILocator Accept => _page.GetByRole(AriaRole.Button, new() { Name = "Accept", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial General Liability History | confidence=High score=127
    public ILocator CommercialGeneralLiabilityHistoryC65BF => _page.GetByLabel("Commercial General Liability History", new() { Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    public ILocator CommercialGeneralLiabilityHistoryE02F8 => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial General Liability History", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial Property History | confidence=High score=127
    public ILocator CommercialPropertyHistory76D22 => _page.GetByLabel("Commercial Property History", new() { Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    public ILocator CommercialPropertyHistoryE6A7F => _page.GetByRole(AriaRole.Link, new() { Name = "Commercial Property History", Exact = true });

    // Source modules: Underwriting Info | General UW Questions | confidence=High score=127
    public ILocator GeneralUWQuestions55852 => _page.GetByLabel("General UW Questions", new() { Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    public ILocator GeneralUWQuestionsBFB08 => _page.GetByRole(AriaRole.Link, new() { Name = "General UW Questions", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    // CPP (CR, GL, CP, IM), BOP, BAP
    public ILocator InsuranceScore => _page.GetByRole(AriaRole.Button, new() { Name = "Insurance Score", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    // BAP Only (VT)
    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Button, new() { Name = "Insurance Score Consent", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial Property History | confidence=High score=125
    public ILocator IsThereAPriorCarrier5D30E => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?", Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Commercial General Liability History | confidence=High score=125
    public ILocator IsThereAPriorCarrierA9EB5 => IsThereAPriorCarrier5D30E; // semantic alias; locator defined once

    // Source modules: Underwriting Info | Other Insurance History | confidence=Medium score=113
    public ILocator IsThereAPriorCarrierEFB4F => _page.GetByRole(AriaRole.Textbox, new() { Name = "Is there a Prior Carrier?*", Exact = true });

    // Source modules: Underwriting Info | Other Insurance History | confidence=High score=127
    public ILocator OtherInsuranceHistory416B1 => _page.GetByLabel("Other Insurance History", new() { Exact = true });

    // Source modules: CPP|Client|Underwriting Info|Navigation | confidence=Medium score=113
    public ILocator OtherInsuranceHistory5AFD8 => _page.GetByRole(AriaRole.Link, new() { Name = "Other Insurance History", Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=Review score=97
    public ILocator ReferenceNumber => _page.GetByLabel("Reference Number", new() { Exact = true });

    // Source modules: Policy Info|Insurance Score | confidence=High score=125
    public ILocator TheInsuranceScoreServiceHasReturnedTheFollowingErrorCREDITVENDORUNREACHABLEPLEASEREPROCESS => _page.GetByLabel("The insurance score service has returned the following error: CREDIT VENDOR UNREACHABLE - PLEASE REPROCESS", new() { Exact = true });

    // Source modules: Underwriting Info | General UW Questions | confidence=Medium score=113
    public ILocator UpdateAnswers => _page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true });

}
