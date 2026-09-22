#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.DataProfiles
{
    public sealed partial class SgsScenarioData
    {
        private const int MaximumTextLength = 65536;

        private string ResolveInput(string key, ResolutionScope scope)
        {
            var qualified = FindInputKey(key)
                ?? throw new SgsScenarioDataException($"Required SGS input '{key}' is absent.");
            var input = State.Inputs[qualified];
            if (!input.IsScalar)
                throw new SgsScenarioDataException($"Required SGS input '{qualified}' is not scalar.");

            scope.Enter("data:" + qualified);
            try
            {
                return ResolveText(input.Value, scope);
            }
            catch (SgsScenarioDataException exception)
            {
                throw new SgsScenarioDataException($"Required SGS input '{qualified}' is invalid: {exception.Message}");
            }
            finally
            {
                scope.Exit("data:" + qualified);
            }
        }

        private string ResolveBuffer(string key, ResolutionScope scope)
        {
            ValidateKey(key);
            if (IsCredentialKey(key))
                throw new SgsScenarioDataException("Credentials are not SGS capture buffers; use an explicit environment reference.");

            var token = NormalizeBufferKey(key) switch
            {
                "firstname" => "{{firstName}}",
                "lastname" => "{{lastName}}",
                "middlename" or "middleinitial" => "{{middleInitial}}",
                "dob" or "dateofbirth" => "{{randomDOB}}",
                "ownerphone" => "{{randomPhone}}",
                "owneremail" => "{{randomEmail}}",
                "insuredssn" or "ssn" => "{{randomSSN}}",
                _ => null
            };
            string? value;
            if (token is not null)
                value = RandomGenerators.ResolveRuntimeTokens(token, _context);
            else if (NormalizeBufferKey(key) is "quotenum" or "quotenumber" or "proposalnumber")
                value = _quoteHandoff.TryGet(out var quote) && quote is not null ? quote.QuoteNumber : null;
            else if (NormalizeBufferKey(key) is "effdate" or "effectivedate")
                value = _context.EffectiveDate;
            else if (!State.Captures.TryGetValue(key, out value))
                throw new SgsScenarioDataException($"Required SGS buffer '{key}' has not been captured.");

            RequireUsable(value);
            RejectExpressionMarkers(value!);
            return value!;
        }

        private string ResolveText(string? expression, ResolutionScope scope, bool allowEmpty = false)
        {
            scope.Step();
            if (expression is null)
                throw new SgsScenarioDataException("A required SGS input is null.");
            if (expression.Length > MaximumTextLength)
                throw new SgsScenarioDataException("SGS expression expansion exceeds the supported text length.");
            if (!allowEmpty)
                RequireUsable(expression);
            else if (IsPlaceholder(expression))
                throw new SgsScenarioDataException("An SGS expression argument is still a placeholder.");

            var result = new StringBuilder();
            for (var index = 0; index < expression.Length;)
            {
                if (expression[index] == '{')
                    result.Append(ReadExpression(expression, ref index, scope));
                else if (expression[index] == '}')
                    throw new SgsScenarioDataException("An SGS expression has an unmatched closing delimiter.");
                else
                    result.Append(expression[index++]);
                if (result.Length > MaximumTextLength)
                    throw new SgsScenarioDataException("SGS expression expansion exceeds the supported text length.");
            }
            var value = result.ToString();
            RejectExpressionMarkers(value);
            if (!allowEmpty)
                RequireUsable(value);
            return value;
        }

        private string ReadExpression(string expression, ref int index, ResolutionScope scope)
        {
            if (index + 1 < expression.Length && expression[index + 1] == '{')
            {
                var end = expression.IndexOf("}}", index + 2, StringComparison.Ordinal);
                if (end < 0)
                    throw new SgsScenarioDataException("An SGS expression has an unmatched opening delimiter.");
                var body = expression[(index + 2)..end];
                index = end + 2;
                return ResolveToken(body, scope);
            }

            var start = ++index;
            while (index < expression.Length && char.IsAsciiLetter(expression[index]))
                index++;
            var operation = expression[start..index].ToUpperInvariant();
            var count = operation switch
            {
                "B" or "PL" or "STRINGTOUPPER" => 1,
                "STRINGREPLACE" or "DATE" => 3,
                _ => throw new SgsScenarioDataException("An unsupported SGS source expression was requested.")
            };
            var arguments = new string[count];
            for (var number = 0; number < count; number++)
                arguments[number] = ReadArgument(expression, ref index);
            if (index >= expression.Length || expression[index++] != '}')
                throw new SgsScenarioDataException("An SGS source expression has invalid arguments or delimiters.");

            if (operation == "B")
                return ResolveBufferOrInput(Unquote(arguments[0]), scope);
            if (operation == "PL")
                return ResolveBufferOrInput(Unquote(arguments[0]), scope);
            for (var number = 0; number < count; number++)
                arguments[number] = ResolveText(Unquote(arguments[number]), scope, allowEmpty: true);

            return operation switch
            {
                "STRINGTOUPPER" => arguments[0].ToUpperInvariant(),
                "STRINGREPLACE" => ReplaceText(arguments),
                "DATE" => ResolveDate(arguments),
                _ => throw new SgsScenarioDataException("An unsupported SGS source expression was requested.")
            };
        }

        private string ResolveToken(string body, ResolutionScope scope)
        {
            var colon = body.IndexOf(':');
            if (colon < 0)
            {
                var token = "{{" + body + "}}";
                var value = RandomGenerators.ResolveRuntimeTokens(token, _context);
                if (value == token)
                    throw new SgsScenarioDataException("An unsupported runtime identity token was requested; SGS random-pattern generation is not enabled.");
                RequireUsable(value);
                RejectExpressionMarkers(value);
                return value;
            }
            var name = body[(colon + 1)..];
            return body[..colon].ToLowerInvariant() switch
            {
                "data" or "external" => ResolveInput(name, scope),
                "runtime" or "buffer" => ResolveBufferOrInput(name, scope),
                "env" => ReadEnvironment(name),
                _ => throw new SgsScenarioDataException("An unsupported SGS expression namespace was requested.")
            };
        }

        private string ResolveBufferOrInput(string key, ResolutionScope scope)
        {
            ValidateKey(key);
            var normalized = NormalizeBufferKey(key);
            if (State.Captures.ContainsKey(key) ||
                normalized is "quotenum" or "quotenumber" or "proposalnumber" or
                    "firstname" or "lastname" or "middlename" or "middleinitial" or
                    "dob" or "dateofbirth" or "ownerphone" or "owneremail" or "insuredssn" or
                    "ssn" or "effdate" or "effectivedate")
            {
                return ResolveBuffer(key, scope);
            }
            return ResolveInput(key, scope);
        }

        private static string ReadEnvironment(string name)
        {
            if (!Regex.IsMatch(name, @"\A[A-Za-z_][A-Za-z0-9_]*\z"))
                throw new SgsScenarioDataException("An SGS environment reference has an invalid variable name.");
            var value = Environment.GetEnvironmentVariable(name);
            RequireUsable(value);
            RejectExpressionMarkers(value!);
            return value!;
        }

        private static string ReadArgument(string expression, ref int index)
        {
            if (index >= expression.Length || expression[index++] != '[')
                throw new SgsScenarioDataException("An SGS source expression requires bracketed arguments.");
            var start = index;
            var depth = 1;
            var quote = '\0';
            var atStart = true;
            while (index < expression.Length)
            {
                var character = expression[index++];
                if (quote != '\0')
                {
                    if (character == quote && (index < 2 || expression[index - 2] != '\\'))
                        quote = '\0';
                    continue;
                }
                if (atStart && char.IsWhiteSpace(character))
                    continue;
                if (atStart && character is '"' or '\'')
                    quote = character;
                atStart = false;
                if (character == '[')
                {
                    depth++;
                    atStart = true;
                }
                if (character == ']' && --depth == 0)
                    return expression[start..(index - 1)];
            }
            throw new SgsScenarioDataException("An SGS source expression has an unterminated argument.");
        }

        private static string Unquote(string value)
        {
            var text = value.Trim();
            if (text.Length > 0 && text[0] is '"' or '\'')
            {
                if (text.Length < 2 || text[^1] != text[0])
                    throw new SgsScenarioDataException("An SGS expression argument has mismatched quotes.");
                return text[1..^1];
            }
            return text;
        }

        private static string ReplaceText(string[] arguments)
        {
            var oldValue = arguments[1].Replace("\\)", ")", StringComparison.Ordinal);
            if (oldValue.Length == 0)
                throw new SgsScenarioDataException("SGS STRINGREPLACE requires a nonempty search argument.");
            long length = arguments[0].Length;
            for (var index = 0; (index = arguments[0].IndexOf(oldValue, index, StringComparison.Ordinal)) >= 0; index += oldValue.Length)
            {
                length += arguments[2].Length - oldValue.Length;
                if (length > MaximumTextLength)
                    throw new SgsScenarioDataException("SGS STRINGREPLACE exceeds the supported text length.");
            }
            return arguments[0].Replace(oldValue, arguments[2], StringComparison.Ordinal);
        }

        private string ResolveDate(string[] arguments)
        {
            var date = State.ReferenceDate;
            string[] formats = ["MM/dd/yyyy", "MM-dd-yyyy", "yyyy-MM-dd", "yyyyMMdd"];
            if (arguments[0].Length != 0 &&
                !DateTime.TryParseExact(arguments[0], formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new SgsScenarioDataException("An SGS DATE base is invalid; it is not replaced by today's date.");
            }
            if (arguments[1].Length != 0)
            {
                var offset = Regex.Match(arguments[1], @"\A([+-]?\d+)\s*([dmy])\z", RegexOptions.IgnoreCase);
                if (!offset.Success || !int.TryParse(offset.Groups[1].Value, CultureInfo.InvariantCulture, out var amount))
                    throw new SgsScenarioDataException("An SGS DATE offset must be an integer followed by d, m or y.");
                try
                {
                    date = offset.Groups[2].Value.ToLowerInvariant() switch
                    {
                        "d" => date.AddDays(amount),
                        "m" => date.AddMonths(amount),
                        "y" => date.AddYears(amount),
                        _ => throw new SgsScenarioDataException("An SGS DATE offset unit is unsupported.")
                    };
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new SgsScenarioDataException("An SGS DATE offset exceeds the supported calendar range.");
                }
            }
            var format = arguments[2].Length == 0 ? "MM-dd-yyyy" : arguments[2];
            if (Array.IndexOf(formats, format) < 0)
                throw new SgsScenarioDataException("An SGS DATE output format is unsupported.");
            return date.ToString(format, CultureInfo.InvariantCulture);
        }

        private static bool IsPlaceholder(string value) =>
            value.Contains("SYNTHETIC_REPLACE_ME", StringComparison.OrdinalIgnoreCase) ||
            Regex.IsMatch(value.Trim(), @"\A(?:PLACEHOLDER|REPLACE_ME|TODO|TBD|<[^<>]+>)\z", RegexOptions.IgnoreCase);

        private static void RequireUsable(string? value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim() is "\"\"" or "''" || IsPlaceholder(value))
                throw new SgsScenarioDataException("A required SGS value is absent, empty or still a placeholder; supply reviewed business data.");
            if (value.Length > MaximumTextLength)
                throw new SgsScenarioDataException("A required SGS value exceeds the supported text length.");
        }

        private static void RejectExpressionMarkers(string value)
        {
            if (value.IndexOfAny(['{', '}']) >= 0)
                throw new SgsScenarioDataException("An SGS value still contains an unsupported or unresolved expression.");
        }

        private sealed class ResolutionScope
        {
            private readonly HashSet<string> _active = new(StringComparer.OrdinalIgnoreCase);
            private int _steps;

            internal void Enter(string key)
            {
                if (_active.Count >= 32 || !_active.Add(key))
                    throw new SgsScenarioDataException("SGS data contains a cyclic reference or exceeds the 32-reference depth limit.");
            }

            internal void Exit(string key) => _active.Remove(key);

            internal void Step()
            {
                if (++_steps > 256)
                    throw new SgsScenarioDataException("SGS expression expansion exceeds the 256-step limit.");
            }
        }
    }
}
