Set objOL = CreateObject("Outlook.Application")

Set myNameSpace = objOL.GetNameSpace("MAPI")

Set objMail = objOL.createItem(0)

with objMail

.subject = "Teste"

.To = "suporte@kazzo.com.br"

.Body = "Teste"

.Send

End With