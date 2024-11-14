@"
$(  
    $nrwk = 0
    $indexColumns = @()  # Initialize an array to store column names with rwk = 1

    # Count columns with rwk flag set to 1
    for ($i = 0; $i -lt $columns.Count; $i++) {
        if ($columns[$i].rwk -eq "1") {
            $nrwk++
            $indexColumns += $columns[$i].column_name  # Add the column name to the list
        }
    }

    # If any column has rwk flag = 1, build the CREATE UNIQUE INDEX statement
    if ($nrwk -gt 0) {
        "CREATE UNIQUE INDEX rwk_$($schemaName)_$($tableName) ON $($schemaName).$($tableName) (" + 
        ($indexColumns -join ", ") + ");" + $cr
    } else {
        ""
    }
)

"@

