using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using ToscaArtifactAutomation.Core.Runtime;

namespace ToscaArtifactAutomation.Core.Utils;

public sealed class RandomDataService
{
    public void GenerateAll(ScenarioDataContext data)
    {
        ArgumentNullException.ThrowIfNull(data);
        foreach (var item in data.RandomDefinitions.OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase))
        {
            if (data.TryGetRuntime(item.Key, out _))
                continue;
            data.SetRuntime(item.Key, Generate(item.Value.Pattern));
        }
    }

    public string Generate(string? pattern)
    {
        pattern = string.IsNullOrWhiteSpace(pattern) ? "[A-Za-z0-9]{10}" : pattern.Trim();
        pattern = pattern.Trim('^', '$').Replace("\\.", ".", StringComparison.Ordinal);
        var output = new StringBuilder();
        for (var i = 0; i < pattern.Length;)
        {
            if (pattern[i] == '[')
            {
                var end = pattern.IndexOf(']', i + 1);
                if (end > i)
                {
                    var characterClass = pattern[(i + 1)..end];
                    var count = 1;
                    var next = end + 1;
                    if (next < pattern.Length && pattern[next] == '{')
                    {
                        var close = pattern.IndexOf('}', next + 1);
                        if (close > next && int.TryParse(pattern[(next + 1)..close], out var parsed))
                        {
                            count = Math.Max(1, parsed);
                            next = close + 1;
                        }
                    }
                    var alphabet = Alphabet(characterClass);
                    for (var j = 0; j < count; j++) output.Append(alphabet[RandomNumberGenerator.GetInt32(alphabet.Length)]);
                    i = next;
                    continue;
                }
            }
            if (pattern[i] == '\\' && i + 1 < pattern.Length)
            {
                output.Append(pattern[i + 1]); i += 2; continue;
            }
            output.Append(pattern[i]); i++;
        }
        return output.ToString();
    }

    public string Digits(int length)
    {
        if (length <= 0) return string.Empty;
        var chars = new char[length];
        for (var i = 0; i < length; i++) chars[i] = (char)('0' + RandomNumberGenerator.GetInt32(10));
        return new string(chars);
    }

    private static string Alphabet(string characterClass)
    {
        var output = new StringBuilder();
        if (characterClass.Contains("A-Z", StringComparison.Ordinal)) output.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        if (characterClass.Contains("a-z", StringComparison.Ordinal)) output.Append("abcdefghijklmnopqrstuvwxyz");
        if (characterClass.Contains("0-9", StringComparison.Ordinal)) output.Append("0123456789");
        if (output.Length == 0)
        {
            foreach (var c in characterClass.Where(char.IsLetterOrDigit)) output.Append(c);
        }
        return output.Length == 0 ? "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" : output.ToString();
    }
}
