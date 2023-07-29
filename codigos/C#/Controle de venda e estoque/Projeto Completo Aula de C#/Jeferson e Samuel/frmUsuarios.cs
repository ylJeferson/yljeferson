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
    public partial class frmUsuarios : Form
    {
        // VARIAVEL CRIADA PARA MUDAR A GLOBAL.ADMIN PARA QUE NÃO HAJA DUPLICIDADE DE USUÁRIOS
        public static bool Admin2;

        public frmUsuarios()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // // 
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Configura1();
            LimpaCampos();
            tsbBusca.PerformClick();

            if (Global.Admin == true)
            {
                Admin2 = true;
            }
            else
            {
                Admin2 = false;
                tsbEditar.Enabled = false;
            }
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // // 
        private void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Global.Cadastro == true)
            {
                frmLogin Log = new frmLogin();
                Log.Show();
            }

            Global.Cadastro = false;
        }


          // // // // // // // // // // // // // // // //
         //    BOTÃO PARA INICIAR UM NOVO CADASTRO    //
        // // // // // // // // // // // // // // // //
        private void tsbNovo_Click(object sender, EventArgs e)
        {
            Configura2();
            LimpaCampos();
            txtLogin.Focus();
            Global.Operacao = 1;
        }


          // // // // // // // // // // // // // // 
         //    BOTÃO PARA EDITAR UM CADASTRO    //
        // // // // // // // // // // // // // // 
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.RowCount > 0)
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
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return;
            }

            try
            {
                Global.Admin = true;

                Global.Conexao.Open();

                Global.ConsultarUsuarios(txtLogin.Text);
                if (Global.datTabela.Rows.Count > 0)
                {
                    MessageBox.Show("Já existe um usuário cadastrado com este login", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Global.Conexao.Close();
                    return;
                }

                if (Global.Operacao == 1)
                {
                    Global.Comando = new MySqlCommand("INSERT INTO Usuarios (Login, Senha, Nivel) VALUES (?Login, ?Senha, ?Nivel)", Global.Conexao);
                }

                if (Global.Operacao == 2)
                {
                    Global.Comando = new MySqlCommand("UPDATE Usuarios SET Login = ?Login, Senha = ?Senha, Nivel = ?Nivel WHERE ID = ?ID", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?ID", txtID.Text);
                }

                Global.Comando.Parameters.AddWithValue("?Login", txtLogin.Text);
                Global.Comando.Parameters.AddWithValue("?Senha", txtSenha.Text);
                Global.Comando.Parameters.AddWithValue("?Nivel", chkADM.Checked);
                Global.Comando.ExecuteNonQuery();
                Global.Conexao.Close();

                Global.Admin = Admin2;

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
                    Global.Comando = new MySqlCommand("DELETE FROM Usuarios WHERE ID = ?ID", Global.Conexao);
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
            Global.ConsultarUsuarios(tsTxtBusca.Text);
            dgvUsuarios.DataSource = Global.datTabela;
            LimpaCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O PRIMEIRO REGISTRO NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbPrimeiro_Click(object sender, EventArgs e)
        {
            dgvUsuarios.CurrentCell = dgvUsuarios[0, 0];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // // // //
         //  BOTÃO PARA SELECIONAR O REGISTRO ANTERIOR NO DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow.Index > 0)
            {
                dgvUsuarios.CurrentCell = dgvUsuarios[0, dgvUsuarios.CurrentCell.RowIndex - 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // 
         // BOTÃO PARA SELECIONAR O PROXIMO REGISTRO NO DGV //
        // // // // // // // // // // // // // // // // // // 
        private void tsbProximo_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow.Index < (dgvUsuarios.RowCount - 1))
            {
                dgvUsuarios.CurrentCell = dgvUsuarios[0, dgvUsuarios.CurrentCell.RowIndex + 1];
                MostraCampos();
            }
        }


          // // // // // // // // // // // // // // // // // // //
         //   BOTÃO PARA SELECIONAR O ULTIMO REGISTRO NO DGV   //
        // // // // // // // // // // // // // // // // // // // 
        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            dgvUsuarios.CurrentCell = dgvUsuarios[0, dgvUsuarios.RowCount - 1];
            MostraCampos();
        }


          // // // // // // // // // // // // // // // // 
         //    BOTÃO PARA IMPRIMIR OS ITENS DA DGV    //
        // // // // // // // // // // // // // // // // 
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            try
            {
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
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
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
            dgvUsuarios.Enabled = true;
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
            dgvUsuarios.Enabled = false;

            if (Global.Admin == false)
            {
                chkADM.Enabled = false;
            }
        }


          // // // // // // // // // // // // // // // // // // //
         //  FUNÇAO PARA MOSTRAR OS DADOS SELECIONADOS DA DGV  //
        // // // // // // // // // // // // // // // // // // //
        private void MostraCampos()
        {
            if (dgvUsuarios.CurrentRow.Cells[1].Value.ToString() != "")
            {
                txtID.Text = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                txtLogin.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
                txtSenha.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
                chkADM.Checked = bool.Parse(dgvUsuarios.CurrentRow.Cells[3].Value.ToString());
            }
        }


          // // // // // // // // // // // // // // // //
         // FUNÇAO PARA LIMPAR OS CAMPOS DA GROUP BOX //
        // // // // // // // // // // // // // // // //
        private void LimpaCampos()
        {
            tsTxtBusca.Clear();
            txtID.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            chkADM.Checked = false;
        }


          // // // // // // // // // // // // // // //
         //     VOID DE CONFIGURAÇÃO DA PÁGINA     //
        // // // // // // // // // // // // // // //  
        private void pdoImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int posicao, itens = 0;
            String nivel;
            string relatorio = "Usuários";

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
            e.Graphics.DrawString("Código", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 105, 95);
            e.Graphics.DrawString("Login", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 205, 95);
            e.Graphics.DrawString("Senha", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 405, 95);
            e.Graphics.DrawString("Nivel", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 605, 95);
            e.Graphics.DrawLine(Pens.Black, 100, 120, 725, 120);
            // Desenvolvimento da interface do corpo do relatório
            posicao = 100;
            foreach (DataGridViewRow linha in dgvUsuarios.Rows)
            {
                if (bool.Parse(linha.Cells[3].Value.ToString()) == true)
                {
                    nivel = "Administrador";
                }
                else
                {
                    nivel = "Comun";
                }

                if (itens > 30)
                {
                    e.HasMorePages = true;
                    return;
                }

                posicao += 25;
                e.Graphics.DrawString(linha.Cells[0].Value.ToString(), new Font("Arial", 10), Brushes.Black, 128, posicao);
                e.Graphics.DrawString(linha.Cells[1].Value.ToString(), new Font("Arial", 10), Brushes.Black, 205, posicao);
                e.Graphics.DrawString(linha.Cells[2].Value.ToString(), new Font("Arial", 10), Brushes.Black, 405, posicao);
                e.Graphics.DrawString(nivel, new Font("Arial", 10), Brushes.Black, 605, posicao);
                itens += 1;
            }
            // Desenvolvimento da interface do rodapé do relatório
            e.Graphics.DrawLine(Pens.Black, 100, 1110, 725, 1110);
            e.Graphics.DrawString("Total de usuários:", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 105, 1115);
            e.Graphics.DrawString(dgvUsuarios.RowCount.ToString(), new Font("Arial", 12), Brushes.Black, 255, 1115);
            e.Graphics.DrawString(System.DateTime.Now.ToString(), new Font("Verdana", 12), Brushes.Black, 527, 1115);
            e.Graphics.DrawLine(Pens.Black, 100, 1140, 725, 1140);
        }
    }
}
