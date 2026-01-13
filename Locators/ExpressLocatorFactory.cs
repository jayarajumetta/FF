using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Locators
{
    public static class ExpressLocatorFactory
    {
        internal class ExpressDashboardLocators
        {
            public static string SelectSearchTypeFromDropDown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectClientName(string value) => $"xpath=.//a[contains(@title, '{value}')]";
            public static string SelectPolicyNumber(string value) => $"xpath=.//a[contains(@title, '{value}')]";
        }

        internal class ExpressSearchResultsPageLocators
        {
            public static string SelectLookingForRadioButton(string value) => $"xpath=.//div[contains(@class, 'radiobtton')//label[contains(text(), '{value}')]";
            public static string SearchFiltersPolicySelection(string value) =>$"xpath=.//a[contains(@title, '{value}')]";
            public static string OperatorSelectionFromDropdown(string value) => $"xpath=.//a[contains(@title, '{value}')]";
            public static string SelectSearchInFromDropdown(string value) => $"xpath=.//a[contains(@title, '{value}')]";
            public static string SelectPolicyStatusFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectPolicyOrQuoteNumberFromTable(string value) => $"xpath=.//a[contains(@title, '{value}')]";
            public static string SelectInsuredNameFromTable(string value) => $"xpath=.//a[contains(@title, '{value}')]";
            public static string SelectPaperlessEnrollmentFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectNamedInsuredPaperlessEntrollentFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
        }

        internal class ExpressCoveragesPageLocators
        {
            // Policy Coverage Section
            public static string SelectBodilyInjuryLimitFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectPropertyDamageLimitFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectUninsuredMotoristLimitFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectUnderinsuredMotoristLimitFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectMedicalPaymentsLimitFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";
            public static string SelectLossOfIncomeRadioButton(string value) => $"xpath=.//label[contains(text(), '{value})]";
            public static string SelectADDLimitFromDropdown(string value) => $"xpath=.//a[contains(text(), '{value}')]";

            // AD&D Operators Section
            public static string SelectADandDOperatorCheckbox(string value) => $"xpath=./dc-checkbox[contains(@data-dc-name, 'DriverInput.ADDOperator')]//div[contains(text(), '{value})]";

            // Loss of Income Operators Section
            public static string SelectLossOfIncomeCheckbox(string value) => $"xpath=./dc-checkbox[contains(@data-dc-name, 'DriverInput.IncomeLossOperator')]//div[contains(text(), '{value})]";

            // Vehicle Coverage Section
        }
    }
}
