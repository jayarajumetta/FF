using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQVehicleCoveragesSectionLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator UMPDUIMPDV1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UIMPDCoverageV1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "$50,000", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RentalReimbursementCoverageV1(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[0].covRentalReimbursementInput$limit.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator TheftDeductibleV1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RoadsideAssistanceCoverageV1(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[0].covRoadsideAssistanceInput$limit.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator CycleAccessoriesV1(IPage page) =>
        page.GetByText("Yes", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator OriginalPartsV1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator EndorsementLimitV1(IPage page) =>
        page.Locator("id=\"fields.policy.line.risk.rows[0].risk_IncreasedLimitsForAccessories.risk_IncreasedLimitsForAccessoriesInput$limit.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator UMPDUIMPDV2(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UIMPDCoverageV2(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "$50,000", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RentalReimbursementCoverageV2(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[1].covRentalReimbursementInput$limit.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator TheftDeductibleV2(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RoadsideAssistanceCoverageV2(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[1].covRoadsideAssistanceInput$limit.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CycleAccessoriesV2(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator OriginalPartsV2(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator EndorsementLimitV2(IPage page) =>
        page.Locator("id=\"fields.policy.line.risk.rows[1].risk_IncreasedLimitsForAccessories.risk_IncreasedLimitsForAccessoriesInput$limit.value\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator NoCoverageV1Towing(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UMPDUIMPDV3(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UIMPDCoverageV3(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "$50,000", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RentalReimbursementCoverageV3(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[2].covRentalReimbursementInput$limit.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator TheftDeductibleV3(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RoadsideAssistanceCoverageV3(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[2].covRoadsideAssistanceInput$limit.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CycleAccessoriesV3(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator OriginalPartsV3(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UMPDUIMPDV4(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator UIMPDCoverageV4(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "$50,000", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RentalReimbursementCoverageV4(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[3].covRentalReimbursementInput$limit.value-chip-wrapper\"");

        // REVIEW: source field not uniquely resolved.
    public static ILocator TheftDeductibleV4(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator RoadsideAssistanceCoverageV4(IPage page) =>
        page.GetByTestId("\"fields.policy.line.risk.rows[3].covRoadsideAssistanceInput$limit.value-chip-wrapper\"");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CycleAccessoriesV4(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator OriginalPartsV4(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

}
