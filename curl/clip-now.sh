#!/usr/bin/env sh
# Pin the last minute of the stream EasyClippers is recording now; that stretch becomes a captioned vertical short.
# Usage: EASYCLIPPERS_TOKEN=... ./clip-now.sh [seconds]   (seconds: 10 to 120, default 60)
# Make a token in EasyClippers: Settings, API and connectors, New token.
set -eu
SECONDS_TO_CLIP="${1:-60}"
curl -sS -X POST "https://easyclippers.com/api/v1/recordings/clip-now" \
  -H "Authorization: Bearer ${EASYCLIPPERS_TOKEN:?set EASYCLIPPERS_TOKEN first}" \
  -H "Content-Type: application/json" \
  -d "{\"seconds\": ${SECONDS_TO_CLIP}}"
echo
