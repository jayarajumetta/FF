#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PnCTestAutomation.Controls
{
    public sealed class PlaywrightControlRuntime : IControlRuntime
    {
        private readonly IPage _rootPage;

        public PlaywrightControlRuntime(IPage rootPage)
        {
            _rootPage = rootPage;
        }

        public Task<IReadOnlyList<IControlScopeAdapter>> GetScopesAsync(
            CancellationToken cancellationToken = default)
        {
            var scopes = new List<IControlScopeAdapter>();
            var pages = _rootPage.Context.Pages;
            for (var pageIndex = 0; pageIndex < pages.Count; pageIndex++)
            {
                var page = pages[pageIndex];
                if (page.IsClosed)
                    continue;

                var orderedFrames = new[] { page.MainFrame }
                    .Concat(page.Frames.Where(frame => frame != page.MainFrame));
                foreach (var frame in orderedFrames)
                {
                    var depth = GetFrameDepth(frame);
                    var isMainFrame = depth == 0;
                    var frameName = string.IsNullOrWhiteSpace(frame.Name)
                        ? "<unnamed>"
                        : frame.Name;
                    var description = isMainFrame
                        ? $"page {pageIndex + 1} main frame"
                        : $"page {pageIndex + 1} frame '{frameName}' depth {depth}";

                    scopes.Add(new PlaywrightControlScope(
                        frame,
                        new ControlScope(
                            description,
                            pageIndex,
                            depth,
                            isMainFrame)));
                }
            }

            return Task.FromResult<IReadOnlyList<IControlScopeAdapter>>(scopes);
        }

        private static int GetFrameDepth(IFrame frame)
        {
            var depth = 0;
            for (var parent = frame.ParentFrame; parent != null; parent = parent.ParentFrame)
                depth++;
            return depth;
        }
    }

    public sealed class PlaywrightControlScope : IControlScopeAdapter
    {
        private readonly IFrame _frame;

        public PlaywrightControlScope(IFrame frame, ControlScope scope)
        {
            _frame = frame;
            Scope = scope;
        }

        public ControlScope Scope { get; }

        public async Task<IReadOnlyList<IControlElement>> FindVisibleAsync(
            ControlSelector selector,
            CancellationToken cancellationToken = default)
        {
            var locator = selector.Kind switch
            {
                ControlSelectorKind.TestId => _frame.GetByTestId(selector.Value),
                ControlSelectorKind.AniHtmlId => _frame.Locator(
                    $"[id=\"{EscapeCssAttributeValue(selector.Value)}\"]"),
                _ => throw new ArgumentOutOfRangeException(nameof(selector))
            };

            var visible = locator.Filter(new() { Visible = true });
            var count = await visible.CountAsync();
            var matches = new List<IControlElement>(count);
            for (var index = 0; index < count; index++)
                matches.Add(new PlaywrightControlElement(visible.Nth(index)));
            return matches;
        }

        private static string EscapeCssAttributeValue(string value) =>
            value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    public sealed class PlaywrightControlElement : IControlElement
    {
        private readonly ILocator _locator;

        public PlaywrightControlElement(ILocator locator)
        {
            _locator = locator;
        }

        public Task ScrollIntoViewAsync(CancellationToken cancellationToken = default) =>
            _locator.ScrollIntoViewIfNeededAsync();

        public Task ClickAsync(CancellationToken cancellationToken = default) =>
            _locator.ClickAsync();

        public Task FillAsync(
            string value,
            CancellationToken cancellationToken = default) =>
            _locator.FillAsync(value);

        public async Task SelectAsync(
            string value,
            CancellationToken cancellationToken = default)
        {
            await _locator.SelectOptionAsync(value);
        }

        public Task SetCheckedAsync(
            bool value,
            CancellationToken cancellationToken = default) =>
            _locator.SetCheckedAsync(value);

        public Task<bool> IsCheckedAsync(CancellationToken cancellationToken = default) =>
            _locator.IsCheckedAsync();

        public Task<bool> IsEnabledAsync(CancellationToken cancellationToken = default) =>
            _locator.IsEnabledAsync();

        public Task<bool> IsSelectedAsync(CancellationToken cancellationToken = default) =>
            _locator.EvaluateAsync<bool>(
                """
                element => {
                    const nested = element.querySelector('input, option');
                    const candidate = nested || element;
                    return candidate.checked === true ||
                        candidate.selected === true ||
                        element.getAttribute('aria-selected') === 'true' ||
                        element.getAttribute('aria-pressed') === 'true' ||
                        element.getAttribute('aria-checked') === 'true' ||
                        element.classList.contains('mat-button-toggle-checked') ||
                        element.classList.contains('mat-mdc-button-toggle-checked');
                }
                """);

        public Task<string> GetValueAsync(CancellationToken cancellationToken = default) =>
            _locator.EvaluateAsync<string>(
                """
                element => {
                    const candidate = element.querySelector('input, textarea') || element;
                    return 'value' in candidate
                        ? String(candidate.value ?? '')
                        : String(candidate.getAttribute('value') ?? candidate.textContent ?? '').trim();
                }
                """);

        public Task<string> GetSelectedValueAsync(
            CancellationToken cancellationToken = default) =>
            _locator.EvaluateAsync<string>(
                """
                element => {
                    const select = element.matches('select')
                        ? element
                        : element.querySelector('select');
                    if (select) return String(select.value ?? '');

                    const selected = element.querySelector(
                        '[aria-selected="true"], option:checked, .mat-selected, .mdc-list-item--selected');
                    return String(
                        selected?.getAttribute('value') ??
                        selected?.textContent ??
                        element.getAttribute('value') ??
                        '').trim();
                }
                """);
    }
}
