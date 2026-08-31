using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    public ILocator CloseTab => _page.Locator("input[id=\"quoteSearchInput\"][name=\"quoteSearchInput\"]");

    public ILocator CoveragesNewNext => _page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

    public ILocator Driver1 => _page.Locator("[id=\"Driver_Headless.FullName-0-layout\"]");

    public ILocator DriverInformation => _page.GetByLabel("Driver Information", new() { Exact = true });

    public ILocator EDITCOVERAGEOpt1 => _page.GetByTestId("fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[0].edit_Coverage");

    public ILocator EDITCOVERAGEOpt2 => _page.GetByTestId("fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[1].edit_Coverage");

    public ILocator EDITCOVERAGEOpt3 => _page.GetByTestId("fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[2].edit_Coverage");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator Option1 => _page.GetByTestId("temp.coverageOption0Selected");

    public ILocator Option2 => _page.GetByTestId("temp.coverageOption1Selected");

    public ILocator Option3 => _page.GetByTestId("temp.coverageOption2Selected");


    public ILocator QuoteSearchInput => _page.Locator("[name=\"Txt_quoteSearchInput\"], [id=\"Txt_quoteSearchInput\"]").First;

    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");

    public ILocator SupplementalUMUIMCov => _page.GetByRole(AriaRole.Button, new() { Name = "Supplemental UM/UIM Cov", Exact = true });

    public ILocator SupplementalUMUIMOptIn => _page.GetByRole(AriaRole.Button, new() { Name = "Supplemental UM/UIM Opt In", Exact = true });


    public ILocator UMCoverage => _page.GetByRole(AriaRole.Button, new() { Name = "UM Coverage", Exact = true });

    public ILocator V1CollDed => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-chip-wrapper");

    public ILocator V1CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-menu-trigger");

    public ILocator V1CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[0].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    public ILocator V1CompDed => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-chip-wrapper");

    public ILocator V1CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-menu-trigger");

    public ILocator V1ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V1_ Comprehensive And Collision Only", Exact = true });

    public ILocator V1ComprehensiveDeductible => _page.Locator("input[id=\"temp.coverageOption0Selected-checkbox\"][data-testid=\"temp.coverageOption0Selected\"]");

    public ILocator V1ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$comprehensiveOnly.value");

    public ILocator V2CollDed => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-chip-wrapper");

    public ILocator V2CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-menu-trigger");

    public ILocator V2CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[1].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    public ILocator V2CompDed => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-chip-wrapper");

    public ILocator V2CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-menu-trigger");

    public ILocator V2ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V2_Comprehensive And Collision Only", Exact = true });


    public ILocator V2ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[1].vehicleInput$comprehensiveOnly.value");

    public ILocator V3CollDed => _page.GetByTestId("temp.vehicleCoverage2.coll_Option-chip-wrapper");

    public ILocator V3CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage2.coll_Option-menu-trigger");

    public ILocator V3CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[2].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    public ILocator V3CompDed => _page.GetByTestId("temp.vehicleCoverage2.comp_Option-chip-wrapper");

    public ILocator V3CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage2.comp_Option-menu-trigger");

    public ILocator V3ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V3_Comprehensive And Collision Only", Exact = true });


    public ILocator V3ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[2].vehicleInput$comprehensiveOnly.value");

    public ILocator V4CollDed => _page.GetByTestId("temp.vehicleCoverage3.coll_Option-chip-wrapper");

    public ILocator V4CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage3.coll_Option-menu-trigger");

    public ILocator V4CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[3].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    public ILocator V4CompDed => _page.GetByTestId("temp.vehicleCoverage3.comp_Option-chip-wrapper");

    public ILocator V4CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage3.comp_Option-menu-trigger");

    public ILocator V4ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V4_Comprehensive And Collision Only", Exact = true });


    public ILocator V4ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[3].vehicleInput$comprehensiveOnly.value");

    public ILocator VehicleSummary => _page.GetByLabel("Vehicle Summary", new() { Exact = true });

}
