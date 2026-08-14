using System.Text.RegularExpressions;
using ToscaModernized.Core.Configuration;
using ToscaModernized.Core.Data;
using ToscaModernized.Core.Locators;
using ToscaModernized.Core.Models;
using ToscaModernized.Core.Runtime;

namespace ToscaModernized.Core.Execution;

public sealed class ConditionEvaluator
{
    private readonly FrameworkSettings _settings;
    private readonly RunDataContext _runData;
    private readonly BrowserSession _browser;
    private readonly LocatorRepository _locators;

    public ConditionEvaluator(FrameworkSettings settings, RunDataContext runData, BrowserSession browser, LocatorRepository locators)
    {
        _settings = settings;
        _runData = runData;
        _browser = browser;
        _locators = locators;
    }

    public async Task<bool> ShouldExecuteAsync(PlanInstruction instruction)
    {
        var condition = string.IsNullOrWhiteSpace(instruction.Condition) ? instruction.ControlFlow : instruction.Condition;
        if (string.IsNullOrWhiteSpace(condition)) return _settings.Execution.ExecuteUnknownConditions;
        var comparison = Regex.Match(condition, "['\\\"]?(?<key>[^'\\\"!=]+)['\\\"]?\\s*(?<op>==|!=)\\s*['\\\"]?(?<value>[^'\\\"]+)['\\\"]?", RegexOptions.IgnoreCase);
        if (comparison.Success && _runData.TryGet(comparison.Groups["key"].Value.Trim(), out var actual))
        {
            var expected = comparison.Groups["value"].Value.Trim();
            var equal = string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase);
            return comparison.Groups["op"].Value == "==" ? equal : !equal;
        }
        if (!string.IsNullOrWhiteSpace(instruction.Target) && !_settings.Execution.DryRun)
        {
            var repositoryMatches = _locators.Find(instruction.Target, instruction.SourceModule);
            if (repositoryMatches.Count > 0)
            {
                // The StepExecutionEngine/LocatorResolver performs the definitive check; an available mapping is sufficient here.
                await _browser.Page.WaitForTimeoutAsync(1).ConfigureAwait(false);
                return true;
            }
        }
        return _settings.Execution.ExecuteUnknownConditions;
    }
}
