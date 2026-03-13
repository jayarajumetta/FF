using System;
using System.Threading.Tasks;
using Playwright_POC.Context;

namespace Playwright_POC.Services
{
    /// <summary>
    /// Extracts the DuckCreek session ID from CLAS via Playwright JavaScript evaluation.
    /// Replaces the Tosca bookmarklet: javascript:alert("SessionID: " + DCT.sessionID)
    /// 
    /// NOTE: The session ID can also be captured from the already-open ExpertQuote page
    /// if it shares the DuckCreek context. Adjust the navigation target as needed.
    /// </summary>
    public class SessionService
    {
        private readonly TestContext _context;

        public SessionService(TestContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Evaluates DCT.sessionID in the current page's JavaScript context.
        /// Assumes the page is already on a DuckCreek-powered application (CLAS / ExpertQuote).
        /// </summary>
        public async Task<string> GetDuckCreekSessionIdAsync()
        {
            var page = _context.Page
                ?? throw new InvalidOperationException("No Playwright page is available. Launch a browser first.");

            // The same JS that the Tosca bookmarklet used
            var sessionId = await page.EvaluateAsync<string>("() => DCT.sessionID");

            if (string.IsNullOrWhiteSpace(sessionId))
                throw new InvalidOperationException(
                    "DCT.sessionID returned null/empty. Ensure you are on an active DuckCreek quote.");

            Console.WriteLine($"DuckCreek Session ID retrieved: {sessionId[..Math.Min(12, sessionId.Length)]}...");
            return sessionId;
        }

    }
}
