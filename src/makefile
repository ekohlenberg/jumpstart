TARGETDIR=./bin/Debug/net9.0

default: build

build:
	@dotnet build
	@mkdir -p $(TARGETDIR)/templates
	@cp -r -f ../templates $(TARGETDIR)

clean:
	@rm -rf ./bin
