// Pages/ExpertQuotePages/SFP_PolicyCoveragesPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// SFP Policy-Wide and Division-Specific Coverages page
    /// </summary>
    public class SFP_PolicyCoveragesPage : BasePage
    {
        public SFP_PolicyCoveragesPage(IPage page) : base(page) { }

        #region Locators - Coverage Catalog Checkboxes
        /// <summary> Checkbox: Agribusiness (Policy-Wide Coverage) </summary>
        public ILocator AgribusinessCheckbox => _page.GetByTestId("fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[0].policyWideCovCatEntryInput$selected.value");
        
        /// <summary> Checkbox: Equine Select (Policy-Wide Coverage) </summary>
        public ILocator EquineSelectCheckbox => _page.GetByTestId("fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[1].policyWideCovCatEntryInput$selected.value");
        
        /// <summary> Checkbox: Excess Debris Removal - Division I </summary>
        public ILocator ExcessDebrisRemovalDivisionICheckbox => _page.GetByTestId("fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[2].policyWideCovCatEntryInput$selected.value");
        
        /// <summary> Checkbox: Excess Debris Removal - Division II </summary>
        public ILocator ExcessDebrisRemovalDivisionIICheckbox => _page.GetByTestId("fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[3].policyWideCovCatEntryInput$selected.value");
        
        /// <summary> Checkbox: Loss to Refrigerated Products - Division II </summary>
        public ILocator LossToRefrigeratedProductsCheckbox => _page.GetByTestId("fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[4].policyWideCovCatEntryInput$selected.value");
        
        /// <summary> Gets a coverage catalog checkbox by row index </summary>
        public ILocator GetCoverageCatalogCheckbox(int rowIndex) => 
            _page.GetByTestId($"fields.data.policy.policyWideCovCat.policyWideCovCatEntry.rows[{rowIndex}].policyWideCovCatEntryInput$selected.value");
        #endregion

        #region Locators - Add/Edit Coverage Buttons (Policy-Wide)
        /// <summary> Button: Add Coverage for Agribusiness </summary>
        public ILocator AddAgribusinessCoverageButton => _page.GetByTestId("fields.data_CoverageSections.policy_PolicyWideSection.line_Agribusiness.addEditAgribusiness");
        
        /// <summary> Button: Add Coverage for Equine Select </summary>
        public ILocator AddEquineSelectCoverageButton => _page.GetByTestId("fields.data_CoverageSections.policy_PolicyWideSection.line_EquineSelect.addEditEquineSelect");
        #endregion

        #region Locators - Add/Edit Coverage Buttons (Division-Specific)
        /// <summary> Button: Add Coverage for Excess Debris Removal - Division I </summary>
        public ILocator AddExcessDebrisRemovalDivisionIButton => _page.GetByTestId("fields.data_CoverageSections.policy_DivisionSpecificSection.line_ExcessDebrisI.addEditExcesDebrisI");
        
        /// <summary> Button: Add Coverage for Excess Debris Removal - Division II </summary>
        public ILocator AddExcessDebrisRemovalDivisionIIButton => _page.GetByTestId("fields.data_CoverageSections.policy_DivisionSpecificSection.line_ExcessDebrisII.addEditExcesDebrisII");
        
        /// <summary> Button: Add Coverage for Loss to Refrigerated Products </summary>
        public ILocator AddLossToRefrigeratedProductsButton => _page.GetByTestId("fields.data_CoverageSections.policy_DivisionSpecificSection.line_LossToRefrig.addEditLossToRefrig");
        #endregion

        #region Locators - Navigation
        /// <summary> Button: Next - Locations, Residences & Buildings </summary>
        public ILocator NextButton => _page.GetByTestId("fields.data_Next.next");
        #endregion

        #region Actions - Coverage Catalog Selection
        /// <summary> Select or deselect Agribusiness coverage </summary>
        public async Task ToggleAgribusinessAsync() => await AgribusinessCheckbox.ClickAsync();
        
        /// <summary> Select or deselect Equine Select coverage </summary>
        public async Task ToggleEquineSelectAsync() => await EquineSelectCheckbox.ClickAsync();
        
        /// <summary> Select or deselect Excess Debris Removal - Division I </summary>
        public async Task ToggleExcessDebrisRemovalDivisionIAsync() => await ExcessDebrisRemovalDivisionICheckbox.ClickAsync();
        
        /// <summary> Select or deselect Excess Debris Removal - Division II </summary>
        public async Task ToggleExcessDebrisRemovalDivisionIIAsync() => await ExcessDebrisRemovalDivisionIICheckbox.ClickAsync();
        
        /// <summary> Select or deselect Loss to Refrigerated Products </summary>
        public async Task ToggleLossToRefrigeratedProductsAsync() => await LossToRefrigeratedProductsCheckbox.ClickAsync();
        
        /// <summary> Toggle a coverage catalog checkbox by row index </summary>
        public async Task ToggleCoverageCatalogAsync(int rowIndex) => 
            await GetCoverageCatalogCheckbox(rowIndex).ClickAsync();
        #endregion

        #region Actions - Add Coverage
        /// <summary> Click Add Coverage for Agribusiness </summary>
        public async Task ClickAddAgribusinessCoverageAsync() => await AddAgribusinessCoverageButton.ClickAsync();
        
        /// <summary> Click Add Coverage for Equine Select </summary>
        public async Task ClickAddEquineSelectCoverageAsync() => await AddEquineSelectCoverageButton.ClickAsync();
        
        /// <summary> Click Add Coverage for Excess Debris Removal - Division I </summary>
        public async Task ClickAddExcessDebrisRemovalDivisionIAsync() => await AddExcessDebrisRemovalDivisionIButton.ClickAsync();
        
        /// <summary> Click Add Coverage for Excess Debris Removal - Division II </summary>
        public async Task ClickAddExcessDebrisRemovalDivisionIIAsync() => await AddExcessDebrisRemovalDivisionIIButton.ClickAsync();
        
        /// <summary> Click Add Coverage for Loss to Refrigerated Products </summary>
        public async Task ClickAddLossToRefrigeratedProductsAsync() => await AddLossToRefrigeratedProductsButton.ClickAsync();
        #endregion

        #region Actions - Navigation
        // ClickNextAsync inherited from BasePage - uses NextButton via test ID discovery
        #endregion

        #region Assertions
        /// <summary> Check if Agribusiness coverage is selected </summary>
        public async Task<bool> IsAgribusinessSelectedAsync() => await AgribusinessCheckbox.IsCheckedAsync();
        
        /// <summary> Check if Equine Select coverage is selected </summary>
        public async Task<bool> IsEquineSelectSelectedAsync() => await EquineSelectCheckbox.IsCheckedAsync();
        #endregion
    }
}
