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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


          // // // // // // // // // // // // // 
         //   LOAD DO FORMULARIO PRINCIPAL   //
        // // // // // // // // // // // // // 
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            Global.AbrirConexao();
            Global.CriaTabelas();
            LimpaCampos();
        }


          // // // // // // // // // // // // // // //
         //   FECHAMENTO DO FORMULARIO PRINCIPAL   //
        // // // // // // // // // // // // // // //
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


          // // // // // // // 
         //  BOTÃO ENTRAR  //
        // // // // // // // 
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Global.Conexao.Open();

                // VERIFICA SE HÁ UM ALGUM REGISTRO NO BANCO.
                Global.Comando = new MySqlCommand("SELECT * FROM Usuarios WHERE Nivel = ?Nivel", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?Nivel", true);
                Global.rConsulta = Global.Comando.ExecuteReader();
                Global.rConsulta.Read();

                if (Global.rConsulta.HasRows)
                {

                    Global.Conexao.Close();

                    Global.Conexao.Open();

                    //VERIFICA SE HÁ UM ALGUM REGISTRO NO BANCO COM OS MESMOS LOGIN E SENHA FORNECIDOS PELO USUÁRIO.
                    Global.Comando = new MySqlCommand("SELECT * FROM Usuarios WHERE Login = ?Login AND Senha = ?Senha", Global.Conexao);
                    Global.Comando.Parameters.AddWithValue("?Login", txtLogin.Text);
                    Global.Comando.Parameters.AddWithValue("?Senha", txtSenha.Text);
                    Global.rConsulta = Global.Comando.ExecuteReader();
                    Global.rConsulta.Read();

                    //SE A VERIFICAÇÃO RETORNAR QUALQUER REGISTRO,
                    // O LOGIN É EFETUADO E SERÁ ABERTO O MENU.
                    if (Global.rConsulta.HasRows)
                    {
                        if (bool.Parse(Global.rConsulta["Nivel"].ToString()) == true)
                        {
                            Global.Admin = true;
                            Global.Nivel = "Administrador";
                        }
                        else
                        {
                            Global.Admin = false;
                            Global.Nivel = "Comun";
                        }

                        Global.ID_Usuario = int.Parse(Global.rConsulta["ID"].ToString());
                        Global.Usuario = Global.rConsulta["Login"].ToString();

                        Global.Conexao.Close();
                        Hide();

                        frmMenu Menu = new frmMenu();
                        Menu.Show();
                    }

                    //CASO CONTRÁRIO RETORNARÁ UMA MENSAGEM DE LOGIN INVÁLIDO.
                    else
                    {
                        MessageBox.Show("Não existe nenhum cadastro referente as informações.", "Login Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Global.Conexao.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Não há nenhum Administrador registrado no banco.", "Cadastre-se!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Global.Conexao.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }


          // // // // // // // 
         //  BOTÃO FECHAR  //
        // // // // // // // 
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


          // // // // // // // // // // // // // // // // //
         //  LINK LABEL QUE ABRE FORMULÁRIO DE USUÁRIOS  //
        // // // // // // // // // // // // // // // // // 
        private void lklUsuarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Global.Conexao.Open();

                //VERIFICA SE HÁ UM ALGUM REGISTRO NO BANCO COM NIVEL ADM.
                Global.Comando = new MySqlCommand("SELECT * FROM Usuarios WHERE Nivel = ?Nivel", Global.Conexao);
                Global.Comando.Parameters.AddWithValue("?Nivel", true);
                Global.rConsulta = Global.Comando.ExecuteReader();
                Global.rConsulta.Read();

                //SE A VERIFICAÇÃO RETORNAR QUALQUER REGISTRO,
                //O FORMULARIO DE USUARIOS IRÁ ABRIR COMO USUÁRIO COMUN.
                if (Global.rConsulta.HasRows)
                {
                    Global.Admin = false;
                    Global.Conexao.Close();
                }

                // CASO CONTRÁRIO IRÁ ABRIR COMO USUÁRIO DO TIPO ADM,
                // POIS NÃO HÁ NENHUM ADM CADASTRADO NO SISTEMA.
                else
                {
                    Global.Admin = true;
                    Global.Conexao.Close();
                }

                LimpaCampos();
                Global.Cadastro = true;
                
                Hide();

                frmUsuarios Usuarios = new frmUsuarios();
                Usuarios.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Conexao.Close();
            }
        }


          // // // // // // // // // // // // // // // //
         // FUNÇAO PARA LIMPAR OS CAMPOS DA GROUP BOX //
        // // // // // // // // // // // // // // // //
        private void LimpaCampos()
        {
            txtLogin.Clear();
            txtSenha.Clear();
        }


          // // // // // // // // // // // //
         //  FACILITA LOGIN E FECHAMENTO  //
        // // // // // // // // // // // // 
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnEntrar.PerformClick();

            if (e.KeyChar == 27)
                btnFechar.PerformClick();
        }


          // // // // // // // // // // // //
         //  FACILITA LOGIN E FECHAMENTO  //
        // // // // // // // // // // // // 
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnEntrar.PerformClick();

            if (e.KeyChar == 27)
                btnFechar.PerformClick();
        }
    }
}
