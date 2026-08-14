using Reqnroll;
using ToscaModernized.Tests.Hooks;

namespace ToscaModernized.Tests.StepDefinitions;

[Binding]
public sealed class ApplicationContextSteps
{
    private readonly ScenarioContext _scenarioContext;
    public ApplicationContextSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

    [Given(@"^the (Commercial Lines Duck Creek|Commercial Lines ExpertQuote|Personal Lines Duck Creek) application context and source-defined prerequisites are initialized$")]
    public void ApplicationContextIsInitialized(string application)
    {
        if (!_scenarioContext.TryGetValue(ScenarioHooks.ServicesKey, out object? services) || services is null)
        {
            throw new InvalidOperationException($"Application context '{application}' was requested before ScenarioServices initialization.");
        }
    }
}
