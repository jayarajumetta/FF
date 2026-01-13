
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
            await _page.ClickAsync(Locators.BillingInformationConstLocators.CreateNewBillingAccountButton);
        }

        public async Task SelectPrimaryPayerAsync(string primaryPayer)
        {
            await _page.WaitForTimeoutAsync(4000); 
            await _page.ClickAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPrimaryPayerButton(primaryPayer));
        }

        public async Task SelectPaymentTypeAsync(string paymentType)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentTypeButton(paymentType));
        }

        public async Task WaitForPaymentPlanAsync(string paymentPlan)
        {
            await _page.WaitForSelectorAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentPlanButton(paymentPlan), new() { Timeout = 15000 });
        }

        public async Task SelectPaymentPlanAsync(string paymentPlan)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentPlanButton(paymentPlan));
        }

        public async Task WaitForPaymentDueDateInputAsync()
        {
            await _page.WaitForSelectorAsync(Locators.BillingInformationConstLocators.PaymentDueDateInput, new() { Timeout = 3000 });
        }

        public async Task EnterPaymentDueDateAsync(string paymentDueDate)
        {
            await _page.FillAsync(Locators.BillingInformationConstLocators.PaymentDueDateInput, paymentDueDate);
        }

        public async Task SelectPaymentAmountAsync(string paymentAmount)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentAmountRadioButton(paymentAmount));
        }

        public async Task SelectPaymentMethodAsync(string paymentMethod)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaymentMethodButton(paymentMethod));
        }

        public async Task EnterCheckNumberAsync(string checkNumber)
        {
            await _page.FillAsync(Locators.BillingInformationConstLocators.CheckNumberInput, checkNumber);
        }

        public async Task SelectPaperlessCommunicationAsync(string paperless)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.BillingInformationsPageLocators.GetPaperlessCommunicationButton(paperless));
        }

        public async Task ClickNextAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

        public void DisplayQuoteNumber(string quoteNumber)
        {
            Console.WriteLine($"QUOTE NUMBER IS: {quoteNumber}");
        }

    }
}
