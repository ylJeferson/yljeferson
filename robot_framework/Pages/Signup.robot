*** Settings ***
Resource    ../Infra/base.robot

*** Variables ***
${txtSignupFirstName}    xpath://input[@placeholder="First Name"]
${txtSignupLastName}    xpath://input[@placeholder="Last Name"]
${txtSignupPhone}    xpath://input[@placeholder="Phone"]
${txtSignupEmail}    xpath://input[@placeholder="Email"]
${txtSignupPassword}    xpath://input[@placeholder="Password"]
${sltAccountType}    xpath://span[@class="selection"]/span

${btnSignup}    xpath://div[@class="form-group mt-3"]/button
${btnSignupLogin}    xpath://div[@class="btn-box pb-1 mt-2"]/a

*** Keywords ***
# Funções
Cadastrar primeiro nome
    [Arguments]    ${firstName}
        Input Text    ${txtSignupFirstName}    ${firstName}

Cadastrar ultimo nome
    [Arguments]    ${lastName}
        Input Text    ${txtSignupLastName}    ${lastName}

Cadastrar telefone
    [Arguments]    ${phone}
        Input Text    ${txtSignupPhone}    ${phone}

Cadastrar email
    [Arguments]    ${email}
        Input Text    ${txtSignupEmail}    ${email}
    
Cadastrar senha
    [Arguments]    ${password}
        Input Text    ${txtSignupPassword}    ${password}

Abrir caixa com os tipos de conta
    Click Element    ${sltAccountType}

Selecionar tipo de conta
    [Arguments]    ${accountType}

    ${elmAccountType}=    Get WebElement    xpath://li[text()="${accountType}"]
    
    Click Element    ${elmAccountType}

Clicar botao signup
    Click button    ${btnSignup}

Clicar botao login para redirecionar para o login
    Click button    ${btnSignupLogin}

#Funcionalidade
Realize signup
    [Arguments]    ${firstName}    ${lastName}    ${phone}    ${email}    ${password}    ${accountType}
    
    Cadastrar primeiro nome    ${firstName}
    Cadastrar ultimo nome    ${lastName}
    Cadastrar telefone    ${phone}
    Cadastrar email    ${email}
    Cadastrar senha    ${password}

    Abrir caixa com os tipos de conta
    Selecionar tipo de conta    ${accountType}
    
    Clicar botao signup

#Passos
Redirecionar para cadastro
    Ir Para    signup
    Log to console    Acessou a tela de cadastro

Registrar usuario
    ${Dados}=    Retornar Dados Aleatorios
    
    Realize signup    ${Dados}[first_name]    ${Dados}[last_name]    ${Dados}[phone]    ${Dados}[email]    ${Dados}[password]    ${Dados}[business]
    Log to console    Dados de cadastro digitados e botão de confirmação pressionado

Deve ser redirecionado para a tela de login
    Verificar label de cadastro realizado
    Log to console    Cadastro realizado

