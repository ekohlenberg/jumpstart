TARGETDIR=./bin/Debug/net8.0

default: build

build:
	@jumpstart ./legr3.csv

clean:
	@rm -rf ./server
	@rm -rf ./database
	@rm -rf ./web

cleanuser:
	@rm -rf server/domain/*user*
	@rm -rf server/logic/*user*
	@rm -rf server/test/*user*

cleangen:
	@rm -rf server/domain/*generated*
	@rm -rf server/logic/*generated*
	@rm -rf server/test/*generated*
