Option Explicit
On Error Resume Next

' -------------------------------------------------------------------------------------------------
' VARIAVEIS DO VBS
Dim objShell
Set objShell = CreateObject("Wscript.Shell")

Dim objFileSystemObject
Set objFileSystemObject = CreateObject("Scripting.FilesystemObject")

Dim strDesktop
strDesktop = objShell.SpecialFolders("Desktop")

' -------------------------------------------------------------------------------------------------
' VARIAVEIS LOCAIS
Dim Bits
Bits = GetObject("winmgmts:root\cimv2:Win32_Processor='cpu0'").AddressWidth

Dim OsArchitectureFolder
If Bits = 64 Then
    OsArchitectureFolder = objShell.ExpandEnvironmentStrings("%PROGRAMFILES(x86)%")
Else
    OsArchitectureFolder = objShell.ExpandEnvironmentStrings("%PROGRAMFILES%")
End If

Dim Programa(3)
Programa(0) = "Nome"
Programa(1) = "Caminho"
Programa(2) = "Argumentos"
Programa(3) = "Icone"
Programa(3) = "Iniciar em"
Programa(3) = "Atalho para abrir (Hotkey)"
Programa(3) = "Modo da tela (Tela cheia, Minimizado, Maximizado...)"
Programa(3) = "Tooltip ao passar o mouse"

' -------------------------------------------------------------------------------------------------
' VARIAVEIS DE ATALHOS
' PROGRAMA
Dim UrlLinkVestis
Set UrlLinkVestis = objShell.CreateShortcut(strDesktop & "\Vestis.lnk")

UrlLinkVestis.TargetPath = "M:\usys72nt\bin\uniface.exe"
UrlLinkVestis.Arguments = "/asn=M:\STRATEGI\INDUSTR\asn\usys.asn  /ini=M:\STRATEGI\INDUSTR\asn\usysnt.ini ssall " & chr(34) & "T" & chr(34)
UrlLinkVestis.IconLocation = "M:\strategi\industr\asn\vestis_.ico"

UrlLinkVestis.WorkingDirectory  = "M:\STRATEGI\INDUSTR\FORMS"
UrlLinkVestis.Hotkey = "CTRL+ALT+2"
UrlLinkVestis.WindowStyle = 3
UrlLinkVestis.Description  = "Created by: Jerbson"

' -------------------------------------------------------------------------------------------------
' EXCLUINDO OS ATALHO


' -------------------------------------------------------------------------------------------------
' GERANDO OS ATALHO
If objFileSystemObject.FolderExists(Path(1)) Then UrlLinkVestis.Save
