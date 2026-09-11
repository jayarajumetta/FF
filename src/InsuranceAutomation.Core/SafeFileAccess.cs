using System.Text;

namespace InsuranceAutomation.Core;

internal static class SafeFileAccess
{
    public static string FindRepositoryRoot()
    {
        var current = new DirectoryInfo(AppContext.BaseDirectory);
        while (current is not null)
        {
            if (File.Exists(Path.Combine(current.FullName, "ToscaCanonicalSimple.sln")) ||
                File.Exists(Path.Combine(current.FullName, "Tosca.runsettings")))
                return current.FullName;
            current = current.Parent;
        }

        throw new DirectoryNotFoundException("Repository root was not found. Ensure execution starts from the repository/package directory tree.");
    }

    public static string ResolveExistingFileUnderRoot(string rootPath, string candidatePath)
    {
        var root = NormalizeRoot(rootPath);
        if (string.IsNullOrWhiteSpace(candidatePath))
            throw new InvalidOperationException("File path cannot be empty.");

        var resolved = Path.IsPathRooted(candidatePath)
            ? Path.GetFullPath(candidatePath)
            : Path.GetFullPath(Path.Combine(root, candidatePath));

        if (!resolved.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Resolved file path is outside the allowed root.");

        var info = new FileInfo(resolved);
        if (!info.Exists)
            throw new FileNotFoundException($"Required file not found: {resolved}");
        if ((info.Attributes & FileAttributes.ReparsePoint) != 0)
            throw new InvalidOperationException($"Reparse-point files are not allowed: {resolved}");

        return resolved;
    }

    public static string ResolveExistingDirectoryUnderRoot(string rootPath, string candidatePath)
    {
        var root = NormalizeRoot(rootPath);
        if (string.IsNullOrWhiteSpace(candidatePath))
            throw new InvalidOperationException("Directory path cannot be empty.");

        var resolved = Path.IsPathRooted(candidatePath)
            ? Path.GetFullPath(candidatePath)
            : Path.GetFullPath(Path.Combine(root, candidatePath));

        if (!resolved.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Resolved directory path is outside the allowed root.");

        var info = new DirectoryInfo(resolved);
        if (!info.Exists)
            throw new DirectoryNotFoundException($"Required directory not found: {resolved}");
        if ((info.Attributes & FileAttributes.ReparsePoint) != 0)
            throw new InvalidOperationException($"Reparse-point directories are not allowed: {resolved}");

        return resolved;
    }

    public static bool TryResolveExistingFileUnderRoot(string rootPath, string candidatePath, out string resolvedPath)
    {
        try
        {
            resolvedPath = ResolveExistingFileUnderRoot(rootPath, candidatePath);
            return true;
        }
        catch
        {
            resolvedPath = string.Empty;
            return false;
        }
    }

    public static string ReadAllTextUnderRoot(string rootPath, string candidatePath, long maxBytes)
    {
        if (maxBytes <= 0)
            throw new InvalidOperationException("maxBytes must be positive.");

        var resolved = ResolveExistingFileUnderRoot(rootPath, candidatePath);
        var info = new FileInfo(resolved);
        if (info.Length <= 0 || info.Length > maxBytes)
            throw new InvalidOperationException($"File size must be between 1 and {maxBytes} bytes: {resolved}");

        using var stream = new FileStream(info.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
        return reader.ReadToEnd();
    }

    private static string NormalizeRoot(string rootPath)
    {
        if (string.IsNullOrWhiteSpace(rootPath))
            throw new InvalidOperationException("Root path cannot be empty.");
        return Path.GetFullPath(rootPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    }
}
