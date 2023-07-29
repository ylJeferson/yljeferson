@echo off

color 0a

REM for /F "usebackq tokens=2 delims==" %%A in (`WMIC PATH Win32_OperatingSystem Get OSArchitecture /VALUE^|FIND "="`) DO SET OSArchitecture=%%A
REM SET OSArchitecture=%i:~0,4%-%i:~4,2%-%i:~6,2%-%i:~8,2%:%i:~10,2%:%i:~12,2%
REM echo %OSArchitecture%

REM for /f "tokens=2 delims==" %%A in ('wmic path Win32_UserAccount where name^="%USERNAME%" Get SID /VALUE ^| FIND "="') do echo %%A

WMIC PATH Win32_ComputerSystem Get DNSHostName /Value | FIND "="
WMIC PATH Win32_BIOS Get Manufacturer /Value | FIND "="
WMIC PATH Win32_ComputerSystemProduct Get Version /Value | FIND "="
WMIC PATH Win32_ComputerSystem Get Model /Value | FIND "="
WMIC PATH Win32_BIOS Get SerialNumber /Value | FIND "="
WMIC PATH Win32_ComputerSystem Get UserName /Value | FIND "="
WMIC PATH Win32_UserAccount where name="%username%" get FullName /value | FIND "="
WMIC PATH Win32_UserAccount where name="%username%" get Description /value | FIND "="
WMIC PATH Win32_OperatingSystem Get Caption /Value | FIND "="
WMIC PATH Win32_OperatingSystem Get Version /Value | FIND "="
WMIC PATH Win32_OperatingSystem Get OSArchitecture /Value | FIND "="
WMIC PATH Win32_OperatingSystem Get InstallDate /Value | FIND "="
WMIC PATH Win32_NetworkAdapterConfiguration where "IPEnabled=true" Get IPAddress /Value | FIND "="
WMIC PATH Win32_NetworkAdapterConfiguration where "IPEnabled=true" Get MACAddress /Value | FIND "="
WMIC PATH Win32_VideoController get CurrentHorizontalResolution,CurrentVerticalResolution

goto fim

												rem =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= mer
												rem =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= mer
												rem =-=-=-=-=- มREA DEDICADA PARA TESTE2 -=-=-=-=-= mer
												rem =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= mer
												rem =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= mer

:teste1
for /F "tokens=2 delims==" %%A in ('wmic os get OSArchitecture /Value ^| FIND "="') do (
set OSArchitecture=%%A
)
IF %OSArchitecture% EQU 32-bit (

echo Teste 1 - 32-bit
goto teste2

) else (

echo Teste 1 - 64-bit
goto teste2

)

:teste2
reg Query "HKLM\Hardware\Description\System\CentralProcessor\0" | find /i "x86" > NUL && set OS=32BIT || set OS=64BIT

if %OS%==32BIT echo Teste 2 - 32-bit
if %OS%==64BIT echo Teste 2 - 64-bit

:fim
echo ษออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛ BY: JERZINHO DO WHATERZAPER AND MELQUICHICLETE ÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออออผ
pause		


