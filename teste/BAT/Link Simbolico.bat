@echo off
color 1a

set /p PASTA1= Digite o caminho para criar uma nova pasta: 
set /p PASTA2= Digite o caminho da pasta a ser sincronizada: 

mklink /d "%PASTA1%" "%PASTA2%"

:fim
pause
exit