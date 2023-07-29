@echo off
mode 47
color 0a
title Configurar Hotspot

:inicio
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ INICIALIZANDO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
set nameofnetwork=YAI
set networkpassword=deumaoito

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛ DADOS DO ROTEADOR ÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
set /p nameofnetwork=ษอ SSID (Padrฦo: %nameofnetwork%)
set /p networkpassword=ศอ Senha (Padrฦo: %networkpassword%)

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛ CONFIGURANDO O ROTEAMENTO ÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
netsh wlan set hostednetwork ssid=%nameofnetwork% key=%networkpassword%

:fim
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛ JERBINHO DO WHATERZAPER ÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
pause
exit