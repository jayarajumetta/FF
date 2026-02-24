// Pages/ExpertQuotePages/PA_AddDriverInfoPage.cs
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
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

    public class PA_AddDriverInfoPage : BasePage
    {
        public PA_AddDriverInfoPage(IPage page) : base(page) { }

        #region Locators
        // Quote Number
        private ILocator QuoteNumberLocator => _page.Locator("div[class*='mat-tab-label-container'] span");

        // Driver Summary Fields
        private ILocator FirstNameInput => _page.GetByLabel("First Name");
        private ILocator MiddleNameInput => _page.GetByLabel("Middle Name");
        private ILocator LastNameInput => _page.GetByLabel("Last Name");
        private ILocator DateOfBirthInput => _page.GetByLabel("Date Of Birth");
        private ILocator PhoneNumberInput => _page.GetByLabel("Phone Number");
        private ILocator EmailAddressInput => _page.GetByLabel("Email Address");
        private ILocator EditSSNButton => _page.GetByRole(AriaRole.Button, new() { Name = "Edit SSN#" });
        private ILocator DLStateDropdown => _page.GetByRole(AriaRole.Combobox, new() { Name = "Driver's License State" });
        private ILocator DLNumberInput => _page.GetByLabel("Driver's License Number");
        private ILocator YearsLicensedInput => _page.GetByLabel("Years");
        private ILocator MonthsLicensedInput => _page.GetByLabel("Months");
        private ILocator SuffixDropdown => _page.GetByRole(AriaRole.Combobox, new() { Name = "Suffix" });
        private ILocator MoreOptionsMaritalStatus => _page.Locator("[data-testid*='maritalStatus.value-other']");
        private ILocator MoreOptionsOperatorStatus => _page.Locator("[data-testid*='operatorStatuc.value-other']");

        // Prior Insurance
        private ILocator PriorCarrierNameInput => _page.Locator("[data-testid*='priorCarrierName']");
        private ILocator PriorPolicyNumberInput => _page.Locator("[data-testid*='priorPolicyNumber']");
        private ILocator PriorCarrierPrefill => _page.Locator("div[id*='PriorCarrierName'] span.readonly-value");
        private ILocator PriorYearsWithCarrierInput => _page.Locator("[data-testid*='yearsWithPriorCarrier']");
        private ILocator PriorMonthsWithCarrierInput => _page.Locator("[data-testid*='monthsWithPriorCarrier']");

        // MVR Pop-Up
        private ILocator MVRPopUpContinueButton => _page.GetByTestId("btnConfirmYes");
        private ILocator MVRPopUpBackToDetailsButton => _page.GetByTestId("btnConfirmNo");
        private ILocator PrefillDriverPageHeader => _page.Locator("section header h1");

        // Global buttons
        private ILocator SaveAndContinueButton => _page.GetByTestId("fields.line.save_and_Continue");

        // Dynamic locators
        private ILocator GetGenderButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetEmailTypeButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetMaritalStatusButton(string maritalStatus) =>
            _page.Locator("button[data-testid^='owner.maritalStatus-']").Filter(new() { HasTextString = maritalStatus.Trim() });

        private ILocator GetNamedInsuredButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetOperatorStatusButton(string value) =>
            _page.GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetFinancialResponsibilityButton(string yesOrNo) =>
            _page.Locator($"button[id*='sR22Indicator'] div:has-text('{yesOrNo}')").First;

        private ILocator GetPriorInsuranceButton(string yesOrNo) =>
            _page.Locator($"button[id*='priorInsurance'] div:has-text('{yesOrNo}')").First;

        private ILocator GetReasonForNoPriorInsuranceButton(string value) =>
            _page.Locator($"button:has-text('{value}')");
        #endregion

        public async Task PreparePriorInsuranceReasonAsync(ScenarioContextData contextData)
        {
            if (contextData.PriorInsurance.Equals("No", StringComparison.OrdinalIgnoreCase))
                contextData.NoPriorInsuranceReason = contextData.NoPriorInsuranceReason.Trim();
        }

        public async Task CollectAndStoreQuoteNumberAsync(ScenarioContextData contextData)
        {
            var fullText = await QuoteNumberLocator.InnerTextAsync();
            var lines = fullText.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var quoteNumber = lines.Length > 1 ? lines[1].Trim() : fullText.Trim();
            contextData.QuoteNumber = quoteNumber;
            Console.WriteLine($"Quote Number is: {quoteNumber}");
        }

        public async Task WaitForPageLoadAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
        }

        public async Task<DriverFieldValues> GetDriverFieldValuesAsync()
        {
            var dobString = await DateOfBirthInput.InputValueAsync();

            return new DriverFieldValues
            {
                FirstName = (await FirstNameInput.InputValueAsync()).Trim(),
                LastName = (await LastNameInput.InputValueAsync()).Trim(),
                DateOfBirth = DateTime.Parse(dobString, CultureInfo.InvariantCulture),
                PhoneNumber = await PhoneNumberInput.InputValueAsync(),
                Email = await EmailAddressInput.InputValueAsync(),
                DLState = await DLStateDropdown.InnerTextAsync()
            };
        }

        public async Task SelectDriverOptionsAsync(ScenarioContextData contextData)
        {
            await ClickIfNotSelectedAsync(GetEmailTypeButton(contextData.EmailType));
            await ClickIfNotSelectedAsync(GetGenderButton(contextData.Gender));

            var selectedButtonLocator = _page.Locator("div[id*='maritalStatus'] button.mat-button-toggle-checked");
            bool anySelected = await selectedButtonLocator.CountAsync() > 0;

            if (!anySelected)
            {
                if (!contextData.MaritalStatus.Equals("Single", StringComparison.OrdinalIgnoreCase) &&
                    !contextData.MaritalStatus.Equals("Married", StringComparison.OrdinalIgnoreCase) &&
                    !contextData.MaritalStatus.Equals("Divorced", StringComparison.OrdinalIgnoreCase))
                {
                    await MoreOptionsMaritalStatus.ClickAsync();
                    await ClickIfNotSelectedAsync(GetMaritalStatusButton(contextData.MaritalStatus));
                }
                else
                {
                    await ClickIfNotSelectedAsync(GetMaritalStatusButton(contextData.MaritalStatus));
                }
            }

            await ClickIfNotSelectedAsync(GetNamedInsuredButton(contextData.NamedInsured));

            if (!contextData.OperatorStatus.Equals("Assigned", StringComparison.OrdinalIgnoreCase) &&
                !contextData.OperatorStatus.Equals("Non Driver", StringComparison.OrdinalIgnoreCase) &&
                !contextData.OperatorStatus.Equals("Related", StringComparison.OrdinalIgnoreCase))
            {
                await MoreOptionsOperatorStatus.ClickAsync();
                await ClickIfNotSelectedAsync(GetOperatorStatusButton(contextData.OperatorStatus));
            }
            else
            {
                await ClickIfNotSelectedAsync(GetOperatorStatusButton(contextData.OperatorStatus));
            }
        }

        public async Task FillDriverLicenseFieldsAsync(ScenarioContextData contextData)
        {
            await DLNumberInput.FillAsync(contextData.DLNumber);
            await YearsLicensedInput.FillAsync(contextData.YearsLicensed);
            await MonthsLicensedInput.FillAsync(contextData.MonthsLicensed);
        }

        public async Task SelectInsuranceOptionsAsync(ScenarioContextData contextData)
        {
            await ClickIfNotSelectedAsync(GetFinancialResponsibilityButton(contextData.FinancialResponsibility));
            await ClickIfNotSelectedAsync(GetPriorInsuranceButton(contextData.PriorInsurance));
            await WaitForSpinnerAsync();
        }

        public async Task HandlePriorInsuranceAsync(ScenarioContextData contextData)
        {
            if (!string.IsNullOrWhiteSpace(contextData.PriorInsurance) &&
                contextData.PriorInsurance.Trim().Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                if (await PriorCarrierPrefill.IsVisibleAsync())
                {
                    var priorCarrierValue = await PriorCarrierPrefill.TextContentAsync();
                    if (!string.IsNullOrWhiteSpace(priorCarrierValue))
                    {
                        return;
                    }
                }

                await _page.WaitForLoadStateAsync(LoadState.Load);

                await PriorCarrierNameInput.FillAsync(contextData.PriorCarrier);
                await PriorPolicyNumberInput.FillAsync(contextData.PriorPolicyNumber);

                await PriorYearsWithCarrierInput.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 2000
                });

                await PriorYearsWithCarrierInput.FillAsync(contextData.PriorInsuranceYears);
                await PriorMonthsWithCarrierInput.FillAsync(contextData.PriorInsuranceMonths);
            }
            else
            {
                var reasonButton = GetReasonForNoPriorInsuranceButton(contextData.NoPriorInsuranceReason);
                await reasonButton.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 5000
                });

                await ClickIfNotSelectedAsync(reasonButton);
            }
        }

        public async Task SaveAndContinueAsync()
        {
            await SaveAndContinueButton.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await WaitForSpinnerAsync();
        }

        public async Task HandleMVRPopUpAsync()
        {
            try
            {
                await MVRPopUpContinueButton.WaitForAsync(
                    new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                Console.WriteLine("Found MVR Dialog");
                await MVRPopUpContinueButton.ClickAsync();
            }
            catch (TimeoutException)
            {
                Console.WriteLine("MVR Dialog Not Found - continuing.");
            }

            if (await PrefillDriverPageHeader.IsVisibleAsync())
            {
                Console.WriteLine("Prefill Driver Page detected - clicking Save and Continue");
                await WaitForSpinnerAsync();
                await SaveAndContinueButton.ClickAsync();
            }
        }
    }
}
