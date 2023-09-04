set DOMINIO=YAI
set PORTS=IMPRESSORA1 IMPRESSORA2 IMPRESSORA3

ver | findstr /i "5\.1\." > nul
if %errorlevel% equ 0 set SYSTEM=xp

ver | findstr /i "6\.0\." > nul
if %errorlevel% equ 0 set SYSTEM=vista

ver | findstr /i "6\.1\." > nul
if %errorlevel% equ 0 set SYSTEM=seven

ver | findstr /i "10\.0\." > nul
if %errorlevel% equ 0 set SYSTEM=10

reg query "HKLM\Hardware\Description\system\CentralProcessor\0" | find /i "x86" > nul && set OS=32BIT || set OS=64BIT

for %%S in (%PORTS%) do (
	reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Ports" /v "\\%DOMINIO%\%%S"
	if errorlevel 1 (
		REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Ports" /v "\\%DOMINIO%\%%S" /t REG_SZ /f
		set SPOOLER=Reiniciar
	)
)

if %SPOOLER%==Reiniciar net stop spooler
if %SPOOLER%==Reiniciar net start spooler

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛÛÛÛßßßßßßßßßßßßßßßßßßßßßÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛ ADICIONANDO DRIVERS ÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
for /f "tokens=4 delims= " %%P in ('dir ".\drivers\impressoras\Brother" ^| findstr /I /C:"DN"') do for /f "tokens=4 delims= " %%D in ('dir ".\drivers\impressoras\Brother\%%P\%SYSTEM%\%OS%\" ^| findstr /I /C:".inf"') do if not exist "C:\Windows\System32\DriverStore\FileRepository\%%D*" pnputil -i -a ".\drivers\impressoras\Brother\%%P\%SYSTEM%\%OS%\%%D"
