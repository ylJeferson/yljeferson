import os
import wx
import time
import wx.adv
import win32gui
import win32con
from datetime import datetime
from selenium import webdriver

tray = win32gui.GetForegroundWindow()
win32gui.SetWindowText(tray, 'By: Jerbson')
win32gui.ShowWindow(tray, win32con.SW_HIDE)
visivel = False

"""
    Inicialmente verifica a se existe algo no parametro submenu, se retornar false, ele cria um botão simples, se retornar true ele cira um menu com submenus.

    Nos 2 casos ele usa os parametros menu, id e label para criar os botões, e joga os dados em uma váriavel.
    Após ele associa o botão a um evento e também a função que foi passada no parametro funcao.
      Obs.: No segundo caso ele usa um FOR porque os dados são passados por uma lista.

    No segundo caso, após o for ele associa os submenus ao menu principal, e o nome do menu principal é o primeiro elemento da lista
    """
def criar_menu(menu, tipomenu, id, label, funcao):
    if tipomenu == 'Menu':
        item = wx.MenuItem(menu, id, label)
        menu.Bind(wx.EVT_MENU, funcao, id=item.GetId())
        menu.Append(item)
        return item
    elif tipomenu == 'Submenu':
        tipomenu = wx.Menu()
        for i in range(len(label)-1):
            item = wx.MenuItem(tipomenu, id[i+1], label[i+1])
            tipomenu.Bind(wx.EVT_MENU, funcao[i+1], id=item.GetId())
            tipomenu.Append(item)

        menu.AppendSubMenu(tipomenu, label[0])
        return item

"""
    Função utilizada para dar u time.sleep até o horario que for indicado no parametro

    Inicialmente pegamos a data, hora e minuto atuais e a convertemos em string
    Após retiramos a diferença dos horarios utilizando a API datetime.timedelta
        Ela converte a string do horario para data e faz a conta para retornar o periodo

    E ao final o valor obtido na subtração é retornado na função time.sleep em segundos
    """
def EsperarAteAs(horario):
    de = datetime.now().strftime('%H:%M:%S')
    ate = horario
    FMT = '%H:%M:%S'
    tempo_de_espera = datetime.strptime(ate, FMT) - datetime.strptime(de, FMT)

    return tempo_de_espera.seconds

"""
    Teste
    """
def Ramais(status):
    if 2 not in status:
        hora = datetime.now().hour
        minuto = datetime.now().minute
        segundo = datetime.now().second

        botucatu1 = 0
        botucatu2 = 0

        if 9 <= hora < 18:
            hora = datetime.now().hour
            minuto = datetime.now().minute
            segundo = datetime.now().second

            ip = '192.168.11.1'
            response = os.system('ping -n 1 ' + ip + ' > NUL')
            if response == 1:
                botucatu1 += 1
                options = webdriver.ChromeOptions()
                options.add_argument('--headless')
                driver = webdriver.Chrome(options=options)
                driver.get('http://administrador:N0v4ar@kazzobotucatu.duckdns.org:14000/vpn_summary.htm')
                driver.find_element_by_xpath('//input[@value="Disconnect"]').click()
                driver.quit()

            ip = '192.168.12.1'
            response = os.system('ping -n 1 ' + ip + ' > NUL')
            if response == 1:
                botucatu2 += 1
                options = webdriver.ChromeOptions()
                options.add_argument('--headless')
                driver = webdriver.Chrome(options=options)
                driver.get('http://administrador:N0v4ar@doctbotucatu2.duckdns.org:14000/vpn_summary.htm')
                driver.find_element_by_xpath('//input[@value="Disconnect"]').click()
                driver.quit()

            print(f'echo {hora}:{minuto}:{segundo} - B1: {botucatu1}    B2: {botucatu2}')

            if not isinstance(status[0], int):
                status.pop(0)
            status.insert(0, wx.CallLater(300000, Ramais, status))
        else:
            if not isinstance(status[0], int):
                status.pop(0)
            status.insert(0, wx.CallLater(EsperarAteAs('09:00:00') * 1000, Ramais, status))
    else:
        status[0].Stop()
        status.pop(0)

"""
    Teste
    """
def Roteadores(ip):
    options = webdriver.ChromeOptions()
    options.add_argument('--headless')
    driver = webdriver.Chrome(options=options)
    driver.get('http://' + ip + '/')

    driver.find_element_by_id('userName').send_keys('admin')
    driver.find_element_by_id('pcPassword').send_keys('D0c7m4c4')
    driver.find_element_by_id('loginBtnText').click()
    time.sleep(2)

    driver.switch_to.frame('bottomLeftFrame')
    driver.find_element_by_id('menu_tools').click()
    driver.find_element_by_id('menu_restart').click()
    driver.switch_to.default_content()
    time.sleep(2)

    driver.switch_to.frame('mainFrame')
    driver.find_element_by_id('button_reboot').click()

    alert = driver.switch_to.alert
    alert.accept()
    time.sleep(2)

    driver.quit()

"""
    Classe criada para configurar a estrutura do icone da barra de tarefas, ela está herdando todas as classes da API wx.adv.TaskBarIcon

    __Init__ Quando a classe for referenciada ele vai chamar este parametro.
        frame - A API wx trabalha com frames (pode ser traduzido como telas), o frame foi criado, mas neste projeto nó não damos show nela, porque esta não é nossa intenção.
        super - serve para herdar os parametros da API que foi passado na variável frame
        DesabilitaBotao - Variavel criada para desabilitar algum botão além disso ela é utilizada para parar alguma rotina.
        Set_icon - chama a função que determina qual icone será usado
        Bind - Associa o evento de click com o botão esquerdo no icone com uma função no programa

    CreatePopupMenu - é uma classe da API wx.adv.TaskBarIcon
        Aqui fica troca a estruturação do menu do nosso TrayIcon.
        Quando for necessário criar um submenu deve-se usar a variavel 'submenu[1]' e criar uma outra variavel com 3 listas, sendo a primeira com o ID dos submenus, a segunda com a Label dos submenus e a terceira deve ser o nome da função que será associada a cada submenu. É importante ressaltar sempre que o primeiro elemento de cada lista será associado ao menu principal, ou seja, ao passar o mouse por cima dele aparecerão os submenus.
            Obs.: Abaixo das funções há um for que desabilita o botão conforme a variavel DesabilitaBotao.
      
        icone - Função usada para definir qual a imagem do icone e seu tooltip
        clickesquerdo - Função para o evento de clique com o botão esquerdo do mouse encima do Tray Icon
        fechar - Função associada ao botão exit
        ----------------------------------------
        Abaixo disso temos as funções dos botões  
    """
class TrayIconKazzo(wx.adv.TaskBarIcon):
    def __init__(self, frame):
        self.frame = frame
        super().__init__()
        self.icone()
        self.DesabilitaBotao = [2]
        self.Bind(wx.adv.EVT_TASKBAR_LEFT_DOWN, self.clickesquerdo)

    def CreatePopupMenu(self):
        menu = wx.Menu()
        tipomenu = ['Menu', 'Submenu', 'Desabilitar']
        ramais = [-1, 1, 2], ['Ramais', 'Start', 'Stop'], [self.donothing, self.inicia_ramais, self.para_ramais]
        roteadores = [-1, 3, 4, 5, 6], ['Roteadores', 'Escritório', 'Expedição', 'Lavanderia', 'Recebimento'], [self.donothing, self.escritorio, self.expedicao, self.lavanderia, self.recebimento]

        criar_menu(menu, tipomenu[1], ramais[0], ramais[1], ramais[2])
        criar_menu(menu, tipomenu[1], roteadores[0], roteadores[1], roteadores[2])
        criar_menu(menu, tipomenu[0], 3, 'Site', self.site)
        menu.AppendSeparator()
        criar_menu(menu, tipomenu[0], 0, 'Fechar', self.fechar)

        for i in self.DesabilitaBotao:
            if isinstance(i, int):
                menu.Enable(i, False)

        return menu

    # -------------------------------------------------

    def icone(self):
        icon = wx.Icon('C:\\config\\programas\\TIK\\icones\\tik.ico')
        self.SetIcon(icon, 'Kazzo By: Jerbson')

    def clickesquerdo(self, event):
        global visivel
        if visivel:
            visivel = False
            win32gui.ShowWindow(tray, win32con.SW_HIDE)
        else:
            visivel = True
            win32gui.ShowWindow(tray, win32con.SW_SHOW)

    # ------------------------------------------------

    def site(self, event):
        os.system('start "" https://www.macatuba.sp.gov.br/')

    def fechar(self, event):
        wx.CallAfter(self.Destroy)
        self.frame.Close()

    def donothing(self, event):
        pass

    # ------------------------------------------------
    # RAMAIS
    # ------------------------------------------------

    def inicia_ramais(self, event):
        id_inicia = 1
        id_para = 2

        if id_inicia not in self.DesabilitaBotao:
            self.DesabilitaBotao.append(id_inicia)
        if id_para in self.DesabilitaBotao:
            self.DesabilitaBotao.remove(id_para)

        wx.CallLater(1000, Ramais, self.DesabilitaBotao)

    def para_ramais(self, event):
        id_inicia = 1
        id_para = 2

        if id_para not in self.DesabilitaBotao:
            self.DesabilitaBotao.append(id_para)
        if id_inicia in self.DesabilitaBotao:
            self.DesabilitaBotao.remove(id_inicia)
            
        wx.CallLater(1000, Ramais, self.DesabilitaBotao)

    # ------------------------------------------------
    # ROTEADORES
    # ------------------------------------------------
    def escritorio(self, event):
        wx.CallLater(1000, Roteadores, '192.168.197.1')

    def expedicao(self, event):
        wx.CallLater(1000, Roteadores, '192.168.198.1')
        
    def lavanderia(self, event):
        wx.CallLater(1000, Roteadores, '192.168.199.1')
        
    def recebimento(self, event):
        wx.CallLater(1000, Roteadores, '192.168.200.1')

    # ------------------------------------------------

"""
    Classe nativa do 'wx' utilizada para iniciar o aplicativo
    frame - Variavel criada para receber a classe Frame da API 'wx'
    SetTopWindow - Define o frame com tela principal, se ela é fechada, o aplicativo inteiro é fechado.
    TrayIconKazzo - Chama a classe criada anteriormente e passa o parametro com a variável do frame.
    """
class App(wx.App):
    def OnInit(self):
        frame=wx.Frame()
        self.SetTopWindow(frame)
        TrayIconKazzo(frame)
        return True

"""
    Inicia o aplicativo
    """
app = App()
app.MainLoop()
