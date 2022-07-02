*** Settings ***
Resource    ../Infra/base.robot

*** Variables ***
${txtProfileFirstName}    xpath://input[@name="firstname"]
${txtProfileLastName}    xpath://input[@name="lastname"]
${txtProfilePhone}    xpath://input[@name="phone"]
${txtProfileEmail}    xpath://input[@name="email"]
${txtProfilePassword}    xpath://input[@name="password"]
${sltCountry}    xpath://span[@class="selection"]/span
${txtProfileState}    xpath://input[@name="state"]
${txtProfileCity}    xpath://input[@name="city"]
${txtProfileFax}    xpath://input[@name="fax"]
${txtProfilePostalCode}    xpath://input[@name="zip"]
${txtProfileAddress1}    xpath://input[@name="address1"]
${txtProfileAddress2}    xpath://input[@name="address2"]

${btnUpdate}    xpath://button[@type="submit"][text()="Update Profile"]
${lblUpdateSuccessfully}    xpath://div[@class="alert alert-success"]

${Primeiro_Nome}    Jeferson
${Ultimo_Nome}    Hugo
${Telefone}    4002-8922
${Email}    phpweqtravelstest@gmail.com
${Senha}    RTest@4590
${Pais}    Brazil
${sltCountryOptValue}    xpath://option[text()="${Pais}"]
${Estado}    São Paulo
${Cidade}    Macatuba
${Fax}    0
${CaixaPostal}    06382-472
${Endereco}    Vieira Alves, Nº 45-70
${Endereco2}    Jd. Veneza

*** Keywords ***
# Funções
Alterar primeiro nome
    [Arguments]    ${firstName}
        Input Text    ${txtProfileFirstName}    ${firstName}

Alterar ultimo nome
    [Arguments]    ${lastName}
        Input Text    ${txtProfileLastName}    ${lastName}

Alterar telefone
    [Arguments]    ${phone}
        Input Text    ${txtProfilePhone}    ${phone}

Alterar email
    [Arguments]    ${email}
        Input Text    ${txtProfileEmail}    ${email}
    
Alterar senha
    [Arguments]    ${password}
        Input Text    ${txtProfilePassword}    ${password}

Abrir caixa com os nomes dos paises
    Click Element    ${sltCountry}

Selecionar pais
    [Arguments]    ${country}

    ${elmAccountType}=    Get WebElement    xpath://li[text()="${country}"]
    
    Click Element    ${elmAccountType}
    
Alterar estado
    [Arguments]    ${state}
        Input Text    ${txtProfileState}    ${state}
    
Alterar cidade
    [Arguments]    ${city}
        Input Text    ${txtProfileCity}    ${city}
    
Alterar fax
    [Arguments]    ${fax}
        Input Text    ${txtProfileFax}    ${fax}
    
Alterar caixa postal
    [Arguments]    ${postalcode}
        Input Text    ${txtProfilePostalCode}    ${postalcode}
    
Alterar endereco1
    [Arguments]    ${address1}
        Input Text    ${txtProfileAddress1}    ${address1}
    
Alterar endereco2
    [Arguments]    ${address2}
        Input Text    ${txtProfileAddress2}    ${address2}

Enviar o formulario
    Submit Form

Verificar se elemento existe
    [Arguments]    ${elemento}

    Wait Until Page Contains Element    ${lblLoginFailed}

#Funcionalidade
Realize update
    [Arguments]    ${firstName}    ${lastName}    ${phone}    ${email}    ${password}    ${country}    ${state}    ${city}    ${fax}    ${postalcode}    ${address1}    ${address2}
    
    Alterar primeiro nome    ${firstName}
    Alterar ultimo nome    ${lastName}
    Alterar telefone    ${phone}
    Alterar email    ${email}
    Alterar senha    ${password}

    Abrir caixa com os nomes dos paises
    Selecionar pais    ${country}

    Alterar estado    ${state}
    Alterar cidade    ${city}
    Alterar fax    ${fax}
    Alterar caixa postal    ${postalcode}
    Alterar endereco1    ${address1}
    Alterar endereco2    ${address2}

    Enviar o formulario

#Passos
Redirecionar para dados do usuario
    Ir Para    account/profile
    Log to console    Acessou a tela dados do usuario

Realizar logout
    Ir Para    account/logout
    Log to console    Logoff feito com sucesso

Alterar dados do usuario
    ${Dados}=    Pegar Valor Json    profile_data
    Realize update    ${Primeiro_Nome}    ${Ultimo_Nome}    ${Telefone}    ${Email}    ${Senha}    ${Pais}    ${Estado}    ${Cidade}    ${Fax}    ${CaixaPostal}    ${Endereco}    ${Endereco2}
    ${Gambiarra}=    Gravar Valor Json    ${Primeiro_Nome}    ${Ultimo_Nome}    ${Telefone}    ${Email}    ${Senha}    ${Pais}    ${Estado}    ${Cidade}    ${Fax}    ${CaixaPostal}    ${Endereco}    ${Endereco2}    ${Dados}[business]
    Log to console    Dados do usuario digitados e botão de confirmação de alteração pressionado

Verificar se dados foram alterados
    Wait Until Page Contains Element    ${lblUpdateSuccessfully}
    Log to console    Dados alterados com sucesso

Verificar se a senha foi atualizada
    Realizar logout
    Logar com login e senha corretos
    Log to console    Nova senha funcionou corretamente

Verificar dados do perfil   
    ${Dados}=    Pegar Valor Json    profile_data
    ${OptionValue}=    Get Element Attribute  ${sltCountryOptValue}  value

    ${elmProfileFirstName}=    Get WebElement    ${txtProfileFirstName}\[@value="${Dados}[first_name]"]
    ${elmProfileLastName}=    Get WebElement    ${txtProfileLastName}\[@value="${Dados}[last_name]"]
    ${elmProfilePhone}=    Get WebElement    ${txtProfilePhone}\[@value="${Dados}[phone]"]
    ${elmProfileEmail}=    Get WebElement    ${txtProfileEmail}\[@value="${Dados}[email]"]
    ${elmProfileCountry}=    Get WebElement    ${sltCountry}//*[text()="${OptionValue}"]
    ${elmProfileState}=    Get WebElement    ${txtProfileState}\[@value="${Dados}[state]"]
    ${elmProfileCity}=    Get WebElement    ${txtProfileCity}\[@value="${Dados}[city]"]
    ${elmProfileFax}=    Get WebElement    ${txtProfileFax}\[@value="${Dados}[fax]"]
    ${elmProfilePostalCode}=    Get WebElement    ${txtProfilePostalCode}\[@value="${Dados}[postal_code]"]
    ${elmProfileAddress1}=    Get WebElement    ${txtProfileAddress1}\[@value="${Dados}[address1]"]
    ${elmProfileAddress2}=    Get WebElement    ${txtProfileAddress2}\[@value="${Dados}[address2]"]

    Wait Until Page Contains Element    ${elmProfileFirstName}
    Wait Until Page Contains Element    ${elmProfilePhone}
    Wait Until Page Contains Element    ${elmProfileEmail}
    Wait Until Page Contains Element    ${elmProfileCountry}
    Wait Until Page Contains Element    ${elmProfileState}
    Wait Until Page Contains Element    ${elmProfileCity}
    Wait Until Page Contains Element    ${elmProfileFax}
    Wait Until Page Contains Element    ${elmProfilePostalCode}
    Wait Until Page Contains Element    ${elmProfileAddress1}
    Wait Until Page Contains Element    ${elmProfileAddress2}