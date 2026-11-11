namespace InsuranceAutomation.CLDC.Runtime;

public sealed class RegressionProfileRoot
{
    public string SchemaVersion { get; init; } = "1.0";
    public Dictionary<string, RegressionLobProfile> Profiles { get; init; } = new(StringComparer.OrdinalIgnoreCase);
}

public sealed class RegressionLobProfile
{
    public string Lob { get; init; } = string.Empty;
    public bool HasDuplicateId { get; init; }
    public bool LogoutAtEnd { get; init; }
    public RegressionTransactionProfile AdjustNewBusiness { get; init; } = new();
    public RegressionTransactionProfile PremiumIncrease { get; init; } = new();
    public RegressionTransactionProfile PremiumDecrease { get; init; } = new();
    public RegressionTransactionProfile InformationChange { get; init; } = new();
    public RegressionTransactionProfile MailingAddressChange { get; init; } = new();
    public RegressionTransactionProfile RenewManual { get; init; } = new();
    public RegressionTransactionProfile AdjustRenewal { get; init; } = new();
    public RegressionTransactionProfile OutOfSequenceEndorsement { get; init; } = new();
    public RegressionTransactionProfile CancelProrate { get; init; } = new();
    public RegressionTransactionProfile ReinstateProrate { get; init; } = new();
    public RegressionTransactionProfile CancelShortRate { get; init; } = new();
    public RegressionTransactionProfile ReinstateShortRate { get; init; } = new();
    public RegressionTransactionProfile CancelOutOfSequence { get; init; } = new();
    public RegressionTransactionProfile ReinstateOutOfSequence { get; init; } = new();
    public RegressionTransactionProfile CancelPolicyExpiration { get; init; } = new();
    public RegressionTransactionProfile ReinstatePolicyExpiration { get; init; } = new();
}

public sealed class RegressionTransactionProfile
{
    public string Transaction { get; init; } = string.Empty;
    public string DateRule { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
    public string ReasonDetail { get; init; } = string.Empty;
    public string ExpectedCharge { get; init; } = string.Empty;
    public string RateType { get; init; } = string.Empty;
    public string ChangeType { get; init; } = "none";
    public string PrimaryValue { get; init; } = string.Empty;
    public string SecondaryValue { get; init; } = string.Empty;
    public bool? RollToRenewal { get; init; }
    public string PacketTransaction { get; init; } = string.Empty;
    public string PacketType { get; init; } = string.Empty;
}
