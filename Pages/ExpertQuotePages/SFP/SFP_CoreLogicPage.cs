using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    public class SFP_CoreLogicPage(IPage page) : BasePage(page)
    {
        private ILocator OptionsMenu =>
            _page.Locator("#rct-topToolBarMenu > ul.sf-menu.sf-js-enabled > #menu_options");

        private ILocator MarkupsAndAdjustmentsLink => _page.Locator("#AddMarkupsAndAdjustmentsLink");

        private ILocator MarkupsAndAdjustmentsWindow =>
            _page.Locator("#AddMarkupsAndAdjustmentsWindow");

        private ILocator MarkupsAndAdjustmentsContent =>
            MarkupsAndAdjustmentsWindow.Locator("#CreateAdjustmentDiv");

        private ILocator UseDepreciationPercentage =>
            MarkupsAndAdjustmentsWindow.Locator("#UseDepreciationPercentage");

        private ILocator DepreciationInput =>
            MarkupsAndAdjustmentsWindow.Locator("#ViewModel_DepreciationPercent");

        private ILocator AdjustmentSaveButton =>
            MarkupsAndAdjustmentsWindow.Locator("input[type='submit'][value='Save']");

        private ILocator CalculateButton =>
            _page.Locator("input.recalc-valuation-totals[value='Calculate']");

        private ILocator FinishButton =>
            _page.Locator("input.save-or-discard-valuation[value='Finish']");

        private ILocator FinalSaveWindow =>
            _page.Locator("#ConfirmationWindow");

        private ILocator FinalSaveMessage =>
            FinalSaveWindow.Locator("#ConfirmationDiv");

        private ILocator FinalSaveButton =>
            FinalSaveWindow.Locator("#SaveValuationButton");

        private ILocator CompletionResult =>
            _page.Locator("#lblResult");

        private ILocator CompletionMessage =>
            _page.Locator("#lblMessage");

        public async Task SetAndSaveDepreciationAsync(string percentage)
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            await Expect(OptionsMenu).ToBeVisibleAsync(new() { Timeout = 30_000 });
            await OptionsMenu.HoverAsync();
            await Expect(MarkupsAndAdjustmentsLink).ToBeVisibleAsync();
            await MarkupsAndAdjustmentsLink.ClickAsync();

            await Expect(MarkupsAndAdjustmentsWindow).ToBeVisibleAsync(new() { Timeout = 30_000 });
            await Expect(MarkupsAndAdjustmentsContent).ToBeVisibleAsync(new() { Timeout = 30_000 });
            await Expect(UseDepreciationPercentage).ToHaveCountAsync(1);
            await UseDepreciationPercentage.CheckAsync();
            await Expect(UseDepreciationPercentage).ToBeCheckedAsync();
            await Expect(DepreciationInput).ToHaveCountAsync(1);
            await Expect(DepreciationInput).ToBeEnabledAsync();
            await DepreciationInput.FillAsync(percentage);
            await DepreciationInput.PressAsync("Tab");
            await SfpFieldAssertions.NumberAsync(DepreciationInput, percentage);

            await Expect(AdjustmentSaveButton).ToHaveCountAsync(1);
            await Expect(AdjustmentSaveButton).ToBeEnabledAsync();
            await AdjustmentSaveButton.ClickAsync();
            await Expect(MarkupsAndAdjustmentsWindow).ToBeHiddenAsync(new() { Timeout = 30_000 });

            await Expect(CalculateButton).ToBeVisibleAsync();
            await Expect(CalculateButton).ToBeEnabledAsync();
            await CalculateButton.ClickAsync();
            await Expect(CalculateButton).ToBeHiddenAsync(new() { Timeout = 30_000 });

            await Expect(FinishButton).ToBeVisibleAsync();
            await Expect(FinishButton).ToBeEnabledAsync();
            await FinishButton.ClickAsync();

            await Expect(FinalSaveWindow).ToBeVisibleAsync(new() { Timeout = 30_000 });
            await Expect(FinalSaveMessage).ToContainTextAsync("Click Save to save your changes.");
            await Expect(FinalSaveButton).ToHaveCountAsync(1);
            await Expect(FinalSaveButton).ToBeEnabledAsync();
            var closed = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            EventHandler<IPage> onClose = (_, _) => closed.TrySetResult(true);
            _page.Close += onClose;
            try
            {
                await FinalSaveButton.ClickAsync();
                if (_page.IsClosed)
                {
                    await closed.Task.WaitAsync(TimeSpan.FromSeconds(30));
                    return;
                }

                var completionPage = WaitForCompletionPageAsync();
                var completionSignal = await Task.WhenAny(closed.Task, completionPage);
                if (completionSignal == closed.Task)
                {
                    await closed.Task;
                    try
                    {
                        await completionPage;
                    }
                    catch (PlaywrightException) when (_page.IsClosed)
                    {
                    }

                    return;
                }

                try
                {
                    await completionPage;
                }
                catch (PlaywrightException) when (_page.IsClosed)
                {
                    await closed.Task.WaitAsync(TimeSpan.FromSeconds(30));
                    return;
                }

                await _page.CloseAsync();
                await closed.Task.WaitAsync(TimeSpan.FromSeconds(30));
            }
            finally
            {
                _page.Close -= onClose;
            }
        }

        private async Task WaitForCompletionPageAsync()
        {
            await Expect(CompletionResult).ToHaveTextAsync("Complete!", new() { Timeout = 30_000 });
            await Expect(CompletionMessage).ToContainTextAsync(
                "You may now close this window. This valuation is being processed.");
        }
    }
}
