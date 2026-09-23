using System.Net;
using Microsoft.Playwright;
using NUnit.Framework;
using PnCTestAutomation.Controls;

namespace PnCTestAutomation.UnitTests;

[TestFixture]
[Category("BrowserContract")]
[NonParallelizable]
public sealed class PlaywrightControlAdapterTests
{
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IBrowserContext _context = null!;
    private IPage _page = null!;

    [OneTimeSetUp]
    public async Task StartBrowser()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = true });
    }

    [SetUp]
    public async Task CreatePage()
    {
        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }

    [TearDown]
    public async Task ClosePage()
    {
        if (_context != null)
            await _context.CloseAsync();
    }

    [OneTimeTearDown]
    public async Task CloseBrowser()
    {
        if (_browser != null)
            await _browser.CloseAsync();
        _playwright?.Dispose();
    }

    [Test]
    public async Task NativeSelectionDistinguishesLabelFromStoredValue()
    {
        await _page.SetContentAsync("""
            <select data-testid="state">
              <option value="AZ">Arizona</option><option value="AL">Alabama</option>
            </select>
            """);
        var control = await ResolveAsync("state");
        var actions = Actions();

        await actions.SelectByLabelAsync(control, "Alabama");
        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.SelectedValue), Is.EqualTo("AL"));
        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.SelectedText), Is.EqualTo("Alabama"));
        await actions.SelectAsync(control, "AZ");
        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.SelectedValue), Is.EqualTo("AZ"));
    }

    [Test]
    public async Task MaterialOverlaySelectionStaysInResolvedFrameAndVerifiesClosedTrigger()
    {
        await _page.SetContentAsync(
            MaterialSelect("Wrong top-page value") +
            $"<iframe name=\"policy\" srcdoc=\"{WebUtility.HtmlEncode(MaterialSelect("Arizona"))}\"></iframe>");
        var evidence = new EvidenceSink();
        var hints = new[] { new FrameScopeHint { ScopeId = "policy", FramePath = ["policy"] } };
        var resolver = new ControlScopeResolver(new PlaywrightControlRuntime(_page, hints));
        var control = await resolver.ResolveAsync(
            ControlDefinition.ByTestId("State", "state").InScope("policy"));
        var actions = Actions(evidence);

        await actions.SelectByLabelAsync(control, "Alabama");

        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.SelectedText), Is.EqualTo("Alabama"));
        Assert.That((await _page.GetByTestId("state").InnerTextAsync()).Trim(), Is.EqualTo("Wrong top-page value"));
        Assert.That(await _page.Frames.Single(frame => frame.Name == "policy").EvaluateAsync<int>("window.clicks"), Is.EqualTo(1));
        Assert.That(evidence.Items.All(item => item.Scope.ContractId == "policy" && item.Scope.FrameDepth == 1), Is.True);
        Assert.That(evidence.Items.Select(item => item.Assertion), Is.All.EqualTo(ControlAssertion.SelectedText));
    }

    [Test]
    public async Task ExplicitMainFrameScopeCannotSelectAMatchingChildControl()
    {
        const string markup = """
            <select data-testid="state"><option value="AZ">Arizona</option><option value="AL">Alabama</option></select>
            """;
        await _page.SetContentAsync(markup +
            $"<iframe name=\"policy\" srcdoc=\"{WebUtility.HtmlEncode(markup)}\"></iframe>");
        var hint = new FrameScopeHint { ScopeId = "cleq-main", IsMainFrame = true };
        var resolver = new ControlScopeResolver(new PlaywrightControlRuntime(_page, [hint]));
        var control = await resolver.ResolveAsync(
            ControlDefinition.ByTestId("State", "state").InScope("cleq-main"));

        await Actions().SelectAsync(control, "AL");

        Assert.That(control.Scope.IsMainFrame, Is.True);
        Assert.That(control.Scope.ContractId, Is.EqualTo("cleq-main"));
        Assert.That(await _page.GetByTestId("state").InputValueAsync(), Is.EqualTo("AL"));
        Assert.That(await _page.Frames.Single(frame => frame.Name == "policy").GetByTestId("state").InputValueAsync(),
            Is.EqualTo("AZ"));
    }

    [Test]
    public async Task IncorrectSelectionFailsWithoutReplayingTheOption()
    {
        await _page.SetContentAsync(MaterialSelect("Arizona", updateSelection: false));
        var control = await ResolveAsync("state");

        Assert.ThrowsAsync<ControlPostconditionException>(async () =>
            await Actions().SelectByLabelAsync(control, "Alabama"));
        Assert.That(await _page.EvaluateAsync<int>("window.clicks"), Is.EqualTo(1));
        Assert.That(await Actions().CaptureAsync(control, ControlTextCapture.SelectedText), Is.EqualTo("Arizona"));
    }

    [Test]
    public async Task MultipleOptionsInExactPanelFailBeforeMutation()
    {
        await _page.SetContentAsync(MaterialSelect("Arizona", duplicateOption: true));
        var control = await ResolveAsync("state");

        Assert.ThrowsAsync<PlaywrightException>(async () =>
            await Actions().SelectByLabelAsync(control, "Alabama"));
        Assert.That(await _page.EvaluateAsync<int>("window.clicks"), Is.Zero);
    }

    [Test]
    public async Task WrappedFieldsCaptureRealValueCheckedAndDisabledState()
    {
        await _page.SetContentAsync("""
            <div data-testid="disabled"><input disabled value="unchanged"></div>
            <div data-testid="name"><input></div>
            <div data-testid="consent"><input type="checkbox"></div>
            """);
        var actions = Actions();
        var disabled = await ResolveAsync("disabled");
        var name = await ResolveAsync("name");
        var consent = await ResolveAsync("consent");

        Assert.That(await actions.CaptureStateAsync(disabled, ControlStateCapture.Enabled), Is.False);
        Assert.ThrowsAsync<ControlPostconditionException>(async () => await actions.FillAsync(disabled, "changed"));
        Assert.That(await actions.CaptureAsync(disabled, ControlTextCapture.Value), Is.EqualTo("unchanged"));
        await actions.FillAsync(name, "Entered name");
        Assert.That(await actions.CaptureAsync(name, ControlTextCapture.Value), Is.EqualTo("Entered name"));
        Assert.That(await actions.CaptureStateAsync(consent, ControlStateCapture.Checked), Is.False);
        await actions.ToggleAsync(consent, true);
        Assert.That(await actions.CaptureStateAsync(consent, ControlStateCapture.Checked), Is.True);
        Assert.That(await actions.CaptureStateAsync(consent, ControlStateCapture.Selected), Is.True);
    }

    [Test]
    public async Task TextDoesNotMasqueradeAsValueOrSelectedState()
    {
        await _page.SetContentAsync("<div data-testid=\"heading\">Actual policy</div>");
        var control = await ResolveAsync("heading");
        var actions = Actions();

        Assert.That(await actions.CaptureAsync(control, ControlTextCapture.Text), Is.EqualTo("Actual policy"));
        Assert.ThrowsAsync<PlaywrightException>(async () =>
            await actions.CaptureAsync(control, ControlTextCapture.Value));
        Assert.ThrowsAsync<PlaywrightException>(async () =>
            await actions.CaptureStateAsync(control, ControlStateCapture.Selected));
        Assert.ThrowsAsync<ControlPostconditionException>(async () =>
            await actions.AssertAsync(control, ControlExpectation.Text("Expected policy")));
    }

    [Test]
    public async Task AmbiguousWrappedControlsFailRatherThanReadingTheFirstInput()
    {
        await _page.SetContentAsync("<div data-testid=\"ambiguous\"><input value=\"one\"><input value=\"two\"></div>");
        var control = await ResolveAsync("ambiguous");

        Assert.ThrowsAsync<PlaywrightException>(async () =>
            await Actions().CaptureAsync(control, ControlTextCapture.Value));
        Assert.ThrowsAsync<ControlResolutionException>(async () =>
            await Actions().FillAsync(control, "replacement"));
        Assert.That(await _page.Locator("input").EvaluateAllAsync<string[]>("inputs => inputs.map(input => input.value)"),
            Is.EqualTo(new[] { "one", "two" }));
    }

    private Task<ResolvedControl> ResolveAsync(string testId) =>
        new ControlScopeResolver(new PlaywrightControlRuntime(_page))
            .ResolveAsync(ControlDefinition.ByTestId(testId, testId));

    [TestCase(false)]
    [TestCase(true)]
    public async Task AniChipSelectionReadsActualSelectedClassRatherThanVisibility(bool selected)
    {
        var css = selected ? "chip-wrapper-selected" : "chip-wrapper";
        await _page.SetContentAsync($"""
            <div data-testid="wrapped" class="chip-item-wrapper"><div class="{css}">Married</div></div>
            <div data-testid="direct" class="{css}">Business Owners</div>
            """);
        foreach (var id in new[] { "wrapped", "direct" })
            Assert.That(await Actions().CaptureStateAsync(await ResolveAsync(id), ControlStateCapture.Selected), Is.EqualTo(selected));
    }

    [Test]
    public async Task AmbiguousChipSelectionCannotPass()
    {
        await _page.SetContentAsync("""
            <div data-testid="chip" class="chip-item-wrapper">
              <div class="chip-wrapper">No</div><div class="chip-wrapper-selected">Yes</div>
            </div>
            """);
        var control = await ResolveAsync("chip");
        Assert.ThrowsAsync<PlaywrightException>(async () => await Actions().CaptureStateAsync(control, ControlStateCapture.Selected));
    }

    [Test]
    public async Task ExactPresentedChipCaptionSelectsMarriedWithoutSelectingDivorced()
    {
        await _page.SetContentAsync("""
            <div style="text-transform:uppercase">
              <div data-testid="marital" class="chip-item-wrapper"
                onclick="this.firstElementChild.className='chip-wrapper-selected'"><div class="chip-wrapper">Married</div></div>
              <div data-testid="marital" class="chip-item-wrapper"><div class="chip-wrapper">Divorced</div></div>
            </div>
            """);
        var resolver = new ControlScopeResolver(new PlaywrightControlRuntime(_page));
        var married = await resolver.ResolveAsync(ControlDefinition.ByTestIdWithExactText("Married", "marital", "MARRIED"));
        var divorced = await resolver.ResolveAsync(ControlDefinition.ByTestIdWithExactText("Divorced", "marital", "DIVORCED"));
        await Actions().ClickAsync(married, ControlExpectation.Selected());
        Assert.That(await Actions().CaptureStateAsync(divorced, ControlStateCapture.Selected), Is.False);
    }

    [TestCase("9/2/2026")]
    [TestCase("09/02/2026")]
    [TestCase("9/02/2026")]
    [TestCase("09/2/2026")]
    public async Task UsDateAssertionComparesTheCalendarDateNotZeroPadding(string actual)
    {
        await _page.SetContentAsync($"<input data-testid=\"date\" value=\"{actual}\">");
        await Helpers.Helpers.AssertUsDateValueAsync(_page.GetByTestId("date"), "09/02/2026", "birth date");
    }

    [TestCase("09/03/2026")]
    [TestCase("09/02/2025")]
    [TestCase("not-a-date")]
    [TestCase("")]
    public async Task UsDateAssertionRejectsChangedOrMissingDatesWithoutLoggingValues(string actual)
    {
        await _page.SetContentAsync($"<input data-testid=\"date\" value=\"{actual}\">");
        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await Helpers.Helpers.AssertUsDateValueAsync(_page.GetByTestId("date"), "09/02/2026", "birth date"));
        Assert.That(exception!.Message, Is.EqualTo("The birth date does not match the scenario-owned calendar date."));
    }

    private static SemanticControlActions Actions(IControlEvidenceSink? sink = null) =>
        new(sink, assertionTimeout: TimeSpan.Zero);

    private static string MaterialSelect(string selectedText, bool updateSelection = true, bool duplicateOption = false)
    {
        var update = updateSelection
            ? "document.getElementById('selected').textContent = 'Alabama';"
            : "";
        var duplicate = duplicateOption ? "<div role=\"option\">Alabama</div>" : "";
        return $$"""
            <mat-select data-testid="state" role="combobox" aria-expanded="false" aria-controls="panel"
              onclick="document.getElementById('panel').hidden=false; this.setAttribute('aria-expanded','true')">
              <span id="selected" class="mat-mdc-select-value-text">{{WebUtility.HtmlEncode(selectedText)}}</span>
            </mat-select>
            <div id="panel" role="listbox" hidden>
              <div role="option" onclick="window.clicks++; {{update}}
                document.getElementById('panel').hidden=true;
                document.querySelector('mat-select').setAttribute('aria-expanded','false')">Alabama</div>
              {{duplicate}}
            </div>
            <script>window.clicks = 0;</script>
            """;
    }

    private sealed class EvidenceSink : IControlEvidenceSink
    {
        public List<ControlEvidence> Items { get; } = [];

        public Task RecordAsync(ControlEvidence evidence, CancellationToken cancellationToken = default)
        {
            Items.Add(evidence);
            return Task.CompletedTask;
        }
    }
}
