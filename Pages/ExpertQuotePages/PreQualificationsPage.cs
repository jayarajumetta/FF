// Pages/PreQualificationPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class PreQualificationPage : BasePage
    {
        public PreQualificationPage(IPage page) : base(page) { }

        #region Locators
        private ILocator SearchAddClassCodeButton => _page.Locator("button:has-text('Search/Add Class Code')");
        private ILocator ClassCodeSearchInput => _page.Locator("input[name='temp.filter']");
        private ILocator ClassCodeSearchButton => _page.GetByTestId("temp.filter--search");
        private ILocator AddClassCodeButton => _page.Locator("a:has-text('Add')");
        private ILocator PrimaryOccupancySlider => _page.GetByTestId("occupancyClass$isPrimaryClass");

        // Dynamic locators - use specific test-id for preQualification to avoid matching other "None Of The Above" buttons
        private ILocator GetQualificationSelection(string value)
        {
            // For "None Of The Above", use the specific preQualification test-id to avoid strict mode violations
            // when other sections (like farmBeefDairyOrReplacementQuestions) also have this button
            if (value.Equals("None Of The Above", StringComparison.OrdinalIgnoreCase))
            {
                return _page.GetByTestId("fields.data.underwritingQuestions.preQualification.preQualificationInput$eqNoneOfTheAbove.value");
            }
            return _page.GetByRole(AriaRole.Button, new() { Name = value, Exact = true });
        }

        private ILocator GetCheckboxByClassCode(string classCode) =>
            _page.Locator($"tr:has(td:has-text('{classCode}')) label.mat-checkbox-layout");

        private ILocator GetCheckboxByDescription(string description) =>
            _page.Locator($"tr:has(td:has-text('{description}')) label.mat-checkbox-layout");

        private ILocator GetClassCodeRestrictionCheckbox(string restriction) =>
            _page.Locator($"button span:has-text('{restriction}')");
        #endregion

        public async Task EnterPreQualificationInfoAndContinueAsync(string eligibilityRestrictions)
        {
            await _page.WaitForTimeoutAsync(2000);
            await ClickIfNotSelectedAsync(GetQualificationSelection(eligibilityRestrictions));
            await ClickNextAsync();
        }

        public async Task SearchAddClassCodeAsync(ScenarioContextData contextData)
        {
            await _page.WaitForTimeoutAsync(2000);
            await SearchAddClassCodeButton.ClickAsync();
            await _page.WaitForTimeoutAsync(2000);
            
            if (contextData.ClassCodeNumber == null)
            {
                await ClassCodeSearchInput.FillAsync(contextData.ClassDescription);
                await _page.WaitForTimeoutAsync(2000);
                await GetCheckboxByDescription(contextData.ClassDescription).ClickAsync();
            }
            else
            {
                await ClassCodeSearchInput.FillAsync(contextData.ClassCodeNumber);
                await _page.WaitForTimeoutAsync(2000);
                await GetCheckboxByClassCode(contextData.ClassCodeNumber).ClickAsync();
            }

            await AddClassCodeButton.ClickAsync();
        }

        public async Task TogglePrimaryOccupancySliderAsync()
        {
            await PrimaryOccupancySlider.ClickAsync();
        }

        public async Task SelectIndustryClassCodeRestrictionsAsync(ScenarioContextData contextData)
        {
            await _page.WaitForTimeoutAsync(5000);
            await GetClassCodeRestrictionCheckbox(contextData.ClassCodeRestriction).ClickAsync();
            await _page.WaitForTimeoutAsync(2000);
        }
    }
}
