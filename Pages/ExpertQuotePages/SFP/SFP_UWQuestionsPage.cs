using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP-specific UW Questions page - handles General UW Questions checkboxes
    /// </summary>
    public class SFP_UWQuestionsPage : BasePage
    {
        public SFP_UWQuestionsPage(IPage page) : base(page) { }

        #region UW Question Test IDs
        private static readonly Dictionary<string, string> UwQuestionTestIds = new(StringComparer.OrdinalIgnoreCase)
        {
            ["ConvictionFelony"] = "fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$convictedOfAnyOtherTypeOfCrime.value",
            ["PolicyDeclined5Years"] = "fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$insurancePolicyDeclinedCancelledNonRenewed.value",
            ["AlcoholOnPremises"] = "fields.underwritingQuestionsGeneralUWQuestions.preQualificationInput$anyAlcoholOnPremise.value",
            ["PublicAttractions"] = "fields.underwritingQuestionsGeneralUWQuestions.preQualificationInput$anyHighExposureActivities.value",
            ["OtherOpsOnPremises"] = "fields.underwritingQuestionsGeneralUWQuestions.sFPGeneralQuestionsInput$anyOperationsNotListed.value",
            ["SolidFuelDevices"] = "fields.underwritingQuestionsGeneralUWQuestions.sFPGeneralQuestionsInput$anySolidFuelHeating.value",
            ["NoneOfTheAbove"] = "fields.underwritingQuestionsGeneralUWQuestions.generalInformationNewInput$noneOfTheAboveGeneralUWQuestions.value",
        };
        #endregion

        private ILocator UwToggleButton(string key)
        {
            if (!UwQuestionTestIds.TryGetValue(key, out var testId))
                throw new ArgumentException($"Unknown UW Question key '{key}'. Valid keys: {string.Join(", ", UwQuestionTestIds.Keys)}");

            return _page.Locator($"button[data-testid='{testId}']");
        }

        private async Task<bool> IsCheckedAsync(string key)
        {
            var btn = UwToggleButton(key);
            var icon = btn.Locator("i.material-icons").First;

            if (await icon.CountAsync() == 0)
            {
                var ariaPressed = await btn.GetAttributeAsync("aria-pressed");
                return string.Equals(ariaPressed, "true", StringComparison.OrdinalIgnoreCase);
            }

            var iconText = (await icon.InnerTextAsync())?.Trim() ?? "";
            return !iconText.Contains("check_box_outline_blank", StringComparison.OrdinalIgnoreCase);
        }

        private async Task SetCheckedAsync(string key, bool shouldBeChecked)
        {
            var btn = UwToggleButton(key);
            var isChecked = await IsCheckedAsync(key);

            if (isChecked != shouldBeChecked)
                await btn.ClickAsync();
        }

        /// <summary>
        /// Answer UW questions based on Yes/No mapping from feature table
        /// </summary>
        public async Task AnswerQuestionsAsync(Dictionary<string, bool> states, bool clickNext = true)
        {
            // If NoneOfTheAbove is selected, ensure all other questions are unchecked
            if (states.TryGetValue("NoneOfTheAbove", out var none) && none)
            {
                foreach (var k in states.Keys.Where(k => !k.Equals("NoneOfTheAbove", StringComparison.OrdinalIgnoreCase)).ToList())
                    states[k] = false;
            }

            foreach (var kvp in states)
                await SetCheckedAsync(kvp.Key, kvp.Value);

            await WaitForSpinnerAsync();

            if (clickNext)
                await ClickNextAsync();
        }
    }
}
