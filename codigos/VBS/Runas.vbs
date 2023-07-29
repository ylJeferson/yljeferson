set oShell= Wscript.CreateObject("WScript.Shell")
oShell.Run "runas /user:administrador@DESK109 ""PATH_TO_PROGRAM"""
WScript.Sleep 100
oShell.Sendkeys "PASSWORD~" 'Não remova o ~, ele pressiona o ENTER
Wscript.Quit