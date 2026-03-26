using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_POC.Pages
{
    /// <summary>
    /// Base class for all Page Objects providing common functionality.
    ///
    /// Selector strategy:
    ///   - DuckCreek form engine fields use <c>GetByTestId("fields.data.*")</c> — those test IDs
    ///     are owned by DuckCreek and are not being migrated.
    ///   - ANi-built UI components (nav, dashboard, landing page) are migrating from
    ///     <c>data-testid</c> attributes to standard HTML <c>id</c> attributes as part of the
    ///     internal library migration (INC0183313 and subsequent rollout).
    ///     Use <c>GetById(id)</c> for <c>#id</c> lookups, or the dual-selector helper
    ///     <c>_page.Locator($"[data-testid='{x}'], #{x}")</c> for elements currently in
    ///     transition so they work whether or not the attribute has been migrated yet.
    /// </summary>
    public abstract class BasePage
    {
        protected readonly IPage _page;

        protected BasePage(IPage page)
        {
            _page = page;
        }

        /// <summary>
        /// Locate an element by standard HTML <c>id</c> attribute.
        /// Use this for ANi-built components that have been migrated away from <c>data-testid</c>.
        /// </summary>
        protected ILocator GetById(string id) => _page.Locator($"#{id}");

        /// <summary>
        /// Wait for the page-specific loading indicator to clear
        /// </summary>
        public async Task WaitForSpinnerAsync(int timeoutMs = 60000)
        {
            var overlay = _page.Locator(".ngx-spinner-overlay");
            if (await overlay.CountAsync() > 0)
            {
                await overlay.First.WaitForAsync(new() { State = WaitForSelectorState.Hidden, Timeout = timeoutMs });
            }
        }

        /// <summary>
        /// Click the standard Next button
        /// </summary>
        public async Task ClickNextAsync()
        {
            var candidates = new[]
            {
                _page.GetByTestId("fields.data.next"),
                _page.GetByTestId("fields.data-Next.next"),
                _page.GetByTestId("fields.data_Next.next"),
                _page.GetByTestId("fields.data_Rules.next"),
                _page.GetByTestId("fields.data_Rules.nextEB"),
                _page.GetByTestId("next"),
                _page.GetByRole(AriaRole.Button, new() { Name = "Next" })
            };

            foreach (var candidate in candidates)
            {
                if (await candidate.CountAsync() > 0 && await candidate.First.IsVisibleAsync())
                {
                    await candidate.First.ClickAsync();
                    return;
                }
            }

            throw new PlaywrightException("Next button not found using any known data-testid.");
        }

        /// <summary>
        /// Click the standard Save button (tries multiple known data-testids)
        /// </summary>
        public async Task ClickSaveAsync()
        {
            var candidates = new[]
            {
                _page.GetByTestId("fields.data.save"),
                _page.GetByTestId("fields.data_Actions.save"),
                _page.GetByTestId("fields.line.save"),
                _page.GetByRole(AriaRole.Button, new() { Name = "Save" })
            };

            foreach (var candidate in candidates)
            {
                if (await candidate.CountAsync() > 0 && await candidate.First.IsVisibleAsync())
                {
                    await candidate.First.ClickAsync();
                    await WaitForSpinnerAsync();
                    return;
                }
            }

            throw new PlaywrightException("Save button not found using any known data-testid.");
        }

        /// <summary>
        /// Click Save and Continue button
        /// </summary>
        public async Task ClickSaveAndContinueAsync()
        {
            await _page.GetByTestId("fields.line.save_and_Continue").ClickAsync();
            await WaitForSpinnerAsync();
        }

        /// <summary>
        /// Click an Angular Material toggle button only if not already selected
        /// </summary>
        public async Task ClickIfNotSelectedAsync(ILocator locator)
        {
            bool isSelected = await locator.EvaluateAsync<bool>(
                "el => el.classList.contains('mat-button-toggle-checked')"
            );

            if (!isSelected)
                await locator.ClickAsync();
        }
    }
}
