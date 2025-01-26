TARGETDIR=./bin/Debug/net8.0

default: build

build:
	@jumpstart ./legr3.csv pgsql
	@jumpstart ./legr3.csv dotnet
	@jumpstart ./legr3.csv react

database:
	@jumpstart ./legr3.csv pgsql

server:
	@jumpstart ./legr3.csv dotnet

web:
	@jumpstart ./legr3.csv react

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
