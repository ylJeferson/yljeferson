@echo off
mode 47
color 0a
title Configurar Hotspot

:inicio
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������������� INICIALIZANDO ��������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set nameofnetwork=YAI
set networkpassword=deumaoito

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo �������������� DADOS DO ROTEADOR ������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set /p nameofnetwork=�� SSID (Padr�o: %nameofnetwork%)
set /p networkpassword=�� Senha (Padr�o: %networkpassword%)

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������� CONFIGURANDO O ROTEAMENTO ��������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
netsh wlan set hostednetwork ssid=%nameofnetwork% key=%networkpassword%

:fim
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������� JERBINHO DO WHATERZAPER ���������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
pause
exit