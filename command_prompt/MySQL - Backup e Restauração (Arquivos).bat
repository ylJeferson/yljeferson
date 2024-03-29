@echo off
color 0a
set startpath=%~d0%~p0
cd /d %startpath%

set MySQLVersion=MySQL Server 5.7
set MySQLService=MySQL57

:db
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩栩烝烝烝烝烝炳栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩栩 CMD MYSQL 栩栩栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩栩栩樛樛樛樛樛樂栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�

:resetmysqlvariables
set MYSQLOPTION=
set DBNAME=
set DBUSER=
set DBPASS=

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩�
echo 裁桎烝烝炳栩烝烝烝烝烝烝烝烝烝烝烝烝烝烝烝烝栩�
echo 裁�  01  栩�         Backup Database        栩�
echo 裁�  02  栩�        Restore Database        栩�
echo 裁�  03  栩�          Send Command          栩�
echo 裁�  08  栩�             Voltar             栩�
echo 裁�  09  栩�              Sair              栩�
echo 裁桀樛樛樂栩樛樛樛樛樛樛樛樛樛樛樛樛樛樛樛樛栩�
echo 裁栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
choice /N /C 123456789 /M "浜 Digite a op��o desejada: "
if %errorlevel% equ 1 set MYSQLOPTION=mysqlbackup
if %errorlevel% equ 2 set MYSQLOPTION=mysqlrestore
if %errorlevel% equ 3 set MYSQLOPTION=mysqlcommand
if %errorlevel% equ 4 cls && goto db
if %errorlevel% equ 5 cls && goto db
if %errorlevel% equ 6 cls && goto db
if %errorlevel% equ 7 cls && goto db
if %errorlevel% equ 8 set MYSQLOPTION=copyright
if %errorlevel% equ 9 set MYSQLOPTION=fim

choice /N /C SN /M "藩 Deseja prosseguir? [S,N]: "
if %errorlevel% equ 1 goto %MYSQLOPTION%
if %errorlevel% equ 2 set MYSQLOPTION= && goto db

:mysqlbackup
:mysqlrestore
:mysqlcommand
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩栩桎烝烝烝烝栩栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩栩� CONEXAO 栩栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩栩桀樛樛樛樛栩栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
if exist "%programfiles%\MySQL\%MySQLVersion%\bin" (
	set MYSQLSERVER=x64
)

if exist "%programfiles(x86)%\MySQL\%MySQLVersion%\bin" (
	set MYSQLSERVER=x86
)

set /p DBNAME=浜 Digite o nome do banco de dados: 
set /p DBUSER=麺 Digite o usu�rio: 
set /p DBPASS=藩 Digite a senha: 

if not defined DBNAME cls && goto db
if not defined DBUSER cls && goto db
if not defined DBPASS cls && goto db

if %MYSQLOPTION% == mysqlbackup goto domysqlbackup
if %MYSQLOPTION% == mysqlrestore goto domysqlrestore
if %MYSQLOPTION% == mysqlcommand goto domysqlcommand
cls && goto db

:domysqlbackup
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩烝烝烝烝烝烝烝烝烝炳栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩 REALIZANDO BACKUP 栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩樛樛樛樛樛樛樛樛樛樂栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
md backups >> nul
cd backups >> nul

md database >> nul
cd .. >> nul

net stop %MySQLService%
xcopy "%programdata%\MySQL\%MySQL%\Data\%dbname%\" ".\backups\database\%dbname%\" /E /Y /D
copy "%programdata%\MySQL\%MySQL%\Data\ibdata1" ".\backups\database\" /y
copy "%programdata%\MySQL\%MySQL%\Data\ib_logfile0" ".\backups\database\" /y
copy "%programdata%\MySQL\%MySQL%\Data\ib_logfile1" ".\backups\database\" /y
net start %MySQLService%

goto db

:domysqlrestore
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩烝烝烝烝烝烝烝烝烝烝烝炳栩栩栩栩栩�
echo 裁栩栩栩栩栩 RESTAURACAO DO BACKUP 栩栩栩栩栩杠
echo 裁栩栩栩栩栩樛樛樛樛樛樛樛樛樛樛樛樂栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
net stop %MySQLService%
xcopy ".\backups\database\" "%programdata%\MySQL\%MySQL%\Data\" /E /Y /D
net start %MySQLService%

goto db

:domysqlcommand
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩桎烝烝烝烝烝烝烝烝烝烝烝烝栩栩栩栩栩�
echo 裁栩栩栩栩� ENVIAR COMANDO AO BANCO 栩栩栩栩栩�
echo 裁栩栩栩栩桀樛樛樛樛樛樛樛樛樛樛樛樛栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
set /p MYSQLCOMMAND=��� Digite o comando: 

if %MYSQLSERVER% == x64 echo %MYSQLCOMMAND% | "%programfiles%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% -t
if %MYSQLSERVER% == x86 echo %MYSQLCOMMAND% | "%programfiles(x86)%\MySQL\%MySQLVersion%\bin\mysql.exe" -u%dbuser% -p%dbpass% %dbname% -t

choice /N /C SN /M "��� Deseja fazer outro comando? [S,N]: "
if %errorlevel% equ 1 goto domysqlcommand
if %errorlevel% equ 2 goto db
