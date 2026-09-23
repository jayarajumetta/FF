#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PnCTestAutomation.Controls
{
    public sealed class ControlScopeResolver : IControlScopeResolver
    {
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan PollInterval = TimeSpan.FromMilliseconds(100);
        private readonly IControlRuntime _runtime;

        public ControlScopeResolver(IControlRuntime runtime)
        {
            _runtime = runtime;
        }

        public async Task<ResolvedControl> ResolveAsync(
            ControlDefinition definition,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default) =>
            await TryResolveAsync(definition, timeout, cancellationToken)
            ?? throw new ControlNotFoundException(
                $"Required control '{definition.Name}' was not found using: " +
                string.Join(", ", definition.Selectors.Select(DescribeSelector)) +
                (definition.RequiredScopeId == null
                    ? ""
                    : $" in required frame scope '{definition.RequiredScopeId}'"));

        public async Task<ResolvedControl?> TryResolveAsync(
            ControlDefinition definition,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default)
        {
            var wait = timeout ?? DefaultTimeout;
            if (wait < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(timeout));

            var stopwatch = Stopwatch.StartNew();
            do
            {
                var scopes = await _runtime.GetScopesAsync(cancellationToken);
                var eligibleScopes = definition.RequiredScopeId == null
                    ? scopes
                    : scopes.Where(scope =>
                        string.Equals(
                            scope.Scope.ContractId,
                            definition.RequiredScopeId,
                            StringComparison.Ordinal)).ToArray();
                if (definition.RequiredScopeId != null &&
                    eligibleScopes.Count() > 1)
                {
                    throw new AmbiguousControlMatchException(
                        $"Required frame scope '{definition.RequiredScopeId}' " +
                        $"matched {eligibleScopes.Count()} runtime frames.");
                }
                foreach (var selector in definition.Selectors)
                {
                    var matches = new List<ResolvedControl>();
                    foreach (var scope in eligibleScopes)
                    {
                        var elements = await scope.FindVisibleAsync(
                            selector,
                            cancellationToken);
                        matches.AddRange(elements.Select(element =>
                            new ResolvedControl(
                                definition,
                                selector,
                                scope.Scope,
                                element)));
                    }

                    if (matches.Count > 1)
                    {
                        var matchedScopes = string.Join(
                            " | ",
                            matches.Select(match => match.Scope.Description));
                        throw new AmbiguousControlMatchException(
                            $"Control '{definition.Name}' matched {matches.Count} visible elements " +
                            $"for {DescribeSelector(selector)} across: {matchedScopes}.");
                    }

                    if (matches.Count == 1)
                        return matches[0];
                }

                if (stopwatch.Elapsed >= wait)
                    return null;

                var remaining = wait - stopwatch.Elapsed;
                await Task.Delay(
                    remaining < PollInterval ? remaining : PollInterval,
                    cancellationToken);
            }
            while (true);
        }

        private static string DescribeSelector(ControlSelector selector) =>
            (selector.Kind == ControlSelectorKind.TestId
                ? $"GetByTestId('{selector.Value}')"
                : $"documented ANi id '#{selector.Value}' ({selector.ExceptionReference})") +
            (selector.ExactText == null
                ? ""
                : $" with exact text '{selector.ExactText}'") +
            (selector.ElementTag == null ? "" : $" on element <{selector.ElementTag}>");
    }
}
