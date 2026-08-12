using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQProposalDetailsStartLocators
{
        // REVIEW: source field not uniquely resolved.
    public static ILocator PersonalAuto(IPage page) =>
        page.GetByTestId("proposal.product-chip-label");

        // REVIEW: source field not uniquely resolved.
    public static ILocator Motorcycle(IPage page) =>
        page.GetByTestId("proposal.product-chip-label");

        // REVIEW: source field not uniquely resolved.
    public static ILocator RecreationalVehicle(IPage page) =>
        page.GetByTestId("proposal.product-chip-label");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator EffectiveDate(IPage page) =>
        page.Locator("id=proposal.effectiveDate");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator AgentCode(IPage page) =>
        page.Locator("id=proposal.agentPC");

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator State(IPage page) =>
        page.GetByLabel("NEW YORK", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator WritingCompany(IPage page) =>
        page.GetByLabel("Farm Family Casualty Insurance Co.", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator CountyComboBox(IPage page) =>
        page.Locator("id=owner.address.county");

        // REVIEW: source field not uniquely resolved.
    public static ILocator CountyYes(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "YES", Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator StartQuote(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Start Quote", Exact = true });

        // REVIEW: source field not uniquely resolved.
    public static ILocator StateName(IPage page) =>
        page.GetByText("{STRINGTOUPPER[{{buffer:StateName}}]}", new() { Exact = true });

    // REVIEW: page/module field not uniquely resolved.
        // REVIEW: source field not uniquely resolved.
    public static ILocator PROCEED(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "PROCEED", Exact = true });

}
