@echo off
mode 47
color 0a
title Marcaไes do Ponto

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ INICIALIZANDO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
set ponto=c:\config\temp\ponto.txt
set path_poto="X:\Depto Pessoal\Captu"

cd /d %path_poto%
if exist %ponto% del %ponto%

set cracha_codigo=112370
set data_passagem_cracha=%date:~0,6%%date:~8,2%
set data_modificacao_arquivo=%date%


echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛ DADOS DA PESQUISA ÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
set /p cracha_codigo=Cขdigo do Cracha (Padrฦo: %cracha_codigo%) 
set /p data_passagem_cracha=Data da Marcaฦo (Padrฦo: %data_passagem_cracha%) 
set /p data_modificacao_arquivo=Data de Mofificaฦo (Padrฦo: %data_modificacao_arquivo%) 

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛ PESQUISANDO ÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
for /f "tokens=3* delims= " %%a in ('dir /s ^| findstr /i "X:"') do (
	for /f "tokens=4* delims= " %%p in ('dir /s ^| findstr /i %data_modificacao_arquivo% ^| findstr /i ".txt"') do (
		if exist "%%a %%b\%%p %%q" findstr /i /p %cracha_codigo% "%%a %%b\%%p %%q" >> c:\config\temp\ponto.txt
	)
)

echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛ RESULTADOS ENCONTRADOS ÛÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
findstr %data_passagem_cracha% c:\config\temp\ponto.txt


echo ษอออออออออออออออออออออออออออออออออออออออออออออป
echo บÛÛÛÛÛÛÛÛÛÛ฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿฿ÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛ JERBINHO DO WHATERZAPER ÛÛÛÛÛÛÛÛÛÛบ
echo บÛÛÛÛÛÛÛÛÛÛÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÜÛÛÛÛÛÛÛÛÛÛบ
echo ศอออออออออออออออออออออออออออออออออออออออออออออผ
pause
exit