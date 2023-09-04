@echo off
FOR /F "skip=2 tokens=2,*" %%A IN ('reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\TeamViewer" /v "ClientID"') DO set "DFMT=%%B"
set /A DEC=%DFMT%
echo ID:%DEC%.
