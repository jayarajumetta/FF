import { buildLocatorCandidates } from '../locator/candidate-builder.js';
import { createLocator } from '../locator/create-locator.js';
import { enumerateFrames } from './frame-search.js';
import { ArrayDiagnosticSink, errorMessage, nowIso, } from './diagnostics.js';
function delay(milliseconds) {
    return milliseconds <= 0
        ? Promise.resolve()
        : new Promise((resolve) => globalThis.setTimeout(resolve, milliseconds));
}
async function visibleIndexes(locator, count) {
    if (!locator.isVisible)
        return [];
    const indexes = [];
    for (let index = 0; index < count; index += 1) {
        try {
            if (await locator.nth(index).isVisible?.({ timeout: 100 }))
                indexes.push(index);
        }
        catch {
            // Dynamic candidates can detach while visibility is checked. Treat the
            // candidate as unavailable and let the next candidate/frame retry.
        }
    }
    return indexes;
}
export async function selectStrictLocator(locator, candidate) {
    const count = await locator.count();
    if (count === 0)
        return undefined;
    if (count === 1)
        return { locator, index: 0, count };
    if (candidate.occurrence !== undefined) {
        const index = candidate.occurrence - 1;
        if (index >= 0 && index < count) {
            return { locator: locator.nth(index), index, count };
        }
        return undefined;
    }
    // Do not silently use first()/nth() for an ambiguous locator. A single
    // visible match is safe; otherwise the lower-ranked unique candidate wins.
    const visible = await visibleIndexes(locator, count);
    if (visible.length === 1 && visible[0] !== undefined) {
        return { locator: locator.nth(visible[0]), index: visible[0], count };
    }
    return undefined;
}
function emit(sink, event) {
    sink.emit({ ...event, timestamp: nowIso() });
}
/** Resolves the first strict, stable locator without performing an action. */
export async function resolveLocator(page, spec, options = {}) {
    const localSink = options.sink ?? new ArrayDiagnosticSink();
    const candidates = buildLocatorCandidates(spec, options.candidateOptions);
    const passes = Math.max(1, options.maxPasses ?? 2);
    const retryDelayMs = Math.max(0, options.retryDelayMs ?? 75);
    for (let pass = 0; pass < passes; pass += 1) {
        const frames = enumerateFrames(page, spec.frame);
        for (const frame of frames) {
            for (const candidate of candidates) {
                try {
                    const raw = createLocator(frame.frame, candidate);
                    const selected = await selectStrictLocator(raw, candidate);
                    if (!selected) {
                        let count;
                        try {
                            count = await raw.count();
                        }
                        catch {
                            count = undefined;
                        }
                        emit(localSink, {
                            phase: 'resolve',
                            locatorKey: spec.key,
                            frame: frame.label,
                            candidate,
                            ...(count === undefined ? {} : { count }),
                            status: count && count > 1 ? 'ambiguous' : 'miss',
                            ...(count && count > 1 && candidate.occurrence === undefined
                                ? { message: 'Strict locator matched multiple elements and no raw occurrence was available.' }
                                : {}),
                        });
                        continue;
                    }
                    emit(localSink, {
                        phase: 'resolve',
                        locatorKey: spec.key,
                        frame: frame.label,
                        candidate,
                        count: selected.count,
                        selectedIndex: selected.index,
                        status: 'matched',
                    });
                    return {
                        resolved: {
                            locator: selected.locator,
                            frame,
                            candidate,
                            selectedIndex: selected.index,
                            count: selected.count,
                        },
                        diagnostics: localSink instanceof ArrayDiagnosticSink ? localSink.events : [],
                    };
                }
                catch (error) {
                    emit(localSink, {
                        phase: 'resolve',
                        locatorKey: spec.key,
                        frame: frame.label,
                        candidate,
                        status: 'failed',
                        message: errorMessage(error),
                    });
                }
            }
        }
        if (pass < passes - 1)
            await delay(retryDelayMs);
    }
    return {
        diagnostics: localSink instanceof ArrayDiagnosticSink ? localSink.events : [],
    };
}
/**
 * Runs an operation against every strict candidate/frame combination until it
 * succeeds. Action failures do not pin the runtime to a bad first locator.
 */
export async function performAcrossLocatorCandidates(page, spec, operation, options = {}) {
    const localSink = options.sink ?? new ArrayDiagnosticSink();
    const candidates = buildLocatorCandidates(spec, options.candidateOptions);
    const passes = Math.max(1, options.maxPasses ?? 2);
    const retryDelayMs = Math.max(0, options.retryDelayMs ?? 75);
    for (let pass = 0; pass < passes; pass += 1) {
        for (const frame of enumerateFrames(page, spec.frame)) {
            for (const candidate of candidates) {
                let selected;
                try {
                    selected = await selectStrictLocator(createLocator(frame.frame, candidate), candidate);
                }
                catch (error) {
                    emit(localSink, {
                        phase: 'resolve',
                        locatorKey: spec.key,
                        frame: frame.label,
                        candidate,
                        status: 'failed',
                        message: errorMessage(error),
                    });
                    continue;
                }
                if (!selected)
                    continue;
                try {
                    const value = await operation({
                        frame,
                        candidate,
                        locator: selected.locator,
                        selectedIndex: selected.index,
                        count: selected.count,
                    });
                    emit(localSink, {
                        phase: 'action',
                        locatorKey: spec.key,
                        frame: frame.label,
                        candidate,
                        count: selected.count,
                        selectedIndex: selected.index,
                        status: 'succeeded',
                    });
                    return {
                        value,
                        diagnostics: localSink instanceof ArrayDiagnosticSink ? localSink.events : [],
                    };
                }
                catch (error) {
                    emit(localSink, {
                        phase: 'action',
                        locatorKey: spec.key,
                        frame: frame.label,
                        candidate,
                        count: selected.count,
                        selectedIndex: selected.index,
                        status: 'failed',
                        message: errorMessage(error),
                    });
                }
            }
        }
        if (pass < passes - 1)
            await delay(retryDelayMs);
    }
    return { diagnostics: localSink instanceof ArrayDiagnosticSink ? localSink.events : [] };
}
//# sourceMappingURL=resolver.js.map