using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Helpers
{
    public static class SfpFieldAssertions
    {
        public static async Task<decimal> PositiveAmountAsync(ILocator input, string field, float timeoutMs = 60000)
        {
            await Expect(input).ToHaveCountAsync(1);
            await Expect(input).ToBeVisibleAsync();
            await Expect(input).ToHaveValueAsync(new Regex(
                @"^\s*\$?\s*(?:[1-9][\d,]*(?:\.\d+)?|0?\.\d*[1-9]\d*)\s*$"),
                new() { Timeout = timeoutMs });
            return ParsePositiveAmount(await input.InputValueAsync(), field);
        }

        internal static decimal ParsePositiveAmount(string value, string field)
        {
            if (!decimal.TryParse(value, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), out var amount)
                || amount <= 0)
                throw new PlaywrightException($"{field} must be a numeric amount greater than zero, received '{value}'.");
            return amount;
        }

        public static async Task NumberAsync(ILocator input, string expected)
        {
            var number = decimal.Parse(expected, NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                CultureInfo.GetCultureInfo("en-US"));
            var formatted = number.ToString("#,0.############################", CultureInfo.InvariantCulture);
            var pattern = Regex.Escape(formatted).Replace(",", ",?");
            if (!formatted.Contains('.'))
                pattern += @"(?:\.0+)?";

            await Expect(input).ToBeVisibleAsync();
            await Expect(input).ToHaveValueAsync(new Regex(@"^\s*\$?\s*" + pattern + @"\s*$"));
        }

        public static async Task SelectionAsync(ILocator select, string expected)
        {
            await Expect(select).ToBeVisibleAsync();
            var displayed = select.Locator(".mat-select-value-text, .mat-mdc-select-value-text");
            if (await displayed.CountAsync() == 0)
                displayed = select;

            await Expect(displayed).ToHaveTextAsync(
                new Regex(@"^\s*" + Regex.Escape(expected.Trim()).Replace(@"\ ", @"\s*") + @"\s*$"));
        }
    }
}
