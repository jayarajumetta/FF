using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_POC.Helpers;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    public class ClientDetailsPage : BasePage
    {
        public ClientDetailsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator AuditContactCheckbox => _page.GetByTestId("fields.primaryInsured.accountInput$isAuditContact.value");
        private ILocator InspectionContactCheckbox => _page.GetByTestId("fields.primaryInsured.accountInput$isInspectionContact.value");
        private ILocator AddEntityButton => _page.Locator("button:has-text('Add Entity')");
        #endregion

        public async Task VerifyClientName(string firstName, string lastName)
        {
            var expected = $"{lastName?.Trim()}, {firstName?.Trim()}";

            var nameDisplayed = _page.Locator("h2").Filter(new() { HasTextString = expected });

            await nameDisplayed.First.WaitForAsync(new() { State = WaitForSelectorState.Visible });

            var actual = (await nameDisplayed.First.InnerTextAsync()).Trim();

            if (!string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"Expected client name to be '{expected}' but was '{actual}'");
            }
        }

        public async Task VerifyClientStreetAddress(string address)
        {


            Assert.That(address, Is.Not.Null.And.Not.Empty, "Expected street address was null or empty.");

            var expected = address.Trim().ToUpperInvariant();

            // Locate readonly text values and find the one containing the street address
            var streetAddressLocator = _page
                .Locator("div.readonly-value")
                .Filter(new() { HasTextString = expected });

            await streetAddressLocator.First.WaitForAsync(
                new() { State = WaitForSelectorState.Visible });

            var actual = (await streetAddressLocator.First.InnerTextAsync()).Trim();

            Assert.That(
                actual,
                Is.EqualTo(expected),
                $"Street Address mismatch. Expected: '{expected}', Actual: '{actual}'"
            );

        }

        public async Task VerifyClientPhone(string phone)
        {

            // Anchor on the label so we don't rely on position/order
            var phoneLabel = _page.Locator(
                "span.readonly-label",
                new() { HasTextString = "Phone Number" }
            );

            await phoneLabel.First.WaitForAsync(
                new() { State = WaitForSelectorState.Visible }
            );

            // The value is the readonly-value span immediately following the label
            var phoneValue = phoneLabel.First
                .Locator("xpath=following-sibling::span[contains(@class,'readonly-value')]");

            var actual = (await phoneValue.InnerTextAsync())?.Trim() ?? string.Empty;
            var expected = phone?.Trim() ?? string.Empty;


            Assert.That(
                actual,
                Is.EqualTo(expected),
                $"Phone Number mismatch. Expected: '{expected}', Actual: '{actual}'."
            );


        }

        public async Task CheckAuditContact()
        {
            var checkbox = AuditContactCheckbox.Locator("input[type='checkbox']");

            await checkbox.WaitForAsync(new() { State = WaitForSelectorState.Attached });

            if (!await checkbox.IsCheckedAsync())
            {
                await checkbox.ClickAsync();
            }
        }

        public async Task CheckInspectionContact()
        {
            var checkbox = InspectionContactCheckbox.Locator("input[type='checkbox']");

            await checkbox.WaitForAsync(new() { State = WaitForSelectorState.Attached });

            if (!await checkbox.IsCheckedAsync())
            {
                await checkbox.ClickAsync();
            }
        }
    }
}
