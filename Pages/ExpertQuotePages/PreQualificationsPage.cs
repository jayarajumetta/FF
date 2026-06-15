// Pages/PreQualificationPage.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Pages
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
                // The test-id lives on the hidden <input> inside the mat-checkbox.
                // Target the outer mat-checkbox wrapper (which IS visible and has proper Angular click handlers)
                // by using a :has() CSS selector scoped to the preQualification test-id.
                return _page.Locator(
                    "mat-checkbox:has([data-testid='fields.data.underwritingQuestions.preQualification.preQualificationInput$eqNoneOfTheAbove.value'])");
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
            await WaitForSpinnerAsync();

            if (eligibilityRestrictions.Equals("None Of The Above", StringComparison.OrdinalIgnoreCase))
            {
                // DuckCreek renders this as a mat-checkbox whose input is cdk-visually-hidden.
                // Use CheckAsync() on the input directly — same pattern as SFP_UWQuestionsPage.SetCheckedAsync.
                var checkbox = _page.Locator(
                    "input[type='checkbox'][data-testid='fields.data.underwritingQuestions.preQualification.preQualificationInput$eqNoneOfTheAbove.value']");
                await checkbox.First.CheckAsync();
            }
            else
            {
                var selection = GetQualificationSelection(eligibilityRestrictions);
                await selection.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
                await selection.ClickAsync();
            }

            // Some states (e.g. TX) render additional farm-type restriction sections below
            // General Eligibility. Each has its own "None Of The Above" checkbox that must be
            // answered before the page will navigate forward. Check any that are still unchecked.
            var extraNoneCheckboxes = _page.Locator(
                "input[type='checkbox'][data-testid$='eqNoneOfTheAbove.value']:not([data-testid*='preQualification'])");
            var extraCount = await extraNoneCheckboxes.CountAsync();
            for (var i = 0; i < extraCount; i++)
            {
                var cb = extraNoneCheckboxes.Nth(i);
                if (await cb.IsVisibleAsync() && !await cb.IsCheckedAsync())
                {
                    await cb.CheckAsync();
                    Console.WriteLine($"[PreQual] Answered extra restriction section {i + 1} with None Of The Above.");
                }
            }

            await ClickNextAsync();
            await WaitForSpinnerAsync();
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
