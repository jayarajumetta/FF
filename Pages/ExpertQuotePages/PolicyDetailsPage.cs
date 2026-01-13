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
            await _page.ClickAsync(ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.SelectFarmTypeButton(farmType));

        }

        public async Task SelectLivestockType(string livestockType)
        {
            await _page.ClickAsync(ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.SelectLivestockTypeRadioButton(livestockType));

        }

        public async Task EnterGrossFarmIncome(string grossFarmIncome)
        {
            await _page.FillAsync(Locators.ProposalDetailsPageLocators.GrossFarmIncomeInput, grossFarmIncome);
        }

        public async Task SelectGrowIndustrialHemp(string growHemp)
        {
            await Helpers.Helpers.ClickIfNotSelectedAsync(_page, ExpertQuoteLocatorFactory.SFPPolicyDetailsPageLocators.GrowIndustrialHemp(growHemp));
        }

    }
}