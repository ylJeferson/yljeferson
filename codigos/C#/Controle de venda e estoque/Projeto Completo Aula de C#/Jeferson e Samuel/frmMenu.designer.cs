namespace Jeferson_e_Samuel
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCentroCusto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCIdades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFinanceiro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPagamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCobrancas = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnaliseGerencial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVendasPorProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFechamentoDoCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUtilitarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAplicativos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tspBaixo = new System.Windows.Forms.ToolStrip();
            this.tslblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.tslblNivel = new System.Windows.Forms.ToolStripLabel();
            this.tsbLogout = new System.Windows.Forms.ToolStripButton();
            this.msMenu.SuspendLayout();
            this.tspBaixo.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCadastros,
            this.tsmiFinanceiro,
            this.relatórioToolStripMenuItem,
            this.tsmiUtilitarios});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(286, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsmiCadastros
            // 
            this.tsmiCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCategorias,
            this.tsmiCentroCusto,
            this.tsmiCIdades,
            this.tsmiClientes,
            this.tsmiDespesas,
            this.tsmiFornecedores,
            this.tsmiProdutos,
            this.tsmiUsuarios});
            this.tsmiCadastros.Name = "tsmiCadastros";
            this.tsmiCadastros.Size = new System.Drawing.Size(66, 20);
            this.tsmiCadastros.Text = "Cadastro";
            // 
            // tsmiCategorias
            // 
            this.tsmiCategorias.Name = "tsmiCategorias";
            this.tsmiCategorias.Size = new System.Drawing.Size(160, 22);
            this.tsmiCategorias.Text = "Categorias";
            this.tsmiCategorias.Click += new System.EventHandler(this.tsmiCategorias_Click);
            // 
            // tsmiCentroCusto
            // 
            this.tsmiCentroCusto.Name = "tsmiCentroCusto";
            this.tsmiCentroCusto.Size = new System.Drawing.Size(160, 22);
            this.tsmiCentroCusto.Text = "Centro de Custo";
            this.tsmiCentroCusto.Click += new System.EventHandler(this.tsmiCentroCusto_Click);
            // 
            // tsmiCIdades
            // 
            this.tsmiCIdades.Name = "tsmiCIdades";
            this.tsmiCIdades.Size = new System.Drawing.Size(160, 22);
            this.tsmiCIdades.Text = "Cidades";
            this.tsmiCIdades.Click += new System.EventHandler(this.tsmiCidades_Click);
            // 
            // tsmiClientes
            // 
            this.tsmiClientes.Name = "tsmiClientes";
            this.tsmiClientes.Size = new System.Drawing.Size(160, 22);
            this.tsmiClientes.Text = "Clientes";
            this.tsmiClientes.Click += new System.EventHandler(this.tsmiClientes_Click);
            // 
            // tsmiDespesas
            // 
            this.tsmiDespesas.Name = "tsmiDespesas";
            this.tsmiDespesas.Size = new System.Drawing.Size(160, 22);
            this.tsmiDespesas.Text = "Despesas";
            this.tsmiDespesas.Click += new System.EventHandler(this.tsmiDespesas_Click);
            // 
            // tsmiFornecedores
            // 
            this.tsmiFornecedores.Name = "tsmiFornecedores";
            this.tsmiFornecedores.Size = new System.Drawing.Size(160, 22);
            this.tsmiFornecedores.Text = "Fornecedores";
            this.tsmiFornecedores.Click += new System.EventHandler(this.tsmiFornecedores_Click);
            // 
            // tsmiProdutos
            // 
            this.tsmiProdutos.Name = "tsmiProdutos";
            this.tsmiProdutos.Size = new System.Drawing.Size(160, 22);
            this.tsmiProdutos.Text = "Produtos";
            this.tsmiProdutos.Click += new System.EventHandler(this.tsmiProdutos_Click);
            // 
            // tsmiUsuarios
            // 
            this.tsmiUsuarios.Name = "tsmiUsuarios";
            this.tsmiUsuarios.Size = new System.Drawing.Size(160, 22);
            this.tsmiUsuarios.Text = "Usuários";
            this.tsmiUsuarios.Click += new System.EventHandler(this.tsmiUsuarios_Click);
            // 
            // tsmiFinanceiro
            // 
            this.tsmiFinanceiro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCompras,
            this.tsmiVendas,
            this.tsmiPagamentos,
            this.tsmiCobrancas});
            this.tsmiFinanceiro.Name = "tsmiFinanceiro";
            this.tsmiFinanceiro.Size = new System.Drawing.Size(74, 20);
            this.tsmiFinanceiro.Text = "Financeiro";
            // 
            // tsmiCompras
            // 
            this.tsmiCompras.Name = "tsmiCompras";
            this.tsmiCompras.Size = new System.Drawing.Size(140, 22);
            this.tsmiCompras.Text = "Compras";
            this.tsmiCompras.Click += new System.EventHandler(this.tsmiCompras_Click);
            // 
            // tsmiVendas
            // 
            this.tsmiVendas.Name = "tsmiVendas";
            this.tsmiVendas.Size = new System.Drawing.Size(140, 22);
            this.tsmiVendas.Text = "Vendas";
            this.tsmiVendas.Click += new System.EventHandler(this.tsmiVendas_Click);
            // 
            // tsmiPagamentos
            // 
            this.tsmiPagamentos.Name = "tsmiPagamentos";
            this.tsmiPagamentos.Size = new System.Drawing.Size(140, 22);
            this.tsmiPagamentos.Text = "Pagamentos";
            this.tsmiPagamentos.Click += new System.EventHandler(this.tsmiPagamentos_Click);
            // 
            // tsmiCobrancas
            // 
            this.tsmiCobrancas.Name = "tsmiCobrancas";
            this.tsmiCobrancas.Size = new System.Drawing.Size(140, 22);
            this.tsmiCobrancas.Text = "Cobranças";
            this.tsmiCobrancas.Click += new System.EventHandler(this.tsmiCobrancas_Click);
            // 
            // relatórioToolStripMenuItem
            // 
            this.relatórioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAnaliseGerencial,
            this.tsmiVendasPorProduto,
            this.tsmiFechamentoDoCaixa});
            this.relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            this.relatórioToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.relatórioToolStripMenuItem.Text = "Relatório";
            // 
            // tsmiAnaliseGerencial
            // 
            this.tsmiAnaliseGerencial.Name = "tsmiAnaliseGerencial";
            this.tsmiAnaliseGerencial.Size = new System.Drawing.Size(188, 22);
            this.tsmiAnaliseGerencial.Text = "Análise Gerencial";
            // 
            // tsmiVendasPorProduto
            // 
            this.tsmiVendasPorProduto.Name = "tsmiVendasPorProduto";
            this.tsmiVendasPorProduto.Size = new System.Drawing.Size(188, 22);
            this.tsmiVendasPorProduto.Text = "Vendas Por Produto";
            this.tsmiVendasPorProduto.Click += new System.EventHandler(this.tsmiVendasPorProduto_Click);
            // 
            // tsmiFechamentoDoCaixa
            // 
            this.tsmiFechamentoDoCaixa.Name = "tsmiFechamentoDoCaixa";
            this.tsmiFechamentoDoCaixa.Size = new System.Drawing.Size(188, 22);
            this.tsmiFechamentoDoCaixa.Text = "Fechamento do Caixa";
            this.tsmiFechamentoDoCaixa.Click += new System.EventHandler(this.tsmiFechamentoDoCaixa_Click);
            // 
            // tsmiUtilitarios
            // 
            this.tsmiUtilitarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBackup,
            this.tsmiAplicativos,
            this.tsmiExportar,
            this.tsmiEmail});
            this.tsmiUtilitarios.Name = "tsmiUtilitarios";
            this.tsmiUtilitarios.Size = new System.Drawing.Size(69, 20);
            this.tsmiUtilitarios.Text = "Utilitários";
            // 
            // tsmiBackup
            // 
            this.tsmiBackup.Image = ((System.Drawing.Image)(resources.GetObject("tsmiBackup.Image")));
            this.tsmiBackup.Name = "tsmiBackup";
            this.tsmiBackup.Size = new System.Drawing.Size(168, 22);
            this.tsmiBackup.Text = "Backup";
            this.tsmiBackup.Click += new System.EventHandler(this.tsmiBackup_Click);
            // 
            // tsmiAplicativos
            // 
            this.tsmiAplicativos.Name = "tsmiAplicativos";
            this.tsmiAplicativos.Size = new System.Drawing.Size(168, 22);
            this.tsmiAplicativos.Text = "Aplicativos";
            this.tsmiAplicativos.Click += new System.EventHandler(this.tsmiAplicativos_Click);
            // 
            // tsmiExportar
            // 
            this.tsmiExportar.Name = "tsmiExportar";
            this.tsmiExportar.Size = new System.Drawing.Size(168, 22);
            this.tsmiExportar.Text = "Exportar Produtos";
            // 
            // tsmiEmail
            // 
            this.tsmiEmail.Name = "tsmiEmail";
            this.tsmiEmail.Size = new System.Drawing.Size(168, 22);
            this.tsmiEmail.Text = "Enviar Email";
            // 
            // tspBaixo
            // 
            this.tspBaixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tspBaixo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblUsuario,
            this.tslblNivel,
            this.tsbLogout});
            this.tspBaixo.Location = new System.Drawing.Point(0, 126);
            this.tspBaixo.Name = "tspBaixo";
            this.tspBaixo.Size = new System.Drawing.Size(286, 25);
            this.tspBaixo.TabIndex = 1;
            // 
            // tslblUsuario
            // 
            this.tslblUsuario.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.tslblUsuario.Name = "tslblUsuario";
            this.tslblUsuario.Size = new System.Drawing.Size(53, 22);
            this.tslblUsuario.Text = "Usuário: ";
            // 
            // tslblNivel
            // 
            this.tslblNivel.Name = "tslblNivel";
            this.tslblNivel.Size = new System.Drawing.Size(40, 22);
            this.tslblNivel.Text = "Nivel: ";
            // 
            // tsbLogout
            // 
            this.tsbLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogout.Image")));
            this.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(23, 22);
            this.tsbLogout.Text = "Logout";
            this.tsbLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(286, 151);
            this.Controls.Add(this.tspBaixo);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.tspBaixo.ResumeLayout(false);
            this.tspBaixo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFinanceiro;
        private System.Windows.Forms.ToolStripMenuItem tsmiCobrancas;
        private System.Windows.Forms.ToolStripMenuItem tsmiPagamentos;
        private System.Windows.Forms.ToolStripMenuItem tsmiUtilitarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiAplicativos;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportar;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmiCadastros;
        private System.Windows.Forms.ToolStripMenuItem tsmiCategorias;
        private System.Windows.Forms.ToolStripMenuItem tsmiCIdades;
        private System.Windows.Forms.ToolStripMenuItem tsmiClientes;
        private System.Windows.Forms.ToolStripMenuItem tsmiFornecedores;
        private System.Windows.Forms.ToolStripMenuItem tsmiProdutos;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompras;
        private System.Windows.Forms.ToolStripMenuItem tsmiVendas;
        private System.Windows.Forms.ToolStripMenuItem relatórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnaliseGerencial;
        private System.Windows.Forms.ToolStripMenuItem tsmiVendasPorProduto;
        private System.Windows.Forms.ToolStripMenuItem tsmiFechamentoDoCaixa;
        private System.Windows.Forms.ToolStrip tspBaixo;
        private System.Windows.Forms.ToolStripLabel tslblUsuario;
        private System.Windows.Forms.ToolStripLabel tslblNivel;
        private System.Windows.Forms.ToolStripButton tsbLogout;
        private System.Windows.Forms.ToolStripMenuItem tsmiCentroCusto;
        private System.Windows.Forms.ToolStripMenuItem tsmiDespesas;
    }
}

