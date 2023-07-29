import wx
import sys
import wx.adv

class TrayIconKazzo(wx.adv.TaskBarIcon):
    def __init__(self, frame):
        self.frame = frame
        super().__init__()
        self.icone()
        self.Bind(wx.adv.EVT_TASKBAR_LEFT_DOWN, self.clickesquerdo)

    # -------------------------------------------------

    def icone(self):
        icon = wx.Icon('C:\\config\\programas\\Robozinho\\imagens\\icons\\trayicon.ico')
        self.SetIcon(icon, 'Tray Icon - By: Jerbson')

    def clickesquerdo(self, event):
        wx.CallAfter(self.Destroy)
        self.frame.Close()
        sys.exit()
        quit()

    # ------------------------------------------------

class App(wx.App):
    def OnInit(self):
        frame=wx.Frame()
        self.SetTopWindow(frame)
        TrayIconKazzo(frame)
        return True

app = App()
app.MainLoop()
