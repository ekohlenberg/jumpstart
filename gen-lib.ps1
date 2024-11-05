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
    }

}

function Generate-AppLevel { 
    param(
        [array]$domainObjects,
        [string]$templateFile,
        [string]$outputFolder,
        [string]$targetFile
    )

    
    $templatePath = $PSScriptRoot + "/templates/" + $templateFile

    $template = Get-Content -path $templatePath -Raw

    $generatedCode = $ExecutionContext.InvokeCommand.ExpandString($template)

    $outputPath = Join-Path -Path $outputFolder -ChildPath $targetFile
    
    # conditionally write the user-maintained code
    # Check if the file exists
    if ( -not (Test-Path -Path $outputPath) -or ($force) ) {
        $generatedCode | Out-File -FilePath $outputPath -Encoding utf8
    } 
    
}

