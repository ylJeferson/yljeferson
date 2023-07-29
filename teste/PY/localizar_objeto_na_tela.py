# pip install Pillow
# pip install pytesseract

from PIL import Image
from pytesseract import pytesseract

# Utilizado para pesquisar imagens no programa que está a frente da tela
# Configurei nos parametros pra gente passar o caminho da pasta referente ao local que o programa foi executado
# Além disso, o 'grupo_de_tela_a_procurar' é um padrão para nomear os arquivos 'nome_da_imagem.nome_da_tela.extensão', utilizo isso porque se não ele irá pesquisar por todas as imagens até encontrar alguma delas no meio da tela
def retornar_tela_atual_por_imagem(pasta_de_imagens, grupo_de_tela_a_procurar):
	lista_de_imagens = []
	caminho_para_pasta_de_imagens = os.listdir(f'.\\imagens\\{pasta_de_imagens}')

	for arquivo in caminho_para_pasta_de_imagens:
		if arquivo.endswith(grupo_de_tela_a_procurar + '.png') or arquivo.endswith(grupo_de_tela_a_procurar + '.jpg'):
			lista_de_imagens.append(arquivo)

	for imagem in lista_de_imagens:
		coordenadas = pyautogui.locateCenterOnScreen(f'.\\imagens\\{pasta_de_imagens}\\{imagem}')

		if coordenadas and int(retornar_parametro_do_arquivo('PRINT', 'nao_retornar_tela_atual')) == 0:
			return coordenadas, imagem.partition(".")[0], imagem.partition(".")[2].partition(".")[0]
		
	return ''

# É necessário instalar o Tesseract OCR - https://github.com/UB-Mannheim/tesseract/wiki
# Além de instalar vocÊ deve indicar o caminho do programa nos comandos que estão abaixo
# Eu utilizo o lightshot, configurado para salvar a print diretamente após apertar o 'Print Screen'
# Mas você pode instalar qualquer programa, só basta configurar para salvar a imagem ao apertar 'Print Screen' 
# Se você passar vazio para o parâmemtro, ele irá imprimir no console tudo o que foi encontrado e vai parar o loop
def retornar_tela_por_texto(expressoes):
	for i in range(int(retornar_parametro_do_arquivo('CONFIG', 'maximo_prints_da_tela_atual'))):
		os.system('del D:\\config\\temp\\*.* /q')
		ahk.send_input('{PrintScreen}')
		utilidades.espera_print()

		path_to_tesseract = r"D:\\programas\\Tesseract-OCR\\tesseract.exe"
		pytesseract.tesseract_cmd = path_to_tesseract
		
		image_path = r"D:\\config\\temp\\Screenshot_1.png"
		img = Image.open(image_path)
		
		text = pytesseract.image_to_data(img, lang='por', output_type='dict')
		if not expressoes:
			return text

		btnX = ''
		btnY = ''
		tela_atual = ''
		for idx, x in enumerate(text['text']):
			if x in expressoes:
				tela_atual = x
				btnY = text['top'][idx] + text['height'][idx] / 2
				btnX = text['left'][idx] + text['width'][idx] / 2
				break

		if tela_atual and btnX and btnY:
			if int(retornar_parametro_do_arquivo('PRINT', 'imprimir_dados_da_palavra_encontrada_na_tela')) == 1:
				print(tela_atual, btnX, btnY)

			return tela_atual, btnX, btnY
