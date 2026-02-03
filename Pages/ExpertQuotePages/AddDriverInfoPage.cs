// Pages/AddDriverInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// Data class to hold driver field values for validation by the caller.
    /// </summary>
    public class DriverFieldValues
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DLState { get; set; } = string.Empty;
    }

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

        /// <summary>
        /// Gets the actual driver field values from the page. 
        /// Returns values for the caller (Steps) to assert.
        /// </summary>
        public async Task<DriverFieldValues> GetDriverFieldValuesAsync()
        {
            var dobString = await Locators.DriverSummaryConstLocators.DateOfBirthInput(_page).InputValueAsync();
            
            return new DriverFieldValues
            {
                FirstName = (await Locators.DriverSummaryConstLocators.FirstNameInput(_page).InputValueAsync()).Trim(),
                LastName = (await Locators.DriverSummaryConstLocators.LastNameInput(_page).InputValueAsync()).Trim(),
                DateOfBirth = DateTime.Parse(dobString, CultureInfo.InvariantCulture),
                PhoneNumber = await Locators.DriverSummaryConstLocators.PhoneNumberInput(_page).InputValueAsync(),
                Email = await Locators.DriverSummaryConstLocators.EmailAddressInput(_page).InputValueAsync(),
                DLState = await Locators.DriverSummaryConstLocators.DLStateDropdown(_page).InnerTextAsync()
            };
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
            // Wait for any conditional fields to appear based on prior insurance selection
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
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

                await Locators.DriverSummaryConstLocators.PriorYearsWithCarrierInput(_page)
                    .WaitForAsync(new() { State = WaitForSelectorState.Visible });

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
            // Wait for page transition and MVR check to complete
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
        }

        public async Task HandleMVRPopUpAsync()
        {
            // Wait for MVR popup to potentially appear (with short timeout)
            try
            {
                await DriverSummaryConstLocators.MVRPopUpContinueButton(_page).WaitForAsync(
                    new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                Console.WriteLine("Found MVR Dialog");
                await DriverSummaryConstLocators.MVRPopUpContinueButton(_page).ClickAsync();
            }
            catch (TimeoutException)
            {
                Console.WriteLine("MVR Dialog Not Found - continuing.");
            }

            // Check for prefill driver page
            if (await _page.Locator(Locators.DriverSummaryConstLocators.PrefillDriverPageHeader).IsVisibleAsync())
            {
                Console.WriteLine("Prefill Driver Page detected - clicking Save and Continue");
                await LoadingHelpers.WaitForAngularSpinnerAsync(_page);
                await Locators.GlobalLocators.SaveAndContinueButton(_page).ClickAsync();
            }
        }

    }
}

