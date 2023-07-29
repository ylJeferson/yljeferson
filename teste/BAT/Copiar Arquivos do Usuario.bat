@echo off
@color 0a

set /p OLD_USER= Digite o nome do usu rio antigo: 
set /p NEW_USER= Digite o nome do novo usu rio: 
XCOPY "C:\Users\%OLD_USER%\*" "C:\Users\%NEW_USER%\" /EXCLUDE:"C:\Users\%OLD_USER%\OneDrive" /E /Y /D