using Microsoft.Playwright;

namespace InsuranceAutomation.Pages.PageLocators;

public static class EQCommonEChecklistEChecklistLocators
{
        public static ILocator BuildingPhoto1(IPage page) =>
        page.GetByText(" Building Photo #1 ", new() { Exact = true });

        public static ILocator BuildingPhoto1Header(IPage page) =>
        page.GetByText(" Building Photo #1 ", new() { Exact = true });

        public static ILocator Accept(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Accept", Exact = true });

        public static ILocator Exception(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Exception", Exact = true });

        public static ILocator OKAccept(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

        public static ILocator OK(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "OK", Exact = true });

        public static ILocator ReviewComplete(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Review Complete", Exact = true });

        public static ILocator PolicyHeader(IPage page) =>
        page.Locator("id=policy-details-group");

        public static ILocator BuildingPhoto2(IPage page) =>
        page.GetByText(" Building Photo #2 ", new() { Exact = true });

        public static ILocator BuildingPhoto2Header(IPage page) =>
        page.GetByText(" Building Photo #2 ", new() { Exact = true });

        public static ILocator SignaturePageLink(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Signature Page", Exact = true });

        public static ILocator SignaturePageBoundCoverageOnlySFP(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Signature Page (bound coverage only)", Exact = true });

        public static ILocator Attach(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Attach", Exact = true });

        public static ILocator DragAndDropFilesHereToUploadOrClickHereToOpenAFileExplorer(IPage page) =>
        page.Locator("id=my-awesome-dropzone");

        public static ILocator Submit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Submit", Exact = true });

        public static ILocator OkSubmit(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Ok", Exact = true });

        public static ILocator LossRunsHeader(IPage page) =>
        page.Locator("id=checklist-item-name");

        public static ILocator LossRuns3YearsHeader(IPage page) =>
        page.Locator("id=checklist-item-name");

        public static ILocator ULRoofTypeCredit(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "UL Roof Type Credit", Exact = true });

        public static ILocator ULRoofTypeCreditHeader(IPage page) =>
        page.Locator("id=checklist-item-name");

        public static ILocator ResidencePhoto1(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Residence Photo #1", Exact = true });

        public static ILocator BuildingPhoto3Header(IPage page) =>
        page.GetByText(" Building Photo #3 ", new() { Exact = true });

        public static ILocator BuildingPhoto3(IPage page) =>
        page.GetByText(" Building Photo #3 ", new() { Exact = true });

        public static ILocator BuildingPhoto4Header(IPage page) =>
        page.GetByText(" Building Photo #4 ", new() { Exact = true });

        public static ILocator BuildingPhoto4(IPage page) =>
        page.GetByText(" Building Photo #4 ", new() { Exact = true });

        public static ILocator LeadAbatementRemovalStatementHeader(IPage page) =>
        page.GetByText(" Lead Abatement/Removal Statement ", new() { Exact = true });

        public static ILocator WindstormOrHailPercentageDeductiblesSelectionForm(IPage page) =>
        page.GetByRole(AriaRole.Link, new() { Name = "Windstorm or Hail Percentage Deductibles Selection Form", Exact = true });

}
