strAppPath = "c:\config\uvncsc\winvnc.exe"

Set objShell = CreateObject("WScript.Shell")
objDesktop = objShell.SpecialFolders("Desktop")
Set objLink = objShell.CreateShortcut(objDesktop & "\Suporte Remoto.lnk")

objLink.TargetPath = strAppPath
objLink.WindowStyle = 3
objLink.Save

WScript.Quit