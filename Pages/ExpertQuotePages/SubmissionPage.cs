using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using Playwright_POC.Pages;

namespace Playwright_POC.Pages.ExpertQuotePages
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
            _page.GetByText("No referrals required");

        public ILocator NoReferralsTextAlt =>
            _page.GetByText("No Referrals");

        /// <summary>Transmit button to submit the policy</summary>
        public ILocator TransmitButton =>
            _page.GetByTestId("fields.data.submission.transmit"); // TODO: Verify testId

        public ILocator TransmitButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Transmit" });
        #endregion
    }
}
