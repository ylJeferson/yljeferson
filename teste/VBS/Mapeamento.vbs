Option Explicit
On Error Resume Next



'VARIAVEIS
Dim objFileSystemObject
Dim objNetwork
Dim objApplication
Dim objShell
Dim strDesktop

Dim strWallpaper

Dim grouplistD
Dim ADSPath
Dim userPath
Dim listGroup

Set objFileSystemObject = CreateObject("Scripting.FilesystemObject")
Set objApplication = CreateObject("Shell.Application")
Set objNetwork = CreateObject("WScript.Network")
Set objShell = CreateObject("Wscript.Shell")

Dim PrinterPorts
Dim strValue
Dim objRegistry
Dim BROTHERADM
DIm BROTHERALM
Dim BROTHERCLR
Dim BROTHERDP
Dim BROTHERETQ
Dim BROTHEREXP
Dim BROTHERFIN
Dim BROTHERLAV
Dim BROTHERMOD
Dim BROTHERREC

Const HKEY_CLASSES_ROOT 	= &H80000000
Const HKEY_CURRENT_USER 	= &H80000001
Const HKEY_LOCAL_MACHINE 	= &H80000002
Const HKEY_USERS 			= &H80000003
Const HKEY_CURRENT_CONFIG 	= &H80000005

PrinterPorts = "Software\Microsoft\Windows NT\CurrentVersion\PrinterPorts"
BROTHERADM = "\\SRV-AD2016-2\Administrativo"
BROTHERALM = "\\SRV-AD2016-2\Almoxarifado"
BROTHERCLR = "\\SRV-AD2016-2\Colorida"
BROTHERDP  = "\\SRV-AD2016-2\Departamento Pessoal"
BROTHERETQ = "\\SRV-AD2016-2\Etiquetas"
BROTHEREXP = "\\SRV-AD2016-2\Expedicao"
BROTHERFIN = "\\SRV-AD2016-2\Financeiro"
BROTHERLAV = "\\SRV-AD2016-2\Lavanderia"
BROTHERMOD = "\\DESK167\Modelagem"
BROTHERREC = "\\SRV-AD2016-2\Recebimento"



'CRIANDO ESTRUTURA DE PASTAS E DELETANDO TEMPORÁRIOS
objFileSystemObject.CreateFolder("c:\config")
objFileSystemObject.CreateFolder("c:\config\temp")




'WALLPAPER
objFileSystemObject.GetFolder("\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\IMAGENS").Copy "c:\config\imagens"
strDesktop = objShell.SpecialFolders("Desktop")
strWallpaper = "c:\config\imagens\wallpapers\kazzo.jpg"
objShell.RegWrite "HKCU\Control Panel\Desktop\Wallpaper", strWallpaper



' MAPEAMENTO DE REDE
If not objFileSystemObject.DriveExists("M:") Then
	objNetwork.MapNetworkDrive "M:", "\\SRV-AD2016\APLICATIVOS\STRATEGIES",true
End If
	objApplication.NameSpace("M:").Self.Name = "VESTIS"
	objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\vestis.Lnk",strDesktop & "\"

If not objFileSystemObject.DriveExists("N:") Then
	objNetwork.MapNetworkDrive "N:", "\\SRV-AD2016\APLICATIVOS\KARAMBA\STRATEGIES",true
End If
	objApplication.NameSpace("N:").Self.Name = "KARAMBA"
	objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\vestis(KARAMBA).Lnk",strDesktop & "\" 

If isMember("DL_MODELAGEM_ESCRITA") Then
	If not objFileSystemObject.DriveExists("X:") Then
		objNetwork.MapNetworkDrive "X:", "\\SRV-MODELAGEM\X",True,"srv-modelagem\administrador","N0v4ar"
	End If
		objApplication.NameSpace("X:").Self.Name = "MODELAGEM"

   If not objFileSystemObject.DriveExists("Z:") Then
		objNetwork.MapNetworkDrive "Z:", "\\SRV-AD2016\ARQUIVOS",true
	End If
		objApplication.NameSpace("Z:").Self.Name = "REDE"
Else
	If not objFileSystemObject.DriveExists("X:") Then
		objNetwork.MapNetworkDrive "X:", "\\SRV-AD2016\ARQUIVOS",true
	End If
		objApplication.NameSpace("X:").Self.Name = "REDE"
End If

If isMember("DL_POSTOS_ESCRITA") Then
   If not objFileSystemObject.DriveExists("Z:") Then
		objNetwork.MapNetworkDrive "Z:", "\\SRV-AD2016\APLICATIVOS\LINX\PFWIN",true
	End If
		objApplication.NameSpace("Z:").Self.Name = "POSTO FACIL"
		objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\PostoFacil.Lnk",strDesktop & "\"
End If

If isMember("DL_SAGE") Then
	If not objFileSystemObject.DriveExists("S:") Then
		objNetwork.MapNetworkDrive "S:", "\\192.168.0.2\FOLHAMATIC",true
	End If
		objApplication.NameSpace("S:").Self.Name = "FOLHAMATIC"

	If isMember("DL_DEPARTAMENTOPESSOAL_ESCRITA") Then
		objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\Folhamatic.Lnk",strDesktop & "\"
	End If

	If isMember("DL_IMPRESSORA_FINANCEIRO") Then
		objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\Contabil.Lnk",strDesktop & "\"
		objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\EFiscal.Lnk",strDesktop & "\"
	End If
End If

objFileSystemObject.CopyFile "\\SRV-AD2016\APLICATIVOS\ARQUIVOS\CONFIG\ATALHOS\Virtual Age.lnk",strDesktop & "\"



'MAPEAMENTO DE IMPRESSORA
objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERADM, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_ADMINISTRATIVO") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERADM"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERALM, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_ALMOXARIFADO") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERALM"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERCLR, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_COLORIDA") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERCLR"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERDP, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_DP") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERDP"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERETQ, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_ETIQUETAS") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERETQ"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHEREXP, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_EXPEDICAO") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHEREXP"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERFIN, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_FINANCEIRO") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERFIN"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERLAV, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_LAVANDERIA") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERLAV"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERMOD, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_MODELAGEM") Then
		objNetwork.AddWindowsPrinterConnection "\\DESK167\BROTHERMOD"
	End If
End If

objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, BROTHERREC, strValue
If IsNull(strValue) Then
	If isMember("DL_IMPRESSORA_RECEBIMENTO") Then
		objNetwork.AddWindowsPrinterConnection "\\SRV-AD2016-2\BROTHERREC"
	End If
End If



'FINALIZANDO CONFIGURACOES
objFileSystemObject.DeleteFile("c:\config\temp\*")
objFileSystemObject.DeleteFolder("c:\config\temp\*")
objShell.Run "RUNDLL32.EXE user32.dll,UpdatePerUserSystemParameters"



'FUNCOES
Function IsMember(groupName)
    If IsEmpty(groupListD) then
        Set groupListD = CreateObject("Scripting.Dictionary")
        groupListD.CompareMode = 1
        ADSPath = EnvString("userdomain") & "/" & EnvString("username")
        Set userPath = GetObject("WinNT://" & ADSPath & ",user")
        For Each listGroup in userPath.Groups
            groupListD.Add listGroup.Name, "-"
        Next
    End if
    IsMember = CBool(groupListD.Exists(groupName))
End Function

Function EnvString(variable)
    variable = "%" & variable & "%"
    EnvString = objShell.ExpandEnvironmentStrings(variable)
End Function