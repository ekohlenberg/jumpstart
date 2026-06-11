#!/bin/bash
# Creates a tmux session with 4 panes in a 2x2 layout

PREFIX="${1:-dev}"
SESSION="${PREFIX}-$(date +%s)"

# Kill any stale sessions with this prefix
tmux list-sessions -F "#{session_name}" 2>/dev/null \
  | grep "^${PREFIX}-" \
  | xargs -I{} tmux kill-session -t {} 2>/dev/null || true

tmux new-session -d -s "$SESSION"

# Split into top/bottom halves
tmux split-window -v -t "$SESSION"

# Split each half into left/right
tmux split-window -h -t "$SESSION:0.0"
tmux split-window -h -t "$SESSION:0.2"

# Arrange evenly
tmux select-layout -t "$SESSION" tiled

# Attach
tmux attach-session -t "$SESSION"
