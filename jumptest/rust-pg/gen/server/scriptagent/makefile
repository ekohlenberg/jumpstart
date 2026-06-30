default: build

build:
	@cargo build
	@mkdir -p ../../../bin
	@cp -f target/debug/scriptagent ../../../bin/scriptagent
	@cp -f scriptagent.sh ../../../bin/scriptagent.sh
	@cp -f scriptagent.cmd ../../../bin/scriptagent.cmd
	@chmod +x ../../../bin/scriptagent ../../../bin/scriptagent.sh

run:
	@cargo run

clean:
	@cargo clean
