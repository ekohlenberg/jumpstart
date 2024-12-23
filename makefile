TARGETDIR=./bin/Debug/net8.0

default: build

build:
	@dotnet build
	@mkdir -p $(TARGETDIR)/templates
	@cp -r -f ./templates $(TARGETDIR)
	@mkdir -p $(TARGETDIR)/global
	@cp -r -f ./global $(TARGETDIR)

clean:
	@rm -rf ./bin
