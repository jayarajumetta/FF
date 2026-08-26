import { MappingResult } from './model';
export interface GenerationSummary {
    outputDirectory: string;
    featureFiles: number;
    planFiles: number;
    testDataFiles: number;
    locatorModules: number;
    pageModules: number;
    mappingEntries: number;
}
export declare function generateProject(mapping: MappingResult, outputDirectory: string): GenerationSummary;
