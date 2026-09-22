namespace PnCTestAutomation.Reporting;

internal static class SgsReportAssets
{
    // SGS tools/generate_consolidated_report.py; d1fa940 keeps the ecd9019 inline presentation.
    internal const string SourceCommit = "d1fa9404f1a245722879e523626beb72e68d033b";
    internal const string Css = """
        :root {
          --ok: #238636; --ok-soft: #eaf7ec; --fail: #c62828; --fail-soft: #fff0f0;
          --skip: #9a6700; --skip-soft: #fff8d8; --unknown: #59636e; --ink: #17191c;
          --muted: #5f6b76; --line: #c9ced4; --line-dark: #9aa1a9; --panel: #ffffff;
          --canvas: #f5f6f7; --robot-green: #98ee98; --robot-red: #ffb1ae;
          --black: #050505; --link: #0066cc; --shadow: 0 8px 26px rgba(31,35,40,.09);
        }
        * { box-sizing: border-box; }
        html { scroll-behavior: smooth; }
        body { margin: 0; color: var(--ink); background: var(--canvas); font-family: Arial, Helvetica, sans-serif; font-size: 13px; }
        a { color: var(--link); text-decoration: none; }
        a:hover { text-decoration: underline; }
        button, input, select { font: inherit; }
        button { cursor: pointer; }
        .report-shell { min-height: 100vh; }
        .robot-banner { position: relative; padding: 22px 24px 18px; border-bottom: 1px solid #7f8a94; background: var(--robot-green); }
        .robot-banner.FAIL { background: var(--robot-red); }
        .robot-banner.SKIP, .robot-banner.UNKNOWN { background: var(--skip-soft); }
        .robot-banner h1 { margin: 0 0 10px; font-size: 27px; line-height: 1.1; }
        .robot-banner .generated { position: absolute; right: 330px; top: 18px; text-align: right; line-height: 1.35; }
        .robot-tabs { position: absolute; top: 0; right: 0; display: flex; }
        .robot-tabs button { min-width: 152px; padding: 8px 18px; border: 0; border-left: 1px solid #333; color: #fff; background: var(--black); font-weight: 800; letter-spacing: 1px; }
        .robot-tabs button.active { background: #252525; box-shadow: inset 0 -4px 0 #fff; }
        .banner-summary { max-width: 980px; display: grid; grid-template-columns: 145px 1fr; gap: 5px 10px; }
        .banner-summary dt { font-weight: 700; }
        .banner-summary dd { margin: 0; min-width: 0; word-break: break-word; }
        .main-content { padding: 20px 24px 42px; }
        .view { display: none; }
        .view.active { display: block; }
        .section-heading { display: flex; align-items: end; justify-content: space-between; gap: 12px; margin: 0 0 10px; }
        h2 { margin: 20px 0 10px; font-size: 21px; }
        h3 { margin: 0 0 8px; font-size: 16px; }
        h4 { margin: 0; font-size: 15px; }
        .cards { display: grid; grid-template-columns: repeat(6, minmax(125px, 1fr)); gap: 10px; margin: 12px 0 18px; }
        .card { border: 1px solid var(--line); background: var(--panel); padding: 12px 14px; box-shadow: 0 1px 2px rgba(31,35,40,.04); }
        .card span { display: block; color: var(--muted); font-size: 11px; text-transform: uppercase; letter-spacing: .05em; }
        .card strong { display: block; margin-top: 4px; font-size: 24px; line-height: 1; }
        .ok-text { color: var(--ok); font-weight: 700; }
        .fail-text { color: var(--fail); font-weight: 700; }
        .skip-text { color: var(--skip); font-weight: 700; }
        .overall-bar { height: 18px; display: flex; overflow: hidden; border: 1px solid var(--line-dark); background: #fff; }
        .overall-bar span { display: block; min-width: 0; }
        .overall-bar .ok { background: var(--ok); }
        .overall-bar .fail { background: var(--fail); }
        .overall-bar .skip { background: var(--skip); }
        .overall-bar-legend { display: flex; gap: 16px; margin: 5px 0 18px; color: var(--muted); }
        .statistics-grid { display: grid; grid-template-columns: repeat(2, minmax(0, 1fr)); gap: 14px; align-items: start; }
        .statistics-panel { min-width: 0; border: 1px solid var(--line); background: var(--panel); padding: 10px; }
        .table-scroll { overflow-x: auto; }
        table { width: 100%; border-collapse: collapse; }
        th, td { padding: 6px 8px; border: 1px solid var(--line); text-align: left; vertical-align: top; }
        thead th { position: sticky; top: 0; z-index: 1; background: #e6e8ea; color: #111; font-weight: 700; }
        .statistics-table td:not(:first-child), .statistics-table th:not(:first-child) { text-align: center; white-space: nowrap; }
        .statistics-table tr:hover { background: #f0f6ff; }
        .statistics-table .click-filter { cursor: pointer; }
        .mini-bar { display: inline-block; width: 110px; height: 11px; margin-right: 6px; vertical-align: middle; border: 1px solid #b5bac1; background: #fff; }
        .mini-bar .ok-segment { display: block; height: 100%; background: #8bc34a; }
        .toolbar { position: sticky; top: 0; z-index: 20; display: flex; flex-wrap: wrap; gap: 8px; align-items: center; padding: 10px; margin: 14px 0 10px; border: 1px solid var(--line-dark); background: rgba(255,255,255,.97); box-shadow: var(--shadow); }
        .toolbar input, .toolbar select { padding: 7px 8px; border: 1px solid var(--line-dark); background: #fff; }
        .toolbar input { flex: 2 1 280px; min-width: 220px; }
        .toolbar select { flex: 1 1 118px; min-width: 105px; }
        .toolbar button { flex: 0 0 auto; padding: 7px 10px; border: 1px solid var(--line-dark); background: #f0f1f2; white-space: nowrap; }
        .toolbar button:hover { background: #e4e6e8; }
        .visible-count { color: var(--muted); white-space: nowrap; text-align: right; }
        .feature-group { margin: 12px 0 18px; }
        .feature-group > details { border: 1px solid var(--line-dark); background: #fff; }
        .feature-group > details > summary { display: flex; align-items: center; gap: 8px; padding: 8px 10px; background: #dfe2e5; font-weight: 800; cursor: pointer; }
        .feature-group .feature-counts { margin-left: auto; color: var(--muted); font-weight: 400; }
        .scenario-list { padding: 8px; }
        .scenario-card { margin: 7px 0; border: 1px solid var(--line); background: #fff; }
        .scenario-card.hidden, .feature-group.hidden, .log-suite.hidden { display: none; }
        .scenario-details > summary { display: grid; grid-template-columns: 42px 52px minmax(260px,1fr) minmax(150px,auto) 95px 64px; align-items: center; gap: 8px; padding: 8px 10px; cursor: pointer; background: #f7f7f7; border-left: 7px solid var(--unknown); }
        .scenario-card.PASS .scenario-details > summary { border-left-color: var(--ok); }
        .scenario-card.FAIL .scenario-details > summary { border-left-color: var(--fail); background: var(--fail-soft); }
        .scenario-card.SKIP .scenario-details > summary { border-left-color: var(--skip); background: var(--skip-soft); }
        .scenario-index { color: var(--muted); font-family: Consolas, monospace; }
        .test-label, .step-kind { display: inline-block; padding: 2px 5px; color: #fff; background: #d13f0b; font-size: 10px; font-weight: 800; line-height: 1.25; }
        .step-kind { background: #70a538; color: #071400; }
        .scenario-title { font-weight: 800; }
        .scenario-context { color: var(--muted); font-size: 11px; text-align: right; }
        .scenario-duration, .step-duration { color: var(--muted); font-variant-numeric: tabular-nums; text-align: right; }
        .status-pill { display: inline-block; min-width: 48px; padding: 2px 6px; color: #fff; text-align: center; font-size: 10px; font-weight: 800; border-radius: 2px; }
        .status-pill.PASS { background: var(--ok); }
        .status-pill.FAIL { background: var(--fail); }
        .status-pill.SKIP { background: var(--skip); }
        .status-pill.UNKNOWN { background: var(--unknown); }
        .scenario-content { padding: 12px; }
        .scenario-meta-grid { display: grid; grid-template-columns: repeat(4,minmax(0,1fr)); gap: 9px; margin-bottom: 10px; }
        .scenario-meta-grid > div { padding: 8px; border: 1px solid #e1e4e8; background: #fbfbfc; min-width: 0; word-break: break-word; }
        .scenario-meta-grid .meta-wide { grid-column: span 2; }
        .field-label { display: block; margin-bottom: 3px; color: var(--muted); font-size: 10px; font-weight: 700; text-transform: uppercase; letter-spacing: .04em; }
        .tag { display: inline-block; margin: 1px 4px 1px 0; padding: 2px 6px; border: 1px solid #b7c9db; background: #eaf3fb; color: #194d78; font-size: 10px; border-radius: 10px; }
        .artifact-strip { display: flex; flex-wrap: wrap; gap: 6px; margin: 8px 0 12px; }
        .artifact-link { display: inline-flex; gap: 4px; align-items: center; padding: 5px 8px; border: 1px solid #b9c4cf; background: #edf4fb; border-radius: 2px; }
        .artifact-link small { color: var(--muted); }
        .artifact-link.missing { border-color: #e1b9b9; background: #fff1f1; color: #9b2c2c; }
        .steps-heading, .section-title-row { display: flex; align-items: center; justify-content: space-between; gap: 12px; margin: 14px 0 6px; }
        .steps-heading span, .evidence-count { color: var(--muted); }
        .step-list { border: 1px solid var(--line); }
        .step-row { border-bottom: 1px solid var(--line); background: #fff; }
        .step-row:last-child { border-bottom: 0; }
        .step-row > summary { display: grid; grid-template-columns: 38px 64px minmax(260px,1fr) 95px 60px; gap: 7px; align-items: center; padding: 7px 8px; cursor: pointer; }
        .step-row.FAIL > summary { background: var(--fail-soft); }
        .step-row.SKIP > summary { background: var(--skip-soft); }
        .step-order { color: var(--muted); font-family: Consolas, monospace; }
        .step-name { font-weight: 700; }
        .step-body { padding: 10px 12px 12px 36px; border-top: 1px dashed var(--line); background: #fcfcfd; }
        .step-grid { display: grid; grid-template-columns: 1fr 1.5fr 130px; gap: 10px; }
        .step-grid > div { min-width: 0; padding: 8px; border: 1px solid #e0e3e6; background: #fff; overflow-wrap: anywhere; }
        .binding-source, .binding-note { margin-top: 3px; color: var(--muted); font-family: Consolas, monospace; font-size: 10px; }
        .binding-source.unresolved { color: var(--fail); }
        .data-table th { width: 34%; background: #f2f3f5; font-weight: 700; }
        .data-table td, .data-table th { padding: 4px 6px; font-size: 11px; word-break: break-word; }
        .diagnostic { margin: 8px 0 0; border: 1px solid #d7a8a8; background: #fff7f7; }
        .diagnostic > summary { padding: 6px 8px; color: #7f1d1d; font-weight: 700; cursor: pointer; }
        pre { margin: 0; padding: 9px; white-space: pre-wrap; word-break: break-word; overflow-wrap: anywhere; font-family: Consolas, Menlo, monospace; font-size: 11px; line-height: 1.42; background: #f7f7f8; }
        .image-button { padding: 0; border: 0; background: transparent; width: 100%; }
        .failure-evidence { margin-top: 16px; padding: 12px; border: 2px solid var(--fail); background: #fff; }
        .evidence-tabs, .attempt-tabs { display: flex; gap: 0; margin: 8px 0 0; border-bottom: 1px solid var(--line-dark); }
        .evidence-tab { padding: 7px 12px; border: 1px solid var(--line-dark); border-bottom: 0; margin-right: -1px; background: #eceeef; font-weight: 700; }
        .evidence-tab.active { background: #fff; transform: translateY(1px); }
        .evidence-pane { display: none; padding: 10px 0 0; }
        .evidence-pane.active { display: block; }
        .evidence-gallery { display: grid; grid-template-columns: repeat(auto-fill,minmax(270px,1fr)); gap: 10px; }
        .evidence-image { margin: 0; border: 1px solid var(--line); background: #f7f8f9; }
        .evidence-image img { display: block; width: 100%; max-height: 320px; object-fit: contain; background: #111; }
        .evidence-image figcaption { padding: 7px; font-size: 11px; overflow-wrap: anywhere; }
        .evidence-missing { padding: 12px; border: 1px dashed var(--fail); background: var(--fail-soft); }
        .embedded-file-meta { padding: 6px 8px; border: 1px solid var(--line); border-bottom: 0; background: #eceff2; }
        .embedded-log { max-height: 560px; overflow: auto; border: 1px solid var(--line); background: #101418; color: #e7edf3; }
        .raw-json > summary, .video-block > summary, .deferred-block > summary { padding: 7px 9px; cursor: pointer; font-weight: 700; background: #eef0f2; border: 1px solid var(--line); }
        .raw-json pre { max-height: 520px; overflow: auto; border: 1px solid var(--line); border-top: 0; }
        .deferred-block { margin: 10px 0; border: 1px solid var(--fail); }
        .deferred-block > p, .deferred-block > .table-scroll { margin: 8px; }
        .cell-pre { padding: 0; background: transparent; }
        .video-block { margin-top: 10px; }
        .video-block video { width: min(100%,1000px); max-height: 560px; display: block; margin: 8px auto 0; background: #111; }
        .notice { padding: 9px; border: 1px solid #d9c783; background: #fff9df; }
        .evidence-error { padding: 9px; border: 1px solid var(--fail); background: var(--fail-soft); }
        .muted { color: var(--muted); }
        .small { font-size: 11px; }
        .log-toolbar { display: flex; flex-wrap: wrap; gap: 8px; margin: 12px 0; }
        .log-toolbar input, .log-toolbar select { padding: 7px 8px; border: 1px solid var(--line-dark); }
        .log-toolbar input { min-width: 0; flex: 1 1 240px; }
        .log-suite { margin: 7px 0; border: 1px solid var(--line); background: #fff; }
        .log-suite > details > summary { padding: 8px 10px; background: #eceeef; font-weight: 700; cursor: pointer; }
        .log-suite .status-pill, .log-step .status-pill { float: right; margin-left: 8px; }
        .log-suite .step-duration, .log-step .step-duration { float: right; margin-left: 12px; }
        .log-scenario-meta { padding: 7px 10px; color: var(--muted); border-top: 1px solid var(--line); }
        .log-step { margin: 0 10px; border-top: 1px dashed var(--line); }
        .log-step > summary { padding: 7px 6px; cursor: pointer; }
        .log-step.FAIL > summary { background: var(--fail-soft); }
        .log-step-body { padding: 8px 16px 10px; }
        .lightbox { position: fixed; inset: 0; z-index: 9999; display: none; align-items: center; justify-content: center; padding: 24px; background: rgba(0,0,0,.88); }
        .lightbox.open { display: flex; }
        .lightbox-inner { max-width: 96vw; max-height: 94vh; display: grid; grid-template-rows: auto 1fr auto; gap: 8px; }
        .lightbox-controls { display: flex; justify-content: space-between; gap: 8px; }
        .lightbox-controls button { border: 1px solid #fff; padding: 8px; background: #111; color: #fff; }
        .lightbox img { max-width: 94vw; max-height: 78vh; object-fit: contain; background: #111; }
        .lightbox-caption { color: #fff; text-align: center; }
        @media (max-width:1120px) {
          .robot-banner .generated { position: static; text-align: left; margin: 8px 0 10px; }
          .cards { grid-template-columns: repeat(3,1fr); } .statistics-grid { grid-template-columns: 1fr; }
          .scenario-meta-grid { grid-template-columns: repeat(2,minmax(0,1fr)); }
          .scenario-details > summary { grid-template-columns: 34px 46px minmax(200px,1fr) 80px 58px; }
          .scenario-context { display: none; } .step-grid { grid-template-columns: 1fr; }
        }
        @media (max-width:700px) {
          .robot-banner { padding: 70px 14px 14px; } .robot-tabs { left: 0; right: auto; width: 100%; }
          .robot-tabs button { flex: 1; min-width: 0; } .main-content { padding: 12px; }
          .cards { grid-template-columns: repeat(2,1fr); } .banner-summary { grid-template-columns: 110px 1fr; }
          .toolbar { position: static; display: grid; grid-template-columns: 1fr; }
          .toolbar input, .toolbar select, .toolbar button { width: 100%; min-width: 0; }
          .scenario-details > summary { grid-template-columns: 44px minmax(130px,1fr) 52px; }
          .scenario-index, .scenario-duration { display: none; } .scenario-meta-grid { grid-template-columns: 1fr; }
          .scenario-meta-grid .meta-wide { grid-column: span 1; }
          .step-row > summary { grid-template-columns: 50px minmax(130px,1fr) 50px; }
          .step-order, .step-duration { display: none; } .step-body { padding-left: 8px; }
        }
        @media print {
          @page { size: A4 landscape; margin: 10mm; }
          body { background: #fff; font-size: 11px; }
          .robot-tabs, .toolbar, .log-toolbar, .lightbox { display: none !important; }
          .view, details > * { display: block !important; } #log-view { page-break-before: always; }
          .cards { grid-template-columns: repeat(3,1fr); } .statistics-grid { grid-template-columns: 1fr; }
          .statistics-panel, .scenario-card, .step-row, .evidence-image { break-inside: avoid; }
          .evidence-gallery { display: block; } .evidence-image { margin: 0 0 10px; }
        }
        """;

    internal const string JavaScript = """
        (function () {
          'use strict';
          const byId = id => document.getElementById(id);
          const all = (selector, root) => Array.from((root || document).querySelectorAll(selector));
          function setView(name) {
            all('.view').forEach(view => view.classList.toggle('active', view.id === name + '-view'));
            all('.robot-tabs button').forEach(button => button.classList.toggle('active', button.dataset.view === name));
          }
          all('.robot-tabs button').forEach(button => button.addEventListener('click', () => setView(button.dataset.view)));
          if (location.hash === '#log') setView('log');
          const controls = {
            search: byId('filter-search'), status: byId('filter-status'), feature: byId('filter-feature'),
            application: byId('filter-application'), state: byId('filter-state'), lob: byId('filter-lob')
          };
          function applyFilters() {
            const query = controls.search.value.trim().toLowerCase();
            let visible = 0;
            all('.scenario-card').forEach(card => {
              const matches = (!query || card.dataset.search.includes(query)) &&
                ['status', 'feature', 'application', 'state', 'lob'].every(key => !controls[key].value || card.dataset[key] === controls[key].value);
              card.classList.toggle('hidden', !matches);
              if (matches) visible++;
            });
            all('.feature-group').forEach(group => group.classList.toggle('hidden', !all('.scenario-card:not(.hidden)', group).length));
            byId('visible-count').textContent = visible + ' of ' + all('.scenario-card').length + ' tests';
          }
          Object.values(controls).forEach(control => control.addEventListener(control.tagName === 'INPUT' ? 'input' : 'change', applyFilters));
          byId('clear-filters').addEventListener('click', () => { Object.values(controls).forEach(control => { control.value = ''; }); applyFilters(); });
          byId('failures-only').addEventListener('click', () => { controls.status.value = controls.status.value === 'FAIL' ? '' : 'FAIL'; applyFilters(); });
          byId('expand-visible').addEventListener('click', () => all('.scenario-card:not(.hidden) > details, .feature-group:not(.hidden) > details').forEach(node => { node.open = true; }));
          byId('collapse-all').addEventListener('click', () => all('.scenario-card > details').forEach(node => { node.open = false; }));
          all('.click-filter').forEach(row => row.addEventListener('click', () => {
            const target = controls[row.dataset.filterType];
            if (target) { target.value = row.dataset.filterValue; applyFilters(); byId('test-details').scrollIntoView(); }
          }));
          all('.scenario-card').forEach(card => {
            all('.attempt-tab', card).forEach(button => button.addEventListener('click', () => {
              all('.attempt-tab', card).forEach(tab => { tab.classList.toggle('active', tab === button); tab.setAttribute('aria-pressed', String(tab === button)); });
              all('.attempt-panel', card).forEach(panel => { panel.hidden = panel.id !== button.dataset.attempt; });
            }));
          });
          all('.failure-evidence').forEach(section => {
            all('.evidence-tab', section).forEach(tab => tab.addEventListener('click', () => {
              all('.evidence-tab', section).forEach(item => { item.classList.toggle('active', item === tab); item.setAttribute('aria-pressed', String(item === tab)); });
              all('.evidence-pane', section).forEach(pane => pane.classList.toggle('active', pane.dataset.evidencePane === tab.dataset.evidenceTab));
            }));
          });
          const lightbox = byId('lightbox'), image = byId('lightbox-image'), caption = byId('lightbox-caption');
          let gallery = [], position = 0, opener = null;
          function showImage(index) {
            position = (index + gallery.length) % gallery.length;
            const button = gallery[position], thumbnail = button.querySelector('img');
            image.src = thumbnail.src;
            caption.textContent = (position + 1) + ' / ' + gallery.length + ' - ' + button.dataset.lightboxCaption;
          }
          function closeLightbox() {
            lightbox.classList.remove('open'); lightbox.setAttribute('aria-hidden', 'true'); image.removeAttribute('src');
            if (opener) opener.focus();
          }
          all('[data-lightbox]').forEach(button => button.addEventListener('click', () => {
            opener = button; gallery = all('[data-lightbox]', button.closest('.evidence-gallery')); showImage(gallery.indexOf(button));
            lightbox.classList.add('open'); lightbox.setAttribute('aria-hidden', 'false'); byId('lightbox-close').focus();
          }));
          byId('lightbox-close').addEventListener('click', closeLightbox);
          byId('lightbox-previous').addEventListener('click', () => showImage(position - 1));
          byId('lightbox-next').addEventListener('click', () => showImage(position + 1));
          lightbox.addEventListener('click', event => { if (event.target === lightbox) closeLightbox(); });
          document.addEventListener('keydown', event => {
            if (!lightbox.classList.contains('open')) return;
            if (event.key === 'Escape') closeLightbox();
            if (event.key === 'ArrowLeft') showImage(position - 1);
            if (event.key === 'ArrowRight') showImage(position + 1);
            if (event.key === 'Tab') {
              const buttons = all('button', lightbox), first = buttons[0], last = buttons[buttons.length - 1];
              if (event.shiftKey && document.activeElement === first) { event.preventDefault(); last.focus(); }
              else if (!event.shiftKey && document.activeElement === last) { event.preventDefault(); first.focus(); }
            }
          });
          function filterLog() {
            const query = byId('log-search').value.trim().toLowerCase(), status = byId('log-status').value;
            all('.log-suite').forEach(block => block.classList.toggle('hidden',
              (query && !block.dataset.search.includes(query)) || (status && block.dataset.status !== status)));
          }
          byId('log-search').addEventListener('input', filterLog);
          byId('log-status').addEventListener('change', filterLog);
          applyFilters();
        })();
        """;
}
