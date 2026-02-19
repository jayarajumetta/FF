// Pages/ExpertQuotePages/SFP/SFP_AddAgribusinessCoveragePage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// SFP Add Coverage: Agribusiness modal/panel
    /// Used when adding or editing Agribusiness coverage from Policy-Wide Coverages
    /// </summary>
    public class SFP_AddAgribusinessCoveragePage : BasePage
    {
        public SFP_AddAgribusinessCoveragePage(IPage page) : base(page) { }

        #region Locators - Navigation
        /// <summary> Side nav: Agribusiness coverage section </summary>
        public ILocator AgribusinessNavItem => _page.GetByTestId("Agribusiness-nav");
        #endregion

        #region Locators - Agribusiness Type Selection
        /// <summary> Agribusiness Choice (Basic) </summary>
        public ILocator AgribusinessChoiceButton => _page.GetByTestId("fields.line.lineCoverages$agribusinessType.value-0");
        
        /// <summary> Agribusiness Select (Mid-tier) </summary>
        public ILocator AgribusinessSelectButton => _page.GetByTestId("fields.line.lineCoverages$agribusinessType.value-1");
        
        /// <summary> Agribusiness Premier (Top-tier) </summary>
        public ILocator AgribusinessPremierButton => _page.GetByTestId("fields.line.lineCoverages$agribusinessType.value-2");
        #endregion

        #region Locators - Affinity Group
        /// <summary> Affinity Group: Ranch Sorting National Championship </summary>
        public ILocator RanchSortingAffinityButton => _page.GetByTestId("fields.line.covAgriBusinessInput$affinityGroup.value-0");
        
        /// <summary> Affinity Group: World Series of Team Roping </summary>
        public ILocator TeamRopingAffinityButton => _page.GetByTestId("fields.line.covAgriBusinessInput$affinityGroup.value-1");
        #endregion

        #region Locators - Coverage Options (Division I)
        /// <summary> Water Damage - Division I dropdown </summary>
        public ILocator WaterDamageDivisionISelect => _page.GetByTestId("fields.line.covAgriBusiness_DivI.covAgriBusinessInput$waterDamageD1.value");
        #endregion

        #region Locators - Coverage Options (Division II)
        /// <summary> Water Damage - Division II dropdown </summary>
        public ILocator WaterDamageDivisionIISelect => _page.GetByTestId("fields.line.covAgriBusiness_DivII.covAgriBusinessInput$waterDamageD2.value");
        #endregion

        #region Locators - Coverage Options (Division III)
        /// <summary> Property Away From Premises dropdown </summary>
        public ILocator PropertyAwayFromPremisesSelect => _page.GetByTestId("fields.line.covAgriBusiness_DivIII.covAgriBusinessInput$propertyAwayFP.value");
        
        /// <summary> Mechanical Rental Reimbursement Per Loss dropdown </summary>
        public ILocator MechanicalRentalReimbursementSelect => _page.GetByTestId("fields.line.covAgriBusiness_DivIII.covAgriBusinessInput$mechRentReimbPerLoss.value");
        #endregion

        #region Locators - Actions
        /// <summary> Cancel button - closes modal without saving </summary>
        public ILocator CancelButton => _page.GetByTestId("fields.line.cancel");
        
        /// <summary> Save button - saves coverage and closes modal </summary>
        public ILocator SaveButton => _page.GetByTestId("fields.line.save");
        #endregion

        #region Actions - Agribusiness Type
        /// <summary> Select Agribusiness Choice coverage type </summary>
        public async Task SelectAgribusinessChoiceAsync() => await AgribusinessChoiceButton.ClickAsync();
        
        /// <summary> Select Agribusiness Select coverage type </summary>
        public async Task SelectAgribusinessSelectAsync() => await AgribusinessSelectButton.ClickAsync();
        
        /// <summary> Select Agribusiness Premier coverage type </summary>
        public async Task SelectAgribusinessPremierAsync() => await AgribusinessPremierButton.ClickAsync();
        
        /// <summary> Select Agribusiness type by name </summary>
        public async Task SelectAgribusinessTypeAsync(string type)
        {
            switch (type.ToLower())
            {
                case "choice":
                    await SelectAgribusinessChoiceAsync();
                    break;
                case "select":
                    await SelectAgribusinessSelectAsync();
                    break;
                case "premier":
                    await SelectAgribusinessPremierAsync();
                    break;
                default:
                    throw new System.ArgumentException($"Unknown Agribusiness type: {type}");
            }
        }
        #endregion

        #region Actions - Affinity Group
        /// <summary> Select Ranch Sorting National Championship affinity group </summary>
        public async Task SelectRanchSortingAffinityAsync() => await RanchSortingAffinityButton.ClickAsync();
        
        /// <summary> Select World Series of Team Roping affinity group </summary>
        public async Task SelectTeamRopingAffinityAsync() => await TeamRopingAffinityButton.ClickAsync();
        #endregion

        #region Actions - Coverage Options
        /// <summary> Select Water Damage option for Division I </summary>
        public async Task SelectWaterDamageDivisionIAsync(string option)
        {
            await WaterDamageDivisionISelect.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = option }).ClickAsync();
        }
        
        /// <summary> Select Water Damage option for Division II </summary>
        public async Task SelectWaterDamageDivisionIIAsync(string option)
        {
            await WaterDamageDivisionIISelect.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = option }).ClickAsync();
        }
        
        /// <summary> Select Property Away From Premises option </summary>
        public async Task SelectPropertyAwayFromPremisesAsync(string option)
        {
            await PropertyAwayFromPremisesSelect.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = option }).ClickAsync();
        }
        
        /// <summary> Select Mechanical Rental Reimbursement option </summary>
        public async Task SelectMechanicalRentalReimbursementAsync(string option)
        {
            await MechanicalRentalReimbursementSelect.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = option }).ClickAsync();
        }
        #endregion

        #region Actions - Modal Controls
        /// <summary> Click Cancel to close modal without saving </summary>
        public async Task ClickCancelAsync() => await CancelButton.ClickAsync();
        
        // ClickSaveAsync inherited from BasePage - uses SaveButton via test ID discovery
        #endregion
    }
}
