for %%S in (%Ports%) do (
	reg query "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Ports" /v "\\SRV-AD2016\%%S"
	if errorlevel 1 (
		REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Ports" /v "\\SRV-AD2016\%%S" /t REG_SZ /f
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
for /f "tokens=4 delims= " %%P in ('dir ".\drivers\impressoras\Brother" ^| findstr /I /C:"DN"') do for /f "tokens=4 delims= " %%D in ('dir ".\drivers\impressoras\Brother\%%P\%system%\%os%\" ^| findstr /I /C:".inf"') do if not exist "C:\Windows\System32\DriverStore\FileRepository\%%D*" pnputil -i -a ".\drivers\impressoras\Brother\%%P\%SYSTEM%\%OS%\%%D"
