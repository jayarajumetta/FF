using System.Net.Http;


namespace Playwright_POC.Context
{
    public class TestContext
    {
        public HttpClient HttpClient { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
        public Microsoft.Playwright.IPage Page { get; set; }
    }
}