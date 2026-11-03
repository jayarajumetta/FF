using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PnCTestAutomation.Tools.FormsBaselineGenerator
{
    public static class CanonicalProjectionFingerprint
    {
        public static string Compute(CanonicalExpectedProjection projection)
        {
            if (projection == null)
                throw new ArgumentNullException(nameof(projection));
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            options.Converters.Add(new JsonStringEnumConverter());
            using var algorithm = SHA256.Create();
            using var stream = new CryptoStream(
                Stream.Null,
                algorithm,
                CryptoStreamMode.Write,
                leaveOpen: true);
            JsonSerializer.Serialize(stream, projection, options);
            stream.FlushFinalBlock();
            return Convert.ToHexString(algorithm.Hash!);
        }
    }
}
