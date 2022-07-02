*** Settings ***
Resource    ../Infra/base.robot

*** Variables ***
${txtLoginEmail}    xpath://input[@placeholder="Email"]
${txtLoginPassword}    xpath://input[@placeholder="Password"]
${btnLogin}    xpath://div[@class="btn-box pt-3 pb-4"]/button
${lblLoginSignup}    xpath://div[@class="alert alert-success signup"]
${lblLoginFailed}    xpath://div[@class="alert alert-danger failed"]

*** Keywords ***
# Funções
Escrever email
    [Arguments]    ${email}
        Input Text    ${txtLoginEmail}    ${email}
    
Escrever senha
    [Arguments]    ${password}
        Input Text    ${txtLoginPassword}    ${password}

Clicar botao login
    Click button    ${btnLogin}

#Funcionalidade
Realize login
    [Arguments]    ${email}    ${password}

    Escrever email    ${email}
    Escrever senha    ${password}
    Clicar botao login

#Passos
Redirecionar para login
    Ir Para    login
    Log to console    Acessou a tela de login

Logar com login e senha corretos
    ${Dados}=    Pegar Valor Json    profile_data
    
    Realize login    ${Dados}[email]    ${Dados}[password]
    Log to console    Dados de login digitados e botão apertado

Logar com login e senha incorretos
    Realize login    saucedemo@travels.com    secretsauce
    Log to console    Dados de login digitados e botão de confirmação pressionado

Verificar label de cadastro realizado
    Wait Until Page Contains Element    ${lblLoginSignup}
    Log to console    Dados de login digitados e botão apertado

Verificar label de credenciais erradas
    Wait Until Page Contains Element    ${lblLoginFailed}
    Log to console    Erro de login retornado