@echo off
mode 48
color 0a
title Run As Invoker
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
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ HISTORICO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
echo C:\Windows\system32\cmd.exe

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛßßßßßßßßßßßßßßßßßßßßßßßßßßßÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛ RAI - CAMINHO DO PROGRAMA ÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
echo ÉÍ Exemplo: %%config%%\Automate\automate.bat
set /p "CAMINHO=ÈÍ Digite o caminho do programa: "

reg add "HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "%CAMINHO%" /t REG_SZ /d "~ RUNASINVOKER"

echo ÉÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ»
echo ºÛÛÛÛÛÛÛÛÛÛßßßßßßßßßßßßßßßßßßßßßßßßßÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛ JERBINHO DO WHATERZAPER ÛÛÛÛÛÛÛÛÛÛº
echo ºÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛº
echo ÈÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍÍ¼
timeout /t 10 /nobreak >nul 2>&1
exit
