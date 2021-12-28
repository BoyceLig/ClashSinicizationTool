param([string]$buildtfm = 'all')
$ErrorActionPreference = 'Stop'

Write-Host 'dotnet SDK info'
dotnet --info

$exe = 'Clash Sinicization Tool.exe'
$net_tfm = 'net6.0-windows'
$dllpatcher_tfm = 'net6.0'
$configuration = 'Release'
$output_dir = "$PSScriptRoot\ClashSinicizationTool\bin\$configuration"
$dllpatcher_dir = "$PSScriptRoot\Build\DotNetDllPathPatcher"
$dllpatcher_exe = "$dllpatcher_dir\bin\$configuration\$dllpatcher_tfm\DotNetDllPathPatcher.exe"
$proj_path = "$PSScriptRoot\ClashSinicizationTool\ClashSinicizationTool.csproj"

$build    = $buildtfm -eq 'all' -or $buildtfm -eq 'app'
function Build-App
{
	Write-Host 'Building .NET App'
	
	$outdir = "$output_dir\$net_tfm"
	$publishDir = "$outdir\publish"

	Remove-Item $publishDir -Recurse -Force -Confirm:$false -ErrorAction Ignore
	
	dotnet publish -c $configuration -f $net_tfm $proj_path
	if ($LASTEXITCODE) { exit $LASTEXITCODE }

	& $dllpatcher_exe $publishDir\$exe bin
	if ($LASTEXITCODE) { exit $LASTEXITCODE }
}

function Build-SelfContained
{
	param([string]$rid)

	Write-Host "Building .NET App SelfContained $rid"

	$outdir = "$output_dir\$net_tfm\$rid"
	$publishDir = "$outdir\publish"

	Remove-Item $publishDir -Recurse -Force -Confirm:$false -ErrorAction Ignore

	dotnet publish -c $configuration -f $net_tfm -r $rid --self-contained true $proj_path
	if ($LASTEXITCODE) { exit $LASTEXITCODE }

	& $dllpatcher_exe $publishDir\$exe bin
	if ($LASTEXITCODE) { exit $LASTEXITCODE }
}

dotnet build -c $configuration -f $dllpatcher_tfm $dllpatcher_dir\DotNetDllPathPatcher.csproj
if ($LASTEXITCODE) { exit $LASTEXITCODE }

if ($build)
{
    Build-App
	$outdir = "$output_dir\$net_tfm"
	$publishDir = "$outdir\publish"
	Expand-Archive -Path $PSScriptRoot\Node_asar.zip -DestinationPath $publishDir\bin
}
