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
    public partial class frmFornecedores : Form
    {
        public frmFornecedores()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmFornecedores_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Configura1();
            LimpaCampos();
            tsbBusca.PerformClick();
        }


          // // // // // // // // // // //
         //   ATIVAÇAO DO FORMULARIO   //
        // // // // // // // // // // //
        private void frmFornecedores_Activated(object sender, EventArgs e)
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
        private void frmFornecedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


          // // // // // // // // // // // //  
         //  BOTÃO PARA UM NOVO CADASTRO  //
        // // // // // // // // // // // // 
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Configura2();
            LimpaCampos();
            txtRazaoSocial.Focus();
            Global.Operacao = 1;
        }


          // // // // // // // // // // // // // // 
         //    BOTÃO PARA EDITAR UM CADASTRO    //
        // // // // // // // // // // // // // // 
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvFornecedores.RowCount > 0)
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
            if (txtRazaoSocial.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazaoSocial.Focus();
                return;
            }

            try
            {
                Global.Conexao.Open();

                if (Global.Operacao == 1)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO Fornecedores (Razao_Social, Fantasia, Endereco, Bairro, ID_Cidade, UF, CNPJ, IE, Fone, Contato, Email) VALUES (?Razao_Social, ?Fantasia, ?Endereco, ?Bairro, ?ID_Cidade, ?UF, ?CNPJ, ?IE, ?Fone, ?Contato, ?Email)", Global.Conexao);
                }

                if (Global.Operacao == 2)
                {
                    Global.Comando = new MySqlCommand("UPDATE Fornecedores SET Razao_Social = ?Razao_Social, Fantasia = ?Fantasia, Endereco = ?Endereco, Bairro = ?Bairro, ID_Cidade = ?ID_Cidade, UF = ?UF, CNPJ = ?CNPJ, IE = ?IE, Fone = ?Fone, Contato = ?Contato, Email = ?Email WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                }
                Global.Comando.Parameters.AddWithValue("?Razao_Social", txtRazaoSocial.Text);
                Global.Comando.Parameters.AddWithValue("?Fantasia", txtFantasia.Text);
                Global.Comando.Parameters.AddWithValue("?Endereco", txtEndereco.Text);
                Global.Comando.Parameters.AddWithValue("?Bairro", txtBairro.Text);
                Global.Comando.Parameters.AddWithValue("?ID_Cidade", cboCidades.SelectedValue);
                Global.Comando.Parameters.AddWithValue("?UF", txtUF.Text);
                Global.Comando.Parameters.AddWithValue("?CNPJ", mtbCNPJ.Text);
                Global.Comando.Parameters.AddWithValue("?IE",mtbIE.Text);
                Global.Comando.Parameters.AddWithValue("?Fone", mtbTelefone.Text);
                Global.Comando.Parameters.AddWithValue("?Contato", txtContato.Text);
                Global.Comando.Parameters.AddWithValue("?Email", txtEmail.Text);
                Global.Comando.ExecuteNonQuery();
                Global.Conexao.Close();
                Configura1();
                LimpaCampos();
                tsbBusca.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbIE.Enabled = false;
                mtbIE.Clear();
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
                    Global.Comando = new MySqlCommand("DELETE FROM Fornecedores WHERE ID = ?ID", Global.Conexao);
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
            Global.ConsultarFornecedores(tsTxtBusca.Text);
            dgvFornecedores.DataSource = Global.datTabela;
            LimpaCampos();
        }



          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O PRIMEIRO REGISTRO NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbPrimeiro_Click(object sender, EventArgs e)
        {
            dgvFornecedores.CurrentCell = dgvFornecedores[0, 0];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O REGISTRO ANTERIOR NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (dgvFornecedores.CurrentRow.Index > 0)
            {
                dgvFornecedores.CurrentCell = dgvFornecedores[0, dgvFornecedores.CurrentCell.RowIndex - 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // 
         // BOTÃO PARA SELECIONAR O PROXIMO REGISTRO NO DGV //
        // // // // // // // // // // // // // // // // // // 
        private void tsbProximo_Click(object sender, EventArgs e)
        {
            if (dgvFornecedores.CurrentRow.Index < (dgvFornecedores.RowCount - 1))
            {
                dgvFornecedores.CurrentCell = dgvFornecedores[0, dgvFornecedores.CurrentCell.RowIndex + 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // //
         //   BOTÃO PARA SELECIONAR O ULTIMO REGISTRO NO DGV   //
        // // // // // // // // // // // // // // // // // // // 
        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            dgvFornecedores.CurrentCell = dgvFornecedores[0, dgvFornecedores.RowCount - 1];
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
        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
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
         //  EVENTO QUE SELECIONA O ESTADO A PARTIR DA COMBO BOX  //
        // // // // // // // // // // // // // // // // // // // // 
        private void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FAZ A CONSULTA E PREENCHE O CAMPO UF DE ACORDO COM A CIDADE SELECIONADA
            Global.ConsultarCidades(cboCidades.Text);

            if (Global.datTabela.Rows.Count > 0)
            {
                txtUF.Text = Global.datTabela.Rows[0].Field<String>("UF").ToString();
            }

            if (cboCidades.Text == "")
                mtbIE.Enabled = false;

            if (cboCidades.Text != null)
                mtbIE.Enabled = true;

            Mascaras();
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
            dgvFornecedores.Enabled = true;
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
            dgvFornecedores.Enabled = false;
            mtbIE.Enabled = false;
        }


          // // // // // // // // // // // // // // // // // // //
         //  FUNÇAO PARA MOSTRAR OS DADOS SELECIONADOS DA DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void MostraCampos()
        {
            if (dgvFornecedores.CurrentRow.Cells[1].Value.ToString() != "")
            {
                txtID.Text = dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
                txtRazaoSocial.Text = dgvFornecedores.CurrentRow.Cells[1].Value.ToString();
                txtFantasia.Text = dgvFornecedores.CurrentRow.Cells[2].Value.ToString();
                txtEndereco.Text = dgvFornecedores.CurrentRow.Cells[3].Value.ToString();
                txtBairro.Text = dgvFornecedores.CurrentRow.Cells[4].Value.ToString();
                txtUF.Text = dgvFornecedores.CurrentRow.Cells[6].Value.ToString();
                mtbCNPJ.Text = dgvFornecedores.CurrentRow.Cells[7].Value.ToString();
                mtbIE.Text = dgvFornecedores.CurrentRow.Cells[8].Value.ToString();
                mtbTelefone.Text = dgvFornecedores.CurrentRow.Cells[9].Value.ToString();
                txtContato.Text = dgvFornecedores.CurrentRow.Cells[10].Value.ToString();
                txtEmail.Text = dgvFornecedores.CurrentRow.Cells[11].Value.ToString();
                cboCidades.Text = dgvFornecedores.CurrentRow.Cells[12].Value.ToString();
            }
        }


          // // // // // // // // // // // // // // // //
         // FUNÇAO PARA LIMPAR OS CAMPOS DA GROUP BOX //
        // // // // // // // // // // // // // // // //
        private void LimpaCampos()
        {
            tsTxtBusca.Clear();
            txtID.Clear();
            txtRazaoSocial.Clear(); 
            txtFantasia.Clear(); 
            txtEndereco.Clear();
            txtBairro.Clear();
            txtUF.Clear();
            mtbCNPJ.Clear();
            mtbIE.Mask = "";
            mtbIE.Clear();
            mtbTelefone.Clear();
            txtContato.Clear();
            txtEmail.Clear();
            cboCidades.Text = "";
        }


          // // // // // // // // // // // // // // //
         //     VOID DE CONFIGURAÇÃO DA PÁGINA     //
        // // // // // // // // // // // // // // //  
        private void pdoImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicao, itens = 0;
            string relatorio = "Fornecedores";

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
            e.Graphics.DrawString("Cód.", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 25, 95);
            e.Graphics.DrawString("Razão Social", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 70, 95);
            e.Graphics.DrawString("Fantasia", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 230, 95);
            e.Graphics.DrawString("Endereço", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 320, 95);
            e.Graphics.DrawString("Cidade", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 520, 95);
            e.Graphics.DrawString("CNPJ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 595, 95);
            e.Graphics.DrawString("Insc. Estadual", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 730, 95);
            e.Graphics.DrawString("Fone", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 855, 95);
            //e.Graphics.DrawString("Contato", new Font("Arial", 12), Brushes.Black, 615, 95);
            e.Graphics.DrawString("Email", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 960, 95);
            e.Graphics.DrawLine(Pens.Black, 25, 120, 1145, 120);
            // Desenvolvimento da interface do corpo do relatório
            posicao = 100;
            foreach (DataGridViewRow linha in dgvFornecedores.Rows)
            {
                if (itens > 30)
                {
                    e.HasMorePages = true;
                    return;
                }

                posicao += 25;
                e.Graphics.DrawString(linha.Cells[0].Value.ToString(), new Font("Arial", 10), Brushes.Black, 38, posicao);
                e.Graphics.DrawString(linha.Cells[1].Value.ToString(), new Font("Arial", 10), Brushes.Black, 70, posicao);
                e.Graphics.DrawString(linha.Cells[2].Value.ToString(), new Font("Arial", 10), Brushes.Black, 230, posicao);
                e.Graphics.DrawString(linha.Cells[3].Value.ToString() + " - " + linha.Cells[4].Value.ToString(), new Font("Arial", 10), Brushes.Black, 320, posicao);
                e.Graphics.DrawString(linha.Cells[12].Value.ToString(), new Font("Arial", 10), Brushes.Black, 520, posicao);
                e.Graphics.DrawString(linha.Cells[7].Value.ToString(), new Font("Arial", 10), Brushes.Black, 595, posicao);
                e.Graphics.DrawString(linha.Cells[8].Value.ToString(), new Font("Arial", 10), Brushes.Black, 730, posicao);
                e.Graphics.DrawString(linha.Cells[9].Value.ToString(), new Font("Arial", 10), Brushes.Black, 855, posicao);
                //e.Graphics.DrawString(linha.Cells[10].Value.ToString(), new Font("Arial", 10), Brushes.Black, 615, posicao);
                e.Graphics.DrawString(linha.Cells[11].Value.ToString(), new Font("Arial", 10), Brushes.Black, 960, posicao);
                itens += 1;
            }
            // Desenvolvimento da interface do rodapé do relatório
            e.Graphics.DrawLine(Pens.Black, 25, 760, 1145, 760);
            e.Graphics.DrawString("Total de fornecedores:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 30, 765);
            e.Graphics.DrawString(dgvFornecedores.RowCount.ToString(), new Font("Arial", 12), Brushes.Black, 205, 765);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), new Font("Verdana", 12), Brushes.Black, 955, 765);
            e.Graphics.DrawLine(Pens.Black, 25, 790, 1145, 790);
        }


          // // // // // // // // // // // // // // 
         // FUNÇAO PARA DEFINIR A MASCARA DO IE //
        // // // // // // // // // // // // // // 
        private void Mascaras()
        {
            // ESTADO DO ACRE
            if (txtUF.Text == "AC")
                mtbIE.Mask = "00.000.000/000-00";
            

            // ESTADO DE ALAGOAS
            else if (txtUF.Text == "AL") 
                mtbIE.Mask = "000000000";
            

            // ESTADO DO AMAPÁ
            else if (txtUF.Text == "AP") 
                mtbIE.Mask = "000000000";
            

            // ESTADO DO AMAZONAS
            else if (txtUF.Text == "AM") 
                mtbIE.Mask = "00.000.000-0";
            

            // ESTADO DA BAHIA
            else if (txtUF.Text == "BA") 
                mtbIE.Mask = "000000-00";
            

            // ESTADO DO CEARA
            else if (txtUF.Text == "CE") 
                mtbIE.Mask = "00000000-0";
            

            // DISTRITO FEDERAL
            else if (txtUF.Text == "DF") 
                mtbIE.Mask = "00000000000-00";
            

            // ESTADO DO ESPIRITO SANTO
            else if (txtUF.Text == "ES") 
                mtbIE.Mask = "00000000-0";
            
            // ESTADO DE GOIAS
            else if (txtUF.Text == "GO") 
                mtbIE.Mask = "00.000.000-0";
            

            // ESTADO DO MARANHAO
            else if (txtUF.Text == "MA") 
                mtbIE.Mask = "00000000-0";
            

            // ESTADO DO MATO GROSSO
            else if (txtUF.Text == "MT") 
                mtbIE.Mask = "0000000000-0";
            

            // ESTADO DO MATO GROSSO DO SUL
            else if (txtUF.Text == "MS") 
                mtbIE.Mask = "00000000-0";
            

            // ESTADO DE MINAS GERAIS
            else if (txtUF.Text == "MG") 
                mtbIE.Mask = "000.000.000/0000";
            

            // ESTADO DO PARA
            else if (txtUF.Text == "PA") 
                mtbIE.Mask = "00-000000-0";
            

            // ESTADO DA PARAIBA
            else if (txtUF.Text == "PB") 
                mtbIE.Mask = "00000000-0";
            

            // ESTADO DO PARANÁ
            else if (txtUF.Text == "PR") 
                mtbIE.Mask = "000.00000-00";
            

            // ESTADO DE PERNAMBUCO
            else if (txtUF.Text == "PE") 
                mtbIE.Mask = "0000000-00";
            

            // ESTADO DO PIAUI
            else if (txtUF.Text == "PI") 
                mtbIE.Mask = "00000000-0";
            

            // ESTADO DO RIO DE JANEIRO
            else if (txtUF.Text == "RJ") 
                mtbIE.Mask = "00.000.00-0";
            

            // ESTADO DO RIO GRANDE DO NORTE
            else if (txtUF.Text == "RN") 
                mtbIE.Mask = "00.000.000-0";
            

            // ESTADO DO RIO GRANDE DO SUL
            else if (txtUF.Text == "RS") 
                mtbIE.Mask = "000/0000000";
            

            // ESTADO DE RONDONIA
            else if (txtUF.Text == "RO") 
                mtbIE.Mask = "0000000000000-0";
            

            // ESTADO DA RORAIMA
            else if (txtUF.Text == "RR") 
                mtbIE.Mask = "00000000-0";
            

            // ESTADO DE SÃO PAULO
            else if (txtUF.Text == "SP") 
                mtbIE.Mask = "000.000.000.000";
            

            // ESTADO DE SANTA CATARINA
            else if (txtUF.Text == "SC") 
                mtbIE.Mask = "000.000.000";
            

            // ESTADO DE SERGIPE
            else if (txtUF.Text == "SE") 
                mtbIE.Mask = "00000000-0";
            

            // ESTADO DE TOCANTINS
            else if (txtUF.Text == "TO") 
                mtbIE.Mask = "0000000000-0";
            

            // SEM ESTADO SELECIONADO
            else 
                mtbIE.Mask = "";
            
        }
    }
}
