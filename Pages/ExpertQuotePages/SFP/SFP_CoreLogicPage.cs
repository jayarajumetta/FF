using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    public class SFP_CoreLogicPage(IPage page) : BasePage(page)
    {
        private ILocator DepreciationInput =>
            _page.GetByLabel(new Regex(@"^\s*(?:Physical\s+)?Depreciation(?:\s+Percentage|\s*%)?\s*:?$", RegexOptions.IgnoreCase))
                .And(_page.Locator("input:visible"));

        private ILocator SaveButton =>
            _page.GetByRole(AriaRole.Button, new()
            {
                NameRegex = new Regex(@"^\s*Save(?:\s+and\s+Close)?\s*$", RegexOptions.IgnoreCase)
            }).And(_page.Locator(":visible"));

        public async Task SetAndSaveDepreciationAsync(string percentage)
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Expect(DepreciationInput).ToHaveCountAsync(1);
            await DepreciationInput.FillAsync(percentage);
            await DepreciationInput.PressAsync("Tab");
            await SfpFieldAssertions.NumberAsync(DepreciationInput, percentage);
            await Expect(SaveButton).ToHaveCountAsync(1);
            await Expect(SaveButton).ToBeEnabledAsync();
            if (await SaveButton.And(_page.GetByRole(AriaRole.Button, new()
                { NameRegex = new Regex(@"^\s*Save\s+and\s+Close\s*$", RegexOptions.IgnoreCase) })).CountAsync() == 1)
            {
                var closed = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                EventHandler<IPage> onClose = (_, _) => closed.TrySetResult(true);
                _page.Close += onClose;
                try
                {
                    await SaveButton.ClickAsync();
                    await closed.Task.WaitAsync(TimeSpan.FromSeconds(30));
                }
                finally
                {
                    _page.Close -= onClose;
                }
                return;
            }
            await SaveButton.ClickAsync();
            if (!_page.IsClosed)
            {
                await _page.ReloadAsync(new() { WaitUntil = WaitUntilState.DOMContentLoaded });
                await SfpFieldAssertions.NumberAsync(DepreciationInput, percentage);
                await _page.CloseAsync();
            }
        }
    }
}
