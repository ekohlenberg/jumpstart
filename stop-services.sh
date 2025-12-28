#!/bin/bash

# Simple script to stop background services
# Usage: ./stop-services.sh

PID_FILE=".service-pids"

if [ ! -f "$PID_FILE" ]; then
    echo "No PID file found. Nothing to stop."
    exit 0
fi

echo "Stopping services..."

# Read each PID and kill it
while read pid; do
    if [ -n "$pid" ]; then
        kill $pid 2>/dev/null
        echo "Stopped PID: $pid"
    fi
done < "$PID_FILE"

# Remove PID file
rm -f "$PID_FILE"

echo "Done."
