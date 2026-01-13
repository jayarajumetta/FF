
// Pages/AddDriverInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;
using NUnit.Framework;

namespace Playwright_POC.Pages
{
    public class AddDriverInfoPage
    {
        private readonly IPage _page;

        public AddDriverInfoPage(IPage page)
        {
            _page = page;
        }


        public async Task PreparePriorInsuranceReasonAsync(ScenarioContextData contextData)
        {
            if (contextData.PriorInsurance.Equals("No", StringComparison.OrdinalIgnoreCase))
                contextData.NoPriorInsuranceReason = contextData.NoPriorInsuranceReason.Trim();
        }

        public async Task CollectAndStoreQuoteNumberAsync(ScenarioContextData contextData)
        {
            var fullText = await _page.InnerTextAsync(Locators.GlobalLocators.QuoteNumber);
            var lines = fullText.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var quoteNumber = lines.Length > 1 ? lines[1].Trim() : fullText.Trim();
            contextData.QuoteNumber = quoteNumber;
            Console.WriteLine($"Quote Number is: {quoteNumber}");
        }

        public async Task WaitForPageLoadAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
        }

        public async Task ValidateDriverFieldsAsync(ScenarioContextData contextData)
        {
            DateTime expectedDOB = DateTime.Parse(contextData.ClientDOB, CultureInfo.InvariantCulture);
            DateTime actualDob = DateTime.Parse(await _page.InputValueAsync(Locators.DriverSummaryConstLocators.DateOfBirthInput));

            var actualFirstName = (await _page.InputValueAsync(Locators.DriverSummaryConstLocators.FirstNameInput)).Trim();
            var expectedFirstName = contextData.ClientFirstName.Trim();
            Assert.That(actualFirstName.Equals(expectedFirstName, StringComparison.OrdinalIgnoreCase),
                $"First Name does not match expected value. Expected: '{expectedFirstName}', Actual: '{actualFirstName}'");

            var actualLastName = (await _page.InputValueAsync(Locators.DriverSummaryConstLocators.LastNameInput)).Trim();
            var expectedLastName = contextData.ClientLastName.Trim();
            Assert.That(actualLastName.Equals(expectedLastName, StringComparison.OrdinalIgnoreCase),
                $"Last Name does not match expected value. Expected: '{expectedLastName}', Actual: '{actualLastName}'");
            Assert.That(actualDob, Is.EqualTo(expectedDOB), "DOB does not match expected value.");
            Assert.That(await _page.InputValueAsync(Locators.DriverSummaryConstLocators.PhoneNumberInput), Is.EqualTo(contextData.ClientPhoneNumber), "Phone Number does not match expected value.");
            Assert.That(await _page.InputValueAsync(Locators.DriverSummaryConstLocators.EmailAddressInput), Is.EqualTo(contextData.ClientEmail), "Email Address does not match expected value.");
            Assert.That(await _page.InnerTextAsync(Locators.DriverSummaryConstLocators.DLStateDropdown), Is.EqualTo(contextData.DLState), "State does not match expected value.");
        }

        public async Task SelectDriverOptionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetEmailTypeButton(contextData.EmailType));
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetGenderButton(contextData.Gender));

            var selectedButtonLocator = _page.Locator("xpath=.//div[contains(@id, 'maritalStatus')]//button[contains(@class, 'mat-button-toggle-checked')]");
            bool anySelected = await selectedButtonLocator.CountAsync() > 0;

            if (!anySelected)
            {
                if (!contextData.MaritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                    !contextData.MaritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                    !contextData.MaritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
                {
                    await _page.ClickAsync(Locators.DriverSummaryConstLocators.MoreOptionsMaritalStatus);
                    await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(contextData.MaritalStatus));
                }
                else
                {
                    await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(contextData.MaritalStatus));
                }
            }

            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetNamedInsuredButton(contextData.NamedInsured));

            if (!contextData.OperatorStatus.Equals("Assigned", StringComparison.OrdinalIgnoreCase) &&
                !contextData.OperatorStatus.Equals("Non Driver", StringComparison.OrdinalIgnoreCase) &&
                !contextData.OperatorStatus.Equals("Related", StringComparison.OrdinalIgnoreCase))
            {
                await _page.ClickAsync(Locators.DriverSummaryConstLocators.MoreOptionsOperatorStatus);
                await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetOperatorStatus(contextData.OperatorStatus));
            }
            else
            {
                await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetOperatorStatus(contextData.OperatorStatus));
            }
        }

        public async Task FillDriverLicenseFieldsAsync(ScenarioContextData contextData)
        {
            await _page.FillAsync(Locators.DriverSummaryConstLocators.DLNumberInput, contextData.DLNumber);
            await _page.FillAsync(Locators.DriverSummaryConstLocators.YearsLicensedInput, contextData.YearsLicensed);
            await _page.FillAsync(Locators.DriverSummaryConstLocators.MonthsLicensedInput, contextData.MonthsLicensed);
        }

        public async Task SelectInsuranceOptionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetFinancialResponsibilityButton(contextData.FinancialResponsibility));
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetPriorInsuranceButton(contextData.PriorInsurance));
            await _page.WaitForTimeoutAsync(2000);
        }

        public async Task HandlePriorInsuranceAsync(ScenarioContextData contextData)
        {
            if (!string.IsNullOrWhiteSpace(contextData.PriorInsurance) &&
                contextData.PriorInsurance.Trim().Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                if (await _page.IsVisibleAsync(Locators.DriverSummaryConstLocators.PriorCarrierPrefill))
                {
                    var priorCarrierValue = await _page.TextContentAsync(Locators.DriverSummaryConstLocators.PriorCarrierPrefill);
                    if (!string.IsNullOrWhiteSpace(priorCarrierValue))
                    {
                        return;
                    }
                }

                await _page.WaitForLoadStateAsync(LoadState.Load);

                await _page.FillAsync(Locators.DriverSummaryConstLocators.PriorCarrierNameInput, contextData.PriorCarrier);
                await _page.FillAsync(Locators.DriverSummaryConstLocators.PriorPolicyNumberInput, contextData.PriorPolicyNumber);

                await _page.WaitForSelectorAsync(Locators.DriverSummaryConstLocators.PriorYearsWithCarrierInput, new() { Timeout = 2000 });
                await _page.Locator(Locators.DriverSummaryConstLocators.PriorYearsWithCarrierInput)
                    .WaitForAsync(new() { State = WaitForSelectorState.Visible });

                await _page.FillAsync(Locators.DriverSummaryConstLocators.PriorYearsWithCarrierInput, contextData.PriorInsuranceYears);
                await _page.FillAsync(Locators.DriverSummaryConstLocators.PriorMonthsWithCarrierInput, contextData.PriorInsuranceMonths);
            }
            else
            {
                await _page.WaitForSelectorAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetReasonForNoPriorInsurance(contextData.NoPriorInsuranceReason), new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 5000
                });

                await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetReasonForNoPriorInsurance(contextData.NoPriorInsuranceReason));
            }
        }

        public async Task SaveAndContinueAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.SaveAndContinueButton);
            await _page.WaitForTimeoutAsync(10000);
        }

        public async Task HandleMVRPopUpAsync()
        {
            await _page.WaitForTimeoutAsync(8000);
            if (await _page.Locator(Locators.DriverSummaryConstLocators.MVRPopUpContinueButton).IsVisibleAsync())
            {
                await _page.WaitForTimeoutAsync(2000);
                Console.WriteLine("Found Dialog Container");
                await _page.ClickAsync(Locators.DriverSummaryConstLocators.MVRPopUpContinueButton);
            }
            else
            {
                Console.WriteLine("Dialog Container Not Found.");
            }

            if (await _page.Locator(Locators.DriverSummaryConstLocators.PrefillDriverPageHeader).IsVisibleAsync())
            {
                await _page.WaitForTimeoutAsync(2000);
                Console.WriteLine("CONDITION TRIGGERED");
                await _page.ClickAsync(Locators.GlobalLocators.SaveAndContinueButton);
            }
        }

    }
}

