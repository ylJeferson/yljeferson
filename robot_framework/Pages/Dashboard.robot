*** Settings ***
Resource    ../Infra/base.robot

*** Variables ***


*** Keywords ***
#Passos
Verificar primeiro nome do usuario
    ${Dados}=    Pegar Valor Json    profile_data
    ${PrimeiroNome}=    Get WebElement    xpath://strong[text()="${Dados}[first_name]"]
    Wait Until Page Contains Element    ${PrimeiroNome}
    Log to console    Acessou a tela inicial do usuario