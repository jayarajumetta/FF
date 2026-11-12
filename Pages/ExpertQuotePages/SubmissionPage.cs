using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages
{
    /// <summary>
    /// Submission page for ExpertQuote application
    /// </summary>
    public class SubmissionPage : BasePage
    {
        public SubmissionPage(IPage page) : base(page) { }

        #region Locators
        /// <summary>Button to open the checklist panel</summary>
        public ILocator ChecklistButton =>
            _page.GetByTestId("fields.data.submission.openChecklist"); // TODO: Verify testId

        public ILocator ChecklistButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Checklist" });

        /// <summary>Referrals section container</summary>
        public ILocator ReferralsSection =>
            _page.GetByTestId("fields.data.submission.referrals"); // TODO: Verify testId

        /// <summary>Text indicating no referrals required</summary>
        public ILocator NoReferralsText =>
            _page.GetByText("NO REFERRAL NEEDED", new() { Exact = false });

        public ILocator NoReferralsTextAlt =>
            _page.GetByText("NO REFERRAL NEEDED");

        public ILocator ReferralRequiredText =>
            _page.GetByText("STATUS: REFERRAL NEEDED", new() { Exact = false });

        public ILocator PollutionReferralRule =>
            _page.GetByText("Limited Farm Pollution Liability requires Underwriting approval", new() { Exact = false });

        public ILocator PollutionReferralRuleCode =>
            _page.GetByText("11125", new() { Exact = true });

        public ILocator RequiredAgentComments =>
            _page.GetByTestId(new Regex(
                    @"uWRuleReview\$agentComments\.value$",
                    RegexOptions.IgnoreCase))
                .And(_page.Locator("input:visible, textarea:visible"));

        private ILocator PrimaryInsuredAddressOverrideRequirement =>
            _page.GetByText(new Regex(
                @"Primary Insured Details\s*-\s*Address Override",
                RegexOptions.IgnoreCase));

        /// <summary>Transmit button to submit the policy</summary>
        public ILocator TransmitButton =>
            _page.GetByTestId("fields.data.submission.transmit"); // TODO: Verify testId

        public ILocator TransmitButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Transmit" });
        #endregion

        public async Task CompleteRequiredAgentCommentsAsync()
        {
            var count = await RequiredAgentComments.CountAsync();
            for (var index = 0; index < count; index++)
            {
                var comment = RequiredAgentComments.Nth(index);
                if (!string.IsNullOrWhiteSpace(await comment.InputValueAsync()))
                    continue;

                await comment.FillAsync(
                    "Reviewed for automated Country Estate validation.",
                    new() { Force = true });
                await comment.DispatchEventAsync("change");
                await comment.DispatchEventAsync("blur");
            }

            if (count > 0)
            {
                Console.WriteLine($"[Submission] Completed {count} required underwriting agent comment(s).");
                await Expect(RequiredAgentComments).Not.ToHaveValueAsync("");
            }
        }

        public async Task<bool> RequiresPrimaryInsuredAddressOverrideAsync() =>
            await PrimaryInsuredAddressOverrideRequirement.CountAsync() > 0
            && await PrimaryInsuredAddressOverrideRequirement.First.IsVisibleAsync();

        public async Task AcknowledgeChecklistUpdateAsync(bool expectReferralRequired = false)
        {
            var dialog = _page.GetByRole(AriaRole.Dialog).Filter(new() { HasText = "Checklist Opened" });
            await Expect(dialog).ToHaveCountAsync(1);
            await Expect(dialog).ToBeVisibleAsync();
            var confirm = dialog.GetByRole(AriaRole.Button, new()
            {
                NameRegex = new Regex(@"^\s*(?:OK|Update)\s*$", RegexOptions.IgnoreCase)
            });
            await Expect(confirm).ToHaveCountAsync(1);
            await confirm.ClickAsync();
            await Expect(dialog).ToBeHiddenAsync();
            await WaitForSpinnerAsync();
            await Expect(expectReferralRequired ? ReferralRequiredText : NoReferralsText).ToBeVisibleAsync();
        }
    }
}
