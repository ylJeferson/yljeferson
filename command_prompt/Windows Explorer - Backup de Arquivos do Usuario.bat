@echo off
@color 0a

set /p DISCO_CLIENTE=Digite o disco onde se encontram os arquivos do cliente: 
set /p DISCO_BACKUP=Digite o disco onde deseja salvar os arquivos do cliente: 
set /p USER= Digite o nome do usu rio: 
xcopy "%DISCO_CLIENTE%:\Users\%USER%\*" "%DISCO_BACKUP%:\backups" /EXCLUDE:"%DISCO_CLIENTE%:\Users\%USER%\OneDrive\" /E /Y /D