# README_V59

V59 applies the observed Duck Creek DOM contract: Tosca DuckCreekId is rendered as the DOM `fieldref` value. For every raw Duck Creek control carrying both a DuckCreekId and a supported raw tag, the technical primary is `tag[fieldref="DuckCreekId"]`. Client Search uses the exact AccountInput fieldrefs for Insured Type, Entity Type, names, DOB, gender, address, phone and related fields.

Locator priority: raw tag + DuckCreekId-as-fieldref; raw id/name when source-backed; test id; role/link/button only when DOM semantics support it; associated label; relationship; source-backed index last. Runtime discovery also promotes direct tag+fieldref first. No DuckCreekId is treated as a separate browser attribute.

Actions perform a best-effort visible readiness wait before interaction; a visibility timeout is logged and does not itself fail the step, allowing deterministic fallback/frame resolution and Playwright actionability to proceed. HtmlFrame remains a hint: probe frame, otherwise document, cache successful scope. PressSequentially APIs are available for controls requiring real key-by-key input. Existing highlighting, dropdown semantic selection, evidence finalization and NUnit attachment contracts remain enabled.

PL|DC is not force-converted because the supplied PL raw Tosca exports contain no DuckCreekId properties. EQ-only HTML remains on its own evidence. EQ/DC controls present in the supplied CL/EQ raw assets are included in the Duck Creek fieldref catalog.
