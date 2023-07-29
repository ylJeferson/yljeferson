@echo off
@color 0a

cd /d %~d0%~p0

reg Query "HKLM\Hardware\Description\system\CentralProcessor\0" | find /i "x86" > NUL && set OS=32BIT || set OS=64BIT

ver | findstr /i "5\.1\." > nul
if %ERRORLEVEL% equ 0 set SYSTEM=xp

ver | findstr /i "6\.0\." > nul
if %ERRORLEVEL% equ 0 set SYSTEM=vista

ver | findstr /i "6\.1\." > nul
if %ERRORLEVEL% equ 0 set SYSTEM=seven

ver | findstr /i "10\.0\." > nul
if %ERRORLEVEL% equ 0 set SYSTEM=10


net use J: "\\SRV-AD2016\Aplicativos\config"
for /f "tokens=4 delims= " %%P in ('dir "J:\drivers\impressoras\Brother" ^| findstr /I /C:"DN"') do for /f "tokens=4 delims= " %%D in ('dir "J:\drivers\impressoras\Brother\%%P\%SYSTEM%\%OS%\" ^| findstr /I /C:".inf"') do if not exist "C:\Windows\System32\DriverStore\FileRepository\%%D*" pnputil -i -a "J:\drivers\impressoras\Brother\%%P\%SYSTEM%\%OS%\%%D"
for /f "tokens=4 delims= " %%P in ('dir "J:\drivers\impressoras\HP"') do for /f "tokens=4 delims= " %%D in ('dir "J:\drivers\impressoras\HP\%%P\%SYSTEM%\%OS%\" ^| findstr /I /C:".inf"') do if not exist "C:\Windows\System32\DriverStore\FileRepository\%%D*" pnputil -i -a "J:\drivers\impressoras\HP\%%P\%SYSTEM%\%OS%\%%D"