using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Playwright;

namespace PnCTestAutomation.Helpers
{
    internal sealed class RetryDiagnostics : IDisposable
    {
        private static readonly ConditionalWeakTable<IPage, RetryDiagnostics> Sessions = new();
        private static readonly ConditionalWeakTable<IBrowserContext, RetryDiagnostics> ContextSessions = new();
        private readonly IPage _page;
        private readonly string _clasHost;
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private readonly ConcurrentDictionary<IRequest, int> _requests = new();
        private readonly Action<string> _write;
        private int _nextRequestId;

        private RetryDiagnostics(IPage page, string clasBaseUrl, Action<string> write)
        {
            _page = page;
            _clasHost = Uri.TryCreate(clasBaseUrl, UriKind.Absolute, out var uri) ? uri.Host : null;
            _write = write;
            page.Request += OnRequest;
            page.Response += OnResponse;
            page.RequestFinished += OnFinished;
            page.RequestFailed += OnFailed;
        }

        internal static RetryDiagnostics Start(IPage page, string clasBaseUrl, Action<string> write = null)
        {
            var diagnostics = new RetryDiagnostics(page, clasBaseUrl, write ?? Console.WriteLine);
            Sessions.Add(page, diagnostics);
            ContextSessions.Add(page.Context, diagnostics);
            diagnostics.Mark("capture started");
            return diagnostics;
        }

        internal static RetryDiagnostics For(IPage page) =>
            Sessions.TryGetValue(page, out var diagnostics) ||
            ContextSessions.TryGetValue(page.Context, out diagnostics) ? diagnostics : null;

        internal void Mark(string message) =>
            _write($"[RetryDiagnostics] {DateTime.UtcNow:O} elapsedMs={_clock.ElapsedMilliseconds} {message}");

        internal static string ClassifyUrl(string url, string clasHost)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
                return null;
            if (uri.AbsolutePath.EndsWith("/api/duckcreek/product", StringComparison.OrdinalIgnoreCase))
                return "eq-product";
            return !string.IsNullOrEmpty(clasHost) && uri.Host.Equals(clasHost, StringComparison.OrdinalIgnoreCase)
                ? "clas"
                : null;
        }

        internal static string FailureCode(string failure)
        {
            var match = Regex.Match(failure ?? string.Empty, @"\bnet::ERR_[A-Z0-9_]+\b");
            return match.Success ? match.Value : "unavailable";
        }

        private void OnRequest(object sender, IRequest request)
        {
            var category = ClassifyUrl(request.Url, _clasHost);
            if (category == null || request.ResourceType is not ("xhr" or "fetch" or "document"))
                return;

            var id = Interlocked.Increment(ref _nextRequestId);
            _requests[request] = id;
            var method = request.Method is "GET" or "POST" or "PUT" or "PATCH" or "DELETE"
                ? request.Method : "OTHER";
            var correlation = request.Headers.TryGetValue("x-amnat-correlation-id", out var value)
                && Guid.TryParse(value, out var guid) ? guid.ToString() : "unavailable";
            Mark($"request id={id} target={category} method={method} correlationId={correlation}");
        }

        private void OnResponse(object sender, IResponse response)
        {
            if (_requests.TryGetValue(response.Request, out var id))
                Mark($"response id={id} status={response.Status}");
        }

        private void OnFinished(object sender, IRequest request)
        {
            if (_requests.TryRemove(request, out var id))
                Mark($"request-finished id={id}");
        }

        private void OnFailed(object sender, IRequest request)
        {
            if (_requests.TryRemove(request, out var id))
                Mark($"request-failed id={id} code={FailureCode(request.Failure)}");
        }

        public void Dispose()
        {
            _page.Request -= OnRequest;
            _page.Response -= OnResponse;
            _page.RequestFinished -= OnFinished;
            _page.RequestFailed -= OnFailed;
            Sessions.Remove(_page);
            ContextSessions.Remove(_page.Context);
            Mark($"capture stopped pendingRequests={_requests.Count}");
        }
    }
}
