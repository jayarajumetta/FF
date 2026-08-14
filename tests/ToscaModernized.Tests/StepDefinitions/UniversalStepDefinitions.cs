using Reqnroll;
using ToscaModernized.Core.Runtime;
using ToscaModernized.Tests.Hooks;

namespace ToscaModernized.Tests.StepDefinitions;

[Binding]
public sealed class UniversalStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    public UniversalStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

    [Given(@"^(?!the (?:Commercial Lines Duck Creek|Commercial Lines ExpertQuote|Personal Lines Duck Creek) application context and source-defined prerequisites are initialized$)(.*)$")]
    [Then(@"^(.*)$")]
    public Task ExecuteGivenOrThenAsync(string stepText) => Services().ExecuteScenarioStepAsync(stepText);

    [When(@"^(?!I enter the following account address:$)(.*)$")]
    public Task ExecuteWhenAsync(string stepText) => Services().ExecuteScenarioStepAsync(stepText);

    [When(@"^I enter the following account address:$")]
    public Task EnterAccountAddressAsync(Table table)
    {
        var rows = new List<IReadOnlyList<string>> { table.Header.ToArray() };
        rows.AddRange(table.Rows.Select(row => (IReadOnlyList<string>)table.Header.Select(header => row[header]).ToArray()));
        return Services().ExecuteScenarioStepAsync("I enter the following account address:", rows);
    }

    private ScenarioServices Services()
    {
        if (!_scenarioContext.TryGetValue(ScenarioHooks.ServicesKey, out ScenarioServices? services) || services is null)
        {
            throw new InvalidOperationException("ScenarioServices are not initialized. Verify the BeforeScenario hook ran successfully.");
        }
        return services;
    }
}
