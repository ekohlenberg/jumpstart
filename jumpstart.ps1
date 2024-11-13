param (
    [string]$modelPath =  "./model.csv"
    #,[string]$csvGlobal = $PSScriptRoot + "/global.csv"
)

#import shared functions
. "$PSScriptRoot/gen-lib.ps1"

function Init-Object-Level-Templates {
    # Initialize an empty list (array)
    $templateList = @()
    
    $templateList += [templateDefinition]::new("database/template.table.generated.sql.ps1", "./server/database", $true)
    $templateList += [templateDefinition]::new("database/template.audit.generated.sql.ps1", "./server/database", $true)
    $templateList += [templateDefinition]::new("database/template.sequence.generated.sql.ps1", "./server/database", $true)
    $templateList += [templateDefinition]::new("database/template.rwkindex.generated.sql.ps1", "./server/database", $true)
    $templateList += [templateDefinition]::new("server/domain/template.generated.cs.ps1", "./server/domain", $true)
    $templateList += [templateDefinition]::new("server/logic/templateLogic.generated.cs.ps1", "./server/logic", $true)
    $templateList += [templateDefinition]::new("server/logic/templateLogic.user.cs.ps1", "./server/logic", $false)
    $templateList += [templateDefinition]::new("server/api/template.api.generated.cs.ps1", "./server/api", $true)
    $templateList += [templateDefinition]::new("server/test/template.test.generated.cs.ps1", "./server/test", $true)
    $templateList += [templateDefinition]::new("server/test/template.test.user.cs.ps1", "./server/test", $false)

    return $templateList
    
    }

function Init-App-Level-Templates {

     # Initialize an empty list (array)
     $templateList = @()
    
     $templateList += [templateDefinition]::new("database/template.database.create.generated.sql.ps1", "./server/database", $true)
     $templateList += [templateDefinition]::new("database/template.connection.grants.generated.sql.ps1", "./server/database", $true)
     
     $templateList += [templateDefinition]::new("server/test/BaseTest.generated.cs.ps1", "./server/test", $true)
     $templateList += [templateDefinition]::new("server/persist/DBPersist.generated.cs.ps1", "./server/persist", $true)
     $templateList += [templateDefinition]::new("server/common/Config.generated.cs.ps1", "./server/common", $true)
     $templateList += [templateDefinition]::new("server/common/Logic.generated.cs.ps1", "./server/common", $true)
     $templateList += [templateDefinition]::new("server/common/Tuple.generated.cs.ps1", "./server/common", $true)
     $templateList += [templateDefinition]::new("server/common/Util.generated.cs.ps1", "./server/common", $true)
     
     return $templateList
}

function Init-Schema-Level-Templates {
    # Initialize an empty list (array)
    $templateList = @()
        
    $templateList += [templateDefinition]::new("database/template.schema.create.generated.sql.ps1", "./server/database", $true)
    $templateList += [templateDefinition]::new("database/template.schema.grants.generated.sql.ps1", "./server/database", $true)

    return $templateList
}


function Init-Build-Templates {

    # Initialize an empty list (array)
    $templateList = @()

    $templateList += [templateDefinition]::new("database/template.build.generated.sh.ps1", "./server/database", $true)

    return $templateList

}

   
function Get-UniqueCatalogSchemaNames {
    param (
        [Parameter(Mandatory = $true)]
        [array]$Metadata
    )

    # Filter out rows without both table_catalog and schemaName values
    $filteredData = $Metadata | Where-Object { 
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


# Read the CSV file
$metadata = Import-Csv -Path $modelPath

# Group the metadata by table name and table catalog
$groupedMetadata = $metadata | Group-Object -Property table_name, table_catalog

# Read the Global metadata file (these attributes apply to all domain objects)
#$globalMetadata = Import-Csv -Path $csvGlobal
[templateDefinition]$currentTemplate = $null

try
{
# Generate single files once for the application
$appTemplates = Init-App-Level-Templates

foreach($appTemplateDef in $appTemplates) {
    $currentTemplate = $appTemplateDef

    Write-Output "Processing template $($currentTemplate.templateFile) for application"
       
    
    Generate-AppLevel -domainObjects $groupedMetadata -templateFile $currentTemplate.templateFile -outputFolder $currentTemplate.outFolder -force $currentTemplate.force
}



    
$schemaTemplates = Init-Schema-Level-Templates
# Generate files for each schema
$uniqueCatalogSchemas = Get-UniqueCatalogSchemaNames -Metadata $metadata
foreach ($catalogSchema in $uniqueCatalogSchemas) {
    $schemaName = $catalogSchema.table_schema
    $namespace = $catalogSchema.table_catalog

    foreach($schemaTemplate in $schemaTemplates) {
        $currentTemplate = $schemaTemplate
        Write-Output "Processing template $($currentTemplate.templateFile) for schema $($schemaName)"
        Generate-SchemaLevel -schemaName $schemaName -namespace $namespace -templateFile $currentTemplate.templateFile -outputFolder $currentTemplate.outFolder -force $currentTemplate.force
    }

}


    # Generate files for each class

    $templateList = Init-Object-Level-Templates

    foreach ($template in $templateList) {
        
        foreach ($group in $groupedMetadata) {
    
        # Traverse the list and read attributes
    
            $currentTemplate = $template
            Write-Output "Processing template $($template.templateFile) for object $($group.Group[0].table_name)"
            Generate-Object  -columns $group.Group -templateFile $template.templateFile -outputFolder $template.outFolder -force $template.force
        
        }
    
    }

    $buildTemplates = Init-Build-Templates
    foreach($buildTemplate in $buildTemplates) {
        $currentTemplate = $buildTemplate
    
        Write-Output "Processing build template $($currentTemplate.templateFile) for application"
           
        
        Generate-AppLevel -domainObjects $groupedMetadata -templateFile $currentTemplate.templateFile -outputFolder $currentTemplate.outFolder -force $currentTemplate.force
    }
    


}
catch 
{
    Write-Error "ERROR Template $($currentTemplate.templateFile) $_"
 }
