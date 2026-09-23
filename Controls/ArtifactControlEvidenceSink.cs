#nullable enable
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Controls
{
    public sealed record RuntimeLocatorEvidence(
        int SchemaVersion,
        string Control,
        string SelectorKind,
        string SelectorIdentityHash,
        string? SelectorExceptionReference,
        string ScopeIdentity,
        string? ScopeContractId,
        int PageIndex,
        int FrameDepth,
        bool IsMainFrame,
        string Operation,
        string Assertion,
        DateTimeOffset CapturedAtUtc,
        string? SelectorElementTag = null);

    public sealed class ArtifactControlEvidenceSink : IControlEvidenceSink
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private readonly IArtifactContext _artifacts;

        public ArtifactControlEvidenceSink(IArtifactContext artifacts)
        {
            _artifacts = artifacts;
        }

        public async Task RecordAsync(
            ControlEvidence evidence,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(evidence);
            var scopeIdentity = string.IsNullOrWhiteSpace(
                evidence.Scope.RuntimeIdentity)
                ? Hash(
                    $"{evidence.Scope.PageIndex}|" +
                    $"{evidence.Scope.FrameDepth}|" +
                    $"{evidence.Scope.IsMainFrame}|" +
                    $"{evidence.Scope.Description}")
                : evidence.Scope.RuntimeIdentity;
            var record = new RuntimeLocatorEvidence(
                1,
                evidence.ControlName,
                evidence.Selector.Kind.ToString(),
                Hash(evidence.Selector.Value),
                evidence.Selector.ExceptionReference,
                scopeIdentity,
                evidence.Scope.ContractId,
                evidence.Scope.PageIndex,
                evidence.Scope.FrameDepth,
                evidence.Scope.IsMainFrame,
                evidence.Operation,
                evidence.Assertion.ToString(),
                DateTimeOffset.UtcNow,
                evidence.Selector.ElementTag);
            var path = _artifacts.CreateArtifactPath(
                ArtifactKind.RuntimeLocator,
                $"{evidence.ControlName}-{evidence.Operation}",
                ".json");
            await File.WriteAllTextAsync(
                path,
                JsonSerializer.Serialize(record, JsonOptions),
                cancellationToken);
            _artifacts.RecordFile(
                ArtifactKind.RuntimeLocator,
                $"{evidence.ControlName}-{evidence.Operation}",
                path);
        }

        private static string Hash(string value) =>
            Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(value)));
    }
}
