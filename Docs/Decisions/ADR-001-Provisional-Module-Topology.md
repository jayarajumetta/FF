# ADR-001: Provisional In-Assembly Product Module Topology

- Status: Provisional; architecture decision required
- Package baseline: 1.4.0
- Decision owner: Architecture/David

## Context

The combined framework currently keeps shared contracts and SFP reference
workflows in `TestAutomation.dll`. Product boundaries are represented by
`IProductModule` descriptors and shared control/frame/evidence services.
Original SGS features remain retained and non-runnable until product adapters
are implemented against those shared contracts. This gives the integration branch one lifecycle, one dependency
graph, one test assembly, and one package while the imported product
boundaries are still blocked.

Moving immediately to physical `Framework` and `Products.*` projects would
change assembly boundaries, dependency direction, Reqnroll binding discovery,
configuration/resource copying, Playwright/runtime packaging, and CI test
inventory. The current evidence does not establish that this change is needed
or identify the intended dependency graph. This milestone must not make that
architecture choice on David's behalf.

## Provisional decision

Retain the current in-assembly topology for package 1.4.0. Treat
`IProductModule`, product namespaces, typed profiles, workflow interfaces, and
shard suites as logical boundaries, not as approval of the final physical
solution structure. No new product-specific hooks, browser factories, retry
systems, result writers, or pipelines may be introduced while this status is
provisional.

## Decision required

Architecture/David must explicitly choose one of these before physical
separation:

1. Keep one test assembly and formalize logical module boundaries.
2. Extract shared contracts/runtime into a `Framework` project and create
   product binding/test projects that reference it.
3. Use another documented dependency graph with equivalent lifecycle,
   discovery, package, and evidence guarantees.

The decision must specify:

- allowed project references and where Reqnroll bindings/hooks live;
- ownership of browser/API lifecycle, control resolution, profiles, quote
  handoffs, evidence finalization, and retry;
- resource-copy and configuration behavior;
- generated-code and binding-discovery boundaries;
- whether CI inventories one or multiple test assemblies;
- package layout and versioning implications;
- migration order and compatibility criteria.

## Acceptance evidence

Before changing topology, provide an approved diagram/decision record, a
dependency-cycle check, equivalent Reqnroll discovery and shard counts, no
duplicate hooks/services, package-inventory parity, and canonical
result/evidence/Test Plans parity. Until then,
`Resources/Contracts/integration-readiness.json` must report
`ProvisionalInAssembly` and every workflow remains gated on the
Architecture/David approval.
