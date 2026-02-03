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
            await Locators.GlobalLocators.NextButton(_page).WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            await Helpers.Helpers.ClickIfNotSelectedAsync(
                ExpertQuoteLocatorFactory.PreQualificationPageLocators.GetQualificationSelection(_page, eligibilityRestrictions)
            );

            await Locators.GlobalLocators.NextButton(_page).ClickAsync();
        }

        public async Task SearchAddClassCodeAsync(ScenarioContextData contextData)
        {
            await Locators.GlobalLocators.NextButton(_page).WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.SearchAddClassCodeButton);
            
            // Wait for search input to be ready
            await Assertions.Expect(_page.Locator(Locators.BOPPrequalificationPageLocators.ClassCodeSearchInput)).ToBeVisibleAsync();
            
            if (contextData.ClassCodeNumber == null)
            {
                await _page.FillAsync(Locators.BOPPrequalificationPageLocators.ClassCodeSearchInput, contextData.ClassDescription);
                // Wait for search results (checkbox) to be visible
                var checkboxSelector = ExpertQuoteLocatorFactory.PreQualificationPageLocators.CheckboxByDescription(contextData.ClassDescription);
                await Assertions.Expect(_page.Locator(checkboxSelector)).ToBeVisibleAsync();
                await _page.ClickAsync(checkboxSelector);
            }
            else
            {
                await _page.FillAsync(Locators.BOPPrequalificationPageLocators.ClassCodeSearchInput, contextData.ClassCodeNumber);
                // Wait for search results (checkbox) to be visible
                var checkboxSelector = ExpertQuoteLocatorFactory.PreQualificationPageLocators.CheckboxByClassCode(contextData.ClassCodeNumber);
                await Assertions.Expect(_page.Locator(checkboxSelector)).ToBeVisibleAsync();
                await _page.ClickAsync(checkboxSelector);
            }

            await _page.ClickAsync(Locators.BOPPrequalificationPageLocators.AddClassCodeButton);
        }

        public async Task TogglePrimaryOccupancySliderAsync()
        {
            await Locators.BOPPrequalificationPageLocators.PrimaryOccupancySlider(_page).ClickAsync();
        }

        public async Task SelectIndustryClassCodeRestrictionsAsync(ScenarioContextData contextData)
        {
            // Wait for the restriction checkbox to be visible before clicking
            var restrictionSelector = ExpertQuoteLocatorFactory.PreQualificationPageLocators.SelectClassCodeRestrictionCheckbox(contextData.ClassCodeRestriction);
            await Assertions.Expect(_page.Locator(restrictionSelector)).ToBeVisibleAsync();
            await _page.ClickAsync(restrictionSelector);
        }
    }
}
