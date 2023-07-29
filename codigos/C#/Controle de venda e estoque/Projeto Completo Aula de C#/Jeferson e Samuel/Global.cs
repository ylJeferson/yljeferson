using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Jeferson_e_Samuel
{
    class Global
    {
          // // // // // // // // // // // // // // //
         //      CRIANDO AS VARIAVEIS PUBLICAS     //
        // // // // // // // // // // // // // // //

        // VARIAVEIS BANCO
        public static MySqlConnection Conexao;
        public static MySqlCommand Comando;
        public static MySqlDataReader rConsulta;
        public static MySqlDataAdapter Adaptador;
        public static DataTable datTabela;

        // VARIAVEIS USUARIO
        public static String Usuario;
        public static String Nivel;
        public static int ID_Usuario;
        public static bool Admin;

        // VARIAVEIS FORMULARIO
        public static int Operacao;
        public static bool Cadastro;
        public static bool Load;

        // VARIAVEIS TESTE
        // String Mensagem = "", Parametros = "";


          // // // // // // // // // // // //
         //   ABRIR CONEXAO COM O BANCO   //
        // // // // // // // // // // // //
        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;uid=root;pwd=etecjau");
                Conexao.Open();
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS bd_projeto;" +
                                           "USE bd_projeto;", Conexao);
                Comando.ExecuteNonQuery();
                Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexao.Close();
            }
        }


          // // // // // // // // // // // // // //
         //  CRIANDO TODAS AS TABELAS DO BANCO  //
        // // // // // // // // // // // // // //
        public static void CriaTabelas()
        {
            try
            {
                Conexao.Open();


                  // // // // // // // //
                 //  TABELA DE CAIXA  //
                // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS caixa" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Data DATE," +
                                           "Dinheiro DECIMAL(10,2)," +
                                           "Cartao DECIMAL(10,2)," +
                                           "Cheque DECIMAL(10,2)," +
                                           "Tipo INTEGER)", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // // //
                 //   TABELA DE CATEGORIAS  //
                // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS categorias" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Descricao VARCHAR(30))", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // // // //
                 //   TABELA DE CENTRO CUSTO   //
                // // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS centro_custo" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Descricao VARCHAR(30))", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // 
                 // TABELA DE CIDADES //
                // // // // // // // // 
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cidades" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Nome CHAR(40)," +
                                           "UF CHAR(02))", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // //
                 //  TABELA DE CLIENTES  //
                // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS clientes" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Nome CHAR(40)," +
                                           "CPF CHAR(14)," +
                                           "Endereco CHAR(40)," +
                                           "Nascimento DATE," +
                                           "ID_Cidade INTEGER," +
                                           "Renda DECIMAL(10,2))", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // // // //
                 // TABELA DE CONTAS A RECEBER //
                // // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS contas_receber" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "ID_Venda INTEGER," +
                                           "ID_Cliente INTEGER," +
                                           "Parcela INTEGER," +
                                           "Data_Venda DATE," +
                                           "Data_Vencto DATE," +
                                           "Data_Pgto DATE," +
                                           "Vlr_Parcela Double(10,2)," +
                                           "Status BOOLEAN)", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // //
                 //  TABELA DE DESPESAS  //
                // // // // // // // // // 
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS despesas" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Descricao VARCHAR(30)," +
                                           "ID_Centro_Custo INTEGER)", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // // // //
                 //   TABELA DE FORNECEDORES   //
                // // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS fornecedores" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Razao_Social CHAR(40)," +
                                           "Fantasia CHAR(30)," +
                                           "Endereco CHAR(40)," +
                                           "Bairro CHAR(30)," +
                                           "ID_Cidade INTEGER," +
                                           "UF CHAR(02)," +
                                           "CNPJ CHAR(18)," +
                                           "IE CHAR(17)," +
                                           "Fone CHAR(14)," +
                                           "Contato CHAR(40)," +
                                           "Email CHAR(40))", Conexao);
                Comando.ExecuteNonQuery();



                  // // // // // // // // // //
                 //  TABELA DE LANCAMENTOS  //
                // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS lancamentos" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "ID_Despesa INTEGER," +
                                           "ID_Fornecedor INTEGER," +
                                           "Parcela INTEGER," +
                                           "Valor DOUBLE(10,2)," +
                                           "Data_Movimento DATE," +
                                           "Data_Vencimento DATE," +
                                           "Data_Pgto DATE," +
                                           "Status BOOLEAN)", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // //
                 //  TABELA DE PRODUTOS  //
                // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS produtos" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Descricao VARCHAR(40)," +
                                           "Cod_Barra CHAR(20)," +
                                           "ID_Categoria INTEGER," +
                                           "ID_Fornecedor INTEGER," +
                                           "Estoque DECIMAL(10,3)," +
                                           "Est_Minimo DECIMAL(10,3)," +
                                           "Vlr_Custo DECIMAL(10,2)," +
                                           "Vlr_Venda DECIMAL(10,2)," +
                                           "Imagem CHAR(60)," +
                                           "Video CHAR(60))", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // //
                 //  TABELA DE USUARIOS  //
                // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS usuarios" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "Login CHAR(20)," +
                                           "Senha CHAR(10)," +
                                           "Nivel BOOLEAN)", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // // //
                 //   TABELA DE VENDA_CAB   //
                // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS venda_cab" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "ID_Cliente INTEGER," +
                                           "Data DATE," +
                                           "Total DECIMAL(10,2)," +
                                           "ID_VENDEDOR INTEGER)", Conexao);
                Comando.ExecuteNonQuery();


                  // // // // // // // // // //
                 //   TABELA DE VENDA_DET   //
                // // // // // // // // // //
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS venda_det" +
                                           "(ID INTEGER AUTO_INCREMENT PRIMARY KEY," +
                                           "ID_Venda INTEGER," +
                                           "ID_Produto INTEGER," +
                                           "Qtde INTEGER," +
                                           "Vlr_Unit DECIMAL(10,2))", Conexao);
                Comando.ExecuteNonQuery();


                Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexao.Close();
            }
        }


          // // // // // // // // // // // // // // // // // //
         //  ADAPTADOR PARA CONSULTAS OFFLINE - CATEGORIAS  //
        // // // // // // // // // // // // // // // // // //
        public static void ConsultarCategorias(String Nome)
        {
            try
            {
                Comando = new MySqlCommand("SELECT * FROM categorias WHERE Descricao LIKE ?Categorias ORDER BY ID", Conexao);
                Comando.Parameters.AddWithValue("?Categorias", Nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // // // // // // // 
         // ADAPTADOR PARA CONSULTAS OFFLINE - CENTRO CUSTO //
        // // // // // // // // // // // // // // // // // //
        public static void ConsultarCentroCusto(String Descricao)
        {
            try
            {
                Comando = new MySqlCommand("SELECT * FROM centro_custo WHERE Descricao LIKE ?Descricao ORDER BY ID", Conexao);
                Comando.Parameters.AddWithValue("?Descricao", Descricao + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // // // // // //
         //  ADAPTADOR PARA CONSULTAS OFFLINE - CIDADES  //
        // // // // // // // // // // // // // // // // //
        public static void ConsultarCidades(String Nome)
        {
            try
            {
                Comando = new MySqlCommand("SELECT * FROM cidades WHERE Nome LIKE ?Cidades ORDER BY ID", Conexao);
                Comando.Parameters.AddWithValue("?Cidades", Nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


          // // // // // // // // // // // // // // // // // //
         //   ADAPTADOR PARA CONSULTAS OFFLINE - CLIENTES   //
        // // // // // // // // // // // // // // // // // //
        public static void ConsultarClientes(String Nome)
        {
            try
            {
                Comando = new MySqlCommand("SELECT Clientes.*, Cidades.Nome Cidade, Cidades.UF FROM clientes " +
                                           "LEFT JOIN cidades on Cidades.ID = Clientes.ID_Cidade " +
                                           "WHERE Clientes.Nome LIKE ?Clientes ORDER BY Clientes.ID", Conexao);
                Comando.Parameters.AddWithValue("?Clientes", Nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // // // // // // // // //
         //  ADAPTADOR PARA CONSULTAS OFFLINE - CONTAS A RECEBER  //
        // // // // // // // // // // // // // // // // // // // //
        public static void ContasAReceber(String Cliente)
        {
            try
            {
                Comando = new MySqlCommand("SELECT CR.Status, CR.ID_Venda, CR.Parcela, CR.Data_Vencto, CR.Vlr_Parcela FROM contas_receber CR " +
                                           "INNER JOIN clientes CL on CL.ID = CR.ID_Cliente " +
                                           "WHERE CL.Nome = ?Cliente AND CR.Status = false " +
                                           "ORDER BY Data_Vencto", Conexao);
                Comando.Parameters.AddWithValue("?Cliente", Cliente);
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


          // // // // // // // // // // // // // // // // // //
         //   ADAPTADOR PARA CONSULTAS OFFLINE - DESPESAS   //
        // // // // // // // // // // // // // // // // // //
        public static void ConsultarDespesas(String Descricao)
        {
            try
            {
                Comando = new MySqlCommand("SELECT de.ID, de.Descricao Despesa, cc.Descricao CentroCusto FROM despesas de INNER JOIN centro_custo cc ON de.ID_Centro_Custo = cc.ID WHERE de.Descricao LIKE ?Descricao ORDER BY de.ID", Conexao);
                Comando.Parameters.AddWithValue("?Descricao", Descricao + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



          // // // // // // // // // // // // // // // // // // // //
         //    ADAPTADOR PARA CONSULTAS OFFLINE - FORNECEDORES    //
        // // // // // // // // // // // // // // // // // // // //
        public static void ConsultarFornecedores(String Nome)
        {
            try
            {
                Comando = new MySqlCommand("SELECT Fornecedores.*, Cidades.Nome Cidade FROM fornecedores " +
                                           "LEFT JOIN cidades on cidades.ID = fornecedores.ID_Cidade " +
                                           "WHERE Fornecedores.Razao_Social LIKE ?Fornecedores ORDER BY Fornecedores.ID", Conexao);
                Comando.Parameters.AddWithValue("?Fornecedores", Nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



          // // // // // // // // // // // // // // // // //
         //ADAPTADOR PARA CONSULTAS OFFLINE - LANCAMENTOS//
        // // // // // // // // // // // // // // // // //
        public static void ConsultarLancamentos(String Fornecedor)
        {
            try
            {
                Comando = new MySqlCommand("SELECT la.status, dp.Descricao, la.Parcela, la.Valor, la.Data_Vencimento FROM lancamentos la " +
                                           "INNER JOIN despesas dp on dp.ID = la.ID_Despesa " +
                                           "INNER JOIN fornecedores fr on fr.ID = la.ID_Fornecedor " +
                                           "WHERE fr.Razao_Social = ?Fornecedor AND la.status = ?status " +
                                           "ORDER BY la.ID", Conexao);

                Comando.Parameters.AddWithValue("?Fornecedor", Fornecedor);
                Comando.Parameters.AddWithValue("?status", false);
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // // // // // // // // // // // // // // // // // //
        //   ADAPTADOR PARA CONSULTAS OFFLINE - PRODUTOS   //
        // // // // // // // // // // // // // // // // // //
        public static void ConsultarProdutos(String Nome)
        {
            try
            {
                Comando = new MySqlCommand("SELECT PR.*, CA.Descricao Categoria, FR.Razao_Social FROM produtos PR " +
                                           "INNER JOIN categorias CA ON CA.ID = PR.ID_Categoria " +
                                           "INNER JOIN fornecedores FR on FR.ID = PR.ID_Fornecedor " +
                                           "WHERE PR.Descricao LIKE ?Produtos ORDER BY PR.ID", Conexao);
                Comando.Parameters.AddWithValue("?Produtos", Nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
          // // // // // // // // // // // // // // // // // //
         //   ADAPTADOR PARA CONSULTAS OFFLINE - USUARIOS   //
        // // // // // // // // // // // // // // // // // //
        public static void ConsultarUsuarios(String Nome)
        {
            try
            {
                if (Global.Admin == false)
                {
                    Comando = new MySqlCommand("SELECT * FROM usuarios WHERE Login LIKE ?Usuarios AND Nivel != ?Nivel AND Nivel = ?Nivel ORDER BY ID", Conexao);
                    Comando.Parameters.AddWithValue("?Nivel", true);
                }
                if (Global.Admin == true)
                {
                    Comando = new MySqlCommand("SELECT * FROM usuarios WHERE Login LIKE ?Usuarios ORDER BY ID", Conexao);
                }

                Comando.Parameters.AddWithValue("?Usuarios", Nome + "%");
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



          // // // // // // // // // // // // // // // // 
         // ADAPTADOR PARA CONSULTAS OFFLINE - VENDAS //
        // // // // // // // // // // // // // // // // 
        public static void ConsultarVendas(String Produto, DateTime DataInicio, DateTime DataFim)
        {
            try
            {
                Comando = new MySqlCommand("SELECT VC.ID Venda, VC.Data, C.Nome, VD.Qtde Quantidade, VD.Vlr_Unit FROM venda_cab VC " +

                                           "INNER JOIN clientes C ON C.ID = VC.ID_Cliente " +
                                           "INNER JOIN venda_det VD ON VC.ID = VD.ID_Venda " +
                                           "INNER JOIN produtos P ON P.ID = VD.ID_Produto " +

                                           "WHERE P.Descricao = ?Produto " +
                                           "AND VC.Data >= ?DataInicio " +
                                           "AND VC.Data <= ?DataFim " +
                                           "ORDER BY VC.ID", Conexao);

                Comando.Parameters.AddWithValue("?Produto", Produto);
                Comando.Parameters.AddWithValue("?DataInicio", DataInicio);
                Comando.Parameters.AddWithValue("?DataFim", DataFim);
                Adaptador = new MySqlDataAdapter(Comando);
                datTabela = new DataTable();
                Adaptador.Fill(datTabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public static void ConfigComboCidades(Control Cidade)
        {
            Global.ConsultarCidades("");
            (Cidade as ComboBox).DataSource = Global.datTabela;
            (Cidade as ComboBox).DisplayMember = "nome";
            (Cidade as ComboBox).ValueMember = "id";
            (Cidade as ComboBox).ResetText();
        }



        // ACHEI UM ERRO .................
        //TA AI A HOMOLOGA~ÇAÃLDSAIKF LKJBVS KF


        // // // // // // // // // // // // // // // // // // // // // //
        // TESTE - FUNCAO PARA INCLUSÃO E DADOS EM QUALQUER FORMMULARIO
        /*
        public static void Inclusao(Form Form_Atual)
        {
            foreach (Control Itens in Form_Atual.Controls)
            {
                if (Itens is TextBox)
                {
                    if ((Itens as TextBox).Enabled)
                    {
                        if (Itens.Text == "")
                        {
                            MessageBox.Show("Favor preecher todos os campos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Itens.Focus();
                            return;
                        }

                        else
                        {
                            try
                            {
                                Mensagem += Itens.Tag + ",";
                                Parametros += "?" + Itens.Tag + ",";
                                Comando.Parameters.AddWithValue("?" + Itens.Tag, Itens.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

            try
            {
                Mensagem = Mensagem.TrimEnd(',');
                Parametros = Parametros.TrimEnd(',');

                Conexao.Open();
                Comando = new MySqlCommand("INSERT INTO Cidades (" + Mensagem + ") VALUES (" + Parametros + ")", Conexao);
                Comando.ExecuteNonQuery();
                Conexao.Close();
                MessageBox.Show("Cidade cadastrada.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexao.Close();
            }

            Mensagem = "";
            Parametros = "";

        }*/
    }
}