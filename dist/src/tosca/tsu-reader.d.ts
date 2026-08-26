import { type RawToscaEvidence } from './raw-evidence.js';
export interface EmbeddedToscaDocument {
    path: string;
    format: 'json' | 'xml' | 'text';
    value: unknown;
}
export interface TsuReadResult {
    sourceFile?: string;
    root: unknown;
    entitiesByGuid: ReadonlyMap<string, unknown>;
    embedded: readonly EmbeddedToscaDocument[];
    evidence: RawToscaEvidence;
    warnings: readonly string[];
}
export interface TsuReaderOptions {
    maxEmbeddedDepth?: number;
    maxEmbeddedBytes?: number;
}
export declare function readTsuBuffer(input: Uint8Array, sourceFile?: string, options?: TsuReaderOptions): TsuReadResult;
export declare function readTsuFile(path: string, options?: TsuReaderOptions): TsuReadResult;
//# sourceMappingURL=tsu-reader.d.ts.map