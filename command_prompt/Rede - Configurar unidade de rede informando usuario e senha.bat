@echo off
color 0a
mode 60,15

set /p usuario=Digite seu nome de usuario: 
set /p senha=Digite a senha do seu usuario: 

set dominio=localhost
set caminho_para_a_pasta_na_rede=\\127.0.0.1\c$\config
net use /persistant:yes X: %caminho_para_a_pasta_na_rede% /user:%dominio%\%usuario% %senha% >> nul
net use /persistent:yes X: %caminho_para_a_pasta_na_rede% /user:%dominio%\%usuario% %senha% >> nul

exit
