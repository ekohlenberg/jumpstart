# Function to convert table names to class names


# Mapping PostgreSQL data types to C# data types
$typeMapping = @{
    "integer"       = "System.Int32"
    "bigint"        = "System.Int64"
    "smallint"      = "System.Int16"
    "serial"        = "System.Int32"
    "bigserial"     = "System.Int64"
    "boolean"       = "System.Boolean"
    "char"          = "System.String"
    "varchar"       = "System.String"
    "text"          = "System.String"
    "date"          = "System.DateTime"
    "timestamp"     = "System.DateTime"
    "timestamptz"   = "System.DateTime"
    "time"          = "System.TimeSpan"
    "timetz"        = "System.TimeSpan"
    "real"          = "System.Single"
    "double precision" = "System.Double"
    "numeric"       = "System.Decimal"
    "numeric(18,4)" = "System.Double"
    "decimal"       = "System.Decimal"
    "bytea"         = "System.Byte[]"
    "uuid"          = "System.Guid"
    "json"          = "System.String"
    "jsonb"         = "System.String"
    "xml"           = "System.String"
    "money"         = "System.Decimal"
    "inet"          = "System.String"
    "cidr"          = "System.String"
    "macaddr"       = "System.String"
}


# Define a hashtable mapping PostgreSQL data types to C# Convert methods
$convertMapping = @{
    "integer"       = "ToInt32"
    "bigint"        = "ToInt64"
    "smallint"      = "ToInt16"
    "serial"        = "ToInt32"
    "bigserial"     = "ToInt64"
    "boolean"       = "ToBoolean"
    "char"          = "ToString"
    "varchar"       = "ToString"
    "text"          = "ToString"
    "date"          = "ToDateTime"
    "timestamp"     = "ToDateTime"
    "timestamptz"   = "ToDateTime"
    "time"          = "ToDateTime" # Convert to DateTime, then use .TimeOfDay for TimeSpan
    "timetz"        = "ToDateTime" # Convert to DateTime, then use .TimeOfDay for TimeSpan
    "real"          = "ToSingle"
    "double precision" = "ToDouble"
    "numeric"       = "ToDouble"
    "numeric(18,4)"       = "ToDouble"
    "decimal"       = "ToDouble"
    "bytea"         = "ToByte[]"
    "uuid"          = "Guid.Parse" # Guid.Parse is used instead of Convert for UUIDs
    "json"          = "ToString"
    "jsonb"         = "ToString"
    "xml"           = "ToString"
    "money"         = "ToDecimal"
    "inet"          = "ToString"
    "cidr"          = "ToString"
    "macaddr"       = "ToString"
}

function Convert-ToPascalCase {
    param (
        [string]$inputString
    )
    
    # Split the input string by underscore
    $parts = $inputString -split '_'

    # Convert each part to capitalize the first letter
    $pascalCaseParts = $parts | ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1).ToLower() }

    # Join the parts together
    $pascalCaseString = -join $pascalCaseParts

    return $pascalCaseString
}

[char]$tab = 9
[string]$space = " "
[char]$global:cr = 10

class MetaAttribute {
    [string]$name
    [string]$datatype
    [string]$length
    [string]$label
    [string]$rwk

    [string]ToString() {
        $result = "Name: " + $this.name + $global:cr
        $result += "Datatype: " + $this.datatype + $global:cr
        $result += "Length: " + $this.length + $global:cr
        $result += "Label: " + $this.label + $global:cr
        $result += "RWK: " + $this.rwk + $global:cr

        return $result
    }
}

class MetaObject {
    [string]$domainObj
    [string]$domainVar
    [string]$tableName
    
    [System.Collections.Generic.SortedDictionary[string,MetaAttribute]] $attributes = [System.Collections.Generic.SortedDictionary[string,MetaAttribute]]::new

    MetaObject([string]$table_name) {
        $this.tableName = $table_name
        $this.domainObj = Convert-ToPascalCase -inputString $table_name
        $this.domainVar = $this.domainObj.ToLower()

    }
    [string] ToString() {
        $result = "Domain Obj: " + $this.domainObj + $global:cr
        $result += "Domain Var: " + $this.domainVar + $global:cr
        $result += "Table Name:" + $this.tableName + $global:cr

        foreach ($a in $this.attributes.Keys ) {
            $result += $this.attributes[$a].ToString()
        }

        return $result
    }

}

class MetaSchema {
    [string]$name
    [System.Collections.Generic.SortedDictionary[string,MetaObject]] $objects 

    MetaSchema([string]$name) {
        $this.name = $name
        $this.objects = [System.Collections.Generic.SortedDictionary[string,MetaObject]]::new
    }

    [string] ToString() {
        [string]$result = "Schema: " + $this.name + $global:cr
        foreach( $o in $this.objects.Keys ) {
            $result += $this.objects[$o].ToString()
        }

        return $result

    }
    
}
class MetaModel {
    [string]$namespace
    [System.Collections.Generic.Dictionary[string,MetaObject]] $schemas
    

    MetaModel() {
        $this.namespace = ""
        $this.schemas = New-Object System.Collections.Generic.Dictionary[string,MetaObject]
        
    }
    
    [string] ToString() {

        $result = "namespace="+$this.namespace + $global:cr
        foreach( $s in $this.schemas.Keys ) {
            $result += $this.schemas[$s].ToString()
        }

        return $result
    }
}


class CSVLoader {

    CSVloader()
    {

    }
    [void] load([string]$modelPath) {
        

        # Read the CSV file
        $metadata = Import-Csv -Path $modelPath
        
        [MetaModel]$metaModel = New-Object MetaModel

        foreach( $attrData in $metadata) {
            $this.setNamespace($metaModel, $attrData )
            $this.addSchema( $metaModel, $attrData) 
           
        }

    }

    [void] setNamespace([MetaModel] $metaModel, [PSObject]$attrData) {
        
        if ($metaModel.namespace -eq "") {
            $metaModel.namespace = $attrData.table_catalog
        }
       
    }

    [void] addSchema([MetaModel]$metaModel,[PSObject]$attrData) {
        
        [MetaSchema]$metaSchema = $null

        if ($metaModel.schemas.ContainsKey($attrData.table_schema)) {

            $metaSchema = [MetaSchema]::new($attrData.table_schema)
            $metaModel.schemas.Add( $attrData.table_name, $metaSchema)
        }
        else {
            $metaSchema = $metaModel.schemas[$attrData.table_schema]
        }

        $this.addObject($metaSchema , $attrData)
        
    }

    [void] addObject([MetaSchema]$metaSchema,[PSObject]$attrData) { 
       

        [MetaObject]$metaObject = $null
        if ($metaSchema.objects.ContainsKey($attrData.table_name)) {
            $metaObject = $metaSchema.objects[$attrData.table_name]
        }
        else {
            $metaObject = [MetaObject]::new($attrData.table_name)
            $metaSchema.objects.Add($attrData.table_name, $metaObject)
        }

        $this.addAttribute($metaObject, $attrData)

    }

    [void] addAttribute([MetaObject] $metaObject,[PSObject]$attrData) {

        [MetaAttribute]$metaAttribute = $null
        if ($metaObject.attributes.ContainsKey($attrData.column_name)) {
            $metaAttribute = $metaObject.attributes[$attrData.column_name]                
        } else  {
            $metaAttribute = [MetaAttribute]::new
            $metaAttribute.name = $attrData.column_name
            $metaAttribute.datatype = $attrData.datatype
            $metaAttribute.length = $attrData.column_length
            $metaAttribute.label = $attrData.column_label
            $metaAttribute.rwk = $attrData.rwk
        }
    }
}







