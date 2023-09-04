@echo off
mode 48
color 0a
cd /d %~d0%~p0
title Elevate Without Prompt

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ HISTORICO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
echo C:\Windows\system32\cmd.exe

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛ EWP - CAMINHO DO PROGRAMA ÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
echo ษอ Exemplo: %%config%%\Automate\automate.bat
set /p CAMINHO=ศอ Digite o caminho do programa: 

reg add "HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "%CAMINHO%" /t REG_SZ /d "~ RUNASINVOKER"
exit
