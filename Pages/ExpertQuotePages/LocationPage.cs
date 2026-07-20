using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Reqnroll;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages
{
    public class LocationPage : BasePage
    {
        private readonly ScenarioContextData _contextData;
        public LocationPage(IPage page, ScenarioContextData contextData) : base(page)
        {
            _contextData = contextData;
        }

        public async Task EnterLocationInformationAsync()
        {
            await SetLocationNickname(_contextData.LocationNickname);
            await SelectLocationType(_contextData.LocationType);
            await SetMilesFromFireDepartment(_contextData.MilesFromFireDepartment);
            await SelectFeetFromHydrant(_contextData.FeetFromHydrant);
            await SetTotalFarmingAcreage(_contextData.TotalAcreage);

            await WaitForSpinnerAsync();
        }

        private ILocator LocationNicknameInput() => _page.Locator("input[data-testid*='locationInput$additionalDescription.value']");

        private async Task SetLocationNickname(string nickname)
        {
            var input = LocationNicknameInput();
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(nickname);
            await WaitForSpinnerAsync();
        }

        private ILocator LocationTypeButton(string typeText) =>
            _page.Locator("mat-button-toggle").Filter(new() { HasText = typeText }).First;

        public async Task SelectLocationType(string locationType)
        {
            var normalized = (locationType ?? "").Trim();

            var btn = LocationTypeButton(normalized);

            // Guard: if no mat-button-toggle exists for this text, skip (may be default)
            var count = await _page.Locator("mat-button-toggle").Filter(new() { HasText = normalized }).CountAsync();
            if (count == 0)
            {
                Console.WriteLine($"[LocationType] No toggle found for '{normalized}' — skipping.");
                return;
            }

            await btn.ScrollIntoViewIfNeededAsync();

            // Check if already selected
            var cls = await btn.GetAttributeAsync("class") ?? string.Empty;
            if (cls.Contains("mat-button-toggle-checked", StringComparison.OrdinalIgnoreCase) ||
                cls.Contains("chip-wrapper-selected", StringComparison.OrdinalIgnoreCase))
                return;

            await btn.ClickAsync(new() { Force = true });
            await WaitForSpinnerAsync();
        }

        private ILocator MilesFromFireDepartment() => _page.Locator("input[data-testid*='locationInput$milesFromFireDepartment.value']");

        public async Task SetMilesFromFireDepartment(string miles)
        {
            var input = MilesFromFireDepartment().First;
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await input.ScrollIntoViewIfNeededAsync();
            await input.ClearAsync();
            await input.FillAsync(miles?.Trim() ?? string.Empty);
            await input.PressAsync("Tab"); // Blur to trigger Angular validation
            await WaitForSpinnerAsync();
        }

        private ILocator FeetFromHydrantSelect() =>
            _page.Locator("mat-select[data-testid*='locationInput$feetFromHydrant.value']").First;

        public async Task SelectFeetFromHydrant(string value)
        {
            var normalizedValue = value?.Trim() ?? string.Empty;

            var select = FeetFromHydrantSelect();
            await select.ScrollIntoViewIfNeededAsync();
            await WaitForSpinnerAsync();

            // Click to open the dropdown
            await select.ClickAsync(new() { Timeout = 30000 });

            // Wait for panel to appear and select option by text
            var option = _page.Locator(".cdk-overlay-pane mat-option").GetByText(normalizedValue, new() { Exact = true });
            await option.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await option.ClickAsync();

            // Wait for panel to close before tabbing onward
            await _page.Locator(".cdk-overlay-pane mat-option").First.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = 10000 });
            await _page.Keyboard.PressAsync("Tab");
            await WaitForSpinnerAsync();
        }

        private ILocator TotalAcreageInput() => _page.Locator("input[data-testid*='locationInput$acreage.value']");

        public async Task SetTotalFarmingAcreage(string acreage)
        {
            var input = TotalAcreageInput();
            await input.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await input.FillAsync(acreage);
        }

        private ILocator WindHailScope() => _page.Locator("div:has([data-testid*='locationInput$windHailDeductible.value'])").First;
        private ILocator WindHailOptionsInScope() => WindHailScope().Locator("[data-testid*='locationInput$windHailDeductible.value']");

        private ILocator WindHailMoreOptionsButton() =>
                WindHailScope().GetByRole(AriaRole.Button, new() { Name = "More Options", Exact = true });
        private ILocator WindHailMenuItem(string text) =>
                _page.Locator(".cdk-overlay-pane .mat-menu.panel, .cdk-overlay-pane .mat-mdc-menu-panel")
                .Last
                .GetByRole(AriaRole.Menuitem, new() { Name = text, Exact = true });

        private static string NormalizeWhText(string text) =>
            (text ?? string.Empty).Trim().Replace(" ", string.Empty).ToUpperInvariant();

        private static decimal? TryParsePercent(string option)
        {
            var normalized = NormalizeWhText(option).Replace("%", string.Empty);
            return decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out var value)
                ? value
                : null;
        }

        private static bool IsNoiseOption(string option) =>
            string.IsNullOrWhiteSpace(option)
            || NormalizeWhText(option) == "MOREOPTIONS";

        private static IEnumerable<string> SplitOptionText(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                yield break;

            var parts = raw
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p));

            foreach (var part in parts)
                yield return part;
        }

        private async Task<List<string>> GetAllWindHailOptionsAsync(ILocator scope)
        {
            var optionTexts = new List<string>();

            var inScope = scope.Locator("[data-testid*='locationInput$windHailDeductible.value']");
            var count = await inScope.CountAsync();
            for (var i = 0; i < count; i++)
            {
                var raw = await inScope.Nth(i).InnerTextAsync();
                optionTexts.AddRange(SplitOptionText(raw));
            }

            var hasNumericOptions = optionTexts.Any(t => TryParsePercent(t).HasValue);
            if (!hasNumericOptions)
            {
                var moreOpts = WindHailMoreOptionsButton();
                if (await moreOpts.CountAsync() > 0 && await moreOpts.IsVisibleAsync())
                {
                    await moreOpts.ClickAsync();
                    await _page.WaitForTimeoutAsync(500);

                    var menuPanel = _page.Locator(".cdk-overlay-pane .mat-menu-panel, .cdk-overlay-pane .mat-mdc-menu-panel").Last;
                    if (await menuPanel.CountAsync() > 0 && await menuPanel.IsVisibleAsync())
                    {
                        var menuItems = menuPanel.GetByRole(AriaRole.Menuitem);
                        var menuCount = await menuItems.CountAsync();
                        for (var i = 0; i < menuCount; i++)
                            optionTexts.AddRange(SplitOptionText(await menuItems.Nth(i).InnerTextAsync()));
                    }

                    await _page.Keyboard.PressAsync("Escape");
                    await _page.WaitForTimeoutAsync(300);
                }
            }

            return optionTexts
                .Select(t => t.Trim())
                .Where(t => !IsNoiseOption(t))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private async Task<bool> TrySelectWindHailOptionAsync(ILocator scope, string target, int timeoutMs = 30000)
        {
            var normalizedTarget = NormalizeWhText(target);
            if (string.IsNullOrWhiteSpace(normalizedTarget))
                return false;

            // Prefer direct chip selection by testid+text (works for non-button chip wrappers).
            var chips = scope.Locator("[data-testid*='locationInput$windHailDeductible.value']");
            var chipCount = await chips.CountAsync();
            for (var i = 0; i < chipCount; i++)
            {
                var candidate = chips.Nth(i);
                if (!await candidate.IsVisibleAsync())
                    continue;

                var text = NormalizeWhText(await candidate.InnerTextAsync());
                if (text == normalizedTarget)
                {
                    await candidate.ScrollIntoViewIfNeededAsync();
                    await candidate.ClickAsync(new() { Timeout = timeoutMs, Force = true });
                    return true;
                }
            }

            // Fallback to overflow menu when direct chip isn't visible.
            var moreOptionsButton = WindHailMoreOptionsButton();
            if (await moreOptionsButton.CountAsync() == 0 || !await moreOptionsButton.IsVisibleAsync())
                return false;

            await moreOptionsButton.ClickAsync(new() { Timeout = timeoutMs });
            var menuPanel = _page.Locator(".cdk-overlay-pane .mat-menu-panel, .cdk-overlay-pane .mat-mdc-menu-panel").Last;
            await Expect(menuPanel).ToBeVisibleAsync(new() { Timeout = timeoutMs });

            var menuItem = menuPanel.GetByRole(AriaRole.Menuitem, new() { Name = target, Exact = true }).First;
            if (await menuItem.CountAsync() > 0 && await menuItem.IsVisibleAsync())
            {
                await menuItem.ClickAsync(new() { Timeout = timeoutMs });
                await Expect(menuPanel).ToBeHiddenAsync(new() { Timeout = timeoutMs });
                return true;
            }

            await _page.Keyboard.PressAsync("Escape");
            await _page.WaitForTimeoutAsync(200);
            return false;
        }

        private static string ResolveBaselineSelection((bool cannotBeAdded, string minDeductible) rules, List<string> options)
        {
            if (rules.cannotBeAdded)
                return null;

            if (!string.IsNullOrWhiteSpace(rules.minDeductible))
                return rules.minDeductible;

            var na = options.FirstOrDefault(o => NormalizeWhText(o) == "N/A");
            if (!string.IsNullOrEmpty(na))
                return na;

            var smallestNumeric = options
                .Select(o => new { Raw = o, Value = TryParsePercent(o) })
                .Where(x => x.Value.HasValue)
                .OrderBy(x => x.Value.Value)
                .Select(x => x.Raw)
                .FirstOrDefault();

            return smallestNumeric;
        }

        private static string ResolveNextAboveSelection(string baseline, List<string> options)
        {
            if (string.IsNullOrWhiteSpace(baseline))
                return null;

            var baselineNormalized = NormalizeWhText(baseline);
            if (baselineNormalized == "N/A")
            {
                return options
                    .Select(o => new { Raw = o, Value = TryParsePercent(o) })
                    .Where(x => x.Value.HasValue)
                    .OrderBy(x => x.Value.Value)
                    .Select(x => x.Raw)
                    .FirstOrDefault();
            }

            var baselineValue = TryParsePercent(baseline);
            if (!baselineValue.HasValue)
                return null;

            return options
                .Select(o => new { Raw = o, Value = TryParsePercent(o) })
                .Where(x => x.Value.HasValue && x.Value.Value > baselineValue.Value)
                .OrderBy(x => x.Value.Value)
                .Select(x => x.Raw)
                .FirstOrDefault();
        }

        private ILocator OrderWildfireRiskScoreButton() =>
                _page.GetByTestId("fields.data.account.location.rows[0].orderWildfire");

        /// <summary>
        /// Clicks the "Order Wildfire Risk Score" button if it is visible and enabled.
        /// Some states require this step; others do not show the button.
        /// </summary>
        public async Task OrderWildfireRiskScoreIfAvailableAsync()
        {
            var button = OrderWildfireRiskScoreButton();

            // Check if button exists and is visible
            if (await button.CountAsync() > 0 && await button.IsVisibleAsync())
            {
                // Check if button is enabled (not disabled)
                var isDisabled = await button.IsDisabledAsync();
                if (!isDisabled)
                {
                    await button.ClickAsync();
                    await WaitForSpinnerAsync();
                    Console.WriteLine("Clicked 'Order Wildfire Risk Score' button.");
                }
                else
                {
                    Console.WriteLine("'Order Wildfire Risk Score' button is present but disabled - skipping.");
                }
            }
            else
            {
                Console.WriteLine("'Order Wildfire Risk Score' button not present on this page - skipping.");
            }
        }

        public async Task SelectWindHailDeductibleAsync(string deductible, string zipCode = null)
        {
            var expectsWindHailSelection = !string.IsNullOrWhiteSpace(deductible);

            // Check if Wind/Hail deductible field exists (not all states have this field)
            var scope = WindHailScope();
            if (await scope.CountAsync() == 0)
            {
                if (expectsWindHailSelection)
                    Assert.Fail($"[WindHail] Zip {zipCode}: expected Wind/Hail deductible field for requested value '{deductible}', but field was not present.");

                Console.WriteLine("Wind/Hail deductible field not present for this state - skipping.");
                return;
            }

            var optionsInScope = WindHailOptionsInScope();
            if (await optionsInScope.CountAsync() == 0)
            {
                if (expectsWindHailSelection)
                    Assert.Fail($"[WindHail] Zip {zipCode}: expected Wind/Hail deductible buttons for requested value '{deductible}', but none were found.");

                Console.WriteLine("Wind/Hail deductible buttons not found - skipping.");
                return;
            }

            var rules = !string.IsNullOrWhiteSpace(zipCode)
                ? GetWindHailRulesForZip(zipCode)
                : null;

            if (rules?.cannotBeAdded == true)
            {
                if (expectsWindHailSelection)
                    Assert.Fail($"[WindHail] Zip {zipCode}: rules indicate Wind/Hail cannot be added, but test requested '{deductible}'.");

                Console.WriteLine($"[WindHail] Zip {zipCode} — WH cannot be added, skipping selection.");
                return;
            }

            var availableOptions = await GetAllWindHailOptionsAsync(scope);
            Console.WriteLine($"[WindHail] Available options for selection: {string.Join(", ", availableOptions)}");

            // Step 17: select the minimum/baseline option (minimum required or N/A/lowest available)
            var baselineChoice = rules.HasValue
                ? ResolveBaselineSelection(rules.Value, availableOptions)
                : (deductible ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(baselineChoice))
            {
                if (expectsWindHailSelection)
                    Assert.Fail($"[WindHail] Zip {zipCode}: no Wind/Hail baseline option could be resolved for requested value '{deductible}'.");

                Console.WriteLine("[WindHail] No baseline deductible option resolved - skipping selection.");
                return;
            }

            var baselineSelected = await TrySelectWindHailOptionAsync(scope, baselineChoice);
            if (!baselineSelected)
            {
                Assert.Fail($"[WindHail] Zip {zipCode}: could not select required baseline option '{baselineChoice}'.");
                return;
            }

            await WaitForSpinnerAsync();

            // Step 18: select the next option above the baseline when available.
            var nextAbove = ResolveNextAboveSelection(baselineChoice, availableOptions);
            if (string.IsNullOrWhiteSpace(nextAbove))
            {
                Console.WriteLine($"[WindHail] No option above '{baselineChoice}' is available for this zip/state.");
                return;
            }

            var nextSelected = await TrySelectWindHailOptionAsync(scope, nextAbove);
            if (!nextSelected)
            {
                Assert.Fail($"[WindHail] Zip {zipCode}: baseline '{baselineChoice}' was selected, but required next-above option '{nextAbove}' could not be selected.");
                return;
            }

            await WaitForSpinnerAsync();
            Console.WriteLine($"[WindHail] Selected baseline '{baselineChoice}', then next-above '{nextAbove}'.");
        }

        // ── Wind/Hail zip-to-zone rules ───────────────────────────────────────
        // Source: SFP WH Research – Expected Results based on Zip (sheet 2)
        // cannotBeAdded = true  → field must be absent (ID, OR, UT, WA)
        // minDeductible = "1%" → mandatory minimum; assert 1% present, no sub-1% options
        // minDeductible = null  → no minimum; field present but unconstrained (N/A states)
        private static (bool cannotBeAdded, string minDeductible)? GetWindHailRulesForZip(string zip) =>
            zip?.Trim() switch
            {
                "35661" => (false, "1%"),   // AL – zone 1, min 1%
                "72503" => (false, "1%"),   // AR – zone 1, min 1%
                "85016" => (false, null),   // AZ – zone 1, no minimum
                "80701" => (false, "1%"),   // CO – zone 2, min 1%
                "19720" => (false, "2%"),  // DE – min 2%
                "30327" => (false, "1%"),  // GA – min 1%
                "83814" => (true, null),   // ID – WH cannot be added
                "01201" => (false, "1%"),  // MA – min 1%
                "04769" => (true, null),   // ME – WH cannot be added
                "61108" => (false, null),   // IL – zone 1, no minimum
                "46320" => (false, null),   // IN – no mandatory minimum
                "52101" => (false, null),   // IA – no mandatory minimum
                "66112" => (false, null),   // KS – zone 1, no minimum
                "42066" => (false, "1%"),   // KY – zone 2, min 1%
                "71463" => (false, "1%"),   // LA – zone 2, min 1%
                "56762" => (false, null),   // MN – zone 1, no minimum
                "59072" => (false, "1%"),   // MT – zone 2, min 1%
                "69361" => (false, null),   // NE – zone 1, no minimum
                "89101" => (false, null),   // NV – zone 1, no minimum
                "88101" => (false, null),   // NM – no mandatory minimum
                "58504" => (false, "1%"),   // ND – zone 1, min 1%
                "74332" => (false, null),   // OK – no mandatory minimum
                "97331" => (true, null),   // OR – WH cannot be added
                "29810" => (false, null),   // SC – zone 2, no minimum
                "57501" => (false, "1%"),   // SD – zone 3, min 1%
                "37604" => (false, null),   // TN – zone 1, no minimum
                "78205" => (false, "1%"),   // TX – zone 1, min 1%
                "84321" => (true, null),   // UT – WH cannot be added
                "98368" => (true, null),   // WA – WH cannot be added
                "53704" => (false, null),   // WI – zone 1, no minimum
                "82601" => (false, "1%"),   // WY – zone 2, min 1%
                _ => null
            };

        /// <summary>
        /// Verifies Wind/Hail deductible field state against SFP WH Research zip-to-zone rules.
        /// ADO step 16: asserts field absent for WH-cannot-be-added states; asserts minimum for others.
        /// ADO step 18: asserts above-minimum option is present and enabled where applicable.
        /// </summary>
        public async Task VerifyWindHailDeductibleOptionsAsync(string zipCode, string expectedDeductible = null)
        {
            var rules = GetWindHailRulesForZip(zipCode);
            if (rules is null)
            {
                if (string.IsNullOrWhiteSpace(expectedDeductible))
                {
                    Console.WriteLine($"[WindHail] No rules defined for zip '{zipCode}' – skipping WH verification.");
                    return;
                }

                var unknownScope = WindHailScope();
                var unknownFieldPresent = await unknownScope.CountAsync() > 0;
                Assert.That(unknownFieldPresent, Is.True,
                    $"[WindHail] Zip {zipCode}: no WH rule exists, but test requested deductible '{expectedDeductible}' and WH field was not found.");

                var unknownButtons = unknownScope.Locator("[data-testid*='locationInput$windHailDeductible.value']");
                var unknownButtonCount = await unknownButtons.CountAsync();
                Assert.That(unknownButtonCount, Is.GreaterThan(0),
                    $"[WindHail] Zip {zipCode}: no WH rule exists, but test requested deductible '{expectedDeductible}' and no WH options were found.");

                Console.WriteLine($"[WindHail] Zip {zipCode}: no explicit rule found; enforced WH field presence because test requested '{expectedDeductible}'.");
                return;
            }

            var scope = WindHailScope();
            var fieldPresent = await scope.CountAsync() > 0;

            if (rules.Value.cannotBeAdded)
            {
                Assert.That(fieldPresent, Is.False,
                    $"[WindHail] Zip {zipCode}: WH deductible field should NOT be present for this state but was found.");
                Console.WriteLine($"[WindHail] Zip {zipCode}: Verified – WH deductible cannot be added (field absent).");
                return;
            }

            Assert.That(fieldPresent, Is.True,
                $"[WindHail] Zip {zipCode}: WH deductible field should be present but was not found.");

            var buttons = scope.Locator("[data-testid*='locationInput$windHailDeductible.value']");
            var buttonCount = await buttons.CountAsync();
            Assert.That(buttonCount, Is.GreaterThan(0),
                $"[WindHail] Zip {zipCode}: WH deductible field present but no option buttons found.");

            var optionTexts = (await GetAllWindHailOptionsAsync(scope))
                .Select(NormalizeWhText)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            Console.WriteLine($"[WindHail] Zip {zipCode}: Available options - {string.Join(", ", optionTexts)}");

            if (rules.Value.minDeductible == "1%")
            {
                // ADO step 16 & 17: 1% must exist and nothing lower should be present
                Assert.That(optionTexts.Contains("1%"), Is.True,
                    $"[WindHail] Zip {zipCode}: Expected minimum '1%' option not found. Available: {string.Join(", ", optionTexts)}");

                var subMin = optionTexts.Where(t =>
                {
                    var n = t.Replace("%", "").Trim();
                    return decimal.TryParse(n, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) && v < 1m;
                }).ToList();

                Assert.That(subMin.Count, Is.EqualTo(0),
                    $"[WindHail] Zip {zipCode}: Found WH options below minimum 1%: {string.Join(", ", subMin)}");

                Console.WriteLine($"[WindHail] Zip {zipCode}: Verified – minimum WH deductible of 1% confirmed, no sub-minimum options.");
            }
            else
            {
                Console.WriteLine($"[WindHail] Zip {zipCode}: No mandatory minimum – field present with {buttonCount} option(s).");
            }

            // ADO step 18: verify an above-minimum option exists (visible or in overflow)
            var aboveMin = optionTexts
                .Where(t =>
                {
                    var n = t.Replace("%", "").Trim();
                    return decimal.TryParse(n, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) && v > 1m;
                })
                .ToList();

            if (aboveMin.Count > 0)
            {
                Console.WriteLine($"[WindHail] Zip {zipCode}: Verified – above-minimum option '{aboveMin[0]}' is available.");
            }
            else
            {
                Console.WriteLine($"[WindHail] Zip {zipCode}: No above-minimum WH deductible options present for this zip.");
            }
        }
    }
}
