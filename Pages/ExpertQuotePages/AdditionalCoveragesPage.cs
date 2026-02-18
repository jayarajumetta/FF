// Pages/AdditionalCoveragesPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class AdditionalCoveragesPage : BasePage
    {
        public AdditionalCoveragesPage(IPage page) : base(page) { }

        #region Locators
        private ILocator RentedMotorHomesCheckbox => _page.GetByTestId("RentedMotorHomeTravelTrailer");
        private ILocator AddedCoverageEndorsementCheckbox => _page.GetByTestId("addedCoverageEndorsement");
        private ILocator SoundReceivingEquipmentCheckbox => _page.GetByTestId("SoundRec");

        // Dynamic locators
        private ILocator GetAccidentalDeathAndDismembermentButton(string value) =>
            _page.Locator("[id*='AccidentalDeath']").GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetLossOfIncomeCheckbox(string value) =>
            _page.Locator("[id*='driverIncomeLoss']").GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetRentalReimbursementButton(string value) =>
            _page.Locator("[id*='RentalReimbursement']").GetByRole(AriaRole.Button, new() { Name = value });

        private ILocator GetRoadsideAssistanceButton(string value) =>
            _page.Locator($"button[id*='RoadsideAssistance'] div:has-text('{value}')");

        private ILocator GetADDDriverCheckbox(string value) =>
            _page.Locator("[id*='aDDOperator']").GetByRole(AriaRole.Button);
        #endregion

        public async Task SelectAccidentalDeathAndDismembermentAsync(string value)
        {
            await GetAccidentalDeathAndDismembermentButton(value).ClickAsync();
        }

        public async Task WaitForCoverageOptionsLoadAsync()
        {
            await WaitForSpinnerAsync();
        }

        public async Task SelectADDDriverAsync(string value)
        {
            await GetADDDriverCheckbox(value).ClickAsync();
        }

        public async Task SelectLossOfIncomeAsync(string value)
        {
            await GetLossOfIncomeCheckbox(value).ClickAsync();
        }

        public async Task SelectRentedMotorHomesAsync()
        {
            await RentedMotorHomesCheckbox.ClickAsync();
        }

        public async Task SelectRentalReimbursementAsync(string value)
        {
            await GetRentalReimbursementButton(value).ClickAsync();
        }

        public async Task SelectAddedCoverageEndorsement()
        {
            await AddedCoverageEndorsementCheckbox.ClickAsync();
        }

        public async Task SelectRoadsideAssistanceAsync(string value)
        {
            await GetRoadsideAssistanceButton(value).ClickAsync();
        }

        public async Task SelectSoundReceivingEquipment()
        {
            await SoundReceivingEquipmentCheckbox.ClickAsync();
        }
    }
}
