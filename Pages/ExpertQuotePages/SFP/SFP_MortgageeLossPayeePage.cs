using Microsoft.Playwright;
using System;
using System.Linq;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    /// <summary>
    /// SFP Mortgagee / Loss Payee page - for adding mortgagee additional interest to a policy.
    /// </summary>
    public class SFP_MortgageeLossPayeePage : BasePage
    {
        public SFP_MortgageeLossPayeePage(IPage page) : base(page) { }

        #region Locators - Add Mortgagee Button
        // Primary: button text "ADD ADDITIONAL INTEREST" (robust against testid changes)
        public ILocator AddMortgageeButton =>
            _page.GetByRole(AriaRole.Button, new() { NameRegex = new System.Text.RegularExpressions.Regex("add additional interest", System.Text.RegularExpressions.RegexOptions.IgnoreCase) });

        // Legacy testid fallback (kept for reference — may no longer be present in DOM)
        public ILocator AddMortgageeButtonByTestId =>
            _page.GetByTestId("fields.data.account.additionalOtherInterest.addAdditionalInterests");
        #endregion

        #region Locators - Search
        public ILocator SearchNameInput =>
            _page.GetByTestId("temp.searchName");

        public ILocator SearchButton =>
            _page.GetByTestId("searchActionButton");

        public ILocator FirstSearchResultCheckbox =>
            _page.GetByTestId("additionalInsuredSelected.0-checkbox-wrapper").GetByTestId("additionalInsuredSelected.0");
        #endregion

        #region Locators - Mortgagee Details Form
        public ILocator LocationSelect =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$locationID.value");

        public ILocator ResidenceSelect =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$buildingID.value");

        // Residence/Building is a mat-select dropdown — options appear in a CDK overlay with role="option", no test IDs
        public ILocator FirstResidenceOption =>
            _page.GetByRole(AriaRole.Option).First;

        public ILocator DescriptionOfInterestInput =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$descriptionOfInterest.value");

        public ILocator AccountNumberInput =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$accountNumber.value");

        public ILocator ProofOfCoverageYesButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;

        public ILocator ProofOfCoverageNoButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$proofOfCoverageRequired.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;

        public ILocator EscrowBilledYesButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-item-wrapper")
                 .Filter(new() { HasText = "Yes" }).First;

        public ILocator EscrowBilledNoButton =>
            _page.GetByTestId("fields.additionalOtherInterest.additionalOtherInterestInput$mortgageeResponsibleForEscrow.value-chip-item-wrapper")
                 .Filter(new() { HasText = "No" }).First;

        public ILocator SaveMortgageeButton =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Save" });

        public ILocator NextButton =>
            _page.GetByTestId("fields.data.next");
        #endregion

        #region Actions
        public async Task AddMortgageeAsync(ScenarioContextData contextData)
        {
            await WaitForSpinnerAsync();
            await ThrowIfQuoteErrorAsync("opening Mortgagee/Loss Payee");

            // Click + ADD ADDITIONAL INTEREST to open the mortgagee form
            // Wait explicitly for the button to appear — it renders after the spinner on CI.
            await AddMortgageeButton
                .Or(AddMortgageeButtonByTestId)
                .First.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 15000 });

            // Try role-based locator first (robust against testid changes), fall back to testid
            ILocator addBtn;
            if (await AddMortgageeButton.CountAsync() > 0 && await AddMortgageeButton.IsVisibleAsync())
                addBtn = AddMortgageeButton;
            else if (await AddMortgageeButtonByTestId.CountAsync() > 0 && await AddMortgageeButtonByTestId.IsVisibleAsync())
                addBtn = AddMortgageeButtonByTestId;
            else
                throw new PlaywrightException("+ ADD ADDITIONAL INTEREST button not found on Mortgagee/Loss Payee page.");

            await addBtn.ClickAsync();
            await WaitForSpinnerAsync();

            // Search for mortgagee by name
            if (!string.IsNullOrEmpty(contextData.MortgageeSearchName))
            {
                await SearchNameInput.FillAsync(contextData.MortgageeSearchName);
                await SearchButton.ClickAsync();
                await WaitForSpinnerAsync();

                // Select the first search result
                await FirstSearchResultCheckbox.ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Select Location if specified
            var availableLocationOptions = Array.Empty<string>();
            if (!string.IsNullOrEmpty(contextData.MortgageeLocation))
            {
                await LocationSelect.ClickAsync();
                var locationOptions = _page.GetByRole(AriaRole.Option).Filter(new() { Visible = true });
                await locationOptions.First.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
                availableLocationOptions = (await locationOptions.AllTextContentsAsync())
                    .Select(NormalizeDiagnosticText)
                    .Where(option => !string.IsNullOrWhiteSpace(option))
                    .ToArray();
                var requestedLocation = _page.GetByRole(
                    AriaRole.Option,
                    new() { Name = contextData.MortgageeLocation, Exact = false }).First;
                await requestedLocation.ClickAsync();
                await WaitForSpinnerAsync();
                await ThrowIfQuoteErrorAsync(
                    $"refreshing Mortgagee residence options after selecting location '{contextData.MortgageeLocation}'");
            }

            // Select Residence if specified
            // Wait explicitly for the Residence dropdown to become visible — it only renders
            // after Location is selected and the page re-renders (slower on CI agents).
            if (!string.IsNullOrEmpty(contextData.MortgageeResidence))
            {
                try
                {
                    await ResidenceSelect.WaitForAsync(new()
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 30000
                    });
                }
                catch (TimeoutException ex)
                {
                    await ThrowIfQuoteErrorAsync(
                        $"waiting for Mortgagee residence '{contextData.MortgageeResidence}'");
                    throw new PlaywrightException(
                        "Mortgagee residence options did not refresh after location selection. " +
                        await BuildMortgageeRefreshDiagnosticsAsync(availableLocationOptions),
                        ex);
                }

                await ResidenceSelect.ClickAsync();
                var residenceOptions = _page.GetByRole(AriaRole.Option).Filter(new() { Visible = true });
                await residenceOptions.First.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
                var availableResidences = (await residenceOptions.AllTextContentsAsync())
                    .Select(NormalizeDiagnosticText)
                    .Where(option => !string.IsNullOrWhiteSpace(option))
                    .ToArray();
                var residenceIndex = ResolveResidenceOptionIndex(
                    contextData.MortgageeResidence,
                    availableResidences);
                if (residenceIndex < 0)
                {
                    await _page.Keyboard.PressAsync("Escape");
                    throw new PlaywrightException(
                        $"Mortgagee residence '{contextData.MortgageeResidence}' was not offered. " +
                        $"Available residences: {(availableResidences.Length == 0 ? "<none>" : string.Join(", ", availableResidences))}. " +
                        await BuildMortgageeRefreshDiagnosticsAsync(availableLocationOptions));
                }

                if (!availableResidences[residenceIndex].Contains(
                    contextData.MortgageeResidence,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        $"[Mortgagee] The only residence option is '{availableResidences[residenceIndex]}'; " +
                        $"using it for requested residence '{contextData.MortgageeResidence}'.");
                }

                await residenceOptions.Nth(residenceIndex).ClickAsync();
                await WaitForSpinnerAsync();
                await ThrowIfQuoteErrorAsync(
                    $"selecting Mortgagee residence '{contextData.MortgageeResidence}'");
            }

            // Copy of DEC (Proof of Coverage Required)
            if (!string.IsNullOrEmpty(contextData.MortgageeCopyOfDEC))
            {
                var isYes = contextData.MortgageeCopyOfDEC.ToLower() is "yes" or "true";
                await (isYes ? ProofOfCoverageYesButton : ProofOfCoverageNoButton).ClickAsync();
            }

            // Account Number
            if (!string.IsNullOrEmpty(contextData.MortgageeAccountNumber))
                await AccountNumberInput.FillAsync(contextData.MortgageeAccountNumber);

            // Description of Interest (free text input)
            if (!string.IsNullOrEmpty(contextData.MortgageeDescriptionOfInterest))
                await DescriptionOfInterestInput.FillAsync(contextData.MortgageeDescriptionOfInterest);

            // Escrow Billed (Mortgagee Responsible for Escrow)
            if (!string.IsNullOrEmpty(contextData.MortgageeEscrowBilled))
            {
                var isYes = contextData.MortgageeEscrowBilled.ToLower() is "yes" or "true";
                await (isYes ? EscrowBilledYesButton : EscrowBilledNoButton).ClickAsync();
                await WaitForSpinnerAsync();
            }

            // Save the mortgagee
            await SaveMortgageeButton.ClickAsync();
            await WaitForSpinnerAsync();

            // Navigate to next page (Insurance Score)
            // Use ClickNextAsync() to handle variations in the Next button test ID across page states
            await ClickNextAsync();
            await WaitForSpinnerAsync();
        }

        private async Task<string> BuildMortgageeRefreshDiagnosticsAsync(string[] availableLocationOptions)
        {
            var locationVisible = await LocationSelect.Filter(new() { Visible = true }).CountAsync() > 0;
            var residenceVisible = await ResidenceSelect.Filter(new() { Visible = true }).CountAsync() > 0;
            var selectedLocation = locationVisible
                ? NormalizeDiagnosticText(await LocationSelect.InnerTextAsync())
                : "<unavailable>";
            var selectedResidence = residenceVisible
                ? NormalizeDiagnosticText(await ResidenceSelect.InnerTextAsync())
                : "<unavailable>";
            var spinnerVisible = await _page.Locator(".ngx-spinner-overlay:visible").CountAsync() > 0;

            return string.Join(
                " | ",
                await BuildPageDiagnosticsAsync(),
                $"LocationVisible={locationVisible}",
                $"SelectedLocation={selectedLocation}",
                $"LocationOptions={(availableLocationOptions.Length == 0 ? "<none>" : string.Join(", ", availableLocationOptions))}",
                $"ResidenceVisible={residenceVisible}",
                $"SelectedResidence={selectedResidence}",
                $"OutstandingSpinner={spinnerVisible}");
        }

        private static string NormalizeDiagnosticText(string value)
        {
            var normalized = string.Join(
                " ",
                (value ?? string.Empty)
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                .Trim();
            return normalized.Length <= 200 ? normalized : normalized[..200] + "...";
        }

        internal static int ResolveResidenceOptionIndex(string requestedResidence, string[] availableResidences)
        {
            var exactOrContaining = Array.FindIndex(
                availableResidences,
                option => option.Contains(requestedResidence, StringComparison.OrdinalIgnoreCase));
            if (exactOrContaining >= 0)
                return exactOrContaining;

            return availableResidences.Length == 1 ? 0 : -1;
        }
        #endregion
    }
}
