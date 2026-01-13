using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace Playwright_POC.Helpers
{
    internal class Helpers
    {
        public static async Task ClickIfNotSelectedAsync(IPage page, string xpath)
        {
            var buttonLocator = page.Locator(xpath);
            bool isSelected = await buttonLocator.EvaluateAsync<bool>("el => el.classList.contains('mat-button-toggle-checked')");

            if (!isSelected)
            {
                await buttonLocator.ClickAsync();
            }
        }

    }
}
