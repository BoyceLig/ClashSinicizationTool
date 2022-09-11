param([string]$buildtfm = 'all')
$ErrorActionPreference = 'Stop'

Write-Host 'dotnet SDK info'
dotnet --info

$net_tfm = 'net6.0-windows'
$configuration = 'Release'
$output_dir = @("$PSScriptRoot\ClashSinicizationToolCLI\bin\$configuration")
$proj_path = @("$PSScriptRoot\ClashSinicizationToolCLI\ClashSinicizationToolCLI.csproj")
$dist_path = "$PSScriptRoot\Dist\$configuration"

$build    = $buildtfm -eq 'all' -or $buildtfm -eq 'app'

function Build-App
{
	Write-Host 'Building .NET App'
	
	for ($i = 0; $i -lt 1; $i++)
	{
		$outdir = "{0}\$net_tfm" -f $output_dir[$i]
		$publishDir = "$outdir\publish"

		Remove-Item $publishDir -Recurse -Force -Confirm:$false -ErrorAction Ignore

		dotnet publish -c $configuration -f $net_tfm $proj_path[$i]
		if ($LASTEXITCODE) { exit $LASTEXITCODE }

		Copy-Item -Path $publishDir\* -Destination $dist_path\ -Recurse -Force
	}
}

if ($build)
{
	if (Test-Path $PSScriptRoot\Dist)
	{
		Remove-Item -Path $PSScriptRoot\Dist -Recurse
	}
	if (-not (Test-Path $PSScriptRoot\Dist))
	{
		New-Item -Path $PSScriptRoot -Name Dist -ItemType Directory > $null
	}
	if (-not (Test-Path $dist_path))
	{
		New-Item -Path $PSScriptRoot\Dist -Name $configuration -ItemType Directory > $null
	}

  Build-App
	Expand-Archive -Path $PSScriptRoot\Node_asar.zip -DestinationPath $dist_path\
}
