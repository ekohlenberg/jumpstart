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
    
     $templateList += [templateDefinition]::new("server/test/BaseTest.generated.cs.ps1", "./server/test", $true)
     $templateList += [templateDefinition]::new("server/persist/DBPersist.generated.cs.ps1", "./server/persist", $true)
     $templateList += [templateDefinition]::new("server/common/Config.generated.cs.ps1", "./server/common", $true)
     $templateList += [templateDefinition]::new("server/common/Logic.generated.cs.ps1", "./server/common", $true)
     $templateList += [templateDefinition]::new("server/common/Tuple.generated.cs.ps1", "./server/common", $true)
     $templateList += [templateDefinition]::new("server/common/Util.generated.cs.ps1", "./server/common", $true)
     
     return $templateList
}


# Read the CSV file
$metadata = Import-Csv -Path $modelPath

# Group the metadata by table name and table catalog
$groupedMetadata = $metadata | Group-Object -Property table_name, table_catalog

# Read the Global metadata file (these attributes apply to all domain objects)
#$globalMetadata = Import-Csv -Path $csvGlobal
[TemplateDefinition]$currentTemplate = $null

try
{
# Generate files for each class

$templateList = Init-Object-Level-Templates

foreach ($group in $groupedMetadata) {

    # Traverse the list and read attributes
    foreach ($template in $templateList) {
        $currentTemplate = $template
        Write-Output "Processing template $($template.templateFile) for object $($group.Group[0].table_name)"
        Generate-Object  -columns $group.Group -templateFile $template.templateFile -outputFolder $template.outFolder -force $template.force
    
    }

}
    

# Generate files for each schema
$schemaMetadata = $metadata | Group-Object -Property table_schema
foreach ($schema in $schemaMetadata) {

    Write-Output $schema.table_schema

}




# Generate single files once for the application
$appTemplates = Init-App-Level-Templates

foreach($appTemplateDef in $appTemplates) {
    $currentTemplate = $appTemplateDef

    Write-Output "Processing template $($currentTemplate.templateFile)"
       
    
    Generate-AppLevel -domainObjects $groupedMetadata -templateFile $currentTemplate.templateFile -outputFolder $currentTemplate.outFolder -force $currentTemplate.force
}


}
catch 
{
    Write-Error "ERROR Template $($currentTemplate.templateFile) $_"
 }
