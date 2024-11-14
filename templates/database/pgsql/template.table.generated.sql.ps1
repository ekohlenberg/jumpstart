@"
create table $($schemaName).$($tableName) (

$(
    for ($i = 0; $i -lt $columns.Count; $i++) {
        $column = $columns[$i]
        $pk = ""
        if ($column.column_name -eq "id"){
            $pk = "PRIMARY KEY"
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
        
        $column.column_name + $space + $column.data_type + $len + $space + $pk + $nullable + $comma + $cr

        
    }

)

);