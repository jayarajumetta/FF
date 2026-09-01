# Consolidated execution reporting

Each scenario continues to create its individual `report.html`. `ScenarioReport` additionally creates `scenario-result.json` containing the feature, scenario, status, duration, executed business steps, resolved data, errors and evidence paths.

After one or more execution stages, run:

```powershell
python .\tools\generate_consolidated_report.py `
  --evidence-root .\Artifacts `
  --source-root . `
  --output-dir .\Artifacts\Consolidated
```

The output is:

- `report.html` — feature/scenario dashboard with failed tests first and expandable step detail;
- `log.html` — flat feature, scenario, step, C# binding, duration and error log;
- `output.xml` — Robot-style XML suitable for machine processing;
- `summary.json` — run totals and feature totals.

The generator discovers scoped ReqnRoll attributes in `tests/*/StepDefinitions/*.cs` and maps each executed step to its C# class, method, file and source line.

To send the completed report, configure `SMTP_HOST`, `SMTP_PORT`, `SMTP_FROM`, `SMTP_TO`, optional `SMTP_USER`, `SMTP_PASSWORD` and `SMTP_SSL`, then run:

```powershell
python .\tools\send_consolidated_report.py `
  --report-dir .\Artifacts\Consolidated `
  --subject "Insurance automation execution"
```

SMTP credentials are never read from repository files.
