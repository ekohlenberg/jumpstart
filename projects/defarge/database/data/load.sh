export PSQLCMD="psql --host=localhost --port=5432 --dbname=defarge --username=postgres"

$PSQLCMD --file=./defarge.static.generated.sql
$PSQLCMD --file=./defarge.admin.generated.sql
$PSQLCMD --file=./defarge.currentuser.generated.sql
$PSQLCMD --file=./defarge.event.test.sql
