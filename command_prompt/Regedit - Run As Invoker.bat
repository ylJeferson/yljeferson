@echo off
mode 48
color 0a
cd /d %~d0%~p0
title Elevate Without Prompt

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩栩烝烝烝烝烝炳栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩栩 HISTORICO 栩栩栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩栩栩樛樛樛樛樛樂栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
echo C:\Windows\system32\cmd.exe

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩烝烝烝烝烝烝烝烝烝烝烝烝烝炳栩栩栩栩�
echo 裁栩栩栩栩 EWP - CAMINHO DO PROGRAMA 栩栩栩栩杠
echo 裁栩栩栩栩樛樛樛樛樛樛樛樛樛樛樛樛樛樂栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
echo 浜 Exemplo: %%config%%\Automate\automate.bat
set /p CAMINHO=藩 Digite o caminho do programa: 

reg add "HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "%CAMINHO%" /t REG_SZ /d "~ RUNASINVOKER"
exit
