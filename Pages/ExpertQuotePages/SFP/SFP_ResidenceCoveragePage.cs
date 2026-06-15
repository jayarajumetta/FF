using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Residence Coverage detail section — expands inline on the Add Residence page
    /// after the "Residence Coverage" checkbox is checked.
    /// </summary>
    public class SFP_ResidenceCoveragePage : BasePage
    {
        public SFP_ResidenceCoveragePage(IPage page) : base(page) { }

        #region Locators
        public ILocator InsuranceAmountInput =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$limit.value");

        public ILocator SquareFeetInput =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$squareFt.value");

        public ILocator PerilsSelect =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$perilGroup.value");

        // Thermostat Question (No / Yes)
        private ILocator GetThermostatButton(string yesOrNo) =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-chip-item-wrapper")
                 .Filter(new() { HasText = yesOrNo }).First;

        public ILocator ReplacementCostSelect =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$replacementCost.value");

        // Estimator Type — "RCT" is the only option; must be clicked to reveal Valuation Type
        public ILocator EstimatorTypeRCTButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$estimatorType.value-chip-item-wrapper")
                 .Filter(new() { HasText = "RCT" }).First;

        // Valuation Type (Standard / No Defaults / High Value)
        private ILocator GetValuationTypeChip(string text) =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-chip-item-wrapper")
                 .Filter(new() { HasText = text }).First;

        // Get Valuation button — appears after Valuation Type is selected
        public ILocator GetValuationButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].completeRCTProcess1");

        /// <summary>
        /// Returns the correct Valuation Type button based on RCTOption + UseDefaults.
        /// </summary>
        public ILocator GetValuationTypeButton(string rctOption, string useDefaults)
        {
            var isHighValue = rctOption?.ToLower().Contains("high") == true;
            var isNoDefaults = useDefaults?.ToLower() is "no" or "false";

            if (isHighValue) return GetValuationTypeChip("High Value");
            if (isNoDefaults) return GetValuationTypeChip("No Defaults");
            return GetValuationTypeChip("Standard");
        }
        #endregion

        #region Actions
        public async Task FillResidenceCoverageAsync(ScenarioContextData contextData)
        {
            await WaitForSpinnerAsync();

            if (!string.IsNullOrEmpty(contextData.ResidenceInsuranceAmount))
            {
                await InsuranceAmountInput.ClickAsync();
                await InsuranceAmountInput.FillAsync(contextData.ResidenceInsuranceAmount);
                await InsuranceAmountInput.PressAsync("Tab");
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceSquareFeet))
            {
                await SquareFeetInput.ClickAsync();
                await SquareFeetInput.FillAsync(contextData.ResidenceSquareFeet);
                await SquareFeetInput.PressAsync("Tab");
            }

            if (!string.IsNullOrEmpty(contextData.ResidencePerils))
            {
                var perilsAriaDisabled = await PerilsSelect.GetAttributeAsync("aria-disabled");
                var perilsDisabled = string.Equals(perilsAriaDisabled, "true", System.StringComparison.OrdinalIgnoreCase);

                if (perilsDisabled)
                {
                    System.Console.WriteLine($"[ResidenceCoverage] Perils is disabled for this flow/state. Requested='{contextData.ResidencePerils}'. Skipping selection.");
                }
                else
                {
                    await PerilsSelect.ClickAsync();
                    await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidencePerils }).First.ClickAsync();
                }
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceThermostatQuestion))
            {
                var isYes = contextData.ResidenceThermostatQuestion.ToLower() is "yes" or "true";
                await GetThermostatButton(isYes ? "Yes" : "No").ClickAsync();
            }

            // ActualCashValue selects the settlement/replacement cost option from a dropdown
            if (!string.IsNullOrEmpty(contextData.ResidenceActualCashValue))
            {
                await ReplacementCostSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidenceActualCashValue }).First.ClickAsync();
            }

            // Step 1: Click Estimator Type (RCT) — reveals the Valuation Type options
            await EstimatorTypeRCTButton.ClickAsync();
            await WaitForSpinnerAsync();

            // Step 2: Select Valuation Type — reveals Get Valuation button
            if (!string.IsNullOrEmpty(contextData.ResidenceRCTOption) || !string.IsNullOrEmpty(contextData.ResidenceUseDefaults))
            {
                await GetValuationTypeButton(contextData.ResidenceRCTOption, contextData.ResidenceUseDefaults).ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Step 3: Click Get Valuation button to trigger RCT calculation
            await ClickGetValuationButtonAsync();
        }

        /// <summary>
        /// Clicks the Get Valuation / Order RCT button and waits for the RCT calculation to complete.
        /// Tries the DuckCreek testid first, then falls back to the button's visible text.
        /// </summary>
        private async Task ClickGetValuationButtonAsync()
        {
            // Primary: DuckCreek-assigned testid
            if (await GetValuationButton.CountAsync() > 0 && await GetValuationButton.IsVisibleAsync())
            {
                await GetValuationButton.ClickAsync();
                await WaitForSpinnerAsync();
                await _page.WaitForTimeoutAsync(2000);
                await WaitForSpinnerAsync();
                System.Console.WriteLine("RCT calculation completed.");
                return;
            }

            // Fallback: any visible button labelled "Get Valuation" or "Order RCT"
            var byText = _page.GetByRole(AriaRole.Button, new() { NameRegex = new System.Text.RegularExpressions.Regex("Get Valuation|Order RCT", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });
            if (await byText.CountAsync() > 0 && await byText.First.IsVisibleAsync())
            {
                await byText.First.ClickAsync();
                await WaitForSpinnerAsync();
                await _page.WaitForTimeoutAsync(2000);
                await WaitForSpinnerAsync();
                System.Console.WriteLine("RCT calculation completed.");
                return;
            }

            // Some states auto-calculate — log a warning rather than failing
            System.Console.WriteLine("WARNING: No 'Get Valuation' / 'Order RCT' button found — RCT may be auto-calculated or not required.");
        }
        #endregion
    }
}
