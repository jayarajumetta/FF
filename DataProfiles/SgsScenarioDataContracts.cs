#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace PnCTestAutomation.DataProfiles
{
    public sealed record SgsScenarioDataRequest(
        string ProductCode,
        string ProfilePath,
        string? StateVariant = null,
        string? ExternalDataPath = null,
        IReadOnlyDictionary<string, string?>? RuntimeOverrides = null)
    {
        public IReadOnlyList<string> LayerPaths { get; init; } = Array.Empty<string>();
        public string? StateOverridesPath { get; init; }
    }

    public sealed class SgsScenarioDataOptions
    {
        public string ResourcesRootPath { get; init; } =
            Path.Combine(AppContext.BaseDirectory, "Resources");

        public TimeProvider TimeProvider { get; init; } = TimeProvider.System;
    }

    public interface ISgsScenarioData
    {
        void Load(SgsScenarioDataRequest request);
        string GetRequired(string key);
        string ResolveRequired(string expression);
        string GenerateRandom(string name);
        void ValidateRequiredInputs(IEnumerable<string> keys);
        bool TryGetOptional(string key, [NotNullWhen(true)] out string? value);
        void CaptureBuffer(string key, string value);
        string GetRequiredBuffer(string key);
    }

    public sealed class SgsScenarioDataException : InvalidOperationException
    {
        public SgsScenarioDataException(string message) : base(message)
        {
        }
    }
}
