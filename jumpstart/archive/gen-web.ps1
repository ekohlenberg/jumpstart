param (
    [string]$csvPath = $PSScriptRoot + "/model.csv",
    [string]$outputFolder = $PSScriptRoot + "/../web/react-frontend/src",
    [string]$csvGlobal = $PSScriptRoot + "/global.csv"
)

# import shared functions
. ./gen-lib.ps1


# component templates
$componentOutputFolder = Join-Path -Path $outputFolder -ChildPath "components"


# service templates
$serviceOutputFolder = Join-Path -Path $outputFolder -ChildPath "services"
$serviceTemplateFile = $PSScriptRoot + "/templates/template-service.js.txt"
$serviceTemplate = Get-Content -path $serviceTemplateFile -Raw

$appOutputFolder = $outputFolder
$appTemplateFile = $PSScriptRoot + "/templates/template-app.js.txt"
$appTemplate = Get-Content -path $appTemplateFile -Raw


# Read the CSV file
$metadata = Import-Csv -Path $csvPath

# Group the metadata by table name and table catalog
$groupedMetadata = $metadata | Group-Object -Property table_name, table_catalog

# Read the Global metadata file (these attributes apply to all domain objects)
$globalMetadata = Import-Csv -Path $csvGlobal



# Function to generate the javascript/react list component for a table
function Generate-List-Component {
    param (
        [string]$tableName,
        [string]$namespace,
        [array]$columns,
        [string]$action
    )

    $templateFile = $PSScriptRoot + "/templates/template-$($action).jsx.txt"
    $template = Get-Content -path $templateFile -Raw
    
    $headerTemplateFile = $PSScriptRoot + "/templates/template-$($action)-header.jsx.txt"
    $headerTemplate = Get-Content -path $headerTemplateFile -Raw
    
    $recordTemplateFile = $PSScriptRoot + "/templates/template-$($action)-record.jsx.txt"
    $recordTemplate = Get-Content -path $recordTemplateFile -Raw
    
    $domainObj = Convert-ToPascalCase -inputString $tableName
    $domainVar = $domainObj.ToLower()

    $schemaName = $columns[0].table_schema;

    $content = $template

    $content = $content.Replace("@(Model.DomainObj)", $domainObj)
    $content = $content.Replace("@(Model.DomainVar)", $domainVar)
    $content = $content.Replace("^(namespace)", $namespace)
    $content = $content.Replace("^(tableName)", $tableName)
    $content = $content.Replace("^(schemaName)", $schemaName)

    $headerContent = ""
    $recordContent = ""

    
    for ($i = 0; $i -lt $columns.Count; $i++) {
        $column = $columns[$i]
        $headerContent = $headerContent + $headerTemplate.Replace("^(column-label)", $column.column_label)
        $recordContent = $recordContent + $recordTemplate.Replace("^(column-name)", $column.column_name)
        $recordContent = $recordContent.Replace( "@(Model.DomainVar)", $domainVar )
    }

    $content = $content.Replace( "^(list-header-partial)", $headerContent)
    $content = $content.Replace( "^(list-record-partial)", $recordContent)

    # Output the list to a .jsx file
    $PascalAction = Convert-ToPascalCase -inputString $action
    $outputPath = Join-Path -Path $componentOutputFolder -ChildPath "$($domainObj)$($PascalAction)Component.jsx"

    # conditionally write the user-maintained code
    # Check if the file exists
    #if ( -not (Test-Path -Path $outputPath) ) {
        $content | Out-File -FilePath $outputPath -Encoding utf8
    #} 
}

# Function to generate the javascript/react create component for a table

function Generate-Create-Component {
    param (
        [string]$tableName,
        [string]$namespace,
        [array]$columns,
        [string]$action
    )

    $templateFile = $PSScriptRoot + "/templates/template-$($action).jsx.txt"
    $template = Get-Content -path $templateFile -Raw
    
    $defaultsTemplateFile = $PSScriptRoot + "/templates/template-$($action)-defaults.jsx.txt"
    $defaultsTemplate = Get-Content -path $defaultsTemplateFile -Raw

    $eventsTemplateFile = $PSScriptRoot + "/templates/template-$($action)-events.jsx.txt"
    $eventsTemplate = Get-Content -path $eventsTemplateFile -Raw

    $formTemplateFile = $PSScriptRoot + "/templates/template-$($action)-form.jsx.txt"
    $formTemplate = Get-Content -path $formTemplateFile -Raw
    
    $handlersTemplateFile = $PSScriptRoot + "/templates/template-$($action)-handlers.jsx.txt"
    $handlersTemplate = Get-Content -path $handlersTemplateFile -Raw

    $saveTemplateFile = $PSScriptRoot + "/templates/template-$($action)-save.jsx.txt"
    $saveTemplate = Get-Content -path $saveTemplateFile -Raw

    $setstateTemplateFile = $PSScriptRoot + "/templates/template-$($action)-setstate.jsx.txt"
    $setstateTemplate = Get-Content -path $setstateTemplateFile -Raw


    $domainObj = Convert-ToPascalCase -inputString $tableName
    $domainVar = $domainObj.ToLower()

    $schemaName = $columns[0].table_schema;

    $content = $template

    $content = $content.Replace("@(Model.DomainObj)", $domainObj)
    $content = $content.Replace("@(Model.DomainVar)", $domainVar)
    $content = $content.Replace("^(namespace)", $namespace)
    $content = $content.Replace("^(tableName)", $tableName)
    $content = $content.Replace("^(schemaName)", $schemaName)

    $defaultsContent = ""
    $eventsContent = ""
    $formContent = ""
    $handlersContent = ""
    $saveContent = ""
    $setstateContent = ""
    
    for ($i = 0; $i -lt $columns.Count; $i++) {
        $column = $columns[$i]
        $comma = ""
        if ($i -lt $columns.Count - 1) {
            $comma = ","

        }
        $objAttr = Convert-ToPascalCase -inputString $column.column_name
        
        if ($column.column_name -ne "id") {
        
        $defaultsContent = $defaultsContent + $defaultsTemplate.Replace("^(column-name)", $column.column_name)
        $defaultsContent = $defaultsContent.Replace("^(comma)", $comma)
        }
        
        $eventsContent = $eventsContent + $eventsTemplate.Replace("^(column-name)", $column.column_name)
        $eventsContent = $eventsContent.Replace( "^(obj-attr)", $objAttr)

        $formContent = $formContent + $formTemplate.Replace("^(column-name)", $column.column_name)
        $formContent = $formContent.Replace("^(column-label)", $column.column_label)
        $formContent = $formContent.Replace("^(obj-attr)", $objAttr)

        $handlersContent = $handlersContent + $handlersTemplate.Replace("^(obj-attr)", $objAttr )

        $saveContent = $saveContent + $saveTemplate.Replace("^(column-name)", $column.column_name )
        $saveContent = $saveContent.Replace("^(comma)", $comma)
 
        $setstateContent = $setstateContent + $setstateTemplate.Replace("^(column-name)", $column.column_name )
        $setstateContent = $setstateContent.Replace("@(Model.DomainVar)", $domainVar)
        $setstateContent = $setstateContent.Replace("^(comma)", $comma)
 
    }

    $content = $content.Replace( "^(create-defaults-partial)", $defaultsContent)
    $content = $content.Replace( "^(create-handlers-partial)", $handlersContent)
    $content = $content.Replace( "^(create-events-partial)", $eventsContent)
    $content = $content.Replace( "^(create-setstate-partial)", $setstateContent)
    $content = $content.Replace( "^(create-save-partial)", $saveContent)
    $content = $content.Replace( "^(create-form-partial)", $formContent)
    $content = $content.Replace("@(Model.DomainObj)", $domainObj)
    $content = $content.Replace("@(Model.DomainVar)", $domainVar)
    

    # Output the list to a .jsx file
    $PascalAction = Convert-ToPascalCase -inputString $action
    $outputPath = Join-Path -Path $componentOutputFolder -ChildPath "$($domainObj)$($PascalAction)Component.jsx"

    # conditionally write the user-maintained code
    # Check if the file exists
    #if ( -not (Test-Path -Path $outputPath) ) {
        $content | Out-File -FilePath $outputPath -Encoding utf8
    #} 
}

# Function to generate the javascript/react service for a table
function Generate-Service {
    param (
        [string]$tableName,
        [string]$namespace,
        [array]$columns,
        [string]$action
    )

    $templateFile = $PSScriptRoot + "/templates/template-$($action).js.txt"
    $template = Get-Content -path $templateFile -Raw
    
    
    $domainObj = Convert-ToPascalCase -inputString $tableName
    $domainVar = $domainObj.ToLower()
    $domainConst = $domainObj.ToUpper()

    $schemaName = $columns[0].table_schema;

    $content = $template

    $content = $content.Replace("@(Model.DomainObj)", $domainObj)
    $content = $content.Replace("@(Model.DomainVar)", $domainVar)
    $content = $content.Replace("^(domain-const)", $domainConst)
    $content = $content.Replace("^(namespace)", $namespace)
    $content = $content.Replace("^(tableName)", $tableName)
    $content = $content.Replace("^(schemaName)", $schemaName)

    
    # Output the list to a .jsx file
    $PascalAction = Convert-ToPascalCase -inputString $action
    $outputPath = Join-Path -Path $serviceOutputFolder -ChildPath "$($domainObj)$($PascalAction).js"

    # conditionally write the user-maintained code
    # Check if the file exists
    #if ( -not (Test-Path -Path $outputPath) ) {
        $content | Out-File -FilePath $outputPath -Encoding utf8
    #} 
}

#### Main

$routeTemplateFile = $PSScriptRoot + "/templates/template-app-route.js.txt"
$routeTemplate = Get-Content -path $routeTemplateFile -Raw

$importTemplateFile = $PSScriptRoot + "/templates/template-app-import.js.txt"
$importTemplate = Get-Content -path $importTemplateFile -Raw

$headerTemplateFile = $PSScriptRoot + "/templates/template-header.js.txt"
$headerTemplate = Get-Content -path $headerTemplateFile -Raw

$headerNavTemplateFile = $PSScriptRoot + "/templates/template-header-nav.js.txt"
$headerNavTemplate = Get-Content -path $headerNavTemplateFile -Raw

$routeContent = ""
$importContent = ""
$headerNavContent = ""

# Generate components and services for each table
foreach ($group in $groupedMetadata) {
    
    
    $tableName = $group.Group[0].table_name
    $namespace = $group.Group[0].table_catalog
    $isPrimary = $group.Group[0].primary_table

    $domainObj = Convert-ToPascalCase -inputString $tableName
    $domainVar = $domainObj.ToLower()

    if ($isPrimary -eq 1) {
        Generate-List-Component -tableName $tableName -namespace $namespace -columns $group.Group -action "list"
        Generate-Create-Component -tableName $tableName -namespace $namespace -columns $group.Group -action "create"

        $headerNavContent = $headerNavContent + $headerNavTemplate.Replace("@(Model.DomainObj)", $domainObj)
        $headerNavContent = $headerNavContent.Replace("@(Model.DomainVar)", $domainVar)

        $routeContent = $routeContent + $routeTemplate.Replace("@(Model.DomainObj)", $domainObj)
        $routeContent = $routeContent.Replace("@(Model.DomainVar)", $domainVar)

        $importContent = $importContent + $importTemplate.Replace("@(Model.DomainObj)", $domainObj )

    }
   
    Generate-Service -tableName $tableName -namespace $namespace -columns $group.Group -action "service"

    
 
    
}

$appContent = $appTemplate
$appContent = $appContent.Replace("^(app-import-partial)", $importContent)
$appContent = $appContent.Replace("^(app-route-partial)", $routeContent)

$outputPath = Join-Path -Path $appOutputFolder -ChildPath "App.js"

    # conditionally write the user-maintained code
    # Check if the file exists
    #if ( -not (Test-Path -Path $outputPath) ) {
        $appContent | Out-File -FilePath $outputPath -Encoding utf8
    #} 

 $headerContent = $headerTemplate
 $headerContent = $headerContent.Replace("^(namespace)", $namespace) 
 $headerContent = $headerContent.Replace("^(header-nav-partial)", $headerNavContent)  

 $outputPath = Join-Path -Path $componentOutputFolder -ChildPath "HeaderComponent.js"

    # conditionally write the user-maintained code
    # Check if the file exists
    #if ( -not (Test-Path -Path $outputPath) ) {
        $headerContent | Out-File -FilePath $outputPath -Encoding utf8
    #} 
