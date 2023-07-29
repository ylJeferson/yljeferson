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
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // //  
        private void frmBackup_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // //
        private void frmBackup_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


          // // // // // // // // 
         //  BOTAO DE BACKUP  //
        // // // // // // // // 
        private void btnBackup_Click(object sender, EventArgs e)
        {
            sfdBackup.Title = "BACKUP";
            sfdBackup.Filter = "BACKUP DO SISTEMA (*.SQL)|*.SQL";
            sfdBackup.DefaultExt = ".SQL";
            sfdBackup.InitialDirectory = Application.StartupPath + "\\BACKUP\\";
            sfdBackup.ShowDialog();

            try
            {
                System.Diagnostics.Process.Start("cmd.exe", "/C mysqldump -uroot -petecjau bd_projeto > " + sfdBackup.FileName + "");
                MessageBox.Show("Backup finalizado com sucesso", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // //
         // BOTAO DE RESTAURAÇÃO //
        // // // // // // // // //
        private void btnRestauracao_Click(object sender, EventArgs e)
        {
            ofdRestauracao.Title = "RESTAURAÇÃO";
            ofdRestauracao.Filter = "BACKUP DO SISTEMA (*.SQL)|*.SQL";
            ofdRestauracao.FileName = "";
            ofdRestauracao.InitialDirectory = Application.StartupPath + "\\BACKUP\\";
            ofdRestauracao.ShowDialog();

            Global.AbrirConexao();

            try
            {
                if (ofdRestauracao.FileName != "")
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/C mysqldump -uroot -petecjau bd_projeto < " + ofdRestauracao.FileName + "");
                    MessageBox.Show("Reatauração finalizado com sucesso", "Reatauração", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
