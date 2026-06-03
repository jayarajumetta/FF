using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PnCTestAutomation.Models;

namespace PnCTestAutomation.Parsers
{
    /// <summary>
    /// Parses the DuckCreek FormsEngine.initPrintJobRs XML response into strongly-typed models.
    /// Replaces the PowerShell XML parsing:
    ///   $XmlDocument.server.responses.'FormsEngine.initPrintJobRs'.printJob.printDoc
    /// </summary>
    public static class FormsXmlParser
    {
        /// <summary>
        /// Extracts all printDoc entries from the FormsEngine initPrintJob response XML.
        /// Each printDoc has attributes: name, selected (0/1/2), docType, caption.
        /// </summary>
        public static List<ActualFormEntry> Parse(string xmlContent)
        {
            var doc = XDocument.Parse(xmlContent);
            var forms = new List<ActualFormEntry>();

            // Path: server > responses > FormsEngine.initPrintJobRs > printJob > printDoc
            var printDocs = doc.Descendants("printDoc");

            foreach (var element in printDocs)
            {
                var name = element.Attribute("name")?.Value ?? string.Empty;
                var selectedStr = element.Attribute("selected")?.Value ?? "0";
                int.TryParse(selectedStr, out var selected);

                forms.Add(new ActualFormEntry
                {
                    Name = name,
                    Selected = selected,
                    DocType = element.Attribute("docType")?.Value,
                    Caption = element.Attribute("caption")?.Value
                });
            }

            return forms;
        }

        /// <summary>
        /// Extracts response envelope metadata.
        /// DuckCreek XML will contain "failure" status nodes because the API user differs
        /// from the UI session user — this is expected and does not mean the request failed.
        /// </summary>
        public static FormsResponseMetadata ParseMetadata(string xmlContent)
        {
            var doc = XDocument.Parse(xmlContent);
            var meta = new FormsResponseMetadata();

            // Session.resumeRs — capture status but DO NOT treat 'failure' as a warning.
            // The API user ≠ UI session user, so DuckCreek always reports this as failure.
            var resumeEl = doc.Descendants("Session.resumeRs").FirstOrDefault();
            if (resumeEl != null)
            {
                var resumeStatus = resumeEl.Attribute("status")?.Value ?? "";
                if (resumeStatus.Equals("failure", System.StringComparison.OrdinalIgnoreCase))
                    meta.Warnings.Add($"Session.resumeRs status='failure' (expected — API user ≠ session user)");
            }

            // FormsEngine.initPrintJobRs element
            var responseEl = doc.Descendants("FormsEngine.initPrintJobRs").FirstOrDefault();
            if (responseEl != null)
            {
                meta.ReturnSuccessStatus = responseEl.Attribute("returnSuccessStatus")?.Value ?? "";
                // returnSuccessStatus may be missing or '0' due to user mismatch — this is informational only
            }

            // printJob element
            var printJobEl = doc.Descendants("printJob").FirstOrDefault();
            if (printJobEl != null)
            {
                meta.PrintJobName = printJobEl.Attribute("name")?.Value ?? "";
                meta.Manuscript = printJobEl.Attribute("manuscript")?.Value ?? "";
            }

            // roleBasedSecurity
            meta.HasRoleBasedSecurity = doc.Descendants("roleBasedSecurity").Any();

            return meta;
        }
    }
}
