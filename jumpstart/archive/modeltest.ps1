param (
    [string]$modelPath
)

. "$PSScriptRoot/metamodel.ps1"

#[CSVLoader] $csvLoader = [CSVLoader]::new

$csvLoader = New-Object CSVLoader 

$metaModel = $csvLoader.load($modelPath)

Write-Output $metaModel.ToString()

