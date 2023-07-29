from pywinauto.application import Application
from configparser import ConfigParser
from win32api import GetKeyState
from PIL import Image
import pyperclip
import pyautogui
import win32con
import win32gui
import string
import random
import time
import sys
import os

# ---------------------------------------------------------
"""

	FUNÇÕES
	
	"""
# ---------------------------------------------------------

def INI():
	config = ConfigParser()
	config.read('C:\\config\\programas\\Robozinho\\robozinho.ini')

	if not config.has_section('UPDATE'):
		config.add_section('UPDATE')
		config.set('UPDATE', 'update', '1')

	if not config.has_section('CONFIG'):
		config.add_section('CONFIG')

	if not config.has_section('TOTVS'):
		config.add_section('TOTVS')

	if config.getboolean('UPDATE', 'update') == 1:
		config.set('CONFIG', 'tempimage', 'C:\\config\\temp\\')

		config.set('TOTVS', 'title', 'TOTVS Moda')
		config.set('TOTVS', 'programpath', '"C:\\Program Files\\Uniface\\Uniface Anywhere Client\\Client\\ua-client.exe" /deb -h www30.bhan.com.br -c -u kazzoconfeccoes -p kjLsjJC4 -a "Virtual Age"')
		config.set('TOTVS', 'imagespath', 'C:\\config\\programas\\Robozinho\\imagens\\totvs\\')
		config.set('TOTVS', 'imagespath', 'C:\\config\\programas\\Robozinho\\imagens\\totvs\\')
		config.set('TOTVS', 'imagespath', 'C:\\config\\programas\\Robozinho\\imagens\\totvs\\')
		config.set('TOTVS', 'username', 'TI')
		config.set('TOTVS', 'password', '314coli')
		config.set('TOTVS', 'enterprise', '79')
		config.set('TOTVS', 'mousecursor', '65541,65539')
		config.set('TOTVS', 'allowedusers', 'ADMIN,DESEN,VIRTUAL,ENGEN,SUPEX,SMALL,LIGHT,ANANDA,CAROLLINE,RENATA,SHELIDE,TATIANA,VIVIAN')
		config.set('TOTVS', 'allowedcomponents', ',DICFM001,PRDFC014,PRDFF005')
		config.set('TOTVS', 'packettimer', '120')
		config.set('TOTVS', 'locaterepetitions', '1')
		config.set('TOTVS', 'start', '7')
		config.set('TOTVS', 'stop', '17')
		config.set('TOTVS', 'maxwday', '4')

	config.set('TOTVS', 'imagesname', BrowseImages(config.get('TOTVS', 'imagespath'), ''))
	config.set('UPDATE', 'update', '0')

	with open('C:\\config\\programas\\Robozinho\\robozinho.ini', 'w') as configfile:
		config.write(configfile)

	return config

# ---------------------------------------------------------

def BrowseImages(path, files):
	for f in os.listdir(path):
		files += os.path.join(f) + ','

	files = files.rstrip(',')

	return files

# ---------------------------------------------------------

def RandomString(path, extension):
	number_of_strings = 1
	length_of_string = 8

	for x in range(number_of_strings):
		path += ''.join(random.SystemRandom().choice(string.ascii_letters + string.digits) for _ in range(length_of_string)) + extension

	return path

# ---------------------------------------------------------

def MouseCursorStatus():
	timer = 0
	pyautogui.moveTo(x=50, y=50)

	while win32gui.GetCursorInfo()[1] not in main_program_parameters['mousecursor']:
		pyautogui.moveTo(x=50, y=50, duration=1)
		pyautogui.moveTo(x=100, y=100, duration=1)
		timer += 2
		time.sleep(.1)

	if timer >= main_program_parameters['packettimer']:
		pyautogui.press('f2')
		time.sleep(2)
		return True

# ---------------------------------------------------------

class MacroTOTVS:
	def __init__(self, main_program_parameters):
		self.Macro(main_program_parameters)

	def Macro(self, main_program_parameters):
		self.OpenTOTVS(main_program_parameters)
		self.ReturnCurrentWindow(main_program_parameters, len(main_program_parameters['imagesname']) * main_program_parameters['locaterepetitions'])

		if main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][5] or main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][6]:
			pyautogui.hotkey('alt', 'n')
			time.sleep(1)

			if main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][6]:
				pyautogui.hotkey('shift', 'tab')

			self.SendInput(main_program_parameters['username'], 'tab')
			self.SendInput(main_program_parameters['password'], 'enter')
			time.sleep(2)

			self.SendInput(main_program_parameters['enterprise'], 'enter')
			time.sleep(2)

			self.SendInput('', 'space')
			time.sleep(2)

			self.DefaultMessage('Mensagem geral', 'system_login')

			main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][0]

		elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][0] or main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][1]:
			self.DefaultMessage('Mensagem geral', 'basic')

			pyautogui.hotkey('alt', 'n')
			time.sleep(.5)

			x, y = pyautogui.position()
			while win32gui.GetCursorInfo()[1] != 65541:
				pyautogui.moveTo(x, y)
				x += 10
				time.sleep(.5)

			pyautogui.click(x, y)

			self.SendInput('INTFP053', 'tab')
			main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][2]

		elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][2]:
			pyautogui.hotkey('alt', 'f')
			pyautogui.press('c')
			time.sleep(1)

			self.SendInput('ADMFP020', 'f12')

			main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][3]

		elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][3] or main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][4]:
			main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][7]

		elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][7] or main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][8] or main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][9]:
			MouseCursorStatus()

			if main_program_parameters['start'] <= time.localtime().tm_hour <= main_program_parameters['stop'] and time.localtime().tm_wday <= main_program_parameters['maxwday']:
				if not main_program_parameters['cancelsession']:
					main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][3]

				elif not main_program_parameters['ordersession']:
					main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][7]

				elif not main_program_parameters['usersession']:
					main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][8]

				elif not main_program_parameters['windowsession']:
					main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][9]

				else:
					UserX = main_program_parameters['usersession'][0] + main_program_parameters['usersession'][2] / 2
					ScreenX = main_program_parameters['windowsession'][0] + main_program_parameters['windowsession'][2] / 2
					IdleX = main_program_parameters['ordersession'][0] + main_program_parameters['ordersession'][2] / 2

					dados = [1, 'User', 'Screen', 100]
					x = [UserX, ScreenX, IdleX]
					y = main_program_parameters['ordersession'][1] + main_program_parameters['ordersession'][3] * 1.5
				
					MouseCursorStatus()
					pyautogui.press('f2')
					time.sleep(2)

					MouseCursorStatus()
					pyautogui.click(main_program_parameters['ordersession'], clicks=2)

					while (dados[0] <= 16) and (int(dados[3]) >= 5):
						self.Copy(dados, x, y)
						if (dados[1] not in main_program_parameters['allowedusers']) and (dados[2] not in main_program_parameters['allowedcomponents']) and (int(dados[3]) >= 5):
							time.sleep(.3)

							pyautogui.press('tab')
							time.sleep(.3)
							if MouseCursorStatus():
								return

							pyautogui.press('space')
							time.sleep(.3)
							if MouseCursorStatus():
								return

						dados[0] += 1
						y += 16
						time.sleep(.5)

					if MouseCursorStatus():
						return

					pyautogui.hotkey('alt', 'c')
					time.sleep(.5)

					if MouseCursorStatus():
						pyautogui.hotkey('alt', 'n')
						pyautogui.hotkey('alt', 'n')
					
					else:
						pyautogui.hotkey('alt', 's')
					
					time.sleep(5)
					self.DefaultMessage('Mensagem geral', 'basic')
					main_program_parameters['nextwindow'] = main_program_parameters['imagesname'][7]

			else:
				hours = (30 - time.localtime().tm_hour) * 3600
				minutes = (59 - time.localtime().tm_min) * 60
				seconds = 60 - time.localtime().tm_sec
				sleep = hours + minutes + seconds
				time.sleep(sleep)
				return

		else:
			print('Reiniciando ...')
			pyautogui.screenshot().save(RandomString(main_program_parameters['tempimage'], '.png'))

			MouseCursorStatus()
			self.DefaultMessage('Mensagem geral', 'restart')

			main_program_parameters['nextwindow'] = ''
	
	def ReturnCurrentWindow(self, main_program_parameters, maxloops):
		looptimes = 0
		VerifyImages = True

		if main_program_parameters['nextwindow']:
			while VerifyImages:
				print(1, main_program_parameters['nextwindow'])				
				coordinates = pyautogui.locateOnScreen(Image.open(main_program_parameters['imagespath'] + main_program_parameters['nextwindow']))

				if coordinates:
					main_program_parameters['coordinates'] = coordinates
					if main_program_parameters['nextwindow'] not in (main_program_parameters['imagesname'][3], main_program_parameters['imagesname'][4], main_program_parameters['imagesname'][7], main_program_parameters['imagesname'][8], main_program_parameters['imagesname'][9]):
						pyautogui.click(coordinates)

					elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][7]:
						main_program_parameters['ordersession'] = coordinates

					elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][8]:
						main_program_parameters['usersession'] = coordinates

					elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][9]:
						main_program_parameters['windowsession'] = coordinates

					else:
						main_program_parameters['cancelsession'] = coordinates

					time.sleep(2)
					VerifyImages = False
					return

				looptimes += 1
				if looptimes >= maxloops:
					main_program_parameters['nextwindow'] = ''
					return

		else:
			while VerifyImages:
				for f in main_program_parameters['imagesname']:
					print(2, f)				
					coordinates = pyautogui.locateOnScreen(Image.open(main_program_parameters['imagespath'] + f))

					if coordinates:
						main_program_parameters['nextwindow'] = f
						main_program_parameters['coordinates'] = coordinates
						if f not in (main_program_parameters['imagesname'][3], main_program_parameters['imagesname'][4], main_program_parameters['imagesname'][7], main_program_parameters['imagesname'][8], main_program_parameters['imagesname'][9]):
							pyautogui.click(coordinates)

						elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][7]:
							main_program_parameters['ordersession'] = coordinates

						elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][8]:
							main_program_parameters['usersession'] = coordinates

						elif main_program_parameters['nextwindow'] == main_program_parameters['imagesname'][9]:
							main_program_parameters['windowsession'] = coordinates

						else:
							main_program_parameters['cancelsession'] = coordinates

						time.sleep(2)
						VerifyImages = False
						return

					looptimes += 1
					if looptimes >= maxloops:
						main_program_parameters['nextwindow'] = ''
						return

	def SendInput(self, text, button):
		if text:
			pyautogui.press('numlock')
			pyautogui.hotkey('ctrl', 'end')
			pyautogui.hotkey('shift', 'home')
			pyautogui.press('numlock')
			pyautogui.write(text, interval=0.25)
		time.sleep(.5)

		pyautogui.press(button)

	def DefaultMessage(self, messagetitle, msgtype):
		if msgtype == 'restart':
			while not win32gui.FindWindow(None, messagetitle):
				pyautogui.press('esc')
				time.sleep(1)

		while win32gui.FindWindow(None, messagetitle):
			win32gui.SetForegroundWindow(win32gui.FindWindow(None, messagetitle))

			if msgtype == 'basic':
				pyautogui.press('space')
				time.sleep(2)

			elif msgtype == 'system_login':
				pyautogui.press('space', presses=2)
				time.sleep(2)

			elif msgtype == 'restart':
				pyautogui.hotkey('alt', 'n')
				pyautogui.press('backspace')
				time.sleep(2)

	def Copy(self, dados, px, y):
		MouseCursorStatus()

		for i, x in enumerate(px):
			pyautogui.click(x, y, clicks=2)
			pyautogui.hotkey('ctrl', 'c')
			time.sleep(.5)

			idx = i + 1
			dados[idx] = pyperclip.paste()
			pyperclip.copy('')
			MouseCursorStatus()

		print(dados)

	def OpenTOTVS(self, main_program_parameters):
		if GetKeyState(win32con.VK_CAPITAL):
			pyautogui.press('capslock')

		main_program_parameters['hwnd'] = win32gui.FindWindow(None, main_program_parameters['title'])
		response = os.system('ping -n 1 www30.bhan.com.br > NUL')
		while response != 0:
			response = os.system('ping -n 1 www30.bhan.com.br > NUL')
			time.sleep(60)

		if not main_program_parameters['hwnd']:
			main_program_parameters['nextwindow'] = ''
			main_program_parameters['coordinates'] = ''
			main_program_parameters['cancelsession'] = ''
			main_program_parameters['ordersession'] = ''
			main_program_parameters['usersession'] = ''
			main_program_parameters['windowsession'] = ''
			main_program_parameters['timesession'] = ''
			main_program_parameters['positiony'] = ''

			Application(backend="uia").start(main_program_parameters['programpath']).window(title=main_program_parameters['title']).wait('visible', timeout=30)
			self.OpenTOTVS(main_program_parameters)
		else:
			win32gui.ShowWindow(main_program_parameters['hwnd'], main_program_parameters['sw_flag'])
			win32gui.SetForegroundWindow(main_program_parameters['hwnd'])

# ---------------------------------------------------------
"""

	PROGRAMA

	"""
# ---------------------------------------------------------
main_program_parameters = {
	'sw_flag': win32con.SW_MAXIMIZE,
	'hwnd': '',
	'title': INI().get('TOTVS', 'title'),
	'programpath': INI().get('TOTVS', 'programpath'),
	'imagespath': INI().get('TOTVS', 'imagespath'),
	'imagesname': INI().get('TOTVS', 'imagesname').split(','),
	'nextwindow': '',
	'username': INI().get('TOTVS', 'username'),
	'password': INI().get('TOTVS', 'password'),
	'enterprise': INI().get('TOTVS', 'enterprise'),
	'coordinates': '',
	'mousecursor': [int(x) for x in INI().get('TOTVS', 'mousecursor').split(',')],
	'allowedusers': INI().get('TOTVS', 'allowedusers').split(','),
	'allowedcomponents': INI().get('TOTVS', 'allowedcomponents').split(','),
	'cancelsession': '',
	'ordersession': '',
	'usersession': '',
	'windowsession': '',
	'timesession': '',
	'positiony': '',
	'packettimer': INI().getint('TOTVS', 'packettimer'),
	'locaterepetitions': INI().getint('TOTVS', 'locaterepetitions'),
	'start': INI().getint('TOTVS', 'start'),
	'stop': INI().getint('TOTVS', 'stop'),
	'maxwday': INI().getint('TOTVS', 'maxwday'),

	'tempimage': INI().get('CONFIG', 'tempimage')
}

try:
	while True:
		MacroTOTVS(main_program_parameters)

	sys.exit()
	quit()

except Exception as e:
	os.system(f'echo {e} >> c:\\config\\log.txt')
	os.system('echo ------------------------------------------------------------------------------------------------------------------------ >> c:\\config\\log.txt')
	os.system(f'echo {time.localtime().tm_mday}/{time.localtime().tm_mon}/{time.localtime().tm_year} - {time.localtime().tm_hour}:{time.localtime().tm_min} >> c:\\config\\log.txt')
	os.system(f'echo Robozinho >> c:\\config\\log.txt')
	os.system(f'echo. >> c:\\config\\log.txt')
	os.system(f'echo. >> c:\\config\\log.txt')
	time.sleep(5)

	sys.exit()
	quit()