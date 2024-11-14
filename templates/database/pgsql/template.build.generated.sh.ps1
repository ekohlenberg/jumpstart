
@"
export PSQLCMD="psql --host=localhost --port=5432 --dbname=$($namespace) --username=postgres"
psql --host=localhost --port=5432 --dbname=postgres --username=postgres --file=./$($namespace).database.create.generated.sql
$( 
    #Write-Error $outputFiles.Count
    for($i = 0; $i -lt $outputFiles.Count; $i++) {
    $outputFile = $outputFiles[$i]  
    if ($outputFile -ne "$($namespace).database.create.generated.sql") {
        "`$PSQLCMD --file=./" + $($outputFile) + $cr
        }
    }
)
"@