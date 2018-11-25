<#
.SYNOPSIS
   <A brief description of the script>
.DESCRIPTION
   <A detailed description of the script>
.PARAMETER <paramName>
   <Description of script parameter>
.EXAMPLE
   <An example of using the script>
#>

Param
(
	[string] $sourcePath,
	[switch] $buildSolution = $false
)

$IISExpress = "$(${env:ProgramFiles(x86)})\IIS Express\iisexpress.exe";
$DotNet = 'dotnet';
$DotNetRunArgumentList = 'run';
If (-Not (Test-Path $IISExpress))
{
	$IISExpress = "$($env:ProgramFiles)\IIS Express\iisexpress.exe";
}

if($buildSolution)
{
	$DotNetBuildArgumentList = 'build';
	$MsBuild = "$(${env:ProgramFiles(x86)})\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\bin\amd64\MSBuild.exe";

	Start-Process -FilePath $MsBuild -ArgumentList "/t:rebuild AdvisorService.sln" -WorkingDirectory "$($sourcePath)\AdvisorService\Code" -WindowStyle Hidden | Out-Null;
	Start-Process -FilePath $MsBuild -ArgumentList "/t:rebuild AccountDataService.sln" -WorkingDirectory "$($sourcePath)\AccountDataService\Code" -WindowStyle Hidden | Out-Null;
	Start-Process -FilePath $MsBuild -ArgumentList "/t:rebuild OAService.sln" -WorkingDirectory "$($sourcePath)\OAService\Code" -WindowStyle Hidden | Out-Null;
	Start-Process -FilePath $MsBuild -ArgumentList "/t:rebuild OAService.sln" -WorkingDirectory "$($sourcePath)\NanService\Code" -WindowStyle Hidden | Out-Null;
}

Start-Process -FilePath $IISExpress -ArgumentList "/path:$($sourcePath)\AdvisorService\Code\AdvisorService /port:17776" -WindowStyle Minimized;
Start-Process -FilePath $IISExpress -ArgumentList "/path:$($sourcePath)\AccountDataService\Code\AccountData.Service /port:17775" -WindowStyle Minimized;
Start-Process -FilePath $IISExpress -ArgumentList "/path:$($sourcePath)\OAService\Code\OA.Service /port:17777" -WindowStyle Minimized;
Start-Process -FilePath $IISExpress -ArgumentList "/path:$($sourcePath)\NanService\Code\Nan.Service /port:17778" -WindowStyle Minimized;
Start-Process -FilePath $DotNet -ArgumentList "$($DotNetRunArgumentList)" -WorkingDirectory "$($sourcePath)\ManagerReportingService\Code\ManagerReporting.Service" -WindowStyle Minimized;
Start-Process -FilePath $DotNet -ArgumentList "$($DotNetRunArgumentList)" -WorkingDirectory "$($sourcePath)\OAReportService\Code\OAReport.Service" -WindowStyle Minimized;
Start-Process -FilePath $DotNet -ArgumentList "$($DotNetRunArgumentList)" -WorkingDirectory "$($sourcePath)\SwpReportService\Code\SwpReport.Service" -WindowStyle Minimized;