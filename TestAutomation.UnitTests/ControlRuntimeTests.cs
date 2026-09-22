using NUnit.Framework;
using PnCTestAutomation.Controls;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
public class ControlRuntimeTests
{
    [Test]
    public async Task ResolvesAVisibleControlInTheMainPage()
    {
        var element = new FakeControlElement();
        var mainScope = FakeScope.MainPage().WithTestId("policy.number", element);
        var resolver = new ControlScopeResolver(new FakeRuntime(mainScope));

        var resolved = await resolver.ResolveAsync(
            ControlDefinition.ByTestId("Policy Number", "policy.number"),
            TimeSpan.Zero);

        Assert.Multiple(() =>
        {
            Assert.That(resolved.Element, Is.SameAs(element));
            Assert.That(resolved.Scope.IsMainFrame, Is.True);
            Assert.That(resolved.Scope.FrameDepth, Is.Zero);
        });
    }

    [Test]
    public async Task ResolvesAControlInsideANestedFrame()
    {
        var element = new FakeControlElement();
        var mainScope = FakeScope.MainPage();
        var nestedScope = FakeScope.Frame("page 1 frame 'nested' depth 2", depth: 2)
            .WithTestId("policy.consent", element);
        var resolver = new ControlScopeResolver(
            new FakeRuntime(mainScope, nestedScope));

        var resolved = await resolver.ResolveAsync(
            ControlDefinition.ByTestId("Consent", "policy.consent"),
            TimeSpan.Zero);

        Assert.Multiple(() =>
        {
            Assert.That(resolved.Element, Is.SameAs(element));
            Assert.That(resolved.Scope.Description, Does.Contain("nested"));
            Assert.That(resolved.Scope.FrameDepth, Is.EqualTo(2));
            Assert.That(resolved.Scope.IsMainFrame, Is.False);
        });
    }

    [Test]
    public async Task RequiredFrameScopeIsExactAndPreserved()
    {
        var element = new FakeControlElement();
        var main = FakeScope.MainPage()
            .WithTestId("policy.state", new FakeControlElement());
        var nested = FakeScope.Frame(
                "page 1 frame 'policy-editor' depth 2",
                depth: 2,
                contractId: "cldc-policy")
            .WithTestId("policy.state", element);
        var definition = ControlDefinition
            .ByTestId("Primary state", "policy.state")
            .InScope("cldc-policy");

        var resolved = await new ControlScopeResolver(
                new FakeRuntime(main, nested))
            .ResolveAsync(definition, TimeSpan.Zero);

        Assert.Multiple(() =>
        {
            Assert.That(resolved.Element, Is.SameAs(element));
            Assert.That(
                resolved.Scope.ContractId,
                Is.EqualTo("cldc-policy"));
            Assert.That(resolved.Scope.FrameDepth, Is.EqualTo(2));
        });
    }

    [Test]
    public void RequiredFrameScopeNeverFallsBackToTopDocument()
    {
        var main = FakeScope.MainPage()
            .WithTestId("policy.state", new FakeControlElement());
        var definition = ControlDefinition
            .ByTestId("Primary state", "policy.state")
            .InScope("cldc-policy");

        var exception = Assert.ThrowsAsync<ControlNotFoundException>(
            async () => await new ControlScopeResolver(
                    new FakeRuntime(main))
                .ResolveAsync(definition, TimeSpan.Zero));

        Assert.That(
            exception!.Message,
            Does.Contain("required frame scope 'cldc-policy'"));
    }

    [Test]
    public void MultipleRuntimeFramesForRequiredScopeFailBeforeControlLookup()
    {
        var first = FakeScope.Frame(
            "page 1 frame 'policy' depth 1",
            contractId: "cldc-policy");
        var second = FakeScope.Frame(
            "page 1 frame 'policy' depth 1 duplicate",
            contractId: "cldc-policy");
        var definition = ControlDefinition
            .ByTestId("Primary state", "policy.state")
            .InScope("cldc-policy");

        var exception = Assert.ThrowsAsync<AmbiguousControlMatchException>(
            async () => await new ControlScopeResolver(
                    new FakeRuntime(first, second))
                .ResolveAsync(definition, TimeSpan.Zero));

        Assert.That(
            exception!.Message,
            Does.Contain("matched 2 runtime frames"));
    }

    [Test]
    public async Task ResolvedFrameScopeIsPreservedForActionAssertionAndEvidence()
    {
        var element = new FakeControlElement();
        var frameScope = FakeScope.Frame("page 2 frame 'score' depth 1", depth: 1)
            .WithTestId("score.name", element);
        var evidence = new RecordingEvidenceSink();
        var actions = ImmediateActions(evidence);
        var resolved = await new ControlScopeResolver(new FakeRuntime(frameScope))
            .ResolveAsync(
                ControlDefinition.ByTestId("Score Name", "score.name"),
                TimeSpan.Zero);

        await actions.FillAsync(resolved, "Expected value");

        Assert.Multiple(() =>
        {
            Assert.That(element.Value, Is.EqualTo("Expected value"));
            Assert.That(element.Calls, Is.EqualTo(new[] { "fill" }));
            Assert.That(evidence.Items, Has.Count.EqualTo(1));
            Assert.That(evidence.Items[0].Scope, Is.SameAs(resolved.Scope));
            Assert.That(evidence.Items[0].Assertion, Is.EqualTo(ControlAssertion.Value));
        });
    }

    [Test]
    public void MultipleVisibleFrameMatchesFailAsAmbiguous()
    {
        var firstFrame = FakeScope.Frame("page 1 frame 'first' depth 1")
            .WithTestId("score.accept", new FakeControlElement());
        var secondFrame = FakeScope.Frame("page 1 frame 'second' depth 1")
            .WithTestId("score.accept", new FakeControlElement());
        var resolver = new ControlScopeResolver(
            new FakeRuntime(firstFrame, secondFrame));

        var exception = Assert.ThrowsAsync<AmbiguousControlMatchException>(
            async () => await resolver.ResolveAsync(
                ControlDefinition.ByTestId("Accept", "score.accept"),
                TimeSpan.Zero));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Does.Contain("matched 2 visible elements"));
            Assert.That(exception.Message, Does.Contain("first"));
            Assert.That(exception.Message, Does.Contain("second"));
        });
    }

    [Test]
    public void MissingRequiredControlFailsWithAttemptedSelectors()
    {
        var definition = ControlDefinition.WithDocumentedAniIdFallback(
            "Accept",
            "score.accept",
            "score-accept",
            "ANI-ID-001");
        var resolver = new ControlScopeResolver(new FakeRuntime(FakeScope.MainPage()));

        var exception = Assert.ThrowsAsync<ControlNotFoundException>(
            async () => await resolver.ResolveAsync(definition, TimeSpan.Zero));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Message, Does.Contain("Required control 'Accept'"));
            Assert.That(exception.Message, Does.Contain("GetByTestId('score.accept')"));
            Assert.That(exception.Message, Does.Contain("documented ANi id '#score-accept' (ANI-ID-001)"));
        });
    }

    [Test]
    public async Task TestIdWinsBeforeDocumentedAniIdFallback()
    {
        var testIdElement = new FakeControlElement();
        var idElement = new FakeControlElement();
        var scope = FakeScope.MainPage()
            .WithTestId("score.accept", testIdElement)
            .WithAniId("score-accept", idElement);
        var resolver = new ControlScopeResolver(new FakeRuntime(scope));
        var definition = ControlDefinition.WithDocumentedAniIdFallback(
            "Accept",
            "score.accept",
            "score-accept",
            "ANI-ID-001");

        var resolved = await resolver.ResolveAsync(definition, TimeSpan.Zero);

        Assert.Multiple(() =>
        {
            Assert.That(resolved.Element, Is.SameAs(testIdElement));
            Assert.That(resolved.Selector.Kind, Is.EqualTo(ControlSelectorKind.TestId));
        });
    }

    [Test]
    public async Task AniIdFallbackRequiresDocumentationAndIsUsedOnlyAfterTestIdMisses()
    {
        Assert.That(
            () => new ControlDefinition(
                "Accept",
                ControlSelector.ByTestId("score.accept"),
                new ControlSelector(ControlSelectorKind.AniHtmlId, "score-accept")),
            Throws.ArgumentException.With.Message.Contains("documentation reference"));

        var idElement = new FakeControlElement();
        var resolver = new ControlScopeResolver(
            new FakeRuntime(FakeScope.MainPage().WithAniId("score-accept", idElement)));
        var definition = ControlDefinition.WithDocumentedAniIdFallback(
            "Accept",
            "score.accept",
            "score-accept",
            "ANI-ID-001");

        var resolved = await resolver.ResolveAsync(definition, TimeSpan.Zero);

        Assert.Multiple(() =>
        {
            Assert.That(resolved.Element, Is.SameAs(idElement));
            Assert.That(resolved.Selector.Kind, Is.EqualTo(ControlSelectorKind.AniHtmlId));
            Assert.That(
                resolved.Selector.ExceptionReference,
                Is.EqualTo("ANI-ID-001"));
            Assert.That(
                File.ReadAllText(
                    Path.Combine(FindRepositoryRoot(), "Docs", "Locator-Audit.md")),
                Does.Contain("ANI-ID-001"));
        });
    }

    [Test]
    public void LocatorRescueHasNoAutoHealSwitch()
    {
        Assert.That(
            typeof(LocatorRescueOptions).GetProperty("AutoHeal"),
            Is.Null,
            "Locator rescue must remain diagnostic-only.");
    }

    [Test]
    public async Task SemanticOperationsVerifyValueSelectedCheckedAndEnabledState()
    {
        var evidence = new RecordingEvidenceSink();
        var actions = ImmediateActions(evidence);
        var element = new FakeControlElement();
        var control = Resolved(element);

        await actions.FillAsync(control, "entered");
        await actions.SelectAsync(control, "chosen");
        await actions.ToggleAsync(control, true);
        await actions.ClickAsync(control, ControlExpectation.Selected());
        await actions.AssertAsync(control, ControlExpectation.Enabled());

        Assert.Multiple(() =>
        {
            Assert.That(
                element.Calls,
                Is.EqualTo(new[] { "fill", "select", "toggle:True", "click" }));
            Assert.That(element.Value, Is.EqualTo("entered"));
            Assert.That(element.SelectedValue, Is.EqualTo("chosen"));
            Assert.That(element.Checked, Is.True);
            Assert.That(element.Selected, Is.True);
            Assert.That(
                evidence.Items.Select(item => item.Assertion),
                Is.EqualTo(new[]
                {
                    ControlAssertion.Value,
                    ControlAssertion.SelectedValue,
                    ControlAssertion.Checked,
                    ControlAssertion.Selected,
                    ControlAssertion.Enabled
                }));
        });
    }

    [Test]
    public void VisibilityAloneCannotSatisfyASelectedPostcondition()
    {
        var element = new FakeControlElement
        {
            SelectOnClick = false,
            Selected = false
        };
        var actions = ImmediateActions();

        var exception = Assert.ThrowsAsync<ControlPostconditionException>(
            async () => await actions.ClickAsync(
                Resolved(element),
                ControlExpectation.Selected()));

        Assert.That(exception!.Message, Does.Contain("Selected postcondition"));
    }

    [Test]
    public async Task KeyboardActivationUsesOneNativeKeyAndPreservesScope()
    {
        var element = new FakeControlElement();
        var control = Resolved(element);
        var evidence = new RecordingEvidenceSink();

        await ImmediateActions(evidence).ActivateAsync(control);

        Assert.Multiple(() =>
        {
            Assert.That(element.Calls, Is.EqualTo(new[] { "enter" }));
            Assert.That(evidence.Items.Single().Operation, Is.EqualTo("keyboard-activate"));
            Assert.That(evidence.Items.Single().Scope, Is.SameAs(control.Scope));
        });
    }

    [Test]
    public void KeyboardActivationRejectsDisabledControlsWithoutSendingAKey()
    {
        var element = new FakeControlElement { Enabled = false };
        Assert.ThrowsAsync<ControlPostconditionException>(async () =>
            await ImmediateActions().ActivateAsync(Resolved(element)));
        Assert.That(element.Calls, Is.Empty);
    }

    [Test]
    public async Task ModalActionCompletionRequiresDisappearanceNotSelection()
    {
        var element = new FakeControlElement
        {
            SelectOnClick = false,
            HideOnClick = true
        };
        var control = Resolved(element);
        var evidence = new RecordingEvidenceSink();

        await ImmediateActions(evidence).ClickAsync(
            control, ControlExpectation.Visible(false));

        Assert.Multiple(() =>
        {
            Assert.That(element.Calls, Is.EqualTo(new[] { "click" }));
            Assert.That(element.Selected, Is.False);
            Assert.That(evidence.Items.Single().Scope, Is.SameAs(control.Scope));
            Assert.That(evidence.Items.Single().Assertion, Is.EqualTo(ControlAssertion.Visible));
        });
    }

    [Test]
    public void VisibleUnchangedModalFailsWithoutReplayingItsAction()
    {
        var element = new FakeControlElement { SelectOnClick = false };

        Assert.ThrowsAsync<ControlPostconditionException>(async () =>
            await ImmediateActions().ClickAsync(
                Resolved(element), ControlExpectation.Visible(false)));
        Assert.That(element.Calls, Is.EqualTo(new[] { "click" }));
    }

    [Test]
    public async Task CaptureDistinguishesSelectedCheckedEnabledAndTextWithoutLoggingValues()
    {
        var element = new FakeControlElement
        {
            Value = "sensitive-value",
            SelectedValue = "AL",
            SelectedText = "Alabama",
            Text = "Policy",
            Checked = false,
            Enabled = false,
            Selected = true
        };
        var evidence = new RecordingEvidenceSink();
        var actions = ImmediateActions(evidence);
        var control = Resolved(element);

        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.Value), Is.EqualTo(element.Value));
        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.SelectedValue), Is.EqualTo("AL"));
        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.SelectedText), Is.EqualTo("Alabama"));
        Assert.That(await actions.CaptureStateAsync(control, ControlStateCapture.Checked), Is.False);
        Assert.That(await actions.CaptureStateAsync(control, ControlStateCapture.Enabled), Is.False);
        Assert.That(await actions.CaptureStateAsync(control, ControlStateCapture.Selected), Is.True);
        await actions.AssertAsync(control, ControlExpectation.Text("Policy"));
        Assert.That(evidence.Items.All(item => ReferenceEquals(item.Scope, control.Scope)), Is.True);
        Assert.That(evidence.Items.Select(item => item.Operation), Does.Contain("capture"));
        Assert.That(System.Text.Json.JsonSerializer.Serialize(evidence.Items),
            Does.Not.Contain(element.Value));
    }

    [Test]
    public void VisibleTextIsNotAutomaticallyEqual()
    {
        var actions = ImmediateActions();
        var control = Resolved(new FakeControlElement { Text = "Unexpected" });
        Assert.That(async () => await actions.AssertAsync(control, ControlExpectation.Text("Expected")),
            Throws.TypeOf<ControlPostconditionException>());
    }

    private static SemanticControlActions ImmediateActions(
        IControlEvidenceSink? evidenceSink = null) =>
        new(
            evidenceSink,
            assertionTimeout: TimeSpan.Zero,
            pollInterval: TimeSpan.FromMilliseconds(1));

    private static ResolvedControl Resolved(FakeControlElement element)
    {
        var definition = ControlDefinition.ByTestId("Control", "control.id");
        return new ResolvedControl(
            definition,
            definition.Selectors[0],
            new ControlScope("page 1 frame 'proof' depth 1", 0, 1, false),
            element);
    }

    private static string FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
        while (directory != null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "TestAutomation.csproj")))
                return directory.FullName;
            directory = directory.Parent;
        }

        throw new DirectoryNotFoundException("Could not locate the repository root.");
    }

    private sealed class FakeRuntime : IControlRuntime
    {
        private readonly IReadOnlyList<IControlScopeAdapter> _scopes;

        public FakeRuntime(params IControlScopeAdapter[] scopes)
        {
            _scopes = scopes;
        }

        public Task<IReadOnlyList<IControlScopeAdapter>> GetScopesAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(_scopes);
    }

    private sealed class FakeScope : IControlScopeAdapter
    {
        private readonly Dictionary<(ControlSelectorKind Kind, string Value), List<IControlElement>>
            _matches = new();

        private FakeScope(ControlScope scope)
        {
            Scope = scope;
        }

        public ControlScope Scope { get; }

        public static FakeScope MainPage() =>
            new(new ControlScope("page 1 main frame", 0, 0, true));

        public static FakeScope Frame(
            string description,
            int depth = 1,
            string? contractId = null) =>
            new(new ControlScope(
                description,
                0,
                depth,
                false,
                ContractId: contractId));

        public FakeScope WithTestId(string value, params IControlElement[] elements) =>
            With(ControlSelectorKind.TestId, value, elements);

        public FakeScope WithAniId(string value, params IControlElement[] elements) =>
            With(ControlSelectorKind.AniHtmlId, value, elements);

        public Task<IReadOnlyList<IControlElement>> FindVisibleAsync(
            ControlSelector selector,
            CancellationToken cancellationToken = default)
        {
            _matches.TryGetValue((selector.Kind, selector.Value), out var matches);
            IReadOnlyList<IControlElement> result =
                matches ?? (IReadOnlyList<IControlElement>)Array.Empty<IControlElement>();
            return Task.FromResult(result);
        }

        private FakeScope With(
            ControlSelectorKind kind,
            string value,
            params IControlElement[] elements)
        {
            _matches[(kind, value)] = elements.ToList();
            return this;
        }
    }

    private sealed class FakeControlElement : IControlElement
    {
        public List<string> Calls { get; } = new();
        public string Value { get; set; } = string.Empty;
        public string SelectedValue { get; set; } = string.Empty;
        public string SelectedText { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool Checked { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Selected { get; set; }
        public bool SelectOnClick { get; set; } = true;
        public bool Visible { get; set; } = true;
        public bool HideOnClick { get; set; }

        public Task ScrollIntoViewAsync(CancellationToken cancellationToken = default) =>
            Task.CompletedTask;

        public Task ClickAsync(CancellationToken cancellationToken = default)
        {
            Calls.Add("click");
            if (SelectOnClick)
                Selected = true;
            if (HideOnClick)
                Visible = false;
            return Task.CompletedTask;
        }

        public Task PressEnterAsync(CancellationToken cancellationToken = default)
        {
            Calls.Add("enter");
            return Task.CompletedTask;
        }

        public Task FillAsync(
            string value,
            CancellationToken cancellationToken = default)
        {
            Calls.Add("fill");
            Value = value;
            return Task.CompletedTask;
        }

        public Task SelectAsync(
            string value,
            CancellationToken cancellationToken = default)
        {
            Calls.Add("select");
            SelectedValue = value;
            return Task.CompletedTask;
        }

        public Task SelectByLabelAsync(string label, CancellationToken cancellationToken = default)
        {
            Calls.Add("select-label");
            SelectedText = label;
            return Task.CompletedTask;
        }

        public Task SetCheckedAsync(
            bool value,
            CancellationToken cancellationToken = default)
        {
            Calls.Add($"toggle:{value}");
            Checked = value;
            return Task.CompletedTask;
        }

        public Task<bool> IsCheckedAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Checked);

        public Task<bool> IsEnabledAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Enabled);

        public Task<bool> IsVisibleAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Visible);

        public Task<bool> IsSelectedAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Selected);

        public Task<string> GetValueAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Value);

        public Task<string> GetSelectedValueAsync(
            CancellationToken cancellationToken = default) =>
            Task.FromResult(SelectedValue);

        public Task<string> GetSelectedTextAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(SelectedText);

        public Task<string> GetTextAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Text);
    }

    private sealed class RecordingEvidenceSink : IControlEvidenceSink
    {
        public List<ControlEvidence> Items { get; } = new();

        public Task RecordAsync(
            ControlEvidence evidence,
            CancellationToken cancellationToken = default)
        {
            Items.Add(evidence);
            return Task.CompletedTask;
        }
    }
}
