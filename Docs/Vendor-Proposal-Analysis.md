# Sutherland Discovery Assessment — Response & Corrections
**Date:** July 31, 2026
**Prepared by:** PnC Test Automation Team
**For:** Meeting with David & Andy — early August 2026
**Subject:** Response to Sutherland Discovery & Migration Assessment (14–30 July 2026)

---

## Executive Summary

Sutherland conducted a genuine 14-day discovery exercise. The Tosca inventory (1,582 test instances), the process gap analysis, and the Validate → Document → Automate methodology are solid and worth acting on. The process gaps on slide 13 are real.

**However, the TypeScript recommendation is a vendor preference, not a technical requirement.** The evidence for this is in Sutherland's own deliverables:

- They built **5 POCs. 4 of them were in C#.** All 4 passed.
- The one TypeScript POC (Duck Creek Native) succeeded — but C# Playwright also runs on ExtJS. TypeScript was their choice, not a platform requirement.
- Every capability listed as a TypeScript advantage either already exists in the C# framework, can be added incrementally, or is a process/tooling decision independent of language.
- Several of their "current state gaps" are factually incorrect about the C# framework — specifically locators, screenshots/videos, and test data management — which calls into question the objectivity of the comparison.

**The practical impact of accepting Option A:** Farm Family absorbs 6 months and significant cost to reach parity with what already exists today — with no net new capability. Sutherland gets paid to rebuild everything from scratch in their preferred language.

**Recommendation: Retain and enhance the C# framework. Address the real gaps (process, traceability, reporting format) incrementally. Do not rebuild what already works.**

> **Core argument for the meeting:** This is not a debate about whether TypeScript is a good language. It is a question of whether a complete rewrite is *necessary* given what already exists. Sutherland has not demonstrated that it is. The correct challenge to put to them is: *"Show us one thing the C# framework cannot do that TypeScript can — that matters to Farm Family's stated goals."*

---

## The Core Argument: Preference vs. Necessity

The central question is not "is TypeScript good?" It is "is a rewrite *necessary*?" Sutherland has not demonstrated necessity. They have demonstrated preference.

**Their own POC results prove the point:**

| Application | Tech Stack Sutherland Used | Result |
|---|---|---|
| Express Quote (Angular) | **C#, Reqnroll** | SFP quote passed |
| Duck Creek Native (ExtJS) | **TypeScript, Node.js** | BAP quote, 45/45 states |
| GW ClaimCenter | **C#, Reqnroll** | Smoke suite passed |
| GW BillingCenter | **C#, MSTest** | Extent report produced |
| Policy Forms API | **C#, Reqnroll** | 18 API test cases passed |

4 of 5 POCs were built in C# and all passed. The one TypeScript POC worked — but that proves TypeScript *can* automate DC Native, not that C# *cannot*. Playwright .NET runs on ExtJS. No technical blocker has been identified.

If C# cannot do the job, the burden of proof is on Sutherland to demonstrate a specific capability gap. That demonstration has not been made.

---

## What Sutherland Does Not Know About the Current Framework

Several gaps cited in the assessment are either already addressed or significantly overstated. These need to be corrected because they are used to justify the Option A recommendation.

### Reporting — Partially Valid, Significantly Overstated

**What they said:** "Basic HTML Report only. No screenshots. No Gherkin steps."

**Reality:** The C# framework already captures full-page screenshots, videos, and Playwright traces per test in `TestHooks.cs`, organized per scenario. What is missing is surfacing these in a rich report format — the *capture* is done, the *presentation* is not. This is a reporter integration task (Allure or equivalent), not a framework rewrite. **Enhanced reporting has already been discussed as a near-term improvement and is on the roadmap.**

### Test Data Management — Already Built

**What they said:** Test data management is an open gap requiring a solution as part of the migration.

**Reality:** The current framework includes a fully operational **Data Pool service** — a self-contained ASP.NET application that manages test data creation, pooling, and allocation for automated test execution. **Sutherland appears to be entirely unaware this exists.** This should be demonstrated to them before any test data architecture conversation proceeds.

### Locators — Factually Incorrect

**What they said:** "Locating mechanism only in CSS. Self Healing can't be used."

**Reality:** The framework uses Playwright .NET's full locator API — `GetByRole()`, `GetByText()`, `GetByLabel()`, `GetByTestId()` — with CSS/XPath only as fallbacks. This is verifiable by opening any file in `Pages/`. Additionally, "Self Healing" is a feature of separate commercial tools (Testim, Healenium) — **it is not a TypeScript Playwright capability either.** Sutherland's own Option B slide acknowledges "CSS Locators with Fallback Strategy" and "Smart Waits, Retry Logic" — both of which are already implemented.

### Traceability and Test Repository — ADO Process Gap, Not a Language Gap

**What they said:** No centralized test repository. Limited traceability.

**Reality:** These are genuine gaps — but they are solved by configuring **Azure DevOps Test Plans**, which is already licensed. Switching to TypeScript does not create traceability. Configuring ADO does. The fix is weeks of process work, not a language migration.

---

## The TypeScript Advantages — Examined Against the Actual Codebase

| Sutherland's Claim | Reality |
|---|---|
| "Playwright currency — first-party language" | .NET Playwright is at full feature parity for every capability used in this codebase. The delta is weeks on bleeding-edge features that are not relevant to the current workload. |
| "Readable authoring — Gherkin hard to scale" | Reqnroll/Gherkin IS the plain-English authoring standard. 35 states per suite with Scenario Outlines is exactly the pattern Gherkin was designed for. |
| "Larger reporting ecosystem" | Allure, the Playwright HTML reporter, and ADO TRX publishing all work natively in C#. This is already in the enhancement roadmap. |
| "Front-end alignment — same as React" | Relevant only if QA writes front-end code. For test automation against an existing app, the language of the app's UI is irrelevant to the test framework language. |
| "Native, richer API interception" | `page.RouteAsync()` exists in C# Playwright. `ApiService.cs` and `ApiHelpers.cs` already handle API-level testing. |
| "Closest fit to plain-English authoring" | When pressed, Sutherland clarified this refers to AI-assisted test generation. Farm Family already holds a **GitHub Copilot license**, which is actively integrated into the C# development workflow. Playwright CodeGen (`--target csharp`) records workflows and generates C# code. Copilot, already aware of the existing page object patterns and framework conventions, restructures that output into production-ready page objects. This full AI-assisted authoring workflow is available today in C# — no migration required. |

**None of these are blockers. All are either already present or addressable within the current framework.**

---

## GitHub Copilot — The AI Advantage Sutherland Overlooked

Sutherland's recommendation leans heavily on AI-assisted test generation as a TypeScript advantage. This overlooks a significant capability already licensed and in active use.

**Farm Family holds a GitHub Copilot license.** Copilot is integrated directly into the development environment and is already being used within the C# framework. Its advantages in the current context:

| Copilot Capability | Application to C# Framework |
|---|---|
| Codebase-aware code generation | Copilot understands existing page objects, step definitions, and conventions — generates consistent code that fits the established patterns |
| Playwright CodeGen + Copilot workflow | Record a workflow with `codegen --target csharp`, paste into Copilot, ask it to restructure into the POM — new page objects in minutes |
| Step definition generation | Describe a new test scenario in plain English; Copilot generates the Reqnroll step definitions and wiring |
| Pipeline and config authoring | YAML pipelines, runsettings, and ADO configuration generated and reviewed by Copilot |
| Refactoring and gap analysis | Copilot identifies inconsistencies, suggests improvements, and flags locator fragility across the page object library |

Critically, **Copilot is language-agnostic** — it is not a TypeScript advantage. The AI-assisted authoring benefit Sutherland attributes to TypeScript exists equally, and in the context of an established codebase, more powerfully in C# because Copilot already knows the framework.

---

## The Real Cost of Option A

The migration cost is entirely borne by Farm Family:

| Work Item | Estimate |
|---|---|
| Rebuild 70 Express Quote tests in TypeScript | 8–12 weeks |
| Rebuild full page object library | 4–6 weeks |
| Rebuild auth, Data Pool integration, API service | 2–3 weeks |
| Rebuild CI/CD pipeline and shard configuration | 1–2 weeks |
| Team TypeScript upskilling | 3–4 weeks (overlapping) |
| **Total before parity with today** | **~5–6 months** |

During that period, the existing test suite is frozen or run in parallel at double maintenance cost. At the end, Farm Family has what it has today — in a different language — plus an ongoing dependency on Sutherland's TypeScript expertise for maintenance.

---

## What Sutherland Got Right — The Process Gaps

These findings are accurate, important, and should be addressed regardless of language decision:

| Gap | Action |
|---|---|
| Two teams running different STLCs | Establish one STLC standard across Duck Creek and Guidewire |
| No requirement-to-defect traceability | Configure ADO Test Plans — already licensed |
| Metrics and measurement missing | Define quality metrics with business sign-off |
| Coverage not tracked / no living test plan | Living test plan in ADO, maintained as part of definition-of-done |
| Automation runs apart from release teams | Shared regression ownership; change-notification loop into automation |

These are process and ADO configuration problems. **None of them require TypeScript to solve.**

---

## The BrowserStack Test Management Proposal

This should be declined regardless of the language decision. ADO Test Plans, already licensed, covers every feature on their BrowserStack slide:

| BrowserStack TM | ADO Equivalent |
|---|---|
| Test Scenarios | Test Suites |
| Test Cases (Manual) | Test Cases |
| Test Runs | Test Runs |
| Execution Reports | Test Run Reports |
| Milestones & Releases | Milestones |
| Dashboards & Analytics | ADO Dashboards |

Adding BrowserStack Test Management means paying twice for identical capability and maintaining two systems in sync.

---

## The C# Enhancement Path — What We Do Instead

Rather than a rewrite, the following enhancements close every legitimate gap Sutherland identified:

| Gap | Solution | Effort |
|---|---|---|
| Report format (no screenshots/Gherkin inline) | Integrate Allure reporter — artifacts already captured | Days |
| No living test plan / traceability | Configure ADO Test Plans, link scenarios to test cases | 1–2 weeks |
| Process gaps (STLC, metrics, silos) | Process track — Sutherland's own recommendation | Parallel workstream |
| CodeGen / AI-assisted authoring | `playwright codegen --target csharp` + GitHub Copilot (licensed) | Already available, actively in use |
| GitHub Copilot integration | Codebase-aware generation, POM refactoring, step definition authoring | Licensed and active |
| DC Native / Guidewire automation | Net-new C# work aligned to migration roadmap | Per roadmap |

---

## Summary: What to Raise at the David & Andy Meeting

1. **Lead with agreement on the process gaps.** They are real. Commit to addressing them. This is not in dispute.

2. **Correct the framework characterization before any language decision.** Locators, screenshots/videos, and test data management are all misrepresented. These inaccuracies inflate the "problems" side of their comparison table.

3. **Demonstrate the Data Pool service.** Sutherland proposed test data management as an open problem. Show them what already exists.

4. **Challenge the necessity framing.** Ask Sutherland to identify one specific capability the C# framework cannot provide that TypeScript can — that is material to Farm Family's goals. The answer should drive the conversation.

5. **Point to their own POC results.** 4 of 5 POCs were C# and passed. The TypeScript POC proved TypeScript *works* — it did not prove C# *doesn't*.

6. **Decline BrowserStack Test Management.** ADO already does everything on that slide.

7. **Propose the enhancement path.** Close the real gaps incrementally in C#. Agree on the migration roadmap sequencing (Wave 1–4 is sound). Separate the language question from the migration planning question.

---

## Talking Points for the Meeting

**Opening:**
> "We think the process gap analysis and the Validate → Document → Automate approach are exactly right, and we want to move forward on those. Before we discuss the language recommendation, we need to walk through a few things in the current state assessment that don't reflect what's actually in the codebase — because those gaps are being used to justify the Option A recommendation."

**The core challenge:**
> "We're not disputing that TypeScript works. Sutherland's DC Native POC is a good result. The question we need answered is: what can TypeScript do for Farm Family that C# cannot? Not what TypeScript does well — what C# specifically cannot do. We haven't seen that answer yet, and four of Sutherland's own five POCs were built and passed in C#."

**On reporting:**
> "The assessment says we have no screenshots or videos. What we actually have is full-page screenshots, videos, and Playwright traces captured per test in our test hooks. What we don't have is those artifacts surfaced in a rich report format. That's an Allure integration — days of work in the current framework. We've already planned it."

**On test data management:**
> "Sutherland has proposed a test data solution as part of the migration. We already have one — a Data Pool service that manages test data creation and allocation. We'd like to walk through it before any architecture decisions are made on that front."

**On locators:**
> "The current state slide says we only use CSS locators. Our page objects use GetByRole, GetByText, GetByLabel, and GetByTestId throughout. That's verifiable by opening the Pages folder. We want to make sure the comparison table is based on accurate inputs."

**On AI-assisted authoring and GitHub Copilot:**
> "One of Sutherland's key arguments for TypeScript is AI-assisted test generation. We already have a GitHub Copilot license and it's actively integrated into the C# workflow. We use it today for code generation, page object authoring, pipeline configuration, and test refactoring. Copilot is language-agnostic — it isn't a TypeScript advantage. In fact, because Copilot already knows our codebase patterns and conventions, it's more useful in C# than it would be starting from scratch in TypeScript."

**On BrowserStack:**
> "ADO Test Plans covers every feature on the BrowserStack Test Management slide. We'd like to understand what the additional spend buys before committing to a second system."

**Closing:**
> "We want to work with Sutherland on the migration. The roadmap sequencing makes sense, the process work is real, and the Validate → Document → Automate approach is right. What we're asking is that the language decision be based on technical necessity — not preference — and that the current framework be accurately represented before that decision is made."
