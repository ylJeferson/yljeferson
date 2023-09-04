@echo off
color 0a

:inicio
echo ЙННННННННННННННННННННННННННННННННННННННННННННН»
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫ INICIALIZANDO ЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo ИНННННННННННННННННННННННННННННННННННННННННННННј
set DLLPath=%~1
set FileExt=%~x1

echo ЙННННННННННННННННННННННННННННННННННННННННННННН»
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЯЯЯЯЯЯЯЯЯЯЯЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫ VALIDANDO ЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЬЬЬЬЬЬЬЬЬЬЬЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo ИНННННННННННННННННННННННННННННННННННННННННННННј
if not defined DLLPath goto arquivo
if %FileExt% neq .dll goto extensao
goto comando

:arquivo
echo Voc€ deve arrastar e soltar a DLL no arquivo de lotes
pause
exit

:extensao
echo Verifique se o arquivo ‚ uma DLL
pause
exit

:comando
echo ЙННННННННННННННННННННННННННННННННННННННННННННН»
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo єЫЫЯЯЯЯЯЯЫЫЫЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЯЫЫє
echo єЫЫ  01  ЫЫЫ          Registrar DLL         ЫЫє
echo єЫЫ  02  ЫЫЫ        Desregistrar DLL        ЫЫє
echo єЫЫЬЬЬЬЬЬЫЫЫЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЫЫє
echo єЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫє
echo ИНННННННННННННННННННННННННННННННННННННННННННННј
choice /N /C 12 /M "ЙН Digite a op‡Жo desejada: "
if %errorlevel% equ 1 set DESREGISTRAR=
if %errorlevel% equ 2 set DESREGISTRAR=-u

regsvr32 "%DLLPath%" %DESREGISTRAR%
pause
exit
