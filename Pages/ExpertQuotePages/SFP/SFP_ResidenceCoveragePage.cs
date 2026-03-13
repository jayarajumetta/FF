using Microsoft.Playwright;
using Playwright_POC.Helpers;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
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

        public ILocator ThermostatQuestionYesButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-1");

        public ILocator ThermostatQuestionNoButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingInput$buildingThermostatQuestion.value-0");

        public ILocator ReplacementCostSelect =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].coverageInput$replacementCost.value");

        // Note: typo "Valuatioin" is intentional — matches the actual data-testid in the app
        // Estimator Type — must click first; reveals the Valuation Type buttons
        public ILocator EstimatorTypeRCTButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$estimatorType.value-0");

        public ILocator ValuationTypeStandardUseDefaultsButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-0");

        public ILocator ValuationTypeStandardNoDefaultsButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-1");

        public ILocator ValuationTypeHighValueUseDefaultsButton =>
            _page.GetByTestId("fields.risk.rows[0].residenceCoverage.rows[0].buildingValuatioinInput$valuationType.value-2");

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

            if (isHighValue) return ValuationTypeHighValueUseDefaultsButton;
            if (isNoDefaults) return ValuationTypeStandardNoDefaultsButton;
            return ValuationTypeStandardUseDefaultsButton;
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
                await PerilsSelect.ClickAsync();
                await _page.GetByRole(AriaRole.Listbox).Last.GetByRole(AriaRole.Option, new() { Name = contextData.ResidencePerils }).First.ClickAsync();
            }

            if (!string.IsNullOrEmpty(contextData.ResidenceThermostatQuestion))
            {
                var isYes = contextData.ResidenceThermostatQuestion.ToLower() is "yes" or "true";
                await (isYes ? ThermostatQuestionYesButton : ThermostatQuestionNoButton).ClickAsync();
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

            // Step 3: Click Get Valuation button
            if (await GetValuationButton.CountAsync() > 0)
            {
                await GetValuationButton.ClickAsync();
                await WaitForSpinnerAsync();
            }
        }
        #endregion
    }
}
