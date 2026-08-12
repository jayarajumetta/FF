using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQBOPSubmissionMainPageLocators
{
        public static ILocator NoReferralNeededVerification(IPage page) =>
        page.GetByText("STATUS: NO REFERRAL NEEDED -- CONTINUE TO STEP 3", new() { Exact = true });

        public static ILocator LaunchToChecklistButton(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Launch to Checklist", Exact = true });

        public static ILocator ChecklistButtonSFP(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Launch to Checklist", Exact = true });

}
