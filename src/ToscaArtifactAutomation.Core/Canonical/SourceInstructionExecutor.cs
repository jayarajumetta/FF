using System.Text.RegularExpressions;
using Serilog;
using ToscaArtifactAutomation.Core.Actions;
using ToscaArtifactAutomation.Core.Runtime;

namespace ToscaArtifactAutomation.Core.Canonical;

public sealed class SourceInstructionExecutor
{
    private static readonly Regex Quoted = new("\\\"((?:\\\\.|[^\\\"\\\\])*)\\\"", RegexOptions.Compiled);
    private readonly UiActions _actions;
    private readonly UiAssertions _assertions;

    public SourceInstructionExecutor(UiActions actions, UiAssertions assertions)
    {
        _actions = actions ?? throw new ArgumentNullException(nameof(actions));
        _assertions = assertions ?? throw new ArgumentNullException(nameof(assertions));
    }

    public async Task ExecuteAsync(CanonicalAction action, ScenarioDataContext data)
    {
        var sentence = action.SourceSentence;
        var values = Quoted.Matches(sentence).Select(x => Regex.Unescape(x.Groups[1].Value)).ToArray();
        var lower = sentence.ToLowerInvariant();
        if (lower.Contains("click") && values.Length > 0)
        {
            await _actions.ClickAsync(data.Resolve(values[^1]), action.Module, Array.Empty<string>());
            return;
        }
        if ((lower.Contains("enter") || lower.Contains("select") || lower.Contains("use value")) && values.Length >= 2)
        {
            await _actions.SmartSetAsync(data.Resolve(values[^1]), data.Resolve(values[0]), action.Module, Array.Empty<string>());
            return;
        }
        if (lower.Contains("should") && values.Length > 0)
        {
            await _assertions.VerifyAsync(data.Resolve(values[0]), action.Module, lower.Contains("not exist") ? "Absent" : "Exists", string.Empty);
            return;
        }
        if (lower.Contains("wait") && values.Length > 0)
        {
            await _assertions.WaitAsync(data.Resolve(values[0]), action.Module, lower.Contains("not exist") ? "Absent" : "Exists", string.Empty, string.Empty, action.TimeoutMs);
            return;
        }
        Log.Warning("Source instruction {ActionId} has no safe executable translation and is retained as evidence only: {Sentence}", action.Id, sentence);
    }
}
