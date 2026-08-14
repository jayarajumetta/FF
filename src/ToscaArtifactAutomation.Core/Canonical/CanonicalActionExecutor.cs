using Serilog;
using ToscaArtifactAutomation.Core.Actions;
using ToscaArtifactAutomation.Core.Application;
using ToscaArtifactAutomation.Core.Browser;
using ToscaArtifactAutomation.Core.Runtime;
using ToscaArtifactAutomation.Core.Utils;

namespace ToscaArtifactAutomation.Core.Canonical;

public sealed class CanonicalActionExecutor
{
    private readonly BrowserSession _browser;
    private readonly UiActions _actions;
    private readonly UiAssertions _assertions;
    private readonly ConditionEvaluator _conditions;
    private readonly RandomDataService _random;
    private readonly ApplicationSessionService _session;
    private readonly SystemActionService _system;
    private readonly SourceInstructionExecutor _source;

    public CanonicalActionExecutor(
        BrowserSession browser,
        UiActions actions,
        UiAssertions assertions,
        ConditionEvaluator conditions,
        RandomDataService random,
        ApplicationSessionService session,
        SystemActionService system,
        SourceInstructionExecutor source)
    {
        _browser = browser ?? throw new ArgumentNullException(nameof(browser));
        _actions = actions ?? throw new ArgumentNullException(nameof(actions));
        _assertions = assertions ?? throw new ArgumentNullException(nameof(assertions));
        _conditions = conditions ?? throw new ArgumentNullException(nameof(conditions));
        _random = random ?? throw new ArgumentNullException(nameof(random));
        _session = session ?? throw new ArgumentNullException(nameof(session));
        _system = system ?? throw new ArgumentNullException(nameof(system));
        _source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public async Task ExecuteAsync(IReadOnlyList<CanonicalAction> actions, ScenarioDataContext data, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(actions);
        ArgumentNullException.ThrowIfNull(data);
        var previous = 0;
        foreach (var action in actions)
        {
            ArgumentNullException.ThrowIfNull(action);
            cancellationToken.ThrowIfCancellationRequested();
            if (action.Sequence <= previous)
                throw new InvalidOperationException($"Canonical sequence is not strictly increasing at action '{action.Id}'.");
            previous = action.Sequence;
            if (!await _conditions.ShouldExecuteAsync(action, data)) continue;
            Log.Information("CANONICAL {ActionId} source-step={SourceStep} operation={Operation} sentence={Sentence}", action.Id, action.SourceStep, action.Operation, action.SourceSentence);
            await ExecuteOneAsync(action, data, cancellationToken);
        }
    }

    private async Task ExecuteOneAsync(CanonicalAction action, ScenarioDataContext data, CancellationToken cancellationToken)
    {
        var target = data.Resolve(action.Target);
        var value = data.Resolve(action.ValueExpression);
        var expected = data.Resolve(action.ExpectedExpression);
        switch (action.Operation)
        {
            case CanonicalOperation.Navigate:
                if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException($"Navigate action '{action.Id}' has no URL.");
                await _browser.Page.GotoAsync(value, new Microsoft.Playwright.PageGotoOptions { WaitUntil = Microsoft.Playwright.WaitUntilState.DOMContentLoaded });
                break;
            case CanonicalOperation.Authenticate:
                await _session.AuthenticateCurrentPageAsync(target);
                break;
            case CanonicalOperation.Constraint:
                await _assertions.VerifyAsync(target, action.Module, expected, string.IsNullOrWhiteSpace(action.PropertyName) ? "InnerText" : action.PropertyName);
                break;
            case CanonicalOperation.Input:
            case CanonicalOperation.SmartSet:
                await _actions.SmartSetAsync(target, value, action.Module, action.Commands);
                break;
            case CanonicalOperation.Click:
                await _actions.ClickAsync(target, action.Module, action.Commands);
                break;
            case CanonicalOperation.Select:
                await _actions.SelectAsync(target, value, action.Module, action.Commands);
                break;
            case CanonicalOperation.Press:
                await _actions.PressAsync(target, action.Module, action.Commands);
                break;
            case CanonicalOperation.Wait:
                if (action.TimeoutMs > 0 && string.IsNullOrWhiteSpace(target))
                    await Task.Delay(action.TimeoutMs, cancellationToken);
                else
                    await _assertions.WaitAsync(target, action.Module, expected, action.PropertyName, value, action.TimeoutMs);
                break;
            case CanonicalOperation.Verify:
                await _assertions.VerifyAsync(target, action.Module, expected, action.PropertyName);
                break;
            case CanonicalOperation.Capture:
                data.SetRuntime(action.Alias, await _assertions.ReadAsync(target, action.Module, action.PropertyName));
                break;
            case CanonicalOperation.SetRuntime:
            case CanonicalOperation.ExternalValue:
                data.SetRuntime(action.Alias, value);
                break;
            case CanonicalOperation.ExternalInput:
                await _actions.SmartSetAsync(target, value, action.Module, action.Commands);
                break;
            case CanonicalOperation.GenerateRandom:
                if (!data.TryGetRuntime(action.Alias, out _)) data.SetRuntime(action.Alias, _random.Generate(value));
                if (!string.IsNullOrWhiteSpace(target)) await _actions.SmartSetAsync(target, data.GetRuntimeRequired(action.Alias), action.Module, action.Commands);
                break;
            case CanonicalOperation.Evaluate:
                var evaluated = value;
                foreach (var command in action.Commands)
                {
                    if (command.StartsWith("PARTIAL:", StringComparison.OrdinalIgnoreCase))
                    {
                        var parts = command.Split(':');
                        var start = parts.Length > 1 && int.TryParse(parts[1], out var parsedStart) ? parsedStart : 0;
                        var length = parts.Length > 2 && int.TryParse(parts[2], out var parsedLength) ? parsedLength : Math.Max(0, evaluated.Length - start);
                        if (start < 0) start = Math.Max(0, evaluated.Length + start);
                        evaluated = start >= evaluated.Length ? string.Empty : evaluated.Substring(start, Math.Min(length, evaluated.Length - start));
                    }
                    else if (command.StartsWith("LAST:", StringComparison.OrdinalIgnoreCase) && int.TryParse(command[5..], out var last))
                    {
                        evaluated = evaluated.Length <= last ? evaluated : evaluated[^last..];
                    }
                    else if (command.StartsWith("REMOVE_RUNTIME:", StringComparison.OrdinalIgnoreCase))
                    {
                        var key = command[15..];
                        if (data.TryGetRuntime(key, out var remove)) evaluated = evaluated.Replace(remove, string.Empty, StringComparison.Ordinal).Trim();
                    }
                }
                data.SetRuntime(action.Alias, evaluated);
                break;
            case CanonicalOperation.SystemAction:
                await _system.RejectBusinessLayerSystemActionAsync(action.Id);
                break;
            case CanonicalOperation.SourceInstruction:
                await _source.ExecuteAsync(action, data);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action.Operation), action.Operation, $"Unsupported canonical operation for '{action.Id}'.");
        }
    }
}
