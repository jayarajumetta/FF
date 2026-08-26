# Locator decision tree

1. **Is the application PLDC or CLDC and is FieldRef present?**
   - Try exact configured FieldRef attributes.
2. **Is a stable test ID present?**
   - Try it as an explicit contract.
3. **Is an exact HTML ID present?**
   - Use `[id="value"]`; never assume the ID is a valid CSS identifier.
4. **Is an accessible role/name present?**
   - Use role/name. For Tosca Link/Button controls, try both roles.
5. **Is a label or `aria-label` present?**
   - Use label-based location.
6. **Are stable native/framework attributes present?**
   - placeholder, `name`, `formcontrolname`, title.
7. **Is a stable scoped CSS selector present?**
   - use within the preserved scope.
8. **Is exact text or a known alias present?**
   - use as a lower-confidence fallback.
9. **Is a custom/raw XPath present?**
   - retain it last, with scope where available.
10. **Does a candidate match more than once?**
    - use raw occurrence if valid; otherwise require one visible match or reject it.
11. **Did the action fail after resolution?**
    - continue to the next locator/frame.
12. **Did all Playwright attempts fail?**
    - evaluate the same evidence inside each frame and perform a final DOM action, recording the fallback in diagnostics.
