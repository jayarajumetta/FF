using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace InsuranceAutomation.PLDC.Pages.Locators;

public sealed class NavigationLocators
{
    private readonly IPage _page;
    public NavigationLocators(IPage page) => _page = page;

    public ILocator CloseQuote => _page.Locator("mat-icon").Filter(new() { HasText = "clear" });

    public ILocator ClientLink => _page.Locator("a[onclick*='MainInterview_Account']").Filter(new LocatorFilterOptions { Visible = true }).First;

    public ILocator ClientPageTitle => _page.Locator("#pageTitle").Filter(new LocatorFilterOptions { HasText = "Client" });

    public ILocator NameAndQuote => _page.Locator(".mdc-tab.mdc-tab--active .mdc-tab__text-label > span, mat-tab-header [role='tab'][aria-selected='true'] .mdc-tab__text-label > span").First;

    // Source: PL DC|Common|Review Required Pop-up.
    public ILocator KeepGoing => _page.Locator("[id='btnConfirmYes']");

    // Source: PL DC|Common|Navigation. Screen is a reusable parameter; navigation is a click,
    // and the postcondition is an H1 beginning with the requested screen name.
    public ILocator GetNavigationLink(string screen) =>
        _page.GetByTestId($"{screen}-nav");
    public ILocator GetScreenHeading(string screen) =>
        _page.GetByRole(AriaRole.Heading, new() { NameRegex = new Regex("^" + Regex.Escape(screen), RegexOptions.IgnoreCase) });

    public ILocator CoveragesNewNext => _page.GetByTestId("pl-auto-coverages-next-btn-button-label").Filter(new() { HasText = "Next" });

    public ILocator CoveragesTab => _page.Locator("[id='Coverages-nav']");

    public ILocator AdditionalCoveragesTab => _page.GetByTestId("AdditionalCoverages-nav").Filter(new() { HasText = "Additional Coverages" });

    public ILocator CoveragesHeader => _page.Locator("h1").Filter(new() { HasText = "Coverages" }).First;

    public ILocator SubmissionHeader => _page.Locator("h1").Filter(new() { HasText = "Submission" }).First;

    public ILocator AdditionalCoveragesHeader => _page.Locator("h1").Filter(new() { HasText = "Additional Coverages" }).First;

    public ILocator VehicleInformationHeader => _page.Locator("h1").Filter(new() { HasText = "Vehicle Information" }).First;

    public ILocator Driver1 => _page.Locator("[id=\"Driver_Headless.FullName-0-layout\"]");

    public ILocator DriverInformation => _page.GetByLabel("Driver Information", new() { Exact = true });

    public ILocator EDITCOVERAGEOpt1 => _page.Locator("[id=\"fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[0].edit_Coverage-pen\"]");

    public ILocator EDITCOVERAGEOpt2 => _page.Locator("[id=\"fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[1].edit_Coverage-pen\"]");

    public ILocator EDITCOVERAGEOpt3 => _page.Locator("[id=\"fields.data.policy.line.expertQuoteOptions.expertQuoteOption.rows[2].edit_Coverage-pen\"]");

    public ILocator Loading => _page.GetByLabel("Loading ...", new() { Exact = true });

    public ILocator Option1 => _page.Locator("input[id='temp.coverageOption0Selected-checkbox']");

    public ILocator Option2 => _page.GetByTestId("temp.coverageOption1Selected").First;

    public ILocator Option3 => _page.Locator("input[id='temp.coverageOption2Selected-checkbox']");

    public ILocator UninsuredMotoristsLimitLabel => _page.Locator("label").Filter(new() { HasText = "Uninsured Motorists Limit" });

    public ILocator ExpertQuoteOptionPolicyOption => _page.Locator("label").Filter(new() { HasText = "Supplemental Uninsured/Underinsured Motorist Opt in?" });

    public ILocator UninsuredUnderinsuredMotoristLabel => _page.GetByText("Uninsured/Underinsured Motorist", new() { Exact = true });

    public ILocator BodilyInjuryLabel => _page.Locator("label").Filter(new() { HasText = "Bodily Injury" });

    public ILocator BI_LimitChip => _page.GetByTestId("fields.expertQuoteOptions.expertQuoteOption.rows[0].expertQuoteOptionInput$bI_Limit.value-chip-label")
        .Filter(new LocatorFilterOptions { Visible = true }).Nth(1);

    public ILocator UMBI_LimitChip => _page.GetByTestId("fields.expertQuoteOptions.expertQuoteOption.rows[0].expertQuoteOptionInput$uMBI_Limit.value-chip-label")
        .Filter(new LocatorFilterOptions { Visible = true }).Nth(1);

    public ILocator MedicalPaymentsLabel => _page.Locator("label").Filter(new() { HasText = "Medical Payments" });

    public ILocator PropertyDamageLabel => _page.Locator("label").Filter(new() { HasText = "Property Damage" });

    public ILocator PD_LimitChip => _page.GetByTestId("fields.expertQuoteOptions.expertQuoteOption.rows[0].expertQuoteOptionInput$pD_Limit.value-chip-label")
        .Filter(new LocatorFilterOptions { Visible = true }).Nth(1);

    public ILocator MED_LimitChip => _page.GetByTestId("fields.expertQuoteOptions.expertQuoteOption.rows[0].expertQuoteOptionInput$mED_Limit.value-chip-label")
        .Filter(new LocatorFilterOptions { Visible = true }).Nth(1);

    public ILocator UnderinsuredMotoristsLimitLabel => _page.Locator("label").Filter(new() { HasText = "Underinsured Motorists Limit" });

    public ILocator UIMBI_LimitChip => _page.GetByTestId("fields.expertQuoteOptions.expertQuoteOption.rows[0].expertQuoteOptionInput$uIMBI_Limit.value-chip-label")
        .Filter(new LocatorFilterOptions { Visible = true }).Nth(1);

    public ILocator OptionDetailSaveAndContinue => _page.GetByTestId("fields.expertQuoteOptions.expertQuoteOption.rows[0].option_Detail_Done-button-label");




    public ILocator QuoteSearchInput => _page.Locator("[id='quoteSearchInput']");

    public ILocator QuoteSearchButton => _page.Locator("button[id='quoteSearchButton'], button[data-testid='quoteSearchButton']");

    public ILocator SaveAndContinue => _page.GetByRole(AriaRole.Button, new() { Name = "Save and Continue", Exact = true });

    public ILocator State => _page.Locator("[id=\"proposal.ratingState\"]");

    public ILocator SupplementalUMUIMCov => _page.GetByRole(AriaRole.Button, new() { Name = "Supplemental UM/UIM Cov", Exact = true });

    public ILocator SupplementalUMUIMOptIn => _page.GetByRole(AriaRole.Button, new() { Name = "Supplemental UM/UIM Opt In", Exact = true });


    public ILocator UMCoverage => _page.GetByRole(AriaRole.Button, new() { Name = "UM Coverage", Exact = true });

    public ILocator V1CollDed => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-chip-wrapper").Nth(2);

    public ILocator V1CollDed500 => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-chip-label").Filter(new() { HasText = "500" });

    public ILocator V2CollDed1000 => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-chip-label").Filter(new() { HasText = "1,000" });

    public ILocator V2CollDed500 => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-chip-wrapper").Filter(new() { HasText = "500" });


    public ILocator V3CollDed500 => _page.GetByTestId("temp.vehicleCoverage2.coll_Option-chip-label").Filter(new() { HasText = "500" });

    public ILocator V4CollDed500 => _page.GetByTestId("temp.vehicleCoverage3.coll_Option-chip-label").Filter(new() { HasText = "500" });

    public ILocator V1CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage0.coll_Option-menu-trigger");

    public ILocator V1CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[0].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    public ILocator V1CompDed => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-chip-wrapper").Nth(1);

    public ILocator V1CompDed500 => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-chip-label").Filter(new() { HasText = "500" });

    public ILocator V2CompDed200 => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-chip-label").Filter(new() { HasText = "200" });

    public ILocator V2CompDed500 => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-chip-wrapper").Filter(new() { HasText = "500" });


    public ILocator V3CompDed2000 => _page.GetByTestId("temp.vehicleCoverage2.comp_Option-chip-label").Filter(new() { HasText = "2,000" });

    public ILocator V3CompDed500 => _page.GetByTestId("temp.vehicleCoverage2.comp_Option-chip-wrapper").Filter(new() { HasText = "500" });

    public ILocator V4CompDed1000 => _page.GetByTestId("temp.vehicleCoverage3.comp_Option-chip-label").Filter(new() { HasText = "1,000" });

    public ILocator V1CompDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage0.comp_Option-menu-trigger");

    public ILocator V1ComprehensiveAndCollisionOnly => _page.GetByRole(AriaRole.Button, new() { Name = "V1_ Comprehensive And Collision Only", Exact = true });

    public ILocator V1ComprehensiveDeductible => _page.Locator("input[id=\"temp.coverageOption0Selected-checkbox\"][data-testid=\"temp.coverageOption0Selected\"]");

    public ILocator V1ComprehensiveOnly => _page.GetByTestId("fields.data.policy.line.risk.rows[0].vehicleInput$comprehensiveOnly.value");

    public ILocator V2CollDed => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-chip-wrapper").Nth(1);

    public ILocator V2CollDedMoreOpt => _page.GetByTestId("temp.vehicleCoverage1.coll_Option-menu-trigger");

    public ILocator V2CompCollOnlyYES => _page.GetByTestId("fields.data.policy.line.risk.rows[1].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper");

    public ILocator V2CompDed => _page.GetByTestId("temp.vehicleCoverage1.comp_Option-chip-wrapper").Nth(1);

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

    public ILocator LaunchToChecklist => _page.Locator("[data-testid=\"fields.data.policy.launchToChecklist-button-label\"]").Filter(new LocatorFilterOptions { HasText = "Launch To Checklist" }).First;

    public ILocator ChecklistOpenedOK => _page.Locator("button#btnOk[data-testid=\"btnOk\"]");

    public ILocator DiscountsAdjustmentsNav => _page.GetByTestId("Discounts_Adjustments-nav");

    public ILocator Option2CheckBox => _page.Locator("input[data-testid=\"temp.coverageOption1Selected\"]");
}
