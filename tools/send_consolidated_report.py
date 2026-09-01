#!/usr/bin/env python3
"""Send the consolidated HTML report with SMTP settings supplied only by environment variables."""
from __future__ import annotations
import argparse
import json
import mimetypes
import os
import smtplib
import ssl
from email.message import EmailMessage
from pathlib import Path


def required(name: str) -> str:
    value = os.environ.get(name, "").strip()
    if not value:
        raise SystemExit(f"Required environment variable {name} is not configured.")
    return value


def attach(message: EmailMessage, path: Path) -> None:
    if not path.exists(): return
    mime, _ = mimetypes.guess_type(path.name)
    maintype, subtype = (mime or "application/octet-stream").split("/", 1)
    message.add_attachment(path.read_bytes(), maintype=maintype, subtype=subtype, filename=path.name)


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--report-dir", required=True, type=Path)
    parser.add_argument("--subject", default="Insurance automation consolidated execution report")
    args = parser.parse_args()
    host = required("SMTP_HOST")
    port = int(os.environ.get("SMTP_PORT", "587"))
    sender = required("SMTP_FROM")
    recipients = [x.strip() for x in required("SMTP_TO").replace(";", ",").split(",") if x.strip()]
    user = os.environ.get("SMTP_USER", "").strip()
    password = os.environ.get("SMTP_PASSWORD", "")
    use_ssl = os.environ.get("SMTP_SSL", "false").lower() in {"1", "true", "yes"}

    summary_path = args.report_dir / "summary.json"
    summary = json.loads(summary_path.read_text(encoding="utf-8")) if summary_path.exists() else {}
    report_path = args.report_dir / "report.html"
    message = EmailMessage()
    message["From"] = sender
    message["To"] = ", ".join(recipients)
    message["Subject"] = f"{args.subject} - {summary.get('status', 'UNKNOWN')}"
    message.set_content(
        f"Status: {summary.get('status', 'UNKNOWN')}\nTotal: {summary.get('total', 0)}\nPassed: {summary.get('passed', 0)}\nFailed: {summary.get('failed', 0)}\n"
    )
    if report_path.exists():
        message.add_alternative(report_path.read_text(encoding="utf-8"), subtype="html")
    for name in ["report.html", "log.html", "output.xml", "summary.json"]:
        attach(message, args.report_dir / name)

    context = ssl.create_default_context()
    if use_ssl:
        with smtplib.SMTP_SSL(host, port, context=context, timeout=60) as smtp:
            if user: smtp.login(user, password)
            smtp.send_message(message)
    else:
        with smtplib.SMTP(host, port, timeout=60) as smtp:
            smtp.ehlo(); smtp.starttls(context=context); smtp.ehlo()
            if user: smtp.login(user, password)
            smtp.send_message(message)
    print(f"Consolidated report sent to {len(recipients)} recipient(s).")
    return 0

if __name__ == "__main__":
    raise SystemExit(main())
