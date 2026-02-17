using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_POC.Locators
{
    /// <summary>
    /// Extended locators discovered via automated scanning - organized by functional area
    /// Generated from locator scan results on 2/12/2026
    /// </summary>
    /// 
    public static class DashboardTabsLocators
    {
        /// <summary>
        /// Main navigation tabs at the top of the ExpertQuote dashboard
        /// </summary>
        public static ILocator NewQuoteClearTab(IPage page) => page.Locator("#mat-tab-label-0-0");
        public static ILocator AddTab(IPage page) => page.Locator("#mat-tab-label-0-1"); 
        public static ILocator NewQuoteClearTablist(IPage page) => page.GetByRole(AriaRole.Tablist, new() { Name = "New Quoteclearadd" });
        public static ILocator QuoteTabContent(IPage page) => page.GetByLabel("New Quoteclear");
    }

    public static class QuoteSearchTableLocators
    {
        /// <summary>
        /// Recently accessed quotes table and column sorting controls
        /// </summary>
        public static ILocator RecentlyAccessedTable(IPage page) => page.GetByTestId("last-accessed-table");
        
        // Column Header Sorting Buttons
        public static ILocator SortByNameButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Name" });
        public static ILocator SortByTypeButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Type" });
        public static ILocator SortByQuotePolicyButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Quote / Policy #" });
        public static ILocator SortByLineButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Line" });
        public static ILocator SortByDateButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Date" });
        public static ILocator SortByQuotePolicyAltButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Quote/Policy #" });
        
        // Table Components
        public static ILocator TableHeader(IPage page) => page.GetByRole(AriaRole.Columnheader, new() { Name = "NameTypeQuote / Policy #Line" });
        public static ILocator TableRowGroup(IPage page) => page.GetByRole(AriaRole.Rowgroup);
    }

    public static class NavigationLinksLocators
    {
        /// <summary>
        /// External system navigation and resource links
        /// </summary>
        public static ILocator ExpertServiceLink(IPage page) => page.GetByText("ExpertService");
        public static ILocator LMSTrainingLibraryLink(IPage page) => page.GetByRole(AriaRole.Link, new() { Name = "LMS Training Library" });
        public static ILocator ProjectRoadMapLink(IPage page) => page.GetByRole(AriaRole.Link, new() { Name = "Project Road Map" });
        public static ILocator ReferralESignNotificationsLink(IPage page) => page.GetByRole(AriaRole.Link, new() { Name = "Referral & ESIGN Notifications" });
        
        // Quote Number Links (dynamic)
        public static ILocator QuoteLink01894636(IPage page) => page.GetByRole(AriaRole.Link, new() { Name = "01894636" });
        public static ILocator QuoteLink01908191(IPage page) => page.GetByRole(AriaRole.Link, new() { Name = "01908191" });
        public static ILocator QuoteLink01908193(IPage page) => page.GetByRole(AriaRole.Link, new() { Name = "01908193" });
        
        // Generic quote link finder
        public static ILocator QuoteLinkByNumber(IPage page, string quoteNumber) => page.GetByRole(AriaRole.Link, new() { Name = quoteNumber });
    }

    public static class ActionQueueLocators  
    {
        /// <summary>
        /// Notification and action queue management controls
        /// </summary>
        public static ILocator NotificationsButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "Notifications" });
        public static ILocator ActionQueueButton(IPage page) => page.GetByRole(AriaRole.Button, new() { Name = "ActionQueue" });
    }

    public static class QuoteManagementLocators
    {
        /// <summary>
        /// Quote-specific action buttons and controls  
        /// </summary>
        public static ILocator EditButton(IPage page) => page.GetByText("edit");
        public static ILocator OverrideButton(IPage page) => page.GetByText("override");
        
        // Line of Business Indicators
        public static ILocator SFPIndicator(IPage page) => page.GetByText("SFP");
        public static ILocator RuleIndicator(IPage page) => page.GetByText("Rule");
        
        // Client Names (example patterns - replace with dynamic finders)
        public static ILocator ClientFlorezJoseph(IPage page) => page.GetByText("Flores, Joseph");
        public static ILocator ClientRuleKw(IPage page) => page.GetByText("Rule, Kw");
    }

    public static class DashboardContentLocators
    {
        /// <summary>
        /// Dashboard content areas and informational elements
        /// </summary>
        public static ILocator WelcomeMessage(IPage page) => page.GetByText("It's a BRAND new day! Stay tuned for brand rollout enhancements. Need help with ExpertQuote? Please feel free to reach out to our ExpertQuote team by submitting a ServiceNow request.");
        public static ILocator BrandNewDayHeader(IPage page) => page.GetByText("It's a BRAND new day! Stay");
        public static ILocator ServiceNowRequestLink(IPage page) => page.GetByText("submitting a ServiceNow request");
    }

    public static class TableInteractionLocators
    {
        /// <summary>
        /// Generic table interaction patterns
        /// </summary>
        public static ILocator TableCell(IPage page) => page.GetByRole(AriaRole.Cell);
        public static ILocator TableRow(IPage page) => page.GetByRole(AriaRole.Row);
        public static ILocator GridCell(IPage page) => page.GetByRole(AriaRole.Gridcell);
        
        // Specific table cells with data
        public static ILocator TableCellWithQuoteData(IPage page) => page.GetByRole(AriaRole.Cell, new() { Name = "Flores, JosephQuote01908191SFPeditRule, KwoverrideQuote01908193SFPeditRule, KwoverrideQuote01894636SFP" });
    }

    public static class SearchControlsExtendedLocators
    {
        /// <summary>
        /// Extended search functionality beyond basic client search
        /// </summary>
        // Note: Most search inputs already exist in ClientSearchLocators
        // These are additional discovered elements that might be useful
        
        public static ILocator SearchResultsContainer(IPage page) => page.GetByRole(AriaRole.Table);
        public static ILocator SearchTableBody(IPage page) => page.GetByRole(AriaRole.Rowgroup);
    }
}