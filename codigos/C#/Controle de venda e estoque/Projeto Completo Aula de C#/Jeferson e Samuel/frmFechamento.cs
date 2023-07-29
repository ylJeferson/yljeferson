using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jeferson_e_Samuel
{
    public partial class frmFechamento : Form
    {
        public frmFechamento()
        {
            InitializeComponent();
        }

        private void frmFechamento_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void frmFechamento_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Conexao.Open();
                Global.Comando = new MySqlCommand("select sum(case when tipo = 1 then dinheiro else 0 end) dinheiroE, " +
                                                  "sum(case when tipo = 1 then cheque else 0 end) chequeE, " +
                                                  "sum(case when tipo = 1 then cartao else 0 end) cartaoE, " +
                                                  "sum(case when tipo = 2 then dinheiro else 0 end) dinheiroS, " +
                                                  "sum(case when tipo = 2 then cheque else 0 end) chequeS, " +
                                                  "sum(case when tipo = 2 then cartao else 0 end) cartaoS " +
                                                  "from caixa where data = ?data", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?data", Convert.ToDateTime(dtpData.Text));
                Global.rConsulta = Global.Comando.ExecuteReader();
                Global.rConsulta.Read(); ;
                if (! DBNull.Value.Equals(Global.rConsulta["dinheiroE"]))
                {
                    lblDinheiroE.Text = Global.rConsulta["dinheiroE"].ToString();
                    lblChequeE.Text = Global.rConsulta["chequeE"].ToString();
                    lblCartaoE.Text = Global.rConsulta["cartaoE"].ToString();
                    lblTotalE.Text = (Convert.ToDouble(lblDinheiroE.Text) + Convert.ToDouble(lblChequeE.Text) + Convert.ToDouble(lblCartaoE.Text)).ToString();

                    lblDinheiroS.Text = Global.rConsulta["dinheiroS"].ToString();
                    lblChequeS.Text = Global.rConsulta["chequeS"].ToString();
                    lblCartaoS.Text = Global.rConsulta["cartaoS"].ToString();
                    lblTotalS.Text = (Convert.ToDouble(lblDinheiroS.Text) + Convert.ToDouble(lblChequeS.Text) + Convert.ToDouble(lblCartaoS.Text)).ToString();

                    lblDinheiroT.Text = (Convert.ToDouble(lblDinheiroE.Text) - Convert.ToDouble(lblDinheiroS.Text)).ToString();
                    lblChequeT.Text = (Convert.ToDouble(lblChequeE.Text) - Convert.ToDouble(lblChequeS.Text)).ToString();
                    lblCartaoT.Text = (Convert.ToDouble(lblCartaoE.Text) - Convert.ToDouble(lblCartaoS.Text)).ToString();
                    lblTotalT.Text = (Convert.ToDouble(lblTotalE.Text) - Convert.ToDouble(lblTotalS.Text)).ToString();
                }
                Global.Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.WindowState = FormWindowState.Maximized;

            printPreviewDialog1.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Resumo do Caixa", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, 230, 10);
            e.Graphics.DrawLine(Pens.Black, 100, 90, 720, 90);
            e.Graphics.DrawString("Entradas", new Font("Arial", 20), Brushes.Black, 100, 120);

            e.Graphics.DrawString("Dinheiro:", new Font("Arial", 10), Brushes.Black, 100, 180);
            e.Graphics.DrawString(lblDinheiroE.Text, new Font("Arial", 10), Brushes.Black, 300, 180);
            e.Graphics.DrawString("Cheque:", new Font("Arial", 10), Brushes.Black, 100, 240);
            e.Graphics.DrawString(lblChequeE.Text, new Font("Arial", 10), Brushes.Black, 300, 240);
            e.Graphics.DrawString("Cartão:", new Font("Arial", 10), Brushes.Black, 100, 300);
            e.Graphics.DrawString(lblCartaoE.Text, new Font("Arial", 10), Brushes.Black, 300, 300);
            e.Graphics.DrawString("Total:", new Font("Arial", 10), Brushes.Black, 100, 360);
            e.Graphics.DrawString(lblTotalE.Text, new Font("Arial", 10), Brushes.Black, 300, 360);

            e.Graphics.DrawLine(Pens.Black, 100, 390, 720, 390);
            e.Graphics.DrawString("Saidas", new Font("Arial", 20), Brushes.Black, 100, 420);
            e.Graphics.DrawString("Dinheiro:", new Font("Arial", 10), Brushes.Black, 100, 480);
            e.Graphics.DrawString(lblDinheiroS.Text, new Font("Arial", 10), Brushes.Black, 300, 480);
            e.Graphics.DrawString("Cheque:", new Font("Arial", 10), Brushes.Black, 100, 540);
            e.Graphics.DrawString(lblChequeS.Text, new Font("Arial", 10), Brushes.Black, 300, 540);
            e.Graphics.DrawString("Cartão:", new Font("Arial", 10), Brushes.Black, 100, 600);
            e.Graphics.DrawString(lblCartaoS.Text, new Font("Arial", 10), Brushes.Black, 300, 600);
            e.Graphics.DrawString("Total:", new Font("Arial", 10), Brushes.Black, 100, 660);
            e.Graphics.DrawString(lblTotalS.Text, new Font("Arial", 10), Brushes.Black, 300, 660);

            e.Graphics.DrawLine(Pens.Black, 100, 690, 720, 690);
            e.Graphics.DrawString("Resumo", new Font("Arial", 20), Brushes.Black, 100, 720);
            e.Graphics.DrawString("Dinheiro:", new Font("Arial", 10), Brushes.Black, 100, 780);
            e.Graphics.DrawString(lblDinheiroT.Text, new Font("Arial", 10), Brushes.Black, 300, 780);
            e.Graphics.DrawString("Cheque:", new Font("Arial", 10), Brushes.Black, 100, 840);
            e.Graphics.DrawString(lblChequeT.Text, new Font("Arial", 10), Brushes.Black, 300, 840);
            e.Graphics.DrawString("Cartão:", new Font("Arial", 10), Brushes.Black, 100, 900);
            e.Graphics.DrawString(lblCartaoT.Text, new Font("Arial", 10), Brushes.Black, 300, 900);
            e.Graphics.DrawString("Total:", new Font("Arial", 10), Brushes.Black, 100, 960);
            e.Graphics.DrawString(lblTotalT.Text, new Font("Arial", 10), Brushes.Black, 300, 960);

            e.Graphics.DrawLine(Pens.Black, 100, 1060, 720, 1060);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), new Font("Verdana", 10), Brushes.Black, 100, 1065);
            e.Graphics.DrawLine(Pens.Black, 100, 1090, 720, 1090);
        }
    }
}
