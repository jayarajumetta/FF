declare class Buffer extends Uint8Array {
  static from(input: string | ArrayBuffer | ArrayBufferView, encoding?: string): Buffer;
  static isBuffer(input: unknown): input is Buffer;
  static concat(list: readonly Uint8Array[]): Buffer;
  toString(encoding?: string): string;
  readonly length: number;
}

declare module 'node:fs' {
  export function readFileSync(path: string | URL): Buffer;
  export function writeFileSync(path: string | URL, data: string | Uint8Array, encoding?: string): void;
  export function existsSync(path: string | URL): boolean;
  export function mkdirSync(path: string | URL, options?: { recursive?: boolean }): string | undefined;
  export function cpSync(source: string | URL, destination: string | URL, options?: { recursive?: boolean; force?: boolean }): void;
  export function rmSync(path: string | URL, options?: { recursive?: boolean; force?: boolean }): void;
}

declare module 'node:zlib' {
  export function gunzipSync(buffer: Uint8Array): Buffer;
}

declare module 'node:crypto' {
  export function createHash(algorithm: string): {
    update(data: string | Uint8Array): unknown;
    digest(encoding: 'hex'): string;
  };
}

declare module 'node:path' {
  export function resolve(...segments: string[]): string;
  export function join(...segments: string[]): string;
  export function dirname(path: string): string;
  export function basename(path: string): string;
  export function relative(from: string, to: string): string;
}
