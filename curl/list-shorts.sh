#!/usr/bin/env sh
# List your approved shorts (filters: status, project_id, q, since, until).
# Usage: EASYCLIPPERS_TOKEN=... ./list-shorts.sh
set -eu
curl -sS "https://easyclippers.com/api/v1/shorts?status=approved" \
  -H "Authorization: Bearer ${EASYCLIPPERS_TOKEN:?set EASYCLIPPERS_TOKEN first}"
echo
