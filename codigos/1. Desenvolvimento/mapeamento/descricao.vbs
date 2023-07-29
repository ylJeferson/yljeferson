Option Explicit
On Error Resume Next

Dim objFileSystemObject
Set objFileSystemObject = CreateObject("Scripting.FilesystemObject")

Dim objShell
Set objShell = CreateObject("Wscript.Shell")

Dim txtFile
Dim txtReplace
Dim descComputador

Const ForReading = 1
Const ForWriting = 2

'DESCRICAO DO COMPUTADOR
objShell.Run "cmd /c WMIC PATH Win32_UserAccount where name=" & chr(34) & "%username%" & chr(34) & " get Description /Value | FIND "  & chr(34) & "=" & chr(34) &  ">>"  & chr(34) & "c:\config\temp\descricao_do_computador.txt" & chr(34)

WScript.Sleep 2000

Set objFileSystemObject = CreateObject("Scripting.FileSystemObject")
Set txtFile = objFileSystemObject.OpenTextFile("C:\config\temp\descricao_do_computador.txt", ForReading)
descComputador = txtFile.ReadAll
txtFile.Close

txtReplace = Replace(descComputador, "Description=", "")
Set txtFile = objFileSystemObject.OpenTextFile("C:\config\temp\descricao_do_computador.txt", ForWriting)
txtFile.WriteLine txtReplace
txtFile.Close

Set objFileSystemObject = CreateObject("Scripting.FileSystemObject")
Set txtFile = objFileSystemObject.OpenTextFile("C:\config\temp\descricao_do_computador.txt", ForReading)
descComputador = txtFile.ReadAll
txtFile.Close

'EXECUTAR COMO ADMINISTRADOR
objShell.Run "cmd /c net config server /srvcomment:" & chr(34) & descComputador & chr(34)

'EXECUTAR COMO ADMINISTRADOR
objShell.Run "cmd /c REG ADD " & chr(34) & "HKLM\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters" & chr(34) & " /v " & chr(34) & "srvcomment" & chr(34) & " /t REG_SZ /d " & chr(34) & descComputador & chr(34)