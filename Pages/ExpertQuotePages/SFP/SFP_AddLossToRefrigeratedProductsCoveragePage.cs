// Pages/ExpertQuotePages/SFP/SFP_AddLossToRefrigeratedProductsCoveragePage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// SFP Add Coverage: Loss to Refrigerated Products modal/panel
    /// Used when adding or editing Loss to Refrigerated Products coverage (Division II)
    /// </summary>
    public class SFP_AddLossToRefrigeratedProductsCoveragePage : BasePage
    {
        public SFP_AddLossToRefrigeratedProductsCoveragePage(IPage page) : base(page) { }

        #region Locators - Navigation
        /// <summary> Side nav: Loss to Refrigerated Products coverage section </summary>
        public ILocator LossToRefrigeratedProductsNavItem => _page.GetByTestId("LossToRefrigeratedProducts-nav");
        
        /// <summary> Side nav: Equipment Breakdown and Farm Implements section </summary>
        public ILocator EquipmentBreakdownNavItem => _page.GetByTestId("EquipmentBreakdownFarmImplements-nav");
        #endregion

        #region Locators - Coverage Fields
        /// <summary> Input: Coverage Limit amount (currency, required) </summary>
        public ILocator LimitInput => _page.GetByTestId("fields.line.covLossToRefrigeratedProducts.covLossToRefrigeratedProductsInput$limit.value");
        
        /// <summary> Dropdown: Deductible amount selection </summary>
        public ILocator DeductibleSelect => _page.GetByTestId("fields.line.covLossToRefrigeratedProducts.covLossToRefrigeratedProductsInput$deductible.value");
        #endregion

        #region Locators - Actions
        /// <summary> Cancel button - closes modal without saving </summary>
        public ILocator CancelButton => _page.GetByTestId("fields.line.cancel");
        
        /// <summary> Save button - saves coverage and closes modal </summary>
        public ILocator SaveButton => _page.GetByTestId("fields.line.save");
        #endregion

        #region Actions - Coverage Fields
        /// <summary> Enter coverage limit amount </summary>
        public async Task EnterLimitAsync(string amount)
        {
            await LimitInput.ClearAsync();
            await LimitInput.FillAsync(amount);
        }
        
        /// <summary> Select deductible from dropdown </summary>
        public async Task SelectDeductibleAsync(string deductible)
        {
            await DeductibleSelect.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = deductible }).ClickAsync();
        }
        #endregion

        #region Actions - Modal Controls
        /// <summary> Click Cancel to close modal without saving </summary>
        public async Task ClickCancelAsync() => await CancelButton.ClickAsync();
        
        // ClickSaveAsync inherited from BasePage - uses SaveButton via test ID discovery
        #endregion

        #region Actions - Complete Coverage Entry
        /// <summary> Fill coverage and save </summary>
        public async Task AddCoverageAsync(string limit, string deductible)
        {
            await EnterLimitAsync(limit);
            await SelectDeductibleAsync(deductible);
            await ClickSaveAsync();
        }
        #endregion
    }
}
