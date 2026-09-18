# Finding the combined framework in Visual Studio

## Open the integration branch

The combined framework is maintained on:

`pa3402-anico-combined-framework-integration`

In Visual Studio:

1. Close any currently open solution.
2. Open **Git > Manage Branches**.
3. Fetch the `origin` remote.
4. Check out `origin/pa3402-anico-combined-framework-integration` as a local branch if it is not already checked out.
5. Open `PnC-TestAutomation.sln` from the repository root.
6. In Solution Explorer, select **Switch Views > Solution View** and clear any active search or filter.

If Visual Studio opened a different clone or worktree, use **File > Open > Project/Solution** and select the solution from the checkout whose Git status bar shows the integration branch.

## Solution layout

- **01 - Automation Framework**
  - `PnC Test Automation`: executable Reqnroll/Playwright framework and existing PnC tests.
- **02 - SGS Deliverables**
  - **Commercial Lines - DuckCreek**: 18 retained feature files.
  - **Commercial Lines - ExpertQuote**: 5 retained feature files.
  - **Personal Lines - DuckCreek**: 9 retained feature files.
- **03 - Supporting Projects**
  - `DataPool`: local data persistence service.
  - `TestAutomation.UnitTests`: framework contract tests.
- **04 - Tools**
  - compiled test inventory and Azure Test Plans publisher.
- **Solution Items**
  - framework entry documentation, configuration, and SGS inventory manifests.

The SGS feature shortcuts under **02 - SGS Deliverables** open the same physical files compiled by the main project; they are not copies.

## Physical paths

Within `PnC Test Automation`, the retained source files remain in stable runtime paths:

- Existing PnC features: `Features\BOP`, `Features\PA`, and `Features\SFP`
- SGS features: `Features\SGS\<product>`
- SGS scenario data: `Resources\SGS\<product>\TestData`
- SGS frame metadata: `Resources\SGS\CommercialLines.DuckCreek\Runtime`
- Inventory manifests: `Resources\Contracts\sgs-feature-inventory.json` and `sgs-data-inventory.json`
- Framework code: `BusinessOutcomes`, `Configuration`, `Context`, `Controls`, `Hooks`, `Infrastructure`, `Integrations`, and `Services`

Expand **PnC Test Automation > Resources > SGS** to browse all 1,153 retained SGS resource files. Visual Studio may take a moment to populate this node.

## Confirm the correct checkout

Open **View > Terminal** in Visual Studio and run:

```powershell
git branch --show-current
git rev-parse --short HEAD
git ls-files Features\SGS Resources\SGS | Measure-Object
```

The branch must be `pa3402-anico-combined-framework-integration`. The tracked SGS path count is 1,185: 32 feature files and 1,153 resource files.

The SGS scenarios are intentionally tagged `@SgsImported @NonRunnable @NoRetry`. Seeing them in Solution Explorer or Test Explorer confirms discovery; it does not mean their destination bindings and live browser adapters are complete.
