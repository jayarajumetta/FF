using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.Locator("[id=\"accept-checklist-item\"]");

    public ILocator BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.buildingEligibility.rows[0].buildingInput$noneOfTheAboveUWQuestions.value");

    public ILocator EntityType => _page.Locator("[id=\"fields.data.sFPInsuranceScoreDesigneeInput$entityType.value\"]");

    public ILocator InsuranceScoreConsent => _page.Locator("button:has-text(\"Insurance Score Consent\"), a:has-text(\"Insurance Score Consent\")").First;

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator NoneOfTheAboveCheckBox => _page.Locator("[id=\"fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value-checkbox\"]");

    public ILocator Premium => _page.Locator("[id=\"LineOutput.PremiumSummaryPremium124-0-layout\"]");

    public ILocator PrimaryInsured => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-chip-wrapper");

    public ILocator Save => _page.Locator("button[id=\"fields.data.save\"], button[data-testid=\"fields.line.save\"], button:has-text(\"Save\"), a:has-text(\"Save\")").First;

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator TABLERowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

}
