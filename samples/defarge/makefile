TARGETDIR=./bin/Debug/net8.0

default: build

build:
	@jumpstart ./defarge.csv pgsql
	@jumpstart ./defarge.csv dotnet
	@jumpstart ./defarge.csv react

database:
	@jumpstart ./defarge.csv pgsql

server:
	@jumpstart ./defarge.csv dotnet

web:
	@jumpstart ./defarge.csv react

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
