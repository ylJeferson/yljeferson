@echo off
color 0a

title Adicionar credenciais no windows

:inicio
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������������� INICIALIZANDO ��������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set target=%userdomain%
set user=%username%@%userdomain%
set pass=abc123

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ������������� DADOS DA CREDENCIAL �����������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set /p target=�� Dom�nio (Padr�o: %target%) 
set /p user=�� Usu�rio (Padr�o: %user%) 
set /p pass=�� Senha (Padr�o: %pass%) 

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������������� ADICIONANDO ���������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
cmdkey /add:%target% /user:%user% /pass:%pass%

choice /N /C SN /M "��� Deseja fazer outro comando? [S,N]: "
if %ERRORLEVEL% equ 1 goto inicio
if %ERRORLEVEL% equ 2 goto fim

:fim
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������� JERBINHO DO WHATERZAPER ���������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
pause
exit