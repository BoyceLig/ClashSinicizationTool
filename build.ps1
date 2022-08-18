param([string]$buildtfm = 'all')
$ErrorActionPreference = 'Stop'

Write-Host 'dotnet SDK info'
dotnet --info

$exe = @('Clash Sinicization Tool.exe', 'CLI.exe')
$net_tfm = 'net6.0-windows'
$dllpatcher_tfm = 'net6.0'
$configuration = 'Release'
$output_dir = @("$PSScriptRoot\ClashSinicizationTool\bin\$configuration", "$PSScriptRoot\ClashSinicizationToolCLI\bin\$configuration")
$dllpatcher_dir = "$PSScriptRoot\Build\DotNetDllPathPatcher"
$dllpatcher_exe = "$dllpatcher_dir\bin\$configuration\$dllpatcher_tfm\DotNetDllPathPatcher.exe"
$proj_path = @("$PSScriptRoot\ClashSinicizationTool\ClashSinicizationTool.csproj", "$PSScriptRoot\ClashSinicizationToolCLI\ClashSinicizationToolCLI.csproj")
$dist_path = "$PSScriptRoot\Dist\$configuration"

$build    = $buildtfm -eq 'all' -or $buildtfm -eq 'app'

function Build-App
{
	Write-Host 'Building .NET App'
	
	for ($i = 0; $i -lt 2; $i++)
	{
		$outdir = "{0}\$net_tfm" -f $output_dir[$i]
		$publishDir = "$outdir\publish"
		$exe_path = "$publishDir\{0}" -f $exe[$i]

		Remove-Item $publishDir -Recurse -Force -Confirm:$false -ErrorAction Ignore

		dotnet publish -c $configuration -f $net_tfm $proj_path[$i]
		if ($LASTEXITCODE) { exit $LASTEXITCODE }

		& $dllpatcher_exe $exe_path bin
		if ($LASTEXITCODE) { exit $LASTEXITCODE }

		Copy-Item -Path $publishDir\bin\* -Destination $dist_path\bin -Recurse -Force
		Copy-Item $exe_path -Destination $dist_path
	}
}

dotnet build -c $configuration -f $dllpatcher_tfm $dllpatcher_dir\DotNetDllPathPatcher.csproj
if ($LASTEXITCODE) { exit $LASTEXITCODE }

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
	if (-not (Test-Path $dist_path\bin))
	{
		New-Item -Path $dist_path -Name bin -ItemType Directory > $null
	}
  Build-App
	Expand-Archive -Path $PSScriptRoot\Node_asar.zip -DestinationPath $dist_path\bin
}
