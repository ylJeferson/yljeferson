@echo off
color 0a

net stop spooler

cd %systemroot%\system32\spool\PRINTERS

del /f /s *.shd
del /f /s *.spl

net start spooler

:fim
pause
exit
