TARGETDIR=./bin/Debug/net8.0
dotnet build
mkdir -p $TARGETDIR/templates
cp -r -f ./templates $TARGETDIR
mkdir -p $TARGETDIR/global
cp -r -f ./global $TARGETDIR


