Option Explicit
On Error Resume Next

Dim objFileSystemObject
Dim fileStream
Dim objShell
Set objShell = WScript.CreateObject("WScript.Shell")
Set objFileSystemObject = CreateObject("Scripting.FileSystemObject")

Dim NomeCompleto
Dim objSysInfo
Dim objUser
Dim appData
Dim Ramal

Set objSysInfo = CreateObject("ADSystemInfo")
Set objUser = GetObject("LDAP://" & objSysInfo.UserName)

appData = objShell.expandEnvironmentStrings("%APPDATA%")
NomeCompleto = objUser.displayName
Ramal = objUser.telephoneNumber

objFileSystemObject.CreateFolder(appData & "\microsoft\Signatures")
Set fileStream = objFileSystemObject.CreateTextFile(appData & "\microsoft\signatures\assinatura.htm")
fileStream.WriteLine "<!DOCTYPE html>"
fileStream.WriteLine "<html>"
fileStream.WriteLine "<head>"
fileStream.WriteLine "<meta charset=" & chr(34) & "utf-8" & chr(34) & ">"
fileStream.WriteLine "</head>"
fileStream.WriteLine "<body>"
fileStream.WriteLine "<b style=" & chr(34) & "color: #ea0d14;font-size:20px;" & chr(34) & ">" & NomeCompleto & " </b> <br>"
fileStream.WriteLine "<img src=" & chr(34) & "https://i.imgur.com/oJthMrZ.png" & chr(34) & " alt=" & chr(34) & "Kazzo Confecções" & chr(34) & " width=" & chr(34) & "129"  & chr(34) & " height="  & chr(34) & "38"  & chr(34) & "/><br>"
fileStream.WriteLine "Tel.: +55 14 3298-9898 Ramal: " & Ramal & " <br>"
fileStream.WriteLine "Endereço: Rua Pedro Monte, 1-85 <br>"
fileStream.WriteLine "Macatuba – SP CEP: 17.293-244 <br>"
fileStream.WriteLine "<i style=" & chr(34) & "color:#7f7f7f;font-size:12px;text-align:justify;" & chr(34) & ">Antes de imprimir, pense em sua responsabilidade e compromisso com o Meio Ambiente. Este documento pode incluir informação confidencial e de propriedade restrita da Kazzo Confecções Ltda. e apenas pode ser lido por aquele(s) a qual o mesmo tenha sido endereçado. Se você recebeu essa mensagem de e-mail indevidamente, por favor, avise-nos imediatamente. Quaisquer opiniões ou informações expressadas neste e-mail pertencem ao seu remetente e não necessariamente coincidem com aquelas da Kazzo Confecções Ltda. Este documento não pode ser reproduzido, copiado, distribuído, publicado ou modificado por terceiros, sem a previa autorização por escrito da Kazzo Confecções Ltda.</i>"
fileStream.WriteLine "</body>"
fileStream.WriteLine "</html>"
fileStream.Close