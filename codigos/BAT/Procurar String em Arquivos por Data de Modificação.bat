@echo off
mode 47
color 0a
title Marca��es do Ponto

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ���������������� INICIALIZANDO ��������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set ponto=c:\config\temp\ponto.txt
set path_poto="X:\Depto Pessoal\Captu"

cd /d %path_poto%
if exist %ponto% del %ponto%

set cracha_codigo=112370
set data_passagem_cracha=%date:~0,6%%date:~8,2%
set data_modificacao_arquivo=%date%


echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo �������������� DADOS DA PESQUISA ������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
set /p cracha_codigo=C�digo do Cracha (Padr�o: %cracha_codigo%) 
set /p data_passagem_cracha=Data da Marca��o (Padr�o: %data_passagem_cracha%) 
set /p data_modificacao_arquivo=Data de Mofifica��o (Padr�o: %data_modificacao_arquivo%) 

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������������� PESQUISANDO ���������������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
for /f "tokens=3* delims= " %%a in ('dir /s ^| findstr /i "X:"') do (
	for /f "tokens=4* delims= " %%p in ('dir /s ^| findstr /i %data_modificacao_arquivo% ^| findstr /i ".txt"') do (
		if exist "%%a %%b\%%p %%q" findstr /i /p %cracha_codigo% "%%a %%b\%%p %%q" >> c:\config\temp\ponto.txt
	)
)

echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������� RESULTADOS ENCONTRADOS ����������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
findstr %data_passagem_cracha% c:\config\temp\ponto.txt


echo ���������������������������������������������ͻ
echo ���������������������������������������������ۺ
echo ����������� JERBINHO DO WHATERZAPER ���������ۺ
echo ���������������������������������������������ۺ
echo ���������������������������������������������ͼ
pause
exit