using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class CoveragesNewLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator V1CompCollOnlyYES(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[0].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V1ComprehensiveAndCollisionOnly(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankComprehensive And Collision Only", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V1CompDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage0.comp_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V1CompDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage0.comp_Option-menu-trigger").Filter(new() { HasText = "2,000" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V1CollDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage0.coll_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V1CollDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage0.coll_Option-menu-trigger");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2CompCollOnlyYES(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[1].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2ComprehensiveAndCollisionOnly(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankComprehensive And Collision Only", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2ComprehensiveDeductible(IPage page) =>
        page.GetByText("Comprehensive Deductible", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2CompDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage1.comp_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2CompDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage1.comp_Option-menu-trigger").Filter(new() { HasText = "2,000" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2CollDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage1.coll_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V2CollDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage1.coll_Option-menu-trigger").Filter(new() { HasText = "200" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3CompCollOnlyYES(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[2].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3ComprehensiveAndCollisionOnly(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankComprehensive And Collision Only", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3ComprehensiveDeductible(IPage page) =>
        page.GetByText("Comprehensive Deductible", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3CompDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage2.comp_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3CompDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage2.comp_Option-menu-trigger");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3CollDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage2.coll_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V3CollDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage2.coll_Option-menu-trigger").Filter(new() { HasText = "200" });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4CompCollOnlyYES(IPage page) =>
        page.GetByTestId("\"fields.data.policy.line.risk.rows[3].risk_Headless$selectCOMPCOLLBothOnly.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4ComprehensiveAndCollisionOnly(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankComprehensive And Collision Only", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4ComprehensiveDeductible(IPage page) =>
        page.GetByText("Comprehensive Deductible", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4CompDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage3.comp_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4CompDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage3.comp_Option-menu-trigger");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4CollDed(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage3.coll_Option-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator V4CollDedMoreOpt(IPage page) =>
        page.GetByTestId("temp.vehicleCoverage3.coll_Option-menu-trigger").Filter(new() { HasText = "100" });

}
