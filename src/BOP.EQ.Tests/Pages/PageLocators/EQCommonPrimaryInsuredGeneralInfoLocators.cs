using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonPrimaryInsuredGeneralInfoLocators
{
        public static ILocator BusinessName(IPage page) =>
        page.Locator("id=fields.data.account.accountInput$businessName.value");

        public static ILocator DescriptionOfOperations(IPage page) =>
        page.Locator("id=fields.data.account.policyOutput$descriptionOfOperations.value");

        public static ILocator NumberOfFulltimeEmployees(IPage page) =>
        page.Locator("id=fields.data.account.lineInputNonShredded$numberOfEmployees.value");

        public static ILocator NumberOfPartTimeEmployees(IPage page) =>
        page.Locator("id=fields.data.account.lineInputNonShredded$numberOfPartTimeEmployees.value");

        public static ILocator NumberOfSeasonalEmployees(IPage page) =>
        page.Locator("id=fields.data.account.lineInputNonShredded$numberOfSeasonalEmployees.value");

        public static ILocator FarmBureauMemberNo(IPage page) =>
        page.GetByTestId("fields.data.account.policyInput$farmBureauMember.value-chip-wrapper");

        public static ILocator DoYouWishToDiscloseRaceAndGenderInfoNo(IPage page) =>
        page.GetByTestId("fields.data.policy.policyOutputNonShredded$raceAndGenderInformation.value-chip-wrapper");

        public static ILocator IsTheClientAMemberOfAnyProfessionalTradeAssociationNo(IPage page) =>
        page.GetByTestId("fields.data.account.policyInput$farmBureauMember.value-chip-wrapper");

        public static ILocator Save(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Save", Exact = true });

}
