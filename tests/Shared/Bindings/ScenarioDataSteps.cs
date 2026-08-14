using Reqnroll;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.Core.Utils;

namespace ToscaArtifactAutomation.Tests.Shared.Bindings;

[Binding]
public sealed class ScenarioDataSteps
{
    private readonly ScenarioDataContext _data;
    private readonly RandomDataService _random;

    public ScenarioDataSteps(ScenarioDataContext data, RandomDataService random)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
        _random = random ?? throw new ArgumentNullException(nameof(random));
    }

    [Given("^scenario data \"([^\"]+)\" is loaded$")]
    public Task LoadScenarioDataAsync(string dataSet) => _data.LoadAsync(dataSet);

    [Given("^RANDOM scenario values are generated from the canonical Tosca patterns$")]
    public void GenerateRandomScenarioValues() => _random.GenerateAll(_data);
}
