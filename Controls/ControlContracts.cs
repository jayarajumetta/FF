#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PnCTestAutomation.Controls
{
    public enum ControlSelectorKind
    {
        TestId,
        AniHtmlId
    }

    public sealed record ControlSelector(
        ControlSelectorKind Kind,
        string Value,
        string? ExceptionReference = null,
        string? ExactText = null)
    {
        public static ControlSelector ByTestId(
            string testId,
            string? exactText = null)
        {
            RequireValue(testId, nameof(testId));
            if (exactText != null)
                RequireValue(exactText, nameof(exactText));
            return new ControlSelector(
                ControlSelectorKind.TestId,
                testId,
                ExactText: exactText);
        }

        public static ControlSelector ByDocumentedAniId(
            string id,
            string exceptionReference,
            string? exactText = null)
        {
            RequireValue(id, nameof(id));
            RequireValue(exceptionReference, nameof(exceptionReference));
            if (exactText != null)
                RequireValue(exactText, nameof(exactText));
            return new ControlSelector(
                ControlSelectorKind.AniHtmlId,
                id,
                exceptionReference,
                exactText);
        }

        private static void RequireValue(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "A non-empty value is required.",
                    parameterName);
            }
        }
    }

    public sealed class ControlDefinition
    {
        public ControlDefinition(string name, params ControlSelector[] selectors)
            : this(name, null, selectors)
        {
        }

        private ControlDefinition(
            string name,
            string? requiredScopeId,
            params ControlSelector[] selectors)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("A control name is required.", nameof(name));
            if (selectors == null || selectors.Length == 0)
                throw new ArgumentException("At least one selector is required.", nameof(selectors));
            if (selectors[0].Kind != ControlSelectorKind.TestId)
            {
                throw new ArgumentException(
                    "Control selector priority must start with GetByTestId.",
                    nameof(selectors));
            }
            if (Array.Exists(
                    selectors,
                    selector =>
                        selector.Kind == ControlSelectorKind.AniHtmlId &&
                        string.IsNullOrWhiteSpace(selector.ExceptionReference)))
            {
                throw new ArgumentException(
                    "Every ANi HTML id fallback requires a documentation reference.",
                    nameof(selectors));
            }

            Name = name;
            RequiredScopeId = requiredScopeId;
            Selectors = Array.AsReadOnly((ControlSelector[])selectors.Clone());
        }

        public string Name { get; }
        public string? RequiredScopeId { get; }
        public IReadOnlyList<ControlSelector> Selectors { get; }

        public ControlDefinition InScope(string scopeId)
        {
            if (string.IsNullOrWhiteSpace(scopeId))
                throw new ArgumentException(
                    "A scope ID is required.",
                    nameof(scopeId));
            return new ControlDefinition(
                Name,
                scopeId.Trim(),
                Selectors.ToArray());
        }

        public static ControlDefinition ByTestId(string name, string testId) =>
            new(name, ControlSelector.ByTestId(testId));

        public static ControlDefinition ByTestIdWithExactText(
            string name,
            string testId,
            string exactText) =>
            new(name, ControlSelector.ByTestId(testId, exactText));

        public static ControlDefinition WithDocumentedAniIdFallback(
            string name,
            string testId,
            string htmlId,
            string exceptionReference,
            string? exactText = null) =>
            new(
                name,
                ControlSelector.ByTestId(testId, exactText),
                ControlSelector.ByDocumentedAniId(
                    htmlId,
                    exceptionReference,
                    exactText));
    }

    public sealed record ControlScope(
        string Description,
        int PageIndex,
        int FrameDepth,
        bool IsMainFrame,
        string RuntimeIdentity = "",
        string? ContractId = null);

    public interface IControlElement
    {
        Task ScrollIntoViewAsync(CancellationToken cancellationToken = default);
        Task ClickAsync(CancellationToken cancellationToken = default);
        Task PressEnterAsync(CancellationToken cancellationToken = default);
        Task FillAsync(string value, CancellationToken cancellationToken = default);
        Task SelectAsync(string value, CancellationToken cancellationToken = default);
        Task SetCheckedAsync(bool value, CancellationToken cancellationToken = default);
        Task<bool> IsCheckedAsync(CancellationToken cancellationToken = default);
        Task<bool> IsEnabledAsync(CancellationToken cancellationToken = default);
        Task<bool> IsVisibleAsync(CancellationToken cancellationToken = default);
        Task<bool> IsSelectedAsync(CancellationToken cancellationToken = default);
        Task<string> GetValueAsync(CancellationToken cancellationToken = default);
        Task<string> GetSelectedValueAsync(CancellationToken cancellationToken = default);
    }

    public interface IControlScopeAdapter
    {
        ControlScope Scope { get; }
        Task<IReadOnlyList<IControlElement>> FindVisibleAsync(
            ControlSelector selector,
            CancellationToken cancellationToken = default);
    }

    public interface IControlRuntime
    {
        Task<IReadOnlyList<IControlScopeAdapter>> GetScopesAsync(
            CancellationToken cancellationToken = default);
    }

    public sealed record ResolvedControl(
        ControlDefinition Definition,
        ControlSelector Selector,
        ControlScope Scope,
        IControlElement Element);

    public interface IControlScopeResolver
    {
        Task<ResolvedControl> ResolveAsync(
            ControlDefinition definition,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default);

        Task<ResolvedControl?> TryResolveAsync(
            ControlDefinition definition,
            TimeSpan? timeout = null,
            CancellationToken cancellationToken = default);
    }

    public class ControlResolutionException : Exception
    {
        public ControlResolutionException(string message)
            : base(message)
        {
        }
    }

    public sealed class ControlNotFoundException : ControlResolutionException
    {
        public ControlNotFoundException(string message)
            : base(message)
        {
        }
    }

    public sealed class AmbiguousControlMatchException : ControlResolutionException
    {
        public AmbiguousControlMatchException(string message)
            : base(message)
        {
        }
    }

    public enum ControlAssertion
    {
        Value,
        SelectedValue,
        Checked,
        Selected,
        Enabled,
        Visible
    }

    public sealed record ControlExpectation(
        ControlAssertion Assertion,
        string ExpectedValue)
    {
        public static ControlExpectation Value(string expected) =>
            new(ControlAssertion.Value, expected);

        public static ControlExpectation SelectedValue(string expected) =>
            new(ControlAssertion.SelectedValue, expected);

        public static ControlExpectation Checked(bool expected) =>
            new(ControlAssertion.Checked, expected.ToString());

        public static ControlExpectation Selected(bool expected = true) =>
            new(ControlAssertion.Selected, expected.ToString());

        public static ControlExpectation Enabled(bool expected = true) =>
            new(ControlAssertion.Enabled, expected.ToString());

        public static ControlExpectation Visible(bool expected = true) =>
            new(ControlAssertion.Visible, expected.ToString());
    }

    public sealed record ControlEvidence(
        string ControlName,
        ControlSelector Selector,
        ControlScope Scope,
        string Operation,
        ControlAssertion Assertion);

    public interface IControlEvidenceSink
    {
        Task RecordAsync(
            ControlEvidence evidence,
            CancellationToken cancellationToken = default);
    }

    public interface ISemanticControlActions
    {
        Task ActivateAsync(
            ResolvedControl control,
            ControlExpectation? postcondition = null,
            CancellationToken cancellationToken = default);

        Task ClickAsync(
            ResolvedControl control,
            ControlExpectation? postcondition = null,
            CancellationToken cancellationToken = default);

        Task FillAsync(
            ResolvedControl control,
            string value,
            CancellationToken cancellationToken = default);

        Task SelectAsync(
            ResolvedControl control,
            string value,
            CancellationToken cancellationToken = default);

        Task ToggleAsync(
            ResolvedControl control,
            bool isChecked,
            CancellationToken cancellationToken = default);

        Task AssertAsync(
            ResolvedControl control,
            ControlExpectation expectation,
            CancellationToken cancellationToken = default);
    }

    public sealed class ControlPostconditionException : Exception
    {
        public ControlPostconditionException(string message)
            : base(message)
        {
        }
    }
}
