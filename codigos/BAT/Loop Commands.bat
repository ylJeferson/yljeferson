@echo off
@color 0a

:Variaveis
set MAQUINAS=c:\config\temp\maquinas.txt

setlocal EnableDelayedExpansion
(
	echo 192.168.0.205
	echo 192.168.0.206
)>%MAQUINAS%

for /f "tokens=*" %%A in (%MAQUINAS%) do ping -n 1 %%A
del %MAQUINAS%
pause