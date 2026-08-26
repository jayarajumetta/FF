import { test, expect } from "@playwright/test";
import {
  ResilientActions,
  evaluateCondition,
  resolveRuntimeValue,
  type ConditionNode,
  type LocatorSpec,
  type RuntimeValueExpression,
} from "../src/index.js";

const cmbState = {
  "key": "cmbState",
  "app": "PLDC",
  "controlType": "ComboBox",
  "fieldRef": "PLDC.Site.State",
  "id": "cmbState",
  "xpath": "//site-location//mat-select[@id='cmbState']",
  "occurrence": 2,
  "raw": [
    {
      "sourceFile": "/mnt/data/FF-bop-complete-e2e-v57/examples/raw-tosca-excerpt.xml",
      "entityGuid": "pldc-state-guid",
      "controlName": "cmbState",
      "fieldRef": "PLDC.Site.State",
      "id": "cmbState",
      "tag": "MAT-SELECT",
      "controlType": "ComboBox",
      "occurrence": 2,
      "customXPath": "//site-location//mat-select[@id='cmbState']",
      "rawProperties": {
        "Surrogate": "pldc-state-guid",
        "Name": "cmbState",
        "ControlType": "ComboBox",
        "Id": "cmbState",
        "FieldRef": "PLDC.Site.State",
        "Tag": "MAT-SELECT",
        "Occurrence": "2",
        "CustomXPath": "//site-location//mat-select[@id='cmbState']"
      }
    }
  ]
} satisfies LocatorSpec;

test("Raw Tosca cross-check", async ({ page }) => {
  const data = new Map<string, unknown>(Object.entries({}));
  const ui = new ResilientActions(page);

  // v57 source=state-empty-guid order=10 kind=select
  await ui.select(cmbState, resolveRuntimeValue({
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
    await ui.select(cmbState, resolveRuntimeValue({
  "kind": "data",
  "key": "STATE"
} as RuntimeValueExpression, data));
  }

});
