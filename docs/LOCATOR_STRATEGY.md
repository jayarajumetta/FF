# Locator strategy

Source `XModuleAttribute` properties are ranked in this order:

1. `data-testid`
2. exact HTML ID / `attributes_id`
3. Duck Creek ID and `data-fieldref`
4. Automation ID
5. ARIA label / associated label
6. HTML name
7. role plus accessible name
8. exact visible text
9. XPath or CSS fallback

The runtime requires a unique match by default. Ambiguity can be relaxed only through `STRICT_LOCATOR_AMBIGUITY=false`. TBox/system modules are excluded from page locator repositories.
