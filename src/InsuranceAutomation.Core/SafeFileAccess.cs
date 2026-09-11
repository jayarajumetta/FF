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

    public static string ToRepositoryRelativePath(string rootPath, string candidatePath)
    {
        if (string.IsNullOrWhiteSpace(candidatePath))
            return candidatePath;

        if (!Path.IsPathRooted(candidatePath))
            return candidatePath;

        var root = NormalizeRoot(rootPath);
        var full = Path.GetFullPath(candidatePath);
        var relative = Path.GetRelativePath(root, full);
        if (Path.IsPathRooted(relative) || relative == ".." || relative.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            throw new InvalidOperationException("Path must remain inside repository root.");

        return relative;
    }

    public static string ResolveExistingFileUnderRoot(string rootPath, string candidatePath, long maxBytes = 0, params string[] allowedExtensions)
    {
        var root = NormalizeRoot(rootPath);
        var relativePath = NormalizeSafeRelativePath(candidatePath, "File");
        var resolved = Path.GetFullPath(Path.Combine(root, relativePath));

        var backRelative = Path.GetRelativePath(root, resolved);
        if (Path.IsPathRooted(backRelative) || backRelative == ".." || backRelative.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            throw new InvalidOperationException("Resolved file path is outside the allowed root.");

        var info = new FileInfo(resolved);
        if (!info.Exists)
            throw new FileNotFoundException($"Required file not found: {resolved}");
        if ((info.Attributes & FileAttributes.ReparsePoint) != 0)
            throw new InvalidOperationException($"Reparse-point files are not allowed: {resolved}");
        if (maxBytes > 0 && (info.Length <= 0 || info.Length > maxBytes))
            throw new InvalidOperationException($"File size must be between 1 and {maxBytes} bytes: {resolved}");
        if (allowedExtensions.Length > 0)
        {
            var ext = Path.GetExtension(resolved);
            if (!allowedExtensions.Any(item => ext.Equals(item, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"File extension '{ext}' is not allowed for: {resolved}");
        }

        return resolved;
    }

    public static string ResolveExistingDirectoryUnderRoot(string rootPath, string candidatePath)
    {
        var root = NormalizeRoot(rootPath);
        var relativePath = NormalizeSafeRelativePath(candidatePath, "Directory");
        var resolved = Path.GetFullPath(Path.Combine(root, relativePath));

        var backRelative = Path.GetRelativePath(root, resolved);
        if (Path.IsPathRooted(backRelative) || backRelative.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal) || backRelative == "..")
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

    public static string ReadText(string resolvedPath)
    {
        using var stream = new FileStream(resolvedPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var reader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true);
        return reader.ReadToEnd();
    }

    private static string NormalizeRoot(string rootPath)
    {
        if (string.IsNullOrWhiteSpace(rootPath))
            throw new InvalidOperationException("Root path cannot be empty.");
        return Path.GetFullPath(rootPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    }

    private static string NormalizeSafeRelativePath(string candidatePath, string label)
    {
        if (string.IsNullOrWhiteSpace(candidatePath))
            throw new InvalidOperationException($"{label} path cannot be empty.");
        if (Path.IsPathRooted(candidatePath))
            throw new InvalidOperationException($"{label} path must be relative to repository root.");

        var normalized = candidatePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Trim();
        var segments = normalized.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (segments.Length == 0)
            throw new InvalidOperationException($"{label} path cannot be empty.");

        foreach (var segment in segments)
        {
            if (segment is "." or "..")
                throw new InvalidOperationException($"{label} path contains traversal segments.");
            if (segment.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                throw new InvalidOperationException($"{label} path contains invalid characters.");
        }

        return Path.Combine(segments);
    }
}
