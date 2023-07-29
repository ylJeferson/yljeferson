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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }


          // // // // // // // // // 
         //  LOAD DO FORMULARIO  //
        // // // // // // // // //  
        private void frmMenu_Load(object sender, EventArgs e)
        {
           // Global.AbrirConexao();
           // Global.CriaTabelas();

            this.MaximizeBox = false;
            tslblUsuario.Text += Global.Usuario;
            tslblNivel.Text += Global.Nivel;

            if (Global.Admin == false)
            {
              tsmiUsuarios.Visible = false;
            }
        }


          // // // // // // // // // // //
         //  FECHAMENTO DO FORMULARIO  //
        // // // // // // // // // // //
        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin Log = new frmLogin();
            Log.Show();
        }


          // // // // //
         //  LOGOUT  //
        // // // // // 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }


          // // // // // // // // // // // 
         //   FORMULARIO APLICATIVOS   //
        // // // // // // // // // // // 
        private void tsmiAplicativos_Click(object sender, EventArgs e)
        {
            frmAplicativos Aplicativos = new frmAplicativos();
            Aplicativos.Show();
        }


          // // // // // // // // 
         // FORMULARIO BACKUP //
        // // // // // // // // 
        private void tsmiBackup_Click(object sender, EventArgs e)
        {
            frmBackup Backup = new frmBackup();
            Backup.Show();
        }


          // // // // // // // // // // 
         //  FORMULARIO CATEGORIAS  //
        // // // // // // // // // // 
        private void tsmiCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias Categoria = new frmCategorias();
            Categoria.Show();
        }


          // // // // // // // // // // 
         // FORMULARIO CENTRO CUSTO //
        // // // // // // // // // // 
        private void tsmiCentroCusto_Click(object sender, EventArgs e)
        {
            frmCentroCusto CentroCusto = new frmCentroCusto();
            CentroCusto.Show();
        }


          // // // // // // // // //
         //  FORMULARIO CIDADES  //
        // // // // // // // // //
        private void tsmiCidades_Click(object sender, EventArgs e)
        {
            frmCidades Cidade = new frmCidades();
            Cidade.Show();
        }


          // // // // // // // // // //
         //   FORMULARIO CLIENTES   //
        // // // // // // // // // //
        private void tsmiClientes_Click(object sender, EventArgs e)
        {
            frmClientes Cliente = new frmClientes();
            Cliente.Show();
        }


          // // // // // // // // // 
         // FORMULARIO COBRANÇAS //
        // // // // // // // // //
        private void tsmiCobrancas_Click(object sender, EventArgs e)
        {
            frmCaixa Caixa = new frmCaixa();
            Caixa.Show();
        }


          // // // // // // // // // 
         //  FORMULARIO COMPRAS  //
        // // // // // // // // //
        private void tsmiCompras_Click(object sender, EventArgs e)
        {
            frmLancamentos Lacamento = new frmLancamentos();
            Lacamento.Show();
        }


          // // // // // // // // // //
         //   FORMULARIO CONSULTA   //
        // // // // // // // // // //
        private void tsmiConsulta_Click(object sender, EventArgs e)
        {
            frmConsulta Consulta = new frmConsulta();
            Consulta.Show();
        }


          // // // // // // // // // //
         //   FORMULARIO DESPESAS   //
        // // // // // // // // // //
        private void tsmiDespesas_Click(object sender, EventArgs e)
        {
            frmDespesas Despesas = new frmDespesas();
            Despesas.Show();
        }


          // // // // // // // // // // // //
         //    FORMULARIO FORNECEDORES    //
        // // // // // // // // // // // //
        private void tsmiFornecedores_Click(object sender, EventArgs e)
        {
            frmFornecedores Fornecedores = new frmFornecedores();
            Fornecedores.Show();
        }


          // // // // // // // // // //
         //  FORMULARIO PAGAMENTOS  //
        // // // // // // // // // //
        private void tsmiPagamentos_Click(object sender, EventArgs e)
        {
            frmPagamento Pagamento = new frmPagamento();
            Pagamento.Show();
        }


          // // // // // // // // // //
         //   FORMULARIO PRODUTOS   //
        // // // // // // // // // //
        private void tsmiProdutos_Click(object sender, EventArgs e)
        {
            frmProdutos Produto = new frmProdutos();
            Produto.Show();
        }


          // // // // // // // // // //
         //   FORMULARIO USUARIOS   //
        // // // // // // // // // //
        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios Usuario = new frmUsuarios();
            Usuario.Show();
        }


          // // // // // // // // // //
         //    FORMULARIO VENDAS    //
        // // // // // // // // // //
        private void tsmiVendas_Click(object sender, EventArgs e)
        {
            frmVendas Vendas = new frmVendas();
            Vendas.Show();
        }


          // // // // // // // // // // // //
         // FORMULARIO VENDAS POR PRODUTO //
        // // // // // // // // // // // //
        private void tsmiVendasPorProduto_Click(object sender, EventArgs e)
        {
            frmConsulta Consulta = new frmConsulta();
            Consulta.Show();
        }

        private void tsmiFechamentoDoCaixa_Click(object sender, EventArgs e)
        {
            frmFechamento Fechamento = new frmFechamento();
            Fechamento.Show();
        }
    }
}
