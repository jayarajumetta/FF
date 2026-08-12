using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQDiscountRateTierQuestionsNEWLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator ResidentiaProperty1(IPage page) =>
        page.GetByTestId("fields.data.account.accountCompositionPreferredTier.ownrshpResidPropertyInput$override.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator LessThan3000060000(IPage page) =>
        page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Item1500030000(IPage page) =>
        page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator LessThan1500030000(IPage page) =>
        page.GetByTestId("fields.data.account.accountCompositionPreferredTier.priorBILimitInput$override.value-chip-wrapper");

        // REVIEW: source field not uniquely resolved.
    public static ILocator ResidentiaPropertyOld(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Residential Property Owner", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator LessThanOrEqualTo2500050000Old(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Less Than or Equal to $25,000/$50,000", Exact = true });

}
