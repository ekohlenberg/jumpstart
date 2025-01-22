export PSQLCMD="psql --host=localhost --port=5432 --dbname=legr3 --username=postgres"

$PSQLCMD --file=./legr3.static.generated.sql
$PSQLCMD --file=./legr3.admin.generated.sql
$PSQLCMD --file=./legr3.currentuser.generated.sql
