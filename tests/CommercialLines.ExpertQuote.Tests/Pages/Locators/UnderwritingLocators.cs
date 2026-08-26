using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    // v56 raw Tosca primary: EQ|Common|eChecklist - eChecklist | Accept | Id
    public ILocator Accept => _page.Locator("[id=\"accept-checklist-item\"]");

    // Source modules: EQ|BOP|Building|Building Eligibility Questions | confidence=High score=130
    public ILocator BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.buildingEligibility.rows[0].buildingInput$noneOfTheAboveUWQuestions.value");

    // Source modules: EQ|SFP|Insurance Score | confidence=High score=127
    // v56 raw Tosca primary: EQ|SFP|Insurance Score | Entity Type | Id
    public ILocator EntityType => _page.Locator("[id=\"fields.data.sFPInsuranceScoreDesigneeInput$entityType.value\"]");

    // Source modules: EQ|SFP|Insurance Score | confidence=Medium score=113
    // v56 raw Tosca primary: Policy Info|Insurance Score | Insurance Score Consent | DuckCreekId
    public ILocator InsuranceScoreConsent => _page.Locator("[duckcreekid=\"Insurance Score Consent\"], [data-duckcreekid=\"Insurance Score Consent\"]");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|BOP|Primary Insured Details|General UW Questions | confidence=High score=127
    // v56 raw Tosca primary: EQ|BOP|Primary Insured Details|General UW Questions | None of the Above CheckBox | Id
    public ILocator NoneOfTheAboveCheckBox => _page.Locator("[id=\"fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value-checkbox\"]");

    // Source modules: EQ|BOP|Pricing|Insurance Score and Premium | confidence=High score=97
    // v56 raw Tosca primary: EQ|BOP|Pricing|Insurance Score and Premium | Premium | Id
    public ILocator Premium => _page.Locator("[id=\"LineOutput.PremiumSummaryPremium124-0-layout\"]");

    // Source modules: EQ|SFP|Insurance Score | confidence=High score=130
    public ILocator PrimaryInsured => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-chip-wrapper");

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    // v56 raw Tosca primary:  | Save | DuckCreekId | frame=iframe
    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TABLERowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

}
