from pynput import keyboard
from time import sleep

# ---------------------------------------------------------

# def OnPress_KeyCode(key):
# 	try:
# 		key_code = key.vk
# 	except AttributeError:
# 		key_code = key.value.vk
# 	print(key_code)

# listener = keyboard.Listener(on_press=OnPress_KeyCode)
# listener.start()

# try:
# 	while listener.is_alive():
# 		sleep(1)
# except KeyboardInterrupt:
# 	listener.stop()

# ---------------------------------------------------------

break_program = False
def OnPress(key):
    global break_program
    print(key)
    if key.vk == 192:
        break_program = True
        return False

with keyboard.Listener(on_press=OnPress) as listener:
    while not break_program:
        print('program running')
        sleep(.5)
    listener.join()

# ---------------------------------------------------------