Set strArg=WScript.Arguments.Named
Set strRdlproc = CreateObject("WScript.Shell").Exec("rundll32 kernel32,Sleep")
With GetObject("winmgmts:\\.\root\CIMV2:Win32_Process.Handle='" & strRdlproc.ProcessId & "'")
With GetObject("winmgmts:\\.\root\CIMV2:Win32_Process.Handle='" & .ParentProcessId & "'")
If InStr (.CommandLine, WScript.ScriptName) <> 0 Then
strLine = Mid(.CommandLine, InStr(.CommandLine , "/File:") + Len(strArg("File")) + 8)
End If
End With
.Terminate
End With
CreateObject("Shell.Application").ShellExecute "cmd.exe", "/c " & chr(34) & chr(34) & strArg("File") & chr(34) & strLine & chr(34), "", "runas", 1
