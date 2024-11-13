
@"
export PSQLCMD="psql --host=localhost --port=5432 --dbname=$($namespace) --username=postgres"
psql --host=localhost --port=5432 --dbname=postgres --username=postgres --file=./$($namespace).sql
$( 

    for($i = 0; $i -lt $outputFiles.Count; $i++) {
    $outputFile = $outputFiles[$i]  
    "`$PSQLCMD --file=./" + $($outputFile)
    }
)
@"