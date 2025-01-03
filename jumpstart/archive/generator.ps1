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

[char]$tab = 9
[string]$space = " "
[char]$cr = 10

class MetaAttribute {
    [string]$name
    [string]$datatype
    [string]$length
    [string]$label
    [string]$rwk
}

class MetaObject {
    [string]$name
    [string]$schema
    [string]$tableName
    [string]$domainObj
    [string]$domainVar
    [System.Collections.Generic.SortedDictionary[string,MetaAttribute]] $attributes = [System.Collections.Generic.SortedDictionary[string,MetaAttribute]]::new()
}
class MetaModel {
    [string]$namespace
    [System.Collections.Generic.List[string]] $schemas = [System.Collections.ArrayList[string]]::new()
    [System.Collections.Generic.SortedDictionary[string,MetaObject]] objects = [System.Collections.Generic.SortedDictionary[string,MetaObject]]::new()
}


# Define the TempalateDefinition class
class TemplateDefinition {
    [string]$templateFile
    [string]$outFolder
    [bool]$force

    # Constructor to initialize properties
    TemplateDefinition([string]$templateFile, [string]$outFolder, [bool]$force) {
        $this.templateFile = $templateFile
        $this.outFolder = $outFolder
        $this.force = $force
    }
}

class Generator {
    [MetaModel]$metaModel

    [System.Collections.Generic]
}

$metadataMap = @{}
function Add-To-MetadataMap {
    param (
        [string]$tableName,     
        [PSObject]$columnData   
    )

   
    # Check if the table already exists in the metadataMap
    if ($metadataMap.ContainsKey($tableName)) {
        # table exists, so retrieve the list and add the new columnData
        $metadataMap[$tableName].Add($columnData)
    }
    else {
        # tableName does not exist, so create a new list with the columnData
        $metadataMap[$tableName] = [System.Collections.Generic.List[string]]@($columnData)
    }
}


# Initialize an empty outputFolderMap
$outputFolderMap = @{}

# Function to add a string to a list in the outputFolderMap
function Add-To-OutputFolderMap {
    param (
        [string]$outputFolder,     # The outputFolderMap outputFolder
        [string]$outputFile    # The string to add to the list
    )

    $filename = Split-Path -Path $outputFile -Leaf

    # Check if the outputFolder already exists in the outputFolderMap
    if ($outputFolderMap.ContainsKey($outputFolder)) {
        # outputFolder exists, so retrieve the list and add the new string
        $outputFolderMap[$outputFolder].Add($filename)
    }
    else {
        # outputFolder does not exist, so create a new list with the string
        $outputFolderMap[$outputFolder] = [System.Collections.Generic.List[string]]@($filename)
    }
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


function Generate-Object {
    param (
        [array]$columns, 
        [string]$templateFile,
        [string]$outputFolder,
        [Boolean]$force=$false
    )

    $tableName = $columns[0].table_name
    $schemaName = $columns[0].table_schema
    $namespace = $columns[0].table_catalog
    $domainObj = Convert-ToPascalCase -inputString $tableName
    $domainVar = $domainObj.ToLower()
    
    $templatePath = $PSScriptRoot + "/templates/$($templateFile)"

    

    if (-Not (Test-Path -Path $templatePath)) {
        throw "Template not found: " + $templatePath
    }

    [string]$template = Get-Content -path $templatePath -Raw
    $template = $template.Replace("@""", "")
    $template = $template.Replace("""@", "")

    $domainObj = Convert-ToPascalCase -inputString $tableName

    $domainVar = $domainObj.ToLower()

    $schemaName = $columns[0].table_schema;

    
    $generatedCode = $ExecutionContext.InvokeCommand.ExpandString($template)
    $generatedCode = $generatedCode.Trim();

    if ($generatedCode.Length -gt 0 ) {

        # Output the class to a target file based onthe targetFilePattern
        $targetFile = Split-Path -Path $templatePath -Leaf
        $targetFile = $targetFile.Replace( "template",$domainObj).Replace(".ps1", "")
        
        # Check if the folder exists
        if (-Not (Test-Path -Path $outputFolder)) {
            # Folder doesn't exist, so create it
            New-Item -ItemType Directory -Path $outputFolder
        } 

        $outputPath = Join-Path -Path $outputFolder -ChildPath $targetFile

        # conditionally write the user-maintained code
        # Check if the file exists
        if ( -not (Test-Path -Path $outputPath) -or ($force) ) {
            $generatedCode | Out-File -FilePath $outputPath -Encoding utf8
        } 
        Add-To-OutputFolderMap -outputFolder $outputFolder -outputFile $outputPath
    }

}

function Get-UniqueCatalogSchemaNames {
    param (
        [Parameter(Mandatory = $true)]
        [hashtable]$metadata
    )

    # Filter out rows without both table_catalog and schemaName values
    $filteredData = $metadata | Where-Object { 
        $_.table_catalog -ne $null -and $_.table_catalog -ne "" -and
        $_.table_schema -ne $null -and $_.table_schema -ne "" 
    }

    # Collect unique pairs of table_catalog and schemaName
    $uniqueCatalogSchemaNames = $filteredData | ForEach-Object {
        "$($_.table_catalog),$($_.table_schema)"
    } | Sort-Object -Unique

    # Convert the list back to a custom object for easier access
    $result = $uniqueCatalogSchemaNames | ForEach-Object {
        $parts = $_ -split ","
        [PSCustomObject]@{
            table_catalog = $parts[0]
            table_schema = $parts[1]
        }
    }

    return $result
}

function Generate-SchemaLevel { 
    param(
        [string]$schemaName,
        [string]$namespace,
        [string]$templateFile,
        [string]$outputFolder
    )
    
    $templatePath = $PSScriptRoot + "/templates/" + $templateFile

    $template = Get-Content -path $templatePath -Raw
    $template = $template.Replace("@""", "")
    $template = $template.Replace("""@", "")

    $generatedCode = $ExecutionContext.InvokeCommand.ExpandString($template)


    $targetFile = Split-Path -Path $templatePath -Leaf
    $targetFile = $targetFile.Replace( "template",$schemaName).Replace(".ps1", "")

    $outputPath = Join-Path -Path $outputFolder -ChildPath $targetFile
    
    # Check if the folder exists
    if (-Not (Test-Path -Path $outputFolder)) {
        # Folder doesn't exist, so create it
        New-Item -ItemType Directory -Path $outputFolder
    } 

    # conditionally write the user-maintained code
    # Check if the file exists
    if ( -not (Test-Path -Path $outputPath) -or ($force) ) {
        $generatedCode | Out-File -FilePath $outputPath -Encoding utf8
    } 
    
    Add-To-OutputFolderMap -outputFolder $outputFolder -outputFile $outputPath

}



function Generate-AppLevel { 
    param(
        [hashtable]$metadata,
        [string]$templateFile,
        [string]$outputFolder,
        [Boolean]$force=$false
    )
    $namespace = $metadata.Values[0].table_catalog
    
    $templatePath = $PSScriptRoot + "/templates/" + $templateFile

    $template = Get-Content -path $templatePath -Raw
    $template = $template.Replace("@""", "")
    $template = $template.Replace("""@", "")
    
    [System.Collections.Generic.List[string]]$outputFiles = [System.Collections.Generic.List[string]] $outputFolderMap[$outputFolder]
    
    $generatedCode = $ExecutionContext.InvokeCommand.ExpandString($template)


    $targetFile = Split-Path -Path $templatePath -Leaf
    $targetFile = $targetFile.Replace( "template",$namespace).Replace(".ps1", "")

    $outputPath = Join-Path -Path $outputFolder -ChildPath $targetFile
    


    # Check if the folder exists
    if (-Not (Test-Path -Path $outputFolder)) {
        # Folder doesn't exist, so create it
        New-Item -ItemType Directory -Path $outputFolder
    } 

    # conditionally write the user-maintained code
    # Check if the file exists
    if ( -not (Test-Path -Path $outputPath) -or ($force) ) {
        $generatedCode | Out-File -FilePath $outputPath -Encoding utf8
    } 
    
    Add-To-OutputFolderMap -outputFolder $outputFolder -outputFile $outputPath

}

