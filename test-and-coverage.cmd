@echo off

where reportgenerator 1>nul 2>nul
if "%ERRORLEVEL%" NEQ "0" echo reportgenerator not found. Run 'dotnet tool install -g dotnet-reportgenerator-globaltool' && goto :eof

echo [ Remove old results ]
for /f %%i in ('dir /a-d /b /s coverage.cobertura.xml 2^>nul') do del "%%i"

echo [ Build ]
dotnet build Source\Lighting.sln
if "%ERRORLEVEL%" NEQ "0" echo Failed with errorlevel %ERRORLEVEL% &&  goto :eof

echo [ Test and Collect ]
dotnet test --no-build --collect:"XPlat Code Coverage" Source\Lighting.sln
if "%ERRORLEVEL%" NEQ "0" echo Failed with errorlevel %ERRORLEVEL% &&  goto :eof

echo [ Generate report ]
SET Report=
for /f %%i in ('dir /a-d /b /s coverage.cobertura.xml') do SET Report=%%i
echo %Report%

if not exist obj md obj
reportgenerator -reports:"%Report%" -targetdir:"obj\coveragereport" -reporttypes:Html
if "%ERRORLEVEL%" NEQ "0" echo Failed with errorlevel %ERRORLEVEL% &&  goto :eof

start obj\coveragereport\index.html

echo [ Done ]
