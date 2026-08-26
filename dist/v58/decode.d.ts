import { DecodedDocument } from './model';
interface XmlNode {
    tag: string;
    attributes: Record<string, string>;
    children: XmlNode[];
    text: string;
}
export interface WorkspaceLoad {
    sourcePath: string;
    sourceSha256: string;
    documents: DecodedDocument[];
    warnings: string[];
}
export declare function parseXml(text: string): XmlNode;
export declare function loadWorkspace(sourcePath: string, maxDepth?: number): WorkspaceLoad;
export {};
