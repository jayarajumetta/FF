/**
 * Structural Playwright contracts.
 *
 * v57 intentionally does not import @playwright/test in the runtime. Real
 * Playwright Page/Frame/Locator objects satisfy these contracts, while the
 * converter can be compiled and unit-tested without downloading browsers.
 */
export interface LocatorLike {
    count(): Promise<number>;
    nth(index: number): LocatorLike;
    first(): LocatorLike;
    locator?(selector: string): LocatorLike;
    getByRole?(role: any, options?: any): LocatorLike;
    getByLabel?(text: string | RegExp, options?: any): LocatorLike;
    getByText?(text: string | RegExp, options?: any): LocatorLike;
    getByPlaceholder?(text: string | RegExp, options?: any): LocatorLike;
    getByTestId?(testId: string | RegExp): LocatorLike;
    filter?(options: any): LocatorLike;
    isVisible?(options?: {
        timeout?: number;
    }): Promise<boolean>;
    click?(options?: any): Promise<void>;
    fill?(value: string, options?: any): Promise<void>;
    press?(key: string, options?: any): Promise<void>;
    pressSequentially?(text: string, options?: any): Promise<void>;
    selectOption?(values: any, options?: any): Promise<string[]>;
    check?(options?: any): Promise<void>;
    uncheck?(options?: any): Promise<void>;
    focus?(options?: any): Promise<void>;
    blur?(options?: any): Promise<void>;
    waitFor?(options?: any): Promise<void>;
    getAttribute?(name: string, options?: any): Promise<string | null>;
    inputValue?(options?: any): Promise<string>;
    textContent?(options?: any): Promise<string | null>;
    evaluate?<R, A = void>(pageFunction: (element: Element, arg: A) => R | Promise<R>, arg?: A): Promise<R>;
}
export interface FrameLike {
    locator(selector: string): LocatorLike;
    getByRole?(role: any, options?: any): LocatorLike;
    getByLabel?(text: string | RegExp, options?: any): LocatorLike;
    getByText?(text: string | RegExp, options?: any): LocatorLike;
    getByPlaceholder?(text: string | RegExp, options?: any): LocatorLike;
    getByTestId?(testId: string | RegExp): LocatorLike;
    childFrames?(): FrameLike[];
    parentFrame?(): FrameLike | null;
    name?(): string;
    url?(): string;
    isDetached?(): boolean;
    evaluate?<R, A = void>(pageFunction: (arg: A) => R | Promise<R>, arg?: A): Promise<R>;
}
export interface KeyboardLike {
    press(key: string, options?: any): Promise<void>;
    type?(text: string, options?: any): Promise<void>;
}
export interface PageLike extends FrameLike {
    mainFrame(): FrameLike;
    frames(): FrameLike[];
    keyboard?: KeyboardLike;
}
export type LocatorContainer = FrameLike | LocatorLike;
export declare function isFrameLike(value: unknown): value is FrameLike;
//# sourceMappingURL=playwright.d.ts.map