Dim objPrinter
For Each objPrinter in colInstalledPrinters
    objPrinter.Delete_
    WScript.Sleep 500
Next