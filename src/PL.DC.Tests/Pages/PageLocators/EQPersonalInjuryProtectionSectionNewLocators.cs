using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQPersonalInjuryProtectionSectionNewLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator HouseholdMembersAge65OrReceivingPension(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator PIPLimit(IPage page) =>
        page.GetByTestId("fields.policy.line.pIPInput$limit.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator PIPDeductible(IPage page) =>
        page.GetByTestId("fields.policy.line.pIPInput$deductible.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator AdditionalPIP(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator PIPStacking(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator ExtraPIPOption(IPage page) =>
        page.GetByTestId("fields.policy.line.pIPInput$extraPIPOption.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator AutoHealthInsurer(IPage page) =>
        page.GetByTestId("fields.policy.line.pIPInput$autoHealthInsurer.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator MedicalExpenseElimination(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator WorkLossNo(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator BroadenedPIP(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Yes", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator AdditionalDeathBenefit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No Coverage", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator WaiverOfIncomeLoss(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

}
