@echo off
color 0a

title Adicionar credenciais no windows

:inicio
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩烝烝烝烝烝烝烝炳栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩 INICIALIZANDO 栩栩栩栩栩栩栩杠
echo 裁栩栩栩栩栩栩栩樛樛樛樛樛樛樛樂栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
set target=%userdomain%
set user=%username%@%userdomain%
set pass=abc123

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩桎烝烝烝烝烝烝烝烝烝烝栩栩栩栩栩栩�
echo 裁栩栩栩栩栩� DADOS DA CREDENCIAL 栩栩栩栩栩栩�
echo 裁栩栩栩栩栩桀樛樛樛樛樛樛樛樛樛樛栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
set /p target=浜 Dom�nio (Padr�o: %target%) 
set /p user=麺 Usu�rio (Padr�o: %user%) 
set /p pass=藩 Senha (Padr�o: %pass%) 

echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩栩栩栩桎烝烝烝烝烝烝栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩� ADICIONANDO 栩栩栩栩栩栩栩栩�
echo 裁栩栩栩栩栩栩栩桀樛樛樛樛樛樛栩栩栩栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
cmdkey /add:%target% /user:%user% /pass:%pass%

choice /N /C SN /M "��� Deseja fazer outro comando? [S,N]: "
if %ERRORLEVEL% equ 1 goto inicio
if %ERRORLEVEL% equ 2 goto fim

:fim
echo 浜様様様様様様様様様様様様様様様様様様様様様様�
echo 裁栩栩栩栩桎烝烝烝烝烝烝烝烝烝烝烝烝栩栩栩栩栩�
echo 裁栩栩栩栩� JERBINHO DO WHATERZAPER 栩栩栩栩栩�
echo 裁栩栩栩栩桀樛樛樛樛樛樛樛樛樛樛樛樛栩栩栩栩栩�
echo 藩様様様様様様様様様様様様様様様様様様様様様様�
pause
exit