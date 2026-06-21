@echo off
mode 48
color 0a
title Mapear OneDrive
reg add "HKEY_CURRENT_USER\Console" /v "WindowPosition" /t "REG_DWORD" /d "0" /f 1>nul 2>nul

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛßßßßßßßßßßßßßßßÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ INICIALIZANDO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
set "pasta_inicial=%~dp0"
cd /d "%pasta_inicial%"

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛßßßßßßßßßßßÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ VARIµVEIS ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
set /p "ID=Digite o ID do OneDrive: "
set /p "EMAIL=Digite o Email do OneDrive: "
set /p "SENHA=Digite a Senha do OneDrive: "

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛßßßßßßßßßßßßßßßßßßßÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛ MAPEANDO ONEDRIVE ÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
net use R: https://d.docs.live.net/%ID% %SENHA% /user:%EMAIL% /persistent:yes

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛÛßßßßßßßßßßßßßßßßßßßßßßßßßÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛ JERBINHO DO WHATERZAPER ÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
timeout /t 10 /nobreak >nul 2>&1
exit
