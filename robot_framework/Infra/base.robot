*** Settings ***
Library    BuiltIn
Library    SeleniumLibrary
Library    Library/config.py
Library    Library/utilidades.py

*** Variables ***
${btnGotIt}    xpath://*[text()="Got It"]

*** Keywords ***
Open Session
    ${browser}=    Pegar Valor Json    browser
    ${base_url}=    Pegar Valor Json    base_url

    Open Browser    ${base_url}    ${browser}
    Get Selenium speed
    Maximize Browser Window

Close Session
    Close Browser

Ir Para
    [Arguments]    ${path}

    ${base_url}=    Pegar Valor Json    base_url

    Go To    ${base_url}${path}

Aceitar os cookies
    Click Element    ${btnGotIt} 

Pegar Data
    ${date}=    Get Date

    Set Test Message    ${date}