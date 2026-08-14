using System.Globalization;
using System.Text.RegularExpressions;
using ToscaArtifactAutomation.Core.Runtime;

namespace ToscaArtifactAutomation.Core.Utils;

public sealed class ToscaExpressionResolver
{
    private static readonly Regex BufferRegex = new(@"\{(?:X?B)\[(?<key>[^\]]+)\]\}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex RandomDigitsRegex = new(@"\{RND\[(?<count>\d+)\]\}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private static readonly Regex RandomRegexRegex = new("\\{RANDOMREGEX\\[\\\"(?<pattern>(?:\\\\.|[^\\\"])*)\\\"\\]\\}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly RandomDataService _random;

    public ToscaExpressionResolver(RandomDataService random) => _random = random ?? throw new ArgumentNullException(nameof(random));

    public string Resolve(string expression, ScenarioDataContext data)
    {
        ArgumentNullException.ThrowIfNull(data);
        if (string.IsNullOrEmpty(expression)) return string.Empty;
        var value = expression.Replace("{NULL}", string.Empty, StringComparison.OrdinalIgnoreCase);
        value = Regex.Replace(value, @"\$\{COMPUTERNAME\}|\{COMPUTERNAME\}", Environment.MachineName, RegexOptions.IgnoreCase);
        value = Regex.Replace(value, "\"\"\"(?<inner>[^\"]*)\"\"\"", m => "\"" + m.Groups["inner"].Value + "\"");
        value = BufferRegex.Replace(value, m => data.GetRuntimeRequired(m.Groups["key"].Value.Trim()));
        value = RandomDigitsRegex.Replace(value, m => _random.Digits(int.Parse(m.Groups["count"].Value, CultureInfo.InvariantCulture)));
        value = RandomRegexRegex.Replace(value, m => _random.Generate(Regex.Unescape(m.Groups["pattern"].Value)));
        value = ResolveDateExpressions(value);
        value = value.Replace("{NMONTH}", DateTime.Today.Month.ToString(CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase)
                     .Replace("{NDAY}", DateTime.Today.Day.ToString(CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase)
                     .Replace("{NYEAR}", DateTime.Today.Year.ToString(CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase)
                     .Replace("{TIME}", DateTime.Now.ToString("HHmmss", CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase);
        value = ResolveUnaryStringFunction(value, "STRINGTOUPPER", x => x.ToUpperInvariant());
        value = ResolveUnaryStringFunction(value, "STRINGTOLOWER", x => x.ToLowerInvariant());
        value = ResolveStringReplace(value);
        value = ResolveMath(value);
        return value;
    }

    private static string ResolveDateExpressions(string value)
    {
        var start = value.IndexOf("{DATE", StringComparison.OrdinalIgnoreCase);
        while (start >= 0)
        {
            var end = FindBalanced(value, start, '{', '}');
            if (end < 0) break;
            var token = value[start..(end + 1)];
            var inside = token[1..^1];
            var groups = Regex.Matches(inside, @"\[([^\]]*)\]").Select(x => x.Groups[1].Value).ToArray();
            var date = DateTime.Today;
            string format = "MM-dd-yyyy";
            if (groups.Length > 0 && !string.IsNullOrWhiteSpace(groups[0]) && DateTime.TryParse(groups[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed)) date = parsed;
            foreach (var group in groups.Skip(1))
            {
                if (Regex.IsMatch(group, @"^[+-]\d+[dmy]$", RegexOptions.IgnoreCase)) date = ApplyOffset(date, group);
                else if (!string.IsNullOrWhiteSpace(group)) format = group.Replace("'", string.Empty, StringComparison.Ordinal);
            }
            value = value.Replace(token, date.ToString(ToDotNetDateFormat(format), CultureInfo.InvariantCulture), StringComparison.Ordinal);
            start = value.IndexOf("{DATE", StringComparison.OrdinalIgnoreCase);
        }
        return value.Replace("{DATE}", DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase);
    }

    private static DateTime ApplyOffset(DateTime date, string offset)
    {
        var amount = int.Parse(offset[..^1], CultureInfo.InvariantCulture);
        return char.ToLowerInvariant(offset[^1]) switch { 'd' => date.AddDays(amount), 'm' => date.AddMonths(amount), 'y' => date.AddYears(amount), _ => date };
    }

    private static string ResolveUnaryStringFunction(string value, string function, Func<string, string> transform)
    {
        var prefix = "{" + function + "[";
        var start = value.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
        while (start >= 0)
        {
            var end = FindBalanced(value, start, '{', '}'); if (end < 0) break;
            var token = value[start..(end + 1)]; var inner = token[(prefix.Length)..^2];
            value = value.Replace(token, transform(inner), StringComparison.Ordinal);
            start = value.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
        }
        return value;
    }

    private static string ResolveStringReplace(string value)
    {
        var prefix = "{STRINGREPLACE[";
        var start = value.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
        while (start >= 0)
        {
            var end = FindBalanced(value, start, '{', '}'); if (end < 0) break;
            var token = value[start..(end + 1)];
            var parts = Regex.Matches(token, @"\[([^\]]*)\]").Select(x => x.Groups[1].Value.Trim('"')).ToArray();
            if (parts.Length < 3) break;
            value = value.Replace(token, parts[0].Replace(parts[1], parts[2], StringComparison.Ordinal), StringComparison.Ordinal);
            start = value.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
        }
        return value;
    }

    private static string ResolveMath(string value)
    {
        var match = Regex.Match(value, @"\{(?:MATH|CALC)\[(?<left>-?\d+(?:\.\d+)?)\s*(?<op>[+\-*/])\s*(?<right>-?\d+(?:\.\d+)?)\]\}", RegexOptions.IgnoreCase);
        while (match.Success)
        {
            var left = decimal.Parse(match.Groups["left"].Value, CultureInfo.InvariantCulture);
            var right = decimal.Parse(match.Groups["right"].Value, CultureInfo.InvariantCulture);
            var result = match.Groups["op"].Value switch { "+" => left + right, "-" => left - right, "*" => left * right, "/" when right != 0 => left / right, _ => left };
            value = value.Replace(match.Value, result.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal);
            match = Regex.Match(value, @"\{(?:MATH|CALC)\[(?<left>-?\d+(?:\.\d+)?)\s*(?<op>[+\-*/])\s*(?<right>-?\d+(?:\.\d+)?)\]\}", RegexOptions.IgnoreCase);
        }
        return value;
    }

    private static int FindBalanced(string value, int start, char open, char close)
    {
        var depth = 0;
        for (var i = start; i < value.Length; i++) { if (value[i] == open) depth++; else if (value[i] == close && --depth == 0) return i; }
        return -1;
    }

    private static string ToDotNetDateFormat(string format) => format.Replace("YYYY", "yyyy", StringComparison.Ordinal).Replace("DD", "dd", StringComparison.Ordinal);
}
