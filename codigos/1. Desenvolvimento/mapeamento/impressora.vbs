Option Explicit
On Error Resume Next

Dim objNetwork
Set objNetwork = CreateObject("WScript.Network")

Dim objShell
Set objShell = CreateObject("Wscript.Shell")

Dim strComputer
strComputer = "."

Dim objWMIService
Set objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")

Dim colInstalledPrinters
Set colInstalledPrinters = objWMIService.ExecQuery _
    ("Select * from Win32_Printer Where Network = TRUE")

Dim objRegistry
Set objRegistry = GetObject("winmgmts:\\" & _ 
    strComputer & "\root\default:StdRegProv")

Dim PrinterPorts
PrinterPorts = "Software\Microsoft\Windows NT\CurrentVersion\PrinterPorts"

Dim objSysInfo
Set objSysInfo = CreateObject("ADSystemInfo")

Dim UserName
Dim DeskName

UserName = objSysInfo.UserName
DeskName = objSysInfo.ComputerName

DeskName = Left(DeskName, InStr(DeskName, ",") - 1)
DeskName = Right(DeskName, len(DeskName) - InStr(DeskName, "="))

Const HKEY_CLASSES_ROOT     = &H80000000
Const HKEY_CURRENT_USER     = &H80000001
Const HKEY_LOCAL_MACHINE    = &H80000002
Const HKEY_USERS            = &H80000003
Const HKEY_CURRENT_CONFIG   = &H80000005

Dim strValue
Dim grouplistD
Dim ADSPath
Dim userPath
Dim listGroup

Dim PRINTER(9)
PRINTER(0) = "Administrativo"
PRINTER(1) = "Almoxarifado"
PRINTER(2) = "Colorida"
PRINTER(3) = "Departamento Pessoal"
PRINTER(4) = "Etiquetas"
PRINTER(5) = "Expedicao"
PRINTER(6) = "Financeiro"
PRINTER(7) = "Lavanderia"
PRINTER(8) = "Modelagem"
PRINTER(9) = "Recebimento"

Dim DL(9)
DL(0) = "DL_IMPRESSORA_ADMINISTRATIVO"
DL(1) = "DL_IMPRESSORA_ALMOXARIFADO"
DL(2) = "DL_IMPRESSORA_COLORIDA"
DL(3) = "DL_IMPRESSORA_DP"
DL(4) = "DL_IMPRESSORA_ETIQUETAS"
DL(5) = "DL_IMPRESSORA_EXPEDICAO"
DL(6) = "DL_IMPRESSORA_FINANCEIRO"
DL(7) = "DL_IMPRESSORA_LAVANDERIA"
DL(8) = "DL_IMPRESSORA_MODELAGEM"
DL(9) = "DL_IMPRESSORA_RECEBIMENTO"

Dim i
Dim AD
Dim AD1
Dim AD2
Dim SRV
AD1 = "\\SRV-AD2016\"
AD2 = "\\DESK206\"
SRV = "\\DESK206\"

For i = 0 to 9
    AD = SRV
    If PRINTER(i) = "Modelagem" Then AD = "\\DESK167\"

    objRegistry.GetStringValue HKEY_CURRENT_USER, PrinterPorts, AD & PRINTER(i), strValue
    If IsNull(strValue) And IsMember(DL(i)) And DeskName <> "DESK206" Then
        objNetwork.AddWindowsPrinterConnection AD & PRINTER(i)
    ElseIf not IsNull(strValue) And not IsMember(DL(i)) And DeskName <> "DESK206" Then
        objNetwork.RemovePrinterConnection AD & PRINTER(i)
    End If

    If IsMember(DL(i)) And DeskName <> "DESK206" And PRINTER(i) <> "Colorida" Then
        objNetwork.SetDefaultPrinter AD & PRINTER(i)
    End If
    WScript.Sleep 500
Next

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