# Service Management Scripts

Two bash scripts for managing background services on macOS and Linux.

## Files

- **start-services.sh** - Starts background services and tracks their PIDs
- **stop-services.sh** - Stops all services started by start-services.sh

## Usage

### Starting Services

```bash
./start-services.sh
```

This will:
- Start all configured services in the background
- Create a `.service-pids` file to track process IDs
- Create a `logs/` directory for service logs
- Display status of all started services

### Stopping Services

```bash
./stop-services.sh
```

This will:
- Read the `.service-pids` file
- Send SIGTERM to each process (graceful shutdown)
- Wait up to 10 seconds per process
- Force kill (SIGKILL) if process doesn't stop gracefully
- Remove the PID file when done

## Customization

Edit `start-services.sh` to add your own services. The `start_service` function takes:
1. Service name (for logging)
2. Command to run

Example:
```bash
start_service "my-service" "dotnet run --project MyProject"
start_service "redis" "redis-server"
start_service "postgres" "postgres -D /usr/local/var/postgres"
```

## Features

- **Cross-platform**: Works on macOS and Linux
- **PID tracking**: Stores process IDs in `.service-pids` file
- **Logging**: Redirects stdout/stderr to `logs/<service-name>.log`
- **Graceful shutdown**: Tries SIGTERM before SIGKILL
- **Status checking**: Verifies processes are actually running
- **Color output**: Uses colors for better readability (optional)

## Notes

- The scripts use `kill -0` to check if a process is running (portable across Unix systems)
- Logs are stored in the `logs/` directory
- The PID file (`.service-pids`) is created in the current directory
- Make sure the scripts are executable: `chmod +x start-services.sh stop-services.sh`

