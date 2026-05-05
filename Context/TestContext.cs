using System.Net.Http;


namespace Playwright_POC.Context
{
    public class TestContext
    {
        public HttpClient HttpClient { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
        public Microsoft.Playwright.IPage Page { get; set; }
        /// <summary>The popup/new-window page opened by the EChecklist button on Submission.</summary>
        public Microsoft.Playwright.IPage ChecklistPage { get; set; }
    }
}
