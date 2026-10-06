using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PnCTestAutomation.Helpers;
using static Microsoft.Playwright.Assertions;

namespace PnCTestAutomation.Pages.ExpertQuotePages.SFP
{
    public class SFP_NativeFormPage(IPage page) : BasePage(page)
    {
        public ILocator Field(string logicalName) =>
            Native(logicalName, ".value").And(_page.Locator("input:visible, textarea:visible, select:visible, mat-select:visible"));

        public ILocator Chips(string logicalName) =>
            Native(logicalName, ".value-chip-item-wrapper").And(_page.Locator(":visible"));

        public ILocator CheckboxLabel(string logicalName) =>
            Native(logicalName, ".value").And(_page.Locator("label:visible"));

        public ILocator ReadOnlyValue(string logicalName)
        {
            var parts = logicalName.Split('.');
            if (parts.Length != 2 || parts.Any(part => !Regex.IsMatch(part, "^[A-Za-z_][A-Za-z0-9_]*$")))
                throw new ArgumentException($"Expected a native Entity.Field identifier, received '{logicalName}'.");
            return _page.Locator(
                $"[id^='{parts[0]}.{parts[1]}-'][id$='-layout'].readonly-field:visible .readonly-value");
        }

        public ILocator Action(string name) =>
            _page.GetByTestId(new Regex(@"\." + Regex.Escape(name) + "$", RegexOptions.IgnoreCase))
                .And(_page.Locator("button:visible"));

        public async Task<string[]> FieldIdsAsync(string logicalName) =>
            await Field(logicalName).EvaluateAllAsync<string[]>(
                "elements => elements.map(element => element.getAttribute('data-testid') || element.id)");

        public async Task<string> AdditionalSectionAsync(string logicalName, string[] previousIds)
        {
            await Expect(Field(logicalName)).ToHaveCountAsync(previousIds.Length + 1);
            var added = (await FieldIdsAsync(logicalName)).Except(previousIds, StringComparer.Ordinal).ToArray();
            if (added.Length != 1)
                throw new PlaywrightException($"Expected one new {logicalName} field after selecting coverage, found {added.Length}.");
            return SectionOf(added[0]);
        }

        public async Task<string> SectionAsync(string logicalName)
        {
            await Expect(Field(logicalName)).ToHaveCountAsync(1);
            return SectionOf((await FieldIdsAsync(logicalName))[0]);
        }

        private static string SectionOf(string fieldId)
        {
            var fieldPath = fieldId[..fieldId.LastIndexOf('.')];
            return fieldPath[..fieldPath.LastIndexOf('.')];
        }

        public ILocator SectionField(string section, string logicalName)
        {
            var prefix = section.Replace("\\", "\\\\").Replace("'", "\\'");
            return Field(logicalName).And(_page.Locator($"[data-testid^='{prefix}.'], [id^='{prefix}.']"));
        }

        public async Task SetSectionAsync(string section, string logicalName, string value, bool number = false)
        {
            var prefix = section.Replace("\\", "\\\\").Replace("'", "\\'");
            var chips = Chips(logicalName).And(_page.Locator($"[data-testid^='{prefix}.'], [id^='{prefix}.']"));
            if (await chips.CountAsync() != 0)
                await SelectChipAsync(chips, value);
            else
                await SetControlAsync(SectionField(section, logicalName), value, number);
        }

        private ILocator Native(string logicalName, string suffix)
        {
            var parts = logicalName.Split('.');
            if (parts.Length != 2 || parts.Any(part => !Regex.IsMatch(part, "^[A-Za-z_][A-Za-z0-9_]*$")))
                throw new ArgumentException($"Expected a native Entity.Field identifier, received '{logicalName}'.");
            var tail = "." + parts[0] + "$" + parts[1] + suffix;
            return _page.Locator($"[data-testid$='{tail}' i], [id$='{tail}' i]");
        }

        private async Task<ILocator> ChoiceOptionsAsync(string logicalName)
        {
            var chips = Chips(logicalName);
            if (await chips.CountAsync() != 0)
                return chips;
            var parts = logicalName.Split('.');
            if (parts.Length != 2)
                throw new ArgumentException($"Expected Entity.Field, received '{logicalName}'.");
            var pattern = new Regex(@"\." + Regex.Escape(parts[0]) + @"\$" + Regex.Escape(parts[1])
                + @"\.value-\d+$", RegexOptions.IgnoreCase);
            return _page.GetByTestId(pattern).And(_page.Locator(":visible:not(input)"));
        }

        public async Task SelectChoiceAsync(string logicalName, Regex caption)
        {
            var choice = (await ChoiceOptionsAsync(logicalName)).Filter(new() { HasTextRegex = caption });
            await Expect(choice).ToHaveCountAsync(1);
            await choice.ClickAsync();
            await WaitForSpinnerAsync();
            await VerifyChoiceAsync(logicalName, caption);
        }

        public async Task VerifyChoiceAsync(string logicalName, Regex caption)
        {
            var choice = (await ChoiceOptionsAsync(logicalName)).Filter(new() { HasTextRegex = caption });
            await Expect(choice).ToHaveCountAsync(1);
            var selected = choice.Locator(".chip-wrapper-selected, [aria-checked='true'], input:checked")
                .Or(choice.And(_page.Locator(".chip-wrapper-selected, [aria-checked='true']")));
            await Expect(selected).Not.ToHaveCountAsync(0);
        }

        public async Task SetAsync(string logicalName, string value, bool number = false, bool moneyOption = false)
        {
            var chips = Chips(logicalName);
            if (await chips.CountAsync() != 0)
            {
                await SelectChipAsync(chips, value);
                return;
            }
            await SetControlAsync(Field(logicalName), value, number, moneyOption);
        }

        public async Task SetControlAsync(ILocator control, string value, bool number = false, bool moneyOption = false)
        {
            await Expect(control).ToHaveCountAsync(1);
            await Expect(control).ToBeVisibleAsync();
            var tag = await control.EvaluateAsync<string>("element => element.tagName.toLowerCase()");
            if (tag is "mat-select" or "select")
            {
                await SelectAsync(control, value, moneyOption);
                return;
            }
            if (await control.GetAttributeAsync("type") == "checkbox")
            {
                await control.SetCheckedAsync(SfpRequiredTable.YesNo(value));
                await WaitForSpinnerAsync();
                await Expect(control).ToBeCheckedAsync(new() { Checked = SfpRequiredTable.YesNo(value) });
                return;
            }
            if (await control.IsEditableAsync())
            {
                if (number || await control.GetAttributeAsync("type") == "search")
                {
                    await control.ClickAsync();
                    await control.PressAsync("Control+A");
                    await control.PressSequentiallyAsync(value);
                }
                else
                    await control.FillAsync(value);
                await control.PressAsync("Tab");
                await WaitForSpinnerAsync();
            }
            await VerifyTextAsync(control, value, number);
        }

        public async Task SetByLabelAsync(string caption, string value, bool number = false, string section = null)
        {
            var control = LabelledControl(caption, section);
            await SetControlAsync(control, value, number);
        }

        private ILocator LabelledControl(string caption, string section)
        {
            var control = _page.GetByLabel(Caption(caption)).And(_page.Locator(":visible"));
            if (section == null)
                return control;
            var prefix = section.Replace("\\", "\\\\").Replace("'", "\\'");
            return control.And(_page.Locator($"[data-testid^='{prefix}.'], [id^='{prefix}.']"));
        }

        public async Task VerifyAsync(string logicalName, string value, bool number = false)
        {
            var chips = Chips(logicalName);
            if (await chips.CountAsync() != 0)
            {
                var selected = chips.Filter(new() { HasTextRegex = Caption(value) }).Locator(".chip-wrapper-selected");
                await Expect(selected).ToHaveCountAsync(1);
                return;
            }
            await VerifyControlAsync(Field(logicalName), value, number);
        }

        public async Task VerifyControlAsync(ILocator control, string value, bool number = false)
        {
            await Expect(control).ToHaveCountAsync(1);
            await Expect(control).ToBeVisibleAsync();
            var tag = await control.EvaluateAsync<string>("element => element.tagName.toLowerCase()");
            if (tag == "mat-select")
                await SfpFieldAssertions.SelectionAsync(control, value);
            else if (tag == "select")
                await Expect(control.Locator("option:checked")).ToHaveTextAsync(Caption(value));
            else if (await control.GetAttributeAsync("type") == "checkbox")
                await Expect(control).ToBeCheckedAsync(new() { Checked = SfpRequiredTable.YesNo(value) });
            else
                await VerifyTextAsync(control, value, number);
        }

        public Task VerifyByLabelAsync(string caption, string value, bool number = false, string section = null) =>
            VerifyControlAsync(LabelledControl(caption, section), value, number);

        public async Task SelectChipAsync(ILocator chips, string caption)
        {
            var choice = chips.Filter(new() { HasTextRegex = Caption(caption) });
            await Expect(choice).ToHaveCountAsync(1);
            await Expect(choice).ToBeVisibleAsync();
            await choice.ClickAsync();
            await WaitForSpinnerAsync();
            await Expect(choice.Locator(".chip-wrapper-selected")).ToHaveCountAsync(1);
            await Expect(chips.Locator(".chip-wrapper-selected")).ToHaveCountAsync(1);
        }

        public async Task SelectAsync(ILocator select, string caption, bool moneyOption = false)
        {
            await Expect(select).ToHaveCountAsync(1);
            await Expect(select).ToBeVisibleAsync();
            var pattern = moneyOption ? MoneyCaption(caption) : Caption(caption);
            var enabled = await select.IsEnabledAsync() &&
                !string.Equals(await select.GetAttributeAsync("aria-disabled"), "true", StringComparison.OrdinalIgnoreCase);
            if (await select.EvaluateAsync<string>("element => element.tagName.toLowerCase()") == "select")
            {
                if (enabled)
                {
                    var option = select.Locator("option").Filter(new() { HasTextRegex = pattern });
                    await Expect(option).ToHaveCountAsync(1);
                    await select.SelectOptionAsync(await option.EvaluateAsync<string>("element => element.value"));
                    await WaitForSpinnerAsync();
                }
                await Expect(select.Locator("option:checked")).ToHaveCountAsync(1);
                await Expect(select.Locator("option:checked")).ToHaveTextAsync(pattern);
                return;
            }
            if (enabled)
            {
                await select.ClickAsync();
                var listbox = _page.GetByRole(AriaRole.Listbox).And(_page.Locator(":visible"));
                await Expect(listbox).ToHaveCountAsync(1);
                var option = listbox.GetByRole(AriaRole.Option).Filter(new() { HasTextRegex = pattern });
                await Expect(option).ToHaveCountAsync(1);
                var multiple = await listbox.GetAttributeAsync("aria-multiselectable") == "true";
                if (multiple)
                {
                    var unwanted = listbox.GetByRole(AriaRole.Option, new() { Selected = true })
                        .Filter(new() { HasNotTextRegex = pattern });
                    for (var remaining = await unwanted.CountAsync(); remaining > 0; remaining--)
                    {
                        await unwanted.First.ClickAsync();
                        await WaitForSpinnerAsync();
                        if (!await listbox.IsVisibleAsync())
                            await select.ClickAsync();
                        await Expect(unwanted).ToHaveCountAsync(remaining - 1);
                    }
                }
                if (!multiple || await option.GetAttributeAsync("aria-selected") != "true")
                    await option.ClickAsync();
                await WaitForSpinnerAsync();
                if (multiple && await listbox.IsVisibleAsync())
                    await select.PressAsync("Escape");
                await Expect(listbox).Not.ToBeVisibleAsync();
            }
            var displayed = select.Locator(".mat-select-value-text, .mat-mdc-select-value-text");
            await Expect(await displayed.CountAsync() == 0 ? select : displayed).ToHaveTextAsync(pattern);
        }

        public async Task CheckAsync(string logicalName)
        {
            var native = Native(logicalName, ".value");
            var input = native.And(_page.Locator("input[type='checkbox']"));
            var label = CheckboxLabel(logicalName);
            await Expect(input).ToHaveCountAsync(1);
            await Expect(label).ToHaveCountAsync(1);
            if (!await input.IsCheckedAsync())
                await label.ClickAsync();
            await WaitForSpinnerAsync();
            await Expect(input).ToBeCheckedAsync();
        }

        public async Task ClickActionAsync(string name)
        {
            var action = Action(name);
            await Expect(action).ToHaveCountAsync(1);
            await Expect(action).ToBeEnabledAsync();
            await action.ClickAsync();
            await WaitForSpinnerAsync();
            await ThrowIfQuoteErrorAsync($"executing {name}");
        }

        public async Task RequireReadyAsync(ILocator destination)
        {
            var review = _page.GetByRole(AriaRole.Dialog).Filter(new()
            {
                HasTextRegex = new Regex("Review Required", RegexOptions.IgnoreCase)
            });
            await destination.Or(review).And(_page.Locator(":visible")).First.WaitForAsync(
                new() { State = WaitForSelectorState.Visible, Timeout = 30000 });
            if (await review.IsVisibleAsync())
                throw new PlaywrightException($"SFP requires review; no correction was bypassed: {await review.InnerTextAsync()}");
            await ThrowIfQuoteErrorAsync("waiting for the requested SFP page");
            await Expect(destination).ToBeVisibleAsync();
        }

        public async Task<ILocator> SelectCatalogCoverageAsync(ILocator table, string column, string caption)
        {
            await Expect(table).ToBeVisibleAsync();
            var cell = _page.Locator($"td.mat-column-{column}, mat-cell.mat-column-{column}")
                .Filter(new() { HasTextRegex = Caption(caption) });
            var row = table.Locator("tr, mat-row").Filter(new() { Has = cell });
            return await SelectCatalogRowAsync(row);
        }

        public async Task<ILocator> SelectNamedCatalogCoverageAsync(ILocator table, Regex caption)
        {
            await Expect(table).ToBeVisibleAsync();
            var cell = _page.Locator("td, mat-cell").Filter(new() { HasTextRegex = caption });
            return await SelectCatalogRowAsync(table.Locator("tr, mat-row").Filter(new() { Has = cell }));
        }

        private async Task<ILocator> SelectCatalogRowAsync(ILocator row)
        {
            await Expect(row).ToHaveCountAsync(1);
            var input = row.Locator("input[type='checkbox'][data-testid$='Input$selected.value' i]");
            var label = row.Locator("label[data-testid$='Input$selected.value' i]");
            await Expect(input).ToHaveCountAsync(1);
            await Expect(label).ToHaveCountAsync(1);
            if (!await input.IsCheckedAsync())
                await label.ClickAsync();
            await WaitForSpinnerAsync();
            await Expect(input).ToBeCheckedAsync();
            return row;
        }

        public static async Task VerifyTextAsync(ILocator input, string value, bool number = false)
        {
            if (number)
                await SfpFieldAssertions.NumberAsync(input, value);
            else
                await Expect(input).ToHaveValueAsync(new Regex(
                    "^(?:" + Regex.Escape(value) + "|" + Regex.Escape(value.ToUpperInvariant()) + ")$"));
        }

        public static Regex Caption(string value) =>
            new(@"^\s*" + Regex.Escape(value.Trim()).Replace(@"\ ", @"\s+") + @"\s*$", RegexOptions.IgnoreCase);

        private static Regex MoneyCaption(string value)
        {
            var numbers = value.Replace("$", "").Replace(",", "").Split('/');
            if (numbers.Length != 2 || numbers.Any(part => !decimal.TryParse(part.Trim(),
                    NumberStyles.None, CultureInfo.InvariantCulture, out _)))
                throw new ArgumentException($"Expected an occurrence/aggregate limit, received '{value}'.");
            var parts = numbers.Select(part =>
                Regex.Escape(decimal.Parse(part.Trim(), CultureInfo.InvariantCulture)
                    .ToString("#,0", CultureInfo.InvariantCulture)).Replace(",", ",?"));
            return new Regex(@"^\s*\$?\s*" + string.Join(@"\s*/\s*\$?\s*", parts) + @"\s*$");
        }
    }
}
