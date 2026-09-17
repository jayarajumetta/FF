using Microsoft.Playwright;
using PnCTestAutomation.BusinessOutcomes;
using System;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;
using PnCTestAutomation.Pages;

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

        /// <summary>Transmit button to submit the policy</summary>
        public ILocator TransmitButton =>
            _page.GetByTestId("fields.data.submission.transmit"); // TODO: Verify testId

        public ILocator TransmitButtonAlt =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Transmit" });
        #endregion

        public async Task<TransmissionAvailability> GetTransmitAvailabilityAsync()
        {
            var transmit = TransmitButton;
            var count = await transmit.CountAsync();
            if (count == 0)
            {
                transmit = TransmitButtonAlt;
                count = await transmit.CountAsync();
            }

            if (count > 1)
            {
                throw new InvalidOperationException(
                    "Transmission readiness is ambiguous because multiple Transmit actions matched.");
            }

            if (count == 0)
                return new TransmissionAvailability(false, false);

            return new TransmissionAvailability(
                await transmit.IsVisibleAsync(),
                await transmit.IsEnabledAsync());
        }
    }
}
