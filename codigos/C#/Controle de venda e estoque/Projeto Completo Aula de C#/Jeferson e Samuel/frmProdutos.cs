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
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmProdutos_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Configura1();
            LimpaCampos();
            tsbBusca.PerformClick();
        }


          // // // // // // // // // // //
         //   ATIVAÇAO DO FORMULARIO   //
        // // // // // // // // // // //
        private void frmProdutos_Activated(object sender, EventArgs e)
        {
            Global.ConsultarCategorias("");
            cboCategorias.DataSource = Global.datTabela;
            cboCategorias.DisplayMember = "Descricao";
            cboCategorias.ValueMember = "ID";
            cboCategorias.Text = "";

            Global.ConsultarFornecedores("");
            cboFornecedores.DataSource = Global.datTabela;
            cboFornecedores.DisplayMember = "Razao_Social";
            cboFornecedores.ValueMember = "ID";
            cboFornecedores.Text = "";
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // //
        private void frmProdutos_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


          // // // // // // // // // // // // // // // //
         //    BOTÃO PARA INICIAR UM NOVO CADASTRO    //
        // // // // // // // // // // // // // // // //
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Configura2();
            LimpaCampos();
            txtDescricao.Focus();
            Global.Operacao = 1;
        }


          // // // // // // // // // // // // // // 
         //    BOTÃO PARA EDITAR UM CADASTRO    //
        // // // // // // // // // // // // // // 
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            { 
                if (txtID.Text == "")
                {
                    MessageBox.Show("Favor, selecione algum registro na tabela!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Global.Operacao = 2;
                    Configura2();
                }

            }
            else
            {
                MessageBox.Show("Não há nenhum registro no banco", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
}


          // // // // // // // // // // // // // // //
         //  BOTÃO PARA CANCELAR O PROCESSO ATUAL  //
        // // // // // // // // // // // // // // //
        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Configura1();
            LimpaCampos();
            tsbBusca.PerformClick();
        }


          // // // // // // // // // // // // // // // //
         //  BOTÃO PARA INSERIR INFORMAÇÕES NO BANCO  //
        // // // // // // // // // // // // // // // //
        private void tsbGravar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
                return;
            }

            try
            {
                Global.Conexao.Open();

                if (Global.Operacao == 1)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO Produtos (Descricao, Cod_Barra, ID_Categoria, ID_Fornecedor, Estoque, Est_Minimo, Vlr_Custo, Vlr_Venda, Imagem, Video) " +
                                                      "VALUES (?Descricao, ?Cod_Barra, ?ID_Categoria, ?ID_Fornecedor, ?Estoque, ?Est_Minimo, ?Vlr_Custo, ?Vlr_Venda, ?Imagem, ?Video)", Global.Conexao);
                }

                if (Global.Operacao == 2)
                {
                    Global.Comando = new MySqlCommand("UPDATE Produtos SET Descricao = ?Descricao, Cod_Barra = ?Cod_Barra, ID_Categoria = ?ID_Categoria, ID_Fornecedor = ?ID_Fornecedor, Estoque = ?Estoque, Est_Minimo = ?Est_Minimo, Vlr_Custo = ?Vlr_Custo, Vlr_Venda = ?Vlr_Venda, Imagem = ?Imagem, Video = ?Video WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                }

                Global.Comando.Parameters.AddWithValue("?Descricao", txtDescricao.Text);
                Global.Comando.Parameters.AddWithValue("?Cod_Barra", txtCodBarra.Text);
                Global.Comando.Parameters.AddWithValue("?ID_Categoria", cboCategorias.SelectedValue);
                Global.Comando.Parameters.AddWithValue("?ID_Fornecedor", cboFornecedores.SelectedValue);
                Global.Comando.Parameters.AddWithValue("?Estoque", double.Parse(txtEstoque.Text));
                Global.Comando.Parameters.AddWithValue("?Est_Minimo", double.Parse(txtMinimo.Text));
                Global.Comando.Parameters.AddWithValue("?Vlr_Custo", double.Parse(txtCusto.Text));
                Global.Comando.Parameters.AddWithValue("?Vlr_Venda", double.Parse(txtVenda.Text));
                Global.Comando.Parameters.AddWithValue("?Imagem", pcbFoto.ImageLocation);
                Global.Comando.Parameters.AddWithValue("?Video", txtVideo.Text);
                Global.Comando.ExecuteNonQuery();
                Global.Conexao.Close();
                Configura1();
                LimpaCampos();
                tsbBusca.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }


          // // // // // // // // // // // // // // // //
         //  BOTÃO PARA EXCLUIR INFORMAÇÕES NO BANCO  //
        // // // // // // // // // // // // // // // // 
        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Favor, selecione algum registro na tabela!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir o registro selecionado?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    Global.Conexao.Open();
                    Global.Comando = new MySqlCommand("DELETE FROM Produtos WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                    Global.Comando.ExecuteNonQuery();
                    Global.Conexao.Close();
                    LimpaCampos();
                    tsbBusca.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global.Conexao.Close();
                }
            }
        }


          // // // // // // // // // // // // // // 
         // BOTÃO PARA FAZER UMA BUSCA NO BANCO //
        // // // // // // // // // // // // // // 
        private void tsbBusca_Click(object sender, EventArgs e)
        {
            Global.ConsultarProdutos(tsTxtBusca.Text);
            dgvProdutos.DataSource = Global.datTabela;
            LimpaCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O PRIMEIRO REGISTRO NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbPrimeiro_Click(object sender, EventArgs e)
        {
            dgvProdutos.CurrentCell = dgvProdutos[0, 0];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O REGISTRO ANTERIOR NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow.Index > 0)
            {
                dgvProdutos.CurrentCell = dgvProdutos[0, dgvProdutos.CurrentCell.RowIndex - 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // 
         // BOTÃO PARA SELECIONAR O PROXIMO REGISTRO NO DGV //
        // // // // // // // // // // // // // // // // // // 
        private void tsbProximo_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow.Index < (dgvProdutos.RowCount - 1))
            {
                dgvProdutos.CurrentCell = dgvProdutos[0, dgvProdutos.CurrentCell.RowIndex + 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // //
         //   BOTÃO PARA SELECIONAR O ULTIMO REGISTRO NO DGV   //
        // // // // // // // // // // // // // // // // // // // 
        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            dgvProdutos.CurrentCell = dgvProdutos[0, dgvProdutos.RowCount - 1];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // 
         //    BOTÃO PARA IMPRIMIR OS ITENS DA DGV    //
        // // // // // // // // // // // // // // // // 
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Muda o padrão dapágina para posição Paisagem
                pdoImprimir.DefaultPageSettings.Landscape = true;
                // Configura a janela de visualização no modo maximizado.
                ppdVisualizar.WindowState = FormWindowState.Maximized;
                // Abre a tela de visualização do relatório.
                ppdVisualizar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // // // // 
         //  BOTÃO PARA FECHAR O FORMULARIO ATUAL  //
        // // // // // // // // // // // // // // // 
        private void tsbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }


          // // // // // // // // // // // // // // // // // //
         //  CAIXA DE ESCOLHA DE ALGUMA FOTO DO COMPUTADOR  //
        // // // // // // // // // // // // // // // // // //
        private void pcbFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.ShowDialog();
            pcbFoto.ImageLocation = ofdArquivo.FileName;
        }


          // // // // // // // // // // //
         //  ABRIR O LINK NA INTERNET  //
        // // // // // // // // // // // 
        private void btnVideo_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(txtVideo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }


          // // // // // // // // // // 
         // EVENTO DE CLIQUE NA DGV //
        // // // // // // // // // // 
        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // //
         //   FUNÇAO DE CONFIGURAÇAO DO FORMULARIO - 1   //
        // // // // // // // // // // // // // // // // //
        private void Configura1()
        {
            grbCadastro.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbGravar.Enabled = false;
            tsbNovo.Enabled = true;
            tsbEditar.Enabled = true;
            tsbExcluir.Enabled = true;
            tsbPrimeiro.Enabled = true;
            tsbAnterior.Enabled = true;
            tsbProximo.Enabled = true;
            tsbUltimo.Enabled = true;
            tsbImprimir.Enabled = true;
            tsbFechar.Enabled = true;
            tsTxtBusca.Enabled = true;
            tsbBusca.Enabled = true;
            dgvProdutos.Enabled = true;
            pcbFoto.Enabled = false;
        }


          // // // // // // // // // // // // // // // // //
         //   FUNÇAO DE CONFIGURAÇAO DO FORMULARIO - 2   //
        // // // // // // // // // // // // // // // // //
        private void Configura2()
        {
            grbCadastro.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbGravar.Enabled = true;
            tsbNovo.Enabled = false;
            tsbEditar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbPrimeiro.Enabled = false;
            tsbAnterior.Enabled = false;
            tsbProximo.Enabled = false;
            tsbUltimo.Enabled = false;
            tsbImprimir.Enabled = false;
            tsbFechar.Enabled = false;
            tsTxtBusca.Enabled = false;
            tsbBusca.Enabled = false;
            dgvProdutos.Enabled = false;
            pcbFoto.Enabled = true;
        }


          // // // // // // // // // // // // // // // // // // //
         //  FUNÇAO PARA MOSTRAR OS DADOS SELECIONADOS DA DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void MostraCampos()
        {
            if (dgvProdutos.CurrentRow.Cells[1].Value.ToString() != "")
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells[0].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
                txtCodBarra.Text = dgvProdutos.CurrentRow.Cells[2].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells[5].Value.ToString();
                txtMinimo.Text = dgvProdutos.CurrentRow.Cells[6].Value.ToString();
                txtCusto.Text = dgvProdutos.CurrentRow.Cells[7].Value.ToString();
                txtVenda.Text = dgvProdutos.CurrentRow.Cells[8].Value.ToString();
                pcbFoto.ImageLocation = dgvProdutos.CurrentRow.Cells[9].Value.ToString();
                txtVideo.Text = dgvProdutos.CurrentRow.Cells[10].Value.ToString();
                cboCategorias.Text = dgvProdutos.CurrentRow.Cells[11].Value.ToString();
                cboFornecedores.Text = dgvProdutos.CurrentRow.Cells[12].Value.ToString();
            }
        }


          // // // // // // // // // // // // //
         //  EVENTO DE CLIQUE NA LINK LABEL  //
        // // // // // // // // // // // // //
        private void lklFornecedores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Hide();

            frmFornecedores Fornecedores = new frmFornecedores();
            Fornecedores.Show();
        }


          // // // // // // // // // // // // //
         //  EVENTO DE CLIQUE NA LINK LABEL  //
        // // // // // // // // // // // // //
        private void lklCategorias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCategorias Categorias = new frmCategorias();
            Categorias.Show();
        }


          // // // // // // // // // // // // // // // //
         // FUNÇAO PARA LIMPAR OS CAMPOS DA GROUP BOX //
        // // // // // // // // // // // // // // // //
        private void LimpaCampos()
        {
            tsTxtBusca.Clear();
            txtID.Clear();
            txtDescricao.Clear();
            txtCodBarra.Clear();
            cboCategorias.Text = "";
            cboFornecedores.Text = "";
            txtEstoque.Clear();
            txtMinimo.Clear();
            txtCusto.Clear();
            txtVenda.Clear();
            txtVideo.Clear();
            tsTxtBusca.Clear();
            pcbFoto.ImageLocation = "";
        }


          // // // // // // // // // // // // // // //
         //     VOID DE CONFIGURAÇÃO DA PÁGINA     //
        // // // // // // // // // // // // // // //  
        private void pdoImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicao, itens = 0;
            string relatorio = "Produtos";

            // Desenvolvimento do cabeçalho do relatório
            using (Font fonte = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point))
            {
                //O string format serve para formatar strings
                //quanto a seu alinhamento e o proprio alinhamento da linha
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                SolidBrush cor = new SolidBrush(System.Drawing.Color.Black);
                //Captura todo o retângulo dos limites da página
                System.Drawing.RectangleF larg_da_pag = e.PageBounds;
                //Aumenta a coordenada de localização Y
                larg_da_pag.Y += 30;
                //Desenhar texto centralizado
                e.Graphics.DrawString(relatorio, fonte, cor, larg_da_pag, sf);
            }

            e.Graphics.DrawLine(Pens.Black, 25, 90, 1145, 90);
            e.Graphics.DrawString("Código", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 25, 95);
            e.Graphics.DrawString("Descricao", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 105, 95);
            e.Graphics.DrawString("Código de Barras", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 275, 95);
            e.Graphics.DrawString("Fornecedor", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 450, 95);
            e.Graphics.DrawString("Categoria", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 640, 95);
            e.Graphics.DrawString("Estoque", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 805, 95);
            e.Graphics.DrawString("Minimo", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 885, 95);
            e.Graphics.DrawString("Custo", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 965, 95);
            e.Graphics.DrawString("Venda", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 1060, 95);
            e.Graphics.DrawLine(Pens.Black, 25, 120, 1145, 120);
            // Desenvolvimento da interface do corpo do relatório
            posicao = 100;
            foreach (DataGridViewRow linha in dgvProdutos.Rows)
            {
                if (itens > 30)
                {
                    e.HasMorePages = true;
                    return;
                }

                posicao += 25;
                e.Graphics.DrawString(linha.Cells[0].Value.ToString(), new Font("Arial", 10), Brushes.Black, 48, posicao);
                e.Graphics.DrawString(linha.Cells[1].Value.ToString(), new Font("Arial", 10), Brushes.Black, 105, posicao);
                e.Graphics.DrawString(linha.Cells[2].Value.ToString(), new Font("Arial", 10), Brushes.Black, 275, posicao);
                e.Graphics.DrawString(linha.Cells[12].Value.ToString(), new Font("Arial", 10), Brushes.Black, 450, posicao);
                e.Graphics.DrawString(linha.Cells[11].Value.ToString(), new Font("Arial", 10), Brushes.Black, 640, posicao);
                e.Graphics.DrawString(linha.Cells[5].Value.ToString(), new Font("Arial", 10), Brushes.Black, 805, posicao);
                e.Graphics.DrawString(linha.Cells[6].Value.ToString(), new Font("Arial", 10), Brushes.Black, 885, posicao);
                e.Graphics.DrawString("R$ " + linha.Cells[7].Value.ToString(), new Font("Arial", 10), Brushes.Black, 970, posicao);
                e.Graphics.DrawString("R$ " + linha.Cells[8].Value.ToString(), new Font("Arial", 10), Brushes.Black, 1065, posicao);
                itens += 1;
            }
            // Desenvolvimento da interface do rodapé do relatório
            e.Graphics.DrawLine(Pens.Black, 25, 760, 1145, 760);
            e.Graphics.DrawString("Total de produtos:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 30, 765);
            e.Graphics.DrawString(dgvProdutos.RowCount.ToString(), new Font("Arial", 12), Brushes.Black, 175, 765);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), new Font("Verdana", 12), Brushes.Black, 955, 765);
            e.Graphics.DrawLine(Pens.Black, 25, 790, 1145, 790);
        }
    }
}
