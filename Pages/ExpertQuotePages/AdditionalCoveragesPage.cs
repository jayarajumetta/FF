
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
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetAccidentalDeathAndDismembermentButton(value));
        }

        public async Task WaitForCoverageOptionsLoadAsync()
        {
            await _page.WaitForTimeoutAsync(2000);
        }

        public async Task SelectADDDriverAsync(string value)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetADDDriverCheckbox(value));
        }

        public async Task SelectLossOfIncomeAsync(string value)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetLossOfIncomeCheckbox(value));
        }

        public async Task SelectRentedMotorHomesAsync()
        {
            await _page.ClickAsync(Locators.AdditionalCoveragesConstLocators.RentedMotorHomesCheckbox);
        }
        public async Task SelectRentalReimbursementAsync(string value)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetRentalReimbursementButton(value));
        }

        public async Task SelectAddedCoverageEndorsement()
        {
            await _page.ClickAsync(Locators.AdditionalCoveragesConstLocators.AddedCoverageEndorsementCheckbox);
        }
        public async Task SelectRoadsideAssistanceAsync(string value)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.AdditionalCoveragesPageLocators.GetRoadsideAssistanceButton(value));
        }

        public async Task SelectSoundReceivingEquipment()
        {
            await _page.ClickAsync(Locators.AdditionalCoveragesConstLocators.SoundReceivingEquipmentCheckbox);
        }

        public async Task ClickNextAsync()
        {
            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

    }
}
