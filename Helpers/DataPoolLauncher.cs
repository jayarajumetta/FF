using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PnCTestAutomation.Helpers
{
    /// <summary>
    /// Brings the DataPool web app up for the duration of a test run so completed quotes
    /// actually get recorded.
    ///
    /// Quotes are pushed over HTTP rather than written straight to <c>quotes.json</c> because
    /// DataPool serialises every read-modify-write behind an in-process lock. That lock is the
    /// only thing stopping two writers from clobbering the file, and it cannot reach across
    /// processes — so the web app has to be the single writer, and it has to be running.
    ///
    /// If something is already listening on the configured port we leave it alone and never
    /// shut it down; a developer with the DataPool page open should not lose their server
    /// because a test run ended.
    /// </summary>
    internal static class DataPoolLauncher
    {
        // Non-null only when this process launched the server and is therefore responsible
        // for stopping it again.
        private static Process _ownedProcess;

        private const int ReadinessTimeoutMs = 30000;
        private const int ProbeTimeoutMs = 500;

        public static void EnsureRunning(string baseUrl, bool autoStart)
        {
            if (!autoStart || string.IsNullOrWhiteSpace(baseUrl))
            {
                return;
            }

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uri))
            {
                Console.WriteLine($"[DataPool] BaseUrl '{baseUrl}' is not a valid URL — not starting anything.");
                return;
            }

            // A remote DataPool is somebody else's to run. This also means CI can point at a
            // hosted instance and this whole path stays out of the way.
            if (!IsLoopback(uri.Host))
            {
                return;
            }

            if (IsListening(uri.Host, uri.Port))
            {
                Console.WriteLine($"[DataPool] Already running on {uri.Host}:{uri.Port}.");
                return;
            }

            var assembly = ResolveDataPoolAssembly();
            if (assembly == null)
            {
                Console.WriteLine("[DataPool] Could not locate DataPool.dll — quotes will not be recorded this run.");
                return;
            }

            Process process;
            try
            {
                process = Start(assembly);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DataPool] Failed to start: {ex.Message}");
                return;
            }

            if (!WaitForReadiness(uri.Host, uri.Port, process))
            {
                Console.WriteLine("[DataPool] Started but never began listening — quotes will not be recorded this run.");
                TryKill(process);
                return;
            }

            // Losing a start race is fine and expected when shards run in parallel: our process
            // dies on the port binding, someone else's is serving. Only claim ownership if the
            // process we launched is the one still alive.
            if (process.HasExited)
            {
                process.Dispose();
                Console.WriteLine($"[DataPool] Another process got there first — using {uri.Host}:{uri.Port}.");
                return;
            }

            _ownedProcess = process;
            Console.WriteLine($"[DataPool] Started on {uri.Host}:{uri.Port} (pid {process.Id}).");
        }

        public static void StopIfStarted()
        {
            var process = Interlocked.Exchange(ref _ownedProcess, null);
            if (process == null)
            {
                return;
            }

            TryKill(process);
            Console.WriteLine("[DataPool] Stopped.");
        }

        private static Process Start(string assemblyPath)
        {
            var startInfo = new ProcessStartInfo("dotnet")
            {
                // Run from DataPool's own output folder so it picks up its appsettings.json
                // (which sets the listen URL) and writes to its own data/quotes.json.
                WorkingDirectory = Path.GetDirectoryName(assemblyPath)!,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            startInfo.ArgumentList.Add(assemblyPath);

            var process = Process.Start(startInfo)!;

            // Kestrel's startup banner is noise in the middle of a test run, but the pipes still
            // have to be drained or the child blocks once its output buffer fills.
            process.OutputDataReceived += (_, _) => { };
            process.ErrorDataReceived += (_, _) => { };
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return process;
        }

        private static bool WaitForReadiness(string host, int port, Process process)
        {
            var deadline = DateTime.UtcNow.AddMilliseconds(ReadinessTimeoutMs);
            while (DateTime.UtcNow < deadline)
            {
                if (IsListening(host, port))
                {
                    return true;
                }

                // If our process is gone the port can still come up — a parallel shard may have
                // won the race — so keep probing rather than bailing out here.
                Thread.Sleep(250);
            }

            return IsListening(host, port);
        }

        /// <summary>
        /// Probes every address the host resolves to, not just the first.
        /// DataPool binds 0.0.0.0, which is IPv4 only, while "localhost" resolves to ::1
        /// ahead of 127.0.0.1 on Windows. Testing only the first address reports a healthy
        /// server as unreachable.
        /// </summary>
        private static bool IsListening(string host, int port)
        {
            foreach (var address in ResolveAddresses(host))
            {
                try
                {
                    using var client = new TcpClient(address.AddressFamily);
                    if (client.ConnectAsync(address, port).Wait(ProbeTimeoutMs) && client.Connected)
                    {
                        return true;
                    }
                }
                catch
                {
                    // Refused or timed out on this address — try the next one.
                }
            }

            return false;
        }

        private static IPAddress[] ResolveAddresses(string host)
        {
            if (IPAddress.TryParse(host, out var parsed))
            {
                return new[] { parsed };
            }

            try
            {
                return Dns.GetHostAddresses(host);
            }
            catch
            {
                return Array.Empty<IPAddress>();
            }
        }

        private static bool IsLoopback(string host)
            => string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase)
               || (IPAddress.TryParse(host, out var ip) && IPAddress.IsLoopback(ip));

        /// <summary>
        /// The test project references DataPool, so it is always built alongside us and its
        /// output sits in the matching configuration folder.
        /// </summary>
        private static string ResolveDataPoolAssembly()
        {
            var output = new DirectoryInfo(AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar));
            var targetFramework = output.Name;                 // net8.0
            var configuration = output.Parent?.Name;           // Debug
            var repoRoot = output.Parent?.Parent?.Parent;      // <repo>\bin\.. -> <repo>

            if (configuration == null || repoRoot == null)
            {
                return null;
            }

            var assembly = Path.Combine(
                repoRoot.FullName, "DataPool", "bin", configuration, targetFramework, "DataPool.dll");

            return File.Exists(assembly) ? assembly : null;
        }

        private static void TryKill(Process process)
        {
            try
            {
                if (!process.HasExited)
                {
                    process.Kill(entireProcessTree: true);
                    process.WaitForExit(5000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DataPool] Could not stop the server cleanly: {ex.Message}");
            }
            finally
            {
                process.Dispose();
            }
        }
    }
}
