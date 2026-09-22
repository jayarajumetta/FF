#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace PnCTestAutomation.Reporting;

public sealed class ReportRedactor
{
    public const string Mask = "[REDACTED]";
    private const string CredentialNames =
        @"password|passwd|pwd|secret|token|authorization|api[_ -]?key|client[_ -]?secret|" +
        @"cookie|connection[_ -]?string|user[_ -]?name";
    private const string PersonalNames =
        @"email|e-mail|phone|ssn|" +
        @"social[_ -]?security|date[_ -]?of[_ -]?birth|birth[_ -]?date|dob|" +
        @"first[_ -]?name|last[_ -]?name|insured[_ -]?name|street|address";
    private static readonly Regex SensitiveKey = new(
        CredentialNames + "|" + PersonalNames, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant |
        RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private static readonly Regex[] NamedValues =
        [AssignmentPattern(CredentialNames), AssignmentPattern(PersonalNames)];
    private static readonly Regex Authorization = new(
        @"\b(?:Bearer|Basic)\s+[A-Za-z0-9+/=_\-.]+",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant |
        RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private static readonly Regex Url = new(
        @"https?://[^\s<>""']+",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant |
        RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private static readonly Regex Email = new(
        @"\b[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}\b",
        RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private static readonly Regex Jwt = new(
        @"\beyJ[A-Za-z0-9_-]+\.eyJ[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+",
        RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private static readonly Regex SocialSecurity = new(
        @"\b\d{3}-\d{2}-\d{4}\b",
        RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private static readonly Regex XmlValue = new(
        @"(?<open><(?<name>[A-Za-z_][\w:.-]*)\s*>)[^<]*(?<close></[A-Za-z_][\w:.-]*\s*>)",
        RegexOptions.CultureInvariant | RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
    private readonly ImmutableArray<string> _sensitiveValues;

    public ReportRedactor(IEnumerable<string>? sensitiveValues = null)
    {
        _sensitiveValues = (sensitiveValues ?? [])
            .Where(value => !string.IsNullOrEmpty(value))
            .Distinct(StringComparer.Ordinal)
            .OrderByDescending(value => value.Length)
            .ToImmutableArray();
    }

    public string Text(string? value)
    {
        var text = value ?? "";
        foreach (var secret in _sensitiveValues)
            text = text.Replace(secret, Mask, StringComparison.Ordinal);

        text = Url.Replace(text, match =>
        {
            if (!Uri.TryCreate(match.Value, UriKind.Absolute, out var uri))
                return "[invalid URL]";
            return uri.GetComponents(
                UriComponents.SchemeAndServer | UriComponents.Path,
                UriFormat.UriEscaped) +
                (uri.Query.Length > 0 || uri.Fragment.Length > 0 ? "?[REDACTED]" : "");
        });
        foreach (var pattern in NamedValues)
            text = pattern.Replace(text, match =>
            {
                var value = match.Groups["value"].Value;
                var quote = value.Length > 0 && value[0] is '"' or '\'' ? value[..1] : "";
                return match.Groups["key"].Value + quote + Mask + quote;
            });
        text = Authorization.Replace(text, Mask);
        text = Email.Replace(text, Mask);
        text = Jwt.Replace(text, Mask);
        text = SocialSecurity.Replace(text, Mask);
        text = XmlValue.Replace(text, match => SensitiveKey.IsMatch(match.Groups["name"].Value)
            ? match.Groups["open"].Value + Mask + match.Groups["close"].Value : match.Value);
        return new string(text.Where(character =>
            !char.IsControl(character) || character is '\r' or '\n' or '\t').ToArray());
    }

    public string Value(string key, string? value) =>
        SensitiveKey.IsMatch(key) ? Mask : Text(value);

    public ImmutableDictionary<string, string> Data(
        ImmutableDictionary<string, string> values) =>
        values.ToImmutableDictionary(
            pair => Text(pair.Key),
            pair => Value(pair.Key, pair.Value),
            StringComparer.Ordinal);

    private static Regex AssignmentPattern(string names) => new(
        @"(?<key>\b[\w.-]*(?:" + names + @")[\w .-]*[""']?\s*[:=]\s*)" +
        @"(?<value>""(?:\\.|[^""\\])*""|'(?:\\.|[^'\\])*'|[^,;\r\n]+)",
        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant |
        RegexOptions.NonBacktracking, TimeSpan.FromSeconds(1));
}
