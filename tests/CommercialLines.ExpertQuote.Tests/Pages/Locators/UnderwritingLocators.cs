using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    // Source modules: EQ|Common|eChecklist - eChecklist | confidence=High score=127
    public ILocator Accept => _page.GetByRole(AriaRole.Button, new() { Name = "Accept", Exact = true });

    // Source modules: EQ|BOP|Building|Building Eligibility Questions | confidence=High score=130
    public ILocator BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.buildingEligibility.rows[0].buildingInput$noneOfTheAboveUWQuestions.value");

    // Source modules: EQ|SFP|Insurance Score | confidence=High score=127
    public ILocator EntityType => _page.GetByRole(AriaRole.Combobox, new() { Name = "Entity Type", Exact = true });

    // Source modules: EQ|SFP|Insurance Score | confidence=Medium score=113
    public ILocator InsuranceScoreConsent => _page.GetByRole(AriaRole.Button, new() { Name = "Insurance Score Consent", Exact = true });

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: EQ|BOP|Primary Insured Details|General UW Questions | confidence=High score=127
    public ILocator NoneOfTheAboveCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "None of the Above CheckBox", Exact = true });

    // Source modules: EQ|BOP|Pricing|Insurance Score and Premium | confidence=High score=97
    public ILocator Premium => _page.GetByLabel("Premium", new() { Exact = true });

    // Source modules: EQ|SFP|Insurance Score | confidence=High score=130
    public ILocator PrimaryInsured => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-chip-wrapper");

    // Source modules: EQ|SFP|DIV V|Optional Liability Coverage|Workers' Compensation - Residence EmployeesExpertQuote | confidence=High score=130
    public ILocator Save => _page.GetByTestId("fields.line.save");

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    // Source modules: Synthetic | confidence=Review score=40
    // Fallback derived from source control name
    public ILocator TABLERowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

}