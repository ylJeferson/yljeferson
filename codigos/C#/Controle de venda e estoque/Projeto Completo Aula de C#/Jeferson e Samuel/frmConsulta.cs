using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jeferson_e_Samuel
{
    public partial class frmConsulta : Form
    {
        DateTime DataShort;
        String relatorio;

        public frmConsulta()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // //
        private void frmConsulta_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Global.ConsultarProdutos("");
            cboProdutos.DataSource = Global.datTabela;
            cboProdutos.DisplayMember = "Descricao";
            cboProdutos.ValueMember = "ID";
            cboProdutos.SelectedIndex = -1;

            dtpInicio.Value = DateTime.Now;
            dtpFim.Value = DateTime.Now;
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // // 
        private void frmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


          // // // // // // // // // // // 
         // BOTAO DE CONSULTA NO BANCO //
        // // // // // // // // // // //
        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                relatorio = cboProdutos.Text;

                Global.ConsultarVendas(cboProdutos.Text, dtpInicio.Value, dtpFim.Value);
                dgvConsulta.DataSource = Global.datTabela;}
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // 
         // BOTAO IMPRIMIR //
        // // // // // // //
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Configura a janela de visualização no modo maximizado.
                ppdVisualizar.WindowState = FormWindowState.Maximized;
                // Abre a tela de visualização do relatório.
                ppdVisualizar.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // //
         //   BOTAO DE FECHAR O FORMULARIO   //
        // // // // // // // // // // // // //
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }


          // // // // // // // // // // // // // // //
         //     VOID DE CONFIGURAÇÃO DA PÁGINA     //
        // // // // // // // // // // // // // // //  
        private void pdoImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicao, itens = 0;

            // Desenvolvimento do cabeçalho do relatório
            using (Font fonte = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point))
            {
                //O string format serve para formatar strings
                //quanto a seu alinhamento e o proprio alinhamento da linha
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                SolidBrush cor = new SolidBrush(Color.Black);
                //Captura todo o retângulo dos limites da página
                RectangleF larg_da_pag = e.PageBounds;
                //Aumenta a coordenada de localização Y
                larg_da_pag.Y += 30;
                //Desenhar texto centralizado
                e.Graphics.DrawString(relatorio, fonte, cor, larg_da_pag, sf);
            }

            e.Graphics.DrawLine(Pens.Black, 100, 90, 725, 90);
            e.Graphics.DrawString("Código", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 105, 95);
            e.Graphics.DrawString("Data", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 195, 95);
            e.Graphics.DrawString("Nome do Cliente", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 260, 95);
            e.Graphics.DrawString("Quantidade", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 520, 95);
            e.Graphics.DrawString("Valor Unit", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 635, 95);
            e.Graphics.DrawLine(Pens.Black, 100, 120, 725, 120);
            // Desenvolvimento da interface do corpo do relatório
            posicao = 100;
            foreach (DataGridViewRow linha in dgvConsulta.Rows)
            {
                DataShort = DateTime.Parse(linha.Cells[1].Value.ToString());

                if (itens > 30)
                {
                    e.HasMorePages = true;
                    return;
                }
                posicao += 25;
                e.Graphics.DrawString(linha.Cells[0].Value.ToString(), new Font("Arial", 10), Brushes.Black, 128, posicao);
                e.Graphics.DrawString(DataShort.ToShortDateString(), new Font("Arial", 10), Brushes.Black, 180, posicao);
                e.Graphics.DrawString(linha.Cells[2].Value.ToString(), new Font("Arial", 10), Brushes.Black, 265, posicao);
                e.Graphics.DrawString(linha.Cells[3].Value.ToString(), new Font("Arial", 10), Brushes.Black, 560, posicao);
                e.Graphics.DrawString(linha.Cells[4].Value.ToString(), new Font("Arial", 10), Brushes.Black, 670, posicao);
                itens += 1;
            }
            // Desenvolvimento da interface do rodapé do relatório
            e.Graphics.DrawLine(Pens.Black, 100, 1110, 725, 1110);
            e.Graphics.DrawString("Total de vendas:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 105, 1115);
            e.Graphics.DrawString(dgvConsulta.RowCount.ToString(), new Font("Arial", 12), Brushes.Black, 265, 1115);
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("Verdana", 12), Brushes.Black, 527, 1115);
            e.Graphics.DrawLine(Pens.Black, 100, 1140, 725, 1140);
        }
    }
}
