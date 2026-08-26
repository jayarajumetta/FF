import { InteractionTrace, PlanAction, RuntimeOptions } from './model';
import { FrameRuntime } from './frame-runtime';
export declare class ResilientInteractionEngine {
    readonly page: any;
    readonly frames: FrameRuntime;
    readonly traces: InteractionTrace[];
    constructor(page: any, options?: RuntimeOptions);
    private trace;
    private click;
    private fill;
    private press;
    private check;
    private optionInFrame;
    private select;
    private performOnTarget;
    perform(action: PlanAction): Promise<void>;
}
