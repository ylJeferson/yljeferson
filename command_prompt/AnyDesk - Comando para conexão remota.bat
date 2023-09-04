@echo off
color 0a

echo %password% | anydesk.exe %id_lias% --with-password
