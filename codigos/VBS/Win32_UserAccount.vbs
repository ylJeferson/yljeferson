Dim strComputer
Dim objWMIService
Dim theUsername 
Dim theDomain
Dim objAccount 

strComputer = "."

Set objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")
theUsername = "jeferson"
theDomain = "KAZZO1"

Set objAccount = objWMIService.Get("Win32_UserAccount.Name='" & theUsername & "',Domain='" & theDomain & "'")

WScript.Echo AccountType
WScript.Echo Caption
WScript.Echo Description
WScript.Echo Disabled
WScript.Echo Domain
WScript.Echo FullName
WScript.Echo InstallDate
WScript.Echo LocalAccount
WScript.Echo Lockout
WScript.Echo Name
WScript.Echo PasswordChangeable
WScript.Echo PasswordExpires
WScript.Echo PasswordRequired
WScript.Echo SID
WScript.Echo SIDType
WScript.Echo Status