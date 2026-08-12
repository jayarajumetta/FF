using Reqnroll;
using InsuranceAutomation.Utils;

namespace InsuranceAutomation.StepDefinitions;

[Binding]
public sealed class BusinessContextSteps
{
    private readonly ScenarioData _data;
    public BusinessContextSteps(ScenarioData data) => _data = data;

    [Given("the policy jurisdiction is {string}")]
    public void SetJurisdiction(string value) => _data.Set("StateCode", value);

    [Given("the policy state is {string}")]
    public void SetStateName(string value) => _data.Set("StateName", value);

    [Given("the writing company is {string}")]
    public void SetWritingCompany(string value) => _data.Set("WritingCompany", value);

    [Given("the policy effective date is {string}")]
    public void SetEffectiveDate(string value) => _data.Set("EffectiveDate", value);
}
