@echo off
color 0a

echo Command 00: %~1
echo "Utiliza os parametros colocados em atalhos pode usar de %%0 a %%9, se utilizar aspas ~ comando retorna a string sem as aspas"
echo.

echo Command 01: %CmdCmdLine%
echo "Retonar a linha completa de comando que foi passado para o cmd"
echo.

echo Command 02: %*
echo "Retorna todos os parametros embutidos no atalho"
echo.

echo Command 03: %~d0
echo "Retorna a letra do Disco onde o comando foi executado"
echo.

echo Command 04: %~p0
echo "Retorna o caminho de onde o comando foi executado (sem a letra do disco)"
echo.

echo Command 05: %~n0
echo "Retorna o nome do arquivo (sem a extensão)"
echo.

echo Command 06: %~x0
echo "Retorna a extensão do arquivo"
echo.

echo Command 07: %~f0
echo "Retorna o caminho completo com o nome do arquivo"
echo.

echo Command 08: %ALLUSERSPROFILE%
echo ""
echo.

echo Command 09: %APPDATA%
echo ""
echo.

echo Command 10: %CD%
echo ""
echo.

echo Command 11: %ClientName%
echo ""
echo.

echo Command 12: %CMDEXTVERSION%
echo ""
echo.

echo Command 13: %CommonProgramFiles%
echo ""
echo.

echo Command 14: %COMMONPROGRAMFILES(x86)%
echo ""
echo.

echo Command 15: %COMPUTERNAME%
echo ""
echo.

echo Command 16: %COMSPEC%
echo ""
echo.

echo Command 17: %DATE%
echo Command 17: %DATE:~0,6%%DATE:~8,2%
echo ""
echo.

echo Command 18: %ERRORLEVEL%
echo ""
echo.

echo Command 19: %FPS_BROWSER_APP_PROFILE_STRING%
echo Command 19: %FPS_BROWSER_USER_PROFILE_STRING%
echo ""
echo.

echo Command 20: %HighestNumaNodeNumber%
echo ""
echo.

echo Command 21: %HOMEDRIVE%
echo ""
echo.

echo Command 22: %HOMEPATH%
echo ""
echo.

echo Command 23: %HOMESHARE%
echo ""
echo.

echo Command 24: %LOCALAPPDATA%
echo ""
echo.

echo Command 25: %LOGONSERVER%
echo ""
echo.

echo Command 26: %NUMBER_OF_PROCESSORS%
echo ""
echo.

echo Command 27: %OneDrive%
echo ""
echo.

echo Command 28: %OS%
echo ""
echo.

echo Command 29: %PATH%
echo ""
echo.

echo Command 30: %PATHEXT%
echo ""
echo.

echo Command 31: %PROCESSOR_ARCHITECTURE%
echo ""
echo.

echo Command 32: %PROCESSOR_ARCHITEW6432%
echo ""
echo.

echo Command 33: %PROCESSOR_IDENTIFIER%
echo ""
echo.

echo Command 34: %PROCESSOR_LEVEL%
echo ""
echo.

echo Command 35: %PROCESSOR_REVISION%
echo ""
echo.

echo Command 36: %ProgramData%
echo ""
echo.

echo Command 37: %ProgramFiles%
echo ""
echo.

echo Command 38: %ProgramFiles(x86)%
echo ""
echo.

echo Command 39: %ProgramW6432%
echo ""
echo.

echo Command 40: %PROMPT%
echo ""
echo.

echo Command 41: %PSModulePath%
echo ""
echo.

echo Command 42: %Public%
echo ""
echo.

echo Command 43: %RANDOM%
echo ""
echo.

echo Command 44: %SessionName%
echo ""
echo.

echo Command 45: %SYSTEMDRIVE%
echo ""
echo.

echo Command 46: %SYSTEMROOT%
echo ""
echo.

echo Command 47: %TEMP%
echo Command 47: %TMP%
echo ""
echo.

echo Command 48: %TIME%
echo ""
echo.

echo Command 49: %UserDnsDomain%
echo ""
echo.

echo Command 50: %USERDOMAIN%
echo ""
echo.

echo Command 51: %USERDOMAIN_roamingprofile%
echo ""
echo.

echo Command 52: %USERNAME%
echo ""
echo.

echo Command 53: %USERPROFILE%
echo ""
echo.

echo Command 54: %WINDIR%
echo ""
echo.

echo Command 55: %__APPDIR__%
echo "Retorna o caminho do diretório para o aplicativo atual .exe, finalizado com uma barra invertida à direita (global)"
echo.

echo Command 56: %__CD__%
echo "Retorna o diretório atual, finalizado com uma barra invertida à direita (global)"
echo.

echo Command 57: %=C:%
echo "Retorna o O diretório atual da unidade C:"
echo.

echo Command 58: %=D:%
echo "Retorna o diretório atual da unidade D: se a unidade D: foi acessada na sessão CMD atual"
echo.

echo Command 59: %DPATH%
echo "Relacionado ao comando DPATH (obsoleto)"
echo.

echo Command 60: %=ExitCode%
echo "Retorna o código de saída mais recente retornado por um comando externo, como CMD /C EXIT n , convertido em hexadecimal"
echo.

echo Command 61: %=ExitCodeAscii%
echo "Retorna o código de saída mais recente retornado por um comando externo, como ASCII (os valores de 0 a 32 não são exibidos porque mapeiam para códigos de controle ASCII)"
echo.

echo Command 62: %FIRMWARE_TYPE%
echo "Retorna o tipo de inicialização do sistema: Legacy , UEFI, Não implementado, Desconhecido Windows 8/2012"
echo.

echo Command 63: %KEYS%
echo "Relacionado ao comando KEYS (obsoleto)"
echo.

echo Command 64: %__COMPAT_LAYER%
echo "Defina o ExecutionLevel para RunAsInvoker (asInvoker), RunAsHighest (highestAvailable) ou RunAsAdmin (requireAdministrator) para mais ver elevação e Q286705 / Application Compatibility Toolkit para outras Camadas de Compatibilidade (cores, temas etc)"
echo.

pause