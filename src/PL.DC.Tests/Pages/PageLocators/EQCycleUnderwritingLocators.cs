using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCycleUnderwritingLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator HaveYouOrAnyHouseholdMemberEverBeenConvictedOfAFelony(IPage page) =>
        page.GetByText("Have you or any household member ever been convicted of a felony?", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator No(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator IsAnyVintageCycleGaragedInADifferentLocation(IPage page) =>
        page.GetByText("Is any Vintage cycle garaged in a different location?", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator No1(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "No", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator Next(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Next", Exact = true });

}
