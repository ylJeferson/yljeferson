*** Settings ***
Resource    ../Pages/Home.robot
Resource    ../Pages/Login.robot
Resource    ../Pages/Signup.robot
Resource    ../Pages/Flights.robot
Resource    ../Pages/Dashboard.robot
Resource    ../Pages/Profile.robot

Test Setup    Open Session
Test Teardown    Close Session

*** Test Cases ***
Cadastrar usuario
    Acessar o site principal
    Redirecionar para cadastro
    Registrar usuario
    Verificar label de cadastro realizado
    
Realizar login com sucesso
    Acessar o site principal
    Redirecionar para login
    Logar com login e senha corretos
    Verificar primeiro nome do usuario
    
Realizar login com falha
    Acessar o site principal
    Redirecionar para login
    Logar com login e senha incorretos
    Verificar label de credenciais erradas
    
Alterar dados cadastrais
    Acessar o site principal
    Aceitar os cookies
    Redirecionar para login
    Logar com login e senha corretos
    Verificar primeiro nome do usuario
    Redirecionar para dados do usuario
    Alterar dados do usuario
    
    Verificar se dados foram alterados
    Verificar dados do perfil
    Verificar se a senha foi atualizada

Realizar pesquisar de voo
    Acessar o site principal
    Pesquisar voo url