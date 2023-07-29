@echo off
@color 0a
@chcp 65001

md "%appdata%\microsoft\Assinaturas\"
del "%appdata%\microsoft\Assinaturas\*" /Q

md "%appdata%\microsoft\Signatures\"
del "%appdata%\microsoft\Signatures\*" /Q

set PATH="%appdata%\microsoft\Assinaturas\assinatura.htm"
set PATH2="%appdata%\microsoft\Signatures\assinatura.htm"

echo ^<DOCTYPE html^> >> %PATH% 
echo ^<html^> >> %PATH% 
echo ^<head^> >> %PATH%
echo ^<meta charset="utf-8"/^> >> %PATH%
echo ^</head^> >> %PATH%
echo ^<body^> >> %PATH%
echo ^<b style="color: #ea0d14;font-size:20px"^>%~1 ^</b^> ^<br^> >> %PATH%
echo ^<img src="https://i.imgur.com/oJthMrZ.png" alt="Kazzo Confecções" width="129" height="38"/^>^<br^> >> %PATH%
echo Tel.: +55 14 3298-9898 Ramal: %~2 ^<br^> >> %PATH%
echo Endereço: Rua Pedro Monte, 1-85 ^<br^> >> %PATH%
echo Macatuba – SP CEP: 17.293-244 ^<br^> >> %PATH%
echo ^<i style="color:#7f7f7f;font-size:12px;text-align:justify;"^>Antes de imprimir, pense em sua responsabilidade e compromisso com o Meio Ambiente. Este documento pode incluir informação confidencial e de propriedade restrita da Kazzo Confecções Ltda. e apenas pode ser lido por aquele(s) a qual o mesmo tenha sido endereçado. Se você recebeu essa mensagem de e-mail indevidamente, por favor, avise-nos imediatamente. Quaisquer opiniões ou informações expressadas neste e-mail pertencem ao seu remetente e não necessariamente coincidem com aquelas da Kazzo Confecções Ltda. Este documento não pode ser reproduzido, copiado, distribuído, publicado ou modificado por terceiros, sem a previa autorização por escrito da Kazzo Confecções Ltda.^</i^> >> %PATH%
echo ^</body^> >> %PATH%
echo ^</html^> >> %PATH%

echo ^<DOCTYPE html^> >> %PATH2% 
echo ^<html^> >> %PATH2% 
echo ^<head^> >> %PATH2%
echo ^<meta charset="utf-8"/^> >> %PATH2%
echo ^</head^> >> %PATH2%
echo ^<body^> >> %PATH2%
echo ^<b style="color: #ea0d14;font-size:20px"^>%~1 ^</b^> ^<br^> >> %PATH2%
echo ^<img src="https://i.imgur.com/oJthMrZ.png" alt="Kazzo Confecções" width="129" height="38"/^>^<br^> >> %PATH2%
echo Tel.: +55 14 3298-9898 Ramal: %~2 ^<br^> >> %PATH2%
echo Endereço: Rua Pedro Monte, 1-85 ^<br^> >> %PATH2%
echo Macatuba – SP CEP: 17.293-244 ^<br^> >> %PATH2%
echo ^<i style="color:#7f7f7f;font-size:12px;text-align:justify;"^>Antes de imprimir, pense em sua responsabilidade e compromisso com o Meio Ambiente. Este documento pode incluir informação confidencial e de propriedade restrita da Kazzo Confecções Ltda. e apenas pode ser lido por aquele(s) a qual o mesmo tenha sido endereçado. Se você recebeu essa mensagem de e-mail indevidamente, por favor, avise-nos imediatamente. Quaisquer opiniões ou informações expressadas neste e-mail pertencem ao seu remetente e não necessariamente coincidem com aquelas da Kazzo Confecções Ltda. Este documento não pode ser reproduzido, copiado, distribuído, publicado ou modificado por terceiros, sem a previa autorização por escrito da Kazzo Confecções Ltda.^</i^> >> %PATH2%
echo ^</body^> >> %PATH2%
echo ^</html^> >> %PATH2%
exit

