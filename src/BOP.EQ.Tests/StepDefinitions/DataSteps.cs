using Reqnroll;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.StepDefinitions;

[Binding]
public sealed class DataSteps
{
    private readonly ScenarioData _data;
    public DataSteps(ScenarioData data) => _data = data;

    [Given("test data file {string} is loaded")]
    public Task LoadAsync(string path) => _data.LoadAsync(path);
}
