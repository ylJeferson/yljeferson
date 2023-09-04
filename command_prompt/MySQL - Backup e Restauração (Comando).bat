@echo off
color 0a
set startpath=%~d0%~p0
cd /d %startpath%

set MySQLVersion=MySQL Server 5.7

:db
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ CMD MYSQL ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ

:resetmysqlvariables
set MYSQLOPTION=
set DBNAME=
set DBUSER=
set DBPASS=

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛ฿฿฿฿฿฿ÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛบ
echo บÛÛ  01  ÛÛÛ         Backup Database        ÛÛบ
echo บÛÛ  02  ÛÛÛ        Restore Database        ÛÛบ
echo บÛÛ  03  ÛÛÛ          Send Command          ÛÛบ
echo บÛÛ  08  ÛÛÛ             Voltar             ÛÛบ
echo บÛÛ  09  ÛÛÛ              Sair              ÛÛบ
echo บÛÛÜÜÜÜÜÜÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
choice /N /C 123456789 /M "ษอ Digite a opฦo desejada: "
if %errorlevel% equ 1 set MYSQLOPTION=mysqlbackup
if %errorlevel% equ 2 set MYSQLOPTION=mysqlrestore
if %errorlevel% equ 3 set MYSQLOPTION=mysqlcommand
if %errorlevel% equ 4 cls && goto db
if %errorlevel% equ 5 cls && goto db
if %errorlevel% equ 6 cls && goto db
if %errorlevel% equ 7 cls && goto db
if %errorlevel% equ 8 set MYSQLOPTION=copyright
if %errorlevel% equ 9 set MYSQLOPTION=fim

choice /N /C SN /M "ศอ Deseja prosseguir? [S,N]: "
if %errorlevel% equ 1 goto %MYSQLOPTION%
if %errorlevel% equ 2 set MYSQLOPTION= && goto db

:mysqlbackup
:mysqlrestore
:mysqlcommand
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ CONEXAO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
if exist "%programfiles%\MySQL\%MySQLVersion%\bin" (
	set MYSQLSERVER=x64
)

if exist "%programfiles(x86)%\MySQL\%MySQLVersion%\bin" (
	set MYSQLSERVER=x86
)

set /p DBNAME=ษอ Digite o nome do banco de dados: 
set /p DBUSER=ฬอ Digite o usu rio: 
set /p DBPASS=ศอ Digite a senha: 

if not defined DBNAME cls && goto db
if not defined DBUSER cls && goto db
if not defined DBPASS cls && goto db

if %MYSQLOPTION% == mysqlbackup goto domysqlbackup
if %MYSQLOPTION% == mysqlrestore goto domysqlrestore
if %MYSQLOPTION% == mysqlcommand goto domysqlcommand
cls && goto db

:domysqlbackup
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛ REALIZANDO BACKUP ÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
if %MYSQLSERVER% == x64 "%programfiles%\MySQL\%MySQLVersion%\bin\mysqldump.exe" -u%dbuser% -p%dbpass% %dbname% > ".\backups\%dbname%.sql"
if %MYSQLSERVER% == x86 "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysqldump.exe" -u%dbuser% -p%dbpass% %dbname% > ".\backups\%dbname%.sql"

goto db

:domysqlrestore
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛ RESTAURACAO DO BACKUP ÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
if %MYSQLSERVER% == x64 "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% -e "create database if not exists %dbname%"
if %MYSQLSERVER% == x86 "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% -e "create database if not exists %dbname%"

if %MYSQLSERVER% == x64 "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% < ".\backups\%dbname%.sql"
if %MYSQLSERVER% == x86 "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% < ".\backups\%dbname%.sql"

goto db

:domysqlcommand
echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛ ENVIAR COMANDO AO BANCO ÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
set /p MYSQLCOMMAND=ฏฏฏ Digite o comando: 

if %MYSQLSERVER% == x64 echo %MYSQLCOMMAND% | "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% -t
if %MYSQLSERVER% == x86 echo %MYSQLCOMMAND% | "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% -t

choice /N /C SN /M "ฏฏฏ Deseja fazer outro comando? [S,N]: "
if %errorlevel% equ 1 goto domysqlcommand
if %errorlevel% equ 2 goto db
