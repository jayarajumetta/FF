namespace InsuranceAutomation.Core;

public static class TestOutputPaths
{
    public static string FindRoot(string configPath)
    {
        foreach (var start in new[] { Path.GetDirectoryName(configPath)!, AppContext.BaseDirectory })
        {
            for (var current = new DirectoryInfo(start); current is not null; current = current.Parent)
            {
                if (File.Exists(Path.Combine(current.FullName, "ToscaCanonicalSimple.sln")) ||
                    File.Exists(Path.Combine(current.FullName, "Tosca.runsettings")))
                    return current.FullName;
            }
        }

        return Directory.GetParent(Path.GetDirectoryName(configPath)!)!.FullName;
    }

    public static string ResolveResultsRoot(string repositoryRoot, string configuredRoot)
    {
        var value = configuredRoot;
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOperationException("reporting.resultsRoot cannot be empty.");
        var root = Path.GetFullPath(repositoryRoot).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        var resolved = Path.GetFullPath(value, root).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        if (!resolved.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("reporting.resultsRoot must remain inside the repository root.");
        return resolved;
    }

    public static string ResolveArtifactRoot(string resultsRoot, string artifactRoot)
    {
        if (string.IsNullOrWhiteSpace(artifactRoot) || Path.IsPathRooted(artifactRoot))
            throw new InvalidOperationException("reporting.artifactRoot must be a relative subfolder of the results root.");
        var root = Path.GetFullPath(resultsRoot).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        var resolved = Path.GetFullPath(artifactRoot, root);
        if (!resolved.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("reporting.artifactRoot must remain inside the results root.");
        return resolved;
    }
}
