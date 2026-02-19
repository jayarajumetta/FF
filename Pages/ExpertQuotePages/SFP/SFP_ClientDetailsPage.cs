using Microsoft.Playwright;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    public class SFP_ClientDetailsPage : BasePage
    {
        public SFP_ClientDetailsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator ClientNameHeading => _page.Locator("h2");
        private ILocator StreetAddressValue => _page.Locator("div.readonly-value");
        private ILocator PhoneNumberLabel => _page.Locator("span.readonly-label", new() { HasTextString = "Phone Number" });
        
        // Checkboxes - using GetByRole with accessible name for better stability
        private ILocator AuditContactCheckbox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Audit Contact" });
        private ILocator InspectionContactCheckbox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Inspection Contact" });
        
        // Buttons
        private ILocator AddEntityButton => _page.GetByTestId("fields.account.client.addEntityClient");
        #endregion

        #region Verification Methods
        public async Task VerifyClientNameAsync(string firstName, string lastName)
        {
            var expected = $"{lastName?.Trim()}, {firstName?.Trim()}";
            var nameLocator = ClientNameHeading.Filter(new() { HasTextString = expected });
            await Expect(nameLocator.First).ToBeVisibleAsync();
            await Expect(nameLocator.First).ToContainTextAsync(expected);
        }

        public async Task VerifyClientStreetAddressAsync(string address)
        {
            var expected = address.Trim().ToUpperInvariant();
            var addressLocator = StreetAddressValue.Filter(new() { HasTextString = expected });
            await Expect(addressLocator.First).ToBeVisibleAsync();
            await Expect(addressLocator.First).ToContainTextAsync(expected);
        }

        public async Task VerifyClientPhoneAsync(string phone)
        {
            await Expect(PhoneNumberLabel.First).ToBeVisibleAsync();
            var phoneValue = PhoneNumberLabel.First
                .Locator("xpath=following-sibling::span[contains(@class,'readonly-value')]");
            await Expect(phoneValue).ToHaveTextAsync(phone?.Trim() ?? string.Empty);
        }
        #endregion

        #region Actions
        public async Task CheckAuditContactAsync()
        {
            await AuditContactCheckbox.CheckAsync();
        }

        public async Task CheckInspectionContactAsync()
        {
            await InspectionContactCheckbox.CheckAsync();
        }

        public async Task ClickAddEntityAsync()
        {
            await AddEntityButton.ClickAsync();
            await WaitForSpinnerAsync();
        }
        #endregion
    }
}
