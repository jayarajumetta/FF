# Visual Studio synchronization

When a local Visual Studio instance is running, treat the solution currently open in Visual Studio as the source of truth.

- Resolve the active solution's full path through Visual Studio DTE before reading, editing, building, or running tests.
- Work only in the checkout containing that active solution. Never infer the checkout from the repository name, configured project, recent session, or another clone.
- If no solution is open, multiple Visual Studio instances make the target ambiguous, or DTE access fails, stop and ask the user to identify the intended solution.
- Before changing a file, protect unsaved Visual Studio editor content. Do not overwrite an unsaved buffer; ask the user to save it first.
- After changes, build or rebuild through the running Visual Studio instance and require `SolutionBuild.LastBuildInfo` to be `0`.
- Confirm the generated assembly or other requested output exists in the active checkout and that Git status is read from the same checkout.
- For project, solution, package, or generated-file changes, ensure Visual Studio reloads the affected project before considering the work complete.
- If the IDE cannot be synchronized, state that clearly instead of reporting success from only a separate command-line build.

# PnC automation engineering standard

Apply this standard to ExpertQuote, Duck Creek, Fusion, current and future APIs, shared services, integrations, Reqnroll, Playwright, and other systems added to the PnC automation program.

## Source and environment alignment

- Identify the environment under test before drawing source-based conclusions.
- Use these verified ExpertQuote mappings:
  - Quality: `origin/qa`
  - DEV: `origin/develop`
  - Production: `origin/master`
- Use `origin/Development` as the PnC automation baseline.
- Refresh relevant remote refs read-only before an investigation unless they were already refreshed in the current session.
- Do not switch or reset a dirty worktree to inspect another environment. Prefer `git show`, `git diff`, or an isolated worktree.
- Record the repository, branch, and commit used for important conclusions.
- Treat application, API, Fusion, and integration repositories as read-only unless the user explicitly authorizes a change.
- For a new system, first establish its owner, repository, environment mapping, deployed version, integration boundaries, and authoritative contracts. Do not infer these from repository names.

## Evidence and failure classification

Diagnose the responsible product or integration before changing automation. Use evidence in this order:

1. Authoritative product or integration response, including rule codes, API contracts, service errors, and payloads
2. Environment-aligned source
3. Playwright trace and network evidence
4. Screenshot or video
5. Logs and stack traces
6. Explicitly labeled hypothesis

Classify failures as:

- Expected business or underwriting behavior
- Application or integration defect
- Environment or infrastructure problem
- Automation defect
- Invalid, stale, or incomplete test data
- Unconfirmed pending additional evidence

Do not hide an application defect by weakening assertions or changing valid scenario data merely to avoid the behavior.

## Playwright and interaction standards

- Prefer `GetByTestId` for ExpertQuote interactive elements when a stable test ID exists.
- Use documented HTML `id` locators for ANi components that intentionally use IDs instead of `data-testid`.
- Use role, label, or text only as a constrained fallback when no stable test ID or documented ID exists.
- Use CSS, XPath, position, force-clicks, coordinates, DOM mutation, and JavaScript state injection only when explicitly justified and reviewed; never use them merely to force a test through.
- Use Playwright auto-waiting and web-first assertions rather than arbitrary sleeps.
- Model a trained user: use normal pointer and supported keyboard interactions, then verify the persisted business value or resulting workflow state.
- Use explicit destination-state waits instead of generic page-load or network-idle waits for applications with long-lived requests.
- Retry only safe, idempotent, demonstrably transient operations.

## Change and validation standards

- Review the existing implementation, related shared flows, focused tests, and environment-aligned source before editing.
- Make surgical, maintainable changes that correct the root cause without state-specific hacks or unnecessary abstractions.
- Reuse an existing helper only when its contract matches the required behavior.
- Preserve strict checks. Add an expected-continuation path only when the business workflow explicitly permits continuation.
- Add a focused deterministic regression for a changed failure condition.
- Run the smallest relevant test group and a Release build for code changes.
- Do not run complete end-to-end scenarios unless the user explicitly requests it; the user normally performs full scenario runs locally.
- Documentation-only instruction changes do not require a build unless documentation validation exists.

## Approval boundaries

Require explicit user approval before:

- Committing or pushing changes
- Creating, updating, approving, or merging pull requests
- Modifying Azure DevOps work items, test cases, pipelines, schedules, policies, or agents
- Rerunning or canceling pipelines
- Promoting forms or premium baselines
- Replacing expected premiums with newly observed values
- Applying locator self-healing changes without source evidence and focused validation
- Modifying application, Fusion, API, integration, or Duck Creek repositories

Never expose credentials, tokens, personal information, proprietary rating data, or sensitive payload content.
