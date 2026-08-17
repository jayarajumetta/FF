using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    // Source modules: EQ||Tabs | confidence=Medium score=112
    public ILocator CloseTab => _page.GetByLabel("Btn_Close_tab", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=Medium score=113
    public ILocator CoveragesNewNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    // Source modules: EQ|| Add Additional Driver 1 | confidence=High score=97
    public ILocator Driver1 => _page.GetByLabel("Driver_1", new() { Exact = true });

    // Source modules: EQ | Side Menu | confidence=Medium score=108
    public ILocator DriverInformation => _page.GetByLabel("Driver Information", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator EDITCOVERAGEOpt1 => _page.GetByTestId("fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[0].edit_Coverage");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator EDITCOVERAGEOpt2 => _page.GetByTestId("fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[1].edit_Coverage");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator EDITCOVERAGEOpt3 => _page.GetByTestId("fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[2].edit_Coverage");

    // Source modules: EQ |Common|Loading Indicator Wait | confidence=Medium score=78
    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=High score=100
    public ILocator Option1 => _page.GetByTestId("temp.coverageOption0Selected");

    // Source modules: Coverages (New) | confidence=High score=100
    public ILocator Option2 => _page.GetByTestId("temp.coverageOption1Selected");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator Option3 => _page.GetByTestId("temp.coverageOption2Selected");

    // Source modules: EQ||Tabs | confidence=Review score=97
    public ILocator QNum => _page.GetByLabel("Lbl_QNum", new() { Exact = true });

    // Source modules: EQ||Tabs | confidence=High score=127
    public ILocator QuoteSearchInput => _page.GetByRole(AriaRole.Textbox, new() { Name = "Txt_quoteSearchInput", Exact = true });

    // Source modules: Edit Coverage Option (New) | confidence=Medium score=113
    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    // Source modules: EQ || Proposal Details/Start | confidence=High score=97
    public ILocator State => _page.GetByRole(AriaRole.Combobox, new() { Name = "State", Exact = true });

    // Source modules: Edit Coverage Option (New) | confidence=Medium score=113
    public ILocator SupplementalUMUIMCov => _page.GetByRole(AriaRole.Button, new() { Name = "Supplemental UM/UIM Cov", Exact = true });

    // Source modules: Edit Coverage Option (New) | confidence=Medium score=113
    public ILocator SupplementalUMUIMOptIn => _page.GetByRole(AriaRole.Button, new() { Name = "Supplemental UM/UIM Opt In", Exact = true });

    // Source modules: EQ||Tabs | confidence=Medium score=113
    public ILocator TabsSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Btn_Search", Exact = true });

    // Source modules: Edit Coverage Option (New) | confidence=Medium score=113
    public ILocator UMCoverage => _page.GetByRole(AriaRole.Button, new() { Name = "UM Coverage", Exact = true });

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V1CollDed => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V1CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V1CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[0].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V1CompDed => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V1CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=Medium score=113
    public ILocator V1ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V1_ Comprehensive And Collision Only", Exact = true });

    // Source modules: Coverages (New) | confidence=Review score=97
    public ILocator V1ComprehensiveDeductible => _page.GetByLabel("V1_Comprehensive Deductible", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=High score=100
    public ILocator V1ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$comprehensiveOnly.value");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V2CollDed => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V2CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V2CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[1].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V2CompDed => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V2CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=Medium score=113
    public ILocator V2ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V2_Comprehensive And Collision Only", Exact = true });

    // Source modules: Coverages (New) | confidence=Medium score=108
    public ILocator V2ComprehensiveDeductible => _page.GetByLabel("V2_Comprehensive Deductible", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=High score=100
    public ILocator V2ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[1].vehicleInput$comprehensiveOnly.value");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V3CollDed => _page.GetByTestId("temp.vehicleCoverage2.coll_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V3CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage2.coll_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V3CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[2].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V3CompDed => _page.GetByTestId("temp.vehicleCoverage2.comp_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V3CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage2.comp_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=Medium score=113
    public ILocator V3ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V3_Comprehensive And Collision Only", Exact = true });

    // Source modules: Coverages (New) | confidence=Medium score=108
    public ILocator V3ComprehensiveDeductible => _page.GetByLabel("V3_Comprehensive Deductible", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=High score=100
    public ILocator V3ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[2].vehicleInput$comprehensiveOnly.value");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V4CollDed => _page.GetByTestId("temp.vehicleCoverage3.coll_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V4CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage3.coll_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V4CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[3].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V4CompDed => _page.GetByTestId("temp.vehicleCoverage3.comp_Option-chip-wrapper");

    // Source modules: Coverages (New) | confidence=High score=130
    public ILocator V4CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage3.comp_Option-menu-trigger");

    // Source modules: Coverages (New) | confidence=Medium score=113
    public ILocator V4ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V4_Comprehensive And Collision Only", Exact = true });

    // Source modules: Coverages (New) | confidence=Medium score=108
    public ILocator V4ComprehensiveDeductible => _page.GetByLabel("V4_Comprehensive Deductible", new() { Exact = true });

    // Source modules: Coverages (New) | confidence=High score=100
    public ILocator V4ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[3].vehicleInput$comprehensiveOnly.value");

    // Source modules: EQ | Side Menu | confidence=Medium score=108
    public ILocator VehicleSummary => _page.GetByLabel("Vehicle Summary", new() { Exact = true });

}
