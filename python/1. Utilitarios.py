0	SW_HIDE				Hides the window and activates another window.
1	SW_NORMAL			Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
2	SW_SHOWMINIMIZED	Activates the window and displays it as a minimized window.
3	SW_MAXIMIZE			Activates the window and displays it as a maximized window.
4	SW_SHOWNOACTIVATE	Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
5	SW_SHOW				Activates the window and displays it in its current size and position.
6	SW_MINIMIZE			Minimizes the specified window and activates the next top-level window in the Z order.
7	SW_SHOWMINNOACTIVE	Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
8	SW_SHOWNA			Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
9	SW_RESTORE			Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
10	SW_SHOWDEFAULT		Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
11	SW_FORCEMINIMIZE	Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.

# ---------------------------------------------------

['\t', '\n', '\r', ' ', '!', '"', '#', '$', '%', '&', "'", '(',
')', '*', '+', ',', '-', '.', '/', '0', '1', '2', '3', '4', '5', '6', '7',
'8', '9', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`',
'a', 'b', 'c', 'd', 'e','f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~',
'accept', 'add', 'alt', 'altleft', 'altright', 'apps', 'backspace',
'browserback', 'browserfavorites', 'browserforward', 'browserhome',
'browserrefresh', 'browsersearch', 'browserstop', 'capslock', 'clear',
'convert', 'ctrl', 'ctrlleft', 'ctrlright', 'decimal', 'del', 'delete',
'divide', 'down', 'end', 'enter', 'esc', 'escape', 'execute', 'f1', 'f10',
'f11', 'f12', 'f13', 'f14', 'f15', 'f16', 'f17', 'f18', 'f19', 'f2', 'f20',
'f21', 'f22', 'f23', 'f24', 'f3', 'f4', 'f5', 'f6', 'f7', 'f8', 'f9',
'final', 'fn', 'hanguel', 'hangul', 'hanja', 'help', 'home', 'insert', 'junja',
'kana', 'kanji', 'launchapp1', 'launchapp2', 'launchmail',
'launchmediaselect', 'left', 'modechange', 'multiply', 'nexttrack',
'nonconvert', 'num0', 'num1', 'num2', 'num3', 'num4', 'num5', 'num6',
'num7', 'num8', 'num9', 'numlock', 'pagedown', 'pageup', 'pause', 'pgdn',
'pgup', 'playpause', 'prevtrack', 'print', 'printscreen', 'prntscrn',
'prtsc', 'prtscr', 'return', 'right', 'scrolllock', 'select', 'separator',
'shift', 'shiftleft', 'shiftright', 'sleep', 'space', 'stop', 'subtract', 'tab',
'up', 'volumedown', 'volumemute', 'volumeup', 'win', 'winleft', 'winright', 'yen',
'command', 'option', 'optionleft', 'optionright']

# ---------------------------------------------------------

	65539 -> NORMAL
	65541 -> INSERT
	65543 -> WAIT
	65545 -> CROSS
	65547 -> UP
	65549 -> RESIZE_NW_SE
	65551 -> RESIZE_NE_SW
	65553 -> RESIZE_EW
	65555 -> RESIZE_NS
	65557 -> MOVE
	65559 -> NOT_ALLOWED
	65561 -> PROGRESS
	65563 -> HELP

# ---------------------------------------------------------

def AtivaJanela(hwnd, none):
	if win32gui.IsWindowVisible(hwnd):
		print(hex(hwnd), win32gui.GetWindowText(hwnd), hwnd)

win32gui.EnumWindows(AtivaJanela, None)

# ---------------------------------------------------