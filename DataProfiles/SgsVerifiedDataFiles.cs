#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.DataProfiles
{
    internal sealed class SgsVerifiedDataFiles
    {
        private const int MaximumFileBytes = 5 * 1024 * 1024;
        private readonly string _root;
        private readonly string _productFolder;
        private readonly Dictionary<string, InventoryEntry> _entries =
            new(StringComparer.OrdinalIgnoreCase);

        internal SgsVerifiedDataFiles(string root, string productCode)
        {
            _productFolder = productCode switch
            {
                "CLDC" => "CommercialLines.DuckCreek",
                "CLEQ" => "CommercialLines.ExpertQuote",
                "PLDC" => "PersonalLines.DuckCreek",
                _ => throw new SgsScenarioDataException("An explicit SGS product code CLDC, CLEQ or PLDC is required.")
            };
            if (string.IsNullOrWhiteSpace(root) || !Path.IsPathFullyQualified(root))
                throw new SgsScenarioDataException("SGS ResourcesRootPath must be an explicit absolute Resources directory.");

            _root = Path.GetFullPath(root);
            var inventory = ParseObject(ReadBytes(Path.Combine("Contracts", "sgs-data-inventory.json")));
            if (ReadInt(inventory, "version") != 1 ||
                !Regex.IsMatch(ReadString(inventory, "sourceCommit"), @"\A[0-9a-fA-F]{40}\z") ||
                inventory["files"] is not JsonArray files)
            {
                throw new SgsScenarioDataException("The SGS data inventory schema or source commit is invalid.");
            }

            var destinations = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var sources = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in files)
            {
                if (item is not JsonObject entry)
                    throw new SgsScenarioDataException("The SGS data inventory contains an invalid entry.");

                var source = NormalizeRelativePath(ReadString(entry, "sourceRelativePath"));
                var destination = NormalizeRelativePath(ReadString(entry, "destinationPath"));
                if (!sources.Add(source) || !destinations.Add(destination))
                    throw new SgsScenarioDataException("The SGS data inventory contains ambiguous file entries.");

                if (ReadString(entry, "sourceProject") != _productFolder + ".Tests" ||
                    ReadString(entry, "kind") != "scenario-data")
                {
                    continue;
                }

                var prefix = Path.Combine("tests", _productFolder + ".Tests") + Path.DirectorySeparatorChar;
                if (!source.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    throw new SgsScenarioDataException("The SGS inventory source path does not match its product.");

                var relative = NormalizeRequestPath(source);
                var expectedDestination = Path.Combine("Resources", "SGS", _productFolder, relative);
                var hash = ReadString(entry, "importedSha256");
                var size = ReadInt(entry, "importedSize");
                if (!destination.Equals(expectedDestination, StringComparison.OrdinalIgnoreCase) ||
                    !Regex.IsMatch(hash, @"\A[0-9a-fA-F]{64}\z") ||
                    size < 0 || size > MaximumFileBytes)
                {
                    throw new SgsScenarioDataException("The SGS inventory product mapping, imported hash or size is invalid.");
                }
                _entries.Add(relative, new InventoryEntry(hash, size));
            }
        }

        internal string NormalizeRequestPath(string path)
        {
            var normalized = NormalizeRelativePath(path);
            var sourcePrefix = Path.Combine("tests", _productFolder + ".Tests") + Path.DirectorySeparatorChar;
            var destinationPrefix = Path.Combine("Resources", "SGS", _productFolder) + Path.DirectorySeparatorChar;
            if (normalized.StartsWith(sourcePrefix, StringComparison.OrdinalIgnoreCase))
                normalized = normalized[sourcePrefix.Length..];
            else if (normalized.StartsWith(destinationPrefix, StringComparison.OrdinalIgnoreCase))
                normalized = normalized[destinationPrefix.Length..];

            if (!normalized.StartsWith("TestData" + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) ||
                !Path.GetExtension(normalized).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                throw new SgsScenarioDataException("SGS data paths must identify a JSON file under the selected product's TestData directory.");
            }
            return normalized;
        }

        internal JsonObject Read(string path)
        {
            var relative = NormalizeRequestPath(path);
            if (!_entries.TryGetValue(relative, out var entry))
                throw new SgsScenarioDataException("The requested SGS data file is not recorded for this product in the imported inventory.");

            var bytes = ReadBytes(Path.Combine("SGS", _productFolder, relative));
            if (bytes.Length != entry.Size ||
                !Convert.ToHexString(SHA256.HashData(bytes)).Equals(entry.Hash, StringComparison.OrdinalIgnoreCase))
            {
                throw new SgsScenarioDataException("SGS data does not match its current imported SHA-256 and size; review the payload rather than regenerating its hash.");
            }

            var result = ParseObject(bytes);
            if (result.ContainsKey("entries") || result.ContainsKey("baseFile") ||
                result["schemaVersion"]?.ToString() == "1.0-layered-runtime")
            {
                throw new SgsScenarioDataException("Legacy SGS layered manifests are not active data. Use reviewed, individually inventoried profile and patch files.");
            }
            return result;
        }

        private byte[] ReadBytes(string relative)
        {
            try
            {
                var path = Path.Combine(_root, relative);
                ArtifactPathGuard.EnsureSafe(_root, path);
                for (var parent = new DirectoryInfo(_root).Parent; parent is not null; parent = parent.Parent)
                {
                    if (parent.Attributes.HasFlag(FileAttributes.ReparsePoint))
                        throw new SgsScenarioDataException("SGS Resources ancestors cannot traverse symbolic links or reparse points.");
                }
                using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                if (stream.Length > MaximumFileBytes)
                    throw new SgsScenarioDataException("An SGS data file exceeds the 5 MiB size limit.");

                var bytes = new byte[checked((int)stream.Length)];
                stream.ReadExactly(bytes);
                if (stream.ReadByte() != -1)
                    throw new SgsScenarioDataException("An SGS data file changed while being read.");
                return bytes;
            }
            catch (ArtifactEvidenceException)
            {
                throw new SgsScenarioDataException("SGS data paths cannot escape Resources or traverse symbolic links or reparse points.");
            }
            catch (IOException)
            {
                throw new SgsScenarioDataException("A required SGS inventory or data file is missing or cannot be read.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new SgsScenarioDataException("A required SGS inventory or data file is not accessible.");
            }
        }

        private static string NormalizeRelativePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || Path.IsPathRooted(path) ||
                path[0] is '/' or '\\' || path.Any(char.IsControl))
            {
                throw new SgsScenarioDataException("SGS data paths must be nonempty relative paths.");
            }
            var segments = path.Replace('\\', '/').Split('/');
            if (segments.Any(segment =>
                    string.IsNullOrWhiteSpace(segment) || segment is "." or ".." ||
                    segment.EndsWith(' ') || segment.EndsWith('.') ||
                    segment.IndexOfAny([':', '*', '?', '"', '<', '>', '|']) >= 0 ||
                    Regex.IsMatch(segment, @"\A(?:CON|PRN|AUX|NUL|COM[1-9]|LPT[1-9])(?:\.|\z)", RegexOptions.IgnoreCase)))
            {
                throw new SgsScenarioDataException("SGS data paths contain a traversal or unsupported path component.");
            }
            return Path.Combine(segments);
        }

        private static JsonObject ParseObject(byte[] bytes)
        {
            try
            {
                using var document = JsonDocument.Parse(bytes);
                RejectDuplicateProperties(document.RootElement);
                return JsonNode.Parse(bytes, new JsonNodeOptions { PropertyNameCaseInsensitive = true }) as JsonObject
                       ?? throw new SgsScenarioDataException("SGS data must be a JSON object.");
            }
            catch (JsonException)
            {
                throw new SgsScenarioDataException("SGS data is invalid JSON; payload values are not included in diagnostics.");
            }
        }

        private static void RejectDuplicateProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var property in element.EnumerateObject())
                {
                    if (!names.Add(property.Name))
                        throw new SgsScenarioDataException("SGS JSON contains duplicate or case-colliding property names.");
                    RejectDuplicateProperties(property.Value);
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                    RejectDuplicateProperties(item);
            }
        }

        private static string ReadString(JsonObject entry, string name) =>
            entry[name] is JsonValue value && value.TryGetValue<string>(out var text) && !string.IsNullOrWhiteSpace(text)
                ? text
                : throw new SgsScenarioDataException("An SGS inventory text field is missing or invalid.");

        private static int ReadInt(JsonObject entry, string name) =>
            entry[name] is JsonValue value && value.TryGetValue<int>(out var number)
                ? number
                : throw new SgsScenarioDataException("An SGS inventory numeric field is missing or invalid.");

        private sealed record InventoryEntry(string Hash, int Size);
    }
}
