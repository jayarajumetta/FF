#nullable enable
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PnCTestAutomation.Controls
{
    public sealed class SemanticControlActions : ISemanticControlActions
    {
        private readonly IControlEvidenceSink _evidenceSink;
        private readonly TimeSpan _assertionTimeout;
        private readonly TimeSpan _pollInterval;

        public SemanticControlActions(
            IControlEvidenceSink? evidenceSink = null,
            TimeSpan? assertionTimeout = null,
            TimeSpan? pollInterval = null)
        {
            _evidenceSink = evidenceSink ?? DiagnosticControlEvidenceSink.Instance;
            _assertionTimeout = assertionTimeout ?? TimeSpan.FromSeconds(5);
            _pollInterval = pollInterval ?? TimeSpan.FromMilliseconds(100);
            if (_assertionTimeout < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(assertionTimeout));
            if (_pollInterval <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(pollInterval));
        }

        public Task ClickAsync(
            ResolvedControl control,
            ControlExpectation? postcondition = null,
            CancellationToken cancellationToken = default) =>
            PerformActivationAsync(
                control, () => control.Element.ClickAsync(cancellationToken),
                "click", postcondition, cancellationToken);

        public Task ActivateAsync(
            ResolvedControl control,
            ControlExpectation? postcondition = null,
            CancellationToken cancellationToken = default) =>
            PerformActivationAsync(
                control, () => control.Element.PressEnterAsync(cancellationToken),
                "keyboard-activate", postcondition, cancellationToken);

        private async Task PerformActivationAsync(
            ResolvedControl control,
            Func<Task> activate,
            string operation,
            ControlExpectation? postcondition,
            CancellationToken cancellationToken)
        {
            await WaitForExpectedStateAsync(
                control,
                ControlExpectation.Enabled(),
                cancellationToken);
            await control.Element.ScrollIntoViewAsync(cancellationToken);
            await activate();

            if (postcondition != null)
                await WaitForExpectedStateAsync(control, postcondition, cancellationToken);

            var verified = postcondition ?? ControlExpectation.Enabled();
            await RecordAsync(control, operation, verified.Assertion, cancellationToken);
        }

        public async Task FillAsync(
            ResolvedControl control,
            string value,
            CancellationToken cancellationToken = default)
        {
            await WaitForExpectedStateAsync(
                control,
                ControlExpectation.Enabled(),
                cancellationToken);
            await control.Element.FillAsync(value, cancellationToken);
            await AssertAndRecordAsync(
                control,
                "fill",
                ControlExpectation.Value(value),
                cancellationToken);
        }

        public async Task SelectAsync(
            ResolvedControl control,
            string value,
            CancellationToken cancellationToken = default)
        {
            await WaitForExpectedStateAsync(
                control,
                ControlExpectation.Enabled(),
                cancellationToken);
            await control.Element.SelectAsync(value, cancellationToken);
            await AssertAndRecordAsync(
                control,
                "select",
                ControlExpectation.SelectedValue(value),
                cancellationToken);
        }

        public async Task ToggleAsync(
            ResolvedControl control,
            bool isChecked,
            CancellationToken cancellationToken = default)
        {
            await WaitForExpectedStateAsync(
                control,
                ControlExpectation.Enabled(),
                cancellationToken);
            await control.Element.SetCheckedAsync(isChecked, cancellationToken);
            await AssertAndRecordAsync(
                control,
                "toggle",
                ControlExpectation.Checked(isChecked),
                cancellationToken);
        }

        public Task AssertAsync(
            ResolvedControl control,
            ControlExpectation expectation,
            CancellationToken cancellationToken = default) =>
            AssertAndRecordAsync(control, "assert", expectation, cancellationToken);

        private async Task AssertAndRecordAsync(
            ResolvedControl control,
            string operation,
            ControlExpectation expectation,
            CancellationToken cancellationToken)
        {
            await WaitForExpectedStateAsync(control, expectation, cancellationToken);
            await RecordAsync(
                control,
                operation,
                expectation.Assertion,
                cancellationToken);
        }

        private async Task WaitForExpectedStateAsync(
            ResolvedControl control,
            ControlExpectation expectation,
            CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            do
            {
                if (await MatchesAsync(control.Element, expectation, cancellationToken))
                    return;

                if (stopwatch.Elapsed >= _assertionTimeout)
                {
                    throw new ControlPostconditionException(
                        $"Control '{control.Definition.Name}' in {control.Scope.Description} " +
                        $"did not satisfy the {expectation.Assertion} postcondition.");
                }

                await Task.Delay(_pollInterval, cancellationToken);
            }
            while (true);
        }

        private static async Task<bool> MatchesAsync(
            IControlElement element,
            ControlExpectation expectation,
            CancellationToken cancellationToken) =>
            expectation.Assertion switch
            {
                ControlAssertion.Value =>
                    string.Equals(
                        await element.GetValueAsync(cancellationToken),
                        expectation.ExpectedValue,
                        StringComparison.Ordinal),
                ControlAssertion.SelectedValue =>
                    string.Equals(
                        await element.GetSelectedValueAsync(cancellationToken),
                        expectation.ExpectedValue,
                        StringComparison.Ordinal),
                ControlAssertion.Checked =>
                    await element.IsCheckedAsync(cancellationToken) ==
                    bool.Parse(expectation.ExpectedValue),
                ControlAssertion.Selected =>
                    await element.IsSelectedAsync(cancellationToken) ==
                    bool.Parse(expectation.ExpectedValue),
                ControlAssertion.Enabled =>
                    await element.IsEnabledAsync(cancellationToken) ==
                    bool.Parse(expectation.ExpectedValue),
                ControlAssertion.Visible =>
                    await element.IsVisibleAsync(cancellationToken) ==
                    bool.Parse(expectation.ExpectedValue),
                _ => throw new ArgumentOutOfRangeException(nameof(expectation))
            };

        private Task RecordAsync(
            ResolvedControl control,
            string operation,
            ControlAssertion assertion,
            CancellationToken cancellationToken) =>
            _evidenceSink.RecordAsync(
                new ControlEvidence(
                    control.Definition.Name,
                    control.Selector,
                    control.Scope,
                    operation,
                    assertion),
                cancellationToken);

        private sealed class DiagnosticControlEvidenceSink : IControlEvidenceSink
        {
            public static DiagnosticControlEvidenceSink Instance { get; } = new();

            public Task RecordAsync(
                ControlEvidence evidence,
                CancellationToken cancellationToken = default)
            {
                Console.WriteLine(
                    $"[Control] {evidence.Operation} '{evidence.ControlName}' via " +
                    $"{evidence.Selector.Kind} in {evidence.Scope.Description}; " +
                    $"{evidence.Assertion} verified.");
                return Task.CompletedTask;
            }
        }
    }
}
