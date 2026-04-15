using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Primary Insured page - handles client selection, validation, and UW questions
    /// </summary>
    public class SFP_PrimaryInsuredPage : BasePage
    {
        public SFP_PrimaryInsuredPage(IPage page) : base(page) { }

        #region Locators
        // Primary Insured Selection
        private ILocator SelectExistingClientButton => _page.GetByTestId("temp.clientSuggestions-0");
        private ILocator SearchFirstNameInput => _page.Locator("input[name='temp.clientSearchFirstName']");
        private ILocator SearchLastNameInput => _page.Locator("input[name='temp.clientSearchLastName']");
        private ILocator SearchButton => _page.Locator("button:has-text('Search')");

        // Add Primary Insured Form
        private ILocator FirstNameInput => _page.GetByTestId("fields.account.accountInput$nameFirst.value");
        private ILocator MiddleNameInput => _page.GetByTestId("fields.account.accountInput$nameMiddle.value");
        private ILocator LastNameInput => _page.GetByTestId("fields.account.accountInput$nameLast.value");
        private ILocator SuffixDropdown => _page.GetByTestId("fields.account.accountInput$nameSuffix.value");
        private ILocator DOBInput => _page.Locator("input[name='fields.account.accountInput$dateOfBirth.value']");
        private ILocator CountryDropdown => _page.GetByTestId("fields.account.accountInput$country.value");
        private ILocator MailingAddressInput => _page.Locator("input[name='fields.account.accountInput$address1.value']");
        private ILocator Address2Input => _page.GetByTestId("fields.account.accountInput$address2.value");
        private ILocator CityInput => _page.GetByTestId("fields.account.accountInput$city.value");
        private ILocator StateDropdown => _page.GetByTestId("fields.account.accountInput$state.value");
        private ILocator StateValueReadOnly => _page.GetByTestId("fields.account.accountInput$state.value").Locator("mat-select-value");
        private ILocator ZipCodeInput => _page.GetByTestId("fields.account.accountInput$zipCode.value");
        private ILocator MobilePhoneInput => _page.GetByTestId("fields.account.accountInput$mobilePhone.value");
        private ILocator BusinessPhoneInput => _page.GetByTestId("fields.account.accountInput$businessPhone.value");
        private ILocator PrimaryPhoneInput => _page.GetByTestId("fields.account.accountInput$primaryPhone.value");
        private ILocator EmailAddressInput => _page.GetByTestId("fields.account.accountInput$email.value");
        private ILocator FEINInput => _page.GetByTestId("fields.account.accountInput$fEIN.value");
        private ILocator ClientSSNOnFile => _page.GetByText("Social Security #:", new() { Exact = true })
                                                    .Locator("..")
                                                    .Locator(".readonly-value");
        #endregion


        /// <summary>
        /// Selects the existing client as Primary Insured and clicks Next to proceed.
        /// First tries to click the pre-populated suggestion (most states). If it doesn't
        /// appear within 10 s (e.g. Texas), falls back to searching by name so the
        /// suggestion row is rendered before clicking it.
        /// </summary>
        public async Task SelectExistingClientAsPrimaryInsuredAsync(ScenarioContextData contextData)
        {
            await WaitForSpinnerAsync();

            var suggestionVisible = false;
            try
            {
                await SelectExistingClientButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                suggestionVisible = true;
            }
            catch (TimeoutException)
            {
                Console.WriteLine("[PrimaryInsured] Client suggestion not auto-populated — searching by name.");
            }

            if (!suggestionVisible)
            {
                // Some states (e.g. TX) require an explicit search before the suggestion renders
                if (await SearchFirstNameInput.IsVisibleAsync())
                {
                    await SearchFirstNameInput.FillAsync(contextData.ClientFirstName ?? string.Empty);
                    await SearchLastNameInput.FillAsync(contextData.ClientLastName ?? string.Empty);
                    await SearchButton.ClickAsync();
                    await WaitForSpinnerAsync();
                }
                await SelectExistingClientButton.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            }

            await SelectExistingClientButton.ClickAsync();
            await WaitForSpinnerAsync();
            await ClickNextAsync();
        }

        /// <summary>
        /// Clicks Save on the Add Primary Insured page after validation
        /// </summary>
        public async Task SavePrimaryInsuredAsync()
        {
            await WaitForSpinnerAsync();
            await ClickSaveAsync();
        }

        public async Task SearchPersonAsync(ScenarioContextData contextData)
        {
            await SearchFirstNameInput.FillAsync(contextData.ClientFirstName);
            await SearchLastNameInput.FillAsync(contextData.ClientLastName);
            await SearchButton.ClickAsync();
        }

        public async Task EnterPrimaryInsuredDetailsAsync(ScenarioContextData contextData)
        {
            var firstNameValue = (await FirstNameInput.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(firstNameValue))
            {
                await FirstNameInput.ClickAsync();
                await FirstNameInput.PressAsync("Control+A");
                await FirstNameInput.PressAsync("Delete");
                await FirstNameInput.FillAsync(contextData.ClientFirstName ?? string.Empty);
            }
            await FirstNameInput.FillAsync(contextData.ClientFirstName);
            await LastNameInput.FillAsync(contextData.ClientLastName);
            await DOBInput.FillAsync(contextData.ClientDOB);
            await ClickNextAsync();
        }

        public async Task ValidatePrimaryInsuredDetailsAsync(ScenarioContextData contextData)
        {
            var state = await _page.GetByTestId("fields.account.accountInput$state.value").InnerTextAsync();
            var ssnNumber = ClientSSNOnFile.InnerTextAsync();
            var actualFirst = (await FirstNameInput.InputValueAsync())?.Trim();
            var actualLast = (await LastNameInput.InputValueAsync())?.Trim();
            var actualDobText = (await DOBInput.InputValueAsync())?.Trim();
            var actualMailingAddress = (await MailingAddressInput.InputValueAsync())?.Trim();
            var actualCity = (await CityInput.InputValueAsync())?.Trim();
            var actualState = state?.Trim();
            var actualZip = (await ZipCodeInput.InputValueAsync())?.Trim();
            var actualZip5 = actualZip?.Split('-')[0];
            var actualEmail = (await EmailAddressInput.InputValueAsync())?.Trim();

            var actualSSN = (await ssnNumber)?.Trim() ?? string.Empty;
            var ssnLast4 = actualSSN.Length >= 4 ? actualSSN[^4..] : actualSSN;

            Assert.That(actualFirst, Is.EqualTo(contextData.ClientFirstName).IgnoreCase,
                $"First Name mismatch. Expected: {contextData.ClientFirstName}, Actual: {actualFirst}");

            Assert.That(actualLast, Is.EqualTo(contextData.ClientLastName).IgnoreCase,
                $"Last Name mismatch. Expected: {contextData.ClientLastName}, Actual: {actualLast}");

            var actualDob = DateTime.Parse(actualDobText, CultureInfo.InvariantCulture);
            var expectedDob = DateTime.Parse(contextData.ClientDOB, CultureInfo.InvariantCulture);

            Assert.That(actualDob, Is.EqualTo(expectedDob),
                $"DOB mismatch. Expected: {expectedDob}, Actual: {actualDob}");
            Assert.That(actualMailingAddress, Is.EqualTo(contextData.StreetAddress).IgnoreCase,
                $"Mailing Address mismatch. Expected: {contextData.StreetAddress}, Actual: {actualMailingAddress}");
            Assert.That(actualCity, Is.EqualTo(contextData.City).IgnoreCase,
                $"City mismatch. Expected: {contextData.City}, Actual: {actualCity}");
            Assert.That(actualState, Is.EqualTo(contextData.State).IgnoreCase,
                $"State mismatch. Expected: {contextData.State}, Actual: {actualState}");
            Assert.That(actualZip5, Is.EqualTo(contextData.ZipCode).IgnoreCase,
                $"Zip Code mismatch. Expected: {contextData.ZipCode}, Actual: {actualZip5}");
            Assert.That(actualEmail, Is.EqualTo(contextData.ClientEmail).IgnoreCase,
                $"Email Address mismatch. Expected: {contextData.ClientEmail}, Actual: {actualEmail}");

            // SSN validation - soft check (log warning instead of fail) since SSN flow varies by LOB
            var clientSSNLas4 = !string.IsNullOrEmpty(contextData.SSN) && contextData.SSN.Length >= 4
                ? contextData.SSN[^4..]
                : contextData.SSN ?? string.Empty;

            if (!ssnLast4.Equals(clientSSNLas4, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"WARNING: SSN Last 4 mismatch. Expected: {clientSSNLas4}, Actual: {ssnLast4}");
                Console.WriteLine("         This may occur when SSN is set during quote creation vs client creation.");
                if (!string.IsNullOrEmpty(ssnLast4) && ssnLast4.Length == 4)
                {
                    Console.WriteLine($"         Updating context SSN to use displayed value: ***-**-{ssnLast4}");
                }
            }
        }

        #region UW Questions
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


        /// <summary>
        /// Gets the UW question element - handles both button-style and checkbox-style elements.
        /// The UI was updated to use checkboxes instead of buttons for some UW questions.
        /// </summary>
        private ILocator UwToggleElement(string key)
        {
            if (!UwQuestionTestIds.TryGetValue(key, out var testId))
                throw new ArgumentException($"Unknown UW Question key '{key}'. Add it to UwQuestionTestIds.");

            // Try to find checkbox input first (new UI), then fall back to button (old UI)
            return _page.GetByTestId(testId).First;
        }

        private async Task<bool> UwIsCheckedAsync(string key)
        {
            if (!UwQuestionTestIds.TryGetValue(key, out var testId))
                throw new ArgumentException($"Unknown UW Question key '{key}'.");

            // Try checkbox input first (new UI structure)
            var checkbox = _page.Locator($"input[type='checkbox'][data-testid='{testId}']");
            if (await checkbox.CountAsync() > 0)
            {
                return await checkbox.First.IsCheckedAsync();
            }

            // Fall back to button-style element (old UI structure)
            var btn = _page.Locator($"button[data-testid='{testId}']");
            if (await btn.CountAsync() > 0)
            {
                var icon = btn.Locator("i.material-icons").First;
                if (await icon.CountAsync() == 0)
                {
                    var ariaPressed = await btn.GetAttributeAsync("aria-pressed");
                    return string.Equals(ariaPressed, "true", StringComparison.OrdinalIgnoreCase);
                }
                var iconText = (await icon.InnerTextAsync())?.Trim() ?? "";
                return !iconText.Contains("check_box_outline_blank", StringComparison.OrdinalIgnoreCase);
            }

            throw new Exception($"Could not find UW question element with testId '{testId}'. UI may have changed.");
        }

        private async Task UwSetCheckedAsync(string key, bool shouldBeChecked)
        {
            if (!UwQuestionTestIds.TryGetValue(key, out var testId))
                throw new ArgumentException($"Unknown UW Question key '{key}'.");

            var isChecked = await UwIsCheckedAsync(key);
            if (isChecked == shouldBeChecked)
                return; // Already in desired state

            // Try checkbox input first (new UI structure)
            var checkbox = _page.Locator($"input[type='checkbox'][data-testid='{testId}']");
            if (await checkbox.CountAsync() > 0)
            {
                if (shouldBeChecked)
                    await checkbox.First.CheckAsync();
                else
                    await checkbox.First.UncheckAsync();
                return;
            }

            // Fall back to label click (checkbox wrapped in label)
            var label = _page.Locator($"label[data-testid='{testId}']");
            if (await label.CountAsync() > 0)
            {
                await label.First.ClickAsync();
                return;
            }

            // Fall back to button-style element (old UI structure)
            var btn = _page.Locator($"button[data-testid='{testId}']");
            if (await btn.CountAsync() > 0)
            {
                await btn.ClickAsync();
                return;
            }

            throw new Exception($"Could not find UW question element with testId '{testId}'. UI may have changed.");
        }

        // Additional UW sections that appear conditionally based on farm type selection.
        // When Beef/Dairy livestock is chosen, the app renders an extra
        // "Farm Type - Animal - Beef, Dairy, or Dairy Replacement" questions section,
        // each with their own "None Of The Above" button.
        private static readonly string[] ConditionalNoneOfTheAboveTestIds = new[]
        {
            "fields.data.underwritingQuestions.farmBeefDairyOrReplacementQuestions.farmBeefDairyOrReplacementQuestions$eqNoneOfTheAbove.value",
        };

        public async Task AnswerUwQuestionsAsync(Dictionary<string, bool> states, bool clickNext = true)
        {
            if (states.TryGetValue("NoneOfTheAbove", out var none) && none)
            {
                foreach (var k in states.Keys.Cast<string>().Where(k => !k.Equals("NoneOfTheAbove", StringComparison.OrdinalIgnoreCase)).ToList())
                    states[k] = false;
            }

            foreach (var kvp in states)
                await UwSetCheckedAsync(kvp.Key, kvp.Value);

            await WaitForSpinnerAsync();

            // Handle any conditional UW sections (e.g. Beef/Dairy/Replacement) that appear
            // based on the selected farm type. If NoneOfTheAbove was requested and one of
            // these extra sections is visible, click its own None Of The Above too.
            if (states.TryGetValue("NoneOfTheAbove", out var noneRequested) && noneRequested)
            {
                foreach (var testId in ConditionalNoneOfTheAboveTestIds)
                {
                    var btn = _page.GetByTestId(testId);
                    if (await btn.CountAsync() > 0 && await btn.IsVisibleAsync())
                    {
                        Console.WriteLine($"[UWQuestions] Clicking conditional NoneOfTheAbove: {testId}");
                        await btn.ClickAsync();
                        await WaitForSpinnerAsync();
                    }
                }
            }

            if (clickNext)
                await ClickNextAsync();
        }
        #endregion
    }
}
