using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPClaimsPriorInsuranceAddClaimLocators
{
        public static ILocator ClaimsAddAndUpdateClaimsAsNeeded(IPage page) =>
        page.GetByText("ClaimsAdd and Update Claims as Needed", new() { Exact = true });

        public static ILocator ADDCLAIM(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "+ ADD CLAIM", Exact = true });

        public static ILocator DateOfOccurrence(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$dateOfOccurrence.value\"");

        public static ILocator PolicyStart(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodEffectiveDate.value\"");

        public static ILocator PolicyExpire(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].underwritingLossExperienceInput$policyPeriodExpirationDate.value\"");

        public static ILocator AmountPaid(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountPaid.value\"");

        public static ILocator AmountReserved(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$amountReserved.value\"");

        public static ILocator ExpenseAmount(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$expenseAmount.value\"");

        public static ILocator TypeOfLossDropdown(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$typeOfLoss.value\"");

        // REVIEW: no stronger source locator.
    public static ILocator TypeOfLossSelection(IPage page) =>
        page.GetByText("{{buffer:Type of Loss}}", new() { Exact = true });

        public static ILocator DescriptionOfOccurrenceOrClaim(IPage page) =>
        page.Locator("id=\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$descriptionOfOccurrenceOrClaim.value\"");

        public static ILocator OpenButton(IPage page) =>
        page.GetByTestId("\"fields.underwritingLossExperience.rows[0].addLoss.rows[0].addLossInput$claimStatus.value-chip-wrapper\"");

        public static ILocator Save(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true });

}
