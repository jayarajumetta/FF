
// Pages/PreQualificationPage.cs
using Microsoft.Playwright;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PreQualificationPage
    {
        private readonly IPage _page;

        public PreQualificationPage(IPage page)
        {
            _page = page;
        }

        public async Task EnterPreQualificationInfoAndContinueAsync(string eligibilityRestrictions)
        {
            await _page.WaitForSelectorAsync(Locators.GlobalLocators.NextButton, new() { State = WaitForSelectorState.Visible });

            await Helpers.Helpers.ClickIfNotSelectedAsync(
                _page,
                ExpertQuoteLocatorFactory.PreQualificationPageLocators.GetQualificationSelection(eligibilityRestrictions)
            );

            await _page.ClickAsync(Locators.GlobalLocators.NextButton);
        }

        public async Task SearchAddClassCodeAsync(ScenarioContextData contextData)
        {
            await _page.WaitForSelectorAsync(Locators.GlobalLocators.NextButton, new() { State = WaitForSelectorState.Visible });
            await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.SearchAddClassCodeButton);
            await _page.WaitForTimeoutAsync(2000);
            if (contextData.ClassCodeNumber == null)
            {
                await _page.FillAsync(Locators.BOPPrequalificationPageLocators.ClassCodeSearchInput, contextData.ClassDescription);
                //await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.ClassCodeSearchButton);
                await _page.WaitForTimeoutAsync(2000);
                await _page.ClickAsync(ExpertQuoteLocatorFactory.PreQualificationPageLocators.CheckboxByDescription(contextData.ClassDescription));
            }
            else
            {
                await _page.FillAsync(Locators.BOPPrequalificationPageLocators.ClassCodeSearchInput, contextData.ClassCodeNumber);
               // await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.ClassCodeSearchButton);
                await _page.WaitForTimeoutAsync(2000);
                await _page.ClickAsync(ExpertQuoteLocatorFactory.PreQualificationPageLocators.CheckboxByClassCode(contextData.ClassCodeNumber));
            }

            await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.AddClassCodeButton);
        }

        public async Task TogglePrimaryOccupancySliderAsync()
        {
            await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.PrimaryOccupancySlider);
        }

        public async Task SelectIndustryClassCodeRestrictionsAsync(ScenarioContextData contextData)
        {
            await _page.WaitForTimeoutAsync(5000);
            await _page.ClickAsync(ExpertQuoteLocatorFactory.PreQualificationPageLocators.SelectClassCodeRestrictionCheckbox(contextData.ClassCodeRestriction));
            await _page.WaitForTimeoutAsync(2000);
        }
    }
}
