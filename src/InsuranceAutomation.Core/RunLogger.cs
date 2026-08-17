namespace InsuranceAutomation.Core;

public sealed class RunLogger : IDisposable
{
    private readonly object _gate = new();
    private readonly StreamWriter _writer;

    public RunLogger(string artifactDirectory)
    {
        Directory.CreateDirectory(artifactDirectory);
        LogPath = Path.Combine(artifactDirectory, "execution.log");
        _writer = new StreamWriter(LogPath, append: true) { AutoFlush = true };
    }

    public string LogPath { get; }

    public void Info(string message) => Write("INFO", message);
    public void Warn(string message) => Write("WARN", message);
    public void Error(string message) => Write("ERROR", message);

    private void Write(string level, string message)
    {
        var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";
        lock (_gate)
        {
            Console.WriteLine(line);
            _writer.WriteLine(line);
        }
    }

    public void Dispose() => _writer.Dispose();
}
