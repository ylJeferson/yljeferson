@echo off
mode 48
color 0a
cd /d %~d0%~p0
title Elevate Without Prompt

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ������������������ HISTORICO ����������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
echo C:\Windows\system32\cmd.exe

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������� EWP - CAMINHO DO PROGRAMA ��������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
echo �� Exemplo: %%config%%\Automate\automate.bat
set /p CAMINHO=�� Digite o caminho do programa: 

reg add "HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "%CAMINHO%" /t REG_SZ /d "~ RUNASINVOKER"
exit
