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

    public partial class frmLancamentos : Form
    {
        private DateTime Vencto;
        private int ID_Venda;
        private double Parc;
        private double Valor;
        private double Total;
        private double Pagamento;
        private double Parcela;

        object cbo1 = -1, cbo2 = -1;


        public frmLancamentos()
        {
            InitializeComponent();
        }

        private void frmLancamentos_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            LimpaCampos();
            configura1();

        }

        private void frmLancamentos_Activated(object sender, EventArgs e)
        {
            Global.ConsultarDespesas("");
            cboDespesa.DataSource = Global.datTabela;
            cboDespesa.DisplayMember = "Despesa";
            cboDespesa.ValueMember = "ID";
            cboDespesa.SelectedIndex = -1;

            Global.ConsultarFornecedores("");
            cboFornecedor.DataSource = Global.datTabela;
            cboFornecedor.DisplayMember = "Razao_Social";
            cboFornecedor.ValueMember = "ID";
            cboFornecedor.SelectedIndex = -1;

            cboDespesa.SelectedValue = cbo1;
            cboFornecedor.SelectedValue = cbo2;
        }

        private void frmLancamentos_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void lklDespesa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDespesas Despesas = new frmDespesas();
            Despesas.Show();
        }

        private void lklFornecedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFornecedores Fornecedores = new frmFornecedores();
            Fornecedores.Show();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboDespesa.Text != "" && cboFornecedor.Text != "")
            {
                cbo1 = cboDespesa.SelectedValue;
                cbo2 = cboFornecedor.SelectedValue;

                mtbValor.Text = "0";
                nudParc.Value = 1;
                dtpMovimento.Value = DateTime.Now;
                dtpVencimento.Value = DateTime.Now;
                configura2();
            }
            else
            {
                MessageBox.Show("Favor selecionar os itens!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mtbValor_TextChanged(object sender, EventArgs e)
        {
            if (mtbValor.Text == "")
                mtbValor.Text = "0";

            Valor = Double.Parse(mtbValor.Text);
            Parc = Double.Parse(nudParc.Value.ToString());

            Total = Valor / Parc; 

            lblTotal.Text = Total.ToString("C");
        }

        private void nudParc_ValueChanged(object sender, EventArgs e)
        {
            if (mtbValor.Text == "")
                mtbValor.Text = "0";

            Valor = Double.Parse(mtbValor.Text);
            Parc = Double.Parse(nudParc.Value.ToString());

            Total = Valor / Parc;

            lblTotal.Text = Total.ToString("C"); 
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (mtbValor.Text == "0")
            {

                MessageBox.Show("Favor preencha o campo com o valor da divida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

                foreach (Control Caixa in grbInformacoes.Controls)
            {
                if (Caixa is TextBox)
                {
                    if (Caixa.Text == "")
                    {
                        Caixa.Text = "0";
                    }
                }
            }

            Pagamento = double.Parse(txtCartao.Text) + double.Parse(txtCheque.Text) + double.Parse(txtDinheiro.Text);

            if (mtbValor.Text == "")
            {
                MessageBox.Show("Favor preencha o campo com o valor da divida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Pagamento.ToString("C") != Total.ToString("C"))
            {
                MessageBox.Show("Valor a ser pago incorreto, favor digite novamente" +
                                "\nValor da divida: " + Total.ToString("C") +
                                "\nTotal pago: " + Pagamento.ToString("C"),
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Global.Conexao.Open();

                Vencto = dtpVencimento.Value;
                Parcela = 1;

                for (int Count = 1; Count <= nudParc.Value; Count++)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO lancamentos (ID_Despesa, ID_Fornecedor, Parcela, Valor, Data_Movimento, " +
                                                        "Data_Vencimento, Data_Pgto, Status) VALUES (?ID_Despesa, ?ID_Fornecedor, ?Parcela, " +
                                                        "?Valor, ?Data_Movimento, ?Data_Vencimento, ?Data_Pgto, ?Status)", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID_Despesa", cboDespesa.SelectedValue);
                    Global.Comando.Parameters.AddWithValue("?ID_Fornecedor", cboFornecedor.SelectedValue);
                    Global.Comando.Parameters.AddWithValue("?Parcela", Parcela);
                    Global.Comando.Parameters.AddWithValue("?Valor", Pagamento);
                    Global.Comando.Parameters.AddWithValue("?Data_Movimento", dtpMovimento.Value);
                    Global.Comando.Parameters.AddWithValue("?Data_Vencimento", Vencto);
                    Global.Comando.Parameters.AddWithValue("?Data_Pgto", "0000-00-00");
                    Global.Comando.Parameters.AddWithValue("?Status", false);
                    Global.Comando.ExecuteNonQuery();

                    Vencto = Vencto.AddMonths(1);

                    if (Count == 1)
                    {
                        Global.Comando = new MySqlCommand("SELECT MAX(ID) from lancamentos", Global.Conexao);
                        ID_Venda = int.Parse(Global.Comando.ExecuteScalar().ToString());
                    }

                    Parcela++;
                }


                Global.Comando = new MySqlCommand("UPDATE lancamentos SET Data_Pgto = ?Data_Pgto, Status = ?Status WHERE ID = ?ID", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?ID", ID_Venda);
                Global.Comando.Parameters.AddWithValue("?Data_Pgto", DateTime.Now);
                Global.Comando.Parameters.AddWithValue("?Status", true);
                Global.Comando.ExecuteNonQuery();

                Global.Comando = new MySqlCommand("INSERT INTO caixa (Data, Dinheiro, Cartao, Cheque, Tipo) VALUES (?Data, ?Dinheiro, ?Cartao, ?Cheque, ?Tipo)", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?Data", DateTime.Now);
                Global.Comando.Parameters.AddWithValue("?Dinheiro", double.Parse(txtDinheiro.Text));
                Global.Comando.Parameters.AddWithValue("?Cartao", double.Parse(txtCartao.Text));
                Global.Comando.Parameters.AddWithValue("?Cheque", double.Parse(txtCheque.Text));
                Global.Comando.Parameters.AddWithValue("?Tipo", 2);
                Global.Comando.ExecuteNonQuery();
                
                Global.Conexao.Close();

                LimpaCampos();
                configura1();

                cboDespesa.SelectedValue = -1;
                cboFornecedor.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            cboDespesa.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;

            configura1();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimpaCampos()
        {
            cboDespesa.SelectedIndex = -1;
            cboFornecedor.SelectedIndex = -1;
            mtbValor.Text = "0";
            nudParc.Value = 1;
            dtpMovimento.Value = DateTime.Now;
            dtpVencimento.Value = DateTime.Now;
            txtCartao.Clear();
            txtDinheiro.Clear();
            txtCheque.Clear();
        }

        private void configura1()
        {
            grbDespesa.Enabled = true;
            grbInformacoes.Enabled = false;
        }

        private void configura2()
        {
            grbDespesa.Enabled = false;
            grbInformacoes.Enabled = true;
        }
    }
}
