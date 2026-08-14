using System.Text.RegularExpressions;
using Serilog;
using ToscaArtifactAutomation.Core.Configuration;
using ToscaArtifactAutomation.Core.Locators;
using ToscaArtifactAutomation.Core.Runtime;

namespace ToscaArtifactAutomation.Core.Canonical;

public sealed class ConditionEvaluator
{
    private static readonly Regex Comparison = new("^\\s*['\\\"]?(?<left>[^=!'<>&|\\\"]+?)['\\\"]?\\s*(?<op>==|!=)\\s*(?:['\\\"](?<right>[^'\\\"]*)['\\\"]|(?<bare>NULL|TRUE|FALSE|[^\\s]+))\\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly RootSettings _settings;
    private readonly LocatorResolver _resolver;

    public ConditionEvaluator(RootSettings settings, LocatorResolver resolver)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
    }

    public async Task<bool> ShouldExecuteAsync(CanonicalAction action, ScenarioDataContext data)
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentNullException.ThrowIfNull(data);
        if (action.ConditionPolicy == ConditionPolicy.Always || string.IsNullOrWhiteSpace(action.Condition)) return true;
        if (action.ConditionPolicy == ConditionPolicy.OptionalTarget)
        {
            if (string.IsNullOrWhiteSpace(action.Target)) return HandleUnknown(action.Condition, action);
            var exists = await _resolver.ExistsAsync(data.Resolve(action.Target), action.Module);
            Log.Debug("Optional source branch {ActionId} target {Target}: {Exists}", action.Id, action.Target, exists);
            return exists;
        }
        return EvaluateBoolean(data.Resolve(action.Condition), data, action);
    }

    private bool EvaluateBoolean(string expression, ScenarioDataContext data, CanonicalAction action)
    {
        expression = TrimOuterParentheses(expression.Trim());
        var orParts = SplitTopLevel(expression, "||", " OR ");
        if (orParts.Count > 1) return orParts.Any(x => EvaluateBoolean(x, data, action));
        var andParts = SplitTopLevel(expression, "&&", " AND ");
        if (andParts.Count > 1) return andParts.All(x => EvaluateBoolean(x, data, action));
        var match = Comparison.Match(expression);
        if (!match.Success) return HandleUnknown(expression, action);
        var key = match.Groups["left"].Value.Trim();
        var right = match.Groups["right"].Success ? match.Groups["right"].Value : match.Groups["bare"].Value;
        data.TryGetSymbol(key, out var left);
        var equal = right.Equals("NULL", StringComparison.OrdinalIgnoreCase)
            ? string.IsNullOrWhiteSpace(left)
            : string.Equals(left ?? string.Empty, right, StringComparison.OrdinalIgnoreCase);
        return match.Groups["op"].Value == "==" ? equal : !equal;
    }

    private static List<string> SplitTopLevel(string expression, params string[] separators)
    {
        var parts = new List<string>();
        var start = 0; var depth = 0; var quoted = false;
        for (var i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '"' || expression[i] == '\'') quoted = !quoted;
            if (quoted) continue;
            if (expression[i] == '(') depth++;
            else if (expression[i] == ')') depth--;
            if (depth != 0) continue;
            foreach (var separator in separators)
            {
                if (i + separator.Length <= expression.Length && expression.AsSpan(i, separator.Length).Equals(separator.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    parts.Add(expression[start..i].Trim());
                    i += separator.Length - 1; start = i + 1; break;
                }
            }
        }
        if (start == 0) return new List<string> { expression };
        parts.Add(expression[start..].Trim());
        return parts;
    }

    private static string TrimOuterParentheses(string value)
    {
        while (value.Length >= 2 && value[0] == '(' && value[^1] == ')') value = value[1..^1].Trim();
        return value;
    }

    private bool HandleUnknown(string condition, CanonicalAction action)
    {
        return _settings.Framework.UnknownConditionPolicy.Trim().ToLowerInvariant() switch
        {
            "execute" => true,
            "fail" => throw new InvalidOperationException($"Canonical condition '{condition}' for action '{action.Id}' cannot be evaluated safely."),
            _ => LogAndSkip(condition, action)
        };
    }

    private static bool LogAndSkip(string condition, CanonicalAction action)
    {
        Log.Warning("Skipping action {ActionId}; the attached iteration does not provide a safely evaluable condition: {Condition}", action.Id, condition);
        return false;
    }
}
