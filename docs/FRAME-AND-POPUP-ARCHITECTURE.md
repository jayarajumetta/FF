# Frame and Popup Architecture

Tosca frame ancestry is a first-class part of locator identity in v56. `HtmlFrame` ModuleAttributes are not flattened during conversion. Descendant controls carry a frame selector into primary/fallback Playwright resolution.

Recovery order is: primary frame-aware locator → previously validated app-scoped fallback → remaining raw-Tosca candidates in the same frame → optional healing → evidence-backed failure.

For Duck Creek popup frames whose Tosca id uses a wildcard suffix, v56 translates only the source-authored wildcard into a prefix CSS selector. It does not synthesize arbitrary frame indexes.

Browser-window popups remain Playwright page/popup concerns; HTML popup containers represented by Tosca as `HtmlFrame` use `FrameLocator`.
