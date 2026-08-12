using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonProposalStartLocators
{
        public static ILocator ProposalDetailsHeader(IPage page) =>
        page.GetByText("Proposal Details", new() { Exact = true });

        public static ILocator PersonalAuto(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Personal Auto", Exact = true });

        public static ILocator Motorcycle(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Motorcycle", Exact = true });

        public static ILocator RecreationalVehicle(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Recreational Vehicle", Exact = true });

        public static ILocator Home(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Home", Exact = true });

        public static ILocator ROP(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "ROP", Exact = true });

        public static ILocator SpecialFarmPackage(IPage page) =>
        page.GetByTestId("proposal.product-chip-label");

        public static ILocator SelectSFPCE(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Select", Exact = true });

        public static ILocator SearchBusinessName(IPage page) =>
        page.Locator("id=business.search.businessName");

        public static ILocator IndividuallyOwnedDBACheckBox(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "Individually Owned / DBA", Exact = true });

        public static ILocator IndividuallyOwnedDBAOrTA(IPage page) =>
        page.GetByRole(AriaRole.Checkbox, new() { Name = "on", Exact = true });

        public static ILocator IndividualDBA(IPage page) =>
        page.Locator("id=business.individualDba");

        public static ILocator EffectiveDate(IPage page) =>
        page.Locator("id=proposal.effectiveDate");

        public static ILocator LessorsRiskNo(IPage page) =>
        page.GetByTestId("proposal.LessorsRiskExposure-chip-wrapper");

        public static ILocator StateDropdown(IPage page) =>
        page.Locator("id=proposal.ratingState");

        // REVIEW: no stronger source locator.
    public static ILocator StateName(IPage page) =>
        page.GetByText("{STRINGTOUPPER[{{buffer:StateName}}]}", new() { Exact = true });

        public static ILocator AgentPC(IPage page) =>
        page.Locator("id=proposal.agentPC");

        public static ILocator StartQuote(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Start Quote", Exact = true });

    public static ILocator BusinessOwners(IPage page) =>
        page.GetByTestId("proposal.product-chip-item-wrapper");

    public static ILocator NewAccountAddress(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "1918 Avalon Ave, Muscle Shoals, AL 35661", Exact = true });

    public static ILocator PolicyTerm(IPage page) =>
        page.GetByTestId("proposal.term");

}
