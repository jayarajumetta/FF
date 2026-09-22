#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Text;
using PnCTestAutomation.Artifacts;

namespace PnCTestAutomation.Reporting;

public static class ReportPaths
{
    public static string NormalizeRelative(string relativePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(relativePath);
        var normalized = relativePath.Replace('\\', '/');
        var segments = normalized.Split('/');
        if (Path.IsPathRooted(relativePath) || normalized.StartsWith('/') ||
            segments.Any(segment => segment is "" or "." or ".." ||
                segment.EndsWith('.') || segment.EndsWith(' ') ||
                segment.Any(character => char.IsControl(character) ||
                    character is ':' or '?' or '#' or '%' or '"' or '<' or '>' or '|' or '*')))
            throw new ArtifactEvidenceException("Report evidence must use a safe relative artifact path.");
        return normalized;
    }

    public static string SafeRoot(string root, Func<string, FileAttributes?>? getAttributes = null)
    {
        var full = Path.GetFullPath(root);
        // Check every ancestor without passing a drive root that could normalize to drive-relative "C:".
        for (var current = full; Path.GetDirectoryName(current) is { } parent; current = parent)
            _ = ArtifactPathGuard.EnsureSafe(current, current, getAttributes);
        return full;
    }

    public static string Resolve(string root, string relativePath)
    {
        var safeRoot = SafeRoot(root);
        var relative = NormalizeRelative(relativePath);
        return ArtifactPathGuard.EnsureSafe(
            safeRoot, Path.Combine(safeRoot, relative.Replace('/', Path.DirectorySeparatorChar)));
    }

    public static string Href(string packageRoot, string documentDirectory, string filePath)
    {
        var root = SafeRoot(packageRoot);
        var directory = ArtifactPathGuard.EnsureSafe(root, Path.GetFullPath(documentDirectory));
        var file = ArtifactPathGuard.EnsureSafe(root, Path.GetFullPath(filePath));
        var relative = Path.GetRelativePath(directory, file).Replace('\\', '/');
        return string.Join("/", relative.Split('/').Select(
            segment => segment == ".." ? segment : Uri.EscapeDataString(segment)));
    }

    public static bool IsLocalHref(string? href)
    {
        if (string.IsNullOrEmpty(href) || href.StartsWith('/') || href.StartsWith('\\') ||
            href.Contains('\\') || href.Any(char.IsControl))
            return false;
        var segments = href.Split('/');
        var inFile = false;
        foreach (var segment in segments)
        {
            if (segment == ".." && !inFile)
                continue;
            inFile = true;
            string decoded;
            try { decoded = Uri.UnescapeDataString(segment); }
            catch (UriFormatException) { return false; }
            if (decoded is "" or "." or ".." ||
                decoded.Any(character => char.IsControl(character) ||
                    character is '/' or '\\' or ':' or '?' or '#' or '%' or '"' or '<' or '>' or '|'))
                return false;
        }
        return inFile;
    }

    public static void WriteAtomic(string root, string relativePath, string content)
    {
        var path = Resolve(root, relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        path = Resolve(root, relativePath);
        var temporaryPath = ArtifactPathGuard.EnsureSafe(root, path + "." + Guid.NewGuid().ToString("N") + ".tmp");
        try
        {
            using (var stream = new FileStream(
                       temporaryPath, FileMode.CreateNew, FileAccess.Write, FileShare.None,
                       4096, FileOptions.WriteThrough))
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false)))
            {
                writer.Write(content);
                writer.Flush();
                stream.Flush(true);
            }
            _ = Resolve(root, relativePath);
            File.Move(temporaryPath, path, overwrite: true);
        }
        finally
        {
            if (File.Exists(temporaryPath))
                File.Delete(temporaryPath);
        }
    }
}
