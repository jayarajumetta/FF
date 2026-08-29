using Microsoft.Playwright;

namespace InsuranceAutomation.CLEQ.Pages.Locators;

public sealed class UnderwritingLocators
{
    private readonly IPage _page;
    public UnderwritingLocators(IPage page) => _page = page;

    public ILocator Accept => _page.Locator("[id=\"accept-checklist-item\"]");

    public ILocator BuildingEligibilityQuestionsNoneOfTheAboveCheckboxAngular => _page.GetByTestId("fields.data.account.buildingEligibility.rows[0].buildingInput$noneOfTheAboveUWQuestions.value");

    public ILocator EntityType => _page.Locator("[id=\"fields.data.sFPInsuranceScoreDesigneeInput$entityType.value\"]");

    public ILocator InsuranceScoreConsent => _page.Locator("[duckcreekid=\"Insurance Score Consent\"], [data-duckcreekid=\"Insurance Score Consent\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator NoneOfTheAboveCheckBox => _page.Locator("[id=\"fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value-checkbox\"]");

    public ILocator Premium => _page.Locator("[id=\"LineOutput.PremiumSummaryPremium124-0-layout\"]");

    public ILocator PrimaryInsured => _page.GetByTestId("fields.data.sFPInsuranceScoreDesigneeInput$headlessSelectionOption.value-chip-wrapper");

    public ILocator Save => _page.FrameLocator("iframe").Locator("[duckcreekid=\"Save\"], [data-duckcreekid=\"Save\"]");

    public ILocator ScreenHeading => _page.GetByText("Screen Heading", new() { Exact = true });

    public ILocator TABLERowCellExplicitName1 => _page.GetByText("(ExplicitName=$1)", new() { Exact = true });

}
