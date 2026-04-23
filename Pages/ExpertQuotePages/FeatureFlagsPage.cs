using Microsoft.Playwright;
using Playwright_POC.Pages;
using System;
using System.Threading.Tasks;

namespace Playwright_POC.Pages.ExpertQuotePages
{
    /// <summary>
    /// Feature Flags modal — Dev environment only.
    /// Opened by clicking the Farm Family logo (data-testid="feature-flag-editor-button").
    /// Configures alternative CLAS servers for BOP and SFP, then applies flags.
    /// </summary>
    public class FeatureFlagsPage : BasePage
    {
        public FeatureFlagsPage(IPage page) : base(page) { }

        #region Locators
        private ILocator LogoButton         => _page.GetByTestId("feature-flag-editor-button");

        // BOP server section
        private ILocator BopAltServerCheckbox  => _page.GetByTestId("featureFlags.bop-alt-server-checkbox-wrapper");
        private ILocator BopAltServerWrapper   => _page.Locator("[data-testid='featureFlags.bop-alt-server'] .chip-wrapper").First;
        private ILocator BopServerDropdown     => _page.GetByTestId("serverConfig.clBop.server");

        // SFP server section
        private ILocator SfpAltServerCheckbox  => _page.GetByTestId("featureFlags.sfp-alt-server-checkbox-wrapper");
        private ILocator SfpAltServerWrapper   => _page.Locator("[data-testid='featureFlags.sfp-alt-server'] .chip-wrapper").First;
        private ILocator SfpServerDropdown     => _page.GetByTestId("serverConfig.clSfp.server");

        // Dialog actions
        private ILocator ApplyFlagsButton   => _page.GetByTestId("btnConfirmYes");
        #endregion

        /// <summary>
        /// Opens the Feature Flags modal by clicking the Farm Family logo.
        /// </summary>
        public async Task OpenAsync()
        {
            await LogoButton.WaitForAsync(new() { Timeout = 15000 });
            await LogoButton.ClickAsync();
            // Wait for the dialog to appear
            await _page.WaitForSelectorAsync("mat-dialog-content", new() { Timeout = 15000 });
            Console.WriteLine("[FeatureFlags] Modal opened.");
        }

        /// <summary>
        /// Ensures the BOP alt-server checkbox is checked and the server dropdown is set to the specified value.
        /// </summary>
        private async Task ConfigureBopServerAsync(string serverName)
        {
            // Check if already checked (chip-wrapper has class "checked")
            var wrapperClasses = await BopAltServerWrapper.GetAttributeAsync("class") ?? "";
            if (!wrapperClasses.Contains("checked"))
            {
                await BopAltServerCheckbox.ClickAsync();
                await WaitForSpinnerAsync();
                Console.WriteLine("[FeatureFlags] BOP alt-server checkbox checked.");
            }
            else
            {
                Console.WriteLine("[FeatureFlags] BOP alt-server checkbox already checked.");
            }

            // Select the server from the dropdown
            await BopServerDropdown.WaitForAsync(new() { Timeout = 10000 });
            await BopServerDropdown.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = serverName, Exact = true }).ClickAsync();
            Console.WriteLine($"[FeatureFlags] BOP server set to '{serverName}'.");
        }

        /// <summary>
        /// Ensures the SFP alt-server checkbox is checked and the server dropdown is set to the specified value.
        /// </summary>
        private async Task ConfigureSfpServerAsync(string serverName)
        {
            var wrapperClasses = await SfpAltServerWrapper.GetAttributeAsync("class") ?? "";
            if (!wrapperClasses.Contains("checked"))
            {
                await SfpAltServerCheckbox.ClickAsync();
                await WaitForSpinnerAsync();
                Console.WriteLine("[FeatureFlags] SFP alt-server checkbox checked.");
            }
            else
            {
                Console.WriteLine("[FeatureFlags] SFP alt-server checkbox already checked.");
            }

            await SfpServerDropdown.WaitForAsync(new() { Timeout = 10000 });
            await SfpServerDropdown.ClickAsync();
            await _page.GetByRole(AriaRole.Option, new() { Name = serverName, Exact = true }).ClickAsync();
            Console.WriteLine($"[FeatureFlags] SFP server set to '{serverName}'.");
        }

        /// <summary>
        /// Full Dev environment setup: open modal, configure BOP + SFP servers, apply flags.
        /// </summary>
        public async Task ConfigureDevEnvironmentAsync(string server = "svdw-clas03")
        {
            await OpenAsync();
            await ConfigureBopServerAsync(server);
            await ConfigureSfpServerAsync(server);

            // The mat-select dropdown leaves a CDK overlay backdrop.
            // DispatchEventAsync bypasses the overlay interception to fire the click directly.
            await ApplyFlagsButton.WaitForAsync(new() { Timeout = 10000 });
            await ApplyFlagsButton.DispatchEventAsync("click");

            // Wait for modal to close
            await _page.WaitForSelectorAsync("mat-dialog-content",
                new() { State = WaitForSelectorState.Hidden, Timeout = 15000 });
            Console.WriteLine("[FeatureFlags] Flags applied — Dev environment configured.");
        }
    }
}
