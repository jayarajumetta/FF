using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace Playwright_POC.Pages
{
    public class UnderwritingPage
    {
        private readonly IPage _page;
        public UnderwritingPage(IPage page)
        {
            _page = page;
        }

        public async Task AnswerFelonyQuestion(string yesOrNo)
        {
            // Have you or any household member ever been convicted of a felony?
            await ExpertQuoteLocatorFactory.UnderwritingQuestionsPageLocators.ConvictedOfFelonyQuestion(_page, yesOrNo).ClickAsync();
        }
    }
}
