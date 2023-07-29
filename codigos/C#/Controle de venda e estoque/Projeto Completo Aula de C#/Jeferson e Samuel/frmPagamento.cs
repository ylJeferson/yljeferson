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
    public partial class frmPagamento : Form
    {
        double Total;
        double Pagamento;
        int TesteDGV;

        object cbo1 = -1;
        public frmPagamento()
        {
            InitializeComponent();
        }


        // // // // // // // // // 
        //  LOAD DO FORMULARIO  //
        // // // // // // // // //  
        private void frmCaixa_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            txtData.Text = DateTime.Now.ToShortDateString();

            Travar();
            Esconde();
        }

        private void frmLancamentos_Activated(object sender, EventArgs e)
        {
            Global.ConsultarFornecedores("");
            cboFornecedor.DataSource = Global.datTabela;
            cboFornecedor.DisplayMember = "Razao_Social";
            cboFornecedor.ValueMember = "ID";
            cboFornecedor.SelectedIndex = -1;

            cboFornecedor.SelectedValue = cbo1;
        }


        // // // // // // // // // // //
        //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // //
        private void frmCaixa_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        // // // // // // // // // // // //
        //  COMBOBOX SELECAO DO CLIENTE  //
        // // // // // // // // // // // //
        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCarregar.Enabled = true;
        }


        // // // // // // // // // // // // // // // // // // // //
        //   BOTAO PARA CARREGAR INFORMAÇÕES DO CLIENTE NA DGV   //
        // // // // // // // // // // // // // // // // // // // //
        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (cboFornecedor.Text == "")
            {
                MessageBox.Show("Favor Selecione as informações!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Global.ConsultarLancamentos(cboFornecedor.Text);
            dgvTitulos.DataSource = Global.datTabela;

            Selecionados();

            if (dgvTitulos.RowCount == 0)
            {
                MessageBox.Show("Não há dividas em aberto com o fornecedor: " + cboFornecedor.Text +
                                "\nCancelando consulta ...", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Travar();
                return;
            }

            cbo1 = cboFornecedor.SelectedValue;
            Liberar();
        }


        // // // // // // // // // // // // // // // // // // //
        //  BOTÃO PARA SELECIONAR O PRIMEIRO REGISTRO NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            dgvTitulos.CurrentCell = dgvTitulos[0, 0];
        }


        // // // // // // // // // // // // // // // // // // //
        //  BOTÃO PARA SELECIONAR O REGISTRO ANTERIOR NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (dgvTitulos.CurrentRow.Index > 0)
            {
                dgvTitulos.CurrentCell = dgvTitulos[0, dgvTitulos.CurrentCell.RowIndex - 1];
            }
        }


        // // // // // // // // // // // // // // // // // // 
        // BOTÃO PARA SELECIONAR O PROXIMO REGISTRO NO DGV //
        // // // // // // // // // // // // // // // // // // 
        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (dgvTitulos.CurrentRow.Index < (dgvTitulos.RowCount - 1))
            {
                dgvTitulos.CurrentCell = dgvTitulos[0, dgvTitulos.CurrentCell.RowIndex + 1];
            }
        }


        // // // // // // // // // // // // // // // // // // //
        //   BOTÃO PARA SELECIONAR O ULTIMO REGISTRO NO DGV   //
        // // // // // // // // // // // // // // // // // // // 
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            dgvTitulos.CurrentCell = dgvTitulos[0, dgvTitulos.RowCount - 1];
        }


        // // // // // // // // // // // // // // // // // 
        //   BOTAO PARA MARCAR O CHECKBOX SELECIONADO   //
        // // // // // // // // // // // // // // // // // 
        private void btnMarca_Click(object sender, EventArgs e)
        {
            dgvTitulos.CurrentRow.Cells[0].Value = true;

            Selecionados();
        }


        // // // // // // // // // // // // // // // // // //
        //   BOTAO PARA DESMARCAR O CHECKBOX SELECIONADO   //
        // // // // // // // // // // // // // // // // // //
        private void btnDesmarca_Click(object sender, EventArgs e)
        {
            dgvTitulos.CurrentRow.Cells[0].Value = false;

            Selecionados();
        }


        // // // // // // // // // // // // // // // // //
        //  BOTAO PARA MARCAR TODOS OS CHECKBOX NA DGV  //
        // // // // // // // // // // // // // // // // //
        private void btnMarcar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Linha in dgvTitulos.Rows)
            {
                Linha.Cells[0].Value = true;
            }

            Selecionados();

        }


        // // // // // // // // // // // // // // // // // // 
        //  BOTAO PARA DESMARCAR TODOS OS CHECKBOX NA DGV  //
        // // // // // // // // // // // // // // // // // //  
        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Linha in dgvTitulos.Rows)
            {
                Linha.Cells[0].Value = false;
            }

            Selecionados();
        }


        // // // // // 
        //  DGV ¬¬  //
        // // // // // 
        private void dgvTitulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTitulos.EndEdit();
            Selecionados();
        }


        // // // // // // // // // // // // // // //
        //  BOTAO PARA INSERIR NO BANCO DE DADOS  //
        // // // // // // // // // // // // // // //
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                TesteDGV = 0;

                foreach (DataGridViewRow Linha in dgvTitulos.Rows)
                {
                    if (bool.Parse(Linha.Cells[0].Value.ToString()) == true)
                    {
                        TesteDGV += 1;
                    }
                }

                if (TesteDGV == 0)
                {
                    MessageBox.Show("Favor selecione alguma das dividas listadas na tabela!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                foreach (Control Caixa in grbCaixa.Controls)
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

                if (Pagamento.ToString("C") != Total.ToString("C"))
                {
                    MessageBox.Show("Valor a ser pago incorreto, favor digite novamente" +
                                    "\nValor da divida: " + Total.ToString("C") +
                                    "\nTotal pago: " + Pagamento.ToString("C"),
                                    "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    foreach (Control Caixa in grbCaixa.Controls)
                    {
                        if (Caixa is TextBox)
                        {
                            if (Caixa.Text == "0")
                            {
                                Caixa.Text = "";
                            }
                        }
                    }

                    return;
                }

                Global.Conexao.Open();

                foreach (DataGridViewRow Linha in dgvTitulos.Rows)
                {
                    if (bool.Parse(Linha.Cells[0].Value.ToString()) == true)
                    {
                        Global.Comando = new MySqlCommand("UPDATE lancamentos la " +
                                                          "INNER JOIN despesas dp ON dp.ID = la.ID_Despesa " +
                                                          "SET la.Status = ?Status, la.Data_Pgto = ?Data_Pgto " +
                                                          "WHERE dp.Descricao = ?Descricao AND la.Parcela = ?Parcela", Global.Conexao);
                        Global.Comando.Parameters.AddWithValue("?Status", true);
                        Global.Comando.Parameters.AddWithValue("?Data_Pgto", DateTime.Parse(txtData.Text));
                        Global.Comando.Parameters.AddWithValue("?Descricao", Linha.Cells[1].Value.ToString());
                        Global.Comando.Parameters.AddWithValue("?Parcela", int.Parse(Linha.Cells[2].Value.ToString()));
                        Global.Comando.ExecuteNonQuery();
                    }
                }

                Global.Comando = new MySqlCommand("INSERT INTO caixa (Data, Dinheiro, Cartao, Cheque, Tipo) VALUES (?Data, ?Dinheiro, ?Cartao, ?Cheque, ?Tipo)", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?Data", DateTime.Parse(txtData.Text));
                Global.Comando.Parameters.AddWithValue("?Dinheiro", double.Parse(txtDinheiro.Text));
                Global.Comando.Parameters.AddWithValue("?Cartao", double.Parse(txtCartao.Text));
                Global.Comando.Parameters.AddWithValue("?Cheque", double.Parse(txtCheque.Text));
                Global.Comando.Parameters.AddWithValue("?Tipo", 2);
                Global.Comando.ExecuteNonQuery();

                Global.Conexao.Close();

                /*
                if (MessageBox.Show("Deseja fazer outro pagamento?", "Novo lançamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    txtCartao.Clear();
                    txtCheque.Clear();
                    txtDinheiro.Clear();

                    Global.ContasAReceber(cboClientes.Text);
                    dgvTitulos.DataSource = Global.datTabela;
                    Selecionados();

                    if (dgvTitulos.RowCount == 0)
                    {
                        MessageBox.Show("O Cliente: " + cboClientes.Text + ", não apresenta nenhuma divida em aberto!" +
                                        "\nCancelando consulta ...", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Travar();
                        return;
                    }
                }
                else
                {
                    Selecionados();
                    Travar();
                }
                */

                Travar();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }


        // // // // // // // // // // 
        //   BOTAO PARA CANCELAR   //
        // // // // // // // // // //  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Travar();
        }


        // // // // // // // // // // // // // // // 
        //  BOTÃO PARA FECHAR O FORMULARIO ATUAL  //
        // // // // // // // // // // // // // // // 
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }


        // // // // // // // // // //
        // VOID PARA TRAVAR O FORM //
        // // // // // // // // // // 
        private void Travar()
        {
            cboFornecedor.SelectedIndex = -1;

            grbClientes.Enabled = true;
            grbCaixa.Enabled = false;

            btnPrimeiro.Enabled = false;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;

            btnMarca.Enabled = false;
            btnDesmarca.Enabled = false;

            btnMarcar.Enabled = false;
            btnDesmarcar.Enabled = false;
            btnGravar.Enabled = false;

            txtCartao.Clear();
            txtCheque.Clear();
            txtDinheiro.Clear();

            dgvTitulos.DataSource = null;

            Total = 0;
            lblSelecao.Text = Total.ToString("C");
        }


        // // // // // // // // // // //
        //  VOID PARA LIBERAR O FORM  //
        // // // // // // // // // // //
        private void Liberar()
        {
            grbClientes.Enabled = false;
            grbCaixa.Enabled = true;

            btnPrimeiro.Enabled = true;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;

            btnMarca.Enabled = true;
            btnDesmarca.Enabled = true;

            btnMarcar.Enabled = true;
            btnDesmarcar.Enabled = true;
            btnGravar.Enabled = true;

            txtCartao.Clear();
            txtCheque.Clear();
            txtDinheiro.Clear();
        }


        // // // // // // // // // // // // // // //
        //  VOID PARA SOMAR O VALOR DO PAGAMENTO  //
        // // // // // // // // // // // // // // //
        private void Selecionados()
        {
            Total = 0;

            foreach (DataGridViewRow Linha in dgvTitulos.Rows)
            {
                if (bool.Parse(Linha.Cells[0].Value.ToString()) == true)
                {
                    Total += double.Parse(Linha.Cells[3].Value.ToString());
                }
            }

            lblSelecao.Text = Total.ToString("C");
        }


        // // // // // // // // // // // // // // // // // // // // // //
        //  VOID PARA DEIXAR INVISIVEL OS BOTOES DE INTERAÇÃO COM DGV  //
        // // // // // // // // // // // // // // // // // // // // // //
        private void Esconde()
        {
            btnMarca.Visible = false;
            btnDesmarca.Visible = false;

            btnPrimeiro.Visible = false;
            btnAnterior.Visible = false;
            btnProximo.Visible = false;
            btnUltimo.Visible = false;
        }
    }
}
