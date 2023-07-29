@echo off
color 1a

set /p IP1= Primeira casa do IP: 
set /p IP2= Segunda casa do IP: 
set /p IP3= Terceira casa do IP: 
set /p IP4= Quarta casa do IP: 

:ping
ping %IP1%.%IP2%.%IP3%.%IP4% -n 1
if ErrorLevel 1 goto incrementar
echo %IP1%.%IP2%.%IP3%.%IP4% >> PING_BEM_SUCEDIDO.txt

goto incrementar

:incrementar
set /a IP2=IP2+1

if %IP2%==256 goto fim
goto ping

:fim
pause
exit
