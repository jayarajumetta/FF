export class ArrayDiagnosticSink {
    events = [];
    emit(event) {
        this.events.push(event);
    }
}
export function nowIso() {
    return new Date().toISOString();
}
export function errorMessage(error) {
    if (error instanceof Error)
        return `${error.name}: ${error.message}`;
    return String(error);
}
export class ResilientActionError extends Error {
    locator;
    action;
    diagnostics;
    constructor(action, locator, diagnostics) {
        const compact = diagnostics
            .slice(-8)
            .map((entry) => `${entry.frame}/${entry.candidate?.kind ?? 'n/a'}:${entry.status}${entry.message ? `(${entry.message})` : ''}`)
            .join(' | ');
        super(`v57 could not ${action} locator "${locator.key}" after Playwright and in-frame DOM fallbacks.${compact ? ` Attempts: ${compact}` : ''}`);
        this.name = 'ResilientActionError';
        this.action = action;
        this.locator = locator;
        this.diagnostics = diagnostics;
    }
}
//# sourceMappingURL=diagnostics.js.map