# README_V61

V61 uses V60 as its base and removes the static fallback-locator subsystem completely. There are no FallbackLocators page catalogs, LocatorFallbackCatalogs, deterministic fallback candidate resolver, or AI/self-healing locator fallback. Page locators remain the source-controlled contract. CL/DC DuckCreekId continues to map to DOM `fieldref` with raw tag + fieldref as the preferred technical selector.

Frame handling is independent of fallback locators. The 114 raw Tosca controls that carried HtmlFrame ancestry were reduced to a small frame-hint map. At runtime the framework briefly probes the hinted frame, otherwise resolves in the top document, and caches the successful scope. Frame and element probes have bounded waits; a readiness timeout is diagnostic and does not itself fail the business step. The actual Playwright action still determines success/failure.

Every interaction uses the existing short highlight pulse before the action. Insured Type and Entity Type are now one dependent Page operation: select Insured Type, best-effort wait up to 2.5 seconds for Entity Type readiness, then select Entity Type. PressSequentially remains available for controls that require true key-by-key input.

Evidence is finalized after browser/context close. Failure screenshots are mandatory. Console/page errors, request/response/failure logs, HAR, Playwright trace and video can be collected. Passed and failed tests have separate attachment policies in framework.json, so screenshots/log/report/video/trace/HAR/console/network/bundle can be independently selected by outcome. NUnit attachments are staged into the individual test result directory and registered with TestContext.AddTestAttachment.

Browser launch uses `--start-maximized` for headed Chromium/Edge and no fixed viewport when maximize=true. Browser context/browser/Playwright are closed after every scenario by the evidence finalizer.

CL/DC authentication no longer uses ApplicationPage regex username/password/button locators. ApplicationSteps delegates credential entry to LoginPage.EnterUserNameAsync, EnterPasswordAsync and ClickLoginAsync, preserving the raw CL/DC login IDs/link semantics.

Quote descriptions are no longer hardcoded to AL/AZ or Tosca date tokens. All CL/DC flows entering DescriptionOfSpecifiedOperation call ScenarioData.BuildQuoteDescription(), producing STATE_LOB_RANDOM4_yyyyMMdd_HHmmss and capturing the actual entered value for later verification.

The V60 layered smoke-data model is retained: seven LOB base files plus one StateOverrides file. No state-specific full smoke JSON duplication is reintroduced.

Azure DevOps includes build-v61.yml and release-v61.yml. Both use `yyyyMMdd.increment` run naming. Build installs .NET/Python/Playwright, restores/builds, quality-checks and publishes an immutable compiled artifact. Release downloads that artifact and supports a single Test Plan case, a Test Plan suite, or full DLL/tag-filter execution; each publishes TRX with run attachments and raw evidence. The final email stage builds an HTML summary, places failed cases before passed cases, embeds failed report HTML in the body, and attaches the generated email report plus failed HTML reports. SMTP values are supplied as secure pipeline variables.

The v61 source-flow gate explicitly verifies all seven CL/DC smoke flows contain Effective Date, Product and Start, and all applicable non-WC client flows contain DOB plus the dependent InsuredType/EntityType operation. This guards the BAP Product and CPP DOB omissions observed during migration without inventing application steps not present in source evidence.
