namespace Jeferson_e_Samuel
{
    partial class frmClientes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.grbCadastro = new System.Windows.Forms.GroupBox();
            this.mtbCpf = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mtbDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.txtRenda = new System.Windows.Forms.TextBox();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cboCidades = new System.Windows.Forms.ComboBox();
            this.lklCidade = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNovo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsbGravar = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTxtBusca = new System.Windows.Forms.ToolStripTextBox();
            this.tsbBusca = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbProximo = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbFechar = new System.Windows.Forms.ToolStripButton();
            this.pdoImprimir = new System.Drawing.Printing.PrintDocument();
            this.ppdVisualizar = new System.Windows.Forms.PrintPreviewDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grbCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCadastro
            // 
            this.grbCadastro.AutoSize = true;
            this.grbCadastro.Controls.Add(this.mtbCpf);
            this.grbCadastro.Controls.Add(this.label7);
            this.grbCadastro.Controls.Add(this.mtbDataNasc);
            this.grbCadastro.Controls.Add(this.txtRenda);
            this.grbCadastro.Controls.Add(this.txtUF);
            this.grbCadastro.Controls.Add(this.txtEndereco);
            this.grbCadastro.Controls.Add(this.txtNome);
            this.grbCadastro.Controls.Add(this.txtID);
            this.grbCadastro.Controls.Add(this.cboCidades);
            this.grbCadastro.Controls.Add(this.lklCidade);
            this.grbCadastro.Controls.Add(this.label6);
            this.grbCadastro.Controls.Add(this.label5);
            this.grbCadastro.Controls.Add(this.label4);
            this.grbCadastro.Controls.Add(this.label3);
            this.grbCadastro.Controls.Add(this.label2);
            this.grbCadastro.Controls.Add(this.label1);
            this.grbCadastro.Location = new System.Drawing.Point(12, 38);
            this.grbCadastro.Name = "grbCadastro";
            this.grbCadastro.Size = new System.Drawing.Size(545, 150);
            this.grbCadastro.TabIndex = 0;
            this.grbCadastro.TabStop = false;
            // 
            // mtbCpf
            // 
            this.mtbCpf.Location = new System.Drawing.Point(426, 32);
            this.mtbCpf.Mask = "000.000.000-00";
            this.mtbCpf.Name = "mtbCpf";
            this.mtbCpf.Size = new System.Drawing.Size(112, 20);
            this.mtbCpf.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "CPF:";
            // 
            // mtbDataNasc
            // 
            this.mtbDataNasc.Location = new System.Drawing.Point(426, 71);
            this.mtbDataNasc.Mask = "00/00/0000";
            this.mtbDataNasc.Name = "mtbDataNasc";
            this.mtbDataNasc.Size = new System.Drawing.Size(113, 20);
            this.mtbDataNasc.TabIndex = 10;
            this.mtbDataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // txtRenda
            // 
            this.txtRenda.Location = new System.Drawing.Point(472, 110);
            this.txtRenda.Name = "txtRenda";
            this.txtRenda.Size = new System.Drawing.Size(67, 20);
            this.txtRenda.TabIndex = 16;
            // 
            // txtUF
            // 
            this.txtUF.Enabled = false;
            this.txtUF.Location = new System.Drawing.Point(426, 110);
            this.txtUF.Name = "txtUF";
            this.txtUF.ReadOnly = true;
            this.txtUF.Size = new System.Drawing.Size(37, 20);
            this.txtUF.TabIndex = 14;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(6, 71);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(414, 20);
            this.txtEndereco.TabIndex = 8;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(77, 32);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(343, 20);
            this.txtNome.TabIndex = 4;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(6, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(65, 20);
            this.txtID.TabIndex = 2;
            // 
            // cboCidades
            // 
            this.cboCidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCidades.FormattingEnabled = true;
            this.cboCidades.IntegralHeight = false;
            this.cboCidades.Location = new System.Drawing.Point(6, 110);
            this.cboCidades.Name = "cboCidades";
            this.cboCidades.Size = new System.Drawing.Size(414, 21);
            this.cboCidades.TabIndex = 12;
            this.cboCidades.SelectedIndexChanged += new System.EventHandler(this.cboCidades_SelectedIndexChanged);
            // 
            // lklCidade
            // 
            this.lklCidade.AutoSize = true;
            this.lklCidade.Location = new System.Drawing.Point(9, 94);
            this.lklCidade.Name = "lklCidade";
            this.lklCidade.Size = new System.Drawing.Size(43, 13);
            this.lklCidade.TabIndex = 11;
            this.lklCidade.TabStop = true;
            this.lklCidade.Text = "Cidade:";
            this.lklCidade.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCidade_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Renda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "UF:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Data de Nascimento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Endereço do Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome do Cliente";
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
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(12, 194);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(545, 150);
            this.dgvClientes.TabIndex = 17;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
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
            this.toolStrip1.Size = new System.Drawing.Size(570, 35);
            this.toolStrip1.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // tsTxtBusca
            // 
            this.tsTxtBusca.AutoSize = false;
            this.tsTxtBusca.Name = "tsTxtBusca";
            this.tsTxtBusca.Size = new System.Drawing.Size(250, 35);
            // 
            // tsbBusca
            // 
            this.tsbBusca.AutoSize = false;
            this.tsbBusca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBusca.Image = ((System.Drawing.Image)(resources.GetObject("tsbBusca.Image")));
            this.tsbBusca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBusca.Name = "tsbBusca";
            this.tsbBusca.Size = new System.Drawing.Size(23, 32);
            this.tsbBusca.Text = "Busca";
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
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 353);
            this.Controls.Add(this.grbCadastro);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            this.Activated += new System.EventHandler(this.frmClientes_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClientes_FormClosed);
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.grbCadastro.ResumeLayout(false);
            this.grbCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCadastro;
        private System.Windows.Forms.MaskedTextBox mtbCpf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtbDataNasc;
        private System.Windows.Forms.TextBox txtRenda;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cboCidades;
        private System.Windows.Forms.LinkLabel lklCidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNovo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.ToolStripButton tsbGravar;
        private System.Windows.Forms.ToolStripButton tsbExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsTxtBusca;
        private System.Windows.Forms.ToolStripButton tsbBusca;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbPrimeiro;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.ToolStripButton tsbProximo;
        private System.Windows.Forms.ToolStripButton tsbUltimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbFechar;
        private System.Drawing.Printing.PrintDocument pdoImprimir;
        private System.Windows.Forms.PrintPreviewDialog ppdVisualizar;
    }
}