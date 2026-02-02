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
            DateTime actualDob = DateTime.Parse(await (Locators.DriverSummaryConstLocators.DateOfBirthInput(_page)).InputValueAsync());

            var actualFirstName = (await (Locators.DriverSummaryConstLocators.FirstNameInput(_page)).InputValueAsync()).Trim();
            var expectedFirstName = contextData.ClientFirstName.Trim();
            Assert.That(actualFirstName.Equals(expectedFirstName, StringComparison.OrdinalIgnoreCase),
                $"First Name does not match expected value. Expected: '{expectedFirstName}', Actual: '{actualFirstName}'");

            var actualLastName = (await (Locators.DriverSummaryConstLocators.LastNameInput(_page)).InputValueAsync()).Trim();
            var expectedLastName = contextData.ClientLastName.Trim();
            Assert.That(actualLastName.Equals(expectedLastName, StringComparison.OrdinalIgnoreCase),
                $"Last Name does not match expected value. Expected: '{expectedLastName}', Actual: '{actualLastName}'");
            Assert.That(actualDob, Is.EqualTo(expectedDOB), "DOB does not match expected value.");
            Assert.That(await (Locators.DriverSummaryConstLocators.PhoneNumberInput(_page)).InputValueAsync(), Is.EqualTo(contextData.ClientPhoneNumber), "Phone Number does not match expected value.");
            Assert.That(await (Locators.DriverSummaryConstLocators.EmailAddressInput(_page)).InputValueAsync(), Is.EqualTo(contextData.ClientEmail), "Email Address does not match expected value.");
            Assert.That(await (Locators.DriverSummaryConstLocators.DLStateDropdown(_page)).InnerTextAsync(), Is.EqualTo(contextData.DLState), "State does not match expected value.");
        }

        public async Task SelectDriverOptionsAsync(ScenarioContextData contextData)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetEmailTypeButton(_page, contextData.EmailType));
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetGenderButton(_page, contextData.Gender));

            var selectedButtonLocator = _page.Locator("xpath=.//div[contains(@id, 'maritalStatus')]//button[contains(@class, 'mat-button-toggle-checked')]");
            bool anySelected = await selectedButtonLocator.CountAsync() > 0;

            if (!anySelected)
            {
                if (!contextData.MaritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                    !contextData.MaritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                    !contextData.MaritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
                {
                    await DriverSummaryConstLocators.MoreOptionsMaritalStatus(_page).ClickAsync();
                    await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(_page, contextData.MaritalStatus));
                }
                else
                {
                    await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetMaritalStatusSelection(_page, contextData.MaritalStatus));
                }
            }

            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetNamedInsuredButton(_page, contextData.NamedInsured));

            if (!contextData.OperatorStatus.Equals("Assigned", StringComparison.OrdinalIgnoreCase) &&
                !contextData.OperatorStatus.Equals("Non Driver", StringComparison.OrdinalIgnoreCase) &&
                !contextData.OperatorStatus.Equals("Related", StringComparison.OrdinalIgnoreCase))
            {
                await DriverSummaryConstLocators.MoreOptionsOperatorStatus(_page).ClickAsync();
                await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetOperatorStatus(_page, contextData.OperatorStatus));
            }
            else
            {
                await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.DriverSummaryPageLocators.GetOperatorStatus(_page, contextData.OperatorStatus));
            }
        }

        public async Task FillDriverLicenseFieldsAsync(ScenarioContextData contextData)
        {
            await Locators.DriverSummaryConstLocators.DLNumberInput(_page).FillAsync(contextData.DLNumber);
            await Locators.DriverSummaryConstLocators.YearsLicensedInput(_page).FillAsync(contextData.YearsLicensed);
            await Locators.DriverSummaryConstLocators.MonthsLicensedInput(_page).FillAsync(contextData.MonthsLicensed);
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

                await Locators.DriverSummaryConstLocators.PriorCarrierNameInput(_page).FillAsync(contextData.PriorCarrier);
                await Locators.DriverSummaryConstLocators.PriorPolicyNumberInput(_page).FillAsync(contextData.PriorPolicyNumber);

                await Locators.DriverSummaryConstLocators
                    .PriorYearsWithCarrierInput(_page)
                    .WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 2000
                    });


                await Locators.DriverSummaryConstLocators.PriorYearsWithCarrierInput(_page).FillAsync(contextData.PriorInsuranceYears);
                await Locators.DriverSummaryConstLocators.PriorMonthsWithCarrierInput(_page).FillAsync(contextData.PriorInsuranceMonths);
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
            await Locators.GlobalLocators.SaveAndContinueButton(_page).ClickAsync();
            await _page.WaitForTimeoutAsync(10000);
        }

        public async Task HandleMVRPopUpAsync()
        {
            await _page.WaitForTimeoutAsync(8000);
            if (await DriverSummaryConstLocators.MVRPopUpContinueButton(_page).IsVisibleAsync())
            {
                await _page.WaitForTimeoutAsync(2000);
                Console.WriteLine("Found Dialog Container");
                await DriverSummaryConstLocators.MVRPopUpContinueButton(_page).ClickAsync();
            }
            else
            {
                Console.WriteLine("Dialog Container Not Found.");
            }

            if (await _page.Locator(Locators.DriverSummaryConstLocators.PrefillDriverPageHeader).IsVisibleAsync())
            {
                await _page.WaitForTimeoutAsync(2000);
                Console.WriteLine("CONDITION TRIGGERED");
                await Locators.GlobalLocators.SaveAndContinueButton(_page).ClickAsync();
            }
        }

    }
}

