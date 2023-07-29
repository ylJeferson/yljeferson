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
    public partial class frmCidades : Form
    {
        public frmCidades()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmCidades_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Configura1();
            LimpaCampos();
            tsbBusca.PerformClick();
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // // 
        private void frmCidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


          // // // // // // // // // // // // // // // //
         //    BOTÃO PARA INICIAR UM NOVO CADASTRO    //
        // // // // // // // // // // // // // // // //
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Configura2();
            LimpaCampos();
            txtCidade.Focus();
            Global.Operacao = 1;
        }


          // // // // // // // // // // // // // // 
         //    BOTÃO PARA EDITAR UM CADASTRO    //
        // // // // // // // // // // // // // // 
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvCidades.RowCount > 0)
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
            if (txtCidade.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCidade.Focus();
                return;
            }

            try
            {
                Global.Conexao.Open();

                if (Global.Operacao == 1)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO Cidades (Nome, UF) VALUES (?Nome, ?UF)", Global.Conexao);
                }

                if (Global.Operacao == 2)
                {
                    Global.Comando = new MySqlCommand("UPDATE Cidades SET Nome = ?Nome, UF=?UF WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                }

                Global.Comando.Parameters.AddWithValue("?Nome", txtCidade.Text);
                Global.Comando.Parameters.AddWithValue("?UF", txtUF.Text);
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

            if (MessageBox.Show("Deseja realmente excluir o registro selecionado", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    Global.Conexao.Open();
                    Global.Comando = new MySqlCommand("DELETE FROM Cidades WHERE ID = ?ID", Global.Conexao);
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
            Global.ConsultarCidades(tsTxtBusca.Text);
            dgvCidades.DataSource = Global.datTabela;
            LimpaCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O PRIMEIRO REGISTRO NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbPrimeiro_Click(object sender, EventArgs e)
        {
            dgvCidades.CurrentCell = dgvCidades[0, 0];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O REGISTRO ANTERIOR NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (dgvCidades.CurrentRow.Index > 0)
            {
                dgvCidades.CurrentCell = dgvCidades[0, dgvCidades.CurrentCell.RowIndex - 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // 
         // BOTÃO PARA SELECIONAR O PROXIMO REGISTRO NO DGV //
        // // // // // // // // // // // // // // // // // // 
        private void tsbProximo_Click(object sender, EventArgs e)
        {
            if (dgvCidades.CurrentRow.Index < (dgvCidades.RowCount - 1))
            {
                dgvCidades.CurrentCell = dgvCidades[0, dgvCidades.CurrentCell.RowIndex + 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // //
         //   BOTÃO PARA SELECIONAR O ULTIMO REGISTRO NO DGV   //
        // // // // // // // // // // // // // // // // // // // 
        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            dgvCidades.CurrentCell = dgvCidades[0, dgvCidades.RowCount - 1];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // 
         //    BOTÃO PARA IMPRIMIR OS ITENS DA DGV    //
        // // // // // // // // // // // // // // // // 
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            // Configura a janela de visualização no modo maximizado.
            ppdVisualizar.WindowState = FormWindowState.Maximized;
            // Abre a tela de visualização do relatório.
            ppdVisualizar.ShowDialog();
        }


          // // // // // // // // // // // // // // // 
         //  BOTÃO PARA FECHAR O FORMULARIO ATUAL  //
        // // // // // // // // // // // // // // // 
        private void tsbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        

          // // // // // // // // // // 
         // EVENTO DE CLIQUE NA DGV //
        // // // // // // // // // // 
        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
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
            dgvCidades.Enabled = true;
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
            dgvCidades.Enabled = false;
        }


          // // // // // // // // // // // // // // // // // // //
         //  FUNÇAO PARA MOSTRAR OS DADOS SELECIONADOS DA DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void MostraCampos()
        {
            if (dgvCidades.CurrentRow.Cells[1].Value.ToString() != "")
            {
                txtID.Text = dgvCidades.CurrentRow.Cells[0].Value.ToString();
                txtCidade.Text = dgvCidades.CurrentRow.Cells[1].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells[2].Value.ToString();
            }
        }


          // // // // // // // // // // // // // // // //
         // FUNÇAO PARA LIMPAR OS CAMPOS DA GROUP BOX //
        // // // // // // // // // // // // // // // //
        private void LimpaCampos()
        {
            tsTxtBusca.Clear();
            txtID.Clear();
            txtCidade.Clear();
            txtUF.Clear();
        }


          // // // // // // // // // // // // // // //
         //     VOID DE CONFIGURAÇÃO DA PÁGINA     //
        // // // // // // // // // // // // // // //  
        private void pdoImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicao, itens = 0;
            string relatorio = "Cidades";

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

            e.Graphics.DrawLine(Pens.Black, 100, 90, 725, 90);
            e.Graphics.DrawString("Código", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 100, 95);
            e.Graphics.DrawString("Nome", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 200, 95);
            e.Graphics.DrawString("UF", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 695, 95);
            e.Graphics.DrawLine(Pens.Black, 100, 120, 725, 120);
            // Desenvolvimento da interface do corpo do relatório
            posicao = 100;
            foreach (DataGridViewRow linha in dgvCidades.Rows)
            {
                if (itens > 30)
                {
                    e.HasMorePages = true;
                    return;
                }
                posicao += 25;
                e.Graphics.DrawString(linha.Cells[0].Value.ToString(), new Font("Arial", 10), Brushes.Black, 123, posicao);
                e.Graphics.DrawString(linha.Cells[1].Value.ToString(), new Font("Arial", 10), Brushes.Black, 205, posicao);
                e.Graphics.DrawString(linha.Cells[2].Value.ToString(), new Font("Arial", 10), Brushes.Black, 690, posicao);
                // e.Graphics.DrawLine(Pens.Black, 100, posicao + 20, 725, posicao + 20);
                itens += 1;
            }
            // Desenvolvimento da interface do rodapé do relatório
            e.Graphics.DrawLine(Pens.Black, 100, 1110, 725, 1110);
            e.Graphics.DrawString("Total de cidades:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 105, 1115);
            e.Graphics.DrawString(dgvCidades.RowCount.ToString(), new Font("Arial", 12), Brushes.Black, 245, 1115);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), new Font("Verdana", 12), Brushes.Black, 527, 1115);
            e.Graphics.DrawLine(Pens.Black, 100, 1140, 725, 1140);
        }
    }
}
