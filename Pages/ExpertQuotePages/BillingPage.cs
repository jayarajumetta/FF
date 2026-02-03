
// Pages/BillingPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class BillingPage
    {
        private readonly IPage _page;

        public BillingPage(IPage page)
        {
            _page = page;
        }


        public async Task ClickCreateNewBillingAccountAsync()
        {
            await BillingInformationConstLocators.CreateNewBillingAccountButton(_page).ClickAsync();
        }

        public async Task SelectPrimaryPayerAsync(string primaryPayer)
        {
            // Wait for billing page to be fully loaded
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
            var payerButton = ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPrimaryPayerButton(_page, primaryPayer);
            await Assertions.Expect(payerButton).ToBeVisibleAsync();
            await payerButton.ClickAsync();
        }

        public async Task SelectPaymentTypeAsync(string paymentType)
        {
            await ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentTypeButton(_page, paymentType).ClickAsync();
        }

        public async Task WaitForPaymentPlanAsync(string paymentPlan)

        {
            var planBtn = ExpertQuoteLocatorFactory.BillingInformationsPageLocators
                .GetPaymentPlanButton(_page, paymentPlan);  

            await planBtn.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 15000
            });
        }


        public async Task SelectPaymentPlanAsync(string paymentPlan)
        {
            await ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentPlanButton(_page, paymentPlan).ClickAsync();
        }

        public async Task WaitForPaymentDueDateInputAsync()
        {
            await BillingInformationConstLocators.PaymentDueDateInput(_page).WaitForAsync(new() { Timeout = 3000 });
        }

        public async Task EnterPaymentDueDateAsync(string paymentDueDate)
        {
            await BillingInformationConstLocators.PaymentDueDateInput(_page).FillAsync(paymentDueDate);
        }

        public async Task SelectPaymentAmountAsync(string paymentAmount)
        {
            await ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentAmountRadioButton(_page, paymentAmount).ClickAsync();
        }

        public async Task SelectPaymentMethodAsync(string paymentMethod)
        {
            await ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentMethodButton(_page, paymentMethod).ClickAsync();
        }

        public async Task EnterCheckNumberAsync(string checkNumber)
        {
            await BillingInformationConstLocators.CheckNumberInput(_page).FillAsync(checkNumber);
        }

        public async Task SelectPaperlessCommunicationAsync(string paperless)
        {
            await ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaperlessCommunicationButton(_page, paperless).ClickAsync();
        }

        public async Task ClickNextAsync()
        {
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

        public void DisplayQuoteNumber(string quoteNumber)
        {
            Console.WriteLine($"QUOTE NUMBER IS: {quoteNumber}");
        }

    }
}
