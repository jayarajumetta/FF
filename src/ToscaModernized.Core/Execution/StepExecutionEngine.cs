using ToscaModernized.Core.Configuration;
using ToscaModernized.Core.Data;
using ToscaModernized.Core.Models;
using ToscaModernized.Core.Runtime;

namespace ToscaModernized.Core.Execution;

public sealed class StepExecutionEngine
{
    private readonly FrameworkSettings _settings;
    private readonly DynamicDataCoordinator _dynamicData;
    private readonly ExpressionResolver _resolver;
    private readonly RunDataContext _runData;
    private readonly PlaywrightUiActions _ui;
    private readonly SystemActions _system;
    private readonly ConditionEvaluator _conditions;
    private readonly ArtifactManager _artifacts;

    public StepExecutionEngine(
        FrameworkSettings settings,
        DynamicDataCoordinator dynamicData,
        ExpressionResolver resolver,
        RunDataContext runData,
        PlaywrightUiActions ui,
        SystemActions system,
        ConditionEvaluator conditions,
        ArtifactManager artifacts)
    {
        _settings = settings;
        _dynamicData = dynamicData;
        _resolver = resolver;
        _runData = runData;
        _ui = ui;
        _system = system;
        _conditions = conditions;
        _artifacts = artifacts;
    }

    public async Task ExecuteAsync(ExecutionRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        var instruction = request.Instruction;
        var generated = _dynamicData.Prepare(instruction);
        var value = generated ?? _resolver.Resolve(instruction.Value, instruction.ValueRef);
        var execute = !string.Equals(instruction.Operation, "Conditional", StringComparison.OrdinalIgnoreCase)
            || await _conditions.ShouldExecuteAsync(instruction).ConfigureAwait(false);

        await _artifacts.WriteAuditAsync(new
        {
            instruction.Id,
            instruction.Phase,
            instruction.Sequence,
            instruction.GherkinText,
            instruction.Operation,
            instruction.Target,
            Value = IsSensitive(instruction) ? "***" : value,
            Execute = execute,
            Timestamp = DateTimeOffset.UtcNow
        }).ConfigureAwait(false);

        if (!execute || _settings.Execution.DryRun) return;

        switch (instruction.Operation)
        {
            case "Navigate": await _ui.NavigateAsync(value).ConfigureAwait(false); break;
            case "Login": await _ui.LoginAsync(instruction, _resolver).ConfigureAwait(false); break;
            case "Click": await _ui.ClickAsync(instruction.Target, instruction.SourceModule).ConfigureAwait(false); break;
            case "Fill": await _ui.FillAsync(instruction.Target, value, instruction.SourceModule).ConfigureAwait(false); break;
            case "Select": await _ui.SelectAsync(instruction.Target, value, instruction.SourceModule).ConfigureAwait(false); break;
            case "Press": await _ui.PressAsync(instruction.Target, instruction.GherkinText, instruction.SourceModule).ConfigureAwait(false); break;
            case "VerifyExists": await _ui.VerifyExistsAsync(instruction.Target, instruction.GherkinText, instruction.SourceModule).ConfigureAwait(false); break;
            case "VerifyVisible": await _ui.VerifyVisibleAsync(instruction.Target, instruction.SourceModule).ConfigureAwait(false); break;
            case "VerifyText": await _ui.VerifyTextAsync(instruction.Target, value, instruction.SourceModule).ConfigureAwait(false); break;
            case "Wait": await _ui.WaitAsync(instruction, value).ConfigureAwait(false); break;
            case "GenerateRandom":
                if (!string.IsNullOrWhiteSpace(instruction.Target)) await _ui.FillAsync(instruction.Target, generated ?? value, instruction.SourceModule).ConfigureAwait(false);
                break;
            case "SetRuntime":
                _runData.Set(RequiredAlias(instruction), value);
                break;
            case "UseRuntime":
                await _ui.FillAsync(instruction.Target, _runData.GetRequired(RequiredAlias(instruction)), instruction.SourceModule).ConfigureAwait(false);
                break;
            case "Capture":
                _runData.Set(RequiredAlias(instruction), await _ui.ReadAsync(instruction.Target, instruction.SourceModule).ConfigureAwait(false));
                break;
            case "SystemCommand": await _system.ExecuteProcessAsync(instruction.GherkinText).ConfigureAwait(false); break;
            case "FileOperation": await _system.ExecuteFileOperationAsync(instruction.GherkinText).ConfigureAwait(false); break;
            case "JsonOperation": await _system.ExecuteJsonOperationAsync(instruction.GherkinText).ConfigureAwait(false); break;
            case "TableInput": await _ui.EnterTableAsync(request.RuntimeTable.Count > 0 ? request.RuntimeTable : instruction.Table).ConfigureAwait(false); break;
            case "Conditional": await ExecuteConditionalInnerAsync(instruction, value).ConfigureAwait(false); break;
            case "ManualAction": await _ui.ExecuteNaturalLanguageAsync(instruction, value).ConfigureAwait(false); break;
            default: throw new NotSupportedException($"Unsupported operation '{instruction.Operation}' in instruction '{instruction.Id}'.");
        }
    }

    private async Task ExecuteConditionalInnerAsync(PlanInstruction instruction, string value)
    {
        switch (instruction.InnerOperation)
        {
            case "Click": await _ui.ClickAsync(instruction.Target, instruction.SourceModule).ConfigureAwait(false); break;
            case "Fill": await _ui.FillAsync(instruction.Target, value, instruction.SourceModule).ConfigureAwait(false); break;
            case "VerifyExists": await _ui.VerifyExistsAsync(instruction.Target, instruction.GherkinText, instruction.SourceModule).ConfigureAwait(false); break;
            case "Wait": await _ui.WaitAsync(instruction, value).ConfigureAwait(false); break;
            default: await _ui.ExecuteNaturalLanguageAsync(instruction, value).ConfigureAwait(false); break;
        }
    }

    private static string RequiredAlias(PlanInstruction instruction) =>
        !string.IsNullOrWhiteSpace(instruction.Alias)
            ? instruction.Alias
            : throw new InvalidOperationException($"Instruction '{instruction.Id}' requires a runtime alias.");

    private static bool IsSensitive(PlanInstruction instruction) =>
        instruction.GherkinText.Contains("password", StringComparison.OrdinalIgnoreCase) ||
        instruction.Target.Contains("password", StringComparison.OrdinalIgnoreCase);
}
