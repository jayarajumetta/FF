#nullable enable
using System;
using System.Collections.Generic;

namespace PnCTestAutomation.Models
{
    public sealed class SgsScenarioDataState
    {
        public bool IsLoaded { get; internal set; }
        public string? ProductCode { get; internal set; }
        public string? ProfilePath { get; internal set; }
        public string? StateVariant { get; internal set; }

        internal DateTime ReferenceDate { get; set; }
        internal Dictionary<string, SgsDataInput> Inputs { get; } =
            new(StringComparer.OrdinalIgnoreCase);
        internal Dictionary<string, HashSet<string>> Aliases { get; } =
            new(StringComparer.OrdinalIgnoreCase);
        internal Dictionary<string, string> Captures { get; } =
            new(StringComparer.OrdinalIgnoreCase);

        internal void Reset()
        {
            IsLoaded = false;
            ProductCode = null;
            ProfilePath = null;
            StateVariant = null;
            Inputs.Clear();
            Aliases.Clear();
            Captures.Clear();
        }
    }

    internal sealed record SgsDataInput(string? Value, bool IsScalar);
}
