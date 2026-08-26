function safeFrameName(frame) {
    try {
        return frame.name?.() ?? '';
    }
    catch {
        return '';
    }
}
function safeFrameUrl(frame) {
    try {
        return frame.url?.() ?? '';
    }
    catch {
        return '';
    }
}
function isDetached(frame) {
    try {
        return frame.isDetached?.() ?? false;
    }
    catch {
        return true;
    }
}
function samePath(left, right) {
    return left.length === right.length && left.every((value, index) => value === right[index]);
}
function matchesHint(frame, path, hint) {
    if (!hint)
        return false;
    if (hint.path && samePath(path, hint.path))
        return true;
    const name = safeFrameName(frame);
    const url = safeFrameUrl(frame);
    if (hint.name && (name === hint.name || name.includes(hint.name)))
        return true;
    if (hint.url) {
        try {
            if (new RegExp(hint.url).test(url))
                return true;
        }
        catch {
            if (url.includes(hint.url))
                return true;
        }
    }
    return false;
}
function frameLabel(path, frame) {
    const name = safeFrameName(frame) || '<unnamed>';
    const url = safeFrameUrl(frame) || '<no-url>';
    return `${path.length === 0 ? 'main' : `frame[${path.join('.')}]`} name=${name} url=${url}`;
}
/**
 * Deterministically enumerates the main frame and every nested frame.
 * Playwright Frame objects are used directly, so cross-origin frames remain
 * accessible through their own execution context.
 */
export function enumerateFrames(page, hint) {
    const main = page.mainFrame();
    const records = [];
    const seen = new Set();
    const visit = (frame, path) => {
        if (seen.has(frame) || isDetached(frame))
            return;
        seen.add(frame);
        records.push({
            frame,
            path,
            name: safeFrameName(frame),
            url: safeFrameUrl(frame),
            label: frameLabel(path, frame),
            hinted: matchesHint(frame, path, hint),
        });
        let children = [];
        try {
            children = frame.childFrames?.() ?? [];
        }
        catch {
            children = [];
        }
        children.forEach((child, index) => visit(child, [...path, index]));
    };
    visit(main, []);
    // Some fakes/adapters do not expose childFrames(). page.frames() is the
    // authoritative fallback and also captures frames attached during startup.
    for (const frame of page.frames()) {
        if (seen.has(frame) || isDetached(frame))
            continue;
        const syntheticPath = [records.length];
        seen.add(frame);
        records.push({
            frame,
            path: syntheticPath,
            name: safeFrameName(frame),
            url: safeFrameUrl(frame),
            label: frameLabel(syntheticPath, frame),
            hinted: matchesHint(frame, syntheticPath, hint),
        });
    }
    if (!hint)
        return records;
    return records
        .map((record, index) => ({ record, index }))
        .sort((left, right) => {
        if (left.record.hinted !== right.record.hinted)
            return left.record.hinted ? -1 : 1;
        if (left.record.path.length !== right.record.path.length) {
            return left.record.path.length - right.record.path.length;
        }
        return left.index - right.index;
    })
        .map(({ record }) => record);
}
//# sourceMappingURL=frame-search.js.map