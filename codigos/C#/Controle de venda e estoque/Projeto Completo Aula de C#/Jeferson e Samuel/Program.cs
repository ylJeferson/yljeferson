using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeferson_e_Samuel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            frmSplash Carregamento = new frmSplash();
            Carregamento.ShowDialog();

            if (Global.Load == false)
               Application.Run(new frmLogin());
        }
    }
}
