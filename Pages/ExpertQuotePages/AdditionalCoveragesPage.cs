// Pages/AdditionalCoveragesPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class AdditionalCoveragesPage
    {
        private readonly IPage _page;

        public AdditionalCoveragesPage(IPage page)
        {
            _page = page;
        }


        public async Task SelectAccidentalDeathAndDismembermentAsync(string value)
        {
            await ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetAccidentalDeathAndDismembermentButton(_page, value).ClickAsync();
        }

        public async Task WaitForCoverageOptionsLoadAsync()
        {
            await _page.WaitForTimeoutAsync(2000);
        }

        public async Task SelectADDDriverAsync(string value)
        {
            await ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetADDDriverCheckbox(_page, value).ClickAsync();
        }

        public async Task SelectLossOfIncomeAsync(string value)
        {
            await ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetLossOfIncomeCheckbox(_page, value).ClickAsync();
        }

        public async Task SelectRentedMotorHomesAsync()
        {
            await Locators.AdditionalCoveragesConstLocators.RentedMotorHomesCheckbox(_page).ClickAsync();
        }
        public async Task SelectRentalReimbursementAsync(string value)
        {
            await ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetRentalReimbursementButton(_page, value).ClickAsync();
        }

        public async Task SelectAddedCoverageEndorsement()
        {
            await Locators.AdditionalCoveragesConstLocators.AddedCoverageEndorsementCheckbox(_page).ClickAsync();
        }
        public async Task SelectRoadsideAssistanceAsync(string value)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetRoadsideAssistanceButton(value));
        }

        public async Task SelectSoundReceivingEquipment()
        {
            await Locators.AdditionalCoveragesConstLocators.SoundReceivingEquipmentCheckbox(_page).ClickAsync();
        }

        public async Task ClickNextAsync()
        {
            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

    }
}
