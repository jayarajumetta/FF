#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PnCTestAutomation.Controls
{
    public sealed class PlaywrightControlRuntime : IControlRuntime
    {
        private readonly IPage _rootPage;
        private readonly IReadOnlyList<FrameScopeHint> _frameHints;

        public PlaywrightControlRuntime(
            IPage rootPage,
            IReadOnlyList<FrameScopeHint>? frameHints = null)
        {
            _rootPage = rootPage;
            _frameHints = frameHints ?? [];
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
                    var framePath = GetFramePath(frame);
                    var isMainFrame = depth == 0;
                    var frameName = string.IsNullOrWhiteSpace(frame.Name)
                        ? "<unnamed>"
                        : frame.Name;
                    var description = isMainFrame
                        ? $"page {pageIndex + 1} main frame"
                        : $"page {pageIndex + 1} frame '{frameName}' depth {depth}";
                    var contractId = FrameScopeHintMatcher.Match(
                        _frameHints,
                        pageIndex,
                        framePath);

                    scopes.Add(new PlaywrightControlScope(
                        frame,
                        new ControlScope(
                            description,
                            pageIndex,
                            depth,
                            isMainFrame,
                            CreateRuntimeIdentity(
                                pageIndex,
                                framePath),
                            contractId)));
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

        private static IReadOnlyList<string> GetFramePath(IFrame frame)
        {
            var path = new Stack<string>();
            for (var current = frame;
                 current.ParentFrame != null;
                 current = current.ParentFrame)
            {
                path.Push(current.Name);
            }
            return path.ToArray();
        }

        private static string CreateRuntimeIdentity(
            int pageIndex,
            IReadOnlyList<string> framePath)
        {
            var canonical =
                $"{pageIndex}|{string.Join(">", framePath)}";
            return Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(canonical)));
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
            {
                var candidate = visible.Nth(index);
                if (selector.ExactText != null &&
                    !string.Equals(
                        (await candidate.InnerTextAsync()).Trim(),
                        selector.ExactText,
                        StringComparison.Ordinal))
                {
                    continue;
                }
                matches.Add(new PlaywrightControlElement(candidate, _frame));
            }
            return matches;
        }

        internal static string EscapeCssAttributeValue(string value) =>
            value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    public sealed class PlaywrightControlElement : IControlElement
    {
        private readonly ILocator _locator;
        private readonly IFrame _frame;

        public PlaywrightControlElement(ILocator locator, IFrame frame)
        {
            _locator = locator;
            _frame = frame;
        }

        public Task ScrollIntoViewAsync(CancellationToken cancellationToken = default) =>
            _locator.ScrollIntoViewIfNeededAsync();

        public Task ClickAsync(CancellationToken cancellationToken = default) =>
            _locator.ClickAsync();

        public Task PressEnterAsync(CancellationToken cancellationToken = default) =>
            _locator.PressAsync("Enter");

        public async Task FillAsync(
            string value,
            CancellationToken cancellationToken = default)
        {
            var input = await RequireTargetAsync("input:not([type='hidden']), textarea, [contenteditable='true']");
            await input.FillAsync(value);
        }

        public async Task SelectAsync(
            string value,
            CancellationToken cancellationToken = default)
        {
            var select = await RequireTargetAsync("select");
            await select.SelectOptionAsync(value);
        }

        public async Task SelectByLabelAsync(
            string label,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var isNative = await _locator.EvaluateAsync<bool>(
                "element => element.matches('select') || element.querySelector('select') !== null");
            if (isNative)
            {
                var select = await RequireTargetAsync("select");
                await select.SelectOptionAsync(new SelectOptionValue { Label = label });
                return;
            }

            var trigger = await RequireTargetAsync("mat-select, [role='combobox']");
            await trigger.ClickAsync();
            await Assertions.Expect(trigger).ToHaveAttributeAsync("aria-controls", new Regex(@"\S+"));
            var panelId = await trigger.GetAttributeAsync("aria-controls");
            if (string.IsNullOrWhiteSpace(panelId) || panelId.Any(char.IsWhiteSpace))
                throw new ControlResolutionException("A dropdown must identify one exact panel in its resolved frame.");
            var panel = _frame.Locator($"[id=\"{PlaywrightControlScope.EscapeCssAttributeValue(panelId)}\"]");
            await Assertions.Expect(panel).ToHaveCountAsync(1);
            await Assertions.Expect(panel).ToBeVisibleAsync();
            var option = panel.GetByRole(AriaRole.Option, new() { Name = label, Exact = true });
            await Assertions.Expect(option).ToHaveCountAsync(1);
            await option.ClickAsync();
            await Assertions.Expect(panel).ToBeHiddenAsync();
        }

        public async Task SetCheckedAsync(
            bool value,
            CancellationToken cancellationToken = default)
        {
            var input = await RequireTargetAsync("input[type='checkbox'], input[type='radio']");
            await input.SetCheckedAsync(value);
        }

        public async Task<bool> IsCheckedAsync(CancellationToken cancellationToken = default)
        {
            var input = await RequireTargetAsync("input[type='checkbox'], input[type='radio']");
            return await input.IsCheckedAsync();
        }

        public async Task<bool> IsEnabledAsync(CancellationToken cancellationToken = default)
        {
            const string selector = "input:not([type='hidden']), textarea, select, button, mat-select, [role='combobox']";
            if (await _locator.EvaluateAsync<bool>("(element, selector) => element.matches(selector)", selector))
                return await _locator.IsEnabledAsync();
            var nested = _locator.Locator(selector);
            var count = await nested.CountAsync();
            if (count > 1)
                throw new ControlResolutionException("Enabled state has multiple nested controls.");
            return await (count == 1 ? nested : _locator).IsEnabledAsync();
        }

        public Task<bool> IsVisibleAsync(CancellationToken cancellationToken = default) =>
            _locator.IsVisibleAsync();

        public Task<bool> IsSelectedAsync(CancellationToken cancellationToken = default) =>
            _locator.EvaluateAsync<bool>(
                """
                element => {
                    const nested = element.querySelectorAll('input[type="checkbox"], input[type="radio"], option');
                    if (nested.length > 1) throw new Error('Selected state has multiple nested controls.');
                    const candidate = nested[0] || element;
                    if (candidate.matches('input[type="checkbox"], input[type="radio"]')) return candidate.checked;
                    if (candidate.matches('option')) return candidate.selected;
                    for (const attribute of ['aria-selected', 'aria-pressed', 'aria-checked']) {
                        const value = element.getAttribute(attribute);
                        if (value === 'true' || value === 'false') return value === 'true';
                        if (value !== null) throw new Error('Selected state must expose a Boolean value.');
                    }
                    if (element.matches('mat-button-toggle, .mat-button-toggle, .mat-mdc-button-toggle'))
                        return element.classList.contains('mat-button-toggle-checked') ||
                            element.classList.contains('mat-mdc-button-toggle-checked');
                    if (element.matches('.chip-wrapper, .chip-wrapper-selected'))
                        return element.classList.contains('chip-wrapper-selected');
                    if (element.matches('.chip-label')) {
                        const chip = element.closest('.chip-wrapper, .chip-wrapper-selected');
                        if (!chip) throw new Error('Chip label has no owning selected-state control.');
                        return chip.classList.contains('chip-wrapper-selected');
                    }
                    if (element.matches('.chip-item-wrapper')) {
                        const chips = element.querySelectorAll('.chip-wrapper, .chip-wrapper-selected');
                        if (chips.length !== 1) throw new Error('Chip selected state is absent or ambiguous.');
                        return chips[0].classList.contains('chip-wrapper-selected');
                    }
                    throw new Error('This control does not expose selected state.');
                }
                """);

        public Task<string> GetValueAsync(CancellationToken cancellationToken = default) =>
            _locator.EvaluateAsync<string>(
                """
                element => {
                    const nested = element.querySelectorAll('input:not([type="hidden"]), textarea, select');
                    if (nested.length > 1) throw new Error('Value capture has multiple nested controls.');
                    const candidate = nested[0] || element;
                    if ('value' in candidate) return String(candidate.value ?? '');
                    if (candidate.isContentEditable) return candidate.textContent;
                    if (candidate.hasAttribute('value')) return candidate.getAttribute('value');
                    throw new Error('This control has no value; use typed text capture for displayed content.');
                }
                """);

        public async Task<string> GetSelectedValueAsync(CancellationToken cancellationToken = default)
        {
            var select = await RequireTargetAsync("select");
            return await select.EvaluateAsync<string>(
                """
                element => {
                    if (element.selectedOptions.length !== 1) throw new Error('Expected one selected option.');
                    return element.value;
                }
                """);
        }

        public Task<string> GetSelectedTextAsync(CancellationToken cancellationToken = default) =>
            _locator.EvaluateAsync<string>(
                """
                element => {
                    const selects = element.matches('select') ? [element] : element.querySelectorAll('select');
                    if (selects.length > 1) throw new Error('Selected text has multiple nested controls.');
                    const select = selects[0];
                    if (select) {
                        if (select.selectedOptions.length !== 1) throw new Error('Expected one selected option.');
                        return select.selectedOptions[0].label.trim();
                    }
                    const values = element.querySelectorAll('.mat-select-value-text, .mat-mdc-select-value-text');
                    if (values.length !== 1) throw new Error('Dropdown selected text is absent or ambiguous.');
                    return values[0].textContent.trim();
                }
                """);

        public async Task<string> GetTextAsync(CancellationToken cancellationToken = default) =>
            (await _locator.InnerTextAsync()).Trim();

        private async Task<ILocator> RequireTargetAsync(string selector)
        {
            if (await _locator.EvaluateAsync<bool>("(element, selector) => element.matches(selector)", selector))
                return _locator;
            var nested = _locator.Locator(selector);
            await Assertions.Expect(nested).ToHaveCountAsync(1);
            return nested;
        }
    }
}
