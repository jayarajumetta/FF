using System.Collections.Concurrent;
using System.IO.Compression;
using NUnit.Framework;

namespace InsuranceAutomation.NUnit;

/// <summary>Stages immutable evidence in NUnit WorkDirectory/TestResults/TestEvidence before registering it with NUnit/VS Test Explorer.</summary>
public static class NUnitEvidenceAttachment
{
    private static readonly ConcurrentDictionary<string, string> TestDirectories = new();

    public static string AddTestAttachment(string sourcePath, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(sourcePath)) throw new ArgumentException("Evidence path is empty.", nameof(sourcePath));
        var source = Path.GetFullPath(sourcePath);
        if (!File.Exists(source) && !Directory.Exists(source)) throw new FileNotFoundException("Evidence does not exist before attachment staging.", source);
        var stage = GetStageDirectory();
        var staged = Directory.Exists(source) ? StageDirectory(source, stage) : StageFile(source, stage);
        // Reopen before registration: catches delayed/finalization/path problems early.
        using (File.Open(staged, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }
        TestContext.AddTestAttachment(staged, description ?? Path.GetFileName(staged));
        TestContext.Progress.WriteLine($"[EVIDENCE ATTACHED] {staged}");
        return staged;
    }

    public static IReadOnlyList<string> AddExisting(IEnumerable<string?> paths, string? descriptionPrefix = null)
    {
        var attached = new List<string>();
        foreach (var path in paths.Where(p => !string.IsNullOrWhiteSpace(p)).Cast<string>())
        {
            try { attached.Add(AddTestAttachment(path, descriptionPrefix is null ? null : $"{descriptionPrefix} - {Path.GetFileName(path)}")); }
            catch (Exception ex) { TestContext.Progress.WriteLine($"[EVIDENCE ATTACHMENT WARNING] {path} :: {ex.Message}"); }
        }
        return attached;
    }

    public static string GetStageDirectory()
    {
        var id = TestContext.CurrentContext.Test.ID;
        var safe = string.Concat((string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("N") : id).Select(c => char.IsLetterOrDigit(c) || c is '-' or '_' ? c : '_'));
        return TestDirectories.GetOrAdd(safe, key =>
        {
            var work = TestContext.CurrentContext.WorkDirectory;
            if (string.IsNullOrWhiteSpace(work)) work = TestContext.CurrentContext.TestDirectory;
            var dir = Path.Combine(work, "TestResults", "TestEvidence", key);
            Directory.CreateDirectory(dir);
            return dir;
        });
    }

    private static string StageFile(string source, string stage)
    {
        var name = Path.GetFileName(source);
        var target = Path.Combine(stage, name);
        if (Path.GetFullPath(source).Equals(Path.GetFullPath(target), StringComparison.OrdinalIgnoreCase)) return target;
        target = Unique(target);
        CopyWithRetry(source, target);
        return target;
    }

    private static string StageDirectory(string source, string stage)
    {
        var target = Unique(Path.Combine(stage, Path.GetFileName(source.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)) + ".zip"));
        ZipFile.CreateFromDirectory(source, target, CompressionLevel.Fastest, includeBaseDirectory: true);
        return target;
    }

    private static void CopyWithRetry(string source, string target)
    {
        Exception? last = null;
        for (var attempt = 1; attempt <= 5; attempt++)
        {
            try { File.Copy(source, target, overwrite: false); return; }
            catch (IOException ex) { last = ex; Thread.Sleep(attempt * 150); }
        }
        throw new IOException($"Could not stage evidence '{source}' to '{target}'.", last);
    }

    private static string Unique(string path)
    {
        if (!File.Exists(path)) return path;
        var dir = Path.GetDirectoryName(path)!;
        var stem = Path.GetFileNameWithoutExtension(path);
        var ext = Path.GetExtension(path);
        return Path.Combine(dir, $"{stem}-{DateTime.UtcNow:yyyyMMddHHmmssfff}-{Guid.NewGuid():N}{ext}");
    }
}
