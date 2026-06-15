// Pages/ExpertQuotePages/SFP/SFP_AddEquineSelectCoveragePage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PnCTestAutomation.Pages
{
    /// <summary>
    /// SFP Add Coverage: Equine Select modal/panel
    /// Used when adding or editing Equine Select coverage from Policy-Wide Coverages
    /// </summary>
    public class SFP_AddEquineSelectCoveragePage : BasePage
    {
        public SFP_AddEquineSelectCoveragePage(IPage page) : base(page) { }

        #region Locators - Navigation
        /// <summary> Side nav: Equine Select coverage section </summary>
        public ILocator EquineSelectNavItem => _page.GetByTestId("EquineSelect-nav");
        #endregion

        #region Locators - Affinity Group
        /// <summary> Affinity Group: Ranch Sorting National Championship </summary>
        public ILocator RanchSortingAffinityButton => _page.GetByTestId("fields.line.covEquineSelectInput$affinityGroup.value-0");

        /// <summary> Affinity Group: World Series of Team Roping </summary>
        public ILocator TeamRopingAffinityButton => _page.GetByTestId("fields.line.covEquineSelectInput$affinityGroup.value-1");
        #endregion

        #region Locators - Actions
        /// <summary> Cancel button - closes modal without saving </summary>
        public ILocator CancelButton => _page.GetByTestId("fields.line.cancel");

        /// <summary> Save button - saves coverage and closes modal </summary>
        public ILocator SaveButton => _page.GetByTestId("fields.line.save");
        #endregion

        #region Actions - Affinity Group
        /// <summary> Select Ranch Sorting National Championship affinity group </summary>
        public async Task SelectRanchSortingAffinityAsync() => await RanchSortingAffinityButton.ClickAsync();

        /// <summary> Select World Series of Team Roping affinity group </summary>
        public async Task SelectTeamRopingAffinityAsync() => await TeamRopingAffinityButton.ClickAsync();

        /// <summary> Select an affinity group by name </summary>
        public async Task SelectAffinityGroupAsync(string affinityGroup)
        {
            switch (affinityGroup.ToUpper())
            {
                case "RANCH SORTING NATIONAL CHAMPIONSHIP":
                case "RANCH SORTING":
                    await SelectRanchSortingAffinityAsync();
                    break;
                case "WORLD SERIES OF TEAM ROPING":
                case "TEAM ROPING":
                    await SelectTeamRopingAffinityAsync();
                    break;
                default:
                    throw new System.ArgumentException($"Unknown affinity group: {affinityGroup}");
            }
        }
        #endregion

        #region Actions - Modal Controls
        /// <summary> Click Cancel to close modal without saving </summary>
        public async Task ClickCancelAsync() => await CancelButton.ClickAsync();

        // ClickSaveAsync inherited from BasePage - uses SaveButton via test ID discovery
        #endregion
    }
}
