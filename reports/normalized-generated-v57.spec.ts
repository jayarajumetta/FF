import { test, expect } from "@playwright/test";
import {
  ResilientActions,
  evaluateCondition,
  resolveRuntimeValue,
  type ConditionNode,
  type LocatorSpec,
  type RuntimeValueExpression,
} from "../src/index.js";

const cldcLogin = {
  "key": "cldcLogin",
  "app": "CLDC",
  "controlType": "Link",
  "fieldRef": "CLDC.Login.Submit",
  "id": "cl.dc.login.submit",
  "text": "Login",
  "role": {
    "role": "link",
    "name": "Login",
    "exact": true
  },
  "roleAlternates": [
    {
      "role": "button",
      "name": "Login",
      "exact": true
    }
  ]
} satisfies LocatorSpec;

const cribCircumference = {
  "key": "cribCircumference",
  "app": "PLDC",
  "controlType": "TextBox",
  "fieldRef": "PLDC.Crib.Circumference",
  "id": "txtCribCircumference",
  "occurrence": 2
} satisfies LocatorSpec;

const siteState = {
  "key": "siteState",
  "app": "PLDC",
  "controlType": "ComboBox",
  "fieldRef": "PLDC.Site.State",
  "id": "cmbState",
  "occurrence": 2,
  "role": {
    "role": "combobox",
    "name": "State",
    "exact": true
  },
  "xpath": "//site-location//mat-select[@id='cmbState']"
} satisfies LocatorSpec;

test("PLDC and CLDC hardened flow", async ({ page }) => {
  const data = new Map<string, unknown>(Object.entries({
  "LOB": "PLDC",
  "STATE": "CA",
  "CIRCUMFERENCE": "48"
}));
  const ui = new ResilientActions(page);

  // v57 source=state-empty-guid order=10 kind=select
  await ui.select(siteState, resolveRuntimeValue({
  "kind": "literal",
  "value": ""
} as RuntimeValueExpression, data));

  // v57 source=state-input-guid order=11 kind=select
  if (evaluateCondition({
  "kind": "comparison",
  "operator": "eq",
  "left": {
    "kind": "variable",
    "path": "LOB"
  },
  "right": {
    "kind": "literal",
    "value": "PLDC"
  }
} as ConditionNode, data)) {
    await ui.select(siteState, resolveRuntimeValue({
  "kind": "data",
  "key": "STATE"
} as RuntimeValueExpression, data));
  }

  // v57 source=circumference-fill order=12 kind=fill
  if (evaluateCondition({
  "kind": "comparison",
  "operator": "eq",
  "left": {
    "kind": "variable",
    "path": "LOB"
  },
  "right": {
    "kind": "literal",
    "value": "PLDC"
  }
} as ConditionNode, data)) {
    await ui.fill(cribCircumference, resolveRuntimeValue({
  "kind": "data",
  "key": "CIRCUMFERENCE"
} as RuntimeValueExpression, data));
  }

  // v57 source=cldc-login order=13 kind=click
  if (evaluateCondition({
  "kind": "comparison",
  "operator": "eq",
  "left": {
    "kind": "variable",
    "path": "LOB"
  },
  "right": {
    "kind": "literal",
    "value": "CLDC"
  }
} as ConditionNode, data)) {
    await ui.click(cldcLogin);
  }

  const __v57_deferred_MIGRATION_RESULT_4 = true
    ? { apply: true as const, value: resolveRuntimeValue({
  "kind": "literal",
  "value": "completed"
} as RuntimeValueExpression, data) }
    : { apply: false as const, value: undefined };

  // v57 data footer: safe writes only; dependency-sensitive writes stay in place.
  if (__v57_deferred_MIGRATION_RESULT_4.apply) {
    data.set("MIGRATION_RESULT", __v57_deferred_MIGRATION_RESULT_4.value);
  }
});
