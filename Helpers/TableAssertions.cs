using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnCTestAutomation.Helpers
{
    public static class TableAssertions
    {

        public static async Task AssertNameNotInTableAsync(IPage page, string tableSelector, string nameToExclude)
        {
            var rows = await page.QuerySelectorAllAsync($"{tableSelector} tbody tr");

            foreach (var row in rows)
            {
                var firstCell = await row.QuerySelectorAsync("td:first-child");
                if (firstCell != null)
                {
                    var cellText = await firstCell.InnerTextAsync();
                    Assert.That(cellText.Trim(), Is.Not.EqualTo(nameToExclude), $"Name '{nameToExclude}' was found in the table.");
                }
            }
        }
    }

}
