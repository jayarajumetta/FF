using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Playwright_POC.Locators;
using Playwright_POC.Helpers;

namespace TestAutomation.Pages.ExpertQuotePages
{
    public class PrimaryInsuredPage
    {
        private readonly IPage _page;

        public PrimaryInsuredPage(IPage page)
        {
            _page = page;
        }

        public async Task SelectExistingClientAsPrimaryInsuredAsync(ScenarioContextData contextData)
        {
            var existingClientButton = _page.Locator(PrimaryInsuredPageLocators.SelectPrimaryInsured);
            await _page.WaitForSelectorAsync(PrimaryInsuredPageLocators.SelectPrimaryInsured, new() { Timeout = 10000 });
            await existingClientButton.ClickAsync();

            await _page.ClickAsync(GlobalLocators.NextButton);
        }

        public async Task SearchPersonAsync(ScenarioContextData contextData)
        {
            await _page.FillAsync(PrimaryInsuredPageLocators.SearchPrimaryInsuredFirstNameInput, contextData.ClientFirstName);
            await _page.FillAsync(PrimaryInsuredPageLocators.SearchPrimaryInsuredLastNameInput, contextData.ClientLastName);
            await _page.ClickAsync(PrimaryInsuredPageLocators   .PrimaryInsuredSearchButton);

            // Selection of Primary Insured from search results will be implemented here later.
        }

        public async Task EnterPrimaryInsuredDetailsAsync(ScenarioContextData contextData)
        {
            var firstName = _page.Locator(AddPrimaryInsuredPageLocators.AddPrimaryInsuredFirstNameInput);
            var firstNameValue = (await firstName.InputValueAsync())?.Trim();
            if (string.IsNullOrWhiteSpace(firstNameValue))
                {
                await firstName.ClickAsync();
                await firstName.PressAsync("Control+A");
                await firstName.PressAsync("Delete");
                await firstName.FillAsync(contextData.ClientFirstName ?? string.Empty);
            }
            await _page.FillAsync(AddPrimaryInsuredPageLocators.AddPrimaryInsuredFirstNameInput, contextData.ClientFirstName);
            await _page.FillAsync(AddPrimaryInsuredPageLocators.AddPrimaryInsuredLastNameInput, contextData.ClientLastName);
            await _page.FillAsync(AddPrimaryInsuredPageLocators.AddPrimaryInsuredDOBInput, contextData.ClientDOB);
            await _page.ClickAsync(GlobalLocators.NextButton);
        }
    }
}
