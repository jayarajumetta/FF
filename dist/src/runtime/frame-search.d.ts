import type { FrameLike, PageLike } from '../contracts/playwright.js';
import type { FrameHint } from '../locator/model.js';
export interface FrameRecord {
    frame: FrameLike;
    path: readonly number[];
    name: string;
    url: string;
    label: string;
    hinted: boolean;
}
/**
 * Deterministically enumerates the main frame and every nested frame.
 * Playwright Frame objects are used directly, so cross-origin frames remain
 * accessible through their own execution context.
 */
export declare function enumerateFrames(page: PageLike, hint?: FrameHint): FrameRecord[];
//# sourceMappingURL=frame-search.d.ts.map