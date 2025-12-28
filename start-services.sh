#!/bin/bash

# Simple script to start background services
# Usage: ./start-services.sh

PID_FILE=".service-pids"

# Clear previous PID file
> "$PID_FILE"

echo "Starting services..."

# Start API server
if [ -d "server/api" ]; then
    cd server/api
    dotnet run > ../logs/api.log 2>&1 &
    echo "$!" >> "../../$PID_FILE"
    echo "API server started (PID: $!)"
    cd ../..
fi

# Start Scheduler
if [ -d "server/scheduler" ]; then
    cd server/scheduler
    dotnet run > ../logs/scheduler.log 2>&1 &
    echo "$!" >> "../../$PID_FILE"
    echo "Scheduler started (PID: $!)"
    cd ../..
fi

# Start Agent
if [ -d "server/agent" ]; then
    cd server/agent
    dotnet run > ../logs/agent.log 2>&1 &
    echo "$!" >> "../../$PID_FILE"
    echo "Agent started (PID: $!)"
    cd ../..
fi

# Create logs directory if needed
mkdir -p logs

echo "Done. PIDs saved to $PID_FILE"
