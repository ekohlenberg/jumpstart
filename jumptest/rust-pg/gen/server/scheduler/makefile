default: build

build:
	@cargo build
	@mkdir -p ../../../bin
	@cp -f target/debug/scheduler ../../../bin/scheduler
	@cp -f scheduler.sh ../../../bin/scheduler.sh
	@cp -f scheduler.cmd ../../../bin/scheduler.cmd
	@chmod +x ../../../bin/scheduler ../../../bin/scheduler.sh

run:
	@cargo run

clean:
	@cargo clean
