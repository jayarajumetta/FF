using PnCTestAutomation.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PnCTestAutomation.DataPool
{
    /// <summary>
    /// Thin HTTP client used by the test project to push completed quotes
    /// into the running DataPool web app.
    ///
    /// Configure the base URL via appsettings.json:
    ///   "DataPool": { "BaseUrl": "http://localhost:5100" }
    ///
    /// If the URL is absent or the server is unreachable the call is silently
    /// skipped — DataPool availability must never fail a test.
    /// </summary>
    public interface IDataPoolClient
    {
        Task TryPersistAsync(QuoteRecord record);
    }

    public class DataPoolClient : IDataPoolClient
    {
        private readonly HttpClient _http;

        public DataPoolClient(HttpClient http)
            => _http = http;

        public async Task TryPersistAsync(QuoteRecord record)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/quotes", record);
                if (response.IsSuccessStatusCode)
                    Console.WriteLine($"[DataPool] Persisted quote {record.Id} ({record.Lob}/{record.SfpVariant}).");
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    Console.WriteLine($"[DataPool] Quote {record.Id} already exists — skipped.");
                else
                    Console.WriteLine($"[DataPool] Unexpected response {(int)response.StatusCode} for quote {record.Id}.");
            }
            catch (Exception ex)
            {
                // Never fail the test — DataPool is a convenience tool.
                Console.WriteLine($"[DataPool] Could not persist quote {record?.Id}: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Used when DataPool:BaseUrl is not configured — all calls are silent no-ops.
    /// </summary>
    public class NullDataPoolClient : IDataPoolClient
    {
        public Task TryPersistAsync(QuoteRecord record) => Task.CompletedTask;
    }
}
