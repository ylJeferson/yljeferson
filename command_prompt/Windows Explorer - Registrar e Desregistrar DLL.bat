@echo off
color 0a

:inicio
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������������� INICIALIZANDO ��������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set DLLPath=%~1
set FileExt=%~x1

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ������������������ VALIDANDO ����������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
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
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ۺ
echo ���  01  ���          Registrar DLL         �ۺ
echo ���  02  ���        Desregistrar DLL        �ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
choice /N /C 12 /M "�� Digite a op��o desejada: "
if %errorlevel% equ 1 set DESREGISTRAR=
if %errorlevel% equ 2 set DESREGISTRAR=-u

regsvr32 "%DLLPath%" %DESREGISTRAR%
pause
exit
