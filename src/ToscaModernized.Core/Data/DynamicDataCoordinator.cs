using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using ToscaModernized.Core.Models;

namespace ToscaModernized.Core.Data;

public sealed class DynamicDataCoordinator
{
    private readonly RunDataContext _runData;

    public DynamicDataCoordinator(RunDataContext runData) => _runData = runData;

    public string? Prepare(PlanInstruction instruction)
    {
        ArgumentNullException.ThrowIfNull(instruction);
        if (!string.Equals(instruction.Operation, "GenerateRandom", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        var alias = string.IsNullOrWhiteSpace(instruction.Alias)
            ? $"Random_{instruction.Id.Replace('-', '_')}"
            : instruction.Alias;
        var pattern = string.IsNullOrWhiteSpace(instruction.Pattern) ? "[A-Z0-9]{10}" : instruction.Pattern;
        var value = RegexPatternGenerator.Generate(pattern);
        _runData.Set(alias, value);
        return value;
    }

    private static class RegexPatternGenerator
    {
        public static string Generate(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                return Guid.NewGuid().ToString("N")[..10].ToUpperInvariant();
            }

            var output = new StringBuilder();
            for (var i = 0; i < pattern.Length; i++)
            {
                var ch = pattern[i];
                if (ch == '\\' && i + 1 < pattern.Length)
                {
                    var escaped = pattern[++i];
                    output.Append(escaped switch
                    {
                        'd' => RandomCharacter("0123456789"),
                        'w' => RandomCharacter("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_"),
                        _ => escaped
                    });
                    continue;
                }
                if (ch == '[')
                {
                    var end = pattern.IndexOf(']', i + 1);
                    if (end < 0) break;
                    var characters = ExpandCharacterClass(pattern[(i + 1)..end]);
                    var count = ReadCount(pattern, end + 1, out var newIndex);
                    for (var n = 0; n < count; n++) output.Append(RandomCharacter(characters));
                    i = newIndex;
                    continue;
                }
                if (ch == '{')
                {
                    // A quantifier is consumed together with its preceding token.
                    var end = pattern.IndexOf('}', i + 1);
                    i = end >= 0 ? end : i;
                    continue;
                }
                if ("()^$?+*|".Contains(ch))
                {
                    continue;
                }
                var literalCount = ReadCount(pattern, i + 1, out var literalIndex);
                for (var n = 0; n < literalCount; n++) output.Append(ch == '.' ? RandomCharacter("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789") : ch);
                i = literalIndex;
            }
            return output.Length == 0 ? Guid.NewGuid().ToString("N")[..10].ToUpperInvariant() : output.ToString();
        }

        private static int ReadCount(string pattern, int index, out int newIndex)
        {
            newIndex = index - 1;
            if (index >= pattern.Length || pattern[index] != '{') return 1;
            var end = pattern.IndexOf('}', index + 1);
            if (end < 0) return 1;
            var body = pattern[(index + 1)..end].Split(',')[0];
            newIndex = end;
            return int.TryParse(body, out var count) ? Math.Clamp(count, 0, 256) : 1;
        }

        private static string ExpandCharacterClass(string body)
        {
            var output = new StringBuilder();
            for (var i = 0; i < body.Length; i++)
            {
                if (i + 2 < body.Length && body[i + 1] == '-')
                {
                    for (var c = body[i]; c <= body[i + 2]; c++) output.Append(c);
                    i += 2;
                }
                else
                {
                    output.Append(body[i]);
                }
            }
            return output.Length == 0 ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" : output.ToString();
        }

        private static char RandomCharacter(string characters)
        {
            var index = RandomNumberGenerator.GetInt32(characters.Length);
            return characters[index];
        }
    }
}
