using System;
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

            var resume = doc.Descendants("Session.resumeRs").FirstOrDefault();
            if (string.Equals((string)resume?.Attribute("status"), "failure", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("DuckCreek failed to resume the quote session for the Forms request.");

            var response = doc.Descendants("FormsEngine.initPrintJobRs").FirstOrDefault();
            if (string.Equals((string)response?.Attribute("status"), "failure", StringComparison.OrdinalIgnoreCase))
            {
                var message = response.Value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault()?.Trim() ?? "No error details were returned.";
                if (message.Length > 300)
                    message = message[..300] + "...";
                throw new InvalidOperationException($"DuckCreek Forms Engine returned status='failure': {message}");
            }

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
        /// Captures session and print-job metadata for diagnostics.
        /// </summary>
        public static FormsResponseMetadata ParseMetadata(string xmlContent)
        {
            var doc = XDocument.Parse(xmlContent);
            var meta = new FormsResponseMetadata();

            var resumeEl = doc.Descendants("Session.resumeRs").FirstOrDefault();
            if (resumeEl != null)
            {
                var resumeStatus = resumeEl.Attribute("status")?.Value ?? "";
                if (resumeStatus.Equals("failure", System.StringComparison.OrdinalIgnoreCase))
                    meta.Warnings.Add("Session.resumeRs status='failure'");
            }

            // FormsEngine.initPrintJobRs element
            var responseEl = doc.Descendants("FormsEngine.initPrintJobRs").FirstOrDefault();
            if (responseEl != null)
            {
                meta.ReturnSuccessStatus = responseEl.Attribute("returnSuccessStatus")?.Value ?? "";
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
