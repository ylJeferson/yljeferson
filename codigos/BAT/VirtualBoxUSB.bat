@echo off
color 0a

set /p DISK= Digite o numero do disco: 

cd %programfiles%\oracle\virtualbox

VBoxManage internalcommands createrawvmdk -filename "C:\Users\Jerbson\VirtualBox VMs\USB\usb.vmdk" -rawdisk \\.\PhysicalDrive%DISK%

:fim
pause
exit