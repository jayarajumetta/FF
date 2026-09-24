#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Controls
{
    public sealed class FrameScopeHintOptions
    {
        public string? CatalogPath { get; set; }
        public List<string> AdditionalCatalogPaths { get; set; } = [];

        public void Validate()
        {
            if (AdditionalCatalogPaths == null)
            {
                throw new FrameScopeConfigurationException(
                    "Additional frame hint catalog paths cannot be null.");
            }
            var paths = GetCatalogPaths();
            if (paths.Count == 0)
                throw new FrameScopeConfigurationException(
                    "At least one explicit approved frame scope catalog must be configured.");
            if (paths.Any(path =>
                    string.IsNullOrWhiteSpace(path) ||
                    !Path.GetExtension(path).Equals(
                        ".json",
                        StringComparison.OrdinalIgnoreCase)))
            {
                throw new FrameScopeConfigurationException(
                    "Every frame hint catalog path must identify a JSON file.");
            }
            var duplicate = paths
                .GroupBy(path => path, StringComparer.OrdinalIgnoreCase)
                .FirstOrDefault(group => group.Count() > 1);
            if (duplicate != null)
                throw new FrameScopeConfigurationException(
                    $"Duplicate frame hint catalog path '{duplicate.Key}'.");
        }

        public IReadOnlyList<string> GetCatalogPaths() =>
            CatalogPath is null ? [.. AdditionalCatalogPaths] : [CatalogPath, .. AdditionalCatalogPaths];
    }

    public sealed class FrameScopeHintCatalog
    {
        public int SchemaVersion { get; set; }
        public string CatalogVersion { get; set; } = "";
        public string SourcePath { get; set; } = "";
        public string SourceSha256 { get; set; } = "";
        public string Checksum { get; set; } = "";
        public List<FrameScopeHint> Hints { get; set; } = [];
        public List<string> RejectedSourceHints { get; set; } = [];
    }

    public sealed record FrameScopeHint
    {
        public string ScopeId { get; init; } = "";
        public int PageIndex { get; init; }
        public bool IsMainFrame { get; init; }
        public List<string> FramePath { get; init; } = [];
    }

    public interface IFrameScopeHintProvider
    {
        IReadOnlyList<FrameScopeHint> Hints { get; }
        FrameScopeHint Require(string scopeId);
    }

    public sealed class FrameScopeHintProvider : IFrameScopeHintProvider
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        private readonly IReadOnlyDictionary<string, FrameScopeHint> _hints;

        public FrameScopeHintProvider(FrameScopeHintOptions options)
            : this(Load(options))
        {
        }

        public FrameScopeHintProvider(FrameScopeHintCatalog catalog)
            : this([catalog])
        {
        }

        public FrameScopeHintProvider(
            IReadOnlyList<FrameScopeHintCatalog> catalogs)
        {
            ArgumentNullException.ThrowIfNull(catalogs);
            if (catalogs.Count == 0)
                throw new FrameScopeConfigurationException(
                    "At least one frame hint catalog is required.");
            foreach (var catalog in catalogs)
                FrameScopeHintValidator.Validate(catalog);
            Hints = catalogs.SelectMany(catalog => catalog.Hints).ToArray();
            var duplicate = Hints
                .GroupBy(hint => hint.ScopeId, StringComparer.Ordinal)
                .FirstOrDefault(group => group.Count() > 1);
            if (duplicate != null)
            {
                throw new FrameScopeConfigurationException(
                    $"Frame scope hint '{duplicate.Key}' is ambiguous across catalogs.");
            }
            _hints = Hints.ToDictionary(
                hint => hint.ScopeId,
                StringComparer.Ordinal);
        }

        public IReadOnlyList<FrameScopeHint> Hints { get; }

        public FrameScopeHint Require(string scopeId)
        {
            if (!_hints.TryGetValue(scopeId, out var hint))
            {
                throw new FrameScopeConfigurationException(
                    $"Required frame scope hint '{scopeId}' is not approved.");
            }
            return hint;
        }

        private static IReadOnlyList<FrameScopeHintCatalog> Load(
            FrameScopeHintOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);
            options.Validate();
            var root = Path.GetFullPath(AppContext.BaseDirectory);
            var configuredPaths = options.GetCatalogPaths();
            var catalogs = new List<FrameScopeHintCatalog>();
            foreach (var configuredPath in configuredPaths)
            {
                catalogs.Add(ReadCatalog(root, configuredPath));
            }
            return catalogs;
        }

        private static FrameScopeHintCatalog ReadCatalog(
            string root,
            string configuredPath)
        {
            try
            {
                if (configuredPath.StartsWith(@"\\", StringComparison.Ordinal) ||
                    configuredPath.StartsWith("//", StringComparison.Ordinal) ||
                    (Path.IsPathRooted(configuredPath) && !Path.IsPathFullyQualified(configuredPath)))
                {
                    throw new FrameScopeConfigurationException(
                        "Frame hint catalog paths must be relative or fully qualified local paths.");
                }
                var path = ArtifactPathGuard.EnsureSafe(
                    root,
                    Path.GetFullPath(configuredPath, root),
                    entry => File.GetAttributes(entry));
                for (var parent = new DirectoryInfo(root).Parent; parent is not null; parent = parent.Parent)
                {
                    if (parent.Attributes.HasFlag(FileAttributes.ReparsePoint))
                        throw new FrameScopeConfigurationException(
                            "Frame hint catalog ancestors cannot traverse symbolic links or reparse points.");
                }
                return JsonSerializer.Deserialize<FrameScopeHintCatalog>(
                    File.ReadAllText(path),
                    JsonOptions)
                    ?? throw new JsonException();
            }
            catch (ArtifactEvidenceException)
            {
                throw new FrameScopeConfigurationException(
                    "Frame hint catalogs must remain within the application directory and cannot traverse symbolic links or reparse points.");
            }
            catch (Exception exception) when (
                exception is ArgumentException or NotSupportedException)
            {
                throw new FrameScopeConfigurationException(
                    $"Frame hint catalog path '{configuredPath}' is invalid.");
            }
            catch (Exception exception) when (
                exception is IOException or JsonException)
            {
                throw new FrameScopeConfigurationException(
                    $"Frame hint catalog '{configuredPath}' is missing or malformed.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new FrameScopeConfigurationException(
                    $"Frame hint catalog '{configuredPath}' is not accessible.");
            }
        }
    }

    public static class FrameScopeHintValidator
    {
        public static void Validate(FrameScopeHintCatalog catalog)
        {
            ArgumentNullException.ThrowIfNull(catalog);
            if (catalog.SchemaVersion is not (1 or 2))
                throw new FrameScopeConfigurationException(
                    $"Unsupported frame hint schema '{catalog.SchemaVersion}'.");
            if (catalog.Hints is null || catalog.RejectedSourceHints is null ||
                catalog.Hints.Any(hint => hint is null))
                throw new FrameScopeConfigurationException(
                    "Frame scope catalog entries must not be null.");
            Require(catalog.CatalogVersion, "catalogVersion");
            Require(catalog.SourcePath, "sourcePath");
            RequireHash(catalog.SourceSha256, "sourceSha256");
            var duplicate = catalog.Hints
                .GroupBy(hint => hint.ScopeId, StringComparer.Ordinal)
                .FirstOrDefault(group => group.Count() > 1);
            if (duplicate != null)
            {
                throw new FrameScopeConfigurationException(
                    $"Duplicate frame scope hint '{duplicate.Key}'.");
            }
            foreach (var hint in catalog.Hints)
            {
                Require(hint.ScopeId, "scopeId");
                StableIdentifier(hint.ScopeId, "scopeId");
                if (hint.PageIndex < 0 || hint.FramePath is null ||
                    (hint.IsMainFrame
                        ? catalog.SchemaVersion < 2 || hint.FramePath.Count != 0
                        : hint.FramePath.Count == 0))
                {
                    throw new FrameScopeConfigurationException(
                        $"Frame scope hint '{hint.ScopeId}' has invalid page/path.");
                }
                foreach (var frameName in hint.FramePath)
                {
                    Require(frameName, "frameName");
                    StableIdentifier(frameName, "frameName");
                    if (IsGeneric(frameName))
                    {
                        throw new FrameScopeConfigurationException(
                            $"Frame scope hint '{hint.ScopeId}' is generic or ambiguous.");
                    }
                }
            }
            foreach (var rejected in catalog.RejectedSourceHints)
            {
                if (!IsGeneric(rejected))
                {
                    throw new FrameScopeConfigurationException(
                        $"Rejected source frame hint '{rejected}' is not generic.");
                }
            }
            if (!catalog.Checksum.Equals(
                    ComputeChecksum(catalog),
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new FrameScopeConfigurationException(
                    "The frame hint catalog checksum is stale or invalid.");
            }
        }

        public static string ComputeChecksum(FrameScopeHintCatalog catalog)
        {
            var lines = new List<string>
            {
                catalog.SchemaVersion.ToString(CultureInfo.InvariantCulture),
                catalog.CatalogVersion.Trim(),
                catalog.SourcePath.Trim(),
                catalog.SourceSha256.Trim().ToUpperInvariant()
            };
            lines.AddRange(catalog.Hints
                .OrderBy(hint => hint.ScopeId, StringComparer.Ordinal)
                .Select(hint =>
                    $"hint|{hint.ScopeId.Trim()}|{hint.PageIndex}|" +
                    (catalog.SchemaVersion >= 2 ? (hint.IsMainFrame ? "main|" : "frame|") : "") +
                    string.Join(
                        ">",
                        hint.FramePath.Select(value => value.Trim()))));
            lines.AddRange(catalog.RejectedSourceHints
                .OrderBy(value => value, StringComparer.Ordinal)
                .Select(value => $"rejected|{value.Trim()}"));
            return Convert.ToHexString(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(string.Join("\n", lines))));
        }

        private static bool IsGeneric(string value) =>
            value.Trim().Equals("iframe", StringComparison.OrdinalIgnoreCase) ||
            value.Trim().Equals("frame", StringComparison.OrdinalIgnoreCase) ||
            value.Trim().Equals("*", StringComparison.Ordinal);

        private static void StableIdentifier(string value, string name)
        {
            if (!value.Equals(value.Trim(), StringComparison.Ordinal) || !Regex.IsMatch(
                    value.Trim(),
                    "^[A-Za-z0-9][A-Za-z0-9_.:-]{0,127}$",
                    RegexOptions.CultureInvariant,
                    TimeSpan.FromSeconds(1)))
            {
                throw new FrameScopeConfigurationException(
                    $"Frame hint {name} must be an exact stable identifier.");
            }
        }

        private static void Require(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value) ||
                value.Any(char.IsControl))
            {
                throw new FrameScopeConfigurationException(
                    $"Frame hint {name} is missing or invalid.");
            }
        }

        private static void RequireHash(string? value, string name)
        {
            if (value is null || value.Length != 64 ||
                value.Any(character => !Uri.IsHexDigit(character)))
            {
                throw new FrameScopeConfigurationException(
                    $"Frame hint {name} must be a SHA-256 value.");
            }
        }
    }

    public static class FrameScopeHintMatcher
    {
        public static string? Match(
            IReadOnlyList<FrameScopeHint> hints,
            int pageIndex,
            IReadOnlyList<string> framePath)
        {
            ArgumentNullException.ThrowIfNull(hints);
            ArgumentNullException.ThrowIfNull(framePath);
            var matches = hints.Where(hint =>
                    hint.PageIndex == pageIndex &&
                    hint.IsMainFrame == (framePath.Count == 0) &&
                    hint.FramePath.SequenceEqual(
                        framePath,
                        StringComparer.Ordinal))
                .ToArray();
            if (matches.Length > 1)
            {
                throw new FrameScopeConfigurationException(
                    "A runtime frame path matched multiple configured scopes.");
            }
            return matches.SingleOrDefault()?.ScopeId;
        }
    }

    public sealed class FrameScopeConfigurationException : Exception
    {
        public FrameScopeConfigurationException(string message)
            : base(message)
        {
        }
    }
}
