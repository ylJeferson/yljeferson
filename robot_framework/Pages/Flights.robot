*** Settings ***
Resource    ../Infra/base.robot

*** Variables ***
${TempoDeEspera}    50
${IrPara}    resr

${ViajarDE}    gru
${ViajarATE}    jpa

${IdaEVolta}    oneway
# ${IdaEVolta}    return

${DataIr}    05-07-2022
${DataVoltar}    07-07-2022

${Bebes}    0
${Adultos}    2
${Crianças}    0

${TipoDePassagem}    economy
# ${TipoDePassagem}    economy_premium
# ${TipoDePassagem}    business
# ${TipoDePassagem}    first

*** Keywords ***
#Passos
Redirecionar para dados do usuario
    Ir Para    flights
    Log to console    Acessou a tela pesquisa de voos

Pesquisar voo url
    IF    "${IdaEVolta}" == "oneway"
        Ir para    flights/en/usd/${ViajarDE}/${ViajarATE}/${IdaEVolta}/${TipoDePassagem}/${DataIr}/${Adultos}/${Crianças}/${Bebes}
    END
    IF    "${IdaEVolta}" == "return"
        Ir para    flights/en/usd/${ViajarDE}/${ViajarATE}/${IdaEVolta}/${TipoDePassagem}/${DataIr}/${DataVoltar}/${Adultos}/${Crianças}/${Bebes}
    END
    
    Log to console    Voos de ${ViajarDE} até ${ViajarATE} listados, você terá um tempo de ${TempoDeEspera} segundos para visualizar.
    Sleep     ${TempoDeEspera}s

