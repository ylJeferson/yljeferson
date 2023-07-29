namespace Jeferson_e_Samuel
{
    partial class frmProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutos));
            this.tsTxtBusca = new System.Windows.Forms.ToolStripTextBox();
            this.lklCategorias = new System.Windows.Forms.LinkLabel();
            this.lklFornecedores = new System.Windows.Forms.LinkLabel();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.cboFornecedores = new System.Windows.Forms.ComboBox();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtVenda = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtMinimo = new System.Windows.Forms.TextBox();
            this.txtCodBarra = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNovo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsbGravar = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluir = new System.Windows.Forms.ToolStripButton();
            this.tsbBusca = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbProximo = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbFechar = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbCadastro = new System.Windows.Forms.GroupBox();
            this.btnVideo = new System.Windows.Forms.Button();
            this.ofdArquivo = new System.Windows.Forms.OpenFileDialog();
            this.pdoImprimir = new System.Drawing.Printing.PrintDocument();
            this.ppdVisualizar = new System.Windows.Forms.PrintPreviewDialog();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.grbCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTxtBusca
            // 
            this.tsTxtBusca.AutoSize = false;
            this.tsTxtBusca.Name = "tsTxtBusca";
            this.tsTxtBusca.Size = new System.Drawing.Size(250, 35);
            // 
            // lklCategorias
            // 
            this.lklCategorias.AutoSize = true;
            this.lklCategorias.Location = new System.Drawing.Point(280, 58);
            this.lklCategorias.Name = "lklCategorias";
            this.lklCategorias.Size = new System.Drawing.Size(60, 13);
            this.lklCategorias.TabIndex = 9;
            this.lklCategorias.TabStop = true;
            this.lklCategorias.Text = "Categorias:";
            this.lklCategorias.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCategorias_LinkClicked);
            // 
            // lklFornecedores
            // 
            this.lklFornecedores.AutoSize = true;
            this.lklFornecedores.Location = new System.Drawing.Point(9, 58);
            this.lklFornecedores.Name = "lklFornecedores";
            this.lklFornecedores.Size = new System.Drawing.Size(75, 13);
            this.lklFornecedores.TabIndex = 7;
            this.lklFornecedores.TabStop = true;
            this.lklFornecedores.Text = "Fornecedores:";
            this.lklFornecedores.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklFornecedores_LinkClicked);
            // 
            // cboCategorias
            // 
            this.cboCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(277, 74);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(260, 21);
            this.cboCategorias.TabIndex = 10;
            // 
            // cboFornecedores
            // 
            this.cboFornecedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFornecedores.FormattingEnabled = true;
            this.cboFornecedores.Location = new System.Drawing.Point(6, 74);
            this.cboFornecedores.Name = "cboFornecedores";
            this.cboFornecedores.Size = new System.Drawing.Size(260, 21);
            this.cboFornecedores.TabIndex = 8;
            // 
            // txtCusto
            // 
            this.txtCusto.Location = new System.Drawing.Point(272, 114);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(130, 20);
            this.txtCusto.TabIndex = 16;
            // 
            // txtVideo
            // 
            this.txtVideo.Location = new System.Drawing.Point(54, 143);
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.Size = new System.Drawing.Size(452, 20);
            this.txtVideo.TabIndex = 20;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(60, 32);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(234, 20);
            this.txtDescricao.TabIndex = 4;
            // 
            // txtVenda
            // 
            this.txtVenda.Location = new System.Drawing.Point(412, 114);
            this.txtVenda.Name = "txtVenda";
            this.txtVenda.Size = new System.Drawing.Size(125, 20);
            this.txtVenda.TabIndex = 18;
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(6, 114);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(125, 20);
            this.txtEstoque.TabIndex = 12;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // txtMinimo
            // 
            this.txtMinimo.Location = new System.Drawing.Point(139, 114);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Size = new System.Drawing.Size(125, 20);
            this.txtMinimo.TabIndex = 14;
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.Location = new System.Drawing.Point(300, 32);
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.Size = new System.Drawing.Size(237, 20);
            this.txtCodBarra.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Vídeo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Custo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(415, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Venda:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mínimo:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNovo,
            this.tsbEditar,
            this.tsbCancelar,
            this.tsbGravar,
            this.tsbExcluir,
            this.toolStripSeparator1,
            this.tsTxtBusca,
            this.tsbBusca,
            this.toolStripSeparator2,
            this.tsbPrimeiro,
            this.tsbAnterior,
            this.tsbProximo,
            this.tsbUltimo,
            this.toolStripSeparator3,
            this.tsbImprimir,
            this.tsbFechar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(569, 35);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNovo
            // 
            this.tsbNovo.AutoSize = false;
            this.tsbNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNovo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNovo.Image")));
            this.tsbNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNovo.Name = "tsbNovo";
            this.tsbNovo.Size = new System.Drawing.Size(23, 32);
            this.tsbNovo.Text = "Novo";
            this.tsbNovo.Click += new System.EventHandler(this.tsbNovo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.AutoSize = false;
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 32);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.AutoSize = false;
            this.tsbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelar.Image")));
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(23, 32);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // tsbGravar
            // 
            this.tsbGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGravar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGravar.Image")));
            this.tsbGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGravar.Name = "tsbGravar";
            this.tsbGravar.Size = new System.Drawing.Size(23, 32);
            this.tsbGravar.Text = "Salvar";
            this.tsbGravar.Click += new System.EventHandler(this.tsbGravar_Click);
            // 
            // tsbExcluir
            // 
            this.tsbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExcluir.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcluir.Image")));
            this.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluir.Name = "tsbExcluir";
            this.tsbExcluir.Size = new System.Drawing.Size(23, 32);
            this.tsbExcluir.Text = "Excluir";
            this.tsbExcluir.Click += new System.EventHandler(this.tsbExcluir_Click);
            // 
            // tsbBusca
            // 
            this.tsbBusca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBusca.Image = ((System.Drawing.Image)(resources.GetObject("tsbBusca.Image")));
            this.tsbBusca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBusca.Name = "tsbBusca";
            this.tsbBusca.Size = new System.Drawing.Size(23, 32);
            this.tsbBusca.Text = "toolStripButton1";
            this.tsbBusca.Click += new System.EventHandler(this.tsbBusca_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // tsbPrimeiro
            // 
            this.tsbPrimeiro.AutoSize = false;
            this.tsbPrimeiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimeiro.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrimeiro.Image")));
            this.tsbPrimeiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimeiro.Name = "tsbPrimeiro";
            this.tsbPrimeiro.Size = new System.Drawing.Size(23, 32);
            this.tsbPrimeiro.Text = "Primeiro";
            this.tsbPrimeiro.Click += new System.EventHandler(this.tsbPrimeiro_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.AutoSize = false;
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnterior.Image")));
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(23, 32);
            this.tsbAnterior.Text = "Anterior";
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbProximo
            // 
            this.tsbProximo.AutoSize = false;
            this.tsbProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProximo.Image = ((System.Drawing.Image)(resources.GetObject("tsbProximo.Image")));
            this.tsbProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProximo.Name = "tsbProximo";
            this.tsbProximo.Size = new System.Drawing.Size(23, 32);
            this.tsbProximo.Text = "Proximo";
            this.tsbProximo.Click += new System.EventHandler(this.tsbProximo_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUltimo.Image")));
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(23, 32);
            this.tsbUltimo.Text = "Ultimo";
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.AutoSize = false;
            this.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsbImprimir.Image")));
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(23, 32);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.tsbImprimir_Click);
            // 
            // tsbFechar
            // 
            this.tsbFechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFechar.Image = ((System.Drawing.Image)(resources.GetObject("tsbFechar.Image")));
            this.tsbFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFechar.Name = "tsbFechar";
            this.tsbFechar.Size = new System.Drawing.Size(23, 20);
            this.tsbFechar.Text = "Fechar";
            this.tsbFechar.Click += new System.EventHandler(this.tsbFechar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Estoque:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Código Barra:";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(12, 228);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(387, 150);
            this.dgvProdutos.TabIndex = 23;
            this.dgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descricao:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(6, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(48, 20);
            this.txtID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // grbCadastro
            // 
            this.grbCadastro.AutoSize = true;
            this.grbCadastro.Controls.Add(this.lklCategorias);
            this.grbCadastro.Controls.Add(this.lklFornecedores);
            this.grbCadastro.Controls.Add(this.btnVideo);
            this.grbCadastro.Controls.Add(this.cboCategorias);
            this.grbCadastro.Controls.Add(this.cboFornecedores);
            this.grbCadastro.Controls.Add(this.txtCusto);
            this.grbCadastro.Controls.Add(this.txtVideo);
            this.grbCadastro.Controls.Add(this.txtDescricao);
            this.grbCadastro.Controls.Add(this.txtVenda);
            this.grbCadastro.Controls.Add(this.txtMinimo);
            this.grbCadastro.Controls.Add(this.txtEstoque);
            this.grbCadastro.Controls.Add(this.txtCodBarra);
            this.grbCadastro.Controls.Add(this.label10);
            this.grbCadastro.Controls.Add(this.label9);
            this.grbCadastro.Controls.Add(this.label8);
            this.grbCadastro.Controls.Add(this.label7);
            this.grbCadastro.Controls.Add(this.label6);
            this.grbCadastro.Controls.Add(this.label3);
            this.grbCadastro.Controls.Add(this.label2);
            this.grbCadastro.Controls.Add(this.txtID);
            this.grbCadastro.Controls.Add(this.label1);
            this.grbCadastro.Location = new System.Drawing.Point(12, 38);
            this.grbCadastro.Name = "grbCadastro";
            this.grbCadastro.Size = new System.Drawing.Size(543, 184);
            this.grbCadastro.TabIndex = 0;
            this.grbCadastro.TabStop = false;
            // 
            // btnVideo
            // 
            this.btnVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnVideo.Image")));
            this.btnVideo.Location = new System.Drawing.Point(512, 140);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(25, 25);
            this.btnVideo.TabIndex = 21;
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // ofdArquivo
            // 
            this.ofdArquivo.FileName = "ofdArquivo";
            // 
            // pdoImprimir
            // 
            this.pdoImprimir.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdoImprimir_PrintPage);
            // 
            // ppdVisualizar
            // 
            this.ppdVisualizar.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdVisualizar.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdVisualizar.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdVisualizar.Document = this.pdoImprimir;
            this.ppdVisualizar.Enabled = true;
            this.ppdVisualizar.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdVisualizar.Icon")));
            this.ppdVisualizar.Name = "ppdVisualizar";
            this.ppdVisualizar.Visible = false;
            // 
            // pcbFoto
            // 
            this.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbFoto.Image = ((System.Drawing.Image)(resources.GetObject("pcbFoto.Image")));
            this.pcbFoto.InitialImage = null;
            this.pcbFoto.Location = new System.Drawing.Point(405, 228);
            this.pcbFoto.Name = "pcbFoto";
            this.pcbFoto.Size = new System.Drawing.Size(150, 150);
            this.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbFoto.TabIndex = 19;
            this.pcbFoto.TabStop = false;
            this.pcbFoto.Click += new System.EventHandler(this.pcbFoto_Click);
            // 
            // frmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 394);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.grbCadastro);
            this.Controls.Add(this.pcbFoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produtos";
            this.Activated += new System.EventHandler(this.frmProdutos_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProdutos_FormClosed);
            this.Load += new System.EventHandler(this.frmProdutos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.grbCadastro.ResumeLayout(false);
            this.grbCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripTextBox tsTxtBusca;
        private System.Windows.Forms.ToolStripButton tsbExcluir;
        private System.Windows.Forms.LinkLabel lklCategorias;
        private System.Windows.Forms.LinkLabel lklFornecedores;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.PictureBox pcbFoto;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.ComboBox cboFornecedores;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.ToolStripButton tsbGravar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.TextBox txtVideo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtVenda;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNovo;
        private System.Windows.Forms.TextBox txtMinimo;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.TextBox txtCodBarra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbPrimeiro;
        private System.Windows.Forms.ToolStripButton tsbProximo;
        private System.Windows.Forms.ToolStripButton tsbUltimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbFechar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbCadastro;
        private System.Windows.Forms.OpenFileDialog ofdArquivo;
        private System.Windows.Forms.ToolStripButton tsbBusca;
        private System.Drawing.Printing.PrintDocument pdoImprimir;
        private System.Windows.Forms.PrintPreviewDialog ppdVisualizar;
    }
}