using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQOtherPolicyCoveragesSectionNewLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator H1AdditionalCoverages(IPage page) =>
        page.GetByText("Additional Coverages", new() { Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator TortOption(IPage page) =>
        page.GetByTestId("fields.policy.line.tortInput$limit.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator IncomeLossCoverage(IPage page) =>
        page.GetByTestId("fields.policy.line.incomeLossInput$limit.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator UMPD(IPage page) =>
        page.GetByTestId("fields.policy.line.uninsuredMotoristsPDInput$limit.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator UIMPD(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "$250", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ADDCoverage(IPage page) =>
        page.GetByTestId("fields.policy.*ccidentalDeathInput$limit.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator ADDDriver1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankVickie Anderson", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ADDDriver2(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankBecky Buie", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ADDDriver3(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankDomingo Thomas", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ADDDriver4(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankE Trujillo", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ADDDriver5(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankDoryne Stockard", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator TotalDisabilityCoverageDriver1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "check_box_outline_blankConnie Alexander", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator IncLiabilityClaimsOfFamilyMembers(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ExtraordinaryMedicalBenefit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator WorkLossNo(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

}
