using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PolicyDetailsPage
    {
        private readonly IPage _page;

        public PolicyDetailsPage(IPage page)
        {
            _page = page;
        }

        public async Task SelectPrimaryFarmType(string farmType)
        {
            await ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.SelectFarmTypeButton(_page, farmType).ClickAsync();

        }

        public async Task SelectLivestockType(string livestockType)
        {
            await ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.SelectLivestockTypeRadioButton(_page, livestockType).ClickAsync();

        }

        public async Task EnterGrossFarmIncome(string grossFarmIncome)
        {
            await Locators.ProposalDetailsPageLocators.GrossFarmIncomeInput(_page).FillAsync(grossFarmIncome);
        }

        public async Task SelectGrowIndustrialHemp(string growHemp)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.GrowIndustrialHemp(_page, growHemp));
        }

    }
}