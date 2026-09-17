using PnCTestAutomation.Models;

namespace PnCTestAutomation.Services
{
    public interface IFormsEvidenceWriter
    {
        void WriteCsv(FormsValidationSummary summary, string path);
        void WriteHtml(FormsValidationSummary summary, string path);
        void WriteMarkdown(FormsValidationSummary summary, string path);
        void WriteTrx(FormsValidationSummary summary, string path);
    }

    public sealed class FormsEvidenceWriter : IFormsEvidenceWriter
    {
        private readonly IFormsValidationService _validationService;

        public FormsEvidenceWriter(IFormsValidationService validationService)
        {
            _validationService = validationService;
        }

        public void WriteCsv(FormsValidationSummary summary, string path) =>
            _validationService.WriteResultsCsv(summary, path);

        public void WriteHtml(FormsValidationSummary summary, string path) =>
            FormsReportGenerator.Generate(summary, path);

        public void WriteMarkdown(FormsValidationSummary summary, string path) =>
            FormsReportGenerator.WritePipelineSummary(summary, path);

        public void WriteTrx(FormsValidationSummary summary, string path) =>
            FormsReportGenerator.WriteTrxResults(summary, path);
    }
}
