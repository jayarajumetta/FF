namespace PnCTestAutomation.Context
{
    public class PlaywrightContext
    {
        public Microsoft.Playwright.IPage Page { get; set; }
        /// <summary>The popup/new-window page opened by the EChecklist button on Submission.</summary>
        public Microsoft.Playwright.IPage ChecklistPage { get; set; }
    }
}
