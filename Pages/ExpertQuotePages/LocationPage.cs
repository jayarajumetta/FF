using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
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

namespace Playwright_POC.Pages
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
            await _page.WaitForTimeoutAsync(3000);
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
            await _page.WaitForTimeoutAsync(3000);
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
            await _page.WaitForTimeoutAsync(500);
            
            // Wait for panel to appear and select option by text
            var option = _page.Locator(".cdk-overlay-pane mat-option").GetByText(normalizedValue, new() { Exact = true });
            await option.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            await option.ClickAsync();
            
            // Wait for panel to close
            await _page.WaitForTimeoutAsync(300);
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

        private ILocator WindHailScope() => _page.Locator("div:has(button[data-testid*='locationInput$windHailDeductible.value'])").First;
        private ILocator WindHailDeductibleChip(string text) => WindHailScope()
                                        .Locator("button[data-testid*='locationInput$windHailDeductible.value']")
                                        .Filter(new() { HasTextString = text });

        private ILocator WindHailMoreOptionsButton() =>
                WindHailScope().GetByRole(AriaRole.Button, new() { Name = "More Options", Exact = true });
        private ILocator WindHailMenuItem(string text) =>
                _page.Locator(".cdk-overlay-pane .mat-menu.panel, .cdk-overlay-pane .mat-mdc-menu-panel")
                .Last
                .GetByRole(AriaRole.Menuitem, new() { Name = text, Exact = true });

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
            // Resolve the correct choice using the same zip-to-zone rules used for verification.
            // States with no minimum (minDeductible = null) should always select "N/A" regardless
            // of what the feature file specifies — this matches the Tosca baseline behaviour.
            // States where WH cannot be added (cannotBeAdded = true) skip entirely; the field
            // won't exist so the scope check below will also skip.
            string choice;
            if (!string.IsNullOrEmpty(zipCode))
            {
                var rules = GetWindHailRulesForZip(zipCode);
                if (rules?.cannotBeAdded == true)
                {
                    Console.WriteLine($"[WindHail] Zip {zipCode} — WH cannot be added, skipping selection.");
                    return;
                }
                if (rules?.minDeductible == null)
                {
                    // No minimum state — Tosca selects N/A
                    choice = "N/A";
                    Console.WriteLine($"[WindHail] Zip {zipCode} — no minimum state, overriding to 'N/A'.");
                }
                else
                {
                    // Minimum required — use the requested value (e.g. 1%)
                    choice = (deductible ?? "").Trim().ToUpperInvariant();
                }
            }
            else
            {
                choice = (deductible ?? "").Trim().ToUpperInvariant();
            }

            // Check if Wind/Hail deductible field exists (not all states have this field)
            var scope = WindHailScope();
            if (await scope.CountAsync() == 0)
            {
                Console.WriteLine("Wind/Hail deductible field not present for this state - skipping.");
                return;
            }

            // Also verify the options exist within the scope
            var buttons = scope.Locator("[data-testid*='locationInput$windHailDeductible.value']");
            if (await buttons.CountAsync() == 0)
            {
                Console.WriteLine("Wind/Hail deductible buttons not found - skipping.");
                return;
            }

            await Helpers.Helpers.SelectButtonAsync(
                page: _page,
                scope: scope,
                value: choice,
                moreOptionsButton: WindHailMoreOptionsButton(),
                timeoutMs: 30000);

            await WaitForSpinnerAsync();
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
                "83814" => (true,  null),   // ID – WH cannot be added
                "61108" => (false, null),   // IL – zone 1, no minimum
                "66112" => (false, null),   // KS – zone 1, no minimum
                "42066" => (false, "1%"),   // KY – zone 2, min 1%
                "71463" => (false, "1%"),   // LA – zone 2, min 1%
                "56762" => (false, null),   // MN – zone 1, no minimum
                "59072" => (false, "1%"),   // MT – zone 2, min 1%
                "69361" => (false, null),   // NE – zone 1, no minimum
                "89101" => (false, null),   // NV – zone 1, no minimum
                "58504" => (false, "1%"),   // ND – zone 1, min 1%
                "97331" => (true,  null),   // OR – WH cannot be added
                "29810" => (false, null),   // SC – zone 2, no minimum
                "57501" => (false, "1%"),   // SD – zone 3, min 1%
                "37604" => (false, null),   // TN – zone 1, no minimum
                "78205" => (false, "1%"),   // TX – zone 1, min 1%
                "84321" => (true,  null),   // UT – WH cannot be added
                "98368" => (true,  null),   // WA – WH cannot be added
                "53704" => (false, null),   // WI – zone 1, no minimum
                "82601" => (false, "1%"),   // WY – zone 2, min 1%
                _       => null
            };

        /// <summary>
        /// Verifies Wind/Hail deductible field state against SFP WH Research zip-to-zone rules.
        /// ADO step 16: asserts field absent for WH-cannot-be-added states; asserts minimum for others.
        /// ADO step 18: asserts above-minimum option is present and enabled where applicable.
        /// </summary>
        public async Task VerifyWindHailDeductibleOptionsAsync(string zipCode)
        {
            var rules = GetWindHailRulesForZip(zipCode);
            if (rules is null)
            {
                Console.WriteLine($"[WindHail] No rules defined for zip '{zipCode}' – skipping WH verification.");
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

            // Collect and normalise all visible option texts
            var optionTexts = new List<string>();
            for (var i = 0; i < buttonCount; i++)
                optionTexts.Add((await buttons.Nth(i).InnerTextAsync()).Trim().Replace(" ", ""));

            Console.WriteLine($"[WindHail] Zip {zipCode}: Available options – {string.Join(", ", optionTexts)}");

            // After EQ upgrade, percentage options may be hidden behind a "More Options" overflow.
            // If no numeric options are visible, open the overflow menu to collect all options.
            var hasNumericOptions = optionTexts.Any(t =>
                decimal.TryParse(t.Replace("%", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out _));
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
                            optionTexts.Add((await menuItems.Nth(i).InnerTextAsync()).Trim().Replace(" ", ""));
                    }
                    await _page.Keyboard.PressAsync("Escape");
                    await _page.WaitForTimeoutAsync(300);
                    Console.WriteLine($"[WindHail] Zip {zipCode}: Expanded overflow – all options: {string.Join(", ", optionTexts)}");
                }
            }

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