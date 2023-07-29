Option Explicit
On Error Resume Next

Dim objFileSystemObject
Set objFileSystemObject = CreateObject("Scripting.FilesystemObject")

Dim objNetwork
Set objNetwork = CreateObject("WScript.Network")

Dim objApplication
Set objApplication = CreateObject("Shell.Application")

Dim objShell
Set objShell = CreateObject("Wscript.Shell")

Dim strDesktop
strDesktop = objShell.SpecialFolders("Desktop")

Dim grouplistD
Dim ADSPath
Dim userPath
Dim listGroup

Dim DL(6)
DL(0) = "Usu" & chr(225) & "rios do dom" & chr(237) & "nio"
DL(1) = "Usu" & chr(225) & "rios do dom" & chr(237) & "nio"
DL(2) = "DL_SAGE"
DL(3) = "Usu" & chr(225) & "rios do dom" & chr(237) & "nio"
DL(4) = "DL_MODELAGEM_ESCRITA"
DL(5) = "DL_MODELAGEM_ESCRITA"
DL(6) = "DL_POSTOS_ESCRITA"

Dim Drive(6)
Drive(0) = "M:"
Drive(1) = "N:"
Drive(2) = "S:"
Drive(3) = "X:"
Drive(4) = "X:"
Drive(5) = "Z:"
Drive(6) = "Z:"

Dim Path(6)
Path(0) = "\\SRV-AD2016\APLICATIVOS\STRATEGIES"
Path(1) = "\\SRV-AD2016\APLICATIVOS\KARAMBA\STRATEGIES"
Path(2) = "\\192.168.0.2\FOLHAMATIC"
Path(3) = "\\SRV-AD2016\ARQUIVOS"
Path(4) = "\\SRV-MODELAGEM\X"
Path(5) = "\\SRV-AD2016\ARQUIVOS"
Path(6) = "\\SRV-AD2016\APLICATIVOS\LINX\PFWIN"

Dim Name(6)
Name(0) = "VESTIS"
Name(1) = "KARAMBA"
Name(2) = "FOLHAMATIC"
Name(3) = "REDE"
Name(4) = "MODELAGEM"
Name(5) = "REDE"
Name(6) = "POSTO FACIL"

Dim UserName
Dim DeskName
Dim objSysInfo

Set objSysInfo = CreateObject("ADSystemInfo")
' UserName = objSysInfo.UserName
DeskName = objSysInfo.ComputerName

DeskName = Left(DeskName, InStr(DeskName, ",") - 1)
DeskName = Right(DeskName, len(DeskName) - InStr(DeskName, "="))

if DeskName <> "DESK193" Then
    Dim i
    For i = 0 to 6
        If objFileSystemObject.DriveExists(Drive(i)) Then objNetwork.RemoveNetworkDrive Drive(i), True, True
    Next

    WScript.Sleep 1000

    For i = 0 to 6
        If IsMember(DL(i)) Then
            If objFileSystemObject.DriveExists(Drive(i)) Then objNetwork.RemoveNetworkDrive Drive(i), True, True
            WScript.Sleep 500

            If DL(i) <> "\\SRV-MODELAGEM\X" Then objNetwork.MapNetworkDrive Drive(i), Path(i), True Else objNetwork.MapNetworkDrive "X:", "\\SRV-MODELAGEM\X", True, "SRV-MODELAGEM\mapeamento", "Giri4F3l0C@t"
            objApplication.NameSpace(Drive(i)).Self.Name = Name(i)
        End If
        WScript.Sleep 500
    Next
End If

Function IsMember(groupName)
    If IsEmpty(groupListD) then
        Set groupListD = CreateObject("Scripting.Dictionary")
        groupListD.CompareMode = 1
        ADSPath = "KAZZO1/" & EnvString("username")
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