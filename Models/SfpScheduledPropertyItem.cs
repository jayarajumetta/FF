namespace PnCTestAutomation.Models
{
    public sealed record SfpScheduledPropertyItem(
        string Code,
        string Description,
        int Amount,
        bool UnattendedVehicle,
        int? YearOfAppraisal,
        int? NamedPersonCount,
        string NamedPersonNames);
}
