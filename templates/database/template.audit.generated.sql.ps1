@"
create table audit.$($schemaName)_$($tableName) (

$(
    "id BIGINT PRIMARY KEY," + $cr

    for ($i = 0; $i -lt $columns.Count; $i++) {
        $column = $columns[$i]
        $pk = ""
        $colName = $column.column_name
        if ($colName -eq "id"){
            $colName = $tableName + "_id"
        }

        $len = ""
        if (($column.character_maximum_length) -ne "NULL") {
            $len = "(" + $column.character_maximum_length + ")"
        }

        $nullable = ""
        if ($column.rwk -eq "1") {
            $nullable = " not null"
        }

        $comma = ""
        if ($i -lt $columns.Count - 1) {
            $comma = ","
        } 
        
        $colName + $space + $column.data_type + $len + $space + $pk + $nullable + $comma + $cr

        
    }

)

);