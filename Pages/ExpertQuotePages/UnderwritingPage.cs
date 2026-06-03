using Microsoft.Playwright;
using System.Threading.Tasks;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Pages
{
    public class UnderwritingPage : BasePage
    {
        public UnderwritingPage(IPage page) : base(page) { }

        #region Locators
        private ILocator GetConvictedOfFelonyButton(string yesOrNo) =>
            _page.Locator("[id*='felonyConviction']").GetByRole(AriaRole.Button, new() { Name = yesOrNo });
        #endregion

        public async Task AnswerFelonyQuestion(string yesOrNo)
        {
            await GetConvictedOfFelonyButton(yesOrNo).ClickAsync();
        }
    }
}
