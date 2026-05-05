// Pages/BillingPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class BillingPage : BasePage
    {
        public BillingPage(IPage page) : base(page) { }

        #region Locators
        private ILocator CreateNewBillingAccountButton => _page.Locator("[data-testid*='billingCenterAccount']");
        private ILocator PaymentDueDateInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.subsequentPaymentData$dueDate.value");
        private ILocator ApplyRefundCheckbox => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$applyRefund.value");
        private ILocator CheckNumberInput => _page.GetByTestId("fields._PolicyPaymentInputDoc.initialPaymentData$checkNumber.value");

        // Dynamic locators
        private ILocator GetPrimaryPayerButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetPaymentTypeButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetPaymentPlanButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetPaymentAmountRadioButton(string value) =>
            _page.GetByRole(AriaRole.Radio, new() { Name = value });

        private ILocator GetPaymentMethodButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetPaperlessCommunicationButton(string yesOrNo) =>
            _page.GetByRole(AriaRole.Button, new() { Name = yesOrNo });
        #endregion

        public async Task ClickCreateNewBillingAccountAsync()
        {
            await CreateNewBillingAccountButton.ClickAsync();
        }

        public async Task SelectPrimaryPayerAsync(string primaryPayer)
        {
            await WaitForSpinnerAsync();
            var payerButton = GetPrimaryPayerButton(primaryPayer);
            await Assertions.Expect(payerButton).ToBeVisibleAsync();
            await payerButton.ClickAsync();
        }

        public async Task SelectPaymentTypeAsync(string paymentType)
        {
            await GetPaymentTypeButton(paymentType).ClickAsync();
        }

        public async Task WaitForPaymentPlanAsync(string paymentPlan)
        {
            var planBtn = GetPaymentPlanButton(paymentPlan);
            await planBtn.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 15000
            });
        }

        public async Task SelectPaymentPlanAsync(string paymentPlan)
        {
            await GetPaymentPlanButton(paymentPlan).ClickAsync();
        }

        public async Task WaitForPaymentDueDateInputAsync()
        {
            await PaymentDueDateInput.WaitForAsync(new() { Timeout = 3000 });
        }

        public async Task EnterPaymentDueDateAsync(string paymentDueDate)
        {
            await PaymentDueDateInput.FillAsync(paymentDueDate);
        }

        public async Task SelectPaymentAmountAsync(string paymentAmount)
        {
            await GetPaymentAmountRadioButton(paymentAmount).ClickAsync();
        }

        public async Task SelectPaymentMethodAsync(string paymentMethod)
        {
            await GetPaymentMethodButton(paymentMethod).ClickAsync();
        }

        public async Task EnterCheckNumberAsync(string checkNumber)
        {
            await CheckNumberInput.FillAsync(checkNumber);
        }

        public async Task SelectPaperlessCommunicationAsync(string paperless)
        {
            await GetPaperlessCommunicationButton(paperless).ClickAsync();
        }

        /// <summary>
        /// Click the Next button and wait for spinner to clear
        /// </summary>
        public new async Task ClickNextAsync()
        {
            await base.ClickNextAsync();
            await WaitForSpinnerAsync();
        }

        public void DisplayQuoteNumber(string quoteNumber)
        {
            Console.WriteLine($"QUOTE NUMBER IS: {quoteNumber}");
        }
    }
}
