@echo off
color 0a

:inicio
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩烝烝烝烝烝烝烝炳栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩 INICIALIZANDO 栩栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩栩樛樛樛樛樛樛樛樂栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
set DLLPath=%~1
set FileExt=%~x1

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩栩烝烝烝烝烝炳栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩栩 VALIDANDO 栩栩栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩栩栩樛樛樛樛樛樂栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
if not defined DLLPath goto arquivo
if %FileExt% neq .dll goto extensao
goto comando

:arquivo
echo Voc� deve arrastar e soltar a DLL no arquivo de lotes
pause
exit

:extensao
echo Verifique se o arquivo � uma DLL
pause
exit

:comando
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩�
echo 裁桎烝烝炳栩烝烝烝烝烝烝烝烝烝烝烝烝烝烝烝烝栩�
echo 裁�  01  栩�          Registrar DLL         栩�
echo 裁�  02  栩�        Desregistrar DLL        栩�
echo 裁桀樛樛樂栩樛樛樛樛樛樛樛樛樛樛樛樛樛樛樛樛栩�
echo 裁栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
choice /N /C 12 /M "浜 Digite a op��o desejada: "
if %errorlevel% equ 1 set DESREGISTRAR=
if %errorlevel% equ 2 set DESREGISTRAR=-u

regsvr32 "%DLLPath%" %DESREGISTRAR%
pause
exit
