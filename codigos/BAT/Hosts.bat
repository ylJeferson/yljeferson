SET NEWLINE=^& echo.

FIND /C /I "activate.adobe.com" %WINDIR%\system32\drivers\etc\hosts
IF %ERRORLEVEL% NEQ 0 ECHO %NEWLINE%^0.0.0.0                   activate.adobe.com>>%WINDIR%\system32\drivers\etc\hosts

FIND /C /I "practivate.adobe.com" %WINDIR%\system32\drivers\etc\hosts
IF %ERRORLEVEL% NEQ 0 ECHO ^0.0.0.0                   practivate.adobe.com>>%WINDIR%\system32\drivers\etc\hosts

FIND /C /I "lmlicenses.wip4.adobe.com" %WINDIR%\system32\drivers\etc\hosts
IF %ERRORLEVEL% NEQ 0 ECHO ^0.0.0.0                   lmlicenses.wip4.adobe.com>>%WINDIR%\system32\drivers\etc\hosts

FIND /C /I "lm.licenses.adobe.com" %WINDIR%\system32\drivers\etc\hosts
IF %ERRORLEVEL% NEQ 0 ECHO ^0.0.0.0                   lm.licenses.adobe.com>>%WINDIR%\system32\drivers\etc\hosts

FIND /C /I "na1r.services.adobe.com" %WINDIR%\system32\drivers\etc\hosts
IF %ERRORLEVEL% NEQ 0 ECHO ^0.0.0.0                   na1r.services.adobe.com>>%WINDIR%\system32\drivers\etc\hosts

FIND /C /I "hlrcv.stage.adobe.com" %WINDIR%\system32\drivers\etc\hosts
IF %ERRORLEVEL% NEQ 0 ECHO ^0.0.0.0                   hlrcv.stage.adobe.com>>%WINDIR%\system32\drivers\etc\hosts






@echo off
color 0a

set /p IP= Digite a IP: 
set /p HOST= Digite a Nome do Host: 

echo 	%IP%	%HOST%>>%WINDIR%\system32\drivers\etc\hosts

:fim
pause
exit

