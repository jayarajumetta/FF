// Tools/LocatorScan/RepoLocatorInventory.cs
#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PnCTestAutomation.Tools.LocatorScan
{
    // ──────────────────────────────────────────────────────────────────────
    // Model
    // ──────────────────────────────────────────────────────────────────────
    public sealed class ExistingLocator
    {
        public string CanonicalKey { get; set; } = string.Empty;
        public string Strategy { get; set; } = string.Empty;    // GetByTestId, GetByRole, GetByLabel, GetByPlaceholder, GetByText, CssId
        public string? Role { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? Id { get; set; }
        public string CodeSnippet { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
        public string Pattern { get; set; } = string.Empty;     // StaticMethod, Property, Constant, Factory
    }

    // ──────────────────────────────────────────────────────────────────────
    // Inventory builder
    // ──────────────────────────────────────────────────────────────────────
    public sealed class RepoLocatorInventory
    {
        // ── Regex patterns for locator expressions ──

        // Static method: public static ILocator Name(IPage page) => page.XYZ(...);
        private static readonly Regex StaticMethodPattern = new(
            @"public\s+static\s+ILocator\s+(\w+)\s*\(\s*IPage\s+\w+\s*\)\s*=>\s*\w+\.([\s\S]+?);",
            RegexOptions.Compiled | RegexOptions.Multiline);

        // Property getter: private/public ILocator Name => _page.XYZ(...);
        private static readonly Regex PropertyPattern = new(
            @"(?:public|private|internal|protected)\s+ILocator\s+(\w+)\s*=>\s*_?\w+\.([\s\S]+?);",
            RegexOptions.Compiled | RegexOptions.Multiline);

        // ── Regex patterns for locator strategies ──

        private static readonly Regex GetByTestIdRx = new(
            @"GetByTestId\(\s*""([^""]+)""\s*\)",
            RegexOptions.Compiled);

        private static readonly Regex GetByRoleRx = new(
            @"GetByRole\(\s*AriaRole\.(\w+)\s*(?:,\s*new\s*\(\s*\)\s*\{\s*Name\s*=\s*""([^""]+)""\s*(?:,\s*Exact\s*=\s*\w+\s*)?\})?\s*\)",
            RegexOptions.Compiled);

        private static readonly Regex GetByLabelRx = new(
            @"GetByLabel\(\s*""([^""]+)""\s*\)",
            RegexOptions.Compiled);

        private static readonly Regex GetByPlaceholderRx = new(
            @"GetByPlaceholder\(\s*""([^""]+)""\s*\)",
            RegexOptions.Compiled);

        private static readonly Regex GetByTextRx = new(
            @"GetByText\(\s*""([^""]+)""\s*(?:,\s*new\s*\(\s*\)\s*\{[^}]*\})?\s*\)",
            RegexOptions.Compiled);

        private static readonly Regex GetByTitleRx = new(
            @"GetByTitle\(\s*""([^""]+)""\s*\)",
            RegexOptions.Compiled);

        private static readonly Regex LocatorIdRx = new(
            @"Locator\(\s*""#([^""]+)""\s*\)",
            RegexOptions.Compiled);

        // Class declaration (to track current class name)
        private static readonly Regex ClassDeclRx = new(
            @"(?:public|internal|private|static)\s+(?:static\s+)?class\s+(\w+)",
            RegexOptions.Compiled);

        // String constants: public const string Name = "xpath=...";
        private static readonly Regex ConstStringRx = new(
            @"public\s+const\s+string\s+(\w+)\s*=\s*""([^""]+)""",
            RegexOptions.Compiled);

        // Factory methods: public static ILocator GetSomething(IPage page, string param)
        private static readonly Regex FactoryMethodRx = new(
            @"public\s+static\s+(?:ILocator|string)\s+(\w+)\s*\([^)]*IPage[^)]*\)",
            RegexOptions.Compiled);

        // ── Public API ──

        public Task<List<ExistingLocator>> BuildAsync(string repoRoot, CancellationToken ct = default)
        {
            var results = new List<ExistingLocator>();

            // Folders to scan
            var foldersToScan = new[] { "Locators", "Pages" };
            foreach (var folder in foldersToScan)
            {
                var dir = Path.Combine(repoRoot, folder);
                if (!Directory.Exists(dir))
                    continue;

                var csFiles = Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories);
                foreach (var file in csFiles)
                {
                    ct.ThrowIfCancellationRequested();
                    var relativePath = Path.GetRelativePath(repoRoot, file).Replace('\\', '/');
                    var content = File.ReadAllText(file);
                    ParseFile(content, relativePath, results);
                }
            }

            // Optional: StepDefinitions (best-effort)
            var stepsDir = Path.Combine(repoRoot, "StepDefinitions");
            if (Directory.Exists(stepsDir))
            {
                var csFiles = Directory.GetFiles(stepsDir, "*.cs", SearchOption.AllDirectories);
                foreach (var file in csFiles)
                {
                    ct.ThrowIfCancellationRequested();
                    var relativePath = Path.GetRelativePath(repoRoot, file).Replace('\\', '/');
                    var content = File.ReadAllText(file);
                    ParseFile(content, relativePath, results);
                }
            }

            return Task.FromResult(results);
        }

        /// <summary>Write the inventory to JSON for artifact output.</summary>
        public async Task WriteJsonAsync(List<ExistingLocator> inventory, string path, CancellationToken ct = default)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            var jsonOpts = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(inventory, jsonOpts);
            await File.WriteAllTextAsync(path, json, System.Text.Encoding.UTF8, ct);
        }

        // ── Canonical key ──

        public static string ToCanonicalKey(string strategy, string? role, string? nameOrValue, string? id = null)
        {
            var parts = new List<string> { Normalize(strategy) };
            if (!string.IsNullOrWhiteSpace(role))
                parts.Add("role=" + Normalize(role));
            if (!string.IsNullOrWhiteSpace(nameOrValue))
                parts.Add("val=" + Normalize(nameOrValue));
            if (!string.IsNullOrWhiteSpace(id))
                parts.Add("id=" + Normalize(id));
            return string.Join("|", parts);
        }

        // ── Parsing ──

        private void ParseFile(string content, string relativePath, List<ExistingLocator> results)
        {
            // Track the current class name
            string currentClass = "Unknown";

            // Split by line and track class context
            var lines = content.Split('\n');
            var lineIndex = 0;
            foreach (var line in lines)
            {
                lineIndex++;
                var cm = ClassDeclRx.Match(line);
                if (cm.Success)
                    currentClass = cm.Groups[1].Value;
            }

            // Now parse with regex over full content, using class context
            // Re-derive current class per match position
            var classRanges = new List<(int Start, string Name)>();
            foreach (Match cm in ClassDeclRx.Matches(content))
                classRanges.Add((cm.Index, cm.Groups[1].Value));

            string ClassAt(int pos)
            {
                string name = "Unknown";
                foreach (var (start, n) in classRanges)
                {
                    if (start <= pos) name = n;
                    else break;
                }
                return name;
            }

            // Static methods
            foreach (Match m in StaticMethodPattern.Matches(content))
            {
                var memberName = m.Groups[1].Value;
                var expr = m.Groups[2].Value.Trim();
                var cls = ClassAt(m.Index);
                var loc = ParseLocatorExpression(expr, relativePath, cls, memberName, "StaticMethod");
                if (loc is not null)
                    results.Add(loc);
            }

            // Properties
            foreach (Match m in PropertyPattern.Matches(content))
            {
                var memberName = m.Groups[1].Value;
                var expr = m.Groups[2].Value.Trim();
                var cls = ClassAt(m.Index);
                var loc = ParseLocatorExpression(expr, relativePath, cls, memberName, "Property");
                if (loc is not null)
                    results.Add(loc);
            }

            // Constants: public const string Name = "xpath=...";
            foreach (Match m in ConstStringRx.Matches(content))
            {
                var memberName = m.Groups[1].Value;
                var selectorValue = m.Groups[2].Value;
                var cls = ClassAt(m.Index);

                // Determine strategy from selector prefix
                var strategy = "css";
                var cleanSelector = selectorValue;
                if (selectorValue.StartsWith("xpath="))
                {
                    strategy = "xpath";
                    cleanSelector = selectorValue.Substring(6);
                }
                else if (selectorValue.StartsWith("css="))
                {
                    strategy = "css";
                    cleanSelector = selectorValue.Substring(4);
                }

                results.Add(new ExistingLocator
                {
                    Strategy = strategy,
                    Text = cleanSelector,
                    CanonicalKey = ToCanonicalKey(strategy, null, cleanSelector),
                    CodeSnippet = $"const string {memberName} = \"{selectorValue}\"",
                    FilePath = relativePath,
                    ClassName = cls,
                    MemberName = memberName,
                    Pattern = "Constant"
                });
            }

            // Factory Methods: public static ILocator GetSomething(IPage page, string param)
            foreach (Match m in FactoryMethodRx.Matches(content))
            {
                var memberName = m.Groups[1].Value;
                var cls = ClassAt(m.Index);

                results.Add(new ExistingLocator
                {
                    Strategy = "factory",
                    Text = "parameterized",
                    CanonicalKey = ToCanonicalKey("factory", null, memberName),
                    CodeSnippet = m.Value,
                    FilePath = relativePath,
                    ClassName = cls,
                    MemberName = memberName,
                    Pattern = "Factory"
                });
            }
        }

        private ExistingLocator? ParseLocatorExpression(string expr, string filePath, string className, string memberName, string pattern)
        {
            // Try each strategy regex
            Match m;

            m = GetByTestIdRx.Match(expr);
            if (m.Success)
            {
                var val = m.Groups[1].Value;
                return new ExistingLocator
                {
                    Strategy = "GetByTestId",
                    Text = val,
                    CanonicalKey = ToCanonicalKey("GetByTestId", null, val),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            m = GetByRoleRx.Match(expr);
            if (m.Success)
            {
                var role = m.Groups[1].Value;
                var name = m.Groups[2].Success ? m.Groups[2].Value : null;
                return new ExistingLocator
                {
                    Strategy = "GetByRole",
                    Role = role,
                    Name = name,
                    CanonicalKey = ToCanonicalKey("GetByRole", role, name),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            m = GetByLabelRx.Match(expr);
            if (m.Success)
            {
                var val = m.Groups[1].Value;
                return new ExistingLocator
                {
                    Strategy = "GetByLabel",
                    Text = val,
                    CanonicalKey = ToCanonicalKey("GetByLabel", null, val),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            m = GetByPlaceholderRx.Match(expr);
            if (m.Success)
            {
                var val = m.Groups[1].Value;
                return new ExistingLocator
                {
                    Strategy = "GetByPlaceholder",
                    Text = val,
                    CanonicalKey = ToCanonicalKey("GetByPlaceholder", null, val),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            m = GetByTextRx.Match(expr);
            if (m.Success)
            {
                var val = m.Groups[1].Value;
                return new ExistingLocator
                {
                    Strategy = "GetByText",
                    Text = val,
                    CanonicalKey = ToCanonicalKey("GetByText", null, val),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            m = GetByTitleRx.Match(expr);
            if (m.Success)
            {
                var val = m.Groups[1].Value;
                return new ExistingLocator
                {
                    Strategy = "GetByTitle",
                    Text = val,
                    CanonicalKey = ToCanonicalKey("GetByTitle", null, val),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            m = LocatorIdRx.Match(expr);
            if (m.Success)
            {
                var val = m.Groups[1].Value;
                return new ExistingLocator
                {
                    Strategy = "CssId",
                    Id = val,
                    CanonicalKey = ToCanonicalKey("CssId", null, null, val),
                    CodeSnippet = expr,
                    FilePath = filePath,
                    ClassName = className,
                    MemberName = memberName,
                    Pattern = pattern
                };
            }

            // Skip deep CSS/XPath
            return null;
        }

        private static string Normalize(string s) =>
            Regex.Replace((s ?? "").Trim(), @"\s+", " ").ToLowerInvariant();
    }
}
