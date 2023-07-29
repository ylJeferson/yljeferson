@echo off
color 0a

ipconfig /release
ipconfig /renew
ipconfig /flushdns
ipconfig /registerdns

nbtstat -RR
netsh winsock reset
net localgroup administradores localservice /add
fsutil resource setautoreset true C:\

netsh int ip reset resetlog.txt
netsh winsock reset all
netsh int 6to4 reset all
Netsh int ip reset all
netsh int ipv4 reset all
netsh int ipv6 reset all
netsh int httpstunnel reset all
netsh int isatap reset all
netsh int portproxy reset all
netsh int tcp reset all
netsh int teredo reset all
netsh int ip reset
netsh winsock reset

reg add HKLM\Software\Microsoft\Windows\CurrentVersion\SharedAccess /v EnableRebootPersistConnection /d 2 /f
reg add HKLM\SYSTEM\CurrentControlSet\Services\ICSSVC /v Start /t REG_DWORD /d 2 /f
sc config icssvc start= auto

shutdown -r -t 00