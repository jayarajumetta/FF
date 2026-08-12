using Reqnroll;

namespace InsuranceAutomation.Hooks;

[Binding]
public sealed class ScenarioHooks
{
    private readonly BrowserSession _browser;
    private readonly RecoveryManager _recovery;
    private readonly ScenarioContext _scenario;

    public ScenarioHooks(
        BrowserSession browser,
        RecoveryManager recovery,
        ScenarioContext scenario)
    {
        _browser = browser;
        _recovery = recovery;
        _scenario = scenario;
    }

    [BeforeScenario(Order = 0)]
    public Task BeforeScenarioAsync() =>
        _browser.StartAsync(_scenario.ScenarioInfo.Title);

    [AfterScenario(Order = 90)]
    public async Task CaptureAndRecoverAsync()
    {
        if (_scenario.TestError is null)
            return;

        await _browser.CaptureFailureAsync(_scenario.ScenarioInfo.Title);
        await _recovery.AttemptFailureRecoveryAsync();
    }

    [AfterScenario(Order = 100)]
    public ValueTask DisposeScenarioAsync() =>
        _browser.DisposeAsync();
}
