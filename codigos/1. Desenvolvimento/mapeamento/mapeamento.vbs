Option Explicit
On Error Resume Next

Dim objFileSystemObject
Set objFileSystemObject = CreateObject("Scripting.FilesystemObject")

Dim objShell
Set objShell = CreateObject("Wscript.Shell")

Dim strDesktop
strDesktop = objShell.SpecialFolders("Desktop")

Dim WshNetwork
Set WshNetwork = CreateObject("WScript.Network")

Dim ComputerName
ComputerName = WshNetwork.ComputerName

Dim objSysInfo
Set objSysInfo = CreateObject("ADSystemInfo")

Dim objUser
Set objUser = GetObject("LDAP://" & objSysInfo.UserName)

Dim UserName
UserName = objSysInfo.UserName
UserName = Left(UserName, InStr(UserName, ",") - 1)
UserName = Right(UserName, len(UserName) - InStr(UserName, "="))

Dim Ramal
Dim NomeCompleto
Ramal = objUser.telephoneNumber
NomeCompleto = objUser.displayName

' DELETANDO ARQUIVOS ANTIGOS
objFileSystemObject.DeleteFile("c:\config\scripts\*")

' PADRONIZANDO
objFileSystemObject.CreateFolder("c:\config")
objFileSystemObject.CreateFolder("c:\config\temp")

objFileSystemObject.GetFolder("\\SRV-AD2016\Aplicativos\config\imagens").Copy "c:\config\imagens"
objFileSystemObject.GetFolder("\\SRV-AD2016\Aplicativos\config\scripts").Copy "c:\config\scripts"

' ADICIONANDO REGSITROS
objShell.Run "reg import C:\config\scripts\padrao.reg"

'CHAMANDO SCRIPTS
objShell.Run "C:\config\scripts\rede.vbs"
objShell.Run "C:\config\scripts\impressora.vbs"
objShell.Run "C:\config\scripts\assinatura.bat " & chr(34) & NomeCompleto & chr(34) & " " & chr(34) & Ramal & chr(34)

'FINALIZANDO CONFIGURACOES
objFileSystemObject.DeleteFile("c:\config\temp\*")
objShell.Run "RUNDLL32.EXE user32.dll,UpdatePerUserSystemParameters"
' MsgBox("Configuracoes Finalizadas")