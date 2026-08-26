"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.mapWorkspace = mapWorkspace;
const model_1 = require("./model");
const locators_1 = require("./locators");
const optimizer_1 = require("./optimizer");
function props(entity) { return (entity.mergedProperties ?? entity.properties); }
function typeKey(entity) { return (0, model_1.normalizeKey)(entity.type); }
function nameKey(entity) { return (0, model_1.normalizeKey)(entity.name); }
function numericProperty(entity, ...names) {
    const value = (0, locators_1.propertyValue)(props(entity), ...names);
    if (!value)
        return undefined;
    const number = Number(value);
    return Number.isFinite(number) ? number : undefined;
}
function entityOrder(entity) {
    return numericProperty(entity, 'Position', 'Order', 'Sequence', 'ExecutionOrder', 'Index', 'SortOrder') ?? entity.source.ordinal;
}
function isModule(entity) {
    const type = typeKey(entity);
    return type.includes('module') && !/(attribute|control|parameter|folder)/.test(type);
}
function isControl(entity) {
    const type = typeKey(entity);
    const name = nameKey(entity);
    return /(moduleattribute|modulecontrol|control|htmlcontrol|guicontrol|steeringparameter)/.test(type)
        || Boolean((0, locators_1.propertyValue)(props(entity), 'FieldRef', 'ControlType', 'XPath', 'CssSelector', 'TechnicalId'))
            && !/(teststepvalue|testcase|execution)/.test(type + name);
}
function isTestCase(entity) {
    const type = typeKey(entity);
    return type.includes('testcase') && !/(folder|design|instance|template|execution|parameter|value)/.test(type);
}
function isExecutableEntity(entity) {
    const type = typeKey(entity);
    const name = nameKey(entity);
    const properties = props(entity);
    return /(teststep|teststepvalue|reusableblock|condition|ifstatement|else|endcondition|tbox)/.test(type)
        || Boolean((0, locators_1.propertyValue)(properties, 'ActionMode', 'Action', 'Input', 'TestStepValue', 'Expression', 'Condition'))
        || /(tboxif|tboxsetbuffer|setbuffer|openurl|click|select|dropdown)/.test(name);
}
function ancestor(graph, entity, predicate) {
    const visited = new Set();
    let current = entity;
    while (current?.parentId && !visited.has(current.parentId)) {
        visited.add(current.parentId);
        current = graph.byId.get(current.parentId);
        if (current && predicate(current))
            return current;
    }
    return undefined;
}
function referenceIds(entity) {
    const result = new Set();
    if (entity.derivedFrom)
        result.add(entity.derivedFrom);
    for (const ids of Object.values(entity.references))
        for (const id of ids)
            result.add(id);
    return [...result];
}
function findControl(graph, entity, controls) {
    const visited = new Set();
    const queue = [entity.id, ...referenceIds(entity)];
    const names = new Set([
        entity.name,
        (0, locators_1.propertyValue)(props(entity), 'ControlName', 'ModuleAttributeName', 'AttributeName', 'TechnicalName', 'TargetName'),
    ].filter((value) => Boolean(value)).map(model_1.normalizeKey));
    let current = entity;
    while (current?.parentId) {
        queue.push(current.parentId);
        if (current.name)
            names.add((0, model_1.normalizeKey)(current.name));
        current = graph.byId.get(current.parentId);
    }
    while (queue.length) {
        const id = queue.shift();
        if (visited.has(id))
            continue;
        visited.add(id);
        const direct = controls.get(id);
        if (direct)
            return direct;
        const candidate = graph.byId.get(id);
        if (!candidate)
            continue;
        if (isModule(candidate)) {
            const moduleControls = [...controls.values()].filter((control) => ancestor(graph, control, isModule)?.id === candidate.id);
            const exact = moduleControls.filter((control) => names.has((0, model_1.normalizeKey)(control.name))
                || names.has((0, model_1.normalizeKey)((0, locators_1.propertyValue)(props(control), 'Name', 'ControlName', 'TechnicalName', 'FieldRef') ?? '')));
            if (exact.length === 1)
                return exact[0];
        }
        if (candidate.derivedFrom)
            queue.push(candidate.derivedFrom);
        for (const ids of Object.values(candidate.references))
            queue.push(...ids);
    }
    return undefined;
}
function stringAttributes(properties) {
    const result = {};
    for (const [key, value] of Object.entries(properties)) {
        const selected = Array.isArray(value) ? value[0] : value;
        if (selected !== undefined && selected !== null)
            result[key] = String(selected);
    }
    return result;
}
function controlEvidence(graph, control, sourceName) {
    const properties = props(control);
    const module = ancestor(graph, control, isModule);
    const lob = (0, locators_1.inferLob)(sourceName, module?.name, control.name, (0, locators_1.propertyValue)(properties, 'LOB', 'LineOfBusiness'));
    const frameHints = [
        (0, locators_1.propertyValue)(properties, 'Frame', 'FrameName', 'IFrame', 'IFrameName', 'WindowName', 'Context'),
        module ? (0, locators_1.propertyValue)(props(module), 'Frame', 'FrameName', 'IFrame', 'IFrameName') : undefined,
    ].filter((value) => Boolean(value));
    const occurrence = numericProperty(control, 'Occurrence', 'Index', 'ControlOccurrence');
    return {
        controlId: control.id, moduleId: module?.id, lob, name: control.name,
        fieldRef: (0, locators_1.propertyValue)(properties, 'FieldRef', 'FieldReference', 'DCFieldRef', 'data-field-ref', 'data-fieldref'),
        id: (0, locators_1.propertyValue)(properties, 'Id', 'HtmlId', 'ControlId', 'AutomationId', 'TechnicalId'),
        testId: (0, locators_1.propertyValue)(properties, 'TestId', 'data-testid', 'AutomationTestId'),
        label: (0, locators_1.propertyValue)(properties, 'Label', 'Caption', 'DisplayName', 'AssociatedLabel'),
        accessibleName: (0, locators_1.propertyValue)(properties, 'AccessibleName', 'AriaLabel', 'aria-label', 'Text', 'Title') ?? control.name,
        role: (0, locators_1.propertyValue)(properties, 'Role', 'AriaRole', 'ControlRole'),
        tag: (0, locators_1.propertyValue)(properties, 'Tag', 'TagName', 'HtmlTag', 'NodeName'),
        controlName: (0, locators_1.propertyValue)(properties, 'Name', 'HtmlName', 'ControlName'),
        css: (0, locators_1.propertyValue)(properties, 'Css', 'CssSelector', 'Selector'),
        xpath: (0, locators_1.propertyValue)(properties, 'XPath', 'Path', 'RelativeXPath'),
        occurrence: occurrence && occurrence > 0 ? occurrence : undefined,
        frameHints, source: control.source, inheritedFrom: control.inheritanceChain ?? [], attributes: stringAttributes(control.mergedProperties ?? control.properties),
    };
}
function controlKind(control) {
    if (!control)
        return '';
    return [control.type, control.name, ...Object.values(stringAttributes(control.mergedProperties ?? control.properties))].join(' ').toLowerCase();
}
function deriveActionKind(entity, control) {
    const properties = props(entity);
    const mode = ((0, locators_1.propertyValue)(properties, 'ActionMode', 'Mode', 'Action', 'Operation') ?? '').toLowerCase();
    const value = ((0, locators_1.propertyValue)(properties, 'Value', 'Input', 'TestStepValue', 'Data', 'Text') ?? '').trim();
    const combined = `${entity.type} ${entity.name} ${mode} ${value}`.toLowerCase();
    const ckind = controlKind(control);
    if (/\belse\b/.test(combined) && !/if/.test(combined))
        return 'else';
    if (/(endif|end if|endcondition|end condition)/.test(combined))
        return 'ifEnd';
    if (/(tbox if|ifstatement|^if\b|\bcondition\b)/.test(combined) && !/(verify|constraintvalue)/.test(mode))
        return 'ifStart';
    if (/(set buffer|setbuffer|data\.set|tbox set buffer)/.test(combined) || mode === 'buffer')
        return 'setData';
    if (/(openurl|navigate|goto|start browser)/.test(combined) || /^https?:\/\//i.test(value))
        return 'navigate';
    if (/\{\s*click\s*\}|\bclick\b/.test(combined) || mode === 'select' && !/(select|combo|dropdown|listbox)/.test(ckind))
        return 'click';
    if (/\{\s*tab\s*\}/i.test(value))
        return 'press';
    if (/\{\s*enter\s*\}/i.test(value))
        return 'press';
    if (/(uncheck|clear check)/.test(combined))
        return 'uncheck';
    if (/(check box|checkbox)/.test(ckind) && /^(true|x|1|yes|checked)$/i.test(value))
        return 'check';
    if (/(dropdown|combobox|combo box|select|listbox|mat-select)/.test(ckind) || /(selectoption|select option|dropdown)/.test(combined))
        return 'select';
    if (mode === 'verify' || /\bverify\b|assert|check value/.test(combined))
        return 'verify';
    if (/hover|mouseover/.test(combined))
        return 'hover';
    if (/press|keystroke|sendkey/.test(combined))
        return 'press';
    if (mode === 'input' || /input|enter value|set value|fill/.test(combined))
        return 'fill';
    if (mode === 'constraint')
        return 'ifStart';
    return 'noop';
}
function actionValue(entity, kind) {
    const properties = props(entity);
    let value = (0, locators_1.propertyValue)(properties, 'Value', 'Input', 'TestStepValue', 'Data', 'Text', 'Expression', 'Condition', 'ExpectedValue');
    if (!value)
        return undefined;
    if (kind === 'press') {
        const key = value.match(/\{\s*(TAB|ENTER|ESC|ESCAPE|SPACE|ARROWDOWN|ARROWUP)\s*\}/i)?.[1];
        if (key)
            return key.toLowerCase() === 'tab' ? 'Tab' : key.toLowerCase() === 'enter' ? 'Enter' : key;
    }
    if (kind === 'click' && /^\{\s*click\s*\}$/i.test(value))
        return undefined;
    return value;
}
function dataKey(entity) {
    return (0, locators_1.propertyValue)(props(entity), 'BufferName', 'Key', 'Name', 'Variable', 'DataKey', 'Target')
        ?? entity.name.match(/(?:set\s+buffer|data\.set)\s*[:=-]?\s*(.+)$/i)?.[1]?.trim();
}
function conditionExpression(entity) {
    return (0, locators_1.propertyValue)(props(entity), 'Condition', 'Expression', 'Value', 'Input', 'TestStepValue', 'Constraint');
}
function descendantSequence(graph, root) {
    const result = [];
    const visited = new Set();
    const visit = (entity) => {
        if (visited.has(entity.id))
            return;
        visited.add(entity.id);
        const children = [...(graph.childrenByParent.get(entity.id) ?? [])].sort((a, b) => entityOrder(a) - entityOrder(b) || a.source.ordinal - b.source.ordinal);
        for (const child of children) {
            result.push(child);
            visit(child);
        }
        // Expand referenced reusable blocks only when the relation is explicit and the block is outside this subtree.
        for (const [key, ids] of Object.entries(entity.references)) {
            if (!/(reusable|block|teststep|template)/i.test(key))
                continue;
            for (const id of ids) {
                const referenced = graph.byId.get(id);
                if (!referenced || visited.has(id))
                    continue;
                result.push(referenced);
                visit(referenced);
            }
        }
    };
    visit(root);
    return result;
}
function examplesFor(graph, testCase) {
    const candidates = descendantSequence(graph, testCase).filter((entity) => /(instance|example|testdata|dataset|testsheet)/.test(typeKey(entity)));
    return candidates.map((entity) => {
        const values = {};
        for (const [key, value] of Object.entries(entity.mergedProperties ?? entity.properties)) {
            if (/^(id|guid|name|type|position|order|parent|derived)/i.test(key))
                continue;
            const selected = Array.isArray(value) ? value[0] : value;
            if (selected !== undefined && selected !== null && typeof selected !== 'object')
                values[key] = String(selected);
        }
        return { name: entity.name, values, source: entity.source };
    }).filter((example) => Object.keys(example.values).length > 0);
}
function mapWorkspace(graph, sourceName) {
    const controls = new Map(graph.entities.filter(isControl).map((entity) => [entity.id, entity]));
    const locatorRegistry = new locators_1.LocatorRegistry();
    const descriptorByControl = new Map();
    for (const control of controls.values()) {
        const evidence = controlEvidence(graph, control, sourceName);
        if (![evidence.fieldRef, evidence.id, evidence.testId, evidence.label, evidence.accessibleName, evidence.css, evidence.xpath].some(Boolean))
            continue;
        descriptorByControl.set(control.id, locatorRegistry.register(evidence));
    }
    const plans = [];
    const warnings = [...graph.warnings];
    for (const testCase of graph.entities.filter(isTestCase)) {
        const conditionStack = [];
        const rawActions = [];
        for (const entity of descendantSequence(graph, testCase)) {
            if (!isExecutableEntity(entity))
                continue;
            const control = findControl(graph, entity, controls);
            const descriptor = control ? descriptorByControl.get(control.id) ?? locatorRegistry.register(controlEvidence(graph, control, sourceName)) : undefined;
            let kind = deriveActionKind(entity, control);
            const unresolvedElement = !control && ['click', 'fill', 'select', 'check', 'uncheck', 'hover'].includes(kind);
            if (unresolvedElement && /(tbox|buffer|expression|evaluation|file|folder|wait|process|program|database|xml|json|api)/i.test(`${entity.type} ${entity.name}`))
                kind = 'noop';
            if (!control && kind === 'verify' && /(tbox|buffer|expression|evaluation|constraint|data)/i.test(`${entity.type} ${entity.name}`))
                kind = 'comment';
            const expression = conditionExpression(entity);
            const id = `act-${(0, model_1.fnv1a)(`${testCase.id}:${entity.id}:${entity.source.ordinal}:${kind}`)}`;
            const action = {
                id, kind, name: entity.name || control?.name || kind, value: actionValue(entity, kind),
                key: kind === 'setData' ? dataKey(entity) : undefined,
                condition: !['ifStart', 'ifEnd', 'else'].includes(kind) ? (0, locators_1.propertyValue)(props(entity), 'Condition', 'Constraint') : expression,
                conditionPath: [...conditionStack], locatorId: descriptor?.id, locator: descriptor,
                source: entity.source, rawActionMode: (0, locators_1.propertyValue)(props(entity), 'ActionMode', 'Mode', 'Action'), generated: false,
                navigationExpected: Boolean((0, locators_1.propertyValue)(props(entity), 'Navigation', 'NavigationExpected', 'PageTransition')) || /next|continue|submit|login|save|finish/i.test(entity.name),
                explicitOccurrence: Boolean(descriptor?.occurrence), metadata: { entityId: entity.id, entityType: entity.type, controlId: control?.id, moduleId: descriptor?.moduleId, globalKeyboard: kind === 'press' && !descriptor, unresolvedElement: unresolvedElement && kind === 'noop' },
            };
            rawActions.push(action);
            if (kind === 'ifStart')
                conditionStack.push(expression ?? entity.name);
            else if (kind === 'else' && conditionStack.length)
                conditionStack[conditionStack.length - 1] = `ELSE(${conditionStack[conditionStack.length - 1]})`;
            else if (kind === 'ifEnd' && conditionStack.length)
                conditionStack.pop();
        }
        const lob = (0, locators_1.inferLob)(sourceName, testCase.name, (0, locators_1.propertyValue)(props(testCase), 'LOB', 'LineOfBusiness'));
        const rawPlan = { id: testCase.id, name: testCase.name, lob, source: testCase.source, actions: rawActions, examples: examplesFor(graph, testCase), tags: [lob.toLowerCase(), 'tosca-v58'], warnings: [] };
        const optimized = (0, optimizer_1.optimizePlan)(rawPlan);
        (0, optimizer_1.assertSourceOrder)(rawPlan, optimized.plan);
        plans.push(optimized.plan);
    }
    const locators = locatorRegistry.values();
    const metrics = {
        documents: graph.documents.length, entities: graph.entities.length, modules: graph.entities.filter(isModule).length,
        controls: controls.size, locators: locators.length, locatorAliases: Object.keys(locatorRegistry.aliases()).length,
        testCases: plans.length, actions: plans.reduce((sum, plan) => sum + plan.actions.length, 0),
        fieldRefLocators: locators.filter((locator) => Boolean(locator.evidence.fieldRef)).length,
        inheritedLocators: locators.filter((locator) => locator.evidence.inheritedFrom.length > 0).length,
        dataSets: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'setData').length, 0),
        conditions: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'ifStart').length, 0),
        explicitTabs: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'press' && action.value === 'Tab' && !action.generated).length, 0),
        dropdownActions: plans.reduce((sum, plan) => sum + plan.actions.filter((action) => action.kind === 'select').length, 0),
    };
    if (!plans.length)
        warnings.push(`No native TestCase entities were reconstructed from ${sourceName}`);
    return { graph, plans: plans.sort((a, b) => a.source.ordinal - b.source.ordinal), locators, locatorAliases: locatorRegistry.aliases(), warnings, metrics };
}
//# sourceMappingURL=mapper.js.map