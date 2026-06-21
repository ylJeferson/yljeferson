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
echo "Retorna o nome do arquivo (sem a extens∆o)"
echo.

echo Command 06: %~x0
echo "Retorna a extens∆o do arquivo"
echo.

echo Command 07: %~f0
echo "Retorna o caminho completo com o nome do arquivo"
echo.

echo Command 08: %ALLUSERSPROFILE%
echo "Retorna o caminho do perfil comum de todos os usuarios"
echo.

echo Command 09: %APPDATA%
echo "Retorna o caminho da pasta AppData Roaming do usuario atual"
echo.

echo Command 10: %CD%
echo "Retorna a pasta atual onde o comando esta sendo executado"
echo.

echo Command 11: %ClientName%
echo "Retorna o nome do cliente em sessoes remotas, como RDP"
echo.

echo Command 12: %CMDEXTVERSION%
echo "Retorna a versao das extensoes de comando do CMD"
echo.

echo Command 13: %CommonProgramFiles%
echo "Retorna o caminho da pasta Common Files dos programas"
echo.

echo Command 14: %COMMONPROGRAMFILES(x86)%
echo "Retorna o caminho da pasta Common Files dos programas 32 bits em Windows 64 bits"
echo.

echo Command 15: %COMPUTERNAME%
echo "Retorna o nome do computador"
echo.

echo Command 16: %COMSPEC%
echo "Retorna o caminho completo do interpretador de comandos cmd.exe"
echo.

echo Command 17: %DATE%
echo Command 17: %DATE:~0,6%%DATE:~8,2%
echo "Retorna a data atual e tambem um recorte da data em formato reduzido"
echo.

echo Command 18: %ERRORLEVEL%
echo "Retorna o codigo de saida do ultimo comando executado"
echo.

echo Command 19: %FPS_BROWSER_APP_PROFILE_STRING%
echo Command 19: %FPS_BROWSER_USER_PROFILE_STRING%
echo "Retorna as strings de perfil usadas pelo Microsoft Office/Browser quando existirem"
echo.

echo Command 20: %HighestNumaNodeNumber%
echo "Retorna o maior indice NUMA disponivel no sistema"
echo.

echo Command 21: %HOMEDRIVE%
echo "Retorna a letra da unidade da pasta base do usuario"
echo.

echo Command 22: %HOMEPATH%
echo "Retorna o caminho da pasta base do usuario sem a letra da unidade"
echo.

echo Command 23: %HOMESHARE%
echo "Retorna o compartilhamento de rede da pasta base do usuario quando configurado"
echo.

echo Command 24: %LOCALAPPDATA%
echo "Retorna o caminho da pasta AppData Local do usuario atual"
echo.

echo Command 25: %LOGONSERVER%
echo "Retorna o servidor de logon usado pelo usuario"
echo.

echo Command 26: %NUMBER_OF_PROCESSORS%
echo "Retorna a quantidade de processadores logicos disponiveis"
echo.

echo Command 27: %OneDrive%
echo "Retorna o caminho da pasta OneDrive do usuario quando configurado"
echo.

echo Command 28: %OS%
echo "Retorna o tipo de sistema operacional, normalmente Windows_NT"
echo.

echo Command 29: %PATH%
echo "Retorna a lista de caminhos usados para localizar comandos e programas"
echo.

echo Command 30: %PATHEXT%
echo "Retorna a lista de extensoes executaveis reconhecidas pelo CMD"
echo.

echo Command 31: %PROCESSOR_ARCHITECTURE%
echo "Retorna a arquitetura do processo atual do CMD"
echo.

echo Command 32: %PROCESSOR_ARCHITEW6432%
echo "Retorna a arquitetura nativa do Windows quando o CMD 32 bits roda em Windows 64 bits"
echo.

echo Command 33: %PROCESSOR_IDENTIFIER%
echo "Retorna a identificacao completa do processador"
echo.

echo Command 34: %PROCESSOR_LEVEL%
echo "Retorna o nivel/familia do processador"
echo.

echo Command 35: %PROCESSOR_REVISION%
echo "Retorna a revisao do processador"
echo.

echo Command 36: %ProgramData%
echo "Retorna o caminho da pasta ProgramData"
echo.

echo Command 37: %ProgramFiles%
echo "Retorna o caminho da pasta Program Files usada pelo processo atual"
echo.

echo Command 38: %ProgramFiles(x86)%
echo "Retorna o caminho da pasta Program Files (x86) em Windows 64 bits"
echo.

echo Command 39: %ProgramW6432%
echo "Retorna o caminho da pasta Program Files nativa de 64 bits"
echo.

echo Command 40: %PROMPT%
echo "Retorna o formato atual do prompt do CMD"
echo.

echo Command 41: %PSModulePath%
echo "Retorna os caminhos onde o PowerShell procura modulos"
echo.

echo Command 42: %Public%
echo "Retorna o caminho do perfil publico de usuarios"
echo.

echo Command 43: %RANDOM%
echo "Retorna um numero aleatorio entre 0 e 32767"
echo.

echo Command 44: %SessionName%
echo "Retorna o nome da sessao atual, como Console ou RDP-Tcp"
echo.

echo Command 45: %SYSTEMDRIVE%
echo "Retorna a unidade onde o Windows esta instalado"
echo.

echo Command 46: %SYSTEMROOT%
echo "Retorna o caminho da pasta do Windows"
echo.

echo Command 47: %TEMP%
echo Command 47: %TMP%
echo "Retorna os caminhos das pastas temporarias TEMP e TMP"
echo.

echo Command 48: %TIME%
echo "Retorna a hora atual do sistema"
echo.

echo Command 49: %UserDnsDomain%
echo "Retorna o dominio DNS do usuario quando conectado ao Active Directory"
echo.

echo Command 50: %USERDOMAIN%
echo "Retorna o dominio ou nome do computador associado ao usuario"
echo.

echo Command 51: %USERDOMAIN_roamingprofile%
echo "Retorna o dominio usado pelo perfil movel do usuario quando configurado"
echo.

echo Command 52: %USERNAME%
echo "Retorna o nome do usuario atual"
echo.

echo Command 53: %USERPROFILE%
echo "Retorna o caminho do perfil do usuario atual"
echo.

echo Command 54: %WINDIR%
echo "Retorna o caminho da pasta do Windows"
echo.

echo Command 55: %__APPDIR__%
echo "Retorna o caminho do diret¢rio para o aplicativo atual .exe, finalizado com uma barra invertida Ö direita (global)"
echo.

echo Command 56: %__CD__%
echo "Retorna o diret¢rio atual, finalizado com uma barra invertida Ö direita (global)"
echo.

echo Command 57: %=C:%
echo "Retorna o O diret¢rio atual da unidade C:"
echo.

echo Command 58: %=D:%
echo "Retorna o diret¢rio atual da unidade D: se a unidade D: foi acessada na sess∆o CMD atual"
echo.

echo Command 59: %DPATH%
echo "Relacionado ao comando DPATH (obsoleto)"
echo.

echo Command 60: %=ExitCode%
echo "Retorna o c¢digo de sa°da mais recente retornado por um comando externo, como CMD /C EXIT n, convertido em hexadecimal"
echo.

echo Command 61: %=ExitCodeAscii%
echo "Retorna o c¢digo de sa°da mais recente retornado por um comando externo, como ASCII (os valores de 0 a 32 n∆o s∆o exibidos porque mapeiam para c¢digos de controle ASCII)"
echo.

echo Command 62: %FIRMWARE_TYPE%
echo "Retorna o tipo de inicializaá∆o do sistema: Legacy, UEFI, N∆o implementado, Desconhecido Windows 8/2012"
echo.

echo Command 63: %KEYS%
echo "Relacionado ao comando KEYS (obsoleto)"
echo.

echo Command 64: %__COMPAT_LAYER%
echo "Defina o ExecutionLevel para RunAsInvoker (asInvoker), RunAsHighest (highestAvailable) ou RunAsAdmin (requireAdministrator) para mais ver elevaá∆o e Q286705 / Application Compatibility Toolkit para outras Camadas de Compatibilidade (cores, temas etc)"
echo.

pause