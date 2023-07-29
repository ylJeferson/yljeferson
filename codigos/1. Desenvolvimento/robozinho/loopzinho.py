from pynput import keyboard
import win32con
import win32gui
import time
import sys
import os

# ---------------------------------------------------------

hora = time.localtime().tm_hour
minuto = time.localtime().tm_min
weekday = time.localtime().tm_wday

do_ramais = True

ramais_title = 'Restart Botucatu VPN - By: Jerbson'
robozinho_title = 'Robozinho - By: Jerbson'
tray_title = 'Tray Icon - By: Jerbson'

# ---------------------------------------------------------

break_program = False
def OnPress(key):
	global break_program
	print(key)

	try:
		key_code = key.vk
	except AttributeError:
		key_code = key.value.vk

	if key_code == 192:
		break_program = True
		return False

# ---------------------------------------------------------

os.system(f'start "{tray_title}" "C:\\config\\programas\\Robozinho\\utilitarios\\trayicon.exe"')
time.sleep(5)
win32gui.ShowWindow(win32gui.FindWindow(None, tray_title), win32con.SW_HIDE)

# os.system(f'start "{ramais_title}" "C:\\config\\programas\\Robozinho\\utilitarios\\ramais.exe"')
# time.sleep(5)
# win32gui.ShowWindow(win32gui.FindWindow(None, ramais_title), win32con.SW_HIDE)

os.system(f'start "{robozinho_title}" "C:\\config\\programas\\Robozinho\\robozinho.exe"')
time.sleep(5)
win32gui.ShowWindow(win32gui.FindWindow(None, robozinho_title), win32con.SW_HIDE)

# ---------------------------------------------------------

try:
	with keyboard.Listener(on_press=OnPress) as listener:
		while not break_program:
			if 7 <= hora < 18 and weekday <= 5:
				if not win32gui.FindWindow(None, robozinho_title):
					os.system(f'start "{robozinho_title}" "C:\\config\\programas\\Robozinho\\robozinho.exe"')
					time.sleep(5)
					win32gui.ShowWindow(win32gui.FindWindow(None, robozinho_title), win32con.SW_HIDE)

				# if do_ramais and minuto % 10 == 0:
				# 	do_ramais = False

				# 	os.system(f'start "{ramais_title}" "C:\\config\\programas\\Robozinho\\utilitarios\\ramais.exe"')
				# 	time.sleep(5)
				# 	win32gui.ShowWindow(win32gui.FindWindow(None, ramais_title), win32con.SW_HIDE)
				
				# elif not do_ramais and minuto % 10 != 0:
				# 	do_ramais = True

			time.sleep(5)

		listener.join()

	os.system('taskkill /f /im ramais.exe')
	os.system('taskkill /f /im robozinho.exe')
	os.system('taskkill /f /im trayicon.exe')
	sys.exit()
	quit()

except Exception as e:
	os.system(f'echo {e} >> c:\\config\\log.txt')
	os.system('echo ------------------------------------------------------------------------------------------------------------------------ >> c:\\config\\log.txt')
	os.system(f'echo {time.localtime().tm_mday}/{time.localtime().tm_mon}/{time.localtime().tm_year} - {time.localtime().tm_hour}:{time.localtime().tm_min} >> c:\\config\\log.txt')
	os.system(f'echo Loopzinho >> c:\\config\\log.txt')
	os.system(f'echo. >> c:\\config\\log.txt')
	os.system(f'echo. >> c:\\config\\log.txt')
	time.sleep(5)

	sys.exit()
	quit()