@echo off
color 0a
set startpath=%~d0%~p0
cd /d %startpath%

set MySQLVersion=MySQL Server 5.7

:db
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ������������������ CMD MYSQL ����������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ

:resetmysqlvariables
set MYSQLOPTION=
set DBNAME=
set DBUSER=
set DBPASS=

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ۺ
echo ���  01  ���         Backup Database        �ۺ
echo ���  02  ���        Restore Database        �ۺ
echo ���  03  ���          Send Command          �ۺ
echo ���  08  ���             Voltar             �ۺ
echo ���  09  ���              Sair              �ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
choice /N /C 123456789 /M "�� Digite a op��o desejada: "
if %errorlevel% equ 1 set MYSQLOPTION=mysqlbackup
if %errorlevel% equ 2 set MYSQLOPTION=mysqlrestore
if %errorlevel% equ 3 set MYSQLOPTION=mysqlcommand
if %errorlevel% equ 4 cls && goto db
if %errorlevel% equ 5 cls && goto db
if %errorlevel% equ 6 cls && goto db
if %errorlevel% equ 7 cls && goto db
if %errorlevel% equ 8 set MYSQLOPTION=copyright
if %errorlevel% equ 9 set MYSQLOPTION=fim

choice /N /C SN /M "�� Deseja prosseguir? [S,N]: "
if %errorlevel% equ 1 goto %MYSQLOPTION%
if %errorlevel% equ 2 set MYSQLOPTION= && goto db

:mysqlbackup
:mysqlrestore
:mysqlcommand
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ������������������� CONEXAO �����������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
if exist "%programfiles%\MySQL\%MySQLVersion%\bin" (
	set MYSQLSERVER=x64
)

if exist "%programfiles(x86)%\MySQL\%MySQLVersion%\bin" (
	set MYSQLSERVER=x86
)

set /p DBNAME=�� Digite o nome do banco de dados: 
set /p DBUSER=�� Digite o usu�rio: 
set /p DBPASS=�� Digite a senha: 

if not defined DBNAME cls && goto db
if not defined DBUSER cls && goto db
if not defined DBPASS cls && goto db

if %MYSQLOPTION% == mysqlbackup goto domysqlbackup
if %MYSQLOPTION% == mysqlrestore goto domysqlrestore
if %MYSQLOPTION% == mysqlcommand goto domysqlcommand
cls && goto db

:domysqlbackup
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo �������������� REALIZANDO BACKUP ������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
if %MYSQLSERVER% == x64 "%programfiles%\MySQL\%MySQLVersion%\bin\mysqldump.exe" -u%dbuser% -p%dbpass% %dbname% > ".\backups\%dbname%.sql"
if %MYSQLSERVER% == x86 "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysqldump.exe" -u%dbuser% -p%dbpass% %dbname% > ".\backups\%dbname%.sql"

goto db

:domysqlrestore
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ������������ RESTAURACAO DO BACKUP ����������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
if %MYSQLSERVER% == x64 "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% -e "create database if not exists %dbname%"
if %MYSQLSERVER% == x86 "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% -e "create database if not exists %dbname%"

if %MYSQLSERVER% == x64 "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% < ".\backups\%dbname%.sql"
if %MYSQLSERVER% == x86 "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% < ".\backups\%dbname%.sql"

goto db

:domysqlcommand
echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������� ENVIAR COMANDO AO BANCO ���������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set /p MYSQLCOMMAND=��� Digite o comando: 

if %MYSQLSERVER% == x64 echo %MYSQLCOMMAND% | "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% -t
if %MYSQLSERVER% == x86 echo %MYSQLCOMMAND% | "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% -t

choice /N /C SN /M "��� Deseja fazer outro comando? [S,N]: "
if %errorlevel% equ 1 goto domysqlcommand
if %errorlevel% equ 2 goto db
