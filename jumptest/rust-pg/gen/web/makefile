TARGETDIR=../../bin/web

default: build

build:
	@npm install
	@npm run build
	@mkdir -p $(TARGETDIR)
	@cp -r -f dist/. $(TARGETDIR)
	@# Copy hand-written web assets from usr/web into the deployed bin/web
	@# (e.g. usr/web/public/config.json).
	@cp -r -f ../../usr/web/. $(TARGETDIR)

clean:
	@rm -rf ./dist
	@rm -rf ./node_modules

install:
	@npm install

dev:
	@npm run dev

preview:
	@npm run preview
