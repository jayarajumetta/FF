// Pages/QuoteDetailsPage.cs
using Microsoft.Playwright;
using System;
using System.Linq;
using System.Threading.Tasks;
using Playwright_POC.Helpers;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages
{
    public class QuoteDetailsPage : BasePage
    {
        public QuoteDetailsPage(IPage page) : base(page) { }

        #region Locators
        // Page Header
        private ILocator PageHeader => _page.GetByText("Proposal Details");

        // Insurance Products
        private ILocator PersonalAutoButton => _page.GetByTestId("proposal.product-0");
        private ILocator MotorcycleButton => _page.GetByTestId("proposal.product-1");
        private ILocator RecreationalVehicleButton => _page.GetByTestId("proposal.product-2");
        private ILocator HomeButton => _page.GetByTestId("proposal.product-3");
        private ILocator BusinessOwnerButton => _page.GetByTestId("proposal.product-4");
        private ILocator FarmPackageButton => _page.GetByTestId("proposal.product-5");
        private ILocator FarmPackageSelectedIndicator => _page.GetByTestId("sfp-button");

        // Quote Details
        private ILocator EffDateInput => _page.Locator("input[name='proposal.effectiveDate']");
        private ILocator PolicyTermDropdown => _page.GetByTestId("proposal.term");
        private ILocator AgentPCCodeInput => _page.GetByTestId("proposal.agentPC");
        private ILocator SalesAssociatePCCodeInput => _page.GetByTestId("proposal.associatePC");
        private ILocator RatingStateDropdown => _page.GetByTestId("proposal.ratingState");
        private ILocator WritingCompanyDropdownValue => _page.GetByTestId("proposal.writingCompany");
        private ILocator RiskAddressRadioButton => _page.Locator("mat-radio-button[id='proposal.riskAddressSelection-0']");
        private ILocator AddNewRiskAddressRadioButton => _page.Locator("mat-radio-button[id='proposal.riskAddressSelection-1']");
        private ILocator StartQuoteButton => _page.Locator("#startQuote");
        private ILocator IndividuallyOwnedCheckbox => _page.GetByTestId("business.isIndividualDba");
        private ILocator DBANameInput => _page.GetByTestId("business.individualDba");
        private ILocator GrossFarmIncomeInput => _page.GetByTestId("fields.account.policyInput$grossFarmIncome.value");

        // Business Entity Search
        private ILocator BusinessEntitySearchInput => _page.Locator("input[name='business.search.businessName']");
        private ILocator BusinessEntitySearchButton => _page.Locator("button:has-text('Search')");

        // SSN Pop-Up
        private ILocator SSNPopup => _page.GetByRole(AriaRole.Heading, new() { Name = "Enter the Client's Full SSN#" });
        private ILocator SSNInput => _page.GetByTestId("ssn");
        // btnConfirmYes is wrapped in <ng-component> which intercepts pointer events.
        // Use DispatchEventAsync("click") instead of ClickAsync everywhere this is used.
        private ILocator DialogSubmitButton => _page.GetByTestId("btnConfirmYes");

        // Client Exists Pop-Up
        private ILocator ClientExistsPopup => _page.Locator("mat-dialog-container h2:has-text('Client Already Exists')");
        private ILocator CreateNewClientPopupButton => _page.Locator("mat-dialog-container a:has-text('Create New Account')");

        // Dynamic locators
        private ILocator GetLessorsRiskExposureButton(string yesOrNo) =>
            _page.Locator($"button[id*='LessorsRiskExposure'] div:has-text('{yesOrNo}')");
        #endregion

        public async Task WaitForProposalPageLoadAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.Load);
        }

        public async Task SelectPersonalAutoProductAsync()
        {
            await PersonalAutoButton.ClickAsync();
        }

        public async Task SelectMotorcycleProductAsync()
        {
            await MotorcycleButton.ClickAsync();
        }

        public async Task SelectRecreationalVehicleProductAsync()
        {
            await RecreationalVehicleButton.ClickAsync();
        }

        public async Task SelectHomeProductAsync()
        {
            await HomeButton.ClickAsync();
        }

        public async Task SelectBusinessOwnerProductAsync()
        {
            await BusinessOwnerButton.ClickAsync();
        }

        public async Task SelectSpecialFarmPackageProductAsync()
        {
            await FarmPackageButton.ClickAsync();
        }

        public async Task WaitForSpecialFarmPackageSelectedAsync()
        {
            await Expect(FarmPackageSelectedIndicator).ToBeVisibleAsync(new() { Timeout = 10000 });
        }

        public async Task<string> EnterQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await EffDateInput.FillAsync(contextData.EffectiveDate);
            string actualPolicyTerm = await PolicyTermDropdown.InnerTextAsync();
            await AgentPCCodeInput.FillAsync(contextData.AgentCode);
            return actualPolicyTerm.Trim();
        }

        public async Task EnterSFPQuoteDetailsAsync(ScenarioContextData contextData)
        {
            await Expect(_page.GetByText("Quote Details")).ToBeVisibleAsync(new() { Timeout = 30000 });

            var effDateField = _page.Locator("input[formcontrolname='effectiveDate'], input[name='effectiveDate'], input[id*='effectiveDate'], input[data-testid*='effectiveDate']").First;

            if (!await effDateField.IsVisibleAsync())
            {
                effDateField = _page.Locator("mat-form-field:has-text('Effective Date') input").First;
            }

            await Expect(effDateField).ToBeVisibleAsync(new() { Timeout = 30000 });
            await effDateField.FillAsync(contextData.EffectiveDate);

            // Select Policy Term using robust mat-select handler
            await Playwright_POC.Helpers.Helpers.SelectByTextAsync(_page, PolicyTermDropdown, contextData.PolicyTerm, timeoutMs: 30000, blurAfterSelect: false);

            await AgentPCCodeInput.FillAsync(contextData.AgentCode);
        }

        public async Task<string> SelectRatingStateAndCompanyAsync(ScenarioContextData contextData)
        {
            // Select Rating State using robust mat-select handler
            await Playwright_POC.Helpers.Helpers.SelectByTextAsync(_page, RatingStateDropdown, contextData.RatingState.ToUpper(), timeoutMs: 30000, blurAfterSelect: false);

            await WaitForSpinnerAsync();

            string actualWritingCompany = await WritingCompanyDropdownValue.InnerTextAsync();
            return actualWritingCompany.Trim();
        }

        public async Task SelectRiskAddressAsync(ScenarioContextData contextData)
        {
            var displayedRiskAddress = await RiskAddressRadioButton.InnerTextAsync();
            Console.WriteLine($"Displayed Risk Address: {displayedRiskAddress}");
            Console.WriteLine($"Provided Risk Address: {contextData.RiskAddress}");
            if (displayedRiskAddress.Trim().Equals(contextData.RiskAddress.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                await RiskAddressRadioButton.ClickAsync();
            }
            else
            {
                await AddNewRiskAddressRadioButton.ClickAsync();
            }
        }

        public async Task SelectLessorsRiskExposureAsync(ScenarioContextData contextData)
        {
            await GetLessorsRiskExposureButton(contextData.LessorRiskExposure).ClickAsync();
        }

        public async Task SelectBusinessEntityAsync(ScenarioContextData contextData)
        {
            if ((contextData.BusinessEntity == "Individually Owned") || (contextData.BusinessEntity == "DBA") || (contextData.BusinessEntity == "T/A"))
            {
                await IndividuallyOwnedCheckbox.ClickAsync();
                await Expect(DBANameInput).ToBeVisibleAsync();
                await DBANameInput.FillAsync(contextData.DBAName);
            }
            else
            {
                await BusinessEntitySearchInput.FillAsync(contextData.BusinessEntity);
                await BusinessEntitySearchButton.ClickAsync();
                await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            }
        }

        public async Task ClickStartQuoteAsync()
        {
            await StartQuoteButton.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task HandleSSNPopupsAsync(ScenarioContextData contextData)
        {
            // Wait up to 15s for the SSN popup — it can appear well after ClickStartQuoteAsync
            var popupVisible = false;
            try
            {
                await SSNPopup.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
                popupVisible = true;
            }
            catch (TimeoutException)
            {
                // SSN popup didn't appear - continue
            }

            if (!popupVisible)
            {
                await WaitForSpinnerAsync();
                return;
            }

            string ssnToUse = !string.IsNullOrWhiteSpace(contextData.SSN)
                ? contextData.SSN
                : RandomGenerators.GenerateRandomSSN();
            contextData.SSN = ssnToUse;

            // ngx-mask input: type digits only, the mask inserts dashes automatically.
            // PressSequentiallyAsync fires real keystroke events that the mask processes.
            var digitsOnly = new string(ssnToUse.Where(char.IsDigit).ToArray());
            await SSNInput.ClickAsync();
            await SSNInput.PressSequentiallyAsync(digitsOnly, new() { Delay = 50 });
            await Task.Delay(500);

            Console.WriteLine($"[SSN] Typed SSN digits, clicking Submit");
            await DialogSubmitButton.DispatchEventAsync("click");
            Console.WriteLine($"[SSN] Submit clicked, waiting for popup to close");

            // Wait for the popup to close (up to 15s) before continuing
            try
            {
                await SSNPopup.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 15000 });
                Console.WriteLine($"[SSN] First popup closed");
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[SSN] Warning: First popup did not close — Submit may not have worked");
            }

            // Check for confirm dialog (same btnConfirmYes) — allow up to 10s.
            try
            {
                await DialogSubmitButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                Console.WriteLine($"[SSN] Confirm dialog appeared, clicking Submit");
                await DialogSubmitButton.DispatchEventAsync("click");

                // Wait for the confirm dialog to close before proceeding
                await DialogSubmitButton.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 15000 });
                Console.WriteLine($"[SSN] Confirm dialog closed");
                await Task.Delay(500);
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[SSN] No confirm dialog appeared - continuing");
            }

            // Wait for DuckCreek's full page navigation after SSN submission to settle
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await WaitForSpinnerAsync();
            Console.WriteLine($"[SSN] Page settled after SSN — URL: {_page.Url}");
        }

        public async Task HandleClientExistsPopupAsync()
        {
            try
            {
                await ClientExistsPopup.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 3000 });
                await CreateNewClientPopupButton.ClickAsync();
            }
            catch (TimeoutException)
            {
                // Popup didn't appear - continue
            }
        }

        public async Task SelectRatingStateAsync(ScenarioContextData contextData)
        {
            await RatingStateDropdown.ClickAsync();
            await Task.Delay(500);
            // Dropdown shows states in UPPERCASE (Angular Material mat-option)
            // Use Exact = true to prevent "KANSAS" from matching "ARKANSAS"
            await _page.GetByRole(AriaRole.Option, new() { Name = contextData.RatingState.ToUpper(), Exact = true }).ClickAsync();
        }
    }
}
