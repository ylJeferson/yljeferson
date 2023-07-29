using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeferson_e_Samuel
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }


          // // // // // // // // //
         //  LOAD DO FORMULARIO  //
        // // // // // // // // //
        private void frmSplash_Load(object sender, EventArgs e)
        {
            Global.Load = true;
            Global.AbrirConexao();
            Global.CriaTabelas();
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // // 
        private void frmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


          // // // // // // // // //
         //  BARRA DE PROGRESSO  //
        // // // // // // // // //
        private void tmrTempo_Tick(object sender, EventArgs e)
        {
            if (pbCarregamento.Value < 100)
            {
                pbCarregamento.Value = pbCarregamento.Value + 2;
            }
            else
            {
                tmrTempo.Enabled = false;
                Global.Load = false;
                Close();
            }
        }
    }
}
