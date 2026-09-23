// Pages/QuoteDetailsPage.cs
using Microsoft.Playwright;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages
{
    public class QuoteDetailsPage : BasePage
    {
        public QuoteDetailsPage(IPage page) : base(page) { }

        #region Locators
        // Page Header
        private ILocator PageHeader => _page.GetByText("Proposal Details");

        // Insurance Products
        private ILocator PersonalAutoButton => _page.GetByTestId("proposal.product-chip-item-wrapper").Filter(new() { HasText = "Personal Auto" }).First;
        private ILocator MotorcycleButton => _page.GetByTestId("proposal.product-chip-item-wrapper").Filter(new() { HasText = "Motorcycle" }).First;
        private ILocator RecreationalVehicleButton => _page.GetByTestId("proposal.product-chip-item-wrapper").Filter(new() { HasText = "Recreational Vehicle" }).First;
        private ILocator HomeButton => _page.GetByTestId("proposal.product-chip-item-wrapper").Filter(new() { HasText = "Home" }).First;
        private ILocator BusinessOwnerButton => _page.GetByTestId("proposal.product-chip-item-wrapper").Filter(new() { HasText = "Business Owner" }).First;
        private ILocator FarmPackageButton => _page.GetByTestId("proposal.product-chip-item-wrapper").Filter(new() { HasText = "Special Farm Package" }).First;
        private ILocator FarmPackageSelectedIndicator => _page.GetByTestId("sfp-button");
        // CE confirm-product card — matched by its chip-item-wrapper testid or by card text as fallback
        private ILocator CountryEstateSection =>
            _page.GetByTestId("proposal.sfpProductSelection-chip-item-wrapper")
                 .Filter(new() { HasText = "Country Estate" })
                 .First;

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

        public async Task SelectCountryEstateProductAsync()
        {
            // Country Estate lives under the SFP umbrella: click SFP first to reveal the sub-product picker.
            await SelectSpecialFarmPackageProductAsync();
            await WaitForSpinnerAsync();

            // Wait for the Confirm Product Selection heading to appear
            await _page.GetByText("Confirm Product Selection").First
                       .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });

            // Make sure the CE/SFP compare content has rendered.
            await _page.GetByText(new Regex(@"Country\s*Estate", RegexOptions.IgnoreCase)).First
                       .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });

            // In this two-column layout, CE is the right column.
            // If the right-most SELECTED button is already selected, CE is already active.
            if (await IsRightColumnSelectedAsync())
            {
                Console.WriteLine("[CE] Country Estate already selected");
                return;
            }

            // Click the right-most visible SELECT button (CE column button).
            var selectButtons = _page.GetByText(new Regex(@"^\s*SELECT\s*$", RegexOptions.IgnoreCase));
            await selectButtons.First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });

            var selectBtn = await GetRightMostVisibleButtonAsync(selectButtons);
            await selectBtn.ClickAsync();
            await WaitForSpinnerAsync();

            // Give UI a moment to swap SELECT -> SELECTED labels.
            await _page.WaitForTimeoutAsync(400);

            // Confirm CE (right column) is now selected.
            if (!await IsRightColumnSelectedAsync() && !await IsCountryEstateSelectedByButtonLayoutAsync())
                throw new InvalidOperationException("[CE] Clicked SELECT for Country Estate but selection state could not be confirmed.");

            Console.WriteLine("[CE] Country Estate product selected successfully");
        }

        private async Task<bool> IsCountryEstateSelectedByButtonLayoutAsync()
        {
            // Fallback when SELECTED text isn't exposed to Playwright:
            // if only one visible SELECT remains and it is on the left, CE is selected on the right.
            var selectButtons = _page.GetByText(new Regex(@"^\s*SELECT\s*$", RegexOptions.IgnoreCase));
            var count = await selectButtons.CountAsync();
            if (count == 0)
                return false;

            var visible = new System.Collections.Generic.List<ILocator>();
            for (int i = 0; i < count; i++)
            {
                var candidate = selectButtons.Nth(i);
                var box = await candidate.BoundingBoxAsync();
                if (box != null && box.Width > 0 && box.Height > 0)
                    visible.Add(candidate);
            }

            if (visible.Count != 1)
                return false;

            var only = visible[0];
            var onlyBox = await only.BoundingBoxAsync();
            var viewport = _page.ViewportSize;
            if (onlyBox == null || viewport == null)
                return false;

            return onlyBox.X < (viewport.Width / 2.0);
        }

        private async Task<bool> IsRightColumnSelectedAsync()
        {
            var selectedButtons = _page.GetByText(new Regex(@"^\s*SELECTED\s*$", RegexOptions.IgnoreCase));
            if (await selectedButtons.CountAsync() == 0)
                return false;

            var rightMostSelected = await GetRightMostVisibleButtonAsync(selectedButtons);
            var box = await rightMostSelected.BoundingBoxAsync();
            if (box == null)
                return false;

            var viewport = _page.ViewportSize;
            if (viewport == null)
                return false;

            return box.X > (viewport.Width / 2.0);
        }

        private static async Task<ILocator> GetRightMostVisibleButtonAsync(ILocator buttons)
        {
            var count = await buttons.CountAsync();
            ILocator best = null;
            double bestX = double.MinValue;

            for (int i = 0; i < count; i++)
            {
                var btn = buttons.Nth(i);

                var box = await btn.BoundingBoxAsync();
                if (box == null)
                    continue;

                if (box.Width <= 0 || box.Height <= 0)
                    continue;

                if (box.X > bestX)
                {
                    best = btn;
                    bestX = box.X;
                }
            }

            if (best == null)
                throw new TimeoutException("No visible SELECT/SELECTED product action button found.");

            return best;
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
            await PnCTestAutomation.Helpers.Helpers.SelectByTextAsync(_page, PolicyTermDropdown, contextData.PolicyTerm, timeoutMs: 30000, blurAfterSelect: false);

            await AgentPCCodeInput.FillAsync(contextData.AgentCode);
        }

        public async Task<string> SelectRatingStateAndCompanyAsync(ScenarioContextData contextData)
        {
            // Select Rating State using robust mat-select handler
            await PnCTestAutomation.Helpers.Helpers.SelectByTextAsync(_page, RatingStateDropdown, contextData.RatingState.ToUpper(), timeoutMs: 30000, blurAfterSelect: false);

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
            var popupVisible = false;
            try
            {
                await SSNPopup.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });
                popupVisible = true;
            }
            catch (TimeoutException)
            {
                await WaitForSpinnerAsync();
                popupVisible = await SSNPopup.CountAsync() > 0 && await SSNPopup.IsVisibleAsync();

                if (!popupVisible && await StartQuoteButton.IsHiddenAsync())
                    return;

                if (!popupVisible)
                {
                    throw new InvalidOperationException(
                        $"Start Quote produced neither an SSN dialog nor a page transition. URL='{_page.Url}'.");
                }
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
            await Expect(SSNInput).ToHaveValueAsync(
                new Regex(@"^" + string.Join(@"-?", digitsOnly.Select(character => Regex.Escape(character.ToString()))) + "$"));
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
                var dialogText = string.Empty;
                var dialog = _page.Locator("mat-dialog-container").First;
                if (await dialog.CountAsync() > 0)
                    dialogText = (await dialog.InnerTextAsync()).Replace("\r", " ").Replace("\n", " ").Trim();

                throw new InvalidOperationException(
                    $"SSN submit did not close the SSN popup. URL='{_page.Url}'. Dialog='{dialogText}'.");
            }

            try
            {
                await DialogSubmitButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            }
            catch (TimeoutException)
            {
                await WaitForSpinnerAsync();

                if (await DialogSubmitButton.CountAsync() == 0 || !await DialogSubmitButton.IsVisibleAsync())
                {
                    if (await SSNPopup.CountAsync() > 0 && await SSNPopup.IsVisibleAsync())
                        throw new InvalidOperationException($"SSN popup reappeared after submission. URL='{_page.Url}'.");

                    if (await StartQuoteButton.IsVisibleAsync())
                    {
                        throw new InvalidOperationException(
                            $"SSN submission produced neither a confirmation dialog nor a page transition. URL='{_page.Url}'.");
                    }

                    Console.WriteLine("[SSN] No confirm dialog appeared; quote creation continued.");
                    return;
                }
            }

            Console.WriteLine($"[SSN] Confirm dialog appeared, clicking Submit");
            await DialogSubmitButton.DispatchEventAsync("click");
            await DialogSubmitButton.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 15000 });
            Console.WriteLine($"[SSN] Confirm dialog closed");

            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await WaitForSpinnerAsync();

            // Hard guard: never continue into Policy Details while SSN modal is still blocking.
            if (await SSNPopup.CountAsync() > 0 && await SSNPopup.IsVisibleAsync())
            {
                throw new InvalidOperationException($"SSN popup is still visible after submission. URL='{_page.Url}'.");
            }

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
            // Use robust mat-select handler to avoid race conditions with the dropdown panel
            await PnCTestAutomation.Helpers.Helpers.SelectByTextAsync(_page, RatingStateDropdown, contextData.RatingState.ToUpper(), timeoutMs: 30000, blurAfterSelect: false);
        }

        public async Task EnterAndVerifyEffectiveDateAsync(string effectiveDate)
        {
            await EffDateInput.FillAsync(effectiveDate);
            await EffDateInput.PressAsync("Tab");
            await PnCTestAutomation.Helpers.Helpers.AssertUsDateValueAsync(EffDateInput, effectiveDate, "proposal effective date");
        }
    }
}
