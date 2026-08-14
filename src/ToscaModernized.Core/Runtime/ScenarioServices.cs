using System.Text.RegularExpressions;
using ToscaModernized.Core.Configuration;
using ToscaModernized.Core.Data;
using ToscaModernized.Core.Execution;
using ToscaModernized.Core.Locators;
using ToscaModernized.Core.Models;
using ToscaModernized.Core.Plans;

namespace ToscaModernized.Core.Runtime;

public sealed class ScenarioServices : IAsyncDisposable
{
    private readonly FrameworkSettings _settings;
    private readonly string _contentRoot;
    private int _scenarioCursor;

    public ScenarioPlan Plan { get; }
    public RunDataContext RunData { get; }
    public BrowserSession Browser { get; }
    public ArtifactManager Artifacts { get; }
    public StepExecutionEngine Engine { get; }

    private ScenarioServices(
        FrameworkSettings settings,
        string contentRoot,
        ScenarioPlan plan,
        RunDataContext runData,
        BrowserSession browser,
        ArtifactManager artifacts,
        StepExecutionEngine engine)
    {
        _settings = settings;
        _contentRoot = contentRoot;
        Plan = plan;
        RunData = runData;
        Browser = browser;
        Artifacts = artifacts;
        Engine = engine;
    }

    public static async Task<ScenarioServices> CreateAsync(string featureTitle, string scenarioTitle)
    {
        var (settings, contentRoot) = SettingsLoader.Load();
        var plansRoot = Path.Combine(contentRoot, settings.Paths.Plans);
        var plan = new ScenarioPlanRepository(plansRoot).Load(featureTitle, scenarioTitle);
        var dataPath = Path.Combine(contentRoot, settings.Paths.TestData, plan.StaticDataFile);
        var locatorPath = Path.Combine(contentRoot, settings.Paths.Locators, $"{plan.Application}.locators.json");
        var tdmPath = Path.Combine(contentRoot, settings.Paths.TdmOverrides);
        var sourceOverridePath = Path.Combine(contentRoot, settings.Paths.SourceValueOverrides);
        var runData = new RunDataContext();
        var staticData = StaticDataStore.Load(dataPath);
        var browser = await BrowserSession.CreateAsync(settings).ConfigureAwait(false);
        var locatorRepository = LocatorRepository.Load(locatorPath);
        var resolver = new ExpressionResolver(runData, staticData, tdmPath, sourceOverridePath);
        var dynamicData = new DynamicDataCoordinator(runData);
        var artifacts = new ArtifactManager(Path.Combine(contentRoot, settings.Paths.Artifacts), runData.RunId, featureTitle, scenarioTitle);
        var locatorResolver = new LocatorResolver(browser.Page, locatorRepository, settings);
        var ui = new PlaywrightUiActions(browser, locatorResolver);
        var system = new SystemActions(settings);
        var conditions = new ConditionEvaluator(settings, runData, browser, locatorRepository);
        var engine = new StepExecutionEngine(settings, dynamicData, resolver, runData, ui, system, conditions, artifacts);
        return new ScenarioServices(settings, contentRoot, plan, runData, browser, artifacts, engine);
    }

    public async Task ExecuteSourceBackgroundAsync()
    {
        foreach (var instruction in Plan.BackgroundInstructions.OrderBy(x => x.Sequence))
        {
            await Engine.ExecuteAsync(new ExecutionRequest { Instruction = instruction }).ConfigureAwait(false);
        }
    }

    public async Task ExecuteScenarioStepAsync(string stepText, IReadOnlyList<IReadOnlyList<string>>? table = null)
    {
        if (_scenarioCursor >= Plan.ScenarioInstructions.Count)
        {
            throw new InvalidOperationException($"Feature emitted an extra step after the ScenarioPlan ended: '{stepText}'.");
        }
        var expected = Plan.ScenarioInstructions[_scenarioCursor];
        if (_settings.Execution.StrictStepOrder && !string.Equals(Normalize(expected.GherkinText), Normalize(stepText), StringComparison.Ordinal))
        {
            throw new InvalidOperationException($"Step-order mismatch at scenario instruction {_scenarioCursor + 1}. Expected '{expected.GherkinText}', actual '{stepText}'. Source step: {expected.SourceStep} {expected.SourceStepName}.");
        }
        await Engine.ExecuteAsync(new ExecutionRequest
        {
            Instruction = expected,
            RuntimeTable = table ?? Array.Empty<IReadOnlyList<string>>()
        }).ConfigureAwait(false);
        _scenarioCursor++;
    }

    public void VerifyScenarioComplete()
    {
        if (_scenarioCursor != Plan.ScenarioInstructions.Count)
        {
            var next = Plan.ScenarioInstructions[_scenarioCursor];
            throw new InvalidOperationException($"Scenario completed after {_scenarioCursor} of {Plan.ScenarioInstructions.Count} planned instructions. Next missing step: '{next.GherkinText}' ({next.Id}).");
        }
    }

    public async ValueTask DisposeAsync()
    {
        await Artifacts.WriteRunDataAsync(RunData.Snapshot()).ConfigureAwait(false);
        await Browser.DisposeAsync().ConfigureAwait(false);
    }

    private static string Normalize(string value) => Regex.Replace(value.Trim(), "\\s+", " ");
}
