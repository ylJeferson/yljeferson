@echo off
color 0a

set /p ID=Digite o ID do OneDrive: 
set /p EMAIL=Digite o Email do OneDrive: 
set /p SENHA=Digite a Senha do OneDrive: 

net use R: https://d.docs.live.net/%ID% %SENHA% /user:%EMAIL% /persistent:yes
exit