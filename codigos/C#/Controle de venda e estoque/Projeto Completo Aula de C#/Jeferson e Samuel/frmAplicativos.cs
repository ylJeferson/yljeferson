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
    public partial class frmAplicativos : Form
    {
        public frmAplicativos()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmAplicativos_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // // 
        private void frmAplicativos_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        // // // // // // // // // 
        //  ABRE A CALCULADORA  //
        // // // // // // // // // 
        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // //
         //  ABRE O BLOCO DE NOTAS  //
        // // // // // // // // // //
        private void btnNotepad_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // // // // // //
         //  ABRE O INTERNET EXPLORER NO SITE DA GOOGLE  //
        // // // // // // // // // // // // // // // // //
        private void btnNavegador_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore", "www.google.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // //
         //  ABRE O MICROSFOT WORD  //
        // // // // // // // // // //
        private void btnWord_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("winword");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
