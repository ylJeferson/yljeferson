using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeferson_e_Samuel
{
    public partial class frmVendas : Form
    {
        string pcbimg;

        double Qtde;
        double Venda;
        double Total;
        double ValorParc;

        int Linhas;
        int ID_Venda;
        int Count;
        int NParc;

        DateTime Vencto;

        public frmVendas()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmVendas_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            cboClientes.SelectedIndex = -1;
            cboProdutos.SelectedIndex = -1;

            txtData.Text = DateTime.Now.ToShortDateString();

            txtVendedor.Text = Global.Usuario;

            Global.ConsultarClientes("");
            cboClientes.DataSource = Global.datTabela;
            cboClientes.DisplayMember = "Nome";
            cboClientes.ValueMember = "ID";

            Global.ConsultarProdutos("");
            cboProdutos.DataSource = Global.datTabela;
            cboProdutos.DisplayMember = "Descricao";
            cboProdutos.ValueMember = "ID";

            btnCancelar.PerformClick();
        }


          // // // // // // // // // // //
         //   MOSTRANDO O FORMULARIO   //
        // // // // // // // // // // //
        private void frmVendas_Shown(object sender, EventArgs e)
        {
            LimparVenda();
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // //
        private void frmVendas_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


          // // // // // // // // // // //
         //   BOTAO CONFIRMAR CLIENTE  //
        // // // // // // // // // // //
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            grbProdutos.Enabled = true;
            btnGravar.Enabled = true;
            grbClientes.Enabled = false;
        }


          // // // // // // // // // 
         //  BOTAO PARA INSERIR  //
        // // // // // // // // //
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (cboProdutos.SelectedIndex == -1)
            {
                MessageBox.Show("Favor selecione o produto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtQuantidade.Text == "")
            {
                MessageBox.Show("Favor preencha todos os campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Qtde = double.Parse(txtQuantidade.Text);
                Venda = double.Parse(txtPreco.Text);

                Total += Qtde * Venda;

                dgvProdutos.Rows.Add(cboProdutos.SelectedValue, cboProdutos.Text, txtPreco.Text, txtQuantidade.Text);
                lblTotal.Text = Total.ToString("C");

                LimparProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


          // // // // // // // // // 
         //  BOTAO PARA REMOVER  //
        // // // // // // // // //
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                Total -= Double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString()) * Double.Parse(dgvProdutos.CurrentRow.Cells[3].Value.ToString());

                lblTotal.Text = Total.ToString("C");

                dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index);

                cboProdutos.SelectedIndex = -1;
                pcbFoto.ImageLocation = "";
                txtQuantidade.Clear();
                txtPreco.Clear();
                txtEstoque.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


          // // // // // // // // // // // // // // //
         //  BOTAO PARA INSERIR NO BANCO DE DADOS  //
        // // // // // // // // // // // // // // //
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdutos.Rows.Count <= 0)
                {
                    MessageBox.Show("Por favor, insira algum item no carrinho!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Global.Conexao.Open();

                Global.Comando = new MySqlCommand("INSERT INTO Venda_cab (ID_Cliente, Data, Total, ID_Vendedor) VALUES (?ID_Cliente, ?Data, ?Total, ?ID_Vendedor)", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?ID_Cliente", cboClientes.SelectedValue);
                Global.Comando.Parameters.AddWithValue("?Data", DateTime.Parse(txtData.Text));
                Global.Comando.Parameters.AddWithValue("?Total", Total);
                Global.Comando.Parameters.AddWithValue("?ID_Vendedor", Global.ID_Usuario);
                Global.Comando.ExecuteNonQuery();

                //*
                Global.Comando = new MySqlCommand("SELECT MAX(ID) from Venda_cab", Global.Conexao);
                ID_Venda = int.Parse(Global.Comando.ExecuteScalar().ToString());
                //*/

                //ID_Venda = Convert.ToInt32(Global.Comando.LastInsertedId);

                Linhas = dgvProdutos.Rows.Count;

                //*
                foreach (DataGridViewRow Linha in dgvProdutos.Rows)
                {
                    //FUNÇÃO PARA ADICIONAR AO VENDA_DET
                    Global.Comando = new MySqlCommand("UPDATE Produtos SET Estoque = Estoque - ?Qtde WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", Linha.Cells[0].Value);
                    Global.Comando.Parameters.AddWithValue("?Qtde", Linha.Cells[3].Value);
                    Global.Comando.ExecuteNonQuery();

                    //FUNÇÃO PARA ADICIONAR AO VENDA_DET
                    Global.Comando = new MySqlCommand("INSERT INTO Venda_det (ID_Venda, ID_Produto, Qtde, Vlr_Unit) VALUES (?ID_Venda, ?ID_Produto, ?Qtde, ?Vlr_Unit)", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID_Venda", ID_Venda);
                    Global.Comando.Parameters.AddWithValue("?ID_Produto", Linha.Cells[0].Value);
                    Global.Comando.Parameters.AddWithValue("?Qtde", Linha.Cells[3].Value);
                    Global.Comando.Parameters.AddWithValue("?Vlr_Unit", Double.Parse(Linha.Cells[2].Value.ToString()));
                    Global.Comando.ExecuteNonQuery();
                }
                //*/
                /*
                for (Count = 1; Count <= Linhas; Count++)
                {
                    //FUNÇÃO PARA ADICIONAR AO VENDA_DET
                    Global.Comando = new MySqlCommand("UPDATE Produtos SET Estoque = Estoque - ?Qtde WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", Linha.Cells[0].Value);
                    Global.Comando.Parameters.AddWithValue("?Qtde", Linha.Cells[3].Value);
                    Global.Comando.ExecuteNonQuery();

                    //FUNÇÃO PARA ADICIONAR AO VENDA_DET
                    Global.Comando = new MySqlCommand("INSERT INTO Venda_det (ID_Venda, ID_Produto, Qtde, Vlr_Unit) VALUES (?ID_Venda, ?ID_Produto, ?Qtde, ?Vlr_Unit)", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID_Venda", ID_Venda);
                    Global.Comando.Parameters.AddWithValue("?ID_Produto", Linha.Cells[0].Value);
                    Global.Comando.Parameters.AddWithValue("?Qtde", Linha.Cells[3].Value);
                    Global.Comando.Parameters.AddWithValue("?Vlr_Unit", Double.Parse(Linha.Cells[2].Value.ToString()));
                    Global.Comando.ExecuteNonQuery();

                    dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index);
                }
                //*/
                /*
                while (Count <= Linhas)
                {
                    //FUNÇÃO PARA ADICIONAR AO VENDA_DET
                    Global.Comando = new MySqlCommand("UPDATE Produtos SET Estoque = Estoque - ?Qtde WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", Linha.Cells[0].Value);
                    Global.Comando.Parameters.AddWithValue("?Qtde", Linha.Cells[3].Value);
                    Global.Comando.ExecuteNonQuery();

                    //FUNÇÃO PARA ADICIONAR AO VENDA_DET
                    Global.Comando = new MySqlCommand("INSERT INTO Venda_det (ID_Venda, ID_Produto, Qtde, Vlr_Unit) VALUES (?ID_Venda, ?ID_Produto, ?Qtde, ?Vlr_Unit)", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID_Venda", ID_Venda);
                    Global.Comando.Parameters.AddWithValue("?ID_Produto", Linha.Cells[0].Value);
                    Global.Comando.Parameters.AddWithValue("?Qtde", Linha.Cells[3].Value);
                    Global.Comando.Parameters.AddWithValue("?Vlr_Unit", Double.Parse(Linha.Cells[2].Value.ToString()));
                    Global.Comando.ExecuteNonQuery();

                    dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentRow.Index);
                    Count++;
                }
                //*/

                // GERA AS PARCELAS DO CONTAS A RECEBER
                NParc = Convert.ToInt16(nudParc.Value);
                Vencto = DateTime.Parse(txtData.Text);
                ValorParc = Total / NParc;

                for (Count = 1; Count <= NParc; Count++)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO Contas_Receber(ID_Venda, ID_Cliente, Parcela, Data_Venda, Data_Vencto, Data_Pgto, Vlr_Parcela, Status) VALUES (?ID_Venda, ?ID_Cliente, ?Parcela, ?Data_Venda, ?Data_Vencto, ?Data_Pgto, ?Vlr_Parcela, ?Status)", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID_Venda", ID_Venda);
                    Global.Comando.Parameters.AddWithValue("?ID_Cliente", cboClientes.SelectedValue);
                    Global.Comando.Parameters.AddWithValue("?Parcela", Convert.ToInt32(Count));
                    Global.Comando.Parameters.AddWithValue("?Data_Venda", DateTime.Parse(txtData.Text));
                    Global.Comando.Parameters.AddWithValue("?Data_Vencto", Convert.ToDateTime(Vencto));
                    Global.Comando.Parameters.AddWithValue("?Data_Pgto", "0000-00-00");
                    Global.Comando.Parameters.AddWithValue("?Vlr_Parcela", Convert.ToDouble(ValorParc));
                    Global.Comando.Parameters.AddWithValue("?Status", false);
                    Global.Comando.ExecuteNonQuery();
                    Vencto = Vencto.AddMonths(1);
                }

                Global.Conexao.Close();
                LimparVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Global.Conexao.Close();
            }
        }


          // // // // // // // // // // // // 
         //  BOTAO PARA CANCELAR A VENDA  //
        // // // // // // // // // // // // 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparVenda();
        }


          // // // // // // // // // // // // // 
         //  BOTAO PARA FECHAR O FORMULARIO  //
        // // // // // // // // // // // // //  
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }


          // // // // // // // // // // // //
         //  COMBOBOX SELECAO DO CLIENTE  //
        // // // // // // // // // // // //
        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = true;
        }


          // // // // // // // // // // // //
         //  COMBOBOX SELECAO DO PRODUTO  //
        // // // // // // // // // // // //
        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.ConsultarProdutos(cboProdutos.Text);

            if (Global.datTabela.Rows.Count > 0)
            {
                txtPreco.Text = Global.datTabela.Rows[0].Field<decimal>("vlr_venda").ToString();
                txtEstoque.Text = Global.datTabela.Rows[0].Field<decimal>("estoque").ToString();
                pcbimg = Global.datTabela.Rows[0].Field<string>("Imagem").ToString();

                if (pcbimg != null)
                {
                    pcbFoto.ImageLocation = pcbimg;
                }
            }
        }


          // // // // // // // // // // //
         //  VOID PARA LIMPAR A VENDA  //
        // // // // // // // // // // // 
        private void LimparVenda()
        {
            txtData.Text = DateTime.Now.ToShortDateString();
            txtVendedor.Text = Global.Usuario;

            cboClientes.SelectedIndex = -1;

            Total = 0;
            lblTotal.Text = Total.ToString("C");

            dgvProdutos.Rows.Clear();
            nudParc.Value = 1;

            grbProdutos.Enabled = false;
            grbClientes.Enabled = true;
            btnConfirmar.Enabled = false;
            btnGravar.Enabled = false;

            dgvProdutos.ColumnCount = 4;
            dgvProdutos.Columns[0].Name = "Produto";
            dgvProdutos.Columns[1].Name = "Descrição";
            dgvProdutos.Columns[2].Name = "Preço Unit.";
            dgvProdutos.Columns[3].Name = "Quantidade";
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LimparProduto();
        }


          // // // // // // // // // // //
         //  VOID PARA LIMPAR PRODUTO  //
        // // // // // // // // // // // 
        private void LimparProduto()
        {
            cboProdutos.SelectedIndex = -1;

            txtEstoque.Clear();
            txtQuantidade.Clear();
            txtPreco.Clear();
            cboProdutos.Focus();

            pcbFoto.ImageLocation = "";
        }


          // // // // // 
         //  DGV ¬¬  //
        // // // // // 
        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboProdutos.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
            txtQuantidade.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
