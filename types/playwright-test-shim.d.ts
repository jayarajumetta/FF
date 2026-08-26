declare module '@playwright/test' {
  export interface Page {
    [key: string]: unknown;
  }

  export const test: {
    (name: string, body: (fixtures: { page: Page }) => Promise<void>): void;
    describe(name: string, body: () => void): void;
  };

  export function expect(actual: unknown): {
    toBeVisible(options?: unknown): Promise<void>;
    toHaveText(expected: unknown, options?: unknown): Promise<void>;
    toHaveValue(expected: unknown, options?: unknown): Promise<void>;
  };
}
