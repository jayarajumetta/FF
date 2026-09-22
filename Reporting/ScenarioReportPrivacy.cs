#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PnCTestAutomation.Helpers;

namespace PnCTestAutomation.Reporting;

public sealed class ScenarioReportPrivacy
{
    private readonly IConfiguration _configuration;
    private readonly ScenarioContextData _state;
    private readonly object _gate = new();
    private readonly HashSet<string> _runtimeSecrets = new(StringComparer.Ordinal);

    public ScenarioReportPrivacy(IConfiguration configuration, ScenarioContextData state)
    {
        _configuration = configuration;
        _state = state;
    }

    public void RegisterSensitiveValue(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        lock (_gate)
            _runtimeSecrets.Add(value);
    }

    public ReportRedactor CreateRedactor()
    {
        var policy = new ReportRedactor();
        var values = _configuration.AsEnumerable()
            .Where(pair => policy.Value(pair.Key, "") == ReportRedactor.Mask)
            .Select(pair => pair.Value)
            .Concat(_state.SgsData.Inputs
                .Where(pair => policy.Value(pair.Key, "") == ReportRedactor.Mask)
                .Select(pair => pair.Value.Value))
            .Concat(_state.SgsData.Captures
                .Where(pair => policy.Value(pair.Key, "") == ReportRedactor.Mask)
                .Select(pair => pair.Value))
            .Concat(new[]
            {
                _state.Client?.FirstName, _state.Client?.MiddleName, _state.Client?.LastName,
                _state.Client?.DateOfBirth, _state.Client?.Phone, _state.Client?.Email, _state.Client?.SSN,
                _state.Address?.Street, _state.Driver?.FirstName, _state.Driver?.LastName,
                _state.Driver?.DateOfBirth, _state.Driver?.Phone, _state.Driver?.Email,
                _state.Driver?.LicenseNumber, _state.VehicleInfo?.VIN,
                _state.Payment?.AccountNumber, _state.Payment?.RoutingNumber, _state.Payment?.CheckNumber,
                _state.AdditionalInterest?.Name, _state.AdditionalInterest?.Address,
                _state.AdditionalInterest?.Phone, _state.AdditionalInterest?.DateOfBirth,
                _state.AdditionalInterest?.LicenseNumber
            })
            .Where(value => !string.IsNullOrEmpty(value))
            .Select(value => value!)
            .ToList();
        lock (_gate)
            values.AddRange(_runtimeSecrets);
        return new ReportRedactor(values);
    }
}
