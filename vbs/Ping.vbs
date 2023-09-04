Dim objItem
Dim colItems
Dim objWMIService
Set objWMIService = GetObject("winmgmts:\\.\root\cimv2")
' Set colItems = objWMIService.ExecQuery("Select * From win32_PingStatus where address='" & IPServidor & "'")
' For Each objItem in colItems
'     msgbox "Status" & objItem.statuscode & " Time " & objItem.ResponseTime
' Next
Dim Counter
Do while Counter < 10
    Counter = Counter + 1 
	Set colItems = objWMIService.ExecQuery("Select * From win32_PingStatus where address='" & IPServidor & "'")
	For Each objItem in colItems
	    msgbox "Status" & objItem.statuscode & " Time " & objItem.ResponseTime
	Next
Loop


Dim ComputerName
ComputerName = objNetwork.ComputerName
If Not InStr(1, ComputerName, "SRV") = 1 Then