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
    public partial class frmClientes : Form
    {

        public frmClientes()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            Global.ConfigComboCidades(this.cboCidades);

            Configura1();
            LimpaCampos();
            tsbBusca.PerformClick();
        }


          // // // // // // // // // // //
         //   ATIVAÇAO DO FORMULARIO   //
        // // // // // // // // // // //
        private void frmClientes_Activated(object sender, EventArgs e)
        {
            Global.ConsultarCidades("");
            cboCidades.DataSource = Global.datTabela;
            cboCidades.DisplayMember = "Nome";
            cboCidades.ValueMember = "ID";
            cboCidades.Text = "";
            txtUF.Clear();
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // // 
        private void frmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


          // // // // // // // // // // // // // // // //
         //    BOTÃO PARA INICIAR UM NOVO CADASTRO    //
        // // // // // // // // // // // // // // // //
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Configura2();
            LimpaCampos();
            txtNome.Focus();
            Global.Operacao = 1;
        }


          // // // // // // // // // // // // // // 
         //    BOTÃO PARA EDITAR UM CADASTRO    //
        // // // // // // // // // // // // // // 
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.RowCount > 0)
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
            if (txtNome.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return;
            }

             // CHAMA A FUNÇAO DE VALIDAR O CPF E VERIFICA,
            // CASO SEJA "FALSE" O CADASTRO NÃO SERÁ EFETUADO.
            if (Validador(mtbCpf.Text) == false)
            {
                MessageBox.Show("CPF Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                Global.Conexao.Open();

                // VERIFICA SE HÁ UM OUTRO REGISTRO NO BANCO COM O MESMO CPF 
                Global.Comando = new MySqlCommand("SELECT * FROM Clientes WHERE CPF = ?CPF AND ID != ?ID", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                Global.Comando.Parameters.AddWithValue("?CPF", mtbCpf.Text);
                Global.Comando.ExecuteNonQuery();

                 // SE A VERIFICAÇÃO RETORNAR QUALQUER REGISTRO,
                // O CADASTRO NÃO SERÁ EFETUADO.
                if (Global.Comando.ExecuteScalar() != null)
                {
                    MessageBox.Show("Este CPF ja está regitrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global.Conexao.Close();
                    return;
                }

                if (Global.Operacao == 1)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO Clientes (Nome, CPF, Endereco, Nascimento, ID_Cidade, Renda) VALUES (?Nome, ?CPF, ?Endereco, ?Nascimento, ?ID_Cidade, ?Renda)", Global.Conexao);
                }

                if (Global.Operacao == 2)
                {
                    Global.Comando = new MySqlCommand("UPDATE Clientes SET Nome = ?Nome, CPF = ?CPF, Endereco = ?Endereco, Nascimento = ?Nascimento, ID_Cidade = ?ID_Cidade, Renda = ?Renda WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                }
                Global.Comando.Parameters.AddWithValue("?Nome", txtNome.Text);
                Global.Comando.Parameters.AddWithValue("?CPF", mtbCpf.Text);
                Global.Comando.Parameters.AddWithValue("?Endereco", txtEndereco.Text);
                Global.Comando.Parameters.AddWithValue("?Nascimento", DateTime.Parse(mtbDataNasc.Text));
                Global.Comando.Parameters.AddWithValue("?ID_Cidade", cboCidades.SelectedValue);
                Global.Comando.Parameters.AddWithValue("?Renda", Double.Parse(txtRenda.Text));
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
                    Global.Comando = new MySqlCommand("DELETE FROM Clientes WHERE ID = ?ID", Global.Conexao);
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
            Global.ConsultarClientes(tsTxtBusca.Text);
            dgvClientes.DataSource = Global.datTabela;
            LimpaCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O PRIMEIRO REGISTRO NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbPrimeiro_Click(object sender, EventArgs e)
        {
            dgvClientes.CurrentCell = dgvClientes[0, 0];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O REGISTRO ANTERIOR NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow.Index > 0)
            {
                dgvClientes.CurrentCell = dgvClientes[0, dgvClientes.CurrentCell.RowIndex - 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // 
         // BOTÃO PARA SELECIONAR O PROXIMO REGISTRO NO DGV //
        // // // // // // // // // // // // // // // // // // 
        private void tsbProximo_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow.Index < (dgvClientes.RowCount - 1))
            {
                dgvClientes.CurrentCell = dgvClientes[0, dgvClientes.CurrentCell.RowIndex + 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // //
         //   BOTÃO PARA SELECIONAR O ULTIMO REGISTRO NO DGV   //
        // // // // // // // // // // // // // // // // // // // 
        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            dgvClientes.CurrentCell = dgvClientes[0, dgvClientes.RowCount - 1];
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


          // // // // // // // // // // 
         // EVENTO DE CLIQUE NA DGV //
        // // // // // // // // // // 
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostraCampos();
        }


          // // // // // // // // // // // // //
         //  EVENTO DE CLIQUE NA LINK LABEL  //
        // // // // // // // // // // // // //
        private void lklCidade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCidades Cidades = new frmCidades();
            Cidades.Show();
        }


          // // // // // // // // // // // // // // // // // // // //
         //  EVENTO DE MUDANÇA NO VALOR SELECIONADO DA COMBO BOX  //
        // // // // // // // // // // // // // // // // // // // //
        private void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FAZ A CONSULTA E PREENCHE O CAMPO UF DE ACORDO COM A CIDADE SELECIONADA
            Global.ConsultarCidades(cboCidades.Text);
            if (Global.datTabela.Rows.Count > 0)
            {
                txtUF.Text = Global.datTabela.Rows[0].Field<String>("UF").ToString();
            }
            else
            {
                txtUF.Clear();
            }
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
            dgvClientes.Enabled = true;
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
            dgvClientes.Enabled = false;
        }


          // // // // // // // // // // // // // // // // // // //
         //  FUNÇAO PARA MOSTRAR OS DADOS SELECIONADOS DA DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void MostraCampos()
        {
            if (dgvClientes.CurrentRow.Cells[1].Value.ToString() != "")
            {
                txtID.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                mtbCpf.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtEndereco.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                mtbDataNasc.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                cboCidades.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
                txtUF.Text = dgvClientes.CurrentRow.Cells[8].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
            }
        }


          // // // // // // // // // // // // // // // //
         // FUNÇAO PARA LIMPAR OS CAMPOS DA GROUP BOX //
        // // // // // // // // // // // // // // // //
        private void LimpaCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            mtbCpf.Clear();
            txtEndereco.Clear();
            mtbDataNasc.Clear();
            //cboCidades.Text = "";
            //txtUF.Clear();
            txtRenda.Clear();
        }


          // // // // // // // // // // // // // // // // // //
         //   FUNÇAO PARA VERIFICAR SE O CPF É VERDADEIRO   //
        // // // // // // // // // // // // // // // // // //
        private bool Validador(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            String teste;

            cpf = cpf.Trim();
            cpf = cpf.Replace(",", "").Replace(".", "").Replace("-", "");
            teste = cpf.Substring(9);
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
			
            tempCpf = tempCpf + digito;			
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            if (digito != teste)
                return false;
            else
                return true;
        }


          // // // // // // // // // // // // // // //
         //     VOID DE CONFIGURAÇÃO DA PÁGINA     //
        // // // // // // // // // // // // // // //  
        private void pdoImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicao, itens = 0;
            string relatorio = "Clientes";

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

            e.Graphics.DrawLine(Pens.Black, 50, 90, 1095, 90);
            e.Graphics.DrawString("Código", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 95);
            e.Graphics.DrawString("Nome do cliente", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 125, 95);
            e.Graphics.DrawString("CPF", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 363, 95);
            e.Graphics.DrawString("Endereço do cliente", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 475, 95);
            e.Graphics.DrawString("Nascimento", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 690, 95);
            e.Graphics.DrawString("Cidade", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 800, 95);
            e.Graphics.DrawString("UF", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 995, 95);
            e.Graphics.DrawString("Renda", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 1030, 95);
            e.Graphics.DrawLine(Pens.Black, 50, 120, 1095, 120);
            // Desenvolvimento da interface do corpo do relatório
            posicao = 100;
            foreach (DataGridViewRow linha in dgvClientes.Rows)
            {
                if (itens > 30)
                {
                    e.HasMorePages = true;
                    return;
                }

                posicao += 25;
                e.Graphics.DrawString(linha.Cells[0].Value.ToString(), new Font("Arial", 10), Brushes.Black, 72, posicao);
                e.Graphics.DrawString(linha.Cells[1].Value.ToString(), new Font("Arial", 10), Brushes.Black, 125, posicao);
                e.Graphics.DrawString(linha.Cells[2].Value.ToString(), new Font("Arial", 10), Brushes.Black, 363, posicao);
                e.Graphics.DrawString(linha.Cells[3].Value.ToString(), new Font("Arial", 10), Brushes.Black, 475, posicao);
                e.Graphics.DrawString(linha.Cells[4].Value.ToString().Substring(0, 10), new Font("Arial", 10), Brushes.Black, 703, posicao);
                e.Graphics.DrawString(linha.Cells[7].Value.ToString(), new Font("Arial", 10), Brushes.Black, 800, posicao);
                e.Graphics.DrawString(linha.Cells[8].Value.ToString(), new Font("Arial", 10), Brushes.Black, 997, posicao);
                e.Graphics.DrawString(linha.Cells[6].Value.ToString(), new Font("Arial", 10), Brushes.Black, 1030, posicao);
                itens += 1;
            }
            // Desenvolvimento da interface do rodapé do relatório
            e.Graphics.DrawLine(Pens.Black, 50, 760, 1095, 760);
            e.Graphics.DrawString("Total de clientes:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 55, 765);
            e.Graphics.DrawString(dgvClientes.RowCount.ToString(), new Font("Arial", 12), Brushes.Black, 190, 765);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), new Font("Verdana", 12), Brushes.Black, 905, 765);
            e.Graphics.DrawLine(Pens.Black, 50, 790, 1095, 790);
        }
    }
}