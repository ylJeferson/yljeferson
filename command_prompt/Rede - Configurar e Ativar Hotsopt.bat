@echo off
mode 47
color 0a
title Configurar Hotspot

:inicio
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩烝烝烝烝烝烝烝炳栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩 INICIALIZANDO 栩栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩栩樛樛樛樛樛樛樛樂栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
set nameofnetwork=YAI
set networkpassword=deumaoito

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩烝烝烝烝烝烝烝烝烝炳栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩 DADOS DO ROTEADOR 栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩樛樛樛樛樛樛樛樛樛樂栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
set /p nameofnetwork=浜 SSID (Padr�o: %nameofnetwork%)
set /p networkpassword=藩 Senha (Padr�o: %networkpassword%)

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩烝烝烝烝烝烝烝烝烝烝烝烝烝炳栩栩栩栩�
echo 裁栩栩栩栩 CONFIGURANDO O ROTEAMENTO 栩栩栩栩杠
echo 裁栩栩栩栩樛樛樛樛樛樛樛樛樛樛樛樛樛樂栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
netsh wlan set hostednetwork ssid=%nameofnetwork% key=%networkpassword%
netsh wlan start hostednetwork

:fim
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩桎烝烝烝烝烝烝烝烝烝烝烝烝栩栩栩栩栩�
echo 裁栩栩栩栩� JERBINHO DO WHATERZAPER 栩栩栩栩栩�
echo 裁栩栩栩栩桀樛樛樛樛樛樛樛樛樛樛樛樛栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
pause
exit