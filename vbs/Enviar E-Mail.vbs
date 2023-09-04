Set objOL = CreateObject("Outlook.Application")

Set myNameSpace = objOL.GetNameSpace("MAPI")

Set objMail = objOL.createItem(0)

with objMail

.subject = "Teste"

.To = "teste@teste.com.br"

.Body = "Mensagem aqui!"

.Send

End With